using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Model;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using DevExpress.XtraEditors;

namespace PSC_ERPNew.Main
{
    public partial class frmInMaVachTSCDCaBiet : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmInMaVachTSCDCaBiet singleton_ = null;
        public static frmInMaVachTSCDCaBiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmInMaVachTSCDCaBiet();
                return singleton_;
            }
        }
        public static void ShowSingleton(object owner)
        {
            FormUtil.ShowForm_Helper(Singleton, owner);
        }
        #endregion

        //Private Member field
        #region Private Member field
        InMaVachTaiSanCoDinhCaBiet_Factory _inMaVachTaiSanCoDinhCaBiet_Factory = null;
        List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList = new List<tblTaiSanCoDinhCaBiet>();
        List<tblInMaVachTaiSanCoDinhCaBiet> _inMaVachTaiSanCoDinhCaBietList = new List<tblInMaVachTaiSanCoDinhCaBiet>();
        List<tblnsBoPhan> _boPhanList = new List<tblnsBoPhan>();
        List<tblDanhMucTSCD> _nhomTaiSanList = new List<tblDanhMucTSCD>();
        List<tblDanhMucTSCD> _taiSanCoDinhList = new List<tblDanhMucTSCD>();
        List<tblDanhMucTSCD> _loaiTaiSanList = new List<tblDanhMucTSCD>();
        Boolean _daLoadXong = false;
        Int32 _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmInMaVachTSCDCaBiet()
        {
            InitializeComponent();
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            if (grdViewInMaVachTaiSan.RowCount == 0)
            {
                // DialogUtil.ShowWarning("Chưa có dữ liệu");
                // duocPhepLuu = false;
            }
            return duocPhepLuu;
        }
        private bool Save()
        {
            txtBlackHole.Focus();
            //kiểm tra dữ liệu trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        //lưu kiểm kê tài sản
                        _inMaVachTaiSanCoDinhCaBiet_Factory.SaveChangesWithoutTrackingLog();
                        //_inMaVachTaiSanCoDinhCaBiet_Factory.SaveChanges(BusinessCodeEnum.TSCD_InMaVach.ToString());

                        DialogUtil.ShowSaveSuccessful();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful(ex.Message);
                   
                }
            }
            return false;
        }

        private void GanBindingSource()
        {
            tblBoPhanBindingSource.DataSource = _boPhanList;
            //
            tblNhomTSCDBindingSource.DataSource = _nhomTaiSanList;
            //
            tblLoaiTSCDBindingSource.DataSource = _loaiTaiSanList;
            //
            tblTaiSanCoDinhBindingSource.DataSource = _taiSanCoDinhList;
        }

        private void TimTaiSanCoDinhCaBiet()
        {
            using (DialogUtil.Wait(this))
            {
                int maNhomTaiSan = Convert.ToInt32(cbNhomTaiSan.EditValue);
                int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
                int maLoaiTaiSan = Convert.ToInt32(cbLoaiTaiSan.EditValue);
                int maTaiSanCoDinh = Convert.ToInt32(cbTaiSanCD.EditValue);
                DateTime tuNgay;
                if (chkChonTuNgay.Checked)
                    tuNgay = Convert.ToDateTime(dteTuNgay.EditValue);
                else
                    tuNgay = DateTime.MinValue;
                DateTime denNgay = Convert.ToDateTime(dteDenNgay.EditValue);
                //Khởi tạo lại factory
                _inMaVachTaiSanCoDinhCaBiet_Factory = InMaVachTaiSanCoDinhCaBiet_Factory.New();

                //Lấy tài sản cố định cá biệt
                _taiSanCoDinhCaBietList = TaiSanCoDinhCaBiet_Factory.New().Get_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaPhongBanAndMaNhomTSAndMaLoaiTSAndMaTSCD_PhucVuInMaVachTaiSan(maPhongBan, maNhomTaiSan, maLoaiTaiSan, maTaiSanCoDinh, tuNgay, denNgay, _maCongTy).ToList();
                // Lấy danh sách in mã vạch tài sản cố định cá biệt
                _inMaVachTaiSanCoDinhCaBietList = _inMaVachTaiSanCoDinhCaBiet_Factory.Get_DanhSachInMaVachTaiSanCoDinhCaBiet_ByMaPhongBanAndMaNhomTSAndMaLoaiTSAndMaTSCD(maPhongBan, maNhomTaiSan, maLoaiTaiSan, maTaiSanCoDinh, _maCongTy).ToList();
                //Remove tài sản cố định cá biệt khỏi danh sách tìm
                RemoveTaiSanCoDinhCaBietDaChonRaKhoiDanhSachTim();
                //Gán BindingSource
                tblTaiSanCoDinhCaBietBindingSource.DataSource = _taiSanCoDinhCaBietList;
                tblInMaVachTaiSanCoDinhCaBietBindingSource.DataSource = _inMaVachTaiSanCoDinhCaBietList;
            }
        }

        private void RemoveTaiSanCoDinhCaBietDaChonRaKhoiDanhSachTim()
        {
            foreach (tblInMaVachTaiSanCoDinhCaBiet inMaVachTaiSanCDCaBiet in _inMaVachTaiSanCoDinhCaBietList)
            {
                tblTaiSanCoDinhCaBiet taiSanCDCaBietRemoveRaKhoiDanhSachTim = null;
                foreach (tblTaiSanCoDinhCaBiet taiSanCDCaBiet in _taiSanCoDinhCaBietList)
                {
                    if (taiSanCDCaBiet.MaTSCDCaBiet == inMaVachTaiSanCDCaBiet.MaTSCDCaBiet)
                    {
                        taiSanCDCaBietRemoveRaKhoiDanhSachTim = taiSanCDCaBiet;
                        break;
                    }
                }
                if (taiSanCDCaBietRemoveRaKhoiDanhSachTim != null)
                {
                    tblTaiSanCoDinhCaBietBindingSource.Remove(taiSanCDCaBietRemoveRaKhoiDanhSachTim);
                }
            }
        }

        #endregion

        //Event Method
        #region Event Method

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save();
        }

        private void frmKiemKeTaiSan_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
            {
                //khởi tạo dữ liệu 
                _inMaVachTaiSanCoDinhCaBiet_Factory = InMaVachTaiSanCoDinhCaBiet_Factory.New();

                //Lấy dữ liệu
                {
                    _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_maCongTy).ToList();
                    tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
                    _boPhanList.Insert(0, boPhan_chonTatCa);
                    //
                    this.cbPhongBan.EditValue = -1;
                    this.cbPhongBan.EditValue = 0;
                }

                // Set số thứ tự cho lưới
                GridUtil.SetSTTForGridView(grdViewTSCDCaBiet);
                GridUtil.SetSTTForGridView(grdViewInMaVachTaiSan);
                // Set mặc định ngày kiểm kê
                dteTuNgay.EditValue = app_users_Factory.New().SystemDate;
                dteDenNgay.EditValue = app_users_Factory.New().SystemDate;

                //Đưa checkbox lên lưới
                GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewTSCDCaBiet, colChon);
                GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewInMaVachTaiSan, col_Chon);

                //Gán BindingSource
                this.GanBindingSource();
                //Ghi nhận đã load xong form
                _daLoadXong = true;
            };
        }

        private void cbPhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);

                //gan nhom thanh 0
                cbNhomTaiSan.EditValue = -1;
                cbNhomTaiSan.EditValue = 0;
                if (maPhongBan >= 0)
                {
                    //lay nhom theo phong ban
                    _nhomTaiSanList = DanhMucTSCD_Factory.New().Get_DanhSachNhomTaiSan_CuaTaiSanChuaThanhLy_ByMaPhongBan(maPhongBan).ToList();
                    tblDanhMucTSCD nts_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                    _nhomTaiSanList.Insert(0, nts_chonTatCa);

                    this.GanBindingSource();
                }
            }
        }
        private void cbNhomTaiSan_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                int maNhomTaiSan = Convert.ToInt32(cbNhomTaiSan.EditValue);
                int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);

                //gan loai thanh 0
                cbLoaiTaiSan.EditValue = -1;
                cbLoaiTaiSan.EditValue = 0;
                if (maNhomTaiSan >= 0)
                {
                    //lay loai
                    _loaiTaiSanList = DanhMucTSCD_Factory.New().Get_DanhSachLoaiTaiSan_CuaTaiSanChuaThanhLy_ByMaPhongBanAndMaNhomTS(maPhongBan, maNhomTaiSan).ToList();
                    tblDanhMucTSCD lts_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                    _loaiTaiSanList.Insert(0, lts_chonTatCa);

                    this.GanBindingSource();
                }
            }
        }
        private void cbLoaiTaiSan_EditValueChanged(object sender, EventArgs e)
        {
            if (_daLoadXong)
            {
                int maNhomTaiSan = Convert.ToInt32(cbNhomTaiSan.EditValue);
                int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
                int maLoaiTaiSan = Convert.ToInt32(cbLoaiTaiSan.EditValue);
                //gan tscd thanh 0;
                cbTaiSanCD.EditValue = -1;
                cbTaiSanCD.EditValue = 0;

                if (maLoaiTaiSan >= 0)
                {
                    //lay tai san
                    _taiSanCoDinhList = DanhMucTSCD_Factory.New().Get_DanhSachTaiSanCoDinh_CuaTaiSanChuaThanhLy_ByMaPhongBanAndMaNhomTSAndMaLoaiTS(maPhongBan, maNhomTaiSan, maLoaiTaiSan).ToList();
                    tblDanhMucTSCD tscd_chonTatCa = new tblDanhMucTSCD() { ID = 0, MaQuanLy = "<<Tất cả>>", Ten = "<<Tất cả>>" };
                    _taiSanCoDinhList.Insert(0, tscd_chonTatCa);

                    this.GanBindingSource();
                }
            }
        }
        private void chkChonTuNgay_CheckedChanged(object sender, EventArgs e)
        {
            dteTuNgay.Enabled = chkChonTuNgay.Checked;
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            this.TimTaiSanCoDinhCaBiet();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            foreach (tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet in _taiSanCoDinhCaBietList)
            {
                if (taiSanCoDinhCaBiet.Chon == true)
                {
                    tblInMaVachTaiSanCoDinhCaBiet inMaVachTSCDCaBiet = _inMaVachTaiSanCoDinhCaBiet_Factory.CreateManagedObject();
                    inMaVachTSCDCaBiet.MaTSCDCaBiet = taiSanCoDinhCaBiet.MaTSCDCaBiet;
                    _inMaVachTaiSanCoDinhCaBietList.Add(inMaVachTSCDCaBiet);
                }
            }

            //Gán BindingSource
            tblInMaVachTaiSanCoDinhCaBietBindingSource.DataSource = _inMaVachTaiSanCoDinhCaBietList;
            grdViewInMaVachTaiSan.RefreshData();

            // Remove tài sản cố định cá biệt ra khỏi danh sách tìm
            RemoveTaiSanCoDinhCaBietDaChonRaKhoiDanhSachTim();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Tạo một danh sách mới
            List<tblInMaVachTaiSanCoDinhCaBiet> inMaVachTaiSanCoDinhCaBietList_New = new List<tblInMaVachTaiSanCoDinhCaBiet>();

            foreach (tblInMaVachTaiSanCoDinhCaBiet inMaVachTaiSanCoDinhCaBiet in _inMaVachTaiSanCoDinhCaBietList)
            {
                if (inMaVachTaiSanCoDinhCaBiet.Chon == true)
                {
                    // Thêm vao danh sách tạm 
                    inMaVachTaiSanCoDinhCaBietList_New.Add(inMaVachTaiSanCoDinhCaBiet);
                }
            }

            // Remove danh sách in mã vạch tài sản cố định cá biệt
            foreach (tblInMaVachTaiSanCoDinhCaBiet item in inMaVachTaiSanCoDinhCaBietList_New)
            {
                tblInMaVachTaiSanCoDinhCaBiet inMaVachTSCDCaBietRemoveKhoiDanhSach = null;
                foreach (tblInMaVachTaiSanCoDinhCaBiet inMaVachTSCDCaBiet in _inMaVachTaiSanCoDinhCaBietList)
                {
                    if (item.MaTSCDCaBiet == inMaVachTSCDCaBiet.MaTSCDCaBiet)
                    {
                        inMaVachTSCDCaBietRemoveKhoiDanhSach = inMaVachTSCDCaBiet;
                    }
                }

                if (inMaVachTSCDCaBietRemoveKhoiDanhSach != null)
                {
                    // Thêm vào danh sách tài sản cố định cá biệt
                    tblTaiSanCoDinhCaBiet taiSanCDCB = TaiSanCoDinhCaBiet_Factory.New().Get_TaiSanCoDinhCaBiet_ByMaTSCDCaBiet(item.MaTSCDCaBiet.Value);
                    _taiSanCoDinhCaBietList.Add(taiSanCDCB);

                    //Xóa factory in mã vạch tài sản cdcb
                    _inMaVachTaiSanCoDinhCaBiet_Factory.DeleteObject(inMaVachTSCDCaBietRemoveKhoiDanhSach);

                    //Xóa danh sách in mã vạch
                    _inMaVachTaiSanCoDinhCaBietList.Remove(inMaVachTSCDCaBietRemoveKhoiDanhSach);
                }
            }

            //Gán BindingSource
            tblInMaVachTaiSanCoDinhCaBietBindingSource.DataSource = _inMaVachTaiSanCoDinhCaBietList;
            tblTaiSanCoDinhCaBietBindingSource.DataSource = _taiSanCoDinhCaBietList;
            grdViewTSCDCaBiet.RefreshData();
            grdViewInMaVachTaiSan.RefreshData();
        }
        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.TimTaiSanCoDinhCaBiet();
        }

        private void btnInMaVachTaiSanChinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InMaVachTaiSan(inCaChiTiet: false);
        }


        private void btnInMaVachTaiSanChinhVaChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InMaVachTaiSan(inCaChiTiet: true);
        }

        private void InMaVachTaiSan(Boolean inCaChiTiet = false)
        {
            int maNhomTaiSan = Convert.ToInt32(cbNhomTaiSan.EditValue);
            int maPhongBan = Convert.ToInt32(cbPhongBan.EditValue);
            int maLoaiTaiSan = Convert.ToInt32(cbLoaiTaiSan.EditValue);
            int maTaiSanCoDinh = Convert.ToInt32(cbTaiSanCD.EditValue);

            ReportHelper.ShowReport("InMaVachTaiSanCoDinhCaBiet", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_InMaVachTaiSanCoDinhCaBiet", "@MaPhongBan,@MaNhomTaiSan,@MaLoaiTaiSan,@MaTaiSanCoDinh,@InCaChiTiet", maPhongBan, maNhomTaiSan, maLoaiTaiSan, maTaiSanCoDinh, inCaChiTiet);
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }
        private void btnInMaVachPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportHelper.ShowReport("InMaVachPhongBan", () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_InMaVachPhongBan", "");
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
        }
        #endregion

        private void frmInMaVachTSCDCaBiet_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_inMaVachTaiSanCoDinhCaBiet_Factory.IsDirty)
            {
                DialogResult dlgResult = DialogUtil.ShowSaveRequireOptionsOnFormClosing(this);
                if (DialogResult.Yes == dlgResult)
                {
                    if (false == this.Save())
                        e.Cancel = true;
                }
                else if (DialogResult.No == dlgResult)
                {
                    //không làm gì cả
                }
                else if (DialogResult.Cancel == dlgResult)
                {
                    e.Cancel = true;
                }
            }
        }        
    }
}
