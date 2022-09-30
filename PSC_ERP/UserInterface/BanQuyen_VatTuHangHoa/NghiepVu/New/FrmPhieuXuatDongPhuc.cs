using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Common;
//22/09/2014
namespace PSC_ERP
{
    public partial class FrmPhieuXuatDongPhuc : XtraForm
    {
        #region Properties

        PhieuNhapXuatList _phieuNhapXuatList = PhieuNhapXuatList.NewPhieuNhapXuatList();
        PhieuNhapXuat _phieuXuatVTHH;
        CT_PhieuNhapList _ct_PhieuNhapListChon;//
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _doiTacList;
        Int16 _loaiPhieu = 0;
        //bool _flag = true;
        bool _daChonPhieuNhap = false;
        decimal _soLuongHienCo = 0;//M
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        KhoBQ_VTList _khoBQ_VTList = KhoBQ_VTList.NewKhoBQ_VTList();
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        PhieuLinhNhienLieuList _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
        PhieuLinhNhienLieuList _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
        bool _checkXemLaiPhieuXuat = false;
        //Add to 11012013
        DateTime _ngayLapCu;
        int _maKhoCu;
        //End Add to 11012013
        bool _phieuTuDSPhieuNhapXuat = false;
        bool _tu1PhieuNhap = false;
        bool _edtiBophan = true;
        int _loaiPhieuDeNghi = 0;

        PhieuDeNghiXuatDongPhucList _phieuDeNghiList = PhieuDeNghiXuatDongPhucList.NewPhieuDeNghiXuatDongPhucList();

