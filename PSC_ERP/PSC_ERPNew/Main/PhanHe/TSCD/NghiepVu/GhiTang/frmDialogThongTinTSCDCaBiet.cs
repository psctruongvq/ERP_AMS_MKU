using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Common;
using PSC_ERP_Core;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using ERP_Library.Security;

namespace PSC_ERPNew.Main
{
    public partial class frmDialogThongTinTSCDCaBiet : XtraForm
    {
       //Private Member field
        #region Private Member field
        private TaiSanCoDinhCaBiet_Factory _factoryDocLap = null;
        private bool _duocPhepLuuDocLap = false;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        DanhMucTSCD_Factory _danhMucTSCD_Factory = DanhMucTSCD_Factory.New();
        IQueryable<tblDanhMucTSCD> _nhomList;
        IQueryable<tblDanhMucTSCD> _loaiList;
        IQueryable<tblDanhMucTSCD> _TSCDList;
        List<tblDanhMucTSCD> _TSCDorCCDCList;
        IQueryable<tblTaiKhoan> _taiKhoanList;
        IQueryable<tblBoPhanERPNew> _phongBanList;
        IQueryable<tblNguon> _nguonList;
        IQueryable<tblDonViTinh> _donViTinhList;
        IQueryable<tblQuocGia> _quocGiaList;
        List<spd_LichSuDieuChuyenTaiSanCoDinhCaBiet_Result> _lichSuDieuChuyenNoiBo = new List<spd_LichSuDieuChuyenTaiSanCoDinhCaBiet_Result>();
        List<spd_TSCD_LichSuTongQuatSuDungTaiSan_Result> _lichSuTongQuat = new List<spd_TSCD_LichSuTongQuatSuDungTaiSan_Result>();
        UserInfo user = ERP_Library.Security.CurrentUser.Info;
        tblTaiSanCoDinhCaBiet _taiSanCoDinhCaBiet = null;
        #endregion

        //Public Member Property
        #region Public Member Property
        public tblTaiSanCoDinhCaBiet TaiSanCoDinhCaBiet
        {
            get
            {
                //số hiệu tự động nhảy, ko bind được nên dùng cách này để gán
                //_taiSanCoDinhCaBiet.SoHieu = txtSoHieuCaBiet.EditValue.ToString();
                return _taiSanCoDinhCaBiet;
            }
            //set { _taiSanCoDinhCaBiet = value; }
        }

        #endregion

        //Member Constructor
        #region Member Constructor
        //public frmDialogThongTinTSCDCaBiet(tblTaiSanCoDinhCaBiet tscdCaBiet, bool duocPhepLuuDocLap = false)
        // bổ sung maTSCDCaBiet dùng cho form cây tài sản date:24/11/2020
        public frmDialogThongTinTSCDCaBiet(tblTaiSanCoDinhCaBiet tscdCaBiet, bool duocPhepLuuDocLap = false, int maTSCDCaBiet=0)

