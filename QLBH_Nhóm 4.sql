﻿create database QLBH_Nhom4

use QLBH_Nhom4

create table KHACHHANG
(
MAKH INT IDENTITY(01,1) PRIMARY KEY,  
TENKH VARCHAR(40),
NGSINH SMALLDATETIME,
GIOITINH VARCHAR(5),
SDTKH VARCHAR(10),
DOANHSO INT
)

ALTER TABLE KHACHHANG ALTER COLUMN TENKH NVARCHAR(50)
ALTER TABLE KHACHHANG ALTER COLUMN GIOITINH NVARCHAR(10)

ALTER TABLE KHACHHANG ADD CONSTRAINT
CHK_GIOITINH CHECK(GIOITINH = 'Nam' OR GIOITINH = 'Nu')
ALTER TABLE KHACHHANG DROP CONSTRAINT CHK_GIOITINH 

CREATE TABLE SANPHAM
(
MASP INT IDENTITY(01,1) PRIMARY KEY,
TENSP VARCHAR(40),
GIA MONEY,
MALOAISP INT
)
ALTER TABLE SANPHAM ALTER COLUMN TENSP NVARCHAR(50)

ALTER TABLE SANPHAM ADD CONSTRAINT
FK_LOAISP_SP FOREIGN KEY (MALOAISP) REFERENCES LOAISP(MALOAISP)

CREATE TABLE LOAISP
(
MALOAISP INT IDENTITY(01,1) PRIMARY KEY,
TENLOAISP VARCHAR(40)
)
ALTER TABLE LOAISP ALTER COLUMN TENLOAISP NVARCHAR(50)
CREATE TABLE NHANVIEN
(
MANV INT IDENTITY(01,1) PRIMARY KEY,
TENNV VARCHAR(40),
SDTNV VARCHAR(10),
LUONG MONEY
)
ALTER TABLE NHANVIEN ALTER COLUMN TENNV NVARCHAR(50)
ALTER TABLE NHANVIEN ALTER COLUMN GIOITINH NVARCHAR(10)
CREATE TABLE HOADON
(
SOHD INT IDENTITY(01,1) PRIMARY KEY,
NGHD SMALLDATETIME,
TRIGA MONEY,
MAKH INT FOREIGN KEY REFERENCES KHACHHANG(MAKH),
MANV INT FOREIGN KEY REFERENCES NHANVIEN(MANV)
)

CREATE TABLE CTHD 
(
SOHD INT FOREIGN KEY REFERENCES HOADON(SOHD),
MASP INT FOREIGN KEY REFERENCES SANPHAM(MASP),
SOLUONG INT
)

ALTER TABLE SANPHAM ADD SOLUONGSP INT CHECK (SOLUONGSP >= 0)

CREATE TABLE ACCOUNT
(
MATK INT IDENTITY(01,1) PRIMARY KEY,
MANV INT FOREIGN KEY REFERENCES NHANVIEN(MANV),
EMAIL VARCHAR(40),
TAIKHOAN VARCHAR(50),
MATKHAU VARCHAR(50) 
)

ALTER TABLE ACCOUNT ALTER COLUMN TAIKHOAN VARCHAR(50)

CREATE TABLE KHUYENMAI
(
 MAKM INT IDENTITY(01,1) PRIMARY KEY,
 MAKH INT FOREIGN KEY REFERENCES KHACHHANG(MAKH),
 GIATRIKM INT CHECK (GIATRIKM IN (5,20,30)),
)
ALTER TABLE KHUYENMAI ADD SOHD INT CONSTRAINT FK_SOHD_KHUYENMAI FOREIGN KEY REFERENCES HOADON(SOHD) 

