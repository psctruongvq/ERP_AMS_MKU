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
    public partial class frmNhomChucVu : Form
    {
        Util util = new Util();
        NhomChucvuList list;

        public frmNhomChucVu()
        {
            InitializeComponent();
        }

        private void Load_Luoi()
        {
            try
            {
                list = NhomChucvuList.GetNhomChucvuList();
                NhomChucVu_bindingSource.DataSource = list;
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
                            NhomChucvu cv = NhomChucvu.GetNhomChucvu(list[i].MaNhomChucVu);
                            MessageBox.Show(this, "Chức Vụ " + cv.TenNhomChucVu.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdNhomChucVu.ActiveRow = ultragrdNhomChucVu.Rows[i];
                            ultragrdNhomChucVu.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmNhomChucVu_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdNhomChucVu.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdNhomChucVu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            #region Kiemtra Luới
            for (int i = 0; i < ultragrdNhomChucVu.Rows.Count; i++)
            {
                if (ultragrdNhomChucVu.Rows[i].Cells["MaQuanLy"].Text == "") 
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Nhóm Chức Vụ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdNhomChucVu.ActiveRow = ultragrdNhomChucVu.Rows[i];
                    return;
                }
                if (ultragrdNhomChucVu.Rows[i].Cells["TenNhomChucVu"].Text == "")
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Nhóm Chức Vụ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdNhomChucVu.ActiveRow = ultragrdNhomChucVu.Rows[i];
                    return;
                }
            }
            #endregion

            if (KiemTraMaQuanLy() == true)
            {
                try
                {
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ApplicationException)
                {

                }
                //this.Load_Luoi();
            }
        }

        private void ultragrdNhomChucVu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdNhomChucVu.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdNhomChucVu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns["MaNhomChucVu"].Hidden = true;
            ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Header.Caption = "Tên Nhóm Chức Vụ";
            ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Header.VisiblePosition = 1;
            ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns["TenNhomChucVu"].Width = 200;
            ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 230;
            ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 2;

            foreach (UltraGridColumn col in ultragrdNhomChucVu.DisplayLayout.Bands[0].Columns)
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
            h.ShowReport(new string[] { "spd_Report_tblnsNhomchucvuAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptNhomchucvu(), new frmHienThiReport(), false);

        }

        private void ultragrdNhomChucVu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ultragrdNhomChucVu.UpdateData();
            }
        }

        private void ultragrdNhomChucVu_Leave(object sender, EventArgs e)
        {
           //  ultragrdNhomChucVu.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdNhomChucVu);
        }
    }
}