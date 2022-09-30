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
    public partial class FrmPhuLucHopDongMuaSam : DevExpress.XtraEditors.XtraForm
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

        //private bool _notNewPhuLuc = false;
        //--


        #endregion

        public FrmPhuLucHopDongMuaSam()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoHopDong();
        }
        public FrmPhuLucHopDongMuaSam(HopDongThuChi hopDongThuChi,bool tuDS)
        {
            //_notNewPhuLuc = true;
            InitializeComponent();
            KhoiTao();
            KhoiTaoHopDong(hopDongThuChi,tuDS);
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
            ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewList();
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewList.Insert(0, ct0);
            chuongTrinh_NewListAllBindingSource.DataSource = _chuongTrinh_NewList;


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
        }

        private void KhoiTaoHopDong()
        {

            _HopDongMuaBan = HopDongThuChi.NewHopDongMuaBan();
            SetGiaTriMacDinhHopDong();
            BindingData();

        }

        private void KhoiTaoHopDong(HopDongThuChi hopDongThuChi, bool tuDS)
        {
            if (tuDS)
            {
                _HopDongMuaBan = hopDongThuChi;
            }
            else
            {
                HopDongThuChi hdtcLast = HopDongThuChi.GetHopDongMuaBanLast(hopDongThuChi.MaHopDong);
                _HopDongMuaBan = HopDongThuChi.NewPhuLucHopDongMuaBan(hdtcLast);
            }
            BindingData();

        }
        private void SetGiaTriMacDinhHopDong()
        {
            _HopDongMuaBan.MaNguoiKy = 14354;//Người đại diện hợp đồng mặc định là "Cao Anh MInh"
            _HopDongMuaBan.TinhTrang = _tinhTrang;
            if (LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL) != null)
                _HopDongMuaBan.MaLoaiHopDong = LoaiHopDong.GetLoaiHopDong(_maLoaiHDQL).MaLoaiHopDong;
        }

        private bool SetSoHopDongTrongDai()
        {
            #region New
            if ((!_HopDongMuaBan.HDTrongNgoaiDai) && _HopDongMuaBan.TinhTrang == 1)//Là HĐ trong đài
            {
                if (_HopDongMuaBan.IsNew)
                {
                    _HopDongMuaBan.SoHopDong = HopDongThuChi.SetSoPhuLucHopDong(_HopDongMuaBan.MaHopDongChinh);
                    txt_SoHopDong.Text = _HopDongMuaBan.SoHopDong;

                }
            }
            else if (_HopDongMuaBan.HDTrongNgoaiDai)
            {
                if (txt_SoHopDong.Text.Trim() == "")
                {
                    MessageBox.Show("Đây là Phụ lục Hợp đồng ngoài đài, Vui lòng nhập Số Phụ lục hợp đồng");
                    txt_SoHopDong.Focus();
                    return false;
                }
            }
            #endregion //New
            #region old
            //if (_HopDongMuaBan.TinhTrang == 1)
            //{
            //    if (_HopDongMuaBan.IsNew)
            //    {
            //        txt_SoHopDong.Text = HopDongThuChi.SetSoPhuLucHopDong(_HopDongMuaBan.MaHopDongChinh);

            //    }
            //}
            //else
            //{
            //    if (txt_SoHopDong.Text.Trim() == "")
            //    {
            //        MessageBox.Show("Vui lòng nhập Số Phụ lục hợp đồng!");
            //        txt_SoHopDong.Focus();
            //        return false;
            //    }
            //}
            #endregion //old
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

        private bool KiemTraSoHopDongHopLe()
        {
            string sohopdongChinh = HopDongThuChi.GetSoHopDongForSoPhuLuc(_HopDongMuaBan.MaHopDongChinh);
            string sohopdong = txt_SoHopDong.Text.Trim();
            if (sohopdong.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập vào Số phụ lục hợp đồng!");
                txt_SoHopDong.Focus();
                return false;
            }
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
            if (HopDongThuChi.KiemTraTrungSoHopDong(_HopDongMuaBan.MaHopDong, sohopdong))
            {
                MessageBox.Show("Trùng số hợp đồng! Vui lòng chỉnh lại!");
                txt_SoHopDong.Focus();
                return false;
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

            if (_HopDongMuaBan.MaPhanLoaiHD == 0)
            {
                //MessageBox.Show(this, util.LoaiHopDong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(this, "vui lòng chọn Loại Hợp đồng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
            else if (_HopDongMuaBan.chiTietThanhToan.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Chi Tiết Thanh Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return false;
            }
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
                if (SetSoHopDongTrongDai())
                {
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
            this.Text = this.Text + SetGhiChu();
            rdGroupLoai.Properties.ReadOnly = true;
            grdLU_ChuongTrinh.Properties.ReadOnly = true;
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
            KhoiTaoHopDong();
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
                    }
                }
            }
            //_notNewPhuLuc = false;
        }

        private void lookUpEdit_MaBoPhanChuQuan_EditValueChanged(object sender, EventArgs e)
        {
            int maBoPhan = 0;
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




    }
}