Use master;
go
    drop database cnpmnc;
	go
    create database cnpmnc;
go
Use cnpmnc
Go
Create Table KhuVuc
(
  IDKV Int primary key,
  ThanhPho NVARCHAR(50),
)
Create Table ChiNhanh
(
  IDCN Int primary key,
  Diachi  NVARCHAR(50),
  SDT VARCHAR(50),
  IDKV int,
  Foreign key(IDKV) References  KhuVuc(IDKV)
)
Go
-- Tạo bảng Users
CREATE TABLE TaiKhoan (
  IDTK Int primary key,
  TenDN VARCHAR(50),
  MatKhau VARCHAR(50),
  TenTK NVARCHAR(50),
  SDT VARCHAR(11),
  ChucVu Int,
);
-- Tạo bảng Categories
CREATE TABLE Loai (
  IdLoai INT PRIMARY KEY,
  TenLoai NVARCHAR(50)
);
Go
Create Table NguyenLieu
(
	IdNL Int Primary key,
	TenNL Nvarchar(25),
	SoLuong Int,
	DonGia Decimal (9,3),
)
Go
-- Tạo bảng Products
CREATE TABLE MonAn(
  IdMA INT PRIMARY KEY,
  TenMA NVARCHAR(100),
  Mota NVARCHAR(200),
  DonGia DECIMAL(9, 3),
  HinhAnh VARCHAR(200),
  IdLoai INT,
  IdNL INT,
  FOREIGN KEY (IdLoai) REFERENCES Loai(IdLoai),
  FOREIGN KEY (IdNL) REFERENCES NguyenLieu(IdNL)
);
Go
-- Tạo bảng Orders
CREATE TABLE DatHang (
  MaDat INT PRIMARY KEY,
  IdTK INT,
  NgayDat DATE,
  TrangThai VARCHAR(50),
  FOREIGN KEY (IdTK) REFERENCES TaiKhoan(IdTK)
);
Go
-- Tạo bảng Order_Items
CREATE TABLE CTDonHang (
  MaDat INT ,
  IdMA INT,
  SoLuong INT,
  TongTien Decimal (9,3)
  FOREIGN KEY (MaDat) REFERENCES DatHang(MaDat),
  FOREIGN KEY (IdMA) REFERENCES MonAn(IdMA),
  CONSTRAINT PK_CTDonHang PRIMARY KEY (MaDat, IdMA)
);
Go
-- Chèn dữ liệu vào bảng TaiKhoan
INSERT INTO TaiKhoan (IDTK, TenDN, MatKhau, TenTK, SDT, ChucVu)
VALUES
  (1, 'nguyenanh', '123456', N'Nguyen Anh', '123456789', 1),
  (2, 'quanghung', '654321', N'Quang Hung', '987654321', 2),
  (3, 'bachyen', 'bachyen123', N'Bach Yen', '096421456', 3);

  Go
-- Chèn dữ liệu vào bảng Loai
INSERT INTO Loai (IdLoai, TenLoai)
VALUES
  (1, N'Đồ ăn'),
  (2, N'Đồ uống');
  Go
-- Chèn dữ liệu vào bảng NguyenLieu
INSERT INTO NguyenLieu (IdNL, TenNL, SoLuong, DonGia)
VALUES
  (1, N'Đùi Gà', 100, 15),
  (2, N'CocaCola', 50, 10),
  (3, N'Trứng', 50, 3),
  (4, N'Bò', 50, 20),
  (5, N'Ức gà', 50, 15),
  (6, N'Khoai tây', 50, 5),
  (7, N'Sting dâu', 50, 10);

  Go
-- Chèn dữ liệu vào bảng MonAn
INSERT INTO MonAn (IdMA, TenMA, Mota, DonGia, HinhAnh, IdLoai, IdNL)
VALUES
  (1, N'Đùi gà rán', N'Đùi gà rán KFC truyền thống', 25, 'garan.jpg', 1, 1),
  (2, N'Cocacola', N'Coca cola lon 100ml', 20, 'cocacola.jpg', 2, 2),
  (3, N'Ức gà', N'Ức gà rán KFC truyền thống', 25, 'ucga.jpg', 1, 5),
  (4, N'Hamburger gà', N'Hamburger với thịt gà kfc', 30, 'hambugarga.png', 1, 5),
  (5, N'Hamburger bò', N'Hamburger với thịt bò phô mai', 30, 'hamburgerbo.jpg', 1, 4),
  (6, N'Bánh trứng', N'Bánh trứng tặng kèm giờ có thể mua riêng', 5, 'banhtrung.jpg', 1, 1),
  (7, N'Sting dâu', N'Sting hương dâu 250ml', 25, 'sting.jpg', 2, 7),
  (8, N'Khoai tây chiên', N'Khoai tây chiên cỡ vừa', 20, 'khoaitaychien.jpg', 1, 6);

  Go
