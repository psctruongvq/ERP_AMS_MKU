

USE TSHTV
GO
DECLARE @NgayChot DATETIME =(SELECT CONVERT(DATETIME,'2013-12-31'));
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'TSHTV.[dbo].[TMPCuongTestDSTheoPhongBanDenNgay_With_MaPhanBoSuDung]') AND type in (N'U'))
DROP TABLE [TSHTV].[dbo].[TMPCuongTestDSTheoPhongBanDenNgay_With_MaPhanBoSuDung]
select fn.MaPhongBan, fn.NgaySuDung, fn.MaTSCDCaBiet,fn.MaPhanBoSuDung 
into TSHTV.dbo.[TMPCuongTestDSTheoPhongBanDenNgay_With_MaPhanBoSuDung]
from TSHTV.dbo.[fn_DSTheoPhongBanDenNgay_With_MaPhanBoSuDung](@NgayChot)as fn 

USE ERP_HTV
GO
--DECLARE @NgayChot DATETIME =(SELECT CONVERT(DATETIME,'2013-12-31'));

--đổ danh sách phòng ban
SET IDENTITY_INSERT [dbo].[tblBoPhanERPNew] ON
INSERT INTO dbo.tblBoPhanERPNew
        ( MaBoPhan ,
          TenBoPhan ,
          MaBoPhanQL ,
          KhauHaoHaoMon 

        )
SELECT MaPhongBan
	,TenPhongBan
	,MaPhongBanNguoiDung
	,ISNULL(KhauHaoHaoMon,0)
	 FROM TSHTV.dbo.tblPhongBan AS pb
SET IDENTITY_INSERT [dbo].[tblBoPhanERPNew] OFF

--DELETE FROM dbo.tblTaiSanCoDinhCaBiet
--tài sản cá biệt
SET IDENTITY_INSERT [dbo].[tblTaiSanCoDinhCaBiet] ON
INSERT INTO dbo.tblTaiSanCoDinhCaBiet
        ( 
          MaTSCDCaBiet,
		  SoHieu ,
          Serial ,
          Barcode ,
          NamSX ,
          NguyenGiaMua ,
          NguyenGiaConLai ,
          CongSuat ,
          NgayNhan ,
          NgaySuDung ,
          NgayHetHanBaoHanh ,
          ThoiGianSuDung ,
          KhauHaoNam ,
          ViTri ,
          MucDichSuDung ,
          LoaiTang ,
          SuDung ,
          NgungSuDung ,
          ThanhLy ,
          MaTSCD ,--cần cập nhật lại sau
          MaNhaCungCap ,
          NguonMua ,
		  MaNguon ,--cần cập nhật lại sau
          MaChungTuGhiTang ,
          MaNghiepVuThanhLy ,
          ChiPhi ,
          DonGia ,
          TaiKhoanDoiUng ,
          BaoHiem ,
          NguyenGiaTinhKhauHao ,
          STT ,
          SoHieuCu ,
          LoaiNghiepVu ,
          LuyKeKhauHao ,
          LuyKeHaoMon ,
          SoChungTu ,
          NgayChungTu ,
          NhomTaiSanDuAn ,
          TaiSanTinhBaoHiem ,
          NgayThanhLy ,
          LaTaiSanCu ,
          GhiChu
        )
SELECT    MaTSCDCaBiet,
		SoHieu ,
          Serial ,
          Barcode ,
          NamSX ,
          NguyenGiaMua ,
          NguyenGiaConLai ,
          CongSuat ,
          NgayNhan ,
          NgaySuDung ,
          NgayHetBaoHanHanh ,
          ThoiGianSuDung ,
          KhauHaoNam ,
          ViTri ,
          MucDichSuDung ,
          QuyetToan ,--LoaiTang
          SuDung ,
          NgungSuDung ,
          ThanhLy ,
          NULL AS MaTSCD,--cần cập nhật lại sau
          MaNhaCungCap ,
          NguonMua ,
          NULL as MaNguon ,--cần cập nhật lại sau
          NULL as MaChungTuGhiTang,
          NULL AS MaNghiepVuThanhLy ,
          ChiPhiVanChuyen ,--ChiPhi
          ChiPhiChayThu ,--DonGia
          TaiKhoanDoiUng ,
          BaoHiem ,
          NguyenGiaTinhKhauHao ,
          STT ,
          SoHieuCu ,
          LoaiNghiepVu ,
          LuyKeKhauHao ,
          LuyKeHaoMon ,
          SoChungTu ,
          NgayChungTu ,
          NhomTaiSanDuAn ,
          TaiSanTinhBaoHiem ,
          NgayThanhLy ,
          1 AS LaTaiSanCu,
          GhiChu 
          FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet
