using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Shared;
using Infragistics.Win; 
using Infragistics.Win.UltraWinGrid;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using ERP_Library;


namespace PSC_ERP
{
    public partial class frmBaoCaoBanHang : Form
    {
        LoaiKhachHangList _loaiKhachHangList;
        DoiTacList _doiTacList;
        LoaiHangHoaList _loaiHangHoaList;
        HangHoaList _hangHoaList;
        int _Quy = 0;

        public frmBaoCaoBanHang()
        {
            InitializeComponent();
            KhoiTao();
        }

        #region Khởi tạo
        private void KhoiTao()
        {
            LoaiKhachHang _loaiKhachHang = LoaiKhachHang.NewLoaiKhachHang(0, "None");
            _loaiKhachHangList = LoaiKhachHangList.GetLoaiKhachHangList();
            _loaiKhachHangList.Insert(0, _loaiKhachHang);
            loaiKhachHangListBindingSource.DataSource = _loaiKhachHangList;

            LoaiHangHoa _loaiHangHoa = LoaiHangHoa.NewLoaiHangHoa("None", 0);
            _loaiHangHoaList = LoaiHangHoaList.GetLoaiHangHoaList(0);
            _loaiHangHoaList.Insert(0, _loaiHangHoa);
            loaiHangHoaListBindingSource.DataSource = _loaiHangHoaList;

            khoListBindingSource.DataSource = KhoList.GetKhoList_KetChuyenTon();
            kyListBindingSource.DataSource = KyList.GetKyList();

        }
        #endregion

        #region tlslblThoat_Click
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region tlslblIn_Click
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            ReportDocument Report = new ReportDocument();
            DataSet dataSet = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();           

            DateTime ngayBatDau = Convert.ToDateTime(dtu_TuNgay.Value);
            DateTime ngayKetThuc = Convert.ToDateTime(dtu_DenNgay.Value);
            DateTime ngay = Convert.ToDateTime(dtu_Ngay.Value);
            DateTime tuNgayQuy = Convert.ToDateTime(dt_TuNgayQuy.Value);
            DateTime denNgayQuy = Convert.ToDateTime(dt_DenNgayQuy.Value);
            DateTime tuNgayKy = Convert.ToDateTime(dt_TuNgay.Value);
            DateTime denNgayKy = Convert.ToDateTime(dt_DenNgay.Value);

            int maLoaiHangHoa = 0;
            int maKhachHang  = 0;
            int maHangHoa =0;
            int maLoaiKhachHang = 0;
            int maKho = 0;
            int maKy = 0;

            if (cmbu_LoaiHangHoa.ActiveRow != null)            
                maLoaiHangHoa = Convert.ToInt32(cmbu_LoaiHangHoa.Value);
            
            if(cmb_HangHoa.ActiveRow != null)
                maHangHoa = Convert.ToInt32(cmb_HangHoa.Value);

            if(cbu_KhachHang.ActiveRow != null)
                maKhachHang = Convert.ToInt32(cbu_KhachHang.Value);

            if(cbu_LoaiKhachHang.ActiveRow != null)
                maLoaiKhachHang = Convert.ToInt32(cbu_LoaiKhachHang.Value);

            if (cbu_Kho.ActiveRow != null)
                maKho = Convert.ToInt32(cbu_Kho.Value);
            if (cb_Ky.SelectedValue != null)            
                maKy = Convert.ToInt32(cb_Ky.SelectedValue);            

