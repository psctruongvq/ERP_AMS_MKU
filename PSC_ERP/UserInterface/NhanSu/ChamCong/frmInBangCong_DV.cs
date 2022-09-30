using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERP_Library;

namespace PSC_ERP.UserInterface.NhanSu.ChamCong
{
    public partial class frmInBangCong_DV : Form
    {
        public frmInBangCong_DV()
        {
            InitializeComponent();
        }

        private void btn_Xem_Click(object sender, EventArgs e)
        {
            int MaBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
            int Thang = txtThang.Value.Month;
            int Nam = txtThang.Value.Year;
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
    }
}
