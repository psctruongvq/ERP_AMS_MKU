using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
//using System.Data.Entity.Core.Objects;

namespace PSC_ERP.Main
{
    public partial class frmDSKeHoachBaoTriBaoDuong : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDSKeHoachBaoTriBaoDuong singleton_ = null;
        public static frmDSKeHoachBaoTriBaoDuong Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDSKeHoachBaoTriBaoDuong();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion
        //Private Static Field
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        //Private Member field
        #region Private Member field
        IQueryable<Project> _projectList_TimDuoc = null;
        Project_Factory _factory = null;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDSKeHoachBaoTriBaoDuong()
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
                LoaiTimProjectEnum loaiTim = LoaiTimProjectEnum.TatCa;
                CompareTypeEnum compareType = CompareTypeEnum.Equal;

                //xác định phương pháp
                XacDinhPhuongPhapTim(ref loaiTim, ref compareType);
                _factory = Project_Factory.New();
                //tìm
                _projectList_TimDuoc = _factory.TimKiem(loaiTim: loaiTim
                    , compareType: compareType
                    , tuNgay: dteTuNgay.DateTime
                    , denNgay: dteDenNgay.DateTime
                    , userID: PSC_ERP_Global.Main.UserID);
                ////gán binding source
                projectBindingSource.DataSource = _projectList_TimDuoc;
            }
        }
        private void XacDinhPhuongPhapTim(ref LoaiTimProjectEnum loaiTim, ref CompareTypeEnum compareType)
        {
            if (radioChonTatCa.Checked)
                loaiTim = LoaiTimProjectEnum.TatCa;
            else if (radioChonNgayLap.Checked)
            {
                loaiTim = LoaiTimProjectEnum.NgayLap;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoNgay.EditValue);
            }
        }

        #endregion

        //Event Method
        #region Event Method
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmKeHoachBaoTriBaoDuong.ShowSingleton(null, this.MdiParent);
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
        private void frmDSKeHoachBaoTriBaoDuong_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //đặt ngày mặc định cho thông tin tìm kiếm
                //dteTuNgay.DateTime = AppUser_Factory.New().SystemDate;
                dteTuNgay.DateTime = new DateTime(1998, 1, 1);
                dteDenNgay.DateTime = app_users_Factory.New().SystemDate;

                //cài đặt radio group
                RadioUtil.RadioGroup.Setup(false, new CheckEdit[] { radioChonTatCa, radioChonNgayLap});

                //cài đặt double click event cho grid view chứng từ
                GridUtil.DoubleClickHelper.Setup(this.grdViewProject, (object senderz1, EventArgs ez1) =>
                {
                    //xem lại chứng từ
                    GridView view = senderz1 as GridView;
                    Project project = view.GetFocusedRow() as Project;
                    if (project != null)
                    {
                        Form frm = null;
                        if (project.CurrentForm_AddedObj == null || (project.CurrentForm_AddedObj as Form).IsDisposed)
                        {
                            frm = new frmKeHoachBaoTriBaoDuong(project.ID);
                            project.CurrentForm_AddedObj = frm;
                        }
                        else
                            frm = project.CurrentForm_AddedObj as frmKeHoachBaoTriBaoDuong;

                        //show form
                        FormUtil.ShowForm_Helper(frm, null, this.MdiParent);//frm.Show();
                    }
                });
                // Cài đặt lưới
                GridUtil.SetSTTForGridView(this.grdViewProject);

                //cai dat Activated
                this.Activated += (object senderz1, EventArgs ez1) =>
                {
                    try
                    {
                        if (_factory != null)
                            //_factory.RefreshAll(RefreshMode.ClientWins);
                            _factory.RefreshAll(System.Data.Objects.RefreshMode.ClientWins);
                    }
                    catch (Exception ex)
                    {
                        Tim();
                    }
                };
            };
        }
        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_BaoTriBaoDuong, this.MdiParent);
        }
        private void btnProjectReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_projectList_TimDuoc == null || _projectList_TimDuoc.Count() == 0)
            {
                DialogUtil.ShowWarning("Vẫn chưa có kế hoạch bào trì nào?");
                return;
            };
            using (frmKeHoachBaoTriBaoDuongBaoCao frm = new frmKeHoachBaoTriBaoDuongBaoCao( _projectList_TimDuoc.ToList()))
            {//show form task
                frm.ShowDialog(this);
            }
        }
        #endregion
    }
}