ALTER TABLE SANPHAM ADD NGAYTHEM SMALLDATETIME 
ALTER TABLE NHANVIEN ADD GIOITINH VARCHAR(10) CHECK (GIOITINH IN ('Nam','Nữ'))
ALTER TABLE NHANVIEN ADD NGSINH SMALLDATETIME CHECK ( YEAR(NGSINH) - YEAR(GETDATE()) >= 18 )
 
 INSERT NHANVIEN (TENNV,NGSINH,GIOITINH,SDTNV,LUONG) VALUES (N'thịnh vũ','6/2/2002',N'nam',123456,123456)
 INSERT NHANVIEN (TENNV,NGSINH,GIOITINH,SDTNV,LUONG) VALUES (N'thhf ','7/14/2021',N'Nam',3452,234)
 INSERT NHANVIEN (TENNV,NGSINH,GIOITINH,SDTNV,LUONG) VALUES (N'greg','12/6/2022',N'Nữ',45,45)

 CREATE PROCEDURE NhanVienSelect
 AS 
 SELECT * FROM NHANVIEN
 GO

 CREATE PROCEDURE KhachHangSelect
 AS
 SELECT * FROM KHACHHANG  
 GO

 CREATE PROCEDURE SanPhamSelect
 AS
 SELECT * FROM SANPHAM
 GO

 CREATE PROCEDURE CTHD_HOADON_Select
 @soHD INT
 AS
 SELECT TENSP,GIABAN,SOLUONG FROM CTHD CT,SANPHAM SP WHERE SOHD = @soHD AND CT.MASP = SP.MASP
 GO

 EXEC CTHD_HOADON_Select @soHD = 48

 select * from sanpham

DROP PROCEDURE CTHD_HOADON_Select

 CREATE PROCEDURE LoaiSanPhamSelect
 AS
 SELECT * FROM LOAISP
 GO

 CREATE PROCEDURE HoaDonSelect
 AS
 SELECT * FROM HOADON
 GO

 CREATE PROCEDURE TaiKhoanSelect
 AS
 SELECT * FROM ACCOUNT
 GO

 CREATE PROCEDURE KhuyenMaiSelect
 AS
 SELECT * FROM KHUYENMAI
 GO
 
 EXEC  KhuyenMaiSelect

 EXEC  HoaDonSelect

 EXEC LoaiSanPhamSelect

 EXEC NhanVienSelect

 EXEC KhachHangSelect

 EXEC SanPhamSelect

 EXEC TaiKhoanSelect

 EXEC CTHDSelect


alter table NHANVIEN DROP CONSTRAINT CK__NHANVIEN__NGSINH__36B12243

alter table NHANVIEN drop constraint CK__NHANVIEN__GIOITI__35BCFE0A

alter table NHANVIEN ADD FILEANH VARCHAR(50);

INSERT KHACHHANG VALUES (N'efgerg','12/16/2022',N'Nữ',123,234)
INSERT KHACHHANG VALUES (N'RETRET45','12/20/2022',N'Nam',345,345)
INSERT KHACHHANG VALUES (N'erf','12/20/2020',N'Nam',345,345)
ALTER TABLE KHACHHANG ADD FILEANH VARCHAR(50)
alter table NHANVIEN DROP COLUMN FILEANH

INSERT SANPHAM VALUES (N'trergregh',56,0,5,'12/13/2022')

alter table LOAISP add unique(TENLOAISP)

select MALOAISP from LOAISP WHERE TENLOAISP =N'Dụng cụ học tập'

select * from HOADON
select * from CTHD
from LOAISP LSP,SANPHAM SP
where LSP.MALOAISP = SP.MALOAISP

select * FROM HOADON
SELECT GIA FROM SANPHAM WHERE MASP = 4
select * from CTHD
SELECT GIA FROM SANPHAM WHERE MASP = 4

SELECT MAX(SOHD) AS SOHOADON FROM HOADON

SELECT * FROM HOADON HD,CTHD CT WHERE HD.SOHD = CT.SOHD

select * from ACCOUNT


ALTER TABLE ACCOUNT ADD UNIQUE(MANV,EMAIL,TAIKHOAN)


alter table ACCOUNT drop constraint UC_ACCOUNT

CREATE TABLE ACCOUNT
(
MATK INT IDENTITY(01,1) PRIMARY KEY,
MANV INT FOREIGN KEY REFERENCES NHANVIEN(MANV) UNIQUE,
EMAIL VARCHAR(40) UNIQUE,
TAIKHOAN VARCHAR(50) UNIQUE,
MATKHAU VARCHAR(50) 
)


