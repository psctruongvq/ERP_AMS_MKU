USE ERP_HTV
go
DELETE FROM dbo.tblDanhMucTSCD
DBCC CHECKIDENT ('dbo.tblDanhMucTSCD', RESEED, 0)

---------INSERT NHOM---------------
INSERT INTO dbo.tblDanhMucTSCD
        (
          Ten ,
          MaQuanLy ,
          LaNhomTaiSan ,
          PmCuMaNhom 
 
        )
        SELECT 
        TenNhomTaiSan
        ,MaNhomQuanLy
        ,1
        ,MaNhomTaiSan
         FROM TSHTV.dbo.tblNhomTaiSan
         ORDER BY MaNhomQuanLy
         
         
------------------INSERT LOAI----------------------------------------------

INSERT INTO dbo.tblDanhMucTSCD
        ( Ten ,
          MaQuanLy ,
          LaLoaiTaiSan ,
          PmCuMaLoai ,
          PmCuMaLoaiCapTren ,
          PmCuLoaiTaiSanThuocNhomTaiSan
        )
        SELECT
        TenLoaiTaiSan
        ,MaLoaiQuanLy
        ,1
        ,MaLoaiTaiSan
        ,MaLoaiTaiSanCha
        ,MaNhomTaiSan FROM TSHTV.dbo.tblLoaiTaiSan
        ORDER BY MaLoaiQuanLy

-------------UPDATE LOAI---------------------------------
--UPDATE dbo.tblCayDanhMucTSCD SET ParentID = (SELECT ID FROM dbo.tblCayDanhMucTSCD AS A
--												WHERE A.PmCuMaLoai = dbo.tblCayDanhMucTSCD.PmCuMaLoaiCapTren
												
												
--						)
--WHERE dbo.tblCayDanhMucTSCD.LaLoaiTaiSan=1
--	AND dbo.tblCayDanhMucTSCD.PmCuMaLoai IS NOT NULL
--------------------------	
UPDATE dbo.tblDanhMucTSCD SET ParentID = (SELECT ID FROM dbo.tblDanhMucTSCD AS A
												WHERE LEFT(dbo.tblDanhMucTSCD.MaQuanLy,LEN(dbo.tblDanhMucTSCD.MaQuanLy)-2) = A.MaQuanLy
												
													AND (LaNhomTaiSan =1 OR LaLoaiTaiSan=1)
						)
WHERE dbo.tblDanhMucTSCD.LaLoaiTaiSan=1


UPDATE dbo.tblDanhMucTSCD SET LoaiTaiSanThuocNhomTaiSan = (SELECT ID FROM dbo.tblDanhMucTSCD AS A
															WHERE LEFT(dbo.tblDanhMucTSCD.MaQuanLy,1)= LEFT(A.MaQuanLy,1)
															AND LaNhomTaiSan =1
															)
WHERE dbo.tblDanhMucTSCD.LaLoaiTaiSan = 1
	
------INSERT TAI SAN CO DINH-----------------------------------------------

INSERT INTO dbo.tblDanhMucTSCD
        ( Ten ,
          MaQuanLy ,
          LaTaiSanCoDinh ,
          ModelTSCD ,
          TGSuDungToiDaTSCD ,
          TGSuDungToiTHieuTSCD ,
          PmCuMaTSCD ,
          PmCuMaDonViTinh ,
          PmCuMaNuocSx,
          PmCuTSCDThuocLoaiTaiSan
        )
	SELECT
	
	TenTSCD
	,SoHieuTSCD
	,1
	,Model
	,TGSuDungToiDa
	,TGSuDungToiThieu
	,MaTSCD
	,MaDonViTinh
	,MaNuocSX
	,MaLoaiTaiSan
	FROM TSHTV.dbo.tblTaiSanCoDinh
	ORDER BY SoHieuTSCD
	
	
---------------------------------------------------------------
UPDATE dbo.tblDanhMucTSCD SET ParentID = (SELECT ID FROM dbo.tblDanhMucTSCD AS A
												WHERE LEFT(dbo.tblDanhMucTSCD.MaQuanLy,LEN(dbo.tblDanhMucTSCD.MaQuanLy)-3) = A.MaQuanLy
												
													AND a.LaLoaiTaiSan=1
						)
WHERE dbo.tblDanhMucTSCD.LaTaiSanCoDinh=1

----///
UPDATE dbo.tblDanhMucTSCD SET ParentID = (SELECT ID FROM dbo.tblDanhMucTSCD AS A
												WHERE A.PmCuMaLoai = dbo.tblDanhMucTSCD.PmCuTSCDThuocLoaiTaiSan
													AND A.LaLoaiTaiSan =1
												
						)
WHERE dbo.tblDanhMucTSCD.LaTaiSanCoDinh=1
-------------------------------