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
//using Demo.Report;


//05/01/2013
namespace PSC_ERP
{
    public partial class frmDanhSachReportTest : DevExpress.XtraEditors.XtraForm
    {

        private ReportTemplate _reportTemplate;
        ReportTemplateList _reportTemplateList = ReportTemplateList.NewReportTemplateList();
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable tableNgay;
        private XtraReport report;
        DataSet dataSet = new DataSet();
        int _thuMuc = 0;
        //int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        int UserId = 39;

        private void AnTatCaControlItem()
        {
            foreach (LayoutControlItem item in this.layoutControlGroup1.Items)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void ShowControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        public frmDanhSachReportTest()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            BoPhanList _boPhanList = BoPhanList.GetBoPhanList();
            _boPhanList.Insert(0, BoPhan.NewBoPhan(0, "Tất cả"));
            BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanList();
            kyTinhLuongListBindingSource.DataSource = KyTinhLuongList.GetKyTinhLuongList();
            //khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoVatTuList();
            //HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
            //LoaiVTHHList_bindingSource.DataSource = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHBQ_VTList();
            _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            reportTemplateListBindingSource.DataSource = _reportTemplateList;
            gridLookUpEdit_DSLoaiVTHH.EditValue = 0;
            {
                List<int> namList = new List<int>();
                int nam = DateTime.Today.Year;
                for (int i = nam - 10; i < nam + 10; i++)
                    namList.Add(i);
                gridLookUpEdit_Nam.Properties.DataSource = namList;
                gridLookUpEdit_Nam.EditValue = nam;
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

            frmThongTinReport frmObject = new frmThongTinReport(report, UserId, _thuMuc);

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

        private void barbtXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barbt_Xem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report = reportTemplateListBindingSource.Current as ReportTemplate;
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                if (!KiemTra(_report.Id))
                {
                    XtraMessageBox.Show("Báo cáo chưa tồn tại vui lòng tạo báo cáo trước khi xem !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //B
                _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                bool daChonParameter = false;
                if (_report.TenPhuongThuc != "")
                {
                    daChonParameter = (bool)this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }
                if (daChonParameter)
                {
                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                }
                _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
                reportTemplateListBindingSource.DataSource = _reportTemplateList;
                //E
            }
        }

        #region Cac Phuong Thuc Report

        public bool Spd_ThongKeVatTuXNT_TheoNguonKinhPhi()
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
                else
                    if (gridLookUpEdit_DSKho.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
                    {
                        MessageBox.Show("Hãy nhập vào giá trị Kho để xem báo cáo");
                        gridLookUpEdit_DSKho.Focus();
                        return false;
                    }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_ThongKeVatTuXNT_TheoNguonKinhPhi";
                    cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_ThongKeVatTuXNT_TheoNguonKinhPhi;1";
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
                return true;
            }//us 
        }//END Spd_ThongKeVatTuXNT_TheoNguonKinhPhi

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


        public bool InKeHoachSuDungMauBieu()
        {
            if (gridLookUpEdit_Nam.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Năm để xem báo cáo");
                dateEdit_TuNgay.Focus();
                return false;
            }

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InKeHoachSuDungMauBieu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KehoachSuDung";
                    cm.Parameters.AddWithValue("@Nam", gridLookUpEdit_Nam.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_KehoachSuDung";
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
        }//END InKeHoachSuDungMauBieu

        public bool Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru()
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

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru;1";
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
        }//END Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru
        public bool Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho()
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
                else
                    if (gridLookUpEdit_DSKho.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
                    {
                        MessageBox.Show("Hãy nhập vào giá trị Kho để xem báo cáo");
                        gridLookUpEdit_DSKho.Focus();
                        return false;
                    }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (gridLookUpEdit_DSLoaiVTHH.EditValue == null || (int)gridLookUpEdit_DSLoaiVTHH.EditValue == 0)
                    {
                        //
                        cm.CommandText = "Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho";
                        //
                    }
                    else
                    {
                        //
                        cm.CommandText = "Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKhoVaLoaiVTHH";
                        cm.Parameters.AddWithValue("@MaLoaiVTHH", gridLookUpEdit_DSLoaiVTHH.EditValue);
                        //
                    }
                    cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

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

            }//us
            return true;
        }//END Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho

