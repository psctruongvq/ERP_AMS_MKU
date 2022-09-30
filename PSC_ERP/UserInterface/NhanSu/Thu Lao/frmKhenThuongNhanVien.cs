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
using System.Collections;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinEditors;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmKhenThuongNhanVien : Form
    {
        BoPhanList _boPhanList;
        LoaiPhuCapList _loaiPhuCapList;
        KyTinhLuongList _kyTinhLuongList;
        ThongTinNhanVienTongHopList _nhanVienList;
        PhuCapNhanVienList _phuCapNhanVienList;
        static int _maBoPhan = 0;
        static int _maKyTinhluong = 0;
        static int _maLoaiPhuCap = 0;
        private bool _khoaSo = false;
        public int _loaiKhenThuong = 0;
        //ChiThuLaoList _chiThuLaoList;
        ChiThuLaoTongHopList _chiThuLaoList;
        static int _maChuongTrinh = 0;

        string _tenChuongTrinh = string.Empty;
        long _maChiThuLao = 0;
        string _soChungTu = string.Empty;
        string _tenChungTu = string.Empty;
        string _tenGiayXacNhan = string.Empty;
        string _ghiChuPhieuChi = string.Empty;
        bool _hoanTat = false;
        string _tenNguon = string.Empty;
        int _maNguon = 0; decimal _tienTuPhieuChi = 0;
        string _tenPhieuChi = string.Empty;

        private bool _UpdateMaPhieuChi = false;

        #region Bo Sung MaLoai Chi

        string _thongbaoNhapLoaiPhuCap = string.Empty;
        int _ptThuNhapTinhThue = 0;
        int _maLoaiChi = 0;
        Boolean _suaDuLieu = false;
        decimal _tongTienChoPhepCapNhat = 0;

        private void SetTieuDe_ThongBaoNhapLoaiPhuCap()
        {
            if (_maLoaiChi == 2)
            {
                this.Text = "Khen Thưởng Nhân Viên - Tiền Mặt - Trong Đài";
                lbLoaiPhuCap.Text = "Loại khen thưởng ";
                _thongbaoNhapLoaiPhuCap = "Vui Lòng nhập Loại Khen Thưởng";
            }
            else if (_maLoaiChi == 4)
            {
                this.Text = "Phụ Cấp Nhân Viên - Tiền Mặt";
                lbLoaiPhuCap.Text = "Loại phụ cấp ";
                _thongbaoNhapLoaiPhuCap = "Vui Lòng nhập Loại Phụ Cấp";
            }
            else if (_maLoaiChi == 5)
            {
                this.Text = "Truy Lĩnh Nhân Viên - Tiền Mặt";
                lbLoaiPhuCap.Text = "Loại truy lĩnh ";
                _thongbaoNhapLoaiPhuCap = "Vui Lòng nhập Loại Truy Lĩnh";
                
            }
            else if (_maLoaiChi == 6)
            {
                this.Text = "Truy Thu Nhân Viên - Tiền Mặt";
                lbLoaiPhuCap.Text = "Loại truy thu ";
                _thongbaoNhapLoaiPhuCap = "Vui Lòng nhập Loại Truy Thu";
                
            }
        }

        private decimal TongSoTienToiDaChoPhepCapNhat()
        {
            decimal soTienDaNhap = 0;
            decimal soTienChoPhepCapNhat = 0;
            foreach (PhuCapNhanVien item in _phuCapNhanVienList)
            {
                soTienDaNhap +=Math.Abs(item.PhuCap);
            }
            soTienChoPhepCapNhat += soTienDaNhap + Math.Abs(Convert.ToDecimal(tbSoTienConLaiPC.Value));

            return soTienChoPhepCapNhat;
        }

        private void KhoaConTrol(bool khoa)
        {
            cbChungTu.ReadOnly = khoa;
            txt_ChuongTrinh.ReadOnly = khoa;
            cbKyTinhLuong.ReadOnly = khoa;
        }


        #region Constructors

        public void ShowKhenThuong()
        {
            _maLoaiChi = 2;//Chi Khen Thuong
            KhoiTao();
            this.Show();
        }

        public void ShowPhuCap()
        {
            _maLoaiChi = 4;//Chi Thu Lao
            KhoiTao();
            this.Show();
        }

        public void ShowTruyLinh()
        {
            _maLoaiChi = 5;//Truy Linh
            KhoiTao();
            this.Show();
        }

        public void ShowTruyThu()
        {
            _maLoaiChi = 6;//Truy Thu
            KhoiTao();
            this.Show();
        }

        #endregion

        #endregion

        public frmKhenThuongNhanVien()
        {
            InitializeComponent();
            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            LoạiKhenThuongList_BindingSouce.DataSource = typeof(LoaiPhuCapList);
            this.bindingSource1_KyTinhLuong.DataSource = typeof(KyTinhLuongList);
            BangLuong_PhuCapList_BindingSouce.DataSource = typeof(PhuCapNhanVienList);
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_PhuCapNhanVien.AfterCellUpdate += new CellEventHandler(grdu_PhuCapNhanVien_AfterCellUpdate);
            grdu_PhuCapNhanVien.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_PhuCapNhanVien.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_PhuCapNhanVien.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            //KhoiTao();
        }
        public frmKhenThuongNhanVien(int maKyTinhLuong, int maLoaiPhuCap, string soQuyetDinh, string maPhieuChi, long maChiThuLao, int maloaichi,DateTime ngayLap)
        {
            _maChiThuLao = maChiThuLao;
            _maLoaiChi = maloaichi;

            InitializeComponent();
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_PhuCapNhanVien.AfterCellUpdate += new CellEventHandler(grdu_PhuCapNhanVien_AfterCellUpdate);
            grdu_PhuCapNhanVien.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_PhuCapNhanVien.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_PhuCapNhanVien.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            KhoiTao();
            cbKyTinhLuong.Value = maKyTinhLuong;
            cbLoaiKhenThuong.Value = maLoaiPhuCap;
            txt_MaPhieuChi.Text = maPhieuChi;

            _phuCapNhanVienList.Clear();
            //_phuCapNhanVienList = PhuCapNhanVienList.GetNhapPhuCapListByNgay(_maKyTinhLuong,_maLoaiPhuCap,_soQuyetDinh,_maPhieuChi,false);
            _phuCapNhanVienList = PhuCapNhanVienList.GetNhapPhuCapListByNgay_MaLoaiChi(maKyTinhLuong, maLoaiPhuCap, soQuyetDinh, maPhieuChi, false, _maChiThuLao, _maLoaiChi,ngayLap);

            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
            _maKyTinhluong = maKyTinhLuong;
            _maLoaiPhuCap = maLoaiPhuCap;
            _khoaSo = KyTinhLuong.GetKyTinhLuong(_maKyTinhluong).KhoaSoKy2;
            if (_phuCapNhanVienList.Count != 0)
            {
                txt_MaPhieuChi.Text = _phuCapNhanVienList[0].MaPhieuChi;
                dateTimePicker_NgayLap.Value = _phuCapNhanVienList[0].NgayLap as object;
            }
            else
            {
                txt_MaPhieuChi.Text = "";
            }
            this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();

            cbChungTu.Value = maChiThuLao;//
            _suaDuLieu = true;//
            _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();//

            KhoaConTrol(true);//Khoa ConTrol

        }

        #region BS
        public frmKhenThuongNhanVien(PhuCapNhanVienList phucapnhanvienlist, int maLoaiPhuCap,int maloaichi)
        {
            _maLoaiChi = maloaichi;
            _UpdateMaPhieuChi = true;//
            InitializeComponent();
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_PhuCapNhanVien.AfterCellUpdate += new CellEventHandler(grdu_PhuCapNhanVien_AfterCellUpdate);
            grdu_PhuCapNhanVien.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_PhuCapNhanVien.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_PhuCapNhanVien.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
            KhoiTao();
            cbLoaiKhenThuong.Value = maLoaiPhuCap;

            _phuCapNhanVienList.Clear();
            _phuCapNhanVienList = phucapnhanvienlist;
            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
            _maLoaiPhuCap = maLoaiPhuCap;
            _khoaSo = KyTinhLuong.GetKyTinhLuong(_maKyTinhluong).KhoaSoKy2;
            this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();
        }
        #endregion//BS

        private void frmThuLaoChuongTrinh_Load(object sender, EventArgs e)
        {
            grdu_PhuCapNhanVien.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, Infragistics.Win.UltraWinGrid.UltraGridState.AddRow, 0, 0, 0));
        }

        public void KhoiTao()
        {
            SetTieuDe_ThongBaoNhapLoaiPhuCap();//

            _boPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan _boPhanAdd = BoPhan.NewBoPhan(0, "Tất Cả");
            _boPhanList.Insert(0, _boPhanAdd);
            this.bindingSource1_BoPhan.DataSource = _boPhanList;
            _loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapListByMaLoaiChi(_maLoaiChi);
            //_loaiPhuCapList = LoaiPhuCapList.GetLoaiPhuCapListByThuong();
            LoạiKhenThuongList_BindingSouce.DataSource = _loaiPhuCapList;
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            this.bindingSource1_KyTinhLuong.DataSource = _kyTinhLuongList;
            _phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;

            _maBoPhan = 0;
            _maLoaiPhuCap = 0;
            _maKyTinhluong = 0;
            dateTimePicker_NgayLap.Value = DateTime.Today.Date;
            _nhanVienList = ThongTinNhanVienTongHopList.NewThongTinNhanVienTongHopList();
            bindingSource1_NhanVien.DataSource = _nhanVienList;

            //_chiThuLaoList = ChiThuLaoList.GetChiThuLaoListByUser(ERP_Library.Security.CurrentUser.Info.UserID);
            //this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;

            _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao, _maLoaiChi);
            ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
            _chiThuLaoList.Insert(0, itemChiTL);
            this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;
        }

        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (_UpdateMaPhieuChi)
                return;
            try
            {
                if (cmbu_Bophan.ActiveRow != null)
                {
                    _maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
                }
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(_maBoPhan, checkBox_NghiHuu.Checked);
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
                for (int i = 0; i < ultraGrid_NhanVien.Rows.Count; i++)
                {
                    if (!ultraGrid_NhanVien.Rows[i].Hidden == true)
                    {
                        ultraGrid_NhanVien.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ultraGrid_NhanVien.Rows.Count; i++)
                {
                    ultraGrid_NhanVien.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (_maLoaiPhuCap != 0 && _maKyTinhluong != 0 && _soChungTu != "")
            {
                DialogResult _DialogResult = MessageBox.Show("Bạn Có Đồng Ý Đứa Nhân Viên Qua", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (_DialogResult == DialogResult.Yes)
                {
                    for (int i = 0; i < ultraGrid_NhanVien.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid_NhanVien.Rows[i].Cells["Check"].Value == true)
                        {

                            PhuCapNhanVien phuCapNhanVien = PhuCapNhanVien.NewPhuCapNhanVien();
                            phuCapNhanVien.MaKyTinhLuong = _maKyTinhluong;
                            if (cbLoaiKhenThuong.ActiveRow != null)
                                phuCapNhanVien.MaLoaiPhuCap = (int)cbLoaiKhenThuong.ActiveRow.Cells["MaLoaiPhuCap"].Value;
                            phuCapNhanVien.SoQuyetDinh = "";
                            phuCapNhanVien.MaNhanVien = (long)ultraGrid_NhanVien.Rows[i].Cells["MaNhanVien"].Value;
                            phuCapNhanVien.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                            phuCapNhanVien.TinhThueTNCN = true;
                            phuCapNhanVien.TenNhanVien = (string)ultraGrid_NhanVien.Rows[i].Cells["TenNhanVien"].Value;
                            phuCapNhanVien.MaPhieuChi = txt_MaPhieuChi.Text;
                            phuCapNhanVien.ThanhToan = false;
                            phuCapNhanVien.MaBoPhan = NhanVien.GetNhanVien(phuCapNhanVien.MaNhanVien).MaBoPhan;
                            phuCapNhanVien.TenBoPhan = (string)ultraGrid_NhanVien.ActiveRow.Cells["TenBoPhan"].Value;
                            phuCapNhanVien.TenPhuCap = cbLoaiKhenThuong.Text;
                            phuCapNhanVien.DienGiai = cbLoaiKhenThuong.Text;

                            //phuCapNhanVien.SoTienChiuThue = (phuCapNhanVien.PhuCap * _ptThuNhapTinhThue) / 100;//

                            _phuCapNhanVienList.Add(phuCapNhanVien);

                        }
                    }
                    this.BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
                    this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();

                    for (int i = 0; i < ultraGrid_NhanVien.Rows.Count; i++)
                    {
                        if ((bool)ultraGrid_NhanVien.Rows[i].Cells["Check"].Value == true)
                        {
                            ultraGrid_NhanVien.Rows[i].Cells["Check"].Value = false;
                            ultraGrid_NhanVien.Rows[i].Hidden = true;
                        }
                    }
                    this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (_maLoaiPhuCap == 0)
                {
                    MessageBox.Show(_thongbaoNhapLoaiPhuCap, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbLoaiKhenThuong.Focus();
                    return;
                }
                else if (_soChungTu == "")
                {
                    MessageBox.Show("Vui Lòng Chọn Phiếu Chi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbChungTu.Focus();
                    return;
                }
                else
                {
                    MessageBox.Show("Vui Lòng Chọn Kỳ Tính Lương ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbKyTinhLuong.Focus();
                    return;
                }
            }
        }


        private void tlslblLuu_Click(object sender, EventArgs e)
        {

            try
            {
                if (_khoaSo == true)
                {
                    MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (_maKyTinhluong == 0)
                    {
                        MessageBox.Show("Vui Lòng Chọn Kỳ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbKyTinhLuong.Focus();
                        return;
                    }

                    else if (_maLoaiPhuCap == 0)
                    {
                        MessageBox.Show(_thongbaoNhapLoaiPhuCap, "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbLoaiKhenThuong.Focus();
                        return;
                    }

                    decimal soTienDaNhap = 0;//
                    foreach (PhuCapNhanVien pc in _phuCapNhanVienList)
                    {
                        pc.MaKyTinhLuong = _maKyTinhluong;
                        pc.MaLoaiPhuCap = _loaiKhenThuong;
                        pc.MaPhieuChi = _soChungTu;
                        pc.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
                        pc.SoQuyetDinh = "";
                        pc.ThanhToan = false;
                        pc.TinhThueTNCN = true;
                      // pc.u = ERP_Library.Security.CurrentUser.Info.UserID;

                        pc.TenPhuCap = cbLoaiKhenThuong.Text;

                        pc.MaChiThuLao = _maChiThuLao;//
                        soTienDaNhap +=Math.Abs(pc.PhuCap);//
                    }

                    #region BoSung
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
                            decimal tien =Math.Abs(PhuCapNhanVien.SoTienDaNhap(_maChiThuLao));
                            //if (soTienDaNhap > _tongTienChoPhepCapNhat || Convert.ToDecimal(tbSoTienConLaiPC.Value) < soTienDaNhap - PhuCapNhanVien.SoTienDaNhap(_maChiThuLao))
                            if (soTienDaNhap > _tongTienChoPhepCapNhat || Convert.ToDecimal(tbSoTienConLaiPC.Value) < (soTienDaNhap - PhuCapNhanVien.SoTienDaNhap(_maChiThuLao)))
                            {
                                MessageBox.Show("Không đủ tiền nhập thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }
                    #endregion

                    _phuCapNhanVienList.ApplyEdit();
                    BangLuong_PhuCapList_BindingSouce.EndEdit();
                    _phuCapNhanVienList.Save();
                    MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if(_phuCapNhanVienList.Count>0)
                    {
                        KhoaConTrol(true);//Khoa Control
                    }

                    //Set Lai So Tien Con Lai
                    tbSoTienConLaiPC.Value =Math.Abs( PhuCapNhanVien.SoTienConLaiPhieuChi(_maChiThuLao));

                    _suaDuLieu = true;
                    _tongTienChoPhepCapNhat = TongSoTienToiDaChoPhepCapNhat();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            _UpdateMaPhieuChi = false;//BS
            _suaDuLieu = false;
            cbChungTu.Value = 0;
            dateTimePicker_NgayLap.Value = DateTime.Today.Date;
            //KhoiTao();
            #region Replace KhoiTao
            _phuCapNhanVienList = PhuCapNhanVienList.NewPhuCapNhanVienList();
            BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
            if (cbLoaiKhenThuong.Value != null)
            {
                _maLoaiPhuCap = (int)cbLoaiKhenThuong.Value;
            }
            else
            {
                _maLoaiPhuCap = 0;
            }

            if (cbKyTinhLuong.Value != null)
            {
                _maKyTinhluong = (int)cbKyTinhLuong.Value;
                _khoaSo = KyTinhLuong.GetKyTinhLuong(_maKyTinhluong).KhoaSoKy2;
            }
            else
            {
                _maKyTinhluong = 0;
            }

            if (cmbu_Bophan.ActiveRow != null)
            {
                _maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
            }
            else
            {
                _maBoPhan = 0;
            }
            _chiThuLaoList = ChiThuLaoTongHopList.GetChiThuLaoTongHopListByUserAndMaChiThuLao_MaLoaiChi(ERP_Library.Security.CurrentUser.Info.UserID, _maChiThuLao, _maLoaiChi);
            ChiThuLaoTongHop itemChiTL = ChiThuLaoTongHop.NewChiThuLaoTongHop("Không Có Chứng Từ");
            _chiThuLaoList.Insert(0, itemChiTL);
            this.bindingSource1_ChungTu.DataSource = _chiThuLaoList;
            #endregion//Replace KhoiTao
            KhoaConTrol(false);//Mo Khoa Control
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (_khoaSo == true)
            {
                MessageBox.Show("Kỳ Này Đã Được Khóa Sổ Rồi", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                for (int i = 0; i < grdu_PhuCapNhanVien.Rows.Count; i++)
                {
                    if ((bool)grdu_PhuCapNhanVien.Rows[i].Cells["Check"].Value == true)
                    {
                        grdu_PhuCapNhanVien.Rows[i].Selected = true;

                    }

                }
                grdu_PhuCapNhanVien.DeleteSelectedRows();
                _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(_maBoPhan, false);
                this.bindingSource1_NhanVien.DataSource = _nhanVienList;
                this.lbSoLuong.Text = _phuCapNhanVienList.Count.ToString();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < grdu_PhuCapNhanVien.Rows.Count; i++)
                {
                    if (!grdu_PhuCapNhanVien.Rows[i].Hidden == true)
                    {
                        grdu_PhuCapNhanVien.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }

            }
            else
            {
                for (int i = 0; i < grdu_PhuCapNhanVien.Rows.Count; i++)
                {
                    grdu_PhuCapNhanVien.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void grdu_PhuCapNhanVien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                button2_Click_1(null, null);
                // this.ultraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                this.grdu_PhuCapNhanVien.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Copy);
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                this.grdu_PhuCapNhanVien.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.Paste);

            }
        }

        private void grdu_PhuCapNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                //col.Header.Appearance.BackColor = System.Drawing.Color.White;
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

            e.Layout.Override.AllowAddNew = AllowAddNew.TemplateOnTop;
            e.Layout.Override.TemplateAddRowPrompt = "Click vào đây để thêm dòng mới";
            e.Layout.Override.TemplateAddRowAppearance.BackColor = Color.FromArgb(245, 250, 255);
            e.Layout.Override.TemplateAddRowAppearance.ForeColor = SystemColors.GrayText;
            e.Layout.Override.AddRowAppearance.BackColor = Color.LightYellow;
            e.Layout.Override.AddRowAppearance.ForeColor = Color.Blue;
            e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.TemplateAddRow;
            e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = SystemColors.Control;
            e.Layout.Override.TemplateAddRowPromptAppearance.ForeColor = Color.Maroon;
            e.Layout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;

            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["Check"].Width = 70;

            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Nhân Viên";
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;

            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["PhuCap"].Hidden = false;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["PhuCap"].Header.Caption = "Số Tiền";
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["PhuCap"].Header.VisiblePosition = 2;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["PhuCap"].Width = 100;

            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 3;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 200;

            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Bộ Phận";
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 4;
            grdu_PhuCapNhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 200;

            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            // Turn on all of the Cut, Copy, and Paste functionality. 
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;

            // In order to cut or copy, the user needs to select cells or rows. 
            // So set CellClickAction so that clicking on a cell selects that cell
            // instead of going into edit mode.
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;
        }

        private void ultraGrid1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ultraGrid_NhanVien.ActiveRow != null)
            {

                if (e.KeyCode == Keys.Space)
                {
                    if (ultraGrid_NhanVien.ActiveRow.Cells["Check"].Value.ToString() != "")
                    {
                        if ((bool)ultraGrid_NhanVien.ActiveRow.Cells["Check"].Value == true)
                            ultraGrid_NhanVien.ActiveRow.Cells["Check"].Value = false;
                        else
                            ultraGrid_NhanVien.ActiveRow.Cells["Check"].Value = true;
                    }
                }
            }
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
            if (cbLoaiKhenThuong.Value != null)
            {
                _maLoaiPhuCap = (int)cbLoaiKhenThuong.Value;
                foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
                {
                    tl.MaLoaiPhuCap = _maLoaiPhuCap;
                }
            }
        }

        private void cbKyTinhLuong_Leave(object sender, EventArgs e)
        {
            if (cbKyTinhLuong.Value != null)
            {
                _maKyTinhluong = (int)cbKyTinhLuong.Value;
                _khoaSo = KyTinhLuong.GetKyTinhLuong(_maKyTinhluong).KhoaSoKy2;
                foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
                {
                    tl.MaKyTinhLuong = _maKyTinhluong;
                }
            }
        }
        private void dateTimePicker_NgayLap_Leave(object sender, EventArgs e)
        {

            foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
            {
                tl.NgayLap = Convert.ToDateTime(dateTimePicker_NgayLap.Value);
            }
        }
        private void grdu_PhuCapNhanVien_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell.Column.Key == "PhuCap")
            {
                //e.Cell.Row.Cells["SoTien"].Value = e.Cell.Value;
                //e.Cell.Row.Cells["PhuCap"].Value = e.Cell.Value;
            }
        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
        //    {
        //        tl.MaPhieuChi = txt_MaPhieuChi.Text;
        //    }
        //}

        private void grdu_PhuCapNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_PhuCapNhanVien.ActiveRow != null)
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (grdu_PhuCapNhanVien.ActiveRow.Cells["Check"].Value.ToString() != "")
                    {
                        if ((bool)grdu_PhuCapNhanVien.ActiveRow.Cells["Check"].Value == true)
                            grdu_PhuCapNhanVien.ActiveRow.Cells["Check"].Value = false;
                        else
                            grdu_PhuCapNhanVien.ActiveRow.Cells["Check"].Value = true;
                    }
                }
            }

            if ((e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9) && grdu_PhuCapNhanVien.ActiveCell != null && grdu_PhuCapNhanVien.ActiveCell.Column.DataType == typeof(decimal))
            {
                grdu_PhuCapNhanVien.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }
        }



        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_PhuCapNhanVien.ActiveCell != null && !grdu_PhuCapNhanVien.ActiveCell.IsInEditMode && grdu_PhuCapNhanVien.ActiveCell.Column.Key != "TenNhanVien")
            {
                if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                {
                    grdu_PhuCapNhanVien.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                    grdu_PhuCapNhanVien.ActiveCell.SelectAll();
                    iskeyok = true;
                }
                if (e.KeyCode == Keys.Space && grdu_PhuCapNhanVien.ActiveCell.Column.DataType == typeof(bool))
                {
                    grdu_PhuCapNhanVien.ActiveCell.Value = !Convert.ToBoolean(grdu_PhuCapNhanVien.ActiveCell.Value);
                }
            }
        }

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (iskeyok && grdu_PhuCapNhanVien.ActiveCell.Row.IsDataRow)
            {
                if (grdu_PhuCapNhanVien.ActiveCell.Column.DataType == typeof(decimal))
                    try
                    {
                        grdu_PhuCapNhanVien.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                    }
                    catch
                    { }
                else
                    grdu_PhuCapNhanVien.ActiveCell.Value = e.KeyChar.ToString();
                grdu_PhuCapNhanVien.ActiveCell.SelStart = grdu_PhuCapNhanVien.ActiveCell.Text.Length;
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
                    if (iscopyok && grdu_PhuCapNhanVien.Selected != null && grdu_PhuCapNhanVien.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_PhuCapNhanVien.Selected.Cells)
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

        private void cbLoaiKhenThuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cbLoaiKhenThuong, "TenLoaiPhuCap");

            foreach (UltraGridColumn col in this.cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            //"MaQLLoaiPhuCap","TenLoaiPhuCap","KhongDuyet","PTThuNhapTinhThue"
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Hidden = false;
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Header.Caption = "Mã Qlý";
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["MaQLLoaiPhuCap"].Header.VisiblePosition = 0;
          
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Hidden = false;
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Header.Caption = "Tên loại";
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Header.VisiblePosition = 1;
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["TenLoaiPhuCap"].Width = cbLoaiKhenThuong.Width;

            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["KhongDuyet"].Hidden = false;
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["KhongDuyet"].Header.Caption = "Không duyệt";
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["KhongDuyet"].Header.VisiblePosition = 2;

            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["PTThuNhapTinhThue"].Hidden = false;
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["PTThuNhapTinhThue"].Header.Caption = "PT Thu nhập tính thuế";
            cbLoaiKhenThuong.DisplayLayout.Bands[0].Columns["PTThuNhapTinhThue"].Header.VisiblePosition = 3;
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

            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["NgayBatDau"].Hidden = false;
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["NgayBatDau"].Header.Caption = "Ngày bắt đầu";
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["NgayBatDau"].Width = cbKyTinhLuong.Width;

            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Hidden = false;
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Header.Caption = "Ngày kết thúc";
            cbKyTinhLuong.DisplayLayout.Bands[0].Columns["NgayKetThuc"].Width = cbKyTinhLuong.Width;
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

        private void ultraGrid_NhanVien_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            //HamDungChung h = new HamDungChung();
            //h.ultragrdEmail_InitializeLayout(sender, e);
            //e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            e.Layout.Override.RowSelectorNumberStyle = RowSelectorNumberStyle.RowIndex;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucvu"].Hidden = false;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].Hidden = false;

            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Quản Lý";
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Chứng Minh";
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.Caption = "Chức Vụ";
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.Caption = "Mã Số Thuế";

            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 2;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 3;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 4;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucvu"].Header.VisiblePosition = 5;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].Header.VisiblePosition = 6;

            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["Check"].Width = 40;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Width = 100;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 150;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucvu"].Width = 100;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].Width = 100;

            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["CMND"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
            ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["TenChucVu"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
            //ultraGrid_NhanVien.DisplayLayout.Bands[0].Columns["MaSoThue"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
        }

        private void cbLoaiChucVu_ValueChanged(object sender, EventArgs e)
        {
            if (cbLoaiKhenThuong.ActiveRow != null)
            {
                _loaiKhenThuong = Convert.ToInt32(cbLoaiKhenThuong.ActiveRow.Cells["MaLoaiPhuCap"].Value);
                _ptThuNhapTinhThue = Convert.ToInt32(cbLoaiKhenThuong.ActiveRow.Cells["PTThuNhapTinhThue"].Value);
                //foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
                //{
                //    tl.SoTienChiuThue = (tl.PhuCap*_ptThuNhapTinhThue)/100;
                //}
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

        private void cbChungTu_ValueChanged(object sender, EventArgs e)
        {
            if (cbChungTu.ActiveRow != null)
            {
                _maChiThuLao = Convert.ToInt64(cbChungTu.ActiveRow.Cells["MaChiThuLao"].Value);
            }

            if (_maChiThuLao != 0)
            {
                if (cbChungTu.ActiveRow != null)
                {
                    _maChuongTrinh = (int)cbChungTu.ActiveRow.Cells["MaChuongTrinh"].Value;
                    _tenChuongTrinh = (string)cbChungTu.ActiveRow.Cells["TenChuongTrinh"].Value;
                    _tienTuPhieuChi = (decimal)cbChungTu.ActiveRow.Cells["SoTien"].Value;
                    _hoanTat = (bool)cbChungTu.ActiveRow.Cells["HoanTat"].Value;
                    _soChungTu = (string)cbChungTu.ActiveRow.Cells["SoChungTu"].Value;
                    _ghiChuPhieuChi = (string)cbChungTu.ActiveRow.Cells["GhiChu"].Value;
                    ChuongTrinh ct = ChuongTrinh.GetChuongTrinh(_maChuongTrinh);
                    _tenChuongTrinh = ct.TenChuongTrinh;
                    _maNguon = ct.MaNguon;
                    _tenNguon = ct.TenNguon;
                    tbSoTienPhieuChi.Value = _tienTuPhieuChi;
                    //tbSoTienConLaiPC.Value = ChiThuLao.SoTienConLaiPhieuChi(_maChiThuLao);
                    tbSoTienConLaiPC.Value = Math.Abs(PhuCapNhanVien.SoTienConLaiPhieuChi(_maChiThuLao));
                    txt_ChuongTrinh.Text = _tenChuongTrinh;
                    txt_MaPhieuChi.Text = _soChungTu;//
                }
                foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
                {
                    tl.MaPhieuChi = _soChungTu;
                }

                //if (cbLoaiKhenThuong.Value != null)
                //{
                //    maLoaiBoPhan = (int)cbLoaiKhenThuong.Value;
                //    foreach (PhuCapNhanVien tl in _phuCapNhanVienList)
                //    {
                //        tl.MaLoaiPhuCap = maLoaiBoPhan;
                //    }
                //}    
            }
            else
            {
                _soChungTu = string.Empty;
                tbSoTienPhieuChi.Value = 0;
                tbSoTienConLaiPC.Value = 0;
            }
        }


        private void tlSMenuItemUpdateMaPhieuChi_Click(object sender, EventArgs e)
        {
            frmChonPhuCapNhanVienForUpdateMaPhieuChi frm = new frmChonPhuCapNhanVienForUpdateMaPhieuChi(1);
            if (frm.ShowDialog() != DialogResult.OK)
            {
                if (frm.PhuCapNhanVienListCheck.Count > 0)
                {
                    _UpdateMaPhieuChi = true;
                    _phuCapNhanVienList = frm.PhuCapNhanVienListCheck;
                    this.BangLuong_PhuCapList_BindingSouce.DataSource = _phuCapNhanVienList;
                }
            }
        }

        private void tlSMenuItemInPhucCapNVNghiViec_Click(object sender, EventArgs e)
        {
            frmChonPhuCapNhanVienForUpdateMaPhieuChi frm = new frmChonPhuCapNhanVienForUpdateMaPhieuChi(2);
            frm.ShowDialog();
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            frmBaoCaoPhuCapBS frm = new frmBaoCaoPhuCapBS(0);
            frm.Show();
        }
    }
}
