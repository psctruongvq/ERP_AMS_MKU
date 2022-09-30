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
using System.Globalization;

namespace PSC_ERPNew.Main.PhanHe.TSCD.Reports
{
    public partial class frmTSCDReportList
    {
        public bool DanhSachTaiSanMuaBaoHiem()//M
        {

            if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            {
                return false;
            }
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            ReportHelper.ShowReport(key, () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                var tuNgay = Convert.ToDateTime(dteTuNgay.EditValue).ToShortDateString();
                var denNgay = Convert.ToDateTime(dteDenNgay.EditValue).ToShortDateString();
                dataAccess.FillDataSet(ref dataSet,"MainDaTa"
                                                    , "spRpt_DanhSachTSMuaBaoHiem"
                                                    , "@TuNgay,@DenNgay,@MaCongTy"
                                                    , tuNgay, denNgay
                                                    , ERP_Library.Security.CurrentUser.Info.MaCongTy);
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
        }
    }
}
