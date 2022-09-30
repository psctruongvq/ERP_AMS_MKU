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
using System.Diagnostics;
using System.IO;

//13/06/2014
namespace PSC_ERP
{
    public partial class FrmPhieuXuatBanQuyen : DevExpress.XtraEditors.XtraForm
    {
        PhieuNhapXuat _phieuXuat;
        CT_PhieuNhapList _ct_PhieuNhapListChon;//M
        ChuongTrinhBanQuyenConList _chuongTrinhBanQuyenConListChon;
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        KhoBQ_VTList _khoBQ_VTList;
        NguonList _nguonList;//M
        HopDongMuaBanList _hopDongMuaBanList;
        bool _daChonPhieuNhap = false;
        bool _tu1PhieuNhap = false;
        decimal _soLuongHienCo = 0;
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        //Add to 11012013
        DateTime _ngayLapCu;
        int _maKhoCu;
        int _maBoPhanCu;
        //End Add to 11012013
        bool _phieuTuDSPhieuNhapXuat = false;
        bool _saveFinish = false;


        public FrmPhieuXuatBanQuyen()
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu();
            KhoiTao_PhuongPhapNX();
            //colMaPhieuNhap.Visible = false;
        }

        public FrmPhieuXuatBanQuyen(PhieuNhapXuat phieuNhap, int kieu)
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap, kieu);
            KhoiTao_PhuongPhapNX();
        }
        public FrmPhieuXuatBanQuyen(PhieuNhapXuat phieuNhap, int kieu, bool XuatThangtu1PhieuNhap)
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap, kieu);
            KhoiTao_PhuongPhapNX();
            if (XuatThangtu1PhieuNhap)
                _tu1PhieuNhap = true;
        }

        
        #region  Functions
        #region Hàm khởi tạo lookUpEdit_PhuongPhapNX
        private void KhoiTao_PhuongPhapNX()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("maHinhThuc", typeof(byte));
            dt.Columns.Add("tenHinhThuc", typeof(string));
            //Add dòng 1
            DataRow dr = dt.NewRow();
            dr["maHinhThuc"] = 1;
            dr["tenHinhThuc"] = "Bình Quân";
            dt.Rows.Add(dr);
            //Add dòng 2
            dr = dt.NewRow();
            dr["maHinhThuc"] = 2;
            dr["tenHinhThuc"] = "Xuất Thẳng";
            dt.Rows.Add(dr);

            this.lookUpEdit_PhuongPhapNX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("maHinhThuc", null, 10, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenHinhThuc", null, 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            PhuongPhapNX_bindingSource.DataSource = dt;
            lookUpEdit_PhuongPhapNX.Properties.DataSource = PhuongPhapNX_bindingSource;
            lookUpEdit_PhuongPhapNX.Properties.DisplayMember = "tenHinhThuc";
            lookUpEdit_PhuongPhapNX.Properties.ValueMember = "maHinhThuc";
        }
        #endregion//END Hàm khởi tạo lookUpEdit_PhuongPhapNX

        #region Khoi tao moi
        private void KhoiTaoN()
        {
            // PhieuNhapXuatList_bindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            bs_ChuongTrinhConBanQuyenList.DataSource = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList();
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            //boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListBy_All();
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(1);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;


            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            _nguonList = NguonList.GetNguonList();//M 
            Nguon _nguon = Nguon.NewNguon("Không Chọn");//M
            _nguonList.Insert(0, _nguon);//M
            NguonList_bindingSource.DataSource = _nguonList;//M
            _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(1, 0, 0);//M
            HopDongMuaBan hdmb = HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn");
            _hopDongMuaBanList.Insert(0, hdmb);
            HopDongMuaBanList_BindingSource.DataSource = _hopDongMuaBanList;
            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
        }
        #endregion//END Khoi Tao moi

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuXuat = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuXuat.LaNhap = false;
            _phieuXuat.Loai = 1;
            _phieuXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuat.Loai, _phieuXuat.LaNhap, _phieuXuat.NgayNX);
            if (_khoBQ_VTList.Count != 0)
                _phieuXuat.MaKho = _khoBQ_VTList[0].MaKho;
            cTPhieuXuatListBindingSource.DataSource = _phieuXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;
            _phieuXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuXuat;
            if (_phieuXuat.MaPhieuNhapXuatThamChieu != 0)
            {
                //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                LockData();
                LockGridView();
            }
            else
            {
                //grdViewCt_PhieuXuat.OptionsBehavior.Editable = true;
                UnLockData();
                UnLockGridView();
            }

        }
        #endregion

        #region KhoiTaoPhieu()

        private void KhoiTaoPhieu(PhieuNhapXuat phieuXuat, int kieu)
        {
            if (kieu == 1)
            {
                _phieuXuat = phieuXuat;
                _ngayLapCu = _phieuXuat.NgayNX;
                _maKhoCu = _phieuXuat.MaKho;
                _maBoPhanCu = _phieuXuat.MaPhongBan;
                _phieuTuDSPhieuNhapXuat = true;
            }
            else
            {
                _phieuXuat = PhieuNhapXuat.NewPhieuXuatBanQuen(phieuXuat, 1);
                _phieuXuat.LaNhap = false;
                _phieuXuat.Loai = 1;
                _phieuXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuat.Loai, _phieuXuat.LaNhap, _phieuXuat.NgayNX);
                _phieuTuDSPhieuNhapXuat = false;

            }
            cTPhieuXuatListBindingSource.DataSource = _phieuXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuat;
            //btnThemMoi.Enabled = false;
            btnSaoChepChungTu.Enabled = false;//M

            if (_phieuXuat != null)
            {
                if (PhieuNhapXuat.KiemTraPhieuXuatThangTuPhieuNhap(_phieuXuat.MaPhieuNhapXuat))
                {
                    //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                    LockData();
                    if (_phieuXuat.PhuongPhapNX == 2)
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

        #endregion
        void formatGriview()
        {
            this.grdViewCt_PhieuXuat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }
        private void LockData()
        {
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = true;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }
        void UnLockData()
        {
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = false;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        void TempLockData()
        {
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = true;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
        }
        void LockGridView()
        {
            ////grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
            //grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
            //grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            //grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaChuongTrinhCon"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaHopDong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaNguon"].OptionsColumn.AllowEdit = false;
        }
        void UnLockGridView()
        {
            ////grdViewCt_PhieuXuat.OptionsBehavior.Editable = true;
            //grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = true;
            //grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = true;
            //grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaChuongTrinhCon"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaHopDong"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaNguon"].OptionsColumn.AllowEdit = true;
        }
        void EventRowOrColumnChange()
        {
            if (grdViewCt_PhieuXuat.GetFocusedRow() != null)
            {
                CT_PhieuXuat ct_px = (CT_PhieuXuat)grdViewCt_PhieuXuat.GetFocusedRow();
                if (_phieuTuDSPhieuNhapXuat)
                {
                    if (ct_px.MaPhieuNhap != 0)
                    {
                        LockGridView();
                    }
                    else
                    {
                        UnLockGridView();
                    }
                }
                else
                    if (_saveFinish)
                    {
                        if (ct_px.MaPhieuNhap != 0)
                        {
                            LockGridView();
                        }
                        else
                        {
                            UnLockGridView();
                        }
                    }
            }

        }
        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuXuat ct_phieuXuat in _phieuXuat.CT_PhieuXuatList)
            {
                if (ct_phieuXuat.MaChuongTrinhCon == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập Tên Chương trình cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (ct_phieuXuat.SoLuong == 0)
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
            if (_phieuXuat.MaPhongBan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_PhongBan.Focus();
            }
            else if (_phieuXuat.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoXuat.Focus();
            }
            else if (_phieuXuat.CT_PhieuXuatList.Count == 0)
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (KiemTraChiTiet() == false)
            {
                grdViewCt_PhieuXuat.Focus();
            }
            else kq = true;
            return kq;
        }

        private bool KiemTraSoTienTK152_ctPhieu()
        {
            decimal tongTienButToan = 0;
            bool coTK1552 = false;
            if (_phieuXuat.ButToanPhieuNhapXuatList.Count >0)
            {
                //
                foreach (ButToanPhieuNhapXuat bt in _phieuXuat.ButToanPhieuNhapXuatList)
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
                if (coTK1552 && tongTienButToan != _phieuXuat.GiaTriKho)
                {
                    MessageBox.Show("Số tiền bút toán Có TK 1552 và Giá trị phiếu xuất không bằng nhau. Vui lòng kiểm tra lại! ");
                    return false;
                }
                //
            }
            return true;
        }

        private bool KhoaSo()
        {
            bool khoaso = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }
            if (khoaso == false && _phieuXuat.IsNew == false)
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
            daKC = KetChuyenTonKhoBanQuyenBQ.KiemTraKetChuyenBanQuyen_PhucVuNXvaHuyKetChuyen(_phieuXuat.NgayNX, _phieuXuat.MaKho, _phieuXuat.MaPhongBan);

            if (daKC == false && _phieuXuat.IsNew == false)
            {
                daKC = KetChuyenTonKhoBanQuyenBQ.KiemTraKetChuyenBanQuyen_PhucVuNXvaHuyKetChuyen(_ngayLapCu, _maKhoCu, _maBoPhanCu);
            }

            if (daKC)
            {
                MessageBox.Show("Kỳ này đã kết chuyển, không thể cập nhật phiếu!");
            }
            return daKC;
        }

        #endregion//End Function

        #region FrmPhieuXuatBanQuyen_Load
        private void FrmPhieuXuatBanQuyen_Load(object sender, EventArgs e)
        {
            formatGriview();
            if (_phieuXuat.IsNew == false)
            {
                if (_phieuXuat != null)
                {
                    if (PhieuNhapXuat.KiemTraPhieuXuatThangTuPhieuNhap(_phieuXuat.MaPhieuNhapXuat))
                    {
                        LockData();
                        if (_phieuXuat.PhuongPhapNX == 2)
                            LockGridView();
                        else
                            UnLockGridView();
                    }
                }
            }
            else if (_tu1PhieuNhap)
            {
                LockData();
                LockGridView();
            }
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuXuat, 35);
            //Utils.GridUtils.InitNewRowOnTopOfGridView(grdViewCt_PhieuXuat);
            //Utils.GridUtils.InitNewRowOnTopOfGridView(grdView_DinhKhoan);

        }
        #endregion

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
            _phieuXuat.MaPhongBan = (int)lookUpEdit_PhongBan.EditValue;
        }
        #endregion

        #region btnThemMoi_ItemClick
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoPhieu();
            _tu1PhieuNhap = false;
            _daChonPhieuNhap = false;
            UnLockData();
            UnLockGridView();
            dateEdit_NgayLap.Focus();
            _phieuTuDSPhieuNhapXuat = false;
            _saveFinish = false;

        }
        #endregion

        #region btnLuu_ItemClick
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
                if (txt_SoPhieu.EditValue != null)//IF 1
                {
                    string _soPhieu = txt_SoPhieu.EditValue.ToString();
                    int _stt;
                    if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                    {
                        bool ktphieutrung = true;
                        if (_phieuXuat.IsNew)
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.SoPhieu, true);
                        }
                        else//k phai IS NEW
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.SoPhieu, false);
                        }

                        if (ktphieutrung)//IF 5
                        {
                            //GH
                            try
                            {
                                if (KiemTraDuLieu() && KiemTraSoTienTK152_ctPhieu())
                                {
                                    phieuNhapXuatBindingSource.EndEdit();
                                    _phieuXuat.ApplyEdit();
                                    _phieuXuat.Save();
                                    if (_phieuXuat != null)
                                    {
                                        if (PhieuNhapXuat.KiemTraPhieuXuatThangTuPhieuNhap(_phieuXuat.MaPhieuNhapXuat))
                                        {
                                            LockData();
                                        }
                                    }
                                    _saveFinish = true;
                                    _ngayLapCu = _phieuXuat.NgayNX;
                                    _maKhoCu = _phieuXuat.MaKho;
                                    _maBoPhanCu = _phieuXuat.MaPhongBan;
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

                }//END IF 4
            }

        }
        #endregion

        #region grdViewCt_PhieuXuat_CellValueChanged
        private void grdViewCt_PhieuXuat_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //M
            if (cTPhieuXuatListBindingSource.Current != null)
            {
                CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHangHoa")
                {
                    cTPhieuXuatListBindingSource.ResetItem(cTPhieuXuatListBindingSource.Position);
                    _ct_PhieuXuat.MaChuongTrinhCon = 0;
                }

                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaChuongTrinhCon")
                {
                    grdCT_PhieuXuat.Update();
                    ChuongTrinhBanQuyenCon chuongTrinh = ChuongTrinhBanQuyenCon.GetChuongTrinhBanQuyenCon(_ct_PhieuXuat.MaChuongTrinhCon);
                    _ct_PhieuXuat.MaHangHoa = chuongTrinh.MaHangHoa;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(chuongTrinh.MaHangHoa);
                    _ct_PhieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                    _ct_PhieuXuat.ThoiLuong = chuongTrinh.ThoiLuong;
                    if (_phieuXuat.PhuongPhapNX == 1)
                    {
                        _soLuongHienCo = ChuongTrinhBanQuyenCon.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                        _ct_PhieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.DonGia = ChuongTrinhBanQuyenCon.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                    }

                }
                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHopDong")
                {
                    grdCT_PhieuXuat.Update();
                    if (_phieuXuat.PhuongPhapNX == 1)
                    {
                        _soLuongHienCo = ChuongTrinhBanQuyenCon.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                        _ct_PhieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.DonGia = ChuongTrinhBanQuyenCon.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                    }

                }
                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaNguon")
                {
                    grdCT_PhieuXuat.Update();
                    if (_phieuXuat.PhuongPhapNX == 1)
                    {
                        _soLuongHienCo = ChuongTrinhBanQuyenCon.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                        _ct_PhieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.DonGia = ChuongTrinhBanQuyenCon.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                    }

                }
                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colSoLuong")
                {
                    decimal soluong_gv = 0;
                    if (decimal.TryParse(e.Value.ToString(), out soluong_gv))
                    {
                        #region Old
                        /*
                        //if (_laXuatThang)//Trong T/H Xuat thang tu 1 Phieu Nhap
                        if (_ct_PhieuXuat.ChonTuDSCTPhieu)//Trong T/H Xuat tu 1 Phieu Nhap
                        {
                            if (!_phieuTuDSPhieuNhapXuat)
                            {

                                if (soluong_gv > _ct_PhieuXuat.SLgCt_PNhap)
                                {
                                    MessageBox.Show("Số lượng xuất vượt quá chi tiết nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_ct_PhieuXuat.SLgCt_PNhap);
                                }
                                else if (soluong_gv == _ct_PhieuXuat.SLgCt_PNhap)
                                {
                                    _ct_PhieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);
                                    if (soluong_gv == 1)
                                    {
                                        _ct_PhieuXuat.DonGia = _ct_PhieuXuat.ThanhTien;
                                    }
                                }
                                else
                                {
                                    grdCT_PhieuXuat.Update();
                                    _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                                }
                            }
                        }//END Trong T/H Xuattu 1 DS CT_Phieu Nhap
                        else//Trong T/H Xuat Tu DS Ton
                        {
                            _soLuongHienCo = ChuongTrinhBanQuyenCon.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);
                            if (soluong_gv > _soLuongHienCo)
                            {
                                MessageBox.Show("Số lượng còn " + _soLuongHienCo.ToString() + ". Không đủ xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                                _ct_PhieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);
                            }
                            else if (soluong_gv == _soLuongHienCo)
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);
                            }
                            else
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                            }
                        }//END Trong T/H Xuat Tu DS Ton
                        */
                        #endregion //Old
                        if (_ct_PhieuXuat.MaPhieuNhap == 0)//Trong T/H Xuat Tu DS Ton
                        {
                            _soLuongHienCo = ChuongTrinhBanQuyenCon.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                            if (soluong_gv > _soLuongHienCo)
                            {
                                MessageBox.Show("Số lượng còn " + _soLuongHienCo.ToString() + ". Không đủ xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                                _ct_PhieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                            }
                            else if (soluong_gv == _soLuongHienCo)
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                            }
                            else
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                            }

                        }//END Trong T/H Xuat Tu DS Ton
                        else //Xuat tu Phieu Nhap
                        {
                            decimal soLuongTon_NXT = ChuongTrinhBanQuyenCon.GetSoLuongChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                            if (soluong_gv > soLuongTon_NXT)
                            {
                                MessageBox.Show("Số lượng xuất vượt quá chi tiết nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)soLuongTon_NXT);
                            }
                            else if (soluong_gv == soLuongTon_NXT)
                            {
                                _ct_PhieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinhCon, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                                if (soluong_gv == 1)
                                {
                                    _ct_PhieuXuat.DonGia = _ct_PhieuXuat.ThanhTien;
                                }
                            }
                            else
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                            }

                        }//End Xuat tu Phieu Nhap
                    }//IF thay doi tren cot So Luong

                }
                //Cap Nhat Gia Tri Kho
                Decimal tongTien = 0;
                foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuat.CT_PhieuXuatList)
                {
                    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                }
                _phieuXuat.GiaTriKho = tongTien;
            }//Khi Current !=Null

        }
        //M
        #endregion

        #region btnThoat_ItemClick
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.Close();

        }
        #endregion

        #region btnChonXuatThang_ItemClick
        private void btnChonXuatThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuXuat.MaPhongBan == 0)
            {
                MessageBox.Show("Hãy chọn Phòng Ban cần xuất!");
                lookUpEdit_PhongBan.Focus();
            }
            else if (_phieuXuat.MaKho == 0)
            {
                MessageBox.Show("Hãy chọn Kho cần xuất!");
                gridLookUpEdit_KhoXuat.Focus();
            }
            else
            {
                FrmLoadPhieuNhapBanQuyenList frm = new FrmLoadPhieuNhapBanQuyenList(_phieuXuat);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    _ct_PhieuNhapListChon = frm.CT_PhieuNhapListChon;//M
                    if (_ct_PhieuNhapListChon.Count != 0)//M
                    {
                        #region Old
                        ////Luu Tru
                        //long maDoiTac_T = _phieuXuat.MaDoiTac;
                        //string soPhieu_T = _phieuXuat.SoPhieu;
                        //int maPhongBan_T = _phieuXuat.MaPhongBan;
                        //DateTime ngayNX_T = _phieuXuat.NgayNX;
                        //long maNguoiNhapXuat_T = _phieuXuat.MaNguoiNhapXuat;
                        //int maKho_T = _phieuXuat.MaKho;
                        //int soCTKemTheo_T = _phieuXuat.SoCTKemTheo;
                        //byte phuongPhapNX_T = _phieuXuat.PhuongPhapNX;
                        //string dienGiai_T = _phieuXuat.DienGiai;
                        //CT_PhieuXuatList cT_PhieuXuatList_T = _phieuXuat.CT_PhieuXuatList;
                        //ButToanPhieuNhapXuatList butToanPhieuNhapXuatList_T = _phieuXuat.ButToanPhieuNhapXuatList;
                        ////
                        //_phieuXuat = new PhieuNhapXuat(_ct_PhieuNhapListChon, _phieuXuat.MaPhongBan, _phieuXuat.PhuongPhapNX, _phieuXuat.MaKho, _phieuXuat.NgayNX);//M
                        ////-->Day du lieu vao
                        //_phieuXuat.LaNhap = false;
                        //_phieuXuat.Loai = 1;
                        //_phieuXuat.MaDoiTac = maDoiTac_T;
                        //_phieuXuat.SoPhieu = soPhieu_T;
                        //_phieuXuat.MaPhongBan = maPhongBan_T;
                        //_phieuXuat.NgayNX = ngayNX_T;
                        //_phieuXuat.MaNguoiNhapXuat = maNguoiNhapXuat_T;
                        //_phieuXuat.MaKho = maKho_T;
                        //_phieuXuat.SoCTKemTheo = soCTKemTheo_T;
                        //_phieuXuat.PhuongPhapNX = phuongPhapNX_T;
                        //_phieuXuat.DienGiai = dienGiai_T;
                        //foreach (CT_PhieuXuat cT in cT_PhieuXuatList_T)
                        //{
                        //    if (!_phieuXuat.CT_PhieuXuatList.Contains(cT))
                        //    {
                        //        _phieuXuat.CT_PhieuXuatList.Add(cT);
                        //    }
                        //}


                        //foreach (ButToanPhieuNhapXuat bt in butToanPhieuNhapXuatList_T)
                        //{
                        //    _phieuXuat.ButToanPhieuNhapXuatList.Add(bt);
                        //}
                        #endregion//Old
                        #region New
                        foreach (CT_PhieuNhap ct_PhieuNhap in _ct_PhieuNhapListChon)
                        {
                            long maHopDong = 0;
                            NhapXuat_HopDongList nx_HopDongList = NhapXuat_HopDongList.GetNhapXuat_HopDongList(ct_PhieuNhap.MaPhieuNhap);
                            if (nx_HopDongList.Count != 0)
                                maHopDong = nx_HopDongList[0].MaHopDong;
                            //cho t/h Binh Quan & Xuat Thang
                            if (ct_PhieuNhap.SoLuong > ct_PhieuNhap.SoLuongXuat)
                            {
                                CT_PhieuXuat ct_PhieuXuat = new CT_PhieuXuat(ct_PhieuNhap, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, maHopDong, _phieuXuat.NgayNX);
                                bool insert = true;
                                if (grdViewCt_PhieuXuat.RowCount > 0)
                                {
                                    //DataRow[] rows = new DataRow[grdViewCt_PhieuXuat.RowCount];
                                    for (int i = 0; i < grdViewCt_PhieuXuat.RowCount; i++)
                                    {
                                        if (grdViewCt_PhieuXuat.GetRow(i) != null)
                                        {
                                            CT_PhieuXuat ct_px_gv = (CT_PhieuXuat)grdViewCt_PhieuXuat.GetRow(i);
                                            if (ct_px_gv.MaHangHoa == ct_PhieuXuat.MaHangHoa
                                                    && ct_px_gv.MaChuongTrinhCon == ct_PhieuXuat.MaChuongTrinhCon
                                                    && ct_px_gv.MaHopDong == ct_PhieuXuat.MaHopDong
                                                    && ct_px_gv.MaNguon == ct_PhieuXuat.MaNguon
                                                     && ct_px_gv.MaPhieuNhap == ct_PhieuXuat.MaPhieuNhap)
                                            {
                                                insert = false;
                                                break;
                                            }
                                        }
                                    }

                                }//grdViewCt_PhieuXuat.RowCount > 0

                                if (insert)
                                {
                                    _phieuXuat.CT_PhieuXuatList.Add(ct_PhieuXuat);
                                }

                            }
                            else
                            {
                                HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuNhap.MaHangHoa);
                                MessageBox.Show("Chi tiết của \"" + _hangHoaBQ_VT.TenHangHoa + "\" đã xuất hết!");
                            }
                        }
                        #endregion //End New
                        //Set lai Gia Tri Kho
                        Decimal tongTien = 0;
                        foreach (CT_PhieuXuat _ct_px in _phieuXuat.CT_PhieuXuatList)
                        {
                            tongTien = tongTien + _ct_px.ThanhTien;
                        }
                        _phieuXuat.GiaTriKho = tongTien;
                        //END Set lai Gia Tri Kho
                        //Refresh lai du lieu
                        phieuNhapXuatBindingSource.DataSource = _phieuXuat;
                        cTPhieuXuatListBindingSource.DataSource = _phieuXuat.CT_PhieuXuatList; //_ctPhieuXuatList;
                        butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;// _butToanPhieuNhapXuatList;
                        grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
                        grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;
                        _daChonPhieuNhap = true;
                        TempLockData();
                    }//_ct_PhieuNhapListChon.Count != 0
                }
                else
                {
                    frm.ShowDialog();
                }
            }
            //Xu ly dong form [PhieuXuat]

        }
        #endregion

        #region grdCT_PhieuXuat_KeyDown
        private void grdCT_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    DialogResult kq = MessageBox.Show("Bạn chắc xóa dòng này?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //    if (kq == DialogResult.Yes)
            //        grdViewCt_PhieuXuat.DeleteSelectedRows();
            //}

            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
        }
        #endregion

        #region grd_DinhKhoan_KeyDown
        private void grd_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Delete)
            //{
            //    DialogResult kq = MessageBox.Show("Bạn chắc xóa dòng này?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //    if (kq == DialogResult.Yes)
            //        grdView_DinhKhoan.DeleteSelectedRows();
            //}
            HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }
        #endregion

        #region grdView_DinhKhoan_InitNewRow
        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ButToanPhieuNhapXuat butToan = (ButToanPhieuNhapXuat)(butToanPhieuNhapXuatListBindingSource.Current);
            decimal soTienConLai = _phieuXuat.GiaTriKho;
            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuXuat.ButToanPhieuNhapXuatList)
            {
                soTienConLai = soTienConLai - buttoanphieu.SoTien;
            }
            butToan.SoTien = soTienConLai;
            butToan.DienGiai = _phieuXuat.DienGiai;//Gan Dien Giai cua Phieu Xuat cho ButToan
        }
        #endregion

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Rpt_PhieuXuatBanQuyen rpt = new Rpt_PhieuXuatBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.NgayNX);
            //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuXuatBanQuyen");
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
                    cm.CommandText = "Spd_PhieuXuatBanQuyen";
                    cm.Parameters.AddWithValue("@MaPhieuXuat", _phieuXuat.MaPhieuNhapXuat);

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
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_CTPhieuXuat")
            {
                //if (grdViewCt_PhieuXuat.GetFocusedRow() != null)
                //{
                //    CT_PhieuXuat ct_px = grdViewCt_PhieuXuat.GetFocusedRow() as CT_PhieuXuat;
                //    _phieuXuat.GiaTriKho = _phieuXuat.GiaTriKho - ct_px.ThanhTien;
                //    grdViewCt_PhieuXuat.DeleteSelectedRows();
                //}
                grdViewCt_PhieuXuat.DeleteSelectedRows();
                Decimal tongTien = 0;
                foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuat.CT_PhieuXuatList)
                {
                    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                }
                _phieuXuat.GiaTriKho = tongTien;

            }
            else if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_ButToan")
                grdView_DinhKhoan.DeleteSelectedRows();
        }

        private void FrmPhieuXuatBanQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_phieuXuat.IsDirty)
            //{
            //    DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    if (kq == DialogResult.Yes)
            //    {
            //        btnLuu.PerformClick();
            //    }
            //    else
            //        if (kq == DialogResult.Cancel)
            //        {
            //            e.Cancel = true;
            //        }
            //}
        }

        private void lookUpEdit_PhuongPhapNX_EditValueChanged(object sender, EventArgs e)
        {
            _phieuXuat.PhuongPhapNX = (byte)lookUpEdit_PhuongPhapNX.EditValue;
        }

        private void grdViewCt_PhieuXuat_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
            _ct_PhieuXuat.DienGiai = _phieuXuat.DienGiai;

        }

        private void btnSaoChepChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSPhieuNhapXuatBanQuyen frm = new frmDSPhieuNhapXuatBanQuyen(1, false);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                _phieuXuat = PhieuNhapXuat.NewPhieuNhapXuat(frm.PhieuNhapXuat, dateEdit_NgayLap.DateTime);
                //
                _phieuXuat.LaNhap = false;
                _phieuXuat.Loai = 1;
                _phieuXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuat.Loai, _phieuXuat.LaNhap, _phieuXuat.NgayNX);
                cTPhieuXuatListBindingSource.DataSource = _phieuXuat.CT_PhieuXuatList;
                butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;
                // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;
                _phieuXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
                phieuNhapXuatBindingSource.DataSource = _phieuXuat;
            }
        }

        private void grdViewCt_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }

        private void ChuongTinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(1);
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (dlg.MaHangHoaChon != 0)
                {
                    if (dlg.MaChuongTrinhConChon != 0)
                    {
                        if (cTPhieuXuatListBindingSource.Current == null || grdViewCt_PhieuXuat.GetFocusedRow() == null)
                            grdViewCt_PhieuXuat.AddNewRow();
                        CT_PhieuXuat ct_phieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
                        ct_phieuXuat.MaHangHoa = dlg.MaHangHoaChon;
                        ct_phieuXuat.MaChuongTrinhCon = dlg.MaChuongTrinhConChon;
                        HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuXuat.MaHangHoa);
                        ct_phieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                        ChuongTrinhBanQuyenCon chuongTrinh = ChuongTrinhBanQuyenCon.GetChuongTrinhBanQuyenCon(ct_phieuXuat.MaChuongTrinhCon);
                        ct_phieuXuat.ThoiLuong = chuongTrinh.ThoiLuong;
                        if (_phieuXuat.PhuongPhapNX == 1)
                        {
                            _soLuongHienCo = ChuongTrinhBanQuyenCon.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, ct_phieuXuat.MaChuongTrinhCon, ct_phieuXuat.MaHopDong, ct_phieuXuat.MaNguon, _phieuXuat.NgayNX);
                            ct_phieuXuat.SoLuong = _soLuongHienCo;
                            ct_phieuXuat.ThanhTien = ChuongTrinhBanQuyenCon.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, ct_phieuXuat.MaChuongTrinhCon, ct_phieuXuat.MaHopDong, ct_phieuXuat.MaNguon, _phieuXuat.NgayNX);
                            ct_phieuXuat.DonGia = ChuongTrinhBanQuyenCon.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, ct_phieuXuat.MaChuongTrinhCon, ct_phieuXuat.MaHopDong, ct_phieuXuat.MaNguon, _phieuXuat.NgayNX);
                        }
                        cTPhieuXuatListBindingSource.ResetItem(cTPhieuXuatListBindingSource.Position);
                    }
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
                    bs_ChuongTrinhConBanQuyenList.DataSource = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList();
                }
            }
        }

        private void GridLookUpEdit_ChuongTrinh_Popup(object sender, EventArgs e)
        {
            if (cTPhieuXuatListBindingSource.Current != null && grdViewCt_PhieuXuat.GetFocusedRow() != null)
            {
                CT_PhieuXuat ctpx = cTPhieuXuatListBindingSource.Current as CT_PhieuXuat;
                if (ctpx.MaHangHoa != 0)
                {
                    GridLookUpEdit grid = (GridLookUpEdit)sender;
                    if (grid != null)
                    {
                        grid.Properties.View.ActiveFilterString = "MaHangHoa='" + ctpx.MaHangHoa.ToString() + "'";
                        this.gridView6.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
                    }
                }
                else
                {
                    MessageBox.Show("Nhập vào tên chương trình cha");
                    return;
                }
            }
        }


        private void btn_DsChuongTrinh_Click(object sender, EventArgs e)
        {
            if (_phieuXuat.PhuongPhapNX == 2)
            {
                MessageBox.Show("Hãy chọn xuất Bình Quân để xuất các Chương trình còn tồn!");
                lookUpEdit_PhuongPhapNX.Focus();
            }
            else if (_phieuXuat.PhuongPhapNX == 1)
            {
                if (_phieuXuat.MaPhongBan == 0)
                {
                    MessageBox.Show("Vui lòng chọn Phòng ban để xuất!");
                    lookUpEdit_PhongBan.Focus();
                }
                else if (_phieuXuat.MaKho == 0)
                {
                    MessageBox.Show("Vui lòng chọn Kho để xuất!");
                    gridLookUpEdit_KhoXuat.Focus();
                }
                else
                {
                    FrmChuongTrinhBanQuyenListCheck frm = new FrmChuongTrinhBanQuyenListCheck(_phieuXuat);
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        _chuongTrinhBanQuyenConListChon = frm.ChuongTrinhBanQuyenConListChon;//M
                        if (_chuongTrinhBanQuyenConListChon.Count != 0)//M
                        {
                            foreach (ChuongTrinhBanQuyenCon _ctbq in _chuongTrinhBanQuyenConListChon)
                            {
                                CT_PhieuXuat ct_PhieuXuat = CT_PhieuXuat.NewCT_PhieuXuat(_ctbq, _phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.NgayNX, _phieuXuat.DienGiai);
                                //
                                bool insert = true;
                                if (grdViewCt_PhieuXuat.RowCount > 0)
                                {
                                    //DataRow[] rows = new DataRow[grdViewCt_PhieuXuat.RowCount];
                                    for (int i = 0; i < grdViewCt_PhieuXuat.RowCount; i++)
                                    {
                                        if (grdViewCt_PhieuXuat.GetRow(i) != null)
                                        {
                                            CT_PhieuXuat ct_px_gv = (CT_PhieuXuat)grdViewCt_PhieuXuat.GetRow(i);
                                            if (ct_px_gv.MaHangHoa == ct_PhieuXuat.MaHangHoa
                                                    && ct_px_gv.MaChuongTrinhCon == ct_PhieuXuat.MaChuongTrinhCon
                                                    && ct_px_gv.MaHopDong == ct_PhieuXuat.MaHopDong
                                                    && ct_px_gv.MaNguon == ct_PhieuXuat.MaNguon
                                                    && ct_px_gv.MaPhieuNhap == ct_PhieuXuat.MaPhieuNhap)
                                            {
                                                insert = false;
                                                break;
                                            }
                                        }
                                    }

                                }//grdViewCt_PhieuXuat.RowCount > 0

                                if (insert)
                                {
                                    _phieuXuat.CT_PhieuXuatList.Add(ct_PhieuXuat);
                                }
                            }
                            //Set lai Gia Tri Kho
                            Decimal tongTien = 0;
                            foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuat.CT_PhieuXuatList)
                            {
                                tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                            }
                            _phieuXuat.GiaTriKho = tongTien;
                        }
                    }
                    else
                    {
                        frm.ShowDialog();
                    }
                    //Refresh lai du lieu
                    phieuNhapXuatBindingSource.DataSource = _phieuXuat;
                    cTPhieuXuatListBindingSource.DataSource = _phieuXuat.CT_PhieuXuatList; //_ctPhieuXuatList;
                    butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;// _butToanPhieuNhapXuatList;
                    grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
                    grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;
                }
            }//Xuat Binh Quan 
        }

        private void grdViewCt_PhieuXuat_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            EventRowOrColumnChange();
        }

        private void grdViewCt_PhieuXuat_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EventRowOrColumnChange();
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuXuat;
            if (pnx != null)
            {
                if (KhoaSo())
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DaKetChuyen()) return;
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
                        PhieuNhapXuat.DeletePhieuNhapXuat(_phieuXuat);
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

        private void repositoryItemDateEdit_DatePhatsong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                if (cTPhieuXuatListBindingSource.Current != null)
                {
                    CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
                    _ct_PhieuXuat.NgayPhatSong = DateTime.MinValue;
                    DateEdit de = sender as DateEdit;
                    de.EditValue = null;
                }

            }
        }

        private void btn_XuatraExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                grdViewCt_PhieuXuat.ExportToXls(dlg.FileName);
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


    }
}
