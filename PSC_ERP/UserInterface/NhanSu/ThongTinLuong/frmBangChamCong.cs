using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERP_Library;
using System.Collections;

namespace PSC_ERP
{
    public partial class frmBangChamCong : Form
    {
        public frmBangChamCong()
        {
            InitializeComponent();
        }

        private void frmBangChamCong_Load(object sender, EventArgs e)
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
            if (cmbKyLuong.Value != null)
            {
                ERP_Library.KyTinhLuong i = (ERP_Library.KyTinhLuong)cmbKyLuong.SelectedItem.ListObject;
                if (i.KhoaSoKy1)
                {
                    MessageBox.Show("Tháng lương này đã khóa sổ nên không thể tính lại bảng công", "Chấm công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Bạn có muốn thực hiện tính công cho tất cả nhân viên không?", "Chấm công", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ERP_Library.TinhChamCongNhanVien t = new ERP_Library.TinhChamCongNhanVien(i);
                    if (cmbNhanVien.Value != null)
                    {
                        t.GetListByNhanVien((long)cmbNhanVien.Value);
                    }
                    else
                    {
                        if (cmbBoPhan.Value != null)
                            t.GetListByBoPhan((int)cmbBoPhan.Value);
                        else
                            t.GetListData();
                    }
                    frmWaitProcess.Wait(TinhChamCong, t);
                }
            }
        }

        private void cmbBoPhan_ValueChanged(object sender, EventArgs e)
        {
            if (cmbBoPhan.Value == null)
                cmbNhanVien.LoadDataByBoPhan(0);
            else
                cmbNhanVien.LoadDataByBoPhan((int)cmbBoPhan.Value);
            cmbNhanVien.Value = null;
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
        }

        private void TinhChamCong(object sender, DoWorkEventArgs e)
        {
            //chú ý đang chạy trên thread khác, chỉ sử dụng các biến sender, e

            ERP_Library.TinhChamCongNhanVien t = e.Argument as ERP_Library.TinhChamCongNhanVien;
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
                    t.TinhCong(t.List[i]);
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
                f.rptView.LocalReport.ReportEmbeddedResource = "PSC_ERP.Report.rptBangChamCongNhanVien.rdlc";
                Microsoft.Reporting.WinForms.ReportParameter p = new Microsoft.Reporting.WinForms.ReportParameter("KyLuong", cmbKyLuong.Text);
                f.rptView.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter[] {p });
                f.rptView.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_BangChamCongList", ERP_Library.BangChamCongList.GetBangChamCongList((Nullable<long>)cmbNhanVien.Value,(Nullable<int>)cmbBoPhan.Value,(int)cmbKyLuong.Value)));
                f.rptView.LocalReport.SubreportProcessing += new Microsoft.Reporting.WinForms.SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
                f.ShowDialog();
            }
        }

        void LocalReport_SubreportProcessing(object sender, Microsoft.Reporting.WinForms.SubreportProcessingEventArgs e)
        {
            e.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ERP_Library_HinhThucNghiList", ERP_Library.HinhThucNghiList.GetHinhThucNghiList()));
        }
    }
}