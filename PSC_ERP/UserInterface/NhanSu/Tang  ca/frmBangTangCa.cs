using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ERP_Library;

namespace PSC_ERP
{
    public partial class frmBangTangCa : Form
    {
        public frmBangTangCa()
        {
            InitializeComponent();
        }

        private void frmBangTangCa_Load(object sender, EventArgs e)
        {
            cmbKyLuong.DataSource = ERP_Library.KyTinhLuongList.GetKyTinhLuongList();

            cmbBoPhan.DataSource = BoPhanList.GetBoPhanList();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTinhChamCong_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null)
            {
                ERP_Library.KyTinhLuong i = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                if (i.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại bảng tăng ca", "Tăng ca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn thực hiện tính bảng tăng ca cho tất cả nhân viên không?", "Tăng ca", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ERP_Library.TinhTangCaNhanVien t = new ERP_Library.TinhTangCaNhanVien(i);
                    if (cmbBoPhan.Value != null)
                        t.GetListByBoPhan((int)cmbBoPhan.Value);
                    else
                        t.GetListData();

                    frmWaitProcess.Wait(TinhTangCa, t);
                    LoadData();
                }
            }
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbKyLuong_ValueChanged(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong i = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                txtTuNgay.Value = i.NgayBatDau.ToString("dd/MM/yyyy");
                txtDenNgay.Value = i.NgayKetThuc.ToString("dd/MM/yyyy");
            }
            else
            {
                txtTuNgay.Value = "";
                txtDenNgay.Value = "";
            }
            LoadData();
        }

        private void TinhTangCa(object sender, DoWorkEventArgs e)
        {
            //chú ý đang chạy trên thread khác, chỉ sử dụng các biến sender, e

            ERP_Library.TinhTangCaNhanVien t = e.Argument as ERP_Library.TinhTangCaNhanVien;
            t.Begin();
            BackgroundWorker worker = sender as BackgroundWorker;
            for (int i = 0; i < t.List.Count; i++)
            {
                if (worker.CancellationPending)
                {
                    t.Cancel();
                    e.Cancel = true;
                    return;
                }
                else
                {
                    t.TinhTangCa(t.List[i]);
                    worker.ReportProgress(i * 100 / t.List.Count);
                }
            }
            t.End();
        }


        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null)
            {
                frmXemIn f = new frmXemIn();
                f.rptView.LocalReport.ReportEmbeddedResource = "PSC_ERP.Report.rptBangTangCaNhanVien.rdlc";
                Microsoft.Reporting.WinForms.ReportParameter p = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong", cmbKyLuong.Text);
                f.rptView.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] {p });
                if (cmbBoPhan.Value != null)
                    f.rptView.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BangTangCaNhanVienList", ERP_Library.BangTangCaNhanVienList.GetBangTangCaNhanVienListByBoPhan((int)cmbKyLuong.Value, (int)cmbBoPhan.Value)));
                else
                    f.rptView.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BangTangCaNhanVienList", ERP_Library.BangTangCaNhanVienList.GetBangTangCaNhanVienList((int)cmbKyLuong.Value)));
                
                f.ShowDialog();
            }
        }

        private void LoadData()
        {
            if (cmbBoPhan.Value is int && cmbKyLuong.Value is int)
            {
                bdData.DataSource = ERP_Library.BangTangCaNhanVienList.GetBangTangCaNhanVienListByBoPhan((int)cmbKyLuong.Value, (int)cmbBoPhan.Value);
            }

            if (chkNgay.Checked)
                CapNhatHienThiCotNgay();
        }

        private bool SaveData()
        {
            return true;
        }

        private void btnChamTangCa_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null)
            {
                ERP_Library.KyTinhLuong i = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                if (i.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại bảng tăng ca", "Tăng ca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                } 
                
                frmChamTangCaHangLoat f = new frmChamTangCaHangLoat();
                if (f.ChamTangCa((ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject, (ERP_Library.BoPhan)cmbBoPhan.SelectedItem.ListObject))
                    LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value == null || cmbBoPhan.Value == null) return;

            ERP_Library.KyTinhLuong i = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
            if (i.KhoaSoKy2)
            {
                MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại bảng tăng ca", "Tăng ca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa bảng tăng ca của bộ phận này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ERP_Library.BangTangCaNhanVienList.XoaTangCaBoPhan((int)cmbKyLuong.Value, (int)cmbBoPhan.Value);
                LoadData();
            }
        }

        private void btnXoaNhanVien_Click(object sender, EventArgs e)
        {
            if (grdData.Selected.Rows.Count > 0)
            {
                ERP_Library.KyTinhLuong i = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                if (i.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại bảng tăng ca", "Tăng ca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Bạn có muốn xóa tăng ca của nhân viên này không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in grdData.Selected.Rows)
                        ERP_Library.BangTangCaNhanVienList.XoaTangCaNhanVien((int)cmbKyLuong.Value, (long)r.Cells["MaNhanVien"].Value);
                    LoadData();
                }
            }
        }

        private void chkNgay_CheckedChanged(object sender, EventArgs e)
        {
            CapNhatHienThiCotNgay();
        }

        private void CapNhatHienThiCotNgay()
        {
            if (chkNgay.Checked)
            {
                bool b;
                for (int i = 1; i <= 31; i++)
                {
                    b = true;
                    foreach (Infragistics.Win.UltraWinGrid.UltraGridRow r in grdData.Rows)
                        if (r.Cells["Ngay" + i].Value is decimal && (decimal)r.Cells["Ngay" + i].Value > 0)
                        {
                            b = false;
                            break;
                        }

                    grdData.DisplayLayout.Bands[0].Columns["Ngay" + i].Hidden = b;

                }
            }
            else
                for (int i = 1; i <= 31; i++)
                    grdData.DisplayLayout.Bands[0].Columns["Ngay" + i].Hidden = false;
        }

        private void btnTongHop_Click(object sender, EventArgs e)
        {
            if (cmbKyLuong.Value != null && cmbBoPhan.Value != null)
            {
                ERP_Library.KyTinhLuong i = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                if (i.KhoaSoKy2)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại bảng tăng ca", "Tăng ca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                } 
                frmChamTangCaTongHop f = new frmChamTangCaTongHop();
                if (f.ChamTangCa((ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject, (ERP_Library.BoPhan)cmbBoPhan.SelectedItem.ListObject))
                    LoadData();
            }
        }
    }
}