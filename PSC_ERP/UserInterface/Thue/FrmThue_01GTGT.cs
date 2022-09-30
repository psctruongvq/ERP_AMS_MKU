using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
namespace PSC_ERP
{
    public partial class FrmThue_01GTGT : Form
    {
        int _maky = 0;
        ToKhaiThueGTGTGTList Tk = ToKhaiThueGTGTGTList.NewToKhaiThueGTGTGTList();

        public FrmThue_01GTGT(int maky)
        {
            InitializeComponent();
            Tk = ToKhaiThueGTGTGTList.GetToKhaiThueGTGTGTList(maky);
            Binds_TokhaiGT.DataSource = Tk;
            _maky = maky;
        }
        private void Load_Source()
        {

        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                Binds_TokhaiGT.EndEdit();
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


            ReportDocument Report = new Report.Thue.Thue01GTGT();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_Report_ReportHeader";
            command.Parameters.AddWithValue("@macongty", 1);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_ReportHeader;1";


            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;

            command2.CommandText = "spd_LaymasothueCongty";
            command2.Parameters.AddWithValue("@macongty", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            table2.TableName = "spd_LaymasothueCongty;1";


            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_reportThue01GTGT";
            command1.Parameters.AddWithValue("@maky",_maky);
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_reportThue01GTGT;1";


            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            dataset.Tables.Add(table2);
            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();

        }
    }
}