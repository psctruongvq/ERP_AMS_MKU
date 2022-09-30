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
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmInLoatHDLD : Form
    {
        int Loai = 0; // 0 Ky moi 1 Gia han
        BoPhanList _BophanList = BoPhanList.NewBoPhanList();
        InLoatHDLDList _InLoatHD = InLoatHDLDList.NewInLoatHDLDList();
        HinhThucHopDongList _HDLaoDongList;
        public frmInLoatHDLD()
        {
            InitializeComponent();
        }
        public frmInLoatHDLD(int Loai)
        {
            this.Loai = Loai;
            InitializeComponent();
            this.Load_Source();            
        }
        #region Load
        private void Load_Source()
        {
            try
            {
                _BophanList = BoPhanList.GetBoPhanList();
                BindS_Bophan.DataSource = _BophanList;
                _HDLaoDongList = HinhThucHopDongList.GetHinhThucHopDongList();
                BindS_HinhthucHD.DataSource = _HDLaoDongList;
                dtp_Denngay.Value = DateTime.Now;
                dtp_TuNgay.Value = Convert.ToDateTime(dtp_Denngay.Value).AddDays(15);
            }

            catch (ApplicationException)
            {

            }
        }

        private void grdu_phucaptaynghe_NV_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["id"].Hidden = true;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["manhanvien"].Hidden = true;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["mahopdonglaodong"].Hidden = true;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["maqlnhanvien"].Header.Caption = "Mã nhân viên";
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["tennhanvien"].Header.Caption = "Họ tên";
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["SoHDLD"].Header.Caption = "Số HĐLĐ";
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["Ngayky"].Header.Caption = "Ngày ký";

            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["maqlnhanvien"].Header.VisiblePosition = 2;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["tennhanvien"].Header.VisiblePosition = 3;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["SoHDLD"].Header.VisiblePosition = 4;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["Ngayky"].Header.VisiblePosition = 5;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 1;


            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["maqlnhanvien"].CellActivation = Activation.NoEdit;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["tennhanvien"].CellActivation = Activation.NoEdit;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["SoHDLD"].CellActivation = Activation.NoEdit;
            grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns["Ngayky"].CellActivation = Activation.NoEdit;

            grdu_InLoatHDLD.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_InLoatHDLD.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            foreach (UltraGridColumn col in this.grdu_InLoatHDLD.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
            }

        }

        private void cmbu_bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_bophan.DisplayLayout.Bands[0],
              new string[2] { "Tenbophan", "mabophan" },
              new string[2] { "Bộ Phận", "Mã bộ phận" },
              new int[2] { cmbu_bophan.Width, 90 },
              new Control[2] { null, null },
              new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
              new bool[2] { false, false });
            cmbu_bophan.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_bophan.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;
        }
        #endregion

        #region Event
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void chkNV_CheckedChanged(object sender, EventArgs e)
        {
            if (cmbu_bophan.Text == string.Empty)
            {
                return;
            }
            if (chkNV.Checked == true)
            {
                SqlCommand command = new SqlCommand();
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "Update tblnsInloatHDLD set chon=1";
                command.ExecuteNonQuery();
                _InLoatHD = InLoatHDLDList.GetInLoatHDLDListbybophan((int)cmbu_bophan.Value);
                BindS_InLoatHDLD.DataSource = _InLoatHD;
            }
            else
            {
                SqlCommand command = new SqlCommand();
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "Update tblnsInloatHDLD set chon=null";
                command.ExecuteNonQuery();
                _InLoatHD = InLoatHDLDList.GetInLoatHDLDListbybophan((int)cmbu_bophan.Value);
                BindS_InLoatHDLD.DataSource = _InLoatHD;
            }

        }
        #endregion

        #region Process 
        private void LayDSKyMoi()
        {
            try
            {
                if (cmbu_bophan.ActiveRow != null && cmbu_HinhThucHopDong.Value!=null)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Spd_InserttblnsInLoatHDLDbybohan";
                    command.Parameters.AddWithValue("@mabophan", (int)cmbu_bophan.Value);
                    command.Parameters.AddWithValue("@Tungay", Convert.ToDateTime(dtp_TuNgay.Value));
                    command.Parameters.AddWithValue("@Denngay", Convert.ToDateTime(dtp_Denngay.Value.ToString()));
                    command.Parameters.AddWithValue("@mahinhthucHD", (int)cmbu_HinhThucHopDong.Value);
                    command.ExecuteNonQuery();
                    command.Clone();
                    _InLoatHD = InLoatHDLDList.GetInLoatHDLDListbybophan((int)cmbu_bophan.Value);
                    BindS_InLoatHDLD.DataSource = _InLoatHD;
                }
                // lay ra so hopdong moi nhat
                //for (int i = 0; i < _InLoatHD.Count; i++)
                //{
                //    SqlCommand command = new SqlCommand();
                //    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                //    command.Connection.Open();
                //    command.CommandType = CommandType.StoredProcedure;
                //    command.CommandText = "Spd_UpdatetblnsInloatHDLDcapnhatmasoHDmoinhat";
                //    command.Parameters.AddWithValue("@manhanvien", (long)_InLoatHD[i].Manhanvien);
                //    command.ExecuteNonQuery();
                //    command.Clone();
                //}
            }
            catch (ApplicationException)
            {

            }
        }

        private void LayDSGiaHan()
        {
            try
            {
                if (cmbu_bophan.ActiveRow != null)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.Connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_InserttblnsInLoatHDLDGiaHanbybohan";
                    command.Parameters.AddWithValue("@mabophan", cmbu_bophan.Value);
                    command.ExecuteNonQuery();
                    command.Clone();
                    this.Load_Source();
                    _InLoatHD = InLoatHDLDList.GetInLoatHDLDListbybophan((int)cmbu_bophan.Value);
                    BindS_InLoatHDLD.DataSource = _InLoatHD;
                }
                //// lay ra so hopdong moi nhat
                //for (int i = 0; i < _InLoatHD.Count; i++)
                //{
                //    SqlCommand command = new SqlCommand();
                //    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                //    command.Connection.Open();
                //    command.CommandType = CommandType.StoredProcedure;
                //    command.CommandText = "Spd_UpdatetblnsInloatHDLDcapnhatmasoHDmoinhat";
                //    command.Parameters.AddWithValue("@manhanvien", (long)_InLoatHD[i].Manhanvien);
                //    command.ExecuteNonQuery();
                //    command.Clone();
                //}
            }
            catch (ApplicationException)
            {

            }
        }

        private void InKyMoi()
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_report_tblnsHopdonglaodong_Loat";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsHopdonglaodong_Loat;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "hdld_CongTy";
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "hdld_CongTy;1";

            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "spd_Report_tblnsHopdonglaodong_DieuKhoan";
            command2.Parameters.AddWithValue("@Loai", 1);
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            table2.TableName = "spd_Report_tblnsHopdonglaodong_DieuKhoan;1";

            SqlCommand command3 = new SqlCommand();
            command3.CommandType = CommandType.StoredProcedure;
            command3.CommandText = "spd_report_tblnsHopdonglaodong_NgayHocViec";
            command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            DataTable table3 = new DataTable();
            adapter3.Fill(table3);
            table3.TableName = "spd_report_tblnsHopdonglaodong_NgayHocViec;1";

            SqlCommand command4 = new SqlCommand();
            command4.CommandType = CommandType.StoredProcedure;
            command4.CommandText = "spd_report_tblnsHopdonglaodong_NgayThuViec";
            command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
            DataTable table4 = new DataTable();
            adapter4.Fill(table4);
            table4.TableName = "spd_report_tblnsHopdonglaodong_NgayThuViec;1";         

            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            dataset.Tables.Add(table2);
            dataset.Tables.Add(table3);
            dataset.Tables.Add(table4);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void InHDLDTV_HV()
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_report_tblnsHopdonglaodong_ThuViecHocViec_Loat";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsHopdonglaodong_ThuViecHocViec_Loat;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "hdld_CongTy";
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "hdld_CongTy;1";

            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "spd_Report_tblnsHopdonglaodong_DieuKhoan";
            command2.Parameters.AddWithValue("@Loai", 3);
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            table2.TableName = "spd_Report_tblnsHopdonglaodong_DieuKhoan;1";

            SqlCommand command3 = new SqlCommand();
            command3.CommandType = CommandType.StoredProcedure;
            command3.CommandText = "spd_report_tblnsHopdonglaodong_NgayHocViec";
            command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            DataTable table3 = new DataTable();
            adapter3.Fill(table3);
            table3.TableName = "spd_report_tblnsHopdonglaodong_NgayHocViec;1";

            SqlCommand command4 = new SqlCommand();
            command4.CommandType = CommandType.StoredProcedure;
            command4.CommandText = "spd_report_tblnsHopdonglaodong_NgayThuViec";
            command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
            DataTable table4 = new DataTable();
            adapter4.Fill(table4);
            table4.TableName = "spd_report_tblnsHopdonglaodong_NgayThuViec;1";

            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            dataset.Tables.Add(table2);
            dataset.Tables.Add(table3);
            dataset.Tables.Add(table4);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
       
        private void InGiaHan(string Mau)
        {
            ReportDocument Report;
            if (Mau == "NMI")
            {
                Report = new ReportDocument();
            }
            else
            {
                Report = new ReportDocument();
            }
            DataSet dataset = new DataSet();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;

            command.CommandText = "spd_report_TblnsHopdonglaodongGiahan_Loat";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_TblnsHopdonglaodongGiahan_Loat;1";

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "hdld_CongTy";
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "hdld_CongTy;1";

            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "spd_Report_tblnsHopdonglaodong_DieuKhoan";
            command2.Parameters.AddWithValue("@Loai", 2);
            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            table2.TableName = "spd_Report_tblnsHopdonglaodong_DieuKhoan;1";

            dataset.Tables.Add(table);
            dataset.Tables.Add(table1);
            dataset.Tables.Add(table2);

            Report.SetDataSource(dataset);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        #endregion

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            if (Loai == 0)
            {
                this.LayDSKyMoi();
            }
            else
            {
                this.LayDSGiaHan();
            }
        }

        private void cmbu_HinhThucHopDong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_HinhThucHopDong.DisplayLayout.Bands[0],
            new string[2] { "Tenhinhthuchopdong", "Mahinhthuchopdong" },
            new string[2] { "Hình Thức Hợp Đồng", "Mã hình thức" },
            new int[2] { cmbu_HinhThucHopDong.Width, 90 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["Tenhinhthuchopdong"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_HinhThucHopDong.DisplayLayout.Bands[0].Columns["mahinhthuchopdong"].Hidden = true;
        }

        private void frmInLoatHDLD_Load(object sender, EventArgs e)
        {
            dtp_Denngay.Value = DateTime.Now;
            dtp_TuNgay.Value = DateTime.Now;
        }

        private void mẫuNhàMáyIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _InLoatHD.ApplyEdit();
                _InLoatHD.Save();
            }
            catch (ApplicationException)
            {

            }
            if (Loai == 0)
            {
                this.InKyMoi();
            }
            else
            {
                this.InGiaHan("NMI");
            }
        }

        private void mẫuSpacificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _InLoatHD.ApplyEdit();
                _InLoatHD.Save();
            }
            catch (ApplicationException)
            {

            }
            if (Loai == 0)
            {
                this.InKyMoi();
            }
            else
            {
                this.InGiaHan("SPACIFIC");
            }
        }

        private void hĐLĐHọcViệcThửViệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                _InLoatHD.ApplyEdit();
                _InLoatHD.Save();
            }
            catch (ApplicationException)
            {

            }
            this.InHDLDTV_HV();
        }
    }
}