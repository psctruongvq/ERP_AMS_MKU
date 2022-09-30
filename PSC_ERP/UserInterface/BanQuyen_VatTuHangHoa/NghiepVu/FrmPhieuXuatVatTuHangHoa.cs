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
//12_06_2014
namespace PSC_ERP
{
    public partial class FrmPhieuXuatVatTuHangHoa : DevExpress.XtraEditors.XtraForm
    {

        PhieuNhapXuat _phieuXuatVTHH;
        CT_PhieuNhapList _ct_PhieuNhapListChon;//
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        //bool _flag = true;
        bool _daChonPhieuNhap = false;
        decimal _soLuongHienCo = 0;//M
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        KhoBQ_VTList _khoBQ_VTList = KhoBQ_VTList.NewKhoBQ_VTList();
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        PhieuLinhNhienLieuList _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
        PhieuLinhNhienLieuList _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
        //Add to 11012013
        DateTime _ngayLapCu;
        int _maKhoCu;
        //End Add to 11012013
        bool _phieuTuDSPhieuNhapXuat = false;
        bool _tu1PhieuNhap = false;
        //

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

        void TempLockData()
        {
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = true;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
            grdViewCt_PhieuXuat.Columns["DonGia"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
        }

        void AllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }

        void NotAllowDelete()
        {
            btnXoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }

        void CheckPhuongPhapNX()
        {
            if(_phieuXuatVTHH!=null)
            {
                if(_phieuXuatVTHH.PhuongPhapNX==2)
                {
                    colSoPhieuNhap.Visible = true; 
                }
                else
                {
                    colSoPhieuNhap.Visible = false;
                }
            }
        }

        void TinhTongTien()
        {
            Decimal tongTien = 0;
            foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
            {
                tongTien = tongTien + ct_PhieuXuat.ThanhTien;
            }
            _phieuXuatVTHH.GiaTriKho = tongTien;
        }

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
            //PhieuNhapXuatList_bindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            //heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetTaiKhoanConListByCongTy();
            //doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            

            _boPhanList = BoPhanList.GetBoPhanList();
            boPhanListBindingSource.DataSource = _boPhanList;
            _khoBQ_VTList = KhoBQ_VTList.GetKhoVatTuList();
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;


            //_DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            //DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            //_DoiTacList.Insert(0, _DoiTac);
            //doiTacListBindingSource.DataSource = _DoiTacList;

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
            _phieuXuatVTHH.Loai = 2;
            _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();//22012013
            _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;

            _phieuXuatVTHH.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;

            if (_khoBQ_VTList.Count != 0)
                _phieuXuatVTHH.MaKho = _khoBQ_VTList[0].MaKho;
            if (_boPhanList.Count != 0)
                _phieuXuatVTHH.MaPhongBan = _boPhanList[0].MaBoPhan;
            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = false;
            btnChonPNhapXuat.Enabled = true;
            //_flag = true;
            if (_phieuXuatVTHH.MaPhieuNhapXuatThamChieu != 0)
            {
                LockData();
            }
            else
            {
                UnLockData();
            }
        }
        
        #endregion//Function


