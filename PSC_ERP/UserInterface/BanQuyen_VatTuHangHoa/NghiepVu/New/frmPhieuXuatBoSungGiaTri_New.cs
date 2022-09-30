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

//11/04/2013
namespace PSC_ERP
{
    public partial class frmPhieuXuatBoSungGiaTri_New : DevExpress.XtraEditors.XtraForm
    {
        PhieuNhapXuat _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
        PhieuNhapXuat _phieuNhapXuatCu;
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        KhoBQ_VTList _khoBQ_VTList;
        HopDongMuaBanList _hopDongMuaBanList;
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        //Add to 11012013
        DateTime _ngayLapCu;
        //End Add to 11012013
        public frmPhieuXuatBoSungGiaTri_New()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
        }

        #region frmPhieuXuatBoSungGiaTri(PhieuNhapXuat phieuNhapXuat)
        public frmPhieuXuatBoSungGiaTri_New(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }
        public frmPhieuXuatBoSungGiaTri_New(PhieuNhapXuat phieuNhap, int kieu, bool XuatThangtu1PhieuNhap)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhap, kieu);
        }
        #endregion
        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuNhapXuat.Loai = 4;
            _phieuNhapXuat.LaNhap = false;
            _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            if (_khoBQ_VTList.Count != 0)
                _phieuNhapXuat.MaKho = _khoBQ_VTList[0].MaKho;
            cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;

            formatGridviewDinhKhoan();

        }
        #endregion
        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            _phieuNhapXuat = phieuNhapXuat;
            cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            //Add to 11012013
            _ngayLapCu = _phieuNhapXuat.NgayNX;
            //End Add to 11012013
            // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;            
            _phieuNhapXuatCu = PhieuNhapXuat.GetPhieuNhapXuat(_phieuNhapXuat.MaPhieuNhapXuatThamChieu);
            //txt_SoPhieuCu.Text = _phieuNhapXuatCu.SoPhieu;
            barbt_PhieuNhap.Enabled = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            btnSaoChepChungTu.Enabled = false;//M

        }
        #endregion
        #region  KhoiTaoPhieu(PhieuNhapXuat phieuXuat, int kieu)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuXuat, int kieu)
        {
            if (kieu == 1)
            {
                _phieuNhapXuat = phieuXuat;
                //Add to 11012013
                _ngayLapCu = _phieuNhapXuat.NgayNX;
                //End Add to 11012013
                //_phieuTuDSPhieuNhapXuat = true;
            }
            else
            {
                _phieuNhapXuat = PhieuNhapXuat.NewPhieuXuatBanQuen(phieuXuat, 1);
                _phieuNhapXuat.LaNhap = false;
                _phieuNhapXuat.Loai = 4;
                _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
                //_phieuTuDSPhieuNhapXuat = false;

            }
            cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            //btnThemMoi.Enabled = false;
            btnSaoChepChungTu.Enabled = false;//M

            if (_phieuNhapXuat != null)
            {
                if (PhieuNhapXuat.KiemTraPhieuXuatThangTuPhieuNhap(_phieuNhapXuat.MaPhieuNhapXuat))
                {
                    //grdViewCt_PhieuXuat.OptionsBehavior.Editable = false;
                    LockData();
                    if (_phieuNhapXuat.PhuongPhapNX == 2)
                        LockGridView();
                    else
                        UnLockGridView();

                }
                else
                {
                    UnLockData();
                }
            }
        }
        #endregion// KhoiTaoPhieu(PhieuNhapXuat phieuXuat, int kieu)
        #region KhoiTao()
        private void KhoiTao()
        {
            //PhieuNhapXuatList_bindingSource.DataSource = PhieuNhapXuatList.GetPhieuNhapXuatList();//M
            bs_ChuongTrinhConBanQuyenList.DataSource = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            //doiTuongAllListBindingSource.DataSource = DoiTuongAllList.GetDoiTuongAllList();            
            //boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();
            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListBy_All();
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(1);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;


            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(1, 0, 0);//M
            HopDongMuaBan hdmb = HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn");
            _hopDongMuaBanList.Insert(0, hdmb);
            HopDongMuaBanList_BindingSource.DataSource = _hopDongMuaBanList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;
            Init_lookUpEdit_PhongBan();

        }
        #endregion
        #region Kiem Tra Chi Tiet Phieu Nhap có Gia Tri
        private bool KiemTraSoTienTK152_ctPhieu()
        {
            decimal tongTienButToan = 0;
            bool coTK1552 = false;
            if (_phieuNhapXuat.ButToanPhieuNhapXuatList.Count > 0)
            {
                //
                foreach (ButToanPhieuNhapXuat bt in _phieuNhapXuat.ButToanPhieuNhapXuatList)
                {
                    if (bt.SoHieuTaiKhoanCo.Length >= 4)
                    {
                        if (bt.SoHieuTaiKhoanCo.Substring(0, 4) == "1552")
                        {
                            tongTienButToan += bt.SoTien;
                            coTK1552 = true;
                        }
                    }
                }
                if (coTK1552 && tongTienButToan != _phieuNhapXuat.GiaTriKho)
                {
                    MessageBox.Show("Số tiền bút toán Có TK 1552 và Giá trị phiếu xuất không bằng nhau. Vui lòng kiểm tra lại! ");
                    return false;
                }
                //
            }
            return true;
        }
        bool KTGiaTriCt_PhieuXuat()
        {
            bool kt = true;
            foreach (CT_PhieuXuat ctpx in _phieuNhapXuat.CT_PhieuXuatList)
            {
                if (ctpx.ThanhTien == 0)
                {
                    kt = false;
                    break;
                }
            }

            return kt;
        }
        #endregion//Kiem Tra Chi Tiet Phieu Xuat có Gia Tri
        void formatGriview()
        {
            this.grdViewCt_PhieuXuat.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.grdView_DinhKhoan.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }

        private void LockData()
        {
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = true;
            lookUpEdit_PPNXKho.Properties.ReadOnly = true;

        }
        void UnLockData()
        {
            gridLookUpEdit_KhoXuat.Properties.ReadOnly = false;
            lookUpEdit_PPNXKho.Properties.ReadOnly = false;
        }
        void LockGridView()
        {
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaChuongTrinhCon"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaHopDong"].OptionsColumn.AllowEdit = false;
            grdViewCt_PhieuXuat.Columns["MaNguon"].OptionsColumn.AllowEdit = false;
        }
        void UnLockGridView()
        {
            grdViewCt_PhieuXuat.Columns["MaHangHoa"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaChuongTrinhCon"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaHopDong"].OptionsColumn.AllowEdit = true;
            grdViewCt_PhieuXuat.Columns["MaNguon"].OptionsColumn.AllowEdit = true;
        }

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
                thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong((int)lookUpEdit_PhongBan.EditValue, false);
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
            textEdit_Focus.Focus();
            //Add to 11012013
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_phieuNhapXuat.NgayNX);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show(this, "Đã khóa sổ,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (_phieuNhapXuat.IsNew == false)
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
            //Add to 18012013
            if (_phieuNhapXuat.XacNhan == true)
            {
                MessageBox.Show(this, "Thủ kho đã xác nhận,xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //End Add to 18012013
            if (txt_SoPhieu.EditValue != null)//IF 1
            {
                string _soPhieu = txt_SoPhieu.EditValue.ToString();
                int _stt;
                if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                {
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
                        //C
                        try
                        {
                            if (KTGiaTriCt_PhieuXuat() && KiemTraSoTienTK152_ctPhieu())
                            {
                                _phieuNhapXuat.ApplyEdit();
                                _phieuNhapXuat.Save();
                                //Add to 11012013
                                _ngayLapCu = _phieuNhapXuat.NgayNX;
                                //End Add to 11012013
                                MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Không thể lưu! Giá trị bổ sung cho chi tiết phải khác 0.", "Yêu Cầu", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                grdCT_PhieuXuat.Focus();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        //C
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
        #region grdViewCt_PhieuXuat_CellValueChanged
        private void grdViewCt_PhieuXuat_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            CT_PhieuXuat ct_phieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
            if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colThanhTien")
            {
                Decimal tongTien = 0;
                foreach (CT_PhieuXuat ct_PhieuXuat in _phieuNhapXuat.CT_PhieuXuatList)
                {
                    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                }
                _phieuNhapXuat.GiaTriKho = tongTien;
            }
            else if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaHangHoa")
            {
                ct_phieuXuat.MaChuongTrinhCon = 0;
                HangHoaBQ_VT hanghoa = HangHoaBQ_VT.GetHangHoaBQ_VT(ct_phieuXuat.MaHangHoa);
                ct_phieuXuat.MaDonViTinh = hanghoa.MaDonViTinh;
            }
            else if (grdViewCt_PhieuXuat.FocusedColumn.Name == "colMaChuongTrinhCon")
            {
                ChuongTrinhBanQuyenCon chuongtrinh = ChuongTrinhBanQuyenCon.GetChuongTrinhBanQuyenCon(ct_phieuXuat.MaChuongTrinhCon);
                ct_phieuXuat.MaHangHoa = chuongtrinh.MaHangHoa;
                ct_phieuXuat.ThoiLuong = chuongtrinh.ThoiLuong;
                // grdViewCt_PhieuXuat.RefreshData();
            }

        }
        #endregion
        #region btn_HoaDon_ItemClick
        private void btn_HoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.HoaDon_NhapXuatList.Count == 0)
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhapXuat.MaDoiTac);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                    }
                }
            }
            else
            {
                frmChonHoaDonLapPhieu frm = new frmChonHoaDonLapPhieu(_phieuNhapXuat);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.HoaDon_NhapXuatList = frm.HoaDon_NhapXuatList;
                        _phieuNhapXuat.ApplyEdit();
                        _phieuNhapXuat.Save();
                    }
                }
            }
        }
        #endregion
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
            decimal soTienConLai = _phieuNhapXuat.GiaTriKho;
            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                soTienConLai = soTienConLai - buttoanphieu.SoTien;
            }
            butToan.SoTien = soTienConLai;
            butToan.MaDoiTuongCo = _phieuNhapXuat.MaDoiTac;
        }

        private void grdViewCt_PhieuXuat_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    foreach (int i in grdViewCt_PhieuXuat.GetSelectedRows())
            //    {
            //        grdViewCt_PhieuXuat.DeleteRow(i);
            //    }
            //}
            //
            HamDungChung.CopyCell(grdViewCt_PhieuXuat, e);
        }

        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Delete)
            //{
            //    grdView_DinhKhoan.DeleteSelectedRows();
            //}
            //
            HamDungChung.CopyCell(grdView_DinhKhoan, e);
        }
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                //if (grdViewCt_PhieuXuat.GetFocusedRow() != null)
                //{
                //    CT_PhieuXuat ct_px = grdViewCt_PhieuXuat.GetFocusedRow() as CT_PhieuXuat;
                //    _phieuNhapXuat.GiaTriKho = _phieuNhapXuat.GiaTriKho - ct_px.ThanhTien;
                //    grdViewCt_PhieuXuat.DeleteSelectedRows();
                //}
                grdViewCt_PhieuXuat.DeleteSelectedRows();
                Decimal tongTien = 0;
                foreach (CT_PhieuXuat ct_PhieuXuat in _phieuNhapXuat.CT_PhieuXuatList)
                {
                    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                }
                _phieuNhapXuat.GiaTriKho = tongTien;
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
                grdView_DinhKhoan.DeleteSelectedRows();
        }
        private void barbt_PhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmDanhSachPhieuNhapXuat frm = new frmDanhSachPhieuNhapXuat(false, 0);
            frmDanhSachPhieuNhapXuat frm = new frmDanhSachPhieuNhapXuat(true, 4);
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                string _soPhieuT = _phieuNhapXuat.SoPhieu;
                _phieuNhapXuatCu = frm.PhieuNhapXuat;
                _phieuNhapXuat = new PhieuNhapXuat(_phieuNhapXuatCu);//M
                _phieuNhapXuat.SoPhieu = _soPhieuT;
                _phieuNhapXuat.LaNhap = false;
                _phieuNhapXuat.Loai = 4;
                _phieuNhapXuat.MaPhieuNhapXuatThamChieu = _phieuNhapXuatCu.MaPhieuNhapXuat;
                //txt_SoPhieuCu.Text = _phieuNhapXuatCu.SoPhieu;
                _phieuNhapXuat.PhuongPhapNX = _phieuNhapXuatCu.PhuongPhapNX;
                _phieuNhapXuat.MaDoiTac = _phieuNhapXuatCu.MaDoiTac;
                _phieuNhapXuat.MaKho = _phieuNhapXuatCu.MaKho;
                _phieuNhapXuat.MaNguoiNhapXuat = _phieuNhapXuatCu.MaNguoiNhapXuat;
                _phieuNhapXuat.MaPhongBan = _phieuNhapXuatCu.MaPhongBan;
                Decimal tongTien = 0;
                foreach (CT_PhieuXuat ct_PhieuXuat in _phieuNhapXuat.CT_PhieuXuatList)
                {
                    tongTien = tongTien + ct_PhieuXuat.ThanhTien;
                }
                _phieuNhapXuat.GiaTriKho = tongTien;

                phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
                cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList; //_ctPhieuXuatList;
                butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;// _butToanPhieuNhapXuatList;
                grdCT_PhieuXuat.DataSource = cTPhieuXuatListBindingSource;
                grd_DinhKhoan.DataSource = butToanPhieuNhapXuatListBindingSource;

            }
        }
        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
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
        }
        #region Cac Phuong Thuc Report
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
                    cm.Parameters.AddWithValue("@MaPhieuXuat", _phieuNhapXuat.MaPhieuNhapXuat);

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
        }
        //END Spd_PhieuXuatBanQuyen
        #endregion//Cac Phuong Thuc Report

        private void btn_HopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_phieuNhapXuat.IsNew || _phieuNhapXuat.NhapXuat_HopDongList.Count == 0)
            {
                frmChonHopDongLapPhieu frm = new frmChonHopDongLapPhieu(_phieuNhapXuat.MaDoiTac, false);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.NhapXuat_HopDongList = frm.NhapXuat_HopDongList;
                    }
                }
            }
            else
            {
                frmChonHopDongLapPhieu frm = new frmChonHopDongLapPhieu(_phieuNhapXuat, false);
                if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    if (frm.TrangThai == true)
                    {
                        _phieuNhapXuat.NhapXuat_HopDongList = frm.NhapXuat_HopDongList;
                        _phieuNhapXuat.ApplyEdit();
                        _phieuNhapXuat.Save();
                    }
                }
            }
        }

        private void grdViewCt_PhieuXuat_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CT_PhieuXuat ct_phieuXuat = (CT_PhieuXuat)cTPhieuXuatListBindingSource.Current;
            ct_phieuXuat.DienGiai = _phieuNhapXuat.DienGiai;
        }

        private void btnSaoChepChungTu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDSPhieuNhapXuatBanQuyen frm = new frmDSPhieuNhapXuatBanQuyen(4, false);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat(frm.PhieuNhapXuat, dateEdit_NgayLap.DateTime);
                //
                _phieuNhapXuat.Loai = 4;
                _phieuNhapXuat.LaNhap = false;
                _phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
                cTPhieuXuatListBindingSource.DataSource = _phieuNhapXuat.CT_PhieuXuatList;
                butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;
                // hoaDon_NhapXuatbindingSource.DataSource = _phieuNhapXuat.HoaDon_NhapXuatList;

                _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
                phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
            }
        }

        private void frmPhieuXuatBoSungGiaTri_Load(object sender, EventArgs e)
        {
            formatGriview();
            //Tang STT cho CT
            Utils.GridUtils.SetSTTForGridView(grdViewCt_PhieuXuat, 35);
            formatGridviewDinhKhoan();
        }

        private void GridLookUpEdit_ChuongTrinh_Popup(object sender, EventArgs e)
        {
            if (cTPhieuXuatListBindingSource.Current != null && grdViewCt_PhieuXuat.GetFocusedRow() != null)
            {
                CT_PhieuXuat ctpx = cTPhieuXuatListBindingSource.Current as CT_PhieuXuat;
                if (ctpx.MaHangHoa != 0)
                {
                    GridLookUpEdit grid = (GridLookUpEdit)sender;
                    if (grid != null)
                    {
                        grid.Properties.View.ActiveFilterString = "MaHangHoa=" + ctpx.MaHangHoa.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập vào tên chương trình cha");
                    return;
                }
            }
        }

        private void btnXoaPhieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //B
            PhieuNhapXuat pnx = _phieuNhapXuat;
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




    }
}