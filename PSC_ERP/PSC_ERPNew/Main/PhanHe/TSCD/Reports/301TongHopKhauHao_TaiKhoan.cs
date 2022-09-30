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
        public bool TongHopKhauHaoTSCD_TaiKhoan()//M
        {
            int maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            //if (ChuaChon_TuNgay() || ChuaChon_DenNgay() || ChuaChon_BoPhan())
            //{
            //    return false;
            //}
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            int maTuKy = (Int32)cbTuKy.EditValue;
            int maDenKy = (Int32)cbDenKy.EditValue;
            int LoaiBaoCao = (Int32)radioGroupLoaiBaoCao.EditValue;
            int loaiThoiGianSuDung = 0;
            ShowTongHopKhauHaoTSCD_TaiKhoan_SuDungChoReportListVaFormKHHM(key, maTuKy, maDenKy, maCongTy, loaiThoiGianSuDung, _designMode, this.reportBindingSource.Current as Report);
            return true;
        }

        public static void ShowTongHopKhauHaoTSCD_TaiKhoan_SuDungChoReportListVaFormKHHM(String key, int maTuKy, int maDenKy, int maCongTy,int loaiThoiGianSuDung, Boolean designMode, Report report = null)
        {
            ReportHelper.ShowReport(key, () =>
            {
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);

                //int maBoPhan = (Int32)cbPhongBan.EditValue;
                //int nguonMua = (Int32)radioGroupNguonMua_Le_DuAn.EditValue;
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_TongHopKhauHaoTSCD_TaiKhoan", "@TuKy,@DenKy,@MaCongTy,@LoaiThoigianSuDung", maTuKy, maDenKy, maCongTy, loaiThoiGianSuDung);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("TuNgay", typeof(DateTime));
                dtngay.Columns.Add("DenNgay", typeof(DateTime));

                Ky_Factory _ky_Factory = Ky_Factory.New();
                tblKy _tuKy = _ky_Factory.Get_KyByMaKy(maTuKy);
                tblKy _denKy = _ky_Factory.Get_KyByMaKy(maDenKy);
                if (_tuKy != null && _denKy != null)
                {
                    //Add dòng 1
                    DataRow dr = dtngay.NewRow();
                    dr["TuNgay"] = _tuKy.NgayBatDau;
                    dr["DenNgay"] = _denKy.NgayKetThuc;
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