            if (ultraTree_DSBaoCao.ActiveNode.Key == "ChiTietMuaHangTheoTungMatHang")
            {
                Report = new Report.Report_MuaBan.ChiTietBanHangTheoMatHang();
                command.CommandText = "spd_BaoCaoChiTietMuaBanHangTheoMatHang";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@Loai", 1);
                command.Parameters.AddWithValue("@MaLoaiHangHoa", maLoaiHangHoa);
                command.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                adapter.SelectCommand = command;
                adapter.Fill(table);                
                table.TableName = "spd_BaoCaoChiTietMuaBanHangTheoMatHang;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@LoaiTemp", 1);
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
                Report.SetParameterValue("@MaLoaiHangHoa", maLoaiHangHoa);
                Report.SetParameterValue("@MaHangHoa", maHangHoa);

            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangKeDonMuaHang")
            {
                Report = new Report.Report_MuaBan.BangKeDonMuaHang();
                command.CommandText = "spd_BaoCaoThongKeDonMuaHang";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);                
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoThongKeDonMuaHang;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
                Report.SetParameterValue("@tuNgay", ngayBatDau);
                Report.SetParameterValue("@DenNgay", ngayKetThuc);

            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "HoaDonMuaHangChuaThanhToan")
            {
                Report = new Report.Report_MuaBan.HoaDonMuaBanHangChuaThanhToan();
                command.CommandText = "spd_BaoCaoHoaDonMuaBanHangChuaThanhToan";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@Loai", 1);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoHoaDonMuaBanHangChuaThanhToan;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@LoaiTemp", 1);
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "LietKeHoaDonMuaHang")
            {
                Report = new Report.Report_MuaBan.LietKeHoaDonBanHang();
                command.CommandText = "spd_BaoCaoLietKeHoaDonMuaBanHang";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@Loai", 1);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoLietKeHoaDonMuaBanHang;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@LoaiTemp", 1);
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "TongHopMuaHangTheoKhachHang")
            {
                Report = new Report.Report_MuaBan.TongHopMuaHangTheoKhachHang();
                command.CommandText = "spd_BaoCaoTongHopMuaHangTheoKhachHang";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@Loai", 1);
                command.Parameters.AddWithValue("@MaLoaiKhachHang", maLoaiKhachHang);
                command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoTongHopBanHangTheoKhachHang;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
                Report.SetParameterValue("@LoaiTemp", 1);
                
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoNoPhaiTra")
            {
                Report = new Report.Report_MuaBan.BaoCaoNoPhaiThuQuaHan();
                command.CommandText = "spd_BaoCaoNoPhaiThuPhaiTraQuaHan";              
                command.Parameters.AddWithValue("@Loai", 1);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoNoPhaiThuPhaiTraQuaHan;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@LoaiTemp", 1);
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "LietKeChungTuTraLaiHang")
            {
                Report = new Report.Report_MuaBan.ChungTuHangMuaTraLai();
                command.CommandText = "spd_BaoCaoChungTuHangMuaTraLai";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);                
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoChungTuHangMuaTraLai;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "ChiTietBanHangTheoTungMatHang")
            {
                Report = new Report.Report_MuaBan.ChiTietBanHangTheoMatHang();
                command.CommandText = "spd_BaoCaoChiTietMuaBanHangTheoMatHang";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@Loai", 0);
                command.Parameters.AddWithValue("@MaLoaiHangHoa", maLoaiHangHoa);
                command.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoChiTietMuaBanHangTheoMatHang;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@LoaiTemp", 0);
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
                Report.SetParameterValue("@MaLoaiHangHoa", maLoaiHangHoa);
                Report.SetParameterValue("@MaHangHoa", maHangHoa);
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BangKeDonBanHang")
            {
                Report = new Report.Report_MuaBan.BangKeDonHangBan();
                command.CommandText = "spd_BaoCaoThongKeDonBanHang";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);                
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoThongKeDonBanHang;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);
                
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "HoaDonBanHangChuaThanhToan")
            {
                Report = new Report.Report_MuaBan.HoaDonMuaBanHangChuaThanhToan();
                command.CommandText = "spd_BaoCaoHoaDonMuaBanHangChuaThanhToan";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@Loai", 0);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoHoaDonMuaBanHangChuaThanhToan;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@LoaiTemp", 0);
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "LietKeHoaDonBanHang")
            {
                Report = new Report.Report_MuaBan.LietKeHoaDonBanHang();
                command.CommandText = "spd_BaoCaoLietKeHoaDonMuaBanHang";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@Loai", 0);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoLietKeHoaDonMuaBanHang;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@LoaiTemp", 0);
                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "TongHopBanHangTheoKhachHang")
            {
                Report = new Report.Report_MuaBan.TongHopBanHangTheoKhachHang();
                command.CommandText = "spd_BaoCaoTongHopBanHangTheoKhachHang";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);
                command.Parameters.AddWithValue("@Loai", 0);
                command.Parameters.AddWithValue("@MaLoaiKhachHang", maLoaiKhachHang);
                command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                //command.Parameters.AddWithValue("@Loai", 0);      
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoTongHopBanHangTheoKhachHang;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
                Report.SetParameterValue("@LoaiTemp", 0);
              
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoNoPhaiThuQuaHan")
            {
                Report = new Report.Report_MuaBan.BaoCaoNoPhaiThuQuaHan();
                command.CommandText = "spd_BaoCaoNoPhaiThuPhaiTraQuaHan";              
                command.Parameters.AddWithValue("@Loai", 0);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoNoPhaiThuPhaiTraQuaHan;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@LoaiTemp", 0);             
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "LietKeChungTuNhanHangTra")
            {
                Report = new Report.Report_MuaBan.LietKeChungTuNhanHangTra();
                command.CommandText = "spd_BaoCaoChungTuNhanHangTraLai";
                command.Parameters.AddWithValue("@TuNgay", ngayBatDau);
                command.Parameters.AddWithValue("@DenNgay", ngayKetThuc);                
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoChungTuNhanHangTraLai;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                Report.SetDataSource(dataSet);

                Report.SetParameterValue("@NgayBatDau", ngayBatDau);
                Report.SetParameterValue("@NgayKetThuc", ngayKetThuc);
            }

            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoHangHoaTonKho")
            {

                Kho kho = Kho.GetKho(maKho);
                Report = new ReportDocument();
                if (kho.MaLoaiKho == 3 || kho.MaLoaiKho == 46)
                {                                           
                    Report = new Report.Report_MuaBan.BaoCaoTonKho();
                    command.CommandText = "spd_BaoCaoTonKhoBanHangDaiLy";
                    command.Parameters.AddWithValue("@MaKho", maKho);
                }
                else
                {
                    Report = new Report.Report_MuaBan.BaoCaoTonKho();
                    command.CommandText = "spd_BaoCaoTonKhoBanHang";
                    command.Parameters.AddWithValue("@MaKho", maKho);
                }
                int loai = 0; 
                if (rdbt_Ngay.Checked == true)
                {
                    command.Parameters.AddWithValue("@TuNgay", ngay);
                    command.Parameters.AddWithValue("@DenNgay", denNgayKy);
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    command.Parameters.AddWithValue("@Loai", 1);
                    loai = 1;                    
                }
                else if (rdbt_Ky.Checked == true)
                {
                    command.Parameters.AddWithValue("@TuNgay", tuNgayKy);
                    command.Parameters.AddWithValue("@DenNgay", denNgayKy);
                    command.Parameters.AddWithValue("@Loai", 2);                    
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    loai = 2;
                }
                else if (rdbt_Quy.Checked == true)
                {
                    command.Parameters.AddWithValue("@TuNgay", tuNgayQuy);
                    command.Parameters.AddWithValue("@DenNgay", denNgayQuy);
                    command.Parameters.AddWithValue("@Loai", 3);                    
                    command.Parameters.AddWithValue("@MaKy", maKy);
                    loai = 3;
                }  
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoTonKhoBanHang;1";
                Report.SetDataSource(table);
                Report.SetParameterValue("@NgayTon", ngay);
                Report.SetParameterValue("@LoaiReport", loai);
                Report.SetParameterValue("@TenKho", kho.TenKho);
               
            }           

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;            
            dlg.Show();
        }
        #endregion 

        #region cbu_LoaiKhachHang_ValueChanged
        private void cbu_LoaiKhachHang_ValueChanged(object sender, EventArgs e)
        {

            DoiTac doiTac = DoiTac.NewDoiTac(0, "None");
            if (cbu_LoaiKhachHang.ActiveRow != null)
            {
                _doiTacList = DoiTacList.GetDoiTacListTheoLoaiKhachHang(Convert.ToInt32(cbu_LoaiKhachHang.Value));
                _doiTacList.Insert(0, doiTac);                
            }
            else
            {
                _doiTacList = DoiTacList.NewDoiTacList();
                _doiTacList.Insert(0, doiTac);                
            }
            doiTacListBindingSource.DataSource = _doiTacList;
            
        }
        #endregion 

        #region cmbu_LoaiHangHoa_ValueChanged
        private void cmbu_LoaiHangHoa_ValueChanged(object sender, EventArgs e)
        {
            HangHoa _hangHoa = HangHoa.NewHangHoa("None", 0);
            if (cmbu_LoaiHangHoa.ActiveRow != null)
            {
                int maLoaiHangHoa = Convert.ToInt32(cmbu_LoaiHangHoa.Value);                
                _hangHoaList = HangHoaList.GetHangHoaList(maLoaiHangHoa,0);
                _hangHoaList.Insert(0, _hangHoa);
                
            }
            else
            {
                _hangHoaList = HangHoaList.NewHangHoaList();
                _hangHoaList.Insert(0, _hangHoa);
            }
            hangHoaListBindingSource.DataSource = _hangHoaList;
        }
        #endregion 
        
        #region cbu_LoaiKhachHang_InitializeLayout
        private void cbu_LoaiKhachHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {          
            this.cbu_LoaiKhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_LoaiKhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_LoaiKhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            
            }
            cbu_LoaiKhachHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbu_LoaiKhachHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Loại Khách Hàng";
            cbu_LoaiKhachHang.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cbu_LoaiKhachHang.DisplayLayout.Bands[0].Columns["TenLoaiKhachHang"].Hidden = false;
            cbu_LoaiKhachHang.DisplayLayout.Bands[0].Columns["TenLoaiKhachHang"].Header.Caption = "Tên Loại Khách Hàng";
            cbu_LoaiKhachHang.DisplayLayout.Bands[0].Columns["TenLoaiKhachHang"].Header.VisiblePosition = 1;
           
        }
        #endregion 

        #region cbu_KhachHang_InitializeLayout
        private void cbu_KhachHang_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_KhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_KhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_KhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue

            }
            cbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Hidden = false;
            cbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.Caption = "Mã Khách Hàng";
            cbu_KhachHang.DisplayLayout.Bands[0].Columns["MaQLDoiTac"].Header.VisiblePosition = 0;

            cbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Hidden = false;
            cbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.Caption = "Tên Khách Hàng";
            cbu_KhachHang.DisplayLayout.Bands[0].Columns["TenDoiTac"].Header.VisiblePosition = 1;
        }
        #endregion 

        #region cmbu_LoaiHangHoa_InitializeLayout
        private void cmbu_LoaiHangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cmbu_LoaiHangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmbu_LoaiHangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue

            }
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Loại Hàng";
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Hidden = false;
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.Caption = "Tên Loại Hàng";
            cmbu_LoaiHangHoa.DisplayLayout.Bands[0].Columns["TenLoaiHangHoa"].Header.VisiblePosition = 1;
        }
        #endregion 

        #region cmb_HangHoa_InitializeLayout
        private void cmb_HangHoa_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cmb_HangHoa.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cmb_HangHoa.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cmb_HangHoa.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue

            }
            cmb_HangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cmb_HangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Hàng Hóa";
            cmb_HangHoa.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cmb_HangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Hidden = false;
            cmb_HangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.Caption = "Tên Hàng Hóa";
            cmb_HangHoa.DisplayLayout.Bands[0].Columns["TenHangHoa"].Header.VisiblePosition = 1;
        }
        #endregion

        #region ultraTree_DSBaoCao_AfterSelect
        private void ultraTree_DSBaoCao_AfterSelect(object sender, Infragistics.Win.UltraWinTree.SelectEventArgs e)
        {
            if (ultraTree_DSBaoCao.ActiveNode.Key == "ChiTietMuaHangTheoTungMatHang" || ultraTree_DSBaoCao.ActiveNode.Key == "ChiTietBanHangTheoTungMatHang")
            {
                grb_KhachHang.Enabled = false;
                grb_HangHoa.Enabled = true;
                grb_ThoiGian.Enabled = true;
                grb_BaoCaoTon.Enabled = false;
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "TongHopMuaHangTheoKhachHang" || ultraTree_DSBaoCao.ActiveNode.Key == "TongHopBanHangTheoKhachHang")
            {
                grb_KhachHang.Enabled = true;
                grb_HangHoa.Enabled = false;                
                grb_ThoiGian.Enabled = true;
                grb_BaoCaoTon.Enabled = false;
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoNoPhaiThuQuaHan" || ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoNoPhaiTra")
            {
                grb_KhachHang.Enabled = false;
                grb_HangHoa.Enabled = false;
                grb_ThoiGian.Enabled = false;
                grb_BaoCaoTon.Enabled = false;
            }
            else if (ultraTree_DSBaoCao.ActiveNode.Key == "BaoCaoHangHoaTonKho")
            {
                grb_KhachHang.Enabled = false;
                grb_HangHoa.Enabled = false;
                grb_ThoiGian.Enabled = false;
                grb_BaoCaoTon.Enabled = true;
            }
            else
            {
                grb_KhachHang.Enabled = false;
                grb_HangHoa.Enabled = false;
                grb_ThoiGian.Enabled = true;
                grb_BaoCaoTon.Enabled = false;
            }
            
        }
        #endregion 

        #region cbu_Kho_InitializeLayout
        private void cbu_Kho_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            this.cbu_Kho.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.cbu_Kho.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.SteelBlue;
            foreach (UltraGridColumn col in this.cbu_Kho.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue

            }
            cbu_Kho.DisplayLayout.Bands[0].Columns["MaQuanLy"].Hidden = false;
            cbu_Kho.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.Caption = "Mã Kho";
            cbu_Kho.DisplayLayout.Bands[0].Columns["MaQuanLy"].Header.VisiblePosition = 0;

            cbu_Kho.DisplayLayout.Bands[0].Columns["TenKho"].Hidden = false;
            cbu_Kho.DisplayLayout.Bands[0].Columns["TenKho"].Header.Caption = "Tên Kho";
            cbu_Kho.DisplayLayout.Bands[0].Columns["TenKho"].Header.VisiblePosition = 1;
        }
        #endregion 

        #region cbeu_Quy_ValueChanged
        private void cbeu_Quy_ValueChanged(object sender, EventArgs e)
        {
            DateTime ngayBatDau ;
            DateTime ngayKetThuc;
            if (cbeu_Quy.Value != null)
            {
                _Quy = Convert.ToInt16(cbeu_Quy.Value);
                if (_Quy == 1)
                {
                    dt_TuNgayQuy.Value = Convert.ToDateTime("1/1/2008");
                    dt_DenNgayQuy.Value = Convert.ToDateTime("3/31/2008");
                }
                else if (_Quy == 2)
                {
                    dt_TuNgayQuy.Value = Convert.ToDateTime("4/1/2008");
                    dt_DenNgayQuy.Value = Convert.ToDateTime("6/30/2008");
                }
                else  if (_Quy == 3)
                {
                    dt_TuNgayQuy.Value = Convert.ToDateTime("7/1/2008");
                    dt_DenNgayQuy.Value = Convert.ToDateTime("9/30/2008");
                }
                else if (_Quy == 4)
                {
                    dt_TuNgayQuy.Value = Convert.ToDateTime("10/1/2008");
                    dt_DenNgayQuy.Value = Convert.ToDateTime("12/31/2008");
                }
            }
        }
        #endregion 
    }
}