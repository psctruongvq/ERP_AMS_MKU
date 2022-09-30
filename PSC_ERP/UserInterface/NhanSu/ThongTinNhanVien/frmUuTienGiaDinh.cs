using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmUuTienGiaDinh : Form
    {
        Util util=new Util();
        UuTienGiaDinhList list;
        UuTienGiaDinh _UuTienGiaDinh;
        public delegate void PassData(UuTienGiaDinhList value);
        public PassData getData;
        public frmUuTienGiaDinh()
        {
            InitializeComponent();
        }

        private void frmUuTienGiaDinh_Load(object sender, EventArgs e)
        {
            Load_LenLuoi();
        }

        private void Load_LenLuoi()
        {
            try
            {
                list = UuTienGiaDinhList.GetUuTienGiaDinhList();
                UuTienGiaDinhBindingSource.DataSource = list;
            }
            catch (ApplicationException)
            {

            }

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (ultragrdUuTienGiaDinh.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, util.chodongcanxoa, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ultragrdUuTienGiaDinh.DeleteSelectedRows();
        }

        private bool KiemTra_Luoi()
        {
            bool kq = true;
            for (int i = 1; i < ultragrdUuTienGiaDinh.Rows.Count; i++)
            {
                //_UuTienBanThan = list[i];
                if (ultragrdUuTienGiaDinh.Rows[i].Cells["MaQuanLy"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Mã Quản Lý", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdUuTienGiaDinh.ActiveRow = ultragrdUuTienGiaDinh.Rows[i];
                    return kq;
                }
                if (ultragrdUuTienGiaDinh.Rows[i].Cells["UuTienGD"].Text == "")
                {
                    kq = false;
                    MessageBox.Show(this, "Vui Lòng Nhập Ưu Tiên Gia Đình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ultragrdUuTienGiaDinh.ActiveRow = ultragrdUuTienGiaDinh.Rows[i];
                    return kq;
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
                            UuTienGiaDinh cd = UuTienGiaDinh.GetUuTienGiaDinh(list[i].MaUuTienGiaDinh);
                            MessageBox.Show(this, "Ưu tiên " + cd.UuTienGD.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            ultragrdUuTienGiaDinh.ActiveRow = ultragrdUuTienGiaDinh.Rows[i];
                            ultragrdUuTienGiaDinh.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (KiemTra_Luoi() == true)
            {
                if (KiemTraMaQuanLy() == true)
                {
                    try
                    {
                        list.ApplyEdit();
                        list.Save();
                        MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (getData != null)
                        {
                            getData(list);
                        }
                    }
                    catch (ApplicationException)
                    {

                    }
                    //this.Load_LenLuoi();
                }
            }
        }

        private void ultragrdUuTienGiaDinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

           // ultragrdUuTienGiaDinh.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.ultragrdUuTienGiaDinh.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            ultragrdUuTienGiaDinh.DisplayLayout.Bands[0].Columns["MaUuTienGiaDinh"].Hidden = true;
            ultragrdUuTienGiaDinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Quản Lý";
            ultragrdUuTienGiaDinh.DisplayLayout.Bands[0].Columns["MaQuanLy"].Width = 150;
            ultragrdUuTienGiaDinh.DisplayLayout.Bands[0].Columns["UuTienGD"].Header.Caption = "Ưu Tiên Gia Đình";
            ultragrdUuTienGiaDinh.DisplayLayout.Bands[0].Columns["UuTienGD"].Width = 300;

            foreach (UltraGridColumn col in this.ultragrdUuTienGiaDinh.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }
        }
        
        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Load_LenLuoi();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.rptUuTienGiaDinh();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_UuTienGiaDinhesAll";
            //command.Parameters.AddWithValue("@MaChiNhanh", _MaChiNhanh);
            //command.Parameters.AddWithValue("@TuNgay", _TuNgay);
            //command.Parameters.AddWithValue("@DenNgay", _DenNgay);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_UuTienGiaDinhesAll;1";

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

        private void ultragrdUuTienGiaDinh_KeyDown(object sender, KeyEventArgs e)
        {
            ultragrdUuTienGiaDinh.UpdateData();
        }

        private void ultragrdUuTienGiaDinh_Leave(object sender, EventArgs e)
        {
            ultragrdUuTienGiaDinh.UpdateData();
        }

        private void tlslblExportExcel_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(ultragrdUuTienGiaDinh);
        }
    }
}