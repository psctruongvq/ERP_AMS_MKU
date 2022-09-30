using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Data.SqlClient;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using System.Linq;
using System.Collections.Generic;

namespace PSC_ERP.Main
{
    public partial class frmChungTuBaoHiemTaiSan : XtraForm
    {
        ChungTuBaoHiemTaiSan _chungTuBaoHiemTaiSan = ChungTuBaoHiemTaiSan.NewChungTuBaoHiemTaiSan();
        ChungTuBaoHiemTaiSanList _chungTuBaoHiemTaiSanXuatList;
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();      
        DoiTacList _DoiTacList;
        List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList = null;
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        DateTime _ngayLapCu;
        DataSet dataSet;
        public frmChungTuBaoHiemTaiSan()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
        }
      
        public frmChungTuBaoHiemTaiSan(ChungTuBaoHiemTaiSan phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }

        public frmChungTuBaoHiemTaiSan(long maPhieuNhap)
        {
            InitializeComponent();
            KhoiTao();
            ChungTuBaoHiemTaiSan phieunhapccdc = ChungTuBaoHiemTaiSan.GetChungTuBaoHiemTaiSan(maPhieuNhap);
            KhoiTaoPhieu(phieunhapccdc);
        } 
       
        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _chungTuBaoHiemTaiSan = ChungTuBaoHiemTaiSan.NewChungTuBaoHiemTaiSan();        
            chiTietChungTuBaoHiemListBindingSource.DataSource = _chungTuBaoHiemTaiSan.CT_ChungTuBaoHiemTaiSanList;         
            chungTuBaoHiemTaiSanBindingSource.DataSource = _chungTuBaoHiemTaiSan;        
            //tao so chung tu
            TaoSoPhieu();                    
        }

        private void TaoSoPhieu()
        {           
            _chungTuBaoHiemTaiSan.SoChungTu = ChungTuBaoHiemTaiSan.Get_NextSoChungTuBaoHiemTaiSan(_chungTuBaoHiemTaiSan.NgayLap.Year, _chungTuBaoHiemTaiSan.NgayLap.Month,UserId,4);
        }
        #endregion

        #region KhoiTaoPhieu(ChungTuBaoHiemTaiSan phieuNhapXuat)
        private void KhoiTaoPhieu(ChungTuBaoHiemTaiSan chungTuBaoHiemTaiSan)
        {
            _chungTuBaoHiemTaiSan = chungTuBaoHiemTaiSan;
            chungTuBaoHiemTaiSanBindingSource.DataSource = _chungTuBaoHiemTaiSan;
            chiTietChungTuBaoHiemListBindingSource.DataSource = _chungTuBaoHiemTaiSan.CT_ChungTuBaoHiemTaiSanList;                      
        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            _taiSanCoDinhCaBietList = TaiSanCoDinhCaBiet_Factory.New().Context.spd_TSCD_LayDanhSachTaiSanCoDinhorCCDC(0, _maCongTy).ToList();
            // Đưa dữ liệu vào bindingsource
            tblTaiSanCoDinhCaBietBindingSource.DataSource = _taiSanCoDinhCaBietList;

            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            doiTacList_ForGirdBindingSource.DataSource = _DoiTacList;
        }
        #endregion
      
        private void KhoiTaoThongTinTimKiem()
        {                         
            chungTuBaoHiemTaiSanListBindingSource.DataSource = _chungTuBaoHiemTaiSanXuatList;          
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListByTen(0);         
        }    

        private bool KiemTraHopLe()
        {                  
            if (String.IsNullOrEmpty(txtSoPhieu.Text))
            {
                txtSoPhieu.Focus();
                DialogUtil.ShowWarning("Số phiếu không thể rỗng!");
                return false;
            }            
            else if (_chungTuBaoHiemTaiSan.MaDoiTac == 0)
            {
                lookUpEdit_DoiTac.Focus();
                DialogUtil.ShowWarning("Vui lòng chọn Nhà cung cấp!");
                return false;
            }           
            else if (_chungTuBaoHiemTaiSan.CT_ChungTuBaoHiemTaiSanList.Count == 0)
            {
                DialogUtil.ShowWarning("Vui lòng nhập chi tiết phiếu nhập!");
                return false;
            }                   
            return true;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {           
            Save();
        }

        private bool Save()
        {
            bool result = true;//mac dinh la true
            this.txtBlackHole.Focus();
            chungTuBaoHiemTaiSanBindingSource.EndEdit();
            try
            {
                if (KiemTraHopLe() == true)
                {                  
                    if (result == true)//
                    {
                        _chungTuBaoHiemTaiSan.ApplyEdit();
                        _chungTuBaoHiemTaiSan.Save();
                        DialogUtil.ShowInfo("Cập Nhật Thành Công!");
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                result = false;
                DialogUtil.ShowError("Cập Nhật Thất Bại!\n" + ex.Message);
            }
            //
            return result;
        }

        private void LoadInfoByMaChungTuBaoHiemTaiSan(long maChungTu)
        {
            ChungTuBaoHiemTaiSan chungTuBaoHiemTaiSan = ChungTuBaoHiemTaiSan.GetChungTuBaoHiemTaiSan(maChungTu);
            KhoiTaoPhieu(chungTuBaoHiemTaiSan);
            xtraTabControl2.SelectedTabPageIndex = 0;             
        }     

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {    
            KhoiTaoPhieu();
        }     

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            ReportTemplate _report = ReportTemplate.GetReportTemplate("SpdBienBanNhapCongCuDungCu");//PhieuNhapVatTu//
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

        #region Cac Phuong Thuc Report
      
        public void Spd_PhieuNhapVatTu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuNhapVatTu";
                    cm.Parameters.AddWithValue("@MaPhieuNhap", _chungTuBaoHiemTaiSan.ID);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuNhapVatTu;1";
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
        }///End Spd_PhieuNhapVatTu 
        #endregion//Cac Phuong Thuc Report

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            grdViewChiTiet_NghiepVuBaoHiemTaiSan.DeleteSelectedRows();//Xoa nhieu dong
        }       
  
        private void frmPhieuNhapVatTuHangHoa_Load(object sender, EventArgs e)
        {              
            grdv_DanhSachChungTuBaoHiemTaiSan.OptionsBehavior.Editable = false;//M
            Utils.GridUtils.SetSTTForGridView(grdv_DanhSachChungTuBaoHiemTaiSan, 35);//M
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
            KhoiTaoThongTinTimKiem();
        }        

        private void frmPhieuNhapCongCuDungCu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_chungTuBaoHiemTaiSan != null && (_chungTuBaoHiemTaiSan.IsDirty || _chungTuBaoHiemTaiSan.IsNew))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu trước khi thoát?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {
                    if (this.Save() == false)
                        e.Cancel = true;
                }
                else if (DialogResult.No == result)
                {
                }
                else if (DialogResult.Cancel == result)
                {
                    e.Cancel = true;
                }
            }
        }
          
        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ChungTuBaoHiemTaiSan chungTuBaoHiemTaiSan = _chungTuBaoHiemTaiSan;
            if (chungTuBaoHiemTaiSan != null)
            {
                if (MessageBox.Show(this, "Bạn muốn xóa Phiếu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        ChungTuBaoHiemTaiSan.DeleteChungTuBaoHiemTaiSan(chungTuBaoHiemTaiSan);
                        DialogUtil.ShowInfo("Xóa Thành Công!");
                        btnThemMoi.PerformClick();
                    }
                    catch (Exception ex)
                    {
                        DialogUtil.ShowError("Cập Nhật Thất Bại!\n" + ex.Message);
                    }
                }//End De
            }
        }

        #region Methods   
        private bool KiemTraTrungMatHang()
        {
            CT_ChungTuBaoHiemTaiSan ct_chungTuBaoHiemTaiSan = (CT_ChungTuBaoHiemTaiSan)chiTietChungTuBaoHiemListBindingSource.Current;
            foreach (CT_ChungTuBaoHiemTaiSan ct in _chungTuBaoHiemTaiSan.CT_ChungTuBaoHiemTaiSanList)
            {
                if (ct != ct_chungTuBaoHiemTaiSan)
                {
                    if (ct.MaTSCDCB == ct_chungTuBaoHiemTaiSan.MaTSCDCB)
                        return true;
                }
            }
            return false;
        }
      
        private void CapNhatLaiTongGiaTriPhieu()
        {
            Decimal tongTien = 0;
            foreach (CT_ChungTuBaoHiemTaiSan chiTietChungTu in _chungTuBaoHiemTaiSan.CT_ChungTuBaoHiemTaiSanList)
            {
                tongTien += Math.Round(chiTietChungTu.GiaTriBaoHiem, 0, MidpointRounding.AwayFromZero);
            }
            _chungTuBaoHiemTaiSan.TongGiaTriBaoHiem = tongTien;
        }
        #endregion//Method

        #region EventHandles      
        private void grdViewChiTiet_NghiepVuBaoHiemTaiSan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {               
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các tài sản đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (int i in grdViewChiTiet_NghiepVuBaoHiemTaiSan.GetSelectedRows())
                    {
                        CT_ChungTuBaoHiemTaiSan chiTiet = _chungTuBaoHiemTaiSan.CT_ChungTuBaoHiemTaiSanList[i];                       
                        grdViewChiTiet_NghiepVuBaoHiemTaiSan.DeleteRow(i);
                    }
                   // CapNhatLaiTongGiaTriPhieu();
                }
            }
        }
        #endregion EventHandles

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            if (checkEdit_Ngay.Checked == true)
            {
                _chungTuBaoHiemTaiSanXuatList = ChungTuBaoHiemTaiSanList.GetChungTuBaoHiemTaiSanList_TimTheoLoaiVaNgay(1,(long)0, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date);
            }
            else
            {
                _chungTuBaoHiemTaiSanXuatList = ChungTuBaoHiemTaiSanList.GetChungTuBaoHiemTaiSanList_TimTheoLoaiVaNgay(0,(long)0, (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date);
            }
            chungTuBaoHiemTaiSanListBindingSource.DataSource = _chungTuBaoHiemTaiSanXuatList;
            if (_chungTuBaoHiemTaiSanXuatList.Count == 0)//M
                DialogUtil.ShowInfo("Danh Sách Phiếu rỗng!");
        }

        private void grdv_DanhSachChungTuBaoHiemTaiSan_DoubleClick(object sender, EventArgs e)
        {
            ChungTuBaoHiemTaiSan chungTuBaoHiemTaiSan = grdv_DanhSachChungTuBaoHiemTaiSan.GetFocusedRow() as ChungTuBaoHiemTaiSan;
            LoadInfoByMaChungTuBaoHiemTaiSan(chungTuBaoHiemTaiSan.ID);
        }

        private void btn_ExportExcelDS_Click(object sender, EventArgs e)
        {
            //GridUtil.ExportToExcel(gridView: this.grdv_DanhSachChungTuBaoHiemTaiSan, showOpenFilePrompt: true);
        }

        private void btn_ExportChiTietPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView: this.grdViewChiTiet_NghiepVuBaoHiemTaiSan, showOpenFilePrompt: true);
        }        
    }
}