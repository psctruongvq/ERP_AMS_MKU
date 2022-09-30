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
    public partial class frmNgoaiNgu : Form
    {
        Util util=new Util();
        NgoaiNguList list;
        public delegate void PassData(NgoaiNguList value);
        public PassData getData;

        public frmNgoaiNgu()
        {
            InitializeComponent();
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < ultragrdNgoaiNgu.Rows.Count; i++)
            {
                //_UuTienBanThan = list[i];
                if (ultragrdNgoaiNgu.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdNgoaiNgu.ActiveRow = ultragrdNgoaiNgu.Rows[i];
                    return kq;
                }
                if (ultragrdNgoaiNgu.Rows[i].Cells["TenNgoaiNgu"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Ưu Tên Ngoại Ngữ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdNgoaiNgu.ActiveRow = ultragrdNgoaiNgu.Rows[i];
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
                            NgoaiNgu cd = NgoaiNgu.GetNgoaiNgu(list[i].MaNgoaiNgu);
                            MessageBox.Show(this, "Ngoại ngữ " + cd.TenNgoaiNgu.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdNgoaiNgu.ActiveRow = ultragrdNgoaiNgu.Rows[i];
                            ultragrdNgoaiNgu.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
                if (KiemTra_Luoi() == true)
                {
                    if (KiemTraMaQuanLy() == true)
                    {
                        list.ApplyEdit();
                        list.Save();
                        MessageBox.Show(this, util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Load_LenLuoi();
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
        private void Load_LenLuoi()
        {
            try
            {
                list = NgoaiNguList.GetNgoaiNguList();
                NgoaiNgu_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void frmNgoaiNgu_Load(object sender, EventArgs e)
        {
            this.Load_LenLuoi(); 
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdNgoaiNgu.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdNgoaiNgu.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_LenLuoi();
        }

        private void ultragrdNgoaiNgu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            ultragrdNgoaiNgu.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            ultragrdNgoaiNgu.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaNgoaiNgu"].Hidden = true;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenNgoaiNgu"].Header.Caption = "Tên Ngoại Ngữ";
            ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns["TenNgoaiNgu"].Width = 300;

            foreach (UltraGridColumn col in this.ultragrdNgoaiNgu.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ultragrdNgoaiNgu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // ultragrdNgoaiNgu.UpdateData();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_NgoaiNgusAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptNgoaiNgu(), new frmHienThiReport(), false);
        }

        private void frmNgoaiNgu_KeyDown(object sender, KeyEventArgs e)
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
                Load_LenLuoi();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdNgoaiNgu);
        }
    }
}
