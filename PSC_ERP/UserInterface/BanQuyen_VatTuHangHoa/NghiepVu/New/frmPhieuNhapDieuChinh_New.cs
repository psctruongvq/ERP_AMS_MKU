using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.Data.SqlClient;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using ERP_Library.Security;
//22/09/2014
namespace PSC_ERP
{
    public partial class frmPhieuNhapDieuChinh_New : DevExpress.XtraEditors.XtraForm
    {
        #region properties
        PhieuNhapXuat _phieuNhapXuat;
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        KiemKeTonKho _kiemKeTonKho;
        // add 10/03/2021
        List<tblnsBoPhan> _boPhanList = null;
        int _maCongTy = CurrentUser.Info.MaCongTy;

        bool _laNhap = true;

        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        //Add to 11012013
        DateTime _ngayLapCu;
        int _maKhoCu;
        //End Add to 11012013
        #endregion //properties

        public frmPhieuNhapDieuChinh_New()
        {
            InitializeComponent();
        }

        public frmPhieuNhapDieuChinh_New(bool laNhap)
        {
            InitializeComponent();
            _laNhap = laNhap;
            KhoiTao();
            KhoiTaoPhieu(_laNhap);
        }

        public void ShowPhieuNhapDieuChinh()
        {
            _laNhap = true;
            KhoiTao();
            KhoiTaoPhieu(_laNhap);
            this.Show();
        }

        public void ShowPhieuXuatDieuChinh()
        {
            _laNhap = false;
            KhoiTao();
            KhoiTaoPhieu(_laNhap);
            this.Show();
        }

        public frmPhieuNhapDieuChinh_New(KiemKeTonKho kiemKeTonKho, bool laNhap)
        {
            InitializeComponent();
            btnPhieuKiemKe.Enabled = false;
            KhoiTao();
            KhoiTaoPhieu(kiemKeTonKho, laNhap);
        }
        public frmPhieuNhapDieuChinh_New(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }

        #region function

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu(bool laNhap)
        {
            _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuNhapXuat.Loai = 5;
            _laNhap = laNhap;
            _phieuNhapXuat.LaNhap = _laNhap;
            if (this._laNhap == true)
            {
                this.Text = "Phiếu Nhập Điều Chỉnh";
                cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
                //
                this.ColMaTieuMuc.Visible = false;
                this.col_btn.Visible = false;
                //
            }
            else
            {
                this.Text = "Phiếu Xuất Điều Chỉnh";
                cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;

                formatGridviewDinhKhoan();
            }
            _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            btnPhieuKiemKe.Enabled = true;
        }
        #endregion

        private void KhoiTaoPhieu(KiemKeTonKho kiemKeTonKho, bool laNhap)
        {
            _kiemKeTonKho = kiemKeTonKho;
            _laNhap = laNhap;
            _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat(_kiemKeTonKho, _laNhap);
            _phieuNhapXuat.Loai = 5;
            _phieuNhapXuat.LaNhap = _laNhap;
            if (this._laNhap == true)
            {
                this.Text = "Phiếu Nhập Điều Chỉnh";
                cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
            }
            else
            {
                this.Text = "Phiếu Xuất Điều Chỉnh";
                cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
            }
            _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;

        }

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            _phieuNhapXuat = phieuNhapXuat;
            _laNhap = _phieuNhapXuat.LaNhap;
            //Add to 11012013
            _ngayLapCu = _phieuNhapXuat.NgayNX;
            _maKhoCu = _phieuNhapXuat.MaKho;
            //End Add to 11012013
            //cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;            
            if (this._laNhap == true)
            {
                cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuNhapList;
                this.Text = "Phiếu Nhập Điều Chỉnh";
            }
            else
            {
                cTPhieuNhapListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
                this.Text = "Phiếu Xuất Điều Chỉnh";
            }

            btnPhieuKiemKe.Enabled = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;

        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;
            doiTacNoListBindingSource.DataSource = _DoiTacList;

            //
            _boPhanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(_maCongTy).ToList();
            tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
            _boPhanList.Insert(0, boPhan_chonTatCa);
            boPhanListBindingSource.DataSource = _boPhanList;

            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();

            btnPhieuKiemKe.Enabled = true;
            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            Init_lookUpEdit_PhongBan();

        }
        #endregion

