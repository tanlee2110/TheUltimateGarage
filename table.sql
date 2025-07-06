
CREATE DATABASE QUANLIGARA
GO

USE QUANLIGARA
GO
--------------------------------------
--------------------------------------
-- TAO BANG, KHOA CHINH, KHOA NGOAI --
--------------------------------------

-- 1. XE
create table XE(
	BienSo varchar(10),
	TenChuXe nvarchar(50),
	HieuXe varchar(20),
	DiaChi nvarchar(50),
	DienThoai varchar(50),
	Email varchar(50),
	TienNo money,
	NgayTiepNhan smalldatetime,
	constraint PK_XE primary key(BienSo)
)

-- 2. HIEU XE
create table HIEUXE(
	HieuXe varchar(20)
	constraint PK_HIEUXE primary key(HieuXe)
)

-- 3. PHIEU SUA CHUA
create table PHIEUSUACHUA(
	MaPSC char(10),
	BienSo varchar(10),
	NgaySuaChua smalldatetime,
	TongTien money
	constraint PK_PHIEUSUACHUA primary key(MaPSC)
)

-- 4. CHI TIET PHIEU SUA CHUA
create table CT_PSC(
	
	MaPSC char(10),
	NoiDung nvarchar(200),
	MaVTPT char(10),
	TenVTPT nvarchar(50),
	SoLuong int,
	DonGia money,
	MaTienCong char(10),
	TienCong money,
	ThanhTien money,

)

-- 5. PHU TUNG
create table PHUTUNG(
	
	MaVTPT char(10),
	TenVTPT nvarchar(50),
	SoLuongTon int,
	DonGia money,
	constraint PK_PHUTUNG primary key(MaVTPT)
)

-- 6. TIEN CONG
create table TIENCONG(
	MaTienCong char(10),
	NoiDung nvarchar(200),
	TienCong money
	constraint PK_TIENCONG primary key(MaTienCong)
)

-- 7. QUY DINH 
create table QUYDINH(
	SoXeSuaChuaToiDa int,
	TiLeLai float
	constraint PK_QUYDINH primary key(SoXeSuaChuaToiDa)
)

-- 8. PHIEU THU TIEN
create table PHIEUTHUTIEN(
	MaPTT char(10),
	BienSo varchar(10),
	NgayThuTien smalldatetime,
	SoTienThu money
	constraint PK_PHIEUTHUTIEN primary key(MaPTT)
)





-- 13. PHIEU NHAP KHO VAT TU PHU CTUNG
create table PHIEUNHAPKHOVTPT(
	
	MaNKVTPT char(10),
	NgayNhap smalldatetime
	constraint PK_PHIEUNHAPKHOVTPT primary key(MaNKVTPT)
)

-- 14. CHI TIET PHIEU NHAP KHO VAT TU PHU TUNG
create table CT_PNKVTPT(
	MaNKVTPT char(10),
	MaVTPT char(10),
	TenVTPT nvarchar(50),
	SoLuong int,
	GiaNhap money
	
)

-- TAO KHOA NGOAI
-- 1. BANG XE
alter table XE add constraint FK_XE foreign key(HieuXe) references HIEUXE(HieuXe)

-- 2. BANG PHIEU SUA CHUA
alter table PHIEUSUACHUA add constraint FK_PHIEUSUACHUA foreign key(BienSo) references XE(BienSo)

-- 3. BANG CHI TIET PHIEU SUA CHUA
alter table CT_PSC add constraint FK1_CT_PSC foreign key(MaPSC) references PHIEUSUACHUA(MaPSC)
alter table CT_PSC add constraint FK2_CT_PSC foreign key(MaVTPT) references PHUTUNG(MaVTPT)
alter table CT_PSC add constraint FK3_CT_PSC foreign key(MaTienCong) references TIENCONG(MaTienCong)

-- 4. BANG PHIEU THU TIEN
alter table PHIEUTHUTIEN add constraint FK_PHIEUTHUTIEN foreign key(BienSo) references XE(BienSo)










USE QUANLIGARA
GO
CREATE TABLE NHANVIEN
(
	TenDangNhap nvarchar(20),
	MatKhau char(20),
	TenNV nvarchar(50),
	DienThoai varchar(50),
	Email varchar(50),
	DiaChi nvarchar(50),
	ChucVu nvarchar(50)
	constraint PK_NHANVIEN primary key(TenDangNhap)
)
GO
CREATE TABLE CHUCVU
(
	ChucVu nvarchar(50)
	constraint PK_CHUCVU primary key (ChucVu)
)
GO





ALTER TABLE CT_PNKVTPT
ADD CONSTRAINT FK1_CT_PNKVTPT foreign key (MaNKVTPT) references PHIEUNHAPKHOVTPT (MaNKVTPT)
GO
ALTER TABLE CT_PNKVTPT
add constraint FK2_CT_PNKVTPT foreign key(MaVTPT) references PHUTUNG(MaVTPT)
GO
ALTER TABLE NHANVIEN
add constraint FK_NHANVIEN foreign key(ChucVu) references CHUCVU(ChucVu)
GO
CREATE FUNCTION [dbo].[fuConvertToUnsign1] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END

