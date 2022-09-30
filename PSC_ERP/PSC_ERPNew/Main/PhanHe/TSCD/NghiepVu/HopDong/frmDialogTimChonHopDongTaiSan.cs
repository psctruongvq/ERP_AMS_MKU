using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERPNew.Main
{
    public partial class frmDialogTimChonHopDongTaiSan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDialogTimChonHopDongTaiSan singleton_ = null;
        public static frmDialogTimChonHopDongTaiSan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogTimChonHopDongTaiSan(0);
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
        //Public Static Field
        #region Public Static Field

        #endregion
        //Private Static Property
        #region Private Static Property

        #endregion
        //Public Static Property
        #region Public Static Property

        #endregion
        //Static Constructor
        #region Static Constructor

        #endregion

        //Private Static Function
        #region Private Static Function

        #endregion

        //Public Static Function
        #region Public Static Function

        #endregion

        //Private Member field
        #region Private Member field
        HopDongTaiSan_DerivedFactory _hopDongTaiSan_DerivedFactory = null;
        IQueryable<tblHopDong> _hopDongTimKiemList = null;
        IQueryable<tblHopDong> _hopDongDuocChonList = null;
        List<tblDoiTac> _doiTacList = null;
        long _maDoiTac_TruyenVao = 0;
        #endregion

        //Public Member field
        #region Public Member field

        #endregion

        //Public Member Property
        #region Public Member Property
        public IQueryable<tblHopDong> HopDongDuocChonList
        {
            get { return _hopDongDuocChonList; }
        }

        #endregion

        //Member Constructor
        #region Member Constructor


        public frmDialogTimChonHopDongTaiSan(long maDoiTac)
        {
            InitializeComponent();
            cbDoiTac.EditValue = maDoiTac;//mã đối tác này dùng để tìm kiếm tự động các hợp đồng của đổi tác khi load form
            _maDoiTac_TruyenVao = maDoiTac;
            this.DialogResult = DialogResult.No;
            this.LoadData();

        }

        #endregion



        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            using (DialogUtil.Wait())
            {
                _doiTacList = DoiTac_Factory.New().GetAll().ToList();
                tblDoiTac doTac_chonTatCa = new tblDoiTac() { MaDoiTac = 0, TenDoiTac = "<<Tất cả>>", MaQLDoiTac = "<<Tất cả>>", TenVietTat = "<<Tất cả>>" };
                _doiTacList.Insert(0, doTac_chonTatCa);
                GanBindingSource();
            }
        }
        private void Tim()
        {
            using (DialogUtil.Wait())
            {
                txtBlackHole.Focus();
                //
                LoaiTimHopDongEnum loaiTim = LoaiTimHopDongEnum.TatCa;
                CompareTypeEnum compareType = CompareTypeEnum.Equal;

                //xác định phương pháp
                XacDinhPhuongPhapTim(ref loaiTim, ref compareType);

                //tìm
                _hopDongTaiSan_DerivedFactory = HopDongTaiSan_DerivedFactory.New();
                _hopDongTimKiemList = _hopDongTaiSan_DerivedFactory.TimKiem(loaiTim: loaiTim
                    , compareType: compareType
                    , soHopDong: txtSoHopDong.Text.Trim()
                    , tenHopDong: txtTenHopDong.Text.Trim()
                    , soTien: Decimal.Parse(txtSoTien.Text.Trim())
                    , soTienDen: Decimal.Parse(txtSoTien_Den.Text.Trim())
                    , ngayKy: dteNgayKy.DateTime
                    , ngayKyDen: dteNgayKy_Den.DateTime
                    , maDoiTac: (Int64)cbDoiTac.EditValue);
                //gán binding source
                GanBindingSource();
            }
        }

        private void XacDinhPhuongPhapTim(ref LoaiTimHopDongEnum loaiTim, ref CompareTypeEnum compareType)
        {
            if (radioChonTatCa.Checked)
                loaiTim = LoaiTimHopDongEnum.TatCa;
            else if (radioChonSoHopDong.Checked)
            {
                loaiTim = LoaiTimHopDongEnum.SoHopDong;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoSoHopDong.EditValue);
            }
            else if (radioChonTenHopDong.Checked)
            {
                loaiTim = LoaiTimHopDongEnum.TenHopDong;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoTenHopDong.EditValue);
            }
            else if (radioChonNgayKy.Checked)
            {
                loaiTim = LoaiTimHopDongEnum.NgayKy;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoNgayKy.EditValue);
            }
            else if (radioChonSoTien.Checked)
            {
                loaiTim = LoaiTimHopDongEnum.SoTien;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoSoTien.EditValue);
            }
            else if (radioChonDoiTac.Checked)
            {
                loaiTim = LoaiTimHopDongEnum.DoiTac;
                compareType = CompareTypeEnum.Equal;
            }
        }
        private void GanBindingSource()
        {
            tblHopDongBindingSource.DataSource = _hopDongTimKiemList;
            if (_doiTacList != null)
                tblDoiTacBindingSource.DataSource = _doiTacList;
        }
        #endregion


        //Public Member Function
        #region Public Member Function

        #endregion

        //Event Method
        #region Event Method

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Tim();
        }

        private void btnDuaDuLieuVeChungTuGhiTang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            //lấy những dòng được chọn

            _hopDongDuocChonList = (from o in _hopDongTimKiemList
                                    where o.Chon == true
                                    orderby o.NgayLap
                                    select o);
            //Detach
            _hopDongTaiSan_DerivedFactory.Detach(_hopDongDuocChonList.AsQueryable());

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void btnThemMoiHopDongMuaSam_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERP.frmHopDongMuaSam frm = new PSC_ERP.frmHopDongMuaSam(_maDoiTac_TruyenVao);          
            frm.MdiParent = this.MdiParent;
            frm.Show();
        }
        private void btnThemMoiHopDongDuAn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERP.frmHopDongDuAn frm = new PSC_ERP.frmHopDongDuAn(_maDoiTac_TruyenVao);
            frm.MdiParent = this.MdiParent;
            frm.defaultLookAndFeel1.LookAndFeel.SkinName = BasicInfo.User.UserInterfaceTheme;
            frm.Show();

        }
        private void frmDialogTimChonHopDongTaiSan_Load(object sender, EventArgs e)
        {
            //đặt ngày mặc định cho thông tin tìm kiếm
            dteNgayKy.DateTime = app_users_Factory.New().SystemDate;
            dteNgayKy_Den.DateTime = dteNgayKy.DateTime;

            // Cài đặt lưới
            PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewHopDong);
            //cài đặt radio group
            RadioUtil.RadioGroup.Setup(false, new CheckEdit[] { radioChonTatCa, radioChonSoHopDong, radioChonNgayKy, radioChonSoTien, radioChonDoiTac });
            // Đưa checkbox lên lưới
            PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewHopDong, colChon);
            //cài đặt double click event cho grid view chứng từ
            GridUtil.DoubleClickHelper.Setup(this.grdViewHopDong, (object senderz, EventArgs ez) =>
            {
                //xem lại chứng từ

                GridView view = senderz as GridView;
                tblHopDong hopDong = view.GetFocusedRow() as tblHopDong;
                if (hopDong != null)
                {
                    ERP_Library.HopDongThuChi hopDongThuChi = ERP_Library.HopDongThuChi.GetHopDongMuaBan(hopDong.MaHopDong);

                    XtraForm frm = new XtraForm();
                    if (hopDong.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongMuaSam || hopDong.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongDuAn)
                    {
                        if (hopDongThuChi.LaPhuLuc)
                            frm = new PSC_ERP.FrmPhuLucHopDongMuaSam(hopDongThuChi, true);
                        else
                            frm = new PSC_ERP.frmHopDongMuaSam(hopDongThuChi);


                    }
                    else if (hopDong.tblHopDongMuaBan.tblLoaiHopDong.MaQuanLy == PSC_ERP_Global.TSCD.MaQLHopDongDuAn)
                    {
                        if (hopDongThuChi.LaPhuLuc)
                            frm = new PSC_ERP.FrmPhuLucHopDongDuAn(hopDongThuChi, true);
                        else
                            frm = new PSC_ERP.frmHopDongDuAn(hopDongThuChi);
                    }
                    //frm.ShowDialog();
                    //thiết lập lại theme
                    try
                    {
                        dynamic form = frm;
                        form.defaultLookAndFeel1.LookAndFeel.SkinName = BasicInfo.User.UserInterfaceTheme;
                    }
                    catch (System.Exception ex)
                    {

                    }

                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        btnTim.PerformClick();

                    }
                }

            });

            //tự động tìm
            this.Tim();


        }
        #endregion













    }
}