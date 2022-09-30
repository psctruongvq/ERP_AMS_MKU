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
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;


namespace PSC_ERP
{
    public partial class frmPhuongThucThanhToan : Form
    {
        PhuongThucThanhToanList _phuongThucThanhToanList;
        HamDungChung hamDungChung = new HamDungChung();

        #region contructors
        public frmPhuongThucThanhToan()
        {
            InitializeComponent();
            hamDungChung.EventForm(this);
            KhoiTao();
        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            _phuongThucThanhToanList = PhuongThucThanhToanList.GetPhuongThucThanhToanList();
            phuongThucThanhToanListBindingSource.DataSource = _phuongThucThanhToanList;
        }
        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txtMaPTTT.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Phương Thức Thanh Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPTTT.Focus();
                kq = false;
                return kq;
            }
            else if (txtTenPTTT.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Phương Thức Thanh Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPTTT.Focus();
                kq = false;
                return kq;
            } 
            return kq;
        }

        private Boolean KiemTraDuLieu(PhuongThucThanhToan phuongThucThanhToan)
        {
            Boolean kq = true;
            if (phuongThucThanhToan.MaQuanLyPTTT == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Phương Thức Thanh Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPTTT.Focus();
                kq = false;
                return kq;
            }
            else if (phuongThucThanhToan.TenPhuongThucThanhToan == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Phương Thức Thanh Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPTTT.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region ultraGridPuongThucTT_InitializeLayout
        private void ultraGridPuongThucTT_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ultraGridPuongThucTT.DisplayLayout.Bands[0].Columns["MaQuanLyPTTT"].Header.Caption = "Mã Phương Thức Thanh Toán";
            ultraGridPuongThucTT.DisplayLayout.Bands[0].Columns["MaQuanLyPTTT"].Header.VisiblePosition = 1;
            ultraGridPuongThucTT.DisplayLayout.Bands[0].Columns["TenPhuongThucThanhToan"].Header.Caption = "Tên Phương Thức Thanh Toán";
            ultraGridPuongThucTT.DisplayLayout.Bands[0].Columns["TenPhuongThucThanhToan"].Header.VisiblePosition = 2;
            ultraGridPuongThucTT.DisplayLayout.Bands[0].Columns["MaPhuongThucThanhToan"].Hidden = true;
            
            this.ultraGridPuongThucTT.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraGridPuongThucTT.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraGridPuongThucTT.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }

        }
        #endregion

        #region thêmToolStripMenuItem_Click
        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_phuongThucThanhToanList.Count == 0)
            {
                PhuongThucThanhToan phuongThucThanhToan = PhuongThucThanhToan.NewPhuongThucThanhToan();
                _phuongThucThanhToanList.Add(phuongThucThanhToan);
                ultraGridPuongThucTT.ActiveRow = ultraGridPuongThucTT.Rows[_phuongThucThanhToanList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    PhuongThucThanhToan phuongThucThanhToan = PhuongThucThanhToan.NewPhuongThucThanhToan();
                    _phuongThucThanhToanList.Add(phuongThucThanhToan);
                    ultraGridPuongThucTT.ActiveRow = ultraGridPuongThucTT.Rows[_phuongThucThanhToanList.Count - 1];
                }
            }
        }
        #endregion

        #region luuToolStripMenuItem_Click
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhuongThucThanhToan phuongThucThanhToan;
            for (int i = 0; i < _phuongThucThanhToanList.Count; i++)
            {

                phuongThucThanhToan = _phuongThucThanhToanList[i];
                if (phuongThucThanhToan.MaQuanLyPTTT == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Phương Thức Thanh Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridPuongThucTT.ActiveRow = ultraGridPuongThucTT.Rows[i];
                    txtMaPTTT.Focus();
                    return;
                }
                else if (phuongThucThanhToan.TenPhuongThucThanhToan == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Phương Thức Thanh Toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridPuongThucTT.ActiveRow = ultraGridPuongThucTT.Rows[i];
                    txtTenPTTT.Focus();
                    return;
                }
            }
            if (MessageBox.Show(this, "Bạn Có Muốn Lưu Dữ Liệu Hiện Tại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    _phuongThucThanhToanList.ApplyEdit();
                    _phuongThucThanhToanList.Save();
                    KhoiTao();
                }
                catch (ApplicationException ex)
                { }
            }
        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultraGridPuongThucTT.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else ultraGridPuongThucTT.DeleteSelectedRows();
        }
        #endregion

        #region thoatToolStripMenuItem_Click
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.Report_MuaBan.DanhSachPhuongThucThanhToan();
            DataSet dataSet = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from View_PhuongThucThanhToan";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "View_PhuongThucThanhToan";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_Report_ReportHeader";
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            adapter = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";

            dataSet.Tables.Add(table);
            dataSet.Tables.Add(table1);

            Report.SetDataSource(dataSet);
            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        #endregion 

        private void frmPhuongThucThanhToan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Phuong Thuc Thanh Toan", "Help_BanHang.chm");
            }
        }
    }
}