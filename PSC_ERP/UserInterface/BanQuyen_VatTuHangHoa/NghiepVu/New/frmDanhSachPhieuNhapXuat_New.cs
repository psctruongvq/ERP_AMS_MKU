using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Diagnostics;
using System.IO;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using ERP_Library.Security;

namespace PSC_ERP
{
    //23/04/2013
    public partial class frmDanhSachPhieuNhapXuat_New : DevExpress.XtraEditors.XtraForm
    {
        PhieuNhapXuatList _phieuNhapXuatList = PhieuNhapXuatList.NewPhieuNhapXuatList();
        bool _laNhap;
        int _loaiPhieu;
        int _kieu = 1;
        PhieuNhapXuat _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
        long _maPhieuNhapXuat = 0;
        int _maPhongBan = 0;
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        // add 10/03/2021
        List<tblnsBoPhan> _BoPhanList = null;
        int _maCongTy = CurrentUser.Info.MaCongTy;
        #region An Hien BtnXoa
        void HidebtnXoa()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        void ShowbtnXoa()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        #endregion//An Hien BtnXoa
        //
        public PhieuNhapXuat PhieuNhapXuat
        {
            get { return _phieuNhapXuat; }
        }

        public frmDanhSachPhieuNhapXuat_New()
        {
            InitializeComponent();

        }

        public frmDanhSachPhieuNhapXuat_New(bool laNhap, int loaiPhieu)
        {
            InitializeComponent();
            _laNhap = laNhap;
            _loaiPhieu = loaiPhieu;
            _kieu = 2;
            UserId = 0;
            btnPrint.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            HidebtnXoa();
            KhoiTao();
        }

