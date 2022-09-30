using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;

namespace PSC_ERPNew.Main
{
    public partial class frmHoaDon : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmHoaDon singleton_ = null;
        public static frmHoaDon Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmHoaDon();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner);
        }

        #endregion
        //Private Static Field
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        //Public Static Field
        #region Public Static Field

        #endregion
        //Private Static Property
        #region Private Static Property

        #endregion
        //Public Static Property
        #region Public Static Property

        #endregion
        //Static Constructor
        #region Static Constructor

        #endregion

        //Private Static Function
        #region Private Static Function

        #endregion

        //Public Static Function
        #region Public Static Function

        #endregion

        //Private Member field
        #region Private Member field
        HoaDonTaiSan_DerivedFactory _hoaDonTaiSan_DerivedFactory = HoaDonTaiSan_DerivedFactory.New();
        //IQueryable<tblHoaDon> _hoaDonList = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        Boolean _yeuCauTaoHoaDonRongKhiFormLoad = false;
        Boolean _coVAT = false;
        tblHoaDon _currentHoaDon = null;
        tblChungTu _chungTu = null;
        tblButToan _butToan = null;
        tblHoaDon_DoiTac _hoaDon_DoiTac = null;
        List<tblHoaDon> _hoaDonList = new List<tblHoaDon>();
        #endregion

        //Public Member field
        #region Public Member field

        #endregion

        //Public Member Property
        #region Public Member Property
        public Int64 MaHoaDon
        {
            get { return _currentHoaDon.MaHoaDon; }
        }
        #endregion

        //Member Constructor
        #region Member Constructor

        public frmHoaDon()
        {
            InitializeComponent();
        }
        public frmHoaDon(tblChungTu chungTu, tblButToan butToan, Int64 maHoaDon)
        {
            InitializeComponent();
            _chungTu = chungTu;
            _butToan = butToan;
            _hoaDonTaiSan_DerivedFactory = HoaDonTaiSan_DerivedFactory.New();
            _currentHoaDon = _hoaDonTaiSan_DerivedFactory.Get_HoaDon_ByMaHoaDon(maHoaDon);
            _hoaDonList.Add(_currentHoaDon);
            _yeuCauTaoHoaDonRongKhiFormLoad = false;
        }
        public frmHoaDon(tblChungTu chungTu, tblButToan butToan, Boolean coVAT)
        {
            InitializeComponent();
            _yeuCauTaoHoaDonRongKhiFormLoad = true;
            _chungTu = chungTu;
            _butToan = butToan;
            _coVAT = coVAT;


        }

        #endregion



        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {

            //_hoaDonList = _hoaDonTaiSan_DerivedFactory.GetAll();
            Thread thr = new Thread(() =>
               {
                   if (this.InvokeRequired)
                   {
                       PSC_ERP_Common.Delegate.VoidDelegate dele = new PSC_ERP_Common.Delegate.VoidDelegate(this.LoadDoiTac);
                       this.Invoke(dele);
                   }
                   else
                   {
                       this.LoadDoiTac();
                   }
               }
               );
            thr.Start();



            GanBindingSource();
        }
        void LoadDoiTac()
        {
            _doiTacList = DoiTac_Factory.New().GetAll();
            tblDoiTacBindingSource.DataSource = _doiTacList;
        }
        private void GanBindingSource()
        {
            tblPhuongThucThanhToanBindingSource.DataSource = PhuongThucThanhToan_Factory.New().GetAll();
            thueSuatVATBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.ThueSuatVAT.ThueSuatVATList;
            tinhTrangHoaDonBindingSource.DataSource = PSC_ERP_Business.Main.Predefined.TinhTrangHoaDon.TinhTrangHoaDonList;



            tblHoaDonBindingSource.DataSource = _hoaDonList;
            tblHoaDonBindingSource.MoveLast();
            tblDoiTacBindingSource.DataSource = _doiTacList;
            loaiHoaDonBindingSource.DataSource = LoaiHoaDon.LoaiHoaDonList;
            /////////////////////////
            //if (_currentHoaDon != null && _currentHoaDon.tblHoaDon_DoiTac.FirstOrDefault() == null)
            //{
            //    //tạo mới hóa đơn đối tác, chứa một số thông tin của đối tác chọn từ danh mục hoặc ngoài danh mục
            //    tblHoaDon_DoiTac hoaDonDoiTac = HoaDon_DoiTac_Factory.New().CreateAloneObject();
            //    _currentHoaDon.tblHoaDon_DoiTac.Add(hoaDonDoiTac);
            //}
            if (_currentHoaDon != null)
                tblHoaDonDoiTacBindingSource_Single.DataSource = _currentHoaDon.tblHoaDon_DoiTac.FirstOrDefault();
        }
        private Boolean Save()
        {
            this.txtBlackHole.Focus();
            if (DuocPhepLuu())
                try
                {
                    _hoaDonTaiSan_DerivedFactory.SaveChanges(BusinessCodeEnum.TSCD_HoaDon.ToString());//lưu lại
                    //
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful();
                }
            return false;
        }
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            if (String.IsNullOrWhiteSpace(txtSerial.Text.Trim()))
            {
                DialogUtil.ShowWarning("Chưa nhập ký hiệu hóa đơn");
                txtSerial.Focus();
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtSoHoaDon.Text.Trim()))
            {
                DialogUtil.ShowWarning("Chưa nhập số hóa đơn");
                txtSoHoaDon.Focus();
                return false;
            }
            //kiểm tra hình thức thanh toán
            if (_currentHoaDon.MaHinhThucTT == null || _currentHoaDon.MaHinhThucTT.Value == 0)
            {
                DialogUtil.ShowWarning("Chưa chọn hình thức thanh toán");
                cbHinhThucThanhToan.Focus();
                return false;

            }
            if (radioKhachHangTrongDanhMuc.Checked)
            {
                //kiểm tra khách hàng trong danh mục
                if (_currentHoaDon.MaDoiTac == null || _currentHoaDon.MaDoiTac.Value == 0)
                {
                    DialogUtil.ShowWarning("Chưa chọn khách hàng trong danh mục");
                    cbDoiTac.Focus();
                    return false;
                }

            }
            else
            {//kiểm tra khách hàng ngoài danh mục
                //kiểm tra tên KH
                if (String.IsNullOrWhiteSpace(txtTenDoiTac.Text.Trim()))
                {
                    DialogUtil.ShowWarning("Chưa nhập tên khách hàng");
                    return false;
                }
            }



            return duocPhepLuu;
        }
        #endregion
        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();

            if (_yeuCauTaoHoaDonRongKhiFormLoad == true)
                this.btnThemMoi.PerformClick();//tạo mới 
        }
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //xử lý trường hợp đặc biệt
            {
                //khởi tạo mới factory
                _hoaDonTaiSan_DerivedFactory = HoaDonTaiSan_DerivedFactory.New();
                //gỡ bỏ liên kết đến các hóa đơn trước đó
                tblHoaDonBindingSource.DataSource = new List<tblHoaDon>();
            }
            //tạo mới hóa đơn
            _currentHoaDon = _hoaDonTaiSan_DerivedFactory.NewHoaDonMuaTaiSan(_coVAT);
            //ngày lập hóa đơn là ngày chứng từ
            _currentHoaDon.NgayLap = (DateTime?)_chungTu.NgayLap.Value;
            //ngày hết hạn thanh toán là 6 tháng sau ngày lập hóa đơn
            _currentHoaDon.NgayHetHanTT = (DateTime?)_chungTu.NgayLap.Value.AddMonths(6);
            //gán mã đối tác
            _currentHoaDon.MaDoiTac = _chungTu.MaDoiTuong.Value;
            //phương thức thanh toán
            _currentHoaDon.MaHinhThucTT = 1;//1 tiền mặc, 2 chuyển khoản
            //tình trạng
            _currentHoaDon.TinhTrang = (byte?)PSC_ERP_Business.Main.Predefined.TinhTrangHoaDonEnum.ChuaHoanTat;
            //
            {
                //decimal tongTienButToanThue = 0;
                //TaiKhoan_Factory taiKhoan_factory = TaiKhoan_Factory.New();
                //foreach (var butToan in _chungTu.tblDinhKhoan.tblButToans)
                //{
                //    //kiểm tra đối tượng nợ
                //    tblTaiKhoan noTK = taiKhoan_factory.Get_TaiKhoan_ByMaTaiKhoan(butToan.NoTaiKhoan.Value);
                //    if (noTK.SoHieuTK.StartsWith("31131"))
                //    {
                //        tongTienButToanThue += butToan.SoTien;
                //    }
                //}
                //set
                _currentHoaDon.ThanhTien = _butToan.SoTien;//_chungTu.tblTienTe.ThanhTien.Value;
                _currentHoaDon.ThueSuatVAT = 10;
                //set Thuế VAT bằng số tiền bút toán thuế
                //_currentHoaDon.ThueVAT = tongTienButToanThue;
            }

            //thêm hóa đơn vào
            this.tblHoaDonBindingSource.Add(_currentHoaDon);

            //tạo mới hóa đơn đối tác, chứa một số thông tin của đối tác chọn từ danh mục hoặc ngoài danh mục
            _hoaDon_DoiTac = HoaDon_DoiTac_Factory.New().CreateAloneObject();
            //LẤY MST từ đối tác
            tblDoiTac doiTac = DoiTac_Factory.New().Get_DoiTacByMaDoiTac(_chungTu.MaDoiTuong.Value);
            _hoaDon_DoiTac.MSThue = doiTac.MaSoThue;
            //

            _currentHoaDon.tblHoaDon_DoiTac.Add(_hoaDon_DoiTac);
            tblHoaDonDoiTacBindingSource_Single.DataSource = _hoaDon_DoiTac;

            //đi đến vị trí vừa thêm vào
            tblHoaDonBindingSource.MoveLast();
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }

        private void frmHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
            if (DialogResult.Yes == dlgResult)
            {
                if (false == this.Save())
                    e.Cancel = true;
            }
            else if (DialogResult.No == dlgResult)
            {
                //không làm gì cả
            }
            else if (DialogResult.Cancel == dlgResult)
            {
                e.Cancel = true;
            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.txtBlackHole.Focus();
            //DialogResult dlgResult = DialogUtil.ShowDelete(this);
            //if (dlgResult == DialogResult.Yes)
            //{
            //    try
            //    {
            //        this.grdViewHoaDon.DeleteSelectedRows();

            //        //lưu lại thay đổi
            //        _hoaDonTaiSan_DerivedFactory.SaveChanges();
            //        DialogUtil.ShowDeleteSuccessful();

            //    }
            //    catch (Exception)
            //    {
            //        DialogUtil.ShowNotDeleteSuccessful();
            //    }
            //}
        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void dteNgayLap_EditValueChanged(object sender, EventArgs e)
        {
            //Ngày hết hạn thanh toán 6 tháng sau ngày lập

            dteNgayHetHanThanhToan.DateTime = dteNgayLap.DateTime.AddMonths(6);
        }
        private void radioKhachHangTrongDanhMuc_CheckedChanged(object sender, EventArgs e)
        {
            //khách hàng trong danh mục
            txtTenDoiTac.EditValue = null;
            txtTenDoiTac.Visible = false;
            cbDoiTac.Visible = true;
        }
        private void radioKhachHangNgoaiDanhMuc_CheckedChanged(object sender, EventArgs e)
        {
            //khách hàng ngoài danh mục
            cbDoiTac.EditValue = null;
            cbDoiTac.Visible = false;
            txtTenDoiTac.Visible = true;
            txtMST.EditValue = null;
        }
        private void cbDoiTac_EditValueChanged(object sender, EventArgs e)
        {
            long maDoiTac = 0;
            try
            {
                maDoiTac = Convert.ToInt64(cbDoiTac.EditValue);
                if (maDoiTac != 0)
                {
                    tblDoiTac doiTac = DoiTac_Factory.New().Get_DoiTacByMaDoiTac(maDoiTac);

                    txtMST.Text = doiTac.MaSoThue;

                }

            }
            catch (System.Exception ex) { }

        }

        private void btnXoaHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn xóa hóa đơn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    //xóa hóa đơn
                    HoaDon_Factory.FullDelete(context: _hoaDonTaiSan_DerivedFactory.Context, deleteList: new List<Object> { _currentHoaDon });
                    _hoaDonTaiSan_DerivedFactory.SaveChanges();
                    DialogUtil.ShowDeleteSuccessful();
                    this.Close();
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowDeleteSuccessful();
                }
            }

        }

        #endregion























    }
}