using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using ERP_Library;
   using ERP_Library.ThanhToan;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmBaoCaoNangLuong : Form
    {
        BoPhanList _BoPhanList;
        int maBophan = 0; long maNhanVien = 0;
      
        int userID = 0;
        DateTime ngayDenHan = DateTime.Today.Date;
        int maKyTinhLuong = 0;
        int tuKy = 0; int denKy = 0;
        string tenDanhSach = string.Empty;
        string tenNguoiLap = string.Empty;
        string _tenNguoiLap = string.Empty;
        string tenBanPhuTrach = string.Empty;
        string _tenBanPhuTrach = string.Empty;
        string tenThuTruong = string.Empty;
        string _tenThuTruong = string.Empty;
        string _tenLoaiNV = string.Empty;
        string _tenKieuNangLuong = string.Empty;

        KyTinhLuongList _kyTinhLuongList;        
       
        TTNhanVienRutGonList _nhanVienList;
       
        DateTime tuNgay=DateTime.Today.Date;
        DateTime denNgay = DateTime.Today.Date;
        int kieuNangLuong = 0;
        int kieuNhanVien = 0;

        public frmBaoCaoNangLuong()
        {
            InitializeComponent();
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        {
            _BoPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan itemaddBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _BoPhanList.Insert(0, itemaddBoPhan);
            BindS_BoPhan.DataSource = _BoPhanList;

        

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            cmbNguoiLap.Items.Add(0, "Không Có");
           
               foreach (ERP_Library.NguoiKyChild r in ERP_Library.NguoiKyList.GetNguoiKyList())
            {
                cmbNguoiLap.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
           
            }
               foreach (ERP_Library.DanhSachDenHanNangLuong r in ERP_Library.DanhSachDenHanNangLuongList.GetDanhSachDenHanNangLuongListByThang())
               {
                   cbDanhSach.Items.Add(r.TenDanhSach);
               }
            if (ERP_Library.Security.CurrentUser.IsAdmin)
                userID = 0;
            else
                userID = ERP_Library.Security.CurrentUser.Info.UserID;

        
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            SqlCommand command;
            DataSet dataset;
            ReportDocument Report;
            frmHienThiReport dlg;
            SqlDataAdapter adapter;
            DataTable table;
            if (treeReport.SelectedNode.Name == "Node2")
            {
                if (ngayDenHan.Day != 31 || ngayDenHan.Month != 12)
                {
                    MessageBox.Show("Vui lòng chọn ngày đến hạn là ngày 31/12", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            switch (treeReport.SelectedNode.Name)
            {
                case "Node1":
                    Report = new Report.rptDanhSachDenHanNangLuong();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Report_SelecttblnsDanhSachDenHanNangLuongsAll";

                    command.Parameters.AddWithValue("@KieuNangLuong", kieuNangLuong);
                    command.Parameters.AddWithValue("@LoaiNV", kieuNhanVien);
                    command.Parameters.AddWithValue("@TenDanhSach", tenDanhSach);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "Report_SelecttblnsDanhSachDenHanNangLuongsAll;1";

                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tenDanhSach", tenDanhSach);
                    Report.SetParameterValue("_loaiNV", _tenLoaiNV);
                    Report.SetParameterValue("_KieuNangLuong", _tenKieuNangLuong);
                    Report.SetParameterValue("_nguoiLap", tenNguoiLap);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    break;
                case "Node2":
                    Report = new Report.rptDanhSachNangLuongTruocHan();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachNangLuongTruocHan";

                    command.Parameters.AddWithValue("@NgayDenHan", ngayDenHan);                   
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachNangLuongTruocHan;1";

                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tenDanhSach", tenDanhSach);
                    Report.SetParameterValue("_loaiNV", _tenLoaiNV);
                    Report.SetParameterValue("_KieuNangLuong", _tenKieuNangLuong);
                    Report.SetParameterValue("_nguoiLap", tenNguoiLap);
                    Report.SetParameterValue("_ngayDeNghi", ngayDenHan.Date);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    break;
                case "Node3":
                    Report = new Report.rptDanhSachNangLuongCoBanTruocHan();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachNangLuongCoBanTruocHan";

                    command.Parameters.AddWithValue("@NgayDenHan", ngayDenHan);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachNangLuongCoBanTruocHan;1";

                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tenDanhSach", tenDanhSach);
                    Report.SetParameterValue("_loaiNV", _tenLoaiNV);
                    Report.SetParameterValue("_KieuNangLuong", _tenKieuNangLuong);
                    Report.SetParameterValue("_nguoiLap", tenNguoiLap);
                    Report.SetParameterValue("_ngayDeNghi", ngayDenHan.Date);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    break;
                case "Node4":
                    Report = new Report.rptDanhSachNangLuongBaoHiemTruocHan();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachNangLuongBaoHiemTruocHan";

                    command.Parameters.AddWithValue("@NgayDenHan", ngayDenHan);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachNangLuongBaoHiemTruocHan;1";

                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tenDanhSach", tenDanhSach);
                    Report.SetParameterValue("_loaiNV", _tenLoaiNV);
                    Report.SetParameterValue("_KieuNangLuong", _tenKieuNangLuong);
                    Report.SetParameterValue("_nguoiLap", tenNguoiLap);
                    Report.SetParameterValue("_ngayDeNghi", ngayDenHan.Date);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    break;
                case "Node5":
                    Report = new Report.rptDanhSachNangLuong_BaoHiem_VuViecTruocHan();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_DanhSachNangLuong_LuongBaoHiemVuViecTruocHan";

                    command.Parameters.AddWithValue("@NgayDenHan", ngayDenHan);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_DanhSachNangLuong_LuongBaoHiemVuViecTruocHan;1";

                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tenDanhSach", tenDanhSach);
                    Report.SetParameterValue("_loaiNV", _tenLoaiNV);
                    Report.SetParameterValue("_KieuNangLuong", _tenKieuNangLuong);
                    Report.SetParameterValue("_nguoiLap", tenNguoiLap);
                    Report.SetParameterValue("_ngayDeNghi", ngayDenHan.Date);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    break;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.Value != null)
            {
                maBophan = Convert.ToInt32(cmbu_Bophan.Value);
            }
            ComboChanged();
        }

        private void cbNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (cbNhanVien.Value != null)
            {
                maNhanVien = Convert.ToInt64(cbNhanVien.Value);
            }            
        }
        private void ComboChanged()
        {
            _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByBoPhanNhanVien(maBophan, maNhanVien);
            TTNhanVienRutGon _nhanVienThem = TTNhanVienRutGon.NewTTNhanVienRutGon(0, "Tất Cả");
            _nhanVienList.Insert(0, _nhanVienThem);
            this.bindingSource2_nhanVien.DataSource = _nhanVienList;
        }

       

       

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (treeReport.SelectedNode.Name)
            {
                case "Node1":
                    dateTimePicker_NgayLap.Enabled = false;
                    cbDanhSach.Enabled = true;
                    break;
                case "Node2":
                    dateTimePicker_NgayLap.Enabled = true;
                    cbDanhSach.Enabled = false;
                    cmbLoaiNV.Value = 1;
                    break;
                case "Node3":
                    dateTimePicker_NgayLap.Enabled = true;
                    cbDanhSach.Enabled = false;
                    cmbLoaiNV.Value = 2;
                    cbKieuNangLuong.Value = 2;
                    break;
                case "Node4":
                    dateTimePicker_NgayLap.Enabled = true;
                    cbDanhSach.Enabled = false;
                    cmbLoaiNV.Value = 2;
                    cbKieuNangLuong.Value = 3;
                    break;
                case "Node5":
                    dateTimePicker_NgayLap.Enabled = true;
                    cbDanhSach.Enabled = false;
                    cmbLoaiNV.Value = 2;
                    cbKieuNangLuong.Value = 1;
                    break;
                default:
                    dateTimePicker_NgayLap.Enabled = true;
                    cbDanhSach.Enabled = true;
                    break;
                    
            }
        }

      

      

        private void cmbNguoiLap_ValueChanged(object sender, EventArgs e)
        {
            if (cmbNguoiLap.Value != null && (int)cmbNguoiLap.Value != 0)
            {
                _tenNguoiLap = "Tên Người Lập\r\n(Ký, họ tên)";
                tenNguoiLap = cmbNguoiLap.Text;
            }
            else if ((int)cmbNguoiLap.Value == 0)
            {
                _tenNguoiLap = string.Empty;
                tenNguoiLap = string.Empty;
            }
        }

    
    
      

        private void dateTimePicker_DenNgay_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker_TuNgay_ValueChanged(object sender, EventArgs e)
        {
        }
      

     
        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);

        }

        private void cbNguon_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void cbNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
        }

        private void cmbLoaiNV_ValueChanged(object sender, EventArgs e)
        {
            kieuNhanVien = Convert.ToInt32(cmbLoaiNV.Value);

            if (kieuNhanVien == 1)
            {
                cbKieuNangLuong.Value = 1;
                cbKieuNangLuong.Enabled = false;
            }
            else
            {
                cbKieuNangLuong.Enabled = true;
            }
            _tenLoaiNV = cmbLoaiNV.Text;
        }

        private void cbKieuNangLuong_ValueChanged(object sender, EventArgs e)
        {
            kieuNangLuong = Convert.ToInt32(cbKieuNangLuong.Value);
            _tenKieuNangLuong = cbKieuNangLuong.Text;
        }

        private void cbDanhSach_ValueChanged(object sender, EventArgs e)
        {
            if (cbDanhSach.Value != null)
            {
                tenDanhSach = cbDanhSach.Value.ToString();
            }
            else
                tenDanhSach = string.Empty;

        }

        private void dateNgayDenHan_ValueChanged(object sender, EventArgs e)
        {
            ngayDenHan = Convert.ToDateTime(dateTimePicker_NgayLap.Value.Date);
          
        }

      
    }
}