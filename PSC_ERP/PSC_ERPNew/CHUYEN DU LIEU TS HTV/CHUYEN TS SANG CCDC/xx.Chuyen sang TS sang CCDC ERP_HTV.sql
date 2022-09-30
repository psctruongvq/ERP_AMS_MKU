--SELECT * FROM dbo.tblNhomHangHoa WHERE MaLoaiVatTuHH =3

USE ERP_HTV


  /*
  --------THEM BANG [tblChiTietCCDC]----------------------------------------------------------------
  CREATE TABLE [dbo].[tblChiTietCCDC](
	[MaChiTiet] [int] IDENTITY(1,1) NOT NULL,
	[TenChiTiet] [nvarchar](4000) NOT NULL,
	[NguyenGia] [decimal](25, 0) NULL,
	[MaQuocGiaSX] [int] NULL,
	[MaDVT] [nchar](10) NULL,
	[MaCongCuDungCu] [int] NOT NULL,
	[TestMaChiTiet] [int] NULL,
	[TestMaQuocGiaSX] [int] NULL,
	[TestMaDVT] [int] NULL,
	[TestMaTSCDCaBiet] [int] NULL,
	[NamSanXuat] [int] NULL,
	[SoLuong] [int] NULL,
	[Model] [nvarchar](50) NULL,
	[Serial] [varchar](50) NULL,
	[SoHieu] [varchar](30) NULL,
	[NguyenGiaTinhKhauHao] [decimal](18, 0) NULL,
	[TestChoDuyet] [bit] NULL,
	[GhiChu] [nvarchar](4000) NULL,
	[ChiPhi] [decimal](18, 0) NULL,
	[DonGia] [decimal](18, 0) NULL,
 CONSTRAINT [PK_tblChiTietCCDC] PRIMARY KEY CLUSTERED 
(
	[MaChiTiet] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
*/
---------------------------- thêm cột để test vào bảng tblHangHoa
  ALTER TABLE dbo.tblHangHoa
  ADD TestMaTSCD INT
  
  GO
  
  ALTER TABLE dbo.tblHangHoa
  ADD TestMaLoaiTaiSan INT
  
  GO
  
  ALTER TABLE dbo.tblHangHoa
  ADD TestMaNuocSX INT
  
  GO
  
  ALTER TABLE dbo.tblHangHoa
  ADD TestMaDonViTinh INT
  
  GO
  
  ALTER TABLE dbo.tblHangHoa
  ADD TestModel nvarchar(50)
  
  GO
  -------------------------------------------------------------------
  
DECLARE @MaNhomCCTS INT=500;
--thêm nhóm
/*
DECLARE @MaNhomCCTS INT=500;
SET IDENTITY_INSERT [dbo].[tblNhomHangHoa] ON;
INSERT INTO dbo.tblNhomHangHoa
        ( MaNhomHangHoa,
		MaQuanLy ,
          TenNhomHangHoa ,
          DienGiai ,
          TinhTrang ,
          MaLoaiVatTuHH ,
          MaNhomHangHoaCha
        )
VALUES  ( @MaNhomCCTS,-- MaNhomHangHoa - int
		'CCTS' , -- MaQuanLy - varchar(20)
          N'CCDC chuyển từ tài sản 01/07/2013' , -- TenNhomHangHoa - nvarchar(100)
          N'' , -- DienGiai - nvarchar(500)
          1 , -- TinhTrang - bit
          3 , -- MaLoaiVatTuHH - int
          NULL  -- MaNhomHangHoaCha - int
        )
SET IDENTITY_INSERT [dbo].[tblNhomHangHoa] OFF;
*/

