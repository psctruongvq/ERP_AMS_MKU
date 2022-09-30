using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Common;
using PSC_ERP_Business.Main.Model;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.XtraEditors;

namespace PSC_ERPNew.Main
{
    public partial class frmKiemKeTaiSan : XtraForm
    {
        //Singleton
        #region Singleton
        private static frmKiemKeTaiSan singleton_ = null;
        public static frmKiemKeTaiSan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmKiemKeTaiSan();
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
        KiemKeTaiSan_Factory _kiemKeTaiSan_Factory = null;
        List<tblKiemKeTaiSan> _danhSachFileList = new List<tblKiemKeTaiSan>();
        List<tblKiemKeTaiSan> _kiemKeTaiSanList = new List<tblKiemKeTaiSan>();
        int _userID = PSC_ERP_Global.Main.UserID;
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmKiemKeTaiSan()
        {
            InitializeComponent();
        }
        #endregion

        //Private Member Function
        #region Private Member Function
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            if (grdViewKiemKeTaiSan.RowCount == 0)
            {
                // DialogUtil.ShowWarning("Chưa có dữ liệu");
                //  duocPhepLuu = false;
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
            //khởi tạo dữ liệu 
            _kiemKeTaiSan_Factory = KiemKeTaiSan_Factory.New();

            // Set mặc định ngày kiểm kê
            dteNgayKiemKe.EditValue = app_users_Factory.New().SystemDate;
            dteTuNgay.EditValue = app_users_Factory.New().SystemDate;
            dteDenNgay.EditValue = app_users_Factory.New().SystemDate;

            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewKiemKeTaiSan, (GridView gridView, List<Object> deleteList) =>
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

            //cài đặt delete helper
            GridUtil.DeleteHelper.Setup_ManualType(grdViewDanhSachFile, (GridView gridView, List<Object> deleteList) =>
            {
                //xóa danh sách file
                foreach (tblKiemKeTaiSan item in deleteList)
                {
                    _danhSachFileList.Remove(item);
                    tblDanhSachFile_BindingSource.DataSource = _danhSachFileList;
                    // Refesh lại lưới
                    grdViewDanhSachFile.RefreshData();
                }
            });
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            this.txtBlackHole.Focus();
            using (DialogUtil.Wait(this))
            {
                var tmpBoPhanERPFactory = BoPhanERPNew_Factory.New();
                var tmpTSCDCaBietFactory = TaiSanCoDinhCaBiet_Factory.New();
                //tạo mới factory
                _kiemKeTaiSan_Factory = KiemKeTaiSan_Factory.New();
                //tạo mới danh sach
                _kiemKeTaiSanList = new List<tblKiemKeTaiSan>();
                //
                foreach (var item in _danhSachFileList)
                {
                    if (item.DaQuet == false && item.FilePath != null)
                    {
                        #region Body
                        StreamReader sr = new StreamReader(item.FilePath);
                        string currentLine = sr.ReadLine();
                        if (currentLine != null)
                            currentLine = currentLine.Trim();
                        tblBoPhanERPNew boPhan = null;
                        String prefixPhongBan = "PB";
                        String prefixPhongBan1 = "BP";
                        while ((currentLine != null))
                        {
                            if (!String.IsNullOrWhiteSpace(currentLine))
                            {
                                //if (tmpBoPhanERPFactory.Get_BoPhanTheoMaBoPhanQL(currentLine) != null)
                                if (currentLine.Length >= prefixPhongBan.Length && (currentLine.Substring(0, prefixPhongBan.Length) == prefixPhongBan || currentLine.Substring(0, prefixPhongBan1.Length) == prefixPhongBan1))
                                {
                                    string maPBQL_DangXet = currentLine.Substring(prefixPhongBan.Length, currentLine.Length - prefixPhongBan.Length);
                                    //string maPBQL_DangXet = currentLine;
                                    boPhan = BoPhanERPNew_Factory.New().Get_BoPhanTheoMaBoPhanQL(maPBQL_DangXet);
                                    if (boPhan == null)
                                    {
                                        MessageBox.Show("Không tồn tại bộ phận có mã : " + maPBQL_DangXet);
                                        //xoa trang danh sach
                                        //_DSDaKiemKe.Clear();

                                        //Cập nhật đã đọc trong danh sách file
                                        //item.DaDoc = false;
                                        //break;
                                    }
                                }
                                else//xu ly dong tai san
                                {
                                    Boolean trungTS_PB = false;
                                    if (_kiemKeTaiSanList != null)
                                    {
                                        foreach (tblKiemKeTaiSan kiemKeTaiSan in _kiemKeTaiSanList)
                                        {
                                            if (kiemKeTaiSan.MaPhongBan == boPhan.MaBoPhan && kiemKeTaiSan.SoHieuTSCDCaBiet == currentLine)
                                            {
                                                trungTS_PB = true;
                                            }
                                        }
                                    }
                                    if (trungTS_PB == false)
                                    {
                                        var tsCaBiet = tmpTSCDCaBietFactory.Get_TaiSanCoDinhCaBiet_BySoHieu(currentLine);
                                        tblKiemKeTaiSan kiemKeTaiSanCDCB = _kiemKeTaiSan_Factory.CreateManagedObject();
                                        kiemKeTaiSanCDCB.MaPhongBan = boPhan.MaBoPhan;
                                        kiemKeTaiSanCDCB.MaPhongBanQL = boPhan.MaBoPhanQL;
                                        kiemKeTaiSanCDCB.SoHieuTSCDCaBiet = currentLine;
                                        if (tsCaBiet != null)
                                            kiemKeTaiSanCDCB.MaTSCDCaBiet = tsCaBiet.MaTSCDCaBiet;
                                        else
                                        {   //Lấy chi tiết tài sản cố định cá biệt
                                            tblChiTietTaiSanCaBiet chiTietTSCDCaBiet = ChiTietTaiSanCaBiet_Factory.New().Get_ChiTietTaiSanCaBiet_BySoHieu(kiemKeTaiSanCDCB.SoHieuTSCDCaBiet);
                                            if (chiTietTSCDCaBiet != null)
                                                kiemKeTaiSanCDCB.MaChiTietTSCDCaBiet = chiTietTSCDCaBiet == null ? 0 : chiTietTSCDCaBiet.MaChiTiet;
                                            else
                                            {
                                                // Tiếp tục đọc dữ liệu
                                                currentLine = sr.ReadLine();
                                                if (currentLine != null)
                                                    currentLine = currentLine.Trim();
                                                continue;
                                            }
                                        }

                                        kiemKeTaiSanCDCB.NgayKiemKe = dteNgayKiemKe.DateTime.Date; //app_users_Factory.New().SystemDate;
                                        kiemKeTaiSanCDCB.FilePath = item.FilePath;
                                        kiemKeTaiSanCDCB.UserID = _userID;
                                        //Đưa vào danh sach kiểm kê tài sản
                                        _kiemKeTaiSanList.Add(kiemKeTaiSanCDCB);
                                        //Cập nhật đã đọc trong danh sách file
                                        item.DaQuet = true;
                                    }
                                }
                            }
                            // Tiếp tục đọc dữ liệu
                            currentLine = sr.ReadLine();
                            if (currentLine != null)
                                currentLine = currentLine.Trim();
                        }
                        sr.Close();
                        //Gán bindingsource
                        tblKiemKeTaiSanBindingSource.DataSource = _kiemKeTaiSanList;

                        // Refesh lại lưới
                        grdViewKiemKeTaiSan.RefreshData();
                        grdViewDanhSachFile.RefreshData();
                        #endregion
                    }
                }
            }
        }

