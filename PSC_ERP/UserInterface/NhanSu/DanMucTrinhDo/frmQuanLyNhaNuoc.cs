using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmQuanLyNhaNuoc : Form
    {
        Util util=new Util();
        QuanLyNhaNuocList list;
        public delegate void PassData(QuanLyNhaNuocList value);
        public PassData getData;

        public frmQuanLyNhaNuoc()
        {
            InitializeComponent();
        }

   

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
                   list.ApplyEdit();
                        list.Save();
                        MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Load_LenLuoi();
                        if (getData != null)
                        {
                            getData(list);
                        }
                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Load_LenLuoi()
        {
            try
            {
                list = QuanLyNhaNuocList.GetQuanLyNhaNuocList();
                bindingSource1_QuanLyNhaNuoc.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void frmQuanLyKinhTe_Load(object sender, EventArgs e)
        {
            this.Load_LenLuoi(); 
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdNgoaiNgu.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdNgoaiNgu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_LenLuoi();
        }

        private void ultragrdNgoaiNgu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            //ultragrdNgoaiNgu.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdNgoaiNgu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

          
            foreach (UltraGridColumn col in this.ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition =0;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 200;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Hidden = false;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Header.Caption = "Tên Trình Độ";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Header.VisiblePosition = 1;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenQuanLyNhaNuoc"].Width = 200;

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdNgoaiNgu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdNgoaiNgu.UpdateData();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_NgoaiNgusAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptNgoaiNgu(), new frmHienThiReport(), false);
        }

        private void frmQuanLyKinhTe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F1)
            {
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                Load_LenLuoi();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void QuanLyNhaNuoc_bindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void frmQuanLyNhaNuoc_Load(object sender, EventArgs e)
        {
            list = QuanLyNhaNuocList.GetQuanLyNhaNuocList();
            this.bindingSource1_QuanLyNhaNuoc.DataSource = list;
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdNgoaiNgu);
        }
    }
}