        #region BS KhoaSoTK
        private bool _isCellValuechangeBT = true;
        private bool _coTKBiKhoa = false;
        #endregion//BS KhoaSoTK
        private BindingSource LoaiThueSuatListBindingSource = new BindingSource();
        private Guid _oidBienLai = Guid.NewGuid();
        private int _idBienLai = 0;
        private bool isThayDoiSoLieu = false;
        private bool blnIsLoadCboPhieuDeNghi = false;
        #endregion Properties
        //
        #region  Functions
        private void GanBindingSource()
        {
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            bdPhieuDeNghiList.DataSource = _phieuDeNghiList;
        }
        private bool KiemTraLapTuBienLaiHopLe(List<ChiTietXuatKhoFromOtherDB> chitietxuatkholistSelected)
        {
            _oidBienLai = Guid.NewGuid();
            _idBienLai = 0;
            foreach (CT_PhieuXuat itemct_px in _phieuXuatVTHH.CT_PhieuXuatList)
            {
                if (itemct_px.OidMaBienLai != Guid.Empty)
                {
                    _oidBienLai = itemct_px.OidMaBienLai;
                }
                if (itemct_px.IDBienLai != 0)
                {
                    _idBienLai = itemct_px.IDBienLai;
                }
            }
            if (_oidBienLai == Guid.Empty) _oidBienLai = chitietxuatkholistSelected[0].MaBienLai;
            if (_idBienLai == 0) _idBienLai = chitietxuatkholistSelected[0].MaBienLaiInt;
            foreach (ChiTietXuatKhoFromOtherDB ctbienlai in chitietxuatkholistSelected)
            {
                if (_idBienLai == 0 && _oidBienLai != Guid.Empty && ctbienlai.MaBienLai != _oidBienLai)//Không Cùng bienlai
                {
                    MessageBox.Show("Không cùng Biên lai xuất kho!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (_oidBienLai == Guid.Empty && _idBienLai != 0 && ctbienlai.MaBienLaiInt != _idBienLai)//Không Cùng bienlai
                {
                    MessageBox.Show("Không cùng Biên lai xuất kho!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        private void LapChiTietXuatKhotuBienLai()
        {
            #region Process
            FrmGetChiTietXuatKhoFromOtherDB frm = new FrmGetChiTietXuatKhoFromOtherDB("");
            if (frm.ShowDialog() != DialogResult.OK)
            {
                StringBuilder diengiai = new StringBuilder("");
                long MaDoiTac = 0;
                List<ChiTietXuatKhoFromOtherDB> chitietxuatkholistSelected = frm.ChiTietXuatKhoListSelected;//M
                if (chitietxuatkholistSelected.Count != 0)//M
                {
                    lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
                    NhomHangHoaBQ_VT nhomHangHoaIns = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();
                    HangHoaBQ_VTList hanghoaListByMaNhom = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
                    StringBuilder soBienLaiStr = new StringBuilder("");
                    foreach (ChiTietXuatKhoFromOtherDB ctbienlai in chitietxuatkholistSelected)
                    {
                        bool insert = true;
                        if (_phieuXuatVTHH.CT_PhieuXuatList.Count > 0)
                        {
                            //foreach (CT_ChungTuBienLaiChild item in _ChungTu.CT_ChungTuBienLaiList)
                            foreach (CT_PhieuXuat item in _phieuXuatVTHH.CT_PhieuXuatList)
                            {
                                if (
                                    (ctbienlai.MaBienLai != Guid.Empty && item.OidMaBienLai == ctbienlai.MaBienLai && item.OidChiTietBienLai == ctbienlai.MaChiTiet)
                                     ||
                                     (ctbienlai.MaBienLaiInt != 0 && item.IDBienLai == ctbienlai.MaBienLaiInt && item.IDChiTietBienLai == ctbienlai.MaChiTietInt)
                                    )
                                {
                                    insert = false;
                                    break;
                                }
                            }

                        }//grdViewCt_PhieuXuat.RowCount > 0

                        if (insert)
                        {
                            //Tao thanhTien
                            diengiai.Append(string.Format("{0},", ctbienlai.DienGiai));
                            if (soBienLaiStr.ToString().Contains(ctbienlai.SoBienLai) == false)
                            {
                                soBienLaiStr.Append(string.Format("{0},", ctbienlai.SoBienLai));
                            }
                            MaDoiTac = ctbienlai.MaDoiTuongInt;
                            #region Tao CT_PhieuXuat
                            CT_PhieuXuat ctpxAdd = CT_PhieuXuat.NewCT_PhieuXuat();
                            nhomHangHoaIns = NhomHangHoaBQ_VT.GetNhomHangHoaBQ_VT(ctbienlai.DienGiai);
                            if (nhomHangHoaIns != null && nhomHangHoaIns.MaNhomHangHoa != 0)
                            {
                                //hanghoaListByMaNhom = HangHoaBQ_VTList.GetHangHoaBQ_VTListByMaNhom(nhomHangHoaIns.MaNhomHangHoa);
                                ctpxAdd.MaNhomHangHoa = nhomHangHoaIns.MaNhomHangHoa;
                                //ctpxAdd.MaHangHoa = hanghoaListByMaNhom[0].MaHangHoa;
                            }
                            ctpxAdd.SoLuong = ctbienlai.SoLuong;
                            ctpxAdd.OidMaBienLai = ctbienlai.MaBienLai;
                            ctpxAdd.OidChiTietBienLai = ctbienlai.MaChiTiet;
                            ctpxAdd.IDBienLai = ctbienlai.MaBienLaiInt;
                            ctpxAdd.IDChiTietBienLai = ctbienlai.MaChiTietInt;
                            ctpxAdd.DienGiai = ctbienlai.DienGiai;
                            _phieuXuatVTHH.CT_PhieuXuatList.Add(ctpxAdd);
                            #endregion Tao CT_PhieuXuat
                        }
                    }

                    _phieuXuatVTHH.DienGiai = String.Format("Xuất kho cho biên lai: {0}", soBienLaiStr);
                    _phieuXuatVTHH.MaDoiTac = MaDoiTac;
                }
            }
            #endregion//Process
            GanBindingSource();

        }

        private void DesignGrid_grdViewCt_PhieuXuat()
        {//grdViewCt_PhieuXuat
            grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
            HamDungChung.InitGridViewDev(grdViewCt_PhieuXuat, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdViewCt_PhieuXuat, new string[] { "MaNhomHangHoa", "MaHangHoa", "MaDonViTinh"/*, "MoTaTenCCDC"*/, "SoLuong", "DonGia", "ThanhTien", "DienGiai", "SoPhieuNhap" },
                                new string[] { "Nhóm HH", "Hàng Hóa Vật Tư", "ĐVT"/*, "Quy cách"*/, "Số lượng", "Đơn giá", "Thành tiền", "Ghi chú", "Phiếu nhập tương ứng" },
                                             new int[] { 120, 120, 80, 90, /*90,*/ 100, 110, 150, 100 });


            HamDungChung.AlignHeaderColumnGridViewDev(grdViewCt_PhieuXuat, new string[] { "MaNhomHangHoa", "MaHangHoa", "MaDonViTinh"/*, "MoTaTenCCDC"*/, "SoLuong", "DonGia", "ThanhTien", "DienGiai", "SoPhieuNhap" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdViewCt_PhieuXuat, new string[] { "SoLuong", "DonGia", "ThanhTien" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdViewCt_PhieuXuat, new string[] { "SoLuong", "ThanhTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdViewCt_PhieuXuat, NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuXuat, 50);//M

            //Nhom HangHoa
            RepositoryItemGridLookUpEdit nhomHangHoa_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(nhomHangHoa_GrdLU, bs_NhomHangHoaList, "TenNhomHangHoa", "MaNhomHangHoa", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(nhomHangHoa_GrdLU, new string[] { "MaQuanLy", "TenNhomHangHoa" }, new string[] { "Mã", "Tên nhóm HH" }, new int[] { 100, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuXuat, "MaNhomHangHoa", nhomHangHoa_GrdLU);
            //Hang Hoa
            RepositoryItemGridLookUpEdit HangHoa_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(HangHoa_GrdLU, hangHoaBQVTListBindingSource, "TenHangHoa", "MaHangHoa", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(HangHoa_GrdLU, new string[] { "MaQuanLy", "TenHangHoa" }, new string[] { "Mã HH", "Tên HH" }, new int[] { 100, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuXuat, "MaHangHoa", HangHoa_GrdLU);
            HangHoa_GrdLU.Popup += new System.EventHandler(this.HangHoa_GrdLU_Popup);
            //DonViTinh
            RepositoryItemGridLookUpEdit DVT_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DVT_GrdLU, donViTinhListBindingSource, "MaQuanLy", "MaDonViTinh", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DVT_GrdLU, new string[] { "MaQuanLy", "TenDonViTinh" }, new string[] { "Mã ĐVT", "Tên ĐVT" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuXuat, "MaDonViTinh", DVT_GrdLU);
            //
            ////LoaiThueSuatVAT
            //RepositoryItemGridLookUpEdit LoaiThueSuatVAT_grdLU = new RepositoryItemGridLookUpEdit();
            //HamDungChung.InitRepositoryItemGridLookUpDev2(LoaiThueSuatVAT_grdLU, LoaiThueSuatListBindingSource, "MoTa", "ThueSuat", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiThueSuatVAT_grdLU, new string[] { "MoTa" }, new string[] { "Thuế suất" }, new int[] { 90 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(grdViewCt_PhieuXuat, "ThueSuatVAT", LoaiThueSuatVAT_grdLU);

            #region Dinh Dang Danh So
            //Dinh Dang Danh So
            //"DonGia", "ThanhTien", "ChiPhiMuaHang"
            RepositoryItemCalcEdit repositoryItemCalcEditDonGia = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditDonGia.AutoHeight = false;
            repositoryItemCalcEditDonGia.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditDonGia.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditDonGia.Name = "repositoryItemCalcEditSoTien";
            grdViewCt_PhieuXuat.Columns["DonGia"].ColumnEdit = repositoryItemCalcEditDonGia;
            //ThanhTien
            RepositoryItemCalcEdit repositoryItemCalcEditThanhTien = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            repositoryItemCalcEditThanhTien.AutoHeight = false;
            repositoryItemCalcEditThanhTien.DisplayFormat.FormatString = "{0:#,###.##}";
            repositoryItemCalcEditThanhTien.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            repositoryItemCalcEditThanhTien.Name = "repositoryItemCalcEditSoTien";
            grdViewCt_PhieuXuat.Columns["ThanhTien"].ColumnEdit = repositoryItemCalcEditThanhTien;
            ////ChiPhiMuaHang
            //RepositoryItemCalcEdit repositoryItemCalcEditChiPhiMuaHang = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            //repositoryItemCalcEditChiPhiMuaHang.AutoHeight = false;
            //repositoryItemCalcEditChiPhiMuaHang.DisplayFormat.FormatString = "{0:#,###.##}";
            //repositoryItemCalcEditChiPhiMuaHang.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            //repositoryItemCalcEditChiPhiMuaHang.Name = "repositoryItemCalcEditSoTien";
            //grdViewCt_PhieuXuat.Columns["ChiPhiMuaHang"].ColumnEdit = repositoryItemCalcEditChiPhiMuaHang;
            #endregion Dinh Dang Danh So
            //
            this.grdViewCt_PhieuXuat.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdViewCt_PhieuXuat_CellValueChanged);
            this.grdViewCt_PhieuXuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdViewCt_PhieuXuat_KeyDown);
            this.grdViewCt_PhieuXuat.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdViewCt_PhieuXuat_InitNewRow);

            this.grdCT_PhieuXuat.ContextMenuStrip = this.contextMenuStrip_HangHoa;

        }

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

        private void SetDefaultValueButToan(ButToanPhieuNhapXuat butToan)
        {
            decimal tongtienCP = 0;
            decimal tongtienThue = 0;
            if (butToan != null)
            {
                foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
                {
                    tongtienCP += ct_PhieuXuat.ThanhTien;
                    tongtienThue = tongtienThue + ct_PhieuXuat.TienThue;
                }
                foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuXuatVTHH.ButToanPhieuNhapXuatList)
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
                butToan.DienGiai = _phieuXuatVTHH.DienGiai;
            }
        }

        private void LockData()
        {
            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
            grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = true;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        void UnLockData()
        {
            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = true;
            grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = true;
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = false;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        void TempLockData()
        {
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = true;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
            grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            //grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
        }

        void AllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        void NotAllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void CheckPhuongPhapNX()
        {
            if (_phieuXuatVTHH != null)
            {
                if (_phieuXuatVTHH.PhuongPhapNX == 2)
                {
                    grdViewCt_PhieuXuat.Columns["SoPhieuNhap"].Visible = true;
                }
                else
                {
                    grdViewCt_PhieuXuat.Columns["SoPhieuNhap"].Visible = false;
                }
            }
        }

        void CapNhatTongTienPhieu()
        {
            Decimal tongTien = 0;
            foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
            {
                tongTien += ct_PhieuXuat.ThanhTien;
            }
            _phieuXuatVTHH.GiaTriKho = tongTien;
        }
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
            foreach (ButToanPhieuNhapXuat buttoan in _phieuXuatVTHH.ButToanPhieuNhapXuatList)
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
                _phieuXuatVTHH.NgayNX = _ngayLapCu;
                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                return false;
            }
            return true;
        }

        private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        {

            bool khoataiKhoan = false;
            KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _phieuXuatVTHH.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoataiKhoan = true;
                }
            }

            if (khoataiKhoan == false && _phieuXuatVTHH.IsNew == false)
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
            dr["tenHinhThuc"] = "Thực tế đích danh";
            dt.Rows.Add(dr);

            this.lookUpEdit_PhuongPhapNX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("maHinhThuc", null, 10, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenHinhThuc", null, 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            PhuongPhapNX_bindingSource.DataSource = dt;
            lookUpEdit_PhuongPhapNX.Properties.DataSource = PhuongPhapNX_bindingSource;
            lookUpEdit_PhuongPhapNX.Properties.DisplayMember = "tenHinhThuc";
            lookUpEdit_PhuongPhapNX.Properties.ValueMember = "maHinhThuc";

            this.lookUpEdit_PPNXKho.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("maHinhThuc", null, 10, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenHinhThuc", null, 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            PhuongPhapNX_bindingSource.DataSource = dt;
            lookUpEdit_PPNXKho.Properties.DataSource = PhuongPhapNX_bindingSource;
            lookUpEdit_PPNXKho.Properties.DisplayMember = "tenHinhThuc";
            lookUpEdit_PPNXKho.Properties.ValueMember = "maHinhThuc";

        }
        #endregion//END Hàm khởi tạo lookUpEdit_PhuongPhapNX

        #region Khoi tao moi
        private void LoadBoPhanList()
        {
            _boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            BoPhan bpEmpt = BoPhan.NewBoPhan("<<Tất cả>>");
            _boPhanList.Insert(0, bpEmpt);
            boPhanListBindingSource.DataSource = _boPhanList;
        }
        private void KhoiTaoN()
        {
            bs_NhomHangHoaList.DataSource = typeof(NhomHangHoaBQ_VTList);
            //PhieuNhapXuatList_bindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            //heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            //doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            

            //_boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            //boPhanListBindingSource.DataSource = _boPhanList;
            LoadBoPhanList();
            _khoBQ_VTList = KhoBQ_VTList.GetKhoVatTuList();
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;

            _doiTacList = DoiTacList.GetDoiTacHocSinhList();
            DoiTac _doiTac = DoiTac.NewDoiTac(0, "<<None>>");
            _doiTacList.Insert(0, _doiTac);
            doiTacListBindingSource.DataSource = _doiTacList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;

            //Loai Thue VAT
            LoaiThueSuatListBindingSource.DataSource = LoaiThueSuatVAT.CreateListLoaiThueSuatVAT();

            NhomHangHoaBQ_VTList nhomHangHoaBQ_VTList_forGrid = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTListVatTuHangHoa();
            bs_NhomHangHoaList.DataSource = nhomHangHoaBQ_VTList_forGrid;

            DesignGrid_grdViewCt_PhieuXuat();
        }
        #endregion//END Khoi Tao moi

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu(Int16 loaiPhieu)
        {
            _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = loaiPhieu;
            _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();//22012013
            _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;

            _phieuXuatVTHH.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;

            if (_khoBQ_VTList.Count != 0)
                _phieuXuatVTHH.MaKho = _khoBQ_VTList[0].MaKho;
            if (_boPhanList.Count != 0)
                _phieuXuatVTHH.MaPhongBan = _boPhanList[0].MaBoPhan;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
            btnChonPNhapXuat.Enabled = true;
            //_flag = true;
            if (_phieuXuatVTHH.MaPhieuNhapXuatThamChieu != 0)
            {
                LockData();
            }
            else
            {
                UnLockData();
            }
            _phieuXuatVTHH.PhuongPhapNX = 2;

            formatGridviewDinhKhoan();
        }

        private void KhoiTaoPhieuXuatBanDongPhuc()
        {
            _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = 20;
            _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();//22012013
            _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;

            _phieuXuatVTHH.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;

            if (_khoBQ_VTList.Count != 0)
                _phieuXuatVTHH.MaKho = _khoBQ_VTList[0].MaKho;
            if (_boPhanList.Count != 0)
                _phieuXuatVTHH.MaPhongBan = _boPhanList[0].MaBoPhan;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
            btnChonPNhapXuat.Enabled = true;
            //_flag = true;
            if (_phieuXuatVTHH.MaPhieuNhapXuatThamChieu != 0)
            {
                LockData();
            }
            else
            {
                UnLockData();
            }

            formatGridviewDinhKhoan();
        }

        private void KhoiTaoPhieuXuatCapPhatDongPhuc()
        {
            _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = 21;
            _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();//22012013
            _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;

            _phieuXuatVTHH.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;

            if (_khoBQ_VTList.Count != 0)
                _phieuXuatVTHH.MaKho = _khoBQ_VTList[0].MaKho;
            if (_boPhanList.Count != 0)
                _phieuXuatVTHH.MaPhongBan = _boPhanList[0].MaBoPhan;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
            btnChonPNhapXuat.Enabled = true;
            //_flag = true;
            if (_phieuXuatVTHH.MaPhieuNhapXuatThamChieu != 0)
            {
                LockData();
            }
            else
            {
                UnLockData();
            }

            formatGridviewDinhKhoan();
        }

        #endregion//Function


        #region (PhieuLinhNhienLieu phieuLinhNhienLieu)
        private void KhoiTaoPhieu(PhieuLinhNhienLieu phieuLinhNhienLieu)
        {
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuLinhNhienLieuList.Add(phieuLinhNhienLieu);
            //B
            //_phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat(phieuLinhNhienLieu);
            _phieuXuatVTHH.NgayNX = phieuLinhNhienLieu.NgayLap;
            _phieuXuatVTHH.MaNguoiNhapXuat = phieuLinhNhienLieu.MaNguoiNhan;
            _phieuXuatVTHH.MaPhongBan = phieuLinhNhienLieu.MaBoPhanNhan;
            _phieuXuatVTHH.MaKho = phieuLinhNhienLieu.MaKho;
            _phieuXuatVTHH.DienGiai = phieuLinhNhienLieu.DienGiai;
            _phieuXuatVTHH.GiaTriKho = 0;
            foreach (CT_PhieuLinhNhienLieu ct_PhieuLinhNhienLieu in phieuLinhNhienLieu.CT_PhieuLinhNhienLieuList)
            {
                if (ct_PhieuLinhNhienLieu.SoLuongXuat > HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _phieuXuatVTHH.MaKho, ct_PhieuLinhNhienLieu.MaHangHoa, _phieuXuatVTHH.NgayNX))
                {
                    HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuLinhNhienLieu.MaHangHoa);
                    MessageBox.Show("Số lượng xuất \"" + _hangHoaBQ_VT.TenHangHoa + "\" vượt quá số lượng tồn!\n Không thể xuất!");
                }
                else
                {
                    //
                    CT_PhieuXuat ct_PhieuXuat = new CT_PhieuXuat(ct_PhieuLinhNhienLieu, _phieuXuatVTHH.MaKho, _phieuXuatVTHH.NgayNX);
                    _phieuXuatVTHH.CT_PhieuXuatList.Add(ct_PhieuXuat);
                    //_phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien - ct_PhieuXuat.TienChietKhau + ct_PhieuXuat.TienThue;

                    _phieuLinhNhienLieuList_Update.Add(phieuLinhNhienLieu);
                    //
                }
            }
            CapNhatTongTienPhieu();
            //E
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = 2;
            _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

            _phieuXuatVTHH.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;

        }
        #endregion


        private void KhoiTaoPhieu(PhieuLinhNhienLieuList phieuLinhNhienLieuList)
        {
            //_phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            foreach (PhieuLinhNhienLieu item in phieuLinhNhienLieuList)
            {
                _phieuLinhNhienLieuList.Add(PhieuLinhNhienLieu.GetPhieuLinhNhienLieu(item.MaPhieuLinhNhienLieu));
            }
            //_phieuLinhNhienLieuList = phieuLinhNhienLieuList;
            //B
            //_phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat(_phieuLinhNhienLieuList, _phieuXuatVTHH.NgayNX);
            _phieuXuatVTHH.MaNguoiNhapXuat = phieuLinhNhienLieuList[0].MaNguoiNhan;
            _phieuXuatVTHH.MaPhongBan = phieuLinhNhienLieuList[0].MaBoPhanNhan;
            _phieuXuatVTHH.MaKho = phieuLinhNhienLieuList[0].MaKho;
            //_phieuXuatVTHH.GiaTriKho = 0;
            foreach (PhieuLinhNhienLieu phieuLinhNhienLieu in _phieuLinhNhienLieuList)
            {

                foreach (CT_PhieuLinhNhienLieu ct_PhieuLinhNhienLieu in phieuLinhNhienLieu.CT_PhieuLinhNhienLieuList)
                {
                    if (ct_PhieuLinhNhienLieu.SoLuongXuat > HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _phieuXuatVTHH.MaKho, ct_PhieuLinhNhienLieu.MaHangHoa, _phieuXuatVTHH.NgayNX))
                    {
                        HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuLinhNhienLieu.MaHangHoa);
                        MessageBox.Show("Số lượng xuất \"" + _hangHoaBQ_VT.TenHangHoa + "\" vượt quá số lượng tồn!\n Không thể xuất!");
                    }
                    else
                    {
                        CT_PhieuXuat ct_PhieuXuat = new CT_PhieuXuat(ct_PhieuLinhNhienLieu, _phieuXuatVTHH.MaKho, _phieuXuatVTHH.NgayNX);
                        _phieuXuatVTHH.CT_PhieuXuatList.Add(ct_PhieuXuat);
                        //_phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien - ct_PhieuXuat.TienChietKhau + ct_PhieuXuat.TienThue; 

                        _phieuLinhNhienLieuList_Update.Add(phieuLinhNhienLieu);
                    }
                }
                CapNhatTongTienPhieu();
            }
            //E
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = 2;
            _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;

        }

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhap, int kieu)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuXuat, int kieu)
        {

            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
            if (kieu == 1)
            {
                _phieuXuatVTHH = phieuXuat;
                //Add to 11012013
                _ngayLapCu = _phieuXuatVTHH.NgayNX;
                _maKhoCu = _phieuXuatVTHH.MaKho;
                _coTKBiKhoa = CheckCoTaiKhoanBiKhoaTrongButToan();
                //End Add to 11012013
                _phieuTuDSPhieuNhapXuat = true;
            }
            else
            {
                _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat(phieuXuat, 2);
                _phieuXuatVTHH.MaDoiTac = 0;
                _phieuXuatVTHH.LaNhap = false;
                _phieuXuatVTHH.Loai = 20;
                _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
                _phieuTuDSPhieuNhapXuat = false;
                //TinhTongTien();
                this.isThayDoiSoLieu = true;
            }
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;
            btnChonPNhapXuat.Enabled = false;


        }
        #endregion

        //private void AnHienBtnChonXThang()
        //{
        //    if (_phieuXuatVTHH.PhuongPhapNX == 2 && _phieuXuatVTHH.MaKho != 0 && _flag)
        //    {
        //        btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //    }
        //    else
        //    {
        //        btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //    }
        //}
        void formatGriview()
        {
            this.grdViewCt_PhieuXuat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }
        #region Vat Tu_Ban Quyen
        private void anHiencottheoyeucau()
        {
            this.ColMaTieuMuc.Visible = false;
            this.col_btn.Visible = true;
        }
        private void formatGridviewDinhKhoan()
        {
            anHiencottheoyeucau();//Tam thoi
            //if (!_phieuXuatVTHH.IsNew)
            //{
            //    if (_phieuXuatVTHH.ButToanPhieuNhapXuatList.Count > 0)
            //    {
            //        foreach (ButToanPhieuNhapXuat bt in _phieuXuatVTHH.ButToanPhieuNhapXuatList)
            //        {
            //            if (bt.ButToan_MucNganSach.MaTieuMuc != 0 && bt.ButToan_MucNganSach.MaCT_ChiPhiSanXuat == 0)
            //            {

            //                this.ColMaTieuMuc.Visible = true;
            //                this.col_btn.Visible = false;
            //            }
            //            else
            //            {
            //                anHiencottheoyeucau();
            //            }
            //        }
            //    }
            //    else
            //    {
            //        anHiencottheoyeucau();
            //    }
            //}
            //else
            //{
            //    anHiencottheoyeucau();
            //}
        }
        #endregion//Vat Tu_Ban Quyen

        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuXuat ct_phieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
            {
                if (ct_phieuXuat.MaHangHoa == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập hàng hóa cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (ct_phieuXuat.SoLuong == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập số lượng cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            //Kiem tra but toan
            foreach (ButToanPhieuNhapXuat bt in _phieuXuatVTHH.ButToanPhieuNhapXuatList)
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
            if (_phieuXuatVTHH.MaPhongBan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_PhongBan.Focus();
            }
            //else if (_phieuXuatVTHH.MaNguoiNhapXuat == 0)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    lookUpEdit_NhanVien.Focus();
            //}
            else if (_phieuXuatVTHH.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoXuat.Focus();
            }
            else if (_phieuXuatVTHH.CT_PhieuXuatList.Count == 0)
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (KiemTraChiTiet() == false)
            {
                grdViewCt_PhieuXuat.Focus();
            }
            else kq = true;
            return kq;
        }

        private bool KhoaSo()
        {
            bool khoaso = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuXuatVTHH.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }
            //
            if (khoaso == false && _phieuXuatVTHH.IsNew == false)
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
            daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_phieuXuatVTHH.NgayNX, _phieuXuatVTHH.MaKho);
            if (daKC == false && _phieuXuatVTHH.IsNew == false)
            {
                daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_ngayLapCu, _maKhoCu);
            }
            if (daKC)
            {
                MessageBox.Show("Kỳ này đã kết chuyển, không thể cập nhật phiếu!");
            }
            return daKC;
        }
        #endregion//End Function
        public FrmPhieuXuatDongPhuc()
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(_loaiPhieu);
            KhoiTao_PhuongPhapNX();
            //AnHienBtnChonXThang();
        }

        public void ShowPhieuXuatBanDongPhuc()
        {
            KhoiTaoPhieuXuatBanDongPhuc();
            _phieuXuatVTHH.PhuongPhapNX = 2;
            _loaiPhieu = 20;
            this.Text = "Phiếu Xuất Bán Đồng Phục";
            TabPhieu.Text = "Phiếu Xuất Bán Đồng Phục";
            TabDanhSach.Text = "Danh Sách Xuất Bán Đồng Phục";
            btnXuatKhotuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public void ShowPhieuXuatCapPhatDongPhuc()
        {
            KhoiTaoPhieuXuatCapPhatDongPhuc();
            _phieuXuatVTHH.PhuongPhapNX = 2;
            _loaiPhieu = 21;
            this.Text = "Phiếu Xuất Cấp Phát Đồng Phục";
            TabPhieu.Text = "Phiếu Xuất Cấp Phát Đồng Phục";
            TabDanhSach.Text = "Danh Sách Xuất Cấp Phát Đồng Phục";
            btnXuatKhotuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public FrmPhieuXuatDongPhuc(PhieuLinhNhienLieu phieuLinhNhienLieu)
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(phieuLinhNhienLieu);
            KhoiTao_PhuongPhapNX();
            if (_phieuXuatVTHH.CT_PhieuXuatList.Count > 0)
            {
                LockData();
                NotAllowDelete();
            }
            //AnHienBtnChonXThang();
        }

        public FrmPhieuXuatDongPhuc(PhieuNhapXuat phieuNhap)
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap, 0);
            KhoiTao_PhuongPhapNX();
            //_phieuXuatVTHH = PhieuNhapXuat.GetPhieuNhapXuat(maPNX);
            //KhoiTaoN();
            //KhoiTaoPhieu();
            //KhoiTao_PhuongPhapNX();
            //if (_phieuXuatVTHH.PhuongPhapNX == 2)
            //    //grdViewCt_PhieuXuat.OptionsBehavior.ReadOnly = true;
            //    LockData();
            //phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;
            //cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList; //_ctPhieuXuatList;
            //butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;// _butToanPhieuNhapXuatList;
            //grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
            //grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;
            //AnHienBtnChonXThang();
        }

        public FrmPhieuXuatDongPhuc(PhieuNhapXuat phieuNhap, int kieu)
        {
            InitializeComponent();
            _checkXemLaiPhieuXuat = true;
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap, kieu);
            KhoiTao_PhuongPhapNX();
            if (_phieuXuatVTHH.PhuongPhapNX == 2)
                //grdViewCt_PhieuXuat.OptionsBehavior.ReadOnly = true;
                LockData();
        }
        public FrmPhieuXuatDongPhuc(PhieuNhapXuat phieuNhap, int kieu, bool XuatThangTuPhieuNhap)
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap, kieu);
            KhoiTao_PhuongPhapNX();
            _tu1PhieuNhap = true;
            //AnHienBtnChonXThang();
        }

        public FrmPhieuXuatDongPhuc(long maChungTu, int kieu)
        {
            InitializeComponent();
            PhieuNhapXuat phieuNhap = PhieuNhapXuat.GetPhieuNhapXuat(maChungTu);
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap, kieu);
            KhoiTao_PhuongPhapNX();
            if (_phieuXuatVTHH.PhuongPhapNX == 2)
                //grdViewCt_PhieuXuat.OptionsBehavior.ReadOnly = true;
                LockData();
        }

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            //if (_edtiBophan && lookUpEdit_PhongBan.EditValue != null)
            //{
            //    int mabophabout;
            //    if (int.TryParse(lookUpEdit_PhongBan.EditValue.ToString(), out mabophabout))
            //    {
            //        LoadDataForthongTinNhanVienTongHopListBindingSource(mabophabout);
            //    }
            //    //thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
            //}
            ////_phieuXuatVTHH.MaPhongBan = (int)lookUpEdit_PhongBan.EditValue;
        }
        private void LoadDataForthongTinNhanVienTongHopListBindingSource(int maboPHan)
        {
        }
        #endregion

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //int _loaiPhieu = _phieuXuatVTHH.Loai;
            _coTKBiKhoa = false;
            KhoiTaoPhieu(_loaiPhieu);
            dateEdit_NgayLap.Focus();
            _daChonPhieuNhap = false;
            btnChonPNhapXuat.Enabled = true;
            _phieuTuDSPhieuNhapXuat = false;
            _tu1PhieuNhap = false;
            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = true;
            UnLockData();
            CheckPhuongPhapNX();
            AllowDelete();
            _checkXemLaiPhieuXuat = false;
            LoadCboPhieuDeNghi();
            //_phieuNhapXuatList.Clear();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();
            if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
            {
                MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                return;
            }
            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Add to 18012013
            if (_phieuXuatVTHH.XacNhan == true)
            {
                MessageBox.Show(this, "Thủ kho đã xác nhận, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_phieuXuatVTHH.ButToanPhieuNhapXuatList.Count == 0)
            {
                if (MessageBox.Show("Chứng từ chưa được hạch toán, bạn có muốn tiếp tục lưu!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            if (DaKetChuyen() == false)
            {
                //End Add to 18012013
                if (txt_SoPhieu.EditValue != null)//IF 1
                {
                    string _soPhieu = txt_SoPhieu.EditValue.ToString();
                    //int _stt;
                    //if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                    //{
                    bool ktphieutrung = true;
                    if (_phieuXuatVTHH.IsNew)
                    {
                        ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.SoPhieu, true);
                    }
                    else//k phai IS NEW
                    {
                        ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.SoPhieu, false);

                    }
                    if (ktphieutrung)//IF 5
                    {
                        //
                        try
                        {
                            if (KiemTraDuLieu())
                            {
                                phieuNhapXuatBindingSource.EndEdit();
                                _phieuXuatVTHH.ApplyEdit();
                                _phieuXuatVTHH.Save();
                                if (_phieuXuatVTHH != null)
                                {
                                    if (_phieuXuatVTHH.PhuongPhapNX == 2)
                                    {
                                        //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                                        LockData();
                                    }
                                }
                                foreach (PhieuLinhNhienLieu item in _phieuLinhNhienLieuList_Update)
                                {
                                    item.TinhTrang = 2;
                                    item.MaPhieuNhapXuat = _phieuXuatVTHH.MaPhieuNhapXuat;
                                }
                                _phieuLinhNhienLieuList_Update.ApplyEdit();
                                _phieuLinhNhienLieuList_Update.Save();
                                //Add to 11012013
                                _ngayLapCu = _phieuXuatVTHH.NgayNX;
                                _maKhoCu = _phieuXuatVTHH.MaKho;
                                //End Add to 11012013
                                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
                                if (_daChonPhieuNhap)
                                    btnChonPNhapXuat.Enabled = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            DialogUtil.ShowWarning("Cập Nhật Thất Bại!\n" + ex.Message);
                        }
                        //
                    }//END IF 5
                    else
                    {
                        MessageBox.Show("Trùng Số Phiếu! Không Thể Lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_SoPhieu.Focus();
                    }
                    //}//END IF 2
                    //else
                    //{
                    //    MessageBox.Show("Số Phiếu Không Hợp Lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txt_SoPhieu.Focus();
                    //}
                }//END IF 1
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnChonXuatThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuXuatVTHH.MaKho == 0)
            {
                MessageBox.Show("Hãy chọn kho cần xuất!");
                gridLookUpEdit_KhoXuat.Focus();
                gridLookUpEdit_KhoXuat.Properties.ReadOnly = false;
            }
            else
            {
                FrmLoadPhieuNhapList frm = new FrmLoadPhieuNhapList(_phieuXuatVTHH);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    _ct_PhieuNhapListChon = frm.CT_PhieuNhapListChon;//M
                    if (_ct_PhieuNhapListChon.Count != 0)//M
                    {
                        #region Old
                        ////Luu Tru
                        //long maDoiTac_T = _phieuXuatVTHH.MaDoiTac;
                        //string soPhieu_T = _phieuXuatVTHH.SoPhieu;
                        //int maPhongBan_T = _phieuXuatVTHH.MaPhongBan;
                        //DateTime ngayNX_T=_phieuXuatVTHH.NgayNX;
                        //long maNguoiNhapXuat_T = _phieuXuatVTHH.MaNguoiNhapXuat;
                        //int maKho_T = _phieuXuatVTHH.MaKho;
                        //int soCTKemTheo_T = _phieuXuatVTHH.SoCTKemTheo;
                        //byte phuongPhapNX_T = _phieuXuatVTHH.PhuongPhapNX;
                        //string dienGiai_T = _phieuXuatVTHH.DienGiai;
                        //CT_PhieuXuatList cT_PhieuXuatList_T = _phieuXuatVTHH.CT_PhieuXuatList;
                        //ButToanPhieuNhapXuatList butToanPhieuNhapXuatList_T = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
                        ////
                        //_phieuXuatVTHH = new PhieuNhapXuat(_ct_PhieuNhapListChon, _phieuXuatVTHH.MaPhongBan, 2, 2, _phieuXuatVTHH.MaKho, _phieuXuatVTHH.NgayNX);//M
                        ////-->Day du lieu vao
                        //_phieuXuatVTHH.LaNhap = false;
                        //_phieuXuatVTHH.Loai = 2;
                        //_phieuXuatVTHH.MaDoiTac = maDoiTac_T;
                        //_phieuXuatVTHH.SoPhieu = soPhieu_T;
                        //_phieuXuatVTHH.MaPhongBan = maPhongBan_T;
                        //_phieuXuatVTHH.NgayNX = ngayNX_T;
                        //_phieuXuatVTHH.MaNguoiNhapXuat = maNguoiNhapXuat_T;
                        //_phieuXuatVTHH.MaKho = maKho_T;
                        //_phieuXuatVTHH.SoCTKemTheo = soCTKemTheo_T;
                        //_phieuXuatVTHH.PhuongPhapNX = phuongPhapNX_T;
                        //_phieuXuatVTHH.DienGiai = dienGiai_T;
                        //foreach (CT_PhieuXuat cT in cT_PhieuXuatList_T)
                        //{
                        //    if (!_phieuXuatVTHH.CT_PhieuXuatList.Contains(cT))
                        //    {
                        //        _phieuXuatVTHH.CT_PhieuXuatList.Add(cT);
                        //    }
                        //}
                        //foreach (ButToanPhieuNhapXuat bt in butToanPhieuNhapXuatList_T)
                        //{
                        //    _phieuXuatVTHH.ButToanPhieuNhapXuatList.Add(bt);
                        //}
                        #endregion//End Old
                        #region New
                        foreach (CT_PhieuNhap ct_PhieuNhap in _ct_PhieuNhapListChon)
                        {
                            if (ct_PhieuNhap.SoLuong > ct_PhieuNhap.SoLuongXuat)
                            {
                                CT_PhieuXuat ct_PhieuXuat = new CT_PhieuXuat(ct_PhieuNhap, _phieuXuatVTHH.NgayNX);
                                bool insert = true;
                                foreach (CT_PhieuXuat ct in _phieuXuatVTHH.CT_PhieuXuatList)
                                {
                                    if (ct_PhieuXuat.MaHangHoa == ct.MaHangHoa)
                                    {
                                        ct.DonGia = ct_PhieuXuat.DonGia;
                                        ct.ThanhTien = ct.SoLuong * ct.DonGia;
                                        ct.SLgCt_PNhap = ct_PhieuNhap.SoLuong - ct_PhieuNhap.SoLuongXuat;
                                        ct.MaPhieuNhap = ct_PhieuNhap.MaPhieuNhap;
                                        break;
                                    }
                                }
                                //if (grdViewCt_PhieuXuat.RowCount > 0)
                                //{
                                //    for (int i = 0; i < grdViewCt_PhieuXuat.RowCount; i++)
                                //    {
                                //        if (grdViewCt_PhieuXuat.GetRow(i) != null)
                                //        {
                                //            CT_PhieuXuat ct_px_gv = (CT_PhieuXuat)grdViewCt_PhieuXuat.GetRow(i);
                                //            if (ct_px_gv.MaHangHoa == ct_PhieuXuat.MaHangHoa
                                //                && ct_px_gv.MaPhieuNhap == ct_PhieuXuat.MaPhieuNhap
                                //                && ct_px_gv.DonGia == ct_PhieuXuat.DonGia//New 19112013
                                //                )
                                //            {
                                //                insert = false;
                                //                break;
                                //            }
                                //        }
                                //    }

                                //}//grdViewCt_PhieuXuat.RowCount > 0

                                //if (insert)
                                //{
                                //    _phieuXuatVTHH.CT_PhieuXuatList.Add(ct_PhieuXuat);
                                //}

                            }
                            else
                            {
                                HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuNhap.MaHangHoa);
                                MessageBox.Show("Chi tiết của \"" + _hangHoaBQ_VT.TenHangHoa + "\" đã xuất hết!");
                            }
                        }
                        #endregion //End New
                        //Set lai Gia Tri Kho
                        CapNhatTongTienPhieu();
                        //END Set lai Gia Tri Kho
                        //Refresh lai du lieu
                        phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;
                        cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList; //_ctPhieuXuatList;
                        butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;// _butToanPhieuNhapXuatList;
                        grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
                        grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;
                        _daChonPhieuNhap = true;
                        TempLockData();
                        this.isThayDoiSoLieu = true;
                    }
                }
                else
                {
                    frm.ShowDialog();
                }
                ////End Chi Thuyen
            }
            //Xu ly dong form [PhieuXuat]

        }

        private void grdCT_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    DialogResult kq = MessageBox.Show("Bạn chắc xóa dòng này?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //    if (kq == DialogResult.Yes)
            //        grdViewCt_PhieuXuat.DeleteSelectedRows();
            //    //foreach (int i in grdViewCt_PhieuXuat.GetSelectedRows())
            //    //{
            //    //    grdViewCt_PhieuXuat.DeleteRow(i);
            //    //}

            //}
            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
        }

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


        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ButToanPhieuNhapXuat butToan = (ButToanPhieuNhapXuat)(butToanPhieuNhapXuatListBindingSource.Current);
            SetDefaultValueButToan(butToan);
            #region Old
            //decimal soTienConLai = _phieuXuatVTHH.GiaTriKho;
            //foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuXuatVTHH.ButToanPhieuNhapXuatList)
            //{
            //    soTienConLai = soTienConLai - buttoanphieu.SoTien;
            //}
            //butToan.SoTien = soTienConLai;
            //butToan.DienGiai = _phieuXuatVTHH.DienGiai; 
            #endregion Old
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BEGIN
            ReportTemplate _report;

            #region Old phân biệt 2 mẫu: Bình quân và NXT
            //if (_phieuXuatVTHH.PhuongPhapNX == 2)//if la Xuat Thang
            //{
            //    _report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
            //}
            //else//if la Xuat Binh Quan
            //{
            //    _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
            //}
            #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

            #region Modify Chỉ dùng 1 mẫu
            _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
            #endregion//Modify Chỉ dùng 1 mẫu

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
                frm.ShowDialog();
            }
            //END

        }

        #region EventHandles
        private void grdViewCt_PhieuXuat_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (cTPhieuXuatListBindingSource.Current != null)
            {
                CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;


                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHangHoa")
                {

                    grdCT_PhieuXuat.Update();
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(_ct_PhieuXuat.MaHangHoa);
                    _ct_PhieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                    if (_phieuXuatVTHH.PhuongPhapNX == 1)
                    {
                        _ct_PhieuXuat.DonGia = HangHoaBQ_VT.GetGiaTriBinhQuanHangHoa(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        //
                        _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        if (_soLuongHienCo < _ct_PhieuXuat.SoLuong)
                            _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                        _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        //
                    }

                }
                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colSoLuong")
                {
                    decimal soluong_gv = 0;
                    if (decimal.TryParse(e.Value.ToString(), out soluong_gv))
                    {
                        if (_phieuXuatVTHH.PhuongPhapNX == 2)//Trong T/H Xuat thang tu 1 Phieu Nhap
                        {
                            if (!_phieuTuDSPhieuNhapXuat)//Khong Phai Phieu Load Tu DS Phieu NHap Xuat
                            {
                                if (soluong_gv > _ct_PhieuXuat.SLgCt_PNhap)
                                {
                                    MessageBox.Show("Số lượng xuất vượt quá chi tiết nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_ct_PhieuXuat.SLgCt_PNhap);
                                }
                                else if (soluong_gv == _ct_PhieuXuat.SLgCt_PNhap)
                                {
                                    //_ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaNXT(_phieuXuatVTHH.MaPhieuNhapXuat, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaHangHoa, _phieuXuatVTHH.NgayNX, _ct_PhieuXuat.DonGia);//New 19112013                                  
                                    _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * soluong_gv, 0, MidpointRounding.AwayFromZero);
                                }
                                else
                                {
                                    grdCT_PhieuXuat.Update();
                                    _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);

                                }
                            }
                        }//END Trong T/H Xuat thang tu 1 Phieu Nhap
                        else//Trong T/H Xuat Binh Thuong
                        {
                            _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                            if (soluong_gv > _soLuongHienCo)
                            {
                                MessageBox.Show("Số lượng còn " + _soLuongHienCo.ToString() + ". Không đủ xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                                _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                            }
                            else if (soluong_gv == _soLuongHienCo)
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);

                            }
                            else
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);

                            }
                        }//END Trong T/H Xuat Binh Thuong
                    }
                }//IF thay doi tren cot So Luong
                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colDonGia")
                {

                    grdCT_PhieuXuat.Update();
                    _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);

                }
                //Decimal tongTien = 0;
                //foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
                //{
                //    tongTien = tongTien + ct_PhieuXuat.ThanhTien - ct_PhieuXuat.TienChietKhau + ct_PhieuXuat.TienThue;
                //}
                //_phieuXuatVTHH.GiaTriKho = tongTien;
                CapNhatTongTienPhieu();
                this.isThayDoiSoLieu = true;
            }
            GanBindingSource();
        }

        private void grdViewCt_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
        }
        private void grdViewCt_PhieuXuat_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
            _ct_PhieuXuat.DienGiai = _phieuXuatVTHH.DienGiai;
        }
        //HangHoa_GrdLU_Popup
        private void HangHoa_GrdLU_Popup(object sender, EventArgs e)
        {
            if (cTPhieuXuatListBindingSource.Current != null && grdViewCt_PhieuXuat.GetFocusedRow() != null)
            {
                CT_PhieuXuat ctpxCur = cTPhieuXuatListBindingSource.Current as CT_PhieuXuat;
                if (ctpxCur.MaNhomHangHoa != null && ctpxCur.MaNhomHangHoa != 0)
                {
                    GridLookUpEdit grid = (GridLookUpEdit)sender;
                    if (grid != null)
                    {
                        grid.Properties.View.ActiveFilterString = "MaNhomHangHoa=" + ctpxCur.MaNhomHangHoa.ToString();
                    }
                }
            }
        }
        #endregion EventHandles

        #region Cac Phuong Thuc Report
        public void Spd_PhieuXuatVatTu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_PhieuXuatVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuXuatVatTu";
                    cm.Parameters.AddWithValue("@MaPhieuXuatVTHH", _phieuXuatVTHH.MaPhieuNhapXuat);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuXuatVatTu;1";
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

        public void sp_psc_vw_tbl_StudentTatCaGiaoDichDetail_GetByXacNhan()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_PhieuXuatVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    string dtac = DoiTac.GetDoiTac(Convert.ToInt32(_phieuXuatVTHH.MaDoiTac)).MaQLDoiTac;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 900;
                    cm.CommandText = "AccountsFee.dbo.sp_psc_vw_tbl_StudentTatCaGiaoDichDetail_GetByXacNhan";
                    cm.Parameters.AddWithValue("@BillId", dtac);
                    cm.Parameters.AddWithValue("@truong", "CP");

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "sp_psc_vw_tbl_StudentTatCaGiaoDichDetail_GetByXacNhan;1";
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

        public void spd_GetChiTietXuatBanDongPhucFromOtherDBList()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_PhieuXuatVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    string dtac = DoiTac.GetDoiTac(Convert.ToInt32(_phieuXuatVTHH.MaDoiTac)).MaQLDoiTac;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 900;
                    cm.CommandText = "spd_GetChiTietXuatBanDongPhucFromOtherDBList_Report";
                    cm.Parameters.AddWithValue("@BillId", _phieuXuatVTHH.CT_PhieuXuatList[0].IDBienLai);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_GetChiTietXuatBanDongPhucFromOtherDBList_Report;1";
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

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_CTPhieuXuat")
            {
                //if (grdViewCt_PhieuXuat.GetFocusedRow() != null)
                //{
                //    CT_PhieuXuat ct_px = grdViewCt_PhieuXuat.GetFocusedRow() as CT_PhieuXuat;
                //    _phieuXuatVTHH.GiaTriKho = _phieuXuatVTHH.GiaTriKho - ct_px.ThanhTien;
                //    grdViewCt_PhieuXuat.DeleteSelectedRows();
                //}
                grdViewCt_PhieuXuat.DeleteSelectedRows();//Xoa nhieu dong
                CapNhatTongTienPhieu();

            }
            else if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_ButToan")
                grdView_DinhKhoan.DeleteSelectedRows();
        }

        private void FrmPhieuXuatVatTuHangHoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            //textEdit_Focus.Focus();
            //if (_phieuXuatVTHH.IsDirty)
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

        private void btnPhieuDeNghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSPhieuLinhNhienLieu frm = new frmDSPhieuLinhNhienLieu(_phieuXuatVTHH.MaKho, _phieuXuatVTHH.MaPhongBan, _phieuXuatVTHH.NgayNX, 2);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (frm.PhieuLinhNhienLieuDuocChonList != null && frm.PhieuLinhNhienLieuDuocChonList.Count > 0)
                {
                    KhoiTaoPhieu(frm.PhieuLinhNhienLieuDuocChonList);
                    if (_phieuXuatVTHH.CT_PhieuXuatList.Count > 0)
                    {
                        LockData();
                        NotAllowDelete();

                    }
                }
            }
        }

        private void lookUpEdit_PhuongPhapNX_EditValueChanged(object sender, EventArgs e)
        {
            byte ppnhapxuatOut = 0;
            if (byte.TryParse(lookUpEdit_PhuongPhapNX.EditValue.ToString(), out ppnhapxuatOut))
            {
                //ppnhapxuatOut =(byte) lookUpEdit_PPNXKho.EditValue;
            }
            if (ppnhapxuatOut == 2)
            {
                //btnPhieuDeNghi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //btnXuatKhotuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            }
            else
            {
                //btnPhieuDeNghi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //btnXuatKhotuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }

            CheckPhuongPhapNX();
        }


        private void FrmPhieuXuatVatTuHangHoa_Load(object sender, EventArgs e)
        {
            dtEdit_TuNgay.EditValue = DateTime.Now.Date;
            dtEdit_DenNgay.EditValue = DateTime.Now.Date;

            btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnPhieuDeNghi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            formatGriview();
            CheckPhuongPhapNX();
            if (PhieuNhapXuat.KiemTraPhieuXuatTuDSPhieuDeNghiLinh(_phieuXuatVTHH.MaPhieuNhapXuat))
            {
                LockData();
                NotAllowDelete();
            }

            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuXuat, 35);
            //Utils.GridUtils.InitNewRowOnTopOfGridView(grdViewCt_PhieuXuat);
            //Utils.GridUtils.InitNewRowOnTopOfGridView(grdView_DinhKhoan);
            if (_phieuXuatVTHH.IsNew == false)
            {
                if (_phieuXuatVTHH != null)
                {
                    if (PhieuNhapXuat.KiemTraPhieuXuatThangTuPhieuNhap(_phieuXuatVTHH.MaPhieuNhapXuat))
                    {
                        //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                        LockData();
                    }
                }
            }
            else if (_tu1PhieuNhap)
            {
                //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                LockData();
            }


            if (_loaiPhieu == 21)   //xuat cap phat dong phuc
            {
                LoadCboPhieuDeNghi();
            }

            formatGridviewDinhKhoan();//Vat tu ban quyen
            grdView_DinhKhoan.OptionsView.ShowFooter = true;
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdView_DinhKhoan, new string[] { "SoTien" }, "{0:#,###.##}");
        }

        private void LoadCboPhieuDeNghi()
        {
            blnIsLoadCboPhieuDeNghi = false;
            _phieuDeNghiList = PhieuDeNghiXuatDongPhucList.GetPhieuDeNghiXuatDongPhucList("", 27);
            PhieuDeNghiXuatDongPhuc objPhieuDeNghi = PhieuDeNghiXuatDongPhuc.NewPhieuDeNghiXuatDongPhuc();
            _phieuDeNghiList.Insert(0, objPhieuDeNghi);
            bdPhieuDeNghiList.DataSource = _phieuDeNghiList;
            blnIsLoadCboPhieuDeNghi = true;
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(0);
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (dlg.MaHangHoaChon != 0)
                {
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                    if (cTPhieuXuatListBindingSource.Current == null || grdViewCt_PhieuXuat.GetFocusedRow() == null)
                        grdViewCt_PhieuXuat.AddNewRow();
                    CT_PhieuXuat ct_phieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
                    ct_phieuXuat.MaHangHoa = dlg.MaHangHoaChon;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuXuat.MaHangHoa);
                    ct_phieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                    //grdViewCt_PhieuXuat.RefreshData();
                }

            }
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuXuatVTHH;
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
                        PhieuNhapXuat.DeletePhieuNhapXuat(_phieuXuatVTHH);
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

        private void Tab_NghiepVuPhieuXuat_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_ButToan")
            {
                AllowDelete();

                if (this.isThayDoiSoLieu == true)
                {
                    if (this._phieuXuatVTHH.ButToanPhieuNhapXuatList.Count == 0)
                    {
                        ButToanPhieuNhapXuat bt = ButToanPhieuNhapXuat.NewButToanPhieuNhapXuat();
                        int tkNo = HeThongTaiKhoan1.LayMaTaiKhoan("6272");
                        int tkCo = HeThongTaiKhoan1.LayMaTaiKhoan("1531");
                        bt.NoTaiKhoan = tkNo;
                        bt.CoTaiKhoan = tkCo;
                        bt.SoTien = this._phieuXuatVTHH.GiaTriKho;
                        this._phieuXuatVTHH.ButToanPhieuNhapXuatList.Add(bt);
                        //butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
                    }
                    this.isThayDoiSoLieu = false;
                }
            }
            else if (PhieuNhapXuat.KiemTraPhieuXuatTuDSPhieuDeNghiLinh(_phieuXuatVTHH.MaPhieuNhapXuat))
            {
                NotAllowDelete();
            }
        }


        private void grdView_DinhKhoan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
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
                    frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuXuatVTHH.NgayNX, bt.DienGiai, bt.MaButToan);
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
        }

        private void dateEdit_NgayLap_Leave(object sender, EventArgs e)
        {
            if (dateEdit_NgayLap.OldEditValue != dateEdit_NgayLap.EditValue)
            {
                CheckValidKhoaTaiKhoanWhenChangeNgayCT();
            }
        }
       
        private void lookUpEdit_NhanVien_Leave(object sender, EventArgs e)
        {
            //_edtiBophan = false;
            //if (lookUpEdit_NhanVien.EditValue != lookUpEdit_NhanVien.OldEditValue)
            //{
            //    if (lookUpEdit_NhanVien.EditValue != null)
            //    {
            //        long manvOut;
            //        if (long.TryParse(lookUpEdit_NhanVien.EditValue.ToString(), out manvOut))
            //        {
            //            ThongTinNhanVienTongHop nv = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(manvOut);
            //            _phieuXuatVTHH.MaPhongBan = nv.MaBoPhan;
            //        }

            //    }
            //}
            //_edtiBophan = true;
        }

        private void btnXuatKhotuBienLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LapChiTietXuatKhotuBienLai();
        }

        private void btnInVie_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BEGIN
            ReportTemplate _report;

            #region Old phân biệt 2 mẫu: Bình quân và NXT
            //if (_phieuXuatVTHH.PhuongPhapNX == 2)//if la Xuat Thang
            //{
            //    _report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
            //}
            //else//if la Xuat Binh Quan
            //{
            //    _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
            //}
            #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

            if (_phieuXuatVTHH.Loai == 21)
            {
                #region Modify Chỉ dùng 1 mẫu
                _report = ReportTemplate.GetReportTemplate("IDReport_PhieuXuatCapPhatDongPhuc");
                #endregion//Modify Chỉ dùng 1 mẫu


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
                    frm.ShowDialog();
                }
            }
            else if (_phieuXuatVTHH.Loai == 20)
            {
                #region Modify Chỉ dùng 1 mẫu
                _report = ReportTemplate.GetReportTemplate("IDReport_PhieuXuatBanDongPhuc");
                #endregion//Modify Chỉ dùng 1 mẫu


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
                    frm.ShowDialog();
                }
            }
            //END
        }

        private void btnInEng_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //BEGIN
            ReportTemplate _report;

            #region Old phân biệt 2 mẫu: Bình quân và NXT
            //if (_phieuXuatVTHH.PhuongPhapNX == 2)//if la Xuat Thang
            //{
            //    _report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
            //}
            //else//if la Xuat Binh Quan
            //{
            //    _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
            //}
            #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

            #region Modify Chỉ dùng 1 mẫu
            _report = ReportTemplate.GetReportTemplate("IDReport_PhieuXuatVatTu");
            #endregion//Modify Chỉ dùng 1 mẫu


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
                frm.ShowDialog();
            }
            //END

        }

        private void txt_SoPhieu_EditValueChanged(object sender, EventArgs e)
        {
            int MaPhieu = PhieuNhapXuatList.GetMaPhieuBySoPhieu(txt_SoPhieu.EditValue.ToString());

            DataTable dt = PhieuNhapXuatList.GetPhieuXuatByPhieuNhap(MaPhieu, 2);
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
                    linkLabel1.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel1.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel1.Links.Add(link);
                }
                else if (index == 2)
                {
                    linkLabel2.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel2.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel2.Links.Add(link);
                }
                else if (index == 3)
                {
                    linkLabel3.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel3.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel3.Links.Add(link);
                }
                else if (index == 4)
                {
                    linkLabel4.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel4.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel4.Links.Add(link);
                }
                else if (index == 5)
                {
                    linkLabel5.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel5.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel5.Links.Add(link);
                }
                else if (index == 6)
                {
                    linkLabel6.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel6.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel6.Links.Add(link);
                }
                else if (index == 7)
                {
                    linkLabel7.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel7.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel7.Links.Add(link);
                }
                else if (index == 8)
                {
                    linkLabel8.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel8.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel8.Links.Add(link);
                }
                else if (index == 9)
                {
                    linkLabel9.Text = dr["SoPhieuNhap"].ToString();
                    linkLabel9.Links.RemoveAt(0);
                    LinkLabel.Link link = new LinkLabel.Link();
                    link.LinkData = dr["mapn"].ToString();
                    linkLabel9.Links.Add(link);
                }
                i++;

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
            txt_SoPhieu_EditValueChanged(sender, e);
        }

        List<ChiTietXuatKhoFromOtherDB> _chitietxuatkhoaListSelectedXuatCapPhat = new List<ChiTietXuatKhoFromOtherDB>();
        private void lookUpEdit_NhanVien_EditValueChanged(object sender, EventArgs e)
        {
            //if (!_checkXemLaiPhieuXuat)
            //{
            //    if (_phieuXuatVTHH.Loai == 21)
            //    {
            //        if (PhieuNhapXuat.KiemTraXuatCapPhat(Convert.ToInt32(lookUpEdit_NhanVien.EditValue)).MaDoiTac == 0)
            //        {
            //            string dtac = DoiTac.GetDoiTac(Convert.ToInt32(lookUpEdit_NhanVien.EditValue)).MaQLDoiTac;
            //            NhomHangHoaBQ_VT nhomHangHoaIns = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();
            //            _chitietxuatkhoaListSelectedXuatCapPhat = ChiTietXuatKhoFromOtherDB.GetChiTietXuatCapPhatDongPhucFromOtherDBList(dtac, "CP");
            //            _phieuXuatVTHH.CT_PhieuXuatList.Clear();
            //            foreach (ChiTietXuatKhoFromOtherDB ctCapPhat in _chitietxuatkhoaListSelectedXuatCapPhat)
            //            {
            //                CT_PhieuXuat ctpxAdd = CT_PhieuXuat.NewCT_PhieuXuat();
            //                nhomHangHoaIns = NhomHangHoaBQ_VT.GetNhomHangHoaBQ_VT(ctCapPhat.TenMonHoc);
            //                if (nhomHangHoaIns != null && nhomHangHoaIns.MaNhomHangHoa != 0)
            //                {
            //                    //hanghoaListByMaNhom = HangHoaBQ_VTList.GetHangHoaBQ_VTListByMaNhom(nhomHangHoaIns.MaNhomHangHoa);
            //                    ctpxAdd.MaNhomHangHoa = nhomHangHoaIns.MaNhomHangHoa;
            //                    //ctpxAdd.MaHangHoa = hanghoaListByMaNhom[0].MaHangHoa;
            //                }
            //                ctpxAdd.SoLuong = ctCapPhat.SoLuong;
            //                ctpxAdd.DienGiai = ctCapPhat.TenMonHoc;
            //                _phieuXuatVTHH.CT_PhieuXuatList.Add(ctpxAdd);
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Học sinh này đã được cấp phát", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            _phieuXuatVTHH.CT_PhieuXuatList.Clear();
            //        }
            //    }
            //}

        }

        private void btnXuatKhoTuDeNghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CT_PhieuXuatList ctPhieuXuatListKiemTra = CT_PhieuXuatList.NewCT_PhieuXuatList();
            bool checkDieuKiemInsertCT = false;
            frmGetPhieuDeNghiXuatDongPhuc frm = new frmGetPhieuDeNghiXuatDongPhuc("", _loaiPhieu);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                if (frm.PhieuDeNhiXuatDongPhucListSelected.Count > 0)
                {
                    _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
                    _phieuXuatVTHH.Loai = _loaiPhieu;
                    _phieuXuatVTHH.PhuongPhapNX = 2;
                    _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_loaiPhieu, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
                    foreach (PhieuDeNghiXuatDongPhuc pdnxdp in frm.PhieuDeNhiXuatDongPhucListSelected)
                    {
                        //_phieuXuatVTHH.MaDoiTac = pdnxdp.MaDoiTac;
                        //_phieuXuatVTHH.PhuongPhapNX = pdnxdp.PhuongPhapNX;
                        _phieuXuatVTHH.DienGiai = pdnxdp.DienGiai;
                        _phieuXuatVTHH.MaPhongBan = pdnxdp.MaPhongBan;
                        _phieuXuatVTHH.SoCTKemTheo = pdnxdp.SoCTKemTheo;
                    }
                }
                if (frm.CT_PhieuDeNhiXuatDongPhucListSelected.Count > 0)
                {
                    foreach (CT_PhieuDeNghiXuatDongPhuc ctpdn in frm.CT_PhieuDeNhiXuatDongPhucListSelected)
                    {
                        if (ctPhieuXuatListKiemTra.Count == 0)
                        {
                            CT_PhieuXuat ctpxKiemTra = CT_PhieuXuat.NewCT_PhieuXuat();
                            CT_PhieuXuat ctpx = CT_PhieuXuat.NewCT_PhieuXuat();
                            ctpxKiemTra.SoLuong = ctpx.SoLuong = ctpdn.SoLuong;
                            ctpxKiemTra.DienGiai = ctpx.DienGiai = ctpdn.DienGiai;
                            _phieuXuatVTHH.CT_PhieuXuatList.Add(ctpx);
                            ctPhieuXuatListKiemTra.Add(ctpxKiemTra);
                        }
                        else
                        {
                            foreach (CT_PhieuXuat ctpxKT in ctPhieuXuatListKiemTra)
                            {
                                if (ctpxKT.DienGiai == ctpdn.DienGiai)
                                {
                                    checkDieuKiemInsertCT = true;
                                    foreach (CT_PhieuXuat ct in _phieuXuatVTHH.CT_PhieuXuatList)
                                    {
                                        if (ct.DienGiai == ctpdn.DienGiai)
                                            ct.SoLuong += ctpdn.SoLuong;
                                    }
                                    break;
                                }
                                else
                                {
                                    checkDieuKiemInsertCT = false;
                                }
                            }
                            if (!checkDieuKiemInsertCT)
                            {
                                CT_PhieuXuat ctpxKiemTra = CT_PhieuXuat.NewCT_PhieuXuat();
                                CT_PhieuXuat ctpx = CT_PhieuXuat.NewCT_PhieuXuat();
                                ctpxKiemTra.SoLuong = ctpx.SoLuong = ctpdn.SoLuong;
                                ctpxKiemTra.DienGiai = ctpx.DienGiai = ctpdn.DienGiai;
                                _phieuXuatVTHH.CT_PhieuXuatList.Add(ctpx);
                                ctPhieuXuatListKiemTra.Add(ctpxKiemTra);
                            }
                        }
                    }
                }
            }
            GanBindingSource();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "TabPhieu")
            {
                btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
                btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkEdit_Ngay.Checked == true)
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuXuatDongPhucList_Tim("SearchByDate", Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(gridLookUpEdit1.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.Loai, UserId);
            }
            else
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuXuatDongPhucList_Tim("SearchAll", Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(gridLookUpEdit1.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.Loai, UserId);
            }

            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
            if (_phieuNhapXuatList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
        }

        private void grdv_DanhSachPhieuNhapXuat_DoubleClick(object sender, EventArgs e)
        {
            _checkXemLaiPhieuXuat = true;
            xtraTabControl1.SelectedTabPageIndex = 0;
            //_phieuDeNghiXuatDongPhuc = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuDeNghiXuatDongPhuc;
            _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
            //phieuDeNghiXuatBindingSource.Clear();
            _phieuXuatVTHH = PhieuNhapXuat.GetPhieuNhapXuat(((PhieuNhapXuat)phieuNhapXuatListBindingSource.Current).MaPhieuNhapXuat);
            _ngayLapCu = _phieuXuatVTHH.NgayNX;

            if (_phieuXuatVTHH.MaPhieuNhapXuatThamChieu != 0)
            {
                LockData();
            }
            else
            {
                UnLockData();
            }

            if (_phieuXuatVTHH.MaDeNghiXuat != 0)
            {
                PhieuDeNghiXuatDongPhuc obj = PhieuDeNghiXuatDongPhuc.GetPhieuDeNghiXuatDongPhuc(_phieuXuatVTHH.MaDeNghiXuat);
                _phieuDeNghiList.Add(obj);
            }

            GanBindingSource();
        }

        private void cboPhieuDeNghi_EditValueChanged(object sender, EventArgs e)
        {
            if (blnIsLoadCboPhieuDeNghi == false)
                return;

            int maPhieuDeNghi = 0;
            maPhieuDeNghi = (int)cboPhieuDeNghi.EditValue;
            PhieuDeNghiXuatDongPhuc objPDN = PhieuDeNghiXuatDongPhuc.GetPhieuDeNghiXuatDongPhuc(maPhieuDeNghi);
            _phieuXuatVTHH.CT_PhieuXuatList.Clear();
            //_phieuXuatVTHH.NgayNX = objPND.NgayNX;
            _phieuXuatVTHH.MaDeNghiXuat = maPhieuDeNghi;
            dateEdit_NgayLap.EditValue = objPDN.NgayNX.Date;
            _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, objPDN.NgayNX);
            textEdit_DienGiai.Text = objPDN.HoTen + " - " + objPDN.GioiTinh + " - " + objPDN.Lop;
            _phieuXuatVTHH.DienGiai = textEdit_DienGiai.Text;
            lookUpEdit_NhanVien.EditValue = objPDN.MaDoiTac;
            _phieuXuatVTHH.MaDoiTac = objPDN.MaDoiTac;

            foreach (CT_PhieuDeNghiXuatDongPhuc objChiTietDeNghi in objPDN.CT_PhieuDeNghiXuatDongPhucList)
            {
                CT_PhieuXuat objChiTietPhieuXuat = CT_PhieuXuat.NewCT_PhieuXuat();
                objChiTietPhieuXuat.DienGiai = objChiTietDeNghi.DienGiai;
                objChiTietPhieuXuat.SoLuong = objChiTietDeNghi.SoLuong;
                _phieuXuatVTHH.CT_PhieuXuatList.Add(objChiTietPhieuXuat);
            }
        }

        //END Spd_PhieuXuatVatTu

        #endregion//Cac Phuong Thuc Report
    }
}
