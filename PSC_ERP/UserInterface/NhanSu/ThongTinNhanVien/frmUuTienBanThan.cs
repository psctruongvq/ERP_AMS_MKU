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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{    
    public partial class frmUuTienBanThan : Form
    {
        Util util=new Util();
        UuTienBanThanList list;
        UuTienBanThan _UuTienBanThan;
        public delegate void PassData(UuTienBanThanList value);
        public PassData getData;
        
        public frmUuTienBanThan()
        {
            InitializeComponent();
        }
        
        private void Load_LenLuoi()
        {
            try
            {
                list = UuTienBanThanList.GetUuTienBanThanList();
                UuTienBanThanBindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }
        
        private void frmUuTienBanThan_Load(object sender, EventArgs e)
        {
            Load_LenLuoi();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdUuTienBanThan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdUuTienBanThan.DeleteSelectedRows();
        }
        
        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 1; i < ultragrdUuTienBanThan.Rows.Count; i++)
            {
                //_UuTienBanThan = list[i];
                if (ultragrdUuTienBanThan.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdUuTienBanThan.ActiveRow = ultragrdUuTienBanThan.Rows[i];
                    return kq;
                }
                if (ultragrdUuTienBanThan.Rows[i].Cells["UuTienBT"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Ưu Tiên Bản Thân", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdUuTienBanThan.ActiveRow = ultragrdUuTienBanThan.Rows[i];
                    return kq;
                }
            }
            return kq;
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
                            UuTienBanThan cd = UuTienBanThan.GetUuTienBanThan(list[i].MaUuTienBanThan);
                            MessageBox.Show(this, "Ưu tiên " + cd.UuTienBT.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdUuTienBanThan.ActiveRow = ultragrdUuTienBanThan.Rows[i];
                            ultragrdUuTienBanThan.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra_Luoi() == true)
                {
                    if (KiemTraMaQuanLy() == true)
                    {
                        try
                        {
                            list.ApplyEdit();
                            list.Save();
                            MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (getData != null)
                            {
                                getData(list);
                            }
                        }
                        catch (ApplicationException)
                        {

                        }
                        //this.Load_LenLuoi();
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }        

        private void ultragrdUuTienBanThan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdUuTienBanThan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.ultragrdUuTienBanThan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdUuTienBanThan.DisplayLayout.Bands[0].Columns["MaUuTienBanThan"].Hidden = true;
            ultragrdUuTienBanThan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdUuTienBanThan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;
            ultragrdUuTienBanThan.DisplayLayout.Bands[0].Columns["UuTienBT"].Header.Caption = "Ưu Tiên Bản Thân";
            ultragrdUuTienBanThan.DisplayLayout.Bands[0].Columns["UuTienBT"].Width = 300;

            foreach (UltraGridColumn col in this.ultragrdUuTienBanThan.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_LenLuoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdUuTienBanThan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdUuTienBanThan.UpdateData();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_UuTienBanThansAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptUuTienBanThan(), new frmHienThiReport(), false);                     
        }

        private void ultragrdUuTienBanThan_Leave(object sender, EventArgs e)
        {
            ultragrdUuTienBanThan.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdUuTienBanThan);
        }
        
    }
}