CREATE PROC Login
@tk VARCHAR(50),
@mk VARCHAR(50)
AS 
BEGIN
SELECT TAIKHOAN,MATKHAU FROM ACCOUNT WHERE TAIKHOAN = @tk AND MATKHAU = @mk
END

EXEC Login @TK = N'thinh', @MK = N'123'

ALTER TABLE KHACHHANG ADD IMAGEKH VARCHAR(30)
ALTER TABLE SANPHAM ALTER COLUMN IMAGESP VARCHAR(500)
ALTER TABLE SANPHAM ADD IMAGESP VARCHAR(200)

select * from KHACHHANG

delete from KHACHHANG


UPDATE NHANVIEN SET TENNV = N'Vũ Viết Nữ', NGSINHNV = '5/12/2020', GIOITINHNV = N'Nữ',SDTNV = 987015333,LUONG =0,IMAGENV = N'C:/Users/admin/OneDrive/Desktop/QuanLyCuaHang/QuanLyCuaHangApp/quanlynhanvienWPF/bin/Debug/cda70d8020b42dcab9d75963f98fd606.jpg' WHERE MANV =45
delete from NHANVIEN where MANV = 45

ALTER TABLE KHACHHANG ALTER COLUMN DOANHSO MONEY
SELECT * FROM NHANVIEN
select * from khachhang
select * from sanpham
SELECT * FROM LOAISP
select * from hoadon
SELECT * FROM CTHD
ALTER TABLE KHACHHANG ALTER COLUMN IMAGEKH NVARCHAR(500)
DELETE FROM SANPHAM WHERE MASP = 31

SELECT * FROM KHACHHANG WHERE MANV LIKE '%3%'

SELECT * FROM SANPHAM,LOAISP WHERE SANPHAM.MALOAISP = LOAISP.MALOAISP AND LOAISP.TENLOAISP LIKE N'%DỤ%'
ALTER TABLE KHUYENMAI DROP CONSTRAINT FK_MAKH_KHACHHANG

SELECT HD.SOHD,TENSP,GIA,SOLUONG,GIATRIKM,HD.TRIGA FROM HOADON HD, CTHD CT,SANPHAM SP,KHUYENMAI KM 
WHERE HD.SOHD = CT.SOHD AND  CT.MASP = SP.MASP AND HD.SOHD = KM.SOHD
GO

SELECT SOHD,TENNV,TENKH,NGHD,TRIGA FROM HOADON HD,NHANVIEN NV,KHACHHANG KH WHERE HD.MAKH = KH.MAKH AND HD.MANV = NV.MANV 
SELECT TENSP,GIA,SOLUONG,GIATRIKM FROM CTHD CT, HOADON HD, KHUYENMAI KM,SANPHAM SP WHERE CT.SOHD = HD.SOHD AND CT.MASP = SP.MASP AND HD.SOHD = KM.SOHD

select * from SANPHAM
ALTER TABLE KHUYENMAI DROP COLUMN SOHD
ALTER TABLE KHUYENMAI DROP CONSTRAINT FK_SOHD_KHUYENMAI
ALTER TABLE KHUYENMAI ADD GIATRIDIEUKIEN MONEY

INSERT KHUYENMAI VALUES (20,200000)

ALTER TABLE SANPHAM ADD GIABAN MONEY
select * from khuyenmai
select * from sanpham
select * from HOADON
select * from cthd
SELECT HD.SOHD, TENSP, GIA, SOLUONG, GIATRIKM, HD.TRIGA FROM HOADON HD, CTHD CT, SANPHAM SP, KHUYENMAI KM WHERE HD.SOHD = CT.SOHD AND  CT.MASP = SP.MASP AND HD.MAKM = KM.MAKM
ALTER TABLE HOADON ADD TRIGIASAUKM MONEY 
ALTER TABLE HOADON ADD CONSTRAINT CT_TRIGIA_TRIGIASAUKM CHECK(TRIGIASAUKM <= TRIGA)

