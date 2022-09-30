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
    public partial class frmHinhThucTrichNop : Form
    {
        #region Properties
        HinhThucTrichNopList _HinhThucTrichNopList;
        HinhThucTrichNop _HinhThucTrichNop;
        Util util = new Util();
        HamDungChung t = new HamDungChung();
        #endregion

        #region Events
        public frmHinhThucTrichNop()
        {
            InitializeComponent();
        }

        private void LayDuLieu()
        {
            try
            {
                _HinhThucTrichNopList = HinhThucTrichNopList.GetHinhThucTrichNopList();
                HinhThucTrichNop_BindingSource.DataSource = _HinhThucTrichNopList;
            }
            catch (ApplicationException)
            {

            }
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _HinhThucTrichNopList.Count; i++)
            {
                for (int j = 0; j < _HinhThucTrichNopList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_HinhThucTrichNopList[i].MaQuanLy.Trim() == _HinhThucTrichNopList[j].MaQuanLy.Trim())
                        {
                            HinhThucTrichNop qg = HinhThucTrichNop.GetHinhThucTrichNop(_HinhThucTrichNopList[i].MaHinhThucTrichNop);
                            MessageBox.Show(this, "Hình thức trích nộp " + qg.TenHinhThuc.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdHinhThucTrichNop.ActiveRow = ultragrdHinhThucTrichNop.Rows[i + 1];
                            ultragrdHinhThucTrichNop.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmHinhThucTrichNop_Load(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < _HinhThucTrichNopList.Count; i++)
                {
                    if (_HinhThucTrichNopList[i].MaQuanLy == "")
                    {
                        MessageBox.Show(this, util.vuilongnhapma, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (KiemTraMaQuanLy() == true)
                {
                    try
                    {
                        ultragrdHinhThucTrichNop.UpdateData();
                        _HinhThucTrichNopList.ApplyEdit();
                        _HinhThucTrichNopList.Save();
                        MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LayDuLieu();
                    }
                    catch (ApplicationException)
                    {

                    }
                }

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdHinhThucTrichNop.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            ultragrdHinhThucTrichNop.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            LayDuLieu();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ultragrdHinhThucTrichNop_InitializeLayout
        private void ultragrdHinhThucTrichNop_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdHinhThucTrichNop.DisplayLayout.Bands[0].Columns["MaHinhThucTrichNop"].Hidden = true;

            ultragrdHinhThucTrichNop.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Hình Thức";
            ultragrdHinhThucTrichNop.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdHinhThucTrichNop.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 100;

            ultragrdHinhThucTrichNop.DisplayLayout.Bands[0].Columns["TenHinhThuc"].Header.Caption = "Tên Hình Thức";
            ultragrdHinhThucTrichNop.DisplayLayout.Bands[0].Columns["TenHinhThuc"].Header.VisiblePosition = 1;
            ultragrdHinhThucTrichNop.DisplayLayout.Bands[0].Columns["TenHinhThuc"].Width = 250;

            //ultragrdHinhThucTrichNop.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //this.ultragrdHinhThucTrichNop.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.ultragrdHinhThucTrichNop.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_Report_tblnsHinhthuctrichnopAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptHinhthuctrichnop(), new frmHienThiReport(), false);           
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdHinhThucTrichNop);
        }

    }
}