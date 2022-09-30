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
namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmDanhSachKhenThuongTienMat_NgoaiDai : Form
    {

        ThuLaoNhanVienNgoaiDaiList _ThuLaoChuongTrinhList;
        public string maPhieuChi = string.Empty;
        public frmDanhSachKhenThuongTienMat_NgoaiDai()
        {
            InitializeComponent();
            ThuLaoLilst_bindingSource.DataSource = typeof(ThuLaoNhanVienNgoaiDaiList);
        }

        private void grdu_DanhSachTacQuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
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

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["MaPhieuChi"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["MaPhieuChi"].Header.Caption = "Mã Phiếu Chi";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["MaPhieuChi"].Width = 120;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["MaPhieuChi"].Header.VisiblePosition = 1;

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 100;

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Header.Caption = "Người Lập";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Header.VisiblePosition = 4;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Width = 100;

            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayChungTu"].Hidden = false;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayChungTu"].Header.Caption = "Ngày Chứng Từ";
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayChungTu"].Header.VisiblePosition = 4;
            grdu_DanhSachTacQuyen.DisplayLayout.Bands[0].Columns["NgayChungTu"].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ThuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.GetKhenThuongListByNgayLap(Convert.ToDateTime(dateTimePicker_TuNgay.Value), Convert.ToDateTime(dateTimePicker_DenNgay.Value), false);
            if (_ThuLaoChuongTrinhList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ThuLaoLilst_bindingSource.DataSource = _ThuLaoChuongTrinhList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBaoCaoThuLaoNgoaiDai f = new frmBaoCaoThuLaoNgoaiDai();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DanhSachTacQuyen);
        }

        private void grdu_DanhSachTacQuyen_DoubleClick(object sender, EventArgs e)
        {
            if (grdu_DanhSachTacQuyen.ActiveRow.IsActiveRow == true)
            {
                if (grdu_DanhSachTacQuyen.ActiveRow != null)
                {
                    int maKyTinhLuong = (int)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaKyTinhLuong"].Value;
                    int maChuongTrinh = (int)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaChuongTrinh"].Value;
                    int maChiTietGiayXacNhan = (int)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaChiTietGiayXacNhan"].Value;
                    maPhieuChi = (string)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaPhieuChi"].Value;
                    DateTime ngayLap = (DateTime)grdu_DanhSachTacQuyen.ActiveRow.Cells["NgayLap"].Value;
                    //bool thanhToan = (bool)grdu_DanhSachTacQuyen.ActiveRow.Cells["ThanhToan"].Value;
                    long maChiThuLao = (long)grdu_DanhSachTacQuyen.ActiveRow.Cells["MaChiThuLao"].Value;

                    KyTinhLuong _kyTinhLuong = KyTinhLuong.NewKyTinhLuong();
                    _kyTinhLuong = KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);

                    frmNhapKhenThuongTienMat_NgoaiDai  _frmNhapKhenThuongTienMat = new frmNhapKhenThuongTienMat_NgoaiDai(maKyTinhLuong, maChuongTrinh, maChiTietGiayXacNhan, maPhieuChi, ngayLap, maChiThuLao);
                    _frmNhapKhenThuongTienMat.Show();
                }
            }

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
            //command.Parameters.AddWithValue("@Denngay",Convert.ToDateTime(DateTime.Today));
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi;1";

            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();   
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