--DBCC CHECKIDENT ('dbo.tblHangHoa', RESEED, 15000)

  INSERT INTO dbo.tblHangHoa
          ( MaQuanLy ,
            TenHangHoa ,
            MaDonViTinh ,
            MaQuocGia ,
            DienGiai ,
            MaNhomHangHoa ,
            TinhTrang ,
            NgayLap ,
            TestMaTSCD ,
            TestMaLoaiTaiSan ,
            TestMaNuocSX ,
            TestMaDonViTinh ,
            TestModel
          )

  SELECT DISTINCT tscd.SoHieuTSCD,-- MaQuanLy
  tscd.TenTSCD,-- TenHangHoa
  NULL,--madonvitinh
	NULL,--maquocgia
	NULL,--diengiai
   @MaNhomCCTS,--MaNhomHangHoa
   1,--TinhTrang
   '07/01/2013',-- NgayLap
   tscd.MaTSCD,--TestMaTSCD
   tscd.MaLoaiTaiSan,--TestMaLoaiTaiSan
   tscd.MaNuocSX,--TestMaNuocSX
   tscd.MaDonViTinh,-- TestMaDonViTinh
   tscd.Model-- TestModel
   
  FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet AS ccdc
	INNER JOIN TSHTV.dbo.tblTaiSanCoDinh AS tscd ON ccdc.MaTSCD = tscd.MaTSCD
  WHERE ccdc.DaChuyenSangCCDC=1
  
  

  ----------------THÊM CỘT VÀO tblCongCuDungCu
  ALTER TABLE dbo.tblCongCuDungCu
  ADD TestMaTSCDCaBiet INT
  GO
  
  ---------------------Them cot vao tblCongCuDungCu_PhongBan
  ALTER TABLE dbo.tblCongCuDungCu_PhongBan
  ADD TestMaPhongBan INT
  GO
  --DBCC CHECKIDENT ('dbo.tblCongCuDungCu', RESEED, 20000)
DELETE FROM dbo.tblChiTietCCDC
DBCC CHECKIDENT ('dbo.tblChiTietCCDC', RESEED, 0)  
DECLARE @MaTSCDCaBiet INT;
declare @Cur cursor
			set @Cur=cursor for
				SELECT MaTSCDCaBiet FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet WHERE DaChuyenSangCCDC=1
			open @Cur
			fetch next from @Cur into @MaTSCDCaBiet
			while (@@fetch_status=0)
				BEGIN
				
				---------------------------------------------
					--SELECT * FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet AS ccdc
					--INNER JOIN dbo.tblHangHoa AS hh ON ccdc.MaTSCD = hh.TestMaTSCD 
					--WHERE ccdc.MaTSCDCaBiet =@MaTSCDCaBiet
					INSERT INTO dbo.tblCongCuDungCu
					        ( SoSerial ,
					          NguyenGia ,
					          MaQuanLy ,
					          NgayNhan ,
					          ThanhLy ,
					          NgayThanhLy ,
					          ViTri ,
					          MaHangHoa ,
					          TinhTrang ,
					          MaPhieuNhapXuat ,
					          ChiPhiDaPhanBo ,
					          ChiPhiPBLanDau ,
					          PhanTramPBLanDau ,
					          MaThanhLy ,
					          MaTaiKhoan ,
					          SBBGNOld ,
					          TestMaTSCDCaBiet
					        )
					  SELECT hh.TestModel
						, 1
						, ccdc.SoHieu
						,ccdc.NgayNhan
						,0--ThanhLy
						,NULL--NgayThanhLy
						,NULL--ViTri
						,(SELECT MaHangHoa FROM dbo.tblHangHoa WHERE TestMaTSCD =ccdc.MaTSCD)--MaHangHoa
						,1--TinhTrang
						,NULL--MaPhieuNhapXuat
						,0--ISNULL(ccdc.LuyKeKhauHao,0) + ISNULL(ccdc.LuyKeHaoMon,0)--ChiPhiDaPhanBo
						,0--ISNULL(ccdc.LuyKeKhauHao,0) + ISNULL(ccdc.LuyKeHaoMon,0)--ChiPhiPBLanDau
						,NULL--PhanTramPBLanDau
						,NULL--MaThanhLy
						,25--MaTaiKhoan--tk153
						,ccdc.SoChungTu--SBBGNOld
						,ccdc.MaTSCDCaBiet--TestMaTSCDCaBiet
					   FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet AS ccdc
						INNER JOIN dbo.tblHangHoa AS hh ON ccdc.MaTSCD = hh.TestMaTSCD 
						WHERE ccdc.MaTSCDCaBiet = @MaTSCDCaBiet
	
						
						DECLARE @MaCCDC INT = @@IDENTITY;
						
												
						-----insert chiTiet
						INSERT INTO dbo.tblChiTietCCDC
						        ( TenChiTiet ,
						          NguyenGia ,
						          MaQuocGiaSX ,
						          MaDVT ,
						          MaCongCuDungCu ,
						          TestMaChiTiet ,
						          TestMaQuocGiaSX ,
						          TestMaDVT ,
						          TestMaTSCDCaBiet ,
						          NamSanXuat ,
						          SoLuong ,
						          Model ,
						          Serial ,
						          SoHieu ,
						          NguyenGiaTinhKhauHao ,
						          TestChoDuyet ,
						          GhiChu ,
						          ChiPhi ,
						          DonGia
						        )
						SELECT ct.TenChiTiet--TenChiTiet
						,ct.NguyenGia--NguyenGia
						,NULL--MaQuocGiaSX
						,NULL--MaDVT
						,@MaCCDC--(SELECT MaCongCuDungCu FROM dbo.tblCongCuDungCu WHERE TestMaTSCDCaBiet = @MaTSCDCaBiet)--MaCongCuDungCu
						,ct.MaChiTiet--TestMaChiTiet
						,ct.MaQuocGiaSX--TestMaQuocGiaSX
						,ct.MaDVT--TestMaDVT
						,ct.MaTSCDCaBiet--TestMaTSCDCaBiet
						,ct.NamSanXuat
						,ct.SoLuong
						,ct.Model
						,ct.Serial
						,ct.SoHieu
						,ct.NguyenGiaTinhKhauHao
						,ct.ChoDuyet--TestChoDuyet
						,ct.GhiChu
						,ct.ChiPhi
						,ct.DonGia
						
						 FROM TSHTV.dbo.tblChiTietTaiSanCaBiet AS ct
						WHERE ct.MaTSCDCaBiet= @MaTSCDCaBiet
						
						
						
				------------------------------------------
					fetch next from @Cur into @MaTSCDCaBiet
				END--end while
