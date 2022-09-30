using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmDonHangLamLenhNhap : Form
    {

        #region properties
        private DonHangBanList donHangBanList;
        private DonHangMuaList donHangMuaList;
        private DonNhanHangTraList donNhanHangTraList;
        private DonTraHangMuaList donTraHangMuaList;
        private DonHangBanList DonHangBanList = DonHangBanList.NewDonHangBanList();

        private HamDungChung hamDungChung = new HamDungChung();        

        private byte _Loai;
        private byte _loaiDonHangTra; 
        private bool _nhapXuat;
        private string _chuoiTimKiem =  string.Empty;
        private int _cachTruyXuat;
        

        public long _maDoiTac = 0;
        public CT_LenhNhapXuatList ctLenhNhapXuatList = CT_LenhNhapXuatList.NewCT_LenhNhapXuatList();
        public CT_LenhNhapXuat_DonHangList ctLenhNhapXuat_DonHangList = CT_LenhNhapXuat_DonHangList.NewCT_LenhNhapXuat_DonHangList();
        public CT_DonNhanHangTraList ct_DonNhanHangTraList = CT_DonNhanHangTraList.NewCT_DonNhanHangTraList();
        public CT_DonTraHangMuaList ct_DonTraHangMuaList = CT_DonTraHangMuaList.NewCT_DonTraHangMuaList();

        public DonHangBan_DonNhanHangTraList donHangBan_DonNhanHangTraList = DonHangBan_DonNhanHangTraList.NewDonHangBan_DonNhanHangTraList();
        

        #endregion

        #region  Contructors

        public frmDonHangLamLenhNhap()
        {
            InitializeComponent();
            Invisible();
        }

        /*Contructor dùng cho đơn hàng trả*/
        #region frmDonHangLamLenhNhap(byte loaiDonHangTra, byte loai, string chuoiTimKiem)
        public frmDonHangLamLenhNhap(byte loaiDonHangTra, byte loai, string chuoiTimKiem)
        {
            InitializeComponent();           
            _Loai = loai;
            _chuoiTimKiem = chuoiTimKiem;
            _cachTruyXuat = 1;
            _loaiDonHangTra = loaiDonHangTra;
       
            Invisible();
            if (loai == 0)
            {
                KhoiTaoDonHangMua();
            }
            else if (loai == 1)
            {
                KhoiTaoNhanHangTra();
            }
            else if (loai == 2)
            {
                KhoiTaoDonHangBan();
            }
            else if (loai == 3)
            {
                KhoiTaoDonTraHangMua();
            }
        }
        #endregion 

        /*Contructors làm lệnh nhập xuất*/
        #region frmDonHangLamLenhNhap(byte loai, bool nhapXuat)
        public frmDonHangLamLenhNhap(byte loai, bool nhapXuat)
        {
            InitializeComponent();
            Invisible();
            _Loai = loai;
            _nhapXuat = nhapXuat;
            _cachTruyXuat = 2;
            if ( _nhapXuat == true && (loai == 0 || loai== 1 || loai == 2 || loai == 3 || loai == 11 || loai == 12 ))
            {
                KhoiTaoDonHangMua();
            }
            else if (_nhapXuat == true && loai == 13)
            {
                KhoiTaoNhanHangTra();
                
            }
            else if (_nhapXuat == false && (loai == 0 || loai == 1 || loai == 2 || loai == 3 || loai == 11 || loai == 12))
            {
                KhoiTaoDonHangBan();
            }
            else if (_nhapXuat == false && loai == 13)
            {
                KhoiTaoDonTraHangMua();
            }
        }
        #endregion 

        #endregion

        #region Invisible Button
        private void Invisible()
        {            
            if (_cachTruyXuat == 1)
            {
                cbx_CheckAll.Visible = false;
                this.Text = "Danh Sách Đơn Hàng Cần Tìm";
            }

        }
        #endregion 

        #region KhoiTaoDonHangMua()
        private void KhoiTaoDonHangMua()
        {
           
            grdu_DanhSachDonHang.DataSource = donHangMuaBindingSource;
            if(_cachTruyXuat == 1)
                donHangMuaList = DonHangMuaList.GetDonHangMuaList(true, 0, 9, _chuoiTimKiem,1);
            else
                donHangMuaList = DonHangMuaList.GetDonHangMuaList(false, 0 ,_Loai,_chuoiTimKiem,1);
            donHangMuaBindingSource.DataSource = donHangMuaList;
            
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Khách Hàng";

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].Header.Caption = "Ngày Nhận Hàng";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].Format = "dd/MM/yyyy";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayNhanHang"].MaskInput = "{LOC}dd/mm/yyyy";

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Format = "dd/MM/yyyy";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].MaskInput = "{LOC}dd/mm/yyyy";
            if (_cachTruyXuat == 1)
            {
                grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = true;
                grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["HangTraLai"].Header.Caption = "Trả Lại Hàng";
                grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["HangTraLai"].Hidden = false;
                this.grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Hidden = false;
                foreach (UltraGridColumn col in this.grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns)
                {
                    col.Hidden = true;
                    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                }

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Header.Caption = "Hàng Trả Lại";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Header.VisiblePosition = 1;

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenHangHoa"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenHangHoa"].Header.VisiblePosition = 2;

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DienGiai"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DienGiai"].Header.VisiblePosition = 2;

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoLuong"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoLuong"].Header.Caption = "Số Lượng";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoLuong"].Header.VisiblePosition = 3;

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViTinh"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViTinh"].Header.VisiblePosition = 4;
                
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DonGia"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DonGia"].Header.Caption = "Đơn Giá";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DonGia"].Header.VisiblePosition = 7;

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["ThanhTien"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["ThanhTien"].Header.Caption = "Số Tiền";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["ThanhTien"].Header.VisiblePosition = 10;                

            }
            else
                this.grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Hidden = true;          
        }
        #endregion

        #region KhoiTaoNhanHangTra()
        private void KhoiTaoNhanHangTra()
        {            
            grdu_DanhSachDonHang.DataSource = donNhanHangTraBindingSource;
            donNhanHangTraList = DonNhanHangTraList.GetDonNhanHangTraList(false,"");
            donNhanHangTraBindingSource.DataSource = donNhanHangTraList;

            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden= false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.VisiblePosition = 0;

            this.grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonNhanHangTraList"].Hidden = true;

        }
        #endregion

        #region KhoiTaoDonTraHangMua()
        private void KhoiTaoDonTraHangMua()
        {            
            grdu_DanhSachDonHang.DataSource = donTraHangMuaBindingSource;
            donTraHangMuaList = DonTraHangMuaList.GetDonTraHangMuaList(false,"");
            donTraHangMuaBindingSource.DataSource = donTraHangMuaList;
                     
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }


            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";            
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.VisiblePosition= 0;

            this.grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonTraHangMuaList"].Hidden = true;
        }
        #endregion

        #region KhoiTaoDonHangBan()
        private void KhoiTaoDonHangBan()
        {           
            grdu_DanhSachDonHang.DataSource = donHangBanBindingSource;
            if(_cachTruyXuat == 1)
                donHangBanList = DonHangBanList.GetDonHangBanChoDaiLyList(true, 0, 9 , _chuoiTimKiem, _loaiDonHangTra);
            else
                donHangBanList = DonHangBanList.GetDonHangBanList(false, 0, 1, _chuoiTimKiem, 1);

            donHangBanBindingSource.DataSource = donHangBanList;

            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachDonHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Khách hàng";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right;

            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Hidden = false;
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["SoDonHang"].Header.Caption = "Số Đơn Hàng";
            
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Header.Caption = "Ngày Nhận Hàng";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NgayGiaoHang"].Hidden = false;
                        
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";
            grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;

            if (_cachTruyXuat == 1)
            {
                grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = true;
                grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["HangTraLai"].Header.Caption = "Trả Lại Hàng";
                grdu_DanhSachDonHang.DisplayLayout.Bands[0].Columns["HangTraLai"].Hidden = false;
                this.grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Hidden = false;
                foreach (UltraGridColumn col in this.grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns)
                {
                    col.Hidden = true;
                    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
                }
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Header.Caption = "Hàng Trả Lại";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["HangTraLai"].Header.VisiblePosition = 1;

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenHangHoa"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenHangHoa"].Header.VisiblePosition = 2;

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DienGiai"].Header.VisiblePosition = 3;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DienGiai"].Hidden = false;

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoLuong"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoLuong"].Header.Caption = "Số Lượng";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoLuong"].Header.VisiblePosition = 4;

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViTinh"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["TenDonViTinh"].Header.VisiblePosition = 5;


                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DonGia"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DonGia"].Header.Caption = "Đơn Giá";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["DonGia"].Header.VisiblePosition = 7;                

                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoTien"].Hidden = false;
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoTien"].Header.Caption = "Số Tiền";
                grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Columns["SoTien"].Header.VisiblePosition = 10;
                
            }
            else
                this.grdu_DanhSachDonHang.DisplayLayout.Bands["CT_DonHangBanList"].Hidden = true;

           

        }
        #endregion    

        #region cbx_CheckAll_CheckedChanged
        private void cbx_CheckAll_CheckedChanged(object sender, EventArgs e)
        {

            if (cbx_CheckAll.Checked == true)
            {
               
                if (_nhapXuat == true && (_Loai == 0 || _Loai == 1 || _Loai == 2 || _Loai == 3 || _Loai == 11 || _Loai == 12 || _Loai == 14 || _Loai == 15))
                {
                    foreach (DonHangMua donHangMua in donHangMuaList)
                    {
                        donHangMua.NhapXuat = true;
                    }
                }
                else if (_nhapXuat == true && _Loai == 13)
                {
                    foreach (DonNhanHangTra donNhanHangTra in donNhanHangTraList)
                    {
                        donNhanHangTra.NhapXuat = true;
                    }
                }
                else if (_nhapXuat == false && (_Loai == 0 || _Loai == 1 || _Loai == 2 || _Loai == 3 || _Loai == 11 || _Loai == 12 || _Loai == 14 || _Loai == 15))
                {
                    foreach (DonHangBan donHangBan in donHangBanList)
                    {
                        donHangBan.NhapXuat = true;
                    }
                }
                else if (_nhapXuat == false && _Loai == 13)
                {
                    foreach (DonTraHangMua donTraHangMua in donTraHangMuaList)
                    {
                        donTraHangMua.NhapXuat = true;
                    }
                }
               
            }
            else
            {
                if (_nhapXuat == true && (_Loai == 0 || _Loai == 1 || _Loai == 2 || _Loai == 3 || _Loai == 11 || _Loai == 12 || _Loai == 14 || _Loai == 15))
                {
                    foreach (DonHangMua donHangMua in donHangMuaList)
                    {
                        donHangMua.NhapXuat = false;
                    }
                }
                else if (_nhapXuat == true && _Loai == 13)
                {
                    foreach (DonNhanHangTra donNhanHangTra in donNhanHangTraList)
                    {
                        donNhanHangTra.NhapXuat = false;
                    }
                }
                else if (_nhapXuat == false && (_Loai == 0 || _Loai == 1 || _Loai == 2 || _Loai == 3 || _Loai == 11 || _Loai == 12 || _Loai == 14 || _Loai == 15))
                {
                    foreach (DonHangBan donHangBan in donHangBanList)
                    {
                        donHangBan.NhapXuat = false;
                    }
                }
                else if (_nhapXuat == false && _Loai == 13)
                {
                    foreach (DonTraHangMua donTraHangMua in donTraHangMuaList)
                    {
                        donTraHangMua.NhapXuat = false;
                    }
                }
            }
        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            grdu_DanhSachDonHang.UpdateData();
            if (_cachTruyXuat == 2)
                GopHangHoa();
            else if (_cachTruyXuat == 1)
                GopHangHoaTra();
            this.Close();
        }

        #endregion

        #region    GopHangHoa()

        private void GopHangHoa()
        {
            CT_LenhNhapXuat ctLenhNhapXuat = CT_LenhNhapXuat.NewCT_LenhNhapXuat(0);
            CT_LenhNhapXuat_DonHang ctLenhNhapXuat_DonHang;
            if (_nhapXuat == true && (_Loai == 0 || _Loai == 1 || _Loai == 2 || _Loai == 3 || _Loai == 11 || _Loai == 12))
            {
                foreach (DonHangMua donHangMua in donHangMuaList)
                {
                    if (donHangMua.NhapXuat == true)
                    {
                        _maDoiTac = donHangMua.MaDoiTac;
                        ctLenhNhapXuat_DonHang = CT_LenhNhapXuat_DonHang.NewCT_LenhNhapXuat_DonHang(donHangMua.MaDonHang);
                        ctLenhNhapXuat_DonHangList.Add(ctLenhNhapXuat_DonHang);
                        foreach (CT_DonHangMua ctDonHangMua in donHangMua.CT_DonHangBanList)
                        {
                            ctLenhNhapXuat = CT_LenhNhapXuat.NewCT_LenhNhapXuat(ctDonHangMua);
                            ctLenhNhapXuatList.Add(ctLenhNhapXuat);
                        }

                    }
                }
            }
            else if (_nhapXuat == true && _Loai == 13)
            {
                foreach (DonNhanHangTra donNhanHangTra in donNhanHangTraList)
                {
                    if (donNhanHangTra.NhapXuat == true)
                    {
                        _maDoiTac = donNhanHangTra.MaDoiTac;
                        ctLenhNhapXuat_DonHang = CT_LenhNhapXuat_DonHang.NewCT_LenhNhapXuat_DonHang(donNhanHangTra.MaDonHang);
                        ctLenhNhapXuat_DonHangList.Add(ctLenhNhapXuat_DonHang);
                        foreach (CT_DonNhanHangTra ctDonNhanHangTra in donNhanHangTra.CT_DonNhanHangTraList)
                        {
                            ctLenhNhapXuat = CT_LenhNhapXuat.NewCT_LenhNhapXuat(ctDonNhanHangTra);
                            ctLenhNhapXuatList.Add(ctLenhNhapXuat);
                        }
                    }
                }
            }
            else if (_nhapXuat == false && (_Loai == 0 || _Loai == 1 || _Loai == 2 || _Loai == 3 || _Loai == 11 || _Loai == 12))
            {
                foreach (DonHangBan donHangBan in donHangBanList)
                {
                    if (donHangBan.NhapXuat == true)
                    {
                        _maDoiTac = donHangBan.MaDoiTac;
                        ctLenhNhapXuat_DonHang = CT_LenhNhapXuat_DonHang.NewCT_LenhNhapXuat_DonHang(donHangBan.MaDonHang);
                        ctLenhNhapXuat_DonHangList.Add(ctLenhNhapXuat_DonHang);
                        foreach (CT_DonHangBan ctDonHangBan in donHangBan.CT_DonHangBanList)
                        {
                            ctLenhNhapXuat = CT_LenhNhapXuat.NewCT_LenhNhapXuat(ctDonHangBan);
                            ctLenhNhapXuatList.Add(ctLenhNhapXuat);
                        }
                    }
                }
            }
            else if (_nhapXuat == false && _Loai == 13)
            {
                foreach (DonTraHangMua donTraHangMua in donTraHangMuaList)
                {
                    if (donTraHangMua.NhapXuat == true)
                    {
                        _maDoiTac = donTraHangMua.MaDoiTac;
                        ctLenhNhapXuat_DonHang = CT_LenhNhapXuat_DonHang.NewCT_LenhNhapXuat_DonHang(donTraHangMua.MaDonHang);
                        ctLenhNhapXuat_DonHangList.Add(ctLenhNhapXuat_DonHang);
                        foreach (CT_DonTraHangMua ctDonTraHangMua in donTraHangMua.CT_DonTraHangMuaList)
                        {
                            ctLenhNhapXuat = CT_LenhNhapXuat.NewCT_LenhNhapXuat(ctDonTraHangMua);
                            ctLenhNhapXuatList.Add(ctLenhNhapXuat);
                        }
                    }
                }
            }

            for (int i = 0; i < ctLenhNhapXuatList.Count; i++ )
            {
                for (int j = 0; j < ctLenhNhapXuatList.Count; j++ )
                {
                    if (ctLenhNhapXuatList[i].MaHangHoa == ctLenhNhapXuatList[j].MaHangHoa)
                    {
                        if (i != j)
                        { 
                            ctLenhNhapXuatList[i].DonGia = (ctLenhNhapXuatList[i].DonGia + ctLenhNhapXuatList[j].DonGia) /2;                                                         
                            ctLenhNhapXuatList[i].SoLuong += ctLenhNhapXuatList[j].SoLuong;
                            ctLenhNhapXuatList[i].ThanhTien += ctLenhNhapXuatList[j].ThanhTien;
                            ctLenhNhapXuatList[i].KhoiLuong += ctLenhNhapXuatList[j].KhoiLuong;
                            
                            ctLenhNhapXuatList.RemoveAt(j);                            
                            j--;
                        }
                    }
                }
            }
            this.Close();
        }

        private void GopHangHoaTra()
        {
            //CT_DonNhanHangTraList ct_DonNhanHangTraList = CT_DonNhanHangTraList.NewCT_DonNhanHangTraList();
            //DonHangBan_DonNhanHangTraList donHangBan_DonNhanHangTraList = DonHangBan_DonNhanHangTraList.NewDonHangBan_DonNhanHangTraList();
            grdu_DanhSachDonHang.UpdateData();
            if (_Loai == 0)
            {
                foreach (DonHangMua donHangMua in donHangMuaList)
                {
                    if (donHangMua.HangTraLai == true)
                    {
                        foreach (CT_DonHangMua ct_DonHangMua in donHangMua.CT_DonHangBanList)
                        {
                            if (ct_DonHangMua.HangTraLai == true)
                            {
                                CT_DonTraHangMua ct_DonTraHangMua = CT_DonTraHangMua.NewCT_DonTraHangMua(ct_DonHangMua);
                                ct_DonTraHangMuaList.Add(ct_DonTraHangMua);
                            }
                        }
                        _maDoiTac = donHangMua.MaDoiTac;
                    }
                }
            }
            else
            {
                foreach (DonHangBan donHangBan in donHangBanList)
                {
                    if (donHangBan.HangTraLai == true)
                    {
                        foreach (CT_DonHangBan ct_DonHangBan in donHangBan.CT_DonHangBanList)
                        {
                            if (ct_DonHangBan.HangTraLai == true)
                            {
                                CT_DonNhanHangTra ct_DonNhanHangTra = CT_DonNhanHangTra.NewCT_DonNhanHangTra(ct_DonHangBan);
                                ct_DonNhanHangTraList.Add(ct_DonNhanHangTra);
                            }
                        }
                        _maDoiTac = donHangBan.MaDoiTac;
                    }
                }
            }
        }

        #endregion 

        /* Dùng Cho Đơn Nhận Hàng Trả */

        #region txt_ThongTinTimKiem_KeyDown
        private void txt_ThongTinTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_Loai==0 )
                {
                    donHangMuaList = DonHangMuaList.GetDonHangMuaList(true, 0, 9, txt_ThongTinTimKiem.Text,1);
                    donHangMuaBindingSource.DataSource = donHangMuaList;
                }
                else if (_Loai == 1)
                {
                    donNhanHangTraBindingSource.DataSource = DonNhanHangTraList.GetDonNhanHangTraList(false, txt_ThongTinTimKiem.Text);
                }
                else if (_Loai == 2)
                {
                    if (_cachTruyXuat == 1)
                        donHangBanList = DonHangBanList.GetDonHangBanChoDaiLyList(true, 0, 9, _chuoiTimKiem, _loaiDonHangTra);
                    else
                        donHangBanList = DonHangBanList.GetDonHangBanList(false, 0, 1, _chuoiTimKiem, 1);                    
                    donHangBanBindingSource.DataSource = donHangBanList;
                }
                else if (_Loai == 3)
                {
                    donTraHangMuaBindingSource.DataSource = DonTraHangMuaList.GetDonTraHangMuaList(false, txt_ThongTinTimKiem.Text);
                }
            }
        }
        #endregion 
      
        #region grdu_DanhSachDonHang_AfterCellUpdate
        private void grdu_DanhSachDonHang_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (grdu_DanhSachDonHang.ActiveCell == grdu_DanhSachDonHang.ActiveRow.Cells["HangTraLai"])
            {
                if (_Loai == 2)
                {
                    if ((Boolean)(grdu_DanhSachDonHang.ActiveRow.Cells["HangTraLai"].Value) == true)
                        ((DonHangBan)(donHangBanBindingSource.Current)).HangTraLai = true;
                    else
                    {
                        DonHangBan donHangBan = ((DonHangBan)(donHangBanBindingSource.Current));
                        int flag = 0;
                        foreach (CT_DonHangBan ct_DonHangBan in donHangBan.CT_DonHangBanList)
                        {
                            if (ct_DonHangBan.HangTraLai == true)
                            {
                                donHangBan.HangTraLai = true; flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                            donHangBan.HangTraLai = false;
                    }
                }
                else if (_Loai == 0)
                {
                        if ((Boolean)(grdu_DanhSachDonHang.ActiveRow.Cells["HangTraLai"].Value) == true)
                        ((DonHangMua)(donHangMuaBindingSource.Current)).HangTraLai = true;
                    else
                    {
                        DonHangMua donHangMua = ((DonHangMua)(donHangMuaBindingSource.Current));
                        int flag = 0;
                        foreach (CT_DonHangMua ct_DonHangMua in donHangMua.CT_DonHangBanList)
                        {
                            if (ct_DonHangMua.HangTraLai == true)
                            {
                                donHangMua.HangTraLai = true; flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                            donHangMua.HangTraLai = false;
                    }
                }
            }
           
        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        
    }
}