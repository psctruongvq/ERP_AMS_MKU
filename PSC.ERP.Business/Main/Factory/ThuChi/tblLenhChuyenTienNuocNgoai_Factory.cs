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
    public partial class tblLenhChuyenTienNuocNgoai_Factor : BaseFactory<Entities, tblLenhChuyenTienNuocNgoai>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return tblLenhChuyenTienNuocNgoai_Factor.New().CreateAloneObject();
        }
        public static tblLenhChuyenTienNuocNgoai_Factor New()
        {
            return new tblLenhChuyenTienNuocNgoai_Factor();
        }

        public tblLenhChuyenTienNuocNgoai_Factor()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblLenhChuyenTienNuocNgoai Get_LenhChuyenTienNuocNgoai_ByMaLenhCT(long maLenhCT)
        {
            tblLenhChuyenTienNuocNgoai obj = (from o in this.ObjectSet
                             where o.MaLenhCT == maLenhCT
                             select o).SingleOrDefault();
            return obj;
        }
        #endregion
    }//end class
}
