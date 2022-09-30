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
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmLoaiKetChuyen : Form
    {
        #region properties
        LoaiKetChuyenList _loaiKetChuyenList;
        Util util = new Util();
        HamDungChung hdc = new HamDungChung();
        
        #endregion

        #region Contructor
        public frmLoaiKetChuyen()
        {
            InitializeComponent();         
            KhoiTao();
        }
        #endregion

        #region KhoiTao
        public void KhoiTao()
        {
            _loaiKetChuyenList = LoaiKetChuyenList.GetLoaiKetChuyenList();
            LoaiKetChuyen_BindingSource.DataSource = _loaiKetChuyenList;
        }
        #endregion

     
        private void grdu_KyHan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            foreach (UltraGridColumn col in this.grdu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            grdu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Hidden = false;

            grdu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Header.VisiblePosition = 0;

            grdu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Header.Caption = "Tên Loại Kết Chuyển";
            grdu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Header.VisiblePosition = 1;
            grdu_LoaiKetChuyen.DisplayLayout.Bands[0].Columns["TenLoaiKetChuyen"].Width = 400;



        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            grdu_LoaiKetChuyen.UpdateData();
            _loaiKetChuyenList.ApplyEdit();

            foreach (LoaiKetChuyen item in _loaiKetChuyenList)
            {

                if (string.IsNullOrEmpty(item.TenLoaiKetChuyen))
                {
                    MessageBox.Show(this, "Vui lòng nhập tên loại hóa đơn.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            _loaiKetChuyenList.Save();
            MessageBox.Show(this, util.luuthanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            KhoiTao();
        
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdu_LoaiKetChuyen.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn dòng cần xóa.", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            grdu_LoaiKetChuyen.DeleteSelectedRows();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void frmLoaiKetChuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                btnLuu_Click(sender,e);
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                btnXoa_Click(sender, e);
            }
            if (e.Alt && e.KeyCode == Keys.X)
            {
                btnThoat_Click(sender, e);
            }
        }
    }
}