SET IDENTITY_INSERT [dbo].[tblTaiSanCoDinhCaBiet] OFF
--đổ tài sản cá biệt phòng ban
--DELETE FROM dbo.tblTaiSanCoDinhCaBiet_PhongBan
SET IDENTITY_INSERT [dbo].[tblTaiSanCoDinhCaBiet_PhongBan] ON
INSERT INTO dbo.tblTaiSanCoDinhCaBiet_PhongBan
        ( 
			MaPhanBoSuDung,
			MaTSCDCaBiet ,
          MaPhongBan ,
          NgayPhanBo ,
		PmCuMaPhongBan
        )
SELECT A.MaPhanBoSuDung,a.MaTSCDCaBiet,a.MaPhongBan,a.NgayThucHien,a.MaPhongBan  
FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet_PhongBan AS a
	INNER JOIN TSHTV.dbo.tblTaiSanCoDinhCaBiet AS b ON a.MaTSCDCaBiet = b.MaTSCDCaBiet
SET IDENTITY_INSERT [dbo].[tblTaiSanCoDinhCaBiet_PhongBan] OFF


--XÓA NHỮNG PHÂN BỔ DƯ THỪA
DELETE dbo.tblTaiSanCoDinhCaBiet_PhongBan 
WHERE MaPhanBoSuDung NOT IN (SELECT a.MaPhanBoSuDung 
						FROM TSHTV.dbo.[TMPCuongTestDSTheoPhongBanDenNgay_With_MaPhanBoSuDung] AS a
						)

--cập nhật MaTSCD mới

UPDATE dbo.tblTaiSanCoDinhCaBiet SET MaTSCD = (SELECT ID FROM dbo.tblDanhMucTSCD
												WHERE PmCuMaTSCD =(SELECT a.MaTSCD FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet AS a
																WHERE a.MaTSCDCaBiet =dbo.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet)
											)
--cập nhật nguyên giá mua
--UPDATE dbo.tblTaiSanCoDinhCaBiet SET NguyenGiaMua = (SELECT b.NguyenGiaTinhKhauHao 
--							FROM TSHTV.dbo.DuLieuBaoCaoPhucVuDoDuLieuPmTSMoi AS b
--							WHERE ISNULL(b.SCL,0)=0 AND dbo.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet=b.MaTSCDCaBiet) 											
--cập nhật lũy kế khhm từ báo cáo
UPDATE dbo.tblTaiSanCoDinhCaBiet SET LuyKeKhauHao = (SELECT b.LuyKeKH 
							FROM TSHTV.dbo.DuLieuBaoCaoPhucVuDoDuLieuPmTSMoi AS b
							WHERE ISNULL(b.SCL,0)=0 AND dbo.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet=b.MaTSCDCaBiet) 
UPDATE dbo.tblTaiSanCoDinhCaBiet SET LuyKeHaoMon = (SELECT b.LuyKeHaoMon 
							FROM TSHTV.dbo.DuLieuBaoCaoPhucVuDoDuLieuPmTSMoi AS b
							WHERE ISNULL(b.SCL,0)=0 AND dbo.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet=b.MaTSCDCaBiet) 

--tạo chi tiết nguyên giá đầu tiên cho tài sản gốc--------
--DELETE FROM dbo.tblChiTietNguyenGiaTSCD
--SELECT * FROM dbo.tblChiTietNguyenGiaTSCD
INSERT INTO dbo.tblChiTietNguyenGiaTSCD
        ( MaTSCDCaBiet ,
          SoTien ,
          LuyKeKhauHao ,
          LuyKeHaoMon ,
          --MaChungTu ,
          NgayThucHien ,
          NgayTinhKHHM ,
          --SoChungTu ,
          LoaiPhanBietNV ,
          LaNghiepVuPMCu-- ,
          --ThuocSclPMCu ,
          --MaChiTietDCGT ,
          --MaChiTietNghiepVuSuaChuaLon ,
          --MaDungCuPhuTungSCL ,
          --MaChiTietTaiSanBoSungSCL
        )
