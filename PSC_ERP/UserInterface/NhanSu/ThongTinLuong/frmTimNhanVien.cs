using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using System.Collections;

namespace PSC_ERP
{
    public partial class frmTimNhanVien : Form
    {
        #region Properties
        ThongTinNhanVienTongHopList _ThongTinNhanVienTongHopList;
        ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;
        Util _Util = new Util();
        public static int _NumberForm;
        public static long MaNhanVien;
        public ArrayList keywordArr=new ArrayList();
        BoPhanList _ChuyenList;
        BoPhanList _ToList;
        BoPhan bp;
        string TatCaToString = "< ------- Tất cả ------- >";
        string TatCaNhaMayString = "< ------- Nhà máy ------- >";
        ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList1;
        public static frmQuanHeGiaDinh _frmQuanHeGiaDinh;
        #endregion

        #region Events

        public frmTimNhanVien()
        {
            InitializeComponent();
            
        }
        public frmTimNhanVien(int numberForm,ThongTinNhanVienTongHopList _thongTinNhanVienTongHopList)
        {
            InitializeComponent();
            this._thongTinNhanVienTongHopList1 = _thongTinNhanVienTongHopList;
            if (_thongTinNhanVienTongHopList != null)
            {
                TenNhanVien_BindingSource.DataSource = _thongTinNhanVienTongHopList;
            }
            _NumberForm = numberForm;
            txtu_DieuKienTim.Focus();
            KhoiTao();
        }
        public void KhoiTao()
        {
            _ChuyenList=BoPhanList.GetBoPhanList_LoaiBoPhan(3);
            Chuyen_BindingSource.DataSource = _ChuyenList;
            bp = BoPhan.NewBoPhan(TatCaNhaMayString);
            _ChuyenList.Insert(0,bp);
            if (cmbPhanXuong.Value != null)
            {
                _ToList = BoPhanList.GetBoPhanList_Con(int.Parse(cmbPhanXuong.Value.ToString()));
                To_bindingSource.DataSource = _ToList;
                bp = BoPhan.NewBoPhan(TatCaToString);
                _ToList.Insert(0, bp);

                //ToList.Add(bp);
            }

        }
        public frmTimNhanVien(int numberForm)
        {
            InitializeComponent();
            _NumberForm = numberForm;
            txtu_DieuKienTim.Focus();
            KhoiTao();
        }

        #endregion

