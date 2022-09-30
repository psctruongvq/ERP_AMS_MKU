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
    public partial class frmLoaiTaiNan : Form
    {
        Util util = new Util();
        LoaiTaiNanList list;

        public frmLoaiTaiNan()
        {
            InitializeComponent();
        }

        private void Load_Luoi()
        {
            try
            {
                list = LoaiTaiNanList.GetLoaiTaiNanList();
                LoaiTaiNan_bindingSource.DataSource = list;
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
                            LoaiTaiNan cv = LoaiTaiNan.GetLoaiTaiNan(list[i].MaLoaiTaiNan);
                            MessageBox.Show(this, "Loại Tai Nạn" + cv.TenLoaiTaiNan.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdLoaiTaiNan.ActiveRow = ultragrdLoaiTaiNan.Rows[i];
                            ultragrdLoaiTaiNan.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            #region Kiemtra Luới
            for (int i = 0; i < ultragrdLoaiTaiNan.Rows.Count; i++)
            {
                if (ultragrdLoaiTaiNan.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Tai Nạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdLoaiTaiNan.ActiveRow = ultragrdLoaiTaiNan.Rows[i];
                    return;
                }
                if (ultragrdLoaiTaiNan.Rows[i].Cells["TenLoaiTaiNan"].Text == "")
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Tai Nạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdLoaiTaiNan.ActiveRow = ultragrdLoaiTaiNan.Rows[i];
                    return;
                }
            }
            #endregion

            if (KiemTraMaQuanLy())
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
                //this.Load_Luoi();
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdLoaiTaiNan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdLoaiTaiNan.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void frmLoaiTaiNan_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void ultragrdLoaiTaiNan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdLoaiTaiNan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdLoaiTaiNan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdLoaiTaiNan.DisplayLayout.Bands[0].Columns["MaLoaiTaiNan"].Hidden = true;
            ultragrdLoaiTaiNan.DisplayLayout.Bands[0].Columns["TenLoaiTaiNan"].Header.Caption = "Tên Loại Tai Nạn";
            ultragrdLoaiTaiNan.DisplayLayout.Bands[0].Columns["TenLoaiTaiNan"].Width = 400;
            ultragrdLoaiTaiNan.DisplayLayout.Bands[0].Columns["TenLoaiTaiNan"].Header.VisiblePosition = 1;
            ultragrdLoaiTaiNan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdLoaiTaiNan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdLoaiTaiNan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;

            foreach (UltraGridColumn col in ultragrdLoaiTaiNan.DisplayLayout.Bands[0].Columns)
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

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_LoaiTaiNansAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptLoaiTaiNan(), new frmHienThiReport(), false);

        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdLoaiTaiNan);
        }


    }
}