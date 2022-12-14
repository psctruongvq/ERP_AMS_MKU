USE [TSHTV]
GO

ALTER  FUNCTION [dbo].[fn_DSTheoPhongBanDenNgay_With_MaPhanBoSuDung] (@DenNgay datetime)    
RETURNS @Table TABLE(    
   NgaySuDung datetime,    
   MaPhongBan int,       
   MaTSCDCaBiet INT,
   MaPhanBoSuDung INT    
      )    
AS     
begin    
    
    Insert into  @TABLE      
 select A.NgayThucHien, A.MaPhongBan, A.MaTSCDCaBiet,A.MaPhanBoSuDung from tblTaiSanCoDinhCaBiet_PhongBan A            
 where NgayThucHien = (select MAX(NgayThucHien)from tblTaiSanCoDinhCaBiet_PhongBan B     
					  where A.MaTSCDCaBiet = B.MaTSCDCaBiet and B.NgayThucHien<=@DenNgay 
						group by  A.MaTSCDCaBiet )     
            
return      
end    

GO

exec TSHTV.dbo.spd_LayTSCDCaBietKhauHaoHaoMon_Goc_IN_CuongCopy @MucDichSuDung=-1,@MaKy=49,@TuKy=49,@DenKy=60,@SoTienToiThieuKhauHao=10,@MaPhongBan=0


--SELECT * FROM DuLieuBaoCaoPhucVuDoDuLieuPmTSMoi


