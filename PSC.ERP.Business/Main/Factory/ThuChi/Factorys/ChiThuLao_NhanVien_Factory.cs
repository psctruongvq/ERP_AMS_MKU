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
    public partial class ChiThuLao_NhanVien_Factory : BaseFactory<Entities, tblChiThuLao_NhanVien>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return ChiThuLao_NhanVien_Factory.New().CreateAloneObject();
        }
        public static ChiThuLao_NhanVien_Factory New()
        {
            return new ChiThuLao_NhanVien_Factory();
        }
        public ChiThuLao_NhanVien_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public static void FullDelete(Entities context, List<Object> deleteList)
        {
            BaseFactory<Entities, tblChiThuLao_NhanVien>.DeleteHelper(context, deleteList);
        }
        #endregion
    }//end class
}