        private void btnEdit_DuongDan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //Stream myStream = null;
            openFileDialog_DuongDan.InitialDirectory = "c:\\";
            openFileDialog_DuongDan.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog_DuongDan.FilterIndex = 2;
            openFileDialog_DuongDan.RestoreDirectory = true;

            if (openFileDialog_DuongDan.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //if ((myStream = openFileDialog_DuongDan.OpenFile()) != null)
                    //{
                    //using (myStream)
                    {
                        tblKiemKeTaiSan kiemKeTS = new tblKiemKeTaiSan();
                        kiemKeTS.FilePath = openFileDialog_DuongDan.FileName;
                        _danhSachFileList.Add(kiemKeTS);

                        //Gán bindingsource
                        tblDanhSachFile_BindingSource.DataSource = _danhSachFileList;
                        grdViewDanhSachFile.RefreshData();
                    }
                    //}
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowError("Không lấy được file này!\n" + ex.Message);
                }
            }
        }
        private void btnTimTaiSanChoDuyet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (DialogUtil.Wait(this))
            {
                Boolean isAdmin = false;
                // Lấy từ ngày, đến ngày từ form
                DateTime tuNgay = (DateTime)dteTuNgay.EditValue;
                DateTime denNgay = (DateTime)dteDenNgay.EditValue;

                //Kiểm tra xem user đăng nhập có phải admin hay không
                isAdmin = app_users_Factory.New().CheckAdminByUserID_ContainsAdminKeyword(_userID);

                //Lấy danh sách kiểm kê tài sản dựa vào thông trên
                _kiemKeTaiSanList = _kiemKeTaiSan_Factory.Get_DanhSachKiemKeTaiSanTheoNgayKiemKe_PhucVuKiemKeTaiSan(tuNgay, denNgay, _userID, isAdmin).ToList();
                // Gán vào bindingsource
                tblKiemKeTaiSanBindingSource.DataSource = _kiemKeTaiSanList;

                // Thông báo khi không có dữ liệu
                if (_kiemKeTaiSanList.Count == 0)
                {
                    DialogUtil.ShowOK("Không có dữ liệu.");
                }
            }
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn thật sự muốn xóa [" + this.Text.Trim() + "] này?"))
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
    }
}
