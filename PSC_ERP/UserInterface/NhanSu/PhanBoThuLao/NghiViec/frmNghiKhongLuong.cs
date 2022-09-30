using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;


namespace PSC_ERP.UserInterface.NhanSu.NghiViec
{
    public partial class frmNghiKhongLuong : Form
    {

        private NhanVienComboList _nhanVienComboList;
        private int _bophan = 0;
        private long _nhanvien = 0;
        private NghiKhongLuongList _nghiKhongLuongList;
        private KyTinhLuongList _kyTinhLuongListTuKy;
        private KyTinhLuongList _kyTinhLuongListDenKy;
        public frmNghiKhongLuong()
        {
            InitializeComponent();
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            _nhanVienComboList = NhanVienComboList.GetNhanVienByMaBoPhan(Convert.ToInt32(cmbBoPhan.Value));
            ultraCombo_NhanVien.DataSource = _nhanVienComboList;

            _kyTinhLuongListTuKy = KyTinhLuongList.GetKyTinhLuongList();
            bd_TuKy.DataSource = _kyTinhLuongListTuKy;
            _kyTinhLuongListDenKy = KyTinhLuongList.GetKyTinhLuongList();
            bd_DeKy.DataSource = _kyTinhLuongListDenKy;
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            this.ultraCombo_NhanVien.Value = null;
            if ((this.cmbBoPhan.Value != null) && (((int)this.cmbBoPhan.Value) != 0))
            {
                _nhanVienComboList = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhan((int)this.cmbBoPhan.Value);
                ultraCombo_NhanVien.DataSource = _nhanVienComboList;
                nhanVienComboListBindingSource.DataSource = _nhanVienComboList;
                _bophan = (int)this.cmbBoPhan.Value;

            }
            else
            {
                ultraCombo_NhanVien.DataSource = NhanVienComboList.GetNhanVienAll();
            }         
        }

        private void ultraCombo_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(ultraCombo_NhanVien, "TenNhanVien");
            foreach (UltraGridColumn col in this.ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;

            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhận Viên";
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
        }

        private void ultraCombo_NhanVien_Leave(object sender, EventArgs e)
        {
            if (ultraCombo_NhanVien.ActiveRow != null)
            {
                if (Convert.ToInt32(ultraCombo_NhanVien.ActiveRow.Cells["MaNhanVien"].Value) != 0)
                {
                    _nghiKhongLuongList = NghiKhongLuongList.GetNghiKhongLuongList((Int64)ultraCombo_NhanVien.Value);
                    bdNghiKhongLuongList.DataSource = _nghiKhongLuongList;
                }
            }
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ultraCombo_NhanVien.ActiveRow.Cells["MaNhanVien"].Value) != 0)
            {
                NghiKhongLuong nkl = NghiKhongLuong.NewNghiKhongLuong();
                nkl.MaNhanVien = (long)ultraCombo_NhanVien.Value;
                _nghiKhongLuongList.Add(nkl);
                bdNghiKhongLuongList.DataSource = _nghiKhongLuongList;
                
                
            }
        }

        private void ultraCombo_TuKy_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(ultraCombo_TuKy, "TenKy");
            foreach (UltraGridColumn col in this.ultraCombo_TuKy.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["Thang"].Hidden = false;
            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["Thang"].Header.Caption = "Thang1";
            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["Thang"].Header.VisiblePosition = 1;

            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["Nam"].Hidden = false;
            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["Nam"].Header.Caption = "Năm";
            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["Nam"].Header.VisiblePosition = 2;

            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Nhận Viên";
            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["TenKy"].Width = 200;
            ultraCombo_TuKy.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
        }

        private void grdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
            e.Layout.Override.TemplateAddRowAppearance.BackColor = Color.FromArgb(245, 250, 255);
            e.Layout.Override.TemplateAddRowAppearance.ForeColor = SystemColors.GrayText;
            e.Layout.Override.AddRowAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.AddRowAppearance.ForeColor = Color.Blue;
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow;
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = SystemColors.Control;
            e.Layout.Override.TemplateAddRowPromptAppearance.ForeColor = Color.Maroon;
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.Caption = "Nhân Viên";
            grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"].EditorComponent = ultraCombo_NhanVien;
            grdData.DisplayLayout.Bands[0].Columns["MaNhanVien"].Width = 200;

            grdData.DisplayLayout.Bands[0].Columns["TuKy"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TuKy"].Header.Caption = "Từ Kỳ";
            grdData.DisplayLayout.Bands[0].Columns["TuKy"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["TuKy"].EditorComponent = ultraCombo_TuKy;
            grdData.DisplayLayout.Bands[0].Columns["TuKy"].Width = 100;

            //grdData.DisplayLayout.Bands[0].Columns["DenKy"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["DenKy"].Header.Caption = "Đến Ký";
            //grdData.DisplayLayout.Bands[0].Columns["DenKy"].Header.VisiblePosition = 2;
            //grdData.DisplayLayout.Bands[0].Columns["DenKy"].EditorComponent = ultraCombo_TuKy;
            //grdData.DisplayLayout.Bands[0].Columns["DenKy"].Width = 100;

            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;           
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 200;

        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdData.DataBind();
                bdNghiKhongLuongList.EndEdit();
                _nghiKhongLuongList.Save();
                _nghiKhongLuongList = NghiKhongLuongList.GetNghiKhongLuongList((Int64)ultraCombo_NhanVien.Value);
                bdNghiKhongLuongList.DataSource = _nghiKhongLuongList;
                MessageBox.Show(this, "Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Cập nhật thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }


        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Bạn Phải Chọn Dòng Cần Xóa Trên Lưới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdData.DeleteSelectedRows();
           
        }
             
    }
}
