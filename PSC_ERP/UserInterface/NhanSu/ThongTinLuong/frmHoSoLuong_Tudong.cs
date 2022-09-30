using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Csla;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;

namespace PSC_ERP
{
    public partial class frmHoSoLuong_Tudong : Form
    {
        BoPhanList _BophanList;
        HoSoLuongList _DSLuong;
        public frmHoSoLuong_Tudong()
        {
            InitializeComponent();
            this.Load_Source();
        }

        #region Load
        private void frmHoSoLuong_Tudong_Load(object sender, EventArgs e)
        {
            dtpu_Denngay.Value = DateTime.Now;
        }

        private void cmbu_bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_bophan.DisplayLayout.Bands[0],
            new string[2] { "Tenbophan", "mabophan" },
            new string[2] { "Bộ phận", "Mã số" },
            new int[2] { cmbu_bophan.Width, 90 },
            new Control[2] { null, null },
            new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[2] { false, false });
                cmbu_bophan.DisplayLayout.Bands[0].Columns["Tenbophan"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_bophan.DisplayLayout.Bands[0].Columns["mabophan"].Hidden = true;
        }

        private void grd_DanhSachNV_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["NgayKetthuc"].Hidden = true;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["MangachluongKD"].Hidden = true;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["mabacluongKD"].Hidden = true;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["HesoluongKD"].Hidden = true;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Manhanvien"].Hidden = true;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["mahesoluong"].Hidden = true;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["mangachluongcb"].Hidden = true;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["mabacluongcb"].Hidden = true;

            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["MaQlNhanVien"].Header.Caption = "Mã Số";
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["TennhanVien"].Header.Caption = "Họ Tên";
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["NgayBatdau"].Header.Caption = "Ngày Hưởng Hệ Số";
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["maqlngachluongCB"].Header.Caption = "Ngạch Lương";
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["maqlbacluongcb"].Header.Caption = "Bậc Lương";
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["HesoluongCb"].Header.Caption = "Hệ Số";
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Ngayvaonganh"].Header.Caption = "Ngày Vào";
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Tenchucvu"].Header.Caption = "Chức Vụ";

            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["MaQlNhanVien"].Header.VisiblePosition = 1;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["TennhanVien"].Header.VisiblePosition = 2;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["NgayBatdau"].Header.VisiblePosition = 3;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["maqlngachluongCB"].Header.VisiblePosition = 4;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["maqlbacluongcb"].Header.VisiblePosition = 5;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["HesoluongCb"].Header.VisiblePosition = 6;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Ngayvaonganh"].Header.VisiblePosition = 7;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Tenchucvu"].Header.VisiblePosition = 8;

            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["MaQlNhanVien"].Width = 120;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["TennhanVien"].Width = 170;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["NgayBatdau"].Width = 150;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["maqlngachluongCB"].Width = 120;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["maqlbacluongcb"].Width = 120;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["HesoluongCb"].Width=100;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Ngayvaonganh"].Width = 100;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Tenchucvu"].Width = 100;

            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["MaQlNhanVien"].CellActivation = Activation.NoEdit;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["TennhanVien"].CellActivation = Activation.NoEdit;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["NgayBatdau"].CellActivation = Activation.NoEdit;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["maqlngachluongCB"].CellActivation = Activation.NoEdit;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["maqlbacluongcb"].CellActivation = Activation.NoEdit;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["HesoluongCb"].CellActivation = Activation.NoEdit;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Ngayvaonganh"].CellActivation = Activation.NoEdit;
            grd_DanhSachNV.DisplayLayout.Bands[0].Columns["Tenchucvu"].CellActivation = Activation.NoEdit;

            foreach (UltraGridColumn col in this.grd_DanhSachNV.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Black;
                if (col.DataType.ToString() == "System.Datetime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "#.##";
                }
            }

        }

        private void Load_Source()
        {
            _BophanList = BoPhanList.GetBoPhanList();
            BindS_BoPhan.DataSource = _BophanList;
        }

        private void Load_Nguon()
        {
            if (chkAll.Checked)
            {
                if (cmbu_bophan.ActiveRow != null)
                {
                    if (txt_NV.Text == string.Empty)
                    {
                        _DSLuong= HoSoLuongList.GetHoSoLuongListByBoPhanAll((int)cmbu_bophan.Value);
                        BindS_DanhSach.DataSource = _DSLuong;
                        lblTSo.Text = "Tổng Số : " + _DSLuong.Count;
                        if (!chkChon.Visible)
                        {
                            chkChon.Visible = true;
                        }
                    }
                    else
                    {
                        _DSLuong = HoSoLuongList.GetHoSoLuongListByNhanVienAll((int)cmbu_bophan.Value, txt_NV.Text);
                        BindS_DanhSach.DataSource = _DSLuong;
                        lblTSo.Text = "Tổng Số : " + _DSLuong.Count;
                        if (!chkChon.Visible)
                        {
                            chkChon.Visible = true;
                        }
                    }
                }
            }
            else
            {
                if (cmbu_bophan.ActiveRow != null)
                {
                    if (txt_NV.Text == string.Empty)
                    {
                        _DSLuong = HoSoLuongList.GetHoSoLuongListByBoPhan((int)cmbu_bophan.Value);
                        BindS_DanhSach.DataSource = _DSLuong;
                        lblTSo.Text = "Tổng Số : " + _DSLuong.Count;
                        if (!chkChon.Visible)
                        {
                            chkChon.Visible = true;
                        }
                    }
                    else
                    {
                        _DSLuong = HoSoLuongList.GetHoSoLuongListByNhanVien((int)cmbu_bophan.Value, txt_NV.Text);
                        BindS_DanhSach.DataSource = _DSLuong;
                        lblTSo.Text = "Tổng Số : " + _DSLuong.Count;
                        if (!chkChon.Visible)
                        {
                            chkChon.Visible = true;
                        }
                    }
                }
            }
        }
        #endregion

        #region Event
        private void tlslblLuu_Click(object sender, EventArgs e)
        {

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {

                ReportDocument Report = new Report.HoSoLuong();
                SqlCommand command = new SqlCommand();
                DataSet dataset = new DataSet();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_DanhSachHSOLuongHientai";
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_DanhSachHSOLuongHientai;1";
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

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            long manhanvien=0;
            DialogResult = MessageBox.Show(this, "Chương Trình Sẽ Tiến Hành Xét Nâng Bậc Cho Các Nhân Viên Được Chọn Căn Cứ Vào Ngày Hưởng Và Thời Gian Nâng Bậc Của Bậc Hiện Tại. Thực Hiện Thao Tác (Yes/No)?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < _DSLuong.Count; i++)
                {
                    if (_DSLuong[i].Chon)
                    {
                        try
                        {
                            manhanvien = _DSLuong[i].MaNhanVien;
                            HoSoLuong.NangBac(manhanvien, DateTime.Parse(dtpu_Denngay.Value.ToString()).ToString("yyyy-MM-dd"));
                        }
                        catch (ApplicationException)
                        {

                        }

                    }
                }
            }
        }

        private void tlslblXem_Click(object sender, EventArgs e)
        {
            this.TaoDanhSachHSLuong();
            this.Load_Nguon();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            this.Load_Nguon();
        }

        private void chkChon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkChon.Checked)
            {
                for (int i = 0; i <= _DSLuong.Count - 1; i++)
                {
                    _DSLuong[i].Chon = true;
                }
            }
            else
            {
                for (int i = 0; i <= _DSLuong.Count - 1; i++)
                {
                    _DSLuong[i].Chon = false;
                }
            }
        }
        #endregion

        #region Process
        private void NangLuongTheoBac()
        {

        }
        private void TaoDanhSachHSLuong()
        {
            HoSoLuong.TaoDanhsach();
        }

        #endregion
    }
}