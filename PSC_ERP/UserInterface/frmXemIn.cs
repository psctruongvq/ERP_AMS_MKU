using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace PSC_ERP
{
    public partial class frmXemIn : Form
    {
        public frmXemIn()
        {
            InitializeComponent();
        }

        private void frmXemIn_Load(object sender, EventArgs e)
        {
            this.rptView.RefreshReport();
            this.rptView.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }

        /// <summary>
        /// cài đặt report
        /// </summary>
        public Microsoft.Reporting.WinForms.LocalReport Report
        {
            get
            {
                return rptView.LocalReport;
            }
        }

        /// <summary>
        /// cài đặt database cho report
        /// </summary>
        /// <param name="name">tên sử dụng trong report</param>
        /// <param name="source">dữ liệu báo cáo</param>
        public void SetDatabase(string name, object source)
        {
            Report.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource(name, source));
        }

        /// <summary>
        /// cài đặt các tham số cho report
        /// </summary>
        /// <param name="param">mảng các tham số gồm : key và value</param>
        public void SetParameter(params string[] param)
        {
            List<Microsoft.Reporting.WinForms.ReportParameter> a = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            for (int i = 0; i < param.Length; i = i + 2)
            {
                a.Add(new Microsoft.Reporting.WinForms.ReportParameter(param[i], param[i + 1]));
            }
            Report.SetParameters(a);
            
        }

        /// <summary>
        /// Cài đặt người ký tên cho các parammeter của report : NguoiLap, BanPhuTrach, ThuTruong
        /// </summary>
        /// <param name="ind">số chử ký trên report : 0-3</param>
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
            }
        }



        public void SetNguoiKyXacNhanThuNhap(int ind, DateTime ngayky)
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
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n(Ký, họ tên)\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeChuTichCD, nguoiky.TenChuTichCD));
                    break;
            }
        }


        public void SetNguoiKyTongHop(int ind, DateTime ngayky)
        {

            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
            string ngay = ngayky.ToString("'Ngày .... tháng .... năm 'yyyy");
            switch (ind)
            {
                case 0:
                    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", "");
                    break;
                case 1:
                    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    break;
                case 2:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    break;
                case 3:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.BptTieude, nguoiky.BptTen));
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    break;
                case 4:
                    SetParameter("NguoiLap", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}",  ngay, nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.BptTieude.ToUpper(), nguoiky.BptTen));
                    SetParameter("ThuTruong", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                    SetParameter("TongGiamDoc", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    break;
            }
        }

        public void SetNguoiKyTongHop_DichVu(int ind, DateTime ngayky)
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
            string ngay = ngayky.ToString("'Ngày .... tháng .... năm 'yyyy");
            switch (ind)
            {
                case 0:
                    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", "", "TongGiamDoc", "");
                    break;
                case 1:
                    SetParameter("ThuTruong", "", "BanPhuTrach", "", "NguoiLap", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen), "TongGiamDoc", "");
                    break;
                case 2:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}",  nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", "");
                    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2} ", ngay, nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                    break;
                case 3:
                    SetParameter("NguoiLap", string.Format(" {0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    break;
                case 4:
                    SetParameter("NguoiLap", string.Format(" {0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}",  nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.BptTieude.ToUpper(), nguoiky.BptTen));
                    SetParameter("ThuTruong", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2} ", ngay, nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    break;
            }
        }

        public void SetNguoiKyTheoDCNKMoi(int ind, DateTime ngayky)
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
            string ngay = ngayky.ToString("'Ngày .... tháng .... năm 'yyyy");
            switch (ind)
            {
                //case 0:
                //    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", "", "TongGiamDoc", "");
                //    break;
                //case 1:
                //    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                //    SetParameter("BanPhuTrach","");
                //    SetParameter("ThuTruong", "");
                //    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2} ", ngay, nguoiky.BptTieude.ToUpper(), nguoiky.BptTen));
                //    break;
                //case 2:
                //    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                //    SetParameter("BanPhuTrach", "");
                //    SetParameter("ThuTruong", "");
                //    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2} ", ngay, nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                //    break;
                //case 3:
                //    SetParameter("NguoiLap", string.Format(" {0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                //    SetParameter("BanPhuTrach", "");
                //    SetParameter("ThuTruong", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                //    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                //    break;
                //case 4:
                //    SetParameter("NguoiLap", string.Format(" {0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                //    SetParameter("BanPhuTrach", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.BptTieude.ToUpper(), nguoiky.BptTen));
                //    SetParameter("ThuTruong", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                //    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2} ", ngay, nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    //break;
                case 0:
                    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", "", "TongGiamDoc", "");
                    break;
                case 1:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", "");
                    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n{2} ", ngay, nguoiky.BptTieude.ToUpper(), nguoiky.BptTen));
                    break;
                case 2:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", "");
                    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2} ", ngay, nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                    break;
                case 3:
                    //SetParameter("NguoiLap", string.Format(" {0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    //SetParameter("BanPhuTrach", "");
                    //SetParameter("ThuTruong", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                    //SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    break;
                case 4:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.BptTieude.ToUpper(), nguoiky.BptTen));
                    SetParameter("ThuTruong", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                    SetParameter("TongGiamDoc", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    break;
            }
        }

        public void SetNguoiKyTongHopDVCap2(int ind, DateTime ngayky)
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
            string ngay = ngayky.ToString("'Tp.HCM, Ngày 'dd' tháng 'MM' năm 'yyyy");
            switch (ind)
            {
                case 0:
                    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", "");
                    break;
                case 1:
                    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    break;
                case 2:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.ThuTruongTieude, nguoiky.ThuTruongTen));
                    break;
                case 3:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.BptTieude, nguoiky.BptTen));
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.ThuTruongTieude, nguoiky.ThuTruongTen));
                    break;
                case 4:
                    SetParameter("NguoiLap", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.NguoiLapTieude.ToUpper(), nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.BptTieude.ToUpper(), nguoiky.BptTen));
                    SetParameter("ThuTruong", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude.ToUpper(), nguoiky.ThuTruongTen));
                    SetParameter("TongGiamDoc", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.TieuDeTongGiamDoc.ToUpper(), nguoiky.TenTongGiamDoc));
                    break;
                case 10:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc, nguoiky.TenTongGiamDoc));
                    break;
            }
        }

        public void SetNguoiKy_DNCK(int ind, DateTime ngayky)
        {
            ERP_Library.NguoiKyTen nguoiky = ERP_Library.NguoiKyTen.GetNguoiKyTen(ERP_Library.Security.CurrentUser.Info.UserID);
            string ngay = ngayky.ToString("'Tp.HCM, Ngày 'dd' tháng 'MM' năm 'yyyy");
            switch (ind)
            {
                case 0:
                    SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", "");
                    break;
                case 1:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.BptTieude, nguoiky.BptTen));
                    break;
                case 2:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", "");
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc, nguoiky.TenTongGiamDoc));
                    break;
                case 3:
                    SetParameter("NguoiLap", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.NguoiLapTieude, nguoiky.NguoiLapTen));
                    SetParameter("BanPhuTrach", string.Format("{0}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{1}", nguoiky.ThuTruongTieude, nguoiky.ThuTruongTen));
                    SetParameter("ThuTruong", string.Format("{0}\r\n{1}\r\n\r\n\r\n\r\n\r\n\r\n\r\n{2}", ngay, nguoiky.TieuDeTongGiamDoc, nguoiky.TenTongGiamDoc));
                    break;
                case 4:
                   SetParameter("NguoiLap", "", "BanPhuTrach", "", "ThuTruong", "");
                    break;
            }
        }

        public void SetNguoiKy(int ind)
        {
            SetNguoiKy(ind, DateTime.Today);
        }
        public void SetNguoiKyTongHop(int ind)
        {
            SetNguoiKyTongHop(ind, DateTime.Today);
        }

        public void SetNguoiKyTongHopBangKe(int ind, DateTime ngay)
        {
            SetNguoiKyTongHopDVCap2(ind, ngay);
        }

        public void SetNguoiKyTongHop_DichVu(int ind)
        {
            SetNguoiKyTongHop_DichVu(ind, DateTime.Today);
        }

        public void SetNguoiKy_DeNghiCK(int ind)
        {
            SetNguoiKy_DNCK(ind, DateTime.Today);
        }
        //public void SetNguoiKy_TheoDCNKMoi(int ind)
        //{
        //    SetNguoiKyTheoDCNKMoi(ind, DateTime.Today);
        //}
    }
}
