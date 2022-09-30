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
        public bool TongHopKhauHaoTheoDonVi()
        {
            int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            if (ChuaChon_TuKy() || ChuaChon_DenKy())
            {
                return false;
            }
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            int maTuKy = (Convert.ToInt32(cbTuKy.EditValue));
            int maDenKy = (Convert.ToInt32(cbDenKy.EditValue));
            int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            int loaiThoiGianSuDung = 0;
            ShowTongHopKhauHaoTheoDonVi_SuDungChoReportListVaFormKHHM(key, maTuKy, maDenKy,LoaiBaoCao, maCongTy, loaiThoiGianSuDung,  _designMode, this.reportBindingSource.Current as Report);

            return true;
        }

        public static void ShowTongHopKhauHaoTheoDonVi_SuDungChoReportListVaFormKHHM(String key, int maTuKy, int maDenKy, int LoaiBaoCao,Int32 maCongTy,Int32 loaiThoiGianSuDung, Boolean designMode, Report report = null)
        {
            ReportHelper.ShowReport(key, () =>
            {

                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);

                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_TongHopKhauHaoTheoDonVi", "@TuKy,@DenKy,@LoaiBaoCao,@MaCongTy,@LoaiThoigianSuDung", maTuKy, maDenKy, LoaiBaoCao, maCongTy, loaiThoiGianSuDung);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DateTime ngayBatDau = Ky_Factory.New().Get_KyByMaKy(maTuKy).NgayBatDau;
                DateTime ngayKetThuc = Ky_Factory.New().Get_KyByMaKy(maDenKy).NgayKetThuc;

                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("NgayIn", typeof(DateTime));
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["NgayIn"] = DateTime.Now.Date;
                dr["TuNgay"] = ngayBatDau;
                dr["DenNgay"] = ngayKetThuc;
                dtngay.Rows.Add(dr);
                dtngay.TableName = "SubInfo";
                dataSet.Tables.Add(dtngay);
                #endregion
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, true, false, designMode, report);
        }
    }
}
