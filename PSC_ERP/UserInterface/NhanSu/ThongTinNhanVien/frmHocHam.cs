using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmHocHam : Form
    {
        // Hoi tao
        Util util=new Util();
        HocHamList list;
        HocHam _HocHam;
        
        public frmHocHam()
        {
            InitializeComponent();
        }
        
        private bool KiemTra_Luoi() 
        {
            bool kq = true;
            for (int i = 0; i < ultragrdHocHam.Rows.Count; i++)//coi lai vong for i=1 
            {                
                if (ultragrdHocHam.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, util.nhapMaHocHam, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdHocHam.ActiveRow = ultragrdHocHam.Rows[i];
                    return kq;
                }
                if (ultragrdHocHam.Rows[i].Cells["TenHocHam"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, util.nhapTenHocHam, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdHocHam.ActiveRow = ultragrdHocHam.Rows[i];
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
                            HocHam qg = HocHam.GetHocHam(list[i].MaHocHam);
                            MessageBox.Show(this, "Học hàm " + qg.TenHocHam.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdHocHam.ActiveRow = ultragrdHocHam.Rows[i];
                            ultragrdHocHam.Focus();
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
            for (int i = 0; i < list.Count - 1; i++)
            {
                _HocHam = list[i];
                if (_HocHam.MaQuanLy == "")
                {
                    MessageBox.Show(this, util.nhapMaHocHam, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdHocHam.ActiveRow = ultragrdHocHam.Rows[i];
                    return;
                }
                if (_HocHam.TenHocHam == "")
                {
                    MessageBox.Show(this, util.nhapTenHocHam, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdHocHam.ActiveRow = ultragrdHocHam.Rows[i];
                    return;
                }
            }
            if (KiemTraMaQuanLy() == true)
            {
                try
                {
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ApplicationException)
                {

                }
                //this.Load_LenLuoi();
            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdHocHam.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa,util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdHocHam.DeleteSelectedRows();
        }

        private void ultragrdHocHam_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdHocHam.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdHocHam.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdHocHam.DisplayLayout.Bands[0].Columns["MaHocHam"].Hidden = true;
            ultragrdHocHam.DisplayLayout.Bands[0].Columns["TenHocHam"].Header.Caption = "Tên Học Hàm";
            ultragrdHocHam.DisplayLayout.Bands[0].Columns["TenHocHam"].Width = 400;
            ultragrdHocHam.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdHocHam.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;

            foreach (UltraGridColumn col in ultragrdHocHam.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        
        private void Load_LenLuoi()
        {
            try
            {
                list = HocHamList.GetHocHamList();
                HocHam_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void frmHocHam_Load(object sender, EventArgs e)
        {
            this.Load_LenLuoi();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_LenLuoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdHocHam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ultragrdHocHam.UpdateData();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnsHochamsAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptHocham(), new frmHienThiReport(), false);           

        }

        private void frmHocHam_KeyDown(object sender, KeyEventArgs e)
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

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdHocHam);
        }
    }
}