﻿using System;
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
    public class CT_NghiepVuSuaChuaLon_Factory : BaseFactory<Entities, tblCT_NghiepVuSuaChuaLon>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return CT_NghiepVuSuaChuaLon_Factory.New().CreateAloneObject();
        }
        public static CT_NghiepVuSuaChuaLon_Factory New()
        {
            return new CT_NghiepVuSuaChuaLon_Factory();
        }
        public CT_NghiepVuSuaChuaLon_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDeleteCT_NghiepVuSuaChuaLon(Entities context, List<Object> deleteList)
        {
          
            BaseFactory<Entities, tblCT_NghiepVuSuaChuaLon>.DeleteHelper(context, deleteList);

        }
        #endregion
    }//end class
}
