--Thêm dữ liệu từ quốc gia cũ qua quốc gia mới

SET IDENTITY_INSERT [dbo].[tblQuocGia] ON
------------------------------------------------------1
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 101,'India' , -- MaQuocGiaQuanLy - varchar(20)
          N'Ấn Độ' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        ) 
------------------------------------------------------2
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 102,'Asia' , -- MaQuocGiaQuanLy - varchar(20)
          N'Asia' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )   
------------------------------------------------------3
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 103,'B' , -- MaQuocGiaQuanLy - varchar(20)
          N'Bỉ' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        ) 
------------------------------------------------------4
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 104,'Canada' , -- MaQuocGiaQuanLy - varchar(20)
          N'Canada' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )   
------------------------------------------------------5
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 105,'Europe' , -- MaQuocGiaQuanLy - varchar(20)
          N'Châu Âu' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )  
------------------------------------------------------6
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 106,'Costa' , -- MaQuocGiaQuanLy - varchar(20)
          N'Costa Rica' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )   
------------------------------------------------------7
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 107,'F' , -- MaQuocGiaQuanLy - varchar(20)
          N'Finland' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )   
------------------------------------------------------8
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 108,'Indo' , -- MaQuocGiaQuanLy - varchar(20)
          N'Indonesia' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )    
------------------------------------------------------9
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 109,'Ire ' , -- MaQuocGiaQuanLy - varchar(20)
          N'Ireland' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )    
------------------------------------------------------10
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 110,'Israe' , -- MaQuocGiaQuanLy - varchar(20)
          N'Israel' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )      
------------------------------------------------------11
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 111,'Panorama' , -- MaQuocGiaQuanLy - varchar(20)
          N'Panorama' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )     
------------------------------------------------------12
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 112,'Philip' , -- MaQuocGiaQuanLy - varchar(20)
          N'Philippine' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )    
------------------------------------------------------13
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 113,'PL' , -- MaQuocGiaQuanLy - varchar(20)
          N'Poland' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )      
------------------------------------------------------14
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 114,'Sing' , -- MaQuocGiaQuanLy - varchar(20)
          N'Singapore' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )            
------------------------------------------------------15
INSERT INTO dbo.tblQuocGia
        ( MaQuocGia,MaQuocGiaQuanLy ,
          TenQuocGia ,
          TenVietTat ,
          DienGiai
        )
VALUES  ( 115,'Switzerlan' , -- MaQuocGiaQuanLy - varchar(20)
          N'Thụy Sĩ' , -- TenQuocGia - nvarchar(500)
          NULL , -- TenVietTat - varchar(50)
          NULL  -- DienGiai - nvarchar(500)
        )  
---
SET IDENTITY_INSERT [dbo].[tblQuocGia] OFF                                                                                                                                                             