-- Chèn dữ liệu vào bảng DatHang
INSERT INTO DatHang (MaDat, IdTK, NgayDat, TrangThai)
VALUES
  (1, 1, '2023-09-29', N'Đang chuẩn bị'),
  (2, 2, '2023-09-28', N'Đã giao hàng');
  Go
-- Chèn dữ liệu vào bảng CTDonHang
INSERT INTO CTDonHang (MaDat, IdMA, SoLuong, TongTien)
VALUES
  (1, 1, 2, 11.98),
  (1, 2, 1, 9.99),
  (2, 2, 3, 29.97);
 
 -- Chèn dữ liệu vào bảng KhuVuc
   INSERT INTO  KhuVuc(IDKV,ThanhPho)
VALUES (1, N'TP.HCM'),
 (2, N'Hà Nội'),
 (3, N'Đà Lạt'),
 (4, N'Quy Nhơn'),
 (5, N'Huế');
-- Chèn dữ liệu vào bảng Chi nhanh
  INSERT INTO ChiNhanh (IDCN, Diachi, SDT, IDKV)
VALUES (1, N'Địa chỉ 1', '0123456789', 1),
       (2, N'Địa chỉ 2', '0987654321',1),
       (3, N'Địa chỉ 3', '0123456789', 2),
       (4, N'Địa chỉ 4', '0987654321', 2),
       (5, N'Địa chỉ 5', '0123456789', 3),
       (6, N'Địa chỉ 6', '0987654321', 3),
       (7, N'Địa chỉ 7', '0123456789',4),
       (8, N'Địa chỉ 8', '0987654321', 4),
       (9, N'Địa chỉ 9', '0123456789', 5),
       (10, N'Địa chỉ 10', '0987654321',5 );

  -------------------------------------------------------------------------------------------
    ------------------------------Loai-------------------
Go 
 Create Proc PR_Loai
 AS
 Begin
	Select * From Loai
End
Go 
 Create Proc PR_XuatTenLoai @idloai int
 AS
 Begin
	Select TenLoai  From Loai Where IdLoai = @idloai
End
Go 
 Create Proc PR_XoaLoai @IDNL int
 AS
 Begin
	Delete From Loai Where IdLoai = @IDNL
End
Go
 Create Proc PR_ThemLoai
 @TenLoai nvarchar(25)
 As
 Begin
	Declare @IdNL int;
	Select @IdNL = Max(IdLoai)
	From Loai
	Set @IdNL = @IdNL + 1;
	INSERT INTO Loai (IdLoai, TenLoai)
VALUES
  (@IdNL, @TenLoai);
End
Go
 Create Proc PR_SuaLoai
 @TenNL Nvarchar(25),
 @IdNl int
 AS
 Begin
	Update Loai
	Set 
	TenLoai= @TenNL 
	Where IdLoai = @IdNl
End
Go
Create Proc Pr_ChiTietLoai @IDNL int
As
Begin	
	Select * from Loai Where IdLoai = @IDNL
END


  ------------------------------MonAn-------------------
 Go 
 Create Proc PR_Menu
 AS
 Begin
	Select * From MonAn
End
 Go 
  Create Proc PR_TimTheoTen @Ten nvarchar(25)
 AS
 Begin
	Select * From MonAn Where TenMA = @Ten
End
Go  
 Create Proc PR_TimTheoLoai @IdLoai int
 AS
 Begin
	Select * From MonAn Where IdLoai = @IdLoai
End
Go  
Go  
 Create Proc PR_ChiTietMA @IdMA int
 AS
 Begin
	Select * From MonAn Where  IdMA = @IdMA
End
Go 
 Create Proc PR_XoaMonAn @IDNL int
 AS
 Begin
	Delete From MonAn Where IdMA = @IDNL
End
Go
 Create Proc PR_ThemMonAn
 @TenMA nvarchar(25),
 @Mota nvarchar(50),
 @DonGia Decimal(9,3),
 @HinhAnh varchar(200),
 @IdLoai int,
 @IdNL int
 AS
 Begin
	Declare @IdMA int;
	Select @IdMA = Max(IdMA)
	From MonAn
	Set @IdMA = @IdMA + 1;
	INSERT INTO MonAn (IdMA, TenMA, Mota, DonGia, HinhAnh, IdLoai, IdNL)
VALUES
  (@IdMA,@TenMA,@Mota, @DonGia, @HinhAnh, @IdLoai, @IdNL);
End
Go
 Create Proc PR_SuaMonAn
 @TenMA nvarchar(25),
 @Mota nvarchar(50),
 @DonGia Decimal(9,3),
 @HinhAnh varchar(200),
 @IdLoai int,
 @IdNL int,
 @IdMA int
 AS
 Begin
	Update MonAn
	Set TenMA = @TenMA,
	MoTa = @Mota,
	DonGia = @DonGia,
	HinhAnh = @HinhAnh,
	IdLoai = @IdLoai,
	IdNL = @IdNL
	Where IdMA = @IdMA
End

