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
//07_10_2014
namespace PSC_ERP
{
    public partial class frmPhieuNhapBanQuyenBQ : DevExpress.XtraEditors.XtraForm
    {

        #region properties
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
        #region BS KhoaSoTK
        private bool _isCellValuechangeBT = true;
        private bool _coTKBiKhoa = false;
        #endregion//BS KhoaSoTK
        #endregion //properties//

        #region Function
        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _chungTu_HoaDonList = ChungTu_HoaDonBQList.NewChungTu_HoaDonList();
            _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat();
            _phieuNhapXuat.Loai = 1;
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
            _coTKBiKhoa = CheckCoTaiKhoanBiKhoaTrongButToan();
            int flag = 0;
            //End Add to 11012013
            foreach (ButToanPhieuNhapXuatBQ _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.CoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (taiKhoan.SoHieuTK.StartsWith("3113") || taiKhoan.SoHieuTK.StartsWith("3337") || taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))
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
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            bs_ChuongTrinhConBanQuyenList.DataSource = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList();

            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();

            DoiTacList doitaclist_P = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac_P = DoiTac.NewDoiTac(0, "Không Chọn");
            doitaclist_P.Insert(0, _DoiTac_P);
            doiTacListBindingSource1.DataSource = doitaclist_P; //DoiTacList.GetDoiTacListByTen(0);

            _boPhanList = BoPhanList.GetBoPhanListBy_All();
            boPhanListBindingSource.DataSource = _boPhanList;
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(1);
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

        #region KhoaSoTaiKhoan

       

        private bool CheckCoTaiKhoanBiKhoaTrongButToan()
        {
            foreach (ButToanPhieuNhapXuatBQ buttoan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
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
                _phieuNhapXuat.NgayNX = _ngayLapCu;
                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                return false;
            }
            return true;
        }

        private bool KhoaButToanTheoTaiKhoan(int mataiKhoan)
        {

            bool khoataiKhoan = false;
            KhoaSo_MaTaiKhoanRootList khoa = KhoaSo_MaTaiKhoanRootList.GetKhoaSo_MaTaiKhoanRootList(UserId, mataiKhoan, _phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoataiKhoan = true;
                }
            }

            if (khoataiKhoan == false && _phieuNhapXuat.IsNew == false)
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

