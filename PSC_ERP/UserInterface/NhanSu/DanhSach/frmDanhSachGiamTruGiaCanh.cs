using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using ERP_Library.Security;

namespace PSC_ERP
{//
    public partial class frmDanhSachGiamTruGiaCanh : Form
    {
        BoPhanList _BoPhanList;
        int maBophan = 0; long maNhanVien = 0;
        int userID = CurrentUser.Info.UserID;
        TTNhanVienRutGonList _nhanVienList;

        public frmDanhSachGiamTruGiaCanh()
        {
            InitializeComponent();
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        {           
            _BoPhanList = BoPhanList.GetBoPhanListAll(userID);            
            BindS_BoPhan.DataSource = _BoPhanList;
            ComboChanged();
            cmbKyLuong.DataSource = KyTinhLuongList.GetKyTinhLuongList();
            cmb_TuKy.DataSource = KyTinhLuongList.GetKyTinhLuongList();          
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            DataSet dataset;
            ReportDocument Report;
            frmHienThiReport dlg;
            SqlDataAdapter adapter;
            DataTable table;
            frmXemIn f = new frmXemIn();
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            switch (treeReport.SelectedNode.Name)
            {
                case "Node1":
                    Report = new Report.NhanSu.ChiTietGiamTruGiaCanh();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportChiTietGiamTruGiaCanh";
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportChiTietGiamTruGiaCanh;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node_BaoCaoMaSoThue":
                    //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptDanhSachThuTien.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBaoCaoMaSoThue.rdlc";
                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ThongTinNhanVienTongHopList", ERP_Library.ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListTheoMaSoThue((int)cmbKyLuong.Value)));
                    f.ShowDialog();
                    break;
                case "TinhHinhTangGiam":
                    InBaoCaoTangGiam_New(1);
                    break;
                case "TinhHinhTangGiam_Mau2":
                    InBaoCaoTangGiam_New(2);
                    break;            
            }
        }

        private void InBaoCaoTangGiam()
        {
            ReportDocument Report = new Report.NhanSu.rpt_TangGiamNguoiPhuThuoc();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_ReportTangGiamTruGiaCanh";
            command.Parameters.AddWithValue("@MaKyTinhLuong", (int)cmbKyLuong.Value);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_ReportTangGiamTruGiaCanh;1";

            dataset.Tables.Add(table);
            Report.SetDataSource(dataset);
            Report.SetParameterValue("@DenNgay", ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value).Nam.ToString());

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void InBaoCaoTangGiam_New(int iLoai)
        {
            ReportDocument Report;
            int Nam = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value).Nam;
            if(iLoai == 1)
                Report = new Report.NhanSu.rpt_TangGiamNguoiPhuThuoc_NEW();
            else
                Report = new Report.NhanSu.rpt_TangGiamNguoiPhuThuoc_Mau2();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            if (Nam < 2014)
            {
                command.CommandText = "spd_ReportTangGiamTruGiaCanh";
            }
            else
            {
                command.CommandText = "spd_ReportTangGiamTruGiaCanhNew";
            }
            command.Parameters.AddWithValue("@TuKy", (int)cmb_TuKy.Value);
            command.Parameters.AddWithValue("@DenKy", (int)cmbKyLuong.Value);
            command.Parameters.AddWithValue("@Loai", false);
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_ReportTangGiamTruGiaCanh;1";

            dataset.Tables.Add(table);
            Report.SetDataSource(dataset);
            Report.SetParameterValue("@DenNgay", Nam.ToString());

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                maBophan = Convert.ToInt32(cmbu_Bophan.Value);
                
                ComboChanged();
            }
           
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            maNhanVien = Convert.ToInt32(ultraCombo1.Value);
        }
        private void ComboChanged()
        {
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByBoPhanNganHang(maBophan,0, 0,maNhanVien);
            TTNhanVienRutGon _nhanVienThem = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Tất Cả");
            _nhanVienList.Insert(0, _nhanVienThem);
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;
        }
     
        private void cmbu_Bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void cbNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
           // FilterCombo f = new FilterCombo(cmbNhanVien, "TenNhanVien");
            e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
            e.Layout.Override.AllowColMoving = AllowColMoving.WithinBand;
            e.Layout.Override.AllowColSwapping = AllowColSwapping.WithinBand;
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Bands[0].Columns["TenNhanVien"].FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
            e.Layout.Bands[0].Columns["TenNhanVien"].FilterOperandStyle = FilterOperandStyle.Combo;
            e.Layout.Bands[0].Columns["TenNhanVien"].FilterOperatorLocation = FilterOperatorLocation.AboveOperand; 
        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {
            maNhanVien = Convert.ToInt32(ultraCombo1.Value);
        }

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeReport.SelectedNode.Name == "TinhHinhTangGiam" || treeReport.SelectedNode.Name == "TinhHinhTangGiam_Mau2")
            {
                cmb_TuKy.Visible = true;
                lblTuKy.Visible = true;
                lblKyLuong.Text = "Đến kỳ";
            }
            else
            {
                cmb_TuKy.Visible = false;
                lblTuKy.Visible = false;
                lblKyLuong.Text = "Tháng lương";
            }
        }

    }
}