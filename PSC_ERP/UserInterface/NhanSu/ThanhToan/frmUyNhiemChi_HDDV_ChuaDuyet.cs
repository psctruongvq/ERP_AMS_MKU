using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library.ThanhToan;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmUyNhiemChi_HDDV_ChuaDuyet : Form
    {
        #region Properties
        internal ERP_Library.ChungTuNganHang _chungtu;
        internal ERP_Library.LenhChuyenTienNuocNgoai _lenhChuyen;
        internal ERP_Library.GiayBanNgoaiTe _giayban;
        private bool _loai = false;
        private int _loaiTruyen = 1;
        private int _maNganHang = 0;
        private int _maDoiTac = 0;
        private int _nganHangNhan = 0;
        private string _lyDo = string.Empty;
        private decimal _soTien = 0;
        public decimal _tyGia = 0;
        #endregion

        #region Loads
        public frmUyNhiemChi_HDDV_ChuaDuyet()
        {
            InitializeComponent();
        }

        public frmUyNhiemChi_HDDV_ChuaDuyet(int Loai)
        {
            InitializeComponent();
            _loaiTruyen = Loai;
            if (_loaiTruyen == 1)
            {
                this.Text = "Đề nghị chuyển khoản Hợp đồng dịch vụ chưa duyệt";
            }
            else if (_loaiTruyen == 2 || _loaiTruyen == 3) // Lệnh chuyển tiền
            {
                this.Text = "Đề nghị chuyển khoản chưa duyệt";
            }
        }

        public frmUyNhiemChi_HDDV_ChuaDuyet(bool Loai)
        {
            InitializeComponent();
            _loai = Loai;
            //_maNganHang = _chungtu.MaNganHang;
            if (_loai == false)
            {
                this.Text = "Đề nghị chuyển khoản Hợp đồng dịch vụ chưa duyệt";
            }
            else
            {
                this.Text = "Đề nghị chuyển khoản Công Tác Viên chưa duyệt";
            }
        }

        private void frmChungTuNganHang_DeNghiChuaDuyet_Load_1(object sender, EventArgs e)
        {
            if (_loaiTruyen == 1)
            {
                _maNganHang = _chungtu.MaNganHang;
            }
            else if (_loaiTruyen == 2)
            {
                _maNganHang = _lenhChuyen.NganHangChuyen;
            }
            else if (_loaiTruyen == 3)
            {
                _maNganHang = _giayban.NganHangMua;
            }

            if (_loaiTruyen != 3)
                bdData.DataSource = ERP_Library.ChungTuNganHang_DeNghiList.GetDeNghiChuaDuyet_HoaDon(ERP_Library.CongTy_NganHang.GetCongTy_NganHang(_maNganHang).MaNganHang, _loai);
            else
                bdData.DataSource = ERP_Library.ChungTuNganHang_DeNghiList.GetDeNghiChuaDuyet_ChuaMuaNgoaiTe(ERP_Library.CongTy_NganHang.GetCongTy_NganHang(_maNganHang).MaNganHang, _loai);
            //filter những record đã add vào nhưng chưa lưu
            grdData.DisplayLayout.Bands[0].ColumnFilters["MaDeNghi"].ClearFilterConditions();
            if (_loaiTruyen == 1)
            {
                foreach (ERP_Library.ChungTuNganHang_DeNghi item in _chungtu.DeNghi)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["MaDeNghi"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.MaDeNghi);
                    }
                }
            }
            else if (_loaiTruyen == 2)
            {
                foreach (ERP_Library.ChiTietDeNghi_LenhChuyenTien item in _lenhChuyen.ChiTietDeNghi_LenhChuyenTienList)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["MaDeNghi"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.MaDeNghi);
                    }
                }
            }
            else if (_loaiTruyen == 3)
            {
                foreach (ERP_Library.DeNghi_GiayBanNgoaiTe item in _giayban.DeNghi_GiayBanNTList)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["MaDeNghi"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.MaDeNghi);
                    }
                }
            }

            foreach (ERP_Library.DatabaseNumberChild item in ERP_Library.DatabaseNumberList.GetDatabaseNumberList())
            {
                grdData.DisplayLayout.ValueLists["DatabaseNumber"].ValueListItems.Add(item.DatabaseNumber, item.Ten);
            }
        }
        #endregion

        #region Process
        #endregion

        #region Events
        private void btnDongY_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            //thêm những row chọn vào data chứng từ
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
            {
                if ((bool)item.Cells["Chon"].Value)
                {
                    ERP_Library.ChungTuNganHang_DeNghi i = (ERP_Library.ChungTuNganHang_DeNghi)item.ListObject;
                    if (_loaiTruyen == 1)
                    {
                        ERP_Library.ChungTuNganHang_DeNghi a = new ERP_Library.ChungTuNganHang_DeNghi(_chungtu.MaChungTu, i.MaDeNghi);
                        a.MaBoPhanQL = i.MaBoPhanQL;
                        a.TenBoPhan = i.TenBoPhan;
                        a.SoTien = i.SoTien;
                        a.TinhTrang = i.TinhTrang;
                        a.LyDo = i.LyDo;
                        _chungtu.DeNghi.Add(a);
                    }
                    else
                    {//Lệnh Chuyển Tiền ra nước ngoài
                        DeNghiChuyenKhoan dn = DeNghiChuyenKhoan.GetDeNghiChuyenKhoan(i.MaDeNghi);
                        if (_lyDo != string.Empty)
                            _lyDo += ", " + dn.LyDo;
                        else
                            _lyDo += dn.LyDo;

                        if (_loaiTruyen == 2)
                        {
                            foreach (DeNghiChuyenKhoan_DichVu dv in dn.DeNghiDichVuList)
                            {
                                ChiTietDeNghi_LenhChuyenTien ct = ChiTietDeNghi_LenhChuyenTien.NewChiTietDeNghi_LenhChuyenTien(dn.MaPhieu, dn.So, dv.SoTien, dv.LoaiTien);
                                _lenhChuyen.ChiTietDeNghi_LenhChuyenTienList.Add(ct);
                                _lenhChuyen.LoaiTien = dv.LoaiTien;
                                _maDoiTac = Convert.ToInt32(dv.MaDoiTac);
                                _nganHangNhan = dv.MaNganHang;

                                DeNghi_GiayBanNgoaiTeList _chitietList = DeNghi_GiayBanNgoaiTeList.GetDeNghi_GiayBanNgoaiTeList_ByDeNghiCK(dn.MaPhieu);
                                if (_chitietList.Count > 0)
                                {
                                    _tyGia = GiayBanNgoaiTe.GetGiayBanNgoaiTe(_chitietList[0].MaPhieu).TyGia;
                                }
                            }
                        }
                        else if (_loaiTruyen == 3)
                        {
                            foreach (DeNghiChuyenKhoan_DichVu dv in dn.DeNghiDichVuList)
                            {
                                DeNghi_GiayBanNgoaiTe ct = DeNghi_GiayBanNgoaiTe.NewDeNghi_GiayBanNgoaiTe(dn.MaPhieu, dn.So, dv.SoTien, dv.LoaiTien);
                                _giayban.DeNghi_GiayBanNTList.Add(ct);
                                _giayban.LoaiTien = dv.LoaiTien;
                                _maDoiTac = Convert.ToInt32(dv.MaDoiTac);
                                _nganHangNhan = dv.MaNganHang;
                                //_soTien += dv.SoTien;
                            }
                        }
                    }
                }
            }

            if (_loaiTruyen == 2)
            {
                _lenhChuyen.NoiDungThanhToan = _lyDo;
                _lenhChuyen.MaDoiTac = _maDoiTac;
                _lenhChuyen.NganHangNhan = _nganHangNhan;
                _lenhChuyen.SoTien = _soTien;
            }
            else if (_loaiTruyen == 3)
            {
                _giayban.SoKheUoc = _lyDo;
                _giayban.SoTien = _soTien;
            }

        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
            {
                if (!item.IsFilteredOut)
                {
                    item.Cells["Chon"].Value = true;
                    item.Update();
                }
            }
        }

        private void grdData_ClickCell(object sender, Infragistics.Win.UltraWinGrid.ClickCellEventArgs e)
        {
            if (grdData.ActiveCell.Column.Key == "Chon")
            {
                ChungTuNganHang_DeNghi obj = (ChungTuNganHang_DeNghi)grdData.ActiveRow.ListObject;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
                {
                    if ((bool)item.Cells["Chon"].Value && _loaiTruyen != 3)
                    {
                        string strChuoi = item.Cells["TenDoiTac"].Value.ToString();
                        if (!obj.TenDoiTac.Equals(strChuoi))
                        {
                            grdData.ActiveRow.Cells["Chon"].Value = false;
                            MessageBox.Show(this, "Đề nghị đang chọn không cùng đối tác với các đề nghị khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                }
            }
        }

        private void grdData_BeforeCellActivate(object sender, Infragistics.Win.UltraWinGrid.CancelableCellEventArgs e)
        {

        }
        #endregion
    }
}