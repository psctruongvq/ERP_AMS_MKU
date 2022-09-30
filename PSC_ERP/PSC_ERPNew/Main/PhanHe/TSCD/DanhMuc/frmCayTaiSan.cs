using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList.Nodes;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using DevExpress.XtraEditors;
using PSC_ERP;
using ERP_Library.Security;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraTreeList;
using DevExpress.XtraLayout;
using Csla;
using System.IO;

namespace PSC_ERPNew.Main
{
    public partial class frmCayTaiSan : XtraForm
    {
        #region Private Static Field
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion

        //Singleton
        #region Singleton
        private static frmCayTaiSan singleton_ = null;
        public static frmCayTaiSan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmCayTaiSan();
                return singleton_;
            }
        }

        public static void ShowSingleton(object owner, Form mdiParent = null)
        {
            FormUtil.ShowForm_Helper(Singleton, owner, mdiParent);
        }

        #endregion

        //Private Member field
        #region Private Member field
        string _tenDangNhap = CurrentUser.Info.TenDangNhap;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        int _userID = CurrentUser.Info.UserID;
        UserInfo _user = CurrentUser.Info;
        DanhMucTSCD_Factory _danhMucTSCD_Factory = null;
        private TaiSanCoDinhCaBiet_Factory _taiSanCoDinhCaBiet_Factory = null;
        List<tblTaiKhoan> _taiKhoanList = null;
        IQueryable<tblDanhMucTSCD> _danhMucTSCDList = null;
        // List<tblTaiSanCoDinhCaBiet> _taiSanCoDinhCaBietList = null;
        List<tblDonViTinh> _donViTinhList = null;
        List<tblQuocGia> _quocGiaList = null;

        // UserItem _user = UserItem.NewUserItemChooseChild();
        // List<spRpt_TSCD_ReportTongHopBaoCaoChiTietTSCDCuaDonViHCSN_Result> DanhSachTaiSanCoDinhCaBiet = null;
        DataTable _dt_TaiSanCoDinhCaBiet = new DataTable();
        #endregion

        //Member Constructor
        #region Member Constructor
        public frmCayTaiSan()
        {
            InitializeComponent();
            //this.LoadData();
        }
        #endregion
        //Private Member Function
        #region Private Member Function

        private bool KiemTraTSTruocKhiXoa(tblDanhMucTSCD obj)//M
        {
            TaiSanCoDinhCaBiet_Factory taiSanCoDinhCaBiet_Factory = TaiSanCoDinhCaBiet_Factory.New();
            if (obj.LaNhomTaiSan == true)
            {
                if (taiSanCoDinhCaBiet_Factory.Any_TaiSanCoDinhCaBiet_ByMaNhomTaiSan(obj.ID))
                {
                    MessageBox.Show(String.Format("Hiện có tài sản cá biệt thuộc nhóm [{0}], Không thể xóa!", obj.Ten));
                    return false;
                }
            }
            else if (obj.LaLoaiTaiSan == true)
            {

                if (taiSanCoDinhCaBiet_Factory.Any_TaiSanCoDinhCaBiet_ByMaLoaiTaiSan(obj.ID))
                {
                    MessageBox.Show(String.Format("Hiện có tài sản cá biệt thuộc loại [{0}], Không thể xóa!", obj.Ten));
                    return false;
                }
            }
            else if (obj.LaTaiSanCoDinh == true)
            {
                if (taiSanCoDinhCaBiet_Factory.Any_TaiSanCoDinhCaBiet_ByMaTSCD(obj.ID))
                {
                    MessageBox.Show(String.Format("Hiện có tài sản cá biệt thuộc tài sản [{0}], Không thể xóa!", obj.Ten));
                    return false;
                }
            }
            return true;
        }

        private void LoadData()
        {
            using (DialogUtil.Wait(this))
            {
                //khởi tạo factory
                _danhMucTSCD_Factory = DanhMucTSCD_Factory.New();
                //lấy hết cây danh mục
                _danhMucTSCDList = _danhMucTSCD_Factory.Get_DanhSachTaiSanTheoMaCongTy(_maCongTy);
                this.tblDanhMucTSCDBindingSource.DataSource = _danhMucTSCDList;

                //lấy danh sách đơn vị tính
                _donViTinhList = DonViTinh_Factory.New().ParallelGetAll().ToList();
                tblDonViTinh dvt_khongChon = new tblDonViTinh() { MaDonViTinh = 0, MaQuanLy = "<<Không chọn>>", TenDonViTinh = "<<Không chọn>>" };
                _donViTinhList.Insert(0, dvt_khongChon);
                this.tblDonViTinhBindingSource.DataSource = _donViTinhList;
                //tài khoản
                _taiKhoanList = TaiKhoan_Factory.New().ParallelGetAll().ToList();
                tblTaiKhoan taiKhoan_khongChon = new tblTaiKhoan() { MaTaiKhoan = 0, SoHieuTK = "<<Không chọn>>", TenTaiKhoan = "<<Không chọn>>" };
                _taiKhoanList.Insert(0, taiKhoan_khongChon);
                this.tblTaiKhoan_BindingSource.DataSource = _taiKhoanList;
                // tài khoản khấu hao lũy kế. bổ sung 26/10/2020 
                this.tblTaiKhoanLuyKe_BinDingSource.DataSource = _taiKhoanList;
                //lấy danh sách quốc gia
                _quocGiaList = QuocGia_Factory.New().ParallelGetAll().ToList();
                tblQuocGia quocGia_khongChon = new tblQuocGia() { MaQuocGia = 0, MaQuocGiaQuanLy = "<<Không chọn>>", TenQuocGia = "<<Không chọn>>" };
                _quocGiaList.Insert(0, quocGia_khongChon);
                this.tblQuocGiaBindingSource.DataSource = _quocGiaList;
                //                   
                tblDoiTacBindingSource.DataSource = DoiTac_Factory.New().ParallelGetAll();
                EnableTreeView(true);
            }
        }

        private tblDanhMucTSCD GetObject_AtNode(TreeListNode node)
        {
            //Int32 id = (Int32)node.GetValue(this.colID);
            return treeList1.GetDataRecordByNode(node) as tblDanhMucTSCD;
        }
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;
            foreach (TreeListNode childNode in treeList1.GetNodeList())
            {
                tblDanhMucTSCD danhMuc = GetObject_AtNode(childNode);
                if (danhMuc.Ten == null || danhMuc.Ten.Trim() == "")
                {
                    treeList1.FocusedNode = childNode;
                    treeList1.MakeNodeVisible(treeList1.FocusedNode); //srcoll đến dòng focus 
                    //DialogUtil.ShowWarning("Tài sản hay CCDC " + danhMuc.MaQuanLy + " chưa có Tên!\nVui lòng nhập tên!");
                    XtraMessageBox.Show("Tài sản hay CCDC <color=red>" + danhMuc.MaQuanLy + "</color>\n<b>-Chưa có tên. Vui lòng nhập tên!</b>", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
                    return false;
                }
                if (danhMuc.LaTaiSanCoDinh == true && (danhMuc.MaDonViTinhTSCD == null || danhMuc.MaDonViTinhTSCD == 0))
                {
                    treeList1.FocusedNode = childNode;
                    treeList1.MakeNodeVisible(treeList1.FocusedNode); //srcoll đến dòng focus 
                    XtraMessageBox.Show("Tài sản hay CCDC \n-Mã: <color=red>" + danhMuc.MaQuanLy + "</color>\n-Tên: <color=red>" + danhMuc.Ten + "</color> \n<b>-Chưa có đơn vị tính. Vui lòng chọn đơn vị tính!</b>", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
                    return false;
                }
                if (danhMuc.LaNhomTaiSan != true && (danhMuc.TaiKhoanTuongUng == null || danhMuc.TaiKhoanTuongUng == 0))
                {
                    treeList1.FocusedNode = childNode;
                    treeList1.MakeNodeVisible(treeList1.FocusedNode); //srcoll đến dòng focus 
                    XtraMessageBox.Show("Tài sản hay CCDC \n-Mã: <color=red>" + danhMuc.MaQuanLy + "</color>\n-Tên: <color=red>" + danhMuc.Ten + "</color> \n<b>-Chưa có mã tài khoản nguyên giá. Vui lòng chọn mã tài khoản nguyên giá!</b>", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
                    return false;
                }
                if (danhMuc.LaNhomTaiSan != true && (danhMuc.TaiKhoanPhanBo == null || danhMuc.TaiKhoanPhanBo == 0))
                {
                    treeList1.FocusedNode = childNode;
                    treeList1.MakeNodeVisible(treeList1.FocusedNode); //srcoll đến dòng focus 
                    XtraMessageBox.Show("Tài sản hay CCDC \n-Mã: <color=red>" + danhMuc.MaQuanLy + "</color>\n-Tên: <color=red>" + danhMuc.Ten + "</color> \n<b>-Chưa có mã tài khoản khấu hao lũy kế. Vui lòng chọn mã tài khoản khấu hao lũy kế!</b>", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
                    return false;
                }
                if (danhMuc.LaTaiSanCoDinh == true && (danhMuc.TGSuDungToiTHieuTSCD == null || danhMuc.TGSuDungToiTHieuTSCD < 1))
                {
                    treeList1.FocusedNode = childNode;
                    treeList1.MakeNodeVisible(treeList1.FocusedNode); //srcoll đến dòng focus  
                    XtraMessageBox.Show("Tài sản hay CCDC \n-Mã: <color=red>" + danhMuc.MaQuanLy + "</color>\n-Tên: <color=red>" + danhMuc.Ten + "</color> \n<b>-Thời gian sử dụng không hợp lệ (phải lớn hơn 0). Vui lòng nhập lại thời gian sử dụng!</b>", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);
                    return false;
                }
                if ((danhMuc.MaChiPhiKeToan == null || danhMuc.MaChiPhiKeToan == "") && danhMuc.LaTaiSanCoDinh == true && danhMuc.ID == 0)
                {
                    treeList1.FocusedNode = childNode;
                    treeList1.MakeNodeVisible(treeList1.FocusedNode); //srcoll đến dòng focus  
                    XtraMessageBox.Show("Tài sản hay CCDC \n-Mã: <color=red>" + danhMuc.MaQuanLy + "</color>\n-Tên: <color=red>" + danhMuc.Ten + "</color> \n<b>-Mã phí kế toán không hợp lệ (phải lớn hơn 0). Vui lòng nhập lại Mã phí kế toán!</b>", "CẢNH BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True);                    
                }
            }
            return duocPhepLuu;
        }
        private Boolean Save()
        {
            txtBlackHole.Focus();
            //kiểm tra chứng từ trước khi lưu
            if (DuocPhepLuu())
                try
                {
                    _danhMucTSCD_Factory.SaveChangesWithoutTrackingLog();
                    //_danhMucTSCD_Factory.SaveChanges();//lưu lại
                    DialogUtil.ShowSaveSuccessful();
                    EnableTreeView(true);
                    return true;//lưu thành công
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful();
                }
            return false;//lưu không thành công hoặc không được phép lưu
        }
        private string PhatSinhMaQuanLyMoi(TreeListNode parentNode, Boolean phatSinhMaQuanLyLoaiTaiSan = false)
        {
            Int32 sizeOfIncreasePart = 0;
            //xác định size
            if (phatSinhMaQuanLyLoaiTaiSan)
                sizeOfIncreasePart = PSC_ERP_Global.TSCD.SizeOf_MaLoaiTaiSanQuanLy_IncreasePart;
            else
                sizeOfIncreasePart = PSC_ERP_Global.TSCD.SizeOf_MaTSCDQuanLy_IncreasePart;
            //
            tblDanhMucTSCD parentObject = GetObject_AtNode(parentNode);
            String soHieuMoi = "";

            Int32 maxNum = 0;

            //foreach (TreeListNode childNode in parentNode.Nodes)
            //{
            //    tblDanhMucTSCD childObj = GetObject_AtNode(childNode);
            //    //nếu mã quản lý tuân theo quy tắc
            //    if (childObj.MaQuanLy.Length == parentObject.MaQuanLy.Length + sizeOfIncreasePart)
            //    {
            //        Int32 maxNumTemp = Int32.Parse(childObj.MaQuanLy.Substring(childObj.MaQuanLy.Length - sizeOfIncreasePart));
            //        if (maxNumTemp > maxNum)
            //            maxNum = maxNumTemp;
            //    }
            //}

            String soHieuCapTren = parentObject.MaQuanLy;
            //lựa chọn phương thức
            if (phatSinhMaQuanLyLoaiTaiSan)//phát sinh mã quản lý loại tài sản mới
            {

                String maxSoHieu = _danhMucTSCD_Factory.Get_MaxSoHieuLoaiTS_ByMaCapTrenTrucTiep(parentObject.ID, ERP_Library.Security.CurrentUser.Info.MaCongTy);
                if (!String.IsNullOrWhiteSpace(maxSoHieu))
                {
                    maxNum = Int32.Parse(maxSoHieu.Substring(maxSoHieu.Length - sizeOfIncreasePart));
                }

                if (maxNum == 0) //số hiệu đầu tiên
                    soHieuMoi = _danhMucTSCD_Factory.CreateFirst_MaQuanLyLoaiTaiSan(soHieuCapTren);
                else//số hiệu tiếp theo
                    soHieuMoi = _danhMucTSCD_Factory.Create_MaQuanLyLoaiTaiSan(soHieuCapTren, maxNum + 1);
            }
            else//phát sinh mã quản lý tài sản cố định mới
            {
                String maxSoHieu = _danhMucTSCD_Factory.Get_MaxSoHieuTSCD_ByMaLoaiCapTrenTrucTiep(parentObject.ID, ERP_Library.Security.CurrentUser.Info.MaCongTy);
                if (!String.IsNullOrWhiteSpace(maxSoHieu))
                {
                    maxNum = Int32.Parse(maxSoHieu.Substring(maxSoHieu.Length - sizeOfIncreasePart));
                }

                if (maxNum == 0) //số hiệu đầu tiên
                    soHieuMoi = _danhMucTSCD_Factory.CreateFirst_MaQuanLyTSCD(soHieuCapTren);
                else//số hiệu tiếp theo
                    soHieuMoi = _danhMucTSCD_Factory.Create_MaQuanLyTSCD(soHieuCapTren, maxNum + 1);
            }
            return soHieuMoi;
        }
        private void FillterTree()
        {
            String pattern = txtFilterTree.Text.Trim();
            if (String.IsNullOrWhiteSpace(pattern))
            {
                //this.treeList1.DataSource = null;
                tblDanhMucTSCDBindingSource.DataSource = _danhMucTSCDList;
                this.treeList1.DataSource = this.tblDanhMucTSCDBindingSource;
            }
            else
            {
                IEnumerable<tblDanhMucTSCD> kqList = _danhMucTSCD_Factory.Context.sp_TSCD_DanhMucTreeSearch(pattern);//new List<tblDanhMucTSCD>();
                tblDanhMucTSCDBindingSource.DataSource = kqList;
                this.treeList1.DataSource = this.tblDanhMucTSCDBindingSource;
                TreeUtils.FilterTreeNode(treeList1, pattern);
            }
        }

        private void ThemLenCay(Boolean themLoai = false, Boolean themTSCD = false)
        {
            TreeListNode focusedNode = treeList1.FocusedNode;//C
            Boolean duocPhepThemMoi = true;
            tblDanhMucTSCD currentObject = GetObject_AtNode(focusedNode);//C
            if (currentObject.ID == 0)
            {
                if (DialogResult.Yes == DialogUtil.ShowYesNo("Lưu lại thay đổi cũ trên cây danh mục trước khi thêm mới"))
                {
                    if (this.Save())
                        duocPhepThemMoi = true;
                    else
                        duocPhepThemMoi = false;
                }
            }
            //
            foreach (TreeListNode childNode in focusedNode.Nodes)
            {
                tblDanhMucTSCD danhMuc = GetObject_AtNode(childNode);
                if (danhMuc.ID == 0)
                {
                    if (DialogResult.Yes == DialogUtil.ShowYesNo("Lưu lại thay đổi cũ trên cây danh mục trước khi thêm mới"))
                    {
                        if (this.Save())
                            duocPhepThemMoi = true;
                        else
                            duocPhepThemMoi = false;
                    }
                }
            }

            //được phép thêm mới
            if (duocPhepThemMoi)
            {
                tblDanhMucTSCD newObj = _danhMucTSCD_Factory.CreateManagedObject();
                newObj.ParentID = currentObject.ID;
                xtraTabControl1.SelectedTabPage = tabPageChiTiet;//M
                txtTen.Focus();//M
                newObj.MaCongTy = _maCongTy;
                if (themLoai)
                {
                    newObj.LaLoaiTaiSan = true;
                    //định nhóm cho loại
                    if (currentObject.LaNhomTaiSan == true)
                    {
                        newObj.LoaiTaiSanThuocNhomTaiSan = currentObject.ID;
                    }
                    else if (currentObject.LaLoaiTaiSan == true)
                    {
                        newObj.LoaiTaiSanThuocNhomTaiSan = currentObject.LoaiTaiSanThuocNhomTaiSan;
                    }
                    //phát sinh số hiệu loại tài sản mới
                    newObj.MaQuanLy = PhatSinhMaQuanLyMoi(parentNode: focusedNode, phatSinhMaQuanLyLoaiTaiSan: true);
                }
                else if (themTSCD)
                {
                    newObj.LaTaiSanCoDinh = true;
                    //phát sinh số hiệu tài sản cố định mới
                    newObj.MaQuanLy = PhatSinhMaQuanLyMoi(parentNode: focusedNode);
                }

                newObj.Ten = treeList1.Columns["Ten"].FilterInfo.AutoFilterRowValue + "";// gán giá trị Filter mà user đang tìm vào giá trị Tên khi thêm mới.
                if (currentObject.TaiKhoanTuongUng != null)
                    newObj.TaiKhoanTuongUng = currentObject.TaiKhoanTuongUng;
                if (currentObject.TaiKhoanPhanBo != null)
                    newObj.TaiKhoanPhanBo = currentObject.TaiKhoanPhanBo;
                newObj.MaChiPhiKeToan = currentObject.MaChiPhiKeToan;
                newObj.TGSuDungToiTHieuTSCD = currentObject.TGSuDungToiTHieuTSCD;
                //thêm vào binding source
                tblDanhMucTSCDBindingSource.Add(newObj);
                //focus tới vị trí vừa thêm vào
                tblDanhMucTSCDBindingSource.Position = tblDanhMucTSCDBindingSource.IndexOf(newObj);
                EnableTreeView(false);
            }
        }
        private void EnableTreeView(bool Bat)
        {
            treeList1.Enabled = Bat;
        }
        #endregion

        //Event Method
        #region Event Method
        private void btnDocDanhSachTaiSanCoDinhCaBiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (DialogUtil.Wait(this))
            {
                tblDanhMucTSCD obj = GetObject_AtNode(treeList1.FocusedNode);
                if (obj != null)
                {
                    _taiSanCoDinhCaBiet_Factory = TaiSanCoDinhCaBiet_Factory.New();
                    if (obj.LaTaiSanCoDinh == true)
                    {
                        _dt_TaiSanCoDinhCaBiet = dt_TaiSanCoDinhCaBiet(obj.ID, _maCongTy, true);
                    }
                    else
                    {
                        _dt_TaiSanCoDinhCaBiet = dt_TaiSanCoDinhCaBiet(obj.ID, _maCongTy);
                    }
                    grdTaiSanCoDinhCaBiet.DataSource = _dt_TaiSanCoDinhCaBiet;
                    if (grdViewTaiSanCoDinhCaBiet.RowCount == 0)
                        DialogUtil.ShowInfo("Không có tài sản cố định cá biệt!");
                }
            }
        }
        #region Đọc danh sách tài sản cố định cá biệt
        public static DataTable dt_TaiSanCoDinhCaBiet(Nullable<int> loaiTaiSan, Nullable<int> maCongTy, bool LaTaiSanCoDinh = false)
        {
            DataTable kq = new DataTable();
            try
            {
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandTimeout = 1800;
                        cm.CommandType = CommandType.StoredProcedure;
                        if (LaTaiSanCoDinh)
                        {
                            cm.CommandText = "spd_TSCDCB_LayDanhSachTSCDCB";
                            cm.Parameters.AddWithValue("@MaTSCD", loaiTaiSan);
                        }
                        else
                        {
                            cm.CommandText = "spd_TSCD_LayDanhSachTaiSanCoDinhTrongNhieuCapLoaiTaiSan";
                            cm.Parameters.AddWithValue("@LoaiTaiSan", loaiTaiSan);
                        }
                        cm.Parameters.AddWithValue("@MaCongTy", maCongTy);
                        SqlDataAdapter da = new SqlDataAdapter(cm);
                        da.Fill(kq);
                    }
                }
                return kq;
            }
            catch (Exception ThongBaoLoi) { XtraMessageBox.Show("<color=red>-Lỗi: </color>" + ThongBaoLoi.ToString(), "ĐÃ XẢY RA LỖI", DevExpress.Utils.DefaultBoolean.True); return kq; }
        }
        #endregion Đọc danh sách tài sản cố định cá biệt
        private void treeList1_NodeCellStyle(object sender, DevExpress.XtraTreeList.GetCustomNodeCellStyleEventArgs e)
        {
            try
            {
                tblDanhMucTSCD obj = GetObject_AtNode(e.Node);
                if (obj != null)
                {
                    //tô màu tree cho dễ nhìn
                    if (obj.LaNhomTaiSan == true)
                    {
                        //if (object.ReferenceEquals(e.Column, this.colTen))
                        //{
                        e.Appearance.BackColor = Color.WhiteSmoke;
                        e.Appearance.ForeColor = Color.LimeGreen;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                        //}
                    }
                    else if (obj.LaLoaiTaiSan == true)
                    {
                        e.Appearance.BackColor = Color.WhiteSmoke;
                        e.Appearance.ForeColor = Color.Blue;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
                    else if (obj.LaTaiSanCoDinh == true)
                    {
                        e.Appearance.BackColor = Color.WhiteSmoke;
                        e.Appearance.ForeColor = Color.Red;
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError(ex.Message);
            }
        }

        private void frmCayTaiSan_Load(object sender, EventArgs e)
        {
            if (_tenDangNhap.ToLower() == "admin")
            {
                btn_XoaToanBoDuLieu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            if (_user.GroupID == 38)
            {
                btn_ImportTSCDCB.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btn_ImportTSCDCB.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            this.Shown += (senderz, ez) =>
                          {
                              this.LoadData();
                              //set STT
                              GridUtil.SetSTTForGridView(this.grdViewTaiSanCoDinhCaBiet);
                              //
                              GridUtil.DoubleClickHelper.Setup(this.grdViewTaiSanCoDinhCaBiet, (senderz1, ez1) =>
                                {
                                    GridView view = senderz1 as GridView;
                                    var obj = view.GetFocusedRow() as tblTaiSanCoDinhCaBiet;
                                    DataRow dr = grdViewTaiSanCoDinhCaBiet.GetDataRow(grdViewTaiSanCoDinhCaBiet.FocusedRowHandle);
                                    if (dr != null)
                                    {
                                        int maTSCDCB = int.Parse(dr["MaTSCDCaBiet"].ToString());
                                        frmDialogThongTinTSCDCaBiet frm = new frmDialogThongTinTSCDCaBiet(obj, true, maTSCDCB);
                                        if (frm.ShowDialog() == DialogResult.Yes)
                                        {
                                            // load lại danh sách sau khi chỉnh sửa
                                            btnDocDanhSachTaiSanCoDinhCaBiet_ItemClick(sender, null);
                                        }
                                    }
                                });
                              treeList1.IndicatorWidth = 50;
                              treeList1.ExpandAll();
                          };
        }
        private void treeList1_AfterFocusNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            //mở rộng node
            //e.Node.Expanded = true;          
            tblDanhMucTSCD obj = GetObject_AtNode(e.Node);
            //ẩn tất cả nút thêm
            btnThemLoai.Visible = false;
            btnThemTaiSanCoDinh.Visible = false;
            btn_nhapTaiSanCoDinhCu.Visible = false;
            btnXoaTrenCay.Visible = false;
            if (obj != null)
            {
                //ẩn tất cả các control trong chi tiết
                //ControlUtil.HideControls(this.panelChiTiet.Controls);
                ControlUtil.HideControl_LayoutGroup(this.layoutCT);
                if (obj.LaNhomTaiSan == true)
                {
                    //hiện các control của nhóm và loại
                    //ControlUtil.ShowControls(new Control[] { lblMaQuanLy, txtMaQuanLy ,lblTen,lblTenRequired, txtTen});
                    ControlUtil.ShowControl_LayoutGroup(new LayoutControlItem[] { layoutMa, layoutTen });
                    if (CurrentUser.Info.CapNhatHoSo == false)//(_user.CapNhatHoSo==false)
                    {// 20/11/2020 ko cho phép chỉnh sửa khi ko có quyền 
                        txtMaQuanLy.ReadOnly = true; txtTen.ReadOnly = true;
                    }
                }
                else if (obj.LaLoaiTaiSan == true)
                { //hiện các control của nhóm và loại
                    ControlUtil.ShowControl_LayoutGroup(new LayoutControlItem[] { layoutMa, layoutTen, layoutTGSuDung, layoutThang, layoutTKNG, layoutTKKHLuyKe, layoutMaPhiKeToan });

                    if (CurrentUser.Info.CapNhatHoSo == false) //(_user.CapNhatHoSo==false)
                    {    // 20/11/2020 ko cho phép chỉnh sửa khi ko có quyền
                        txtMaQuanLy.ReadOnly = true; txtTen.ReadOnly = true; txtThoiGianSuDungToiThieu.ReadOnly = true;
                        cmb_TaiKhoan.ReadOnly = true; cmb_TaiKhoanKhauHaoLuyKe.ReadOnly = true; txtMaChiPhiKeToan.ReadOnly = true;
                    }
                }
                else if (obj.LaTaiSanCoDinh == true)
                {
                    //hiện các control của tài sản cố định
                    ControlUtil.ShowControl_LayoutGroup(new LayoutControlItem[] { layoutMa, layoutTen, layoutDVT, layoutNuocSX, layoutTGSuDung, layoutThang, layoutTKNG, layoutTKKHLuyKe, layoutMaPhiKeToan });
                    // cho phép người dùng nhập 20/11/2020
                    txtTen.ReadOnly = false; txtThoiGianSuDungToiThieu.ReadOnly = false; cmb_TaiKhoan.ReadOnly = false; cmb_TaiKhoanKhauHaoLuyKe.ReadOnly = false; txtMaChiPhiKeToan.ReadOnly = false;
                    if (CurrentUser.Info.GroupID == 1002) //(_user.GroupID == 1002) // chặn nhóm mua hàng 
                    {
                        txtMaQuanLy.ReadOnly = true; cmb_TaiKhoan.ReadOnly = true; cmb_TaiKhoanKhauHaoLuyKe.ReadOnly = true; txtThoiGianSuDungToiThieu.ReadOnly = true;
                        txtMaChiPhiKeToan.ReadOnly = true;
                    }
                }
                //ẩn hiện các nút thêm
                {
                    //hiện các nút cần thiết
                    if (obj.LaNhomTaiSan == true)
                    {
                        //hiện nút thêm loại _user.CapNhatHoSo == true
                        if (CurrentUser.Info.CapNhatHoSo == true || _userID == 39 || _tenDangNhap.ToLower() == "admin")
                        {
                            btnThemLoai.Visible = true;
                        }
                        btnThemLoai.Text = String.Format("Loại tài sản vào nhóm [{0}]", obj.Ten);
                    }
                    else if (obj.LaLoaiTaiSan == true)
                    {
                        //hiện nút thêm tài sản cố định  (_user.CapNhatHoSo == true
                        if (CurrentUser.Info.CapNhatHoSo == true || _userID == 39 || _tenDangNhap.ToLower() == "admin")
                        {
                            btnThemLoai.Visible = true;
                            btnXoaTrenCay.Visible = true;
                        }
                        btnThemLoai.Text = String.Format("Loại tài sản vào loại [{0}]", obj.Ten);
                        btnThemTaiSanCoDinh.Visible = true;
                        btnThemTaiSanCoDinh.Text = String.Format("Tài sản cố định vào loại [{0}]", obj.Ten);
                    }
                    else if (obj.LaTaiSanCoDinh == true)
                    {
                        //hiện nút thêm loại
                        if (_userID == 39 || _tenDangNhap.ToLower() == "admin")
                        {
                            btnXoaTrenCay.Visible = true;
                        }
                        if (obj.MaCongTy == _maCongTy)
                        {
                            btnXoaTrenCay.Visible = true;
                        }
                        //btn_nhapTaiSanCoDinhCu.Visible = true;
                        btn_nhapTaiSanCoDinhCu.Text = String.Format("Nhập tài sản cố định cá biệt cho tài sản {0}", obj.Ten);
                    }
                }
                //clear danh sách tài sản cá biệt
                tblTaiSanCoDinhCaBietBindingSource.DataSource = null;
                //clear danh sách tài sản cá biệt new 
                _dt_TaiSanCoDinhCaBiet = null;
                grdTaiSanCoDinhCaBiet.DataSource = _dt_TaiSanCoDinhCaBiet;
                //đếm số tài sản cá biệt
                #region Đếm số tài sản cá biệt
                //{
                //    TaiSanCoDinhCaBiet_Factory taiSanCoDinhCaBiet_Factory = TaiSanCoDinhCaBiet_Factory.New();
                //    if (obj.LaNhomTaiSan == true)
                //    {
                //        Int32 count = taiSanCoDinhCaBiet_Factory.Count_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaNhomTaiSan(obj.ID);
                //        if (count > 0)
                //            grdViewTaiSanCoDinhCaBiet.GroupPanelText = String.Format("Có {0} tài sản cá biệt thuộc nhóm [{1}]", count, obj.Ten);
                //        else
                //            grdViewTaiSanCoDinhCaBiet.GroupPanelText = "";
                //    }
                //    else if (obj.LaLoaiTaiSan == true)
                //    {
                //        Int32 count = taiSanCoDinhCaBiet_Factory.Count_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaLoaiTaiSan(obj.ID);
                //        if (count > 0)
                //            grdViewTaiSanCoDinhCaBiet.GroupPanelText = String.Format("Có {0} tài sản cá biệt thuộc loại [{1}]", count, obj.Ten);
                //        else
                //            grdViewTaiSanCoDinhCaBiet.GroupPanelText = "";
                //    }
                //    else if (obj.LaTaiSanCoDinh == true)
                //    {
                //        Int32 count = taiSanCoDinhCaBiet_Factory.Count_DanhSachTaiSanCoDinhCaBiet_ChuaThanhLy_ByMaTSCD(obj.ID);
                //        if (count > 0)
                //            grdViewTaiSanCoDinhCaBiet.GroupPanelText = String.Format("Có {0} tài sản cá biệt thuộc tài sản [{1}]", count, obj.Ten);
                //        else
                //            grdViewTaiSanCoDinhCaBiet.GroupPanelText = "";
                //    }
                //    else
                //    {
                //        grdViewTaiSanCoDinhCaBiet.GroupPanelText = "";
                //    }
                //}
                #endregion Đếm số tài sản cá biệt
            }
        }
        private bool validData()
        {
            bool kq = true;
            if (txtTen.Text.Length == 0)
            {
                kq = false;
                MessageBox.Show("Tên Tài Sản Không Để Trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTen.Focus();
            }

            return kq;
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if(validData())
            // clear filter
            treeList1.ActiveFilterCriteria = null;
            this.Save();

        }
        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            ThemLenCay(themLoai: true);
        }

        private void btnThemTaiSanCoDinh_Click(object sender, EventArgs e)
        {
            ThemLenCay(themTSCD: true);
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void btnXoaTrenCay_Click(object sender, EventArgs e)
        {
            tblDanhMucTSCD obj = tblDanhMucTSCDBindingSource.Current as tblDanhMucTSCD;
            if (KiemTraTSTruocKhiXoa(obj) == true)
            {
                //xóa node
                if (DialogResult.Yes == XtraMessageBox.Show("<b>Bạn có muốn xóa dòng được chọn?</b> \n- Mã: <color=red>" + obj.MaQuanLy + "</color>" + " \n - Tên: <color=red>" + obj.Ten + "</color>", "XÁC NHẬN XÓA", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, DevExpress.Utils.DefaultBoolean.True))
                {
                    treeList1.DeleteSelectedNodes();
                }

            }
        }
        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txtFilterTree.Text.Trim() != "")
                this.FillterTree();
            else
                this.LoadData();
        }
        private void txtFilterTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                FillterTree();
        }
        private void btnXuatExcelCayTaiSan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //TreeListNode focusedNode = treeList1.FocusedNode;//C
            //tblDanhMucTSCD currentObject = GetObject_AtNode(focusedNode);//C
            //_danhMucTSCDList = _danhMucTSCD_Factory.Get_DanhSachTaiSanTheoMaCongTy(_maCongTy);
            //this.tblDanhMucTSCDBindingSource.DataSource = _danhMucTSCDList;
            //treeList1.ExpandAll();
            _danhMucTSCDList = tblDanhMucTSCDBindingSource.DataSource as IQueryable<tblDanhMucTSCD>;
            foreach (tblDanhMucTSCD danhMuc in _danhMucTSCDList)
            {
                if (danhMuc.LaTaiSanCoDinh == false)                
                    danhMuc.LaTaiSanCoDinh = null;                
            }

            treeList1.ExpandAll();
            this.tblDanhMucTSCDBindingSource.DataSource = _danhMucTSCDList;
            //xuất excel cây danh mục
            TreeUtils.ExportToExcel(treeList: treeList1, showOpenFilePrompt: true);
        }

        private void btnXuatExcelDanhSachTaiSanCaBiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //xuất excel danh sách tài sản cá biệt
            GridUtil.ExportToExcel(gridView: this.grdViewTaiSanCoDinhCaBiet, showOpenFilePrompt: true);
        }
        #endregion

        private void frmCayTaiSan_FormClosing(object sender, FormClosingEventArgs e)
        {
            txtBlackHole.Focus();
            if (_danhMucTSCD_Factory.IsDirty)
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

        private void btn_nhapTaiSanCoDinhCu_Click(object sender, EventArgs e)
        {
            tblDanhMucTSCD obj = tblDanhMucTSCDBindingSource.Current as tblDanhMucTSCD;
            frmNhapTaiSanCoDinhCaBietCu frm = null;
            do
            {
                frm = new frmNhapTaiSanCoDinhCaBietCu(obj, false);
                frm.ShowDialog();
                btnDocDanhSachTaiSanCoDinhCaBiet_ItemClick(sender, null);
            }
            while (frm._nhapTiep && frm.DialogResult == DialogResult.Yes);
        }

        private void btn_ImportTSCDCB_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImportTSCD.ImportTSCDCaBietNew(true);
        }

        private void btn_XoaToanBoDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dlg = DialogUtil.ShowYesNo("Bạn có muốn xóa toàn bộ data để import lại từ đầu?\nChú ý tất cả nghiệp vụ phát sinh đều phải làm lại!\nBạn nên suy nghĩ kỹ!");
            if (dlg == DialogResult.Yes)
            {
                try
                {
                    if (TaiSanCoDinhCaBiet_Factory.New().Context.spd_TSCD_KiemTraNghiepVuGhiTang().Count() > 0)
                    {
                        if (CurrentUser.Info.TenDangNhap.ToLower() == "admin")
                        {
                            if (TaiSanCoDinhCaBiet_Factory.New().Context.spd_TSCD_Delete_DuLieuImportLaiTuDau(true) > 0)
                            {
                                DialogUtil.ShowInfo("Xóa thành công!\nVui lòng import lại dữ liệu!");
                            }
                        }
                        else
                        {
                            DialogUtil.ShowWarning("Đã phát sinh nghiệp vụ ghi tăng tài sản mới!\nBạn không có quyền xóa!\nVui lòng liên hệ admin để xóa dữ liệu!");
                        }
                    }
                    else
                    {
                        if (TaiSanCoDinhCaBiet_Factory.New().Context.spd_TSCD_Delete_DuLieuImportLaiTuDau(false) > 0)
                        {
                            DialogUtil.ShowInfo("Xóa thành công!\nVui lòng import lại dữ liệu!");
                            btnRefresh_ItemClick(sender, e);
                        }
                    }
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowError("Lỗi hệ thống!\n" + ex.Message + "\n" + ex.InnerException);
                }
            }
        }

        private void btn_ImportCCDC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ImportTSCD.ImportTSCDCaBiet(false);
        }

        private void cbDonViTinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//danh sách đơn vị tính
            {
                frmListDonViTinh frm = new frmListDonViTinh();
                frm.ShowDialog();
                _donViTinhList = DonViTinh_Factory.New().GetAll().ToList();
                tblDonViTinhBindingSource.DataSource = _donViTinhList;
            }
        }

        private void cbNuocSanXuat_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)//danh sách quốc gia
            {
                frmListQuocGia frm = new frmListQuocGia();
                frm.ShowDialog();
                _quocGiaList = QuocGia_Factory.New().GetAll().ToList();
                tblQuocGiaBindingSource.DataSource = _quocGiaList;
            }
        }

        private void treeList1_MouseDown(object sender, MouseEventArgs e)
        {// click chuột phải vào dòng bất kỳ sẽ tự Focus đến
            TreeList tree = sender as TreeList;
            TreeListHitInfo hitInfo = tree.CalcHitInfo(e.Location);
            if (e.Button == MouseButtons.Right && hitInfo.HitInfoType == HitInfoType.Cell)
                hitInfo.Node.Selected = !hitInfo.Node.Selected;
        }

        private void btnBieuMauNhapLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.AddExtension = true;
                dlg.Filter = "Excel|*.xls|All file|*.*";
                dlg.FileName = "Mau_import_AMS_VLU";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    //tạo file template
                    FileStream fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    fs.Write(PSC_ERP.Properties.Resources.Mau_import_AMS_VLU, 0, PSC_ERP.Properties.Resources.Mau_import_AMS_VLU.Length);
                    fs.Close();

                    MessageBox.Show("Đã xuất dữ liệu thành công.", "Xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start(dlg.FileName);
                }
            }
            catch (Exception ex)
            {
                DialogUtil.ShowError("Export không thành công!\n" + ex.Message);

            }
        }
    }
}