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
    public partial class PhieuThuTuPhieuChi_Factory : BaseFactory<Entities, tblPhieuThutuPhieuChi>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return PhieuThuTuPhieuChi_Factory.New().CreateAloneObject();
        }
        public static PhieuThuTuPhieuChi_Factory New()
        {
            return new PhieuThuTuPhieuChi_Factory();
        }
        public PhieuThuTuPhieuChi_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            BaseFactory<Entities, tblPhieuThutuPhieuChi>.DeleteHelper(context, deleteList);
        }

        public static string GetSoChungTuString(List<tblPhieuThutuPhieuChi> list)
        {
            string kqString = string.Empty;
            foreach (tblPhieuThutuPhieuChi child in list)
            {
                kqString = kqString + ", " + child.SoChungTuPhieuChi;
            }
            if (kqString.Length > 2)
                kqString = kqString.Substring(2, kqString.Length - 2);
            return kqString;
        }
        #endregion
    }//end class
}
