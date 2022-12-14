using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmUyNhiemChi_HDDV : Form
    {
        #region Properties
        private ERP_Library.ChungTuNganHangList _data;
        private string _tenNguoiNhan = "";//"Đài Truyền Hình TP HCM";

        SqlCommand command;
        ReportDocument Report;
        frmHienThiReport dlg;
        SqlDataAdapter adapter;
        DataTable table;

        int maChungTu = 0;

        #region Devexpress
        DataSet dataSet = new DataSet();
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        private bool _InmauCoSan = false;
        #endregion//Devexpress
        #endregion

        #region Loads
        public frmUyNhiemChi_HDDV()
        {
            InitializeComponent();
        }

        private void frmChungTuNganHang_Load(object sender, EventArgs e)
        {
            txtTuNgay.Value = DateTime.Today;
            txtDenNgay.Value = DateTime.Today;
            foreach (ERP_Library.ThanhToan.TaiKhoanNganHangCongTyChild item in ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList())
                grdData.DisplayLayout.ValueLists["NganHang"].ValueListItems.Add(item.MaChiTiet, item.SoTaiKhoan);
            foreach (ERP_Library.Security.UserItem useritem in ERP_Library.Security.UserList.GetUserList())
                grdData.DisplayLayout.ValueLists["NguoiLap"].ValueListItems.Add(useritem.UserID, useritem.TenDangNhap);
            LoadData();
        }

        #endregion

        #region Process
        private void LoadData()
        {
            _data = ERP_Library.ChungTuNganHangList.GetChungTuNganHangList(txtTuNgay.DateTime, txtDenNgay.DateTime, 201, 0);
            bdChungTu.DataSource = _data;
        }

        private void SaveData()
        {
            try
            {
                _data.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        #region Devexpress
        private void inUyNhiemChi(string UNCNganHang)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
                //Kiểm tra UNC Đang chọn có đúng với ngân hàng cần in không
                int iMaNganHang = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaNganHang"].Value);
                iMaNganHang = CongTy_NganHang.GetCongTy_NganHang(iMaNganHang).MaNganHang;
                long lNhomNganHang = NganHang.GetNganHang(iMaNganHang).MaNhomNganHang;
                string strTenNganHang = NhomNganHang.GetNhomNganHang(lNhomNganHang).TenNhomNganHang;
                string strUNCNganHang = UNCNganHang.Replace("A4", "");//Mốt có A khác nữa nhớ bỏ thêm vô loại trừ hết lấy chữ Eximbank thôi
                strUNCNganHang = UNCNganHang.Replace("New", "");//Mốt có A khác nữa nhớ bỏ thêm vô loại trừ hết lấy chữ Eximbank thôi
                bool bTrung = strTenNganHang.ToUpper().Contains(strUNCNganHang.Trim().ToUpper());
                if (!bTrung)
                {
                    MessageBox.Show(this, "Mẫu in Ủy Nhiệm Chi không cùng thông tin ngân hàng của Ủy Nhiệm Chi đang chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                switch (UNCNganHang)
                {
                    case "VietinBank":
                        InUNC_VietinBank();
                        break;
                    case "Vietcombank":
                        InUNC_Vietcombank();
                        break;
                    case "ACB":
                        InUNC_ACB();
                        break;
                    case "Agribank":
                        InUNC_Agribank();
                        break;
                    case "BIDV":
                        InUNC_BIDV();
                        break;

                    default:
                        Report = new Report.NganHang.UNC_BIDV();

                        break;
                }
            }
        }

        public bool Method_ReportBangKeChungTuThanhToan_TamUng()
        {
            //Kiểm tra UNC Đang chọn có đúng với ngân hàng cần in không
            int iMaNganHang = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaNganHang"].Value);
            iMaNganHang = CongTy_NganHang.GetCongTy_NganHang(iMaNganHang).MaNganHang;
            long lNhomNganHang = NganHang.GetNganHang(iMaNganHang).MaNhomNganHang;
            string strTenNganHang = NhomNganHang.GetNhomNganHang(lNhomNganHang).TenNhomNganHang;

            //Lấy thông tin Ủy Nhiệm Chi Đang Chọn
            int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaChungTu"].Value);
            decimal soTien = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTien"].Value);
            string SoTienBangChu = HamDungChung.DocTien(soTien);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_BangKeChungTuThanhToan_TamUng";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@TenDonViNhan", _tenNguoiNhan);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_BangKeChungTuThanhToan_TamUng;1";

                    foreach (DataRow row in dt.Rows)
                    {
                        if (checkBox_NgayLap.Checked == false)
                        {
                            row["NgayLap"] = DBNull.Value;
                        }
                    }
                    dataSet.Tables.Add(dt);
                }
                DataTable dt2 = new DataTable("tblParameter");
                dt2.Columns.Add("TenBoPhan", typeof(string));
                dt2.Columns.Add("TenNguoiLap", typeof(string));
                dt2.Columns.Add("TenThuTruong", typeof(string));
                dt2.Rows.Add(ERP_Library.Security.CurrentUser.Info.TenBoPhan, ERP_Library.Security.CurrentUser.Info.TenNguoiLap, ERP_Library.Security.CurrentUser.Info.TenThuTruong);
                dataSet.Tables.Add(dt2);
            }
            return true;
        }

        #region VietinBank
        private void InUNC_VietinBank()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_VietinBank");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_VietinBank()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaChungTu"].Value);
            decimal soTienConLai = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTienConLai"].Value);
            string SoTienBangChu = HamDungChung.DocTien(soTienConLai);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@TenDonViNhan", _tenNguoiNhan);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }
        #endregion//VietinBank

        #region Vietcombank
        private void InUNC_Vietcombank()
        {
            ReportTemplate _report;
            //BEGIN
            if (_InmauCoSan)
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_VCB_MauCoSan");
            }
            else
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_VCB");
            }
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_VCB()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaChungTu"].Value);
            decimal soTienConLai = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTienConLai"].Value);
            string SoTienBangChu = HamDungChung.DocTien(soTienConLai);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@TenDonViNhan", _tenNguoiNhan);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }
        #endregion//Vietcombank

        #region ACB
        private void InUNC_ACB()
        {
            //BEGIN
            ReportTemplate _report;
            if (_InmauCoSan)
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_ACB_MauCoSan");
            }
            else
            {
                _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_ACB");
            }
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_ACB()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaChungTu"].Value);
            decimal soTienConLai = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTienConLai"].Value);
            string SoTienBangChu = HamDungChung.DocTien(soTienConLai);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@TenDonViNhan", _tenNguoiNhan);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }
        #endregion//ACB

        #region Agribank
        private void InUNC_Agribank()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_Agribank");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_Agribank()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaChungTu"].Value);
            decimal soTienConLai = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTienConLai"].Value);
            string SoTienBangChu = HamDungChung.DocTien(soTienConLai);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@TenDonViNhan", _tenNguoiNhan);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }
        #endregion//Agribank

        #region BIDV
        private void InUNC_BIDV()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_Report_UNC_BIDV");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }

                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSet);
                frm.ShowDialog();
            }
            //END
        }
        public void Method_Report_UNC_BIDV()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaChungTu"].Value);
            decimal soTienConLai = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTienConLai"].Value);
            string SoTienBangChu = HamDungChung.DocTien(soTienConLai);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_UyNhiemChi";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@TenDonViNhan", _tenNguoiNhan);
                    cm.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_UyNhiemChi";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua Parameters of Report
                DataTable dtParameters = new DataTable();
                dtParameters.Columns.Add("TenBoPhan", typeof(string));
                dtParameters.Columns.Add("TenNguoiLap", typeof(string));
                dtParameters.Columns.Add("TenThuTruong", typeof(string));
                //Add dòng 1
                DataRow dr = dtParameters.NewRow();
                dr["TenBoPhan"] = nguoiky.ThuTruongTen;
                dr["TenNguoiLap"] = ERP_Library.Security.CurrentUser.Info.TenNguoiLap;
                dr["TenThuTruong"] = nguoiky.TenTongGiamDoc;
                dtParameters.Rows.Add(dr);
                dtParameters.TableName = "dtParameters";
                dataSet.Tables.Add(dtParameters);
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }//us  
        }
        #endregion//BIDV

        #endregion//Devexpress

        #endregion//Process

        #region Event
        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            if (Convert.ToBoolean(e.Rows[0].Cells["HoanTat"].Value))
            {
                MessageBox.Show("Dữ liệu đã hoàn tất nên không thể xóa!", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
            else
                e.Cancel = MessageBox.Show("Bạn có muốn xóa chứng từ này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
            e.DisplayPromptMsg = false;
        }

        private void grdData_AfterRowsDeleted(object sender, EventArgs e)
        {
            SaveData();
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            ERP_Library.ChungTuNganHang item = _data.AddNew();
            frmUyNhiemChi_HDDV_Edit f = new frmUyNhiemChi_HDDV_Edit(false);
            //item.So = item.SoPhieuMoi();
            if (f.ShowEdit(item))
            {
                int iSoChungTu = item.SoChungTu;
                item.So = item.GetSoChungTu(ref iSoChungTu).ToString() + '-' + item.GetMaUNC();
                item.SoChungTu = iSoChungTu;
                SaveData();
                LoadData();
            }
            else
            {
                _data.Remove(item);
            }
        }

        private void tlSua_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                ERP_Library.ChungTuNganHang item = (ERP_Library.ChungTuNganHang)grdData.ActiveRow.ListObject;
                frmUyNhiemChi_HDDV_Edit f = new frmUyNhiemChi_HDDV_Edit();
                item.BeginEdit();
                if (f.ShowEdit(item))
                {
                    item.ApplyEdit();
                    SaveData();
                    LoadData();
                }
                else
                    item.CancelEdit();
            }
        }

        private void grdData_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            if (e.Row.IsDataRow)
                tlSua.PerformClick();
        }

        private void Ngay_Changed(object sender, EventArgs e)
        {
            //LoadData();
        }

        private void tlIn_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                int MaChungTu = (int)grdData.ActiveRow.Cells["MaChungTu"].Value;
                frmXemIn f = new frmXemIn();
                f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoan.rdlc";
                //f.Report.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoan.rdlc";
                f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetChiTietChuyenKhoanListByNganHang(MaChungTu));
                f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", grdData.ActiveRow.Cells["DienGiai"].Value.ToString());
                f.ShowDialog();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (grdData.ActiveRow != null && grdData.ActiveRow.IsDataRow)
            {
                int MaChungTu = (int)grdData.ActiveRow.Cells["MaChungTu"].Value;
                frmXemIn f = new frmXemIn();
                f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanDVCap2.rdlc";
                //f.Report.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoan.rdlc";
                f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanList", ERP_Library.Report.ChiTietChuyenKhoanList.GetChiTietChuyenKhoanListByNganHang(MaChungTu));
                f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "VeViec", grdData.ActiveRow.Cells["DienGiai"].Value.ToString());
                f.ShowDialog();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdData);
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            try
            {
                grdData.UpdateData();
                bdChungTu.EndEdit();
                _data.ApplyEdit();
                _data.Save();

                MessageBox.Show(this, "Cập nhật thông tin thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void mnuUNC_BIDV_Click(object sender, EventArgs e)
        {
            //Ủy Nhiệm Chi BIDV
            inUyNhiemChi("BIDV");
            //Load_Report("BIDV");
        }

        private void mnuUNC_BIDV2_Click(object sender, EventArgs e)
        {
            //Ủy Nhiệm Chi BIDV
            Load_Report("BIDV New");
        }

        private void mnuUNC_DA_Click(object sender, EventArgs e)
        {
            Load_Report("Đông Á");
        }

        private void mnuUNC_Exim_Click(object sender, EventArgs e)
        {
            Load_Report("EximBank");
        }

        private void mnuUNC_Vietin_Click(object sender, EventArgs e)
        {

            //Ủy Nhiệm Chi VietinBank
            inUyNhiemChi("VietinBank");
            //Load_Report("VietinBank");
        }

        private void mnuUNC_SCB_Click(object sender, EventArgs e)
        {
            Load_Report("SCB");
        }

        private void mnuUNC_KB_Click(object sender, EventArgs e)
        {
            //Ủy Nhiệm Chi Kho bạc
            Load_Report("Kho bạc");
        }

        private void Load_Report(string UNCNganHang)
        {

            if (grdData.Selected.Rows.Count > 0)
            {
                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
                //Kiểm tra UNC Đang chọn có đúng với ngân hàng cần in không
                int iMaNganHang = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaNganHang"].Value);
                iMaNganHang = CongTy_NganHang.GetCongTy_NganHang(iMaNganHang).MaNganHang;
                long lNhomNganHang = NganHang.GetNganHang(iMaNganHang).MaNhomNganHang;
                string strTenNganHang = NhomNganHang.GetNhomNganHang(lNhomNganHang).TenNhomNganHang;
                string strUNCNganHang = UNCNganHang.Replace("A4", "");//Mốt có A khác nữa nhớ bỏ thêm vô loại trừ hết lấy chữ Eximbank thôi
                strUNCNganHang = UNCNganHang.Replace("New", "");//Mốt có A khác nữa nhớ bỏ thêm vô loại trừ hết lấy chữ Eximbank thôi
                bool bTrung = strTenNganHang.ToUpper().Contains(strUNCNganHang.Trim().ToUpper());
                if (!bTrung)
                {
                    MessageBox.Show(this, "Mẫu in Ủy Nhiệm Chi không cùng thông tin ngân hàng của Ủy Nhiệm Chi đang chọn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Lấy thông tin Ủy Nhiệm Chi Đang Chọn
                int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaChungTu"].Value);
                decimal soTien = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTien"].Value);
                string SoTienBangChu = HamDungChung.DocTien(soTien);

                switch (UNCNganHang)
                {
                    case "SCB":
                        Report = new Report.NganHang.UNC_SCB();
                        break;

                    case "Đông Á":
                        Report = new Report.NganHang.UNC_DongA();
                        break;

                    case "EximBank":
                        Report = new Report.NganHang.UNCEximbank();
                        break;

                    case "EximBank A4":
                        Report = new Report.NganHang.UNCEximbank_A4();
                        break;

                    case "BIDV":
                        Report = new Report.NganHang.UNC_BIDV();
                        break;

                    case "BIDV New":
                        Report = new Report.NganHang.UNC_BIDV_Update();
                        break;

                    case "Kho bạc":
                        Report = new Report.NganHang.UNC_KhoBac();
                        break;
                    case "Kho bạc New":
                        Report = new Report.NganHang.UNC_KhoBacTTTT();
                        break;

                    case "VietinBank":
                        Report = new Report.NganHang.UNC_VietinBank();
                        break;

                    default:
                        Report = new Report.NganHang.UNC_BIDV();

                        break;
                }


                command = new SqlCommand();

                command.CommandType = CommandType.StoredProcedure;
                if (UNCNganHang == "Kho bạc New")
                {
                    command.CommandText = "spd_Report_UyNhiemChiNew";
                }
                else
                {
                    command.CommandText = "spd_Report_UyNhiemChi";
                }

                command.Parameters.AddWithValue("@MaChungTu", maChungTu);
                command.Parameters.AddWithValue("@TenDonViNhan", _tenNguoiNhan);
                command.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    if (checkBox_NgayLap.Checked == false)
                    {
                        row["NgayLap"] = DBNull.Value;
                    }
                }
                table.TableName = "spd_Report_UyNhiemChi;1";
                Report.SetDataSource(table);

                Report.SetParameterValue("_tenBoPhan", nguoiky.ThuTruongTen);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", nguoiky.TenTongGiamDoc);

                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
            else
            {
                MessageBox.Show(this, "Vui lòng chọn Ủy Nhiệm Chi cần in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void mnuUNC_Exim_A4_Click(object sender, EventArgs e)
        {
            Load_Report("EximBank A4");
        }

        private void uNCKhoBacNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load_Report("Kho bạc New");
        }

        private void toolStripButton_BangKeThanhToan_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
                //Kiểm tra UNC Đang chọn có đúng với ngân hàng cần in không
                int iMaNganHang = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaNganHang"].Value);
                iMaNganHang = CongTy_NganHang.GetCongTy_NganHang(iMaNganHang).MaNganHang;
                long lNhomNganHang = NganHang.GetNganHang(iMaNganHang).MaNhomNganHang;
                string strTenNganHang = NhomNganHang.GetNhomNganHang(lNhomNganHang).TenNhomNganHang;

                //Lấy thông tin Ủy Nhiệm Chi Đang Chọn
                int maChungTu = Convert.ToInt32(grdData.Selected.Rows[0].Cells["MaChungTu"].Value);
                decimal soTien = Convert.ToDecimal(grdData.Selected.Rows[0].Cells["SoTien"].Value);
                string SoTienBangChu = HamDungChung.DocTien(soTien);
                Report = new Report.NganHang.BangKeChungTuThanhToan();
                command = new SqlCommand();

                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_UyNhiemChi";

                command.Parameters.AddWithValue("@MaChungTu", maChungTu);
                command.Parameters.AddWithValue("@TenDonViNhan", _tenNguoiNhan);
                command.Parameters.AddWithValue("@SoTienBangChu", SoTienBangChu);
                command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

                adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    if (checkBox_NgayLap.Checked == false)
                    {
                        row["NgayLap"] = DBNull.Value;
                    }
                }

                table.TableName = "spd_Report_UyNhiemChi;1";
                Report.SetDataSource(table);

                Report.SetParameterValue("_tenBoPhan", nguoiky.ThuTruongTen);
                Report.SetParameterValue("_tenNguoiLap", ERP_Library.Security.CurrentUser.Info.TenNguoiLap);
                Report.SetParameterValue("_tenThuTruong", nguoiky.TenTongGiamDoc);

                dlg = new frmHienThiReport();
                dlg.crytalView_HienThiReport.ReportSource = Report;
                dlg.Show();
            }
        }

        private void bt_Xem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tlsbtn_InBangKeThanhToanDev_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_ReportBangKeChungTuThanhToan_TamUng");
                if (_report != null)
                {
                    DateTime dtDenNgay = DateTime.Today;
                    frmReport frm = new frmReport();

                    ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                    if (_reportTemplate.Id == string.Empty)
                    {
                        _reportTemplate.Id = _report.Id;
                        _reportTemplate.UserID = UserId;
                        _reportTemplate.DenNgay = dtDenNgay;
                    }
                    if (_report.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                    }

                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
            }
        }

        private void mnuUNC_Vietin_Ad_042017_Click(object sender, EventArgs e)
        {
            inUyNhiemChi("VietinBank");
        }

        private void mnuUNC_Vietcombank_Click(object sender, EventArgs e)
        {
            _InmauCoSan = false;
            inUyNhiemChi("Vietcombank");
        }

        private void mnuUNC_ACB_Click(object sender, EventArgs e)
        {
            _InmauCoSan = false;
            inUyNhiemChi("ACB");
        }

        private void mnuUNC_Agribank_Click(object sender, EventArgs e)
        {
            inUyNhiemChi("Agribank");
        }


        #endregion

        private void mnuUNC_Vietcombank_MauCoSan_Click(object sender, EventArgs e)
        {
            _InmauCoSan = true;
            inUyNhiemChi("Vietcombank");
        }

        private void mnuUNC_ACB_MauCoSan_Click(object sender, EventArgs e)
        {
            _InmauCoSan = true;
            inUyNhiemChi("ACB");
        }

    }
}