using System;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmBaoCaoThueTamThu : Form
    {
        KyTinhLuongList _kyTinhLuongList;
        BoPhanList _boPhanList;
        ThueTamThuList _thueTamThuList;
        int userID = CurrentUser.Info.UserID;
        public frmBaoCaoThueTamThu()
        {
            InitializeComponent();
            _kyTinhLuongList = KyTinhLuongList.GetKyTinhLuongList();
            KyTinhLuong_bindingSource.DataSource = _kyTinhLuongList;

            _boPhanList = BoPhanList.GetBoPhanListAll(userID);
            _boPhanList.Insert(0, BoPhan.NewBoPhan(0, "Tất cả"));
            BoPhan_bindingSource.DataSource = _boPhanList;
        }                     

        private void label2_Click(object sender, EventArgs e)
        {

        }
        int MaBoPhan = 0;
        int MaKyTinhLuong = 0;
        bool KiemTraDuLieu()
        {            
            if (cmbKyTinhLuong.Value == null)
            {
                MessageBox.Show("Chưa chọn kỳ tính lương", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                MaKyTinhLuong = int.Parse(cmbKyTinhLuong.Value.ToString());
                return true;
            }
            return true;
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                if (cmbBoPhan.Value != null)
                {
                    MaBoPhan = int.Parse(cmbBoPhan.Value.ToString());
                }
                _thueTamThuList = ThueTamThuList.GetThueTamThuListTheoNgay(MaKyTinhLuong, MaBoPhan, dtTuNgay.DateTime, dtDenNgay.DateTime);
                ThueTamThu_bindingSource.DataSource = _thueTamThuList;
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            if (KiemTraDuLieu())
            {
                string TenBoPhan = " ";

                if (cmbBoPhan.Value != null)
                {
                    if (int.Parse(cmbBoPhan.Value.ToString()) != 0)
                    {
                        MaBoPhan = int.Parse(cmbBoPhan.Value.ToString());
                        TenBoPhan = BoPhan.GetBoPhan(MaBoPhan).TenBoPhan;
                    }
                }
                _thueTamThuList = ThueTamThuList.GetThueTamThuListTheoNgay(MaKyTinhLuong, MaBoPhan, dtTuNgay.DateTime, dtDenNgay.DateTime);
                ThueTamThu_bindingSource.DataSource = _thueTamThuList;

                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;

                rpt.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBaoCaoThueTamThu.rdlc";
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ThueTamThuList", _thueTamThuList));

                //f.SetParameter("TenBoPhan", BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                //f.Report.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rptBaoCaoThueTamThu.rdlc";
                f.SetParameter("BoPhan", TenBoPhan);
                f.SetParameter("Ngay", "Từ Ngày " + dtTuNgay.DateTime.ToString("dd/MM/yyyy") + " Đến Ngày " + dtDenNgay.DateTime.ToString("dd/MM/yyyy"));
                f.SetParameter("KyTinhLuong", KyTinhLuong.GetKyTinhLuong(MaKyTinhLuong).TenKy);
                f.SetDatabase("ThueTamThuList", _thueTamThuList);
                f.SetNguoiKy(3);
                f.ShowDialog();
            }

        }

        private void grid_ThueTamThu_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in grid_ThueTamThu.DisplayLayout.Bands[0].Columns)
            {
                col.Hidden = true;
            }

            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TongThuLao"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["GiamTru"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueTNCN"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueDaThu"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThuePhaiThu"].Hidden = false;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["NgayLap"].Hidden = false;

            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 0;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TongThuLao"].Header.VisiblePosition = 1;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["GiamTru"].Header.VisiblePosition = 2;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueTNCN"].Header.VisiblePosition = 3;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueDaThu"].Header.VisiblePosition = 4;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThuePhaiThu"].Header.VisiblePosition = 5;
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.VisiblePosition = 6;

            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["TongThuLao"].Header.Caption = "Tổng Thù Lao";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["GiamTru"].Header.Caption = "Giảm Trừ";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueTNCN"].Header.Caption = "Thuế TNCN";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThueDaThu"].Header.Caption = "Thuế Đã Thu";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["ThuePhaiThu"].Header.Caption = "Thuế Phải Thu";
            grid_ThueTamThu.DisplayLayout.Bands[0].Columns["NgayLap"].Header.Caption = "Ngày Lập";
        }

    }
}