        #region Vat Tu_Ban Quyen
        private void anHiencottheoyeucau()
        {
            this.ColMaTieuMuc.Visible = false;
            this.col_btn.Visible = true;
        }
        private void formatGridviewDinhKhoan()
        {
            if (!_phieuNhapXuat.IsNew)
            {
                if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count > 0)
                {
                    foreach (ButToanPhieuNhapXuat bt in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                    {
                        if (bt.ButToan_MucNganSach.MaTieuMuc != 0 && bt.ButToan_MucNganSach.MaCT_ChiPhiSanXuat == 0)
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

        private bool KiemTraButToan()
        {
            foreach (ButToanPhieuNhapXuat butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                HeThongTaiKhoan1 taiKhoanNo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.NoTaiKhoan);
                HeThongTaiKhoan1 taiKhoanCo = HeThongTaiKhoan1.GetHeThongTaiKhoan1(butToan.CoTaiKhoan);
                string noTK = taiKhoanNo.SoHieuTK;
                string CoTK = taiKhoanCo.SoHieuTK;
                #region Kiểm tra  hóa đơn
                if (taiKhoanNo.SoHieuTK.Contains("3113"))
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
                #endregion//Kiểm tra  hóa đơn

                #region Kiểm Tra chi phí sản xuất

                if (noTK == "1551" || noTK == "1552" || CoTK == "1551" || CoTK == "1552" || noTK.Contains("631") || noTK.Contains("4314"))
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
                            if (cp.ButtoanMucNganSachList.Count == 0 && (noTK.Contains("631") || noTK.Contains("4314")))
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
            foreach (ButToanPhieuNhapXuat _butToan in _phieuNhapXuat.ButToanPhieuNhapXuatList)
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
            if (!_phieuNhapXuat.IsNew)
            {
                if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count > 0)
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
                //((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = _phieuNhapXuat.MaDoiTac;

            }
            else
            {
                this.colMaDoiTuongNo.Visible = false;
                ((ButToanPhieuNhapXuat)butToanPhieuNhapXuatListBindingSource.Current).MaDoiTuongNo = 0;
                DuyetButToanToShowDoiTuong_ButToan();
            }
        }

        private bool KhoaSo()
        {
            bool khoaso = false;
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    khoaso = true;
                }
            }
            //
                if (khoaso == false && _phieuNhapXuat.IsNew == false)
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
            daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_phieuNhapXuat.NgayNX, _phieuNhapXuat.MaKho);
            if (daKC == false && _phieuNhapXuat.IsNew == false)
            {
                daKC = KyKetChuyenTonKho.KiemTraKetChuyetVatTu_PhucVuNXvaHuyKetChuyen(_ngayLapCu, _maKhoCu);
            }
            if (daKC)
            {
                MessageBox.Show("Kỳ này đã kết chuyển, không thể cập nhật phiếu!");
            }
            return daKC;
        }

        #endregion //function

        #region Event

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
            textEdit_Focus.Focus();