GO

CREATE PROC DANGNHAP @username nvarchar(10), @password char(20)
AS
BEGIN
	SELECT TenDangNhap, MatKhau, ChucVu FROM NHANVIEN WHERE CAST(TenDangNhap AS varbinary(100)) = CAST(@username AS varbinary(100)) AND CAST(MatKhau AS varbinary(100)) = CAST(@password AS varbinary(100))
END
GO

create trigger tr_SoXeSuaChuaToiDaTrongNgay on XE for insert
as
	declare @SoXeToiDa int = (select SoXeSuaChuaToiDa from QUYDINH)
	if (select count(distinct BienSo) 
		from XE where Convert(date,NgayTiepNhan) = Convert(date, getdate())) > @SoXeToiDa
		Begin
			print N'Vượt quá số lượng xe sửa chữa tối đa trong ngày!'
			Rollback Tran
		End
go


CREATE PROC BAOCAOTON 
@thang int, @nam int
AS 
BEGIN
((SELECT MaVTPT, TenVTPT, SUM(SoLuong) AS PhatSinh, 0 AS SuDung FROM CT_PNKVTPT C, PHIEUNHAPKHOVTPT P  
WHERE P.MaNKVTPT = C.MaNKVTPT AND MONTH(P.NgayNhap) = @thang AND YEAR(P.NgayNhap) = @nam AND MaVTPT NOT IN 
(SELECT T1.MaVTPT FROM
(SELECT MaVTPT, TenVTPT, SUM(SoLuong) AS PhatSinh, 0 AS SuDung FROM CT_PNKVTPT C, PHIEUNHAPKHOVTPT P  
WHERE P.MaNKVTPT = C.MaNKVTPT AND MONTH(P.NgayNhap) = @thang AND YEAR(P.NgayNhap) = @nam
GROUP BY MaVTPT, TenVTPT)  T1
JOIN
(SELECT MaVTPT, TenVTPT, 0 AS PhatSinh, SUM(SoLuong) AS SuDung FROM CT_PSC C, PHIEUSUACHUA P  
WHERE P.MaPSC = C.MaPSC AND MONTH(P.NgaySuaChua) = @thang AND YEAR(P.NgaySuaChua) = @nam
GROUP BY MaVTPT, TenVTPT) T2
ON T1.MaVTPT = T2.MaVTPT)
GROUP BY MaVTPT, TenVTPT))
UNION
(SELECT MaVTPT, TenVTPT, 0 AS PhatSinh, SUM(SoLuong) AS SuDung FROM CT_PSC C, PHIEUSUACHUA P  
WHERE P.MaPSC = C.MaPSC AND MONTH(P.NgaySuaChua) = @thang AND YEAR(P.NgaySuaChua) = @nam AND MaVTPT
NOT IN (SELECT T1.MaVTPT FROM
(SELECT MaVTPT, TenVTPT, SUM(SoLuong) AS PhatSinh, 0 AS SuDung FROM CT_PNKVTPT C, PHIEUNHAPKHOVTPT P  
WHERE P.MaNKVTPT = C.MaNKVTPT AND MONTH(P.NgayNhap) = @thang AND YEAR(P.NgayNhap) = @nam
GROUP BY MaVTPT, TenVTPT)  T1
JOIN
(SELECT MaVTPT, TenVTPT, 0 AS PhatSinh, SUM(SoLuong) AS SuDung FROM CT_PSC C, PHIEUSUACHUA P  
WHERE P.MaPSC = C.MaPSC AND MONTH(P.NgaySuaChua) = @thang AND YEAR(P.NgaySuaChua) = @nam
GROUP BY MaVTPT, TenVTPT) T2
ON T1.MaVTPT = T2.MaVTPT)
GROUP BY MaVTPT, TenVTPT)



UNION

(SELECT T1.MaVTPT, T1.TenVTPT, T1.PHATSINH, T2.SUDUNG FROM
(SELECT MaVTPT, TenVTPT, SUM(SoLuong) AS PHATSINH, 0 AS SUDUNG FROM CT_PNKVTPT C, PHIEUNHAPKHOVTPT P  
WHERE P.MaNKVTPT = C.MaNKVTPT AND MONTH(P.NgayNhap) = @thang AND YEAR(P.NgayNhap) = @nam
GROUP BY MaVTPT, TenVTPT)  T1
JOIN
(SELECT MaVTPT, TenVTPT, 0 AS PHATSINH, SUM(SoLuong) AS SUDUNG FROM CT_PSC C, PHIEUSUACHUA P  
WHERE P.MaPSC = C.MaPSC AND MONTH(P.NgaySuaChua) = @thang AND YEAR(P.NgaySuaChua) = @nam
GROUP BY MaVTPT, TenVTPT) T2
ON T1.MaVTPT = T2.MaVTPT)
END

/*USE MASTER
GO
ALTER DATABASE QUANLIGARA
SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE QUANLIGARA
GO*/