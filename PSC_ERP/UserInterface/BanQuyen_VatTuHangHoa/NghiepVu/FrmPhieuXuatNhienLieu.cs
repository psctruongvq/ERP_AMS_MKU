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
//12/06/2014

namespace PSC_ERP
{
    public partial class FrmPhieuXuatNhienLieu : DevExpress.XtraEditors.XtraForm
    {
        PhieuNhapXuat _phieuXuatVTHH;
        String _soPhieu;
        string _soPhieuSet = "";
        PhieuNhapXuatList _phieuNhapListChon;
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        bool _flag = false;
        PhieuLinhNhienLieuList _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
        PhieuLinhNhienLieuList _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        //Add to 11012013
        DateTime _ngayLapCu;
        int _maKhoCu;
        //End Add to 11012013
        /// <summary>
        /// /////
        /// </summary>

        #region  Functions
        #region DamBao
        private bool KiemTraPhanHeCua2014()
        {
            if (_phieuXuatVTHH != null)
            {
                if (_phieuXuatVTHH.NgayNX.Year >= 2014)
                {
                    MessageBox.Show("Vui lòng nhập phiếu vào phân hệ 2014!");
                    return true;
                    this.Close();
                }
            }
            return false;
        }
        #endregion


        #region Hàm khởi tạo lookUpEdit_PhuongPhapNX
        private void KhoiTao_PhuongPhapNX()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("maHinhThuc", typeof(byte));
            dt.Columns.Add("tenHinhThuc", typeof(string));
            //Add dòng 1
            DataRow dr = dt.NewRow();
            dr["maHinhThuc"] = 1;
            dr["tenHinhThuc"] = "Bình Quân";
            dt.Rows.Add(dr);
            //Add dòng 2
            dr = dt.NewRow();
            dr["maHinhThuc"] = 2;
            dr["tenHinhThuc"] = "Xuất Thẳng";
            dt.Rows.Add(dr);

            this.lookUpEdit_PhuongPhapNX.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("maHinhThuc", null, 10, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Center),
                    new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenHinhThuc", null, 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            PhuongPhapNX_bindingSource.DataSource = dt;
            lookUpEdit_PhuongPhapNX.Properties.DataSource = PhuongPhapNX_bindingSource;
            lookUpEdit_PhuongPhapNX.Properties.DisplayMember = "tenHinhThuc";
            lookUpEdit_PhuongPhapNX.Properties.ValueMember = "maHinhThuc";
        }
        #endregion//END Hàm khởi tạo lookUpEdit_PhuongPhapNX

        #region Khoi tao moi
        private void KhoiTaoN()
        {
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(4);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            //boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListForLinhNhienLieu();
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList(4);


            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
        }
        #endregion//END Khoi Tao moi

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = 6;
            _soPhieuSet = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            _phieuXuatVTHH.SoPhieu = _soPhieuSet;
            _phieuXuatVTHH.MaKho = KhoBQ_VTList.GetKhoBQ_VTList(4)[0].MaKho;
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();//22012013
            _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

