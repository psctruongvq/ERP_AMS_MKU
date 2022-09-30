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
    public partial class frmLuuTruCapHoaDon : Form
    {
       
        LuuTruCapPhatHoaDonList _luutrucapphathdlist;       
        Util util = new Util();
        HamDungChung hdc = new HamDungChung();


        #region Contructor
        public frmLuuTruCapHoaDon()
        {
            InitializeComponent();         
            KhoiTao();
        }
        #endregion

        #region KhoiTao
        public void KhoiTao()
        {
            _luutrucapphathdlist = LuuTruCapPhatHoaDonList.GetLuuTruCapPhatHoaDonList();
            bindsluutrucaphd.DataSource = _luutrucapphathdlist;
        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {        
            this.Close();         
        }
        #endregion

        #region tlslblXoa_Click
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_KyHan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_KyHan.DeleteSelectedRows();
        }
        #endregion
      
        #region tlslblLuu_Click
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            grdu_KyHan.UpdateData();
            // kiem tra tinh hop le cap phat hoa don
            _luutrucapphathdlist.ApplyEdit();
            _luutrucapphathdlist.Save();
            MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            KhoiTao();
        }
        #endregion      

        #region grdu_KyHan_InitializeLayout
        private void grdu_KyHan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grdu_KyHan.DisplayLayout.Bands[0].Columns["id"].Hidden = true;
            grdu_KyHan.DisplayLayout.Bands[0].Columns["Tentt"].Header.Caption = "Tên TT" ;
            grdu_KyHan.DisplayLayout.Bands[0].Columns["NgayCap"].Header.Caption = "Ngày Cấp";
            grdu_KyHan.DisplayLayout.Bands[0].Columns["KyHieu"].Header.Caption = "Ký Hiệu";
            grdu_KyHan.DisplayLayout.Bands[0].Columns["Tuso"].Header.Caption = "Từ Số";

            grdu_KyHan.DisplayLayout.Bands[0].Columns["Denso"].Header.Caption = "Đến Số";
            grdu_KyHan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            hdc.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

     
    }
}