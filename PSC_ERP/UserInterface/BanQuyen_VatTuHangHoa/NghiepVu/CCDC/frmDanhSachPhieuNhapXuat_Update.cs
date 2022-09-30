using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Diagnostics;
using System.IO;

namespace PSC_ERP
{
    //23/04/2013
    public partial class frmDanhSachPhieuNhapXuat_Update : DevExpress.XtraEditors.XtraForm
    {
        PhieuNhapXuatCCDCList _phieuNhapXuatList = PhieuNhapXuatCCDCList.NewPhieuNhapXuatList();
        bool _laNhap;
        int _loaiPhieu;
        int _kieu = 1;
        PhieuNhapXuatCCDC _phieuNhapXuat = PhieuNhapXuatCCDC.NewPhieuNhapXuat();
        long _maPhieuNhapXuat = 0;
        int _maPhongBan = 0;
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
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
        public PhieuNhapXuatCCDC PhieuNhapXuatccdc
        {
            get { return _phieuNhapXuat; }
        }

        private void SetBindingForBindingSource()
        {
            phieuNhapXuatListBindingSource.DataSource = typeof(PhieuNhapXuatCCDC);
        }

        public frmDanhSachPhieuNhapXuat_Update()
        {
            InitializeComponent();
            KhoiTao();
        }

        public frmDanhSachPhieuNhapXuat_Update(bool laNhap, int loaiPhieu)
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
            SetBindingForBindingSource();

            // BoPhanList _BoPhanList = BoPhanList.GetBoPhanList();
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            KhoBQ_VTList _KhoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList();
            KhoBQ_VT _KhoBQ_VT = KhoBQ_VT.NewKhoBQ_VT();
            _KhoBQ_VT.TenKho = "Không Chọn";
            _KhoBQ_VTList.Insert(0, _KhoBQ_VT);
            khoBQVTListBindingSource.DataSource = _KhoBQ_VTList;

            Init_lookUpEdit_PPNXKho();

            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;

            //boPhanListBindingSource1.DataSource = BoPhanList.GetBoPhanList();
            boPhanListBindingSource1.DataSource = BoPhanList.GetBoPhanListBy_All();
            thongTinNhanVienTongHopListBindingSource1.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            khoBQVTListBindingSource1.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
            doiTacListBindingSource.DataSource = DoiTacList.GetDoiTacListByTen(0);
        }


        private void Init_lookUpEdit_PPNXKho()
        {
            DataTable _dataTable = new DataTable();
            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(0, "<<Không chọn>>");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");
            _dataTable.Rows.Add(3, "CCDC quản lý");

            phuongPhapNXbindingSource.DataSource = _dataTable;
            lookUpEdit_PPNXKho.Properties.DataSource = phuongPhapNXbindingSource;
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.Properties.NullText = "Không Chọn";
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm frm = new XtraForm();
            if (_loaiPhieu == 3 && _laNhap == false)
            {
                frm = new frmPhieuXuatPhanBoCCDC_Update();
            }
            else if (_loaiPhieu == 3 && _laNhap == true)
            {
                frm = new frmPhieuNhapCongCuDungCu_Update();
            }
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (checkEdit_Ngay.Checked == true)
                {
                    _phieuNhapXuatList = PhieuNhapXuatCCDCList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), Convert.ToDateTime(dtEdit_TuNgay.EditValue), Convert.ToDateTime(dtEdit_DenNgay.EditValue), _laNhap, _loaiPhieu, UserId);
                }
                else
                {
                    _phieuNhapXuatList = PhieuNhapXuatCCDCList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), _laNhap, _loaiPhieu, UserId);
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

            if (checkEdit_Ngay.Checked == true)
            {
                _phieuNhapXuatList = PhieuNhapXuatCCDCList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _laNhap, _loaiPhieu, UserId);
            }
            else
            {
                _phieuNhapXuatList = PhieuNhapXuatCCDCList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), _laNhap, _loaiPhieu, UserId);
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
                PhieuNhapXuatCCDC phieuNhapXuat = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuNhapXuatCCDC;
                _phieuNhapXuat = PhieuNhapXuatCCDC.GetPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
                if (_kieu == 1)
                {
                    XtraForm frm = new XtraForm();
                   if (_phieuNhapXuat.LaNhap == false && _phieuNhapXuat.Loai == 3)
                    {
                        frm = new frmPhieuXuatPhanBoCCDC_Update(_phieuNhapXuat, 0);
                    }
                   else if (_phieuNhapXuat.LaNhap == true && _phieuNhapXuat.Loai == 3)
                   {
                       PhieuNhapXuat phieunhapccdc=PhieuNhapXuat.GetPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
                       //frm = new frmNhapPhanBoCongCuDungCu(_phieuNhapXuat);
                       frm = new frmPhieuNhapCongCuDungCu_Update(phieunhapccdc);
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
                _ThongTinNhanVienTongHopList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
                ThongTinNhanVienTongHop nhanVien = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "Không Chọn");
                _ThongTinNhanVienTongHopList.Insert(0, nhanVien);
            }
            thongTinNhanVienTongHopListBindingSource.DataSource = _ThongTinNhanVienTongHopList;

        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhapXuatCCDC pnx = (PhieuNhapXuatCCDC)phieuNhapXuatListBindingSource.Current;
            _maPhieuNhapXuat = pnx.MaPhieuNhapXuat;
            _maPhongBan = pnx.MaPhongBan;
            //
            if (pnx.Loai == 3 && pnx.LaNhap == false)//xuat CCDC
            {
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
                    PhieuNhapXuatCCDC pnx = _phieuNhapXuatList[i];
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
                        if (PhieuNhapXuatCCDC.KiemTraPhieuNhapDaXuatThang(pnx.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
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

        private void barBtnItemInCCDCQuanLy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhapXuatCCDC pnx = (PhieuNhapXuatCCDC)phieuNhapXuatListBindingSource.Current;
            _maPhieuNhapXuat = pnx.MaPhieuNhapXuat;
            _maPhongBan = pnx.MaPhongBan;
            //
            if (pnx.Loai == 3)
            {
                if (pnx.LaNhap)//nhap CCDC
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
                else//xuat CCDC
                {
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
            }
        }

        private void barBtnItemInNXT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhapXuatCCDC pnx = (PhieuNhapXuatCCDC)phieuNhapXuatListBindingSource.Current;
            _maPhieuNhapXuat = pnx.MaPhieuNhapXuat;
            _maPhongBan = pnx.MaPhongBan;
            //
            if (pnx.Loai == 3)
            {
                if (pnx.LaNhap)//nhap CCDC
                {
                    //IN Phieu Nhap Vat Tu
                    //BEGIN
                    ReportTemplate _report;
                    _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu_XuatThang");
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
                else//xuat CCDC
                {
                    ReportTemplate _report;
                    _report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
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
}