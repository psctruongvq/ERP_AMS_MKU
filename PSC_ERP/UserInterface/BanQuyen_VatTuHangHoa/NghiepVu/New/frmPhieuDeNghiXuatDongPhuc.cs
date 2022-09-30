using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using PSC_ERP_Common;
//22/09/2014
namespace PSC_ERP
{
    public partial class frmPhieuDeNghiXuatDongPhuc : XtraForm
    {
        #region Properties
        PhieuDeNghiXuatDongPhuc _phieuDeNghiXuatDongPhuc;
        CT_PhieuNhapList _ct_PhieuNhapListChon;//
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _doiTacList;
        //bool _flag = true;
        bool _daChonPhieuNhap = false;
        decimal _soLuongHienCo = 0;//M
        PhieuNhapXuatList _phieuNhapXuat;
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
        private int _loaiPhieu = 0;

        #region BS KhoaSoTK
        private bool _isCellValuechangeBT = true;
        private bool _coTKBiKhoa = false;
        #endregion//BS KhoaSoTK
        private BindingSource LoaiThueSuatListBindingSource = new BindingSource();
        private Guid _oidBienLai = Guid.NewGuid();
        private int _idBienLai = 0;
        private bool isThayDoiSoLieu = false;
        private string _maTruong = "";
        #endregion Properties
        //
        #region  Functions
        private void GanBindingSource()
        {

            phieuDeNghiXuatBindingSource.DataSource = _phieuDeNghiXuatDongPhuc;
            cTPhieuXuatDongPhucListBindingSource.DataSource = _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList;
            //butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
        }
        private bool KiemTraLapTuBienLaiHopLe(List<ChiTietXuatKhoFromOtherDB> chitietxuatkholistSelected)
        {
            //_oidBienLai = Guid.NewGuid();
            //_idBienLai = 0;
            //foreach (CT_PhieuXuat itemct_px in _phieuXuatVTHH.CT_PhieuXuatList)
            //{
            //    if (itemct_px.OidMaBienLai != Guid.Empty)
            //    {
            //        _oidBienLai = itemct_px.OidMaBienLai;
            //    }
            //    if (itemct_px.IDBienLai != 0)
            //    {
            //        _idBienLai = itemct_px.IDBienLai;
            //    }
            //}
            //if (_oidBienLai == Guid.Empty) _oidBienLai = chitietxuatkholistSelected[0].MaBienLai;
            //if (_idBienLai == 0) _idBienLai = chitietxuatkholistSelected[0].MaBienLaiInt;
            //foreach (ChiTietXuatKhoFromOtherDB ctbienlai in chitietxuatkholistSelected)
            //{
            //    if (_idBienLai == 0 && _oidBienLai != Guid.Empty && ctbienlai.MaBienLai != _oidBienLai)//Không Cùng bienlai
            //    {
            //        MessageBox.Show("Không cùng Biên lai xuất kho!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //    else if (_oidBienLai == Guid.Empty && _idBienLai != 0 && ctbienlai.MaBienLaiInt != _idBienLai)//Không Cùng bienlai
            //    {
            //        MessageBox.Show("Không cùng Biên lai xuất kho!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}
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
                string Lop = "";
                string GioiTinh = "";
                List<ChiTietXuatKhoFromOtherDB> chitietxuatkholistSelected = frm.ChiTietXuatKhoListSelected;//M
                if (chitietxuatkholistSelected.Count != 0)//M
                {
                    btnThemMoi.PerformClick();
                    lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
                    NhomHangHoaBQ_VT nhomHangHoaIns = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();
                    HangHoaBQ_VTList hanghoaListByMaNhom = HangHoaBQ_VTList.NewHangHoaBQ_VTList();
                    StringBuilder soBienLaiStr = new StringBuilder("");
                    foreach (ChiTietXuatKhoFromOtherDB ctbienlai in chitietxuatkholistSelected)
                    {
                        bool insert = true;
                        if (_phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList.Count > 0)
                        {
                            //foreach (CT_ChungTuBienLaiChild item in _ChungTu.CT_ChungTuBienLaiList)
                            foreach (CT_PhieuDeNghiXuatDongPhuc item in _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList)
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
                            Lop = ctbienlai.TenLop;
                            GioiTinh = ctbienlai.GioiTinh;
                            #region Tao CT_PhieuXuat
                            CT_PhieuDeNghiXuatDongPhuc ctpxAdd = CT_PhieuDeNghiXuatDongPhuc.NewCT_PhieuDeNghiXuatDongPhuc();
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
                            _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList.Add(ctpxAdd);
                            #endregion Tao CT_PhieuXuat
                            GanBindingSource();
                        }
                    }

                    _phieuDeNghiXuatDongPhuc.MaDoiTac = MaDoiTac;
                    _phieuDeNghiXuatDongPhuc.Lop = Lop;
                    _phieuDeNghiXuatDongPhuc.GioiTinh = GioiTinh;
                }
            }
            #endregion//Process
            GanBindingSource();

        }

        private void DesignGrid_grdViewCt_PhieuXuat()
        {//grdViewCt_PhieuXuat
            grdCT_PhieuXuat.DataSource = cTPhieuXuatDongPhucListBindingSource;
            HamDungChung.InitGridViewDev(grdViewCt_PhieuXuat, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdViewCt_PhieuXuat, new string[] { "MaNhomHangHoa", "MaHangHoa", "MaDonViTinh", "SoLuong", "DienGiai" },
                                new string[] { "Nhóm HH", "Hàng Hóa Vật Tư", "ĐVT", "Số lượng", "Ghi chú" },
                                             new int[] { 120, 120, 80, 90, 90 });


            HamDungChung.AlignHeaderColumnGridViewDev(grdViewCt_PhieuXuat, new string[] { "MaNhomHangHoa", "MaHangHoa", "MaDonViTinh", "SoLuong", "DienGiai" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdViewCt_PhieuXuat, new string[] { "SoLuong" }, "#,###.##");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdViewCt_PhieuXuat, new string[] { "SoLuong" }, "{0:#,###.#}");
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
            //decimal tongtienCP = 0;
            //decimal tongtienThue = 0;
            //if (butToan != null)
            //{
            //    foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
            //    {
            //        tongtienCP += ct_PhieuXuat.ThanhTien;
            //        tongtienThue = tongtienThue + ct_PhieuXuat.TienThue;
            //    }
            //    foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuXuatVTHH.ButToanPhieuNhapXuatList)
            //    {
            //        if (IsTaiKhoanThueKhauTru(buttoanphieu.NoTaiKhoan))
            //        {
            //            tongtienThue = tongtienThue - buttoanphieu.SoTien;
            //        }
            //        else
            //        {
            //            tongtienCP = tongtienCP - buttoanphieu.SoTien;
            //        }
            //    }
            //    if (IsTaiKhoanThueKhauTru(butToan.NoTaiKhoan))
            //    {
            //        butToan.SoTien = tongtienThue;
            //    }
            //    else
            //    {
            //        butToan.SoTien = tongtienCP;
            //    }
            //    butToan.DienGiai = _phieuXuatVTHH.DienGiai;
            //}
        }

