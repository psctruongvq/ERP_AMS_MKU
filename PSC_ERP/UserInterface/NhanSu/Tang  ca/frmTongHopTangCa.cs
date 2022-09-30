using ERP_Library.Security;
using System;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmTongHopTangCa : Form
    {
        private ERP_Library.HinhThucTangCaList _data;
        int userID = CurrentUser.Info.UserID;
        public frmTongHopTangCa()
        {
            InitializeComponent();
        }

        private void frmTongHopTangCa_Load(object sender, EventArgs e)
        {
            ERP_Library.KyTinhLuongList kyluong = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbTuKy.DataSource = kyluong;
            cmbDenKy.DataSource = kyluong;
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll(userID);
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbBoPhan.Value = 0;
            cmbKyTen.Value = 0;

            _data = ERP_Library.HinhThucTangCaList.GetHinhThucTangCaList();
            bdData.DataSource = _data;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckData()
        {
            if (cmbTuKy.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn từ kỳ để tổng hợp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbDenKy.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn đến kỳ để tổng hợp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            bdData.EndEdit();
            try
            {
                _data.Save();
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }

            return true;
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            string s, sub;

            //gọi report
            frmXemIn f = new frmXemIn();
            ERP_Library.Report.TongHopChamNgoaiGioList data = ERP_Library.Report.TongHopChamNgoaiGioList.GetTongHopChamNgoaiGioList((int)cmbTuKy.Value, (int)cmbDenKy.Value, (int)cmbBoPhan.Value,chkTheoKyChamCong.Checked, chkDuyet.Checked);
            
            s = Report_LoadString("PSC_ERP.Report.rptTongHopChamNgoaiGio.rdlc", data.SoCot, 1, 5);
            sub = Report_NguoiKyTenA4();
            f.Report.LoadReportDefinition(new System.IO.StringReader(s));
            f.Report.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));

            //f.Report.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptTongHopChamNgoaiGio.rdlc";
            //f.Report.ReportEmbeddedResource = @"PSC_ERP.Report.rptTongHopChamNgoaiGio.rdlc";
            f.SetDatabase("ERP_Library_Report_TongHopChamNgoaiGioList", data);
            f.SetNguoiKy((int)cmbKyTen.Value);
            f.SetParameter("ThoiGian", "Từ " + cmbTuKy.Text.ToLower() + " đến " + cmbDenKy.Text.ToLower());
            f.SetParameter("NoiDung", "TẤT CẢ");
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            f.ShowDialog();
            //this.Close();
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;

            string s, sub;
            frmXemIn f = new frmXemIn();
            ERP_Library.Report.TongHopChamNgoaiGioBoPhanList data = ERP_Library.Report.TongHopChamNgoaiGioBoPhanList.GetTongHopChamNgoaiGioBoPhanList((int)cmbTuKy.Value, (int)cmbDenKy.Value, (int)cmbBoPhan.Value,chkTheoKyChamCong.Checked, chkDuyet.Checked);

            s = Report_LoadString("PSC_ERP.Report.rptTongHopChamNgoaiGioBoPhan.rdlc", data.SoCot, 1, 7.3 - 2.1);
            sub = Report_NguoiKyTenA4();
            f.Report.LoadReportDefinition(new System.IO.StringReader(s));
            f.Report.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));

            f.SetDatabase("ERP_Library_Report_TongHopChamNgoaiGioBoPhanList", data);
            f.SetNguoiKy((int)cmbKyTen.Value);
            f.SetParameter("ThoiGian", "Từ " + cmbTuKy.Text.ToLower() + " đến " + cmbDenKy.Text.ToLower());
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            f.ShowDialog();
        }

        private string Report_LoadString(string reportname, int socot, double colwidth, double space)
        {
            string s = "";
            decimal l = 0;
            l = Convert.ToDecimal((space - (colwidth * socot)) / 2);
            if (l < 0) l = 0;
            System.IO.Stream m = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(reportname);
            byte[] a = new byte[m.Length];
            m.Read(a, 0, (int)m.Length);
            m.Close();
            s = System.Text.Encoding.UTF8.GetString(a);
            s = s.Replace(@"<Left>0.31746cm</Left>", @"<Left>" + l.ToString().Replace(",", ".") + @"in</Left>");
            return s;
        }

        private string Report_NguoiKyTenA4()
        {
            string s = "";
            System.IO.Stream m = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PSC_ERP.Report.rptNguoiKyTenA4.rdlc");
            byte[] a = new byte[m.Length];
            m.Read(a, 0, (int)m.Length);
            m.Close();
            s = System.Text.Encoding.UTF8.GetString(a);
            return s;
        }

        private void ultraButton_ChiTiet200Gio_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            string s, sub;

            //gọi report
            frmXemIn f = new frmXemIn();
            ERP_Library.Report.TongHopChamNgoaiGioList data = ERP_Library.Report.TongHopChamNgoaiGioList.GetTongHopChamNgoaiGio200GioList((int)cmbTuKy.Value, (int)cmbDenKy.Value, (int)cmbBoPhan.Value, chkTheoKyChamCong.Checked, chkDuyet.Checked);

            s = Report_LoadString("PSC_ERP.Report.rptChiTietChamNgoaiGio.rdlc", data.SoCot, 1, 5);
            sub = Report_NguoiKyTenA4();
            f.Report.LoadReportDefinition(new System.IO.StringReader(s));
            f.Report.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));

            //f.Report.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptTongHopChamNgoaiGio.rdlc";
            //f.Report.ReportEmbeddedResource = @"PSC_ERP.Report.rptTongHopChamNgoaiGio.rdlc";
            f.SetDatabase("ERP_Library_Report_TongHopChamNgoaiGioList", data);
            f.SetNguoiKy((int)cmbKyTen.Value);
            f.SetParameter("ThoiGian", "Từ " + cmbTuKy.Text.ToLower() + " đến " + cmbDenKy.Text.ToLower());
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            f.ShowDialog();
        }

        private void ultraButton_CTLonHon200Gio_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;
            string s, sub;

            //gọi report
            frmXemIn f = new frmXemIn();
            ERP_Library.Report.TongHopChamNgoaiGioList data = ERP_Library.Report.TongHopChamNgoaiGioList.GetTongHopChamNgoaiGioLonHon200List((int)cmbTuKy.Value, (int)cmbDenKy.Value, (int)cmbBoPhan.Value, chkTheoKyChamCong.Checked, chkDuyet.Checked);

            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.reportChitietNgoaiGioLonHon200.rdlc";
            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("TongHopChamNgoaiGioList", data));

            f.SetNguoiKy((int)cmbKyTen.Value);
            f.SetParameter("ThoiGian", "Từ " + cmbTuKy.Text.ToLower() + " đến " + cmbDenKy.Text.ToLower());
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            f.ShowDialog();
        }

        private void ultraButton_THLonHon200Gioi_Click(object sender, EventArgs e)
        {            
            if (!CheckData()) return;
     
            //gọi report
            frmXemIn f = new frmXemIn();
            ERP_Library.Report.TongHopChamNgoaiGioBoPhanList data = ERP_Library.Report.TongHopChamNgoaiGioBoPhanList.GetTongHopChamNgoaiGioBoPhanLonHon200GioList((int)cmbTuKy.Value, (int)cmbDenKy.Value, (int)cmbBoPhan.Value, chkTheoKyChamCong.Checked, chkDuyet.Checked);

            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            rpt.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.reportTongHopNgoaiGioBPLonHon200Gio.rdlc";
            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_TongHopChamNgoaiGioBoPhanList", data));

            f.SetNguoiKy((int)cmbKyTen.Value);
            f.SetParameter("ThoiGian", "Từ " + cmbTuKy.Text.ToLower() + " đến " + cmbDenKy.Text.ToLower());
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            f.ShowDialog();
        }

        private void ultraButton_THTrong200Gio_Click(object sender, EventArgs e)
        {
            if (!CheckData()) return;

            string s, sub;
            frmXemIn f = new frmXemIn();
            ERP_Library.Report.TongHopChamNgoaiGioBoPhanList data = ERP_Library.Report.TongHopChamNgoaiGioBoPhanList.GetTongHopChamNgoaiGioBoPhanTrong200GioList((int)cmbTuKy.Value, (int)cmbDenKy.Value, (int)cmbBoPhan.Value, chkTheoKyChamCong.Checked, chkDuyet.Checked);

            s = Report_LoadString("PSC_ERP.Report.rptChiTietChamNgoaiGioBoPhan.rdlc", data.SoCot, 1, 7.3 - 2.1);
            sub = Report_NguoiKyTenA4();
            f.Report.LoadReportDefinition(new System.IO.StringReader(s));
            f.Report.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));

            f.SetDatabase("ERP_Library_Report_TongHopChamNgoaiGioBoPhanList", data);
            f.SetNguoiKy((int)cmbKyTen.Value);
            f.SetParameter("ThoiGian", "Từ " + cmbTuKy.Text.ToLower() + " đến " + cmbDenKy.Text.ToLower());
            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            f.ShowDialog();
        }

    }
}
