BEGIN TRANSACTION
-- Add row to [dbo].[tblNhomHangHoa]
SET IDENTITY_INSERT [dbo].[tblNhomHangHoa] ON
INSERT INTO [dbo].[tblNhomHangHoa] ([MaNhomHangHoa], [MaQuanLy], [TenNhomHangHoa], [DienGiai], [TinhTrang], [MaLoaiVatTuHH], [MaNhomHangHoaCha]) VALUES (500, 'CCTS', N'CCDC chuyển từ tài sản 01/07/2013', N'', 1, 3, NULL)
SET IDENTITY_INSERT [dbo].[tblNhomHangHoa] OFF

COMMIT TRANSACTION

