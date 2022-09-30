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

namespace PSC_ERP
{
    public partial class frmNhapPhanBoCongCuDungCu : DevExpress.XtraEditors.XtraForm
    {/////////////////////////////

        PhieuNhapXuat _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
        HoaDonList _hoaDonList = HoaDonList.NewHoaDonList();
        DoiTuongAllList _doiTuongAllList = DoiTuongAllList.NewDoiTuongAllList();
        TieuMucNganSachList _tieuMucNganSachList = TieuMucNganSachList.NewTieuMucNganSachList();
        DoiTacList _DoiTacList;
        //Bien cho REPORT
        int UserId = ERP_Library.Security.CurrentUser.Info.UserID;
        DataSet dataSet;
        //
        public frmNhapPhanBoCongCuDungCu()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu();
        }

        #region frmPhieuNhapBanQuyen(PhieuNhapXuat phieuNhapXuat)
        public frmNhapPhanBoCongCuDungCu(PhieuNhapXuat phieuNhapXuat)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoPhieu(phieuNhapXuat);
        }
        #endregion

        #region KhoiTaoPhieu()
        private void KhoiTaoPhieu()
        {
            _phieuNhapXuat = PhieuNhapXuat.NewPhieuNhapXuat();
            _phieuNhapXuat.Loai = 3;
            _phieuNhapXuat.LaNhap = true;
            ////////////_phieuNhapXuat.SoPhieu = PhieuNhapXuat.SetSoPhieuNhapXuat(_phieuNhapXuat.Loai, _phieuNhapXuat.LaNhap, _phieuNhapXuat.NgayNX);
            _phieuNhapXuat.SoPhieu = PhieuNhapXuat.Get_NextSoChungTuNhapXuatCongCuDungCu(laNhap: _phieuNhapXuat.LaNhap
                , maBoPhan: ERP_Library.Security.CurrentUser.Info.MaBoPhan
                , maQLUser: ERP_Library.Security.CurrentUser.Info.MaQLUser
                , year: _phieuNhapXuat.NgayNX.Year, size: 4);
            congCuDungCuListBindingSource.DataSource = _phieuNhapXuat.CongCuDungCuList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;

            _phieuNhapXuat.DinhKhoanNhapXuat.LaMotNoNhieuCo = false;
            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;


        }
        #endregion

        #region KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        private void KhoiTaoPhieu(PhieuNhapXuat phieuNhapXuat)
        {
            //khong cho thay doi phong ban
            this.lookUpEdit_PhongBan.Properties.ReadOnly = true;
            _phieuNhapXuat = phieuNhapXuat;
            congCuDungCuListBindingSource.DataSource = _phieuNhapXuat.CongCuDungCuList;
            butToanPhieuNhapXuatListBindingSource.DataSource = _phieuNhapXuat.ButToanPhieuNhapXuatList;

            phieuNhapXuatBindingSource.DataSource = _phieuNhapXuat;
        }
        #endregion

        #region KhoiTao()
        private void KhoiTao()
        {

            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            donViTinhListBindingSource.DataSource = DonViTinhList.GetDonViTinhList();
            heThongTaiKhoan1ListBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            heThongTaiKhoan1ListBindingSource1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //
            {
                HeThongTaiKhoan1List heThongTaiKhoanList1All = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
                HeThongTaiKhoan1 tkKhongChon = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
                tkKhongChon.SoHieuTK = "<<Không chọn>>";
                tkKhongChon.TenTaiKhoan = "<<Không chọn>>";
                heThongTaiKhoan1ListBindingSource_forChiTietPhieuNhap.DataSource = heThongTaiKhoanList1All;
            }
            //
            doiTacListBindingSource1.DataSource = DoiTacList.GetDoiTacListByTen(0);

            boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList(1);


            _DoiTacList = DoiTacList.GetDoiTacListByTen(0);
            DoiTac _DoiTac = DoiTac.NewDoiTac(0, "Không Chọn");
            _DoiTacList.Insert(0, _DoiTac);
            doiTacListBindingSource.DataSource = _DoiTacList;

            _tieuMucNganSachList = TieuMucNganSachList.GetTieuMucNganSachList();
            TieuMucNganSach _tieuMucNganSach = TieuMucNganSach.NewTieuMucNganSach("Không Chọn", "Không Chọn");
            _tieuMucNganSachList.Insert(0, _tieuMucNganSach);
            tieuMucNganSachListBindingSource.DataSource = _tieuMucNganSachList;

            thongTinNhanVienTongHopListAllBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
        }
        #endregion

        private bool KiemTraDuLieu()
        {
            bool kq = false;
            if (_phieuNhapXuat.MaDoiTac == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn đối tác", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_DoiTac.Focus();
            }
            else if (_phieuNhapXuat.MaPhongBan == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn phòng ban", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_PhongBan.Focus();
            }
            else if (_phieuNhapXuat.MaNguoiNhapXuat == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn đại diện bên nhận", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookUpEdit_NhanVien.Focus();
            }
            else if (_phieuNhapXuat.MaNguoiDaiDienBenGiao == 0)
            {
                MessageBox.Show(this, "Vui lòng chọn người đại diện bên giao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbDaiDienNguoiGiao.Focus();
            }
            else if (_phieuNhapXuat.CongCuDungCuList.Count == 0)
                MessageBox.Show(this, "Vui lòng nhập chi tiết phiếu xuất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (KiemTraChiTiet() == false)
                grdViewCt_PhieuNhap.Focus();
            else kq = true;
            return kq;
        }


        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CongCuDungCu congCuDungCu in _phieuNhapXuat.CongCuDungCuList)
            {
                if (congCuDungCu.MaHangHoa == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập hàng hóa cho công cụ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                else if (congCuDungCu.MaBoPhan == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập bộ phận nhận công cụ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            return kq;
        }


        #region btnLuu_ItemClick
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Bạn có muốn lưu?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.ChangeFocus();
                try
                {
                    if (KiemTraDuLieu())
                    {
                        _phieuNhapXuat.ApplyEdit();
                        _phieuNhapXuat.Save();
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        #region grdViewCt_PhieuNhap_CellValueChanged
        private void grdViewCt_PhieuNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colSoLuong" || grdViewCt_PhieuNhap.FocusedColumn.Name == "colNguyenGia")
            {
                Decimal tongTien = 0;
                foreach (CongCuDungCu congCu in _phieuNhapXuat.CongCuDungCuList)
                {
                    tongTien = tongTien + congCu.NguyenGia;
                }
                _phieuNhapXuat.GiaTriKho = tongTien;
            }
            else if (grdViewCt_PhieuNhap.FocusedColumn.Name == "colMaHangHoa")
            {
                HangHoaBQ_VT hangHoa = HangHoaBQ_VT.GetHangHoaBQ_VT(((CongCuDungCu)congCuDungCuListBindingSource.Current).MaHangHoa);
                CongCuDungCu congCu = CongCuDungCu.GetCongCuDungCuByMaHangHoa(hangHoa.MaHangHoa);
                int maCongCuDungCu;
                string MaQuanLy;
                if (congCu.MaCongCuDungCu != 0)
                {
                    maCongCuDungCu = Convert.ToInt32(congCu.MaQuanLy.Substring(congCu.MaQuanLy.Length - 3)) + 1;
                }
                else
                {
                    maCongCuDungCu = 1;
                }

                if (maCongCuDungCu < 10)
                    MaQuanLy = hangHoa.MaQuanLy + "00" + maCongCuDungCu.ToString();
                else if (maCongCuDungCu < 100)
                    MaQuanLy = hangHoa.MaQuanLy + "0" + maCongCuDungCu.ToString();
                else MaQuanLy = hangHoa.MaQuanLy + maCongCuDungCu.ToString();
                ((CongCuDungCu)congCuDungCuListBindingSource.Current).MaQuanLy = MaQuanLy;

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

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #region btnThemMoi_ItemClick
        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiTaoPhieu();
        }
        #endregion

        #region grdView_DinhKhoan_InitNewRow
        private void grdView_DinhKhoan_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            // Gan tien cho but toan
            ButToanPhieuNhapXuat butToan = (ButToanPhieuNhapXuat)(butToanPhieuNhapXuatListBindingSource.Current);
            butToan.NoTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("153");
            butToan.DienGiai = this.txtDienGiai.Text;
            decimal soTienConLai = _phieuNhapXuat.GiaTriKho;
            foreach (ButToanPhieuNhapXuat buttoanphieu in _phieuNhapXuat.ButToanPhieuNhapXuatList)
            {
                soTienConLai = soTienConLai - buttoanphieu.SoTien;
            }
            butToan.SoTien = soTienConLai;
            butToan.MaDoiTuongCo = _phieuNhapXuat.MaDoiTac;
        }
        #endregion

        #region grdViewCt_PhieuNhap_KeyDown
        private void grdViewCt_PhieuNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (int i in grdViewCt_PhieuNhap.GetSelectedRows())
                {
                    CongCuDungCu congCuDungCu = (grdViewCt_PhieuNhap.GetRow(i)) as CongCuDungCu;
                    _phieuNhapXuat.GiaTriKho = _phieuNhapXuat.GiaTriKho - congCuDungCu.NguyenGia;
                    grdViewCt_PhieuNhap.DeleteRow(i);
                }
            }
        }
        #endregion

        #region grdView_DinhKhoan_KeyDown
        private void grdView_DinhKhoan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (int i in grdView_DinhKhoan.GetSelectedRows())
                {
                    grdView_DinhKhoan.DeleteRow(i);
                }
            }
        }
        #endregion

        #region barBt_HangHoa_ItemClick
        private void barBt_HangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            decimal TongTien = 0;
            frmCongCuDungCu frm = new frmCongCuDungCu();
            if (frm.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                if (frm.TinhTrang == 1)
                {
                    foreach (CongCuDungCu congCuDungCu in frm.CongCuDungCuList)
                    {
                        TongTien = TongTien + congCuDungCu.NguyenGia;
                        _phieuNhapXuat.CongCuDungCuList.Add(congCuDungCu);
                    }
                }
            }
            _phieuNhapXuat.GiaTriKho = _phieuNhapXuat.GiaTriKho + TongTien;

        }
        #endregion

        #region lookUpEdit_PhongBan_EditValueChanged
        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            if (lookUpEdit_PhongBan.EditValue != null)
            {
                //
                thongTinNhanVienTongHopList_TheoPhongBanBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListKeCaNVBoPhanMoRong_ByMaBoPhan((int)lookUpEdit_PhongBan.EditValue);
            }
        }
        #endregion

        #region grdViewCt_PhieuNhap_InitNewRow
        private void grdViewCt_PhieuNhap_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            CongCuDungCu congCuDungCu = (CongCuDungCu)(congCuDungCuListBindingSource.Current);
            congCuDungCu.MaTaiKhoan = HeThongTaiKhoan1.LayMaTaiKhoan("153");
            congCuDungCu.NgayNhan = _phieuNhapXuat.NgayNX;
            if (lookUpEdit_PhongBan.EditValue != null)
            {
                congCuDungCu.CongCuDungCu_PhongBan.MaBoPhan = Convert.ToInt32(lookUpEdit_PhongBan.EditValue);
            }
        }
        #endregion

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Rpt_BienBanGiaoNhanCongCuDungCu rpt = new Rpt_BienBanGiaoNhanCongCuDungCu(_phieuNhapXuat.MaPhieuNhapXuat, _phieuNhapXuat.MaPhongBan);
            //FrmHienThiReportBQVT frm = new FrmHienThiReportBQVT(rpt);
            //frm.WindowState = FormWindowState.Maximized;
            //frm.ShowDialog();
            //
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
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _phieuNhapXuat.MaPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@MaPhongBan", _phieuNhapXuat.MaPhongBan);

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
            grdViewCt_PhieuNhap.DeleteSelectedRows();
        }




        #endregion//END Cac Ham cho RePort

        private void ChangeFocus()
        {
            this.txtBlackHole.Focus();
        }

        private void congCuDungCuListBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        private void btnToolStrip_ThemHangHoa_Click(object sender, EventArgs e)
        {
            XtraFrm_HangHoa frm = new XtraFrm_HangHoa(3);
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            }
        }

        private void frmNhapPhanBoCongCuDungCu_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.ConfigGridView(grdViewCt_PhieuNhap
                     , setSTT: true//
                     , initCopyCell: true//
                     , multiSelectCell: true//
                     , multiSelectRow: false
                     , initNewRowOnTop: true);//

            Utils.GridUtils.ConfigGridView(grdView_DinhKhoan
             , setSTT: true//
             , initCopyCell: true//
             , multiSelectCell: true//
             , multiSelectRow: false
             , initNewRowOnTop: true);//
  
        }
    }
}