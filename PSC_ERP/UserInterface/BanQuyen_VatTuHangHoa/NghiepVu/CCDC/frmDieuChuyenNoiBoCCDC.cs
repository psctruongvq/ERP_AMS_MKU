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
using DevExpress.XtraGrid.Views.BandedGrid;
namespace PSC_ERP///
{
    public partial class frmDieuChuyenNoiBoCCDC : DevExpress.XtraEditors.XtraForm
    {
        #region Field

        DataSet dataSet = new DataSet();
        //
        BoPhanList _boPhanListAll = null;
        HangHoaBQ_VTList _hangHoaList = null;
        DuyetCCDCList _duyetCongCuDungCuList_Find = null;

        //DuyetCongCuDungCuList _tmp_duyetCongCuDungCuList_canChuyen_dungDeKiemTra = DuyetCongCuDungCuList.NewDuyetCongCuDungCuList();
        ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList_benGiao = null;
        ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList_benNhan = null;


        DieuChuyenNoiBoCCDC _dieuChuyenNoiBoCongCuDungCu_single = null;

        private DateTime _NgayDieuChuyenOld;
        private bool _isXemLai = false;
        #endregion

        #region Constructor

        public frmDieuChuyenNoiBoCCDC()
        {
            InitializeComponent();
            SetBindingForBindingSource();
            this.LoadData();
            Utils.GridUtils.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.gridView_DuyetCongCuDungCuList, this.colChon).ColumnCheckingEvent += new Utils.GridUtils.BooleanCheckAllBox.ColumnChecking(Chon_ColumnCheckingEvent);
            //hien thi bang banded view
            this.gridCtrl_CT_DieuChuyenNoiBoList.MainView = this.gridBand1.View;
  
            this.WindowState = FormWindowState.Maximized;

        }

        void Chon_ColumnCheckingEvent(object sender, Utils.GridUtils.BooleanCheckAllBox.CheckAllColumnCheckingEventArgs e)
        {

        }

        public frmDieuChuyenNoiBoCCDC(int maDieuChuyen)
        {
            _isXemLai = true;
            InitializeComponent();
            SetBindingForBindingSource();
            this.LoadData_XemLai(maDieuChuyen);
            //hien thi bang banded view
            this.gridCtrl_CT_DieuChuyenNoiBoList.MainView = this.gridBand1.View;

            this.WindowState = FormWindowState.Maximized;


            this.barEditItem_BoPhan.Enabled = false;
            this.barEditItem_BoPhan.EditValue = _dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanGiao;
            this.cbBoPhanTiepNhan.Properties.ReadOnly = true;

            //
            _hangHoaList = HangHoaBQ_VTList.GetHangHoaBQ_VTList_BoPhanDangSuDung(_dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanGiao);
            HangHoaBQ_VT hangHoa_ChonTatCa = HangHoaBQ_VT.NewHangHoaBQ_VT();
            hangHoa_ChonTatCa.MaQuanLy = "<<Tất cả>>";
            hangHoa_ChonTatCa.TenHangHoa = "<<Tất cả>>";
            _hangHoaList.Insert(0, hangHoa_ChonTatCa);
            hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaList;


        }
        #endregion
       
        #region Useful Method

        private void SetBindingForBindingSource()
        {
            dieuChuyenNoiBoCongCuDungCuBindingSource_single.DataSource = typeof(DieuChuyenNoiBoCCDC);
            cTDieuChuyenNoiBoCongCuDungCuListBindingSource_forGrid.DataSource = typeof(CT_DieuChuyenNoiBoCCDCChildList);
            congCuDungCuListBindingSource_forGrid.DataSource = typeof(CCDCList);
            duyetCongCuDungCuListBindingSource_forGrid.DataSource = typeof(DuyetCCDCList);
        }