            _phieuXuatVTHH.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;
            _flag = true;
        }
        #endregion

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            _phieuXuatVTHH = phieuNhapXuat;
            //Add to 11012013
            _ngayLapCu = _phieuXuatVTHH.NgayNX;
            _maKhoCu = _phieuXuatVTHH.MaKho;
            //End Add to 11012013
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;
            _flag = true;

        }
        #endregion

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu(PhieuLinhNhienLieu phieuLinhNhienLieu)
        {
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            _phieuLinhNhienLieuList.Add(PhieuLinhNhienLieu.GetPhieuLinhNhienLieu(phieuLinhNhienLieu.MaPhieuLinhNhienLieu));
            //B
            //_phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat(phieuLinhNhienLieu);
            _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuXuatVTHH.NgayNX = phieuLinhNhienLieu.NgayLap;
            _phieuXuatVTHH.MaNguoiNhapXuat = phieuLinhNhienLieu.MaNguoiNhan;
            _phieuXuatVTHH.MaPhongBan = phieuLinhNhienLieu.MaBoPhanNhan;
            _phieuXuatVTHH.MaKho = phieuLinhNhienLieu.MaKho;
            _phieuXuatVTHH.DienGiai = phieuLinhNhienLieu.DienGiai;
            _phieuXuatVTHH.GiaTriKho = 0;
            foreach (CT_PhieuLinhNhienLieu ct_PhieuLinhNhienLieu in phieuLinhNhienLieu.CT_PhieuLinhNhienLieuList)
            {
                if (ct_PhieuLinhNhienLieu.SoLuongXuat > HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _phieuXuatVTHH.MaKho, ct_PhieuLinhNhienLieu.MaHangHoa, _phieuXuatVTHH.NgayNX))
                {
                    HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuLinhNhienLieu.MaHangHoa);
                    MessageBox.Show("Số lượng xuất \"" + _hangHoaBQ_VT.TenHangHoa + "\" vượt quá số lượng tồn!\n Không thể xuất!");
                }
                else
                {
                    //
                    CT_PhieuXuat ct_PhieuXuat = new CT_PhieuXuat(ct_PhieuLinhNhienLieu, _phieuXuatVTHH.MaKho, _phieuXuatVTHH.NgayNX);
                    ct_PhieuXuat.DienGiai = _phieuXuatVTHH.DienGiai;//NewDienGiai
                    _phieuXuatVTHH.CT_PhieuXuatList.Add(ct_PhieuXuat);
                    _phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien;

                    _phieuLinhNhienLieuList_Update.Add(phieuLinhNhienLieu);
                    //
                }
            }
            //E
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = 6;
            _phieuXuatVTHH.DienGiai = phieuLinhNhienLieu.DienGiai; //Thang           
            _soPhieuSet = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            _phieuXuatVTHH.SoPhieu = _soPhieuSet;
            _soPhieu = _phieuXuatVTHH.SoPhieu;

            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;



            _flag = true;

        }

        private void KhoiTaoPhieu(PhieuLinhNhienLieuList phieuLinhNhienLieuList)
        {
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            foreach (PhieuLinhNhienLieu itemN in phieuLinhNhienLieuList)
            {
                PhieuLinhNhienLieu _itemAdd = PhieuLinhNhienLieu.GetPhieuLinhNhienLieu(itemN.MaPhieuLinhNhienLieu);
                if (!_phieuLinhNhienLieuList.Contains(_itemAdd))
                {
                    _phieuLinhNhienLieuList.Add(_itemAdd);
                }
            }
            #region NewDienGiai
            String dienGiai = "";
            {
                foreach (PhieuLinhNhienLieu item in phieuLinhNhienLieuList)
                {
                    if (item.DienGiai.ToString().Trim().Length > 0)
                    {
                        dienGiai = item.DienGiai;
                        break;
                    }
                }
            }
            #endregion//NewDienGiai
            
            string soPhieuO = _phieuXuatVTHH.SoPhieu;
            DateTime NgayNXO = _phieuXuatVTHH.NgayNX;
            //decimal giaTriKhoO = _phieuXuatVTHH.GiaTriKho;
            byte pPNXO = _phieuXuatVTHH.PhuongPhapNX;
            //
            _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
           _phieuXuatVTHH.SoPhieu = soPhieuO;
            _phieuXuatVTHH.NgayNX = NgayNXO;
            //_phieuXuatVTHH.GiaTriKho = giaTriKhoO;
           _phieuXuatVTHH.PhuongPhapNX = pPNXO;
            //
           _phieuXuatVTHH.MaPhongBan = phieuLinhNhienLieuList[0].MaBoPhanNhan;
            _phieuXuatVTHH.MaNguoiNhapXuat = phieuLinhNhienLieuList[0].MaNguoiNhan;
            _phieuXuatVTHH.MaKho = phieuLinhNhienLieuList[0].MaKho;
            //_phieuXuatVTHH.GiaTriKho = 0;
            _phieuXuatVTHH.DienGiai = "";
           
            foreach (PhieuLinhNhienLieu phieuLinhNhienLieu in _phieuLinhNhienLieuList)
            {

                foreach (CT_PhieuLinhNhienLieu ct_PhieuLinhNhienLieu in phieuLinhNhienLieu.CT_PhieuLinhNhienLieuList)
                {
                    if (ct_PhieuLinhNhienLieu.SoLuongXuat > HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(0, _phieuXuatVTHH.MaKho, ct_PhieuLinhNhienLieu.MaHangHoa, _phieuXuatVTHH.NgayNX))
                    {
                        HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuLinhNhienLieu.MaHangHoa);
                        MessageBox.Show("Số lượng xuất \"" + _hangHoaBQ_VT.TenHangHoa + "\" vượt quá số lượng tồn!\n Không thể xuất!");
                    }
                    else
                    {
                        //
                        CT_PhieuXuat ct_PhieuXuat = new CT_PhieuXuat(ct_PhieuLinhNhienLieu, _phieuXuatVTHH.MaKho, _phieuXuatVTHH.NgayNX);
                        ct_PhieuXuat.DienGiai = dienGiai;//NewDienGiai
                        _phieuXuatVTHH.CT_PhieuXuatList.Add(ct_PhieuXuat);
                        _phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien;

                        _phieuLinhNhienLieuList_Update.Add(phieuLinhNhienLieu);
                        //
                    }
                }
            }
            //E
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = 6;

            _soPhieuSet = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            _phieuXuatVTHH.SoPhieu = _soPhieuSet;
            _phieuXuatVTHH.DienGiai = dienGiai;
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;

            _flag = true;

        }
        #endregion
        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuXuat ct_phieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
            {
                if (ct_phieuXuat.MaHangHoa == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập hàng hóa cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (ct_phieuXuat.SoLuong == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập số lượng cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            return kq;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = false;
            if (_phieuXuatVTHH.MaPhongBan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_PhongBan.Focus();
            }
            else if (_phieuXuatVTHH.MaNguoiNhapXuat == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_NhanVien.Focus();
            }
            else if (_phieuXuatVTHH.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoXuat.Focus();
            }
            else if (_phieuXuatVTHH.CT_PhieuXuatList.Count == 0)
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (KiemTraChiTiet() == false)
            {
                grdViewCt_PhieuXuat.Focus();
            }
            else kq = true;
            return kq;
        }
        private void LockData()
        {
            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
            grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = true;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

        }
        void UnLockData()
        {
            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = true;
            grdViewCt_PhieuXuat.Columns["SoLuong"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["ThanhTien"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = true;
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = false;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
            //btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        void formatGriview()
        {
            this.grdViewCt_PhieuXuat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }
        void AllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        void NotAllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        private bool KhoaSo()
        {
            bool khoaso = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuXuatVTHH.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }
            //
            if (khoaso == false && _phieuXuatVTHH.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        khoaso = true;
                    }
                }
            }
            return khoaso;
        }

        private bool DaKetChuyen()
        {
            bool daKC = false;
            daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_phieuXuatVTHH.NgayNX, _phieuXuatVTHH.MaKho);
            if (daKC == false && _phieuXuatVTHH.IsNew == false)
            {
                daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_ngayLapCu, _maKhoCu);
            }
            if (daKC)
            {
                MessageBox.Show("Kỳ này đã kết chuyển, không thể cập nhật phiếu!");
            }
            return daKC;
        }
        #endregion//End Function

        public FrmPhieuXuatNhienLieu()
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu();
            KhoiTao_PhuongPhapNX();
        }

        public FrmPhieuXuatNhienLieu(PhieuNhapXuat phieuNhap)
        {
            InitializeComponent();
            barbt_PhieuLinhNL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap);
            KhoiTao_PhuongPhapNX();
        }

        public FrmPhieuXuatNhienLieu(PhieuLinhNhienLieu phieuLinhNhienLieu)
        {
            InitializeComponent();
            barbt_PhieuLinhNL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            KhoiTaoN();
            KhoiTaoPhieu(phieuLinhNhienLieu);
            KhoiTao_PhuongPhapNX();
            if (_phieuXuatVTHH.CT_PhieuXuatList.Count > 0)
            {
                LockData();
                NotAllowDelete();

            }
        }

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
        }
        #endregion
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            barbt_PhieuLinhNL.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            KhoiTaoPhieu();
            UnLockData();//
            AllowDelete();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraPhanHeCua2014())
                return;
            textEdit_Focus.Focus();
            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Add to 18012013
            if (_phieuXuatVTHH.XacNhan == true)
            {
                MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DaKetChuyen() == false)
            {
                //End Add to 18012013
                if (txt_SoPhieu.EditValue != null)//IF 1
                {
                    string _soPhieu = txt_SoPhieu.EditValue.ToString();
                    int _stt;
                    if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                    {
                        bool ktphieutrung = true;
                        if (_phieuXuatVTHH.IsNew)
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.SoPhieu, true);
                        }
                        else//k phai IS NEW
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.SoPhieu, false);

                        }
                        if (ktphieutrung)//IF 5
                        {
                            //
                            try
                            {
                                if (KiemTraDuLieu())
                                {
                                    //C
                                    try
                                    {
                                        phieuNhapXuatBindingSource.EndEdit();
                                        _phieuXuatVTHH.ApplyEdit();
                                        _phieuXuatVTHH.Save();
                                        {
                                            foreach (PhieuLinhNhienLieu item in _phieuLinhNhienLieuList_Update)
                                            {
                                                item.TinhTrang = 2;
                                                item.MaPhieuNhapXuat = _phieuXuatVTHH.MaPhieuNhapXuat;
                                            }
                                            _phieuLinhNhienLieuList_Update.ApplyEdit();
                                            _phieuLinhNhienLieuList_Update.Save();
                                        }
                                        //Add to 11012013
                                        _ngayLapCu = _phieuXuatVTHH.NgayNX;
                                        _maKhoCu = _phieuXuatVTHH.MaKho;
                                        //End Add to 11012013
                                        barbt_PhieuLinhNL.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        _flag = false;
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    //C
                                }
                            }
                            catch
                            {
                                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            //
                        }//END IF 5
                        else
                        {
                            MessageBox.Show("Số phiếu đã tồn tại. \r\n Vui lòng lấy giá trị mặc định. \r\n Cập nhật thất bại.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_SoPhieu.Focus();
                        }
                    }//END IF 2
                    else
                    {
                        MessageBox.Show("Số Phiếu Không Hợp Lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_SoPhieu.Focus();
                    }

                }
            }
        }
        private void grdViewCt_PhieuXuat_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {


            CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
            if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHangHoa")
            {
                grdCT_PhieuXuat.Update();
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(_ct_PhieuXuat.MaHangHoa);
                _ct_PhieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                _ct_PhieuXuat.SoLuong = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                _ct_PhieuXuat.DonGia = HangHoaBQ_VT.GetGiaTriBinhQuanHangHoa(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
            }
            if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colSoLuong")
            {
                decimal _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                if ((decimal)e.Value > _soLuongHienCo)
                {
                    MessageBox.Show("Số lượng còn " + _soLuongHienCo.ToString() + ". Không đủ xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                }

                if ((decimal)e.Value == _soLuongHienCo)
                {
                    grdCT_PhieuXuat.Update();
                    _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                }
            }

            _phieuXuatVTHH.GiaTriKho = 0;
            foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
            {
                _phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien;
            }


        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void grdCT_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
        }

        private void grd_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    grdView_DinhKhoan.DeleteSelectedRows();
            //}
            HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }

        private void btnUndoM_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;

        }

        private void gridLookUpEdit_KhoXuat_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            ButToanPhieuNhapXuat butToan = (ButToanPhieuNhapXuat)(butToanPhieuNhapXuatListBindingSource.Current);
            decimal soTienConLai = _phieuXuatVTHH.GiaTriKho;
            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuXuatVTHH.ButToanPhieuNhapXuatList)
            {
                soTienConLai = soTienConLai - buttoanphieu.SoTien;
            }
            butToan.SoTien = soTienConLai;
            butToan.CoTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("152");
            butToan.DienGiai = _phieuXuatVTHH.DienGiai;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Rpt_PhieuXuatVatTu rpt = new Rpt_PhieuXuatVatTu(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.NgayNX);
            //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();

            //BEGIN
            ReportTemplate _report;
            if (_phieuXuatVTHH.PhuongPhapNX == 2)//if la Xuat Thang
            {
                _report = ReportTemplate.GetReportTemplate("PhieuXuatVatTu_XuatThang");
            }
            else//if la Xuat Binh Quan
            {
                _report = ReportTemplate.GetReportTemplate("PheuXuatVatTu");
            }
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

        private void gridLookUpEdit_KhoXuat_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            _phieuXuatVTHH.GiaTriKho = 0;
            phieuNhapXuatBindingSource.EndEdit();
            foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
            {
                ct_PhieuXuat.DonGia = HangHoaBQ_VT.GetGiaBinhQuan(_phieuXuatVTHH.MaKho, ct_PhieuXuat.MaHangHoa, _phieuXuatVTHH.NgayNX);
                _phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien;
            }
        }

        private void barbt_PhieuLinhNL_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSPhieuLinhNhienLieu frm = new frmDSPhieuLinhNhienLieu(_phieuXuatVTHH.MaKho, _phieuXuatVTHH.MaPhongBan, _phieuXuatVTHH.NgayNX, 1);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (frm.PhieuLinhNhienLieuDuocChonList != null && frm.PhieuLinhNhienLieuDuocChonList.Count > 0)
                {
                    KhoiTaoPhieu(frm.PhieuLinhNhienLieuDuocChonList);
                    if (_phieuXuatVTHH.CT_PhieuXuatList.Count > 0)
                    {
                        LockData();
                        NotAllowDelete();

                    }
                }
            }
        }
        #region Cac Phuong Thuc Report


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
                    cm.Parameters.AddWithValue("@MaPhieuXuatVTHH", _phieuXuatVTHH.MaPhieuNhapXuat);

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
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_CTPhieuXuat")
            {
                //if (grdViewCt_PhieuXuat.GetFocusedRow() != null)
                //{
                //    CT_PhieuXuat ct_px = grdViewCt_PhieuXuat.GetFocusedRow() as CT_PhieuXuat;
                //    _phieuXuatVTHH.GiaTriKho = _phieuXuatVTHH.GiaTriKho - ct_px.ThanhTien;
                //    grdViewCt_PhieuXuat.DeleteSelectedRows();
                //}
                grdViewCt_PhieuXuat.DeleteSelectedRows();
                _phieuXuatVTHH.GiaTriKho = 0;
                foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
                {
                    _phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien;
                }

            }
            else if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_ButToan")
            {
                grdView_DinhKhoan.DeleteSelectedRows();

            }

        }

        private void grdViewCt_PhieuXuat_RowCountChanged(object sender, EventArgs e)
        {
            //_phieuXuatVTHH.GiaTriKho = 0;
            //foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
            //{
            //    _phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien;
            //}
        }

        private void FrmPhieuXuatNhienLieu_Load(object sender, EventArgs e)
        {
           
            formatGriview();
            if (PhieuNhapXuat.KiemTraPhieuXuatTuDSPhieuDeNghiLinh(_phieuXuatVTHH.MaPhieuNhapXuat))
            {
                LockData();
                NotAllowDelete();
            }

            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuXuat, 35);
            Utils.GridUtils.InitNewRowOnTopOfGridView(grdViewCt_PhieuXuat);
            Utils.GridUtils.InitNewRowOnTopOfGridView(grdView_DinhKhoan);
            //KiemTraPhanHeCua2014();
        }

        private void grdViewCt_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(0);
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (dlg.MaHangHoaChon != 0)
                {
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(4);
                    if (cTPhieuXuatListBindingSource.Current == null)
                        grdViewCt_PhieuXuat.AddNewRow();
                    CT_PhieuXuat ct_phieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
                    ct_phieuXuat.MaHangHoa = dlg.MaHangHoaChon;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuXuat.MaHangHoa);
                    ct_phieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                    //grdViewCt_PhieuXuat.RefreshData();
                }

            }
        }

        private void grdViewCt_PhieuXuat_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
            _ct_PhieuXuat.DienGiai = _phieuXuatVTHH.DienGiai;
        }

        private void Tab_NghiepVuPhieuXuat_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {

            if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_ButToan")
            {
                AllowDelete();
            }
            else if (PhieuNhapXuat.KiemTraPhieuXuatTuDSPhieuDeNghiLinh(_phieuXuatVTHH.MaPhieuNhapXuat))
            {
                NotAllowDelete();
            }
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuXuatVTHH;
            if (pnx != null)
            {
                if (KhoaSo())
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DaKetChuyen()) return;

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
                //Delete Phieu
                if (MessageBox.Show(this, "Bạn muốn xóa Phiếu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        PhieuNhapXuat.DeletePhieuNhapXuat(_phieuXuatVTHH);
                        MessageBox.Show(this, "Xóa Thành Công ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnThemMoi.PerformClick();
                    }
                    catch
                    {
                        MessageBox.Show(this, "Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }//End Delete Phieu
            }
            //E
        }


        //END Spd_PhieuXuatVatTu

        #endregion//Cac Phuong Thuc Report
    }
}