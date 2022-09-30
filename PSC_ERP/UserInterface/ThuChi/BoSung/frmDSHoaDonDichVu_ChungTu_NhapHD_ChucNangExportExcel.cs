using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;


namespace PSC_ERP//578578876
{

    public partial class frmDSHoaDonDichVu_ChungTu_NhapHD_ChucNangExportExcel : Form
    {

        long MaDangNhap = ERP_Library.Security.CurrentUser.Info.UserID;
        public bool IsSave = false;
        HoaDonList _HoaDonList_Copy = HoaDonList.NewHoaDonList();
        public HoaDonList _HoaDonList = HoaDonList.NewHoaDonList();
        DoiTacList _DoiTacList;
        public ChungTu_HoaDonList ct_hdList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        public decimal TongTien = 0;
        public decimal TongTienThue = 0;
        HoaDon_DoiTac _hdDOitac;
        public Decimal TongTienChungTu = 0;
        decimal _tongtienthue = 0;
        ChungTuRutGonList _chungTuList;
        int _mabuttoan = 0;
        ChungTu _ct = ChungTu.NewChungTu();
        HamDungChung hamDungChung = new HamDungChung();
        decimal _tongtienhoadon = 0;
        ButToan _bt;
        decimal _tongtienhd = 0;
        HoaDon_DoiTacList _hdDOitacList;
        HoaDon_DoiTacList _hdDOitacListGet;
        private FilterCombo fCombo;
        int _sorecord_copy = 0;
        DateTime _tuNgay = DateTime.Today.AddMonths(-6).Date;
        DateTime _denNgay = DateTime.Today.Date;
        public bool DaChon = false;
        ChungTuRutGonList _ChungTuList;
        ChungTuRutGon _ChungTu = ChungTuRutGon.NewChungTuRutGon();
        public ChungTuRutGon _ChungTu1 = ChungTuRutGon.NewChungTuRutGon();
        private string _tenfrm = "CTHD";

        private bool isimportfromExcel = false;

