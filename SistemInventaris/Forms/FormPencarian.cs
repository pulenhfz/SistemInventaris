// ============================================================
// FormPencarian.cs - Form pencarian dan laporan barang
// ============================================================
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SistemInventaris.Forms
{
    public partial class FormPencarian : MaterialForm
    {
        private System.Windows.Forms.Timer _debounceTimer = null!;
        private bool _loadingKategori = false; // guard agar SelectedIndexChanged tidak fire saat LoadKategori

        public FormPencarian()
        {
            InitializeComponent();
            MaterialSkinManager.Instance.AddFormToManage(this);

            // Inisialisasi debounce timer untuk live search
            // Mencegah query ke DB setiap keystroke
            _debounceTimer = new System.Windows.Forms.Timer();
            _debounceTimer.Interval = 350; // tunggu 350ms setelah ketikan terakhir
            _debounceTimer.Tick += (s, e) =>
            {
                _debounceTimer.Stop();
                LoadData(txtCari.Text, GetSelectedKategoriID());
            };

            this.FormClosed += FormPencarian_FormClosed;
        }

        // ============================================================
        // EVENT: Form Load - Isi ComboBox kategori dan muat semua data
        // ============================================================
        private void FormPencarian_Load(object sender, EventArgs e)
        {
            LoadKategori();
            LoadData("", 0);
        }

        /// <summary>
        /// Memuat daftar kategori ke ComboBox dengan opsi "Semua Kategori" di awal
        /// </summary>
        private void LoadKategori()
        {
            _loadingKategori = true;
            try
            {
                DataTable dt = DBHelper.GetDataTable(
                    "SELECT KategoriID, NamaKategori FROM Kategori ORDER BY NamaKategori");

                // Buat DataTable baru dengan baris "Semua Kategori" di posisi pertama
                DataTable dtFilter = dt.Clone();
                DataRow rowSemua = dtFilter.NewRow();
                rowSemua["KategoriID"] = 0;
                rowSemua["NamaKategori"] = "Semua Kategori";
                dtFilter.Rows.Add(rowSemua);

                foreach (DataRow row in dt.Rows)
                    dtFilter.ImportRow(row);

                cmbFilterKategori.DataSource = dtFilter;
                cmbFilterKategori.DisplayMember = "NamaKategori";
                cmbFilterKategori.ValueMember = "KategoriID";
                cmbFilterKategori.SelectedIndex = 0;
            }
            finally
            {
                _loadingKategori = false;
            }
        }

        /// <summary>
        /// Membaca KategoriID yang dipilih dari ComboBox secara aman.
        /// Menghindari InvalidCastException saat DataSource adalah DataTable.
        /// </summary>
        private int GetSelectedKategoriID()
        {
            if (cmbFilterKategori.SelectedItem is DataRowView row)
                return Convert.ToInt32(row["KategoriID"]);
            return 0;
        }

        /// <summary>
        /// Memuat data barang berdasarkan kata kunci dan filter kategori
        /// </summary>
        private void LoadData(string keyword, int kategoriID)
        {
            // Query dasar dengan JOIN ke Kategori
            string query = @"
                SELECT b.BarangID, b.KodeBarang, b.NamaBarang,
                       k.NamaKategori, b.Stok, b.HargaSatuan, b.Satuan
                FROM   Barang b
                INNER JOIN Kategori k ON b.KategoriID = k.KategoriID
                WHERE  1=1";

            var parameters = new List<SqlParameter>();

            // Tambahkan filter pencarian jika ada kata kunci
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query += " AND (b.NamaBarang LIKE @keyword OR b.KodeBarang LIKE @keyword)";
                parameters.Add(new SqlParameter("@keyword", SqlDbType.NVarChar)
                    { Value = "%" + keyword.Trim() + "%" });
            }

            // Tambahkan filter kategori jika bukan "Semua Kategori"
            if (kategoriID > 0)
            {
                query += " AND b.KategoriID = @katId";
                parameters.Add(new SqlParameter("@katId", SqlDbType.Int) { Value = kategoriID });
            }

            query += " ORDER BY b.NamaBarang";

            DataTable dt = DBHelper.GetDataTable(query, parameters.ToArray());
            dgvHasil.DataSource = dt;

            // Sembunyikan kolom ID
            if (dgvHasil.Columns.Contains("BarangID"))
                dgvHasil.Columns["BarangID"].Visible = false;

            // Atur header kolom
            var headers = new Dictionary<string, string>
            {
                { "KodeBarang",   "Kode Barang"  },
                { "NamaBarang",   "Nama Barang"  },
                { "NamaKategori", "Kategori"     },
                { "HargaSatuan",  "Harga Satuan" }
            };
            foreach (var kv in headers)
                if (dgvHasil.Columns.Contains(kv.Key))
                    dgvHasil.Columns[kv.Key].HeaderText = kv.Value;

            StyleGrid(dgvHasil);

            // Format kolom Harga Satuan sebagai Rupiah (tanpa desimal)
            if (dgvHasil.Columns.Contains("HargaSatuan"))
                dgvHasil.Columns["HargaSatuan"].DefaultCellStyle.Format = "N0";

            // Update label total hasil
            lblTotal.Text = $"Total: {dt.Rows.Count} barang ditemukan";
        }

        /// <summary>
        /// Mengatur tampilan DataGridView agar terlihat modern
        /// </summary>
        private void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle     = BorderStyle.None;
            dgv.GridColor       = Color.FromArgb(220, 220, 230);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font      = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 36;

            dgv.DefaultCellStyle.Font               = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.SelectionBackColor  = Color.FromArgb(230, 230, 250);
            dgv.DefaultCellStyle.SelectionForeColor  = Color.Black;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 255);

            dgv.RowHeadersVisible   = false;
            dgv.AllowUserToAddRows  = false;
            dgv.ReadOnly            = true;
            dgv.SelectionMode       = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        // EVENT: TextChanged - Live search saat pengguna mengetik
        // Pencarian langsung tanpa perlu klik tombol Cari
        // ============================================================
        private void txtCari_TextChanged(object sender, EventArgs e)
        {
            // Reset timer setiap kali ada keystroke baru (debounce pattern)
            _debounceTimer.Stop();
            _debounceTimer.Start();
        }

        // ============================================================
        // EVENT: SelectedIndexChanged - Filter ulang saat kategori berubah
        // ============================================================
        private void cmbFilterKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Abaikan event yang terpicu saat LoadKategori sedang berjalan
            if (_loadingKategori) return;
            LoadData(txtCari.Text, GetSelectedKategoriID());
        }

        // ============================================================
        // EVENT: Button Click - Cari data secara manual
        // ============================================================
        private void btnCari_Click(object sender, EventArgs e)
        {
            LoadData(txtCari.Text, GetSelectedKategoriID());
        }

        // ============================================================
        // EVENT: Button Click - Reset semua filter dan tampilkan semua data
        // ============================================================
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCari.Text = "";
            cmbFilterKategori.SelectedIndex = 0;
            LoadData("", 0);
        }

        private void FormPencarian_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _debounceTimer?.Dispose();
        }
    }
}
