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
    public partial class frmChiTietButToan : Form
    {
        ButToan _ButToan;
        CT_PhieuNXList _CT_PhieuNXList;
        Util util = new Util();

        #region Contructors  
        public frmChiTietButToan(ButToan butToan)
        {
            InitializeComponent();
            _ButToan = butToan;
           // _CT_PhieuNXList = ct_PhieuNXList;
            KhoiTao();
        }
        #endregion 

        #region Khởi Tạo
        private void KhoiTao()
        {
            chiTietButToanListBindingSource.DataSource = _ButToan.ChiTietButToanList;
        }
        #endregion 

        #region grdu_ChiTietButToan_InitializeLayout
        private void grdu_ChiTietButToan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaChiTiet"].Hidden = true;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaButToan"].Hidden = true;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaHangHoa"].Hidden = true;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["MaLoaiVang"].Hidden = true;

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Hàng Hóa";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 0;            

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenLoaiVang"].Header.Caption = "Loại Vàng";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenLoaiVang"].Width = 100;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TenLoaiVang"].Header.VisiblePosition = 1;

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TuoiVang"].Header.Caption = "Tuổi Vàng";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TuoiVang"].Width = 70;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["TuoiVang"].Header.VisiblePosition = 2;         

            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Header.Caption = "Khối Lượng Vàng";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Header.VisiblePosition = 3;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].MaskInput = "nnnnnnnnn";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["KhoiLuongVang"].Width = 70;
            
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["KhoiLuongQ10"].Header.Caption = "Khối Lượng Q10";            
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["KhoiLuongQ10"].Width = 100;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["KhoiLuongQ10"].Header.VisiblePosition = 4;
                        
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["SoLuong"].Header.Caption = "Số Lượng";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["SoLuong"].Header.VisiblePosition = 5;
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["SoLuong"].MaskInput = "nnnnnnnnn";
            grdu_ChiTietButToan.DisplayLayout.Bands[0].Columns["SoLuong"].Width = 70;
            
            

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
            }
        }
        #endregion 

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            _ButToan.ChiTietButToanList = ChiTietButToanList.NewChiTietButToanList();
            this.Close();
        }
        #endregion 

        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
             if (grdu_ChiTietButToan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_ChiTietButToan.DeleteSelectedRows();

        }
        #endregion 
    }
}