using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using ERP_Library;

namespace PSC_ERP.UserInterface.NhanSu.ChamCong
{
    public partial class frmBangCongNhanVien : Form
    {
        #region Properties
        DanhSachNghiLamList _danhsachList;
        int MaBoPhan = 0;
        int Thang = 0;
        int Nam = 0;
        #endregion

        #region Load
        public frmBangCongNhanVien()
        {
            InitializeComponent();
            Load_Form();
        }

        private void grd_DanhSach_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            HamDungChung.EditBand(grd_DanhSach.DisplayLayout.Bands[0],
                new string[5] { "TenNhanVien", "TuNgay", "DenNgay", "LyDo", "LoaiNghi" },
                new string[5] { "Tên nhân viên", "Từ ngày", "Đến ngày", "Lý do", "Loại" },
                new int[5] { 250, 120, 120, 200, 100 },
                new Control[5] { null, null, null, null, null },
                new KieuDuLieu[5] { KieuDuLieu.Null, KieuDuLieu.Ngay, KieuDuLieu.Ngay, KieuDuLieu.Null, KieuDuLieu.Null },
                new bool[5] { false, false, false, false, false });

            //màu và font chữ
            foreach (UltraGridColumn col in this.grd_DanhSach.DisplayLayout.Bands[0].Columns)
            {
                col.Header.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                col.Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
                col.Header.Appearance.ForeColor = System.Drawing.Color.Navy;//x =  //= System.Drawing.w;//RoyalBlue
            }
            this.grd_DanhSach.DisplayLayout.Override.HeaderStyle = HeaderStyle.WindowsXPCommand;
            this.grd_DanhSach.DisplayLayout.Override.HeaderAppearance.BackColor = System.Drawing.Color.White;
        }
        #endregion

        #region Process
        private void Load_Form()
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListByMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy);
        }

        private void ChangeValue()
        {
            MaBoPhan = Convert.ToInt32(cmbBoPhan.Value);
            Thang = txtThang.Value.Month;
            Nam = txtThang.Value.Year;
        }
        #endregion

        #region Event
        private void tlslbl_BangCongTam_Click(object sender, EventArgs e)
        {
            try
            {
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                rpt.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rpt_BangCongNhanVien.rdlc";
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("BangCong", ERP_Library.BangChamCong_NewList.GetBangChamCong_NewList(MaBoPhan, Thang, Nam)));
                List<Microsoft.Reporting.WinForms.ReportParameter> para = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                para.Add(new Microsoft.Reporting.WinForms.ReportParameter("TenDonVi", CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).TenCongTy));
                para.Add(new Microsoft.Reporting.WinForms.ReportParameter("SoSDNS", CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).SoDVSDNS));
                rpt.SetParameters(para);

                f.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            try
            {
                int MaBoPhan = Convert.ToInt32(cmbBoPhan.Value);
                int Thang = txtThang.Value.Month;
                int Nam = txtThang.Value.Year;

                _danhsachList = DanhSachNghiLamList.GetDanhSachNghiLamList(MaBoPhan, Thang, Nam);
                DanhSachbd.DataSource = _danhsachList;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            if (BangChamCong_NewList.KiemTraBangCongDuyet(MaBoPhan, Thang, Nam))
            {
                if (MessageBox.Show(this, "Đã tồn tại bảng công được duyệt. Có muốn xóa bỏ và thực hiện duyệt lại bảng công ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    BangChamCong_NewList.XoaDuyetBangCong(MaBoPhan, Thang, Nam);
                    BangChamCong_NewList.DuyetBangCong(MaBoPhan, Thang, Nam);

                    MessageBox.Show(this, "Bảng công đã được duyệt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                BangChamCong_NewList.DuyetBangCong(MaBoPhan, Thang, Nam);

                MessageBox.Show(this, "Bảng công đã được duyệt thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            if (BangChamCong_NewList.KiemTraBangCongDuyet(MaBoPhan, Thang, Nam))
            {
                if (MessageBox.Show(this, "Có chắc chắn xóa bảng công đã duyệt hiện tại ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    BangChamCong_NewList.XoaDuyetBangCong(MaBoPhan, Thang, Nam);

                    MessageBox.Show(this, "Bảng công đã được xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show(this, "Bảng công chưa được duyệt, vui lòng duyệt bảng công cho bộ phận này trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            ChangeValue();
        }

        private void txtThang_ValueChanged(object sender, EventArgs e)
        {
            ChangeValue();
        }

        private void tlslbl_BangCong_ChinhThuc_Click(object sender, EventArgs e)
        {
            if (!BangChamCong_NewList.KiemTraBangCongDuyet(MaBoPhan, Thang, Nam))
            {
                MessageBox.Show(this, "Bảng công chưa được duyệt, vui lòng duyệt bảng công cho bộ phận này trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                frmXemIn f = new frmXemIn();
                Microsoft.Reporting.WinForms.LocalReport rpt = f.rptView.LocalReport;
                rpt.ReportEmbeddedResource = "PSC_ERP.Report.NhanSu.rpt_BangCongNhanVien.rdlc";
                rpt.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("BangCong", ERP_Library.BangChamCong_NewList.GetBangChamCong_NewList_ByDaDuyet(MaBoPhan, Thang, Nam)));
                List<Microsoft.Reporting.WinForms.ReportParameter> para = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                para.Add(new Microsoft.Reporting.WinForms.ReportParameter("TenDonVi", CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).TenCongTy));
                para.Add(new Microsoft.Reporting.WinForms.ReportParameter("SoSDNS", CongTy.GetCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).SoDVSDNS));
                rpt.SetParameters(para);
                f.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
