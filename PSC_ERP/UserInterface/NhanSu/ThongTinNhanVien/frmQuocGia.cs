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
    public partial class frmQuocGia : Form
    {
        Util util = new Util();
        QuocGiaList _QuocGiaList;

        public delegate void PassData(QuocGiaList value);
        public PassData getData;       

        public frmQuocGia()
        {
            InitializeComponent();
            this.Load_Source();
        }
        private void Load_Source()
        {
            try
            {
                _QuocGiaList = QuocGiaList.GetQuocGiaList();
                QuocGia_bindingSource.DataSource = _QuocGiaList;
            }
            catch (ApplicationException)
            {

            }
        }



        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _QuocGiaList.Count; i++)
            {
                for (int j = 0; j < _QuocGiaList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_QuocGiaList[i].MaQuocGiaQuanLy.Trim() == _QuocGiaList[j].MaQuocGiaQuanLy.Trim())
                        {
                            QuocGia qg = QuocGia.GetQuocGia(_QuocGiaList[i].MaQuocGia);
                            MessageBox.Show(this, "Quốc Gia " + qg.TenQuocGia.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_QuocGia.ActiveRow = grdu_QuocGia.Rows[i];
                            grdu_QuocGia.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblThoat_Click_1(object sender, EventArgs e)
        {
                this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_QuocGia.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdu_QuocGia.DeleteSelectedRows();
        }

        private void grdu_QuocGia_InitializeLayout_1(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            grdu_QuocGia.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grdu_QuocGia.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaQuocGia"].Hidden = true;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenVietTat"].Hidden = true;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaQuocGiaQuanLy"].Header.Caption = "Mã Quốc Gia";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaQuocGiaQuanLy"].Width = 150;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenQuocGia"].Header.Caption = "Tên Quốc Gia";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenQuocGia"].Width = 300;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenVietTat"].Width = 150;

            foreach (UltraGridColumn col in this.grdu_QuocGia.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();   
        }
        private void Save()
        {
            QuocGia quocGia;
            for (int i = 0; i < _QuocGiaList.Count; i++)
            {
                quocGia = _QuocGiaList[i];
                if (quocGia.MaQuocGiaQuanLy == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quốc Gia", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_QuocGia.ActiveRow = grdu_QuocGia.Rows[i + 1];
                    grdu_QuocGia.Focus();
                    return;
                }
                else if (quocGia.TenQuocGia == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Quốc Gia", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdu_QuocGia.ActiveRow = grdu_QuocGia.Rows[i + 1];
                    grdu_QuocGia.Focus();
                    return;
                }
            }
            if (KiemTraMaQuanLy() == true)
            {
                try
                {
                    grdu_QuocGia.UpdateData();
                    _QuocGiaList.ApplyEdit();
                    QuocGia_bindingSource.EndEdit();
                    _QuocGiaList.Save();
                    if (getData != null)
                    {
                        getData(_QuocGiaList);
                    }
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ApplicationException)
                {

                }
            }
        }
        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    grdu_QuocGia.UpdateData();
            //}
        }

        private void grdu_QuocGia_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {
            //grdu_QuocGia.UpdateData();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();

            h.ShowReport(new string[] { "spd_report_QuocGiasAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptQuocGia(), new frmHienThiReport(), false);
           
        }

        private void grdu_QuocGia_Leave(object sender, EventArgs e)
        {
            grdu_QuocGia.UpdateData();
        }

        private void frmQuocGia_KeyDown(object sender, KeyEventArgs e)
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
                Load_Source();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            //Export ra fiel excel
            HamDungChung.ExportToExcel(grdu_QuocGia);
        }
    }
}
