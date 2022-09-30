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
    public partial class frmQuanHam : Form
    {
        Util util=new Util();
        QuanHamList list;
        public frmQuanHam()
        {
            InitializeComponent();
        }

        private void frmQuanHam_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }
        private void Load_Luoi()
        {
            try
            {
                list = QuanHamList.GetQuanHamList();
                QuanHam_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i != j)
                    {
                        if (list[i].MaQuanLy.Trim() == list[j].MaQuanLy.Trim())
                        {
                            QuanHam cd = QuanHam.GetQuanHam(list[i].MaQuanHam);
                            MessageBox.Show(this, "Quân hàm " + cd.TenQuanHam.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdQuanHam.ActiveRow = ultragrdQuanHam.Rows[i];
                            ultragrdQuanHam.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
                if (KiemTraMaQuanLy() == true)
                {
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    //this.Load_Luoi();
                }
            }
            catch (ApplicationException)
            {

            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdQuanHam.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdQuanHam.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void ultragrdQuanHam_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdQuanHam.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdQuanHam.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdQuanHam.DisplayLayout.Bands[0].Columns["MaQuanHam"].Hidden = true;
            ultragrdQuanHam.DisplayLayout.Bands[0].Columns["TenQuanHam"].Header.Caption = "Tên Quân Hàm";
            ultragrdQuanHam.DisplayLayout.Bands[0].Columns["TenQuanHam"].Width = 300;
            ultragrdQuanHam.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdQuanHam.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;

            foreach (UltraGridColumn col in ultragrdQuanHam.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdQuanHam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdQuanHam.UpdateData();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnsQuanhamsAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptQuanham(), new frmHienThiReport(), false);           

        }

        private void ultragrdQuanHam_Leave(object sender, EventArgs e)
        {
            ultragrdQuanHam.UpdateData();
        }

        private void frmQuanHam_KeyDown(object sender, KeyEventArgs e)
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

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdQuanHam);
        }
    }
}