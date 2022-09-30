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
//12/06/2014
namespace PSC_ERP
{
    public partial class frmPhieuNhapBanQuyen : DevExpress.XtraEditors.XtraForm
    {

        PhieuNhapXuat _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        NguonList _nguonList;//M
        KhoBQ_VTList _khoBQ_VTList = KhoBQ_VTList.NewKhoBQ_VTList();
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        ChungTu_HoaDonList _chungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
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
        //
        public frmPhieuNhapBanQuyen()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
            grdViewCt_PhieuNhap.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            grdViewCt_PhieuNhap.FocusedRowHandle = grdViewCt_PhieuNhap.RowCount - 1;
            grdViewCt_PhieuNhap.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
        }

        #region frmPhieuNhapBanQuyen(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuNhapBanQuyen(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }
        #endregion

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _chungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
            _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuNhapXuat.Loai = 1;
            _phieuNhapXuat.LaNhap = true;
            _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
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
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
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
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanNo.SoHieuTK.Contains("3113") || taiKhoanNo.SoHieuTK.Contains("3337"))
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
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            bs_ChuongTrinhConBanQuyenList.DataSource = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList();
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

        }
        #endregion

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

        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuNhap ct_phieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
            {
                if (ct_phieuNhap.MaChuongTrinhCon == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập Tên Chương trình cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (ct_phieuNhap.SoLuong == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập số lượng cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            bool kq = true;
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanNo.SoHieuTK.Contains("3113") || taiKhoanNo.SoHieuTK.Contains("3337"))
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
            //grdViewCt_PhieuNhap.OptionsBehavior.Editable = false;
            grdViewCt_PhieuNhap.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["MaChuongTrinhCon"].OptionsColumn.AllowEdit = false;
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
            grdViewCt_PhieuNhap.Columns["MaHangHoa"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns["MaChuongTrinhCon"].OptionsColumn.AllowEdit = true;
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
                MessageBox.Show("Kỳ này đã kết chuyển, không thể cập nhật phiếu!");
            }
            return daKC;
        }

        private bool KiemTraSoTienTK152_ctPhieu()
        {
            decimal tongTienButToan = 0;
             bool coTK1552 = false;
             if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count >0)
             {
                 //
                 foreach (ButToanPhieuNhapXuat bt in _phieuNhapXuat.ButToanPhieuNhapXuatList)
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

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();
            textEdit_Focus1.Focus();
            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DaKetChuyen() == false)
            {

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
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, true);

                        }
                        else//k phai IS NEW
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, false);
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
            CT_PhieuNhap _ct_PhieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colThanhTien" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong")
            {
                if (_ct_PhieuNhap.SoLuong != 0)//Thay doi Don Gia
                {
                    _ct_PhieuNhap.DonGia = Math.Round(_ct_PhieuNhap.ThanhTien / _ct_PhieuNhap.SoLuong, 0, MidpointRounding.AwayFromZero);
                }
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa")
            {
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(_ct_PhieuNhap.MaHangHoa);
                _ct_PhieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                _ct_PhieuNhap.MaChuongTrinhCon = 0;
                grdViewCt_PhieuNhap.RefreshData();
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaChuongTrinhCon")
            {
                //CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                ChuongTrinhBanQuyenCon chuongTrinh = ChuongTrinhBanQuyenCon.GetChuongTrinhBanQuyenCon(_ct_PhieuNhap.MaChuongTrinhCon);
                _ct_PhieuNhap.MaHangHoa = chuongTrinh.MaHangHoa;
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(chuongTrinh.MaHangHoa);
                _ct_PhieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                _ct_PhieuNhap.ThoiLuong = chuongTrinh.ThoiLuong;
                //grdViewCt_PhieuNhap.RefreshData();
            }
            Decimal tongTien = 0;
            foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
            {
                tongTien = tongTien + ct_PhieuNhap.ThanhTien;
            }
            _phieuNhapXuat.GiaTriKho = tongTien;//Thay doi Gia Tri Kho

        }
        #endregion

        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            phieuNhapXuatBindingSource.EndEdit();
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.HoaDon_NhapXuatList.Count == 0)
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhapXuat.MaDoiTac, _phieuNhapXuat.Loai);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
                        foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                        {
                            HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                            HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);

                            if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanNo.SoHieuTK.Contains("3113") || taiKhoanNo.SoHieuTK.Contains("3337"))
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
                            HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                            HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                            if (taiKhoan.SoHieuTK.Contains("3113") || taiKhoan.SoHieuTK.Contains("3337") || taiKhoanNo.SoHieuTK.Contains("3113") || taiKhoanNo.SoHieuTK.Contains("3337"))
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

        private void btnSaoChepChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew)
            {
                frmDSPhieuNhapXuatBanQuyen frm = new frmDSPhieuNhapXuatBanQuyen(1, true);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat(frm.PhieuNhapXuat, dateEdit_NgayLap.DateTime);
                    //
                    _phieuNhapXuat.Loai = 1;
                    _phieuNhapXuat.LaNhap = true;
                    _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
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
            btnSaoChepChungTu.Enabled = true;//M
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
                long giaTri = PhieuNhapXuat.KiemTraPhieu(_phieuNhapXuat.MaPhieuNhapXuat);
                if (giaTri != 0)
                {
                    PhieuNhapXuat phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(giaTri);
                    FrmPhieuXuatBanQuyen frm = new FrmPhieuXuatBanQuyen(phieuNhapXuat, 1, true);
                    //frm.ShowDialog();//(1)
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        CheckPhieuNhap();
                    }//replace (1)
                }
                else
                {
                    FrmPhieuXuatBanQuyen frm = new FrmPhieuXuatBanQuyen(_phieuNhapXuat, 2, true);
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
            ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuNhapBanQuyen");
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
                    cm.CommandText = "Spd_PhieuNhapBanQuyen";
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
                _phieuNhapXuat.GiaTriKho = tongTien;//Thay doi Gia Tri Kho

            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
                grdView_DinhKhoan.DeleteSelectedRows();
        }



        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(1);
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (dlg.MaHangHoaChon != 0)
                {
                    if (dlg.MaChuongTrinhConChon != 0)
                    {
                        if (cTPhieuNhapListBindingSource.Current == null || grdViewCt_PhieuNhap.GetFocusedRow() == null)
                        {
                            grdViewCt_PhieuNhap.AddNewRow();
                        }
                        CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                        ct_phieuNhap.MaHangHoa = dlg.MaHangHoaChon;
                        ct_phieuNhap.MaChuongTrinhCon = dlg.MaChuongTrinhConChon;
                        HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                        ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                        ChuongTrinhBanQuyenCon chuongTrinh = ChuongTrinhBanQuyenCon.GetChuongTrinhBanQuyenCon(ct_phieuNhap.MaChuongTrinhCon);
                        ct_phieuNhap.ThoiLuong = chuongTrinh.ThoiLuong;
                        cTPhieuNhapListBindingSource.ResetItem(cTPhieuNhapListBindingSource.Position);

                    }
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
                    bs_ChuongTrinhConBanQuyenList.DataSource = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList();
                }
            }
        }

        private void btn_HopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.NhapXuat_HopDongList.Count == 0)
            {
                frmChonHopDongLapPhieu frm = new frmChonHopDongLapPhieu(_phieuNhapXuat.MaDoiTac, _lockHopDong);
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
                frmChonHopDongLapPhieu frm = new frmChonHopDongLapPhieu(_phieuNhapXuat, _lockHopDong);
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
            CT_PhieuNhap _ct_PhieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            _ct_PhieuNhap.DienGiai = _phieuNhapXuat.DienGiai;
            //_ct_PhieuNhap.STT = grdViewCt_PhieuNhap.RowCount + 1;
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
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuNhap, 35);

        }

        /// <summary>
        /// Init GridView
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="autoFilter"></param>
        /// <param name="multiSelect"></param>
        /// <param name="selectMode"></param>
        /// <param name="detailButton"></param>
        /// <param name="groupPanel"></param>
        /// <param name="textNewRow"></param>
        public static void InitGridView(GridView grid, bool autoFilter, bool multiSelect, GridMultiSelectMode selectMode, bool detailButton, bool groupPanel, string textNewRow)
        {
            //Show filter
            grid.OptionsView.ShowAutoFilterRow = autoFilter;
            //Show multi select
            grid.OptionsSelection.MultiSelect = multiSelect;
            //Show multi select mode
            grid.OptionsSelection.MultiSelectMode = selectMode;
            //Show detail button
            grid.OptionsView.ShowDetailButtons = detailButton;
            //Show group panel
            grid.OptionsView.ShowGroupPanel = groupPanel;
            //Show text new row
            grid.NewItemRowText = textNewRow;

            for (int i = 0; i < grid.Columns.Count; i++)
                grid.Columns[i].Visible = false;
        }

        /// <summary>
        /// Show editor for Grid
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="pos"></param>
        public static void ShowEditor(GridView grid, NewItemRowPosition pos)
        {
            //Show edit
            grid.FocusedRowHandle = grid.RowCount - 1;
            grid.OptionsView.NewItemRowPosition = pos;
        }

        /// <summary>
        /// Show field with caption, width
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        public static void ShowField(GridView grid, string[] fieldName, string[] caption, int[] width)
        {
            grid.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns.AddField(fieldName[i]);
                grid.Columns[fieldName[i]].Visible = true;
                grid.Columns[fieldName[i]].Caption = caption[i];
                grid.Columns[fieldName[i]].Width = width[i];
                grid.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }



        /// <summary>
        /// Attach control RepositoryItem
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="item"></param>
        public static void RegisterControlField(GridView grid, string fieldName, DevExpress.XtraEditors.Repository.RepositoryItem item)
        {
            grid.Columns[fieldName].ColumnEdit = item;
        }

        /// <summary>
        /// Format data field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="formatType"></param>
        /// <param name="formatString"></param>
        public static void FormatDataField(GridView grid, string fieldName, DevExpress.Utils.FormatType formatType, string formatString)
        {
            grid.Columns[fieldName].DisplayFormat.FormatString = formatString;
        }


        /// <summary>
        /// Initialize for RepositoryItemGridLookUp
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="autoFilter"></param>
        /// <param name="autoPopup"></param>
        /// <param name="textEditStyle"></param>
        public static void InitRepositoryItemGridLookUp(RepositoryItemGridLookUpEdit grid, bool autoPopup, TextEditStyles textEditStyle)
        {
            //Show filter
            grid.View.OptionsView.ShowAutoFilterRow = true;
            grid.View.OptionsSelection.EnableAppearanceFocusedCell = false;
            grid.View.OptionsView.ShowGroupPanel = false;
            grid.View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.CellFocus;
            grid.TextEditStyle = textEditStyle;
            grid.ImmediatePopup = autoPopup;
            grid.PopupFilterMode = PopupFilterMode.Contains;
            //grid.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < grid.View.Columns.Count; i++)
                grid.View.Columns[i].Visible = false;
        }

        /// <summary>
        /// Initialize for RepositoryItemGridLookUp
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void InitPopupFormSize(RepositoryItemGridLookUpEdit grid, int width, int height)
        {
            grid.PopupFormSize = new Size(width, height);
        }

        /// <summary>
        /// Show field with caption, width
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        public static void ShowField(RepositoryItemGridLookUpEdit grid, string[] fieldName, string[] caption, int[] width)
        {
            grid.View.OptionsView.ColumnAutoWidth = true;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.View.Columns.AddField(fieldName[i]);
                grid.View.Columns[fieldName[i]].Visible = true;
                grid.View.Columns[fieldName[i]].Caption = caption[i];
                grid.View.Columns[fieldName[i]].Width = width[i];
                grid.View.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }




        /// <summary>
        /// Init
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="autoFilter"></param>
        /// <param name="autoPopup"></param>
        /// <param name="textEditStyle"></param>
        public static void InitGridLookUp(GridLookUpEdit grid, bool autoFilter, bool autoPopup, TextEditStyles textEditStyle)
        {
            //Show filter
            grid.Properties.View.OptionsView.ShowAutoFilterRow = autoFilter;
            grid.Properties.TextEditStyle = textEditStyle;
            grid.Properties.ImmediatePopup = autoPopup;
            grid.Properties.PopupFilterMode = PopupFilterMode.Contains;
            //grid.Properties.BestFitMode = BestFitMode.BestFit;
            for (int i = 0; i < grid.Properties.View.Columns.Count; i++)
                grid.Properties.View.Columns[i].Visible = false;
        }

        /// <summary>
        /// Init popup form
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void InitPopupFormSize(GridLookUpEdit grid, int width, int height)
        {
            grid.Properties.PopupFormSize = new Size(width, height);
        }

        /// <summary>
        /// Show field
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="fieldName"></param>
        /// <param name="caption"></param>
        /// <param name="width"></param>
        public static void ShowField(GridLookUpEdit grid, string[] fieldName, string[] caption, int[] width)
        {
            grid.Properties.View.OptionsView.ColumnAutoWidth = false;
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Properties.View.Columns.AddField(fieldName[i]);
                grid.Properties.View.Columns[fieldName[i]].Visible = true;
                grid.Properties.View.Columns[fieldName[i]].Caption = caption[i];
                grid.Properties.View.Columns[fieldName[i]].Width = width[i];
                grid.Properties.View.Columns[fieldName[i]].OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
            }
        }

        private void grdViewCt_PhieuNhap_ShownEditor(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view;

            view = sender as DevExpress.XtraGrid.Views.Grid.GridView;

            if (view.FocusedColumn.FieldName == "colMaChuongTrinhCon" && view.ActiveEditor is DevExpress.XtraEditors.GridLookUpEdit)
            {

                Text = view.ActiveEditor.Parent.Name;

                DevExpress.XtraEditors.GridLookUpEdit edit;

                edit = (DevExpress.XtraEditors.GridLookUpEdit)view.ActiveEditor;



                //DataTable table = edit.Properties.grLookUpData.DataSource as DataTable;
                DataTable table = edit.Properties.DataSource as DataTable;

                clone = new DataView(table);

                DataRow row = view.GetDataRow(view.FocusedRowHandle);

                clone.RowFilter = "[MaChuongTrinhCon] = " + row["colMaChuongTrinhCon"].ToString();

                edit.Properties.DataSource = clone;

            }
        }

        private void GridLookUpEdit_ChuongTrinhBanQuyenConList_Popup(object sender, EventArgs e)
        {
            if (cTPhieuNhapListBindingSource.Current != null && grdViewCt_PhieuNhap.GetFocusedRow() != null)
            {
                CT_PhieuNhap ctpn = cTPhieuNhapListBindingSource.Current as CT_PhieuNhap;
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
            ButToanPhieuNhapXuat _butToan = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);

            if (grdView_DinhKhoan.FocusedColumn.Name == "colNoTaiKhoan" || grdView_DinhKhoan.FocusedColumn.Name == "colCoTaiKhoan")
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                HeThongTaiKhoan1 tk1 = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                _butToan.ChungTu_HoaDonList.Clear();
                if (tk.SoHieuTK.Contains("3113") || tk.SoHieuTK.Contains("3337") || tk1.SoHieuTK.Contains("3113") || tk1.SoHieuTK.Contains("3337"))
                {
                    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                }

            }
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

        private void grdView_DinhKhoan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colHoaDon")
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).CoTaiKhoan);
                HeThongTaiKhoan1 tk1 = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                if (tk.SoHieuTK.Contains("3113") || tk.SoHieuTK.Contains("3337") || tk1.SoHieuTK.Contains("3113") || tk1.SoHieuTK.Contains("3337"))
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

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        //private void grdViewCt_PhieuNhap_AfterPrintRow(object sender, DevExpress.XtraGrid.Views.Printing.PrintRowEventArgs e)
        //{
        //    CT_PhieuNhap current = (CT_PhieuNhap)grdViewCt_PhieuNhap.GetRow(e.RowHandle);
        //    if (current != null)
        //        current.STT = e.RowHandle + 1;
        //}


    }
}