        #region Load
        public frmDSHoaDonDichVu_ChungTu_NhapHD_ChucNangExportExcel()
        {
            InitializeComponent();
            //grdu_DSHoaDon.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            //grdu_DSHoaDon.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            //grdu_DSHoaDon.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            //grdu_DSHoaDon.KeyDown += new KeyEventHandler(grdData_KeyDown);
            //grdu_DSHoaDon.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            //grdu_DSHoaDon.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            //grdu_DSHoaDon.DoubleClickCell += new DoubleClickCellEventHandler(grdData_DoubleClickCell);

            this.DSHoaDonDichVu_BindingSource.DataSource = typeof(HoaDonList);
            this.bdCT_HoaDon.DataSource = typeof(ChungTu_HoaDonList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChungTuRutGonList);
            //   this.mauHDBindingSource.DataSource = typeof(DanhMucMauHoaDonList);

            KhoiTao();
            fCombo = new FilterCombo(grdu_DSHoaDon, "MaDoiTac", "TenDoiTac");

            //Thêm dữ liệu vào mẫu hóa đơn
            ThemDuLieuVaoComBoBox_MauHoaDon();


        }
        private void cbChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "SoChungTu");
            foreach (UltraGridColumn col in this.cbChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                if (col.DataType == typeof(decimal))
                {
                    col.Format = "###,###,###,####,###";
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 300;

            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;
        }
        private void grdu_DSHoaDon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;

            foreach (UltraGridColumn col in this.grdu_DSHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }


            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["mahoadon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["mahoadon"].Header.Caption = "No.";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["mahoadon"].Header.VisiblePosition = 13;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["mahoadon"].CellActivation = Activation.NoEdit;


            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns.Add("CHon", "");
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["CHon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["CHon"].Width = 70;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["CHon"].DataType = typeof(bool);
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["CHon"].Header.VisiblePosition = 1;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["CHon"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.Always;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["CHon"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["CHon"].CellActivation = Activation.AllowEdit;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["CHon"].CellClickAction = CellClickAction.Edit;


            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Header.Caption = "Số Serial";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["SoSerial"].Header.VisiblePosition = 2;

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["SoHoaDon"].Header.VisiblePosition = 3;

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["MauHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["MauHoaDon"].Header.Caption = "Mẫu Hóa Đơn";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["MauHoaDon"].Header.VisiblePosition = 4;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["MauHoaDon"].EditorComponent = cmbu_MauHD;

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["KyHieuMauHoaDon"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["KyHieuMauHoaDon"].Header.Caption = "Ký Hiệu Mẫu HĐ";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["KyHieuMauHoaDon"].Header.VisiblePosition = 5;

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["NgayLap"].Header.VisiblePosition = 6;

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].Header.Caption = "Khách Hàng";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].Header.VisiblePosition = 7;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].Width = 250;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["maDoiTac"].EditorComponent = cmbu_KhachHang1;

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["GhiCHu"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["GhiCHu"].Header.Caption = "Diễn Giải";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["GhiCHu"].Header.VisiblePosition = 8;

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].Header.Caption = "Tiền Trước Thuế";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].Header.VisiblePosition = 9;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].Format = "#,###";
            //grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThanhTien"].MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn,nnn";

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueSuatVAt"].Header.Caption = "Thuế Suất";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueSuatVAt"].Header.VisiblePosition = 10;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueSuatVAt"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueSuatVAt"].EditorComponent = cmbe_ThueVAT;


            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].Header.Caption = "Thuế VAT";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].Header.VisiblePosition = 11;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].Format = "#,###";
            //grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn,nnn";

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TienThue"].Header.Caption = "Tiền Thuế";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TienThue"].Header.VisiblePosition = 12;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TienThue"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TienThue"].Format = "#,###";
            //grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["ThueVAT"].MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn,nnn";

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Header.Caption = "Tiền Sau Thuế";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Header.VisiblePosition = 13;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].Format = "#,###";
            //grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TongTien"].MaskInput = "{LOC}-nnn,nnn,nnn,nnn,nnn,nnn";

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["maHinhThucTT"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["maHinhThucTT"].Header.Caption = "Hình Thức Thanh Toán";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["maHinhThucTT"].Header.VisiblePosition = 14;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["maHinhThucTT"].EditorComponent = cbo_hinhthuctt;

            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["KhauTruThue"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["KhauTruThue"].Header.Caption = "HĐ Khấu Trừ Thuế";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["KhauTruThue"].Header.VisiblePosition = 15;



            //grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns.Add("TenKhachHangNgoai");
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Header.Caption = "Tên KH Ngoài";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Header.VisiblePosition = 16;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["TenKhachHangNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue

            //grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns.Add("MSThueNgoai");
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Header.Caption = "MS Thuế";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Header.VisiblePosition = 17;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["MSThueNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue

            //grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns.Add("NguoiLienLacNgoai");
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Header.Caption = "Người Liên Hệ";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Header.VisiblePosition = 18;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["NguoiLienLacNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue

            //grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns.Add("DiaChiNgoai");
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DiaChiNgoai"].Header.Caption = "Địa Chỉ";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DiaChiNgoai"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DiaChiNgoai"].Header.VisiblePosition = 19;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DiaChiNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DiaChiNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue

            //grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns.Add("DTNgoai");
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Header.Caption = "Điện Thoại";
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Hidden = false;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Header.VisiblePosition = 20;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].Columns["DTNgoai"].Header.Appearance.BackColor = System.Drawing.Color.PeachPuff;//x =  //= System.Drawing.w;//RoyalBlue


            //grdu_DSHoaDon.DisplayLayout.Bands["CT_HoaDonDichVuList"].Hidden = true;
            //grdu_DSHoaDon.DisplayLayout.Bands["CT_HoaDonTSCDList"].Hidden = true;
            //grdu_DSHoaDon.DisplayLayout.Bands["CT_HoaDonList"].Hidden = true;
        }

        public void KhoiTao()
        {

            phuongThucThanhToanListBindingSource.DataSource = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
            _DoiTacList.Insert(0, _DoiTac);
            DoiTac _DoiTac1 = DoiTac.NewDoiTac(0, "<None>");
            _DoiTacList.Insert(0, _DoiTac1);
            doiTacListBindingSource.DataSource = _DoiTacList;

            //_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            //DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);

            //LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value));
        }
        public void LayHoaDon(byte loai, DateTime tuNgay, DateTime denNgay, bool click)
        {
            DSHoaDonDichVu_BindingSource.DataSource = HoaDonList.NewHoaDonList();
            if (click)
            {
                _HoaDonList = HoaDonList.GetHoaDonListChuaTT(loai, 0, tuNgay, denNgay, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            }
            else
            {
                //_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
                _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTubyLoaiHoaDon(loai, 0, 0, false, _ct.MaChungTu, this._mabuttoan);
                DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;

            }
            _hdDOitacList = HoaDon_DoiTacList.NewHoaDon_DoiTacList();

            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                // gan vaop du lieu hoa don
                if ((long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value <= 0)
                {
                    long _mahoadon = (long)grdu_DSHoaDon.Rows[i].Cells["Mahoadon"].Value;
                    _hdDOitacListGet = HoaDon_DoiTacList.GetHoaDon_DoiTacList(_mahoadon);
                    if (_hdDOitacListGet.Count != 0)
                    {
                        grdu_DSHoaDon.Rows[i].Cells["TenKhachHAngNgoai"].Value = _hdDOitacListGet[0].TenDoiTac;
                        grdu_DSHoaDon.Rows[i].Cells["NguoiLienLacNgoai"].Value = _hdDOitacListGet[0].NguoiLienHe;
                        grdu_DSHoaDon.Rows[i].Cells["MSThueNgoai"].Value = _hdDOitacListGet[0].MSThue;
                        grdu_DSHoaDon.Rows[i].Cells["DiaChiNgoai"].Value = _hdDOitacListGet[0].DiaChi;
                        grdu_DSHoaDon.Rows[i].Cells["DTNgoai"].Value = _hdDOitacListGet[0].DienThoai;
                    }
                }
            }
        }



        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            // kiem tra da co hoa don cho chung tu nay chua

            #region
            grdu_DSHoaDon.UpdateData();

            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                if ((long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value > 0 && Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["TenKhachHangNgoai"].Value).Trim() != "")
                {
                    MessageBox.Show(this, "Nhập liệu khách hàng không đồng thời chọn khách hàng trong danh mục và ngoài danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdu_DSHoaDon.Rows[i].Selected = true;
                    return;
                }
                else if ((long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value <= 0 && Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["TenKhachHangNgoai"].Value).Trim() == "")
                {
                    MessageBox.Show(this, "Vui lòng nhập khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdu_DSHoaDon.Rows[i].Selected = true;
                    return;
                }
                //else if ((long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value <= 0 )
                //{
                //    MessageBox.Show(this, "Vui lòng nhập khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    grdu_DSHoaDon.Rows[i].Selected = true;
                //    return;
                //}
                else if (Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["MauHoaDon"].Value).Trim() == "")
                {
                    MessageBox.Show(this, "Vui lòng chọn mẫu hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdu_DSHoaDon.Rows[i].Selected = true;
                    return;
                }
                else if (Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["KyHieuMauHoaDon"].Value).Trim() == "")
                {
                    MessageBox.Show(this, "Vui lòng nhập ký hiếu mẫu hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdu_DSHoaDon.Rows[i].Selected = true;
                    return;
                }
                if ((long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value <= 0)
                {
                    if (((grdu_DSHoaDon.Rows[i].Cells["MSThueNgoai"].Value != null && (grdu_DSHoaDon.Rows[i].Cells["MSThueNgoai"].Value.ToString().Length == 9 || (grdu_DSHoaDon.Rows[i].Cells["MSThueNgoai"].Value.ToString().Length == 14 && grdu_DSHoaDon.Rows[i].Cells["MSThueNgoai"].Value.ToString().Substring(10, 1) == "-") || grdu_DSHoaDon.Rows[i].Cells["MSThueNgoai"].Value.ToString().Length == 13 || grdu_DSHoaDon.Rows[i].Cells["MSThueNgoai"].Value.ToString().Length == 10))))
                    {

                    }
                    else
                    {
                        MessageBox.Show(this, "Mã Số Thuế Không Hợp Lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_DSHoaDon.Rows[i].Selected = true;
                        return;
                    }
                }

            }
            foreach (HoaDon hd in _HoaDonList)
            {
                if (isHoaDonBanQuyen(_ct))
                    hd.LoaiHoaDon = 30;
                else
                    hd.LoaiHoaDon = 4;
                if (hd.IsNew)
                {
                    if (HoaDon.KiemTraHoaDon(hd.SoHoaDon, hd.SoSerial, hd.MaDoiTac, hd.TongTien, hd.NgayLap.Year) > 0)
                    {
                        MessageBox.Show(this, "Hóa đơn số " + hd.SoHoaDon + " SoSerial " + hd.SoSerial + " Tổng tiền " + hd.TongTien +" ngày lập "+hd.NgayLap+ "này đã tồn tại rồi vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            _HoaDonList.ApplyEdit();
            _HoaDonList.Save();

            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                if ((long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value <= 0)
                {
                    _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                    _hdDOitac.MaHoaDon = (long)grdu_DSHoaDon.Rows[i].Cells["MaHoaDon"].Value;
                    _hdDOitac.TenDoiTac = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["TenKhachHangNgoai"].Value);
                    _hdDOitac.NguoiLienHe = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["NguoiLienLacNgoai"].Value);
                    _hdDOitac.MSThue = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["MSThueNgoai"].Value);
                    _hdDOitac.DiaChi = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["DiaChiNgoai"].Value);
                    _hdDOitac.DienThoai = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["DTNgoai"].Value);
                    _hdDOitacList.Add(_hdDOitac);
                }
            }
            _hdDOitacList.ApplyEdit();
            _hdDOitacList.Save();
            MessageBox.Show(this, "Cập nhật hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            #endregion


            if (_bt != null)
            {
                if (_bt.ChungTu_HoaDonList.Count != 0)
                {
                    MessageBox.Show(this, "Đã có hóa đơn cho chứng từ này đề nghị xem lại dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (Them())
                    Save();
            }
            if (isHoaDonBanQuyen(_ct))
            {
                LayHoaDon(30, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
            }
            else
                LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
            //Thành thêm đoạn này, để sau khi lưu sẽ cập nhật trạng thái "Hoàn Tất" cho danh sách hiện tại. (13/04/2012)
            //Xulytinhtrangchungtu();


        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlshdmuavao_Click(object sender, EventArgs e)
        {
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_ct.DoiTuong, _ct.NgayLap.Date, false);
            frmhoadondichvu.ShowDialog();


            // _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            // DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);


        }
        private void tlshdbanra_Click(object sender, EventArgs e)
        {
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmHoaDonDichVuBanRa frmhoadondichvu = new frmHoaDonDichVuBanRa(_ct.DoiTuong, 5, _ct.NgayLap.Date);
            frmhoadondichvu.ShowDialog();

            //if (_ct.DoiTuong != 0) // nam trong danh muc khach hang
            //{
            //    _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(_ct.DoiTuong, 0, false, _ct.MaChungTu);
            //    DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            //}
            //else //ngoai danh muc 
            //{
            // _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            // DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
            //}

        }
        private void tlstim_Click(object sender, EventArgs e)
        {
            //int taikhoan31131 = HeThongTaiKhoan1.LayMaTaiKhoan("31131");
            //int taikhoan31132 = HeThongTaiKhoan1.LayMaTaiKhoan("31132");


            frmTimChungTuNew_TheoHD f = new frmTimChungTuNew_TheoHD("CTHD");
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                if (f._ChungTu1.MaChungTu != 0)
                {
                    bindingSource1_ChungTu.DataSource = ChungTuRutGon.GetChungTuRutGon(f._ChungTu1.MaChungTu);
                    _ct = ChungTuList.GetChungTuListByMaChungTu(f._ChungTu1.MaChungTu)[0];

                    _ct = ChungTu.GetChungTu(f._ChungTu1.MaChungTu);
                    cbChungTu.Value = _ct.MaChungTu;
                    btn_chonbt.Enabled = true;
                    // kiem tra neu chung tu chi co 1 but toan thi lay tu dong
                    if (_ct.DinhKhoan.ButToan.Count == 1)
                    {
                        this._mabuttoan = _ct.DinhKhoan.ButToan[0].MaButToan;
                        _bt = _ct.DinhKhoan.ButToan[0];
                        TongTienChungTu = _ct.DinhKhoan.ButToan[0].SoTien;
                        cbSoTien.Value = TongTienChungTu;
                        if (_ct.DinhKhoan.LaMotNoNhieuCo == true)
                            txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_ct.DinhKhoan.ButToan[0].CoTaiKhoan).SoHieuTK;
                        else
                            txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_ct.DinhKhoan.ButToan[0].NoTaiKhoan).SoHieuTK;
                    }
                    else // lay but toan co tai khoan 31131
                    {
                        foreach (ButToan bt in _ct.DinhKhoan.ButToan)
                        {
                            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
                            HeThongTaiKhoan1 tkco = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan);
                            //if (taikhoan31131 == bt.NoTaiKhoan || taikhoan31132 == bt.NoTaiKhoan)
                            if (tk.SoHieuTK.StartsWith("3113") || tk.SoHieuTK.StartsWith("3337") || tkco.SoHieuTK.StartsWith("3337"))
                            {
                                this._mabuttoan = bt.MaButToan;
                                _bt = bt;
                                TongTienChungTu += _bt.SoTien;
                                cbSoTien.Value = TongTienChungTu;
                                if (tk.SoHieuTK.StartsWith("3113") || tk.SoHieuTK.StartsWith("3337"))
                                {
                                    txt_taikhoan.Text = tk.SoHieuTK;
                                }
                                else if (tkco.SoHieuTK.StartsWith("3337"))
                                {
                                    txt_taikhoan.Text = tkco.SoHieuTK;
                                }
                                //txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan).SoHieuTK;
                            }
                        }
                    }

                    #region Old
                    //// Load ds hoa don phai theo but toan 
                    ////_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
                    ////DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
                    //LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
                    #endregion//Old
                    if (isHoaDonBanQuyen(_ct))
                    {
                        LayHoaDon(30, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
                    }
                    else
                    {
                        LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
                    }
                    bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;

                    if (_bt.ChungTu_HoaDonList.Count != 0)
                        tlslblThem.Enabled = true;
                    else
                        tlslblThem.Enabled = false;

                    // check chon tat ca hoa don
                    for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
                    {
                        grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
                    }
                }
            }
        }


        #endregion

        #region Process
        private bool Them()
        {
            _tongtienthue = 0;
            _tongtienhoadon = 0;
            grdu_DSHoaDon.UpdateData();

            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (this._mabuttoan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn bút toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            #region K Kiem Tra Khoa So
            //KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ct.NgayLap);
            //if (khoa.Count > 0)
            //{
            //    if (khoa[0].KhoaSo == true)
            //    {
            //        MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            #endregion// K Kiem Tra Khoa So
            if (KhoaSoThue())
            {
                MessageBox.Show(this, "Đã khóa sổ thuế, không thể cập nhật!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                if ((bool)grdu_DSHoaDon.Rows[i].Cells["Chon"].Value == true && grdu_DSHoaDon.Rows[i].IsFilterRow == false)
                {
                    long maHoaDon = (long)grdu_DSHoaDon.Rows[i].Cells["MaHoaDon"].Value;
                    if (isHoaDonBanQuyen(_ct))
                    {
                        _tongtienthue = _tongtienthue + (decimal)grdu_DSHoaDon.Rows[i].Cells["TienThue"].Value;
                    }
                    else
                        _tongtienthue = _tongtienthue + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                    _tongtienhoadon = _tongtienhoadon + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThanhTien"].Value;
                    decimal _tienthue = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                }
            }

            //if (_tongtienthue != 0)
            //{
            //    if (_tongtienthue != TongTienChungTu)
            //    {
            //        MessageBox.Show("Tổng tiền hóa đơn khác tổng tiền bút toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            //else
            //{
            //    if (_tongtienhoadon != TongTienChungTu)
            //    {
            //        MessageBox.Show("Tổng tiền hóa đơn khác tổng tiền bút toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        return false;
            //    }
            //}
            ChungTu_HoaDon ct_hd;
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                bool exists = false;
                if ((bool)grdu_DSHoaDon.Rows[i].Cells["Chon"].Value == true && grdu_DSHoaDon.Rows[i].IsFilterRow == false)
                {
                    long maHoaDon = (long)grdu_DSHoaDon.Rows[i].Cells["MaHoaDon"].Value;
                    decimal _tienhoadon = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThanhTien"].Value;
                    decimal _tienthue;
                    if (isHoaDonBanQuyen(_ct))
                    {
                        _tienthue = (decimal)grdu_DSHoaDon.Rows[i].Cells["TienThue"].Value;
                    }
                    else
                        _tienthue = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                    string soHoaDon = (string)grdu_DSHoaDon.Rows[i].Cells["SoHoaDon"].Value;

                    // truong hop khi edite lai cho nguoi dung them vao danh sach co san           
                    foreach (ChungTu_HoaDon ct_hd1 in _bt.ChungTu_HoaDonList)
                    {
                        if (maHoaDon == ct_hd1.MaHoaDon)//Đã tồn tại hóa đơn bên danh sách Chứng từ-hóa đơn list                      
                            exists = true;

                    }
                    if (exists == false)
                    {
                        ct_hd = ChungTu_HoaDon.NewChungTu_HoaDon();
                        if (_tongtienthue != 0)
                        {
                            ct_hd.SoTien = _tongtienthue;
                            ct_hd.SoTienSeThanhToan = _tienthue;
                        }
                        else
                        {
                            ct_hd.SoTien = _tongtienhoadon;
                            ct_hd.SoTienSeThanhToan = _tienhoadon;
                        }

                        //ct_hd.SoTienDaThanhToan = 0;
                        ct_hd.MaHoaDon = maHoaDon;
                        ct_hd.MaChungTu = _ct.MaChungTu;
                        ct_hd.MaButToan = this._mabuttoan;
                        ct_hd.SoHoaDon = soHoaDon;
                        _bt.ChungTu_HoaDonList.Add(ct_hd);
                    }
                }
            }
            // kiem tra tog tien trong hoa don va tong tien trong chung tu phai bang nhai thi moi cho luu


            this.bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;
            return true;
        }
        private void Save()
        {
            try
            {
                _bt.ChungTu_HoaDonList._Update();
                MessageBox.Show("Cập nhật hóa đơn và chứng từ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.ToString()); }


        }

        #region process
        private bool iskeyok = false;
        private bool iscopyok = false;
        private object copyvalue;
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_DSHoaDon.ActiveCell != null && !grdu_DSHoaDon.ActiveCell.IsInEditMode && grdu_DSHoaDon.ActiveCell.Column.Key != "MaDoitac" && grdu_DSHoaDon.ActiveCell.Column.Key != "mahoadon")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    grdu_DSHoaDon.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    grdu_DSHoaDon.ActiveCell.SelectAll();
                    iskeyok = true;
                }
                if (e.KeyCode == Keys.Space && grdu_DSHoaDon.ActiveCell.Column.DataType == typeof(bool))
                {
                    grdu_DSHoaDon.ActiveCell.Value = !Convert.ToBoolean(grdu_DSHoaDon.ActiveCell.Value);
                }
            }
        }
        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok && grdu_DSHoaDon.ActiveCell.Row.IsDataRow)
            {
                if (grdu_DSHoaDon.ActiveCell.Column.DataType == typeof(decimal))
                    try
                    {
                        grdu_DSHoaDon.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                    }
                    catch
                    { }
                else
                    grdu_DSHoaDon.ActiveCell.Value = e.KeyChar.ToString();
                //grdu_DSHoaDon.ActiveCell.SelStart = grdu_DSHoaDon.ActiveCell.Text.Length;
                e.Handled = true;
                iskeyok = false;
            }
        }
        private void grdData_BeforeMultiCellOperation(object sender, Infragistics.Win.UltraWinGrid.BeforeMultiCellOperationEventArgs e)
        {
            if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Copy)
            {
                if (e.Cells.RowCount == 1 && e.Cells.ColumnCount == 1)
                {
                    iscopyok = true;
                    copyvalue = e.Cells[0, 0].Value;
                }
            }
            else
                if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Paste)
                {
                    if (iscopyok && grdu_DSHoaDon.Selected != null && grdu_DSHoaDon.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_DSHoaDon.Selected.Cells)
                        {
                            try
                            {
                                item.Value = copyvalue;
                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    if (!iscopyok && grdu_DSHoaDon.Selected != null && grdu_DSHoaDon.Selected.Cells != null)
                    {
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_DSHoaDon.Selected.Cells)
                        {
                            try
                            {

                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    iscopyok = false;
                }
        }
        private void grdData_DoubleClickCell(object sender, DoubleClickCellEventArgs e)
        {
            grdu_DSHoaDon.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
        }
        #endregion
        #endregion

        #region Function KhoaSoThue
        private bool KhoaSoThue()
        {
            bool khoasothue = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ct.NgayLap);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSoThue == true)
                {
                    khoasothue = true;
                }
            }
            return khoasothue;
        }//Them

        private bool isHoaDonBanQuyen(ChungTu chungtu)
        {
            foreach (ButToan bt in _ct.DinhKhoan.ButToan)
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
                HeThongTaiKhoan1 tkco = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan);
                //if (taikhoan31131 == bt.NoTaiKhoan || taikhoan31132 == bt.NoTaiKhoan)
                if (tk.SoHieuTK.StartsWith("3337") || tkco.SoHieuTK.StartsWith("3337"))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion// Function KhoaSoThue

        private void btn_chonbt_Click(object sender, EventArgs e)
        {
            frmDSButToan_ChungTu f = new frmDSButToan_ChungTu(this._ct);
            if (f.ShowDialog(this) != DialogResult.OK)
            {
                if (f._mabt != 0)
                {
                    this._mabuttoan = f._mabt;
                    this._bt = f._bt;
                    TongTienChungTu = f._sotien;
                    cbSoTien.Value = TongTienChungTu;

                    if (_ct.DinhKhoan.LaMotNoNhieuCo)
                        txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.CoTaiKhoan).SoHieuTK;
                    else
                        txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_bt.NoTaiKhoan).SoHieuTK;
                    // kh \i nay moi Load ds hoa don len

                    //_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
                    //DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
                    LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
                    bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;

                    if (_bt.ChungTu_HoaDonList.Count != 0)
                        tlslblThem.Enabled = true;
                    else
                        tlslblThem.Enabled = false;
                    for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
                    {
                        grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
                    }
                }
            }
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmDanhSachHoaDonDichVu_DadinhKem frm = new frmDanhSachHoaDonDichVu_DadinhKem(_ct, _bt);
            frm.ShowDialog();

            //_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            //DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;           
            LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
        }

        private void hóaĐơnMuaVàoKhôngCóVATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_ct.DoiTuong, _ct.NgayLap.Date, true);
            frmhoadondichvu.ShowDialog();


            //_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            //DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
        }

        private void grdu_DSHoaDon_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (isimportfromExcel) return;
            grdu_DSHoaDon.UpdateData();
            decimal _ttthue = 0, _tthd = 0;


            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                if ((bool)grdu_DSHoaDon.Rows[i].Cells["Chon"].Value)
                {
                    _ttthue = _ttthue + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                    _tthd = _tthd + (decimal)grdu_DSHoaDon.Rows[i].Cells["ThanhTien"].Value;
                }
            }
            if (_ttthue != 0)
            {
                txttienhoadon.Value = _ttthue;
            }
            else
            {
                txttienhoadon.Value = _tthd;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), true);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdu_DSHoaDon.ActiveRow != null)
            {
                _sorecord_copy = grdu_DSHoaDon.Selected.Rows.Count;
                MessageBox.Show(this, "Đã sao chép được " + _sorecord_copy.ToString() + " dòng");
                if (_sorecord_copy != 0)
                {
                    _HoaDonList_Copy = HoaDonList.NewHoaDonList();
                    HoaDon hd = HoaDon.NewHoaDon();
                    for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
                    {
                        if (grdu_DSHoaDon.Rows[i].Selected)
                        {
                            hd = HoaDon.NewHoaDon();
                            hd.SoHoaDon = grdu_DSHoaDon.Rows[i].Cells["Sohoadon"].Value.ToString();
                            hd.SoSerial = grdu_DSHoaDon.Rows[i].Cells["SoSerial"].Value.ToString();
                            hd.NgayLap = Convert.ToDateTime(grdu_DSHoaDon.Rows[i].Cells["NgayLap"].Value);
                            hd.MaDoiTac = (long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value;
                            hd.GhiChu = grdu_DSHoaDon.Rows[i].Cells["Ghichu"].Value.ToString();
                            hd.ThanhTien = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThanhTien"].Value;
                            hd.ThueSuatVAT = (double)grdu_DSHoaDon.Rows[i].Cells["ThueSuatVAT"].Value;
                            hd.ThueVAT = (decimal)grdu_DSHoaDon.Rows[i].Cells["ThueVAT"].Value;
                            hd.TongTien = (decimal)grdu_DSHoaDon.Rows[i].Cells["TongTien"].Value;
                            hd.VietBangChu = grdu_DSHoaDon.Rows[i].Cells["VietBangChu"].Value.ToString();
                            hd.NgayHetHanTT = Convert.ToDateTime(grdu_DSHoaDon.Rows[i].Cells["NgayHetHanTT"].Value);
                            hd.KhauTruThue = (bool)grdu_DSHoaDon.Rows[i].Cells["KhauTruThue"].Value;
                            _HoaDonList_Copy.Add(hd);
                        }
                    }
                }
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // neu so luong copy la 1 dong thi bat lenh lam nhieu dong con neu nguoc lai thi khong
            if (_HoaDonList_Copy.Count > 0)
            {
                if (_HoaDonList_Copy.Count == 1)
                {
                    string result = Microsoft.VisualBasic.Interaction.InputBox("Nhập số lượng dòng cần sao chép", "Copy", "", (this.Width / 2) + 100, (this.Height / 2) + 100);
                    // duyet qua tung dong copy va Insert truc tiep vao trong bang
                    int sodong = Convert.ToInt32(result);
                    HoaDon __hd;
                    for (int i = 0; i < sodong; i++)
                    {
                        __hd = HoaDon.NewHoaDon();

                        __hd.SoHoaDon = _HoaDonList_Copy[0].SoHoaDon;
                        __hd.SoSerial = _HoaDonList_Copy[0].SoSerial;
                        __hd.NgayLap = _HoaDonList_Copy[0].NgayLap;
                        __hd.MaDoiTac = _HoaDonList_Copy[0].MaDoiTac;
                        __hd.GhiChu = _HoaDonList_Copy[0].GhiChu;
                        __hd.ThanhTien = _HoaDonList_Copy[0].ThanhTien;
                        __hd.ThueSuatVAT = _HoaDonList_Copy[0].ThueSuatVAT;
                        __hd.ThueVAT = _HoaDonList_Copy[0].ThueVAT;
                        __hd.TongTien = _HoaDonList_Copy[0].TongTien;
                        __hd.VietBangChu = _HoaDonList_Copy[0].VietBangChu;
                        __hd.NgayHetHanTT = _HoaDonList_Copy[0].NgayHetHanTT;
                        __hd.KhauTruThue = _HoaDonList_Copy[0].KhauTruThue;


                        _HoaDonList.Add(__hd);
                    }
                }
                else
                {
                    foreach (HoaDon hd in _HoaDonList_Copy)
                    {
                        _HoaDonList.Add(hd);
                    }
                }
            }
            DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {

        }

        private void saveListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdu_DSHoaDon.UpdateData();
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                if ((long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value > 0 && Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["TenKhachHangNgoai"].Value).Trim() != "")
                {
                    MessageBox.Show(this, "Nhập liệu khách hàng không đồng thời chọn khách hàng trong danh mục và ngoài danh mục.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdu_DSHoaDon.Rows[i].Selected = true;
                    return;
                }
                if ((long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value <= 0 && Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["TenKhachHangNgoai"].Value).Trim() == "")
                {
                    MessageBox.Show(this, "Vui lòng chọn khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grdu_DSHoaDon.Rows[i].Selected = true;
                    return;
                }

            }
            for (int i = 0; i < _HoaDonList.Count; i++)
                _HoaDonList[i].LoaiHoaDon = 4;
            _HoaDonList.ApplyEdit();
            _HoaDonList.Save();


            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                if ((long)grdu_DSHoaDon.Rows[i].Cells["MaDoiTac"].Value <= 0)
                {
                    _hdDOitac = HoaDon_DoiTac.NewHoaDon_DoiTac();
                    _hdDOitac.MaHoaDon = (long)grdu_DSHoaDon.Rows[i].Cells["MaHoaDon"].Value;
                    _hdDOitac.TenDoiTac = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["TenKhachHangNgoai"].Value);
                    _hdDOitac.NguoiLienHe = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["NguoiLienLacNgoai"].Value);
                    _hdDOitac.MSThue = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["MSThueNgoai"].Value);
                    _hdDOitac.DiaChi = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["DiaChiNgoai"].Value);
                    _hdDOitac.DienThoai = Convert.ToString(grdu_DSHoaDon.Rows[i].Cells["DTNgoai"].Value);
                    _hdDOitacList.Add(_hdDOitac);
                }
            }
            _hdDOitacList.ApplyEdit();
            _hdDOitacList.Save();
            MessageBox.Show(this, "Cập nhật hóa đơn thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void xóaHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdu_DSHoaDon.ActiveRow != null)
            {
                grdu_DSHoaDon.DeleteSelectedRows();
            }
        }

        private void cmbu_KhachHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["MaDoiTac"].Hidden = true;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["KhachHang"].Hidden = true;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["NhaCungCap"].Hidden = true;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["LoaiDoitac"].Hidden = true;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = true;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["DiaChi"].Hidden = true;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["DienThoai"].Hidden = true;

            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 1;

            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["TenDoitac"].Header.Caption = "Tên Khách Hàng";
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["TenDoitac"].Width = 250;
            cmbu_KhachHang1.DisplayLayout.Bands[0].Columns["TenDoitac"].Header.VisiblePosition = 0;


            this.cmbu_KhachHang1.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;//appearance17;
            this.cmbu_KhachHang1.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_KhachHang1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void cmbu_KhachHang_AfterCloseUp(object sender, EventArgs e)
        {
            long ma = 0;
            if (cmbu_KhachHang1.ActiveRow != null)
            {
                if (cmbu_KhachHang1.Text == "Thêm Mới...")
                {
                    frmKhachHang _frmKhachHang = new frmKhachHang();
                    if (_frmKhachHang.ShowDialog() != DialogResult.OK)
                    {
                        _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
                        DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Thêm Mới...");
                        _DoiTacList.Insert(0, _DoiTac);
                        DoiTac _DoiTac1 = DoiTac.NewDoiTac(0, "<None>");
                        _DoiTacList.Insert(0, _DoiTac1);
                        ma = _DoiTacList[_DoiTacList.Count - 1].MaDoiTac;
                        cmbu_KhachHang1.Value = ma;
                        doiTacListBindingSource.DataSource = _DoiTacList;
                    }
                }
            }
        }
        private void txtu_DieuKienTim_ValueChanged(object sender, EventArgs e)
        {
            grdData.DisplayLayout.Bands[0].ColumnFilters.LogicalOperator = FilterLogicalOperator.Or;

            if (grdData.DisplayLayout.Bands[0].ColumnFilters["SoChungTu"].FilterConditions.Count > 0)
                grdData.DisplayLayout.Bands[0].ColumnFilters["SoChungTu"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdData.DisplayLayout.Bands[0].ColumnFilters["SoChungTu"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

            if (grdData.DisplayLayout.Bands[0].ColumnFilters["NgayLap"].FilterConditions.Count > 0)
                grdData.DisplayLayout.Bands[0].ColumnFilters["NgayLap"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdData.DisplayLayout.Bands[0].ColumnFilters["NgayLap"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

            if (grdData.DisplayLayout.Bands[0].ColumnFilters["SoTien"].FilterConditions.Count > 0)
                grdData.DisplayLayout.Bands[0].ColumnFilters["SoTien"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdData.DisplayLayout.Bands[0].ColumnFilters["SoTien"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            _tuNgay = Convert.ToDateTime(dateTuNgay.Value);
            _denNgay = Convert.ToDateTime(dateDenNgay.Value);
            LoadChungTu();
        }

        private void LoadChungTu()
        {
            if (_tenfrm == "CTHD")
            {
                _ChungTuList = ChungTuRutGonList.GetChungTuListAll_ByLoc(_tuNgay, _denNgay);
                this.ChungTu_BindingSource.DataSource = _ChungTuList;
                Xulytinhtrangchungtu();
            }
        }

        private void Xulytinhtrangchungtu()
        {
            //_ChungTuList;
            ChungTu _ct = ChungTu.NewChungTu();
            int _mabuttoan = 0;
            decimal _tongtienchungtu = 0;
            decimal _tongtienhd = 0;

            //int taikhoan31131 = HeThongTaiKhoan1.LayMaTaiKhoan("31131");
            //int taikhoan31132 = HeThongTaiKhoan1.LayMaTaiKhoan("31132");

            for (int i = 0; i < grdData.Rows.Count; i++)
            {
                if (_ct != null)
                {
                    _mabuttoan = (int)grdData.Rows[i].Cells["maButToan"].Value;
                    _tongtienchungtu = (decimal)grdData.Rows[i].Cells["STButToan"].Value;
                    _tongtienhd = 0;
                    _tongtienhd = LaytongtienCTtheobt(_mabuttoan);
                    if (_tongtienchungtu == _tongtienhd)
                        grdData.Rows[i].Cells["Tinhtrang"].Value = "Hoàn Tất";
                }
            }
        }

        private decimal LaytongtienCTtheobt(int mabuttoan)
        {
            decimal sotien = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_laysotienhoadontheobuttoan";
                    cm.Parameters.AddWithValue("@mabuttoan", mabuttoan);
                    sotien = (decimal)cm.ExecuteScalar();
                }
            }
            return sotien;
        }

        private void grdData_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                    col.CellAppearance.TextHAlign = HAlign.Center;
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.CellActivation = Activation.AllowEdit;
            }

            grdData.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdData.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["Chon"].Width = 15;
            grdData.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;

            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Header.Caption = "STT";
            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Hidden = true;
            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Width = 40;

            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;

            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 100;

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;


            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 5;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 400;



            grdData.DisplayLayout.Bands[0].Columns.Add("Tinhtrang", "Tình Trạng");
            grdData.DisplayLayout.Bands[0].Columns["Tinhtrang"].Header.VisiblePosition = 6;
            grdData.DisplayLayout.Bands[0].Columns["Tinhtrang"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["Tinhtrang"].Width = 100;
        }

        private void grdData_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            //Trả số tiền lại giá trị ban đầu tránh việc cộng lũy tiến tiền
            TongTienChungTu = 0;

            HeThongTaiKhoan1List taikhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoanBySoHieu("3113");

            //Chuyển về tab chứng từ
            _ChungTu1 = (ChungTuRutGon)(ChungTu_BindingSource.Current);

            bindingSource1_ChungTu.DataSource = ChungTuRutGon.GetChungTuRutGon(_ChungTu1.MaChungTu);
            _ct = ChungTuList.GetChungTuListByMaChungTu(_ChungTu1.MaChungTu)[0];
            cbChungTu.Value = _ct.MaChungTu;
            btn_chonbt.Enabled = true;

            // kiem tra neu chung tu chi co 1 but toan thi lay tu dong
            if (_ct.DinhKhoan.ButToan.Count == 1)
            {
                this._mabuttoan = _ct.DinhKhoan.ButToan[0].MaButToan;
                _bt = _ct.DinhKhoan.ButToan[0];
                TongTienChungTu = _ct.DinhKhoan.ButToan[0].SoTien;
                cbSoTien.Value = TongTienChungTu;
                if (_ct.DinhKhoan.LaMotNoNhieuCo == true)
                    txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_ct.DinhKhoan.ButToan[0].CoTaiKhoan).SoHieuTK;
                else
                    txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_ct.DinhKhoan.ButToan[0].NoTaiKhoan).SoHieuTK;
            }
            else // lay but toan co tai khoan 3113
            {
                foreach (ButToan bt in _ct.DinhKhoan.ButToan)
                {
                    foreach (HeThongTaiKhoan1 tk in taikhoanList)
                    {
                        if (tk.MaTaiKhoan == bt.NoTaiKhoan)
                        {
                            this._mabuttoan = bt.MaButToan;
                            _bt = bt;
                            TongTienChungTu += _bt.SoTien;
                            cbSoTien.Value = TongTienChungTu;
                            txt_taikhoan.Text = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan).SoHieuTK;
                            break;
                        }
                    }
                }
            }

            #region OLd
            //// Load ds hoa don phai theo but toan 
            ////_HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            ////DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            //LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
            #endregion//OLd
            if (isHoaDonBanQuyen(_ct))
            {
                LayHoaDon(30, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
            }
            else
            {
                LayHoaDon(4, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);
            }
            bdCT_HoaDon.DataSource = _bt.ChungTu_HoaDonList;

            if (_bt.ChungTu_HoaDonList.Count != 0)
                tlslblThem.Enabled = true;
            else
                tlslblThem.Enabled = false;

            // check chon tat ca hoa don
            for (int i = 0; i < grdu_DSHoaDon.Rows.Count; i++)
            {
                grdu_DSHoaDon.Rows[i].Cells["Chon"].Value = true;
            }

            tabControl1.SelectedIndex = 0;
        }

        private void cmbu_MauHD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_MauHD, "MaQuanLy");
            foreach (UltraGridColumn col in this.cmbu_MauHD.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                if (col.DataType == typeof(decimal))
                {
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Hóa Đơn";
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;

            cmbu_MauHD.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Hidden = false;
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Header.Caption = "Tên Loại Hóa Đơn";
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Header.VisiblePosition = 2;
            cmbu_MauHD.DisplayLayout.Bands[0].Columns["TenLoaiHoaDon"].Width = 300;
        }

        private void ThemDuLieuVaoComBoBox_MauHoaDon()
        {
            //
            DanhMucMauHoaDonList danhMucMauHoaDonList = DanhMucMauHoaDonList.GetDanhMucMauHoaDonList();
            mauHDBindingSource.DataSource = danhMucMauHoaDonList;
        }

        private void cmbu_MauHD_AfterCloseUp(object sender, EventArgs e)
        {
            grdData.UpdateData();

            //Lấy hóa đơn hiện tại
            HoaDon hoaDon = DSHoaDonDichVu_BindingSource.Current as HoaDon;

            if (hoaDon != null && cmbu_MauHD.Value != null)
            {
                hoaDon.MauHoaDon = Convert.ToString(cmbu_MauHD.Value);
                hoaDon.KyHieuMauHoaDon = Convert.ToString(cmbu_MauHD.Value).Trim() + "/";
            }
        }

        private void grdu_DSHoaDon_AfterRowInsert(object sender, RowEventArgs e)
        {
            if (isimportfromExcel) return;
            //Lấy hóa đơn hiện tại
            HoaDon hoaDon = DSHoaDonDichVu_BindingSource.Current as HoaDon;

            if (hoaDon != null)
            {
                hoaDon.MauHoaDon = "01GTKT";
                hoaDon.KyHieuMauHoaDon = "01GTKT/";
            }
        }

        private void hóaĐơnBảnQuyềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ct.MaChungTu == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn chứng từ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            frmHoaDonMuaBanQuyen frmhoadondichvu = new frmHoaDonMuaBanQuyen(_ct.DoiTuong, _ct.NgayLap.Date, false);
            //frmHoaDonDichVuMuaVao frmhoadondichvu = new frmHoaDonDichVuMuaVao(_ct.DoiTuong, _ct.NgayLap.Date, false);
            frmhoadondichvu.ShowDialog();


            // _HoaDonList = HoaDonList.GetHoaDonList_byHoaDonDichVu_ChungTu(0, 0, false, _ct.MaChungTu, this._mabuttoan);
            // DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
            LayHoaDon(30, Convert.ToDateTime(dtmp_TuNgay.Value), Convert.ToDateTime(dtmp_DenNgay.Value), false);

        }



        private void tlSbtnExport_Click(object sender, EventArgs e)
        {
            //HamDungChung.ExportToExcel(grdu_DSHoaDon);
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.AddExtension = true;
            dlg.Filter = "Excel|*.xls|All file|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                //tạo file template
                FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                fs.Write(Properties.Resources.DSHoaDonBaoCaoThueExportExcel, 0, Properties.Resources.DSHoaDonBaoCaoThueExportExcel.Length);
                fs.Close();




                MessageBox.Show("Đã xuất dữ liệu thành công", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                System.Diagnostics.Process.Start(dlg.FileName);
            }
        }

        #region BS

        private DataTable ImportExcelXLS(string FileName, bool hasHeaders)
        {
            string HDR = hasHeaders ? "Yes" : "No";
            string strConn;
            if (FileName.Substring(FileName.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=0\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=0\"";


            DataTable outputTable = new DataTable();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();

                DataTable schemaTable = conn.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                foreach (DataRow schemaRow in schemaTable.Rows)
                {
                    string sheet = schemaRow["TABLE_NAME"].ToString();

                    if (!sheet.EndsWith("_"))
                    {
                        try
                        {
                            //OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                            OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "A5:S]", conn);
                            cmd.CommandType = CommandType.Text;

                            outputTable = new DataTable(sheet);
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex);
                        }
                    }
                }
            }
            return outputTable;
        }

        private void ImportTabletoDSHoaDon(DataTable tblresult)
        {
            #region Old
            //if (tblresult.Rows.Count > 0)
            //{
            //    foreach (DataRow rowhd in tblresult.Rows)
            //    {
            //        //Ngay lap
            //        DateTime ngaylap = DateTime.Today.Date;
            //        DateTime ngaylapOut;
            //        if (DateTime.TryParse(rowhd[5].ToString(), out ngaylapOut))
            //        {
            //            ngaylap = ngaylapOut;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Ngày lập hóa đơn không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //        //MaDoiTac
            //        long madoitac = 0;
            //        DoiTac dtac = DoiTac.GetDoiTacWithoutChildbyTenKhachHang(rowhd[6].ToString());
            //        if (dtac != null) madoitac = dtac.MaDoiTac;
            //        //ThanhTien
            //        decimal thanhtien;
            //        decimal thanhtienOut;
            //        if (decimal.TryParse(rowhd[8].ToString(), out thanhtienOut))
            //        {
            //            thanhtien = thanhtienOut;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Tiền trước thuế không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }

            //        //ThueSuatVAT
            //        double thuesuatVAT;
            //        double thuesuatVATOut;
            //        if (double.TryParse(rowhd[9].ToString(), out thuesuatVATOut))
            //        {
            //            thuesuatVAT = thuesuatVATOut;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Thuế suất VAT không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }
            //        //maHinhThucTT
            //        int mahinhthuctt = 1;
            //        if (rowhd[13].ToString() == "chuyển khoản")
            //        {
            //            mahinhthuctt = 2;
            //        }
            //        //KhauTruThue
            //        bool khautruthue = false;
            //        bool khautruthueOut;
            //        if (bool.TryParse(rowhd[14].ToString(), out khautruthueOut))
            //        {
            //            khautruthue = khautruthueOut;
            //        }
            //        else
            //        {
            //            MessageBox.Show("HĐ khấu trừ thuế không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return;
            //        }

            //        UltraGridRow rownew = grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].AddNew();

            //        rownew.Cells["SoHoaDon"].Value = rowhd[2].ToString();
            //        rownew.Cells["SoSerial"].Value = rowhd[1].ToString();
            //        rownew.Cells["MauHoaDon"].Value = rowhd[3].ToString();
            //        rownew.Cells["KyHieuMauHoaDon"].Value = rowhd[4].ToString();
            //        rownew.Cells["NgayLap"].Value = ngaylap;
            //        rownew.Cells["MaDoiTac"].Value = madoitac;
            //        rownew.Cells["GhiChu"].Value = rowhd[7].ToString();
            //        rownew.Cells["ThanhTien"].Value = thanhtien;
            //        rownew.Cells["ThueSuatVAT"].Value = thuesuatVAT;
            //        rownew.Cells["maHinhThucTT"].Value = mahinhthuctt;
            //        rownew.Cells["KhauTruThue"].Value = khautruthue;

            //        rownew.Cells["TenKhachHangNgoai"].Value = rowhd[15].ToString();
            //        rownew.Cells["MSThueNgoai"].Value = rowhd[16].ToString(); ;
            //        rownew.Cells["NguoiLienLacNgoai"].Value = rowhd[17].ToString();
            //        rownew.Cells["diachiNgoai"].Value = rowhd[18].ToString(); ;
            //        rownew.Cells["DTNgoai"].Value = rowhd[19].ToString();

            //        //grdu_DSHoaDon.Rows.Move(rownew, grdu_DSHoaDon.Rows.Count - 1);
            //        rownew.ParentCollection.Move(rownew, grdu_DSHoaDon.Rows.Count - 1);
            //        this.grdu_DSHoaDon.ActiveRowScrollRegion.ScrollRowIntoView(rownew);
            //    }
            //    //UltraGridRow rowtemp = grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].AddNew();
            //    //grdu_DSHoaDon.Rows[rowtemp.Index].Delete();
            //    //grdu_DSHoaDon.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.ReloadData);
            //    grdu_DSHoaDon.UpdateData();
            //    _HoaDonList.ApplyEdit();
            //    DSHoaDonDichVu_BindingSource.EndEdit();
            //    //cbChungTu.Focus();
            //} 
            #endregion//Old

            #region New
            if (tblresult.Rows.Count > 0)
            {
                foreach (DataRow rowhd in tblresult.Rows)
                {
                    if (rowhd[1].ToString().Trim().Length == 0 && rowhd[2].ToString().Trim().Length == 0)//Soserial và sohoadon = rong
                    {
                        return;
                    }
                    //Ngay lap
                    DateTime ngaylap = DateTime.Today.Date;
                    DateTime ngaylapOut;
                    if (DateTime.TryParse(rowhd[5].ToString(), out ngaylapOut))
                    {
                        ngaylap = ngaylapOut;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Ngày lập hóa đơn không hợp lệ của hóa đơn {0}, số TT {1}!",rowhd[2].ToString(),rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (_ct != null)//Kiem tra Ngay Lap chung tu
                    {
                        if (_ct.NgayLap < ngaylap)
                        {
                            MessageBox.Show(string.Format("Ngày lập của hóa đơn {0}, số TT {1} lớn hơn Ngày lập chứng từ, không hợp lệ!", rowhd[2].ToString(), rowhd[0].ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    //MaDoiTac
                    long madoitac = 0;
                    DoiTac dtac = DoiTac.GetDoiTacWithoutChildbyTenKhachHang(rowhd[6].ToString());
                    if (dtac != null) madoitac = dtac.MaDoiTac;
                    //ThanhTien
                    decimal thanhtien;
                    decimal thanhtienOut;
                    if (decimal.TryParse(rowhd[8].ToString(), out thanhtienOut))
                    {
                        thanhtien = thanhtienOut;
                    }
                    else
                    {
                        MessageBox.Show("Tiền trước thuế không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //TienThueVAT
                    decimal thueVAT;
                    decimal thueVATOut;
                    if(decimal.TryParse(rowhd[10].ToString(),out thueVATOut))
                    {
                        thueVAT=thueVATOut;
                    } 
                    else
                    {
                        MessageBox.Show("Thuế VAT không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //Tien Sau Thue
                    decimal tongtien;
                    decimal tongtienOut;
                    if(decimal.TryParse(rowhd[11].ToString(),out tongtienOut))
                    {
                        tongtien=tongtienOut;
                    }
                    else
                    {
                        MessageBox.Show("Tiền sau thuế không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    //KhauTruThue
                    bool khautruthue = false;
                    bool khautruthueOut;
                    if (bool.TryParse(rowhd[13].ToString(), out khautruthueOut))
                    {
                        khautruthue = khautruthueOut;
                    }
                    else
                    {
                        MessageBox.Show("HĐ khấu trừ thuế không hợp lệ!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    //ThueSuatVAT
                    double thuesuatVAT;
                    double thuesuatVATOut;
                    if (khautruthue == false)
                    {
                        thuesuatVAT = -1;
                    }
                    else if (double.TryParse(rowhd[9].ToString(), out thuesuatVATOut))
                    {
                        thuesuatVAT = thuesuatVATOut;
                    }
                    else
                    {
                        thuesuatVAT =(double) ((thueVAT * 100) / thanhtien);
                    }
                    if (thuesuatVAT > 0 && thuesuatVAT <=1)
                    {
                        thuesuatVAT = 0;
                    }
                    else if (thuesuatVAT > 1 && thuesuatVAT <=6)
                    {
                        thuesuatVAT = 5;
                    }
                    else if (thuesuatVAT > 6)
                    {
                        thuesuatVAT = 10;
                    }
                    //maHinhThucTT
                    int mahinhthuctt = 1;
                    if (rowhd[12].ToString() == "chuyển khoản")
                    {
                        mahinhthuctt = 2;
                    }
                    
                    //
                    HoaDon hdNew = HoaDon.NewHoaDon();
                    hdNew.SoHoaDon = rowhd[2].ToString();
                    hdNew.SoSerial = rowhd[1].ToString();
                    hdNew.MauHoaDon = rowhd[3].ToString();//"01GTKT";
                    hdNew.KyHieuMauHoaDon = rowhd[4].ToString();//"01GTKT/";
                    hdNew.NgayLap = ngaylap;
                    hdNew.MaDoiTac = madoitac;
                    hdNew.GhiChu = rowhd[7].ToString();
                    hdNew.ThanhTien = thanhtien;
                    hdNew.ThueSuatVAT = thuesuatVAT;
                    hdNew.MaHinhThucTT = mahinhthuctt;
                    hdNew.KhauTruThue = khautruthue;

                    hdNew.ThueVAT = thueVAT;
                    hdNew.TongTien = tongtien;

                    hdNew.TenKhachHangNgoai = rowhd[14].ToString();
                    hdNew.MSThueNgoai = rowhd[15].ToString(); ;
                    hdNew.NguoiLienLacNgoai = rowhd[16].ToString();
                    hdNew.DiaChiNgoai = rowhd[17].ToString(); ;
                    hdNew.DTNgoai = rowhd[18].ToString();

                    _HoaDonList.Add(hdNew);
                    //


                    #region OLD
                    //UltraGridRow rownew = grdu_DSHoaDon.DisplayLayout.Bands["HoaDon"].AddNew();

                    //rownew.Cells["SoHoaDon"].Value = rowhd[1].ToString();
                    //rownew.Cells["SoSerial"].Value = rowhd[0].ToString();
                    //rownew.Cells["MauHoaDon"].Value = "";
                    //rownew.Cells["NgayLap"].Value = ngaylap;
                    //rownew.Cells["MaDoiTac"].Value = madoitac;
                    //rownew.Cells["GhiChu"].Value = rowhd[4].ToString();
                    //rownew.Cells["ThanhTien"].Value = thanhtien;
                    //rownew.Cells["ThueSuatVAT"].Value = thuesuatVAT;
                    //rownew.Cells["maHinhThucTT"].Value = mahinhthuctt;
                    //rownew.Cells["KhauTruThue"].Value = khautruthue;

                    //rownew.Cells["TenKhachHangNgoai"].Value = rowhd[9].ToString();
                    //rownew.Cells["MSThueNgoai"].Value = rowhd[10].ToString(); ;
                    //rownew.Cells["NguoiLienLacNgoai"].Value = rowhd[11].ToString();
                    //rownew.Cells["diachiNgoai"].Value = rowhd[12].ToString(); ;
                    //rownew.Cells["DTNgoai"].Value = rowhd[13].ToString();

                    //grdu_DSHoaDon.Rows.Move(rownew, grdu_DSHoaDon.Rows.Count - 1);
                    #endregion//OLD
                }
                DSHoaDonDichVu_BindingSource.DataSource = _HoaDonList;
                //grdu_DSHoaDon.UpdateData();
                //_HoaDonList.ApplyEdit();
                //DSHoaDonDichVu_BindingSource.EndEdit();
            }
            #endregion//New

        }
        #endregion//BS

        private void tlsbtnImport_Click(object sender, EventArgs e)
        {
            isimportfromExcel = true;
            #region Old
            OpenFileDialog oFD = new OpenFileDialog();
            oFD.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
            oFD.ShowDialog();
            string path = oFD.FileName;
            string p = System.IO.Path.GetFileName(path);
            DataTable tblResult = ImportExcelXLS(path, true);
            ImportTabletoDSHoaDon(tblResult);
            #endregion//Old

            isimportfromExcel = false;
        }

        private void tlsbtnExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DSHoaDon);
        }
    }
}