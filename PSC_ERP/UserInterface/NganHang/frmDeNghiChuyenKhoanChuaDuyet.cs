using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP.UserInterface.NganHang
{
    public partial class frmDeNghiChuyenKhoanChuaDuyet : Form
    {
        #region Properties
        ChuyenKhoanChuaDuyetList _data;
        DateTime _TuNgay;
        DateTime _DenNgay;
        int _MaCongTy = 0;
        #endregion

        #region Loads
        public frmDeNghiChuyenKhoanChuaDuyet()
        {
            InitializeComponent();

            LoadForm();
            
            CongTyList _congtyList = CongTyList.GetCongTyList();
            CongTy_BindingSource.DataSource = _congtyList;
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
                new string[9] { "So", "Ngay", "TenDoiTac", "SoTaiKhoan", "TenNganHang", "SoTien", "MaQuanLy", "DienGiai", "TenDangNhap" },
                new string[9] { "Số đề nghị", "Ngày lập", "Tên đối tác", "Số tài khoản", "Ngân hàng", "Số tiền", "Loại tiền", "Diễn giải", "Người lập"},
                new int[9] { 120, 100, 200, 120, 150, 120, 60, 150, 80 },
                new Control[9] { null, null, null, null, null, null, null, null, null },
                new KieuDuLieu[9] { KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.TienLe, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[9] { false, false, false, false, false, false, false, false, false });

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
           }
            this.grdData.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdData.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
        }

        private void cmbu_CongTy_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_CongTy.DisplayLayout.Bands[0],
                new string[1] { "TenCongTy" },
                new string[1] { "Tên công ty" },
                new int[1] { 350 },
                new Control[1] { null },
                new KieuDuLieu[1] { KieuDuLieu.Null },
                new bool[1] { false });

            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_CongTy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.cmbu_CongTy.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_CongTy.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
        }
        #endregion

        #region Process
        private void LoadForm()
        {
            _TuNgay = Convert.ToDateTime(dtp_TuNgay.Value);
            _DenNgay = Convert.ToDateTime(dtp_DenNgay.Value);
            _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

            _data = ChuyenKhoanChuaDuyetList.GetChuyenKhoanChuaDuyetList(_TuNgay, _DenNgay, _MaCongTy);
            bdData.DataSource = _data;
        }
        #endregion

        #region Events
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.NganHang.rpt_DeNghiChuaDuyet();
            DataSet dataSet = new DataSet();
            frmHienThiReport dlg;

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 0;

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command1.CommandTimeout = 0;


            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command2.CommandTimeout = 0;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();

            command.CommandText = "spd_tblDeNghiChuyenKhoan_ChuaLapChungTu";
            command.Parameters.AddWithValue("@TuNgay", _TuNgay);
            command.Parameters.AddWithValue("@DenNgay", _DenNgay);
            command.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            table.TableName = "spd_tblDeNghiChuyenKhoan_ChuaLapChungTu;1";

            command1.CommandText = "spd_report_ReportHeader";
            command1.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
            adapter.SelectCommand = command1;
            adapter.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";
            command1.CommandTimeout = 0;

            command2.CommandText = "spd_LayNguoiKyTenCongNo";
            command2.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            command2.CommandTimeout = 0;
            adapter.SelectCommand = command2;
            adapter.Fill(table2);
            table2.TableName = "spd_LayNguoiKyTenCongNo;1";

            dataSet.Tables.Add(table);
            dataSet.Tables.Add(table1);
            dataSet.Tables.Add(table2);

            Report.SetDataSource(dataSet);
            dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslbl_Export_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }
        #endregion

        private void dtp_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void dtp_DenNgay_ValueChanged(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void cmbu_CongTy_ValueChanged(object sender, EventArgs e)
        {
            LoadForm();
        }
    }
}
