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
{// 9-2-2011
    public partial class frmTimChungTuNew_TheoHD : Form
    {
        DateTime _tuNgay = DateTime.Today.AddMonths(-6).Date;
        DateTime _denNgay = DateTime.Today.Date;
        public bool DaChon = false;
        ChungTuRutGonList _ChungTuList;
        ChungTuRutGon _ChungTu = ChungTuRutGon.NewChungTuRutGon();

        public ChungTuRutGon _ChungTu1 = ChungTuRutGon.NewChungTuRutGon();
     

        // by loc dung chung cho form chung tu hoa don
        string _tenfrm = ""; // chung tu hoa don

        public int MaLoaiChungTu;
        public frmTimChungTuNew_TheoHD()
        {
            InitializeComponent();
            txtu_DieuKienTim.Focus();
            ChungTu_BindingSource.DataSource = typeof(ChungTuRutGonList);
        }
        public frmTimChungTuNew_TheoHD(string tenfrm)
        {
            InitializeComponent();
            txtu_DieuKienTim.Focus();
            ChungTu_BindingSource.DataSource = typeof(ChungTuRutGonList);
            _tenfrm = tenfrm;
            tlslblXoa.Enabled = false;
        }
        public frmTimChungTuNew_TheoHD(int maLoaiChungTu)
        {
            InitializeComponent();
            txtu_DieuKienTim.Focus();
            this.MaLoaiChungTu = maLoaiChungTu;
            ChungTu_BindingSource.DataSource = typeof(ChungTuRutGonList);
            dateTuNgay.Value = _tuNgay;
            dateDenNgay.Value = _denNgay;
            LoadChungTu();
        }
       
        private void grdu_DSKhachHang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
               
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
                col.CellActivation = Activation.AllowEdit;
            }

            grdData.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Chọn";
            grdData.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["Chon"].Width = 15;
            grdData.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;

            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Header.Caption = "STT";
            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Hidden = true;
            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Width = 40;

            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;

            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 100;

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;      


            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 5;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 400;



            grdData.DisplayLayout.Bands[0].Columns.Add("Tinhtrang","Tình Trạng");
            grdData.DisplayLayout.Bands[0].Columns["Tinhtrang"].Header.VisiblePosition = 6;
            grdData.DisplayLayout.Bands[0].Columns["Tinhtrang"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["Tinhtrang"].Width = 100;



          

        }
        private void Xulytinhtrangchungtu()
        {
            //_ChungTuList;
            ChungTu _ct = ChungTu.NewChungTu();
            int _mabuttoan = 0;
            decimal _tongtienchungtu = 0;
            decimal _tongtienhd=0;

            int taikhoan31131 = HeThongTaiKhoan1.LayMaTaiKhoan("31131");
            int taikhoan31132 = HeThongTaiKhoan1.LayMaTaiKhoan("31132");

            for (int i = 0; i < grdData.Rows.Count; i++)
            {
                //_ct = ChungTuList.GetChungTuListByMaChungTuByLoc((long)grdData.Rows[i].Cells["machungtu"].Value)[0];
                if (_ct != null)
                {
                    // viet ham dem so tai khoan no 31131 hoac 31132 va co nhieu tai khoan co
                    //if (Chungtuthueconhieubuttoan(_ct.DinhKhoan.MaDinhKhoan))  // co nhieu but toan thue
                    //{
                        //// so sanh so tien trong but toan chung tu va so tien trong hoa don neu khac thi gan tinh trang=0
                        //foreach (ButToan bt in _ct.DinhKhoan.ButToan)
                        //{
                        //    if (taikhoan31131 == bt.NoTaiKhoan || taikhoan31132 == bt.NoTaiKhoan)
                        //    {
                        _mabuttoan = (int)grdData.Rows[i].Cells["maButToan"].Value;
                        _tongtienchungtu = (decimal)grdData.Rows[i].Cells["STButToan"].Value;
                        _tongtienhd = 0;
                        _tongtienhd = LaytongtienCTtheobt(_mabuttoan);
                        if (_tongtienchungtu == _tongtienhd)
                            grdData.Rows[i].Cells["Tinhtrang"].Value = "Hoàn Tất";
                        //    }
                        //}
                    //}
                    //else
                    //{
                    //    // so sanh so tien trong but toan chung tu va so tien trong hoa don neu khac thi gan tinh trang=0
                    //    foreach (ButToan bt in _ct.DinhKhoan.ButToan)
                    //    {
                    //        if (taikhoan31131 == bt.NoTaiKhoan || taikhoan31132 == bt.NoTaiKhoan)
                    //        {
                    //            _mabuttoan = bt.MaButToan;
                    //            _tongtienchungtu = bt.SoTien;
                    //            _tongtienhd = 0;
                    //            _tongtienhd = LaytongtienCTtheobt(bt.MaButToan);
                    //            if (_tongtienchungtu == _tongtienhd)
                    //                grdData.Rows[i].Cells["Tinhtrang"].Value = "Hoàn Tất";
                    //        }
                    //    }
                    //}
                }
            }
        }
        private decimal LaytongtienCTtheobt(int mabuttoan)
        {
            decimal sotien = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_laysotienhoadontheobuttoan";
                    cm.Parameters.AddWithValue("@mabuttoan",mabuttoan);
                    sotien=(decimal)cm.ExecuteScalar();
                }
            }
            return sotien;
        }
        private bool Chungtuthueconhieubuttoan(long madinhkhoan)
        {
            int sorecord = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_kiemtrachungtuconhieubuttoan";
                    cm.Parameters.AddWithValue("@madinhkhoan", madinhkhoan);
                    sorecord = (int)cm.ExecuteScalar();
                    if (sorecord != 0)
                        return true;
                }
            }
            return false;
        }
        private void LoadChungTu()
        {
            if (_tenfrm == "CTHD")
            {
                _ChungTuList = ChungTuRutGonList.GetChungTuListAll_ByLoc(_tuNgay, _denNgay);
                this.ChungTu_BindingSource.DataSource = _ChungTuList;
                Xulytinhtrangchungtu();
            }
            else
            {
                _ChungTuList = ChungTuRutGonList.GetChungTuList(MaLoaiChungTu, _tuNgay, _denNgay);
                this.ChungTu_BindingSource.DataSource = _ChungTuList;
            }
        }          

        #region In

        #region inToolStripMenuItem_In_Click
        private ReportDocument Report;
        private void inToolStripMenuItem_In_Click(object sender, EventArgs e)
        {


        }

        public void LoaiIn(int loaiIn)
        {
            DataSet _DataSet = new DataSet();
            if (_ChungTu.MaLoaiChungTu == 2) // In phieu thu
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
            else if (_ChungTu.MaLoaiChungTu == 3) // In phieu chi
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
            else if (_ChungTu.MaLoaiChungTu == 6) // In Uy Nhiem Chi
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
            else if (_ChungTu.MaLoaiChungTu == 7) // In Uy Nhiem Thu
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
            else if (_ChungTu.MaLoaiChungTu == 8 || _ChungTu.MaLoaiChungTu == 16) // In Phieu Chuyen Khoan
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
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);
            DataSet _DataSet = new DataSet();

            if (_ChungTu.MaLoaiChungTu == 2) // In phieu thu
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
            else if (_ChungTu.MaLoaiChungTu == 3) // In phieu chi
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
            else if (_ChungTu.MaLoaiChungTu == 6) // In Bao Co
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
            else if (_ChungTu.MaLoaiChungTu == 7) // In Bao No
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
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);
            if (_ChungTu.MaLoaiChungTu == 6 || _ChungTu.MaLoaiChungTu == 7 || _ChungTu.MaLoaiChungTu == 8)
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
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);
            DataSet _DataSet = new DataSet();
            if (_ChungTu.MaLoaiChungTu == 6) // In Uy Nhiem Chi
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
            else if (_ChungTu.MaLoaiChungTu == 7) // In Uy Nhiem Chi
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
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);

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
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);

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
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);

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
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);

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
      
        private void txtu_DieuKienTim_ValueChanged(object sender, EventArgs e)
        {
            grdData.DisplayLayout.Bands[0].ColumnFilters.LogicalOperator = FilterLogicalOperator.Or;

            if (grdData.DisplayLayout.Bands[0].ColumnFilters["SoChungTu"].FilterConditions.Count > 0)
                grdData.DisplayLayout.Bands[0].ColumnFilters["SoChungTu"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdData.DisplayLayout.Bands[0].ColumnFilters["SoChungTu"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

            if (grdData.DisplayLayout.Bands[0].ColumnFilters["NgayLap"].FilterConditions.Count > 0)
                grdData.DisplayLayout.Bands[0].ColumnFilters["NgayLap"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdData.DisplayLayout.Bands[0].ColumnFilters["NgayLap"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

            if (grdData.DisplayLayout.Bands[0].ColumnFilters["SoTien"].FilterConditions.Count > 0)
                grdData.DisplayLayout.Bands[0].ColumnFilters["SoTien"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdData.DisplayLayout.Bands[0].ColumnFilters["SoTien"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);


        }       

        private void frmTimChungTu_Load(object sender, EventArgs e)
        {

        }     

        private void btnXoa_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            string soct = "";
            List<long> mang = new List<long>();
            for (int i = 0; i < grdData.Rows.Count; i++)
            {
                if ((bool)grdData.Rows[i].Cells["Chon"].Value == true)
                {
                    soct += (string)grdData.Rows[i].Cells["SoChungTu"].Value + ", ";
                    mang.Add((long)grdData.Rows[i].Cells["MaChungTu"].Value);

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
                                ChungTu.DeleteChungTu(ChungTu.GetChungTu(_ChungTuList[j].MaChungTu));
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
            LoadChungTu();
        }
      
    
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            ChungTu_BindingSource.EndEdit();
           // LoaiIn(4);
            InHangLoatPhieuChi(4);
        }
        private void tlslblIn_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            ChungTu_BindingSource.EndEdit();
            InHangLoatPhieuChi(5);
            
        }
        DataSet _DataSet;
        private void InHangLoatPhieuChi(int loaiin)
        {
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);
          
            #region Phieu Chi
            foreach (ChungTuRutGon ct in _ChungTuList)
            {
                if (ct.Chon == true)
                {
                    _ChungTu = ct;
                    if (ChungTu.GetChungTu(ct.MaChungTu).DinhKhoan.ButToan.Count > 3 && loaiin == 5)
                    {
                        MessageBox.Show(ct.SoChungTu + " có quá nhiều chi tiết, không thể in trên khổ A5", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                       
                         _DataSet = new DataSet();
                      
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
                            if (_ChungTu.MaLoaiChungTu == 3)// phiếu chi
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
                            else if (_ChungTu.MaLoaiChungTu == 2)// phiếu thu
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
                            else if (_ChungTu.MaLoaiChungTu == 16)// phiếu thu
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
                        else if (loaiin == 4) //2) // In phieu thu
                        {
                            // Report = new Report.CongNo.PhieuChiA4();
                            if (_ChungTu.MaLoaiChungTu == 3)// phiếu chi
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
                            else if (_ChungTu.MaLoaiChungTu == 2)// phieu chi
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
                            else if (_ChungTu.MaLoaiChungTu == 16)// phieu chi
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
            }
            //dlg.Show();
            #endregion


        }

        private void grdData_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            _ChungTu1 = (ChungTuRutGon)(ChungTu_BindingSource.Current);
            DaChon = true;
            this.Close();
        }

        private void ultraButton1_Click(object sender, EventArgs e)
        {
            _tuNgay = Convert.ToDateTime(dateTuNgay.Value);
            _denNgay = Convert.ToDateTime(dateDenNgay.Value);
            LoadChungTu();
        }

        private void grdData_CellChange(object sender, CellEventArgs e)
        {
          
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            for (int i = 0; i < grdData.Rows.Count; i++)
            {
                if ((bool)grdData.Rows[i].Cells["Chon"].Value == true)
                {
                    string soChungTu="";long maChungTu=0;
                    soChungTu = (string)grdData.Rows[i].Cells["SoChungTu"].Value;
                    maChungTu=(long)grdData.Rows[i].Cells["MaChungTu"].Value;

                    ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu(maChungTu);
                    if (ct.Count > 0)
                    {
                        ct[0].SoChungTu = soChungTu;
                        ct.ApplyEdit();
                        ct.Save();
                    }
                }
            }
            MessageBox.Show(this, "Cập nhật Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                HamDungChung.ExportToExcel(grdData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

    }
}