SELECT a.MaTSCDCaBiet
	,NguyenGiaMua
	,LuyKeKhauHao
	,LuyKeHaoMon
	,a.NgaySuDung AS NgayThucHien
	,a.NgaySuDung AS NgayThucHien
	,1 AS LoaiPhanBietNV
	,1 AS LaNghiepVuPMCu
	FROM dbo.tblTaiSanCoDinhCaBiet AS a
--tạo chi tiết nguyên giá cho phần điều chỉnh giá trị
	--tblChiTietNguyenGiaTSCD.LoaiPhanBietNV 1:tài sản gốc; 2:Điều chỉnh giá ts gốc; 3: SCL tài sản gốc (bổ sung dcpt hoặc chi tiết)
INSERT INTO dbo.tblChiTietNguyenGiaTSCD
        ( MaTSCDCaBiet ,
          SoTien ,
          --LuyKeKhauHao ,
          --LuyKeHaoMon ,
          --MaChungTu ,
          NgayThucHien ,
          NgayTinhKHHM ,
          --SoChungTu ,
          LoaiPhanBietNV ,
          LaNghiepVuPMCu-- ,
          --ThuocSclPMCu ,
          --MaChiTietDCGT ,
          --MaChiTietNghiepVuSuaChuaLon ,
          --MaDungCuPhuTungSCL ,
          --MaChiTietTaiSanBoSungSCL
        )
        
        select
	ts.MaTSCDCaBiet,
	ISNULL(GiaTriTang,0)-ISNULL(GiaTriGiam,0) as SoTien , 	
	--NULL LuyKeKhauHao, 
	--NULL LuyKeHaoMon,  
	a.NgayLap AS NgayThucHien,  
	a.NgayLap AS NgayTinhKHHM,
	2 AS LoaiPhanBietNV,
	1 as LaNghiepVuPMCu   
from TSHTV.dbo.tblDieuChinhGiaTri AS a
	inner join  TSHTV.dbo.tblChiTietDieuChinhGiaTri AS ct on a.MaDieuChinhGia=ct.MaDieuChinhGiaTri
	inner join TSHTV.dbo.tblTaiSanCoDinhCaBiet AS ts on ct.MaTSCDCaBiet=ts.MaTSCDCaBiet
where 	 a.NgayLap >= '01/01/2011'
	AND
	( ct.GiaTriTang is not null or ct.GiaTriGiam is not null)
	--AND ISNULL(ts.DaChuyenSangCCDC,0) =0
	
	

--SELECT * FROM dbo.tblTaiSanCoDinhCaBiet WHERE PARSENAME(NguyenGiaMua,1)!=0
--đổ dụng cụ phụ tùng
SET IDENTITY_INSERT [dbo].[tblBoSungDungCuPhuTung] ON
INSERT INTO dbo.tblBoSungDungCuPhuTung
        ( MaDungCuPhuTung,
			MaQuanLy ,
          Ten ,
          GhiChu ,
          NgayNhan ,
          NgaySuDung ,
          --NgayChungTuSCL ,--cập nhật sau
          MaTSCDCaBiet ,
          --MaDVT ,--cập nhật sau
          SoLuong ,
          TongGiaTri ,
          MaDonViTinhPMCu --,
          --UserID ,
          --MaChiTietNghiepVuSuaChuaLon ,
          --ThuocSclPMCu ,--cập nhật sau
          --LaDCPTSuaChuaLon ,--cập nhật sau
          --ChiPhi ,
          --DonGia
        )
SELECT a.MaDungCuPhuTung
	,a.MaDungCuQuanLy
	,a.TenDungCuPhuTung
	,a.GhiChu
	,a.NgayNhan
	,a.NgaySuDung 
	,a.MaTSCDCaBiet
	,a.SoLuong
	,a.GiaTri
	,a.MaDVT AS MaDonViTinhPMCu
FROM TSHTV.dbo.tblDungCuPhuTung AS a
	INNER JOIN TSHTV.dbo.tblTaiSanCoDinhCaBiet AS b ON a.MaTSCDCaBiet = b.MaTSCDCaBiet
