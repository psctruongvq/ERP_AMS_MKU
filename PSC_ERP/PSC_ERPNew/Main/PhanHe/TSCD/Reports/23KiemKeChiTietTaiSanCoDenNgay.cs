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
        public bool KiemKeChiTietTaiSanCoDenNgay()//M
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
                DateTime denNgay = (Convert.ToDateTime(dteDenNgay.EditValue)).Date;
                //int maBoPhan = (Int32)cbPhongBan.EditValue;
                int maBoPhan = (Int32)treeListLookUpEdit_BoPhan.EditValue;
                int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_KiemKeChiTietTaiSanCoDenNgay", "@DenNgay,@maPhongBan,@LoaiBaoCao", denNgay, maBoPhan,LoaiBaoCao);
                #region Extend table
                //Tao Bang Chua NgayLap
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("NgayLap", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["NgayLap"] = denNgay;//DateTime.Now.Date;
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
