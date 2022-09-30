using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using PSC_ERP;

namespace PSC_ERP
{
    public partial class frmTieuNhomNganSach : Form
    {
        #region Properties
        PSC_ERP.HamDungChung t = new PSC_ERP.HamDungChung();
        TieuNhomNganSachList _TieuNhomNganSachList = TieuNhomNganSachList.NewTieuNhomNganSachList();
        Util _Util = new Util();
        #endregion

        #region Events
        private void LayDuLieu()
        {
            _TieuNhomNganSachList = TieuNhomNganSachList.GetTieuNhomNganSachList();
            TieuNhom_BindingSource.DataSource = _TieuNhomNganSachList; 
        }

        public frmTieuNhomNganSach()
        {
            InitializeComponent();
            LayDuLieu();
        }

        private void frmTieuNhomNganSach_Load(object sender, EventArgs e)
        {

        }
        
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                TieuNhom_BindingSource.EndEdit();
                grdu_TieuNhomNganSach.UpdateData();
                _TieuNhomNganSachList.ApplyEdit();
                _TieuNhomNganSachList.Save();
                MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_TieuNhomNganSach.Selected.Rows.Count == 0)
            {
                MessageBox.Show(_Util.chodongcanxoa, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            grdu_TieuNhomNganSach.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdu_TieuNhomNganSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdu_TieuNhomNganSach.UpdateData();
            }
        }

        private void grdu_TieuNhomNganSach_Leave(object sender, EventArgs e)
        {
            grdu_TieuNhomNganSach.UpdateData();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new PSC_ERP.Report.CongNo.TieuNhomNganSach();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_TieuNhomNganSach";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_TieuNhomNganSach;1";

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

        #region InitializeLayout
        private void grdu_TieuNhomNganSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            t.ultragrdEmail_InitializeLayout(sender, e);

            grdu_TieuNhomNganSach.DisplayLayout.Bands[0].Columns["MaTieuNhom"].Hidden = true;
            grdu_TieuNhomNganSach.DisplayLayout.Bands[0].Columns["MaTieuNhomQL"].Header.Caption = "Mã Tiểu Nhóm Ngân Sách";
            grdu_TieuNhomNganSach.DisplayLayout.Bands[0].Columns["MaTieuNhomQL"].Header.VisiblePosition = 0;
            grdu_TieuNhomNganSach.DisplayLayout.Bands[0].Columns["MaTieuNhomQL"].Width = 150;

            grdu_TieuNhomNganSach.DisplayLayout.Bands[0].Columns["TenTieuNhom"].Header.Caption = "Tên Tiểu Nhóm Ngân Sách";
            grdu_TieuNhomNganSach.DisplayLayout.Bands[0].Columns["TenTieuNhom"].Header.VisiblePosition = 1;
            grdu_TieuNhomNganSach.DisplayLayout.Bands[0].Columns["TenTieuNhom"].Width = 400;
        }
        #endregion
    }
}