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
//4/12/2013
namespace PSC_ERP
{
    public partial class frmBaoCaoPhuCapBS : DevExpress.XtraEditors.XtraForm
    {
        private ReportTemplate _reportTemplate;
        ReportTemplateList _reportTemplateList = ReportTemplateList.NewReportTemplateList();
        private XtraReport report;
        DataSet dataSet = new DataSet();
        int _thuMuc = 11111;
        int userID = ERP_Library.Security.CurrentUser.Info.UserID;


        private string _ptThanhToan = "Tất cả";

        private string _ptThanhToanString = string.Empty;

        //

        private void KiemTra()
        {
            btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barbtSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            barbtXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //if (ERP_Library.Security.CurrentUser.Info.UserID != 39)
            //{
            //    btnThemMoi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    barbtSua.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //    barbtXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
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

        private void HideControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;

        }

        private void XemBaoCao()
        {
            //BEGIN
            ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_BaoCaoChiTietPhuCapNhanVienBS");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, userID, dtDenNgay);

                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = userID;
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

        private void KhoiTao()
        {
            //_reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            //reportTemplateListBindingSource.DataSource = _reportTemplateList;
            dateEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }


        #region BoSung


        #endregion//BoSung

        public frmBaoCaoPhuCapBS()
        {
            InitializeComponent();
            KhoiTao();
        }
        public frmBaoCaoPhuCapBS(int thanhtoan)
        {
            InitializeComponent();
            KhoiTao();
            if (thanhtoan == 0)
            {
                comboBoxEdit_Loai.EditValue = "Tiền mặt";
            }
            else if (thanhtoan == 1)
            {
                comboBoxEdit_Loai.EditValue = "Chuyển khoản";
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
            report = new Rpt_ReportMau();

            frmThongTinReport frmObject = new frmThongTinReport(report, userID, _thuMuc);

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
            XemBaoCao();

            #region Other
            //ReportTemplate _report = reportTemplateListBindingSource.Current as ReportTemplate;
            //if (_report != null)
            //{
            //    DateTime dtDenNgay = DateTime.Today;
            //    frmReport frm = new frmReport();

            //    if (!KiemTra(_report.Id))
            //    {
            //        XtraMessageBox.Show("Báo cáo chưa tồn tại vui lòng tạo báo cáo trước khi xem !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    //B
            //    _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, userID, dtDenNgay);
            //    if (_reportTemplate.Id == string.Empty)
            //    {
            //        _reportTemplate.Id = _report.Id;
            //        _reportTemplate.UserID = userID;
            //        _reportTemplate.DenNgay = dtDenNgay;
            //    }
            //    bool daChonParameter = false;
            //    if (_report.TenPhuongThuc != "")
            //    {
            //        daChonParameter = (bool)this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //    }
            //    if (daChonParameter)
            //    {
            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.ShowDialog();
            //    }
            //    _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            //    reportTemplateListBindingSource.DataSource = _reportTemplateList;
            //    //E
            //}
            #endregion//Other
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #region Cac Phuong Thuc Report
        public void Method_BaoCaoChiTietPhuCapNhanVienBS()
        {
            int thanhtoan = 0;
            if (_ptThanhToan == "Chuyển khoản")
            {
                thanhtoan = 2;
            }
            else if (_ptThanhToan == "Tiền mặt")
            {
                thanhtoan = 1;
            }

            dataSet = new DataSet();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BaoCaoChiTietPhuCapNhanVienBS";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@ThanhToan", thanhtoan);
                    cm.Parameters.AddWithValue("@UserID", userID);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_BaoCaoChiTietPhuCapNhanVienBS";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_ReportHeaderAndFooter
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_ReportHeaderAndFooter";
                    cm.Parameters.AddWithValue("@MaNguoiLap", userID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblNgay";
                dataSet.Tables.Add(dtngay);

            }//us  
        }//END 


        #endregion//END Cac Phuong Thuc Report

        private void treeList_baoCao_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            //this.AnTatCaControlItem();
            //ReportTemplate rpt = reportTemplateListBindingSource.Current as ReportTemplate;
            //switch (rpt.Id)
            //{
            //    case "BangKeSuDungChungTuKhauTruThueThuNhap":
            //    case "ID_Spd_BangKeSuDungChungTuKhauTruThueThuNhap_2":
            //        {
            //            ShowControlItem(Item_TuNgay);
            //            ShowControlItem(Item_DenNgay);
            //            ShowControlItem(Item_Loai);
            //            ShowControlItem(Item_LoaiBaoCao);
            //        }
            //        break;
            //    case "ID_BangKeSuDungChungTuKhauTruThueThuNhap_NhanVien":
            //        {
            //            ShowControlItem(Item_TuNgay);
            //            ShowControlItem(Item_DenNgay);
            //        }
            //        break;
            //    default:
            //        this.AnTatCaControlItem();
            //        break;
            //}
        }

        private void barbtSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report = ReportTemplate.GetReportTemplate((reportTemplateListBindingSource.Current as ReportTemplate).Id);

            if (_report != null)
            {
                frmThongTinReport frmObject = new frmThongTinReport(_report, userID, _thuMuc);
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

        private void frmDanhSachReportBanQuyen_Load(object sender, EventArgs e)
        {
            KiemTra();
            //Set điều kiện 
            radioGroup_LoaiBaoCao.EditValue = 0;
        }
        private void LoadData()
        {
            if (dateEdit_TuNgay.EditValue != null && dateEdit_DenNgay.EditValue != null)
            {
                DateTime tuNgay = Convert.ToDateTime(dateEdit_TuNgay.EditValue);
                DateTime denNgay = Convert.ToDateTime(dateEdit_DenNgay.EditValue);

            }
        }

        private void dateEdit_TuNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dateEdit_DenNgay_EditValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }


        private void comboBoxEdit_Loai_SelectedValueChanged(object sender, EventArgs e)
        {
            _ptThanhToan = comboBoxEdit_Loai.EditValue.ToString();
        }
    }


}