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


namespace PSC_ERP.UserInterface.KeToanTongHop
{
    public partial class frmDSTaiKhoan : Form
    {
        HeThongTaiKhoan1List _HeThongTaiKhoan1List;

        public string maTaiKhoanChuoi = string.Empty;
        public string soHieuTK = string.Empty;
        public frmDSTaiKhoan()
        {
            InitializeComponent();
            _HeThongTaiKhoan1List = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            TaiKhoanList_bindingSource.DataSource = _HeThongTaiKhoan1List;
        }

        private void grdu_ChiTietButToan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

            this.grdu_ChiTietButToan.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;//appearance17;

            foreach (UltraGridColumn col in this.grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;                   
                }
                col.Hidden = true;
            }

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 60;

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["Chon"].Width = 30;

                 
        }

        public void CongChuoi()
        {
            maTaiKhoanChuoi = string.Empty;
            soHieuTK = string.Empty;
            foreach (HeThongTaiKhoan1 mns in _HeThongTaiKhoan1List)
            {
                if (mns.Chon == true)
                {
                    //mns.Chon = true;
                    maTaiKhoanChuoi += mns.MaTaiKhoan + ",";
                    soHieuTK += mns.SoHieuTK + ",";

                }

            }
            if (maTaiKhoanChuoi!= "")
            {
                maTaiKhoanChuoi = maTaiKhoanChuoi.Substring(0, maTaiKhoanChuoi.Length - 1);
                soHieuTK = soHieuTK.Substring(0, soHieuTK.Length - 1);
            }
        }
        private void grdu_ChiTietButToan_CellChange(object sender, CellEventArgs e)
        {
            if (grdu_ChiTietButToan.ActiveRow.IsFilterRow != true)
            {
                Color mau = grdu_ChiTietButToan.ActiveRow.Appearance.BackColor;
                if (grdu_ChiTietButToan.ActiveCell == grdu_ChiTietButToan.ActiveRow.Cells["Chon"])
                {
                    HeThongTaiKhoan1 dt;// = DoiTuongAll.NewDoiTuongAll();
                    dt = (HeThongTaiKhoan1)(TaiKhoanList_bindingSource.Current);
                    if (dt.Chon == false)
                    {
                        dt.Chon = true;
                    }
                    else
                        dt.Chon = false;
                    if (dt.Chon == true)
                        grdu_ChiTietButToan.ActiveRow.Appearance.BackColor = Color.LightBlue;
                    else
                        grdu_ChiTietButToan.ActiveRow.Appearance.BackColor = Color.White;
                }
            }
        }

        private void frmDSBoPhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            CongChuoi();
        }
    }
}
