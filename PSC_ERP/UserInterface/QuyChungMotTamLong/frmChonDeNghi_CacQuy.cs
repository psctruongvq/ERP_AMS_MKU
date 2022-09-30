using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.ThanhToan;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace PSC_ERP
{
    public partial class frmChonDeNghi_CacQuy : Form
    {
        ChungTu_DeNghiChuyenKhoanNgoaiList _chungTuList;
        DeNghiChuyenKhoan_ChungTuNgoaiList _deNghiList;
        ChungTu_CacLoaiQuy _chungTu;
        CongDoan_ChungTu _chungTu_CongDoan;
        int _loaiDeNghi = 1;
        

        public frmChonDeNghi_CacQuy()
        {
            InitializeComponent();
        }

        public frmChonDeNghi_CacQuy(ChungTu_DeNghiChuyenKhoanNgoaiList chungtuList)
        {
            InitializeComponent();
            _chungTuList = chungtuList;
            KhoiTao();
        }

        public frmChonDeNghi_CacQuy(object ChungTu, int LoaiDeNghi)
        {
            InitializeComponent();
            if (ChungTu is ChungTu_CacLoaiQuy)
                _chungTu = (ChungTu_CacLoaiQuy)ChungTu;
            else if (ChungTu is CongDoan_ChungTu)
                _chungTu_CongDoan = (CongDoan_ChungTu)ChungTu;
            _loaiDeNghi = LoaiDeNghi;
            if (_loaiDeNghi == 1)
            {
                this.Text += " Các quỹ";
            }
            else
            {
                this.Text += " Công đoàn";
            }
            KhoiTao();
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhoiTao()
        {
            //Bao gồm cả: Giấy Báo có, Đề nghị chuyển khoản
            if (_loaiDeNghi == 1)
                _deNghiList = DeNghiChuyenKhoan_ChungTuNgoaiList.GetDeNghiChuyenKhoan_ChungTuNgoaiList_ChuaLapCT(_loaiDeNghi);
            else
                _deNghiList = DeNghiChuyenKhoan_ChungTuNgoaiList.GetDeNghiChuyenKhoan_ChungTuNgoaiList_ChuaLapCT_CongDoan(_loaiDeNghi);
            bdData.DataSource = _deNghiList;

            //Load Loại tiền
            foreach (ERP_Library.LoaiTien item in ERP_Library.LoaiTienList.GetLoaiTienList())
            {
                grdData.DisplayLayout.ValueLists["LoaiTien"].ValueListItems.Add(item.MaLoaiTien, item.MaLoaiQuanLy);
            }

            grdData.DisplayLayout.Bands[0].ColumnFilters["So"].ClearFilterConditions();

            //Chứng Từ Các Quỹ
            if (_loaiDeNghi == 1)
            {
                if (_chungTu.LoaiChungTuDiKem == 1)
                {
                    foreach (ChungTu_DeNghiChuyenKhoanNgoai item in _chungTu.ChungTu_DeNghiNgoaiList)
                    {
                        if (item.IsNew)
                        {
                            grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                        }
                    }
                }
                else if (_chungTu.LoaiChungTuDiKem == 2 || _chungTu.LoaiChungTuDiKem == 3)
                {
                    foreach (ChungTu_GiayBaoCo_CacQuy item in _chungTu.ChungTu_GiayBCList)
                    {
                        if (item.IsNew)
                        {
                            grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                        }
                    }
                }
                else if (_chungTu.LoaiChungTuDiKem == 4)
                {
                    foreach (ChungTu_GiayRutTien_CacQuy item in _chungTu.ChungTu_GiayRTList)
                    {
                        if (item.IsNew)
                        {
                            grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                        }
                    }
                }
            }
            else if (_loaiDeNghi == 2)
            {
                if (_chungTu_CongDoan.LoaiChungTuDiKem == 1)
                {
                    foreach (CongDoan_DeNghiChuyenKhoan item in _chungTu_CongDoan.CongDoan_DeNghiList)
                    {
                        if (item.IsNew)
                        {
                            grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                        }
                    }
                }
                else if (_chungTu_CongDoan.LoaiChungTuDiKem == 2 || _chungTu_CongDoan.LoaiChungTuDiKem == 3)
                {
                    foreach (CongDoan_GiayBaoCo item in _chungTu_CongDoan.CongDoan_GiayBCList)
                    {
                        if (item.IsNew)
                        {
                            grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                        }
                    }
                }
                else if (_chungTu_CongDoan.LoaiChungTuDiKem == 4)
                {
                    foreach (CongDoan_GiayRutTien item in _chungTu_CongDoan.CongDoan_GiayRTList)
                    {
                        if (item.IsNew)
                        {
                            grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                        }
                    }
                }
            }

            //Set Màu chữ để phân biệt các loại
            if (grdData.Rows.Count > 0)
            {
                for (int i = 0; i < grdData.Rows.Count; i++)
                {
                    grdData.Rows[i].Cells["TenLoaiChungTu"].Appearance.FontData.Bold = DefaultableBoolean.True;

                    if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiChungTu"].Value) == 1)
                    {
                        grdData.Rows[i].Cells["TenLoaiChungTu"].Appearance.ForeColor = Color.Green;
                    }
                    else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiChungTu"].Value) == 2)
                    {
                        grdData.Rows[i].Cells["TenLoaiChungTu"].Appearance.ForeColor = Color.Blue;
                    }
                    else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiChungTu"].Value) == 3)
                    {
                        grdData.Rows[i].Cells["TenLoaiChungTu"].Appearance.ForeColor = Color.Red;
                    }
                    else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiChungTu"].Value) == 4)
                    {
                        grdData.Rows[i].Cells["TenLoaiChungTu"].Appearance.ForeColor = Color.Brown;
                    }
                }
            }
        }

        private void ChonDeNghi_CacQuy()
        {
            int iLoaiChungTu = 0;
            string strDienGiai = string.Empty;
            long lMaDoiTac = 0;
            try
            {
                //Nếu Chứng Từ Đã Được set loại chứng từ
                if (_chungTu.LoaiChungTuDiKem != 0)
                {
                    iLoaiChungTu = _chungTu.LoaiChungTuDiKem;
                }

                //Cập nhật dữ liệu
                grdData.UpdateData();
                _deNghiList.ApplyEdit();
                bdData.EndEdit();

                //Kiểm tra tính thống nhất của dữ liệu đang được chọn
                if (!KiemTraDongNhat(_deNghiList, ref iLoaiChungTu))
                {
                    MessageBox.Show(this, "Chỉ chọn các chứng từ kèm theo của cùng một loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Kiểm tra tính thống nhất của ngày
                DateTime ngayLap = _chungTu.NgayLap;
                if (!KiemTraDongNhat_Ngay(_deNghiList, ref ngayLap))
                {
                    MessageBox.Show(this, "Ngày xác nhận của các chứng từ không giống nhau.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                _chungTu.NgayLap = ngayLap;
                _chungTu.LoaiChungTuDiKem = iLoaiChungTu;
                _chungTu.SoTien = 0;
                strDienGiai = _chungTu.DienGiai;

                switch (iLoaiChungTu)
                {
                    case 1: //Đề nghị chuyển khoản
                        foreach (DeNghiChuyenKhoan_ChungTuNgoai dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                ChungTu_DeNghiChuyenKhoanNgoai chungTuDeNghi = ChungTu_DeNghiChuyenKhoanNgoai.NewChungTu_DeNghiChuyenKhoanNgoai(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.So, dn.LyDo);
                                _chungTu.ChungTu_DeNghiNgoaiList.Add(chungTuDeNghi);

                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);

                                //Lấy Mã Đối Tác
                                if (lMaDoiTac == 0)
                                {
                                    lMaDoiTac = dn.MaDoiTac;
                                }
                            }
                        }

                        foreach (ChungTu_DeNghiChuyenKhoanNgoai item in _chungTu.ChungTu_DeNghiNgoaiList)
                        {
                            _chungTu.SoTien += item.SoTien;
                        }
                        break;

                    case 2: //Giấy báo co
                    case 3: //Phí ngân hàng
                        foreach (DeNghiChuyenKhoan_ChungTuNgoai dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                ChungTu_GiayBaoCo_CacQuy chungTu_GBC = ChungTu_GiayBaoCo_CacQuy.NewChungTu_GiayBaoCo_CacQuy(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.So, dn.LyDo);
                                _chungTu.ChungTu_GiayBCList.Add(chungTu_GBC);
                                //Lấy Mã Đối Tác

                                //lMaDoiTac = GiayBaoCo.GetGiayBaoCo(dn.MaPhieu).MaNganHang; Sửa lại thành đối tác từ từ làm

                                lMaDoiTac = GiayBaoCo_CacQuy.GetGiayBaoCo_CacQuy((int)dn.MaPhieu).MaDoiTac;
                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);
                            }
                        }

                        foreach (ChungTu_GiayBaoCo_CacQuy item in _chungTu.ChungTu_GiayBCList)
                        {
                            _chungTu.SoTien += item.SoTien;
                        }
                        break;

                    case 4: //Giấy rút tiền
                        foreach (DeNghiChuyenKhoan_ChungTuNgoai dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                ChungTu_GiayRutTien_CacQuy Chungtu_GRT = ChungTu_GiayRutTien_CacQuy.NewChungTu_GiayRutTien_CacQuy(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.So, dn.LyDo);
                                _chungTu.ChungTu_GiayRTList.Add(Chungtu_GRT);

                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);
                            }
                        }

                        foreach (ChungTu_GiayRutTien_CacQuy item in _chungTu.ChungTu_GiayRTList)
                        {
                            _chungTu.SoTien += item.SoTien;
                        }
                        break;

                    default: break;
                }

                _chungTu.DienGiai = strDienGiai;
                _chungTu.MaDoiTuong = lMaDoiTac;

                this.Close();
            }
            catch (Exception)
            {

                throw;

            }
        }

        private void ChonDeNghi_CongDoan()
        {
            int iLoaiChungTu = 0;
            string strDienGiai = string.Empty;
            long lMaDoiTac = 0;
            try
            {
                //Nếu Chứng Từ Đã Được set loại chứng từ
                if (_chungTu_CongDoan.LoaiChungTuDiKem != 0)
                {
                    iLoaiChungTu = _chungTu_CongDoan.LoaiChungTuDiKem;
                }

                //Cập nhật dữ liệu
                grdData.UpdateData();
                _deNghiList.ApplyEdit();
                bdData.EndEdit();

                //Kiểm tra tính thống nhất của dữ liệu đang được chọn
                if (!KiemTraDongNhat(_deNghiList, ref iLoaiChungTu))
                {
                    MessageBox.Show(this, "Chỉ chọn các chứng từ kèm theo của cùng một loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //Kiểm tra tính thống nhất của ngày
                DateTime ngayLap = _chungTu_CongDoan.NgayLap;
                if (!KiemTraDongNhat_Ngay(_deNghiList, ref ngayLap))
                {
                    MessageBox.Show(this, "Ngày xác nhận của các chứng từ không giống nhau.", "Lưu ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                _chungTu_CongDoan.NgayLap = ngayLap;
                _chungTu_CongDoan.LoaiChungTuDiKem = iLoaiChungTu;
                _chungTu_CongDoan.SoTien = 0;
                strDienGiai = _chungTu_CongDoan.DienGiai;

                switch (iLoaiChungTu)
                {
                    case 1: //Đề nghị chuyển khoản
                        foreach (DeNghiChuyenKhoan_ChungTuNgoai dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                CongDoan_DeNghiChuyenKhoan congDoanDeNghi = CongDoan_DeNghiChuyenKhoan.NewCongDoan_DeNghiChuyenKhoan(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.So, dn.LyDo);
                                _chungTu_CongDoan.CongDoan_DeNghiList.Add(congDoanDeNghi);

                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);

                                //Lấy Mã Đối Tác
                                if (lMaDoiTac == 0)
                                {
                                    lMaDoiTac = dn.MaDoiTac;
                                }
                            }
                        }

                        foreach (CongDoan_DeNghiChuyenKhoan item in _chungTu_CongDoan.CongDoan_DeNghiList)
                        {
                            _chungTu_CongDoan.SoTien += item.SoTien;
                        }
                        break;

                    case 2: //Giấy báo co
                    case 3: //Phí ngân hàng
                        foreach (DeNghiChuyenKhoan_ChungTuNgoai dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                CongDoan_GiayBaoCo CongDoan_GBC = CongDoan_GiayBaoCo.NewCongDoan_GiayBaoCo(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.So, dn.LyDo);
                                _chungTu_CongDoan.CongDoan_GiayBCList.Add(CongDoan_GBC);
                                //Lấy Mã Đối Tác
                                
                                lMaDoiTac = GiayBaoCo_CacQuy.GetGiayBaoCo_CacQuy((int)dn.MaPhieu).MaDoiTac;
                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);
                            }
                        }

                        foreach (CongDoan_GiayBaoCo item in _chungTu_CongDoan.CongDoan_GiayBCList)
                        {
                            _chungTu_CongDoan.SoTien += item.SoTien;
                        }
                        break;

                    case 4: //Giấy rút tiền
                        foreach (DeNghiChuyenKhoan_ChungTuNgoai dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                CongDoan_GiayRutTien CongDoan_GRT = CongDoan_GiayRutTien.NewCongDoan_GiayRutTien(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.So, dn.LyDo);
                                _chungTu_CongDoan.CongDoan_GiayRTList.Add(CongDoan_GRT);

                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);
                            }
                        }

                        foreach (CongDoan_GiayRutTien item in _chungTu_CongDoan.CongDoan_GiayRTList)
                        {
                            _chungTu_CongDoan.SoTien += item.SoTien;
                        }
                        break;

                    default: break;
                }

                _chungTu_CongDoan.DienGiai = strDienGiai;
                _chungTu_CongDoan.MaDoiTuong = lMaDoiTac;

                this.Close();
            }
            catch (Exception)
            {

                throw;

            }
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            if (_loaiDeNghi == 1)
                ChonDeNghi_CacQuy();
            else
                ChonDeNghi_CongDoan();
        }

        private void GetDienGiai(DeNghiChuyenKhoan_ChungTuNgoai dn, ref string strDienGiai)
        {
            //Lưu diễn giải
            if (strDienGiai != string.Empty)
            {
                strDienGiai += ", " + dn.LyDo;
            }
            else
            {
                strDienGiai += dn.LyDo;
            }
        }

        /// <summary>
        /// Kiểm tra các đối tượng được chọn có cùng 1 kiểu hay không
        /// 1: Đề nghị chuyển khoản
        /// 2: Giấy báo có
        /// 3: Phí ngân hàng
        /// 4: Giấy rút tiền
        /// </summary>
        /// <param name="deNghiChuyenKhoanList"></param>
        /// <param name="iLoaiChungTu"></param>
        /// <returns></returns>
        private bool KiemTraDongNhat(DeNghiChuyenKhoan_ChungTuNgoaiList deNghiChuyenKhoanList, ref int iLoaiChungTu)
        {
            foreach (DeNghiChuyenKhoan_ChungTuNgoai dn in _deNghiList)
            {
                if (dn.Chon)
                {
                    if (iLoaiChungTu == 0)
                    {
                        iLoaiChungTu = dn.LoaiChungTu;
                    }
                    else
                    {
                        if (iLoaiChungTu != dn.LoaiChungTu)
                            return false;
                    }
                }
            }
            return true;
        }

        private bool KiemTraDongNhat_Ngay(DeNghiChuyenKhoan_ChungTuNgoaiList deNghiChuyenKhoanList, ref DateTime _ngay)
        {
            DateTime? Ngay = null;
            foreach (DeNghiChuyenKhoan_ChungTuNgoai dn in _deNghiList)
            {
                if (dn.Chon)
                {
                    if (Ngay == null)
                    {
                        if (dn.NgayXacNhan != null)
                            Ngay = dn.NgayXacNhan;
                    }
                    else
                    {
                        if (Ngay != dn.NgayXacNhan && dn.NgayXacNhan != null)
                        {
                            _ngay = (DateTime)dn.NgayXacNhan;
                            return false;
                        }
                    }
                }
            }
            if (Ngay == null)
            {
                _ngay = DateTime.Today;
            }
            else
            {
                _ngay = (DateTime)Ngay;
            }
            return true;
        }

        private void grdData_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grdData.DisplayLayout.Bands[0],
            new string[12] { "Chon", "TenLoaiChungTu", "NgayXacNhan", "So", "Ngay", "LyDo", "SoTien", "LoaiTien", "TyGia", "TenDoiTac", "SoTaiKhoan", "SoTaiKhoanChuyen"},
            new string[12] { "Chọn", "Loại chứng từ", "Ngày xác nhận", "Số", "Ngày lập", "Lý do", "Số tiền", "Loại tiền", "Tỷ giá", "Đối tác", "Tài Khoản", "Tài khoản chuyển" },
            new int[12] { 40, 130, 100, 120, 70, 200, 110, 80, 80, 120, 100, 100 },
            new Control[12] { null, null, null, null, null, null, null, null, null, null, null, null },
            new KieuDuLieu[12] { KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.TienLe, KieuDuLieu.Null, KieuDuLieu.Tien, KieuDuLieu.Null, KieuDuLieu.Null, KieuDuLieu.Null },
            new bool[12] { true, false, false, false, false, false, false, false, false, false, false, false });
            //màu và font chữ
            foreach (UltraGridColumn col in this.grdData.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.White;//x =  //= System.Drawing.w;//RoyalBlue
            }
            //màu nền
            //this.grdData.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
            //this.grdData.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;

            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
        }
    }
}
