
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
using ERP_Library;
using Infragistics.Win.UltraWinGrid; 

namespace PSC_ERP
{
    public partial class frmInChiTietLuongCTV : Form
    {
        NhanVienNgoaiDaiList _nhanVienList;
        private ERP_Library.Report.InChiTietLuong_NhanVienList _data;
        int maBophan;
        public frmInChiTietLuongCTV()
        {
            InitializeComponent();
        }

        private void frmInChiTietLuong_Load(object sender, EventArgs e)
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanList();
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value == null || cmbBoPhan.Value == null)
            {
                MessageBox.Show("Cần phải chọn kỳ lương và bộ phận để báo cáo", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            long nvid = 0;
            if (cmbNhanVien.Value != null)
                nvid = (long)cmbNhanVien.Value;

            frmXemIn f = new frmXemIn();
            f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptInChiTietLuong.rdlc";
            //f.Report.ReportPath = @"E:\HTV\PSC_ERPHTV\PSC_ERP\Report\rptInChiTietLuong.rdlc";

            f.SetParameter("TenBoPhan", ERP_Library.BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).TenBoPhan, "KyTinhLuong", cmbKyLuong.Text, "ThoiGian", "(Thu nhập từ " + txtTuNgay.Value.ToString("dd/MM/yyyy") + " đến ngày " + txtDenNgay.Value.ToString("dd/MM/yyyy") + ")");
            if (chkChuKy.Checked)
                f.SetParameter("ChuKy", GetChuKy());
            else
                f.SetParameter("ChuKy", "");
            //ERP_Library.Report.InChiTietLuong_NhanVienList.TuNgay = (DateTime)dtNgayBDTinhLuong.Value;
            //ERP_Library.Report.InChiTietLuong_NhanVienList.DenNgay = (DateTime)dtNgayKTTinhLuong.Value;
            _data = ERP_Library.Report.InChiTietLuong_NhanVienList.GetInChiTietLuong_NhanVienListCTV(nvid, (int)cmbBoPhan.Value, (int)cmbKyLuong.Value, 0, false);
            //_data = ERP_Library.Report.InChiTietLuong_NhanVienList.GetInChiTietLuong_NhanVienList(nvid, (int)cmbBoPhan.Value, (int)cmbKyLuong.Value, (DateTime)txtTuNgay.Value, (DateTime)txtTuNgay.Value);
            f.SetDatabase("ERP_Library_Report_InChiTietLuong_NhanVienList", _data);
            f.Report.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(Report_SubreportProcessing);
            f.ShowDialog();
        }
        private string GetChuKy()
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
            string ngay = DateTime.Today.ToString("'Tp.HCM, Ngày 'dd' tháng 'MM' năm 'yyyy");
            string s;
            return string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.BptTieude, nguoiky.BptTen);
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

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.ActiveRow != null)
            {
                maBophan = Convert.ToInt32(cmbBoPhan.Value);
            }
            ComboChanged();
        }
        private void ComboChanged()
        {
            //  _nhanVienList = TTNhanVienRutGonList.GetNhanVienListByBoPhanNganHang(maBophan,maLoaiNV, maNganHang,maNhanVien);
            _nhanVienList = NhanVienNgoaiDaiList.GetNhanVienNgoaiDaiList(maBophan, 0);
            NhanVienNgoaiDai _nhanVienThem = NhanVienNgoaiDai.NewNhanVienNgoaiDai("Tất cả");
            _nhanVienList.Insert(0, _nhanVienThem);
            cmbNhanVien.DataSource = _nhanVienList;
        }

        private void cmbNhanVien_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.Combobox_InitializeLayout(sender, e);
            FilterCombo f = new FilterCombo(cmbNhanVien, "TenNhanVien");
            foreach (UltraGridColumn col in this.cmbNhanVien.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;
                col.Hidden = true;
            }

            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Hidden = false;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.Caption = "Tên Nhân Viên";
            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Header.VisiblePosition = 1;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["TenNhanVien"].Width = 150;

            cmbNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Hidden = false;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.Caption = "Mã Nhân Viên";
            cmbNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Header.VisiblePosition = 0;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["CMND"].Width = 80;

            cmbNhanVien.DisplayLayout.Bands[0].Columns["MST"].Hidden = false;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MST"].Header.Caption = "Mã Số Thuế";
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MST"].Header.VisiblePosition = 2;
            cmbNhanVien.DisplayLayout.Bands[0].Columns["MST"].Width = 80;
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            ERP_Library.KyTinhLuong ky = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
            if (cmbKyLuong.Value != null)
            {
                txtTuNgay.Value = ky.NgayBatDau;
                txtDenNgay.Value = ky.NgayKetThuc;
            }
        }
    }
}
