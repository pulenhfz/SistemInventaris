// ============================================================
// DBHelper.cs - Kelas pembantu untuk koneksi & operasi database
// Menggunakan ADO.NET dengan SQL Server
// ============================================================
using System.Data;
using System.Data.SqlClient;

namespace SistemInventaris
{
    /// <summary>
    /// Kelas statis yang menyediakan method-method pembantu
    /// untuk berinteraksi dengan database SQL Server.
    /// Semua method menggunakan 'using' agar koneksi otomatis ditutup.
    /// </summary>
    public static class DBHelper
    {
        // Connection string ke SQL Server lokal
        // Ganti "." dengan nama server Anda jika perlu (misal: .\SQLEXPRESS)
        private static readonly string connectionString =
            "Server=.;Database=InventarisDB;Integrated Security=True;TrustServerCertificate=True";

        /// <summary>
        /// Membuat dan mengembalikan objek SqlConnection baru.
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        /// <summary>
        /// Menjalankan query SELECT dan mengembalikan hasilnya sebagai DataTable.
        /// Cocok untuk menampilkan data di DataGridView.
        /// </summary>
        public static DataTable GetDataTable(string query, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil data:\n" + ex.Message,
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        /// <summary>
        /// Menjalankan query INSERT, UPDATE, atau DELETE.
        /// Mengembalikan jumlah baris yang terpengaruh.
        /// </summary>
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menjalankan perintah database:\n" + ex.Message,
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        /// <summary>
        /// Menjalankan query yang mengembalikan satu nilai saja.
        /// Contoh: SELECT COUNT(*), SELECT MAX(ID)
        /// </summary>
        public static object? ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null && parameters.Length > 0)
                        cmd.Parameters.AddRange(parameters);

                    conn.Open();
                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menjalankan query:\n" + ex.Message,
                    "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
