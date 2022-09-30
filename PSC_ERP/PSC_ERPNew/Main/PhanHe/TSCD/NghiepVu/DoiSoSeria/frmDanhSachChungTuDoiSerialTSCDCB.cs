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
    public partial class frmDanhSachChungTuDoiSerialTSCDCB : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDanhSachChungTuDoiSerialTSCDCB singleton_ = null;
        public static frmDanhSachChungTuDoiSerialTSCDCB Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDanhSachChungTuDoiSerialTSCDCB();
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
        IQueryable<tblNghiepVuSuaSoSerialTSCDCB> _nghiepVuList_TimDuoc = null;
        NghiepVuDoiSerialTaiSan_Factory _factory = null;
        #endregion


        //Member Constructor
        #region Member Constructor


        public frmDanhSachChungTuDoiSerialTSCDCB()
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
                _factory = NghiepVuDoiSerialTaiSan_Factory.New();
                //tìm
                _nghiepVuList_TimDuoc = _factory.TimKiem(loaiTim: loaiTim
                    , compareType: compareType
                    , soChungTu: txtSoChungTu.Text.Trim()
                    , ngayChungTu: dteNgayChungTu.DateTime
                    , ngayChungTuDen: dteNgayChungTu_Den.DateTime
                    , userID: PSC_ERP_Global.Main.UserID);
                //gán binding source
                tblNghiepVuDoiSerialTSCDCB_BindingSource.DataSource = _nghiepVuList_TimDuoc;
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
        }

        #endregion

        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gọi thêm mới chứng từ ghi tăng tài sản
            //frmDieuChuyenNoiBoTSCDCaBiet frm = new frmDieuChuyenNoiBoTSCDCaBiet();
            //frm.MdiParent = this.MdiParent;
            //frm.Show();

            frmDoiSoSerialTSCD.ShowSingleton(null, this.MdiParent);
        }
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tìm chứng từ
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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void frmDanhSachChungTuDoiSerialTSCDCB_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //đặt ngày mặc định cho thông tin tìm kiếm
                dteNgayChungTu.DateTime = app_users_Factory.New().SystemDate;
                dteNgayChungTu_Den.DateTime = dteNgayChungTu.DateTime;
                //cài đặt double click event cho grid view chứng từ
                GridUtil.DoubleClickHelper.Setup(this.grdViewNghiepVuDoiSerialTaiSan, (object senderz1, EventArgs ez1) =>
                {
                    //xem lại chứng từ
                    GridView view = senderz1 as GridView;
                    tblNghiepVuSuaSoSerialTSCDCB nghiepVuDoiSerialTaiSan = view.GetFocusedRow() as tblNghiepVuSuaSoSerialTSCDCB;
                    if (nghiepVuDoiSerialTaiSan != null)
                    {
                        Form frm = null;
                        if (nghiepVuDoiSerialTaiSan.CurrentForm_AddedObj == null || (nghiepVuDoiSerialTaiSan.CurrentForm_AddedObj as Form).IsDisposed)
                        {
                            frm = new frmDoiSoSerialTSCD(Convert.ToInt32(nghiepVuDoiSerialTaiSan.ID));
                            nghiepVuDoiSerialTaiSan.CurrentForm_AddedObj = frm;
                        }
                        else
                            frm = nghiepVuDoiSerialTaiSan.CurrentForm_AddedObj as frmDoiSoSerialTSCD;

                        //show form
                        PSC_ERP_Common.FormUtil.ShowForm_Helper(frm, null, this.MdiParent);//frm.Show();
                    }
                });
                // Cài đặt lưới
                PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewNghiepVuDoiSerialTaiSan);
                //cài đặt radio group
                RadioUtil.RadioGroup.Setup(false, new CheckEdit[] { radioChonTatCa, radioChonSoChungTu, radioChonNgayChungTu });
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
            };
        }
        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DieuChuyenNoiBo, this.MdiParent);
        }
        #endregion



    }
}