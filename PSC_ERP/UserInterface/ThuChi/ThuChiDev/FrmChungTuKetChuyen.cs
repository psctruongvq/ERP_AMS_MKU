using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Common;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class FrmChungTuKetChuyen : DevExpress.XtraEditors.XtraForm
    {
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        ChungTu _chungTu = ChungTu.NewChungTu(); 
        LoaiChungTuDev _LoaiChungTu = LoaiChungTuDev.NewLoaiChungTuDev();
        HeThongTaiKhoan1List _HeThongTaiKhoan1ListCo, _HeThongTaiKhoan1ListNo;
        HopDongMuaBanList _hopDongList;
        DoiTuongAll dtKhachHang = DoiTuongAll.NewDoiTuongAll(0);
        int _maDoiTuongDeNghi = 0;
        bool _taoMoiChungTu = true;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet = new DataSet();

        public FrmChungTuKetChuyen()
        {
            InitializeComponent();
            this.Load += FrmChungTuKetChuyen_Load;
            this.DoiTuongGridLookUpEdit.EditValueChanged += DoiTuongGridLookUpEdit_EditValueChanged;
            this.dtmp_Ngay.Leave += dtmp_Ngay_Leave;
            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnDSChungTu.ItemClick += btnDSChungTu_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.btnXoaChungTu.ItemClick += btnXoaChungTu_ItemClick;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.btnPrintA4.ItemClick += btnPrintA4_ItemClick;
        }

        public FrmChungTuKetChuyen(long maChungTu)
        {
            InitializeComponent();
            this.Load += FrmChungTuKetChuyen_Load;
            this.DoiTuongGridLookUpEdit.EditValueChanged += DoiTuongGridLookUpEdit_EditValueChanged;
            this.dtmp_Ngay.Leave += dtmp_Ngay_Leave;
            this.btnThemMoi.ItemClick += btnThemMoi_ItemClick;
            this.btnDSChungTu.ItemClick += btnDSChungTu_ItemClick;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            this.btnXoaChungTu.ItemClick += btnXoaChungTu_ItemClick;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.btnPrintA4.ItemClick += btnPrintA4_ItemClick;

            ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(maChungTu);
            if (ct.Count > 0)
            {
                this._chungTu = ct[0];
            }
            if (this._chungTu.MaChungTu == 0) return;
        }

        void btnPrintA4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_LoaiChungTu.MaLoaiCTQuanLy == "PKC")//Bảng Kê
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuKeToanA4");//PhieuNhapVatTu//
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
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
        }

        public bool PhieuKeToan()//[dbo].[spd_BaoCaoChungTuGhiSo] 
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_BaoCaoChungTuGhiSo
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoChungTuGhiSo";
                    cm.Parameters.AddWithValue("@MaChungTu", _chungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_BaoCaoChungTuGhiSo";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private bool KhoaSo()
        {
            bool khoaso = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_chungTu.NgayLap);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }

            return khoaso;
        }

        private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        {
            bool khoataiKhoan = false;
            KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _chungTu.NgayLap);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoataiKhoan = true;
                }
            }
            return khoataiKhoan;
        }//Them

        private bool CheckCoTaiKhoanBiKhoaTrongButToan()
        {
            foreach (ButToan buttoan in _chungTu.DinhKhoan.ButToan)
            {
                if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan))
                {
                    return true;
                }
            }
            return false;
        }

        private bool KiemTraTruocKhiXoaChungTuHopLe()
        {
            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show(this, "Đã khóa sổ Tài Khoản,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool DeleteChungTu()
        {
            if (KiemTraTruocKhiXoaChungTuHopLe() == false)
                return false;
            if (_chungTu.MaChungTu != 0)
            {

                if (MessageBox.Show("Bạn Có Muốn Xóa Chứng Từ Số " + _chungTu.SoChungTu + " ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        ChungTu.DeleteChungTu(_chungTu);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                        //tlslblThem_Click(sender, e);
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }

                }
            }

            return false;
        }

        void btnXoaChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DeleteChungTu())
            {
                btnThemMoi.PerformClick();
            }
        }

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus1.Focus();
            HoatDong_gridLookUpEdit1.Focus();
            if (_taoMoiChungTu == true && CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show(this, "Đã khóa sổ tài khoản, không thể lưu ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (this.Save())
            {
                btnXoaChungTu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                this.strStatus = "KHOA";
                this.ReadOnlyConTrolByStatus(this.strStatus);
            }
        }

        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;

            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtSoChungTu.Text.Trim() == "")
            {
                MessageBox.Show(this, "Vui lòng nhập số chứng từ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoChungTu.Text = _chungTu.SoChungTu;
                txtSoChungTu.Focus();
                return false;
            }
            //kiểm tra trùng số chứng từ
            if (ChungTu.KiemTraSoChungTu(txtSoChungTu.Text, _chungTu) == true)
            {
                txtSoChungTu.Focus();
                DialogResult dlgResult = MessageBox.Show(this, "Trùng số chứng từ. Tự động phát sinh số chứng từ mới", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (dlgResult == DialogResult.Yes)
                {
                    _chungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, (Convert.ToDateTime(dtmp_Ngay.EditValue)).Date);//ChungTu.LaySoChungTuMax(_LoaiChungTu.MaLoaiCT, _ChungTu.NgayLap.Year);
                    //đệ quy
                    return DuocPhepLuu();
                }
                else
                    return false;
            }
            else if (_chungTu.Tien.SoTien == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Số Tiền Chứng Từ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                calcEdit_SoTien.Focus();
                return false;
            }
            if (KiemTraButToanHopLe() == false)
                return false;
            return duocPhepLuu;
        }

        private bool KiemTraButToanHopLe()
        {

            #region Modify Method
            decimal tongtienButToan = 0;
            foreach (ButToan bt in _chungTu.DinhKhoan.ButToan)
            {
                if (bt.NoTaiKhoan == 0 || bt.CoTaiKhoan == 0)
                {
                    MessageBox.Show(this, "Chưa chọn đầy đủ tài khoản của bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                #region KiemTraDoiTuongTheoDoi
                HeThongTaiKhoan1 httkno = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
                HeThongTaiKhoan1 httkco = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan);
                if (httkno.CoDoiTuongTheoDoi == true)
                {
                    if (bt.DoiTuongNo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng Nợ cho bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (httkco.CoDoiTuongTheoDoi == true)
                {
                    if (bt.DoiTuongCo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng Có cho bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                //Khoan Muc Chi Phi
                if (httkno.CoTheoDoiKhoanMucChiPhi == true || httkco.CoTheoDoiKhoanMucChiPhi == true)
                {
                    if (bt.IDKhoanMuc == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn khoản mục CP cho bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                //Don Vi
                if (httkno.CoDonViTheoDoi == true || httkco.CoDonViTheoDoi == true)
                {
                    if (bt.MaDonVi == 0)
                    {
                        if (MessageBox.Show("Đơn vị đang để trống cho tài khoản có theo dõi đơn vị, bạn có muốn tiếp tục lưu?", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        {
                            return false;
                        }
                    }
                }

                #endregion KiemTraDoiTuongTheoDoi

                tongtienButToan += bt.SoTien;
            }



            if (_chungTu.Tien.SoTien != tongtienButToan)
            {
                MessageBox.Show("Tổng tiền bút toán và Số tiền Chứng từ không bằng nhau, không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            #endregion//Modify Method

            return true;
        }

        private void XuLyTruocKhiLuu()
        {
            for (int i = 0; i < gridView_ButToan.RowCount; i++)
            {
                int currentRowHandle = gridView_ButToan.GetVisibleRowHandle(i);
                object obj = gridView_ButToan.GetRow(currentRowHandle);
                decimal sotien;
                bool hople = true;
                if (obj != null && decimal.TryParse(((ButToan)obj).SoTien.ToString(), out sotien))
                {
                    if (sotien == 0)
                    {
                        hople = false;
                    }
                }
                else hople = true;
                if (hople == false)
                {
                    ButToan butToan = (ButToan)gridView_ButToan.GetRow(currentRowHandle);
                    gridView_ButToan.DeleteRow(currentRowHandle);
                    i -= 1;
                }
            }
            //if (_taoMoiChungTu) _ChungTu.GhiSoCai = true;
        }

        private bool Save()
        {
            XuLyTruocKhiLuu();
            ////kiểm tra chứng từ trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        _chungTu.LoaiChungTu = _LoaiChungTu;
                        _chungTu.ApplyEdit();
                        _chungTu.Save();
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;

                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful();
                }
            }
            return false;
        }
        
        void btnDSChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTimChungTuNew f = new frmTimChungTuNew(_LoaiChungTu.MaLoaiCT);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                if (f.DaChon == true)
                {
                    LoadChungTuCu(f._ChungTu1.MaChungTu);
                    _taoMoiChungTu = false;//

                    this.strStatus = "KHOA";
                    this.ReadOnlyConTrolByStatus(this.strStatus);
                }
                else if (f.isCopyPassChungTu == true)
                {
                    _taoMoiChungTu = true;
                    this._chungTu = ChungTu.NewChungTu();
                    this._chungTu = f.chungTuMoi;
                    GetData();

                    this.strStatus = "THEM";
                    this.ReadOnlyConTrolByStatus(this.strStatus);
                }
            }
        }

        private void LoadChungTuCu(long machungtu)
        {
            ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(machungtu);
            if (ct.Count > 0)
            {
                _chungTu = ct[0];
            }
            if (_chungTu.MaChungTu != 0)
            {
                _LoaiChungTu = _chungTu.LoaiChungTu;
                tblButToanBindingSource.DataSource = _chungTu.DinhKhoan.ButToan;
                TienTe_bindingSource.DataSource = _chungTu.Tien;
                gridControl1.DataSource = tblButToanBindingSource;

                //_ngayLapCu = _ChungTu.NgayLap.Year > 1900 ? _ChungTu.NgayLap : _ChungTu.NgayThucHien;
                dtmp_Ngay.EditValue = _chungTu.NgayLap;
                GetData();

                calcEdit_ThanhTien.EditValue = _chungTu.Tien.ThanhTien;
                calcEdit_SoTien.EditValue = _chungTu.Tien.SoTien;
            }
        }

        void gridView_ButToan_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                ButToan buttoan = this.gridView_ButToan.GetRow(e.RowHandle) as ButToan;
                if (buttoan != null)
                {
                    if (txt_DienGiai.EditValue != null)
                        buttoan.DienGiai = txt_DienGiai.EditValue.ToString();
                    TinhTien();
                }
            }
            catch
            { }
        }
        private void TinhTien()
        {
            decimal tong = 0;
            foreach (ButToan bt in _chungTu.DinhKhoan.ButToan)
            {

                tong += bt.SoTien;
            }
            _chungTu.Tien.SoTien = tong;
        }

        void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            HoatDong_gridLookUpEdit1.Focus();
            dtmp_Ngay.DateTime = DateTime.Now;
            _chungTu = ChungTu.NewChungTu(_LoaiChungTu.MaLoaiCT);
            _chungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _chungTu.NgayLap);
            //GetData();
            ChungTu_bindingSource.DataSource = _chungTu;
            TienTe_bindingSource.DataSource = _chungTu.Tien;
            tblButToanBindingSource.DataSource = _chungTu.DinhKhoan.ButToan;
            gridControl1.DataSource = tblButToanBindingSource;

            MaDoiTuongtextEdit1.EditValue = "";
            NguoiNhan_textEdit1.EditValue = "";
            txt_DiaChiDoiTuongNhan.EditValue = "";
            txt_DienGiai.EditValue = "";

            this.strStatus = "THEM";
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }

        void dtmp_Ngay_Leave(object sender, EventArgs e)
        {
            if (dtmp_Ngay.OldEditValue != dtmp_Ngay.EditValue)
            {
                _chungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _chungTu.NgayLap);
            }
        }


        void DoiTuongGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (DoiTuongGridLookUpEdit.EditValue != null)
            {
                int madoituongOut;
                if (int.TryParse(DoiTuongGridLookUpEdit.EditValue.ToString(), out madoituongOut))
                {
                    LoadDataControlLienQuanTheoDoiTuong(madoituongOut);
                }
            }
        }

        private void LoadDataControlLienQuanTheoDoiTuong(int maDoiTuong)
        {
            if (maDoiTuong != 0)
            {
                dtKhachHang = DoiTuongAll.GetDoiTuongAll(maDoiTuong);
                MaDoiTuongtextEdit1.Text = dtKhachHang.MaQLDoiTuong;

                txt_DiaChiDoiTuongNhan.Text = dtKhachHang.DiaChi;
                NguoiNhan_textEdit1.Text = dtKhachHang.TenDoiTuong;

                _hopDongList = HopDongMuaBanList.GetHopDongMuaBanList_TheoDoiTac(maDoiTuong);
                _hopDongList.Insert(0, HopDongMuaBan.NewHopDongMuaBan(0, ""));
                HopDong_bindingSource.DataSource = _hopDongList;

            }
        }

        private void DesignLueHoatDong()
        {
            HamDungChung.InitGridLookUpDev2(HoatDong_gridLookUpEdit1, HoatDongList_bindingSource1, "TenHoatDong", "MaHoatDong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(HoatDong_gridLookUpEdit1, new string[] { "TenHoatDong", "MaQLHoatDong" }, new string[] { "Hoạt động", "Mã QL" }, new int[] { 120, 100 }, false);
        }

        private void DesignLueDoiTuong()
        {
            HamDungChung.InitGridLookUpDev2(DoiTuongGridLookUpEdit, DoiTuongList_bindingSource1, "TenDoiTuong", "MaDoiTuong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(DoiTuongGridLookUpEdit, new string[] { "TenDoiTuong", "MaDoiTuong" }, new string[] { "Tên đối tượng", "Mã đối tượng" }, new int[] { 120, 100 }, false);
        }

        private void DesignLueNhanVien()
        {
            HamDungChung.InitGridLookUpDev2(NhanVien_gridLookUpEdit1, NhanVienList_bindingSource, "TenDoiTuong", "MaDoiTuong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(NhanVien_gridLookUpEdit1, new string[] { "TenDoiTuong", "MaDoiTuong" }, new string[] { "Tên đối tượng", "Mã đối tượng" }, new int[] { 120, 100 }, false);
        }

        private void GetDataHoatDong()
        {
            HoatDongDevList _hoatDongList = HoatDongDevList.GetHoatDongDevList(_maCongTy);
            HoatDongDev _hoatDong = HoatDongDev.NewHoatDongDev();
            _hoatDong.TenHoatDong = "";
            _hoatDongList.Insert(0, _hoatDong);
            HoatDongList_bindingSource1.DataSource = _hoatDongList;
        }

        private void GetDataDoiTuong()
        {
            DoiTuongAllList _doituongList = DoiTuongAllList.GetDoiTuongAllList();
            DoiTuongAll _doiTuong = DoiTuongAll.NewDoiTuongAll("");
            _doiTuong.TenDoiTuong = "";
            _doituongList.Insert(0, _doiTuong);
            DoiTuongList_bindingSource1.DataSource = _doituongList;
        }
        private void GetDataNhanVien()
        {
            DoiTuongAllList _nhanvienList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien("",_maCongTy);
            DoiTuongAll _nhanVien = DoiTuongAll.NewDoiTuongAll("");
            _nhanVien.TenDoiTuong = "";
            _nhanvienList.Insert(0, _nhanVien);
            NhanVienList_bindingSource.DataSource = _nhanvienList;
        }

        private void getDataTaiKhoan()
        {
            _HeThongTaiKhoan1ListCo = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            tblTaiKhoanBindingSource_No.DataSource = _HeThongTaiKhoan1ListCo;
            _HeThongTaiKhoan1ListNo = _HeThongTaiKhoan1ListCo;
            tblTaiKhoanBindingSource_Co.DataSource = _HeThongTaiKhoan1ListNo;
        }

        private void GetDataloaiTien()
        {
            LoaiTienList _loaiTienList = LoaiTienList.GetLoaiTienList();
            LoaiTien_bindingSource.DataSource = _loaiTienList;
            grdLU_LoaiTien.EditValue = 1;
        }

        private void GetDataBoPhan() //Get Bo phan theo User
        {
            BoPhanList bophanlist = BoPhanList.GetBoPhanList();
            BoPhan bpEmpt = BoPhan.NewBoPhan("");
            bophanlist.Insert(0, bpEmpt);
            DonViList_bindingSource1.DataSource = bophanlist;
        }
        private void GetDataKhoanMuc()//
        {
            CauTrucDoanhThuChiPhiList khoanmuclist = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(_maCongTy);
            CauTrucDoanhThuChiPhi khoanmucE = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            khoanmucE.Ten = "";
            khoanmuclist.Insert(0, khoanmucE);
            CauTrucDoanhThuChiPhiList_bindingSource1.DataSource = khoanmuclist;
        }

        private void GetDataDoiTuongNoCo()
        { 
            DoiTuongAllList doituongNoCoList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0); //_factory.Context.sp_AllDoiTuong(1, 0).Where(x => x.MaCongTy == _maCongTy).ToList();//Lấy đối tác
            DoiTuongAll doituongNCEmpty = DoiTuongAll.NewDoiTuongAll("");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "" };
            doituongNoCoList.Insert(0, doituongNCEmpty);
            DoiTuongNoList_BindingSource.DataSource = doituongNoCoList;
            DoiTuongCoList_BindingSource.DataSource = doituongNoCoList;
        }

        private void DesignControl()
        {
            DesignLueHoatDong();
            DesignLueDoiTuong();
            DesignLueNhanVien();
        }

        private void GetData()
        {
            ChungTu_bindingSource.DataSource = _chungTu;
            GetDataHoatDong();
            GetDataDoiTuong();
            GetDataNhanVien();
            GetDataloaiTien();
            getDataTaiKhoan();
            GetDataKhoanMuc();
            GetDataBoPhan();
            GetDataDoiTuongNoCo();
        }

        private void DesignGrid()
        {
            gridControl1.DataSource = tblButToanBindingSource;
            HamDungChung.InitGridViewDev(gridView_ButToan, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView_ButToan, new string[] { "DienGiai", "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DoiTuongNo", "DoiTuongCo", "MaDonVi", "IDKhoanMuc", "MaHopDong" },
                                new string[] { "Nội dung", "Nợ Tài Khoản", "Có Tài Khoản", "Số Tiền", "Đối tượng nợ", "Đối tượng có", "Đơn vị", "Thuộc khoản mục", "Số hợp đồng" },
                                             //new int[] { 150, 80, 80, 90, 120, 120, 100, 100, 100 });
                                             new int[] { 500, 200, 200, 300, 300, 300, 150, 150, 100 });

            HamDungChung.AlignHeaderColumnGridViewDev(gridView_ButToan, new string[] { "DienGiai", "NoTaiKhoan", "CoTaiKhoan", "SoTien", "DoiTuongNo", "DoiTuongCo", "MaDonVi", "IDKhoanMuc", "MaHopDong" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(gridView_ButToan, NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(gridView_ButToan, 50);//M

            RepositoryItemGridLookUpEdit TaiKhoanCo_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanCo_GrdLU, tblTaiKhoanBindingSource_Co, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanCo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "CoTaiKhoan", TaiKhoanCo_GrdLU);

            RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanNo_GrdLU, tblTaiKhoanBindingSource_No, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "NoTaiKhoan", TaiKhoanNo_GrdLU);

            RepositoryItemGridLookUpEdit DoiTuongNo_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuongNo_grdLU, DoiTuongNoList_BindingSource, "TenDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "DoiTuongNo", DoiTuongNo_grdLU);

            RepositoryItemGridLookUpEdit DoiTuongCo_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuongCo_grdLU, DoiTuongCoList_BindingSource, "TenDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongCo_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "DoiTuongCo", DoiTuongCo_grdLU);

            RepositoryItemGridLookUpEdit HopDong_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(HopDong_GrdLU, HopDong_bindingSource, "SoHopDong", "MaHopDong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HopDong_GrdLU, new string[] { "SoHopDong", "TenHopDong" }, new string[] { "Số hợp đồng", "Nội dung" }, new int[] { 100, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaHopDong", HopDong_GrdLU);
            //
            //KhoanMucCol
            RepositoryItemGridLookUpEdit khoanMuc_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(khoanMuc_GrdLU, CauTrucDoanhThuChiPhiList_bindingSource1, "Ten", "Id", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(khoanMuc_GrdLU, new string[] { "Ten", "MaQL" }, new string[] { "Khoản mục", "Mã Ql" }, new int[] { 200, 100 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "IDKhoanMuc", khoanMuc_GrdLU);
            //
            //DonViCol
            //KhoanMucCol
            RepositoryItemGridLookUpEdit donVi_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(donVi_GrdLU, DonViList_bindingSource1, "TenBoPhan", "MaBoPhan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(donVi_GrdLU, new string[] { "TenBoPhan", "MaBoPhanQL" }, new string[] { "Đơn vị", "Mã đơn vị" }, new int[] { 200, 100 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView_ButToan, "MaDonVi", donVi_GrdLU);
            //
            RepositoryItemCalcEdit repositoryItemCalcEditSoTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();

            repositoryItemCalcEditSoTien.AutoHeight = false;
            repositoryItemCalcEditSoTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditSoTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditSoTien.Name = "repositoryItemCalcEditSoTien";
            gridView_ButToan.Columns["SoTien"].ColumnEdit = repositoryItemCalcEditSoTien;
            //
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView_ButToan, new string[] { "SoTien" }, "#,###.#");
            this.gridView_ButToan.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView_ButToan_InitNewRow);
            this.gridView_ButToan.KeyDown += gridView_ButToan_KeyDown;
            this.gridView_ButToan.RowCellClick += gridView_ButToan_RowCellClick;
            this.gridView_ButToan.CellValueChanged += gridView_ButToan_CellValueChanged;
            this.gridView_ButToan.FocusedRowChanged += gridView_ButToan_FocusedRowChanged;

        }

        void gridView_ButToan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView_ButToan.IsNewItemRow(e.FocusedRowHandle))
            {
                if (gridView_ButToan.GetRow(e.FocusedRowHandle) == null)
                    gridView_ButToan.AddNewRow();
                gridView_ButToan.FocusedColumn = gridView_ButToan.VisibleColumns[0];
            }
        }

        private void DeleteButToanList()
        {
            //if (KiemTraButToanThueTruocKhiXoaButToan() == false) return;
            if (gridView_ButToan.RowCount > 0)
            {
                if (gridView_ButToan.GetSelectedRows().Length > 0)
                {
                    if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView_ButToan.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        gridView_ButToan.DeleteSelectedRows();
                        TinhTien();
                    }
                }
            }
        }


        void gridView_ButToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteButToanList();
            }
        }

        void gridView_ButToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ButToan currentButToan = (ButToan)tblButToanBindingSource.Current;
            if (currentButToan != null && gridView_ButToan.FocusedColumn.Name == "colNoTaiKhoan" || gridView_ButToan.FocusedColumn.Name == "colCoTaiKhoan")
            {
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(currentButToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(currentButToan.CoTaiKhoan);

                #region Xu ly Doi Tuong No Co
                //No
                if (taiKhoanNo.MaTaiKhoan != 0)
                {
                    //currentButToan.DoiTuongNo = 0;
                    if (taiKhoanNo.CoDoiTuongTheoDoi == true && currentButToan.DoiTuongNo == 0)
                    {
                        if (_maDoiTuongDeNghi != 0)
                            currentButToan.DoiTuongNo = _maDoiTuongDeNghi;
                        else
                            currentButToan.DoiTuongNo = _chungTu.DoiTuong;
                    }


                }
                //Co
                if (taiKhoanCo.MaTaiKhoan != 0)
                {
                    //currentButToan.DoiTuongCo = 0;
                    if (taiKhoanCo.CoDoiTuongTheoDoi == true && currentButToan.DoiTuongCo == 0)
                    {
                        if (_maDoiTuongDeNghi != 0)
                            currentButToan.DoiTuongCo = _maDoiTuongDeNghi;
                        else
                            currentButToan.DoiTuongCo = _chungTu.DoiTuong;
                    }
                }
                #endregion//Xu ly Doi Tuong No Co
            }
            else if (currentButToan != null && gridView_ButToan.FocusedColumn.FieldName == "SoTien")
            {
                TinhTien();
            }
        }

        void gridView_ButToan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (gridView_ButToan.IsNewItemRow(e.RowHandle))
            {
                if (gridView_ButToan.GetRow(e.RowHandle) == null)
                    gridView_ButToan.AddNewRow();
                gridView_ButToan.FocusedColumn = gridView_ButToan.VisibleColumns[0];
            }
        }

        void FrmChungTuKetChuyen_Load(object sender, EventArgs e)
        {
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDevByMaQuanLy("PKC");
            dtmp_Ngay.DateTime = DateTime.Now;
            _chungTu.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(_LoaiChungTu.MaLoaiCT, _chungTu.NgayLap);
            tblButToanBindingSource.DataSource = _chungTu.DinhKhoan.ButToan;
            TienTe_bindingSource.DataSource = _chungTu.Tien;
            gridControl1.DataSource = tblButToanBindingSource;
            DesignControl();
            GetData();
            DesignGrid();
        }

        #region event btnSua
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.strStatus = "SUA";
            this.ReadOnlyConTrolByStatus(this.strStatus);
            HoatDong_gridLookUpEdit1.Focus();
        }
        public string strStatus = "";
        private void ReadOnlyConTrolByStatus(string _strStatus)
        {
            if (_strStatus == "" || _strStatus == "THEM" || _strStatus == "SUA")
            {
                gridView_ButToan.OptionsBehavior.Editable = true;
                tblButToanBindingSource.AllowNew = true;

             
                txt_TienBangChu.Properties.ReadOnly = false;

                foreach (Control c in ThongTinChunggroupControl2.Controls)
                {
                    if (c is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.GridLookUpEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.TextEdit)
                    {
                        ((DevExpress.XtraEditors.TextEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.DateEdit)
                    {
                        ((DevExpress.XtraEditors.DateEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.CalcEdit)
                    {
                        ((DevExpress.XtraEditors.CalcEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.MemoEdit)
                    {
                        ((DevExpress.XtraEditors.MemoEdit)c).Properties.ReadOnly = false;
                    }
                }

                foreach (Control c in ThongTinChungTugroupControl.Controls)
                {
                    if (c is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.GridLookUpEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.TextEdit)
                    {
                        ((DevExpress.XtraEditors.TextEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.DateEdit)
                    {
                        ((DevExpress.XtraEditors.DateEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.CalcEdit)
                    {
                        ((DevExpress.XtraEditors.CalcEdit)c).Properties.ReadOnly = false;
                    }
                    else if (c is DevExpress.XtraEditors.MemoEdit)
                    {
                        ((DevExpress.XtraEditors.MemoEdit)c).Properties.ReadOnly = false;
                    }
                }


                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else if (_strStatus == "KHOA")
            {
                gridView_ButToan.OptionsBehavior.Editable = false;
                tblButToanBindingSource.AllowNew = false;
                             
                txt_TienBangChu.Properties.ReadOnly = true;

                foreach (Control c in ThongTinChunggroupControl2.Controls)
                {
                    if (c is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.GridLookUpEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.TextEdit)
                    {
                        ((DevExpress.XtraEditors.TextEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.DateEdit)
                    {
                        ((DevExpress.XtraEditors.DateEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.CalcEdit)
                    {
                        ((DevExpress.XtraEditors.CalcEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.MemoEdit)
                    {
                        ((DevExpress.XtraEditors.MemoEdit)c).Properties.ReadOnly = true;
                    }
                }

                foreach (Control c in ThongTinChungTugroupControl.Controls)
                {
                    if (c is DevExpress.XtraEditors.GridLookUpEdit)
                    {
                        ((DevExpress.XtraEditors.GridLookUpEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.TextEdit)
                    {
                        ((DevExpress.XtraEditors.TextEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.DateEdit)
                    {
                        ((DevExpress.XtraEditors.DateEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.CalcEdit)
                    {
                        ((DevExpress.XtraEditors.CalcEdit)c).Properties.ReadOnly = true;
                    }
                    else if (c is DevExpress.XtraEditors.MemoEdit)
                    {
                        ((DevExpress.XtraEditors.MemoEdit)c).Properties.ReadOnly = true;
                    }
                }

                btnSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }
        #endregion

        private void FrmChungTuKetChuyen_Load_1(object sender, EventArgs e)
        {
            this.ReadOnlyConTrolByStatus(this.strStatus);
        }
       
    }
}