using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using System.Drawing;

namespace PSC_ERPNew.Main
{
    public partial class frmDanhSachChungTu_SuaChuaLon :XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDanhSachChungTu_SuaChuaLon singleton_ = null;
        public static frmDanhSachChungTu_SuaChuaLon Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDanhSachChungTu_SuaChuaLon();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion

        //Private Member field
        #region Private Member field
        IQueryable<tblChungTu> _chungTuList_TimDuoc = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        ChungTuSuaChuaLonTaiSan_DerivedFactory _factory = null;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDanhSachChungTu_SuaChuaLon()
        {
            InitializeComponent();
            //đặt ngày mặc định cho thông tin tìm kiếm
            dteNgayChungTu.DateTime = app_users_Factory.New().SystemDate;
            dteNgayChungTu_Den.DateTime = dteNgayChungTu.DateTime;
            //cài đặt double click event cho grid view chứng từ
            GridUtil.DoubleClickHelper.Setup(this.grdViewChungTu, (object sender, EventArgs e) =>
            {
                //xem lại chứng từ
                GridView view = sender as GridView;
                tblChungTu chungTu = view.GetFocusedRow() as tblChungTu;
                if (chungTu != null)
                {
                    Form frm = null;
                    if (chungTu.CurrentForm_AddedObj == null || (chungTu.CurrentForm_AddedObj as Form).IsDisposed)
                    {
                        frm = new frmSuaChuaLon(chungTu);//(chungTu.MaChungTu);
                        chungTu.CurrentForm_AddedObj = frm;
                    }
                    else
                        frm = chungTu.CurrentForm_AddedObj as frmSuaChuaLon;
                    //show form
                    FormUtil.ShowForm_Helper(frm, null, this.MdiParent);//frm.Show();
                }
            });
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private void Tim()
        {
            using (DialogUtil.Wait())
            {
                LoaiTimChungTuEnum loaiTim = LoaiTimChungTuEnum.TatCa;
                CompareTypeEnum compareType = CompareTypeEnum.Equal;

                //xác định phương pháp
                XacDinhPhuongPhapTim(ref loaiTim, ref compareType);

                _factory = ChungTuSuaChuaLonTaiSan_DerivedFactory.New();
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
            Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_SuaChuaLon, this.MdiParent);
        }

        private void frmDanhSachChungTu_SuaChuaLon_Load(object sender, EventArgs e)
        {
            //load đối tác
            LoadDoiTac();
            // Cài đặt lưới
            GridUtil.SetSTTForGridView(this.grdViewChungTu);
            //cài đặt radio group
            RadioUtil.RadioGroup.Setup(false, new CheckEdit[] { radioChonTatCa, radioChonSoChungTu, radioChonNgayChungTu, radioChonSoTien, radioChonDoiTac });
            //cai dat Activated
            this.Activated += (object senderz1, EventArgs ez1) =>
            {
                try
                {
                    if (_factory != null)
                        _factory.RefreshAll(System.Data.Objects.RefreshMode.ClientWins);
                }
                catch (Exception ex)
                {
                    Tim();
                }
            };
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gọi thêm mới chứng từ
            //frmSuaChuaLon frm = new frmSuaChuaLon();
            //frm.MdiParent = this.MdiParent;
            //frm.Show();
            frmSuaChuaLon.ShowSingleton(null, this.MdiParent);
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
        private void radioChonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            //UncheckAll_WithoutMe(sender as CheckEdit, new List<CheckEdit> { });
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            GridUtil.ExportToExcelXlsx(gridView: this.grdViewChungTu, showOpenFilePrompt: true);
        }

        private void grdViewChungTu_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (_chungTuList_TimDuoc != null && _chungTuList_TimDuoc.Count() > 0)
            {
                GridView View = sender as GridView;

                string TrangThaiString = View.GetRowCellDisplayText(e.RowHandle, "TrangThai");
                if (TrangThaiString == "0")
                {
                    e.Appearance.BackColor = Color.FromArgb(150, Color.LightCoral);
                }
                //else if (TrangThaiString == "1")
                //{
                //    e.Appearance.BackColor = Color.FromArgb(150, Color.LightSkyBlue);
                //}
                //else
                //{
                //    e.Appearance.BackColor = Color.FromArgb(150, Color.LightYellow);
                //}
             
            }
        }
    }
}