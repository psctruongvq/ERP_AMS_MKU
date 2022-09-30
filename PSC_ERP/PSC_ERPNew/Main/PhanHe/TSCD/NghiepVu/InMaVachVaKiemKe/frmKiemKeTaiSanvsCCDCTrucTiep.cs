using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Model;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Common.Ado.Net;
using PSC_ERP_Business.Main;
using PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog;

namespace PSC_ERPNew.Main
{
    public partial class frmKiemKeTaiSanvsCCDCTrucTiep : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmKiemKeTaiSanvsCCDCTrucTiep singleton_ = null;
        public static frmKiemKeTaiSanvsCCDCTrucTiep Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmKiemKeTaiSanvsCCDCTrucTiep();
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
        List<tblnsBoPhan> _boPhanList = new List<tblnsBoPhan>();
        List<tblBoPhanERPNew> _viTriList = new List<tblBoPhanERPNew>();
        //tài sản
        KiemKeTaiSan_Factory _kiemKeTaiSan_Factory = KiemKeTaiSan_Factory.New();
        List<tblKiemKeTaiSan> _kiemKeTaiSanList = new List<tblKiemKeTaiSan>();
        List<spd_TSCD_LayTaiSanCoDinhvaChiTietTaiSanTheoPhongBanDenNgay_KiemKe_Result1> _dsTaiSanVaChiTietTheoPhongBan = new List<spd_TSCD_LayTaiSanCoDinhvaChiTietTaiSanTheoPhongBanDenNgay_KiemKe_Result1>();
             
        List<String> _dsSoHieuQuet = new List<String>();
        Int32 _userID = PSC_ERP_Global.Main.UserID;
        Int32 _maPhongBanKiemKe = 0;
        DateTime _ngayKiemKe = app_users_Factory.New().SystemDate;
        Boolean _quetMoi = false;
        String _maVach = "";
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmKiemKeTaiSanvsCCDCTrucTiep()
        {
            InitializeComponent();
        }

        public frmKiemKeTaiSanvsCCDCTrucTiep(Int32 maPhongBan, DateTime ngayKiemKe)
        {
            InitializeComponent();
            _maPhongBanKiemKe = maPhongBan;
            _ngayKiemKe = ngayKiemKe;
            btn_LayDanhSachTaiSanvaChiTiet_ItemClick(null, null);
        }

        #endregion

