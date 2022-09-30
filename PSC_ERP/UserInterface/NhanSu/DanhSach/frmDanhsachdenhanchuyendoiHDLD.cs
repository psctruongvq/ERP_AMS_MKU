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
    public partial class frmDanhsachdenhanchuyendoiHDLD : Form
    {
        HDLaoDongList _Dsnhanvien = HDLaoDongList.NewHDLaoDongList();
        BoPhanList _BophanList = BoPhanList.NewBoPhanList();
        HinhThucHopDongList _HinhThucHopDongList = HinhThucHopDongList.NewHinhThucHopDongList();
        public frmDanhsachdenhanchuyendoiHDLD()
        {
            InitializeComponent();
            Load_source();
        }

        #region Load
        private void Load_source()
        {
            try
            {
                _BophanList = BoPhanList.GetBoPhanList();
                BindS_bophan.DataSource = _BophanList;
                _HinhThucHopDongList = HinhThucHopDongList.GetHinhThucHopDongList();
                BindS_HinhthucHD.DataSource = _HinhThucHopDongList;

                if (cmbu_Bophan.Value != null)
                {
                    if (cmbu_HinhThucHD.Value == null)
                    {
                        _Dsnhanvien = HDLaoDongList.GetHDLaoDong_denhanchuyendoiHD((int)cmbu_Bophan.Value, Convert.ToDateTime(dtp_Denngay.Value));
                        BindS_DsNhanvien.DataSource = _Dsnhanvien;
                    }
                    else
                    {
                        _Dsnhanvien = HDLaoDongList.GetHDLaoDong_denhanchuyendoiHD((int)cmbu_HinhThucHD.Value, Convert.ToDateTime(dtp_Denngay.Value));
                        BindS_DsNhanvien.DataSource = _Dsnhanvien;
                    }
                    lblTSo.Text = "Tổng Số : " + _Dsnhanvien.Count;
                }
            }
            catch (ApplicationException)
            {

            }
        }
        private void cmbu_HinhThucHD_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_HinhThucHD.DisplayLayout.Bands[0],
             new string[2] { "Tenhinhthuchopdong", "Mahinhthuchopdong" },
             new string[2] { "Hình Thức Hợp Đồng", "Mã hình thức" },
             new int[2] { cmbu_HinhThucHD.Width, 90 },
             new Control[2] { null, null },
             new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
             new bool[2] { false, false });
            cmbu_HinhThucHD.DisplayLayout.Bands[0].Columns["Tenhinhthuchopdong"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_HinhThucHD.DisplayLayout.Bands[0].Columns["mahinhthuchopdong"].Hidden = true;
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

        private void frmDanhsachdenhanchuyendoiHDLD_Load(object sender, EventArgs e)
        {
            dtp_Denngay.Value = DateTime.Now;
        }

        private void grdu_DSNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaHopDongLaoDong"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaNguoiKy"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaChucVu"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaChucDanh"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DieuKhoanKhac"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["ThoiGianLamViec"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DungCuLamViec"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["PhuongTienDiLamViec"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CheDoDaoTao"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Mucluong"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Hinhthuctraluong"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaHinhThucHopDong"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["HeSoBHXH"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["HeSoBHYT"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SoTienCongDoan"].Hidden = true;



            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenHinhThucHD"].Header.Caption = "Loại Hợp Đồng";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenHinhThucHD"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenHinhThucHD"].Width = 120;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.Caption = "Họ Tên";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].Width = 120;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tungay"].Header.Caption = "Từ Ngày";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tungay"].Width = 95;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tungay"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Denngay"].Header.Caption = "Đến Ngày";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Denngay"].Width = 95;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Denngay"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.Caption = "Số Hợp Đồng";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SoHopDong"].Width = 95;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SoHopDong"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayKy"].Header.Caption = "Ngày Ký";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayKy"].Width = 95;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayKy"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 200;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgheNghiep"].Header.Caption = "Nghề Nghiệp";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgheNghiep"].Width = 100;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgheNghiep"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].Header.Caption = "Công Việc Phải Làm";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].Width = 150;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].CellActivation = Activation.NoEdit;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenHinhThucHD"].Header.VisiblePosition = 0;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].Header.VisiblePosition = 1;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Tungay"].Header.VisiblePosition = 2;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Denngay"].Header.VisiblePosition = 3;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SoHopDong"].Header.VisiblePosition = 4;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayKy"].Header.VisiblePosition = 5;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 6;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgheNghiep"].Header.VisiblePosition = 7;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["CongviecphaiLam"].Header.VisiblePosition = 8;

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
            //this.grdu_DSNhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.grdu_DSNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
        }
        #endregion

        #region Event
        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            this.Load_source();
        }

        private void dtp_Denngay_Leave(object sender, EventArgs e)
        {
            this.Load_source();
        }

        private void cmbu_HinhThucHD_ValueChanged(object sender, EventArgs e)
        {
            this.Load_source();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_source();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                this.InDSALL();
            }
        }
        #endregion

        #region Process
        private void InDSALL()
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_tblnsDSchuyendoiHD";
            command.Parameters.AddWithValue("@denngay", dtp_Denngay.Value);
            command.Parameters.AddWithValue("@mabophan", (int)cmbu_Bophan.Value);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsDSchuyendoiHD;1";

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
        private void InDSByBoPhan()
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_report_tblnsDSchuyendoiHDByBoPhan";
            command.Parameters.AddWithValue("@denngay", dtp_Denngay.Value);
            command.Parameters.AddWithValue("@MaboPhan", cmbu_Bophan.Value);
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_report_tblnsDSchuyendoiHDByBoPhan;1";

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

    }
}