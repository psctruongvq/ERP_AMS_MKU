using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
namespace PSC_ERP
{
    public partial class frmChiPhiSanXuatChuongTrinh_New : Form
    {
        ChuongTrinhList _chuongTrinhList = ChuongTrinhList.NewChuongTrinhList();
        public ChungTu_ChiPhiSanXuatList _ChungTu_ChiPhiSXList;
        public static ChungTu_ChiPhiSanXuatList _chungTu_ChiPhiSanXuatList = null;
        public static ChungTu_ChiPhiSanXuat _chungTuChiPhiSanXuat = null;
        ChungTu_ChiPhiSanXuatList _chungTu_ChiPhiSanXuatList_Deleted = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
        long maChungTu = 0;
        int maButToan = 0;
        string soChungTu = string.Empty;
        public bool IsSave = false;
        decimal soTien = 0;
        long maDoiTuong = 0;
        DateTime ngayLap = DateTime.Today.Date;
        string dienGiai = string.Empty;
        public decimal SoTienDaNhap = 0;
        public ChungTu _chungTu;
        HeThongTaiKhoan1List tklist;
        HeThongTaiKhoan1List tklistAll;
        public static decimal _soTienThuLao = 0;
        public static decimal _soTienChiPhi = 0;
        public static decimal _soTienTong = 0;
        public static ChungTu_ChiPhiSanXuat ct_ChiPhi;
        decimal _tongSoTienButToanMucNganSach = 0;
        string _dienGiaiMucNganSach = "";
        Util _Util = new Util();
        decimal _tongTienChiPhiSanXuatChuongTrinh = 0;
        ChungTu_ChiPhiSanXuatList _chungTu_ChiPhiSXList_Undo = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
        BoPhanList _boPhanDenList;
        Boolean _daTapHopChiPhiSanXuat = false;
        //public static ChungTu_ChiPhiSanXuatList _chungTu_ChiPhiSanXuatListFirst = null;
        #region BS
        private string _NoTK = string.Empty;
        private string _CoTK = string.Empty;

        #endregion//BS

        public bool DaTapHopChiPhiSanXuat
        {
            get
            {
                return _daTapHopChiPhiSanXuat;
            }
            set
            {
                if (!_daTapHopChiPhiSanXuat.Equals(value))
                {
                    _daTapHopChiPhiSanXuat = value;
                }
            }

        }
        public frmChiPhiSanXuatChuongTrinh_New()
        {
            InitializeComponent();
            bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            bd_ChungTuChiPhiSanXuat.DataSource = typeof(ChungTu_ChiPhiSanXuatList);
            BoPhanDen_bindingSourceList.DataSource = typeof(BoPhanList);
        }
        public frmChiPhiSanXuatChuongTrinh_New(ChungTu ct, ChungTu_ChiPhiSanXuatList list, decimal soTien, long maChungTu, string soChungTu, long maDoiTuong, DateTime ngayLap, string dienGiai, int maButToan, string noTK, string coTK)
        {
            InitializeComponent();
            _chungTu = ct;
            _ChungTu_ChiPhiSXList = list;
            #region BS
            _NoTK = noTK;
            _CoTK = coTK;
            //_chungTu_ChiPhiSanXuatListFirst = ChungTu_ChiPhiSanXuatList.NewChungTu_ChiPhiSanXuatList();
            //foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat in list)
            //{
            //    _chungTu_ChiPhiSanXuatListFirst.Add(chungTu_ChiPhiSanXuat);
            //}
            #endregion//BS

            //Setup dữ liệu (mã loại chi and mã bộ phận) phục vụ chứng từ chi phí sản xuất mới
            foreach (ChungTu_ChiPhiSanXuat ct_cpsx in _ChungTu_ChiPhiSXList)
            {
                if (ct_cpsx.ChiPhiThucHienList.Count != 0)
                {
                    ct_cpsx.MaLoaiChi = 3;
                }
                else if (ct_cpsx.ChiThuLaoList.Count != 0)
                {
                    ct_cpsx.MaLoaiChi = ct_cpsx.ChiThuLaoList[0].MaLoaiKinhPhi;
                    ct_cpsx.MaBoPhan = ct_cpsx.ChiThuLaoList[0].MaBoPhanNhan;
                }
                else
                {
                    ct_cpsx.MaLoaiChi = 0;
                    ct_cpsx.MaBoPhan = 0;
                }
            }
            this.bd_ChungTuChiPhiSanXuat.DataSource = _ChungTu_ChiPhiSXList;

            this.maChungTu = maChungTu;
            this.soChungTu = soChungTu;
            this.soTien = soTien;
            this.maDoiTuong = maDoiTuong;
            this.ngayLap = ngayLap;
            this.dienGiai = dienGiai;
            this.maButToan = maButToan;
            _dienGiaiMucNganSach = dienGiai;
            _tongTienChiPhiSanXuatChuongTrinh = soTien;

            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;
            if (ERP_Library.Security.CurrentUser.Info.UserID == 39)
            {
                ChungTu_ChiPhiSanXuatList liscp = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatUpdateDataTemp();
                liscp.ApplyEdit();
                liscp.Save();
            }
            _soTienThuLao = 0;
            _soTienChiPhi = 0;
            _soTienTong = 0;
            ct_ChiPhi = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();

            _boPhanDenList = BoPhanList.GetBoPhanListByAll();
            BoPhanDen_bindingSourceList.DataSource = _boPhanDenList;

            ////Cập nhật tên khách hàng trong chi phí thực hiện
            //foreach (ChungTu_ChiPhiSanXuat chungTuChiPhiSanXuat in _ChungTu_ChiPhiSXList)
            //{
            //    if (chungTuChiPhiSanXuat.ChiPhiThucHienList.Count != 0)
            //    {
            //        chungTuChiPhiSanXuat.ChiPhiThucHienList[0].MaDoiTuong = maDoiTuong;
            //    }
            //}

        }

