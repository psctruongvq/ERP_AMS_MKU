using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using Infragistics.Documents.Excel;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmXuatChungTuGocRaExcel : Form
    {
        string path;
        SaveFileDialog saveFileDialog;
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        DataTable table = new DataTable();
        DateTime ngayBatDau;
        DateTime ngayKetThuc;
        BoPhan _boPhan = BoPhan.NewBoPhan();
        int userID = CurrentUser.Info.UserID;
        public frmXuatChungTuGocRaExcel()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            _boPhanList = BoPhanList.GetBoPhanListByUserID(userID);
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            boPhanListBindingSource.DataSource = _boPhanList;
        }

        private void cbu_BoPhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbu_BoPhan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cbu_BoPhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cbu_BoPhan.Width;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbu_BoPhan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        #region bt_Xem_Click
        private void bt_Xem_Click(object sender, EventArgs e)
        {
            ngayBatDau = Convert.ToDateTime(dtu_TuNgay.Value);
            ngayKetThuc = Convert.ToDateTime(dtu_DenNgay.Value);
            XuatDuLieuList _xuatDuLieuList = XuatDuLieuList.GetXuatDuLieuList(ngayBatDau, ngayKetThuc, _boPhan.MaBoPhan, ERP_Library.Security.CurrentUser.Info.UserID);
            bindingSource_XuatDuLieuExcel.DataSource = _xuatDuLieuList;
            ultraGrid_DuLieu.DataSource = bindingSource_XuatDuLieuExcel;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 1;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 100;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Header.Caption = "Nợ TK";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Header.VisiblePosition = 3;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Width = 70;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Header.Caption = "Có TK";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Header.VisiblePosition = 4;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Width = 70;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Header.Caption = "Số Tiền BT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Header.VisiblePosition = 5;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Width = 100;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Mục NS";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 6;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Width = 70;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Header.Caption = "Tiểu Mục NS";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Header.VisiblePosition = 7;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Width = 70;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.Caption = "SoTienTieuMuc";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.VisiblePosition = 8;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Width = 100;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Header.Caption = "Diễn Giải Mục";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Header.VisiblePosition = 9;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Width = 150;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Header.Caption = "Diễn Giải bt";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Header.VisiblePosition = 10;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Width = 150;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 11;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Tỷ Giá";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 12;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Width = 50;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 13;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Width = 100;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 14;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Header.Caption = "Loại CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Header.VisiblePosition = 15;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Width = 60;
            // co 
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCo"].Header.Caption = "Mã Đối Tượng Có";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCo"].Header.VisiblePosition = 16;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCo"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCo"].Header.Caption = "Tên Đối Tượng Có";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCo"].Header.VisiblePosition = 17;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCo"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCo"].Header.Caption = "ĐC Đối Tượng Có";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCo"].Header.VisiblePosition = 18;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCo"].Width = 80;
            //nọ
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongNo"].Header.Caption = "Mã Đối Tượng Nợ";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongNo"].Header.VisiblePosition = 19;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongNo"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongNo"].Header.Caption = "Tên Đối Tượng Nợ";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongNo"].Header.VisiblePosition = 20;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongNo"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongNo"].Header.Caption = "ĐC Đối Tượng Nợ";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongNo"].Header.VisiblePosition = 21;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongNo"].Width = 80;
            //chung tu

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCT"].Header.Caption = "Mã Đối Tượng CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCT"].Header.VisiblePosition = 22;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCT"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCT"].Header.Caption = "Tên Đối Tượng CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCT"].Header.VisiblePosition = 23;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCT"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCT"].Header.Caption = "ĐC Đối Tượng CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCT"].Header.VisiblePosition = 24;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCT"].Width = 80;

            //==================bo sung 19/03/2018=================
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTKNganHang"].Header.Caption = "Số TK Ngân hàng";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTKNganHang"].Header.VisiblePosition = 25;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTKNganHang"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaDonViQL"].Header.Caption = "Mã Đơn Vị";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaDonViQL"].Header.VisiblePosition = 26;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaDonViQL"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDonVi"].Header.Caption = "Tên Đơn Vị";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDonVi"].Header.VisiblePosition = 27;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDonVi"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaKhoanMucQL"].Header.Caption = "Mã Khoản Mục";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaKhoanMucQL"].Header.VisiblePosition = 28;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaKhoanMucQL"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenKhoanMuc"].Header.Caption = "Tên Khoản Mục";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenKhoanMuc"].Header.VisiblePosition = 29;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenKhoanMuc"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.Caption = "Số Hợp Đồng";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.VisiblePosition = 30;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHopDong"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoBienLai"].Header.Caption = "Số Biên Lai";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoBienLai"].Header.VisiblePosition = 31;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoBienLai"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["BillSeries"].Header.Caption = "Số seri";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["BillSeries"].Header.VisiblePosition = 32;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["BillSeries"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NamHoc"].Header.Caption = "Năm Học";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NamHoc"].Header.VisiblePosition = 33;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NamHoc"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 34;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 100;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["KHNgoai"].Header.Caption = "Tên người nhận";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["KHNgoai"].Header.VisiblePosition = 35;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCNgoai"].Header.Caption = "ĐC người nhận";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCNgoai"].Header.VisiblePosition = 36;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Bộ Phận";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 37;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.Caption = "Người Lâp";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.VisiblePosition = 38;

        }
        #endregion

        #region cbu_BoPhan_ValueChanged
        private void cbu_BoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cbu_BoPhan.Value != null)
            {
                _boPhan = BoPhan.GetBoPhan(Convert.ToInt32(cbu_BoPhan.Value));
            }
        }
        #endregion

        private void ultraGrid_DuLieu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {  
            foreach (UltraGridColumn col in this.ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.Hidden = true;

                //col.CellActivation = Activation.AllowEdit;
                //col.CellClickAction = CellClickAction.RowSelect;
            }
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 1;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 100;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Header.Caption = "Nọ TK";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Header.VisiblePosition = 3;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Width = 70;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Header.Caption = "Có TK";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Header.VisiblePosition = 4;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Width = 70;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Header.Caption = "Số Tiền BT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Header.VisiblePosition = 5;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Width = 100;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Hidden = false;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Mục NS";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 6;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Width = 70;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Hidden = false;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Header.Caption = "Tiểu Mục NS";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Header.VisiblePosition = 7;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Width = 70;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Hidden = false;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.Caption = "SoTienTieuMuc";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.VisiblePosition = 8;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Width = 100;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Hidden = false;

            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Header.Caption = "Diễn Giải Mục";
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Header.VisiblePosition = 9;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Width = 150;
            //ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Header.Caption = "Diễn Giải bt";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Header.VisiblePosition = 10;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Width = 150;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 11;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Tỷ Giá";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 12;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Width = 50;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 13;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Width = 100;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 14;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Header.Caption = "Loại CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Header.VisiblePosition = 15;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Width = 60;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Hidden = false;
            // co 
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCo"].Header.Caption = "Mã Đối Tượng Có";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCo"].Header.VisiblePosition = 16;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCo"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCo"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCo"].Header.Caption = "Tên Đối Tượng Có";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCo"].Header.VisiblePosition = 17;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCo"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCo"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCo"].Header.Caption = "ĐC Đối Tượng Có";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCo"].Header.VisiblePosition = 18;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCo"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCo"].Hidden = false;
            //nọ
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongNo"].Header.Caption = "Mã Đối Tượng Nợ";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongNo"].Header.VisiblePosition = 19;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongNo"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongNo"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongNo"].Header.Caption = "Tên Đối Tượng Nợ";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongNo"].Header.VisiblePosition = 20;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongNo"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongNo"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongNo"].Header.Caption = "ĐC Đối Tượng Nợ";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongNo"].Header.VisiblePosition = 21;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongNo"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongNo"].Hidden = false;
            //chung tu

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCT"].Header.Caption = "Mã Đối Tượng CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCT"].Header.VisiblePosition = 22;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCT"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaQLDoiTuongCT"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCT"].Header.Caption = "Tên Đối Tượng CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCT"].Header.VisiblePosition = 23;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCT"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDoiTuongCT"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCT"].Header.Caption = "ĐC Đối Tượng CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCT"].Header.VisiblePosition = 24;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCT"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCDoiTuongCT"].Hidden = false;

            //==================bo sung 19/03/2018=================
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTKNganHang"].Header.Caption = "Số TK Ngân Hàng";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTKNganHang"].Header.VisiblePosition = 25;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTKNganHang"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTKNganHang"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaDonViQL"].Header.Caption = "Mã Đơn Vị";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaDonViQL"].Header.VisiblePosition = 25;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaDonViQL"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaDonViQL"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDonVi"].Header.Caption = "Tên Đơn Vị";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDonVi"].Header.VisiblePosition = 26;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDonVi"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDonVi"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaKhoanMucQL"].Header.Caption = "Mã Khoản Mục";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaKhoanMucQL"].Header.VisiblePosition = 27;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaKhoanMucQL"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaKhoanMucQL"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenKhoanMuc"].Header.Caption = "Tên Khoản Mục";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenKhoanMuc"].Header.VisiblePosition = 28;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenKhoanMuc"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenKhoanMuc"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.Caption = "Số Hợp Đồng";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.VisiblePosition = 29;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHopDong"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHopDong"].Hidden = false;
            //============================
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoBienLai"].Header.Caption = "Số Biên Lai";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoBienLai"].Header.VisiblePosition = 30;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoBienLai"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoBienLai"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["BillSeries"].Header.Caption = "Số seri";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["BillSeries"].Header.VisiblePosition = 31;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["BillSeries"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["BillSeries"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NamHoc"].Header.Caption = "Năm Học";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NamHoc"].Header.VisiblePosition = 32;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NamHoc"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NamHoc"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 33;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 80;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["KHNgoai"].Header.Caption = "Tên người nhận";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["KHNgoai"].Header.VisiblePosition = 34;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["KHNgoai"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCNgoai"].Header.Caption = "ĐC người nhận";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCNgoai"].Header.VisiblePosition = 35;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DCNgoai"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Bộ Phận";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 36;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.Caption = "Người Lâp";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.VisiblePosition = 37;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDangNhap"].Hidden = false;
        }

        private void sồSáchBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid_DuLieu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid_DuLieu);
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultraGrid_DuLieu_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            ViewChungTu();
            #region view chung tu
            //XuatDuLieu obj = (XuatDuLieu)bindingSource_XuatDuLieuExcel.Current;
            //           if (obj == null)
            //               return;

            //           long maChungTu = obj.MaChungTu;
            //           int maLoaiChungTu = obj.IntMaLoaiChungTu;

            //           switch (maLoaiChungTu)
            //           {
            //               case 2:
            //                   //PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu,isShowFromReport);
            //                   PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu);
            //                   //frm.maChungTuOfReport = maChungTu;
            //                   //frm.isShowFromReport = isShowFromReport;
            //                   frm.WindowState = FormWindowState.Maximized;
            //                   frm.ShowDialog();
            //                   break;

            //               case 3:
            //                   PSC_ERP.FrmChungTuChiTienMat frm3 = new PSC_ERP.FrmChungTuChiTienMat(maChungTu);
            //                   frm3.WindowState = FormWindowState.Maximized;
            //                   frm3.ShowDialog();
            //                   break;

            //               case 4:
            //                   PSC_ERP.frmPhieuNhapVatTuHangHoa_New frm4 = new PSC_ERP.frmPhieuNhapVatTuHangHoa_New(maChungTu);
            //                   frm4.WindowState = FormWindowState.Maximized;
            //                   frm4.ShowDialog();
            //                   break;

            //               case 5:
            //                   PSC_ERP.FrmPhieuXuatVatTuHangHoa_New frm5 = new PSC_ERP.FrmPhieuXuatVatTuHangHoa_New(maChungTu, 1);
            //                   frm5.WindowState = FormWindowState.Maximized;
            //                   frm5.ShowDialog();
            //                   break;

            //               case 6:
            //                   PSC_ERP.FrmChungTuThuTienGui frm6 = new PSC_ERP.FrmChungTuThuTienGui(maChungTu);
            //                   frm6.WindowState = FormWindowState.Maximized;
            //                   frm6.ShowDialog();
            //                   break;

            //               case 7:
            //                   PSC_ERP.FrmChungTuChiTienGui frm7 = new PSC_ERP.FrmChungTuChiTienGui(maChungTu);
            //                   frm7.WindowState = FormWindowState.Maximized;
            //                   frm7.ShowDialog();
            //                   break;

            //               case 8:
            //                   PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD frm8 = new PSC_ERP.FrmChungTuKetChuyenXacDinhKQHDKD(maChungTu);
            //                   frm8.WindowState = FormWindowState.Maximized;
            //                   frm8.ShowDialog();
            //                   break;

            //               case 9:
            //                   PSC_ERP.FrmChungTuMuaChuaThanhToan frm9 = new PSC_ERP.FrmChungTuMuaChuaThanhToan(maChungTu);
            //                   frm9.WindowState = FormWindowState.Maximized;
            //                   frm9.ShowDialog();
            //                   break;

            //               case 10:
            //                   PSC_ERP.FrmChungTuGiayNhanNo frm10 = new PSC_ERP.FrmChungTuGiayNhanNo(maChungTu);
            //                   frm10.WindowState = FormWindowState.Maximized;
            //                   frm10.ShowDialog();
            //                   break;

            //               case 14:
            //                   PSC_ERP.FrmChungTuChuyenTienNoiBo frm14 = new PSC_ERP.FrmChungTuChuyenTienNoiBo(maChungTu);
            //                   frm14.WindowState = FormWindowState.Maximized;
            //                   frm14.ShowDialog();
            //                   break;

            //               case 16:
            //                   PSC_ERP.FrmChungTuKeToanCustomize frm16 = new PSC_ERP.FrmChungTuKeToanCustomize(maChungTu);
            //                   frm16.WindowState = FormWindowState.Maximized;
            //                   frm16.ShowDialog();
            //                   break;

            //               case 22:
            //                   PSC_ERP.FrmChungTuPhiNganHang frm22 = new PSC_ERP.FrmChungTuPhiNganHang(maChungTu);
            //                   frm22.WindowState = FormWindowState.Maximized;
            //                   frm22.ShowDialog();
            //                   break;

            //               case 23:
            //                   PSC_ERP.FrmChungTuMuaNgoaiTe frm23 = new PSC_ERP.FrmChungTuMuaNgoaiTe(maChungTu);
            //                   frm23.WindowState = FormWindowState.Maximized;
            //                   frm23.ShowDialog();
            //                   break;

            //               case 24:
            //                   PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai frm24 = new PSC_ERP.FrmChungTuLenhChuyenTienNuocNgoai(maChungTu);
            //                   frm24.WindowState = FormWindowState.Maximized;
            //                   frm24.ShowDialog();
            //                   break;

            //               case 25:
            //                   PSC_ERP.FrmChungTuGiayRutTienMat frm25 = new PSC_ERP.FrmChungTuGiayRutTienMat(maChungTu);
            //                   frm25.WindowState = FormWindowState.Maximized;
            //                   frm25.ShowDialog();
            //                   break;


            //               default:
            //                   MessageBox.Show("Không tìm thấy form chứng từ");
            //                   break;
            //           }
            #endregion
        }

        private void ultraGrid_DuLieu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ViewChungTu();
            }
        }

        private void ViewChungTu()
        {
            XuatDuLieu obj = (XuatDuLieu)bindingSource_XuatDuLieuExcel.Current;
            if (obj == null)
                return;

            long maChungTu = obj.MaChungTu;
            int maLoaiChungTu = obj.IntMaLoaiChungTu;

            switch (maLoaiChungTu)
            {
                case 2:
                    //PSC_ERP.FrmChungTuThuTienMat frm = new PSC_ERP.FrmChungTuThuTienMat(maChungTu,isShowFromReport);
                    FrmChungTuThuTienMat frm = new FrmChungTuThuTienMat(maChungTu);
                    //frm.maChungTuOfReport = maChungTu;
                    //frm.isShowFromReport = isShowFromReport;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                    break;

                case 3:
                    FrmChungTuChiTienMat frm3 = new FrmChungTuChiTienMat(maChungTu);
                    frm3.WindowState = FormWindowState.Maximized;
                    frm3.ShowDialog();
                    break;

                case 4:
                    frmPhieuNhapVatTuHangHoa_New frm4 = new frmPhieuNhapVatTuHangHoa_New(maChungTu);
                    frm4.WindowState = FormWindowState.Maximized;
                    frm4.ShowDialog();
                    break;

                case 5:
                    FrmPhieuXuatVatTuHangHoa_New frm5 = new FrmPhieuXuatVatTuHangHoa_New(maChungTu, 1);
                    frm5.WindowState = FormWindowState.Maximized;
                    frm5.ShowDialog();
                    break;

                case 6:
                    FrmChungTuThuTienGui frm6 = new FrmChungTuThuTienGui(maChungTu);
                    frm6.WindowState = FormWindowState.Maximized;
                    frm6.ShowDialog();
                    break;

                case 7:
                    FrmChungTuChiTienGui frm7 = new FrmChungTuChiTienGui(maChungTu);
                    frm7.WindowState = FormWindowState.Maximized;
                    frm7.ShowDialog();
                    break;

                case 8:
                    FrmChungTuKetChuyenXacDinhKQHDKD frm8 = new FrmChungTuKetChuyenXacDinhKQHDKD(maChungTu);
                    frm8.WindowState = FormWindowState.Maximized;
                    frm8.ShowDialog();
                    break;

                case 9:
                    FrmChungTuMuaChuaThanhToan frm9 = new FrmChungTuMuaChuaThanhToan(maChungTu);
                    frm9.WindowState = FormWindowState.Maximized;
                    frm9.ShowDialog();
                    break;

                case 10:
                    FrmChungTuGiayNhanNo frm10 = new FrmChungTuGiayNhanNo(maChungTu);
                    frm10.WindowState = FormWindowState.Maximized;
                    frm10.ShowDialog();
                    break;

                case 14:
                    FrmChungTuChuyenTienNoiBo frm14 = new FrmChungTuChuyenTienNoiBo(maChungTu);
                    frm14.WindowState = FormWindowState.Maximized;
                    frm14.ShowDialog();
                    break;

                case 16:
                    FrmChungTuKeToanCustomize frm16 = new FrmChungTuKeToanCustomize(maChungTu);
                    frm16.WindowState = FormWindowState.Maximized;
                    frm16.ShowDialog();
                    break;

                case 22:
                    FrmChungTuPhiNganHang frm22 = new FrmChungTuPhiNganHang(maChungTu);
                    frm22.WindowState = FormWindowState.Maximized;
                    frm22.ShowDialog();
                    break;

                case 23:
                    FrmChungTuMuaNgoaiTe frm23 = new FrmChungTuMuaNgoaiTe(maChungTu);
                    frm23.WindowState = FormWindowState.Maximized;
                    frm23.ShowDialog();
                    break;

                case 24:
                    FrmChungTuLenhChuyenTienNuocNgoai frm24 = new FrmChungTuLenhChuyenTienNuocNgoai(maChungTu);
                    frm24.WindowState = FormWindowState.Maximized;
                    frm24.ShowDialog();
                    break;

                case 25:
                    FrmChungTuGiayRutTienMat frm25 = new FrmChungTuGiayRutTienMat(maChungTu);
                    frm25.WindowState = FormWindowState.Maximized;
                    frm25.ShowDialog();
                    break;


                default:
                    MessageBox.Show("Không tìm thấy form chứng từ");
                    break;
            }
        }

    }
}
