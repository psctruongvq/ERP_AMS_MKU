using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;


namespace PSC_ERP
{
    public partial class frmBaoCaoCongDoan : Form
    {
        private  NguoiKyTen nguoikyten; 
        public frmBaoCaoCongDoan()
        {
            InitializeComponent();
            treeReport.ExpandAll();
           
            heThongTaiKhoan1ListBindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            ultraCombo_TaiKhoan.DataSource = heThongTaiKhoan1ListBindingSource;
            ultraCombo_TaiKhoan.DisplayMember = "TenTaiKhoan";
            ultraCombo_TaiKhoan.ValueMember = "MaTaiKhoan";

            HeThongTaiKhoan1List tklist = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            heThongTaiKhoan1ListBindingSource.DataSource = tklist;
            txtNam.Value = DateTime.Today.Year;
            cmbKyTen.Value = 0;
            nguoikyten = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        DataSet _DataSet;
        ReportDocument Report;
        SqlCommand command;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table;
        int dot = 1;
        string loai;
        private void btnReport_Click(object sender, EventArgs e)
        {
            
            frmXemIn f = new frmXemIn();
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;

            switch (treeReport.SelectedNode.Name)
            {
                case "nodeTongHopCongDoan":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopCongDoanPhi.rdlc";
                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BaoCaoCongDoanPhiList", ERP_Library.BaoCaoCongDoanPhiList.GetBaoCaoTongHopCongDoan(Convert.ToInt32(txtQui.Value), Convert.ToInt32(txtNam.Value), "All")));
                    dot = -1;
                    Microsoft.Reporting.WinForms.ReportParameter _ky = null;
                    if (dot == -1)
                        _ky = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong", "Quí " + txtQui.Value + " năm " + txtNam.Value);

                    loai = "";
                    Microsoft.Reporting.WinForms.ReportParameter _loai = new Microsoft.Reporting.WinForms.ReportParameter("PhanLoai", loai);
                    if (treeReport.SelectedNode.Name == "nodeTongHopCongDoan" || treeReport.SelectedNode.Name == "nodeCongDoanPhi")
                    {
                        Microsoft.Reporting.WinForms.ReportParameter _qui = new Microsoft.Reporting.WinForms.ReportParameter("Qui", txtQui.Value.ToString());
                        rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { _ky, _loai, _qui });
                    }
                    f.SetNguoiKy((int)cmbKyTen.Value);
                    f.ShowDialog();
                    break;
                case "nodeCongDoanPhi":
                    dot = -1;
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDanhSachCongDoanPhi.rdlc";
                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BaoCaoCongDoanPhiList", ERP_Library.BaoCaoCongDoanPhiList.GetBaoCaoCongDoanPhiList(Convert.ToInt32(txtQui.Value), Convert.ToInt32(txtNam.Value), 0, "All")));
                    Microsoft.Reporting.WinForms.ReportParameter _ky1 = null;
                    if (dot == -1)
                        _ky1 = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong", "Quí " + txtQui.Value + " năm " + txtNam.Value);

                    loai = "";
                    Microsoft.Reporting.WinForms.ReportParameter _loai1 = new Microsoft.Reporting.WinForms.ReportParameter("PhanLoai", loai);
                    if (treeReport.SelectedNode.Name == "nodeTongHopCongDoan" || treeReport.SelectedNode.Name == "nodeCongDoanPhi")
                    {
                        Microsoft.Reporting.WinForms.ReportParameter _qui = new Microsoft.Reporting.WinForms.ReportParameter("Qui", txtQui.Value.ToString());
                        rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { _ky1, _loai1, _qui });
                    }
                    f.SetNguoiKy((int)cmbKyTen.Value);
                    f.ShowDialog();
                    break;
                case "Node_SoChiTietTaiKhoan":

                    Report = new Report.CongNo.BaoCaoThuQuyTienGoi_CongDoan();
                    command = new SqlCommand();
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    _DataSet = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportThuQuyTienGuiCongDoan";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(ultraDateTimeEditor_TuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(ultraDateTimeEditor_DenNgay.Value).Date);
                    command.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter.Fill(table);
                    table.TableName = "spd_ReportThuQuyTienGuiCongDoan;1";
                    _DataSet.Tables.Add(table);
                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(ultraDateTimeEditor_TuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(ultraDateTimeEditor_DenNgay.Value).Date);
                    Report.SetParameterValue("_tieuDeNguoiLap", nguoikyten.NguoiLapTieude);
                    Report.SetParameterValue("_tieuDeThuTruong", nguoikyten.ThuTruongTieude);
                    Report.SetParameterValue("_tenNguoiLap", nguoikyten.NguoiLapTen);
                    Report.SetParameterValue("_tenThuTruong", nguoikyten.ThuTruongTen);
                    Report.SetParameterValue("_tieuDeGiamDoc", nguoikyten.TieuDeTongGiamDoc);
                    Report.SetParameterValue("_tenGiamDoc", nguoikyten.TenTongGiamDoc);
                    HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1((int)ultraCombo_TaiKhoan.Value);

                    Report.SetParameterValue("_soHieuTk", "Số hiệu: " + tk.SoHieuTK);
                    Report.SetParameterValue("_tenTaiKhoan", "Tên tài khoản: " + tk.TenTaiKhoan);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                   
                    dlg.Show();
                    break;
                case "Node_ThuChiNganSachCongDoanCoSo":
                    // _DataSet = new DataSet();
                    Report = new Report.CongNo.ThuChiNganSachCongDoan();
                    command = new SqlCommand();
                    command = new SqlCommand();
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    _DataSet = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "ReportSoThuChiCongDoanCoSo";
                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(ultraDateTimeEditor_TuNgay.Value).Date);
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(ultraDateTimeEditor_DenNgay.Value).Date);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    adapter.Fill(table);
                    table.TableName = "ReportSoThuChiCongDoanCoSo;1";
                    _DataSet.Tables.Add(table);

                    Report.SetDataSource(_DataSet);
                    Report.SetParameterValue("_TenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_TuNgay", Convert.ToDateTime(ultraDateTimeEditor_TuNgay.Value).Date);
                    Report.SetParameterValue("_DenNgay", Convert.ToDateTime(ultraDateTimeEditor_DenNgay.Value).Date);
                    Report.SetParameterValue("_tieuDeNguoiLap", nguoikyten.NguoiLapTieude);
                    Report.SetParameterValue("_tieuDeThuTruong", nguoikyten.ThuTruongTieude);

                    Report.SetParameterValue("_tenNguoiLap", nguoikyten.NguoiLapTen);
                    Report.SetParameterValue("_tenThuTruong", nguoikyten.ThuTruongTen);


                    Report.SetParameterValue("_tieuDeGiamDoc", nguoikyten.TieuDeTongGiamDoc);
                    Report.SetParameterValue("_tenGiamDoc", nguoikyten.TenTongGiamDoc);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                default:
                    return;

            }
             
        }

        private void ultraCombo_TaiKhoan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu Tài Khoản";
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;

            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 250;

            this.ultraCombo_TaiKhoan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCombo_TaiKhoan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            FilterCombo f = new FilterCombo(ultraCombo_TaiKhoan, "SoHieuTK");
          
        }

    }
}