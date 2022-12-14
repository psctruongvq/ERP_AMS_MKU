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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmTinhThanh : Form
    {
        Util util = new Util();        
        TinhThanhList _TinhThanhList;
        KhuVucList _KhuVucList;
        QuocGiaList _QuocGiaList;

        public delegate void PassData(TinhThanhList value);
        public PassData getData;       

        public frmTinhThanh()
        {
            InitializeComponent();
            this.Load_Form();
        }

        private void Load_Form()
        {
            try
            {
                _TinhThanhList = TinhThanhList.GetTinhThanhList();
                TinhThanh_bindingSource.DataSource = _TinhThanhList;
                _KhuVucList = KhuVucList.GetKhuVucList();
                cmbu_KhuVuc.DataSource = _KhuVucList;
                _QuocGiaList = QuocGiaList.GetQuocGiaList();
                QuocGia_bindingSource.DataSource = _QuocGiaList;
            }
            catch (ApplicationException)
            {

            }
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _TinhThanhList.Count; i++)
            {
                for (int j = 0; j < _TinhThanhList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_TinhThanhList[i].MaTinhThanhQuanLy.Trim() == _TinhThanhList[j].MaTinhThanhQuanLy.Trim())
                        {
                            TinhThanh qg = TinhThanh.GetTinhThanh(_TinhThanhList[i].MaTinhThanh);
                            MessageBox.Show(this, "Tỉnh Thành " + qg.TenTinhThanh.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdTinhThanh.ActiveRow = grdTinhThanh.Rows[i];
                            grdTinhThanh.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            
                this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdTinhThanh.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdTinhThanh.DeleteSelectedRows();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            try
            {
                TinhThanh tinhThanh;
                for (int i = 0; i < _TinhThanhList.Count; i++)
                {
                    tinhThanh = _TinhThanhList[i];
                    if (tinhThanh.MaTinhThanhQuanLy == string.Empty)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Tỉnh Thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdTinhThanh.ActiveRow = grdTinhThanh.Rows[i + 1];
                        grdTinhThanh.Focus();
                        return;
                    }
                    else if (tinhThanh.TenTinhThanh == string.Empty)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Tỉnh Thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdTinhThanh.ActiveRow = grdTinhThanh.Rows[i];
                        grdTinhThanh.Focus();
                        return;
                    }
                    //else if (tinhThanh.MaKhuVuc == 0)
                    //{
                    //    MessageBox.Show(this, "Vui Lòng Chọn Khu Vực", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    grdTinhThanh.ActiveRow = grdTinhThanh.Rows[i];
                    //    grdTinhThanh.Focus();
                    //    return;
                    //}
                    //else if (tinhThanh.MaQuocGia == 0)
                    //{
                    //    MessageBox.Show(this, "Vui Lòng Chọn Quốc Gia", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    grdTinhThanh.ActiveRow = grdTinhThanh.Rows[i];
                    //    grdTinhThanh.Focus();
                    //    return;
                    //}
                }
                if (KiemTraMaQuanLy() == true)
                {
                    _TinhThanhList.ApplyEdit();
                    grdTinhThanh.UpdateData();
                    _TinhThanhList.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Form();
                    if (getData != null)
                    {
                        getData(_TinhThanhList);
                    }
                }
            }
            catch (ApplicationException)
            {

            }
        }
        private void grdTinhThanh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            cmbu_QuocGia.Visible = false;
            cmbu_KhuVuc.Visible = false;
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);
            grdTinhThanh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grdTinhThanh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaTinhThanh"].Hidden = true;            
            grdTinhThanh.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = true;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Header.Caption = "Mã Tỉnh Thành";
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.Caption = "Tên Tỉnh Thành";
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaKhuVuc"].Header.Caption = "Tên Khu Vực";
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaQuocGia"].Header.Caption = "Tên Quốc Gia";
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaKhuVuc"].EditorComponent = cmbu_KhuVuc;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaQuocGia"].EditorComponent = cmbu_QuocGia;

            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Header.VisiblePosition = 0;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Header.VisiblePosition = 1;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaKhuVuc"].Width = 200;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaQuocGia"].Width = 150;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["MaTinhThanhQuanLy"].Width = 80;
            grdTinhThanh.DisplayLayout.Bands[0].Columns["TenTinhThanh"].Width = 150;
            foreach (UltraGridColumn col in this.grdTinhThanh.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void grdTinhThanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               // grdTinhThanh.UpdateData();
            }
        }





        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();   
            h.ShowReport(new string[] { "spd_report_TinhThanhesAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptTinhThanh(), new frmHienThiReport(), false);
            
        }

        private void cmbu_KhuVuc_ValueChanged(object sender, EventArgs e)
        {

        }

        private void grdTinhThanh_Leave(object sender, EventArgs e)
        {
            grdTinhThanh.UpdateData();
        }

        private void frmTinhThanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //frmMainNhanSu.LoadHelp(this, "Quan he gia dinh");
            }
            else if (e.Control && e.KeyCode == Keys.U )
            {
                Load_Form();
            }
            else if (e.Control && e.KeyCode == Keys.S )
            {
                Save();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdTinhThanh);
        }
    }
}
