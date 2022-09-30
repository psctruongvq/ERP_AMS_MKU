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
    public partial class frmBaoCaoThuLao_DangPhi : Form
    {
        BoPhanList _BoPhanList;
        int maBophan = 0; long maNhanVien = 0;
      
        int userID = 0;
        
        int maKyTinhLuong = 0;
        int tuKy = 0; int denKy = 0;
        string tenNguoiLap = string.Empty;
        string _tenNguoiLap = string.Empty;
        string tenBanPhuTrach = string.Empty;
        string _tenBanPhuTrach = string.Empty;
        string tenThuTruong = string.Empty;
        string _tenThuTruong = string.Empty;
        KyTinhLuongList _kyTinhLuongList;        
       
        TTNhanVienRutGonList _nhanVienList;
       
        DateTime tuNgay=DateTime.Today.Date;
        DateTime denNgay = DateTime.Today.Date;
       

        public frmBaoCaoThuLao_DangPhi()
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
            cmbPTTaiChinh.Items.Add(0, "Không Có");
            cmbPTDonVi.Items.Add(0, "Không Có");
               foreach (ERP_Library.NguoiKyChild r in ERP_Library.NguoiKyList.GetNguoiKyList())
            {
                cmbNguoiLap.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
                cmbPTTaiChinh.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
                cmbPTDonVi.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
            }

            if (ERP_Library.Security.CurrentUser.IsAdmin && ERP_Library.Security.CurrentUser.Info.MaCongTy == 1)
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
            
            switch (treeReport.SelectedNode.Name)
            {
                case "Node0":
                     Report = new Report.ThuLaoChuongTrinh_DangPhiBoPhan();
                     command = new SqlCommand();
                     dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhiBoPhan";

                    command.Parameters.AddWithValue("@TuKy",tuKy);
                    command.Parameters.AddWithValue("@DenKy", denKy);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@MaBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.CommandTimeout = 0;
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhiBoPhan;1";

                    dataset.Tables.Add(table);
                    //
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);                    
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);                   
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tuKy", cbKyTinhLuong.Text);
                    Report.SetParameterValue("_denky", cbDenKy.Text);
                       dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    break;
                case "Node1":
                     Report = new Report.ThuLaoChuongTrinh_DangPhi();
                     command = new SqlCommand();
                     dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi";
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@TuKy",tuKy);
                    command.Parameters.AddWithValue("@DenKy",denKy);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.CommandTimeout = 0;
                    // command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi;1";

                    dataset.Tables.Add(table);
                    //
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tuKy", cbKyTinhLuong.Text);
                    Report.SetParameterValue("_denky", cbDenKy.Text);
                     dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node2":
                     Report = new Report.ChiTietDangPhiNhanVien();
                     command = new SqlCommand();
                     dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_SelectChiTietDangPhiNhanVien";
                    command.Parameters.AddWithValue("@TuKy", tuKy);
                    command.Parameters.AddWithValue("@DenKy", denKy);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.CommandTimeout = 0;
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_SelectChiTietDangPhiNhanVien;1";
                    dataset.Tables.Add(table);

                    //
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tuKy", cbKyTinhLuong.Text);
                    Report.SetParameterValue("_denky", cbDenKy.Text);
                     dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node4":
                    Report = new Report.DangPhi_DieuChinh();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi_DieuChinh";
                    command.Parameters.AddWithValue("@TuKy", tuKy);
                    command.Parameters.AddWithValue("@DenKy", denKy);
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout = 0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi_DieuChinh;1";

                    dataset.Tables.Add(table);
                    //
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tuKy", cbKyTinhLuong.Text);
                    Report.SetParameterValue("_denky", cbDenKy.Text);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node5":
                    Report = new Report.ThuLaoChuongTrinh_DangPhiBoPhan_DieuChinh();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhiBoPhan_DieuChinh";
                    command.CommandTimeout=0;
                    command.Parameters.AddWithValue("@TuKy", tuKy);
                    command.Parameters.AddWithValue("@DenKy", denKy);
                    command.Parameters.AddWithValue("@MaBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);

                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhiBoPhan_DieuChinh;1";

                    dataset.Tables.Add(table);
                    //
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tuKy", cbKyTinhLuong.Text);
                    Report.SetParameterValue("_denky", cbDenKy.Text);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    break;
                case "Node6":
                    Report = new Report.ThuLaoChuongTrinh_DangPhiBoPhan_TongHop();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhiBoPhan_TongHop";
                    command.CommandTimeout=0;
                    command.Parameters.AddWithValue("@TuKy", tuKy);
                    command.Parameters.AddWithValue("@DenKy", denKy);
                    
                    command.Parameters.AddWithValue("@MaBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhiBoPhan_TongHop;1";

                    dataset.Tables.Add(table);
                    //
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("TenBPT", tenBanPhuTrach);
                    Report.SetParameterValue("BanPhuTrach", _tenBanPhuTrach);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tuKy", cbKyTinhLuong.Text);
                    Report.SetParameterValue("_denky", cbDenKy.Text);
                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();

                    break;
                case "Node7":
                    Report = new Report.ThuLaoChuongTrinh_DangPhi_TongHop();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi_TongHop";
                    command.Parameters.AddWithValue("@MaBoPhan", maBophan);
                    command.Parameters.AddWithValue("@TuKy", tuKy);
                    command.Parameters.AddWithValue("@DenKy", denKy);
                    command.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                    command.Parameters.AddWithValue("@MaBoPhanDangNhap", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                    // command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    command.CommandTimeout=0;
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "spd_SelecttblnsThuLaoChuongTrinh_ByTinhDangPhi_TongHop;1";

                    dataset.Tables.Add(table);
                    //
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("TenNguoiLap", tenNguoiLap);
                    Report.SetParameterValue("TenThuTruong", tenThuTruong);
                    Report.SetParameterValue("NguoiLapBang", _tenNguoiLap);
                    Report.SetParameterValue("ThuTruongDonVi", _tenThuTruong);
                    Report.SetParameterValue("_tuKy", cbKyTinhLuong.Text);
                    Report.SetParameterValue("_denky", cbDenKy.Text);
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
                //case "Node1":
                //    gbChiTiet.Enabled = false;
                //    lbGhiChu.Text = "Báo Cáo thù lao chi tiết cho từng nhân viên điều kiện: Từ ngày->Đến ngày";
                //    break;
                //case "Node2":
                //    gbChiTiet.Enabled = false;
                //    lbGhiChu.Text = "Báo Cáo thù lao chi tiết cho từng nhân viên theo phiếu chi điều kiện: Từ ngày->Đến ngày";
                //    break;
                //case "Node3":
                //    gbChiTiet.Enabled = true;
                //    lbGhiChu.Text = "Báo Cáo thù lao theo bộ phận được phân quyền điều kiện: Điều kiện chi tiết";
                //    break;
                //case "Node4":
                //    gbChiTiet.Enabled = true;
                //    lbGhiChu.Text = "Báo Cáo thù lao chuyển đi ngân hàng của nhân viên từng bộ phận được phân phân quyền điều kiện: Điều kiện chi tiết";
                //    break;
                //default:
                //    lbGhiChu.Text = "";
                //    break;
                    
            }
        }

      

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhLuong = Convert.ToInt32(cbKyTinhLuong.Value);
                KyTinhLuong ktl=KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);
               
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

        private void cmbPTDonVi_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPTDonVi.Value != null && (int)cmbPTDonVi.Value != 0)
            {
                _tenBanPhuTrach = "Ban Phụ Trách\r\n(Ký, họ tên)";
                tenBanPhuTrach = cmbPTDonVi.Text;
            }
            else if ((int)cmbPTDonVi.Value == 0)
            {
                _tenBanPhuTrach = string.Empty;
                tenBanPhuTrach = string.Empty;
            }
        }

        private void cmbPTTaiChinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbPTTaiChinh.Value != null && (int)cmbPTTaiChinh.Value != 0)
            {
                _tenThuTruong = "Ban Phụ Trách\r\n(Ký, họ tên)";
                tenThuTruong = cmbPTTaiChinh.Text;
            }
            else if ((int)cmbPTTaiChinh.Value == 0)
            {
                _tenThuTruong = string.Empty;
                tenThuTruong = string.Empty;
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
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
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
            FilterCombo f = new FilterCombo(cbNhanVien, "TenNhanVien");
            
        }

        private void cbKyTinhLuong_ValueChanged_1(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                tuKy = Convert.ToInt32(cbKyTinhLuong.Value);
            }
        }

        private void cbDenKy_ValueChanged(object sender, EventArgs e)
        {
            if (cbDenKy.Value != null)
            {
                denKy = Convert.ToInt32(cbDenKy.Value);
            }
        }
    }
}