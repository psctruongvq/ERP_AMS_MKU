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
    public partial class frmHinhThucDaoTao : Form
    {
        Util util = new Util();
        HinhThucDaoTaoClassList list;

        public frmHinhThucDaoTao()
        {
            InitializeComponent();
        }

        private void Load_Luoi()
        {
            list = HinhThucDaoTaoClassList.GetHinhThucDaoTaoClassList();
            HinhThucDaoTao_bindingSource.DataSource = list;
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
                            HinhThucDaoTaoClass qg = HinhThucDaoTaoClass.GetHinhThucDaoTaoClass(list[i].MaHinhThucDaoTao);
                            MessageBox.Show(this, "Hình thức đào tạo " + qg.HinhThucDaoTao.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdHinhThucDaoTao.ActiveRow = ultragrdHinhThucDaoTao.Rows[i + 1];
                            ultragrdHinhThucDaoTao.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void frmHinhThucDaoTao_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void ultragrdHinhThucDaoTao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdHinhThucDaoTao.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdHinhThucDaoTao.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdHinhThucDaoTao.DisplayLayout.Bands[0].Columns["MaHinhThucDaoTao"].Hidden = true;
            ultragrdHinhThucDaoTao.DisplayLayout.Bands[0].Columns["HinhThucDaoTao"].Header.Caption = "Hình Thức Đào Tạo";
            ultragrdHinhThucDaoTao.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";

            foreach (UltraGridColumn col in ultragrdHinhThucDaoTao.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].MaQuanLy == "")
                    {
                        MessageBox.Show(this, "Vui lòng nhập mã hình thức đào tạo", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else if (list[i].HinhThucDaoTao == "")
                    {
                        MessageBox.Show(this, "Vui lòng nhập tên hình thức đào tạo", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (KiemTraMaQuanLy() == true)
                {
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Load_Luoi();
                }
            }
            catch (Exception ex) 
            {
                throw ex; 
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdHinhThucDaoTao.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdHinhThucDaoTao.DeleteSelectedRows();
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
            h.ShowReport(new string[] { "spd_report_tblnshinhthucdaotaoAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptHinhthucdaotao(), new frmHienThiReport(), false);           
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdHinhThucDaoTao);
        }


    }
}