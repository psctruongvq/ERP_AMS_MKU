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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace PSC_ERP
{
    public partial class frmNhaCungCapCustomize : Form
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
        List<LoaiDoiTacKhachHang> _LoaiDoiTacKhachHangList;
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
        private int _loaiDoiTac=1;//Nha Cung Cap

        #endregion

        #region Constructor
        public frmNhaCungCapCustomize()
        {
            InitializeComponent();
            InitForm();
            LoadDatasource();
            Them();
            
        }

        public frmNhaCungCapCustomize(bool newForChungTu)
        {
            _NewForChungTu = newForChungTu;
            InitializeComponent();
            InitForm();
            LoadDatasource();
            Them();
        }

        public frmNhaCungCapCustomize(DoiTac maDoiTac)
        {
            InitializeComponent();
            InitForm();
            LoadDatasource();
            KhoiTao(maDoiTac);
        }

        public frmNhaCungCapCustomize(string maDoiTacString)
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

        public frmNhaCungCapCustomize(object maDoiTacString)
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
            _loaiDoiTac = _DoiTac.LoaiDoiTac;
            DoiTacBindingSource.DataSource = _DoiTac;

            #region MyRegion BS
            bindingSource_DoiTuongTheoDoi.DataSource = _DoiTac.TheoDoiTaiKhoanDoiTuongList;
            #endregion//BS

            

            //_NhomKhachHangList = NhomKhachHangList.GetNhomKhachHangList();
            //NhomKhachHangListBindingSource.DataSource = _NhomKhachHangList;

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
            _DoiTac = DoiTac.NewDoiTac(DoiTac.MaKhachHangTuDong( _loaiDoiTac));
            _DoiTac.KhachHang.MaLoaiKhachHang = 1;
            _DoiTac.KhachHang.MaNhomKhachHang = 1;
            DoiTacBindingSource.DataSource = _DoiTac;
            #region MyRegion BS
            bindingSource_DoiTuongTheoDoi.DataSource = _DoiTac.TheoDoiTaiKhoanDoiTuongList;
            #endregion//BS
            _DoiTac.LoaiDoiTac = _loaiDoiTac;

            //_LoaiDoiTacKhachHangList = LoaiKhachHangList.GetLoaiKhachHangList();
            //LoaiKhachHang _LoaiKhachHang = LoaiKhachHang.NewLoaiKhachHang(0, "Thêm Mới...");
            //_LoaiDoiTacKhachHangList.Insert(0, _LoaiKhachHang);
            //LoaiKhachHangDoiTacListbindingSource.DataSource = _LoaiDoiTacKhachHangList;

            _KhachHang = _DoiTac.KhachHang;
            KhachHangBindingSource.DataSource = _KhachHang;

            _KhachHang.MaLoaiKhachHang = LoaiKhachHang.GetLoaiKhachHang(1).MaLoaiKhachHang;
            _KhachHang.MaNhomKhachHang = NhomKhachHang.GetNhomKhachHang(2).MaNhomKhachHang;

            _NhomKhachHangList = NhomKhachHangList.GetNhomKhachHangList();
            NhomKhachHang _NhomKhachHang = NhomKhachHang.NewNhomKhachHang(0, "Thêm Mới...");
            _NhomKhachHangList.Insert(0, _NhomKhachHang);
            NhomKhachHangListBindingSource.DataSource = _NhomKhachHangList;
            //ultracmbNhomKH.Value = NhomKhachHang.GetNhomKhachHang(2).TenNhomKhachHang;

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
            //dtmp_ngayCap.Enabled = true;
            //cmbu_NoiCap.Enabled = true;
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
            //if (DoiTac.KiemTraMaKH(ultratxtMaKhachHang.Text) == 0)
            //{
            //    kq = true;
            //}
            //else
            //{
            //    MessageBox.Show(this, "Mã Nhà Cung Cấp Đã Tồn Tại", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    kq = false;
            //    ultratxtMaKhachHang.Text = "";
            //    ultratxtMaKhachHang.Focus();
            //    return kq;
            //}
            //if (rdb_SuDung.Checked == false)
            //{
            //    rdb_SuDung.Checked = true;
            //    _DoiTac.TinhTrang = true;
            //}
            return kq;

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
            //return kq;
        }
        #endregion

        #region KiemTraLuu
        bool KiemTraLuu()
        {
            bool kq = false;
            if (_DoiTac.MaSoThue.Length > 0 && DoiTac.KiemTraMST(ultratxtMaSoThue.Text)==0)//kiểm tra trùng MST
            {
                kq = true;
            }
            else
            {
                if(_DoiTac.MaSoThue.Length == 0)
                    MessageBox.Show(this, "Mã Số Thuế Đang Trống ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show(this, "Mã Số Thuế Đã Tồn Tại ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
                ultratxtMaSoThue.Focus();
                return kq;
            }
            if (_DoiTac.DiaChi_DoiTacList.Count > 0)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Địa Chỉ Đối Tác Đang Trống ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
                return kq;
            }
            if (_DoiTac.DoiTac_DienThoai_FaxList.Count > 0)
            {
                kq = true;
            }
            else
            {
                MessageBox.Show(this, "Điện Thoại Đối Tác Đang Trống ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kq = false;
                return kq;
            }

            if (DoiTac.KiemTraMaKH(ultratxtMaKhachHang.Text) == 0  )
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
            //if (rdb_SuDung.Checked == false)
            //{
            //    rdb_SuDung.Checked = true;
            //    _DoiTac.TinhTrang = true;
            //}
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
          
            textBoxFocus.Focus();
            if (KiemTra() == true)
            {
                if (_DoiTac.IsNew)
                {
                    if (KiemTraLuu() == true)
                    {
                        try
                        {
                            //_DoiTac.MaQLDoiTac = DoiTac.MaKhachHangTuDong(ERP_Library.Security.CurrentUser.Info.MaCongTy, _loaiDoiTac);
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
        private void PhanQuyenThemSuaXoa()
        {
            PhanQuyenSuDungForm _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(ERP_Library.Security.CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
           
                tlslblThem.Enabled = _phanQuyen.Them;
            
                tlslblLuu.Enabled = _phanQuyen.Sua;
            
                tlslblXoa.Enabled = _phanQuyen.Xoa;
        }

        #region frmNhaCungCapCustomize_Load
        private void frmNhaCungCapCustomize_Load(object sender, EventArgs e)
        {
            //ChucNangKhoiTao();
            PhanQuyenThemSuaXoa();

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

            //Ẩn Cột TinhTP, QuocGia, QuanHuyen
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["TinhTP"].Hidden = true;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["QuocGia"].Hidden = true;
            ultragrdDiaChi.DisplayLayout.Bands[0].Columns["QuanHuyen"].Hidden = true;
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

        #region LoaiKhachHangDoiTac_ultCombo_InitializeLayout
        //private void LoaiKhachHangDoiTac_ultCombo_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        //{
        //    //tiêu đề
        //    LoaiKhachHangDoiTac_ultCombo.DisplayLayout.Bands[0].Columns["Ma"].Hidden = true;
        //    LoaiKhachHangDoiTac_ultCombo.DisplayLayout.Bands[0].Columns["TenLoai"].Header.Caption = "Thuộc loại";
        //    LoaiKhachHangDoiTac_ultCombo.DisplayLayout.Bands[0].Columns["TenLoai"].Header.VisiblePosition = 0;

        //    //màu và font chữ
        //    foreach (UltraGridColumn col in this.LoaiKhachHangDoiTac_ultCombo.DisplayLayout.Bands[0].Columns)
        //    {
        //        col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
        //        col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
        //        col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
        //    }
        //    this.LoaiKhachHangDoiTac_ultCombo.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        //    this.LoaiKhachHangDoiTac_ultCombo.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        //}
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

        private void frmNhaCungCapCustomize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Khach Hang", "Help_BanHang.chm");
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                tlslblLuu.PerformClick();
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            Main.frmMain.LoadHelp(this, "Khach Hang", "Help_BanHang.chm");
        }

        private void txt_ThongTinKhac_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {

        }

       

        #region BS

        private void InitForm()
        {
            bindingSource_DoiTuongTheoDoi.DataSource = typeof(ERP_Library.DoiTuongTheoDoiList);
            tblTaiKhoanBindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);
            LoaiKhachHangDoiTacListbindingSource.DataSource = typeof(LoaiDoiTacKhachHang);
        }

        private void LoadDatasource()
        {
            tblTaiKhoanBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            bindingSource1_NhanVien.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(ERP_Library.Security.CurrentUser.Info.MaBoPhan, false);
            _LoaiDoiTacKhachHangList = LoaiDoiTacKhachHang.CreateListLoaiDoiTacKhachHang();
            LoaiKhachHangDoiTacListbindingSource.DataSource = _LoaiDoiTacKhachHangList;
            DesignGrid();
        }

        private void DesignGrid()
        {



            //MaTaiKhoan
            RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            TaiKhoanNo_GrdLU.DataSource = tblTaiKhoanBindingSource;
            TaiKhoanNo_GrdLU.DisplayMember = "SoHieuTK";
            TaiKhoanNo_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);

            //
            //
            //MaDoiTuong
            RepositoryItemGridLookUpEdit DoiTuongNo_grdLU = new RepositoryItemGridLookUpEdit();
            DoiTuongNo_grdLU.DataSource = bindingSource1_NhanVien;
            DoiTuongNo_grdLU.DisplayMember = "TenNhanVien";
            DoiTuongNo_grdLU.ValueMember = "MaNhanVien";
            HamDungChung.InitRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuongNo_grdLU, new string[] { "TenNhanVien", "MaQLNhanVien", "TenBoPhan" }, new string[] { "Nhân viên", "Mã nhân viên", "thuộc bộ phận" }, new int[] { 100, 90, 100 }, false);


           

        }

     

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            clickButtoan = true;
        }

       

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

           

        }

       


        #endregion//BS

        private void LoaiKhachHangDoiTac_ultCombo_Leave(object sender, EventArgs e)
        {
            //_loaiDTKHLeave = true;
            //if (LoaiKhachHangDoiTac_ultCombo.Value != null)
            //{
            //    if ((int)cmbu_QuanHuyen.Value == 0 )
            //    {
            //    }
            //}
        }

        private void ultratxtMaSoThue_Validated(object sender, EventArgs e)
        {
            if (DoiTac.kiemtramasothue(_DoiTac.MaDoiTac, ultratxtMaSoThue.Text) )
            {
                MessageBox.Show("Lưu ý! mã số thuế " + ultratxtMaSoThue.Text + " đã tồn tại trong đối tượng khác!");
            }
        }

        private void btnCheckAPI_MST_Click(object sender, EventArgs e)
        {
            string _url = "https://thongtindoanhnghiep.co/api/company/" + ultratxtMaSoThue.Text;
                      
            var client = new RestClient(string.Format("{0}", _url));
            var request = new RestRequest(Method.GET);           
            request.RequestFormat = DataFormat.Json;
            IRestResponse response = client.Execute(request);
            string kq = response.Content.ToString();
            JToken data = JToken.Parse(response.Content);

            string strTenNhaCungCap = "";
            string strDiaChi = "";
            string strID = "";
            if (data.HasValues)
            {
                strID = data.Value<string>("ID");
                strTenNhaCungCap = data.Value<string>("Title");
               strDiaChi = data.Value<string>("DiaChiCongTy");              
            }

            if (strID == "" || strID == "0")
            {
                MessageBox.Show("Mã số thuế không hợp lệ");
            }
            else
            {
                ultratxtTenKhachHang.Text = strTenNhaCungCap;
                _DoiTac.TenDoiTac = strTenNhaCungCap;

                DiaChi_DoiTac dcdt = DiaChi_DoiTac.NewDiaChi_DoiTac();
                dcdt.TenDiaChi = strDiaChi;
                _DoiTac.DiaChi_DoiTacList.Add(dcdt);

            }
        }
    }
}
