using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmGiayXacNhan_DeNghiChuyenKhoan : Form
    {
        GiayXacNhan_TrackingList _list;
        public frmGiayXacNhan_DeNghiChuyenKhoan()
        {
            InitializeComponent();
            this.GiayXacNhanTracking_bindingSourceList.DataSource = typeof(GiayXacNhan_TrackingList);
        }
        public frmGiayXacNhan_DeNghiChuyenKhoan(string maPhieuStr)
        {
            InitializeComponent();
            _list = GiayXacNhan_TrackingList.GetGiayXacNhan_TrackingListByDeNghiChuyenKhoan(maPhieuStr);
            this.GiayXacNhanTracking_bindingSourceList.DataSource = _list;
        }
        public frmGiayXacNhan_DeNghiChuyenKhoan(string maPhieuStr, int so)
        {
            InitializeComponent();
            _list = GiayXacNhan_TrackingList.GetGiayXacNhan_TrackingListByDeNghiChuyenKhoanByNhanVien(maPhieuStr);
            this.GiayXacNhanTracking_bindingSourceList.DataSource = _list;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGiayXacNhan_DeNghiChuyenKhoan_Load(object sender, EventArgs e)
        {

        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultraGrid1);
        }

        private void ultraGrid1_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.CellActivation = Activation.NoEdit;
                if (col.DataType == typeof(DateTime))
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType == typeof(decimal))
                {
                    col.Format = "###,###,###,###,###";
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";

            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";

            ultraGrid1.DisplayLayout.Bands[0].Columns["MST"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MST"].Header.Caption = "MST";


            ultraGrid1.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 0;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Bộ Phận Gửi";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 1;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.Caption = "Bộ Phận Nhận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.VisiblePosition = 2;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 3;
            ultraGrid1.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Nhập Hộ";
            ultraGrid1.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 4;

            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Tiền Trước Thuế";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 5;

            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            ultraGrid1.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 6;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TienThue"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TienThue"].Header.Caption = "Tiền Thuế";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TienThue"].Header.VisiblePosition = 6;
        }
    }
}