SET IDENTITY_INSERT [dbo].[tblBoSungDungCuPhuTung] OFF
--cập nhật các cột để xác định dcpt của sửa chữa lớn
--SELECT * FROM TSHTV.dbo.v_BoSungDCPT
UPDATE dbo.tblBoSungDungCuPhuTung SET LaDCPTSuaChuaLon =1,ThuocSclPMCu=1
,NgayChungTuSCL = (SELECT c1.NgayThucHien        
					FROM TSHTV.dbo.tblBoSungDungCuPhuTung a1 
					INNER JOIN TSHTV.dbo.tblDungCuPhuTung b1 ON b1.MaDungCuPhuTung=a1.MaDungCuPhuTung
					INNER JOIN TSHTV.dbo.tblNghiepVuSuaChuaLon AS c1 ON a1.MaNghiepVuSuaChuaLon = c1.MaNghiepVuSuaChuaLon
					WHERE dbo.tblBoSungDungCuPhuTung.MaDungCuPhuTung = a1.MaDungCuPhuTung
					)
,PmCuSCLNguon =(SELECT c1.Nguon        
					FROM TSHTV.dbo.tblBoSungDungCuPhuTung a1 
					INNER JOIN TSHTV.dbo.tblDungCuPhuTung b1 ON b1.MaDungCuPhuTung=a1.MaDungCuPhuTung
					INNER JOIN TSHTV.dbo.tblNghiepVuSuaChuaLon AS c1 ON a1.MaNghiepVuSuaChuaLon = c1.MaNghiepVuSuaChuaLon
					WHERE dbo.tblBoSungDungCuPhuTung.MaDungCuPhuTung = a1.MaDungCuPhuTung
					)
,PmCuSCLNguonMua=(SELECT c1.NguonMua        
					FROM TSHTV.dbo.tblBoSungDungCuPhuTung a1 
					INNER JOIN TSHTV.dbo.tblDungCuPhuTung b1 ON b1.MaDungCuPhuTung=a1.MaDungCuPhuTung
					INNER JOIN TSHTV.dbo.tblNghiepVuSuaChuaLon AS c1 ON a1.MaNghiepVuSuaChuaLon = c1.MaNghiepVuSuaChuaLon
					WHERE dbo.tblBoSungDungCuPhuTung.MaDungCuPhuTung = a1.MaDungCuPhuTung
					)
WHERE MaDungCuPhuTung IN (
		SELECT  b.MaDungCuPhuTung        
  FROM TSHTV.dbo.tblBoSungDungCuPhuTung a INNER JOIN TSHTV.dbo.tblDungCuPhuTung b ON b.MaDungCuPhuTung=a.MaDungCuPhuTung 
	)
--đổ chi tiết tài sản
SET IDENTITY_INSERT [dbo].[tblChiTietTaiSanCaBiet] ON
INSERT INTO dbo.tblChiTietTaiSanCaBiet
        ( 
        MaChiTiet, 
        --NgayChungTuSCL ,--cập nhật sau
          TenChiTiet ,
          NguyenGia ,
          --MaQuocGiaSX ,--cập nhật sau
          --MaDVT ,--cập nhật sau
          MaTSCDCaBiet ,
          NamSanXuat ,
          SoLuong ,
          Model ,
          Serial ,
          SoHieu ,
          PmCuMaDVT ,
          PmCuMaQuocGiaSX ,
          --MaChiTietNghiepVuSuaChuaLon ,
          --LaChiTietSuaChuaLon ,--cập nhật sau
          ChiPhi ,
          DonGia --,
          --ThuocSclPMCu--cập nhật sau
        )
SELECT a.MaChiTiet
		,a.TenChiTiet
		,a.NguyenGia
		,a.MaTSCDCaBiet
		,a.NamSanXuat
		,a.SoLuong
		,a.Model
		,a.Serial
		,a.SoHieu
		,a.MaDVT AS PmCuMaDVT
		,a.MaQuocGiaSX AS PmCuMaQuocGiaSX
		,a.ChiPhi
		,a.DonGia
FROM TSHTV.dbo.tblChiTietTaiSanCaBiet AS a
	INNER JOIN TSHTV.dbo.tblTaiSanCoDinhCaBiet AS b ON a.MaTSCDCaBiet = b.MaTSCDCaBiet     
