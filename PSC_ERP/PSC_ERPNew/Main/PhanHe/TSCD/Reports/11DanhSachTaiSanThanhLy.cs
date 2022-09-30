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

        public bool DanhSachTaiSanThanhLy()//M
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
                int kieuThanhLy = (Int32)cbKieuThanhLy.EditValue;
                int maBoPhan = (Int32)cbPhongBan.EditValue;
                //dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTaiSanThanhLy", "@TuNgay,@DenNgay,@KieuThanhLy,@MaBoPhan", tuNgay, denNgay, kieuThanhLy, maBoPhan);
                // bổ sung mã công ty 18/11/2020
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_DanhSachTaiSanThanhLy", "@TuNgay,@DenNgay,@KieuThanhLy,@MaBoPhan,@MaCongTy", tuNgay, denNgay, kieuThanhLy, maBoPhan, _maCongTy);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                dtngay.Columns.Add("LoaiBaoCao", typeof(String));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["TuNgay"] = dteTuNgay.EditValue;
                dr["DenNgay"] = dteDenNgay.EditValue;
                if (Convert.ToInt32(cbKieuThanhLy.EditValue) != 0)
                    dr["LoaiBaoCao"] = PSC_ERP_Business.Main.Predefined.LoaiThanhLyTaiSan.LoaiThanhLyTaiSanList.FirstOrDefault(x => x.Ma == Convert.ToInt32(cbKieuThanhLy.EditValue)).Ten;
                else
                    dr["LoaiBaoCao"] = "Thanh lý và điều chuyển ngoài";
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
