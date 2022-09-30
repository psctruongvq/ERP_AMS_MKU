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


namespace PSC_ERP
{
    public partial class frmNganHang : Form
    {
        public delegate void PassData(NganHangList value);
        public PassData getData;
        Util util = new Util();
        NganHangList _nganHangList;
        TinhThanhList _TinhThanhList;
        NhomNganHangList _nhomNganHangList;

        public frmNganHang()
        {
            InitializeComponent();
            LoadForm();
        }
        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < grd_NganHang.Rows.Count; i++)
            {
                if (grd_NganHang.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grd_NganHang.ActiveRow = grd_NganHang.Rows[i];
                    return kq;
                }
                if (grd_NganHang.Rows[i].Cells["TenNganHang"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Ngân Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grd_NganHang.ActiveRow = grd_NganHang.Rows[i];
                    return kq;
                }
            }
            return kq;
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _nganHangList.Count; i++)
            {
                for (int j = 0; j < _nganHangList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_nganHangList[i].MaQuanLy.Trim() == _nganHangList[j].MaQuanLy.Trim())
                        {
                            NganHang cd = NganHang.GetNganHang(_nganHangList[i].MaNganHang);
                            MessageBox.Show(this, "Ngân hàng " + cd.TenNganHang.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grd_NganHang.ActiveRow = grd_NganHang.Rows[i];
                            grd_NganHang.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void LoadForm()
        {
            try
            {
                _nganHangList = NganHangList.GetNganHangList();
                NganHang_bindingSource1.DataSource = _nganHangList;

                _TinhThanhList = TinhThanhList.GetTinhThanhList();
                TinhThanh tt = TinhThanh.NewTinhThanh(0, "Tất Cả");
                _TinhThanhList.Insert(0,tt);
                TinhThanh_BindingSource.DataSource = _TinhThanhList;
                cmbu_TinhThanh.DataSource = TinhThanh_BindingSource;

                _nhomNganHangList = NhomNganHangList.GetNhomNganHangList();
                NhomNganHang _nhomNganHang = NhomNganHang.NewNhomNganHang("Chưa chọn");
                _nhomNganHangList.Insert(0, _nhomNganHang);
                NhomNganHang_bindingSource.DataSource = _nhomNganHangList;
                cmb_NhomNganHang.DataSource = NhomNganHang_bindingSource;
            }
            catch (ApplicationException)
            {

            }
        }

        private void ultragrdNganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            grd_NganHang.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grd_NganHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            foreach (UltraGridColumn col in this.grd_NganHang.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            grd_NganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Hidden = false;
            grd_NganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";
            grd_NganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 250;
            grd_NganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 1;

            grd_NganHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = false;
            grd_NganHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            grd_NganHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 2;
            grd_NganHang.DisplayLayout.Bands[0].Columns["TenVietTat"].Width = 100;


            grd_NganHang.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Hidden = false;            
            grd_NganHang.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Header.Caption = "Tên Chi Nhánh";
            grd_NganHang.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Header.VisiblePosition = 3;
            grd_NganHang.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Width = 150;

            grd_NganHang.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = false;
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaTinhThanh"].EditorComponent = cmbu_TinhThanh;
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.Caption = "Tỉnh Thành";
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.VisiblePosition = 4;
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Width = 150;

            grd_NganHang.DisplayLayout.Bands[0].Columns["MaNhomNganHang"].Hidden = false;
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaNhomNganHang"].EditorComponent = cmb_NhomNganHang;
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaNhomNganHang"].Header.Caption = "Thuộc ngân hàng";
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaNhomNganHang"].Header.VisiblePosition = 6;
            grd_NganHang.DisplayLayout.Bands[0].Columns["MaNhomNganHang"].Width = 250;           
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
                if (KiemTra_Luoi() == true)
                {
                    if (KiemTraMaQuanLy() == true)
                    {
                        grd_NganHang.UpdateData();
                        NganHang_bindingSource1.EndEdit();
                        _nganHangList.ApplyEdit();
                        _nganHangList.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //LoadForm();
                        if (getData != null)
                        {
                            getData(_nganHangList);
                        }
                    }
                }

            }
            catch (ApplicationException)
            {

            }
        }
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grd_NganHang.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa,util.thongbao,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            grd_NganHang.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LoadForm();
        }

        private void ultragrdNganHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdNganHang.UpdateData();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_NganHangsAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptNganHang(), new frmHienThiReport(), false);
        }

        private void frmNganHang_KeyDown(object sender, KeyEventArgs e)
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
                LoadForm();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grd_NganHang);
        }
    }
}
