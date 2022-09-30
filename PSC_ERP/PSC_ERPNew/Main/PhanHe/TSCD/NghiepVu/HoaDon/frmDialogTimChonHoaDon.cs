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
using PSC_ERP;

namespace PSC_ERPNew.Main
{
    public partial class frmDialogTimChonHoaDon : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDialogTimChonHoaDon singleton_ = null;
        public static frmDialogTimChonHoaDon Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogTimChonHoaDon();
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



        //Private Member field
        #region Private Member field
        HoaDonTaiSan_DerivedFactory _hoaDonTaiSan_DerivedFactory = null;
        IQueryable<tblHoaDon> _hoaDonTimKiemList = null;
        IQueryable<tblHoaDon> _hoaDonDuocChonList = null;
        IQueryable<tblDoiTac> _doiTacList = null;
        tblChungTu _chungTu = null;
        //tblButToan _butToan = null;
        #endregion


        //Public Member Property
        #region Public Member Property
        public IQueryable<tblHoaDon> HoaDonDuocChonList
        {
            get { return _hoaDonDuocChonList; }
        }

        #endregion

        //Member Constructor
        #region Member Constructor

        public frmDialogTimChonHoaDon()
        {
            InitializeComponent();
        }
        public frmDialogTimChonHoaDon(tblChungTu chungTu//, tblButToan butToan
            , long maDoiTac)
        {
            InitializeComponent();
            _chungTu = chungTu;
            //_butToan = butToan;
            cbDoiTac.EditValue = maDoiTac;//mã đối tác này dùng để tìm kiếm tự động các hóa đơn của đổi tác khi load form
            this.DialogResult = DialogResult.No;
        }

        #endregion



        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {

            _doiTacList = DoiTac_Factory.New().GetAll();
            GanBindingSource();

        }
        private void Tim()
        {
            using (DialogUtil.Wait(this))
            {
                txtBlackHole.Focus();
                //
                LoaiTimHoaDonEnum loaiTim = LoaiTimHoaDonEnum.TatCa;
                CompareTypeEnum compareType = CompareTypeEnum.Equal;

                //xác định phương pháp
                XacDinhPhuongPhapTim(ref loaiTim, ref compareType);

                _hoaDonTaiSan_DerivedFactory = HoaDonTaiSan_DerivedFactory.New();
                //tìm
                _hoaDonTimKiemList = _hoaDonTaiSan_DerivedFactory.TimKiem(loaiTim: loaiTim
                    , compareType: compareType
                    , soHoaDon: txtSoHopDong.Text.Trim()
                    , serial: txtTenHopDong.Text.Trim()
                    , soTien: Decimal.Parse(txtSoTien.Text.Trim())
                    , phanTramThueVAT: Double.Parse(txtPhanTramThueVAT.Text.Trim())
                    , tienThueVAT: Decimal.Parse(txtTienThueVAT.Text.Trim())
                    , tongTien: Decimal.Parse(txtTongTien.Text.Trim())
                    , ngayLap: dteNgayLap.DateTime
                    , ngayLapDen: dteNgayLap_Den.DateTime
                    , maDoiTac: (Int64)cbDoiTac.EditValue);
                //gán binding source
                GanBindingSource();
            }
        }

