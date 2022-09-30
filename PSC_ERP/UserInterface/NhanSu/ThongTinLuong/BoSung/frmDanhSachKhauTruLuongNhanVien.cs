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

namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmDanhSachKhauTruLuongNhanVien : Form
    {
        frmTinhDangPhi frm = new frmTinhDangPhi();
        PhuCapNhanVienList _PhuCapNhanVienList;

        #region Bo Sung MaLoai Chi

        int _maLoaiChi = 0;

        #region Constructors

        public void ShowKhenThuong()
        {
            _maLoaiChi = 2;//Chi Khen Thuong
            this.Text = "Danh Sách Khen Thưởng Nhân Viên - Tiền Mặt - Trong Đài";
            this.Show();
        }

        public void ShowPhuCap()
        {
            _maLoaiChi = 4;//Chi Thu Lao
            this.Text = "Danh Sách Phụ Cấp Nhân Viên - Tiền Mặt";
            this.Show();
        }

        public void ShowTruyLinh()
        {
            _maLoaiChi = 5;//Truy Linh
            this.Text = "Danh Sách Truy Lĩnh Nhân Viên - Tiền Mặt";
            this.Show();
        }

        public void ShowTruyThu()
        {
            _maLoaiChi = 6;//Truy Thu
            this.Text = "Danh Sách Truy Thu Nhân Viên - Tiền Mặt";
            this.Show();
        }

        #endregion
        #endregion

        public frmDanhSachKhauTruLuongNhanVien()
        {
            InitializeComponent();
            PhuCapNhanVienList_bindingSource.DataSource = typeof(PhuCapNhanVienList);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker_DenNgay_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _PhuCapNhanVienList = PhuCapNhanVienList.GetNhapPhuCapListByNgay_CacKhoanTruLuong(Convert.ToDateTime(dateTimePicker_TuNgay.Value), Convert.ToDateTime(dateTimePicker_DenNgay.Value));
            PhuCapNhanVienList_bindingSource.DataSource = _PhuCapNhanVienList;
            if (_PhuCapNhanVienList.Count == 0)
            {
                MessageBox.Show("Danh sách rỗng!");
            }
        }

        private void grdu_QuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
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
            if (grdu_QuocGia.ActiveRow != null)
            {
                if (grdu_QuocGia.ActiveRow.IsFilterRow != true)
                {
                    int maKyTinhLuong = (int)grdu_QuocGia.ActiveRow.Cells["MaKyTinhLuong"].Value;
                    int maLoaiPhuCap = (int)grdu_QuocGia.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                    string SoQuyetDinh = (string)grdu_QuocGia.ActiveRow.Cells["SoQuyetDinh"].Value;
                    string MaPhieuChi = (string)grdu_QuocGia.ActiveRow.Cells["MaPhieuChi"].Value;
                    long maChiThuLao = (long)grdu_QuocGia.ActiveRow.Cells["MaChiThuLao"].Value;
                    DateTime ngaylap = (DateTime)grdu_QuocGia.ActiveRow.Cells["NgayLap"].Value;
                    frmKhauTruLuongNhanVien _frmKhauTruLuongNhanVien = new frmKhauTruLuongNhanVien(maKyTinhLuong, maLoaiPhuCap, SoQuyetDinh,ngaylap);
                    _frmKhauTruLuongNhanVien.Show();
                }                
            }
        }

      

        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdu_QuocGia_DoubleClick(null, null);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //ReportDocument Report = new Report.rptThuLaoChuongTrinh();
            //SqlCommand command = new SqlCommand();
            //DataSet dataset = new DataSet();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "spd_DanhSachThuLao_Report";
            //command.Parameters.AddWithValue("@TuNgay", dateTimePicker_TuNgay.Value.Date);
            //command.Parameters.AddWithValue("@DenNgay", dateTimePicker_DenNgay.Value.Date);
            //command.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            //command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable table = new DataTable();
            //adapter.Fill(table);
            //table.TableName = "spd_DanhSachThuLao_Report;1";
            ////// store thu 2
            //SqlCommand command1 = new SqlCommand();
            //command1.CommandType = CommandType.StoredProcedure;
            //command1.CommandText = "spd_REPORT_ReportHeader";

            //command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            //SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            //DataTable table1 = new DataTable();
            //adapter1.Fill(table1);
            //table1.TableName = "spd_REPORT_ReportHeader;1";

            //dataset.Tables.Add(table1);
            //dataset.Tables.Add(table);

            //Report.SetDataSource(dataset);

            //frmHienThiReport dlg = new frmHienThiReport();
            //dlg.crytalView_HienThiReport.ReportSource = Report;
            //dlg.Show(); 
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
            command.Parameters.AddWithValue("@MaNhanVien",0);
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

        private void button2_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_QuocGia);
        }
    }
}