        private bool KiemTraTruocKhiThoat()
        {
            if (_NoTK.Contains("1551") || _NoTK.Contains("1552") || _CoTK.Contains("1551") || _CoTK.Contains("1552") || _NoTK.Contains("631") || _NoTK.Contains("4314"))
            {
                if (_ChungTu_ChiPhiSXList.Count == 0)
                {
                    MessageBox.Show(this, "Bạn phải chọn công việc/chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    foreach (ChungTu_ChiPhiSanXuat cp in _ChungTu_ChiPhiSXList)
                    {
                        if (cp.ButtoanMucNganSachList.Count == 0 && (_NoTK.Contains("631") || _NoTK.Contains("4314")))
                        {
                            MessageBox.Show(this, "Vui lòng nhập mục ngân sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #region VatTu_Ban Quyen
        public frmChiPhiSanXuatChuongTrinh_New(ChungTu_ChiPhiSanXuatList list, decimal soTien, DateTime ngayLap, string dienGiai, int maButToan)
        {
            InitializeComponent();
            _ChungTu_ChiPhiSXList = list;


            this.bd_ChungTuChiPhiSanXuat.DataSource = _ChungTu_ChiPhiSXList;
            this.soTien = soTien;
            this.ngayLap = ngayLap;
            this.dienGiai = dienGiai;
            this.maButToan = maButToan;
            _dienGiaiMucNganSach = dienGiai;
            _tongTienChiPhiSanXuatChuongTrinh = soTien;

            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;
            if (ERP_Library.Security.CurrentUser.Info.UserID == 39)
            {
                ChungTu_ChiPhiSanXuatList liscp = ChungTu_ChiPhiSanXuatList.GetChungTu_ChiPhiSanXuatUpdateDataTemp();
                liscp.ApplyEdit();
                liscp.Save();
            }
            _soTienThuLao = 0;
            _soTienChiPhi = 0;
            _soTienTong = 0;
            ct_ChiPhi = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();

            //Dinh Dang Lai Luoi

            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = true;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChi"].Hidden = true;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = true;
            //

        }
        #endregion//VatTu_BanQuyen

        #region BoSungMaLoaiChi

        private void LockGrig()
        {
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellActivation = Activation.NoEdit;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChi"].CellActivation = Activation.NoEdit;
        }

        private void UnLockGrig()
        {
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].CellActivation = Activation.AllowEdit;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChi"].CellActivation = Activation.AllowEdit;
        }

        private bool CheckChiThuLaoChuaSuDung()
        {
            //Lấy chứng từ chi phí sản xuất hiện tại
            ChungTu_ChiPhiSanXuat chungTuChiPhiSanXuatCurrent = bd_ChungTuChiPhiSanXuat.Current as ChungTu_ChiPhiSanXuat;
            if (chungTuChiPhiSanXuatCurrent.ChiThuLaoList.Count != 0)
            {
                ChiThuLao chiThuLao = ChiThuLao.GetChiThuLao(chungTuChiPhiSanXuatCurrent.ChiThuLaoList[0].MaChiThuLao);
                if (ChiThuLao.CheckChiThuLaoDaSuDung(chiThuLao.MaChiThuLao))
                    return false;

            }
            return true;
        }

        private bool KiemTraTruocKhiXoa()
        {
            object[] rowList = grdData.Selected.Rows.All;
            foreach (object obj in rowList)
            {
                UltraGridRow row = obj as UltraGridRow;

                ChungTu_ChiPhiSanXuat ct_ChiPhi = row.ListObject as ChungTu_ChiPhiSanXuat;
                if (ct_ChiPhi.ChiThuLaoList.Count != 0)
                {
                    ChiThuLao chiThuLao = ChiThuLao.GetChiThuLao(ct_ChiPhi.ChiThuLaoList[0].MaChiThuLao);
                    if (ChiThuLao.CheckChiThuLaoDaSuDung(chiThuLao.MaChiThuLao))
                    {
                        MessageBox.Show("Chi phí đã Chi, không thể xóa. Vui lòng kiểm tra lại!", "Thông báo");
                        return false;
                    }

                }
            }
            return true;
        }


        private void grdData_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (CheckChiThuLaoChuaSuDung() == false)
            {
                LockGrig();
            }
            else
            {
                UnLockGrig();
            }

        }

        #endregion//BoSungMaLoaiChi
        private void frmChiPhiSanXuatChuongTrinh_Load(object sender, EventArgs e)
        {
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            tklist = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            bindingSource_TaiKhoanlist.DataSource = tklist;

            //tklistAll = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();
            //bindingSource_TaiKhoanAll.DataSource = tklist;

        }

        private void grdu_DSChiThuLao_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            //FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
            foreach (UltraGridBand ban in grdData.DisplayLayout.Bands)
            {
                ban.Hidden = true;
            } this.grdData.DisplayLayout.Bands[0].Hidden = false;
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "###,###,###,###,###,###";
                }
                col.Hidden = true;
            }

            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].EditorComponent = cmbu_ChuongTrinh;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.Caption = "Công Việc/CT";
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            grdData.DisplayLayout.Bands[0].Columns["MaChuongTrinh"].Header.VisiblePosition = 0;

            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;
            grdData.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;

            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].EditorComponent = ultraCombo_TaiKhoan;
            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.Caption = "Tài Khoản KC";
            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Width = 60;
            grdData.DisplayLayout.Bands[0].Columns["MaTaiKhoan"].Header.VisiblePosition = 2;

            grdData.DisplayLayout.Bands[0].Columns["ButToanMucNganSach"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["ButToanMucNganSach"].EditorComponent = tEMucNganSach;
            grdData.DisplayLayout.Bands[0].Columns["ButToanMucNganSach"].Header.Caption = "Mục NS";
            grdData.DisplayLayout.Bands[0].Columns["ButToanMucNganSach"].Width = 65;
            grdData.DisplayLayout.Bands[0].Columns["ButToanMucNganSach"].Header.VisiblePosition = 3;

            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChi"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChi"].EditorComponent = cmbu_LoaiChiPhi;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChi"].Header.Caption = "Loại Chi";
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChi"].Width = 135;
            grdData.DisplayLayout.Bands[0].Columns["MaLoaiChi"].Header.VisiblePosition = 4;

            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Hidden = false;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].EditorComponent = cmbu_BoPhanDen;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.Caption = "Bộ Phận Đến";
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Width = 150;
            grdData.DisplayLayout.Bands[0].Columns["MaBoPhan"].Header.VisiblePosition = 5;
        }

