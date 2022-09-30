using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
//using Demo.Report.Parameters;
using System.Data.SqlClient;
using ERP_Library;
using DevExpress.XtraLayout;
//using Demo.Report;

//02/05/2013
namespace PSC_ERP
{
    public partial class frmDanhSachReportVTHH : XtraForm
    {

        private ReportTemplate _reportTemplate;
        ReportTemplateList _reportTemplateList = ReportTemplateList.NewReportTemplateList();
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable tableNgay;
        private XtraReport report;
        DataSet dataSet = new DataSet();
        int _thuMuc = 2;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        byte _PPNXKho = 0;
        //int UserId = 43;

        private void KiemTra()
        {
            if (ERP_Library.Security.CurrentUser.Info.UserID != 39)
            {
                btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                barbtXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

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

        public frmDanhSachReportVTHH()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {

            BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();

            KhoBQ_VTList lstKho = KhoBQ_VTList.GetKhoVatTuList();
            KhoBQ_VT kho = KhoBQ_VT.NewKhoBQ_VT();
            kho.MaQuanLy = "";
            kho.TenKho = "Không chọn";
            lstKho.Insert(0, kho);
            khoBQVTListBindingSource.DataSource = lstKho;  //KhoBQ_VTList.GetKhoVatTuList();

            HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();

            LoaiVatTuHHBQ_VTList listLoaiVTHH = LoaiVatTuHHBQ_VTList.GetLoaiVatTuHHBQ_VTList();
            LoaiVatTuHHBQ_VT objLoaiVTHH = LoaiVatTuHHBQ_VT.NewLoaiVatTuHHBQ_VT();
            objLoaiVTHH.TenLoaiVatTuHH = "<<Tất Cả>>";
            objLoaiVTHH.MaQuanLy = "";
            LoaiVTHHList_bindingSource.DataSource = listLoaiVTHH;

            _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            reportTemplateListBindingSource.DataSource = _reportTemplateList;
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            gridLookUpEdit_DSLoaiVTHH.EditValue = 0;
            {
                List<int> namList = new List<int>();
                int nam = DateTime.Today.Year;
                for (int i = nam - 10; i < nam + 10; i++)
                    namList.Add(i);
                gridLookUpEdit_Nam.Properties.DataSource = namList;
                gridLookUpEdit_Nam.EditValue = nam;
            }
            dateEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
            Init_lookUpEditPPNXKho();
        }

        private void Init_lookUpEditPPNXKho()
        {
            DataTable _dataTable = new DataTable();

            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(0, "<<Tất cả>>");
            _dataTable.Rows.Add(1, "Bình Quân");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");


            lookUpEdit_PPNXKho.Properties.DataSource = _dataTable;
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.EditValue = 0;
        }

        private void GetPPNXKho()
        {
            byte ppnxkhoOut = 0;
            if (byte.TryParse(lookUpEdit_PPNXKho.EditValue.ToString(), out ppnxkhoOut))
            {
                _PPNXKho = ppnxkhoOut;
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
            GetPPNXKho();
            ReportTemplate _report = reportTemplateListBindingSource.Current as ReportTemplate;
            if (_report != null)
            {
                if (_PPNXKho == 2 && _report.Id == "BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru")
                {
                    _report = ReportTemplate.GetReportTemplate("ID_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru_double");
                }
                if (_PPNXKho == 2 && _report.Id == "BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho")
                {
                    _report = ReportTemplate.GetReportTemplate("ID_BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho_double");
                }
                if (_PPNXKho == 2 && _report.Id == "BangTongHopChiTietVatTuTheoKho")
                {
                    _report = ReportTemplate.GetReportTemplate("ID_BangTongHopChiTietVatTuTheoKho_double");
                }
            }
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
                    //frm.ShowDialog();
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
            GetPPNXKho();

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
                    cm.Parameters.AddWithValue("@PPNXKho", _PPNXKho);
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
            if (GridLookupEdit_TaiKhoan.EditValue != null)
            {
                _maTaiKhoan = (int)GridLookupEdit_TaiKhoan.EditValue;
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
            GetPPNXKho();
            dataSet = new DataSet();
            int _maLoaiVTHH = 0;
            int _maNhomVTHH = 0;
            if (gridLookUpEdit_DSLoaiVTHH.EditValue != null)
            {
                _maLoaiVTHH = (int)gridLookUpEdit_DSLoaiVTHH.EditValue;
            }

            if (gridLookUpEdit_DSNhomVTHH.GetSelectedDataRow() != null)
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
                    cm.Parameters.AddWithValue("@PPNXKho", _PPNXKho);

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
            int _maTaiKhoan = 0;
            if (GridLookupEdit_TaiKhoan.EditValue != null)
            {
                _maTaiKhoan = (int)GridLookupEdit_TaiKhoan.EditValue;
            }
            int maBoPhan = 0;
            if (lookUpEdit_BoPhan.EditValue != null)
                maBoPhan = (int)lookUpEdit_BoPhan.EditValue;
            GetPPNXKho();
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
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@PPNXKho", _PPNXKho);

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
            //else
            //    if (gridLookUpEdit_DSKho.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            //    {
            //        MessageBox.Show("Hãy nhập vào giá trị Kho để xem báo cáo");
            //        gridLookUpEdit_DSKho.Focus();
            //        return false;
            //    }
            GetPPNXKho();
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
                    else cm.Parameters.AddWithValue("@MaKho", 0);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@PPNXKho", _PPNXKho);

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
        }//END Spd_BangChiTietSoLuongVatTuXNT_Kho
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
            object taiKhoan = GridLookupEdit_TaiKhoan.GetSelectedDataRow();
            if (taiKhoan != null)
            {
                _maTaiKhoan = (int)GridLookupEdit_TaiKhoan.EditValue;
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
            object xe = GridLookupEdit_Xe.GetSelectedDataRow();
            if (xe != null)
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
        public bool Spd_BaoCaoTongHopVatTuXuatKho_theoDonVi()
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

            int _maBoPhan = 0;
            object boPhan = lookUpEdit_BoPhan.GetSelectedDataRow();
            if (boPhan != null)
            {
                _maBoPhan = (int)lookUpEdit_BoPhan.EditValue;
            }
            int _maTaiKhoan = 0;
            if (GridLookupEdit_TaiKhoan.EditValue != null)
            {
                _maTaiKhoan = (int)GridLookupEdit_TaiKhoan.EditValue;
            }
            GetPPNXKho();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao Spd_BaoCaoTongHopVatTuXuatKho_theoDonVi
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoTongHopVatTuXuatKho_theoDonVi";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
                    cm.Parameters.AddWithValue("@PPNXKho", _PPNXKho);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _maTaiKhoan);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoTongHopVatTuXuatKho_theoDonVi;1";
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
            int maTaiKhoan = 0;
            if (GridLookupEdit_TaiKhoan.EditValue != null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            {
                maTaiKhoan = (int)GridLookupEdit_TaiKhoan.EditValue;
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
            if (GridLookupEdit_TaiKhoan.EditValue != null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            {
                maTaiKhoan = (int)GridLookupEdit_TaiKhoan.EditValue;
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
            //else if (gridLookUpEdit_DSKho.EditValue == null)// || (int)gridLookUpEdit_DSKho.EditValue == 0)
            //{
            //    MessageBox.Show("Hãy nhập vào giá trị Kho cần xem báo cáo");
            //    gridLookUpEdit_DSKho.Focus();
            //    return false;
            //}
            GetPPNXKho();
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
                    cm.Parameters.AddWithValue("@PPNXKho", _PPNXKho);
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



        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridLookUpEdit_DSLoaiVTHH_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit_DSLoaiVTHH.EditValue != null)
                NhomVTHHList_bindingSource.DataSource = NhomHangHoaBQ_VTList.GetNhomHangHoaBQ_VTList_NhomCap1TheoLoai((int)gridLookUpEdit_DSLoaiVTHH.EditValue);
        }

        private void gridLookUpEdit_DSNhomVTHH_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit_DSNhomVTHH.EditValue != null)
                HangHoaList_bindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTListByMaNhom((int)gridLookUpEdit_DSNhomVTHH.EditValue);
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
                case "ThongKeVatTuXNT_TheoNguonKinhPhi"://15
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_Kho);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "DSTomTatVatTuPhieuNhap"://12
                case "DSTomTatVatTuPhieuXuat"://13
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_Kho);
                        ShowControlItem(Item_TaiKhoan);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "BangBaoCaoGiaTriVatTu_CCDC_TheoTaiKhoanKho"://15
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_TaiKhoan);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "BaoCaoNhapXuatTonKhoVatTuHangHoaDuTruTheoKho"://7
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_TaiKhoan);
                        ShowControlItem(Item_LoaiVTHH);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "BangCTKeHoachMuaVatTu"://2 
                case "BangCTKeHoachMuaVatTuTH"://3
                    {
                        ShowControlItem(Item_Nam);
                        ShowControlItem(Item_LoaiVTHH);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "BangKeHoachMuaVatTu"://4
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_LoaiVTHH);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "BaoCaoNhapXuatTonKhoVatTuHangHoaDuTru"://6
                case "BaoCaoTinhHinhSuDungXangDauTheoThang"://8
                case "BangTongHopNhapXuatTonPhim"://15
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "DanhSachChiTietVatTu_PhieuXuat_DonVi"://9
                    {
                        BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_TaiKhoan);
                        ShowControlItem(Item_BoPhan);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "ID_BaoCaoTongHopVatTuXuatKho_theoDonVi":
                    {
                        BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_BoPhan);
                        ShowControlItem(ItemPPNhapXuat);
                        ShowControlItem(Item_TaiKhoan);
                    }
                    break;
                case "BaoCaoTongHopLinhNhienLieuCuaCacXeTheoPhongBan":
                    {
                        //DataTable dt = new DataTable();
                        // BoPhanList_bindingSource.Filter = "MaBoPhan IN (10,23)";
                        //lookUpEdit_BoPhan.Refresh();
                        BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanListForLinhNhienLieu();
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_BoPhan);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "BaoCaoChiTietLinhNhienLieuTheoXe_PhongBan":
                    {
                        BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanListForLinhNhienLieu();
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_BoPhan);
                        ShowControlItem(Item_BienSoXe);
                        ShowControlItem(ItemPPNhapXuat);
                    }
                    break;
                case "DanhSachChiTietVatTu_PhieuXuat_Kho"://10
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_Kho); ;
                        ShowControlItem(Item_LoaiVTHH);
                        ShowControlItem(Item_NhomVTHH);
                        ShowControlItem(ItemPPNhapXuat);

                    }
                    break;
                case "TheKho"://14
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_HangHoa);
                        ShowControlItem(ItemPPNhapXuat);
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
                case "IDReport_ChiTietNhapXuatTon":
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_HangHoa);
                        ShowControlItem(Item_Kho);
                    }
                    break;
                case "IDReport_TongHopNhapXuatTonTheoTruong":
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_HangHoa);
                        //ShowControlItem(Item_Kho);
                    }
                    break;
                default:
                    this.AnTatCaControlItem();
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
                XeListBindingSource.DataSource = XeList.GetXeList((int)lookUpEdit_BoPhan.EditValue);
            GridLookupEdit_Xe.EditValue = null;
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

        private void GridLookupEdit_TaiKhoan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookupEdit_TaiKhoan.EditValue = null;
            }

        }

        private void frmDanhSachReportVTHH_Load(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void btn_ChucNangMoRong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChucNangBaoCaoVatTu frm = new FrmChucNangBaoCaoVatTu();
            frm.ShowDialog();
        }


        #region bao cao chi tiet nxt
        public bool InChiTietNhapXuatTon()
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

            int maKho = 0;
            int maHangHoa = 0;
            if (gridLookUpEdit_DSKho.EditValue != null)
                maKho = (int)gridLookUpEdit_DSKho.EditValue;

            if (gridLookUpEdit_DSHangHoa.EditValue != null)
                maHangHoa = (int)gridLookUpEdit_DSHangHoa.EditValue;

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBangTongHopChiTietVatTuTheoKho
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_ChiTietNhapXuatTon";
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spRpt_ChiTietNhapXuatTon";
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
        #endregion

        #region bao cao tong hop nxt theo truong
        public bool InTongHopNhapXuatTonTheoTruong()
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

            int maKho = 0;
            int maHangHoa = 0;
            if (gridLookUpEdit_DSKho.EditValue != null)
                maKho = (int)gridLookUpEdit_DSKho.EditValue;

            if (gridLookUpEdit_DSHangHoa.EditValue != null)
                maHangHoa = (int)gridLookUpEdit_DSHangHoa.EditValue;

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBangTongHopChiTietVatTuTheoKho
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_TongHopNhapXuatTonTheoTruong";
                    cm.Parameters.AddWithValue("@MaKho", maKho);
                    cm.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spRpt_TongHopNhapXuatTonTheoTruong";
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
        #endregion
    }
}
