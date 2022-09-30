using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP.UserInterface.NhanSu.ThongTinLuong
{
    public partial class frmCapNhatThongTinQuyetDinh : Form
    {
        QuyetDinhNangLuongList _quyetDinhNangLuongList = QuyetDinhNangLuongList.NewQuyetDinhNangLuongList();
        QuyetDinhNangLuong _quyetDinhNangLuong;
        NhomNgachLuongCoBanList _NhomNgachLuongBaoHiemList;
        BacLuongCoBanList _BacLuongBaoHiemList;
        NhomNgachLuongCoBanList _nhomNgachCoBanList;
        NgachLuongCoBanList _ngachCoBanList;
        BacLuongCoBanList _bacLuongCoBanList;
        NgachLuongCoBanList _NgachLuongBaoHiemList;

        public frmCapNhatThongTinQuyetDinh()
        {
            InitializeComponent();
        }

        private void frmCapNhatThongTinQuyetDinh_Load(object sender, EventArgs e)
        {
            _quyetDinhNangLuongList = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(true);
            this.bindingSource1_QuyetDinhNangLuong.DataSource = _quyetDinhNangLuongList;

            _NhomNgachLuongBaoHiemList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
            this.bindingSource1_NhomNgachBH.DataSource = _NhomNgachLuongBaoHiemList;

            _NgachLuongBaoHiemList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            this.bindingSource1_NgachBH.DataSource = _NgachLuongBaoHiemList;

            _BacLuongBaoHiemList = BacLuongCoBanList.GetBacLuongCoBanListAll();
            this.bindingSource1_BacBH.DataSource = _BacLuongBaoHiemList;

            _nhomNgachCoBanList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
            this.bindingSource1_NhomNgachLuong.DataSource = _nhomNgachCoBanList;

            _ngachCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            this.bindingSource1_NgachLuong.DataSource = _ngachCoBanList;

            _bacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanListAll();
            this.bindingSource1_BacLuong.DataSource = _bacLuongCoBanList;
        }

        private void grdu_DanhSachNangLuong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.White;
                col.Hidden = true;
                col.CellActivation = Activation.ActivateOnly;
            }
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["CapNhatSau"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["CapNhatSau"].Header.Caption = "Cập nhật sau";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["CapNhatSau"].Header.VisiblePosition = 0;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["CapNhatSau"].CellActivation = Activation.AllowEdit;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 1;
            
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.Caption = "Ngày Quyết Định";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.VisiblePosition = 2;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Họ Tên";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 3;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.Caption = "Ngày Hiệu Lực";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.VisiblePosition = 4;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].Header.Caption = "Mốc Thời Gian";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].Header.VisiblePosition = 5;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoLuongMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoLuongMoi"].Header.Caption = "HSL Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoLuongMoi"].Header.VisiblePosition = 6;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacCoBanMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacCoBanMoi"].Header.Caption = "Bậc CB Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacCoBanMoi"].Header.VisiblePosition = 7;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemMoi"].Header.Caption = "HSBH Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemMoi"].Header.VisiblePosition = 8;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemMoi"].Header.Caption = "Bậc BH Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemMoi"].Header.VisiblePosition = 9;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSVKMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSVKMoi"].Header.Caption = "HSVK Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSVKMoi"].Header.VisiblePosition = 10;

            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSNBMoi"].Hidden = false;
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSNBMoi"].Header.Caption = "HSNB Mới";
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSNBMoi"].Header.VisiblePosition = 10;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _quyetDinhNangLuongList = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(true);
            this.bindingSource1_QuyetDinhNangLuong.DataSource = _quyetDinhNangLuongList;
        }

        private void tlslblSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void Save()
        {
            _quyetDinhNangLuongList.ApplyEdit();
            _quyetDinhNangLuongList.Save();

            foreach (QuyetDinhNangLuong _quyetDinh in _quyetDinhNangLuongList)
            {
                if (!_quyetDinh.CapNhatSau)
                {
                    QuyetDinhNangLuongList _quyetDinhListNV = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(_quyetDinh.MaNhanVien);
                    int soQuyetDinh = QuyetDinhNangLuong.KiemTraNgayHieuLucMax(_quyetDinh.MaNhanVien);
                    NhanVien _nhanVien = NhanVien.GetNhanVien(_quyetDinh.MaNhanVien);

                    for (int i = 0; i < _quyetDinhListNV.Count; i++)
                    {
                        if (_quyetDinhListNV[i].MaQuyetDinh == soQuyetDinh && _quyetDinhListNV[i].CapNhatSau != true)
                        {
                            _nhanVien.HeSoVuotKhung = _quyetDinhListNV[i].HSVKMoi;
                            _nhanVien.HeSoVuotKhungBH = _quyetDinhListNV[i].HSVKBHMoi;
                            _nhanVien.MaNgachLuongCoBan = _quyetDinhListNV[i].MaNgachLuongCoBanMoi;
                            _nhanVien.MaBacLuongCoBan = _quyetDinhListNV[i].MaBacLuongCoBanMoi;
                            _nhanVien.HeSoLuong = _quyetDinhListNV[i].HeSoLuongMoi;

                            _nhanVien.MaNhomNgachLuongBaoHiem = _quyetDinhListNV[i].MaNhomBaoHiemNgach;
                            _nhanVien.MaNhomNgachLuongCB = _quyetDinhListNV[i].MaNhomNgachCoBan;

                            _nhanVien.MaNgachLuongBaoHiem = _quyetDinhListNV[i].MaNgachBaoHiemMoi;
                            _nhanVien.MaBacLuongBaoHiem = _quyetDinhListNV[i].MaBacBaoHiemMoi;
                            _nhanVien.HeSoLuongBaoHiem = _quyetDinhListNV[i].HeSoBaoHiemMoi;
                            if (_quyetDinhListNV[i].LoaiNhanVienMoi != 0)
                            {
                                _nhanVien.LoaiNV = _quyetDinhListNV[i].LoaiNhanVienMoi;
                                _nhanVien.HeSoLuongNoiBo = _quyetDinhListNV[i].HeSoNBMoi;
                            }

                            //Đối với
                            if (_quyetDinhListNV[i].KieuNangLuong == 1 || _quyetDinhListNV[i].KieuNangLuong == 4 || _quyetDinhListNV[i].KieuNangLuong == 5)
                            {
                                _nhanVien.MocLenLuong = _quyetDinhListNV[i].MocThoiGianNangBac;
                                _nhanVien.MocLenLuongBaoHiem = _quyetDinhListNV[i].MocThoiGianNangBac;
                            }
                            else
                                if (_quyetDinhListNV[i].KieuNangLuong == 2)
                                {
                                    _nhanVien.MocLenLuong = _quyetDinhListNV[i].MocThoiGianNangBac;
                                }
                                else if (_quyetDinhListNV[i].KieuNangLuong == 3)
                                {
                                    _nhanVien.MocLenLuongBaoHiem = _quyetDinhListNV[i].MocThoiGianNangBac;
                                }
                        }
                    }
                    //Cập nhật thông tin cho nhân viên
                    _nhanVien.ApplyEdit();
                    _nhanVien.Save();
                }
            }

            //Tải lại danh sách
            grdu_DanhSachNangLuong.UpdateData();
            bindingSource1_QuyetDinhNangLuong.EndEdit();
            MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            _quyetDinhNangLuongList = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(true);
            this.bindingSource1_QuyetDinhNangLuong.DataSource = _quyetDinhNangLuongList;

            //cập nhật cảnh báo
            PSC_ERP.Main.frmNhanSu.mfnc_KiemTraCanhBao();

        }  
    }
}
