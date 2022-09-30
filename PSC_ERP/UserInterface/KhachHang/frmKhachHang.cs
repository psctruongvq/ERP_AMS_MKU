using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace PSC_ERP
{
    public partial class frmKhachHang : Form
    {

        #region Properties
        DoiTac _DoiTac;
        KhachHang _KhachHang;
        NguoiLienLacList _NguoiLienLacList;
        DiaChi_DoiTacList _DiaChi_DoiTacList;
        DoiTac_DienThoai_FaxList _DoiTac_DienThoai_FaxList;
        TK_NganHangList _TK_NganHangList;
        TKPhu_NganHangList _TKPhu_NganHangList;
        DoiTac_PhuongThucThanhToanList _doiTac_PhuongThucThanhToanList;
        DoiTac_Website_EmailList _DoiTac_Website_EmailList;
        LoaiKhachHangList _LoaiKhachHangList;
        NhomKhachHangList _NhomKhachHangList;
        TinhThanhList _TinhThanhList;
        QuanHuyenList _QuanHuyenList;
        QuocGiaList _QuocGiaList;
        HanMucTinDung _HanMucTinDung;
        PhuongThucThanhToanList _phuongThucThanhToanList;
        Util util = new Util();
        HamDungChung hamDungChung = new HamDungChung();

        public delegate void PassDaTa(DoiTacList value);
        public PassDaTa passDaTa;
        DoiTacList _doiTacList;

        int _flag = 0;

        private bool clickButtoan = false;
        private bool handlefocus = true;

        bool _NewForChungTu = false;
        long _maDoiTacForLapChungTu = 0;
        public long MaDoiTac { get { return _maDoiTacForLapChungTu; } }

        #endregion

        #region Constructor
        public frmKhachHang()
        {
            InitializeComponent();
            InitForm();
            LoadDatasource();
            Them();
        }

        public frmKhachHang(bool newForChungTu)
        {
            _NewForChungTu = newForChungTu;
            InitializeComponent();
            InitForm();
            LoadDatasource();
            Them();
        }

        public frmKhachHang(DoiTac maDoiTac)
        {
            InitializeComponent();
            InitForm();
            LoadDatasource();
            KhoiTao(maDoiTac);
        }

        public frmKhachHang(string maDoiTacString)
        {
            //long maDoiTacOut;
            //DoiTac doiTacPreView=DoiTac.NewDoiTac();
            //if (long.TryParse(maDoiTacString, out maDoiTacOut))
            //{
            //    doiTacPreView = DoiTac.GetDoiTacbyTenDoiTacForPreviewReport(maDoiTacString);
            //}
            DoiTac doiTacPreView = DoiTac.NewDoiTac();
            doiTacPreView = DoiTac.GetDoiTacbyTenDoiTacForPreviewReport(maDoiTacString);
            if (doiTacPreView.MaDoiTac != 0)
            {
                InitializeComponent();
                InitForm();
                LoadDatasource();
                KhoiTao(doiTacPreView);
            }
        }

        public frmKhachHang(object maDoiTacString)
        {
            //long maDoiTacOut;
            //DoiTac doiTacPreView=DoiTac.NewDoiTac();
            //if (long.TryParse(maDoiTacString, out maDoiTacOut))
            //{
            //    doiTacPreView = DoiTac.GetDoiTacbyTenDoiTacForPreviewReport(maDoiTacString);
            //}
            DoiTac doiTacPreView = DoiTac.NewDoiTac();
            //doiTacPreView = DoiTac.GetDoiTacbyTenDoiTacForPreviewReport(maDoiTacString);
            if (doiTacPreView.MaDoiTac != 0)
            {
                InitializeComponent();
                InitForm();
                LoadDatasource();
                KhoiTao(doiTacPreView);
            }
        }

        #endregion

        #region KhoiTao
        public void KhoiTao(DoiTac maDoiTac)
        {
            _DoiTac = maDoiTac;
            DoiTacBindingSource.DataSource = _DoiTac;

            #region MyRegion BS
            bindingSource_DoiTuongTheoDoi.DataSource = _DoiTac.TheoDoiTaiKhoanDoiTuongList;
            #endregion//BS

            _LoaiKhachHangList = LoaiKhachHangList.GetLoaiKhachHangList();
            LoaiKhachHangListbindingSource.DataSource = _LoaiKhachHangList;

            _NhomKhachHangList = NhomKhachHangList.GetNhomKhachHangList();
            NhomKhachHangListBindingSource.DataSource = _NhomKhachHangList;

            _phuongThucThanhToanList = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            phuongThucThanhToanListBindingSource.DataSource = _phuongThucThanhToanList;

            _KhachHang = _DoiTac.KhachHang;
            KhachHangBindingSource.DataSource = _KhachHang;

            if (_KhachHang.HanMucTinDungList.Count == 0)
            {
                _HanMucTinDung = HanMucTinDung.NewHanMucTinDung();
                HanMucTinDungBindingSource.DataSource = _HanMucTinDung;
                _KhachHang.HanMucTinDungList.Add(_HanMucTinDung);
            }
            else
            {
                _HanMucTinDung = _KhachHang.HanMucTinDungList[0];
                HanMucTinDungBindingSource.DataSource = _HanMucTinDung;
                _KhachHang.HanMucTinDungList.Add(_HanMucTinDung);
            }

            _NguoiLienLacList = NguoiLienLacList.NewNguoiLienLacList();
            _NguoiLienLacList = _DoiTac.NguoiLienLacList;
            NguoiLienLaclistBindingSource.DataSource = _NguoiLienLacList;

            _DiaChi_DoiTacList = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
            _DiaChi_DoiTacList = _DoiTac.DiaChi_DoiTacList;
            diaChiDoiTacListBindingSource.DataSource = _DiaChi_DoiTacList;

            _DoiTac_DienThoai_FaxList = DoiTac_DienThoai_FaxList.NewDoiTac_DienThoai_FaxList();
            _DoiTac_DienThoai_FaxList = _DoiTac.DoiTac_DienThoai_FaxList;
            doiTacDienThoaiFaxListBindingSource.DataSource = _DoiTac_DienThoai_FaxList;

            _TK_NganHangList = TK_NganHangList.NewTK_NganHangList();
            _TK_NganHangList = _DoiTac.TK_NganHangList;
            TK_NganHangListBindingSource.DataSource = _TK_NganHangList;

            _TKPhu_NganHangList = _DoiTac.tKPhu_NganHangList;
            TaiKhoanPhu_bindingSource.DataSource = _TKPhu_NganHangList;

            doiTacPhuongThucThanhToanListBindingSource.DataSource = _DoiTac.DoiTac_PhuongThucThanhToanList;

            doiTacWebsiteEmailListBindingSource.DataSource = _DoiTac.DoiTac_Website_EmailList;

            _TinhThanhList = TinhThanhList.GetTinhThanhList();
            tinhThanhListBindingSource.DataSource = _TinhThanhList;

            TinhThanh_BindingSource.DataSource = _TinhThanhList;

            _QuocGiaList = QuocGiaList.GetQuocGiaList();
            quocGiaListBindingSource.DataSource = _QuocGiaList;

            _QuanHuyenList = QuanHuyenList.GetQuanHuyenList();
            QuanHuyen _QuanHuyen = QuanHuyen.NewQuanHuyen("Thêm mới ...", 0);

            _QuanHuyenList.Insert(0, _QuanHuyen);
            quanHuyenListBindingSource.DataSource = _QuanHuyenList;

            nganHangListBindingSource.DataSource = NhomNganHangList.GetNhomNganHangList();


            
        }
        #endregion

        #region Them
        public void Them()
        {
            _DoiTac = DoiTac.NewDoiTac(DoiTac.MaKhachHangTuDong(2));
            _DoiTac.KhachHang.MaLoaiKhachHang = 1;
            _DoiTac.KhachHang.MaNhomKhachHang = 1;
            DoiTacBindingSource.DataSource = _DoiTac;
            #region MyRegion BS
            bindingSource_DoiTuongTheoDoi.DataSource = _DoiTac.TheoDoiTaiKhoanDoiTuongList;
            #endregion//BS
            _DoiTac.LoaiDoiTac = 0;

            _LoaiKhachHangList = LoaiKhachHangList.GetLoaiKhachHangList();
            LoaiKhachHang _LoaiKhachHang = LoaiKhachHang.NewLoaiKhachHang(0, "Thêm Mới...");
            _LoaiKhachHangList.Insert(0, _LoaiKhachHang);
            LoaiKhachHangListbindingSource.DataSource = _LoaiKhachHangList;

            _KhachHang = _DoiTac.KhachHang;
            KhachHangBindingSource.DataSource = _KhachHang;

            _KhachHang.MaLoaiKhachHang = LoaiKhachHang.GetLoaiKhachHang(1).MaLoaiKhachHang;
            _KhachHang.MaNhomKhachHang = NhomKhachHang.GetNhomKhachHang(2).MaNhomKhachHang;

            _NhomKhachHangList = NhomKhachHangList.GetNhomKhachHangList();
            NhomKhachHang _NhomKhachHang = NhomKhachHang.NewNhomKhachHang(0, "Thêm Mới...");
            _NhomKhachHangList.Insert(0, _NhomKhachHang);
            NhomKhachHangListBindingSource.DataSource = _NhomKhachHangList;
            ultracmbNhomKH.Value = NhomKhachHang.GetNhomKhachHang(2).TenNhomKhachHang;

            _phuongThucThanhToanList = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            phuongThucThanhToanListBindingSource.DataSource = _phuongThucThanhToanList;

            if (_KhachHang.HanMucTinDungList.Count == 0)
            {
                _HanMucTinDung = HanMucTinDung.NewHanMucTinDung();
                HanMucTinDungBindingSource.DataSource = _HanMucTinDung;
                _KhachHang.HanMucTinDungList.Add(_HanMucTinDung);
            }
            else
            {
                _HanMucTinDung = _KhachHang.HanMucTinDungList[0];
                HanMucTinDungBindingSource.DataSource = _HanMucTinDung;
                _KhachHang.HanMucTinDungList.Add(_HanMucTinDung);
            }

            _NguoiLienLacList = NguoiLienLacList.NewNguoiLienLacList();
            _NguoiLienLacList = _DoiTac.NguoiLienLacList;
            NguoiLienLaclistBindingSource.DataSource = _NguoiLienLacList;

            _DiaChi_DoiTacList = DiaChi_DoiTacList.NewDiaChi_DoiTacList();
            _DiaChi_DoiTacList = _DoiTac.DiaChi_DoiTacList;
            diaChiDoiTacListBindingSource.DataSource = _DiaChi_DoiTacList;

            _DoiTac_DienThoai_FaxList = DoiTac_DienThoai_FaxList.NewDoiTac_DienThoai_FaxList();
            _DoiTac_DienThoai_FaxList = _DoiTac.DoiTac_DienThoai_FaxList;
            doiTacDienThoaiFaxListBindingSource.DataSource = _DoiTac_DienThoai_FaxList;

            _TK_NganHangList = TK_NganHangList.NewTK_NganHangList();
            _TK_NganHangList = _DoiTac.TK_NganHangList;
            TK_NganHangListBindingSource.DataSource = _TK_NganHangList;

            _TKPhu_NganHangList = _DoiTac.tKPhu_NganHangList;
            TaiKhoanPhu_bindingSource.DataSource = _TKPhu_NganHangList;

            doiTacPhuongThucThanhToanListBindingSource.DataSource = _DoiTac.DoiTac_PhuongThucThanhToanList;

            _DoiTac_Website_EmailList = DoiTac_Website_EmailList.NewDoiTac_Website_EmailList();
            _DoiTac_Website_EmailList = _DoiTac.DoiTac_Website_EmailList;
            doiTacWebsiteEmailListBindingSource.DataSource = _DoiTac_Website_EmailList;

            _TinhThanhList = TinhThanhList.GetTinhThanhList();
            tinhThanhListBindingSource.DataSource = _TinhThanhList;

            TinhThanh_BindingSource.DataSource = _TinhThanhList;

            _QuocGiaList = QuocGiaList.GetQuocGiaList();
            quocGiaListBindingSource.DataSource = _QuocGiaList;

            _QuanHuyenList = QuanHuyenList.GetQuanHuyenList();
            QuanHuyen _QuanHuyen = QuanHuyen.NewQuanHuyen("Thêm mới ...", 0);

            _QuanHuyenList.Insert(0, _QuanHuyen);
            quanHuyenListBindingSource.DataSource = _QuanHuyenList;

            nganHangListBindingSource.DataSource = NhomNganHangList.GetNhomNganHangList();
            rdb_SuDung.Checked = true;

            #region MyRegion BS
            
            #endregion//BS
        }
        #endregion

        #region ChucNangKhoiTao
        public void ChucNangKhoiTao()
        {
            tlslblLuu.Enabled = false;
            tlslblTim.Enabled = false;
            tlslblXoa.Enabled = false;
            tlslblIn.Enabled = false;
            tlslblUndo.Enabled = false;
        }
        #endregion

        #region ChucNangThem
        public void ChucNangThem()
        {
            //tlslblLuu.Enabled = true;
            //tlslblXoa.Enabled = true;
            //tlslblUndo.Enabled = true;
            //tlslblTim.Enabled = false;
            //tlslblThem.Enabled = false;
            //tlslblIn.Enabled = false;
        }
        #endregion

        #region tlslblThem_Click
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            ChucNangThem();
            Them();
            dtmp_ngayCap.Enabled = true;
            cmbu_NoiCap.Enabled = true;
        }
        #endregion

        #region KiemTra
        bool KiemTra()
        {
            bool kq = true;
            //if (ultratxtMaKhachHang.Text == string.Empty)
            //{
            //    MessageBox.Show(this, util.nhapmakhachhang, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    kq = false;
            //    ultratxtMaKhachHang.Focus();
            //    return kq;
            //}
            if (ultratxtTenKhachHang.Text == string.Empty)
            {
                MessageBox.Show(this, util.nhaptenkhachhang, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
                ultratxtTenKhachHang.Focus();
                return kq;
            }
            //if (Convert.ToInt32(ultraCmbLoaiKH.Value) == 0)
            //{
            //    MessageBox.Show(this, "Chưa Chọn Loại Khách Hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    kq = false;
            //    ultraCmbLoaiKH.Focus();
            //    return kq;
            //}
            //if (Convert.ToInt32(ultracmbNhomKH.Value) == 0)
            //{
            //    MessageBox.Show(this, "Chưa Nhóm Khách Hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    kq = false;
            //    ultracmbNhomKH.Focus();
            //    return kq;
            //}
            //if (txtu_CMND.Text == string.Empty)
            //{
            //    MessageBox.Show(this, "Nhập Số CMND", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    kq = false;
            //    txtu_CMND.Focus();
            //    return kq;
            //}
            //if (Convert.ToDateTime(dtmp_ngayCap.Value) == DateTime.Today)
            //{
            //    MessageBox.Show(this, "Chọn Ngày Cấp CMND", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    kq = false;
            //    dtmp_ngayCap.Focus();
            //    return kq;
            //}
            //if (cmbu_NoiCap.Value==null )
            //{
            //    MessageBox.Show(this, "Chọn Nơi Cấp CMND", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    kq = false;
            //    cmbu_NoiCap.Focus();
            //    return kq;
            //}   


            //if (DoiTac.kiemtramasothue(_DoiTac.MaDoiTac, ultratxtMaSoThue.Text.Trim()))
            //{
            //    MessageBox.Show(this, "Mã Số Thuế Đã Bị Trùng Vui Lòng Kiểm Tra Lại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    kq = false;
            //    ultratxtMaSoThue.Focus();
            //    return kq;
            //}
            return kq;
        }
        #endregion

        #region KiemTraLuu
        bool KiemTraLuu()
        {
            bool kq = false;
            if (DoiTac.KiemTraMaKH(ultratxtMaKhachHang.Text) == 0)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Mã Khách Hàng Đã Tồn Tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
                ultratxtMaKhachHang.Text = "";
                ultratxtMaKhachHang.Focus();
                return kq;
            }
            if (rdb_SuDung.Checked == false)
            {
                rdb_SuDung.Checked = true;
                _DoiTac.TinhTrang = true;
            }
            return kq;
        }
        #endregion

        #region KiemTraCapNhat
        bool KiemTraCapNhat()
        {
            bool kq = false;
            if (DoiTac.KiemTraMaKH(ultratxtMaKhachHang.Text) <= 1)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Mã Khách Hàng Đã Tồn Tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
                ultratxtMaKhachHang.Text = "";
                ultratxtMaKhachHang.Focus();
                return kq;
            }
            return kq;
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            FocusofTKNH_textBox.Focus();
            textBoxFocus.Focus();
            if (KiemTra() == true)
            {
                if (_DoiTac.IsNew)
                {
                    if (KiemTraLuu() == true)
                    {
                        try
                        {
                            //_DoiTac.MaQLDoiTac = DoiTac.MaKhachHangTuDong(ERP_Library.Security.CurrentUser.Info.MaCongTy, 2);
                            DoiTacBindingSource.EndEdit();
                            _DoiTac.ApplyEdit();
                            _DoiTac.Save();
                            MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string tem = ex.Message;
                        }
                    }
                }
                else //là đối tượng cũ
                {
                    if (KiemTraCapNhat() == true)
                    {
                        try
                        {
                            DoiTacBindingSource.EndEdit();
                            _DoiTac.ApplyEdit();
                            _DoiTac.Save();
                            MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            string tem = ex.Message;
                        }
                    }
                }
                if (_NewForChungTu)
                {
                    _maDoiTacForLapChungTu = _DoiTac.MaDoiTac;
                    this.Close();
                }
            }
            else
            {
                return;
            }
        }
        #endregion

        #region frmKhachHang_Load
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            //ChucNangKhoiTao();
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tbpDiaChi)//
            {
                if (ultragrdDiaChi.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ultragrdDiaChi.DeleteSelectedRows();
            }
            if (tabControl1.SelectedTab == tbpEmail_Website)//
            {
                if (ultragrdEmail.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ultragrdEmail.DeleteSelectedRows();
            }
            if (tabControl1.SelectedTab == tbpLienLac)//
            {
                if (ultraGridDTFax.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ultraGridDTFax.DeleteSelectedRows();
                if (ultragrdLienlac.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ultragrdLienlac.DeleteSelectedRows();
            }
            if (tabControl1.SelectedTab == tbpNguoiLienLac)//
            {
                if (ultragrdNguoiLienLac.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ultragrdNguoiLienLac.DeleteSelectedRows();
            }
            if (tabControl1.SelectedTab == tbpTKNganHang)//
            {
                if (ultraGridTKNganHang.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ultraGridTKNganHang.DeleteSelectedRows();
            }
            if (tabControl1.SelectedTab == tabPhuongThucThanhToan)//
            {
                if (ultraGridPhuongThucThanhToan.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ultraGridPhuongThucThanhToan.DeleteSelectedRows();
            }//
        }
        #endregion

        #region ultragrdDiaChi_KeyDown
        private void ultragrdDiaChi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdDiaChi.UpdateData();
            }
        }
        #endregion

        #region ultraGridDTFax_KeyDown
        private void ultraGridDTFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultraGridDTFax.UpdateData();
            }
        }
        #endregion

        #region ultragrdEmail_KeyDown
        private void ultragrdEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdEmail.UpdateData();
            }
        }
        #endregion

        #region ultragrdNguoiLienLac_KeyDown
        private void ultragrdNguoiLienLac_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdNguoiLienLac.UpdateData();
            }
        }
        #endregion

        #region ultraGridTKNganHang_KeyDown
        private void ultraGridTKNganHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultraGridTKNganHang.UpdateData();
            }
        }
        #endregion

        #region ultraGridPhuongThucThanhToan_KeyDown
        private void ultraGridPhuongThucThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultraGridPhuongThucThanhToan.UpdateData();
            }
        }
        #endregion

        #region ultraCmbLoaiKH_AfterCloseUp
        private void ultraCmbLoaiKH_AfterCloseUp(object sender, EventArgs e)
        {
            if (ultraCmbLoaiKH.Value != null)
            {
                if (Convert.ToInt32(ultraCmbLoaiKH.Value) == 0)
                {
                    frmLoaiKhachHang _frmLoaiKhachHang = new frmLoaiKhachHang();
                    if (_frmLoaiKhachHang.ShowDialog() != DialogResult.OK)
                    {
                        _LoaiKhachHangList = LoaiKhachHangList.GetLoaiKhachHangList();
                        LoaiKhachHang _LoaiKhachHang = LoaiKhachHang.NewLoaiKhachHang(0, "Thêm Mới...");
                        _LoaiKhachHangList.Insert(0, _LoaiKhachHang);
                        LoaiKhachHangListbindingSource.DataSource = _LoaiKhachHangList;
                    }
                }
            }
        }
        #endregion

        #region ultracmbNhomKH_AfterCloseUp
        private void ultracmbNhomKH_AfterCloseUp(object sender, EventArgs e)
        {
            if (ultracmbNhomKH.ActiveRow != null)
            {
                if (Convert.ToInt32(ultracmbNhomKH.Value) == 0)
                {
                    frmNhomKhachHang _frmNhomKhachHang = new frmNhomKhachHang();
                    if (_frmNhomKhachHang.ShowDialog() != DialogResult.OK)
                    {
                        _NhomKhachHangList = NhomKhachHangList.GetNhomKhachHangList();
                        NhomKhachHang _NhomKhachHang = NhomKhachHang.NewNhomKhachHang(0, "Thêm Mới...");
                        _NhomKhachHangList.Insert(0, _NhomKhachHang);
                        NhomKhachHangListBindingSource.DataSource = _NhomKhachHangList;
                    }
                }
            }
        }
        #endregion

        #region tlslblUndo_Click
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            tlslblThem_Click(sender, e);
            tlslblTim.Enabled = true;
            tlslblThem.Enabled = true;
            tlslblIn.Enabled = true;
        }
        #endregion

        #region cmbu_QuocGia_ValueChanged
        private void cmbu_QuocGia_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbu_QuocGia.Value != null && Convert.ToInt32(cmbu_QuocGia.Value) != 0)
            //{

            //    int MaQuocGia = Convert.ToInt32(cmbu_QuocGia.Value);
            //    _TinhThanhList = TinhThanhList.GetQuocGiaist(MaQuocGia);
            //    TinhThanh _TinhThanh = TinhThanh.NewTinhThanh();
            //    _TinhThanh.TenTinhThanh = "Thêm Dòng Mới...";
            //    _TinhThanhList.Insert(0, _TinhThanh);
            //    tinhThanhListBindingSource.DataSource = _TinhThanhList;
            //}
            //else
            //{
            //    _TinhThanhList = TinhThanhList.NewTinhThanhList();
            //    TinhThanh _TinhThanh = TinhThanh.NewTinhThanh();
            //    _TinhThanh.TenTinhThanh = "Thêm Dòng Mới...";
            //    _TinhThanhList.Insert(0, _TinhThanh);
            //    tinhThanhListBindingSource.DataSource = _TinhThanhList;
            //}
        }
        #endregion

        #region cmbu_TinhThanh_ValueChanged
        private void cmbu_TinhThanh_ValueChanged(object sender, EventArgs e)
        {
            //frmDanhSachKhachHang f = new frmDanhSachKhachHang();
            //f.Show();
        }
        #endregion

        #region txt_cm_Leave
        private void txt_cm_Leave(object sender, EventArgs e)
        {
            if (txtu_CMND.Value != null)
            {
                //if (txtu_CMND.Value.ToString().Length > 9)
                //{
                //    MessageBox.Show(this, "CMND không được nhiều hơn 9 số", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    txtu_CMND.Focus();
                //}
                dtmp_ngayCap.Enabled = true;
                cmbu_NoiCap.Enabled = true;
            }
            else
            {
                dtmp_ngayCap.Enabled = false;
                cmbu_NoiCap.Enabled = false;
            }
        }
        #endregion

        #region tlslblTim_Click
        private void tlslblTim_Click(object sender, EventArgs e)
        {
            frmDanhSachKhachHang f = new frmDanhSachKhachHang();
            f.Show();
        }
        #endregion

        #region ultragrdDiaChi_CellChange
        private void ultragrdDiaChi_CellChange(object sender, CellEventArgs e)
        {
            if (ultragrdDiaChi.Rows.Count != 0)
            {
                ultragrdDiaChi.ActiveRow.Cells["QuocGia"].Value = "Việt Nam";
                ultragrdDiaChi.ActiveRow.Cells["TinhTP"].Value = "TP.Hồ Chí Minh";
            }
        }
        #endregion

        #region InitializeLayout

        #region ultragrdDiaChi_InitializeLayout
        private void ultragrdDiaChi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //màu và font chữ
            foreach (UltraGridColumn col in this.ultragrdDiaChi.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            this.ultragrdDiaChi.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.ultragrdDiaChi.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["MaDiaChi"].Hidden = true;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["TenDiaChiChung"].Hidden = true;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["MaQuocGia"].Hidden = true;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["MaQuanHuyen"].Hidden = true;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;

            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["Active"].Header.Caption = "Sử Dụng Chính";
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["TenDiaChi"].Header.Caption = "Địa Chỉ";
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["TenDiaChi"].Width = 200;

            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["QuanHuyen"].Header.Caption = "Quận Huyện";
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["QuanHuyen"].Width = 130;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["TinhTP"].Header.Caption = "Tỉnh / TP";
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["TinhTP"].Width = 130;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["QuocGia"].Header.Caption = "Quốc Gia";
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["QuocGia"].Width = 130;

            //ultragrdDiaChi.DisplayLayout.Bands[0].Columns["MaQuanHuyen"].EditorControl = cmbu_QuanHuyen;

            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["TenDiaChi"].Header.VisiblePosition = 0;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["QuanHuyen"].Header.VisiblePosition = 1;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["TinhTP"].Header.VisiblePosition = 2;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["QuocGia"].Header.VisiblePosition = 3;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["Active"].Header.VisiblePosition = 4;

            //thêm 1 dòng mới
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);

        }
        #endregion

        #region ultragrdLienlac_InitializeLayout
        private void ultragrdLienlac_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //tiêu đề
            ultragrdLienlac.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            ultragrdLienlac.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultragrdLienlac.DisplayLayout.Bands[0].Columns["MaDienThoaiFax"].Hidden = true;
            ultragrdLienlac.DisplayLayout.Bands[0].Columns["SoDTFax"].Header.Caption = "Số ĐT/Fax";
            ultragrdLienlac.DisplayLayout.Bands[0].Columns["SoDTFax"].Width = 250;
            ultragrdLienlac.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Fax";

            ultragrdLienlac.DisplayLayout.Bands[0].Columns["SoDTFax"].Header.VisiblePosition = 0;
            ultragrdLienlac.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 1;
            //màu và font chữ
            foreach (UltraGridColumn col in this.ultragrdLienlac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            //màu nền
            this.ultragrdLienlac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.ultragrdLienlac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region ultragrdEmail_InitializeLayout
        private void ultragrdEmail_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //tiêu đề
            ultragrdEmail.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            ultragrdEmail.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultragrdEmail.DisplayLayout.Bands[0].Columns["MaWebsiteEmail"].Hidden = true;
            ultragrdEmail.DisplayLayout.Bands[0].Columns["DiaChi"].Header.Caption = "Địa Chỉ";
            ultragrdEmail.DisplayLayout.Bands[0].Columns["DiaChi"].Width = 250;
            ultragrdEmail.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Email";

            ultragrdEmail.DisplayLayout.Bands[0].Columns["DiaChi"].Header.VisiblePosition = 0;
            ultragrdEmail.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 1;
            //màu và font chữ
            foreach (UltraGridColumn col in this.ultragrdEmail.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            this.ultragrdEmail.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.ultragrdEmail.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region ultragrdNguoiLienLac_InitializeLayout
        private void ultragrdNguoiLienLac_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //tiêu đề
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["MaNguoiLienLac"].Hidden = true;
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.Caption = "Tên Người Liên Lạc";
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Width = 150;
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.Caption = "Điện Thoại";
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Width = 150;
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.Caption = "Email";
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Width = 150;

            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["TenNguoiLienLac"].Header.VisiblePosition = 0;
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["DienThoai"].Header.VisiblePosition = 1;
            ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns["Email"].Header.VisiblePosition = 2;
            //màu và font chữ
            foreach (UltraGridColumn col in this.ultragrdNguoiLienLac.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            this.ultragrdNguoiLienLac.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.ultragrdNguoiLienLac.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region ultraCmbLoaiKH_InitializeLayout
        private void ultraCmbLoaiKH_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //tiêu đề
            ultraCmbLoaiKH.DisplayLayout.Bands[0].Columns["MaLoaiKhachHang"].Hidden = true;
            ultraCmbLoaiKH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Loại Khách Hàng";
            ultraCmbLoaiKH.DisplayLayout.Bands[0].Columns["TenLoaiKhachHang"].Header.Caption = "Tên Loại Khách Hàng";
            ultraCmbLoaiKH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultraCmbLoaiKH.DisplayLayout.Bands[0].Columns["TenLoaiKhachHang"].Header.VisiblePosition = 1;

            //màu và font chữ
            foreach (UltraGridColumn col in this.ultraCmbLoaiKH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.ultraCmbLoaiKH.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.ultraCmbLoaiKH.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region ultracmbNhomKH_InitializeLayout
        private void ultracmbNhomKH_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //tiêu đề
            ultracmbNhomKH.DisplayLayout.Bands[0].Columns["MaNhomKhachHang"].Hidden = true;
            ultracmbNhomKH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Nhóm Khách Hàng";
            ultracmbNhomKH.DisplayLayout.Bands[0].Columns["TenNhomKhachHang"].Header.Caption = "Tên Nhóm Khách Hàng";
            ultracmbNhomKH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultracmbNhomKH.DisplayLayout.Bands[0].Columns["TenNhomKhachHang"].Header.VisiblePosition = 1;

            //màu và font chữ
            foreach (UltraGridColumn col in this.ultracmbNhomKH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.ultracmbNhomKH.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.ultracmbNhomKH.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region ultraGridDTFax_InitializeLayout
        private void ultraGridDTFax_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //tiêu đề
            ultraGridDTFax.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            ultraGridDTFax.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultraGridDTFax.DisplayLayout.Bands[0].Columns["MaDienThoaiFax"].Hidden = true;
            ultraGridDTFax.DisplayLayout.Bands[0].Columns["SoDTFax"].Header.Caption = "Số ĐT/Fax";
            ultraGridDTFax.DisplayLayout.Bands[0].Columns["SoDTFax"].Width = 250;
            ultraGridDTFax.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Fax";
            ultraGridDTFax.DisplayLayout.Bands[0].Columns["Active"].Header.Caption = "Sử Dụng Chính";

            ultraGridDTFax.DisplayLayout.Bands[0].Columns["SoDTFax"].Header.VisiblePosition = 0;
            ultraGridDTFax.DisplayLayout.Bands[0].Columns["Loai"].Header.VisiblePosition = 1;
            ultraGridDTFax.DisplayLayout.Bands[0].Columns["Active"].Header.VisiblePosition = 2;

            //màu và font chữ
            foreach (UltraGridColumn col in this.ultraGridDTFax.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            this.ultraGridDTFax.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.ultraGridDTFax.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region ultraGridTKNganHang_InitializeLayout
        private void ultraGridTKNganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //tiêu đề
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaTKNganHang"].Hidden = true;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["TenNhomNganHang"].Hidden = true;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["SoTK"].Header.Caption = "Số Tài Khoản";
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["SoTK"].Header.VisiblePosition = 3;

            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.Caption = "Tên Nhóm Ngân Hàng";
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].EditorControl = cmbu_NganHang;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Width = 200;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.VisiblePosition = 0;

            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 200;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 1;

            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.Caption = "Tỉnh Thành";
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaTinhThanh"].EditorControl = cmbu_TinhThanhNganHang;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Width = 120;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.VisiblePosition = 2;

            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["ThongTinKhac"].Header.Caption = "Thông tin khác";
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["ThongTinKhac"].EditorControl = txt_ThongTinKhac;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["ThongTinKhac"].Width = 150;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["ThongTinKhac"].Header.VisiblePosition = 4;
            ultraGridTKNganHang.DisplayLayout.Bands[0].Columns["ThongTinKhac"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            //màu và font chữ
            foreach (UltraGridColumn col in this.ultraGridTKNganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            this.ultraGridTKNganHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.ultraGridTKNganHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region ultraGridPhuongThucThanhToan_InitializeLayout
        private void ultraGridPhuongThucThanhToan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //tiêu đề
            ultraGridPhuongThucThanhToan.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            ultraGridPhuongThucThanhToan.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            ultraGridPhuongThucThanhToan.DisplayLayout.Bands[0].Columns["MaPhuongThucThanhToan"].Header.Caption = "Phương Thức Thanh Toán";
            ultraGridPhuongThucThanhToan.DisplayLayout.Bands[0].Columns["MaPhuongThucThanhToan"].Header.VisiblePosition = 0;
            ultraGridPhuongThucThanhToan.DisplayLayout.Bands[0].Columns["MaPhuongThucThanhToan"].EditorControl = cmbu_MaPhuongThucTT;

            //màu và font chữ
            foreach (UltraGridColumn col in this.ultraGridPhuongThucThanhToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            this.ultraGridPhuongThucThanhToan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.ultraGridPhuongThucThanhToan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region cmbu_NoiCap_InitializeLayout
        private void cmbu_NoiCap_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["MaQuocGia"].Hidden = true;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Hidden = true;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["MaKhuVuc"].Hidden = true;

            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.VisiblePosition = 0;
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            cmbu_NoiCap.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 1;
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NoiCap.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            this.cmbu_NoiCap.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_NoiCap.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region cmbu_NganHang_InitializeLayout
        private void cmbu_NganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_NganHang.DisplayLayout.Bands[0],
                new string[2] { "TenNhomNganHang", "ChuVietTat" },
                new string[2] { "Tên ngân hàng", "Chữ viết tắt" },
                new int[2] { 300, 130 },
                new Control[2] { null, null },
                new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[2] { false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_NganHang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            FilterCombo filter = new FilterCombo(ultraGridTKNganHang, "MaNganHang", "TenNhomNganHang");
        }
        #endregion

        #region cmbu_QuanHuyen_InitializeLayout
        private void cmbu_QuanHuyen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_QuanHuyen.DisplayLayout.Bands[0].Columns["MaQuanHuyen"].Hidden = true;
            cmbu_QuanHuyen.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = true;
            cmbu_QuanHuyen.DisplayLayout.Bands[0].Columns["TenQuanHuyen"].Header.Caption = "Tên Quận Huyện";
            cmbu_QuanHuyen.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;

            cmbu_QuanHuyen.DisplayLayout.Bands[0].Columns["TenQuanHuyen"].Header.VisiblePosition = 0;
            cmbu_QuanHuyen.DisplayLayout.Bands[0].Columns["TenQuanHuyen"].Width = 138;

            //màu và font chữ
            foreach (UltraGridColumn col in this.cmbu_QuanHuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            }
            //màu nền
            this.cmbu_QuanHuyen.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.cmbu_QuanHuyen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            FilterCombo filter = new FilterCombo(ultraGridTKNganHang, "MaQuanHuyen", "TenQuanHuyen");
        }
        #endregion

        #endregion

        private void cmbu_QuanHuyen_AfterCloseUp(object sender, EventArgs e)
        {
            if ((int)cmbu_QuanHuyen.Value == 0 && _flag != 0)
            {
                frmQuanHuyen _frmQuanHuyen = new frmQuanHuyen();
                if (_frmQuanHuyen.ShowDialog(this) != DialogResult.OK)
                {
                    _QuanHuyenList = QuanHuyenList.GetQuanHuyenList();
                    QuanHuyen _QuanHuyen = QuanHuyen.NewQuanHuyen("Thêm mới ...", 0);
                    _QuanHuyenList.Insert(0, _QuanHuyen);
                    quanHuyenListBindingSource.DataSource = _QuanHuyenList;
                }
                _flag++;
            }
        }

        private void cmbu_QuanHuyen_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_QuanHuyen.Value != null)
            {
                if ((int)cmbu_QuanHuyen.Value == 0 && _flag != 0)
                {
                    frmQuanHuyen _frmQuanHuyen = new frmQuanHuyen();
                    if (_frmQuanHuyen.ShowDialog(this) != DialogResult.OK)
                    {
                        _QuanHuyenList = QuanHuyenList.GetQuanHuyenList();
                        QuanHuyen _QuanHuyen = QuanHuyen.NewQuanHuyen("Thêm mới ...", 0);
                        _QuanHuyenList.Insert(0, _QuanHuyen);
                        quanHuyenListBindingSource.DataSource = _QuanHuyenList;
                    }
                }
                _flag++;
            }
        }

        private void cmbu_QuanHuyen_Click(object sender, EventArgs e)
        {
            _flag = 0;
        }

        private void ultragrdDiaChi_AfterRowActivate(object sender, EventArgs e)
        {
            _flag = 0;
        }

        private void frmKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Khach Hang", "Help_BanHang.chm");
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Khach Hang", "Help_BanHang.chm");
        }

        private void txt_ThongTinKhac_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            if (ultraGridTKNganHang.ActiveRow != null)
            {
                TK_NganHang item = (ERP_Library.TK_NganHang)ultraGridTKNganHang.ActiveRow.ListObject;
                ThongTinNganHangChildList thongtin = ThongTinNganHangChildList.GetChungTu_GiayBanNgoaiTeChildList(item.MaTKNganHang);
                frmThongTinNganHang frm = new frmThongTinNganHang(thongtin);
                frm.ShowDialog();

                //cập nhật lại thông tin danh sách
                item.ThongTinNganHangList = frm._thongtinList;
                _DoiTac.ApplyEdit();
                _DoiTac.Save();

                //Load lại danh sách
                _TK_NganHangList = _DoiTac.TK_NganHangList;
                TK_NganHangListBindingSource.DataSource = _TK_NganHangList; ;
            }
        }

        private void grd_TaiKhoanPhu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //tiêu đề
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["maTKPhu"].Hidden = true;
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;

            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số Tài Khoản";
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 5;
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 120;

            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.Caption = "Nhóm Ngân Hàng";
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["MaNganHang"].EditorControl = cmbu_NganHang;
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["MaNganHang"].Width = 180;
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["MaNganHang"].Header.VisiblePosition = 1;

            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["TenDoiTacPhu"].Header.Caption = "Đối tác phụ";
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["TenDoiTacPhu"].Width = 200;
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["TenDoiTacPhu"].Header.VisiblePosition = 0;

            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 180;
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 3;

            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.Caption = "Tỉnh Thành";
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["MaTinhThanh"].EditorControl = cmbu_TinhThanhNganHang;
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Width = 120;
            grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.VisiblePosition = 4;

            //màu và font chữ
            foreach (UltraGridColumn col in this.grd_TaiKhoanPhu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            this.grd_TaiKhoanPhu.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            this.grd_TaiKhoanPhu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }

        #region BS

        private void InitForm()
        {
            bindingSource_DoiTuongTheoDoi.DataSource = typeof(ERP_Library.DoiTuongTheoDoiList);
            tblTaiKhoanBindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);
        }

        private void LoadDatasource()
        {
                tblTaiKhoanBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
                bindingSource1_NhanVien.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(ERP_Library.Security.CurrentUser.Info.MaBoPhan, false);
                DesignGrid();
        }

        private void DesignGrid()
        {
            gridControl1.DataSource = bindingSource_DoiTuongTheoDoi;
            HamDungChung.InitGridViewDev(gridView1, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaTaiKhoan", "MaNguoiPhuTrachChinh" },
                                new string[] { "Tài khoản theo dõi", "Người phụ trách chính"},
                                             new int[] { 100, 100});


            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaTaiKhoan", "MaNguoiPhuTrachChinh"}, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.NewRowGridViewDev(gridView1, NewItemRowPosition.Bottom);

            Utils.GridUtils.SetSTTForGridView(gridView1, 40);//M

            //MaTaiKhoan
            RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            TaiKhoanNo_GrdLU.DataSource = tblTaiKhoanBindingSource;
            TaiKhoanNo_GrdLU.DisplayMember = "SoHieuTK";
            TaiKhoanNo_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaTaiKhoan", TaiKhoanNo_GrdLU);
            //
            //
            //MaDoiTuong
            RepositoryItemGridLookUpEdit DoiTuongNo_grdLU = new RepositoryItemGridLookUpEdit();
            DoiTuongNo_grdLU.DataSource = bindingSource1_NhanVien;
            DoiTuongNo_grdLU.DisplayMember = "TenNhanVien";
            DoiTuongNo_grdLU.ValueMember = "MaNhanVien";
            HamDungChung.InitRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, new string[] { "TenNhanVien", "MaQLNhanVien", "TenBoPhan" }, new string[] { "Nhân viên", "Mã nhân viên", "thuộc bộ phận" }, new int[] { 100, 90, 100 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaNguoiPhuTrachChinh", DoiTuongNo_grdLU);

            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            ////this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            ////this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            ////this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);

            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);
        }

        private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
        {
            if (clickButtoan)
            {
                if (handlefocus)
                {
                    if (e.FocusedColumn.FieldName == "MaTaiKhoan" || e.FocusedColumn.FieldName == "MaNguoiPhuTrachChinh")
                    {
                        gridView1.ShowEditor();
                        ((GridLookUpEdit)gridView1.ActiveEditor).ShowPopup();
                    }
                }
            }
            handlefocus = true;
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            clickButtoan = true;
        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                gridView1.PostEditor();
                gridView1.UpdateCurrentRow();
                handlefocus = false;//
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

                if (gridView1.RowCount > 0)
                {
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = GridControl.NewItemRowHandle;
                }
            }
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

           

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.GetSelectedRows().Length > 0)
                {
                    if (XtraMessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView1.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        gridView1.DeleteSelectedRows();
                    }
                }
            }

        }


        #endregion//BS

    }
}
