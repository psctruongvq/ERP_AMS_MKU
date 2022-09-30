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
    public partial class frmLoaiThuChi_CacQuy : Form
    {
        #region Properties
        Util util = new Util();
        LoaiThuChi_CacQuyList _LoaiThuChiList;
        #endregion

        #region Loads
        public frmLoaiThuChi_CacQuy()
        {
            InitializeComponent();
            Load_Form();
        }
        
        private void grd_NhomNganHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            grd_LoaiThuChi.DisplayLayout.Bands[0].Columns["MaLoaiThuChi"].Hidden = true;
            grd_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.Caption = "Tên Chương Trình";
            grd_LoaiThuChi.DisplayLayout.Bands[0].Columns["IsThu"].Header.Caption = "Là thu";
            grd_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Header.VisiblePosition = 1;
            grd_LoaiThuChi.DisplayLayout.Bands[0].Columns["IsThu"].Header.VisiblePosition = 2;

            grd_LoaiThuChi.DisplayLayout.Bands[0].Columns["IsThu"].Width = 100;
            grd_LoaiThuChi.DisplayLayout.Bands[0].Columns["TenLoaiThuChi"].Width = 250;

            foreach (UltraGridColumn col in grd_LoaiThuChi.DisplayLayout.Bands[0].Columns)
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
            _LoaiThuChiList = LoaiThuChi_CacQuyList.GetLoaiThuChi_CacQuyList();
            LoaiThuChiCacQuy_bindingSource.DataSource = _LoaiThuChiList;
        }
        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _LoaiThuChiList.Count; i++)
                {
                    if (_LoaiThuChiList[i].TenLoaiThuChi == string.Empty)
                    {
                        MessageBox.Show(this, "Vui lòng nhập tên chương trình", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                grd_LoaiThuChi.UpdateData();
                LoaiThuChiCacQuy_bindingSource.EndEdit();
                _LoaiThuChiList.ApplyEdit();
                _LoaiThuChiList.Save();
                MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grd_LoaiThuChi.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grd_LoaiThuChi.DeleteSelectedRows();
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