SET IDENTITY_INSERT [dbo].[tblChiTietTaiSanCaBiet] OFF
--cập nhật chi tiết là chi tiết scl
UPDATE dbo.tblChiTietTaiSanCaBiet SET LaChiTietSuaChuaLon =1,ThuocSclPMCu=1
,NgayChungTuSCL = (SELECT c1.NgayThucHien        
					FROM TSHTV.dbo.tblChiTietBoPhanSuaChua a1 
					INNER JOIN TSHTV.dbo.tblChiTietTaiSanCaBiet b1 ON b1.MaChiTiet=a1.MaChiTietCaBiet
					INNER JOIN TSHTV.dbo.tblNghiepVuSuaChuaLon AS c1 ON a1.MaNghiepVuSuaChuaLon = c1.MaNghiepVuSuaChuaLon
					WHERE dbo.tblChiTietTaiSanCaBiet.MaChiTiet = a1.MaChiTietCaBiet
					)
,PmCuSCLNguon = (SELECT c1.Nguon        
					FROM TSHTV.dbo.tblChiTietBoPhanSuaChua a1 
					INNER JOIN TSHTV.dbo.tblChiTietTaiSanCaBiet b1 ON b1.MaChiTiet=a1.MaChiTietCaBiet
					INNER JOIN TSHTV.dbo.tblNghiepVuSuaChuaLon AS c1 ON a1.MaNghiepVuSuaChuaLon = c1.MaNghiepVuSuaChuaLon
					WHERE dbo.tblChiTietTaiSanCaBiet.MaChiTiet = a1.MaChiTietCaBiet
					)			
,PmCuSCLNguonMua = (SELECT c1.NguonMua        
					FROM TSHTV.dbo.tblChiTietBoPhanSuaChua a1 
					INNER JOIN TSHTV.dbo.tblChiTietTaiSanCaBiet b1 ON b1.MaChiTiet=a1.MaChiTietCaBiet
					INNER JOIN TSHTV.dbo.tblNghiepVuSuaChuaLon AS c1 ON a1.MaNghiepVuSuaChuaLon = c1.MaNghiepVuSuaChuaLon
					WHERE dbo.tblChiTietTaiSanCaBiet.MaChiTiet = a1.MaChiTietCaBiet
					)								
WHERE MaChiTiet IN (
		SELECT  b.MaChiTiet        
  FROM TSHTV.dbo.tblChiTietBoPhanSuaChua a INNER JOIN TSHTV.dbo.tblChiTietTaiSanCaBiet b ON b.MaChiTiet=a.MaChiTietCaBiet  
)
--tạo chi tiết nguyên giá cho sửa chữa lớn (dụng cụ phụ tùng và chi tiết sum lại 1 dòng)
INSERT INTO dbo.tblChiTietNguyenGiaTSCD
        ( MaTSCDCaBiet ,
          SoTien ,
          LuyKeKhauHao ,
          LuyKeHaoMon ,
          --MaChungTu ,
          NgayThucHien ,
          NgayTinhKHHM ,
          --SoChungTu ,
          LoaiPhanBietNV ,
          LaNghiepVuPMCu ,
          ThuocSclPMCu --,
          --MaChiTietDCGT ,
          --MaChiTietNghiepVuSuaChuaLon ,
          --MaDungCuPhuTungSCL,
          --MaChiTietTaiSanBoSungSCL
        )
SELECT MaTSCDCaBiet
	,a.NguyenGiaMua
	,a.LuyKeKH
	,a.LuyKeHaoMon
	,(SELECT TOP 1 c1.NgayThucHien  FROM      
					
					TSHTV.dbo.tblNghiepVuSuaChuaLon AS c1 
					INNER JOIN TSHTV.dbo.v_BoSungDCPT AS bs ON c1.MaNghiepVuSuaChuaLon = bs.MaNghiepVuSuaChuaLon
					WHERE a.MaTSCDCaBiet = bs.MaTSCDCaBiet
					) AS NgayThucHien
	,(SELECT TOP 1 c1.NgayThucHien FROM       
					TSHTV.dbo.tblNghiepVuSuaChuaLon AS c1 
					INNER JOIN TSHTV.dbo.v_BoSungDCPT AS bs ON c1.MaNghiepVuSuaChuaLon = bs.MaNghiepVuSuaChuaLon
					WHERE a.MaTSCDCaBiet = bs.MaTSCDCaBiet
					)  AS NgayTinhKHHM
	,3 AS LoaiPhanBietNV
	,1 AS LaNghiepVuPMCu
	,1 AS ThuocSclPMCu
