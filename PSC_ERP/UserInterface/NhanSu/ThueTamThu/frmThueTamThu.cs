using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;              
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.Security;

namespace PSC_ERP
{       
    public partial class frmThueTamThu : Form
    {
        KyTinhLuongList _kyTinhLuongList;
        ThueTamThuList _thueTamThuList;
        bool IsLoaded = false;

        public frmThueTamThu()
        {
            InitializeComponent();
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            KyTinhLuong_bindingSource.DataSource = _kyTinhLuongList;
        }
        bool KiemTraDuLieu()
        {
            if (cmbKyTinhLuong.Value == null)
            {
                MessageBox.Show("Chưa chọn kỳ tính lương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            ERP_Library.KyTinhLuong ky = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyTinhLuong.Value);
            if (ky.KhoaSoKy2)
            {
                MessageBox.Show("Kỳ lương này đã khóa sổ nên không thể tính thuế TNCN", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void btnTinhThue_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                _thueTamThuList = ThueTamThuList.TinhThueTamThu(int.Parse(cmbKyTinhLuong.Value.ToString()), txtDenNgay.DateTime, txtNgay.DateTime);
                IsLoaded = false;
                cmbKyTinhLuong_ValueChanged(sender, e);
                cmbNgayTinh.SelectedValue = txtNgay.DateTime;
                IsLoaded = true;
                ThueTamThuList_bindingSource.DataSource = _thueTamThuList;
                MessageBox.Show("Đã tính thuế TNCN thành công. Vui lòng lập tiếp đề nghị chuyển khoản", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grid_ThueTamThu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            grid_ThueTamThu.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in grid_ThueTamThu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }

            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false; 
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TongThuNhap"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["GiamTru"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueTNCN"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueDaThu"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThuePhaiThu"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TamThuKhac"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TongThu"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["DienGiai"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["DaThu"].Hidden = false;

            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 0; 
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TongThuNhap"].Header.VisiblePosition = 2;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["GiamTru"].Header.VisiblePosition = 3;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueTNCN"].Header.VisiblePosition = 4;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueDaThu"].Header.VisiblePosition = 5;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThuePhaiThu"].Header.VisiblePosition = 6;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 7;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TamThuKhac"].Header.VisiblePosition = 8;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TongThu"].Header.VisiblePosition = 9;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["DienGiai"].Header.VisiblePosition = 10;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["DaThu"].Header.VisiblePosition = 11;

            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TongThuNhap"].Header.Caption ="Tổng Thu Nhập";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["GiamTru"].Header.Caption ="Giảm Trừ";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueTNCN"].Header.Caption ="Thuế TNCN";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueDaThu"].Header.Caption ="Thuế Đã Thu";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThuePhaiThu"].Header.Caption ="Thuế Phải Thu";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["DaThu"].Header.Caption = "Đã thu";

        }

        private void LoadData()
        {
            if (!IsLoaded || cmbKyTinhLuong.Value == null || cmbNgayTinh.SelectedValue == null) return;
            _thueTamThuList = ERP_Library.ThueTamThuList.GetThueTamThuListTheoNgay((int)cmbKyTinhLuong.Value, 0, (DateTime)cmbNgayTinh.SelectedValue, (DateTime)cmbNgayTinh.SelectedValue);
            ThueTamThuList_bindingSource.DataSource = _thueTamThuList;
        }

        private void frmThueTamThu_Load(object sender, EventArgs e)
        {
            txtDenNgay.DateTime = DateTime.Today;
            txtNgay.DateTime = DateTime.Today;
            IsLoaded = true;
        }

        private void cmbKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyTinhLuong.Value != null)
                ngayTinhThueTamThuListBindingSource.DataSource = ERP_Library.NgayTinhThueTamThuList.GetNgayTinhThueTamThuList((int)cmbKyTinhLuong.Value);
        }

        private void cmbNgayTinh_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolLuu_Click(object sender, EventArgs e)
        {
            if (_thueTamThuList != null)
            {
                try
                {
                    ERP_Library.KyTinhLuong kyluong = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyTinhLuong.Value);
                    if (kyluong.KhoaSoKy2)
                    {
                        MessageBox.Show("Kỳ lương này đã khóa sổ nên không thể lưu", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    grid_ThueTamThu.UpdateData();
                    _thueTamThuList.Save();
                    MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _thueTamThuList);
                }
            }
        }

        private void toolUndo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolReport_Click(object sender, EventArgs e)
        {
            if (cmbKyTinhLuong.Value == null || cmbNgayTinh.SelectedValue == null) return;

            frmXemIn f = new frmXemIn();
            f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptThueTamThu.rdlc";
            //f.Report.ReportPath = @"F:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptThueTamThu.rdlc";
            f.SetNguoiKy(2);
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            f.SetParameter("Ngay", "Ngày : " + ((DateTime)cmbNgayTinh.SelectedValue).ToString("dd/MM/yyyy"));
            f.SetDatabase("ERP_Library_ThueTamThuList", ERP_Library.ThueTamThuList.GetThueTamThuReport((int)cmbKyTinhLuong.Value, 0, (DateTime)cmbNgayTinh.SelectedValue, (DateTime)cmbNgayTinh.SelectedValue));
            f.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grid_ThueTamThu);
        }
    }
}
