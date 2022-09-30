using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmDanhHieu : Form
    {
      
       
        DanhHieuList list;
     
        public frmDanhHieu()
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

                bindingSource1.EndEdit();
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show("Cập nhật thành công","Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Luoi();
                  
                
            }
            catch (ApplicationException)
            {

            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
           
            ultragrdChucVu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void frmDanToc_Load(object sender, EventArgs e)
        {
            list = DanhHieuList.GetDanhHieuList();
            this.bindingSource1.DataSource = list;
        }

        private void Load_Luoi()
        {
            try
            {
                list = DanhHieuList.GetDanhHieuList();
                this.bindingSource1.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void ultragrdDanToc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            //t.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdDanToc.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdDanToc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            //ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaDanToc"].Hidden = true;
            //ultragrdDanToc.DisplayLayout.Bands[0].Columns["DanToc"].Header.Caption = "Tên Dân Tộc";
            //ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            //ultragrdDanToc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;
            //ultragrdDanToc.DisplayLayout.Bands[0].Columns["DanToc"].Width = 400;

            //foreach (UltraGridColumn col in ultragrdDanToc.DisplayLayout.Bands[0].Columns)
            //{
            //    col.SortIndicator = SortIndicator.Ascending; 
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = Color.Navy;
            //}
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdDanToc.UpdateData();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
        //    h.ShowReport(new string[] { "spd_report_DanTocsAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptDanToc(), new frmHienThiReport(), false);

        }

        private void frmDanToc_KeyDown(object sender, KeyEventArgs e)
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
                Load_Luoi();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void ultragrdChucVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdChucVu);
        }


    }
}
