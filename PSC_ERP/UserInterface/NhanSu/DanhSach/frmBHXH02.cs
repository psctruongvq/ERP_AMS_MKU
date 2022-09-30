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
    public partial class frmBHXH02 : Form
    {
        Util util = new Util();
        BoPhanList _BophanList;
        BHXH02List _BHXHList;
        int SoLD = 0;
        decimal QLBH = 0,QLYTE=0;
        public frmBHXH02()
        {
            InitializeComponent();
            this.Load_Source();
        }

        #region Load
        private void Load_Source()
        {
            _BophanList = BoPhanList.GetBoPhanList();
            BindS_BoPhan.DataSource = _BophanList;
        }

        private void grdu_BHXH02_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {            
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["maso"].Hidden = true;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["Thang"].Hidden = true;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["nam"].Hidden = true;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["Manhanvien"].Hidden = true;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.Caption = "Họ Tên";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["Tennhanvien"].Width = 150;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.VisiblePosition = 0;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellActivation = Activation.NoEdit;


            grdu_BHXH02.DisplayLayout.Bands[0].Columns["NoiDKTinh"].Header.Caption = "Nơi ĐK (Tỉnh)";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["NoiDKTinh"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["NoiDKTinh"].Header.VisiblePosition = 1;


            grdu_BHXH02.DisplayLayout.Bands[0].Columns["NoiDKBenhvien"].Header.Caption = "Nơi ĐK (Bệnh Viện)";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["NoiDKBenhvien"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["NoiDKBenhvien"].Header.VisiblePosition = 2;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["LuongCb"].Header.Caption = "Mức Lương";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["LuongCb"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["LuongCb"].Header.VisiblePosition = 3;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["LuongCb"].CellActivation = Activation.NoEdit;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCChucvu"].Header.Caption = "PC Chức Vụ";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCChucvu"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCChucvu"].Header.VisiblePosition = 4;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCthamnienVK"].Header.Caption = "PC Thâm Niên VK";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCthamnienVK"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCthamnienVK"].Header.VisiblePosition = 5;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCthamniennghe"].Header.Caption = "PC Thâm Niên Nghề";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCthamniennghe"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCthamniennghe"].Header.VisiblePosition = 6;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCKhuVuc"].Header.Caption = "PC Khu Vực";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCKhuVuc"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["PCKhuVuc"].Header.VisiblePosition = 7;


            grdu_BHXH02.DisplayLayout.Bands[0].Columns["ThamGiaTu"].Header.Caption = "TG Từ Ngày";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["ThamGiaTu"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["ThamGiaTu"].Header.VisiblePosition = 8;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["ThamGiaDen"].Header.Caption = "TG Đến";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["ThamGiaDen"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["ThamGiaDen"].Header.VisiblePosition = 9;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 150;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 10;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["Sothang"].Header.Caption = "Số Tháng";
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["Sothang"].Width = 85;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["Sothang"].Header.VisiblePosition = 11;

            grdu_BHXH02.DisplayLayout.Bands[0].Columns["BSBHXH"].Hidden = true;
            grdu_BHXH02.DisplayLayout.Bands[0].Columns["BSBHYT"].Hidden = true;
            foreach (UltraGridColumn col in grdu_BHXH02.DisplayLayout.Bands[0].Columns)
            {
                col.SortIndicator = SortIndicator.Ascending;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.TextHAlign = HAlign.Center;
            }
        }

        private void frmBHXH02_Load(object sender, EventArgs e)
        {
            cmbu_Thang.Value = DateTime.Now.Month.ToString();
            txt_nam.Text = DateTime.Now.Year.ToString();
        }

        private void Load_nguon()
        {
                _BHXHList = BHXH02List.GetBHXH02ListByThangNam((int)cmbu_Thang.Value, Convert.ToInt32(txt_nam.Text));
                BindS_BHXH02.DataSource = _BHXHList;
                SoLD = _BHXHList.Count;
            int thang = 0, nam = 0;
            if (cmbu_Thang.Text != "")
            {
                thang = Convert.ToInt32(cmbu_Thang.Text);
            }
            if (txt_nam.Text!="")
            {
                nam = Convert.ToInt32(txt_nam.Text);
            }
            if (thang != 0 && nam != 0)
            this.TinhTongSo(thang, nam);
        }
        #endregion

        #region Event
        private void tlslblThem_Click(object sender, EventArgs e)
        {

            int thang=0, nam=0;
            if (cmbu_Thang.Text!="")
            {
                thang = Convert.ToInt32(cmbu_Thang.Text);
            }
            if (txt_nam.Text!="")
            {
                nam = Convert.ToInt32(txt_nam.Text);
            }
            if (thang!=0 && nam!=0)
            {
                DialogResult = MessageBox.Show(this, "Chương Trình Sẽ Tạo Mới Danh Sách Theo Tháng " + cmbu_Thang.Text.ToString() + ". Thực Hiện Thao Tác (Yes/No) ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult == DialogResult.Yes)
                {
                    BHXH02.Taodulieu(thang, nam);
                }
            }
            this.Load_nguon();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show(this, "Cập Nhật Và Tính Lại. Thực Hiện Thao Tác (Yes/No)?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                try
                {
                    _BHXHList.ApplyEdit();
                    _BHXHList.Save();
                    MessageBox.Show(util.thanhcong, util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (ApplicationException ex)
                {

                }
                int thang = 0, nam = 0;
                if (cmbu_Thang.Text != "")
                {
                    thang = Convert.ToInt32(cmbu_Thang.Text);
                }
                if (txt_nam.Text != "")
                {
                    nam = Convert.ToInt32(txt_nam.Text);
                }
                BHXH02.Tinhlai(thang, nam);
                this.Load_nguon();
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_BHXH02.ActiveRow != null)
            {
                grdu_BHXH02.DeleteSelectedRows();
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            int thang = 0, nam = 0;
            if (cmbu_Thang.Text != "")
            {
                thang = Convert.ToInt32(cmbu_Thang.Text);
            }
            if (txt_nam.Text != "")
            {
                nam = Convert.ToInt32(txt_nam.Text);
            }
            if (thang != 0 && nam != 0)
            {
                this.InMau02(thang, nam);
            }
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Source();
            this.Load_nguon();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Process
        private void TinhTongSo(int thang, int nam)
        {
            try
            {
                txt_BHXHsold.Text = SoLD.ToString("#,###");
                txt_BHYTsold.Text = SoLD.ToString("#,###");
                // Quy luong
                QLBH = BHXH02.QuyluongBH(thang, nam);
                QLYTE = BHXH02.QuyluongYTE(thang, nam);
                txt_BHXHquyluong.Text = QLBH.ToString("#,###");
                txt_BHYTQuyluong.Text = QLYTE.ToString("#,###");
                // So phai dong
                txt_BHXHsophaidong.Text = (QLBH * 20 / 100).ToString("#,###");
                txt_BHYTsophaidong.Text = (QLYTE * 3 / 100).ToString("#,###");

                txt_BHXHsobosung.Text = BHXH02.BHBS(thang, nam).ToString("#,###");
                txt_BHYTsobosung.Text = BHXH02.YTEBS(thang, nam).ToString("#,###");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, "Chưa Có Dữ Liệu !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InMau02(int thang, int nam)
        {
            int soldbh = 0, soldyt = 0;
            decimal qlbh = 0, qlyt = 0, psbh = 0, psyt = 0, bsyt = 0, bsbh = 0;

            soldbh = Convert.ToInt32(txt_BHXHsold.Text);
            soldyt = Convert.ToInt32(txt_BHYTsold.Text);
            qlbh = Convert.ToDecimal(txt_BHXHquyluong.Text);
            qlyt = Convert.ToDecimal(txt_BHYTQuyluong.Text);
            psbh = Convert.ToDecimal(txt_BHXHsophaidong.Text);
            psyt = Convert.ToDecimal(txt_BHYTsophaidong.Text);
            bsyt = Convert.ToDecimal(txt_BHYTsobosung.Text);
            bsbh = Convert.ToDecimal(txt_BHXHsobosung.Text);

            ReportDocument Report = new Report.Mau02BH();
            SqlCommand command = new SqlCommand();
            DataSet dataset = new DataSet();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_tblnsBHXH02";
            command.Parameters.AddWithValue("@Thang", thang);
            command.Parameters.AddWithValue("@nam", nam);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_tblnsBHXH02;1";
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
            Report.SetParameterValue("BHSold", soldbh);
            Report.SetParameterValue("YTSold", soldyt);
            Report.SetParameterValue("QLBH", qlbh);
            Report.SetParameterValue("QLYT", qlyt);
            Report.SetParameterValue("SoPDBH", psbh);
            Report.SetParameterValue("SoPDYT", psyt);
            Report.SetParameterValue("SoBSBH", bsbh);
            Report.SetParameterValue("SoBSYT", bsyt);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        #endregion
        
    }
}
