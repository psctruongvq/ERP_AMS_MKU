using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmLuong_Nguon : Form
    {
        Luong_NguonList _luong_NguonList;
        KyTinhLuongList _kyTinhLuongList;
        Luong_Nguon _luong_NguonNew;
        public frmLuong_Nguon()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPhuCapNguon_Load(object sender, EventArgs e)
        {
            //Load dữ liệu
            LoadData();
        }
        private Boolean KiemTraHopLe()
        {
            Boolean duocPhepLuu = true;

            foreach (Luong_Nguon item in _luong_NguonList)
            {
                if (string.IsNullOrEmpty(item.Loai))
                {
                    MessageBox.Show("Chọn loại lương!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return duocPhepLuu = false;
                }
                if (item.MaNguon == 0)
                {
                    MessageBox.Show("Chọn nguồn!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return duocPhepLuu = false;
                }
                if (item.MaKy == 0)
                {
                    MessageBox.Show("Chọn kỳ tính lương!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return duocPhepLuu = false;
                }
            }

            return duocPhepLuu;
        }
        private void SaveData()
        {
            txtBlackHole.Focus();//
            //
            try
            {
                if (KiemTraHopLe())
                {
                    grdData.UpdateData();
                    _luong_NguonList.Save();
                    //
                    MessageBox.Show("Dữ liệu lưu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dữ liệu lưu không thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void LoadData()
        {
            _luong_NguonList = Luong_NguonList.GetLuong_NguonList();
            //
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KyTinhLuong kyTinhLuong = KyTinhLuong.NewKyTinhLuong();
            kyTinhLuong.TenKy = "<<Chọn>>";
            _kyTinhLuongList.Insert(0,kyTinhLuong);
            //
            NguonList nguonList  = NguonList.GetNguonList();
            Nguon nguon = Nguon.NewNguon();
            nguon.TenNguon = "<<Chọn>>";
            nguonList.Insert(0,nguon);
            //Đưa vào bindingSource

            bdData.DataSource = _luong_NguonList;
            //
            KyTinhLuongListBindingSource.DataSource = _kyTinhLuongList;
            //
            NguonListBindingSource.DataSource = nguonList;
            //
            LoaiLuongNguonBindingSource.DataSource = LoaiLuong_Nguon.LoaiLuongList;
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            //e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            grdData.DisplayLayout.Bands[0].Columns["MaLuongNguon"].Hidden = true;

            grdData.DisplayLayout.Bands[0].Columns["Loai"].EditorComponent = cbLoaiLuong;
            grdData.DisplayLayout.Bands[0].Columns["MaNguon"].EditorComponent = cbNguon;
            grdData.DisplayLayout.Bands[0].Columns["MaKy"].EditorComponent = cbKyTinhLuong;

            grdData.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại lương";
            grdData.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["Loai"].Width = cbLoaiLuong.Width;

            grdData.DisplayLayout.Bands[0].Columns["MaNguon"].Header.Caption = "Nguồn";
            grdData.DisplayLayout.Bands[0].Columns["MaNguon"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["MaNguon"].Width = cbNguon.Width;

            grdData.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Kỳ tính lương";
            grdData.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["MaKy"].Width = cbKyTinhLuong.Width;

            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void cbNguon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNguon, "TenNguon");
            foreach (UltraGridColumn col in this.cbNguon.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                col.Width = 150;
            }
            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cbNguon.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Hidden = false;

            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên nguồn";
            cbNguon.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Header.Caption = "Mã quản lý";

            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 0;
            cbNguon.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Header.VisiblePosition = 1;

            cbNguon.DisplayLayout.Bands[0].Columns["TenNguon"].Width = 250;
            cbNguon.DisplayLayout.Bands[0].Columns["MaNguonQuanLy"].Width = 100;
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
            foreach (UltraGridColumn col in this.cbKyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                col.Width = 150;
            }
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên kỳ";
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;

            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = 220;
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            //Tiến hành copy dữ liệu
            CopyData();
        }
        private void btnPass_Click(object sender, EventArgs e)
        {
            //Tiến hành pass
            PassData();
        }
        private void CopyData()
        {
               DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn copy dữ liệu sang kỳ kế tiếp?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
               if (_DialogResult == DialogResult.Yes)
               {
                   //Lấy dữ liệu vừa chọn trên lưới
                   Luong_Nguon currentLuong_Nguon = bdData.Current as Luong_Nguon;

                   if (currentLuong_Nguon == null)
                       return;

                   //Khởi tạo phụ cấp nguồn mới
                   _luong_NguonNew = Luong_Nguon.NewLuong_Nguon();
                   _luong_NguonNew.Loai = currentLuong_Nguon.Loai;

                   _luong_NguonNew.MaNguon = currentLuong_Nguon.MaNguon;
                   //Lấy mã kỳ kế tiếp
                   _luong_NguonNew.MaKy = MaKyKeTiep(currentLuong_Nguon.MaKy);
               }
        }
        private void PassData()
        {
            if (_luong_NguonNew == null)
                return;

            if (KiemTraLuong_Nguon(_luong_NguonNew.MaKy))
            {
                //Thêm vào danh sách
                _luong_NguonList.Add(_luong_NguonNew);
                bdData.DataSource = _luong_NguonList;
                bdData.MoveLast();

                //Set data
                _luong_NguonNew = null;
            }
            else
            {
                MessageBox.Show("Kỳ kế tiếp đã tồn tại!", "Copy", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private Boolean KiemTraLuong_Nguon(int maKy, Luong_Nguon luong_Nguon = null)
        {
            foreach (Luong_Nguon item in _luong_NguonList)
            {
                if (item.MaKy == maKy && item != luong_Nguon)
                    return false;
            }
            return true;
        }
        private int MaKyKeTiep(int maKy)
        {
            int maKyKetiep = 0;
            int dieuKienTim_Thang = 0;
            int dieuKienTim_Nam = 0;

            {// Set điều kiện tìm

                KyTinhLuong kyTinhLuong = KyTinhLuong.GetKyTinhLuong(maKy);

                if (kyTinhLuong != null)
                {
                    if (kyTinhLuong.Thang == 12)
                    { dieuKienTim_Thang = 1; }
                    else
                    { dieuKienTim_Thang = kyTinhLuong.Thang + 1; }
                    //
                    dieuKienTim_Nam += kyTinhLuong.Nam;
                }
            }
            //
            foreach (KyTinhLuong item in _kyTinhLuongList)
            {
                if (item.Thang == dieuKienTim_Thang && item.Nam == dieuKienTim_Nam)
                {
                    maKyKetiep = item.MaKy;
                }
            }

            return maKyKetiep;
        }

        private void grdData_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.ToString() != "MaKy")
                return;

            //Lấy dữ liệu vừa chọn trên lưới
            Luong_Nguon currentLuong_Nguon = bdData.Current as Luong_Nguon;

            if (!KiemTraLuong_Nguon(currentLuong_Nguon.MaKy, currentLuong_Nguon))
            {
                MessageBox.Show("Kỳ này đã tồn tại! Vui lòng chọn kỳ khác!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                currentLuong_Nguon.MaKy = 0;
            }
        }

        private void frmLuong_Nguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                tlslblXoa_Click(sender,e);
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                CopyData();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                PassData();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                SaveData();
            }
            else if (e.Alt && e.KeyCode == Keys.X)
            {
                this.Close();
            }
        }

        private void cbLoaiLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbLoaiLuong, "Ten");
            foreach (UltraGridColumn col in this.cbLoaiLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                col.Width = 150;
            }
            cbLoaiLuong.DisplayLayout.Bands[0].Columns["Ten"].Hidden = false;
            cbLoaiLuong.DisplayLayout.Bands[0].Columns["Ten"].Header.Caption = "Tên loại lương";
            cbLoaiLuong.DisplayLayout.Bands[0].Columns["Ten"].Header.VisiblePosition = 0;

            cbLoaiLuong.DisplayLayout.Bands[0].Columns["Ten"].Width = 250;
        }
    }
}