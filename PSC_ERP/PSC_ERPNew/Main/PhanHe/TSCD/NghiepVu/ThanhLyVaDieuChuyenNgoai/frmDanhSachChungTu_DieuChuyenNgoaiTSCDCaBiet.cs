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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
//
namespace PSC_ERPNew.Main
{
    public partial class frmDanhSachChungTu_DieuChuyenNgoaiTSCDCaBiet : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDanhSachChungTu_DieuChuyenNgoaiTSCDCaBiet singleton_ = null;
        public static frmDanhSachChungTu_DieuChuyenNgoaiTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDanhSachChungTu_DieuChuyenNgoaiTSCDCaBiet();
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
        IQueryable<tblChungTu> _chungTuList_TimDuoc = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        ChungTuDieuChuyenNgoai_DerivedFactory _factory = null;
        #endregion


        //Member Constructor
        #region Member Constructor


        public frmDanhSachChungTu_DieuChuyenNgoaiTSCDCaBiet()
        {
            InitializeComponent();

        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void Tim()
        {
            using (DialogUtil.Wait(this))
            {
                LoaiTimChungTuEnum loaiTim = LoaiTimChungTuEnum.TatCa;
                CompareTypeEnum compareType = CompareTypeEnum.Equal;

                //xác định phương pháp
                XacDinhPhuongPhapTim(ref loaiTim, ref compareType);
                _factory = ChungTuDieuChuyenNgoai_DerivedFactory.New();
                //tìm
                _chungTuList_TimDuoc = _factory.TimKiem(loaiTim: loaiTim
                    , compareType: compareType
                    , soChungTu: txtSoChungTu.Text.Trim()
                    , soTien: Decimal.Parse(txtSoTien.Text.Trim())
                    , soTienDen: Decimal.Parse(txtSoTien_Den.Text.Trim())
                    , ngayChungTu: dteNgayChungTu.DateTime
                    , ngayChungTuDen: dteNgayChungTu_Den.DateTime
                    , maDoiTac: (Int32)cbDoiTac.EditValue
                    , userID: PSC_ERP_Global.Main.UserID);
                //gán binding source
                tblChungTuBindingSource.DataSource = _chungTuList_TimDuoc;
            }
        }
        private void XacDinhPhuongPhapTim(ref LoaiTimChungTuEnum loaiTim, ref CompareTypeEnum compareType)
        {
            if (radioChonTatCa.Checked)
                loaiTim = LoaiTimChungTuEnum.TatCa;
            else if (radioChonSoChungTu.Checked)
            {
                loaiTim = LoaiTimChungTuEnum.SoChungTu;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoSoChungTu.EditValue);
            }
            else if (radioChonNgayChungTu.Checked)
            {
                loaiTim = LoaiTimChungTuEnum.NgayLap;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoNgayChungTu.EditValue);
            }
            else if (radioChonSoTien.Checked)
            {
                loaiTim = LoaiTimChungTuEnum.SoTien;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoSoTien.EditValue);
            }
            else if (radioChonDoiTac.Checked)
            {
                loaiTim = LoaiTimChungTuEnum.DoiTac;
                compareType = CompareTypeEnum.Equal;
            }
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
            //gán binding source
            tblDoiTacBindingSource.DataSource = _doiTacList;
        }

        #endregion


        //Event Method
        #region Event Method

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DieuChuyenNgoai, this.MdiParent);
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gọi thêm mới chứng từ
            //frmDieuChuyenNgoaiTSCDCaBiet frm = new frmDieuChuyenNgoaiTSCDCaBiet();
            //frm.MdiParent = this.MdiParent;
            //frm.Show();
            frmDieuChuyenNgoaiTSCDCaBiet.ShowSingleton(null, this.MdiParent);
        }
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tìm chứng từ ghi tăng
            this.Tim();
        }
        private void UncheckAll_WithoutMe(List<CheckEdit> list, CheckEdit me)
        {
            foreach (var item in list)
            {
                if (!Object.ReferenceEquals(item, me))
                    item.Checked = false;

            }
        }

        private void frmDanhSachChungTu_DieuChuyenNgoaiTSCDCaBiet_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                using (DialogUtil.Wait(this))
                {
                    //load đối tác
                    LoadDoiTac();
                    // Cài đặt lưới
                    PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewChungTu);
                    //cài đặt radio group
                    RadioUtil.RadioGroup.Setup(false, new CheckEdit[] { radioChonTatCa, radioChonSoChungTu, radioChonNgayChungTu, radioChonSoTien, radioChonDoiTac });

                    //đặt ngày mặc định cho thông tin tìm kiếm
                    dteNgayChungTu.DateTime = app_users_Factory.New().SystemDate;
                    dteNgayChungTu_Den.DateTime = dteNgayChungTu.DateTime;
                    //cài đặt double click event cho grid view chứng từ
                    GridUtil.DoubleClickHelper.Setup(this.grdViewChungTu, (object senderz1, EventArgs ez1) =>
                    {
                        //xem lại chứng từ
                        GridView view = senderz1 as GridView;
                        tblChungTu chungTu = view.GetFocusedRow() as tblChungTu;
                        if (chungTu != null)
                        {
                            Form frm = null;
                            if (chungTu.CurrentForm_AddedObj == null || (chungTu.CurrentForm_AddedObj as Form).IsDisposed)
                            {
                                frm = new frmDieuChuyenNgoaiTSCDCaBiet(chungTu);
                                chungTu.CurrentForm_AddedObj = frm;
                            }
                            else
                                frm = chungTu.CurrentForm_AddedObj as frmDieuChuyenNgoaiTSCDCaBiet;

                            //show form
                            PSC_ERP_Common.FormUtil.ShowForm_Helper(frm, null, this.MdiParent);//frm.Show();
                        }

                    });
                    //cai dat Activated
                    this.Activated += (object senderz1, EventArgs ez1) =>
                    {
                        try
                        {
                            if (_factory != null)
                                _factory.RefreshAll(System.Data.Objects.RefreshMode.ClientWins);
                        }
                        catch (System.Exception ex)
                        {
                            Tim();
                        }
                    };
                }
            };

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}