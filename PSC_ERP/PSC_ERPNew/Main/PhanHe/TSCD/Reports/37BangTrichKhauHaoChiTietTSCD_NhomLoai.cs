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
        public bool BangTrichKhauHaoChiTietTSCD_NhomLoai()//M
        {
            //if ( ChuaChon_DenNgay())
            //{
            //    return false;
            //}
            String key = (this.reportBindingSource.Current as Report).ReportKey;
            ReportHelper.ShowReport(key, () =>
            {
                tblDanhMucTSCD danhMucTSCD = cbLoaiTaiSan.GetSelectedDataRow() as tblDanhMucTSCD;
                DataSet dataSet = new DataSet();
                SpeedDataAccess dataAccess = new SpeedDataAccess(Database.NormalConnectionString);
                DateTime denNgay = (Convert.ToDateTime(dteDenNgay.EditValue)).Date;
                int maTSCD = 0;
                int maNhom = 0;
                int maLoai = 0;
                if (danhMucTSCD == null)
                {
                    maNhom = maLoai = maTSCD = 0;
                }
                else if (danhMucTSCD.ID == 0)
                {
                    maNhom = maLoai = maTSCD = 0;
                }
                else if ((danhMucTSCD.LaNhomTaiSan==null?false:danhMucTSCD.LaNhomTaiSan.Value)==true)
                {
                    maNhom = danhMucTSCD.ID;
                }
                else if ((danhMucTSCD.LaLoaiTaiSan==null?false:danhMucTSCD.LaLoaiTaiSan.Value)==true)
                {
                    maLoai = danhMucTSCD.ID;
                }
                else if ((danhMucTSCD.LaTaiSanCoDinh == null ? false : danhMucTSCD.LaTaiSanCoDinh.Value) == true)
                {
                    maTSCD = danhMucTSCD.ID;
                }
                dataAccess.FillDataSet(ref dataSet, "MainData", "spRpt_TSCD_BangTrichKhauHaoChiTietTSCD_NhomLoai", "@Ngay,@MaTSCD,@MaNhom,@MaLoai,@MaCongTy", denNgay, maTSCD, maNhom, maLoai,_maCongTy);
                #region Extend table
                //Tao Bang Chua TuNgay, DenNgay
                DataTable dtngay = new DataTable();
                dtngay.Columns.Add("DenNgay", typeof(DateTime));
                //Add dòng 1
                DataRow dr = dtngay.NewRow();
                dr["DenNgay"] = dteDenNgay.EditValue;
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
