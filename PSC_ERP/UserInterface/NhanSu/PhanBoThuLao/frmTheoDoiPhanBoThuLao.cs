using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;
using System.Data.SqlClient;
namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    public partial class frmTheoDoiPhanBoThuLao : Form
    {
        #region

        KyTinhLuongList _kyTinhLuongList;
        DanhSachPhanBoThuLaoList _danhSachPhanBoThuLaoList;

        int maBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        int maKyTinhLuong = 0;
        DateTime tuNgay = DateTime.Now.Date;
        DateTime denNgay = DateTime.Now.Date;
        #endregion
        public frmTheoDoiPhanBoThuLao()
        {
            InitializeComponent();
            this.KyTinhLuong_BindingSource.DataSource = typeof(KyTinhLuongList);
            LoadForm();
        }

        public void LoadForm()
        {
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongListByKhoaSo();
            KyTinhLuong_BindingSource.DataSource = _kyTinhLuongList;

            _danhSachPhanBoThuLaoList=DanhSachPhanBoThuLaoList.NewDanhSachPhanBoThuLaoList();
            DanhSachPhanBoThuLao_BindingSource.DataSource=_danhSachPhanBoThuLaoList;

            cmbu_TuNgay.Value = DateTime.Now.Date;
            cmbu_DenNgay.Value = DateTime.Now.Date;
        }
      
        private void cmbu_KyTinhLuong_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//Navy
                col.Hidden = true;
            }
            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Hidden = false;

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.Caption = "Tên Kỳ";

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Width = 150;

            cmbu_KyTinhLuong.DisplayLayout.Bands[0].Columns["TenKy"].Header.VisiblePosition = 0;
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn thật sự muốn thoát không ?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (_DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void grdu_DanhSachPhanBoThuLao_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            foreach (UltraGridColumn col in this.grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
            }
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["Ma"].Hidden = true;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLao"].Header.VisiblePosition = 0;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.VisiblePosition = 1;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.VisiblePosition = 2;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.VisiblePosition = 3;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.VisiblePosition = 4;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapNhanVien"].Header.VisiblePosition = 5;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.VisiblePosition = 7;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapCongTacVien"].Header.VisiblePosition = 6;

            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["MaPhanBoThuLao"].Header.Caption = "Mã Phân Bổ ";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["TenChuongTrinh"].Header.Caption = "Tên Chương Trình";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["TenBoPhan"].Header.Caption = "Bộ Phận";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Header.Caption = "Tên Công Việc";       
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Header.Caption = "Số Tiền";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapNhanVien"].Header.Caption = "Số Tiền Nhân Viên";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapCongTacVien"].Header.Caption = "Số Tiền Cộng Tác Viên";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Header.Caption = "Số Tiền Còn Lại";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["HoanTat"].Header.Caption = "Hoàn Tất";

            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Width = 150;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapNhanVien"].Width = 150;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapCongTacVien"].Width = 160;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Width = 150;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["HoanTat"].Width = 80;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["TenCongViec"].Width = 200;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["TenBoPhan"].Width = 160;

            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].Format = "#,###";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].PromptChar = ' ';

            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapNhanVien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapNhanVien"].Format = "#,###";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapNhanVien"].PromptChar = ' ';

            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapCongTacVien"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapCongTacVien"].Format = "#,###";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapCongTacVien"].PromptChar = ' ';

            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].MaskInput = "{LOC}nnn,nnn,nnn,nnn,nnn,nnn";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].Format = "#,###";
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].PromptChar = ' ';

            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienConLai"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapCongTacVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTienNhapNhanVien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            grdu_DanhSachPhanBoThuLao.DisplayLayout.Bands[0].Columns["SoTien"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
        
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbu_KyTinhLuong.Value) == 0)
            {
                MessageBox.Show("Chưa chọn kỳ tính lương.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Convert.ToDateTime(cmbu_DenNgay.Value).Date < Convert.ToDateTime(cmbu_TuNgay.Value).Date)
            {
                MessageBox.Show("Từ ngày phải nhỏ hơn hoặc bằng đến ngày.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            maKyTinhLuong = Convert.ToInt32(cmbu_KyTinhLuong.Value);
            tuNgay = Convert.ToDateTime(cmbu_TuNgay.Value);
            denNgay = Convert.ToDateTime(cmbu_DenNgay.Value);

            _danhSachPhanBoThuLaoList = DanhSachPhanBoThuLaoList.GetDanhSachPhanBoThuLaoList(maKyTinhLuong,tuNgay,denNgay,maBoPhan);
            DanhSachPhanBoThuLao_BindingSource.DataSource = _danhSachPhanBoThuLaoList;
        }

        private void cmbu_KyTinhLuong_AfterCloseUp(object sender, EventArgs e)
        {
            if (cmbu_KyTinhLuong.Value != null)
            {
                KyTinhLuong _kyTinhLuong = KyTinhLuong.GetKyTinhLuong((int)cmbu_KyTinhLuong.Value);

                cmbu_TuNgay.Value = _kyTinhLuong.NgayBatDau;
                cmbu_DenNgay.Value = _kyTinhLuong.NgayKetThuc;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DanhSachPhanBoThuLao);
        }

        private void tlsblExport_Click(object sender, EventArgs e)
        {
            HamDungChung.ExportToExcel(grdu_DanhSachPhanBoThuLao);
        }

    }
}
