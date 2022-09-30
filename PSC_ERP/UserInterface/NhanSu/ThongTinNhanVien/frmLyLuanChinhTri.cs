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
    public partial class frmLyLuanChinhTri : Form
    {
        public delegate void PassData(LyLuanChinhTriList value);
        public PassData getData;
        Util util=new Util();
        LyLuanChinhTriList list;
        public frmLyLuanChinhTri()
        {
            InitializeComponent();
        }

        private void frmLyLuanChinhTri_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }                

        private void Load_Luoi()
        {
            try
            {
                list = LyLuanChinhTriList.GetLyLuanChinhTriList();
                LyLuanChinhTri_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 1; i < ultragrdLyLuanChinhTri.Rows.Count; i++)
            {
                if (ultragrdLyLuanChinhTri.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdLyLuanChinhTri.ActiveRow = ultragrdLyLuanChinhTri.Rows[i];
                    return kq;
                }
                if (ultragrdLyLuanChinhTri.Rows[i].Cells["LyLuanCT"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Lý Luận Chính Trị", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdLyLuanChinhTri.ActiveRow = ultragrdLyLuanChinhTri.Rows[i];
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
                            LyLuanChinhTri cd = LyLuanChinhTri.GetLyLuanChinhTri(list[i].MaLyLuanCT);
                            MessageBox.Show(this, "Lý luận chính trị " + cd.LyLuanCT.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdLyLuanChinhTri.ActiveRow = ultragrdLyLuanChinhTri.Rows[i];
                            ultragrdLyLuanChinhTri.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void ultragrdLyLuanChinhTri_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdLyLuanChinhTri.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdLyLuanChinhTri.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdLyLuanChinhTri.DisplayLayout.Bands[0].Columns["MaLyLuanCT"].Hidden = true;
            ultragrdLyLuanChinhTri.DisplayLayout.Bands[0].Columns["LyLuanCT"].Header.Caption = "Tên lý luận chính trị";
            ultragrdLyLuanChinhTri.DisplayLayout.Bands[0].Columns["LyLuanCT"].Width = 400;
            ultragrdLyLuanChinhTri.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdLyLuanChinhTri.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;

            foreach (UltraGridColumn col in ultragrdLyLuanChinhTri.DisplayLayout.Bands[0].Columns)
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
                        if (getData != null)
                        {
                            getData(list);
                        }
                    }
                }
            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdLyLuanChinhTri.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdLyLuanChinhTri.DeleteSelectedRows();
        }

        private void ultragrdLyLuanChinhTri_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdLyLuanChinhTri.UpdateData();
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnslyluanchinhtrisAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptLyluanCT(), new frmHienThiReport(), false);           

        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdLyLuanChinhTri);
        }

    }
}