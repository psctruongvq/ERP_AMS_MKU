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
    public partial class frmNhomKhachHang : Form
    {
        #region properties
        NhomKhachHangList _NhomKhachHangList;        
        HamDungChung hamDungChung = new HamDungChung();
        Util util = new Util();
        #endregion

        #region Contructor
        public frmNhomKhachHang()
        {
            InitializeComponent();
            KhoiTao();
        }
        #endregion

        #region KhoiTao
        public void KhoiTao()
        {            
            _NhomKhachHangList = NhomKhachHangList.GetNhomKhachHangList();        
            nhomKhachHangListBindingSource.DataSource = _NhomKhachHangList;
        }
        #endregion

        #region ultraGridNhomKH_InitializeLayout
        private void ultraGridNhomKH_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //tiêu đề
            grdu_NhomKH.DisplayLayout.Bands[0].Columns["MaNhomKhachHang"].Hidden = true;
            grdu_NhomKH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Nhóm Khách Hàng";
            grdu_NhomKH.DisplayLayout.Bands[0].Columns["TenNhomKhachHang"].Header.Caption = "Tên Nhóm Khách Hàng";
            grdu_NhomKH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            grdu_NhomKH.DisplayLayout.Bands[0].Columns["TenNhomKhachHang"].Header.VisiblePosition = 1;

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_NhomKH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.grdu_NhomKH.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_NhomKH.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion                       

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdu_NhomKH.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_NhomKH.DeleteSelectedRows();            
        }
        #endregion

        #region grdu_NhomKH_KeyDown
        private void grdu_NhomKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdu_NhomKH.UpdateData();
            }
        }
        #endregion

        #region Lưu nhóm khách hàng mới
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                _NhomKhachHangList.ApplyEdit();
                _NhomKhachHangList.Save();
                MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.thatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                string tem = ex.Message;
            }
        }
         #endregion

        #region Thoát 
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        #endregion

        private void frmNhomKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Nhom Khach Hang", "Help_BanHang.chm");
            }
        }
    }
}