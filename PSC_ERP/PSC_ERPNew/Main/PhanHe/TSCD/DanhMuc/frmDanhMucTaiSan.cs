using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common;
using DevExpress.XtraGrid.Views.Grid;

namespace PSC_ERPNew.Main
{
    public partial class frmDanhMucTaiSan : DevExpress.XtraEditors.XtraForm
    {
        //Singleton
        #region Singleton
        private static frmDanhMucTaiSan singleton_ = null;
        public static frmDanhMucTaiSan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDanhMucTaiSan();
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
        DanhMucTSCD_Factory _mainFactory = DanhMucTSCD_Factory.New();
        IQueryable<tblDanhMucTSCD> _danhMucTSCDList_ForFilter = null;
        IQueryable<tblDanhMucTSCD> _danhMucTSCDList_TheoLoai = null;
        Boolean _yeuCauTaoMoiTaiSanKhiFormLoad = false;
        Int32 _maLoaiTaiSan_GoiVao = 0;
        List<tblTaiKhoan> _taiKhoanList = null;
        #endregion

        //Member Constructor
        #region Member Constructor

        public frmDanhMucTaiSan()
        {
            InitializeComponent();
            _yeuCauTaoMoiTaiSanKhiFormLoad = false;
        }
        public frmDanhMucTaiSan(Int32 maLoaiTaiSan)
        {
            InitializeComponent();
            _maLoaiTaiSan_GoiVao = maLoaiTaiSan;
            this.WindowState = FormWindowState.Maximized;
        }
        //public frmDanhMucTaiSan(Boolean taoMoi)
        //{
        //    InitializeComponent();
        //    _yeuCauTaoMoiTaiSanKhiFormLoad = taoMoi;
        //}

        #endregion

        //Private Member Function
        #region Private Member Function

        private Boolean Save()
        {
            this.txtBlackHole.Focus();
            if (DuocPhepLuu())
                try
                {
                    _mainFactory.SaveChangesWithoutTrackingLog();
                    //_mainFactory.SaveChanges();//lưu lại
                    //
                    DialogUtil.ShowSaveSuccessful();
                    return true;
                }
                catch (Exception ex)
                {
                    DialogUtil.ShowNotSaveSuccessful();
                }
            return true;

        }
        private Boolean DuocPhepLuu()
        {
            Boolean duocPhepLuu = true;

            return duocPhepLuu;
        }
        #endregion

