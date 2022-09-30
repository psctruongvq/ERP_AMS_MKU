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
using System.Drawing;
using ERP_Library;

namespace PSC_ERPNew.Main
{
    public partial class frmDanhSachTaiSuDungTSCDCaBiet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDanhSachTaiSuDungTSCDCaBiet singleton_ = null;
        public static frmDanhSachTaiSuDungTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDanhSachTaiSuDungTSCDCaBiet();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion     

        //Private Member field
        #region Private Member field
        IQueryable<tblNVNgungvaTaiSuDungTSCD> _nVNgungVaTaiSuDungList_TimDuoc = null;
        NVNgungvaTaiSuDungTSCD_Factory _factory = null;
        #endregion

        //Member Constructor
        #region Member Constructor

        public frmDanhSachTaiSuDungTSCDCaBiet()
        {
            InitializeComponent();
            //đặt ngày mặc định cho thông tin tìm kiếm
            dteNgayChungTu.DateTime = app_users_Factory.New().SystemDate;
            dteNgayChungTu_Den.DateTime = dteNgayChungTu.DateTime;
            //cài đặt double click event cho grid view chứng từ
            GridUtil.DoubleClickHelper.Setup(this.grdViewNgungSuDungTSCDCaBiet, (object sender, EventArgs e) =>
            {
                //xem lại chứng từ
                GridView view = sender as GridView;
                tblNVNgungvaTaiSuDungTSCD nVNgungVaTaiSuDung = view.GetFocusedRow() as tblNVNgungvaTaiSuDungTSCD;
                if (nVNgungVaTaiSuDung != null)
                {
                    Form frm = null;
                    if (nVNgungVaTaiSuDung.CurrentForm_AddedObj == null || (nVNgungVaTaiSuDung.CurrentForm_AddedObj as Form).IsDisposed)
                    {
                        frm = new frmTaiSuDungTSCDCaBiet(Convert.ToInt32(nVNgungVaTaiSuDung.MaNghiepVu));
                        nVNgungVaTaiSuDung.CurrentForm_AddedObj = frm;
                    }
                    else
                        frm = nVNgungVaTaiSuDung.CurrentForm_AddedObj as frmTaiSuDungTSCDCaBiet;

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
            LoaiTimChungTuEnum loaiTim = LoaiTimChungTuEnum.TatCa;
            CompareTypeEnum compareType = CompareTypeEnum.Equal;

            //xác định phương pháp
            XacDinhPhuongPhapTim(ref loaiTim, ref compareType);
            _factory = NVNgungvaTaiSuDungTSCD_Factory.New();
            //tìm
            _nVNgungVaTaiSuDungList_TimDuoc = _factory.TimKiem_TaiSuDung(loaiTim: loaiTim
                , compareType: compareType
                , soChungTu: txtSoChungTu.Text.Trim()
                , ngayChungTu: dteNgayChungTu.DateTime
                , ngayChungTuDen: dteNgayChungTu_Den.DateTime
                , userID: PSC_ERP_Global.Main.UserID);
            //gán binding source
            tblNVNgungvaTaiSuDungTSCDBindingSource.DataSource = _nVNgungVaTaiSuDungList_TimDuoc;
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

        //Event Method
        #region Event Method

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_TaiSuDung, this.MdiParent);
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gọi thêm mới chứng từ ghi tăng tài sản
            //frmTaiSuDungTSCDCaBiet frm = new frmTaiSuDungTSCDCaBiet();
            //frm.MdiParent = this.MdiParent;
            //frm.Show();

            frmTaiSuDungTSCDCaBiet.ShowSingleton(null, this.MdiParent);
        }
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //tìm chứng từ ngừng sử dụng
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
        private void PhanQuyenThemSuaXoa()
        {
            PhanQuyenSuDungForm _phanQuyen = PhanQuyenSuDungForm.GetQuyenSuDungFormTheoUser(ERP_Library.Security.CurrentUser.Info.UserID, (this.GetType().Namespace + "." + this.Name));
            btnThemMoi.Enabled = _phanQuyen.Them;

        }
        private void frmDanhSachDieuChuyenNoiBoTSCDCaBiet_Load(object sender, EventArgs e)
        {
            // Cài đặt lưới
            GridUtil.SetSTTForGridView(this.grdViewNgungSuDungTSCDCaBiet);
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
                catch (Exception ex)
                {
                    Tim();
                }
            };
            PhanQuyenThemSuaXoa();
        }
        #endregion

        private void grdViewNgungSuDungTSCDCaBiet_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (_nVNgungVaTaiSuDungList_TimDuoc != null && _nVNgungVaTaiSuDungList_TimDuoc.Count() > 0)
            {
                GridView View = sender as GridView;

                string TrangThaiString = View.GetRowCellDisplayText(e.RowHandle, "TinhTrang");
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