        //Private Member Function
        #region Private Member Function
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            if (grdViewKiemKeTaiSan.RowCount == 0 && grdViewKiemKeTaiSanTheoDoi.RowCount==0 && gridViewKiemKeCCDC.RowCount==0)
            {
                DialogUtil.ShowWarning("Chưa có dữ liệu!");
                duocPhepLuu = false;
            }
            return duocPhepLuu;
        }

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }
        private Boolean Save()
        {
            this.ChangeFocus();

            //kiểm tra dữ liệu trước khi lưu
            if (DuocPhepLuu())
            {
                try
                {
                    using (DialogUtil.WaitForSave(this))
                    {
                        //lưu kiểm kê tài sản
                        _kiemKeTaiSan_Factory.SaveChangesWithoutTrackingLog();                      
                        //_kiemKeTaiSan_Factory.SaveChanges(BusinessCodeEnum.TSCD_KiemKe.ToString());
                    }
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful(ex.Message);
                }
            }
            return false;
        }

        #endregion

        //Event Method
        #region Event Method

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLuu_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Save())
            {
                DialogResult dlgResult = DialogUtil.ShowYesNo("Kết thúc kiểm kê!\nBạn có muốn in báo cáo đối chiếu kiểm kê!");
                if (dlgResult == DialogResult.Yes)
                {
                    ReportHelper.ShowReport("DanhSachTaiSanvaChiTietCoDenNgay_DungKiemKeDoiChieu", () =>
                    {
                        DataSet dataSet = new DataSet();
                        SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                        dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTaiSanvaChiTietTaiSanCoDenNgay_KiemKeDoiChieu", "@DenNgay,@MaPhongBan,@CoChiTiet", _ngayKiemKe, _maPhongBanKiemKe, true);
                        #region Extend table
                        //Tao Bang Ngay Lap
                        DataTable dtngay = new DataTable();
                        dtngay.Columns.Add("DenNgay", typeof(DateTime));
                        //Add dòng 1
                        DataRow dr = dtngay.NewRow();
                        dr["DenNgay"] = _ngayKiemKe;
                        dtngay.Rows.Add(dr);
                        dtngay.TableName = "SubInfo";
                        dataSet.Tables.Add(dtngay);
                        #endregion
                        return dataSet;
                    }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
                }
                btn_LayDanhSachTaiSanvaChiTiet.Enabled = groupThongTinKiemKe.Enabled = true;
            }
            else
            {
                DialogUtil.ShowError("Kết thúc không thành công!");
            }
        }

        private void frmKiemKeTaiSanvsCCDCTrucTiep_Load(object sender, EventArgs e)
        {
            //khởi tạo dữ liệu 
            //_kiemKeTaiSan_Factory = KiemKeTaiSan_Factory.New();
            //_kiemKeCCDC_Factory = KiemKeCCDC_Factory.New();
            //_kiemKeTaiSanTheoDoi_Factory = KiemKeTaiSanTheoDoi_Factory.New();
            //Lấy dữ liệu
            _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).ToList();
            tblnsBoPhan_BindingSource.DataSource = _boPhanList;
            _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            tblBoPhanERPNewBindingSource.DataSource = _viTriList;
            //
            cbBoPhan.EditValue = _maPhongBanKiemKe;
            dteNgayKiemKe.EditValue = _ngayKiemKe;
            //cài đặt delete helper kiểm kê TSCD
            GridUtil.DeleteHelper.Setup_ManualType(grdViewKiemKeTaiSan, (gridView, deleteList) =>
                                                                        {
                                                                            // xóa kiểm kê tài sản trên lưới             
                                                                            foreach (tblKiemKeTaiSan item in deleteList)
                                                                            {
                                                                                _kiemKeTaiSanList.Remove(item);
                                                                                tblKiemKeTaiSanBindingSource.DataSource = _kiemKeTaiSanList;
                                                                                // Refesh lại lưới
                                                                                grdViewKiemKeTaiSan.RefreshData();
                                                                            }
                                                                            //xóa kiểm kê tài sản
                                                                            KiemKeTaiSan_Factory.FullDeleteKiemKeTaiSan(context: _kiemKeTaiSan_Factory.Context, deleteList: deleteList);
                                                                        });
          
            // Đưa checkbox lên lưới
            GridUtil.BooleanCheckAllBox.SetCheckAllBoxToBooleanGridColumn(this.grdViewKiemKeTaiSan, colDaQuetTSCD);           
          
            //
            GridUtil.DoubleClickHelper.Setup(this.grdViewKiemKeTaiSan, (object senderz1, EventArgs ez1) =>
            {
                GridView view = senderz1 as GridView;
                var obj = view.GetFocusedRow() as tblKiemKeTaiSan;
                
                tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet = TaiSanCoDinhCaBiet_Factory.New().Get_TaiSanCoDinhCaBiet_ByMaTSCDCaBiet(obj.MaTSCDCaBiet.Value);
                if (taiSanCoDinhCaBiet != null)
                {
                    if ((taiSanCoDinhCaBiet.LaTaiSanCu ?? false) == true)
                    {
                        Boolean _laDat = true;
                        if (taiSanCoDinhCaBiet.tblDanhMucTSCD.ParentID == 168)
                            //trường hợp tài sản là đất chỉ nhập vào để theo dõi không tính khấu hao hay hao mòn
                            _laDat = true;
                        else
                            _laDat = false;
                        frmNhapTaiSanCoDinhCaBietCu frm = new frmNhapTaiSanCoDinhCaBietCu(taiSanCoDinhCaBiet, _laDat);
                        if (frm.ShowDialog() == DialogResult.Yes)
                        {
                            _kiemKeTaiSan_Factory.RefreshAll(System.Data.Objects.RefreshMode.ClientWins);
                        }
                    }
                    else
                    {
                        frmDialogThongTinTSCDCaBiet frm = new frmDialogThongTinTSCDCaBiet(taiSanCoDinhCaBiet, true);
                        if (frm.ShowDialog() == DialogResult.Yes)
                        {
                            _kiemKeTaiSan_Factory.RefreshAll(System.Data.Objects.RefreshMode.ClientWins);
                        }
                    }
                }
            });
        }

        private void btn_LayDanhSachTaiSanvaChiTiet_ItemClick(object sender, ItemClickEventArgs e)
        {          
            using (DialogUtil.Wait(this))
            {
                #region lấy danh sách tài sản (có chi tiết nếu có) theo phòng ban có đến ngày kiểm kê                       
               // _dsTaiSanDaKiemKeDenNgay = _kiemKeTaiSan_Factory.Context.spd_TSCD_LayTaiSanCoDinhvaChiTietTaiSanTheoPhongBanDenNgay_KiemKe(_ngayKiemKe, _maPhongBanKiemKe,1).ToList();
                _kiemKeTaiSanList = _kiemKeTaiSan_Factory.Get_TaiSanCoDinhCaBiet_MaPhongBan_NgayKiemKe(_maPhongBanKiemKe, _ngayKiemKe).ToList();
                //if (_DSDaKiemKe.Count == 0)//nếu ngày đó phòng ban chưa kiểm kê sẽ lấy dữ liệu mới đã kiểm kê thì load lại dữ liệu cũ
                //{
                //    _quetMoi = true;
                    
                //    if (_dsTaiSanDaKiemKeDenNgay.Count > 0)
                //    {
                //        tblKiemKeTaiSanBindingSource.DataSource = null;
                //        _DSDaKiemKe = new List<tblKiemKeTaiSan>();
                //        foreach (spd_TSCD_LayTaiSanCoDinhvaChiTietTaiSanTheoPhongBanDenNgay_KiemKe_Result ts_or_ct in _dsTaiSanDaKiemKeDenNgay)
                //        {
                //            tblKiemKeTaiSan taiSanhayChiTietKiemKe = _kiemKeTaiSan_Factory.CreateManagedObject();
                //            taiSanhayChiTietKiemKe.MaPhongBan = ts_or_ct.MaBoPhan;
                //            taiSanhayChiTietKiemKe.SoHieuTSCDCaBiet = ts_or_ct.SoHieu;
                //            taiSanhayChiTietKiemKe.MaPhongBanQL = ts_or_ct.MaBoPhanQL;
                //            taiSanhayChiTietKiemKe.Ten = ts_or_ct.TaiSanCoDinhCaBiet;
                //            taiSanhayChiTietKiemKe.DaQuet = false;
                //            taiSanhayChiTietKiemKe.NguyenGiaBanDau = ts_or_ct.NguyenGiaMua;
                //            taiSanhayChiTietKiemKe.GiaTriMoiNhat = ts_or_ct.NguyenGiaTinhKhauHao;
                //            taiSanhayChiTietKiemKe.GiaTriConLai = ts_or_ct.GiaTriConLai;
                //            taiSanhayChiTietKiemKe.NgaySuDung = ts_or_ct.NgaySuDung;
                //            taiSanhayChiTietKiemKe.NgayKiemKe = _ngayKiemKe;
                //            taiSanhayChiTietKiemKe.MaTSCDCaBiet = ts_or_ct.MaTSCDCaBiet;
                //            taiSanhayChiTietKiemKe.UserID = _userID;
                //            if (ts_or_ct.LaTaiSan == 1)
                //            {
                //                taiSanhayChiTietKiemKe.LaTaiSan = true;
                //            }
                //            else
                //            {
                //                taiSanhayChiTietKiemKe.LaTaiSan = false;
                //                taiSanhayChiTietKiemKe.MaChiTietTSCDCaBiet = ts_or_ct.ID;
                //            }
                //            _DSDaKiemKe.Add(taiSanhayChiTietKiemKe);
                //        }
                //    }
                //}
                //else
                //{
                    foreach(tblKiemKeTaiSan kkTaiSan in _kiemKeTaiSanList)
                    {
                        if (kkTaiSan.DaQuet.Value)
                            _dsSoHieuQuet.Add(kkTaiSan.SoHieuTSCDCaBiet);
                    }
               // }
                tblKiemKeTaiSanBindingSource.DataSource = _kiemKeTaiSanList;
                #endregion          

                // Thông báo khi không có dữ liệu
                if (_kiemKeTaiSanList.Count == 0 )
                {
                    DialogUtil.ShowOK("Không có dữ liệu!");
                }
            }
        }
        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DialogResult.Yes == DialogUtil.ShowYesNo(string.Format("Bạn thật sự muốn xóa [{0}] này?", this.Text.Trim())))
            {
                //Xóa tất kiểm kê tài sản
                _kiemKeTaiSan_Factory.DeleteKiemKeTaiSan(_kiemKeTaiSanList);

                // Xóa danh sách 
                _kiemKeTaiSanList.Clear();

                //Gán bindingsource   
                tblKiemKeTaiSanBindingSource.DataSource = _kiemKeTaiSanList;
                grdViewKiemKeTaiSan.RefreshData();
                //DialogUtil.ShowInfo("Bấm nút " + btnLuu.Caption + " để hoàn tất");
            }
        }
        private void frmKiemKeTaiSan_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_kiemKeTaiSan_Factory.IsDirty)
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
        #endregion

        private void txt_MaVach_KeyDown(object sender, KeyEventArgs e)
        {
            Boolean daquet = false;
            if (e.KeyCode == Keys.Enter)
            {
                _maVach = txt_MaVach.Text;
                if (_maVach.Contains(" "))
                    _maVach = _maVach.Substring(0, _maVach.IndexOf(" "));
                foreach (String str in _dsSoHieuQuet)
                {
                    if (str == _maVach)
                    {
                        daquet = true;
                        break;
                    }
                }
                if (!daquet)
                {
                    _dsSoHieuQuet.Add(_maVach);
                }
                
                tblTaiSanCoDinhCaBiet taiSanCoDinhCaBiet = TaiSanCoDinhCaBiet_Factory.New().Get_TaiSanCoDinhCaBiet_BySoHieu(_maVach);
                tblChiTietTaiSanCaBiet chiTietTaiSanCoDinhCaBiet = ChiTietTaiSanCaBiet_Factory.New().Get_ChiTietTaiSanCaBiet_BySoHieu(_maVach);
            
                if (taiSanCoDinhCaBiet == null && chiTietTaiSanCoDinhCaBiet == null)//số hiệu không tồn tại trong phần mềm
                {
                    DialogUtil.ShowInfo("Không tồn tại tài sản hay công cụ có số hiệu này!");      
                }

                #region là tài sản cố định hay chi tiết của tài sản          
                else // là tài sản hay chi tiết tài sản
                {
                    if (LayThongTinMaVachQuet(_maVach) == 1)//có trong phần mềm và đúng vị trí
                    {
                        tblKiemKeTaiSan _kkTS = _kiemKeTaiSan_Factory.Get_TaiSanCoDinhCaBiet_BySoHieu_MaPhongBan_NgayKiemKe(_maVach, _maPhongBanKiemKe, _ngayKiemKe);
                        _kkTS.DaQuet = true;
                        _kkTS.NgayQuet = _kiemKeTaiSan_Factory.SystemDate;
                        _kiemKeTaiSan_Factory.SaveChanges();
                        //
                        tblKiemKeTaiSanBindingSource.ResetBindings(true);
                        int position = 0;
                        foreach (tblKiemKeTaiSan kkTS in _kiemKeTaiSanList)
                        {
                            if (kkTS.SoHieuTSCDCaBiet == _maVach)
                            {
                                break;
                            }
                            position++;
                        }
                        tblKiemKeTaiSanBindingSource.Position = position;
                        _kiemKeTaiSan_Factory.RefreshAll(System.Data.Objects.RefreshMode.ClientWins);
                    }
                    else // có trong phần mềm nhưng không đúng vị trí
                    {
                        //tblKiemKeTaiSan kiemKeTaiSanSaiViTri = _kiemKeTaiSan_Factory.CreateManagedObject();
                        //kiemKeTaiSanSaiViTri.UserID = _userID;
                        //kiemKeTaiSanSaiViTri.MaPhongBan = _maPhongBanKiemKe;
                        //kiemKeTaiSanSaiViTri.NgayKiemKe = _ngayKiemKe;
                        //kiemKeTaiSanSaiViTri.NgayQuet = _kiemKeTaiSan_Factory.SystemDate;
                        //kiemKeTaiSanSaiViTri.SoHieuTSCDCaBiet = _maVach;
                        //kiemKeTaiSanSaiViTri.MaPhongBanQL = BoPhan_Factory.New().Get_BoPhanTheoMaBoPhan(_maPhongBanKiemKe).MaBoPhanQL;                     
                        //kiemKeTaiSanSaiViTri.DaQuet = true;                        
                        //kiemKeTaiSanSaiViTri.TaiSanThua = true;

                        tblnsBoPhan boPhan = BoPhan_Factory.New().Get_ByID(_maPhongBanKiemKe);
                        if (taiSanCoDinhCaBiet != null)//là tài sản cố định
                        {
                            DialogUtil.ShowInfo("Tài sản: " + taiSanCoDinhCaBiet.SoHieu + "\nTên: " + taiSanCoDinhCaBiet.tblDanhMucTSCD.Ten + " " + taiSanCoDinhCaBiet.GhiChu + "\nKhông thuộc bộ phận này: " + boPhan.TenBoPhan + "\nHiện tại thuộc bộ phận: " + taiSanCoDinhCaBiet.PhanBoSauCung_RefObj.tblnsBoPhan.TenBoPhan);
                            //kiemKeTaiSanSaiViTri.LaTaiSan = true;
                            //kiemKeTaiSanSaiViTri.MaTSCDCaBiet = taiSanCoDinhCaBiet.MaTSCDCaBiet;
                            //kiemKeTaiSanSaiViTri.NgaySuDung = taiSanCoDinhCaBiet.NgaySuDung;
                            //kiemKeTaiSanSaiViTri.NguyenGiaBanDau = taiSanCoDinhCaBiet.NguyenGiaMua;
                            //kiemKeTaiSanSaiViTri.GiaTriMoiNhat = taiSanCoDinhCaBiet.NguyenGiaTinhKhauHao;
                            //kiemKeTaiSanSaiViTri.GiaTriConLai = taiSanCoDinhCaBiet.NguyenGiaConLai;
                            //kiemKeTaiSanSaiViTri.Ten = taiSanCoDinhCaBiet.tblDanhMucTSCD.Ten + " " + taiSanCoDinhCaBiet.GhiChu;
                        }
                        else//là chi tiết của tài sản
                        {
                            DialogUtil.ShowInfo("Chi tiết Tài sản: " + chiTietTaiSanCoDinhCaBiet.SoHieu + " " + chiTietTaiSanCoDinhCaBiet.TenChiTiet + "\nTài sản: " + chiTietTaiSanCoDinhCaBiet.tblTaiSanCoDinhCaBiet.SoHieu + " " + chiTietTaiSanCoDinhCaBiet.tblTaiSanCoDinhCaBiet.tblDanhMucTSCD.Ten + " " + chiTietTaiSanCoDinhCaBiet.tblTaiSanCoDinhCaBiet.GhiChu + "\nKhông thuộc bộ phận này: " + boPhan.TenBoPhan + "\nHiện tại thuộc bộ phận: " + chiTietTaiSanCoDinhCaBiet.tblTaiSanCoDinhCaBiet.PhanBoSauCung_RefObj.tblnsBoPhan.TenBoPhan);
                            //kiemKeTaiSanSaiViTri.MaTSCDCaBiet = chiTietTaiSanCoDinhCaBiet.tblTaiSanCoDinhCaBiet.MaTSCDCaBiet;
                            //kiemKeTaiSanSaiViTri.NgaySuDung = chiTietTaiSanCoDinhCaBiet.tblTaiSanCoDinhCaBiet.NgaySuDung;
                            //kiemKeTaiSanSaiViTri.NguyenGiaBanDau = chiTietTaiSanCoDinhCaBiet.NguyenGia;
                            //kiemKeTaiSanSaiViTri.GiaTriMoiNhat = kiemKeTaiSanSaiViTri.GiaTriConLai =chiTietTaiSanCoDinhCaBiet.NguyenGia + chiTietTaiSanCoDinhCaBiet.ChiPhi;                            
                            //kiemKeTaiSanSaiViTri.LaTaiSan = false;
                            //kiemKeTaiSanSaiViTri.MaChiTietTSCDCaBiet = chiTietTaiSanCoDinhCaBiet.MaChiTiet;
                            //kiemKeTaiSanSaiViTri.Ten = chiTietTaiSanCoDinhCaBiet.TenChiTiet;
                        }
                        //_DSDaKiemKe.Add(kiemKeTaiSanSaiViTri);
                        //_kiemKeTaiSan_Factory.SaveChanges();
                    }                
                }
                #endregion
              
                txt_MaVach.Text = "";
                txt_MaVach.Focus();
                if (KetThucQuetTuDong())
                {
                    DialogUtil.ShowInfo("Đã quét xong!\nTài Sản cố định, Công cụ dụng cụ và tài sản (CCDC) theo dõi ngoài của Phòng Ban này đã đủ!");
                    btnLuu_ItemClick(null, null);
                }
            }
        }

        private void dteNgayKiemKe_EditValueChanged(object sender, EventArgs e)
        {
            _ngayKiemKe = (DateTime)dteNgayKiemKe.EditValue;
        }

        private void cbBoPhan_EditValueChanged(object sender, EventArgs e)
        {
            _maPhongBanKiemKe = (Int32)cbBoPhan.EditValue;
        }

        private void btn_BatDau_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_kiemKeTaiSanList.Count == 0 )
            {
                DialogUtil.ShowOK("Không có dữ liệu.");
            }
            else
            {
                if (_quetMoi)
                    using (DialogUtil.WaitForSave(this))
                    {
                        _kiemKeTaiSan_Factory.SaveChanges();
                    }

                btn_LayDanhSachTaiSanvaChiTiet.Enabled = cbBoPhan.Enabled = dteNgayKiemKe.Enabled = false;//groupThongTinKiemKe.Enabled
                txt_MaVach.Focus();
            }     
        }

        public Int32 LayThongTinMaVachQuet(String soHieu)
        {
            foreach (tblKiemKeTaiSan kkts in _kiemKeTaiSanList)
            {
                if (kkts.SoHieuTSCDCaBiet == soHieu)
                {
                    return 1;
                }
            }
            return 0;
        }

        public Boolean KetThucQuetTuDong()
        {          
            foreach (tblKiemKeTaiSan kkts in _kiemKeTaiSanList)
            {
                if (!kkts.DaQuet.Value)
                {
                    return false;
                }
            }
           
            return true;
        }

        private void btn_InBaoCao_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDialogChonDuLieuInKiemKe dlg = new frmDialogChonDuLieuInKiemKe(true,_maPhongBanKiemKe,_ngayKiemKe, true);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                int maPhongBan = dlg.MaPhongBan;
                DateTime denNgay = dlg.DenNgay;
                Boolean coChiTietTS = dlg.CoChiTietTaiSan;
                Int32 TSCD_CCDC_TSCCDCTheoDoi = dlg.TSCDorCCDCorTS_CCDCTheoDoi;
                int loaiBaoCao = dlg.LoaiBaoCao;

                #region tài sản cố định và chi tiết của tài sản 
                if (TSCD_CCDC_TSCCDCTheoDoi==1) //tài sản cố định
                {
                    switch (loaiBaoCao)
                    {
                        case 0://báo cáo thừa
                            using (DialogUtil.Wait(this))
                            {
                                ReportHelper.ShowReport("DanhSachTaiSanvaChiTietCoDenNgay_DungKiemKeDoiChieu", () =>
                                {
                                    DataSet dataSet = new DataSet();
                                    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                                    dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTaiSanvaChiTietTaiSanCoDenNgay_KiemKeDoiChieu", "@DenNgay,@MaPhongBan,@CoChiTiet", denNgay, maPhongBan, coChiTietTS);
                                    #region Extend table
                                    //Tao Bang Ngay Lap
                                    DataTable dtngay = new DataTable();
                                    dtngay.Columns.Add("DenNgay", typeof(DateTime));
                                    //Add dòng 1
                                    DataRow dr = dtngay.NewRow();
                                    dr["DenNgay"] = denNgay;
                                    dtngay.Rows.Add(dr);
                                    dtngay.TableName = "SubInfo";
                                    dataSet.Tables.Add(dtngay);
                                    #endregion
                                    return dataSet;
                                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
                            }
                            break;
                        case 1://báo cáo thừa
                            using (DialogUtil.Wait(this))
                            {
                                ReportHelper.ShowReport("DanhSachTaiSanvaChiTietCoDenNgay_DungKiemKeThua", () =>
                                {
                                    DataSet dataSet = new DataSet();
                                    SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                                    dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTaiSanvaChiTietTaiSanCoDenNgay_KiemKeThua", "@DenNgay,@MaPhongBan,@CoChiTiet", denNgay, maPhongBan, coChiTietTS);
                                    #region Extend table
                                    //Tao Bang Ngay Lap
                                    DataTable dtngay = new DataTable();
                                    dtngay.Columns.Add("DenNgay", typeof(DateTime));
                                    //Add dòng 1
                                    DataRow dr = dtngay.NewRow();
                                    dr["DenNgay"] = denNgay;
                                    dtngay.Rows.Add(dr);
                                    dtngay.TableName = "SubInfo";
                                    dataSet.Tables.Add(dtngay);
                                    #endregion
                                    return dataSet;
                                }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
                            }
                            break;
                        case 2://báo cáo thiếu
                            using (DialogUtil.Wait(this))
                            {
                                ReportHelper.ShowReport("DanhSachTaiSanvaChiTietCoDenNgay_DungKiemKeThieu", () =>
                               {
                                   DataSet dataSet = new DataSet();
                                   SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                                   dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTaiSanvaChiTietTaiSanCoDenNgay_KiemKeThieu", "@DenNgay,@MaPhongBan,@CoChiTiet", denNgay, maPhongBan, coChiTietTS);
                                   #region Extend table
                                   //Tao Bang Ngay Lap
                                   DataTable dtngay = new DataTable();
                                   dtngay.Columns.Add("DenNgay", typeof(DateTime));
                                   //Add dòng 1
                                   DataRow dr = dtngay.NewRow();
                                   dr["DenNgay"] = denNgay;
                                   dtngay.Rows.Add(dr);
                                   dtngay.TableName = "SubInfo";
                                   dataSet.Tables.Add(dtngay);
                                   #endregion
                                   return dataSet;
                               }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, false, true);
                            }
                            break;
                        default:
                            break;
                    }
                }
                #endregion
       
            }
        }

        private void btn_XoaKiemKe_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult dlgResult = DialogUtil.ShowDelete(this, "Bạn có muốn xóa dữ liệu kiểm kê ngày " + _ngayKiemKe.ToShortDateString() + "\ncủa bộ phận " + BoPhan_Factory.New().Get_ByID(_maPhongBanKiemKe).TenBoPhan + " không?");
            if (dlgResult == DialogResult.Yes)
            {
                using (DialogUtil.Wait(this))
                {
                    #region xóa dữ liệu kiểm kê tài sản
                    _kiemKeTaiSan_Factory.DeleteKiemKeTaiSan(_kiemKeTaiSanList);
                    _kiemKeTaiSanList.Clear();

                    //Gán bindingsource   
                    tblKiemKeTaiSanBindingSource.DataSource = _kiemKeTaiSanList;
                    grdViewKiemKeTaiSan.RefreshData();
                    _kiemKeTaiSan_Factory.SaveChanges();
                    #endregion

                }
            }
        }

        private void btn_ExportTSCD_ItemClick(object sender, ItemClickEventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            GridUtil.ExportToExcel(gridView: this.grdViewKiemKeTaiSan, showOpenFilePrompt: true);     
        }

        private void btn_ExportCCDC_ItemClick(object sender, ItemClickEventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            GridUtil.ExportToExcel(gridView: this.gridViewKiemKeCCDC, showOpenFilePrompt: true);     
        }

        private void btn_ExportTSCD_CCDC_ItemClick(object sender, ItemClickEventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            GridUtil.ExportToExcel(gridView: this.grdViewKiemKeTaiSanTheoDoi, showOpenFilePrompt: true);
        }
    }
}
