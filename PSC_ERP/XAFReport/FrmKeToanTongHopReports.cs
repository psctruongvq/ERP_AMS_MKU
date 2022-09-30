using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
//using Demo.Report.Parameters;
using System.Data.SqlClient;
using ERP_Library;
using DevExpress.XtraLayout;
//using Demo.Report;
//20/03/2013
namespace PSC_ERP
{
    public partial class FrmKeToanTongHopReports : XtraForm
    {
        #region Properties
        private ReportTemplate _reportTemplate;
        ReportTemplateList _reportTemplateList = ReportTemplateList.NewReportTemplateList();
        private XtraReport report;
        DataSet dataSet = new DataSet();
        int _thuMuc = 12;//Thu Muc Bao Cao Kế Toán Tổng Hợp
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        int _UserIdAdmin = 39;
        int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        //int UserId = 39;
        BindingSource _kyBaoCaoKeToanBindingSource = new BindingSource();//typeof(ERP_Library.KyBaoCaoKeToan);
        BindingSource _TaiKhoanNganHangListBindingSource = new BindingSource();//typeof(ERP_Library.KyBaoCaoKeToan);
        HopDongThuChiList _hopDongList = HopDongThuChiList.NewHopDongMuaBanList();
        LoaiTienList _LoaiTienList = LoaiTienList.NewLoaiTienList();
        DoiTuongAllList _NhanVienList;

        DateTime _TuNgay = DateTime.Today.Date;
        DateTime _DenNgay = DateTime.Today.Date;
        int _MaBoPhan;
        int _MaTaiKhoan;
        int _MaLoaiTien = 1;
        string _SoHieuTK = string.Empty;
        string _TenTaiKhoan = string.Empty;
        long _MaDoiTuong;
        int _MaChiTietNganHang = 0;
        long _maHopDong;
        int _MaKhoanMuc = 0;
        string _keyReport = "";

        string _TieuDe = "";
        string strMaTaiKhoan = "";
        string strMaDoiTuong = "";
        CauTrucDoanhThuChiPhiList _KhoanMucList = CauTrucDoanhThuChiPhiList.NewCauTrucDoanhThuChiPhiList();
        #endregion//Properties

        #region Functions
        #region DesignGrid
        //DesignKyBaoCao
        private void DesignKyBaoCaogridLookUpEdit()
        {
            _kyBaoCaoKeToanBindingSource.DataSource = KyBaoCaoKeToan.CreateListKyBaoCaoKeToan();
            HamDungChung.InitGridLookUpDev2(KyBaoCaogridLookUpEdit, _kyBaoCaoKeToanBindingSource, "MoTa", "Ma", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(KyBaoCaogridLookUpEdit, new string[] { "MoTa" }, new string[] { "" }, new int[] { 300 }, false);
            KyBaoCaogridLookUpEdit.EditValueChanged += new System.EventHandler(this.KyBaoCaogridLookUpEdit_EditValueChanged);

            KyBaoCaogridLookUpEdit.EditValue = "NamNay";
        }

        //BoPhanGridlookUpEdit
        private void DesignBoPhanGridlookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(BoPhanGridlookUpEdit, BoPhanList_bindingSource, "TenBoPhan", "MaBoPhan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(BoPhanGridlookUpEdit, new string[] { "TenBoPhan", "MaBoPhanQL" }, new string[] { "Bộ phận", "Mã QL" }, new int[] { 200, 90 }, false);
            BoPhanGridlookUpEdit.EditValueChanged += new System.EventHandler(this.BoPhanGridlookUpEdit_EditValueChanged);
        }

        //TaiKhoanGridLookUpEdit
        private void DesignTaiKhoanGridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(TaiKhoanGridLookUpEdit, heThongTaiKhoanListAllBindingSource, "SoHieuTK", "MaTaiKhoan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(TaiKhoanGridLookUpEdit, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số tài khoản", "Tên tài khoản" }, new int[] { 90, 200 }, false);
            TaiKhoanGridLookUpEdit.EditValueChanged += new System.EventHandler(this.TaiKhoanGridLookUpEdit_EditValueChanged);
        }

        //DoiTuonggridLookUpEdit
        private void DesignDoiTuonggridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(DoiTuonggridLookUpEdit, doiTuongAllListBindingSource, "TenDoiTuong", "MaDoiTuong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(DoiTuonggridLookUpEdit, new string[] { "TenDoiTuong", "MaQLDoiTuong" }, new string[] { "Đối tượng", "Mã Ql" }, new int[] { 200, 90 }, false);
            DoiTuonggridLookUpEdit.EditValueChanged += new System.EventHandler(this.DoiTuonggridLookUpEdit_EditValueChanged);
        }

        //tài khoản ngân hàng     
        private void DesignTaiKhoanNganHang_gridLookUpEdit1()
        {
            _TaiKhoanNganHangListBindingSource.DataSource = ERP_Library.ThanhToan.TaiKhoanNganHangCongTyList.GetTaiKhoanNganHangCongTyList();
            HamDungChung.InitGridLookUpDev2(TaiKhoanNganHang_gridLookUpEdit1, _TaiKhoanNganHangListBindingSource, "SoTaiKhoan", "MaChiTiet", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(TaiKhoanNganHang_gridLookUpEdit1, new string[] { "SoTaiKhoan", "TenNganHang" }, new string[] { "Số tài khoản", "Thuộc ngân hàng" }, new int[] { 100, 200 }, false);
        }

        //HopDongListGridlookUpEdit
        private void DesignHopDongListgridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(HopDongListgridLookUpEdit1, HopDongThuChiList_bindingSource, "SoHopDong", "MaHopDong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(HopDongListgridLookUpEdit1, new string[] { "SoHopDong", "TenHopDong" }, new string[] { "Số hợp đồng", "Nội dung" }, new int[] { 90, 200 }, false);
        }

        //nhân viên
        private void DesignNhanVien_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(NhanVien_gridLookUpEdit1, NhanVienList_bindingSource, "TenDoiTuong", "MaDoiTuong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(NhanVien_gridLookUpEdit1, new string[] { "TenDoiTuong", "MaQLDoiTuong", "Email", }, new string[] { "Nhân viên", "Mã QL", "Email", }, new int[] { 120, 90, 90 }, false);
            //NhanVien_gridLookUpEdit1.EditValueChanged += new System.EventHandler(this.NhanVien_gridLookUpEdit1_EditValueChanged);
            NhanVien_gridLookUpEdit1.EditValue = 0;
        }

        //Khoan muc
        private void DesignCboKhoanMuc()
        {
            HamDungChung.InitGridLookUpDev2(cboKhoanMucPhi, bdKhoanMucPhi, "Ten", "ID", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(cboKhoanMucPhi, new string[] { "Ten", "MaQL" }, new string[] { "Tên Khoản Mục", "Mã QL", }, new int[] { 120, 90 }, false);
            cboKhoanMucPhi.EditValue = 0;

        }
        private void DesignControl()
        {
            DesignKyBaoCaogridLookUpEdit();
            DesignBoPhanGridlookUpEdit();
            DesignTaiKhoanGridLookUpEdit();
            DesignDoiTuonggridLookUpEdit();
            DesignTaiKhoanNganHang_gridLookUpEdit1();
            DesignHopDongListgridLookUpEdit1();
            DesignNhanVien_gridLookUpEdit1();
            DesignCboKhoanMuc();

        }
        #endregion //DesignGrid

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
            TaiKhoanGridLookUpEdit.Properties.Buttons[1].Visible = false;
            DoiTuonggridLookUpEdit.Properties.Buttons[1].Visible = false;
        }

        private void ShowControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
        }

        private void KhoiTao()
        {
            _kyBaoCaoKeToanBindingSource.DataSource = typeof(ERP_Library.KyBaoCaoKeToan);
            BoPhanList_bindingSource.DataSource = typeof(BoPhanList);
            heThongTaiKhoanListAllBindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            doiTuongAllListBindingSource.DataSource = typeof(DoiTuongAllList);
            HopDongThuChiList_bindingSource.DataSource = typeof(HopDongThuChiList);
            bdKhoanMucPhi.DataSource = typeof(CauTrucDoanhThuChiPhiList);
            DesignControl();
            //BoPhanList
            BoPhanList boPhanList = BoPhanList.GetBoPhanListByMaCongTy(_MaCongTy);
            BoPhan itemBoPhan = BoPhan.NewBoPhan("<<Tất cả>>");
            boPhanList.Insert(0, itemBoPhan);
            this.BoPhanList_bindingSource.DataSource = boPhanList;

            //TaiKhoanList
            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("<<Tất cả>>");
            HeThongTaiKhoan1List taikhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            taikhoanList.Insert(0, tk);
            heThongTaiKhoanListAllBindingSource.DataSource = taikhoanList;
            //TaiKhoanNganHangCongTy              

            //DoiTuongList
            DoiTuongAll doituong = DoiTuongAll.NewDoiTuongAll("<<Tất cả>>");
            DoiTuongAllList doiTuongList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0); ;
            doiTuongList.Insert(0, doituong);
            doiTuongAllListBindingSource.DataSource = doiTuongList;

            //HopDongList
            _hopDongList = HopDongThuChiList.NewHopDongMuaBanList();
            HopDongThuChi hdEmpt = HopDongThuChi.NewHopDongMuaBan(0, "<<Tất cả>>");
            _hopDongList.Insert(0, hdEmpt);
            HopDongThuChiList_bindingSource.DataSource = _hopDongList;

            //LoaiTienList
            _LoaiTienList = LoaiTienList.GetLoaiTienList();
            LoaiTien_bindingSource.DataSource = _LoaiTienList;
            grdLU_LoaiTien.EditValue = 1;//gán mặc định là tiền VND

            //nhân viên
            _NhanVienList = DoiTuongAllList.GetDoiTuongAllList_Tim_NhanVien("", _MaCongTy);
            DoiTuongAll nhanvien = DoiTuongAll.NewDoiTuongAll("");
            _NhanVienList.Insert(0, nhanvien);
            NhanVienList_bindingSource.DataSource = _NhanVienList;

            _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
            reportTemplateListBindingSource.DataSource = _reportTemplateList;
            //dateEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            //dateEdit_DenNgay.EditValue = (object)DateTime.Today.Date;

