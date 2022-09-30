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
    public partial class frmDanhSachHoaDonLamLenhNhapXuat : Form
    {

        #region properties

        private HoaDonList _hoaDonList = HoaDonList.NewHoaDonList(); 
        private HamDungChung hamDungChung = new HamDungChung();       
        private int _Loai;
        private long _MaDoiTac = 0;

        public CT_LenhNhapXuatList ctLenhNhapXuatList = CT_LenhNhapXuatList.NewCT_LenhNhapXuatList();
        public CT_HoaDon_LenhNhapXuatList ct_HoaDon_LenhNhapXuatList = CT_HoaDon_LenhNhapXuatList.NewCT_HoaDon_LenhNhapXuatList();

        #endregion

        #region  Contructors

        public frmDanhSachHoaDonLamLenhNhapXuat()
        {
            InitializeComponent();
            Invisible();
        }          

        public frmDanhSachHoaDonLamLenhNhapXuat(int loai)
        {
            InitializeComponent();
            Invisible();
            _hoaDonList = HoaDonList.GetHoaDonList(0,(byte)1, false, 1,"");
            hoaDonBindingSource.DataSource = _hoaDonList;
        }
        #endregion     

        #region Invisible Button
        private void Invisible()
        {
            tlslblXoa.Available = false;
            tlslblUndo.Available = false;
            tlslblTim.Available = false;
            tlslblTroGiup.Available = false;
            tlslblThem.Available = false;

        }
        #endregion 
   
        #region cbx_CheckAll_CheckedChanged
        private void cbx_CheckAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbx_CheckAll.Checked == true)
            {

                foreach (ERP_Library.HoaDon hoaDon in _hoaDonList)
                {
                    hoaDon.NhapXuat = true;
                }
            }
            else
            {
                foreach (ERP_Library.HoaDon hoaDon in _hoaDonList)
                {
                    hoaDon.NhapXuat = false;
                }
            }
        }
        #endregion

        #region grdu_DanhSachHoaDon_InitializeLayout
        private void grdu_DanhSachHoaDon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.grdu_DanhSachHoaDon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grdu_DanhSachHoaDon.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NhapXuat"].Hidden = false;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.Caption = "Nhập Xuất";            
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NhapXuat"].Header.VisiblePosition= 0;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NhapXuat"].CellActivation = Activation.AllowEdit;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Hidden = false;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.Caption = "Số Serial";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Số Hóa Đơn";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Format = "###,###,###,###,###";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["TongTien"].CellAppearance.TextHAlign = HAlign.Right; 

            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";
            grdu_DanhSachHoaDon.DisplayLayout.Bands[0].Columns["NgayLap"].MaskInput = "{LOC}dd/mm/yyyy";

        }
        #endregion

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            CT_LenhNhapXuat ctLenhNhapXuat = CT_LenhNhapXuat.NewCT_LenhNhapXuat(0);
            CT_HoaDon_LenhNhapXuat ct_HoaDon_LenhNhapXuat;
            grdu_DanhSachHoaDon.UpdateData();
            foreach (HoaDon hoaDon in _hoaDonList)
            {
                if (hoaDon.NhapXuat == true)
                {
                    _MaDoiTac = hoaDon.MaDoiTac;
                    ct_HoaDon_LenhNhapXuat = CT_HoaDon_LenhNhapXuat.NewCT_HoaDon_LenhNhapXuat(hoaDon.MaHoaDon);
                    ct_HoaDon_LenhNhapXuatList.Add(ct_HoaDon_LenhNhapXuat);
                    foreach (CT_HoaDon ctHoaDon in hoaDon.CT_HoaDonList)
                    {
                        ctLenhNhapXuat = CT_LenhNhapXuat.NewCT_LenhNhapXuat(ctHoaDon);
                        ctLenhNhapXuatList.Add(ctLenhNhapXuat);
                    }
                }
            }

            for (int i = 0; i < ctLenhNhapXuatList.Count; i++)
            {
                for (int j = 0; j < ctLenhNhapXuatList.Count; j++)
                {
                    if (ctLenhNhapXuatList[i].MaHangHoa == ctLenhNhapXuatList[j].MaHangHoa)
                    {
                        if (i != j)
                        {
                            ctLenhNhapXuatList[i].DonGia = (ctLenhNhapXuatList[i].DonGia + ctLenhNhapXuatList[j].DonGia) / 2;
                            
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
        #endregion 

        #region tlslblThoat_Click(object sender, EventArgs e)
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

    }
}