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
using PSC_ERP;

namespace PSC_ERP.ThuChiEntity
{
    public partial class frmDanhSachHoaDonTheoButToan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDanhSachHoaDonTheoButToan singleton_ = null;
        public static frmDanhSachHoaDonTheoButToan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDanhSachHoaDonTheoButToan();
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


        //Private Member field
        #region Private Member field
        Entities _context = null;
        IQueryable<tblTaiKhoan> _taiKhoanNoList = null;
        IQueryable<tblTaiKhoan> _taiKhoanCoList = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        tblChungTu _chungTu = null;
        tblButToan _butToan = null;
        long _maDoiTac = 0;
        #endregion



        //Member Constructor
        #region Member Constructor

        public frmDanhSachHoaDonTheoButToan()
        {
            InitializeComponent();
        }
        public frmDanhSachHoaDonTheoButToan(Entities context, tblChungTu chungTu, tblButToan butToan, IQueryable<tblTaiKhoan> noTaiKhoanList, IQueryable<tblTaiKhoan> coTaiKhoanList)
        {
            InitializeComponent();
            _context = context;
            _chungTu = chungTu;
            _butToan = butToan;

            _taiKhoanNoList = noTaiKhoanList;
            _taiKhoanCoList = coTaiKhoanList;

            _maDoiTac = chungTu.MaDoiTuong != null ? chungTu.MaDoiTuong.Value : 0;
            //chungTu.tblChungTu_HoaDon
        }

        #endregion



        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {

            //lấy danh sách tất cả đối tác
            LoadDoiTac();
            tblButToanBindingSource_Single.DataSource = _butToan;
            tblChungTuHoaDonBindingSource.DataSource = _butToan.tblChungTu_HoaDon;

            tblTaiKhoanBindingSource_No.DataSource = _taiKhoanNoList;
            tblTaiKhoanBindingSource_Co.DataSource = _taiKhoanCoList;
        }


        private void LoadDoiTac()
        {

            Thread thr = new Thread(() =>
            {
                if (this.InvokeRequired)
                {
                    PSC_ERP_Common.Delegate.VoidDelegate dele = new PSC_ERP_Common.Delegate.VoidDelegate(this.LoadDoiTac_Helper);
                    this.Invoke(dele);
                }
                else
                {
                    this.LoadDoiTac_Helper();
                }
            });
            thr.Start();

        }
        void LoadDoiTac_Helper()
        {
            _doiTacList = DoiTac_Factory.New().GetAll();
            tblDoiTacBindingSource.DataSource = _doiTacList;
        }
        private Boolean KiemTraHopLe()
        {
            Boolean hopLe = true;


            return hopLe;
        }
        private void Dua1HoaDonVaoButToanChungTu(Int64 maHoaDon)
        {
            tblChungTu_HoaDon chungTu_HoaDon = ChungTu_HoaDon_Factory.New().CreateAloneObject();
            chungTu_HoaDon.MaHoaDon = maHoaDon;

            //đưa vào chứng từ hóa đơn
            _chungTu.tblChungTu_HoaDon.Add(chungTu_HoaDon);

            //đưa vào danh sách chứng từ bút toán
            tblChungTuHoaDonBindingSource.Add(chungTu_HoaDon);
        }
        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method
        private void frmDanhSachHoaDonTheoButToan_Load(object sender, EventArgs e)
        {
            LoadData();

            GridUtil.DeleteHelper.Setup_ManualType(grdViewChungTu_HoaDon, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa chứng từ hóa đơn
                ChungTu_HoaDon_Factory.FullDelete(context: _context, deleteList: deleteList);
            });
            // Cài đặt lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewChungTu_HoaDon);

            //PSC_ERP_Common.GridUtil.DoubleClickHelper.Setup(this.grdViewChungTu_HoaDon, (object senderz, EventArgs ez) =>
            //{
            //    //xem lại chứng từ
            //    GridView view = senderz as GridView;
            //    tblChungTu_HoaDon chungTu_hoaDon = view.GetFocusedRow() as tblChungTu_HoaDon;

            //    if (chungTu_hoaDon != null)
            //    {
            //        Form frm = null;

            //        frm = new frmHoaDon(_chungTu, _butToan, chungTu_hoaDon.MaHoaDon);

            //        //show form
            //        frm.ShowDialog();

            //    }

            //});


            PSC_ERP_Common.GridUtil.DoubleClickHelper.Setup(this.grdViewChungTu_HoaDon, (object senderz1, EventArgs ez1) =>
            {
                //xem lại chứng từ
                GridView view = senderz1 as GridView;
                tblChungTu_HoaDon chungTu_hoaDon = view.GetFocusedRow() as tblChungTu_HoaDon;

                tblHoaDon entityHoaDon = chungTu_hoaDon.tblHoaDon;
                if (entityHoaDon != null)
                {
                    Form frm = null;

                    //frm = new frmHoaDon(_chungTu, _butToan, hoaDon.MaHoaDon);

                    //show form
                    //frm.ShowDialog();
                    //tìm lại
                    //this.Tim();

                    //////

                    ERP_Library.HoaDon cslaHoaDon = ERP_Library.HoaDon.NewHoaDon();
                    cslaHoaDon = ERP_Library.HoaDon.GetHoaDon(entityHoaDon.MaHoaDon);
                    if (entityHoaDon.LoaiHoaDon == 4) // mua vao 
                    {
                        frm = new frmHoaDonDichVuMuaVao(cslaHoaDon);
                    }
                    else // ban ra
                    {
                        frm = new frmHoaDonDichVuBanRa(cslaHoaDon);

                    }
                    frm.ShowDialog();
                    _chungTu.RefreshHoaDon(System.Data.Objects.RefreshMode.ClientWins);
                    ////////////
                }
            });

        }



        private void frmDanhSachHoaDonTheoButToan_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnDuaDuLieuVeChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();



            this.Close();
        }

        private void btnTimChonHoaDon_Click(object sender, EventArgs e)
        {
            frmTimChonHoaDonTheoButToan frm = new frmTimChonHoaDonTheoButToan(_chungTu//, _butToan
                , _maDoiTac);
            DialogResult dlgResult = frm.ShowDialog(this);
            if (dlgResult == DialogResult.Yes)
            {
                //duyệt qua từng hóa đơn được chọn
                foreach (tblHoaDon item in frm.HoaDonDuocChonList)
                {
                    Boolean daTonTai = false;
                    foreach (var ct_hd in _butToan.tblChungTu_HoaDon)
                    {
                        if (ct_hd.MaHoaDon == item.MaHoaDon)
                        {
                            daTonTai = true;
                            break;
                        }
                    }
                    if (daTonTai == false)
                    {
                        Dua1HoaDonVaoButToanChungTu(item.MaHoaDon);
                    }

                }
                _chungTu.RefreshHoaDon(System.Data.Objects.RefreshMode.ClientWins);

            }
        }



        private void btnThemHoaDonMuaVaoCoVAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tạo hóa đơn mới
            //frmHoaDon frm = new frmHoaDon(chungTu: _chungTu, butToan: _butToan, coVAT: true);
            //frm.ShowDialog();

            //Dua1HoaDonVaoButToanChungTu(frm.MaHoaDon);
        }


        private void btnThemHoaDonMuaVaoKhongCoVAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tạo hóa đơn mới
            //frmHoaDon frm = new frmHoaDon(chungTu: _chungTu, butToan: _butToan, coVAT: false);
            //frm.ShowDialog();

            //Dua1HoaDonVaoButToanChungTu(frm.MaHoaDon);
        }

        #endregion



















    }
}