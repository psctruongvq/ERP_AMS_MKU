using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;
using DevExpress.XtraGrid.Views.Grid;
using PSC_ERP_Business.Main.Predefined;
using PSC_ERP_Business.Main.Model.Context;

namespace PSC_ERP.ThuChiEntity
{
    public partial class frmTapHopChiPhiTheoThuLaoE : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        Entities _context = null;
        public tblChungTu _chungTu = null;
        tblButToan _butToan = null;
        private ChungTuThuChi_DerivedFactory _factory = null;
        List<spd_DanhSachChiPhiSanXuatTheoThang_Result> _chiThuLaoList = null;
        List<tblKy> _kyTinhLuongList = null;
        string _duLieu = "";
        tblCT_ChiPhiSanXuat _ChungTu_ChiPhiSX = null;
        List<tblCT_ChiPhiSanXuat> _ChungTu_ChiPhiSXList = null;
        public Boolean _isSave = false;
        List<spd_DanhSachChiPhiSanXuatTheoThang_Result> _chiThuLaoList_DaChon = null;

        private app_users _user;
        private int _maKyS;
        private DateTime _tuNgayS;
        private DateTime _denNgayS;
        #endregion//Properties

        #region Function

        private void KhoiTao()
        {
            DanhSachThuLao_bindingSource.DataSource = typeof(spd_DanhSachChiPhiSanXuatTheoThang_Result);
            tblKyBindingSource.DataSource = typeof(tblKy);

            DesigngrdV_DanhSachThuLao();
        }

        private void LoadData()
        {
            _factory = ChungTuThuChi_DerivedFactory.New();
            _chiThuLaoList = new List<spd_DanhSachChiPhiSanXuatTheoThang_Result>();
            _user = app_users_Factory.New().Get_AppUserByUserID(PSC_ERP_Global.Main.UserID);

            _chiThuLaoList_DaChon = frmBangKeE._chiThuLaoList_DaChon;
            #region Old
            //if (_chungTu.MaLoaiChungTu == 16)
            //    _chiThuLaoList_DaChon = frmBangKeE._chiThuLaoList_DaChon;
            //else if (_chungTu.MaLoaiChungTu == 2)
            //    _chiThuLaoList_DaChon = frmPhieuThuE._chiThuLaoList_DaChon;
            //else if (_chungTu.MaLoaiChungTu == 3)
            //    _chiThuLaoList_DaChon = frmPhieuChiE._chiThuLaoList_DaChon;
            #endregion//Old

            tblKyBindingSource.DataSource = KyTinhLuong_Factory.New().GetKyTinhLuongByMaCongTy(_user.MaCongTy.Value);
            dtmp_TuNgay.EditValue = DateTime.Today.Date;
            dtmp_DenNgay.EditValue = DateTime.Today.Date;

        }

        private void DesigngrdV_DanhSachThuLao()
        {
            grd_DanhSachThuLao.DataSource = DanhSachThuLao_bindingSource;

            HamDungChung.InitGridViewDev(grdV_DanhSachThuLao, false, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect, false, false, false, true);
            HamDungChung.ShowFieldGridViewDev2(grdV_DanhSachThuLao, new string[] { "Chon", "SoDNCK", "NgayDeNghi", "TenBoPhan", "MaChuongTrinhQL", "TenChuongTrinh", "MaGiayXacNhanQL", "SoTien", "TenLoaiNhanVien" },
                                new string[] { "Chọn", "Số Đề Nghị", "Ngày Đề Nghị", "Bộ Phận Nhập", "Mã Chương Trình", "Tên Chương Trình", "Số Giấy XN", "Số Tiền", "Loại NV" },
                                             new int[] { 60, 160, 100, 140, 100, 150, 100, 100, 80 }, true);


            HamDungChung.AlignHeaderColumnGridViewDev(grdV_DanhSachThuLao, new string[] { "Chon", "SoDNCK", "NgayDeNghi", "TenBoPhan", "MaChuongTrinhQL", "TenChuongTrinh", "MaGiayXacNhanQL", "SoTien", "TenLoaiNhanVien" }, DevExpress.Utils.HorzAlignment.Center);

            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdV_DanhSachThuLao, new string[] { "SoTien" }, "#,###.#");
            grdV_DanhSachThuLao.OptionsView.ShowAutoFilterRow = true;
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(grdV_DanhSachThuLao, new string[] { "SoTien" }, "{0:#,###.#}");
            //HamDungChung.NewRowGridViewDev(grdV_DanhSachChungTuKetChuyen);

