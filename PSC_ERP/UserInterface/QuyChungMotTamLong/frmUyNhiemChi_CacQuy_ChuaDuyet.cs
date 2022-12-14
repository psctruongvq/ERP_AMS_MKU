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
    public partial class frmUyNhiemChi_CacQuy_ChuaDuyet : Form
    {
        #region Properties
        internal UyNhiemChi_CacQuy _data;

        private int _loaiDeNghi = 0;  

        private string _lyDo = string.Empty;
        private decimal _soTien = 0;
        public decimal _tyGia = 0;
        #endregion

        #region Loads
        public frmUyNhiemChi_CacQuy_ChuaDuyet()
        {
            InitializeComponent();
        }

        public frmUyNhiemChi_CacQuy_ChuaDuyet(int Loai)
        {
            InitializeComponent();
            _loaiDeNghi = Loai;
            if (_loaiDeNghi == 1)
            {
                this.Text = "Đề nghị chuyển khoản Các Quỹ chưa duyệt";
            }
            else
            {
                this.Text = "Đề nghị chuyển khoản Công Đoàn chưa duyệt";
            }
        }

        private void frmChungTuNganHang_DeNghiChuaDuyet_Load_1(object sender, EventArgs e)
        {
            bdData.DataSource = DeNghiChuyenKhoan_ChungTuNgoaiList.GetDeNghiChuyenKhoan_ChungTuNgoaiList_ChuaDuyet(_loaiDeNghi);
            
            //filter những record đã add vào nhưng chưa lưu
            grdData.DisplayLayout.Bands[0].ColumnFilters["MaPhieu"].ClearFilterConditions();
            foreach (DeNghi_UyNhiemChi_CacQuy item in _data.DeNghi_UNC_CacQuyList)
            {
                if (item.IsNew)
                {
                    grdData.DisplayLayout.Bands[0].ColumnFilters["MaDeNghi"].FilterConditions.Add(Infragistics.Win.UltraWinGrid.FilterComparisionOperator.NotEquals, item.MaDeNghi);
                }
            }

            foreach (LoaiTien item in LoaiTienList.GetLoaiTienList())
            {
                grdData.DisplayLayout.ValueLists["LoaiTien"].ValueListItems.Add(item.MaLoaiTien, item.MaLoaiQuanLy);
            }
            foreach (DoiTac item in DoiTacList.GetDoiTacListByTen(0))
            {
                grdData.DisplayLayout.ValueLists["DoiTac"].ValueListItems.Add(item.MaDoiTac, item.TenDoiTac);
            }
        }
        #endregion

        #region Events
        private void btnDongY_Click(object sender, EventArgs e)
        {
            grdData.UpdateData();
            //thêm những row chọn vào data chứng từ
            long maDoiTac = 0;
            int TaiKhoan = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
            {
                if ((bool)item.Cells["Chon"].Value)
                {
                    DeNghiChuyenKhoan_ChungTuNgoai dn = (DeNghiChuyenKhoan_ChungTuNgoai)item.ListObject;

                    //Lấy diễn giải
                    if (_lyDo != string.Empty)
                        _lyDo += ", " + dn.LyDo;
                    else
                        _lyDo += dn.LyDo;

                    maDoiTac = dn.MaDoiTac;
                    TaiKhoan = dn.MaTaiKhoanNhan;

                    DeNghi_UyNhiemChi_CacQuy denghi_UNC = DeNghi_UyNhiemChi_CacQuy.NewDeNghi_UyNhiemChi_CacQuy(dn.MaPhieu, dn.So, dn.SoTien, dn.LoaiTien);
                    _data.DeNghi_UNC_CacQuyList.Add(denghi_UNC);
                }
            }

            _data.TenDoiTac = DoiTac.GetDoiTac(maDoiTac).TenDoiTac;
            _data.SoTaiKhoan = TK_NganHang.GetSoTaiKhoan((int)maDoiTac, TaiKhoan); 
            _data.DienGiai = _lyDo;
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
                DeNghiChuyenKhoan_ChungTuNgoai obj = (DeNghiChuyenKhoan_ChungTuNgoai)grdData.ActiveRow.ListObject;
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
                {
                    if ((bool)item.Cells["Chon"].Value)
                    {
                        long MaDoiTac = Convert.ToInt64(item.Cells["madoitac"].Value);
                        if (!obj.MaDoiTac.Equals(MaDoiTac))
                        {
                            grdData.ActiveRow.Cells["Chon"].Value = false;
                            MessageBox.Show(this, "Đề nghị đang chọn không cùng đối tác với các đề nghị khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                    }
                }
            }
        }
        #endregion
    }
}