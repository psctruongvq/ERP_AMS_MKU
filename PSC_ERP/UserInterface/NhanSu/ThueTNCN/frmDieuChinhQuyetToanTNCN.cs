using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Shared;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;

namespace PSC_ERP
{
    public partial class frmDieuChinhQuyetToanTNCN : Form
    {
        private BangLuongQuyetToanThueList _bangluong;
        private BangKeThueTNCNChild _data;
        private DieuChinhQuyetToanThueList _dieuchinh;
        //private BindingSource bdBangLuong;
        //private BindingSource bdDieuChinh;
        public int Loai;
        private bool OK = false;

        public frmDieuChinhQuyetToanTNCN()
        {
            InitializeComponent();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            this.OK = true;
            try
            {
                this.grdDieuChinh.UpdateData();
                this._dieuchinh.Save();
            }
            catch (Exception exception)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(exception, this._dieuchinh);
                return;
            }
            decimal num = 0M;
            foreach (BangLuongQuyetToanThueChild child in this._bangluong)
            {
                if (this.Loai == 12)
                {
                    num = this._bangluong.Count;
                }
                else
                {
                    num += child.SoTien;
                }
            }
            foreach (DieuChinhQuyetToanThueChild child2 in this._dieuchinh)
            {
                num += child2.SoTien;
            }
            switch (this.Loai)
            {
                case 1:
                    this._data.ThuNhapChiuThue = num;
                    break;

                case 2:
                    this._data.SoNguoiPhuThuoc = Convert.ToInt32(num);
                    break;

                case 3:
                    this._data.SoThangGiamTru = Convert.ToInt32(num);
                    break;

                case 4:
                    this._data.TuThienNhanDao = num;
                    break;

                case 5:
                    this._data.BaoHiemBatBuoc = num;
                    break;

                case 6:
                    this._data.TNCTGiamThue = num;
                    break;

                case 7:
                    this._data.ThueDaKhauTru = num;
                    break;

                case 8:
                    this._data.ThueNLDDaNop = num;
                    break;
                case 9:// bhxh
                    this._data.BHXH = num;
                    break;
                case 10://bhyt
                    this._data.BHYT = num;
                    break;
                case 11:// bhtn
                    this._data.BHTN = num;
                    break;
                case 12:// bht
                    this._data.SoThang = Convert.ToInt32(num);
                    break;
                case 13:// tông thu nhap
                    this._data.TongThuNhap = Convert.ToDecimal(num);
                    break;
            }
            base.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OK = false;
            base.Close();
        }

        private void grdDieuChinh_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn Có Muốn Xóa Dữ Liệu Này Không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void grdDieuChinh_BeforeRowUpdate(object sender, Infragistics.Win.UltraWinGrid.CancelableRowEventArgs e)
        {
            e.Row.Cells["MaNhanVien"].Value = this._data.MaNhanVien;
            e.Row.Cells["Nam"].Value = this._data.Nam;
            e.Row.Cells["Loai"].Value = this.Loai;
        }

        public bool ShowDieuChinh(BangKeThueTNCNChild item, int loai)
        {
            this._data = item;
            this.Loai = loai;
            this.lblTenBoPhan.Text = this._data.TenBoPhan;
            this.lblTenNhanVien.Text = this._data.HoTen;
            switch (this.Loai)
            {
                case 1:
                    this.lblLoai.Text = "Thu nhập chịu thuế";
                    break;

                case 2:
                    this.lblLoai.Text = "Số người phụ thuộc";
                    break;

                case 3:
                    this.lblLoai.Text = "Tổng số tháng giảm trừ";
                    break;

                case 4:
                    this.lblLoai.Text = "Từ thiện, nhân đạo, khuyến học";
                    break;

                case 5:
                    this.lblLoai.Text = "Bảo hiểm bắt buộc";
                    break;

                case 6:
                    this.lblLoai.Text = "TNCT lăm căn cứ tính giảm thuế";
                    break;

                case 7:
                    this.lblLoai.Text = "Số thuế TNCN được khấu trừ";
                    break;

                case 8:
                    this.lblLoai.Text = "Thuế NLD đã nộp";
                    break;
                case 9:
                    this.lblLoai.Text = " BHXH ";
                    break;
                case 10:
                    this.lblLoai.Text = " BHYT ";
                    break;
                case 11:
                    this.lblLoai.Text = " BHTN ";
                    break;
                case 12:
                    this.lblLoai.Text = " Số Tháng ";
                    break;
                case 13:
                    this.lblLoai.Text = " Tổng Thu Nhập ";
                    break;
            }
            this._dieuchinh = DieuChinhQuyetToanThueList.GetDieuChinhQuyetToanThueList(this._data.MaNhanVien, this.Loai, this._data.Nam);
            this.bdDieuChinh.DataSource = this._dieuchinh;
            this._bangluong = BangLuongQuyetToanThueList.GetBangLuongQuyetToanThueList(this._data.MaNhanVien, this.Loai, this._data.Nam);
            this.bdBangLuong.DataSource = this._bangluong;
            base.ShowDialog();
            return this.OK;
        }

        private void grdDieuChinh_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung t = new HamDungChung();
            t.ultragrdEmail_InitializeLayout(sender, e);

            foreach (UltraGridColumn col in this.grdDieuChinh.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                //col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
        }

        private void grdBangLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdBangLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
               // col.Hidden = true;
                if (col.DataType.ToString() == "System.DateTime")
                {
                    col.Format = "dd/MM/yyyy";
                }
                if (col.DataType.ToString() == "System.Decimal")
                {
                    col.Format = "#,###.##";
                    col.CellAppearance.TextHAlign = HAlign.Right;
                }
            }
        }
    }
}
