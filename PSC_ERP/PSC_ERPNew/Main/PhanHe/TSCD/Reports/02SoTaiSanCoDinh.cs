using System;
using System.Data;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common.Ado.Net;
using PSC_ERPNew.Main.Reports;

namespace PSC_ERPNew.Main.PhanHe.TSCD.Reports
{
    public partial class frmTSCDReportList
    {
        public bool SoTaiSanCoDinh()//M
        {

            //if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            //{
            //    return false;
            //}
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            ReportHelper.ShowReport(key, () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                int nam = (Int32)cbNam.EditValue;
                int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
                int loaiTaiSan = (Int32)cbLoaiTaiSan.EditValue;
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_SoTaiSanCoDinh", "@Nam,@LoaiTaiSan,@LoaiBaoCao", nam, loaiTaiSan,LoaiBaoCao);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("Nam", typeof(Int32));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["Nam"] = (Int32)cbNam.EditValue;
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