        #region (PhieuLinhNhienLieu phieuLinhNhienLieu)
        private void KhoiTaoPhieu(PhieuLinhNhienLieu phieuLinhNhienLieu)
        {
            _phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            _phieuLinhNhienLieuList_Update = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuLinhNhienLieuList.Add(phieuLinhNhienLieu);
            //B
            //_phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat(phieuLinhNhienLieu);
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
                    _phieuXuatVTHH.CT_PhieuXuatList.Add(ct_PhieuXuat);
                    _phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien;

                    _phieuLinhNhienLieuList_Update.Add(phieuLinhNhienLieu);
                    //
                }
            }
            //E
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = 2;
            _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

            _phieuXuatVTHH.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;

        }
        #endregion


        private void KhoiTaoPhieu(PhieuLinhNhienLieuList phieuLinhNhienLieuList)
        {
            //_phieuLinhNhienLieuList = PhieuLinhNhienLieuList.NewPhieuLinhNhienLieuList();
            foreach (PhieuLinhNhienLieu item in phieuLinhNhienLieuList)
            {
                _phieuLinhNhienLieuList.Add(PhieuLinhNhienLieu.GetPhieuLinhNhienLieu(item.MaPhieuLinhNhienLieu));
            }
            //_phieuLinhNhienLieuList = phieuLinhNhienLieuList;
            //B
            //_phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat(_phieuLinhNhienLieuList, _phieuXuatVTHH.NgayNX);
            _phieuXuatVTHH.MaNguoiNhapXuat = phieuLinhNhienLieuList[0].MaNguoiNhan;
            _phieuXuatVTHH.MaPhongBan = phieuLinhNhienLieuList[0].MaBoPhanNhan;
            _phieuXuatVTHH.MaKho = phieuLinhNhienLieuList[0].MaKho;
            //_phieuXuatVTHH.GiaTriKho = 0;
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
                        CT_PhieuXuat ct_PhieuXuat = new CT_PhieuXuat(ct_PhieuLinhNhienLieu, _phieuXuatVTHH.MaKho, _phieuXuatVTHH.NgayNX);
                        _phieuXuatVTHH.CT_PhieuXuatList.Add(ct_PhieuXuat);
                        _phieuXuatVTHH.GiaTriKho += ct_PhieuXuat.ThanhTien;

                        _phieuLinhNhienLieuList_Update.Add(phieuLinhNhienLieu);
                    }
                }
            }
            //E
            _phieuXuatVTHH.LaNhap = false;
            _phieuXuatVTHH.Loai = 2;
            _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;

        }

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhap, int kieu)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhap, int kieu)
        {

            lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
            if (kieu == 1)
            {
                _phieuXuatVTHH = phieuNhap;
                //Add to 11012013
                _ngayLapCu = _phieuXuatVTHH.NgayNX;
                _maKhoCu = _phieuXuatVTHH.MaKho;
                //End Add to 11012013
                _phieuTuDSPhieuNhapXuat = true;
            }
            else
            {
                _phieuXuatVTHH = PhieuNhapXuat.NewPhieuNhapXuat(phieuNhap, 2);
                _phieuXuatVTHH.LaNhap = false;
                _phieuXuatVTHH.Loai = 2;
                _phieuXuatVTHH.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuXuatVTHH.Loai, _phieuXuatVTHH.LaNhap, _phieuXuatVTHH.NgayNX);
                _phieuTuDSPhieuNhapXuat = false;
                TinhTongTien();

            }
            cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;
            btnChonPNhapXuat.Enabled = false;


        }
        #endregion

        //private void AnHienBtnChonXThang()
        //{
        //    if (_phieuXuatVTHH.PhuongPhapNX == 2 && _phieuXuatVTHH.MaKho != 0 && _flag)
        //    {
        //        btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        //    }
        //    else
        //    {
        //        btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        //    }
        //}
        void formatGriview()
        {
            this.grdViewCt_PhieuXuat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
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


        public FrmPhieuXuatVatTuHangHoa()
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu();
            KhoiTao_PhuongPhapNX();
            //AnHienBtnChonXThang();
        }

        public FrmPhieuXuatVatTuHangHoa(PhieuLinhNhienLieu phieuLinhNhienLieu)
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(phieuLinhNhienLieu);
            KhoiTao_PhuongPhapNX();
            if(_phieuXuatVTHH.CT_PhieuXuatList.Count>0)
            {
                LockData();
                NotAllowDelete();

            }
            //AnHienBtnChonXThang();
        }

        public FrmPhieuXuatVatTuHangHoa(PhieuNhapXuat phieuNhap, int kieu)
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap, kieu);
            KhoiTao_PhuongPhapNX();
            if (_phieuXuatVTHH.PhuongPhapNX == 2)
                //grdViewCt_PhieuXuat.OptionsBehavior.ReadOnly = true;
                LockData();
        }
        public FrmPhieuXuatVatTuHangHoa(PhieuNhapXuat phieuNhap, int kieu, bool XuatThangTuPhieuNhap)
        {
            InitializeComponent();
            KhoiTaoN();
            KhoiTaoPhieu(phieuNhap, kieu);
            KhoiTao_PhuongPhapNX();
            _tu1PhieuNhap = true;


            //AnHienBtnChonXThang();
        }

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
            {
                //ThongTinNhanVienTongHop nv = ThongTinNhanVienTongHop.NewThongTinNhanVienTongHop(0, "<Không Chọn>");
                //ThongTinNhanVienTongHopList nvlist = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
                //nvlist.Insert(0, nv);
                //thongTinNhanVienTongHopListBindingSource.DataSource = nvlist;
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
            }
            _phieuXuatVTHH.MaPhongBan = (int)lookUpEdit_PhongBan.EditValue;
        }
        #endregion

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoPhieu();
            dateEdit_NgayLap.Focus();
            _daChonPhieuNhap = false;
            btnChonPNhapXuat.Enabled = true;
            _phieuTuDSPhieuNhapXuat = false;
            _tu1PhieuNhap = false;
            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = true;
            UnLockData();
            CheckPhuongPhapNX();
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
                MessageBox.Show(this, "Thủ kho đã xác nhận, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //End Add to 18012013

            if (DaKetChuyen() == false)
            {
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
                                    phieuNhapXuatBindingSource.EndEdit();
                                    _phieuXuatVTHH.ApplyEdit();
                                    _phieuXuatVTHH.Save();
                                    if (_phieuXuatVTHH != null)
                                    {
                                        if (_phieuXuatVTHH.PhuongPhapNX == 2)
                                        {
                                            //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                                            LockData();
                                        }
                                    }
                                    foreach (PhieuLinhNhienLieu item in _phieuLinhNhienLieuList_Update)
                                    {
                                        item.TinhTrang = 2;
                                        item.MaPhieuNhapXuat = _phieuXuatVTHH.MaPhieuNhapXuat;
                                    }
                                    _phieuLinhNhienLieuList_Update.ApplyEdit();
                                    _phieuLinhNhienLieuList_Update.Save();
                                    //Add to 11012013
                                    _ngayLapCu = _phieuXuatVTHH.NgayNX;
                                    _maKhoCu = _phieuXuatVTHH.MaKho;
                                    //End Add to 11012013
                                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lookUpEdit_PhuongPhapNX.Properties.ReadOnly = true;
                                    if (_daChonPhieuNhap)
                                        btnChonPNhapXuat.Enabled = false;
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
                            MessageBox.Show("Trùng Số Phiếu! Không Thể Lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txt_SoPhieu.Focus();
                        }
                    }//END IF 2
                    else
                    {
                        MessageBox.Show("Số Phiếu Không Hợp Lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_SoPhieu.Focus();
                    }

                }//END IF 1
            }

        }
        private void grdViewCt_PhieuXuat_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (cTPhieuXuatListBindingSource.Current != null)
            {
                CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;

                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHangHoa")
                {

                    grdCT_PhieuXuat.Update();
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(_ct_PhieuXuat.MaHangHoa);
                    _ct_PhieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                    if (_phieuXuatVTHH.PhuongPhapNX == 1)
                    {
                        _ct_PhieuXuat.DonGia = HangHoaBQ_VT.GetGiaTriBinhQuanHangHoa(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        //
                        _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                        _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        //
                    }

                }
                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colSoLuong")
                {
                    decimal soluong_gv = 0;
                    if (decimal.TryParse(e.Value.ToString(), out soluong_gv))
                    {
                        if (_phieuXuatVTHH.PhuongPhapNX == 2)//Trong T/H Xuat thang tu 1 Phieu Nhap
                        {
                            if (!_phieuTuDSPhieuNhapXuat)//Khong Phai Phieu Load Tu DS Phieu NHap Xuat
                            {
                                if (soluong_gv > _ct_PhieuXuat.SLgCt_PNhap)
                                {
                                    MessageBox.Show("Số lượng xuất vượt quá chi tiết nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_ct_PhieuXuat.SLgCt_PNhap);
                                }
                                else if (soluong_gv == _ct_PhieuXuat.SLgCt_PNhap)
                                {
                                    _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaNXT(_phieuXuatVTHH.MaPhieuNhapXuat, _ct_PhieuXuat.MaPhieuNhap, _ct_PhieuXuat.MaHangHoa, _phieuXuatVTHH.NgayNX, _ct_PhieuXuat.DonGia,_ct_PhieuXuat.MaChiTietPhieuNhap,_ct_PhieuXuat.MaCT_KetChuyen);//New 19112013
                                }
                                else
                                {
                                    grdCT_PhieuXuat.Update();
                                    _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                                }
                            }
                        }//END Trong T/H Xuat thang tu 1 Phieu Nhap
                        else//Trong T/H Xuat Binh Thuong
                        {
                            _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                            if (soluong_gv > _soLuongHienCo)
                            {
                                MessageBox.Show("Số lượng còn " + _soLuongHienCo.ToString() + ". Không đủ xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdViewCt_PhieuXuat.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                                _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                            }
                            else if (soluong_gv == _soLuongHienCo)
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuatVTHH.MaPhieuNhapXuat, _phieuXuatVTHH.MaKho, _ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                            }
                            else
                            {
                                grdCT_PhieuXuat.Update();
                                _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                            }
                        }//END Trong T/H Xuat Binh Thuong
                    }
                }//IF thay doi tren cot So Luong
                if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colDonGia")
                {

                    grdCT_PhieuXuat.Update();
                    _ct_PhieuXuat.ThanhTien = Math.Round(_ct_PhieuXuat.DonGia * _ct_PhieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);

                }
                Decimal tongTien = 0;
                foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
                {
                    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                }
                _phieuXuatVTHH.GiaTriKho = tongTien;
            }

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.Close();

        }

        private void btnChonXuatThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuXuatVTHH.MaKho == 0)
            {
                MessageBox.Show("Hãy chọn kho cần xuất thẳng!");
                gridLookUpEdit_KhoXuat.Focus();
            }
            else
            {

                FrmLoadPhieuNhapList frm = new FrmLoadPhieuNhapList(_phieuXuatVTHH);
                if (frm.ShowDialog() != DialogResult.OK)
                {
                    _ct_PhieuNhapListChon = frm.CT_PhieuNhapListChon;//M
                    if (_ct_PhieuNhapListChon.Count != 0)//M
                    {
                        #region Old
                        ////Luu Tru
                        //long maDoiTac_T = _phieuXuatVTHH.MaDoiTac;
                        //string soPhieu_T = _phieuXuatVTHH.SoPhieu;
                        //int maPhongBan_T = _phieuXuatVTHH.MaPhongBan;
                        //DateTime ngayNX_T=_phieuXuatVTHH.NgayNX;
                        //long maNguoiNhapXuat_T = _phieuXuatVTHH.MaNguoiNhapXuat;
                        //int maKho_T = _phieuXuatVTHH.MaKho;
                        //int soCTKemTheo_T = _phieuXuatVTHH.SoCTKemTheo;
                        //byte phuongPhapNX_T = _phieuXuatVTHH.PhuongPhapNX;
                        //string dienGiai_T = _phieuXuatVTHH.DienGiai;
                        //CT_PhieuXuatList cT_PhieuXuatList_T = _phieuXuatVTHH.CT_PhieuXuatList;
                        //ButToanPhieuNhapXuatList butToanPhieuNhapXuatList_T = _phieuXuatVTHH.ButToanPhieuNhapXuatList;
                        ////
                        //_phieuXuatVTHH = new PhieuNhapXuat(_ct_PhieuNhapListChon, _phieuXuatVTHH.MaPhongBan, 2, 2, _phieuXuatVTHH.MaKho, _phieuXuatVTHH.NgayNX);//M
                        ////-->Day du lieu vao
                        //_phieuXuatVTHH.LaNhap = false;
                        //_phieuXuatVTHH.Loai = 2;
                        //_phieuXuatVTHH.MaDoiTac = maDoiTac_T;
                        //_phieuXuatVTHH.SoPhieu = soPhieu_T;
                        //_phieuXuatVTHH.MaPhongBan = maPhongBan_T;
                        //_phieuXuatVTHH.NgayNX = ngayNX_T;
                        //_phieuXuatVTHH.MaNguoiNhapXuat = maNguoiNhapXuat_T;
                        //_phieuXuatVTHH.MaKho = maKho_T;
                        //_phieuXuatVTHH.SoCTKemTheo = soCTKemTheo_T;
                        //_phieuXuatVTHH.PhuongPhapNX = phuongPhapNX_T;
                        //_phieuXuatVTHH.DienGiai = dienGiai_T;
                        //foreach (CT_PhieuXuat cT in cT_PhieuXuatList_T)
                        //{
                        //    if (!_phieuXuatVTHH.CT_PhieuXuatList.Contains(cT))
                        //    {
                        //        _phieuXuatVTHH.CT_PhieuXuatList.Add(cT);
                        //    }
                        //}
                        //foreach (ButToanPhieuNhapXuat bt in butToanPhieuNhapXuatList_T)
                        //{
                        //    _phieuXuatVTHH.ButToanPhieuNhapXuatList.Add(bt);
                        //}
                        #endregion//End Old
                        #region New
                        foreach (CT_PhieuNhap ct_PhieuNhap in _ct_PhieuNhapListChon)
                        {
                            if (ct_PhieuNhap.SoLuong > ct_PhieuNhap.SoLuongXuat)
                            {
                                CT_PhieuXuat ct_PhieuXuat =new CT_PhieuXuat(ct_PhieuNhap, _phieuXuatVTHH.NgayNX);
                                bool insert = true;
                                if (grdViewCt_PhieuXuat.RowCount > 0)
                                {
                                    for (int i = 0; i < grdViewCt_PhieuXuat.RowCount; i++)
                                    {
                                        if (grdViewCt_PhieuXuat.GetRow(i) != null)
                                        {
                                            CT_PhieuXuat ct_px_gv = (CT_PhieuXuat)grdViewCt_PhieuXuat.GetRow(i);
                                            if (ct_px_gv.MaHangHoa == ct_PhieuXuat.MaHangHoa
                                                && ct_px_gv.MaPhieuNhap == ct_PhieuXuat.MaPhieuNhap
                                                && ct_px_gv.DonGia==ct_PhieuXuat.DonGia//New 19112013
                                                )
                                            {
                                                insert = false;
                                                break;
                                            }
                                        }
                                    }

                                }//grdViewCt_PhieuXuat.RowCount > 0

                                if (insert)
                                {
                                    _phieuXuatVTHH.CT_PhieuXuatList.Add(ct_PhieuXuat);
                                }

                            }
                            else
                            {
                                HangHoaBQ_VT _hangHoaBQ_VT = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuNhap.MaHangHoa);
                                MessageBox.Show("Chi tiết của \"" + _hangHoaBQ_VT.TenHangHoa + "\" đã xuất hết!");
                            }
                        }
                        #endregion //End New
                        //Set lai Gia Tri Kho
                        Decimal tongTien = 0;
                        foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
                        {
                            tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                        }
                        _phieuXuatVTHH.GiaTriKho = tongTien;
                        //END Set lai Gia Tri Kho
                        //Refresh lai du lieu
                        phieuNhapXuatBindingSource.DataSource = _phieuXuatVTHH;
                        cTPhieuXuatListBindingSource.DataSource = _phieuXuatVTHH.CT_PhieuXuatList; //_ctPhieuXuatList;
                        butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuatVTHH.ButToanPhieuNhapXuatList;// _butToanPhieuNhapXuatList;
                        grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
                        grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;
                        _daChonPhieuNhap = true;
                        TempLockData();
                    }
                }
                else
                {
                    frm.ShowDialog();
                }
                ////End Chi Thuyen
            }
            //Xu ly dong form [PhieuXuat]

        }

        private void grdCT_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    DialogResult kq = MessageBox.Show("Bạn chắc xóa dòng này?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //    if (kq == DialogResult.Yes)
            //        grdViewCt_PhieuXuat.DeleteSelectedRows();
            //    //foreach (int i in grdViewCt_PhieuXuat.GetSelectedRows())
            //    //{
            //    //    grdViewCt_PhieuXuat.DeleteRow(i);
            //    //}

            //}
            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
        }

        private void grd_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.Delete)
            //{
            //    DialogResult kq = MessageBox.Show("Bạn chắc xóa dòng này?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            //    if (kq == DialogResult.Yes)
            //        grdView_DinhKhoan.DeleteSelectedRows();
            //}
            HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }



        private void gridLookUpEdit_KhoXuat_EditValueChanged(object sender, EventArgs e)
        {
            //GridLookUpEdit t = (GridLookUpEdit)sender;
            //if (t.EditValue.ToString() != "0" && _phieuXuatVTHH.PhuongPhapNX == 2 && _flag)
            //{
            //    btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            //}
            //else
            //{
            //    btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
            _phieuXuatVTHH.MaKho = (int)gridLookUpEdit_KhoXuat.EditValue;
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
            butToan.DienGiai = _phieuXuatVTHH.DienGiai;
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
                grdViewCt_PhieuXuat.DeleteSelectedRows();//Xoa nhieu dong
                Decimal tongTien = 0;
                foreach (CT_PhieuXuat ct_PhieuXuat in _phieuXuatVTHH.CT_PhieuXuatList)
                {
                    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                }
                _phieuXuatVTHH.GiaTriKho = tongTien;

            }
            else if (Tab_NghiepVuPhieuXuat.SelectedTabPage.Name == "xtraTabPage_ButToan")
                grdView_DinhKhoan.DeleteSelectedRows();
        }

        private void FrmPhieuXuatVatTuHangHoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_phieuXuatVTHH.IsDirty)
            //{
            //    DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    if (kq == DialogResult.Yes)
            //    {
            //        btnLuu.PerformClick();
            //    }
            //    else
            //        if (kq == DialogResult.Cancel)
            //        {
            //            e.Cancel = true;
            //        }
            //}
        }

        private void btnPhieuDeNghi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSPhieuLinhNhienLieu frm = new frmDSPhieuLinhNhienLieu(_phieuXuatVTHH.MaKho, _phieuXuatVTHH.MaPhongBan, _phieuXuatVTHH.NgayNX, 2);
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

        private void lookUpEdit_PhuongPhapNX_EditValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToByte(lookUpEdit_PhuongPhapNX.EditValue) == 1)
            {
                btnPhieuDeNghi.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
            {
                btnPhieuDeNghi.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnChonPNhapXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

            }
            _phieuXuatVTHH.PhuongPhapNX = (byte)lookUpEdit_PhuongPhapNX.EditValue;
            CheckPhuongPhapNX();

        }

        private void grdViewCt_PhieuXuat_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuXuat _ct_PhieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
            _ct_PhieuXuat.DienGiai = _phieuXuatVTHH.DienGiai;
        }

        private void FrmPhieuXuatVatTuHangHoa_Load(object sender, EventArgs e)
        {
         
            formatGriview();
            CheckPhuongPhapNX();
            if (PhieuNhapXuat.KiemTraPhieuXuatTuDSPhieuDeNghiLinh(_phieuXuatVTHH.MaPhieuNhapXuat))
            {
                LockData();
                NotAllowDelete();
            }
            
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuXuat, 35);
            //Utils.GridUtils.InitNewRowOnTopOfGridView(grdViewCt_PhieuXuat);
            //Utils.GridUtils.InitNewRowOnTopOfGridView(grdView_DinhKhoan);
            if (_phieuXuatVTHH.IsNew == false)
            {
                if (_phieuXuatVTHH != null)
                {
                    if (PhieuNhapXuat.KiemTraPhieuXuatThangTuPhieuNhap(_phieuXuatVTHH.MaPhieuNhapXuat))
                    {
                        //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                        LockData();
                    }
                }
            }
            else if (_tu1PhieuNhap)
            {
                //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                LockData();
            }
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
                    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaVatTuHangHoaList();
                    if (cTPhieuXuatListBindingSource.Current == null || grdViewCt_PhieuXuat.GetFocusedRow() == null)
                        grdViewCt_PhieuXuat.AddNewRow();
                    CT_PhieuXuat ct_phieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
                    ct_phieuXuat.MaHangHoa = dlg.MaHangHoaChon;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuXuat.MaHangHoa);
                    ct_phieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                    //grdViewCt_PhieuXuat.RefreshData();
                }

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

        //END Spd_PhieuXuatVatTu

        #endregion//Cac Phuong Thuc Report


    }
}