        //Event Method
        #region Event Method
        private void frmDanhMucTaiSan_Load(object sender, EventArgs e)
        {
            this.Shown += (object senderz, EventArgs ez) =>
           {
               //this.DialogResult = DialogResult.Yes;
               //lấy danh sách nhóm và loại cho filter combo
               _danhMucTSCDList_ForFilter = _mainFactory.Get_DanhSachNhomLoaiTaiSan();
               tblDanhMucTSCDBindingSource_forTreeLookup.DataSource = _danhMucTSCDList_ForFilter;
               cbLoaiTaiSan_ForFilter.EditValue = _maLoaiTaiSan_GoiVao;
               //lấy danh sách TSCD trực tiếp của loại tài sản
               _danhMucTSCDList_TheoLoai = _mainFactory.Get_DanhSachTaiSanCoDinh_TrucTiep_ByMaLoaiTaiSan(_maLoaiTaiSan_GoiVao);
               tblDanhMucTSCDBindingSource.DataSource = _danhMucTSCDList_TheoLoai;

               //lấy danh sách đơn vị tính
               List<tblDonViTinh> donViTinhList = DonViTinh_Factory.New().GetAll().ToList();
               tblDonViTinh dvt_khongChon = new tblDonViTinh() { MaDonViTinh = 0, MaQuanLy = "<<Không chọn>>", TenDonViTinh = "<<Không chọn>>" };
               donViTinhList.Insert(0, dvt_khongChon);
               this.tblDonViTinhBindingSource.DataSource = donViTinhList;

               //lấy danh sách quốc gia
               List<tblQuocGia> quocGiaList = QuocGia_Factory.New().GetAll().ToList();
               tblQuocGia quocGia_khongChon = new tblQuocGia() { MaQuocGia = 0, MaQuocGiaQuanLy = "<<Không chọn>>", TenQuocGia = "<<Không chọn>>" };
               quocGiaList.Insert(0, quocGia_khongChon);
               this.tblQuocGiaBindingSource.DataSource = quocGiaList;
               //tài khoản
               _taiKhoanList = TaiKhoan_Factory.New().GetAll().ToList();
               tblTaiKhoan taiKhoan_khongChon = new tblTaiKhoan() { MaTaiKhoan = 0, SoHieuTK = "<<Không chọn>>", TenTaiKhoan = "<<Không chọn>>" };
               _taiKhoanList.Insert(0, taiKhoan_khongChon);
               this.tblTaiKhoan_BindingSource.DataSource = _taiKhoanList;
               //STT
               GridUtil.SetSTTForGridView(this.grdViewDanhMucTSCD);
               //cài đặt delete helper
               GridUtil.DeleteHelper.Setup_ManualType(grdViewDanhMucTSCD, (GridView gridView, List<Object> deleteList) =>
               {
                   DanhMucTSCD_Factory.FullDelete(context: _mainFactory.Context, deleteList: deleteList);
               });
           };
            
        }
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Boolean duocPhepThemMoi = true;
            foreach (tblDanhMucTSCD currentObject in tblDanhMucTSCDBindingSource)
            {
                if (currentObject.ID == 0)
                {
                    if (DialogResult.Yes == DialogUtil.ShowYesNo("Lưu lại thay đổi cũ trước khi thêm mới?"))
                    {
                        if (this.Save())
                            duocPhepThemMoi = true;
                        else
                            duocPhepThemMoi = false;
                    }
                }
            }
            if (duocPhepThemMoi)
            {
                tblDanhMucTSCD parentObject = cbLoaiTaiSan_ForFilter.GetSelectedDataRow() as tblDanhMucTSCD;

                tblDanhMucTSCD newObj = _mainFactory.CreateManagedObject();
                newObj.LaTaiSanCoDinh = true;
                newObj.ParentID = parentObject.ID;
                newObj.UserID = PSC_ERP_Global.Main.UserID;
                newObj.TGSuDungToiTHieuTSCD = parentObject.TGSuDungToiTHieuTSCD;
                newObj.TaiKhoanTuongUng = parentObject.TaiKhoanTuongUng;
                newObj.TGSuDungToiDaTSCD = 5;
                //phát sinh số hiệu mới
                {
                    Int32 sizeOfIncreasePart = PSC_ERP_Global.TSCD.SizeOf_MaTSCDQuanLy_IncreasePart;
                    //xác định size
                    //

                    String soHieuMoi = "";
                    Int32 maxNum = 0;
                    String soHieuCapTren = parentObject.MaQuanLy;
                    String maxSoHieu = _mainFactory.Get_MaxSoHieuTSCD_ByMaLoaiCapTrenTrucTiep(parentObject.ID);
                    if (!String.IsNullOrWhiteSpace(maxSoHieu))
                    {
                        maxNum = Int32.Parse(maxSoHieu.Substring(maxSoHieu.Length - sizeOfIncreasePart));
                    }

                    if (maxNum == 0) //số hiệu đầu tiên
                        soHieuMoi = _mainFactory.CreateFirst_MaQuanLyTSCD(soHieuCapTren);
                    else//số hiệu tiếp theo
                        soHieuMoi = _mainFactory.Create_MaQuanLyTSCD(soHieuCapTren, maxNum + 1);
                    newObj.MaQuanLy = soHieuMoi;
                }
                //đưa vào danh sách
                tblDanhMucTSCDBindingSource.Add(newObj);
                tblDanhMucTSCDBindingSource.MoveLast();
            }

        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Save();
        }

        private void frmDanhMucTaiSan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_mainFactory.IsDirty)
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
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            //yêu cầu người dùng xác nhận xóa
            DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn muốn xóa những dòng đang chọn?");
            if (dlgResult == DialogResult.Yes)
            {
                try
                {
                    Int32[] rowHandleList = this.grdViewDanhMucTSCD.GetSelectedRows();
                    if (rowHandleList.Count() > 0)
                    {
                        List<Object> deleteList = new List<Object>();
                        foreach (var index in rowHandleList)
                        {
                            deleteList.Add(this.grdViewDanhMucTSCD.GetRow(index));
                        }
                        //
                        DanhMucTSCD_Factory.FullDelete(context: _mainFactory.Context, deleteList: deleteList.ToList<Object>());
                    }
                }
                catch (Exception ex)
                {
                    //thông báo không xóa được
                    DialogUtil.ShowError("Không thể xóa những dòng đang chọn!");
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void cbLoaiTaiSan_ForFilter_EditValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiTaiSan_ForFilter.EditValue != null && Convert.ToInt32(cbLoaiTaiSan_ForFilter.EditValue) != 0)
            {
                tblDanhMucTSCD loai = cbLoaiTaiSan_ForFilter.GetSelectedDataRow() as tblDanhMucTSCD;
                txtTenLoaiTaiSan.Text = loai.Ten;
                //Int32 maLoai = Convert.ToInt32(cbLoaiTaiSan_ForFilter.EditValue);
                _mainFactory = DanhMucTSCD_Factory.New();
                _danhMucTSCDList_TheoLoai = _mainFactory.Get_DanhSachTaiSanCoDinh_TrucTiep_ByMaLoaiTaiSan(loai.ID);
                tblDanhMucTSCDBindingSource.DataSource = _danhMucTSCDList_TheoLoai;
            }
        }

        #endregion

        private void grdDanhMucTSCD_Click(object sender, EventArgs e)
        {
        }

    }
}