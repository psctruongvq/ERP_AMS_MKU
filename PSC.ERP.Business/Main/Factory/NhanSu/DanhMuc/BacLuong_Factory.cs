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
namespace PSC_ERP_Business.Main.Factory//
{
    public partial class BacLuong_Factory : BaseFactory<Entities, tblnsBacLuongCoBan>
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static PSC_ERP_Core.BaseEntityObject CreateStandAloneObject()
        {
            return BacLuong_Factory.New().CreateAloneObject();
        }
        public static BacLuong_Factory New()
        {
            return new BacLuong_Factory();
        }
        public BacLuong_Factory()
            : base(Database.NewEntities())
        {

        }

        #region Custom
        public override IQueryable<tblnsBacLuongCoBan> GetAll()
        {
            IQueryable<tblnsBacLuongCoBan> query = from o in ObjectSet orderby o.TenBacLuongCoBan select o;
            return query;
        }
        public tblnsBacLuongCoBan GetById(int id)
        {
            tblnsBacLuongCoBan obj = this.ObjectSet.SingleOrDefault(o => o.MaBacLuongCoBan == id);
            return obj;
        }

        #endregion
    }//end class
}
