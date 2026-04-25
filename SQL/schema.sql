-- ============================================
-- SISTEM INVENTARIS BARANG - Database Schema
-- ============================================
-- DBMS  : Microsoft SQL Server
-- Jalankan file ini di SSMS atau sqlcmd
-- ============================================

-- Buat database jika belum ada
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'InventarisDB')
    CREATE DATABASE InventarisDB;
GO

USE InventarisDB;
GO

-- ============================================
-- TABEL Users
-- ============================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Users' AND xtype='U')
CREATE TABLE Users (
    UserID      INT           IDENTITY(1,1) PRIMARY KEY,
    Username    NVARCHAR(50)  NOT NULL UNIQUE,
    Password    NVARCHAR(100) NOT NULL,   -- SHA256 hex (64 char)
    NamaLengkap NVARCHAR(100) NULL,
    Role        NVARCHAR(20)  NOT NULL DEFAULT 'User'
);
GO

-- ============================================
-- TABEL Kategori
-- ============================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Kategori' AND xtype='U')
CREATE TABLE Kategori (
    KategoriID   INT           IDENTITY(1,1) PRIMARY KEY,
    NamaKategori NVARCHAR(100) NOT NULL
);
GO

-- ============================================
-- TABEL Barang
-- ============================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Barang' AND xtype='U')
CREATE TABLE Barang (
    BarangID    INT           IDENTITY(1,1) PRIMARY KEY,
    KodeBarang  NVARCHAR(20)  NOT NULL UNIQUE,
    NamaBarang  NVARCHAR(150) NOT NULL,
    Stok        INT           NOT NULL DEFAULT 0,
    HargaSatuan DECIMAL(18,2) NOT NULL,
    Satuan      NVARCHAR(20)  NOT NULL,
    KategoriID  INT           NULL,

    CONSTRAINT FK_Barang_Kategori
        FOREIGN KEY (KategoriID) REFERENCES Kategori(KategoriID)
);
GO

-- ============================================
-- TABEL Transaksi
-- ============================================
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Transaksi' AND xtype='U')
CREATE TABLE Transaksi (
    TransaksiID      INT           IDENTITY(1,1) PRIMARY KEY,
    BarangID         INT           NOT NULL,
    JenisTransaksi   NVARCHAR(10)  NOT NULL,
    Jumlah           INT           NOT NULL,
    TanggalTransaksi DATETIME      DEFAULT GETDATE(),
    Keterangan       NVARCHAR(200) NULL,

    CONSTRAINT FK_Transaksi_Barang
        FOREIGN KEY (BarangID) REFERENCES Barang(BarangID),

    CONSTRAINT CK_JenisTransaksi
        CHECK (JenisTransaksi IN ('Masuk', 'Keluar'))
);
GO

-- ============================================
-- SEED DATA - Users
-- Password disimpan sebagai SHA256 hash
--   admin  -> password: admin123
--   viewer -> password: user123
-- ============================================
IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'admin')
    INSERT INTO Users (Username, Password, NamaLengkap, Role)
    VALUES (
        'admin',
        LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'admin123'), 2)),
        'Administrator Sistem',
        'Admin'
    );
GO

IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'viewer')
    INSERT INTO Users (Username, Password, NamaLengkap, Role)
    VALUES (
        'viewer',
        LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'user123'), 2)),
        'User Viewer',
        'User'
    );
GO

-- ============================================
-- SEED DATA - Kategori
-- ============================================
IF NOT EXISTS (SELECT 1 FROM Kategori)
BEGIN
    INSERT INTO Kategori (NamaKategori)
    VALUES ('Elektronik'), ('ATK'), ('Furniture');
END
GO

-- ============================================
-- SEED DATA - Barang
-- ============================================
IF NOT EXISTS (SELECT 1 FROM Barang)
BEGIN
    INSERT INTO Barang (KodeBarang, NamaBarang, Stok, HargaSatuan, Satuan, KategoriID)
    VALUES
        ('BRG-001', 'Laptop ASUS VivoBook',  10, 8500000.00, 'Unit', 1),
        ('BRG-002', 'Printer Epson L3210',    5, 3200000.00, 'Unit', 1),
        ('BRG-003', 'Kertas HVS A4 70gsm', 100,   55000.00, 'Rim',  2),
        ('BRG-004', 'Pulpen Pilot G-2',     200,   15000.00, 'Pcs',  2),
        ('BRG-005', 'Meja Kantor 120x60',    15, 1250000.00, 'Unit', 3);
END
GO

-- ============================================
-- SEED DATA - Transaksi
-- ============================================
IF NOT EXISTS (SELECT 1 FROM Transaksi)
BEGIN
    INSERT INTO Transaksi (BarangID, JenisTransaksi, Jumlah, TanggalTransaksi, Keterangan)
    VALUES
        (1, 'Masuk',   5, '2025-01-15 08:30:00', 'Pengadaan laptop baru dari vendor'),
        (3, 'Keluar', 20, '2025-01-16 10:00:00', 'Distribusi kertas ke divisi HRD'),
        (5, 'Masuk',   3, '2025-01-17 14:15:00', 'Pembelian meja kantor tambahan');
END
GO

-- ============================================
-- MIGRASI: Hash password lama yang masih plaintext
-- Jalankan ini jika database sudah ada sebelumnya
-- dan password belum di-hash (panjang bukan 64 char)
-- ============================================
UPDATE Users
SET Password = LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', Password), 2))
WHERE LEN(Password) <> 64;
GO

-- ============================================
-- VERIFIKASI
-- ============================================
SELECT UserID, Username, LEFT(Password, 16) + '...' AS PasswordHash, NamaLengkap, Role
FROM Users;

SELECT * FROM Kategori;
SELECT * FROM Barang;
GO
