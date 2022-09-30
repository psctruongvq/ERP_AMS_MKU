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
using DevExpress.XtraGrid.Views.Grid;
//19/11/2013
namespace PSC_ERP//05012016
{
    public partial class frmPhieuXuatPhanBoCCDC_New : DevExpress.XtraEditors.XtraForm
    {

        /// /////
        KhoBQ_VTList _khoBQ_VTList = null;
        PhieuNhapXuat _phieuXuat = PhieuNhapXuat.NewPhieuNhapXuat();
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        byte _loai = 0;
        DateTime _ngayLapCu;
        //
        public frmPhieuXuatPhanBoCCDC_New()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
        }

        #region frmPhieuXuatPhanBoCCDC(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuXuatPhanBoCCDC_New(PhieuNhapXuat phieuNhapXuat, byte loai)
        {
            InitializeComponent();
            _loai = loai;
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);

            //
            if (_phieuXuat.IsNew)
            {
                XuLyThem();
            }
            //this.TinhTongTienChoPhieuXuat();
        }
        #endregion



        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuXuat = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuXuat.Loai = 3;
            _phieuXuat.LaNhap = false;
            //_phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            TaoSoPhieu();
            //mac dinh kho dau tien trong danh sach
            if (this.khoBQVTListBindingSource.Count != 0)
                _phieuXuat.MaKho = _khoBQ_VTList[0].MaKho;
            //

            cTPhieuXuatListBindingSource.DataSource = _phieuXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;
            congCuDungCuListBindingSource.DataSource = _phieuXuat.CongCuDungCuList;

            _phieuXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuXuat;

            formatGridviewDinhKhoan();
        }

        private void TaoSoPhieu()
        {
            _phieuXuat.SoPhieu = PhieuNhapXuat.Get_NextSoChungTuNhapXuatCongCuDungCu(laNhap: _phieuXuat.LaNhap
                            , maBoPhan: ERP_Library.Security.CurrentUser.Info.MaBoPhan
                            , maQLUser: ERP_Library.Security.CurrentUser.Info.MaQLUser
                            , year: _phieuXuat.NgayNX.Year, size: 4);
        }
        #endregion

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            if (_loai == 0)//truong phieu xuat da ton tai(phieu nhap xuat goi vao la phieu xuat)
            {
                _phieuXuat = phieuNhapXuat;
                _ngayLapCu = _phieuXuat.NgayNX;
            }
            else if (_loai == 1)//phieu xuat chua ton tai, can tao phieu xuat moi(phieu nhap xuat goi vao la phieu nhap)
            {
                //_phieuXuat = PhieuNhapXuat.NewPhieuNhapXuat(phieuNhapXuat);
                _phieuXuat = PhieuNhapXuat.NewPhieuNhapXuat(phieuNhapXuat, 3);
                _phieuXuat.Loai = 3;
                _phieuXuat.LaNhap = false;
                this.TaoSoPhieu();
                _phieuXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            }
            //

            cTPhieuXuatListBindingSource.DataSource = _phieuXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuXuat.ButToanPhieuNhapXuatList;
            congCuDungCuListBindingSource.DataSource = _phieuXuat.CongCuDungCuList;
            phieuNhapXuatBindingSource.DataSource = _phieuXuat;

        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {

            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            hangHoaBQVTListBindingSource1.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            //
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(3);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;


            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            Init_lookUpEdit_PhongBan();

        }
        #endregion


        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuXuat ct_phieuXuat in _phieuXuat.CT_PhieuXuatList)
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

            //Kiem tra but toan
            foreach (ButToanPhieuNhapXuat bt in _phieuXuat.ButToanPhieuNhapXuatList)
            {
                #region Kiểm Tra chi phí sản xuất

                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(bt.CoTaiKhoan);
                string noTK = taiKhoanNo.SoHieuTK;
                string CoTK = taiKhoanCo.SoHieuTK;

                if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.StartsWith("631") || noTK.StartsWith("4314"))
                {
                    if (bt.ChungTu_ChiPhiSanXuatList.Count == 0)
                    {
                        MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        foreach (ChungTu_ChiPhiSanXuat cp in bt.ChungTu_ChiPhiSanXuatList)
                        {
                            if (cp.ButtoanMucNganSachList.Count == 0 && (noTK.StartsWith("631") || noTK.StartsWith("4314")))
                            {
                                MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

                if (bt.ChungTu_ChiPhiSanXuatList.Count > 0)
                {

                    decimal sotienCTu = 0;
                    foreach (ChungTu_ChiPhiSanXuat ct_cp in bt.ChungTu_ChiPhiSanXuatList)
                    {
                        sotienCTu += ct_cp.SoTien;
                    }
                    if (bt.SoTien != sotienCTu)
                    {
                        MessageBox.Show(this, "Tổng số tiền Công việc/Chương trình không bằng số tiền bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; ;
                    }
                }
                #endregion//Kiểm Tra chi phí sản xuất
            }

            return kq;
        }

        private bool KiemTraHopLeDuLieu()
        {
            bool hopLe = true;
            //kiem tra trung so phieu
            if (PhieuNhapXuat.KiemTraTrungSoChungTuNhapXuat(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.SoPhieu))
            {
                if (DialogResult.Yes == MessageBox.Show(this, "Số phiếu " + _phieuXuat.SoPhieu + " đã trùng. Chọn Yes để tự động sinh số phiếu mới", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    this.TaoSoPhieu();
                }
                else
                {
                    this.txtSoPhieu.Focus();
                    hopLe = false;
                }

            }

            if (_phieuXuat.MaPhongBan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_PhongBan.Focus();
                hopLe = false;
            }
            if (_phieuXuat.MaNguoiNhapXuat == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_NhanVien.Focus();
                hopLe = false;
            }
            if (_phieuXuat.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoNhan.Focus();
                hopLe = false;
            }
            if (_phieuXuat.CT_PhieuXuatList.Count == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hopLe = false;
            }
            if (KiemTraChiTiet() == false)
            {
                grdViewCt_PhieuNhap.Focus();
                hopLe = false;
            }

            return hopLe;
        }

        #region Vat Tu_Ban Quyen
        private void anHiencottheoyeucau()
        {
            this.ColMaTieuMuc.Visible = false;
            this.col_btn.Visible = true;
        }
        private void formatGridviewDinhKhoan()
        {
            if (!_phieuXuat.IsNew)
            {
                if (_phieuXuat.ButToanPhieuNhapXuatList.Count > 0)
                {
                    foreach (ButToanPhieuNhapXuat bt in _phieuXuat.ButToanPhieuNhapXuatList)
                    {
                        if (bt.ButToan_MucNganSach.MaCT_ChiPhiSanXuat == 0)
                        {
                            this.ColMaTieuMuc.Visible = true;
                            this.col_btn.Visible = false;
                        }
                        else
                        {
                            anHiencottheoyeucau();
                        }
                    }
                }
                else
                {
                    anHiencottheoyeucau();
                }
            }
            else
            {
                anHiencottheoyeucau();
            }
        }
        #endregion//Vat Tu_Ban Quyen

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
            {
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan((int)lookUpEdit_PhongBan.EditValue);
                foreach (CongCuDungCu ccdc in _phieuXuat.CongCuDungCuList)
                {
                    ccdc.CongCuDungCu_PhongBan.MaBoPhan = Convert.ToInt32(lookUpEdit_PhongBan.EditValue);
                }
            }
        }
        #endregion

        private void Init_lookUpEdit_PhongBan()
        {
            DataTable _dataTable = new DataTable();

            _dataTable.Columns.Add("Ma", typeof(byte));
            _dataTable.Columns.Add("Ten", typeof(string));

            _dataTable.Rows.Add(1, "Bình Quân");
            _dataTable.Rows.Add(2, "Nhập Xuất Thẳng");

            phuongPhapNXbindingSource.DataSource = _dataTable;
            lookUpEdit_PPNXKho.Properties.DataSource = phuongPhapNXbindingSource;
            this.lookUpEdit_PPNXKho.Properties.ValueMember = "Ma";
            this.lookUpEdit_PPNXKho.Properties.DisplayMember = "Ten";
            lookUpEdit_PPNXKho.Properties.NullText = "Không Chọn";
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (_phieuXuat.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSo == true)
                    {
                        MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            Save();
        }

        private bool Save()
        {
            bool result = true;
            this.txtBlackHole.Focus();
            try
            {

                if (KiemTraHopLeDuLieu() == true)
                {

                    if (_phieuXuat.ButToanPhieuNhapXuatList.Count == 0)
                    {
                        if (System.Windows.Forms.DialogResult.Yes != MessageBox.Show("Chưa nhập định khoản! Bạn có muốn lưu phiếu với định khoản rỗng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            result = false;//khong chap nhan luu trong khi dinh khoan chua nhap
                        }
                    }

                    if (result == true)
                    {
                        phieuNhapXuatBindingSource.EndEdit();
                        _phieuXuat.ApplyEdit();
                        _phieuXuat.Save();
                        _ngayLapCu = _phieuXuat.NgayNX;
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = false;
            }
            return result;
        }

        #region lookUpEdit_PPNXKho_EditValueChanged
        private void lookUpEdit_PPNXKho_EditValueChanged(object sender, EventArgs e)
        {

            //
            if ((byte)(lookUpEdit_PPNXKho.EditValue) == 1)//binh quan
            {
                this.btnChonPhieuNhapThang.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;//an
            }
            else if ((byte)(lookUpEdit_PPNXKho.EditValue) == 2)//thang
            {
                this.btnChonPhieuNhapThang.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;//hien
            }


            //if ((byte)(lookUpEdit_PPNXKho.EditValue) == 1)
            //{
            //    barBt_LapPhieuXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            //}
            //else
            //    barBt_LapPhieuXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        #endregion

        #region grdViewCt_PhieuNhap_CellValueChanged
        private void grdViewCt_PhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.RowHandle >= 0)
            //{

            CT_PhieuXuat ct_PhieuXuat = (CT_PhieuXuat)(cTPhieuXuatListBindingSource.Current);

            //kiem tra so luong ton con du de xuat hay ko
            //tinh lai thanh tien cho tung ccdc
            if (Object.ReferenceEquals(e.Column, this.colSoLuong))//(grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong")
            {
                if (_phieuXuat.PhuongPhapNX == 2)//
                {
                    //decimal _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaNhapThang(_phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                    decimal _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaNXT(_phieuXuat.MaPhieuNhapXuat, ct_PhieuXuat.MaPhieuNhap, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime, ct_PhieuXuat.DonGia, ct_PhieuXuat.MaChiTietPhieuNhap,ct_PhieuXuat.MaCT_KetChuyen,ct_PhieuXuat.MaCT_KetChuyenCCDC);//New 19112013
                    if ((decimal)e.Value > _soLuongHienCo)
                    {
                        MessageBox.Show(String.Format("Không đủ {0}. Số lượng chỉ còn {1}.", e.Value.ToString(), _soLuongHienCo.ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, "SoLuong", _soLuongHienCo as object);//grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                    }
                    else if ((decimal)e.Value == _soLuongHienCo)
                    {
                        grdCT_PhieuNhap.Update();
                        //ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoa(_phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaNXT(_phieuXuat.MaPhieuNhapXuat, ct_PhieuXuat.MaPhieuNhap, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime, ct_PhieuXuat.DonGia, ct_PhieuXuat.MaChiTietPhieuNhap,ct_PhieuXuat.MaCT_KetChuyen);//New 19112013
                    }
                }
                else
                {
                    //decimal _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoa(_phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                    decimal _soLuongHienCo = HangHoaBQ_VT.GetSoLuongHangHoaBinhQuan(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                    if ((decimal)e.Value > _soLuongHienCo)
                    {
                        MessageBox.Show(String.Format("Không đủ {0}. Số lượng chỉ còn {1}.", e.Value.ToString(), _soLuongHienCo.ToString()), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, this.colSoLuong, 0);//grdViewCt_PhieuNhap.SetRowCellValue(e.RowHandle, "SoLuong", (object)_soLuongHienCo); //# _ct_PhieuXuat.SoLuong = _soLuongHienCo;
                    }
                    else if ((decimal)e.Value == _soLuongHienCo)
                    {
                        grdCT_PhieuNhap.Update();
                        //ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoa(_phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                        ct_PhieuXuat.ThanhTien = HangHoaBQ_VT.GetGiaTriHangHoaBinhQuan(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                    }
                }
            }

            //---------------------------------
            if (Object.ReferenceEquals(e.Column, this.colMaHangHoa) || Object.ReferenceEquals(e.Column, this.colSoLuong)) //(grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong")
            {

                //ct_PhieuXuat.DonGia = HangHoaBQ_VT.GetGiaBinhQuan(_phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                if (_phieuXuat.PhuongPhapNX == 1)//
                {
                    ct_PhieuXuat.DonGia = HangHoaBQ_VT.GetGiaTriBinhQuanHangHoa(_phieuXuat.MaPhieuNhapXuat, _phieuXuat.MaKho, ct_PhieuXuat.MaHangHoa, dateEdit_NgayLap.DateTime);
                }
                //tinh thanh tien cho chi tiet
                ct_PhieuXuat.ThanhTien = CT_PhieuXuat.TinhThanhTien(ct_PhieuXuat.SoLuong, ct_PhieuXuat.DonGia);

                int maHangHoa = 0;
                for (int j = 0; j < grdv_CongCuDungCu.RowCount; j++)//duyet qua tung ccdc
                {
                    CongCuDungCu congCuDungCu = grdv_CongCuDungCu.GetRow(j) as CongCuDungCu;
                    int flag = 0;
                    if (maHangHoa == 0)
                    {
                        foreach (CT_PhieuXuat ct in _phieuXuat.CT_PhieuXuatList)
                        {
                            if (congCuDungCu.MaHangHoa == ct.MaHangHoa && congCuDungCu.NguyenGia == ct.DonGia)
                            {
                                flag++;
                                break;
                            }
                        }
                        //
                        if (flag == 0)
                        {
                            maHangHoa = congCuDungCu.MaHangHoa;
                            grdv_CongCuDungCu.DeleteRow(j);
                            j--;
                        }
                        else if (ct_PhieuXuat.MaHangHoa == congCuDungCu.MaHangHoa && congCuDungCu.NguyenGia == ct_PhieuXuat.DonGia)
                        {
                            grdv_CongCuDungCu.DeleteRow(j);
                            j--;
                        }
                    }
                    else if ((congCuDungCu.MaHangHoa == maHangHoa || ct_PhieuXuat.MaHangHoa == congCuDungCu.MaHangHoa)
                        && congCuDungCu.NguyenGia == ct_PhieuXuat.DonGia)
                    {
                        grdv_CongCuDungCu.DeleteRow(j);
                        j--;
                    }
                }

                //tao cac ccdc ca biet

                TaoCCDCCaBiet(ct_PhieuXuat, Convert.ToInt32(lookUpEdit_PhongBan.EditValue), null);
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colDonGia")
            {
                foreach (CongCuDungCu congCuDungCu in _phieuXuat.CongCuDungCuList)
                {
                    if (congCuDungCu.MaHangHoa == ct_PhieuXuat.MaHangHoa)
                    {
                        congCuDungCu.NguyenGia = ct_PhieuXuat.DonGia;
                    }
                }
            }
            //---------------------------


            //----------------------------
            congCuDungCuListBindingSource.EndEdit();
            grdv_CongCuDungCu.RefreshData();
            //--------------------------------
            //tính lai tong tien cua phieu xuat
            if (Object.ReferenceEquals(e.Column, this.colSoLuong) || Object.ReferenceEquals(e.Column, this.colDonGia))//(grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colDonGia")
            {
                TinhTongTienChoPhieuXuat();
            }
            //}
        }

        private void TinhTongTienChoPhieuXuat()
        {

            Decimal tongTien = 0;
            foreach (CT_PhieuXuat ct in _phieuXuat.CT_PhieuXuatList)
            {
                tongTien = tongTien + ct.ThanhTien;
            }
            _phieuXuat.GiaTriKho = tongTien;
        }

        private CongCuDungCu TaoCCDCCaBiet(CT_PhieuXuat ct_PhieuXuat, int maPhongBan, CongCuDungCu ccdc)
        {
            #region Old
            //String maxSoHieu = "";
            //if (ct_PhieuXuat.SoLuong != 0)
            //{
            //    int thuTuMaQuanLyCCDC;
            //    string maQuanLyCCDC = "";

            //    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuXuat.MaHangHoa);
            //    ct_PhieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;

            //    if (ccdc == null)
            //    {
            //        //lay cong cu dung cu sau cung thuoc hang hoa
            //        ccdc = CongCuDungCu.GetCongCuDungCuByMaHangHoa(hangHoa.MaHangHoa);

            //    }
            //    maxSoHieu = ccdc.MaQuanLy;


            //    if (String.IsNullOrWhiteSpace(maxSoHieu) == false)
            //    {
            //        thuTuMaQuanLyCCDC = Convert.ToInt32(maxSoHieu.Substring(maxSoHieu.Length - 4)) + 1;//tang len 1 don vi
            //    }
            //    else
            //    {
            //        thuTuMaQuanLyCCDC = 1;//cong cu dau tien thuoc hang hoa
            //    }
            //    Int32 size = 4;

            //    for (int i = 0; i < ct_PhieuXuat.SoLuong; i++)
            //    {
            //        String phanTangStr = new String('0', size - thuTuMaQuanLyCCDC.ToString().Length) + thuTuMaQuanLyCCDC.ToString();
            //        maQuanLyCCDC = hangHoa.MaQuanLy + phanTangStr;


            //        /*
            //        if (thuTuMaQuanLyCCDC < 10)
            //            maQuanLyCCDC = hangHoa.MaQuanLy + "000" + thuTuMaQuanLyCCDC.ToString();
            //        else if (thuTuMaQuanLyCCDC < 100)
            //            maQuanLyCCDC = hangHoa.MaQuanLy + "00" + thuTuMaQuanLyCCDC.ToString();
            //        else if (thuTuMaQuanLyCCDC < 1000)
            //            maQuanLyCCDC = hangHoa.MaQuanLy + "0" + thuTuMaQuanLyCCDC.ToString();
            //        else if (thuTuMaQuanLyCCDC < 10000)
            //            maQuanLyCCDC = hangHoa.MaQuanLy + thuTuMaQuanLyCCDC.ToString();
            //        */
            //        CongCuDungCu cc = CongCuDungCu.NewCongCuDungCu(maQuanLyCCDC, "", maPhongBan, hangHoa.MaHangHoa, ct_PhieuXuat.DonGia, Convert.ToDateTime(dateEdit_NgayLap.EditValue), Convert.ToDecimal(txt_PhanTramPhanBo.EditValue));
            //        cc.NgayNhan = DateTime.Now.Date;
            //        _phieuXuat.CongCuDungCuList.Add(cc);
            //        thuTuMaQuanLyCCDC = thuTuMaQuanLyCCDC + 1;//tang len 1 don vi
            //        ccdc = cc;
            //    }
            //}
            //return ccdc;
            #endregion

            #region New
            String maxSoHieu = "";
            if (ct_PhieuXuat != null && ct_PhieuXuat.SoLuong != 0)
            {
                int thuTuMaQuanLyCCDC;
                string maQuanLyCCDC = "";
                string maQuanLy = "";
                string nam = _phieuXuat.NgayNX.Year.ToString().Substring(2, 2);

                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_PhieuXuat.MaHangHoa);
                ct_PhieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;

                if (ccdc == null)
                {
                    //lay cong cu dung cu sau cung thuoc hang hoa
                    ccdc = CongCuDungCu.GetCongCuDungCuByMaHangHoa(hangHoa.MaHangHoa);

                }
                if (ccdc != null)
                    maxSoHieu = ccdc.MaQuanLy;
                if (String.IsNullOrWhiteSpace(maxSoHieu) == false)
                {
                    thuTuMaQuanLyCCDC = Convert.ToInt32(maxSoHieu.Substring(maxSoHieu.Length - 4)) + 1;//tang len 1 don vi
                    //maQuanLy = nam + ccdc.MaQuanLy.Substring(0, ccdc.MaQuanLy.Length - 4).Substring(2, ccdc.MaQuanLy.Length - 6);
                    //maQuanLy = nam + '.' + hangHoa.MaQuanLy.Substring(0, 7) + '.';//congCu.MaQuanLy.Substring(0, congCu.MaQuanLy.Length - 4).Substring(2, congCu.MaQuanLy.Length - 6);
                }
                else
                {
                    thuTuMaQuanLyCCDC = 1;//cong cu dau tien thuoc hang hoa
                    //maQuanLy = nam + '.' + (NhomHangHoaBQ_VT.GetNhomHangHoaBQ_VT(hangHoa.MaNhomHangHoa)).MaQuanLy + '.';
                    //maQuanLy = nam + '.' + hangHoa.MaQuanLy + '.';
                    //maQuanLy = nam + '.' + hangHoa.MaQuanLy.Substring(0, 7) + '.';
                }

                maQuanLy = hangHoa.MaQuanLy;

                Int32 size = 4;

                for (int i = 0; i < ct_PhieuXuat.SoLuong; i++)
                {
                    String phanTangStr = new String('0', size - thuTuMaQuanLyCCDC.ToString().Length) + thuTuMaQuanLyCCDC.ToString();
                    maQuanLyCCDC = maQuanLy + phanTangStr;
                    CongCuDungCu cc = CongCuDungCu.NewCongCuDungCu(maQuanLyCCDC, "", maPhongBan, hangHoa.MaHangHoa, ct_PhieuXuat.DonGia, Convert.ToDateTime(dateEdit_NgayLap.EditValue), Convert.ToDecimal(txt_PhanTramPhanBo.EditValue));
                    cc.NgayNhan = DateTime.Now.Date;
                    _phieuXuat.CongCuDungCuList.Add(cc);
                    thuTuMaQuanLyCCDC = thuTuMaQuanLyCCDC + 1;//tang len 1 don vi
                    ccdc = cc;
                }
            }
            return ccdc;
            #endregion
        }
        #endregion

        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuXuat.IsNew || _phieuXuat.HoaDon_NhapXuatList.Count == 0)
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuXuat.MaDoiTac);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                    }
                }
            }
            else
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuXuat);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _phieuXuat.ApplyEdit();
                        _phieuXuat.Save();
                    }
                }
            }
        }
        #endregion

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoPhieu();
        }

        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            // Gan tien cho but toan
            ButToanPhieuNhapXuat butToan = (ButToanPhieuNhapXuat)(butToanPhieuNhapXuatListBindingSource.Current);
            decimal soTienConLai = _phieuXuat.GiaTriKho;
            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuXuat.ButToanPhieuNhapXuatList)
            {
                soTienConLai = soTienConLai - buttoanphieu.SoTien;
            }
            butToan.SoTien = soTienConLai;
            butToan.MaDoiTuongCo = _phieuXuat.MaDoiTac;

            //
            butToan.DienGiai = this.txtDienGiai.Text;
        }

        private void grdViewCt_PhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các dòng chi tiết phiếu xuất đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                    {
                        CT_PhieuXuat ct_Phieu = _phieuXuat.CT_PhieuXuatList[i];
                        for (int j = 0; j < grdv_CongCuDungCu.RowCount; j++)
                        {
                            CongCuDungCu congCu = grdv_CongCuDungCu.GetRow(j) as CongCuDungCu;
                            if (congCu.MaHangHoa == ct_Phieu.MaHangHoa)
                            {

                                grdv_CongCuDungCu.DeleteRow(j);
                                j--;
                            }

                        }
                        _phieuXuat.GiaTriKho = _phieuXuat.GiaTriKho - ct_Phieu.ThanhTien;
                        grdViewCt_PhieuNhap.DeleteRow(i);
                    }
                }
                else if (e.KeyCode == Keys.Tab)
                {
                    if (grdViewCt_PhieuNhap.FocusedRowHandle < 0)
                    {
                        grdViewCt_PhieuNhap.MoveFirst();
                    }
                }
            }
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các bút toán định khoản đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (int i in grdView_DinhKhoan.GetSelectedRows())
                    {
                        grdView_DinhKhoan.DeleteRow(i);
                    }
                }
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (grdView_DinhKhoan.FocusedRowHandle < 0)
                {
                    grdView_DinhKhoan.MoveFirst();
                }
            }
        }

        #region barBt_LapPhieuXuat_ItemClick
        private void barBt_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        #endregion

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Rpt_BienBanGiaoNhanCongCuDungCu rpt = new Rpt_BienBanGiaoNhanCongCuDungCu(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.MaPhongBan);
            //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();
        }


        private void btnPrint_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        #region Cac Ham cho RePort
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
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuXuat.MaPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", _phieuXuat.MaPhongBan);

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

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
            {
                CT_PhieuXuat ct_Phieu = _phieuXuat.CT_PhieuXuatList[i];
                for (int j = 0; j < grdv_CongCuDungCu.RowCount; j++)
                {
                    CongCuDungCu congCu = grdv_CongCuDungCu.GetRow(j) as CongCuDungCu;
                    if (congCu.MaHangHoa == ct_Phieu.MaHangHoa)
                    {

                        grdv_CongCuDungCu.DeleteRow(j);
                        j--;
                    }

                }

                grdViewCt_PhieuNhap.DeleteRow(i);
            }
        }



        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void txt_PhanTramPhanBo_EditValueChanged(object sender, EventArgs e)
        {

        }

        #endregion//END Cac Ham cho RePort
        private void frmPhieuXuatPhanBoCCDC_Load(object sender, EventArgs e)
        {

            Utils.GridUtils.ConfigGridView(grdViewCt_PhieuNhap
                     , setSTT: true//
                     , initCopyCell: true//
                     , multiSelectCell: true//
                     , multiSelectRow: false
                     , initNewRowOnTop: false);//
            Utils.GridUtils.ConfigGridView(grdv_CongCuDungCu
            , setSTT: true//
            , initCopyCell: true//
            , multiSelectCell: true//
            , multiSelectRow: false
            , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(grdView_DinhKhoan
             , setSTT: true//
             , initCopyCell: true//
             , multiSelectCell: true//
             , multiSelectRow: false
             , initNewRowOnTop: false);//


            formatGridviewDinhKhoan();
        }

        private void btnChonPhieuNhapThang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (_phieuXuat.MaKho != 0)
            {
                CT_PhieuXuatList ct_phieuxuatListNew = CT_PhieuXuatList.NewCT_PhieuXuatList();//--BS

                frmDialogDSPhieuNhapCCDC frm = new frmDialogDSPhieuNhapCCDC(_phieuXuat.MaKho, _phieuXuat.PhuongPhapNX);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CT_PhieuNhapList dsPhieuNhap = frm.DSChiTietPhieuNhapDaChon;
                    foreach (CT_PhieuNhap ct_PhieuNhap in dsPhieuNhap)
                    {
                        #region Old
                        ////CT_PhieuXuat ctPhieuXuat = new CT_PhieuXuat(ct_PhieuNhap, _phieuXuat.MaKho, _phieuXuat.NgayNX);
                        //CT_PhieuXuat ctPhieuXuat = new CT_PhieuXuat(ct_PhieuNhap, _phieuXuat.NgayNX);
                        //ctPhieuXuat.DienGiai = this.txtDienGiai.Text;
                        //_phieuXuat.CT_PhieuXuatList.Add(ctPhieuXuat);
                        #endregion//Old

                        #region New

                        if (ct_PhieuNhap.SoLuong > ct_PhieuNhap.SoLuongXuat)
                        {
                            CT_PhieuXuat ct_PhieuXuat = new CT_PhieuXuat(ct_PhieuNhap, _phieuXuat.NgayNX);
                            bool insert = true;
                            if (grdViewCt_PhieuNhap.RowCount > 0)
                            {
                                for (int i = 0; i < grdViewCt_PhieuNhap.RowCount; i++)
                                {
                                    if (grdViewCt_PhieuNhap.GetRow(i) != null)
                                    {
                                        CT_PhieuXuat ct_px_gv = (CT_PhieuXuat)grdViewCt_PhieuNhap.GetRow(i);
                                        if (ct_px_gv.MaHangHoa == ct_PhieuXuat.MaHangHoa
                                            && ct_px_gv.MaPhieuNhap == ct_PhieuXuat.MaPhieuNhap
                                            && ct_px_gv.DonGia == ct_PhieuXuat.DonGia//New 19112013
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
                                ct_PhieuXuat.DienGiai = this.txtDienGiai.Text;
                                _phieuXuat.CT_PhieuXuatList.Add(ct_PhieuXuat);
                                ct_phieuxuatListNew.Add(ct_PhieuXuat);//--BS
                            }
                        }
                        #endregion//New




                        //XuLyThem();
                        XuLyTaoCCDCCaBiet(ct_phieuxuatListNew);
                        this.TinhTongTienChoPhieuXuat();
                        tabControl_CCDC.SelectedTabPage = tabControl_CCDC.TabPages[1];
                    }
                }
            }
            else
            {
                MessageBox.Show("Cần chọn kho trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void XuLyTaoCCDCCaBiet(CT_PhieuXuatList list)
        {
            foreach (CT_PhieuXuat item in list)//(CT_PhieuXuat item in _phieuXuat.CT_PhieuXuatList)
            {
                CongCuDungCu ccdc = null;

                ccdc = TaoCCDCCaBiet(item, _phieuXuat.MaPhongBan, ccdc);
            }
        }

        private void XuLyThem()
        {

            CongCuDungCu ccdc = null;
            int preMaHangHoa = 0;
            Queue<int> maHangHoaQueueDistinct = new Queue<int>();
            Queue<CT_PhieuXuat> chiTietPhieuXuatSortedQueue = new Queue<CT_PhieuXuat>();
            foreach (CT_PhieuXuat item in _phieuXuat.CT_PhieuXuatList)
            {
                if (maHangHoaQueueDistinct.Contains(item.MaHangHoa) == false)
                {
                    maHangHoaQueueDistinct.Enqueue(item.MaHangHoa);
                    foreach (CT_PhieuXuat x in _phieuXuat.CT_PhieuXuatList)
                    {
                        if (x.MaHangHoa == item.MaHangHoa)
                            chiTietPhieuXuatSortedQueue.Enqueue(x);
                    }
                }

            }

            foreach (CT_PhieuXuat item in chiTietPhieuXuatSortedQueue)//(CT_PhieuXuat item in _phieuXuat.CT_PhieuXuatList)
            {
                //decimal soLuongTheoMaHangHoa = 0;
                //foreach (CT_PhieuXuat x in _phieuXuat.CT_PhieuXuatList)
                //{
                //    if (x.MaHangHoa == item.MaHangHoa)
                //        soLuongTheoMaHangHoa += x.SoLuong;
                //}
                if (item.MaHangHoa != preMaHangHoa)
                    ccdc = null;

                ccdc = TaoCCDCCaBiet(item, _phieuXuat.MaPhongBan, ccdc);
                preMaHangHoa = item.MaHangHoa;
            }
        }

        private void grdViewCt_PhieuNhap_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            if (_phieuXuat.PhuongPhapNX == 2)//xuat thang
            {
                this.grdViewCt_PhieuNhap.DeleteRow(e.RowHandle);
            }
            else if (_phieuXuat.PhuongPhapNX == 1)
            {
                CT_PhieuXuat ct = this.cTPhieuXuatListBindingSource.Current as CT_PhieuXuat;
                ct.DienGiai = this.txtDienGiai.Text;
            }
        }

        private void grdViewCt_PhieuNhap_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //CT_PhieuXuat ct_px = this.cTPhieuXuatListBindingSource.Current as CT_PhieuXuat;
            //if (e.RowHandle >= 0 && ct_px.IsNew != true)
            //{
            //    if (false == Object.ReferenceEquals(e.Column, this.colDienGiai))
            //    {
            //        SendKeys.Send("{ESC}");//khong cho edit
            //    }
            //}
        }

        private void grdViewCt_PhieuNhap_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            //BaseEdit edit = (sender as GridView).ActiveEditor;
            //object oldValue = edit.OldEditValue;
            //object newValue = e.Value;


        }

        private void lookUpEdit_PPNXKho_Validating(object sender, CancelEventArgs e)
        {
            for (int i = 0; i < _phieuXuat.CT_PhieuXuatList.Count; i++)
            {
                CT_PhieuXuat ct_Phieu = _phieuXuat.CT_PhieuXuatList[i];
                for (int j = 0; j < grdv_CongCuDungCu.RowCount; j++)
                {
                    CongCuDungCu congCu = grdv_CongCuDungCu.GetRow(j) as CongCuDungCu;
                    if (congCu.MaHangHoa == ct_Phieu.MaHangHoa)
                    {

                        grdv_CongCuDungCu.DeleteRow(j);
                        j--;
                    }

                }

                grdViewCt_PhieuNhap.DeleteRow(i);
            }
        }

        private void grdv_CongCuDungCu_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (object.ReferenceEquals(e.Column, this.colPhanTramPBLanDau))//A
                {

                    //MessageBox.Show("Test");
                    decimal nguyenGia = (decimal)grdv_CongCuDungCu.GetRowCellValue(e.RowHandle, this.colNguyenGia);
                    decimal phanTram = (decimal)e.Value;
                    decimal soTienPhanBo = TinhSoTienPhanBo(phanTram, nguyenGia);
                    if (soTienPhanBo > nguyenGia)
                    {
                        soTienPhanBo = nguyenGia;

                    }
                    //khi so tien phan bo duoc gan vao luoi
                    //phan tram phan bo se duoc tinh toan lai o //B
                    grdv_CongCuDungCu.SetRowCellValue(e.RowHandle, this.colChiPhiPBLanDau, soTienPhanBo);
                }
                else if (object.ReferenceEquals(e.Column, this.colChiPhiPBLanDau))//B
                {
                    decimal nguyenGia = (decimal)grdv_CongCuDungCu.GetRowCellValue(e.RowHandle, this.colNguyenGia);
                    decimal soTienPhanBo = (decimal)e.Value;
                    decimal phanTramMoi = TinhPhanTram(nguyenGia, soTienPhanBo);
                    decimal phanTramCu = (decimal)grdv_CongCuDungCu.GetRowCellValue(e.RowHandle, this.colPhanTramPBLanDau);
                    if (phanTramMoi != phanTramCu)//tranh vong lap vo tan
                    {
                        grdv_CongCuDungCu.SetRowCellValue(e.RowHandle, colPhanTramPBLanDau, phanTramMoi);
                    }


                }
            }
        }
        private decimal TinhSoTienPhanBo(decimal phanTram, decimal nguyenGia)
        {
            decimal returnValue = Math.Round(phanTram * nguyenGia / 100);
            return returnValue;
        }
        private decimal TinhPhanTram(decimal nguyenGia, decimal soTienPhanBo)
        {
            decimal returnValue = Math.Round(soTienPhanBo / (nguyenGia / 100), 2);
            return returnValue;
        }

        private void frmPhieuXuatPhanBoCCDC_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_phieuXuat != null && (_phieuXuat.IsDirty || _phieuXuat.IsNew))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn lưu trước khi thoát?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult.Yes == result)
                {

                    if (this.Save() == false)
                        e.Cancel = true;
                }
                else if (DialogResult.No == result)
                {

                }
                else if (DialogResult.Cancel == result)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuXuat;
            if (pnx != null)
            {
                //
                KhoaSo_UserList khoa;
                if (pnx.IsNew)
                {
                    khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(pnx.NgayNX);
                }
                else
                {
                    khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                }
                //  
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
                //Delete Phieu
                if (MessageBox.Show(this, "Bạn muốn xóa Phiếu này?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        PhieuNhapXuat.DeletePhieuNhapXuat(_phieuXuat);
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

        private void grdView_DinhKhoan_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "col_btn")
            {
                if (((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current) != null)
                {
                    //Xu ly Tai day
                    ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).BeginEdit();
                    ButToanPhieuNhapXuat bt = (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current;
                    ChungTu_ChiPhiSanXuatList cpList = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList;
                    cpList.BeginEdit();
                    frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuXuat.NgayNX, bt.DienGiai, bt.MaButToan);
                    if (f.ShowDialog(this) != DialogResult.OK)
                    {
                        if (f.IsSave == true)
                        {
                            ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList = f._ChungTu_ChiPhiSXList;
                            ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList.ApplyEdit();

                        }
                        else
                        {
                            cpList.CancelEdit();
                        }
                    }
                    //
                }
            }
        }


    }
}