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
    public partial class frmNhomNganHang : Form
    {
        #region Properties
        Util util = new Util();
        NhomNganHangList _nhomNganHangList;
        #endregion

        #region Loads
        public frmNhomNganHang()
        {
            InitializeComponent();
            Load_Form();
        }
        
        private void grd_NhomNganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["MaNhomNganHang"].Hidden = true;
            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["TenNhomNganHang"].Header.Caption = "Tên ngân hàng";
            //grd_NhomNganHang.DisplayLayout.Bands[0].Columns["MaUNCNganHang"].Header.Caption = "Mã UNC";
            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["ChuVietTat"].Header.Caption = "Mã ngân hàng";
            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["ChuVietTat"].Header.VisiblePosition = 0;
            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["TenNhomNganHang"].Header.VisiblePosition = 1;
            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["MaUNCNganHang"].Header.VisiblePosition = 2;

            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["ChuVietTat"].Width = 150;
            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["TenNhomNganHang"].Width = 250;
            //grd_NhomNganHang.DisplayLayout.Bands[0].Columns["MaUNCNganHang"].Width = 120;

            //grd_NhomNganHang.DisplayLayout.Bands[0].Columns["SoUNCBatDau"].Hidden = true;
            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["SoUNCBatDau"].Header.Caption = "Số bắt đầu";
            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["SoUNCBatDau"].Header.VisiblePosition = 7;
            grd_NhomNganHang.DisplayLayout.Bands[0].Columns["SoUNCBatDau"].Width = 100; 

            foreach (UltraGridColumn col in grd_NhomNganHang.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.White;
            }
        }
        #endregion

        #region Process
        private void Load_Form()
        {
            _nhomNganHangList = NhomNganHangList.GetNhomNganHangList();
            NhomNganHang_bindingSource.DataSource = _nhomNganHangList;
        }
        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _nhomNganHangList.Count; i++)
                {
                    if (_nhomNganHangList[i].TenNhomNganHang == string.Empty)
                    {
                        MessageBox.Show(this, "Vui lòng nhập tên nhóm ngân hàng", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                grd_NhomNganHang.UpdateData();
                NhomNganHang_bindingSource.EndEdit();
                _nhomNganHangList.ApplyEdit();
                _nhomNganHangList.Save();
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grd_NhomNganHang.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_NhomNganHang.DeleteSelectedRows();
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