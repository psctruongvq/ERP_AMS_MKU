using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.IO;
//using Demo.Report.Parameters;
using System.Reflection;
using System.Data.OleDb;
using DevExpress.Xpo;

using System.Data.SqlClient;
using ERP_Library;
using DevExpress;
using DevExpress.XtraLayout;
using PSC_ERP_Common;
//using Demo.Report;
//25/04/2013
namespace PSC_ERP
{
    public partial class frmDanhSachReportCCDC : DevExpress.XtraEditors.XtraForm
    {

        private ReportTemplate _reportTemplate;
        ReportTemplateList _reportTemplateList = ReportTemplateList.NewReportTemplateList();
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable tableNgay;
        private XtraReport report;
        DataSet dataSet = new DataSet();
        int _thuMuc = 3;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        //int UserId = 43;
        byte _PPNXKho = 0;

        private byte _LoaiInBaoCao = 1;//1: In Chi Tiết; 2:In Tổng Hợp 

        public frmDanhSachReportCCDC()
        {
            InitializeComponent();
            KiemTra();
            LoadData();
        }

        private void Init_GrdLUPPQuanLyCCDC()
        {
            DataTable _dataTable = new DataTable();

            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(2, "NX thẳng(không quản lý)");
            _dataTable.Rows.Add(3, "CCDC quản lý");
            _dataTable.Rows.Add(0, "<<Tất cả>>");


            lookUpEdit_PPNXKho.Properties.DataSource = _dataTable; 
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.Properties.NullText = "<<chọn PPNX>>";
            lookUpEdit_PPNXKho.EditValue = (byte)0;
        }

        private void LoadData()
        {
            this.dateEdit_TuNgay.DateTime = DateTime.Today;
            this.dateEdit_DenNgay.DateTime = DateTime.Today;
            //////////////////////////
            {
                BoPhanList boPhanListAll = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();//.GetBoPhanList();
                BoPhan boPhan_TatCa = BoPhan.NewBoPhan();
                boPhan_TatCa.MaBoPhanQL = "<<Tất cả>>";
                boPhan_TatCa.TenBoPhan = "<<Tất cả>>";
                boPhanListAll.Insert(0, boPhan_TatCa);
                BoPhanList_bindingSource.DataSource = boPhanListAll;
            }
            ////////////
            //////////////////////////
            {
                HeThongTaiKhoan1List taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
                HeThongTaiKhoan1 item = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
                item.SoHieuTK = "<<Tất cả>>";
                item.TenTaiKhoan = "<<Tất cả>>";
                taiKhoanList.Insert(0, item);
                heThongTaiKhoan1ListAllBindingSource.DataSource = taiKhoanList;
            }
            ////////////////////   
            {
                List<int> namList = new List<int>();
                int nam = DateTime.Today.Year;
                for (int i = nam - 10; i < nam + 10; i++)
                    namList.Add(i);
                cbNam.Properties.DataSource = namList;
                cbNam.EditValue = nam;
            }
            //////////////////////////////////

            Init_GrdLUPPQuanLyCCDC();

            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
            HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
            LoaiVTHHList_bindingSource.DataSource = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHBQ_VTList();
            NhomVTHHList_bindingSource.DataSource = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList();
            _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            reportTemplateListBindingSource.DataSource = _reportTemplateList;
        }

