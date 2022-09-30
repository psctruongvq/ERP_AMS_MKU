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
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
//
namespace PSC_ERPNew.Main
{
    public partial class frmDialogDanhSachGhiMucNganSachTheoButToan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDialogDanhSachGhiMucNganSachTheoButToan singleton_ = null;
        public static frmDialogDanhSachGhiMucNganSachTheoButToan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogDanhSachGhiMucNganSachTheoButToan();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion
        //Private Static Field
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion



        //Private Member field
        #region Private Member field
        Entities _context = null;
        IQueryable<tblTaiKhoan> _taiKhoanNoList = null;
        IQueryable<tblTaiKhoan> _taiKhoanCoList = null;
        IQueryable<tblTieuMucNganSach> _tieuMucNganSachList = null;
        tblChungTu _chungTu = null;
        tblButToan _butToan = null;
        #endregion

        //Member Constructor
        #region Member Constructor

        public frmDialogDanhSachGhiMucNganSachTheoButToan()
        {
            InitializeComponent();
        }
        public frmDialogDanhSachGhiMucNganSachTheoButToan(Entities context, tblChungTu chungTu, tblButToan butToan, IQueryable<tblTaiKhoan> noTaiKhoanList, IQueryable<tblTaiKhoan> coTaiKhoanList)
        {
            InitializeComponent();
            _context = context;
            _chungTu = chungTu;
            _butToan = butToan;

            _taiKhoanNoList = noTaiKhoanList;
            _taiKhoanCoList = coTaiKhoanList;


            //chungTu.tblChungTu_HoaDon
        }

        #endregion



        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {

            //lấy danh sách tiểu mục ngân sách
            _tieuMucNganSachList = TieuMucNganSach_Factory.New().GetAll();
            //
            GridUtil.DeleteHelper.Setup_ManualType(grdViewButToan_MucNganSach, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa ghi mục ngân sách
                ButToan_MucNganSach_Factory.FullDeleteButToan_MucNganSach(context: _context, deleteList: deleteList);
            });
            // Cài đặt lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewButToan_MucNganSach);

            GanBindingSource();
        }

        private void GanBindingSource()
        {
            tblButToanBindingSource_Single.DataSource = _butToan;
            tblButToanMucNganSachBindingSource.DataSource = _butToan.tblButToan_MucNganSach;

            tblTaiKhoanBindingSource_No.DataSource = _taiKhoanNoList;
            tblTaiKhoanBindingSource_Co.DataSource = _taiKhoanCoList;
            tblTieuMucNganSachBindingSource.DataSource = _tieuMucNganSachList;
        }

        private Boolean KiemTraHopLe()
        {
            Boolean hopLe = true;


            return hopLe;
        }
        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method
        private void frmDialogDanhSachGhiMucNganSachTheoButToan_Load(object sender, EventArgs e)
        {
            LoadData();

        }



        private void frmDialogDanhSachGhiMucNganSachTheoButToan_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnDuaDuLieuVeChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            tblButToanMucNganSachBindingSource.EndEdit();
            //kiểm tra thông tin


            Decimal tongTien = 0;
            foreach (var butToan_MucNganSach in _butToan.tblButToan_MucNganSach)
            {
                if (butToan_MucNganSach.MaTieuMuc == null || butToan_MucNganSach.MaTieuMuc.Value == 0)
                {
                    DialogUtil.ShowError("Có dòng ghi mục ngân sách chưa chọn tiểu mục");
                    return;
                }
                tongTien += butToan_MucNganSach.SoTien;
            }
            //
       
            if (tongTien != _butToan.SoTien && _butToan.tblButToan_MucNganSach.Count > 0)
            {
                DialogUtil.ShowError("Tổng tiền ghi mục ngân sách không bằng số tiền bút toán");
                return;
            }
            
            this.Close();
        }
        private void grdViewButToan_MucNganSach_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //lấy but toan muc ngan sach vừa tạo mới trên lưới
            tblButToan_MucNganSach butToan_MucNganSach = this.grdViewButToan_MucNganSach.GetRow(e.RowHandle) as tblButToan_MucNganSach;
            butToan_MucNganSach.DienGiai = _butToan.DienGiai;
            //số tiền trừ dần
            {
                Decimal tongTienMucNganSachKhac = 0;
                foreach (var item in _butToan.tblButToan_MucNganSach)
                {
                    if (!Object.ReferenceEquals(item, butToan_MucNganSach))
                        tongTienMucNganSachKhac += item.SoTien;
                }
                butToan_MucNganSach.SoTien = _butToan.SoTien - tongTienMucNganSachKhac;

            }
        }


        #endregion

    















    }
}