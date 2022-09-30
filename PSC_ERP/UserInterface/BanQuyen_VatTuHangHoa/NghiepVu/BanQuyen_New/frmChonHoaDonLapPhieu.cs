using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;

namespace PSC_ERP//26_04_2014
{
    public partial class frmChonHoaDonLapPhieuBQ : DevExpress.XtraEditors.XtraForm
    {
        long _maDoiTac;
        HoaDonList _HoaDonList = HoaDonList.NewHoaDonList();
        HoaDon_NhapXuatList _hoaDon_NhapXuatList = HoaDon_NhapXuatList.NewHoaDon_NhapXuatList();
        ChungTu_HoaDonBQList _chungTu_HoaDonList = ChungTu_HoaDonBQList.NewChungTu_HoaDonList();
        bool _trangThai = false;
        PhieuNhapXuatBQ _phieuNhapXuat;
        int _loai = 0;
        bool _khoaso = false;

        private void LoadForm()
        {
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListByTen(0);
        }

        public HoaDon_NhapXuatList HoaDon_NhapXuatList
        {
            get { return _hoaDon_NhapXuatList; }
        }

        public ChungTu_HoaDonBQList ChungTu_HoaDonList
        {
            get { return _chungTu_HoaDonList; }
        }

        public bool TrangThai
        {
            get { return _trangThai; }
        }


        public frmChonHoaDonLapPhieuBQ()
        {
            InitializeComponent();
            LoadForm();
        }

        public frmChonHoaDonLapPhieuBQ(long maDoiTac)
        {
            InitializeComponent();
            LoadForm();
            _maDoiTac = maDoiTac;
            _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
        }

        public frmChonHoaDonLapPhieuBQ(long maDoiTac, int loai, bool khoaso)
        {
            khoaso = _khoaso;
            InitializeComponent();
            LoadForm();
            _maDoiTac = maDoiTac;
            _loai = loai;
            if (_loai == 1 || _loai == 4)
                _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
            else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
        }


        public frmChonHoaDonLapPhieuBQ(PhieuNhapXuatBQ phieuNhapXuat, bool khoaso)
        {
            khoaso = _khoaso;
            InitializeComponent();
            LoadForm();
            _phieuNhapXuat = phieuNhapXuat;
            _maDoiTac = phieuNhapXuat.MaDoiTac;//M
            _hoaDon_NhapXuatList = phieuNhapXuat.HoaDon_NhapXuatList;
            foreach (ButToanPhieuNhapXuatBQ _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanCo.SoHieuTK.Contains("3113") || taiKhoanCo.SoHieuTK.Contains("3337"))
                {
                    foreach (ChungTu_HoaDonBQ ct_hd in _butToan.ChungTu_HoaDonList)
                        _chungTu_HoaDonList.Add(ct_hd);
                }
            }
            _HoaDonList = HoaDonList.GetHoaDonListByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
            foreach (HoaDon hoaDon in _HoaDonList)
            {
                hoaDon.Check = true;
            }
            hoaDonListBindingSource.DataSource = _HoaDonList;
        }

        private void btn_HoaDonVAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_maDoiTac, DateTime.Today, false);
            frmhoadondichvu.ShowDialog();

            if (_loai == 1)
                _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
            else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
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
            if (_phieuNhapXuat == null)
            {
                foreach (HoaDon hoaDon in _HoaDonList)
                {
                    if (hoaDon.Check == true)
                    {
                        _hoaDon_NhapXuatList.Add(HoaDon_NhapXuat.NewHoaDon_NhapXuat(hoaDon.MaHoaDon));
                        ChungTu_HoaDonBQList ct_hd = ChungTu_HoaDonBQList.GetChungTu_HoaDonByMaHoaDonList(hoaDon.MaHoaDon);
                        if (ct_hd.Count == 0)
                            _chungTu_HoaDonList.Add(ChungTu_HoaDonBQ.NewChungTu_HoaDon(hoaDon));
                    }
                }
            }
            else
            {
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
                            foreach (ChungTu_HoaDonBQ chungTu_HoaDon in _chungTu_HoaDonList)
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
                            ChungTu_HoaDonBQList ct_hd = ChungTu_HoaDonBQList.GetChungTu_HoaDonByMaHoaDonList(hoaDon.MaHoaDon);
                            if (ct_hd.Count == 0)
                                _chungTu_HoaDonList.Add(ChungTu_HoaDonBQ.NewChungTu_HoaDon(hoaDon));
                        }
                    }
                }
            }
            this.Close();
        }

        private void btn_HoaDonKhongVAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_maDoiTac, DateTime.Today, true);
            frmhoadondichvu.ShowDialog();
            if (_loai == 1)
                _HoaDonList = HoaDonList.GetHoaDonBanQuyenList(_maDoiTac, 0);
            else _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
            hoaDonListBindingSource.DataSource = _HoaDonList;
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

        private void grdv_DanhSachHoaDon_DoubleClick(object sender, EventArgs e)
        {
            if (_khoaso)
            {
                MessageBox.Show(this, "Đã khóa sổ không thể chỉnh sửa hóa đơn cảu phiếu nhập!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                #region xuly sua Hoa Don
                if (grdv_DanhSachHoaDon.GetFocusedRow() != null)
                {
                    HoaDon _HoaDon = HoaDon.NewHoaDon();
                    _HoaDon =HoaDon.GetHoaDon(((HoaDon)grdv_DanhSachHoaDon.GetFocusedRow()).MaHoaDon);
                    if (_HoaDon.LoaiHoaDon == 4) // mua vao 
                    {
                        frmHoaDonDichVuMuaVao _frmHoaDonDichVu = new frmHoaDonDichVuMuaVao( _HoaDon);
                        if (_frmHoaDonDichVu.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        {
                            if (_phieuNhapXuat != null)//Load Hoa Don Theo Phieu Nhap
                            {
                                _HoaDonList = HoaDonList.GetHoaDonListByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
                                foreach (HoaDon hoaDon in _HoaDonList)
                                {
                                    hoaDon.Check = true;
                                }

                            }
                            else//Load Hoa Don Theo Doi Tac
                            {
                                _HoaDonList = HoaDonList.GetHoaDonListLapPhieu(_maDoiTac, 4, 0);
                            }
                            hoaDonListBindingSource.DataSource = _HoaDonList;
                        }
                    }

                    else // ban ra
                    {
                        frmHoaDonDichVuBanRa _frmHoaDonDichVu = new frmHoaDonDichVuBanRa(_HoaDon);
                        if (_frmHoaDonDichVu.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        {
                            if (_phieuNhapXuat != null)//Load Hoa Don Theo Phieu Nhap
                            {
                                _HoaDonList = HoaDonList.GetHoaDonListByMaPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
                                foreach (HoaDon hoaDon in _HoaDonList)
                                {
                                    hoaDon.Check = true;
                                }

                            }
                            hoaDonListBindingSource.DataSource = _HoaDonList;
                        }
                    }
                }
                
                #endregion //xuly sua Hoa Don
            }
        }


    }
}