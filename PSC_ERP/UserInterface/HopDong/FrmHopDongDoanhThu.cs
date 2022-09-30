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
    public partial class FrmHopDongDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        DoiTacList _DoiTacList;
        DoiTac _DoiTac;
        BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();

        HopDongThuChi _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
        DonViTinhList _DonViTinhList;
        string _maLoaiHDQL = "HDDT";
        int _maLoaiHopDong;
        private byte _tinhTrang = 1;//xac dinh bat dau van hanh phan he Hop Dong
        bool _tuHopDongPS;
        bool _themMoi;
        //--


        #endregion

        public FrmHopDongDoanhThu()
        {
            InitializeComponent();
            _tuHopDongPS = false;
            KhoiTao();
            KhoiTaoHopDong();
        }

        public FrmHopDongDoanhThu(HopDongThuChi hopDongThuChi)
        {
            InitializeComponent();
            _tuHopDongPS = false;
            KhoiTao();
            KhoiTaoHopDong(hopDongThuChi);
        }

        public FrmHopDongDoanhThu(HopDongThuChi hopDongThuChi, bool tuHopDongPS)
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
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
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

            //
            this.grdChiTietThanhToan.DataSource = this.chiTietThanhToanBindingSource;
            this.grdChiTietThanhToanThucTe.DataSource = this.chiTietThanhToanThucTeListBindingSource;
            //
            DesignGrid_ChiTietHopDong();
            DesignGrid_ChiTietThanhToan();
            DesignGrid_ChiTietThanhToanThucTe();
            DesignGrid_ChiTietThuLao();
        }
        private void KhoiTaoHopDong()
        {
            _themMoi = true;
            cb_LoaiHD.Focus();

            _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
            SetGiaTriMacDinhHopDong();

            //MessageBox.Show("Khi nhập Hợp đồng cần xác định rõ, đây là Hợp đồng [Trong] hay [Ngoài] đài!\n Việc này sẽ giúp Số Hợp đồng được chính xác", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            BindingData();

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
            cbu_ThueSuat.Value = 10;
            _HopDongMuaBan.ThueSuat = 10;
            //if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
            //    _HopDongMuaBan.MaLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
            _HopDongMuaBan.MaLoaiHopDong = _maLoaiHopDong;
            
            _HopDongMuaBan.TinhTrang = _tinhTrang;
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
            else if (_HopDongMuaBan.HDTrongNgoaiDai)
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



        private string SetGhiChu()
        {
            if (!cb_LoaiHD.Checked)
            {
                return "Hợp Đồng Doanh Thu - Đang nhập Hợp đồng trong đài...";
            }
            else
            {
                return "Hợp Đồng Doanh Thu - Đang nhập Hợp đồng ngoài đài...";
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
                //if (SetSoHopDongTrongDai())
                //{
                    if (KiemTraSoHopDongHopLe())
                    {
                        _HopDongMuaBan.ApplyEdit();
                        HopDongMuaBanBindingSource.EndEdit();
                        _HopDongMuaBan.Save();
                    }
                    else
                    {
                        kq = false;
                    }
                //}
                //else
                //{
                //    kq = false;
                //}
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
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietHopDong, new string[] { "SoLuong", "DonGia", "ThanhTien" }, "#,###.#");
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
            HamDungChung.ShowFieldGridViewDev(grdVChiTietThanhToan, new string[] { "PhuongThucThanhToan", "PhanTramThanhToan", "MaLoaiTien", "TiGiaQuyDoi", "ThueNhaThau", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "GhiChu" },
                                new string[] { "Phương Thức TT", "% thanh toán", "Loại tiền", "Tỉ giá", "Thuế nhà thầu", "Tiền có thuế", "Thuế suất(%)", "Tiền thuế", "Tiền chưa thuế", "Tiền phạt", "Nội dung thanh toán" },
                                             new int[] { 150, 100, 100, 100, 100, 150, 100, 150, 150, 100, 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVChiTietThanhToan, new string[] { "PhuongThucThanhToan", "PhanTramThanhToan", "MaLoaiTien", "TiGiaQuyDoi", "ThueNhaThau", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietThanhToan, new string[] { "TiGiaQuyDoi" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToan, new string[] { "PhanTramThanhToan", "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdVChiTietThanhToan, new string[] { "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdVChiTietThanhToan);

            Utils.GridUtils.SetSTTForGridView(grdVChiTietThanhToan, 50);//M
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource1;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien", "TiGiaQuyDoi" }, new string[] { "Mã", "Loại tiền", "Tỉ giá quy đổi" }, new int[] { 100, 150, 150 }, true);
            //
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThanhToan, "MaLoaiTien", LoaiTien_GrdLU);
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
            HamDungChung.ShowFieldGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "NgayThanhToan", "PhanTramThanhToan", "MaLoaiTien", "TiGiaQuyDoi", "ThueNhaThau", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "GhiChu" },
                                new string[] { "Ngày TT", "% thanh toán", "Loại tiền", "Tỉ giá", "Thuế nhà thầu", "Tiền có thuế", "Thuế suất(%)", "Tiền thuế", "Tiền chưa thuế", "Tiền phạt", "Nội dung thanh toán" },
                                             new int[] { 100, 100, 100, 100, 100, 150, 100, 150, 150, 100, 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "NgayThanhToan", "PhanTramThanhToan", "MaLoaiTien", "TiGiaQuyDoi", "ThueNhaThau", "TienCoThue", "ThueSuat", "TienThue", "SoTien", "TienPhat", "GhiChu" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "TiGiaQuyDoi" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToanThucTe, new string[] { "PhanTramThanhToan", "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdVChiTietThanhToanThucTe, new string[] { "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdVChiTietThanhToanThucTe);

            Utils.GridUtils.SetSTTForGridView(grdVChiTietThanhToanThucTe, 50);//M
            //
            RepositoryItemDateEdit Ngay_DE = new RepositoryItemDateEdit();
            Ngay_DE.DisplayFormat.FormatString = "dd/MM/yyyy";
            Ngay_DE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Ngay_DE.Mask.EditMask = "dd/MM/yyyy";
            Ngay_DE.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            //
            //
            RepositoryItemGridLookUpEdit LoaiTien_GrdLU = new RepositoryItemGridLookUpEdit();
            LoaiTien_GrdLU.DataSource = loaiTienListBindingSource1;
            LoaiTien_GrdLU.DisplayMember = "MaLoaiQuanLy";
            LoaiTien_GrdLU.ValueMember = "MaLoaiTien";
            HamDungChung.InitRepositoryItemGridLookUpDev(LoaiTien_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(LoaiTien_GrdLU, new string[] { "MaLoaiQuanLy", "TenLoaiTien", "TiGiaQuyDoi" }, new string[] { "Mã", "Loại tiền", "Tỉ giá quy đổi" }, new int[] { 100, 150, 150 }, true);
            //
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThanhToanThucTe, "NgayThanhToan", Ngay_DE);
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThanhToanThucTe, "MaLoaiTien", LoaiTien_GrdLU);
            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdVChiTietThanhToanThucTe, new string[] { "TiGiaQuyDoi" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThanhToanThucTe, new string[] { "PhanTramThanhToan", "ThueNhaThau", "TienCoThue", "TienThue", "SoTien", "TienPhat" }, "#,###.#");

            //
            this.grdVChiTietThanhToanThucTe.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.grdVChiTietThanhToanThucTe_InitNewRow);
            this.grdVChiTietThanhToanThucTe.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdVChiTietThanhToanThucTe_CellValueChanged);
            this.grdVChiTietThanhToanThucTe.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdVChiTietThanhToanThucTe_KeyDown);
            //
        }

        private void DesignGrid_ChiTietThuLao()
        {
            HamDungChung.InitGridViewDev(grdVChiTietThuLao, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(grdVChiTietThuLao, new string[] { "MaBoPhan", "NgayTinhThuLao", "SoTien" },
                                                new string[] { "Tên đơn vị", "Ngày tính thù lao", "Số tiền" },
                                                new int[] { 200, 100, 150 });
            HamDungChung.AlignHeaderColumnGridViewDev(grdVChiTietThuLao, new string[] { "MaBoPhan", "NgayTinhThuLao", "SoTien" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThuLao, new string[] { "SoTien" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdVChiTietThuLao, new string[] { "SoTien" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(grdVChiTietThuLao);

            Utils.GridUtils.SetSTTForGridView(grdVChiTietThuLao, 50);//M
            //
            RepositoryItemGridLookUpEdit BoPhan_GrdLU = new RepositoryItemGridLookUpEdit();
            BoPhan_GrdLU.DataSource = BoPhanListbindingSource1;
            BoPhan_GrdLU.DisplayMember = "TenBoPhan";
            BoPhan_GrdLU.ValueMember = "MaBoPhan";
            HamDungChung.InitRepositoryItemGridLookUpDev(BoPhan_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(BoPhan_GrdLU, new string[] { "MaBoPhanQL", "TenBoPhan" }, new string[] { "Mã", "Tên bộ phận" }, new int[] { 100, 150 }, false);
            //
            //
            RepositoryItemDateEdit Ngay_DE = new RepositoryItemDateEdit();
            Ngay_DE.DisplayFormat.FormatString = "dd/MM/yyyy";
            Ngay_DE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            Ngay_DE.Mask.EditMask = "dd/MM/yyyy";
            Ngay_DE.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            //
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThuLao, "MaBoPhan", BoPhan_GrdLU);
            HamDungChung.RegisterControlFieldGridViewDev(grdVChiTietThuLao, "NgayTinhThuLao", Ngay_DE);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdVChiTietThuLao, new string[] { "SoTien" }, "#,###.#");

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
            textEdit_Focus3.Focus();
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
            this.Text =SetGhiChu();
            KiemTraKhoaSoHopDong();
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

        private void grdVChiTietThuLao_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.DeleteSelectedRowsGridViewDev(grdVChiTietThuLao, e);
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
                if (cb_LoaiHD.Checked)
                {
                    txt_SoHopDong.BackColor = Color.White;
                    MessageBox.Show("Lưu ý, Bạn đang chọn Hợp đồng [Ngoài] đài, Số hợp đồng bạn phải nhập vào!");
                }
                else
                {
                    txt_SoHopDong.BackColor = Color.LightGray;
                }
                _HopDongMuaBan.HDTrongNgoaiDai = cb_LoaiHD.Checked;
                KiemTraKhoaSoHopDong();
            }
        }

        private void btn_LaySoHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TaoHopDongTuSoHopDongPS();
            SetTieuDe_btnLaySoHopDong(_themMoi);
        }

        private void FrmHopDongDoanhThu_FormClosing(object sender, FormClosingEventArgs e)
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




    }
}