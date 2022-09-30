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
    public partial class frmLyDoThoiViec : Form
    {
        Util util=new Util();
        LyDoThoiViecList list;

        public frmLyDoThoiViec()
        {
            InitializeComponent();
        }

        private void Load_LenLuoi()
        {
            try
            {
                list = LyDoThoiViecList.GetLyDoThoiViecList();
                LyDoThoiViecbindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 1; i < ultragrdLyDoThoiViec.Rows.Count; i++)
            {
                if (ultragrdLyDoThoiViec.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdLyDoThoiViec.ActiveRow = ultragrdLyDoThoiViec.Rows[i];
                    return kq;
                }
                if (ultragrdLyDoThoiViec.Rows[i].Cells["LyDo"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Lý Do", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdLyDoThoiViec.ActiveRow = ultragrdLyDoThoiViec.Rows[i];
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
                            LyDoThoiViec cd = LyDoThoiViec.GetLyDoThoiViec(list[i].MaLyDoThoiViec);
                            MessageBox.Show(this, "Lý do thôi việc " + cd.LyDo.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdLyDoThoiViec.ActiveRow = ultragrdLyDoThoiViec.Rows[i];
                            ultragrdLyDoThoiViec.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmLyDoThoiViec_Load(object sender, EventArgs e)
        {
            this.Load_LenLuoi();
        }

        private void ultragrdLyDoThoiViec_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdLyDoThoiViec.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdLyDoThoiViec.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdLyDoThoiViec.DisplayLayout.Bands[0].Columns["MaLyDoThoiViec"].Hidden = true;
            ultragrdLyDoThoiViec.DisplayLayout.Bands[0].Columns["LyDo"].Header.Caption = "Lý Do Thôi Việc";
            ultragrdLyDoThoiViec.DisplayLayout.Bands[0].Columns["LyDo"].Width = 400;
            ultragrdLyDoThoiViec.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdLyDoThoiViec.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;

            foreach (UltraGridColumn col in ultragrdLyDoThoiViec.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdLyDoThoiViec.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdLyDoThoiViec.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_LenLuoi();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
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
                    }
                    catch (ApplicationException)
                    {

                    }
                    //this.Load_LenLuoi();
                }
            }
        }

        private void ultragrdLyDoThoiViec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdLyDoThoiViec.UpdateData();
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnsLydothoiviecsAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptLydothoiviec(), new frmHienThiReport(), false);           

        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdLyDoThoiViec);
        }
    }
}