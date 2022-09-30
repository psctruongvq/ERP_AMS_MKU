using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmHinhThucKyLuat : Form
    {
        HinhThucKyLuatList _hinhThucKyLuatList;
        HinhThucKyLuat _hinhThucKyLuat;
        Util util = new Util();

        public frmHinhThucKyLuat()
        {
            InitializeComponent();
            this.Load_Form();
        }

        private void ultragrdHInhThucKyLuat_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung dungChung = new HamDungChung();
            dungChung.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdHInhThucKyLuat.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdHInhThucKyLuat.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdHInhThucKyLuat.DisplayLayout.Bands[0].Columns["MaKyLuat"].Hidden = true;
            ultragrdHInhThucKyLuat.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdHInhThucKyLuat.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;
            ultragrdHInhThucKyLuat.DisplayLayout.Bands[0].Columns["TenKyLyat"].Header.Caption = "Tên Kỷ Luật";
            ultragrdHInhThucKyLuat.DisplayLayout.Bands[0].Columns["TenKyLyat"].Header.VisiblePosition = 1;
            ultragrdHInhThucKyLuat.DisplayLayout.Bands[0].Columns["TenKyLyat"].Width = 200;

            foreach (UltraGridColumn colum in ultragrdHInhThucKyLuat.DisplayLayout.Bands[0].Columns)
            {
                colum.SortIndicator = SortIndicator.Ascending;
                colum.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                colum.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                colum.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        private void Load_Form()
        {
            try
            {
                _hinhThucKyLuatList = HinhThucKyLuatList.GetHinhThucKyLuatList();
                hinhThucKyLuatListBindingSource.DataSource = _hinhThucKyLuatList;
            }
            catch (ApplicationException)
            {

            }
        }

        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _hinhThucKyLuatList.Count; i++)
            {
                for (int j = 0; j < _hinhThucKyLuatList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_hinhThucKyLuatList[i].MaQuanLy.Trim() == _hinhThucKyLuatList[j].MaQuanLy.Trim())
                        {
                            HinhThucKyLuat qg = HinhThucKyLuat.GetHinhThucKyLuat(_hinhThucKyLuatList[i].MaKyLuat);
                            MessageBox.Show(this, "Hình thức kỷ luật " + qg.TenKyLyat.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdHInhThucKyLuat.ActiveRow = ultragrdHInhThucKyLuat.Rows[i + 1];
                            ultragrdHInhThucKyLuat.Focus();
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
                if (KiemTraMaQuanLy() == true)
                {
                    _hinhThucKyLuatList.ApplyEdit();
                    _hinhThucKyLuatList.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load_Form();
                }
            }
                      catch (ApplicationException)
            {

            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            
                if (ultragrdHInhThucKyLuat.Selected.Rows.Count == 0)
                {
                    MessageBox.Show(util.chodongcanxoa,util.thongbao,MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                ultragrdHInhThucKyLuat.DeleteSelectedRows();
           
            
                
           
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Form();
        }

        private void ultragrdHInhThucKyLuat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //ultragrdHInhThucKyLuat.UpdateData();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnshinhthuckyluatAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptHinhthuckyluat(), new frmHienThiReport(), false);           
        }

        private void ultragrdHInhThucKyLuat_Leave(object sender, EventArgs e)
        {
            ultragrdHInhThucKyLuat.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdHInhThucKyLuat);
        }

      
    }
}