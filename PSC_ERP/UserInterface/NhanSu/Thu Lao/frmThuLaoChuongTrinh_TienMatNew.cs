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
using System.Data.SqlClient;
using System.Data.OleDb;
namespace PSC_ERP
{//1/123
    public partial class frmThuLaoChuongTrinh_TienMatNew : Form
    {

        //ChiThuLaoList _chiThuLaoList;
        ChiThuLaoTongHopList _chiThuLaoList;
        BoPhanList _boPhanList;
        ChuongTrinhList _chuongTrinhList;
        KyTinhLuongList _kyTinhLuongList;
        ERP_Library.ThongTinNhanVienTongHopList _nhanVienList;
        ChiThuLao _chiThuLao_NhanVienList = ChiThuLao.NewChiThuLao();
        ThuLaoChuongTrinhList _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
        GiayXacNhanChuongTrinhList _giayXacNhanChuongTrinhList = GiayXacNhanChuongTrinhList.NewGiayXacNhanChuongTrinhList();
        ChiTietGiayXacNhanTongHopList _chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.NewChiTietGiayXacNhanTongHopList();
        ChiTietGiayXacNhanTongHop chiTietGXN = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop();
        //ChiTietGiayXacNhan chiTietGXN = ChiTietGiayXacNhan.NewChiTietGiayXacNhan();
        //ChiTietGiayXacNhanList _chiTietGiayXacNhanList = ChiTietGiayXacNhanList.NewChiTietGiayXacNhanList();
        decimal _tienChiTietGiayXacNhan = 0;
        decimal _tienTuPhieuChi = 0;
        string _tenPhieuChi = string.Empty;
        int maBoPhanDen = 0;

        static int maBoPhan = 0;
        static int maKyTinhluong = 0;
        static int maChuongTrinh = 0;
        bool nhapHo = false;

        string tenChuongTrinh = string.Empty;
        long maChiThuLao = 0;
        string soChungTu = string.Empty;
        string tenChungTu = string.Empty;
        string tenGiayXacNhan = string.Empty;
        string ghiChuPhieuChi = string.Empty;
        int maChiTietGiayXacNhan = 0;
        int maGiayXacNhan = 0;
        bool _hoanTat = false;
        string tenNguon = string.Empty;
        int maNguon = 0;
        long _maChiThuLao_Update = 0;
        decimal _tongTienChoPhepCapNhat = 0;
        Boolean _suaDuLieu = false;

        const int _maLoaiChi = 1;//Chi Thu Lao
        private void LoadControls()
        {
            _boPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _boPhanList.Insert(0, itemBoPhan);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            //chuong trinh
            _chuongTrinhList = ChuongTrinhList.GetChuongTrinhList(false);
            this.bindingSource1_ChuongTrinh.DataSource = _chuongTrinhList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;

            ///------Chay cham--------////
            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanList.GetChiTietGiayXacNhanListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhan itemAdd = ChiTietGiayXacNhan.NewChiTietGiayXacNhan(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;]

            ///------Chay nhanh--------////
            //_chiTietGiayXacNhanList = ChiTietGiayXacNhanTongHopList.GetChiTietGiayXacNhanTongHopListByUserID(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiTietGiayXacNhanTongHop itemAdd = ChiTietGiayXacNhanTongHop.NewChiTietGiayXacNhanTongHop(0, "Không Có Giấy Xác Nhận");
            //_chiTietGiayXacNhanList.Insert(0, itemAdd);
            //this.bindingSource1_ChiTietGiayXacNhan.DataSource = _chiTietGiayXacNhanList;

            _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            bindingSource1_NhanVien.DataSource = _nhanVienList;
            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;

            //_chiThuLaoList = ChiThuLaoList.GetChiThuLaoListByUser(ERP_Library.Security.CurrentUser.Info.UserID);
            //ChiThuLao itemChiTL = ChiThuLao.NewChiThuLao("Không Có Chứng Từ");
            //_chiThuLaoList.Insert(0, itemChiTL);
            //this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

            //_chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update);
            _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update,_maLoaiChi);
            ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
            _chiThuLaoList.Insert(0, itemChiTL);
            this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

