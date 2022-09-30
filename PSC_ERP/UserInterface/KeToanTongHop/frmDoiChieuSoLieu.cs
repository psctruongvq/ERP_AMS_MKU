using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmDoiChieuSoLieu : Form
    {
        string path;
        SaveFileDialog saveFileDialog;
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        DataTable table = new DataTable();
        DateTime ngayBatDau;
        DateTime ngayKetThuc;
        BoPhan _boPhan = BoPhan.NewBoPhan();
        int userID = CurrentUser.Info.UserID;
        public frmDoiChieuSoLieu()
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
            XuatDuLieuList _xuatDuLieuList = XuatDuLieuList.KiemTraSoLieuCacBan(ngayBatDau, ngayKetThuc, _boPhan.MaBoPhan,ERP_Library.Security.CurrentUser.Info.UserID);
            foreach (UltraGridColumn col in this.ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            bindingSource_XuatDuLieuExcel.DataSource = _xuatDuLieuList;
            ultraGrid_DuLieu.DataSource = bindingSource_XuatDuLieuExcel;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 1;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 80;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Header.Caption = "Nọ TK";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Header.VisiblePosition = 2;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKNO"].Width = 70;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Header.Caption = "Có TK";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Header.VisiblePosition = 3;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TKCo"].Width = 70;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Header.Caption = "Số Tiền BT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Header.VisiblePosition = 4;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienBT"].Width = 100;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.Caption = "SoTienTieuMuc";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Header.VisiblePosition = 5;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTienTieuMuc"].Width = 100;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền Xác Nhận";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 6;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.Caption = "Số Tiền Còn Lai";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Header.VisiblePosition = 7;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TiGiaQuyDoi"].Width = 50;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Số Tiền Đã Nhập";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 8;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["ThanhTien"].Width = 100;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Mục NS";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 9;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Width = 70;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Hidden = false; 
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Header.Caption = "Tiểu Mục NS";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Header.VisiblePosition = 10;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaTieuMuc"].Width = 70;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Header.Caption = "Diễn Giải Mục";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Header.VisiblePosition = 11;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiMuc"].Width = 150;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Header.Caption = "Diễn Giải bt";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Header.VisiblePosition = 12;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["DienGiaiBT"].Width = 150;


            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Header.Caption = "Loại CT";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Header.VisiblePosition = 13;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["MaLoaiChungTu"].Width = 60;

            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Bộ Phận Gởi";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 14;
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.Caption = "Người Lâp";
            ultraGrid_DuLieu.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.VisiblePosition = 15;


            
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
            }
        }

        private void sồSáchBáoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid_DuLieu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid_DuLieu);
        }
    }
}