        private bool KiemTraDonGiaCTHopLe()
        {
            bool kq = true;
            foreach (CT_PhieuNhapBQ ct_phieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
            {
                if (KiemTraDonGiaCtNhaplaLe(ct_phieuNhap.SoLuong, ct_phieuNhap.ThanhTien))
                {
                    ct_phieuNhap.ThanhTien = 0;
                    kq = false;
                }
            }
            if (kq == false)
            {
                MessageBox.Show("Đơn giá có phần lẻ, không hợp lệ, thành tiền sẻ trở về 0");
            }
            return kq;

        }

        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuNhapBQ ct_phieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
            {
                if (ct_phieuNhap.MaChuongTrinh == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập Tên Chương trình con cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (ct_phieuNhap.SoLuong == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập số lượng cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            if (kq == true)
                kq = KiemTraDonGiaCTHopLe();
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
                if (butToan.NoTaiKhoan == 0 || butToan.NoTaiKhoan == null || butToan.CoTaiKhoan == 0 || butToan.CoTaiKhoan == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Nợ Có của Định Khoản", "Yêu Cầu");
                    return false;
                }
                if (butToan.SoTien == 0)
                {
                    MessageBox.Show("Vui lòng nhập Số tiền của Định Khoản", "Yêu Cầu");
                    return false;
                }

                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                string noTK = taiKhoanNo.SoHieuTK;
                string CoTK = taiKhoanCo.SoHieuTK;
                #region Kiểm tra  hóa đơn
                if (taiKhoanCo.SoHieuTK.StartsWith("3113") || taiKhoanCo.SoHieuTK.StartsWith("3337") || taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))
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
            //grdViewCt_PhieuNhap.Columns["MaChuongTrinhCha"].OptionsColumn.AllowEdit = false;
            //grdViewCt_PhieuNhap.Columns["MaChuongTrinh"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuNhap.Columns["MaNguon"].OptionsColumn.AllowEdit = false;
            _lockHopDong = true;
            gridLookUpEdit_KhoNhan.Properties.ReadOnly = true;
            lookUpEdit_PPNXKho.Properties.ReadOnly = true;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }

        private void UnLockData()
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

        private void AllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        private void NotAllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private void CheckPhieuNhap()
        {
            if (_phieuNhapXuat != null)
                if (PhieuNhapXuatBQ.KiemTraPhieuNhapDaXuatThang(_phieuNhapXuat.MaPhieuNhapXuat))
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


        private void FormatFormTheoKhoaSoThue()
        {
            //if (KhoaSoThue())
            //{
            //    btn_HoaDon.Enabled = false;
            //    if (_phieuNhapXuat.IsNew)
            //    {
            //        _phieuNhapXuat.HoaDon_NhapXuatList.Clear();
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
            //grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.ReadOnly = true;
            //grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowFocus = false;
            //grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowIncrementalSearch = false;
            //grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowMove = false;

            grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.ReadOnly = true;

            grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.ReadOnly = true;

            //grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = false;
            ////grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.ReadOnly = true;

            //grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = false;//
            ////grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.ReadOnly = true;

            grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;
            //grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.ReadOnly = true;

        }//Them

        private void UnLockgrdView_DinhKhoan()
        {

            grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = true;
            //grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = true;//
            grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = true;
        }//Them

        
        private bool CheckCoTaiKhoanThueTrongButToan()
        {
            foreach (ButToanPhieuNhapXuatBQ butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);

                if (taiKhoan.SoHieuTK.StartsWith("3113") || taiKhoan.SoHieuTK.StartsWith("3337") || taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))
                {
                    return true;
                }
            }
            return false;
        }//Them

        private bool CheckValidKhoaSoThueWhenChangeNgayNX()//Them
        {
            if (_phieuNhapXuat.IsNew == false)
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
                    foreach (ButToanPhieuNhapXuatBQ butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                    {
                        HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                        HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);

                        if (taiKhoan.SoHieuTK.StartsWith("3113") || taiKhoan.SoHieuTK.StartsWith("3337") || taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))
                        {
                            MessageBox.Show("Ngày lập phiếu đã Khóa sổ Thuế, không thể thay đổi", "Thông Báo");
                            _phieuNhapXuat.NgayNX = _ngayLapCu;
                            dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                            return false;
                        }
                    }
                }
                else
                {
                    //duyet  theo ngay nhap xuat
                    KhoaSo_UserList khoa_NgayNX = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
                    if (khoa_NgayNX.Count > 0)
                    {
                        if (khoa_NgayNX[0].KhoaSoThue == true)
                        {
                            khoasotheoNgayNX = true;
                        }
                    }

                    if (khoasotheoNgayNX)
                    {
                        foreach (ButToanPhieuNhapXuatBQ butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                        {
                            HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                            HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);

                            if (taiKhoan.SoHieuTK.StartsWith("3113") || taiKhoan.SoHieuTK.StartsWith("3337") || taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337"))
                            {
                                MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa sổ Thuế, không thể thực hiện", "Thông Báo");
                                _phieuNhapXuat.NgayNX = _ngayLapCu;
                                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                                return false;
                            }
                        }
                    }

                }
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

        private bool KhoaSoThue()
        {
            bool khoasothue = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSoThue == true)
                {
                    khoasothue = true;
                }
            }
            //
            if (khoasothue == false && _phieuNhapXuat.IsNew == false)
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

        private bool KiemTraDonGiaCtNhaplaLe(decimal soLuong, decimal thanhTien)
        {
            if ((thanhTien % soLuong) != 0)
            {
                return true;
            }
            return false;
        }

