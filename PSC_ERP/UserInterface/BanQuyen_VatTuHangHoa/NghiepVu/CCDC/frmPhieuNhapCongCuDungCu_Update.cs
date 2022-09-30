using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Common;
using System.Data.OleDb;
using System.IO;
using DevExpress.XtraGrid.Columns;

namespace PSC_ERP
{
    public partial class frmPhieuNhapCongCuDungCu_Update : XtraForm
    {
        PhieuNhapXuat _phieuNhap = PhieuNhapXuat.NewPhieuNhapXuat();
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        HangHoaBQ_VTList _hangHoaListFul;
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        KhoBQ_VTList _khoBQ_VTList = KhoBQ_VTList.NewKhoBQ_VTList();
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        ChungTu_HoaDonList _chungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        //Add to 11012013
        DateTime _ngayLapCu;
        bool isLoadCboNhanVien = false;
        private bool isThayDoiSoLieu = false;
        string _FileNameImport = "";
        DataSet _dataSet = new DataSet();
        private DataTable tblHangHoa;
        //End Add to 11012013
        //
        #region BS KhoaSoTK
        private bool _isCellValuechangeBT = true;
        private bool _coTKBiKhoa = false;
        #endregion//BS KhoaSoTK
        PhieuNhapXuatCCDCList _phieuNhapXuatList = PhieuNhapXuatCCDCList.NewPhieuNhapXuatList();
        private BindingSource LoaiThueSuatListBindingSource = new BindingSource();

        public frmPhieuNhapCongCuDungCu_Update()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
        }

        #region frmPhieuNhapCongCuDungCu(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuNhapCongCuDungCu_Update(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }

        public frmPhieuNhapCongCuDungCu_Update(long maPhieuNhap)
        {
            InitializeComponent();
            KhoiTao();
            PhieuNhapXuat phieunhapccdc = PhieuNhapXuat.GetPhieuNhapXuat(maPhieuNhap);
            KhoiTaoPhieu(phieunhapccdc);
        }
        #endregion

        private void Event()
        {
            linkLabel1.LinkClicked += linkLabel_LinkClicked;
            linkLabel2.LinkClicked += linkLabel_LinkClicked;
            linkLabel3.LinkClicked += linkLabel_LinkClicked;
            linkLabel4.LinkClicked += linkLabel_LinkClicked;
            linkLabel5.LinkClicked += linkLabel_LinkClicked;
            linkLabel6.LinkClicked += linkLabel_LinkClicked;
            linkLabel7.LinkClicked += linkLabel_LinkClicked;
            linkLabel8.LinkClicked += linkLabel_LinkClicked;
            linkLabel9.LinkClicked += linkLabel_LinkClicked;
        }

        void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            long target = Convert.ToInt64(e.Link.LinkData);

            PhieuNhapXuatCCDC phieuXuat = PhieuNhapXuatCCDC.GetPhieuNhapXuat(target);
            frmPhieuXuatPhanBoCCDC_Update frm = new frmPhieuXuatPhanBoCCDC_Update(phieuXuat, 0);
            frm.ShowDialog();

