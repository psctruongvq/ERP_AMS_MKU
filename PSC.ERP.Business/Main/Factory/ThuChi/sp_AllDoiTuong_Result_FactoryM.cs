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
    public partial class sp_AllDoiTuong_Result_Factory 
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

      

        #region Custom

        public static IEnumerable<sp_AllDoiTuong_Result> GetAllByMaCongTy(Int32 maCongTy)
        {

            IEnumerable<sp_AllDoiTuong_Result> query = ChungTuThuChi_DerivedFactory.New().Context.sp_AllDoiTuong(0).Where(x => x.MaCongTy == maCongTy);
            return query;
        }
        #endregion
    }//end class
}
