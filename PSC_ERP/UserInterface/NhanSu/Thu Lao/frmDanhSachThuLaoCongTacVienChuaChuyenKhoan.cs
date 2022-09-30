using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
//
namespace PSC_ERP
{
    public partial class frmDanhSachThuLaoCongTacVienChuaChuyenKhoan : Form
    {

        int userID = ERP_Library.Security.CurrentUser.Info.UserID;
        ThuLaoNhanVienNgoaiDaiList _ThuLaoChuongTrinhList, _thuLaoChuongTrinhKoGroup, _thuLaoChuongTrinhListUpdateDangPhi;
        public frmDanhSachThuLaoCongTacVienChuaChuyenKhoan()
        {
            InitializeComponent();
            ThuLaoLilst_bindingSource.DataSource = typeof(ThuLaoNhanVienNgoaiDaiList);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _thuLaoChuongTrinhKoGroup = ThuLaoNhanVienNgoaiDaiList.GetThuLaoChuongTrinhListByChuaChuyenKhoan_Modify(Convert.ToDateTime(dateTimePicker_TuNgay.Value), Convert.ToDateTime(dateTimePicker_DenNgay.Value), false);
            _ThuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.GetThuLaoChuongTrinhListByChuaChuyenKhoan_Modify(Convert.ToDateTime(dateTimePicker_TuNgay.Value), Convert.ToDateTime(dateTimePicker_DenNgay.Value), true);
            ThuLaoLilst_bindingSource.DataSource = _ThuLaoChuongTrinhList;
        }

        private void grdu_QuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.grdu_QuocGia.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 180;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Width = 120;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 1;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.Caption = "Nhập Hộ";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DuocNhapHo"].Header.VisiblePosition = 3;

        }

        private void grdu_QuocGia_Error(object sender, Infragistics.Win.UltraWinGrid.ErrorEventArgs e)
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