            txtSoPhieu_EditValueChanged(sender, e);
        }

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuNhap = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuNhap.Loai = 3;//loai nhap xuat cong cu dung cu
            _phieuNhap.PhuongPhapNX = 3;//CCDC quản lý
            cTPhieuNhapListBindingSource.DataSource = _phieuNhap.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhap.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhap.HoaDon_NhapXuatList;

            _phieuNhap.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhap;
            _phieuNhap.LaNhap = true;
            //tao so chung tu
            TaoSoPhieu();
            if (_khoBQ_VTList.Count != 0)
                _phieuNhap.MaKho = _khoBQ_VTList[0].MaKho;
            //if (_boPhanList.Count != 0)
            //    _phieuNhap.MaPhongBan = _boPhanList[0].MaBoPhan;
            btn_ImportCT.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void TaoSoPhieu()
        {
            //   _phieuNhap.SoPhieu = PhieuNhapXuat.Get_NextSoChungTuNhapXuatCongCuDungCu(laNhap: _phieuNhap.LaNhap
            //, maBoPhan: ERP_Library.Security.CurrentUser.Info.MaBoPhan
            //, maQLUser: ERP_Library.Security.CurrentUser.Info.MaQLUser
            //, year: _phieuNhap.NgayNX.Year, size: 4);
            _phieuNhap.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhap.Loai, _phieuNhap.LaNhap, _phieuNhap.NgayNX);
        }
        #endregion

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            _phieuNhap = phieuNhapXuat;
            cTPhieuNhapListBindingSource.DataSource = _phieuNhap.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhap.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhap.HoaDon_NhapXuatList;

            _phieuNhap.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhap;
            _phieuNhap.LaNhap = true;
            //Add to 11012013
            _ngayLapCu = _phieuNhap.NgayNX;
            _coTKBiKhoa = CheckCoTaiKhoanBiKhoaTrongButToan();
            //End Add to 11012013
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhap.ButToanPhieuNhapXuatList)
            {
                #region Modify TKThue
                if (IsTaiKhoanThueKhauTru(_butToan.NoTaiKhoan))
                {
                    foreach (ChungTu_HoaDon ct_hd in _butToan.ChungTu_HoaDonList)
                        _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                }
                #endregion Modify TKThue
                #region TK ThueOld
                //HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                //if (taiKhoan.SoHieuTK.StartsWith("3113"))
                //    foreach (ChungTu_HoaDon ct_hd in _butToan.ChungTu_HoaDonList)
                //        _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd)); 
                #endregion TKThueOld
            }
            Event();
            btn_ImportCT.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            //PhieuNhapXuatList_bindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            _boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();//.GetBoPhanList();
            boPhanListBindingSource.DataSource = _boPhanList;

            BoPhanList boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            boPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource_PhanBo.DataSource = boPhanList;

            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(3);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;

            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            doiTacNoListBindingSource.DataSource = _DoiTacList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            Init_lookUpEdit_PhongBan();

            //Loai Thue VAT
            LoaiThueSuatListBindingSource.DataSource = LoaiThueSuatVAT.CreateListLoaiThueSuatVAT();
            DesignGrid_grdViewCt_PhieuNhap();
        }
        #endregion

        private void Init_lookUpEdit_PPNXKho()
        {
            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(0, "<<Không chọn>>");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");
            _dataTable.Rows.Add(3, "CCDC quản lý");

            phuongPhapNXbindingSource_TimKiem.DataSource = _dataTable;
            lookUpEdit_PPNXKho_TimKiem.Properties.DataSource = phuongPhapNXbindingSource_TimKiem;
            this.lookUpEdit_PPNXKho_TimKiem.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho_TimKiem.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho_TimKiem.Properties.NullText = "Không Chọn";
        }

        private void KhoiTaoThongTinTimKiem()
        {
            // BoPhanList _BoPhanList = BoPhanList.GetBoPhanList();
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource_TimKiem.DataSource = _BoPhanList;
            KhoBQ_VTList _KhoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList();
            KhoBQ_VT _KhoBQ_VT = KhoBQ_VT.NewKhoBQ_VT();
            _KhoBQ_VT.TenKho = "Không Chọn";
            _KhoBQ_VTList.Insert(0, _KhoBQ_VT);
            khoBQVTListBindingSource_TimKiem.DataSource = _KhoBQ_VTList;
            Init_lookUpEdit_PPNXKho();
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;

            thongTinNhanVienTongHopListBindingSource_TimKiem.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListByTen(0);
            //
            boPhanListBindingSource1.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            thongTinNhanVienTongHopListBindingSource1.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            khoBQVTListBindingSource1.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
        }

        #region KhoaSoTaiKhoan
        private bool CheckCoTaiKhoanBiKhoaTrongButToan()
        {
            foreach (ButToanPhieuNhapXuat buttoan in _phieuNhap.ButToanPhieuNhapXuatList)
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
                _phieuNhap.NgayNX = _ngayLapCu;
                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                return false;
            }
            return true;
        }

        private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        {

            bool khoataiKhoan = false;
            KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _phieuNhap.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoataiKhoan = true;
                }
            }

            if (khoataiKhoan == false && _phieuNhap.IsNew == false)
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
                ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetFocusedRow();
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

        private bool CheckValidWhenChangeNgayNX()//Them
        {
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhap.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show("Đã khóa sổ, không thể thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!CCDC.KiemTraThaoTacCCDCHopLe(_phieuNhap.NgayNX))
            {
                MessageBox.Show(string.Format("Đã thực hiện kết chuyển sang năm {0}, không thể thực hiện!", (_phieuNhap.NgayNX.Year + 1).ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_phieuNhap.IsNew == false)
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

        #region BoSung KhoaSoThue
        private void FormatFormTheoKhoaSoThue()
        {
            //if (KhoaSoThue())
            //{
            //    btn_HoaDon.Enabled = false;
            //    if (_phieuNhap.IsNew)
            //    {
            //        _phieuNhap.HoaDon_NhapXuatList.Clear();
            //    }
            //}
            //else
            //{
            //    btn_HoaDon.Enabled = true;
            //}
        }//Them

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

        private bool CheckCoTaiKhoanThueTrongButToan()
        {
            foreach (ButToanPhieuNhapXuat buttoan in _phieuNhap.ButToanPhieuNhapXuatList)
            {
                #region Modify TKThue
                if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                {
                    return true;
                }
                #endregion Modify TKThue
                #region TKThue Old
                //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                //if (tk.SoHieuTK.StartsWith("3113"))
                //{
                //    return true;
                //} 
                #endregion TKThue Old
            }
            return false;
        }//Them

        private bool KhoaSoThue()
        {
            bool khoasothue = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhap.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSoThue == true)
                {
                    khoasothue = true;
                }
            }
            //
            if (khoasothue == false && _phieuNhap.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSoThue == true)
                    {
                        khoasothue = true;
                    }
                }
            }
            return khoasothue;
        }//Them

        private bool CheckValidKhoaSoThueWhenChangeNgayNX()//Them
        {
            if (_phieuNhap.IsNew == false)
            {
                bool khoasotheoNgaylapcu = false;
                bool khoasotheoNgayNX = false;
                //duyet  theo ngay lap cu
                KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSoThue == true)
                    {
                        khoasotheoNgaylapcu = true;
                    }
                }

                if (khoasotheoNgaylapcu)
                {
                    foreach (ButToanPhieuNhapXuat buttoan in _phieuNhap.ButToanPhieuNhapXuatList)
                    {
                        #region Modify TKThue
                        if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                        {
                            MessageBox.Show("Ngày lập phiếu đã Khóa sổ Thuế, không thể thay đổi", "Thông Báo");
                            _phieuNhap.NgayNX = _ngayLapCu;
                            dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                            return false;
                        }
                        #endregion Modify TKThue
                        #region TkThue OLd
                        //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                        //if (tk.SoHieuTK.StartsWith("3113"))
                        //{
                        //    MessageBox.Show("Ngày lập phiếu đã Khóa sổ Thuế, không thể thay đổi", "Thông Báo");
                        //    _phieuNhap.NgayNX = _ngayLapCu;
                        //    dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                        //    return false;
                        //} 
                        #endregion TkThue Old
                    }
                }
                else
                {
                    //duyet  theo ngay nhap xuat
                    KhoaSo_UserList khoa_NgayNX = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhap.NgayNX);
                    if (khoa_NgayNX.Count > 0)
                    {
                        if (khoa_NgayNX[0].KhoaSoThue == true)
                        {
                            khoasotheoNgayNX = true;
                        }
                    }

                    if (khoasotheoNgayNX)
                    {
                        foreach (ButToanPhieuNhapXuat buttoan in _phieuNhap.ButToanPhieuNhapXuatList)
                        {
                            #region Modify TKThue
                            if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                            {
                                MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa sổ Thuế, không thể thực hiện", "Thông Báo");
                                _phieuNhap.NgayNX = _ngayLapCu;
                                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                                return false;
                            }
                            #endregion Modify TKThue
                            #region TKThue Old
                            //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                            //if (tk.SoHieuTK.StartsWith("3113"))
                            //{
                            //    MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa sổ Thuế, không thể thực hiện", "Thông Báo");
                            //    _phieuNhap.NgayNX = _ngayLapCu;
                            //    dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                            //    return false;
                            //} 
                            #endregion TKThue Old
                        }
                    }

                }
            }

            return true;
        }

        #endregion//BoSung KhoaSoThue

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            //if (lookUpEdit_PhongBan.EditValue != null)
            //{
            //   int mabophabout;
            //    if (int.TryParse(lookUpEdit_PhongBan.EditValue.ToString(), out mabophabout))
            //    {
            //        LoadDataForthongTinNhanVienTongHopListBindingSource(mabophabout);
            //    }
            //    //_phieuNhap.MaPhongBan = (int)lookUpEdit_PhongBan.EditValue;
            //    //_phieuNhap.MaPhongBan = mabophabout;
            //}
        }

        private void LoadDataForthongTinNhanVienTongHopListBindingSource(int maboPHan)
        {
            ThongTinNhanVienTongHopList thongtinnhanvienlist = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan(maboPHan);
            ThongTinNhanVienTongHop ttnv = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<<None>>");
            thongtinnhanvienlist.Insert(0, ttnv);
            thongTinNhanVienTongHopListBindingSource.DataSource = thongtinnhanvienlist;
        }

        private void LoadAllNhanVien()
        {
            isLoadCboNhanVien = false;
            ThongTinNhanVienTongHopList thongtinnhanvienlist = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan(0);
            ThongTinNhanVienTongHop ttnv = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<<None>>");
            thongtinnhanvienlist.Insert(0, ttnv);
            thongTinNhanVienTongHopListBindingSource.DataSource = thongtinnhanvienlist;
            isLoadCboNhanVien = true;
        }

        #endregion

        private void Init_lookUpEdit_PhongBan()
        {
            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(2, "Nhập xuất thẳng");
            _dataTable.Rows.Add(3, "CCDC quản lý");

            phuongPhapNXbindingSource.DataSource = _dataTable;
            lookUpEdit_PPNXKho.Properties.DataSource = phuongPhapNXbindingSource;
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.Properties.NullText = "<<chọn PPNX>>";
            lookUpEdit_PPNXKho.EditValue = 2;
        }

        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuNhap ct_phieuNhap in _phieuNhap.CT_PhieuNhapList)
            {
                if (ct_phieuNhap.SoLuong == 0)
                    kq = false;
            }
            return kq;
        }

        private bool KiemTraHopLe()
        {
            int tmp;
            if (!CheckValidWhenChangeNgayNX()) return false;
            if (_phieuNhap.XacNhan == true)//Kiem Tra Thu Kho Xac Nhan
            {
                MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrEmpty(txtSoPhieu.Text))
            {
                txtSoPhieu.Focus();
                MessageBox.Show(this, "Số phiếu không thể rỗng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            //else if (false == int.TryParse(txtSoPhieu.Text.Substring(0, 4), out tmp))
            //{
            //    txtSoPhieu.Focus();
            //    MessageBox.Show("Số phiếu không hợp lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;

            //}
            else if (true == PhieuNhapXuat.KiemTraTrungSoChungTuNhapXuat(_phieuNhap.MaPhieuNhapXuat, _phieuNhap.SoPhieu))//IF 5
            {
                txtSoPhieu.Focus();
                MessageBox.Show("Trùng số phiếu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;

            }
            else if (_phieuNhap.MaDoiTac == 0)
            {
                lookUpEdit_DoiTac.Focus();
                MessageBox.Show(this, "Vui lòng chọn Nhà cung cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (_phieuNhap.MaPhongBan == 0)
            {
                lookUpEdit_PhongBan.Focus();
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //chi Tú yeu cau nguoi ban giao co the de trong nen vai dong duoi day khong duoc sd nua
            //////else if (_phieuNhap.MaNguoiNhapXuat == 0)
            //////{
            //////    MessageBox.Show(this, "Vui long chọn nguoi ban giao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //////    lookUpEdit_NhanVien.Focus();
            //////}
            else if (_phieuNhap.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoNhan.Focus();
                return false;
            }
            else if (_phieuNhap.CT_PhieuNhapList.Count == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (KiemTraChiTiet() == false)
            {
                MessageBox.Show(this, "Vui lòng nhập số lượng chi tiết phiếu xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            ///////////////////////////////
            //kiem tra dinh khoan
            {
                //_phieuNhap.ButToanPhieuNhapXuatList
                foreach (ButToanPhieuNhapXuat bt in _phieuNhap.ButToanPhieuNhapXuatList)
                {
                    if (bt.MaDoiTuongCo != _phieuNhap.MaDoiTac)
                    {
                        MessageBox.Show(this, "Đối tượng trong bút toán định khoản hiện không giống đối tượng Nhà cung cấp của phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                return;
            }
            //End Add to 11012013
            Save();
        }

        private bool Save()
        {
            bool result = true;//mac dinh la true
            this.txtBlackHole.Focus();
            phieuNhapXuatBindingSource.EndEdit();
            try
            {
                if (KiemTraHopLe() == true)
                {
                    if (_phieuNhap.ButToanPhieuNhapXuatList.Count == 0)
                    {
                        MessageBox.Show("Chứng từ chưa được hạch toán, bạn vui lòng hạch toán!");
                        return false;
                        //if (System.Windows.Forms.DialogResult.Yes != MessageBox.Show("Chưa nhập định khoản! Bạn có muốn lưu phiếu với định khoản rỗng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        //{
                        //    result = false;//khong chap nhan luu trong khi dinh khoan chua nhap
                        //}
                    }
                    else
                    {
                        result = KiemTraButToanHoaDon();
                    }

                    if (result == true)//
                    {
                        _phieuNhap.ApplyEdit();
                        _phieuNhap.Save();
                        //Add to 11012013
                        _ngayLapCu = _phieuNhap.NgayNX;
                        //End Add to 11012013
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (_phieuNhap.PhuongPhapNX == 2)//phuong phap nhap xuat thang
                        //{
                        //    long giaTri = PhieuNhapXuat.KiemTraPhieu(_phieuNhap.MaPhieuNhapXuat);
                        //    if (giaTri == 0)
                        //    {
                        //        if (MessageBox.Show("Bạn Có Muốn Lập Phiếu Xuất?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        //        {
                        //            PhieuNhapXuatCCDC phieunhap = PhieuNhapXuatCCDC.GetPhieuNhapXuat(_phieuNhap.MaPhieuNhapXuat);
                        //            frmPhieuXuatPhanBoCCDC_Update frm = new frmPhieuXuatPhanBoCCDC_Update(phieunhap, 1);
                        //            frm.Show();
                        //        }
                        //    }
                        //}
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show("Cập Nhật Thất Bại!\n"+ ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //
            return result;
        }

        private bool KiemTraButToanHoaDon()
        {
            foreach (ButToanPhieuNhapXuat butToan in _phieuNhap.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                string noTK = taiKhoanNo.SoHieuTK;
                string CoTK = taiKhoanCo.SoHieuTK;
                #region Kiểm tra  hóa đơn
                #region Modify TKThue
                if (IsTaiKhoanThueKhauTru(butToan.NoTaiKhoan))
                {
                    if (butToan.ChungTu_HoaDonList.Count == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn hóa đơn cho bút toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        decimal tongTienHoaDon = 0;
                        foreach (ChungTu_HoaDon ct_hd in butToan.ChungTu_HoaDonList)
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
                #endregion Modify TKThue
                #region TKThue Old
                //if (taiKhoanNo.SoHieuTK.StartsWith("3113"))
                //{
                //    if (butToan.ChungTu_HoaDonList.Count == 0)
                //    {
                //        MessageBox.Show(this, "Vui lòng chọn hóa đơn cho bút toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //    else
                //    {
                //        decimal tongTienHoaDon = 0;
                //        foreach (ChungTu_HoaDon ct_hd in butToan.ChungTu_HoaDonList)
                //        {
                //            tongTienHoaDon += ct_hd.SoTien;
                //        }
                //        if (tongTienHoaDon != butToan.SoTien)
                //        {
                //            MessageBox.Show(this, "Gía trị hạch toán tài khoản thuế không bằng tổng giá trị các hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //            return false;
                //        }
                //    }
                //} 
                #endregion TKThue Old
                #endregion//Kiểm tra  hóa đơn

                #region Kiểm Tra chi phí sản xuất

                if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.StartsWith("631") || noTK.StartsWith("4314"))
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
                            if (cp.ButtoanMucNganSachList.Count == 0 && (noTK.StartsWith("631") || noTK.StartsWith("4314")))
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

        private void Show_colMaDoiTuongNo()
        {
            this.colMaDoiTuongNo.Visible = true;
            this.colMaDoiTuongNo.VisibleIndex = 3;
            this.colMaDoiTuongNo.Width = 190;
        }

        private void LoadInfoByMaPhieuNhapXuat(long maPhieu)
        {
            PhieuNhapXuat phieuNhap = PhieuNhapXuat.GetPhieuNhapXuat(maPhieu);
            KhoiTaoPhieu(phieuNhap);
            xtraTabControl2.SelectedTabPageIndex = 0;
            //CheckPhieuNhap();
            LoadLinkLabel((int)maPhieu);
        }

        private void DuyetButToanToShowDoiTuong_ButToan()
        {
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhap.ButToanPhieuNhapXuatList)
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
            if (!_phieuNhap.IsNew)
            {
                if (_phieuNhap.ButToanPhieuNhapXuatList.Count > 0)
                {
                    DuyetButToanToShowDoiTuong_ButToan();
                }
            }
        }

        private void CheckHideShowDoiTuong_ButToan()
        {
            ButToanPhieuNhapXuat _butToan = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
            HeThongTaiKhoan1 httkNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
            if (httkNo.CoDoiTuongTheoDoi)
            {
                Show_colMaDoiTuongNo();
                //((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = _phieuNhap.MaDoiTac;
            }
            else
            {
                this.colMaDoiTuongNo.Visible = false;
                ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = 0;
                DuyetButToanToShowDoiTuong_ButToan();
            }
        }

        private void Unlock_LockConTrol(bool unlock)
        {
            if (unlock)
            {
                lookUpEdit_PPNXKho.Enabled = true;
                HamDungChung.AllowEditColumnChooseGridViewDev(grdViewCt_PhieuNhap, new string[] { "MaHangHoa", "ThanhTien", "SoLuong", "DonGia", "MoTaTenCCDC" });
            }
            else
            {
                lookUpEdit_PPNXKho.Enabled = false;
                HamDungChung.ReadOnlyColumnChoseGridViewDev(grdViewCt_PhieuNhap, new string[] { "MaHangHoa", "ThanhTien", "SoLuong", "DonGia", "MoTaTenCCDC" });
            }
        }

        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            phieuNhapXuatBindingSource.EndEdit();
            frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhap);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (frm.TrangThai == true)
                {
                    _phieuNhap.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                    _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
                    foreach (ButToanPhieuNhapXuat _butToan in _phieuNhap.ButToanPhieuNhapXuatList)
                    {
                        #region Modify TKThue
                        if (IsTaiKhoanThueKhauTru(_butToan.NoTaiKhoan))
                        {
                            _butToan.ChungTu_HoaDonList.Clear();
                            foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                                _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                        }
                        #endregion Modify TKThue
                        #region TKThue Old
                        //HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                        //if (taiKhoan.SoHieuTK.StartsWith("3113") && !(KhoaSoThue()))
                        //{
                        //    _butToan.ChungTu_HoaDonList.Clear();
                        //    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                        //        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

                        //} 
                        #endregion TKThue Old
                    }
                    _phieuNhap.ApplyEdit();
                    _phieuNhap.Save();
                }
            }
            #region Old
            //if (_phieuNhap.IsNew || _phieuNhap.HoaDon_NhapXuatList.Count == 0)
            //{
            //    frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhap.MaDoiTac);
            //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        if (frm.TrangThai == true)
            //        {
            //            _phieuNhap.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
            //            _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
            //            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhap.ButToanPhieuNhapXuatList)
            //            {
            //                #region Modify TKThue
            //                if (IsTaiKhoanThueKhauTru(_butToan.NoTaiKhoan))
            //                {
            //                    _butToan.ChungTu_HoaDonList.Clear();
            //                    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            //                        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

            //                }
            //                #endregion Modify TKThue
            //                #region TKThue Old
            //                //HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan); 
            //                //if (taiKhoan.SoHieuTK.StartsWith("3113") && !(KhoaSoThue()))
            //                //{
            //                //    _butToan.ChungTu_HoaDonList.Clear();
            //                //    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            //                //        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

            //                //}
            //                #endregion TKThue Old
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhap);
            //    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    {
            //        if (frm.TrangThai == true)
            //        {
            //            _phieuNhap.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
            //            _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
            //            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhap.ButToanPhieuNhapXuatList)
            //            {
            //                #region Modify TKThue
            //                if (IsTaiKhoanThueKhauTru(_butToan.NoTaiKhoan))
            //                {
            //                    _butToan.ChungTu_HoaDonList.Clear();
            //                    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            //                        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
            //                }
            //                #endregion Modify TKThue
            //                #region TKThue Old
            //                //HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
            //                //if (taiKhoan.SoHieuTK.StartsWith("3113") && !(KhoaSoThue()))
            //                //{
            //                //    _butToan.ChungTu_HoaDonList.Clear();
            //                //    foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
            //                //        _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));

            //                //} 
            //                #endregion TKThue Old
            //            }
            //            _phieuNhap.ApplyEdit();
            //            _phieuNhap.Save();
            //        }
            //    }
            //} 
            #endregion Old
        }
        #endregion

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _coTKBiKhoa = false;
            Unlock_LockConTrol(true);
            KhoiTaoPhieu();
        }

        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            // Gan tien cho but toan
            ButToanPhieuNhapXuat butToan = (ButToanPhieuNhapXuat)(butToanPhieuNhapXuatListBindingSource.Current);
            SetDefaultValueButToan(butToan);
            #region Old
            //decimal soTienConLai = _phieuNhap.GiaTriKho;
            //foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhap.ButToanPhieuNhapXuatList)
            //{
            //    soTienConLai = soTienConLai - buttoanphieu.SoTien;
            //}
            //butToan.SoTien = soTienConLai;
            //butToan.MaDoiTuongCo = _phieuNhap.MaDoiTac;


            //butToan.DienGiai = txtDienGiai.Text; 
            #endregion Old
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!CheckValidWhenChangeNgayNX()) return;
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các bút toán định khoản đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    grdView_DinhKhoan.DeleteSelectedRows();
                }
            }
        }

        #region barBt_LapPhieuXuat_ItemClick
        private void barBt_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (_phieuNhap.IsNew)
            {
                MessageBox.Show("Vui Lòng Cập Nhật Phiếu Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                long giaTri = PhieuNhapXuat.KiemTraPhieu(_phieuNhap.MaPhieuNhapXuat);
                if (giaTri != 0)//truong hop da xuat roi, bay gio xuat tiep//
                {
                    PhieuNhapXuatCCDC phieuXuat = PhieuNhapXuatCCDC.GetPhieuNhapXuat(giaTri);

                    frmPhieuXuatPhanBoCCDC_Update frm = new frmPhieuXuatPhanBoCCDC_Update(phieuXuat, 0);
                    frm.ShowDialog();
                }
                else//==0//truong hop chua xuat lan nao
                {
                    PhieuNhapXuatCCDC phieunhap = PhieuNhapXuatCCDC.GetPhieuNhapXuat(_phieuNhap.MaPhieuNhapXuat);
                    frmPhieuXuatPhanBoCCDC_Update frm = new frmPhieuXuatPhanBoCCDC_Update(phieunhap, 1);
                    frm.ShowDialog();
                }
                if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(_phieuNhap.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
                {
                    Unlock_LockConTrol(false);
                }
            }
        }
        #endregion

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Rpt_PhieuNhapVatTu rpt = new Rpt_PhieuNhapVatTu(_phieuNhap.MaPhieuNhapXuat, _phieuNhap.NgayNX);
            //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();
            //
            //BEGIN

            ReportTemplate _report = ReportTemplate.GetReportTemplate("SpdBienBanNhapCongCuDungCu");//PhieuNhapVatTu//
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
            /*
            DataSet _DataSet = new DataSet();
            ReportDocument report;

            report = new PSC_ERP.Report.CongNo.ChungTuGhiSoA4();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_BaoCaoChungTuGhiSo_NhapCCDC";
            command.Parameters.AddWithValue("@MaChungTu", _phieuNhap.MaPhieuNhapXuat);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";
            command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "spd_LayNguoiKyTenCongNo";
            command2.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_BaoCaoChungTuGhiSo;1";
            _DataSet.Tables.Add(table);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";
            _DataSet.Tables.Add(table1);

            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            table2.TableName = "spd_LayNguoiKyTenCongNo;1";
            _DataSet.Tables.Add(table2);

            report.SetDataSource(_DataSet);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = report;
            dlg.Show();
            */
        }

        #region Cac Phuong Thuc Report
        public void SpdBienBanNhapCongCuDungCu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SpdBienBanNhapCongCuDungCu";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuNhap.MaPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", _phieuNhap.MaPhongBan);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BienBanGiaoNhanCongCuDungCu;1";
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
            }
        }
        public void Spd_PhieuNhapVatTu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuNhapVatTu";
                    cm.Parameters.AddWithValue("@MaPhieuNhap", _phieuNhap.MaPhieuNhapXuat);

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
            this.txtBlackHole.Focus();
            if (CheckValidWhenChangeNgayNX())
            {
                if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
                {
                    //foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                    //{
                    //    CT_PhieuNhap ct_Phieu = _phieuNhap.CT_PhieuNhapList[i];
                    //    _phieuNhap.GiaTriKho = _phieuNhap.GiaTriKho - ct_Phieu.ThanhTien;
                    //}
                    grdViewCt_PhieuNhap.DeleteSelectedRows();
                    CapNhatLaiTongGiaTriPhieu();
                }
                else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
                {
                    bool chophepxoa = true;
                    int[] deleteRows = grdView_DinhKhoan.GetSelectedRows();
                    foreach (int deleteRow in deleteRows)
                    {
                        ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetRow(deleteRow);
                        #region Modify TKThue
                        if (IsTaiKhoanThueKhauTru(buttoan.NoTaiKhoan))
                        {
                            if (KhoaSoThue())
                            {
                                chophepxoa = false;
                                break;
                            }
                        }
                        #endregion Modify TKThue
                        #region TkThue Old
                        //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                        //if (tk.SoHieuTK.StartsWith("3113"))
                        //{
                        //    if (KhoaSoThue())
                        //    {
                        //        chophepxoa = false;
                        //        break;
                        //    }
                        //} 
                        #endregion TkThue Old

                    }
                    if (chophepxoa)
                        grdView_DinhKhoan.DeleteSelectedRows();
                    else
                    {
                        MessageBox.Show("Đã Khóa sổ Thuế, không thể Xóa Định khoản Thuế!");
                    }
                }
            }
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(0);
            HangHoaBQ_VT hh = HangHoaBQ_VT.NewHangHoaBQ_VT();
            XtraFrm_HangHoa frm = new XtraFrm_HangHoa(hh);
            DialogResult rs = frm.ShowDialog();
            if (rs == DialogResult.OK)
            {
                hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
                if (hh != null && hh.MaHangHoa != 0)
                {
                    if (cTPhieuNhapListBindingSource.Current == null)
                        grdViewCt_PhieuNhap.AddNewRow();
                    CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                    ct_phieuNhap.MaHangHoa = hh.MaHangHoa;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                    ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;

                    grdViewCt_PhieuNhap.RefreshData();
                }
                //hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            }
            //XtraFrm_HangHoa frm = new XtraFrm_HangHoa(3);
            //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            //}
        }

        //Utils.GridUtils.GridHandlerEx _gridHandlerEx;
        private void frmPhieuNhapVatTuHangHoa_Load(object sender, EventArgs e)
        {
            LoadAllNhanVien();

            if (_phieuNhap.IsNew == false)
            {
                if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(_phieuNhap.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
                {
                    Unlock_LockConTrol(false);
                }
            }
            Utils.GridUtils.ConfigGridView(grdView_DinhKhoan
                , setSTT: true
                , initCopyCell: true
                , multiSelectCell: true
                , multiSelectRow: false
                , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(grdViewCt_PhieuNhap
                , setSTT: true
                , initCopyCell: true
                , multiSelectCell: true
                , multiSelectRow: false
                , initNewRowOnTop: false);
            FormatFormTheoKhoaSoThue();
            CheckShow_colMaDoiTuongNo_LoadPhieu();
            //_gridHandlerEx = new Utils.GridUtils.GridHandlerEx(this.grdViewCt_PhieuNhap);
            //_gridHandlerEx.KeyDown += new KeyEventHandler(_gridHandlerEx_KeyDown);
            grdv_DanhSachPhieuNhapXuat.OptionsBehavior.Editable = false;//M
            Utils.GridUtils.SetSTTForGridView(grdv_DanhSachPhieuNhapXuat, 35);//M
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
            KhoiTaoThongTinTimKiem();
        }

        void _gridHandlerEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các dòng chi tiết phiếu nhập đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                    {
                        //CT_PhieuNhap ct_Phieu = _phieuNhap.CT_PhieuNhapList[i];
                        //_phieuNhap.GiaTriKho = _phieuNhap.GiaTriKho - ct_Phieu.ThanhTien;                        
                        grdViewCt_PhieuNhap.DeleteRow(i);
                    }
                    CapNhatLaiTongGiaTriPhieu();
                }
            }
            //else if (e.KeyCode == Keys.Tab)
            //{
            //    if (grdViewCt_PhieuNhap.FocusedRowHandle < 0)
            //    {
            //        grdViewCt_PhieuNhap.MoveFirst();
            //    }
            //}
        }

        private void lookUpEdit_DoiTac_EditValueChanged(object sender, EventArgs e)
        {
            //_phieuNhap.MaDoiTac = (long)lookUpEdit_DoiTac.EditValue;
        }

        private void frmPhieuNhapCongCuDungCu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_phieuNhap != null && (_phieuNhap.IsDirty || _phieuNhap.IsNew))
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

        #region ButtonEdit_HoaDon_Click
        private void ButtonEdit_HoaDon_Click(object sender, EventArgs e)
        {


        }
        #endregion

        #region grdView_DinhKhoan_CellValueChanged
        private void grdView_DinhKhoan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colNoTaiKhoan")
            {
                ButToanPhieuNhapXuat _butToan = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                _butToan.ChungTu_HoaDonList.Clear();
                #region Modify TKThue
                if (IsTaiKhoanThueKhauTru(_butToan.NoTaiKhoan))
                {
                    if (KhoaSoThue())
                    {
                        MessageBox.Show("Đã khóa sổ thuế, không cập thể cập nhật thêm tài khoản thuế vào!");
                        _butToan.NoTaiKhoan = 0;
                    }
                    else
                    {
                        #region BS
                        decimal tongtienThue = 0;
                        if (_butToan != null && _butToan.SoTien == 0)
                        {
                            foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhap.CT_PhieuNhapList)
                            {
                                tongtienThue = tongtienThue + ct_PhieuNhap.TienThue;
                            }
                            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhap.ButToanPhieuNhapXuatList)
                            {
                                if (IsTaiKhoanThueKhauTru(buttoanphieu.NoTaiKhoan))
                                {
                                    tongtienThue = tongtienThue - buttoanphieu.SoTien;
                                }
                            }
                            _butToan.SoTien = tongtienThue;
                        }
                        #endregion BS
                        _butToan.ChungTu_HoaDonList.Clear();
                        foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                            _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                    }
                }
                #endregion Modify TKThue
                #region TKThue Old
                //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                //if (tk.SoHieuTK.StartsWith("3113"))
                //{
                //    if (KhoaSoThue())
                //    {
                //        MessageBox.Show("Đã khóa sổ thuế, không cập thể cập nhật thêm tài khoản thuế vào!");
                //        _butToan.NoTaiKhoan = 0;
                //    }
                //    else
                //    {
                //        _butToan.ChungTu_HoaDonList.Clear();
                //        foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                //            _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                //    }

                //} 
                #endregion TKThue Old
                CheckHideShowDoiTuong_ButToan();
            }
        }
        #endregion

        private void grdView_DinhKhoan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //EventRowOrColumnGrdView_DinhKhoanChange();
            if (grdView_DinhKhoan.FocusedColumn.Name == "colHoaDon" && !(KhoaSoThue()))
            {
                #region Modify TKThue
                if (IsTaiKhoanThueKhauTru(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan))
                {
                    frmDanhSachHoaDonDichVuPhieuXuat _frm = new frmDanhSachHoaDonDichVuPhieuXuat(_phieuNhap, _chungTu_HoaDonList, (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                    _frm.Show();
                }
                #endregion Modify TKThue
                #region TkThue Old
                //HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                //if (tk.SoHieuTK.StartsWith("3113"))
                //{
                //    frmDanhSachHoaDonDichVuPhieuXuat _frm = new frmDanhSachHoaDonDichVuPhieuXuat(_phieuNhap, _chungTu_HoaDonList, (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                //    _frm.Show();
                //} 
                #endregion TkThue Old
            }
            #region New
            if (grdView_DinhKhoan.FocusedColumn.Name == "col_btn")
            {
                if (((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current) != null)
                {
                    //Xu ly Tai day
                    ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).BeginEdit();
                    ButToanPhieuNhapXuat bt = (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current;
                    #region Edit bug
                    ChungTu_ChiPhiSanXuatList cpList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
                    foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat in ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList)
                    {
                        cpList.Add(chungTu_ChiPhiSanXuat);
                    }
                    //ChungTu_ChiPhiSanXuatList cpList = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList;
                    #endregion//Edit bug

                    cpList.BeginEdit();
                    frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuNhap.NgayNX, bt.DienGiai, bt.MaButToan);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        if (f.IsSave == true)
                        {
                            ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList = f._ChungTu_ChiPhiSXList;
                            ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList.ApplyEdit();

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

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuNhap;
            if (pnx != null)
            {
                if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
                {
                    MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                    return;
                }
                //
                if (!CheckValidWhenChangeNgayNX())
                    return;

                //
                if (KhoaSoThue())
                {
                    if (CheckCoTaiKhoanThueTrongButToan())
                    {
                        MessageBox.Show(this, "Đã khóa sổ thuế, không thể xóa phiếu, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //
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
                        PhieuNhapXuat.DeletePhieuNhapXuat(_phieuNhap);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThemMoi.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Cập Nhật Thất Bại!\n"+ ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }//End Delete Phieu
            }
            //E
        }

        #region BoSung KhoaSoThue
        private void dateEdit_NgayLap_Leave(object sender, EventArgs e)
        {
            if (dateEdit_NgayLap.OldEditValue != dateEdit_NgayLap.EditValue)
            {
                CheckValidKhoaTaiKhoanWhenChangeNgayCT();
            }
        }

        private void grdView_DinhKhoan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //EventRowOrColumnGrdView_DinhKhoanChange();
        }
        #endregion//BoSung KhoaSoThue

        #region Methods
        private bool IsTaiKhoanThueKhauTru(int mataikhoan)
        {
            if (mataikhoan == null || mataikhoan == 0) return false;
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(mataikhoan);
            if (PublicClass.KiemTraLaTaiKhoanThueKhauTru(tk.SoHieuTK))
            {
                return true;
            }
            return false;
        }

        private bool KiemTraTrungMatHang()
        {
            //CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            //foreach (CT_PhieuNhap ct in _phieuNhap.CT_PhieuNhapList)
            //{
            //    if (ct != ct_phieuNhap)
            //    {
            //        if (ct.MaHangHoa == ct_phieuNhap.MaHangHoa)
            //            return true;
            //    }
            //}
            return false;
        }

        private void DesignGrid_grdViewCt_PhieuNhap()
        {//grdViewCt_PhieuNhap            
            grdCT_PhieuNhap.DataSource = cTPhieuNhapListBindingSource;
            HamDungChung.InitGridViewDev(grdViewCt_PhieuNhap, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdViewCt_PhieuNhap, new string[] { "MaDonViTinh", "MoTaTenCCDC", "SoLuong", "DonGiaGoc", "ThanhTienGoc", "TyLeCK", "TienChietKhau", "ChiPhiMuaHang", "ThueSuatVAT", "TienThue", "ThanhTien", "ThoiLuong", "DienGiai", "MaBoPhan" },
                                new string[] { "ĐVT", "Quy cách", "Số lượng", "Đơn giá", "Thành tiền", "Tỷ lệ CK(%)", "Tiền chiết khấu", "Chi phí mua hàng", "% thuế VAT", "Tiền thuế VAT", "Tổng tiền", "TGPB (tháng)", "Ghi chú", "Mã Bộ Phận" },
                                             new int[] { 80, 90, 90, 100, 110, 90, 100, 100, 90, 100, 100, 100, 150, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdViewCt_PhieuNhap, new string[] { "MaDonViTinh", "MoTaTenCCDC", "SoLuong", "DonGiaGoc", "ThanhTienGoc", "TyLeCK", "TienChietKhau", "ChiPhiMuaHang", "ThueSuatVAT", "TienThue", "ThanhTien", "ThoiLuong", "DienGiai", "MaBoPhan" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdViewCt_PhieuNhap, new string[] { "SoLuong", "DonGiaGoc", "ThanhTienGoc", "TyLeCK", "TienChietKhau", "ChiPhiMuaHang", "TienThue", "ThanhTien", "ThoiLuong" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdViewCt_PhieuNhap, new string[] { "SoLuong", "DonGiaGoc", "ThanhTienGoc", "TyLeCK", "TienChietKhau", "ChiPhiMuaHang", "TienThue", "ThanhTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdViewCt_PhieuNhap, NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuNhap, 50);//M
            //Hang Hoa mã           
            GridColumn columnMaHangHoa = new GridColumn();
            columnMaHangHoa.Caption = "Mã CCDC";
            columnMaHangHoa.FieldName = "MaHangHoa";
            columnMaHangHoa.Width = 80;
            columnMaHangHoa.OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns.Add(columnMaHangHoa);
            RepositoryItemGridLookUpEdit HangHoa_GrdLU_Ma = new RepositoryItemGridLookUpEdit();
            HangHoa_GrdLU_Ma.ExportMode = ExportMode.DisplayText;
            HamDungChung.InitRepositoryItemGridLookUpDev2(HangHoa_GrdLU_Ma, hangHoaBQVTListBindingSource, "MaQuanLy", "MaHangHoa", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HangHoa_GrdLU_Ma, new string[] { "MaQuanLy", "TenHangHoa" }, new string[] { "Mã HH", "Tên HH" }, new int[] { 100, 200 }, false);
            columnMaHangHoa.ColumnEdit = HangHoa_GrdLU_Ma;
            //Hang Hoa tên
            GridColumn columnTenHangHoa = new GridColumn();
            columnTenHangHoa.Caption = "Công cụ dụng cụ";
            columnTenHangHoa.FieldName = "MaHangHoa";
            columnTenHangHoa.Width = 120;
            columnTenHangHoa.OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuNhap.Columns.Add(columnTenHangHoa);
            RepositoryItemGridLookUpEdit HangHoa_GrdLU = new RepositoryItemGridLookUpEdit();
            HangHoa_GrdLU.ExportMode = ExportMode.DisplayText;
            HamDungChung.InitRepositoryItemGridLookUpDev2(HangHoa_GrdLU, hangHoaBQVTListBindingSource, "TenHangHoa", "MaHangHoa", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HangHoa_GrdLU, new string[] { "MaQuanLy", "TenHangHoa" }, new string[] { "Mã HH", "Tên HH" }, new int[] { 100, 200 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "MaHangHoa", HangHoa_GrdLU);
            columnTenHangHoa.ColumnEdit = HangHoa_GrdLU;
            //DonViTinh
            RepositoryItemGridLookUpEdit DVT_GrdLU = new RepositoryItemGridLookUpEdit();
            DVT_GrdLU.ExportMode = ExportMode.DisplayText;
            HamDungChung.InitRepositoryItemGridLookUpDev2(DVT_GrdLU, donViTinhListBindingSource, "MaQuanLy", "MaDonViTinh", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DVT_GrdLU, new string[] { "MaQuanLy", "TenDonViTinh" }, new string[] { "Mã ĐVT", "Tên ĐVT" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "MaDonViTinh", DVT_GrdLU);
            //               
            columnMaHangHoa.VisibleIndex = 0;
            columnTenHangHoa.VisibleIndex = 1;
            grdViewCt_PhieuNhap.Columns["MaDonViTinh"].VisibleIndex = 2;
            grdViewCt_PhieuNhap.Columns["MoTaTenCCDC"].VisibleIndex = 3;
            grdViewCt_PhieuNhap.Columns["SoLuong"].VisibleIndex = 4;
            grdViewCt_PhieuNhap.Columns["DonGiaGoc"].VisibleIndex = 5;
            grdViewCt_PhieuNhap.Columns["ThanhTienGoc"].VisibleIndex = 6;
            grdViewCt_PhieuNhap.Columns["TyLeCK"].VisibleIndex = 7;
            grdViewCt_PhieuNhap.Columns["TienChietKhau"].VisibleIndex = 8;
            grdViewCt_PhieuNhap.Columns["ChiPhiMuaHang"].VisibleIndex = 9;
            grdViewCt_PhieuNhap.Columns["ThueSuatVAT"].VisibleIndex = 10;
            grdViewCt_PhieuNhap.Columns["TienThue"].VisibleIndex = 11;
            grdViewCt_PhieuNhap.Columns["ThanhTien"].VisibleIndex = 12;
            grdViewCt_PhieuNhap.Columns["ThoiLuong"].VisibleIndex = 13;
            grdViewCt_PhieuNhap.Columns["DienGiai"].VisibleIndex = 14;
            grdViewCt_PhieuNhap.Columns["MaBoPhan"].VisibleIndex = 15;
            //LoaiThueSuatVAT
            RepositoryItemGridLookUpEdit LoaiThueSuatVAT_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(LoaiThueSuatVAT_grdLU, LoaiThueSuatListBindingSource, "MoTa", "ThueSuat", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiThueSuatVAT_grdLU, new string[] { "MoTa" }, new string[] { "Thuế suất" }, new int[] { 90 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "ThueSuatVAT", LoaiThueSuatVAT_grdLU);
            //BoPhan
            RepositoryItemGridLookUpEdit BoPhan_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(BoPhan_GrdLU, boPhanListBindingSource_PhanBo, "TenBoPhan", "MaBoPhan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(BoPhan_GrdLU, new string[] { "MaBoPhanQL", "TenBoPhan" }, new string[] { "Mã QL", "Tên Bộ Phận" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuNhap, "MaBoPhan", BoPhan_GrdLU);
            BoPhan_GrdLU.ExportMode = ExportMode.DisplayText;
            #region Dinh Dang Danh So
            //Dinh Dang Danh So
            //"DonGia", "ThanhTien", "ChiPhiMuaHang"
            RepositoryItemCalcEdit repositoryItemCalcEditDonGia = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditDonGia.AutoHeight = false;
            repositoryItemCalcEditDonGia.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditDonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditDonGia.Name = "repositoryItemCalcEditSoTien";
            grdViewCt_PhieuNhap.Columns["DonGiaGoc"].ColumnEdit = repositoryItemCalcEditDonGia;
            //ThanhTien
            RepositoryItemCalcEdit repositoryItemCalcEditThanhTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditThanhTien.AutoHeight = false;
            repositoryItemCalcEditThanhTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditThanhTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditThanhTien.Name = "repositoryItemCalcEditThanhTien";
            grdViewCt_PhieuNhap.Columns["ThanhTienGoc"].ColumnEdit = repositoryItemCalcEditThanhTien;
            //ChiPhiMuaHang
            RepositoryItemCalcEdit repositoryItemCalcEditChiPhiMuaHang = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditChiPhiMuaHang.AutoHeight = false;
            repositoryItemCalcEditChiPhiMuaHang.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditChiPhiMuaHang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditChiPhiMuaHang.Name = "repositoryItemCalcEditChiPhiMuaHang";
            grdViewCt_PhieuNhap.Columns["ChiPhiMuaHang"].ColumnEdit = repositoryItemCalcEditChiPhiMuaHang;
            //thời gian phân bổ
            RepositoryItemCalcEdit repositoryItemCalcEditThoiGianPB = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditThoiGianPB.AutoHeight = false;
            repositoryItemCalcEditThoiGianPB.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditThoiGianPB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditThoiGianPB.Name = "repositoryItemCalcEditThoiGianPB";
            grdViewCt_PhieuNhap.Columns["ThoiLuong"].ColumnEdit = repositoryItemCalcEditThoiGianPB;
            #endregion Dinh Dang Danh So
            //
            this.grdViewCt_PhieuNhap.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdViewCt_PhieuNhap_CellValueChanged);
            this.grdViewCt_PhieuNhap.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdViewCt_PhieuNhap_KeyDown);
            this.grdViewCt_PhieuNhap.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdViewCt_PhieuNhap_InitNewRow);

            //
            this.grdCT_PhieuNhap.ContextMenuStrip = this.contextMenuStrip_HangHoa;
        }

        private void SetDefaultValueButToan(ButToanPhieuNhapXuat butToan)
        {
            decimal tongtienCP = 0;
            decimal tongtienThue = 0;
            if (butToan != null)
            {
                foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhap.CT_PhieuNhapList)
                {
                    tongtienCP += ct_PhieuNhap.ThanhTien;
                    tongtienThue = tongtienThue + ct_PhieuNhap.TienThue;
                }
                foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhap.ButToanPhieuNhapXuatList)
                {
                    if (IsTaiKhoanThueKhauTru(buttoanphieu.NoTaiKhoan))
                    {
                        tongtienThue = tongtienThue - buttoanphieu.SoTien;
                    }
                    else
                    {
                        tongtienCP = tongtienCP - buttoanphieu.SoTien;
                    }
                }
                if (IsTaiKhoanThueKhauTru(butToan.NoTaiKhoan))
                {
                    butToan.SoTien = tongtienThue;
                }
                else
                {
                    butToan.SoTien = tongtienCP;
                }
                butToan.MaDoiTuongCo = _phieuNhap.MaDoiTac;
                butToan.DienGiai = _phieuNhap.DienGiai;
            }
        }

        private void CapNhatLaiTongGiaTriPhieu()
        {
            Decimal tongTien = 0;
            foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhap.CT_PhieuNhapList)
            {
                tongTien += Math.Round(ct_PhieuNhap.ThanhTien, 0, MidpointRounding.AwayFromZero);
            }
            _phieuNhap.GiaTriKho = tongTien;
        }

        #endregion//Method

        #region EventHandles
        #region grdViewCt_PhieuNhap_CellValueChanged
        private void grdViewCt_PhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colThanhTien")
            {
                grdCT_PhieuNhap.Update();
                ////tinh tong tien phieu nhap
                //Decimal tongTien = 0;
                //foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhap.CT_PhieuNhapList)
                //{
                //    tongTien = tongTien + ct_PhieuNhap.ThanhTien;
                //}
                //_phieuNhap.GiaTriKho = tongTien;
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa")
            {
                if (KiemTraTrungMatHang())
                {
                    MessageBox.Show("Trùng mặt hàng, không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ct_phieuNhap.MaHangHoa = 0;
                }
                if (ct_phieuNhap.MaHangHoa != 0)
                {
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                    ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                    ct_phieuNhap.ThoiLuong = hangHoa.ThoiLuong;
                }
                //grdViewCt_PhieuNhap.RefreshData();
            }
            CapNhatLaiTongGiaTriPhieu();
            this.isThayDoiSoLieu = true;
        }
        #endregion

        private void grdViewCt_PhieuNhap_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            ct_phieuNhap.DienGiai = _phieuNhap.DienGiai;
            if (grdViewCt_PhieuNhap.RowCount > 1)
            {
                CT_PhieuNhap dongtren = grdViewCt_PhieuNhap.GetRow(0) as CT_PhieuNhap;
                ct_phieuNhap.ThueSuatVAT = dongtren.ThueSuatVAT;
            }
        }

        private void grdViewCt_PhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (!CheckValidWhenChangeNgayNX()) return;
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các dòng chi tiết phiếu nhập đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                    {
                        //CT_PhieuNhap ct_Phieu = _phieuNhap.CT_PhieuNhapList[i];
                        //_phieuNhap.GiaTriKho = _phieuNhap.GiaTriKho - ct_Phieu.ThanhTien;
                        grdViewCt_PhieuNhap.DeleteRow(i);
                    }
                    CapNhatLaiTongGiaTriPhieu();
                }
            }
        }
        #endregion EventHandles

        private void barbtnItemInNXT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //IN Phieu Nhap Vat Tu
            //BEGIN
            ReportTemplate _report;
            _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu_XuatThang");
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

        private void barBtnItemInCCDCQuanLy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("SpdBienBanNhapCongCuDungCu");//PhieuNhapVatTu//
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

        private void lookUpEdit_NhanVien_EditValueChanged(object sender, EventArgs e)
        {
            if (isLoadCboNhanVien == false)
                return;

            long maNhanVien = (long)lookUpEdit_NhanVien.EditValue;
            if (maNhanVien != 0)
            {
                NhanVien objNV = NhanVien.GetNhanVien(maNhanVien);
                lookUpEdit_PhongBan.EditValue = objNV.MaBoPhan;
                this._phieuNhap.MaNguoiNhapXuat = maNhanVien;
            }
        }

        private void LoadLinkLabel(int _maPhieuNhap)
        {
            int MaPhieu = _maPhieuNhap;
            DataTable dt = PhieuNhapXuatList.GetPhieuXuatByPhieuNhap(MaPhieu, 1);
            int i = 0;
            //int _loca = 30;
            linkLabel1.Visible = false;
            linkLabel2.Visible = false;
            linkLabel3.Visible = false;
            linkLabel4.Visible = false;
            linkLabel5.Visible = false;
            linkLabel6.Visible = false;
            linkLabel7.Visible = false;
            linkLabel8.Visible = false;
            linkLabel9.Visible = false;
            for (int j = 1; j <= dt.Rows.Count; j++)
            {
                if (j == 1)
                    linkLabel1.Visible = true;
                else if (j == 2)
                    linkLabel2.Visible = true;
                else if (j == 3)
                    linkLabel3.Visible = true;
                else if (j == 4)
                    linkLabel4.Visible = true;
                else if (j == 5)
                    linkLabel5.Visible = true;
                else if (j == 6)
                    linkLabel6.Visible = true;
                else if (j == 7)
                    linkLabel7.Visible = true;
                else if (j == 8)
                    linkLabel8.Visible = true;
                else if (j == 9)
                    linkLabel9.Visible = true;
            }

            foreach (DataRow dr in dt.Rows)
            {
                int index = i + 1;
                if (index == 1)
                {
                    linkLabel1.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel1.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel1.Links.Add(link);
                }
                else if (index == 2)
                {
                    linkLabel2.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel2.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel2.Links.Add(link);
                }
                else if (index == 3)
                {
                    linkLabel3.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel3.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel3.Links.Add(link);
                }
                else if (index == 4)
                {
                    linkLabel4.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel4.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel4.Links.Add(link);
                }
                else if (index == 5)
                {
                    linkLabel5.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel5.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel5.Links.Add(link);
                }
                else if (index == 6)
                {
                    linkLabel6.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel6.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel6.Links.Add(link);
                }
                else if (index == 7)
                {
                    linkLabel7.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel7.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel7.Links.Add(link);
                }
                else if (index == 8)
                {
                    linkLabel8.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel8.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel8.Links.Add(link);
                }
                else if (index == 9)
                {
                    linkLabel9.Text = dr["SoPhieuXuat"].ToString();
                    linkLabel9.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["MaPhieuNhapXuat"].ToString();
                    linkLabel9.Links.Add(link);
                }
                i++;
            }
        }

        private void txtSoPhieu_EditValueChanged(object sender, EventArgs e)
        {
            int MaPhieu = PhieuNhapXuatList.GetMaPhieuBySoPhieu(txtSoPhieu.EditValue.ToString());
            LoadLinkLabel(MaPhieu);
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (checkEdit_Ngay.Checked == true)
            {
                _phieuNhapXuatList = PhieuNhapXuatCCDCList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan_TimKiem.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien_TimKiem.EditValue), Convert.ToInt32(lookUpEdit_PhongBan_TimKiem.EditValue), Convert.ToByte(lookUpEdit_PPNXKho_TimKiem.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, true, 3, UserId);
            }
            else
            {
                _phieuNhapXuatList = PhieuNhapXuatCCDCList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan_TimKiem.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien_TimKiem.EditValue), Convert.ToInt32(lookUpEdit_PhongBan_TimKiem.EditValue), Convert.ToByte(lookUpEdit_PPNXKho_TimKiem.EditValue), true, 3, UserId);
            }
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
            if (_phieuNhapXuatList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
        }

        private void grdv_DanhSachPhieuNhapXuat_DoubleClick(object sender, EventArgs e)
        {
            PhieuNhapXuatCCDC phieuNhapXuat = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuNhapXuatCCDC;
            LoadInfoByMaPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
        }

        private void AllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void NotAllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                AllowDelete();

                if (this.isThayDoiSoLieu == true || this._phieuNhap.ButToanPhieuNhapXuatList.Count == 0)
                {
                    //if (this._phieuNhapXuat.ButToanPhieuNhapXuatList.Count == 0)
                    //{
                    ButToanPhieuNhapXuat bt = ButToanPhieuNhapXuat.NewButToanPhieuNhapXuat();
                    int tkNo = HeThongTaiKhoan1.LayMaTaiKhoan("1531");//sửa lại theo yêu cầu chị Trang ngày 01/07/2019
                    int tkCo = HeThongTaiKhoan1.LayMaTaiKhoan("331");
                    bt.NoTaiKhoan = tkNo;
                    bt.CoTaiKhoan = tkCo;
                    bt.DienGiai = _phieuNhap.DienGiai;
                    bt.MaDoiTuongCo = this._phieuNhap.MaDoiTac;
                    bt.SoTien = this._phieuNhap.GiaTriKho;
                    this._phieuNhap.ButToanPhieuNhapXuatList.Add(bt);
                    //butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
                    //}
                    this.isThayDoiSoLieu = false;
                }
            }
            else if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(_phieuNhap.MaPhieuNhapXuat))
            {
                NotAllowDelete();
            }
        }

        private void btn_ExportExcelDS_Click(object sender, EventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.grdv_DanhSachPhieuNhapXuat, showOpenFilePrompt: true);
        }

        private void btn_ExportChiTietPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.grdViewCt_PhieuNhap, showOpenFilePrompt: true);
        }

        private int KiemTraTonTaiHangHoa(string MaQLHangHoa)
        {
            _hangHoaListFul = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
            foreach (HangHoaBQ_VT item in _hangHoaListFul)
            {
                if (item.MaQuanLy.ToUpper() == MaQLHangHoa.ToUpper())
                {
                    return item.MaHangHoa;
                }
            }
            return 0;
        }

        private int KiemTraTonTaiBoPhan(string MaQLBoPhan)
        {
            foreach (BoPhan boPhan in BoPhanList.GetBoPhanListKeCaBoPhanMoRong())
            {
                if (boPhan.MaBoPhanQL.ToUpper() == MaQLBoPhan.ToUpper())
                {
                    return boPhan.MaBoPhan;
                }
            }
            return 0;
        }

        private DataSet ImportExcelXLSToDataset(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";

            _dataSet = new DataSet();
            DataTable outputTable = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (sheet == "Sheet1$" && !sheet.EndsWith("_"))
                    {
                        try
                        {
                            outputTable = new DataTable();
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A1:O]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            outputTable.TableName = "HangHoa";
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                            _dataSet.Tables.Add(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return _dataSet;
        }

        private void btn_ImportCT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _FileNameImport = "";
                OpenFileDialog oFD = new OpenFileDialog();
                oFD.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                oFD.ShowDialog();
                string path = oFD.FileName;
                string p = System.IO.Path.GetFileName(path);
                _FileNameImport = p;
                DataSet dsRerult = ImportExcelXLSToDataset(path, true);
                ImportToHangHoaFromDataSet(dsRerult);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đọc file!\n"+ ex.Message, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ImportToHangHoaFromDataSet(DataSet dsresult)
        {
            _phieuNhap.CT_PhieuNhapList.Clear();
            StringBuilder mainLog = new StringBuilder();
            int STT = 0, STTLoi = 0, soLuong;
            decimal donGia, thanhTien, tyLeCK, tienCK, chiPhiMuaHang, thueVat, tienThueVat, tongTien;
            String mota = "", ghiChu;
            if (dsresult.Tables.Count == 0) return;
            tblHangHoa = new DataTable();
            tblHangHoa = dsresult.Tables["HangHoa"];
            if (tblHangHoa.Rows.Count > 0)
            {
                foreach (DataRow rowhd in tblHangHoa.Rows)
                {
                    STT++;
                    int maHangHoa = 0, maBoPhan = 0;
                    donGia = 0; thanhTien = 0; soLuong = 0;
                    tyLeCK = 0; tienCK = 0; chiPhiMuaHang = 0; thueVat = 0; tienThueVat = 0; tongTien = 0;
                    mota = null; ghiChu = null;
                    StringBuilder errorLog = new StringBuilder();
                    if (rowhd[0].ToString().Trim().Length == 0)
                    {
                        errorLog.AppendLine("Mã hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    }
                    else
                    {
                        maHangHoa = KiemTraTonTaiHangHoa(rowhd[0].ToString().Trim());
                        if (maHangHoa == 0)
                        {
                            errorLog.AppendLine("Mã hàng hóa, vật tư, công cụ dụng cụ Chưa có trong phần mềm!\nVui lòng tạo mã hàng hóa, vật tư, công cụ dụng cụ trong phần mềm!");
                        }
                    }
                    if (rowhd[4].ToString().Trim().Length == 0)//số lượng
                    {
                        errorLog.AppendLine("Số lượng hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    }
                    else
                    {
                        bool kq = int.TryParse(rowhd[4].ToString().Trim(), out soLuong);
                        if (kq == false)
                            errorLog.AppendLine("Số lượng không đúng định dạng!");
                    }
                    if (rowhd[5].ToString().Trim().Length != 0)//đơn giá
                    {
                        bool kq = decimal.TryParse(rowhd[5].ToString().Trim(), out donGia);
                        if (kq == false)
                            errorLog.AppendLine("Đơn giá không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Đơn giá hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}
                    if (rowhd[6].ToString().Trim().Length != 0)//thành tiền
                    {
                        bool kq = decimal.TryParse(rowhd[6].ToString().Trim(), out thanhTien);
                        if (kq == false)
                            errorLog.AppendLine("Thành tiền không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Thành tiền hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[7].ToString().Trim().Length != 0)//tỷ lệ chiết khấu
                    {
                        bool kq = decimal.TryParse(rowhd[7].ToString().Trim(), out tyLeCK);
                        if (kq == false)
                            errorLog.AppendLine("Tỷ lệ chiết khấu không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Tỷ lệ chiết khấu hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[8].ToString().Trim().Length != 0)//tiền chiết khấu
                    {
                        bool kq = decimal.TryParse(rowhd[8].ToString().Trim(), out tienCK);
                        if (kq == false)
                            errorLog.AppendLine("Tiền chiết khấu không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Tiền chiết khấu hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[9].ToString().Trim().Length != 0)//chi phí mua hàng
                    {
                        bool kq = decimal.TryParse(rowhd[9].ToString().Trim(), out chiPhiMuaHang);
                        if (kq == false)
                            errorLog.AppendLine("Chi phí mua hàng không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Chi phí mua hàng hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[10].ToString().Trim().Length != 0)//thuế Vat
                    {
                        bool kq = decimal.TryParse(rowhd[10].ToString().Trim(), out thueVat);
                        if (kq == false)
                            errorLog.AppendLine("Thuế VAT không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Thuế VAT hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[11].ToString().Trim().Length != 0)//tiền thuế Vat
                    {
                        bool kq = decimal.TryParse(rowhd[11].ToString().Trim(), out tienThueVat);
                        if (kq == false)
                            errorLog.AppendLine("Tiền thuế VAT không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Tiền thuế VAT hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[12].ToString().Trim().Length != 0)//tổng tiền = thành tiền
                    {
                        bool kq = decimal.TryParse(rowhd[12].ToString().Trim(), out tongTien);
                        if (kq == false)
                            errorLog.AppendLine("Tổng tiền không đúng định dạng!");
                    }
                    //else
                    //{
                    //    errorLog.AppendLine("Tổng tiền hàng hóa, vật tư, công cụ dụng cụ không được để trống!");
                    //}

                    if (rowhd[14].ToString().Trim().Length != 0)//bộ phận
                    {
                        maBoPhan = KiemTraTonTaiBoPhan(rowhd[14].ToString().Trim());
                        if (maBoPhan == 0)
                            errorLog.AppendLine("Không tồn tại mã phòng ban trong phần mềm!");
                    }
                    mota = rowhd[3].ToString();
                    ghiChu = rowhd[13].ToString().Trim();
                    if (errorLog.Length > 0)
                    {
                        STTLoi++;
                        mainLog.AppendLine(STTLoi + ") -------------------------------");
                        mainLog.AppendLine("- STT: " + STT + " có mã :" + rowhd[0].ToString().Trim());
                        mainLog.AppendLine(errorLog.ToString());
                    }
                    else
                    {
                        grdViewCt_PhieuNhap.AddNewRow();
                        CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                        ct_phieuNhap.MaHangHoa = maHangHoa;
                        ct_phieuNhap.MaDonViTinh = DonViTinh.GetDonViTinh(HangHoaBQ_VT.GetHangHoaBQ_VT(maHangHoa).MaDonViTinh).MaDonViTinh;
                        ct_phieuNhap.MoTaTenCCDC = mota;
                        ct_phieuNhap.DienGiai = rowhd[1].ToString().Trim() + ghiChu;
                        ct_phieuNhap.SoLuong = soLuong;
                        ct_phieuNhap.DonGiaGoc = Math.Round(donGia, 0, MidpointRounding.AwayFromZero);
                        ct_phieuNhap.ThanhTienGoc = Math.Round(thanhTien, 0, MidpointRounding.AwayFromZero);
                        ct_phieuNhap.TyLeCK = (double)tyLeCK;
                        ct_phieuNhap.TienChietKhau = tienCK;
                        ct_phieuNhap.ChiPhiMuaHang = chiPhiMuaHang;
                        ct_phieuNhap.ThueSuatVAT = (double)thueVat;
                        ct_phieuNhap.TienThue = Math.Round(tienThueVat, 0, MidpointRounding.AwayFromZero);
                        ct_phieuNhap.ThanhTien = Math.Round(tongTien, 0, MidpointRounding.AwayFromZero);
                        ct_phieuNhap.ThoiLuong = HangHoaBQ_VT.GetHangHoaBQ_VT(maHangHoa).ThoiLuong;
                        if (maBoPhan != 0)
                            ct_phieuNhap.MaBoPhan = maBoPhan;
                    }
                }//end forech
                if (mainLog.Length > 0)
                {
                    _phieuNhap.CT_PhieuNhapList.Clear();
                    const string tenFile = "Import_Log.txt";
                    //FileStream fileStream = File.Open(tenFile, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                    StreamWriter writer = new StreamWriter(tenFile);
                    writer.WriteLine(mainLog.ToString());
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                    //mở file log
                    System.Diagnostics.Process.Start(tenFile);
                }
            }
            txtBlackHole.Focus();
            CapNhatLaiTongGiaTriPhieu();
        }

    }
}