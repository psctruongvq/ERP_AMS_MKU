using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.IO;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            InitializeComponent();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }

    
        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
 
        }

        private bool KiemTra(string name)
        {
            bool bFound = false;
            ReportTemplate obj = ReportTemplate.GetReportTemplate(name);
            if (obj.Data != null)
                bFound = true;
            return bFound;
        }


        ReportTemplate item;
        private void btn_Xem_Click(object sender, EventArgs e)
        {
            string strChuoi = TreeView_Test.SelectedNode.Name;
            int UserId = 0;
            DateTime dtDenNgay = dtp_DenNgay.Value.Date;
            frmReport frm = new frmReport();

            if (!KiemTra(strChuoi))
            {
                XtraMessageBox.Show("Báo cáo chưa tồn tại vui lòng tạo báo cáo trước khi xem !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            item = ReportTemplate.GetReportTemplate(strChuoi, UserId, dtDenNgay);
            if (item.Id == string.Empty)
            {
                item.Id = strChuoi;
                item.UserID = UserId;
                item.DenNgay = dtDenNgay;
            }
          
            switch (strChuoi)
            {
                case "baocao01":
                    FillDataTable("LayBoPhanAll");
                    break;
                case "baocao02":
                    FillDataTable("LayBoPhanDCha");
                    break;
                default:
                    break;
            }

            frm.HienThiReport(item, ds);
            frm.Show();
        }

        private void btn_CreateNew_Click(object sender, EventArgs e)
        {
            XtraReport report = new XtraReport();
            int UserId = 0;

            frmThongTinReport frmObject = new frmThongTinReport(report, UserId);

            //frmObject.ShowDialog();

            if (frmObject.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                item = frmThongTinReport._reportItem;
                FillDataTable(item.TenPhuongThuc);

                frmReport frm = new frmReport();
                frm.HienThiReport(item, ds);
                frm.Show();
            }
        }

        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable table;
        DataSet ds;
        public static int maBoPhanCha;

        public DataSet FillDataTable(string fncName)
        {
            ds = new DataSet();
            switch (fncName)
            {
                case "LayBoPhanAll":
                    GetAllBoPhan();
                    break;
                case "LayBoPhanDCha":
                    GetAllBoPhanCha();
                    break;
                default:
                    break;
            }

            return ds;
        }

        private void GetAllBoPhan()
        {
            command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_SelecttblnsBoPhansAll";

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            table.TableName = "sp_SelecttblnsBoPhansAll;1";
            ds.Tables.Add(table);
        }

        private void GetAllBoPhanCha()
        {
            command = new SqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_SelecttblnsBoPhan_MaCha";
            command.Parameters.AddWithValue("@MaBoPhanCha", Convert.ToInt32(txt_BoPhanCha.Text));

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            adapter = new SqlDataAdapter(command);
            table = new DataTable();
            adapter.Fill(table);
            table.TableName = "Table_SelectBoPhancha1";
            ds.Tables.Add(table);
        }


    }
}
