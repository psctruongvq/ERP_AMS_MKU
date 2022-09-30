using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using System.Data.OleDb;
using System.Data.SqlClient;
using Infragistics.Win;
using PSC_ERP_Common;


namespace PSC_ERP
{//lan
    public partial class frmThuLaoChuongTrinh_NgoaiDai_TienMat : Form
    {
        ChiThuLao _chiThuLao_NhanVienList = ChiThuLao.NewChiThuLao();
        //ChiThuLaoList _chiThuLaoList;
        ChiThuLaoTongHopList _chiThuLaoList;
        BoPhanList _boPhanList;
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        NhanVienNgoaiDaiList _nhanVienList;
        ThuLaoNhanVienNgoaiDaiList _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();

        //GiayXacNhanChuongTrinhList _giayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        //ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        //ChiTietGiayXacNhan chiTietGXN = ChiTietGiayXacNhan.NewChiTietGiayXacNhan();
        ChiTietGiayXacNhanTongHopList _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.NewChiTietGiayXacNhanTongHopList();
        ChiTietGiayXacNhanTongHop chiTietGXN = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop();

        decimal _tienChiTietGiayXacNhan = 0;
        decimal _tienTuPhieuChi = 0;
        string tenNguon = string.Empty;
        int maNguon = 0;
        int maBoPhanDen = 0;
        DateTime _ngayLap;
        int loaiNhanVien = 0;
        static int maBoPhan = 0;
        static int maKyTinhluong = 0;
        int maChuongTrinh = 0;
        string tenGiayXacNhan = string.Empty;
        string tenChuongTrinh = string.Empty;
        long maChiThuLao = 0;
        string soChungTu = string.Empty;
        long maChungTu = 0;
        string ghiChuPhieuChi = string.Empty;
        int maChiTietGiayXacNhan = 0;
        int maGiayXacNhan = 0;
        public bool _hoanTat = false;
        bool nhapHo = false;
        DateTime _NgayChungTu;
        long _maChiThuLao_Update = 0;
        decimal _tongTienChoPhepCapNhat = 0;
        Boolean _suaDuLieu = false;

        const int _maLoaiChi = 1;//Chi Thu Lao
        private long _maPhieuChi = 0;//Lap Thu Lao tu PhieuChi

        private void LoadControls()
        {
            _boPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            //chuong trinh
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;


            ///------Chay cham--------////
            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            ///------Chay nhanh--------////
            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            _nhanVienList = NhanVienNgoaiDaiList.NewNhanVienNgoaiDaiList();
            bindingSource1_NhanVien.DataSource = _nhanVienList;
                
            _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;

            //_chiThuLaoList = ChiThuLaoList.GetChiThuLaoListByUser(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiThuLao itemChiTL = ChiThuLao.NewChiThuLao("Không Có Chứng Từ");
            //_chiThuLaoList.Insert(0, itemChiTL);
            //this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

            //_chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update);
            #region BoSung Lap ThuLao tu PhieuChi
            if (_maPhieuChi != 0)
            {
                _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update, _maLoaiChi, _maPhieuChi);
            }
            else
            #endregion//BoSung Lap ThuLao tu PhieuChi
                _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update, _maLoaiChi);
            ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
            _chiThuLaoList.Insert(0, itemChiTL);
            this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

