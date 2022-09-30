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
////
namespace PSC_ERPNew.Main
{
    public partial class frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat singleton_ = null;
        public static frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat();
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
        IQueryable<tblTieuMucNganSach> _tieuMucNganSachList = null;
        tblChungTu _chungTu = null;
        tblButToan _butToan = null;
        tblCT_ChiPhiSanXuat _chiPhiSanXuat = null;
        #endregion

        //Member Constructor
        #region Member Constructor

        public frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat()
        {
            InitializeComponent();
        }
        public frmDialogDanhSachGhiMucNganSachTheoButToanVaChiPhiSanXuat(Entities context, tblChungTu chungTu, tblButToan butToan, tblCT_ChiPhiSanXuat chiPhiSanXuat)
        {
            InitializeComponent();
            _context = context;
            _chungTu = chungTu;
            _butToan = butToan;
            _chiPhiSanXuat = chiPhiSanXuat;
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

            tblButToanMucNganSachBindingSource.DataSource = _butToan.tblButToan_MucNganSach;
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
                if ((butToan_MucNganSach.MaTieuMuc ?? 0) == 0)
                {
                    DialogUtil.ShowError("Có dòng ghi mục ngân sách chưa chọn tiểu mục");
                    return;
                }
                tongTien += butToan_MucNganSach.SoTien;
            }
            //
            if (tongTien != _chiPhiSanXuat.SoTien && _butToan.tblButToan_MucNganSach.Any())//.Count > 0)
            {
                DialogUtil.ShowError("Tổng tiền ghi mục ngân sách không bằng tiền chi phí");
                return;
            }
            this.Close();
        }
        private void grdViewButToan_MucNganSach_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //lấy but toan muc ngan sach vừa tạo mới trên lưới
            tblButToan_MucNganSach butToan_MucNganSachNew = this.grdViewButToan_MucNganSach.GetRow(e.RowHandle) as tblButToan_MucNganSach;
            ThietLapChoButToanMucNganSachMoi(butToan_MucNganSachNew);
        }

        private void ThietLapChoButToanMucNganSachMoi(tblButToan_MucNganSach butToan_MucNganSach)
        {
            butToan_MucNganSach.DienGiai = _butToan.DienGiai;
            //số tiền trừ dần
            {
                Decimal tongTienMucNganSachKhac = 0;
                foreach (var item in _butToan.tblButToan_MucNganSach)
                {
                    if (!Object.ReferenceEquals(item, butToan_MucNganSach))
                        tongTienMucNganSachKhac += item.SoTien;
                }
                butToan_MucNganSach.SoTien = (_chiPhiSanXuat.SoTien ?? 0) - tongTienMucNganSachKhac;

            }
            //_butToan.tblButToan_MucNganSach.Add(butToan_MucNganSach);//ko can nua vi rdViewButToan_MucNganSach da binding truc tiep vo _butToan.tblButToan_MucNganSach
            //gan lien kiet den chi phi san xuat
            _chiPhiSanXuat.tblButToan_MucNganSach.Add(butToan_MucNganSach);
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tblButToan_MucNganSach butToan_MucNganSachNew = ButToan_MucNganSach_Factory.New().CreateAloneObject();

            _butToan.tblButToan_MucNganSach.Add(butToan_MucNganSachNew);
            _chiPhiSanXuat.tblButToan_MucNganSach.Add(butToan_MucNganSachNew);
            tblButToanMucNganSachBindingSource.Add(butToan_MucNganSachNew);
            tblButToanMucNganSachBindingSource.MoveLast();  
            ThietLapChoButToanMucNganSachMoi(butToan_MucNganSachNew);
        }


        #endregion


















    }
}