CLOSE @Cur
DEALLOCATE @Cur

  
  
  
------------------------------------------------------------------------
--DBCC CHECKIDENT ('dbo.tblCongCuDungCu_PhongBan', RESEED, 20000)
DECLARE @MaCongCuDungCu INT;
DECLARE @TestMaTSCDCaBiet INT;
declare @Cur1 cursor
			set @Cur1=cursor for
				SELECT MaCongCuDungCu, TestMaTSCDCaBiet FROM dbo.tblCongCuDungCu AS ccdc WHERE TestMaTSCDCaBiet IS NOT NULL
			open @Cur1
			fetch next from @Cur1 into @MaCongCuDungCu, @TestMaTSCDCaBiet
			while (@@fetch_status=0)
				BEGIN
				---------------------------------------------
				
						-------------insert phong ban
						INSERT INTO dbo.tblCongCuDungCu_PhongBan
						        ( MaCongCuDungCu ,
						          MaBoPhan ,
						          NgayNhan ,
						          TestMaPhongBan
						        )
						SELECT 
							--DISTINCT
							@MaCongCuDungCu--(SELECT MaCongCuDungCu FROM dbo.tblCongCuDungCu WHERE TestMaTSCDCaBiet = @MaTSCDCaBiet)
							,MaPhongBan--mabophan
							,'07/01/2013'--tspb.NgayThucHien
							,MaPhongBan--TestMaPhongBan
						FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet_PhongBan AS tspb
						WHERE tspb.MaTSCDCaBiet = @TestMaTSCDCaBiet 
																AND tspb.NgayThucHien = (SELECT MAX(tspb1.NgayThucHien) FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet_PhongBan AS tspb1
																							WHERE tspb1.MaTSCDCaBiet = @TestMaTSCDCaBiet
																					
																							)
																--AND tspb.MaPhanBoSuDung = (SELECT MAX(tspb1.MaPhanBoSuDung) FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet_PhongBan AS tspb1
																--							WHERE tspb1.MaTSCDCaBiet = @MaTSCDCaBiet
																					
																--							)	
						
												
						
						
						
						
				------------------------------------------
					fetch next from @Cur1 into @MaCongCuDungCu, @TestMaTSCDCaBiet
				END--end while