            dateTimePicker_NgayLap.Value = DateTime.Today;
        }


        public frmThuLaoChuongTrinh_NgoaiDai_TienMat()
        {
            InitializeComponent();

            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = typeof(ThuLaoNhanVienNgoaiDaiList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChiThuLaoList);
            bindingSource1_NhanVien.DataSource = typeof(NhanVienNgoaiDaiList);
            LoadControls();
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            dateTimePicker_NgayLap.Value = DateTime.Today;

        }

        public frmThuLaoChuongTrinh_NgoaiDai_TienMat(long maPhieuChi)//
        {
            _maPhieuChi = maPhieuChi;
            InitializeComponent();

            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = typeof(ThuLaoNhanVienNgoaiDaiList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChiThuLaoList);
            bindingSource1_NhanVien.DataSource = typeof(NhanVienNgoaiDaiList);
            LoadControls();
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            dateTimePicker_NgayLap.Value = DateTime.Today;

            #region T/h muon xem lai thu lao cua phieu chi
            //_maPhieuChi = maPhieuChi;
            //InitializeComponent();
            //KhoiTao(_maPhieuChi);
            //grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            //grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            //grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            //grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            //grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            //grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            //grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            //dateTimePicker_NgayLap.Value = DateTime.Today;
            //_suaDuLieu = true;
            #endregion//T/h muon xem lai thu lao cua phieu chi

        }

        public frmThuLaoChuongTrinh_NgoaiDai_TienMat(int _maKyTinhLuong, int _maChuongTrinh, int maChiTietGiayXacNhan, string maPhieuChi, DateTime ngayLap, long maChiThuLao)
        {
            InitializeComponent();
            KhoiTao(_maKyTinhLuong, _maChuongTrinh, maPhieuChi, ngayLap, maChiThuLao, maChiTietGiayXacNhan);
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            dateTimePicker_NgayLap.Value = DateTime.Today;
            _suaDuLieu = true;
        }
        private void frmThuLaoChuongTrinh_Load(object sender, EventArgs e)
        {
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, Infragistics.Win.UltraWinGrid.UltraGridState.AddRow, 0, 0, 0));
            cmbu_ChuongTrinh.Enabled = false;
        }

        public void KhoiTao(int _maKyTinhLuong, int _maChuongTrinh, string maPhieuChi, DateTime ngayLap, long _maChiThuLao, int _maChiTietGiayXacNhan)
        {
            _maChiThuLao_Update = _maChiThuLao;
            LoadControls();
            cbKyTinhLuong.Value = _maKyTinhLuong;
            cmbu_ChuongTrinh.EditValue = _maChuongTrinh;
            cbChungTu.Value = _maChiThuLao;
            maChuongTrinh = _maChuongTrinh;
            maChiTietGiayXacNhan = _maChiTietGiayXacNhan;
            _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.GetThuLaoChuongTrinhListByPhieuChi(maBoPhan, _maChuongTrinh, maKyTinhluong, maPhieuChi, _maChiThuLao, _maChiTietGiayXacNhan, false, ngayLap);
            maKyTinhluong = _maKyTinhLuong;
            soChungTu = maPhieuChi;
            if (_thuLaoChuongTrinhList.Count != 0)
            {
                dateTimePicker_NgayLap.Value = _thuLaoChuongTrinhList[0].NgayLap;
            }
            if (_maChiThuLao != 0)
            {
                ChiThuLao ct = ChiThuLao.GetChiThuLao(_maChiThuLao);
                _hoanTat = ct.HoanTat;
            }


            bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
            this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

            _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
        }

        public void KhoiTao(long maPhieuChi)
        {
            _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.GetThuLaoChuongTrinhList_MaPhieuChi(maPhieuChi);
            if(_thuLaoChuongTrinhList.Count==0)
            {
                LoadControls();
            }
            else
            {

                this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
                _maChiThuLao_Update = _thuLaoChuongTrinhList[0].MaChiThuLao;
                //
                _boPhanList = BoPhanList.GetBoPhanListByAll();
                BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
                _boPhanList.Insert(0, itemBoPhan);
                this.bindingSource1_BoPhan.DataSource = _boPhanList;
                //chuong trinh
                _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
                this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

                _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
                this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
                _nhanVienList = NhanVienNgoaiDaiList.NewNhanVienNgoaiDaiList();
                bindingSource1_NhanVien.DataSource = _nhanVienList;
                #region BoSung Lap ThuLao tu PhieuChi
                if (_maPhieuChi != 0)
                {
                    _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update, _maLoaiChi, _maPhieuChi);
                }
                else
                #endregion//BoSung Lap ThuLao tu PhieuChi
                    _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update, _maLoaiChi);
                ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
                _chiThuLaoList.Insert(0, itemChiTL);
                this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

                dateTimePicker_NgayLap.Value = DateTime.Today;
                //
                cbKyTinhLuong.Value = _thuLaoChuongTrinhList[0].MaKyTinhLuong;
                cmbu_ChuongTrinh.EditValue = _thuLaoChuongTrinhList[0].MaChuongTrinh;
                cbChungTu.Value = _thuLaoChuongTrinhList[0].MaChiThuLao;
                maChuongTrinh = _thuLaoChuongTrinhList[0].MaChuongTrinh;
                maChiTietGiayXacNhan = _thuLaoChuongTrinhList[0].MaChiTietGiayXacNhan;
                maKyTinhluong = _thuLaoChuongTrinhList[0].MaKyTinhLuong;
                soChungTu = _thuLaoChuongTrinhList[0].SoChungTu;
                
                    dateTimePicker_NgayLap.Value = _thuLaoChuongTrinhList[0].NgayLap;
                    if (_thuLaoChuongTrinhList[0].MaChiThuLao != 0)
                {
                    ChiThuLao ct = ChiThuLao.GetChiThuLao(_thuLaoChuongTrinhList[0].MaChiThuLao);
                    _hoanTat = ct.HoanTat;
                }

                this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

                _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
            }
            
        }

        private decimal TongSoTienToiDaChoPhepCapNhat()
        {
            decimal soTienDaNhapThuLao = 0;
            decimal soTienChoPhepCapNhat = 0;
            foreach (ThuLaoNhanVienNgoaiDai item in _thuLaoChuongTrinhList)
            {
                soTienDaNhapThuLao += item.SoTien;
            }
            soTienChoPhepCapNhat += soTienDaNhapThuLao + Convert.ToDecimal(tbSoTienConLaiPC.Value);

            return soTienChoPhepCapNhat;
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbu_Bophan.ActiveRow != null)
                {
                    maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
                }
                _nhanVienList = NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList(maBoPhan, loaiNhanVien);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void chkAlldanhsach_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlldanhsach.Checked == true)
            {
                for (int i = 0; i < ultraGrid_DSNhanVien.Rows.Count; i++)
                {
                    if (!ultraGrid_DSNhanVien.Rows[i].Hidden == true && ultraGrid_DSNhanVien.Rows[i].IsFilteredOut == false)
                    {
                        ultraGrid_DSNhanVien.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ultraGrid_DSNhanVien.Rows.Count; i++)
                {
                    ultraGrid_DSNhanVien.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue == null || (cmbu_ChuongTrinh.EditValue != null && Convert.ToInt32(cmbu_ChuongTrinh.EditValue) == 0))
            {
                MessageBox.Show("Vui Lòng Chọn Chương Trình ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbu_ChuongTrinh.Focus();
                return;
            }
            if (cbKyTinhLuong.Value == null || (cbKyTinhLuong.Value != null && Convert.ToInt32(cbKyTinhLuong.Value) == 0))
            {
                MessageBox.Show("Vui Lòng Chọn Kỳ Tính Lương ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbKyTinhLuong.Focus();
                return;
            }

            {
                DialogResult _DialogResult = MessageBox.Show("Bạn Có Đồng Ý Đứa Nhân Viên Qua", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < ultraGrid_DSNhanVien.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid_DSNhanVien.Rows[i].Cells["Check"].Value == true)
                        {

                            if (ultraGrid_DSNhanVien.Rows[i].Cells["Cmnd"].Value.ToString().Replace(" ", "") == "")
                            {
                                MessageBox.Show("[" + ultraGrid_DSNhanVien.Rows[i].Cells["TenNhanVien"].Value + "] chưa có chứng minh nhân dân.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
                                return;
                            }
                            else
                            {//Thỏa các điều kiện trên
                                ThuLaoNhanVienNgoaiDai thuLao = ThuLaoNhanVienNgoaiDai.NewThuLaoNhanVienNgoaiDai();

                                thuLao.MaChuongTrinh = maChuongTrinh;
                                thuLao.MaKyTinhLuong = maKyTinhluong;
                                thuLao.MaNhanVien = (long)ultraGrid_DSNhanVien.Rows[i].Cells["MaNhanVien"].Value;
                                thuLao.TenNhanVien = (string)ultraGrid_DSNhanVien.Rows[i].Cells["TenNhanVien"].Value;
                                thuLao.Cmnd = (string)ultraGrid_DSNhanVien.Rows[i].Cells["CMND"].Value;
                                thuLao.MaSoThue = (string)ultraGrid_DSNhanVien.Rows[i].Cells["MST"].Value;
                                thuLao.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                                thuLao.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

                                thuLao.MaGiayXacNhan = maGiayXacNhan;
                                thuLao.MaBoPhan = (int)ultraGrid_DSNhanVien.Rows[i].Cells["MaBoPhan"].Value;
                                thuLao.DienGiai = ghiChuPhieuChi;
                                thuLao.TenBoPhan = (string)ultraGrid_DSNhanVien.Rows[i].Cells["TenBoPhan"].Value;
                                //if (!HamDungChung.KiemTraLaKyTu((string)ultraGrid_DSNhanVien.Rows[i].Cells["GhiChu"].Value))
                                //{
                                thuLao.SoTien = Convert.ToDecimal(ultraGrid_DSNhanVien.Rows[i].Cells["SoTien"].Value);
                                //}
                                thuLao.ThanhToan = false;
                                thuLao.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                                thuLao.DuocNhapHo = nhapHo;
                                thuLao.TenGiayXacNhan = tenGiayXacNhan;
                                thuLao.TenChuongTrinh = tenChuongTrinh;
                                thuLao.SoChungTu = soChungTu;
                                thuLao.MaChiThuLao = maChiThuLao;
                                _thuLaoChuongTrinhList.Add(thuLao);
                            }
                        }
                    }
                    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
                    this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

                    for (int i = 0; i < ultraGrid_DSNhanVien.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid_DSNhanVien.Rows[i].Cells["Check"].Value == true)
                        {
                            ultraGrid_DSNhanVien.Rows[i].Cells["Check"].Value = false;
                            ultraGrid_DSNhanVien.Rows[i].Hidden = true;
                        }
                    }
                    this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                }
                else
                {
                    return;
                }
            }
        }


        private void ComBoChangedValue()
        {
            lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            try
            {
                if (cbChungTu.Value == null || (cbChungTu.Value != null && Convert.ToInt32(cbChungTu.Value) == 0))
                {
                    MessageBox.Show("Vui lòng chọn chứng từ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(maKyTinhluong);


                if (_hoanTat == true && soChungTu != "")
                {
                    MessageBox.Show("Phiếu Chi đã  hoàn tất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    //if (maChiTietGiayXacNhan != 0 && maChiThuLao != 0)
                    //{
                    //    if (GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(maGiayXacNhan).MaChuongTrinh != ChiThuLao.GetChiThuLao(maChiThuLao).MaChuongTrinh)
                    //    {
                    //        MessageBox.Show("Chương trình từ Giấy Xác Nhận và Phiếu Chi không giống nhau", "ThôngBáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        return;
                    //    }
                    //}
                    decimal soTienDaNhap = 0;
                    foreach (ThuLaoNhanVienNgoaiDai tl in _thuLaoChuongTrinhList)
                    {
                        if (cbKyTinhLuong.Value == null || (cbKyTinhLuong.Value != null && Convert.ToInt32(cbKyTinhLuong.Value) == 0))
                        {
                            MessageBox.Show("Chọn ký tính lương.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        KyTinhLuong ktlTrack = KyTinhLuong.GetKyTinhLuong(tl.MaKyTinhLuong);
                        tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                        //if ( tl.NgayLap.Month != ktlTrack.NgayKetThuc.Month && tl.NgayLap.Year != ktlTrack.NgayBatDau.Year)
                        //{
                        //    MessageBox.Show("Ngầy lập Thù Lao phải năm trong kỳ tính lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        //if (_NgayChungTu.Month != ktlTrack.NgayKetThuc.Month && _NgayChungTu.Year != ktlTrack.NgayBatDau.Year)
                        //{
                        //    MessageBox.Show("chứng từ không hợp lệ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        tl.NgayChungTu = _NgayChungTu;
                        tl.TenChuongTrinh = tenChuongTrinh;
                        tl.MaChuongTrinh = maChuongTrinh;
                        tl.MaKyTinhLuong = maKyTinhluong;
                        tl.MaPhieuChi = soChungTu;
                        tl.TenGiayXacNhan = tenGiayXacNhan;
                        tl.MaChiThuLao = maChiThuLao;
                        tl.SoChungTu = soChungTu;
                        tl.ThanhToan = false;
                        tl.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                        tl.MaGiayXacNhan = maGiayXacNhan;
                        tl.DuocNhapHo = nhapHo;
                        soTienDaNhap += tl.SoTien;

                        if (tl.NgayLap < ktl.NgayBatDau || tl.NgayLap > ktl.NgayKetThuc)
                        {
                            MessageBox.Show("Ngày Lập phải năm trong tháng của kỳ lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    if (cbChungTu.Value != null && Convert.ToInt32(cbChungTu.Value) != 0)
                    {
                        if (!_suaDuLieu)
                        {
                            if (Convert.ToDecimal(tbSoTienConLaiPC.Value) < soTienDaNhap)
                            {
                                MessageBox.Show("Không đủ tiền nhập thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                        else
                        {
                            if (soTienDaNhap > _tongTienChoPhepCapNhat || Convert.ToDecimal(tbSoTienConLaiPC.Value) < soTienDaNhap - TinhSoTienDaNhapThuLao(Convert.ToInt32(cbChungTu.Value)))
                            {
                                MessageBox.Show("Không đủ tiền nhập thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    #region KiemTraTienThueHopLeTruocKhiLuu
                    foreach (ThuLaoNhanVienNgoaiDai thuLaoNhanVienNgoaiDai in _thuLaoChuongTrinhList)
                    {
                        if (thuLaoNhanVienNgoaiDai.SoTien >= 2000000 && thuLaoNhanVienNgoaiDai.TienThue <= 0)
                        {
                            MessageBox.Show("Vui lòng nhập tiền thuế cho những CTV chi trên 2 triệu!");
                            return;
                        }
                    }
                    #endregion//KiemTraTienThueHopLeTruocKhiLuu

                    _thuLaoChuongTrinhList.ApplyEdit();
                    bindingSource1_ThuLaoChuongTrinh.EndEdit();
                    _thuLaoChuongTrinhList.Save();
                    if (maChiTietGiayXacNhan != 0)
                    {
                        //  ChiTietGiayXacNhan.UpdateSoTienNhanVienNgoaiDaiGXN(maChiTietGiayXacNhan, databaseNumberGXN, Database.DatabaseNumber, soTienDaNhap);
                    }
                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Cập nhật số tiền còn lại
                    tbSoTienConLaiPC.Value = ChiThuLao.SoTienConLaiPhieuChi(maChiThuLao);

                    //_chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao(ERP_Library.Security.CurrentUser.Info.UserID, maChiThuLao);
                    _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(ERP_Library.Security.CurrentUser.Info.UserID, maChiThuLao, _maLoaiChi);
                    ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
                    _chiThuLaoList.Insert(0, itemChiTL);
                    this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

                    _suaDuLieu = true;
                    _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        private decimal TinhSoTienDaNhapThuLao(int maChiThuLao)
        {
            decimal soTienConLai = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LaySoTienDaNhapThuLaoByMaChiThuLao";
                    cm.Parameters.AddWithValue("@MaChiThuLao", maChiThuLao);
                    cm.Parameters.AddWithValue("@SoTien", soTienConLai);
                    cm.Parameters["@SoTien"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    soTienConLai = Convert.ToDecimal(cm.Parameters["@SoTien"].Value);
                }
            }//using
            return soTienConLai;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComBoChangedValue();
        }


        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {

            for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
            {
                if ((bool)grdu_QuocGia.Rows[i].Cells["Check"].Value == true)
                {
                    grdu_QuocGia.Rows[i].Selected = true;
                }
            }
            grdu_QuocGia.DeleteSelectedRows();
            _nhanVienList = NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList(maBoPhan, loaiNhanVien);
            this.bindingSource1_NhanVien.DataSource = _nhanVienList;
            this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void grdu_QuocGia_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                button2_Click_1(null, null);
                // this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            }

        }

        private void grdu_QuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            // Turn on all of the Cut, Copy, and Paste functionality. 
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            // In order to cut or copy, the user needs to select cells or rows. 
            // So set CellClickAction so that clicking on a cell selects that cell
            // instead of going into edit mode.
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;
            foreach (UltraGridColumn col in this.grdu_QuocGia.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;

            }
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Width = 40;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 120;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Width = 70;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["PhanTramThue"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["PhanTramThue"].Header.Caption = "%Thuế";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["PhanTramThue"].Header.VisiblePosition = 3;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["PhanTramThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["PhanTramThue"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["PhanTramThue"].Width = 50;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TienThue"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TienThue"].Header.Caption = "Tiền Thuế";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TienThue"].Header.VisiblePosition = 4;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TienThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TienThue"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TienThue"].Width = 70;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Tiền Sau Thuế";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 5;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 70;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 6;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 100;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 7;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "MST";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 8;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 9;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;

            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 10;
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaSoThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["MaNhanVienChuyenTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        }

        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid_DSNhanVien.ActiveRow != null)
            {

                if (e.KeyCode == Keys.Space)
                {
                    if (ultraGrid_DSNhanVien.ActiveRow.Cells["Check"].Value.ToString() != "")
                    {
                        if ((bool)ultraGrid_DSNhanVien.ActiveRow.Cells["Check"].Value == true)
                            ultraGrid_DSNhanVien.ActiveRow.Cells["Check"].Value = false;
                        else
                            ultraGrid_DSNhanVien.ActiveRow.Cells["Check"].Value = true;
                    }
                }
            }
        }

        private void grdu_QuocGia_KeyDown(object sender, KeyEventArgs e)
        {
            //if (grdu_QuocGia.ActiveRow != null)
            //{
            //    if (e.KeyCode == Keys.Space)
            //    {
            //        if (grdu_QuocGia.ActiveRow.Cells["Check"].Value.ToString() != "")
            //        {
            //            if ((bool)grdu_QuocGia.ActiveRow.Cells["Check"].Value == true)
            //                grdu_QuocGia.ActiveRow.Cells["Check"].Value = false;
            //            else
            //                grdu_QuocGia.ActiveRow.Cells["Check"].Value = true;
            //        }
            //    }
            //}
        }

        private void ultraGrid1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                btnthem_Click(null, null);
            }
        }

        private void cmbu_ChucVu_Leave(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue != null)
            {
                maChuongTrinh = (int)cmbu_ChuongTrinh.EditValue;
                foreach (ThuLaoNhanVienNgoaiDai tl in _thuLaoChuongTrinhList)
                {
                    tl.MaChuongTrinh = maChuongTrinh;
                }
            }
        }


        private void tlslblIn_Click(object sender, EventArgs e)
        {
            frmBaoCaoThuLaoNgoaiDai f = new frmBaoCaoThuLaoNgoaiDai();
            f.Show();
        }

        private void dateTimePicker_NgayLap_Leave(object sender, EventArgs e)
        {

            foreach (ThuLaoNhanVienNgoaiDai tl in _thuLaoChuongTrinhList)
            {
                tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            }
        }

        private void grdu_QuocGia_AfterCellUpdate(object sender, CellEventArgs e)
        {

            if (e.Cell.Row.IsDataRow)
            {
                string colCurrent = e.Cell.Column.Key;
                if (colCurrent == "SoTien")
                {
                    decimal sotienOut;
                    if (decimal.TryParse(e.Cell.Row.Cells["SoTien"].Value.ToString(), out sotienOut))
                    {
                        if (sotienOut >= 2000000)
                        {
                            e.Cell.Row.Cells["PhanTramThue"].Value = 10;
                        }
                    }
                }
                decimal sotien = Convert.ToDecimal(e.Cell.Row.Cells["SoTien"].Value);
                decimal ts = Convert.ToDecimal(e.Cell.Row.Cells["PhanTramThue"].Value);
                string tenNV = Convert.ToString(e.Cell.Row.Cells["TenNhanVien"].Value);

                if (colCurrent == "PhanTramThue" || colCurrent == "SoTien")
                {
                    e.Cell.Row.Cells["TienThue"].Value = Math.Round(sotien * ts / 100, 0);
                    e.Cell.Row.Cells["SoTienConLai"].Value = sotien - Math.Round(sotien * ts / 100, 0);
                }
                if (colCurrent == "PhanTramThue" && (ts == 1 || ts == 2 || ts == 0))
                    return;

                if (colCurrent == "PhanTramThue" && ts != 10 && ts != 20)
                {
                    MessageBox.Show("Phần trăm thuế của [" + tenNV.Trim() + "] không hợp lệ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cell.Row.Cells["PhanTramThue"].Value = 0;
                }
            }
        }


        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_QuocGia.ActiveCell != null && !grdu_QuocGia.ActiveCell.IsInEditMode && grdu_QuocGia.ActiveCell.Column.Key != "TenNhanVien")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    grdu_QuocGia.ActiveCell.SelectAll();
                    iskeyok = true;
                }
                if (e.KeyCode == Keys.Space && grdu_QuocGia.ActiveCell.Column.DataType == typeof(bool))
                {
                    grdu_QuocGia.ActiveCell.Value = !Convert.ToBoolean(grdu_QuocGia.ActiveCell.Value);
                }
            }
        }

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok && grdu_QuocGia.ActiveCell.Row.IsDataRow)
            {
                if (grdu_QuocGia.ActiveCell.Column.DataType == typeof(decimal))
                    try
                    {
                        grdu_QuocGia.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                    }
                    catch
                    { }
                else
                    grdu_QuocGia.ActiveCell.Value = e.KeyChar.ToString();
                grdu_QuocGia.ActiveCell.SelStart = grdu_QuocGia.ActiveCell.Text.Length;
                e.Handled = true;
                iskeyok = false;
            }
        }
        //xử lý copy 1 cell cho nhiều cell
        private bool iscopyok = false;
        private object copyvalue;
        private void grdData_BeforeMultiCellOperation(object sender, Infragistics.Win.UltraWinGrid.BeforeMultiCellOperationEventArgs e)
        {
            if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Copy)
            {
                if (e.Cells.RowCount == 1 && e.Cells.ColumnCount == 1)
                {
                    iscopyok = true;
                    copyvalue = e.Cells[0, 0].Value;
                }
            }
            else
                if (e.Operation == Infragistics.Win.UltraWinGrid.MultiCellOperation.Paste)
                {
                    if (iscopyok && grdu_QuocGia.Selected != null && grdu_QuocGia.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_QuocGia.Selected.Cells)
                        {
                            try
                            {
                                item.Value = copyvalue;
                                item.Row.Update();
                            }
                            catch { }
                        }
                    }
                    iscopyok = false;
                }
        }

        private void cbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.Value;

            }
        }

        private void cbKyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbKyTinhLuong, "TenKy");
            foreach (UltraGridColumn col in this.cbKyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = cbKyTinhLuong.Width;
        }


        private void tlslblThem_Click(object sender, EventArgs e)
        {
            cbChungTu.Value = 0;
            _maChiThuLao_Update = 0;
            cmbu_ChuongTrinh.EditValue = null;
            _suaDuLieu = false;
            _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;


            //_chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update);
            #region BoSung Lap ThuLao tu PhieuChi
            if (_maPhieuChi != 0)
            {
                _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi_MaPhieuChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update, _maLoaiChi, _maPhieuChi);
            }
            else
            #endregion//BoSung Lap ThuLao tu PhieuChi
            _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update, _maLoaiChi);
            ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
            _chiThuLaoList.Insert(0, itemChiTL);
            this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;
        }


        private void cbChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbChungTu.ActiveRow != null)
            {
                maChiThuLao = Convert.ToInt64(cbChungTu.ActiveRow.Cells["MaChiThuLao"].Value);
            }

            if (maChiThuLao != 0)
            {

                if (cbChungTu.ActiveRow != null)
                {
                    maChuongTrinh = (int)cbChungTu.ActiveRow.Cells["MaChuongTrinh"].Value;

                    tenChuongTrinh = (string)cbChungTu.ActiveRow.Cells["TenChuongTrinh"].Value;
                    _tienTuPhieuChi = (decimal)cbChungTu.ActiveRow.Cells["SoTien"].Value;
                    _hoanTat = (bool)cbChungTu.ActiveRow.Cells["HoanTat"].Value;
                    _NgayChungTu = (DateTime)cbChungTu.ActiveRow.Cells["NgayLap"].Value;
                    soChungTu = (string)cbChungTu.ActiveRow.Cells["SoChungTu"].Value;
                    ghiChuPhieuChi = (string)cbChungTu.ActiveRow.Cells["GhiChu"].Value;
                    ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                    tenChuongTrinh = ct.TenChuongTrinh;
                    maNguon = ct.MaNguon;
                    tenNguon = ct.TenNguon;
                    tbSoTienPhieuChi.Value = _tienTuPhieuChi;
                    tbSoTienConLaiPC.Value = ChiThuLao.SoTienConLaiPhieuChi(maChiThuLao);
                    cmbu_ChuongTrinh.EditValue = maChuongTrinh;
                    cmbu_ChuongTrinh.Enabled = false;
                }
            }
            else
            {
                soChungTu = string.Empty;
                _NgayChungTu = DateTime.MinValue;
                tbSoTienPhieuChi.Value = 0;
                tbSoTienConLaiPC.Value = 0;
                cmbu_ChuongTrinh.EditValue = 0;
            }

            _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
        }

        private void cbChungTu_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbChungTu, "SoChungTu");
            foreach (UltraGridColumn col in this.cbChungTu.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Phiếu Chi";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 120;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 0;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.Caption = "Tên Bộ Phận Nhận";
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Width = 150;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanNhan"].Header.VisiblePosition = 1;

            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.Caption = "Tên Bộ Phận Gửi";
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Width = 150;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenBoPhanGui"].Header.VisiblePosition = 2;

            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 200;
            cbChungTu.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 3;

            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 4;
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            cbChungTu.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;

            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 60;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 5;
            cbChungTu.DisplayLayout.Bands[0].Columns["NgayLap"].Format = "dd/MM/yyyy";

            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Width = 60;
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 6;
        }

        private void cmbu_Bophan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_Bophan, "TenBoPhan");
            foreach (UltraGridColumn col in this.cmbu_Bophan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = cmbu_Bophan.Width;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Hidden = false;
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.Caption = "Mã Bộ Phận";
            cmbu_Bophan.DisplayLayout.Bands[0].Columns["MaBoPhanQL"].Header.VisiblePosition = 1;
        }

        private void tlslblTroGiup_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_QuocGia);
        }

        private void cmbu_ChuongTrinh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue != null)
            {
                maChuongTrinh = (int)cmbu_ChuongTrinh.EditValue;
                ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                tenChuongTrinh = ct.TenChuongTrinh;
                foreach (ThuLaoNhanVienNgoaiDai tl in _thuLaoChuongTrinhList)
                {
                    tl.MaChuongTrinh = maChuongTrinh;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                frmExportThuLapImport frm = new frmExportThuLapImport(1);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslbl_ImportMau_Click(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh == null || (cmbu_ChuongTrinh != null && Convert.ToInt32(cmbu_ChuongTrinh.EditValue) == 0))
            {
                MessageBox.Show("Vui lòng chọn chương trình", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Excel files (*.xls)|*.xls|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string cnnExcel = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dlg.FileName + ";Extended Properties='Excel 8.0;HDR=NO'";
                    OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [CongTacVienExport$A7:H] ", cnnExcel);
                    DataTable tblExcel = new DataTable("Import");
                    daExcel.Fill(tblExcel);

                    daExcel.UpdateCommand = new OleDbCommand("Update [CongTacVienExport$A7:L] Set F8=? Where F3=?", daExcel.SelectCommand.Connection);
                    daExcel.UpdateCommand.Parameters.Add("p1", OleDbType.WChar, 8, "F8");
                    daExcel.UpdateCommand.Parameters.Add("p3", OleDbType.WChar, 20, "F3");

                    //thêm dữ liệu vào object và save lại
                    ThuLaoNhanVienNgoaiDai objNew;
                    bool ok;
                    _thuLaoChuongTrinhList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
                    bool duThongTinImport = true;
                    bool duLieuLoi = false;

                    foreach (DataRow row in tblExcel.Rows)
                    {
                        ok = true;
                        duThongTinImport = true;
                        duLieuLoi = false;

                        if (string.IsNullOrEmpty(row["F3"].ToString()) && duLieuLoi == false)
                        {
                            DialogUtil.ShowWarning("Nhân viên [" + row["F1"] + "] chưa có chứng minh. Chương trình sẽ loại bỏ nhân viên này.");
                            duLieuLoi = true;
                        }
                        if (duLieuLoi == false && (string.IsNullOrEmpty(row["F2"].ToString()) || (!string.IsNullOrEmpty(row["F2"].ToString()) && Convert.ToDecimal(row["F2"]) == 0)))
                        {
                            DialogUtil.ShowWarning("Nhân viên [" + row["F1"] + "] số tiền phải lớn hơn không. Chương trình sẽ loại bỏ nhân viên này.");
                            duLieuLoi = true;
                        }
                        if (row.IsNull("F3") || (string.IsNullOrEmpty(row["F2"].ToString()) || (!string.IsNullOrEmpty(row["F2"].ToString()) && Convert.ToDecimal(row["F2"]) == 0))) continue;
                        {
                            if (ok)
                            {
                                objNew = ERP_Library.ThuLaoNhanVienNgoaiDai.NewThuLaoNhanVienNgoaiDai();

                                objNew.ThanhToan = true;
                                objNew.MaChuongTrinh = maChuongTrinh;
                                objNew.MaKyTinhLuong = maKyTinhluong;
                                objNew.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                                objNew.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);

                                objNew.DienGiai = ghiChuPhieuChi;
                                objNew.TenChuongTrinh = tenChuongTrinh;
                                objNew.SoChungTu = soChungTu;
                                objNew.MaChiThuLao = maChiThuLao;
                                objNew.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                                objNew.MaGiayXacNhan = maGiayXacNhan;

                                if (NhanVienNgoaiDai.KiemTraCMND(row["F3"].ToString()))//Kiểm tra chứng minh nhân dân
                                {
                                    NhanVienNgoaiDai nv = NhanVienNgoaiDai.GetNhanVienNgoaiDaiByCMND(row["F3"].ToString());
                                    BoPhan bp = BoPhan.GetBoPhan(nv.MaBoPhan);
                                    objNew.MaQLBoPhan = bp.MaBoPhanQL;
                                    objNew.MaBoPhan = nv.MaBoPhan;
                                    objNew.TenBoPhan = nv.TenBoPhan;
                                    objNew.MaNhanVien = nv.MaNhanVien;
                                    objNew.TenNhanVien = nv.TenNhanVien;
                                    objNew.Cmnd = nv.Cmnd;

                                    if (!string.IsNullOrEmpty((row["F4"].ToString())))
                                    {
                                        objNew.MaSoThue = row["F4"].ToString();
                                    }
                                    if (!string.IsNullOrEmpty((row["F2"].ToString())))
                                    {
                                        objNew.SoTien = Convert.ToDecimal(row["F2"]);
                                    }
                                    if (!string.IsNullOrEmpty((row["F5"].ToString())))
                                    {
                                        objNew.DienThoai = row["F5"].ToString();
                                    }
                                    if (!string.IsNullOrEmpty((row["F6"].ToString())))
                                    {
                                        objNew.DienGiai = row["F6"].ToString();
                                    }
                                    if (!string.IsNullOrEmpty((row["F7"].ToString())))
                                    {
                                        objNew.DiaChi = row["F7"].ToString();
                                    }
                                    objNew.MaNhanVienChuyenTien = objNew.MaNhanVien;
                                }
                                else
                                {
                                    DialogUtil.ShowWarning("Số chứng minh của [" + row["F1"] + "] không đúng. Chương trình sẽ loại bỏ dòng này.");
                                }

                                if (objNew.MaNhanVien != 0 && duThongTinImport == true)
                                {
                                    _thuLaoChuongTrinhList.Add(objNew);
                                    row["F8"] = "OK";
                                }

                            }
                        }
                    }

                    daExcel.Update(tblExcel);
                    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void tlslbl_ExportMau_Click(object sender, EventArgs e)
        {
            try
            {
                frmExportThuLapImport frm = new frmExportThuLapImport(1);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ultraGrid_DSNhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;

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
                    //col.MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn.nn";
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["Check"].Width = 40;

            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 130;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;

            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 3;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;

            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Hidden = false;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.Caption = "Số Tài Khoản";
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Header.VisiblePosition = 4;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["SoTaiKhoan"].Width = 100;

            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Hidden = false;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.Caption = "Tên Ngân Hàng";
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Header.VisiblePosition = 5;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["TenNganHang"].Width = 120;

            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["Mst"].Hidden = false;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["Mst"].Header.Caption = "Mã Số Thuế";
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["Mst"].Header.VisiblePosition = 6;
            ultraGrid_DSNhanVien.DisplayLayout.Bands[0].Columns["Mst"].Width = 100;
        }
    }
}
