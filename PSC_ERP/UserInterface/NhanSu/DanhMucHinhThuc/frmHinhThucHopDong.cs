using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Csla;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmHinhThucHopDong : Form
    {
        Util util = new Util();
        HinhThucHopDongList list;

        public frmHinhThucHopDong()
        {
            InitializeComponent();
        }

        #region Load
        private void Load_Luoi()
        {
            try
            {
                list = HinhThucHopDongList.GetHinhThucHopDongList();
                HinhThucHopDong_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void frmHinhThucHopDong_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }
        private void ultragrdHinhThucHopDong_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //ultragrdHinhThucHopDong.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdHinhThucHopDong.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdHinhThucHopDong.DisplayLayout.Bands[0].Columns["MaHinhThucHopDong"].Hidden = true;
            ultragrdHinhThucHopDong.DisplayLayout.Bands[0].Columns["TenHinhThucHopDong"].Header.Caption = "Hình Thức Hợp Đồng";

            ultragrdHinhThucHopDong.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";

            foreach (UltraGridColumn col in ultragrdHinhThucHopDong.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }

        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < list.Count; i++)
            {

                if (ultragrdHinhThucHopDong.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Hình Thức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdHinhThucHopDong.ActiveRow = ultragrdHinhThucHopDong.Rows[i];
                    return;
                }
                if (ultragrdHinhThucHopDong.Rows[i].Cells["TenHinhThucHopDong"].Text == "")
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Hình Thức", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdHinhThucHopDong.ActiveRow = ultragrdHinhThucHopDong.Rows[i];
                    return;
                }
            }
            if (KiemTraMaQuanLy() == true)
            {
                try
                {
                    list.ApplyEdit();
                    list.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Luoi();
                }
                catch (ApplicationException)
                {

                }
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdHinhThucHopDong.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdHinhThucHopDong.DeleteSelectedRows();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            ultratxtMaHinhThuc.Focus();
            HinhThucHopDong obj;
            for (int i = 0; i < list.Count; i++)
            {
                obj = list[i];
                if (obj.MaQuanLy == "")
                {
                    return;
                }
            }
            obj = HinhThucHopDong.NewHinhThucHopDong();
            list.Add(obj);
            ultragrdHinhThucHopDong.ActiveRow = ultragrdHinhThucHopDong.Rows[list.Count - 1];
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
            h.ShowReport(new string[] { "spd_report_tblnshinhthuchopdongAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptHinhthuchopdong(), new frmHienThiReport(), false);
        }
        #endregion

        #region Process
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
                            HinhThucHopDong qg = HinhThucHopDong.GetHinhThucHopDong(list[i].MaHinhThucHopDong);
                            MessageBox.Show(this, "Hình thức hợp đồng " + qg.TenHinhThucHopDong.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdHinhThucHopDong.ActiveRow = ultragrdHinhThucHopDong.Rows[i + 1];
                            ultragrdHinhThucHopDong.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        private void ultragrdHinhThucHopDong_KeyDown(object sender, KeyEventArgs e)
        {
            ultragrdHinhThucHopDong.UpdateData();
        }

        private void ultragrdHinhThucHopDong_Leave(object sender, EventArgs e)
        {
            ultragrdHinhThucHopDong.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdHinhThucHopDong);
        }


    }
}