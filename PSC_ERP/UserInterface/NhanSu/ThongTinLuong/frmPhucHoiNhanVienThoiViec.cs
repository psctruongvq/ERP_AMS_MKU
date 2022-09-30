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
    public partial class frmPhucHoiNhanVienThoiViec : Form
    {       
        BoPhanList _BoPhanList=BoPhanList.NewBoPhanList();
        ThongTinNhanVienTongHopList _ThongTinNVTH = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
        ThoiViecList _DSNghi = ThoiViecList.NewThoiViecList();
        TenNhanVienList _DSNVDanghi = TenNhanVienList.NewTenNhanVienList();
        Util _Util = new Util();
        public frmPhucHoiNhanVienThoiViec()
        {
            InitializeComponent();
            this.Load_Source();
        }

        #region Load
        private void frmPhucHoiNhanVienThoiViec_Load(object sender, EventArgs e)
        {
            dtpu_Ngayvao.Value = DateTime.Now;
            dtp_Denngay.Value = DateTime.Now;
            dtp_NgayTN.Value = DateTime.Now;
            dtpu_Ngayvao.Value = DateTime.Now;
            dtp_Tungay.Value = Convert.ToDateTime(dtp_Denngay.Value).AddMonths(-1);
        }

        private void Load_Source()
        {
            try
            {
                _BoPhanList = BoPhanList.GetBoPhanList();
                BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Tất Cả");
                _BoPhanList.Insert(0, _BoPhan);
                BindS_Bophan.DataSource = _BoPhanList;                
            }
            catch (ApplicationException)
            {

            }
        }

        private void Load_Nguon()
        {
            if (cmbu_Bophan.Value!=null)
            {
                try
                {
                    _DSNghi = ThoiViecList.GetThoiViecListChuaPhucHoiByNgay(Convert.ToDateTime(dtp_Tungay.Value), Convert.ToDateTime(dtp_Denngay.Value), (int)cmbu_Bophan.Value);
                    BindS_NVNghi.DataSource = _DSNghi;
                }
                catch (ApplicationException)
                {
                }
                gbx_QuaTrinhLuong.Text = "Danh Sách Nhân Viên Nghỉ Việc. Tổng Số : " + _DSNghi.Count;
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

        

        private void grdu_DanhSachNhanVienNghi_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["MaThoiViec"].Hidden = true;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["NgayKy"].Hidden = true;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["NguoiKy"].Hidden = true;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["MaChucVuNguoiKy"].Hidden = true;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["MaNguoiLap"].Hidden = true;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = true;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["MaNhanVien"].Hidden = true;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["MaLoaiQuyetDinh"].Hidden = true;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["MaLyDoThoiViec"].Hidden = true;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Check";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Số";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 170;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Header.Caption = "Loại Quyết Định Thôi Việc";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TenLyDoThoiViec"].Header.Caption = "Lý Do Thôi Việc";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.Caption = "Số Quyết Định";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.Caption = "Ngày Hiệu Lực";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TroCapThoiViec"].Header.Caption = "Trợ Cấp Thôi Việc";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TroCapKhac"].Header.Caption = "Trợ Cấp Khác";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TenLoaiQuyetDinh"].Header.VisiblePosition = 3;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TenLyDoThoiViec"].Header.VisiblePosition = 4;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["SoQuyetDinh"].Header.VisiblePosition = 5;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["NgayHieuLuc"].Header.VisiblePosition = 6;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TroCapThoiViec"].Header.VisiblePosition = 7;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["TroCapKhac"].Header.VisiblePosition = 8;
            grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 9;

            //foreach (UltraGridColumn col in this.grdu_DanhSachNhanVienNghi.DisplayLayout.Bands[0].Columns)
            //{
            //    col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            //    col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
            //    col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
            //}
          
            
        }
        #endregion

        #region Events
        private void tlslblPhucHoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbu_KieuPH.Value != null)
                {
                    if (cmbu_KieuPH.Value.ToString() == "1")
                    {
                        DialogResult = MessageBox.Show(this, "Phục Hồi Toàn Bộ Thông Tin Cho Những Nhân Viên Đã Chọn . Chương Trình Sẽ Thay Đổi Ngày Vào Và Ngày Tính Thâm Niên . Thực Hiện Thao Tác (Yes/No) ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (DialogResult == DialogResult.Yes)
                        {

                            for (int i = 0; i < grdu_DanhSachNhanVienNghi.Rows.Count; i++)
                            {
                                if ((bool)grdu_DanhSachNhanVienNghi.Rows[i].Cells["Check"].Value == true)
                                {
                                    ThoiViec.PhucHoiNVResetNgayThamnien((long)grdu_DanhSachNhanVienNghi.Rows[i].Cells["MaNhanVien"].Value, Convert.ToDateTime(dtpu_Ngayvao.Value), Convert.ToDateTime(dtp_NgayTN.Value));
                                }
                            }
                        }
                    }
                    else
                    {
                        DialogResult = MessageBox.Show(this, "Phục Hồi Toàn Bộ Thông Tin Cho Những Nhân Viên Đã Chọn. Thực Hiện Thao Tác (Yes/No) ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (DialogResult == DialogResult.Yes)
                        {
                            for (int i = 0; i < grdu_DanhSachNhanVienNghi.Rows.Count; i++)
                            {
                                if ((bool)grdu_DanhSachNhanVienNghi.Rows[i].Cells["Check"].Value == true)
                                {
                                    ThoiViec.PhucHoiNV((long)grdu_DanhSachNhanVienNghi.Rows[i].Cells["MaNhanVien"].Value);
                                }

                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show(this, "Chọn Kiểu Phục Hồi Nhân Viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show(this, "Phục Hồi Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Load_Source();
                this.Load_Nguon();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            ComboValueChanged();
        }
        private void ComboValueChanged()
        {
            if (cmbu_Bophan.Value != null)
            {
                _ThongTinNVTH = ThongTinNhanVienTongHopList.GetThongTinNhanVienNghiTongHopList_Bophan((int)cmbu_Bophan.Value, 0);
                BindS_NV.DataSource = _ThongTinNVTH;
            }
            this.Load_Nguon();
        }
        private void cmbu_Nhanvien_ValueChanged(object sender, EventArgs e)
        {
            this.Load_Nguon();
        }

        private void tlslblXem_Click(object sender, EventArgs e)
        {
            this.Load_Nguon();
        }

        #endregion     

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new Report.DanhSach_NV_NghiViec();
            DataSet dataset = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_Report_DanhsachNhanVienNghiViec";
            command.Parameters.AddWithValue("@Tungay",DateTime.Parse(dtp_Tungay.Value.ToString()).ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Denngay",DateTime.Parse(dtp_Tungay.Value.ToString()).ToString("yyyy-MM-dd"));
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_Report_DanhsachNhanVienNghiViec;1";

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

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            //frmMainNhanSu.LoadHelp(this, "Phuc hoi NV nghi viec");
        }

        private void frmPhucHoiNhanVienThoiViec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
               // frmMainNhanSu.LoadHelp(this, "Phuc hoi NV nghi viec");
            }
        }

        private void dtp_Tungay_ValueChanged(object sender, EventArgs e)
        {
            ComboValueChanged();
        }

        private void dtp_Denngay_ValueChanged(object sender, EventArgs e)
        {
            ComboValueChanged();
        }

        private void chkAlldanhsach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlldanhsach.Checked == true)
            {
                for (int i = 0; i < grdu_DanhSachNhanVienNghi.Rows.Count; i++)
                {
                    if (!grdu_DanhSachNhanVienNghi.Rows[i].Hidden == true)
                    {
                        grdu_DanhSachNhanVienNghi.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_DanhSachNhanVienNghi.Rows.Count; i++)
                {
                    grdu_DanhSachNhanVienNghi.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        #region Process
        #endregion

    }
}

