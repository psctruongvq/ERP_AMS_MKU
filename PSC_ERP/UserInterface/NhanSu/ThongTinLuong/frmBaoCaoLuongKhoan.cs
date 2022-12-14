using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmBaoCaoLuongKhoan : Form
    {
        private int Loai=1;
        public frmBaoCaoLuongKhoan()
        {
            InitializeComponent();
        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBaoCaoBangLuong_Load(object sender, EventArgs e)
        {
            if (!ERP_Library.Security.CurrentUser.IsAdminNhanSu)
            {
                treeReport.Nodes.Clear();
                treeReport.Nodes.Add("nodeLuongKhoan", "Bảng kê lương nhân viên loại khoán, hợp đồng");
                treeReport.Nodes[0].Tag = "BoPhan;LoaiNV";

                treeReport.Nodes.Add("nodeLuongKhoanKoBH", "Bảng kê lương nhân viên loại khoán, hợp đồng (Không bảo hiểm)");
                treeReport.Nodes[1].Tag = "BoPhan;LoaiNV";          
            }
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
            cmbNganHang.DataSource = ERP_Library.NganHangList.GetNganHangListByCongTy();
            ERP_Library.BoPhanList bp = ERP_Library.BoPhanList.GetBoPhanList();
            ERP_Library.BoPhan allbp = ERP_Library.BoPhan.NewBoPhan("Tất cả");
            bp.Insert(0,allbp);
            cmbBoPhan.DataSource = bp;
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbBoPhan.Value = 0;
            //foreach (ERP_Library.BoPhan i in ERP_Library.BoPhanList.DanhSachBoPhanTinhLuong())
            //    cmbBoPhan.Items.Add(i.MaBoPhan, i.TenBoPhan);

            treeReport.ExpandAll();
            txtQui.Value = (DateTime.Today.Month - 1) / 3 + 1;
            txtNam.Value = DateTime.Today.Year;
            cmbKyTen.Value = 0;
            cmbDieuKien.Value = 0;

            cmbLoaiNV.Value = "All";
            cmbHinhThuc.Value = "All";
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
            lblQui.Visible = false;
            txtQui.Visible = false;
            lblNam.Visible = false;
            txtNam.Visible = false;
            lblDieuKien.Visible = false;
            cmbDieuKien.Visible = false;

            if (e.Node.Nodes.Count == 0)
            {
                string s = "";
                int yl = 82, yc = 74, c = 0;
                if (e.Node.Tag is string) s = (string)e.Node.Tag;
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

                if (s.Contains("DieuKien"))
                {
                    lblDieuKien.Top = yl + 28 * c;
                    cmbDieuKien.Top = yc + 28 * c;
                    lblDieuKien.Visible = true;
                    cmbDieuKien.Visible = true;
                    c++;
                }

                if (s.Contains("Qui"))
                {
                    lblQui.Top = lblTuNgay.Top;
                    txtQui.Top = txtTuNgay.Top;
                    lblNam.Top = lblQui.Top;
                    txtNam.Top = txtQui.Top;
                    lblKyLuong.Visible = false;
                    cmbKyLuong.Visible = false;
                    lblTuNgay.Visible = false;
                    txtTuNgay.Visible = false;
                    lblDenNgay.Visible = false;
                    txtDenNgay.Visible = false;
                    lblQui.Visible = true;
                    txtQui.Visible = true;
                    lblNam.Visible = true;
                    txtNam.Visible = true;
                }
                else
                {
                    lblKyLuong.Visible = true;
                    cmbKyLuong.Visible = true;
                    lblTuNgay.Visible = true;
                    txtTuNgay.Visible = true;
                    lblDenNgay.Visible = true;
                    txtDenNgay.Visible = true;
                }

                btnReport.Enabled = true;
            }
            else
            {
                btnReport.Enabled = false;
            }

            if (e.Node.Name == "nodeSoNganHang" || e.Node.Name == "nodeSoNganHangChiTiet")
            {
                cmbDieuKien.Value = 1;
            }
            if (e.Node.Name == "nodeLuongKhoan" || e.Node.Name == "nodeLuongKhoanKoCoBH" )
                cmbLoaiNV.Value = "KhoanKTN";
             if (e.Node.Name == "NodeCTV")
                 cmbLoaiNV.Value = "CTV";
           
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.SelectedItem != null)
            {
                ERP_Library.KyTinhLuong i = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                txtTuNgay.Value = i.NgayBatDau.ToString("dd/MM/yyyy");
                txtDenNgay.Value = i.NgayKetThuc.ToString("dd/MM/yyyy");
            }
            else
            {
                txtTuNgay.Text = "";
                txtDenNgay.Text = "";
            }
        }
        ERP_Library.Report.BangLuongChiTietKy1List _BangLuongChiTietKy1List;
        ERP_Library.Report.BangLuongChiTietKy2List _BangLuongChiTietKy2List; 
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (treeReport.SelectedNode == null) return;
            if (cmbKyLuong.Value == null && cmbKyLuong.Visible)
            {
                MessageBox.Show("Bạn chưa chọn Tháng lương", "Tháng lương", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cmbNganHang.Visible && cmbNganHang.Value == null)
            {
                MessageBox.Show("Bạn chưa chọn ngân hàng", "Ngân hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //báo cáo
            Nullable<int> bpid = null;
            if ((int)cmbBoPhan.Value != 0)
                bpid = (int)cmbBoPhan.Value;
            frmXemIn f = new frmXemIn();
            int MaKy = 0;
            if (cmbKyLuong.Value != null) MaKy = (int)cmbKyLuong.Value;
            int dot = 1;

            Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
            switch (treeReport.SelectedNode.Name)
            {
                    //kỳ 1
                case "nodeTongHopBoPhan":
                    if (cmbLoaiNV.Value is string && (string)cmbLoaiNV.Value == "VV")
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1BoPhanVuViec";
                    else
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1BoPhan";
                    if (ERP_Library.Security.CurrentUser.Info.UserID == 64)
                        rpt.ReportEmbeddedResource += "TFS.rdlc";
                    else
                        rpt.ReportEmbeddedResource += ".rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongTongHopKy1List", ERP_Library.Report.BangLuongTongHopKy1List.GetBangLuongTongHopKy1List((int)cmbKyLuong.Value, (string)cmbLoaiNV.Value, (string)cmbHinhThuc.Value, 0));
                    break;
                case "nodeTongHopNganHang":
                    if (cmbLoaiNV.Value is string && (string)cmbLoaiNV.Value == "VV")
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1NganHangVuViec";
                    else
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1NganHang";
                    if (ERP_Library.Security.CurrentUser.Info.UserID == 64)
                        rpt.ReportEmbeddedResource += "TFS.rdlc";
                    else
                        rpt.ReportEmbeddedResource += ".rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongTongHopKy1List", ERP_Library.Report.BangLuongTongHopKy1List.GetBangLuongNganHangKy1List((int)cmbKyLuong.Value, (string)cmbLoaiNV.Value, "CK"));
                    break;                   
                case "nodeTongHopBoPhanNganHang":
                    if (cmbLoaiNV.Value is string && (string)cmbLoaiNV.Value == "VV")
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1BoPhanVuViec";
                    else
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1BoPhan";
                    if (ERP_Library.Security.CurrentUser.Info.UserID == 64)
                        rpt.ReportEmbeddedResource += "TFS.rdlc";
                    else
                        rpt.ReportEmbeddedResource += ".rdlc";

                    f.SetDatabase("ERP_Library_Report_BangLuongTongHopKy1List", ERP_Library.Report.BangLuongTongHopKy1List.GetBangLuongTongHopKy1List((int)cmbKyLuong.Value, (string)cmbLoaiNV.Value, "CK", (int)cmbNganHang.Value));
                    break;                   
                case "nodeBangLuongBoPhan":
                    if (cmbLoaiNV.Value is string && (string)cmbLoaiNV.Value == "VV")
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1NhanVienVuViec";
                    else
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1NhanVien";
                    if (ERP_Library.Security.CurrentUser.Info.UserID == 64)
                        rpt.ReportEmbeddedResource += "TFS.rdlc";
                    else
                        rpt.ReportEmbeddedResource += ".rdlc";

                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy1List", ERP_Library.Report.BangLuongChiTietKy1List.GetBangLuongChiTietKy1List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, 0, (string)cmbLoaiNV.Value, (string)cmbHinhThuc.Value));
                    break;
                case "nodeBangLuongNganHang":
                    if (cmbLoaiNV.Value is string && (string)cmbLoaiNV.Value == "VV")
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1NhanVienVuViec";
                    else
                        rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1NhanVien";
                    if (ERP_Library.Security.CurrentUser.Info.UserID == 64)
                        rpt.ReportEmbeddedResource += "TFS.rdlc";
                    else
                        rpt.ReportEmbeddedResource += ".rdlc";

                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy1List", ERP_Library.Report.BangLuongChiTietKy1List.GetBangLuongChiTietKy1List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, (int)cmbNganHang.Value, (string)cmbLoaiNV.Value, (string)cmbHinhThuc.Value));
                    break;
                case "nodeSoNganHangChiTiet":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV1NhanVienNganHang.rdlc";
                    _BangLuongChiTietKy1List = ERP_Library.Report.BangLuongChiTietKy1List.GetBangLuongChiTietKy1List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, (int)cmbNganHang.Value, (string)cmbLoaiNV.Value, (string)cmbHinhThuc.Value);
                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy1List",_BangLuongChiTietKy1List );
                    break;
                ////////////////// THU NHẬP /////////////
                case "nodeTNTongHopBoPhan":
                    //rpt.ReportPath = @"D:\Working\WorkingHTV\Souce\ERPNew\PSC_ERP\Report\rptBangLuongV2TongHop.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV2TongHop.rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongTongHopKy2List", ERP_Library.Report.BangLuongTongHopKy2List.GetBangLuongTongHopKy2List((int)cmbKyLuong.Value, (string)cmbLoaiNV.Value, (string)cmbHinhThuc.Value, 0, (int)cmbDieuKien.Value,Loai));
                    dot = 2;
                    break;
                case "nodeTNTongHopNganHang":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV2NganHang.rdlc";
                    //rpt.ReportPath = @"D:\Working\WorkingHTV\Souce\ERPNew\PSC_ERP\Report\rptBangLuongV2NganHang.rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongTongHopKy2List", ERP_Library.Report.BangLuongTongHopKy2List.GetBangLuongNganHangKy2List((int)cmbKyLuong.Value, (string)cmbLoaiNV.Value, (int)cmbDieuKien.Value, Loai));
                    dot = 2;
                    break;
                case "nodeTNTongHopBoPhanNganHang":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV2TongHop.rdlc";
                    //rpt.ReportPath = @"D:\Working\WorkingHTV\Souce\ERPNew\PSC_ERP\Report\rptBangLuongV2TongHop.rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongTongHopKy2List", ERP_Library.Report.BangLuongTongHopKy2List.GetBangLuongTongHopKy2List((int)cmbKyLuong.Value, (string)cmbLoaiNV.Value, "CK", (int)cmbNganHang.Value, (int)cmbDieuKien.Value, Loai));
                    dot = 2;
                    break;
                case "nodeTNBoPhan":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV2NhanVien.rdlc";
                    //rpt.ReportPath = @"D:\Working\WorkingHTV\Souce\ERPNew\PSC_ERP\Report\rptBangLuongV2NhanVien.rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy2List", ERP_Library.Report.BangLuongChiTietKy2List.GetBangLuongChiTietKy2List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, 0, (string)cmbLoaiNV.Value, (string)cmbHinhThuc.Value, (int)cmbDieuKien.Value, Loai));
                    dot = 2;
                    break;
                case "nodeTNNganHang":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV2NhanVien.rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy2List", ERP_Library.Report.BangLuongChiTietKy2List.GetBangLuongChiTietKy2List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, (int)cmbNganHang.Value, (string)cmbLoaiNV.Value, "CK", (int)cmbDieuKien.Value, Loai));
                    dot = 2;
                    break;
                case "nodeSoNganHang":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongV2NhanVienNganHang.rdlc";
                    _BangLuongChiTietKy2List = ERP_Library.Report.BangLuongChiTietKy2List.GetBangLuongChiTietKy2List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, (int)cmbNganHang.Value, (string)cmbLoaiNV.Value, "CK", (int)cmbDieuKien.Value,Loai);
                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy2List", _BangLuongChiTietKy2List);
                    dot = 2;
                    break;
                case "nodeLuongKhoanKoCoBH":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongLoaiKhoan_Nhan.rdlc";
                    //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptBangLuongLoaiKhoan.rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy2List", ERP_Library.Report.BangLuongChiTietKy2List.GetBangLuongChiTietKy2List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, 0, (string)cmbLoaiNV.Value, "All", 0,Loai));
                    break;
                    
                case "nodeLuongKhoan":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongLoaiKhoan.rdlc";
                    //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptBangLuongLoaiKhoan.rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy2List", ERP_Library.Report.BangLuongChiTietKy2List.GetBangLuongChiTietKy2List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, 0, (string)cmbLoaiNV.Value, "All", (int)cmbDieuKien.Value, Loai));
                    break;
                case "nodeLuongKhoanHTVC":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongLoaiKhoan_Long.rdlc";
                    //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptBangLuongLoaiKhoan.rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy2List", ERP_Library.Report.BangLuongChiTietKy2List.GetBangLuongChiTietKy2List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, 0, (string)cmbLoaiNV.Value, "All", (int)cmbDieuKien.Value, Loai));
                    break;
                case "NodeCTV":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangLuongLoaiKhoan_Long.rdlc";
                    //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptBangLuongLoaiKhoan.rdlc";
                    f.SetDatabase("ERP_Library_Report_BangLuongChiTietKy2List", ERP_Library.Report.BangLuongChiTietKy2List.GetBangLuongChiTietKy2List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, 0, (string)cmbLoaiNV.Value, "All", (int)cmbDieuKien.Value, Loai));
                    break;
                /////////////////////////// CÁC BÁO CÁO KHÁC //////////////////
                case "nodeTruyLuongNhanVien":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTruyLuongNhanVien.rdlc";
                    //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptTruyLuongNhanVien.rdlc";
                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BaoCaoTruyLuongList", ERP_Library.BaoCaoTruyLuongList.GetBaoCaoTruyLuongList(MaKy, (string)cmbLoaiNV.Value,(int)cmbBoPhan.Value)));
                    dot = 0;
                    break;
                case "nodeDieuChinhLuong":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptBangDieuChinhLuong.rdlc";
                    //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptBangDieuChinhLuong.rdlc";
                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BaoCaoDieuChinhLuongList", ERP_Library.BaoCaoDieuChinhLuongList.GetBaoCaoDieuChinhLuongList(MaKy, (int)cmbBoPhan.Value, (string)cmbLoaiNV.Value)));
                    dot = 0;
                    break;
                case "nodeCongDoanPhi":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDanhSachCongDoanPhi.rdlc";
                    //rpt.ReportPath = @"D:\Hien Trung\NhanSu HTV\PSC_ERP\PSC_ERP\Report\rptDanhSachCongDoanPhi.rdlc";
                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BaoCaoCongDoanPhiList", ERP_Library.BaoCaoCongDoanPhiList.GetBaoCaoCongDoanPhiList(Convert.ToInt32(txtQui.Value), Convert.ToInt32(txtNam.Value), (int)cmbBoPhan.Value, (string)cmbLoaiNV.Value)));
                    dot = -1; 
                    break;
                case "nodeTongHopCongDoan":
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopCongDoanPhi.rdlc";
                    //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptTongHopCongDoanPhi.rdlc";
                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BaoCaoCongDoanPhiList", ERP_Library.BaoCaoCongDoanPhiList.GetBaoCaoTongHopCongDoan(Convert.ToInt32(txtQui.Value), Convert.ToInt32(txtNam.Value), (string)cmbLoaiNV.Value)));
                    dot = -1;
                    break;
                case "tonghopthutien":
                    //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptDanhSachThuTien.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopDanhSachThuTien.rdlc";
                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_DanhSachThuTienNhanVienList", ERP_Library.Report.DanhSachThuTienNhanVienList.GetTongHopThuTienNhanVienList((int)cmbKyLuong.Value)));
                    dot = 0;
                    break;
                case "danhsachthutien":
                    //rpt.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptDanhSachThuTien.rdlc";
                    rpt.ReportEmbeddedResource = "PSC_ERP.Report.rptDanhSachThuTien.rdlc";
                    rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_Report_DanhSachThuTienNhanVienList", ERP_Library.Report.DanhSachThuTienNhanVienList.GetDanhSachThuTienNhanVienList((int)cmbKyLuong.Value)));
                    dot = 0;
                    break;
                default:

                    dot = 0;
                    return;
            }
            Microsoft.Reporting.WinForms.ReportParameter _ky = null;
            if (dot == 0)
                _ky = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong", cmbKyLuong.Text);
            else if (dot==1)
                _ky = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong",  cmbKyLuong.Text.ToLower());
            else if (dot == 2)
                _ky = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong", "Kỳ 2 " + cmbKyLuong.Text.ToLower());
            else if (dot==-1)
                _ky = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong", "Quí " + txtQui.Value + " năm " + txtNam.Value);

            string loai = "";
            if (cmbLoaiNV.Value != null && cmbLoaiNV.Visible) loai = "Đối tượng : " + cmbLoaiNV.Text;
            if (cmbHinhThuc.Value != null && cmbHinhThuc.Visible)
            {
                if (loai != "")
                    loai += "  -  Hình thức : " + cmbHinhThuc.Text;
                else
                    loai = "Hình thức : " + cmbHinhThuc.Text;
            }
            if (bpid != null && cmbBoPhan.Visible)
            {
                if (loai != "")
                    loai += "  -  Bộ phận : " + cmbBoPhan.Text;
                else
                    loai = "Bộ phận : " + cmbBoPhan.Text;
            }
            if (cmbNganHang.Value != null && cmbNganHang.Visible)
            {
                if (loai != "")
                    loai += "  -  Ngân hàng : " + cmbNganHang.Text + " ( " + ERP_Library.CongTy_NganHang.GetCongTy_NganHangByMaNganHang((int)cmbNganHang.Value).SoTaiKhoan + " )";
                else
                    loai = "Ngân hàng : " + cmbNganHang.Text + " ( " + ERP_Library.CongTy_NganHang.GetCongTy_NganHangByMaNganHang((int)cmbNganHang.Value).SoTaiKhoan + " )";
            }
            Microsoft.Reporting.WinForms.ReportParameter _loai = new Microsoft.Reporting.WinForms.ReportParameter("PhanLoai", loai);
            if (treeReport.SelectedNode.Name == "nodeTongHopCongDoan" || treeReport.SelectedNode.Name == "nodeCongDoanPhi")
            {
                Microsoft.Reporting.WinForms.ReportParameter _qui = new Microsoft.Reporting.WinForms.ReportParameter("Qui", txtQui.Value.ToString());
                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { _ky, _loai, _qui });
            }
            if (treeReport.SelectedNode.Name == "nodeSoNganHangChiTiet" || treeReport.SelectedNode.Name == "nodeSoNganHang")
            {
                string vietbangchu = string.Empty;
                decimal tongtien = 0;
                if (treeReport.SelectedNode.Name == "nodeSoNganHangChiTiet")
                {
                    foreach (ERP_Library.Report.BangLuongChiTietKy1Child ct in _BangLuongChiTietKy1List)
                    {
                        tongtien += ct.ThucLanhSauThue;
                    }
                }
                else if (treeReport.SelectedNode.Name == "nodeSoNganHang")
                {
                    foreach (ERP_Library.Report.BangLuongChiTietKy2Child ct in _BangLuongChiTietKy2List)
                    {
                        tongtien += ct.ThucLanh;
                    }
                }
                vietbangchu = HamDungChung.DocTien(tongtien);              
                Microsoft.Reporting.WinForms.ReportParameter _vietBangChu = new Microsoft.Reporting.WinForms.ReportParameter("VietBangChu", vietbangchu);
                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { _ky, _loai, _vietBangChu });
                f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            }
            else
            {
                rpt.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] { _ky, _loai });
          
            }
           
            f.SetNguoiKy((int)cmbKyTen.Value);
            f.ShowDialog();
        }
    }
}