        {
            InitializeComponent();

            if (duocPhepLuuDocLap == false)
            {//nhận tài sản cá biệt từ form chứng từ ghi tăng
                _taiSanCoDinhCaBiet = tscdCaBiet;
            }
            else
            {
                //khởi tạo factory xài riêng
                _factoryDocLap = TaiSanCoDinhCaBiet_Factory.New();
                //doc lai tai san
                if(maTSCDCaBiet>0)
                    // đọc lại tài sản theo maTSCDCaBiet từ cây tài sản Date:24/11/2020
                    _taiSanCoDinhCaBiet = _factoryDocLap.Get_TaiSanCoDinhCaBiet_ByMaTSCDCaBiet(maTSCDCaBiet);
                else
                    _taiSanCoDinhCaBiet = _factoryDocLap.Get_TaiSanCoDinhCaBiet_ByMaTSCDCaBiet(tscdCaBiet.MaTSCDCaBiet);
                //an hien menu
                this.btnDuaDuLieuVeChungTuGhiTang.Visibility = BarItemVisibility.Never;
                this.btnSave.Visibility = BarItemVisibility.Always;
                this.btnThoat.Visibility = BarItemVisibility.Always;
            }
            this.DialogResult = DialogResult.No;

            this.LoadData();
            // Cài đặt lưới
            GridUtil.SetSTTForGridView(this.grdViewChiTietTaiSanCaBiet);
            GridUtil.SetSTTForGridView(this.grdViewDungCuPhuTung);
            //cài đặt filter để ko hiển thị các dòng dụng cụ phụ tùng từ nghiệp vụ sữa chữa lớn
            this.colLaDCPTSuaChuaLon.FilterInfo = new ColumnFilterInfo(this.colLaDCPTSuaChuaLon.FieldName + " = false");
            //cài đặt filter để ko hiển thị các dòng bổ sung chi tiết tài sản sữa chữa lớn
            this.colLaChiTietSuaChuaLon.FilterInfo = new ColumnFilterInfo(this.colLaChiTietSuaChuaLon.FieldName + " = false");
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
           
            //lấy danh sách tài khoản
            _taiKhoanList = TaiKhoan_Factory.New().GetAll();
            //lấy danh sách phòng ban
            _phongBanList = BoPhanERPNew_Factory.New().GetAll();
            //lấy danh sách nguồn
            _nguonList = Nguon_Factory.New().GetAll();
            //lấy danh sách đơn vị tính
            _donViTinhList = DonViTinh_Factory.New().GetAll();
            //lấy danh sách quốc gia
            _quocGiaList = QuocGia_Factory.New().GetAll();
            _nhomList = _danhMucTSCD_Factory.Get_DanhSachNhomTaiSan();
            _loaiList = _danhMucTSCD_Factory.Get_DanhSachLoaiTaiSan();

            GanBindingSource();
            LayDanhSachLoaiTaiSan();
            LayDanhSachTSCD();

            Int32 maNhom = _taiSanCoDinhCaBiet.tblDanhMucTSCD.tblDanhMucTSCD2.LoaiTaiSanThuocNhomTaiSan ?? 0;
            Int32 maLoai = _taiSanCoDinhCaBiet.tblDanhMucTSCD.ParentID ?? 0;
            Int32 maTSCD = _taiSanCoDinhCaBiet.MaTSCD ?? 0;

            cbNhomTaiSan.EditValue = maNhom;
            treeListLookUpEdit_LoaiTaiSan.EditValue = maLoai;
            cbTaiSanCoDinh.EditValue = maTSCD;

            if (_taiSanCoDinhCaBiet.MaTSCDCaBiet != 0)
            {
                _lichSuDieuChuyenNoiBo = TaiSanCoDinhCaBiet_Factory.New().Context.spd_LichSuDieuChuyenTaiSanCoDinhCaBiet(_taiSanCoDinhCaBiet.MaTSCDCaBiet).ToList();
                _lichSuTongQuat = TaiSanCoDinhCaBiet_Factory.New().Context.spd_TSCD_LichSuTongQuatSuDungTaiSan(_taiSanCoDinhCaBiet.MaTSCDCaBiet).ToList();
                //lịch sử điều chuyển
                tblLichSuDieuChuyenTaiSanbindingSource.DataSource = _lichSuDieuChuyenNoiBo;
                //lịch sử điều chuyển tổng quát
                tblLichSuSuDungTaiSan.DataSource = _lichSuTongQuat;
            }

        }
        private void GanBindingSource()
        {
            tblTaiSanCoDinhCaBietBindingSource_Single.DataSource = _taiSanCoDinhCaBiet;

            //nhóm tài sản
            tblDanhMucTSCDBindingSource_Nhom.DataSource = _nhomList;
            //loại tài sản
            tblDanhMucTSCDBindingSource_Loai.DataSource = _loaiList;
            //tài sản cố định
            tblDanhMucTSCDBindingSource_TSCD.DataSource = _TSCDorCCDCList;
            //tài khoản
            tblTaiKhoanBindingSource.DataSource = _taiKhoanList;
            //phòng ban
            tblBoPhanERPNewBindingSource.DataSource = _phongBanList;
            //loại ghi tăng
            loaiGhiTangTSCDCaBietBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.LoaiGhiTangTSCDCaBiet.LoaiGhiTangTSCDCaBietList;
            //nguồn
            tblNguonBindingSource.DataSource = _nguonList;
            //đơn vị tính
            tblDonViTinhBindingSource.DataSource = _donViTinhList;
            //quốc gia
            tblQuocGiaBindingSource.DataSource = _quocGiaList;
            //chi tiết tài sản
            tblChiTietTaiSanCaBietBindingSource.DataSource = _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets;
            //dụng cụ phụ tùng
            tblBoSungDungCuPhuTungBindingSource.DataSource = _taiSanCoDinhCaBiet.tblBoSungDungCuPhuTungs;
            //lịch sử sửa chữa tài sản
            tblLichSuSuaChuaTaiSanBindingSource.DataSource = _taiSanCoDinhCaBiet.tblLichSuSuaChuaTaiSans;
            //lịch sử điều chuyển
            tblLichSuDieuChuyenTaiSanbindingSource.DataSource = _lichSuDieuChuyenNoiBo;
            //lịch sử điều chuyển tổng quát
            tblLichSuSuDungTaiSan.DataSource = _lichSuTongQuat;
        }

