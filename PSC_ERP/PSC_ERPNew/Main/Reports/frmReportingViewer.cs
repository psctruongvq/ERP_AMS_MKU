using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERPNew.Main.Reports
{
    public partial class frmReportingViewer : Form
    {
        public Microsoft.Reporting.WinForms.ReportViewer MainReportView
        {
            get { return this.reportViewer1; }
        }
        public frmReportingViewer()
        {
            InitializeComponent();
        }

        public void SetParameter(params string[] param)
        {
            List<Microsoft.Reporting.WinForms.ReportParameter> a = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            for (int i = 0; i < param.Length; i = i + 2)
            {
                a.Add(new Microsoft.Reporting.WinForms.ReportParameter(param[i], param[i + 1]));
            }
            MainReportView.LocalReport.SetParameters(a);
        }

        public void SetNguoiKy(int ind, DateTime ngayky)
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);

            string ngay = ngayky.ToString("'Tp.HCM, Ngày 'dd' tháng 'MM' năm 'yyyy");
            switch (ind)
            {
                case 0:
                    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", "");
                    break;
                case 1:
                    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", string.Format("{0}\r\n{1}\r\n(Ký, họ tên)\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    break;
                case 2:
                    SetParameter("NguoiLap", string.Format("{0}\r\n(Ký, họ tên)\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n(Ký, họ tên)\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc, nguoiky.TenTongGiamDoc));
                    break;
                case 3:
                    SetParameter("NguoiLap", string.Format("{0}\r\n(Ký, họ tên)\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", string.Format("{0}\r\n(Ký, họ tên)\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude, nguoiky.ThuTruongTen));
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n(Ký, họ tên)\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc, nguoiky.TenTongGiamDoc));
                    break;
                default:
                    SetParameter("NguoiLap",  nguoiky.NguoiLapTen);
                    SetParameter("BanPhuTrach",  nguoiky.ThuTruongTen);
                    SetParameter("ThuTruong", nguoiky.TenTongGiamDoc);
                    break;
            }
        }
        public void SetNguoiKy(int ind)
        {
            SetNguoiKy(ind, DateTime.Today);
        }
    }
}