        private void CheckCTPhieuNhaptoTwoRow(decimal soLuong, decimal thanhTien)
        {
            if (KiemTraDonGiaCtNhaplaLe(soLuong, thanhTien))
            {
                CT_PhieuNhapBQ _ct_PhieuNhap = (CT_PhieuNhapBQ)cTPhieuNhapListBindingSource.Current;
                //if (MessageBox.Show(this, "Đơn giá có phần lẻ, Bạn có muốn tách thành 2 dòng?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                //{
                    decimal dongia = 0;
                    decimal sl1 = 0;
                    decimal tt1 = 0;
                    decimal sl2 = 0;
                    decimal tt2 = 0;
                    //decimal dg2 = 0;
                    dongia = Math.Floor((thanhTien / soLuong));
                    sl1 = soLuong - 1;
                    tt1 = sl1 * dongia;
                    sl2 = 1;
                    tt2 = dongia + (thanhTien % soLuong);
                    //dg2 = dongia + (thanhTien % soLuong);
                    //-->
                    _ct_PhieuNhap.SoLuong = sl1;
                    _ct_PhieuNhap.ThanhTien = tt1;
                    _ct_PhieuNhap.DonGia = dongia;
                    CT_PhieuNhapBQ ctn2 = new CT_PhieuNhapBQ(_ct_PhieuNhap, sl2, tt2);
                    cTPhieuNhapListBindingSource.Add(ctn2 as object);
                //}
                //else
                //{
                //    MessageBox.Show("Dữ liệu nhập vào không hợp lệ, Thành tiền sẽ trở về là 0!", "Thông Báo");
                //    _ct_PhieuNhap.ThanhTien = 0;
                //}
            }
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
            if (!DaKetChuyen())
            {
                //XuLy Luu Phieu
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
                                    _ngayLapCu = _phieuNhapXuat.NgayNX;
                                    _maKhoCu = _phieuNhapXuat.MaKho;
                                    _maBoPhanCu = _phieuNhapXuat.MaPhongBan;
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
                //XuLy lu phieu
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
                decimal soluong = 0;
                decimal thanhtien = 0;
                if (decimal.TryParse(_ct_PhieuNhap.SoLuong.ToString(), out soluong))
                {
                    if (decimal.TryParse(_ct_PhieuNhap.ThanhTien.ToString(), out thanhtien))
                    {
                        CheckCTPhieuNhaptoTwoRow(soluong, thanhtien);
                    }
                }
                //if (_ct_PhieuNhap.SoLuong != 0)//Thay doi Don Gia
                //{
                //    _ct_PhieuNhap.DonGia = Math.Round(_ct_PhieuNhap.ThanhTien / _ct_PhieuNhap.SoLuong, 0, MidpointRounding.AwayFromZero);
                //}
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

                            if ((taiKhoan.SoHieuTK.StartsWith("3113") || taiKhoan.SoHieuTK.StartsWith("3337") || taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337")) && !(KhoaSoThue()))
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
                            if ((taiKhoan.SoHieuTK.StartsWith("3113") || taiKhoan.SoHieuTK.StartsWith("3337") || taiKhoanNo.SoHieuTK.StartsWith("3113") || taiKhoanNo.SoHieuTK.StartsWith("3337")) && !(KhoaSoThue()))
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
                frmDSPhieuNhapXuatBanQuyenBQ frm = new frmDSPhieuNhapXuatBanQuyenBQ(1, true);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat(frm.PhieuNhapXuat, dateEdit_NgayLap.DateTime);
                    //
                    _phieuNhapXuat.Loai = 1;
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
            _coTKBiKhoa = false;
            UnLockData();
            AllowDelete();
            KhoiTaoPhieu();
            btnSaoChepChungTu.Enabled = true;//M
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
                    FrmPhieuXuatBanQuyenBQ frm = new FrmPhieuXuatBanQuyenBQ(phieuNhapXuat, 1, true);
                    //frm.ShowDialog();//(1)
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        CheckPhieuNhap();
                    }//replace (1)
                }
                else
                {
                    FrmPhieuXuatBanQuyenBQ frm = new FrmPhieuXuatBanQuyenBQ(_phieuNhapXuat, 2, true);
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
                frm.ShowDialog();
            }
            //END
        }

        //Sua
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
            {
                bool chophepxoa = true;
                int[] deleteRows = grdView_DinhKhoan.GetSelectedRows();
                foreach (int deleteRow in deleteRows)
                {
                    ButToanPhieuNhapXuatBQ buttoan = (ButToanPhieuNhapXuatBQ)grdView_DinhKhoan.GetRow(deleteRow);
                    HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                    HeThongTaiKhoan1 tk1 = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.CoTaiKhoan);
                    if (tk.SoHieuTK.StartsWith("3113") || tk.SoHieuTK.StartsWith("3337") || tk1.SoHieuTK.StartsWith("3113") || tk1.SoHieuTK.StartsWith("3337"))
                    {
                        if (KhoaSoThue())
                        {
                            chophepxoa = false;
                            break;
                        }
                    }

                }
                if (chophepxoa)
                    grdView_DinhKhoan.DeleteSelectedRows();
                else
                {
                    MessageBox.Show("Đã Khóa sổ Thuế, không thể Xóa Định khoản Thuế!");

                }
            }
        }

