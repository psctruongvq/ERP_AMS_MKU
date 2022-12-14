using ERP_Library.Security;
using System;
using System.Windows.Forms;

namespace PSC_ERP.ThanhToan
{
    public partial class frmInThuLaoNganHang : Form
    {
        int userID = CurrentUser.Info.UserID;
        public frmInThuLaoNganHang()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmInThuLaoNganHang_Load(object sender, EventArgs e)
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll(userID);
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            foreach (ERP_Library.NganHang item in ERP_Library.NganHangList.GetNganHangList())
                cmbNganHang.Items.Add(item.MaNganHang, item.TenNganHang);
            foreach (ERP_Library.NguoiKyChild r in ERP_Library.NguoiKyList.GetNguoiKyList())
            {
                cmbNguoiLap.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
                cmbPTTaiChinh.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
                cmbPTDonVi.Items.Add(r.MaNguoiKy, r.TenNguoiKy);
            }
            txtTuNgay.DateTime = DateTime.Today;
            txtDenNgay.DateTime = DateTime.Today;
            cmbBoPhan.Value = 0;
            cmbNganHang.Value = 0;
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
                txtTuNgay.Value = ((ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject).NgayBatDau;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value == null) return;
            frmXemIn f = new frmXemIn();
            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptThuLaoNhanVienNganHang.rdlc";
            //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptThuLaoNhanVienNganHang.rdlc";
            string loai = "Từ " + txtTuNgay.DateTime.ToString("dd/MM/yy") + " đến " + txtDenNgay.DateTime.ToString("dd/MM/yy");
            if (cmbNganHang.Value != null && (int)cmbNganHang.Value != 0)
            {
                loai += "\r\nNgân hàng : " + cmbNganHang.Text;
            }

            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ThuLaoNhanVienNganHangList", ERP_Library.Report.ThuLaoNhanVienNganHangList.GetThuLaoNhanVienNganHangList((int)cmbKyLuong.Value,(int)cmbBoPhan.Value,(int)cmbNganHang.Value,txtTuNgay.DateTime,txtDenNgay.DateTime)));
            Microsoft.Reporting.WinForms.ReportParameter _ky = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong", cmbKyLuong.Text); 
            Microsoft.Reporting.WinForms.ReportParameter _loai = new Microsoft.Reporting.WinForms.ReportParameter("PhanLoai", loai);
            Microsoft.Reporting.WinForms.ReportParameter _nguoilap = new Microsoft.Reporting.WinForms.ReportParameter("NguoiLapBang", cmbNguoiLap.Text);
            Microsoft.Reporting.WinForms.ReportParameter _pttaichinh = new Microsoft.Reporting.WinForms.ReportParameter("PhuTrachDonVi", cmbPTDonVi.Text);
            Microsoft.Reporting.WinForms.ReportParameter _ptdonvi = new Microsoft.Reporting.WinForms.ReportParameter("PhuTrachTaiChinh", cmbPTTaiChinh.Text);
            rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { _ky, _loai, _nguoilap, _pttaichinh, _ptdonvi });

            f.ShowDialog();
        }
    }
}