using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using PSC_ERP.UserInterface.NhanSu.Thu_Lao;
using Infragistics.Win;
using System.Data.SqlClient;
namespace PSC_ERP
{
    public partial class frmDanhSachChuyenPhanBoThuLaoTrongDai : Form
    {
        PhanBoThuLaoList _phanBoThuLaoList = PhanBoThuLaoList.NewPhanBoThuLaoList();
        KyTinhLuongList _kyTinhLuongList = KyTinhLuongList.NewKyTinhLuongList();
        int userID = ERP_Library.Security.CurrentUser.Info.UserID;

        public frmDanhSachChuyenPhanBoThuLaoTrongDai()
        {
            InitializeComponent();
            this.PhanBoThuLao_BindingSource.DataSource = typeof(PhanBoThuLaoList);
        }

        public void LoadForm()
        {
          //  dateTuNgay.Value = DateTime.Now.Date;
          //  dateDenNgay.Value = DateTime.Now.Date;

            _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoListByNgayLap(Convert.ToDateTime(dateTuNgay.Value), Convert.ToDateTime(dateDenNgay.Value), userID, 3);
            PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KyTinhLuong_BindingSource.DataSource = _kyTinhLuongList;
        }
        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
           MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (grdu_PhanBoThuLao.Selected.Rows.Count == 0)
            {
                MessageBox.Show("Chọn dòng cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else
            {
                   DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn xóa không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                   if (_DialogResult == DialogResult.Yes)
                   {
                       int maBoPhanDen = Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaPhanBoThuLao"].Value);
                       int maKyTinhLuong = Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaKyTinhLuong"].Value);
                       DateTime ngayLap = Convert.ToDateTime(grdu_PhanBoThuLao.ActiveRow.Cells["NgayLap"].Value);
                       int maChuongTrinh = Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaChuongTrinh"].Value);

                       DeleteThuLaoChuongTrinhByChuyenPhanBoThuLao(userID, maKyTinhLuong, ngayLap, maChuongTrinh);

                       MessageBox.Show("Xóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                       LoadForm();
                   }  
            }          
        }

        public void DeleteThuLaoChuongTrinhByChuyenPhanBoThuLao(int userID, int maKyTinhLuong, DateTime ngayLap , int maChuongTrinh)
        {
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_DeletetblnsThuLaoChuongTrinhByChuyenPhanBoThuLaoTrongDai";
                    cm.Parameters.AddWithValue("@UserID", userID);
                    cm.Parameters.AddWithValue("@NgayLap", ngayLap);
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaChuongTrinh", maChuongTrinh);

                    cm.ExecuteNonQuery();
                }
            }//using
        }

        private void grdu_PhanBoThuLao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

            ///tao su kien cho luoi
            HamDungChung h = new HamDungChung();
            h.ultragrdEmail_InitializeLayout(sender, e);
            e.Layout.Override.AllowMultiCellOperations = AllowMultiCellOperation.All;
            e.Layout.Override.AllowAddNew = AllowAddNew.No;

            foreach (UltraGridColumn col in this.grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].CellActivation = Activation.NoEdit;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].Hidden = false;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinhQL"].Hidden = false;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].EditorComponent = cmbu_KyTinhLuong;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 2;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.VisiblePosition = 3;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 1;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].Header.VisiblePosition = 0;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinhQL"].Header.VisiblePosition = 3;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Header.Caption = "Bộ Phận Phân Bổ";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày lập";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].Header.Caption = "Kỳ Tính Lương";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinhQL"].Header.Caption = "Chương Trình";

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 120;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLaoQL"].Width = 180;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].Width = 100;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].Width = 150;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaChuongTrinhQL"].Width = 200;

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["NgayLap"].CellAppearance.TextHAlign = HAlign.Center;
            grdu_PhanBoThuLao.DisplayLayout.Bands[0].Columns["MaKyTinhLuong"].CellAppearance.TextHAlign = HAlign.Center;
        }

        private void grdu_PhanBoThuLao_DoubleClick(object sender, EventArgs e)
        {
            if (grdu_PhanBoThuLao.ActiveRow != null)
            {
                if (grdu_PhanBoThuLao.ActiveRow.IsFilterRow != true)
                {
                    int maBoPhan = Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaPhanBoThuLao"].Value);
                    DateTime ngayLap = Convert.ToDateTime(grdu_PhanBoThuLao.ActiveRow.Cells["NgayLap"].Value);
                    int maKyTinhLuong = Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaKyTinhLuong"].Value);
                    int maChuongTrinh = Convert.ToInt32(grdu_PhanBoThuLao.ActiveRow.Cells["MaChuongTrinh"].Value);

                    frmChuyenPhanBoThuLao_NhanVien f = new frmChuyenPhanBoThuLao_NhanVien(maBoPhan,ngayLap,maKyTinhLuong,0, maChuongTrinh);
                    f.ShowDialog(); 
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            _phanBoThuLaoList = PhanBoThuLaoList.GetPhanBoThuLaoListByNgayLap(Convert.ToDateTime(dateTuNgay.Value), Convert.ToDateTime(dateDenNgay.Value),userID,3);
            if (_phanBoThuLaoList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _phanBoThuLaoList = PhanBoThuLaoList.NewPhanBoThuLaoList();
            }
            this.PhanBoThuLao_BindingSource.DataSource = _phanBoThuLaoList;

            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KyTinhLuong_BindingSource.DataSource = _kyTinhLuongList;
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {

        }


    }
}