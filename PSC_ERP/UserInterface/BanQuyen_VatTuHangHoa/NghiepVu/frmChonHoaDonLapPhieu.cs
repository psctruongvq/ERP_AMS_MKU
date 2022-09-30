using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmChonHoaDonLapPhieu : DevExpress.XtraEditors.XtraForm
    {
        long _maDoiTac;
        HoaDonList _HoaDonList = HoaDonList.NewHoaDonList();
        HoaDon_NhapXuatList _hoaDon_NhapXuatList = HoaDon_NhapXuatList.NewHoaDon_NhapXuatList();
        ChungTu_HoaDonList _chungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        bool _trangThai = false;
        PhieuNhapXuat _phieuNhapXuat;
        int _loai = 0;

        public HoaDon_NhapXuatList HoaDon_NhapXuatList
        {
            get { return _hoaDon_NhapXuatList; }
        }

        public ChungTu_HoaDonList ChungTu_HoaDonList
        {
            get { return _chungTu_HoaDonList; }
        }

        public bool TrangThai
        {
            get { return _trangThai; }
        }

        public frmChonHoaDonLapPhieu()
        {
            InitializeComponent();
        }

        public frmChonHoaDonLapPhieu(long maDoiTac)
        {
            InitializeComponent();
            _maDoiTac = maDoiTac;
            _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
        }

        public frmChonHoaDonLapPhieu(long maDoiTac, PhieuNhapXuat phieuNX)
        {
            InitializeComponent();
            _maDoiTac = maDoiTac;
            _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
        }

        public frmChonHoaDonLapPhieu(long maDoiTac, int loai)
        {
            InitializeComponent();
            _maDoiTac = maDoiTac;
            _loai = loai;
            if (_loai == 1 || _loai == 4)
                _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
            else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
        }


        public frmChonHoaDonLapPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();
            _phieuNhapXuat = phieuNhapXuat;
            _maDoiTac = phieuNhapXuat.MaDoiTac;//M
            _hoaDon_NhapXuatList = phieuNhapXuat.HoaDon_NhapXuatList;
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                //if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanCo.SoHieuTK.Contains("3113") || taiKhoanCo.SoHieuTK.Contains("3337"))
                if (PublicClass.KiemTraLaTaiKhoanThueKhauTru(taiKhoan.SoHieuTK) || PublicClass.KiemTraLaTaiKhoanThueKhauTru(taiKhoanCo.SoHieuTK))
                {
                    foreach (ChungTu_HoaDon ct_hd in _butToan.ChungTu_HoaDonList)
                        _chungTu_HoaDonList.Add(ct_hd);
                }
            }
            _HoaDonList = HoaDonList.GetHoaDonListByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
            foreach (HoaDon hoaDon in _HoaDonList)
            {
                hoaDon.Check = true;
            }
            hoaDonListBindingSource.DataSource = _HoaDonList;

            if (_HoaDonList.Count == 0)
            {
                if (_loai == 1)
                    _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
                else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
                hoaDonListBindingSource.DataSource = _HoaDonList;
            }
        }

        private void btn_HoaDonVAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Modify
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_phieuNhapXuat, false);
            frmhoadondichvu.ShowDialog();

            if (_loai == 1)
                _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
            else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
            #endregion Modify

            #region Old
            //frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_maDoiTac, DateTime.Today, false);
            //frmhoadondichvu.ShowDialog();

            //if (_loai == 1)
            //    _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
            //else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            //hoaDonListBindingSource.DataSource = _HoaDonList;
            #endregion Old
        }

        private void grdv_DanhSachHoaDon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                foreach (int i in grdv_DanhSachHoaDon.GetSelectedRows())
                {
                    if (_HoaDonList[i].Check == true)
                        _HoaDonList[i].Check = false;
                    else _HoaDonList[i].Check = true;
                }
            }
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();
            _trangThai = true;

            if (_phieuNhapXuat == null || (_phieuNhapXuat.MaPhieuNhapXuat == 0))
            {
                foreach (HoaDon hoaDon in _HoaDonList)
                {
                    if (hoaDon.Check == true)
                    {
                        _hoaDon_NhapXuatList.Add(HoaDon_NhapXuat.NewHoaDon_NhapXuat(hoaDon.MaHoaDon));
                        ChungTu_HoaDonList ct_hd = ChungTu_HoaDonList.GetChungTu_HoaDonByMaHoaDonList(hoaDon.MaHoaDon);
                        if (ct_hd.Count == 0)
                            _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(hoaDon));
                    }
                }
            }
            else
            {
                //rang buoc mot PN chi chon mot hoa don
                int i = 0;
                foreach (HoaDon hoaDon in _HoaDonList)
                {
                    if (hoaDon.Check == true)
                    {
                        i += 1;
                    }
                }
                if (i > 1)
                {
                    MessageBox.Show("Phiếu Nhập chỉ tương ứng với một hóa đơn. Vui lòng chỉ chọn 1 Hóa Đơn");
                    return;
                }

                foreach (HoaDon hoaDon in _HoaDonList)
                {
                    if (HoaDon_NhapXuat.KiemTraHoaDonTonTaiTrongHoaDon_NhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, hoaDon.MaHoaDon))
                    {
                        //
                        if (hoaDon.Check == false)
                        {
                            foreach (HoaDon_NhapXuat hoaDon_NhapXuat in _hoaDon_NhapXuatList)
                            {
                                if (hoaDon.MaHoaDon == hoaDon_NhapXuat.MaHoaDon)
                                {
                                    _hoaDon_NhapXuatList.Remove(hoaDon_NhapXuat);
                                    break;
                                }
                            }
                            foreach (ChungTu_HoaDon chungTu_HoaDon in _chungTu_HoaDonList)
                            {
                                if (hoaDon.MaHoaDon == chungTu_HoaDon.MaHoaDon)
                                {
                                    _chungTu_HoaDonList.Remove(chungTu_HoaDon);
                                    break;
                                }
                            }
                        }
                    }
                    //
                    else
                    {
                        if (hoaDon.Check == true)
                        {
                            _hoaDon_NhapXuatList.Add(HoaDon_NhapXuat.NewHoaDon_NhapXuat(hoaDon.MaHoaDon));
                            ChungTu_HoaDonList ct_hd = ChungTu_HoaDonList.GetChungTu_HoaDonByMaHoaDonList(hoaDon.MaHoaDon);
                            if (ct_hd.Count == 0)
                                _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(hoaDon));
                        }
                    }
                }
            }
            this.Close();
        }

        private void btn_HoaDonKhongVAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region Modify
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_phieuNhapXuat, true);
            frmhoadondichvu.ShowDialog();
            if (_loai == 1)
                _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
            else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
            #endregion Modify

            #region Old
            //frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_maDoiTac, DateTime.Today, true);
            //frmhoadondichvu.ShowDialog();
            //if (_loai == 1)
            //    _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
            //else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            //hoaDonListBindingSource.DataSource = _HoaDonList; 
            #endregion Old
        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _trangThai = false;
            this.Close();
        }

        private void barEdit_Check_EditValueChanged(object sender, EventArgs e)
        {
            if ((bool)barEdit_Check.EditValue == false)
            {
                foreach (HoaDon hoaDon in _HoaDonList)
                {
                    hoaDon.Check = false;
                }
            }
            else
            {
                foreach (HoaDon hoaDon in _HoaDonList)
                {
                    hoaDon.Check = true;
                }
            }
        }

        private void CheckEdit_Chon_EditValueChanged(object sender, EventArgs e)
        {
            //HoaDon _hd = (HoaDon)hoaDonListBindingSource.Current;
            //CheckEdit ch = (CheckEdit)sender;
            //_hd.Check = (bool)ch.EditValue;
        }

        private void barbt_HoaDonMuaBanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHoaDonMuaBanQuyen frmhoadondichvu = new frmHoaDonMuaBanQuyen(_maDoiTac, DateTime.Today, false);
            frmhoadondichvu.ShowDialog();

            if (_loai == 1)
                _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
            else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _hoaDon_NhapXuatList = _phieuNhapXuat.HoaDon_NhapXuatList;
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                //if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanCo.SoHieuTK.Contains("3113") || taiKhoanCo.SoHieuTK.Contains("3337"))
                if (PublicClass.KiemTraLaTaiKhoanThueKhauTru(taiKhoan.SoHieuTK) || PublicClass.KiemTraLaTaiKhoanThueKhauTru(taiKhoanCo.SoHieuTK))
                {
                    foreach (ChungTu_HoaDon ct_hd in _butToan.ChungTu_HoaDonList)
                        _chungTu_HoaDonList.Add(ct_hd);
                }
            }
            _HoaDonList = HoaDonList.GetHoaDonListByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
            foreach (HoaDon hoaDon in _HoaDonList)
            {
                hoaDon.Check = true;
            }
            hoaDonListBindingSource.DataSource = _HoaDonList;

            if (_HoaDonList.Count == 0)
            {
                if (_loai == 1)
                    _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
                else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
                hoaDonListBindingSource.DataSource = _HoaDonList;
            }

        }

        private void grdv_DanhSachHoaDon_DoubleClick(object sender, EventArgs e)
        {
            HoaDon hd = (HoaDon)hoaDonListBindingSource.Current;
            if (hd.LoaiHoaDon == 4)
            {
                HoaDon objHD = HoaDon.GetHoaDon(hd.MaHoaDon);
                frmHoaDonDichVuMuaVao frm = new frmHoaDonDichVuMuaVao(objHD);
                frm.ShowDialog();
            }
        }

    }
}