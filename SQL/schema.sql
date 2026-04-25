-- ============================================
-- SISTEM INVENTARIS BARANG - Database Schema
-- ============================================
-- DBMS: Microsoft SQL Server
-- ============================================

-- Membuat database baru
CREATE DATABASE InventarisDB;
GO

USE InventarisDB;
GO

-- ============================================
-- TABEL Users
-- Menyimpan data pengguna untuk login
-- ============================================
CREATE TABLE Users (
    UserID       INT           IDENTITY(1,1) PRIMARY KEY,
    Username     NVARCHAR(50)  NOT NULL UNIQUE,
    Password     NVARCHAR(100) NOT NULL,
    NamaLengkap  NVARCHAR(100) NULL,
    Role         NVARCHAR(20)  DEFAULT 'Admin'
);
GO

-- ============================================
-- TABEL Kategori
-- Mengelompokkan barang berdasarkan jenis
-- ============================================
CREATE TABLE Kategori (
    KategoriID   INT           IDENTITY(1,1) PRIMARY KEY,
    NamaKategori NVARCHAR(100) NOT NULL
);
GO

-- ============================================
-- TABEL Barang
-- Data utama barang inventaris
-- Berelasi ke tabel Kategori (FK)
-- ============================================
CREATE TABLE Barang (
    BarangID    INT            IDENTITY(1,1) PRIMARY KEY,
    KodeBarang  NVARCHAR(20)   NOT NULL UNIQUE,
    NamaBarang  NVARCHAR(150)  NOT NULL,
    Stok        INT            NOT NULL DEFAULT 0,
    HargaSatuan DECIMAL(18,2)  NOT NULL,
    Satuan      NVARCHAR(20)   NOT NULL,
    KategoriID  INT            NULL,

    CONSTRAINT FK_Barang_Kategori
        FOREIGN KEY (KategoriID) REFERENCES Kategori(KategoriID)
);
GO

-- ============================================
-- TABEL Transaksi
-- Mencatat barang masuk dan keluar
-- Berelasi ke tabel Barang (FK)
-- ============================================
CREATE TABLE Transaksi (
    TransaksiID      INT           IDENTITY(1,1) PRIMARY KEY,
    BarangID         INT           NOT NULL,
    JenisTransaksi   NVARCHAR(10)  NOT NULL,
    Jumlah           INT           NOT NULL,
    TanggalTransaksi DATETIME      DEFAULT GETDATE(),
    Keterangan       NVARCHAR(200) NULL,

    CONSTRAINT FK_Transaksi_Barang
        FOREIGN KEY (BarangID) REFERENCES Barang(BarangID),

    -- Validasi: hanya boleh 'Masuk' atau 'Keluar'
    CONSTRAINT CK_JenisTransaksi
        CHECK (JenisTransaksi IN ('Masuk', 'Keluar'))
);
GO

-- ============================================
-- DATA AWAL (Seed Data)
-- ============================================

-- Admin default: username=admin, password=admin123
INSERT INTO Users (Username, Password, NamaLengkap, Role)
VALUES ('admin', 'admin123', 'Administrator Sistem', 'Admin');
GO

-- 3 kategori barang
INSERT INTO Kategori (NamaKategori)
VALUES ('Elektronik'), ('ATK'), ('Furniture');
GO

-- 5 barang contoh
INSERT INTO Barang (KodeBarang, NamaBarang, Stok, HargaSatuan, Satuan, KategoriID)
VALUES
    ('BRG-001', 'Laptop ASUS VivoBook',  10, 8500000.00, 'Unit', 1),
    ('BRG-002', 'Printer Epson L3210',    5, 3200000.00, 'Unit', 1),
    ('BRG-003', 'Kertas HVS A4 70gsm', 100,   55000.00, 'Rim',  2),
    ('BRG-004', 'Pulpen Pilot G-2',     200,   15000.00, 'Pcs',  2),
    ('BRG-005', 'Meja Kantor 120x60',    15, 1250000.00, 'Unit', 3);
GO

-- 3 transaksi contoh
INSERT INTO Transaksi (BarangID, JenisTransaksi, Jumlah, TanggalTransaksi, Keterangan)
VALUES
    (1, 'Masuk',   5, '2025-01-15 08:30:00', 'Pengadaan laptop baru dari vendor'),
    (3, 'Keluar', 20, '2025-01-16 10:00:00', 'Distribusi kertas ke divisi HRD'),
    (5, 'Masuk',   3, '2025-01-17 14:15:00', 'Pembelian meja kantor tambahan');
GO
