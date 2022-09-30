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

namespace PSC_ERPNew.Main
{
    public partial class frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014 : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014 singleton_ = null;
        public static frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014 Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014();
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
        List<sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014_Result> _chungTuList_TimDuoc = null;
        List<sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014_Result> _chungTuDuocChonList = null;
        #endregion

        //Public Member Property
        #region Public Member Property
        public List<sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014_Result> ChungTuDuocChonList
        {
            get { return _chungTuDuocChonList; }
        }
        #endregion

        //Member Constructor
        #region Member Constructor


        public frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014()
        {
            InitializeComponent();
   

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

        private void frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014_Load(object sender, EventArgs e)
        {
            _chungTuList_TimDuoc = sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014_Factory.GetAll().ToList();
            spTSCDLayDanhSachChungTuGhiTangCuTruocNam2014ResultBindingSource.DataSource = _chungTuList_TimDuoc;
            // Cài đặt lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewChungTu);
            // Đưa checkbox lên lưới
            PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewChungTu, colChon);

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnDuaDuLieuVeChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            //lấy những dòng được chọn
            _chungTuDuocChonList = (from o in _chungTuList_TimDuoc
                                    where o.Chon == true
                                    orderby o.NgayLap
                                    select o).ToList();

            

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion













    }
}