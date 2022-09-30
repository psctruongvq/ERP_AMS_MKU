using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Predefined;
using ERP_Library;
using System.Data.SqlClient;
//cường
namespace PSC_ERP
{
    public partial class frmPhanBoChiPhiCCDCChuyenTuTaiSan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmPhanBoChiPhiCCDCChuyenTuTaiSan singleton_ = null;
        public static frmPhanBoChiPhiCCDCChuyenTuTaiSan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmPhanBoChiPhiCCDCChuyenTuTaiSan();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            PSC_ERP_Common.FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion
        tblPhanBoChiPhiCCDCChuyenTuTaiSan _document = null;
        PhanBoChiPhiCCDCChuyenTuTaiSan_Factory _factory = null;
        tblPhanBoChiPhiCCDCChuyenTuTaiSan _objFromAnotherFactory = null;
        Boolean _taoMoiChungTu = true;
        Int32 _reviewDocumentID = 0;
        public frmPhanBoChiPhiCCDCChuyenTuTaiSan()
        {
            InitializeComponent();
            _taoMoiChungTu = true;
        }
        public frmPhanBoChiPhiCCDCChuyenTuTaiSan(tblPhanBoChiPhiCCDCChuyenTuTaiSan document)
        {
            InitializeComponent();
            _taoMoiChungTu = false;
            _objFromAnotherFactory = document;
            _reviewDocumentID = document.MaPhanBo;
        }
        private void NewDocument()
        {
            _factory = PhanBoChiPhiCCDCChuyenTuTaiSan_Factory.New();
            _document = _factory.TaoMoiChungTuDayDuChiTiet_ManagedObject();
            BindDocument();
        }
        private void ReviewDocument()
        {
            _factory = PhanBoChiPhiCCDCChuyenTuTaiSan_Factory.New();
            _document = _factory.Get_ByID(_reviewDocumentID);
            BindDocument();
        }
        private void BindDocument()
        {//gỡ bỏ liên kết đến các document trước đó
            tblPhanBoChiPhiCCDCChuyenTuTaiSanBindingSource.DataSource = new List<tblPhanBoChiPhiCCDCChuyenTuTaiSan>();
            tblPhanBoChiPhiCCDCChuyenTuTaiSanBindingSource.Add(_document);
            tblCTPhanBoChiPhiCCDCChuyenTuTaiSanBindingSource.DataSource = _document.tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan;
            txtSoChungTu.Focus();
        }

        private Boolean Save()
        {
            txtBlackHole.Focus();
            tblPhanBoChiPhiCCDCChuyenTuTaiSanBindingSource.EndEdit();
            tblCTPhanBoChiPhiCCDCChuyenTuTaiSanBindingSource.EndEdit();

            if (DuocPhepLuu())
            {
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        _factory.SaveChangesWithoutTrackingLog();
                        //_factory.SaveChanges(BusinessCodeEnum.CCDC_PhanBoChiPhiCCDCChuyenTuTaiSan.ToString());
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful();
                }
            }
            return false;
        }
        private Boolean DuocPhepLuu()
        {
            Boolean result = true;
            if (String.IsNullOrWhiteSpace(_document.SoChungTu))
            {
                DialogUtil.ShowWarning("Số chứng từ không được rỗng");
                txtSoChungTu.Focus();
                return false;
            }
            //kiểm tra trùng số chứng từ
            if (_factory.KiemTraTrungSoChungTu(_document) == true)
            {
                DialogUtil.ShowWarning("Trùng số chứng từ");
                txtSoChungTu.Focus();
                return false;
            }
            //
            //kiểm tra đã chạy phân bổ trong năm
            if (_factory.KiemTraTrongNamDaChayPhanBo(_document) == true)
            {
                DialogUtil.ShowWarning(String.Format("Không lưu được do năm {0} đã từng chạy phân bổ", _document.NgayChungTu.Value.Year.ToString()));
                return false;
            }

            return result;
        }
        private void frmPhanBoChiPhiCCDCChuyenTuTaiSan_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                using (DialogUtil.Wait(this))
                {
                    if (_taoMoiChungTu)
                    {
                        //tạo mới chứng từ
                        NewDocument();
                    }
                    else
                        ReviewDocument();
                }
                PSC_ERP_Common.GridUtil.SetSTTForGridView(this.gridView1);
            };
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlgResult = DialogUtil.ShowSaveRequireOptions(this);
            if (dlgResult == DialogResult.Yes)
            {
                if (this.Save() == false)
                    return;
            }
            if (_objFromAnotherFactory != null)
                this._objFromAnotherFactory.CurrentForm_AddedObj = null;
            NewDocument();
        }
        private void btnXoaChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            DialogResult dlgResult = DialogUtil.ShowDelete(this);//.ShowYesNo("Bạn muốn xóa phiếu?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    //xóa
                    _factory.FullDelete(deleteList: _document);
                    _factory.SaveChangesWithoutTrackingLog();
                    //_factory.SaveChanges(BusinessCodeEnum.CCDC_PhanBoChiPhiCCDCChuyenTuTaiSan.ToString());
                    DialogUtil.ShowDeleteSuccessful();
                    this.Close();
                }
                catch (System.Exception ex)
                {
                    DialogUtil.ShowDeleteSuccessful();
                }
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }

        private void btnDanhSachChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Test");
        }
        DataSet dataSet = new DataSet();
        private void btnBienBanChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ReportTemplate report = ReportTemplate.GetReportTemplate("ChiTietPhanBoChiPhiCCDCChuyenTuTaiSan");
            if (report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();


                ReportTemplate reportTemplate = ReportTemplate.GetReportTemplate(report.Id, PSC_ERP_Global.Main.UserID, dtDenNgay);
                if (reportTemplate.Id == string.Empty)
                {
                    reportTemplate.Id = report.Id;
                    reportTemplate.UserID = PSC_ERP_Global.Main.UserID;
                    reportTemplate.DenNgay = dtDenNgay;
                }
                if (report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(reportTemplate, dataSet);
                frm.Show();
            }
        }

        private void btnInBienBanTongHop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            ReportTemplate report = ReportTemplate.GetReportTemplate("TongHopPhanBoChiPhiCCDCChuyenTuTaiSan");
            if (report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();


                ReportTemplate reportTemplate = ReportTemplate.GetReportTemplate(report.Id, PSC_ERP_Global.Main.UserID, dtDenNgay);
                if (reportTemplate.Id == string.Empty)
                {
                    reportTemplate.Id = report.Id;
                    reportTemplate.UserID = PSC_ERP_Global.Main.UserID;
                    reportTemplate.DenNgay = dtDenNgay;
                }
                if (report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(reportTemplate, dataSet);
                frm.Show();
            }
        }
        public bool ChiTietPhanBoChiPhiCCDCChuyenTuTaiSan()
        {

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_CCDC_PhanBoChiPhiCCDCChuyenTuTaiSan";//xài chung store với TongHopPhanBoChiPhiCCDCChuyenTuTaiSan
                    cm.Parameters.AddWithValue("@Nam", _document.NgayChungTu.Value.Year);
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
                    cm.Parameters.AddWithValue("@MaNguoiLap", PSC_ERP_Global.Main.UserID);
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

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_CCDC_TongHopPhanBoChiPhiCCDCChuyenTuTaiSan";//
                    cm.Parameters.AddWithValue("@Nam", _document.NgayChungTu.Value.Year);
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
                    cm.Parameters.AddWithValue("@MaNguoiLap", PSC_ERP_Global.Main.UserID);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

            }
            return true;
        }


    }
}