        public bool Spd_TheKho()
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
                else
                    if (gridLookUpEdit_DSHangHoa.EditValue == null)
                    {
                        MessageBox.Show("Hãy nhập vào giá trị Hàng Hóa để xem báo cáo");
                        gridLookUpEdit_DSHangHoa.Focus();
                        return false;
                    }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_TheKho
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_TheKho";
                    if (gridLookUpEdit_DSHangHoa.EditValue != null)
                        cm.Parameters.AddWithValue("@MaHangHoa", gridLookUpEdit_DSHangHoa.EditValue);
                    else cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_TheKho;1";
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
        }//END Spd_TheKho

        public bool Spd_DanhSachChiTietVatTu_PhieuXuat_Kho()
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
            //else
            //    if (gridLookUpEdit_DSKho.EditValue == null)
            //    {
            //        MessageBox.Show("Hãy nhập vào giá trị Kho để xem báo cáo");
            //        gridLookUpEdit_DSKho.Focus();
            //        return false;
            //    }
            dataSet = new DataSet();
            int _maLoaiVTHH = 0;
            int _maNhomVTHH = 0;
            if (gridLookUpEdit_DSLoaiVTHH.EditValue != null)
            {
                _maLoaiVTHH = (int)gridLookUpEdit_DSLoaiVTHH.EditValue;
            }

            if (gridLookUpEdit_DSNhomVTHH.EditValue != null)
            {
                _maNhomVTHH = (int)gridLookUpEdit_DSNhomVTHH.EditValue;
            }
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_DanhSachChiTietVatTu_PhieuXuat
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (gridLookUpEdit_DSKho.EditValue != null)
                    {
                        if (_maLoaiVTHH != 0)
                        {
                            if (_maNhomVTHH != 0)
                            {
                                cm.CommandText = "Spd_DanhSachChiTietVatTu_PhieuXuat_Kho_LoaiVTHH_NhomVTHH";//1)LAY RA TAT CA CAC CT PHIEU XUAT THEO KHO VA LOAIVATTUHH,NhomVTHH 
                                cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                                cm.Parameters.AddWithValue("@MaLoaiVTHH", _maLoaiVTHH);
                                cm.Parameters.AddWithValue("@MaNhomVTHH", _maNhomVTHH);
                            }
                            else
                            {
                                cm.CommandText = "Spd_DanhSachChiTietVatTu_PhieuXuat_Kho_LoaiVTHH";//3)LAY RA TAT CA CAC CT PHIEU XUAT THEO KHO VA LOAIVATTUHH 
                                cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                                cm.Parameters.AddWithValue("@MaLoaiVTHH", _maLoaiVTHH);
                            }
                        }
                        else
                        {
                            cm.CommandText = "Spd_DanhSachChiTietVatTu_PhieuXuat_Kho";//2)LAY RA TAT CA CAC CT PHIEU XUAT THEO KHO
                            cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                        }

                    }

