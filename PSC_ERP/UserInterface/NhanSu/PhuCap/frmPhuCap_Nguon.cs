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
    public partial class frmPhuCap_Nguon : Form
    {
        PhuCap_NguonList _phuCapNguonList;
        KyTinhLuongList _kyTinhLuongList;
        PhuCap_Nguon _phuCap_NguonNew;
        public frmPhuCap_Nguon()
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
            bdData.EndEdit();
            _phuCapNguonList.ApplyEdit();
            //
            Boolean duocPhepLuu = true;

            foreach (PhuCap_Nguon item in _phuCapNguonList)
            {
                //if (item.MaNhomPhuCap == 0)
                //{
                //    MessageBox.Show("Chọn nhóm phụ cấp!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return duocPhepLuu = false;
                //}
                if (item.MaLoaiPhuCap == 0)
                {
                    MessageBox.Show("Chọn loại phụ cấp!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbLoaiPhuCap.Focus();
                    return duocPhepLuu = false;
                }
                if (item.MaNguon == 0)
                {
                    MessageBox.Show("Chọn nguồn!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbNguon.Focus();
                    return duocPhepLuu = false;
                }
                if (item.MaKy == 0)
                {
                    MessageBox.Show("Chọn kỳ tính lương!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbKyTinhLuong.Focus();
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
                    _phuCapNguonList.Save();
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
            //
            cbLoaiPhuCap.Value = null;
            //
            _phuCapNguonList = PhuCap_NguonList.GetPhuCapNguonList();
            //
            NhomPhuCapList nhomPhuCapList = NhomPhuCapList.GetNhomPhuCapList();
            NhomPhuCap nhomPhuCap = NhomPhuCap.NewNhomPhuCap();
            nhomPhuCap.Ten = "<<Tất cả>>";
            nhomPhuCapList.Insert(0, nhomPhuCap);
            //
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KyTinhLuong kyTinhLuong = KyTinhLuong.NewKyTinhLuong();
            kyTinhLuong.TenKy = "<<Chọn>>";
            _kyTinhLuongList.Insert(0,kyTinhLuong);
            //
            NguonList nguonList = NguonList.GetNguonList();
            Nguon nguon = Nguon.NewNguon();
            nguon.TenNguon = "<<Chọn>>";
            nguonList.Insert(0, nguon);
            //
            LoaiPhuCapList loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapList();
            LoaiPhuCapChild loaiPhuCap = LoaiPhuCapChild.NewLoaiPhuCapChild("<<Chọn>>");
            loaiPhuCapList.Insert(0, loaiPhuCap);
            //
            //Đưa vào bindingSource
            KyTinhLuongListBindingSource.DataSource = _kyTinhLuongList;
            //
            NguonListBindingSource.DataSource = nguonList;
            //
            NhomPhuCapListBindingSource.DataSource = nhomPhuCapList;
            //
            LoaiPCBindingSource.DataSource = loaiPhuCapList;
            //
            bdData.DataSource = _phuCapNguonList;
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void cbNhomPhuCap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbNhomPhuCap, "Ten");
            foreach (UltraGridColumn col in this.cbNhomPhuCap.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            cbNhomPhuCap.DisplayLayout.Bands[0].Columns["Ten"].Hidden = false;
            cbNhomPhuCap.DisplayLayout.Bands[0].Columns["Ma"].Hidden = false;

            cbNhomPhuCap.DisplayLayout.Bands[0].Columns["Ten"].Header.Caption = "Tên nhóm";
            cbNhomPhuCap.DisplayLayout.Bands[0].Columns["Ma"].Header.Caption = "Mã quản lý";

            cbNhomPhuCap.DisplayLayout.Bands[0].Columns["Ten"].Header.VisiblePosition = 0;
            cbNhomPhuCap.DisplayLayout.Bands[0].Columns["Ma"].Header.VisiblePosition = 1;

            cbNhomPhuCap.DisplayLayout.Bands[0].Columns["Ten"].Width = 200;
            cbNhomPhuCap.DisplayLayout.Bands[0].Columns["Ma"].Width = 100;
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
                PhuCap_Nguon currentPhuCap_Nguon = bdData.Current as PhuCap_Nguon;

                if (currentPhuCap_Nguon == null)
                    return;

                //Khởi tạo phụ cấp nguồn mới
                _phuCap_NguonNew = PhuCap_Nguon.NewPhuCapNguon();
                _phuCap_NguonNew.MaNhomPhuCap = currentPhuCap_Nguon.MaNhomPhuCap;
                _phuCap_NguonNew.MaNguon = currentPhuCap_Nguon.MaNguon;
                _phuCap_NguonNew.MaLoaiPhuCap = currentPhuCap_Nguon.MaLoaiPhuCap;
                //Lấy mã kỳ kế tiếp
                _phuCap_NguonNew.MaKy = MaKyKeTiep(currentPhuCap_Nguon.MaKy);
            }
        }
        private void PassData()
        {
            if (_phuCap_NguonNew == null)
                return;

            if (KiemTraPhuCap_Nguon(_phuCap_NguonNew.MaKy))
            {
                //Thêm vào danh sách
                _phuCapNguonList.Add(_phuCap_NguonNew);
                bdData.DataSource = _phuCapNguonList;
                bdData.MoveLast();

                //Set data
                _phuCap_NguonNew = null;
            }
            else
            {
                MessageBox.Show("Kỳ kế tiếp đã tồn tại!", "Copy", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        private Boolean KiemTraPhuCap_Nguon(int maKy, PhuCap_Nguon phuCap_Nguon = null)
        {
            foreach (PhuCap_Nguon item in _phuCapNguonList)
            {
                if (item.MaKy == maKy && item != phuCap_Nguon)
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

        private void frmPhuCap_Nguon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.D)
            {
                tlslblXoa_Click(sender, e);
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

        private void cbLoaiPhuCap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbLoaiPhuCap, "TenLoaiPhuCap");
            foreach (UltraGridColumn col in this.cbLoaiPhuCap.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            cbLoaiPhuCap.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Hidden = false;
            cbLoaiPhuCap.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Hidden = false;

            cbLoaiPhuCap.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Header.Caption = "Tên loại";
            cbLoaiPhuCap.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Header.Caption = "Mã quản lý";

            cbLoaiPhuCap.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Header.VisiblePosition = 0;
            cbLoaiPhuCap.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Header.VisiblePosition = 1;

            cbLoaiPhuCap.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Width = 200;
            cbLoaiPhuCap.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Width = 100;
        }

        private void cbNhomPhuCap_AfterCloseUp(object sender, EventArgs e)
        {
            ////Lấy giá trị vừa chọn
            if (cbNhomPhuCap.Value == null)
                return;
            int maNhom = (Int32)cbNhomPhuCap.Value;

            //Lấy dữ liệu cho loại phụ cấp
            LayLoaiPhuCap(maNhom);

            //
            txtBlackHole.Focus();
        }
        private void LayLoaiPhuCap(int maNhom)
        {
            LoaiPhuCapList loaiPhuCapList;
            if (maNhom == 0)
            {
                loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapList();
            }
            else
            {
                loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapByMaNhom(maNhom);
            }

            //
            LoaiPhuCapChild loaiPhuCap = LoaiPhuCapChild.NewLoaiPhuCapChild("<<Chọn>>");
            loaiPhuCapList.Insert(0, loaiPhuCap);
            //
            LoaiPhuCapListBindingSource.DataSource = loaiPhuCapList;
            cbLoaiPhuCap.Value = 0;
        }
        private void cbLoaiPC_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbLoaiPC, "TenLoaiPhuCap");
            foreach (UltraGridColumn col in this.cbLoaiPC.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            cbLoaiPC.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Hidden = false;
            cbLoaiPC.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Hidden = false;

            cbLoaiPC.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Header.Caption = "Tên loại";
            cbLoaiPC.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Header.Caption = "Mã quản lý";

            cbLoaiPC.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Header.VisiblePosition = 0;
            cbLoaiPC.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Header.VisiblePosition = 1;

            cbLoaiPC.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Width = 200;
            cbLoaiPC.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Width = 100;
        }

        private void grdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            //e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            grdData.DisplayLayout.Bands[0].Columns["MaPhuCapNguon"].Hidden = true;

            grdData.DisplayLayout.Bands[0].Columns["MaNhomPhuCap"].EditorComponent = cbNhomPhuCap;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiPhuCap"].EditorComponent = cbLoaiPC;
            grdData.DisplayLayout.Bands[0].Columns["MaNguon"].EditorComponent = cbNguon;
            grdData.DisplayLayout.Bands[0].Columns["MaKy"].EditorComponent = cbKyTinhLuong;

            grdData.DisplayLayout.Bands[0].Columns["MaNhomPhuCap"].Header.Caption = "Nhóm phụ cấp";
            grdData.DisplayLayout.Bands[0].Columns["MaNhomPhuCap"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["MaNhomPhuCap"].Width = cbLoaiPC.Width;

            grdData.DisplayLayout.Bands[0].Columns["MaLoaiPhuCap"].Header.Caption = "Loại phụ cấp";
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiPhuCap"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiPhuCap"].Width = cbLoaiPC.Width;

            grdData.DisplayLayout.Bands[0].Columns["MaNguon"].Header.Caption = "Nguồn";
            grdData.DisplayLayout.Bands[0].Columns["MaNguon"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["MaNguon"].Width = cbNguon.Width;

            grdData.DisplayLayout.Bands[0].Columns["MaKy"].Header.Caption = "Kỳ tính lương";
            grdData.DisplayLayout.Bands[0].Columns["MaKy"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["MaKy"].Width = cbKyTinhLuong.Width;

            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;
            }
        }

        private void bdData_CurrentChanged(object sender, EventArgs e)
        {
            //Lấy phụ cấp nguồn hiện tại
            PhuCap_Nguon currentPhuCap_Nguon = bdData.Current as PhuCap_Nguon;
            if (currentPhuCap_Nguon == null)
                return;
            //Lấy dữ liệu cho loại phụ cấp
            LayLoaiPhuCap(currentPhuCap_Nguon.MaNhomPhuCap);
            //
            cbLoaiPhuCap.Value = currentPhuCap_Nguon.MaLoaiPhuCap;
        }

        private void cbLoaiPhuCap_AfterCloseUp(object sender, EventArgs e)
        {
            if (cbLoaiPhuCap.Value == null)
                return;
            //Mã loại phụ cấp vừa chọn
            int maLoaiPhuCap = (Int32)cbLoaiPhuCap.Value;

            //Lấy phụ cấp nguồn hiện tại
            PhuCap_Nguon currentPhuCap_Nguon = bdData.Current as PhuCap_Nguon;
            if (currentPhuCap_Nguon == null)
                return;
            currentPhuCap_Nguon.MaLoaiPhuCap = maLoaiPhuCap;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //
            cbLoaiPhuCap.Value = 0;

            //Khởi tạo phụ cấp nguồn mới
            PhuCap_Nguon phuCap_NguonNew = PhuCap_Nguon.NewPhuCapNguon();
            bdData.Add(phuCap_NguonNew);
            bdData.MoveLast();
            //
        }

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value ==null)
                return;
            //Lấy phụ cấp nguồn hiện tại
            PhuCap_Nguon currentPhuCap_Nguon = bdData.Current as PhuCap_Nguon;

            if (!KiemTraPhuCap_Nguon((int)cbKyTinhLuong.Value, currentPhuCap_Nguon))
            {
                MessageBox.Show("Kỳ này đã tồn tại! Vui lòng chọn kỳ khác!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                cbKyTinhLuong.Value = 0;
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            //Load lãi dữ liệu
            LoadData();
        }
    }
}