CLOSE @Cur1
DEALLOCATE @Cur1
  
       
       
-------------------------------------------------------
--cập nhật đơn vị tính
UPDATE dbo.tblHangHoa SET MaDonViTinh= 23	WHERE TestMaDonViTinh= 2
UPDATE dbo.tblHangHoa SET MaDonViTinh= 8	WHERE TestMaDonViTinh=1
UPDATE dbo.tblHangHoa SET MaDonViTinh= 25	WHERE TestMaDonViTinh=4
UPDATE dbo.tblHangHoa SET MaDonViTinh= 22	WHERE TestMaDonViTinh=3
UPDATE dbo.tblHangHoa SET MaDonViTinh= 54	WHERE TestMaDonViTinh=25
UPDATE dbo.tblHangHoa SET MaDonViTinh= 20	WHERE TestMaDonViTinh=7
UPDATE dbo.tblHangHoa SET MaDonViTinh= 30	WHERE TestMaDonViTinh=19
UPDATE dbo.tblHangHoa SET MaDonViTinh= 19	WHERE TestMaDonViTinh=13
UPDATE dbo.tblHangHoa SET MaDonViTinh= 21	WHERE TestMaDonViTinh=22

UPDATE dbo.tblHangHoa SET MaDonViTinh= 56	WHERE TestMaDonViTinh=24
UPDATE dbo.tblHangHoa SET MaDonViTinh= 57	WHERE TestMaDonViTinh=5

UPDATE dbo.tblHangHoa SET MaDonViTinh= 7	WHERE TestMaDonViTinh=10
UPDATE dbo.tblHangHoa SET MaDonViTinh= 11	WHERE TestMaDonViTinh=18
UPDATE dbo.tblHangHoa SET MaDonViTinh= 53	WHERE TestMaDonViTinh=26
UPDATE dbo.tblHangHoa SET MaDonViTinh= 55	WHERE TestMaDonViTinh=28
UPDATE dbo.tblHangHoa SET MaDonViTinh= 32	WHERE TestMaDonViTinh=12
UPDATE dbo.tblHangHoa SET MaDonViTinh= 28	WHERE TestMaDonViTinh=20
UPDATE dbo.tblHangHoa SET MaDonViTinh= 45	WHERE TestMaDonViTinh=8
UPDATE dbo.tblHangHoa SET MaDonViTinh= 26	WHERE TestMaDonViTinh=29

