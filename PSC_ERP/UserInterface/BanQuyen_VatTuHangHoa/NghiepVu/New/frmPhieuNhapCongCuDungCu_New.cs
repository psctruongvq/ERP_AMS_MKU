using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;


namespace PSC_ERP
{
    public partial class frmPhieuNhapCongCuDungCu_New : DevExpress.XtraEditors.XtraForm
    {
        //public class GridHandlerEx : DevExpress.XtraGrid.Views.Grid.Handler.GridHandler
        //{
        //    private GridView _gridView;
        //    public event KeyEventHandler KeyDown;
        //    public GridHandlerEx(GridView gridView)
        //        : base(gridView)
        //    {
        //        _gridView = gridView;

        //    }

        //    protected override void OnKeyDown(KeyEventArgs e)
        //    {

        //        base.OnKeyDown(e);
        //        if (KeyDown != null)
        //        {
        //            KeyDown(_gridView, e);
        //        }
        //    }
        //}

        
        PhieuNhapXuat _phieuNhap = PhieuNhapXuat.NewPhieuNhapXuat();
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        KhoBQ_VTList _khoBQ_VTList = KhoBQ_VTList.NewKhoBQ_VTList();
        BoPhanList _boPhanList = BoPhanList.NewBoPhanList();
        ChungTu_HoaDonList _chungTu_HoaDonList = ChungTu_HoaDonList.NewChungTu_HoaDonList();
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        //Add to 11012013
        DateTime _ngayLapCu;
        //End Add to 11012013
        //

        public frmPhieuNhapCongCuDungCu_New()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
        }

        #region frmPhieuNhapCongCuDungCu(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuNhapCongCuDungCu_New(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }
        #endregion

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuNhap = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuNhap.Loai = 3;//loai nhap xuat cong cu dung cu
            cTPhieuNhapListBindingSource.DataSource = _phieuNhap.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhap.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhap.HoaDon_NhapXuatList;