        private Boolean KiemTraHopLe()
        {
            Boolean hopLe = true;

            //Kiểm tra chọn tài sản cố định
            if ((_taiSanCoDinhCaBiet.MaTSCD ?? 0) == 0)
            {
                DialogUtil.ShowWarning("Chưa chọn tài sản cố định");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                cbTaiSanCoDinh.Focus();
                hopLe = false;
            }
            //kiểm tra số hiệu
            if (txtSoHieuCaBiet.EditValue == null || String.IsNullOrWhiteSpace(txtSoHieuCaBiet.EditValue.ToString()))
            {
                DialogUtil.ShowWarning("Số hiệu tài sản cá biệt rỗng");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtSoHieuCaBiet.Focus();
                hopLe = false;
            }          
            //kiểm tra tài khoản
            //if ((Int32)cbTaiKhoan.EditValue == 0 || cbTaiKhoan.Text == "<<Không chọn>>")
            //{
            //    DialogUtil.ShowWarning("Chưa chọn tài khoản");
            //    //focus đến vị trí
            //    xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
            //    cbTaiKhoan.Focus();
            //    hopLe = false;
            //}

            //kiểm tra lũy kế KH
            if ((_taiSanCoDinhCaBiet.LuyKeKhauHao ?? 0) < 0)
            {
                DialogUtil.ShowWarning("Lũy kế khấu hao phải là số dương");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtLuyKeKH.Focus();
                hopLe = false;
            }
            //Kiểm tra lũy kế HM
            if ((_taiSanCoDinhCaBiet.LuyKeHaoMon ?? 0) < 0)
            {
                DialogUtil.ShowWarning("Lũy kế hao mòn phải là số dương");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtLuyKeHM.Focus();
                hopLe = false;
            }

            //kiểm tra nguyên giá
            if ((_taiSanCoDinhCaBiet.NguyenGiaMua ?? 0) == 0)
            {
                DialogUtil.ShowWarning("Chưa nhập nguyên giá");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtNguyenGia.Focus();
                hopLe = false;
            }
            if ((_taiSanCoDinhCaBiet.NguyenGiaMua ?? 0) < 0)
            {
                DialogUtil.ShowWarning("Nguyên giá phải là số dương");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtNguyenGia.Focus();
                hopLe = false;
            }
            //kiểm tra chi phí
            if ((_taiSanCoDinhCaBiet.ChiPhi ?? 0) < 0)
            {
                DialogUtil.ShowWarning("Chi phí phải là số dương");
                //focus đến vị trí
                xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                txtChiPhiCaBiet.Focus();
                hopLe = false;
            }
            //Kiểm tra chi tiết////////////////////////////////////////////////////////
            foreach (tblChiTietTaiSanCaBiet chiTiet in _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets)
            {
                //if (String.IsNullOrWhiteSpace(chiTiet.TenChiTiet))
                //{
                //    DialogUtil.ShowWarning("Kiểm tra danh sách chi tiết tài sản. Tên của chi tiết không được rỗng");
                //    //focus đến vị trí
                //    xtraTabControl1.SelectedTabPage = tabChiTietTaiSan;
                //    hopLe = false;
                //}
                if (String.IsNullOrWhiteSpace(chiTiet.SoHieu))
                {
                    DialogUtil.ShowWarning("Kiểm tra danh sách chi tiết tài sản. Số hiệu của chi tiết không được rỗng");
                    //focus đến vị trí
                    xtraTabControl1.SelectedTabPage = tabChiTietTaiSan;
                    hopLe = false;
                }
            }
            return hopLe;
        }
        private void LayDanhSachLoaiTaiSan()
        {
            //tblDanhMucTSCD nhom = cbNhomTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;

            //if (nhom != null)
            //{
            //    _loaiList = _danhMucTSCD_Factory.Get_DanhSachLoaiTaiSan_ByMaNhomTaiSan(nhom.ID);
            //    tblDanhMucTSCDBindingSource_Loai.DataSource = _loaiList;
            //}
        }
        private void LayDanhSachTSCD()
        {
            ////đọc lại danh sách tài sản cố định
            tblDanhMucTSCD loai = treeListLookUpEdit_LoaiTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;
            if (loai != null)
            {
                _TSCDList = _danhMucTSCD_Factory.Get_DanhSachTaiSanCoDinh_TrucTiep_ByMaLoaiTaiSan(loai.ID);
                tblDanhMucTSCDBindingSource_TSCD.DataSource = _TSCDList;
                cbTaiSanCoDinh.Properties.DataSource = tblDanhMucTSCDBindingSource_TSCD;
            }
            else
            {
                _TSCDorCCDCList = _danhMucTSCD_Factory.Context.spd_TSCD_LayDanhSachDanhMucTSCDorCCDCTheoCapCha(0, _maCongTy).ToList();
                tblDanhMucTSCDBindingSource_TSCD.DataSource = _TSCDorCCDCList;
                cbTaiSanCoDinh.Properties.DataSource = tblDanhMucTSCDBindingSource_TSCD;
            }
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmDialogThongTinTSCDCaBiet_Load(object sender, EventArgs e)
        {                     
            if (user.TenDangNhap.ToLower().Equals("admin") || user.GroupID == 38)
            {
                cbNguonMua.Enabled = true;
                numSoNamSD.Enabled = true;
            }
            //Delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewChiTietTaiSanCaBiet, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa chi tiet
                ChiTietTaiSanCaBiet_Factory.FullDelete((Entities)_taiSanCoDinhCaBiet.GetContext(), deleteList);
            });
            //Delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewDungCuPhuTung, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa dụng cụ phụ tùng
                BoSungDungCuPhuTung_Factory.FullDelete((Entities)_taiSanCoDinhCaBiet.GetContext(), deleteList);
            });
            GridUtil.DeleteHelper.Setup_ManualType(gridView_LichSuSuaChuaTS, (GridView gridView, List<Object> deleteList) =>
            {
                //lịch sử sửa chữa nhỏ
                SuaChuaNhoVaBaoTri_Factory.FullDelete((Entities)_taiSanCoDinhCaBiet.GetContext(), deleteList);
            });
            //LayDanhSachTSCD();
           // LayDanhSachLoaiTaiSan();
        }
     
        private void cbNhomTaiSan_EditValueChanged(object sender, EventArgs e)
        {
            tblDanhMucTSCD nhom = _danhMucTSCD_Factory.Get_NhomTaiSan_ByMaNhomTaiSan(Convert.ToInt32(cbNhomTaiSan.EditValue)) as tblDanhMucTSCD;
            if (nhom != null)
            {
                txtTenNhomTaiSan.Text = nhom.Ten;
                tblDanhMucTSCDBindingSource_Nhom.DataSource = nhom;
            }
        }
        private void treeListLookUpEdit_LoaiTaiSan_EditValueChanged(object sender, EventArgs e)
        {
            tblDanhMucTSCD loai = treeListLookUpEdit_LoaiTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;
            if (loai != null)
            {
                txtTenLoaiTaiSan.Text = loai.Ten;
                cbNhomTaiSan.EditValue = loai.LoaiTaiSanThuocNhomTaiSan;
            }

        }

        private void cbTaiSanCoDinh_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            //lấy số hiệu mới
            if (e.OldValue != null)
            {
                if (e.NewValue != null)
                {
                    int maTSCD = Convert.ToInt32(e.NewValue);
                    txtSoHieuCaBiet.EditValue = TaiSanCoDinhCaBiet_Factory.New().Get_NextSoHieuTSCDCaBiet_ByMaTSCD(maTSCD);
                }
            }
        }
        private void cbTaiSanCoDinh_EditValueChanged(object sender, EventArgs e)
        {

           tblDanhMucTSCD tscd = _danhMucTSCD_Factory.Get_TaiSanCoDinh_ByMaTSCD( (int)cbTaiSanCoDinh.EditValue)as tblDanhMucTSCD;
            if (tscd != null)
            {
                //gán mã tài sản
                _taiSanCoDinhCaBiet.MaTSCD = tscd.ID;
                txtTenTSCD.Text = tscd.Ten;
                txtModelTSCD.Text = tscd.ModelTSCD;
           
                cbDonViTinh.EditValue = tscd.MaDonViTinhTSCD;
                cbNuocSanXuat.EditValue = tscd.MaNuocSxTSCD;
                //treeListLookUpEdit_LoaiTaiSan.EditValue = tscd.ParentID;            
            }
            else
            {
                txtTenTSCD.Text = "";
                txtModelTSCD.Text = "";
                txtSoHieuCaBiet.Text = "";
            }
        }

        private void btnDuaDuLieuVeChungTuGhiTang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (KiemTraHopLe())
            {
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;//thoát mà không làm gì hết
            this.Close();
        }        

        private void txtNguyenGia_EditValueChanged(object sender, EventArgs e)
        {
            //cập nhật đơn giá = nguyên giá - chi phí
            //this._donGia = (this.NguyenGiaMua == null ? 0 : this.NguyenGiaMua.Value) - (this.ChiPhi == null ? 0 : this.ChiPhi.Value);
        }
        private void txtDonGia_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Decimal.Parse(txtChiPhiCaBiet.EditValue.ToString() == "" ? "0" : txtChiPhiCaBiet.EditValue.ToString()) != 0 || Decimal.Parse(txtDonGia.EditValue.ToString() == "" ? "0" : txtDonGia.EditValue.ToString()) != 0)
            //    {

            //        this.txtNguyenGia.EditValue = Decimal.Parse(txtChiPhiCaBiet.EditValue.ToString() == "" ? "0" : txtChiPhiCaBiet.EditValue.ToString()) + Decimal.Parse(txtDonGia.EditValue.ToString() == "" ? "0" : txtDonGia.EditValue.ToString());

            //    }
            //}
            //catch (System.Exception ex)
            //{
            //}
        }
        private void txtChiPhiCaBiet_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (Decimal.Parse(txtChiPhiCaBiet.EditValue.ToString() == "" ? "0" : txtChiPhiCaBiet.EditValue.ToString()) != 0 || Decimal.Parse(txtDonGia.EditValue.ToString() == "" ? "0" : txtDonGia.EditValue.ToString()) != 0)
            //    {
            //        this.txtNguyenGia.EditValue = Decimal.Parse(txtChiPhiCaBiet.EditValue.ToString() == "" ? "0" : txtChiPhiCaBiet.EditValue.ToString()) + Decimal.Parse(txtDonGia.EditValue.ToString() == "" ? "0" : txtDonGia.EditValue.ToString());
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //}
        }
        private void grdViewChiTietTaiSanCaBiet_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //lấy chi tiết mới
            tblChiTietTaiSanCaBiet chiTietMoi = grdViewChiTietTaiSanCaBiet.GetRow(e.RowHandle) as tblChiTietTaiSanCaBiet;
            if (chiTietMoi != null)
            {
                Int32 maxNum = 0;
                foreach (tblChiTietTaiSanCaBiet chiTietTruocDo in _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets)
                {
                    if (String.IsNullOrWhiteSpace(chiTietTruocDo.SoHieu) == false)
                    {
                        Int32 maxNumTemp = Int32.Parse(chiTietTruocDo.SoHieu.Substring(chiTietTruocDo.SoHieu.Length - PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart));
                        if (maxNumTemp > maxNum)
                            maxNum = maxNumTemp;
                    }
                }

                String soHieuCapTren = txtSoHieuCaBiet.Text;
                //tạo số hiệu
                String soHieuMoi = "";
                if (maxNum == 0) //số hiệu đầu tiên
                    soHieuMoi = ChiTietTaiSanCaBiet_Factory.CreateFirst_SoHieuChiTietTaiSanCaBiet(soHieuCapTren);
                else//số hiệu tiếp theo
                    soHieuMoi = ChiTietTaiSanCaBiet_Factory.Create_SoHieuChiTietTaiSanCaBiet(soHieuCapTren, maxNum + 1);

                //gán số hiệu mới cho chi tiết
                chiTietMoi.SoHieu = soHieuMoi;
                chiTietMoi.TenChiTiet = "";
                //mặc định số lượng =1
                chiTietMoi.DonGia = 0;
                chiTietMoi.ChiPhi = 0;
                chiTietMoi.SoLuong = 1;
                chiTietMoi.NguyenGia = 0;
                //chiTietMoi.GhiChu = txtGhiChu.Text.Trim();
            }
        }
        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabChiTietTaiSan)
            {
                if (String.IsNullOrWhiteSpace(txtSoHieuCaBiet.Text))
                {
                    DialogUtil.ShowWarning(String.Format("Cần nhập thông tin bên thẻ [{0}] trước!", tabTaiSanChinh.Text));
                    //focus về tab tài sản chính
                    xtraTabControl1.SelectedTabPage = tabTaiSanChinh;
                }
            }
        }
        private void grdViewDungCuPhuTung_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //lấy đối tượng vừa tạo mới trên lưới
            tblBoSungDungCuPhuTung doiTuong = grdViewDungCuPhuTung.GetRow(e.RowHandle) as tblBoSungDungCuPhuTung;
            if (doiTuong != null)
            {
                //mặc định số lượng =1
                doiTuong.DonGia = 0;
                doiTuong.ChiPhi = 0;
                doiTuong.SoLuong = 1;
                doiTuong.TongGiaTri = 0;
                //doiTuong.GhiChu = txtGhiChu.Text.Trim();
                doiTuong.Ten = "";
                doiTuong.MaQuanLy = "";

            }
        }
        private void btnSaoChepDungCuPhuTung_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = this.grdViewDungCuPhuTung.GetSelectedRows();
            foreach (var rowHandle in selectedRowHandles)
            {
                if (rowHandle >= 0)
                {
                    tblBoSungDungCuPhuTung dungCuPhuTung = this.grdViewDungCuPhuTung.GetRow(rowHandle) as tblBoSungDungCuPhuTung;
                    //copy
                    tblBoSungDungCuPhuTung dungCuPhuTungNew = BoSungDungCuPhuTung_Factory.BasicClonePhuTungGhiTang(dungCuPhuTung);
                    //dua vao tai san
                    _taiSanCoDinhCaBiet.tblBoSungDungCuPhuTungs.Add(dungCuPhuTungNew);
                }
            }
        }
        private void btnSaoChepChiTietTaiSan_Click(object sender, EventArgs e)
        {
            int[] selectedRowHandles = this.grdViewChiTietTaiSanCaBiet.GetSelectedRows();
            foreach (var rowHandle in selectedRowHandles)
            {
                if (rowHandle >= 0)
                {
                    tblChiTietTaiSanCaBiet chiTiet = this.grdViewChiTietTaiSanCaBiet.GetRow(rowHandle) as tblChiTietTaiSanCaBiet;
                    //copy
                    tblChiTietTaiSanCaBiet chiTietNew = ChiTietTaiSanCaBiet_Factory.BasicCloneChiTietTaiSan(chiTiet);
                    //tao moi so hieu cho chi tiet
                    {
                        Int32 sizeOfNumber = PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart;
                        //lay max so hieu trong danh sách
                        String maxSoHieuChiTiet = (from o in _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets
                                                   orderby o.SoHieu.Substring(o.SoHieu.Length - sizeOfNumber, sizeOfNumber) descending
                                                   select o.SoHieu).FirstOrDefault();
                        if (maxSoHieuChiTiet != null)
                            chiTietNew.SoHieu = ChiTietTaiSanCaBiet_Factory.IncreaseSoHieuChiTietTaiSanCaBiet(maxSoHieuChiTiet);
                    }
                    //dua vao tai san
                    _taiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets.Add(chiTietNew);
                }

            }
        }
        private void cbTaiKhoan_EditValueChanged(object sender, EventArgs e)
        {
            //Thread thr = new Thread(() =>
            //{
            //    if (this.InvokeRequired)
            //    {
            //        PSC_ERP_Common.Delegate.VoidDelegate dele = new PSC_ERP_Common.Delegate.VoidDelegate(this.TinhSoNamSuDung);
            //        this.Invoke(dele);
            //    }
            //    else
            //    {
            //        this.TinhSoNamSuDung();
            //    }
            //});
            //thr.Start();
        }

        private void TinhSoNamSuDung()
        {
            tblTaiKhoan taiKhoan = cbTaiKhoan.GetSelectedDataRow() as tblTaiKhoan;
            if (taiKhoan != null)
            {
                DateTime ngay = _taiSanCoDinhCaBiet.NgayChungTu.Value;
                tblTiLeKhauHaoTheoTaiKhoan tileKHTheoTaiKhoan = TiLeKhauHaoTheoTaiKhoan_Factory.New().GetLast_TiLeKhauHaoTheoTaiKhoan_BySoHieuTaiKhoanAndNgayChot(taiKhoan.SoHieuTK, ngay);
                if (tileKHTheoTaiKhoan != null)
                    _taiSanCoDinhCaBiet.ThoiGianSuDung = (Int32)(100 / tileKHTheoTaiKhoan.PhanTram);
                else
                    _taiSanCoDinhCaBiet.ThoiGianSuDung = 0;
            }
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            try
            {
                if (KiemTraHopLe())
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        _factoryDocLap.SaveChangesWithoutTrackingLog();
                        //_factoryDocLap.SaveChanges();
                    }
                    DialogUtil.ShowSaveSuccessful();
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion

        private void btn_InLichSuSuDungTaiSan_ItemClick(object sender, ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("In_ChiTietSuDungTaiSan", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spd_TSCD_LichSuTongQuatSuDungTaiSan", "@MaTSCDCB", _taiSanCoDinhCaBiet.MaTSCDCaBiet);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }

        private void cbDonViTinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                frmListDonViTinh frm = new frmListDonViTinh();
                frm.ShowDialog();
                _donViTinhList = DonViTinh_Factory.New().GetAll();
                tblDonViTinhBindingSource.DataSource = _donViTinhList;
            }
        }

        private void cbNuocSanXuat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                frmListQuocGia frm = new frmListQuocGia();
                frm.ShowDialog();
                _quocGiaList = QuocGia_Factory.New().GetAll();
            }
        }

       
    }
}