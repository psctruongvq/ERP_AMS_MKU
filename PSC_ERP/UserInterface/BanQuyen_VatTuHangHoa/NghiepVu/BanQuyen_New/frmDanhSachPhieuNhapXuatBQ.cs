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
    //05/05/2014
    public partial class frmDanhSachPhieuNhapXuatBQ : DevExpress.XtraEditors.XtraForm
    {
        PhieuNhapXuatBQList _phieuNhapXuatList = PhieuNhapXuatBQList.NewPhieuNhapXuatList();
        PhieuNhapXuatBQList _dsPhieuNhapForLapPhieuXuat = PhieuNhapXuatBQList.NewPhieuNhapXuatList();
        bool _laNhap;
        int _loaiPhieu;
        int _kieu = 1;
        PhieuNhapXuatBQ _phieuNhapXuat = PhieuNhapXuatBQ.NewPhieuNhapXuat();
        PhieuNhapXuatBQ _pxTam = PhieuNhapXuatBQ.NewPhieuNhapXuat();
        string _MaPhieuListString;
        long _maPhieuNhapXuat = 0;
        int _maPhongBan = 0;
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        private bool _forLapPX;
        public bool ChoPhepLapPhieuXuat = false;
        #region Functions
        #region An Hien BtnXoa
        void HidebtnXoa()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            if (_forLapPX == false)
            {
                btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnLuu.Caption = "Lập phiếu xuất";
            }
        }
        void ShowbtnXoa()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        #endregion//An Hien BtnXoa

        private void LockGridview()
        {
            this.colSoPhieu.OptionsColumn.ReadOnly = true;
            this.colSoPhieu.OptionsColumn.ReadOnly = true;
            this.colNgayNX.OptionsColumn.ReadOnly = true;
            this.colMaKho.OptionsColumn.ReadOnly = true;
            this.colGiaTriKho.OptionsColumn.ReadOnly = true;
            this.colMaPhongBan.OptionsColumn.ReadOnly = true;
            this.colMaDoiTac.OptionsColumn.ReadOnly = true;
            this.colDienGiai.OptionsColumn.ReadOnly = true;
        }
        #endregion Functions
        //
        public PhieuNhapXuatBQ PhieuNhapXuat
        {
            get { return _phieuNhapXuat; }
        }

        public PhieuNhapXuatBQList DSPhieuNhapForLapPhieuXuat
        {
            get { return _dsPhieuNhapForLapPhieuXuat; }
        }

        public frmDanhSachPhieuNhapXuatBQ()
        {
            InitializeComponent();

        }

        public frmDanhSachPhieuNhapXuatBQ(bool laNhap, int loaiPhieu)
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

        public frmDanhSachPhieuNhapXuatBQ(PhieuNhapXuatBQ px, bool laNhap, int loaiPhieu, bool forLapPX)
        {
            InitializeComponent();
            _laNhap = laNhap;
            _loaiPhieu = loaiPhieu;
            _kieu = 2;
            UserId = 0;
            _pxTam = px;
            _forLapPX = forLapPX;
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

        private void KhoiTao()
        {
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

            _dataTable.Rows.Add(0, "Không Chọn");
            _dataTable.Rows.Add(1, "Bình Quân");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");

            phuongPhapNXbindingSource.DataSource = _dataTable;
            lookUpEdit_PPNXKho.Properties.DataSource = phuongPhapNXbindingSource;
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.Properties.NullText = "Không Chọn";
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            XtraForm frm = new XtraForm();
            if (_loaiPhieu == 1 && _laNhap == true)
            {
                frm = new frmPhieuNhapBanQuyenBQ();
            }
            else if (_loaiPhieu == 1 && _laNhap == false)
            {
                frm = new FrmPhieuXuatBanQuyenBQ();
            }
            else if (_loaiPhieu == 4 && _laNhap == true)
            {
                frm = new frmPhieuNhapBoSungGiaTriBQ();
            }
            else if (_loaiPhieu == 4 && _laNhap == false)
            {
                frm = new frmPhieuXuatBoSungGiaTriBQ();
            }
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (checkEdit_Ngay.Checked == true)
                {
                    _phieuNhapXuatList = PhieuNhapXuatBQList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), Convert.ToDateTime(dtEdit_TuNgay.EditValue), Convert.ToDateTime(dtEdit_DenNgay.EditValue), _laNhap, _loaiPhieu, UserId);
                }
                else
                {
                    _phieuNhapXuatList = PhieuNhapXuatBQList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), _laNhap, _loaiPhieu, UserId);
                }
            }
            phieuNhapXuatListBindingSource.DataSource = _phieuNhapXuatList;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus.Focus();
            if (_forLapPX)
            {
                _dsPhieuNhapForLapPhieuXuat = PhieuNhapXuatBQList.NewPhieuNhapXuatList();
                foreach (PhieuNhapXuatBQ item in _phieuNhapXuatList)
                {
                    if (item.CheckChon)
                    {
                        PhieuNhapXuatBQ newBQ = PhieuNhapXuatBQ.GetPhieuNhapXuat(item.MaPhieuNhapXuat);
                        _dsPhieuNhapForLapPhieuXuat.Add(newBQ);
                    }
                }
                ChoPhepLapPhieuXuat = true;
                this.Close();
            }

            //try
            //{
            //    _phieuNhapXuatList.ApplyEdit();
            //    _phieuNhapXuatList.Save();
            //    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch
            //{
            //    MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }


        private void btn_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_forLapPX)
            {
                _phieuNhapXuatList = PhieuNhapXuatBQList.GetPhieuNhapXuatListForXuatBoSungGiaTriBQ(_pxTam.MaKho, _pxTam.MaPhongBan, _pxTam.PhuongPhapNX, _pxTam.NgayNX, 4);
            }
            else
            {

                if (checkEdit_Ngay.Checked == true)
                {
                    _phieuNhapXuatList = PhieuNhapXuatBQList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), (Convert.ToDateTime(dtEdit_TuNgay.EditValue)).Date, (Convert.ToDateTime(dtEdit_DenNgay.EditValue)).Date, _laNhap, _loaiPhieu, UserId);
                }
                else
                {
                    _phieuNhapXuatList = PhieuNhapXuatBQList.GetPhieuNhapXuatList(Convert.ToInt32(gridLookUpEdit_KhoNhan.EditValue), (long)0, Convert.ToInt64(lookUpEdit_NhanVien.EditValue), Convert.ToInt32(lookUpEdit_PhongBan.EditValue), Convert.ToByte(lookUpEdit_PPNXKho.EditValue), _laNhap, _loaiPhieu, UserId);
                }
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
                PhieuNhapXuatBQ phieuNhapXuat = grdv_DanhSachPhieuNhapXuat.GetFocusedRow() as PhieuNhapXuatBQ;
                _phieuNhapXuat = PhieuNhapXuatBQ.GetPhieuNhapXuat(phieuNhapXuat.MaPhieuNhapXuat);
                if (_kieu == 1)
                {
                    XtraForm frm = new XtraForm();
                    if (_phieuNhapXuat.LaNhap == true && _phieuNhapXuat.Loai == 1)
                    {
                        frm = new frmPhieuNhapBanQuyenBQ(_phieuNhapXuat);
                    }
                    else if (_phieuNhapXuat.LaNhap == false && _phieuNhapXuat.Loai == 1)
                    {
                        frm = new FrmPhieuXuatBanQuyenBQ(_phieuNhapXuat, 1);
                    }
                    else if (_phieuNhapXuat.LaNhap == true && _phieuNhapXuat.Loai == 4)
                    {
                        frm = new frmPhieuNhapBoSungGiaTriBQ(_phieuNhapXuat);
                    }
                    else if (_phieuNhapXuat.LaNhap == false && _phieuNhapXuat.Loai == 4)
                    {
                        frm = new frmPhieuXuatBoSungGiaTriBQ(_phieuNhapXuat);
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
            textEdit_Focus.Focus();
            PhieuNhapXuatBQList phieuNXList = PhieuNhapXuatBQList.NewPhieuNhapXuatList();
            _MaPhieuListString = "";
            foreach (PhieuNhapXuatBQ phieu in _phieuNhapXuatList)
            {
                if (phieu.CheckChon)
                {
                    phieuNXList.Add(phieu);
                }
            }
            if (phieuNXList.Count > 0)
            {

                foreach (PhieuNhapXuatBQ phieuchon in phieuNXList)
                {
                    _MaPhieuListString += phieuchon.MaPhieuNhapXuat.ToString() + ",";
                }
                _MaPhieuListString = _MaPhieuListString.Substring(0, _MaPhieuListString.Length - 1);

                #region//--====================================
                PhieuNhapXuatBQ pnx = (PhieuNhapXuatBQ)phieuNhapXuatListBindingSource.Current;
                _maPhieuNhapXuat = pnx.MaPhieuNhapXuat;
                _maPhongBan = pnx.MaPhongBan;
                //

                if ((pnx.Loai == 1 || pnx.Loai == 4) && pnx.LaNhap == true)
                {
                    //IN Phieu Nhap Ban Quyen
                    //BEGIN
                    ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_PhieuNhapBanQuyen_BQ_InNhieuPhieu");
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
                    ReportTemplate _report = ReportTemplate.GetReportTemplate("ID_PhieuXuatBanQuyen_BQ_InNhieuPhieu");
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

                #endregion//--====================================
            }
            else
            {
                MessageBox.Show("Hãy chọn phiếu cần in!");
                return;
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
                    cm.CommandText = "Spd_PhieuXuatBanQuyen_BQ_InNhieuPhieu";
                    cm.Parameters.AddWithValue("@MaPhieuListString", _MaPhieuListString);

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
                    cm.CommandText = "Spd_PhieuNhapBanQuyen_BQ_InNhieuPhieu";
                    cm.Parameters.AddWithValue("@MaPhieuListString", _MaPhieuListString);

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
                    PhieuNhapXuatBQ pnx = _phieuNhapXuatList[i];
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
                        if (PhieuNhapXuatBQ.KiemTraPhieuNhapDaXuatThang(pnx.MaPhieuNhapXuat))//Kiem Tra Phieu Nhap Thang da Xuat
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
            LockGridview();
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
    }
}