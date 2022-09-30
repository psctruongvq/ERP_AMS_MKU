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

namespace PSC_ERP_Business.Main.Factory
{
    public partial class sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014_Factory 
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #region Custom

        public static IEnumerable<sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014_Result> GetAll()
        {

            IEnumerable<sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014_Result> query = ChungTu_Factory.New().Context.sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014();
            return query;
        }
        #endregion
    }//end class
}