        private void btn_HopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.NhapXuat_HopDongList.Count == 0)
            {
                int maPhanLoaiHD = PhanLoaiHopDong.GetPhanLoaiHopDongByMaQL("BQ").MaPhanLoaiHD;
                frmChonHopDongLapPhieuBQ frm = new frmChonHopDongLapPhieuBQ(_phieuNhapXuat.MaDoiTac, _lockHopDong, maPhanLoaiHD);
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

        //Sua
        private void frmPhieuNhapBanQuyen_Load(object sender, EventArgs e)
        {
            formatGriview();
            CheckPhieuNhap();
            FormatFormTheoKhoaSoThue();
            CheckShow_colMaDoiTuongNo_LoadPhieu();
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuNhap, 35);

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

        //Sua
        private void grdView_DinhKhoan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {


            if (grdView_DinhKhoan.FocusedColumn.Name == "colNoTaiKhoan" || grdView_DinhKhoan.FocusedColumn.Name == "colCoTaiKhoan")
            {
                ButToanPhieuNhapXuatBQ butToan = ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current);
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);
                HeThongTaiKhoan1 tk1 = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                if (tk.SoHieuTK.StartsWith("3113") || tk.SoHieuTK.StartsWith("3337") || tk1.SoHieuTK.StartsWith("3113") || tk1.SoHieuTK.StartsWith("3337"))
                {
                    if (KhoaSoThue())
                    {
                        MessageBox.Show("Đã khóa sổ thuế, không cập thể cập nhật thêm tài khoản thuế vào!");
                        if (grdView_DinhKhoan.FocusedColumn.Name == "colNoTaiKhoan")
                            butToan.NoTaiKhoan = 0;
                        else if (grdView_DinhKhoan.FocusedColumn.Name == "colCoTaiKhoan")
                            butToan.CoTaiKhoan = 0;
                    }
                    else
                    {
                        butToan.ChungTu_HoaDonList.Clear();
                        foreach (ChungTu_HoaDonBQ ct_hd in _chungTu_HoaDonList)
                            butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDonBQ.NewChungTu_HoaDon(ct_hd));
                    }

                }
                CheckHideShowDoiTuong_ButToan();
            }
        }

        //Sua
        private void grdView_DinhKhoan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colHoaDon" && !(KhoaSoThue()))
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).CoTaiKhoan);
                HeThongTaiKhoan1 tk1 = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                if (tk.SoHieuTK.StartsWith("3113") || tk.SoHieuTK.StartsWith("3337") || tk1.SoHieuTK.StartsWith("3113") || tk1.SoHieuTK.StartsWith("3337"))
                {
                    bool khoaso = KhoaSo();
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
                    #region Edit bug
                    ChungTu_ChiPhiSanXuatList cpList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
                    foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat in ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList)
                    {
                        cpList.Add(chungTu_ChiPhiSanXuat);
                    }
                    //ChungTu_ChiPhiSanXuatList cpList = ((ButToanPhieuNhapXuatBQ)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList;
                    #endregion//Edit bug
                    
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

        //Sua
        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuatBQ pnx = _phieuNhapXuat;
            if (pnx != null)
            {
                if (_coTKBiKhoa || CheckCoTaiKhoanBiKhoaTrongButToan())
                {
                    MessageBox.Show("Tài khoản đã bị khóa, k thể lưu", "Thông Báo");
                    return;
                }
                if (KhoaSo())//Kiem Tra Khoa so
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(KhoaSoThue())
                {
                    if(CheckCoTaiKhoanThueTrongButToan())
                    {
                        MessageBox.Show(this, "Đã khóa sổ thuế, không thể xóa phiếu, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
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

        //Them
        private void grdView_DinhKhoan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EventRowOrColumnGrdView_DinhKhoanChange();
        }

        //Them
        private void dateEdit_NgayLap_Leave(object sender, EventArgs e)
        {
            if (dateEdit_NgayLap.OldEditValue != dateEdit_NgayLap.EditValue)
            {
                CheckValidKhoaSoThueWhenChangeNgayNX();
                FormatFormTheoKhoaSoThue();
            }
        }
        #endregion //Event

        public frmPhieuNhapBanQuyenBQ()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
            grdViewCt_PhieuNhap.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            grdViewCt_PhieuNhap.FocusedRowHandle = grdViewCt_PhieuNhap.RowCount - 1;
            grdViewCt_PhieuNhap.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
        }

        #region frmPhieuNhapBanQuyenBQ(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuNhapBanQuyenBQ(PhieuNhapXuatBQ phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }
        #endregion

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

        private void grd_DinhKhoan_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == false)
                e.Handled = true;
        }

        private void grd_DinhKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit == false)
                e.Handled = true;
        }

        private void grdCT_PhieuNhap_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (grdViewCt_PhieuNhap.Columns["SoLuong"].OptionsColumn.AllowEdit == false)
                e.Handled = true;
        }

        private void grdCT_PhieuNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdViewCt_PhieuNhap.Columns["SoLuong"].OptionsColumn.AllowEdit == false)
                e.Handled = true;
        }










    }
}