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
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraReports.Parameters;
using PSC_ERP;
using ERP_Library.ThanhToan;
using System.IO;

namespace PSC_ERP
{// 4-1-2010
    public partial class frmTimChungTuNew : Form
    {
        //DateTime _tuNgay = DateTime.Today.AddMonths(-6).Date;
        //DateTime _denNgay = DateTime.Today.Date;

        DateTime _tuNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year, 7, 1) : new DateTime(DateTime.Today.Year - 1, 7, 1);
        DateTime _denNgay = DateTime.Today.Month > 6 ? new DateTime(DateTime.Today.Year + 1, 6, 30) : new DateTime(DateTime.Today.Year, 6, 30);

        public bool DaChon = false;
        ChungTuRutGonList _ChungTuList;
        ChungTuRutGon _ChungTu = ChungTuRutGon.NewChungTuRutGon();

        public ChungTuRutGon _ChungTu1 = ChungTuRutGon.NewChungTuRutGon();


        // by loc dung chung cho form chung tu hoa don
        string _tenfrm = ""; // chung tu hoa don
        DataSet dataSet = new DataSet();
        int UserID = ERP_Library.Security.CurrentUser.Info.UserID;
        ChungTu _chungTuCanDeCopy = ChungTu.NewChungTu();

        private string _MaLoaiCTQL = "";

        public int MaLoaiChungTu;

        public bool isCopyPassChungTu = false;
        public ChungTu chungTuMoi;

        public frmTimChungTuNew()
        {
            InitializeComponent();
            txtu_DieuKienTim.Focus();
            ChungTu_BindingSource.DataSource = typeof(ChungTuRutGonList);
        }
        public frmTimChungTuNew(string tenfrm)
        {
            InitializeComponent();
            txtu_DieuKienTim.Focus();
            ChungTu_BindingSource.DataSource = typeof(ChungTuRutGonList);
            _tenfrm = tenfrm;
            tlslblXoa.Enabled = false;
        }
        public frmTimChungTuNew(int maLoaiChungTu)
        {
            InitializeComponent();
            tlslblInA4New.Visible = false;
            txtu_DieuKienTim.Focus();
            this.MaLoaiChungTu = maLoaiChungTu;
            _MaLoaiCTQL = LoaiChungTuDev.GetLoaiChungTuDev(MaLoaiChungTu).MaLoaiCTQuanLy;
            ChungTu_BindingSource.DataSource = typeof(ChungTuRutGonList);
            dateTuNgay.Value = _tuNgay;
            dateDenNgay.Value = _denNgay;
            LoadChungTu();
            FormatForm();//
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
                col.CellClickAction = CellClickAction.RowSelect;
            }

            //grdData.DisplayLayout.Bands[0].Columns["Chon"].CellClickAction = CellClickAction.EditAndSelectText;

            //grdData.DisplayLayout.Bands[0].Columns["Chon"].Header.Caption = "Ch???n";
            //grdData.DisplayLayout.Bands[0].Columns["Chon"].Header.VisiblePosition = 0;
            //grdData.DisplayLayout.Bands[0].Columns["Chon"].Width = 15;
            //grdData.DisplayLayout.Bands[0].Columns["Chon"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["Chon"].CellActivation = Activation.AllowEdit;

            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Header.Caption = "STT";
            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Header.VisiblePosition = 1;
            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Hidden = true;
            grdData.DisplayLayout.Bands[0].Columns["SoTT"].Width = 40;

            grdData.DisplayLayout.Bands[0].Columns["NgayThucHien"].Header.Caption = "Ng??y Ch???ng t???";
            grdData.DisplayLayout.Bands[0].Columns["NgayThucHien"].Header.VisiblePosition = 2;
            grdData.DisplayLayout.Bands[0].Columns["NgayThucHien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayThucHien"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["NgayThucHien"].SortIndicator = SortIndicator.Descending;

            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "S??? Ch???ng T???";
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 3;
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;

            grdData.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.Caption = "?????i T?????ng";
            grdData.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Header.VisiblePosition = 4;
            grdData.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Width = 200;
            grdData.DisplayLayout.Bands[0].Columns["TenDoiTuong"].Hidden = false;

            //grdData.DisplayLayout.Bands[0].Columns["NgapLap"].Header.Caption = "Ng??y L???p";
            //grdData.DisplayLayout.Bands[0].Columns["NgapLap"].Header.VisiblePosition = 3;
            //grdData.DisplayLayout.Bands[0].Columns["NgapLap"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["NgapLap"].Width = 100;

            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Di???n Gi???i";
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 5;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 300;

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "S??? Ti???n";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 7;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;


            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.Caption = "Ng?????i l???p";
            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Header.VisiblePosition = 10;
            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["TenDangNhap"].Width = 100;


            //grdData.DisplayLayout.Bands[0].Columns.Add("SoHoa", "");
            //grdData.DisplayLayout.Bands[0].Columns["SoHoa"].Hidden = false;
            //grdData.DisplayLayout.Bands[0].Columns["SoHoa"].EditorComponent = txtSoHoaChungTu;
            //grdData.DisplayLayout.Bands[0].Columns["SoHoa"].CellActivation = Activation.ActivateOnly;
            //grdData.DisplayLayout.Bands[0].Columns["SoHoa"].ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always;
            //grdData.DisplayLayout.Bands[0].Columns["SoHoa"].Header.VisiblePosition = 6;
            //grdData.DisplayLayout.Bands[0].Columns["SoHoa"].Width = 40;
        }