UPDATE dbo.tblHangHoa SET MaDonViTinh=101	WHERE TestMaDonViTinh=27
UPDATE dbo.tblHangHoa SET MaDonViTinh=102	WHERE TestMaDonViTinh=16
UPDATE dbo.tblHangHoa SET MaDonViTinh=103	WHERE TestMaDonViTinh=14
UPDATE dbo.tblHangHoa SET MaDonViTinh=104	WHERE TestMaDonViTinh=21
UPDATE dbo.tblHangHoa SET MaDonViTinh=105	WHERE TestMaDonViTinh=23
UPDATE dbo.tblHangHoa SET MaDonViTinh=106	WHERE TestMaDonViTinh=15
UPDATE dbo.tblHangHoa SET MaDonViTinh=107	WHERE TestMaDonViTinh=17
UPDATE dbo.tblHangHoa SET MaDonViTinh=108	WHERE TestMaDonViTinh=6
UPDATE dbo.tblHangHoa SET MaDonViTinh=109	WHERE TestMaDonViTinh=9
UPDATE dbo.tblHangHoa SET MaDonViTinh=110	WHERE TestMaDonViTinh=30
--don vi tinh cho chi tiet
UPDATE dbo.tblChiTietCCDC SET MaDVT= 23	WHERE TestMaDVT=2
UPDATE dbo.tblChiTietCCDC SET MaDVT= 8	WHERE TestMaDVT=1
UPDATE dbo.tblChiTietCCDC SET MaDVT= 25	WHERE TestMaDVT=4
UPDATE dbo.tblChiTietCCDC SET MaDVT= 22	WHERE TestMaDVT=3
UPDATE dbo.tblChiTietCCDC SET MaDVT= 54	WHERE TestMaDVT=25
UPDATE dbo.tblChiTietCCDC SET MaDVT= 20	WHERE TestMaDVT=7
UPDATE dbo.tblChiTietCCDC SET MaDVT= 30	WHERE TestMaDVT=19
UPDATE dbo.tblChiTietCCDC SET MaDVT= 19	WHERE TestMaDVT=13
UPDATE dbo.tblChiTietCCDC SET MaDVT= 21	WHERE TestMaDVT=22

UPDATE dbo.tblChiTietCCDC SET MaDVT= 56	WHERE TestMaDVT=24
UPDATE dbo.tblChiTietCCDC SET MaDVT= 57	WHERE TestMaDVT=5

UPDATE dbo.tblChiTietCCDC SET MaDVT= 7	WHERE TestMaDVT=10
UPDATE dbo.tblChiTietCCDC SET MaDVT= 11	WHERE TestMaDVT=18
UPDATE dbo.tblChiTietCCDC SET MaDVT= 53	WHERE TestMaDVT=26
UPDATE dbo.tblChiTietCCDC SET MaDVT= 55	WHERE TestMaDVT=28
UPDATE dbo.tblChiTietCCDC SET MaDVT= 32	WHERE TestMaDVT=12
UPDATE dbo.tblChiTietCCDC SET MaDVT= 28	WHERE TestMaDVT=20
UPDATE dbo.tblChiTietCCDC SET MaDVT= 45	WHERE TestMaDVT=8
UPDATE dbo.tblChiTietCCDC SET MaDVT= 26	WHERE TestMaDVT=29

UPDATE dbo.tblChiTietCCDC SET MaDVT=101	WHERE TestMaDVT=27
UPDATE dbo.tblChiTietCCDC SET MaDVT=102	WHERE TestMaDVT=16
UPDATE dbo.tblChiTietCCDC SET MaDVT=103	WHERE TestMaDVT=14
UPDATE dbo.tblChiTietCCDC SET MaDVT=104	WHERE TestMaDVT=21
UPDATE dbo.tblChiTietCCDC SET MaDVT=105	WHERE TestMaDVT=23
UPDATE dbo.tblChiTietCCDC SET MaDVT=106	WHERE TestMaDVT=15
UPDATE dbo.tblChiTietCCDC SET MaDVT=107	WHERE TestMaDVT=17
UPDATE dbo.tblChiTietCCDC SET MaDVT=108	WHERE TestMaDVT=6
UPDATE dbo.tblChiTietCCDC SET MaDVT=109	WHERE TestMaDVT=9
UPDATE dbo.tblChiTietCCDC SET MaDVT=110	WHERE TestMaDVT=30
--cập nhật quốc gia