            Utils.GridUtils.SetSTTForGridView(grdV_DanhSachThuLao, 40);//M

            HamDungChung.FormatNumberTypeofColumnGridViewDev(grdV_DanhSachThuLao, new string[] { "SoTien" });
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(grdV_DanhSachThuLao, new string[] { "SoTien" }, "#,###.#");

            HamDungChung.ReadOnlyColumnGridViewDev(grdV_DanhSachThuLao);
            grdV_DanhSachThuLao.Columns["Chon"].OptionsColumn.AllowFocus = true;
            grdV_DanhSachThuLao.Columns["Chon"].OptionsColumn.ReadOnly = false;
            grdV_DanhSachThuLao.Columns["Chon"].OptionsColumn.AllowEdit = true;
            this.grdV_DanhSachThuLao.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.grdV_DanhSachThuLaoRowCellClick);
        }

        private bool KiemTraDieuKienTim()
        {
            if (gridLUKy.EditValue == null || _maKyS == 0)
            {
                MessageBox.Show(this, "Chọn Kỳ Tính Lương Để Xem", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLUKy.Focus();
                return false;
            }
            _tuNgayS = (Convert.ToDateTime(dtmp_TuNgay.EditValue)).Date;
            _denNgayS = (Convert.ToDateTime(dtmp_DenNgay.EditValue)).Date;
            return true;
        }

        private bool KiemTraTruocKhiLuu()
        {
            if (_chiThuLaoList == null)
            {
                MessageBox.Show("Chưa có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            bool coChon = false;
            foreach (spd_DanhSachChiPhiSanXuatTheoThang_Result ctl in _chiThuLaoList)
            {
                if (ctl.Chon)
                {
                    coChon = true;
                    break;
                }
            }
            if (coChon == false)
            {
                MessageBox.Show("Vui lòng chọn dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        #endregion //Function

        #region Event

        private void Check_TatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_TatCa.Checked == true)
            {
                for (int i = 0; i < grdV_DanhSachThuLao.RowCount; i++)
                {
                    spd_DanhSachChiPhiSanXuatTheoThang_Result item = grdV_DanhSachThuLao.GetRow(i) as spd_DanhSachChiPhiSanXuatTheoThang_Result;
                    if (item.Chon == false)
                    {
                        item.Chon = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdV_DanhSachThuLao.RowCount; i++)
                {
                    spd_DanhSachChiPhiSanXuatTheoThang_Result item = grdV_DanhSachThuLao.GetRow(i) as spd_DanhSachChiPhiSanXuatTheoThang_Result;
                    item.Chon = false;
                }
            }
            grdV_DanhSachThuLao.RefreshData();
        }

        private void gridLUKy_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLUKy.EditValue != null)
            {
                int maky;
                if (int.TryParse(gridLUKy.EditValue.ToString(), out maky))
                {
                    if (maky != 0)
                    {
                        _maKyS = maky;
                        tblnsKyTinhLuong ky = KyTinhLuong_Factory.New().GetKyTinhLuongByIDMaKy_MaCongTy(maky, _user.MaCongTy.Value);
                        dtmp_TuNgay.EditValue = ky.NgayBatDau;
                        dtmp_DenNgay.EditValue = ky.NgayKetThuc;
                    }
                }

            }
        }

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            if (KiemTraDieuKienTim())
            {
                _chiThuLaoList = _factory.Context.spd_DanhSachChiPhiSanXuatTheoThang(_maKyS, _tuNgayS, _denNgayS, _user.UserID).ToList<spd_DanhSachChiPhiSanXuatTheoThang_Result>();

                if (_chiThuLaoList.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DanhSachThuLao_bindingSource.DataSource = _chiThuLaoList;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLog_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PSC_ERPNew.Main.Sys.frmEntityTrackingLog.ShowSingleton(null, BusinessCodeEnum.BangKe_ThuChi, this.MdiParent);
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //Chuyển focus để đảm bảo dữ liệu đã được chọn
            gridLUKy.Focus();
            if (KiemTraTruocKhiLuu())
            {
                _ChungTu_ChiPhiSXList = new List<tblCT_ChiPhiSanXuat>();
                List<spd_DanhSachChiPhiSanXuatTheoThang_Result> _chiThuLaoMoiNhatList = new List<spd_DanhSachChiPhiSanXuatTheoThang_Result>();
                int _bienTam = 0;
                bool daCoChiThuLao = false;

                #region Xu Lu
                foreach (spd_DanhSachChiPhiSanXuatTheoThang_Result ctl in _chiThuLaoList)
                {
                    if (ctl.Chon == true)
                    {
                        //ctl.MaLoaiKinhPhi = 1;
                        //ctl.MaBoPhanNhan = ctl.MaBoPhanGui;

                        //lay chung tu chi phi san xuat
                        _ChungTu_ChiPhiSX = new tblCT_ChiPhiSanXuat();
                        _ChungTu_ChiPhiSX.MaChuongTrinh = ctl.MaChuongTrinh;
                        _ChungTu_ChiPhiSX.SoTien = ctl.SoTien;
                        _ChungTu_ChiPhiSX.TaoTuTapHopCPSX = true;
                        if (ctl.LoaiNV == true)
                        {
                            //Lấy mã tiểu mục bởi mã quản lý (nhân viên thì lấy mã quản lý 7019)
                            tblTieuMucNganSach tieuMucNganSach = TieuMucNganSach_Factory.New().Get_TieuMucNganSachbyMaQuanLy("7019");

                            if (tieuMucNganSach != null)
                            {
                                tblButToan_MucNganSach butToanMucNganSach = new tblButToan_MucNganSach();
                                butToanMucNganSach.MaTieuMuc = tieuMucNganSach.MaTieuMuc;
                                butToanMucNganSach.SoTien = ctl.SoTien ?? 0;
                                butToanMucNganSach.DienGiai = "Quyết toán chương trình " + ctl.TenChuongTrinh.ToUpper() + " cho nhân viên";
                                _ChungTu_ChiPhiSX.tblButToan_MucNganSach.Add(butToanMucNganSach);
                                //_butToan.tblButToan_MucNganSach.Add(butToanMucNganSach);//T
                            }
                        }
                        else
                        {
                            //Lấy mã tiểu mục bởi mã quản lý (cộng tác viên thì lấy mã quản lý 7018)
                            tblTieuMucNganSach tieuMucNganSach = TieuMucNganSach_Factory.New().Get_TieuMucNganSachbyMaQuanLy("7018");

                            if (tieuMucNganSach != null)
                            {
                                tblButToan_MucNganSach butToanMucNganSach = new tblButToan_MucNganSach();
                                butToanMucNganSach.MaTieuMuc = tieuMucNganSach.MaTieuMuc;
                                butToanMucNganSach.SoTien = ctl.SoTien ?? 0;
                                butToanMucNganSach.DienGiai = "Quyết toán chương trình " + ctl.TenChuongTrinh.ToUpper() + " cho cộng tác viên";
                                _ChungTu_ChiPhiSX.tblButToan_MucNganSach.Add(butToanMucNganSach);
                                //_butToan.tblButToan_MucNganSach.Add(butToanMucNganSach);//T
                            }
                        }
                        //Lưu vết lại để tiến hành cập nhật mã chứng từ chi phí trong thù lao chương trình và thù lao nhân viên ngoài đài          
                        foreach (spd_DanhSachChiPhiSanXuatTheoThang_Result item in _chiThuLaoList_DaChon)
                        {//MaBoPhan là MaBoPhanGui Trong ThuLao
                            if (item.MaBoPhan == ctl.MaBoPhan && item.MaChuongTrinh == ctl.MaChuongTrinh && item.SoTien == ctl.SoTien && item.LoaiNV == ctl.LoaiNV && item.SoDNCK == ctl.SoDNCK)
                            {
                                daCoChiThuLao = true;
                                break;
                            }

                        }
                        if (daCoChiThuLao == false)
                        {
                            _ChungTu_ChiPhiSXList.Add(_ChungTu_ChiPhiSX);
                            _chiThuLaoList_DaChon.Add(ctl);
                        }
                        daCoChiThuLao = false;


                    }
                }
                //
                ///Nếu cùng chương trình thì sum số tiền lại 
                foreach (tblCT_ChiPhiSanXuat itemChiPhiSanXuat in _ChungTu_ChiPhiSXList)
                {
                    foreach (tblCT_ChiPhiSanXuat _itemChiPhiSanXuat in _butToan.tblCT_ChiPhiSanXuat)
                    {
                        //Nếu đã có trong danh sach thì cộng số tiền lại
                        if (_itemChiPhiSanXuat.MaChuongTrinh == itemChiPhiSanXuat.MaChuongTrinh)
                        {
                            _itemChiPhiSanXuat.SoTien += itemChiPhiSanXuat.SoTien;
                            _itemChiPhiSanXuat.TaoTuTapHopCPSX = true;

                            //Nếu cùng bút toán mục ngân sách thì cộng số tiền lại
                            if (itemChiPhiSanXuat.tblButToan_MucNganSach.FirstOrDefault().MaTieuMuc == _itemChiPhiSanXuat.tblButToan_MucNganSach.FirstOrDefault().MaTieuMuc)
                            {
                                _itemChiPhiSanXuat.tblButToan_MucNganSach.FirstOrDefault().SoTien += itemChiPhiSanXuat.tblButToan_MucNganSach.FirstOrDefault().SoTien;
                            }
                            else if (_itemChiPhiSanXuat.tblButToan_MucNganSach.Count > 1 && itemChiPhiSanXuat.tblButToan_MucNganSach.FirstOrDefault().MaTieuMuc == _itemChiPhiSanXuat.tblButToan_MucNganSach.ElementAtOrDefault(1).MaTieuMuc)
                            {
                                _itemChiPhiSanXuat.tblButToan_MucNganSach.ElementAtOrDefault(1).SoTien += itemChiPhiSanXuat.tblButToan_MucNganSach.FirstOrDefault().SoTien;

                            }
                            else // Nếu khác bút toán mục ngân sách sách tạo mới bút toán mục ngân sach1
                            {
                                tblButToan_MucNganSach butToanMucNganSach = new tblButToan_MucNganSach();
                                butToanMucNganSach.MaTieuMuc = itemChiPhiSanXuat.tblButToan_MucNganSach.FirstOrDefault().MaTieuMuc;
                                butToanMucNganSach.SoTien += itemChiPhiSanXuat.tblButToan_MucNganSach.FirstOrDefault().SoTien;
                                butToanMucNganSach.DienGiai = itemChiPhiSanXuat.tblButToan_MucNganSach.FirstOrDefault().DienGiai;
                                _itemChiPhiSanXuat.tblButToan_MucNganSach.Add(butToanMucNganSach);
                                //_butToan.tblButToan_MucNganSach.Add(butToanMucNganSach);//T
                            }
                            _bienTam = 1;
                        }
                    }

                    if (_bienTam == 0)//Nếu chưa có trong danh sách thì mới thêm vào
                    {
                        #region New
                        _chungTu.tblCT_ChiPhiSanXuat.Add(itemChiPhiSanXuat);
                        _butToan.tblCT_ChiPhiSanXuat.Add(itemChiPhiSanXuat);
                        #endregion//New
                    }

                    _bienTam = 0;
                }
                frmBangKeE._chiThuLaoList_DaChon = _chiThuLaoList_DaChon;

                //frmPhieuChiE._chiThuLaoList_DaChon = _chiThuLaoList_DaChon;
                //frmPhieuThuE._chiThuLaoList_DaChon = _chiThuLaoList_DaChon;
                _isSave = true;
                this.Close();

                #endregion//XuLy

            }




        }

        #endregion //Event

        #region EventHandler
        private void grdV_DanhSachThuLaoRowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (grdV_DanhSachThuLao.FocusedColumn.FieldName == "Chon")
            {
                spd_DanhSachChiPhiSanXuatTheoThang_Result currentItem = this.grdV_DanhSachThuLao.GetFocusedRow() as spd_DanhSachChiPhiSanXuatTheoThang_Result;
                if (currentItem != null)
                {
                    currentItem.Chon = !currentItem.Chon;
                    grdV_DanhSachThuLao.RefreshData();
                }
            }
        }
        #endregion //EventHandler

        public frmTapHopChiPhiTheoThuLaoE()
        {
            InitializeComponent();
        }
        public frmTapHopChiPhiTheoThuLaoE(Entities context, tblChungTu chungTu, tblButToan butToan)
        {
            InitializeComponent();
            _context = context;
            _chungTu = chungTu;
            _butToan = butToan;
            KhoiTao();
            LoadData();
        }








    }
}