            //Cau Truc Doanh Thu Chi Phi
            _KhoanMucList = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(_MaCongTy);
            CauTrucDoanhThuChiPhi obj = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            obj.Ten = "<<Tất Cả>>";
            _KhoanMucList.Insert(0, obj);
            bdKhoanMucPhi.DataSource = _KhoanMucList;
            cboKhoanMucPhi.EditValue = 0;
        }

        private void LoadHopDongListByDoiTuong(long maDoiTuong)
        {
            _hopDongList = HopDongThuChiList.GetHopDongMuaBanByMaDoiTac_MaCongTy(maDoiTuong);
            HopDongThuChi hdEmpt = HopDongThuChi.NewHopDongMuaBan(0, "<<Tất cả>>");
            _hopDongList.Insert(0, hdEmpt);
            HopDongThuChiList_bindingSource.DataSource = _hopDongList;
        }

        private bool KiemTra(string name)
        {
            bool bFound = false;
            ReportTemplate obj = ReportTemplate.GetReportTemplate(name);
            if (obj.Data != null)
                bFound = true;
            return bFound;
        }

        #region CheckInput

        private bool CheckInputTuNgay()
        {
            if (dateEdit_TuNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Từ Ngày để xem báo cáo!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEdit_TuNgay.Focus();
                return false;
            }
            DateTime dateOut;
            if (DateTime.TryParse(dateEdit_TuNgay.EditValue.ToString(), out dateOut))
            {
                _TuNgay = dateOut.Date;
            }
            return true;
        }
        private bool CheckInputDenNgay()
        {
            if (dateEdit_DenNgay.EditValue == null)
            {
                MessageBox.Show("Hãy nhập vào giá trị Đến Ngày để xem báo cáo!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateEdit_DenNgay.Focus();
                return false;
            }
            DateTime dateOut;
            if (DateTime.TryParse(dateEdit_DenNgay.EditValue.ToString(), out dateOut))
            {
                _DenNgay = dateOut.Date;
            }
            return true;
        }

        private bool CheckInputBoPhan()
        {
            _MaBoPhan = 0;
            int bophanOut;
            if (BoPhanGridlookUpEdit.EditValue != null && int.TryParse(BoPhanGridlookUpEdit.EditValue.ToString(), out bophanOut))
            {
                _MaBoPhan = bophanOut;
            }
            if (_MaBoPhan == 0)
            {
                MessageBox.Show("Hãy nhập vào Thông tin bộ phận để xem báo cáo!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                BoPhanGridlookUpEdit.Focus();
                return false;
            }
            return true;
        }
        private void GetInputBoPhan()
        {
            _MaBoPhan = 0;
            int bophanOut;
            if (BoPhanGridlookUpEdit.EditValue != null && int.TryParse(BoPhanGridlookUpEdit.EditValue.ToString(), out bophanOut))
            {
                _MaBoPhan = bophanOut;
            }
        }

        private bool CheckInputTaiKhoan()
        {
            _MaTaiKhoan = 0;
            int taikhoanOut;
            if (TaiKhoanGridLookUpEdit.EditValue != null && int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out taikhoanOut))
            {
                _MaTaiKhoan = taikhoanOut;
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(taikhoanOut);
                _SoHieuTK = tk.SoHieuTK;
                _TenTaiKhoan = tk.TenTaiKhoan;
            }
            if (_MaTaiKhoan == 0)
            {
                MessageBox.Show("Hãy nhập vào Thông tin Tài khoản để xem báo cáo!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TaiKhoanGridLookUpEdit.Focus();
                return false;
            }
            return true;
        }
        private void GetInputTaiKhoan()
        {
            _MaTaiKhoan = 0;
            int taikhoanOut;
            if (TaiKhoanGridLookUpEdit.EditValue != null && int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out taikhoanOut))
            {
                _MaTaiKhoan = taikhoanOut;
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(taikhoanOut);
                _SoHieuTK = tk.SoHieuTK;
                _TenTaiKhoan = tk.TenTaiKhoan;
            }
        }

        private bool CheckInputDoiTuong()
        {
            _MaDoiTuong = 0;
            long doituongOut;
            if (DoiTuonggridLookUpEdit.EditValue != null && long.TryParse(DoiTuonggridLookUpEdit.EditValue.ToString(), out doituongOut))
            {
                _MaDoiTuong = doituongOut;
            }
            if (_MaDoiTuong == 0)
            {
                MessageBox.Show("Hãy nhập vào Thông tin đối tượng để xem báo cáo!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DoiTuonggridLookUpEdit.Focus();
                return false;
            }
            return true;
        }
        private void GetInputDoiTuong()
        {
            _MaDoiTuong = 0;
            long doituongOut;
            if (DoiTuonggridLookUpEdit.EditValue != null && long.TryParse(DoiTuonggridLookUpEdit.EditValue.ToString(), out doituongOut))
            {
                _MaDoiTuong = doituongOut;
            }
        }

        private bool CheckInputTaiKhoanNganHang()
        {
            _MaChiTietNganHang = 0;
            int tkNganHangOut;
            if (TaiKhoanNganHang_gridLookUpEdit1.EditValue != null && int.TryParse(TaiKhoanNganHang_gridLookUpEdit1.EditValue.ToString(), out tkNganHangOut))
            {
                _MaChiTietNganHang = tkNganHangOut;
            }
            if (_MaChiTietNganHang == 0)
            {
                MessageBox.Show("Hãy nhập vào Thông tin Tài khoản ngân hàng để xem báo cáo!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TaiKhoanNganHang_gridLookUpEdit1.Focus();
                return false;
            }
            return true;
        }
        private void GetInputTaiKhoanNganHang()
        {
            _MaChiTietNganHang = 0;
            int tkNganHangOut;
            if (TaiKhoanNganHang_gridLookUpEdit1.EditValue != null && int.TryParse(TaiKhoanNganHang_gridLookUpEdit1.EditValue.ToString(), out tkNganHangOut))
            {
                _MaChiTietNganHang = tkNganHangOut;
            }
        }

        private bool CheckInputHopDong()
        {
            _maHopDong = 0;
            long hopdongOut;
            if (HopDongListgridLookUpEdit1.EditValue != null && long.TryParse(HopDongListgridLookUpEdit1.EditValue.ToString(), out hopdongOut))
            {
                _maHopDong = hopdongOut;
            }
            if (_maHopDong == 0)
            {
                MessageBox.Show("Hãy nhập vào Thông tin Hợp đồng để xem báo cáo!", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                HopDongListgridLookUpEdit1.Focus();
                return false;
            }
            return true;
        }
        private void GetInputHopDong()
        {
            _maHopDong = 0;
            long hopdongOut;
            if (HopDongListgridLookUpEdit1.EditValue != null && long.TryParse(HopDongListgridLookUpEdit1.EditValue.ToString(), out hopdongOut))
            {
                _maHopDong = hopdongOut;
            }
        }
        #endregion//CheckInput

        #region Cac Phuong Thuc Report
        //01
        public bool Method_SoChiTietTaiKhoan()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "report_SoChiTietTaiKhoan_ModifyForDev";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_Luy Ke
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "aspd_LuyKe_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "aspd_LuyKe";
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
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //01.1
        public bool Method_SoChiTietTaiKhoanTheoDoiTuong()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            _DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "report_SoChiTietTaiKhoanTheoDoiTuong_ModifyForXtraRe";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_Luy Ke
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "aspd_LuyKe_DoiTuong_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "aspd_LuyKe";
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
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                dr["TenDoiTuong"] = _DoiTuong.TenDoiTuong;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //01.2
        public bool Method_SoChiTietTaiKhoan_TheoHopDong()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }

            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            GetInputBoPhan();
            GetInputHopDong();
            DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            _DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            string sohopdong = HopDongListgridLookUpEdit1.Text;
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_Report_SoChiTietTaiKhoanTheoHopdong_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    //command1.Parameters.AddWithValue("@MaKy", maKy);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_Luy Ke
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "aspd_LuyKe_HopDong_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "aspd_LuyKe";
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
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                dtngay.Columns.Add("SoHopDong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                dr["TenDoiTuong"] = _DoiTuong.TenDoiTuong;
                dr["SoHopDong"] = sohopdong;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //02
        public bool Method_SoNhatKyChung()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "report_SoNhatKyChung_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserId", UserId);
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
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //03
        public bool Method_SoQuyTienMat()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_MainReport";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@UserId", UserId);
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
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //04
        public bool Method_SoQuyTienGui()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_MainReport";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@UserId", UserId);
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
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //05
        public bool Method_SoCai()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputBoPhan();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_SoDuDau_TaiKhoan_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_SoDuDau_TaiKhoan;1";
                    dataSet.Tables.Add(dt);
                }
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_SoCai_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserId", UserId);
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
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //06
        public bool Method_ChungTuGhiSo()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_MainReport";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@UserId", UserId);
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
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //
        public bool Method_BangTongHopCongNoDoiDoiTuong()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputBoPhan();
            GetInputDoiTuong();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    //cm.CommandText = "spd_BangCanDoiSoPhatSinh_DoiTuong_Modify";
                    cm.CommandText = "spRpt_TongHopCongNoDoiTuong";
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@UserId", UserId);
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
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //07
        public bool Method_BangCanDoiPhatSinh()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            GetInputBoPhan();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    //cm.CommandText = "spd_BangCanDoiSoPhatSinh_CapBa_TheoNgay_Modify";
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_BangCanDoiPhatSinh_New";
                    cm.CommandTimeout = 0;
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan.ToString());
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    if (chkSoDuHaiBen.Checked == true)
                    {
                        cm.Parameters.AddWithValue("@buTru", false);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@buTru", true);
                    }

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
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //08
        public bool Method_BangCanDoiKeToan()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_Report_BangCanDoiKeToan_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_BangCanDoiKeToantheoNHNN;1";
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
                    dt.TableName = "spd_REPORT_ReportHeader;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("TieuDe", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["TieuDe"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //09
        public bool Method_BaoCaoKetQuaHoatDongKinhDoanh()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            GetInputBoPhan();
            string mabophanStr = string.Empty;
            if (_MaBoPhan == 0) mabophanStr = "";
            else mabophanStr = _MaBoPhan.ToString();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_report_BaoCaoketQuaHoatDongKinhDoanhTheoBoPhan_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", mabophanStr);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_report_BaoCaoketQuaHoatDongKinhDoanhtheoThongTu;1";
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
                    dt.TableName = "spd_REPORT_ReportHeader;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("TieuDe", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["TieuDe"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_BangKetQuaHoatDongKinhDoanh_zTemp()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            GetInputBoPhan();
            string mabophanStr = string.Empty;
            if (_MaBoPhan == 0) mabophanStr = "";
            else mabophanStr = _MaBoPhan.ToString();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_BangKetQuaHoatDongKinhDoanh_zTemp";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@MaBoPhan", mabophanStr);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "mainData";
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
                    dt.TableName = "spd_REPORT_ReportHeader";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("TieuDe", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["TieuDe"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        //10
        public bool Method_BaoCaoChiTietKetQuaHoatDongKinhDoanh()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_MainReport";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_report_BaoCaoLuuChuyenTienTetheoThongTu;1";
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
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("TieuDe", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["TieuDe"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //11
        public bool Method_BaoCaoLuuChuyenTienTe()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            int theoThoiGian = 0;
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spd_report_BaoCaoLuuChuyenTienTe_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@TheoThoiGian", theoThoiGian);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_report_BaoCaoLuuChuyenTienTetheoThongTu;1";
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
                    dt.TableName = "spd_REPORT_ReportHeader;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("TieuDe", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["TieuDe"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //12--

        #region ThuyetMinhBaoCaoTaiChinh
        public bool Method_ThuyetMinhBaoCaoTaiChinhtheoThongTu()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            string TieuDe = "Tiêu đề";
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                DateTime NgayDauNam;
                NgayDauNam = Convert.ToDateTime("1/1/" + _TuNgay.Year.ToString());
                SqlDataAdapter da = new SqlDataAdapter();
                #region PhanDoanI
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandText = "spd_MauTMBCTaiChinh_PhanDoanMot_ThongTu";
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    cm.CommandType = CommandType.StoredProcedure;
                    DataTable dt = new DataTable("spd_MauTMBCTaiChinh_PhanDoanMot");
                    da = new SqlDataAdapter();
                    da.SelectCommand = cm;
                    try
                    {
                        da.Fill(dt);
                    }
                    catch (Exception ex)
                    {

                    }

                    dataSet.Tables.Add(dt);
                }
                #endregion PhanDoanI

                #region PhanDoanII
                using (SqlCommand cm2 = cn.CreateCommand())
                {
                    cm2.CommandText = "spd_MauTMBCTaiChinh_PhanDoanHai_From1to3";
                    cm2.CommandType = CommandType.StoredProcedure;
                    cm2.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm2.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm2.Parameters.AddWithValue("@UserId", UserId);
                    DataTable dt2 = new DataTable();
                    da.SelectCommand = cm2;
                    try
                    {
                        da.Fill(dt2);
                    }
                    catch (Exception ex)
                    {

                    }
                    dt2.TableName = "spd_MauTMBCTaiChinh_PhanDoanHai_From1to3";
                    dataSet.Tables.Add(dt2);
                }

                using (SqlCommand cm2_2 = cn.CreateCommand())
                {
                    cm2_2.CommandText = "spd_MauTMBCTaiChinh_PhanDoanHai_4TSCD";
                    cm2_2.CommandType = CommandType.StoredProcedure;
                    cm2_2.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm2_2.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm2_2.Parameters.AddWithValue("@UserId", UserId);
                    DataTable dt2_2 = new DataTable();
                    da.SelectCommand = cm2_2;
                    try
                    {
                        da.Fill(dt2_2);
                    }
                    catch (Exception ex)
                    {

                    }
                    dt2_2.TableName = "spd_MauTMBCTaiChinh_PhanDoanHai_4TSCD";
                    dataSet.Tables.Add(dt2_2);
                }

                using (SqlCommand cm2_6 = cn.CreateCommand())
                {
                    cm2_6.CommandText = "spd_MauTMBCTaiChinh_PhanDoanHai_From5to14";
                    cm2_6.CommandType = CommandType.StoredProcedure;
                    cm2_6.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm2_6.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm2_6.Parameters.AddWithValue("@UserId", UserId);
                    DataTable dt2_6 = new DataTable();
                    da.SelectCommand = cm2_6;
                    try
                    {
                        da.Fill(dt2_6);
                    }
                    catch (Exception ex)
                    {

                    }
                    dt2_6.TableName = "spd_MauTMBCTaiChinh_PhanDoanHai_From5to14";
                    dataSet.Tables.Add(dt2_6);
                }

                using (SqlCommand cm2_8 = cn.CreateCommand())
                {
                    cm2_8.CommandText = "spd_MauTMBCTaiChinh_PhanDoanHai_15BienDongNguonVon";
                    cm2_8.CommandType = CommandType.StoredProcedure;
                    cm2_8.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm2_8.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm2_8.Parameters.AddWithValue("@UserId", UserId);
                    DataTable dt2_8 = new DataTable();
                    da.SelectCommand = cm2_8;
                    try
                    {
                        da.Fill(dt2_8);
                    }
                    catch (Exception ex)
                    {

                    }
                    dt2_8.TableName = "spd_MauTMBCTaiChinh_PhanDoanHai_15BienDongNguonVon";
                    dataSet.Tables.Add(dt2_8);
                }
                using (SqlCommand cm2_9 = cn.CreateCommand())
                {
                    cm2_9.CommandText = "spd_MauTMBCTaiChinh_PhanDoanHai_16Khac";
                    cm2_9.CommandType = CommandType.StoredProcedure;
                    cm2_9.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm2_9.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm2_9.Parameters.AddWithValue("@UserId", UserId);
                    DataTable dt2_9 = new DataTable();
                    da.SelectCommand = cm2_9;
                    try
                    {
                        da.Fill(dt2_9);
                    }
                    catch (Exception ex)
                    {

                    }
                    dt2_9.TableName = "spd_MauTMBCTaiChinh_PhanDoanHai_16Khac";
                    dataSet.Tables.Add(dt2_9);
                }


                #endregion//PhanDoanII

                #region PhanDoanIII
                using (SqlCommand cm3 = cn.CreateCommand())
                {
                    cm3.CommandText = "spd_MauTMBCTaiChinh_PhanDoanBa_ThongTu";
                    cm3.CommandType = CommandType.StoredProcedure;
                    cm3.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm3.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm3.Parameters.AddWithValue("@UserId", UserId);
                    da = new SqlDataAdapter();
                    DataTable dt3 = new DataTable("spd_MauTMBCTaiChinh_PhanDoanBa");
                    da.SelectCommand = cm3;
                    try
                    {
                        da.Fill(dt3);
                    }
                    catch (Exception ex)
                    {

                    }

                    dataSet.Tables.Add(dt3);
                }
                #endregion PhanDoanIII

                #region PhanDoanIV
                using (SqlCommand cm4 = cn.CreateCommand())
                {
                    cm4.CommandText = "spd_MauTMBCTaiChinh_PhanDoanBon_ThongTu";
                    cm4.CommandType = CommandType.StoredProcedure;
                    cm4.Parameters.AddWithValue("@TuNgay", NgayDauNam);
                    cm4.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm4.Parameters.AddWithValue("@UserId", UserId);
                    DataTable dt4 = new DataTable("spd_MauTMBCTaiChinh_PhanDoanBon");
                    da.SelectCommand = cm4;
                    try
                    {
                        da.Fill(dt4);
                    }
                    catch (Exception ex)
                    {

                    }

                    dataSet.Tables.Add(dt4);
                }
                #endregion PhanDoanIV

                #region PhanDoanV
                using (SqlCommand cm4_5 = cn.CreateCommand())
                {
                    cm4_5.CommandText = "spd_MauTMBCTaiChinh_PhanDoanNam_ThongTu";
                    cm4_5.CommandType = CommandType.StoredProcedure;
                    cm4_5.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm4_5.Parameters.AddWithValue("@UserId", UserId);
                    DataTable dt4_5 = new DataTable("spd_MauTMBCTaiChinh_PhanDoanNam_ThongTu");
                    da.SelectCommand = cm4_5;
                    try
                    {
                        da.Fill(dt4_5);
                    }
                    catch (Exception ex)
                    {

                    }

                    dataSet.Tables.Add(dt4_5);
                }
                #endregion PhanDoanV

                using (SqlCommand cm10 = cn.CreateCommand())
                {
                    cm10.CommandText = "spd_ReportHeaderAndFooter";
                    cm10.Parameters.AddWithValue("@MaNguoiLap", UserId);
                    //cm10.CommandText = "spd_report_ReportHeader";
                    //cm10.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm10.CommandType = CommandType.StoredProcedure;
                    DataTable dt10 = new DataTable("spd_REPORT_ReportHeader");
                    da.SelectCommand = cm10;
                    try
                    {
                        da.Fill(dt10);
                    }
                    catch (Exception ex)
                    {
                    }
                    dataSet.Tables.Add(dt10);
                }

            }//us 
            DataTable dtParameter = new DataTable();
            dtParameter.TableName = "tblParameter";
            dtParameter.Columns.Add("TieuDe", typeof(string));
            dtParameter.Rows.Add(TieuDe);
            dataSet.Tables.Add(dtParameter);
            return true;
        }

        #endregion//ThuyetMinhBaoCaoTaiChinh


        //bổ sung ngày 08/12/2017
        public bool Method_ChiTietCongNoPhaiTra()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            _DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    //cm.CommandText = "spdReport_ChiTietCongNoPhaiTra";
                    cm.CommandText = "spRpt_ChiTietTaiKhoanTheoDoiTuong";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);
                    cm.Parameters.AddWithValue("@UserID", UserId);

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                if (_DoiTuong.MaDoiTuong == 0)
                    dr["TenDoiTuong"] = "Tất cả";
                else
                    dr["TenDoiTuong"] = _DoiTuong.TenDoiTuong;
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);
            }//us
            return true;
        }

        public bool Method_ChiTietCongNoPhaiThu()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            _DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    //cm.CommandText = "spdReport_ChiTietCongNoPhaiTra";
                    cm.CommandText = "spRpt_ChiTietTaiKhoanTheoDoiTuong";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);
                    cm.Parameters.AddWithValue("@UserID", UserId);

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                if (_DoiTuong.MaDoiTuong == 0)
                    dr["TenDoiTuong"] = "Tất cả";
                else
                    dr["TenDoiTuong"] = _DoiTuong.TenDoiTuong;
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);
            }//us
            return true;
        }

        public bool Method_ChiTietCongNoPhaiTraTheoHoaDon()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            _DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spdReport_ChiTietCongNoPhaiTraTheoHoaDon";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                if (_DoiTuong.MaDoiTuong == 0)
                    dr["TenDoiTuong"] = "Tất cả";
                else
                    dr["TenDoiTuong"] = _DoiTuong.TenDoiTuong;
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoChiTietTaiKhoanTheoDoiTuongNew()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            GetInputTaiKhoan();
            GetInputDoiTuong();
            DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            _DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    //cm.CommandText = "spdReport_ChiTietTaiKhoanTheoDoiTuongNew";
                    cm.CommandText = "spRpt_ChiTietTaiKhoanTheoDoiTuong";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    cm.Parameters.AddWithValue("@strMaTaiKhoan", this.strMaTaiKhoan);
                    cm.Parameters.AddWithValue("@strMaDoiTuong", this.strMaDoiTuong);

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                if (_DoiTuong.MaDoiTuong == 0)
                    dr["TenDoiTuong"] = "Tất cả";
                else
                    dr["TenDoiTuong"] = _DoiTuong.TenDoiTuong;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        //2019.05.15 
        public bool Method_ChiTietCongNoPhaiTra_RutGon()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            _DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    //cm.CommandText = "spdReport_ChiTietCongNoPhaiTra";
                    cm.CommandText = "spRpt_ChiTietTaiKhoanTheoDoiTuong_ChuaCanTruHoaDon";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);
                    cm.Parameters.AddWithValue("@UserID", UserId);

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                if (_DoiTuong.MaDoiTuong == 0)
                    dr["TenDoiTuong"] = "Tất cả";
                else
                    dr["TenDoiTuong"] = _DoiTuong.TenDoiTuong;
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);
            }//us
            return true;
        }

        public bool Method_ChiTietCongNoTamUng_RutGon()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            _DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    //cm.CommandText = "spdReport_ChiTietCongNoPhaiTra";
                    cm.CommandText = "spRpt_ChiTietTaiKhoanTheoDoiTuong_RutGon";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);
                    cm.Parameters.AddWithValue("@UserID", UserId);

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                if (_DoiTuong.MaDoiTuong == 0)
                    dr["TenDoiTuong"] = "Tất cả";
                else
                    dr["TenDoiTuong"] = _DoiTuong.TenDoiTuong;
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);
            }//us
            return true;
        }

        public bool Method_SoKeToanChiTietQuyTienMat()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();          
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spdReport_SoKeToanChiTietQuyTienMat";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);
                    cm.Parameters.AddWithValue("@UserID", UserId);
                    if (radTheoChiTiet.Checked)
                    {
                        cm.Parameters.AddWithValue("@Action", "");
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@Action", "TheoChungTu");
                    }

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenTaiKhoan"] = _TenTaiKhoan;
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoTienGuiNganHangChiTiet()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            dataSet = new DataSet();
            CheckInputTaiKhoanNganHang();
            CongTy_NganHang nganHang = CongTy_NganHang.GetCongTy_NganHang(_MaChiTietNganHang);
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spdReport_SoTienGuiNganHangChiTiet";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);
                    cm.Parameters.AddWithValue("@MaTaiKhoanNH", _MaChiTietNganHang);

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("NganHang", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["NganHang"] = nganHang.SoTaiKhoan + " - " + nganHang.TenNganHang;
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoTienGuiNganHangChiTiet_NgoaiTe()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            dataSet = new DataSet();
            CheckInputTaiKhoanNganHang();
            CongTy_NganHang nganHang = CongTy_NganHang.GetCongTy_NganHang(_MaChiTietNganHang);
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spdReport_SoTienGuiNganHangChiTiet_NgoaiTe";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);
                    cm.Parameters.AddWithValue("@MaTaiKhoanNH", _MaChiTietNganHang);

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("NganHang", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["NganHang"] = nganHang.SoTaiKhoan + " - " + nganHang.TenNganHang;
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_BangKeSoDuNganHang()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            dataSet = new DataSet();
            //CheckInputTaiKhoanNganHang();
            //CongTy_NganHang nganHang = CongTy_NganHang.GetCongTy_NganHang(_MaChiTietNganHang);
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_BangKeSoDuNganHang";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    //cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);
                    //cm.Parameters.AddWithValue("@MaTaiKhoanNH", _MaChiTietNganHang);
                    cm.Parameters.AddWithValue("@userID", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spRpt_BangKeSoDuNganHang";
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
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("NganHang", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["NganHang"] = "";
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoTienGuiNganHang()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spdReport_SoTienGuiNganHangChiTiet";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaLoaiTien", _MaLoaiTien);
                    cm.Parameters.AddWithValue("@MaTaiKhoanNH", 0);
                    //cm.Parameters.AddWithValue("@MaTaiKhoanNH", _MaChiTietNganHang);

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenLoaiTien", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = _SoHieuTK;
                dr["TenLoaiTien"] = grdLU_LoaiTien.Text;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_TongHopCongNoNhanVien()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spdReport_TongHopCongNoNhanVien";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    //cm.Parameters.AddWithValue("@MaNhanVien", _MaChiTietNganHang);
                    cm.Parameters.AddWithValue("@MaNhanVien", NhanVien_gridLookUpEdit1.EditValue.ToString());

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
                dtngay.Columns.Add("SoHieuTK", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                if (_SoHieuTK == string.Empty || _SoHieuTK == "")
                    dr["SoHieuTK"] = "Tất cả";
                else
                    dr["SoHieuTK"] = _SoHieuTK;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        //
        public bool Method_SoChiTietTaiKhoan_New()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_SoChiTietTaiKhoan";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    cm.Parameters.AddWithValue("@strMaTaiKhoan", this.strMaTaiKhoan);
                    cm.CommandTimeout = 3000;
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_Luy Ke
                //using (SqlCommand cm = cn.CreateCommand())
                //{
                //    cm.CommandType = CommandType.StoredProcedure;
                //    cm.CommandText = "aspd_LuyKe_DoiTuong_Modify";
                //    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                //    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                //    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                //    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                //    cm.Parameters.AddWithValue("@UserId", UserId);
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    dt.TableName = "aspd_LuyKe";
                //    dataSet.Tables.Add(dt);
                //}
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoChiTietTaiKhoanTheoDoiTuong_New()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_SoChiTietTaiKhoan_DoiTuong";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@UserId", UserId);                    

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_Luy Ke
                //using (SqlCommand cm = cn.CreateCommand())
                //{
                //    cm.CommandType = CommandType.StoredProcedure;
                //    cm.CommandText = "aspd_LuyKe_DoiTuong_Modify";
                //    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                //    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                //    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                //    cm.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                //    cm.Parameters.AddWithValue("@UserId", UserId);
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    dt.TableName = "aspd_LuyKe";
                //    dataSet.Tables.Add(dt);
                //}
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoChiTietTheoKhoanMuc()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            _MaKhoanMuc = 0;
            int.TryParse(cboKhoanMucPhi.EditValue.ToString(), out _MaKhoanMuc);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_SoChiTietTheoKhoanMuc";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaKhoanMuc", _MaKhoanMuc);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    cm.Parameters.AddWithValue("@strMaTaiKhoan", this.strMaTaiKhoan);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoChiTietTheoDonVi()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            _MaBoPhan = 0;
            int.TryParse(BoPhanGridlookUpEdit.EditValue.ToString(), out _MaBoPhan);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_SoChiTietTheoDonVi";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaDonVi", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoTongHopTheoDonVi()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            _MaBoPhan = 0;
            int.TryParse(BoPhanGridlookUpEdit.EditValue.ToString(), out _MaBoPhan);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_SoTongHopTheoDonVi";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaDonVi", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoTongHopTheoKhoanMuc()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            _MaKhoanMuc = 0;
            int.TryParse(cboKhoanMucPhi.EditValue.ToString(), out _MaKhoanMuc);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_SoTongHopTheoKhoanMuc";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@MaKhoanMuc", _MaKhoanMuc);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    cm.Parameters.AddWithValue("@strMaTaiKhoan", this.strMaTaiKhoan);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_TongHopCayChiPhi()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            _MaKhoanMuc = 0;
            int.TryParse(cboKhoanMucPhi.EditValue.ToString(), out _MaKhoanMuc);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_TongHopCayChiPhi";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    //cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    //cm.Parameters.AddWithValue("@MaKhoanMuc", _MaKhoanMuc);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    cm.Parameters.AddWithValue("@strMaTaiKhoan", this.strMaTaiKhoan);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_BangCanDoiKeToan_zTemp()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_BangCanDoiKeToan";
                    cm.Parameters.AddWithValue("@TuNgay", dateEdit_TuNgay.EditValue);
                    cm.Parameters.AddWithValue("@DenNgay", dateEdit_DenNgay.EditValue);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_BangCanDoiKeToantheoNHNN;1";
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
                    dt.TableName = "spd_REPORT_ReportHeader;1";
                    dataSet.Tables.Add(dt);
                }
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("TieuDe", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["TieuDe"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_BangKeThuPhiHocSinh()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            _MaKhoanMuc = 0;
            int.TryParse(cboKhoanMucPhi.EditValue.ToString(), out _MaKhoanMuc);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_BangKeThuPhiHocSinh";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);                    
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);                   
                    cm.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_BangKeDoanhThuChuaThucHien()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            _MaKhoanMuc = 0;
            int.TryParse(cboKhoanMucPhi.EditValue.ToString(), out _MaKhoanMuc);

            if (this.strMaTaiKhoan == "")
                this.strMaTaiKhoan = strMaTaiKhoan + _MaTaiKhoan;

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_BangKeDoanhThuChuaThucHien";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@strMaTaiKhoan", this.strMaTaiKhoan);
                    cm.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoChiTietTaiKhoanNganHang()
        {
            CheckInputTuNgay();
            CheckInputDenNgay();
            CheckInputTaiKhoanNganHang();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_SoChiTietTaiKhoanNganHang";                   
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoanNH", _MaChiTietNganHang);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    if (radTheoChiTiet.Checked)
                    {
                        cm.Parameters.AddWithValue("@Action", "");
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@Action", "TheoChungTu");
                    }


                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_Luy Ke
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "aspd_LuyKe_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "aspd_LuyKe";
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
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoChiTietTaiKhoanNganHang_TheoNgayGhiSo()
        {
            CheckInputTuNgay();
            CheckInputDenNgay();
            CheckInputTaiKhoanNganHang();

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_SoChiTietTaiKhoanNganHang_TheoNgayGhiSo";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoanNH", _MaChiTietNganHang);
                    cm.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                    if (radTheoChiTiet.Checked)
                    {
                        cm.Parameters.AddWithValue("@Action", "");
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@Action", "TheoChungTu");
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_Luy Ke
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "aspd_LuyKe_Modify";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "aspd_LuyKe";
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
                    dt.TableName = "spd_ReportHeaderAndFooter";
                    dataSet.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_SoTongHopBanHang()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputBoPhan();
            GetInputDoiTuong();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_SoTongHopBanHang";                    
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@strMaDoiTuong", _MaDoiTuong);
                    cm.Parameters.AddWithValue("@strMaKhoanMuc", _MaKhoanMuc);
                    cm.Parameters.AddWithValue("@UserId", UserId);
                    if (radTheoDoiTuong.Checked)
                        cm.Parameters.AddWithValue("@Action", "TheoDoiTuong");
                    else if (radTheoKhoanMuc.Checked)
                        cm.Parameters.AddWithValue("@Action", "TheoKhoanMuc");

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
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_BangKeGiayNhanNo()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            
            GetInputBoPhan();
            //GetInputDoiTuong();
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_BangKeGiayNhanNo";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);                   
                    cm.Parameters.AddWithValue("@UserId", UserId);                   

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
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_BangTongHopPhatSinhTaiKhoan()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay() || !CheckInputTaiKhoan())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            CheckInputTaiKhoan();
           
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_BangTongHopPhatSinhTaiKhoan";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);                  
                    cm.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dataSet.Tables.Add(dt);
                }
                //tao bang_Luy Ke
               
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));               
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;               
               
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }

        public bool Method_HocSinhDaXuatHoaDon_or_DaThuTien()
        {
            if (!CheckInputTuNgay() || !CheckInputDenNgay())
            {
                return false;
            }
            //CheckInputTuNgay();
            //CheckInputDenNgay();
            //CheckInputTaiKhoan();
            GetInputDoiTuong();
            //DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
            //_DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
            _MaTaiKhoan = 0;
            int.TryParse(TaiKhoanGridLookUpEdit.EditValue.ToString(), out _MaTaiKhoan);
            _MaKhoanMuc = 0;
            int.TryParse(cboKhoanMucPhi.EditValue.ToString(), out _MaKhoanMuc);

            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandTimeout = 3000;
                    cm.CommandText = "spRpt_HocSinhDaXuatHoaDon_or_DaThuTien";
                    cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    cm.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    cm.Parameters.AddWithValue("@UserId", UserId);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
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

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dateEdit_TuNgay.EditValue;
                dr["DenNgay"] = dateEdit_DenNgay.EditValue;
                dr["SoHieuTK"] = "";
                dr["TenTaiKhoan"] = "";
                dr["TenDoiTuong"] = "";
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dataSet.Tables.Add(dtngay);

            }//us
            return true;
        }
        #endregion//Cac Phuong Thuc Report

        #region Xem BaoCao

        private void PrintForReportDevexpress()
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
                #region Customize
                if (_report.Id == "IDReport_SoChiTietTaiKhoan" && _MaDoiTuong != 0)
                {
                    _report = ReportTemplate.GetReportTemplate("IDReport_SoChiTietTaiKhoanTheoDoiTuong", _UserIdAdmin, DateTime.Today.Date);
                    _reportTemplate = ReportTemplate.GetReportTemplate("IDReport_SoChiTietTaiKhoanTheoDoiTuong", UserId, dtDenNgay);
                }
                else
                {
                    _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                }
                #endregion //Customize

                //B
                //_reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);//Thay The boi Phan Customize
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

                if (chkXemDangLuoi.Visible && chkXemDangLuoi.Checked)
                {
                    frmShowReportForGrid frmGrid = new frmShowReportForGrid(_report.TenPhuongThuc,dataSet);
                    frmGrid.Show();
                    return;
                }

                if (daChonParameter)
                {
                    frm.HienThiReport(_reportTemplate, dataSet);
                    frm.Show();
                    //frm.ShowDialog();
                }
                _reportTemplateList = ReportTemplateList.GetReportTemplateList(_thuMuc);
                reportTemplateListBindingSource.DataSource = _reportTemplateList;
                //E
            }
        }
        private void PrintReport()
        {
            GetInputDoiTuong();
            if (
                //(_keyReport == "IDReport_SoChiTietTaiKhoan" && _MaDoiTuong != 0)
                //||
                //(_keyReport == "IDReport_SoChiTietTaiKhoan" && _MaDoiTuong == 0)
                //||
                //_keyReport == "IDReport_SoNhatKyChung"
                //|| 
                //_keyReport == "IDReport_SoCai"
                //||
                //_keyReport == "IDReport_BangCanDoiPhatSinh"
                //||
                _keyReport == "IDReport_ChungTuGhiSo"
                //|| _keyReport == "IDReport_SoChiTiet_NganHang"
                //|| _keyReport == "IDReport_SoChiTiet_NganHang_NgayLap"
                //|| _keyReport == "IDReport_SoChiTietTaiKhoan_TheoHopDong"
                || _keyReport == "IDReport_BangTongHopTheoHopDong"
                )
            {
                PrintForReportCrystal();
            }
            else
            {
                PrintForReportDevexpress();
            }
        }
        #endregion//Xem BaoCao

        private void PrintForReportCrystal()
        {
            CrystalDecisions.CrystalReports.Engine.ReportDocument reportCrytal = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            dataSet = new DataSet();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(Database.ERP_Connection);
            command.CommandTimeout = 0;

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.Connection = new SqlConnection(Database.ERP_Connection);
            command1.CommandTimeout = 0;

            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.Connection = new SqlConnection(Database.ERP_Connection);
            command2.CommandTimeout = 0;

            SqlCommand command3 = new SqlCommand();
            command3.CommandType = CommandType.StoredProcedure;
            command3.Connection = new SqlConnection(Database.ERP_Connection);

            SqlCommand command4 = new SqlCommand();
            command4.CommandType = CommandType.StoredProcedure;
            command4.Connection = new SqlConnection(Database.ERP_Connection);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataTable table1 = new DataTable();
            DataTable table2 = new DataTable();
            DataTable table3 = new DataTable();
            DataTable table4 = new DataTable();

            #region SoChiTietTaiKhoan
            if (_keyReport == "IDReport_SoChiTietTaiKhoan")
            {
                CheckInputTuNgay();
                CheckInputDenNgay();
                CheckInputTaiKhoan();
                GetInputDoiTuong();
                if (_MaDoiTuong == 0)
                {
                    reportCrytal = new Report.ReportTongHop.Report_SoChiTietTaiKhoan();
                    command.CommandText = "report_SoChiTietTaiKhoan_SoDuDau_Modify";
                    command.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    command.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    command.Parameters.AddWithValue("@UserID", UserId);
                    command.CommandTimeout = 0;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";


                    command1.CommandText = "report_SoChiTietTaiKhoan_Modify";
                    command1.CommandTimeout = 0;
                    command1.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    command1.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    command1.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    command1.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    command1.Parameters.AddWithValue("@UserID", UserId);
                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "report_SoChiTietTaiKhoan;1";

                    command2.CommandText = "spd_REPORT_ReportHeader_Modify";
                    command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    command2.Parameters.AddWithValue("@UserId", UserId);
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "spd_REPORT_ReportHeader;1";


                    command3.CommandText = "spd_LayNguoiKyTenCongNo";
                    command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    adapter.SelectCommand = command3;
                    adapter.Fill(table3);
                    table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                    command4.CommandText = "aspd_LuyKe_Modify";
                    command4.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    command4.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    command4.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    command4.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    command4.Parameters.AddWithValue("@UserId", UserId);
                    command4.CommandTimeout = 0;
                    //command4.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    adapter.SelectCommand = command4;
                    adapter.Fill(table4);
                    table4.TableName = "aspd_LuyKe;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table3);
                    dataSet.Tables.Add(table4);

                    reportCrytal.SetDataSource(dataSet);

                    reportCrytal.SetParameterValue("@MaTaiKhoan", _MaTaiKhoan);
                    reportCrytal.SetParameterValue("@NgayBatDau", _TuNgay);
                    reportCrytal.SetParameterValue("@NgayKetThuc", _DenNgay);

                }
                else
                {
                    DoiTuongAll _DoiTuong = DoiTuongAll.NewDoiTuongAll(0);
                    _DoiTuong = DoiTuongAll.GetDoiTuongAll(_MaDoiTuong);
                    reportCrytal = new Report.ReportTongHop.Report_SoChiTietTaiKhoanTheoDoiTuong();

                    command.CommandText = "report_SoChiTietTaiKhoan_SoDuDau_Modify";
                    command.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    command.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.CommandTimeout = 0;
                    adapter.SelectCommand = command;
                    adapter.Fill(table);
                    table.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                    command1.CommandText = "report_SoChiTietTaiKhoanTheoDoiTuong_Modify";
                    command1.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    command1.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    command1.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    command1.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                    command1.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    command1.Parameters.AddWithValue("@UserId", UserId);
                    adapter.SelectCommand = command1;
                    adapter.Fill(table1);
                    table1.TableName = "report_SoChiTietTaiKhoanTheoDoiTuong;1";

                    command2.CommandText = "spd_REPORT_ReportHeader_Modify";
                    command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    command2.Parameters.AddWithValue("@UserId", UserId);
                    adapter.SelectCommand = command2;
                    adapter.Fill(table2);
                    table2.TableName = "spd_REPORT_ReportHeader;1";

                    command3.CommandText = "spd_LayNguoiKyTenCongNo";
                    command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    adapter.SelectCommand = command3;
                    adapter.Fill(table3);
                    table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                    command4.CommandText = "aspd_LuyKe_DoiTuong_Modify";
                    command4.Parameters.AddWithValue("@TuNgay", _TuNgay);
                    command4.Parameters.AddWithValue("@DenNgay", _DenNgay);
                    command4.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                    command4.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                    command4.Parameters.AddWithValue("@UserId", UserId);
                    adapter.SelectCommand = command4;
                    adapter.Fill(table4);
                    table4.TableName = "aspd_LuyKe_DoiTuong;1";

                    dataSet.Tables.Add(table);
                    dataSet.Tables.Add(table1);
                    dataSet.Tables.Add(table2);
                    dataSet.Tables.Add(table3);
                    dataSet.Tables.Add(table4);

                    reportCrytal.SetDataSource(dataSet);

                    reportCrytal.SetParameterValue("@MaTaiKhoan", _MaTaiKhoan);
                    reportCrytal.SetParameterValue("@NgayBatDau", _TuNgay);
                    reportCrytal.SetParameterValue("@NgayKetThuc", _DenNgay);
                    reportCrytal.SetParameterValue("@TuNgay", _TuNgay);
                    reportCrytal.SetParameterValue("@DenNgay", _DenNgay);
                    reportCrytal.SetParameterValue("@MaBoPhan", _MaBoPhan);
                    reportCrytal.SetParameterValue("@MaDoiTuong", _DoiTuong.MaDoiTuong);
                    reportCrytal.SetParameterValue("@TenDoiTuong", _DoiTuong.TenDoiTuong);
                }
                //Report.SetParameterValue("@TenBoPhan", tenbophan);
            }
            #endregion//SoChiTietTaiKhoan

            #region SoNhatKyChung
            if (_keyReport == "IDReport_SoNhatKyChung")
            {
                CheckInputTuNgay();
                CheckInputDenNgay();
                GetInputBoPhan();

                reportCrytal = new Report.ReportTongHop.Report_SoNhatKyChung();
                command.CommandText = "report_SoNhatKyChung_Modify";
                command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                command.Parameters.AddWithValue("@UserId", UserId);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "report_SoNhatKyChung;1";
                //--
                command1.CommandText = "spd_REPORT_ReportHeader_Modify";
                command1.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
                command1.Parameters.AddWithValue("@UserId", UserId);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                //--
                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";
                //--
                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table3);
                reportCrytal.SetDataSource(dataSet);
                reportCrytal.SetParameterValue("@NgayBatDau", _TuNgay);
                reportCrytal.SetParameterValue("@NgayKetThuc", _DenNgay);
            }
            #endregion//SoNhatKyChung

            #region SoCai
            if (_keyReport == "IDReport_SoCai")
            {
                CheckInputTuNgay();
                CheckInputDenNgay();
                CheckInputTaiKhoan();
                GetInputBoPhan();
                reportCrytal = new Report.ReportTongHop.SoCai();
                command.CommandText = "spd_SoDuDau_TaiKhoan_Modify";
                command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                command.Parameters.AddWithValue("@UserId", UserId);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_SoDuDau_TaiKhoan;1";
                command1.CommandText = "spd_SoCai_Modify";
                command1.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command1.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command1.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                command1.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                command1.Parameters.AddWithValue("@UserId", UserId);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_SoCai;1";
                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                reportCrytal.SetDataSource(dataSet);
                reportCrytal.SetParameterValue("ngayBatDau", _TuNgay);
                reportCrytal.SetParameterValue("ngayKetThuc", _DenNgay);
            }
            #endregion//SoCai

            #region BangCanDoiSoPhatSinh
            if (_keyReport == "IDReport_BangCanDoiPhatSinh")
            {
                CheckInputTuNgay();
                CheckInputDenNgay();
                GetInputBoPhan();
                string bophanString = "";
                if (_MaBoPhan != 0)
                {
                    bophanString = _MaBoPhan.ToString();
                }
                #region New
                reportCrytal = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapBa_TheoNgay();
                command.CommandText = "spd_BangCanDoiSoPhatSinh_CapBa_TheoNgay_Modify";
                command.CommandTimeout = 0;
                command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan.ToString());
                command.Parameters.AddWithValue("@UserId", UserId);

                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BangCanDoiSoPhatSinh_CapBa_TheoNgay;1";

                command1.CommandText = "spd_REPORT_ReportHeader_Modify";
                adapter.SelectCommand = command1;
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                command1.Parameters.AddWithValue("@UserId", UserId);

                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", UserId);


                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", UserId);

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table4);

                reportCrytal.SetDataSource(dataSet);
                reportCrytal.SetParameterValue("@TuNgay", _TuNgay);
                reportCrytal.SetParameterValue("@DenNgay", _DenNgay);
                reportCrytal.SetParameterValue("@TieuDe", "");
                reportCrytal.SetParameterValue("@MaBoPhan", _MaBoPhan);
                reportCrytal.SetParameterValue("@TenBoPhan", "");
                #endregion//New
                #region Old
                //reportCrytal = new Report.ReportTongHop.BangCanDoiSoPhatSinh_CapBaAll();
                //command.CommandText = "spd_BangCanDoiSoPhatSinh_CapBaAll_Modify";
                //command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                //command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                //command.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                //command.Parameters.AddWithValue("@UserId", UserId);
                //adapter.SelectCommand = command;
                //adapter.Fill(table);
                //table.TableName = "spd_BangCanDoiSoPhatSinh_CapBaAll;1";

                //command1.CommandText = "spd_REPORT_ReportHeader_Modify";
                //command1.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
                //command1.Parameters.AddWithValue("@UserId", UserId);
                //adapter.SelectCommand = command1;
                //adapter.Fill(table1);
                //table1.TableName = "spd_REPORT_ReportHeader;1";

                //dataSet.Tables.Add(table);
                //dataSet.Tables.Add(table1);

                //reportCrytal.SetDataSource(dataSet);
                //reportCrytal.SetParameterValue("@TieuDe", "");
                //reportCrytal.SetParameterValue("@TuNgay", _TuNgay);
                //reportCrytal.SetParameterValue("@DenNgay", _DenNgay); 
                #endregion//Old
            }
            #endregion BangCanDoiSoPhatSinh

            #region ChungTuGhiSo
            if (_keyReport == "IDReport_ChungTuGhiSo")
            {
                CheckInputTuNgay();
                CheckInputDenNgay();
                string tieudeCTGS = string.Empty;
                reportCrytal = new Report.ReportTongHop.Report_ChungTuGhiSo();
                command.CommandText = "spd_ChungTuGhiSo_Modify";
                command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command.Parameters.AddWithValue("@UserId", UserId);
                if (_TuNgay.Date == _DenNgay.Date)
                {
                    tieudeCTGS = "Ngày " + _TuNgay.Day.ToString() + " tháng " + _TuNgay.Month.ToString() + " năm " + _TuNgay.Year.ToString();
                }
                else
                {
                    tieudeCTGS = "Từ ngày " + _TuNgay.ToShortDateString() + " đến ngày " + _DenNgay.ToShortDateString();
                }
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_ChungTuGhiSo;1";
                command1.CommandText = "spd_REPORT_ReportHeader_Modify";
                command1.Parameters.AddWithValue("@MaCongTy", _MaCongTy);
                command1.Parameters.AddWithValue("@UserId", UserId);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                reportCrytal.SetDataSource(dataSet);
                reportCrytal.SetParameterValue("@TieuDe", tieudeCTGS);
            }
            #endregion//ChungTuGhiSo

            #region SoChiTiet_NganHang
            if (_keyReport == "IDReport_SoChiTiet_NganHang" || _keyReport == "IDReport_SoChiTiet_NganHang_NgayLap")
            {
                CheckInputTuNgay();
                CheckInputDenNgay();
                CheckInputTaiKhoanNganHang();
                //===================
                CongTy_NganHang ct = CongTy_NganHang.GetCongTy_NganHang(_MaChiTietNganHang);
                HeThongTaiKhoan1 ht = HeThongTaiKhoan1.GetHeThongTaiKhoan1(ct.MaTKKeToan);
                LoaiTien lt = LoaiTien.GetLoaiTien(ct.LoaiTien);
                NganHang nh = NganHang.GetNganHang(ct.MaNganHang);

                if (lt.MaLoaiTien == 1 || lt.MaLoaiTien == 0)
                {
                    reportCrytal = new Report.NganHang.rpt_SoChiTietTaiKhoan_NganHang();
                }
                else
                {
                    reportCrytal = new Report.NganHang.rpt_SoChiTietTaiKhoan_NganHang_NT();
                }

                if (_keyReport == "IDReport_SoChiTiet_NganHang")
                {
                    command.CommandText = "spd_Report_SoDuDauKy_NganHang";
                }
                else
                {
                    command.CommandText = "spd_Report_SoDuDauKy_NganHang_TheoNgayLap";
                }
                command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command.Parameters.AddWithValue("@MaNganHang", _MaChiTietNganHang);
                command.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_Report_SoDuDauKy_NganHang;1";

                command1.CommandText = "spd_report_ReportHeader";
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";
                command1.CommandTimeout = 0;
                command2.CommandText = "spd_LayNguoiKyTenCongNo";
                command2.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                command2.CommandTimeout = 0;
                adapter.SelectCommand = command2;
                adapter.Fill(table2);
                table2.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);

                reportCrytal.SetDataSource(dataSet);

                reportCrytal.SetParameterValue("@NgayBatDau", _TuNgay);
                reportCrytal.SetParameterValue("@NgayKetThuc", _DenNgay);
                reportCrytal.SetParameterValue("@TieuDe", "TK " + ht.SoHieuTK + ": " + ht.TenTaiKhoan + " (" + ct.SoTaiKhoan + ") " + ct.TenNganHang);
                reportCrytal.SetParameterValue("@LoaiTien", lt.MaLoaiQuanLy);

            }
            #endregion//SoChiTiet_NganHang

            #region IDReport_SoChiTietTaiKhoan_TheoHopDong
            if (_keyReport == "IDReport_SoChiTietTaiKhoan_TheoHopDong")
            {
                CheckInputTuNgay();
                CheckInputDenNgay();
                CheckInputTaiKhoan();
                GetInputDoiTuong();
                GetInputBoPhan();
                GetInputHopDong();
                reportCrytal = new Report.ReportTongHop.Report_SoChiTietTaiKhoan_TheoHopDong();
                command.CommandText = "report_SoChiTietTaiKhoan_SoDuDau_Modify";
                command.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                command.Parameters.AddWithValue("@UserID", UserId);
                command.CommandTimeout = 0;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                command1.CommandText = "spd_Report_SoChiTietTaiKhoanTheoHopdong_Modify";
                command1.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command1.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command1.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                //command1.Parameters.AddWithValue("@MaKy", maKy);
                command1.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                command1.Parameters.AddWithValue("@MaHopDong", _maHopDong);
                command1.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                command1.Parameters.AddWithValue("@UserId", ERP_Library.Security.CurrentUser.Info.UserID);
                adapter.SelectCommand = command1;
                adapter.Fill(table1);
                table1.TableName = "spd_Report_SoChiTietTaiKhoanTheoHopdong;1";

                command2.CommandText = "spd_report_ReportHeader";
                command2.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                adapter.SelectCommand = command2;
                adapter.Fill(table2);
                table2.TableName = "spd_REPORT_ReportHeader;1";
                command2.CommandTimeout = 0;
                command3.CommandText = "spd_LayNguoiKyTenCongNo";
                command3.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                command2.CommandTimeout = 0;
                adapter.SelectCommand = command3;
                adapter.Fill(table3);
                table3.TableName = "spd_LayNguoiKyTenCongNo;1";

                command4.CommandText = "aspd_LuyKe_HopDong";
                command4.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command4.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command4.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                command4.Parameters.AddWithValue("@MaHopDong", _maHopDong);
                command4.Parameters.AddWithValue("@MaDoiTuong", _MaDoiTuong);
                //command4.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                adapter.SelectCommand = command4;
                adapter.Fill(table4);
                table4.TableName = "aspd_LuyKe_HopDong;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table3);
                dataSet.Tables.Add(table4);

                reportCrytal.SetDataSource(dataSet);

                reportCrytal.SetParameterValue("@MaTaiKhoan", _MaTaiKhoan);
                reportCrytal.SetParameterValue("@NgayBatDau", _TuNgay);
                reportCrytal.SetParameterValue("@NgayKetThuc", _DenNgay);
            }
            #endregion//IDReport_SoChiTietTaiKhoan_TheoHopDong

            #region BangTongHopTheoHopDong
            if (_keyReport == "IDReport_BangTongHopTheoHopDong")
            {
                CheckInputTuNgay();
                CheckInputDenNgay();
                CheckInputTaiKhoan();
                GetInputBoPhan();
                reportCrytal = new Report.ReportTongHop.Report_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong();
                command.CommandText = "spd_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong_Modify";
                command.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command.Parameters.AddWithValue("@DenNgay", _DenNgay);
                //command.Parameters.AddWithValue("@MaKy", maKy);
                //command.Parameters.AddWithValue("@Quy", Quy);
                //command.Parameters.AddWithValue("@Nam", Nam);
                //command.Parameters.AddWithValue("@Loai", Loai);
                command.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                command.Parameters.AddWithValue("@MaNguoiLap", UserId);
                command.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                table.TableName = "spd_BangCanDoiSoPhatSinh_DoiTuong_TheoHopDong;1";

                command1.CommandText = "spd_report_ReportHeader";
                adapter.SelectCommand = command1;
                command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                adapter.Fill(table1);
                table1.TableName = "spd_REPORT_ReportHeader;1";

                command2.CommandText = "report_SoChiTietTaiKhoan_SoDuDau_Modify";
                command2.Parameters.AddWithValue("@MaTaiKhoan", _MaTaiKhoan);
                command2.Parameters.AddWithValue("@TuNgay", _TuNgay);
                command2.Parameters.AddWithValue("@DenNgay", _DenNgay);
                command2.Parameters.AddWithValue("@MaBoPhan", _MaBoPhan);
                command2.Parameters.AddWithValue("@UserID", UserId);
                adapter.SelectCommand = command2;
                adapter.Fill(table2);
                table2.TableName = "report_SoChiTietTaiKhoan_SoHieu;1";

                command4.CommandType = CommandType.StoredProcedure;
                command4.CommandText = "spd_LayNguoiKyTenCongNo";
                command4.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                SqlDataAdapter adapter4 = new SqlDataAdapter(command4);
                adapter4.Fill(table4);
                table4.TableName = "spd_LayNguoiKyTenCongNo;1";

                dataSet.Tables.Add(table);
                dataSet.Tables.Add(table1);
                dataSet.Tables.Add(table2);
                dataSet.Tables.Add(table4);

                reportCrytal.SetDataSource(dataSet);
                reportCrytal.SetParameterValue("@TieuDe", _TieuDe);
                reportCrytal.SetParameterValue("@TuNgay", _TuNgay);
                reportCrytal.SetParameterValue("@DenNgay", _DenNgay);
                //reportCrytal.SetParameterValue("@MaKy", maKy);
                //reportCrytal.SetParameterValue("@Quy", Quy);
                //reportCrytal.SetParameterValue("@Nam", Nam);
                //reportCrytal.SetParameterValue("@Loai", Loai);
                reportCrytal.SetParameterValue("@MaTaiKhoan", _MaTaiKhoan);
                reportCrytal.SetParameterValue("@MaNguoiLap", UserId);
                reportCrytal.SetParameterValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
                reportCrytal.SetParameterValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

            }
            #endregion//BangTongHopTheoHopDong

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = reportCrytal;
            dlg.Show();
        }
        #endregion//Functions

        #region Initialize
        public FrmKeToanTongHopReports()
        {
            InitializeComponent();
            KhoiTao();
        }
        #endregion//Initialize

        #region Events
        private bool btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            return true;

        }//END InBaoCaoTinhHinhSuDungXangDauTheoThang


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void treeList_baoCao_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            this.AnTatCaControlItem();
            ReportTemplate rpt = reportTemplateListBindingSource.Current as ReportTemplate;
            _keyReport = rpt.Id;
            switch (rpt.Id)
            {
                case "IDReport_SoChiTietTaiKhoan"://01
                case "IDReport_SoChiTietTaiKhoan_New":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemTaiKhoan);
                        //ShowControlItem(ItemDoiTuong);
                        TaiKhoanGridLookUpEdit.Properties.Buttons[1].Visible = true;
                        //DoiTuonggridLookUpEdit.Properties.Buttons[1].Visible = true;
                    }
                    break;
                case "IDReport_SoChiTietTaiKhoanTheoDoiTuong"://01.1
                case "IDReport_SoChiTietTaiKhoanTheoDoiTuong_New"://15.03.18
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemDoiTuong);
                        //TaiKhoanGridLookUpEdit.Properties.Buttons[1].Visible = true;
                    }
                    break;
                case "IDReport_SoNhatKyChung"://02
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                    }
                    break;
                case "IDReport_SoQuyTienMat"://03
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemTaiKhoan);
                        //ShowControlItem(ItemDoiTuong);
                        ShowControlItem(itemTheoChiTiet);
                        ShowControlItem(itemTheoChungTu);                        
                    }
                    break;
                case "IDReport_SoQuyTienGui"://04
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemDoiTuong);
                    }
                    break;
                case "IDReport_SoCai"://05
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemBoPhan);
                    }
                    break;
                case "IDReport_ChungTuGhiSo"://06
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                    }
                    break;
                case "IDReport_BangTongHopCongNoDoiDoiTuong"://06
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemDoiTuong);
                        ShowControlItem(ItemXemDangLuoi);
                    }
                    break;
                case "IDReport_BangCanDoiPhatSinh"://07
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(itemSoDuHaiBen);
                        ShowControlItem(ItemXemDangLuoi);
                    }
                    break;
                case "IDReport_BangCanDoiKeToan"://08
                case "IDReport_BangCanDoiKeToan_zTemp":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                    }
                    break;
                case "IDReport_BaoCaoKetQuaHoatDongKinhDoanh"://09
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                    }
                    break;
                case "IDReport_BangKetQuaHoatDongKinhDoanh_zTemp"://09
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                    }
                    break;
                case "IDReport_BaoCaoChiTietKetQuaHoatDongKinhDoanh"://10
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                    }
                    break;
                case "IDReport_BaoCaoLuuChuyenTienTe"://11
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                    }
                    break;
                case "IDReport_ThuyetMinhBaoCaoTaiChinh"://12
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                    }
                    break;
                case "IDReport_SoChiTiet_NganHang":
                case "IDReport_SoChiTiet_NganHang_NgayLap":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoanNganHang);
                        ShowControlItem(itemTheoChiTiet);
                        ShowControlItem(itemTheoChungTu);
                    }
                    break;
                case "IDReport_SoChiTietTaiKhoan_TheoHopDong":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemDoiTuong);
                        ShowControlItem(ItemHopDong);
                    }
                    break;
                case "IDReport_BangTongHopTheoHopDong":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemBoPhan);
                    }
                    break;
                //thêm báo cáo 08/12/2017
                case "IDReport_ChiTietCongNoPhaiTra":                
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemDoiTuong);
                        ShowControlItem(ItemLoaiTien);
                        _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("331");
                        TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                    }
                    break;
                case "IDReport_ChiTietCongNoPhaiTra_RutGon":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemDoiTuong);
                        ShowControlItem(ItemLoaiTien);
                        if (TaiKhoanGridLookUpEdit.Text.Contains("331") == false)
                        {
                            _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("331");
                            TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                        }
                    }
                    break;
                case "IDReport_ChiTietCongNoTamUng_RutGon":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemDoiTuong);
                        ShowControlItem(ItemLoaiTien);
                        if (TaiKhoanGridLookUpEdit.Text.Contains("141") == false)
                        {
                            _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("141");
                            TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                        }
                    }
                    break;
                case "IDReport_ChiTietCongNoPhaiThu":
                     {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemDoiTuong);
                        ShowControlItem(ItemLoaiTien);
                        if (TaiKhoanGridLookUpEdit.Text.Contains("131") == false)
                        {
                            _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("131");
                            TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                        }
                    }
                    break;
                case "IDReport_ChiTietCongNoPhaiTraTheoHoaDon":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemDoiTuong);
                        ShowControlItem(ItemLoaiTien);
                    }
                    break;
                case "IDReport_SoChiTietTaiKhoanTheoDoiTuongNew":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemDoiTuong);
                        TaiKhoanGridLookUpEdit.Properties.Buttons[1].Visible = true;
                        DoiTuonggridLookUpEdit.Properties.Buttons[1].Visible = true;
                    }
                    break;

                case "IDReport_SoKeToanChiTietQuyTienMat":
                case "IDReport_SoKeToanChiTietQuyTienMat_SoBienLai":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("1111");
                        TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                        ShowControlItem(itemTheoChiTiet);
                        ShowControlItem(itemTheoChungTu);
                    }
                    break;
                case "IDReport_SoTienGuiNganHangChiTiet":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemLoaiTien);
                        ShowControlItem(ItemTaiKhoanNganHang);
                        if (TaiKhoanGridLookUpEdit.Text.Contains("112") == false && TaiKhoanGridLookUpEdit.Text.Contains("128") == false)
                        {
                            _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("1121");
                            TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                        }
                        
                    }
                    break;
                case "IDReport_SoTienGuiNganHangChiTiet_NgoaiTe":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemLoaiTien);
                        ShowControlItem(ItemTaiKhoanNganHang);
                        if (TaiKhoanGridLookUpEdit.Text.Contains("1122") == false)
                        {
                            _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("1122");
                            TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                        }

                    }
                    break;
                case "IDReport_SoTienGuiNganHang":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemLoaiTien);
                        if (TaiKhoanGridLookUpEdit.Text.Contains("112") == false && TaiKhoanGridLookUpEdit.Text.Contains("128") == false)
                        {
                            _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("1121");
                            TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                        }
                    }
                    break;
                case "IDReport_BangKeSoDuNganHang":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        //ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemLoaiTien);
                        //if (TaiKhoanGridLookUpEdit.Text.Contains("112") == false && TaiKhoanGridLookUpEdit.Text.Contains("128") == false)
                        //{
                        //    _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("1121");
                        //    TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                        //}
                    }
                    break;
                case "IDReport_TongHopCongNoNhanVien":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemNhanVien);
                        if (TaiKhoanGridLookUpEdit.Text.Contains("141") == false)
                        {
                            _MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("141");
                            TaiKhoanGridLookUpEdit.EditValue = _MaTaiKhoan;
                        }
                    }
                    break;
                case "IDReport_SoChiTietTheoKhoanMuc":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemKhoanMuc);
                        TaiKhoanGridLookUpEdit.Properties.Buttons[1].Visible = true;
                    }
                    break;
                case "IDReport_SoChiTietTheoDonVi":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemBoPhan);
                    }
                    break;
                case "IDReport_SoTongHopTheoDonVi":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemBoPhan);
                    }
                    break;
                case "IDReport_SoTongHopTheoKhoanMuc":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemKhoanMuc);
                        TaiKhoanGridLookUpEdit.Properties.Buttons[1].Visible = true;
                    }
                    break;
                case "IDReport_TongHopCayChiPhi":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemTaiKhoan);
                        //ShowControlItem(ItemKhoanMuc);
                        TaiKhoanGridLookUpEdit.Properties.Buttons[1].Visible = true;
                    }
                    break;
                case "IDReport_BangKeThuPhiHocSinh":               
                case "IDReport_HocSinhDaXuatHoaDon_or_DaThuTien":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemXemDangLuoi);
                    }
                    break;
                case "IDReport_BangKeDoanhThuChuaThucHien":               
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemTaiKhoan);
                        TaiKhoanGridLookUpEdit.Properties.Buttons[1].Visible = true;
                        ShowControlItem(ItemXemDangLuoi);
                    }
                    break;
                case "IDReport_SoTongHopBanHang":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        //ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemDoiTuong);
                        ShowControlItem(ItemKhoanMuc);
                        ShowControlItem(ItemTheoDoiTuong);
                        ShowControlItem(ItemTheoKhoanMuc);
                        ShowControlItem(ItemXemDangLuoi);
                    }
                    break;
                case "IDReport_BangKeGiayNhanNo":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                    }
                    break;
                case "IDReport_BangTongHopPhatSinhTaiKhoan":
                    {
                        ShowControlItem(ItemKyBaoCao);
                        ShowControlItem(Item_TuNgay);
                        ShowControlItem(Item_DenNgay);
                        ShowControlItem(ItemBoPhan);
                        ShowControlItem(ItemTaiKhoan);
                        ShowControlItem(ItemXemDangLuoi);
                    }
                    break;
                //
                default:
                    this.AnTatCaControlItem();
                    break;
            }
        }//END InDSRePort

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

        private void FrmKeToanTongHopReports_Load(object sender, EventArgs e)
        {
            KiemTra();
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
            PrintReport();
        }

        private void grdLU_LoaiTien_EditValueChanged(object sender, EventArgs e)
        {
            _MaLoaiTien = (Int32)grdLU_LoaiTien.EditValue;
        }

        #endregion //Events

        #region eventHandles
        //KyBaoCaogridLookUpEdit_EditValueChanged
        private void KyBaoCaogridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (KyBaoCaogridLookUpEdit.EditValue != null)
            {
                KyBaoCaoKeToan kyBaoCao = KyBaoCaoKeToan.GetKyBaoCaoKeToanByMa(KyBaoCaogridLookUpEdit.EditValue.ToString());
                dateEdit_TuNgay.EditValue = kyBaoCao.TuNgay;
                dateEdit_DenNgay.EditValue = kyBaoCao.DenNgay;
            }
        }
        //BoPhanGridlookUpEdit_EditValueChanged
        private void BoPhanGridlookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (BoPhanGridlookUpEdit.EditValue != null)
            {
            }
        }
        //TaiKhoanGridLookUpEdit_EditValueChanged
        private void TaiKhoanGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            strMaTaiKhoan = "";
            //strMaTaiKhoan = TaiKhoanGridLookUpEdit.EditValue + "";
            //if (strMaTaiKhoan == "0")
            //    strMaTaiKhoan = "";
            //if (TaiKhoanGridLookUpEdit.EditValue != null)
            //{

            //}
        }
        //DoiTuonggridLookUpEdit_EditValueChanged
        private void DoiTuonggridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {   
            long doituongOut = 0;
            if (DoiTuonggridLookUpEdit.EditValue != null)
            {               
                if (DoiTuonggridLookUpEdit.EditValue != null && long.TryParse(DoiTuonggridLookUpEdit.EditValue.ToString(), out doituongOut))
                {
                    LoadHopDongListByDoiTuong(doituongOut);
                }
                this.strMaDoiTuong = doituongOut + "";
            }
        }
        #endregion eventHandles

        #region Cac phuong thuc viet de copy vao script report, lien ket bao cao tong hop - chi tiet
        private void ShowReport_SoChiTietTaiKhoanTheoDoiTuong(DateTime tuNgay, DateTime denNgay, int maBoPhan, int maTaiKhoan, long maDoiTuong, int userID, string soHieuTK, string tenTaiKhoan, string tenDoiTuong)
        {
            DataSet dsMain = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spdReport_ChiTietTaiKhoanTheoDoiTuongNew";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dsMain.Tables.Add(dt);
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
                    dsMain.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
                dr["SoHieuTK"] = soHieuTK;
                dr["TenTaiKhoan"] = tenTaiKhoan;
                dr["TenDoiTuong"] = tenDoiTuong;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dsMain.Tables.Add(dtngay);

                ERP_Library.ReportTemplate reportTemplate;
                reportTemplate = ReportTemplate.GetReportTemplate("IDReport_SoChiTietTaiKhoanTheoDoiTuongNew", userID, DateTime.Today.Date);

                PSC_ERP.frmReport frm = new PSC_ERP.frmReport();
                frm.HienThiReport(reportTemplate, dsMain);
                frm.Show();
            }//us
        }

        private void ShowReport_SoChiTietTaiKhoan(DateTime tuNgay, DateTime denNgay, int maBoPhan, int maTaiKhoan, long maDoiTuong, int userID, string soHieuTK, string tenTaiKhoan, string tenDoiTuong)
        {
            DataSet dsMain = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao MainData
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spRpt_SoChiTietTaiKhoan";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    cm.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    cm.Parameters.AddWithValue("@MaDoiTuong", maDoiTuong);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@UserID", userID);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "MainData";
                    dsMain.Tables.Add(dt);
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
                    dsMain.Tables.Add(dt);
                }

                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("SoHieuTK", typeof(string));
                dtngay.Columns.Add("TenTaiKhoan", typeof(string));
                dtngay.Columns.Add("TenDoiTuong", typeof(string));

                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
                dr["SoHieuTK"] = soHieuTK;
                dr["TenTaiKhoan"] = tenTaiKhoan;
                dr["TenDoiTuong"] = tenDoiTuong;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "TblTuNgay_DenNgay";
                dsMain.Tables.Add(dtngay);

                ERP_Library.ReportTemplate reportTemplate;
                reportTemplate = ReportTemplate.GetReportTemplate("IDReport_SoChiTietTaiKhoan_New", userID, DateTime.Today.Date);

                PSC_ERP.frmReport frm = new PSC_ERP.frmReport();
                frm.HienThiReport(reportTemplate, dsMain);
                frm.Show();
            }//us
        }
        #endregion

        private void TaiKhoanGridLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmChonTaiKhoan frm = new frmChonTaiKhoan();
                frm.ShowDialog();
                strMaTaiKhoan = frm.strMaTaiKhoan;
            }
        }

        private void DoiTuonggridLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                frmChonDoiTuong frm = new frmChonDoiTuong();
                frm.ShowDialog();
                strMaDoiTuong = frm.strMaDoiTuong;
            }
        }

    }
}
