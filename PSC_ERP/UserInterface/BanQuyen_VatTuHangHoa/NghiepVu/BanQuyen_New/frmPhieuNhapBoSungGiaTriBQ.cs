using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using System.IO;
//27_06_2014
namespace PSC_ERP
{
    public partial class frmPhieuNhapBoSungGiaTriBQ : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        PhieuNhapXuatBQ _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat();
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        NguonList _nguonList;//M
        KhoBQ_VTList _khoBQ_VTList = KhoBQ_VTList.NewKhoBQ_VTList();
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        ChungTu_HoaDonBQList _chungTu_HoaDonList = ChungTu_HoaDonBQList.NewChungTu_HoaDonList();
        bool _lockHopDong = false;
        //Add to 11012013
        DateTime _ngayLapCu;
        int _maKhoCu;
        int _maBoPhanCu;
        //End Add to 11012013

        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet = new DataSet();
        DataView clone = null;//--
        int _hoanTat = -1;
        int _maCongTyCurrent = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        #endregion //Properties

        public frmPhieuNhapBoSungGiaTriBQ()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
            grdViewCt_PhieuNhap.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            grdViewCt_PhieuNhap.FocusedRowHandle = grdViewCt_PhieuNhap.RowCount - 1;
            grdViewCt_PhieuNhap.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
        }

        #region frmPhieuNhapBoSungGiaTriBQ(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuNhapBoSungGiaTriBQ(PhieuNhapXuatBQ phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }
        #endregion

        #region Function
        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _chungTu_HoaDonList = ChungTu_HoaDonBQList.NewChungTu_HoaDonList();
            _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat();
            _phieuNhapXuat.Loai = 4;
            _phieuNhapXuat.LaNhap = true;
            _phieuNhapXuat.SoPhieu = PhieuNhapXuatBQ.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;

            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;

            if (_khoBQ_VTList.Count != 0)
                _phieuNhapXuat.MaKho = _khoBQ_VTList[0].MaKho;
            if (_boPhanList.Count != 0)
                _phieuNhapXuat.MaPhongBan = _boPhanList[0].MaBoPhan;
            //M
            CheckPhieuNhap();
        }
        #endregion

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuatBQ phieuNhapXuat)
        {
            _phieuNhapXuat = phieuNhapXuat;
            cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            _phieuNhapXuat.LaNhap = true;
            btnSaoChepChungTu.Enabled = false;//M
            //Add to 11012013
            _ngayLapCu = _phieuNhapXuat.NgayNX;
            _maKhoCu = _phieuNhapXuat.MaKho;
            _maBoPhanCu = _phieuNhapXuat.MaPhongBan;
            int flag = 0;
            //End Add to 11012013
            foreach (ButToanPhieuNhapXuatBQ _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanNo.SoHieuTK.Contains("3113") || taiKhoanNo.SoHieuTK.Contains("3337"))
                {
                    foreach (ChungTu_HoaDonBQ ct_hd in _butToan.ChungTu_HoaDonList)
                        _chungTu_HoaDonList.Add(ChungTu_HoaDonBQ.NewChungTu_HoaDon(ct_hd));
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                foreach (HoaDon_NhapXuat hoaDon_NhapXuat in _phieuNhapXuat.HoaDon_NhapXuatList)
                {
                    ChungTu_HoaDonBQList ct_hd = ChungTu_HoaDonBQList.GetChungTu_HoaDonByMaHoaDonList(hoaDon_NhapXuat.MaHoaDon);
                    if (ct_hd.Count == 0)
                    {
                        HoaDon hoaDon = HoaDon.GetHoaDon(hoaDon_NhapXuat.MaHoaDon);
                        _chungTu_HoaDonList.Add(ChungTu_HoaDonBQ.NewChungTu_HoaDon(hoaDon));
                    }
                }
            }

        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            boPhanListBindingSource.DataSource = _boPhanList;
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(1);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;

            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            _nguonList = NguonList.GetNguonList();//M
            Nguon _nguon = Nguon.NewNguon("Không Chọn");//M
            _nguonList.Insert(0, _nguon);//M
            NguonList_bindingSource.DataSource = _nguonList;//M
            Init_lookUpEdit_PhongBan();

            ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewList_BQ(_hoanTat, _maCongTyCurrent);
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewList.Insert(0, ct0);
            chuongTrinh_NewListBindingSource.DataSource = _chuongTrinh_NewList;
            ChuongTrinh_NewList _chuongTrinh_NewList1 = ChuongTrinh_NewList.GetChuongTrinh_NewListAll(_hoanTat, _maCongTyCurrent);
            chuongTrinh_NewListbindingSource1.DataSource = _chuongTrinh_NewList1;

        }
        #endregion

        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuNhapBQ ct_phieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
            {
                if (ct_phieuNhap.MaChuongTrinh == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập Tên Chương trình chính cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            return kq;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = false;
            if (_phieuNhapXuat.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn đối tác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_DoiTac.Focus();
            }
            else if (_phieuNhapXuat.MaPhongBan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_PhongBan.Focus();
            }
            else if (_phieuNhapXuat.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoNhan.Focus();
            }
            else if (_phieuNhapXuat.CT_PhieuNhapList.Count == 0)
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (KiemTraChiTiet() == false)
                grdCT_PhieuNhap.Focus();
            else if (KiemTraButToanHoaDon() == false)
            {
                kq = false;
            }
            else kq = true;
            return kq;
        }

        private bool KiemTraButToanHoaDon()
        {
            TuDongCapNhatCPSXButToanTheoCT_PhieuXuat();
            foreach (ButToanPhieuNhapXuatBQ butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                string noTK = taiKhoanNo.SoHieuTK;
                string CoTK = taiKhoanCo.SoHieuTK;
                #region Kiểm tra  hóa đơn
                if (taiKhoanCo.SoHieuTK.Contains("3113") || taiKhoanCo.SoHieuTK.Contains("3337") || taiKhoanNo.SoHieuTK.Contains("3113") || taiKhoanNo.SoHieuTK.Contains("3337"))
                {
                    if (butToan.ChungTu_HoaDonList.Count == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn hóa đơn cho bút toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        decimal tongTienHoaDon = 0;
                        foreach (ChungTu_HoaDonBQ ct_hd in butToan.ChungTu_HoaDonList)
                        {
                            tongTienHoaDon += ct_hd.SoTien;
                        }
                        if (tongTienHoaDon != butToan.SoTien)
                        {
                            MessageBox.Show(this, "Gía trị hạch toán tài khoản thuế không bằng tổng giá trị các hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                #endregion//Kiểm tra  hóa đơn

                #region Kiểm Tra chi phí sản xuất

                if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.Contains("631") || noTK.Contains("4314"))
                {
                    if (butToan.ChungTu_ChiPhiSanXuatList.Count == 0)
                    {
                        MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        foreach (ChungTu_ChiPhiSanXuat cp in butToan.ChungTu_ChiPhiSanXuatList)
                        {
                            if (cp.ButtoanMucNganSachList.Count == 0 && (noTK.Contains("631") || noTK.Contains("4314")))
                            {
                                MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

                if (butToan.ChungTu_ChiPhiSanXuatList.Count > 0)
                {

                    decimal sotienCTu = 0;
                    foreach (ChungTu_ChiPhiSanXuat ct_cp in butToan.ChungTu_ChiPhiSanXuatList)
                    {
                        sotienCTu += ct_cp.SoTien;
                    }
                    if (butToan.SoTien != sotienCTu)
                    {
                        MessageBox.Show(this, "Tổng số tiền Công việc/Chương trình không bằng số tiền bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; ;
                    }
                }
                #endregion

                #region Kiểm Tra đối tượng theo dõi
                if (taiKhoanNo.CoDoiTuongTheoDoi == true)
                {
                    if (butToan.MaDoiTuongNo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng nợ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (taiKhoanCo.CoDoiTuongTheoDoi == true)
                {
                    if (butToan.MaDoiTuongCo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng Có ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                #endregion//Kiểm Tra đối tượng theo dõi

            }
            return true;
        }

        void formatGriview()
        {
            this.grdViewCt_PhieuNhap.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }
        private void LockData()
        {
            //grdViewCt_PhieuNhap.OptionsBehavior.Editable = false;
            grdViewCt_PhieuNhap.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["MaChuongTrinhCha"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["MaChuongTrinh"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["MaNguon"].OptionsColumn.AllowEdit = false;
            _lockHopDong = true;
            gridLookUpEdit_KhoNhan.Properties.ReadOnly = true;
            lookUpEdit_PPNXKho.Properties.ReadOnly = true;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }
        void UnLockData()
        {
            //grdViewCt_PhieuNhap.OptionsBehavior.Editable = true;
            grdViewCt_PhieuNhap.Columns["SoLuong"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["DonGia"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["MaChuongTrinhCha"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["MaChuongTrinh"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["MaNguon"].OptionsColumn.AllowEdit = true;
            _lockHopDong = false;
            gridLookUpEdit_KhoNhan.Properties.ReadOnly = false;
            lookUpEdit_PPNXKho.Properties.ReadOnly = false;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        void AllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        void NotAllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        void CheckPhieuNhap()
        {
            if (_phieuNhapXuat != null)
                if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(_phieuNhapXuat.MaPhieuNhapXuat))
                {
                    //grdViewCt_PhieuNhap.OptionsBehavior.Editable = false;
                    LockData();
                    NotAllowDelete();
                }
                else
                {
                    //grdViewCt_PhieuNhap.OptionsBehavior.Editable = true;
                    UnLockData();
                    AllowDelete();
                }
        }

        private bool KiemTraSoTienTK152_ctPhieu()
        {
            decimal tongTienButToan = 0;
            bool coTK1552 = false;
            if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count > 0)
            {
                //
                foreach (ButToanPhieuNhapXuatBQ bt in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                {
                    if (bt.SoHieuTaiKhoanNo.Length >= 4)
                    {
                        if (bt.SoHieuTaiKhoanNo.Substring(0, 4) == "1552")
                        {
                            tongTienButToan += bt.SoTien;
                            coTK1552 = true;
                        }
                    }
                }
                if (coTK1552 && tongTienButToan != _phieuNhapXuat.GiaTriKho)
                {
                    MessageBox.Show("Số tiền bút toán Nợ TK 1552 và Giá trị phiếu nhập không bằng nhau. Vui lòng kiểm tra lại! ");
                    return false;
                }
                //
            }
            return true;
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

        private bool DaKetChuyen()
        {
            bool daKC = false;
            daKC = KetChuyenTonKhoBanQuyenBQ.KiemTraKetChuyenBanQuyen_PhucVuNXvaHuyKetChuyen(_phieuNhapXuat.NgayNX, _phieuNhapXuat.MaKho, _phieuNhapXuat.MaPhongBan);

            if (daKC == false && _phieuNhapXuat.IsNew == false)
            {
                daKC = KetChuyenTonKhoBanQuyenBQ.KiemTraKetChuyenBanQuyen_PhucVuNXvaHuyKetChuyen(_ngayLapCu, _maKhoCu, _maBoPhanCu);
            }

            if (daKC)
            {
                MessageBox.Show("Kỳ này đã kết chuyển, không thể cập nhật phiếu nhập!");
            }
            return daKC;
        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void Show_colMaDoiTuongNo()
        {
            this.colMaDoiTuongNo.Visible = true;
            this.colMaDoiTuongNo.VisibleIndex = 3;
            this.colMaDoiTuongNo.Width = 190;
        }

        private void DuyetButToanToShowDoiTuong_ButToan()
        {
            foreach (ButToanPhieuNhapXuatBQ _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 httkNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (httkNo.CoDoiTuongTheoDoi)
                {
                    Show_colMaDoiTuongNo();
                    break;

                }
            }
        }

        private void CheckShow_colMaDoiTuongNo_LoadPhieu()
        {
            if (!_phieuNhapXuat.IsNew)
            {
                if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count > 0)
                {
                    DuyetButToanToShowDoiTuong_ButToan();
                }
            }
        }

        private void CheckHideShowDoiTuong_ButToan()
        {
            ButToanPhieuNhapXuatBQ _butToan = ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current);
            HeThongTaiKhoan1 httkNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
            if (httkNo.CoDoiTuongTheoDoi)
            {
                Show_colMaDoiTuongNo();
                //((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = _phieuNhapXuat.MaDoiTac;

            }
            else
            {
                this.colMaDoiTuongNo.Visible = false;
                ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = 0;
                DuyetButToanToShowDoiTuong_ButToan();
            }
        }

        private decimal TongTienTheoChuongTrinhPhieu(int maChuongTrinh)
        {
            decimal tongtien = 0;
            foreach (CT_PhieuNhapBQ ct in _phieuNhapXuat.CT_PhieuNhapList)
            {
                if (ct.MaChuongTrinh == maChuongTrinh)
                {
                    tongtien += ct.ThanhTien;
                }
            }
            return tongtien;

        }

        private bool TaiKhoanButToanThuocCPSX(ButToanPhieuNhapXuatBQ bt)
        {
            if (bt.SoHieuTaiKhoanNo.StartsWith("1551") || bt.SoHieuTaiKhoanNo.StartsWith("1552") || bt.SoHieuTaiKhoanCo.StartsWith("1551") || bt.SoHieuTaiKhoanCo.StartsWith("1552") || bt.SoHieuTaiKhoanNo.StartsWith("631") || bt.SoHieuTaiKhoanNo.StartsWith("4314"))
            {
                return true;
            }
            return false;
        }

        private void TuDongCapNhatCPSXButToanTheoCT_PhieuXuat()
        {
            foreach (ButToanPhieuNhapXuatBQ buttoan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                CT_PhieuNhapBQList list = _phieuNhapXuat.CT_PhieuNhapList;
                if (TaiKhoanButToanThuocCPSX(buttoan))
                {
                    if (buttoan.ChungTu_ChiPhiSanXuatList.Count == 0)
                    {
                        foreach (CT_PhieuNhapBQ ct in list)
                        {
                            Boolean chuaCo = true;
                            foreach (ChungTu_ChiPhiSanXuat ct_CPSX in buttoan.ChungTu_ChiPhiSanXuatList)
                            {
                                if (ct.MaChuongTrinh == ct_CPSX.MaChuongTrinh)
                                {
                                    chuaCo = false;
                                    break;
                                }
                            }
                            if (chuaCo)
                            {
                                decimal thanhtien = TongTienTheoChuongTrinhPhieu(ct.MaChuongTrinh);
                                ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat = new ChungTu_ChiPhiSanXuat(ct.MaChuongTrinh, thanhtien);
                                buttoan.ChungTu_ChiPhiSanXuatList.Add(chungTu_ChiPhiSanXuat);
                            }
                        }
                    }
                }
            }
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;

        }

        #endregion //Function

        #region Event

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
            _phieuNhapXuat.MaPhongBan = (int)lookUpEdit_PhongBan.EditValue;
        }
        #endregion

        private void Init_lookUpEdit_PhongBan()
        {
            DataTable _dataTable = new DataTable();

            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(1, "Bình Quân");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");

            phuongPhapNXbindingSource.DataSource = _dataTable;
            lookUpEdit_PPNXKho.Properties.DataSource = phuongPhapNXbindingSource;
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.Properties.NullText = "Không Chọn";
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();
            textEdit_Focus1.Focus();

            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!DaKetChuyen())
            {
                //Xu ly Luu Phieu
                //End Add to 11012013
                if (txt_SoPhieu.EditValue != null)//IF 1
                {
                    string _soPhieu = txt_SoPhieu.EditValue.ToString();
                    int _stt;
                    if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                    {
                        bool ktphieutrung = true;
                        if (_phieuNhapXuat.IsNew)
                        {
                            ktphieutrung = PhieuNhapXuatBQ.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, true);

                        }
                        else//k phai IS NEW
                        {
                            ktphieutrung = PhieuNhapXuatBQ.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, false);
                        }

                        if (ktphieutrung)//IF 5
                        {
                            //GH
                            try
                            {
                                phieuNhapXuatBindingSource.EndEdit();
                                if (KiemTraDuLieu() && KiemTraSoTienTK152_ctPhieu())
                                {
                                    _phieuNhapXuat.ApplyEdit();
                                    _phieuNhapXuat.Save();
                                    //Add to 11012013
                                    _ngayLapCu = _phieuNhapXuat.NgayNX;
                                    _maKhoCu = _phieuNhapXuat.MaKho;
                                    _maBoPhanCu = _phieuNhapXuat.MaPhongBan;
                                    //End Add to 11012013
                                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //
                        }//END IF 5
                        else
                        {
                            MessageBox.Show("Trùng Số Phiếu! Không Thể Lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_SoPhieu.Focus();
                        }
                    }//END IF 2
                    else
                    {
                        MessageBox.Show("Số Phiếu Không Hợp Lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_SoPhieu.Focus();
                    }

                }//END IF 1
                //Xu ly Luu Phieu
            }

        }

        #region lookUpEdit_PPNXKho_EditValueChanged
        private void lookUpEdit_PPNXKho_EditValueChanged(object sender, EventArgs e)
        {
            if ((byte)(lookUpEdit_PPNXKho.EditValue) == 1)
            {
                barBt_LapPhieuXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
                barBt_LapPhieuXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            _phieuNhapXuat.PhuongPhapNX = (Byte)lookUpEdit_PPNXKho.EditValue;

        }
        #endregion

        #region grdViewCt_PhieuNhap_CellValueChanged
        private void grdViewCt_PhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CT_PhieuNhapBQ _ct_PhieuNhap = (CT_PhieuNhapBQ)cTPhieuNhapListBindingSource.Current;
            if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colThanhTien" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong")
            {
                if (_ct_PhieuNhap.SoLuong != 0)//Thay doi Don Gia
                {
                    _ct_PhieuNhap.DonGia = Math.Round(_ct_PhieuNhap.ThanhTien / _ct_PhieuNhap.SoLuong, 0, MidpointRounding.AwayFromZero);
                }
                //Tinh Lai Tong Tien
                Decimal tongTien = 0;
                foreach (CT_PhieuNhapBQ ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
                {
                    tongTien = tongTien + ct_PhieuNhap.ThanhTien;
                }
                _phieuNhapXuat.GiaTriKho = tongTien;//Thay doi Gia Tri Kho
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa")
            {
                _ct_PhieuNhap.MaChuongTrinh = 0;
                grdViewCt_PhieuNhap.RefreshData();
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaChuongTrinhCon")
            {
                ChuongTrinh_New chuongTrinh = ChuongTrinh_New.GetChuongTrinh_New(_ct_PhieuNhap.MaChuongTrinh);
                int maCtCha = chuongTrinh.MaChuongTrinhCha;
                if (maCtCha != 0)
                {
                    _ct_PhieuNhap.MaChuongTrinhCha = maCtCha;
                }
                else
                {
                    _ct_PhieuNhap.MaChuongTrinhCha = _ct_PhieuNhap.MaChuongTrinh;
                }
                _ct_PhieuNhap.MaDonViTinh = chuongTrinh.MaDonViTinh;
                _ct_PhieuNhap.ThoiLuong = chuongTrinh.ThoiLuong;
            }

        }
        #endregion

        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool khoaso = KhoaSo();
            phieuNhapXuatBindingSource.EndEdit();
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.HoaDon_NhapXuatList.Count == 0)
            {
                frmChonHoaDonLapPhieuBQ frm = new frmChonHoaDonLapPhieuBQ(_phieuNhapXuat.MaDoiTac, _phieuNhapXuat.Loai, khoaso);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
                        foreach (ButToanPhieuNhapXuatBQ _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                        {
                            HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                            HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);

                            if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanNo.SoHieuTK.Contains("3113") || taiKhoanNo.SoHieuTK.Contains("3337"))
                            {
                                _butToan.ChungTu_HoaDonList.Clear();
                                foreach (ChungTu_HoaDonBQ ct_hd in _chungTu_HoaDonList)
                                    _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDonBQ.NewChungTu_HoaDon(ct_hd));

                            }
                        }
                    }
                }
            }
            else
            {
                frmChonHoaDonLapPhieuBQ frm = new frmChonHoaDonLapPhieuBQ(_phieuNhapXuat, khoaso);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
                        foreach (ButToanPhieuNhapXuatBQ _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                        {
                            HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                            HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                            if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanNo.SoHieuTK.Contains("3113") || taiKhoanNo.SoHieuTK.Contains("3337"))
                            {
                                _butToan.ChungTu_HoaDonList.Clear();
                                foreach (ChungTu_HoaDonBQ ct_hd in _chungTu_HoaDonList)
                                    _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDonBQ.NewChungTu_HoaDon(ct_hd));

                            }
                        }
                        _phieuNhapXuat.ApplyEdit();
                        _phieuNhapXuat.Save();
                    }
                }
            }
        }
        #endregion

        private void btnSaoChepChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew)
            {
                frmDSPhieuNhapXuatBanQuyenBQ frm = new frmDSPhieuNhapXuatBanQuyenBQ(4, true);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat(frm.PhieuNhapXuat, dateEdit_NgayLap.DateTime);
                    foreach (CT_PhieuNhapBQ ct in _phieuNhapXuat.CT_PhieuNhapList)
                    {
                        ct.DonGia = 0;
                        ct.SoLuong = 0;
                    }
                    //
                    _phieuNhapXuat.Loai = 4;
                    _phieuNhapXuat.LaNhap = true;
                    _phieuNhapXuat.SoPhieu = PhieuNhapXuatBQ.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
                    cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
                    butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;

                    _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
                    phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
                }
            }
            else
            {
                MessageBox.Show("Phiếu đã lập, không thể Copy!", "Thông Báo");
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UnLockData();
            AllowDelete();
            KhoiTaoPhieu();
            btnSaoChepChungTu.Enabled = true;
        }

        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            // Gan tien cho but toan
            ButToanPhieuNhapXuatBQ butToan = (ButToanPhieuNhapXuatBQ)(butToanPhieuNhapXuatListBindingSource.Current);
            decimal soTienConLai = _phieuNhapXuat.GiaTriKho;
            foreach (ButToanPhieuNhapXuatBQ buttoanphieu in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                soTienConLai = soTienConLai - buttoanphieu.SoTien;
            }
            butToan.SoTien = soTienConLai;
            butToan.MaDoiTuongCo = _phieuNhapXuat.MaDoiTac;
            butToan.DienGiai = _phieuNhapXuat.DienGiai;//M Gan Dien Giai cua Phieu Xuat cho ButToan
        }

        private void grdViewCt_PhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    grdViewCt_PhieuNhap.DeleteSelectedRows();

            //}
            //
            HamDungChung.CopyCell(grdViewCt_PhieuNhap, e);
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    foreach (int i in grdView_DinhKhoan.GetSelectedRows())
            //    {
            //        grdView_DinhKhoan.DeleteRow(i);
            //    }
            //}
            //
            HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }

        #region barBt_LapPhieuXuat_ItemClick
        private void barBt_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew)
            {
                MessageBox.Show("Vui Lòng Cập Nhật Phiếu Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                long giaTri = PhieuNhapXuatBQ.KiemTraPhieu(_phieuNhapXuat.MaPhieuNhapXuat);
                if (giaTri != 0)
                {
                    PhieuNhapXuatBQ phieuNhapXuat = PhieuNhapXuatBQ.GetPhieuNhapXuat(giaTri);
                    frmPhieuXuatBoSungGiaTriBQ frm = new frmPhieuXuatBoSungGiaTriBQ(phieuNhapXuat, 1, true);
                    //frm.ShowDialog();//(1)
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        CheckPhieuNhap();
                    }//replace (1)
                }
                else
                {
                    frmPhieuXuatBoSungGiaTriBQ frm = new frmPhieuXuatBoSungGiaTriBQ(_phieuNhapXuat, 2, true);
                    //frm.ShowDialog();//(1)
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        CheckPhieuNhap();
                    }//replace (1)
                }
            }
        }
        #endregion

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_PhieuNhapBanQuyen_BQ");
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
            //END
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                grdViewCt_PhieuNhap.DeleteSelectedRows();//Xoa nhieu dong
                Decimal tongTien = 0;
                foreach (CT_PhieuNhapBQ ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
                {
                    tongTien = tongTien + ct_PhieuNhap.ThanhTien;
                }
                _phieuNhapXuat.GiaTriKho = tongTien;//Thay doi Gia Tri Kho

            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
                grdView_DinhKhoan.DeleteSelectedRows();
        }

        private void btn_HopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.NhapXuat_HopDongList.Count == 0)
            {
                int maPhanLoaiHD = PhanLoaiHopDong.GetPhanLoaiHopDongByMaQL("BQ").MaPhanLoaiHD;
                frmChonHopDongLapPhieuBQ frm = new frmChonHopDongLapPhieuBQ(_phieuNhapXuat.MaDoiTac, _lockHopDong,maPhanLoaiHD);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.NhapXuat_HopDongList = frm.NhapXuat_HopDongList;
                        if (_phieuNhapXuat.MaDoiTac == 0)
                        {
                            _phieuNhapXuat.MaDoiTac = frm.MaDoiTac;
                        }
                    }
                }
            }
            else
            {
                frmChonHopDongLapPhieuBQ frm = new frmChonHopDongLapPhieuBQ(_phieuNhapXuat, _lockHopDong);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.NhapXuat_HopDongList = frm.NhapXuat_HopDongList;
                        _phieuNhapXuat.ApplyEdit();
                        _phieuNhapXuat.Save();
                    }
                }
            }
        }

        private void gridLookUpEdit_KhoNhan_EditValueChanged(object sender, EventArgs e)
        {
            _phieuNhapXuat.MaKho = (int)gridLookUpEdit_KhoNhan.EditValue;
        }

        private void lookUpEdit_DoiTac_EditValueChanged(object sender, EventArgs e)
        {
            _phieuNhapXuat.MaDoiTac = (long)lookUpEdit_DoiTac.EditValue;
        }

        private void grdViewCt_PhieuNhap_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuNhapBQ _ct_PhieuNhap = (CT_PhieuNhapBQ)cTPhieuNhapListBindingSource.Current;
            _ct_PhieuNhap.DienGiai = _phieuNhapXuat.DienGiai;
        }

        private void txt_SoCTKemTheo_EditValueChanged(object sender, EventArgs e)
        {
            _phieuNhapXuat.SoCTKemTheo = (int)txt_SoCTKemTheo.EditValue;
        }

        private void textEdit_DienGiai_EditValueChanged(object sender, EventArgs e)
        {
            _phieuNhapXuat.DienGiai = (string)textEdit_DienGiai.EditValue;
        }

        private void frmPhieuNhapBanQuyen_Load(object sender, EventArgs e)
        {
            formatGriview();
            CheckPhieuNhap();
            CheckShow_colMaDoiTuongNo_LoadPhieu();
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuNhap, 35);

            
            grdView_DinhKhoan.OptionsView.ShowFooter = true;
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdView_DinhKhoan, new string[] { "SoTien" }, "{0:#,###.##}");

        }

        private void GridLookUpEdit_ChuongTrinhBanQuyenConList_Popup(object sender, EventArgs e)
        {
            if (cTPhieuNhapListBindingSource.Current != null && grdViewCt_PhieuNhap.GetFocusedRow() != null)
            {
                CT_PhieuNhapBQ ctpn = cTPhieuNhapListBindingSource.Current as CT_PhieuNhapBQ;
                if (ctpn.MaHangHoa != 0)
                {
                    GridLookUpEdit grid = (GridLookUpEdit)sender;
                    if (grid != null)
                    {
                        grid.Properties.View.ActiveFilterString = "MaHangHoa=" + ctpn.MaHangHoa.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập vào tên chương trình cha");
                    return;
                }
            }
        }

        private void grdView_DinhKhoan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            ButToanPhieuNhapXuatBQ _butToan = ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current);

            if (grdView_DinhKhoan.FocusedColumn.Name == "colNoTaiKhoan" || grdView_DinhKhoan.FocusedColumn.Name == "colCoTaiKhoan")
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                HeThongTaiKhoan1 tk1 = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                _butToan.ChungTu_HoaDonList.Clear();
                if (tk.SoHieuTK.Contains("3113") || tk.SoHieuTK.Contains("3337") || tk1.SoHieuTK.Contains("3113") || tk1.SoHieuTK.Contains("3337"))
                {
                    foreach (ChungTu_HoaDonBQ ct_hd in _chungTu_HoaDonList)
                        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDonBQ.NewChungTu_HoaDon(ct_hd));
                }
                CheckHideShowDoiTuong_ButToan();

            }
        }

        private void grdView_DinhKhoan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colHoaDon")
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).CoTaiKhoan);
                HeThongTaiKhoan1 tk1 = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                if (tk.SoHieuTK.Contains("3113") || tk.SoHieuTK.Contains("3337") || tk1.SoHieuTK.Contains("3113") || tk1.SoHieuTK.Contains("3337"))
                {
                    frmDanhSachHoaDonDichVuPhieuXuatBQ _frm = new frmDanhSachHoaDonDichVuPhieuXuatBQ(_phieuNhapXuat, _chungTu_HoaDonList, (ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current);
                    _frm.Show();
                }
            }
            #region NEw
            if (grdView_DinhKhoan.FocusedColumn.Name == "col_btn")
            {
                TuDongCapNhatCPSXButToanTheoCT_PhieuXuat();
                if (((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current) != null)
                {
                    //Xu ly Tai day
                    ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).BeginEdit();
                    ButToanPhieuNhapXuatBQ bt = (ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current;
                    ChungTu_ChiPhiSanXuatList cpList = ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList;
                    cpList.BeginEdit();
                    frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuNhapXuat.NgayNX, bt.DienGiai, bt.MaButToan);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        if (f.IsSave == true)
                        {
                            ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList = f._ChungTu_ChiPhiSXList;
                            ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList.ApplyEdit();

                        }
                        else
                        {
                            cpList.CancelEdit();
                        }
                    }
                    //
                }
            }
            #endregion
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                AllowDelete();
            }
            else if (PhieuNhapXuatBQ.KiemTraPhieuNhapDaXuatThang(_phieuNhapXuat.MaPhieuNhapXuat))
            {
                NotAllowDelete();
            }
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuatBQ pnx = _phieuNhapXuat;
            if (pnx != null)
            {

                if (KhoaSo())
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DaKetChuyen())
                {
                    return;
                }

                if (pnx.XacNhan == true)//Kiem Tra Thu Kho Xac Nhan
                {
                    MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //
                if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(pnx.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
                {
                    MessageBox.Show("Phiếu Nhập đã Xuất!\n Vui lòng xóa Phiếu Xuất trước khi xóa Phiếu Nhập!");
                    return;
                }
                //Delete Phieu
                if (MessageBox.Show(this, "Bạn muốn xóa Phiếu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        PhieuNhapXuatBQ.DeletePhieuNhapXuat(_phieuNhapXuat);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThemMoi.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }//End Delete Phieu
            }
            //E
        }

        private void btn_XuatraExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                grdViewCt_PhieuNhap.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }
        }

        private void GridLookUpEdit_ChuongTrinhCon_Popup(object sender, EventArgs e)
        {
            if (cTPhieuNhapListBindingSource.Current != null && grdViewCt_PhieuNhap.GetFocusedRow() != null)
            {
                CT_PhieuNhapBQ ctpn = cTPhieuNhapListBindingSource.Current as CT_PhieuNhapBQ;
                if (ctpn.MaChuongTrinhCha != 0)
                {
                    GridLookUpEdit grid = (GridLookUpEdit)sender;
                    if (grid != null)
                    {
                        grid.Properties.View.ActiveFilterString = "MaChuongTrinhCha=" + ctpn.MaChuongTrinhCha.ToString() + "or MaChuongTrinh=" + ctpn.MaChuongTrinhCha.ToString();
                    }
                }
                //else
                //{
                //    MessageBox.Show("Nhập vào tên chương trình cha");
                //    return;
                //}
            }
        }
        #endregion Event

        #region Cac Phuong Thuc Report
        public void Spd_PhieuNhapBanQuyen()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuNhapBanQuyen_BQ";
                    cm.Parameters.AddWithValue("@MaPhieuNhap", _phieuNhapXuat.MaPhieuNhapXuat);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuNhapBanQuyen;1";
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
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }//END Spd_PhieuNhapBanQuyen

        #endregion//Cac Phuong Thuc Report






    }
}