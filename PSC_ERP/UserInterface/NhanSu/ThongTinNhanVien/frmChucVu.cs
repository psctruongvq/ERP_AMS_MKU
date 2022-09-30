using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmChucVu : Form
    {
        #region Properties
        Util util=new Util();
        ChucVuList list;
      
        public delegate void PassData(ChucVuList value);
        public PassData passData;
        #endregion

        #region Events
        private void ultragrdChucVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            /*
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            //ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Header.Caption = "Mã Chức Vụ";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Header.VisiblePosition = 1;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Width = 100;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 2;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 150;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 3;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenVietTat"].Width = 90;

            //ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Header.Caption = "Tên Nhóm Chức Vụ";
            //ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Header.VisiblePosition = 0;
            //ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Width = 150;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 5;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;

            ultragrdChucVu.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.ultragrdChucVu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.ultragrdChucVu.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
             * */
        }
        public frmChucVu()
        {
            InitializeComponent();
        }
        private void Load_Luoi()
        {
            try
            {
                

                list = ChucVuList.GetChucVuListAll();
                ChucVu_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.rptChucVu();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_ChucVusAll";
            //command.Parameters.AddWithValue("@MaChiNhanh", _MaChiNhanh);
            //command.Parameters.AddWithValue("@TuNgay", _TuNgay);
            //command.Parameters.AddWithValue("@DenNgay", _DenNgay);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_ChucVusAll;1";

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

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i != j)
                    {
                        if (list[i].MaQLChucVu.Trim() == list[j].MaQLChucVu.Trim())
                        {
                            ChucVu cv = ChucVu.GetChucVu(list[i].MaChucVu);
                            MessageBox.Show(this, "Chức Vụ " + cv.TenChucVu.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdChucVu.ActiveRow = ultragrdChucVu.Rows[i];
                            ultragrdChucVu.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();

            tlslblIn.Visible = true;
            toolStripLabel1.Visible = false;
           

        }

      
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
                #region Kiemtra Luới
                for (int i = 0; i < ultragrdChucVu.Rows.Count; i++)
                {
                   
                    if (ultragrdChucVu.Rows[i].Cells["MaQLChucVu"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Chức Vụ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdChucVu.ActiveRow = ultragrdChucVu.Rows[i];
                        return;
                    }
                    if (ultragrdChucVu.Rows[i].Cells["TenChucVu"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Chức Vụ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdChucVu.ActiveRow = ultragrdChucVu.Rows[i];
                        return;
                    }
                }
                #endregion

                if (KiemTraMaQuanLy() == true)
                {
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Luoi();
                    if (passData != null)
                        passData(this.list);
                }
            }
            catch (ApplicationException)
            {

            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdChucVu.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa,util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdChucVu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void Undo()
        {
            this.Load_Luoi();
          
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void frmChucVu_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            if (e.Control && e.KeyCode == Keys.U)
            {
                Undo();
            }
            if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

     

        private void grdu_QuocGia_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
          
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            //ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Header.Caption = "Mã Chức Vụ";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Header.VisiblePosition = 0;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["MaQLChucVu"].Width = 100;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 1;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenChucVu"].Width = 150;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 2;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenVietTat"].Width = 90;

            //ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Header.Caption = "Tên Nhóm Chức Vụ";
            //ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Header.VisiblePosition = 0;
            //ultragrdChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Width = 150;

            ultragrdChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            ultragrdChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;

            //ultragrdChucVu.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //this.ultragrdChucVu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.ultragrdChucVu.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

        }

        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  ultragrdChucVu.UpdateData();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdChucVu);
        }

    }
}
