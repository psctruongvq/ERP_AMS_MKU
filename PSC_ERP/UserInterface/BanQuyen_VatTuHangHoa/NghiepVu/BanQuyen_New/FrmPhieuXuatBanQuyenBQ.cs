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

////16/07/2014
namespace PSC_ERP
{
    public partial class FrmPhieuXuatBanQuyenBQ : DevExpress.XtraEditors.XtraForm
    {
        PhieuNhapXuatBQ _phieuXuat;
        CT_PhieuNhapBQList _ct_PhieuNhapListChon;//M
        ChuongTrinh_NewBQList _chuongTrinhBanQuyenConListChon;
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
        #region BS KhoaSoTK
        private bool _isCellValuechangeBT = true;
        private bool _coTKBiKhoa = false;
        #endregion//BS KhoaSoTK
        //End Add to 11012013
        bool _phieuTuDSPhieuNhapXuat = false;
        bool _saveFinish = false;


        int _hoanTat = -1;
        int _maCongTyCurrent = ERP_Library.Security.CurrentUser.Info.MaCongTy;


        public FrmPhieuXuatBanQuyenBQ()
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu();
            KhoiTao_PhuongPhapNX();
            //colMaPhieuNhap.Visible = false;
        }

        public FrmPhieuXuatBanQuyenBQ(PhieuNhapXuatBQ phieuNhap, int kieu)
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap, kieu);
            KhoiTao_PhuongPhapNX();
        }
        public FrmPhieuXuatBanQuyenBQ(PhieuNhapXuatBQ phieuNhap, int kieu, bool XuatThangtu1PhieuNhap)
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

            ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewList_BQ(_hoanTat, _maCongTyCurrent);
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewList.Insert(0, ct0);
            chuongTrinh_NewListBindingSource.DataSource = _chuongTrinh_NewList;
            ChuongTrinh_NewList _chuongTrinh_NewList1 = ChuongTrinh_NewList.GetChuongTrinh_NewListAll(_hoanTat, _maCongTyCurrent);
            chuongTrinh_NewListbindingSource1.DataSource = _chuongTrinh_NewList1;
        }
        #endregion//END Khoi Tao moi

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat();
            _phieuXuat.LaNhap = false;
            _phieuXuat.Loai = 1;
            _phieuXuat.SoPhieu = PhieuNhapXuatBQ.SetSoPhieuNhapXuat(_phieuXuat.Loai, _phieuXuat.LaNhap, _phieuXuat.NgayNX);
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

            formatGridviewDinhKhoan();

        }
        #endregion

        #region KhoiTaoPhieu()

        private void KhoiTaoPhieu(PhieuNhapXuatBQ phieuXuat, int kieu)
        {
            if (kieu == 1)
            {
                _phieuXuat = phieuXuat;
                //Add to 11012013
                _ngayLapCu = _phieuXuat.NgayNX;
                _maKhoCu = _phieuXuat.MaKho;
                _maBoPhanCu = _phieuXuat.MaPhongBan;
                _coTKBiKhoa = CheckCoTaiKhoanBiKhoaTrongButToan();
                //End Add to 11012013
                _phieuTuDSPhieuNhapXuat = true;
            }
            else
            {
                _phieuXuat = PhieuNhapXuatBQ.NewPhieuXuatBanQuen(phieuXuat, 1);
                _phieuXuat.LaNhap = false;
                _phieuXuat.Loai = 1;
                _phieuXuat.SoPhieu = PhieuNhapXuatBQ.SetSoPhieuNhapXuat(_phieuXuat.Loai, _phieuXuat.LaNhap, _phieuXuat.NgayNX);
                _phieuTuDSPhieuNhapXuat = false;

            }
            cTPhieuXuatListBindingSource.DataSource = _phieuXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuat;
            //btnThemMoi.Enabled = false;
            btnSaoChepChungTu.Enabled = false;//M

            if (_phieuXuat != null)
            {
                if (PhieuNhapXuatBQ.KiemTraPhieuXuatThangTuPhieuNhap(_phieuXuat.MaPhieuNhapXuat))
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

        #region KhoaSoTaiKhoan

        private void LockgrdView_DinhKhoan()
        {

            grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = false;
            grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = false;
            grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = false;//
            //grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;

        }//Them

        private void UnLockgrdView_DinhKhoan()
        {
            grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = true;//
            //grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = true;
        }//Them

        private bool CheckCoTaiKhoanBiKhoaTrongButToan()
        {
            foreach (ButToanPhieuNhapXuatBQ buttoan in _phieuXuat.ButToanPhieuNhapXuatList)
            {
                //tblTaiKhoan tk = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.NoTaiKhoan ?? 0);
                //tblTaiKhoan tkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.CoTaiKhoan ?? 0);
                if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckValidKhoaTaiKhoanWhenChangeNgayCT()//Them
        {
            if (CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa Tài khoản, không thể thực hiện", "Thông Báo");
                _phieuXuat.NgayNX = _ngayLapCu;
                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                return false;
            }
            return true;
        }

        private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        {

            bool khoataiKhoan = false;
            KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _phieuXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoataiKhoan = true;
                }
            }

            if (khoataiKhoan == false && _phieuXuat.IsNew == false)
            {
                khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        khoataiKhoan = true;
                    }
                }
            }
            return khoataiKhoan;
        }//Them
        private void EventRowOrColumnGrdView_DinhKhoanChange()
        {
            UnLockgrdView_DinhKhoan();
            if (grdView_DinhKhoan.GetFocusedRow() != null)
            {
                ButToanPhieuNhapXuatBQ buttoan = (ButToanPhieuNhapXuatBQ)grdView_DinhKhoan.GetFocusedRow();
                if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan))
                {
                    if (buttoan.MaButToan == 0)
                    {
                        _isCellValuechangeBT = false;
                        MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        buttoan.NoTaiKhoan = 0;
                        buttoan.CoTaiKhoan = 0;
                        _isCellValuechangeBT = true;
                    }
                    else
                        LockgrdView_DinhKhoan();
                }
            }

            #region KhoaSoThue
            //if (KhoaSoThue())
            //{
            //    if (grdView_DinhKhoan.GetFocusedRow() != null)
            //    {
            //        ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetFocusedRow();
            //        HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
            //        if (tk.SoHieuTK.StartsWith("3113"))
            //        {
            //            LockgrdView_DinhKhoan();
            //        }
            //        else
            //        {
            //            UnLockgrdView_DinhKhoan();
            //        }
            //    }
            //}
            //else
            //{
            //    UnLockgrdView_DinhKhoan();
            //}
            #endregion//KhoaSoThue


        }//Them

        #endregion //KhoaSoTaiKhoan

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

            grdViewCt_PhieuXuat.Columns["MaChuongTrinhCha"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaChuongTrinh"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaHopDong"].OptionsColumn.AllowEdit = false;
            //grdViewCt_PhieuXuat.Columns["MaNguon"].OptionsColumn.AllowEdit = false;
        }

        void UnLockGridView()
        {

            grdViewCt_PhieuXuat.Columns["MaChuongTrinhCha"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaChuongTrinh"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaHopDong"].OptionsColumn.AllowEdit = true;
            //grdViewCt_PhieuXuat.Columns["MaNguon"].OptionsColumn.AllowEdit = true;
        }

        void EventRowOrColumnChange()
        {
            if (grdViewCt_PhieuXuat.GetFocusedRow() != null)
            {
                CT_PhieuXuatBQ ct_px = (CT_PhieuXuatBQ)grdViewCt_PhieuXuat.GetFocusedRow();
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
            foreach (CT_PhieuXuatBQ ct_phieuXuat in _phieuXuat.CT_PhieuXuatList)
            {
                if (ct_phieuXuat.MaChuongTrinh == 0)
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
                else if (ct_phieuXuat.ThanhTien == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập thành tiền cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            TuDongCapNhatCPSXButToanTheoCT_PhieuXuat();
            //Kiem tra but toan
            foreach (ButToanPhieuNhapXuatBQ bt in _phieuXuat.ButToanPhieuNhapXuatList)
            {
                if (bt.NoTaiKhoan == 0 || bt.NoTaiKhoan == null || bt.CoTaiKhoan == 0 || bt.CoTaiKhoan == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Nợ Có của Định Khoản", "Yêu Cầu");
                    return false;
                }
                if (bt.SoTien == 0)
                {
                    MessageBox.Show("Vui lòng nhập Số tiền của Định Khoản", "Yêu Cầu");
                    return false;
                }

                #region Kiểm Tra chi phí sản xuất

                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan);
                string noTK = taiKhoanNo.SoHieuTK;
                string CoTK = taiKhoanCo.SoHieuTK;

                if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.StartsWith("631") || noTK.StartsWith("4314"))
                {
                    if (bt.ChungTu_ChiPhiSanXuatList.Count == 0)
                    {
                        MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        foreach (ChungTu_ChiPhiSanXuat cp in bt.ChungTu_ChiPhiSanXuatList)
                        {
                            if (cp.ButtoanMucNganSachList.Count == 0 && (noTK.StartsWith("631") || noTK.StartsWith("4314")))
                            {
                                MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

                if (bt.ChungTu_ChiPhiSanXuatList.Count > 0)
                {

                    decimal sotienCTu = 0;
                    foreach (ChungTu_ChiPhiSanXuat ct_cp in bt.ChungTu_ChiPhiSanXuatList)
                    {
                        sotienCTu += ct_cp.SoTien;
                    }
                    if (bt.SoTien != sotienCTu)
                    {
                        MessageBox.Show(this, "Tổng số tiền Công việc/Chương trình không bằng số tiền bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; ;
                    }
                }
                #endregion//Kiểm Tra chi phí sản xuất

                #region Old
                //if (bt.ChungTu_ChiPhiSanXuatList.Count > 0)
                //{

                //    decimal sotienCTu = 0;
                //    foreach (ChungTu_ChiPhiSanXuat ct_cp in bt.ChungTu_ChiPhiSanXuatList)
                //    {
                //        sotienCTu += ct_cp.SoTien;
                //    }
                //    if (bt.SoTien != sotienCTu)
                //    {
                //        kq = false;
                //        MessageBox.Show(this, "Tổng số tiền Công việc/Chương trình không bằng số tiền bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        break;
                //    }
                //}
                #endregion//Old
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
            if (_phieuXuat.ButToanPhieuNhapXuatList.Count > 0)
            {
                //
                foreach (ButToanPhieuNhapXuatBQ bt in _phieuXuat.ButToanPhieuNhapXuatList)
                {
                    #region tinh tongtien but toan so sanh gia tri chungtu
                    if (bt.SoHieuTaiKhoanCo.Length >= 4)
                    {
                        if (bt.SoHieuTaiKhoanCo.Substring(0, 4) == "1552")
                        {
                            tongTienButToan += bt.SoTien;
                            coTK1552 = true;
                        }
                    }
                    #endregion //tinh tongtien but toan so sanh gia tri chungtu

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

        #region Vat Tu_Ban Quyen
        private void anHiencottheoyeucau()
        {
            this.colMaTieuMuc.Visible = false;
            this.col_btn.Visible = true;
        }
        private void formatGridviewDinhKhoan()
        {
            if (!_phieuXuat.IsNew)
            {
                if (_phieuXuat.ButToanPhieuNhapXuatList.Count > 0)
                {
                    foreach (ButToanPhieuNhapXuatBQ bt in _phieuXuat.ButToanPhieuNhapXuatList)
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

        private decimal TongTienTheoChuongTrinhPhieu(int maChuongTrinh)
        {
            decimal tongtien = 0;
            foreach (CT_PhieuXuatBQ ct in _phieuXuat.CT_PhieuXuatList)
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
            foreach (ButToanPhieuNhapXuatBQ buttoan in _phieuXuat.ButToanPhieuNhapXuatList)
            {
                CT_PhieuXuatBQList list = _phieuXuat.CT_PhieuXuatList;
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
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;

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
                    if (PhieuNhapXuatBQ.KiemTraPhieuXuatThangTuPhieuNhap(_phieuXuat.MaPhieuNhapXuat))
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

            formatGridviewDinhKhoan();
            grdView_DinhKhoan.OptionsView.ShowFooter = true;
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdView_DinhKhoan, new string[] { "SoTien" }, "{0:#,###.##}");

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
            _coTKBiKhoa = false;
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
            if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                return;
            }
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
                        if (_phieuXuat.IsNew)
                        {
                            ktphieutrung = PhieuNhapXuatBQ.CheckSoPhieuNhapXuat(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.SoPhieu, true);
                        }
                        else//k phai IS NEW
                        {
                            ktphieutrung = PhieuNhapXuatBQ.CheckSoPhieuNhapXuat(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.SoPhieu, false);
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
                                        if (PhieuNhapXuatBQ.KiemTraPhieuXuatThangTuPhieuNhap(_phieuXuat.MaPhieuNhapXuat))
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
                CT_PhieuXuatBQ _ct_PhieuXuat = (CT_PhieuXuatBQ)cTPhieuXuatListBindingSource.Current;
                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHangHoa")
                {
                    cTPhieuXuatListBindingSource.ResetItem(cTPhieuXuatListBindingSource.Position);
                    _ct_PhieuXuat.MaChuongTrinh = 0;
                }

                else if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaChuongTrinhCon")
                {
                    grdCT_PhieuXuat.Update();
                    ChuongTrinh_New chuongTrinh = ChuongTrinh_New.GetChuongTrinh_New(_ct_PhieuXuat.MaChuongTrinh);
                    int maCtCha = chuongTrinh.MaChuongTrinhCha;
                    if (maCtCha != 0)
                    {
                        _ct_PhieuXuat.MaChuongTrinhCha = maCtCha;
                    }
                    else
                    {
                        _ct_PhieuXuat.MaChuongTrinhCha = _ct_PhieuXuat.MaChuongTrinh;
                    }
                    _ct_PhieuXuat.MaDonViTinh = chuongTrinh.MaDonViTinh;
                    _ct_PhieuXuat.ThoiLuong = chuongTrinh.ThoiLuong;
                    if (_phieuXuat.PhuongPhapNX == 1)
                    {
                        //_soLuongHienCo = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _soLuongHienCo = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                        //_ct_PhieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);
                        //_ct_PhieuXuat.DonGia = ChuongTrinh_NewBQ.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.DonGia = ChuongTrinh_NewBQ.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);
                    }

                }
                else if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHopDong")
                {
                    grdCT_PhieuXuat.Update();
                    if (_phieuXuat.PhuongPhapNX == 1)
                    {
                        _soLuongHienCo = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX); //=ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                        _ct_PhieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX); //=ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        _ct_PhieuXuat.DonGia = ChuongTrinh_NewBQ.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);//= ChuongTrinh_NewBQ.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                    }

                }
                //if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaNguon")
                //{
                //    grdCT_PhieuXuat.Update();
                //    if (_phieuXuat.PhuongPhapNX == 1)
                //    {
                //        _soLuongHienCo = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX); //=ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                //        _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                //        _ct_PhieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX); //= ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                //        _ct_PhieuXuat.DonGia = ChuongTrinh_NewBQ.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);//= ChuongTrinh_NewBQ.GetGiaBinhQuanChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                //    }

                //}
                else if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colSoLuong")
                {
                    decimal soluong_gv = 0;
                    if (decimal.TryParse(e.Value.ToString(), out soluong_gv))
                    {
                        if (_ct_PhieuXuat.MaPhieuNhap == 0)//Trong T/H Xuat Tu DS Ton
                        {
                            _soLuongHienCo = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);//= ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                            if (soluong_gv > _soLuongHienCo)
                            {
                                MessageBox.Show("Số lượng còn " + _soLuongHienCo.ToString() + ". Không đủ xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                                _ct_PhieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);//= ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                            }
                            else if (soluong_gv == _soLuongHienCo)
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX);// = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                            }
                            else
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                            }

                        }//END Trong T/H Xuat Tu DS Ton
                        else //Xuat tu Phieu Nhap
                        {
                            decimal soLuongTon_NXT = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX,_ct_PhieuXuat.MaChiTietPhieuNhap);//= ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                            //decimal soLuongTon_NXT = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyenTheoMaChiTietPhieuNhap_NXT(_phieuXuat.MaPhieuNhapXuat, _ct_PhieuXuat.MaChiTietPhieuNhap, _phieuXuat.NgayNX);
                            if (soluong_gv > soLuongTon_NXT)
                            {
                                MessageBox.Show("Số lượng xuất vượt quá chi tiết nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)soLuongTon_NXT);
                            }
                            else if (soluong_gv == soLuongTon_NXT)
                            {
                                _ct_PhieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX,_ct_PhieuXuat.MaChiTietPhieuNhap);//= ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                                //_ct_PhieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyenTheoMaChiTietPhieuNhap_NXT(_phieuXuat.MaPhieuNhapXuat,_ct_PhieuXuat.MaChiTietPhieuNhap, _phieuXuat.NgayNX);
                                //if (soluong_gv == 1)
                                //{
                                //    _ct_PhieuXuat.DonGia = _ct_PhieuXuat.ThanhTien;
                                //}
                            }
                            else
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                            }

                        }//End Xuat tu Phieu Nhap
                    }//IF thay doi tren cot So Luong

                }
                else if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colThanhTien")
                {
                    decimal soluong_gv = 0;
                    decimal thanhtien_gv = 0;
                    if (decimal.TryParse(e.Value.ToString(), out thanhtien_gv))
                    {
                        soluong_gv = _ct_PhieuXuat.SoLuong;
                        decimal soLuongTon_NXT = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX, _ct_PhieuXuat.MaChiTietPhieuNhap);//= ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        decimal giaTriTon_NXT = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX, _ct_PhieuXuat.MaChiTietPhieuNhap);//= ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                        //decimal soLuongTon_NXT = ChuongTrinh_NewBQ.GetSoLuongChuongTrinhBanQuyenTheoMaChiTietPhieuNhap_NXT(_phieuXuat.MaPhieuNhapXuat, _ct_PhieuXuat.MaChiTietPhieuNhap, _phieuXuat.NgayNX);
                        if (soluong_gv == soLuongTon_NXT)
                        {
                            if (thanhtien_gv != giaTriTon_NXT)
                            {
                                MessageBox.Show("Thành tiền không hợp lệ!", "Thông Báo");
                                _ct_PhieuXuat.ThanhTien = ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _phieuXuat.NgayNX, _ct_PhieuXuat.MaChiTietPhieuNhap);//= ChuongTrinh_NewBQ.GetGiaTriChuongTrinhBanQuyen_NXT(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaChuongTrinh, _ct_PhieuXuat.MaHopDong, _ct_PhieuXuat.MaNguon, _phieuXuat.NgayNX);
                            }
                        }
                    }
 
                }
                //Cap Nhat Gia Tri Kho
                Decimal tongTien = 0;
                foreach (CT_PhieuXuatBQ ct_PhieuXuat in _phieuXuat.CT_PhieuXuatList)
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
                FrmLoadPhieuNhapBanQuyenBQList frm = new FrmLoadPhieuNhapBanQuyenBQList(_phieuXuat);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    _ct_PhieuNhapListChon = frm.CT_PhieuNhapListChon;//M
                    if (_ct_PhieuNhapListChon.Count != 0)//M
                    {

                        #region New
                        foreach (CT_PhieuNhapBQ ct_PhieuNhap in _ct_PhieuNhapListChon)
                        {
                            long maHopDong = 0;
                            NhapXuat_HopDongList nx_HopDongList = NhapXuat_HopDongList.GetNhapXuat_HopDongList(ct_PhieuNhap.MaPhieuNhap);
                            if (nx_HopDongList.Count != 0)
                                maHopDong = nx_HopDongList[0].MaHopDong;
                            //cho t/h Binh Quan & Xuat Thang
                            if (ct_PhieuNhap.SoLuong > ct_PhieuNhap.SoLuongXuat)
                            {
                                CT_PhieuXuatBQ ct_PhieuXuat = new CT_PhieuXuatBQ(ct_PhieuNhap, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.PhuongPhapNX, maHopDong, _phieuXuat.NgayNX);
                                bool insert = true;
                                if (grdViewCt_PhieuXuat.RowCount > 0)
                                {
                                    //DataRow[] rows = new DataRow[grdViewCt_PhieuXuat.RowCount];
                                    for (int i = 0; i < grdViewCt_PhieuXuat.RowCount; i++)
                                    {
                                        if (grdViewCt_PhieuXuat.GetRow(i) != null)
                                        {
                                            CT_PhieuXuatBQ ct_px_gv = (CT_PhieuXuatBQ)grdViewCt_PhieuXuat.GetRow(i);
                                            if (
                                                //ct_px_gv.MaChuongTrinh == ct_PhieuXuat.MaChuongTrinh
                                                //    && ct_px_gv.MaHopDong == ct_PhieuXuat.MaHopDong
                                                ////&& ct_px_gv.MaNguon == ct_PhieuXuat.MaNguon
                                                //     && ct_px_gv.MaPhieuNhap == ct_PhieuXuat.MaPhieuNhap
                                                //&& 
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
                                    _phieuXuat.CT_PhieuXuatList.Add(ct_PhieuXuat);
                                }

                            }
                            else
                            {
                                ChuongTrinh_New _chuongTrinh = ChuongTrinh_New.GetChuongTrinh_New(ct_PhieuNhap.MaChuongTrinh);
                                MessageBox.Show("Chi tiết của \"" + _chuongTrinh.TenChuongTrinh + "\" đã xuất hết!");
                            }
                        }
                        #endregion //End New
                        //Set lai Gia Tri Kho
                        Decimal tongTien = 0;
                        foreach (CT_PhieuXuatBQ _ct_px in _phieuXuat.CT_PhieuXuatList)
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
            ButToanPhieuNhapXuatBQ butToan = (ButToanPhieuNhapXuatBQ)(butToanPhieuNhapXuatListBindingSource.Current);
            decimal soTienConLai = _phieuXuat.GiaTriKho;
            foreach (ButToanPhieuNhapXuatBQ buttoanphieu in _phieuXuat.ButToanPhieuNhapXuatList)
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
                    cm.CommandText = "Spd_PhieuXuatBanQuyen_BQ";
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
                foreach (CT_PhieuXuatBQ ct_PhieuXuat in _phieuXuat.CT_PhieuXuatList)
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
            CT_PhieuXuatBQ _ct_PhieuXuat = (CT_PhieuXuatBQ)cTPhieuXuatListBindingSource.Current;
            _ct_PhieuXuat.DienGiai = _phieuXuat.DienGiai;

        }

        private void btnSaoChepChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSPhieuNhapXuatBanQuyenBQ frm = new frmDSPhieuNhapXuatBanQuyenBQ(1, false);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                _phieuXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat(frm.PhieuNhapXuat, dateEdit_NgayLap.DateTime);
                //
                _phieuXuat.LaNhap = false;
                _phieuXuat.Loai = 1;
                _phieuXuat.SoPhieu = PhieuNhapXuatBQ.SetSoPhieuNhapXuat(_phieuXuat.Loai, _phieuXuat.LaNhap, _phieuXuat.NgayNX);
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
                    FrmChuongTrinhBanQuyenBQListCheck frm = new FrmChuongTrinhBanQuyenBQListCheck(_phieuXuat);
                    if (frm.ShowDialog() != DialogResult.OK)
                    {
                        _chuongTrinhBanQuyenConListChon = frm.ChuongTrinhBanQuyenConListChon;//M
                        if (_chuongTrinhBanQuyenConListChon.Count != 0)//M
                        {
                            foreach (ChuongTrinh_NewBQ _ctbq in _chuongTrinhBanQuyenConListChon)
                            {
                                CT_PhieuXuatBQ ct_PhieuXuat = CT_PhieuXuatBQ.NewCT_PhieuXuat(_ctbq, _phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaPhongBan, _phieuXuat.MaKho, _phieuXuat.NgayNX, _phieuXuat.DienGiai);
                                //
                                bool insert = true;
                                if (grdViewCt_PhieuXuat.RowCount > 0)
                                {
                                    //DataRow[] rows = new DataRow[grdViewCt_PhieuXuat.RowCount];
                                    for (int i = 0; i < grdViewCt_PhieuXuat.RowCount; i++)
                                    {
                                        if (grdViewCt_PhieuXuat.GetRow(i) != null)
                                        {
                                            CT_PhieuXuatBQ ct_px_gv = (CT_PhieuXuatBQ)grdViewCt_PhieuXuat.GetRow(i);
                                            if (ct_px_gv.MaChuongTrinh == ct_PhieuXuat.MaChuongTrinh
                                                    && ct_px_gv.MaHopDong == ct_PhieuXuat.MaHopDong
                                                //&& ct_px_gv.MaNguon == ct_PhieuXuat.MaNguon
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
                            foreach (CT_PhieuXuatBQ ct_PhieuXuat in _phieuXuat.CT_PhieuXuatList)
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
            PhieuNhapXuatBQ pnx = _phieuXuat;
            if (pnx != null)
            {
                if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
                {
                    MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                    return;
                }
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
                        PhieuNhapXuatBQ.DeletePhieuNhapXuat(_phieuXuat);
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
                    CT_PhieuXuatBQ _ct_PhieuXuat = (CT_PhieuXuatBQ)cTPhieuXuatListBindingSource.Current;
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
                    #region Edit bug
                    ChungTu_ChiPhiSanXuatList cpList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
                    foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat in ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList)
                    {
                        cpList.Add(chungTu_ChiPhiSanXuat);
                    }
                    //ChungTu_ChiPhiSanXuatList cpList = ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList;
                    #endregion//Edit bug
                    
                    cpList.BeginEdit();
                    frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuXuat.NgayNX, bt.DienGiai, bt.MaButToan);
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
