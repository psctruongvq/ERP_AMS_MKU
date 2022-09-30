using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Common;

namespace PSC_ERPNew.Main
{
    public partial class frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon singleton_ = null;
        public static frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon();
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
        Entities _context = null;

        tblChungTu _chungTu = null;
        tblCT_NghiepVuSuaChuaLon _ct_nghiepVuSuaChuaLon = null;
        IQueryable<tblDonViTinh> _donViTinhList;
        IQueryable<tblQuocGia> _quocGiaList;
        #endregion

        //Member Constructor
        #region Member Constructor

        public frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon()
        {
            InitializeComponent();
            grdChiTietTaiSanCaBiet.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }
        public frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon(Entities context, tblChungTu chungTu, tblCT_NghiepVuSuaChuaLon ct_NghiepVuSuaChuaLon)
        {
            InitializeComponent();
            _context = context;
            _chungTu = chungTu;
            _ct_nghiepVuSuaChuaLon = ct_NghiepVuSuaChuaLon;
            grdChiTietTaiSanCaBiet.DataBindings.DefaultDataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private void LoadData()
        {
            _donViTinhList = DonViTinh_Factory.New().GetAll();
            _quocGiaList = QuocGia_Factory.New().GetAll();
            GridUtil.DeleteHelper.Setup_ManualType(grdViewChiTietTaiSanCaBiet, (gridView, deleteList) =>
                                                                               {
                                                                                   //xóa bổ sung DCPT
                                                                                   ChiTietTaiSanCaBiet_Factory.FullDelete(_context, deleteList);
                                                                               });
            GridUtil.DeleteHelper.Setup_ManualType(grdViewDungCuPhuTung, (gridView, deleteList) =>
                                                                         {
                                                                             //xóa bổ sung DCPT
                                                                             BoSungDungCuPhuTung_Factory.FullDelete(_context, deleteList);
                                                                         });
            // Cài đặt lưới
            GridUtil.SetSTTForGridView(this.grdViewDungCuPhuTung);
            GanBindingSource();
        }

        private void GanBindingSource()
        {
            tblDonViTinhBindingSource.DataSource = _donViTinhList;
            tblQuocGiaBindingSource.DataSource = _quocGiaList;
            tblTaiSanCoDinhCaBietBindingSource_Single.DataSource = _ct_nghiepVuSuaChuaLon.tblTaiSanCoDinhCaBiet;
            tblDanhMucTSCDBindingSource_TSCD_Single.DataSource = _ct_nghiepVuSuaChuaLon.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD;
            tblBoSungDungCuPhuTungBindingSource.DataSource = _ct_nghiepVuSuaChuaLon.tblBoSungDungCuPhuTungs;
            tblChiTietTaiSanCaBietBindingSource.DataSource = _ct_nghiepVuSuaChuaLon.tblChiTietTaiSanCaBiets;
        }

        private Boolean KiemTraHopLe()
        {
            Boolean hopLe = true;
            return hopLe;
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmDialogDanhSachBoSungDCPTvaChiTietTheoChiTietNghiepVuSuaChuaLon_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void btnDuaDuLieuVeChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtBlackHole.Focus();
            this.Close();
        }
        private void grdViewDungCuPhuTung_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            #region chưa sử dụng 
            //lấy DCPT vừa tạo mới trên lưới
            //tblBoSungDungCuPhuTung boSungDCPT = this.grdViewDungCuPhuTung.GetRow(e.RowHandle) as tblBoSungDungCuPhuTung;
            //boSungDCPT.MaTSCDCaBiet = _ct_nghiepVuSuaChuaLon.MaTSCDCaBiet;
            //boSungDCPT.DonGia = 0;
            //boSungDCPT.ChiPhi = 0;
            //boSungDCPT.SoLuong = 1;
            //boSungDCPT.TongGiaTri = 0;
            //boSungDCPT.LaDCPTSuaChuaLon = true;
            //boSungDCPT.Ten = "";
            //boSungDCPT.MaQuanLy = "";
            ////boSungDCPT.GhiChu = _chungTu.DienGiai;
            ////tạo chi tiết nguyên giá
            //tblChiTietNguyenGiaTSCD chiTietNguyenGiaMoi = ChiTietNguyenGiaTSCD_Factory.New().CreateAloneObject();
            //chiTietNguyenGiaMoi.SoTien = 0;
            //chiTietNguyenGiaMoi.NgayThucHien = _chungTu.NgayLap;
            //chiTietNguyenGiaMoi.MaTSCDCaBiet = _ct_nghiepVuSuaChuaLon.MaTSCDCaBiet;
            //chiTietNguyenGiaMoi.LuyKeKhauHao = 0;
            //chiTietNguyenGiaMoi.LuyKeHaoMon = 0;
            //chiTietNguyenGiaMoi.LoaiPhanBietNV = (Byte)PSC_ERP_Business.Main.Predefined.ChiTietNguyenGiaTSCD_LoaiPhanBietNVEnum.SuaChuaLonTaiSan;//sửa chữa lớn ts gốc

            ////đưa chi tiết nguyên giá mới vào danh sách
            //_chungTu.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGiaMoi);
            //_ct_nghiepVuSuaChuaLon.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGiaMoi);
            //boSungDCPT.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGiaMoi);
            #endregion
        }
        private void grdViewChiTietTaiSanCaBiet_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            //lấy chi tiết mới
            tblChiTietTaiSanCaBiet chiTietMoi = grdViewChiTietTaiSanCaBiet.GetRow(e.RowHandle) as tblChiTietTaiSanCaBiet;
            if (chiTietMoi != null)
            {
                Int32 maxNum = 0;
                foreach (tblChiTietTaiSanCaBiet chiTietTruocDo in _ct_nghiepVuSuaChuaLon.tblTaiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets)
                {
                    if (String.IsNullOrWhiteSpace(chiTietTruocDo.SoHieu) == false)
                    {
                        Int32 maxNumTemp = Int32.Parse(chiTietTruocDo.SoHieu.Substring(chiTietTruocDo.SoHieu.Length - PSC_ERP_Global.TSCD.SizeOf_SoHieuChiTietTSCDCaBiet_IncreasePart));
                        if (maxNumTemp > maxNum)
                            maxNum = maxNumTemp;
                    }
                }

                String soHieuCapTren = _ct_nghiepVuSuaChuaLon.tblTaiSanCoDinhCaBiet.SoHieu;
                //tạo số hiệu
                String soHieuMoi = "";
                if (maxNum == 0) //số hiệu đầu tiên
                    soHieuMoi = ChiTietTaiSanCaBiet_Factory.CreateFirst_SoHieuChiTietTaiSanCaBiet(soHieuCapTren);
                else//số hiệu tiếp theo
                    soHieuMoi = ChiTietTaiSanCaBiet_Factory.Create_SoHieuChiTietTaiSanCaBiet(soHieuCapTren, maxNum + 1);

                //gán số hiệu mới cho chi tiết
                chiTietMoi.SoHieu = soHieuMoi;
                //chiTietMoi.GhiChu = _chungTu.DienGiai;
                chiTietMoi.TenChiTiet = "";
                chiTietMoi.MaTSCDCaBiet = _ct_nghiepVuSuaChuaLon.MaTSCDCaBiet;

                //mặc định số lượng =1
                chiTietMoi.DonGia = 0;
                chiTietMoi.ChiPhi = 0;
                chiTietMoi.SoLuong = 1;
                chiTietMoi.TienSauThue = 0;
                chiTietMoi.LaChiTietSuaChuaLon = true;
                chiTietMoi.NguyenGia = 0;
                //tạo chi tiết nguyên giá
                tblChiTietNguyenGiaTSCD chiTietNguyenGiaMoi = ChiTietNguyenGiaTSCD_Factory.New().CreateAloneObject();
                chiTietNguyenGiaMoi.SoTien = 0;
                chiTietNguyenGiaMoi.NgayThucHien = _chungTu.NgayLap;
                chiTietNguyenGiaMoi.MaTSCDCaBiet = _ct_nghiepVuSuaChuaLon.MaTSCDCaBiet;
                chiTietNguyenGiaMoi.LuyKeKhauHao = 0;
                chiTietNguyenGiaMoi.LuyKeHaoMon = 0;
                chiTietNguyenGiaMoi.LoaiPhanBietNV = (Byte)PSC_ERP_Business.Main.Predefined.ChiTietNguyenGiaTSCD_LoaiPhanBietNVEnum.SuaChuaLonTaiSan;//sửa chữa lớn ts gốc

                //đưa chi tiết nguyên giá mới vào danh sách
                _chungTu.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGiaMoi);
                _ct_nghiepVuSuaChuaLon.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGiaMoi);
                chiTietMoi.tblChiTietNguyenGiaTSCDs.Add(chiTietNguyenGiaMoi);
            }
        }
        #endregion

        private void cbDonViTinh_ForGrid_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                frmListDonViTinh frm = new frmListDonViTinh();
                frm.ShowDialog();
                _donViTinhList = DonViTinh_Factory.New().GetAll();
                tblDonViTinhBindingSource.DataSource = _donViTinhList;
            }
        }

        private void cbQuocGia_ForGrid_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//refresh danh sách tài sản cố đinh
            {
                frmListQuocGia frm = new frmListQuocGia();
                frm.ShowDialog();
                _quocGiaList = QuocGia_Factory.New().GetAll();
            }
        }
 
        private void grdViewChiTietTaiSanCaBiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            foreach (var chiTietTruocDo in _ct_nghiepVuSuaChuaLon.tblTaiSanCoDinhCaBiet.tblChiTietTaiSanCaBiets)
            {
                chiTietTruocDo.TienSauThue = chiTietTruocDo.NguyenGia + ((chiTietTruocDo.NguyenGia * chiTietTruocDo.Thue) / 100);
            }
        }
       
    }
}