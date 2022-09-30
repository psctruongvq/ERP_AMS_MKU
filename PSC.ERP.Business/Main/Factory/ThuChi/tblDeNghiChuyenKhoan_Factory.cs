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
    public partial class tblDeNghiChuyenKhoan_Factory : BaseFactory<Entities, tblDeNghiChuyenKhoan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return tblDeNghiChuyenKhoan_Factory.New().CreateAloneObject();
        }
        public static tblDeNghiChuyenKhoan_Factory New()
        {
            return new tblDeNghiChuyenKhoan_Factory();
        }

        public tblDeNghiChuyenKhoan_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public tblDeNghiChuyenKhoan Get_DeNghiChuyenKhoan_ByMaPhieu(long maPhieu)
        {
            tblDeNghiChuyenKhoan obj = (from o in this.ObjectSet
                             where o.MaPhieu == maPhieu
                             select o).SingleOrDefault();
            return obj;
        }
        #endregion
    }//end class
}
