using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;

namespace PSC_ERP
{
    public partial class frmDanhSachChiuThueTNCN : Form
    {
        LoaiBoPhanList _LoaiBoPhanList;
        BoPhanList _BoPhanList;
        NhanVienList _nhanVienList;
       static int MaBoPhan = 0;
        Util util = new Util();
        public frmDanhSachChiuThueTNCN()
        {
            InitializeComponent();
        }

        private void frmDanhSachChiuThueTNCN_Load(object sender, EventArgs e)
        {
            _LoaiBoPhanList = LoaiBoPhanList.GetLoaiBoPhanList();
            LoaiBoPhan_BindingSource.DataSource = _LoaiBoPhanList;
        }

        private void cmbu_LoaiBoPhan_ValueChanged(object sender, EventArgs e)
        {
            int MaLoaiBoPhan = 0;
            if (cmbu_LoaiBoPhan.Value != null)
            {
                MaLoaiBoPhan = (int)cmbu_LoaiBoPhan.Value;
                _BoPhanList = BoPhanList.GetBoPhanList_LoaiBoPhan(MaLoaiBoPhan);
                BoPhan_BindingSource.DataSource = _BoPhanList;
            }
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            
            if (cmbu_BoPhan.Value != null)
            {
                if ((int)cmbu_BoPhan.Value != 0)
                {
                    MaBoPhan = (int)cmbu_BoPhan.Value;
                }
            }
            try
            {
                _nhanVienList = NhanVienList.GetNhanVienListBoPhan(MaBoPhan);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            }
            catch (ApplicationException)
            {

            }
            lbl_TongSo.Text = "Số lượng công nhân: " + _nhanVienList.Count;
            if (_nhanVienList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.rptThueTNCN();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_reportDSThueTNCN";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "sp_reportDSThueTNCN;1";
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
}