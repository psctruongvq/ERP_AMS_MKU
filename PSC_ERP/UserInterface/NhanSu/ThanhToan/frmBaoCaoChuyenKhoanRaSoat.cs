using System;
using System.Windows.Forms;
using ERP_Library;
using ERP_Library.Security;

namespace PSC_ERP
{
    public partial class frmBaoCaoChuyenKhoanRaSoat : Form
    {
        FilterCombo fileternganHang;
        DoiTuongAllList _doiTuongAllList;
        int userID = CurrentUser.Info.UserID;

        public frmBaoCaoChuyenKhoanRaSoat()
        {
            InitializeComponent();
            this.NhanvienListbindingSource.DataSource = typeof(DoiTuongAllList);
            ultraCombo_NhanVien.DataSource = NhanvienListbindingSource;
            ultraCombo_NhanVien.DisplayMember = "TenDoiTuong";
            //ultraCombo_NhanVien.Value = "MaDoiTuong";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBaoCaoChuyenKhoan_Load(object sender, EventArgs e)
        {
            txtTuNgay.DateTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            txtDenNgay.DateTime = DateTime.Today;
          //  ultraCombo_NganHang.DataSource = ERP_Library.NganHangList.GetNganHangList();
            ultraCombo_NganHang.DataSource = ERP_Library.NganHangList.GetNganHangListByCongTy();
            ultraCombo_NganHang.ValueMember = "MaNganHang";
            ultraCombo_NganHang.DisplayMember = "TenNganHang";
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll(userID);
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            HamDungChung.VisibleColumn(ultraCombo_NganHang.DisplayLayout.Bands[0], "TenNganHang", "TenVietTat");
            cmbBoPhan.Value = 0;

            treeReport.ExpandAll();
            cmbKyTen.Value = 0;
      
            fileternganHang = new FilterCombo(ultraCombo_NganHang, "TenNganHang");
            _doiTuongAllList = DoiTuongAllList.GetDoiTuongAllListByLoai(1,0);
            
        }

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblBoPhan.Visible = false;
            cmbBoPhan.Visible = false;
            lblNganHang.Visible = false;
            ultraCombo_NganHang.Visible = false;
            lblNhanVien.Visible = false;
            ultraCombo_NhanVien.Visible = false;

            if (e.Node.Nodes.Count == 0)
            {
                string s = "";
                int yl = 60, yc = 51, c = 0;
                if (e.Node.Tag is string) s = (string)e.Node.Tag;

                if (s.Contains("NganHang"))
                {
                    lblNganHang.Top = yl + 28 * c;
                    ultraCombo_NganHang.Top = yc + 28 * c;
                    lblNganHang.Visible = true;
                    ultraCombo_NganHang.Visible = true;
                    c++;
                }

                if (s.Contains("BoPhan"))
                {
                    lblBoPhan.Top = yl + 28 * c;
                    cmbBoPhan.Top = yc + 28 * c;
                    lblBoPhan.Visible = true;
                    cmbBoPhan.Visible = true;
                    c++;
                }

                if (s.Contains("NhanVien"))
                {
                    lblNhanVien.Top = yl + 28 * c;
                    ultraCombo_NhanVien.Top = yc + 28 * c;
                    lblNhanVien.Visible = true;
                    ultraCombo_NhanVien.Visible = true;
                    c++;
                }

                btnReport.Enabled = true;
            }
            else
            {
                btnReport.Enabled = false;
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (treeReport.SelectedNode == null) return;
            if (ultraCombo_NganHang.Visible && ultraCombo_NganHang.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn ngân hàng", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //if (cmbBoPhan.Visible && (cmbBoPhan.Value == null || (int)cmbBoPhan.Value == 0))
            //{
            //    MessageBox.Show("Bạn chưa chọn bộ phận", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            //báo cáo
            frmXemIn f = new frmXemIn();
            string sNganHang, PhanLoai;
            sNganHang = ultraCombo_NganHang.Text;
            PhanLoai = "";
            if (ultraCombo_NganHang.Visible)
            {
                PhanLoai = "Ngân hàng : " + sNganHang;
            }
            if (cmbBoPhan.Visible && cmbBoPhan.Value is int && (int)cmbBoPhan.Value != 0)
            {
                if (PhanLoai == "")
                    PhanLoai = "Bộ phận : " + cmbBoPhan.Text;
                else
                    PhanLoai += "\r\nBộ phận : " + cmbBoPhan.Text;
            }
            long MaNhanVien = 0;
            if (ultraCombo_NhanVien.Value is long)
                MaNhanVien = (long)ultraCombo_NhanVien.Value;

            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            switch (treeReport.SelectedNode.Name)
            {
                case "tonghopbophan":
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptTongHopChuyenKhoanBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopChuyenKhoanBoPhan.rdlc";
                    f.SetDatabase("ERP_Library_Report_TongHopChuyenKhoanBoPhanList", ERP_Library.Report.TongHopChuyenKhoanBoPhanList.GetTongHopChuyenKhoanBoPhanList(txtTuNgay.DateTime, txtDenNgay.DateTime, (int)ultraCombo_NganHang.Value));
                    break;
                case "chitietbophan":
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptChiTietChuyenKhoanBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanBoPhan.rdlc";
                    f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanBoPhanList", ERP_Library.Report.ChiTietChuyenKhoanBoPhanList.GetChiTietChuyenKhoanBoPhanList(txtTuNgay.DateTime, txtDenNgay.DateTime, (int)ultraCombo_NganHang.Value, (int)cmbBoPhan.Value));
                    break;
                case "chitietnhanvienbophan":
                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanNhanVienBoPhanList", ERP_Library.Report.ChiTietChuyenKhoanNhanVienBoPhanList.GetChiTietChuyenKhoanNhanVienBoPhanList(txtTuNgay.DateTime, txtDenNgay.DateTime, (int)ultraCombo_NganHang.Value, (int)cmbBoPhan.Value, MaNhanVien));
                    f.SetParameter("TieuDe", "CHI TIẾT CHUYỂN KHOẢN NHÂN VIÊN");
                    break;
                case "tonghopnhanvien":
                    //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietChuyenKhoanNhanVienBoPhan.rdlc";
                    f.SetDatabase("ERP_Library_Report_ChiTietChuyenKhoanNhanVienBoPhanList", ERP_Library.Report.ChiTietChuyenKhoanNhanVienBoPhanList.GetTongHopChuyenKhoanNhanvien(txtTuNgay.DateTime, txtDenNgay.DateTime, (int)ultraCombo_NganHang.Value, (int)cmbBoPhan.Value, MaNhanVien));
                    f.SetParameter("TieuDe", "TỔNG HỢP CHUYỂN KHOẢN NHÂN VIÊN");
                    break;               
                default:
                    return;
            }

            f.SetNguoiKy((int)cmbKyTen.Value);
            f.SetParameter("PhanLoai", PhanLoai);
            f.SetParameter("ThoiGian", "Từ Ngày: " + txtTuNgay.DateTime.ToShortDateString() + " Đến Ngày: " + txtDenNgay.DateTime.ToShortDateString());
            f.ShowDialog();
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value is int && (int)cmbBoPhan.Value != 0 && ultraCombo_NhanVien.Visible)
            {
                _doiTuongAllList = DoiTuongAllList.GetDoiTuongAllListByLoai(1, (int)cmbBoPhan.Value);
                //ultraCombo_NhanVien.LoadDataByBoPhanALL((int)cmbBoPhan.Value);
                NhanvienListbindingSource.DataSource = _doiTuongAllList;
            }
            else if (ultraCombo_NhanVien.Visible)
            {
                _doiTuongAllList = DoiTuongAllList.GetDoiTuongAllListByLoai(1, 0);
                NhanvienListbindingSource.DataSource = _doiTuongAllList;
            }
        }
    }
}