        private void LoadData_XemLai(int maDieuChuyen)
        {
            this.LoadData();
            _dieuChuyenNoiBoCongCuDungCu_single = DieuChuyenNoiBoCCDC.GetDieuChuyenNoiBoCongCuDungCu(maDieuChuyen);
            _NgayDieuChuyenOld = _dieuChuyenNoiBoCongCuDungCu_single.NgayDieuChuyen;
            dieuChuyenNoiBoCongCuDungCuBindingSource_single.DataSource = _dieuChuyenNoiBoCongCuDungCu_single;

            cTDieuChuyenNoiBoCongCuDungCuListBindingSource_forGrid.DataSource = _dieuChuyenNoiBoCongCuDungCu_single.CT_DieuChuyenNoiBoCongCuDungCuList;
        }
        private void LoadData()
        {


            //danh sach hang hoa rong
            _hangHoaList = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
            hangHoaBQVTListBindingSource_forCombo.DataSource = _hangHoaList;

            _boPhanListAll = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();//GetBoPhanListBy_All();
            boPhanListAllBindingSource_giao_forCombo.DataSource = _boPhanListAll;
            boPhanListAllBindingSource_tiepNhan_forCombo.DataSource = _boPhanListAll;
        }
        public void ChangeFocus()
        {
            this.txtBlackHole1.Focus();
            this.txtBlackHole2.Focus();
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
            _dieuChuyenNoiBoCongCuDungCu_single = DieuChuyenNoiBoCCDC.NewDieuChuyenNoiBoCongCuDungCu();
            //
            _dieuChuyenNoiBoCongCuDungCu_single.SoChungTu = DieuChuyenNoiBoCCDC.Get_NextSoChungTuDieuChuyenNoiBo(ERP_Library.Security.CurrentUser.Info.MaBoPhan, DateTime.Today.Year, ERP_Library.Security.CurrentUser.Info.MaQLUser, 4);
            //gan MaNguoiLap
            _dieuChuyenNoiBoCongCuDungCu_single.MaNguoiLap = CurrentUser.Info.UserID;
            //gan MaBoPhanGiao
            _dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanGiao = maBoPhanGiao;

            _NgayDieuChuyenOld = _dieuChuyenNoiBoCongCuDungCu_single.NgayDieuChuyen;
            //ket du lieu vao bindingSource
            dieuChuyenNoiBoCongCuDungCuBindingSource_single.DataSource = _dieuChuyenNoiBoCongCuDungCu_single;

            //
            cTDieuChuyenNoiBoCongCuDungCuListBindingSource_forGrid.DataSource = _dieuChuyenNoiBoCongCuDungCu_single.CT_DieuChuyenNoiBoCongCuDungCuList;

           
        }

        private void repositoryItemGridLookUpEdit_HangHoa_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lookupEdit = sender as GridLookUpEdit;
            int maBoPhan = (int)lookupEdit.EditValue;

            //this.repositoryItemGridLookUpEdit_HangHoa.Tag = maBoPhan;
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

