using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using PSC_ERP.Main;//TT_BXLO
namespace PSC_ERP
{
    //TT22
    public partial class frmQuyetDinhNangLuong : Form
    {
        #region Properties
        QuyetDinhNangLuongList _quyetDinhNangLuongList=QuyetDinhNangLuongList.NewQuyetDinhNangLuongList();
        QuyetDinhNangLuong _quyetDinhNangLuong;
        NhanVien _nhanVien;
        int kieuNangLuong = 0;
        private long maNhanVien = 0;
        private bool GridActive = true;
       
        private decimal heSoBHMoi = 0;
        private decimal heSoCu = 0;

        public decimal HeSoCu
        {
            get { return heSoCu; }
            set 
            { 
                heSoCu = value;
                tbHeSo.Value = heSoCu;
            }
        }
        private DateTime ngayHieuLuc = DateTime.Today.Date;
        private DateTime ngayMocThoiGian = DateTime.Today.Date;
        private DateTime ngayLap = DateTime.Today.Date;

        NhomNgachLuongCoBanList _NhomNgachLuongBaoHiemList;

        NhomNgachLuongCoBanList _nhomNgachCoBanList;
        NgachLuongCoBanList _ngachCoBanList;
        BacLuongCoBanList _bacLuongCoBanList;

        BacLuongCoBanList _BacLuongBaoHiemList;

        NgachLuongCoBanList _NgachLuongBaoHiemList;
        LoaiNhanVienList _LoaiNhanVienList;
        #endregion

        #region Load
        public frmQuyetDinhNangLuong()
        {
            InitializeComponent();
            kieuNangLuong = 3;
            cmb_KieuTangLuong.Value = 3;
        }

        private void frmQuyetDinhNangLuong_Load(object sender, EventArgs e)
        {
            _quyetDinhNangLuongList = QuyetDinhNangLuongList.NewQuyetDinhNangLuongList();
            this.bindingSource1_QuyetDinhNangLuong.DataSource = _quyetDinhNangLuongList;

            mfnc_LoadConTrolBanDau();

            //Load combobox và chọn loại cho nhân viên đó !
            _LoaiNhanVienList = LoaiNhanVienList.GetLoaiNhanVienList();
            this.bindingSource1_LoaiNhanVien.DataSource = _LoaiNhanVienList;
        }

        private void cbNgachLuongNB_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNgachLuongBH_LoadGiaoDien(cbNgachLuongNB);
        }

