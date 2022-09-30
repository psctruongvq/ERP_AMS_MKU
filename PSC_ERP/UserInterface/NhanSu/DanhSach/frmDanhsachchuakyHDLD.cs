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
    public partial class frmDanhsachchuakyHDLD : Form
    {
        DanhsachNVTheoHDList _Dsnhanvien = DanhsachNVTheoHDList.NewDanhsachNVTheoHDList();
        BoPhanList _BophanList = BoPhanList.NewBoPhanList();
        public frmDanhsachchuakyHDLD()
        {
            InitializeComponent();
            Load_Source();
        }

        #region"Load"
        private void Load_Source()
        {
            try
            {
                _BophanList = BoPhanList.GetBoPhanList();
                BindS_bophan.DataSource = _BophanList;
                if (cmbu_Bophan.Value == null)
                {
                    _Dsnhanvien = DanhsachNVTheoHDList.GetNhanvien_ChuakyHDByNgay(Convert.ToDateTime(dtp_vaoTungay.Value), Convert.ToDateTime(dtp_VaoDenngay.Value));
                    BindS_DsNhanvien.DataSource = _Dsnhanvien;
                    lblTSo.Text = "Tổng Số : " + _Dsnhanvien.Count;
                }
                else
                {
                    _Dsnhanvien = DanhsachNVTheoHDList.GetNhanvien_ChuakyHD((int)cmbu_Bophan.Value, Convert.ToDateTime(dtp_vaoTungay.Value), Convert.ToDateTime(dtp_VaoDenngay.Value));
                    BindS_DsNhanvien.DataSource = _Dsnhanvien;
                    lblTSo.Text = "Tổng Số : " + _Dsnhanvien.Count;
                }
            }
            catch (ApplicationException)
            {

            }
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_Bophan.DisplayLayout.Bands[0],
             new string[2] { "Tenbophan", "mabophan" },
             new string[2] { "Bộ Phận", "Mã bộ phận" },
             new int[2] { cmbu_Bophan.Width, 90 },
             new Control[2] { null, null },
             new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
             new bool[2] { false, false });
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;
        }

        private void grdu_DSNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CardID"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaChucDanh"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["HinhThucHDLD"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TuNgay"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DenNgay"].Hidden = true;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQlNhanvien"].Header.Caption = "Mã Số";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQlNhanvien"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQlNhanvien"].Width = 120;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.Caption = "Họ Tên";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].Width = 250;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellActivation = Activation.NoEdit;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayVaolam"].Header.Caption = "Ngày Vào";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayVaolam"].Width = 120;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayVaolam"].CellActivation = Activation.NoEdit;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Width = 120;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].CellActivation = Activation.NoEdit;


            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQlNhanvien"].Header.VisiblePosition = 1;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.VisiblePosition = 2;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayVaolam"].Header.VisiblePosition = 3;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 4;


            foreach (UltraGridColumn col in this.grdu_DSNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }






        }
        #endregion

        #region "Event"

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Source();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.Danhsach_NV_ChuakyHD();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_tblnsDSchuakyHD";
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsDSchuakyHD;1";

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

        private void frmDanhsachchuakyHDLD_Load(object sender, EventArgs e)
        {
            dtp_VaoDenngay.Value=DateTime.Now;
            dtp_vaoTungay.Value = Convert.ToDateTime(dtp_VaoDenngay.Value).AddMonths(-1);
        }

    }
}