using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmChamNgoaiGioTongHop : Form
    {
        private bool OK = false;
        private ERP_Library.NhanVienComboList _Data;
        private ERP_Library.BoPhan _BoPhan;
        private ERP_Library.KyTinhLuong _KyLuong;

        public frmChamNgoaiGioTongHop()
        {
            InitializeComponent();
        }

        private void frmChamTangCaHangLoat_Load(object sender, EventArgs e)
        {
            bdHinhThuc.DataSource = ERP_Library.LoaiTangCaList.GetLoaiTangCaList();
            cmbKyCham.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbKyCham.Value = _KyLuong.MaKy;
        }

        public bool ChamNgoaiGio(ERP_Library.KyTinhLuong KyLuong, ERP_Library.BoPhan BoPhan)
        {
            _BoPhan = BoPhan;
            _KyLuong = KyLuong;
            radBoPhan.Text += " " + _BoPhan.TenBoPhan;
            radNhanVien.Text += " " + _BoPhan.TenBoPhan;
            this.ShowDialog();
            return OK;
        }

        private void radNhanVien_CheckedChanged(object sender, EventArgs e)
        {
            if (_Data == null && radNhanVien.Checked)
            {
                _Data = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhanKhongNghiViec(_BoPhan.MaBoPhan,true);

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
            OK = true;
            this.Close();
        }

        /// <summary>
        /// Cập nhật (thêm, sửa) dữ liệu chấm ngoài giờ vào object data
        /// </summary>
        public void CapNhatDuLieu(ERP_Library.NgoaiGio_TongHopList _data)
        {
            //lấy danh sách mã nhân viên cần cập nhật
            object lst = null;
            if (radBoPhan.Checked)
                lst = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhanKhongNghiViec(_BoPhan.MaBoPhan,true);
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
            int loai = 0;
            if (cmbHinhThuc.Value != null)
                loai = (int)cmbHinhThuc.Value;
            decimal sogio = Convert.ToDecimal(txtSoGio.Value);
            bool cham = loai != 0 && sogio > 0;

            //thực hiện chấm bằng cách insert hoặc edit dữ liệu của _data
            ERP_Library.NgoaiGio_TongHop nv;
            ERP_Library.NgoaiGio_ChiTiet ct;
            foreach (ERP_Library.NhanVienComboListChild manv in (System.Collections.IList)lst)
            {
                //kiểm tra đã có nv chưa
                nv = null;
                foreach (ERP_Library.NgoaiGio_TongHop item in _data)
                {
                    if (item.MaNhanVien == ((ERP_Library.NhanVienComboListChild)manv).MaNhanVien)
                    {
                        nv = item;
                        break;
                    }
                }
                //kiểm tra đã duyệt
                if (nv != null && nv.DaDuyet)
                {
                    cham = false;
                    MessageBox.Show("Dữ liệu nhân viên " + nv.TenNhanVien + " đã được duyệt nên không thể thay đổi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    //cập nhật nhân viên
                    if (nv == null)
                    {
                        nv = ERP_Library.NgoaiGio_TongHop.NewNgoaiGio_TongHopChild();
                        nv.MaNhanVien = ((ERP_Library.NhanVienComboListChild)manv).MaNhanVien;
                        nv.TenNhanVien = ((ERP_Library.NhanVienComboListChild)manv).TenNhanVien;
                        nv.MaKyChamCong = (int)cmbKyCham.Value;
                        nv.MaKyTinhLuong = _KyLuong.MaKy;
                        nv.MaBoPhan = _BoPhan.MaBoPhan;
                        _data.Add(nv);
                    }
                //cập nhật giờ chi tiết
                if (cham)
                {
                    //lấy chi tiết giờ
                    ct = null;
                    foreach (ERP_Library.NgoaiGio_ChiTiet i in nv.ChiTiet)
                        if (i.MaLoai == loai)
                        {
                            ct = i;
                        }
                    if (ct == null)
                    {
                        ct = ERP_Library.NgoaiGio_ChiTiet.NewNgoaiGio_ChiTietChild();
                        nv.ChiTiet.Add(ct);
                    }
                    ct.MaLoai = loai;
                    ct.SoGio = sogio;
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
    }
}
