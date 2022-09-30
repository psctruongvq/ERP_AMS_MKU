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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace PSC_ERP
{
    public partial class frmDanhSachNhanVienBiKyLuat : Form
    {
        #region Properties
        CongTyList _CongTyList;
        BoPhanList _PhongBanList;
        ToList _ToList;
        KyLuatTheoNhanVienList _KyLuatTheoNhanVienList;
        Util _Util = new Util();
        static int _MaChiNhanh = 0;
        static int _MaPhongBan = 0;
        static int _MaTo = 0;
        static DateTime _TuNgay = DateTime.Today;
        static DateTime _DenNgay = DateTime.Today;
        #endregion

        #region Events
        public frmDanhSachNhanVienBiKyLuat()
        {
            InitializeComponent();
            domainUpDown_Nam.Text = DateTime.Today.Year.ToString();

            KhoiTao_Combo();

            tlslblTim.Visible = false;
            toolStripSeparator4.Visible = false;

            tlslblLuu.Visible = false;
            toolStripSeparator2.Visible = false;

            tlslblXoa.Visible = false;
            toolStripSeparator3.Visible = false;
        }

        private void KhoiTao_Combo()
        {
            _CongTyList = CongTyList.GetCongTyList();
            ChiNhanh_BindingSource.DataSource = _CongTyList;
        }

        private void DuLieuComBo()
        {
            _MaChiNhanh = Convert.ToInt32(cmbu_ChiNhanh.Value);
            _MaPhongBan = Convert.ToInt32(cmbu_PhongBan.Value);
            if (cmbu_To.Value != null)
                _MaTo = Convert.ToInt32(cmbu_To.Value);
            _TuNgay = Convert.ToDateTime(dtmpu_TuNgay.Value);
            _DenNgay = Convert.ToDateTime(dtmpu_DenNgay.Value);
        }

        private void XemDuLieu(int MaChiNhanh, int MaPhongBan, int MaTo, DateTime TuNgay, DateTime DenNgay)
        {
            _KyLuatTheoNhanVienList = KyLuatTheoNhanVienList.GetKyLuatTheoNhanVienList_To_Nam(MaChiNhanh, MaPhongBan, MaTo, TuNgay, DenNgay);
            DSNV_KyLuat_BindingSource.DataSource = _KyLuatTheoNhanVienList;
            
            lbl_TongSo.Text = "Số lượng nhân viên: " + _KyLuatTheoNhanVienList.Count;
            if (_KyLuatTheoNhanVienList.Count == 0)
                MessageBox.Show(this, "Không Có Dữ Liệu", _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            frmKyLuatTungNhanVien f = new frmKyLuatTungNhanVien();
            f.Show();
        }

        private void tlslblLamTuoi_Click(object sender, EventArgs e)
        {
            DuLieuComBo();
            XemDuLieu(_MaChiNhanh, _MaPhongBan, _MaTo, _TuNgay, _DenNgay);
        }

        private void grdu_DSNhanVien_DoubleClick(object sender, EventArgs e)
        {
            frmKyLuatTungNhanVien _frmKyLuatTungNhanVien = new frmKyLuatTungNhanVien((long)grdu_DSNhanVien.ActiveRow.Cells["MaNhanVien"].Value);
            if (_frmKyLuatTungNhanVien.ShowDialog(this) != DialogResult.OK)
            {
                DuLieuComBo();
                XemDuLieu(_MaChiNhanh, _MaPhongBan, _MaTo, _TuNgay,_DenNgay);
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            DuLieuComBo();
            ReportDocument Report = new Report.DanhSach_CBNV_BiKyLuat();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_REPORT_nsDanhSachNhanVienBiKyLuat";
            command.Parameters.AddWithValue("@MaChiNhanh", _MaChiNhanh);
            command.Parameters.AddWithValue("@MaPhongBan", _MaPhongBan);
            command.Parameters.AddWithValue("@MaTo", _MaTo);
            command.Parameters.AddWithValue("@TuNgay", _TuNgay);
            command.Parameters.AddWithValue("@DenNgay", _DenNgay);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_REPORT_nsDanhSachNhanVienBiKyLuat;1";

            // store thu 2
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

        private void cmbu_ChiNhanh_ValueChanged(object sender, EventArgs e)
        {
            int MaChiNhanh = 0;
            if (cmbu_ChiNhanh.Value != null)
            {
                MaChiNhanh = Convert.ToInt32(cmbu_ChiNhanh.Value);
            }
            if (MaChiNhanh != 0)
            {
                _PhongBanList = BoPhanList.GetBoPhanList(MaChiNhanh);

                BoPhan _phongBan = BoPhan.NewBoPhan(0, "Chọn tất cả");
                _PhongBanList.Insert(0, _phongBan);

                PhongBan_BindingSource.DataSource = _PhongBanList;
                cmbu_PhongBan.Value = 0;

                _ToList = ToList.NewToList();
                To _to = To.NewTo(0, "Chọn tất Cả");
                _ToList.Insert(0, _to);
                To_BindingSource.DataSource = _ToList;
                cmbu_To.Value = 0;
            }
            else
            {
                PhongBan_BindingSource.DataSource = BoPhanList.NewBoPhanList();
            }
        }

        private void cmbu_PhongBan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_PhongBan.Value != null)
            {
                _ToList = ToList.GetToListChung((int)cmbu_ChiNhanh.Value, (int)cmbu_PhongBan.Value);
                To _to = To.NewTo(0, "Chọn tất Cả");
                _ToList.Insert(0, _to);
                To_BindingSource.DataSource = _ToList;
                cmbu_To.Value = 0;
            }
        }

        private void cmbu_PhongBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbu_ChiNhanh.Value != null && cmbu_PhongBan.Value!=null)
                {
                    XemDuLieu((int)cmbu_ChiNhanh.Value, (int)cmbu_PhongBan.Value, 0, Convert.ToDateTime(dtmpu_TuNgay.Value), Convert.ToDateTime(dtmpu_DenNgay.Value));
                }
            }
        }

        private void cmbu_ChiNhanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbu_ChiNhanh.Value != null)
                {
                    XemDuLieu((int)cmbu_ChiNhanh.Value, 0, 0, Convert.ToDateTime(dtmpu_TuNgay.Value), Convert.ToDateTime(dtmpu_DenNgay.Value));
                }
            }
        }

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            XemDuLieu((int)cmbu_ChiNhanh.Value, (int)cmbu_PhongBan.Value, (int)cmbu_To.Value, Convert.ToDateTime(dtmpu_TuNgay.Value), Convert.ToDateTime(dtmpu_DenNgay.Value));
        }

        private void cmbu_To_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cmbu_To.Value != null)
                {
                    XemDuLieu((int)cmbu_ChiNhanh.Value, (int)cmbu_PhongBan.Value, (int)cmbu_To.Value, Convert.ToDateTime(dtmpu_TuNgay.Value), Convert.ToDateTime(dtmpu_DenNgay.Value));
                }
            }
        }
        #endregion

        #region grdu_DSNhanVien_InitializeLayout
        private void grdu_DSNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            #region Header Lưới
            grdu_DSNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaHinhThucKyLuat"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaKyLuat"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayLapQuyetDinh"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaCapQuyetDinh"].Hidden = true;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = true;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenHinhThucKyLuat"].Header.Caption = "Hình Thức Khen Thưởng";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenCapQuyetDinh"].Header.Caption = "Cấp Quyết Định";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.Caption = "Ngày Cấp";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TGBDKyLuat"].Header.Caption = "Danh Hiệu";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TGKTKyLuat"].Header.Caption = "Danh Hiệu";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NguoiKy"].Header.Caption = "Người Cấp";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GiamLuongDenHan"].Header.Caption = "Giảm Lương (Tháng)";
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 150;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;

            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenHinhThucKyLuat"].Header.VisiblePosition = 1;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TenCapQuyetDinh"].Header.VisiblePosition = 2;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 3;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NgayQuyetDinh"].Header.VisiblePosition = 4;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TGBDKyLuat"].Header.VisiblePosition = 5;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["TGKTKyLuat"].Header.VisiblePosition = 6;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["NguoiKy"].Header.VisiblePosition = 7;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GiamLuongDenHan"].Header.VisiblePosition = 8;
            grdu_DSNhanVien.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 9;
            foreach (UltraGridColumn col in grdu_DSNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = Color.Navy;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
            }
            //this.grdu_DSNhanVien.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            //this.grdu_DSNhanVien.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            #endregion
        }
        #endregion
    }
}