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
    public partial class frmNhomChucDanh : Form
    {
        Util util = new Util();
        NhomChucDanhList list;

        public frmNhomChucDanh()
        {
            InitializeComponent();
            this.Load_Luoi();
        }

        private void Load_Luoi()
        {
            try
            {
                list = NhomChucDanhList.GetNhomChucDanhList();
                NhomChucdanh_bindingSource.DataSource = list;
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
                            NhomChucDanh cv = NhomChucDanh.GetNhomChucDanh(list[i].MaNhomChucDanh);
                            MessageBox.Show(this, "Chức Danh " + cv.TenNhomChucDanh.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_NhomChucDanh.ActiveRow = grdu_NhomChucDanh.Rows[i];
                            grdu_NhomChucDanh.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void grdu_NhomChucDanh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            grdu_NhomChucDanh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grdu_NhomChucDanh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grdu_NhomChucDanh.DisplayLayout.Bands[0].Columns["MaNhomChucDanh"].Hidden = true;
            grdu_NhomChucDanh.DisplayLayout.Bands[0].Columns["TenNhomChucDanh"].Header.Caption = "Tên Nhóm Chức Danh";
            grdu_NhomChucDanh.DisplayLayout.Bands[0].Columns["TenNhomChucDanh"].Width = 220;
            grdu_NhomChucDanh.DisplayLayout.Bands[0].Columns["TenNhomChucDanh"].Header.VisiblePosition = 1;
            grdu_NhomChucDanh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            grdu_NhomChucDanh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            foreach (UltraGridColumn col in grdu_NhomChucDanh.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }       

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                #region Kiemtra Luới
                for (int i = 0; i < grdu_NhomChucDanh.Rows.Count; i++)
                {
                    if (grdu_NhomChucDanh.Rows[i].Cells["MaQuanLy"].Text == "") 
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Nhóm Chức Danh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_NhomChucDanh.ActiveRow = grdu_NhomChucDanh.Rows[i];
                        return;
                    }
                    if (grdu_NhomChucDanh.Rows[i].Cells["TenNhomChucDanh"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Nhóm Chức Danh", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_NhomChucDanh.ActiveRow = grdu_NhomChucDanh.Rows[i];
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
            catch (Exception ex)
            {
                MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw ex;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_NhomChucDanh.DeleteSelectedRows();
        }

        private void grdu_NhomChucDanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
              //  grdu_NhomChucDanh.UpdateData();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_NhomChucDanh);
        }
    }
}