-------------- NguyenLieu------------------
Go 
 Create Proc PR_NguyenLieu
 AS
 Begin
	Select * From NguyenLieu
End
Go 
 Create Proc PR_XoaNguyenLieu @IDNL int
 AS
 Begin
	Delete From NguyenLieu Where IdNL = @IDNL
End
Go
 Create Proc PR_ThemNguyenLieu 
 @TenNL nvarchar(25),
 @SoLuong int,
 @DonGia Decimal(9,3)
 AS
 Begin
	Declare @IdNL int;
	Select @IdNL = Max(IdNL)
	From NguyenLieu
	Set @IdNL = @IdNL + 1;
	INSERT INTO NguyenLieu (IdNL, TenNL, SoLuong, DonGia)
VALUES
  (@IdNL, @TenNL, @SoLuong, @DonGia);
End
Go
 Create Proc PR_SuaNguyenLieu
 @TenNL Nvarchar(25),
 @SoLuong varchar(25),
 @DonGia Decimal(9,3),
 @IdNl int
 AS
 Begin
	Update NguyenLieu
	Set 
	TenNL = @TenNL, 
	SoLuong = @SoLuong, 
	DonGia =@DonGia
	Where IDNL = @IdNl
End
Go
Create Proc Pr_ChiTietNguyenLieu @IDNL int
As
Begin	
	Select * from NguyenLieu Where IDNL = @IDNL
END
---------------TaiKhoan---------------------
Go
 Create Proc PR_TaiKhoan
 AS
 Begin
	Select * From TaiKhoan
End
Go
 Create Proc PR_TaiKhoan_Sort @loaitk int
 AS
 Begin
	Select * From TaiKhoan Where ChucVu = @loaitk
End
Go
 Create Proc PR_TaiKhoan_NhanVien
 AS
 Begin
	Select * From TaiKhoan Where ChucVu = 2
End
Go
 Create Proc PR_TaiKhoan_KhachHang
 AS
 Begin
	Select * From TaiKhoan Where ChucVu = 3
End
Go
 Create Proc PR_ThemTaiKhoan
 @TenDN Nvarchar(25),
 @MatKhau varchar(25),
 @TenTaiKhoan Nvarchar(25),
 @SDT varchar(25),
 @LoaiTK int
 AS
 Begin
	Declare @IdTK int;
	Select @IdTK = Max(IDTK)
	From TaiKhoan
	Set @IdTK = @IdTK + 1;
	INSERT INTO TaiKhoan (IDTK, TenDN, MatKhau, TenTK, SDT, ChucVu)
VALUES
  (@IdTK, @TenDN, @MatKhau, @TenTaiKhoan, @SDT, @LoaiTK);
End
Go
 Create Proc PR_SuaTaiKhoan
 @TenDN Nvarchar(25),
 @MatKhau varchar(25),
 @TenTaiKhoan Nvarchar(25),
 @SDT varchar(25),
 @IdTK int
 AS
 Begin
	Update TaiKhoan
	Set 
	TenDN = @TenDN, 
	MatKhau = @MatKhau, 
	TenTK =@TenTaiKhoan, 
	SDT = @SDT
	Where IDTK = @IdTK
End
Go 
 Create Proc PR_XoaTaiKhoan @IDNL int
 AS
 Begin
	Delete From TaiKhoan Where IDTK = @IDNL
End
Go
Create Proc PR_ChiTietTK @IdTK int
As
Begin
	Select * From TaiKhoan Where IDTK = @IdTK
End
-----------------------------------------------
Go
Create Proc PR_ChiNhanh
AS
Begin
	Select * From ChiNhanh
End
Go
Create Proc PR_ChiNhanhCT @id int
AS
Begin
	Select * From ChiNhanh Where IDCN = @id
End
Go
 Create Proc PR_ThemChiNhanh
 @DiaChi nvarchar(50),
 @SDT varchar(25),
 @IDKV int
 AS
 Begin
	Declare @IdTK int;
	Select @IdTK = Max(IdCN)
	From ChiNhanh
	Set @IdTK = @IdTK + 1;
	INSERT INTO ChiNhanh (IDCN, DiaChi, SDT, IDKV)
VALUES
  (@IdTK, @DiaChi, @SDT, @IDKV);
End
Go
 Create Proc PR_SuaChiNhanh
 @DiaChi nvarchar(50),
 @SDT varchar(25),
 @IdKV Int,
 @IdTK int
 AS
 Begin
	Update ChiNhanh
	Set 
	Diachi = @DiaChi, 
	SDT = @SDT, 
	IdKV = @IdKV
	Where IDCN = @IdTK
End
Go 
 Create Proc PR_XoaChiNhanh @IDNL int
 AS
 Begin
	Delete From ChiNhanh Where IDCN= @IDNL
End
Go
------------------------------------
Create Proc PR_KhuVuc
As
Begin
	Select * from KhuVuc 
End
Go
Create Proc PR_CTKhuVuc @idkv int
As
Begin
	Select * from KhuVuc where IDKV = @idkv
End