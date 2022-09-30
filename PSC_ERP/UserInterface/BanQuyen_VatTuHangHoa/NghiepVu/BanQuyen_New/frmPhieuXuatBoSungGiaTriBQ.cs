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

///07/07/2014
namespace PSC_ERP
{
    public partial class frmPhieuXuatBoSungGiaTriBQ : DevExpress.XtraEditors.XtraForm
    {
        PhieuNhapXuatBQ _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat();
        PhieuNhapXuatBQ _phieuNhapXuatCu;
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        KhoBQ_VTList _khoBQ_VTList;
        HopDongMuaBanList _hopDongMuaBanList;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        //Add to 11012013
        DateTime _ngayLapCu;
        int _maKhoCu;
        int _maBoPhanCu;
        //End Add to 11012013
        bool _khoaso = false;

        NguonList _nguonList;//M


        int _hoanTat = -1;
        int _maCongTyCurrent = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        public frmPhieuXuatBoSungGiaTriBQ()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
        }

        #region frmPhieuXuatBoSungGiaTri(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuXuatBoSungGiaTriBQ(PhieuNhapXuatBQ phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }
        #endregion
        public frmPhieuXuatBoSungGiaTriBQ(PhieuNhapXuatBQ phieuNhap, int kieu, bool XuatThangtu1PhieuNhap)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhap, kieu);
        }
        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat();
            _phieuNhapXuat.Loai = 4;
            _phieuNhapXuat.LaNhap = false;
            _phieuNhapXuat.SoPhieu = PhieuNhapXuatBQ.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            if (_khoBQ_VTList.Count != 0)
                _phieuNhapXuat.MaKho = _khoBQ_VTList[0].MaKho;
            cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;

            formatGridviewDinhKhoan();
            UnLockData();
            UnLockGridView();

        }
        #endregion
        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuatBQ phieuNhapXuat)
        {
            _phieuNhapXuat = phieuNhapXuat;
            cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            //Add to 11012013
            _ngayLapCu = _phieuNhapXuat.NgayNX;
            _maKhoCu = _phieuNhapXuat.MaKho;
            _maBoPhanCu = _phieuNhapXuat.MaPhongBan;
            //End Add to 11012013
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;            
            _phieuNhapXuatCu = PhieuNhapXuatBQ.GetPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuatThamChieu);
            //txt_SoPhieuCu.Text = _phieuNhapXuatCu.SoPhieu;
            //barbt_PhieuNhap.Enabled = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            btnSaoChepChungTu.Enabled = false;//M

        }
        #endregion

        #region  KhoiTaoPhieu(PhieuNhapXuat phieuXuat, int kieu)
        private void KhoiTaoPhieu(PhieuNhapXuatBQ phieuXuat, int kieu)
        {
            if (kieu == 1)
            {
                _phieuNhapXuat = phieuXuat;
                //Add to 11012013
                _ngayLapCu = _phieuNhapXuat.NgayNX;
                _maKhoCu = _phieuNhapXuat.MaKho;
                _maBoPhanCu = _phieuNhapXuat.MaPhongBan;
                //End Add to 11012013
                //_phieuTuDSPhieuNhapXuat = true;
            }
            else
            {
                _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuXuatBanQuen(phieuXuat, 1);
                _phieuNhapXuat.LaNhap = false;
                _phieuNhapXuat.Loai = 4;
                _phieuNhapXuat.SoPhieu = PhieuNhapXuatBQ.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
                //_phieuTuDSPhieuNhapXuat = false;

            }
            cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            //btnThemMoi.Enabled = false;
            btnSaoChepChungTu.Enabled = false;//M

            if (_phieuNhapXuat != null)
            {
                if (PhieuNhapXuatBQ.KiemTraPhieuXuatThangTuPhieuNhap(_phieuNhapXuat.MaPhieuNhapXuat))
                {
                    //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                    LockData();
                    if (_phieuNhapXuat.PhuongPhapNX == 2)
                        LockGridView();
                    else
                        UnLockGridView();

                }
                else
                {
                    UnLockData();
                }
            }
        }
        #endregion// KhoiTaoPhieu(PhieuNhapXuat phieuXuat, int kieu)
        #region KhoiTao()
        private void KhoiTao()
        {

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            //boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListBy_All();
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(1);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;

            _nguonList = NguonList.GetNguonList();//M 
            Nguon _nguon = Nguon.NewNguon("Không Chọn");//M
            _nguonList.Insert(0, _nguon);//M
            NguonList_bindingSource.DataSource = _nguonList;//M

            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(1, 0, 0);//M
            HopDongMuaBan hdmb = HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn");
            _hopDongMuaBanList.Insert(0, hdmb);
            HopDongMuaBanList_BindingSource.DataSource = _hopDongMuaBanList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            Init_lookUpEdit_PhongBan();

            ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewList_BQ(_hoanTat, _maCongTyCurrent);
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewList.Insert(0, ct0);
            chuongTrinh_NewListBindingSource.DataSource = _chuongTrinh_NewList;
            ChuongTrinh_NewList _chuongTrinh_NewList1 = ChuongTrinh_NewList.GetChuongTrinh_NewListAll(_hoanTat, _maCongTyCurrent);
            chuongTrinh_NewListbindingSource1.DataSource = _chuongTrinh_NewList1;

        }
        #endregion
        #region Kiem Tra Chi Tiet Phieu Nhap có Gia Tri
        private bool KiemTraSoTienTK152_ctPhieu()
        {
            decimal tongTienButToan = 0;
            bool coTK1552 = false;
            if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count > 0)
            {
                //
                foreach (ButToanPhieuNhapXuatBQ bt in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                {
                    if (bt.SoHieuTaiKhoanCo.Length >= 4)
                    {
                        if (bt.SoHieuTaiKhoanCo.Substring(0, 4) == "1552")
                        {
                            tongTienButToan += bt.SoTien;
                            coTK1552 = true;
                        }
                    }
                }
                if (coTK1552 && tongTienButToan != _phieuNhapXuat.GiaTriKho)
                {
                    MessageBox.Show("Số tiền bút toán Có TK 1552 và Giá trị phiếu xuất không bằng nhau. Vui lòng kiểm tra lại! ");
                    return false;
                }
                //
            }
            return true;
        }
        bool KTGiaTriCt_PhieuXuat()
        {
            bool kt = true;
            foreach (CT_PhieuXuatBQ ctpx in _phieuNhapXuat.CT_PhieuXuatList)
            {
                if (ctpx.ThanhTien == 0)
                {
                    kt = false;
                    break;
                }
            }

            TuDongCapNhatCPSXButToanTheoCT_PhieuXuat();

            //Kiem tra but toan
            foreach (ButToanPhieuNhapXuatBQ bt in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                if (bt.ChungTu_ChiPhiSanXuatList.Count > 0)
                {

                    decimal sotienCTu = 0;
                    foreach (ChungTu_ChiPhiSanXuat ct_cp in bt.ChungTu_ChiPhiSanXuatList)
                    {
                        sotienCTu += ct_cp.SoTien;
                    }
                    if (bt.SoTien != sotienCTu)
                    {
                        kt = false;
                        MessageBox.Show(this, "Tổng số tiền Công việc/Chương trình không bằng số tiền bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }

            return kt;
        }
        #endregion//Kiem Tra Chi Tiet Phieu Xuat có Gia Tri
        void formatGriview()
        {
            this.grdViewCt_PhieuXuat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }

        private void LockData()
        {
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = true;
            lookUpEdit_PPNXKho.Properties.ReadOnly = true;

        }
        void UnLockData()
        {
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = false;
            lookUpEdit_PPNXKho.Properties.ReadOnly = false;
        }
        void LockGridView()
        {
            grdViewCt_PhieuXuat.Columns["MaChuongTrinhCha"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaChuongTrinh"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaHopDong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            //grdViewCt_PhieuXuat.Columns["MaNguon"].OptionsColumn.AllowEdit = false;
        }
        void UnLockGridView()
        {
            grdViewCt_PhieuXuat.Columns["MaChuongTrinhCha"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaChuongTrinh"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaHopDong"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = true;
            //grdViewCt_PhieuXuat.Columns["MaNguon"].OptionsColumn.AllowEdit = true;
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


        private decimal TongTienTheoChuongTrinhPhieu(int maChuongTrinh)
        {
            decimal tongtien = 0;
            foreach (CT_PhieuXuatBQ ct in _phieuNhapXuat.CT_PhieuXuatList)
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
                CT_PhieuXuatBQList list = _phieuNhapXuat.CT_PhieuXuatList;
                if (TaiKhoanButToanThuocCPSX(buttoan))
                {
                    if (buttoan.ChungTu_ChiPhiSanXuatList.Count == 0)
                    {
                        foreach (CT_PhieuXuatBQ ct in list)
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

        #region Vat Tu_Ban Quyen
        private void anHiencottheoyeucau()
        {
            this.colMaTieuMuc.Visible = false;
            this.col_btn.Visible = true;
        }
        private void formatGridviewDinhKhoan()
        {
            if (!_phieuNhapXuat.IsNew)
            {
                if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count > 0)
                {
                    foreach (ButToanPhieuNhapXuatBQ bt in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                    {
                        if (bt.ButToan_MucNganSach.MaTieuMuc != 0 && bt.ButToan_MucNganSach.MaCT_ChiPhiSanXuat == 0)
                        {

                            this.colMaTieuMuc.Visible = true;
                            this.col_btn.Visible = false;
                        }
                        else
                        {
                            anHiencottheoyeucau();
                        }
                    }
                }
                else
                {
                    anHiencottheoyeucau();
                }
            }
            else
            {
                anHiencottheoyeucau();
            }
        }
        #endregion//Vat Tu_Ban Quyen

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
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

            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DaKetChuyen() == false)
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
                            ktphieutrung = PhieuNhapXuatBQ.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, true);
                        }
                        else//k phai IS NEW
                        {
                            ktphieutrung = PhieuNhapXuatBQ.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, false);
                        }
                        if (ktphieutrung)//IF 5
                        {
                            //C
                            try
                            {
                                if (KTGiaTriCt_PhieuXuat() && KiemTraSoTienTK152_ctPhieu())
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
                                else
                                {
                                    MessageBox.Show("Không thể lưu! Giá trị bổ sung cho chi tiết phải khác 0.", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    grdCT_PhieuXuat.Focus();
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //C
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
        #region grdViewCt_PhieuXuat_CellValueChanged
        private void grdViewCt_PhieuXuat_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CT_PhieuXuatBQ ct_phieuXuat = (CT_PhieuXuatBQ)cTPhieuXuatListBindingSource.Current;
            if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colThanhTien")
            {
                decimal thanhtien_gv = 0;
                if (decimal.TryParse(e.Value.ToString(), out thanhtien_gv))
                {
                    decimal giaTriTon_NXT = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_PhanBoSungGiaTri_NXT(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.MaPhongBan, _phieuNhapXuat.MaKho, _phieuNhapXuat.PhuongPhapNX, ct_phieuXuat.MaPhieuNhap, ct_phieuXuat.MaChuongTrinh, ct_phieuXuat.MaHopDong, _phieuNhapXuat.NgayNX, ct_phieuXuat.MaChiTietPhieuNhap);//= ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                    //decimal soLuongTon_NXT = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyenTheoMaChiTietPhieuNhap_NXT(_phieuXuat.MaPhieuNhapXuat, _ct_PhieuXuat.MaChiTietPhieuNhap, _phieuXuat.NgayNX);

                    if (thanhtien_gv != giaTriTon_NXT)
                    {
                        MessageBox.Show("Thành tiền không hợp lệ!", "Thông Báo");
                        ct_phieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_PhanBoSungGiaTri_NXT(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.MaPhongBan, _phieuNhapXuat.MaKho, _phieuNhapXuat.PhuongPhapNX, ct_phieuXuat.MaPhieuNhap, ct_phieuXuat.MaChuongTrinh, ct_phieuXuat.MaHopDong, _phieuNhapXuat.NgayNX, ct_phieuXuat.MaChiTietPhieuNhap);//= ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                    }
                }


                Decimal tongTien = 0;
                foreach (CT_PhieuXuatBQ ct_PhieuXuat in _phieuNhapXuat.CT_PhieuXuatList)
                {
                    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                }
                _phieuNhapXuat.GiaTriKho = tongTien;
            }
            else if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHangHoa")
            {
                ct_phieuXuat.MaChuongTrinh = 0;
            }
            else if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaChuongTrinhCon")
            {
                ChuongTrinh_New chuongtrinh = ChuongTrinh_New.GetChuongTrinh_New(ct_phieuXuat.MaChuongTrinh);
                int maCtCha = chuongtrinh.MaChuongTrinhCha;
                if (maCtCha != 0)
                {
                    ct_phieuXuat.MaChuongTrinhCha = maCtCha;
                }
                else
                {
                    ct_phieuXuat.MaChuongTrinhCha = ct_phieuXuat.MaChuongTrinh;
                }
                ct_phieuXuat.MaDonViTinh = chuongtrinh.MaDonViTinh;
                ct_phieuXuat.ThoiLuong = chuongtrinh.ThoiLuong;
                // grdViewCt_PhieuXuat.RefreshData();
            }

        }
        #endregion
        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool khoaso = KhoaSo();
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.HoaDon_NhapXuatList.Count == 0)
            {
                frmChonHoaDonLapPhieuBQ frm = new frmChonHoaDonLapPhieuBQ(_phieuNhapXuat.MaDoiTac, _phieuNhapXuat.Loai, khoaso);
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
                frmChonHoaDonLapPhieuBQ frm = new frmChonHoaDonLapPhieuBQ(_phieuNhapXuat, khoaso);
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
        #endregion
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //barbt_PhieuNhap.Enabled = true;
            KhoiTaoPhieu();
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
            butToan.DienGiai = _phieuNhapXuat.DienGiai;
        }

        private void grdViewCt_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    foreach (int i in grdViewCt_PhieuXuat.GetSelectedRows())
            //    {
            //        grdViewCt_PhieuXuat.DeleteRow(i);
            //    }
            //}
            //
            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
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
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                //if (grdViewCt_PhieuXuat.GetFocusedRow() != null)
                //{
                //    CT_PhieuXuat ct_px = grdViewCt_PhieuXuat.GetFocusedRow() as CT_PhieuXuat;
                //    _phieuNhapXuat.GiaTriKho = _phieuNhapXuat.GiaTriKho - ct_px.ThanhTien;
                //    grdViewCt_PhieuXuat.DeleteSelectedRows();
                //}
                grdViewCt_PhieuXuat.DeleteSelectedRows();
                Decimal tongTien = 0;
                foreach (CT_PhieuXuatBQ ct_PhieuXuat in _phieuNhapXuat.CT_PhieuXuatList)
                {
                    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                }
                _phieuNhapXuat.GiaTriKho = tongTien;
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
                grdView_DinhKhoan.DeleteSelectedRows();
        }
        private void barbt_PhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.MaPhongBan == 0)
            {
                MessageBox.Show("Hãy chọn Phòng Ban cần xuất!");
                lookUpEdit_PhongBan.Focus();
                return;
            }
            else if (_phieuNhapXuat.MaKho == 0)
            {
                MessageBox.Show("Hãy chọn Kho cần xuất!");
                gridLookUpEdit_KhoXuat.Focus();
                return;
            }
            //frmDanhSachPhieuNhapXuat frm = new frmDanhSachPhieuNhapXuat(false, 0);
            frmDanhSachPhieuNhapXuatBQ frm = new frmDanhSachPhieuNhapXuatBQ(_phieuNhapXuat, true, 4,true);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {

                #region Old
                //string _soPhieuT = _phieuNhapXuat.SoPhieu;
                //_phieuNhapXuatCu = frm.PhieuNhapXuat;
                //_phieuNhapXuat = new PhieuNhapXuatBQ(_phieuNhapXuatCu);//M
                //_phieuNhapXuat.SoPhieu = _soPhieuT;
                //_phieuNhapXuat.LaNhap = false;
                //_phieuNhapXuat.Loai = 4;
                //_phieuNhapXuat.MaPhieuNhapXuatThamChieu = _phieuNhapXuatCu.MaPhieuNhapXuat;
                ////txt_SoPhieuCu.Text = _phieuNhapXuatCu.SoPhieu;
                //_phieuNhapXuat.PhuongPhapNX = _phieuNhapXuatCu.PhuongPhapNX;
                //_phieuNhapXuat.MaDoiTac = _phieuNhapXuatCu.MaDoiTac;
                //_phieuNhapXuat.MaKho = _phieuNhapXuatCu.MaKho;
                //_phieuNhapXuat.MaNguoiNhapXuat = _phieuNhapXuatCu.MaNguoiNhapXuat;
                //_phieuNhapXuat.MaPhongBan = _phieuNhapXuatCu.MaPhongBan;
                //Decimal tongTien = 0;
                //foreach (CT_PhieuXuatBQ ct_PhieuXuat in _phieuNhapXuat.CT_PhieuXuatList)
                //{
                //    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                //}
                //_phieuNhapXuat.GiaTriKho = tongTien;

                //phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
                //cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList; //_ctPhieuXuatList;
                //butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;// _butToanPhieuNhapXuatList;
                //grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
                //grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;
                //if (_phieuNhapXuat.CT_PhieuXuatList.Count > 0)
                //{
                //    LockData();
                //    LockGridView();
                //}
                #endregion//Old

                #region Modify
                if (frm.DSPhieuNhapForLapPhieuXuat.Count != 0)//M
                {
                    #region New
                    foreach (PhieuNhapXuatBQ phieunhap in frm.DSPhieuNhapForLapPhieuXuat)
                    {
                        foreach (CT_PhieuNhapBQ ct_PhieuNhap in phieunhap.CT_PhieuNhapList)
                        {
                            long maHopDong = 0;
                            NhapXuat_HopDongList nx_HopDongList = NhapXuat_HopDongList.GetNhapXuat_HopDongList(ct_PhieuNhap.MaPhieuNhap);
                            if (nx_HopDongList.Count != 0)
                                maHopDong = nx_HopDongList[0].MaHopDong;
                                CT_PhieuXuatBQ ct_PhieuXuat = new CT_PhieuXuatBQ(ct_PhieuNhap,4);
                                bool insert = true;
                                if (grdViewCt_PhieuXuat.RowCount > 0)
                                {
                                    for (int i = 0; i < grdViewCt_PhieuXuat.RowCount; i++)
                                    {
                                        if (grdViewCt_PhieuXuat.GetRow(i) != null)
                                        {
                                            CT_PhieuXuatBQ ct_px_gv = (CT_PhieuXuatBQ)grdViewCt_PhieuXuat.GetRow(i);
                                            if (
                                                ct_px_gv.MaChiTietPhieuNhap == ct_PhieuXuat.MaChiTietPhieuNhap
                                                )
                                            {
                                                insert = false;
                                                break;
                                            }
                                        }
                                    }

                                }//grdViewCt_PhieuXuat.RowCount > 0

                                if (insert)
                                {
                                    _phieuNhapXuat.CT_PhieuXuatList.Add(ct_PhieuXuat);
                                }
                        }
                    }
                    #endregion //End New
                    //Set lai Gia Tri Kho
                    Decimal tongTien = 0;
                    foreach (CT_PhieuXuatBQ _ct_px in _phieuNhapXuat.CT_PhieuXuatList)
                    {
                        tongTien = tongTien + _ct_px.ThanhTien;
                    }
                    _phieuNhapXuat.GiaTriKho = tongTien;
                    //END Set lai Gia Tri Kho
                    //Refresh lai du lieu
                    phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
                    cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList; //_ctPhieuXuatList;
                    butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;// _butToanPhieuNhapXuatList;
                    grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
                    grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;
                    //_daChonPhieuNhap = true;
                    //TempLockData();
                    if (_phieuNhapXuat.CT_PhieuXuatList.Count > 0)
                    {
                        LockData();
                        LockGridView();
                    }
                }//_ct_PhieuNhapListChon.Count != 0
                #endregion//Modify



            }
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_PhieuXuatBanQuyen_BQ");
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
        #region Cac Phuong Thuc Report
        public void Spd_PhieuXuatBanQuyen()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuXuatBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuXuatBanQuyen_BQ";
                    cm.Parameters.AddWithValue("@MaPhieuXuat", _phieuNhapXuat.MaPhieuNhapXuat);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuXuatBanQuyen;1";
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
        }
        //END Spd_PhieuXuatBanQuyen
        #endregion//Cac Phuong Thuc Report

        private void btn_HopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.NhapXuat_HopDongList.Count == 0)
            {
                int maPhanLoaiHD = PhanLoaiHopDong.GetPhanLoaiHopDongByMaQL("BQ").MaPhanLoaiHD;
                frmChonHopDongLapPhieuBQ frm = new frmChonHopDongLapPhieuBQ(_phieuNhapXuat.MaDoiTac, false,maPhanLoaiHD);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.NhapXuat_HopDongList = frm.NhapXuat_HopDongList;
                    }
                }
            }
            else
            {
                frmChonHopDongLapPhieuBQ frm = new frmChonHopDongLapPhieuBQ(_phieuNhapXuat, false);
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

        private void grdViewCt_PhieuXuat_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuXuatBQ ct_phieuXuat = (CT_PhieuXuatBQ)cTPhieuXuatListBindingSource.Current;
            ct_phieuXuat.DienGiai = _phieuNhapXuat.DienGiai;
        }

        private void btnSaoChepChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSPhieuNhapXuatBanQuyenBQ frm = new frmDSPhieuNhapXuatBanQuyenBQ(4, false);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat(frm.PhieuNhapXuat, dateEdit_NgayLap.DateTime);
                //
                _phieuNhapXuat.Loai = 4;
                _phieuNhapXuat.LaNhap = false;
                _phieuNhapXuat.SoPhieu = PhieuNhapXuatBQ.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
                cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
                butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
                // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

                _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
                phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            }
        }

        private void frmPhieuXuatBoSungGiaTri_Load(object sender, EventArgs e)
        {
            formatGriview();
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuXuat, 35);

            formatGridviewDinhKhoan();
            grdView_DinhKhoan.OptionsView.ShowFooter = true;
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdView_DinhKhoan, new string[] { "SoTien" }, "{0:#,###.##}");
        }

        private void GridLookUpEdit_ChuongTrinh_Popup(object sender, EventArgs e)
        {
            if (cTPhieuXuatListBindingSource.Current != null && grdViewCt_PhieuXuat.GetFocusedRow() != null)
            {
                CT_PhieuXuatBQ ctpx = cTPhieuXuatListBindingSource.Current as CT_PhieuXuatBQ;
                if (ctpx.MaHangHoa != 0)
                {
                    GridLookUpEdit grid = (GridLookUpEdit)sender;
                    if (grid != null)
                    {
                        grid.Properties.View.ActiveFilterString = "MaHangHoa=" + ctpx.MaHangHoa.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập vào tên chương trình cha");
                    return;
                }
            }
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuatBQ pnx = _phieuNhapXuat;
            if (pnx != null)
            {
                if (KhoaSo())//Kiem Tra Khoa so
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (DaKetChuyen())
                {
                    return;
                }
                //
                if (PhieuNhapXuatBQ.KiemTraPhieuNhapDaXuatThang(pnx.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
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

        private void GridLookUpEdit_MaChuongTrinh_Popup(object sender, EventArgs e)
        {
            if (cTPhieuXuatListBindingSource.Current != null && grdViewCt_PhieuXuat.GetFocusedRow() != null)
            {
                CT_PhieuXuatBQ ctpx = cTPhieuXuatListBindingSource.Current as CT_PhieuXuatBQ;
                if (ctpx.MaChuongTrinhCha != 0)
                {
                    GridLookUpEdit grid = (GridLookUpEdit)sender;
                    if (grid != null)
                    {
                        grid.Properties.View.ActiveFilterString = "MaChuongTrinhCha=" + ctpx.MaChuongTrinhCha.ToString() + "or MaChuongTrinh=" + ctpx.MaChuongTrinhCha.ToString();
                    }
                }
                //else
                //{
                //    MessageBox.Show("Nhập vào tên chương trình cha");
                //    return;
                //}
            }
        }

        private void grdView_DinhKhoan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
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
        }




    }
}