        private void ultraCombo2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNgachLuong_LoadGiaoDien(cmbNgachLuongCB);
        }

        private void cbBacLuongNB_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxBacLuongBH_LoadGiaoDien(cbBacLuongNB);
        }

        private void ultraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxBacLuong_LoadGiaoDien(cbBacLuongCoBan);
        }

        private void cmbu_NhomNgachMoi_Kieu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNhomNgachLuong_LoadGiaoDien(cmbu_NhomNgachMoi_Kieu);
        }

        private void cmbu_NgachMoi_Kieu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNgachLuong_LoadGiaoDien(cmbu_NgachMoi_Kieu);
        }

        private void cmbu_BacLuongMoi_Kieu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxBacLuong_LoadGiaoDien(cmbu_BacLuongMoi_Kieu);
        }

        private void cmbu_NhomNgachBHMoi_Kieu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNhomNgachLuongBH_LoadGiaoDien(cmbu_NhomNgachBHMoi_Kieu);
        }

        private void cmbu_NgachBHMoi_Kieu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNgachLuongBH_LoadGiaoDien(cmbu_NgachBHMoi_Kieu);
        }

        private void cmbu_BacLuongBHMoi_Kieu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxBacLuongBH_LoadGiaoDien(cmbu_BacLuongBHMoi_Kieu);
        }

        private void cmbu_NhomNgachMoi_Cl_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNhomNgachLuong_LoadGiaoDien(cmbu_NhomNgachMoi_Cl);
        }

        private void cmbu_NgachLuongMoi_Cl_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNgachLuong_LoadGiaoDien(cmbu_NgachLuongMoi_Cl);
        }

        private void cmbu_BacLuongMoi_Cl_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxBacLuong_LoadGiaoDien(cmbu_BacLuongMoi_Cl);
        }

        private void cmbu_NhomNgachBHMoi_Cl_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNhomNgachLuongBH_LoadGiaoDien(cmbu_NhomNgachBHMoi_Cl);
        }

        private void cmbu_NgachLuongBHMoi_Cl_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNgachLuongBH_LoadGiaoDien(cmbu_NgachLuongBHMoi_Cl);
        }

        private void cmbu_BacLuongBHMoi_Cl_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxBacLuongBH_LoadGiaoDien(cmbu_BacLuongBHMoi_Cl);
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
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 0;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].CellActivation = Activation.AllowEdit;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Họ Tên";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemCu"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemCu"].Header.Caption = "Bậc BH Cũ";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemCu"].Header.VisiblePosition = 2;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemCu"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemCu"].Header.Caption = "HSBH Cũ";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemCu"].Header.VisiblePosition = 3;


            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemMoi"].Header.Caption = "HSBH Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemMoi"].Header.VisiblePosition = 4;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemMoi"].Header.Caption = "Bậc BH Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemMoi"].Header.VisiblePosition = 5;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacCoBanCu"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacCoBanCu"].Header.Caption = "Bậc CB Cũ";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacCoBanCu"].Header.VisiblePosition = 6;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoLuongCu"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoLuongCu"].Header.Caption = "HSL Cũ";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoLuongCu"].Header.VisiblePosition = 7;


            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoLuongMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoLuongMoi"].Header.Caption = "HSL Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoLuongMoi"].Header.VisiblePosition = 8;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacCoBanMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacCoBanMoi"].Header.Caption = "Bậc CB Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacCoBanMoi"].Header.VisiblePosition = 9;


            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSVKCu"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSVKCu"].Header.Caption = "HSVK Cũ";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSVKCu"].Header.VisiblePosition = 10;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSVKMoi"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSVKMoi"].Header.Caption = "HSVK Mới";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HSVKMoi"].Header.VisiblePosition = 11;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.Caption = "Ngày Hiệu Lực";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.VisiblePosition = 12;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].Header.Caption = "Mốc Thời Gian";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].Header.VisiblePosition = 13;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.Caption = "Ngày Quyết Định";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.VisiblePosition = 14;

        }

        private void cbNhomNgachBaoHiem_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNhomNgachLuongBH_LoadGiaoDien(cbNhomNgachBaoHiem);
        }

        private void ultraCombo3_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            ComboboxNhomNgachLuong_LoadGiaoDien(cmbNhomNgachLuong);
        }

        #endregion

        #region Process
        private void mfnc_LoadConTrolBanDau()
        {
            //Set lại toàn bộ thông tin ngạch bậc cơ bản , bảo hiểm của người dùng = về trạng thái chưa chọn !
            _nhomNgachCoBanList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
            _nhomNgachCoBanList.Insert(0, NhomNgachLuongCoBan.NewNhomNgachLuongCoBan(0, "<Chưa chọn>"));
            this.bindingSource1_NhomNgachLuong.DataSource = _nhomNgachCoBanList;

            _NhomNgachLuongBaoHiemList = NhomNgachLuongCoBanList.GetNhomNgachLuongCoBanListAll();
            _NhomNgachLuongBaoHiemList.Insert(0, NhomNgachLuongCoBan.NewNhomNgachLuongCoBan(0, "<Chưa chọn>"));
            this.bindingSource1_NhomNgachBH.DataSource = _NhomNgachLuongBaoHiemList;

            _NgachLuongBaoHiemList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            _NgachLuongBaoHiemList.Insert(0, NgachLuongCoBan.NewNgachLuongCoBan(0, "<Chưa chọn>"));
            this.bindingSource1_NgachBH.DataSource = _NgachLuongBaoHiemList;

            _BacLuongBaoHiemList = BacLuongCoBanList.GetBacLuongCoBanListAll();
            _BacLuongBaoHiemList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
            this.bindingSource1_BacBH.DataSource = _BacLuongBaoHiemList;

            _ngachCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanList();
            _ngachCoBanList.Insert(0, NgachLuongCoBan.NewNgachLuongCoBan(0, "<Chưa chọn>"));
            this.bindingSource1_NgachLuong.DataSource = _ngachCoBanList;

            _bacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanListAll();
            _bacLuongCoBanList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
            this.bindingSource1_BacLuong.DataSource = _bacLuongCoBanList;

        }

        #region Thêm mới của anh Lân
        private void New()
        {
            decimal HSLuongBHNext = 0;
            int maBacLuongBHNext = 0;

            decimal _heSoLuongNext = 0;
            int maBacLuongCoBanNext = 0;

            BacLuongCoBanList _listBacLuongBH = BacLuongCoBanList.GetBacLuongCoBanList(_nhanVien.MaNgachLuongBaoHiem);
            BacLuongCoBanList _listBacLuongCB = BacLuongCoBanList.GetBacLuongCoBanList(_nhanVien.MaNgachLuongCoBan);

            decimal _heSoLuongBH = _nhanVien.HeSoLuongBaoHiem;
            decimal _heSoLuong = _nhanVien.HeSoLuong;
            QuyetDinhNangLuong _nangLuong = QuyetDinhNangLuong.NewQuyetDinhNangLuong(maNhanVien, _heSoLuongBH);
            decimal HSVK = _nhanVien.HeSoVuotKhung;

            _heSoLuongNext = _heSoLuong;
            for (int j = 0; j < _listBacLuongCB.Count; j++)
            {
                //if (kieuNangLuong != 3)
                // {
                if (_heSoLuong < _listBacLuongCB[j].HeSoLuong)
                {
                    _heSoLuongNext = _listBacLuongCB[j].HeSoLuong;//Hệ Số Kế Tiếp
                    break;
                }
                // }
            }
            maBacLuongCoBanNext = BacLuongCoBan.GetBacLuongCoBanByHeSoLuong(_heSoLuongNext, _nhanVien.MaNgachLuongCoBan).MaBacLuongCoBan;
            HSLuongBHNext = _heSoLuongBH;
            for (int j = 0; j < _listBacLuongBH.Count; j++)
            {
                if (_heSoLuongBH < _listBacLuongBH[j].HeSoLuong)
                {
                    HSLuongBHNext = _listBacLuongBH[j].HeSoLuong;//Hệ Số Kế Tiếp
                    break;

                }
            }
            if (HSLuongBHNext > _heSoLuongBH)
            {

                //maNgachLuongBHNext = BacLuongNoiBo.BacLuongNoiBoByHeSoLuong(HSLuongBHNext).MaNgachLuongNoiBo;
                maBacLuongBHNext = BacLuongCoBan.GetBacLuongCoBanByHeSoLuong(HSLuongBHNext, _nhanVien.MaNgachLuongBaoHiem).MaBacLuongCoBan;
            }


            else if ((HSLuongBHNext == _heSoLuongBH) && HSVK == 0)//Hết Bậc Lương tăng Vượt Khung lần đầu.
            {
                HSVK = 5;

            }
            else if ((HSLuongBHNext == _heSoLuongBH) && HSVK != 0)//Hết Bậc Lương tăng Vượt Khung lần Sau.
            {
                HSVK = HSVK + 1;
            }



            //Nếu loại nhân viên =1 or 4: Tăng bậc lương cơ bản, lương bảo hiểm. Ngược lại chỉ tăng lương bảo hiểm
            _nangLuong.MocNangLuong = _nhanVien.MocLenLuong;
            _nangLuong.MocNangLuongBH = _nhanVien.MocLenLuongBaoHiem;
            if (_nhanVien.LoaiNV == 1 || _nhanVien.LoaiNV == 4)
            {
                cmb_KieuTangLuong.Value = 1;
                _nangLuong.KieuNangLuong = 1;
                _nangLuong.TenNhanVien = _nhanVien.TenNhanVien;
                _nangLuong.MaBacBaoHiemCu = _nhanVien.MaBacLuongBaoHiem;
                _nangLuong.MaBoPhan = _nhanVien.MaBoPhan;
                _nangLuong.MaChucVu = _nhanVien.MaChucVu;
                _nangLuong.MaNgachBaoHiemCu = _nhanVien.MaNgachLuongBaoHiem;

                _nangLuong.MaNgachCoBanCu = _nhanVien.MaNgachLuongCoBan;
                _nangLuong.MaNgachLuongCoBanMoi = _nhanVien.MaNgachLuongCoBan;
                _nangLuong.MaNgachBaoHiemMoi = _nhanVien.MaNgachLuongBaoHiem;
                _nangLuong.TenNgachBaoHiemMoi = NgachLuongCoBan.GetNgachLuongCoBan(_nhanVien.MaBacLuongBaoHiem).TenNgachLuongCoBan;
                _nangLuong.MaBacLuongCoBanCu = _nhanVien.MaBacLuongCoBan;
                _nangLuong.HeSoLuongCu = _nhanVien.HeSoLuong;

                _nangLuong.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                _nangLuong.TenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemCu).MaQuanLy;
                _nangLuong.TenNgachBaoHiemCu = _nhanVien.TenNgachLuongBaoHiem;
                _nangLuong.LoaiNhanVienCu = _nhanVien.LoaiNV;
                _nangLuong.LoaiNhanVienMoi = _nhanVien.LoaiNV;
                _nangLuong.HeSoNBCu = _nhanVien.HeSoLuongNoiBo;
                _nangLuong.HeSoNBMoi = _nhanVien.HeSoLuongNoiBo;

                if (HSVK == 0)
                {
                    //_nangLuong.HeSoBaoHiemMoi = HSLuongBHNext;
                    _nangLuong.MaBacBaoHiemMoi = maBacLuongBHNext;
                    _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemMoi).MaQuanLy;
                    cbBacLuongNB.Text = _nangLuong.TenBacBaoHiemMoi;
                    //_nangLuong.HeSoLuongMoi = _heSoLuongNext;
                    _nangLuong.MaBacLuongCoBanMoi = maBacLuongCoBanNext;
                    _nangLuong.TenBacCoBanMoi = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemMoi).MaQuanLy;
                    cbBacLuongCoBan.Text = _nangLuong.TenBacCoBanMoi;

                }
                else
                {
                    _nangLuong.HeSoBaoHiemMoi = _heSoLuongBH;
                    _nangLuong.MaBacBaoHiemMoi = _nangLuong.MaBacBaoHiemCu;
                    _nangLuong.TenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemCu).MaQuanLy;
                    _nangLuong.TenNgachBaoHiemMoi = _nhanVien.TenNgachLuongBaoHiem;

                    _nangLuong.HeSoLuongMoi = _heSoLuongNext;
                    _nangLuong.MaBacLuongCoBanMoi = maBacLuongCoBanNext;
                    _nangLuong.HSVKMoi = HSVK;
                    _nangLuong.HSVKBHMoi = HSVK;

                }
            }
            else//Loại nhân viên khác
            {
                cmb_KieuTangLuong.Value = 3;
                _nangLuong.KieuNangLuong = 3;
                _nangLuong.TenNhanVien = _nhanVien.TenNhanVien;
                _nangLuong.MaBacBaoHiemCu = _nhanVien.MaBacLuongBaoHiem;
                _nangLuong.MaBoPhan = _nhanVien.MaBoPhan;
                _nangLuong.MaChucVu = _nhanVien.MaChucVu;
                _nangLuong.MaNgachBaoHiemCu = _nhanVien.MaNgachLuongBaoHiem;

                _nangLuong.MaNgachCoBanCu = _nhanVien.MaNgachLuongCoBan;
                _nangLuong.MaNgachLuongCoBanMoi = _nhanVien.MaNgachLuongCoBan;
                _nangLuong.MaNgachBaoHiemMoi = _nhanVien.MaNgachLuongBaoHiem;
                _nangLuong.TenNgachBaoHiemMoi = NgachLuongCoBan.GetNgachLuongCoBan(_nhanVien.MaBacLuongBaoHiem).TenNgachLuongCoBan;
                _nangLuong.MaBacLuongCoBanCu = _nhanVien.MaBacLuongCoBan;
                _nangLuong.HeSoLuongCu = _nhanVien.HeSoLuong;

                _nangLuong.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                _nangLuong.TenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemCu).MaQuanLy;
                _nangLuong.TenNgachBaoHiemCu = _nhanVien.TenNgachLuongBaoHiem;
                _nangLuong.HeSoNBCu = _nhanVien.HeSoLuongNoiBo;
                _nangLuong.HeSoNBMoi = _nhanVien.HeSoLuongNoiBo;

                if (HSVK == 0)
                {
                    //  _nangLuong.HeSoBaoHiemMoi = HSLuongBHNext;
                    _nangLuong.MaBacBaoHiemMoi = maBacLuongBHNext;
                    _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemMoi).MaQuanLy;
                    //cbBacLuongNB.Text = _nangLuong.TenBacBaoHiemMoi;
                    _nangLuong.MaBacLuongCoBanMoi = _nhanVien.MaBacLuongCoBan;
                    _nangLuong.TenBacCoBanMoi = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacLuongCoBanMoi).MaQuanLy;
                    //cbBacLuongCoBan.Text = _nangLuong.TenBacCoBanMoi;

                }
                else
                {
                    //  _nangLuong.HeSoBaoHiemMoi = _heSoLuongBH;
                    _nangLuong.MaBacBaoHiemMoi = _nangLuong.MaBacBaoHiemCu;
                    _nangLuong.TenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemCu).MaQuanLy;
                    _nangLuong.TenNgachBaoHiemMoi = _nhanVien.TenNgachLuongBaoHiem;

                    //  _nangLuong.HeSoLuongMoi = _nhanVien.HeSoLuong;
                    _nangLuong.MaBacLuongCoBanMoi = _nhanVien.MaBacLuongCoBan;
                    _nangLuong.HSVKMoi = HSVK;
                    _nangLuong.HSVKBHMoi = HSVK;

                }
            }
            //Với kiểu nâng tự động thì set kiểu = 0
            //_nangLuong.KieuNangLuong = 0;
            GridActive = true;
            _quyetDinhNangLuongList.Add(_nangLuong);

            grdu_DanhSachNangLuong.ActiveRow = grdu_DanhSachNangLuong.Rows[_quyetDinhNangLuongList.Count - 1];

            _nhanVien.HeSoVuotKhung = _nangLuong.HSVKMoi;
            _nhanVien.HeSoVuotKhungBH = _nangLuong.HSVKBHMoi;
            _nhanVien.MaNgachLuongCoBan = _nangLuong.MaNgachLuongCoBanMoi;
            _nhanVien.MaBacLuongCoBan = _nangLuong.MaBacLuongCoBanMoi;
            _nhanVien.HeSoLuong = _nangLuong.HeSoLuongMoi;

            _nhanVien.MaNgachLuongBaoHiem = _nangLuong.MaNgachBaoHiemMoi;
            _nhanVien.MaBacLuongBaoHiem = _nangLuong.MaBacBaoHiemMoi;
            _nhanVien.HeSoLuongBaoHiem = _nangLuong.HeSoBaoHiemMoi;

        }
        #endregion

        #region Thêm mới theo kiểu (nâng cả 2, nâng lương, nâng bảo hiểm, hoặc chuyển ngạch)
        private void New_TheoKieu()
        {
            decimal HSLuongBHNext = 0;
            int maBacLuongBHNext = 0;

            decimal _heSoLuongNext = 0;
            int maBacLuongCoBanNext = 0;

            BacLuongCoBanList _listBacLuongBH = BacLuongCoBanList.GetBacLuongCoBanList(_nhanVien.MaNgachLuongBaoHiem);
            BacLuongCoBanList _listBacLuongCB = BacLuongCoBanList.GetBacLuongCoBanList(_nhanVien.MaNgachLuongCoBan);

            decimal _heSoLuongBH = _nhanVien.HeSoLuongBaoHiem;
            decimal _heSoLuong = _nhanVien.HeSoLuong;
            QuyetDinhNangLuong _nangLuong = QuyetDinhNangLuong.NewQuyetDinhNangLuong(maNhanVien, _heSoLuongBH);
            decimal HSVK = _nhanVien.HeSoVuotKhung;

            _heSoLuongNext = _heSoLuong;
            for (int j = 0; j < _listBacLuongCB.Count; j++)
            {
                if (_heSoLuong < _listBacLuongCB[j].HeSoLuong)
                {
                    _heSoLuongNext = _listBacLuongCB[j].HeSoLuong;//Hệ Số Lương Kế Tiếp
                    break;
                }
            }
            maBacLuongCoBanNext = BacLuongCoBan.GetBacLuongCoBanByHeSoLuong(_heSoLuongNext, _nhanVien.MaNgachLuongCoBan).MaBacLuongCoBan;

            HSLuongBHNext = _heSoLuongBH;
            for (int j = 0; j < _listBacLuongBH.Count; j++)
            {
                if (_heSoLuongBH < _listBacLuongBH[j].HeSoLuong)
                {
                    HSLuongBHNext = _listBacLuongBH[j].HeSoLuong;//Hệ Số Bảo hiểm Kế Tiếp
                    break;
                }
            }

            maBacLuongBHNext = BacLuongCoBan.GetBacLuongCoBanByHeSoLuong(HSLuongBHNext, _nhanVien.MaNgachLuongBaoHiem).MaBacLuongCoBan;

            if ((HSLuongBHNext == _heSoLuongBH) && HSVK == 0)//Hết Bậc Lương tăng Vượt Khung lần đầu.
            {
                HSVK = 5;

            }
            else if ((HSLuongBHNext == _heSoLuongBH) && HSVK != 0)//Hết Bậc Lương tăng Vượt Khung lần Sau.
            {
                HSVK = HSVK + 1;
            }

            _nangLuong.MocNangLuong = _nhanVien.MocLenLuong;
            _nangLuong.MocNangLuongBH = _nhanVien.MocLenLuongBaoHiem;
            int iLoaiNangLuong = Convert.ToInt32(cmb_KieuTangLuong.Value);
            //Các thông tin cơ bản của quyết định
            _nangLuong.TenNhanVien = _nhanVien.TenNhanVien;
            _nangLuong.MaBacBaoHiemCu = _nhanVien.MaBacLuongBaoHiem;
            _nangLuong.MaBoPhan = _nhanVien.MaBoPhan;
            _nangLuong.MaChucVu = _nhanVien.MaChucVu;

            //Ngạch, bậc, hệ số, HSVK lương cũ
            _nangLuong.MaNgachCoBanCu = _nhanVien.MaNgachLuongCoBan;
            _nangLuong.MaBacLuongCoBanCu = _nhanVien.MaBacLuongCoBan;
            _nangLuong.HeSoLuongCu = _nhanVien.HeSoLuong;

            //Ngạch, bậc, hệ số, HSVK BH cũ
            _nangLuong.MaNgachBaoHiemCu = _nhanVien.MaNgachLuongBaoHiem;
            _nangLuong.TenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemCu).MaQuanLy;
            _nangLuong.TenNgachBaoHiemCu = _nhanVien.TenNgachLuongBaoHiem;
            _nangLuong.HeSoBaoHiemCu = _nhanVien.HeSoLuongBaoHiem;

            //Mặc định loại nhân viên mới là loại nhân viên hiện tại
            _nangLuong.LoaiNhanVienCu = _nhanVien.LoaiNV;
            _nangLuong.LoaiNhanVienMoi = _nhanVien.LoaiNV;

            //Hệ số nội bộ mới = hệ số nội bộ cũ
            _nangLuong.HeSoNBCu = _nhanVien.HeSoLuongNoiBo;
            _nangLuong.HeSoNBMoi = _nhanVien.HeSoLuongNoiBo;

            _nangLuong.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

            if (iLoaiNangLuong != 4)
            {
                _nangLuong.MaNgachLuongCoBanMoi = _nhanVien.MaNgachLuongCoBan;
                _nangLuong.MaNgachBaoHiemMoi = _nhanVien.MaNgachLuongBaoHiem;
            }

            //Nếu tăng cả 2
            if (iLoaiNangLuong == 1)
            {
                cmb_KieuTangLuong.Value = 1;
                _nangLuong.KieuNangLuong = 1;
            }
            else if (iLoaiNangLuong == 2)
            {
                cmb_KieuTangLuong.Value = 2;
                _nangLuong.KieuNangLuong = 2;
            }
            else if (iLoaiNangLuong == 3)
            {
                cmb_KieuTangLuong.Value = 3;
                _nangLuong.KieuNangLuong = 3;
            }
            else if (iLoaiNangLuong == 4)
            {
                cmb_KieuTangLuong.Value = 4;
                _nangLuong.KieuNangLuong = 4;
            }

            //Xét hệ số vượt khung
            if (HSVK == 0)
            {
                //Nếu tăng cả 2
                if (iLoaiNangLuong == 1)
                {
                    //Tăng bậc lương cơ bản
                    _nangLuong.MaBacLuongCoBanMoi = maBacLuongCoBanNext;
                    _nangLuong.TenBacCoBanMoi = BacLuongCoBan.GetBacLuongCoBan(maBacLuongCoBanNext).MaQuanLy;
                    cmbu_BacLuongMoi_Kieu.Value = maBacLuongCoBanNext;

                    //Tăng bậc bảo hiểm
                    _nangLuong.MaBacBaoHiemMoi = maBacLuongBHNext;
                    _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(maBacLuongBHNext).MaQuanLy;
                    cmbu_BacLuongBHMoi_Kieu.Value = _nhanVien.MaBacLuongBaoHiem;

                }
                else if (iLoaiNangLuong == 2)
                {
                    //Tăng bậc lương cơ bản
                    _nangLuong.MaBacLuongCoBanMoi = maBacLuongCoBanNext;
                    _nangLuong.TenBacCoBanMoi = BacLuongCoBan.GetBacLuongCoBan(maBacLuongCoBanNext).MaQuanLy;
                    cmbu_BacLuongMoi_Kieu.Value = maBacLuongCoBanNext;

                    //Không tăng bậc bảo hiểm
                    _nangLuong.MaBacBaoHiemMoi = _nhanVien.MaBacLuongBaoHiem;
                    _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongBaoHiem).MaQuanLy;
                    cmbu_BacLuongBHMoi_Kieu.Value = _nhanVien.MaBacLuongBaoHiem;
                }
                else if (iLoaiNangLuong == 3)
                {
                    //Không tăng bậc lương cơ bản
                    _nangLuong.MaBacLuongCoBanMoi = _nhanVien.MaBacLuongCoBan;
                    _nangLuong.TenBacCoBanMoi = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongCoBan).MaQuanLy;
                    cmbu_BacLuongMoi_Kieu.Value = maBacLuongCoBanNext;

                    //Tăng bậc bảo hiểm
                    _nangLuong.MaBacBaoHiemMoi = maBacLuongBHNext;
                    _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(maBacLuongBHNext).MaQuanLy;
                    cmbu_BacLuongBHMoi_Kieu.Value = _nhanVien.MaBacLuongBaoHiem;
                }
            }
            else
            {
                //Không tăng bậc lương cơ bản
                _nangLuong.MaBacLuongCoBanMoi = _nhanVien.MaBacLuongCoBan;
                _nangLuong.TenBacCoBanMoi = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongCoBan).MaQuanLy;
                cmbu_BacLuongMoi_Kieu.Value = maBacLuongCoBanNext;

                //Không tăng bậc bảo hiểm
                _nangLuong.MaBacBaoHiemMoi = _nhanVien.MaBacLuongBaoHiem;
                _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongBaoHiem).MaQuanLy;
                cmbu_BacLuongBHMoi_Kieu.Value = _nhanVien.MaBacLuongBaoHiem;

                //Nguyên nhân lấy thông tin
                _nangLuong.HSVKMoi = HSVK;
                _nangLuong.HSVKBHMoi = HSVK;

                //Nếu tăng cả 2
                if (iLoaiNangLuong == 1)
                {
                    _nangLuong.MaBacLuongCoBanMoi = maBacLuongCoBanNext;
                    _nangLuong.MaBacBaoHiemMoi = maBacLuongBHNext;
                }
                //Nếu loại nâng lương = 2 (Chỉ nâng lương) 
                else if (iLoaiNangLuong == 2)
                {
                    _nangLuong.MaBacBaoHiemMoi = _nhanVien.MaBacLuongBaoHiem;
                    _nangLuong.MaBacLuongCoBanMoi = maBacLuongCoBanNext;
                }
                //Nếu loại nâng lương = 1 (Chỉ nâng bảo hiểm)
                else if (iLoaiNangLuong == 3)
                {
                    _nangLuong.MaBacBaoHiemMoi = maBacLuongBHNext;
                    _nangLuong.MaBacLuongCoBanMoi = _nhanVien.MaBacLuongCoBan;
                }

                _nangLuong.TenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemCu).MaQuanLy;
                _nangLuong.TenNgachBaoHiemMoi = _nhanVien.TenNgachLuongBaoHiem;

                _nangLuong.HSVKMoi = HSVK;
                _nangLuong.HSVKBHMoi = HSVK;
            }

            _nangLuong.KieuNangLuong = kieuNangLuong;

            if (iLoaiNangLuong == 4)
            {
                cmbu_NhomNgachBHMoi_Kieu.Value = _nhomNgachCoBanList[0].MaNhomNgachLuongCoBan;
                cmbu_NhomNgachMoi_Kieu.Value = _NhomNgachLuongBaoHiemList[0].MaNhomNgachLuongCoBan;

                cmbu_NgachMoi_Kieu.Value = _ngachCoBanList[0].MaNgachLuongCoBan;
                cmbu_NgachBHMoi_Kieu.Value = _NgachLuongBaoHiemList[0].MaNgachLuongCoBan;

                if (_bacLuongCoBanList.Count < 1)
                {
                    _bacLuongCoBanList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
                }
                cmbu_BacLuongMoi_Kieu.Value = _bacLuongCoBanList[0].MaBacLuongCoBan;
                if (_BacLuongBaoHiemList.Count < 1)
                {
                    _BacLuongBaoHiemList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
                }
                cmbu_BacLuongBHMoi_Kieu.Value = _BacLuongBaoHiemList[0].MaBacLuongCoBan;

                mnu_HSVKMoi_Kieu.Value = 0;
                mnu_HSVKBHMoi_Kieu.Value = 0;

                _nangLuong.ApplyEdit();
            }

            //bindingSource1_QuyetDinhNangLuong.EndEdit();
            //Cập nhật lại thông tin cho nhân viên
            _nhanVien.HeSoVuotKhung = _nangLuong.HSVKMoi;
            _nhanVien.HeSoVuotKhungBH = _nangLuong.HSVKBHMoi;
            _nhanVien.MaNhomNgachLuongBaoHiem = _nangLuong.MaNhomBaoHiemNgach;
            _nhanVien.MaNhomNgachLuongCB = _nangLuong.MaNhomNgachCoBan;
            _nhanVien.MaNgachLuongCoBan = _nangLuong.MaNgachLuongCoBanMoi;
            _nhanVien.MaBacLuongCoBan = _nangLuong.MaBacLuongCoBanMoi;
            _nhanVien.HeSoLuong = _nangLuong.HeSoLuongMoi;

            _nhanVien.MaNgachLuongBaoHiem = _nangLuong.MaNgachBaoHiemMoi;
            _nhanVien.MaBacLuongBaoHiem = _nangLuong.MaBacBaoHiemMoi;
            _nhanVien.HeSoLuongBaoHiem = _nangLuong.HeSoBaoHiemMoi;

            _nangLuong.ApplyEdit();
            _quyetDinhNangLuongList.Add(_nangLuong);

            grdu_DanhSachNangLuong.ActiveRow = grdu_DanhSachNangLuong.Rows[_quyetDinhNangLuongList.Count - 1];
        }
        #endregion

        #region Chuyển loại nhân viên
        private void New_ChuyenLoai()
        {
            QuyetDinhNangLuong _nangLuong = QuyetDinhNangLuong.NewQuyetDinhNangLuong(maNhanVien, _nhanVien.HeSoLuongBaoHiem);

            _nangLuong.MocNangLuong = _nhanVien.MocLenLuong;
            _nangLuong.MocNangLuongBH = _nhanVien.MocLenLuongBaoHiem;
            //Các thông tin cơ bản của quyết định
            _nangLuong.TenNhanVien = _nhanVien.TenNhanVien;
            _nangLuong.MaBacBaoHiemCu = _nhanVien.MaBacLuongBaoHiem;
            _nangLuong.MaBoPhan = _nhanVien.MaBoPhan;
            _nangLuong.MaChucVu = _nhanVien.MaChucVu;

            //Ngạch, bậc, hệ số, HSVK lương cũ
            _nangLuong.MaNgachCoBanCu = _nhanVien.MaNgachLuongCoBan;
            _nangLuong.MaBacLuongCoBanCu = _nhanVien.MaBacLuongCoBan;
            _nangLuong.HeSoLuongCu = _nhanVien.HeSoLuong;

            //Ngạch, bậc, hệ số, HSVK BH cũ
            _nangLuong.MaNgachBaoHiemCu = _nhanVien.MaNgachLuongBaoHiem;
            _nangLuong.TenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemCu).MaQuanLy;
            _nangLuong.TenNgachBaoHiemCu = _nhanVien.TenNgachLuongBaoHiem;
            _nangLuong.HeSoBaoHiemCu = _nhanVien.HeSoLuongBaoHiem;
            _nangLuong.LoaiNhanVienCu = _nhanVien.LoaiNV;
            _nangLuong.HeSoNBCu = _nhanVien.HeSoLuongNoiBo;
            _nangLuong.HeSoNBMoi = _nhanVien.HeSoLuongNoiBo;
            //_nangLuong.LoaiNhanVienMoi = (int)cmbu_LoaiNhanVienMoi.Value;

            _nangLuong.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

            if (cmbu_LoaiNhanVienMoi.Value != null)
            {
                _nangLuong.LoaiNhanVienMoi = (int)cmbu_LoaiNhanVienMoi.Value;
                if (_nangLuong.LoaiNhanVienMoi == 1 || _nangLuong.LoaiNhanVienMoi == 4)
                {
                    _nangLuong.KieuNangLuong = 1;
                }
                else
                {
                    _nangLuong.KieuNangLuong = 3;
                }
            }
            _quyetDinhNangLuongList.Add(_nangLuong);

            grdu_DanhSachNangLuong.ActiveRow = grdu_DanhSachNangLuong.Rows[_quyetDinhNangLuongList.Count - 1];

            //cmbu_NhomNgachBHMoi_Cl.Value = _nhomNgachCoBanList[0].MaNhomNgachLuongCoBan;
            //cmbu_NhomNgachMoi_Cl.Value = _NhomNgachLuongBaoHiemList[0].MaNhomNgachLuongCoBan;

            //cmbu_NgachLuongMoi_Cl.Value = _ngachCoBanList[0].MaNgachLuongCoBan;
            //cmbu_NgachLuongBHMoi_Cl.Value = _NgachLuongBaoHiemList[0].MaNgachLuongCoBan;

            //_nangLuong.MaNhomNgachCoBan = _nhomNgachCoBanList[0].MaNhomNgachLuongCoBan;
            //_nangLuong.MaNhomBaoHiemNgach = _NhomNgachLuongBaoHiemList[0].MaNhomNgachLuongCoBan;

            //_nangLuong.MaNgachLuongCoBanMoi = _ngachCoBanList[0].MaNgachLuongCoBan;
            //_nangLuong.MaNgachBaoHiemMoi = _NgachLuongBaoHiemList[0].MaNgachLuongCoBan;

            //if (_bacLuongCoBanList.Count < 1)
            //{
            //    _bacLuongCoBanList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
            //}
            //_nangLuong.MaBacLuongCoBanMoi = _bacLuongCoBanList[0].MaBacLuongCoBan;
            //if (_BacLuongBaoHiemList.Count < 1)
            //{
            //    _BacLuongBaoHiemList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
            //}
            //_nangLuong.MaBacBaoHiemMoi = _BacLuongBaoHiemList[0].MaBacLuongCoBan;

            cmbu_NhomNgachBHMoi_Cl.Value = _nhomNgachCoBanList[0].MaNhomNgachLuongCoBan;
            cmbu_NhomNgachMoi_Cl.Value = _NhomNgachLuongBaoHiemList[0].MaNhomNgachLuongCoBan;

            cmbu_NgachLuongMoi_Cl.Value = _ngachCoBanList[0].MaNgachLuongCoBan;
            cmbu_NgachLuongBHMoi_Cl.Value = _NgachLuongBaoHiemList[0].MaNgachLuongCoBan;

            if (_bacLuongCoBanList.Count < 1)
            {
                _bacLuongCoBanList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
            }
            cmbu_BacLuongMoi_Cl.Value = _bacLuongCoBanList[0].MaBacLuongCoBan;
            if (_BacLuongBaoHiemList.Count < 1)
            {
                _BacLuongBaoHiemList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
            }
            cmbu_BacLuongBHMoi_Cl.Value = _BacLuongBaoHiemList[0].MaBacLuongCoBan;

            mnu_HSVKMoi_CL.Value = 0;
            mnu_HSVKBHMoi_CL.Value = 0;

            _nangLuong.ApplyEdit();

            //Cập nhật lại thông tin cho nhân viên
            _nhanVien.HeSoVuotKhung = _nangLuong.HSVKMoi;
            _nhanVien.HeSoVuotKhungBH = _nangLuong.HSVKBHMoi;
            _nhanVien.MaNhomNgachLuongBaoHiem = _nangLuong.MaNhomBaoHiemNgach;
            _nhanVien.MaNhomNgachLuongCB = _nangLuong.MaNhomNgachCoBan;
            _nhanVien.MaNgachLuongCoBan = _nangLuong.MaNgachLuongCoBanMoi;
            _nhanVien.MaBacLuongCoBan = _nangLuong.MaBacLuongCoBanMoi;
            _nhanVien.HeSoLuong = _nangLuong.HeSoLuongMoi;

            _nhanVien.MaNgachLuongBaoHiem = _nangLuong.MaNgachBaoHiemMoi;
            _nhanVien.MaBacLuongBaoHiem = _nangLuong.MaBacBaoHiemMoi;
            _nhanVien.HeSoLuongBaoHiem = _nangLuong.HeSoBaoHiemMoi;

        }
        #endregion

        private void Save()
        {
            try
            {
                bindingSource1_QuyetDinhNangLuong.EndEdit();
                //Quyết định mới nhất trước khi lưu
                //int soQuyetDinh = QuyetDinhNangLuong.KiemTraNgayHieuLucMax(_nhanVien.MaNhanVien);
                //Trước khi lưu phải cập nhật thông tin về mốc nâng lương cho các quyết định
                foreach (QuyetDinhNangLuong _quyetDinh in _quyetDinhNangLuongList)
                {
                    //Tùy thuộc vào kiểu nâng lương mà mốc nâng lương nào sẽ tăng !
                    if (_quyetDinh.KieuNangLuong == 1 || _quyetDinh.KieuNangLuong == 4)
                    {
                        //Cập nhật lại ngày nâng bậc cho cả 2 ngày BH và Lương CB Trong Quyết Đinh
                        _quyetDinh.MocNangLuong = _quyetDinh.MocThoiGianNangBac;
                        _quyetDinh.MocNangLuongBH = _quyetDinh.MocThoiGianNangBac;
                    }
                    else
                        if (_quyetDinh.KieuNangLuong == 2)
                        {
                            //Cập nhật lại ngày nâng bậc cho Lương CB Trong Quyết Đinh
                            _quyetDinh.MocNangLuong = _quyetDinh.MocThoiGianNangBac;
                        }
                        else if (_quyetDinh.KieuNangLuong == 3)
                        {
                            //Cập nhật lại ngày nâng bậc cho BH Trong Quyết Đinh
                            _quyetDinh.MocNangLuongBH = _quyetDinh.MocThoiGianNangBac;
                        }
                }

                bindingSource1_QuyetDinhNangLuong.EndEdit();
                _quyetDinhNangLuongList.ApplyEdit();
                _quyetDinhNangLuongList.Save();

                int soQuyetDinh = QuyetDinhNangLuong.KiemTraNgayHieuLucMax(_nhanVien.MaNhanVien);

                _quyetDinhNangLuongList = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(maNhanVien);

                if (kieuNangLuong == 0)
                {
                    MessageBox.Show("Kiểu nâng lương chưa hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //Số quyết định mới nhất sau khi lưu


                for (int i = 0; i < _quyetDinhNangLuongList.Count; i++)
                {
                    if (_quyetDinhNangLuongList[i].MaQuyetDinh == soQuyetDinh && _quyetDinhNangLuongList[i].CapNhatSau != true)
                    {
                        //Cập nhật thông tin về lương trước
                        _nhanVien.HeSoVuotKhung = _quyetDinhNangLuongList[i].HSVKMoi;
                        _nhanVien.HeSoVuotKhungBH = _quyetDinhNangLuongList[i].HSVKBHMoi;
                        _nhanVien.MaNgachLuongCoBan = _quyetDinhNangLuongList[i].MaNgachLuongCoBanMoi;
                        _nhanVien.MaBacLuongCoBan = _quyetDinhNangLuongList[i].MaBacLuongCoBanMoi;
                        _nhanVien.HeSoLuong = _quyetDinhNangLuongList[i].HeSoLuongMoi;

                        _nhanVien.MaNhomNgachLuongBaoHiem = _quyetDinhNangLuongList[i].MaNhomBaoHiemNgach;
                        _nhanVien.MaNhomNgachLuongCB = _quyetDinhNangLuongList[i].MaNhomNgachCoBan;

                        _nhanVien.MaNgachLuongBaoHiem = _quyetDinhNangLuongList[i].MaNgachBaoHiemMoi;
                        _nhanVien.MaBacLuongBaoHiem = _quyetDinhNangLuongList[i].MaBacBaoHiemMoi;
                        _nhanVien.HeSoLuongBaoHiem = _quyetDinhNangLuongList[i].HeSoBaoHiemMoi;

                        if (_quyetDinhNangLuongList[i].LoaiNhanVienMoi != 0 &&
                            tabThongTin.SelectedTab == tabChuyenLoai)
                        {

                            _nhanVien.LoaiNV = _quyetDinhNangLuongList[i].LoaiNhanVienMoi;
                            _nhanVien.HeSoLuongNoiBo = _quyetDinhNangLuongList[i].HeSoNBMoi;

                        }

                        _nhanVien.MocLenLuong = _quyetDinhNangLuongList[i].MocNangLuong;
                        _nhanVien.MocLenLuongBaoHiem = _quyetDinhNangLuongList[i].MocNangLuongBH;

                        if (_nhanVien.MaNhomNgachLuongCB != 0 | _nhanVien.MaNhomNgachLuongBaoHiem != 0 |
                            _nhanVien.MaNgachLuongCoBan != 0 | _nhanVien.MaNgachLuongBaoHiem != 0 |
                            _nhanVien.MaBacLuongCoBan != 0 | _nhanVien.MaBacLuongBaoHiem != 0)
                        {
                            _nhanVien.ApplyEdit();
                            _nhanVien.Save(true);

                        }
                    }

                }

                grdu_DanhSachNangLuong.UpdateData();
                bindingSource1_QuyetDinhNangLuong.EndEdit();


                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _quyetDinhNangLuongList = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(maNhanVien);
                bindingSource1_QuyetDinhNangLuong.DataSource = _quyetDinhNangLuongList;
                tbHeSo.Text = NhanVien.GetNhanVien(maNhanVien).HeSoLuong.ToString();
                _nhanVien = NhanVien.GetNhanVien(maNhanVien);
                ReLoad(_nhanVien);

                //Kiểm tra cảnh báo sau khi cập nhật dữ liệu
                frmNhanSu.mfnc_KiemTraCanhBao();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ReLoad(NhanVien _nhanVien)
        {
            //Cho giao diện của nâng lương theo loại nhân viên
            txt_MaNhanVienQL.Text = _nhanVien.MaQLNhanVien;
            txt_TenNhanVien.Text = _nhanVien.TenNhanVien;
            txt_TenChucVu.Text = _nhanVien.TenChucVu;

            tbNhomNgachLuong.Text = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_nhanVien.MaNhomNgachLuongCB).TenNhomNgachLuongCoBan;
            tbNgachLuong.Text = NgachLuongCoBan.GetNgachLuongCoBan(_nhanVien.MaNgachLuongCoBan).TenNgachLuongCoBan;
            tbBacLuong.Text = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongCoBan).MaQuanLy;
            tbHeSo.Text = _nhanVien.HeSoLuong.ToString();
            tbNhomNgachBH.Text = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_nhanVien.MaNhomNgachLuongBaoHiem).TenNhomNgachLuongCoBan;
            tbNgachBH.Text = NgachLuongCoBan.GetNgachLuongCoBan(_nhanVien.MaNgachLuongBaoHiem).TenNgachLuongCoBan;
            tbBacBH.Text = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongBaoHiem).MaQuanLy;
            tbHSBaoHiem.Value = _nhanVien.HeSoLuongBaoHiem.ToString();

            tbHSVK.Text = _nhanVien.HeSoVuotKhung.ToString();
            tbHSVKBH.Text = _nhanVien.HeSoVuotKhungBH.ToString();

            //Cho giao diện của nâng lương theo kiểu nâng lương
            txt_NhomNgachCu_Kieu.Text = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_nhanVien.MaNhomNgachLuongCB).TenNhomNgachLuongCoBan;
            txt_NgachCu_Kieu.Text = NgachLuongCoBan.GetNgachLuongCoBan(_nhanVien.MaNgachLuongCoBan).TenNgachLuongCoBan;
            txt_BacLuongCu_Kieu.Text = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongCoBan).MaQuanLy;
            nmu_HeSoCu_Kieu.Text = _nhanVien.HeSoLuong.ToString();
            txt_HSVKCu_Kieu.Text = _nhanVien.HeSoVuotKhungBH.ToString();

            txt_NhomNgachBHCu_Kieu.Text = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_nhanVien.MaNhomNgachLuongBaoHiem).TenNhomNgachLuongCoBan;
            txt_NgachBHCu_kieu.Text = NgachLuongCoBan.GetNgachLuongCoBan(_nhanVien.MaNgachLuongBaoHiem).TenNgachLuongCoBan;
            txt_BacLuongBHCu_Kieu.Text = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongBaoHiem).MaQuanLy;
            nmu_HeSoBHCu_Kieu.Value = _nhanVien.HeSoLuongBaoHiem.ToString();
            txt_HSVKBHCu_Kieu.Text = _nhanVien.HeSoVuotKhungBH.ToString();

            //Cho giao diện chuyển loại
            txt_NhomNgachCu_CL.Text = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_nhanVien.MaNhomNgachLuongCB).TenNhomNgachLuongCoBan;
            txt_NgachCu_CL.Text = NgachLuongCoBan.GetNgachLuongCoBan(_nhanVien.MaNgachLuongCoBan).TenNgachLuongCoBan;
            txt_BacLuongCu_CL.Text = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongCoBan).MaQuanLy;
            mnu_HeSoCu_CL.Text = _nhanVien.HeSoLuong.ToString();
            txt_HSVKCu_CL.Text = _nhanVien.HeSoVuotKhungBH.ToString();

            txt_NhomNgachBHCu_CL.Text = NhomNgachLuongCoBan.GetNhomNgachLuongCoBan(_nhanVien.MaNhomNgachLuongBaoHiem).TenNhomNgachLuongCoBan;
            txt_NgachBHCu_CL.Text = NgachLuongCoBan.GetNgachLuongCoBan(_nhanVien.MaNgachLuongBaoHiem).TenNgachLuongCoBan;
            txt_BacLuongBHCu_CL.Text = BacLuongCoBan.GetBacLuongCoBan(_nhanVien.MaBacLuongBaoHiem).MaQuanLy;
            mnu_HeSoBHCu_CL.Value = _nhanVien.HeSoLuongBaoHiem.ToString();
            txt_HSVKBHCu_CL.Text = _nhanVien.HeSoVuotKhungBH.ToString();

            txt_HSNBCu_CL.Text = _nhanVien.HeSoLuongNoiBo.ToString();
        }

        private void TimKiem()
        {
            frmTimNhanVien _frmTimNhanVien = new frmTimNhanVien(4);
            _quyetDinhNangLuongList = QuyetDinhNangLuongList.NewQuyetDinhNangLuongList();
            if (_frmTimNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                maNhanVien = frmTimNhanVien.MaNhanVien;
                if (maNhanVien != 0)
                {

                    _nhanVien = NhanVien.GetNhanVien_IsDirty(maNhanVien);
                    // Error right here Anh Loc tim duoi luon ne lan sau nho xem ky nha ku
                    //cbBacLuongCoBan.Value = 0;
                    //cbBacLuongNB.Value = 0;
                    ReLoad(_nhanVien);
                    _quyetDinhNangLuongList = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(maNhanVien);
                    bindingSource1_QuyetDinhNangLuong.DataSource = _quyetDinhNangLuongList;

                    if (_quyetDinhNangLuongList.Count > 0)
                        UpdateMocNangLuongChoQDGanNhat();
                    grdu_DanhSachNangLuong.Focus();
                }
            }
        }

        private void UpdateMocNangLuongChoQDGanNhat()
        {
            int soQuyetDinh = QuyetDinhNangLuong.KiemTraNgayHieuLucMax(_nhanVien.MaNhanVien);
            foreach (QuyetDinhNangLuong _qd in _quyetDinhNangLuongList)
            {
                if (_qd.MaQuyetDinh == soQuyetDinh)
                {
                    _qd.MocNangLuong = _nhanVien.MocLenLuong;
                    _qd.MocNangLuongBH = _nhanVien.MocLenLuongBaoHiem;
                    _qd.ApplyEdit();
                }
            }
            _quyetDinhNangLuongList.Save();

        }
        #endregion

        #region event
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            //if (cbKieuNangLuong.SelectedIndex == -1)
            //{
            //    MessageBox.Show("Kiểu nâng lương chưa hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            if (_nhanVien == null)
            {
                MessageBox.Show("Chưa chọn thông tin nhân viên !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            mnu_HSNBMoi_CL.Value = _nhanVien.HeSoLuongNoiBo;
            GridActive = false;
            if (tabThongTin.SelectedTab == tabTheoLoai)
            {
                New();
            }
            else if (tabThongTin.SelectedTab == tabTheoKieu)
            {
                New_TheoKieu();
            }
            else if (tabThongTin.SelectedTab == tabChuyenLoai)
            {
                New_ChuyenLoai();
            }
            grdu_DanhSachNangLuong.Focus();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdu_DanhSachNangLuong.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _nhanVien = NhanVien.GetNhanVien(maNhanVien);
            ReLoad(_nhanVien);
            _quyetDinhNangLuongList = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(maNhanVien);
            bindingSource1_QuyetDinhNangLuong.DataSource = _quyetDinhNangLuongList;
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
            if (_nhanVien != null)
            {
                cmbu_LoaiNV.Value = _nhanVien.LoaiNV;
                cmbu_LoaiNhanVienMoi.Value = _nhanVien.LoaiNV;
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuyetDinhNangLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
            {
                TimKiem();
            }
            else if (e.Control && e.KeyCode == Keys.S && tlslblLuu.Enabled == true)
            {
                Save();
            }
            else if ((e.Control && e.KeyCode == Keys.N) && tlslblThem.Enabled == true)
            {
                New();
            }
        }

        private void ComboboxNhomNgachLuongBH_LoadGiaoDien(UltraCombo _cmbu_NhomNgachLuongBH)
        {
            foreach (UltraGridColumn col in _cmbu_NhomNgachLuongBH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            _cmbu_NhomNgachLuongBH.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Width = _cmbu_NhomNgachLuongBH.Width;
            _cmbu_NhomNgachLuongBH.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Hidden = false;
            _cmbu_NhomNgachLuongBH.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.Caption = "Nhóm Ngạch Bảo Hiểm";
            _cmbu_NhomNgachLuongBH.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.VisiblePosition = 0;
        }

        private void ComboboxNhomNgachLuong_LoadGiaoDien(UltraCombo _cmb_NhomNgachLuong)
        {
            foreach (UltraGridColumn col in _cmb_NhomNgachLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            _cmb_NhomNgachLuong.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Width = _cmb_NhomNgachLuong.Width;
            _cmb_NhomNgachLuong.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Hidden = false;
            _cmb_NhomNgachLuong.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.Caption = "Nhóm Ngạch Cơ Bản";
            _cmb_NhomNgachLuong.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.VisiblePosition = 0;
        }

        private void ComboboxNgachLuongBH_LoadGiaoDien(UltraCombo _cmbu_NgachLuongBH)
        {
            foreach (UltraGridColumn col in _cmbu_NgachLuongBH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            _cmbu_NgachLuongBH.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            _cmbu_NgachLuongBH.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Ngạch Bảo Hiểm";
            _cmbu_NgachLuongBH.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 0;

            _cmbu_NgachLuongBH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            _cmbu_NgachLuongBH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            _cmbu_NgachLuongBH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void ComboboxNgachLuong_LoadGiaoDien(UltraCombo _cmbu_NgachLuong)
        {
            foreach (UltraGridColumn col in _cmbu_NgachLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            _cmbu_NgachLuong.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            _cmbu_NgachLuong.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Ngạch Cơ Bản";
            _cmbu_NgachLuong.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 0;

            _cmbu_NgachLuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            _cmbu_NgachLuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            _cmbu_NgachLuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void ComboboxBacLuongBH_LoadGiaoDien(UltraCombo _cmbu_BacLuongBH)
        {
            foreach (UltraGridColumn col in _cmbu_BacLuongBH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            _cmbu_BacLuongBH.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            _cmbu_BacLuongBH.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            _cmbu_BacLuongBH.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 0;

            _cmbu_BacLuongBH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            _cmbu_BacLuongBH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            _cmbu_BacLuongBH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void ComboboxBacLuong_LoadGiaoDien(UltraCombo _cmbu_BacLuong)
        {
            foreach (UltraGridColumn col in _cmbu_BacLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }
            _cmbu_BacLuong.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            _cmbu_BacLuong.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            _cmbu_BacLuong.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 0;

            _cmbu_BacLuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            _cmbu_BacLuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            _cmbu_BacLuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cmbu_NhomNgachMoi_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNhomNgachLuong.ActiveRow != null && !GridActive)
            {
                int iNhomNgachLuong = 0;
                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    iNhomNgachLuong = (int)cmbNhomNgachLuong.Value;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    iNhomNgachLuong = (int)cmbu_NhomNgachMoi_Kieu.Value;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    iNhomNgachLuong = (int)cmbu_NhomNgachMoi_Cl.Value;
                }

                //_ngachCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(iNhomNgachLuong));
                //_ngachCoBanList.Insert(0, NgachLuongCoBan.NewNgachLuongCoBan(0, "<Chưa chọn>"));
                //this.bindingSource1_NgachLuong.DataSource = _ngachCoBanList;

                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    cmbNgachLuongCB.Value = _ngachCoBanList[0].MaNgachLuongCoBan;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    cmbu_NgachMoi_Kieu.Value = _ngachCoBanList[0].MaNgachLuongCoBan;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    cmbu_NgachLuongMoi_Cl.Value = _ngachCoBanList[0].MaNgachLuongCoBan;
                }
            }
        }

        private void cmbu_NgachMoi_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNgachLuongCB.ActiveRow != null && !GridActive)
            {
                int iNgachLuong = 0;
                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    iNgachLuong = (int)cmbNgachLuongCB.Value;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    iNgachLuong = (int)cmbu_NgachMoi_Kieu.Value;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    iNgachLuong = (int)cmbu_NgachLuongMoi_Cl.Value;
                }

                //_bacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanListByNgachLuong(Convert.ToInt32(iNgachLuong));
                //_bacLuongCoBanList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
                //this.bindingSource1_BacLuong.DataSource = _bacLuongCoBanList;

                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    cbBacLuongCoBan.Value = _bacLuongCoBanList[0].MaBacLuongCoBan;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    cmbu_BacLuongMoi_Kieu.Value = _bacLuongCoBanList[0].MaBacLuongCoBan;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    cmbu_BacLuongMoi_Cl.Value = _bacLuongCoBanList[0].MaBacLuongCoBan;
                }
            }

        }

        private void cmbu_BacLuongMoi_ValueChanged(object sender, EventArgs e)
        {
            if (cbBacLuongCoBan.ActiveRow != null)
            {
                int iBacLuong = 0;
                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    iBacLuong = (int)cbBacLuongCoBan.Value;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    iBacLuong = (int)cmbu_BacLuongMoi_Kieu.Value;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    iBacLuong = (int)cmbu_BacLuongMoi_Cl.Value;
                }

                decimal deHeSoLuong = BacLuongCoBan.GetBacLuongCoBan(iBacLuong).HeSoLuong;
                tbHSoLuongMoi.Value = deHeSoLuong;
                nmu_HeSoMoi_Kieu.Value = deHeSoLuong;
                mnu_HeSoMoi_CL.Value = deHeSoLuong;
            }
        }

        private void cbNhomNgachBaoHiem_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhomNgachBaoHiem.ActiveRow != null && !GridActive)
            {
                int iNhomNgachLuongBH = 0;
                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    iNhomNgachLuongBH = (int)cbNhomNgachBaoHiem.Value;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    iNhomNgachLuongBH = (int)cmbu_NhomNgachBHMoi_Kieu.Value;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    iNhomNgachLuongBH = (int)cmbu_NhomNgachBHMoi_Cl.Value;
                }

                //_NgachLuongBaoHiemList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(iNhomNgachLuongBH));
                //_NgachLuongBaoHiemList.Insert(0, NgachLuongCoBan.NewNgachLuongCoBan(0, "<Chưa chọn>"));
                //this.bindingSource1_NgachBH.DataSource = _NgachLuongBaoHiemList;

                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    cbNgachLuongNB.Value = _NgachLuongBaoHiemList[0].MaNgachLuongCoBan;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    cmbu_NgachBHMoi_Kieu.Value = _NgachLuongBaoHiemList[0].MaNgachLuongCoBan;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    cmbu_NgachLuongBHMoi_Cl.Value = _NgachLuongBaoHiemList[0].MaNgachLuongCoBan;
                }
            }
        }

        private void cbNgachLuongNB_ValueChanged(object sender, EventArgs e)
        {
            if (cbNgachLuongNB.ActiveRow != null && !GridActive)
            {
                int iNgachBH = 0;
                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    iNgachBH = (int)cbNgachLuongNB.Value;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    iNgachBH = (int)cmbu_NgachBHMoi_Kieu.Value;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    iNgachBH = (int)cmbu_NgachLuongBHMoi_Cl.Value;
                }

                //_BacLuongBaoHiemList = BacLuongCoBanList.GetBacLuongCoBanList(Convert.ToInt32(iNgachBH));
                //_BacLuongBaoHiemList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
                //this.bindingSource1_BacBH.DataSource = _BacLuongBaoHiemList;

                //cbBacLuongNB.Value = _BacLuongBaoHiemList[0].MaBacLuongCoBan;
                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    cbBacLuongNB.Value = _BacLuongBaoHiemList[0].MaBacLuongCoBan;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    cmbu_BacLuongBHMoi_Kieu.Value = _BacLuongBaoHiemList[0].MaBacLuongCoBan;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    cmbu_BacLuongBHMoi_Cl.Value = _BacLuongBaoHiemList[0].MaBacLuongCoBan;
                }
            }
        }

        private void cbBacLuongNB_ValueChanged(object sender, EventArgs e)
        {
            if (cbBacLuongNB.ActiveRow != null)
            {
                int iBacLuong = 0;
                if (tabThongTin.SelectedTab == tabTheoLoai)
                {
                    iBacLuong = (int)cbBacLuongNB.Value;
                }
                else if (tabThongTin.SelectedTab == tabTheoKieu)
                {
                    iBacLuong = (int)cmbu_BacLuongBHMoi_Kieu.Value;
                }
                else if (tabThongTin.SelectedTab == tabChuyenLoai)
                {
                    iBacLuong = (int)cmbu_BacLuongBHMoi_Cl.Value;
                }

                heSoBHMoi = BacLuongCoBan.GetBacLuongCoBan(Convert.ToInt32(cbBacLuongNB.Value)).HeSoLuong;
                tbHSLuongBH.Value = heSoBHMoi;
                nmu_HeSoBHMoi_Kieu.Value = heSoBHMoi;
                mnu_HeSoBHMoi_CL.Value = heSoBHMoi;
            }
        }

        private void cbKieuNangLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmb_KieuTangLuong.Value != null)
            {
                kieuNangLuong = Convert.ToInt32(cmb_KieuTangLuong.Value);
            }
        }

        private void grdu_DanhSachNangLuong_BeforeRowActivate(object sender, RowEventArgs e)
        {
            GridActive = true;
        }

        private void cmbNhomNgachLuong_Leave(object sender, EventArgs e)
        {
            GridActive = true;
            mfnc_LoadConTrolBanDau();
        }

        private void cmbNgachLuongCB_Leave(object sender, EventArgs e)
        {
            GridActive = true;
            mfnc_LoadConTrolBanDau();
        }

        private void cbBacLuongCoBan_Leave(object sender, EventArgs e)
        {
            GridActive = true;
            mfnc_LoadConTrolBanDau();
        }

        private void cbBacLuongCoBan_BeforeDropDown(object sender, CancelEventArgs e)
        {
            GridActive = false;
            if (cmbNgachLuongCB.ActiveRow != null)
            {
                _bacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanList((int)cmbNgachLuongCB.Value);
                _bacLuongCoBanList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
                this.bindingSource1_BacLuong.DataSource = _bacLuongCoBanList;
            }
        }

        private void cbNhomNgachBaoHiem_Leave(object sender, EventArgs e)
        {
            GridActive = true;
            mfnc_LoadConTrolBanDau();
        }

        private void cbNgachLuongNB_Leave(object sender, EventArgs e)
        {
            GridActive = true;
            mfnc_LoadConTrolBanDau();
        }

        private void cbBacLuongNB_Leave(object sender, EventArgs e)
        {
            GridActive = true;
            mfnc_LoadConTrolBanDau();
        }

        private void cbBacLuongNB_BeforeDropDown(object sender, CancelEventArgs e)
        {
            GridActive = false;
            if (cbNgachLuongNB.ActiveRow != null)
            {
                _BacLuongBaoHiemList = BacLuongCoBanList.GetBacLuongCoBanList((int)cbNgachLuongNB.Value);
                _BacLuongBaoHiemList.Insert(0, BacLuongCoBan.NewBacLuongCoBan(0, "<Chưa chọn>"));
                this.bindingSource1_BacBH.DataSource = _BacLuongBaoHiemList;
            }
        }

        private void cmbNgachLuongCB_BeforeDropDown(object sender, CancelEventArgs e)
        {
            GridActive = false;
            if (cmbNhomNgachLuong.ActiveRow != null)
            {
                _ngachCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach((int)cmbNhomNgachLuong.Value);
                _ngachCoBanList.Insert(0, NgachLuongCoBan.NewNgachLuongCoBan(0, "<Chưa chọn>"));
                this.bindingSource1_NgachLuong.DataSource = _ngachCoBanList;
            }
        }

        private void cbNgachLuongNB_BeforeDropDown(object sender, CancelEventArgs e)
        {
            GridActive = false;
            if (cbNhomNgachBaoHiem.ActiveRow != null)
            {
                _NgachLuongBaoHiemList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach((int)cbNhomNgachBaoHiem.Value);
                _NgachLuongBaoHiemList.Insert(0, NgachLuongCoBan.NewNgachLuongCoBan(0, "<Chưa chọn>"));
                this.bindingSource1_NgachBH.DataSource = _NgachLuongBaoHiemList;
            }
        }

        private void cmbNhomNgachLuong_BeforeDropDown(object sender, CancelEventArgs e)
        {
            GridActive = false;
        }

        private void cbNhomNgachBaoHiem_BeforeDropDown(object sender, CancelEventArgs e)
        {
            GridActive = false;
        }
        #endregion
    }
}