                    else
                    {
                        cm.CommandText = "Spd_DanhSachChiTietVatTu_PhieuXuat";//4)LAY RA TAT CA CAC CT PHIEU XUAT
                    }
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_DanhSachChiTietVatTu_PhieuXuat_Kho;1";
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
        }//END Spd_DanhSachChiTietVatTu_PhieuXuat

        public bool Spd_DanhSachChiTietVatTu_PhieuXuat_DonVi()
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
            int maBoPhan = 0;
            if (lookUpEdit_BoPhan.EditValue != null)
                maBoPhan = (int)lookUpEdit_BoPhan.EditValue;
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_DanhSachChiTietVatTu_PhieuXuat_DonVi
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_DanhSachChiTietVatTu_PhieuXuat_DonVi";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_DanhSachChiTietVatTu_PhieuXuat_DonVi;1";
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
        }//END Spd_DanhSachChiTietVatTu_PhieuXuat_DonVi

        public bool Spd_BangChiTietSoLuongVatTuXNT_Kho()
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
                else
                    if (gridLookUpEdit_DSKho.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
                    {
                        MessageBox.Show("Hãy nhập vào giá trị Kho để xem báo cáo");
                        gridLookUpEdit_DSKho.Focus();
                        return false;
                    }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_Spd_BangChiTietSoLuongVatTuXNT_Kho
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BangChiTietSoLuongVatTuXNT_Kho";
                    if (gridLookUpEdit_DSKho.EditValue != null)
                        cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                    else cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BangChiTietSoLuongVatTuXNT_Kho;1";
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
        }//END Spd_BangChiTietSoLuongVatTuXNT_Kho

        public bool spd_TongHopGiaTriCongCuDungCuLuyKeCoDenNgay()
        {
            if (dateEdit_DenNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để xem báo cáo");
                dateEdit_DenNgay.Focus();
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

        public bool Spd_ReportDanhSachChiTietCongCuDungCuCoDenNgayTheoBoPhan()
        {
            if (dateEdit_DenNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để xem báo cáo");
                dateEdit_DenNgay.Focus();
                return false;
            }
            else
                if (lookUpEdit_BoPhan.EditValue == null)
                {
                    MessageBox.Show("Hãy nhập vào giá trị Kho để xem báo cáo");
                    dateEdit_DenNgay.Focus();
                    return false;
                }
            //cuong
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

        public bool Spd_BangTongHopNhapXuatTonPhim()
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

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_BangTongHopNhapXuatTonPhim
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BangTongHopNhapXuatTonPhim";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BangTongHopNhapXuatTonPhim;1";
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
        }//END Spd_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru

        public bool Spd_BaoCaoTongHopLinhNhienLieuCuaCacXeTheoPhongBan()
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
            else if (lookUpEdit_BoPhan.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Bộ phận _ Phòng ban cần xem báo cáo");
                lookUpEdit_BoPhan.Focus();
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao Spd_BaoCaoTongHopLinhNhienLieuCuaCacXeTheoPhongBan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoTongHopLinhNhienLieuCuaCacXeTheoPhongBan";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", lookUpEdit_BoPhan.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoTongHopLinhNhienLieuCuaCacXeTheoPhongBan;1";
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
        }//END Spd_BaoCaoTongHopLinhNhienLieuCuaCacXeTheoPhongBan

        public bool Spd_BaoCaoChiTietLinhNhienLieuTheoXe_PhongBan()
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
            else if (lookUpEdit_BoPhan.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Bộ phận _ Phòng ban cần xem báo cáo");
                lookUpEdit_BoPhan.Focus();
                return false;
            }
            //else if (GridLookupEdit_Xe.EditValue == null)
            //{
            //    MessageBox.Show("Hãy nhập vào Thông tin xe cần xem báo cáo");
            //    GridLookupEdit_Xe.Focus();
            //    return false;
            //}
            int _iDXe = 0;
            if (GridLookupEdit_Xe.EditValue != null)
            {
                _iDXe = (int)GridLookupEdit_Xe.EditValue;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao Spd_BaoCaoChiTietLinhNhienLieuTheoXe_PhongBan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoChiTietLinhNhienLieuTheoXe_PhongBan";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", lookUpEdit_BoPhan.EditValue);
                    cm.Parameters.AddWithValue("@IDXe", _iDXe);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoChiTietLinhNhienLieuTheoXe_PhongBan;1";
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
        }//END Spd_BaoCaoChiTietLinhNhienLieuTheoXe_PhongBan
        #endregion//Cac Phuong Thuc Report
        #region Cac Phuong Thuc Tam
        public bool PhieuKeToan()//[dbo].[spd_BaoCaoChungTuGhiSo] 
        {
            long maChungTu = 11;
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_BaoCaoChungTuGhiSo
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoChungTuGhiSo";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
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
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
            }//us 
            return true;
        }//END Phieu Ke Toan
        public bool PhieuChi()//[dbo].[spd_ChuoiHachToan], [dbo].[spd_CongNo_PhieuChi]
        {
            long maChungTu = 10;
            int soChungTuKemTheo = 0;
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao spd_ChuoiHachToan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ChuoiHachToanQTMTL";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
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
                    cm.CommandText = "spd_ChungTu_CacQuy_PhieuChi";
                    cm.Parameters.AddWithValue("@MaPhieuChi", maChungTu);
                    //cm.Parameters.AddWithValue("@SoCTKemTheo ", soChungTuKemTheo);
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
                    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
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
                    cm.Parameters.AddWithValue("@MaChungTu", 76960);
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
                    cm.Parameters.AddWithValue("@MaPhieuThu", 76960);
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
        #endregion //Cac Phuong Thuc Tam


        public bool InPhieuLinhNhienLieu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InPhieuLinhNhienLieu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_PhieuLinhNhienLieu";
                    cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", lue_SoChungTu.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_PhieuLinhNhienLieu;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_REPORT_ReportHeader";
                    cm.Parameters.AddWithValue("@MaCongTy", 1);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_REPORT_ReportHeader;1";
                    dataSet.Tables.Add(dt);
                }

            }//us 
            return true;
        }//END InPhieuXuatVatTu
        public bool MauInPhieuLinhNhienLieu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
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
        public bool InDuTruKeHoach()
        {
            if (gridLookUpEdit_Nam.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Năm để xem báo cáo");
                gridLookUpEdit_Nam.Focus();
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InDuTruKeHoach
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_DuTruKehoach";
                    cm.Parameters.AddWithValue("@Nam", gridLookUpEdit_Nam.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_DuTruKehoach;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_REPORT_ReportHeader";
                    cm.Parameters.AddWithValue("@MaCongTy", 1);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_REPORT_ReportHeader;1";
                    dataSet.Tables.Add(dt);
                }

            }//us 
            return true;
        }//END InDuTruKeHoach

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
            //else
            //    if (gridLookUpEdit_DSKho.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            //    {
            //        MessageBox.Show("Hãy nhập vào giá trị Kho để xem báo cáo");
            //        gridLookUpEdit_DSKho.Focus();
            //        return false;
            //    }
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
                    //if (gridLookUpEdit_DSKho.EditValue != null)
                    //    cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                    //else cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
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
            //else
            //    if (gridLookUpEdit_DSKho.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            //    {
            //        MessageBox.Show("Hãy nhập vào giá trị Kho để xem báo cáo");
            //        gridLookUpEdit_DSKho.Focus();
            //        return false;
            //    }
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
                    //if (gridLookUpEdit_DSKho.EditValue != null)
                    //    cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                    //else cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
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

        public bool InDSChiTietVatTuPhieuNhap()
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
            //else
            //    if (gridLookUpEdit_DSKho.EditValue == null ||(int) gridLookUpEdit_DSKho.EditValue==0)
            //    {
            //        MessageBox.Show("Hãy nhập vào giá trị Kho để xem báo cáo");
            //        dateEdit_DenNgay.Focus();
            //        return false;
            //    }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InDSChiTietVatTuPhieuNhap
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    if (gridLookUpEdit_DSKho.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
                    {
                        cm.CommandText = "Spd_DanhSachChiTietVatTu_PhieuNhap";
                    }
                    else
                    {
                        cm.CommandText = "Spd_DanhSachChiTietVatTu_PhieuNhap_Kho";
                        cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                    }

                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_DanhSachChiTietVatTu_PhieuNhap;1";
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
        }//END InDSChiTietVatTuPhieuNhap

        public bool InBaoCaoTinhHinhSuDungXangDauTheoThang()
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
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBaoCaoTinhHinhSuDungXangDauTheoThang
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoTinhHinhSuDungXangDauTheoThang";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoTinhHinhSuDungXangDauTheoThang;1";
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
        }


        public bool InBangCTKeHoachMuaVatTu()
        {
            if (gridLookUpEdit_Nam.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Năm để xem báo cáo");
                gridLookUpEdit_Nam.Focus();
                return false;
            }
            else
                if (gridLookUpEdit_DSLoaiVTHH.EditValue == null)
                {
                    MessageBox.Show("Hãy nhập vào giá trị LoạiVTHH để xem báo cáo");
                    gridLookUpEdit_DSLoaiVTHH.Focus();
                    return false;
                }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBangCTKeHoachMuaVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BangCTKeHoachMuaVatTu";
                    cm.Parameters.AddWithValue("@Nam", gridLookUpEdit_Nam.EditValue);
                    cm.Parameters.AddWithValue("@MaLoaiVatTu", gridLookUpEdit_DSLoaiVTHH.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_BangCTKeHoachMuaVatTu";
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
        public bool InBangCTKeHoachMuaVatTuTH()
        {
            if (gridLookUpEdit_Nam.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Năm để xem báo cáo");
                gridLookUpEdit_Nam.Focus();
                return false;
            }
            else
                if (gridLookUpEdit_DSLoaiVTHH.EditValue == null)
                {
                    MessageBox.Show("Hãy nhập vào giá trị LoạiVTHH để xem báo cáo");
                    gridLookUpEdit_DSLoaiVTHH.Focus();
                    return false;
                }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBangCTKeHoachMuaVatTuTH
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BangCTKeHoachMuaVatTu";
                    cm.Parameters.AddWithValue("@Nam", gridLookUpEdit_Nam.EditValue);
                    cm.Parameters.AddWithValue("@MaLoaiVatTu", gridLookUpEdit_DSLoaiVTHH.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_BangCTKeHoachMuaVatTu";
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


        public bool InBangKeHoachMuaVatTu()
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
                else
                    if (gridLookUpEdit_DSLoaiVTHH.EditValue == null)
                    {
                        MessageBox.Show("Hãy nhập vào giá trị LoạiVTHH để xem báo cáo");
                        gridLookUpEdit_DSLoaiVTHH.Focus();
                        return false;
                    }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBangKeHoachMuaVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BangKeHoachMuaVatTu";
                    cm.Parameters.AddWithValue("@MaLoaiVatTu", gridLookUpEdit_DSLoaiVTHH.EditValue);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_BangKeHoachMuaVatTu";
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
        }

        public bool InDeNghiLinhVatTu()
        {
            if (lue_SoChungTu.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn số chứng từ để xem");
                lue_SoChungTu.Focus();
                return false;
            }

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InDeNghiLinhVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_PhieuLinhNhienLieu";
                    cm.Parameters.AddWithValue("@MaPhieuLinhNhienLieu", lue_SoChungTu.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_PhieuLinhNhienLieu";
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
        }//END InDeNghiLinhVatTu


        private bool btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            return true;

        }//END InBaoCaoTinhHinhSuDungXangDauTheoThang


        public bool InBangTongHopChiTietVatTuTheoKho()
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
            else if (gridLookUpEdit_DSKho.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            {
                MessageBox.Show("Hãy nhập vào giá trị Kho cần xem báo cáo");
                gridLookUpEdit_DSKho.Focus();
                return false;
            }
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBangTongHopChiTietVatTuTheoKho
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BangTongHopChiTietVatTuTheoKho";
                    if (gridLookUpEdit_DSKho.EditValue != null)
                        cm.Parameters.AddWithValue("@MaKho", gridLookUpEdit_DSKho.EditValue);
                    else cm.Parameters.AddWithValue("@MaKho", DBNull.Value);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BangTongHopChiTietVatTuTheoKho;1";
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
        }//END InBangTongHopChiTietVatTuTheoKho


        #region Tờ Khai Thuế Thu Nhập Cá Nhân
        public bool ToKhaiThueTNCN()
        {
            if (cmb_TuKy.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Kỳ để xem báo cáo");
                cmb_TuKy.Focus();
                return false;
            }

            if (cmb_DenKy.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Đến Kỳ để xem báo cáo");
                cmb_DenKy.Focus();
                return false;
            }

            int iTuKy = Convert.ToInt32(cmb_TuKy.EditValue);
            int iDenKy = Convert.ToInt32(cmb_DenKy.EditValue);
            DateTime dtTuNgay = KyTinhLuong.GetKyTinhLuong(iTuKy).NgayBatDau;
            DateTime dtDenNgay = KyTinhLuong.GetKyTinhLuong(iDenKy).NgayKetThuc;
            int MaBoPhan = Convert.ToInt32(lookUpEdit_BoPhan.EditValue);
            int MaNhanVien = Convert.ToInt32(cmb_NhanVien.EditValue);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ToKhaiQuyetToanThueTNCN";
                    cm.Parameters.AddWithValue("@TuKy", iTuKy);
                    cm.Parameters.AddWithValue("@DenKy", iDenKy);
                    cm.Parameters.AddWithValue("@BoPhan", MaBoPhan);
                    cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ToKhaiQuyetToanThueTNCN";
                    dataSet.Tables.Add(dt);
                }

                //tao bang_REPORT_ReportHeader 
                DataTable dtNgay = new DataTable();
                dtNgay.TableName = "TuNgay_DenNgay";
                dtNgay.Columns.Add("TuNgay", typeof(DateTime));
                dtNgay.Columns.Add("DenNgay", typeof(DateTime));
                dtNgay.Rows.Add(dtTuNgay, dtDenNgay);
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
        }
        #endregion

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridLookUpEdit_DSLoaiVTHH_EditValueChanged(object sender, EventArgs e)
        {
            //if (gridLookUpEdit_DSLoaiVTHH.EditValue != null)
            //    NhomVTHHList_bindingSource.DataSource = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList_NhomCap1TheoLoai((int)gridLookUpEdit_DSLoaiVTHH.EditValue);
        }

        private void gridLookUpEdit_DSNhomVTHH_EditValueChanged(object sender, EventArgs e)
        {
            //if (gridLookUpEdit_DSNhomVTHH.EditValue != null)
            //    HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTListByMaNhom((int)gridLookUpEdit_DSNhomVTHH.EditValue);
        }

        private void treeList_baoCao_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            this.AnTatCaControlItem();
            ReportTemplate rpt = reportTemplateListBindingSource.Current as ReportTemplate;
            switch (rpt.Id)
            {
                case "BangChiTietSoLuongVatTuXNT_Kho"://1
                case "BangTongHopChiTietVatTuTheoKho"://5

                case "DSChiTietVatTuPhieuNhap"://11
                case "DSTomTatVatTuPhieuNhap"://12
                case "DSTomTatVatTuPhieuXuat"://13
                case "ThongKeVatTuXNT_TheoNguonKinhPhi"://15
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_Kho);
                    }
                    break;
                case "BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho"://7
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_Kho);
                        ShowControlItem(Item_LoaiVTHH);
                    }
                    break;
                case "BangCTKeHoachMuaVatTu"://2 
                case "BangCTKeHoachMuaVatTuTH"://3
                    {
                        ShowControlItem(Item_Nam);
                        ShowControlItem(Item_LoaiVTHH);
                    }
                    break;
                case "BangKeHoachMuaVatTu"://4
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_LoaiVTHH);
                    }
                    break;
                case "BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru"://6
                case "BaoCaoTinhHinhSuDungXangDauTheoThang"://8
                case "BangTongHopNhapXuatTonPhim"://15
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                    }
                    break;
                case "DanhSachChiTietVatTu_PhieuXuat_DonVi"://9
                    {
                        BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanList();
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_BoPhan);
                    }
                    break;
                case "BaoCaoTongHopLinhNhienLieuCuaCacXeTheoPhongBan":
                    {
                        //DataTable dt = new DataTable();
                        // BoPhanList_bindingSource.Filter = "MaBoPhan IN (10,23)";
                        //lookUpEdit_BoPhan.Refresh();
                        //BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanListForLinhNhienLieu();
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_BoPhan);
                    }
                    break;
                case "BaoCaoChiTietLinhNhienLieuTheoXe_PhongBan":
                    {
                        //BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanListForLinhNhienLieu();
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_BoPhan);
                        ShowControlItem(Item_BienSoXe);
                    }
                    break;
                case "DanhSachChiTietVatTu_PhieuXuat_Kho"://10
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_Kho); ;
                        ShowControlItem(Item_LoaiVTHH);
                        ShowControlItem(Item_NhomVTHH);

                    }
                    break;
                case "TheKho"://14
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_HangHoa);
                    }
                    break;
                case "PhieuLinhNhienLieu":
                    {
                        ShowControlItem(Item_SoChungTu);
                    }
                    break;
                case "DeNghiLinhVatTu":
                    {
                        ShowControlItem(Item_SoChungTu);
                    }
                    break;
                case "ToKhaiQuyetToanThueTNCN":
                    {
                        ShowControlItem(TuKy);
                        ShowControlItem(DenKy);
                        ShowControlItem(Item_BoPhan);
                        ShowControlItem(Item_NhanVien);
                    }
                    break;
                default:
                    //this.AnTatCaControlItem();
                    break;
            }
        }//END InDSRePort

        private void gridLookUpEdit_DSLoaiVTHH_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                gridLookUpEdit_DSLoaiVTHH.EditValue = null;
            }
        }

        private void gridLookUpEdit_DSNhomVTHH_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                gridLookUpEdit_DSNhomVTHH.EditValue = null;
            }
        }

        private void gridLookUpEdit_DSHangHoa_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                gridLookUpEdit_DSHangHoa.EditValue = null;
            }
        }

        private void lue_SoChungTu_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lue_SoChungTu.EditValue = null;
            }
        }

        private void gridLookUpEdit_DSKho_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                gridLookUpEdit_DSKho.EditValue = null;
            }
        }

        private void GridLookupEdit_Xe_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookupEdit_Xe.EditValue = null;
            }
        }

        private void lookUpEdit_BoPhan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_BoPhan.EditValue != null)
            {
                NhanVienList _nhanVienList = NhanVienList.GetNhanVienList((int)lookUpEdit_BoPhan.EditValue);
                _nhanVienList.Insert(0, NhanVien.NewNhanVien(0, "Tất cả"));
                nhanVienListBindingSource.DataSource = _nhanVienList;
            }
            //    XeListBindingSource.DataSource = XeList.GetXeList((int)lookUpEdit_BoPhan.EditValue);
        }

        private void lookUpEdit_BoPhan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lookUpEdit_BoPhan.EditValue = null;
            }
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

        private void btn_ExportReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //_reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            //frmExportReport export = new frmExportReport();
            //export.LoadData(_reportTemplateList);
            //export.ShowDialog();

        }

        private void btn_ImportReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ReportHelper.Import();
        }


        public bool Method_Report_BangKeChiTietPhuCapTruyLinhTruyThu()
        {
            int maKyTinhLuong = 0;
            int maKyPhuCap = 0;
            int maNganHang = 0;
            int maBoPhan = 0;
            int loaiNV = 0;

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBangTongHopChiTietVatTuTheoKho
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_BangKeChiTietPhuCapTruyLinhTruyThu";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", maKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNganHang",maNganHang);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@LoaiNV", loaiNV);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_BangKeChiTietPhuCapTruyLinhTruyThu;1";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                //DataTable dtNgay = new DataTable();
                //dtNgay.TableName = "TuNgay_DenNgay";
                //dtNgay.Columns.Add("TuNgay", typeof(DateTime));
                //dtNgay.Columns.Add("DenNgay", typeof(DateTime));
                //dtNgay.Rows.Add(dateEdit_TuNgay.EditValue, dateEdit_DenNgay.EditValue);
                //dataSet.Tables.Add(dtNgay);

                //using (SqlCommand cm = cn.CreateCommand())
                //{
                //    cm.CommandType = CommandType.StoredProcedure;
                //    cm.CommandText = "spd_ReportHeaderAndFooter";
                //    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    dt.TableName = "spd_ReportHeaderAndFooter";
                //    dataSet.Tables.Add(dt);
                //}

            }//us 
            return true;
        }//END InBangTongHopChiTietVatTuTheoKho

        private void In_Report_BangKeChiTietPhuCapTruyLinhTruyThu()
        {
            ReportTemplate _report;
            _report = ReportTemplate.GetReportTemplate("ID_Report_BangKeChiTietPhuCapTruyLinhTruyThu");
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

        private void In_Report_BangKeTongHopPhuCapTruyLinhTruyThu()
        {
            ReportTemplate _report;
            _report = ReportTemplate.GetReportTemplate("ID_Report_BangKeTongHopPhuCapTruyLinhTruyThu");
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
}
