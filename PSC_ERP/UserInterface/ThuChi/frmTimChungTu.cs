using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Shared;
using Infragistics.Win;
using ERP_Library;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using PSC_ERP;


namespace PSC_ERP
{// 4-1-2010
    public partial class frmTimChungTu : Form
    {
        ChungTuList _ChungTuList;
        ChungTu _ChungTu = ChungTu.NewChungTu();
        int TongTrang = 0; // tong so trang 
        int PageSize = 0; // kich thuoc trang can hien
        long TrangBo = 0; // tong so trang nam ngoai trang chon
        int TrangChon = 0;// trang hien tai chon
        public ChungTu _ChungTu1 = ChungTu.NewChungTu();
        public bool DaChon = false;
        public int MaLoaiChungTu;
        public frmTimChungTu()
        {
            InitializeComponent();
            txtu_DieuKienTim.Focus();
        }
        public frmTimChungTu(int maLoaiChungTu)
        {
            InitializeComponent();
            txtu_DieuKienTim.Focus();
            this.MaLoaiChungTu = maLoaiChungTu;
        }
        #region grdu_DSKhachHang_InitializeLayout
        private void grdu_DSKhachHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_DSKhachHang.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                    col.CellAppearance.TextHAlign = HAlign.Center;
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "###,###,###,###,###,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
                col.CellActivation = Activation.NoEdit;
            }

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Xóa/In";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Chon"].Width = 15;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoTT"].Header.Caption = "STT";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoTT"].Header.VisiblePosition = 1;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoTT"].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoTT"].Width = 40;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 2;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 100;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 4;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TyGia"].Header.Caption = "Tỷ Giá";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TyGia"].Header.VisiblePosition = 4;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TyGia"].Width = 15;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["TyGia"].Hidden = false;

            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.Caption = "Thành Tiền";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["ThanhTien"].Header.VisiblePosition = 5;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["ThanhTien"].Width = 150;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["ThanhTien"].Hidden = false;


            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 5;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 200;

            grdu_DSKhachHang.DisplayLayout.Bands[1].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[2].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[3].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[4].Hidden = true;
            grdu_DSKhachHang.DisplayLayout.Bands[5].Hidden = true;
            //grdu_DSKhachHang.DisplayLayout.Bands[6].Hidden = true;            
            //grdu_DSKhachHang.DisplayLayout.Bands[9].Hidden = true;

            grdu_DSKhachHang.DisplayLayout.Override.HeaderAppearance.BackColor = Color.SteelBlue;
            this.grdu_DSKhachHang.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;


            grdu_DSKhachHang.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;

        }
        #endregion

        #region btn_Tim_Click
        private void btn_Tim_Click(object sender, EventArgs e)
        {
            //if (DSChungTu_BindingSource.Current != null)
            //    grdu_DSKhachHang_DoubleClick(grdu_DSKhachHang, null);
            //_ChungTuList = ChungTuList.TimChungTu(txtu_DieuKienTim.Text);
            //DSChungTu_BindingSource.DataSource = _ChungTuList;

            Paging(txtu_DieuKienTim.Text, ERP_Library.Security.CurrentUser.Info.UserID);
        }
        #endregion
        #region Paging
        void Paging(string dkTim, long MaNguoiLap)
        {
            //cboTrang.Items.Clear();
            //PageSize = int.Parse(txtSize.Text.Trim());
            //
            string TuNgay = "";
            string DenNgay = "";
            int loai = 0;
            LoadPage();
            //if (KiemTraTuNgayDenNgay(txtu_DieuKienTim.Text))
            //{
            //    string[] mang = txtu_DieuKienTim.Text.Split('-');
            //    TuNgay = mang[0].Trim();
            //    DenNgay = mang[1].Trim();
            //    loai = 1;
            //}
            //
            //int TongDong = ChungTuList.TongDonngTim(dkTim, MaNguoiLap,loai,TuNgay,DenNgay);
            //TongTrang = TongDong / PageSize;
            //if (TongDong % PageSize != 0)
            //    TongTrang++;
            //for (int i = 1; i <= TongTrang; i++)
            //{
            //    cboTrang.Items.Add(i);
            //}
            ////
            //txtTongTrang.Text = TongTrang.ToString();
            //cboTrang.Text = "1";
        }
        #endregion
        #region txtu_DieuKienTim_KeyDown
        private void txtu_DieuKienTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //_ChungTuList = ChungTuList.TimChungTu(txtu_DieuKienTim.Text);
                //DSChungTu_BindingSource.DataSource = _ChungTuList;
                Paging(txtu_DieuKienTim.Text, ERP_Library.Security.CurrentUser.Info.UserID);


                //if (DSChungTu_BindingSource.Current != null)
                //    grdu_DSKhachHang_DoubleClickRow(grdu_DSKhachHang, null);

            }
        }
        #endregion

        #region grdu_DSKhachHang_DoubleClick
        private void grdu_DSKhachHang_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region grdu_DSKhachHang_Click
        private void grdu_DSKhachHang_Click(object sender, EventArgs e)
        {
            //_ChungTu = (ChungTu)(DSChungTu_BindingSource.Current);
            //contextMenuStrip_In.Show();

        }
        #endregion

        #region In

        #region inToolStripMenuItem_In_Click
        private ReportDocument Report;
        private void inToolStripMenuItem_In_Click(object sender, EventArgs e)
        {


        }

        public void LoaiIn(int loaiIn)
        {
            DataSet _DataSet = new DataSet();
            if (_ChungTu.LoaiChungTu.MaLoaiCT == 2) // In phieu thu
            {
                #region Phieu Thu

                if (loaiIn == 5)
                {
                    Report = new Report.CongNo.PhieuThu();
                }
                else if (loaiIn == 4)
                {
                    Report = new Report.CongNo.PhieuThuA4();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_PhieuThu";
                command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@SoCTKemTheo", 0);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = "spd_LayNoTaiKhoan_1";
                command2.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command3 = new SqlCommand();
                command3.CommandType = CommandType.StoredProcedure;
                command3.CommandText = "spd_LayCoTaiKhoan_1";
                command3.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                SqlCommand command4 = new SqlCommand();
                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuThu;1";
                _DataSet.Tables.Add(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                table2.TableName = "spd_LayNoTaiKhoan_1;1";
                _DataSet.Tables.Add(table2);

                SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                DataTable table3 = new DataTable();
                adapter3.Fill(table3);
                table3.TableName = "spd_LayCoTaiKhoan_1;1";
                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                _DataSet.Tables.Add(table4);
                _DataSet.Tables.Add(table3);
                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            else if (_ChungTu.LoaiChungTu.MaLoaiCT == 3) // In phieu chi
            {
                #region Phieu Chi

                if (loaiIn == 5)
                {
                    Report = new Report.CongNo.PhieuChi();
                }
                else if (loaiIn == 4)
                {
                    Report = new Report.CongNo.PhieuChiA4();
                }

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_PhieuChi";
                command.Parameters.AddWithValue("@MaPhieuChi", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@SoCTKemTheo", 0);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);


                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = "spd_LayNoTaiKhoan_1";
                command2.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command3 = new SqlCommand();
                command3.CommandType = CommandType.StoredProcedure;
                command3.CommandText = "spd_LayCoTaiKhoan_1";
                command3.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command4 = new SqlCommand();
                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuChi;1";
                _DataSet.Tables.Add(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                table2.TableName = "spd_LayNoTaiKhoan_1;1";
                _DataSet.Tables.Add(table2);

                SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                DataTable table3 = new DataTable();
                adapter3.Fill(table3);
                table3.TableName = "spd_LayCoTaiKhoan_1;1";
                _DataSet.Tables.Add(table3);

                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                DataTable table4 = new DataTable();
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                _DataSet.Tables.Add(table4);
                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            else if (_ChungTu.LoaiChungTu.MaLoaiCT == 6) // In Uy Nhiem Chi
            {
                #region Uy Nhiem Chi
                ReportDocument Report = new PSC_ERP.Report.CongNo.UyNhiemChi();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_UyNhiemChi";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@MaCongTy", 1);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_UyNhiemChi;1";
                _DataSet.Tables.Add(table);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            else if (_ChungTu.LoaiChungTu.MaLoaiCT == 7) // In Uy Nhiem Thu
            {
                #region Uy Nhiem Thu
                ReportDocument Report = new PSC_ERP.Report.CongNo.UyNhiemThu();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_UyNhiemThu";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@MaCongTy", 1);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_UyNhiemThu;1";
                _DataSet.Tables.Add(table);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            else if (_ChungTu.LoaiChungTu.MaLoaiCT == 8 || _ChungTu.LoaiChungTu.MaLoaiCT == 16) // In Phieu Chuyen Khoan
            {
                #region Phieu Chuyen Khoan
                if (loaiIn == 5)
                {
                    Report = new Report.CongNo.ChungTuGhiSo();
                }
                else if (loaiIn == 4)
                {
                    Report = new Report.CongNo.ChungTuGhiSoA4();
                }
                //ReportDocument Report = new PSC_ERP.Report.CongNo.ChungTuGhiSo();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_BaoCaoChungTuGhiSo";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command2 = new SqlCommand();
                command2.CommandType = CommandType.StoredProcedure;
                command2.CommandText = "spd_LayNguoiKyTenCongNo";
                command2.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);




                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_BaoCaoChungTuGhiSo;1";
                _DataSet.Tables.Add(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                DataTable table2 = new DataTable();
                adapter2.Fill(table2);
                table2.TableName = "spd_LayNguoiKyTenCongNo;1";
                _DataSet.Tables.Add(table2);


                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
        }
        #endregion

        #region btn_In_Click
        private void btn_In_Click(object sender, EventArgs e)
        {
            _ChungTu = (ChungTu)(DSChungTu_BindingSource.Current);
            DataSet _DataSet = new DataSet();

            if (_ChungTu.LoaiChungTu.MaLoaiCT == 2) // In phieu thu
            {
                #region Phieu Thu
                ReportDocument Report = new PSC_ERP.Report.CongNo.PhieuThu();
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_PhieuThu";
                command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@SoCTKemTheo", 0);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuThu;1";
                _DataSet.Tables.Add(table);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                _DataSet.Tables.Add(table1);

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            else if (_ChungTu.LoaiChungTu.MaLoaiCT == 3) // In phieu chi
            {
                #region Phieu Chi
                ReportDocument Report = new PSC_ERP.Report.CongNo.PhieuChi();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_PhieuChi";
                command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@SoCTKemTheo", 0);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_PhieuChi;1";
                _DataSet.Tables.Add(table);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            else if (_ChungTu.LoaiChungTu.MaLoaiCT == 6) // In Bao Co
            {
                #region Uy Nhiem Chi
                ReportDocument Report = new PSC_ERP.Report.CongNo.UyNhiemChi();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_UyNhiemChi";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@MaCongTy", 1);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_UyNhiemChi;1";
                _DataSet.Tables.Add(table);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            else if (_ChungTu.LoaiChungTu.MaLoaiCT == 7) // In Bao No
            {
                #region Uy Nhiem Thu
                ReportDocument Report = new PSC_ERP.Report.CongNo.UyNhiemThu();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_UyNhiemThu";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@MaCongTy", 1);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_UyNhiemThu;1";
                _DataSet.Tables.Add(table);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            //else if (Phieu == 5) // In Phieu Chuyen Khoan
            //{
            #region Phieu Chuyen Khoan
            //ReportDocument Report = new Report.CongNo.PhieuChuyenKhoan();

            //SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.StoredProcedure;
            //command.CommandText = "spd_CongNo_ChuyenKhoan";
            //command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

            //command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            //SqlCommand command1 = new SqlCommand();
            //command1.CommandType = CommandType.StoredProcedure;
            //command1.CommandText = "spd_REPORT_ReportHeader";

            //command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            //DataTable table = new DataTable();
            //adapter.Fill(table);
            //table.TableName = "spd_CongNo_ChuyenKhoan;1";
            //_DataSet.Tables.Add(table);

            //SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            //DataTable table1 = new DataTable();
            //adapter1.Fill(table1);
            //table1.TableName = "spd_REPORT_ReportHeader;1";
            //_DataSet.Tables.Add(table1);

            //Report.SetDataSource(_DataSet);

            //frmHienThiReport dlg = new frmHienThiReport();
            //dlg.crytalView_HienThiReport.ReportSource = Report;
            //dlg.Show();
            #endregion
            //}
        }
        #endregion

        private void inBảngKêChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inPhiếuChuyểnKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChungTu = (ChungTu)(DSChungTu_BindingSource.Current);
            if (_ChungTu.LoaiChungTu.MaLoaiCT == 6 || _ChungTu.LoaiChungTu.MaLoaiCT == 7 || _ChungTu.LoaiChungTu.MaLoaiCT == 8)
            {
                DataSet _DataSet = new DataSet();
                ReportDocument Report = new PSC_ERP.Report.CongNo.PhieuChuyenKhoan();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_ChuyenKhoan";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_ChuyenKhoan;1";
                _DataSet.Tables.Add(table);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
            else
            {
                MessageBox.Show(this, "Phiếu này không có Phiếu Chuyển Khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void inUynhiem_Click(object sender, EventArgs e)
        {
            _ChungTu = (ChungTu)(DSChungTu_BindingSource.Current);
            DataSet _DataSet = new DataSet();
            if (_ChungTu.LoaiChungTu.MaLoaiCT == 6) // In Uy Nhiem Chi
            {
                #region Uy Nhiem Chi
                ReportDocument Report = new PSC_ERP.Report.CongNo.UyNhiemChi();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_UyNhiemChi";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@MaCongTy", 1);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_UyNhiemChi;1";
                _DataSet.Tables.Add(table);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
            else if (_ChungTu.LoaiChungTu.MaLoaiCT == 7) // In Uy Nhiem Chi
            {
                #region Uy Nhiem Thu
                ReportDocument Report = new PSC_ERP.Report.CongNo.UyNhiemThu();

                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_CongNo_UyNhiemThu";
                command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                command.Parameters.AddWithValue("@MaCongTy", 1);

                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlCommand command1 = new SqlCommand();
                command1.CommandType = CommandType.StoredProcedure;
                command1.CommandText = "spd_REPORT_ReportHeader";

                command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.TableName = "spd_CongNo_UyNhiemThu;1";
                _DataSet.Tables.Add(table);

                SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                DataTable table1 = new DataTable();
                adapter1.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                _DataSet.Tables.Add(table1);

                Report.SetDataSource(_DataSet);

                frmHienThiReport dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
                #endregion
            }
        }

        private void bảngKêChiTiếtThuTiềnTheoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChungTu = (ChungTu)(DSChungTu_BindingSource.Current);

            DataSet _DataSet = new DataSet();
            ReportDocument Report = new PSC_ERP.Report.CongNo.BangKeChiTietThuTienTheoHoaDon();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_BangKeChiTietThuTienTheoHoaDon";
            command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";

            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_BangKeChiTietThuTienTheoHoaDon;1";
            _DataSet.Tables.Add(table);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";
            _DataSet.Tables.Add(table1);

            Report.SetDataSource(_DataSet);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void BangKeCongNoTheohoaDonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChungTu = (ChungTu)(DSChungTu_BindingSource.Current);

            DataSet _DataSet = new DataSet();
            ReportDocument Report = new PSC_ERP.Report.CongNo.BangKeCongNoTheoHoaDon();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_BangKeChiTietThuTienTheoHoaDon";
            command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";

            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_BangKeChiTietThuTienTheoHoaDon;1";
            _DataSet.Tables.Add(table);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";
            _DataSet.Tables.Add(table1);

            Report.SetDataSource(_DataSet);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void bảngKêCôngNợTheoKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChungTu = (ChungTu)(DSChungTu_BindingSource.Current);

            DataSet _DataSet = new DataSet();
            ReportDocument Report = new PSC_ERP.Report.CongNo.BangKeCongNoTheoKhachHang();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_BangKeCongNoPhaiThuTheoKhachHang";
            command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";

            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_BangKeCongNoPhaiThuTheoKhachHang;1";
            _DataSet.Tables.Add(table);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";
            _DataSet.Tables.Add(table1);

            Report.SetDataSource(_DataSet);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }

        private void BangKeCongNoPhaiThuHoaDonTheoHanThanhToanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ChungTu = (ChungTu)(DSChungTu_BindingSource.Current);

            DataSet _DataSet = new DataSet();
            ReportDocument Report = new PSC_ERP.Report.CongNo.BangKeCongNoPhaiThuHoaDonTheoHanThanhToan();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_BangKeCongNoPhaiThuHoaDonTheoHanThanhToan";
            command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";

            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_BangKeCongNoPhaiThuHoaDonTheoHanThanhToan;1";
            _DataSet.Tables.Add(table);

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";
            _DataSet.Tables.Add(table1);

            Report.SetDataSource(_DataSet);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = Report;
            dlg.Show();
        }
        #endregion

        #region frmTimChungTu_FormClosed
        private void frmTimChungTu_FormClosed(object sender, FormClosedEventArgs e)
        {

            // this.Close();
        }
        #endregion

        private void frmTimChungTu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Main.frmMain.LoadHelp(this, "Danh Sach Chung Tu", "Help_CongNo.chm");
            }
        }

        private void btn_Tim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

            }
        }

        private void frmTimChungTu_Load(object sender, EventArgs e)
        {

        }
        #region LoadPage
        void LoadPage()
        {
            //
            string TuNgay = "";
            string DenNgay = "";
            int loai = 0;
            //if (KiemTraTuNgayDenNgay(txtu_DieuKienTim.Text))
            //{
            //    string[] mang = txtu_DieuKienTim.Text.Split('-');
            //    TuNgay = mang[0].Trim();
            //    DenNgay = mang[1].Trim();
            //    loai = 1;
            //}
            ////

            //TrangBo = (TrangChon - 1) * PageSize;
            _ChungTuList = ChungTuList.TimChungTu_Paging(txtu_DieuKienTim.Text, TrangBo, PageSize, ERP_Library.Security.CurrentUser.Info.UserID, loai, TuNgay, DenNgay, this.MaLoaiChungTu);
            DSChungTu_BindingSource.DataSource = _ChungTuList;
        }
        #endregion

        private void cboTrang_TextChanged(object sender, EventArgs e)
        {
            //if (cboTrang.Text != null || cboTrang.Text != "")
            //{
            //  TrangChon = int.Parse(cboTrang.Text);
            LoadPage();
            // }
        }

        private void grdu_DSKhachHang_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            ChungTu ct = (ChungTu)(DSChungTu_BindingSource.Current);
            //   _ChungTu1 = ChungTu.GetChungTu(ct.MaChungTu);
            _ChungTu1 = ct;
            DaChon = true;
            this.Close();
        }

        private void grdu_DSKhachHang_CellChange(object sender, CellEventArgs e)
        {

            if (grdu_DSKhachHang.ActiveCell == grdu_DSKhachHang.ActiveRow.Cells["Chon"])
            {
                bool value = (bool)grdu_DSKhachHang.ActiveCell.Value;


            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string soct = "";
            List<long> mang = new List<long>();
            for (int i = 0; i < grdu_DSKhachHang.Rows.Count; i++)
            {
                if ((bool)grdu_DSKhachHang.Rows[i].Cells["Chon"].Value == true)
                {
                    soct += (string)grdu_DSKhachHang.Rows[i].Cells["SoChungTu"].Value + ", ";
                    mang.Add((long)grdu_DSKhachHang.Rows[i].Cells["MaChungTu"].Value);

                }
            }
            soct = soct.Remove(soct.Length - 2, 2);
            if (MessageBox.Show("Bạn Có Muốn Xóa Chứng Từ Số " + soct + " ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                for (int i = 0; i < mang.Count; i++)
                {
                    for (int j = 0; j < _ChungTuList.Count; j++)
                    {
                        if (mang[i] == _ChungTuList[j].MaChungTu)
                        {
                            try
                            {
                                ChungTu.DeleteChungTu(_ChungTuList[j]);
                                MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch
                            {

                                MessageBox.Show("Lỗi khi đang xóa chứng từ số " + _ChungTuList[j].SoChungTu, "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                                return;
                            }

                            break;
                        }
                    }
                }
            }

        }
        bool KiemTraTuNgayDenNgay(string dkTim)
        {
            int count = 0;
            string tam = "";
            for (int i = 0; i < dkTim.Length; i++)
            {
                tam = dkTim.Substring(i, 1);
                if (tam == "/")
                    count++;
            }
            if (count == 4)
            {
                //

                string[] mang = txtu_DieuKienTim.Text.Split('-');
                if (mang.Length != 2)
                    return false;
                string[] TuNgay = mang[0].Trim().Split('/');
                string[] DenNgay = mang[1].Trim().Split('/');
                if (TuNgay.Length != 3 || DenNgay.Length != 3)
                    return false;
                try
                {
                    if (int.Parse(TuNgay[0]) < 0 || int.Parse(DenNgay[0]) < 0 || int.Parse(TuNgay[0]) > 31 || int.Parse(DenNgay[0]) > 31)
                        return false;
                    if (int.Parse(TuNgay[1]) < 0 || int.Parse(DenNgay[1]) < 0 || int.Parse(TuNgay[1]) > 12 || int.Parse(DenNgay[1]) > 12)
                        return false;
                    int.Parse(TuNgay[2]);
                    int.Parse(DenNgay[2]);

                }
                catch
                {

                    return false;
                }

                //
                return true;
            }
            else
                return false;
        }

        private void grdu_DSKhachHang_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

           // LoaiIn(4);
            InHangLoatPhieuChi(4);
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            InHangLoatPhieuChi(5);
            
        }

        private void InHangLoatPhieuChi(int loaiin)
        {
            _ChungTu = (ChungTu)(DSChungTu_BindingSource.Current);
            #region Phieu Chi
            foreach (ChungTu ct in _ChungTuList)
            {
                if (ct.Chon == true)
                {
                    _ChungTu = ct;
                    DataSet _DataSet = new DataSet();
                    SqlCommand command = new SqlCommand();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();

                    SqlCommand command1 = new SqlCommand();
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.CommandText = "spd_REPORT_ReportHeader";
                    command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);


                    SqlCommand command2 = new SqlCommand();
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.CommandText = "spd_LayNoTaiKhoan_1";
                    command2.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlCommand command3 = new SqlCommand();
                    command3.CommandType = CommandType.StoredProcedure;
                    command3.CommandText = "spd_LayCoTaiKhoan_1";
                    command3.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    command3.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlCommand command4 = new SqlCommand();
                    command4.CommandType = CommandType.StoredProcedure;
                    command4.CommandText = "spd_LayNguoiKyTenCongNo";
                    command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                    SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
                    DataTable table1 = new DataTable();
                    adapter1.Fill(table1);
                    table1.TableName = "spd_REPORT_ReportHeader;1";
                    _DataSet.Tables.Add(table1);

                    SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
                    DataTable table2 = new DataTable();
                    adapter2.Fill(table2);
                    table2.TableName = "spd_LayNoTaiKhoan_1;1";
                    _DataSet.Tables.Add(table2);

                    SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
                    DataTable table3 = new DataTable();
                    adapter3.Fill(table3);
                    table3.TableName = "spd_LayCoTaiKhoan_1;1";
                    _DataSet.Tables.Add(table3);

                    SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                    DataTable table4 = new DataTable();
                    adapter4.Fill(table4);
                    table4.TableName = "spd_LayNguoiKyTenCongNo;1";
                    _DataSet.Tables.Add(table4);

                    if (loaiin == 5)
                    {
                        if (_ChungTu.LoaiChungTu.MaLoaiCT == 3)// phiếu chi
                        {
                            //SqlCommand command = new SqlCommand();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "spd_CongNo_PhieuChi";
                            command.Parameters.AddWithValue("@MaPhieuChi", _ChungTu.MaChungTu);
                            command.Parameters.AddWithValue("@SoCTKemTheo", 0);
                            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                            Report = new Report.CongNo.PhieuChi();
                            adapter.Fill(table);
                            table.TableName = "spd_CongNo_PhieuChi;1";
                            _DataSet.Tables.Add(table);
                        }
                        else if (_ChungTu.LoaiChungTu.MaLoaiCT == 2)// phiếu thu
                        {

                            // SqlCommand command = new SqlCommand();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "spd_CongNo_PhieuThu";
                            command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                            command.Parameters.AddWithValue("@SoCTKemTheo", 0);
                            command4.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                            Report = new Report.CongNo.PhieuThu();
                            // SqlDataAdapter adapter = new SqlDataAdapter(command);
                            //DataTable table = new DataTable();
                            adapter.Fill(table);
                            table.TableName = "spd_CongNo_PhieuThu;1";
                            _DataSet.Tables.Add(table);

                        }
                        else if (_ChungTu.LoaiChungTu.MaLoaiCT == 16)// phiếu thu
                        {
                            //SqlCommand command = new SqlCommand();
                            Report = new Report.CongNo.ChungTuGhiSo();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "spd_BaoCaoChungTuGhiSo";
                            command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                            //DataTable table = new DataTable();
                            adapter.Fill(table);
                            table.TableName = "spd_BaoCaoChungTuGhiSo;1";
                            _DataSet.Tables.Add(table);

                        }
                    }
                    else if (loaiin == 4 ) //2) // In phieu thu
                    {
                        // Report = new Report.CongNo.PhieuChiA4();
                        if (_ChungTu.LoaiChungTu.MaLoaiCT == 3)// phiếu chi
                        {
                            //SqlCommand command = new SqlCommand();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "spd_CongNo_PhieuChi";
                            command.Parameters.AddWithValue("@MaPhieuChi", _ChungTu.MaChungTu);
                            command.Parameters.AddWithValue("@SoCTKemTheo", 0);
                            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                            Report = new Report.CongNo.PhieuChiA4();
                            adapter.Fill(table);
                            table.TableName = "spd_CongNo_PhieuChi;1";
                            _DataSet.Tables.Add(table);
                        }
                        else if (_ChungTu.LoaiChungTu.MaLoaiCT == 2)// phieu chi
                        {
                            // SqlCommand command = new SqlCommand();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "spd_CongNo_PhieuThu";
                            command.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                            command.Parameters.AddWithValue("@SoCTKemTheo", 0);
                            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                            Report = new Report.CongNo.PhieuThuA4();
                            // SqlDataAdapter adapter = new SqlDataAdapter(command);
                            //DataTable table = new DataTable();
                            adapter.Fill(table);
                            table.TableName = "spd_CongNo_PhieuThu;1";
                            _DataSet.Tables.Add(table);
                        }
                        else if (_ChungTu.LoaiChungTu.MaLoaiCT == 16)// phieu chi
                        {
                            //SqlCommand command = new SqlCommand();
                            Report = new Report.CongNo.ChungTuGhiSoA4();
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "spd_BaoCaoChungTuGhiSo";
                            command.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
                            //DataTable table = new DataTable();
                            adapter.Fill(table);
                            table.TableName = "spd_BaoCaoChungTuGhiSo;1";
                            _DataSet.Tables.Add(table);
                        }

                        if (table.Rows.Count == 0)
                        {
                            MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }


                    Report.SetDataSource(_DataSet);
                    frmHienThiReport dlg = new frmHienThiReport();
                    dlg.crytalView_HienThiReport.ReportSource = Report;
                    Report.PrintToPrinter(1, false, -1, -1);
                }
            }
            //dlg.Show();
            #endregion


        }


    }
}