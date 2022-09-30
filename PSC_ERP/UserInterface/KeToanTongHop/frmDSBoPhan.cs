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
    public partial class frmDSBoPhan : Form
    {
        BoPhanList _BoPhanList;
        public string maBoPhanChuoi = string.Empty;

        public string maBoPhanQL = string.Empty;

        public frmDSBoPhan()
        {
            InitializeComponent();
            _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhanList_bindingSource.DataSource = _BoPhanList;

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

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bô Phân";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaBoPhanQl"].Width = 60;

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 200;


            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["Chon"].Width = 30;

                 
        }


        public void CongChuoi()
        {
            maBoPhanChuoi = string.Empty;
            maBoPhanQL = string.Empty;
            foreach (BoPhan mns in _BoPhanList)
            {
                if (mns.Chon == true)
                {
                    //mns.Chon = true;
                    maBoPhanChuoi += mns.MaBoPhan + ",";
                    maBoPhanQL += mns.MaBoPhanQL + ",";

                }

            }
            if (maBoPhanChuoi!= "")
            {
                maBoPhanChuoi = maBoPhanChuoi.Substring(0, maBoPhanChuoi.Length - 1);
                maBoPhanQL = maBoPhanQL.Substring(0, maBoPhanQL.Length - 1);
            }
        }
        private void grdu_ChiTietButToan_CellChange(object sender, CellEventArgs e)
        {
            if (grdu_ChiTietButToan.ActiveRow.IsFilterRow != true)
            {
                Color mau = grdu_ChiTietButToan.ActiveRow.Appearance.BackColor;
                if (grdu_ChiTietButToan.ActiveCell == grdu_ChiTietButToan.ActiveRow.Cells["Chon"])
                {
                    BoPhan dt;// = DoiTuongAll.NewDoiTuongAll();
                    dt = (BoPhan)(BoPhanList_bindingSource.Current);
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
