using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP.UserInterface.NganHang
{
    public partial class frmChiTietSoDuNganHang : Form
    {

        #region Properties
        SqlCommand command;
        SqlCommand command1;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        SqlDataAdapter adapter1;
        DataTable table;
        DataTable table1;
        NhomNganHangList _nhomNganHangList;
        DataSet dataset = new DataSet();
        #endregion

        #region Load
        public frmChiTietSoDuNganHang()
        {
            InitializeComponent();
            cmb_Loai.SelectedIndex = 0;
            _nhomNganHangList = NhomNganHangList.GetNhomNganHangList();
            _nhomNganHangList.Insert(0, NhomNganHang.NewNhomNganHang("Tất cả"));
            nhomNganHangListBindingSource.DataSource = _nhomNganHangList;
        }
        #endregion

        #region Events
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cmb_Loai.SelectedIndex >= 0)
            {

                int iLoai = Convert.ToInt32(cmb_Loai.Value);

                dataset = new DataSet();
                DateTime dtTuNgay = Convert.ToDateTime(txtTuNgay.Value);
                DateTime dtDenNgay = Convert.ToDateTime(txtDenNgay.Value);

                Report = new Report.NganHang.rpt_ChiTietSoDu_NganHang();
                command = new SqlCommand();

                command.CommandType = CommandType.StoredProcedure;
                if (iLoai == 0)
                {
                    command.CommandText = "spd_Report_ChiTietSoDuTaiKhoan_NganHang";
                }
                else if (iLoai == 1)
                {
                    command.CommandText = "spd_Report_ChiTietSoDuTaiKhoan_NganHang_ByNgayLap";
                }
                else if (iLoai == 2)
                {
                    command.CommandText = "spd_Report_ChiTietSoDuTaiKhoan_NganHang_ByNgayLapNotXacNhan";
                }

                command.Parameters.AddWithValue("@MaNhomNganHang", Convert.ToInt32(cmbu_NhomNganHang.Value));
                command.Parameters.AddWithValue("@TuNgay", dtTuNgay);
                command.Parameters.AddWithValue("@DenNgay", dtDenNgay);
                command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_ChiTietSoDuTaiKhoan_NganHang;1";

                command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                command1.CommandTimeout = 0;
                command1.CommandText = "spd_LayNguoiKyTenCongNo";
                command1.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter1 = new SqlDataAdapter(command1);
                table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataset = new DataSet();
                dataset.Tables.Add(table);
                dataset.Tables.Add(table1);
                Report.SetDataSource(dataset);

                Report.SetParameterValue("_denNgay", dtDenNgay);
                //Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                //Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
        }
        #endregion

        private void cmbu_NhomNganHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            FilterCombo filter = new FilterCombo(cmbu_NhomNganHang, "TenNhomNganHang");
            HamDungChung.EditBand(cmbu_NhomNganHang.DisplayLayout.Bands[0],
                new string[2] { "TenNhomNganHang", "ChuVietTat" },
                new string[2] { "Tên nhóm ngân hàng", "Chữ viết tắt"},
                new int[2] { 300, 100 },
                new Control[2] { null, null },
                new KieuDuLieu[2] {  KieuDuLieu.Null, KieuDuLieu.Null},
                new bool[2] { false, false});

            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NhomNganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            this.cmbu_NhomNganHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_NhomNganHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
        }
    }
}