        private void grdu_QuocGia_DoubleClick(object sender, EventArgs e)
        {
            ThuLaoNhanVienNgoaiDaiList _list = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
            if (grdu_QuocGia.ActiveRow != null)
            {
                int maKyTinhLuong = (int)grdu_QuocGia.ActiveRow.Cells["MaKyTinhLuong"].Value;
                int maChuongTrinh = (int)grdu_QuocGia.ActiveRow.Cells["MaChuongTrinh"].Value;
                int maChiTietGiayXacNhan = (int)grdu_QuocGia.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value;
                //bool tinhDangPhi = (bool)grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"].Value;
                DateTime ngayLap = (DateTime)grdu_QuocGia.ActiveRow.Cells["NgayLap"].Value;
                int maGiayXacNhan = (int)grdu_QuocGia.ActiveRow.Cells["MaGiayXacNhan"].Value;
                KyTinhLuong _kyTinhLuong = KyTinhLuong.NewKyTinhLuong();
                _kyTinhLuong = KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);
                long maChiThuLao = (long)grdu_QuocGia.ActiveRow.Cells["MaChiThuLao"].Value;
                #region Modify
                foreach (ThuLaoNhanVienNgoaiDai tl in _thuLaoChuongTrinhKoGroup)
                {
                    if (tl.MaChuongTrinh == maChuongTrinh && tl.MaKyTinhLuong == maKyTinhLuong && tl.MaChiTietGiayXacNhan == maChiTietGiayXacNhan)
                    {
                        _list.Add(tl);
                    }
                }
                #endregion//Modify
                #region Old
                //_list = ThuLaoNhanVienNgoaiDaiList.GetThuLaoChuongTrinhListByPhieuChi(0, maChuongTrinh, maKyTinhLuong, "", maChiThuLao, maChiTietGiayXacNhan, true, ngayLap);
                #endregion//Old
                frmThuLaoCongTacVienChuaChuyenKhoan _frmThuLaoChuongTrinh = new frmThuLaoCongTacVienChuaChuyenKhoan(_list);
                _frmThuLaoChuongTrinh.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ThuLaoChuongTrinhList.Save();
        }


        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void báoCáoDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.rptThuLaoChuongTrinh();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_DanhSachThuLao_Report";
            command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTimePicker_TuNgay.Value));
            command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateTimePicker_DenNgay.Value));
            command.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_DanhSachThuLao_Report;1";
            //// store thu 2
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";

            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";

            dataset.Tables.Add(table1);
            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);
            Report.SetParameterValue("TenNguoiLap", "");
            Report.SetParameterValue("TenBPT", "");
            Report.SetParameterValue("TenThuTruong", "");
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void báoCáoChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTuNgayDenNgay f = new frmTuNgayDenNgay();
            f.ShowDialog(this);
            ReportDocument Report = new Report.rptDanhSachThuLaoChiTiet();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_ThuLaoChuongTrinhByNhanVien";
            command.Parameters.AddWithValue("@MaBoPhan", 0);
            command.Parameters.AddWithValue("@MaNhanVien", 0);
            command.Parameters.AddWithValue("@TuNgay", frmTuNgayDenNgay.TuNgay.Date);
            command.Parameters.AddWithValue("@DenNgay", frmTuNgayDenNgay.DenNgay.Date);
            command.Parameters.AddWithValue("@MaNguoiDangNhap", ERP_Library.Security.CurrentUser.Info.UserID);
            //command.Parameters.AddWithValue("@Denngay",Convert.ToDateTime(DateTime.Today));
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_ThuLaoChuongTrinhByNhanVien;1";

            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);
            Report.SetParameterValue("TenNguoiLap", "");
            Report.SetParameterValue("TenBPT", "");
            Report.SetParameterValue("TenThuTruong", "");
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void báoCáoĐảngPhíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChonKyTinhLuong f = new frmChonKyTinhLuong();
            f.ShowDialog(this);
            ReportDocument Report = new Report.ThuLaoChuongTrinh_DangPhi();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi";
            command.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            command.Parameters.AddWithValue("@TuKy", frmChonKyTinhLuong.maKyTinhLuongTuKy);
            command.Parameters.AddWithValue("@DenKy", frmChonKyTinhLuong.maKyTinhLuongDenKy);
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            //command.Parameters.AddWithValue("@Denngay",Convert.ToDateTime(DateTime.Today));
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi;1";

            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);
            Report.SetParameterValue("TenNguoiLap", "");
            Report.SetParameterValue("TenBPT", "");
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            try
            {
                _thuLaoChuongTrinhListUpdateDangPhi.Save();
                MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_QuocGia);
        }

        private void grdu_QuocGia_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //ThuLaoNhanVienNgoaiDaiList _list = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
            //if (grdu_QuocGia.ActiveRow != null)
            //{
            //    int maKyTinhLuong = (int)grdu_QuocGia.ActiveRow.Cells["MaKyTinhLuong"].Value;
            //    int maChuongTrinh = (int)grdu_QuocGia.ActiveRow.Cells["MaChuongTrinh"].Value;
            //    int maChiTietGiayXacNhan = (int)grdu_QuocGia.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value;
            //    //bool tinhDangPhi = (bool)grdu_QuocGia.ActiveRow.Cells["TinhDangPhi"].Value;
            //    DateTime ngayLap = (DateTime)grdu_QuocGia.ActiveRow.Cells["NgayLap"].Value;
            //    int maGiayXacNhan = (int)grdu_QuocGia.ActiveRow.Cells["MaGiayXacNhan"].Value;
            //    KyTinhLuong _kyTinhLuong = KyTinhLuong.NewKyTinhLuong();
            //    _kyTinhLuong = KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);
            //    long maChiThuLao = (long)grdu_QuocGia.ActiveRow.Cells["MaChiThuLao"].Value;
            //    foreach (ThuLaoNhanVienNgoaiDai tl in _ThuLaoChuongTrinhList)
            //    {
            //        if (tl.MaChuongTrinh == maChuongTrinh && tl.MaKyTinhLuong == maKyTinhLuong && tl.MaChiTietGiayXacNhan == maChiTietGiayXacNhan)
            //        {
            //            _list.Add(tl);
            //        }
            //    }
            //    frmThuLaoCongTacVienChuaChuyenKhoan _frmThuLaoChuongTrinh = new frmThuLaoCongTacVienChuaChuyenKhoan(_list);
            //    _frmThuLaoChuongTrinh.Show();
            //}
        }
    }
}