            _phieuNhap.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhap;
            _phieuNhap.LaNhap = true;
            //tao so chung tu
            TaoSoPhieu();
            if (_khoBQ_VTList.Count != 0)
                _phieuNhap.MaKho = _khoBQ_VTList[0].MaKho;
            //if (_boPhanList.Count != 0)
            //    _phieuNhap.MaPhongBan = _boPhanList[0].MaBoPhan;

        }

        private void TaoSoPhieu()
        {
            _phieuNhap.SoPhieu = PhieuNhapXuat.Get_NextSoChungTuNhapXuatCongCuDungCu(laNhap: _phieuNhap.LaNhap
         , maBoPhan: ERP_Library.Security.CurrentUser.Info.MaBoPhan
         , maQLUser: ERP_Library.Security.CurrentUser.Info.MaQLUser
         , year: _phieuNhap.NgayNX.Year, size: 4);
        }
        #endregion

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            _phieuNhap = phieuNhapXuat;
            cTPhieuNhapListBindingSource.DataSource = _phieuNhap.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhap.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhap.HoaDon_NhapXuatList;

            _phieuNhap.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhap;
            _phieuNhap.LaNhap = true;
            //Add to 11012013
            _ngayLapCu=_phieuNhap.NgayNX;
            //End Add to 11012013
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhap.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (taiKhoan.SoHieuTK.StartsWith("3113"))
                    foreach (ChungTu_HoaDon ct_hd in _butToan.ChungTu_HoaDonList)
                        _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
            }
        }
        #endregion               

        #region KhoiTao()
        private void KhoiTao()
        {
            //PhieuNhapXuatList_bindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            _boPhanList = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();//.GetBoPhanList();
            boPhanListBindingSource.DataSource = _boPhanList;
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(3);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;

            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            doiTacNoListBindingSource.DataSource = _DoiTacList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            Init_lookUpEdit_PhongBan();

        }
        #endregion


        #region BoSung KhoaSoThue
        private void FormatFormTheoKhoaSoThue()
        {
            //if (KhoaSoThue())
            //{
            //    btn_HoaDon.Enabled = false;
            //    if (_phieuNhap.IsNew)
            //    {
            //        _phieuNhap.HoaDon_NhapXuatList.Clear();
            //    }
            //}
            //else
            //{
            //    btn_HoaDon.Enabled = true;
            //}
        }//Them

        private void LockgrdView_DinhKhoan()
        {

            grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = false;
            grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = false;
            grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = false;
            grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = false;
            grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = false;//
            //grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = false;

        }//Them

        private void UnLockgrdView_DinhKhoan()
        {

            grdView_DinhKhoan.Columns["NoTaiKhoan"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["CoTaiKhoan"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["SoTien"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["MaDoiTuongCo"].OptionsColumn.AllowEdit = true;
            grdView_DinhKhoan.Columns["MaDoiTuongNo"].OptionsColumn.AllowEdit = true;//
            //grdView_DinhKhoan.Columns["DienGiai"].OptionsColumn.AllowEdit = true;
        }//Them

        private void EventRowOrColumnGrdView_DinhKhoanChange()
        {
            if (KhoaSoThue())
            {
                if (grdView_DinhKhoan.GetFocusedRow() != null)
                {
                    ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetFocusedRow();
                    HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                    if (tk.SoHieuTK.StartsWith("3113"))
                    {
                        LockgrdView_DinhKhoan();
                    }
                    else
                    {
                        UnLockgrdView_DinhKhoan();
                    }
                }
            }
            else
            {
                UnLockgrdView_DinhKhoan();
            }


        }//Them

        private bool CheckCoTaiKhoanThueTrongButToan()
        {
            foreach (ButToanPhieuNhapXuat buttoan in _phieuNhap.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                if (tk.SoHieuTK.StartsWith("3113"))
                {
                    return true;
                }
            }
            return false;
        }//Them

        private bool KhoaSoThue()
        {
            bool khoasothue = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhap.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSoThue == true)
                {
                    khoasothue = true;
                }
            }
            //
            if (khoasothue == false && _phieuNhap.IsNew == false)
            {
                khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSoThue == true)
                    {
                        khoasothue = true;
                    }
                }
            }
            return khoasothue;
        }//Them

        private bool CheckValidKhoaSoThueWhenChangeNgayNX()//Them
        {
            if (_phieuNhap.IsNew == false)
            {
                bool khoasotheoNgaylapcu = false;
                bool khoasotheoNgayNX = false;
                //duyet  theo ngay lap cu
                KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_ngayLapCu);
                if (khoa.Count > 0)
                {
                    if (khoa[0].KhoaSoThue == true)
                    {
                        khoasotheoNgaylapcu = true;
                    }
                }

                if (khoasotheoNgaylapcu)
                {
                    foreach (ButToanPhieuNhapXuat buttoan in _phieuNhap.ButToanPhieuNhapXuatList)
                    {
                        HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                        if (tk.SoHieuTK.StartsWith("3113"))
                        {
                            MessageBox.Show("Ngày lập phiếu đã Khóa sổ Thuế, không thể thay đổi", "Thông Báo");
                            _phieuNhap.NgayNX = _ngayLapCu;
                            dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                            return false;
                        }
                    }
                }
                else
                {
                    //duyet  theo ngay nhap xuat
                    KhoaSo_UserList khoa_NgayNX = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhap.NgayNX);
                    if (khoa_NgayNX.Count > 0)
                    {
                        if (khoa_NgayNX[0].KhoaSoThue == true)
                        {
                            khoasotheoNgayNX = true;
                        }
                    }

                    if (khoasotheoNgayNX)
                    {
                        foreach (ButToanPhieuNhapXuat buttoan in _phieuNhap.ButToanPhieuNhapXuatList)
                        {
                            HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                            if (tk.SoHieuTK.StartsWith("3113"))
                            {
                                MessageBox.Show("Ngày thay đổi rơi vào ngày Khóa sổ Thuế, không thể thực hiện", "Thông Báo");
                                _phieuNhap.NgayNX = _ngayLapCu;
                                dateEdit_NgayLap.EditValue = _ngayLapCu as object;
                                return false;
                            }
                        }
                    }

                }
            }

            return true;
        }

        #endregion//BoSung KhoaSoThue

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan((int)lookUpEdit_PhongBan.EditValue);//.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
            _phieuNhap.MaPhongBan = (int)lookUpEdit_PhongBan.EditValue;
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

        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_PhieuNhap ct_phieuNhap in _phieuNhap.CT_PhieuNhapList)
            {
                if (ct_phieuNhap.SoLuong == 0)
                    kq = false;
            }
            return kq;
        }

        private bool KiemTraHopLe()
        {
            bool kq = false;

            int tmp;

            if (String.IsNullOrEmpty(txtSoPhieu.Text))
            {

                txtSoPhieu.Focus();
                MessageBox.Show(this, "Số phiếu không thể rỗng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (false == int.TryParse(txtSoPhieu.Text.Substring(0, 4), out tmp))
            {
                txtSoPhieu.Focus();
                MessageBox.Show("Số phiếu không hợp lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (true == PhieuNhapXuat.KiemTraTrungSoChungTuNhapXuat(_phieuNhap.MaPhieuNhapXuat, _phieuNhap.SoPhieu))//IF 5
            {
                txtSoPhieu.Focus();
                MessageBox.Show("Trùng số phiếu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (_phieuNhap.MaDoiTac == 0)
            {
                lookUpEdit_DoiTac.Focus();
                MessageBox.Show(this, "Vui lòng chọn Nhà cung cấp", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (_phieuNhap.MaPhongBan == 0)
            {
                lookUpEdit_PhongBan.Focus();
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            //chi Tú yeu cau nguoi ban giao co the de trong nen vai dong duoi day khong duoc sd nua
            //////else if (_phieuNhap.MaNguoiNhapXuat == 0)
            //////{
            //////    MessageBox.Show(this, "Vui long chọn nguoi ban giao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //////    lookUpEdit_NhanVien.Focus();
            //////}
            else if (_phieuNhap.MaKho == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn kho nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit_KhoNhan.Focus();
            }
            else if (_phieuNhap.CT_PhieuNhapList.Count == 0)
            {
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (KiemTraChiTiet() == false)
            {
                MessageBox.Show(this, "Vui lòng nhập số lượng chi tiết phiếu xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                kq = true;
            }
            ///////////////////////////////
            //kiem tra dinh khoan
            {
                //_phieuNhap.ButToanPhieuNhapXuatList
                foreach (ButToanPhieuNhapXuat bt in _phieuNhap.ButToanPhieuNhapXuatList)
                {
                    if (bt.MaDoiTuongCo != _phieuNhap.MaDoiTac)
                    {
                        MessageBox.Show(this, "Đối tượng trong bút toán định khoản hiện không giống đối tượng Nhà cung cấp của phiếu nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        kq = false;
                        break;
                    }
                }
            }
            return kq;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Add to 11012013
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhap.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (_phieuNhap.IsNew == false)
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
            //End Add to 11012013
            Save();

        }
        

        private bool Save()
        {
            bool result = true;//mac dinh la true
            this.txtBlackHole.Focus();
            phieuNhapXuatBindingSource.EndEdit();
            try
            {

                if (KiemTraHopLe() == true)
                {
                    if (_phieuNhap.ButToanPhieuNhapXuatList.Count == 0)
                    {
                        //if (System.Windows.Forms.DialogResult.Yes != MessageBox.Show("Chưa nhập định khoản! Bạn có muốn lưu phiếu với định khoản rỗng?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        //{
                        //    result = false;//khong chap nhan luu trong khi dinh khoan chua nhap
                        //}

                        MessageBox.Show("Chứng từ chưa được hạch toán, bạn vui lòng hạch toán!");
                        return result;
                    }
                    else
                    {
                        result = KiemTraButToanHoaDon();
                    }

                    if (result == true)//
                    {
                        _phieuNhap.ApplyEdit();
                        _phieuNhap.Save();
                        //Add to 11012013
                        _ngayLapCu=_phieuNhap.NgayNX;
                        //End Add to 11012013
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (_phieuNhap.PhuongPhapNX == 2)//phuong phap nhap xuat thang
                        {
                            long giaTri = PhieuNhapXuat.KiemTraPhieu(_phieuNhap.MaPhieuNhapXuat);
                            if (giaTri == 0)
                            {
                                if (MessageBox.Show("Bạn Có Muốn Lập Phiếu Xuất?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    frmPhieuXuatPhanBoCCDC_New frm = new frmPhieuXuatPhanBoCCDC_New(_phieuNhap, 1);
                                    frm.Show();
                                }
                            }
                        }
                    }

                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                result = false;
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            //
            return result;
        }

        private bool KiemTraButToanHoaDon()
        {
            foreach (ButToanPhieuNhapXuat butToan in _phieuNhap.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                string noTK = taiKhoanNo.SoHieuTK;
                string CoTK = taiKhoanCo.SoHieuTK;
                #region Kiểm tra  hóa đơn
                if (taiKhoanNo.SoHieuTK.StartsWith("3113"))
                {
                    if (butToan.ChungTu_HoaDonList.Count == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn hóa đơn cho bút toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        decimal tongTienHoaDon = 0;
                        foreach (ChungTu_HoaDon ct_hd in butToan.ChungTu_HoaDonList)
                        {
                            tongTienHoaDon += ct_hd.SoTien;
                        }
                        if (tongTienHoaDon != butToan.SoTien)
                        {
                            MessageBox.Show(this, "Gía trị hạch toán tài khoản thuế không bằng tổng giá trị các hóa đơn", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
                #endregion//Kiểm tra  hóa đơn

                #region Kiểm Tra chi phí sản xuất

                if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.StartsWith("631") || noTK.StartsWith("4314"))
                {
                    if (butToan.ChungTu_ChiPhiSanXuatList.Count == 0)
                    {
                        MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        foreach (ChungTu_ChiPhiSanXuat cp in butToan.ChungTu_ChiPhiSanXuatList)
                        {
                            if (cp.ButtoanMucNganSachList.Count == 0 && (noTK.StartsWith("631") || noTK.StartsWith("4314")))
                            {
                                MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }
                }

                if (butToan.ChungTu_ChiPhiSanXuatList.Count > 0)
                {

                    decimal sotienCTu = 0;
                    foreach (ChungTu_ChiPhiSanXuat ct_cp in butToan.ChungTu_ChiPhiSanXuatList)
                    {
                        sotienCTu += ct_cp.SoTien;
                    }
                    if (butToan.SoTien != sotienCTu)
                    {
                        MessageBox.Show(this, "Tổng số tiền Công việc/Chương trình không bằng số tiền bút toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false; ;
                    }
                }
                #endregion

                #region Kiểm Tra đối tượng theo dõi
                if (taiKhoanNo.CoDoiTuongTheoDoi == true)
                {
                    if (butToan.MaDoiTuongNo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng nợ ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                if (taiKhoanCo.CoDoiTuongTheoDoi == true)
                {
                    if (butToan.MaDoiTuongCo == 0)
                    {
                        MessageBox.Show(this, "Vui lòng chọn đối tượng Có ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                #endregion//Kiểm Tra đối tượng theo dõi

            }
            return true;
        }

        private void Show_colMaDoiTuongNo()
        {
            this.colMaDoiTuongNo.Visible = true;
            this.colMaDoiTuongNo.VisibleIndex = 3;
            this.colMaDoiTuongNo.Width = 190;
        }

        private void DuyetButToanToShowDoiTuong_ButToan()
        {
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhap.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 httkNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                if (httkNo.CoDoiTuongTheoDoi)
                {
                    Show_colMaDoiTuongNo();
                    break;

                }
            }
        }

        private void CheckShow_colMaDoiTuongNo_LoadPhieu()
        {
            if (!_phieuNhap.IsNew)
            {
                if (_phieuNhap.ButToanPhieuNhapXuatList.Count > 0)
                {
                    DuyetButToanToShowDoiTuong_ButToan();
                }
            }
        }

        private void CheckHideShowDoiTuong_ButToan()
        {
            ButToanPhieuNhapXuat _butToan = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
            HeThongTaiKhoan1 httkNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
            if (httkNo.CoDoiTuongTheoDoi)
            {
                Show_colMaDoiTuongNo();
                //((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = _phieuNhap.MaDoiTac;

            }
            else
            {
                this.colMaDoiTuongNo.Visible = false;
                ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = 0;
                DuyetButToanToShowDoiTuong_ButToan();
            }
        }

        #region lookUpEdit_PPNXKho_EditValueChanged
        private void lookUpEdit_PPNXKho_EditValueChanged(object sender, EventArgs e)
        {
            if ((byte)(lookUpEdit_PPNXKho.EditValue) == 1)
            {
                barBt_LapPhieuXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
            else
                barBt_LapPhieuXuat.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        #endregion

        #region grdViewCt_PhieuNhap_CellValueChanged
        private void grdViewCt_PhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colThanhTien" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colDonGia")
            {
                grdCT_PhieuNhap.Update();
                ct_phieuNhap.ThanhTien = Math.Round(ct_phieuNhap.DonGia * ct_phieuNhap.SoLuong, 0, MidpointRounding.AwayFromZero);
                //tinh tong tien phieu nhap
                Decimal tongTien = 0;
                foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhap.CT_PhieuNhapList)
                {
                    tongTien = tongTien + ct_PhieuNhap.ThanhTien;
                }
                _phieuNhap.GiaTriKho = tongTien;
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa")
            {
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                //ct_phieuNhap.ThoiLuong = hangHoa.ThoiLuong;
                //grdViewCt_PhieuNhap.RefreshData();
            }
          
        }
        #endregion

        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            phieuNhapXuatBindingSource.EndEdit();
            if (_phieuNhap.IsNew || _phieuNhap.HoaDon_NhapXuatList.Count == 0)
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhap.MaDoiTac);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhap.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
                        foreach (ButToanPhieuNhapXuat _butToan in _phieuNhap.ButToanPhieuNhapXuatList)
                        {
                            HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                            if (taiKhoan.SoHieuTK.StartsWith("3113") && !(KhoaSoThue()))
                            {
                               
                                //if (_phieuNhap.IsNew == false)
                                //{
                                //    foreach (HoaDon_NhapXuat hd_nx in _phieuNhap.HoaDon_NhapXuatList)
                                //    {
                                //        foreach (ChungTu_HoaDon ct in _butToan.ChungTu_HoaDonList)
                                //        {
                                //            if (hd_nx.MaHoaDon == ct.MaHoaDon)
                                //            {
                                //                _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct));
                                //            }
                                //            break;
                                //        }
                                //    }
                                //}
                                _butToan.ChungTu_HoaDonList.Clear();
                                foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                                    _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                               
                            }
                        }
                    }
                }
            }
            else
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhap);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhap.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _chungTu_HoaDonList = frm.ChungTu_HoaDonList;
                        foreach (ButToanPhieuNhapXuat _butToan in _phieuNhap.ButToanPhieuNhapXuatList)
                        {
                            HeThongTaiKhoan1 taiKhoan = HeThongTaiKhoan1.GetHeThongTaiKhoan1(_butToan.NoTaiKhoan);
                            if (taiKhoan.SoHieuTK.StartsWith("3113") && !(KhoaSoThue()))
                            {
                               
                                //foreach ( HoaDon_NhapXuat hd_nx in  _phieuNhap.HoaDon_NhapXuatList)
                                //{
                                //    foreach (ChungTu_HoaDon ct in _butToan.ChungTu_HoaDonList)
                                //    {
                                //        if (hd_nx.MaHoaDon == ct.MaHoaDon)
                                //        {
                                //            _chungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct));
                                //        }
                                //        break;
                                //    }
                                //}
                                _butToan.ChungTu_HoaDonList.Clear();
                                foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                                    _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                                
                            }
                        }
                        _phieuNhap.ApplyEdit();
                        _phieuNhap.Save();
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
            decimal soTienConLai = _phieuNhap.GiaTriKho;
            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhap.ButToanPhieuNhapXuatList)
            {
                soTienConLai = soTienConLai - buttoanphieu.SoTien;
            }
            butToan.SoTien = soTienConLai;
            butToan.MaDoiTuongCo = _phieuNhap.MaDoiTac;


            butToan.DienGiai = txtDienGiai.Text;
        }
        private void grdCT_PhieuNhap_ProcessGridKey(object sender, KeyEventArgs e)
        {
            
      
        }


        private void grdViewCt_PhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các dòng chi tiết phiếu nhập đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                    {
                        CT_PhieuNhap ct_Phieu = _phieuNhap.CT_PhieuNhapList[i];
                        _phieuNhap.GiaTriKho = _phieuNhap.GiaTriKho - ct_Phieu.ThanhTien;
                        grdViewCt_PhieuNhap.DeleteRow(i);
                    }
                }
            }
            //else if (e.KeyCode == Keys.Tab)
            //{
            //    if (grdViewCt_PhieuNhap.FocusedRowHandle < 0)
            //    {
            //        grdViewCt_PhieuNhap.MoveFirst();
            //    }
            //}                      
        }

        private void grdViewCt_PhieuNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            ////MessageBox.Show(e.KeyChar.ToString());
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các bút toán định khoản đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    grdView_DinhKhoan.DeleteSelectedRows();
                }

            }
            //else if (e.KeyCode == Keys.Tab)
            //{
            //    if (grdView_DinhKhoan.FocusedRowHandle < 0)
            //    {
            //        grdView_DinhKhoan.MoveFirst();
            //    }
            //}
            //
            
        }

        #region barBt_LapPhieuXuat_ItemClick
        private void barBt_LapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (_phieuNhap.IsNew)
            {
                MessageBox.Show("Vui Lòng Cập Nhật Phiếu Nhập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                long giaTri = PhieuNhapXuat.KiemTraPhieu(_phieuNhap.MaPhieuNhapXuat);
                if (giaTri != 0)//truong hop da xuat roi, bay gio xuat tiep//
                {
                    PhieuNhapXuat phieuXuat = PhieuNhapXuat.GetPhieuNhapXuat(giaTri);
                    //FrmPhieuXuatVatTuHangHoa frm = new FrmPhieuXuatVatTuHangHoa(phieuNhapXuat, 1, true);

                    frmPhieuXuatPhanBoCCDC_New frm = new frmPhieuXuatPhanBoCCDC_New(phieuXuat, 0);
                    frm.ShowDialog();
                }
                else//==0//truong hop chua xuat lan nao
                {
                    //FrmPhieuXuatVatTuHangHoa frm = new FrmPhieuXuatVatTuHangHoa(_phieuNhap, 2, true);
                    frmPhieuXuatPhanBoCCDC_New frm = new frmPhieuXuatPhanBoCCDC_New(_phieuNhap, 1);
                    frm.ShowDialog();
                }
            }
        }
        #endregion

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Rpt_PhieuNhapVatTu rpt = new Rpt_PhieuNhapVatTu(_phieuNhap.MaPhieuNhapXuat, _phieuNhap.NgayNX);
            //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();
            //
            //BEGIN

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
            //END


            /*
            DataSet _DataSet = new DataSet();
            ReportDocument report;



            report = new PSC_ERP.Report.CongNo.ChungTuGhiSoA4();

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "spd_BaoCaoChungTuGhiSo_NhapCCDC";
            command.Parameters.AddWithValue("@MaChungTu", _phieuNhap.MaPhieuNhapXuat);

            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command1 = new SqlCommand();
            command1.CommandType = CommandType.StoredProcedure;
            command1.CommandText = "spd_REPORT_ReportHeader";
            command1.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);

            command1.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);

            SqlCommand command2 = new SqlCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "spd_LayNguoiKyTenCongNo";
            command2.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

            command2.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);




            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            table.TableName = "spd_BaoCaoChungTuGhiSo;1";
            _DataSet.Tables.Add(table);

            if (table.Rows.Count == 0)
            {
                MessageBox.Show(this, "Lưu dữ liệu trước khi in.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlDataAdapter adapter1 = new SqlDataAdapter(command1);
            DataTable table1 = new DataTable();
            adapter1.Fill(table1);
            table1.TableName = "spd_REPORT_ReportHeader;1";
            _DataSet.Tables.Add(table1);

            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            DataTable table2 = new DataTable();
            adapter2.Fill(table2);
            table2.TableName = "spd_LayNguoiKyTenCongNo;1";
            _DataSet.Tables.Add(table2);


            report.SetDataSource(_DataSet);

            frmHienThiReport dlg = new frmHienThiReport();
            dlg.crytalView_HienThiReport.ReportSource = report;
            dlg.Show();
            */

        }

        #region Cac Phuong Thuc Report
        public void SpdBienBanNhapCongCuDungCu()
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
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuNhap.MaPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", _phieuNhap.MaPhongBan);
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
        public void Spd_PhieuNhapVatTu()
        {
            dataSet = new DataSet();
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {

                cn.Open();
                //tao bang_PhieuNhapVatTu
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_PhieuNhapVatTu";
                    cm.Parameters.AddWithValue("@MaPhieuNhap", _phieuNhap.MaPhieuNhapXuat);

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
        #endregion//Cac Phuong Thuc Report

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.txtBlackHole.Focus();
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                
                foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                {
                    CT_PhieuNhap ct_Phieu = _phieuNhap.CT_PhieuNhapList[i];
                    _phieuNhap.GiaTriKho = _phieuNhap.GiaTriKho - ct_Phieu.ThanhTien;
                }
                grdViewCt_PhieuNhap.DeleteSelectedRows();
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                bool chophepxoa = true;
                int[] deleteRows = grdView_DinhKhoan.GetSelectedRows();
                foreach (int deleteRow in deleteRows)
                {
                    ButToanPhieuNhapXuat buttoan = (ButToanPhieuNhapXuat)grdView_DinhKhoan.GetRow(deleteRow);
                    HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(buttoan.NoTaiKhoan);
                    if (tk.SoHieuTK.StartsWith("3113"))
                    {
                        if (KhoaSoThue())
                        {
                            chophepxoa = false;
                            break;
                        }
                    }

                }
                if (chophepxoa)
                    grdView_DinhKhoan.DeleteSelectedRows();
                else
                {
                    MessageBox.Show("Đã Khóa sổ Thuế, không thể Xóa Định khoản Thuế!");

                }
            }
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //XtraFrm_HangHoa dlg = new XtraFrm_HangHoa(0);
            HangHoaBQ_VT hh = HangHoaBQ_VT.NewHangHoaBQ_VT();
            XtraFrm_HangHoa frm = new XtraFrm_HangHoa(hh);
            DialogResult rs = frm.ShowDialog();
            if (rs == System.Windows.Forms.DialogResult.OK)
            {
                hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
                if (hh != null && hh.MaHangHoa != 0)
                {

                    if (cTPhieuNhapListBindingSource.Current == null)
                        grdViewCt_PhieuNhap.AddNewRow();
                    CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                    ct_phieuNhap.MaHangHoa = hh.MaHangHoa;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                    ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;

                    grdViewCt_PhieuNhap.RefreshData();
                }
                //hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);

            }

            //XtraFrm_HangHoa frm = new XtraFrm_HangHoa(3);
            //if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            //}
        }

        private void gridLookUpEdit_KhoNhan_EditValueChanged(object sender, EventArgs e)
        {
            _phieuNhap.MaKho = (int)gridLookUpEdit_KhoNhan.EditValue;
        }

        private void grdViewCt_PhieuNhap_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
            ct_phieuNhap.DienGiai = _phieuNhap.DienGiai;
            
        }
        //Utils.GridUtils.GridHandlerEx _gridHandlerEx;
        private void frmPhieuNhapVatTuHangHoa_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.ConfigGridView(grdView_DinhKhoan
                , setSTT: true
                , initCopyCell: true
                , multiSelectCell: true
                , multiSelectRow: false
                , initNewRowOnTop: false);
            Utils.GridUtils.ConfigGridView(grdViewCt_PhieuNhap
                , setSTT: true
                , initCopyCell: true
                , multiSelectCell: true
                , multiSelectRow: false
                , initNewRowOnTop: false);
            FormatFormTheoKhoaSoThue();
            CheckShow_colMaDoiTuongNo_LoadPhieu();
            //_gridHandlerEx = new Utils.GridUtils.GridHandlerEx(this.grdViewCt_PhieuNhap);
            //_gridHandlerEx.KeyDown += new KeyEventHandler(_gridHandlerEx_KeyDown);
            
        }

        void _gridHandlerEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DialogResult.Yes == MessageBox.Show("Bạn muốn xóa các dòng chi tiết phiếu nhập đang chọn trên lưới?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                    {                                                
                        CT_PhieuNhap ct_Phieu = _phieuNhap.CT_PhieuNhapList[i];
                        _phieuNhap.GiaTriKho = _phieuNhap.GiaTriKho - ct_Phieu.ThanhTien;                        
                        grdViewCt_PhieuNhap.DeleteRow(i);
                    }
                }
            }
            //else if (e.KeyCode == Keys.Tab)
            //{
            //    if (grdViewCt_PhieuNhap.FocusedRowHandle < 0)
            //    {
            //        grdViewCt_PhieuNhap.MoveFirst();
            //    }
            //}
        }

        private void lookUpEdit_DoiTac_EditValueChanged(object sender, EventArgs e)
        {
            _phieuNhap.MaDoiTac = (long)lookUpEdit_DoiTac.EditValue;
        }

        private void frmPhieuNhapCongCuDungCu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_phieuNhap != null && (_phieuNhap.IsDirty || _phieuNhap.IsNew))
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

        private void grdViewCt_PhieuNhap_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {

        }
        #region ButtonEdit_HoaDon_Click
        private void ButtonEdit_HoaDon_Click(object sender, EventArgs e)
        {
           
             
        }
        #endregion        

        #region grdView_DinhKhoan_CellValueChanged
        private void grdView_DinhKhoan_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colNoTaiKhoan")
            {
                ButToanPhieuNhapXuat _butToan = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                _butToan.ChungTu_HoaDonList.Clear();
                if (tk.SoHieuTK.StartsWith("3113"))
                {
                    if (KhoaSoThue())
                    {
                        MessageBox.Show("Đã khóa sổ thuế, không cập thể cập nhật thêm tài khoản thuế vào!");
                        _butToan.NoTaiKhoan = 0;
                    }
                    else
                    {
                        _butToan.ChungTu_HoaDonList.Clear();
                        foreach (ChungTu_HoaDon ct_hd in _chungTu_HoaDonList)
                            _butToan.ChungTu_HoaDonList.Add(ChungTu_HoaDon.NewChungTu_HoaDon(ct_hd));
                    }
                    
                }
                CheckHideShowDoiTuong_ButToan();
            }
        }
        #endregion 

        private void grdView_DinhKhoan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (grdView_DinhKhoan.FocusedColumn.Name == "colHoaDon" && !(KhoaSoThue()))
            {
                HeThongTaiKhoan1 tk = HeThongTaiKhoan1.GetHeThongTaiKhoan1(((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).NoTaiKhoan);
                if (tk.SoHieuTK.StartsWith("3113"))
                {
                    frmDanhSachHoaDonDichVuPhieuXuat _frm = new frmDanhSachHoaDonDichVuPhieuXuat(_phieuNhap, _chungTu_HoaDonList, (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current);
                    _frm.Show();
                }
            }
            #region New
            if (grdView_DinhKhoan.FocusedColumn.Name == "col_btn")
            {
                if (((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current) != null)
                {
                    //Xu ly Tai day
                    ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).BeginEdit();
                    ButToanPhieuNhapXuat bt = (ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current;
                    #region Edit bug
                    ChungTu_ChiPhiSanXuatList cpList = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
                    foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat in ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList)
                    {
                        cpList.Add(chungTu_ChiPhiSanXuat);
                    }
                    //ChungTu_ChiPhiSanXuatList cpList = ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).ChungTu_ChiPhiSanXuatList;
                    #endregion//Edit bug
                    
                    cpList.BeginEdit();
                    frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuNhap.NgayNX, bt.DienGiai, bt.MaButToan);
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
            #endregion

        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuNhap;
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
                //
                if (KhoaSoThue())
                {
                    if (CheckCoTaiKhoanThueTrongButToan())
                    {
                        MessageBox.Show(this, "Đã khóa sổ thuế, không thể xóa phiếu, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //
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
                        PhieuNhapXuat.DeletePhieuNhapXuat(_phieuNhap);
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

        #region BoSung KhoaSoThue
        private void dateEdit_NgayLap_Leave(object sender, EventArgs e)
        {
            if (dateEdit_NgayLap.OldEditValue != dateEdit_NgayLap.EditValue)
            {
                CheckValidKhoaSoThueWhenChangeNgayNX();
                FormatFormTheoKhoaSoThue();
            }
        }

        private void grdView_DinhKhoan_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            EventRowOrColumnGrdView_DinhKhoanChange();
        }
        #endregion//BoSung KhoaSoThue

    }
}