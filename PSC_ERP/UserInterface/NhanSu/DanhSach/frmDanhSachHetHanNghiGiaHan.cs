using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmDanhSachHetHanNghiGiaHan : Form
    {
        BoPhanList _BophanList = BoPhanList.NewBoPhanList();
        ThongTinNhanVienTongHopList _ThongTinNVTHList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        HinhThucNghiList _HinhthucNghi = HinhThucNghiList.NewHinhThucNghiList();
        QuaTrinhNghiList _QuaTrinhNghi = QuaTrinhNghiList.NewQuaTrinhNghiList();
        public frmDanhSachHetHanNghiGiaHan()
        {
            InitializeComponent();
            this.Load_Source();
        }
        #region Load
        private void frmDanhSachHetHanNghiGiaHan_Load(object sender, EventArgs e)
        {
            dtp_Denngay.Value = DateTime.Now;
        }

        private void  Load_Source()
        {
            try
            {
                _BophanList = BoPhanList.GetBoPhanList();
                BindS_BoPhan.DataSource = _BophanList;
                _HinhthucNghi = HinhThucNghiList.GetHinhThucNghiList();
                BindS_HTNghi.DataSource = _HinhthucNghi;
            }
            catch (ApplicationException)
            {

            }
        }

        private void Load_Nguon()
        {
            if (cmbu_HinhThucNghi.Value != null)
            {
                try
                {
                    if (cmbu_Bophan.Value == null)
                    {
                        _QuaTrinhNghi = QuaTrinhNghiList.GetHetHanNghiAll((int)cmbu_HinhThucNghi.Value, Convert.ToDateTime(dtp_Denngay.Value));
                        BindS_DSGiaHan.DataSource = _QuaTrinhNghi;
                    }
                    else
                    {
                        if (cmbu_NhanVien.Value != null)
                        {
                            _QuaTrinhNghi = QuaTrinhNghiList.GetHetHanNghiByNhanVien((int)cmbu_HinhThucNghi.Value, Convert.ToDateTime(dtp_Denngay.Value), (long)cmbu_NhanVien.Value);
                            BindS_DSGiaHan.DataSource = _QuaTrinhNghi;
                        }
                        else
                        {
                            _QuaTrinhNghi = QuaTrinhNghiList.GetHetHanNghiByBoPhan((int)cmbu_HinhThucNghi.Value, Convert.ToDateTime(dtp_Denngay.Value), (int)cmbu_Bophan.Value);
                            BindS_DSGiaHan.DataSource = _QuaTrinhNghi;
                        }
                    }
                }
                catch (ApplicationException)
                {

                }
                lblTSo.Text = "Tổng Số : " + _QuaTrinhNghi.Count; 
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

        private void cmbu_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_NhanVien.DisplayLayout.Bands[0],
             new string[2] { "MaQLNHanvien", "Tennhanvien" },
             new string[2] { "Mã Số", "Họ Tên" },
             new int[2] { 100, cmbu_NhanVien.Width - 100 },
             new Control[2] { null, null },
             new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
             new bool[2] { false, false });
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNHanvien"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_NhanVien.DisplayLayout.Bands[0].Columns["Tennhanvien"].CellAppearance.TextHAlign = HAlign.Left;

        }

        private void cmbu_HinhThucNghi_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(cmbu_HinhThucNghi.DisplayLayout.Bands[0],
               new string[2] { "TenHinhthucnghi", "Mahinhthucnghi" },
               new string[2] { "Hình Thức", "Mã ht" },
               new int[2] { cmbu_HinhThucNghi.Width, 90 },
               new Control[2] { null, null },
               new KieuDuLieu[2] { KieuDuLieu.Null, KieuDuLieu.Null },
               new bool[2] { false, false });
            cmbu_HinhThucNghi.DisplayLayout.Bands[0].Columns["TenHinhthucnghi"].CellAppearance.TextHAlign = HAlign.Left;
            cmbu_HinhThucNghi.DisplayLayout.Bands[0].Columns["Mahinhthucnghi"].Hidden = true;
        }

        private void grdu_DSNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQuaTrinhNghi"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaHinhThucNghi"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayNghi"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SoTienHuong"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TinhTrang"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SuDung"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["LuongTinh"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNguoiLap"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["Giahan"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SoGioNghi"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenHinhThucNghi"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TruChuyenCan"].Hidden = true;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Số";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 0;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Họ Tên";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 250;            
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TuNgay"].Header.Caption = "Từ Ngày";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TuNgay"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TuNgay"].Header.VisiblePosition = 2;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TuNgay"].Width = 100;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DenNgay"].Header.Caption = "Đến Ngày";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DenNgay"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DenNgay"].Header.VisiblePosition = 3;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["DenNgay"].Width = 100;
           
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["LyDo"].Header.Caption = "Lý Do";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["LyDo"].CellActivation = Activation.NoEdit;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["LyDo"].Header.VisiblePosition = 4;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["LyDo"].Width = 250;

            //grdu_DSNhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            //this.grdu_DSNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            foreach (UltraGridColumn col in this.grdu_DSNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
        }
        #endregion

        #region Event
        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                _ThongTinNVTHList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_Bophan((int)cmbu_Bophan.Value,0);
                BindS_NhanVien.DataSource = _ThongTinNVTHList;
            }
            this.Load_Nguon();
        }

        private void cmbu_NhanVien_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Nguon();
        }

        private void cmbu_HinhThucNghi_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Nguon();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            this.Load_Nguon();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (cmbu_HinhThucNghi.Value!=null)
            {
                ReportDocument Report = new Report.Danhsach_NV_HetHanGiaHan();
                SqlCommand command = new SqlCommand();
                DataSet dataset = new DataSet();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_tblnsQuaTrinhNghiHetHanAll";
                command.Parameters.AddWithValue("@denngay",Convert.ToDateTime(dtp_Denngay.Value));
                command.Parameters.AddWithValue("@mahinhthuc", (int)cmbu_HinhThucNghi.Value);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_Report_tblnsQuaTrinhNghiHetHanAll;1";
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
            
        }
        #endregion

        #region Process
        #endregion

    }
}