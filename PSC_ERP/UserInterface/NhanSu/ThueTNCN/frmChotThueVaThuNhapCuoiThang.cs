using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using System.Data.SqlClient;
using PSC_ERP_Common;
namespace PSC_ERP
{
    public partial class frmChotThueVaThuNhapCuoiThang : Form
    {
        #region

        #endregion
        public frmChotThueVaThuNhapCuoiThang()
        {
            InitializeComponent();
            //
            LoadForm();
        }

        private void LoadForm()
        {
            KyTinhLuongList kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            KyTinhLuong_BindingSource.DataSource = kyTinhLuongList;

            //Set ngày chốt thuế
            dte_NgayChot.Value = DateTime.Now.Date;
        }
        private void grdViewChotThueVaThuNhapCuoiThang_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            e.Layout.Override.CellClickAction = CellClickAction.CellSelect;
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["So"].Header.Caption = "Số Chứng Từ";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Tên Bộ Phận";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "CMND";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["MST"].Header.Caption = "Mã Số Thuế";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["NgayCap"].Header.Caption = "Ngày Cấp";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienDaKhauTru"].Header.Caption = "Số Tiền Khấu Trừ";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";


            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["So"].Width = 100;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 200;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["CMND"].Width = 100;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["MST"].Width = 100;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["NgayCap"].Width = 100;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTien"].Width = 100;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienDaKhauTru"].Width = 120;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 120;

            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["So"].Header.VisiblePosition = 0;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 1;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 3;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["MST"].Header.VisiblePosition = 4;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["NgayCap"].Header.VisiblePosition = 5;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 6;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienDaKhauTru"].Header.VisiblePosition = 7;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 8;

            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["So"].Hidden = false;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["TenBoPhan"].Hidden = false;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["MST"].Hidden = false;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["NgayCap"].Hidden = false;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienDaKhauTru"].Hidden = false;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienConLai"].Hidden = false;

            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienDaKhauTru"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienDaKhauTru"].Format = "#,###";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienDaKhauTru"].PromptChar = ' ';

            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienConLai"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "#,###";
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienConLai"].PromptChar = ' ';


            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienDaKhauTru"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdViewChotThueVaThuNhapCuoiThang.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
        }

        private void btnXuLy_Click(object sender, EventArgs e)
        {
            string thongBaoChotThue = string.Empty;
            Boolean xoaDuLieuDaChot = false;
            //Kiểm tra kỳ tính lương
            if (cmbuKyTinhLuong.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ tính lương.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Kiểm tra ngày chốt thuế
            if (dte_NgayChot.Value == null)
            {
                MessageBox.Show("Vui lòng chọn ngày chốt thuế.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Lấy kỳ tính lương
            int maKyTinhLuong = Convert.ToInt32(cmbuKyTinhLuong.Value);
            KyTinhLuong kyTinhLuong = KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);

            //Kiểm tra khóa sổ
            if (kyTinhLuong.KhoaSoKy2 == true)
            {
                MessageBox.Show("Kỳ tính lương [" + kyTinhLuong.TenKy.Trim() + "] đã khóa sổ, không thể chốt thuế.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Kiểm tra ngày chốt thuế
            if (kyTinhLuong.NgayBatDau > Convert.ToDateTime(dte_NgayChot.Value) || kyTinhLuong.NgayKetThuc < Convert.ToDateTime(dte_NgayChot.Value))
            {
                MessageBox.Show("Ngày chốt thuế không nằm trong kỳ tính lương [" + kyTinhLuong.TenKy.Trim() + "].", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Kiểm tra đã chốt thuế chưa
            if (KiemTraChotThueVaThuNhapCuoiThang(maKyTinhLuong))
            {
                thongBaoChotThue = "Kỳ tính lương [" + kyTinhLuong.TenKy.Trim() + "] đã chốt thuế. Bạn muốn xóa dữ liệu và chốt thuế lại?";
                xoaDuLieuDaChot = true;
            }
            else
            {
                thongBaoChotThue = "Bạn thật sự muốn chốt thuế [" + kyTinhLuong.TenKy.Trim() + "]?";
            }

            DialogResult dialogResult = MessageBox.Show(thongBaoChotThue, "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)//Đồng ý chạy chốt thuế
            {
                try
                {
                    using (DialogUtil.Wait(this))
                    {
                        if (xoaDuLieuDaChot)//Chấp nhận xóa dữ liệu
                        {
                            //Tiến hành xóa
                            XoaChotThueVaThuNhapCuoiThang(maKyTinhLuong);
                        }

                        //Chạy chốt thuế cuối tháng
                        ChotThueCuoiThang(maKyTinhLuong, Convert.ToDateTime(dte_NgayChot.Value));

                        //Load danh sách nhân viên vừa chốt thuế
                        LoadDanhSachChotThueCongTacVienTheoThang(maKyTinhLuong);
                    }

                    MessageBox.Show("Chốt thuế [" + kyTinhLuong.TenKy.Trim() + "] thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chốt thuế không thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool KiemTraChotThueVaThuNhapCuoiThang(int maKyTinhLuong)
        {
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_KiemTraChotThueVaThuNhapCuoiThang";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@KetQua", kq);
                    cm.Parameters["@KetQua"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    kq = Convert.ToBoolean(cm.Parameters["@KetQua"].Value);
                }
            }//using

            return kq;
        }
        private bool XoaChotThueVaThuNhapCuoiThang(int maKyTinhLuong)
        {
            Boolean kq = false;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_XoaChotThueVaThuNhapCuoiThang";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.ExecuteNonQuery();
                }
            }//using

            return kq;
        }
        private void LoadDanhSachChotThueCongTacVienTheoThang(int maKyTinhLuong)
        {
            NhanVienNgoaiDaiList nhanVienList = ERP_Library.NhanVienNgoaiDaiList.GetDanhSachChotThuecCongTacVienList_ByMaKyTinhLuong(maKyTinhLuong);
            NhanVienNgoaiDaiList_BindingSource.DataSource = nhanVienList;
        }
        private void ChotThueCuoiThang(int maKyTinhLuong, DateTime ngayChot)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_XuLyChotThueVaThuNhapCuoiThang";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@NgayLap", ngayChot);

                    cm.ExecuteNonQuery();
                }
            }//using
        }

        private void cmbuKyTinhLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbuKyTinhLuong.Value == null)
                return;

            //Load danh sách nhân viên vừa chốt thuế
            LoadDanhSachChotThueCongTacVienTheoThang(Convert.ToInt32(cmbuKyTinhLuong.Value));
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoaChotThue_Click(object sender, EventArgs e)
        {
            //Kiểm tra kỳ tính lương
            if (cmbuKyTinhLuong.Value == null)
            {
                MessageBox.Show("Vui lòng chọn kỳ tính lương.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Lấy kỳ tính lương
            int maKyTinhLuong = Convert.ToInt32(cmbuKyTinhLuong.Value);
            KyTinhLuong kyTinhLuong = KyTinhLuong.GetKyTinhLuong(maKyTinhLuong);

            //Kiểm tra khóa sổ
            if (kyTinhLuong.KhoaSoKy2 == true)
            {
                MessageBox.Show("Kỳ tính lương [" + kyTinhLuong.TenKy.Trim() + "] đã khóa sổ, không thể xóa dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (grdViewChotThueVaThuNhapCuoiThang.Rows.Count == 0)
            {
                MessageBox.Show("Kỳ tính lương [" + kyTinhLuong.TenKy.Trim() + "] không có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {

                DialogResult dialogResult = MessageBox.Show("Bạn thật sự muốn xóa dữ liệu kỳ tính lương [" + kyTinhLuong.TenKy.Trim() + "]? ", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)//Đồng ý xóa chốt thuế
                {
                    using (DialogUtil.Wait(this))
                    {
                        //Tiến hành xóa dữ liệu đã chốt trong tháng
                        XoaChotThueVaThuNhapCuoiThang(maKyTinhLuong);

                        //Load lại danh sách
                        LoadDanhSachChotThueCongTacVienTheoThang(maKyTinhLuong);
                    }

                    MessageBox.Show("Đã xóa dữ liệu chốt thuế kỳ tính lương [" + kyTinhLuong.TenKy.Trim() + "].", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}