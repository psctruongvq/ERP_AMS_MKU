using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Data.SqlClient;

//9_07_2014
namespace PSC_ERP
{
    public partial class frmPhieuNhapVatTuHangHoa : DevExpress.XtraEditors.XtraForm
    {

        PhieuNhapXuat _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        KhoBQ_VTList _khoBQ_VTList = KhoBQ_VTList.NewKhoBQ_VTList();
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        ChungTu_HoaDonList _chungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        //Add to 11012013
        DateTime _ngayLapCu;
        int _maKhoCu;
        //End Add to 11012013
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        //

        public frmPhieuNhapVatTuHangHoa()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
        }

        #region frmPhieuNhapVatTuHangHoa(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuNhapVatTuHangHoa(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }
        #endregion
        #region DamBao
        private bool KiemTraPhanHeCua2014()
        {
            if (_phieuNhapXuat != null)
            {
                if (_phieuNhapXuat.NgayNX.Year >= 2014)
                {
                    MessageBox.Show("Vui lòng nhập phiếu vào phân hệ 2014!");
                    return true;
                    this.Close();
                }
            }
            return false;
        }
        #endregion

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuNhapXuat.Loai = 2;
            cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            _phieuNhapXuat.LaNhap = true;
            _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            if (_khoBQ_VTList.Count != 0)
                _phieuNhapXuat.MaKho = _khoBQ_VTList[0].MaKho;
            if (_boPhanList.Count != 0)
                _phieuNhapXuat.MaPhongBan = _boPhanList[0].MaBoPhan;
            //
            CheckPhieuNhap();

        }
        #endregion

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            _phieuNhapXuat = phieuNhapXuat;
            cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            _phieuNhapXuat.LaNhap = true;
            //Add to 11012013
            _ngayLapCu = _phieuNhapXuat.NgayNX;
            _maKhoCu = _phieuNhapXuat.MaKho;
            //End Add to 11012013
            int flag = 0;

            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (taiKhoan.SoHieuTK.Contains("3113"))
                {
                    foreach (ChungTu_HoaDon ct_hd in _butToan.ChungTu_HoaDonList)
                        _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                foreach (HoaDon_NhapXuat hoaDon_NhapXuat in _phieuNhapXuat.HoaDon_NhapXuatList)
                {
                    ChungTu_HoaDonList ct_hd = ChungTu_HoaDonList.GetChungTu_HoaDonByMaHoaDonList(hoaDon_NhapXuat.MaHoaDon);
                    if (ct_hd.Count == 0)
                    {
                        HoaDon hoaDon = HoaDon.GetHoaDon(hoaDon_NhapXuat.MaHoaDon);
                        _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(hoaDon));
                    }
                }
            }
        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            //PhieuNhapXuatList_bindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            //heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();

            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            _boPhanList = BoPhanList.GetBoPhanList();
            boPhanListBindingSource.DataSource = _boPhanList;
            _khoBQ_VTList = KhoBQ_VTList.GetKhoVatTuList();
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;

            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            Init_lookUpEdit_PhongBan();

        }
        #endregion

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
            {
                //ThongTinNhanVienTongHop nv = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<Không Chọn>");
                //ThongTinNhanVienTongHopList nvlist = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
                //nvlist.Insert(0, nv);
                //thongTinNhanVienTongHopListBindingSource.DataSource = nvlist;
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
            }
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

        private bool KiemTraChiTiet()
        {
            foreach (CT_PhieuNhap ct_phieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
            {
                if (ct_phieuNhap.MaHangHoa == 0)
                {
                    MessageBox.Show(this, "Vui lòng nhập Tên Vật tư - Hàng hóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (ct_phieuNhap.SoLuong == 0)
                {
                    MessageBox.Show(this, "Vui lòng nhập vào số lượng chi tiết!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
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
            else if (_phieuNhapXuat.MaNguoiNhapXuat == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_NhanVien.Focus();
            }
            else if (_phieuNhapXuat.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoNhan.Focus();
            }
            else if (_phieuNhapXuat.CT_PhieuNhapList.Count == 0)
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (KiemTraChiTiet() == false)
                return false;
            //MessageBox.Show(this, "Vui lòng nhập số lượng chi tiết phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (KiemTraButToanHoaDon() == false)
            {
                kq = false;
            }
            else kq = true;
            return kq;
        }

        private bool KiemTraButToanHoaDon()
        {
            bool kq = true;
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (taiKhoan.SoHieuTK.Contains("3113"))
                {
                    decimal tongTienHoaDon = 0;
                    foreach (ChungTu_HoaDon ct_hd in _butToan.ChungTu_HoaDonList)
                    {
                        tongTienHoaDon += ct_hd.SoTien;
                    }
                    if (tongTienHoaDon != _butToan.SoTien)
                    {
                        kq = false;
                        MessageBox.Show(this, "Gía trị hạch toán tài khoản thuế không bằng tổng giá trị các hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return kq;
        }


        void formatGriview()
        {
            this.grdViewCt_PhieuNhap.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }
        private void LockData()
        {
            //grdViewCt_PhieuNhap.OptionsBehavior.OptionsBehavior.Editable = false;
            grdViewCt_PhieuNhap.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
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
            grdViewCt_PhieuNhap.Columns["MaHangHoa"].OptionsColumn.AllowEdit = true;
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
                    // grdViewCt_PhieuNhap.OptionsBehavior.Editable = false;
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
            //
            if (khoaso = false && _phieuNhapXuat.IsNew == false)
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
            daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_phieuNhapXuat.NgayNX, _phieuNhapXuat.MaKho);
            if (daKC == false && _phieuNhapXuat.IsNew == false)
            {
                daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_ngayLapCu, _maKhoCu);
            }
            if (daKC)
            {
                MessageBox.Show("Kỳ này đã kết chuyển, không thể cập nhật phiếu!");
            }
            return daKC;
        }

        #region KiemTraCT_PhieuNhapsKhongTrung
        /*
        private bool KiemTraCT_PhieuNhapsKhongTrung()
        {
            CT_PhieuNhap ctCapNhat = grdViewCt_PhieuNhap.GetFocusedRow() as CT_PhieuNhap;
            int indexCapNhat = grdViewCt_PhieuNhap.FocusedRowHandle;
            if (ctCapNhat != null)
            {
                if (_phieuNhapXuat.PhuongPhapNX == 1 && ctCapNhat.MaHangHoa != 0)
                {
                    for (int i = 0; i < grdViewCt_PhieuNhap.RowCount; i++)
                    {
                        if (grdViewCt_PhieuNhap.GetRow(i) != null)
                        {
                            if (i == indexCapNhat) continue;
                            CT_PhieuNhap ct_pn_gv = (CT_PhieuNhap)grdViewCt_PhieuNhap.GetRow(i);
                            if (ct_pn_gv.MaHangHoa == ctCapNhat.MaHangHoa
                                )
                            {
                                MessageBox.Show("Không nhập " + HangHoaBQ_VT.GetHangHoaBQ_VT(ctCapNhat.MaHangHoa).TenHangHoa + " nhiều dòng trên cùng 1 phiếu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }
                else if (_phieuNhapXuat.PhuongPhapNX==2 && ctCapNhat.MaHangHoa != 0 && ctCapNhat.DonGia != 0)
                {
                    for (int i = 0; i < grdViewCt_PhieuNhap.RowCount; i++)
                    {
                        if (grdViewCt_PhieuNhap.GetRow(i) != null)
                        {
                            if (i == indexCapNhat) continue;
                            CT_PhieuNhap ct_pn_gv = (CT_PhieuNhap)grdViewCt_PhieuNhap.GetRow(i);
                            if (ct_pn_gv.MaHangHoa == ctCapNhat.MaHangHoa
                                && ct_pn_gv.DonGia == ctCapNhat.DonGia//New 19112013
                                )
                            {
                                MessageBox.Show("Không nhập " + HangHoaBQ_VT.GetHangHoaBQ_VT(ctCapNhat.MaHangHoa).TenHangHoa + " nhiều dòng trên cùng 1 phiếu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

            }//grdViewCt_PhieuXuat.RowCount > 0
            return true;
        }
        */
        private bool KiemTraCT_PhieuNhapsKhongTrung()
        {
            CT_PhieuNhap ctCapNhat = grdViewCt_PhieuNhap.GetFocusedRow() as CT_PhieuNhap;
            int indexCapNhat = grdViewCt_PhieuNhap.FocusedRowHandle;
            if (ctCapNhat != null)
            {
                if (ctCapNhat.MaHangHoa != 0 && ctCapNhat.DonGia != 0)
                {
                    for (int i = 0; i < grdViewCt_PhieuNhap.RowCount; i++)
                    {
                        if (grdViewCt_PhieuNhap.GetRow(i) != null)
                        {
                            if (i == indexCapNhat) continue;
                            CT_PhieuNhap ct_pn_gv = (CT_PhieuNhap)grdViewCt_PhieuNhap.GetRow(i);
                            if (ct_pn_gv.MaHangHoa == ctCapNhat.MaHangHoa
                                && ct_pn_gv.DonGia == ctCapNhat.DonGia//New 19112013
                                )
                            {
                                MessageBox.Show("Không nhập " + HangHoaBQ_VT.GetHangHoaBQ_VT(ctCapNhat.MaHangHoa).TenHangHoa + " nhiều dòng trên cùng 1 phiếu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

            }//grdViewCt_PhieuXuat.RowCount > 0
            return true;
        }

        #endregion//KiemTraCT_PhieuNhapsKhongTrung

        private void CapNhatLaiTongGiaTriPhieu()
        {
            Decimal tongTien = 0;
            foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
            {
                tongTien = tongTien + ct_PhieuNhap.ThanhTien;
            }
            _phieuNhapXuat.GiaTriKho = tongTien;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraPhanHeCua2014())
                return;
            textEdit_Focus.Focus();
            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Add to 18012013
            if (_phieuNhapXuat.XacNhan == true)
            {
                MessageBox.Show(this, "Thủ kho đã xác nhận, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DaKetChuyen())
            {
                //End Add to 18012013
                if (txt_SoPhieu.EditValue != null)//IF 1
                {
                    string _soPhieu = txt_SoPhieu.EditValue.ToString();
                    int _stt;
                    if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                    {
                        bool ktphieutrung = true;
                        if (_phieuNhapXuat.IsNew)
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, true);
                        }
                        else//k phai IS NEW
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, false);
                        }
                        if (ktphieutrung)//IF 5
                        {
                            //GH
                            phieuNhapXuatBindingSource.EndEdit();
                            try
                            {
                                if (KiemTraDuLieu() == true)
                                {
                                    _phieuNhapXuat.ApplyEdit();
                                    _phieuNhapXuat.Save();
                                    //Add to 11012013
                                    _ngayLapCu = _phieuNhapXuat.NgayNX;
                                    _maKhoCu = _phieuNhapXuat.MaKho;
                                    //End Add to 11012013
                                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (_phieuNhapXuat.PhuongPhapNX == 2)
                                    {
                                        long giaTri = PhieuNhapXuat.KiemTraPhieu(_phieuNhapXuat.MaPhieuNhapXuat);
                                        if (giaTri == 0)
                                        {
                                            if (MessageBox.Show("Bạn Có Muốn Lập Phiếu Xuất?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                FrmPhieuXuatVatTuHangHoa frm = new FrmPhieuXuatVatTuHangHoa(_phieuNhapXuat, 2, true);
                                                //frm.ShowDialog();//(1)
                                                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                                                {
                                                    CheckPhieuNhap();
                                                }//replace (1)
                                            }
                                        }
                                    }
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

                }//END IF 4
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
        }
        #endregion

        #region grdViewCt_PhieuNhap_CellValueChanged
        private void grdViewCt_PhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colDonGia")
            {
                grdCT_PhieuNhap.Update();
                ct_phieuNhap.ThanhTien = Math.Round(ct_phieuNhap.DonGia * ct_phieuNhap.SoLuong, 0, MidpointRounding.AwayFromZero);
                CapNhatLaiTongGiaTriPhieu();
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colThanhTien")
            {
                CapNhatLaiTongGiaTriPhieu();
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa")
            {
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                ct_phieuNhap.ThoiLuong = hangHoa.ThoiLuong;
                //grdViewCt_PhieuNhap.RefreshData();

            }
            if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colDonGia")
            {
                if (!KiemTraCT_PhieuNhapsKhongTrung())
                {
                    ((CT_PhieuNhap)cTPhieuNhapListBindingSource.Current).MaHangHoa = 0;
                }
            }

        }
        #endregion

        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            phieuNhapXuatBindingSource.EndEdit();
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.HoaDon_NhapXuatList.Count == 0)
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhapXuat.MaDoiTac);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
                        foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                        {
                            HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                            if (taiKhoan.SoHieuTK.Contains("3113"))
                            {

                                //if (_phieuNhapXuat.IsNew == false)
                                //{
                                //    foreach (HoaDon_NhapXuat hd_nx in _phieuNhapXuat.HoaDon_NhapXuatList)
                                //    {
                                //        foreach (ChungTu_HoaDon ct in _butToan.ChungTu_HoaDonList)
                                //        {
                                //            if (hd_nx.MaHoaDon == ct.MaHoaDon)
                                //            {
                                //                _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct));
                                //            }
                                //            break;
                                //        }
                                //    }
                                //}
                                _butToan.ChungTu_HoaDonList.Clear();
                                foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                                    _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

                            }
                        }
                    }
                }
            }
            else
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhapXuat);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
                        foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                        {
                            HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                            if (taiKhoan.SoHieuTK.Contains("3113"))
                            {

                                //foreach (HoaDon_NhapXuat hd_nx in _phieuNhapXuat.HoaDon_NhapXuatList)
                                //{
                                //    foreach (ChungTu_HoaDon ct in _butToan.ChungTu_HoaDonList)
                                //    {
                                //        if (hd_nx.MaHoaDon == ct.MaHoaDon)
                                //        {
                                //            _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct));
                                //        }
                                //        break;
                                //    }
                                //}
                                _butToan.ChungTu_HoaDonList.Clear();
                                foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                                    _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

                            }
                        }
                        _phieuNhapXuat.ApplyEdit();
                        _phieuNhapXuat.Save();
                    }
                }
            }
        }
        #endregion

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoPhieu();
        }

        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            // Gan tien cho but toan
            ButToanPhieuNhapXuat butToan = (ButToanPhieuNhapXuat)(butToanPhieuNhapXuatListBindingSource.Current);
            decimal soTienConLai = _phieuNhapXuat.GiaTriKho;
            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                soTienConLai = soTienConLai - buttoanphieu.SoTien;
            }
            butToan.SoTien = soTienConLai;
            butToan.MaDoiTuongCo = _phieuNhapXuat.MaDoiTac;
            butToan.DienGiai = _phieuNhapXuat.DienGiai;
        }

        private void grdViewCt_PhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
            //    {
            //        grdViewCt_PhieuNhap.DeleteRow(i);
            //    }
            //}
            //
            HamDungChung.CopyCell(grdViewCt_PhieuNhap, e);
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    grdView_DinhKhoan.DeleteSelectedRows();

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
                long giaTri = PhieuNhapXuat.KiemTraPhieu(_phieuNhapXuat.MaPhieuNhapXuat);
                if (giaTri != 0)
                {
                    PhieuNhapXuat phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(giaTri);
                    FrmPhieuXuatVatTuHangHoa frm = new FrmPhieuXuatVatTuHangHoa(phieuNhapXuat, 1, true);
                    //frm.ShowDialog();//(1)
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        CheckPhieuNhap();
                    }//replace (1)
                }
                else
                {
                    FrmPhieuXuatVatTuHangHoa frm = new FrmPhieuXuatVatTuHangHoa(_phieuNhapXuat, 2, true);
                    //frm.ShowDialog();//(1)
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        CheckPhieuNhap();//replace (1)
                    }
                }
            }
        }
        #endregion

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Rpt_PhieuNhapVatTu rpt = new Rpt_PhieuNhapVatTu(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.NgayNX);
            //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();
            //
            //BEGIN
            ReportTemplate _report;
            if (_phieuNhapXuat.PhuongPhapNX == 2)//IF la XuatThang
            {
                _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu_XuatThang");
            }
            else//IF la Xuat Binh Quan
            {
                _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
            }
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

        #region Cac Phuong Thuc Report

        public void Spd_PhieuNhapVatTu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuNhapVatTu";
                    cm.Parameters.AddWithValue("@MaPhieuNhap", _phieuNhapXuat.MaPhieuNhapXuat);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuNhapVatTu;1";
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
        }///End Spd_PhieuNhapVatTu 
        #endregion//Cac Phuong Thuc Report

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                //if (grdViewCt_PhieuNhap.GetFocusedRow() != null)
                //{
                //    CT_PhieuNhap ct_pn = grdViewCt_PhieuNhap.GetFocusedRow() as CT_PhieuNhap;
                //    _phieuNhapXuat.GiaTriKho = _phieuNhapXuat.GiaTriKho - ct_pn.ThanhTien;
                //    grdViewCt_PhieuNhap.DeleteSelectedRows();
                //}
                grdViewCt_PhieuNhap.DeleteSelectedRows();//Xoa nhieu dong
                Decimal tongTien = 0;
                foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
                {
                    tongTien = tongTien + ct_PhieuNhap.ThanhTien;
                }
                _phieuNhapXuat.GiaTriKho = tongTien;

            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                grdView_DinhKhoan.DeleteSelectedRows();
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(0);
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (dlg.MaHangHoaChon != 0)
                {
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                    if (cTPhieuNhapListBindingSource.Current == null || grdViewCt_PhieuNhap.GetFocusedRow() == null)
                        grdViewCt_PhieuNhap.AddNewRow();
                    CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                    ct_phieuNhap.MaHangHoa = dlg.MaHangHoaChon;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                    ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                    grdViewCt_PhieuNhap.RefreshData();
                }

            }
        }

        private void gridLookUpEdit_KhoNhan_EditValueChanged(object sender, EventArgs e)
        {
            _phieuNhapXuat.MaKho = (int)gridLookUpEdit_KhoNhan.EditValue;
        }

        private void grdViewCt_PhieuNhap_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            ct_phieuNhap.DienGiai = _phieuNhapXuat.DienGiai;

        }

        private void frmPhieuNhapVatTuHangHoa_Load(object sender, EventArgs e)
        {
            formatGriview();
            CheckPhieuNhap();
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuNhap, 35);

            //KiemTraPhanHeCua2014();
        }

        private void lookUpEdit_DoiTac_EditValueChanged(object sender, EventArgs e)
        {
            _phieuNhapXuat.MaDoiTac = (long)lookUpEdit_DoiTac.EditValue;
        }

        private void ButtonEdit_HoaDon_Click(object sender, EventArgs e)
        {
            //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
            //if (tk.SoHieuTK.Contains("3113"))
            //{
            //    frmDanhSachHoaDonDichVuPhieuXuat _frm = new frmDanhSachHoaDonDichVuPhieuXuat(_phieuNhapXuat, _chungTu_HoaDonList, (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
            //    _frm.Show();
            //}
        }

        private void grdView_DinhKhoan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colNoTaiKhoan")
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                if (tk.SoHieuTK.Contains("3113"))
                {
                    ButToanPhieuNhapXuat _butToan = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                }
            }
        }

        private void grdView_DinhKhoan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colHoaDon")
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                if (tk.SoHieuTK.Contains("3113"))
                {
                    frmDanhSachHoaDonDichVuPhieuXuat _frm = new frmDanhSachHoaDonDichVuPhieuXuat(_phieuNhapXuat, _chungTu_HoaDonList, (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                    _frm.Show();
                }
            }

        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                AllowDelete();
            }
            else if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(_phieuNhapXuat.MaPhieuNhapXuat))
            {
                NotAllowDelete();
            }
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuNhapXuat;
            if (pnx != null)
            {
                if (KhoaSo())
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DaKetChuyen()) return;

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
                        PhieuNhapXuat.DeletePhieuNhapXuat(_phieuNhapXuat);
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


    }
}