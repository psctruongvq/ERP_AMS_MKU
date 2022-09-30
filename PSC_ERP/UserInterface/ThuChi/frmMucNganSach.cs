using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using PSC_ERP;

namespace PSC_ERP
{
    public partial class frmMucNganSach : Form
    {

        #region Properties
        PSC_ERP.HamDungChung t = new PSC_ERP.HamDungChung();
        MucNganSachList _MucNganSachList = MucNganSachList.NewMucNganSachList();
        MucNganSach _MucNganSach;
        TieuNhomNganSachList _TieuNhomNganSachList = TieuNhomNganSachList.NewTieuNhomNganSachList();
        Util _Util = new Util();
        #endregion

        #region Events
        public frmMucNganSach()
        {
            InitializeComponent();
            LayDuLieu();
        }

        private void LayDuLieu()
        {
            _TieuNhomNganSachList = TieuNhomNganSachList.GetTieuNhomNganSachList();
            TieuNhomNS_BindingSource.DataSource = _TieuNhomNganSachList;
           
            _MucNganSachList = MucNganSachList.GetMucNganSachList();
            MucNganSach_BindingSource.DataSource = _MucNganSachList;
        }

        private void frmMucNganSach_Load(object sender, EventArgs e)
        {
        }
        
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                MucNganSach_BindingSource.EndEdit();
                grdu_MucNganSach.UpdateData();
                _MucNganSachList.ApplyEdit();
                _MucNganSachList.Save();
                MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_MucNganSach.Selected.Rows.Count == 0)
            {
                MessageBox.Show(_Util.chodongcanxoa, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            grdu_MucNganSach.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdu_MucNganSach_Leave(object sender, EventArgs e)
        {
            grdu_MucNganSach.UpdateData();
        }

        private void grdu_MucNganSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdu_MucNganSach.UpdateData();
            }
        }

        private void cmbu_TieuNhomMNS_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_TieuNhomNS.Value != null && (int)cmbu_TieuNhomNS.Value != 0)
            { 
                _MucNganSachList = MucNganSachList.GetMucNganSachList((int)cmbu_TieuNhomNS.Value);
                MucNganSach_BindingSource.DataSource = _MucNganSachList;
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                _MucNganSach = MucNganSach.NewMucNganSach();
                _MucNganSachList.Add(_MucNganSach);
                grdu_MucNganSach.ActiveRow = grdu_MucNganSach.Rows[_MucNganSachList.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new PSC_ERP.Report.CongNo.MucNganSach();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();  
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_MucNganSach";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_MucNganSach;1";

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
        private void grdu_MucNganSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            t.ultragrdEmail_InitializeLayout(sender, e);

            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSach"].Hidden = true;
            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["TenTieuNhom"].Hidden = true;

            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Mục Ngân Sách";
            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Width = 120;
            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 1;

            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.Caption = "Tên Mục Ngân Sách";
            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Width = 235;
            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.VisiblePosition = 2;

            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 3;

            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["MaTieuNhom"].EditorComponent = cmbu_TieuNhomNS;

            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["MaTieuNhom"].Header.Caption = "Tiểu Nhóm Ngân Sách";
            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["MaTieuNhom"].Header.VisiblePosition = 0;
            grdu_MucNganSach.DisplayLayout.Bands[0].Columns["MaTieuNhom"].Width = 220;

            foreach (UltraGridColumn col in this.grdu_MucNganSach.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                    col.CellAppearance.TextHAlign = HAlign.Center;
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
                    col.Format = "###,###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
        }
        #endregion
    }
}