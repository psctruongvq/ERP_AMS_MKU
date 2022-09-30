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

namespace PSC_ERP_Business.Main.Factory
{
    public partial class ChiThuLao_Factory : BaseFactory<Entities, tblcnChiThuLao>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChiThuLao_Factory.New().CreateAloneObject();
        }
        public static ChiThuLao_Factory New()
        {
            return new ChiThuLao_Factory();
        }
        public ChiThuLao_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public virtual tblcnChiThuLao GetChiThuLaoByID(long machithulao)
        {
            tblcnChiThuLao ctl = (from o in this.ObjectSet
                                  where o.MaChiThuLao == machithulao
                                  select o).SingleOrDefault<tblcnChiThuLao>();
            return ctl;
        }

        public static void FullDelete(Entities context, List<tblcnChiThuLao> deleteList)
        {
            foreach (tblcnChiThuLao ctl in deleteList)
            {
                ChiThuLao_NhanVien_Factory.FullDelete(context, ctl.tblChiThuLao_NhanVien.ToList<Object>());
                context.tblcnChiThuLaos.DeleteObject(ctl);
            }
        }

        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            foreach (tblcnChiThuLao ctl in deleteList)
            {
                ChiThuLao_NhanVien_Factory.FullDelete(context, ctl.tblChiThuLao_NhanVien.ToList<Object>());
            }
            BaseFactory<Entities, tblcnChiThuLao>.DeleteHelper(context, deleteList);
        }
        #endregion
    }//end class
}