            if (KhoaSo())
            {
                MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DaKetChuyen() == false)
            {
                //End Add to 11012013
                if (txt_SoPhieu.EditValue != null)//IF 1
                {
                    string _soPhieu = txt_SoPhieu.EditValue.ToString();
                    int _stt;
                    //if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                    //{
                        bool ktphieutrung = true;
                        if (_phieuNhapXuat.IsNew)
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, true);
                        }
                        else//k phai IS NEW
                        {
                            ktphieutrung = PhieuNhapXuat.CheckSoPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.SoPhieu, false);

                        }
                        if (ktphieutrung)//IF 5
                        {
                            //
                            try
                            {
                                //Luu
                                if (lookUpEdit_PhongBan.GetSelectedDataRow() == null)
                                    MessageBox.Show("Vui lòng chọn Phòng ban nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                else if (lookUpEdit_MaNguoiNhapXuat.GetSelectedDataRow() == null)
                                    MessageBox.Show("Vui lòng chọn Người nhập xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                else if (_phieuNhapXuat.CT_PhieuNhapList.Count == 0 && _phieuNhapXuat.LaNhap == true)
                                    MessageBox.Show("Phiếu không có chi tiết vui lòng xem lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                else if (_phieuNhapXuat.CT_PhieuXuatList.Count == 0 && _phieuNhapXuat.LaNhap == false)
                                    MessageBox.Show("Phiếu không có chi tiết vui lòng xem lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                else btLuu();
                                //End Luu
                            }//End Try
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
                    //}//END IF 2
                    //else
                    //{
                    //    MessageBox.Show("Số Phiếu Không Hợp Lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    txt_SoPhieu.Focus();
                    //}

                }//END IF 1

            }

        }

        private void btLuu()
        {
            try
            {
                if (_phieuNhapXuat.IsNew)
                    _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
                if (KiemTraButToan())
                {
                    _phieuNhapXuat.ApplyEdit();
                    _phieuNhapXuat.Save();
                }
                //Add to 11012013
                _ngayLapCu = _phieuNhapXuat.NgayNX;
                _maKhoCu = _phieuNhapXuat.MaKho;
                //End Add to 11012013
                btnPhieuKiemKe.Enabled = false;
                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region grdViewCt_PhieuNhap_CellValueChanged
        private void grdViewCt_PhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colDonGia" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colThanhTien")
            {
                if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colDonGia")
                {
                    if (this._laNhap == true)
                    {
                        CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                        grdCT_PhieuNhap.Update();
                        ct_phieuNhap.ThanhTien = Math.Round(ct_phieuNhap.DonGia * ct_phieuNhap.SoLuong, 0, MidpointRounding.AwayFromZero);
                    }
                    else
                    {
                        CT_PhieuXuat ct_phieuXuat = (CT_PhieuXuat)cTPhieuNhapListBindingSource.Current;
                        grdCT_PhieuNhap.Update();
                        ct_phieuXuat.ThanhTien = Math.Round(ct_phieuXuat.DonGia * ct_phieuXuat.SoLuong, 0, MidpointRounding.AwayFromZero);
                    }
                }

                Decimal tongTien = 0;
                if (this._laNhap == true)
                {
                    foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
                    {
                        tongTien = tongTien + ct_PhieuNhap.ThanhTien;
                    }
                }
                else
                {
                    foreach (CT_PhieuXuat ct_PhieuXuat in _phieuNhapXuat.CT_PhieuXuatList)
                    {
                        tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                    }
                }
                _phieuNhapXuat.GiaTriKho = tongTien;
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa")
            {
                if (this._laNhap == true)
                {
                    CT_PhieuNhap ct_phieuNhap = (CT_PhieuNhap)cTPhieuNhapListBindingSource.Current;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuNhap.MaHangHoa);
                    ct_phieuNhap.MaDonViTinh = hangHoa.MaDonViTinh;
                }
                else
                {
                    CT_PhieuXuat ct_phieuXuat = (CT_PhieuXuat)cTPhieuNhapListBindingSource.Current;
                    HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuXuat.MaHangHoa);
                    ct_phieuXuat.MaDonViTinh = hangHoa.MaDonViTinh;
                }
                // grdViewCt_PhieuNhap.RefreshData();
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
            KhoiTaoPhieu(_laNhap);
        }

        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            // Gan tien cho but toan
            ButToanPhieuNhapXuat butToan = (ButToanPhieuNhapXuat)(butToanPhieuNhapXuatListBindingSource.Current);
            decimal soTienConLai = _phieuNhapXuat.GiaTriKho;
            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                soTienConLai = soTienConLai - buttoanphieu.SoTien;
            }
            butToan.SoTien = soTienConLai;
            butToan.MaDoiTuongCo = _phieuNhapXuat.MaDoiTac;
        }

        private void grdViewCt_PhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                grdViewCt_PhieuNhap.DeleteSelectedRows();
            }
            //
            HamDungChung.CopyCell(grdViewCt_PhieuNhap, e);
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                grdView_DinhKhoan.DeleteSelectedRows();
            }
            HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                //if (grdViewCt_PhieuNhap.GetFocusedRow() != null)
                //{
                //    CT_PhieuNhap ct_pn = grdViewCt_PhieuNhap.GetFocusedRow() as CT_PhieuNhap;
                //    _phieuNhapXuat.GiaTriKho = _phieuNhapXuat.GiaTriKho - ct_pn.ThanhTien;
                //    grdViewCt_PhieuNhap.DeleteSelectedRows();
                //}
                grdViewCt_PhieuNhap.DeleteSelectedRows();
                Decimal tongTien = 0;
                if (this._laNhap == true)
                {
                    foreach (CT_PhieuNhap ct_PhieuNhap in _phieuNhapXuat.CT_PhieuNhapList)
                    {
                        tongTien = tongTien + ct_PhieuNhap.ThanhTien;
                    }
                }
                else
                {
                    foreach (CT_PhieuXuat ct_PhieuXuat in _phieuNhapXuat.CT_PhieuXuatList)
                    {
                        tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                    }
                }
                _phieuNhapXuat.GiaTriKho = tongTien;

            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
                grdView_DinhKhoan.DeleteSelectedRows();
        }

        private void btnPhieuKiemKe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPhieuKiemKeTonKhoList frm = new frmPhieuKiemKeTonKhoList(_phieuNhapXuat.MaKho);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                KhoiTaoPhieu(frm.KiemKeTonKho, _phieuNhapXuat.LaNhap);
            }
        }


        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ReportTemplate _report;
            if (this._laNhap == true)
            {
                _report = ReportTemplate.GetReportTemplate("PhieuNhapVatTu");
            }
            else
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
        }

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_ByBophan((int)lookUpEdit_PhongBan.EditValue);
        }
        #endregion

        private void frmPhieuNhapDieuChinh_Load(object sender, EventArgs e)
        {
            //CheckShow_colMaDoiTuongNo_LoadPhieu();//Tam thoi k hien
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuNhap, 35);
            if (_laNhap)//N
            {
                //
                this.ColMaTieuMuc.Visible = false;
                this.col_btn.Visible = false;
                //
            }
            else
            {
                formatGridviewDinhKhoan();
            }
            grdView_DinhKhoan.OptionsView.ShowFooter = true;
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdView_DinhKhoan, new string[] { "SoTien" }, "{0:#,###.##}");
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuNhapXuat;
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
                        PhieuNhapXuat.DeletePhieuNhapXuat(_phieuNhapXuat);
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

        private void grdView_DinhKhoan_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
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
                    frmChiPhiSanXuatChuongTrinh_New f = new frmChiPhiSanXuatChuongTrinh_New(cpList, bt.SoTien, _phieuNhapXuat.NgayNX, bt.DienGiai, bt.MaButToan);
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


        #endregion //Event

        #region function report
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
                    cm.Parameters.AddWithValue("@MaPhieuNhap", _phieuNhapXuat.MaPhieuNhapXuat);

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
        }
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
                    cm.Parameters.AddWithValue("@MaPhieuXuatVTHH", _phieuNhapXuat.MaPhieuNhapXuat);

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
        #endregion //function report




    }
}