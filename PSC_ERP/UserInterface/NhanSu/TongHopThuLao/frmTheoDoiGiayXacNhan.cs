using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Diagnostics;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP.UserInterface.NhanSu.TongHopThuLao
{
    public partial class frmTheoDoiGiayXacNhan : Form
    {
        #region
        GiayXacNhan_TrackingList _giayXacNhan_TrackingList = GiayXacNhan_TrackingList.NewGiayXacNhan_TrackingList();
        Util util = new Util();
        #endregion

        public frmTheoDoiGiayXacNhan()
        {
            InitializeComponent();
            this.GiayXacNhanTracking_BindingSource.DataSource = typeof(GiayXacNhan_TrackingList);
        }

        private void gridViewDanhSachGiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.CellActivation = Activation.NoEdit;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
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
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 0;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Width = 150;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Bộ Phận Gửi";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 1;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Width = 150;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.Caption = "Bộ Phận Nhận";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.VisiblePosition = 2;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Width = 150;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 3;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 150;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Nhập Hộ";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 4;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Width = 40;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 5;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaNhapNV"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaNhapNV"].Header.Caption = "Tiền NV";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaNhapNV"].Header.VisiblePosition = 6;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaNhapNV"].Width = 100;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVNgoaiDai"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVNgoaiDai"].Header.Caption = "Tiền NVNĐ";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVNgoaiDai"].Header.VisiblePosition = 7;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaNhapNVNgoaiDai"].Width = 100;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaDeNghiCK"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaDeNghiCK"].Header.Caption = "Tiền Đã ĐNCK";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaDeNghiCK"].Header.VisiblePosition = 10;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienDaDeNghiCK"].Width = 100;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienChuaDeNghiCK"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienChuaDeNghiCK"].Header.Caption = "Tiền Chưa ĐNCK";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienChuaDeNghiCK"].Header.VisiblePosition = 11;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienChuaDeNghiCK"].Width = 100;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Tiền Còn Lại";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 12;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 120;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLapGXN"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLapGXN"].Header.Caption = "Ngày Lập";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLapGXN"].Header.VisiblePosition = 13;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLapGXN"].Width = 80;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TinhTrang"].Header.Caption = "Hoàn Tất";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TinhTrang"].Header.VisiblePosition = 14;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["TinhTrang"].Width = 60;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 15;
            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 100;

            gridViewDanhSachGiayXacNhan.DisplayLayout.Bands[0].Columns["NgayLapGXN"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = Convert.ToDateTime(dateTimePicker_TuNgay.Value);
            DateTime denNgay = Convert.ToDateTime(dateTimePicker_DenNgay.Value);
            int userID = ERP_Library.Security.CurrentUser.Info.UserID;
            //Lấy danh sách giấy xác nhận
            _giayXacNhan_TrackingList = GiayXacNhan_TrackingList.GetGiayXacNhan_TrackingListByNgayLap_TheoDoiGiayXacNhan(userID, tuNgay, denNgay);
            GiayXacNhanTracking_BindingSource.DataSource = _giayXacNhan_TrackingList;
            if (_giayXacNhan_TrackingList.Count == 0)
            {
                MessageBox.Show(util.khongcodulieu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridViewDanhSachGiayXacNhan);
        }
    }
}