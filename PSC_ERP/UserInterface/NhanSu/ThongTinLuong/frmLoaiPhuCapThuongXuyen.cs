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

namespace PSC_ERP
{
    public partial class frmLoaiPhuCapThuongXuyen : Form
    {
        #region Properties
        LoaiPhuCapTXList _LoaiPhuCapTXList;
        HamDungChung t = new HamDungChung();
        Util _Util = new Util();
        #endregion

        #region Events
        public frmLoaiPhuCapThuongXuyen()
        {
            InitializeComponent();
        }

        private void LayDuLieuLenLuoi()
        {
            _LoaiPhuCapTXList = LoaiPhuCapTXList.GetLoaiPhuCapTXList();
            LoaiPhuCapTX_BindingSource.DataSource = _LoaiPhuCapTXList;
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _LoaiPhuCapTXList.Count; i++)
            {
                for (int j = 0; j < _LoaiPhuCapTXList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_LoaiPhuCapTXList[i].MaQuanLy.Trim() == _LoaiPhuCapTXList[j].MaQuanLy.Trim())
                        {
                            LoaiPhuCapTX cv = LoaiPhuCapTX.GetLoaiPhuCapTX(_LoaiPhuCapTXList[i].MaLoaiPhuCapTX);
                            MessageBox.Show(this, "Loại Phụ Cấp TX" + cv.TenLoaiPhuCapTX.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            gbx_LoaiPhuCapTX.ActiveRow = gbx_LoaiPhuCapTX.Rows[i];
                            gbx_LoaiPhuCapTX.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmLoaiPhuCapThuongXuyen_Load(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _LoaiPhuCapTXList.Count; i++)
                {
                    if (_LoaiPhuCapTXList[i].MaQuanLy == "")
                    {
                        MessageBox.Show(this, _Util.vuilongnhapma, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (_LoaiPhuCapTXList[i].TenLoaiPhuCapTX == "")
                    {
                        MessageBox.Show(this, _Util.vuilongnhaptenloaiphucaptx, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (KiemTraMaQuanLy() == true)
                {
                    gbx_LoaiPhuCapTX.UpdateData();
                    _LoaiPhuCapTXList.ApplyEdit();
                    _LoaiPhuCapTXList.Save();
                    MessageBox.Show(this, _Util.thanhcong, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoaiPhuCapTX_BindingSource.DataSource = _LoaiPhuCapTXList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            gbx_LoaiPhuCapTX.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieuLenLuoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gbx_LoaiPhuCapTX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                gbx_LoaiPhuCapTX.UpdateData();
            }
        }
        #endregion

        #region gbx_LoaiPhuCapTX_InitializeLayout
        private void gbx_LoaiPhuCapTX_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            t.ultragrdEmail_InitializeLayout(sender, e);

            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["MaLoaiPhucapTX"].Hidden = true;

            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Loại PCTX";
            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 70;

            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["TenLoaiPhuCapTX"].Header.Caption = "Tên Loại Phụ Cấp TX";
            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["TenLoaiPhuCapTX"].Header.VisiblePosition = 1;
            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["TenLoaiPhuCapTX"].Width = 150;

            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 2;
            gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 305;

            gbx_LoaiPhuCapTX.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.gbx_LoaiPhuCapTX.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.gbx_LoaiPhuCapTX.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(gbx_LoaiPhuCapTX);
        }
    }
}