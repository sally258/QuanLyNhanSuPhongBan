USE [master]
GO
/****** Object:  Database [QuanLyNhanSuPhongBan]    Script Date: 1/6/2022 3:30:34 PM ******/
CREATE DATABASE [QuanLyNhanSuPhongBan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyNhanSuPhongBan', FILENAME = N'D:\App\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\QuanLyNhanSuPhongBan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyNhanSuPhongBan_log', FILENAME = N'D:\App\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\QuanLyNhanSuPhongBan_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyNhanSuPhongBan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET QUERY_STORE = OFF
GO
USE [QuanLyNhanSuPhongBan]
GO
/****** Object:  Table [dbo].[ChucVu]    Script Date: 1/6/2022 3:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChucVu](
	[MaChucVu] [nvarchar](10) NOT NULL,
	[TenChucVu] [nvarchar](50) NOT NULL,
	[SoNhanVien] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaChucVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 1/6/2022 3:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](100) NOT NULL,
	[NgaySinh] [datetime] NULL,
	[DiaChi] [nvarchar](255) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[Email] [nvarchar](50) NULL,
	[CMND] [nvarchar](15) NULL,
	[HocVan] [nvarchar](50) NULL,
	[TinhTrangHonNhan] [nvarchar](20) NULL,
	[MaPhong] [nvarchar](10) NULL,
	[TruongPhong] [int] NULL,
	[NgayVaoLam] [datetime] NULL,
	[Luong] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien_ChucVu]    Script Date: 1/6/2022 3:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien_ChucVu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaNhanVien] [nvarchar](10) NULL,
	[MaChucVu] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongBan]    Script Date: 1/6/2022 3:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongBan](
	[MaPhong] [nvarchar](10) NOT NULL,
	[TenPhong] [nvarchar](100) NOT NULL,
	[SoNhanVien] [int] NULL,
	[ViTri] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaPhong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'CT', N'Chủ tịch', 2)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'GD01', N'Giám đốc điều hành', 2)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'GD02', N'Giám đốc tài chính', 1)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'GD03', N'Giám đốc Marketing', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'GD04', N'Giám đốc thương mại', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'GD05', N'Giám đốc vận hành', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'NV01', N'Nhân viên văn phòng', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'NV02', N'Nhân viên bảo vệ', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'PCT', N'Phó chủ tịch', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'PGD01', N'Phó giám đốc điều hành', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'PGD02', N'Phó giám đốc tài chính', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'PM', N'Quản lý dự án', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'TGD', N'Tổng giám đốc', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'TP', N'Trưởng phòng', 0)
INSERT [dbo].[ChucVu] ([MaChucVu], [TenChucVu], [SoNhanVien]) VALUES (N'TP01', N'Trưởng phòng tài chính', 0)
GO
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [GioiTinh], [SoDienThoai], [Email], [CMND], [HocVan], [TinhTrangHonNhan], [MaPhong], [TruongPhong], [NgayVaoLam], [Luong]) VALUES (N'NV0001', N'ABC', CAST(N'2022-01-06T06:49:32.963' AS DateTime), N'', NULL, N'', N'', N'', N'', N'', N'AI01', NULL, CAST(N'2022-01-06T06:49:32.957' AS DateTime), 9.0000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [GioiTinh], [SoDienThoai], [Email], [CMND], [HocVan], [TinhTrangHonNhan], [MaPhong], [TruongPhong], [NgayVaoLam], [Luong]) VALUES (N'NV0002', N'ABCD', CAST(N'2022-01-06T06:54:24.260' AS DateTime), N'', NULL, N'', N'', N'', N'', N'', N'None', NULL, CAST(N'2022-01-06T06:54:24.253' AS DateTime), 0.0000)
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [NgaySinh], [DiaChi], [GioiTinh], [SoDienThoai], [Email], [CMND], [HocVan], [TinhTrangHonNhan], [MaPhong], [TruongPhong], [NgayVaoLam], [Luong]) VALUES (N'NV0003', N'Nguyễn Lê Thiện Nhân', CAST(N'2022-01-06T15:11:06.860' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'None', NULL, CAST(N'2022-01-06T15:11:06.833' AS DateTime), 0.0000)
GO
SET IDENTITY_INSERT [dbo].[NhanVien_ChucVu] ON 

INSERT [dbo].[NhanVien_ChucVu] ([Id], [MaNhanVien], [MaChucVu]) VALUES (9, N'NV0001', N'GD02')
INSERT [dbo].[NhanVien_ChucVu] ([Id], [MaNhanVien], [MaChucVu]) VALUES (11, N'NV0002', N'GD01')
INSERT [dbo].[NhanVien_ChucVu] ([Id], [MaNhanVien], [MaChucVu]) VALUES (12, N'NV0002', N'CT')
INSERT [dbo].[NhanVien_ChucVu] ([Id], [MaNhanVien], [MaChucVu]) VALUES (13, N'NV0003', N'CT')
INSERT [dbo].[NhanVien_ChucVu] ([Id], [MaNhanVien], [MaChucVu]) VALUES (14, N'NV0003', N'GD01')
SET IDENTITY_INSERT [dbo].[NhanVien_ChucVu] OFF
GO
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'AI01', N'Phòng AI số 01', 1, N'P101 Tầng 3')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'AI02', N'Phòng AI số 02', 0, N'P102 Tầng 2')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'BL01', N'Phòng Blockchain số 01', 0, N'P101 Tầng 3')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'BV', N'Phòng bảo vệ', 0, N'Phòng bảo vệ')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'DS01', N'Phòng thiết kế số 01', 0, N'P104 Tầng 2')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'IOS01', N'Phòng lập trình ios số 01', 0, N'P103 Tầng 3')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'LT', N'Lễ tân', 0, N'Lễ tân tầng 1')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'MB01', N'Phòng lập trình mobile số 01', 0, N'P102 Tầng 3')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'None', N'Chưa xác định', 0, N'')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'NS01', N'Phòng nhân sự', 0, N'P101 Tầng 1')
INSERT [dbo].[PhongBan] ([MaPhong], [TenPhong], [SoNhanVien], [ViTri]) VALUES (N'PHP01', N'Phòng PHP số 01', 0, N'P101 Tầng 3')
GO
ALTER TABLE [dbo].[ChucVu] ADD  DEFAULT ((0)) FOR [SoNhanVien]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ((0)) FOR [TruongPhong]
GO
ALTER TABLE [dbo].[NhanVien] ADD  DEFAULT ((0)) FOR [Luong]
GO
ALTER TABLE [dbo].[PhongBan] ADD  DEFAULT ((0)) FOR [SoNhanVien]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_PhongBan] FOREIGN KEY([MaPhong])
REFERENCES [dbo].[PhongBan] ([MaPhong])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_PhongBan]
GO
ALTER TABLE [dbo].[NhanVien_ChucVu]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu_ChucVu] FOREIGN KEY([MaChucVu])
REFERENCES [dbo].[ChucVu] ([MaChucVu])
GO
ALTER TABLE [dbo].[NhanVien_ChucVu] CHECK CONSTRAINT [FK_NhanVien_ChucVu_ChucVu]
GO
ALTER TABLE [dbo].[NhanVien_ChucVu]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_ChucVu_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
GO
ALTER TABLE [dbo].[NhanVien_ChucVu] CHECK CONSTRAINT [FK_NhanVien_ChucVu_NhanVien]
GO
USE [master]
GO
ALTER DATABASE [QuanLyNhanSuPhongBan] SET  READ_WRITE 
GO
