using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmLoaiQuy : Form
    {
        #region Properties
        Util util = new Util();
        LoaiQuyList _loaiQuyList;
        #endregion

        #region Loads
        public frmLoaiQuy()
        {
            InitializeComponent();
            Load_Form();
        }
        
        private void grd_NhomNganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            foreach (UltraGridColumn col in grd_LoaiQuy.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.White;
                col.Hidden = true;
            }
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["MaCacQuyQL"].Hidden = false;
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["MaCacQuyQL"].Header.Caption = "Mã Quản Lý";
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["MaCacQuyQL"].Header.VisiblePosition = 0;
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["MaCacQuyQL"].Width = 120;

            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["TenCacQuy"].Hidden = false;
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["TenCacQuy"].Header.Caption = "Tên Các Quỹ";
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["TenCacQuy"].Header.VisiblePosition = 1;
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["TenCacQuy"].Width = 250;

            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày lập";
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;
            grd_LoaiQuy.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 100;
        }
        #endregion

        #region Process
        private void Load_Form()
        {
            _loaiQuyList = LoaiQuyList.GetLoaiQuyList();
            LoaiQuy_bindingSource.DataSource = _loaiQuyList;
        }
        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _loaiQuyList.Count; i++)
                {
                    if (_loaiQuyList[i].TenCacQuy == string.Empty)
                    {
                        MessageBox.Show(this, "Vui lòng nhập tên các quỹ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                grd_LoaiQuy.UpdateData();
                LoaiQuy_bindingSource.EndEdit();
                _loaiQuyList.ApplyEdit();
                _loaiQuyList.Save();
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grd_LoaiQuy.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_LoaiQuy.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}