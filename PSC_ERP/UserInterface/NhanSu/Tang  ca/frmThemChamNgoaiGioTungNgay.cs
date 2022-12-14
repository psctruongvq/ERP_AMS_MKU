using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmThemChamNgoaiGioTungNgay : Form
    {
        private bool OK = false;
        private ERP_Library.NhanVienComboList _Data;
        private ERP_Library.BoPhan _BoPhan;
        private ERP_Library.KyTinhLuong _KyLuong;
        private ERP_Library.HinhThucTangCaChild _HinhThuc;

        public frmThemChamNgoaiGioTungNgay()
        {
            InitializeComponent();
        }

        private void frmChamTangCaHangLoat_Load(object sender, EventArgs e)
        {
            bdHinhThuc.DataSource = ERP_Library.LoaiTangCaList.GetLoaiTangCaList();
            cmbKyCham.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbKyCham.Value = _KyLuong.MaKy;
        }

        public bool ChamNgoaiGio(ERP_Library.KyTinhLuong KyLuong, ERP_Library.BoPhan BoPhan, ERP_Library.HinhThucTangCaChild HinhThuc)
        {
            _BoPhan = BoPhan;
            _KyLuong = KyLuong;
            _HinhThuc = HinhThuc;
            radBoPhan.Text += " " + _BoPhan.TenBoPhan;
            radNhanVien.Text += " " + _BoPhan.TenBoPhan;
            this.ShowDialog();
            return OK;
        }

        private void radNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (_Data == null && radNhanVien.Checked)
            {
                _Data = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhan(_BoPhan.MaBoPhan);
                grdData.DataSource = _Data;
            }
            grdData.Enabled = radNhanVien.Checked;
        }

        private void btnKhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (cmbKyCham.Value == null)
            {
                MessageBox.Show("Chưa chọn kỳ chấm ngoài giờ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDecimal(txtSoGio.Value) == 0)
            {
                MessageBox.Show("Chưa nhập thời gian làm ngoài giờ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ERP_Library.KyTinhLuong kycham = (ERP_Library.KyTinhLuong)cmbKyCham.SelectedItem.ListObject;
            if (txtTuNgay.DateTime < kycham.NgayBatDau || txtTuNgay.DateTime > kycham.NgayKetThuc)
            {
                MessageBox.Show("Ngày bắt đầu chấm ngoài giờ không hợp lệ trong khoảng thời gian của kỳ chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtDenNgay.DateTime < kycham.NgayBatDau || txtDenNgay.DateTime > kycham.NgayKetThuc)
            {
                MessageBox.Show("Ngày kết thúc chấm ngoài giờ không hợp lệ trong khoảng thời gian của kỳ chấm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OK = true;
            this.Close();
        }

        /// <summary>
        /// Cập nhật (thêm, sửa) dữ liệu chấm ngoài giờ vào object data
        /// </summary>
        public void CapNhatDuLieu(ERP_Library.NgoaiGioTungNgay_TongHopList _List)
        {
            //lấy danh sách mã nhân viên cần cập nhật
            object lst = null;
            if (radBoPhan.Checked)
                lst = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhan(_BoPhan.MaBoPhan);
            else
            {
                lst = new List<ERP_Library.NhanVienComboListChild>();
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow item in grdData.Rows)
                    if ((bool)item.Cells["Chon"].Value)
                    {
                        ((List<ERP_Library.NhanVienComboListChild>)lst).Add((ERP_Library.NhanVienComboListChild)item.ListObject);
                    }
            }

            //lấy số giờ và loại chấm nếu có
            decimal sogio = Convert.ToDecimal(txtSoGio.Value);

            //thực hiện chấm bằng cách insert hoặc edit dữ liệu của _data
            ERP_Library.NgoaiGioTungNgay_TongHop row = null;
            ERP_Library.NgoaiGioTungNgay_ChiTiet ct = null;
            foreach (ERP_Library.NhanVienComboListChild nv in (System.Collections.IList)lst)
            {
                //tìm nhân viên nếu có trong list cần cập nhật
                row = null;
                foreach (ERP_Library.NgoaiGioTungNgay_TongHop item in _List)
                    if (item.MaNhanVien == nv.MaNhanVien)
                    {
                        row = item;
                        break;
                    }
                if (row == null)//thêm nv mới vào danh sách nếu chưa có
                {
                    row = _List.AddNew();
                    row.MaBoPhan = _BoPhan.MaBoPhan;
                    row.MaNhanVien = nv.MaNhanVien;
                    row.TenNhanVien = nv.TenNhanVien;
                    row.MaKyTinhLuong = _KyLuong.MaKy;
                    row.MaKyChamCong = (int)cmbKyCham.Value;
                }
                //kiểm tra đã duyệt
                if (row != null && row.DaDuyet)
                    MessageBox.Show("Dữ liệu nhân viên " + row.TenNhanVien + " đã được duyệt nên không thể thay đổi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                //chấm liên tục nhiều ngày
                for (DateTime ngay = txtTuNgay.DateTime; ngay <= txtDenNgay.DateTime; ngay = ngay.AddDays(1))
                {
                    //tìm chi tiết ngày chấm
                    ct = null;
                    foreach (ERP_Library.NgoaiGioTungNgay_ChiTiet i in row.ChiTiet)
                        if (i.Ngay == ngay)
                        {
                            ct = i;
                            break;
                        }
                    if (ct == null)//thêm chi tiết nếu chưa có
                    {
                        ct = row.ChiTiet.AddNew();
                        ct.MaLoai = _HinhThuc.MaLoaiTangCa;
                        ct.Ngay = ngay;
                    }
                    ct.SoGio = Convert.ToDecimal(txtSoGio.Value);
                }
            }
        }

        private void grdData_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            int tong = 0;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in grdData.Rows)
                if ((bool)r.Cells["Chon"].Value)
                    tong++;
            txtSoNV.Text = tong.ToString("#,###");
        }

        private void grdData_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            if (e.Cell.Column.Key == "Chon")
                e.Cell.Row.Update();
        }

        private void txtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            txtDenNgay.Value = txtTuNgay.Value;
        }
   }
}