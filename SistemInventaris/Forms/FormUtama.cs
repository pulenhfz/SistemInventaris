// ============================================================
// FormUtama.cs - Form dashboard utama setelah login berhasil
// Menampilkan data barang dan tombol CRUD
// ============================================================
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SistemInventaris.Forms
{
    public partial class FormUtama : MaterialForm
    {
        private readonly string _namaUser;
        private readonly string _roleUser;

        /// <summary>
        /// Menerima nama dan role pengguna dari FormLogin
        /// </summary>
        public FormUtama(string namaUser, string roleUser)
        {
            InitializeComponent();

            _namaUser = namaUser;
            _roleUser = roleUser;

            // Daftarkan form ke MaterialSkinManager (tema sudah diset di FormLogin)
            MaterialSkinManager.Instance.AddFormToManage(this);
        }

        // ============================================================
        // EVENT: Form Load - Muat data saat form pertama kali dibuka
        // ============================================================
        private void FormUtama_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Selamat Datang, {_namaUser}  |  Role: {_roleUser}";
            LoadData();
            TerapkanHakAkses();
        }

        /// <summary>
        /// Mengatur visibilitas tombol CRUD berdasarkan role pengguna.
        /// Hanya Admin yang boleh menambah, mengedit, dan menghapus barang.
        /// </summary>
        private void TerapkanHakAkses()
        {
            bool isAdmin = _roleUser.Equals("Admin", StringComparison.OrdinalIgnoreCase);
            btnTambah.Enabled = isAdmin;
            btnEdit.Enabled = isAdmin;
            btnHapus.Enabled = isAdmin;

            if (!isAdmin)
            {
                // Beri tahu pengguna bahwa akses CRUD dibatasi
                lblWelcome.Text += "  |  [Hanya Lihat]";
            }
        }

        /// <summary>
        /// Memuat data barang dari database dengan JOIN ke Kategori
        /// lalu menampilkannya di DataGridView
        /// </summary>
        private void LoadData()
        {
            string query = @"
                SELECT b.BarangID, b.KodeBarang, b.NamaBarang,
                       k.NamaKategori, b.Stok, b.HargaSatuan, b.Satuan
                FROM   Barang b
                INNER JOIN Kategori k ON b.KategoriID = k.KategoriID
                ORDER  BY b.BarangID DESC";

            DataTable dt = DBHelper.GetDataTable(query);
            dgvBarang.DataSource = dt;

            // Sembunyikan kolom ID (tidak perlu ditampilkan ke pengguna)
            if (dgvBarang.Columns.Contains("BarangID"))
                dgvBarang.Columns["BarangID"].Visible = false;

            // Atur header kolom agar lebih mudah dibaca
            SetColumnHeaders();

            // Terapkan gaya modern pada DataGridView
            StyleGrid(dgvBarang);

            // Format kolom Harga Satuan sebagai Rupiah (tanpa desimal)
            if (dgvBarang.Columns.Contains("HargaSatuan"))
                dgvBarang.Columns["HargaSatuan"].DefaultCellStyle.Format = "N0";
        }

        private void SetColumnHeaders()
        {
            var headers = new Dictionary<string, string>
            {
                { "KodeBarang",  "Kode Barang"  },
                { "NamaBarang",  "Nama Barang"  },
                { "NamaKategori","Kategori"     },
                { "Stok",        "Stok"         },
                { "HargaSatuan", "Harga Satuan" },
                { "Satuan",      "Satuan"       }
            };

            foreach (var kv in headers)
                if (dgvBarang.Columns.Contains(kv.Key))
                    dgvBarang.Columns[kv.Key].HeaderText = kv.Value;
        }

        /// <summary>
        /// Mengatur tampilan DataGridView agar terlihat modern
        /// </summary>
        private void StyleGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(220, 220, 230);

            // Header: latar Indigo, teks putih, tebal
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(63, 81, 181); // Indigo
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersHeight = 36;

            // Sel default
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Padding = new Padding(3);

            // Warna selang-seling baris
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 255);

            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // ============================================================
        // EVENT: Button Click - Buka form tambah barang
        // ============================================================
        private void btnTambah_Click(object sender, EventArgs e)
        {
            FormInputBarang form = new FormInputBarang("Tambah", 0);
            form.ShowDialog();
            LoadData(); // Refresh setelah form ditutup
        }

        // ============================================================
        // EVENT: Button Click - Buka form edit barang
        // ============================================================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBarang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih barang yang ingin diedit terlebih dahulu.",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int barangID = Convert.ToInt32(dgvBarang.SelectedRows[0].Cells["BarangID"].Value);
            FormInputBarang form = new FormInputBarang("Edit", barangID);
            form.ShowDialog();
            LoadData();
        }

        // ============================================================
        // EVENT: Button Click - Hapus barang yang dipilih
        // Konfirmasi dengan MessageBox sebelum menghapus
        // ============================================================
        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (dgvBarang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih barang yang ingin dihapus terlebih dahulu.",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string namaBarang = dgvBarang.SelectedRows[0].Cells["NamaBarang"].Value.ToString()!;
            int barangID = Convert.ToInt32(dgvBarang.SelectedRows[0].Cells["BarangID"].Value);

            // Konfirmasi penghapusan
            DialogResult result = MessageBox.Show(
                $"Yakin ingin menghapus barang \"{namaBarang}\"?",
                "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            int affected = DBHelper.ExecuteNonQuery(
                "DELETE FROM Barang WHERE BarangID = @id",
                new SqlParameter("@id", SqlDbType.Int) { Value = barangID });

            if (affected > 0)
                MessageBox.Show("Barang berhasil dihapus.", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadData();
        }

        // ============================================================
        // EVENT: Button Click - Refresh data dari database
        // ============================================================
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // ============================================================
        // EVENT: Button Click - Buka form pencarian/laporan
        // ============================================================
        private void btnPencarian_Click(object sender, EventArgs e)
        {
            FormPencarian form = new FormPencarian();
            form.ShowDialog();
        }

        // ============================================================
        // EVENT: Button Click - Logout dengan konfirmasi
        // ============================================================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin logout?",
                "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.Close();
        }

        // ============================================================
        // EVENT: FormClosing - Tutup seluruh aplikasi saat form ditutup
        // ============================================================
        private void FormUtama_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