        private void XacDinhPhuongPhapTim(ref LoaiTimHoaDonEnum loaiTim, ref CompareTypeEnum compareType)
        {
            if (radioChonTatCa.Checked)
                loaiTim = LoaiTimHoaDonEnum.TatCa;
            else if (radioChonSoHoaDon.Checked)
            {
                loaiTim = LoaiTimHoaDonEnum.SoHoaDon;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoSoHoaDon.EditValue);
            }
            else if (radioChonSerial.Checked)
            {
                loaiTim = LoaiTimHoaDonEnum.Serial;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoSerial.EditValue);
            }
            else if (radioChonNgayLap.Checked)
            {
                loaiTim = LoaiTimHoaDonEnum.NgayLap;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoNgayLap.EditValue);
            }
            else if (radioChonSoTien.Checked)
            {
                loaiTim = LoaiTimHoaDonEnum.SoTien;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoSoTien.EditValue);
            }
            else if (radioChonPhanTramThueVAT.Checked)
            {
                loaiTim = LoaiTimHoaDonEnum.PhanTramThueVAT;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoPhanTramThueVAT.EditValue);
            }
            else if (radioChonTienThueVAT.Checked)
            {
                loaiTim = LoaiTimHoaDonEnum.TienThueVAT;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoTienThueVAT.EditValue);
            }
            else if (radioChonTongTien.Checked)
            {
                loaiTim = LoaiTimHoaDonEnum.TongTien;
                compareType = (CompareTypeEnum)((Int32)radioGroupPhuongPhapTim_TheoTongTien.EditValue);
            }
            else if (radioChonDoiTac.Checked)
            {
                loaiTim = LoaiTimHoaDonEnum.DoiTac;
                compareType = CompareTypeEnum.Equal;
            }
        }
        private void GanBindingSource()
        {
            tblHoaDonBindingSource.DataSource = _hoaDonTimKiemList;
            tblDoiTacBindingSource.DataSource = _doiTacList;
            loaiHoaDonBindingSource.DataSource = LoaiHoaDon.LoaiHoaDonList;
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

        private void btnDuaDuLieuVeChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            //lấy những dòng được chọn
            _hoaDonDuocChonList = (from o in _hoaDonTimKiemList.ToList()
                                   where o.Chon == true
                                   orderby o.NgayLap
                                   select o).AsQueryable();
            //Detach
            _hoaDonTaiSan_DerivedFactory.Detach(_hoaDonDuocChonList);

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        private void btnThemHoaDonMuaVaoCoVAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_chungTu.MaDoiTuong == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn đối tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao((_chungTu.MaDoiTuong ?? 0), _chungTu.NgayLap.Value, false);
                frmhoadondichvu.ShowDialog();
                this.Tim();
            }


            //////tạo hóa đơn mới
            //frmHoaDon frm = new frmHoaDon(chungTu: _chungTu, butToan: _butToan, coVAT: true);
            //frm.Show();
        }
        private void btnThemHoaDonMuaVaoKhongCoVAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {  
            //tạo hóa đơn mới
            if (_chungTu.MaDoiTuong == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn đối tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao((_chungTu.MaDoiTuong ?? 0), _chungTu.NgayLap.Value, true);
                frmhoadondichvu.ShowDialog();
                this.Tim();
            }

          
            //frmHoaDon frm = new frmHoaDon(chungTu: _chungTu, butToan: _butToan, coVAT: false);
            //frm.Show();
        }
        private void frmDialogTimChonHoaDon_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                using (DialogUtil.Wait(this))
                {
                    this.LoadData();
                    //đặt ngày mặc định cho thông tin tìm kiếm
                    dteNgayLap.DateTime = app_users_Factory.New().SystemDate;
                    dteNgayLap.DateTime = dteNgayLap.DateTime;

                    // Cài đặt lưới
                    PSC_ERP_Common.GridUtil.SetSTTForGridView(this.grdViewHoaDon);
                    //cài đặt radio group
                    RadioUtil.RadioGroup.Setup(false, new CheckEdit[] { radioChonTatCa, radioChonSoHoaDon, radioChonNgayLap, radioChonSoTien, radioChonPhanTramThueVAT, radioChonTienThueVAT, radioChonTongTien, radioChonDoiTac });

                    // Đưa checkbox lên lưới
                    PSC_ERP_Common.GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewHoaDon, colChon);

                    PSC_ERP_Common.GridUtil.DoubleClickHelper.Setup(this.grdViewHoaDon, (object senderz1, EventArgs ez1) =>
                    {
                        //xem lại chứng từ
                        GridView view = senderz1 as GridView;
                        tblHoaDon entityHoaDon = view.GetFocusedRow() as tblHoaDon;
                        if (entityHoaDon != null)
                        {
                            Form frm = null;

                            //frm = new frmHoaDon(_chungTu, _butToan, hoaDon.MaHoaDon);

                            //show form
                            //frm.ShowDialog();
                            //tìm lại
                            //this.Tim();

                            //////

                            ERP_Library.HoaDon cslaHoaDon = ERP_Library.HoaDon.NewHoaDon();
                            cslaHoaDon = ERP_Library.HoaDon.GetHoaDon(entityHoaDon.MaHoaDon);
                            if (entityHoaDon.LoaiHoaDon == 4) // mua vao 
                            {
                                frm = new frmHoaDonDichVuMuaVao(cslaHoaDon);
                            }
                            else // ban ra
                            {
                                frm = new frmHoaDonDichVuBanRa(cslaHoaDon);

                            }
                            frm.ShowDialog();
                            //tìm lại
                            this.Tim();

                            ////////////
                        }
                    });
                    //
                    //tự động tìm
                    this.Tim();
                }
            };
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdViewHoaDon.SelectedRowsCount == 0)
                DialogUtil.ShowWarning("Vui lòng chọn dòng cần xóa");
            else
                if (PSC_ERP_Common.DialogUtil.ShowYesNo("Bạn muốn xóa những dòng đang chọn?") == DialogResult.Yes)
                {
                    using (DialogUtil.WaitForDelete())
                    {
                        Int32[] deleteRowHandleList = grdViewHoaDon.GetSelectedRows();
                        //grdViewHoaDon.GetRow();
                        List<Object> deleteList = new List<Object>();
                        foreach (Int32 handle in deleteRowHandleList)
                        {
                            tblHoaDon hoaDon = grdViewHoaDon.GetRow(handle) as tblHoaDon;
                            //dua vao danh sach nhung hoa don cua user hien tai
                            if (hoaDon.MaNguoiLap == PSC_ERP_Global.Main.UserID)
                                deleteList.Add(hoaDon);
                        }

                        try
                        {
                            HoaDon_Factory tmpFactory = HoaDon_Factory.New();
                            HoaDon_Factory.FullDelete(tmpFactory.Context, deleteList);
                            tmpFactory.SaveChangesWithoutTrackingLog();
                            DialogUtil.ShowInfo("Xóa hóa đơn thành công");
                        }
                        catch (System.Exception ex)
                        {
                            DialogUtil.ShowError("Xóa hóa thất bại. Error: " + ex.Message);
                        }
                    }//
                }
        }

        #endregion














    }
}