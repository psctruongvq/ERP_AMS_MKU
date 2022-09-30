﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmDanhSachTacQuyenATM_NgoaiDai : Form
    {

        ThuLaoNhanVienNgoaiDaiList _thuLaoNhanVienNgoaiDaiList;

        public frmDanhSachTacQuyenATM_NgoaiDai()
        {
            InitializeComponent();
        }

        private void grdu_DanhSachTacQuyen_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 180;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Width = 120;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 1;

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 100;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Header.Caption = "Người Lập";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Width = 100;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Header.VisiblePosition = 4;

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Nhập Hộ";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Width = 80;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 5;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            _thuLaoNhanVienNgoaiDaiList = ThuLaoNhanVienNgoaiDaiList.GetTacQuyenListByNgayLap(Convert.ToDateTime(dateTimePicker_TuNgay.Value), Convert.ToDateTime(dateTimePicker_DenNgay.Value), true);
            if (_thuLaoNhanVienNgoaiDaiList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            TacQuyenLilst_bindingSource.DataSource = _thuLaoNhanVienNgoaiDaiList;
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCaoThuLaoNgoaiDai f = new frmBaoCaoThuLaoNgoaiDai();
            f.Show();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DanhSachTacQuyen);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdu_DanhSachTacQuyen_Error(object sender, ErrorEventArgs e)
        {
            if (e.ErrorType == ErrorType.MultiCellOperation)
            {
                // Cancel the default error message
                e.Cancel = true;

                // e.MultiCellOperationErrorInfo returns the error information.
                // Build a custom error message for the user.
                System.Text.StringBuilder SB = new System.Text.StringBuilder();

                SB.AppendFormat("An error has occurred during the {0} operation", e.MultiCellOperationErrorInfo.Operation.ToString());
                SB.Append(Environment.NewLine);
                SB.Append("The error was as follows:");
                SB.Append(Environment.NewLine);
                SB.Append(Environment.NewLine);
                SB.AppendFormat("\"{0}\"", e.ErrorText);

                // Get the cell on which the error occurred
                UltraGridCell errorCell = e.MultiCellOperationErrorInfo.ErrorCell;

                // The ErrorCell will be null if the error was an error in the whole
                // operation as oppossed to an error no a single cell.
                if (errorCell != null)
                {
                    int rowIndex = errorCell.Row.Index;
                    string columnCaption = errorCell.Column.Header.Caption;

                    SB.Append(Environment.NewLine);
                    SB.AppendFormat("The error occurred on Row {0} in Column {1}", rowIndex, columnCaption);
                }

                MessageBox.Show(this, SB.ToString());
            }
        }

        private void grdu_DanhSachTacQuyen_DoubleClick(object sender, EventArgs e)
        {
            if (grdu_DanhSachTacQuyen.ActiveRow != null)
            {
                int maKyTinhLuong = (int)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaKyTinhLuong"].Value;
                int maChuongTrinh = (int)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaChuongTrinh"].Value;
                int maChiTietGiayXacNhan = (int)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value;
                string maPhieuChi = (string)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaPhieuChi"].Value;
                DateTime ngayLap = (DateTime)grdu_DanhSachTacQuyen.ActiveRow.Cells["NgayLap"].Value;
                long maChiThuLao = (long)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaChiThuLao"].Value;

                KyTinhLuong _kyTinhLuong = KyTinhLuong.NewKyTinhLuong();
                _kyTinhLuong = KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);

                if ((long)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaNhanVienTrongDai"].Value == 0)
                {
                    frmNhapTacQuyenATM_NgoaiDai _frmNhapTacQuyenATM = new frmNhapTacQuyenATM_NgoaiDai(maKyTinhLuong, maChuongTrinh, maChiTietGiayXacNhan, maPhieuChi, ngayLap, maChiThuLao);
                    _frmNhapTacQuyenATM.Show();
                }
            }
        }

  
    }
}
