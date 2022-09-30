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
    public partial class frmHoTroBaoCaoThueBS : DevExpress.XtraEditors.XtraForm
    {
        private ReportTemplate _reportTemplate;
        ReportTemplateList _reportTemplateList = ReportTemplateList.NewReportTemplateList();
        private XtraReport report;
        ChungTuNganHangList _chungTuNganHangList = ChungTuNganHangList.NewChungTuNganHangList();
        DataSet dataSet = new DataSet();
        int _thuMuc = 6;
        int userID = ERP_Library.Security.CurrentUser.Info.UserID;
        int _loaiThuLao = 4;


        private string _ptThanhToan = "Tất cả";
        private long _maChungTuPC = 0;

        private long _maChungTu = 0;

        private string _ptThanhToanString=string.Empty;

        //

        private void KiemTra()
        {
            //if (ERP_Library.Security.CurrentUser.Info.UserID!=39)
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

        private void KhoiTao()
        {
            _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            reportTemplateListBindingSource.DataSource = _reportTemplateList;
            dateEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dateEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }


        #region BoSung
        private void KhoiTaoGridLookupEditMaChungTuPhieuChi()
        {
            LoadDanhSachChungTuPhieuChi();
            gridLookUpEditMaChungTuPC.Properties.DisplayMember = "SoChungTu";
            gridLookUpEditMaChungTuPC.Properties.ValueMember = "MaChungTu";
            HamDungChung.InitGridLookUpDev(gridLookUpEditMaChungTuPC, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev(gridLookUpEditMaChungTuPC, new string[] { "SoChungTu", "NgayLap" }, new string[] { "Số chứng từ", "Ngày lập" }, new int[] { 100, 100 });

        }

        private void LoadDanhSachChungTuPhieuChi()
        {
            if (dateEdit_TuNgay.EditValue != null && dateEdit_DenNgay.EditValue != null)
            {
                DateTime _tuNgay = Convert.ToDateTime(dateEdit_TuNgay.EditValue);
                DateTime _denNgay = Convert.ToDateTime(dateEdit_DenNgay.EditValue);
                List<ChungTuPhieuChiforLapPhieuThu> chungtuphieuchiList = ChungTuPhieuChiforLapPhieuThu.CreatChungTuPhieuChiListforBaoCaoThueCTVTienMat(_tuNgay, _denNgay);
                gridLookUpEditMaChungTuPC.Properties.DataSource = chungtuphieuchiList;
            }
        }


        private bool GetThongTinMaChungTuPC()
        {
            if (gridLookUpEditMaChungTuPC.EditValue != null)
            {
                long mactOut = 0;
                if (long.TryParse(gridLookUpEditMaChungTuPC.EditValue.ToString(), out mactOut))
                {
                    _maChungTuPC = mactOut;
                    return true;
                }
            }
            MessageBox.Show("Chứng Từ Chọn Không Hợp Lệ", "Thông Báo");
            return false;
        }
        #endregion//BoSung

        public frmHoTroBaoCaoThueBS()
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
                _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, userID, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = userID;
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
        public bool Spd_BangKeSuDungChungTuKhauTruThueThuNhap()
        {
            if (dateEdit_TuNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Ngày để xem báo cáo");
                dateEdit_TuNgay.Focus();
                return false;
            }
            if (dateEdit_DenNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để xem báo cáo");
                dateEdit_DenNgay.Focus();
                return false;
            }
            //if (lookUpEdit_ChungTuNganHang.EditValue == null)
            //{
            //    MessageBox.Show("Hãy chọn Ủy Nhiệm Chi để xem báo cáo");
            //    lookUpEdit_ChungTuNganHang.Focus();
            //    return false;
            //}

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tạo bảng chứng từ khấu trừ thếu thu nhập cá nhân
                using (SqlCommand cm = cn.CreateCommand())
                {
                    if (_ptThanhToan == "Chuyển khoản")
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "Spd_BangKeSuDungChungTuKhauTruThueThuNhap";
                        cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                        cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                        cm.Parameters.AddWithValue("@Loai", radioGroup_LoaiBaoCao.EditValue);
                        cm.Parameters.AddWithValue("@MaChungTu", lookUpEdit_ChungTuNganHang.EditValue);
                        cm.Parameters.AddWithValue("@LoaiThuLao", _loaiThuLao);
                    }
                    else
                    {
                        byte ptThanhToan = 0;
                        if (_ptThanhToan == "Tiền mặt")
                        {
                            if (gridLookUpEditMaChungTuPC.EditValue != null)
                            {
                                long mactOut = 0;
                                if (long.TryParse(gridLookUpEditMaChungTuPC.EditValue.ToString(), out mactOut))
                                {
                                    _maChungTuPC = mactOut;
                                }
                            }
                            ptThanhToan = 1;
                        }
                        else
                            ptThanhToan = 0;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_BangKeSuDungChungTuKhauTruThueThuNhap_AddTienMat";
                        cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                        cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                        cm.Parameters.AddWithValue("@Loai", radioGroup_LoaiBaoCao.EditValue);
                        cm.Parameters.AddWithValue("@MaChungTu", _maChungTuPC);
                        cm.Parameters.AddWithValue("@LoaiThuLao", _loaiThuLao);
                        cm.Parameters.AddWithValue("@ptThanhToan", ptThanhToan);
                    }


                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BangKeSuDungChungTuKhauTruThueThuNhap;1";
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
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("NgayLap", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["NgayLap"] = DateTime.Now.Date;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblNgay:1";
                dataSet.Tables.Add(dtngay);

            }//us 
            return true;
        }//END

        public bool Spd_BangKeSuDungChungTuKhauTruThueThuNhap_2()
        {
            if (dateEdit_TuNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Ngày để xem báo cáo");
                dateEdit_TuNgay.Focus();
                return false;
            }
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
                //tạo bảng chứng từ khấu trừ thếu thu nhập cá nhân
                using (SqlCommand cm = cn.CreateCommand())
                {
                    byte ptThanhToan = 0;
                    if (_ptThanhToan == "Chuyển khoản")
                    {
                        ptThanhToan = 2;//Chuyển khoản
                            _ptThanhToanString="Chuyển Khoản";
                        if (lookUpEdit_ChungTuNganHang.EditValue != null)
                        {
                            long mactOut = 0;
                            if (long.TryParse(lookUpEdit_ChungTuNganHang.EditValue.ToString(), out mactOut))
                            {
                                _maChungTu = mactOut;//Chứng từ Ngân hàng
                            }
                        }
                    }
                    else if (_ptThanhToan == "Tiền mặt")
                    {
                        ptThanhToan = 1;//Tiền mặt
                            _ptThanhToanString="Tiền Mặt";
                        if (gridLookUpEditMaChungTuPC.EditValue != null)
                        {
                            long mactOut = 0;
                            if (long.TryParse(gridLookUpEditMaChungTuPC.EditValue.ToString(), out mactOut))
                            {
                                _maChungTu = mactOut;//Chứng từ Tiền Mặt
                            }
                        }
                    }
                    else
                    {
                        ptThanhToan = 0;//Tất cả
                         _ptThanhToanString="Tiền Mặt,Chuyển Khoản";
                        _maChungTu = 0;
                    }

                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_BangKeSuDungChungTuKhauTruThueThuNhap_AddTienMat_2";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@Loai", radioGroup_LoaiBaoCao.EditValue);
                    cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                    cm.Parameters.AddWithValue("@LoaiThuLao", _loaiThuLao);
                    cm.Parameters.AddWithValue("@ptThanhToan", ptThanhToan);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BangKeSuDungChungTuKhauTruThueThuNhap;1";
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
                    dt.TableName = "spd_ReportHeaderAndFooter;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("NgayLap", typeof(DateTime));
                dtngay.Columns.Add("ptThanhToan", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["NgayLap"] = DateTime.Now.Date;
                dr["ptThanhToan"] = _ptThanhToanString;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblNgay:1";
                dataSet.Tables.Add(dtngay);

            }//us 
            return true;
        }//END

        #endregion//END Cac Phuong Thuc Report

        private void treeList_baoCao_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            this.AnTatCaControlItem();
            ReportTemplate rpt = reportTemplateListBindingSource.Current as ReportTemplate;
            switch (rpt.Id)
            {
                case "BangKeSuDungChungTuKhauTruThueThuNhap":
                case "ID_Spd_BangKeSuDungChungTuKhauTruThueThuNhap_2":
                    {
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(Item_Loai);
                        ShowControlItem(Item_LoaiBaoCao);
                        ShowControlItem(Item_LoaiThuLao);
                    }
                    break;
                default:
                    this.AnTatCaControlItem();
                    break;
            }
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
            lookUpEdit_ChungTuNganHang.EditValue = 0;


        }
        private void LoadData()
        {
            if (dateEdit_TuNgay.EditValue != null && dateEdit_DenNgay.EditValue != null)
            {
                DateTime tuNgay = Convert.ToDateTime(dateEdit_TuNgay.EditValue);
                DateTime denNgay = Convert.ToDateTime(dateEdit_DenNgay.EditValue);
                if (_ptThanhToan == "Chuyển khoản")
                {
                    _chungTuNganHangList = ChungTuNganHangList.GetChungTuNganHangList(tuNgay, denNgay);
                    ChungTuNganHang chungTuNganHang_ChonTatCa = new ChungTuNganHang() { So = "<<Tất Cả>>" };
                    _chungTuNganHangList.Insert(0, chungTuNganHang_ChonTatCa);
                    ChungTuNganHangList_bindingSource.DataSource = _chungTuNganHangList;
                }
                else if (_ptThanhToan == "Tiền mặt")
                {
                    KhoiTaoGridLookupEditMaChungTuPhieuChi();
                }

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

        private void cmbu_LoaiThuLao_TextChanged(object sender, EventArgs e)
        {
            string loaiThuLao = cmbu_LoaiThuLao.Text;
            if (loaiThuLao == "Thù Lao")
            {
                _loaiThuLao = 0;
            }
            if (loaiThuLao == "Khen Thưởng")
            {
                _loaiThuLao = 1;
            }
            if (loaiThuLao == "Tác Quyền")
            {
                _loaiThuLao = 2;
            }
            if (loaiThuLao == "Khác")
            {
                _loaiThuLao = 3;
            }
            if (loaiThuLao == "Tất Cả")
            {
                _loaiThuLao = 4;
            }
        }

        private void comboBoxEdit_Loai_SelectedValueChanged(object sender, EventArgs e)
        {
            _ptThanhToan = comboBoxEdit_Loai.EditValue.ToString();
            if (_ptThanhToan == "Tiền mặt")
            {
                ShowControlItem(Item_ChungTuPC);
                HideControlItem(Item_UyNhiemChi);
                LoadData();
            }
            else if (_ptThanhToan == "Chuyển khoản")
            {
                HideControlItem(Item_ChungTuPC);
                ShowControlItem(Item_UyNhiemChi);
                LoadData();
                _maChungTuPC = 0;
            }
            else
            {
                HideControlItem(Item_ChungTuPC);
                HideControlItem(Item_UyNhiemChi);
                _maChungTuPC = 0;
            }
        }
    }


}