FROM TSHTV.dbo.DuLieuBaoCaoPhucVuDoDuLieuPmTSMoi AS a
WHERE ISNULL(a.SCL,0)=1



--cập nhật lại ngày chứng từ cho các tài sản cũ không có ngày chứng từ
UPDATE dbo.tblTaiSanCoDinhCaBiet SET NgayChungTu = NgaySuDung WHERE NgayChungTu IS NULL
--
--cap nhat don vi tinh danh muc tai san
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 23	WHERE PmCuMaDonViTinh= 2
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 8	WHERE PmCuMaDonViTinh=1
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 25	WHERE PmCuMaDonViTinh=4
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 22	WHERE PmCuMaDonViTinh=3
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 54	WHERE PmCuMaDonViTinh=25
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 20	WHERE PmCuMaDonViTinh=7
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 30	WHERE PmCuMaDonViTinh=19
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 19	WHERE PmCuMaDonViTinh=13
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 21	WHERE PmCuMaDonViTinh=22

UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 56	WHERE PmCuMaDonViTinh=24
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 57	WHERE PmCuMaDonViTinh=5

UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 7	WHERE PmCuMaDonViTinh=10
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 11	WHERE PmCuMaDonViTinh=18
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 53	WHERE PmCuMaDonViTinh=26
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 55	WHERE PmCuMaDonViTinh=28
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 32	WHERE PmCuMaDonViTinh=12
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 28	WHERE PmCuMaDonViTinh=20
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 45	WHERE PmCuMaDonViTinh=8
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD= 26	WHERE PmCuMaDonViTinh=29

UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=101	WHERE PmCuMaDonViTinh=27
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=102	WHERE PmCuMaDonViTinh=16
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=103	WHERE PmCuMaDonViTinh=14
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=104	WHERE PmCuMaDonViTinh=21
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=105	WHERE PmCuMaDonViTinh=23
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=106	WHERE PmCuMaDonViTinh=15
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=107	WHERE PmCuMaDonViTinh=17
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=108	WHERE PmCuMaDonViTinh=6
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=109	WHERE PmCuMaDonViTinh=9
UPDATE dbo.tblDanhMucTSCD SET MaDonViTinhTSCD=110	WHERE PmCuMaDonViTinh=30
--don vi tinh cho chi tiet tai san ca biet
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 23	WHERE PmCuMaDVT=2
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 8	WHERE PmCuMaDVT=1
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 25	WHERE PmCuMaDVT=4
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 22	WHERE PmCuMaDVT=3
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 54	WHERE PmCuMaDVT=25
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 20	WHERE PmCuMaDVT=7
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 30	WHERE PmCuMaDVT=19
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 19	WHERE PmCuMaDVT=13
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 21	WHERE PmCuMaDVT=22

UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 56	WHERE PmCuMaDVT=24
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 57	WHERE PmCuMaDVT=5

UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 7	WHERE PmCuMaDVT=10
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 11	WHERE PmCuMaDVT=18
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 53	WHERE PmCuMaDVT=26
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 55	WHERE PmCuMaDVT=28
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 32	WHERE PmCuMaDVT=12
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 28	WHERE PmCuMaDVT=20
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 45	WHERE PmCuMaDVT=8
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT= 26	WHERE PmCuMaDVT=29

UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=101	WHERE PmCuMaDVT=27
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=102	WHERE PmCuMaDVT=16
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=103	WHERE PmCuMaDVT=14
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=104	WHERE PmCuMaDVT=21
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=105	WHERE PmCuMaDVT=23
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=106	WHERE PmCuMaDVT=15
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=107	WHERE PmCuMaDVT=17
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=108	WHERE PmCuMaDVT=6
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=109	WHERE PmCuMaDVT=9
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaDVT=110	WHERE PmCuMaDVT=30
--cap nhat don vi tinh bo sung dung cu phu tung
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 23	WHERE MaDonViTinhPMCu=2
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 8	WHERE MaDonViTinhPMCu=1
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 25	WHERE MaDonViTinhPMCu=4
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 22	WHERE MaDonViTinhPMCu=3
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 54	WHERE MaDonViTinhPMCu=25
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 20	WHERE MaDonViTinhPMCu=7
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 30	WHERE MaDonViTinhPMCu=19
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 19	WHERE MaDonViTinhPMCu=13
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 21	WHERE MaDonViTinhPMCu=22

UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 56	WHERE MaDonViTinhPMCu=24
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 57	WHERE MaDonViTinhPMCu=5

UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 7	WHERE MaDonViTinhPMCu=10
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 11	WHERE MaDonViTinhPMCu=18
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 53	WHERE MaDonViTinhPMCu=26
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 55	WHERE MaDonViTinhPMCu=28
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 32	WHERE MaDonViTinhPMCu=12
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 28	WHERE MaDonViTinhPMCu=20
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 45	WHERE MaDonViTinhPMCu=8
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT= 26	WHERE MaDonViTinhPMCu=29

UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=101	WHERE MaDonViTinhPMCu=27
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=102	WHERE MaDonViTinhPMCu=16
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=103	WHERE MaDonViTinhPMCu=14
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=104	WHERE MaDonViTinhPMCu=21
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=105	WHERE MaDonViTinhPMCu=23
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=106	WHERE MaDonViTinhPMCu=15
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=107	WHERE MaDonViTinhPMCu=17
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=108	WHERE MaDonViTinhPMCu=6
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=109	WHERE MaDonViTinhPMCu=9
UPDATE dbo.tblBoSungDungCuPhuTung SET MaDVT=110	WHERE MaDonViTinhPMCu=30
--


--cap nhat quoc gia cho danh muc ts
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=10	WHERE PmCuMaNuocSx=24
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=30	WHERE PmCuMaNuocSx=23
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=31	WHERE PmCuMaNuocSx=38
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=32	WHERE PmCuMaNuocSx=51
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=44	WHERE PmCuMaNuocSx=11
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=45	WHERE PmCuMaNuocSx=4
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=49	WHERE PmCuMaNuocSx=3
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=50	WHERE PmCuMaNuocSx=1
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=51	WHERE PmCuMaNuocSx=39
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=52	WHERE PmCuMaNuocSx=7
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=55	WHERE PmCuMaNuocSx=33
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=58	WHERE PmCuMaNuocSx=43
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=61	WHERE PmCuMaNuocSx=45
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=63	WHERE PmCuMaNuocSx=32
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=64	WHERE PmCuMaNuocSx=20
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=65	WHERE PmCuMaNuocSx=5
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=47	WHERE PmCuMaNuocSx=48
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=35	WHERE PmCuMaNuocSx=18
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=39	WHERE PmCuMaNuocSx=2
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=40	WHERE PmCuMaNuocSx=19
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=42	WHERE PmCuMaNuocSx=36
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=52	WHERE PmCuMaNuocSx=28
--
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=105	WHERE PmCuMaNuocSx=37
--
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=101	WHERE PmCuMaNuocSx=46
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=102	WHERE PmCuMaNuocSx=26
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=103	WHERE PmCuMaNuocSx=50
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=104	WHERE PmCuMaNuocSx=22
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=105	WHERE PmCuMaNuocSx=47
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=106	WHERE PmCuMaNuocSx=44
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=107	WHERE PmCuMaNuocSx=34
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=108	WHERE PmCuMaNuocSx=21
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=109	WHERE PmCuMaNuocSx=41
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=110	WHERE PmCuMaNuocSx=27
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=111	WHERE PmCuMaNuocSx=35
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=112	WHERE PmCuMaNuocSx=29
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=113	WHERE PmCuMaNuocSx=49
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=114	WHERE PmCuMaNuocSx=25
UPDATE dbo.tblDanhMucTSCD SET MaNuocSxTSCD=115	WHERE PmCuMaNuocSx=40
--cap nhat quoc gia cho chi tiet tai san
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=10	WHERE PmCuMaQuocGiaSX=24
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=30	WHERE PmCuMaQuocGiaSX=23
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=31	WHERE PmCuMaQuocGiaSX=38
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=32	WHERE PmCuMaQuocGiaSX=51
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=44	WHERE PmCuMaQuocGiaSX=11
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=45	WHERE PmCuMaQuocGiaSX=4
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=49	WHERE PmCuMaQuocGiaSX=3
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=50	WHERE PmCuMaQuocGiaSX=1
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=51	WHERE PmCuMaQuocGiaSX=39
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=52	WHERE PmCuMaQuocGiaSX=7
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=55	WHERE PmCuMaQuocGiaSX=33
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=58	WHERE PmCuMaQuocGiaSX=43
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=61	WHERE PmCuMaQuocGiaSX=45
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=63	WHERE PmCuMaQuocGiaSX=32
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=64	WHERE PmCuMaQuocGiaSX=20
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=65	WHERE PmCuMaQuocGiaSX=5
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=47	WHERE PmCuMaQuocGiaSX=48
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=35	WHERE PmCuMaQuocGiaSX=18
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=39	WHERE PmCuMaQuocGiaSX=2
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=40	WHERE PmCuMaQuocGiaSX=19
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=42	WHERE PmCuMaQuocGiaSX=36
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=52	WHERE PmCuMaQuocGiaSX=28
--
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=105	WHERE PmCuMaQuocGiaSX=37
--
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=101	WHERE PmCuMaQuocGiaSX=46
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=102	WHERE PmCuMaQuocGiaSX=26
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=103	WHERE PmCuMaQuocGiaSX=50
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=104	WHERE PmCuMaQuocGiaSX=22
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=105	WHERE PmCuMaQuocGiaSX=47
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=106	WHERE PmCuMaQuocGiaSX=44
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=107	WHERE PmCuMaQuocGiaSX=34
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=108	WHERE PmCuMaQuocGiaSX=21
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=109	WHERE PmCuMaQuocGiaSX=41
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=110	WHERE PmCuMaQuocGiaSX=27
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=111	WHERE PmCuMaQuocGiaSX=35
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=112	WHERE PmCuMaQuocGiaSX=29
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=113	WHERE PmCuMaQuocGiaSX=49
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=114	WHERE PmCuMaQuocGiaSX=25
UPDATE dbo.tblChiTietTaiSanCaBiet SET MaQuocGiaSX=115	WHERE PmCuMaQuocGiaSX=40
--
--script ho tro kiem tra
--------SELECT * FROM dbo.tblDanhMucTSCD WHERE MaDonViTinhTSCD IS NULL AND PmCuMaDonViTinh IS NOT NULL
--------SELECT * FROM dbo.tblChiTietTaiSanCaBiet WHERE MaDVT IS NULL AND PmCuMaDVT IS NOT NULL
--------SELECT * FROM dbo.tblBoSungDungCuPhuTung WHERE MaDVT IS NULL AND MaDonViTinhPMCu IS NOT NULL
--------SELECT MaNuocSxTSCD,PmCuMaNuocSx FROM dbo.tblDanhMucTSCD WHERE MaNuocSxTSCD IS NULL AND PmCuMaNuocSx IS NOT NULL



