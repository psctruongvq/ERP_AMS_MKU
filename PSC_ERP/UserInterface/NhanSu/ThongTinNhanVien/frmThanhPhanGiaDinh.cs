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
    public partial class frmThanhPhanGiaDinh : Form
    {
        Util util=new Util();
        ThanhPhanGiaDinhClassList list;
        public delegate void PassData(ThanhPhanGiaDinhClassList value);
        public PassData getData;
        public frmThanhPhanGiaDinh()
        {
            InitializeComponent();
        }

        private void ultragrdThanhPhanGiaDinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            ultragrdThanhPhanGiaDinh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdThanhPhanGiaDinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdThanhPhanGiaDinh.DisplayLayout.Bands[0].Columns["MaThanhPhan"].Hidden = true;
            ultragrdThanhPhanGiaDinh.DisplayLayout.Bands[0].Columns["ThanhPhanGiaDinh"].Header.Caption = "Tên thành phần gia đình";
            ultragrdThanhPhanGiaDinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdThanhPhanGiaDinh.DisplayLayout.Bands[0].Columns["ThanhPhanGiaDinh"].Width = 150;

            foreach (UltraGridColumn col in ultragrdThanhPhanGiaDinh.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void Load_Luoi()
        {
            try
            {
                list = ThanhPhanGiaDinhClassList.GetThanhPhanGiaDinhClassList();
                ThanhPhanGiaDinh_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < ultragrdThanhPhanGiaDinh.Rows.Count; i++)
            {
                if (ultragrdThanhPhanGiaDinh.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdThanhPhanGiaDinh.ActiveRow = ultragrdThanhPhanGiaDinh.Rows[i];
                    return kq;
                }
            }
            return kq;
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
                            ThanhPhanGiaDinhClass cd = ThanhPhanGiaDinhClass.GetThanhPhanGiaDinhClass(list[i].MaThanhPhan);
                            MessageBox.Show(this, "Thành phần gia đình" + cd.ThanhPhanGiaDinh.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdThanhPhanGiaDinh.ActiveRow = ultragrdThanhPhanGiaDinh.Rows[i];
                            ultragrdThanhPhanGiaDinh.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmThanhPhanGiaDinh_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTra_Luoi() == true)
                {
                    if (KiemTraMaQuanLy() == true)
                    {
                        list.ApplyEdit();
                        list.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Load_Luoi();
                        if (getData != null)
                        {
                            getData(list);
                        }
                    }
                }
            }
            catch (ApplicationException)
            {

            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdThanhPhanGiaDinh.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdThanhPhanGiaDinh.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void ultragrdThanhPhanGiaDinh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ultragrdThanhPhanGiaDinh.UpdateData();
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnsTPgiadinhsAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptThanhphangiadinh(), new frmHienThiReport(), false);           

        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdThanhPhanGiaDinh);
        }
    }
}