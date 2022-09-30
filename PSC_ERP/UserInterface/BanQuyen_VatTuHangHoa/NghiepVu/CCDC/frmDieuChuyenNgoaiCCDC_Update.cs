using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using ERP_Library.Security;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace PSC_ERP///
{
    public partial class frmDieuChuyenNgoaiCCDC_Update : DevExpress.XtraEditors.XtraForm
    {
        #region Field
        BoPhanList _boPhanListAll = null;
        HangHoaBQ_VTList _hangHoaList = null;
        DuyetCCDCList _duyetCongCuDungCuList_Find = null;

        //DuyetCongCuDungCuList _tmp_duyetCongCuDungCuList_dungDeKiemTra = DuyetCongCuDungCuList.NewDuyetCongCuDungCuList();
        ThongTinNhanVienTongHopList _thongTinNhanVienTongHopListAll_benGiao = null;
        DoiTacList _doiTacListAll = null;
        PhieuNhapXuatCCDC _phieuNhapXuat = PhieuNhapXuatCCDC.NewPhieuNhapXuat();
        HeThongTaiKhoan1List _heThongTaiKhoan1ListAll = null;
        TieuMucNganSachList _tieuMucNganSachListAll = null;
        private bool _isXemLai = false;
        DateTime _ngayLapCu;

        
        #endregion
        #region Constructor

        public frmDieuChuyenNgoaiCCDC_Update()
        {
            InitializeComponent();

            this.LoadData();
            //dinh loai
            _phieuNhapXuat.Loai = 8;//7:Thanh ly; 8:Dieu chuyen ngoai
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            _ngayLapCu = _phieuNhapXuat.NgayNX;
            //nguoi lap
            this._phieuNhapXuat.MaNguoiLap = CurrentUser.Info.UserID;

            //sinh so chung tu
            //_phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(7, false, DateTime.Now);
            _phieuNhapXuat.SoPhieu = PhieuNhapXuatCCDC.Get_NextSoChungTuThanhLyHoacDieuDieuChuyenNgoaiCongCuDungCu(8, ERP_Library.Security.CurrentUser.Info.MaBoPhan, this._phieuNhapXuat.NgayHT.Year, ERP_Library.Security.CurrentUser.Info.MaQLUser, 4);
            this.WindowState = FormWindowState.Maximized;

            
        }

        public frmDieuChuyenNgoaiCCDC_Update(long maPhieuNhapXuat)
        {
            _isXemLai = true;
            InitializeComponent();
            this.LoadData_XemLai(maPhieuNhapXuat);

            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region Useful Method
        private void LoadData_XemLai(long maPhieuNhapXuat)
        {
            _phieuNhapXuat = PhieuNhapXuatCCDC.GetPhieuNhapXuat(maPhieuNhapXuat);
            _ngayLapCu = _phieuNhapXuat.NgayNX;
            this.LoadData();

        }
        private void LoadData()
        {


            //danh sach hang hoa rong
            _hangHoaList = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
            hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaList;
            //
            _boPhanListAll = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();//.GetBoPhanListBy_All();
            boPhanListAllBindingSource_giao_forCombo.DataSource = _boPhanListAll;
            /////////////////////////////////////////////////////////////////////////

            //
            _thongTinNhanVienTongHopListAll_benGiao = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            thongTinNhanVienTongHopListBindingSource_benGiao_forCombo.DataSource = _thongTinNhanVienTongHopListAll_benGiao;
            //
            _doiTacListAll = DoiTacList.GetDoiTacListByTen(0);//cai ham nay co ten khong dung voi chuc nang
            doiTacListAllBindingSource.DataSource = _doiTacListAll;
            //
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            //
            congCuDungCuListBindingSource_forGrid.DataSource = _phieuNhapXuat.CongCuDungCuList;
            //
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            //
            _heThongTaiKhoan1ListAll = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            HeThongTaiKhoan1 taiKhoan_khongChon = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            taiKhoan_khongChon.SoHieuTK = "<<Không chọn>>";
            taiKhoan_khongChon.TenTaiKhoan = "<<Không chọn>>";
            _heThongTaiKhoan1ListAll.Insert(0, taiKhoan_khongChon);
            heThongTaiKhoan1ListBindingSource_No.DataSource = _heThongTaiKhoan1ListAll;
            heThongTaiKhoan1ListBindingSource_Co.DataSource = _heThongTaiKhoan1ListAll;

            //
            _tieuMucNganSachListAll = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach tieuMucNganSach_KhongChon = TieuMucNganSach.NewTieuMucNganSach
                ();
            tieuMucNganSach_KhongChon.MaQuanLy = "<<Không chọn>>";
            tieuMucNganSach_KhongChon.TenTieuMuc = "<<Không chọn>>";
            _tieuMucNganSachListAll.Insert(0, tieuMucNganSach_KhongChon);
            tieuMucNganSachListAllBindingSource.DataSource = _tieuMucNganSachListAll;

        }
        public void ChangeFocus()
        {
            this.txtBlackHole1.Focus();
            this.txtBlackHole2.Focus();
        }

        private bool KhoaSo()
        {
            bool khoaso = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }

            if (khoaso == false && _phieuNhapXuat.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        khoaso = true;
                    }
                }
            }
            return khoaso;
        }


        private bool CheckValidWhenChangeNgayNX()//Them
        {
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!CCDC.KiemTraThaoTacCCDCHopLe(_phieuNhapXuat.NgayNX))
            {
                MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_phieuNhapXuat.NgayNX.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_phieuNhapXuat.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (!CCDC.KiemTraThaoTacCCDCHopLe(_ngayLapCu))
                {
                    MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_ngayLapCu.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Event Method

        private void repositoryItemGridLookUpEdit_BoPhan_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lookupEdit = sender as GridLookUpEdit;
            int maBoPhanGiao = (int)lookupEdit.EditValue;

            this.barEditItem_HangHoa.EditValue = 0;
            //

            _hangHoaList = HangHoaBQ_VTList.GetHangHoaBQ_VTList_BoPhanDangSuDung(maBoPhanGiao);
            HangHoaBQ_VT hangHoa_ChonTatCa = HangHoaBQ_VT.NewHangHoaBQ_VT();
            hangHoa_ChonTatCa.MaQuanLy = "<<Tất cả>>";
            hangHoa_ChonTatCa.TenHangHoa = "<<Tất cả>>";
            _hangHoaList.Insert(0, hangHoa_ChonTatCa);
            hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaList;





            //tao moi danh sach kiem tra
            //_tmp_congCuDungCuList_canChuyen_dungDeKiemTra = CongCuDungCuList.NewCongCuDungCuList();
            //_tmp_duyetCongCuDungCuList_canChuyen_dungDeKiemTra = DuyetCongCuDungCuList.NewDuyetCongCuDungCuList();
            //tao moi dieu chuyen noi bo
            //_dieuChuyenNoiBoCongCuDungCu_single = DieuChuyenNoiBoCongCuDungCu.NewDieuChuyenNoiBoCongCuDungCu();
            //gan MaNguoiLap
            //_dieuChuyenNoiBoCongCuDungCu_single.MaNguoiLap = CurrentUser.Info.UserID;
            //gan MaBoPhanGiao
            //_dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanGiao = maBoPhanGiao;
            //ket du lieu vao bindingSource
            //dieuChuyenNoiBoCongCuDungCuBindingSource_single.DataSource = _dieuChuyenNoiBoCongCuDungCu_single;

            //
            //cTDieuChuyenNoiBoCongCuDungCuListBindingSource_forGrid.DataSource = _dieuChuyenNoiBoCongCuDungCu_single.CT_DieuChuyenNoiBoCongCuDungCuList;
        }

        private void repositoryItemGridLookUpEdit_HangHoa_EditValueChanged(object sender, EventArgs e)
        {
            //GridLookUpEdit lookupEdit = sender as GridLookUpEdit;
            //int maBoPhan = (int)lookupEdit.EditValue;
        }




        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ChangeFocus();
            if (this.barEditItem_BoPhan.EditValue != null)
            {
                //
                int maBoPhan = (int)this.barEditItem_BoPhan.EditValue;
                int maHangHoa = 0;
                if (this.barEditItem_HangHoa.EditValue != null)
                    maHangHoa = (int)this.barEditItem_HangHoa.EditValue;

                byte loaiNghiepVu = 3;//1:thanhly; 2:Dieuchuyennoibo; 3:nghiep vu dieu chuyen ngoai
                _duyetCongCuDungCuList_Find = DuyetCCDCList.GetDuyetCongCuDungCuList_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien(loaiNghiepVu, maBoPhan, maHangHoa ,_phieuNhapXuat.NgayNX);
                //remove nhung cong cu dung cu da duoc dua vao danh sach kiem tra ra khoi danh sach moi tim
                RemoveCongCuDungCuDaChonRaKhoiDanhSachTim();
                duyetCongCuDungCuListBindingSource_forGrid.DataSource = _duyetCongCuDungCuList_Find;
                //this.congCuDungCuListBindingSource_forGrid.DataSource = _congCuDungCuList_Find;

            }
            else
            {
                MessageBox.Show("Vui lòng chọn bộ phận trước khi tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveCongCuDungCuDaChonRaKhoiDanhSachTim()
        {
            foreach (CCDC ccdc in _phieuNhapXuat.CongCuDungCuList)
            {
                DuyetCCDC duyetCcdcCanRemoveRaKhoiDanhSachTim = null;
                foreach (DuyetCCDC duyetCcdc in _duyetCongCuDungCuList_Find)
                {
                    if (duyetCcdc.MaCongCuDungCu == ccdc.MaCongCuDungCu)
                    {
                        duyetCcdcCanRemoveRaKhoiDanhSachTim = duyetCcdc;
                        break;
                    }
                }

                if (duyetCcdcCanRemoveRaKhoiDanhSachTim != null)
                {
                    _duyetCongCuDungCuList_Find.Remove(duyetCcdcCanRemoveRaKhoiDanhSachTim);
                }
            }
        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.ChangeFocus();
            try
            {
                foreach (DuyetCCDC duyetCcdc in _duyetCongCuDungCuList_Find)
                {
                    if (duyetCcdc.Chon == true)
                    {
                        //gan chut thong tin
                        duyetCcdc.CongCuDungCu.MaDuyetCongCuDungCu = duyetCcdc.MaDuyetCongCuDungCu;

                        _phieuNhapXuat.CongCuDungCuList.Add(duyetCcdc.CongCuDungCu);

                    }
                }
                this.RemoveCongCuDungCuDaChonRaKhoiDanhSachTim();
            }
            catch (System.Exception ex)
            {

            }


        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckValidWhenChangeNgayNX()) return;
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn lưu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                Save();
            }
        }
        private bool DaKhoaSo()
        {
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!CCDC.KiemTraThaoTacCCDCHopLe(_phieuNhapXuat.NgayNX))
            {
                MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_phieuNhapXuat.NgayNX.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_phieuNhapXuat.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (!CCDC.KiemTraThaoTacCCDCHopLe(_ngayLapCu))
                {
                    MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_ngayLapCu.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        private bool Save()
        {
            this.ChangeFocus();

            if (this.DaKhoaSo() == false)
            {
                if (_phieuNhapXuat != null && PhieuNhapXuatCCDC.KiemTraTrungSoChungTuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu))
                {
                    MessageBox.Show("Trùng số chứng từ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSoChungTu.Focus();
                    return false;
                }
                else
                {
                    //kiem tra da dien du du lieu can thiet hay chua
                    if (this.KiemTraDuDieuKienTruocKhiLuu() == false)
                    {
                        return false;
                    }
                    try
                    {
                        phieuNhapXuatBindingSource.EndEdit();
                        _phieuNhapXuat.Save();
                        _ngayLapCu = _phieuNhapXuat.NgayNX;
                        MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Đã khóa sổ, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;//khong save dc vi da khoa so
            }
        }

        private bool KiemTraDuDieuKienTruocKhiLuu()
        {
            bool returnValue = true;
            if (this._phieuNhapXuat.CongCuDungCuList.Count == 0)
            {

                MessageBox.Show("Không thể lưu thanh lý rỗng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this._phieuNhapXuat.ButToanPhieuNhapXuatList.Count == 0)
            {

                MessageBox.Show("Chưa nhập định khoản", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (TongTienHopLe() == false)
            {
                MessageBox.Show("Tổng tiền phiếu phải bằng tổng tiền bút toán định khoản", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (String.IsNullOrEmpty(this._phieuNhapXuat.SoPhieu))
            {
                MessageBox.Show("Chưa nhập số chứng từ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (this._phieuNhapXuat.MaNguoiNhapXuat == 0)
            {

                MessageBox.Show("Chưa chọn nhân viên giao", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this._phieuNhapXuat.MaDoiTac == 0)
            {
                MessageBox.Show("Chưa chọn đối tác nhận", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            return returnValue;
        }
        #endregion


        private void barEditItem_BoPhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }



        private void cbNhanVienGiao_EditValueChanged(object sender, EventArgs e)
        {

        }



        private void gridCtrl_DuyetCongCuDungCuList_Click(object sender, EventArgs e)
        {

        }

        private void gridView_CCDCThanhLy_KeyDown(object sender, KeyEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.KeyCode == Keys.Delete)
            {
                if (!CheckValidWhenChangeNgayNX()) return;
                if (gridView.SelectedRowsCount > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn? Nếu xóa, sau đó cần bấm nút" + this.btnLuu.Caption + " để lưu lại những thay đổi trên lưới xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        gridView.DeleteSelectedRows();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void gridView_DinhKhoan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ////////if (object.ReferenceEquals(e.Column, this.colSoTienButToan))
            ////////{
            ////////    //can cap nhat tong tien
            ////////    CapNhatTongTien();
            ////////}

        }

        private void CapNhatTongTien()
        {
            decimal tongTien = 0;
            foreach (ButToanPhieuNhapXuatCCDC butToan in this._phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                tongTien += butToan.SoTien;
            }
            _phieuNhapXuat.GiaTriKho = tongTien;
        }

        private bool TongTienHopLe()
        {
            decimal tongTien = 0;
            foreach (ButToanPhieuNhapXuatCCDC butToan in this._phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                tongTien += butToan.SoTien;
            }
            if (_phieuNhapXuat.GiaTriKho == tongTien)
                return true;
            else 
                return false;
        }

        private void gridView_DinhKhoan_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
        }

        private void gridView_DinhKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gridView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            GridView gridView = sender as GridView;
            if (e.KeyCode == Keys.Delete)
            {

                if (gridView.SelectedRowsCount > 0)
                {
                    if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng định khoản đang chọn? Nếu xóa, sau đó cần bấm nút" + this.btnLuu.Caption + " để lưu lại những thay đổi trên lưới xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                    {
                        gridView.DeleteSelectedRows();
                        ////////can cap nhat tong tien
                        //////CapNhatTongTien();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn dòng bút toán định khoản cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.HoaDon_NhapXuatList.Count == 0)
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhapXuat.MaDoiTac);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                    }
                }
            }
            else
            {
                PhieuNhapXuat pnx = PhieuNhapXuat.GetPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat);
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(pnx);//
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _phieuNhapXuat.ApplyEdit();
                        _phieuNhapXuat.Save();
                    }
                }
            }
        }

        private void frmDieuChuyenNgoaiCCDC_Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_phieuNhapXuat != null && (_phieuNhapXuat.IsDirty || _phieuNhapXuat.IsNew))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu trước khi thoát?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {

                    if (this.Save() == false)
                        e.Cancel = true;
                }
                else if (DialogResult.No == result)
                {

                }
                else if (DialogResult.Cancel == result)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridCtrl_DinhKhoan_Click(object sender, EventArgs e)
        {

        }

        private void gridView_DinhKhoan_InitNewRow(object sender, InitNewRowEventArgs e)
        {

            decimal tongTienButToan = 0;
            foreach (ButToanPhieuNhapXuatCCDC butToan in this._phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                tongTienButToan += butToan.SoTien;
            }

            this.gridView_DinhKhoan.SetRowCellValue(e.RowHandle, this.colSoTienButToan, _phieuNhapXuat.GiaTriKho - tongTienButToan);
        }

        private void frmDieuChuyenNgoaiCCDC_Update_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.SetSTTForGridView(gridView_DinhKhoan);
            Utils.GridUtils.InitMultiRowSelectForGridView(gridView_DinhKhoan);
            Utils.GridUtils.InitCopyCellForGridView(this.gridView_DinhKhoan);
            Utils.GridUtils.InitNewRowOnTopOfGridView(this.gridView_DinhKhoan);

            //////////////Utils.GridUtils.ConfigGridView(gridView_DinhKhoan
            ////////////// , setSTT: true
            ////////////// , initCopyCell: true
            ////////////// , multiSelectCell: false
            ////////////// , multiSelectRow: true
            ////////////// , initNewRowOnTop: true);
            Utils.GridUtils.ConfigGridView(gridView_CCDCThanhLy
            , setSTT: true
            , initCopyCell: false
            , multiSelectCell: false
            , multiSelectRow: true
            , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(gridView_DuyetCongCuDungCuList
             , setSTT: true
             , initCopyCell: false
             , multiSelectCell: false
             , multiSelectRow: false
             , initNewRowOnTop: false);
        }

        private void gridView_DinhKhoan_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            this.gridView_DinhKhoan.MoveLast();
        }

        private void deNgayThanhLy_Leave(object sender, EventArgs e)
        {
            if (deNgayThanhLy.OldEditValue != deNgayThanhLy.EditValue)
            {
                if (!CheckValidWhenChangeNgayNX())
                {
                    _phieuNhapXuat.NgayNX = _ngayLapCu;
                    deNgayThanhLy.EditValue = _ngayLapCu as object;
                }
            }
        }


    }
}