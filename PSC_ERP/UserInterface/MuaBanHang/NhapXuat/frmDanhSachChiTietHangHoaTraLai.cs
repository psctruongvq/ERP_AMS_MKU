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


namespace PSC_ERP
{
    public partial class frmDanhSachChiTietHangHoaTraLai : Form
    {
        HamDungChung hamDungChung = new HamDungChung();
        CT_DonNhanHangTraList ct_DonNhanHangTraList = CT_DonNhanHangTraList.NewCT_DonNhanHangTraList();
        //DonNhanHangTra donNhanHangTra = DonNhanHangTra.NewDonNhanHangTra(0);
        long MaDoiTac =0 ;
        int MaKho = 0;  
      
        #region Contructors
        public frmDanhSachChiTietHangHoaTraLai()
        {
            InitializeComponent();
            KhoiTao();
        }
        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListTheoLoaiKhachHang(5);
            loaiHangHoaListBindingSource.DataSource = LoaiHangHoaList.GetLoaiHangHoaList(0);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            donViTinhListBindingSource1.DataSource = DonViTinhList.GetDonViTinhList();
            cTDonNhanHangTraListBindingSource.DataSource = ct_DonNhanHangTraList;            
            if (cb_DaiLy.SelectedItem != null)
            {
                MaDoiTac = ((DoiTac)(cb_DaiLy.SelectedItem)).MaDoiTac;
                khoListBindingSource.DataSource = KhoList.GetKhoList_KhoDaiLyByMaDaiLy(MaDoiTac);
            }             
        }
        #endregion 

