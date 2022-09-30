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
    public partial class frmHinhThucNghi : Form
    {
        #region properties
        HinhThucNghiList list;
        public frmHinhThucNghi()
        {
            InitializeComponent();
        }
        #endregion

        #region Load_Luoi
        private void Load_Luoi()
        {
            try
            {
                list = HinhThucNghiList.GetHinhThucNghiList();
                HinhThucNghi_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }
        #endregion

        #region frmHinhThucNghi_Load
        private void frmHinhThucNghi_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }
        #endregion

        #region KiemTraControl
        private Boolean KiemTraControl()
        {
            Boolean kq = true;
            foreach (Control control in groupBox2.Controls)
            {
                if (errorProvider1.GetError(control) != String.Empty)
                {
                    if (control.Name == ultratxtMaHinhThuc.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Hình Thức Nghỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    if (control.Name == ultratxtTenHinhThuc.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Hình Thức Nghỉ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                }
            }
            return kq;
        }
        #endregion

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
                            HinhThucNghi qg = HinhThucNghi.GetHinhThucNghi(list[i].MaHinhThucNghi);
                            MessageBox.Show(this, "Hình thức nghỉ " + qg.TenHinhThucNghi.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdHinhThucNghi.ActiveRow = ultragrdHinhThucNghi.Rows[i + 1];
                            ultragrdHinhThucNghi.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }


        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            ultratxtMaHinhThuc.Focus();
            HinhThucNghi obj;
            for (int i = 0; i < list.Count; i++)
            {
                obj = list[i];
                if (obj.MaQuanLy == "")
                {
                    return;
                }
            }
            obj = HinhThucNghi.NewHinhThucNghi();
            list.Add(obj);
            ultragrdHinhThucNghi.ActiveRow = ultragrdHinhThucNghi.Rows[list.Count - 1];
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
                if (!KiemTraControl())
                {
                    return;
                }
                for (int i = 0; i < list.Count; i++)
                {

                    if (ultragrdHinhThucNghi.Rows[i].Cells["MaQuanLy"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Hình Thức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdHinhThucNghi.ActiveRow = ultragrdHinhThucNghi.Rows[i];
                        return;
                    }
                    if (ultragrdHinhThucNghi.Rows[i].Cells["TenHinhThucNghi"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Hình Thức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdHinhThucNghi.ActiveRow = ultragrdHinhThucNghi.Rows[i];
                        return;
                    }
                    if (ultragrdHinhThucNghi.Rows[i].Cells["TruLuong"].Value.ToString() == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Trừ Lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdHinhThucNghi.ActiveRow = ultragrdHinhThucNghi.Rows[i];
                        return;
                    }
                }
                try
                {
                    HinhThucNghi_bindingSource.EndEdit();
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Luoi();
                }
                catch (ApplicationException)
                {

                }
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdHinhThucNghi.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Bạn Phải Chọn Dòng Cần Xóa Trên Lưới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdHinhThucNghi.DeleteSelectedRows();
        }
        #endregion

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }
        #endregion

        private void ultragrdHinhThucNghi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung dungChung = new HamDungChung();
            dungChung.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdHinhThucNghi.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdHinhThucNghi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["MaHinhThucNghi"].Hidden = true;
            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["TenHinhThucNghi"].Header.Caption = "Tên Kỷ Luật";
            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;            
            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 2;
            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["PhanTramluong"].Header.Caption = "Phần Trăm Lương";
            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 3;
            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 4;

            foreach (UltraGridColumn colum in ultragrdHinhThucNghi.DisplayLayout.Bands[0].Columns)
            {
                colum.SortIndicator = SortIndicator.Ascending;
                colum.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                colum.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                colum.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnshinhthucnghiAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptHinhthucnghi(), new frmHienThiReport(), false);           
        }

        private void ultragrdHinhThucNghi_KeyDown(object sender, KeyEventArgs e)
        {
            ultragrdHinhThucNghi.UpdateData();
        }

        private void ultragrdHinhThucNghi_Leave(object sender, EventArgs e)
        {
            ultragrdHinhThucNghi.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdHinhThucNghi);
        }
    }
}