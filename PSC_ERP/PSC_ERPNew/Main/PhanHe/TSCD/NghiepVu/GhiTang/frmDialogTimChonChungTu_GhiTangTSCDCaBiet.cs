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
    public partial class frmDialogTimChonChungTu_GhiTangTSCDCaBiet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDialogTimChonChungTu_GhiTangTSCDCaBiet singleton_ = null;
        public static frmDialogTimChonChungTu_GhiTangTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogTimChonChungTu_GhiTangTSCDCaBiet();
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
        ChungTuGhiTangTaiSan_DerivedFactory _factory = null;
        IQueryable<tblChungTu> _chungTuList_TimDuoc = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        IQueryable<tblChungTu> _chungTuDuocChonList = null;
        #endregion

        //Public Member Property
        #region Public Member Property
        public IQueryable<tblChungTu> ChungTuDuocChonList
        {
            get { return _chungTuDuocChonList; }
        }
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmDialogTimChonChungTu_GhiTangTSCDCaBiet()
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
                        frm = new frmGhiTangTSCDCaBiet(chungTu);//(chungTu.MaChungTu);
                        chungTu.CurrentForm_AddedObj = frm;
                    }
                    else
                        frm = chungTu.CurrentForm_AddedObj as frmGhiTangTSCDCaBiet;

                    //show form
                    PSC_ERP_Common.FormUtil.ShowForm_Helper(frm, null);//frm.Show();
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
            //
            _factory = ChungTuGhiTangTaiSan_DerivedFactory.New();
            //tìm
            _chungTuList_TimDuoc = _factory.TimKiem(loaiTim: loaiTim
                , compareType: compareType
                , soChungTu: txtSoChungTu.Text.Trim()
                , soTien: Decimal.Parse(txtSoTien.Text.Trim())
                , soTienDen: Decimal.Parse(txtSoTien_Den.Text.Trim())
                , ngayChungTu: dteNgayChungTu.DateTime
                , ngayChungTuDen: dteNgayChungTu_Den.DateTime
                , maDoiTac: (Int64)cbDoiTac.EditValue);
            //gán binding source
            tblChungTuBindingSource.DataSource = _chungTuList_TimDuoc;
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
        private void frmDialogTimChonChungTu_GhiTangTSCDCaBiet_Load(object sender, EventArgs e)
        {
            //load đối tác
            LoadDoiTac();
            // Cài đặt lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewChungTu);
            //cài đặt radio group
            RadioUtil.RadioGroup.Setup(false, new CheckEdit[] { radioChonTatCa, radioChonSoChungTu, radioChonNgayChungTu, radioChonSoTien, radioChonDoiTac });
            // Đưa checkbox lên lưới
            PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewChungTu, colChon);
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //gọi thêm mới chứng từ ghi tăng tài sản
            frmGhiTangTSCDCaBiet frm = new frmGhiTangTSCDCaBiet();
            frm.ShowDialog();
            this.Tim();
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
        private void btnDuaDuLieuVeChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            //lấy những dòng được chọn
            _chungTuDuocChonList = (from o in _chungTuList_TimDuoc.ToList()
                                    where o.Chon == true
                                    orderby o.NgayLap
                                    select o).AsQueryable();
            //Detach
            _factory.Detach(_chungTuDuocChonList);

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion

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