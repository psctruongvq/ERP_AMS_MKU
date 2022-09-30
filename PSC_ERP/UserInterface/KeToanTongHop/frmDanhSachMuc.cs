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

namespace PSC_ERP.UserInterface.KeToanTongHop
{
    public partial class frmDanhSachMuc : Form
    {
        MucNganSachList _MucNganSachList;
        public string MaMuc = string.Empty;
        public string MaMucQL = string.Empty;

        public frmDanhSachMuc()
        {
            InitializeComponent();
            _MucNganSachList = MucNganSachList.GetMucNganSachList();
            bindingSource_MucNganSachList.DataSource = _MucNganSachList;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            CongChuoi();
         
        }


        public void CongChuoi()
        {
            MaMuc = string.Empty;
            MaMucQL = string.Empty;
            foreach (MucNganSach mns in _MucNganSachList)
            {
                if (mns.Chon == true)
                {
                    //mns.Chon = true;
                    MaMuc += mns.MaMucNganSach + ",";
                    MaMucQL += mns.MaMucNganSachQL + ",";

                }              

            }
            if (MaMuc != "")
            {
                MaMuc = MaMuc.Substring(0, MaMuc.Length - 1);
                MaMucQL = MaMucQL.Substring(0, MaMucQL.Length - 1);
            }
        }


        private void grdu_ChiTietButToan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaMucNganSach"].Hidden = true;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaTieuNhom"].Hidden = true;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenTieuNhom"].Hidden = true;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = true;
           

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.Caption = "Mã Mục NS";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Width = 80;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaMucNganSachQL"].Header.VisiblePosition = 0;

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.Caption = "Tên Mục Ngân Sách";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Width = 350;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenMucNganSach"].Header.VisiblePosition = 1;

           

            foreach (UltraGridColumn col in this.grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                    col.CellAppearance.TextHAlign = HAlign.Center;
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
                    col.Format = "###,###,###,###,###,###";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
        }

        private void grdu_ChiTietButToan_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (grdu_ChiTietButToan.ActiveRow.IsFilterRow != true)
            {
                Color mau = grdu_ChiTietButToan.ActiveRow.Appearance.BackColor;
                if (grdu_ChiTietButToan.ActiveCell == grdu_ChiTietButToan.ActiveRow.Cells["Chon"])
                {
                    MucNganSach dt;// = DoiTuongAll.NewDoiTuongAll();
                    dt = (MucNganSach)(bindingSource_MucNganSachList.Current);
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

        private void frmDanhSachMuc_FormClosed(object sender, FormClosedEventArgs e)
        {
            CongChuoi();
        }
    }
}
