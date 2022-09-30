--Thêm dữ liệu từ đơn vị tính cũ qua đơn vị tính cũ mới

SET IDENTITY_INSERT [dbo].[tblDonViTinh] ON
------------------------------------------------------1
INSERT INTO dbo.tblDonViTinh
        ( 
			MaDonViTinh ,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 101,N'Bao' , -- MaQuanLy - nvarchar(20)
          N'Bao' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        ) 
------------------------------------------------------2
INSERT INTO dbo.tblDonViTinh
        ( MaDonViTinh,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 102,N'Bon' , -- MaQuanLy - nvarchar(20)
          N'Bồn' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        )   
------------------------------------------------------3
INSERT INTO dbo.tblDonViTinh
        ( MaDonViTinh,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 103,N'Khoi' , -- MaQuanLy - nvarchar(20)
          N'Khối' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        )    
------------------------------------------------------4
INSERT INTO dbo.tblDonViTinh
        ( MaDonViTinh ,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 104,N'Khung' , -- MaQuanLy - nvarchar(20)
          N'Khung' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        )      
------------------------------------------------------5
INSERT INTO dbo.tblDonViTinh
        ( MaDonViTinh ,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 105,N'Lo' , -- MaQuanLy - nvarchar(20)
          N'Lô' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        ) 
------------------------------------------------------6
INSERT INTO dbo.tblDonViTinh
        ( MaDonViTinh ,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 106,N'May' , -- MaQuanLy - nvarchar(20)
          N'Máy' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        )  
------------------------------------------------------7
INSERT INTO dbo.tblDonViTinh
        ( MaDonViTinh ,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 107,N'PhanMen' , -- MaQuanLy - nvarchar(20)
          N'Phần Mền' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        )  
------------------------------------------------------8
INSERT INTO dbo.tblDonViTinh
        ( MaDonViTinh ,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 108,N'Quyen' , -- MaQuanLy - nvarchar(20)
          N'Quyển' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        )  
------------------------------------------------------9
INSERT INTO dbo.tblDonViTinh
        ( MaDonViTinh ,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 109,N'ThietBi' , -- MaQuanLy - nvarchar(20)
          N'Thiết Bị' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        )    
INSERT INTO dbo.tblDonViTinh
        ( MaDonViTinh ,MaQuanLy ,
          TenDonViTinh ,
          DienGiai ,
          MaTinhTrang
        )
VALUES  ( 110,N'Tru' , -- MaQuanLy - nvarchar(20)
          N'Trụ' , -- TenDonViTinh - nvarchar(100)
          NULL , -- DienGiai - nvarchar(500)
          1  -- MaTinhTrang - bit
        )       

SET IDENTITY_INSERT [dbo].[tblDonViTinh] OFF                                                                                                                                                                                            