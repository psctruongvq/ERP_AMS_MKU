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

namespace PSC_ERP
{
    //Thành
    public partial class frmChonDeNghiChuyenKhoan : Form
    {
        ChungTu_DeNghiChuyenKhoanChildList _chungTuList;
        DeNghiChuyenKhoanList _deNghiList;
        ChungTu _chungTu;

        public frmChonDeNghiChuyenKhoan()
        {
            InitializeComponent();
        }

        public frmChonDeNghiChuyenKhoan(ChungTu_DeNghiChuyenKhoanChildList chungtuList)
        {
            InitializeComponent();
            _chungTuList = chungtuList;
            KhoiTao();
        }

        public frmChonDeNghiChuyenKhoan(ChungTu ChungTu)
        {
            InitializeComponent();
            _chungTu = ChungTu;
            KhoiTao();
        }

        private void tlClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KhoiTao()
        {
            //Bao gồm cả: Giấy Báo có, Đề nghị chuyển khoản
            _deNghiList = DeNghiChuyenKhoanList.GetDeNghiChuyenKhoan_ChuaLapCT();
            bdData.DataSource = _deNghiList;

            foreach (ERP_Library.BoPhan item in ERP_Library.BoPhanList.GetBoPhanList())
            {
                grdData.DisplayLayout.ValueLists["BoPhan"].ValueListItems.Add(item.MaBoPhan, item.TenBoPhan);
            }
            foreach (ERP_Library.NhanVienComboListChild item in ERP_Library.NhanVienComboList.GetNhanVienAll())
            {
                grdData.DisplayLayout.ValueLists["NhanVien"].ValueListItems.Add(item.MaNhanVien, item.TenNhanVien);
            }
            foreach (ERP_Library.DatabaseNumberChild item in ERP_Library.DatabaseNumberList.GetDatabaseNumberList())
            {
                grdData.DisplayLayout.ValueLists["NoiNhan"].ValueListItems.Add(item.DatabaseNumber, item.Ten);
            }

            grdData.DisplayLayout.Bands[0].ColumnFilters["So"].ClearFilterConditions();
            if (_chungTu.LoaiChungTuDiKem == 1)
            {
                foreach (ChungTu_DeNghiChuyenKhoanChild item in _chungTu.ChungTuDeNghiList)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                    }
                }
            }
            else if(_chungTu.LoaiChungTuDiKem == 2)
            {
                foreach (ChungTu_GiayBaoCo item in _chungTu.ChungTuGiayBaoCoList)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                    }
                }
            }
            else if (_chungTu.LoaiChungTuDiKem == 3)
            {
                foreach (ChungTu_GiayBanNgoaiTeChild item in _chungTu.ChungTuGiayBanNgoaiTe)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                    }
                }
            }
            else if (_chungTu.LoaiChungTuDiKem == 4)
            {
                foreach (ChungTu_LenhChuyenTienNNChild item in _chungTu.ChungTuLenhChuyenTienList)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                    }
                }
            }
            else if (_chungTu.LoaiChungTuDiKem == 5 || _chungTu.LoaiChungTuDiKem == 8)
            {
                foreach (ChungTu_UNCChild item in _chungTu.ChungTuUyNhiemChiList)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                    }
                }
            }
            else if (_chungTu.LoaiChungTuDiKem == 6)
            {
                foreach (ChungTu_GiayBaoCo item in _chungTu.ChungTuGiayBaoCoList)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                    }
                }
            }
            else if (_chungTu.LoaiChungTuDiKem == 7)
            {
                foreach (ChungTu_GiayRutTienChild item in _chungTu.ChungTuGiayRutTienList)
                {
                    if (item.IsNew)
                    {
                        grdData.DisplayLayout.Bands[0].ColumnFilters["So"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.SoChungTu);
                    }
                }
            }

            //Set Màu chữ để phân biệt các loại
            if (grdData.Rows.Count > 0)
            {
                for (int i = 0; i < grdData.Rows.Count; i++)
                {
                    if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 2)
                    {
                        grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.Green;
                        //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Green;
                    }
                    else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 3)
                    {
                        grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.Blue;
                        //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
                    }
                    else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 4)
                    {
                        grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.Orange;
                        //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
                    }
                    else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 5)
                    {
                        grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.DarkGoldenrod;
                        //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
                    }
                    else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 6)
                    {
                        grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.LightSeaGreen;
                        //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
                    }
                    else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 7)
                    {
                        grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.DarkRed;
                        //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
                    }
                    else if (Convert.ToInt32(grdData.Rows[i].Cells["LoaiCT"].Value) == 8)
                    {
                        grdData.Rows[i].Cells["LoaiChungTu"].Appearance.ForeColor = Color.Brown;
                        //grdData.Rows[i].Cells["LoaiChungTu"].Appearance.BackColor = Color.Blue;
                    }
                }
            }
        }

        private void tlThem_Click(object sender, EventArgs e)
        {
            int iLoaiChungTu = 0;
            string strDienGiai = string.Empty;
            long lMaDoiTac = 0;
            _chungTu.SoTien = 0;
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

                switch(iLoaiChungTu)
                {
                    case 1: //Đề nghị chuyển khoản
                        foreach (DeNghiChuyenKhoan dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                //Khúc này để tính tổng số tiền đưa qua bảng kê, còn xài đừng có xóa
                                //ChiTietChungTuNganHangList chitiet = ChiTietChungTuNganHangList.GetChiTietChungTuNganHangList_ByDeNghiChuyenKhoan(dn.MaPhieu);
                                //foreach (ChiTietChungTuNganHang ct in chitiet)
                                //{
                                //    _chungTu.SoTien += (ct.SoTien * ct.TyGia);
                                //}
                                ChungTu_DeNghiChuyenKhoanChild chungTuDeNghi = ChungTu_DeNghiChuyenKhoanChild.NewChungTu_DeNghiChuyenKhoanChild(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.LoaiCT, dn.So, dn.LyDo);
                                _chungTu.ChungTuDeNghiList.Add(chungTuDeNghi);
                                _chungTu.SoTien += dn.ThanhTien;
                                
                                //Lưu diễn giải
                                GetDienGiai(dn,ref strDienGiai);

                                //Lấy Mã Đối Tác
                                if (dn.DeNghiDichVuList.Count > 0 && lMaDoiTac == 0)
                                {
                                    lMaDoiTac = dn.DeNghiDichVuList[0].MaDoiTac;
                                }                                
                            }
                        }
                        break;

                    case 2: //Giấy báo co
                        foreach (DeNghiChuyenKhoan dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                ChungTu_GiayBaoCo chungTu_GBC = ChungTu_GiayBaoCo.NewChungTu_GiayBaoCo(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.LoaiCT, dn.So, dn.LyDo);
                                _chungTu.ChungTuGiayBaoCoList.Add(chungTu_GBC);
                                _chungTu.SoTien += dn.ThanhTien;//Lấy Mã Đối Tác

                                //lMaDoiTac = GiayBaoCo.GetGiayBaoCo(dn.MaPhieu).MaNganHang; Sửa lại thành đối tác từ từ làm

                                lMaDoiTac = GiayBaoCo.GetGiayBaoCo((int)dn.MaPhieu).MaDoiTac;
                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);  
                            }
                        }
                        break;

                    case 3: //Giấy bán ngoại tệ
                        foreach (DeNghiChuyenKhoan dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                ChungTu_GiayBanNgoaiTeChild chungTu_GBNT = ChungTu_GiayBanNgoaiTeChild.NewChungTu_GiayBanNgoaiTeChild(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.LoaiCT, dn.So, dn.LyDo);
                                _chungTu.ChungTuGiayBanNgoaiTe.Add(chungTu_GBNT);
                                _chungTu.SoTien += dn.ThanhTien;

                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);
                            }
                        }
                        break;

                    case 4: //Lệnh chuyển tiền
                        foreach (DeNghiChuyenKhoan dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                ChungTu_LenhChuyenTienNNChild chungTu_LenhCT = ChungTu_LenhChuyenTienNNChild.NewChungTu_LenhChuyenTienNNChild(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.LoaiCT, dn.So, dn.LyDo);
                                _chungTu.ChungTuLenhChuyenTienList.Add(chungTu_LenhCT);
                                _chungTu.SoTien += dn.ThanhTien;
                                //_chungTu.Tien.MaLoaiTien = LenhChuyenTienNuocNgoai.GetLenhChuyenTienNuocNgoai(chungTu_LenhCT.MaLenhCT).LoaiTien;

                                lMaDoiTac = LenhChuyenTienNuocNgoai.GetLenhChuyenTienNuocNgoai(dn.MaPhieu).MaDoiTac;
                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);
                            }
                        }
                        break;

                    case 5 :
                    case 8 : //Uy Nhiệm Chi
                        foreach (DeNghiChuyenKhoan dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                ChungTu_UNCChild chungtu_UyNhiemChi = ChungTu_UNCChild.NewChungTu_GiayRutTienChild(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.LoaiCT, dn.So, dn.LyDo);
                                _chungTu.ChungTuUyNhiemChiList.Add(chungtu_UyNhiemChi);
                                _chungTu.SoTien += dn.ThanhTien;

                                GetDienGiai(dn, ref strDienGiai);
                            }
                        }
                        break;

                    case 6: //Phí ngân hàng
                        foreach (DeNghiChuyenKhoan dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                ChungTu_GiayBaoCo chungTu_GBC = ChungTu_GiayBaoCo.NewChungTu_GiayBaoCo(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.LoaiCT, dn.So, dn.LyDo);
                                _chungTu.ChungTuGiayBaoCoList.Add(chungTu_GBC);
                                _chungTu.SoTien += dn.ThanhTien;//Lấy Mã Đối Tác

                                //lMaDoiTac = GiayBaoCo.GetGiayBaoCo(dn.MaPhieu).MaNganHang; Sửa lại thành đối tác từ từ làm

                                lMaDoiTac = GiayBaoCo.GetGiayBaoCo((int)dn.MaPhieu).MaDoiTac;
                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);
                            }
                        }
                        break;

                    case 7: //Giấy rút tiền
                        foreach (DeNghiChuyenKhoan dn in _deNghiList)
                        {
                            if (dn.Chon)
                            {
                                ChungTu_GiayRutTienChild Chungtu_GRT = ChungTu_GiayRutTienChild.NewChungTu_GiayRutTienChild(Convert.ToInt32(dn.MaPhieu), dn.ThanhTien, dn.LoaiCT, dn.So, dn.LyDo);
                                _chungTu.ChungTuGiayRutTienList.Add(Chungtu_GRT);
                                _chungTu.SoTien += dn.ThanhTien;//Lấy Mã Đối Tác

                                //Lưu diễn giải
                                GetDienGiai(dn, ref strDienGiai);
                            }
                        }
                        break;

                    default: break;
                }

                _chungTu.DienGiai = strDienGiai;
                _chungTu.DoiTuong = lMaDoiTac;

                this.Close();
            }
            catch (Exception)
            {
                
                throw;

            }
        }

        private void GetDienGiai(DeNghiChuyenKhoan dn, ref string strDienGiai)
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
        /// 3: giấy bán ngoại tệ
        /// 4: Lệnh chuyển tiền
        /// </summary>
        /// <param name="deNghiChuyenKhoanList"></param>
        /// <param name="iLoaiChungTu"></param>
        /// <returns></returns>
        private bool KiemTraDongNhat(DeNghiChuyenKhoanList deNghiChuyenKhoanList, ref int iLoaiChungTu)
        {
            foreach (DeNghiChuyenKhoan dn in _deNghiList)
            {
                if (dn.Chon)
                {
                    if (iLoaiChungTu == 0)
                    {
                        iLoaiChungTu = dn.LoaiCT;
                    }
                    else
                    {
                        if (iLoaiChungTu != dn.LoaiCT)
                            return false;
                    }
                }
            }
            return true;
        }

        private bool KiemTraDongNhat_Ngay(DeNghiChuyenKhoanList deNghiChuyenKhoanList, ref DateTime _ngay)
        {
            DateTime? Ngay = null;
            foreach (DeNghiChuyenKhoan dn in _deNghiList)
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
            e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
            e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
        }
    }
}
