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
        public bool DanhSachTaiSanCoDenNgay_DungKiemKe()
        {

            if (ChuaChon_DenNgay())
            {
                return false;
            }
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            ReportHelper.ShowReport(key, () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                DateTime tuNgay = (Convert.ToDateTime(dteTuNgay.EditValue)).Date;
                DateTime denNgay = (Convert.ToDateTime(dteDenNgay.EditValue).Date);
                bool onLyDenNgay = radioChonDenNgay.Checked;
                int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
                //int maBoPhan = (Int32)cbPhongBan.EditValue;
                int maBoPhan = (Int32)treeListLookUpEdit_BoPhan.EditValue;
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTaiSanCoDenNgay_DungKiemKe", "@TuNgay,@DenNgay,@OnlyDenNgay,@InChiTiet,@MaPhongBan,@LoaiBaoCao",tuNgay, denNgay,onLyDenNgay, true, maBoPhan,LoaiBaoCao);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable tableSubInfo = new DataTable();
                tableSubInfo.Columns.Add("TuNgay", typeof(DateTime));
                tableSubInfo.Columns.Add("DenNgay", typeof(DateTime));
                tableSubInfo.Columns.Add("OnlyDenNgay", typeof(bool));
                //Add dòng 1
                DataRow dr1 = tableSubInfo.NewRow();
                dr1["TuNgay"] = tuNgay;
                dr1["DenNgay"] = denNgay;
                dr1["OnlyDenNgay"] = onLyDenNgay;
                tableSubInfo.Rows.Add(dr1);

                /////////////////////////////

                tableSubInfo.TableName = "SubInfo";
                dataSet.Tables.Add(tableSubInfo);
                #endregion
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, true, false, _designMode, this.reportBindingSource.Current as Report);

            return true;
        }
    }
}
