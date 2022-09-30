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
    public partial class frmPhucaptrachnhiem : Form
    {
        Util util = new Util();
        PhuCapTrachNhiemList _PCTrachNhiemList = PhuCapTrachNhiemList.NewPhuCapTrachNhiemList();
        ChucVuList _ChuvuList = ChucVuList.NewChucVuList();
        public frmPhucaptrachnhiem()
        {
            InitializeComponent();
            Load_Source();
        }
            
        #region"Load"
        private void Load_Source()
        {
            _PCTrachNhiemList = PhuCapTrachNhiemList.GetPhuCapTrachNhiemList();
            BindS_PCTrachNhiem.DataSource = _PCTrachNhiemList;
            _ChuvuList = ChucVuList.GetChucVuList();
            BindS_Chucvu.DataSource = _ChuvuList;
        }
        private void grdu_phucaptheochucvu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["maphucaptrachnhiem"].Hidden = true;
            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["machucvu"].Hidden = true;
            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["tenchucvu"].Header.Caption = "Chức vụ";
            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["Sotien"].Header.Caption = "Số tiền";
            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["Ghichu"].Header.Caption = "Ghi chú";
            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["Ngaylap"].Header.Caption = "Ngày lập";

            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["tenchucvu"].Header.VisiblePosition = 1;
            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["Sotien"].Header.VisiblePosition = 2;
            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["Ghichu"].Header.VisiblePosition = 3;
            grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns["Ngaylap"].Header.VisiblePosition = 4;

            grdu_phucaptrachnhiem.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_phucaptrachnhiem.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_phucaptrachnhiem.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
        }

        private void cmbu_chucvu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_chucvu.DisplayLayout.Bands[0],
                new string[2] { "Tenchucvu", "machucvu" },
                new string[2] { "Chức vụ", "Mã số" },
                new int[2] { 120, 90 },
                new Control[2] { null, null },
                new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[2] { false, false });
        }
        #endregion

        #region"Event"
        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_phucaptrachnhiem.Selected.Rows.Count == 0)
            {
                MessageBox.Show(this, "Vui Lòng Chọn  Dòng Dữ Liệu Cần Xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else grdu_phucaptrachnhiem.DeleteSelectedRows();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            PhuCapTrachNhiem _PCTrachnhiem;
            for (int i = 0; i < _PCTrachNhiemList.Count; i++)
            {
                if (_PCTrachNhiemList[i].MaChucVu == 0)
                {
                    return;
                }
                if (_PCTrachNhiemList[i].SoTien == 0)
                {
                    return;
                }
            }
            _PCTrachnhiem = PhuCapTrachNhiem.NewPhuCapTrachNhiem();
            _PCTrachNhiemList.Add(_PCTrachnhiem);
            grdu_phucaptrachnhiem.ActiveRow = grdu_phucaptrachnhiem.Rows[_PCTrachNhiemList.Count - 1];
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < _PCTrachNhiemList.Count; i++)
                {
                    if (_PCTrachNhiemList[i].MaChucVu == 0)
                    {
                        MessageBox.Show(this, "Không để trống mã chức vụ", util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        grdu_phucaptrachnhiem.ActiveRow = grdu_phucaptrachnhiem.Rows[i];
                        return;
                    }
                }
                if (KiemTraMaQuanLy())
                {
                    _PCTrachNhiemList.ApplyEdit();
                    _PCTrachNhiemList.Save();
                    this.Capnhatvaohoso();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Load_Source();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.Danhsach_PCTrachnhiem();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_tblnsPhuCapTrachnhiem";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_tblnsPhuCapTrachnhiem;1";

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

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
        }
        #endregion

        #region"Process"
        private void Capnhatvaohoso()
        {
                int rowseffect;
                SqlCommand command = new SqlCommand();
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                command.Connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "Spd_SelecttblnsPhucaptrachniemintoNhanvien";
                rowseffect= command.ExecuteNonQuery();                    
        }
        private Boolean KiemTraMaQuanLy()
        {
            for (int i = 0; i < _PCTrachNhiemList.Count; i++)
            {
                for (int j = 0; j < _PCTrachNhiemList.Count; j++)
                {
                    if (i != j)
                    {
                        if (_PCTrachNhiemList[i].MaChucVu == _PCTrachNhiemList[j].MaChucVu)
                        {
                            MessageBox.Show(this, "Chức vụ " + _PCTrachNhiemList[i].Tenchucvu.ToString() + " bị trùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            grdu_phucaptrachnhiem.ActiveRow = grdu_phucaptrachnhiem.Rows[i];
                            grdu_phucaptrachnhiem.Focus();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private string laytenchucvu(int machucvu)
        {
            string tenchucvu;
            ChucVu _Chucvu;
            _Chucvu = ChucVu.GetChucVu(machucvu);
            tenchucvu = _Chucvu.TenChucVu;
            return tenchucvu;
        }
        #endregion

        private void cmbu_chucvu_AfterCloseUp(object sender, EventArgs e)
        {
            //grdu_phucaptrachnhiem.ActiveRow.Cells["Tenchucvu"].Value = laytenchucvu((int)cmbu_chucvu.Value);
        }
    }
}