--cập nhật mã MaNguon mới cho tblTaiSanCoDinhCaBiet(chưa đủ thông tin)
UPDATE dbo.tblTaiSanCoDinhCaBiet SET MaNguon=1 WHERE 
MaTSCDCaBiet IN (SELECT MaTSCDCaBiet FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet AS a WHERE a.MaNguon IN (1,2,3,4,5))

UPDATE dbo.tblTaiSanCoDinhCaBiet SET MaNguon=5 WHERE 
MaTSCDCaBiet IN (SELECT MaTSCDCaBiet FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet AS a WHERE a.MaNguon IN (6,7,8))

UPDATE dbo.tblTaiSanCoDinhCaBiet SET MaNguon=11 WHERE 
MaTSCDCaBiet IN (SELECT MaTSCDCaBiet FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet AS a WHERE a.MaNguon IN (9))


UPDATE dbo.tblTaiSanCoDinhCaBiet SET MaNguon=16 WHERE 
MaTSCDCaBiet IN (SELECT MaTSCDCaBiet FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet AS a WHERE a.MaNguon IN (12))



--SELECT * FROM tblChiTietTaiSanCaBiet
--SELECT * FROM tblBoSungDungCuPhuTung
--SELECT * FROM dbo.tblTaiSanCoDinhCaBiet
--SELECT * FROM TSHTV.dbo.tblTaiSanCoDinhCaBiet
--SELECT * FROM dbo.tblNguon
--EX--EC sp_TSCD_FillDanhSachPhongBanERPNew
--SELECT * FROM dbo.tblBoPhanERPNew
