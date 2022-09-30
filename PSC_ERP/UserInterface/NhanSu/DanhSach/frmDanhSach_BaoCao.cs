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
namespace PSC_ERP
{
    public partial class frmDanhSach_BaoCao : Form
    {
        BiaHoSoList _BiaHS;
        BiaBHXHList _BiaBHXH;
        BoPhanList _BoPhanHD;
        public frmDanhSach_BaoCao()
        {
            InitializeComponent();
            this.Load_Source();
        }

        #region Load
        private void Load_Source()
        {
            _BiaHS = BiaHoSoList.GetBiaHoSoList();
            BindS_BiaHS.DataSource = _BiaHS;

            _BiaBHXH = BiaBHXHList.GetBiaBHXHList();
            BindS_BiaBHXH.DataSource = _BiaBHXH;
            _BoPhanHD = BoPhanList.GetBoPhanList();
            BindS_BoPhan.DataSource = _BoPhanHD;
        }
        private void Load_Nguon()
        {
            trvbaocao.ImageList = imgTree;
            trvbaocao.Nodes.Add("QLNS", "Quản Lý Hồ Sơ",2);
            trvbaocao.Nodes["QLNS"].Nodes.Add("DSNV_CHUACOTHECC", "Danh Sách Chưa Có Thẻ Chấm Công",1);
            trvbaocao.Nodes["QLNS"].Nodes.Add("DSNV_DACOTHECC", "Danh Sách Đã Có Thẻ Chấm Công",1);
            trvbaocao.Nodes["QLNS"].Nodes.Add("BHXH", "BHXH-BHYT", 2);
            trvbaocao.Nodes["QLNS"].Nodes["BHXH"].Nodes.Add("BHXH_CHUACOSO", "Danh Sách Chưa Có Sổ BHXH", 1);
            trvbaocao.Nodes["QLNS"].Nodes["BHXH"].Nodes.Add("BHXH_DACOSO", "Danh Sách Đã Có Sổ BHXH", 1);
            trvbaocao.Nodes["QLNS"].Nodes["BHXH"].Nodes.Add("BHXH_CHUACOTHEBHYT", "Danh Sách Chưa Có Thẻ KCB", 1);
            trvbaocao.Nodes["QLNS"].Nodes["BHXH"].Nodes.Add("BHXH_DACOTHEBHYT", "Danh Sách Đã Có Thẻ KCB", 1);

            trvbaocao.Nodes["QLNS"].Nodes.Add("BIAHS", "Bìa HS - Bìa BHXH", 2);
            trvbaocao.Nodes["QLNS"].Nodes["BIAHS"].Nodes.Add("BIA_CHUACOBIAHS", "Danh Sách Chưa Có Bìa HS", 1);
            trvbaocao.Nodes["QLNS"].Nodes["BIAHS"].Nodes.Add("BIA_TRONGBIAHS", "Danh Sách Trong Bìa HS", 1);
            trvbaocao.Nodes["QLNS"].Nodes["BIAHS"].Nodes.Add("BIA_CHUACOBIABH", "Danh Sách Chưa Có Bìa BHXH", 1);
            trvbaocao.Nodes["QLNS"].Nodes["BIAHS"].Nodes.Add("BIA_TRONGBIABH", "Danh Sách Trong Bìa BHXH", 1);

            trvbaocao.Nodes["QLNS"].Nodes.Add("HDLD", "Hợp Đồng Lao Động", 2);
            trvbaocao.Nodes["QLNS"].Nodes["HDLD"].Nodes.Add("HDLD_CHUAKY", "Danh Sách Chưa Ký HĐLĐ", 1);
            trvbaocao.Nodes["QLNS"].Nodes["HDLD"].Nodes.Add("HDLD_HETHAN", "Danh Sách Đến Hạn HĐ", 1);

            trvbaocao.Nodes.Add("QLCC", "Quản Lý Chấm Công",3);

            trvbaocao.ExpandAll();
        }
        private void frmDanhSach_BaoCao_Load(object sender, EventArgs e)
        {
            this.Load_Nguon();
            dtp_HDLDDenngay.Value = DateTime.Now;
        }
        #endregion
        
        #region Event 
        private void trvbaocao_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.AnGroup();
            groupBox1.Text = "Xem Báo Cáo : " + trvbaocao.SelectedNode.Text;
            if (trvbaocao.SelectedNode.Name == "BIA_TRONGBIAHS")
            {
                if (!grpBiaHS.Visible)
                {
                    grpBiaHS.Visible = true;
                    grpBiaHS.Left = 6;
                    grpBiaHS.Top = 19;
                }
            }
            if (trvbaocao.SelectedNode.Name == "BIA_TRONGBIABH")
            {
                if (!grpBHXH.Visible)
                {
                    grpBHXH.Visible = true;
                    grpBHXH.Left = 6;
                    grpBHXH.Top = 19;
                }
            }
            if (trvbaocao.SelectedNode.Name == "HDLD_HETHAN")
            {
                if (!grpGiaHanHD.Visible)
                {
                    grpGiaHanHD.Visible = true;
                    grpGiaHanHD.Left = 6;
                    grpGiaHanHD.Top = 19;
                }
            }
        }        

