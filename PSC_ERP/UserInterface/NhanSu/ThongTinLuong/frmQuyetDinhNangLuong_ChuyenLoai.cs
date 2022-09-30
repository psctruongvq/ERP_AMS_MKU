using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;//TT_BXLO
namespace PSC_ERP
{
    //TT22
    public partial class frmQuyetDinhNangLuong_ChuyenLoai : Form
    {
        QuyetDinhNangLuongList _quyetDinhNangLuongList=QuyetDinhNangLuongList.NewQuyetDinhNangLuongList();
        QuyetDinhNangLuong _quyetDinhNangLuong;
        NhomNgachLuongCoBanList _NhomNgachLuongBaoHiemList;
        NhanVien _nhanVien;
        TenNhanVienList _nhanVienList;
        NhanVienList _nhanVienNangLuongList;
        int kieuNangLuong = 0;
        private long maNhanVien = 0;
       
        private decimal heSoBHMoi = 0;
        private decimal heSoCu = 0;

        public decimal HeSoCu
        {
            get { return heSoCu; }
            set 
            { 
                heSoCu = value;
              
            }
        }
        private DateTime ngayHieuLuc = DateTime.Today.Date;
        private DateTime ngayMocThoiGian = DateTime.Today.Date;
        private DateTime ngayLap = DateTime.Today.Date;
        BacLuongCoBanList _BacLuongBaoHiemList;
        NhomNgachLuongCoBanList _nhomNgachCoBanList;
        NgachLuongCoBanList _ngachCoBanList;
        BacLuongCoBanList _bacLuongCoBanList;
        NgachLuongCoBanList _NgachLuongBaoHiemList;

        public frmQuyetDinhNangLuong_ChuyenLoai()
        {
            InitializeComponent();
        }
        private void frmQuyetDinhNangLuong_Load(object sender, EventArgs e)
        {
            _nhanVienNangLuongList = NhanVienList.NewNhanVienList();
            _nhanVienList = TenNhanVienList.GetTenNhanVienList();   
            this.bindingSource1_NhanVien.DataSource = _nhanVienList;

            _quyetDinhNangLuongList = QuyetDinhNangLuongList.NewQuyetDinhNangLuongList();
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

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            New1(0);
        }
       
        private void New1(long _maNhanVien)
        {
            
            _nhanVien = NhanVien.GetNhanVien(_maNhanVien);
            decimal HSLuongBHNext = 0;
            int maBacLuongBHNext = 0;

            decimal _heSoLuongNext = 0;
            int maBacLuongCoBanNext = 0;

            BacLuongCoBanList _listBacLuongBH = BacLuongCoBanList.GetBacLuongCoBanList(_nhanVien.MaNgachLuongBaoHiem);
            BacLuongCoBanList _listBacLuongCB = BacLuongCoBanList.GetBacLuongCoBanList(_nhanVien.MaNgachLuongCoBan);

            decimal _heSoLuongBH = _nhanVien.HeSoLuongBaoHiem;
            decimal _heSoLuong = _nhanVien.HeSoLuong;
            QuyetDinhNangLuong _nangLuong = QuyetDinhNangLuong.NewQuyetDinhNangLuong(_maNhanVien, _heSoLuongBH);
            decimal HSVK = _nhanVien.HeSoVuotKhung;

            _heSoLuongNext = _heSoLuong;
            for (int j = 0; j < _listBacLuongCB.Count; j++)
            {
                if (_heSoLuong < _listBacLuongCB[j].HeSoLuong)
                {
                    _heSoLuongNext = _listBacLuongCB[j].HeSoLuong;//Hệ Số Kế Tiếp
                    break;
                }
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
            //Chuyển Ngạch Bậc Bảo Hiểm=Ngạch Bậc Cơ Bản.
            if (cbLoaiBienChe.Checked == true)
            {
                //cbKieuNangLuong.Value = 1;
                _nangLuong.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                _nangLuong.TenNhanVien = _nhanVien.TenNhanVien;
                _nangLuong.MaBacBaoHiemCu = _nhanVien.MaBacLuongBaoHiem;
                _nangLuong.MaBoPhan = _nhanVien.MaBoPhan;
                _nangLuong.MaChucVu = _nhanVien.MaChucVu;
                _nangLuong.MaNgachBaoHiemCu = _nhanVien.MaNgachLuongBaoHiem;
                _nangLuong.TenNgachBaoHiemCu = _nhanVien.TenNgachLuongBaoHiem;
                _nangLuong.MaNgachCoBanCu = _nhanVien.MaNgachLuongCoBan;
                _nangLuong.MaNgachLuongCoBanMoi = _nhanVien.MaNgachLuongCoBan;
                _nangLuong.MaNgachBaoHiemMoi = _nhanVien.MaNgachLuongBaoHiem;
                _nangLuong.TenNgachBaoHiemMoi = NgachLuongCoBan.GetNgachLuongCoBan(_nhanVien.MaBacLuongBaoHiem).TenNgachLuongCoBan;
                _nangLuong.MaBacLuongCoBanCu = _nhanVien.MaBacLuongCoBan;
                _nangLuong.MaBacBaoHiemCu = _nhanVien.MaBacLuongBaoHiem;
                _nangLuong.TenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemCu).MaQuanLy;
                _nangLuong.HeSoLuongCu = _nhanVien.HeSoLuong;
                _nangLuong.HeSoBaoHiemCu = _nhanVien.HeSoLuongBaoHiem;        
                if (HSVK == 0)
                {
                    _nangLuong.MaBacBaoHiemMoi = maBacLuongCoBanNext;
                    _nangLuong.MaBacLuongCoBanMoi = maBacLuongCoBanNext;
                    _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(maBacLuongCoBanNext).MaQuanLy;                 
                    

                }
                else
                {                   
                  

                    _nangLuong.MaBacBaoHiemMoi = _nangLuong.MaBacLuongCoBanCu;
                    _nangLuong.MaBacLuongCoBanMoi = _nangLuong.MaBacLuongCoBanCu;
                    _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacLuongCoBanCu).MaQuanLy;
                    _nangLuong.TenNgachBaoHiemMoi = _nhanVien.TenNgachLuongBaoHiem;
                    _nangLuong.HSVKMoi = HSVK;
                    _nangLuong.HSVKBHMoi = HSVK;

                }
            }