UPDATE dbo.tblHangHoa SET MaQuocGia=10	WHERE TestMaNuocSX=24
UPDATE dbo.tblHangHoa SET MaQuocGia=30	WHERE TestMaNuocSX=23
UPDATE dbo.tblHangHoa SET MaQuocGia=31	WHERE TestMaNuocSX=38
UPDATE dbo.tblHangHoa SET MaQuocGia=32	WHERE TestMaNuocSX=51
UPDATE dbo.tblHangHoa SET MaQuocGia=44	WHERE TestMaNuocSX=11
UPDATE dbo.tblHangHoa SET MaQuocGia=45	WHERE TestMaNuocSX=4
UPDATE dbo.tblHangHoa SET MaQuocGia=49	WHERE TestMaNuocSX=3
UPDATE dbo.tblHangHoa SET MaQuocGia=50	WHERE TestMaNuocSX=1
UPDATE dbo.tblHangHoa SET MaQuocGia=51	WHERE TestMaNuocSX=39
UPDATE dbo.tblHangHoa SET MaQuocGia=52	WHERE TestMaNuocSX=7
UPDATE dbo.tblHangHoa SET MaQuocGia=55	WHERE TestMaNuocSX=33
UPDATE dbo.tblHangHoa SET MaQuocGia=58	WHERE TestMaNuocSX=43
UPDATE dbo.tblHangHoa SET MaQuocGia=61	WHERE TestMaNuocSX=45
UPDATE dbo.tblHangHoa SET MaQuocGia=63	WHERE TestMaNuocSX=32
UPDATE dbo.tblHangHoa SET MaQuocGia=64	WHERE TestMaNuocSX=20
UPDATE dbo.tblHangHoa SET MaQuocGia=65	WHERE TestMaNuocSX=5
UPDATE dbo.tblHangHoa SET MaQuocGia=47	WHERE TestMaNuocSX=48
UPDATE dbo.tblHangHoa SET MaQuocGia=35	WHERE TestMaNuocSX=18
UPDATE dbo.tblHangHoa SET MaQuocGia=39	WHERE TestMaNuocSX=2
UPDATE dbo.tblHangHoa SET MaQuocGia=40	WHERE TestMaNuocSX=19
UPDATE dbo.tblHangHoa SET MaQuocGia=42	WHERE TestMaNuocSX=36
UPDATE dbo.tblHangHoa SET MaQuocGia=52	WHERE TestMaNuocSX=28
--
UPDATE dbo.tblHangHoa SET MaQuocGia=105	WHERE TestMaNuocSX=37
--
UPDATE dbo.tblHangHoa SET MaQuocGia=101	WHERE TestMaNuocSX=46
UPDATE dbo.tblHangHoa SET MaQuocGia=102	WHERE TestMaNuocSX=26
UPDATE dbo.tblHangHoa SET MaQuocGia=103	WHERE TestMaNuocSX=50
UPDATE dbo.tblHangHoa SET MaQuocGia=104	WHERE TestMaNuocSX=22
UPDATE dbo.tblHangHoa SET MaQuocGia=105	WHERE TestMaNuocSX=47
UPDATE dbo.tblHangHoa SET MaQuocGia=106	WHERE TestMaNuocSX=44
UPDATE dbo.tblHangHoa SET MaQuocGia=107	WHERE TestMaNuocSX=34
UPDATE dbo.tblHangHoa SET MaQuocGia=108	WHERE TestMaNuocSX=21
UPDATE dbo.tblHangHoa SET MaQuocGia=109	WHERE TestMaNuocSX=41
UPDATE dbo.tblHangHoa SET MaQuocGia=110	WHERE TestMaNuocSX=27
UPDATE dbo.tblHangHoa SET MaQuocGia=111	WHERE TestMaNuocSX=35
UPDATE dbo.tblHangHoa SET MaQuocGia=112	WHERE TestMaNuocSX=29
UPDATE dbo.tblHangHoa SET MaQuocGia=113	WHERE TestMaNuocSX=49
UPDATE dbo.tblHangHoa SET MaQuocGia=114	WHERE TestMaNuocSX=25
UPDATE dbo.tblHangHoa SET MaQuocGia=115	WHERE TestMaNuocSX=40
--cap nhat quoc gia cho chi tiet
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=10	WHERE TestMaQuocGiaSX=24
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=30	WHERE TestMaQuocGiaSX=23
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=31	WHERE TestMaQuocGiaSX=38
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=32	WHERE TestMaQuocGiaSX=51
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=44	WHERE TestMaQuocGiaSX=11
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=45	WHERE TestMaQuocGiaSX=4
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=49	WHERE TestMaQuocGiaSX=3
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=50	WHERE TestMaQuocGiaSX=1
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=51	WHERE TestMaQuocGiaSX=39
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=52	WHERE TestMaQuocGiaSX=7
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=55	WHERE TestMaQuocGiaSX=33
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=58	WHERE TestMaQuocGiaSX=43
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=61	WHERE TestMaQuocGiaSX=45
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=63	WHERE TestMaQuocGiaSX=32
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=64	WHERE TestMaQuocGiaSX=20
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=65	WHERE TestMaQuocGiaSX=5
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=47	WHERE TestMaQuocGiaSX=48
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=35	WHERE TestMaQuocGiaSX=18
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=39	WHERE TestMaQuocGiaSX=2
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=40	WHERE TestMaQuocGiaSX=19
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=42	WHERE TestMaQuocGiaSX=36
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=52	WHERE TestMaQuocGiaSX=28
--
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=105	WHERE TestMaQuocGiaSX=37
--
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=101	WHERE TestMaQuocGiaSX=46
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=102	WHERE TestMaQuocGiaSX=26
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=103	WHERE TestMaQuocGiaSX=50
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=104	WHERE TestMaQuocGiaSX=22
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=105	WHERE TestMaQuocGiaSX=47
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=106	WHERE TestMaQuocGiaSX=44
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=107	WHERE TestMaQuocGiaSX=34
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=108	WHERE TestMaQuocGiaSX=21
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=109	WHERE TestMaQuocGiaSX=41
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=110	WHERE TestMaQuocGiaSX=27
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=111	WHERE TestMaQuocGiaSX=35
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=112	WHERE TestMaQuocGiaSX=29
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=113	WHERE TestMaQuocGiaSX=49
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=114	WHERE TestMaQuocGiaSX=25
UPDATE dbo.tblChiTietCCDC SET MaQuocGiaSX=115	WHERE TestMaQuocGiaSX=40