        private void cmbu_ChuongTrinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(grdData, "MaChuongTrinh", "TenChuongTrinh");
            foreach (UltraGridColumn col in this.cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 0;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = cmbu_ChuongTrinh.Width;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.Caption = "Mã QL";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["MaQL"].Header.VisiblePosition = 1;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Hidden = false;
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.Caption = "Tên Nguồn";
            cmbu_ChuongTrinh.DisplayLayout.Bands[0].Columns["TenNguon"].Header.VisiblePosition = 2;

        }



        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraTruocKhiThoat() == false)
                return;
            decimal _soTien = 0;
            Boolean coButToanMucNganSach = false;
            Boolean coChiPhiSanxuatChuongTrinh = false;
            _soTienThuLao = 0;
            _soTienChiPhi = 0;
            _tongSoTienButToanMucNganSach = 0;
            this.bd_ChungTuChiPhiSanXuat.EndEdit();
            grdData.UpdateData();
            _ChungTu_ChiPhiSXList = bd_ChungTuChiPhiSanXuat.DataSource as ChungTu_ChiPhiSanXuatList;
            foreach (ChungTu_ChiPhiSanXuat ct_cpsx in _ChungTu_ChiPhiSXList)
            {
                if (ct_cpsx.MaChuongTrinh == 0)
                {
                    MessageBox.Show("Vui lòng chọn chương trình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if ((ct_cpsx.MaLoaiChi == 1 || ct_cpsx.MaLoaiChi == 2) && ct_cpsx.MaBoPhan == 0)
                {
                    MessageBox.Show("Vui lòng chọn bộ phận.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ct_cpsx.MaChungTu = maChungTu;
                ct_cpsx.MaButToan = maButToan;
                ct_cpsx.SoChungTu = soChungTu;
                _soTien += ct_cpsx.SoTien;

                coChiPhiSanxuatChuongTrinh = true;

                foreach (ButToanMucNganSach item in ct_cpsx.ButtoanMucNganSachList)
                {
                    coButToanMucNganSach = true;
                    _tongSoTienButToanMucNganSach += item.SoTien;
                }
            }

            if (coButToanMucNganSach == true && _tongSoTienButToanMucNganSach != this.soTien && _daTapHopChiPhiSanXuat == false)
            {
                //Vat Tu_Ban Quyen
                if (_chungTu == null)
                {
                    MessageBox.Show("Số tiền bút toán mục ngân sách không bằng số tiền bút toán.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //End Vat Tu_Ban Quyen
                MessageBox.Show("Số tiền bút toán mục ngân sách không bằng số tiền bút toán.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                _ChungTu_ChiPhiSXList = _chungTu.ChungTuChiPhiSanXuatList;
                return;
            }

            if (coChiPhiSanxuatChuongTrinh == true && _soTien != this.soTien && _daTapHopChiPhiSanXuat == false)
            {
                //Vat Tu_Ban Quyen
                if (_chungTu == null)
                {
                    MessageBox.Show("Số tiền bút toán mục ngân sách không bằng số tiền bút toán.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return;
                }
                //End Vat Tu_Ban Quyen
                MessageBox.Show("Tổng số tiền chi phí sản xuất chương trình không bằng số tiền bút toán.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                _ChungTu_ChiPhiSXList = _chungTu.ChungTuChiPhiSanXuatList;
                return;
            }
            _ChungTu_ChiPhiSXList.ApplyEdit();
            IsSave = true;
            SoTienDaNhap = _soTien;
            this.Close();

        }

        private void tEChiPhi_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            _soTienChiPhi = 0;
            _soTienThuLao = 0;

            int maChuongTrinh = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChuongTrinh;
            string tenChuongTrinh = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).TenChuongTrinh;
            long maChungTu = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChungTu;
            string soChungTu = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).SoChungTu;

            ct_ChiPhi = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current);
            ct_ChiPhi.ChiPhiThucHienList.BeginEdit();

            if (ct_ChiPhi.MaChuongTrinh == 0)
            {
                MessageBox.Show("Vui lòng chọn chương trình.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            //lay so tien chi thu lao
            if (ct_ChiPhi.ChiThuLaoList != null)
            {
                foreach (ChiThuLao _chiThuLao in ct_ChiPhi.ChiThuLaoList)
                {
                    _soTienThuLao += _chiThuLao.SoTien;
                }
            }
            //Cập nhật tổng tiền chi phí sản xuất chương trình
            _tongTienChiPhiSanXuatChuongTrinh = ct_ChiPhi.SoTien - _soTienThuLao;

            frmChiPhiThucHien f = new frmChiPhiThucHien(ct_ChiPhi.ChiPhiThucHienList, maChungTu, soChungTu, maChuongTrinh, tenChuongTrinh, maDoiTuong, _tongTienChiPhiSanXuatChuongTrinh, ngayLap, dienGiai);

            if (f.ShowDialog() != DialogResult.OK)
            {
                if (f.IsSave == false)
                {
                    ct_ChiPhi.ChiPhiThucHienList.CancelEdit();
                }
            }
        }

        private void tEChiThuLao_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            _soTienThuLao = 0;
            _soTienChiPhi = 0;
            int maChuongTrinh = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChuongTrinh;
            string tenChuongTrinh = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).TenChuongTrinh;
            long maChungTu = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChungTu;
            string soChungTu = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).SoChungTu;

            ct_ChiPhi = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current);
            ct_ChiPhi.ChiThuLaoList.BeginEdit();

            if (ct_ChiPhi.MaChuongTrinh == 0)
            {
                MessageBox.Show("Vui lòng chọn chương trình.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            //lay so tien chi phi thuc hien
            if (ct_ChiPhi.ChiPhiThucHienList != null)
            {
                foreach (ChiPhiThucHien _chiPhiThucHien in ct_ChiPhi.ChiPhiThucHienList)
                {
                    _soTienChiPhi += _chiPhiThucHien.SoTien;
                }
            }

            //Cập nhật tổng tiền chi phí sản xuất chương trình
            _tongTienChiPhiSanXuatChuongTrinh = ct_ChiPhi.SoTien - _soTienChiPhi;

            frmChiThuLao f = new frmChiThuLao(_chungTu, ct_ChiPhi.ChiThuLaoList, maChuongTrinh, _tongTienChiPhiSanXuatChuongTrinh);
            if (f.ShowDialog() != DialogResult.OK)
            {
                if (f.Luu == false)
                {
                    ct_ChiPhi.ChiThuLaoList.CancelEdit();
                }
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (KiemTraTruocKhiXoa() == false)
                return;

            Boolean daCoButToanMucNganSach = false;

            if (grdData.Selected.Rows.Count == 0)
            {
                MessageBox.Show(_Util.chodongcanxoa, _Util.thongbao, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat = (ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current;

            foreach (ChungTu_ChiPhiSanXuat item in _chungTu_ChiPhiSanXuatList_Deleted)
            {
                if (item == chungTu_ChiPhiSanXuat)
                {
                    daCoButToanMucNganSach = true;
                }
            }
            if (daCoButToanMucNganSach == false)
                _chungTu_ChiPhiSanXuatList_Deleted.Add(chungTu_ChiPhiSanXuat);

            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            Boolean daCoButToanMucNganSach = false;
            ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat = (ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current;

            if (chungTu_ChiPhiSanXuat != null && chungTu_ChiPhiSanXuat.IsNew)//Nếu là đối tượng mới thì xóa đi
            {
                bd_ChungTuChiPhiSanXuat.Remove(chungTu_ChiPhiSanXuat);
            }
            else//Nếu là đối tượng cũ mà đã cập nhật dữ liệu thì trả về ban đầu
            {
                bd_ChungTuChiPhiSanXuat.CancelEdit();
            }
            //Nếu đã xóa đi dữ liệu cũ thì trả lại
            ChungTu_ChiPhiSanXuatList chungTu_ChiPhiSanXuatList_Current = bd_ChungTuChiPhiSanXuat.DataSource as ChungTu_ChiPhiSanXuatList;
            foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat_Deleted in _chungTu_ChiPhiSanXuatList_Deleted)
            {
                foreach (ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat_Current in chungTu_ChiPhiSanXuatList_Current)
                {
                    if (chungTu_ChiPhiSanXuat_Deleted == chungTu_ChiPhiSanXuat_Current)
                    {
                        daCoButToanMucNganSach = true;
                    }
                }
                if (daCoButToanMucNganSach == false)
                {
                    bd_ChungTuChiPhiSanXuat.Add(chungTu_ChiPhiSanXuat_Deleted);
                }
                daCoButToanMucNganSach = false;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdData_AfterRowInsert(object sender, RowEventArgs e)
        {

            if (ERP_Library.Security.CurrentUser.Info.MaCongTy == 3 && frmTamUng.MaChuongTrinh == 0)
            {
                ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChuongTrinh = 3741;
            }
            else
            {
                ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).MaChuongTrinh = frmTamUng.MaChuongTrinh;
            }

            bd_ChungTuChiPhiSanXuat.EndEdit();

            ChungTu_ChiPhiSanXuatList ChiPhiSXList = bd_ChungTuChiPhiSanXuat.DataSource as ChungTu_ChiPhiSanXuatList;
            decimal soTienDaNhapChiPhiSXChuongTrinh = 0;
            //Lấy số tiền đã phân bổ chi phí sản xuất chương trình
            foreach (ChungTu_ChiPhiSanXuat cp in ChiPhiSXList)
            {
                soTienDaNhapChiPhiSXChuongTrinh += cp.SoTien;
            }

            ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).SoTien = soTien - soTienDaNhapChiPhiSXChuongTrinh;


        }

        private void ultraCombo_TaiKhoan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_TaiKhoan.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            FilterCombo f = new FilterCombo(ultraCombo_TaiKhoan, "SoHieuTK");
        }

        private void ultraCombo_TaiKhoanAll_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Hidden = false;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.Caption = "Số Hiệu TK";
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Header.VisiblePosition = 1;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["SoHieuTK"].Width = 70;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Hidden = false;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.Caption = "Tên Tài Khoản";
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Width = 200;
            ultraCombo_TaiKhoanAll.DisplayLayout.Bands[0].Columns["TenTaiKhoan"].Header.VisiblePosition = 2;
            FilterCombo f = new FilterCombo(ultraCombo_TaiKhoanAll, "SoHieuTK");
        }

        private void ultraCombo_TaiKhoanAll_ValueChanged(object sender, EventArgs e)
        {
            //if(ultraCombo_TaiKhoanAll.Value!= null)
            //{
            //    foreach (ChungTu_ChiPhiSanXuat ctcp in _ChungTu_ChiPhiSXList)
            //    {
            //        ctcp.MaTaiKhoan = Convert.ToInt32(ultraCombo_TaiKhoanAll.Value);
            //    }   
            //}
        }

        private void LocDanhSachChungTuChiPhiSanXuat(ChungTu_ChiPhiSanXuatList chungTuChiPhiSanXuatList_Current)
        {
            if (_chungTu_ChiPhiSanXuatList == null)
                return;

            foreach (ChungTu_ChiPhiSanXuat itemCurrent in chungTuChiPhiSanXuatList_Current)
            {
                ChungTu_ChiPhiSanXuat chungTuChiPhiSanXuatcanXoa = null;

                foreach (ChungTu_ChiPhiSanXuat item in _chungTu_ChiPhiSanXuatList)
                {
                    if (itemCurrent.MaChuongTrinh == item.MaChuongTrinh && itemCurrent.ButtoanMucNganSachList[0].MaTieuMucNganSach == item.ButtoanMucNganSachList[0].MaTieuMucNganSach)
                    {
                        //Cập nhật lại số tiền và bút toán mục ngân sách 
                        {
                            itemCurrent.SoTien = item.SoTien;
                            itemCurrent.ButtoanMucNganSachList[0].SoTien = item.ButtoanMucNganSachList[0].SoTien;
                        }
                        chungTuChiPhiSanXuatcanXoa = item;
                    }
                }

                //Tiến hành xóa chứng từ đã tồn tại trong danh sach
                if (chungTuChiPhiSanXuatcanXoa != null)
                {
                    _chungTu_ChiPhiSanXuatList.Remove(chungTuChiPhiSanXuatcanXoa);
                }
            }
        }
        private void tlslblDanhSach_Click(object sender, EventArgs e)
        {
            ((ChungTu_ChiPhiSanXuatList)bd_ChungTuChiPhiSanXuat.DataSource).ApplyEdit();

            frmTapHopChiPhiTheoThuLao_New frm = new frmTapHopChiPhiTheoThuLao_New();

            if (frm.ShowDialog() != DialogResult.OK)
            {
                if (frm._isSave == true)
                {
                    //Lấy danh sach chứng từ hiện tại
                    ChungTu_ChiPhiSanXuatList chungTuChiPhiSanXuatList_Current = bd_ChungTuChiPhiSanXuat.DataSource as ChungTu_ChiPhiSanXuatList;

                    //Xóa chương trình đã tồn tại
                    LocDanhSachChungTuChiPhiSanXuat(chungTuChiPhiSanXuatList_Current);

                    if (_chungTu_ChiPhiSanXuatList != null && _chungTu_ChiPhiSanXuatList.Count != 0)
                    {
                        //Đưa dữ liệu vào bindingSource
                        foreach (ChungTu_ChiPhiSanXuat item in _chungTu_ChiPhiSanXuatList)
                        {
                            bd_ChungTuChiPhiSanXuat.Add(item);
                        }

                        _daTapHopChiPhiSanXuat = true;

                        //Focus vào dòng đầu tiên
                        grdData.ActiveRow = grdData.Rows[0];
                    }

                    if (chungTuChiPhiSanXuatList_Current.Count > 0)
                    {
                        _daTapHopChiPhiSanXuat = true;
                    }

                    ((ChungTu_ChiPhiSanXuatList)bd_ChungTuChiPhiSanXuat.DataSource).ApplyEdit();
                }
                else
                {
                    bd_ChungTuChiPhiSanXuat.CancelEdit();
                }
            }
        }

        private void tblThem_Click(object sender, EventArgs e)
        {
            bd_ChungTuChiPhiSanXuat.EndEdit();
            ChungTu_ChiPhiSanXuatList ChiPhiSXList = bd_ChungTuChiPhiSanXuat.DataSource as ChungTu_ChiPhiSanXuatList;
            decimal soTienDaNhapChiPhiSXChuongTrinh = 0;
            //Lấy số tiền đã phân bổ chi phí sản xuất chương trình
            foreach (ChungTu_ChiPhiSanXuat cp in ChiPhiSXList)
            {
                soTienDaNhapChiPhiSXChuongTrinh += cp.SoTien;
            }

            bd_ChungTuChiPhiSanXuat.EndEdit();
            ChungTu_ChiPhiSanXuat chungTu_ChiPhiSanXuat = ChungTu_ChiPhiSanXuat.NewChungTu_ChiPhiSanXuat();
            chungTu_ChiPhiSanXuat.SoTien = this.soTien - soTienDaNhapChiPhiSXChuongTrinh;
            bd_ChungTuChiPhiSanXuat.Add(chungTu_ChiPhiSanXuat);
            // bd_ChungTuChiPhiSanXuat.DataSource = _ChungTu_ChiPhiSXList;

            _ChungTu_ChiPhiSXList = bd_ChungTuChiPhiSanXuat.DataSource as ChungTu_ChiPhiSanXuatList;
            grdData.ActiveRow = grdData.Rows[_ChungTu_ChiPhiSXList.Count - 1];
        }

        private void tEMucNganSach_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).BeginEdit();
            _chungTuChiPhiSanXuat = ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current);

            if (_chungTuChiPhiSanXuat.MaChuongTrinh == 0)
            {
                MessageBox.Show("Vui lòng chọn chương trình.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }
            ButtoanMucNganSachList mnsList = ButtoanMucNganSachList.NewButtoanMucNganSachList();
            foreach (ButToanMucNganSach btmns in _chungTuChiPhiSanXuat.ButtoanMucNganSachList)
            {
                mnsList.Add(btmns);
            }
            mnsList.BeginEdit();
            //frmDinhKhoan_MucNganSach_New frm = new frmDinhKhoan_MucNganSach_New(_chungTuChiPhiSanXuat.ButtoanMucNganSachList, _chungTuChiPhiSanXuat.SoTien, _dienGiaiMucNganSach, _NoTK);
            frmDinhKhoan_MucNganSach_New frm = new frmDinhKhoan_MucNganSach_New(mnsList, _chungTuChiPhiSanXuat.SoTien, _dienGiaiMucNganSach, _NoTK);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                if (frmDinhKhoan_MucNganSach_New.isSave == true)
                {
                    ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).ButtoanMucNganSachList=frm._butToanMNSList;
                    ((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).ApplyEdit();

                }
                else
                {
                    //((ChungTu_ChiPhiSanXuat)bd_ChungTuChiPhiSanXuat.Current).CancelEdit();
                    mnsList.CancelEdit();
                }
            }
        }

        private void cmbu_BoPhanDen_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            //  FilterCombo f = new FilterCombo(grdu_DSChiThuLao, "MaBoPhanNhan", "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 250;

            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_BoPhanDen.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Width = 100;
        }
        private void grdData_AfterCellUpdate(object sender, CellEventArgs e)
        {

            //Cập nhật lại dữ liệu trên lưới
            grdData.UpdateData();

            //Lấy chứng từ chi phí sản xuất hiện tại
            ChungTu_ChiPhiSanXuat chungTuChiPhiSanXuatCurrent = bd_ChungTuChiPhiSanXuat.Current as ChungTu_ChiPhiSanXuat;

            if (chungTuChiPhiSanXuatCurrent.MaLoaiChi == 0)
            {

                if (chungTuChiPhiSanXuatCurrent.ChiPhiThucHienList.Count != 0)
                {
                    ChiPhiThucHien chiPhiThucHienDelete = ChiPhiThucHien.GetChiPhiThucHien(chungTuChiPhiSanXuatCurrent.ChiPhiThucHienList[0].MaChiPhiThucHien);
                    //xóa tất cả chi phí thực hiện
                    chungTuChiPhiSanXuatCurrent.ChiPhiThucHienList.Remove(chiPhiThucHienDelete);
                }

                if (chungTuChiPhiSanXuatCurrent.ChiThuLaoList.Count != 0)
                {
                    ChiThuLao chiThuLaoDelete = ChiThuLao.GetChiThuLao(chungTuChiPhiSanXuatCurrent.ChiThuLaoList[0].MaChiThuLao);
                    //xóa tất cả chi thù lao 
                    chungTuChiPhiSanXuatCurrent.ChiThuLaoList.Remove(chiThuLaoDelete);
                }

                //Set mã bộ phận 
                chungTuChiPhiSanXuatCurrent.MaBoPhan = 0;
            }
            else if (chungTuChiPhiSanXuatCurrent.MaLoaiChi == 3 && maDoiTuong == 0)
            {
                MessageBox.Show("Chưa chọn Tên Khách Hàng.", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                chungTuChiPhiSanXuatCurrent.MaLoaiChi = 0;
                return;
            }
            else if (chungTuChiPhiSanXuatCurrent.MaLoaiChi == 3 && maDoiTuong != 0)
            {
                if (chungTuChiPhiSanXuatCurrent.ChiPhiThucHienList.Count == 0)
                {

                    ChiPhiThucHien chiPhiThucHien = ChiPhiThucHien.NewChiPhiThucHien();
                    chiPhiThucHien.MaDoiTuong = maDoiTuong;
                    chiPhiThucHien.SoTien = chungTuChiPhiSanXuatCurrent.SoTien;
                    chiPhiThucHien.NgayLap = DateTime.Now.Date;
                    chiPhiThucHien.MaLoaiChiPhiSanXuat = 1;
                    chiPhiThucHien.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                    //Lấy dữ liệu cho chi phí thực hiện chương trình
                    chungTuChiPhiSanXuatCurrent.ChiPhiThucHienList.Add(chiPhiThucHien);

                    //Set mã bộ phận 
                    chungTuChiPhiSanXuatCurrent.MaBoPhan = 0;
                }
                else
                {
                    chungTuChiPhiSanXuatCurrent.ChiPhiThucHienList[0].MaDoiTuong = maDoiTuong;
                    chungTuChiPhiSanXuatCurrent.ChiPhiThucHienList[0].SoTien = chungTuChiPhiSanXuatCurrent.SoTien;

                    //Set mã bộ phận 
                    chungTuChiPhiSanXuatCurrent.MaBoPhan = 0;
                }
            }
            else if (chungTuChiPhiSanXuatCurrent.MaBoPhan != 0)
            {
                if (chungTuChiPhiSanXuatCurrent.ChiThuLaoList.Count == 0)
                {
                    ChiThuLao chiThuLao = ChiThuLao.NewChiThuLao();
                    chiThuLao.MaBoPhanNhan = chungTuChiPhiSanXuatCurrent.MaBoPhan;
                    chiThuLao.SoTien = chungTuChiPhiSanXuatCurrent.SoTien;
                    chiThuLao.NgayThucHienChi = DateTime.Now.Date;
                    chiThuLao.MaLoaiKinhPhi = chungTuChiPhiSanXuatCurrent.MaLoaiChi;
                    //Lấy dữ liệu cho chi phí thù lao chương trình
                    chungTuChiPhiSanXuatCurrent.ChiThuLaoList.Add(chiThuLao);
                }
                else
                {
                    chungTuChiPhiSanXuatCurrent.ChiThuLaoList[0].MaBoPhanNhan = chungTuChiPhiSanXuatCurrent.MaBoPhan;
                    chungTuChiPhiSanXuatCurrent.ChiThuLaoList[0].SoTien = chungTuChiPhiSanXuatCurrent.SoTien;
                    chungTuChiPhiSanXuatCurrent.ChiThuLaoList[0].MaLoaiKinhPhi = chungTuChiPhiSanXuatCurrent.MaLoaiChi;
                }
            }
        }

        private void frmChiPhiSanXuatChuongTrinh_New_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (IsSave == false)
            //{
            //    if (KiemTraTruocKhiThoat() == false)
            //        e.Cancel = true;
            //    //if (_chungTu_ChiPhiSanXuatList.IsDirty)
            //    //{
            //    //    DialogResult kq = MessageBox.Show("Bạn có muốn lưu sự chuyển đổi?", "Hộp Thoại Xác Nhận!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            //    //    if (kq == DialogResult.Yes)
            //    //    {
            //    //        tlslblLuu.PerformClick();
            //    //    }
            //    //    else if (kq == DialogResult.No)
            //    //    {
            //    //        _chungTu_ChiPhiSanXuatList = _chungTu_ChiPhiSanXuatListFirst;
            //    //    }
            //    //    else if (kq == DialogResult.Cancel)
            //    //    {
            //    //        e.Cancel = true;
            //    //    }

            //    //}
            //}
            
        }

        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true;
            }
        }



    }
}
