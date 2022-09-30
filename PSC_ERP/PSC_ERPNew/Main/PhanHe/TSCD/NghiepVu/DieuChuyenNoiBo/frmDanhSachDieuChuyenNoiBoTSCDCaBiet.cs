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

namespace PSC_ERPNew.Main
{
    public partial class frmDanhSachDieuChuyenNoiBoTSCDCaBiet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDanhSachDieuChuyenNoiBoTSCDCaBiet singleton_ = null;
        public static frmDanhSachDieuChuyenNoiBoTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDanhSachDieuChuyenNoiBoTSCDCaBiet();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion      

        //Private Member field
        #region Private Member field
        IQueryable<tblNghiepVuDieuChuyenNoiBo> _nghiepVuList_TimDuoc = null;
        NghiepVuDieuChuyenNoiBo_Factory _factory = null;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDanhSachDieuChuyenNoiBoTSCDCaBiet()
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
                _factory = NghiepVuDieuChuyenNoiBo_Factory.New();
                //tìm
                _nghiepVuList_TimDuoc = _factory.TimKiem(loaiTim: loaiTim
                    , compareType: compareType
                    , soChungTu: txtSoChungTu.Text.Trim()
                    , ngayChungTu: dteNgayChungTu.DateTime
                    , ngayChungTuDen: dteNgayChungTu_Den.DateTime
                    , userID: PSC_ERP_Global.Main.UserID);
                //gán binding source
                tblNghiepVuDieuChuyenNoiBoBindingSource.DataSource = _nghiepVuList_TimDuoc;
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

        //Event Method
        #region Event Method
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gọi thêm mới chứng từ ghi tăng tài sản
            //frmDieuChuyenNoiBoTSCDCaBiet frm = new frmDieuChuyenNoiBoTSCDCaBiet();
            //frm.MdiParent = this.MdiParent;
            //frm.Show();
            frmDieuChuyenNoiBoTSCDCaBiet.ShowSingleton(null, this.MdiParent);
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
        private void frmDanhSachDieuChuyenNoiBoTSCDCaBiet_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //đặt ngày mặc định cho thông tin tìm kiếm
                dteNgayChungTu.DateTime = app_users_Factory.New().SystemDate;
                dteNgayChungTu_Den.DateTime = dteNgayChungTu.DateTime;
                //cài đặt double click event cho grid view chứng từ
                GridUtil.DoubleClickHelper.Setup(this.grdViewNghiepVuDieuChuyenNoiBo, (object senderz1, EventArgs ez1) =>
                {
                    //xem lại chứng từ
                    GridView view = senderz1 as GridView;
                    tblNghiepVuDieuChuyenNoiBo nghiepVuDieuChuyenNoiBo = view.GetFocusedRow() as tblNghiepVuDieuChuyenNoiBo;
                    if (nghiepVuDieuChuyenNoiBo != null)
                    {
                        Form frm = null;
                        if (nghiepVuDieuChuyenNoiBo.CurrentForm_AddedObj == null || (nghiepVuDieuChuyenNoiBo.CurrentForm_AddedObj as Form).IsDisposed)
                        {
                            frm = new frmDieuChuyenNoiBoTSCDCaBiet(Convert.ToInt32(nghiepVuDieuChuyenNoiBo.MaNghiepVuDieuChuyenNoiBo));
                            nghiepVuDieuChuyenNoiBo.CurrentForm_AddedObj = frm;
                        }
                        else
                            frm = nghiepVuDieuChuyenNoiBo.CurrentForm_AddedObj as frmDieuChuyenNoiBoTSCDCaBiet;

                        //show form
                        FormUtil.ShowForm_Helper(frm, null, this.MdiParent);//frm.Show();
                    }
                });
                // Cài đặt lưới
                GridUtil.SetSTTForGridView(this.grdViewNghiepVuDieuChuyenNoiBo);
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
            };
        }
        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.TSCD_DieuChuyenNoiBo, this.MdiParent);
        }
        #endregion

        private void grdViewNghiepVuDieuChuyenNoiBo_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (_nghiepVuList_TimDuoc != null && _nghiepVuList_TimDuoc.Count() > 0)
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