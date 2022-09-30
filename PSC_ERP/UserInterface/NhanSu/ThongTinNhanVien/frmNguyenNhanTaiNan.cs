using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmNguyenNhanTaiNan : Form
    {
        Util util = new Util();
        NguyenNhanTaiNanList _NguyenNhanTaiNanList;
        
        public frmNguyenNhanTaiNan()
        {
            InitializeComponent();
            this.Load_LenLuoi();
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < ultragrdNguyenNhanTaiNan.Rows.Count; i++)
            {
                if (ultragrdNguyenNhanTaiNan.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdNguyenNhanTaiNan.ActiveRow = ultragrdNguyenNhanTaiNan.Rows[i];
                    return kq;
                }
                if (ultragrdNguyenNhanTaiNan.Rows[i].Cells["_NguyenNhanTaiNan"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Nguyên Nhân Tai Nạn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdNguyenNhanTaiNan.ActiveRow = ultragrdNguyenNhanTaiNan.Rows[i];
                    return kq;
                }
            }
            return kq;
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _NguyenNhanTaiNanList.Count; i++)
            {
                for (int j = 0; j < _NguyenNhanTaiNanList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_NguyenNhanTaiNanList[i].MaQuanLy.Trim() == _NguyenNhanTaiNanList[j].MaQuanLy.Trim())
                        {
                            NguyenNhanTaiNan cd = NguyenNhanTaiNan.GetNguyenNhanTaiNan(_NguyenNhanTaiNanList[i].MaNguyenNhanTaiNan);
                            MessageBox.Show(this, "Nguyên nhân tai nạn " + cd._NguyenNhanTaiNan.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdNguyenNhanTaiNan.ActiveRow = ultragrdNguyenNhanTaiNan.Rows[i];
                            ultragrdNguyenNhanTaiNan.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void Load_LenLuoi()
        {
            try
            {
                _NguyenNhanTaiNanList = NguyenNhanTaiNanList.GetNguyenNhanTaiNanList();
                NguyenNhanTaiNan_BindingSource.DataSource = _NguyenNhanTaiNanList;
            }
            catch (ApplicationException)
            {

            }
        }
        private void ultragrdNguyenNhanTaiNan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            ultragrdNguyenNhanTaiNan.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdNguyenNhanTaiNan.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdNguyenNhanTaiNan.DisplayLayout.Bands[0].Columns["manguyennhantainan"].Hidden = true;
            ultragrdNguyenNhanTaiNan.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã quản lý";
            ultragrdNguyenNhanTaiNan.DisplayLayout.Bands[0].Columns["_Nguyennhantainan"].Header.Caption = "Nguyên nhân tai nạn";

            foreach (UltraGridColumn col in this.ultragrdNguyenNhanTaiNan.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (KiemTra_Luoi() == true)
            {
                if (KiemTraMaQuanLy() == true)
                {
                    try
                    {
                        _NguyenNhanTaiNanList.ApplyEdit();
                        _NguyenNhanTaiNanList.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Load_LenLuoi();
                    }
                    catch (ApplicationException)
                    {

                    }
                }
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_LenLuoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
           // h.ShowReport(new string[] { "spd_report_tblnsnguyennhantainansAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptnguyennhn(), new frmHienThiReport(), false);           

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            ultragrdNguyenNhanTaiNan.DeleteSelectedRows();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdNguyenNhanTaiNan);
        }
    }
}