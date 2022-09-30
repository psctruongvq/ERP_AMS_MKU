using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Core;
using System.Reflection;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Objects;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main;
using PSC_ERP_Util.DateTimeExtension;
using System.Collections;
using PSC_ERP_Common.Ado.Net;
using System.Data.SqlClient;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class spd_SelectChungTuPhieuChiListforLapPhieuThu_Factory 
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static spd_SelectChungTuPhieuChiListforLapPhieuThu_Factory New()
        {
            return new spd_SelectChungTuPhieuChiListforLapPhieuThu_Factory();
        }

        #region Custom
        public static decimal GetTienThueConLai(long maPhieuChi, long maPhieuThu)
        {
            decimal Result = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.NormalConnectionString))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_GetTienThueConLaicuaPhieuChi";
                        cm.Parameters.AddWithValue("@MaPhieuChi", maPhieuChi);
                        cm.Parameters.AddWithValue("@MaPhieuThu", maPhieuThu);
                        SqlParameter prmGiaTriTraVe = new SqlParameter("@result", SqlDbType.Decimal, 18);
                        prmGiaTriTraVe.Precision = 18;
                        prmGiaTriTraVe.Scale = 3;
                        prmGiaTriTraVe.Direction = ParameterDirection.Output;
                        cm.Parameters.Add(prmGiaTriTraVe);
                        cm.ExecuteNonQuery();
                        Result = (decimal)prmGiaTriTraVe.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }
        #endregion
    }//end class
}
