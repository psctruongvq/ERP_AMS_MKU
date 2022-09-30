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
//11/04/2014////
namespace PSC_ERP
{
    public partial class frmDanhSachReportBanQuyen : DevExpress.XtraEditors.XtraForm
    {   
        private ReportTemplate _reportTemplate;
        ReportTemplateList _reportTemplateList = ReportTemplateList.NewReportTemplateList();
        //SqlCommand command;
        //SqlDataAdapter adapter;
        //DataTable tableNgay;
        private XtraReport report;
        DataSet dataSet = new DataSet();
        int _thuMuc = 4;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        //
        int _maQuocGia = 0;
        int _maBoPhan = 0;

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
        private void KhoiTao()
        {
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "<<Tất cả>>");
            _BoPhanList.Insert(0, _BoPhan);
            BoPhanList_bindingSource.DataSource = _BoPhanList;

            QuocGiabindingSource.DataSource = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList();
            _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            reportTemplateListBindingSource.DataSource = _reportTemplateList;
            dateEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }
        public frmDanhSachReportBanQuyen()
        {
            InitializeComponent();
            KhoiTao();
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
            if (lookUpEdit_BoPhan.EditValue != null)
            {
                int temp;
                if (int.TryParse(lookUpEdit_BoPhan.EditValue.ToString(), out temp))
                    _maBoPhan = temp;
                else
                    _maBoPhan = 0;
            }

            if (grdLUE_NuocSanXuat.EditValue != null)
            {
                int temp;
                if (int.TryParse(grdLUE_NuocSanXuat.EditValue.ToString(), out temp))
                    _maQuocGia = temp;
                else
                    _maQuocGia = 0;
            }

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

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #region Cac Phuong Thuc Report
        public bool Spd_BangTongHopNhapXuatTonPhim()
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
                    cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
                    cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);

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
        }//END Spd_BangTongHopNhapXuatTonPhim

        public bool Spd_BangTongHopChiTietNhapXuatTonPhimTheoBoPhan()
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
            

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_BangTongHopChiTietNhapXuatTonPhimTheoBoPhan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BangTongHopChiTietNhapXuatTonPhimTheoBoPhan";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
                    cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);

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
        }//END Spd_BangTongHopChiTietNhapXuatTonPhimTheoBoPhan

        public bool Spd_BangTongHopNhapXuatTonPhimTheoTungBoPhan()
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
                    cm.CommandText = "Spd_BangTongHopNhapXuatTonPhimTheoTungBoPhan";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BangTongHopNhapXuatTonPhimTheoTungBoPhan;1";
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
        }//END Spd_BangTongHopNhapXuatTonPhimTheoTungBoPhan

        #region BanQuyen
        public bool Spd_BangTongHopNhapXuatTonPhimTheoBoPhan_BQ()//BC2
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
            

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_BangTongHopNhapXuatTonPhim
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BangTongHopNhapXuatTonPhimTheoBoPhan_BQ";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
                    cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);

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
        }//END Spd_BangTongHopNhapXuatTonPhim

        public bool Spd_BangTongHopChiTietNhapXuatTonPhimTheoBoPhan_BQ()//BC3
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
            

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_BangTongHopChiTietNhapXuatTonPhimTheoBoPhan
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BangTongHopChiTietNhapXuatTonPhimTheoBoPhan_BQ";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
                    cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);

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
        }//END Spd_BangTongHopChiTietNhapXuatTonPhimTheoBoPhan

        public bool Spd_BangTongHopNhapXuatTonPhimTatCaBoPhan_BQ()//BC1
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
                    cm.CommandText = "Spd_BangTongHopNhapXuatTonPhimTatCaBoPhan_BQ";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BangTongHopNhapXuatTonPhimTheoTungBoPhan;1";
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
        }//END Spd_BangTongHopNhapXuatTonPhimTheoTungBoPhan
        #endregion

        #region Test

        #endregion
        #endregion//END Cac Phuong Thuc Report

        private void treeList_baoCao_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            this.AnTatCaControlItem();
            ReportTemplate rpt = reportTemplateListBindingSource.Current as ReportTemplate;
            switch (rpt.Id)
            {
                case "BangTongHopNhapXuatTonPhim"://1
                case "BangTongHopChiTietNhapXuatTonPhimTheoBoPhan":
                case "ID_BangTongHopNhapXuatTonPhimTheoBoPhan_BQ"://BC2
                case "ID_BangTongHopNhapXuatTonPhimTheoBoPhan_BQ_All"://BC2_Mau2
                case "ID_BangTongHopChiTietNhapXuatTonPhimTheoBoPhan_BQ"://BC3
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_BoPhan);
                        ShowControlItem(Item_NuocSanXuat);
                    }
                    break;
                case "BangTongHopNhapXuatTonPhimTheoTungBoPhan"://2
                case "ID_BangTongHopNhapXuatTonPhimTatCaBoPhan_BQ"://BC1
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                    }
                    break;
                default:
                    this.AnTatCaControlItem();
                    break;
            }
        }

        private void gridLookUpEdit1_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
                grdLUE_NuocSanXuat.EditValue = null;

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

        private void btn_ImportReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //_reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            //frmExportReport export = new frmExportReport();
            //export.LoadData(_reportTemplateList);
            //export.ShowDialog();
        }

        private void btn_ExportReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ReportHelper.Import();
        }

        private void btn_ChucNangKhac_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChucNangBaoCaoBanQuyen frm = new FrmChucNangBaoCaoBanQuyen();
            frm.ShowDialog();
        }

        private void frmDanhSachReportBanQuyen_Load(object sender, EventArgs e)
        {
            KiemTra();
        }

        private void btn_ChucNangKhac2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmChucNangBaoCaoBanQuyenBQ frm = new FrmChucNangBaoCaoBanQuyenBQ();
            frm.ShowDialog();
        }

    }
}