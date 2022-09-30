using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class TaiSuDungList:BusinessListBase<TaiSuDungList,TaiSuDung>
    {
        
   #region Business Methods

        // TODO: add public properties and methods

        public TaiSuDung GetTaiSuDung(int MaTaiSuDung)
        {
            foreach (TaiSuDung nsd in this)
                if (nsd.MaNghiepVuTaiSuDungTSCD == MaTaiSuDung)
                    return nsd;
            return null;
        }

        public void Remove(int maTaiSuDung)
        {
            foreach (TaiSuDung item in this)
            {
                if (item.MaNghiepVuTaiSuDungTSCD == maTaiSuDung)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            TaiSuDung item = TaiSuDung.NewTaiSuDung();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static TaiSuDungList NewTaiSuDungList()
        {
          //return DataPortal.Create<TaiSuDungList>();
            return new TaiSuDungList();
        }

        public static TaiSuDungList GetTaiSuDungList( )
        {
          return DataPortal.Fetch<TaiSuDungList>(new Criteria());
        }
               
        private TaiSuDungList()
        {
            this.AllowNew = true;            
        }

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            //hong làm gì hêt
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select * from view_loadDanhSachTaiSanTaiSuDung";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(TaiSuDung.GetTaiSuDung(dr));
                        }
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // add/update any current child objects
            foreach (TaiSuDung obj in this)
            {
                if (obj.IsDirty)
                {
                    if (obj.IsNew)
                        obj.Insert();                  
                }
            }
            this.RaiseListChangedEvents = true;
        }

        #endregion
    }
}
