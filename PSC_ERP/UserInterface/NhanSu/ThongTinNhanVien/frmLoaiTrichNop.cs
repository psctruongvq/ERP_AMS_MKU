using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmLoaiTrichNop : Form
    {
        #region Properties
        Util util = new Util();
        LoaiTrichNopList list;
        #endregion

        #region Events
        public frmLoaiTrichNop()
        {
            InitializeComponent();
        }

        private void Load_Luoi()
        {
            try
            {
                list = LoaiTrichNopList.GetLoaiTrichNopList();
                LoaiTrichNop_bindingSource.DataSource = list;
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
                            LoaiTrichNop cv = LoaiTrichNop.GetLoaiTrichNop(list[i].MaLoaiTrichNop);
                            MessageBox.Show(this, "Loại Trích Nộp" + cv.TenLoaiTrichNop.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdLoaiTrichNop.ActiveRow = ultragrdLoaiTrichNop.Rows[i];
                            ultragrdLoaiTrichNop.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmLoaiTrichNop_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private Boolean KiemTraControl()
        {
            Boolean kq = true;
            foreach (Control control in groupBox2.Controls)
            {
                if (errorProvider1.GetError(control) != String.Empty)
                {
                    if (control.Name == ultratxtMaLoaiTrichNop.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Trích Nộp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    if (control.Name == ultratxtTenLoaiTrichNop.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Trích Nộp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    if (control.Name == ultracmbeCongTruLuong.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng chọn cộng trừ lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    if (control.Name == ultracmbeTinhThueThuNhap.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng chọn tính thuế thu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    if (control.Name == ultracmbeTinhVaoLuong.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng chọn tính vào lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                }
            }
            return kq;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            ultratxtMaLoaiTrichNop.Focus();
            LoaiTrichNop obj;
            for (int i = 0; i < list.Count; i++)
            {
                obj = list[i];
                if (obj.MaQuanLy == "")
                {
                    return;
                }                
            }
            obj = LoaiTrichNop.NewLoaiTrichNop();
            list.Add(obj);
            ultragrdLoaiTrichNop.ActiveRow = ultragrdLoaiTrichNop.Rows[list.Count - 1];
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraControl())
            {
                return;
            }
            try
            {
                #region Kiemtra Luới
                for (int i=0;i<ultragrdLoaiTrichNop.Rows.Count;i++)
                {
                    if (ultragrdLoaiTrichNop.Rows[i].Cells["MaQuanLy"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Loại Trích Nộp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdLoaiTrichNop.ActiveRow = ultragrdLoaiTrichNop.Rows[i];
                        return;
                    }
                    if (ultragrdLoaiTrichNop.Rows[i].Cells["TenLoaiTrichNop"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Loại Trích Nộp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdLoaiTrichNop.ActiveRow = ultragrdLoaiTrichNop.Rows[i];
                        return;
                    }
                    if (ultragrdLoaiTrichNop.Rows[i].Cells["TinhVaoLuong"].Value.ToString() == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Tính Vào Lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdLoaiTrichNop.ActiveRow = ultragrdLoaiTrichNop.Rows[i];
                        return;
                    }
                    if (ultragrdLoaiTrichNop.Rows[i].Cells["CongTruLuong"].Value.ToString() == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Cộng Trừ Lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdLoaiTrichNop.ActiveRow = ultragrdLoaiTrichNop.Rows[i];
                        return;
                    }
                    if (ultragrdLoaiTrichNop.Rows[i].Cells["TinhThueThuNhap"].Value.ToString() == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Tính Tính Thuế Thu Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdLoaiTrichNop.ActiveRow = ultragrdLoaiTrichNop.Rows[i];
                        return;
                    }
                }
                #endregion

                if (KiemTraMaQuanLy() == true)
                {
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Load_Luoi();
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
            if (ultragrdLoaiTrichNop.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdLoaiTrichNop.DeleteSelectedRows();
        }
        #endregion

        #region ultragrdLoaiTrichNop_InitializeLayout
        private void ultragrdLoaiTrichNop_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["MaLoaiTrichNop"].Hidden = true;
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["TinhThueThuNhap"].Hidden = true;

            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Lọai Trích Nộp";
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 70;

            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["TenLoaiTrichNop"].Header.Caption = "Tên Lọai Trích Nộp";
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["TenLoaiTrichNop"].Header.VisiblePosition = 1;
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["TenLoaiTrichNop"].Width = 100;

            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["TinhVaoLuong"].Header.Caption = "Tính Vào Lương";
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["TinhVaoLuong"].Header.VisiblePosition = 2;
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["TinhVaoLuong"].Width = 100;

            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["CongTruLuong"].Header.Caption = "Cộng Trừ Lương";
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["CongTruLuong"].Header.VisiblePosition = 3;
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["CongTruLuong"].Width = 100;

            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 4;
            ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 200;

            foreach (UltraGridColumn col in ultragrdLoaiTrichNop.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();      
            h.ShowReport(new string[] { "spd_report_LoaiTrichNopsAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptLoaiTrichNop(), new frmHienThiReport(), false);
            
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}