using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmBiaBHXH : Form
    {
        BiaBHXHList _BiaBHXHList = BiaBHXHList.NewBiaBHXHList();
        Util util = new Util();
        public frmBiaBHXH()
        {
            InitializeComponent();
            this.Load_Source();
        }
        #region Load
        private void Load_Source()
        {
            try
            {
                _BiaBHXHList = BiaBHXHList.GetBiaBHXHList();
                BindS_BiaBHXH.DataSource = _BiaBHXHList;
            }
            catch (ApplicationException)
            {

            }
        }
        private void grdu_BiaBHXH_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["mabiaBHXH"].Hidden = true;
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["Loai"].Hidden = true;
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["mabiaBHXHquanly"].Header.Caption = "Mã số";
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["mabiaBHXHquanly"].Width = 80;
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["mabiaBHXHquanly"].Header.VisiblePosition = 0;

            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["TenbiaBHXH"].Header.Caption = "Tên bìa hồ sơ";
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["TenbiaBHXH"].Width = 150;
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["TenbiaBHXH"].Header.VisiblePosition = 1;

            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["Soluongchua"].Header.Caption = "Số lượng đã chứa";
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["Soluongchua"].Header.VisiblePosition = 2;
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["Soluongchua"].CellClickAction = CellClickAction.CellSelect;


            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["soluongtoida"].Header.Caption = "Số lượng tối đa";
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["soluongtoida"].Header.VisiblePosition = 3;
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["ngaytao"].Header.Caption = "Ngày tạo";
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["ngaytao"].Header.VisiblePosition = 4;
            grdu_BiaBHXH.DisplayLayout.Bands[0].Columns["Nguoitao"].Hidden = true;

            grdu_BiaBHXH.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_BiaBHXH.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_BiaBHXH.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
                for (int i = 0; i < grdu_BiaBHXH.Rows.Count; i++)
                {
                    if (grdu_BiaBHXH.Rows[i].Cells["mabiaBHXHquanly"].Text == "")
                    {
                        MessageBox.Show(this, util.chonNhomChucVu, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_BiaBHXH.ActiveRow = grdu_BiaBHXH.Rows[i];
                        return;
                    }
                    if (grdu_BiaBHXH.Rows[i].Cells["Soluongtoida"].Text == "0" || (int)grdu_BiaBHXH.Rows[i].Cells["Soluongtoida"].Value >150)
                    {
                        MessageBox.Show(this, "Nhập Số Lượng Tối Đa Cho Bìa BHXH . Hoặc Số Lượng Chứa Tối Đa Quá Lớn !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_BiaBHXH.ActiveRow = grdu_BiaBHXH.Rows[i];
                        return;
                    }
                }
                for (int i = 0; i < _BiaBHXHList.Count; i++)
                {
                    if (_BiaBHXHList[i].SoLuongChua > _BiaBHXHList[i].SoLuongToiDa)
                    {
                        MessageBox.Show(this, "Số lượng chứa tối đa phải lớn hơn số lượng đang chứa.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_BiaBHXH.ActiveRow = grdu_BiaBHXH.Rows[i];
                        return;
                    }
                }
                if (KiemTraMaQuanLy() == true)
                {
                    try
                    {
                        _BiaBHXHList.ApplyEdit();
                        _BiaBHXHList.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Load_Source();
                    }
                    catch (ApplicationException)
                    {

                    }
                }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_BiaBHXH.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            grdu_BiaBHXH.DeleteSelectedRows();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            BiaBHXH BiaBHXH;
            for (int i = 0; i < _BiaBHXHList.Count; i++)
            {
                BiaBHXH = _BiaBHXHList[i];
                if (BiaBHXH.MaBiaBHXHQuanLy == "")
                {
                    return;
                }
            }
            BiaBHXH = BiaBHXH.NewBiaBHXH();
            _BiaBHXHList.Add(BiaBHXH);
            grdu_BiaBHXH.ActiveRow = grdu_BiaBHXH.Rows[_BiaBHXHList.Count - 1];
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.DanhsachBiaBHXH();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_tblnsBiaBHXHAll";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_tblnsBiaBHXHAll;1";

            //// store thu 2
            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";

            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";

            dataset.Tables.Add(table1);
            dataset.Tables.Add(table);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        #endregion

        #region Process
        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _BiaBHXHList.Count; i++)
            {
                for (int j = 0; j < _BiaBHXHList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_BiaBHXHList[i].MaBiaBHXHQuanLy.Trim() == _BiaBHXHList[j].MaBiaBHXHQuanLy.Trim())
                        {
                            BiaBHXH BiaBHXH = BiaBHXH.GetBiaBHXH(_BiaBHXHList[i].MaBiaBHXH);
                            MessageBox.Show(this, "Bìa hồ sơ " + BiaBHXH.TenBiaBHXH.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_BiaBHXH.ActiveRow = grdu_BiaBHXH.Rows[i];
                            grdu_BiaBHXH.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        private void grdu_BiaBHXH_KeyDown(object sender, KeyEventArgs e)
        {
            grdu_BiaBHXH.UpdateData();
        }

        private void grdu_BiaBHXH_Leave(object sender, EventArgs e)
        {
            grdu_BiaBHXH.UpdateData();
        }

        private void frmBiaBHXH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                //frmMainNhanSu.LoadHelp(this, "Bia bao hiem");
            }
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            //frmMainNhanSu.LoadHelp(this, "Bia bao hiem");
        }


    }
}