        private void LockData()
        {
            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
            grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
            //grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            //grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = true;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        void UnLockData()
        {
            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = true;
            grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = true;
            //grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = true;
            //grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = true;
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
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
        }

        void AllowDelete()
        {
        }

        void NotAllowDelete()
        {
        }

        void CheckPhuongPhapNX()
        {
            //if (_phieuDeNghiXuatDongPhuc != null)
            //{
            //    if (_phieuDeNghiXuatDongPhuc.PhuongPhapNX == 2)
            //    {
            //        grdViewCt_PhieuXuat.Columns["SoPhieuNhap"].Visible = true;
            //    }
            //    else
            //    {
            //        grdViewCt_PhieuXuat.Columns["SoPhieuNhap"].Visible = false;
            //    }
            //}
        }

        void CapNhatTongTienPhieu()
        {
            //Decimal tongTien = 0;
            //foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
            //{
            //    tongTien += ct_PhieuXuat.ThanhTien;
            //}
            //_phieuXuatVTHH.GiaTriKho = tongTien;
        }
        #region KhoaSoTaiKhoan
        private void LockgrdView_DinhKhoan()
        {

            //grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = false;//
            //grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;

        }//Them

        private void UnLockgrdView_DinhKhoan()
        {

            //grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = true;//
            //grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = true;
        }//Them

        //private bool CheckCoTaiKhoanBiKhoaTrongButToan()
        //{
        //    foreach (ButToanPhieuNhapXuat buttoan in _phieuXuatVTHH.ButToanPhieuNhapXuatList)
        //    {
        //        //tblTaiKhoan tk = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.NoTaiKhoan ?? 0);
        //        //tblTaiKhoan tkco = TaiKhoan_Factory.New().Get_TaiKhoan_ByMaTaiKhoan(buttoan.CoTaiKhoan ?? 0);
        //        if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //private bool CheckValidKhoaTaiKhoanWhenChangeNgayCT()//Them
        //{
        //    if (CheckCoTaiKhoanBiKhoaTrongButToan())
        //    {
        //        MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa Tài khoản, không thể thực hiện", "Thông Báo");
        //        _phieuXuatVTHH.NgayNX = _ngayLapCu;
        //        dateEdit_NgayLap.EditValue = _ngayLapCu as object;
        //        return false;
        //    }
        //    return true;
        //}

        //private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        //{

        //    bool khoataiKhoan = false;
        //    KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _phieuXuatVTHH.NgayNX);
        //    if (khoa.Count > 0)
        //    {
        //        if (khoa[0].KhoaSo == true)
        //        {
        //            khoataiKhoan = true;
        //        }
        //    }

        //    if (khoataiKhoan == false && _phieuXuatVTHH.IsNew == false)
        //    {
        //        khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _ngayLapCu);
        //        if (khoa.Count > 0)
        //        {
        //            if (khoa[0].KhoaSo == true)
        //            {
        //                khoataiKhoan = true;
        //            }
        //        }
        //    }
        //    return khoataiKhoan;
        //}//Them
        private void EventRowOrColumnGrdView_DinhKhoanChange()
        {
            //UnLockgrdView_DinhKhoan();
            //if (grdView_DinhKhoan.GetFocusedRow() != null)
            //{
            //    ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetFocusedRow();
            //    if (KhoaButToanTheoTaiKhoan(buttoan.NoTaiKhoan) || KhoaButToanTheoTaiKhoan(buttoan.CoTaiKhoan))
            //    {
            //        if (buttoan.MaButToan == 0)
            //        {
            //            _isCellValuechangeBT = false;
            //            MessageBox.Show(this, "Đã khóa sổ tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            buttoan.NoTaiKhoan = 0;
            //            buttoan.CoTaiKhoan = 0;
            //            _isCellValuechangeBT = true;
            //        }
            //        else
            //            LockgrdView_DinhKhoan();
            //    }
            //}

            //#region KhoaSoThue
            ////if (KhoaSoThue())
            ////{
            ////    if (grdView_DinhKhoan.GetFocusedRow() != null)
            ////    {
            ////        ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetFocusedRow();
            ////        HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
            ////        if (tk.SoHieuTK.StartsWith("3113"))
            ////        {
            ////            LockgrdView_DinhKhoan();
            ////        }
            ////        else
            ////        {
            ////            UnLockgrdView_DinhKhoan();
            ////        }
            ////    }
            ////}
            ////else
            ////{
            ////    UnLockgrdView_DinhKhoan();
            ////}
            //#endregion//KhoaSoThue


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
        private void KhoiTaoN(int loaiPhieu)
        {
            bs_NhomHangHoaList.DataSource = typeof(NhomHangHoaBQ_VTList);
            //PhieuNhapXuatList_bindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            //heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            //heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            //doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            

            //_boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            //boPhanListBindingSource.DataSource = _boPhanList;
            LoadBoPhanList();
            _khoBQ_VTList = KhoBQ_VTList.GetKhoVatTuList();
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;

            if (loaiPhieu == 27 || loaiPhieu == 28)
            {
                if (loaiPhieu == 27)
                {
                    _doiTacList = DoiTacList.GetHocSinhFormBienLai("8");
                    DoiTac _doiTac = DoiTac.NewDoiTac(0, "<<None>>");
                    _doiTacList.Insert(0, _doiTac);
                    doiTacListBindingSource.DataSource = _doiTacList;
                }
                else
                {
                    _doiTacList = DoiTacList.GetHocSinhFormBienLai("10");
                    DoiTac _doiTac = DoiTac.NewDoiTac(0, "<<None>>");
                    _doiTacList.Insert(0, _doiTac);
                    doiTacListBindingSource.DataSource = _doiTacList;
                }
            }
            else
            {
                _doiTacList = DoiTacList.GetDoiTacHocSinhList();
                DoiTac _doiTac = DoiTac.NewDoiTac(0, "<<None>>");
                _doiTacList.Insert(0, _doiTac);
                doiTacListBindingSource.DataSource = _doiTacList;
                lookUpEdit_NhanVien.Properties.View.Columns["NgaySinh"].Visible = false;
                lookUpEdit_NhanVien.Properties.View.Columns["GioiTinh"].Visible = false;
                lookUpEdit_NhanVien.Properties.View.Columns["TenLop"].Visible = false;
                lookUpEdit_NhanVien.Properties.View.Columns["TenKhoi"].Visible = false;
                lookUpEdit_NhanVien.Properties.View.Columns["TenTruong"].Visible = false;
                lookUpEdit_NhanVien.Properties.PopupFormSize = new Size(300, 0);
            }



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
        private void KhoiTaoPhieu()
        {
            _phieuDeNghiXuatDongPhuc = PhieuDeNghiXuatDongPhuc.NewPhieuDeNghiXuatDongPhuc();
            _phieuDeNghiXuatDongPhuc.SoPhieu = PublicClass.SetSoChungTuByMaLoaiChungTu(this._loaiPhieu, _phieuDeNghiXuatDongPhuc.NgayNX);
            cTPhieuXuatDongPhucListBindingSource.DataSource = _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList;

            phieuDeNghiXuatBindingSource.DataSource = _phieuDeNghiXuatDongPhuc;

            if (_boPhanList.Count != 0)
                _phieuDeNghiXuatDongPhuc.MaPhongBan = _boPhanList[0].MaBoPhan;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
        }

        private void KhoiTaoPhieu(int loai)
        {
            _phieuDeNghiXuatDongPhuc = PhieuDeNghiXuatDongPhuc.NewPhieuDeNghiXuatDongPhuc();
            _phieuDeNghiXuatDongPhuc.SoPhieu = PublicClass.SetSoChungTuByMaLoaiChungTu(loai, _phieuDeNghiXuatDongPhuc.NgayNX);
            _phieuDeNghiXuatDongPhuc.Loai = loai;
            cTPhieuXuatDongPhucListBindingSource.DataSource = _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList;

            phieuDeNghiXuatBindingSource.DataSource = _phieuDeNghiXuatDongPhuc;

            if (_boPhanList.Count != 0)
                _phieuDeNghiXuatDongPhuc.MaPhongBan = _boPhanList[0].MaBoPhan;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;

        }

        //private void KhoiTaoPhieuXuatBanDongPhuc(int loaiPhieu)
        //{
        //    _phieuDeNghiXuatDongPhuc = PhieuDeNghiXuatDongPhuc.NewPhieuDeNghiXuatDongPhuc();
        //    _phieuDeNghiXuatDongPhuc.Loai = 26;
        //    _phieuDeNghiXuatDongPhuc.SoPhieu = PublicClass.SetSoChungTuByMaLoaiChungTu(_phieuDeNghiXuatDongPhuc.Loai, _phieuDeNghiXuatDongPhuc.NgayNX);
        //    cTPhieuXuatDongPhucListBindingSource.DataSource = _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList;

        //    phieuDeNghiXuatBindingSource.DataSource = _phieuDeNghiXuatDongPhuc;

        //    if (_boPhanList.Count != 0)
        //        _phieuDeNghiXuatDongPhuc.MaPhongBan = _boPhanList[0].MaBoPhan;
        //    lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
        //}

        private void KhoiTaoPhieuDeNghiXuatDongPhuc(int loaiPhieu)
        {
            _phieuDeNghiXuatDongPhuc = PhieuDeNghiXuatDongPhuc.NewPhieuDeNghiXuatDongPhuc();
            _phieuDeNghiXuatDongPhuc.Loai = loaiPhieu;
            _phieuDeNghiXuatDongPhuc.SoPhieu = PublicClass.SetSoChungTuByMaLoaiChungTu(_phieuDeNghiXuatDongPhuc.Loai, _phieuDeNghiXuatDongPhuc.NgayNX);

            phieuDeNghiXuatBindingSource.DataSource = _phieuDeNghiXuatDongPhuc;

            if (_boPhanList.Count != 0)
                _phieuDeNghiXuatDongPhuc.MaPhongBan = _boPhanList[0].MaBoPhan;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
        }

        #endregion//Function

        void formatGriview()
        {
            this.grdViewCt_PhieuXuat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            //this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }


        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuDeNghiXuatDongPhuc cT_PhieuDeNghiXuatDongPhuc in _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList)
            {
                ////if (cT_PhieuDeNghiXuatDongPhuc.MaHangHoa == 0)
                ////{
                ////    kq = false;
                ////    MessageBox.Show(this, "Vui lòng nhập hàng hóa cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ////    break;
                ////}
                //else if (cT_PhieuDeNghiXuatDongPhuc.SoLuong == 0)
                //{
                //    kq = false;
                //    MessageBox.Show(this, "Vui lòng nhập số lượng cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    break;
                //}
            }

            return kq;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = false;
            //if (_phieuDeNghiXuatDongPhuc.MaPhongBan == 0)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    lookUpEdit_PhongBan.Focus();
            //}
            //else if (_phieuXuatVTHH.MaNguoiNhapXuat == 0)
            //{
            //    MessageBox.Show(this, "Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    lookUpEdit_NhanVien.Focus();
            //}

            // if (_phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList.Count == 0)
            //    MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //else if (KiemTraChiTiet() == false)
            //{
            //    grdViewCt_PhieuXuat.Focus();
            //}
            //else kq = true;
            return kq;
        }


        #endregion//End Function
        public frmPhieuDeNghiXuatDongPhuc()
        {
            InitializeComponent();
            //KhoiTaoPhieu();
            KhoiTao_PhuongPhapNX();
            //AnHienBtnChonXThang();
            btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        public void ShowPhieuXuatBanDongPhuc()
        {
            _loaiPhieu = 26;
            KhoiTaoPhieuDeNghiXuatDongPhuc(_loaiPhieu);
            _phieuDeNghiXuatDongPhuc.PhuongPhapNX = 1;
            _phieuDeNghiXuatDongPhuc.MaNguoiLap = UserId;
            this.Text = "Phiếu Đề Nghị Xuất Bán Đồng Phục";
            xtraTabPage1.Text = "Phiếu Đề Nghị Xuất Bán Đồng Phục";
            xtraTabPage2.Text = "Danh Sách Đề Nghị Xuất Bán Đồng Phục";
            _phieuDeNghiXuatDongPhuc.DienGiai = "Xuất Bán Đồng Phục";
            KhoiTaoN(_loaiPhieu);
        }

        public void ShowPhieuXuatCapPhatDongPhucBCIS()
        {
            _loaiPhieu = 27;
            KhoiTaoPhieuDeNghiXuatDongPhuc(_loaiPhieu);
            _phieuDeNghiXuatDongPhuc.PhuongPhapNX = 1;
            _phieuDeNghiXuatDongPhuc.MaNguoiLap = UserId;
            this.Text = "Phiếu Đề Nghị Xuất Cấp Phát Đồng Phục - BCIS";
            xtraTabPage1.Text = "Phiếu Đề Nghị Xuất Cấp Phát Đồng Phục - BCIS";
            xtraTabPage2.Text = "Danh Sách Đề Nghị Xuất Cấp Phát Đồng Phục - BCIS";
            _phieuDeNghiXuatDongPhuc.DienGiai = "Xuất Cấp Phát Đồng Phục - BCIS";
            KhoiTaoN(_loaiPhieu);
            _maTruong = "8";
        }

        public void ShowPhieuXuatCapPhatDongPhucCIS()
        {
            _loaiPhieu = 28;
            KhoiTaoPhieuDeNghiXuatDongPhuc(_loaiPhieu);
            _phieuDeNghiXuatDongPhuc.PhuongPhapNX = 1;
            _phieuDeNghiXuatDongPhuc.MaNguoiLap = UserId;
            this.Text = "Phiếu Đề Nghị Xuất Cấp Phát Đồng Phục - CIS";
            xtraTabPage1.Text = "Phiếu Đề Nghị Xuất Cấp Phát Đồng Phục - CIS";
            xtraTabPage2.Text = "Danh Sách Đề Nghị Xuất Cấp Phát Đồng Phục - CIS";
            _phieuDeNghiXuatDongPhuc.DienGiai = "Xuất Cấp Phát Đồng Phục - CIS";
            KhoiTaoN(_loaiPhieu);
            _maTruong = "10";
        }

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (_edtiBophan && lookUpEdit_PhongBan.EditValue != null)
            {
                int mabophabout;
                if (int.TryParse(lookUpEdit_PhongBan.EditValue.ToString(), out mabophabout))
                {
                    LoadDataForthongTinNhanVienTongHopListBindingSource(mabophabout);
                }
                //thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
            }
            //_phieuXuatVTHH.MaPhongBan = (int)lookUpEdit_PhongBan.EditValue;
        }
        private void LoadDataForthongTinNhanVienTongHopListBindingSource(int maboPHan)
        {
        }
        #endregion

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _phieuDeNghiXuatDongPhucList = PhieuDeNghiXuatDongPhucList.NewPhieuDeNghiXuatDongPhucList();
            TimPhieuDeNghiXuatBindingSource.DataSource = _phieuDeNghiXuatDongPhuc;
            _coTKBiKhoa = false;
            KhoiTaoPhieu(this._loaiPhieu);
            dateEdit_NgayLap.Focus();
            _daChonPhieuNhap = false;
            _phieuTuDSPhieuNhapXuat = false;
            _tu1PhieuNhap = false;
            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = true;
            UnLockData();
            CheckPhuongPhapNX();
            AllowDelete();
            _checkXemLaiPhieuXuat = false;
            if (_loaiPhieu == 26)
                _phieuDeNghiXuatDongPhuc.DienGiai = "Xuất Bán Đồng Phục";
            else
                _phieuDeNghiXuatDongPhuc.DienGiai = "Xuất Cấp Phát Đồng Phục";

            btnCapNhatHocSinh.PerformClick();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit_Focus.Focus();
            Application.DoEvents();

            //End Add to 18012013
            if (_loaiPhieu == 27 || _loaiPhieu == 28)
            {
                DoiTac getNamHoc = (DoiTac)lookUpEdit_NhanVien.Properties.GetRowByKeyValue(lookUpEdit_NhanVien.EditValue);
                if (PhieuDeNghiXuatDongPhuc.KiemTraXuatCapPhat(Convert.ToInt32(lookUpEdit_NhanVien.EditValue), getNamHoc.NamHoc, _loaiPhieu).MaDoiTac == 0)
                {
                    if (txt_SoPhieu.EditValue != null)//IF 1
                    {
                        string _soPhieu = txt_SoPhieu.EditValue.ToString();
                        //int _stt;
                        //if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                        //{
                        bool ktphieutrung = true;
                        if (_phieuDeNghiXuatDongPhuc.IsNew)
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuDeNghiXuatDongPhuc.MaDeNghiXuat, _phieuDeNghiXuatDongPhuc.SoPhieu, true);
                        }
                        else//k phai IS NEW
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuDeNghiXuatDongPhuc.MaDeNghiXuat, _phieuDeNghiXuatDongPhuc.SoPhieu, false);
                        }
                        if (ktphieutrung)//IF 5
                        {
                            //
                            try
                            {
                                //if (KiemTraDuLieu())
                                //{
                                phieuDeNghiXuatBindingSource.EndEdit();
                                _phieuDeNghiXuatDongPhuc.ApplyEdit();
                                _phieuDeNghiXuatDongPhuc.Save();
                                if (_phieuDeNghiXuatDongPhuc != null)
                                {
                                    if (_phieuDeNghiXuatDongPhuc.PhuongPhapNX == 2)
                                    {
                                        //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                                        LockData();
                                    }
                                }
                                //Add to 11012013
                                _ngayLapCu = _phieuDeNghiXuatDongPhuc.NgayNX;
                                //End Add to 11012013
                                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
                                //}
                            }
                            catch (Exception ex)
                            {
                                DialogUtil.ShowWarning("Cập Nhật Thất Bại!\n"+ ex.Message);
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
                else if(_phieuDeNghiXuatDongPhuc.IsNew == false)
                {
                    try
                    {
                        //if (KiemTraDuLieu())
                        //{
                        phieuDeNghiXuatBindingSource.EndEdit();
                        _phieuDeNghiXuatDongPhuc.ApplyEdit();
                        _phieuDeNghiXuatDongPhuc.Save();
                        if (_phieuDeNghiXuatDongPhuc != null)
                        {
                            if (_phieuDeNghiXuatDongPhuc.PhuongPhapNX == 2)
                            {
                                //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                                LockData();
                            }
                        }
                        //Add to 11012013
                        _ngayLapCu = _phieuDeNghiXuatDongPhuc.NgayNX;
                        //End Add to 11012013
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
                        //}
                    }
                    catch (Exception ex)
                    {
                        DialogUtil.ShowWarning("Cập Nhật Thất Bại!\n" + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Học sinh này đã được cấp phát", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (_loaiPhieu == 26)
            {
                if (txt_SoPhieu.EditValue != null)//IF 1
                {
                    string _soPhieu = txt_SoPhieu.EditValue.ToString();
                    //int _stt;
                    //if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                    //{
                    bool ktphieutrung = true;
                    if (_phieuDeNghiXuatDongPhuc.IsNew)
                    {
                        ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuDeNghiXuatDongPhuc.MaDeNghiXuat, _phieuDeNghiXuatDongPhuc.SoPhieu, true);
                    }
                    else//k phai IS NEW
                    {
                        ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuDeNghiXuatDongPhuc.MaDeNghiXuat, _phieuDeNghiXuatDongPhuc.SoPhieu, false);
                    }
                    if (ktphieutrung)//IF 5
                    {
                        //
                        try
                        {
                            //if (KiemTraDuLieu())
                            //{
                            phieuDeNghiXuatBindingSource.EndEdit();
                            _phieuDeNghiXuatDongPhuc.ApplyEdit();
                            _phieuDeNghiXuatDongPhuc.Save();
                            if (_phieuDeNghiXuatDongPhuc != null)
                            {
                                if (_phieuDeNghiXuatDongPhuc.PhuongPhapNX == 2)
                                {
                                    //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                                    LockData();
                                }
                            }
                            //Add to 11012013
                            _ngayLapCu = _phieuDeNghiXuatDongPhuc.NgayNX;
                            //End Add to 11012013
                            MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
                            //}
                        }
                        catch (Exception ex)
                        {
                            DialogUtil.ShowWarning("Cập Nhật Thất Bại!\n"+ ex.Message);
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
            //HamDungChung.CopyCell(grdView_DinhKhoan, e);
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
            if (cTPhieuXuatDongPhucListBindingSource.Current != null)
            {
                CT_PhieuDeNghiXuatDongPhuc _ct_PhieuXuat = (CT_PhieuDeNghiXuatDongPhuc)cTPhieuXuatDongPhucListBindingSource.Current;

                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHangHoa")
                {

                    grdCT_PhieuXuat.Update();
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(_ct_PhieuXuat.MaHangHoa);
                    _ct_PhieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                    if (_phieuDeNghiXuatDongPhuc.PhuongPhapNX == 1)
                    {
                        //_ct_PhieuXuat.DonGia = HangHoaBQ_VT.GetGiaTriBinhQuanHangHoa(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        //
                        //_soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        //_ct_PhieuXuat.SoLuong = _soLuongHienCo;
                        //_ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        //
                    }

                }
                //if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colSoLuong")
                //{
                //    decimal soluong_gv = 0;
                //    if (decimal.TryParse(e.Value.ToString(), out soluong_gv))
                //    {
                //        if (_phieuDeNghiXuatDongPhuc.PhuongPhapNX == 2)//Trong T/H Xuat thang tu 1 Phieu Nhap
                //        {
                //            if (!_phieuTuDSPhieuNhapXuat)//Khong Phai Phieu Load Tu DS Phieu NHap Xuat
                //            {
                //                if (soluong_gv > _ct_PhieuXuat.SLgCt_PNhap)
                //                {
                //                    MessageBox.Show("Số lượng xuất vượt quá chi tiết nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //                    grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_ct_PhieuXuat.SLgCt_PNhap);
                //                }
                //                else if (soluong_gv == _ct_PhieuXuat.SLgCt_PNhap)
                //                {
                //                    //_ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaNXT(_phieuDeNghiXuatDongPhuc.MaPhieuNhapXuat, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaHangHoa, _phieuXuatVTHH.NgayNX, _ct_PhieuXuat.DonGia);//New 19112013
                //                }
                //                else
                //                {
                //                    grdCT_PhieuXuat.Update();
                //                    _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                //                }
                //            }
                //        }//END Trong T/H Xuat thang tu 1 Phieu Nhap
                //        else//Trong T/H Xuat Binh Thuong
                //        {
                //            //_soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuDeNghiXuatDongPhuc., _phieuDeNghiXuatDongPhuc.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                //            //if (soluong_gv > _soLuongHienCo)
                //            //{
                //            //    MessageBox.Show("Số lượng còn " + _soLuongHienCo.ToString() + ". Không đủ xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            //    grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                //            //    _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                //            //}
                //            //else if (soluong_gv == _soLuongHienCo)
                //            //{
                //            //    grdCT_PhieuXuat.Update();
                //            //    _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                //            //}
                //            //else
                //            //{
                //            //    grdCT_PhieuXuat.Update();
                //            //    _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                //            //}
                //        }//END Trong T/H Xuat Binh Thuong
                //    }
                //}//IF thay doi tren cot So Luong
                //if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colDonGia")
                //{

                //    grdCT_PhieuXuat.Update();
                //    _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);

                //}
                //Decimal tongTien = 0;
                //foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
                //{
                //    tongTien = tongTien + ct_PhieuXuat.ThanhTien - ct_PhieuXuat.TienChietKhau + ct_PhieuXuat.TienThue;
                //}
                //_phieuXuatVTHH.GiaTriKho = tongTien;
                CapNhatTongTienPhieu();
                this.isThayDoiSoLieu = true;
            }

        }

        private void grdViewCt_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
        }
        private void grdViewCt_PhieuXuat_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //    CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
            //    _ct_PhieuXuat.DienGiai = _phieuDeNghiXuatDongPhuc.DienGiai;
        }
        //HangHoa_GrdLU_Popup
        private void HangHoa_GrdLU_Popup(object sender, EventArgs e)
        {
            if (cTPhieuXuatDongPhucListBindingSource.Current != null && grdViewCt_PhieuXuat.GetFocusedRow() != null)
            {
                CT_PhieuDeNghiXuatDongPhuc ctpxCur = cTPhieuXuatDongPhucListBindingSource.Current as CT_PhieuDeNghiXuatDongPhuc;
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
            //dataSet = new DataSet();
            //using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            //{

            //    cn.Open();
            //    //tao bang_PhieuXuatVatTu
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "Spd_PhieuXuatVatTu";
            //        cm.Parameters.AddWithValue("@MaPhieuXuatVTHH", _phieuXuatVTHH.MaPhieuNhapXuat);

            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        dt.TableName = "Spd_PhieuXuatVatTu;1";
            //        dataSet.Tables.Add(dt);
            //    }
            //    //tao bang_ReportHeaderAndFooter
            //    using (SqlCommand cm = cn.CreateCommand())
            //    {
            //        cm.CommandType = CommandType.StoredProcedure;
            //        cm.CommandText = "spd_ReportHeaderAndFooter";
            //        cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
            //        SqlDataAdapter da = new SqlDataAdapter(cm);
            //        DataTable dt = new DataTable();
            //        da.Fill(dt);
            //        dt.TableName = "spd_ReportHeaderAndFooter;1";
            //        dataSet.Tables.Add(dt);
            //    }

            //}//us 
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
                    string dtac = DoiTac.GetDoiTac(Convert.ToInt32(_phieuDeNghiXuatDongPhuc.MaDoiTac)).MaQLDoiTac;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 1800;
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

                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("SoPhieu", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["SoPhieu"] = txt_SoPhieu.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);
            }
            //}//us 
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
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetChiTietXuatBanDongPhucFromOtherDBList_Report";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@BillId", _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList[0].IDBienLai);
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
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("SoPhieu", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["SoPhieu"] = txt_SoPhieu.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);
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
            //else if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_ButToan")
            //    grdView_DinhKhoan.DeleteSelectedRows();
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
            //frmDSPhieuLinhNhienLieu frm = new frmDSPhieuLinhNhienLieu(_phieuXuatVTHH.MaKho, _phieuXuatVTHH.MaPhongBan, _phieuXuatVTHH.NgayNX, 2);
            //if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //{
            //    if (frm.PhieuLinhNhienLieuDuocChonList != null && frm.PhieuLinhNhienLieuDuocChonList.Count > 0)
            //    {
            //        KhoiTaoPhieu(frm.PhieuLinhNhienLieuDuocChonList);
            //        if (_phieuXuatVTHH.CT_PhieuXuatList.Count > 0)
            //        {
            //            LockData();
            //            NotAllowDelete();

            //        }
            //    }
            //}
        }

        private void lookUpEdit_PhuongPhapNX_EditValueChanged(object sender, EventArgs e)
        {
            byte ppnhapxuatOut = 0;
            if (byte.TryParse(lookUpEdit_PhuongPhapNX.EditValue.ToString(), out ppnhapxuatOut))
            {
                //ppnhapxuatOut =(byte) lookUpEdit_PPNXKho.EditValue;
            }
            if (ppnhapxuatOut == 2 || _phieuDeNghiXuatDongPhuc.Loai == 27)
            {
                //btnPhieuDeNghi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnXuatKhotuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                //btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                //btnPhieuDeNghi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnXuatKhotuBienLai.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            CheckPhuongPhapNX();
        }


        private void FrmPhieuXuatVatTuHangHoa_Load(object sender, EventArgs e)
        {
            btnPhieuDeNghi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            formatGriview();
            CheckPhuongPhapNX();
            //if (PhieuNhapXuat.KiemTraPhieuXuatTuDSPhieuDeNghiLinh(_phieuDeNghiXuatDongPhuc.MaPhieuNhapXuat))
            //{
            //    LockData();
            //    NotAllowDelete();
            //}
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuXuat, 35);
            //Utils.GridUtils.InitNewRowOnTopOfGridView(grdViewCt_PhieuXuat);
            //Utils.GridUtils.InitNewRowOnTopOfGridView(grdView_DinhKhoan);
            //if (_phieuXuatVTHH.IsNew == false)
            //{
            //    if (_phieuXuatVTHH != null)
            //    {
            //        if (PhieuNhapXuat.KiemTraPhieuXuatThangTuPhieuNhap(_phieuXuatVTHH.MaPhieuNhapXuat))
            //        {
            //            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
            //            LockData();
            //        }
            //    }
            //}
            //else if (_tu1PhieuNhap)
            //{
            //    //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
            //    LockData();
            //}
            //formatGridviewDinhKhoan();//Vat tu ban quyen
            //grdView_DinhKhoan.OptionsView.ShowFooter = true;
            //HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdView_DinhKhoan, new string[] { "SoTien" }, "{0:#,###.##}");
        }
        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            //HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(0);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                if (dlg.MaHangHoaChon != 0)
                {
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                    if (cTPhieuXuatDongPhucListBindingSource.Current == null || grdViewCt_PhieuXuat.GetFocusedRow() == null)
                        grdViewCt_PhieuXuat.AddNewRow();
                    CT_PhieuXuat ct_phieuXuat = (CT_PhieuXuat)cTPhieuXuatDongPhucListBindingSource.Current;
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
            PhieuDeNghiXuatDongPhuc pnx = _phieuDeNghiXuatDongPhuc;
            if (pnx != null)
            {
                //if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
                //{
                //    MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                //    return;
                //}

                //if (pnx.XacNhan == true)//Kiem Tra Thu Kho Xac Nhan
                //{
                //    MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                //
                //if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(pnx.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
                //{
                //    MessageBox.Show("Phiếu Nhập đã Xuất!\n Vui lòng xóa Phiếu Xuất trước khi xóa Phiếu Nhập!");
                //    return;
                //}
                //Delete Phieu
                if (MessageBox.Show(this, "Bạn muốn xóa Phiếu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        //_phieuDeNghiXuatDongPhuc.DeletePhieuDeNghiXuatDongPhuc(_phieuDeNghiXuatDongPhuc.MaDeNghiXuat);
                        PhieuDeNghiXuatDongPhuc.DeletePhieuDeNghiXuatDongPhuc(_phieuDeNghiXuatDongPhuc);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnTim.PerformClick();
                        btnThemMoi.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        DialogUtil.ShowWarning("Cập Nhật Thất Bại!\n"+ ex.Message);
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
                    //if (this._phieu.ButToanPhieuNhapXuatList.Count == 0)
                    //{
                    //    ButToanPhieuNhapXuat bt = ButToanPhieuNhapXuat.NewButToanPhieuNhapXuat();
                    //    int tkNo = HeThongTaiKhoan1.LayMaTaiKhoan("6272");
                    //    int tkCo = HeThongTaiKhoan1.LayMaTaiKhoan("1531");
                    //    bt.NoTaiKhoan = tkNo;
                    //    bt.CoTaiKhoan = tkCo;
                    //    bt.SoTien = this._phieuXuatVTHH.GiaTriKho;
                    //    this._phieuXuatVTHH.ButToanPhieuNhapXuatList.Add(bt);
                    //    //butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
                    //}
                    this.isThayDoiSoLieu = false;
                }
            }
            //else if (PhieuNhapXuat.KiemTraPhieuXuatTuDSPhieuDeNghiLinh(_phieuXuatVTHH.MaPhieuNhapXuat))
            //{
            //    NotAllowDelete();
            //}
        }


        private void grdView_DinhKhoan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            //if (grdView_DinhKhoan.FocusedColumn.Name == "col_btn")
            //{
            //    if (((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current) != null)
            //    {
            //        //Xu ly Tai day
            //        ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).BeginEdit();
            //        ButToanPhieuNhapXuat bt = (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current;
            //        #region Edit bug
            //        ChungTu_ChiPhiSanXuatList cpList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
            //        foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat in ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList)
            //        {
            //            cpList.Add(chungTu_ChiPhiSanXuat);
            //        }
            //        //ChungTu_ChiPhiSanXuatList cpList = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList;
            //        #endregion//Edit bug

            //        cpList.BeginEdit();
            //        frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuXuatVTHH.NgayNX, bt.DienGiai, bt.MaButToan);
            //        if (f.ShowDialog(this) != DialogResult.OK)
            //        {
            //            if (f.IsSave == true)
            //            {
            //                ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList = f._ChungTu_ChiPhiSXList;
            //                ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList.ApplyEdit();

            //            }
            //            else
            //            {
            //                cpList.CancelEdit();
            //            }
            //        }
            //        //
            //    }
            //}
        }
        private void dateEdit_NgayLap_Leave(object sender, EventArgs e)
        {
            //if (dateEdit_NgayLap.OldEditValue != dateEdit_NgayLap.EditValue)
            //{
            //    CheckValidKhoaTaiKhoanWhenChangeNgayCT();
            //}
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
            //            _phieuDeNghiXuatDongPhuc.MaPhongBan = nv.MaBoPhan;
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
            if (_loaiPhieu == 27 || _loaiPhieu == 28)
            {
                DoiTac getNamHoc = (DoiTac)lookUpEdit_NhanVien.Properties.GetRowByKeyValue(lookUpEdit_NhanVien.EditValue);
                if (PhieuDeNghiXuatDongPhuc.KiemTraXuatCapPhat(Convert.ToInt32(lookUpEdit_NhanVien.EditValue), getNamHoc.NamHoc, _loaiPhieu).MaDoiTac != 0)
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
                else
                {
                    MessageBox.Show("Vui lòng lưu phiếu trước khi in", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else if (_loaiPhieu == 26)
            {
                if (_phieuDeNghiXuatDongPhuc.MaDeNghiXuat != 0)
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
                else
                {
                    MessageBox.Show("Vui lòng lưu phiếu trước khi in", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();
          
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();          
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();          
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();           
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();           
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();           
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();         
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();          
        }

        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int target = Convert.ToInt32(e.Link.LinkData);
            PhieuNhapXuat _pnx = PhieuNhapXuat.GetPhieuNhapXuat(target);
            frmPhieuNhapVatTuHangHoa_New a = new frmPhieuNhapVatTuHangHoa_New(_pnx);
            a.ShowDialog();        
        }

        List<ChiTietXuatKhoFromOtherDB> _chitietxuatkhoaListSelectedXuatCapPhat = new List<ChiTietXuatKhoFromOtherDB>();
        private void lookUpEdit_NhanVien_EditValueChanged(object sender, EventArgs e)
        {

            if (!_checkXemLaiPhieuXuat)
            {
                if (_loaiPhieu == 27 || _loaiPhieu == 28)
                {
                    DoiTac getNamHoc = (DoiTac)lookUpEdit_NhanVien.Properties.GetRowByKeyValue(lookUpEdit_NhanVien.EditValue);
                    if (PhieuDeNghiXuatDongPhuc.KiemTraXuatCapPhat(Convert.ToInt32(lookUpEdit_NhanVien.EditValue), getNamHoc.NamHoc, _loaiPhieu).MaDoiTac == 0)
                    {
                        _phieuDeNghiXuatDongPhuc = PhieuDeNghiXuatDongPhuc.NewPhieuDeNghiXuatDongPhuc();
                        _phieuDeNghiXuatDongPhuc.DienGiai = "Xuất Cấp Phát Đồng Phục";
                        _phieuDeNghiXuatDongPhuc.Loai = _loaiPhieu;
                        _phieuDeNghiXuatDongPhuc.SoPhieu = PublicClass.SetSoChungTuByMaLoaiChungTu(_phieuDeNghiXuatDongPhuc.Loai, _phieuDeNghiXuatDongPhuc.NgayNX);
                        _phieuDeNghiXuatDongPhuc.MaDoiTac = Convert.ToInt64(lookUpEdit_NhanVien.EditValue.ToString());
                        _phieuDeNghiXuatDongPhuc.NamHoc = getNamHoc.NamHoc;
                        _phieuDeNghiXuatDongPhuc.HoTen = getNamHoc.TenDoiTac;
                        _phieuDeNghiXuatDongPhuc.Ten = getNamHoc.Ten;
                        string dtac = DoiTac.GetDoiTac(Convert.ToInt32(lookUpEdit_NhanVien.EditValue)).MaQLDoiTac;
                        NhomHangHoaBQ_VT nhomHangHoaIns = NhomHangHoaBQ_VT.NewNhomHangHoaBQ_VT();
                        _chitietxuatkhoaListSelectedXuatCapPhat = ChiTietXuatKhoFromOtherDB.GetChiTietXuatCapPhatDongPhucFromOtherDBList(dtac, "CP");
                        _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList.Clear();
                        foreach (ChiTietXuatKhoFromOtherDB ctCapPhat in _chitietxuatkhoaListSelectedXuatCapPhat)
                        {
                            CT_PhieuDeNghiXuatDongPhuc ctpxAdd = CT_PhieuDeNghiXuatDongPhuc.NewCT_PhieuDeNghiXuatDongPhuc();
                            nhomHangHoaIns = NhomHangHoaBQ_VT.GetNhomHangHoaBQ_VT(ctCapPhat.TenMonHoc);
                            if (nhomHangHoaIns != null && nhomHangHoaIns.MaNhomHangHoa != 0)
                            {
                                //hanghoaListByMaNhom = HangHoaBQ_VTList.GetHangHoaBQ_VTListByMaNhom(nhomHangHoaIns.MaNhomHangHoa);
                                ctpxAdd.MaNhomHangHoa = nhomHangHoaIns.MaNhomHangHoa;
                                //ctpxAdd.MaHangHoa = hanghoaListByMaNhom[0].MaHangHoa;
                            }
                            ctpxAdd.SoLuong = ctCapPhat.SoLuong;
                            ctpxAdd.DienGiai = ctCapPhat.TenMonHoc;
                            _phieuDeNghiXuatDongPhuc.Lop = ctCapPhat.TenLop;
                            _phieuDeNghiXuatDongPhuc.GioiTinh = ctCapPhat.GioiTinh;
                            _phieuDeNghiXuatDongPhuc.Loai = _loaiPhieu;
                            _phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList.Add(ctpxAdd);                           
                        }
                    }
                    else
                    {
                        MessageBox.Show("Học sinh này đã được cấp phát", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //_phieuDeNghiXuatDongPhuc.CT_PhieuDeNghiXuatDongPhucList.Clear();
                        GanBindingSource();
                    }
                }
            }
            GanBindingSource();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnTim.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
        }
        private PhieuDeNghiXuatDongPhucList _phieuDeNghiXuatDongPhucList;
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (checkEdit_Ngay.Checked == true)
            {
                _phieuDeNghiXuatDongPhucList = PhieuDeNghiXuatDongPhucList.GetPhieuXuatDongPhucList_Tim("SearchByDate", Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, false, this._loaiPhieu, UserId);
            }
            else
            {
                _phieuDeNghiXuatDongPhucList = PhieuDeNghiXuatDongPhucList.GetPhieuXuatDongPhucList_Tim("SearchAll", Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, false, this._loaiPhieu, UserId);
            }

            if (_phieuDeNghiXuatDongPhucList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
            TimPhieuDeNghiXuatBindingSource.DataSource = _phieuDeNghiXuatDongPhucList;
        }
        private void grd_DanhSachPhieuXuat_DoubleClick(object sender, EventArgs e)
        {
            _checkXemLaiPhieuXuat = true;
            xtraTabControl1.SelectedTabPageIndex = 0;
            //_phieuDeNghiXuatDongPhuc = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuDeNghiXuatDongPhuc;
            _phieuDeNghiXuatDongPhuc = PhieuDeNghiXuatDongPhuc.NewPhieuDeNghiXuatDongPhuc();
            //phieuDeNghiXuatBindingSource.Clear();
            _phieuDeNghiXuatDongPhuc = PhieuDeNghiXuatDongPhuc.GetPhieuDeNghiXuatDongPhuc(((PhieuDeNghiXuatDongPhuc)TimPhieuDeNghiXuatBindingSource.Current).MaDeNghiXuat);
            DoiTac dtac = DoiTac.GetDoiTacXuatDongPhuc(_maTruong,_phieuDeNghiXuatDongPhuc.MaDoiTac);
            _doiTacList.Add(dtac);
            GanBindingSource();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                grd_DanhSachPhieuXuat.ExportToXls(dlg.FileName);
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(dlg.FileName);
            }
        }

        private void btnExcelHocSinh_Click(object sender, EventArgs e)
        {
            BindingSource db = new BindingSource();
            DoiTacList dtl = DoiTacList.NewDoiTacList();
            if (_loaiPhieu == 27)
            {
                dtl = DoiTacList.GetHocSinhFormBienLai("8");
            }
            else
            {
                dtl = DoiTacList.GetHocSinhFormBienLai("10");
            }
            db.DataSource = dtl;
            XuatExcelHocSinh.DataSource = db;
            HamDungChung.InitGridViewDev(gridView10, false, true, GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView10, new string[] { "MaQLDoiTac", "TenDoiTac", "NgaySinh", "GioiTinh", "TenKhoi", "TenLop", "TenTruong" },
                                new string[] { "MaHocSinh", "Ten", "BirthDay", "GenderName", "TenKhoi", "TenLop", "TenTruong" },
                                             new int[] { 100, 130, 80, 80, 70, 70, 130 });
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                XuatExcelHocSinh.ExportToXls(dlg.FileName);
                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start(dlg.FileName);
            }
        }

        private void btnCapNhatHocSinh_Click(object sender, EventArgs e)
        {
            if (_loaiPhieu == 27 || _loaiPhieu == 28)
            {
                if (_loaiPhieu == 27)
                {
                    _doiTacList = DoiTacList.GetHocSinhFormBienLai("8");
                    DoiTac _doiTac = DoiTac.NewDoiTac(0, "<<None>>");
                    _doiTacList.Insert(0, _doiTac);
                    doiTacListBindingSource.DataSource = _doiTacList;
                }
                else
                {
                    _doiTacList = DoiTacList.GetHocSinhFormBienLai("10");
                    DoiTac _doiTac = DoiTac.NewDoiTac(0, "<<None>>");
                    _doiTacList.Insert(0, _doiTac);
                    doiTacListBindingSource.DataSource = _doiTacList;
                }
            }
            else
            {
                _doiTacList = DoiTacList.GetDoiTacHocSinhList();
                DoiTac _doiTac = DoiTac.NewDoiTac(0, "<<None>>");
                _doiTacList.Insert(0, _doiTac);
                doiTacListBindingSource.DataSource = _doiTacList;
                lookUpEdit_NhanVien.Properties.View.Columns["NgaySinh"].Visible = false;
                lookUpEdit_NhanVien.Properties.View.Columns["GioiTinh"].Visible = false;
                lookUpEdit_NhanVien.Properties.View.Columns["TenLop"].Visible = false;
                lookUpEdit_NhanVien.Properties.View.Columns["TenKhoi"].Visible = false;
                lookUpEdit_NhanVien.Properties.View.Columns["TenTruong"].Visible = false;
                lookUpEdit_NhanVien.Properties.PopupFormSize = new Size(300, 0);
            }
        }

        private void dateEdit_NgayLap_EditValueChanged(object sender, EventArgs e)
        {
            if (_phieuDeNghiXuatDongPhuc.IsNew == true)
            {
                _phieuDeNghiXuatDongPhuc.NgayNX = dateEdit_NgayLap.DateTime.Date;
                _phieuDeNghiXuatDongPhuc.SoPhieu = PublicClass.SetSoChungTuByMaLoaiChungTu(this._loaiPhieu, dateEdit_NgayLap.DateTime.Date);
            }
        }

        //END Spd_PhieuXuatVatTu

        #endregion//Cac Phuong Thuc Report
    }
}
