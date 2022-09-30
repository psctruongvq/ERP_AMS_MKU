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
        public bool DanhSachChungTuHopDongMuaSamTaiSan()//M
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
                DateTime tuNgay = (Convert.ToDateTime(dteTuNgay.EditValue)).Date;
                DateTime denNgay = (Convert.ToDateTime(dteDenNgay.EditValue)).Date;
                bool onLyDenNgay = radioChonDenNgay.Checked;
                int nguonMua = (Int32)radioGroupNguonMua_Le_DuAn.EditValue;
                int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachChungTuHopDongMuaSamTaiSan", "@TuNgay,@DenNgay,@OnlyDenNgay,@NguonMua,@LoaiBaoCao", tuNgay, denNgay, onLyDenNgay, nguonMua,LoaiBaoCao);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("OnlyDenNgay", typeof(Boolean));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dteTuNgay.EditValue;
                dr["DenNgay"] = dteDenNgay.EditValue;
                dr["OnlyDenNgay"] = radioChonDenNgay.Checked;
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
