using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
namespace PSC_ERP
{
    public partial class FrmBangPhanBoGTGT : Form
    {
        int _maky = 0;
        PhanBoGTGTList Tk = PhanBoGTGTList.NewPhanBoGTGTList();
        public FrmBangPhanBoGTGT(int maky)
        {
            InitializeComponent();
            Tk = PhanBoGTGTList.GetPhanBoGTGTList(maky);
            Binds_PhanboGTGT.DataSource = Tk;
            _maky = maky;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                Binds_PhanboGTGT.EndEdit();
                Tk.ApplyEdit();
                Tk.Save();
                MessageBox.Show(this, "Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            In_GTbangphanbo(1);
        }
        private void In_GTbangphanbo(int macongty)
        {
            ReportDocument Report = new Report.Thue.Thue01_4AGTGT();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_Report_ReportHeader";
            command.Parameters.AddWithValue("@macongty", macongty);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_ReportHeader;1";

            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;

            command2.CommandText = "spd_LaymasothueCongty";
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            table2.TableName = "spd_LaymasothueCongty;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_reportThue01_4GTGT";
            command1.Parameters.AddWithValue("@maky", _maky);
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_reportThue01_4GTGT;1";

            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            dataset.Tables.Add(table2);
            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}