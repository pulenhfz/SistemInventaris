// ============================================================
// FormInputBarang.cs - Form tambah / edit data barang
// ============================================================
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SistemInventaris.Forms
{
    public partial class FormInputBarang : MaterialForm
    {
        private readonly string _mode;     // "Tambah" atau "Edit"
        private readonly int    _barangID; // ID barang yang diedit (0 jika Tambah)

        public FormInputBarang(string mode, int barangID)
        {
            InitializeComponent();

            MaterialSkinManager.Instance.AddFormToManage(this);

            _mode     = mode;
            _barangID = barangID;

            // Atur judul form sesuai mode
            lblTitle.Text = (_mode == "Edit") ? "Edit Barang" : "Tambah Barang";
            this.Text     = lblTitle.Text;
        }

        // ============================================================
        // EVENT: Form Load - Isi ComboBox dan data jika mode Edit
        // ============================================================
        private void FormInputBarang_Load(object sender, EventArgs e)
        {
            LoadKategori();

            // Isi pilihan satuan
            cmbSatuan.Items.Clear();
            cmbSatuan.Items.AddRange(new object[] { "Pcs", "Unit", "Box", "Set", "Kg", "Rim" });
            cmbSatuan.SelectedIndex = 0;

            // Auto-generate kode barang hanya untuk mode Tambah
            if (_mode == "Tambah")
            {
                txtKodeBarang.Text = GenerateKodeBarang();
                txtKodeBarang.Enabled = false; // kode otomatis, tidak perlu diedit
            }

            // Jika mode Edit, muat data barang yang ada
            if (_mode == "Edit" && _barangID > 0)
                LoadBarangData();
        }

        /// <summary>
        /// Membaca KategoriID yang dipilih dari ComboBox secara aman.
        /// Menghindari InvalidCastException saat DataSource adalah DataTable.
        /// </summary>
        private int GetSelectedKategoriID()
        {
            if (cmbKategori.SelectedItem is DataRowView row)
                return Convert.ToInt32(row["KategoriID"]);
            return 0;
        }

        /// <summary>
        /// Generate kode barang otomatis format BRG-XXX berdasarkan data terakhir di DB.
        /// </summary>
        private string GenerateKodeBarang()
        {
            object? result = DBHelper.ExecuteScalar(
                "SELECT TOP 1 KodeBarang FROM Barang ORDER BY BarangID DESC");

            if (result == null || result == DBNull.Value)
                return "BRG-001";

            string last = result.ToString()!;
            // Ambil angka di belakang "BRG-"
            if (last.StartsWith("BRG-") && int.TryParse(last.Substring(4), out int num))
                return $"BRG-{(num + 1):D3}";

            // Fallback: hitung total barang + 1
            object? count = DBHelper.ExecuteScalar("SELECT COUNT(*) FROM Barang");
            int next = Convert.ToInt32(count) + 1;
            return $"BRG-{next:D3}";
        }

        /// <summary>
        /// Memuat daftar kategori dari database ke ComboBox
        /// </summary>
        private void LoadKategori()
        {
            DataTable dt = DBHelper.GetDataTable(
                "SELECT KategoriID, NamaKategori FROM Kategori ORDER BY NamaKategori");

            cmbKategori.DataSource    = dt;
            cmbKategori.DisplayMember = "NamaKategori";
            cmbKategori.ValueMember   = "KategoriID";
        }

        /// <summary>
        /// Memuat data barang yang sudah ada untuk ditampilkan di form Edit
        /// </summary>
        private void LoadBarangData()
        {
            DataTable dt = DBHelper.GetDataTable(
                "SELECT KodeBarang, NamaBarang, KategoriID, Stok, HargaSatuan, Satuan FROM Barang WHERE BarangID = @id",
                new SqlParameter("@id", SqlDbType.Int) { Value = _barangID });

            if (dt.Rows.Count == 0) return;

            DataRow row = dt.Rows[0];
            txtKodeBarang.Text         = row["KodeBarang"].ToString();
            txtNamaBarang.Text         = row["NamaBarang"].ToString();
            cmbKategori.SelectedValue  = Convert.ToInt32(row["KategoriID"]);
            txtStok.Text               = row["Stok"].ToString();
            txtHargaSatuan.Text        = Convert.ToDecimal(row["HargaSatuan"]).ToString("0.##");

            string satuan = row["Satuan"].ToString()!;
            int idx = cmbSatuan.Items.IndexOf(satuan);
            if (idx >= 0) cmbSatuan.SelectedIndex = idx;
        }

        // ============================================================
        // EVENT: KeyPress - Validasi input Stok (hanya angka)
        // e.Handled = true akan memblokir karakter yang tidak diizinkan
        // ============================================================
        private void txtStok_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Izinkan: digit (0-9) dan backspace saja
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        // ============================================================
        // EVENT: KeyPress - Validasi input Harga (angka + satu desimal)
        // ============================================================
        private void txtHargaSatuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Izinkan digit dan backspace
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)
                return;

            // Izinkan satu pemisah desimal (titik atau koma)
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                string current = ((MaterialTextBox2)sender).Text;
                if (!current.Contains('.') && !current.Contains(','))
                    return;
            }

            // Tolak semua karakter lainnya
            e.Handled = true;
        }

        // ============================================================
        // EVENT: Validating - Validasi Kode Barang tidak boleh kosong
        // Dipanggil saat fokus berpindah dari field ini
        // ============================================================
        private void txtKodeBarang_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKodeBarang.Text))
                errorProvider1.SetError(txtKodeBarang, "Kode Barang tidak boleh kosong!");
            else
                errorProvider1.SetError(txtKodeBarang, "");
        }

        // ============================================================
        // EVENT: Validating - Validasi Nama Barang tidak boleh kosong
        // ============================================================
        private void txtNamaBarang_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamaBarang.Text))
                errorProvider1.SetError(txtNamaBarang, "Nama Barang tidak boleh kosong!");
            else
                errorProvider1.SetError(txtNamaBarang, "");
        }

        // ============================================================
        // EVENT: Button Click - Simpan data barang ke database
        // INSERT jika mode Tambah, UPDATE jika mode Edit
        // ============================================================
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi semua field wajib
            if (string.IsNullOrWhiteSpace(txtKodeBarang.Text))
            {
                MessageBox.Show("Kode Barang harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKodeBarang.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtNamaBarang.Text))
            {
                MessageBox.Show("Nama Barang harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaBarang.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtStok.Text))
            {
                MessageBox.Show("Stok harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStok.Focus(); return;
            }
            if (string.IsNullOrWhiteSpace(txtHargaSatuan.Text))
            {
                MessageBox.Show("Harga Satuan harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHargaSatuan.Focus(); return;
            }

            // Siapkan parameter SQL (parameterized query = aman dari SQL Injection)
            string hargaStr = txtHargaSatuan.Text.Replace(",", ".");
            SqlParameter[] param =
            {
                new SqlParameter("@kode",   SqlDbType.NVarChar) { Value = txtKodeBarang.Text.Trim() },
                new SqlParameter("@nama",   SqlDbType.NVarChar) { Value = txtNamaBarang.Text.Trim() },
                new SqlParameter("@katId",  SqlDbType.Int)      { Value = GetSelectedKategoriID() },
                new SqlParameter("@stok",   SqlDbType.Int)      { Value = Convert.ToInt32(txtStok.Text) },
                new SqlParameter("@harga",  SqlDbType.Decimal)  { Value = decimal.Parse(hargaStr, CultureInfo.InvariantCulture) },
                new SqlParameter("@satuan", SqlDbType.NVarChar) { Value = cmbSatuan.SelectedItem!.ToString() }
            };

            if (_mode == "Tambah")
            {
                // INSERT data barang baru
                DBHelper.ExecuteNonQuery(
                    @"INSERT INTO Barang (KodeBarang, NamaBarang, KategoriID, Stok, HargaSatuan, Satuan)
                      VALUES (@kode, @nama, @katId, @stok, @harga, @satuan)", param);

                MessageBox.Show("Barang berhasil ditambahkan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // UPDATE data barang yang sudah ada
                var paramEdit = param.Append(
                    new SqlParameter("@id", SqlDbType.Int) { Value = _barangID }).ToArray();

                DBHelper.ExecuteNonQuery(
                    @"UPDATE Barang SET KodeBarang=@kode, NamaBarang=@nama,
                      KategoriID=@katId, Stok=@stok, HargaSatuan=@harga, Satuan=@satuan
                      WHERE BarangID=@id", paramEdit);

                MessageBox.Show("Barang berhasil diperbarui!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        // ============================================================
        // EVENT: Button Click - Batal, tutup form tanpa menyimpan
        // ============================================================
        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
