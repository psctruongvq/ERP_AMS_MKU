using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using System.Linq;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Predefined;

namespace PSC_ERPNew.Main
{
    public partial class frmNhapChiTietTaiSan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmNhapChiTietTaiSan singleton_ = null;
        public static frmNhapChiTietTaiSan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmNhapChiTietTaiSan();
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
        //static readonly log4net.ILog TracingLog = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
        tblChiTietTaiSanCaBiet _chiTietTaiSanCBCu = null;
        public tblChiTietTaiSanCaBiet _chiTietTaiSanCBMoi = null;

        tblTaiSanCoDinhCaBiet _taiSanCoDinhCaBiet = null;

        List<tblQuocGia> _quocGiaList = null;
        tblQuocGia _quocGiaSanXuat = null;
        List<tblTaiSanCoDinhCaBiet> _taiSanCDCBList = null;
        List<tblChiTietTaiSanCaBiet> _danhSachChiTietDaCo = null;
        public List<tblTaiSanCoDinhCaBiet> _danhSachTaiSanCDCBApDung = new List<tblTaiSanCoDinhCaBiet>();

        int namHienTai = app_users_Factory.New().SystemDate.Year;       

        Boolean _apDungNhieuTaiSan = false;
        Boolean _kiemTraHopLe = true;
        #endregion

        //Public Member field
        #region Public Member field

        #endregion

        //Public Member Property
        #region Public Member Property

        #endregion

        //Member Constructor
        #region Member Constructor


        public frmNhapChiTietTaiSan()
        {
            InitializeComponent();
        }


        public frmNhapChiTietTaiSan(tblChiTietTaiSanCaBiet chiTietTaiSanCBCu, tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet, List<tblChiTietTaiSanCaBiet> danhSachChiTietDaCo)
        {
            InitializeComponent();
            _chiTietTaiSanCBCu = chiTietTaiSanCBCu;
            _taiSanCoDinhCaBiet = taiSanCoDinhCaBiet;
            _danhSachChiTietDaCo = danhSachChiTietDaCo;
            if (_chiTietTaiSanCBCu != null)
            {
                _taiSanCDCBList = TaiSanCoDinhCaBiet_Factory.New().Get_DanhSachTaiSanCoDinhCaBiet_ByTenChiTietTSCDCB(_chiTietTaiSanCBCu.TenChiTiet).ToList();
            }
            if (danhSachChiTietDaCo.Count > 0 || danhSachChiTietDaCo != null)
            {
                foreach (tblTaiSanCoDinhCaBiet taiSanCDCB in _taiSanCDCBList)
                {
                    foreach (tblChiTietTaiSanCaBiet chiTietTSCDCB in taiSanCDCB.tblChiTietTaiSanCaBiets)
                    {
                        //foreach (tblChiTietTaiSanCaBiet chiTietTaiSanCDCBDaCo in danhSachChiTietDaCo)
                        for (int i = 0; i < _danhSachChiTietDaCo.Count; i++)
                        {   //xóa bỏ tài sản đã tồn tại chi tiết được thêm vào chứng từ trường hợp áp dụng hàng loạt đã có trước đó
                            tblChiTietTaiSanCaBiet chiTiet = _danhSachChiTietDaCo[i];
                            if (chiTiet != null)
                            {
                                if (chiTietTSCDCB.MaChiTiet == chiTiet.MaChiTiet)
                                {
                                    _taiSanCDCBList.Remove(taiSanCDCB);
                                }
                            }
                        }
                    }
                }

                tblTaiSanCoDinhCaBiet_BindingSource.DataSource = _taiSanCDCBList;
            }
            //groupControl1.Text = "Thông tin Chi tiết mới của tài sản: " taiSanCoDinhCaBiet.tblDanhMucTSCD.Ten.ToString() + " - Model " + taiSanCoDinhCaBiet.tblDanhMucTSCD.ModelTSCD.ToString();
        }

        #endregion



