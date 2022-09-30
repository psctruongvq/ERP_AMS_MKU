using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP
{
    public partial class frmThongKeNhanSu : Form
    {
        public frmThongKeNhanSu()
        {
            InitializeComponent();
        }
        DateTime tuNgay = DateTime.Today.Date;
        DateTime denNgay = DateTime.Today.Date;
        int tuThang = DateTime.Today.Date.Month;
        int tuNam = DateTime.Today.Date.Year;
        int denThang = DateTime.Today.Date.Month;
        int denNam = DateTime.Today.Date.Year;
        SqlCommand command;
        DataSet dataset;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table;
        private void treeReport_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           

        }
        private void ReportGeneral(string strProcedure1,ReportDocument Report)
        {            
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = strProcedure1;            
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = strProcedure1+";1";
            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.treeReport.SelectedNode.Name == "Node0")
            {
                ReportGeneral("ThongKe_MaSoNgach", new Report.ThongKeMaSoNgach());
            }
            else if (this.treeReport.SelectedNode.Name == "Node1")
            {
                ReportGeneral("ThongKe_MaSoNgachBoPhan", new Report.ThongKeMaSoNgachDonVi());
            }

            else if (this.treeReport.SelectedNode.Name == "Node2")
            {
                ReportGeneral("ThongKe_MaSoNgachLoaiNV", new Report.ThongKeMaSoNgachHD());
            }
            else if (this.treeReport.SelectedNode.Name == "Node3")
            {
                ReportGeneral("ThongKe_NganhDaoTao", new Report.ThongKeNganhDaoTao());
            }
            else if (this.treeReport.SelectedNode.Name == "Node4")
            {
                ReportGeneral("ThongKe_NganhDaoTaoBoPhan", new Report.ThongKeNganhDaoTaoBoPhan());
            }
            else if (this.treeReport.SelectedNode.Name == "Node5")
            {
                ReportGeneral("ThongKe_NganhDaoTaoLoaiNV", new Report.ThongKeNganhDaoTaoLoaiHD());
            }
            else if (this.treeReport.SelectedNode.Name == "Node6")
            {
                ReportGeneral("ThongKe_ChucDanh", new Report.ThongKeChucDanh());
            }
            else if (this.treeReport.SelectedNode.Name == "Node7")
            {
                ReportGeneral("ThongKe_ChucDanhBoPhan", new Report.ThongKeChucDanhBoPhan());
            }
            else if (this.treeReport.SelectedNode.Name == "Node8")
            {
                ReportGeneral("ThongKe_ChucDanhLoaiHopDong", new Report.ThongKeChucDanhLoaiHD());
            }
            else if (this.treeReport.SelectedNode.Name == "Node9")
            {
                ReportGeneral("ThongKe_HeSoLuong", new Report.ThongKeHeSoLuong());
            }
            else if (this.treeReport.SelectedNode.Name == "Node10")
            {
                ReportGeneral("ThongKe_HeSoLuongDonVi", new Report.ThongKeHeSoLuongDonVi());
            }
            else if (this.treeReport.SelectedNode.Name == "Node11")
            {
                ReportGeneral("ThongKe_HeSoLuongLoaiHD", new Report.ThongKeHeSoLuongLoaiHD());
            }
            else if (this.treeReport.SelectedNode.Name == "Node12")
            {
                ReportGeneral("ThongKe_Phai", new Report.ThongKePhai());
            }
            else if (this.treeReport.SelectedNode.Name == "Node13")
            {
                ReportGeneral("ThongKe_PhaiBoPhan", new Report.ThongKePhaiBoPhan());
            }
            else if (this.treeReport.SelectedNode.Name == "Node14")
            {
                ReportGeneral("ThongKe_PhaiBoLoaiNV", new Report.ThongKePhaiHD());
            }
            else if (this.treeReport.SelectedNode.Name == "Node15")
            {
                ReportGeneral("ThongKe_LyLuanChinhTri", new Report.ThongKeLyLuanChinhTri());
            }
            else if (this.treeReport.SelectedNode.Name == "Node16")
            {
                ReportGeneral("ThongKe_LyLuanChinhTriBoPhan", new Report.ThongKeLyLuanChinhTriDonVi());
            }
            else if (this.treeReport.SelectedNode.Name == "Node17")
            {
                ReportGeneral("ThongKe_LyLuanChinhTriLoaiHD", new Report.ThongKeLyLuanChinhTriLoaiHD());
            }
            else if (this.treeReport.SelectedNode.Name == "Node18")
            {
                ReportGeneral("ThongKe_LoaiNhanVien", new Report.ThongKeLoaiNhanVien());
            }
            else if (this.treeReport.SelectedNode.Name == "Node19")
            {
                ReportGeneral("ThongKe_DangVien", new Report.ThongKeDangVien());
            }
            else if (this.treeReport.SelectedNode.Name == "Node20")
            {
                ReportGeneral("ThongKe_DangVienLoaiBoPhan", new Report.ThongKeDangVienBoPhan());
            }
            else if (this.treeReport.SelectedNode.Name == "Node21")
            {
                ReportGeneral("ThongKe_DangVienLoaiHopDong", new Report.ThongKeDangVienLoaiHopDong());
            }
            else if (this.treeReport.SelectedNode.Name == "Node22")
            {
                ReportGeneral("ThongKe_DonVi", new Report.ThongKeDonVi());
            }
            else if (this.treeReport.SelectedNode.Name == "Node24")
            {
                ReportGeneral("ThongKe_DonViLoaiHD", new Report.ThongKeDonViLoaiHD());
            }
            else if (this.treeReport.SelectedNode.Name == "Node25")
            {
                ReportGeneral("ThongKe_NgoaiNgu", new Report.ThongKeNgoaiNgu());
            }
            else if (this.treeReport.SelectedNode.Name == "Node26")
            {
                ReportGeneral("ThongKe_NgoaiNguBoPhan", new Report.ThongKeNgoaiNguBoPhan());
            }
            else if (this.treeReport.SelectedNode.Name == "Node27")
            {
                ReportGeneral("ThongKe_NgoaiNguLoaiNhanVien", new Report.ThongKeNgoaiNguHD());
            }
            else if (this.treeReport.SelectedNode.Name == "Node28")
            {
                ReportGeneral("ThongKe_VanHoa", new Report.ThongKeVanHoa());
            }
            else if (this.treeReport.SelectedNode.Name == "Node29")
            {
                ReportGeneral("ThongKe_VanHoaBoPhan", new Report.ThongKeVanHoaBoPhan());
            }
            else if (this.treeReport.SelectedNode.Name == "Node30")
            {
                ReportGeneral("ThongKe_VanHoaLoaiNV", new Report.ThongKeVanHoaHD());
            }
            else if (this.treeReport.SelectedNode.Name == "Node31")
            {

                Report = new Report.NhanSu.BaoCaoTangGiamLaoDong();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_ReportThongKeTangGiamLaoDong";

                    command.Parameters.AddWithValue("@TuThang", tuThang);
                    command.Parameters.AddWithValue("@DenThang", denThang);
                    command.Parameters.AddWithValue("@TuNam", tuNam);
                    command.Parameters.AddWithValue("@DenNam", denNam);
                    command.Parameters.AddWithValue("@TuNgay", tuNgay);
                    command.Parameters.AddWithValue("@DenNgay", denNgay);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_ReportThongKeTangGiamLaoDong;1";

                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay", tuNgay);
                    Report.SetParameterValue("_denNgay", denNgay);
                    

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            tuNgay = dateTuNgay.Value.Date;
            tuThang = dateTuNgay.Value.Date.Month;
            tuNam = dateTuNgay.Value.Date.Year;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            denNgay = dateTimePicker1.Value.Date;
            denThang = dateTimePicker1.Value.Date.Month;
            denNam = dateTimePicker1.Value.Date.Year;
        }

        
    }
}