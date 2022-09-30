using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common.Ado.Net;
using PSC_ERPNew.Main.Reports;

namespace PSC_ERPNew.Main.PhanHe.TSCD.Reports
{
    public partial class frmTSCDReportList
    {
        public bool TongHopKinhPhiMuaSamTaiSanTangTrongKyTheoTaiKhoan()//M
        {
            
            //if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            //{
            //    return false;
            //}

            /*
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            ReportHelper.ShowReport(key, () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                DateTime tuNgay = (Convert.ToDateTime(dteTuNgay.EditValue)).Date;
                DateTime denNgay = (Convert.ToDateTime(dteDenNgay.EditValue)).Date;
                int nguonMua = (Int32)radioGroupNguonMua_Le_DuAn.EditValue;
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_TongHopKinhPhiMuaSamTaiSanTangTrongKyTheoTaiKhoan", "@TuNgay,@DenNgay,@NguonMua", tuNgay, denNgay, nguonMua);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dteTuNgay.EditValue;
                dr["DenNgay"] = dteDenNgay.EditValue;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "SubInfo";
                dataSet.Tables.Add(dtngay);
                #endregion
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, true, false, _designMode, this.reportBindingSource.Current as Report);

            return true;
             
            */

            DataSet dataSet = new DataSet();
            SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
            DateTime tuNgay = (Convert.ToDateTime(dteTuNgay.EditValue)).Date;
            DateTime denNgay = (Convert.ToDateTime(dteDenNgay.EditValue)).Date;
            int nguonMua = (Int32)radioGroupNguonMua_Le_DuAn.EditValue;
            int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_TongHopKinhPhiMuaSamTaiSanTangTrongKyTheoTaiKhoan_New", "@TuNgay,@DenNgay,@NguonMua,@LoaiBaoCao", tuNgay, denNgay, nguonMua,LoaiBaoCao);

            frmReportingViewer frm = new frmReportingViewer();
            frm.MainReportView.LocalReport.DataSources.Clear();
            frm.MainReportView.LocalReport.ReportEmbeddedResource = "PSC_ERP.PSC_ERPNew.Main.PhanHe.TSCD.Reports.rptTongHopTaiSanTangTrongKyTheoTaiKhoan_16.rdlc";
            //người ký tên
            frm.SetNguoiKy(100);//lấy trường hợp default truyền số bất kỳ không cho case là được (case từ 0-3)

            frm.MainReportView.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("BaoCao_16", dataSet.Tables[0]));
            frm.MainReportView.RefreshReport();

            frm.MainReportView.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            frm.MainReportView.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            frm.MainReportView.ZoomPercent = 100;
            frm.Show();
            return false;

        }



    }
}
