using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;

namespace PSC_ERP
{
    public partial class FrmPhuLucHopDongBanQuyen : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        DoiTacList _DoiTacList;
        DoiTac _DoiTac;
        BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();

        HopDongThuChi _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
        DonViTinhList _DonViTinhList;
        string _maLoaiHDQL = "HDBQ";

        int _maLoaiHopDong;
        private byte _tinhTrang = 1;//xac dinh bat dau van hanh phan he Hop Dong

        private bool _isHDNam2014 = false;
        //private bool _notNewPhuLuc = false;

        //--


        #endregion

        public FrmPhuLucHopDongBanQuyen()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhuLucHopDong();
        }
        public FrmPhuLucHopDongBanQuyen(HopDongThuChi hopDongThuChi, bool tuDS)
        {
            InitializeComponent();
            //_notNewPhuLuc = true;
            KhoiTao();
            KhoiTaoPhuLucHopDong(hopDongThuChi, tuDS);
        }

        public FrmPhuLucHopDongBanQuyen(HopDongThuChi hopDongThuChi, bool tuDS, bool isHDNam2014, string tieuDeForm)
        {
            InitializeComponent();
            this.Text = tieuDeForm;
            _isHDNam2014 = isHDNam2014;
            //_notNewPhuLuc = true;
            KhoiTao();
            KhoiTaoPhuLucHopDongtuHopDong2014(hopDongThuChi, tuDS);
            btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        #region Function

        private void KhoiTao()
        {
            if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
                _maLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;

            HopDongThuChiList_bindingSource.DataSource = HopDongThuChiList.GetHopDongMuaBanByUserID_MaLoaiHopDong(_maLoaiHopDong);

            NguoiDaiDienList_bindingSource.DataSource = TenNhanVienList.GetTenNhanVienList_NguoiDaiDienHopDong();

            loaiTienListBindingSource.DataSource = LoaiTienList.GetLoaiTienList();

            loaiTienListBindingSource1.DataSource = LoaiTienList.GetLoaiTienList();

            _DoiTacList = DoiTacList.GetDoiTacList("", 0);
            doiTacListBindingSource.DataSource = _DoiTacList;


            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;
            BoPhanListbindingSource1.DataSource = _BoPhanList;

            DonViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();

            QuocGiaBQ_VTList _quocGiaList = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            QuocGiaBQ_VT qg = QuocGiaBQ_VT.NewQuocGiaBQ_VT("<<Không chọn>>");
            _quocGiaList.Insert(0, qg);
            bs_QuocGiaList.DataSource = _quocGiaList;
            //
            //
            this.grdChiTietThanhToan.DataSource = this.chiTietThanhToanBindingSource;
            this.grdChiTietThanhToanThucTe.DataSource = this.chiTietThanhToanThucTeListBindingSource;
            //
            DesignGrid_ChiTietHopDong();
            DesignGrid_ChiTietThanhToan();
            DesignGrid_ChiTietThanhToanThucTe();
        }

        private void BindingData()
        {
            HopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
            cTHopDongDichVuBindingSource.DataSource = _HopDongMuaBan.CT_HopDongDichVu;
            chiTietThanhToanBindingSource.DataSource = _HopDongMuaBan.chiTietThanhToan;
            chiTietThanhToanThucTeListBindingSource.DataSource = _HopDongMuaBan.chiTietThanhToanThucTeList;
            ChiTietThuLao_bindingSource.DataSource = _HopDongMuaBan.chiTietThuLaoHopDongList;

            CT_HopDongThuChiList ct_hopdonglist = CT_HopDongThuChiList.GetCT_HopDongDichVuList(_HopDongMuaBan.MaHopDong);
            CT_HopDongThuChi ct_hopdong = CT_HopDongThuChi.NewCT_HopDongDichVu("Không chọn");
            ct_hopdonglist.Insert(0, ct_hopdong);
            cTHopDongDichVuBindingSource1.DataSource = ct_hopdonglist;
        }

        private void KhoiTaoPhuLucHopDong()
        {
            _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
            SetGiaTriMacDinhHopDong();
            BindingData();

        }
        private void KhoiTaoPhuLucHopDong(HopDongThuChi hopDongThuChi, bool tuDS)
        {
            if (tuDS)
            {
                _HopDongMuaBan = hopDongThuChi;

            }
            else
            {
                HopDongThuChi hdtcLast = HopDongThuChi.GetHopDongMuaBanLast(hopDongThuChi.MaHopDong);
                _HopDongMuaBan = HopDongThuChi.NewPhuLucHopDongMuaBan(hdtcLast);
                if (_HopDongMuaBan.CT_HopDongDichVu.Count > 0)
                    if (LuuDuLieu() == false)
                    {
                        MessageBox.Show("Thực hiện thất bại!");
                        this.Close();
                    }

            }
            BindingData();

        }

        private void KhoiTaoPhuLucHopDongtuHopDong2014(HopDongThuChi hopDongThuChi, bool tuDS)
        {
            HopDongThuChiList hopDongList = HopDongThuChiList.NewHopDongMuaBanList();
            if (hopDongThuChi.LaPhuLuc)
            {
                HopDongThuChi hdinsert = HopDongThuChi.GetHopDongMuaBanWithoutChild(hopDongThuChi.MaHopDongChinh);
                hopDongList.Add(hdinsert);
            }
            else
            {
                hopDongList.Add(hopDongThuChi);
            }
            HopDongThuChiList_bindingSource.DataSource = hopDongList;
            if (tuDS)
            {
                _HopDongMuaBan = hopDongThuChi;

            }
            else
            {
                HopDongThuChi hdtcLast = HopDongThuChi.GetHopDongMuaBanLastfromHopDong2014(hopDongThuChi.MaHopDong);
                _HopDongMuaBan = HopDongThuChi.NewPhuLucHopDongMuaBan(hdtcLast);
                if (_HopDongMuaBan.CT_HopDongDichVu.Count > 0)
                    if (LuuDuLieu() == false)
                    {
                        MessageBox.Show("Thực hiện thất bại!");
                        this.Close();
                    }

            }
            BindingData();

        }
        private void SetGiaTriMacDinhHopDong()
        {
            //_HopDongMuaBan.LaPhuLuc = true;
        }

        private bool SetSoPhuLucHopDong()
        {
            if ((!_HopDongMuaBan.HDTrongNgoaiDai) && _HopDongMuaBan.TinhTrang == 1)//Là HĐ trong đài
            {
                if (_HopDongMuaBan.IsNew)
                {
                    _HopDongMuaBan.SoHopDong = HopDongThuChi.SetSoPhuLucHopDong(_HopDongMuaBan.MaHopDongChinh);
                    txt_SoHopDong.Text = _HopDongMuaBan.SoHopDong;

                }
            }
            else if (_isHDNam2014 && (!_HopDongMuaBan.HDTrongNgoaiDai))
            {
                if (_HopDongMuaBan.IsNew)
                {
                    _HopDongMuaBan.SoHopDong = HopDongThuChi.SetSoPhuLucHopDong(_HopDongMuaBan.MaHopDongChinh);
                    txt_SoHopDong.Text = _HopDongMuaBan.SoHopDong;

                }
            }
            //else if (_HopDongMuaBan.HDTrongNgoaiDai)
            //{
            //    if (txt_SoHopDong.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Đây là Phụ lục Hợp đồng ngoài đài, Vui lòng nhập Số Phụ lục hợp đồng");
            //        txt_SoHopDong.Focus();
            //        return false;
            //    }
            //}

            return true;
        }



        private string SetGhiChu()
        {

            if (!_HopDongMuaBan.HDTrongNgoaiDai)
            {
                return " - Đang nhập Hợp đồng trong đài...";
            }
            else
            {
                return " - Đang nhập Hợp đồng ngoài đài...";
            }

        }

        private bool KiemTraSoPhuLucHopDongHopLe()
        {
            string sohopdongChinh = HopDongThuChi.GetSoHopDongForSoPhuLuc(_HopDongMuaBan.MaHopDongChinh);
            string sohopdong = txt_SoHopDong.Text.Trim();
            //if (sohopdong.Length == 0)
            //{
            //    MessageBox.Show("Vui lòng nhập vào Số phụ lục hợp đồng!");
            //    txt_SoHopDong.Focus();
            //    return false;
            //}
            if (!_HopDongMuaBan.HDTrongNgoaiDai)//Là HĐ trong đài
            {
                //
                if (sohopdongChinh.Length > 0)
                {
                    int size = sohopdongChinh.Length;
                    if (sohopdong.Substring(0, size) != sohopdongChinh)
                    {
                        MessageBox.Show(size + " ký tự đầu không trùng khớp với số hợp đồng!");
                        txt_SoHopDong.Focus();
                        return false;
                    }
                    int soTTHD;
                    if (!int.TryParse(sohopdong.Substring(size + 1, 1), out soTTHD))
                    {
                        MessageBox.Show("Số phụ lục hợp đồng không hợp lệ! ký tự thứ " + (size + 2) + " phải là số!");
                        txt_SoHopDong.Focus();
                        return false;
                    }
                }
                //
            }
            if (sohopdong.Length > 0)
            {
                if (HopDongThuChi.KiemTraTrungSoHopDong(_HopDongMuaBan.MaHopDong, sohopdong))
                {
                    MessageBox.Show("Trùng số phụ lục hợp đồng! Vui lòng chỉnh lại!");
                    txt_SoHopDong.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool KiemTraChiTietThanhToan()
        {
            foreach (ChiTietThanhToanHopDongThuChi ctthanhtoan in _HopDongMuaBan.chiTietThanhToan)
            {
                if (ctthanhtoan.PhuongThucThanhToan.Length == 0)
                {
                    MessageBox.Show("Nhập vào phương thức thanh toán");
                    return false;
                }
                else if (ctthanhtoan.PhanTramThanhToan == 0)
                {
                    MessageBox.Show("Nhập vào % thanh toán");
                    return false;
                }
                else if (ctthanhtoan.SoTien == 0)
                {
                    MessageBox.Show("Nhập vào Số tiền thanh toán");
                    return false;
                }

            }
            return true;
        }
        private bool KiemTraChiTietThanhToanThucTe()
        {
            foreach (ChiTietThanhToanThucTe ctthanhtoan in _HopDongMuaBan.chiTietThanhToanThucTeList)
            {
                if (ctthanhtoan.NgayThanhToan == null)
                {
                    MessageBox.Show("Nhập vào Ngày thanh toán");
                    return false;
                }
                else if (ctthanhtoan.PhanTramThanhToan == 0)
                {
                    MessageBox.Show("Nhập vào % thanh toán");
                    return false;
                }
                else if (ctthanhtoan.SoTien == 0)
                {
                    MessageBox.Show("Nhập vào Số tiền thanh toán");
                    return false;
                }

            }
            return true;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = true;

            if (_HopDongMuaBan.MaHopDongChinh == 0)
            {
                MessageBox.Show(this, "vui lòng chọn Hợp đồng của Phụ lục!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            if (_HopDongMuaBan.SoHopDong == "")
            {
                MessageBox.Show(this, "Số Phụ lục không thể rỗng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_SoHopDong.Focus();
                return false;
            }
            if (txt_TenHopDong.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập vào nội dung Phụ lục Hợp đồng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TenHopDong.Focus();
                return false;
            }
            else if (_HopDongMuaBan.TongTien == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập vào tổng tiền", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TongTien.Focus();
                return false;
            }
            else if (_HopDongMuaBan.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Khách Hàng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                grdLU_KhachHang.Focus();
                return false;
            }
            //else if (_HopDongMuaBan.chiTietThanhToan.Count == 0)
            //{
            //    MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Thanh Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    return false;
            //}
            return kq;

        }

        private bool KiemTraRangBuocTruocKhiLuu()
        {
            if (!_HopDongMuaBan.IsNew)
            {
                if (HopDongThuChi.KiemTraPhuLucDaPhatSinhPhuLucMoi(_HopDongMuaBan.MaHopDong, _HopDongMuaBan.MaHopDongChinh))
                {
                    MessageBox.Show(this, "Phụ lục đã phát sinh Phụ lục mới, Không thể lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //if (HopDongThuChi.KiemTraHopDongDaPhatSinhNghiemThuThanhly(_HopDongMuaBan.MaHopDongChinh))
                //{
                //    MessageBox.Show(this, "Hợp đồng đã Nghiệm thu thanh lý, Không thể lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
            }
            return true;
        }

        private bool KiemTraRangBuocTruocKhiXoa()
        {
            if (HopDongThuChi.KiemTraPhuLucDaPhatSinhPhuLucMoi(_HopDongMuaBan.MaHopDong, _HopDongMuaBan.MaHopDongChinh))
            {
                MessageBox.Show(this, "Phụ lục đã phát sinh Phụ lục mới, Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (HopDongThuChi.KiemTraHopDongDaPhatSinhNghiemThuThanhly(_HopDongMuaBan.MaHopDongChinh))
            {
                MessageBox.Show(this, "Hợp đồng đã Nghiệm thu thanh lý, Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (HopDongThuChi.KiemTraHopDongDaPhatSinhNhapXuat(_HopDongMuaBan.MaHopDong))
            {
                MessageBox.Show(this, "Phụ lục đã phát sinh Nhập Xuất, Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (SetSoPhuLucHopDong())
                {
                    if (KiemTraSoPhuLucHopDongHopLe())
                    {
                        _HopDongMuaBan.ApplyEdit();
                        HopDongMuaBanBindingSource.EndEdit();
                        _HopDongMuaBan.Save();
                    }
                    else
                    {
                        kq = false;
                    }
                }
                else
                {
                    kq = false;
                }
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }

        private void DesignGrid_ChiTietHopDong()
        {
            HamDungChung.InitGridViewDev(grdVChiTietHopDong, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdVChiTietHopDong, new string[] { "HangHoa", "NuocSX", "SoLuong", "DonGia", "ThanhTien", "SoPhut", "ThoiLuong", "SoThangTrongHan", "NgayApDung", "NgayHetHanPS", "SoLanPhatSong", "KenhPS", "GioPS", "NgayPS" },
                                new string[] { "Tên chương trình", "Nước SX", "Số tập", "Đơn giá", "Thành tiền", "Số phút", "Thời lượng", "BQ(tháng)", "Ngày áp dụng(BQ)", "Ngày hết hạn(BQ)", "Số lần PS", "Kênh PS", "Giờ phát sóng", "Ngày PS" },
                                             new int[] { 120, 90, 60, 110, 120, 75, 75, 75, 100, 100, 75, 75, 75, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVChiTietHopDong, new string[] { "HangHoa", "NuocSX", "SoLuong", "DonGia", "ThanhTien", "SoPhut", "ThoiLuong", "SoThangTrongHan", "NgayApDung", "NgayHetHanPS", "SoLanPhatSong", "KenhPS", "GioPS", "NgayPS" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietHopDong, new string[] { "SoLuong", "SoPhut", "ThoiLuong" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietHopDong, new string[] { "DonGia", "ThanhTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev(grdVChiTietHopDong, new string[] { "SoLuong" });
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdVChiTietHopDong, new string[] { "ThanhTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdVChiTietHopDong);

            Utils.GridUtils.SetSTTForGridView(grdVChiTietHopDong, 30);//M
            //
            RepositoryItemDateEdit Ngay_DE = new RepositoryItemDateEdit();
            Ngay_DE.DisplayFormat.FormatString = "dd/MM/yyyy";
            Ngay_DE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Ngay_DE.Mask.EditMask = "dd/MM/yyyy";
            Ngay_DE.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            //
            //
            RepositoryItemGridLookUpEdit NuocSX_GrdLU = new RepositoryItemGridLookUpEdit();
            NuocSX_GrdLU.DataSource = bs_QuocGiaList;
            NuocSX_GrdLU.DisplayMember = "TenQuocGia";
            NuocSX_GrdLU.ValueMember = "MaQuocGia";
            HamDungChung.InitRepositoryItemGridLookUpDev(NuocSX_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(NuocSX_GrdLU, new string[] { "TenVietTat", "TenQuocGia" }, new string[] { "Tên viết tắt", "Tên quốc gia " }, new int[] { 100, 150 }, true);
            //
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietHopDong, "NgayApDung", Ngay_DE);
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietHopDong, "NgayPS", Ngay_DE);
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietHopDong, "NgayHetHanPS", Ngay_DE);
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietHopDong, "NuocSX", NuocSX_GrdLU);

            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietHopDong, new string[] { "SoLuong", "SoPhut", "ThoiLuong" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietHopDong, new string[] { "DonGia", "ThanhTien" }, "#,###.#");

        }

        private void DesignGrid_ChiTietThanhToan()
        {

            HamDungChung.InitGridViewDev(grdVChiTietThanhToan, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdVChiTietThanhToan, new string[] { "PhuongThucThanhToan", "PhanTramThanhToan", "MaLoaiTien", "TiGiaQuyDoi", "ThueNhaThau", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "MaChiTietHopDong", "GhiChu" },
                                new string[] { "Phương Thức TT", "% thanh toán", "Loại tiền", "Tỉ giá", "Thuế nhà thầu", "Tiền có thuế", "Thuế suất(%)", "Tiền thuế", "Tiền chưa thuế", "Tiền phạt", "TT chương trình", "Nội dung TT" },
                                             new int[] { 150, 100, 100, 100, 100, 150, 100, 150, 150, 100, 150, 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVChiTietThanhToan, new string[] { "PhuongThucThanhToan", "PhanTramThanhToan", "MaLoaiTien", "TiGiaQuyDoi", "ThueNhaThau", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "MaChiTietHopDong", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietThanhToan, new string[] { "TiGiaQuyDoi" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToan, new string[] { "PhanTramThanhToan", "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdVChiTietThanhToan, new string[] { "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdVChiTietThanhToan);

            Utils.GridUtils.SetSTTForGridView(grdVChiTietThanhToan, 35);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource1;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien", "TiGiaQuyDoi" }, new string[] { "Mã", "Loại tiền", "Tỉ giá quy đổi" }, new int[] { 100, 150, 150 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThanhToan, "MaLoaiTien", LoaiTien_GrdLU);
            //
            //
            RepositoryItemGridLookUpEdit Ct_HopDong_GrdLU = new RepositoryItemGridLookUpEdit();
            Ct_HopDong_GrdLU.DataSource = cTHopDongDichVuBindingSource1;
            Ct_HopDong_GrdLU.DisplayMember = "HangHoa";
            Ct_HopDong_GrdLU.ValueMember = "MaThamChieu";
            HamDungChung.InitRepositoryItemGridLookUpDev(Ct_HopDong_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(Ct_HopDong_GrdLU, new string[] { "HangHoa" }, new string[] { "Chương trình" }, new int[] { 150 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThanhToan, "MaChiTietHopDong", Ct_HopDong_GrdLU);

            Ct_HopDong_GrdLU.Popup += new System.EventHandler(this.GridLookUpEdit_MaChiTietHopDong_Popup);
            //

            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietThanhToan, new string[] { "TiGiaQuyDoi" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToan, new string[] { "PhanTramThanhToan", "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "#,###.#");

            //
            this.grdVChiTietThanhToan.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdVChiTietThanhToan_InitNewRow);
            this.grdVChiTietThanhToan.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdVChiTietThanhToan_CellValueChanged);
            this.grdVChiTietThanhToan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdVChiTietThanhToan_KeyDown);

            //


        }

        private void DesignGrid_ChiTietThanhToanThucTe()
        {
            HamDungChung.InitGridViewDev(grdVChiTietThanhToanThucTe, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "NgayThanhToan", "PhanTramThanhToan", "MaLoaiTien", "TiGiaQuyDoi", "ThueNhaThau", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "MaChiTietHopDong", "GhiChu" },
                                new string[] { "Ngày TT", "% thanh toán", "Loại tiền", "Tỉ giá", "Thuế nhà thầu", "Tiền có thuế", "Thuế suất(%)", "Tiền thuế", "Tiền chưa thuế", "Tiền phạt", "TT chương trình", "Nội dung TT" },
                                             new int[] { 120, 100, 100, 100, 100, 150, 100, 150, 150, 100, 150, 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "NgayThanhToan", "PhanTramThanhToan", "MaLoaiTien", "TiGiaQuyDoi", "ThueNhaThau", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "MaChiTietHopDong", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "TiGiaQuyDoi" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToanThucTe, new string[] { "PhanTramThanhToan", "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdVChiTietThanhToanThucTe, new string[] { "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdVChiTietThanhToanThucTe);

            Utils.GridUtils.SetSTTForGridView(grdVChiTietThanhToanThucTe, 35);//M
            //
            RepositoryItemDateEdit Ngay_DE = new RepositoryItemDateEdit();
            Ngay_DE.DisplayFormat.FormatString = "dd/MM/yyyy";
            Ngay_DE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Ngay_DE.Mask.EditMask = "dd/MM/yyyy";
            Ngay_DE.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThanhToanThucTe, "NgayThanhToan", Ngay_DE);
            //
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource1;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien", "TiGiaQuyDoi" }, new string[] { "Mã", "Loại tiền", "Tỉ giá quy đổi" }, new int[] { 100, 150, 150 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThanhToanThucTe, "MaLoaiTien", LoaiTien_GrdLU);
            //
            RepositoryItemGridLookUpEdit Ct_HopDong_GrdLU = new RepositoryItemGridLookUpEdit();
            Ct_HopDong_GrdLU.DataSource = cTHopDongDichVuBindingSource1;
            Ct_HopDong_GrdLU.DisplayMember = "HangHoa";
            Ct_HopDong_GrdLU.ValueMember = "MaThamChieu";
            HamDungChung.InitRepositoryItemGridLookUpDev(Ct_HopDong_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(Ct_HopDong_GrdLU, new string[] { "HangHoa" }, new string[] { "Chương trình" }, new int[] { 150 }, true);
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThanhToanThucTe, "MaChiTietHopDong", Ct_HopDong_GrdLU);

            Ct_HopDong_GrdLU.Popup += new System.EventHandler(this.GridLookUpEdit_MaChiTietHopDong_Popup);
            //


            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "TiGiaQuyDoi" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToanThucTe, new string[] { "PhanTramThanhToan", "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "#,###.#");
            //
            this.grdVChiTietThanhToanThucTe.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdVChiTietThanhToanThucTe_InitNewRow);
            this.grdVChiTietThanhToanThucTe.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdVChiTietThanhToanThucTe_CellValueChanged);
            this.grdVChiTietThanhToanThucTe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdVChiTietThanhToanThucTe_KeyDown);
            //

        }




        private void TinhGiaTriHDTheoCT_HopDong()
        {
            CT_HopDongThuChi ct = (CT_HopDongThuChi)cTHopDongDichVuBindingSource.Current;
            Decimal tongTien = 0;
            foreach (CT_HopDongThuChi ct_hd in _HopDongMuaBan.CT_HopDongDichVu)
            {
                //tongTien = tongTien + ct_hd.ThanhTien;
                tongTien = tongTien + ((100 + (decimal)_HopDongMuaBan.ThueSuat) * ct_hd.ThanhTien) / 100;
            }
            _HopDongMuaBan.TongTien = tongTien;//Thay doi Gia Tri Kho
        }

        private void Focus()
        {
            textEdit_Focus1.Focus();
            textEdit_Focus2.Focus();
            textEdit_Focus4.Focus();
        }

        #endregion

        #region Event


        private void grdLU_KhachHang_EditValueChanged(object sender, EventArgs e)
        {
            if (grdLU_KhachHang.EditValue != null)
            {
                long maDoiTac;
                if (long.TryParse(grdLU_KhachHang.EditValue.ToString(), out maDoiTac))
                {
                    _DoiTac = DoiTac.GetDoiTacWithoutChild(maDoiTac);

                    txt_MaSoThue.EditValue = (object)_DoiTac.MaSoThue;
                    txt_DiaChiKH.EditValue = (object)_DoiTac.DiaChi;
                    lb_TenKhachHang.Text = _DoiTac.TenDoiTac;
                }

            }
        }



        private void frmHopDongDichVu_Load(object sender, EventArgs e)
        {
            if (_isHDNam2014)
            {
                this.Text = "Phụ Lục Hợp Đồng của năm 2014";
            }
            else
                this.Text = this.Text + SetGhiChu();
            rdGroupLoai.Properties.ReadOnly = true;
        }

        private void grdVChiTietHopDong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdVChiTietHopDong.FocusedColumn.Name == "colSoLuong" || grdVChiTietHopDong.FocusedColumn.Name == "colDonGia" || grdVChiTietHopDong.FocusedColumn.Name == "colThanhTien")
            {
                TinhGiaTriHDTheoCT_HopDong();
            }
        }

        private void grdVChiTietThanhToan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ChiTietThanhToanHopDongThuChi ct = chiTietThanhToanBindingSource.Current as ChiTietThanhToanHopDongThuChi;
            ct.ThueSuat = _HopDongMuaBan.ThueSuat;
            ct.MaLoaiTien = _HopDongMuaBan.MaLoaiTien;
            ct.TiGiaQuyDoi = _HopDongMuaBan.TiGiaQuyDoi;
        }

        private void grdVChiTietThanhToanThucTe_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ChiTietThanhToanThucTe ct = chiTietThanhToanThucTeListBindingSource.Current as ChiTietThanhToanThucTe;
            ct.ThueSuat = _HopDongMuaBan.ThueSuat;
            ct.MaLoaiTien = _HopDongMuaBan.MaLoaiTien;
            ct.TiGiaQuyDoi = _HopDongMuaBan.TiGiaQuyDoi;
        }


        private void grdVChiTietThanhToan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdVChiTietThanhToan.FocusedColumn.Name == "colPhanTramThanhToan")
            {
                ChiTietThanhToanHopDongThuChi ct = chiTietThanhToanBindingSource.Current as ChiTietThanhToanHopDongThuChi;
                ct.TienCoThue = (_HopDongMuaBan.TongTien * ct.PhanTramThanhToan) / 100;
            }
        }

        private void grdVChiTietThanhToanThucTe_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdVChiTietThanhToanThucTe.FocusedColumn.Name == "colPhanTramThanhToan")
            {
                ChiTietThanhToanThucTe ct = chiTietThanhToanThucTeListBindingSource.Current as ChiTietThanhToanThucTe;
                ct.TienCoThue = (_HopDongMuaBan.TongTien * ct.PhanTramThanhToan) / 100;
            }
        }
        private void grdVChiTietHopDong_KeyDown(object sender, KeyEventArgs e)
        {
            if (HamDungChung.DeleteSelectedRowsGridViewDev(grdVChiTietHopDong, e))
            {
                TinhGiaTriHDTheoCT_HopDong();
            }
        }

        private void grdVChiTietThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.DeleteSelectedRowsGridViewDev(grdVChiTietThanhToan, e);

        }


        private void grdVChiTietThanhToanThucTe_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.DeleteSelectedRowsGridViewDev(grdVChiTietThanhToanThucTe, e);
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoPhuLucHopDong();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Focus();
            if (KiemTraRangBuocTruocKhiLuu())
            {
                //B
                if (KiemTraDuLieu() && KiemTraChiTietThanhToan() && KiemTraChiTietThanhToanThucTe())
                {
                    if (MessageBox.Show(this, "Bạn Muốn Lưu Dữ Liệu", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        if (LuuDuLieu() == true)
                        {
                            MessageBox.Show(this, "Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindingData();
                        }
                    }
                }
                //E
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void GridLookUpEdit_MaChiTietHopDong_Popup(object sender, EventArgs e)
        {
            if (_HopDongMuaBan.CT_HopDongDichVu.IsDirty)
            {
                MessageBox.Show("Vui lòng nhấn nút [Lưu] để cập nhật chương trình vào Danh sách chọn thanh toán!");
            }
        }

        #endregion



        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (KiemTraRangBuocTruocKhiXoa())
            {
                if (MessageBox.Show("Bạn có muốn xóa Phụ lục này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        HopDongThuChi.DeleteHopDongThuChi(_HopDongMuaBan.MaHopDong);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThemMoi.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void grdLU_MaHopDongChinh_EditValueChanged(object sender, EventArgs e)
        {
            //if (!_notNewPhuLuc)
            if (_HopDongMuaBan.IsNew)
            {
                if (grdLU_MaHopDongChinh.EditValue != null)
                {
                    long maHopDong;
                    if (long.TryParse(grdLU_MaHopDongChinh.EditValue.ToString(), out maHopDong))
                    {
                        HopDongThuChi hopdongthuchi = HopDongThuChi.GetHopDongMuaBanLast(maHopDong);
                        _HopDongMuaBan = HopDongThuChi.NewPhuLucHopDongMuaBan(hopdongthuchi);
                        BindingData();
                        //_notNewPhuLuc = false;
                    }

                }
            }

        }

        private void FrmPhuLucHopDongBanQuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_HopDongMuaBan.IsNew)
            {
                if (_HopDongMuaBan.SoHopDong == "")
                {
                    if (_HopDongMuaBan.HDTrongNgoaiDai)
                    {
                        MessageBox.Show("Đây là Phụ lục Hợp đồng ngoài đài, Vui lòng nhập Số Phụ lục hợp đồng");

                    }
                    else
                    {
                        MessageBox.Show("Số Phụ lục hợp đồng không được trống!");
                    }
                    txt_SoHopDong.Focus();
                    e.Cancel = true;
                }
                else if (_HopDongMuaBan.IsDirty)
                {
                    if (LuuDuLieu() == false)
                    {
                        e.Cancel = true;
                    }
                }

            }
        }




    }
}