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
    public partial class frmBaoCaoHoaDon : Form
    {
        DoiTacList _doiTacList;        
        HoaDonList _hoaDonList;
        ChungTuList _chungTuList;
        int maTaiKhoan;

        long maDoiTac = 0;
        long maHoaDon = 0;
        long maChungTu = 0;
        int _tinhTrang = -1;
        int _tinhTrangThuChi = -1;
        int _maLoaiChungTu = 0;
        DateTime _tuNgay = DateTime.Today.Date;
        DateTime _denNgay = DateTime.Today.Date;
        int userID = ERP_Library.Security.CurrentUser.Info.UserID;
        string maTaiKhoanChuoi = string.Empty;

        public frmBaoCaoHoaDon()
        {
            InitializeComponent();
            this.bindingSource2_DoiTac.DataSource = typeof(ERP_Library.DoiTacList);
            this.bindingSource1_HoaDon.DataSource = typeof(ERP_Library.HoaDonList);

            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            dateDenNgay1.Value = DateTime.Now.Date;
            dateTuNgay1.Value = DateTime.Now.Date;
            cbo_sohieutk.Value= HeThongTaiKhoan1.LayMaTaiKhoan("31131");
        }

        private void frmBaoCaoThuLao_Load(object sender, EventArgs e)
        {
            _doiTacList = DoiTacList.GetDoiTacList();
            DoiTac dt = DoiTac.NewDoiTac("Tất Cả");
            _doiTacList.Insert(0, dt);
            this.bindingSource2_DoiTac.DataSource = _doiTacList;

            _hoaDonList = HoaDonList.GetHoaDonList();
            HoaDon hd = HoaDon.NewHoaDon("Tất Cả");
            _hoaDonList.Insert(0, hd);
            this.bindingSource1_HoaDon.DataSource = _hoaDonList;
           
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
                case "Node1":
                    Report = new Report.CongNo.DanhSachHoaDon();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DanhSachHoaDon";                

                    command.Parameters.AddWithValue("@TuNgay",Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay",Convert.ToDateTime( dateDenNgay1.Value));
                    command.Parameters.AddWithValue("@MaDoiTac",maDoiTac);
                    command.Parameters.AddWithValue("@MaHoaDon",maHoaDon);
                    command.Parameters.AddWithValue("@TinhTrang",_tinhTrang);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);  
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                     adapter = new SqlDataAdapter(command);
                     table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "DanhSachHoaDon;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay",Convert.ToDateTime(dateTuNgay1.Value));
                    Report.SetParameterValue("_denNgay",Convert.ToDateTime(dateDenNgay1.Value));
                    Report.SetParameterValue("_tinhTrang", cbTinhTrangHoaDon.Text);
                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node2":                    
                    if ((int)cbo_sohieutk.Value == 0)
                    {
                        cbo_sohieutk.Appearance.BackColor = Color.PeachPuff;
                        cbo_sohieutk.Focus();
                    }
                    else
                    {
                        cbo_sohieutk.Appearance.BackColor = Color.White;                        
                    }
                    Report = new Report.CongNo.DanhSachHoaDonKemChungTu();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "reportDanhSachHoaDonKemChungTu";

                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay1.Value));
                    command.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                    command.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    command.Parameters.AddWithValue("@mataikhoan", (int)cbo_sohieutk.Value);
                    //command.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "reportDanhSachHoaDonKemChungTu;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay1.Value));
                    Report.SetParameterValue("_tinhTrang", cbTinhTrangHoaDon.Text);
                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node3":
                    Report = new Report.CongNo.BaoCaoTheoDoiThuChi();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "Report_TheoDoiChungTu";

                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay1.Value));                    
                    command.Parameters.AddWithValue("@MaChungTu", maChungTu);                    
                    command.Parameters.AddWithValue("@TinhTrang", _tinhTrangThuChi);
                    command.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "Report_TheoDoiChungTu;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay1.Value));
                    Report.SetParameterValue("_tinhTrang", cbTinhTrangThuChi.Text);
                    Report.SetParameterValue("_loaiThuChi", cbLoaiChungTu.Text);
                    Report.SetParameterValue("tenDonVi", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

                    dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    dlg.Show();
                    break;
                case "Node4":
                    if ((int)cbo_sohieutk.Value == 0)
                    {
                        cbo_sohieutk.Appearance.BackColor = Color.PeachPuff;
                        cbo_sohieutk.Focus();
                    }
                    else
                    {
                        cbo_sohieutk.Appearance.BackColor = Color.White;
                    }
                    Report = new Report.CongNo.DanhSachHoaDonKem_KhongChungTu();
                    command = new SqlCommand();
                    dataset = new DataSet();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "reportDanhSachHoaDon_khongKemChungTu";

                    command.Parameters.AddWithValue("@TuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    command.Parameters.AddWithValue("@DenNgay", Convert.ToDateTime(dateDenNgay1.Value));
                    command.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                    command.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    command.Parameters.AddWithValue("@mataikhoan", (int)cbo_sohieutk.Value);
                    //command.Parameters.AddWithValue("@TinhTrang", _tinhTrang);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                    adapter = new SqlDataAdapter(command);
                    table = new DataTable();
                    adapter.Fill(table);
                    table.TableName = "reportdanhsachhoadon_khongkemchungtu;1";
                    dataset.Tables.Add(table);
                    Report.SetDataSource(dataset);
                    Report.SetParameterValue("_tuNgay", Convert.ToDateTime(dateTuNgay1.Value));
                    Report.SetParameterValue("_denNgay", Convert.ToDateTime(dateDenNgay1.Value));
                    Report.SetParameterValue("_tinhTrang", cbTinhTrangHoaDon.Text);
                    Report.SetParameterValue("_tenBoPhan", ERP_Library.Security.CurrentUser.Info.TenBoPhan);
                    Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                    Report.SetParameterValue("_tenThuTruong", ERP_Library.Security.CurrentUser.Info.TenThuTruong);

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
        
        }

   
    
        private void cbNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbDoiTuong, "TenDoiTac");
            foreach (UltraGridColumn col in this.cbDoiTuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Khách Hàng";
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 0;
            cbDoiTuong.DisplayLayout.Bands[0].Columns["TenDoiTac"].Width = 250;

        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_HoaDon,  "SoHoaDon");
            foreach (UltraGridColumn col in this.cmbu_HoaDon.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                if (col.DataType == typeof(decimal))
                {
                    col.Format = "###,###,###,####,###";
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "Tên Chương Trình";
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 0;
            
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Hidden = false;
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.Caption = "Mã QL";
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoSerial"].Header.VisiblePosition = 1;
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Hidden = false;
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.Caption = "Tổng Tiền";
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["TongTien"].Header.VisiblePosition = 2;

            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Hidden = false;
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Header.Caption = "Tổng Tiền Đã Thanh Toán";
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoTienDaThanhToan"].Header.VisiblePosition =3;

            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Tổng Tiền Còn Lại";
            cmbu_HoaDon.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 4;
        }

        private void cmbu_ChuongTrinh_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_HoaDon.Value != null)
            {
                maHoaDon = Convert.ToInt64(cmbu_HoaDon.Value);
            }
        }

        private void cbDoiTuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbDoiTuong.Value != null)
           {
                maDoiTac = Convert.ToInt64(cbDoiTuong.Value);
            }
        }

        private void cbThanhToan_ValueChanged(object sender, EventArgs e)
        {
            if (cbTinhTrangHoaDon.Value != null)
            {
                _tinhTrang = Convert.ToInt32(cbTinhTrangHoaDon.Value);
            }
        }

        private void cbChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "SoChungTu");
            foreach (UltraGridColumn col in this.cbChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                if (col.DataType == typeof(decimal))
                {
                    col.Format = "###,###,###,####,###";
                    col.CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                }
            }
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;

            //cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            //cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            //cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 2;

        
        }

        private void cbChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbChungTu.Value != null)
            {
                maChungTu = Convert.ToInt64(cbChungTu.Value);
            }
        }

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeReport.SelectedNode.Name != "Node3")
            {
                cbLoaiChungTu.Enabled = false;
                cbTinhTrangThuChi.Enabled = false;
                cbDoiTuong.Enabled = true;
                cbTinhTrangHoaDon.Enabled = true;
                cmbu_HoaDon.Enabled = true;
            }
            else if (treeReport.SelectedNode.Name == "Node3")
            {
                cbLoaiChungTu.Enabled = true;
                cbTinhTrangThuChi.Enabled = true;
                cbDoiTuong.Enabled = false;
                cbTinhTrangHoaDon.Enabled = false;
                cmbu_HoaDon.Enabled = false;
            }
        }

        private void cbLoaiChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiChungTu.Value != null)
                _maLoaiChungTu = Convert.ToInt32(cbLoaiChungTu.Value);
        }

        private void cbTinhTrangThuChi_ValueChanged(object sender, EventArgs e)
        {
            if (cbTinhTrangThuChi.Value != null)
                _tinhTrangThuChi = Convert.ToInt32(cbTinhTrangThuChi.Value);
        }

        private void btn_chontk_Click(object sender, EventArgs e)
        {
            maTaiKhoanChuoi = string.Empty;
            UserInterface.KeToanTongHop.frmDSTaiKhoan _frmDS = new PSC_ERP.UserInterface.KeToanTongHop.frmDSTaiKhoan();
            if (_frmDS.ShowDialog(this) != DialogResult.OK)
            {
                maTaiKhoanChuoi = _frmDS.maTaiKhoanChuoi;
            }
        }

        private void cbo_sohieutk_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cbo_sohieutk.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            cbo_sohieutk.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            cbo_sohieutk.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu Tài Khoản";
            cbo_sohieutk.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 0;

            cbo_sohieutk.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            cbo_sohieutk.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            cbo_sohieutk.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 1;

            this.cbo_sohieutk.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
        }

        private void cbo_sohieutk_ValueChanged(object sender, EventArgs e)
        {
            if (cbo_sohieutk.ActiveRow != null)
            {
                HeThongTaiKhoan1 taiKhoan;
                taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1((int)cbo_sohieutk.Value);
                maTaiKhoan = taiKhoan.MaTaiKhoan;
                // them chuoi vao
                maTaiKhoanChuoi = string.Empty;
                if (Convert.ToInt32(cbo_sohieutk.ActiveRow.Cells["MaTaiKhoan"].Value) != 0)
                {
                    maTaiKhoanChuoi = cbo_sohieutk.ActiveRow.Cells["MaTaiKhoan"].Value.ToString();
                }
                else
                {
                    maTaiKhoanChuoi = "";
                }

            }
        }

       

   
    }
}