USE MASTER
GO
IF EXISTS ( SELECT * FROM SYS.DATABASES WHERE NAME = 'QLSanPham')
    DROP DATABASE QLSanPham
GO

CREATE DATABASE QLSanPham
GO

USE QLSanPham
GO
IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE NAME = 'LoaiSP')
    DROP TABLE LoaiSP
GO
CREATE TABLE LoaiSP
(
    MaLoai char(2) not null primary key,
    TenLoai nvarchar(30)
)

IF EXISTS (SELECT * FROM SYS.OBJECTS WHERE NAME = 'SanPham')
    DROP TABLE SanPham
GO
CREATE TABLE SanPham
(
    MaSP varchar(6) not null primary key,
    TenSP nvarchar(30),
    NgayNhap datetime,
    MaLoai char(2)
)

ALTER TABLE SanPham
    ADD CONSTRAINT FK_SanPham_LoaiSP FOREIGN KEY(MaLoai) REFERENCES LoaiSP(MaLoai)

SET DATEFORMAT DMY

INSERT INTO LoaiSP(MaLoai,TenLoai) VALUES('L1','Banh Keo')
INSERT INTO LoaiSP(MaLoai,TenLoai) VALUES('L2','Giai Khat')

INSERT INTO SanPham(MaSP,TenSP,NgayNhap,MaLoai) VALUES('SP1','Banh Quy Bo Sua','6/11/2077','L1')
INSERT INTO SanPham(MaSP,TenSP,NgayNhap,MaLoai) VALUES('SP2','Banh Chocopie','12/2/2077','L1')
INSERT INTO SanPham(MaSP,TenSP,NgayNhap,MaLoai) VALUES('SP3','Cola','5/7/2069','L2')
INSERT INTO SanPham(MaSP,TenSP,NgayNhap,MaLoai) VALUES('SP4','Pepsi','9/11/2069','L2')

select * from LoaiSP
select * from SanPham