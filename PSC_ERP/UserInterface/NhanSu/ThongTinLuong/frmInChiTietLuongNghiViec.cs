
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using ERP_Library.Report;
using ERP_Library;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
namespace PSC_ERP
{
    public partial class frmInChiTietLuongNghiViec : Form
    {
        private ERP_Library.Report.InChiTietLuong_NhanVienList _data;
        BoPhanList _BoPhanList;
        ThongTinNhanVienTongHopList _nhanVienList;

        static int maBoPhan = 0;

        public frmInChiTietLuongNghiViec()
        {
            InitializeComponent();
           _BoPhanList = BoPhanList.GetBoPhanListByMaBoPhanChaNotNull();
            BoPhan itemBoPhan = BoPhan.NewBoPhan("Tất Cả");
            _BoPhanList.Insert(0, itemBoPhan);
            this.BindS_BoPhan.DataSource = _BoPhanList;
            cmbu_Bophan.DataSource = _BoPhanList;
            HamDungChung.VisibleColumn(cmbu_Bophan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
        }

        private void frmInChiTietLuongNghiViec_Load(object sender, EventArgs e)
        {           
           
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {

            if (cmbKyLuong.Value != null & cmbu_Bophan.Value != null)
            {
                BangLuongChiTietKy2List list = BangLuongChiTietKy2List.GetNgayTinhLuong((int)cmbKyLuong.Value, (int)cmbu_Bophan.Value,0);
                if (list.Count > 0)
                {
                    BangLuongChiTietKy2Child item = list[0];
                    if (item.NgayBDTinhLuong != DateTime.MinValue & item.NgayKTTinhLuong != DateTime.MinValue)
                    {
                        dtNgayBDTinhLuong.Value = Convert.ToDateTime(item.NgayBDTinhLuong.ToString("dd/MM/yyyy"));
                        dtNgayKTTinhLuong.Value = Convert.ToDateTime(item.NgayKTTinhLuong.ToString("dd/MM/yyyy"));
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value == null || ultraCombo_NhanVien.Value == null)
            {
                MessageBox.Show("Cần phải chọn kỳ lương và bộ phận để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            long nvid = 0;
            if (ultraCombo_NhanVien.Value != null)
                nvid = (long)ultraCombo_NhanVien.Value;

            frmXemIn f = new frmXemIn();
            f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptInChiTietLuong.rdlc";
            //f.Report.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptInChiTietLuong.rdlc";

            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "KyTinhLuong", cmbKyLuong.Text, "ThoiGian", "(Thu nhập từ " + txtTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày " + txtDenNgay.Value.ToString("dd/MM/yyyy") + ")");
            if (chkChuKy.Checked)
                f.SetParameter("ChuKy", GetChuKy());
            else
                f.SetParameter("ChuKy", "");
            _data = ERP_Library.Report.InChiTietLuong_NhanVienList.GetInChiTietLuong_NhanVienList(nvid, (int)cmbu_Bophan.Value, (int)cmbKyLuong.Value,1, true);
            f.SetDatabase("ERP_Library_Report_InChiTietLuong_NhanVienList", _data);
            f.Report.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(Report_SubreportProcessing);
            f.ShowDialog();
        }

        void Report_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {

            if (e.Parameters["MaNhanVien"].Values[0] != null)
            {
                long manv = Convert.ToInt32(e.Parameters["MaNhanVien"].Values[0]);
                ERP_Library.Report.InChiTietLuong_NhanVienChild nv = null;
                foreach (ERP_Library.Report.InChiTietLuong_NhanVienChild item in _data)
                    if (item.MaNhanVien == manv)
                    {
                        nv = item;
                        break;
                    }
                if (e.ReportPath == "rptInChiTietLuongTongHop")
                    e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_InChiTietLuong_TongHopList", nv.TongHop));
                if (e.ReportPath == "rptInChiTietLuongThuLao")
                    e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_InChiTietLuong_ThuLaoList", nv.ThuLao));
                if (e.ReportPath == "rptInChiTietLuongPhuCap")
                {

                    e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_InChiTietLuong_PhuCapList", nv.PhuCap));
                }
                if (e.ReportPath == "rptInChiTietLuongThueTamThu")
                {
                    e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_InChiTietLuong_ThueTamThuList", nv.ThueTamThu));
                }
            }
        }

        private void btnIn2Mat_Click(object sender, EventArgs e)
        {
            //if (cmbKyLuong.Value == null)
            //{
            //    MessageBox.Show("Cần phải chọn kỳ lương để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (MessageBox.Show("Chức năng này chỉ hổ trợ cho máy in 2 mặt,vui lòng chọn máy in có hổ trợ! \r\nBạn có muốn tiếp tục không?", "In báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PrintDialog dlg = new PrintDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ERP_Library.NhanVienComboList lst;
                    if (cmbu_Bophan.Value == null)
                        lst = ERP_Library.NhanVienComboList.GetNhanVienAll();
                    else
                        if (cmbu_Bophan.Value == null)
                            lst = ERP_Library.NhanVienComboList.GetNhanVienByMaBoPhan((int)cmbu_Bophan.Value);
                        else
                            lst = null;

                    List<Microsoft.Reporting.WinForms.ReportParameter> p = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                    p.Add(new Microsoft.Reporting.WinForms.ReportParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan));
                    p.Add(new Microsoft.Reporting.WinForms.ReportParameter("KyTinhLuong", cmbKyLuong.Text));
                    if (chkChuKy.Checked)
                        p.Add(new Microsoft.Reporting.WinForms.ReportParameter("ChuKy", GetChuKy()));
                    else
                        p.Add(new Microsoft.Reporting.WinForms.ReportParameter("ChuKy", ""));
                    if (lst != null)
                    {
                        if (MessageBox.Show("Có tổng cộng " + lst.Count.ToString() + " nhân viên sẽ được in báo cáo. Bạn có muốn tiếp tục không?", "In báo cáo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            foreach (ERP_Library.NhanVienComboListChild item in lst)
                            {
                                using (Microsoft.Reporting.WinForms.LocalReport rpt = new Microsoft.Reporting.WinForms.LocalReport())
                                {
                                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptInChiTietLuong.rdlc";
                                    //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptInChiTietLuong.rdlc";
                                    rpt.SetParameters(p);
                                    //ERP_Library.Report.InChiTietLuong_NhanVienList.DenNgay = (DateTime)dtNgayBDTinhLuong.Value;
                                    //ERP_Library.Report.InChiTietLuong_NhanVienList.TuNgay = (DateTime)dtNgayKTTinhLuong.Value;
                                    _data = InChiTietLuong_NhanVienList.GetInChiTietLuong_NhanVienList(item.MaNhanVien, item.MaBoPhan, (int)cmbKyLuong.Value,1, true);
                                    //_data = ERP_Library.Report.InChiTietLuong_NhanVienList.GetInChiTietLuong_NhanVienList(item.MaNhanVien, (int)cmbBoPhan.Value, (int)cmbKyLuong.Value, (DateTime)txtTuNgay.Value, (DateTime)txtTuNgay.Value);
                                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_InChiTietLuong_NhanVienList", _data));
                                    rpt.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(Report_SubreportProcessing);
                                }
                            }
                        }
                    }
                    else
                    {
                        using (Microsoft.Reporting.WinForms.LocalReport rpt = new Microsoft.Reporting.WinForms.LocalReport())
                        {
                            rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptInChiTietLuong.rdlc";
                            //rpt.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptInChiTietLuong.rdlc"; 
                            rpt.SetParameters(p);
                            //ERP_Library.Report.InChiTietLuong_NhanVienList.DenNgay = (DateTime)dtNgayBDTinhLuong.Value;
                            //ERP_Library.Report.InChiTietLuong_NhanVienList.TuNgay = (DateTime)dtNgayKTTinhLuong.Value;
                            _data = ERP_Library.Report.InChiTietLuong_NhanVienList.GetInChiTietLuong_NhanVienList((long)ultraCombo_NhanVien.Value, (int)cmbu_Bophan.Value, (int)cmbKyLuong.Value,1, true);
                            //_data = ERP_Library.Report.InChiTietLuong_NhanVienList.GetInChiTietLuong_NhanVienList((long)cmbNhanVien.Value, (int)cmbBoPhan.Value, (int)cmbKyLuong.Value, (DateTime)txtTuNgay.Value, (DateTime)txtTuNgay.Value);
                            rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_InChiTietLuong_NhanVienList", _data));
                            rpt.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(Report_SubreportProcessing);
                            PrintReport(rpt, dlg.PrinterSettings);
                        }
                    }
                }
            }
        }

        private string GetChuKy()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
            string ngay = DateTime.Today.ToString("'Tp.HCM, Ngày 'dd' tháng 'MM' năm 'yyyy");
            string s;
            return string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.BptTieude, nguoiky.BptTen);
        }


        #region "Xử lý in reportting, bị lỗi không dàn trang được"
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private void PrintReport(Microsoft.Reporting.WinForms.LocalReport rpt, PrinterSettings pst)
        {
            Export(rpt);

            m_currentPageIndex = 0;
            Print(pst);
            DisposeStream();
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new FileStream(name + "." + fileNameExtension, FileMode.Create);
            //Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private void Export(LocalReport report)
        {
            string deviceInfo =
              "<DeviceInfo>" +
              "  <OutputFormat>EMF</OutputFormat>" +
                //"  <PageWidth>21cm</PageWidth>" +
                //"  <PageHeight>29.7cm</PageHeight>" +
                //"  <MarginTop>5mm</MarginTop>" +
                //"  <MarginLeft>5mm</MarginLeft>" +
                //"  <MarginRight>5mm</MarginRight>" +
                //"  <MarginBottom>5mm</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);

            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, 0, 0);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print(PrinterSettings pst)
        {
            if (m_streams == null || m_streams.Count == 0)
                return;

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings = pst;
            if (!printDoc.PrinterSettings.IsValid)
            {
                return;
            }
            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            printDoc.Print();
        }

        private void DisposeStream()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }


        #endregion
             
        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong ky = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                if (ky.MaKyChinh.HasValue)
                {
                    txtTuNgay.Value = new DateTime(ky.NgayKetThuc.Year, ky.NgayKetThuc.Month, 16);
                    txtDenNgay.Value = ky.NgayKetThuc;
                }
                else
                {
                    txtTuNgay.Value = new DateTime(ky.NgayBatDau.Year, ky.NgayBatDau.Month, 16);
                    txtTuNgay.Value = txtTuNgay.Value.AddMonths(1);
                    txtDenNgay.Value = new DateTime(ky.NgayKetThuc.Year, ky.NgayKetThuc.Month, 15);
                    txtDenNgay.Value = txtDenNgay.Value.AddMonths(1);
                }
                if (cmbKyLuong.Value != null & cmbu_Bophan.Value != null)
                {
                    BangLuongChiTietKy2Child item = BangLuongChiTietKy2List.GetNgayTinhLuong((int)cmbKyLuong.Value, (int)cmbu_Bophan.Value,0)[0];
                    if (item.NgayBDTinhLuong != DateTime.MinValue || item.NgayKTTinhLuong != DateTime.MinValue)
                    {
                        dtNgayBDTinhLuong.Value = item.NgayBDTinhLuong;
                        dtNgayKTTinhLuong.Value = item.NgayKTTinhLuong;
                    }
                }
            }
        }

      
        private void cmbu_Bophan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbu_Bophan.ActiveRow != null)
            {
                maBoPhan = (int)cmbu_Bophan.ActiveRow.Cells["MaBoPhan"].Value;
            }
            //_nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, checkBox_NghiHuu.Checked);
            _nhanVienList = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopListByTinhLuong(maBoPhan, true);
            this.ultraCombo_NhanVien.DataSource = _nhanVienList;
            ultraCombo_NhanVien.DisplayMember="TenNhanVien";
            ultraCombo_NhanVien.ValueMember = "MaNhanVien";
            HamDungChung.VisibleColumn(ultraCombo_NhanVien.DisplayLayout.Bands[0], "MaQLNhanVien", "TenNhanVien");
        }

        private void cmbu_Bophan_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {

        }

        private void ultraCombo_NhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            FilterCombo f = new FilterCombo(ultraCombo_NhanVien, "TenNhanVien");
            foreach (UltraGridColumn col in this.ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
                col.Hidden = true;
            }
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Hidden = false;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.Caption = "Mã Nhân Viên";
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["MaQLNhanVien"].Header.VisiblePosition = 1;

            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhận Viên";
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 200;
            ultraCombo_NhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 2;
        }
    }
}
