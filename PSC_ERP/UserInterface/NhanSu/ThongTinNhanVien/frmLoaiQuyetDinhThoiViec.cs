using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmLoaiQuyetDinhThoiViec : Form
    {
        Util util = new Util();
        LoaiQuyetDinhThoiViecList list;

        public frmLoaiQuyetDinhThoiViec()
        {
            InitializeComponent();
        }

        private void Load_Luoi()
        {
            try
            {
                list = LoaiQuyetDinhThoiViecList.GetLoaiQuyetDinhThoiViecList();
                LoaiQuyetDinh_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (i != j)
                    {
                        if (list[i].MaQuanLy.Trim() == list[j].MaQuanLy.Trim())
                        {
                            LoaiQuyetDinhThoiViec cv = LoaiQuyetDinhThoiViec.GetLoaiQuyetDinhThoiViec(list[i].MaLoaiQuyetDinh);
                            MessageBox.Show(this, "Loại Quyết Định Thôi Việc" + cv.TenLoaiQuyetDinh.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdLoaiQuyetDinhThoiViec.ActiveRow = ultragrdLoaiQuyetDinhThoiViec.Rows[i];
                            ultragrdLoaiQuyetDinhThoiViec.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmLoaiQuyetDinhThoiViec_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void ultragrdLoaiQuyetDinhThoiViec_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdLoaiQuyetDinhThoiViec.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdLoaiQuyetDinhThoiViec.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdLoaiQuyetDinhThoiViec.DisplayLayout.Bands[0].Columns["MaLoaiQuyetDinh"].Hidden = true;
            ultragrdLoaiQuyetDinhThoiViec.DisplayLayout.Bands[0].Columns["Loai"].Hidden = true;
            ultragrdLoaiQuyetDinhThoiViec.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Header.Caption = "Tên Loại Quyết Định";
            ultragrdLoaiQuyetDinhThoiViec.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            //ultragrdLoaiQuyetDinhThoiViec.DisplayLayout.Bands[0].Columns["Loai"].Header.Caption = "Loại";
            ultragrdLoaiQuyetDinhThoiViec.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Width = 250;

            foreach (UltraGridColumn col in ultragrdLoaiQuyetDinhThoiViec.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdLoaiQuyetDinhThoiViec.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa,util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdLoaiQuyetDinhThoiViec.DeleteSelectedRows();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraMaQuanLy() == true)
            {
                try
                {
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ApplicationException)
                {

                }
                //this.Load_Luoi();
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnsLoaiquyetdinhthoiviecAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptLoaiquyetdinhthoiviec(), new frmHienThiReport(), false);           

        }

        private void ultragrdLoaiQuyetDinhThoiViec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdLoaiQuyetDinhThoiViec.UpdateData();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdLoaiQuyetDinhThoiViec);
        }
    }
}