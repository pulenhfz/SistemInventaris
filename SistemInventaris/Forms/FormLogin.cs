// ============================================================
// FormLogin.cs - Form untuk proses login pengguna
// Memvalidasi username & password terhadap tabel Users
// ============================================================
using System.Data;
using System.Data.SqlClient;
using MaterialSkin;
using MaterialSkin.Controls;

namespace SistemInventaris.Forms
{
    public partial class FormLogin : MaterialForm
    {
        public FormLogin()
        {
            InitializeComponent();

            // Inisialisasi MaterialSkinManager - atur tema & warna aplikasi
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            // Skema warna Indigo - terlihat profesional
            skinManager.ColorScheme = new ColorScheme(
                Primary.Indigo500,
                Primary.Indigo700,
                Primary.Indigo100,
                Accent.Pink200,
                TextShade.WHITE
            );
        }

        // ============================================================
        // EVENT: Button Click - Proses login
        // Mengecek username & password ke database tabel Users
        // ============================================================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Validasi field tidak boleh kosong
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Username tidak boleh kosong!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password tidak boleh kosong!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Hash password sebelum dibandingkan dengan database
            // Password disimpan sebagai SHA256 hash di tabel Users
            string hashedPassword = DBHelper.HashPassword(txtPassword.Text);

            // Query dengan parameter untuk mencegah SQL Injection
            string query = "SELECT UserID, NamaLengkap, Role FROM Users WHERE Username=@u AND Password=@p";
            SqlParameter[] param =
            {
                new SqlParameter("@u", txtUsername.Text.Trim()),
                new SqlParameter("@p", hashedPassword)
            };

            DataTable dt = DBHelper.GetDataTable(query, param);

            if (dt.Rows.Count > 0)
            {
                // Login berhasil - ambil data pengguna
                string namaLengkap = dt.Rows[0]["NamaLengkap"].ToString()!;
                string role = dt.Rows[0]["Role"].ToString()!;

                MessageBox.Show($"Selamat datang, {namaLengkap}!\nRole: {role}",
                    "Login Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Buka FormUtama, tutup FormLogin saat FormUtama ditutup
                FormUtama formUtama = new FormUtama(namaLengkap, role);
                formUtama.FormClosed += (s, args) => this.Close();
                formUtama.Show();
                this.Hide();
            }
            else
            {
                // Login gagal
                MessageBox.Show("Username atau Password salah!\nSilakan coba lagi.",
                    "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }

        // ============================================================
        // EVENT: KeyPress - Validasi input username
        // Hanya huruf, angka, dan backspace yang diizinkan
        // ============================================================
        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tolak karakter yang tidak diizinkan
            }
        }

        // ============================================================
        // EVENT: KeyDown - Tekan Enter di password = trigger login
        // Mempermudah pengguna tanpa harus klik tombol
        // ============================================================
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnLogin.PerformClick();
            }
        }

        // ============================================================
        // EVENT: Button Click - Konfirmasi keluar dari aplikasi
        // ============================================================
        private void btnKeluar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Apakah Anda yakin ingin keluar dari aplikasi?",
                "Konfirmasi Keluar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                Application.Exit();
        }
    }
}
