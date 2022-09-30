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
    public partial class frmChiTietDotGiaoNhan : Form
    {
        CT_HopDongMuaBanList _ctHopDongMuaBanList;
        HamDungChung _hamDungChung = new HamDungChung();
        CT_DotGiaoHangHDMBList _ctDotGiaoHangHDMBList = CT_DotGiaoHangHDMBList.NewCT_DotGiaoHangHDMBList();        
        DotGiaoHangHDMB _dotGiaoHangHDMB;

        #region Contructors

        public frmChiTietDotGiaoNhan()
        {
            InitializeComponent();
            Invisible();
        }
        public frmChiTietDotGiaoNhan(DotGiaoHangHDMB dotGiaoHangHDMB, CT_HopDongMuaBanList ctHopDongMuaBanList)
        {
            InitializeComponent();
            Invisible();
            _ctHopDongMuaBanList = ctHopDongMuaBanList;
           
            _dotGiaoHangHDMB = dotGiaoHangHDMB;
            if (dotGiaoHangHDMB.CT_DotGiaoHangHDMBList.Count == 0)
            {
                KhoiTaoChiTietDotGiaoNhan();
                _dotGiaoHangHDMB.CT_DotGiaoHangHDMBList = _ctDotGiaoHangHDMBList;
            }
            cTDotGiaoHangHDMBListBindingSource.DataSource = _dotGiaoHangHDMB.CT_DotGiaoHangHDMBList;            
           
        }

        private void KhoiTaoChiTietDotGiaoNhan()
        {
            CT_DotGiaoHangHDMB ctDotGiaoNhanHDMB;            
            foreach (CT_HopDongMuaBan ctHopDongMuaBan in _ctHopDongMuaBanList)
            {
                ctDotGiaoNhanHDMB = CT_DotGiaoHangHDMB.NewCT_DotGiaoHangHDMB(ctHopDongMuaBan);
                _ctDotGiaoHangHDMBList.Add(ctDotGiaoNhanHDMB);
            }          
        }
        #endregion

        #region Kiểm Tra

        private Boolean KiemTra()
        {
            Boolean kq = true;
            foreach (CT_DotGiaoHangHDMB ct_DotGiaoHangHDMB in _dotGiaoHangHDMB.CT_DotGiaoHangHDMBList)
            {
                foreach (CT_HopDongMuaBan ct_HopDongMuaBan in _ctHopDongMuaBanList)
                {
                    if(ct_DotGiaoHangHDMB.MaHangHoa == ct_HopDongMuaBan.MaHangHoa)
                    {
                        if (ct_HopDongMuaBan.SoLuong < ct_DotGiaoHangHDMB.SoLuong)
                        {
                            MessageBox.Show(this, "Vui Lòng Nhập Số Lượng Đợt Giao Hàng <=" + ct_HopDongMuaBan.SoLuong.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            kq = false;
                        }
                        else if (ct_HopDongMuaBan.KhoiLuong< ct_DotGiaoHangHDMB.KhoiLuong)
                        {
                            MessageBox.Show(this, "Vui Lòng Nhập Khối Lượng Đợt Giao Hàng <=" + ct_HopDongMuaBan.KhoiLuong.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            kq = false;
                        }
                    }
                }
            }
            return kq;
            
        }
            
        #endregion

        #region Invisible Button
        private void Invisible()
        {
            //tlslblXoa.Available = false;
            //tlslblUndo.Available = false;
            //tlslblTim.Available = false;
            //tlslblTroGiup.Available = false;
            //tlslblThem.Available = false;
        }
          #endregion 

        #region urdu_ChiTietDotGiaoNhan_InitializeLayout
        private void urdu_ChiTietDotGiaoNhan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {            
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["MaDotGiaoHang"].Hidden = true;
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = true;

            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Thể Loại";
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 0;
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Hàng Hóa/Dịch Vụ";
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 1;

            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 2;

            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["MaDonViTinh"].Hidden = true;
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.Caption = "Đơn Vị Tính";
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["TenDonViTinh"].Header.VisiblePosition = 3;                                          

            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["KhoiLuong"].Header.Caption = "Khối Lượng";
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["KhoiLuong"].Header.VisiblePosition = 4;
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["KhoiLuong"].Hidden = true;

            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["DonGia"].Header.Caption = "Đơn Giá";
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["DonGia"].Header.VisiblePosition = 6;            

           
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 9;

            urdu_ChiTietDotGiaoNhan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.urdu_ChiTietDotGiaoNhan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.urdu_ChiTietDotGiaoNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                }
            }
        }
        #endregion

        #region Sự Kiện Click

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            _dotGiaoHangHDMB.CT_DotGiaoHangHDMBList = CT_DotGiaoHangHDMBList.NewCT_DotGiaoHangHDMBList();
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            urdu_ChiTietDotGiaoNhan.DeleteSelectedRows();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if(KiemTra()==true)
                this.Close();
        }
        #endregion
      
    }
}