        private void AnGroup()
        {
            foreach (Control ctr in groupBox1.Controls)
            {
                if (ctr.GetType()==typeof(GroupBox))
                {
                    ctr.Visible = false;
                }
            }
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            this.ThuTucIn(trvbaocao.SelectedNode.Name.ToString());
        }
        #endregion

        #region Process
        private void ThuTucIn(string LoaiBC)
        {
            switch( LoaiBC)
            {
                case "DSNV_CHUACOTHECC": this.InDSChuaCoTheCC(); break;
                case "DSNV_DACOTHECC": this.InDSDaCoTheCC(); break;
                case "BHXH_CHUACOSO": this.InDSChuaCoSoBHXH(); break;
                case "BHXH_DACOSO": this.InDSDaCoSoBHXH(); break;
                case "BHXH_CHUACOTHEBHYT": this.InDSChuaCoTheBHYT(); break;
                case "BHXH_DACOTHEBHYT": this.InDSDaCoTheBHYT(); break;

                case "BIA_CHUACOBIAHS": this.InDSChuaCoBiaHS(); break;
                case "BIA_TRONGBIAHS": this.InDSTrongBiaHS(); break;
                case "BIA_CHUACOBIABH": this.InDSChuaCoBiaBHXH(); break;
                case "BIA_TRONGBIABH": this.InDSTrongBiaBHXH(); break;
                case "HDLD_CHUAKY": this.InDSChuaKyHDLD(); break;
                case "HDLD_HETHAN": this.InDSDenHanCDHD(); break; 
                                
            }
        }

        private void InDSChuaCoTheCC()
        {
            ReportDocument Report = new Report.Danhsach_NV_ChuacoTheCC();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_DSChuaCotheChamcong";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_DSChuaCotheChamcong;1";

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

        private void InDSDaCoTheCC()
        {
            ReportDocument Report = new Report.Danhsach_NV_DaCoTheCC();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_DSCotheChamcong";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_DSCotheChamcong;1";

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

        private void InDSChuaCoSoBHXH()
        {
            ReportDocument Report = new Report.Danhsach_NV_ChuacosoBH();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_tblnsDSchuacosoBH";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_tblnsDSchuacosoBH;1";
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

        private void InDSDaCoSoBHXH()
        {
            ReportDocument Report = new Report.Danhsach_NV_DacosoBH();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_tblnsDSdacosoBH";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_tblnsDSdacosoBH;1";
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

        private void InDSChuaCoTheBHYT()
        {
            ReportDocument Report = new Report.Danhsach_NV_ChuacosoYTE();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_tblnsdschuacosoYTE";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_tblnsdschuacosoYTE;1";
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

        private void InDSDaCoTheBHYT()
        {
            ReportDocument Report = new Report.Danhsach_NV_DacosoYTE();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_tblnsdsdacosoYTE";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_tblnsdsdacosoYTE;1";
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

        private void InDSChuaCoBiaHS()
        {
            ReportDocument Report = new Report.Danhsach_NV_ChuacoBia();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_tblnsDSchuacobia";

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsDSchuacobia;1";

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

        private void InDSTrongBiaHS()
        {
            if (cmdu_Biahoso.Text == string.Empty)
            {
                MessageBox.Show(this, "Chọn bìa cần in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ReportDocument Report = new ReportDocument();
                DataSet dataset = new DataSet();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_report_tblnsDSNVtheobia";
                command.Parameters.AddWithValue("@mabiahoso", cmdu_Biahoso.Value);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_report_tblnsDSNVtheobia;1";

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
        }

        private void InDSChuaCoBiaBHXH()
        {
            ReportDocument Report = new Report.Danhsach_NV_ChuacoBiaBH();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_tblnsDSchuacobiaBH";

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsDSchuacobiaBH;1";

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

        private void InDSTrongBiaBHXH()
        {
            if (cmbu_BiaBHXH.Text == string.Empty)
            {
                MessageBox.Show(this, "Chọn bìa cần in", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                ReportDocument Report = new ReportDocument();
                DataSet dataset = new DataSet();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_report_tblnsDSNVtheobiaBHXH";
                command.Parameters.AddWithValue("@mabiaBHXH", cmbu_BiaBHXH.Value);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_report_tblnsDSNVtheobiaBHXH;1";

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
        }

        private void InDSChuaKyHDLD()
        {
            ReportDocument Report = new Report.Danhsach_NV_ChuakyHD();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_tblnsDSchuakyHD";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsDSchuakyHD;1";

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

        private void InDSDenHanCDHD()
        {
            if (cmbu_HDLDBoPhan.Value == null)
            {
                MessageBox.Show(this, "Chọn Bộ Phận Cần In !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ReportDocument Report = new ReportDocument();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_tblnsDSchuyendoiHD";
            command.Parameters.AddWithValue("@denngay", dtp_HDLDDenngay.Value);
            command.Parameters.AddWithValue("@mabophan", (int)cmbu_HDLDBoPhan.Value);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsDSchuyendoiHD;1";

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

        #endregion

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


    }
}