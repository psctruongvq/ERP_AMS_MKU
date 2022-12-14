using ERP_Library.Security;
using System;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmThueTNCNKy3 : Form
    {
        private ERP_Library.ThueTNCNKy3List _data;
        int userID = CurrentUser.Info.UserID;
        public frmThueTNCNKy3()
        {
            InitializeComponent();
        }

        private void tlslblThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThueTNCNKy3_Load(object sender, EventArgs e)
        {
            cmbBoPhan.DataSource = ERP_Library.BoPhanList.GetBoPhanListAll(userID);
            HamDungChung.VisibleColumn(cmbBoPhan.DisplayLayout.Bands[0], "MaBoPhanQL", "TenBoPhan");
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongKy3List();
        }


        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong ky = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
                if (ky.KhoaSoKy2)
                {
                    MessageBox.Show("Kỳ tính lương này đã khóa sổ nên không thể cập nhật!", "Khóa sổ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                KhoaControl(ky.KhoaSoKy2);

                if (cmbBoPhan.Value != null)
                {
                    _data = ERP_Library.ThueTNCNKy3List.GetThueTNCNKy3List(ky.MaKy, (int)cmbBoPhan.Value);
                    bdData.DataSource = _data;
                }
            }
        }

        private void KhoaControl(bool b)
        {
            if (b)
            {
                grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
                grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
                tlslblLuu.Enabled = false;
                btnTinhThue.Enabled = false;
            }
            else
            {
                grdData.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
                grdData.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                tlslblLuu.Enabled = true;
                btnTinhThue.Enabled = true;
            }
        }

        private void btnTinhThue_Click(object sender, EventArgs e)
        {
            if (_data != null && cmbKyLuong.Value != null && cmbBoPhan.Value != null)
            {
                ERP_Library.KyTinhLuong ky = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
                if (ky.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể xử lý", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    ky.KhoaSoKy2 = true;
                    ky.Save();
                }
                KhoaControl(true);
                _data.TinhThueTNCN((int)cmbKyLuong.Value, (int)cmbBoPhan.Value);
                MessageBox.Show("Đã tính thuế thành công", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _data = ERP_Library.ThueTNCNKy3List.GetThueTNCNKy3List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value);
                bdData.DataSource = _data;
            }
            else
                MessageBox.Show("Cần chọn Tháng lương và bộ phận để xử lý", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null)
            {
                _data = ERP_Library.ThueTNCNKy3List.GetThueTNCNKy3List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value);
                bdData.DataSource = _data;
            }
        }

        private void tlslblXoa_Click(object sender, EventArgs e)
        {
            grdData.DeleteSelectedRows();
        }

        private void tlslblUndo_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null)
            {
                _data = ERP_Library.ThueTNCNKy3List.GetThueTNCNKy3List((int)cmbKyLuong.Value, (int)cmbBoPhan.Value);
                bdData.DataSource = _data;
            }
            ERP_Library.KyTinhLuong ky = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
            KhoaControl(ky.KhoaSoKy2);
        }

        private void grdData_BeforeRowsDeleted(object sender, Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs e)
        {
            e.DisplayPromptMsg = false;
            e.Cancel = MessageBox.Show("Bạn có muốn xóa dữ liệu này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
        }

        private void tlslblLuu_Click(object sender, EventArgs e)
        {
            ERP_Library.KyTinhLuong ky = ERP_Library.KyTinhLuong.GetKyTinhLuong((int)cmbKyLuong.Value);
            if (ky.KhoaSoKy2)
            {
                MessageBox.Show("Tháng lương này đã khóa sổ nên không thể xử lý", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                grdData.UpdateData();
                _data.Save();
                MessageBox.Show("Đã lưu dữ liệu thành công!", "Lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                frmThongBaoLoiDuLieu.ThongBaoLoi(ex, _data);
            }
        }

        private void tlslblIn_Click(object sender, EventArgs e)
        {
            frmXemIn f = new frmXemIn();
            f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptThueThuNhapCaNhanKy3.rdlc";
            //f.Report.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptThueThuNhapCaNhanKy3.rdlc";
            f.SetDatabase("ERP_Library_ThueTNCNKy3List", _data);
            f.SetParameter("KyLuong", cmbKyLuong.Text);
            f.SetNguoiKy(3);
            f.ShowDialog();
        }

        private void báoCáoTổngHợpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                frmXemIn f = new frmXemIn();
                f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopThueThuNhapCaNhanKy3.rdlc";
                //f.Report.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptThueThuNhapCaNhanKy3.rdlc";
                f.SetDatabase("ERP_Library_ThueTNCNKy3List", ERP_Library.ThueTNCNKy3List.GetThueTNCNKy3TongHop((int)cmbKyLuong.Value,Convert.ToInt32(0)));
                f.SetParameter("KyLuong", cmbKyLuong.Text);
                f.SetNguoiKy(3);
                f.ShowDialog();
            }
        }

        private void báoCáoTổngHợpNVKhoánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                frmXemIn f = new frmXemIn();
                f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptTongHopThueThuNhapCaNhanKy3.rdlc";
                //f.Report.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptThueThuNhapCaNhanKy3.rdlc";
                f.SetDatabase("ERP_Library_ThueTNCNKy3List", ERP_Library.ThueTNCNKy3List.GetThueTNCNKy3TongHop((int)cmbKyLuong.Value, 7));
                f.SetParameter("KyLuong", cmbKyLuong.Text);
                f.SetNguoiKy(3);
                f.ShowDialog();
            }
        }

        private void báoCáoChiTiếtNVKhoánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXemIn f = new frmXemIn();
            f.Report.ReportEmbeddedResource = "PSC_ERP.Report.rptThueThuNhapCaNhanKy3.rdlc";
            //f.Report.ReportPath = @"D:\Hien Trung\HTV\PSC_ERP\Report\rptThueThuNhapCaNhanKy3.rdlc";
            _data = ERP_Library.ThueTNCNKy3List.GetThueTNCNKy3ListIn((int)cmbKyLuong.Value, (int)cmbBoPhan.Value, 7);
            f.SetDatabase("ERP_Library_ThueTNCNKy3List", _data);
            f.SetParameter("KyLuong", cmbKyLuong.Text);
            f.SetNguoiKy(3);
            f.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                HamDungChung.ExportToExcel(grdData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}