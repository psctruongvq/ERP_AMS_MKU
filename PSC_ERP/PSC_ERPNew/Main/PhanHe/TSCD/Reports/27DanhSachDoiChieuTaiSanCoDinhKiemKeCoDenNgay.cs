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
        public bool DanhSachDoiChieuTaiSanCoDinhKiemKeCoDenNgay()
        {

            if (ChuaChon_NgayChot() || ChuaChon_NgayKiemKe())
            {
                return false;
            }
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            ReportHelper.ShowReport(key, () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                DateTime ngayChot = (Convert.ToDateTime(dteNgayChot.EditValue).Date);
                DateTime ngayKiemKe = (Convert.ToDateTime(dteNgayKiemKe.EditValue).Date);
                int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
                //int maBoPhan = (Int32)cbPhongBan.EditValue;
                int maBoPhan = (Int32)treeListLookUpEdit_BoPhan.EditValue;
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachDoiChieuTaiSanCoDinhKiemKeCoDenNgay", "@NgayChot,@NgayKiemKe,@MaPhongBan,@LoaiBaoCao", ngayChot, ngayKiemKe, maBoPhan,LoaiBaoCao);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("NgayIn", typeof(DateTime));
                dtngay.Columns.Add("NgayChot", typeof(DateTime));
                dtngay.Columns.Add("NgayKiemKe", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["NgayIn"] = DateTime.Now.Date;
                dr["NgayChot"] = ngayChot;
                dr["NgayKiemKe"] = ngayKiemKe;
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
