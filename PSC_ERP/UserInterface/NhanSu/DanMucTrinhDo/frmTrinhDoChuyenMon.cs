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
    public partial class frmTrinhDoChuyenMon : Form
    {
        Util util;
        TrinhDoChuyenMonList list;
        public delegate void PassData(TrinhDoChuyenMonList value);
        public PassData getData;     
    
    
        public frmTrinhDoChuyenMon()
        {
            InitializeComponent();
            Load_Luoi();
        }


        #region Load
        private void Load_Luoi()
        {
            try
            {
                list = TrinhDoChuyenMonList.GetTrinhDoChuyenMonList();
                TrinhDoChuyenMon_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void frmTrinhDoChuyenMon_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void ultragrdTrinhDoChueynMon_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            //ultragrdTrinhDoChueynMon.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdTrinhDoChueynMon.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["MaTrinhDoChuyenMon"].Hidden = true;
            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["TenTrinhDo"].Header.Caption = "Tên Trình Độ";
            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["TenTrinhDo"].Header.VisiblePosition = 1;
            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["TenTrinhDo"].Width = 180;

            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 2;
            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["TenVietTat"].Width = 100;

            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 200;

            foreach (UltraGridColumn col in ultragrdTrinhDoChueynMon.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        #region Event
        private void tlslblThem_Click(object sender, EventArgs e)
        {
            TrinhDoChuyenMon obj;
            ultratxtMaTrinhDo.Focus();
            for (int i = 0; i < list.Count; i++)
            {
                obj = list[i];
                if (obj.MaQuanLy == "")
                {
                    return;
                }
            }
            obj = TrinhDoChuyenMon.NewTrinhDoChuyenMon();
            list.Add(obj);
            ultragrdTrinhDoChueynMon.ActiveRow = ultragrdTrinhDoChueynMon.Rows[list.Count - 1];
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (!KiemTraControl())
            {
                return;
            }
            for (int i = 0; i < ultragrdTrinhDoChueynMon.Rows.Count; i++)
            {
                if (ultragrdTrinhDoChueynMon.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Trình Độ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdTrinhDoChueynMon.ActiveRow = ultragrdTrinhDoChueynMon.Rows[i];
                    return;
                }
                if (ultragrdTrinhDoChueynMon.Rows[i].Cells["TenTrinhDo"].Text == "")
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Trình Độ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdTrinhDoChueynMon.ActiveRow = ultragrdTrinhDoChueynMon.Rows[i];
                    return;
                }
                if (ultragrdTrinhDoChueynMon.Rows[i].Cells["TenVietTat"].Text == "")
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Viết Tắt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdTrinhDoChueynMon.ActiveRow = ultragrdTrinhDoChueynMon.Rows[i];
                    return;
                }
            }
            if (KiemTraMaQuanLy() == true)
            {
                try
                {
                    ultragrdTrinhDoChueynMon.UpdateData();
                    list.ApplyEdit();
                    list.Save();

                    MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Luoi();
                    if (getData != null)
                    {
                        getData(list);
                    }
                }
                catch (ApplicationException)
                {

                }
                catch (Exception ex)
                { 
                }

            }

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdTrinhDoChueynMon.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdTrinhDoChueynMon.DeleteSelectedRows();
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
            h.ShowReport(new string[] { "spd_report_tblnsTrinhdochuyenmonAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptTrinhdochuyenmon(), new frmHienThiReport(), false);
        }
        #endregion

        #region Process
        private Boolean KiemTraControl()
        {
            Boolean kq = true;
            foreach (Control control in groupBox2.Controls)
            {
                if (errorProvider1.GetError(control) != String.Empty)
                {
                    if (control.Name == ultratxtMaTrinhDo.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Trình Độ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    if (control.Name == ultratxtTenTrinhDo.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Trình Độ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
                    if (control.Name == ultratxtTenVietTat.Name)
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Viết Tắt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        control.Focus();
                        kq = false;
                        return kq;
                    }
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
                            TrinhDoChuyenMon qg = TrinhDoChuyenMon.GetTrinhDoChuyenMon(list[i].MaTrinhDoChuyenMon);
                            MessageBox.Show(this, "Trình độ chuyên môn " + qg.TenTrinhDo.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdTrinhDoChueynMon.ActiveRow = ultragrdTrinhDoChueynMon.Rows[i + 1];
                            ultragrdTrinhDoChueynMon.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        private void ultragrdTrinhDoChueynMon_KeyDown(object sender, KeyEventArgs e)
        {
            ultragrdTrinhDoChueynMon.UpdateData();
        }

        private void ultragrdTrinhDoChueynMon_Leave(object sender, EventArgs e)
        {
            ultragrdTrinhDoChueynMon.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdTrinhDoChueynMon);
        }

    }
}