        private void KiemTra()
        {
            if (ERP_Library.Security.CurrentUser.Info.UserID != 39)
            {
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        private bool KiemTra(string name)
        {
            bool bFound = false;
            ReportTemplate obj = ReportTemplate.GetReportTemplate(name);
            if (obj.Data != null)
                bFound = true;
            return bFound;
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //report = new XtraReport();
            report = new Rpt_ReportMau();

            //ReportTemplate a = ReportTemplate.GetReportTemplate("PhieuThuA5_2"); //Thuyen

            frmThongTinReport frmObject = new frmThongTinReport(report, UserId, _thuMuc);

            if (frmObject.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _reportTemplate = frmThongTinReport._reportItem;

                if (_reportTemplate.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_reportTemplate.TenPhuongThuc).Invoke(this, null);
                }

                frmReport frm = new frmReport();
                //_reportTemplate.Data = a.Data;  //Thuyen
                frm.HienThiReport(_reportTemplate, dataSet);
                frm.Show();
            }
            _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            reportTemplateListBindingSource.DataSource = _reportTemplateList;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //demoReport = gridView1.GetFocusedRow() as MauReport;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _reportTemplateList.ApplyEdit();
                _reportTemplateList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void barbt_Xem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList_baoCao.Focus();
            ReportTemplate rpt = reportTemplateListBindingSource.Current as ReportTemplate;
            if (rpt != null)
            {
                DateTime denNgay = DateTime.Today;
                frmReport frm = new frmReport();

                if (!KiemTra(rpt.Id))
                {
                    XtraMessageBox.Show("Báo cáo chưa tồn tại vui lòng tạo báo cáo trước khi xem !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _reportTemplate = ReportTemplate.GetReportTemplate(rpt.Id, UserId, denNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = rpt.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = denNgay;
                }
                bool daChonParameter = false;
                if (rpt.TenPhuongThuc != "")
                {
                    daChonParameter = (bool)(this.GetType().GetMethod(rpt.TenPhuongThuc).Invoke(this, null));
                }

                if (daChonParameter == true)
                {
                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.ShowDialog();
                }
                _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
                reportTemplateListBindingSource.DataSource = _reportTemplateList;
            }
        }//end function

        #region Cac Phuong Thuc Report

        public bool spd_TongHopGiaTriCongCuDungCuLuyKeCoDenNgay()//Nu
        {
            if (ChuaChon_DenNgay())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_spd_TongHopGiaTriCongCuDungCuLuyKeCoDenNgay
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TongHopGiaTriCongCuDungCuLuyKeCoDenNgay";
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_TongHopGiaTriCongCuDungCuLuyKeCoDenNgay;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us
            return true;
        }//END spd_TongHopGiaTriCongCuDungCuLuyKeCoDenNgay

        ///
        //public void Spd_BienBanGiaoNhanCongCuDungCu()//NU
        //{
        //    dataSet = new DataSet();
        //    PhieuNhapXuat phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(Convert.ToInt64(lookUpEdit_PhieuNhapXuat.EditValue));
        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {

        //        cn.Open();
        //        //tao bang_PhieuNhapVatTu
        //        using (SqlCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.StoredProcedure;
        //            cm.CommandText = "Spd_BienBanGiaoNhanCongCuDungCu";
        //            cm.Parameters.AddWithValue("@MaPhieuNhapXuat", phieuNhapXuat.MaPhieuNhapXuat);
        //            cm.Parameters.AddWithValue("@MaPhongBan", lookUpEdit_BoPhan.EditValue);

        //            SqlDataAdapter da = new SqlDataAdapter(cm);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            dt.TableName = "Spd_BienBanGiaoNhanCongCuDungCu;1";
        //            dataSet.Tables.Add(dt);
        //        }
        //        //tao bang_ReportHeaderAndFooter
        //        using (SqlCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.StoredProcedure;
        //            cm.CommandText = "spd_ReportHeaderAndFooter";
        //            cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
        //            SqlDataAdapter da = new SqlDataAdapter(cm);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            dt.TableName = "spd_ReportHeaderAndFooter;1";
        //            dataSet.Tables.Add(dt);
        //        }

        //    }//us 
        //}//END Spd_BienBanGiaoNhanCongCuDungCu

        public bool spd_ReportHeaderAndFooter()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }//END spd_ReportHeaderAndFooter
        public bool Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan()
        {
            //cuong 
            if (ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan";
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);

                    cm.Parameters.AddWithValue("@hasManage", (byte) lookUpEdit_PPNXKho.EditValue);
                    
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan;1");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter;1");
                }
            }
            return true;
        }
        public bool Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan_NhoHon10Tr()
        {
            //cuong 
            if (ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan_NhoHon10Tr";
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan;1");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter;1");
                }
            }
            return true;
        }
        public bool Spd_ReportDSChiTietCCDCCoDenNgayTheoBoPhan_NhoHon10Tr()
        {
            //cuong 
            if (ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ReportDSChiTietCCDCCoDenNgayTheoBoPhan_NhoHon10Tr";
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan;1");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter;1");
                }
            }
            return true;
        }
        public bool Spd_ReportDSChiTietCCDCCoDenNgayTheoBoPhan_10TrTroLen()
        {
            //cuong 
            if (ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ReportDSChiTietCCDCCoDenNgayTheoBoPhan_10TrTroLen";
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "MainData");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter;1");
                }
            }
            return true;
        }
        public bool Spd_ReportDSChiTietCCDCChuaPhanBoHetDenNgayTheoBoPhan_10TrTroLen()
        {
            //cuong 
            if (ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ReportDSChiTietCCDCChuaPhanBoHetDenNgayTheoBoPhan_10TrTroLen";
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "MainData");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter;1");
                }
            }
            return true;
        }
        public bool spd_TongHopCCDC10TrTroLenChuaPhanBoHetDenNgayTheoBoPhan()//chua phan bo het
        {
            //cuong 
            if (ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TongHopCCDC10TrTroLenChuaPhanBoHetDenNgayTheoBoPhan";
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "MainData");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter;1");
                }
            }
            return true;
        }
        public bool spd_TongHopChiPhiPBCCDC() //Thang
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TongHopChiPhiPBCCDC";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_TongHopChiPhiPBCCDC");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter");
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);
            }
            return true;
        } //spd_TongHopChiPhiPBCCDC

        public bool spd_TongHopChiPhiPBCCDCByHangHoa() //Thang
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TongHopChiPhiPBCCDCByHangHoa";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_TongHopChiPhiPBCCDCByHangHoa");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter");
                }

            }
            return true;
        } //spd_TongHopChiPhiPBCCDCByHangHoa

        public bool spd_TongHopChiPhiPBCCDCByHangHoa_NhoHon10tr() //
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TongHopChiPhiPBCCDCByHangHoa_NhoHon10tr";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_TongHopChiPhiPBCCDCByHangHoa");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter");
                }
            }
            return true;
        } //spd_TongHopChiPhiPBCCDCByHangHoa_NhoHon10tr

        public bool Spd_ReportBaoCaoCongCuDungCuTangTheoTaiKhoan()
        {
            //cuong
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_TaiKhoan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                #region Old
                //using (SqlCommand cm = cn.CreateCommand())
                //{

                //    cm.CommandType = CommandType.StoredProcedure;
                //    cm.CommandText = "Spd_ReportBaoCaoCongCuDungCuTangTheoTaiKhoan";
                //    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                //    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                //    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    da.Fill(dataSet);//fill tat ca cac table tu ket qua tra ve
                //    dataSet.Tables[0].TableName = "Infos;1";
                //    dataSet.Tables[1].TableName = "MainData;1";
                //    dataSet.Tables[2].TableName = "SoDuDauNam;1";
                //    dataSet.Tables[3].TableName = "CacThangTruoc;1";


                //}
                ////tao bang_ReportHeaderAndFooter
                //using (SqlCommand cm = cn.CreateCommand())
                //{
                //    cm.CommandType = CommandType.StoredProcedure;
                //    cm.CommandText = "spd_ReportHeaderAndFooter";
                //    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    da.Fill(dataSet, "spd_ReportHeaderAndFooter;1");
                //}
                #endregion //End Old
                #region New]
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ReportBaoCaoBanGiaoCongCuDungCuTangTheoTaiKhoan";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    cm.Parameters.AddWithValue("@InCTorTH", (int)radioGroupChonInCTorTH.EditValue);
                    cm.Parameters.AddWithValue("@hasManage", (byte)lookUpEdit_PPNXKho.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_ReportBaoCaoBanGiaoCongCuDungCuTangTheoTaiKhoan;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);
                #endregion //End New
            }//
            return true;
        }
        public bool spRpt_CCDC_CongCuDungCuTang()
        {
            //cuong
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                #region Old

                #endregion //End Old
                #region New]
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_CCDC_CongCuDungCuTang";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    cm.Parameters.AddWithValue("@MaPhongBan", (int)lookUpEdit_BoPhan.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.CommandTimeout = 300;
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);
                #endregion //End New
            }//
            return true;
        }
        public bool InDSCT_CCDC_DeNghiThanhLy() //Thang
        {
            if (ChuaChon_Nam() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao Spd_DSCT_CCDC_DeNghiThanhLy
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_DSCT_CCDC_DeNghiThanhLy";
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@Nam", cbNam.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", lookUpEdit_BoPhan.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_DSCT_CCDC_DeNghiThanhLy";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

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
            return true;
        }
        public bool ChiTietPhanBoChiPhiCCDCChuyenTuTaiSan()
        {
            if (ChuaChon_Nam())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_CCDC_PhanBoChiPhiCCDCChuyenTuTaiSan";//xài chung store với TongHopPhanBoChiPhiCCDCChuyenTuTaiSan
                    cm.CommandTimeout = 900;
                    cm.Parameters.AddWithValue("@Nam", cbNam.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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
            }
            return true;
        }
        public bool TongHopPhanBoChiPhiCCDCChuyenTuTaiSan()
        {
            if (ChuaChon_Nam())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_CCDC_PhanBoChiPhiCCDCChuyenTuTaiSan";//xài chung store với ChiTietPhanBoChiPhiCCDCChuyenTuTaiSan
                    cm.Parameters.AddWithValue("@Nam", cbNam.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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
            }
            return true;
        }

        #region 19/04/2014

        public bool TongHopGiaTriCCDCLuyKeDenNgay_DonVi()
        {
            if (ChuaChon_DenNgay())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_CCDC_TongHopGiaTriCCDCLuyKe";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool ChiTietCCDCDaPhanBoHetVaoChiPhiDenNgay_DonVi()
        {
            if (ChuaChon_DenNgay())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "spRpt_CCDC_ChiTietCCDCDaPhanBoHetVaoChiPhi";
                    cm.CommandText = "spRpt_CCDC_ChiTietCCDCDaPhanBoHetVaoChiPhi_Update";
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool ChiTietCCDCDangPhanBoDenNgay_DonVi()
        {
            if (ChuaChon_DenNgay())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "spRpt_CCDC_ChiTietCCDCDangPhanBo";
                    cm.CommandText = "spRpt_CCDC_ChiTietCCDCDangPhanBo_Update";
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        #endregion //19/04/2014

        public bool Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho()
        {
            if (dateEdit_TuNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Ngày để xem báo cáo");
                dateEdit_TuNgay.Focus();
                return false;
            }
            else if (dateEdit_DenNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để xem báo cáo");
                dateEdit_DenNgay.Focus();
                return false;
            }
            //else if (GridLookupEdit_TaiKhoan.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            //{
            //    MessageBox.Show("Hãy nhập vào giá trị Tài Khoản Kho để xem báo cáo");
            //    GridLookupEdit_TaiKhoan.Focus();
            //    return false;
            //}
            int _maTaiKhoan = 0;
            if (cbTaiKhoan.EditValue != null)
            {
                _maTaiKhoan = (int)cbTaiKhoan.EditValue;
            }
            int _maLoaiVTHH = 0;
            if (gridLookUpEdit_DSLoaiVTHH.EditValue != null)
            {
                _maLoaiVTHH = (int)gridLookUpEdit_DSLoaiVTHH.EditValue;
            }
            GetPPNXKho();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;

                    cm.CommandText = "Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKhoVaLoaiVTHH";
                    cm.Parameters.AddWithValue("@MaLoaiVTHH", _maLoaiVTHH);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@PPNXKho", _PPNXKho);
                    cm.Parameters.AddWithValue("@LoaiBaoCao", "CCDC");
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);
            }//us
            return true;
        }//END Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho
        
        public bool Spd_BangBaoCaoGiaTriVatTu_CCDC_TheoTaiKhoanKho()
        {
            if (dateEdit_TuNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Ngày để xem báo cáo");
                dateEdit_TuNgay.Focus();
                return false;
            }
            else
                if (dateEdit_DenNgay.EditValue == null)
                {
                    MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để xem báo cáo");
                    dateEdit_DenNgay.Focus();
                    return false;
                }
            int _maTaiKhoan = 0;
            object taiKhoan = cbTaiKhoan.GetSelectedDataRow();
            if (taiKhoan != null)
            {
                _maTaiKhoan = (int)cbTaiKhoan.EditValue;
            }
            GetPPNXKho();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao Spd_BangBaoCaoGiaTriVatTu_CCDC_TheoTaiKhoanKho
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BangBaoCaoGiaTriVatTu_CCDC_TheoTaiKhoanKho";
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@PPNXKho", _PPNXKho);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BangBaoCaoGiaTriVatTu_CCDC_TheoTaiKhoanKho;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);
            }//us
            return true;
        }//END Spd_BangBaoCaoGiaTriVatTu_CCDC_TheoTaiKhoanKho

        public bool InDSTomTatVatTuPhieuNhap()
        {
            if (dateEdit_TuNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Ngày để xem báo cáo");
                dateEdit_TuNgay.Focus();
                return false;
            }
            else
                if (dateEdit_DenNgay.EditValue == null)
                {
                    MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để xem báo cáo");
                    dateEdit_DenNgay.Focus();
                    return false;
                }

            int maTaiKhoan = 0;
            if (cbTaiKhoan.EditValue != null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            {
                maTaiKhoan = (int)cbTaiKhoan.EditValue;
            }

            int maKho = 0;
            if (gridLookUpEdit_DSKho.EditValue != null)
            {
                maKho = (int)gridLookUpEdit_DSKho.EditValue;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao InDSTomTatVatTuPhieuNhap
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_DanhSachTomTatVatTu_PhieuNhap";
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_DanhSachTomTatVatTu_PhieuNhap";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                DataTable dtNgay = new DataTable();
                dtNgay.TableName = "TuNgay_DenNgay";
                dtNgay.Columns.Add("TuNgay", typeof(DateTime));
                dtNgay.Columns.Add("DenNgay", typeof(DateTime));
                dtNgay.Rows.Add(dateEdit_TuNgay.EditValue, dateEdit_DenNgay.EditValue);
                dataSet.Tables.Add(dtNgay);

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
            return true;
        }//END InDSTomTatVatTuPhieuNhap

        public bool InDSTomTatVatTuPhieuXuat()
        {
            if (dateEdit_TuNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Ngày để xem báo cáo");
                dateEdit_TuNgay.Focus();
                return false;
            }
            else
                if (dateEdit_DenNgay.EditValue == null)
                {
                    MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để xem báo cáo");
                    dateEdit_DenNgay.Focus();
                    return false;
                }

            int maTaiKhoan = 0;
            if (cbTaiKhoan.EditValue != null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            {
                maTaiKhoan = (int)cbTaiKhoan.EditValue;
            }
            int maKho = 0;
            if (gridLookUpEdit_DSKho.EditValue != null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            {
                maKho = (int)gridLookUpEdit_DSKho.EditValue;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao InDSTomTatVatTuPhieuXuat
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_DanhSachTomTatVatTu_PhieuXuat";
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_DanhSachTomTatVatTu_PhieuXuat;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                DataTable dtNgay = new DataTable();
                dtNgay.TableName = "TuNgay_DenNgay";
                dtNgay.Columns.Add("TuNgay", typeof(DateTime));
                dtNgay.Columns.Add("DenNgay", typeof(DateTime));
                dtNgay.Rows.Add(dateEdit_TuNgay.EditValue, dateEdit_DenNgay.EditValue);
                dataSet.Tables.Add(dtNgay);

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
            return true;
        }//END InDSTomTatVatTuPhieuXuat

        #region UpdateReports

        public bool Method_BaoCaoTinhHinhTangGiamCCDC()
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoTinhHinhTangGiamCCDC";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    cm.Parameters.AddWithValue("@InCTorTH", (int)radioGroupChonInCTorTH.EditValue);
                    cm.Parameters.AddWithValue("@PhuongThucIn", (int)radioGroupChonDenNgay.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("CTorTH", typeof(Int32));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["CTorTH"] = radioGroupChonInCTorTH.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoNhapXuatTonCCDC_Update1()
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoNhapXuatTonCCDC_Update1";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoNhapXuatTonCCDCTheoBoPhan_Update2()
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoNhapXuatTonCCDC_Update1";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoNhapXuatTonCCDCLuyKe_Update3()
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoNhapXuatTonCCDCLuyKe_Update3";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoNhapXuatTonCCDCLuyKeTheoBoPhan_Update4()
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoNhapXuatTonCCDCLuyKe_Update3";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoLuyKeCCDCDaPhanBoHet_Update5()
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoLuyKeCCDCDaPhanBoHet_Update5";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoLuyKeCCDCDaPhanBoHetTheoPhongBan_Update6()
        {
            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoLuyKeCCDCDaPhanBoHet_Update5";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoLuyKeCCDCChuaPhanBo_Update7()
        {
            if (ChuaChon_TuNgay() || ChuaChon_TaiKhoan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoLuyKeCCDCChuaPhanBo_Update7";
                    cm.CommandTimeout = 300;//5 phút 
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoLuyKeCCDCChuaPhanBoTheoPhongBan_Update8()
        {
            if (ChuaChon_DenNgay() || ChuaChon_TaiKhoan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoLuyKeCCDCChuaPhanBo_Update7";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", (int)cbTaiKhoan.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoCCDCDieuChuyenNoiBo_Update9()
        {
            if (ChuaChon_DenNgay())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoCCDCDieuChuyenNoiBo_Update9";
                    cm.CommandTimeout = 300;//5 phút
                    //cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_BaoCaoLuyKeCCDCTheoTinhTrangPhanBo_Update()
        {
            if (ChuaChon_DenNgay())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoLuyKeCCDCTheoTinhTrangPhanBo_Update";
                    cm.CommandTimeout = 300;//5 phút
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", 0);
                    cm.Parameters.AddWithValue("@TTPhanBo", (int)radioGroup_tinhtrangphanbo.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "DataResult";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

            }
            return true;
        }

        public bool Method_DanhSachChiTietCCDCQuanLyCoDenNgayTheoDonVi()
        {
            if (ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (radioGroupChonDenNgay.EditValue != null && (int)radioGroupChonDenNgay.EditValue == 1)//TuNgay DenNgay
                    {
                        cm.CommandText = "Spd_ReportDanhSachChiTietCongCuDungCuQuanLyTrongKhoangTuNgayDenNgay";
                        cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    }
                    else
                    {
                        cm.CommandText = "Spd_ReportDanhSachChiTietCongCuDungCuQuanLyCoDenNgayTheoBoPhan";
                    }
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);

                    cm.Parameters.AddWithValue("@hasManage", (byte)lookUpEdit_PPNXKho.EditValue);
                    cm.Parameters.AddWithValue("@LoaiBaoCao", _LoaiInBaoCao);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan;1");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter;1");
                }

            }
            return true;
        }

        public bool Method_BaoCaoTongHopCCDCQuanLyCoDenNgayTungPhongBan()
        {
            if (ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (radioGroupChonDenNgay.EditValue != null && (int)radioGroupChonDenNgay.EditValue == 1)//TuNgay DenNgay
                    {
                        cm.CommandText = "Spd_ReportDanhSachChiTietCongCuDungCuQuanLyTrongKhoangTuNgayDenNgay";
                        cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    }
                    else
                    {
                        cm.CommandText = "Spd_ReportDanhSachChiTietCongCuDungCuQuanLyCoDenNgayTheoBoPhan";
                    }
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    if (lookUpEdit_BoPhan.EditValue != null)
                        cm.Parameters.AddWithValue("@MaBoPhan", (int)lookUpEdit_BoPhan.EditValue);
                    else
                        cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);

                    cm.Parameters.AddWithValue("@hasManage", (byte)lookUpEdit_PPNXKho.EditValue);
                    cm.Parameters.AddWithValue("@LoaiBaoCao", _LoaiInBaoCao);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan;1");
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    da.Fill(dataSet, "spd_ReportHeaderAndFooter;1");
                }

            }
            return true;
        }

        #region Chuyen Bao Cao tu VatTu

        #endregion//Chuyen Bao Cao tu VatTu

        #endregion//UpdateReport

        #endregion//Cac Phuong Thuc Report

        //public void InBienBan_BanGiao_CCDC_DieuChuyen_NoiBo() //Thang
        //{
        //    /*
        //    dataSet = new DataSet();
        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {

        //        cn.Open();
        //        //tao InBienBan_BanGiao_CCDC_DieuChuyen_NoiBo
        //        using (SqlCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.StoredProcedure;
        //            cm.CommandText = "Spd_BienBan_BanGiao_CCDC_DieuChuyenNoiBo";
        //            cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
        //            cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
        //            SqlDataAdapter da = new SqlDataAdapter(cm);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            dt.TableName = "Spd_BienBan_BanGiao_CCDC_DieuChuyenNoiBo";
        //            dataSet.Tables.Add(dt);
        //        }
        //        //tao bang_REPORT_ReportHeader 


        //        using (SqlCommand cm = cn.CreateCommand())
        //        {
        //            cm.CommandType = CommandType.StoredProcedure;
        //            cm.CommandText = "spd_ReportHeaderAndFooter";
        //            cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
        //            SqlDataAdapter da = new SqlDataAdapter(cm);
        //            DataTable dt = new DataTable();
        //            da.Fill(dt);
        //            dt.TableName = "spd_ReportHeaderAndFooter";
        //            dataSet.Tables.Add(dt);
        //        }

        //    }//us 
        //     * */
        //}

        public bool Inspd_DSCT_CCDC_cho_phan_bo_den_ngay() //Thang
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao Inspd_DSCT_CCDC_cho_phan_bo_den_ngay
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DSCT_CCDC_cho_phan_bo_den_ngay";
                    //cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    //cm.Parameters.AddWithValue("@MaPhongBan", lookUpEdit_BoPhan.EditValue);
                    cm.Parameters.AddWithValue("@MaPhanBo", 0); //gridLookUpEdit_PhanBo.EditValue
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_DSCT_CCDC_cho_phan_bo_den_ngay";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                DataTable dtngay = new DataTable();
                //dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                //dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay:1";
                dataSet.Tables.Add(dtngay);

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
            return true;
        }

        public bool Inspd_CongNo_PhieuThu() //Thang
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao Inspd_CongNo_PhieuThu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToanQTMTL";
                    cm.Parameters.AddWithValue("@MaChungTu", 7);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dataSet);
                    dataSet.Tables[0].TableName = "spd_ChuoiHachToan";
                    dataSet.Tables[1].TableName = "spd_ChuoiTien";
                }

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChungTu_CacQuy_PhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", 7);
                    //cm.Parameters.AddWithValue("@SoCTKemTheo", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuThu";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                //using (SqlCommand cm = cn.CreateCommand())
                //{
                //    cm.CommandType = CommandType.StoredProcedure;
                //    cm.CommandText = "spd_ChuoiHachToan";
                //    cm.Parameters.AddWithValue("@MaChungTu", 5);                    
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    dt.TableName = "spd_ChuoiHachToan";
                //    dataSet.Tables.Add(dt);
                //}
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
            return true;
        } //Inspd_CongNo_PhieuThu

        public bool Inspd_CongNo_PhieuThuTest() //Thang
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao Inspd_CongNo_PhieuThu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_CongNo_PhieuThu";
                    cm.Parameters.AddWithValue("@MaPhieuThu", 76960);
                    cm.Parameters.AddWithValue("@SoCTKemTheo", 0);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_CongNo_PhieuThu";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                //using (SqlCommand cm = cn.CreateCommand())
                //{
                //    cm.CommandType = CommandType.StoredProcedure;
                //    cm.CommandText = "spd_ChuoiHachToan";
                //    cm.Parameters.AddWithValue("@MaChungTu", 5);
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    dt.TableName = "spd_ChuoiHachToan";
                //    dataSet.Tables.Add(dt);
                //}

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayNoTaiKhoan_1";
                    cm.Parameters.AddWithValue("@MaChungTu", 76960);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_LayNoTaiKhoan_1";
                    dataSet.Tables.Add(dt);
                }

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayCoTaiKhoan_1";
                    cm.Parameters.AddWithValue("@MaChungTu", 76960);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_LayCoTaiKhoan_1";
                    dataSet.Tables.Add(dt);
                }

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
            return true;
        } //Inspd_CongNo_PhieuThu

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void treeList_baoCao_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            this.AnTatCaLayoutControlItem();
            ReportTemplate rpt = reportTemplateListBindingSource.Current as ReportTemplate;
            switch (rpt.Id)
            {
                case "ID_BaoCaoTinhHinhTangGiamCCDC":
                    {
                        cbTaiKhoan.EditValue = 49;
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(ItemChonInCTorTH);
                        ShowLayoutControlItem(itemTaiKhoan);
                        ShowLayoutControlItem(ItemPhuongThucIn);
                        ShowLayoutControlItem(itemPPQuanLy);
                    }
                    break;
                case "ID_BaoCaoNhapXuatTonCCDC_Update1":
                    {
                        cbTaiKhoan.EditValue = 49;//BS
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTaiKhoan);
                    }
                    break;
                case "ID_BaoCaoNhapXuatTonCCDCTheoBoPhan_Update2":
                    {
                        cbTaiKhoan.EditValue = 25;//BS
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                        ShowLayoutControlItem(itemTaiKhoan);
                    }
                    break;
                case "ID_BaoCaoNhapXuatTonCCDCLuyKe_Update3":
                case "ID_BaoCaoLuyKeCCDCDaPhanBoHet_Update5":
                    {
                        cbTaiKhoan.EditValue = 49;//BS
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTaiKhoan);
                    }
                    break;
                case "ID_BaoCaoNhapXuatTonCCDCLuyKeTheoBoPhan_Update4":
                case "ID_BaoCaoLuyKeCCDCDaPhanBoHetTheoPhongBan_Update6":
                    {
                        cbTaiKhoan.EditValue = 49;//BS
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTaiKhoan);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "ID_BaoCaoLuyKeCCDCChuaPhanBo_Update7":
                    {
                        cbTaiKhoan.EditValue = 131;//BS
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTaiKhoan);
                    }
                    break;
                case "ID_BaoCaoLuyKeCCDCChuaPhanBoTheoPhongBan_Update8":
                    {
                        cbTaiKhoan.EditValue = 131;//BS
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTaiKhoan);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "ID_BaoCaoCCDCDieuChuyenNoiBo_Update9":
                    {
                        //ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                    }
                    break;
                case "ID_BaoCaoLuyKeCCDCTheoTinhTrangPhanBo_Update":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                        ShowLayoutControlItem(item_TinhTrangPhanBo);
                    }
                    break;
                case "ID_BaoCaoTongHopCCDCQuanLyCoDenNgayTungPhongBan":
                    {
                        _LoaiInBaoCao = 2;
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                        ShowLayoutControlItem(itemPPQuanLy);
                        ShowLayoutControlItem(ItemPhuongThucIn);//BS
                    }
                    break;
                case "ID_DanhSachChiTietCCDCQuanLyCoDenNgayTheoDonVi":
                    {
                        _LoaiInBaoCao = 1;
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                        ShowLayoutControlItem(itemPPQuanLy);
                        ShowLayoutControlItem(ItemPhuongThucIn);//BS
                    }
                    break;
                case "Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                        ShowLayoutControlItem(itemPPQuanLy);
                    }
                    break;
                //báo cáo chuyển từ VTHH sang CCDC
                case "Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTaiKhoan);
                        cbTaiKhoan.EditValue = 49;//gán mặc định là CCDC
                        //ShowLayoutControlItem(itemLoaiVTHH_CCDC);
                        ShowLayoutControlItem(itemPPQuanLy);
                    }
                    break;
                case "InDSTomTatVatTuPhieuXuat":
                case "InDSTomTatVatTuPhieuNhap":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        //ShowLayoutControlItem(item_DSKho);
                        ShowLayoutControlItem(itemTaiKhoan);
                        cbTaiKhoan.EditValue = 49;//gán mặc định là CCDC                       
                        ShowLayoutControlItem(itemPPQuanLy);
                    }
                    break;
                case "Id_TongHopGiaTriCCDCLuyKeDenNgay_DonVi":
                case "Id_ChiTietCCDCDaPhanBoHetVaoChiPhiDenNgay_DonVi":
                case "Id_ChiTietCCDCDangPhanBoDenNgay_DonVi":
                    {
                        //ShowLayoutControlItem(this.itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan_NhoHon10Tr":
                    {

                        //ShowLayoutControlItem(this.itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "Spd_ReportDSChiTietCCDCCoDenNgayTheoBoPhan_NhoHon10Tr":
                    {
                        //ShowLayoutControlItem(this.itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "Spd_ReportDSChiTietCCDCCoDenNgayTheoBoPhan_10TrTroLen":
                    {
                        //ShowLayoutControlItem(this.itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "Spd_ReportDSChiTietCCDCChuaPhanBoHetDenNgayTheoBoPhan_10TrTroLen":
                    {
                        //ShowLayoutControlItem(this.itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "spd_TongHopCCDC10TrTroLenChuaPhanBoHetDenNgayTheoBoPhan":
                    {
                        //ShowLayoutControlItem(this.itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "Spd_BangBaoCaoGiaTriVatTu_CCDC_TheoTaiKhoanKho":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTaiKhoan);
                        cbTaiKhoan.EditValue = 49;//gán mặc định là CCDC                  
                        ShowLayoutControlItem(itemPPQuanLy);
                    }
                    break;
                case "Spd_ReportBaoCaoCongCuDungCuTangTheoTaiKhoan":
                    {
                        ShowLayoutControlItem(this.itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(ItemChonInCTorTH);
                        ShowLayoutControlItem(itemTaiKhoan);
                        cbTaiKhoan.EditValue = 49;//gán mặc định là CCDC   
                        ShowLayoutControlItem(itemPPQuanLy);
                    }
                    break;
                case "spRpt_CCDC_CongCuDungCuTang":
                    {
                        ShowLayoutControlItem(this.itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemTaiKhoan);
                        ShowLayoutControlItem(itemBoPhan);
                        ShowLayoutControlItem(ItemChonInCTorTH);
                    }
                    break;
                case "TongHopGiaTriCongCuDungCuLuyKeCoDenNgay":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                    }
                    break;
                case "DSCT_CCDC_DeNghiThanhLy":
                    {
                        ShowLayoutControlItem(itemBoPhan);
                        ShowLayoutControlItem(itemNam);
                    }
                    break;
                case "BienBan_BanGiao_CCDC_DieuChuyen_NoiBo":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                    }
                    break;
                case "spd_TongHopChiPhiPBCCDC":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "spd_TongHopChiPhiPBCCDCByHangHoa":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "spd_TongHopChiPhiPBCCDCByHangHoa_NhoHon10tr":
                    {
                        ShowLayoutControlItem(itemTuNgay);
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                    }
                    break;
                case "spd_DSCT_CCDC_cho_phan_bo_den_ngay":
                    {
                        ShowLayoutControlItem(itemDenNgay);
                        ShowLayoutControlItem(itemBoPhan);
                        ShowLayoutControlItem(Item_PhanBo);
                    }
                    break;
                case "ChiTietPhanBoChiPhiCCDCChuyenTuTaiSan"://chi tiết phân bổ chi phí ccdc chuyển từ tài sản
                    {
                        ShowLayoutControlItem(itemNam);
                    }
                    break;
                case "TongHopPhanBoChiPhiCCDCChuyenTuTaiSan"://tổng hợp phân bổ chi phí ccdc chuyển từ tài sản
                    {
                        ShowLayoutControlItem(itemNam);
                    }
                    break;
                default:
                    this.AnTatCaLayoutControlItem();
                    break;
            }
        }
        private void AnTatCaLayoutControlItem()
        {
            foreach (LayoutControlItem item in this.layoutControlGroup1.Items)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        private void ShowLayoutControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void HideLayoutControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        #region Kiem tra dieu kien

        private bool ChuaChon_BoPhan()
        {
            if (this.lookUpEdit_BoPhan.EditValue == null)
            {
                MessageBox.Show("Chưa chọn bộ phận", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lookUpEdit_BoPhan.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_DenNgay()
        {
            if (dateEdit_DenNgay.EditValue == null)
            {

                MessageBox.Show("Chưa chọn đến ngày", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateEdit_DenNgay.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_TaiKhoan()
        {
            if (cbTaiKhoan.EditValue == null || (int)cbTaiKhoan.EditValue == 0)
            {

                MessageBox.Show("Chưa chọn tài khoản", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbTaiKhoan.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_TuNgay()
        {
            if (dateEdit_TuNgay.EditValue == null)
            {

                MessageBox.Show("Chưa chọn từ ngày", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateEdit_TuNgay.Focus();
                return true;
            }
            return false;
        }
        private bool ChuaChon_Nam()
        {
            if (cbNam.EditValue == null || (int)cbNam.EditValue == 0)
            {

                MessageBox.Show("Chưa chọn năm", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbNam.Focus();
                return true;
            }
            return false;
        }

        #endregion

        private void lookUpEdit_BoPhan_EditValueChanged(object sender, EventArgs e)
        {
            phanBoChiPhiCCDCListBindingSource.DataSource = PhanBoChiPhiCCDCList.GetPhanBoChiPhiCCDCList((int)lookUpEdit_BoPhan.EditValue);
        }

        private void barbtSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate((reportTemplateListBindingSource.Current as ReportTemplate).Id);

            if (_report != null)
            {
                frmThongTinReport frmObject = new frmThongTinReport(_report, UserId, _thuMuc);
                if (frmObject.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    _reportTemplate = frmThongTinReport._reportItem;

                    if (_reportTemplate.TenPhuongThuc != "")
                    {
                        this.GetType().GetMethod(_reportTemplate.TenPhuongThuc).Invoke(this, null);
                    }

                    frmReport frm = new frmReport();
                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
                _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
                reportTemplateListBindingSource.DataSource = _reportTemplateList;
            }
        }

        private void radioGroupChonDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            if (radioGroupChonDenNgay.EditValue != null && (int)radioGroupChonDenNgay.EditValue == 2)
            {
                HideLayoutControlItem(itemTuNgay);
            }
            else
            {
                ShowLayoutControlItem(itemTuNgay);
            }
        }

        private void GetPPNXKho()
        {
            byte ppnxkhoOut = 0;
            if (byte.TryParse(lookUpEdit_PPNXKho.EditValue.ToString(), out ppnxkhoOut))
            {
                _PPNXKho = ppnxkhoOut;
            }
        }
    }//end class
}
