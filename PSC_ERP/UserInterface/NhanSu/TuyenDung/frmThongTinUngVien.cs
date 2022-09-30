

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmThongTinUngVien : Form
    {
        BoPhanList _boPhanList;
        int daChuyen = 0;
        DateTime tuNgay = DateTime.Today.Date;
        DateTime denNgay = DateTime.Today.Date;
        ThongTinUngVienList _ttUngVienList;
        TinhThanhList _tinhThanhList;
        TrinhDoHocVanClassList _trinhDoHocVanList;
        ChuyenNganhDaoTaoClassList _chuyenNganhDaoTao;

        //long maTuyenDung = 0;
        public frmThongTinUngVien()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ultragrdDanToc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung hdc = new HamDungChung();
            hdc.ultragrdEmail_InitializeLayout(sender, e);
            gridData.DisplayLayout.Bands[0].Columns["NoiSinh"].EditorComponent = cbTinhThanh;
            gridData.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cbBophan;
            gridData.DisplayLayout.Bands[0].Columns["TrinhDoVanHoa"].EditorComponent = cbTrinhDoVH;
            gridData.DisplayLayout.Bands[0].Columns["TrinhDoTayNghe"].EditorComponent = cbChuyenMonNghiepVu;
            gridData.DisplayLayout.Bands[0].Columns["LoaiNV"].EditorComponent = cmbu_LoaiNV;

            foreach (UltraGridColumn col in gridData.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
            gridData.DisplayLayout.Bands[0].Columns["LoaiNV"].Width = cmbu_LoaiNV.Width;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                int trungTuyen = 0;
                for (int i = 0; i < _ttUngVienList.Count; i++)
                {
                    _ttUngVienList[i].MaTuyenDung = frmThongTinTuyenDung.maTuyenDung; ;
                    if (_ttUngVienList[i].NoiSinh <= 0)
                    {
                        MessageBox.Show("Nơi sinh chưa chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_ttUngVienList[i].SoNamKinhNghiem < 0)
                    {
                        MessageBox.Show("Kinh nghiệm chưa chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //if (_ttUngVienList[i].TrinhDoTayNghe <= 0)
                    //{
                    //    MessageBox.Show("Trình độ tay nghề chưa chính xác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    if (_ttUngVienList[i].LoaiNV == 0)
                    {
                        MessageBox.Show("Loại Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_ttUngVienList[i].TrungTuyen == true)
                    {
                        trungTuyen++;
                    }
                    _ttUngVienList[i].TrungTuyen = true;
                    //if (trungTuyen > ThongTinTuyenDung.GetThongTinTuyenDung(frmThongTinTuyenDung.maTuyenDung).SoLuongTuyen)
                    //{
                    //    MessageBox.Show("Số lượng trúng tuyển lớn hơn số lượng tuyển", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                }
                _ttUngVienList.ApplyEdit();
                _ttUngVienList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ComboChanged();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw ex;
            }

        }

        private void ultragrdDanToc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gridData.UpdateData();
            }
        }

        private void frmThongTinUngVien_Load(object sender, EventArgs e)
        {
            LoaiNhanVienList loaiNV = LoaiNhanVienList.GetLoaiNhanVienList();
            this.bindingSource1_LoaiNhanVien.DataSource = loaiNV;
            _boPhanList = BoPhanList.GetBoPhanList();
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            _tinhThanhList = TinhThanhList.GetTinhThanhList();
            this.bindingSource1_tinhThanh.DataSource = _tinhThanhList;
            _trinhDoHocVanList = TrinhDoHocVanClassList.GetTrinhDoHocVanClassList();
            this.bindingSource1_trinhDoHocVan.DataSource = _trinhDoHocVanList;

            _chuyenNganhDaoTao = ChuyenNganhDaoTaoClassList.GetChuyenNganhDaoTaoClassList();
            this.bindingSource1_ChuyenNganhDaoTao.DataSource = _chuyenNganhDaoTao;
            ComboChanged();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (gridData.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            gridData.DeleteSelectedRows();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true )
            {
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    if (!gridData.Rows[i].Hidden == true && gridData.Rows[i].IsFilteredOut == false)
                    {
                        gridData.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    gridData.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComboChanged();
        }


        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTrinhDoVH_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            FilterCombo f = new FilterCombo(cbTrinhDoVH, "TrinhDoHocVan");
            foreach (UltraGridColumn col in this.cbTrinhDoVH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbTrinhDoVH.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Hidden = false;
            cbTrinhDoVH.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Header.Caption = "Văn Hóa";
            cbTrinhDoVH.DisplayLayout.Bands[0].Columns["TrinhDoHocVan"].Width = cbTrinhDoVH.Width;
        }

        private void cbTinhThanh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            FilterCombo f = new FilterCombo(cbTinhThanh, "TenTinhThanh");
            foreach (UltraGridColumn col in this.cbTinhThanh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbTinhThanh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Hidden = false;
            cbTinhThanh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tỉnh Thành";
            cbTinhThanh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Width = cbTinhThanh.Width;
        }

        private void cbChuyenMonNghiepVu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            FilterCombo f = new FilterCombo(cbChuyenMonNghiepVu, "ChuyenNganhDaoTao");
            foreach (UltraGridColumn col in this.cbChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["ChuyenNganhDaoTao"].Hidden = false;
            cbChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["ChuyenNganhDaoTao"].Header.Caption = "Chuyên Ngành";
            cbChuyenMonNghiepVu.DisplayLayout.Bands[0].Columns["ChuyenNganhDaoTao"].Width = cbChuyenMonNghiepVu.Width;
        }

        private void cbBophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbBophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cbBophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbBophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cbBophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cbBophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cbBophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cbBophan.Width;
            cbBophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cbBophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cbBophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 0;
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            tuNgay = Convert.ToDateTime(dateTuNgay.Value.Date);
            ComboChanged();
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            denNgay = Convert.ToDateTime(dateDenNgay.Value.Date);
            ComboChanged();
        }
        private void ComboChanged()
        {
         
                _ttUngVienList = ThongTinUngVienList.GetThongTinUngVienListTrungTuyenByNgay(tuNgay, denNgay,daChuyen);
           
           
            this.bindingSource1_ThongTinUngVien.DataSource = _ttUngVienList;
        }

        private void ultraButton2_Click(object sender, EventArgs e)
        {
            long maUngVien = 0;
            TTNhanVienRutGonList _ttNVList = TTNhanVienRutGonList.GetNhanVienListAll();
            try
            {
                DialogResult result = MessageBox.Show("Bạn Có Muốn Chuyển Những Ứng Viên Đã Chọn Thành Nhân Viên ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    for (int i = 0; i < gridData.Rows.Count; i++)
                    {

                        if ((Convert.ToBoolean(gridData.Rows[i].Cells["Check"].Value) == true) && (Convert.ToBoolean(gridData.Rows[i].Cells["ChuyenThanhNV"].Value) == false))
                        {
                            string maQLNV = Convert.ToString(gridData.Rows[i].Cells["MaQuanLy"].Value);
                            for (int j = 0; j < _ttNVList.Count; j++)
                            {
                                if (_ttNVList[j].MaQLNhanVien == maQLNV)
                                {
                                    MessageBox.Show("Mã Quản Lý Nhân Viên " + maQLNV + " Đã Tồn Tại, Xin Chọn Nhập Lại Mã Quản Lý Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    gridData.ActiveRow = gridData.Rows[i];
                                    gridData.Focus();
                                    return;
                                }
                            }

                            maUngVien = Convert.ToInt64(gridData.Rows[i].Cells["MaUngVien"].Value);
                            string ho = Convert.ToString(gridData.Rows[i].Cells["Ho"].Value);
                            string ten = Convert.ToString(gridData.Rows[i].Cells["Ten"].Value);
                            int maBoPhan = Convert.ToInt32(gridData.Rows[i].Cells["MaBoPhan"].Value);
                            bool gioiTinh = Convert.ToBoolean(gridData.Rows[i].Cells["GioiTinh"].Value);
                            string CMND = Convert.ToString(gridData.Rows[i].Cells["SoCMND"].Value);
                            DateTime ngayCap = Convert.ToDateTime(gridData.Rows[i].Cells["NgayCap"].Value);
                            DateTime ngaySinh = Convert.ToDateTime(gridData.Rows[i].Cells["NgaySinh"].Value);
                            int maNoiCap = Convert.ToInt32(gridData.Rows[i].Cells["NoiCap"].Value);
                            int maNoiSinh = Convert.ToInt32(gridData.Rows[i].Cells["NoiSinh"].Value);
                            int loaiNV = Convert.ToInt32(gridData.Rows[i].Cells["LoaiNV"].Value);
                            string diaChiTam = Convert.ToString(gridData.Rows[i].Cells["DiaChiLienLac"].Value);
                            string dienThoai = Convert.ToString(gridData.Rows[i].Cells["DienThoai"].Value);
                            //ThongTinUngVien.ChuyenUngVienThanhNV(maUngVien, maQLNV, tenNV, maBoPhan, gioiTinh, CMND, ngayCap, maNoiCap, ngaySinh, maNoiSinh, diaChiTam);

                            NhanVien nv = NhanVien.NewNhanVien();
                         
                            
                            nv.MaBoPhan = maBoPhan;
                            nv.Ho = ho;
                            nv.Ten = ten;
                            nv.MaQLNhanVien = maQLNV;
                            nv.NgaySinh = ngaySinh;
                            nv.GioiTinh = gioiTinh;
                            nv.LoaiNV = loaiNV;
                            nv.MaNoiSinh = maNoiSinh;
                            nv.DienthoaiThT = dienThoai;
                            nv.DienthoaiTT = dienThoai;
                            nv.DiaChiNhanVienTam = diaChiTam;
                            nv.DiachiThT = diaChiTam;
                            nv.ApplyEdit();
                            nv.Save();
                            ThongTinUngVien uv = ThongTinUngVien.GetThongTinUngVien(maUngVien);
                            uv.ChuyenThanhNV = true;
                            uv.ApplyEdit();
                            uv.Save(true);
                        }
                    }
                    MessageBox.Show("Chuyển Ứng Viên Thành Nhân Viên Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ComboChanged();
                }//
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void rdChua_CheckedChanged(object sender, EventArgs e)
        {
            if (rdChua.Checked == true)
                daChuyen = 0;
            ComboChanged();
        }

        private void rdDaChuyen_CheckedChanged(object sender, EventArgs e)
        {
            if (rdDaChuyen.Checked == true)
                daChuyen = 1;
            ComboChanged();
        }

        private void rdTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rdTatCa.Checked == true)
                daChuyen = -1;
            ComboChanged();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridData);
        }
    }
}
       