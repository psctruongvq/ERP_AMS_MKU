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
    public partial class frmTacDongDen : Form
    {
        Util util=new Util();
        TacDongDenClassList list;

        public frmTacDongDen()
        {
            InitializeComponent();
        }

        private void frmTacDongDen_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }
        
        private void Load_Luoi()
        {
            try
            {
                list = TacDongDenClassList.GetTacDongDenClassList();
                TacdongDen_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 1; i < ultragrdtacDongDen.Rows.Count; i++)
            {
                if (ultragrdtacDongDen.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdtacDongDen.ActiveRow = ultragrdtacDongDen.Rows[i];
                    return kq;
                }
                if (ultragrdtacDongDen.Rows[i].Cells["TacDongDen"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Tác Động Đến", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdtacDongDen.ActiveRow = ultragrdtacDongDen.Rows[i];
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
                            TacDongDenClass cd = TacDongDenClass.GetTacDongDenClass(list[i].MaTacDongDen);
                            MessageBox.Show(this, "Tác động đến " + cd.TacDongDen.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdtacDongDen.ActiveRow = ultragrdtacDongDen.Rows[i];
                            ultragrdtacDongDen.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        
        private void ultragrdtacDongDen_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdtacDongDen.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdtacDongDen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdtacDongDen.DisplayLayout.Bands[0].Columns["MaTacDongDen"].Hidden = true;
            ultragrdtacDongDen.DisplayLayout.Bands[0].Columns["TacDongDen"].Header.Caption = "Tên Tác Động";
            ultragrdtacDongDen.DisplayLayout.Bands[0].Columns["TacDongDen"].Width = 200;
            ultragrdtacDongDen.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdtacDongDen.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;

            foreach (UltraGridColumn col in ultragrdtacDongDen.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra_Luoi() == true)
                {
                    if (KiemTraMaQuanLy() == true)
                    {
                        list.ApplyEdit();
                        list.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Load_Luoi();
                    }
                }
            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdtacDongDen.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdtacDongDen.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdtacDongDen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdtacDongDen.UpdateData();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            //h.ShowReport(new string[] { "spd_report_tblnstacdongdensAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptTacdongden(), new frmHienThiReport(), false);           

        }

        private void ultragrdtacDongDen_Leave(object sender, EventArgs e)
        {
            ultragrdtacDongDen.UpdateData();
        }
    }
}