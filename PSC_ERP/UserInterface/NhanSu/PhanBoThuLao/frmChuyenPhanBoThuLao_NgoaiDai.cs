using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using System.Data.SqlClient;
using Infragistics.Win;
namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmChuyenPhanBoThuLao_NgoaiDai : Form
    {
        #region
        KyTinhLuong _kyTinhLuong=KyTinhLuong.NewKyTinhLuong();
        KyTinhLuongList _kyTinhLuongList;
        PhanBoThuLaoNhanVienNgoaiDaiList _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.NewPhanBoThuLaoNhanVienNgoaiDaiList();
        PhanBoThuLaoNhanVienNgoaiDai _phanBoThuLaoNhanVienNgoaiDai;
        BoPhanThuLaoList _boPhanThuLaoList;
        ThuLaoNhanVienNgoaiDai _thuLaoNhanVienNgoaiDai=ThuLaoNhanVienNgoaiDai.NewThuLaoNhanVienNgoaiDai();
        ThuLaoNhanVienNgoaiDaiList _thuLaoNhanVienNgoaiDaiList=ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
        GiayXacNhanTongHopList _giayXacNhanList;

        int maKyTinhLuong = 0;
        DateTime tuNgay = DateTime.Now.Date;
        DateTime denNgay = DateTime.Now.Date;
        int _suaDuLieu = 0;
        int maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        decimal _tongTienPhanBoThuLaoChuongTrinh = 0;
        decimal _tongTienThuLaoChuongTrinh = 0;
        string _duLieu = "";

        #endregion
        public frmChuyenPhanBoThuLao_NgoaiDai()
        {
            InitializeComponent();
            LoadForm();

            grdu_ThuLaoChuongTrinhNgoaiDai.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_ThuLaoChuongTrinhNgoaiDai.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_ThuLaoChuongTrinhNgoaiDai.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_ThuLaoChuongTrinhNgoaiDai.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_ThuLaoChuongTrinhNgoaiDai.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_ThuLaoChuongTrinhNgoaiDai.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
     
        }

        public frmChuyenPhanBoThuLao_NgoaiDai(int maBoPhan, DateTime ngayLap, int maKyTinhLuong, int suaDuLieu, int maChuongTrinh)
        {
            InitializeComponent();
            _suaDuLieu = suaDuLieu;
            LoadForm(maBoPhan, ngayLap, maKyTinhLuong, maChuongTrinh);

            grdu_ThuLaoChuongTrinhNgoaiDai.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.NextCellByTab, 0, 0, 0, 0));
            grdu_ThuLaoChuongTrinhNgoaiDai.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Up, Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));
            grdu_ThuLaoChuongTrinhNgoaiDai.KeyActionMappings.Add(new Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Down, Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, 0, Infragistics.Win.UltraWinGrid.UltraGridState.InEdit, 0, 0));

            grdu_ThuLaoChuongTrinhNgoaiDai.KeyDown += new KeyEventHandler(grdData_KeyDown);
            grdu_ThuLaoChuongTrinhNgoaiDai.KeyPress += new KeyPressEventHandler(grdData_KeyPress);
            grdu_ThuLaoChuongTrinhNgoaiDai.BeforeMultiCellOperation += new BeforeMultiCellOperationEventHandler(grdData_BeforeMultiCellOperation);
    
        }

        public void LoadForm(int maBoPhan, DateTime ngayLap, int maKyTinhLuong, int maChuongTrinh)
        {
            _boPhanThuLaoList = BoPhanThuLaoList.NewBoPhanThuLaoList();
            BoPhanThuLao_BindingSource.DataSource = _boPhanThuLaoList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            KyTinhLuong_BindingSource.DataSource = _kyTinhLuongList;

            KyTinhLuongList kyTinhList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KTL_BindingSource.DataSource = kyTinhList;

            _thuLaoNhanVienNgoaiDaiList = ThuLaoNhanVienNgoaiDaiList.GetThuLaoChuongTrinhListByBoPhan_NgayLap(maBoPhan,ngayLap,maKyTinhLuong ,maChuongTrinh);
            ThuLaoChuongTrinhNgoaiDai_BindingSource.DataSource = _thuLaoNhanVienNgoaiDaiList;

            _giayXacNhanList = GiayXacNhanTongHopList.GetGiayXacNhanTongHopListByBoPhanDen_DaNhapPhanBoThuLao(maBoPhan,2);
            GiayXacNhan_BindingSource.DataSource = _giayXacNhanList;

            cmbu_KyTinhLuongThuLao.Value = maKyTinhLuong;
            cmbu_NgayLapThuLao.Value = ngayLap;
            cmbu_DenNgay.Value = DateTime.Now.Date;
            cmbu_TuNgay.Value = DateTime.Now.Date;
        }
        public void LoadForm()
        {
            _boPhanThuLaoList = BoPhanThuLaoList.NewBoPhanThuLaoList();
            BoPhanThuLao_BindingSource.DataSource = _boPhanThuLaoList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            KyTinhLuong_BindingSource.DataSource = _kyTinhLuongList;

            KyTinhLuongList kyTinhList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KTL_BindingSource.DataSource = kyTinhList;

            _thuLaoNhanVienNgoaiDaiList = ThuLaoNhanVienNgoaiDaiList.NewThuLaoNhanVienNgoaiDaiList();
            ThuLaoChuongTrinhNgoaiDai_BindingSource.DataSource = _thuLaoNhanVienNgoaiDaiList;

            _giayXacNhanList = GiayXacNhanTongHopList.GetGiayXacNhanTongHopListByBoPhanDen_DaNhapPhanBoThuLao(maBoPhan,2);
            GiayXacNhan_BindingSource.DataSource = _giayXacNhanList;

            cmbu_TuNgay.Value = DateTime.Now.Date;
            cmbu_DenNgay.Value = DateTime.Now.Date;
            cmbu_NgayLapThuLao.Value = DateTime.Now.Date;
        }

        private void cmbu_KyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = 150;

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
        }


        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }



        private void Check_TatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (Check_TatCa.Checked == true)
            {
                for (int i = 0; i < grdu_BoPhanThuLao.Rows.Count; i++)
                {
                    if (!grdu_BoPhanThuLao.Rows[i].Hidden == true)
                    {
                        grdu_BoPhanThuLao.Rows[i].Cells["Check"].Value = (object)true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < grdu_BoPhanThuLao.Rows.Count; i++)
                {
                    grdu_BoPhanThuLao.Rows[i].Cells["Check"].Value = (object)false;
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            grdu_BoPhanThuLao.UpdateData();
            _tongTienPhanBoThuLaoChuongTrinh = 0;
            grdu_ThuLaoChuongTrinhNgoaiDai.UpdateData();

            int _bienTam = 0;

            if (grdu_BoPhanThuLao.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult _DialogResult = MessageBox.Show("Bạn có đồng ý chuyển dữ liệu ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                for (int i = 0; i < grdu_BoPhanThuLao.Rows.Count; i++)
                {
                    _tongTienPhanBoThuLaoChuongTrinh += Convert.ToDecimal(grdu_BoPhanThuLao.Rows[i].Cells["SoTien"].Value);

                    if ((bool)grdu_BoPhanThuLao.Rows[i].Cells["Check"].Value == true)
                    {
                        int maBoPhan = (int)grdu_BoPhanThuLao.Rows[i].Cells["Ma"].Value;
                        int maCongViec = (int)grdu_BoPhanThuLao.Rows[i].Cells["MaCongViec"].Value;
                        long maPhanBoThuLao = (long)grdu_BoPhanThuLao.Rows[i].Cells["MaPhanBoThuLao"].Value;
                        bool daDuyet = (bool)grdu_BoPhanThuLao.Rows[i].Cells["DaDuyet"].Value;
                        string dienGiai = (string)grdu_BoPhanThuLao.Rows[i].Cells["DienGiai"].Value;

                        _phanBoThuLaoNhanVienNgoaiDaiList = PhanBoThuLaoNhanVienNgoaiDaiList.GetPhanBoThuLaoNhanVienNgoaiDaiListByBoPhan(maBoPhan, maCongViec, maPhanBoThuLao,daDuyet,dienGiai);

                        foreach (PhanBoThuLaoNhanVienNgoaiDai item in _phanBoThuLaoNhanVienNgoaiDaiList)
                        {
                            for (int j = 0; j < grdu_ThuLaoChuongTrinhNgoaiDai.Rows.Count; j++)
                            {
                                int MaPhanBoThuLaoNgoaiDai = Convert.ToInt32(grdu_ThuLaoChuongTrinhNgoaiDai.Rows[j].Cells["MaPhanBoThuLaoNgoaiDai"].Value);
                                if (MaPhanBoThuLaoNgoaiDai == item.MaPhanBoThuLaoNgoaiDai)
                                {
                                    _bienTam = 1;
                                }
                            }

                            if (_bienTam == 0)
                            {
                                _thuLaoNhanVienNgoaiDai = ThuLaoNhanVienNgoaiDai.NewThuLaoNhanVienNgoaiDai();

                                _thuLaoNhanVienNgoaiDai.MaChuongTrinh = item.MaChuongTrinh;
                                _thuLaoNhanVienNgoaiDai.MaNhanVien = item.MaNhanVien;
                                // _thuLaoNhanVienNgoaiDai.MaKyTinhLuong = item.MaKyTinhLuong;
                                _thuLaoNhanVienNgoaiDai.SoTien = item.SoTien;
                                //  _thuLaoNhanVienNgoaiDai.NgayLap = item.NgayLap;
                                _thuLaoNhanVienNgoaiDai.NguoiLap = Convert.ToInt32(ERP_Library.Security.CurrentUser.Info.UserID); ;
                                _thuLaoNhanVienNgoaiDai.MaPhieuChi = item.MaPhieuChi;
                                _thuLaoNhanVienNgoaiDai.DienGiai = PhanBoThuLao.GetPhanBoThuLao(item.MaPhanBoThuLao).GhiChu;
                                _thuLaoNhanVienNgoaiDai.PhanTramThue = item.PhanTramThue;
                                _thuLaoNhanVienNgoaiDai.MaGiayXacNhan = item.MaGiayXacNhan;
                                _thuLaoNhanVienNgoaiDai.TenGiayXacNhan = GiayXacNhanChuongTrinh.GetGiayXacNhanChuongTrinh(item.MaGiayXacNhan).TenGiayXacNhan;
                                _thuLaoNhanVienNgoaiDai.MaChiTietGiayXacNhan = item.MaChiTietGiayXacNhan;
                                _thuLaoNhanVienNgoaiDai.TenNhanVien = item.TenNhanVien;
                                _thuLaoNhanVienNgoaiDai.MaBoPhan = item.MaBoPhan;
                                _thuLaoNhanVienNgoaiDai.MaQLBoPhan = item.MaQLBoPhan;
                                _thuLaoNhanVienNgoaiDai.TenBoPhan = item.TenBoPhan;
                                _thuLaoNhanVienNgoaiDai.TenChuongTrinh = item.TenChuongTrinh;
                                _thuLaoNhanVienNgoaiDai.DuocNhapHo = item.DuocNhapHo;
                                _thuLaoNhanVienNgoaiDai.PhanTramThue = item.PhanTramThue;
                                _thuLaoNhanVienNgoaiDai.TienThue = item.TienThue;
                                _thuLaoNhanVienNgoaiDai.SoTienConLai = item.SoTienConLai;
                                _thuLaoNhanVienNgoaiDai.Cmnd = item.Cmnd;
                                _thuLaoNhanVienNgoaiDai.DiaChi = item.DiaChi;
                                _thuLaoNhanVienNgoaiDai.MaSoThue = item.MaSoThue;
                                _thuLaoNhanVienNgoaiDai.DienThoai = item.DienThoai;
                                _thuLaoNhanVienNgoaiDai.ThanhToan = item.ThanhToan;
                                _thuLaoNhanVienNgoaiDai.MaPhanBoThuLao = Convert.ToInt32(item.MaPhanBoThuLao);
                                cmbu_KyTinhLuongThuLao.Value = item.MaKyTinhLuong;
                                _thuLaoNhanVienNgoaiDai.MaPhanBoThuLaoNgoaiDai = item.MaPhanBoThuLaoNgoaiDai;

                                _thuLaoNhanVienNgoaiDaiList.Add(_thuLaoNhanVienNgoaiDai); 
                            }
                            _bienTam = 0;
                        }
                    }
                }

                ThuLaoChuongTrinhNgoaiDai_BindingSource.DataSource = _thuLaoNhanVienNgoaiDaiList;

                if (cmbu_NgayLapThuLao.Value != null)
                {
                    KyTinhLuong kyTinhLuong = KyTinhLuong.GetKyTinhLuong_Ngay(Convert.ToDateTime(cmbu_NgayLapThuLao.Value));
                    
                    //Lấy danh sách kỳ tính lương đã khóa sổ
                    KyTinhLuongList kyTinhLuongList = KTL_BindingSource.DataSource as KyTinhLuongList;
                    foreach (KyTinhLuong item in kyTinhLuongList)
                    {
                        if (item.MaKy == kyTinhLuong.MaKy)
                        {
                            cmbu_KyTinhLuongThuLao.Value = kyTinhLuong.MaKy;
                            break;
                        }
                        else
                        {
                            cmbu_KyTinhLuongThuLao.Value = null;
                        }
                    }
                }
                ///reload lai danh sach bo phan
                for (int j = 0; j < grdu_BoPhanThuLao.Rows.Count; j++)
                {
                    if ((bool)grdu_BoPhanThuLao.Rows[j].Cells["Check"].Value == true)
                    {
                        grdu_BoPhanThuLao.Rows[j].Cells["Check"].Value = false;
                        grdu_BoPhanThuLao.Rows[j].Hidden = true;
                    }
                }

                Check_TatCa.Checked = false;
                _suaDuLieu = 1;
            }
        }

        private void Check_TatCaThuLao_CheckedChanged(object sender, EventArgs e)
        {
            if (_duLieu.Trim().CompareTo("") != 0 && _duLieu.Trim().CompareTo("(NonBlanks)") != 0)
            {
                if (Check_TatCaThuLao.Checked == true)
                {
                    for (int i = 0; i < grdu_ThuLaoChuongTrinhNgoaiDai.Rows.Count; i++)
                    {
                        if (!grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Hidden == true && (grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Cells["TenBoPhan"].Value.ToString().Trim().Contains(_duLieu.Trim()) || grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Cells["TenNhanVien"].Value.ToString().Trim().Contains(_duLieu.Trim())))
                        {
                            grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Cells["Check"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdu_ThuLaoChuongTrinhNgoaiDai.Rows.Count; i++)
                    {
                        grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Cells["Check"].Value = (object)false;
                    }
                }

                _duLieu = "";
            }
            else
            {
                if (Check_TatCaThuLao.Checked == true)
                {
                    for (int i = 0; i < grdu_ThuLaoChuongTrinhNgoaiDai.Rows.Count; i++)
                    {
                        if (!grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Hidden == true)
                        {
                            grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Cells["Check"].Value = (object)true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < grdu_ThuLaoChuongTrinhNgoaiDai.Rows.Count; i++)
                    {
                        grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Cells["Check"].Value = (object)false;
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdu_ThuLaoChuongTrinhNgoaiDai.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < grdu_ThuLaoChuongTrinhNgoaiDai.Rows.Count; i++)
            {
                if ((bool)grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Cells["Check"].Value == true)
                {
                    grdu_ThuLaoChuongTrinhNgoaiDai.Rows[i].Selected = true;
                   
                }
            }
            grdu_ThuLaoChuongTrinhNgoaiDai.DeleteSelectedRows();

            Check_TatCaThuLao.Checked = false;
            cmbu_TuNgay.Value = DateTime.Now.Date;
            cmbu_DenNgay.Value = DateTime.Now.Date;

            //if (_suaDuLieu == 1)
            //{
            //    _boPhanThuLaoList = BoPhanThuLaoList.GetBoPhanThuLaoList(maKyTinhLuong, tuNgay, denNgay, maBoPhan, 2);
            //    BoPhanThuLao_BindingSource.DataSource = _boPhanThuLaoList;
            //}
            //else
            //{
            //    _boPhanThuLaoList = BoPhanThuLaoList.GetBoPhanThuLaoListAll(maKyTinhLuong, tuNgay, denNgay, maBoPhan, 2);
            //    BoPhanThuLao_BindingSource.DataSource = _boPhanThuLaoList;
            //}

            _suaDuLieu = 1;
        }

        private void tlsblExport_Click(object sender, EventArgs e)
        {

        }
        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            _tongTienThuLaoChuongTrinh = 0;

            if (cmbu_NgayLapThuLao.Value ==  null)
            {
                MessageBox.Show("Chưa chọn ngày lập", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(cmbu_KyTinhLuongThuLao.Value) == 0)
            {
                MessageBox.Show("Chưa chọn kỳ tính lương.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


             _kyTinhLuong = KyTinhLuong.GetKyTinhLuong((int)cmbu_KyTinhLuongThuLao.Value);
            if (_kyTinhLuong.KhoaSoKy2 == true)
            {
                MessageBox.Show("Kỳ này đã khóa sổ.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((DateTime)cmbu_NgayLapThuLao.Value >= _kyTinhLuong.NgayKhoaThuLao)
            {
                MessageBox.Show("Ngày Lập lớn hơn Ngày Khóa Thù Lao", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((DateTime)cmbu_NgayLapThuLao.Value < _kyTinhLuong.NgayBatDau || (DateTime)cmbu_NgayLapThuLao.Value > _kyTinhLuong.NgayKetThuc)
            {
                MessageBox.Show("Ngày lập phải nằm trong kỳ tính lương", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (grdu_ThuLaoChuongTrinhNgoaiDai.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm dữ liệu vào danh sách thù lao.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            /// luu du lieu xuong
            foreach (ThuLaoNhanVienNgoaiDai item in _thuLaoNhanVienNgoaiDaiList)
            {
                item.NgayLap = Convert.ToDateTime(cmbu_NgayLapThuLao.Value);
                item.MaKyTinhLuong = Convert.ToInt32(cmbu_KyTinhLuongThuLao.Value);
                _tongTienThuLaoChuongTrinh += item.SoTien;
            }

            //if (_tongTienPhanBoThuLaoChuongTrinh < _tongTienThuLaoChuongTrinh && _phanBoThuLaoNhanVienNgoaiDaiList.Count > 0)
            //{
            //    MessageBox.Show("Số tiền phân bổ thù lao nhỏ hơn số tiền trong thù lao chương trình.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            _thuLaoNhanVienNgoaiDaiList.ApplyEdit();
            _thuLaoNhanVienNgoaiDaiList.Save();

            MessageBox.Show("Cập nhật thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Check_TatCaThuLao.Checked = false;
            Check_TatCa.Checked = false;

            _suaDuLieu = 0;
        }

        private void bntXem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbu_GiayXacNhan.Value) == 0)
            {
                MessageBox.Show("Vui lòng chọn giấy xác nhận.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Convert.ToInt32(cmbu_KyTinhLuong.Value) == 0)
            {
                MessageBox.Show("Vui lòng chọn kỳ tính lương.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToDateTime(cmbu_DenNgay.Value).Date < Convert.ToDateTime(cmbu_TuNgay.Value).Date)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            maKyTinhLuong = Convert.ToInt32(cmbu_KyTinhLuong.Value);
            int maGiayXacNhan = Convert.ToInt32(cmbu_GiayXacNhan.Value);
            tuNgay = Convert.ToDateTime(cmbu_TuNgay.Value);
            denNgay = Convert.ToDateTime(cmbu_DenNgay.Value);

            _boPhanThuLaoList = BoPhanThuLaoList.GetBoPhanThuLaoList(maKyTinhLuong,maGiayXacNhan, tuNgay, denNgay, maBoPhan, 2);

            if (_boPhanThuLaoList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }

            BoPhanThuLao_BindingSource.DataSource = _boPhanThuLaoList;
        }

        private void grdu_BoPhanThuLao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            foreach (UltraGridColumn col in this.grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["MaQLBoPhan"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoQL"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienCTV"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienTrongDinhMuc"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienNgoaiDinhMuc"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["DaDuyet"].Hidden = false;

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoQL"].Header.VisiblePosition = 1;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 2;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["MaQLBoPhan"].Header.VisiblePosition = 3;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.VisiblePosition = 4;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 5;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienCTV"].Header.VisiblePosition = 6;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienNgoaiDinhMuc"].Header.VisiblePosition = 7;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienTrongDinhMuc"].Header.VisiblePosition = 8;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 9;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["DaDuyet"].Header.VisiblePosition = 10;

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["Check"].CellActivation = Activation.AllowEdit;

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["MaQLBoPhan"].Header.Caption = "Bộ Phận";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.Caption = "Công Việc";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoQL"].Header.Caption = "Mã Phân Bổ";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienCTV"].Header.Caption = "Tiền CTV";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienTrongDinhMuc"].Header.Caption = "Trong Định Mức";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienNgoaiDinhMuc"].Header.Caption = "Ngoài Định Mức";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Tiền Còn Lại";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["DaDuyet"].Header.Caption = "Duyệt";

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 120;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["MaQLBoPhan"].Width = 80;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Width = 150;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["Check"].Width = 40;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Width = 150;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoQL"].Width = 100;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienCTV"].Width = 120;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienTrongDinhMuc"].Width = 120;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienNgoaiDinhMuc"].Width = 120;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 120;
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["DaDuyet"].Width = 80;

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienCTV"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienCTV"].Format = "#,###";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienCTV"].PromptChar = ' ';

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienTrongDinhMuc"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienTrongDinhMuc"].Format = "#,###";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienTrongDinhMuc"].PromptChar = ' ';

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienNgoaiDinhMuc"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienNgoaiDinhMuc"].Format = "#,###";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienNgoaiDinhMuc"].PromptChar = ' ';

            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "#,###";
            grdu_BoPhanThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].PromptChar = ' ';
        }

        private void grdu_ThuLaoChuongTrinhNgoaiDai_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowAddNew = AllowAddNew.No;
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
           // e.Layout.Override.CellClickAction = CellClickAction.CellSelect;

            foreach (UltraGridColumn col in this.grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTien"].CellClickAction = CellClickAction.CellSelect;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["DienGiai"].CellClickAction = CellClickAction.CellSelect;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenBoPhan"].CellClickAction = CellClickAction.CellSelect;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenNhanVien"].CellClickAction = CellClickAction.CellSelect;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["PhanTramThue"].CellClickAction = CellClickAction.CellSelect;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["PhanTramThue"].CellClickAction = CellClickAction.CellSelect;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellClickAction = CellClickAction.CellSelect;
           // grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["Check"].CellClickAction = CellClickAction.CellSelect;

            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["Check"].Hidden = false;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
         //   grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TienThue"].Hidden = false;
          //  grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["PhanTramThue"].Hidden = false;
          //  grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;

            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["Check"].Header.VisiblePosition = 0;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["PhanTramThue"].Header.VisiblePosition = 3;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TienThue"].Header.VisiblePosition = 4;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 5;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 6;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 7;

            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["DienGiai"].Header.Caption = "Diễn Giải";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Bộ Phận";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "Chọn";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["PhanTramThue"].Header.Caption = "% Thuế";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TienThue"].Header.Caption = "Tiền Thuế";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";

            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["DienGiai"].Width = 150;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 180;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["Check"].Width = 70;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TienThue"].Width = 100;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["PhanTramThue"].Width = 100;
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 110;

            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTienConLai"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "#,###";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["SoTienConLai"].PromptChar = ' ';

            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TienThue"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TienThue"].Format = "#,###";
            grdu_ThuLaoChuongTrinhNgoaiDai.DisplayLayout.Bands[0].Columns["TienThue"].PromptChar = ' ';

        }

        private void cmbu_KyTinhLuongThuLao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_KyTinhLuongThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_KyTinhLuongThuLao.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;

            cmbu_KyTinhLuongThuLao.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";

            cmbu_KyTinhLuongThuLao.DisplayLayout.Bands[0].Columns["TenKy"].Width = 150;

            cmbu_KyTinhLuongThuLao.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
        }

        private void tlslblThem_Click(object sender, EventArgs e)
        {
            LoadForm();
            cmbu_KyTinhLuongThuLao.Value = null;
            cmbu_GiayXacNhan.Value = null;
            txt_BoPhan.Value = null;
            txt_ChuongTrinh.Value = null;
            cmbu_KyTinhLuong.Value = null;
            cbSoTien.Value = 0;
            cbSoTienConLai.Value = 0;
        }


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
                    if (iscopyok && grdu_ThuLaoChuongTrinhNgoaiDai.Selected != null && grdu_ThuLaoChuongTrinhNgoaiDai.Selected.Cells != null)
                    {
                        e.Cancel = true;
                        foreach (Infragistics.Win.UltraWinGrid.UltraGridCell item in grdu_ThuLaoChuongTrinhNgoaiDai.Selected.Cells)
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

        private void grdData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdu_ThuLaoChuongTrinhNgoaiDai.ActiveRow.IsFilterRow != true)
            {
                if (iskeyok && grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.Row.IsDataRow)
                {
                    if (grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.Column.DataType == typeof(decimal))
                        try
                        {
                            grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.Value = Convert.ToDecimal(e.KeyChar.ToString());
                        }
                        catch
                        { }
                    else
                        grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.Value = e.KeyChar.ToString();
                    grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.SelStart = grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.Text.Length;
                    e.Handled = true;
                    iskeyok = false;
                }
            }
        }
        private bool iskeyok = false;//xử lý key cho cột string
        private void grdData_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdu_ThuLaoChuongTrinhNgoaiDai.ActiveRow.IsFilterRow != true)
            {
                if (grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell != null && !grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.IsInEditMode )
                {
                    if ((e.KeyData >= Keys.A && e.KeyData <= Keys.Z) || (e.KeyData >= Keys.D0 && e.KeyData <= Keys.D9) || (e.KeyData >= Keys.NumPad0 && e.KeyData <= Keys.NumPad9))
                    {
                        grdu_ThuLaoChuongTrinhNgoaiDai.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.SelectAll();
                        iskeyok = true;
                    }
                    if (e.KeyCode == Keys.Space && grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.Column.DataType == typeof(bool))
                    {
                        grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.Value = !Convert.ToBoolean(grdu_ThuLaoChuongTrinhNgoaiDai.ActiveCell.Value);
                    }
                }
            }
        }

        private void cmbu_KyTinhLuong_AfterCloseUp(object sender, EventArgs e)
        {
            if (cmbu_KyTinhLuong.Value != null)
            {
                KyTinhLuong _kyTinhLuong = KyTinhLuong.GetKyTinhLuong((int)cmbu_KyTinhLuong.Value);

                cmbu_TuNgay.Value = _kyTinhLuong.NgayBatDau;
                cmbu_DenNgay.Value = _kyTinhLuong.NgayKetThuc;
            }
        }

        public decimal SoTienPhanBoThuLaoByGiayXacNhan(int maGiayXacNhan, int maBoPhan)
        {
            decimal soTienPhanBoThuLao = 0;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraSoTienPhanBoThuLao";
                    cm.Parameters.AddWithValue("@MaGiayXacNhan", maGiayXacNhan);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@SoTienPhanBo", soTienPhanBoThuLao);
                    cm.Parameters["@SoTienPhanBo"].Direction = ParameterDirection.Output;

                    cm.ExecuteNonQuery();
                    soTienPhanBoThuLao = Convert.ToDecimal(cm.Parameters["@SoTienPhanBo"].Value);
                }
            }//using
            return soTienPhanBoThuLao;

        }
        private void cmbu_GiayXacNhan_AfterCloseUp(object sender, EventArgs e)
        {
            if (cmbu_GiayXacNhan.Value == null)
            {
                return;
            }
            else
            {
                int maGiayXacNhan = Convert.ToInt32(cmbu_GiayXacNhan.Value);
                GiayXacNhanTongHop _giayXacNhan = GiayXacNhanTongHop.GetGiayXacNhanTongHop(maGiayXacNhan, maBoPhan);

                if (_giayXacNhan != null)
                {
                    txt_BoPhan.Value = BoPhan.GetBoPhan(_giayXacNhan.MaBoPhanDen).TenBoPhan;
                    txt_ChuongTrinh.Value = ChuongTrinh.GetChuongTrinh(_giayXacNhan.MaChuongTrinh).TenChuongTrinh;
                    cbSoTien.Value = _giayXacNhan.SoTien;
                    cbSoTienConLai.Value = _giayXacNhan.SoTien - SoTienPhanBoThuLaoByGiayXacNhan(_giayXacNhan.MaGiayXacNhan, _giayXacNhan.MaBoPhanDen);
                }
            }
        }

        private void cmbu_GiayXacNhan_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbu_GiayXacNhan, "TenGiayXacNhan");
            foreach (UltraGridColumn col in this.cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Hidden = false;
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Hidden = false;

            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.Caption = "Tên Giấy Xác Nhận";
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.Caption = "Ghi Chú";

            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["TenGiayXacNhan"].Header.VisiblePosition = 0;
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 1;
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["GhiChu"].Header.VisiblePosition = 2;


            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].Format = "###,###,###,###,###";
            cmbu_GiayXacNhan.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
  
        }

        private void grdu_ThuLaoChuongTrinhNgoaiDai_FilterCellValueChanged(object sender, FilterCellValueChangedEventArgs e)
        {
            _duLieu = "";
            UltraGridFilterCell filterCell = e.FilterCell;
            EmbeddableEditorBase editor = filterCell.EditorResolved;

            if (filterCell.Value != null && editor.IsValid)
            {
                _duLieu = editor.Value.ToString();
            }
        }

    }
}