---CẬP NHẬT PHÒNG BAN--------------------
--testmaphongban

UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =30 WHERE TestMaPhongBan =1
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =9 WHERE TestMaPhongBan =3
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =21 WHERE TestMaPhongBan =4
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =4 WHERE TestMaPhongBan =5
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =31 WHERE TestMaPhongBan =6
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =37 WHERE TestMaPhongBan =7
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =1 WHERE TestMaPhongBan =8
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =5 WHERE TestMaPhongBan =9
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =13 WHERE TestMaPhongBan =10
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =8 WHERE TestMaPhongBan =11
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =15 WHERE TestMaPhongBan =12
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =6 WHERE TestMaPhongBan =13
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =27 WHERE TestMaPhongBan =14
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =142 WHERE TestMaPhongBan =15
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =17 WHERE TestMaPhongBan =16
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =24 WHERE TestMaPhongBan =17
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =12 WHERE TestMaPhongBan =19
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =7 WHERE TestMaPhongBan =21
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =18 WHERE TestMaPhongBan =22
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =22 WHERE TestMaPhongBan =23
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =26 WHERE TestMaPhongBan =24
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =28 WHERE TestMaPhongBan =25
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =143 WHERE TestMaPhongBan =26
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =144 WHERE TestMaPhongBan =27
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =23 WHERE TestMaPhongBan =28
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =141 WHERE TestMaPhongBan =30
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =20 WHERE TestMaPhongBan =31
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =10 WHERE TestMaPhongBan =32
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =16 WHERE TestMaPhongBan =33
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =25 WHERE TestMaPhongBan =34
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =29 WHERE TestMaPhongBan =35
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =145 WHERE TestMaPhongBan =36
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =11 WHERE TestMaPhongBan =37
UPDATE dbo.tblCongCuDungCu_PhongBan SET MaBoPhan =40 WHERE TestMaPhongBan =38




--SELECT DISTINCT TestMaPhongBan FROM tblCongCuDungCu_PhongBan ORDER BY TestMaPhongBan

