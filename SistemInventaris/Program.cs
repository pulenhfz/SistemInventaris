// ================================================
// Program.cs - Titik masuk aplikasi (entry point)
// ================================================
using SistemInventaris.Forms;

namespace SistemInventaris
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Inisialisasi konfigurasi aplikasi (visual styles, font default, dll)
            ApplicationConfiguration.Initialize();

            // Jalankan FormLogin sebagai form pertama
            Application.Run(new FormLogin());
        }
    }
}
