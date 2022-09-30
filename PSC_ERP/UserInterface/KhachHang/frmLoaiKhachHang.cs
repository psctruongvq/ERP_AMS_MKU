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
    public partial class frmLoaiKhachHang : Form
    {
        #region Properties
        HamDungChung hamDungChung = new HamDungChung();
        Util util = new Util();
        LoaiKhachHangList _LoaiKhachHangList;
        #endregion

        #region Contructor
        public frmLoaiKhachHang()
        {
            InitializeComponent();
            KhoiTao();
        }
        #endregion

        #region Hàm khởi tạo
        public void KhoiTao()
        {
            _LoaiKhachHangList = LoaiKhachHangList.GetLoaiKhachHangList();
            loaiKhachHangListBindingSource.DataSource = _LoaiKhachHangList;
        }
        #endregion

        #region ultraGridLoaiKH_InitializeLayout
        private void ultraGridLoaiKH_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //tiêu đề
            grdu_LoaiKH.DisplayLayout.Bands[0].Columns["MaLoaiKhachHang"].Hidden = true;
            grdu_LoaiKH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Loại Khách Hàng";
            grdu_LoaiKH.DisplayLayout.Bands[0].Columns["TenLoaiKhachHang"].Header.Caption = "Tên Loại Khách Hàng";
            grdu_LoaiKH.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            grdu_LoaiKH.DisplayLayout.Bands[0].Columns["TenLoaiKhachHang"].Header.VisiblePosition = 1;

            //màu và font chữ
            foreach (UltraGridColumn col in this.grdu_LoaiKH.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.grdu_LoaiKH.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            this.grdu_LoaiKH.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            hamDungChung.ultragrdEmail_InitializeLayout(sender, e);
        }
        #endregion

        #region Lưu 1 loại khách hàng
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _LoaiKhachHangList.ApplyEdit();
                _LoaiKhachHangList.Save();
                MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, util.luuthatbai, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                string tem = ex.Message;
            }
        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grdu_LoaiKH.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_LoaiKH.DeleteSelectedRows();          
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

        #region grdu_LoaiKH_KeyDown
        private void grdu_LoaiKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grdu_LoaiKH.UpdateData();
            }
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            int MaLoaiKhachHang;
        }
        #endregion 

        private void frmLoaiKhachHang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Loai Khach Hang", "Help_BanHang.chm");
            }
        }


    }
}