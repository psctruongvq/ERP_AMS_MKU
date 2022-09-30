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

namespace PSC_ERP
{
    public partial class frmDanhSachPhanBoChiPhiCCDCChuyenTuTaiSan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDanhSachPhanBoChiPhiCCDCChuyenTuTaiSan singleton_ = null;
        public static frmDanhSachPhanBoChiPhiCCDCChuyenTuTaiSan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDanhSachPhanBoChiPhiCCDCChuyenTuTaiSan();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent)
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
        IQueryable<tblPhanBoChiPhiCCDCChuyenTuTaiSan> _nghiepVuList_TimDuoc = null;
        #endregion


        //Member Constructor
        #region Member Constructor


        public frmDanhSachPhanBoChiPhiCCDCChuyenTuTaiSan()
        {
            InitializeComponent();
            //đặt ngày mặc định cho thông tin tìm kiếm
            dteNgayChungTu.DateTime = app_users_Factory.New().SystemDate;
            dteNgayChungTu_Den.DateTime = dteNgayChungTu.DateTime;
            //cài đặt double click event cho grid view chứng từ
            GridUtil.DoubleClickHelper.Setup(this.grdViewNghiepVuDieuChuyenNoiBo, (object sender, EventArgs e) =>
            {
                //xem lại chứng từ
                GridView view = sender as GridView;
                tblPhanBoChiPhiCCDCChuyenTuTaiSan nghiepVu = view.GetFocusedRow() as tblPhanBoChiPhiCCDCChuyenTuTaiSan;
                if (nghiepVu != null)
                {
                    Form frm = null;
                    if (nghiepVu.CurrentForm_AddedObj == null || (nghiepVu.CurrentForm_AddedObj as Form).IsDisposed)
                    {
                        frm = new frmPhanBoChiPhiCCDCChuyenTuTaiSan(nghiepVu);
                        nghiepVu.CurrentForm_AddedObj = frm;
                    }
                    else
                        frm = nghiepVu.CurrentForm_AddedObj as frmPhanBoChiPhiCCDCChuyenTuTaiSan;

                    //show form
                    PSC_ERP_Common.FormUtil.ShowForm_Helper(frm, null, this.MdiParent);//frm.Show();
                }
            });
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private void Tim()
        {
            LoaiTimChungTuEnum loaiTim = LoaiTimChungTuEnum.TatCa;
            CompareTypeEnum compareType = CompareTypeEnum.Equal;

            //xác định phương pháp
            XacDinhPhuongPhapTim(ref loaiTim, ref compareType);

            //tìm
            _nghiepVuList_TimDuoc = PhanBoChiPhiCCDCChuyenTuTaiSan_Factory.New().TimKiem(loaiTim: loaiTim
                , compareType: compareType
                , soChungTu: txtSoChungTu.Text.Trim()
                , ngayChungTu: dteNgayChungTu.DateTime
                , ngayChungTuDen: dteNgayChungTu_Den.DateTime);
            //gán binding source
            tblPhaBoChiPhiCCDCChuyenTuTaiSanBindingSource.DataSource = _nghiepVuList_TimDuoc;
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
        }

        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhanBoChiPhiCCDCChuyenTuTaiSan.ShowSingleton(null, this.MdiParent);
        }
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tìm chứng từ
            this.Tim();
        }
 

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void frmDanhSachPhanBoChiPhiCCDCChuyenTuTaiSan_Load(object sender, EventArgs e)
        {
            // Cài đặt lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewNghiepVuDieuChuyenNoiBo);
            //cài đặt radio group
            RadioUtil.RadioGroup.Setup(false, new CheckEdit[] { radioChonTatCa, radioChonSoChungTu, radioChonNgayChungTu });
        }
        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DieuChuyenNoiBo, this.MdiParent);
        }
        #endregion



    }
}