        #region cb_DaiLy_SelectedValueChanged
        private void cb_DaiLy_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_DaiLy.SelectedItem != null)
            {
                MaDoiTac = ((DoiTac)(cb_DaiLy.SelectedItem)).MaDoiTac ;
                khoListBindingSource.DataSource = KhoList.GetKhoList_KhoDaiLyByMaDaiLy(MaDoiTac);
            }
        }
        #endregion      

        #region cmbu_LoaiHangHoa_ValueChanged
        private void cmbu_LoaiHangHoa_ValueChanged(object sender, EventArgs e)
        {
            //if (cmbu_LoaiHangHoa.ActiveRow != null)
            //{               
            //   int MaLoaiHangHoa = (int)cmbu_LoaiHangHoa.ActiveRow.Cells["MaLoaiHangHoa"].Value;
            //   hangHoaListBindingSource.DataSource = HangHoaList.GetHangHoaList(MaLoaiHangHoa, 0);
            //}
        }
        #endregion 

        #region cmbu_LoaiHangHoa_InitializeLayout
        private void cmbu_LoaiHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cmbu_LoaiHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_LoaiHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }


            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Loại Hàng";
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = false;
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Tên Loại Hàng Hóa";
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 1;
        }
        #endregion 

        #region grdu_DanhSachHangHoaTraLai_InitializeLayout
        private void grdu_DanhSachHangHoaTraLai_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                    
                }
                //x =  //= System.Drawing.w;//RoyalBlue
            }          
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Loại Hàng Hóa";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 0;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].EditorControl = cmbu_LoaiHangHoa;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Hàng Hóa";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenHangHoa"].EditorControl = ultraCbHangHoa;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenHangHoa"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 2;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["SoLuong"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 3;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenDonViTinh"].EditorControl = ultraCbDonViTinh;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Header.Caption = "Khối Lượng Vàng";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Header.VisiblePosition = 4;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].MaskInput = "nnnnnnnnn.nnnn";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["KhoiLuongDa"].Header.Caption = "Khối Lượng Đá";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["KhoiLuongDa"].Header.VisiblePosition = 5;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["KhoiLuongDa"].MaskInput = "nnnnnnnnn.nnnn";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["KhoiLuongDa"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenDonViKhoiLuong"].Header.Caption = "Đơn Khối Lượng";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenDonViKhoiLuong"].Header.VisiblePosition = 6;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenDonViKhoiLuong"].EditorControl = cmbu_DonViKhoiLuong;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["TenDonViKhoiLuong"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 6;            
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["DonGia"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["DGTienCong"].Header.Caption = "ĐG Tiền Công";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["DGTienCong"].Header.VisiblePosition = 6;            
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["DGTienCong"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["DGTienDa"].Header.Caption = "ĐG Tiền Đá";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["DGTienDa"].Header.VisiblePosition = 6;
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["DGTienDa"].Hidden = false;

            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["ChuaBan"].Header.Caption = "Chưa Bán";
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["ChuaBan"].Header.VisiblePosition = 7;            
            grdu_DanhSachHangHoaTraLai.DisplayLayout.Bands[0].Columns["ChuaBan"].Hidden = false; 

            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion 

        #region cmbu_DonViKhoiLuong_InitializeLayout
        private void cmbu_DonViKhoiLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            cmbu_DonViKhoiLuong.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.cmbu_DonViKhoiLuong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.cmbu_DonViKhoiLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

            cmbu_DonViKhoiLuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_DonViKhoiLuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã DVT";
            cmbu_DonViKhoiLuong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cmbu_DonViKhoiLuong.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Hidden = false;
            cmbu_DonViKhoiLuong.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Tính";
            cmbu_DonViKhoiLuong.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 1;
        }
        #endregion 

        #region ultraCbDonViTinh_InitializeLayout
        private void ultraCbDonViTinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Số";
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Tên Đơn Vị Tính";
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 2;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["MaTinhTrang"].Hidden = true;
            ultraCbDonViTinh.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;

            this.ultraCbHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCbDonViTinh.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraCbDonViTinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
        }
        #endregion 

        #region ultraCbHangHoa_InitializeLayout
        private void ultraCbHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.ultraCbHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraCbHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraCbHangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Hàng";
            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 1;
            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;

            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Tên Hàng Hóa";
            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 2;
            ultraCbHangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Hidden = false;

        }
        #endregion 

        #region grdu_DanhSachHangHoaTraLai_KeyDown
        private void grdu_DanhSachHangHoaTraLai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                grdu_DanhSachHangHoaTraLai.UpdateData();
            }
        }
        #endregion 

        #region ultraCbHangHoa_ValueChanged
        private void ultraCbHangHoa_ValueChanged(object sender, EventArgs e)
        {
            if (ultraCbHangHoa.ActiveRow != null)
            {
                ((CT_DonNhanHangTra)cTDonNhanHangTraListBindingSource.Current).MaHangHoa = (int)(ultraCbHangHoa.ActiveRow.Cells["MaHangHoa"].Value);
            }
        }
        #endregion 

        #region cb_Kho_SelectedValueChanged
        private void cb_Kho_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_Kho.SelectedItem != null)
            {
                MaKho = ((Kho)(cb_Kho.SelectedItem)).MaKho;
            }
        }
        #endregion 

        #region bt_DonHangTraTuKhachHang_Click
        private void bt_DonHangTraTuKhachHang_Click(object sender, EventArgs e)
        {
            DonNhanHangTra donNhanHangTra = DonNhanHangTra.NewDonNhanHangTra(0, 4);
            donNhanHangTra.MaDoiTac = MaDoiTac;
            donNhanHangTra.MaKho = MaKho;
            foreach (CT_DonNhanHangTra ct_DonNhanHangTra in ct_DonNhanHangTraList)
            {
                if(ct_DonNhanHangTra.ChuaBan == false)
                    donNhanHangTra.CT_DonNhanHangTraList.Add(ct_DonNhanHangTra);
            }
            frmDonNhanHangTra dlg = new frmDonNhanHangTra(donNhanHangTra);
            dlg.ShowDialog();
        }
        #endregion 

        #region bt_DonHangTraTuKho_Click
        private void bt_DonHangTraTuKho_Click(object sender, EventArgs e)
        {
            DonNhanHangTra donNhanHangTra = DonNhanHangTra.NewDonNhanHangTra(0, 5);
            donNhanHangTra.MaDoiTac = MaDoiTac;
            donNhanHangTra.MaKho = MaKho;
            foreach (CT_DonNhanHangTra ct_DonNhanHangTra in ct_DonNhanHangTraList)
            {
                if (ct_DonNhanHangTra.ChuaBan == true)
                    donNhanHangTra.CT_DonNhanHangTraList.Add(ct_DonNhanHangTra);
            }
            frmDonNhanHangTra dlg = new frmDonNhanHangTra(donNhanHangTra);
            dlg.ShowDialog(); 
        }
        #endregion 

        #region grdu_DanhSachHangHoaTraLai_AfterCellUpdate
        private void grdu_DanhSachHangHoaTraLai_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (grdu_DanhSachHangHoaTraLai.ActiveCell == grdu_DanhSachHangHoaTraLai.ActiveRow.Cells["TenHangHoa"])
            {
                if (grdu_DanhSachHangHoaTraLai.ActiveRow != null)
                {
                    CT_DonNhanHangTra ct_DonNhanHangTra = (CT_DonNhanHangTra)cTDonNhanHangTraListBindingSource.Current;
                    byte tinhTrang = 0;
                    DonHangBanList donHangBanList = DonHangBanList.NewDonHangBanList();
                    if (ct_DonNhanHangTra.MaHangHoa != 0)
                    {
                        donHangBanList = DonHangBanList.GetDonHangBanChoDaiLyList(MaDoiTac, MaKho, ct_DonNhanHangTra.MaHangHoa, 4);
                        tinhTrang = 4;
                        if (donHangBanList.Count == 0)
                        {
                            donHangBanList = DonHangBanList.GetDonHangBanChoDaiLyList(MaDoiTac, MaKho, ct_DonNhanHangTra.MaHangHoa, 2);
                            tinhTrang = 2;
                        }
                    }
                    if (donHangBanList.Count != 0)
                    {
                        frmDanhSachDonHangBanCanTraHang dlg = new frmDanhSachDonHangBanCanTraHang(donHangBanList, tinhTrang, ct_DonNhanHangTra.MaHangHoa);
                        if (dlg.ShowDialog() != DialogResult.OK)
                        {
                            CT_DonNhanHangTra _ct_DonNhanHangTra = dlg.ct_DonNhanHangTra;
                            
                            ct_DonNhanHangTra.DonGia = _ct_DonNhanHangTra.DonGia;
                            ct_DonNhanHangTra.MaDonHangBan = _ct_DonNhanHangTra.MaDonHangBan;
                            if (tinhTrang == 4)
                                ct_DonNhanHangTra.ChuaBan = true;
                            else if (tinhTrang == 2)
                                ct_DonNhanHangTra.ChuaBan = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Mặt Hàng Chưa Từng Xuất Cho Đại Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
        #endregion 

        private void frmDanhSachChiTietHangHoaTraLai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Lap Danh Sach Hang Hoa Tra Lai", "Help_BanHang.chm");
            }
        }
    }
}