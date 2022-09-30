using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using System.IO;
using ERP_Library;
using System.Reflection;

namespace PSC_ERP
{
    public partial class frmThongTinReport : DevExpress.XtraEditors.XtraForm
    {
        private XtraReport _report;
        public static ReportTemplate _reportItem;
        private int _userId = 0;
        private int _thuMuc = 0;
        int _kieu = 0; // 0 : tạo mới; 1: chỉnh sửa 

        public frmThongTinReport()
        {
            InitializeComponent();
        }

        public frmThongTinReport(XtraReport report, int UserId, int thuMuc)
        {
            InitializeComponent();
            _report = report;
            _userId = UserId;
            _thuMuc = thuMuc;
            _kieu = 0; 
        }

        public frmThongTinReport(ReportTemplate report, int UserId, int thuMuc)
        {
            InitializeComponent();
            _reportItem = report;
            _userId = UserId;
            _thuMuc = thuMuc;
            txt_ID.Text = report.Id;
            txt_TenPhuongThuc.Text = report.TenPhuongThuc;
            txt_TenBaoCao.Text = report.TenBaoCao;
            txt_SoTT.EditValue = report.SoTTSapXep;
            dtp_DenNgay.Value = report.DenNgay;
            _kieu = 1;
        }
                
        public frmThongTinReport(MemoryStream stream, string strReportName)
        {
            InitializeComponent();
        }

        private void btn_ThemMoi_Click(object sender, EventArgs e)
        {
            SaveReport();
        }

        private void SaveReport()
        {
            DateTime dtDenNgay = dtp_DenNgay.Value.Date;
            string strID = txt_ID.Text;
            string strTenPhuongThuc = txt_TenPhuongThuc.Text;
            string strTenBaoCao = txt_TenBaoCao.Text;
            int soTTSapXep = Convert.ToInt32(txt_SoTT.Text);
            if (_kieu == 0)
            {
                _reportItem = ReportTemplate.NewReportTemplate(strID, _userId, dtDenNgay, strTenPhuongThuc, _thuMuc, strTenBaoCao, soTTSapXep);
                using (MemoryStream stream = new MemoryStream())
                {
                    _report.SaveLayout(stream);
                    _reportItem.Data = stream.ToArray();
                }

            }
            else
            {
                _reportItem.ThuMuc = _thuMuc;
                _reportItem.UserID = _userId;
                _reportItem.TenBaoCao = strTenBaoCao;
                _reportItem.TenPhuongThuc = strTenPhuongThuc;
                _reportItem.Id = strID;
                _reportItem.SoTTSapXep = soTTSapXep;
            }
            //set Datasource cho report
                       
            _reportItem.ApplyEdit();
            _reportItem.Save();
            XtraMessageBox.Show("Đã cập thành công. Sau đó chuyển sang phần design", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}