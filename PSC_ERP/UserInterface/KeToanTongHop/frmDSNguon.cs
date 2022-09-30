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
    public partial class  frmDSNguon : Form
    {
        NguonList _NguonList;
        public string maNguonChuoi = string.Empty;
        public string maNguonQL = string.Empty;
        public frmDSNguon()
        {
            InitializeComponent();
            _NguonList = NguonList.GetNguonList();
            BindS_nguon.DataSource = _NguonList;

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
                    col.Format = "#,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;                   
                }
                col.Hidden = true;
            }

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["chon"].Hidden = false;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["chon"].Header.VisiblePosition = 0;


            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 1;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenNguon"].Width = 300;
                 
        }

        public void CongChuoi()
        {
            grdu_ChiTietButToan.UpdateData();
            maNguonChuoi = string.Empty;
            maNguonQL = string.Empty;
           
            foreach (Nguon mns in _NguonList)
            {
                if (mns.Chon == true)
                {
                    maNguonChuoi += mns.MaNguon+ ",";
                    maNguonQL += mns.MaNguonQuanLy + ",";

                }

            }
            if (maNguonChuoi != "")
            {
                maNguonChuoi = maNguonChuoi.Substring(0, maNguonChuoi.Length - 1);
                maNguonQL = maNguonQL.Substring(0, maNguonQL.Length - 1);
            }
        }
  
        private void frmDSBoPhan_FormClosed(object sender, FormClosedEventArgs e)
        {
            CongChuoi();
        }
    }
}
