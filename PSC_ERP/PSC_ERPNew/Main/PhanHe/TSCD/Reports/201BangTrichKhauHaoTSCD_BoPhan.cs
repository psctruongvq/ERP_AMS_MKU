using System;
using System.Data;
using PSC_ERP_Business.Main;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Common.Ado.Net;
using PSC_ERPNew.Main.Reports;
using PSC_ERP_Business.Main.Factory;

namespace PSC_ERPNew.Main.PhanHe.TSCD.Reports
{
    public partial class frmTSCDReportList
    {
        public bool BangTrichKhauHaoTSCD_BoPhan()//M
        {

            //if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            //{
            //    return false;
            //}
            int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            int maTuKy = (Int32)cbTuKy.EditValue;
            int maDenKy = (Int32)cbDenKy.EditValue;
            int loaiThoiGianSuDung = 0;
            //int maBoPhan = (Int32)cbPhongBan.EditValue;
            int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            int maBoPhan = (Int32)treeListLookUpEdit_BoPhan.EditValue;  
            ShowBangTrichKhauHaoTSCD_BoPhan_SuDungChoReportListVaFormKHHM(key, maTuKy, maDenKy, maBoPhan, LoaiBaoCao, maCongTy, loaiThoiGianSuDung, _designMode, this.reportBindingSource.Current as Report );
            return true;
        }

        public static void ShowBangTrichKhauHaoTSCD_BoPhan_SuDungChoReportListVaFormKHHM(String key, Int32 maTuKy, Int32 maDenKy, Int32 maBoPhan, Int32 loaiBaoCao, Int32 maCongTy, Int32 loaiThoiGianSuDung, Boolean designMode, Report report = null)
        {
            ReportHelper.ShowReport(key, () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);

                //int nguonMua = (Int32)radioGroupNguonMua_Le_DuAn.EditValue;
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BangTrichKhauHaoTSCD_BoPhan", "@TuKy,@DenKy,@MaBoPhan,@LoaiBaoCao,@MaCongTy,@LoaiThoigianSuDung", maTuKy, maDenKy, maBoPhan, loaiBaoCao, maCongTy, loaiThoiGianSuDung);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));

                Ky_Factory ky_Factory = Ky_Factory.New();
                tblKy tuKy = ky_Factory.Get_KyByMaKy(maTuKy);
                tblKy denKy = ky_Factory.Get_KyByMaKy(maDenKy);
                if (tuKy != null && denKy != null)
                {
                    //Add dòng 1
                    DataRow dr = dtngay.NewRow();
                    dr["TuNgay"] = tuKy.NgayBatDau;
                    dr["DenNgay"] = denKy.NgayKetThuc;
                    dtngay.Rows.Add(dr);
                    dtngay.TableName = "SubInfo";
                    dataSet.Tables.Add(dtngay);
                }
                #endregion
                return dataSet;
            }, PSC_ERP_Global.TSCD.MaPhanHeTSCD, true, false, designMode, report);
        }
    }
}