SELECT HD.SOHD, TENSP, GIA, SOLUONG, GIATRIKM, HD.TRIGA FROM HOADON HD, CTHD CT, SANPHAM SP, KHUYENMAI KM WHERE HD.SOHD = CT.SOHD AND  CT.MASP = SP.MASP AND HD.MAKM = KM.MAKM
SELECT SOHD,TENNV,TENKH,NGHD,TRIGA,GIATRIKM,TRIGIASAUKM FROM HOADON HD,NHANVIEN NV,KHACHHANG KH, KHUYENMAI KM WHERE HD.MAKH = KH.MAKH AND HD.MANV = NV.MANV AND HD.MAKM join KM.MAKM
SELECT SOHD FROM HOADON WHERE SOHD = (SELECT MAX(SOHD) FROM HOADON)

SELECT SOHD,TENNV,TENKH,NGHD,TRIGA,GIATRIKM,TRIGIASAUKM FROM HOADON AS HD INNER JOIN NHANVIEN AS NV ON HD.MANV = NV.MANV INNER JOIN KHACHHANG AS KH ON HD.MAKH = KH.MAKH LEFT JOIN KHUYENMAI AS KM ON HD.MAKM = KM.MAKM
delete from khuyenmai where makm >= 24

delete from cthd where sohd = 7
DELETE FROM HOADON WHERE SOHD = 30

ALTER TABLE KHACHHANG ALTER COLUMN IMAGEKH NVARCHAR(1000)


select * from sanpham

select MASP,count(masp)  from cthd  group by masp      -- lấy ra số lượng bán được của từng sản phẩm
SELECT * FROM CTHD
select masp,soluongsp from sanpham             -- lấy ra số lượng nhập hàng từng loại sản phẩm
alter table sanpham add default 0 for soluongsp

SELECT SANPHAM.MASP,TENSP,SOLUONG AS BANDUOC FROM SANPHAM JOIN CTHD ON SANPHAM.MASP = CTHD.MASP

SELECT CT.MASP,  SUM(SOLUONG) AS BANDUOC FROM CTHD CT RIGHT JOIN SANPHAM SP ON CT.MASP = SP.MASP GROUP BY CT.MASP

SELECT MASP,SUM(SOLUONG) as BANDUOC FROM CTHD GROUP BY MASP 

SELECT SUM(TRIGIASAUKM) FROM HOADON

SELECT MONTH(NGHD) AS THANGNAY,TRIGIASAUKM FROM HOADON WHERE MONTH(NGHD) = MONTH(GETDATE())
SELECT SUM(TRIGIASAUKM) FROM HOADON WHERE MONTH(NGHD) = MONTH(GETDATE())

select * from account
ALTER TABLE ACCOUNT DROP COLUMN EMAIL
ALTER TABLE ACCOUNT DROP CONSTRAINT UQ__ACCOUNT__161CF7245165187F

select MATK,ACC.MANV,TENNV,TAIKHOAN,MATKHAU FROM ACCOUNT ACC,NHANVIEN NV WHERE ACC.MANV = NV.MANV

SELECT SUM(TRIGIASAUKM),DAY(GETDATE()) - 1 FROM HOADON WHERE DAY(NGHD) = DAY(GETDATE()) 

SELECT MATK FROM ACCOUNT WHERE TAIKHOAN =" + taiKhoanTextbox.Text




CREATE PROC HOADON_CTHD_View
@maHD INT
AS 
BEGIN
SELECT CT.SOHD,SP.TENSP,CT.SOLUONG,SP.GIABAN FROM CTHD CT,SANPHAM SP WHERE SP.MASP = CT.MASP  AND CT.SOHD = @maHD
END

EXEC HOADON_CTHD_View @maHD = 48




SELECT CT.SOHD,SP.TENSP,CT.SOLUONG,SP.GIA FROM CTHD CT,SANPHAM SP WHERE CT.SOHD = 48 AND SP.MASP = CT.MASP