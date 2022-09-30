
/*
 *Người viết: Nguyễn Phú Cường 
 * 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Reflection;

namespace PSC_ERP_Core
{
    public class BaseEntityObject : EntityObject
    {
        //public bool IsNew
        //{
        //    get
        //    {
        //        return base.EntityState == System.Data.EntityState.Added ? true : false;
        //    }
        //}
        public BaseEntityObject()
        {

        }
        ////public bool ChildListIsDirty//tuong doi, ko chinh xac tuyet doi
        ////{
        ////    get
        ////    {
        ////        Type type = this.GetType();
        ////        PropertyInfo[] infos = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        ////        foreach (PropertyInfo inf in infos)
        ////        {

        ////            dynamic obj = inf.GetValue(this, null);
        ////            if (obj != null && obj.GetType().BaseType == typeof(ICollection<>))
        ////            {
        ////                Type childListType = obj.GetType();
        ////                IEnumerator<EntityObject> lst = obj.GetEnumerator();

        ////                do
        ////                {
        ////                    if (lst.Current != null && (lst.Current.EntityState == System.Data.EntityState.Added
        ////                                        || lst.Current.EntityState == System.Data.EntityState.Modified))
        ////                    {
        ////                        return true;
        ////                    }
        ////                }
        ////                while (lst.MoveNext());

        ////            }

        ////        }
        ////        return false;
        ////    }
        ////}




      
    }
}
