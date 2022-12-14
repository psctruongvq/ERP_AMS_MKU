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
    public partial class frmPhongBan : Form
    {
        #region Properties
        Util util = new Util();
        CongTyList _CongTyList;
        BoPhanList _PhongBanList;
        #endregion

        public frmPhongBan()
        {
            InitializeComponent();
            this.Load_Form();
        }

        private void Load_Form()
        {
            _PhongBanList = BoPhanList.GetBoPhanList();
            PhongBan_bindingSource.DataSource = _PhongBanList;

            _CongTyList = CongTyList.GetCongTyList();
            ultraComboEditor1.DataSource = _CongTyList;
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _PhongBanList.Count; i++)
            {
                for (int j = 0; j < _PhongBanList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_PhongBanList[i].MaBoPhanQL.Trim() == _PhongBanList[j].MaBoPhanQL.Trim())
                        {
                            BoPhan qg = BoPhan.GetBoPhan(_PhongBanList[i].MaBoPhan);
                            MessageBox.Show(this, "Phòng Ban " + qg.MaBoPhanQL.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_PhongBan.ActiveRow = grdu_PhongBan.Rows[i];
                            grdu_PhongBan.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show(this, util.thaoTac, util.thongbao, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                this.Close();
            }

        #region grdPhongBan_InitializeLayout
        private void grdPhongBan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
    {
        tlslblTim.Visible = false;
        toolStripSeparator4.Visible = false;

        dtmu_NgayLap.Visible = false;
        ultraComboEditor1.Visible = false;
        HamDungChung t = new HamDungChung();
        t.ultragrdEmail_InitializeLayout(sender, e);
        grdu_PhongBan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
        grdu_PhongBan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

        grdu_PhongBan.DisplayLayout.Bands[0].Columns["MaPhongBan"].Hidden = true;
        //grdu_PhongBan.DisplayLayout.Bands[0].Columns["TenChiNhanh"].Hidden = true;            
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["MaQLPhongBan"].Header.Caption = "Mã Phòng Ban";
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["MaQLPhongBan"].Width = 150;
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["TenPhongBan"].Header.Caption = "Tên Phòng Ban";
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["TenPhongBan"].Width = 285;
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["MaChiNhanh"].Header.Caption = "Tên Chi Nhánh";
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["MaChiNhanh"].Width = 300;
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["NgayDangKi"].Header.Caption = "Ngày Lập";
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["NgayDangKi"].Width = 100;
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["MaChiNhanh"].EditorComponent = ultraComboEditor1;
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["NgayDangKi"].EditorComponent = dtmu_NgayLap;

        grdu_PhongBan.DisplayLayout.Bands[0].Columns["MaQLPhongBan"].Header.VisiblePosition = 0;
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["TenPhongBan"].Header.VisiblePosition = 1;
        grdu_PhongBan.DisplayLayout.Bands[0].Columns["MaChiNhanh"].Header.VisiblePosition = 2;

        foreach (UltraGridColumn col in this.grdu_PhongBan.DisplayLayout.Bands[0].Columns)
        {
            col.SortIndicator = SortIndicator.Ascending;
            col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            col.Header.Appearance.ForeColor = Color.Navy;
        }
    }
        #endregion

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_PhongBan.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdu_PhongBan.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form();
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < grdu_PhongBan.Rows.Count; i++)
            {
                //_UuTienBanThan = list[i];
                if (grdu_PhongBan.Rows[i].Cells["MaBoPhan"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Bộ Phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_PhongBan.ActiveRow = grdu_PhongBan.Rows[i];
                    return kq;
                }
                if (grdu_PhongBan.Rows[i].Cells["TenMaBoPhan"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Bộ Phận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_PhongBan.ActiveRow = grdu_PhongBan.Rows[i];
                    return kq;
                }
            }
            return kq;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra_Luoi() == true)
                {
                    if (KiemTraMaQuanLy() == true)
                    {
                        _PhongBanList.ApplyEdit();
                        _PhongBanList.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Load_Form();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void grdu_PhongBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // grdu_PhongBan.UpdateData();
            }
        }

        private void grdu_PhongBan_Leave(object sender, EventArgs e)
        {
            grdu_PhongBan.UpdateData();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            //DataSet dataset = new DataSet();
            //HamDungChung h = new HamDungChung();

            //DataTable table1 = h.ExecStoredProcedure("spd_report_PhongBansAll", ERP_Library.Database.ERP_Connection);

            //DataTable table2 = h.ExecStoredProcedure("spd_REPORT_ReportHeader", ERP_Library.Database.ERP_Connection);

            //dataset.Tables.Add(table1);
            //dataset.Tables.Add(table2);
            //frmHienThiReport dlg = new frmHienThiReport();
            //h.ShowReport(dataset, new Report.rptPhongBan(), dlg, false);
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_PhongBan);
        }
    }
}
