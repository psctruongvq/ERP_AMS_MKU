using System;
using System.Windows.Forms;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;

namespace PSC_ERP
{
    public partial class frmHopDongMuaSam : XtraForm
    {
        #region Properties
        DoiTacList _DoiTacList;
        DoiTac _DoiTac;
        BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();

        HopDongThuChi _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
        DonViTinhList _DonViTinhList;
        string _maLoaiHDQL = "HDMS";
        int _maLoaiHopDong;
        private byte _tinhTrang = 1;//xac dinh bat dau van hanh phan he Hop Dong
        bool CheckTrongNgoaiDai = true;
        bool _tuHopDongPS;

        bool _themMoi;
        //--
        #endregion

        public frmHopDongMuaSam()
        {
            if (ERP_Library.Security.CurrentUser.Info == null || ERP_Library.Security.CurrentUser.Info.UserID == 0)
            {
                MessageBox.Show("Chưa đăng nhập");
                this.Close();
            }
            InitializeComponent();
            _tuHopDongPS = false;
            KhoiTao();
            KhoiTaoHopDong();
        }

        public frmHopDongMuaSam(long maDoiTac)//Dap ung ben Tai San
        {
            if (ERP_Library.Security.CurrentUser.Info == null || ERP_Library.Security.CurrentUser.Info.UserID == 0)
            {
                MessageBox.Show("Chưa đăng nhập");
                this.Close();
            }
            InitializeComponent();
            _tuHopDongPS = false;
            KhoiTao();
            KhoiTaoHopDong(maDoiTac);
        }
        public frmHopDongMuaSam(HopDongThuChi hopDongThuChi)
        {
            InitializeComponent();
            _tuHopDongPS = false;
            KhoiTao();
            KhoiTaoHopDong(hopDongThuChi);
        }
        public frmHopDongMuaSam(HopDongThuChi hopDongThuChi, bool tuHopDongPS)
        {
            InitializeComponent();
            _tuHopDongPS = tuHopDongPS;
            KhoiTao();
            KhoiTaoHopDongTuHopDongPS(hopDongThuChi);
        }

        #region Function

        private void SetTieuDe_btnLaySoHopDong(bool dieuKien)
        {
            if (dieuKien)//La Them Moi
            {
                btn_LaySoHopDong.Caption = "Lấy Số Hợp Đồng!";
            }
            else//La cap nhat
            {
                btn_LaySoHopDong.Caption = "Lấy Lại Số Hợp Đồng!";
            }
        }

        private void TaoHopDongTuSoHopDongPS()
        {
            if (KiemTraRangBuocTruocKhiThayDoi())
            {
                FrmDanhSachSoHopDongPhatSinh frm = new FrmDanhSachSoHopDongPhatSinh(2);
                //Cường thêm              
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    if (frm.MaHopDong != 0)
                    {
                        _tuHopDongPS = true;
                        HopDongThuChi hopDongThuChi = HopDongThuChi.GetHopDongMuaBan(frm.MaHopDong);
                        if (_HopDongMuaBan.IsNew)//tao moi Hop Dong
                        {
                            //
                            KhoiTaoHopDongTuHopDongPS(hopDongThuChi);
                            //
                        }
                        else//Cap Nhat lai HopDong
                        {
                            _HopDongMuaBan = HopDongThuChi.UpdateHopDongFromHopDong(_HopDongMuaBan, hopDongThuChi);
                            BindingData();
                        }
                        KiemTraKhoaHDTrongNgoaiDai();
                        KiemTraKhoaSoHopDong();
                    }
                }
            }
        }