        public void ShowPhieuNhapBanQuyen()
        {
            KhoiTao();
            _laNhap = true;
            _loaiPhieu = 1;
            this.Text = "Danh sách phiếu nhập bản quyền";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuXuatBanQuyen()
        {
            KhoiTao();
            _laNhap = false;
            _loaiPhieu = 1;
            this.Text = "Danh sách phiếu xuất bản quyền";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuNhapVatTu()
        {
            KhoiTao();
            _laNhap = true;
            _loaiPhieu = 2;
            this.Text = "Danh sách phiếu nhập vật tư";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuXuatVatTu()
        {
            KhoiTao();
            _laNhap = false;
            _loaiPhieu = 2;
            this.Text = "Danh sách phiếu xuất vật tư";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuNhapPhanBoCCDC()
        {
            KhoiTao();
            _laNhap = true;
            _loaiPhieu = 3;
            this.Text = "Danh sách phiếu nhập công cụ dụng cụ";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuXuatPhanBoCCDC()
        {
            KhoiTao();
            _laNhap = false;
            _loaiPhieu = 3;
            this.Text = "Danh sách phiếu xuất PB công cụ dụng cụ";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuNhapBoSungGiaTri()
        {
            KhoiTao();
            _laNhap = true;
            _loaiPhieu = 4;
            this.Text = "Danh sách phiếu nhập bổ sung giá trị";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuXuatBoSungGiaTri()
        {
            KhoiTao();
            _laNhap = false;
            _loaiPhieu = 4;
            this.Text = "Danh sách phiếu xuất điều chỉnh giá trị";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuNhapDieuChinhTonKho()
        {
            KhoiTao();
            _laNhap = true;
            _loaiPhieu = 5;
            this.Text = "Danh sách phiếu nhập điều chỉnh tồn kho";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuXuatDieuChinhTonKho()
        {
            KhoiTao();
            _laNhap = false;
            _loaiPhieu = 5;
            this.Text = "Danh sách phiếu xuất điều chỉnh tồn kho";
            this.Show();
            HidebtnXoa();
        }

        public void ShowPhieuXuatNhienLieu()
        {
            KhoiTao();
            _laNhap = false;
            _loaiPhieu = 6;
            this.Text = "Danh sách phiếu xuất nhiên liệu";
            this.Show();
            HidebtnXoa();
        }
        public void ShowPhieuXuatVatTu_NhienLieu()
        {
            KhoiTao();
            _laNhap = false;
            _loaiPhieu = 0;
            this.Text = "Danh sách phiếu xuất vật tư và nhiên liệu";
            this.Show();
            HidebtnXoa();
        }

        private void KhoiTao()
        {

            _BoPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_maCongTy).ToList();
            tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _BoPhanList.Insert(0, boPhan_chonTatCa);
            boPhanListBindingSource.DataSource = _BoPhanList;


            //BoPhanList _BoPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            //BoPhan _BoPhan = BoPhan.NewBoPhan(0, "<<None>>");
            //_BoPhanList.Insert(0, _BoPhan);
            //boPhanListBindingSource.DataSource = _BoPhanList;

            KhoBQ_VTList _KhoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList();
            KhoBQ_VT _KhoBQ_VT = KhoBQ_VT.NewKhoBQ_VT();
            _KhoBQ_VT.TenKho = "<<None>>";
            _KhoBQ_VTList.Insert(0, _KhoBQ_VT);
            khoBQVTListBindingSource.DataSource = _KhoBQ_VTList;

            Init_lookUpEdit_PPNXKho();

            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;

            //boPhanListBindingSource1.DataSource = BoPhanList.GetBoPhanList();
            boPhanListBindingSource1.DataSource = _BoPhanList;
            thongTinNhanVienTongHopListBindingSource1.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            khoBQVTListBindingSource1.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListByTen(0);

            // load nhân viên theo phòng ban 
            ThongTinNhanVienTongHopList _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ByBophan(0);
            ThongTinNhanVienTongHop nhanVien = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<<None>>");
            _ThongTinNhanVienTongHopList.Insert(0, nhanVien);
            thongTinNhanVienTongHopListBindingSource.DataSource = _ThongTinNhanVienTongHopList;
        }


        private void Init_lookUpEdit_PPNXKho()
        {
            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(0, "<<None>>");
            _dataTable.Rows.Add(1, "Bình Quân");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");

            phuongPhapNXbindingSource.DataSource = _dataTable;
            lookUpEdit_PPNXKho.Properties.DataSource = phuongPhapNXbindingSource;
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.Properties.NullText = "<<None>>";
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm frm = new XtraForm();
            if (_loaiPhieu == 1 && _laNhap == true)
            {
                frm = new frmPhieuNhapBanQuyen_New();
            }
            else if (_loaiPhieu == 1 && _laNhap == false)
            {
                frm = new FrmPhieuXuatBanQuyen_New();
            }
            else if (_loaiPhieu == 2 && _laNhap == true)
            {
                frm = new frmPhieuNhapVatTuHangHoa_New();
            }
            else if (_loaiPhieu == 2 && _laNhap == false)
            {
                frm = new FrmPhieuXuatVatTuHangHoa_New();
            }
            else if (_loaiPhieu == 3 && _laNhap == true)
            {
                frm = new frmPhieuNhapCongCuDungCu_New();
            }
            else if (_loaiPhieu == 3 && _laNhap == false)
            {
                frm = new frmPhieuXuatPhanBoCCDC_New();
            }
            else if (_loaiPhieu == 4 && _laNhap == true)
            {
                frm = new frmPhieuNhapBoSungGiaTri_New();
            }
            else if (_loaiPhieu == 4 && _laNhap == false)
            {
                frm = new frmPhieuXuatBoSungGiaTri_New();
            }
            else if (_loaiPhieu == 5 && _laNhap == true)
            {
                frm = new frmPhieuNhapDieuChinh_New(_laNhap);
            }
            else if (_loaiPhieu == 5 && _laNhap == false)
            {
                frm = new frmPhieuNhapDieuChinh_New(_laNhap);
            }
            else if (_loaiPhieu == 6 && _laNhap == false)
            {
                frm = new FrmPhieuXuatNhienLieu_New();
            }
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                //if (checkEdit_Ngay.Checked == true)
                //{
                //    _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), Convert.ToDateTime(dtEdit_TuNgay.EditValue), Convert.ToDateTime(dtEdit_DenNgay.EditValue), _laNhap, _loaiPhieu, UserId);
                //}
                //else
                //{
                //    _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), _laNhap, _loaiPhieu, UserId);
                //}

                if (checkEdit_Ngay.Checked == true)
                {
                    _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_Tim("SearchByDate", Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _laNhap, _loaiPhieu, UserId);
                }
                else
                {
                    _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_Tim("SearchAll", Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _laNhap, _loaiPhieu, UserId);
                }
            }
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                _phieuNhapXuatList.ApplyEdit();
                _phieuNhapXuatList.Save();
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //if (checkEdit_Ngay.Checked == true)
            //{
            //    _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _laNhap, _loaiPhieu, UserId);
            //}
            //else
            //{
            //    _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), _laNhap, _loaiPhieu, UserId);
            //}

            if (checkEdit_Ngay.Checked == true)
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_Tim("SearchByDate",Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _laNhap, _loaiPhieu, UserId);
            }
            else
            {
                _phieuNhapXuatList = PhieuNhapXuatList.GetPhieuNhapXuatList_Tim("SearchAll", Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _laNhap, _loaiPhieu, UserId);
            }

            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
            if (_phieuNhapXuatList.Count == 0)//M
                MessageBox.Show("Danh Sách Phiếu rỗng!");
            
        }


        private void grd_DanhSachPhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            #region Key Delete
            //if (e.KeyCode == Keys.Delete)
            //{
            //    if (grdv_DanhSachPhieuNhapXuat.GetSelectedRows() == null)
            //        MessageBox.Show(this, "Chọn dòng muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    else
            //    {

            //        foreach (int i in grdv_DanhSachPhieuNhapXuat.GetSelectedRows())
            //        {
            //            //B
            //            PhieuNhapXuat pnx = _phieuNhapXuatList[i];
            //            if (pnx != null)
            //            {
            //                KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(pnx.NgayNX);
            //                if (khoa.Count > 0)//Kiem Tra Khoa so
            //                {
            //                    if (khoa[0].KhoaSo == true)
            //                    {
            //                        MessageBox.Show(this, "Đã khóa sổ, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                        return;
            //                    }
            //                }
            //                if (pnx.XacNhan == true)//Kiem Tra Thu Kho Xac Nhan
            //                {
            //                    MessageBox.Show(this, "Thủ kho đã xác nhận, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    return;
            //                }
            //                //
            //                if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(pnx.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
            //                {
            //                    MessageBox.Show("Phiếu Nhập đã Xuất!\n Vui lòng xóa Phiếu Xuất trước khi xóa Phiếu Nhập!");
            //                    return;
            //                }
            //            }
            //            //E
            //        }
            //        if (MessageBox.Show(this, "Bạn muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            //            grdv_DanhSachPhieuNhapXuat.DeleteSelectedRows();
            //    }

            //}
            #endregion //Key Delete
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grdv_DanhSachPhieuNhapXuat_DoubleClick(object sender, EventArgs e)
        {
            if (grdv_DanhSachPhieuNhapXuat.GetFocusedRow() != null)
            {
                PhieuNhapXuat phieuNhapXuat = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuNhapXuat;
                _phieuNhapXuat = PhieuNhapXuat.GetPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
                if (_kieu == 1)
                {
                    XtraForm frm = new XtraForm();
                    if (_phieuNhapXuat.LaNhap == true && _phieuNhapXuat.Loai == 1)
                    {
                        frm = new frmPhieuNhapBanQuyen_New(_phieuNhapXuat);
                    }
                    else if (_phieuNhapXuat.LaNhap == false && _phieuNhapXuat.Loai == 1)
                    {
                        frm = new FrmPhieuXuatBanQuyen_New(_phieuNhapXuat, 1);
                    }
                    else if (_phieuNhapXuat.LaNhap == true && _phieuNhapXuat.Loai == 2)
                    {
                        frm = new frmPhieuNhapVatTuHangHoa_New(_phieuNhapXuat);
                    }
                    else if (_phieuNhapXuat.LaNhap == false && _phieuNhapXuat.Loai == 2)
                    {
                        frm = new FrmPhieuXuatVatTuHangHoa_New(_phieuNhapXuat, 1);
                    }
                    else if (_phieuNhapXuat.LaNhap == true && _phieuNhapXuat.Loai == 3)
                    {
                        //frm = new frmNhapPhanBoCongCuDungCu(_phieuNhapXuat);
                        frm = new frmPhieuNhapCongCuDungCu_New(_phieuNhapXuat);
                    }
                    else if (_phieuNhapXuat.LaNhap == false && _phieuNhapXuat.Loai == 3)
                    {
                        frm = new frmPhieuXuatPhanBoCCDC_New(_phieuNhapXuat, 0);
                    }
                    else if (_phieuNhapXuat.LaNhap == true && _phieuNhapXuat.Loai == 4)
                    {
                        frm = new frmPhieuNhapBoSungGiaTri_New(_phieuNhapXuat);
                    }
                    else if (_phieuNhapXuat.LaNhap == false && _phieuNhapXuat.Loai == 4)
                    {
                        frm = new frmPhieuXuatBoSungGiaTri_New(_phieuNhapXuat);
                    }
                    else if (_phieuNhapXuat.Loai == 5)
                    {
                        frm = new frmPhieuNhapDieuChinh_New(_phieuNhapXuat);
                    }
                    else if (_phieuNhapXuat.LaNhap == false && _phieuNhapXuat.Loai == 6)
                    {
                        frm = new FrmPhieuXuatNhienLieu_New(_phieuNhapXuat);
                    }
                    //frm.ShowDialog();
                    if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        btn_Tim.PerformClick();
                    }//New
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            ThongTinNhanVienTongHopList _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            if (lookUpEdit_PhongBan.EditValue != null)
            {
                _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ByBophan((int)lookUpEdit_PhongBan.EditValue);
                ThongTinNhanVienTongHop nhanVien = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<<None>>");
                _ThongTinNhanVienTongHopList.Insert(0, nhanVien);
            }
            thongTinNhanVienTongHopListBindingSource.DataSource = _ThongTinNhanVienTongHopList;

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhapXuat pnx = (PhieuNhapXuat)phieuNhapXuatListBindingSource.Current;
            _maPhieuNhapXuat = pnx.MaPhieuNhapXuat;
            _maPhongBan = pnx.MaPhongBan;
            //
            if (pnx.Loai == 3 && pnx.LaNhap == true)//NHAP CCDC
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("SpdBienBanNhapCongCuDungCu");
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
                    frm.ShowDialog();
                }

            }
            else if (pnx.Loai == 3 && pnx.LaNhap == false)//xuat CCDC
            {

                //Rpt_BienBanGiaoNhanCongCuDungCu rpt = new Rpt_BienBanGiaoNhanCongCuDungCu(pnx.MaPhieuNhapXuat, pnx.MaPhongBan);
                //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
                //frm.WindowState = FormWindowState.Maximized;
                //frm.ShowDialog();
                //BEGIN
                ReportTemplate _report = ReportTemplate.GetReportTemplate("BienBanGiaoNhanCongCuDungCu");
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
                //END
            }
            if ((pnx.Loai == 1 || pnx.Loai == 4) && pnx.LaNhap == true)
            {
                //IN Phieu Nhap Ban Quyen
                //BEGIN
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuNhapBanQuyen");
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
                //END
            }
            if ((pnx.Loai == 1 || pnx.Loai == 4) && pnx.LaNhap == false)
            {
                //IN Phieu Xuat Ban Quyen 
                //BEGIN
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuXuatBanQuyen");
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
                //END
            }
            if ((pnx.Loai == 2 || pnx.Loai == 5) && pnx.LaNhap == true)
            {
                //IN Phieu Nhap Vat Tu
                //BEGIN
                ReportTemplate _report;
               
                #region Old phân biệt 2 mẫu: Bình quân và NXT
                //if (pnx.PhuongPhapNX == 2)//IF la Xuat Thang
                //{
                //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu_XuatThang");
                //}
                //else//IF la Xuat Binh Quan
                //{
                //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
                //}
                #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

                #region Modify Chỉ dùng 1 mẫu
                _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
                #endregion//Modify Chỉ dùng 1 mẫu


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
                //END
            }
            if (((pnx.Loai == 2 || pnx.Loai == 5) && pnx.LaNhap == false) || pnx.Loai == 6)
            {
                //IN Phieu Xuat Vat Tu if Loai=2
                //IN Phieu Xuat Nhien Lieu if Loai=6
                //BEGIN
                ReportTemplate _report;
                
                #region Old phân biệt 2 mẫu: Bình quân và NXT
                //if (pnx.PhuongPhapNX == 2)//IF la Xuat Thang
                //{
                //    _report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
                //}
                //else//IF la Xuat Binh Quan
                //{
                //    _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
                //}
                #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

                #region Modify Chỉ dùng 1 mẫu
                _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
                #endregion//Modify Chỉ dùng 1 mẫu


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
                //END
            }



        }
        #region Cac Ham cho RePort
        public void SpdBienBanNhapCongCuDungCu()//c
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SpdBienBanNhapCongCuDungCu";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BienBanGiaoNhanCongCuDungCu;1";
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

            }
        }
        public void Spd_PhieuXuatBanQuyen()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuXuatBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuXuatBanQuyen";
                    cm.Parameters.AddWithValue("@MaPhieuXuat", _maPhieuNhapXuat);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuXuatBanQuyen;1";
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
        }//END Spd_PhieuXuatBanQuyen

        public void Spd_PhieuNhapBanQuyen()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapBanQuyen
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuNhapBanQuyen";
                    cm.Parameters.AddWithValue("@MaPhieuNhap", _maPhieuNhapXuat);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuNhapBanQuyen;1";
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
        }//END Spd_PhieuNhapBanQuyen

        public void Spd_PhieuXuatVatTu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuXuatVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuXuatVatTu";
                    cm.Parameters.AddWithValue("@MaPhieuXuatVTHH", _maPhieuNhapXuat);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_PhieuXuatVatTu;1";
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
        }//END Spd_PhieuXuatVatTu

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
                    cm.Parameters.AddWithValue("@MaPhieuNhap", _maPhieuNhapXuat);

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
        ///
        public void Spd_BienBanGiaoNhanCongCuDungCu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_BienBanGiaoNhanCongCuDungCu";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);

                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "Spd_BienBanGiaoNhanCongCuDungCu;1";
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
        }

