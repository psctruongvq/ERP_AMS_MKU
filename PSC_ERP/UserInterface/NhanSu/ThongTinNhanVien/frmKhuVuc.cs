using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Csla;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraDataGridView;
using Csla.Windows;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmKhuVuc : Form
    {
        Util util = new Util();
        KhuVucList _khuVucList;
        QuocGiaList _quocGiaList;
        public frmKhuVuc()
        {
            InitializeComponent();
            Load_Form();
        }
        private void Load_Form()
        {
            try
            {
                _khuVucList = KhuVucList.GetKhuVucList();
                KhuVuc_bindingSource1.DataSource = _khuVucList;

                _quocGiaList = QuocGiaList.GetQuocGiaList();
                ultracbQuocGia.DataSource = _quocGiaList;
                QuocGia_bindingSource1.DataSource = _quocGiaList;
            }
            catch (ApplicationException)
            {

            }
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _khuVucList.Count; i++)
            {
                for (int j = 0; j < _khuVucList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_khuVucList[i].MaKhuVucQuanLy.Trim() == _khuVucList[j].MaKhuVucQuanLy.Trim())
                        {
                            KhuVuc kv = KhuVuc.GetKhuVuc(_khuVucList[i].MaKhuVuc);
                            MessageBox.Show(this, "Khu Vực " + kv.TenKhuVuc.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdKhuVuc.ActiveRow = grdKhuVuc.Rows[i];
                            grdKhuVuc.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
       
        private void grdKhuVuc_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultracbQuocGia.Visible = false;
           // tlslblThem.Visible = false;
          //  toolStripSeparator1.Visible = false;
            //tlslblTim.Visible = false;
            toolStripSeparator4.Visible = false;
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            grdKhuVuc.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            grdKhuVuc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            grdKhuVuc.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdKhuVuc.DisplayLayout.Bands[0].Columns["MaKhuVuc"].Hidden = true;
            grdKhuVuc.DisplayLayout.Bands[0].Columns["TenKhuVuc"].Header.Caption = "Tên Khu Vực";
            grdKhuVuc.DisplayLayout.Bands[0].Columns["MaKhuVucQuanLy"].Header.Caption = "Mã Quản Lý";

            grdKhuVuc.DisplayLayout.Bands[0].Columns["MaQuocGia"].Header.Caption = "Tên Quốc Gia";
            grdKhuVuc.DisplayLayout.Bands[0].Columns["MaQuocGia"].EditorComponent = ultracbQuocGia;

            grdKhuVuc.DisplayLayout.Bands[0].Columns["MaKhuVucQuanLy"].Header.VisiblePosition = 0;
            grdKhuVuc.DisplayLayout.Bands[0].Columns["TenKhuVuc"].Header.VisiblePosition = 1;
            grdKhuVuc.DisplayLayout.Bands[0].Columns["MaQuocGia"].Width = 150;
            grdKhuVuc.DisplayLayout.Bands[0].Columns["MaKhuVucQuanLy"].Width = 100;
            grdKhuVuc.DisplayLayout.Bands[0].Columns["TenKhuVuc"].Width = 250;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in grdKhuVuc.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void grdKhuVuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //grdKhuVuc.UpdateData();
            }
        }

        private void tlslblLuu_Click_1(object sender, EventArgs e)
        {
            Save(); 
        }
        private void Save()
        {
            KhuVuc khuVuc;
            for (int i = 0; i < _khuVucList.Count; i++)
            {
                khuVuc = _khuVucList[i];
                if (khuVuc.MaKhuVucQuanLy == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Khu Vực", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdKhuVuc.ActiveRow = grdKhuVuc.Rows[i + 1];
                    grdKhuVuc.Focus();
                    return;
                }
                else if (khuVuc.TenKhuVuc == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Khu Vực", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdKhuVuc.ActiveRow = grdKhuVuc.Rows[i];
                    grdKhuVuc.Focus();
                    return;
                }
                else if (khuVuc.MaQuocGia == 0)
                {
                    MessageBox.Show(this, "Vui Lòng Chọn Quốc Gia", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    grdKhuVuc.ActiveRow = grdKhuVuc.Rows[i];
                    grdKhuVuc.Focus();
                    return;
                }
            }
            if (KiemTraMaQuanLy() == true)
            {
                try
                {
                    _khuVucList.ApplyEdit();
                    _khuVucList.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Form();
                }
                catch (ApplicationException)
                {

                }
            }
        }
        private void tlslblXoa_Click_1(object sender, EventArgs e)
        {

            if (grdKhuVuc.Selected.Rows.Count == 0)
            {
                MessageBox.Show(util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            grdKhuVuc.DeleteSelectedRows();
        }

        private void tlslblThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            _khuVucList = KhuVucList.GetKhuVucList();
            KhuVuc_bindingSource1.DataSource = _khuVucList;
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_KhuVucsAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptKhuVuc(), new frmHienThiReport(), false) ;
        }

        private void frmKhuVuc_KeyDown(object sender, KeyEventArgs e)
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
                _khuVucList = KhuVucList.GetKhuVucList();
                KhuVuc_bindingSource1.DataSource = _khuVucList;
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            //Export excel
            HamDungChung.ExportToExcel(grdKhuVuc);
        }
    }
}
