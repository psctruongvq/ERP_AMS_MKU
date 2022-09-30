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


//02/05/2013
namespace PSC_ERP
{
    public partial class frmDanhSachReportHopDong : DevExpress.XtraEditors.XtraForm
    {

        private ReportTemplate _reportTemplate;
        ReportTemplateList _reportTemplateList = ReportTemplateList.NewReportTemplateList();
        SqlCommand command;
        SqlDataAdapter adapter;
        DataTable tableNgay;
        private XtraReport report;
        DataSet dataSet = new DataSet();
        int _thuMuc = 8;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
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

        public frmDanhSachReportHopDong()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {

            BoPhanList_bindingSource.DataSource = BoPhanList.GetBoPhanList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacList("", 0);
            bs_QuocGiaList.DataSource = QuocGiaBQ_VTList.GetQuocGiaBQ_VTList(); ;
            _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            reportTemplateListBindingSource.DataSource = _reportTemplateList;
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            gridLookUpEdit_QuocGia.EditValue = 0;

            //PhanLoaiHopDongList_bindingSource.DataSource = PhanLoaiHopDongList.GetPhanLoaiHopDongList();
            PhanLoaiHopDongList phanloaiHDList = PhanLoaiHopDongList.GetPhanLoaiHopDongList();
            PhanLoaiHopDong plhd = PhanLoaiHopDong.NewPhanLoaiHopDong(0, "Không chọn");
            phanloaiHDList.Insert(0, plhd);
            PhanLoaiHopDongList_bindingSource.DataSource = phanloaiHDList;

            ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewList();
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewList.Insert(0, ct0);
            chuongTrinh_NewListAllBindingSource.DataSource = _chuongTrinh_NewList;

            loaiHopDongListBindingSource.DataSource = LoaiHopDongList.GetLoaiHopDongList();

            dateEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
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



        #region Cac Phuong Thuc Report

        public bool Spd_BaoCaoThongKeHopDongTheoChuongTrinh()//Spd_BaoCaoThongKeHopDongTheoChuongTrinh
        {
            int maLoaiHD = 0;
            int maPhanLoaiHD = 0;
            int maChuongTrinh = 0;
            if (gridLookUpEdit_LoaiHD.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Nhóm Hợp Đồng để xem báo cáo");
                gridLookUpEdit_LoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(gridLookUpEdit_LoaiHD.EditValue.ToString(), out maLoaiHD))
            {
                if (maLoaiHD == 0)
                {
                    MessageBox.Show("Nhóm Hợp Đồng không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_LoaiHD.Focus();
                    return false;
                }
            }
            if (gridLookUpEdit_MaPhanLoaiHD.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Phân Loại Hợp Đồng để xem báo cáo");
                gridLookUpEdit_MaPhanLoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(gridLookUpEdit_MaPhanLoaiHD.EditValue.ToString(), out maPhanLoaiHD))
            {
                if (maPhanLoaiHD == 0)
                {
                    MessageBox.Show("Phân Loại Hợp Đồng không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_MaPhanLoaiHD.Focus();
                    return false;
                }
            }
            //if (dateEdit_TuNgay.EditValue == null)
            //{
            //    MessageBox.Show("Hãy nhập vào giá trị Từ Ngày để xem báo cáo");
            //    dateEdit_TuNgay.Focus();
            //    return false;
            //}
            //else if (dateEdit_DenNgay.EditValue == null)
            //{
            //    MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để xem báo cáo");
            //    dateEdit_DenNgay.Focus();
            //    return false;
            //}
            if (grdLU_ChuongTrinh.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Tên Chương trình để xem báo cáo");
                grdLU_ChuongTrinh.Focus();
                return false;
            }
            else if (int.TryParse(grdLU_ChuongTrinh.EditValue.ToString(), out maChuongTrinh))
            {
                if (maChuongTrinh == 0)
                {
                    MessageBox.Show("Tên Chương trình không hợp lại, vui lòng nhập lại để xem báo cáo");
                    grdLU_ChuongTrinh.Focus();
                    return false;
                }
            }

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao Bang_BaoCaoThongKeHopDongTheoChuongTrinh
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoThongKeHopDongTheoChuongTrinh";
                    //cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    //cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", maLoaiHD);
                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", maPhanLoaiHD);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);
                    cm.Parameters.AddWithValue("@UserID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoThongKeHopDongTheoChuongTrinh;1";
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
        }//END Bang_BaoCaoThongKeHopDongTheoChuongTrinh

        public bool Spd_BaoCaoTinhHinhThucHienCacHopDongTheoPhanLoaiHD()//Spd_BaoCaoTinhHinhThucHienCacHopDongDaoTao
        {
            int maLoaiHD = 0;
            int maPhanLoaiHD = 0;
            if (gridLookUpEdit_LoaiHD.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Nhóm Hợp Đồng để xem báo cáo");
                gridLookUpEdit_LoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(gridLookUpEdit_LoaiHD.EditValue.ToString(), out maLoaiHD))
            {
                if (maLoaiHD == 0)
                {
                    MessageBox.Show("Nhóm Hợp Đồng không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_LoaiHD.Focus();
                    return false;
                }
            }
            if (gridLookUpEdit_MaPhanLoaiHD.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Phân Loại Hợp Đồng để xem báo cáo");
                gridLookUpEdit_MaPhanLoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(gridLookUpEdit_MaPhanLoaiHD.EditValue.ToString(), out maPhanLoaiHD))
            {
                if (maPhanLoaiHD == 0)
                {
                    MessageBox.Show("Phân Loại Hợp Đồng không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_MaPhanLoaiHD.Focus();
                    return false;
                }
            }
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
                //tao bang_BaoCaoTinhHinhThucHienCacHopDongDaoTao
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoTinhHinhThucHienCacHopDongTheoPhanLoaiHD";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", maLoaiHD);
                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", maPhanLoaiHD);
                    cm.Parameters.AddWithValue("@UserID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoTinhHinhThucHienCacHopDong;1";
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
        }//END Spd_BaoCaoTinhHinhThucHienCacHopDongDaoTao

        public bool Spd_BaoCaoThongKeCacChuongTrinhXHHoa()//Spd_BaoCaoThongKeCacChuongTrinhXHHoa
        {
            int maLoaiHD = 0;
            int maPhanLoaiHD = 0;
            if (gridLookUpEdit_LoaiHD.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Nhóm Hợp Đồng để xem báo cáo");
                gridLookUpEdit_LoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(gridLookUpEdit_LoaiHD.EditValue.ToString(), out maLoaiHD))
            {
                if (maLoaiHD == 0)
                {
                    MessageBox.Show("Nhóm Hợp Đồng không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_LoaiHD.Focus();
                    return false;
                }
            }
            if (gridLookUpEdit_MaPhanLoaiHD.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Phân Loại Hợp Đồng để xem báo cáo");
                gridLookUpEdit_MaPhanLoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(gridLookUpEdit_MaPhanLoaiHD.EditValue.ToString(), out maPhanLoaiHD))
            {
                if (maPhanLoaiHD == 0)
                {
                    MessageBox.Show("Phân Loại Hợp Đồng không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_MaPhanLoaiHD.Focus();
                    return false;
                }
            }
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
            long maDoiTac = 0;
            if (lookUpEdit_BoPhan.EditValue != null)
            {
                int.TryParse(lookUpEdit_BoPhan.EditValue.ToString(), out maBoPhan);
            }
            if (gridLookUpEdit_DoiTac.EditValue != null)
            {
                long.TryParse(gridLookUpEdit_DoiTac.EditValue.ToString(), out maDoiTac);
            }

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_BaoCaoThongKeCacChuongTrinhXHHoa
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoThongKeCacChuongTrinhXHHoa";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", maLoaiHD);
                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", maPhanLoaiHD);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                    cm.Parameters.AddWithValue("@UserID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoThongKeCacChuongTrinhXHHoa;1";
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
        }//END Spd_BaoCaoThongKeCacChuongTrinhXHHoa

        public bool Spd_BaoCaoTinhHinhMuaChuongTrinhBanVeTinh_Nam()//Spd_BaoCaoTinhHinhMuaChuongTrinhBanVeTinh_Nam
        {
            int maLoaiHD = 0;
            int maPhanLoaiHD = 0;
            if (gridLookUpEdit_LoaiHD.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Nhóm Hợp Đồng để xem báo cáo");
                gridLookUpEdit_LoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(gridLookUpEdit_LoaiHD.EditValue.ToString(), out maLoaiHD))
            {
                if (maLoaiHD == 0)
                {
                    MessageBox.Show("Nhóm Hợp Đồng không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_LoaiHD.Focus();
                    return false;
                }
            }
            if (gridLookUpEdit_MaPhanLoaiHD.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Phân Loại Hợp Đồng để xem báo cáo");
                gridLookUpEdit_MaPhanLoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(gridLookUpEdit_MaPhanLoaiHD.EditValue.ToString(), out maPhanLoaiHD))
            {
                if (maPhanLoaiHD == 0)
                {
                    MessageBox.Show("Phân Loại Hợp Đồng không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_MaPhanLoaiHD.Focus();
                    return false;
                }
            }
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
            int maQuocGia = 0;
            long maDoiTac = 0;
            if (gridLookUpEdit_QuocGia.EditValue != null)
            {
                int.TryParse(gridLookUpEdit_QuocGia.EditValue.ToString(), out maQuocGia);
            }
            if (gridLookUpEdit_DoiTac.EditValue != null)
            {
                long.TryParse(gridLookUpEdit_DoiTac.EditValue.ToString(), out maDoiTac);
            }

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_BaoCaoTinhHinhMuaChuongTrinhBanVeTinh_Nam
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoTinhHinhMuaChuongTrinhBanVeTinh_Nam";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", maLoaiHD);
                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", maPhanLoaiHD);
                    cm.Parameters.AddWithValue("@MaQuocGia", maQuocGia);
                    cm.Parameters.AddWithValue("@MaDoiTac", maDoiTac);
                    cm.Parameters.AddWithValue("@UserID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoTinhHinhMuaChuongTrinhBanVeTinh_Nam;1";
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
        }//END Spd_BaoCaoTinhHinhMuaChuongTrinhBanVeTinh_Nam

        public bool Spd_BaoCaoChuongTrinhTheoDuAn()//Spd_BaoCaoChuongTrinhTheoDuAn
        {
            int maLoaiHD = 0;
            int maPhanLoaiHD = 0;
            int maDuAn = 0;

            if (gridLookUpEdit_LoaiHD.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Nhóm Hợp Đồng để xem báo cáo");
                gridLookUpEdit_LoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(gridLookUpEdit_LoaiHD.EditValue.ToString(), out maLoaiHD))
            {
                if (maLoaiHD == 0)
                {
                    MessageBox.Show("Nhóm Hợp Đồng không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_LoaiHD.Focus();
                    return false;
                }
            }
            
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
            if (GridLookupEdit_TaiKhoan.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào Mã dự án để xem báo cáo");
                gridLookUpEdit_LoaiHD.Focus();
                return false;
            }
            else if (int.TryParse(GridLookupEdit_TaiKhoan.EditValue.ToString(), out maDuAn))
            {
                if (maDuAn == 0)
                {
                    MessageBox.Show("Mã dự án không hợp lại, vui lòng nhập lại để xem báo cáo");
                    gridLookUpEdit_LoaiHD.Focus();
                    return false;
                }
            }

            if (gridLookUpEdit_MaPhanLoaiHD.EditValue != null)
            {
                int.TryParse(gridLookUpEdit_MaPhanLoaiHD.EditValue.ToString(), out maPhanLoaiHD);
            }

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_BaoCaoChuongTrinhTheoDuAn
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BaoCaoChuongTrinhTheoDuAn";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaDuAn", maDuAn);
                    cm.Parameters.AddWithValue("@MaLoaiHopDong", maLoaiHD);
                    cm.Parameters.AddWithValue("@MaPhanLoaiHD", maPhanLoaiHD);
                    cm.Parameters.AddWithValue("@UserID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BaoCaoChuongTrinhTheoDuAn;1";
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
        }//END Spd_BaoCaoChuongTrinhTheoDuAn


        #endregion//Cac Phuong Thuc Report

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private void treeList_baoCao_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            this.AnTatCaControlItem();
            ReportTemplate rpt = reportTemplateListBindingSource.Current as ReportTemplate;
            switch (rpt.Id)
            {
                case "ID_BaoCaoThongKeHopDongTheoChuongTrinh"://1
                    {
                        ShowControlItem(Item_LoaiHD);
                        ShowControlItem(Item_MaPhanLoaiHD);
                        ShowControlItem(item_MaChuongTrinh);
                        //ShowControlItem(Item_TuNgay);
                        //ShowControlItem(Item_DenNgay);
                    }
                    break;
                case "ID_BaoCaoTinhHinhThucHienCacHopDongTheoPhanLoaiHD"://1
                case "ID_BaoCaoTinhHinhThucHienCacHopDongMuaSam"://1
                    {
                        ShowControlItem(Item_LoaiHD);
                        ShowControlItem(Item_MaPhanLoaiHD);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                    }
                    break;
                case "ID_BaoCaoThongKeCacChuongTrinhXHHoa"://2
                    {
                        ShowControlItem(Item_LoaiHD);
                        ShowControlItem(Item_MaPhanLoaiHD);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_DoiTac);
                        ShowControlItem(Item_BoPhan);
                    }
                    break;
                case "ID_BaoCaoTinhHinhMuaChuongTrinhBanVeTinh_Nam"://3
                    {
                        ShowControlItem(Item_LoaiHD);
                        ShowControlItem(Item_MaPhanLoaiHD);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_DoiTac);
                        ShowControlItem(Item_QuocGia);
                    }
                    break;
                case "ID_BaoCaoChuongTrinhTheoDuAn"://4
                    {
                        //PhanLoaiHopDongList phanloaiHDList = PhanLoaiHopDongList.GetPhanLoaiHopDongList();
                        //PhanLoaiHopDong plhd = PhanLoaiHopDong.NewPhanLoaiHopDong(0, "Không chọn");
                        //phanloaiHDList.Insert(0, plhd);
                        //PhanLoaiHopDongList_bindingSource.DataSource = phanloaiHDList;


                        ShowControlItem(Item_LoaiHD);
                        ShowControlItem(Item_MaPhanLoaiHD);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_TaiKhoan);

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
                gridLookUpEdit_QuocGia.EditValue = null;
            }
        }

        private void gridLookUpEdit_DSKho_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                gridLookUpEdit_DoiTac.EditValue = null;
            }
        }

        private void lookUpEdit_BoPhan_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lookUpEdit_BoPhan.EditValue = null;
            }
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


    }
}
