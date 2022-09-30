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
    public partial class frmPhuongThucGiaoNhan : Form
    {
        PhuongThucGiaoNhanList _phuongThucGiaoNhanList;

        HamDungChung hamDungChung = new HamDungChung();

        #region contructors
        public frmPhuongThucGiaoNhan()
        {
            InitializeComponent();
            hamDungChung.EventForm(this);
            KhoiTao();
        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            _phuongThucGiaoNhanList = PhuongThucGiaoNhanList.GetPhuongThucGiaoNhanList();
            phuongThucGiaoNhanListBindingSource.DataSource = _phuongThucGiaoNhanList;
        }
        #endregion

        #region KiemTraDuLieu()
        private Boolean KiemTraDuLieu()
        {
            Boolean kq = true;
            if (txtMaPTGN.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Phương Thức Giao Nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPTGN.Focus();
                kq = false;
                return kq;
            }
            else if (txtTenPTGN.Text == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Phương Thức Giao Nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPTGN.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }

        private Boolean KiemTraDuLieu(PhuongThucGiaoNhan phuongThucGiaoNhan)
        {
            Boolean kq = true;
            if (phuongThucGiaoNhan.MaPTGNQL == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Mã Phương Thức Giao Nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPTGN.Focus();
                kq = false;
                return kq;
            }
            else if (phuongThucGiaoNhan.TenPhuongThuc == string.Empty)
            {
                MessageBox.Show(this, "Vui Lòng Nhập Tên Phương Thức Giao Nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPTGN.Focus();
                kq = false;
                return kq;
            }
            return kq;
        }
        #endregion

        #region ultraGridPuongThucGN_InitializeLayout
        private void ultraGridPuongThucGN_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ultraGridPuongThucGN.DisplayLayout.Bands[0].Columns["MaPTGNQL"].Header.Caption = "Mã Phương Thức Thanh Toán";
            ultraGridPuongThucGN.DisplayLayout.Bands[0].Columns["MaPTGNQL"].Header.VisiblePosition = 1;
            ultraGridPuongThucGN.DisplayLayout.Bands[0].Columns["TenPhuongThuc"].Header.Caption = "Tên Phương Thức Thanh Toán";
            ultraGridPuongThucGN.DisplayLayout.Bands[0].Columns["TenPhuongThuc"].Header.VisiblePosition = 2;
            ultraGridPuongThucGN.DisplayLayout.Bands[0].Columns["MaPhuongThucGiaoNhan"].Hidden = true;

            this.ultraGridPuongThucGN.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.ultraGridPuongThucGN.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.ultraGridPuongThucGN.DisplayLayout.Bands[0].Columns)
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

            if (_phuongThucGiaoNhanList.Count == 0)
            {
                PhuongThucGiaoNhan phuongThucGiaoNhan = PhuongThucGiaoNhan.NewPhuongThucGiaoNhan();
                _phuongThucGiaoNhanList.Add(phuongThucGiaoNhan);
                ultraGridPuongThucGN.ActiveRow = ultraGridPuongThucGN.Rows[_phuongThucGiaoNhanList.Count - 1];
            }
            else
            {
                if (KiemTraDuLieu() == true)
                {
                    PhuongThucGiaoNhan phuongThucGiaoNhan = PhuongThucGiaoNhan.NewPhuongThucGiaoNhan();
                    _phuongThucGiaoNhanList.Add(phuongThucGiaoNhan);
                    ultraGridPuongThucGN.ActiveRow = ultraGridPuongThucGN.Rows[_phuongThucGiaoNhanList.Count - 1];
                }
            }
        }
        #endregion

        #region luuToolStripMenuItem_Click
        private void luuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PhuongThucGiaoNhan phuongThucGiaoNhan;
            for (int i = 0; i < _phuongThucGiaoNhanList.Count; i++)
            {

                phuongThucGiaoNhan = _phuongThucGiaoNhanList[i];
                if (phuongThucGiaoNhan.MaPTGNQL == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Phương Thức Giao Nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridPuongThucGN.ActiveRow = ultraGridPuongThucGN.Rows[i];
                    txtMaPTGN.Focus();
                    return;
                }
                else if (phuongThucGiaoNhan.TenPhuongThuc == string.Empty)
                {
                    MessageBox.Show(this, "Vui Lòng Nhập Tên Phương Thức Giao Nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultraGridPuongThucGN.ActiveRow = ultraGridPuongThucGN.Rows[i];
                    txtTenPTGN.Focus();
                    return;
                }
            }
            if (MessageBox.Show(this, "Bạn Có Muốn Lưu Dữ Liệu Hiện Tại", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                try
                {
                    _phuongThucGiaoNhanList.ApplyEdit();
                    _phuongThucGiaoNhanList.Save();
                    KhoiTao();
                }
                catch (ApplicationException ex)
                { 
                }
            }
        }
        #endregion

        #region xóaToolStripMenuItem_Click
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ultraGridPuongThucGN.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else ultraGridPuongThucGN.DeleteSelectedRows();
        }
        #endregion

        #region thoatToolStripMenuItem_Click
        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region inToolStripMenuItem_Click
        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                ReportDocument Report = new Report.Report_MuaBan.DanhSachPhuongThucGiaoNhan();
                DataSet dataSet = new DataSet();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "select * from View_PhuongThucGiaoNhan";                
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "View_PhuongThucGiaoNhan";

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

        private void frmPhuongThucGiaoNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Phuong Thuc Giao Nhan", "Help_BanHang.chm");
            }
        }
    }
}