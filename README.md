# 📦 Sistem Inventaris Barang (SiInventaris)

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![WinForms](https://img.shields.io/badge/WinForms-.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)
![MaterialSkin.2](https://img.shields.io/badge/MaterialSkin.2-Modern_UI-7575?style=for-the-badge)

---

## 📋 Deskripsi Aplikasi

| Item | Detail |
|---|---|
| **Jenis Aplikasi** | Instansi — Manajemen Gudang / Inventaris |
| **Nama Aplikasi** | SiInventaris |
| **Tujuan** | Mengelola data barang, kategori, dan transaksi keluar masuk barang secara terkomputerisasi |
| **Target Pengguna** | Admin gudang / staf inventaris |

SiInventaris adalah aplikasi desktop berbasis **Windows Forms** yang dirancang untuk mempermudah pengelolaan inventaris barang di lingkungan instansi, kantor, atau gudang.

---

## ✨ Fitur Utama

1. **Login & Autentikasi Pengguna** — Sistem login dengan validasi username & password
2. **Manajemen Data Barang (CRUD)** — Tambah, lihat, edit, dan hapus data barang via DataGridView
3. **Pencatatan Transaksi Barang Masuk / Keluar** — Catat pergerakan stok barang
4. **Pencarian & Filter Data** — Cari barang berdasarkan nama/kode, filter per kategori

---

## 🔄 Alur Penggunaan

```mermaid
flowchart TD
    A([Login]) --> B[Dashboard]
    B --> C{Pilih Aksi}
    C --> D[Tambah / Edit / Hapus Barang]
    C --> E[Catat Transaksi]
    C --> F[Cari / Filter Data]
    D & E & F --> G([Logout])
```

---

## 🛠️ Teknologi

| Teknologi | Keterangan |
|---|---|
| C# WinForms (.NET 8) | Framework utama antarmuka desktop |
| MaterialSkin.2 | Library UI Material Design untuk WinForms |
| SQL Server | Database relasional |
| ADO.NET | Akses data ke SQL Server |

---

## 🚀 Cara Setup

1. Jalankan `SQL/schema.sql` di SSMS untuk membuat database `InventarisDB`
2. Buka `SistemInventaris/SistemInventaris.csproj` di Visual Studio 2022
3. Restore NuGet packages (MaterialSkin.2 + System.Data.SqlClient)
4. Sesuaikan connection string di `DBHelper.cs` jika perlu
5. Tekan F5 untuk menjalankan
6. Login: **admin** / **admin123**

---

## 🗄️ Struktur Database

```mermaid
erDiagram
    Users {
        int UserID PK
        string Username
        string Password
        string NamaLengkap
        string Role
    }

    Kategori {
        int KategoriID PK
        string NamaKategori
    }

    Barang {
        int BarangID PK
        string KodeBarang
        string NamaBarang
        int Stok
        decimal HargaSatuan
        string Satuan
        int KategoriID FK
    }

    Transaksi {
        int TransaksiID PK
        int BarangID FK
        string JenisTransaksi
        int Jumlah
        datetime TanggalTransaksi
        string Keterangan
    }

    Kategori ||--o{ Barang : "memiliki"
    Barang ||--o{ Transaksi : "dicatat dalam"
```