        //Private Member Function
        #region Private Member Function      

        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlack.Focus();
            _kiemTraHopLe = true;
            if (!_apDungNhieuTaiSan)
            {
                if (numSoLuong.Value > _chiTietTaiSanCBCu.SoLuong || numSoLuong.Value <= 0)
                {
                    DialogUtil.ShowError("Số lượng chi tiết tài sản mới lớn hơn số lượng chi tiết tài sản cũ\nHay Số lượng không đươc nhỏ hơn hay bằng 0 \nKhông hợp lệ! Vui lòng nhập lại!");
                    return;
                }
                _danhSachTaiSanCDCBApDung.Add(_taiSanCoDinhCaBiet);
            }
            else
            {
                //lấy danh sách các tài sản cần áp dụng
                //List<tblTaiSanCoDinhCaBiet> _danhSachTSCDCB = new List<tblTaiSanCoDinhCaBiet>();
                tblTaiSanCoDinhCaBiet _taiSanCDCB = null;
                Int32[] rowHandleList = grdViewTSCDCaBiet.GetSelectedRows();
                if (rowHandleList.Count() > 0)
                {
                    foreach (var index in rowHandleList)
                    {
                        _taiSanCDCB = new tblTaiSanCoDinhCaBiet();
                        _taiSanCDCB = ((tblTaiSanCoDinhCaBiet)grdViewTSCDCaBiet.GetRow(index));
                        _danhSachTaiSanCDCBApDung.Add(_taiSanCDCB);
                    }
                }
                else
                {
                    DialogUtil.ShowError("Chưa Chọn Tài Sản Cố Định Cá Biệt Cần Áp Dụng \nVui Lòng Chọn Tài Sản Cố Định Cá Biệt!");
                    _kiemTraHopLe = false;
                }
            }
            if (txtTen.Text == "")
            {
                DialogUtil.ShowError("Chưa nhập tên chi tiết tài sản \nVui lòng nhập tên chi tiết tài sản");
                txtTen.Focus();
                _kiemTraHopLe = false;
                return;
            }         
            if (_kiemTraHopLe)
            {
                TaoChiTietTaiSanMoi();
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void frmBoPhan_Load(object sender, EventArgs e)
        {           
            PSC_ERP_Common.GridUtil.SetSTTForGridView(grdViewTSCDCaBiet);

            //lấy danh sách quốc gia
            _quocGiaList = QuocGia_Factory.New().GetAll().ToList();
            tblQuocGia quocGia_khongChon = new tblQuocGia() { MaQuocGia = 0, MaQuocGiaQuanLy = "<<Không chọn>>", TenQuocGia = "<<Không chọn>>" };
            _quocGiaList.Insert(0, quocGia_khongChon);
            this.tblQuocGiaBindingSource.DataSource = _quocGiaList;

            numNamSX.Value = namHienTai;
            grdControl_TaiSanCDCBCaBiet.Enabled = false;
           
        }

        #endregion

        private void frmBoPhanNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlack.Focus();
        }

        private void chk_ApDungNhieuTaiSan_CheckedChanged(object sender, EventArgs e)
        {
            _apDungNhieuTaiSan = chk_ApDungNhieuTaiSan.Checked;
            grdControl_TaiSanCDCBCaBiet.Enabled = _apDungNhieuTaiSan;
        }

        //lưu những thông tin cơ bản cho chi tiêt mới
        public void TaoChiTietTaiSanMoi()
        {
            _chiTietTaiSanCBMoi = new tblChiTietTaiSanCaBiet();// _chiTietTaiSanCaBiet_Factory.CreateManagedObject();
            _chiTietTaiSanCBMoi.TenChiTiet = txtTen.Text;
            _chiTietTaiSanCBMoi.SoLuong = (int)numSoLuong.Value;
            _chiTietTaiSanCBMoi.Model = txtModel.Text;
            _chiTietTaiSanCBMoi.Serial = txt_Seria.Text;
            _chiTietTaiSanCBMoi.NamSanXuat = (Int32?)numNamSX.Value;
            if(_quocGiaSanXuat !=null)
                _chiTietTaiSanCBMoi.MaQuocGiaSX = _quocGiaSanXuat.MaQuocGia;
               
        }

        private void cbNuocSanXuat_EditValueChanged(object sender, EventArgs e)
        {
            _quocGiaSanXuat = (tblQuocGia)cbNuocSanXuat.GetSelectedDataRow();

        }

        private void cbNuocSanXuat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                frmListQuocGia frm = new frmListQuocGia();
                frm.ShowDialog();
                _quocGiaList = QuocGia_Factory.New().GetAll().ToList();
            }
        }
    }

}