        #region grdu_HoSoPhuCapTX_InitializeLayout
        private void grdu_HoSoPhuCapTX_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
          
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                col.Hidden = true;
            }

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 100;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Bộ Phận";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition =2;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 200;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaQLBoPhan"].Hidden = false;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaQLBoPhan"].Header.Caption = "Mã Bộ Phận";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["MaQLBoPhan"].Header.VisiblePosition = 2;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["HeSoLuong"].Hidden = false;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.Caption = "HSL";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 3;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["HeSoLuong"].Header.VisiblePosition = 5;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 5;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.VisiblePosition = 4;

            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Hidden = false;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["HeSoLuongBaoHiem"].Header.Caption = "HSLBH";
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenChucVu"].Hidden = false;
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].Columns["TenChucVu"].Header.Caption = "Chức Vụ";


            //grdu_HoSoPhuCapTX.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //this.grdu_HoSoPhuCapTX.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
          
          
        }
        #endregion

        #region grdu_HoSoPhuCapTX_KeyDown
        private void grdu_HoSoPhuCapTX_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (grdu_HoSoPhuCapTX.ActiveRow != null)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        MaNhanVien = ((ThongTinNhanVienTongHop)(TenNhanVien_BindingSource.Current)).MaNhanVien;
                        _ThongTinNhanVienTongHop = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien);
                        if (_NumberForm == 1)//Form frmHoSoPhuCap
                        {
                            //frmHoSoPhuCap _frmHoSoPhuCap = new frmHoSoPhuCap(_ThongTinNhanVienTongHop);
                            this.Close();
                        }
                        if (_NumberForm == 2)//Form frmHoSoBaoHiem
                        {
                            //frmHoSoBaoHiem _frmHoSoBaoHiem = new frmHoSoBaoHiem(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 3)//Form frmPhuCapThuongXuyen
                        {
                            frmPhuCapThuongXuyen _frmPhuCapThuongXuyen = new frmPhuCapThuongXuyen(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 4)//Form frmQuaTrinhTrichNop
                        {
                            frmQuaTrinhTrichNop _frmQuaTrinhTrichNop = new frmQuaTrinhTrichNop(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 5)//Form frmQuaTrinhNghi
                        {
                            frmQuaTrinhNghi _frmQuaTrinhNghi = new frmQuaTrinhNghi(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 6)//Form frmThongTinThoiViec
                        {
                            frmThongTinThoiViec _frmThongTinThoiViec = new frmThongTinThoiViec(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 7)//Form frmHopDongLaoDong
                        {
                            frmHopDongLaoDong _frmHopDongLaoDong = new frmHopDongLaoDong(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 8)//Form frmQuaTrinhDaoTaoMoi
                        {
                            frmQuaTrinhDaoTaoMoi _frmQuaTrinhDaoTaoMoi = new frmQuaTrinhDaoTaoMoi(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 9)//Form frmThongTinNhanVien
                        {
                            frmThongTinNhanVien _frmThongTinNhanVien = new frmThongTinNhanVien(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 10)//Form frmKhenThuongTungCanBo
                        {
                          //  frmKhenThuongTungCanBo _frmKhenThuongTungCanBo = new frmKhenThuongTungCanBo(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 11)//Form frmKyLuatTungNhanVien
                        {
                            //frmKyLuatTungNhanVien _frmKyLuatTungNhanVien = new frmKyLuatTungNhanVien(_ThongTinNhanVienTongHop);
                        }
                        //if (_NumberForm == 12)// Form frmChamCong
                        //{
                        //    frmChamCong _frmChamCong = new frmChamCong(_ThongTinNhanVienTongHop);
                        //}
                        if (_NumberForm == 13)// Form frmHoSoLuong
                        {
                            frmHoSoLuong _frmHoSoLuong = new frmHoSoLuong(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 14)// Form frmLichSuBanThan
                        {
                            frmLichSuBanThan _frmLichSuBanThan = new frmLichSuBanThan(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 15)// Form frmQuaTrinhDaoTao
                        {
                            frmQuaTrinhDaoTaoMoi _frmQuaTrinhDaoTao = new frmQuaTrinhDaoTaoMoi(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 16)// Form frmSoBaoHiem_KhamChuaBenh
                        {
                           // frmSoBaoHiem_KhamChuaBenh _frmSoBaoHiem_KhamChuaBenh = new frmSoBaoHiem_KhamChuaBenh(_ThongTinNhanVienTongHop);
                        }
                        //if (_NumberForm == 17)// Form frmBangRaVao
                        //{
                        //    frmBangRaVao _frmBangRaVao = new frmBangRaVao(_ThongTinNhanVienTongHop);
                        //}
                        if (_NumberForm == 18)// Form frmQuaTrinhThamGiaQuanDoi
                        {
                            frmQuaTrinhThamGiaQuanDoi _frmQuaTrinhThamGiaQuanDoi = new frmQuaTrinhThamGiaQuanDoi(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 19)// Form frmLuanChuyenDieuChuyenCB
                        {
                            frmLuanChuyenDieuChuyenCB _frm = new frmLuanChuyenDieuChuyenCB(_ThongTinNhanVienTongHop);
                        }
                        //if (_NumberForm == 20)// Form frmTamUng
                        //{
                        //    frmTamUng _frmTamUng = new frmTamUng(_ThongTinNhanVienTongHop);
                        //}
                        if (_NumberForm == 21)// Form frmQuanHeGiaDinh
                        {
                            frmQuanHeGiaDinh _frmQuanHeGiaDinh = new frmQuanHeGiaDinh(_ThongTinNhanVienTongHop);
                        }
                        if (_NumberForm == 22)// Form frmQuanHeGiaDinh
                        {
                            frmCongThemGio _frmCongThemGio = new frmCongThemGio(_ThongTinNhanVienTongHop);
                        }
                        this.Close();
                    }
                }
            }
            catch (ApplicationException)
            {

            }
        }
        #endregion

        string temp = "";

        private void btnTim_Click(object sender, EventArgs e)
        {

            if (radNew.Checked)
            {
                keywordArr.Clear();
            }
            keywordArr.Add(txtu_DieuKienTim.Text);
            if (!check_BoPhan.Checked)
                _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList(keywordArr, "");
            else
                _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList(keywordArr, temp);
            if (_ThongTinNhanVienTongHopList.Count == 0)
            {
                _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListSearch(txtu_DieuKienTim.Text);
                if (_NumberForm == 19)
                    _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListSearch_New(txtu_DieuKienTim.Text);
            }
            TenNhanVien_BindingSource.DataSource = _ThongTinNhanVienTongHopList;
            if (keywordArr.Count == 0)
                radPreviousResult.Enabled = false;
            else
                radPreviousResult.Enabled = true;
        }

        private void txtu_DieuKienTim_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (TenNhanVien_BindingSource.Current != null)
                    grdu_HoSoPhuCapTX_DoubleClickRow(grdu_HoSoPhuCapTX, null);
            }
        }

        private void txtu_DieuKienTim_ValueChanged(object sender, EventArgs e)
        {
            grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters.LogicalOperator = FilterLogicalOperator.Or;

            if (grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["TenNhanVien"].FilterConditions.Count > 0)
                grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["TenNhanVien"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["TenNhanVien"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

            if (grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["MaQLNhanVien"].FilterConditions.Count > 0)
                grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["MaQLNhanVien"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["MaQLNhanVien"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

            if (grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["Cmnd"].FilterConditions.Count > 0)
                grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["Cmnd"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["Cmnd"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

            if (grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["MaSoThue"].FilterConditions.Count > 0)
                grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["MaSoThue"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdu_HoSoPhuCapTX.DisplayLayout.Bands[0].ColumnFilters["MaSoThue"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);
        }

        private void frmTimNhanVien_Load(object sender, EventArgs e)
        {
            if (ERP_Library.Security.CurrentUser.IsAdmin || ERP_Library.Security.CurrentUser.IsAdminNhanSu)
            {
                _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListSearch(txtu_DieuKienTim.Text);
                if(_NumberForm == 19)
                    _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListSearch_New(txtu_DieuKienTim.Text);
            }
            else
            {
                _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByLuongKhoan();
                if (_NumberForm == 19)
                    _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByLuongKhoan_New();
            }
            TenNhanVien_BindingSource.DataSource = _ThongTinNhanVienTongHopList;
        }

        private void grdu_HoSoPhuCapTX_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            if (e != null)
                MaNhanVien = (long)e.Row.Cells["MaNhanVien"].Value;
            else
                MaNhanVien = (long)grdu_HoSoPhuCapTX.ActiveRowScrollRegion.FirstRow.Cells["MaNhanVien"].Value;
            _ThongTinNhanVienTongHop = ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien);
            if (_NumberForm == 1)//Form frmHoSoPhuCap
            {
                //frmHoSoPhuCap _frmHoSoPhuCap = new frmHoSoPhuCap(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 2)//Form frmHoSoBaoHiem
            {
                //frmHoSoBaoHiem _frmHoSoBaoHiem = new frmHoSoBaoHiem(_ThongTinNhanVienTongHop);

            }
            if (_NumberForm == 3)//Form frmPhuCapThuongXuyen
            {
                frmPhuCapThuongXuyen _frmPhuCapThuongXuyen = new frmPhuCapThuongXuyen(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 4)//Form frmQuaTrinhTrichNop
            {
                frmQuaTrinhTrichNop _frmQuaTrinhTrichNop = new frmQuaTrinhTrichNop(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 5)//Form frmQuaTrinhNghi
            {
                frmQuaTrinhNghi _frmQuaTrinhNghi = new frmQuaTrinhNghi(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 6)//Form frmThongTinThoiViec
            {
                frmThongTinThoiViec _frmThongTinThoiViec = new frmThongTinThoiViec(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 7)//Form frmHopDongLaoDong
            {
                frmHopDongLaoDong _frmHopDongLaoDong = new frmHopDongLaoDong(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 8)//Form frmQuaTrinhDaoTaoMoi
            {
                frmQuaTrinhDaoTaoMoi _frmQuaTrinhDaoTaoMoi = new frmQuaTrinhDaoTaoMoi(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 9)//Form frmThongTinNhanVien
            {
                frmThongTinNhanVien _frmThongTinNhanVien;
                _thongTinNhanVienTongHopList1 = _ThongTinNhanVienTongHopList;
                if (_thongTinNhanVienTongHopList1 != null)
                    _frmThongTinNhanVien = new frmThongTinNhanVien(_ThongTinNhanVienTongHop, _thongTinNhanVienTongHopList1);
                else
                    _frmThongTinNhanVien = new frmThongTinNhanVien(_ThongTinNhanVienTongHop);

            }
            if (_NumberForm == 10)//Form frmKhenThuongTungCanBo
            {
                // frmKhenThuongTungCanBo _frmKhenThuongTungCanBo = new frmKhenThuongTungCanBo(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 11)//Form frmKyLuatTungNhanVien
            {
                //frmKyLuatTungNhanVien _frmKyLuatTungNhanVien = new frmKyLuatTungNhanVien(_ThongTinNhanVienTongHop);
            }
            //if (_NumberForm == 12)// Form frmChamCong
            //{
            //    frmChamCong _frmChamCong = new frmChamCong(_ThongTinNhanVienTongHop);
            //}
            if (_NumberForm == 13)// Form frmHoSoLuong
            {
                frmHoSoLuong _frmHoSoLuong = new frmHoSoLuong(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 14)// Form frmLichSuBanThan
            {
                frmLichSuBanThan _frmLichSuBanThan = new frmLichSuBanThan(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 15)// Form frmQuaTrinhDaoTao
            {
                frmQuaTrinhDaoTaoMoi _frmQuaTrinhDaoTao = new frmQuaTrinhDaoTaoMoi(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 16)// Form frmSoBaoHiem_KhamChuaBenh
            {
                //frmSoBaoHiem_KhamChuaBenh _frmSoBaoHiem_KhamChuaBenh = new frmSoBaoHiem_KhamChuaBenh(_ThongTinNhanVienTongHop);
            }
            //if (_NumberForm == 17)// Form frmBangRaVao
            //{
            //    frmBangRaVao _frmBangRaVao = new frmBangRaVao(_ThongTinNhanVienTongHop);
            //}
            if (_NumberForm == 18)// Form frmQuaTrinhThamGiaQuanDoi
            {
                frmQuaTrinhThamGiaQuanDoi _frmQuaTrinhThamGiaQuanDoi = new frmQuaTrinhThamGiaQuanDoi(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 19)// Form frmLuanChuyenDieuChuyenCB
            {

            }
            //if (_NumberForm == 20)// Form frmTamUng
            //{
            //    frmTamUng _frmTamUng = new frmTamUng(_ThongTinNhanVienTongHop);
            //}
            if (_NumberForm == 21)// Form frmQuanHeGiaDinh
            {
                _frmQuanHeGiaDinh = new frmQuanHeGiaDinh(_ThongTinNhanVienTongHop);
            }
            if (_NumberForm == 22)// Form frmQuanHeGiaDinh
            {
                // frmCongThemGio _frmCongThemGio = new frmCongThemGio(_ThongTinNhanVienTongHop);
            }
            this.Close();
        }
    }
}