        #endregion//END Cac Ham cho RePort

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (grdv_DanhSachPhieuNhapXuat.GetSelectedRows() == null)
                MessageBox.Show(this, "Chọn dòng muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {

                foreach (int i in grdv_DanhSachPhieuNhapXuat.GetSelectedRows())
                {
                    //B
                    PhieuNhapXuat pnx = _phieuNhapXuatList[i];
                    if (pnx != null)
                    {
                        KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(pnx.NgayNX);
                        if (khoa.Count > 0)//Kiem Tra Khoa so
                        {
                            if (khoa[0].KhoaSo == true)
                            {
                                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        if (pnx.XacNhan == true)//Kiem Tra Thu Kho Xac Nhan
                        {
                            MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //
                        if (PhieuNhapXuat.KiemTraPhieuNhapDaXuatThang(pnx.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
                        {
                            MessageBox.Show("Phiếu Nhập đã Xuất!\n Vui lòng xóa Phiếu Xuất trước khi xóa Phiếu Nhập!");
                            return;
                        }
                    }
                    //E
                }
                if (MessageBox.Show(this, "Bạn muốn xóa dữ liệu này", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    grdv_DanhSachPhieuNhapXuat.DeleteSelectedRows();
            }

        }

        private void frmDanhSachPhieuNhapXuat_Load(object sender, EventArgs e)
        {
            grdv_DanhSachPhieuNhapXuat.OptionsBehavior.Editable = false;//M
            Utils.GridUtils.SetSTTForGridView(grdv_DanhSachPhieuNhapXuat, 35);//M
            dtEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
            dtEdit_DenNgay.EditValue = (object)DateTime.Today.Date;
        }

        private void LookUpEdit_Kho_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                LookUpEdit gridLUE = sender as LookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void LookUpEdit_NhanVienNhan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                LookUpEdit gridLUE = sender as LookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void btn_XuatRaExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                grdv_DanhSachPhieuNhapXuat.ExportToXls(dlg.FileName);
                OpenFile(dlg.FileName);
            }

        }

        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void GridLookUpEdit_PhongBan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void GridLookUpEdit_DoiTac_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void btnPrintVie_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhapXuat pnx = (PhieuNhapXuat)phieuNhapXuatListBindingSource.Current;
            _maPhieuNhapXuat = pnx.MaPhieuNhapXuat;
            _maPhongBan = pnx.MaPhongBan;
            //
            if (pnx.Loai == 3 && pnx.LaNhap == true)//NHAP CCDC
            {
                ReportTemplate _report = ReportTemplate.GetReportTemplate("SpdBienBanNhapCongCuDungCu");
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
                    frm.ShowDialog();
                }

            }
            else if (pnx.Loai == 3 && pnx.LaNhap == false)//xuat CCDC
            {

                //Rpt_BienBanGiaoNhanCongCuDungCu rpt = new Rpt_BienBanGiaoNhanCongCuDungCu(pnx.MaPhieuNhapXuat, pnx.MaPhongBan);
                //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
                //frm.WindowState = FormWindowState.Maximized;
                //frm.ShowDialog();
                //BEGIN
                ReportTemplate _report = ReportTemplate.GetReportTemplate("BienBanGiaoNhanCongCuDungCu");
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
                //END
            }
            if ((pnx.Loai == 1 || pnx.Loai == 4) && pnx.LaNhap == true)
            {
                //IN Phieu Nhap Ban Quyen
                //BEGIN
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuNhapBanQuyen");
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
                //END
            }
            if ((pnx.Loai == 1 || pnx.Loai == 4) && pnx.LaNhap == false)
            {
                //IN Phieu Xuat Ban Quyen 
                //BEGIN
                ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuXuatBanQuyen");
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
                //END
            }
            if ((pnx.Loai == 2 || pnx.Loai == 5) && pnx.LaNhap == true)
            {
                //IN Phieu Nhap Vat Tu
                //BEGIN
                ReportTemplate _report;

                #region Old phân biệt 2 mẫu: Bình quân và NXT
                //if (pnx.PhuongPhapNX == 2)//IF la Xuat Thang
                //{
                //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu_XuatThang");
                //}
                //else//IF la Xuat Binh Quan
                //{
                //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
                //}
                #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

                #region Modify Chỉ dùng 1 mẫu
                _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
                #endregion//Modify Chỉ dùng 1 mẫu


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
                //END
            }
            if (((pnx.Loai == 2 || pnx.Loai == 5) && pnx.LaNhap == false) || pnx.Loai == 6)
            {
                //IN Phieu Xuat Vat Tu if Loai=2
                //IN Phieu Xuat Nhien Lieu if Loai=6
                //BEGIN
                ReportTemplate _report;

                #region Old phân biệt 2 mẫu: Bình quân và NXT
                //if (pnx.PhuongPhapNX == 2)//IF la Xuat Thang
                //{
                //    _report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
                //}
                //else//IF la Xuat Binh Quan
                //{
                //    _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
                //}
                #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

                #region Modify Chỉ dùng 1 mẫu
                _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
                #endregion//Modify Chỉ dùng 1 mẫu


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
                //END
            }
        }

        private void btnPrintEng_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhapXuat pnx = (PhieuNhapXuat)phieuNhapXuatListBindingSource.Current;
            _maPhieuNhapXuat = pnx.MaPhieuNhapXuat;
            _maPhongBan = pnx.MaPhongBan;
            //
            //if (pnx.Loai == 3 && pnx.LaNhap == true)//NHAP CCDC
            //{
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("SpdBienBanNhapCongCuDungCu");
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();

            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = UserId;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.ShowDialog();
            //    }

            //}
            //else if (pnx.Loai == 3 && pnx.LaNhap == false)//xuat CCDC
            //{

            //    //Rpt_BienBanGiaoNhanCongCuDungCu rpt = new Rpt_BienBanGiaoNhanCongCuDungCu(pnx.MaPhieuNhapXuat, pnx.MaPhongBan);
            //    //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
            //    //frm.WindowState = FormWindowState.Maximized;
            //    //frm.ShowDialog();
            //    //BEGIN
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("BienBanGiaoNhanCongCuDungCu");
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();


            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = UserId;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.Show();
            //    }
            //    //END
            //}
            //if ((pnx.Loai == 1 || pnx.Loai == 4) && pnx.LaNhap == true)
            //{
            //    //IN Phieu Nhap Ban Quyen
            //    //BEGIN
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuNhapBanQuyen");
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();


            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = UserId;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.Show();
            //    }
            //    //END
            //}
            //if ((pnx.Loai == 1 || pnx.Loai == 4) && pnx.LaNhap == false)
            //{
            //    //IN Phieu Xuat Ban Quyen 
            //    //BEGIN
            //    ReportTemplate _report = ReportTemplate.GetReportTemplate("PhieuXuatBanQuyen");
            //    if (_report != null)
            //    {
            //        DateTime dtDenNgay = DateTime.Today;
            //        frmReport frm = new frmReport();


            //        ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
            //        if (_reportTemplate.Id == string.Empty)
            //        {
            //            _reportTemplate.Id = _report.Id;
            //            _reportTemplate.UserID = UserId;
            //            _reportTemplate.DenNgay = dtDenNgay;
            //        }
            //        if (_report.TenPhuongThuc != "")
            //        {
            //            this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
            //        }

            //        frm.HienThiReport(_reportTemplate, dataSet);
            //        frm.Show();
            //    }
            //    //END
            //}
            if ((pnx.Loai == 2 || pnx.Loai == 5) && pnx.LaNhap == true)
            {
                //IN Phieu Nhap Vat Tu
                //BEGIN
                ReportTemplate _report;

                #region Old phân biệt 2 mẫu: Bình quân và NXT
                //if (pnx.PhuongPhapNX == 2)//IF la Xuat Thang
                //{
                //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu_XuatThang");
                //}
                //else//IF la Xuat Binh Quan
                //{
                //    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
                //}
                #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

                #region Modify Chỉ dùng 1 mẫu
                _report = ReportTemplate.GetReportTemplate("IDReport_PhieuNhapVatTu");
                #endregion//Modify Chỉ dùng 1 mẫu


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
                //END
            }
            if (((pnx.Loai == 2 || pnx.Loai == 5) && pnx.LaNhap == false) || pnx.Loai == 6)
            {
                //IN Phieu Xuat Vat Tu if Loai=2
                //IN Phieu Xuat Nhien Lieu if Loai=6
                //BEGIN
                ReportTemplate _report;

                #region Old phân biệt 2 mẫu: Bình quân và NXT
                //if (pnx.PhuongPhapNX == 2)//IF la Xuat Thang
                //{
                //    _report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
                //}
                //else//IF la Xuat Binh Quan
                //{
                //    _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
                //}
                #endregion//Old phân biệt 2 mẫu: Bình quân và NXT

                #region Modify Chỉ dùng 1 mẫu
                _report = ReportTemplate.GetReportTemplate("IDReport_PhieuXuatVatTu");
                #endregion//Modify Chỉ dùng 1 mẫu


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
                //END
            }
        }
    }
}