            dateTimePicker_NgayLap.Value = DateTime.Today;
        }
        public frmThuLaoChuongTrinh_TienMatNew()
        {
            InitializeComponent();

            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            this.bindingSource1_ChuongTrinh.DataSource = typeof(ChuongTrinhList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            this.bindingSource1_ChiTietGiayXacNhan.DataSource = typeof(ChiTietGiayXacNhanList);
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = typeof(ThuLaoChuongTrinhList);
            this.bindingSource1_ChungTu.DataSource = typeof(ChiThuLaoList);
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);
            LoadControls();
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            dateTimePicker_NgayLap.Value = DateTime.Today;
            if (ERP_Library.Security.CurrentUser.IsAdmin)
            {
                checkBox_NghiHuu.Visible = true;
            }
            else
            {
                checkBox_NghiHuu.Visible = false;
            }

        }

        public frmThuLaoChuongTrinh_TienMatNew(int _maKyTinhLuong, int _maChuongTrinh, string maPhieuChi, DateTime ngayLap, bool tinhDangPhi, long maChiThuLao,int maChiTietGiayXacNhan)
        {
            InitializeComponent();
            KhoiTao(_maKyTinhLuong, _maChuongTrinh, maPhieuChi, ngayLap, tinhDangPhi, maChiThuLao,maChiTietGiayXacNhan);
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_QuocGia.AfterCellUpdate += new CellEventHandler(grdu_QuocGia_AfterCellUpdate);
            grdu_QuocGia.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_QuocGia.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_QuocGia.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            dateTimePicker_NgayLap.Value = DateTime.Today;
            _suaDuLieu = true;
            KhoaConTrol(true);//Khoa ConTrol
        }
        private void frmThuLaoChuongTrinh_Load(object sender, EventArgs e)
        {
            grdu_QuocGia.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, Infragistics.Win.UltraWinGrid.UltraGridState.AddRow, 0, 0, 0));
            //LoadControls();
            cmbu_ChuongTrinh.Enabled = false;
        }

        public void KhoiTao(int _maKyTinhLuong, int _maChuongTrinh, string maPhieuChi, DateTime ngayLap, bool tinhDangPhi, long _maChiThuLao, int _maChiTietGiayXacNhan)
        {
            _maChiThuLao_Update = _maChiThuLao;
            LoadControls();
            cbKyTinhLuong.Value = _maKyTinhLuong;
            cmbu_ChuongTrinh.EditValue = _maChuongTrinh;
            cbChungTu.Value = _maChiThuLao;
            maChuongTrinh = _maChuongTrinh;
            maChiTietGiayXacNhan = _maChiTietGiayXacNhan;        
            maChiThuLao = _maChiThuLao;
            cbChungTu.Value = _maChiThuLao;
            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(0, maChuongTrinh, maKyTinhluong, maPhieuChi, tinhDangPhi, _maChiThuLao, maChiTietGiayXacNhan, ngayLap);
            maKyTinhluong = _maKyTinhLuong;
            if (_thuLaoChuongTrinhList.Count != 0)
            {

                dateTimePicker_NgayLap.Value = _thuLaoChuongTrinhList[0].NgayLap;
                chbTinhDangPhi.Checked = _thuLaoChuongTrinhList[0].TinhDangPhi;
            }

            bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
            this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

            _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
        }
        private decimal TongSoTienToiDaChoPhepCapNhat()
        {
            decimal soTienDaNhapThuLao = 0;
            decimal soTienChoPhepCapNhat = 0;
            foreach (ThuLaoChuongTrinh item in _thuLaoChuongTrinhList)
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

                if (cmbu_Bophan.ActiveRow!= null)
                {
                    maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
                }
                //_nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, checkBox_NghiHuu.Checked);
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByDatabase(maBoPhan, checkBox_NghiHuu.Checked);
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
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    if (!ultraGrid1.Rows[i].Hidden == true && ultraGrid1.Rows[i].IsFilteredOut == false)
                    {
                        ultraGrid1.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                {
                    ultraGrid1.Rows[i].Cells["Check"].Value = (object)false;
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
                KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(maKyTinhluong);
                //if ((DateTime)dateTimePicker_NgayLap.Value >= ktl.NgayKhoaThuLao)
                //{
                //    MessageBox.Show("Ngày Lập lớn hơn Ngày Khóa Thù Lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}
                if (ktl.KhoaSoKy2 == true || ktl.KhoaSo == true)
                {
                    MessageBox.Show("Tháng lương Đã Khóa Sổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult _DialogResult = MessageBox.Show("Bạn Có Đồng Ý Đứa Nhân Viên Qua", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true)
                        {
                            ThuLaoChuongTrinh thuLao = ThuLaoChuongTrinh.NewThuLaoChuongTrinh();
                            thuLao.ThanhToan = false;
                            thuLao.MaChuongTrinh = maChuongTrinh;
                            thuLao.MaKyTinhLuong = maKyTinhluong;
                            thuLao.MaNhanVien = (long)ultraGrid1.Rows[i].Cells["MaNhanVien"].Value;
                            thuLao.TenNhanVien = (string)ultraGrid1.Rows[i].Cells["TenNhanVien"].Value;
                            thuLao.TinhDangPhi = chbTinhDangPhi.Checked;
                            thuLao.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                            thuLao.NguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;

                            thuLao.SoTien = Convert.ToDecimal(ultraGrid1.Rows[i].Cells["SoTien"].Value);
                            thuLao.MaQLNhanVien = (string)ultraGrid1.Rows[i].Cells["MaQLNhanVien"].Value;
                            thuLao.MaQLBoPhan = (string)ultraGrid1.Rows[i].Cells["MaQLBoPhan"].Value;
                            thuLao.MaBoPhan = (int)ultraGrid1.Rows[i].Cells["MaBoPhan"].Value;
                            thuLao.MaChucVu = (int)ultraGrid1.Rows[i].Cells["MaChucVu"].Value;
                            thuLao.TenBoPhan = (string)ultraGrid1.Rows[i].Cells["TenBoPhan"].Value;
                            thuLao.TenChucVu = (string)ultraGrid1.Rows[i].Cells["TenChucVu"].Value;
                            thuLao.DienGiai = ghiChuPhieuChi;
                            thuLao.TenChuongTrinh = tenChuongTrinh;
                            thuLao.SoChungTu = soChungTu;
                            thuLao.MaChiThuLao = maChiThuLao;
                            thuLao.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                            thuLao.MaGiayXacNhan = maGiayXacNhan;
                            thuLao.MaPhieuChi = soChungTu;
                            thuLao.MaNguonChuongTrinh = maNguon;
                            thuLao.TenNguonChuongTrinh = tenNguon;
                            thuLao.ThucNhan = cbDinhMuc.Checked;

                            _thuLaoChuongTrinhList.Add(thuLao);

                        }
                    }
                    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
                    this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();

                    for (int i = 0; i < ultraGrid1.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid1.Rows[i].Cells["Check"].Value == true)
                        {
                            ultraGrid1.Rows[i].Cells["Check"].Value = false;
                            ultraGrid1.Rows[i].Hidden = true;
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
            //decimal _soTienTemp = 0;
            //if (txt_MaPhieuChi.Text != "")
            //{
            //    _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.GetThuLaoChuongTrinhList(maBoPhan, maChuongTrinh, maKyTinhluong, txt_MaPhieuChi.Text);
            //    this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;
            //}
            lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
            //for (int i = 0; i < _thuLaoChuongTrinhList.Count; i++)
            //{
            //    _soTienTemp += _thuLaoChuongTrinhList[i].SoTien;
            //}
            //SoTien = _soTienTemp;
            //if (_soTienTemp != 0)
            //{
            //    tbSoTien.Text = SoTien.ToString();
            //}
        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            try
            {
                if (cbChungTu.Value == null || (cbChungTu.Value !=null && Convert.ToInt32(cbChungTu.Value)  == 0))
                {
                    MessageBox.Show("Vui lòng chọn chứng từ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KyTinhLuong ktl = KyTinhLuong.GetKyTinhLuong(maKyTinhluong);
                if (_hoanTat == true && maChiThuLao != 0)
                {
                    MessageBox.Show("Chứng Từ Đã Đánh Dấu Hoàn Tất", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (ktl.KhoaSoKy2 == true || ktl.KhoaSo == true)
                {
                    MessageBox.Show("Tháng lương Đã Khóa Sổ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (maKyTinhluong==0)
                {
                    MessageBox.Show("Vui Lòng Chọn Kỳ Tính Lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbKyTinhLuong.Focus();
                    return;
                }
                else
                {
                    if (maChiTietGiayXacNhan != 0 && maChiThuLao != 0)
                    {
                        if (GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(maGiayXacNhan).MaChuongTrinh != ChiThuLao.GetChiThuLao(maChiThuLao).MaChuongTrinh)
                        {
                            MessageBox.Show("Chương trình từ Giấy Xác Nhận và Phiếu Chi không giống nhau", "ThôngBáo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    decimal soTienDaNhap = 0;
                    foreach (ThuLaoChuongTrinh tl in _thuLaoChuongTrinhList)
                    {
                        KyTinhLuong ktlTrack = KyTinhLuong.GetKyTinhLuong(tl.MaKyTinhLuong);
                        if (ktlTrack.KhoaSoKy2 == true)
                        {
                            MessageBox.Show("Kỳ Trước Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        //if ((DateTime)dateTimePicker_NgayLap.Value >= ktlTrack.NgayKhoaThuLao)
                        //{
                        //    MessageBox.Show("Ngày Lập lớn hơn Ngày Khóa Thù Lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}
                        tl.NgayLap =Convert.ToDateTime( dateTimePicker_NgayLap.Value);
                        tl.TenChuongTrinh = tenChuongTrinh;
                        tl.MaChuongTrinh = maChuongTrinh;
                        tl.MaKyTinhLuong = maKyTinhluong;

                        tl.MaChiThuLao = maChiThuLao;
                        tl.SoChungTu = soChungTu;

                        tl.SoChungTu = soChungTu;
                        tl.MaChiThuLao = maChiThuLao;
                        tl.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
                        tl.MaGiayXacNhan = maGiayXacNhan;
                        tl.TenGiayXacNhan = tenGiayXacNhan;
                        tl.MaPhieuChi = soChungTu;
                        tl.MaNguonChuongTrinh = maNguon;
                        tl.TenNguonChuongTrinh = tenNguon;
                        soTienDaNhap += tl.SoTien;
                        tl.DuocNhapHo = nhapHo;

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

                    _thuLaoChuongTrinhList.ApplyEdit();
                    bindingSource1_ThuLaoChuongTrinh.EndEdit();
                    _thuLaoChuongTrinhList.Save();
                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //Cập nhật số tiền còn lại
                    tbSoTienConLaiPC.Value = ChiThuLao.SoTienConLaiPhieuChi(maChiThuLao);
                    if (_thuLaoChuongTrinhList.Count > 0)
                    {
                        KhoaConTrol(true);//Khoa Control
                    }
                    //
                   //_chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao(ERP_Library.Security.CurrentUser.Info.UserID, maChiThuLao);
                   _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(ERP_Library.Security.CurrentUser.Info.UserID, maChiThuLao,_maLoaiChi);
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
        void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        #region BoSung
        private void KhoaConTrol(bool khoa)
        {
            cbChungTu.ReadOnly = khoa;
            //txt_ChuongTrinh.ReadOnly = khoa;
            cbKyTinhLuong.ReadOnly = khoa;
        }
        #endregion//BoSung

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            ComBoChangedValue();
        }


        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblTim_Click(object sender, EventArgs e)
        {
            // KhoiTao(maKyTinhluong,maChuongTrinh,maGiayXacNhan);           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (KyTinhLuong.GetKyTinhLuong(maKyTinhluong).KhoaSoKy2 != true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if ((bool)grdu_QuocGia.Rows[i].Cells["Check"].Value == true)
                    {
                        grdu_QuocGia.Rows[i].Selected = true;
                    }
                }
                grdu_QuocGia.DeleteSelectedRows();
                //_thuLaoChuongTrinhList.ApplyEdit();
                // _thuLaoChuongTrinhList.Save();
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByDatabase(maBoPhan, checkBox_NghiHuu.Checked);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                this.lbSoLuong.Text = _thuLaoChuongTrinhList.Count.ToString();
            }
            else
            {
                MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //ComBoChangedValue();
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
            //else if (e.KeyCode == (Keys.C && Keys.Control))
            //{
            //    this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            //}
            //if (e.KeyCode == (Keys.V && Keys.Control))
            //{
            //    this.grdu_QuocGia.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);
            //}
        }

        private void grdu_QuocGia_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            // Turn on all of the Cut, Copy, and Paste functionality. 
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
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
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["Check"].Width = 60;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoTien"].Width = 80;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 4;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 120;

            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Hidden = false;
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.Caption = "Số Chứng Từ";
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Header.VisiblePosition = 5;
            //grdu_QuocGia.DisplayLayout.Bands[0].Columns["SoChungTu"].Width = 100;

            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Hidden = false;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.Caption = "Ngoài Định Mức";
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Header.VisiblePosition = 6;
            grdu_QuocGia.DisplayLayout.Bands[0].Columns["ThucNhan"].Width = 80;

        }

        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid1.ActiveRow != null)
            {

                if (e.KeyCode == Keys.Space)
                {
                    if (ultraGrid1.ActiveRow.Cells["Check"].Value.ToString() != "")
                    {
                        if ((bool)ultraGrid1.ActiveRow.Cells["Check"].Value == true)
                            ultraGrid1.ActiveRow.Cells["Check"].Value = false;
                        else
                            ultraGrid1.ActiveRow.Cells["Check"].Value = true;
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


        private void tlslblIn_Click(object sender, EventArgs e)
        {
            frmBaoCaoThuLaoChiTiet f = new frmBaoCaoThuLaoChiTiet();
            f.Show();
        }

        private void dateTimePicker_NgayLap_Leave(object sender, EventArgs e)
        {

            foreach (ThuLaoChuongTrinh tl in _thuLaoChuongTrinhList)
            {
                tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            }
        }

        private void grdu_QuocGia_AfterCellUpdate(object sender, CellEventArgs e)
        {

            //if (e.Cell.Row.IsDataRow)
            //{
            //    string t = e.Cell.Column.Key;
            //    if (t == "PhanTramThue" || t == "SoTien")
            //    {
            //        decimal sotien = Convert.ToDecimal(e.Cell.Row.Cells["SoTien"].Value);
            //        decimal ts = Convert.ToDecimal(e.Cell.Row.Cells["PhanTramThue"].Value);
            //        e.Cell.Row.Cells["TienThue"].Value = Math.Round(sotien * ts / 100, 0);
            //        e.Cell.Row.Cells["SoTienConLai"].Value = sotien - Math.Round(sotien * ts / 100, 0);
            //    }
            //}
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
            if (cbKyTinhLuong.ActiveRow!= null)
            {
                maKyTinhluong = (int)cbKyTinhLuong.ActiveRow.Cells["MaKy"].Value;

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

        private void chbTinhDangPhi_CheckedChanged(object sender, EventArgs e)
        {
            if (chbTinhDangPhi.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["TinhDangPhi"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["TinhDangPhi"].Value = (object)false;
                }
            }
        }


        private void tlslblThem_Click(object sender, EventArgs e)
        {
            cbChungTu.Value = 0;
            _maChiThuLao_Update = 0;
            cmbu_ChuongTrinh.EditValue = null;
            _suaDuLieu = false;

            _thuLaoChuongTrinhList = ThuLaoChuongTrinhList.NewThuLaoChuongTrinhList();
            this.bindingSource1_ThuLaoChuongTrinh.DataSource = _thuLaoChuongTrinhList;

            //_chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update);
            _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao_Update,_maLoaiChi);
            ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
            _chiThuLaoList.Insert(0, itemChiTL);
            this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;
            KhoaConTrol(false);//Mo Khoa Control
        }

        private void cbDinhMuc_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDinhMuc.Checked == true)
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    if (!grdu_QuocGia.Rows[i].Hidden == true)
                    {
                        grdu_QuocGia.Rows[i].Cells["ThucNhan"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_QuocGia.Rows.Count; i++)
                {
                    grdu_QuocGia.Rows[i].Cells["ThucNhan"].Value = (object)false;
                }
            }
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

            cbChungTu.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";
            cbChungTu.DisplayLayout.Bands[0].Columns["GhiChu"].Width = 80;
            cbChungTu.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 6;

            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Hidden = false;
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Width = 60;
            cbChungTu.DisplayLayout.Bands[0].Columns["HoanTat"].Header.VisiblePosition = 7;

        }

        private void cbChiTietGiayXacNhan_ValueChanged(object sender, EventArgs e)
        {
            //maChiTietGiayXacNhan = 0;
            //if (maChiTietGiayXacNhan == 0)
            //{
            //    maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.Value);
            //}
            ////if (cbChiTietGiayXacNhan.Value != null &&maChiTietGiayXacNhan != 0)
            //if (maChiTietGiayXacNhan != 0)
            //{
            //    _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            //    _boPhanList = BoPhanList.GetBoPhanListAll();
            //    this.bindingSource1_BoPhan.DataSource = _boPhanList;
            //    _tienChiTietGiayXacNhan = 0;
            //    if (cbChiTietGiayXacNhan.ActiveRow != null)
            //    {
            //        maGiayXacNhan = (int)cbChiTietGiayXacNhan.ActiveRow.Cells["MaGiayXacNhan"].Value;
            //        maChiTietGiayXacNhan = Convert.ToInt32(cbChiTietGiayXacNhan.Value);
            //        databaseNumberGXN = (int)cbChiTietGiayXacNhan.ActiveRow.Cells["DatabaseNumber"].Value;
            //        maBoPhanDen = (int)cbChiTietGiayXacNhan.ActiveRow.Cells["MaBoPhanDen"].Value;
            //        tenGiayXacNhan = (string)cbChiTietGiayXacNhan.ActiveRow.Cells["TenGiayXacNhan"].Value;
            //        _hoanTat = (bool)cbChiTietGiayXacNhan.ActiveRow.Cells["HoanTat"].Value;
            //        _tienChiTietGiayXacNhan = (decimal)cbChiTietGiayXacNhan.ActiveRow.Cells["SoTien"].Value;
            //        nhapHo = (bool)cbChiTietGiayXacNhan.ActiveRow.Cells["DuocNhapHo"].Value;
            //    }
            //    cmbu_ChuongTrinh.Enabled = false;
            //    GiayXacNhanChuongTrinh gxn = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(maGiayXacNhan, databaseNumberGXN);


            //    maChuongTrinh = gxn.MaChuongTrinh;
            //    tenChuongTrinh = gxn.TenChuongTrinh;
            //    ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh,databaseNumberGXN);
            //    maNguon = ct.MaNguon;
            //    tenNguon = ct.TenNguon;
            //    TbTongTien.Value = _tienChiTietGiayXacNhan;
            //    cmbu_ChuongTrinh.Text = tenChuongTrinh;


            //    chiTietGXN = ChiTietGiayXacNhan.GetChiTietGiayXacNhan(maChiTietGiayXacNhan, databaseNumberGXN);
            //}
            //else
            //{
            //    _tienChiTietGiayXacNhan = 0;
            //    TbTongTien.Value = 0;
            //    tenGiayXacNhan = string.Empty;
            //    maGiayXacNhan = 0;
            //    maChiTietGiayXacNhan = 0;
            //    nhapHo = false;
            //    cmbu_ChuongTrinh.Value = maChuongTrinh;
            //    cmbu_ChuongTrinh.Enabled = true;
            //}
        }

        private void cbChungTu_KeyDown(object sender, KeyEventArgs e)
        {
            FilterCombo _filter = new FilterCombo(cbChungTu, "SoChungTu");
        }

        private void ultraGrid1_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.ultraGrid1.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Hidden = false;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Quản Lý";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Chứng Minh";
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.Caption = "Chức Vụ";
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 2;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 3;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 4;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.VisiblePosition = 5;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 6;

            ultraGrid1.DisplayLayout.Bands[0].Columns["Check"].Width = 40;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucvu"].Width = 100;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;

            ultraGrid1.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["CMND"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["TenChucVu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid1.DisplayLayout.Bands[0].Columns["MaSoThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        }

        private void cbChiTietGiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //HamDungChung.Combobox_InitializeLayout(sender, e);
            //FilterCombo f = new FilterCombo(cbChiTietGiayXacNhan, "TenGiayXacNhan");
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

        private void cbChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbChungTu.ActiveRow!= null)
            {
                maChiThuLao = Convert.ToInt64(cbChungTu.ActiveRow.Cells["MaChiThuLao"].Value);
            }

            if (maChiThuLao != 0)
            {

                if (cbChungTu.ActiveRow!= null)
                {
                    maChuongTrinh = (int)cbChungTu.ActiveRow.Cells["MaChuongTrinh"].Value;
                    tenChuongTrinh = (string)cbChungTu.ActiveRow.Cells["TenChuongTrinh"].Value;
                    _tienTuPhieuChi = (decimal)cbChungTu.ActiveRow.Cells["SoTien"].Value;
                    _hoanTat = (bool)cbChungTu.ActiveRow.Cells["HoanTat"].Value;
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
                tbSoTienPhieuChi.Value = 0;
                tbSoTienConLaiPC.Value = 0;
                cmbu_ChuongTrinh.EditValue = 0;
                maChuongTrinh = 0;
            }
            _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
        }

        private void cmbu_ChuongTrinh_EditValueChanged(object sender, EventArgs e)
        {
            if (cmbu_ChuongTrinh.EditValue != null)
            {
                maChuongTrinh = Convert.ToInt32(cmbu_ChuongTrinh.EditValue);
                ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(maChuongTrinh);
                tenChuongTrinh = ct.TenChuongTrinh;
                maNguon = ct.MaNguon;
                tenNguon = ct.TenNguon;
            }
        }

        private void tlslbl_ImportMau_Click(object sender, EventArgs e)
        {
            if (maChiThuLao == 0 && maChuongTrinh == 0)
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
                    OleDbDataAdapter daExcel = new OleDbDataAdapter("Select * From [DanhSachTheoPB$A7:F] ", cnnExcel);
                    DataTable tblExcel = new DataTable("Import");
                    daExcel.Fill(tblExcel);

                    daExcel.UpdateCommand = new OleDbCommand("Update [DanhSachTheoPB$A7:F] Set F6=? Where F2=?", daExcel.SelectCommand.Connection);
                    daExcel.UpdateCommand.Parameters.Add("p1", OleDbType.WChar, 8, "F6");
                    daExcel.UpdateCommand.Parameters.Add("p2", OleDbType.WChar, 20, "F2");

                    //thêm dữ liệu vào object và save lại
                    ThuLaoChuongTrinh objNew;
                    bool ok;
                    foreach (DataRow row in tblExcel.Rows)
                    {

                        ok = true;
                        if (row.IsNull("F2")) continue;

                        if (ok)
                        {
                            objNew = ERP_Library.ThuLaoChuongTrinh.NewThuLaoChuongTrinh();

                            objNew.ThanhToan = false;
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
                            objNew.MaPhieuChi = soChungTu;
                            objNew.MaNguonChuongTrinh = maNguon;
                            objNew.TenNguonChuongTrinh = tenNguon;
                            objNew.ThucNhan = cbDinhMuc.Checked;

                            if (row["F2"].ToString() == string.Empty) return;

                            NhanVien nv = NhanVien.GetNhanVien_ByCMND(row["F2"].ToString());
                            BoPhan bp = BoPhan.GetBoPhan(nv.MaBoPhan);
                            objNew.MaQLNhanVien = nv.MaQLNhanVien;
                            objNew.MaQLBoPhan = bp.MaBoPhanQL;
                            objNew.MaBoPhan = nv.MaBoPhan;
                            objNew.MaChucVu = nv.MaChucVu;
                            objNew.TenBoPhan = nv.TenBoPhan;
                            objNew.TenChucVu = nv.TenChucVu;
                            objNew.MaNhanVien = nv.MaNhanVien;
                            objNew.TenNhanVien = nv.TenNhanVien;

                            objNew.SoTien = Convert.ToDecimal(row["F4"]);
                            objNew.DienGiai = row["F5"].ToString();

                            _thuLaoChuongTrinhList.Add(objNew);
                            row["F6"] = "OK";
                        }
                        else
                        {
                            row["F6"] = "Lỗi";
                        }
                    }

                    daExcel.Update(tblExcel);
                    daExcel.Dispose();
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
                frmExportThuLapImport frm = new frmExportThuLapImport(0);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
