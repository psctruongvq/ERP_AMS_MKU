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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;


namespace PSC_ERP
{    
    public partial class frmTruongDaoTao : Form
    {
        Util util=new Util();
        TruongDaoTaoList list;

        public frmTruongDaoTao()
        {
            InitializeComponent();
        }

        private void Load_Luoi()
        {
            try
            {
                list = TruongDaoTaoList.GetTruongDaoTaoList();
                TruongDaoTao_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void ultragrdTruongDaoTao_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdTruongDaoTao.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdTruongDaoTao.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdTruongDaoTao.DisplayLayout.Bands[0].Columns["MaTruongDaoTao"].Hidden = true;
            ultragrdTruongDaoTao.DisplayLayout.Bands[0].Columns["TenTruongDaoTao"].Header.Caption = "Tên Trường Đào Tạo";
            ultragrdTruongDaoTao.DisplayLayout.Bands[0].Columns["TenTruongDaoTao"].Width = 300;
            ultragrdTruongDaoTao.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdTruongDaoTao.DisplayLayout.Bands[0].Columns["TenTruongDaoTao"].Width = 150;

            foreach (UltraGridColumn col in ultragrdTruongDaoTao.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void frmTruongDaoTao_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 0; i < ultragrdTruongDaoTao.Rows.Count; i++)
            {
                //_UuTienBanThan = list[i];
                if (ultragrdTruongDaoTao.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdTruongDaoTao.ActiveRow = ultragrdTruongDaoTao.Rows[i];
                    return kq;
                }
                if (ultragrdTruongDaoTao.Rows[i].Cells["TenTruongDaoTao"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Trường Đào Tạo", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdTruongDaoTao.ActiveRow = ultragrdTruongDaoTao.Rows[i];
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
                            TruongDaoTao cd = TruongDaoTao.GetTruongDaoTao(list[i].MaTruongDaoTao);
                            MessageBox.Show(this, "Trường " + cd.TenTruongDaoTao.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdTruongDaoTao.ActiveRow = ultragrdTruongDaoTao.Rows[i];
                            ultragrdTruongDaoTao.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
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
                    }
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdTruongDaoTao.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdTruongDaoTao.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_SelecttblnsTruongDaoTaosAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptTruongDaoTao(), new frmHienThiReport(), false);                       
        }

        private void frmTruongDaoTao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ultragrdTruongDaoTao.UpdateData();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdTruongDaoTao);
        }


    }
}