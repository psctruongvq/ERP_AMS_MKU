--cập nhật nguyên giá mua 
UPDATE ERP_HTV.dbo.tblCongCuDungCu SET NguyenGia =(SELECT SUM(NguyenGiaMua) FROM TSHTV.dbo.DuLieuChuyenCCDCKiemTra_TMP AS a
										WHERE ERP_HTV.dbo.tblCongCuDungCu.TestMaTSCDCaBiet = a.MaTSCDCaBiet
										GROUP BY MaTSCDCaBiet
									) 
WHERE TestMaTSCDCaBiet IS NOT NULL

--cập nhật Lũy kế khhm
UPDATE ERP_HTV.dbo.tblCongCuDungCu SET LuyKeKHTaiSanChuyenSang =(SELECT SUM(LuyKeKhauHao) FROM TSHTV.dbo.DuLieuChuyenCCDCKiemTra_TMP AS a
										WHERE ERP_HTV.dbo.tblCongCuDungCu.TestMaTSCDCaBiet = a.MaTSCDCaBiet
										GROUP BY MaTSCDCaBiet
									) 
									,LuyKeHMTaiSanChuyenSang =(SELECT SUM(LuyKeHaoMon) FROM TSHTV.dbo.DuLieuChuyenCCDCKiemTra_TMP AS a
										WHERE ERP_HTV.dbo.tblCongCuDungCu.TestMaTSCDCaBiet = a.MaTSCDCaBiet
										GROUP BY MaTSCDCaBiet
									) 
WHERE TestMaTSCDCaBiet IS NOT NULL
--------------------------------
UPDATE ERP_HTV.dbo.tblCongCuDungCu SET ChuyenTuTaiSan=1
WHERE TestMaTSCDCaBiet IS NOT NULL
--cập nhật lũy kế hm


--------------------
SELECT * FROM dbo.tblCongCuDungCu WHERE TestMaTSCDCaBiet IS NOT NULL




SELECT * FROM dbo.tblCongCuDungCu_PhongBan

 SELECT MaTSCDCaBiet, SUM(NguyenGiaTinhKH) AS NguyenGiaTinhKH FROM @KQX GROUP BY MaTSCDCaBiet
HAVING SUM(NguyenGiaTinhKH)<30000000---------DIEU KIEN LOC


SELECT SUM(nguyengiamua) FROM DuLieuChuyenCCDCKiemTra_TMP
SELECT * FROM DuLieuChuyenCCDCKiemTra_TMP WHERE MaTSCDCaBiet= 11468


SELECT MaTSCDCaBiet, COUNT(*) FROM DuLieuChuyenCCDCKiemTra_TMP
GROUP BY MaTSCDCaBiet
HAVING COUNT(*)>1


SELECT COUNT(*) FROM TSHTV.dbo.DuLieuChuyenCCDCKiemTra_TMP


SELECT DISTINCT LuyKeHaoMon FROM TSHTV.dbo.DuLieuChuyenCCDCKiemTra_TMP

SELECT * FROM TSHTV.dbo.DuLieuChuyenCCDCKiemTra_TMP
WHERE NguyenGiaMua - LuyKeKhauHao - LuyKeHaoMon <>NguyenGiaConLai


SELECT * FROM dbo.AppMenus