                byte loaiNghiepVu = 2;//nghiep vu dieu chuyen noi bo
                _duyetCongCuDungCuList_Find = DuyetCCDCList.GetDuyetCongCuDungCuList_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien(loaiNghiepVu, maBoPhan, maHangHoa,_dieuChuyenNoiBoCongCuDungCu_single.NgayDieuChuyen);
                //remove nhung cong cu dung cu da duoc dua vao danh sach kiem tra ra khoi danh sach moi tim
                RemoveCongCuDungCuDaChonRaKhoiDanhSachTim();
                duyetCongCuDungCuListBindingSource_forGrid.DataSource = _duyetCongCuDungCuList_Find;
                //this.congCuDungCuListBindingSource_forGrid.DataSource = _congCuDungCuList_Find;
                if (_duyetCongCuDungCuList_Find.Count < 1)
                {
                    MessageBox.Show("Danh sách rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng chọn bộ phận trước khi tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveCongCuDungCuDaChonRaKhoiDanhSachTim()
        {
            foreach (CT_DieuChuyenNoiBoCCDCChild item in _dieuChuyenNoiBoCongCuDungCu_single.CT_DieuChuyenNoiBoCongCuDungCuList)
            {
                DuyetCCDC duyetCcdcCanRemoveRaKhoiDanhSachTim = null;
                foreach (DuyetCCDC duyetCcdc in _duyetCongCuDungCuList_Find)
                {
                    if (duyetCcdc.MaCongCuDungCu == item.MaCongCuDungCu)
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
                        //_tmp_duyetCongCuDungCuList_canChuyen_dungDeKiemTra.Add(duyetCcdc);

                        CT_DieuChuyenNoiBoCCDCChild chiTiet = CT_DieuChuyenNoiBoCCDCChild.NewCT_DieuChuyenNoiBoCCDCChild();
                        chiTiet.MaDuyetCongCuDungCu = duyetCcdc.MaDuyetCongCuDungCu;
                        chiTiet.MaCongCuDungCu = duyetCcdc.MaCongCuDungCu;
                        chiTiet.TenHangHoa = duyetCcdc.TenHangHoa;
                        chiTiet.MaQuanLy = duyetCcdc.MaQuanLy;
                        //chiTiet.CongCuDungCu = duyetCcdc.CongCuDungCu;
                        //gan mac dinh la khong con dung//ben trong se tu dong gan gia tri LyDoDieuChuyen =1
                        chiTiet.KhongConDung = true;

                        //_dieuChuyenNoiBoCongCuDungCu_single.DSDuyetCongCuDungCu.Add(duyetCcdc);
                        _dieuChuyenNoiBoCongCuDungCu_single.CT_DieuChuyenNoiBoCongCuDungCuList.Add(chiTiet);
                    }
                }
                this.RemoveCongCuDungCuDaChonRaKhoiDanhSachTim();
                cTDieuChuyenNoiBoCongCuDungCuListBindingSource_forGrid.DataSource = _dieuChuyenNoiBoCongCuDungCu_single.CT_DieuChuyenNoiBoCongCuDungCuList;
            }
            catch (System.Exception ex)
            {

            }


        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckValidWhenChangeNgayDieuChuyenNoiBo()) return;
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn lưu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.Save();
            }

        }

        private bool Save()
        {
            this.ChangeFocus();


            //kiem tra da dien du du lieu can thiet hay chua
            if (this.KiemTraDuDieuKienTruocKhiLuu() == false)
            {
                return false;
            }
            try
            {
                {


                    dieuChuyenNoiBoCongCuDungCuBindingSource_single.EndEdit();
                    this._dieuChuyenNoiBoCongCuDungCu_single.ApplyEdit();
                    this._dieuChuyenNoiBoCongCuDungCu_single.Save();
                    _NgayDieuChuyenOld = _dieuChuyenNoiBoCongCuDungCu_single.NgayDieuChuyen;

                }

                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception)
            {

                //DieuChuyenNoiBoCongCuDungCu.AdvancedTransaction = null;
                MessageBox.Show("Lưu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool KiemTraDuDieuKienTruocKhiLuu()
        {
            bool returnValue = true;
            if (this._dieuChuyenNoiBoCongCuDungCu_single.CT_DieuChuyenNoiBoCongCuDungCuList.Count == 0)
            {
                returnValue = false;
                MessageBox.Show("Không thể lưu điều chuyển rỗng", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return returnValue;
            }
            if (String.IsNullOrEmpty(_dieuChuyenNoiBoCongCuDungCu_single.SoChungTu))
            {
                MessageBox.Show("Chưa nhập số chứng từ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnValue = false;
            }
            if (_dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanNhan == 0)
            {
                MessageBox.Show("Chưa chọn bộ phận nhận", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnValue = false;
            }
            if (_dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanGiao == 0)
            {
                MessageBox.Show("Chưa chọn bộ phận giao", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnValue = false;
            }

            //if (_dieuChuyenNoiBoCongCuDungCu_single.MaNhanVienGiao == 0)
            //{
            //    MessageBox.Show("Chưa chọn nhân viên giao", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    returnValue = false;
            //}

            //if (_dieuChuyenNoiBoCongCuDungCu_single.MaNhanVienNhan == 0)
            //{
            //    MessageBox.Show("Chưa chọn nhân viên nhận", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    returnValue = false;
            //}

            if (_dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanGiao == _dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanNhan
                && _dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanGiao != 0
                && _dieuChuyenNoiBoCongCuDungCu_single.MaBoPhanNhan != 0
                )
            {
                MessageBox.Show("Bộ phận nhận đang trùng bộ phận giao", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                returnValue = false;
            }

            return returnValue;
        }

        private bool CheckValidWhenChangeNgayDieuChuyenNoiBo()//Them
        {
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_dieuChuyenNoiBoCongCuDungCu_single.NgayDieuChuyen);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!CCDC.KiemTraThaoTacCCDCHopLe(_dieuChuyenNoiBoCongCuDungCu_single.NgayDieuChuyen))
            {
                MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_dieuChuyenNoiBoCongCuDungCu_single.NgayDieuChuyen.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_dieuChuyenNoiBoCongCuDungCu_single.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_NgayDieuChuyenOld);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (!CCDC.KiemTraThaoTacCCDCHopLe(_NgayDieuChuyenOld))
                {
                    MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_NgayDieuChuyenOld.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        #endregion

        private void cbBoPhanGiao_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lookupEdit = sender as GridLookUpEdit;
            try
            {
                int maBoPhanGiao = (int)lookupEdit.EditValue;
                if (maBoPhanGiao != 0)
                {
                    _thongTinNhanVienTongHopList_benGiao = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan(maBoPhanGiao);//.GetThongTinNhanVienTongHopList_ByBophan(maBoPhanGiao);
                    ThongTinNhanVienTongHop nvEmpty = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<<None>>");
                    _thongTinNhanVienTongHopList_benGiao.Insert(0, nvEmpty);
                    thongTinNhanVienTongHopListBindingSource_benGiao_forCombo.DataSource = _thongTinNhanVienTongHopList_benGiao;
                }
            }
            catch (System.Exception ex)
            {

            }


        }

        private void cbBoPhanTiepNhan_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lookUpEdit = sender as GridLookUpEdit;
            try
            {
                int maBoPhan_tiepNhan = (int)lookUpEdit.EditValue;
                if (maBoPhan_tiepNhan != 0)
                {
                    _thongTinNhanVienTongHopList_benNhan = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan(maBoPhan_tiepNhan);//.GetThongTinNhanVienTongHopList_ByBophan(maBoPhan_tiepNhan);
                    ThongTinNhanVienTongHop nvEmpty = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<<None>>");
                    _thongTinNhanVienTongHopList_benNhan.Insert(0, nvEmpty);
                    thongTinNhanVienTongHopListBindingSource_benNhan_forCombo.DataSource = _thongTinNhanVienTongHopList_benNhan;
                }
            }
            catch (System.Exception ex)
            {

            }


        }

        private void barEditItem_BoPhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }



        private void cbNhanVienGiao_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cbNhanVienNhan_EditValueChanged(object sender, EventArgs e)
        {
            //
        }

        private void btnXoaTrenLuoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!CheckValidWhenChangeNgayDieuChuyenNoiBo()) return;

            if (this.bandedGridView_CT_DieuChuyenNoiBoList.SelectedRowsCount > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn có muốn xóa trên lưới những dòng đang chọn. Nếu xóa, sau đó cần bấm nut \"[" + btnLuu.Caption + "]\" để lưu lại những thay đổi xuống cơ sở dữ liệu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    this.bandedGridView_CT_DieuChuyenNoiBoList.DeleteSelectedRows();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng chi tiết cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bandedGridView_CT_DieuChuyenNoiBoList_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView = sender as DevExpress.XtraGrid.Views.BandedGrid.BandedGridView;
            if (object.ReferenceEquals(e.Column, this.bandedGridColumn_KhongConDung) || object.ReferenceEquals(e.Column, this.bandedGridColumn_KhongSuDung))
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void bandedGridView_CT_DieuChuyenNoiBoList_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gridCtrl_DuyetCongCuDungCuList_Click(object sender, EventArgs e)
        {

        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_dieuChuyenNoiBoCongCuDungCu_single.MaDieuChuyen != 0 && _dieuChuyenNoiBoCongCuDungCu_single.IsNew == false && _dieuChuyenNoiBoCongCuDungCu_single.IsDirty == false)
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("BienBan_BanGiao_CCDC_DieuChuyen_NoiBo");
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, ERP_Library.Security.CurrentUser.Info.UserID, dtDenNgay);

                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = ERP_Library.Security.CurrentUser.Info.UserID;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }

                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Cần lưu trước khi xem báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmDieuChuyenNoiBoCCDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_dieuChuyenNoiBoCongCuDungCu_single != null && (_dieuChuyenNoiBoCongCuDungCu_single.IsDirty || _dieuChuyenNoiBoCongCuDungCu_single.IsNew))
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

        public void InBienBan_BanGiao_CCDC_DieuChuyen_NoiBo()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBienBan_BanGiao_CCDC_DieuChuyen_NoiBo
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BienBan_BanGiao_CCDC_DieuChuyenNoiBo";
                    cm.Parameters.AddWithValue("@Ngay", _dieuChuyenNoiBoCongCuDungCu_single.NgayDieuChuyen);
                    cm.Parameters.AddWithValue("@MaDieuChuyen", _dieuChuyenNoiBoCongCuDungCu_single.MaDieuChuyen);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BienBan_BanGiao_CCDC_DieuChuyenNoiBo";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 


                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us 
        }

        private void bandedGridView_CT_DieuChuyenNoiBoList_KeyDown(object sender, KeyEventArgs e)
        {

            //BandedGridView gridView = sender as BandedGridView;
            if (e.KeyCode == Keys.Delete)
            {
                btnXoaTrenLuoi.PerformClick();
            }
        }

        private void frmDieuChuyenNoiBoCCDC_Load(object sender, EventArgs e)
        {
            //Utils.GridUtils.SetSTTForGridView(gridView_DuyetCongCuDungCuList);
            //Utils.GridUtils.SetSTTForGridView(bandedGridView_CT_DieuChuyenNoiBoList);

            Utils.GridUtils.ConfigGridView(gridView_DuyetCongCuDungCuList
                         , setSTT: true//
                         , initCopyCell: false
                         , multiSelectCell: false
                         , multiSelectRow: false
                         , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(bandedGridView_CT_DieuChuyenNoiBoList
                  , setSTT: true//
                  , initCopyCell: true//
                  , multiSelectCell: true//
                  , multiSelectRow: false
                  , initNewRowOnTop: false);
  
        }

        private void deNgayLap_Leave(object sender, EventArgs e)
        {

        }

        private void deNgayDieuChuyen_Leave(object sender, EventArgs e)
        {
            if (deNgayDieuChuyen.OldEditValue != deNgayDieuChuyen.EditValue)
            {
                if (!CheckValidWhenChangeNgayDieuChuyenNoiBo())
                {
                    _dieuChuyenNoiBoCongCuDungCu_single.NgayDieuChuyen = _NgayDieuChuyenOld;
                    deNgayDieuChuyen.EditValue = _NgayDieuChuyenOld as object;
                }
            }
        }//end function
    }
}