            //Nếu loại nhân viên =1 or 4: Tăng bậc lương cơ bản, lương bảo hiểm. Ngược lại chỉ tăng lương bảo hiểm
            else if (_nhanVien.LoaiNV == 1 || _nhanVien.LoaiNV == 4)
            {
                //cbKieuNangLuong.Value = 1;
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

                if (HSVK == 0)
                {
                    //_nangLuong.HeSoBaoHiemMoi = HSLuongBHNext;
                    _nangLuong.MaBacBaoHiemMoi = maBacLuongBHNext;
                    _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemMoi).MaQuanLy;
                    // _nangLuong.HeSoLuongMoi = _heSoLuongNext;
                    _nangLuong.MaBacLuongCoBanMoi = maBacLuongCoBanNext;

                }
                else
                {
                    // _nangLuong.HeSoBaoHiemMoi = _heSoLuongBH;
                    _nangLuong.MaBacBaoHiemMoi = _nangLuong.MaBacBaoHiemCu;
                    _nangLuong.TenBacBaoHiemCu = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemCu).MaQuanLy;
                    _nangLuong.TenNgachBaoHiemMoi = _nhanVien.TenNgachLuongBaoHiem;

                    // _nangLuong.HeSoLuongMoi = _heSoLuongNext;
                    _nangLuong.MaBacLuongCoBanMoi = maBacLuongCoBanNext;
                    _nangLuong.HSVKMoi = HSVK;
                    _nangLuong.HSVKBHMoi = HSVK;

                }
            }
            #region bo

            else//Loại nhân viên khác
            {
                // cbKieuNangLuong.Value = 3;
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

                if (HSVK == 0)
                {
                    //  _nangLuong.HeSoBaoHiemMoi = HSLuongBHNext;
                    _nangLuong.MaBacBaoHiemMoi = maBacLuongBHNext;
                    _nangLuong.TenBacBaoHiemMoi = BacLuongCoBan.GetBacLuongCoBan(_nangLuong.MaBacBaoHiemMoi).MaQuanLy;
                    //  _nangLuong.HeSoLuongMoi = _nhanVien.HeSoLuong;
                    _nangLuong.MaBacLuongCoBanMoi = _nhanVien.MaBacLuongCoBan;

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
            #endregion bo
            _nangLuong.KieuNangLuong = kieuNangLuong;
            _quyetDinhNangLuongList.Add(_nangLuong);          
            
            _nhanVien.HeSoVuotKhung = _nangLuong.HSVKMoi;
            _nhanVien.HeSoVuotKhungBH = _nangLuong.HSVKBHMoi;
            _nhanVien.MaNgachLuongCoBan = _nangLuong.MaNgachLuongCoBanMoi;
            _nhanVien.MaBacLuongCoBan = _nangLuong.MaBacLuongCoBanMoi;
            _nhanVien.HeSoLuong = _nangLuong.HeSoLuongMoi;

            _nhanVien.MaNgachLuongBaoHiem = _nangLuong.MaNgachBaoHiemMoi;
            _nhanVien.MaBacLuongBaoHiem = _nangLuong.MaBacBaoHiemMoi;
            _nhanVien.HeSoLuongBaoHiem = _nangLuong.HeSoBaoHiemMoi;
            _nhanVien.MocLenLuong = _nangLuong.MocThoiGianNangBac;
            _nhanVien.MocLenLuongBaoHiem = _nangLuong.MocThoiGianNangBac;
            //
            if(Convert.ToDecimal(tbHeSoNoiBo.Value)!=0)
            {
                _nhanVien.HeSoLuongNoiBo = Convert.ToDecimal(tbHeSoNoiBo.Value);
            }
            if (cbLoaiBienChe.Checked == true)
            {
                _nhanVien.LoaiNV = 1;
            }
            _nhanVienNangLuongList.Add(_nhanVien);
        }
        private void Save()
        {
            try
            {
                foreach (QuyetDinhNangLuong nl in _quyetDinhNangLuongList)
                {

                   

                    if (nl.SoQuyetDinh == "")
                    {
                        MessageBox.Show("Số Quyết Định chưa hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (Convert.ToDecimal(tbHeSoNoiBo.Value) != 0)
                {
                    foreach (NhanVien nv in _nhanVienNangLuongList)
                    {
                        nv.HeSoLuongNoiBo = Convert.ToDecimal(tbHeSoNoiBo.Value);
                    }
                }
                if (cbLoaiBienChe.Checked == true)
                {
                    foreach (NhanVien nv in _nhanVienNangLuongList)
                    {
                        _nhanVien.LoaiNV = 1;
                        foreach (UltraGridRow row in grdu_DanhSachNangLuong.DisplayLayout.Rows)
                        {
                            if (nv.MaNhanVien == Convert.ToInt64(row.Cells["MaNhanVien"].Value))
                            {
                                nv.MocLenLuong = Convert.ToDateTime(row.Cells["MocThoiGianNangBac"].Value);
                                nv.MocLenLuongBaoHiem = Convert.ToDateTime(row.Cells["MocThoiGianNangBac"].Value);
                            }
                        }
                       
                    }
                }
                _nhanVienNangLuongList.ApplyEdit();
                _nhanVienNangLuongList.Save();
                _quyetDinhNangLuongList.ApplyEdit();
                _quyetDinhNangLuongList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdu_DanhSachNangLuong.UpdateData();
                bindingSource1_QuyetDinhNangLuong.EndEdit();
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
            _quyetDinhNangLuongList = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(maNhanVien);
            bindingSource1_QuyetDinhNangLuong.DataSource = _quyetDinhNangLuongList;
        }
        private void ReLoad(NhanVien _nhanVien)
        {
           

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

                     _nhanVien = NhanVien.GetNhanVien(maNhanVien);

                    ReLoad(_nhanVien);
                    _quyetDinhNangLuongList = QuyetDinhNangLuongList.GetQuyetDinhNangLuongList(maNhanVien);
                    bindingSource1_QuyetDinhNangLuong.DataSource = _quyetDinhNangLuongList;
                    
                }
            }
        }
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    
        private void tbSoQuyetDinh_ValueChanged(object sender, EventArgs e)
        {
            
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
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
                col.CellActivation = Activation.NoEdit;
            }
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 0;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].CellActivation = Activation.AllowEdit;


            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.Caption = "Ngày Hiệu Lực";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.VisiblePosition = 1;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].CellActivation = Activation.AllowEdit;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].Header.Caption = "Mốc Thời Gian";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].Header.VisiblePosition = 2;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["MocThoiGianNangBac"].CellActivation = Activation.AllowEdit;

            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.Caption = "Ngày Quyết Định";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.VisiblePosition = 3;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].CellActivation = Activation.AllowEdit;
            
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Họ Tên";
            grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition=4;

            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemCu"].Hidden = false;
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemCu"].Header.Caption = "Bậc BH Cũ";
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemCu"].Header.VisiblePosition = 2;

            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemCu"].Hidden = false;
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemCu"].Header.Caption = "HSBH Cũ";
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemCu"].Header.VisiblePosition = 3;


            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemMoi"].Hidden = false;
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemMoi"].Header.Caption = "HSBH Mới";
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["HeSoBaoHiemMoi"].Header.VisiblePosition = 4;

            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemMoi"].Hidden = false;
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemMoi"].Header.Caption = "Bậc BH Mới";
            //grdu_DanhSachNangLuong.DisplayLayout.Bands[0].Columns["TenBacBaoHiemMoi"].Header.VisiblePosition = 5;

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

          
            
        }

        private void cbNhomNgachBaoHiem_ValueChanged(object sender, EventArgs e)
        {
            /*
            _NgachLuongBaoHiemList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(cbNhomNgachBaoHiem.Value));
            this.bindingSource1_NgachLuong.DataSource = _NgachLuongBaoHiemList;*/
        }

        private void cbNgachLuongNB_ValueChanged(object sender, EventArgs e)
        {/*
            _BacLuongBaoHiemList = BacLuongCoBanList.GetBacLuongCoBanList(Convert.ToInt32(cbNgachLuongNB.Value));
            this.bindingSource1_BacBH.DataSource = _BacLuongBaoHiemList;*/
        }

        private void cbBacLuongNB_ValueChanged(object sender, EventArgs e)
        {/*
            heSoMoi = BacLuongNoiBo.GetBacLuongNoiBo(Convert.ToInt32(cbBacLuongNB.Value)).HeSoLuong;
            heSoBHMoi = BacLuongCoBan.GetBacLuongCoBan(Convert.ToInt32(cbBacLuongNB.Value)).HeSoLuong;
            tbHSLuongBH.Value = heSoBHMoi;*/
        }

        private void bindingSource1_QuyetDinhNangLuong_CurrentItemChanged(object sender, EventArgs e)
        {
            if ((QuyetDinhNangLuong)bindingSource1_QuyetDinhNangLuong.Current != null)
            {
                //((QuyetDinhNangLuong)bindingSource1_QuyetDinhNangLuong.Current).HeSoCu = Convert.ToDecimal(tbHeSo.Value);
                //((QuyetDinhNangLuong)bindingSource1_QuyetDinhNangLuong.Current).HSPCCu = Convert.ToDecimal(tbHSPC.Value);
                //((QuyetDinhNangLuong)bindingSource1_QuyetDinhNangLuong.Current).HSVKCu = Convert.ToDecimal(tbHSVK.Value);
            }
        }

        private void grdu_DanhSachNangLuong_AfterRowActivate(object sender, EventArgs e)
        {
            
            //heSoCu=(decimal)grdu_DanhSachNangLuong.ActiveRow.Cells["HeSoCu"].Value;
            //tbHeSo.Value = heSoCu;
            
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
            //else if ((e.Control && e.KeyCode == Keys.N) && tlslblThem.Enabled == true)
            //{
            //    New1(0);
            //}
        }

        private void dateNgayHieuLuc_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tbSoQuyetDinh_Leave(object sender, EventArgs e)
        {
            //if (tbSoQuyetDinh.Text == "")
            //{
            //    MessageBox.Show("Nhập Số Quyết Định", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tbSoQuyetDinh.Focus();
            //}
        }

        private void cbNhomNgachBaoHiem_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //foreach (UltraGridColumn col in cbNhomNgachBaoHiem.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = Color.Navy;
            //    col.Hidden = true;
            //}
            //cbNhomNgachBaoHiem.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Width = cbNhomNgachBaoHiem.Width;
            //cbNhomNgachBaoHiem.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Hidden = false;
            //cbNhomNgachBaoHiem.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.Caption = "Nhóm Ngạch Bảo Hiểm";
            //cbNhomNgachBaoHiem.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.VisiblePosition = 0;
        }

        private void ultraCombo3_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //foreach (UltraGridColumn col in ultraCombo3.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = Color.Navy;
            //    col.Hidden = true;
            //}
            //ultraCombo3.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Width = ultraCombo3.Width;
            //ultraCombo3.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Hidden = false;
            //ultraCombo3.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.Caption = "Nhóm Ngạch Cơ Bản";
            //ultraCombo3.DisplayLayout.Bands[0].Columns["TenNhomNgachLuongCoBan"].Header.VisiblePosition = 0;
        }

        private void cbNgachLuongNB_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //foreach (UltraGridColumn col in cbNgachLuongNB.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = Color.Navy;
            //    col.Hidden = true;
            //}            
            //cbNgachLuongNB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            //cbNgachLuongNB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Ngạch Bảo Hiểm";
            //cbNgachLuongNB.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 0;

            //cbNgachLuongNB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            //cbNgachLuongNB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            //cbNgachLuongNB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void ultraCombo2_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //foreach (UltraGridColumn col in ultraCombo2.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = Color.Navy;
            //    col.Hidden = true;
            //}
            //ultraCombo2.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Hidden = false;
            //ultraCombo2.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.Caption = "Ngạch Cơ Bản";
            //ultraCombo2.DisplayLayout.Bands[0].Columns["TenNgachLuongCoBan"].Header.VisiblePosition = 0;

            //ultraCombo2.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            //ultraCombo2.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            //ultraCombo2.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void cbBacLuongNB_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //foreach (UltraGridColumn col in cbBacLuongNB.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = Color.Navy;
            //    col.Hidden = true;
            //}
            //cbBacLuongNB.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            //cbBacLuongNB.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            //cbBacLuongNB.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 0;

            //cbBacLuongNB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            //cbBacLuongNB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            //cbBacLuongNB.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void ultraCombo1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //foreach (UltraGridColumn col in ultraCombo1.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = Color.Navy;
            //    col.Hidden = true;
            //}
            //ultraCombo1.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "Hệ Số Lương";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 0;

            //ultraCombo1.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            //ultraCombo1.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            //ultraCombo1.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
        }

        private void ultraCombo3_ValueChanged(object sender, EventArgs e)
        {
            //_ngachCoBanList = NgachLuongCoBanList.GetNgachLuongCoBanListByNhomNgach(Convert.ToInt32(ultraCombo3.Value));
            //this.bindingSource1_NgachLuong.DataSource = _ngachCoBanList;
        }

        private void ultraCombo2_ValueChanged(object sender, EventArgs e)
        {
            //_bacLuongCoBanList = BacLuongCoBanList.GetBacLuongCoBanListByNgachLuong(Convert.ToInt32(ultraCombo2.Value));
            //this.bindingSource1_BacLuong.DataSource = _bacLuongCoBanList;
        }

        private void ultraCombo1_ValueChanged(object sender, EventArgs e)
        {            
         //   tbHSoLuongMoi.Value = BacLuongCoBan.GetBacLuongCoBan(Convert.ToInt32(ultraCombo1.Value)).HeSoLuong;
        }

        private void cbKieuNangLuong_ValueChanged(object sender, EventArgs e)
        {
            //if (cbKieuNangLuong.Value != null)
            //{
            //    kieuNangLuong = Convert.ToInt32(cbKieuNangLuong.Value);
              
            //}
        }

        private void grdu_DanhSachNangLuong_AfterRowsDeleted(object sender, EventArgs e)
        {
           
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in grdNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            
            }
           // grdNhanVien.DisplayLayout.Bands[0].Columns.Add("Check");
            //grdNhanVien.DisplayLayout.Bands[0].Columns["Check"].DataType = typeof(bool);
            grdNhanVien.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Check";
            grdNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;

            grdNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            grdNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;

            grdNhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            grdNhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Tên Chức Vụ";
            grdNhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 3;

            grdNhanVien.DisplayLayout.Bands[0].Columns["HeSoLuongCoBan"].Hidden = false;
            grdNhanVien.DisplayLayout.Bands[0].Columns["HeSoLuongCoBan"].Header.Caption = "Hệ Số Lương";
            grdNhanVien.DisplayLayout.Bands[0].Columns["HeSoLuongCoBan"].Header.VisiblePosition = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grdNhanVien.Rows.Count; i++)
            {
                if ((bool)grdNhanVien.Rows[i].Cells["Check"].Value == true)
                {
                    long _maNhanVien = (long)grdNhanVien.Rows[i].Cells["MaNhanVien"].Value;
                    New1(_maNhanVien);

                }
            }
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdNhanVien);
        }

        private void danhSáchNângLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DanhSachNangLuong);
        }
    }
}
