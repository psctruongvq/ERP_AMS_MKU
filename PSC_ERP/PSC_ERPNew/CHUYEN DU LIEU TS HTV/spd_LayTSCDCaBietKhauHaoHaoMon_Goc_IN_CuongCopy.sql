USE [TSHTV]
GO
/****** Object:  StoredProcedure [dbo].[spd_LayTSCDCaBietKhauHaoHaoMon_Goc_IN_CuongCopy]    Script Date: 01/10/2014 15:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[spd_LayTSCDCaBietKhauHaoHaoMon_Goc_IN_CuongCopy](@MucDichSuDung int, @MaKy INT,@TuKy INT,@DenKy INT, @SoTienToiThieuKhauhao DECIMAL,@MaPhongBan INT)      
as
begin

	SET XACT_ABORT ON    
	Begin Transaction       
	

	--DECLARE @MaKySS INT        
	DECLARE @TenKyTuKy NVARCHAR(50)        
	DECLARE @TenKyDenKy NVARCHAR(50)         
	SELECT @TenKyDenKy = TenKy FROM dbo.tblKy WHERE MaKy=@DenKy                 
	--SELECT @MaKySS = MaKy,@TenKyTuKy = TenKy FROM [tblKy] WHERE MONTH(ngaybatdau)=@MaKy AND YEAR(ngaybatdau)=YEAR(GETDATE())        
	SELECT @TenKyTuKy = TenKy FROM dbo.tblKy WHERE MaKy=@MaKy        
	DECLARE @NgayCuaKy DATETIME           
	DECLARE @NgayCuoiKy DATETIME      
	SET @NgayCuaKy = (SELECT NgayBatDau FROM dbo.tblKy WHERE MaKy = @TuKy)        
	SET @NgayCuoiKy = (SELECT NgayKetThuc FROM dbo.tblKy WHERE MaKy = @DenKy)    
	DECLARE @CoChinhSua BIT                
    SET @CoChinhSua = 0   
    
    
	DECLARE @DanhSachNhoHon30tr TABLE (MaTSCDCaBiet INT )  
	INSERT INTO @DanhSachNhoHon30tr
	SELECT MaTSCDCaBiet FROM dbo.tblTaiSanCoDinhCaBiet 
		WHERE DaChuyenSangCCDC=1 AND ThanhLy =1 AND NgayThanhLy <=@NgayCuoiKy
	            
declare  @KQ table (MaTSCDCaBiet int, SoHieu varchar(50), TenTaiSanCoDinh nvarchar(2000),PhanTramKhauHao int, NgaySuDung datetime, TaiKhoan varchar(20),
					 Nguon nvarchar(20) , MaPhongBanQL varchar(50), TenPhongBan nvarchar(500), NguyenGiaMua decimal(18,2), NguyenGiaTinhKhauHao decimal(18,2), 
					 LuyKeHaoMon decimal(18,2), LuyKeKH  decimal(18,2), LuyKe decimal(18,2),GiaTriConLai decimal(18,2), SoTienKhauHao decimal(18,2), Loai int)


/****** Object:  Table [dbo].[PhongBan]    Script Date: 11/09/2011 10:48:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PhongBan]') AND type in (N'U'))
DROP TABLE [dbo].[PhongBan]
--declare @PhongBan table(MaPhongBan int, NgayThucHien datetime, MaTSCDCaBiet int)

--insert into @PhongBan(MaPhongBan, NgayThucHien, MaTSCDCaBiet)
select fn.MaPhongBan, fn.NgaySuDung, fn.MaTSCDCaBiet 
into [PhongBan]
from dbo.[fn_DSTheoPhongBanDenNgay](@NgayCuoiKy)as fn --where MaPhongBan!=26
--- khuc nay lay tai co dinh co sua chua lon-----
declare @TongSCL table (MaTSCDCaBiet int, SoTienKH decimal)
insert into @TongSCL
select MaTSCDCaBiet, SUM(SoTien)as SoTienKH from tblNghiepVuKhauHaoHaoMon inner join tblKy on tblKy.MaKy=tblNghiepVuKhauHaoHaoMon.DenKy
where tblKy.NgayKetThuc<=@NgayCuoiKy and  isnull(tblNghiepVuKhauHaoHaoMon.MaNghiepVuSuaChuaLon,0)!=0
group by MaTSCDCaBiet


declare @TongSCLDenNgay table (MaTSCDCaBiet int, SoTienKH decimal)
insert into @TongSCLDenNgay
select MaTSCDCaBiet, SUM(SoTien)as SoTienKH from tblNghiepVuKhauHaoHaoMon inner join tblKy on tblKy.MaKy=tblNghiepVuKhauHaoHaoMon.DenKy
where tblKy.NgayKetThuc<@NgayCuaKy and  isnull(tblNghiepVuKhauHaoHaoMon.MaNghiepVuSuaChuaLon,0)!=0
group by MaTSCDCaBiet
--- tinh tong sua khau hao sau chua lon----

declare @SCLTrongKy table (MaTSCDCaBiet int, SoTienKH decimal)
insert into @SCLTrongKy
select MaTSCDCaBiet, SUM(SoTien)as SoTienKH from tblNghiepVuKhauHaoHaoMon 
where tblNghiepVuKhauHaoHaoMon.DenKy between @TuKy and @DenKy and  isnull(tblNghiepVuKhauHaoHaoMon.MaNghiepVuSuaChuaLon,0)!=0
group by MaTSCDCaBiet

-----
---------khâu hao của tài sản tron kỳ
declare @KhauHaoTrongKy table (MaTSCDCaBiet int, SoTienKH decimal)
insert into @KhauHaoTrongKy
select MaTSCDCaBiet, SUM(SoTien)as SoTienKH from tblNghiepVuKhauHaoHaoMon
where DenKy between @TuKy and @DenKy
group by MaTSCDCaBiet
-------------

---------khâu hao của tài sản tron kỳ
--declare @TongKhauHaoTaiSan table (MaTSCDCaBiet int, SoTienKH decimal)
--insert into @TongKhauHaoTaiSan
--select MaTSCDCaBiet, SUM(SoTien)as SoTienKH from tblNghiepVuKhauHaoHaoMon
--where DenKy <=@DenKy
--group by MaTSCDCaBiet
-------------


-----khuc nay tinh khau hao cua tài sản bình thường-------
declare @TongKhauHao table (MaTSCDCaBiet int, SoTienKH decimal)
insert into @TongKhauHao
select tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet, SUM(SoTien)as SoTienKH 
from tblNghiepVuKhauHaoHaoMon inner join tblTaiSanCoDinhCaBiet on tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet=tblTaiSanCoDinhCaBiet.MaTSCDCaBiet
			inner join tblTiLeKhauHaoTheoTaiKhoan on tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK=tblTaiSanCoDinhCaBiet.TaiKhoanDoiUng
	 inner join tblTaiSanCoDinh on tblTaiSanCoDinh.MaTSCD=tblTaiSanCoDinhCaBiet.MaTSCD
	 inner join tblKy on tblKy.MaKy=tblNghiepVuKhauHaoHaoMon.DenKy
	 INNER JOIN [PhongBan] as d ON tblTaiSanCoDinhCaBiet.MaTSCDCaBiet = d.MaTSCDCaBiet	 
	 inner join tblPhongBan on tblPhongBan.MaPhongBan=d.MaPhongBan	
	 inner join tblNghiepVuGhiTang on tblNghiepVuGhiTang.MaNghiepVuGhiTang=tblTaiSanCoDinhCaBiet.MaNghiepVuGhiTang
	 inner join tblDoiTuongNghiepVu on tblDoiTuongNghiepVu.MaDoiTuong=tblNghiepVuGhiTang.MaNghiepVuGhiTang
	 inner join tblChungTu on tblChungTu.MaChungTu=tblDoiTuongNghiepVu.MaChungTu
	 where tblKy.NgayKetThuc > @NgayCuoiKy
	 		and (tblPhongBan.MaPhongBan=@MaPhongBan or @MaPhongBan=0)
	 		and tblTiLeKhauHaoTheoTaiKhoan.Nam=YEAR(@NgayCuaKy)
           and tblChungTu.NgayLap<= @NgayCuoiKy
group by tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet

-- lấy khấu hao của tài sản cu--
	INSERT INTO @TongKhauHao    		
	select       
		tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet,      
		sum(tblNghiepVuKhauHaoHaoMon.SoTien) as SoTienKH      
	from tblNghiepVuKhauHaoHaoMon inner join tblTaiSanCoDinhCaBiet on tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet=tblTaiSanCoDinhCaBiet.MaTSCDCaBiet  
	inner join tblTiLeKhauHaoTheoTaiKhoan on tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK=tblTaiSanCoDinhCaBiet.TaiKhoanDoiUng  
	inner join tblTaiSanCoDinh on tblTaiSanCoDinh.MaTSCD=tblTaiSanCoDinhCaBiet.MaTSCD  
	inner join tblKy on tblKy.MaKy=tblNghiepVuKhauHaoHaoMon.DenKy  
	INNER JOIN [PhongBan] as d ON tblTaiSanCoDinhCaBiet.MaTSCDCaBiet = d.MaTSCDCaBiet    
	inner join tblPhongBan on tblPhongBan.MaPhongBan=d.MaPhongBan   
	where tblKy.NgayKetThuc > @NgayCuoiKy  
		and tblTiLeKhauHaoTheoTaiKhoan.Nam=YEAR(@NgayCuoiKy)
		and ISNULL(tblTaiSanCoDinhCaBiet.LaTaiSanCu,0)=1     
	group by tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet	
-------kết thúc tính tổng khấu hao------------------

 --------------------do tai san vào bảng @KQ------------
  
 insert into @KQ
	SELECT  
		a.MaTSCDCaBiet,
		a.SoHieu,
		b.TenTSCD,
		tblTiLeKhauHaoTheoTaiKhoan.PhanTram as KhauHaoNam,
		a.NgaySuDung,
		tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK,
		case when a.NguonMua=0
		 then N'L'else N'DA'end NguonMua,
		e.MaPhongBanNguoiDung,
		e.TenPhongBan,                                                 
		ISNULL(a.NguyenGiaMua,0)as NguyenGiaMua,   
		ISNULL(a.NguyenGiaMua,0) as NguyenGiaTinhKhauHao,                  
		ISNULL(a.LuyKeHaoMon,0) as LuyKeHaoMon, 
		ISNULL( a.LuyKeKhauHao,0)as LuyKeKhauHao, 
		0 as LuyKe,
		0 as NguyenGiaConLai,
		0 as SoTienKhauHao  ,
		4 as Loai   
	from tblTaiSanCoDinhCaBiet as a INNER JOIN tblTaiSanCoDinh b ON a.MaTSCD = b.MaTSCD
		inner join tblTiLeKhauHaoTheoTaiKhoan on tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK=a.TaiKhoanDoiUng
		left OUTER JOIN tblDonViTinh c ON b.MaDonViTinh = c.MaDVT
		INNER JOIN [PhongBan] as d ON a.MaTSCDCaBiet = d.MaTSCDCaBiet
		INNER JOIN tblPhongBan e ON d.MaPhongBan = e.MaPhongBan  
		LEFT JOIN [tblQuocGia] f ON b.[MaNuocSX] = f.[MaNuoc]  -- ok
		--left join dbo.[fn_TaiSanKhauHao](@NgayCuaKy, @NgayCuoiKy) as fn on a.MaTSCDCaBiet=fn.MaTSCDCaBiet
	where 
	 a.MaTSCDCaBiet not in( select MaTSCDCaBiet from tblTaiSanCoDinhCaBiet where ThanhLy=1 and NgayThanhLy<=@NgayCuoiKy) 
		and (e.MaPhongBan=@MaPhongBan or @MaPhongBan=0)
		and tblTiLeKhauHaoTheoTaiKhoan.Nam=YEAR(@NgayCuaKy)
		and ISNULL(a.NgayChungTu,'01/12/2010')<=@NgayCuoiKy
		AND a.MaTSCDCaBiet NOT IN (SELECT MaTSCDCaBiet FROM @DanhSachNhoHon30tr)
		
---- dieu chinh gia tri vao @KQ-----------

insert into @KQ
select
	tblTaiSanCoDinhCaBiet.MaTSCDCaBiet,
	tblTaiSanCoDinhCaBiet.SoHieu,
	tblTaiSanCoDinh.TenTSCD,
	tblTiLeKhauHaoTheoTaiKhoan.PhanTram as KhauHaoNam,
	tblTaiSanCoDinhCaBiet.NgaySuDung,
	tblTaiSanCoDinhCaBiet.TaiKhoanDoiUng,
	case when tblTaiSanCoDinhCaBiet.NguonMua=0
	then N'L' else N'DA' end NguonMua,
	tblPhongBan.MaPhongBanNguoiDung,                                                              
	tblPhongBan.TenPhongBan,
	0 as NguyenGiaMua,
	case when  tblChiTietDieuChinhGiaTri.GiaTriTang is not null
	then tblChiTietDieuChinhGiaTri.GiaTriTang
	else - tblChiTietDieuChinhGiaTri.GiaTriGiam 
	end as NguyenGiaTinhKhauHao , 	
	0 LuyKeHaoMon, 
	0 LuyKeKhauHao,  
	0 as LuyKe,  
	0 as NguyenGiaConLai,
	0 as SoTienKhauHao ,
	4 as Loai   
from tblDieuChinhGiaTri 
	inner join  tblChiTietDieuChinhGiaTri on tblDieuChinhGiaTri.MaDieuChinhGia=tblChiTietDieuChinhGiaTri.MaDieuChinhGiaTri
	inner join tblTaiSanCoDinhCaBiet on tblChiTietDieuChinhGiaTri.MaTSCDCaBiet=tblTaiSanCoDinhCaBiet.MaTSCDCaBiet
	inner join tblTiLeKhauHaoTheoTaiKhoan on tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK=tblTaiSanCoDinhCaBiet.TaiKhoanDoiUng            
	inner join tblTaiSanCoDinh on tblTaiSanCoDinh.MaTSCD=tblTaiSanCoDinhCaBiet.MaTSCD
	INNER JOIN [PhongBan] as d ON tblTaiSanCoDinhCaBiet.MaTSCDCaBiet = d.MaTSCDCaBiet
	inner join tblPhongBan on tblPhongBan.MaPhongBan=d.MaPhongBan
	left join tblDonViTinh on tblTaiSanCoDinh.MaDonViTinh=tblDonViTinh.MaDVT
	LEFT JOIN [tblQuocGia]  ON tblQuocGia.MaNuoc  = tblTaiSanCoDinh.[MaNuocSX] 
where 	 tblDieuChinhGiaTri.NgayLap between '01/01/2011' and @NgayCuoiKy
	and( GiaTriTang is not null or GiaTriGiam is not null)
	and (tblPhongBan.MaPhongBan=@MaPhongBan or @MaPhongBan=0)
	and tblTiLeKhauHaoTheoTaiKhoan.Nam=YEAR(@NgayCuaKy)
	AND dbo.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet NOT IN (SELECT MaTSCDCaBiet FROM @DanhSachNhoHon30tr)

-------------sum tai san lai---------------
declare  @KQTSCD table (MaTSCDCaBiet int, SoHieu varchar(50), TenTaiSanCoDinh nvarchar(2000),PhanTramKhauHao int, NgaySuDung datetime, TaiKhoan varchar(20),
					 Nguon nvarchar(20) , MaPhongBanQL varchar(50), TenPhongBan nvarchar(500), NguyenGiaMua decimal(18,2), NguyenGiaTinhKhauHao decimal(18,2), 
					 LuyKeHaoMon decimal(18,2), LuyKeKH  decimal(18,2), LuyKe decimal(18,2),GiaTriConLai decimal(18,2), SoTienKhauHao decimal(18,2), Loai int)

insert into @KQTSCD	
select
	MaTSCDCaBiet,
	SoHieu,
	TenTaiSanCoDinh,
	PhanTramKhauHao,	
	NgaySuDung,
	TaiKhoan,
	Nguon,
	MaPhongBanQL,                                                              
	TenPhongBan,
	sum(NguyenGiaMua)as  NguyenGiaMua,
	sum(NguyenGiaTinhKhauHao) as NguyenGiaTinhKhauHao , 	
	sum(LuyKeHaoMon)as LuyKeHaoMon, 
	sum(LuyKeKH)as LuyKeKH,  
	sum(LuyKe) as LuyKe,     
	sum(GiaTriConLai) as GiaTriConLai, 
	sum(SoTienKhauHao)as SoTienKhauHao ,
	Loai   
from @KQ   
group by 	MaTSCDCaBiet,
	SoHieu,
	TenTaiSanCoDinh,
	PhanTramKhauHao,	
	NgaySuDung,
	TaiKhoan,
	Nguon,
	MaPhongBanQL,                                                              
	TenPhongBan,
	Loai


----------- lay cua tai san--------------------
declare  @TaiSanNew table (MaTSCDCaBiet int, SoHieu varchar(50), TenTaiSanCoDinh nvarchar(2000),PhanTramKhauHao int, NgaySuDung datetime, TaiKhoan varchar(20),
					 Nguon nvarchar(20) , MaPhongBanQL varchar(50), TenPhongBan nvarchar(500), NguyenGiaMua decimal(18,2), NguyenGiaTinhKhauHao decimal(18,2), 
					 LuyKeHaoMon decimal(18,2), LuyKeKH  decimal(18,2), LuyKe decimal(18,2),GiaTriConLai decimal(18,2), SoTienKhauHao decimal(18,2), Loai INT
					 ,SCL BIT)
insert into @TaiSanNew
select 
	TS.MaTSCDCaBiet , 
	TS.SoHieu , 
	TS.TenTaiSanCoDinh,
	TS.PhanTramKhauHao ,
	TS.NgaySuDung ,
	TS.TaiKhoan ,
	TS.Nguon, 
	TS.MaPhongBanQL ,
	TS.TenPhongBan , 
	TS.NguyenGiaMua , 
	TS.NguyenGiaTinhKhauHao , 
	TS.LuyKeHaoMon ,	
	(ISNULL(TS.LuyKeKH,0)-isnull(TongSCL.SoTienKH,0) - ISNULL(KHTruocDo.SoTienKH,0)) AS LuyKeKH ,
	0 as LuyKe,
	0 as GiaTriConLai,
	(ISNULL(KhauHaoTrongKy.SoTienKH,0) -isnull(SCLTrongKy.SoTienKH,0) )  as SoTienKhauHao,
	TS.Loai,
	0 AS SCL 
from @KQTSCD as TS left join @TongSCL as TongSCL on ts.MaTSCDCaBiet=TongSCL.MaTSCDCaBiet
left join @SCLTrongKy as SCLTrongKy on SCLTrongKy.MaTSCDCaBiet=TS.MaTSCDCaBiet
left join @KhauHaoTrongKy as KhauHaoTrongKy on KhauHaoTrongKy.MaTSCDCaBiet=TS.MaTSCDCaBiet
left join @TongKhauHao as KHTruocDo on KHTruocDo.MaTSCDCaBiet=TS.MaTSCDCaBiet
left join @TongSCLDenNgay as  SCLDenNgay on SCLDenNgay.MaTSCDCaBiet=TS.MaTSCDCaBiet
	
---------------tai san co dinh sua chua lon --------------
declare  @SCL table (MaTSCDCaBiet int, SoHieu varchar(50), TenTaiSanCoDinh nvarchar(2000),PhanTramKhauHao int, NgaySuDung datetime, TaiKhoan varchar(20),
					 Nguon nvarchar(20) , MaPhongBanQL varchar(50), TenPhongBan nvarchar(500), NguyenGiaMua decimal(18,2), NguyenGiaTinhKhauHao decimal(18,2), 
					 LuyKeHaoMon decimal(18,2), LuyKeKH  decimal(18,2), LuyKe decimal(18,2),GiaTriConLai decimal(18,2), SoTienKhauHao decimal(18,2), Loai int
					 )

insert into @SCL
	SELECT  
		d.MaTSCDCaBiet,
		d.SoHieu,
		e.TenTSCD,
		tblTiLeKhauHaoTheoTaiKhoan.PhanTram as KhauHaoNam,	
		a.NgayLap as NgaySuDung,
		tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK,
		case when d.NguonMua=0
		 then N'L'else N'DA' end NguonMua,			
		i.MaPhongBanNguoiDung,  
		i.TenPhongBan,
		sum(c.GiaTri) as NguyenGiaMua,                                                           		
		sum(c.GiaTri) as NguyenGiaTinhKhauHao,
		0 LuyKeHaoMon, 
		0 LuyKeKhauHao,	
		0 as  LuyKe,
		0 as NguyenGiaConLai,
		0 as SoTienKhauHao,
		4 as Loai   
	FROM    dbo.tblChungTu a                    
		inner join tblDoiTuongNghiepVu b on a.MaChungTu = b.MaChungTu                    
		LEFT JOIN v_BoSungDCPT c ON b.MaDoiTuong = c.MaNghiepVuSuaChuaLon                  
		LEFT JOIN tblNghiepVuSuaChuaLon g ON c.MaNghiepVuSuaChuaLon = g.MaNghiepVuSuaChuaLon             
		LEFT JOIN tblTaiSanCoDinhCaBiet d ON c.MaTSCDCaBiet = d.MaTSCDCaBiet
		inner join tblTiLeKhauHaoTheoTaiKhoan on tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK=d.TaiKhoanDoiUng            
		INNER JOIN tblTaiSanCoDinh e ON d.MaTSCD = e.MaTSCD                                    
		left OUTER JOIN tblDonViTinh f ON e.MaDonViTinh = f.MaDVT   
		INNER JOIN [PhongBan] as pb ON d.MaTSCDCaBiet = pb.MaTSCDCaBiet 
		INNER JOIN tblPhongBan i ON pb.MaPhongBan = i.MaPhongBan                                           
		LEFT JOIN [tblQuocGia] j ON e.[MaNuocSX] = j.[MaNuoc]				
	WHERE 		g.NgayThucHien  between '01/01/2011' and @NgayCuoiKy
			and (i.MaPhongBan=@MaPhongBan or @MaPhongBan=0)
			and tblTiLeKhauHaoTheoTaiKhoan.Nam=YEAR(@NgayCuaKy)
			AND c.MaTSCDCaBiet NOT IN (SELECT MaTSCDCaBiet FROM @DanhSachNhoHon30tr)
group by d.MaTSCDCaBiet,
		d.SoHieu,
		e.TenTSCD,
		tblTiLeKhauHaoTheoTaiKhoan.PhanTram ,	
		a.NgayLap,
		tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK,
		i.MaPhongBanNguoiDung,  
		i.TenPhongBan, d.NguonMua		
-------------			
insert into @TaiSanNew
select 
	TS.MaTSCDCaBiet , 
	TS.SoHieu , 
	TS.TenTaiSanCoDinh,
	TS.PhanTramKhauHao ,
	TS.NgaySuDung ,
	TS.TaiKhoan ,
	TS.Nguon, 
	TS.MaPhongBanQL ,
	TS.TenPhongBan , 
	TS.NguyenGiaMua , 
	TS.NguyenGiaTinhKhauHao , 
	TS.LuyKeHaoMon ,
	( ISNULL(TSCL.SoTienKH,0)) AS LuyKeKH , 
	(ISNULL(TS.LuyKe,0) + ISNULL(TSCL.SoTienKH,0)) AS LuyKe ,
	0 as GiaTriConLai,
	ISNULL(SCLTrongKy.SoTienKH,0) as SoTienKhauHao,
	TS.Loai, 
	1 AS SCL
from @SCL as TS left join @TongSCL as TSCL on ts.MaTSCDCaBiet=TSCL.MaTSCDCaBiet
left join @SCLTrongKy as SCLTrongKy on TS.MaTSCDCaBiet = SCLTrongKy.MaTSCDCaBiet



-----------------------khúc này tính riêng cho tài sản thanh lý--------------------------
 
-- lay tai san thannh ly 
 --declare @TSTL table (MaTSCDCaBiet int, SoTien decimal)
 --insert into @TSTL
 -- select MaTSCDCaBiet, sum(SoTien) from tblNghiepVuKhauHaoHaoMon
 --	where tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet not in(select MaTSCDCaBiet from @KQ)
 --	and DenKy between @TuKy and @DenKy
 --group by MaTSCDCaBiet	
 
  declare @TSTL table (MaTSCDCaBiet int, SoTien decimal, Loai int)
 insert into @TSTL
 select tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet, sum(SoTien),tblNghiepVuThanhLy.LoaiPhanBiet
	
  from tblNghiepVuKhauHaoHaoMon inner join tblTaiSanCoDinhCaBiet on tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet=tblTaiSanCoDinhCaBiet.MaTSCDCaBiet 
			inner join tblNghiepVuThanhLy on tblNghiepVuThanhLy.MaNghiepVuThanhLy=tblTaiSanCoDinhCaBiet.MaNghiepVuThanhLy
 	where  
 	tblTaiSanCoDinhCaBiet.NgayThanhLy between @NgayCuaKy and  @NgayCuoiKy
 	  and tblNghiepVuKhauHaoHaoMon.DenKy between  @TuKy and @DenKy
 group by tblNghiepVuKhauHaoHaoMon.MaTSCDCaBiet,tblNghiepVuThanhLy.LoaiPhanBiet	
 
 
 
 
 declare  @TaiSanThanLy table (MaTSCDCaBiet int, SoHieu varchar(50), TenTaiSanCoDinh nvarchar(2000),PhanTramKhauHao int, NgaySuDung datetime, TaiKhoan varchar(20),
					 Nguon nvarchar(20) , MaPhongBanQL varchar(50), TenPhongBan nvarchar(500), NguyenGiaMua decimal(18,2), NguyenGiaTinhKhauHao decimal(18,2), 
					 LuyKeHaoMon decimal(18,2), LuyKeKH  decimal(18,2), LuyKe decimal(18,2),GiaTriConLai decimal(18,2), SoTienKhauHao decimal(18,2), Loai int)
 
 insert into @TaiSanThanLy
 select  
		tblTaiSanCoDinhCaBiet.MaTSCDCaBiet,
		tblTaiSanCoDinhCaBiet.SoHieu,
		tblTaiSanCoDinh.TenTSCD,
		tblTiLeKhauHaoTheoTaiKhoan.PhanTram as KhauHaoNam,
		tblTaiSanCoDinhCaBiet.NgaySuDung,
		tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK,
		case when tblTaiSanCoDinhCaBiet.NguonMua=0
		 then N'L' else N'DA' end NguonMua,
		tblPhongBan.MaPhongBanNguoiDung,
		tblPhongBan.TenPhongBan,                                                 
		isnull(tblTaiSanCoDinhCaBiet.NguyenGiaMua,0),   
		isnull(tblTaiSanCoDinhCaBiet.NguyenGiaMua,0) as NguyenGiaTinhKhauHao,                  
		isnull(tblTaiSanCoDinhCaBiet.LuyKeHaoMon,0) , 
		isnull(tblTaiSanCoDinhCaBiet.LuyKeKhauHao,0) , 
		0 as LuyKe,
		0 as NguyenGiaConLai,
		ISNULL(TS.SoTien,0) as SoTienKH,
		LoaiPhanBiet as Loai
	from tblNghiepVuThanhLy inner join tblTaiSanCoDinhCaBiet on tblTaiSanCoDinhCaBiet.MaNghiepVuThanhLy=tblNghiepVuThanhLy.MaNghiepVuThanhLy
	inner join tblTaiSanCoDinh on tblTaiSanCoDinh.MaTSCD=tblTaiSanCoDinhCaBiet.MaTSCD
	inner join tblTiLeKhauHaoTheoTaiKhoan on tblTiLeKhauHaoTheoTaiKhoan.SoHieuTK=tblTaiSanCoDinhCaBiet.TaiKhoanDoiUng 
	LEFT JOIN [tblQuocGia]  ON tblTaiSanCoDinh.[MaNuocSX] = tblQuocGia.[MaNuoc]  -- ok        
	inner join v_DanhSachTaiSanMax on v_DanhSachTaiSanMax.MaTSCDCaBiet=tblTaiSanCoDinhCaBiet.MaTSCDCaBiet
	inner join tblPhongBan on v_DanhSachTaiSanMax.MaPhongBan=tblPhongBan.MaPhongBan  
	left join @TSTL as TS on TS.MaTSCDCaBiet=tblTaiSanCoDinhCaBiet.MaTSCDCaBiet
 	where tblTiLeKhauHaoTheoTaiKhoan.Nam=YEAR(@NgayCuaKy)
 	and (tblPhongBan.MaPhongBan=@MaPhongBan or @MaPhongBan=0)
 	and tblNghiepVuThanhLy.NgayThucHien between @NgayCuaKy and @NgayCuoiKy
	AND dbo.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet NOT IN (SELECT MaTSCDCaBiet FROM @DanhSachNhoHon30tr)
		 
declare  @ThanhLy table (MaTSCDCaBiet int, SoHieu varchar(50), TenTaiSanCoDinh nvarchar(2000),PhanTramKhauHao int, NgaySuDung datetime, TaiKhoan varchar(20),
					 Nguon nvarchar(20) , MaPhongBanQL varchar(50), TenPhongBan nvarchar(500), NguyenGiaMua decimal(18,2), NguyenGiaTinhKhauHao decimal(18,2), 
						 LuyKeHaoMon decimal(18,2), LuyKeKH  decimal(18,2), LuyKe decimal(18,2),GiaTriConLai decimal(18,2), SoTienKhauHao decimal(18,2), Loai int)
-----------------------------------	

					 
insert into @ThanhLy 
select 
	TL.MaTSCDCaBiet,
	SoHieu,
	TenTaiSanCoDinh,
	PhanTramKhauHao,	
	NgaySuDung,
	TaiKhoan,
	Nguon,
	MaPhongBanQL,                                                              
	TenPhongBan,
	NguyenGiaMua  ,
	NguyenGiaTinhKhauHao , 	
	LuyKeHaoMon,
	LuyKeKH  -ISNULL(KH.SoTienKH,0) as LuyKeKH,  
	0 as LuyKe,
	0 as  GiaTriConLai, 
	SoTienKhauHao - ISNULL(KH.SoTienKH,0) as SoTienKhauHao ,
	Loai 
from @TaiSanThanLy as TL left join @TongKhauHao as KH on TL.MaTSCDCaBiet=KH.MaTSCDCaBiet 


-- lay danh sach tai san thanh lý đổ vào bảng tài sản	 

insert into @TaiSanNew
select 
	TS.MaTSCDCaBiet , 
	TS.SoHieu , 
	TS.TenTaiSanCoDinh,
	TS.PhanTramKhauHao ,
	TS.NgaySuDung ,
	TS.TaiKhoan ,
	TS.Nguon, 
	TS.MaPhongBanQL ,
	TS.TenPhongBan , 
	TS.NguyenGiaMua , 
	TS.NguyenGiaTinhKhauHao , 
	TS.LuyKeHaoMon ,
	(ISNULL(TS.LuyKeKH,0) -ISNULL(scl.SoTienKH,0)) AS LuyKeKH ,
	(ISNULL(TS.LuyKe,0) -ISNULL(scl.SoTienKH,0)) AS LuyKe ,
	(ISNULL(TS.GiaTriConLai,0) +ISNULL(scl.SoTienKH,0)) AS GiaTriConLai , 
	ISNULL(TS.SoTienKhauHao,0) -ISNULL(scl.SoTienKH,0) as SoTienKhauHao,
	TS.Loai,
	0 AS SCL 
from @ThanhLy as TS left join @TongSCL as SCL on ts.MaTSCDCaBiet=SCL.MaTSCDCaBiet	 
		
 ------------kêt thúc tính riêng cho thanh lý-----------------------------
 	
 --------------- lấy lại kết quả theo 2 loại: 0 tài sản còn sử dung; 1 tài sản đã thanh lý---------------

 
 IF(@MucDichSuDung=1)-- TAI SAN BINH THUONG
 BEGIN
  select KQ.MaTSCDCaBiet,
   KQ.SoHieu , 
   KQ.TenTaiSanCoDinh ,
   KQ.PhanTramKhauHao, 
   KQ.NgaySuDung, 
   KQ.TaiKhoan, 
   KQ.Nguon,  
   KQ.MaPhongBanQL, 
   KQ.TenPhongBan,
	KQ.NguyenGiaTinhKhauHao, 
	KQ.NguyenGiaMua,
	KQ.NguyenGiaTinhKhauHao-KQ.LuyKeKH-KQ.LuyKeHaoMon as GiaTriConLai,	
	KQ.LuyKeKH,
	KQ.LuyKeHaoMon, 
	KQ.LuyKeKH+ KQ.LuyKeHaoMon as LuyKe, 
	KQ.SoTienKhauHao, 
	@NgayCuoiKy as DenNgay, @NgayCuaKy as TuNgay , case when Loai =4 then N'I. TÀI SẢN ĐANG CÒN SỬ DỤNG ĐẾN CUỐI KỲ BC'
													else '' end  as Loai,
	tblTaiKhoan.TenTaiKhoan
	from @TaiSanNew as KQ left join tblTaiKhoan on KQ.TaiKhoan=tblTaiKhoan.SoHieuTK
	where KQ.Loai=4
 order by  MaPhongBanQL,NgaySuDung,SoHieu asc
 END
 ELSE IF(@MucDichSuDung = 2) --TAI SAN THANH LY
 BEGIN
    select KQ.MaTSCDCaBiet,
   KQ.SoHieu , 
   KQ.TenTaiSanCoDinh ,
   KQ.PhanTramKhauHao, 
   KQ.NgaySuDung, 
   KQ.TaiKhoan, 
   KQ.Nguon,  
   KQ.MaPhongBanQL, 
   KQ.TenPhongBan,
	KQ.NguyenGiaTinhKhauHao, 
	KQ.NguyenGiaMua,
	KQ.NguyenGiaTinhKhauHao-KQ.LuyKeKH-KQ.LuyKeHaoMon as GiaTriConLai,	
	KQ.LuyKeKH,
	KQ.LuyKeHaoMon, 
	KQ.LuyKeKH+ KQ.LuyKeHaoMon as LuyKe, 
	KQ.SoTienKhauHao, 
	@NgayCuoiKy as DenNgay, @NgayCuaKy as TuNgay , case when Loai IN(0) then N'I. TRÍCH KHẤU HAO TÀI SẢN THANH LÝ TRONG KỲ BC'														
													else '' end  as Loai,
	tblTaiKhoan.TenTaiKhoan,
	Loai
	from @TaiSanNew as KQ left join tblTaiKhoan on KQ.TaiKhoan=tblTaiKhoan.SoHieuTK
	where  KQ.Loai IN (0)
	order by  MaPhongBanQL,NgaySuDung,SoHieu asc
 END
 ELSE if(@MucDichSuDung=3)-- dieu chuyen ngoai
 begin
  select KQ.MaTSCDCaBiet,
   KQ.SoHieu , 
   KQ.TenTaiSanCoDinh ,
   KQ.PhanTramKhauHao, 
   KQ.NgaySuDung, 
   KQ.TaiKhoan, 
   KQ.Nguon,  
   KQ.MaPhongBanQL, 
   KQ.TenPhongBan,
	KQ.NguyenGiaTinhKhauHao, 
	KQ.NguyenGiaMua,
	KQ.NguyenGiaTinhKhauHao-KQ.LuyKeKH-KQ.LuyKeHaoMon as GiaTriConLai,	
	KQ.LuyKeKH,
	KQ.LuyKeHaoMon, 
	KQ.LuyKeKH+ KQ.LuyKeHaoMon as LuyKe, 
	KQ.SoTienKhauHao, 
	@NgayCuoiKy as DenNgay, @NgayCuaKy as TuNgay , case when Loai =4 then N'I. TRÍCH KHẤU HAO - TÁCH TÀI SẢN HỆ THỐNG'
													else '' end  as Loai,
	tblTaiKhoan.TenTaiKhoan
	from @TaiSanNew as KQ left join tblTaiKhoan on KQ.TaiKhoan=tblTaiKhoan.SoHieuTK	
	where KQ.Loai IN (1)
 order by  MaPhongBanQL,NgaySuDung,SoHieu asc
 end
 ELSE if(@MucDichSuDung=4)-- tach he thong
 begin
  select KQ.MaTSCDCaBiet,
   KQ.SoHieu , 
   KQ.TenTaiSanCoDinh ,
   KQ.PhanTramKhauHao, 
   KQ.NgaySuDung, 
   KQ.TaiKhoan, 
   KQ.Nguon,  
   KQ.MaPhongBanQL, 
   KQ.TenPhongBan,
	KQ.NguyenGiaTinhKhauHao, 
	KQ.NguyenGiaMua,
	KQ.NguyenGiaTinhKhauHao-KQ.LuyKeKH-KQ.LuyKeHaoMon as GiaTriConLai,	
	KQ.LuyKeKH,
	KQ.LuyKeHaoMon, 
	KQ.LuyKeKH+ KQ.LuyKeHaoMon as LuyKe, 
	KQ.SoTienKhauHao, 
	@NgayCuoiKy as DenNgay, @NgayCuaKy as TuNgay , case when Loai =4 then N'I. TRÍCH KHẤU HAO - TÁCH TÀI SẢN HỆ THỐNG'
													else '' end  as Loai,
	tblTaiKhoan.TenTaiKhoan
	from @TaiSanNew as KQ left join tblTaiKhoan on KQ.TaiKhoan=tblTaiKhoan.SoHieuTK	
	where KQ.Loai IN (3)
 order by  MaPhongBanQL,NgaySuDung,SoHieu asc
 end
 
 ELSE 
 BEGIN
 
 
 
	  --cuong them vao de copy du lieu
	IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DuLieuBaoCaoPhucVuDoDuLieuPmTSMoi]') AND type in (N'U'))
		DROP TABLE [dbo].[DuLieuBaoCaoPhucVuDoDuLieuPmTSMoi]
		 select KQ.MaTSCDCaBiet,
	   KQ.SoHieu , 
	   KQ.TenTaiSanCoDinh ,
	   KQ.PhanTramKhauHao, 
	   KQ.NgaySuDung, 
	   KQ.TaiKhoan, 
	   KQ.Nguon,  
	   KQ.MaPhongBanQL, 
	   KQ.TenPhongBan,
		KQ.NguyenGiaTinhKhauHao, 
		KQ.NguyenGiaMua,
		KQ.NguyenGiaTinhKhauHao-KQ.LuyKeKH-KQ.LuyKeHaoMon as GiaTriConLai,	
		KQ.LuyKeKH,
		KQ.LuyKeHaoMon, 
		KQ.LuyKeKH+ KQ.LuyKeHaoMon as LuyKe, 
		KQ.SoTienKhauHao, 
		@NgayCuoiKy as DenNgay, @NgayCuaKy as TuNgay , case when Loai =4 then N'I. TÀI SẢN ĐANG CÒN SỬ DỤNG ĐẾN CUỐI KỲ BC'
															when Loai IN(0) then N'II. TRÍCH KHẤU HAO TÀI SẢN THANH LÝ TRONG KỲ BC'
															when Loai IN(1) then N'III. TRÍCH KHẤU HAO TÀI SẢN ĐIỀU CHUYỂN BÊN NGOÀI TRONG KỲ BC'
														else N'IV. TRÍCH KHẤU HAO - TÁCH TÀI SẢN HỆ THỐNG'end  as Loai,
		tblTaiKhoan.TenTaiKhoan,
		KQ.SCL
		INTO [DuLieuBaoCaoPhucVuDoDuLieuPmTSMoi]
		from @TaiSanNew as KQ left join tblTaiKhoan on KQ.TaiKhoan=tblTaiKhoan.SoHieuTK	
	 order by  MaPhongBanQL,NgaySuDung,SoHieu ASC
	 -----------------
     select KQ.MaTSCDCaBiet,
   KQ.SoHieu , 
   KQ.TenTaiSanCoDinh ,
   KQ.PhanTramKhauHao, 
   KQ.NgaySuDung, 
   KQ.TaiKhoan, 
   KQ.Nguon,  
   KQ.MaPhongBanQL, 
   KQ.TenPhongBan,
	KQ.NguyenGiaTinhKhauHao, 
	KQ.NguyenGiaMua,
	KQ.NguyenGiaTinhKhauHao-KQ.LuyKeKH-KQ.LuyKeHaoMon as GiaTriConLai,	
	KQ.LuyKeKH,
	KQ.LuyKeHaoMon, 
	KQ.LuyKeKH+ KQ.LuyKeHaoMon as LuyKe, 
	KQ.SoTienKhauHao, 
	@NgayCuoiKy as DenNgay, @NgayCuaKy as TuNgay , case when Loai =4 then N'I. TÀI SẢN ĐANG CÒN SỬ DỤNG ĐẾN CUỐI KỲ BC'
														when Loai IN(0) then N'II. TRÍCH KHẤU HAO TÀI SẢN THANH LÝ TRONG KỲ BC'
														when Loai IN(1) then N'III. TRÍCH KHẤU HAO TÀI SẢN ĐIỀU CHUYỂN BÊN NGOÀI TRONG KỲ BC'
													else N'IV. TRÍCH KHẤU HAO - TÁCH TÀI SẢN HỆ THỐNG'end  as Loai,
	tblTaiKhoan.TenTaiKhoan
	from @TaiSanNew as KQ left join tblTaiKhoan on KQ.TaiKhoan=tblTaiKhoan.SoHieuTK	
 order by  MaPhongBanQL,NgaySuDung,SoHieu asc
 END
 
 Commit                   
end       

