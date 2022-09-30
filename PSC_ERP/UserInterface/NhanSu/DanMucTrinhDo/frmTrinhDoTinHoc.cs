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
    public partial class frmTrinhDoTinHoc : Form
    {
        Util util=new Util();
        TrinhDoTinHocClassList list;
        public delegate void PassData(TrinhDoTinHocClassList value);
        public PassData getData;
        TrinhDoTinHocClass _TrinhDoTinHocClass;
        public frmTrinhDoTinHoc()
        {
            InitializeComponent();
        }
        #region Load
        private void Load_Luoi()
        {
            try
            {
                list = TrinhDoTinHocClassList.GetTrinhDoTinHocClassList();
                TrinhDoTinHoc_bindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }
        }

        private void frmTrinhDoTinHoc_Load(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void ultragrdTrinhDoTinHoc_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //ultragrdTrinhDoTinHoc.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //ultragrdTrinhDoTinHoc.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["MaTrinhDoTH"].Hidden = true;
            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Header.Caption = "Trình Độ Tin Học";
            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Header.VisiblePosition = 1;
            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TrinhDoTinHoc"].Width = 180;

            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.Caption = "Tên Viết Tắt";
            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TenVietTat"].Header.VisiblePosition = 2;
            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["TenVietTat"].Width = 100;

            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Ghi Chú";
            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 200;

            foreach (UltraGridColumn col in ultragrdTrinhDoTinHoc.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        #region Event
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdTrinhDoTinHoc.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdTrinhDoTinHoc.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Luoi();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
                if (!KiemTraControl())
                {
                    return;
                }
                for (int i = 0; i < list.Count; i++)
                {

                    if (ultragrdTrinhDoTinHoc.Rows[i].Cells["MaQuanLy"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Mã Trình Độ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdTrinhDoTinHoc.ActiveRow = ultragrdTrinhDoTinHoc.Rows[i];
                        return;
                    }
                    if (ultragrdTrinhDoTinHoc.Rows[i].Cells["TrinhDoTinHoc"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Nhập Tên Trình Độ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdTrinhDoTinHoc.ActiveRow = ultragrdTrinhDoTinHoc.Rows[i];
                        return;
                    }
                    if (ultragrdTrinhDoTinHoc.Rows[i].Cells["TenVietTat"].Text == "")
                    {
                        MessageBox.Show(this, "Vui Lòng Chọn Tên Viết Tắt", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ultragrdTrinhDoTinHoc.ActiveRow = ultragrdTrinhDoTinHoc.Rows[i];
                        return;
                    }
                }
                if (KiemTraControl() == true)
                {
                    try
                    {
                        list.ApplyEdit();
                        list.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Load_Luoi();
                        if (getData != null)
                        {
                            getData(list);
                        }
                    }
                    catch (ApplicationException)
                    {

                    }
                }          

        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ShowReport(new string[] { "spd_report_tblnstrinhdotinhocAll", "spd_REPORT_ReportHeader" }, ERP_Library.Database.ERP_Connection, new Report.rptTrinhdotinhoc(), new frmHienThiReport(), false);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            try
            {
                _TrinhDoTinHocClass = TrinhDoTinHocClass.NewTrinhDoTinHocClass();
                list.Add(_TrinhDoTinHocClass);
                TrinhDoTinHoc_bindingSource.DataSource = list;
                ultragrdTrinhDoTinHoc.ActiveRow = ultragrdTrinhDoTinHoc.Rows[list.Count - 1];
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        #endregion

        private void ultragrdTrinhDoTinHoc_KeyDown(object sender, KeyEventArgs e)
        {
            ultragrdTrinhDoTinHoc.UpdateData();
        }

        private void ultragrdTrinhDoTinHoc_Leave(object sender, EventArgs e)
        {
            ultragrdTrinhDoTinHoc.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdTrinhDoTinHoc);
        }

    }
}