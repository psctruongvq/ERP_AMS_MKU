using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmQuanHuyen : Form
    {
        Util util = new Util();
        QuanHuyenList _QuanHuyenList;
        TinhThanhList _TinhThanhList;
        public delegate void PassData(QuanHuyenList value);
        public PassData getData;

        public frmQuanHuyen()
        {
            InitializeComponent();
            this.Load_Form();
        }

        private void Load_Form()
        {
            try
            {
                _QuanHuyenList = QuanHuyenList.GetQuanHuyenList();
                QuanHuyen_bindingSource.DataSource = _QuanHuyenList;
                _TinhThanhList = TinhThanhList.GetTinhThanhList();
                ultraComboEditor1.DataSource = _TinhThanhList;
            }
            catch (ApplicationException)
            {

            }
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _QuanHuyenList.Count; i++)
            {
                for (int j = 0; j < _QuanHuyenList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_QuanHuyenList[i].MaQuanLy.Trim() == _QuanHuyenList[j].MaQuanLy.Trim())
                        {
                            QuanHuyen qg = QuanHuyen.GetQuanHuyen(_QuanHuyenList[i].MaQuanHuyen);
                            MessageBox.Show(this, "Quận Huyên " + qg.TenQuanHuyen.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_QuanHuyen.ActiveRow = grdu_QuanHuyen.Rows[i];
                            grdu_QuanHuyen.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void grdu_QuanHuyen_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ultraComboEditor1.Visible = false;
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            grdu_QuanHuyen.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grdu_QuanHuyen.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grdu_QuanHuyen.DisplayLayout.Bands[0].Columns["MaQuanHuyen"].Hidden = true;                        
            grdu_QuanHuyen.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quận Huyện";
            grdu_QuanHuyen.DisplayLayout.Bands[0].Columns["TenQuanHuyen"].Header.Caption = "Tên Quận Huyện";
            grdu_QuanHuyen.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Header.Caption = "Tỉnh Thành";
            grdu_QuanHuyen.DisplayLayout.Bands[0].Columns["MaTinhThanh"].EditorComponent = ultraComboEditor1;

            grdu_QuanHuyen.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            grdu_QuanHuyen.DisplayLayout.Bands[0].Columns["TenQuanHuyen"].Header.VisiblePosition = 1;
            grdu_QuanHuyen.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Width = 200;
            grdu_QuanHuyen.DisplayLayout.Bands[0].Columns["TenQuanHuyen"].Width = 150;

            foreach (UltraGridColumn col in this.grdu_QuanHuyen.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_QuanHuyen.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdu_QuanHuyen.DeleteSelectedRows();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
                QuanHuyen quanHuyen;
                for (int i = 0; i < _QuanHuyenList.Count; i++)
                {
                    quanHuyen = _QuanHuyenList[i];
                    if (quanHuyen.MaQuanLy == string.Empty)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Quận Huyện", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_QuanHuyen.ActiveRow = grdu_QuanHuyen.Rows[i + 1];
                        grdu_QuanHuyen.Focus();
                        return;
                    }
                    else if (quanHuyen.TenQuanHuyen == string.Empty)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Quận Huyện", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_QuanHuyen.ActiveRow = grdu_QuanHuyen.Rows[i];
                        grdu_QuanHuyen.Focus();
                        return;
                    }
                    else if (quanHuyen.MaTinhThanh == 0)
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Tỉnh Thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_QuanHuyen.ActiveRow = grdu_QuanHuyen.Rows[i];
                        grdu_QuanHuyen.Focus();
                        return;
                    }
                }
                if (KiemTraMaQuanLy() == true)
                {
                    _QuanHuyenList.ApplyEdit();
                    _QuanHuyenList.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Form();
                    if (getData != null)
                    {
                        getData(_QuanHuyenList);
                    }
                }
            }
            catch (ApplicationException)
            {

            }
        }
        private void grdu_QuanHuyen_Leave(object sender, EventArgs e)
        {
            grdu_QuanHuyen.UpdateData();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_QuanHuyensAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptQuanHuyen(), new frmHienThiReport(), false);
        }
      
        private void frmQuanHuyen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F1)
            {
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                Load_Form();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_QuanHuyen);
        }

    }
}
