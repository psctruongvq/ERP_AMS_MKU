using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class LoaiChungTuList:BusinessListBase<LoaiChungTuList,LoaiChungTu>
    {
        
        #region Business Methods

        // TODO: add public properties and methods

        public LoaiChungTu GetLoaiChungTu(int maLoaiCT)
        {
            foreach (LoaiChungTu ct in this)
                if (ct.MaLoaiCT == maLoaiCT)
                    return ct;
            return null;
        }

        public void Remove(int maLoaiCT)
        {
            foreach (LoaiChungTu item in this)
            {
                if (item.MaLoaiCT == maLoaiCT)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            LoaiChungTu item = LoaiChungTu.NewLoaiChungTu();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static LoaiChungTuList NewLoaiChungTuList()
        {
          return DataPortal.Create<LoaiChungTuList>();
        }

        public static LoaiChungTuList GetLoaiChungTuList( )
        {
          return DataPortal.Fetch<LoaiChungTuList>(new Criteria());
        }
               
        private LoaiChungTuList()
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
                    cm.CommandText = "select * from tblLoaiChungTu";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(LoaiChungTu.GetLoaiChungTu(dr));
                        }
                    }
                }

            }
            this.RaiseListChangedEvents = true;
        }
        


        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (LoaiChungTu obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (LoaiChungTu obj in this)
            {
                if (obj.IsDirty)
                {
                    if (obj.IsNew)
                        obj.Insert();
                    else
                        obj.Update();
                }
            }
            this.RaiseListChangedEvents = true;         
        }  

      

        #endregion
    }
}
