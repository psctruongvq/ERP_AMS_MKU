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
using PSC_ERP_Business.Main.Factory;

namespace PSC_ERPNew.Main.PhanHe.TSCD.Reports
{
    public partial class frmTSCDReportList
    {
        public bool DanhSachTSCDDieuChuyenNoiBo_GhiGiam()
        {

            if (ChuaChon_TuNgay() || ChuaChon_DenNgay())
            {
                return false;
            }
            DateTime tuNgay = (Convert.ToDateTime(dteTuNgay.EditValue).Date);
            DateTime denNgay = (Convert.ToDateTime(dteDenNgay.EditValue).Date);
            if (NamBaoCaoKhongHopLe(tuNgay, denNgay))
                return false;
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            ReportHelper.ShowReport(key, () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);

                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTSCDDieuChuyenNoiBo_GhiGiam", "@TuNgay,@DenNgay", tuNgay, denNgay);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = tuNgay;
                dr["DenNgay"] = denNgay;
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
