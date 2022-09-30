using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERP
{
    public partial class frmThongTinBoSungThuyetMinhBCTC : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private ThongTinBoSungBangThuyetMinhBCTCEditableRootList _ThongTinBoSungBangThuyetMinhBCTCList = ThongTinBoSungBangThuyetMinhBCTCEditableRootList.NewThongTinBoSungBangThuyetMinhBCTCEditableRootList();
        int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        int _userID = ERP_Library.Security.CurrentUser.Info.UserID;
        //--
        private int _maMuc = 0;

        private BindingSource _kyBaoCaoKeToanBindingSource = new BindingSource();

        private DateTime _TuNgay = DateTime.Today.Date;
        private DateTime _DenNgay = DateTime.Today.Date;
        private bool _loadFirst = false;
        #endregion

        #region Constructors
        public frmThongTinBoSungThuyetMinhBCTC(int mamuc, string tenMuc)
        {
            InitializeComponent();
            _maMuc = mamuc;
            txtTenMuc.Text = tenMuc;
            txtTenMuc.Properties.ReadOnly = true;
            KhoiTao();
            _loadFirst = true;
            KhoiTaoThongTinBoSungBangThuyetMinhBCTCList();
            _loadFirst = false;
        }
        #endregion Constructors

        #region Function
        private void DesignKyBaoCaogridLookUpEdit()
        {
            _kyBaoCaoKeToanBindingSource.DataSource = KyBaoCaoKeToan.CreateListKyBaoCaoKeToan();
            HamDungChung.InitGridLookUpDev2(KyBaoCaogridLookUpEdit, _kyBaoCaoKeToanBindingSource, "MoTa", "Ma", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(KyBaoCaogridLookUpEdit, new string[] { "MoTa" }, new string[] { "" }, new int[] { 300 }, false);
            KyBaoCaogridLookUpEdit.EditValueChanged += new System.EventHandler(this.KyBaoCaogridLookUpEdit_EditValueChanged);

            KyBaoCaogridLookUpEdit.EditValue = "TuyChon";
        }

        private void DesignCTCongThucMauBieuBCgridView()
        {
            #region MyRegion 2
            ThongTinBoSungThuyetMinhBCTCgridControl.DataSource = ThongTinBoSungBangThuyetMinhBCTCList_bindingSource1;
            HamDungChung.InitGridViewDev(ThongTinBoSungThuyetMinhBCTCgridView, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, true, false, true);
            HamDungChung.ShowFieldGridViewDev2(ThongTinBoSungThuyetMinhBCTCgridView, new string[] { "TenDoiTuong", "SoTienCK", "SoTienDK", "GhiChu", "TuNgay", "DenNgay" },
                                new string[] { "Tên đối tượng", "Số cuối kỳ", "Số đầu kỳ", "Ghi chú", "Từ ngày", "Đến ngày" },
                                             new int[] { 150, 100, 100, 300, 75, 75 }, true);
            HamDungChung.AlignHeaderColumnGridViewDev(ThongTinBoSungThuyetMinhBCTCgridView, new string[] { "TenDoiTuong", "SoTienCK", "SoTienDK", "GhiChu", "TuNgay", "DenNgay" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(ThongTinBoSungThuyetMinhBCTCgridView, new string[] { "SoTienCK", "SoTienDK" }, "#,###.##");
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(ThongTinBoSungThuyetMinhBCTCgridView, new string[] { "TuNgay", "DenNgay" }, "dd/MM/yyyy");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(ThongTinBoSungThuyetMinhBCTCgridView, new string[] { "SoTienCK", "SoTienDK" }, "{0:#,###.#}");
            HamDungChung.NewRowGridViewDev(ThongTinBoSungThuyetMinhBCTCgridView);

            Utils.GridUtils.SetSTTForGridView(ThongTinBoSungThuyetMinhBCTCgridView, 30);//M

            HamDungChung.ReadOnlyColumnChoseGridViewDev(ThongTinBoSungThuyetMinhBCTCgridView, new string[] { "TuNgay", "DenNgay" });

            ////this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            //this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.ThongTinBoSungThuyetMinhBCTCgridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ThongTinBoSungThuyetMinhBCTCgridView_KeyDown);
            this.ThongTinBoSungThuyetMinhBCTCgridView.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.ThongTinBoSungThuyetMinhBCTCgridView_InitNewRow);
            //this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);

            //this.gridView1.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridView1_FocusedColumnChanged);

            //this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey); 
            ThongTinBoSungThuyetMinhBCTCgridView.GroupPanelText = "Thiết Lập Thông Tin Bổ Sung Bảng Thuyết Minh BCTC";
            #endregion

        }

        private void DesignGridControl()
        {
            DesignKyBaoCaogridLookUpEdit();
            DesignCTCongThucMauBieuBCgridView();
        }

        private void KhoiTao()
        {
            ThongTinBoSungBangThuyetMinhBCTCList_bindingSource1.DataSource = typeof(ThongTinBoSungBangThuyetMinhBCTCEditableRootList);


            ThongTinBoSungBangThuyetMinhBCTCList_bindingSource1.DataSource = _ThongTinBoSungBangThuyetMinhBCTCList;

            DesignGridControl();
        }

        private void KhoiTaoThongTinBoSungBangThuyetMinhBCTCList()
        {
            GetThongTin();
            _ThongTinBoSungBangThuyetMinhBCTCList = ThongTinBoSungBangThuyetMinhBCTCEditableRootList.NewThongTinBoSungBangThuyetMinhBCTCEditableRootList();
            if (_loadFirst == false && _DenNgay >= _TuNgay)
            {
                _ThongTinBoSungBangThuyetMinhBCTCList = ThongTinBoSungBangThuyetMinhBCTCEditableRootList.GetThongTinBoSungBangThuyetMinhBCTCEditableRootList(_maMuc, _TuNgay, _DenNgay);
            }
            if (_ThongTinBoSungBangThuyetMinhBCTCList == null || _ThongTinBoSungBangThuyetMinhBCTCList.Count == 0)
            {
                _ThongTinBoSungBangThuyetMinhBCTCList = ThongTinBoSungBangThuyetMinhBCTCEditableRootList.NewThongTinBoSungBangThuyetMinhBCTCEditableRootList();
            }
            BindingData();

        }
        private void BindingData()
        {
            ThongTinBoSungBangThuyetMinhBCTCList_bindingSource1.DataSource = _ThongTinBoSungBangThuyetMinhBCTCList;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = true;
            return kq;

        }


        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (KiemTraDuLieu())
                {
                    ThongTinBoSungBangThuyetMinhBCTCList_bindingSource1.EndEdit();
                    _ThongTinBoSungBangThuyetMinhBCTCList.ApplyEdit();
                    _ThongTinBoSungBangThuyetMinhBCTCList.Save();
                }
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }


        private bool CheckInputTuNgay()
        {
            if (TuNgay_dateEdit.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Ngày để lập thông tin bổ sung!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TuNgay_dateEdit.Focus();
                return false;
            }
            DateTime dateOut;
            if (DateTime.TryParse(TuNgay_dateEdit.EditValue.ToString(), out dateOut))
            {
                _TuNgay = dateOut.Date;
            }
            return true;
        }
        private bool CheckInputDenNgay()
        {
            if (DenNgay_dateEdit.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để lập thông tin bổ sung!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DenNgay_dateEdit.Focus();
                return false;
            }
            DateTime dateOut;
            if (DateTime.TryParse(DenNgay_dateEdit.EditValue.ToString(), out dateOut))
            {
                _DenNgay = dateOut.Date;
            }
            return true;
        }

        private void GetThongTin()
        {
            DateTime dateOut;
            if (DateTime.TryParse(TuNgay_dateEdit.EditValue.ToString(), out dateOut))
            {
                _TuNgay = dateOut.Date;
            }
            if (DateTime.TryParse(DenNgay_dateEdit.EditValue.ToString(), out dateOut))
            {
                _DenNgay = dateOut.Date;
            }
        }

        private void setvaluesDefault(ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable ttbs)
        {
            ttbs.MaMuc = _maMuc;
            ttbs.TuNgay = _TuNgay;
            ttbs.DenNgay = _DenNgay;
        }

        #endregion

        #region Event


        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                MessageBox.Show(this, "Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Cậpnhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private void TuNgay_dateEdit_Leave(object sender, EventArgs e)
        {
            if (TuNgay_dateEdit.OldEditValue != TuNgay_dateEdit.EditValue)
            {
                if (KyBaoCaogridLookUpEdit.EditValue != "TuyChon")
                    KhoiTaoThongTinBoSungBangThuyetMinhBCTCList();

            }
        }

        private void DenNgay_dateEdit_Leave(object sender, EventArgs e)
        {
            if (DenNgay_dateEdit.OldEditValue != DenNgay_dateEdit.EditValue)
            {
                KhoiTaoThongTinBoSungBangThuyetMinhBCTCList();

            }
        }

        private void KyBaoCaogridLookUpEdit_Leave(object sender, EventArgs e)
        {
            if (KyBaoCaogridLookUpEdit.OldEditValue != KyBaoCaogridLookUpEdit.EditValue)
            {
                if (KyBaoCaogridLookUpEdit.EditValue == "TuyChon") return;
                KhoiTaoThongTinBoSungBangThuyetMinhBCTCList();

            }
        }

        #endregion

        #region Event handles
        //KyBaoCaogridLookUpEdit
        private void KyBaoCaogridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (KyBaoCaogridLookUpEdit.EditValue != null)
            {
                KyBaoCaoKeToan kyBaoCao = KyBaoCaoKeToan.GetKyBaoCaoKeToanByMa(KyBaoCaogridLookUpEdit.EditValue.ToString());
                TuNgay_dateEdit.EditValue = kyBaoCao.TuNgay;
                DenNgay_dateEdit.EditValue = kyBaoCao.DenNgay;
            }
        }

        private void ThongTinBoSungThuyetMinhBCTCgridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (ThongTinBoSungThuyetMinhBCTCgridView.RowCount > 0)
                {
                    if (ThongTinBoSungThuyetMinhBCTCgridView.GetSelectedRows().Length > 0)
                    {
                        if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", ThongTinBoSungThuyetMinhBCTCgridView.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ThongTinBoSungThuyetMinhBCTCgridView.DeleteSelectedRows();
                        }
                    }
                }
            }

        }

        private void ThongTinBoSungThuyetMinhBCTCgridView_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            //lấy tam ứng vừa tạo mới trên lưới
            ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable ttbs = this.ThongTinBoSungThuyetMinhBCTCgridView.GetRow(e.RowHandle) as ThongTinBoSungBangThuyetMinhBCTCEditableSwitchable;
            if (ttbs != null)
            {
                setvaluesDefault(ttbs);
            }
        }
        #endregion Event handles



    }
    //=======================

    #region PublicClass

    //public class KyBaoCaoKeToan
    //{
    //    public string Ma { get; set; }
    //    public string MoTa { get; set; }
    //    public DateTime TuNgay { get; set; }
    //    public DateTime DenNgay { get; set; }
    //    public KyBaoCaoKeToan()
    //    {

    //    }
    //    public KyBaoCaoKeToan(string ma, string mota, DateTime tuNgay, DateTime denNgay)
    //    {
    //        Ma = ma;
    //        MoTa = mota;
    //        TuNgay = tuNgay;
    //        DenNgay = denNgay;
    //    }
    //    public static KyBaoCaoKeToan GetKyBaoCaoKeToanByMa(string ma)
    //    {
    //        DateTime currentDate = DateTime.Now.Date;
    //        KyBaoCaoKeToan rs = new KyBaoCaoKeToan();
    //        if (ma == "HomNay")
    //        {
    //            rs = new KyBaoCaoKeToan("HomNay", "Hôm nay", currentDate, currentDate);
    //        }
    //        else if (ma == "TuanNay")
    //        {
    //            rs = new KyBaoCaoKeToan("TuanNay", "Tuần này", PublicClass.StartOfWeek(currentDate, DayOfWeek.Monday), PublicClass.LastOfWeek(currentDate, DayOfWeek.Monday));
    //        }
    //        else if (ma == "DauTuanNayDenHienTai")
    //        {
    //            rs = new KyBaoCaoKeToan("DauTuanNayDenHienTai", "Đầu tuần này đến hiện tại", PublicClass.StartOfWeek(currentDate, DayOfWeek.Monday), currentDate);
    //        }
    //        else if (ma == "ThangNay")
    //        {
    //            rs = new KyBaoCaoKeToan("ThangNay", "Tháng này", PublicClass.GetFirstDayInMonth(currentDate.Year, currentDate.Month), PublicClass.GetLastDayInMonth(currentDate.Year, currentDate.Month));
    //        }
    //        else if (ma == "DauThangNayDenHienTai")
    //        {
    //            rs = new KyBaoCaoKeToan("DauThangNayDenHienTai", "Đầu tháng này đến hiện tại", PublicClass.GetFirstDayInMonth(currentDate.Year, currentDate.Month), currentDate);
    //        }
    //        else if (ma == "QuyNay")
    //        {
    //            rs = new KyBaoCaoKeToan("QuyNay", "Quý này", PublicClass.GetFirstDayInQuarterOfYear(currentDate.Year, currentDate.Month), PublicClass.GetLastDayInQuarterOfYear(currentDate.Year, currentDate.Month));
    //        }
    //        else if (ma == "DauQuyNayDenHienTai")
    //        {
    //            rs = new KyBaoCaoKeToan("DauQuyNayDenHienTai", "Đầu quý này đến hiện tại", PublicClass.GetFirstDayInQuarterOfYear(currentDate.Year, currentDate.Month), currentDate);
    //        }
    //        else if (ma == "NamNay")
    //        {
    //            rs = new KyBaoCaoKeToan("NamNay", "Năm nay", new DateTime(currentDate.Year, 1, 1), new DateTime(currentDate.Year, 12, 31));
    //            //if (currentDate.Month > 7)
    //            //{
    //            //    rs = new KyBaoCaoKeToan("NamNay", "Năm nay", new DateTime(currentDate.Year, 7, 1), new DateTime(currentDate.Year + 1, 6, 30));
    //            //}
    //            //else
    //            //{
    //            //    rs = new KyBaoCaoKeToan("NamNay", "Năm nay", new DateTime(currentDate.Year - 1, 7, 1), new DateTime(currentDate.Year, 6, 30));
    //            //}
    //        }
    //        else if (ma == "Thang1")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang1", "Tháng 1", PublicClass.GetFirstDayInMonth(currentDate.Year, 1), PublicClass.GetLastDayInMonth(currentDate.Year, 1));
    //        }
    //        else if (ma == "Thang2")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang2", "Tháng 2", PublicClass.GetFirstDayInMonth(currentDate.Year, 2), PublicClass.GetLastDayInMonth(currentDate.Year, 2));
    //        }
    //        else if (ma == "Thang3")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang3", "Tháng 3", PublicClass.GetFirstDayInMonth(currentDate.Year, 3), PublicClass.GetLastDayInMonth(currentDate.Year, 3));
    //        }
    //        else if (ma == "Thang4")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang4", "Tháng 4", PublicClass.GetFirstDayInMonth(currentDate.Year, 4), PublicClass.GetLastDayInMonth(currentDate.Year, 4));
    //        }
    //        else if (ma == "Thang5")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang5", "Tháng 5", PublicClass.GetFirstDayInMonth(currentDate.Year, 5), PublicClass.GetLastDayInMonth(currentDate.Year, 5));
    //        }
    //        else if (ma == "Thang6")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang6", "Tháng 6", PublicClass.GetFirstDayInMonth(currentDate.Year, 6), PublicClass.GetLastDayInMonth(currentDate.Year, 6));
    //        }
    //        else if (ma == "Thang7")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang7", "Tháng 7", PublicClass.GetFirstDayInMonth(currentDate.Year, 7), PublicClass.GetLastDayInMonth(currentDate.Year, 7));
    //        }
    //        else if (ma == "Thang8")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang8", "Tháng 8", PublicClass.GetFirstDayInMonth(currentDate.Year, 8), PublicClass.GetLastDayInMonth(currentDate.Year, 8));
    //        }
    //        else if (ma == "Thang9")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang9", "Tháng 9", PublicClass.GetFirstDayInMonth(currentDate.Year, 9), PublicClass.GetLastDayInMonth(currentDate.Year, 9));
    //        }
    //        else if (ma == "Thang10")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang10", "Tháng 10", PublicClass.GetFirstDayInMonth(currentDate.Year, 10), PublicClass.GetLastDayInMonth(currentDate.Year, 10));
    //        }
    //        else if (ma == "Thang11")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang11", "Tháng 11", PublicClass.GetFirstDayInMonth(currentDate.Year, 11), PublicClass.GetLastDayInMonth(currentDate.Year, 11));
    //        }
    //        else if (ma == "Thang12")
    //        {
    //            rs = new KyBaoCaoKeToan("Thang12", "Tháng 12", PublicClass.GetFirstDayInMonth(currentDate.Year, 12), PublicClass.GetLastDayInMonth(currentDate.Year, 12));
    //        }
    //        else if (ma == "Quy1")
    //        {
    //            rs = new KyBaoCaoKeToan("Quy1", "Quý I", PublicClass.GetFirstDayInMonth(currentDate.Year, 1), PublicClass.GetLastDayInMonth(currentDate.Year, 3));
    //        }
    //        else if (ma == "Quy2")
    //        {
    //            rs = new KyBaoCaoKeToan("Quy2", "Quý II", PublicClass.GetFirstDayInMonth(currentDate.Year, 4), PublicClass.GetLastDayInMonth(currentDate.Year, 6));
    //        }
    //        else if (ma == "Quy3")
    //        {
    //            rs = new KyBaoCaoKeToan("Quy3", "Quý III", PublicClass.GetFirstDayInMonth(currentDate.Year, 7), PublicClass.GetLastDayInMonth(currentDate.Year, 9));
    //        }
    //        else if (ma == "Quy4")
    //        {
    //            rs = new KyBaoCaoKeToan("Quy4", "Quý IV", PublicClass.GetFirstDayInMonth(currentDate.Year, 10), PublicClass.GetLastDayInMonth(currentDate.Year, 12));
    //        }
    //        else if (ma == "ThangTruoc")
    //        {
    //            rs = new KyBaoCaoKeToan("ThangTruoc", "Tháng trước", PublicClass.GetFirstDayInLastMonth(currentDate.Year, currentDate.Month), PublicClass.GetLastDayInLastMonth(currentDate.Year, currentDate.Month));
    //        }
    //        else if (ma == "QuyTruoc")
    //        {
    //            rs = new KyBaoCaoKeToan("QuyTruoc", "Quý trước", PublicClass.GetFirstDayInLastQuarterOfYear(currentDate.Year, currentDate.Month), PublicClass.GetLastDayInLastQuarterOfYear(currentDate.Year, currentDate.Month));
    //        }
    //        else if (ma == "NamTruoc")
    //        {
    //            rs = new KyBaoCaoKeToan("NamTruoc", "Năm trước", new DateTime(currentDate.Year - 1, 1, 1), new DateTime(currentDate.Year - 1, 12, 31));
    //            //rs = new KyBaoCaoKeToan("NamTruoc", "Năm trước", new DateTime(currentDate.Year - 1, 7, 1), new DateTime(currentDate.Year, 6, 30));
    //        }
    //        else if (ma == "TuyChon")
    //        {
    //            rs = new KyBaoCaoKeToan("TuyChon", "Tùy chọn", currentDate, currentDate);
    //        }

    //        return rs;
    //    }
    //    //        Hôm nay,Tuần Này,Đầu tuần này đến hiện tại,Tháng này,Đầu tháng này đến hiện tại
    //    //Quý này,Đầu quý này đến hiện tại,Tháng 1,Tháng 2,Tháng 3,Tháng 4,Tháng 5,Tháng 6,Tháng 7,Tháng 8,Tháng 9,Tháng 10
    //    //Tháng 11,Tháng12,Quý I,Quý II,Quý III,Quý IV,Tuần trước,Tháng trước,Quý trước,Năm trước
    //    //Tuần sau,Bốn tuần sau,Tháng sau,Quý sau,Năm Sau,Tự chọn
    //    public static List<KyBaoCaoKeToan> CreateListKyBaoCaoKeToan()
    //    {
    //        DateTime currentDate = DateTime.Now.Date;
    //        List<KyBaoCaoKeToan> listRS = new List<KyBaoCaoKeToan>();
    //        listRS.Add(new KyBaoCaoKeToan("HomNay", "Hôm nay", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("TuanNay", "Tuần này", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("DauTuanNayDenHienTai", "Đầu tuần này đến hiện tại", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("ThangNay", "Tháng này", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("DauThangNayDenHienTai", "Đầu tháng này đến hiện tại", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("QuyNay", "Quý này", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("DauQuyNayDenHienTai", "Đầu quý này đến hiện tại", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("NamNay", "Năm nay", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang1", "Tháng 1", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang2", "Tháng 2", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang3", "Tháng 3", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang4", "Tháng 4", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang5", "Tháng 5", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang6", "Tháng 6", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang7", "Tháng 7", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang8", "Tháng 8", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang9", "Tháng 9", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang10", "Tháng 10", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang11", "Tháng 11", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Thang12", "Tháng 12", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Quy1", "Quý I", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Quy2", "Quý II", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Quy3", "Quý III", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("Quy4", "Quý IV", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("ThangTruoc", "Tháng trước", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("QuyTruoc", "Quý trước", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("NamTruoc", "Năm trước", currentDate, currentDate));
    //        listRS.Add(new KyBaoCaoKeToan("TuyChon", "Tùy chọn", currentDate, currentDate));

    //        return listRS;
    //    }

    //}

    //public class PublicClass
    //{

    //    public static DateTime StartOfWeek(DateTime dt, DayOfWeek startOfWeek)
    //    {
    //        int diff = dt.DayOfWeek - startOfWeek;
    //        if (diff < 0)
    //        {
    //            diff += 7;
    //        }
    //        return dt.AddDays(-1 * diff).Date;
    //    }

    //    public static DateTime LastOfWeek(DateTime dt, DayOfWeek startOfWeek)
    //    {
    //        DateTime ldowDate = (StartOfWeek(dt, startOfWeek)).AddDays(6);
    //        return ldowDate;
    //    }

    //    public static DateTime GetFirstDayInMonth(int year, int month)
    //    {
    //        DateTime aDateTime = new DateTime(year, month, 1);

    //        return aDateTime;
    //    }

    //    public static DateTime GetLastDayInMonth(int year, int month)
    //    {
    //        DateTime aDateTime = new DateTime(year, month, 1);

    //        // Cộng thêm 1 tháng và trừ đi một ngày.
    //        DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);

    //        return retDateTime;
    //    }

    //    public static DateTime GetFirstDayInLastMonth(int year, int month)
    //    {
    //        DateTime aDateTime = new DateTime(year, month, 1);
    //        DateTime rsDateTime = aDateTime.AddMonths(-1);
    //        return rsDateTime;
    //    }

    //    public static DateTime GetLastDayInLastMonth(int year, int month)
    //    {
    //        DateTime aDateTime = new DateTime(year, month, 1);

    //        DateTime retDateTime = (aDateTime.AddMonths(-1)).AddMonths(1).AddDays(-1);

    //        return retDateTime;
    //    }

    //    public static DateTime GetFirstDayInQuarterOfYear(int year, int month)
    //    {
    //        DateTime rSDateTime = new DateTime();
    //        if (month >= 1 && month <= 3)
    //        {
    //            rSDateTime = GetFirstDayInMonth(year, 1);
    //        }
    //        else if (month >= 4 && month <= 6)
    //        {
    //            rSDateTime = GetFirstDayInMonth(year, 4);
    //        }
    //        else if (month >= 7 && month <= 9)
    //        {
    //            rSDateTime = GetFirstDayInMonth(year, 7);
    //        }
    //        else if (month >= 10 && month <= 12)
    //        {
    //            rSDateTime = GetFirstDayInMonth(year, 10);
    //        }
    //        return rSDateTime;
    //    }

    //    public static DateTime GetLastDayInQuarterOfYear(int year, int month)
    //    {
    //        DateTime rSDateTime = new DateTime();
    //        if (month >= 1 && month <= 3)
    //        {
    //            rSDateTime = GetLastDayInMonth(year, 3);
    //        }
    //        else if (month >= 4 && month <= 6)
    //        {
    //            rSDateTime = GetLastDayInMonth(year, 6);
    //        }
    //        else if (month >= 7 && month <= 9)
    //        {
    //            rSDateTime = GetLastDayInMonth(year, 9);
    //        }
    //        else if (month >= 10 && month <= 12)
    //        {
    //            rSDateTime = GetLastDayInMonth(year, 12);
    //        }
    //        return rSDateTime;
    //    }

    //    public static DateTime GetFirstDayInLastQuarterOfYear(int year, int month)
    //    {
    //        DateTime rSDateTime = new DateTime();
    //        if (month >= 1 && month <= 3)
    //        {
    //            rSDateTime = GetFirstDayInMonth(year - 1, 10);
    //        }
    //        else if (month >= 4 && month <= 6)
    //        {
    //            rSDateTime = GetFirstDayInMonth(year, 1);
    //        }
    //        else if (month >= 7 && month <= 9)
    //        {
    //            rSDateTime = GetFirstDayInMonth(year, 4);
    //        }
    //        else if (month >= 10 && month <= 12)
    //        {
    //            rSDateTime = GetFirstDayInMonth(year, 7);
    //        }
    //        return rSDateTime;
    //    }

    //    public static DateTime GetLastDayInLastQuarterOfYear(int year, int month)
    //    {
    //        DateTime rSDateTime = new DateTime();
    //        if (month >= 1 && month <= 3)
    //        {
    //            rSDateTime = GetLastDayInMonth(year - 1, 12);
    //        }
    //        else if (month >= 4 && month <= 6)
    //        {
    //            rSDateTime = GetLastDayInMonth(year, 3);
    //        }
    //        else if (month >= 7 && month <= 9)
    //        {
    //            rSDateTime = GetLastDayInMonth(year, 6);
    //        }
    //        else if (month >= 10 && month <= 12)
    //        {
    //            rSDateTime = GetLastDayInMonth(year, 9);
    //        }
    //        return rSDateTime;
    //    }

    //    public static DateTime GetFirstDayInYear(int year)
    //    {
    //        DateTime rSDateTime = new DateTime(year, 1, 1);
    //        return rSDateTime;
    //    }

    //    public static DateTime GetLastDayInYear(int year)
    //    {
    //        DateTime rSDateTime = new DateTime(year, 12, 31);
    //        return rSDateTime;
    //    }
    //}

    #endregion PublicClass
}//End