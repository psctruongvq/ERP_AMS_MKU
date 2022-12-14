using ERP_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmBaoCaoPhuCap : Form
    {
        private DataSet dataSetDEV = new DataSet();
        private int UserId = ERP_Library.Security.CurrentUser.Info.UserID;

        public frmBaoCaoPhuCap()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmBaoCaoPhuCap_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            foreach (ERP_Library.NganHang nh in ERP_Library.NganHangList.GetNganHangListByCongTy())
                cmbNganHang.Items.ValueList.ValueListItems.Add(nh.MaNganHang, nh.TenNganHang);
            cmbNganHang.Value = 0;
            ERP_Library.BoPhanList bp = ERP_Library.BoPhanList.GetBoPhanList();
            ERP_Library.BoPhan allbp = ERP_Library.BoPhan.NewBoPhan("Tất cả");
            bp.Insert(0,allbp);
            cmbBoPhan.DataSource = bp;
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbBoPhan.Value = 0;
            cmbLoaiNV.Value = 0;

            treeReport.ExpandAll();
            foreach (ERP_Library.NhomPhuCap item in ERP_Library.NhomPhuCapList.GetNhomPhuCapList())
                cmbNhomPC.Items.Add(item.MaNhom, item.Ten);
            cmbNhomPC.Value = 0;
            cmbKyTen.Value = 0;
            cmbHinhThuc.Value = 0;

        }

        private void treeReport_AfterSelect(object sender, TreeViewEventArgs e)
        {
            lblPhanLoai.Visible = false;
            cmbLoaiNV.Visible = false;
            lblBoPhan.Visible = false;
            cmbBoPhan.Visible = false;
            lblHinhThuc.Visible = false;
            cmbHinhThuc.Visible = false;
            lblNganHang.Visible = false;
            cmbNganHang.Visible = false;
            lblPhuCap.Visible = false;
            cmbPhuCap.Visible = false;
            lblNhomPC.Visible = false;
            cmbNhomPC.Visible = false;

            if (e.Node.Nodes.Count == 0)
            {
                string s = "";
                int yl = 82, yc = 74, c = 0;
                if (e.Node.Tag is string) s = (string)e.Node.Tag;
                if (s.Contains("NhomPC"))
                {
                    lblNhomPC.Top = yl + 28 * c;
                    cmbNhomPC.Top = yc + 28 * c;
                    lblNhomPC.Visible = true;
                    cmbNhomPC.Visible = true;
                    c++;
                }

                if (s.Contains("PhuCap"))
                {
                    lblPhuCap.Top = yl + 28 * c;
                    cmbPhuCap.Top = yc + 28 * c;
                    lblPhuCap.Visible = true;
                    cmbPhuCap.Visible = true;
                    c++;
                }

                if (s.Contains("LoaiNV"))
                {
                    lblPhanLoai.Top = yl + 28 * c;
                    cmbLoaiNV.Top = yc + 28 * c;
                    lblPhanLoai.Visible = true;
                    cmbLoaiNV.Visible = true;
                    c++;
                }

                if (s.Contains("HinhThuc"))
                {
                    lblHinhThuc.Top = yl + 28 * c;
                    cmbHinhThuc.Top = yc + 28 * c;
                    lblHinhThuc.Visible = true;
                    cmbHinhThuc.Visible = true;
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

                if (s.Contains("NganHang"))
                {
                    lblNganHang.Top = yl + 28 * c;
                    cmbNganHang.Top = yc + 28 * c;
                    lblNganHang.Visible = true;
                    cmbNganHang.Visible = true;
                    c++;
                }

                btnReport.Enabled = true;
            }
            else
            {
                btnReport.Enabled = false;
            }
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                cmbKyPC.Items.Clear();
                cmbKyPC.Items.Add(0, "Tất cả");
                foreach (ERP_Library.KyTinhLuong item in ERP_Library.KyTinhLuongList.GetKyTinhPhuCap((int)cmbKyLuong.Value))
                    cmbKyPC.Items.Add(item.MaKy, item.TenKy);
                cmbKyPC.Value = 0;
            }
        }

        ERP_Library.Report.ChiTietPhuCapNhanVienList _ChiTietPhuCapNhanVienList;
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (treeReport.SelectedNode.Name == "NodeBangKeTruyLinhTruyThuNhanVien")
            {
                In_Report_BangKeChiTietPhuCapTruyLinhTruyThu();
            }
            else if (treeReport.SelectedNode.Name == "NodeBangKeTongHopPhuCapTruyLinhTruyThuNhanVien")
            {
                In_Report_BangKeTongHopPhuCapTruyLinhTruyThu();
            }
            else
            {
                if (cmbKyLuong.Value == null)
                {
                    MessageBox.Show("Bạn chưa chọn Tháng lương", "Tháng lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cmbKyPC.Value == null)
                {
                    MessageBox.Show("Bạn chưa chọn kỳ của phụ cấp", "Tháng lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cmbNganHang.Visible && cmbNganHang.Value == null)
                {
                    MessageBox.Show("Bạn chưa chọn ngân hàng", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cmbPhuCap.Visible && cmbPhuCap.Value == null)
                {
                    MessageBox.Show("Bạn chưa chọn phụ cấp", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cmbNhomPC.Visible && cmbNhomPC.Value == null)
                {
                    MessageBox.Show("Bạn chưa chọn nhóm phụ cấp", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                //if (cmbHinhThuc.Value == null)
                //{
                //    MessageBox.Show("Bạn chưa chọn hình thức thanh toán", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //báo cáo
                int bpid = (int)cmbBoPhan.Value;
                int kypc = (int)cmbKyPC.Value;
                frmXemIn f = new frmXemIn();
                int MaKy = (int)cmbKyLuong.Value;
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                rpt.DataSources.Clear();
                string s, sub;
                string diengiai = string.Empty;

                switch (treeReport.SelectedNode.Name)
                {
                    case "node01":
                        //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptChiTietPhuCapAnTruaHanhChinhTNKVQL.rdlc";
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietPhuCapAnTruaHanhChinhTNKVQL.rdlc";
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_ChiTietPhuCapAT_HC_TNKVQLList", ERP_Library.ChiTietPhuCapAT_HC_TNKVQLList.GetChiTietPhuCapAT_HC_TNKVQLList(MaKy, kypc, (int)cmbLoaiNV.Value, bpid, (int)cmbNganHang.Value)));
                        break;
                    case "node02":
                        //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptTongHopPhuCapAnTruaHanhChinhTNKVQL.rdlc";
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopPhuCapAnTruaHanhChinhTNKVQL.rdlc";
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_TongHopPhuCapAT_HC_TNKVQLList", ERP_Library.TongHopPhuCapAT_HC_TNKVQLList.GetTongHopPhuCapAT_HC_TNKVQLList(MaKy, kypc, (int)cmbLoaiNV.Value)));
                        break;
                    case "node03":
                        //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptChiTietPhuCapNhanVien.rdlc";
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietPhuCapNhanVien.rdlc";
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChiTietPhuCapNhanVienList", ERP_Library.Report.ChiTietPhuCapNhanVienList.GetChiTietPhuCapNhanVienList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbPhuCap.Value, (int)cmbLoaiNV.Value, bpid, (int)cmbNganHang.Value)));
                        break;
                    case "nodeChiTietThue":
                        //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptChiTietPhuCapNhanVien.rdlc";
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietPhuCapNhanVienThueTamThu.rdlc";
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChiTietPhuCapNhanVienList", ERP_Library.Report.ChiTietPhuCapNhanVienList.GetChiTietPhuCapNhanVienList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbPhuCap.Value, (int)cmbLoaiNV.Value, bpid, (int)cmbNganHang.Value)));
                        break;
                    case "node04":
                        //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptTongHopPhuCapNhanVien.rdlc";
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopPhuCapNhanVien.rdlc";
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_TongHopPhuCapNhanVienList", ERP_Library.Report.TongHopPhuCapNhanVienList.GetTongHopPhuCapNhanVienList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbPhuCap.Value, (int)cmbLoaiNV.Value)));
                        break;
                    case "node05":
                        //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptChiTietPhuCapNganHang.rdlc";
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietPhuCapNganHang.rdlc";
                        _ChiTietPhuCapNhanVienList = ERP_Library.Report.ChiTietPhuCapNhanVienList.GetBaoCaoNganHang(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbPhuCap.Value, (int)cmbLoaiNV.Value, bpid, (int)cmbNganHang.Value);
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChiTietPhuCapNhanVienList", _ChiTietPhuCapNhanVienList));
                        break;
                    case "node06":
                        //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptTongHopPhuCapNganHang.rdlc";
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopPhuCapNganHang.rdlc";
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_TongHopPhuCapNhanVienList", ERP_Library.Report.TongHopPhuCapNhanVienList.GetTongHopPhuCapNganHang(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbPhuCap.Value, (int)cmbLoaiNV.Value, (int)cmbBoPhan.Value)));
                        break;
                    case "node07":
                        //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptTongHopPhuCapBoPhanNganHang.rdlc";
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopPhuCapBoPhanNganHang.rdlc";
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_TongHopPhuCapNhanVienList", ERP_Library.Report.TongHopPhuCapNhanVienList.GetTongHopNganHang(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbPhuCap.Value, (int)cmbLoaiNV.Value)));
                        break;
                    case "node08":
                        ERP_Library.Report.TongHopPhuCapTrichNgangList tonghopa3 = ERP_Library.Report.TongHopPhuCapTrichNgangList.GetTongHopPhuCapTrichNgangList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbNganHang.Value, (int)cmbHinhThuc.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptTongHopPhuCapTrichNgang.rdlc", tonghopa3.SoCot + 1, 0.75, 15.25 - 1.625);
                        sub = Report_NguoiKyTenA3();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA3", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_TongHopPhuCapTrichNgangList", tonghopa3));
                        break;
                    case "node09":
                        ERP_Library.Report.ChiTietPhuCapNgoaiGioList chitietngoaigio = ERP_Library.Report.ChiTietPhuCapNgoaiGioList.GetChiTietPhuCapNgoaiGioList(MaKy, kypc, bpid, (int)cmbNganHang.Value, (int)cmbNhomPC.Value, (int)cmbLoaiNV.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptChiTietPhuCapNgoaiGio.rdlc", chitietngoaigio.SoCot, 0.5 + 0.875, 15 - 1.375);
                        sub = Report_NguoiKyTenA3();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA3", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChiTietPhuCapNgoaiGioList", chitietngoaigio));
                        break;
                    case "node10":
                        ERP_Library.Report.TongHopPhuCapNgoaiGioList tonghopngoaigio = ERP_Library.Report.TongHopPhuCapNgoaiGioList.GetTongHopPhuCapNgoaiGioList(MaKy, kypc, (int)cmbNganHang.Value, (int)cmbNhomPC.Value, (int)cmbLoaiNV.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptTongHopPhuCapNgoaiGio.rdlc", tonghopngoaigio.SoCot + 1, 0.5 + 0.75, 15.125 - 1.625);
                        sub = Report_NguoiKyTenA3();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA3", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_TongHopPhuCapNgoaiGioList", tonghopngoaigio));
                        break;
                    case "chitiettrichngang":
                        ERP_Library.Report.ChiTietPhuCapTrichNgangList chitieta3 = ERP_Library.Report.ChiTietPhuCapTrichNgangList.GetChiTietPhuCapTrichNgangList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbBoPhan.Value, (int)cmbLoaiNV.Value, (int)cmbNganHang.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptChiTietPhuCapTrichNgang.rdlc", chitieta3.SoCot, 0.875, 15.25 - 1.75);
                        sub = Report_NguoiKyTenA3();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA3", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChiTietPhuCapTrichNgangList", chitieta3));
                        break;
                    case "chitiettrichngangA4":
                        ERP_Library.Report.ChiTietPhuCapTrichNgangList chitieta4 = ERP_Library.Report.ChiTietPhuCapTrichNgangList.GetChiTietPhuCapTrichNgangList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbBoPhan.Value, (int)cmbLoaiNV.Value, (int)cmbNganHang.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptChiTietPhuCapTrichNgangA4.rdlc", chitieta4.SoCot, 0.875, 6);
                        sub = Report_NguoiKyTenA4();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChiTietPhuCapTrichNgangList", chitieta4));
                        break;
                    case "chitiettrichngangA4Trong200Gio":
                        diengiai = "Ngoài giờ (trong 200 giờ)";
                        ERP_Library.Report.ChiTietPhuCapTrichNgangList chitieta4Trong200Gio = ERP_Library.Report.ChiTietPhuCapTrichNgangList.GetChiTietPhuCapTrichNgangTrong200GioList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbBoPhan.Value, (int)cmbLoaiNV.Value, (int)cmbNganHang.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptChiTietPhuCapTrichNgangA4.rdlc", chitieta4Trong200Gio.SoCot, 0.875, 6);
                        sub = Report_NguoiKyTenA4();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChiTietPhuCapTrichNgangList", chitieta4Trong200Gio));
                        break;
                    case "chitiettrichngangA4LonHon200Gio":
                        diengiai = "Ngoài giờ (vượt 200 giờ)";
                        ERP_Library.Report.ChiTietPhuCapTrichNgangList chitieta4LonHon200Gio = ERP_Library.Report.ChiTietPhuCapTrichNgangList.GetChiTietPhuCapTrichNgangLonHon200GioList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbBoPhan.Value, (int)cmbLoaiNV.Value, (int)cmbNganHang.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptChiTietPhuCapTrichNgangA4.rdlc", chitieta4LonHon200Gio.SoCot, 0.875, 6);
                        sub = Report_NguoiKyTenA4();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChiTietPhuCapTrichNgangList", chitieta4LonHon200Gio));
                        break;
                    case "node11":
                        ERP_Library.Report.TongHopPhuCapTrichNgangList tonghopa4 = ERP_Library.Report.TongHopPhuCapTrichNgangList.GetTongHopPhuCapTrichNgangList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbNganHang.Value, (int)cmbHinhThuc.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptTongHopPhuCapTrichNgangA4.rdlc", tonghopa4.SoCot + 1, 0.75, 6);
                        sub = Report_NguoiKyTenA4();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_TongHopPhuCapTrichNgangList", tonghopa4));
                        break;

                    case "TongHopTheoNhomPhuCapTrong200":
                        diengiai = "Ngoài giờ (trong 200 giờ)";
                        ERP_Library.Report.TongHopPhuCapTrichNgangList tonghopa4trong200gio = ERP_Library.Report.TongHopPhuCapTrichNgangList.GetTongHopPhuCapTrichNgangTrong200GioList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbNganHang.Value, (int)cmbHinhThuc.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptTongHopPhuCapTrichNgangA4.rdlc", tonghopa4trong200gio.SoCot + 1, 0.75, 6);
                        sub = Report_NguoiKyTenA4();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_TongHopPhuCapTrichNgangList", tonghopa4trong200gio));
                        break;

                    case "TongHopTheoNhomPhuCapLonHon200":
                        diengiai = "Ngoài giờ (vượt 200 giờ)";

                        ERP_Library.Report.TongHopPhuCapTrichNgangList tonghopa4lonhon200gio = ERP_Library.Report.TongHopPhuCapTrichNgangList.GetTongHopPhuCapTrichNgangLonHon200GioList(MaKy, kypc, (int)cmbNhomPC.Value, (int)cmbNganHang.Value, (int)cmbHinhThuc.Value);
                        s = Report_LoadString("PSC_ERP.Report.rptTongHopPhuCapTrichNgangA4.rdlc", tonghopa4lonhon200gio.SoCot + 1, 0.75, 6);
                        sub = Report_NguoiKyTenA4();
                        rpt.LoadReportDefinition(new System.IO.StringReader(s));
                        rpt.LoadSubreportDefinition("rptNguoiKyTenA4", new System.IO.StringReader(sub));
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_TongHopPhuCapTrichNgangList", tonghopa4lonhon200gio));
                        break;

                    case "chitietnganhang2nhom":
                        //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptChiTietPhuCapNganHang2Nhom.rdlc";
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptChiTietPhuCapNganHang2Nhom.rdlc";
                        rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_ChiTietPhuCapNhanVienList", ERP_Library.Report.ChiTietPhuCapNhanVienList.GetBaoCaoNganHang2Nhom(MaKy, kypc, (int)cmbLoaiNV.Value, bpid, (int)cmbNganHang.Value)));
                        break;
                    default:
                        return;
                }
                Microsoft.Reporting.WinForms.ReportParameter _ky = null;
                _ky = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong", cmbKyLuong.Text.ToUpper());
                string loai = "";
                if (kypc != 0) loai = "Kỳ phụ cấp : " + cmbKyPC.Text + " - ";
                if (cmbLoaiNV.Value != null && cmbLoaiNV.Visible && (int)cmbLoaiNV.Value != 0) loai += "Đối tượng : " + cmbLoaiNV.Text;
                if (cmbHinhThuc.Value != null && (int)cmbHinhThuc.Value != 0 && cmbHinhThuc.Visible)
                {
                    if (loai != "")
                        loai += "\r\nHình thức : " + cmbHinhThuc.Text;
                    else
                        loai = "Hình thức : " + cmbHinhThuc.Text;
                }
                if (bpid != 0 && cmbBoPhan.Visible)
                {
                    if (loai != "")
                        loai += "\r\nBộ phận : " + cmbBoPhan.Text;
                    else
                        loai = "Bộ phận : " + cmbBoPhan.Text;
                }
                if (cmbNganHang.Value != null && (int)cmbNganHang.Value != 0 && cmbNganHang.Visible)
                {
                    if (loai != "")
                        loai += "\r\nNgân hàng : " + cmbNganHang.Text + "( " + ERP_Library.CongTy_NganHang.GetCongTy_NganHangByMaNganHang((int)cmbNganHang.Value).SoTaiKhoan + " )";
                    else
                        loai = "Ngân hàng : " + cmbNganHang.Text + "( " + ERP_Library.CongTy_NganHang.GetCongTy_NganHangByMaNganHang((int)cmbNganHang.Value).SoTaiKhoan + " )";
                }
                if (cmbNhomPC.Visible)
                {
                    s = "";
                    if (!cmbPhuCap.Visible || cmbPhuCap.Value == null || (int)cmbPhuCap.Value == 0)
                        s = cmbNhomPC.Text;//+ "\r\n" + diengiai;
                    else
                        s = cmbPhuCap.Text;

                    if (loai != "")
                        loai += "\r\nPhụ cấp : " + s + "\r\n" + diengiai;
                    else
                        loai = "Phụ cấp : " + s + "\r\n" + diengiai;
                }
                Microsoft.Reporting.WinForms.ReportParameter _loai = new Microsoft.Reporting.WinForms.ReportParameter("PhanLoai", loai);
                if (treeReport.SelectedNode.Name == "node05")
                {
                    string vietbangchu = string.Empty;
                    decimal tongtien = 0;
                    foreach (ERP_Library.Report.ChiTietPhuCapNhanVienChild ct in _ChiTietPhuCapNhanVienList)
                    {
                        tongtien += ct.SoTien;
                    }
                    vietbangchu = HamDungChung.DocTien(tongtien);
                    Microsoft.Reporting.WinForms.ReportParameter _vietBangChu = new Microsoft.Reporting.WinForms.ReportParameter("VietBangChu", vietbangchu);
                    rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { _ky, _loai, _vietBangChu });
                }
                else
                {

                    rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { _ky, _loai });

                }
                f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
                f.SetNguoiKy((int)cmbKyTen.Value);
                f.ShowDialog();
            }
        }

        private void cmbNhomPC_ValueChanged(object sender, EventArgs e)
        {
            cmbPhuCap.Items.Clear();
            cmbPhuCap.Items.Add(0, "Tất cả");
            foreach (ERP_Library.LoaiPhuCapChild item in ERP_Library.LoaiPhuCapList.GetLoaiPhuCapByMaNhom((int)cmbNhomPC.Value))
            {
                cmbPhuCap.Items.Add(item.MaLoaiPhuCap, item.TenLoaiPhuCap);
            }
            cmbPhuCap.Value = 0;
        }

        private string Report_LoadString(string reportname, int socot, double colwidth, double space)
        {
            string s = "";
            decimal l = 0;
            l = Convert.ToDecimal((space - (colwidth * socot))/2);
            if (l < 0) l = 0;
            System.IO.Stream m = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(reportname);
            byte[] a = new byte[m.Length];
            m.Read(a, 0, (int) m.Length);
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

        private string Report_NguoiKyTenA3()
        {
            string s = "";
            System.IO.Stream m = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PSC_ERP.Report.rptNguoiKyTenA3.rdlc");
            byte[] a = new byte[m.Length];
            m.Read(a, 0, (int)m.Length);
            m.Close();
            s = System.Text.Encoding.UTF8.GetString(a);
            return s;
        }


        #region Dev

        public bool Method_Report_BangKeChiTietPhuCapTruyLinhTruyThu()
        {
            int maKyTinhLuong = 0;
            int maKyPhuCap = 0;
            int maNganHang = 0;
            int maBoPhan = 0;
            int loaiNV = 0;
            int maHinhThuc = 2;
            if (cmbKyLuong.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn Tháng lương", "Tháng lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbKyPC.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn kỳ của phụ cấp", "Tháng lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbNganHang.Visible && cmbNganHang.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn ngân hàng", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else maNganHang = (int)cmbNganHang.Value;

            if (cmbHinhThuc.Visible && cmbHinhThuc.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn Hình thức", "Hình thức", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else maHinhThuc = (int)cmbHinhThuc.Value;

            maBoPhan = (int)cmbBoPhan.Value;
            maKyPhuCap = (int)cmbKyPC.Value;
            maKyTinhLuong = (int)cmbKyLuong.Value;
            loaiNV = (int)cmbLoaiNV.Value;

            dataSetDEV = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBangTongHopChiTietVatTuTheoKho
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_BangKeChiTietPhuCapTruyLinhTruyThu";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", maKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@LoaiNV", loaiNV);
                    cm.Parameters.AddWithValue("@MaHinhThuc", maHinhThuc);
                    cm.Parameters.AddWithValue("@UserID", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_BangKeChiTietPhuCapTruyLinhTruyThu;1";
                    dataSetDEV.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                DataTable dtNgay = new DataTable();
                dtNgay.TableName = "TuNgay_DenNgay";
                dtNgay.Columns.Add("KyTinhLuong", typeof(string));
                dtNgay.Columns.Add("HinhThuc", typeof(string));
                dtNgay.Rows.Add(cmbKyLuong.Text, maHinhThuc==0 ? "Tiền mặt" : (maHinhThuc==1 ? "Chuyển khoản NV" : "Tất cả"));
                dataSetDEV.Tables.Add(dtNgay);

                //using (SqlCommand cm = cn.CreateCommand())
                //{
                //    cm.CommandType = CommandType.StoredProcedure;
                //    cm.CommandText = "spd_ReportHeaderAndFooter";
                //    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    dt.TableName = "spd_ReportHeaderAndFooter";
                //    dataSetDEV.Tables.Add(dt);
                //}

            }//us 
            return true;
        }//END InBangTongHopChiTietVatTuTheoKho

        private void In_Report_BangKeChiTietPhuCapTruyLinhTruyThu()
        {
            ReportTemplate _report;
            _report = ReportTemplate.GetReportTemplate("ID_Report_BangKeChiTietPhuCapTruyLinhTruyThu");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSetDEV);
                frm.Show();
            }
        }


        public bool Method_Report_BangKeTongHopPhuCapTruyLinhTruyThu()
        {
            int maKyTinhLuong = 0;
            int maKyPhuCap = 0;
            int maNganHang = 0;
            int maBoPhan = 0;
            int loaiNV = 0;
            int maHinhThuc = 2;
            if (cmbKyLuong.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn Tháng lương", "Tháng lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbKyPC.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn kỳ của phụ cấp", "Tháng lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (cmbNganHang.Visible && cmbNganHang.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn ngân hàng", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else maNganHang = (int)cmbNganHang.Value;
            if (cmbHinhThuc.Visible && cmbHinhThuc.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn Hình thức", "Hình thức", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else maHinhThuc = (int)cmbHinhThuc.Value;

            //maBoPhan = (int)cmbBoPhan.Value;
            maKyPhuCap = (int)cmbKyPC.Value;
            maKyTinhLuong = (int)cmbKyLuong.Value;
            loaiNV = (int)cmbLoaiNV.Value;

            dataSetDEV = new DataSet();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {

                cn.Open();
                //tao InBangTongHopChiTietVatTuTheoKho
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_BangKeChiTietPhuCapTruyLinhTruyThu";
                    cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                    cm.Parameters.AddWithValue("@MaKyPhuCap", maKyPhuCap);
                    cm.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@LoaiNV", loaiNV);
                    cm.Parameters.AddWithValue("@MaHinhThuc", maHinhThuc);
                    cm.Parameters.AddWithValue("@UserID", UserId);
                    SqlDataAdapter da = new SqlDataAdapter(cm);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dt.TableName = "spd_Report_BangKeChiTietPhuCapTruyLinhTruyThu;1";
                    dataSetDEV.Tables.Add(dt);
                }
                //tao bang_REPORT_ReportHeader 

                DataTable dtNgay = new DataTable();
                dtNgay.TableName = "TuNgay_DenNgay";
                dtNgay.Columns.Add("KyTinhLuong", typeof(string));
                dtNgay.Columns.Add("HinhThuc", typeof(string));
                dtNgay.Rows.Add(cmbKyLuong.Text, maHinhThuc == 0 ? "Tiền mặt" : (maHinhThuc == 1 ? "Chuyển khoản NV" : "Tất cả"));
                dataSetDEV.Tables.Add(dtNgay);

                //using (SqlCommand cm = cn.CreateCommand())
                //{
                //    cm.CommandType = CommandType.StoredProcedure;
                //    cm.CommandText = "spd_ReportHeaderAndFooter";
                //    cm.Parameters.AddWithValue("@MaNguoiLap", UserId);
                //    SqlDataAdapter da = new SqlDataAdapter(cm);
                //    DataTable dt = new DataTable();
                //    da.Fill(dt);
                //    dt.TableName = "spd_ReportHeaderAndFooter";
                //    dataSetDEV.Tables.Add(dt);
                //}

            }//us 
            return true;
        }//END InBangTongHopChiTietVatTuTheoKho

        private void In_Report_BangKeTongHopPhuCapTruyLinhTruyThu()
        {
            ReportTemplate _report;
            _report = ReportTemplate.GetReportTemplate("ID_Report_BangKeTongHopPhuCapTruyLinhTruyThu");
            if (_report != null)
            {
                DateTime dtDenNgay = DateTime.Today;
                frmReport frm = new frmReport();

                ReportTemplate _reportTemplate = ReportTemplate.GetReportTemplate(_report.Id, UserId, dtDenNgay);
                if (_reportTemplate.Id == string.Empty)
                {
                    _reportTemplate.Id = _report.Id;
                    _reportTemplate.UserID = UserId;
                    _reportTemplate.DenNgay = dtDenNgay;
                }
                if (_report.TenPhuongThuc != "")
                {
                    this.GetType().GetMethod(_report.TenPhuongThuc).Invoke(this, null);
                }

                frm.HienThiReport(_reportTemplate, dataSetDEV);
                frm.Show();
            }
        }
        #endregion//Dev
    }
}