        private void KhoiTao()
        {
            if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
                _maLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
            //
            NguoiDaiDienList_bindingSource.DataSource = TenNhanVienList.GetTenNhanVienList_NguoiDaiDienHopDong();
            PhanLoaiHopDongList_bindingSource.DataSource = PhanLoaiHopDongList.GetPhanLoaiHopDongList(_maLoaiHopDong);

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
            QuocGiaBQ_VT qg = QuocGiaBQ_VT.NewQuocGiaBQ_VT("Không chọn");
            _quocGiaList.Insert(0, qg);
            bs_QuocGiaList.DataSource = _quocGiaList;
            //
            ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewList();
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewList.Insert(0, ct0);
            chuongTrinh_NewListAllBindingSource.DataSource = _chuongTrinh_NewList;            

            DesignGrid_ChiTietHopDong();
            DesignGrid_ChiTietThanhToan();
            DesignGrid_ChiTietThanhToanThucTe();
        }
        private void KhoiTaoHopDong()
        {
            _themMoi = true;
            CheckTrongNgoaiDai = false;
            cb_LoaiHD.Focus();

            _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
            SetGiaTriMacDinhHopDong();
            BindingData();
            //MessageBox.Show("Khi nhập Hợp đồng cần xác định rõ, đây là Hợp đồng [Trong] hay [Ngoài] đài!\n Việc này sẽ giúp Số Hợp đồng được chính xác", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void KhoiTaoHopDong(long maDoiTac)//Dap ung ben Tai San
        {
            _themMoi = true;
            CheckTrongNgoaiDai = false;
            cb_LoaiHD.Focus();

            _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
            SetGiaTriMacDinhHopDong();
            _HopDongMuaBan.MaDoiTac = maDoiTac;
            BindingData();
            //MessageBox.Show("Khi nhập Hợp đồng cần xác định rõ, đây là Hợp đồng [Trong] hay [Ngoài] đài!\n Việc này sẽ giúp Số Hợp đồng được chính xác", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }

        private void KhoiTaoHopDong(HopDongThuChi hopDongThuChi)
        {
            _themMoi = false;
            _HopDongMuaBan = hopDongThuChi;
            BindingData();
        }

        private void KhoiTaoHopDongTuHopDongPS(HopDongThuChi hopDongThuChi)
        {
            _themMoi = false;
            _HopDongMuaBan = hopDongThuChi;
            SetGiaTriMacDinhHopDong();
            BindingData();
        }

        private void BindingData()
        {
            HopDongMuaBanBindingSource.DataSource = _HopDongMuaBan;
            cTHopDongDichVuBindingSource.DataSource = _HopDongMuaBan.CT_HopDongDichVu;
            chiTietThanhToanBindingSource.DataSource = _HopDongMuaBan.chiTietThanhToan;
            chiTietThanhToanThucTeListBindingSource.DataSource = _HopDongMuaBan.chiTietThanhToanThucTeList;
            ChiTietThuLao_bindingSource.DataSource = _HopDongMuaBan.chiTietThuLaoHopDongList;
        }

        private void SetGiaTriMacDinhHopDong()
        {
            _HopDongMuaBan.MaNguoiKy = 14354;//Người đại diện hợp đồng mặc định là "Cao Anh MInh"
            _HopDongMuaBan.TinhTrang = _tinhTrang;
            if (_tuHopDongPS == false)//Khong phai tu So Hop Dong PS
            {
                _HopDongMuaBan.HDTrongNgoaiDai = true;//
                _HopDongMuaBan.ThuChi = 2;//
            }
            //if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
            //    _HopDongMuaBan.MaLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
            _HopDongMuaBan.MaLoaiHopDong = _maLoaiHopDong;
        }

        private bool SetSoHopDongTrongDai()
        {
            if ((!_HopDongMuaBan.HDTrongNgoaiDai) && _HopDongMuaBan.TinhTrang == 1)//Là HĐ trong đài
            {
                if (_HopDongMuaBan.IsNew)
                {
                    //_HopDongMuaBan.SoHopDong = HopDongMuaBan.SetSoHopDongTrongDai(_HopDongMuaBan.NgayLap);
                    txt_SoHopDong.Text = HopDongThuChi.SetSoHopDongTrongDai(_HopDongMuaBan.NgayKy.Value.Date);

                }
            }
            else 
                if (_HopDongMuaBan.HDTrongNgoaiDai)
            {
                if (txt_SoHopDong.Text.Trim() == "")
                {
                    MessageBox.Show("Đây là Hợp đồng ngoài đài, Vui lòng nhập Số hợp đồng!");
                    txt_SoHopDong.Focus();
                    return false;
                }
            }
            return true;
        }

        private bool SetSoThamDinhHopDong()
        {
            if (_HopDongMuaBan.TinhTrang == 1)//Là HĐ trong đài
            {
                if (_HopDongMuaBan.IsNew || _tuHopDongPS)
                {
                    txt_SoThamDinh.Text = HopDongThuChi.SetSoThamDinhHopDong(_HopDongMuaBan.NgayKy.Value.Date);

                }
            }
            return true;
        }

        private string SetGhiChu()
        {
            if (!cb_LoaiHD.Checked)
            {
                return "Hợp Đồng Mua Sắm - Đang nhập Hợp đồng trong đài...";
            }
            else
            {
                return "Hợp Đồng Mua Sắm - Đang nhập Hợp đồng ngoài đài...";
            }

        }

        private bool KiemTraSoHopDongHopLe()
        {
            string sohopdong = txt_SoHopDong.Text.Trim();
            if (!_HopDongMuaBan.HDTrongNgoaiDai)//Là HĐ trong đài
            {
                if (sohopdong.Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn Số hợp đồng!");
                    txt_SoHopDong.Focus();
                    return false;
                }
                int soTTHD;
                if (!int.TryParse(sohopdong.Substring(0, 3), out soTTHD))
                {
                    MessageBox.Show("Số hợp đồng không hợp lệ! 3 ký tự đầu phải là số!");
                    txt_SoHopDong.Focus();
                    return false;
                }

            }
            else//là HĐ ngoài đài
            {
                if (sohopdong.Length == 0)
                {
                    MessageBox.Show("Vui lòng nhập vào Số hợp đồng!");
                    txt_SoHopDong.Focus();
                    return false;
                }

            }
            if (HopDongThuChi.KiemTraTrungSoHopDong(_HopDongMuaBan.MaHopDong, sohopdong))
            {
                MessageBox.Show("Trùng số hợp đồng! Vui lòng chỉnh lại!");
                txt_SoHopDong.Focus();
                return false;
            }

            return true;
        }

        private bool KiemTraSoThamDinhHopDongHopLe()
        {
            string sothamdinh = txt_SoThamDinh.Text.Trim();
            if (sothamdinh.Length > 0)
            {
                if (_HopDongMuaBan.TinhTrang == 1)//Là HĐ trong đài
                {
                    int soTTTD;
                    if (!int.TryParse(sothamdinh.Substring(0, 3), out soTTTD))
                    {
                        MessageBox.Show("Số thẩm định không hợp lệ! 3 ký tự đầu phải là số!");
                        txt_SoThamDinh.Focus();
                        return false;
                    }

                }
            }
            if (HopDongThuChi.KiemTraTrungSoThamDinhHopDong(_HopDongMuaBan.MaHopDong, sothamdinh))
            {
                MessageBox.Show("Trùng số thẩm định! Vui lòng chỉnh lại!");
                txt_SoThamDinh.Focus();
                return false;
            }

            return true;
        }

        private void KiemTraKhoaHDTrongNgoaiDai()
        {
            //if (_HopDongMuaBan.HDTrongNgoaiDai)//if la HD ngoai dai
            cb_LoaiHD.Enabled = false;

        }

        private void KiemTraKhoaSoHopDong()
        {
            if (_HopDongMuaBan.HDTrongNgoaiDai)//if la HD ngoai dai
            {
                txt_SoHopDong.Properties.ReadOnly = false;
            }
            else
            {
                txt_SoHopDong.Properties.ReadOnly = true;
            }
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

            if (_HopDongMuaBan.MaPhanLoaiHD == 0)
            {
                //MessageBox.Show(this, util.LoaiHopDong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(this, "vui lòng chọn Phân Loại Hợp đồng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
            if (txt_TenHopDong.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập vào nôi dung Hợp đồng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (HopDongThuChi.KiemTraHopDongDaPhatSinhPhuLuc(_HopDongMuaBan.MaHopDong))
                {
                    MessageBox.Show(this, "Hợp đồng đã phát sinh Phụ lục, Không thể lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //if (HopDongThuChi.KiemTraHopDongDaPhatSinhNghiemThuThanhly(_HopDongMuaBan.MaHopDong))
                //{
                //    MessageBox.Show(this, "Hợp đồng đã Nghiệm thu thanh lý, Không thể lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
            }
            return true;
        }

        private bool KiemTraRangBuocTruocKhiXoa()
        {
            if (HopDongThuChi.KiemTraHopDongDaPhatSinhPhuLuc(_HopDongMuaBan.MaHopDong))
            {
                MessageBox.Show(this, "Hợp đồng đã phát sinh Phụ lục, Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (HopDongThuChi.KiemTraHopDongDaPhatSinhNghiemThuThanhly(_HopDongMuaBan.MaHopDong))
            {
                MessageBox.Show(this, "Hợp đồng đã Nghiệm thu thanh lý, Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (HopDongThuChi.KiemTraHopDongDaPhatSinhNhapXuat(_HopDongMuaBan.MaHopDong))
            {
                MessageBox.Show(this, "Hợp đồng đã phát sinh Nhập Xuất, Không thể xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool KiemTraRangBuocTruocKhiThayDoi()
        {
            if (HopDongThuChi.KiemTraHopDongDaPhatSinhPhuLuc(_HopDongMuaBan.MaHopDong))
            {
                MessageBox.Show(this, "Hợp đồng đã phát sinh Phụ lục, Không thể thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (HopDongThuChi.KiemTraHopDongDaPhatSinhNghiemThuThanhly(_HopDongMuaBan.MaHopDong))
            {
                MessageBox.Show(this, "Hợp đồng đã Nghiệm thu thanh lý, Không thể thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (HopDongThuChi.KiemTraHopDongDaPhatSinhNhapXuat(_HopDongMuaBan.MaHopDong))
            {
                MessageBox.Show(this, "Hợp đồng đã phát sinh Nhập Xuất, Không thể thay đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                //if (SetSoHopDongTrongDai() && SetSoThamDinhHopDong())
                if (SetSoThamDinhHopDong())
                {
                    if (KiemTraSoHopDongHopLe() && KiemTraSoThamDinhHopDongHopLe())
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
            HamDungChung.ShowFieldGridViewDev(grdVChiTietHopDong, new string[] { "HangHoa", "MaDonViTinh", "SoLuong", "DonGia", "ThanhTien" },
                                new string[] { "Tên chương trình", "ĐVT", "Số lượng", "Đơn giá", "Thành tiền" },
                                             new int[] { 200, 150, 100, 150, 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVChiTietHopDong, new string[] { "HangHoa", "MaDonViTinh", "SoLuong", "DonGia", "ThanhTien" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietHopDong, new string[] { "SoLuong" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietHopDong, new string[] { "DonGia", "ThanhTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev(grdVChiTietHopDong, new string[] { "SoLuong" });
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdVChiTietHopDong, new string[] { "ThanhTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdVChiTietHopDong);

            Utils.GridUtils.SetSTTForGridView(grdVChiTietHopDong, 50);//M
            //
            RepositoryItemGridLookUpEdit DVT_GrdLU = new RepositoryItemGridLookUpEdit();
            DVT_GrdLU.DataSource = DonViTinhListBindingSource;
            DVT_GrdLU.DisplayMember = "TenDonViTinh";
            DVT_GrdLU.ValueMember = "MaDonViTinh";
            HamDungChung.InitRepositoryItemGridLookUpDev(DVT_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DVT_GrdLU, new string[] { "MaQuanLy", "TenDonViTinh" }, new string[] { "Mã", "Đơn vị tính" }, new int[] { 100, 150 }, false);
            //
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietHopDong, "MaDonViTinh", DVT_GrdLU);

            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietHopDong, new string[] { "SoLuong" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietHopDong, new string[] { "DonGia", "ThanhTien" }, "#,###.#");

        }

        private void DesignGrid_ChiTietThanhToan()
        {

            HamDungChung.InitGridViewDev(grdVChiTietThanhToan, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdVChiTietThanhToan, new string[] { "PhuongThucThanhToan", "PhanTramThanhToan", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "ThueNhaThau", "GhiChu" },
                                new string[] { "Phương Thức TT", "% thanh toán", "Tiền có thuế", "Thuế suất(%)", "Tiền thuế", "Tiền chưa thuế", "Tiền phạt", "Thuế nhà thầu", "Nội dung thanh toán" },
                                             new int[] { 150, 100, 100, 150, 100, 150, 150, 100, 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVChiTietThanhToan, new string[] { "PhuongThucThanhToan", "PhanTramThanhToan", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "ThueNhaThau", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToan, new string[] { "PhanTramThanhToan", "TienCoThue", "TienThue", "SoTien", "TienPhat", "ThueNhaThau" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdVChiTietThanhToan, new string[] { "TienCoThue", "TienThue", "SoTien", "TienPhat", "ThueNhaThau" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdVChiTietThanhToan);

            Utils.GridUtils.SetSTTForGridView(grdVChiTietThanhToan, 50);//M


            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToan, new string[] { "PhanTramThanhToan", "TienCoThue", "TienThue", "SoTien", "TienPhat", "ThueNhaThau" }, "#,###.#");


        }

        private void DesignGrid_ChiTietThanhToanThucTe()
        {
            HamDungChung.InitGridViewDev(grdVChiTietThanhToanThucTe, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "NgayThanhToan", "PhanTramThanhToan", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "ThueNhaThau", "GhiChu" },
                                new string[] { "Ngày TT", "% thanh toán", "Tiền có thuế", "Thuế suất(%)", "Tiền thuế", "Tiền chưa thuế", "Tiền phạt", "Thuế nhà thầu", "Nội dung thanh toán" },
                                             new int[] { 100, 100, 100, 150, 100, 150, 150, 100, 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "NgayThanhToan", "PhanTramThanhToan", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "ThueNhaThau", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToanThucTe, new string[] { "PhanTramThanhToan", "TienCoThue", "TienThue", "SoTien", "TienPhat", "ThueNhaThau" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdVChiTietThanhToanThucTe, new string[] { "TienCoThue", "TienThue", "SoTien", "TienPhat", "ThueNhaThau" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdVChiTietThanhToanThucTe);

            Utils.GridUtils.SetSTTForGridView(grdVChiTietThanhToanThucTe, 50);//M
            //
            RepositoryItemDateEdit Ngay_DE = new RepositoryItemDateEdit();
            Ngay_DE.DisplayFormat.FormatString = "dd/MM/yyyy";
            Ngay_DE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Ngay_DE.Mask.EditMask = "dd/MM/yyyy";
            Ngay_DE.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            //
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThanhToanThucTe, "NgayThanhToan", Ngay_DE);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToanThucTe, new string[] { "PhanTramThanhToan", "TienCoThue", "TienThue", "SoTien", "TienPhat", "ThueNhaThau", }, "#,###.#");
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
            if (!_HopDongMuaBan.IsNew)
            {
                KiemTraKhoaHDTrongNgoaiDai();
            }
            KiemTraKhoaSoHopDong();
            this.Text = SetGhiChu();
            SetTieuDe_btnLaySoHopDong(_themMoi);
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
        }

        private void grdVChiTietThanhToanThucTe_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ChiTietThanhToanThucTe ct = chiTietThanhToanThucTeListBindingSource.Current as ChiTietThanhToanThucTe;
            ct.ThueSuat = _HopDongMuaBan.ThueSuat;
            ct.MaLoaiTien = _HopDongMuaBan.MaLoaiTien;
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
            if (grdVChiTietThanhToanThucTe.FocusedColumn.Name == "colPhanTramThanhToan1")
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
            _tuHopDongPS = false;
            KhoiTaoHopDong();
            cb_LoaiHD.Enabled = true;
            KiemTraKhoaSoHopDong();
            SetTieuDe_btnLaySoHopDong(_themMoi);
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
                            KiemTraKhoaHDTrongNgoaiDai();

                            _tuHopDongPS = false;
                            //
                            _themMoi = false;
                            //
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

        #endregion

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraRangBuocTruocKhiXoa())
            {
                if (MessageBox.Show("Bạn có muốn xóa Hợp đồng này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (_HopDongMuaBan.HDTrongNgoaiDai)
                        {
                            HopDongThuChi.DeleteHopDongThuChi(_HopDongMuaBan.MaHopDong);
                        }
                        else
                        {
                            HopDongThuChi.DeleteHopDongThuChiTuHopDongPS(_HopDongMuaBan.MaHopDong);
                        }
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
                        {
                            //if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
                            //    _HopDongMuaBan.MaLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
                            _HopDongMuaBan.MaLoaiHopDong = _maLoaiHopDong;
                            _HopDongMuaBan.TinhTrang = _tinhTrang;
                            KiemTraKhoaSoHopDong();
                            _themMoi = true;
                        }
                        BindingData();
                    }
                    catch
                    {
                        MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void cb_LoaiHD_CheckedChanged(object sender, EventArgs e)
        {
            this.Text = SetGhiChu();
            if (_HopDongMuaBan.IsNew)
            {
                if (CheckTrongNgoaiDai)
                {
                    ////
                    //if (cb_LoaiHD.Checked)
                    //{
                    //    MessageBox.Show("Lưu ý, Bạn đang chọn Hợp đồng [Ngoài] đài, Số hợp đồng bạn phải nhập vào!");
                    //}
                    ////
                    _HopDongMuaBan.HDTrongNgoaiDai = cb_LoaiHD.Checked;
                    KiemTraKhoaSoHopDong();
                }
            }
            CheckTrongNgoaiDai = true;
        }

        private void btn_LaySoHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaoHopDongTuSoHopDongPS();
            SetTieuDe_btnLaySoHopDong(_themMoi);
        }

        private void frmHopDongMuaSam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_HopDongMuaBan.IsDirty)
            {
                DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (kq == DialogResult.Yes)
                {
                    btnLuu.PerformClick();
                }
                else
                    if (kq == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
            }
        }

        private void lookUpEdit_MaBoPhanChuQuan_EditValueChanged(object sender, EventArgs e)
        {
            int maBoPhan=0;
            if (int.TryParse(lookUpEdit_MaBoPhanChuQuan.EditValue.ToString(), out maBoPhan))
            {
                if (maBoPhan != 0)
                {
                    KeHoachHopDongList keHoachiHopDongList = KeHoachHopDongList.GetKeHoachHopDongList(maBoPhan);
                    KeHoachHopDong khhd = KeHoachHopDong.NewKeHoachHopDong("Không chọn");
                    keHoachiHopDongList.Insert(0, khhd);
                    KeHoachHopDongList_bindingSource.DataSource = keHoachiHopDongList;
                }
            }
        }

        private void de_NgayHopDong_Leave(object sender, EventArgs e)
        {
            if (((DateTime)de_NgayHopDong.OldEditValue).Year != ((DateTime)de_NgayHopDong.EditValue).Year)
            {
                txt_SoThamDinh.Text = HopDongThuChi.SetSoThamDinhHopDong(_HopDongMuaBan.NgayKy.Value.Date);
            }
        }

    }
}