        private void LoadChungTu()
        {
            if (_tenfrm == "CTHD")
            {
                _ChungTuList = ChungTuRutGonList.GetChungTuListAll(_tuNgay, _denNgay);
                this.ChungTu_BindingSource.DataSource = _ChungTuList;
            }
            else
            {
                _ChungTuList = ChungTuRutGonList.GetChungTuList_1(MaLoaiChungTu, _tuNgay, _denNgay);
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
            int soChungTuKemTheo = 0;
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_ChuoiHachToan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToan";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";

                }
                //tao spd_CongNo_PhieuChi
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CongNo_PhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoCTKemTheo ", soChungTuKemTheo);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuChi;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_
                //HeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us 

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
                    MessageBox.Show(this, "L??u d??? li???u tr?????c khi in.", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show(this, "L??u d??? li???u tr?????c khi in.", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show(this, "L??u d??? li???u tr?????c khi in.", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            else if (_ChungTu.MaLoaiChungTu == 15) // Phi???u ??i???u ch???nh k??? to??n
            {

                if (loaiIn == 5)
                {
                    Report = new PSC_ERP.Report.CongNo.PhieuDieuChinhKeToanA5();
                }
                else if (loaiIn == 4)
                {
                    Report = new PSC_ERP.Report.CongNo.PhieuDieuChinhKeToanA4();
                }


                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[spd_PhieuDieuChinhKeToan]";
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
                table.TableName = "spd_PhieuDieuChinhKeToan;1";
                _DataSet.Tables.Add(table);

                if (table.Rows.Count == 0)
                {
                    MessageBox.Show(this, "L??u d??? li???u tr?????c khi in.", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        }
        #endregion

        private void inB???ngK??ChiTi???tToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void inPhi???uChuy???nKho???nToolStripMenuItem_Click(object sender, EventArgs e)
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
                MessageBox.Show(this, "Phi???u n??y kh??ng c?? Phi???u Chuy???n Kho???n", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void b???ngK??ChiTi???tThuTi???nTheoH??a????nToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void b???ngK??C??ngN???TheoKh??chH??ngToolStripMenuItem_Click(object sender, EventArgs e)
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

            if (grdData.DisplayLayout.Bands[0].ColumnFilters["NgayThucHien"].FilterConditions.Count > 0)
                grdData.DisplayLayout.Bands[0].ColumnFilters["NgayThucHien"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            else
                grdData.DisplayLayout.Bands[0].ColumnFilters["NgayThucHien"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

            //if (grdData.DisplayLayout.Bands[0].ColumnFilters["NgayLap"].FilterConditions.Count > 0)
            //    grdData.DisplayLayout.Bands[0].ColumnFilters["NgayLap"].FilterConditions[0].CompareValue = txtu_DieuKienTim.Text;
            //else
            //    grdData.DisplayLayout.Bands[0].ColumnFilters["NgayLap"].FilterConditions.Add(FilterComparisionOperator.Contains, txtu_DieuKienTim.Text);

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
                KhoaSo_UserList khoaso = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap((DateTime)grdData.Rows[i].Cells["NgayThucHien"].Value);

                if (khoaso.Count > 0)
                {
                    if (khoaso[0].KhoaSo == true)
                    {
                        MessageBox.Show(this, "???? kh??a s???,xin vui l??ng ki???m tra l???i", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                if ((bool)grdData.Rows[i].Cells["Chon"].Value == true)
                {
                    soct += (string)grdData.Rows[i].Cells["SoChungTu"].Value + ", ";
                    mang.Add((long)grdData.Rows[i].Cells["MaChungTu"].Value);

                }
            }
            soct = soct.Remove(soct.Length - 2, 2);
            if (MessageBox.Show("B???n C?? Mu???n X??a Ch???ng T??? S??? " + soct + " ?", "Th??ng B??o", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                                MessageBox.Show(this, "X??a Th??nh C??ng ", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch
                            {

                                MessageBox.Show("L???i khi ??ang x??a ch???ng t??? s??? " + _ChungTuList[j].SoChungTu, "Th??ng B??o", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
                        MessageBox.Show(ct.SoChungTu + " c?? qu?? nhi???u chi ti???t, kh??ng th??? in tr??n kh??? A5", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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
                            if (_ChungTu.MaLoaiChungTu == 3)// phi???u chi
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
                            else if (_ChungTu.MaLoaiChungTu == 2)// phi???u thu
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
                            else if (_ChungTu.MaLoaiChungTu == 16)// phi???u thu
                            {
                                //SqlCommand command = new SqlCommand();

                                //T??ch ra T??i ch??nh v?? c??c ban kh??c Th??nh s???a
                                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                                {
                                    Report = new Report.CongNo.ChungTuGhiSo();
                                }
                                else
                                {
                                    Report = new Report.CongNo.ChungTuGhiSo_DVC2();
                                }
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
                            if (_ChungTu.MaLoaiChungTu == 3)// phi???u chi
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

                                //T??ch ra T??i ch??nh v?? c??c ban kh??c Th??nh s???a
                                if (ERP_Library.Security.CurrentUser.Info.MaBoPhan == 9)
                                {
                                    Report = new Report.CongNo.ChungTuGhiSoA4();
                                }
                                else
                                {
                                    Report = new Report.CongNo.ChungTuGhiSoA4_DVC2();
                                }
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
                                MessageBox.Show(this, "L??u d??? li???u tr?????c khi in.", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public bool PhieuChi()//[dbo].[spd_ChuoiHachToan], [dbo].[spd_CongNo_PhieuChi]
        {

            int soChungTuKemTheo = 0;
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_ChuoiHachToan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToan";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";

                }
                //tao spd_CongNo_PhieuChi
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CongNo_PhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoCTKemTheo ", soChungTuKemTheo);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuChi;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }//END Phieu Chi

        public bool Inspd_CongNo_PhieuThu() //Thang
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToan";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";

                }
                //tao Inspd_CongNo_PhieuThu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CongNo_PhieuThu";
                    cm.Parameters.AddWithValue("@MaPhieuThu", _ChungTu.MaChungTu);
                    cm.Parameters.AddWithValue("@SoCTKemTheo", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuThu";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }

        public bool PhieuKeToan()//[dbo].[spd_BaoCaoChungTuGhiSo] 
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_BaoCaoChungTuGhiSo
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoChungTuGhiSo";
                    cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_BaoCaoChungTuGhiSo;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }//END Phieu Ke Toan

        private void InNhieuPhieu(string loaiPhieu)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate(loaiPhieu);//PhieuChi1A4 PhieuChi1A5
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                //frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserID, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserID;
                    _reportTemplate.DenNgay = dtDenNgay;
                }


                foreach (ChungTuRutGon ct in _ChungTuList)
                {
                    if (ct.Chon == true)
                    {
                        _ChungTu = ct;
                        if (loaiPhieu != "PhieuKeToanA4")
                            if (ChungTu.GetChungTu(ct.MaChungTu).DinhKhoan.ButToan.Count > 3)//&& loaiin == 5)
                            {
                                MessageBox.Show(ct.SoChungTu + " c?? qu?? nhi???u chi ti???t, kh??ng th??? in tr??n kh??? A5", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            }
                            else
                            {
                                if (_report.TenPhuongThuc != "")
                                {
                                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                                }
                                //frm.HienThiReport(_reportTemplate, dataSet);
                                //frm.Show();      
                                XtraReport XReport = new XtraReport();
                                if (_reportTemplate.Data != null)
                                {
                                    XReport.LoadLayout(new MemoryStream(_reportTemplate.Data));
                                    XReport.DataSource = dataSet;
                                }
                                XReport.Print();
                            }
                    }
                }
            }
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
                KhoaSo_UserList khoaso = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap((DateTime)grdData.Rows[i].Cells["NgayThucHien"].Value);

                if (khoaso.Count > 0)
                {
                    if (khoaso[0].KhoaSo == true)
                    {
                        MessageBox.Show(this, "???? kh??a s???,xin vui l??ng ki???m tra l???i", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                if ((bool)grdData.Rows[i].Cells["Chon"].Value == true)
                {
                    string soChungTu = ""; long maChungTu = 0;
                    soChungTu = (string)grdData.Rows[i].Cells["SoChungTu"].Value;
                    maChungTu = (long)grdData.Rows[i].Cells["MaChungTu"].Value;

                    ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu(maChungTu);
                    if (ct.Count > 0)
                    {
                        ct[0].SoChungTu = soChungTu;
                        ct.ApplyEdit();
                        ct.Save();
                    }
                }
            }
            MessageBox.Show(this, "C???p nh???t Th??nh C??ng ", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void tlslblInA4New_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            ChungTu_BindingSource.EndEdit();
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);
            switch (_ChungTu.MaLoaiChungTu)
            {
                case 2:
                    InNhieuPhieu("PhieuThuA4_2");
                    break;
                case 3:
                    InNhieuPhieu("PhieuChi1A4");
                    break;
                case 16:
                    InNhieuPhieu("PhieuKeToanA4");
                    break;
                default:
                    break;
            }


        }

        private void tlslblInA5New_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            ChungTu_BindingSource.EndEdit();
            _ChungTu = (ChungTuRutGon)(ChungTu_BindingSource.Current);
            switch (_ChungTu.MaLoaiChungTu)
            {
                case 2:
                    InNhieuPhieu("PhieuThuA5_2");
                    break;
                case 3:
                    InNhieuPhieu("PhieuChi1A5");
                    break;
                case 16:
                    InNhieuPhieu("PhieuKeToanA5");
                    break;
                default:
                    break;
            }
        }

        private void CopyChungTu()
        {
            _chungTuCanDeCopy = ChungTu.NewChungTu();

            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Vui l??ng ch???n d??? li???u c???n copy.", "Th??ng B??o", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            //
            long maChungTu = ((ChungTuRutGon)ChungTu_BindingSource.Current).MaChungTu;

            ChungTuList ct = ChungTuList.GetChungTuListByMaChungTu_New(maChungTu);
            if (ct.Count > 0)
            {
                _chungTuCanDeCopy = ct[0];
            }

            //_chungTuCanDeCopy = ChungTu.GetChungTu(maChungTu);

            if (_chungTuCanDeCopy.NgayThucHien.Year <= Convert.ToDateTime("31-12-2013").Year)
            {
                MessageBox.Show("Ch???ng t??? c?? n??m [" + _chungTuCanDeCopy.NgayLap.Year + "] kh??ng th??? copy.", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _chungTuCanDeCopy = null;
            }
        }

        private void copyCh???ngT???ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyChungTu();
        }

        private void PassChungTu()
        {
            if (_chungTuCanDeCopy != null)
            {
                if (_chungTuCanDeCopy.MaChungTu != 0)
                {
                    //L???y d??? li???u cho ti???n t??? d???a v??o ch???ng t??? copy
                    TienTe tienTe = TienTe.GetTienTe(_chungTuCanDeCopy.MaChungTu);

                    //Kh???i t???o ch???ng t??? m???i
                    //ChungTu chungTuMoi = ChungTu.NewChungTu();
                    this.chungTuMoi = ChungTu.NewChungTu();

                    //L???y d??? li???u cho ch???ng t??? m???i
                    chungTuMoi.MaDoiTuongThuChi = _chungTuCanDeCopy.MaDoiTuongThuChi;
                    chungTuMoi.NgayLap = DateTime.Now.Date;
                    chungTuMoi.NgayThucHien = DateTime.Now.Date;
                    //chungTuMoi.NgayLapString = (_chungTuCanDeCopy.NgayLapString + "") == "" ? "" : DateTime.Now.Date.ToString("dd/MM/yyyy");
                    if (this.MaLoaiChungTu == 7 || this.MaLoaiChungTu == 24)
                    {
                        chungTuMoi.NgayLapString = "";
                    }
                                        
                    chungTuMoi.DienGiai = _chungTuCanDeCopy.DienGiai;
                    chungTuMoi.SoChungTuKemTheo = _chungTuCanDeCopy.SoChungTuKemTheo;
                    chungTuMoi.LoaiChungTu = _chungTuCanDeCopy.LoaiChungTu;
                    chungTuMoi.DoiTuong = _chungTuCanDeCopy.DoiTuong;
                    chungTuMoi.MaPhuongThucThanhToan = _chungTuCanDeCopy.MaPhuongThucThanhToan;
                    chungTuMoi.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;


                    chungTuMoi.ChungTu_DiaChi.Ten = _chungTuCanDeCopy.ChungTu_DiaChi.Ten;
                    chungTuMoi.ChungTu_DiaChi.DiaChi = _chungTuCanDeCopy.ChungTu_DiaChi.DiaChi;

                    chungTuMoi.BoSungChungTuKT.MaTaiKhoanNH = _chungTuCanDeCopy.BoSungChungTuKT.MaTaiKhoanNH;
                    chungTuMoi.BoSungChungTuKT.MaTaiKhoanNHDoiTac = _chungTuCanDeCopy.BoSungChungTuKT.MaTaiKhoanNHDoiTac;
                    chungTuMoi.BoSungChungTuKT.MaTaiKhoanNHGiaoDich = _chungTuCanDeCopy.BoSungChungTuKT.MaTaiKhoanNHGiaoDich;
                    chungTuMoi.BoSungChungTuKT.MaNganHangTrungGian = _chungTuCanDeCopy.BoSungChungTuKT.MaNganHangTrungGian;
                    chungTuMoi.BoSungChungTuKT.LoaiChuyenTienNN = _chungTuCanDeCopy.BoSungChungTuKT.LoaiChuyenTienNN;
                    chungTuMoi.BoSungChungTuKT.LoaiPhiChuyenTienNN = _chungTuCanDeCopy.BoSungChungTuKT.LoaiPhiChuyenTienNN;
                    chungTuMoi.BoSungChungTuKT.MucDichMuaNgoaiTe = _chungTuCanDeCopy.BoSungChungTuKT.MucDichMuaNgoaiTe;
                    chungTuMoi.BoSungChungTuKT.NDMucDichMuaNgoaiTe = _chungTuCanDeCopy.BoSungChungTuKT.NDMucDichMuaNgoaiTe;
                    chungTuMoi.BoSungChungTuKT.PhuongThucMuaNgoaiTe = _chungTuCanDeCopy.BoSungChungTuKT.PhuongThucMuaNgoaiTe;
                    chungTuMoi.BoSungChungTuKT.TenNganHang = _chungTuCanDeCopy.BoSungChungTuKT.TenNganHang;
                    chungTuMoi.BoSungChungTuKT.TenNganHangDoiTac = _chungTuCanDeCopy.BoSungChungTuKT.TenNganHangDoiTac;

                    //chungTuMoi.BoSungChungTuKT = _chungTuCanDeCopy.BoSungChungTuKT;
                    //--L???y s??? ch???ng t??? m???i
                    //int loaitien = tienTe.MaLoaiTien;
                    //string soCTCu = ChungTu.KiemTraSoChungTuMoiNhat(16, loaitien, DateTime.Now.Year);
                    //if (soCTCu != null)
                    //{

                    //    if (chungTuMoi.MaChungTu == 0)
                    //    {
                    //        chungTuMoi.SoChungTu = ChungTu.LaySoChungTuMax(16, DateTime.Now.Year);
                    //    }
                    //}
                    //else
                    //{
                    //    chungTuMoi.SoChungTu = "";

                    //}
                    chungTuMoi.SoChungTu = PublicClass.SetSoChungTuByMaLoaiChungTu(this.MaLoaiChungTu, DateTime.Now.Date);
                    //--End  

                    //L???y d??? li???u ti???n t??? m???i
                    chungTuMoi.Tien.SoTien = tienTe.SoTien;
                    chungTuMoi.Tien.ThanhTien = tienTe.ThanhTien;
                    chungTuMoi.Tien.TiGiaQuyDoi = tienTe.TiGiaQuyDoi;
                    chungTuMoi.Tien.VietBangChu = tienTe.VietBangChu;
                    chungTuMoi.Tien.MaLoaiTien = tienTe.MaLoaiTien;

                    //L???y d??? li???u ?????nh kho???n m???i
                    chungTuMoi.DinhKhoan.LaMotNoNhieuCo = _chungTuCanDeCopy.DinhKhoan.LaMotNoNhieuCo;
                    chungTuMoi.DinhKhoan.NoCo = _chungTuCanDeCopy.DinhKhoan.NoCo;
                    chungTuMoi.DinhKhoan.GhiMucNganSach = _chungTuCanDeCopy.DinhKhoan.GhiMucNganSach;

                    //chung tu hoa don mua v??o
                    if (this.MaLoaiChungTu == 9 || this.MaLoaiChungTu == 16)
                    {
                        foreach (ChungTu_HoaDonThanhToan item in _chungTuCanDeCopy.ChungTu_HoaDonThanhToanList)
                        {
                            ChungTu_HoaDonThanhToan ct_hdtt = ChungTu_HoaDonThanhToan.NewChungTu_HoaDonThanhToan();
                            ct_hdtt.HoaDon.SoSerial = item.HoaDon.SoSerial;
                            ct_hdtt.HoaDon.GhiChu = item.HoaDon.GhiChu;
                            ct_hdtt.HoaDon.MauHoaDon = item.HoaDon.MauHoaDon;
                            ct_hdtt.HoaDon.KyHieuMauHoaDon = item.HoaDon.KyHieuMauHoaDon;
                            ct_hdtt.HoaDon.NgayLap = item.HoaDon.NgayLap;
                            ct_hdtt.HoaDon.ThueSuatVAT = item.HoaDon.ThueSuatVAT;
                            ct_hdtt.HoaDon.MaDoiTac = item.HoaDon.MaDoiTac;
                            ct_hdtt.HoaDon.KhauTruThue = item.HoaDon.KhauTruThue;
                            ct_hdtt.HoaDon.LoaiHoaDon = item.HoaDon.LoaiHoaDon;
                            chungTuMoi.ChungTu_HoaDonThanhToanList.Add(ct_hdtt);
                        }
                    }

                    //L???y d??? li???u b??t to??n m???i
                    foreach (ButToan item in _chungTuCanDeCopy.DinhKhoan.ButToan)
                    {
                        ButToan butToanMoi = ButToan.NewButToan();
                        butToanMoi.NoTaiKhoan = item.NoTaiKhoan;
                        butToanMoi.CoTaiKhoan = item.CoTaiKhoan;
                        if (this.MaLoaiChungTu == 9 || this.MaLoaiChungTu == 16)
                        {
                            butToanMoi.SoTien = 0;
                        }
                        else
                        {
                            butToanMoi.SoTien = item.SoTien;
                        }                        
                        butToanMoi.DienGiai = item.DienGiai;
                        butToanMoi.DoiTuongCo = item.DoiTuongCo;
                        butToanMoi.DoiTuongNo = item.DoiTuongNo;
                        butToanMoi.MaSoQuy = item.MaSoQuy;
                        butToanMoi.MaNhanVien = item.MaNhanVien;

                        //B??t to??n chi ph?? ho???t ?????ng
                        //ButToan_ChiPhiHD butToanCPHDMoi = ButToan_ChiPhiHD.NewButToan_ChiPhiHD();
                        //butToanCPHDMoi.MaBoPhan = item.ButToanChiPhiHD.MaBoPhan;
                        //butToanCPHDMoi.MaChiPhiHD = item.ButToanChiPhiHD.MaChiPhiHD;
                        //butToanCPHDMoi.TenChiPhiHD = item.ButToanChiPhiHD.TenChiPhiHD;
                        //butToanCPHDMoi.SoTien = item.ButToanChiPhiHD.SoTien;
                        //butToanCPHDMoi.TenBoPhan = item.ButToanChiPhiHD.TenBoPhan;
                        //butToanCPHDMoi.ThuChi = item.ButToanChiPhiHD.ThuChi;
                        //butToanCPHDMoi.NgayLap = DateTime.Now.Date;

                        //butToanMoi.ButToanChiPhiHD = butToanCPHDMoi;

                        //L???y b??t to??n chi ph?? s???n xu???t
                        foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat in item.ChungTuChiPhiSanXuatList)
                        {
                            ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuatMoi = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
                            chungTu_ChiPhiSanXuatMoi.SoChungTu = chungTuMoi.SoChungTu;
                            chungTu_ChiPhiSanXuatMoi.MaChuongTrinh = chungTu_ChiPhiSanXuat.MaChuongTrinh;
                            chungTu_ChiPhiSanXuat.TenChuongTrinh = chungTu_ChiPhiSanXuat.TenChuongTrinh;
                            chungTu_ChiPhiSanXuatMoi.SoTien = chungTu_ChiPhiSanXuat.SoTien;
                            chungTu_ChiPhiSanXuat.MaLoaiChiPhi = chungTu_ChiPhiSanXuat.MaLoaiChiPhi;
                            chungTu_ChiPhiSanXuatMoi.MaTaiKhoan = chungTu_ChiPhiSanXuat.MaTaiKhoan;
                            chungTu_ChiPhiSanXuatMoi.IsUpdate = chungTu_ChiPhiSanXuat.IsUpdate;

                            //L???y chi th?? lao
                            foreach (ChiThuLao chiThuLao in chungTu_ChiPhiSanXuat.ChiThuLaoList)
                            {
                                ChiThuLao chiThuLaoMoi = ChiThuLao.NewChiThuLao();
                                chiThuLaoMoi.MaChungTu = chungTuMoi.MaChungTu;
                                chiThuLaoMoi.SoChungTu = chungTuMoi.SoChungTu;
                                chiThuLaoMoi.MaBoPhanGui = chiThuLao.MaBoPhanGui;
                                chiThuLaoMoi.MaBoPhanNhan = chiThuLao.MaBoPhanNhan;
                                chiThuLaoMoi.SoTien = chiThuLao.SoTien;
                                chiThuLaoMoi.GhiChu = chiThuLao.GhiChu;
                                chiThuLaoMoi.HoanTat = chiThuLao.HoanTat;
                                chiThuLaoMoi.TenBoPhanGui = chiThuLao.TenBoPhanGui;
                                chiThuLaoMoi.TenBoPhanNhan = chiThuLao.TenBoPhanNhan;
                                chiThuLaoMoi.MaChuongTrinh = chiThuLao.MaChuongTrinh;
                                chiThuLaoMoi.TenChuongTrinh = chiThuLao.TenChuongTrinh;
                                chiThuLaoMoi.SoTienDaNhap = chiThuLao.SoTienDaNhap;
                                chiThuLaoMoi.SoTienDaNhapNgoaiDai = chiThuLao.SoTienDaNhapNgoaiDai;
                                chiThuLaoMoi.SoTienConLai = chiThuLao.SoTienConLai;
                                chiThuLaoMoi.NgayLap = DateTime.Now.Date;
                                chiThuLaoMoi.SoTienSeNhap = chiThuLao.SoTienSeNhap;
                                chiThuLaoMoi.SoTienSeNhapNgoaiDai = chiThuLao.SoTienSeNhapNgoaiDai;
                                chiThuLaoMoi.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                                chiThuLaoMoi.MaLoaiKinhPhi = chiThuLao.MaLoaiKinhPhi;
                                chiThuLaoMoi.SoTienSeNhapNgoaiDai = chiThuLao.SoTienSeNhapNgoaiDai;
                                chiThuLaoMoi.NgayThucHienChi = chiThuLao.NgayThucHienChi;
                                chiThuLaoMoi.MaTaiKhoan = chiThuLao.MaTaiKhoan;

                                //L???y chi th?? lao nh??n vi??n
                                foreach (ChiThuLao_NhanVien chiThuLao_NhanVien in chiThuLao.ChiThuLaoNhanVienList)
                                {
                                    ChiThuLao_NhanVien chiThuLao_NhanVienMoi = ChiThuLao_NhanVien.NewChiThuLao_NhanVien();
                                    chiThuLao_NhanVienMoi.MabophanNv = chiThuLao_NhanVien.MabophanNv;
                                    chiThuLao_NhanVienMoi.MaNhanVien = chiThuLao_NhanVien.MaNhanVien;
                                    chiThuLao_NhanVienMoi.SoTien = chiThuLao_NhanVien.SoTien;
                                    chiThuLao_NhanVienMoi.TenBoPhan = chiThuLao_NhanVien.TenBoPhan;
                                    chiThuLao_NhanVienMoi.TenNhanVien = chiThuLao_NhanVien.TenNhanVien;
                                    chiThuLao_NhanVienMoi.LoaiNV = chiThuLao_NhanVien.LoaiNV;

                                    chiThuLaoMoi.ChiThuLaoNhanVienList.Add(chiThuLao_NhanVienMoi);

                                }
                                chungTu_ChiPhiSanXuatMoi.ChiThuLaoList.Add(chiThuLaoMoi);
                            }
                            //L???y chi ph?? th???c hi???n
                            foreach (ChiPhiThucHien chiPhiThucHien in chungTu_ChiPhiSanXuat.ChiPhiThucHienList)
                            {
                                ChiPhiThucHien chiPhiThucHienMoi = ChiPhiThucHien.NewChiPhiThucHien();
                                chiPhiThucHienMoi.TenChungTu = chungTuMoi.SoChungTu;
                                chiPhiThucHienMoi.TenChuongTrinh = chiPhiThucHien.TenChuongTrinh;
                                chiPhiThucHienMoi.MaChuongTrinh = chiPhiThucHien.MaChuongTrinh;
                                chiPhiThucHienMoi.MaDoiTuong = chiPhiThucHien.MaDoiTuong;
                                chiPhiThucHienMoi.TenDoiTuong = chiPhiThucHien.TenDoiTuong;
                                chiPhiThucHienMoi.DiaChi = chiPhiThucHien.DiaChi;
                                chiPhiThucHienMoi.SoTien = chiPhiThucHien.SoTien;
                                chiPhiThucHienMoi.DienGiai = chiPhiThucHien.DienGiai;
                                chiPhiThucHienMoi.NgayLap = DateTime.Now.Date;
                                chiPhiThucHienMoi.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                                chiPhiThucHienMoi.MaLoaiChiPhiSanXuat = chiPhiThucHien.MaLoaiChiPhiSanXuat;

                                chungTu_ChiPhiSanXuatMoi.ChiPhiThucHienList.Add(chiPhiThucHienMoi);
                            }

                            //L???y b??t to??n m???c ng??n s??ch
                            foreach (ButToanMucNganSach butToanMucNganSach in chungTu_ChiPhiSanXuat.ButtoanMucNganSachList)
                            {
                                ButToanMucNganSach butToanMucNganSachMoi = ButToanMucNganSach.NewButToanMucNganSach();
                                butToanMucNganSachMoi.MaTieuMucNganSach = butToanMucNganSach.MaTieuMucNganSach;
                                butToanMucNganSachMoi.SoTien = butToanMucNganSach.SoTien;
                                butToanMucNganSachMoi.DienGiai = butToanMucNganSach.DienGiai;
                                chungTu_ChiPhiSanXuatMoi.ButtoanMucNganSachList.Add(butToanMucNganSachMoi);
                            }

                            butToanMoi.ChungTuChiPhiSanXuatList.Add(chungTu_ChiPhiSanXuatMoi);
                        }

                        //L???y ch???ng t??? h??a ????n
                        foreach (ChungTu_HoaDon chungTu_HoaDon in item.ChungTu_HoaDonList)
                        {
                            ChungTu_HoaDon chungTu_HoaDonMoi = ChungTu_HoaDon.NewChungTu_HoaDon();
                            chungTu_HoaDonMoi.MaHoaDon = chungTu_HoaDon.MaHoaDon;
                            chungTu_HoaDonMoi.MaPhieuNhapXuat = chungTu_HoaDon.MaPhieuNhapXuat;
                            chungTu_HoaDonMoi.SoTien = chungTu_HoaDon.SoTien;
                            chungTu_HoaDonMoi.NgayLap = DateTime.Now.Date;
                            chungTu_HoaDonMoi.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

                            butToanMoi.ChungTu_HoaDonList.Add(chungTu_HoaDonMoi);
                        }

                        //Th??m d??? li??u b??t to??n
                        chungTuMoi.DinhKhoan.ButToan.Add(butToanMoi);
                    }

                    //L??u ch???ng t??
                    //chungTuMoi.Save();

                    //LoadChungTu();
                    //MessageBox.Show("Copy Th??nh C??ng.", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DaChon = false;
                    this.isCopyPassChungTu = true;
                    this.Close();
                }
            }
        }

        private void LuuChungTuCopy()
        {
        }
        private void passCh???ngT???ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ti???n h??nh l???y d??? li???u v?? t???o m???i ch???ng t???
            PassChungTu();
        }

        private void frmTimChungTuNew_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F1)
            {
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                CopyChungTu();
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                PassChungTu();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {

            }
            else if (e.Control && e.KeyCode == Keys.U)
            {
                LoadChungTu();
            }
            else if (e.Control && e.KeyCode == Keys.E)
            {
                this.Close();
            }
        }

        private void copy_ChungTu_Click(object sender, EventArgs e)
        {
            CopyChungTu();
        }

        private void pass_ChungTu_Click(object sender, EventArgs e)
        {
            // Ti???n h??nh l???y d??? li???u v?? t???o m???i ch???ng t???
            PassChungTu();
        }

        private void txtSoHoaChungTu_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            //L???y ch???ng t??? hi???n t???i
            //ChungTuRutGon chungTuCurrent = ChungTu_BindingSource.Current as ChungTuRutGon;
            //if (chungTuCurrent != null)
            //{
            //    frmSoHoaChungTu frm = new frmSoHoaChungTu(chungTuCurrent.MaChungTu, false);
            //    frm.ShowDialog(this);
            //}
        }

        #region BoSung
        private void FormatForm()
        {
            btnLuu.Visible = false;
            if (this.MaLoaiChungTu == 16
                && BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).MaBoPhanQL != "DV02"
                )
            {
                tlSCapNhatLaiSoChungTu.Visible = true;
            }
            else
            {
                tlSCapNhatLaiSoChungTu.Visible = false;
            }

            grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].CellClickAction = CellClickAction.EditAndSelectText;

            grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].Header.Caption = "Ng??y Ghi S???";  //"Ng??y x??c nh???n UNC";
            grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].Header.VisiblePosition = 0;
            grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].Width = 100;
            grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].CellActivation = Activation.AllowEdit;

            if (_MaLoaiCTQL == "PC112" || _MaLoaiCTQL == "LCTNN" || _MaLoaiCTQL == "GBNT")
            {
                //grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].CellClickAction = CellClickAction.EditAndSelectText;

                //grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].Header.Caption = "Ng??y Ghi S???";  //"Ng??y x??c nh???n UNC";
                //grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].Header.VisiblePosition = 0;
                //grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].Width = 100;
                //grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].Hidden = false;
                //grdData.DisplayLayout.Bands[0].Columns["NgayXacNhanUNC"].CellActivation = Activation.AllowEdit;

                grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "TK Ng??n H??ng";
                grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 8;
                grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;
                grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 100;

                grdData.DisplayLayout.Bands[0].Columns["SoTienNgoaiTe"].Header.Caption = "Ti???n ngo???i t???";
                grdData.DisplayLayout.Bands[0].Columns["SoTienNgoaiTe"].Header.VisiblePosition = 6;
                grdData.DisplayLayout.Bands[0].Columns["SoTienNgoaiTe"].Hidden = false;
                grdData.DisplayLayout.Bands[0].Columns["SoTienNgoaiTe"].Width = 100;

                btnLuu.Visible = true;
            }
            else if (_MaLoaiCTQL == "PT112")
            {
                grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "TK Ng??n H??ng";
                grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 8;
                grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;
                grdData.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 100;
            }
            else if (_MaLoaiCTQL == "MuaChuaThanhToan")
            {
                grdData.DisplayLayout.Bands[0].Columns["NgayHoaDon"].Header.Caption = "Ng??y H??a ????n";
                grdData.DisplayLayout.Bands[0].Columns["NgayHoaDon"].Header.VisiblePosition = 8;
                grdData.DisplayLayout.Bands[0].Columns["NgayHoaDon"].Hidden = false;
                grdData.DisplayLayout.Bands[0].Columns["NgayHoaDon"].Width = 100;

                grdData.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.Caption = "S??? H??a ????n";
                grdData.DisplayLayout.Bands[0].Columns["SoHoaDon"].Header.VisiblePosition = 9;
                grdData.DisplayLayout.Bands[0].Columns["SoHoaDon"].Hidden = false;
                grdData.DisplayLayout.Bands[0].Columns["SoHoaDon"].Width = 100;

                grdData.DisplayLayout.Bands[0].Columns["SoTienHoaDon"].Header.Caption = "Ti???n H??a ????n";
                grdData.DisplayLayout.Bands[0].Columns["SoTienHoaDon"].Header.VisiblePosition = 10;
                grdData.DisplayLayout.Bands[0].Columns["SoTienHoaDon"].Hidden = false;
                grdData.DisplayLayout.Bands[0].Columns["SoTienHoaDon"].Width = 100;
            }
        }
        #endregion//BoSung

        private void tlSCapNhatLaiSoChungTu_Click(object sender, EventArgs e)
        {
            if (this.MaLoaiChungTu == 16)
            {
                frmCapNhatSoChungTu frm = new frmCapNhatSoChungTu(this.MaLoaiChungTu);
                if (frm.ShowDialog() != DialogResult.OK && frm.CapNhat)
                {
                    dateTuNgay.Value = (object)frm.TuNgay;
                    dateDenNgay.Value = (object)DateTime.Today.Date;
                    _ChungTuList = ChungTuRutGonList.GetChungTuList(MaLoaiChungTu, frm.TuNgay, DateTime.Today.Date);
                    this.ChungTu_BindingSource.DataSource = _ChungTuList;
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            FocustextBox.Focus();
            try
            {
                ChungTu_BindingSource.EndEdit();
                _ChungTuList.ApplyEdit();
                _ChungTuList.Save();
                MessageBox.Show("L??u Ch???ng T??? Th??nh C??ng!", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("C???p nh???t Ch???ng t??? th???t b???i!", "Th??ng B??o", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
