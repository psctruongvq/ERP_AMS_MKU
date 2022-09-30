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
    public partial class frmDanhSachDenHanNangLuong : Form
    {
        TTNhanVienRutGonList _nhanVienList;
        DanhSachDenHanNangLuongList _danhSachDenHanNangLuongList;
        DanhSachDenHanNangLuong _danhSachDenHanNangLuong;
        DateTime tuNgay = DateTime.Now.Date;
        DateTime denNgay = DateTime.Now.Date;
        DateTime ngayDenHan = DateTime.Now.Date;
        int kieuNangLuong = 0;
        int kieuNhanVien = 0;
        long maNhanVien = 0;
        public frmDanhSachDenHanNangLuong()
        {
            InitializeComponent();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _danhSachDenHanNangLuongList = DanhSachDenHanNangLuongList.NewDanhSachDenHanNangLuongList();
            frmDate f = new frmDate();
            f.ShowDialog();
            if (!frmDate.isCancel)
            {
                ngayDenHan = frmDate.ngayDenHan.Date;
                kieuNangLuong = frmDate.kieuNangLuong;
                kieuNhanVien = frmDate.kieuNhanVien;
                if (kieuNhanVien == 1)
                {
                    _danhSachDenHanNangLuongList = DanhSachDenHanNangLuongList.NewDanhSachDenHanNangLuongList(ngayDenHan);
                }
                else
                {
                    _danhSachDenHanNangLuongList = DanhSachDenHanNangLuongList.NewDanhSachDenHanNangLuongBaoHiemList(ngayDenHan, kieuNangLuong);
                }
                for (int i = 0; i < _danhSachDenHanNangLuongList.Count; i++)
                {
                    _danhSachDenHanNangLuongList[i].NgayDenHan = ngayDenHan;
                    _danhSachDenHanNangLuongList[i].KieuNangLuong = kieuNangLuong;


                }
                this.bindingSource1_DanhsachDenHan.DataSource = _danhSachDenHanNangLuongList;
                lbTongSo.Text = "Tổng Số: " + _danhSachDenHanNangLuongList.Count.ToString();
                cbKieuNangLuong.Value = kieuNangLuong;
                cmbLoaiNV.Value = kieuNhanVien;
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    if (KyLuatTheoNhanVien.KiemTraNVKyLuat(Convert.ToInt64(gridData.Rows[i].Cells["MaNhanVien"].Value), ngayDenHan) != 0)
                    {
                        gridData.Rows[i].Appearance.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _danhSachDenHanNangLuongList.Count; i++)
            {
                _danhSachDenHanNangLuongList[i].TenDanhSach = _danhSachDenHanNangLuongList[i].NgayDenHan.Date.Month.ToString() + "/" + _danhSachDenHanNangLuongList[i].NgayDenHan.Date.Year.ToString();

            }


            _danhSachDenHanNangLuongList.ApplyEdit();
            _danhSachDenHanNangLuongList.Save();
            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lbTongSo.Text = "Tổng Số: " + _danhSachDenHanNangLuongList.Count.ToString();
        }

        private void dateTuNgay_ValueChanged(object sender, EventArgs e)
        {
            tuNgay = Convert.ToDateTime(dateTuNgay.Value);
            ComBoboxChanged();
        }

        private void dateDenNgay_ValueChanged(object sender, EventArgs e)
        {
            denNgay = Convert.ToDateTime(dateDenNgay.Value);
            ComBoboxChanged();
        }

        private void cmbLoaiNV_ValueChanged(object sender, EventArgs e)
        {
            kieuNhanVien = Convert.ToInt32(cmbLoaiNV.Value);
            ComBoboxChanged();
        }
        private void ComBoboxChanged()
        {

            _danhSachDenHanNangLuongList = DanhSachDenHanNangLuongList.GetDanhSachDenHanNangLuongList(tuNgay, denNgay, kieuNangLuong, kieuNhanVien);
            this.bindingSource1_DanhsachDenHan.DataSource = _danhSachDenHanNangLuongList;
            for (int i = 0; i < gridData.Rows.Count; i++)
            {
                if (KyLuatTheoNhanVien.KiemTraNVKyLuat(Convert.ToInt64(gridData.Rows[i].Cells["MaNhanVien"].Value), ngayDenHan) != 0)
                {
                    gridData.Rows[i].Appearance.ForeColor = Color.Red;

                }
            }
            lbTongSo.Text = "Tổng Số: " + _danhSachDenHanNangLuongList.Count.ToString();

            KyLuatTheoNhanVienList kyLuatList = KyLuatTheoNhanVienList.GetKyLuatTheoNhanVienListByNgayLap(tuNgay, denNgay, 0, 0, 0);
        }

        private void cmbLoaiNV_ValueChanged_1(object sender, EventArgs e)
        {
            kieuNhanVien = Convert.ToInt32(cmbLoaiNV.Value);
            if (kieuNhanVien == 1)
            {
                cbKieuNangLuong.Value = 1;
                cbKieuNangLuong.Enabled = false;
            }
            else
            {
                cbKieuNangLuong.Enabled = true;
            }
            //  ComBoboxChanged();
        }

        private void cbKieuNangLuong_ValueChanged(object sender, EventArgs e)
        {
            kieuNangLuong = Convert.ToInt32(cbKieuNangLuong.Value);
            // ComBoboxChanged();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdu_QuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            gridData.DeleteSelectedRows();
        }

        private void frmDanhSachDenHanNangLuong_Load(object sender, EventArgs e)
        {
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListAll();
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;
        }

        private void bindingSource1_DanhsachDenHan_AddingNew(object sender, AddingNewEventArgs e)
        {
            //DanhSachDenHanNangLuong ds;
            //    ds = DanhSachDenHanNangLuong.NewDanhSachDenHanNangLuongByNhanVien(maNhanVien, ngayDenHan);
            //    _danhSachDenHanNangLuongList.Add(ds);
            //    bindingSource1_DanhsachDenHan.DataSource = _danhSachDenHanNangLuongList;

        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.Value != null)
            {
                maNhanVien = Convert.ToInt64(cbNhanVien.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gridData);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < gridData.Rows.Count; i++)
                {
                    if (!gridData.Rows[i].Hidden == true)
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

        private void button2_Click(object sender, EventArgs e)
        {
            long maUngVien = 0;
            TTNhanVienRutGonList _ttNVList = TTNhanVienRutGonList.GetNhanVienListAll();
            try
            {
                DialogResult result = MessageBox.Show("Bạn Có Muốn Chuyển Quyết Định Nâng Lương Cho Nhân Viên Đã Chọn ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    for (int i = 0; i < gridData.Rows.Count; i++)
                    {

                        if ((Convert.ToBoolean(gridData.Rows[i].Cells["Check"].Value) == true) && (Convert.ToBoolean(gridData.Rows[i].Cells["DaChuyenThanhNangLuong"].Value) == false))
                        {

                            long maNhanVien = Convert.ToInt64(gridData.Rows[i].Cells["MaNhanVien"].Value);
                            NhanVien _nhanVien = NhanVien.GetNhanVien(maNhanVien);
                            decimal heSoLuongCu = Convert.ToDecimal(gridData.Rows[i].Cells["HeSoLuong"].Value);
                            decimal heSoLuongMoi = Convert.ToDecimal(gridData.Rows[i].Cells["HeSoLuongMoi"].Value);


                            _nhanVien = NhanVien.GetNhanVien(maNhanVien);
                            QuyetDinhNangLuong nangLuong = QuyetDinhNangLuong.NewQuyetDinhNangLuong();
                            nangLuong.MaNhanVien = maNhanVien;
                            nangLuong.HeSoLuongCu = heSoLuongCu;

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

                        }
                    }
                }//
            }
            catch(Exception ex)
            {}
        }
    }
}
