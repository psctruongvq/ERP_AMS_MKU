using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{

    public class DinhKhoanList:BusinessListBase<DinhKhoanList,DinhKhoan>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public DinhKhoan GetDinhKhoan(int maDinhKhoan)
        {
            foreach (DinhKhoan dk in this)
                if (dk.MaDinhKhoan == maDinhKhoan)
                    return dk;
            return null;
        }

        public void Remove(int maDinhKhoan)
        {
            foreach (DinhKhoan item in this)
            {
                if (item.MaDinhKhoan == maDinhKhoan)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            DinhKhoan item = DinhKhoan.NewDinhKhoan();
            Add(item);
            return item;
        }
        #endregion    



        #region Factory Methods

        public static DinhKhoanList NewDinhKhoanList()
        {
          return DataPortal.Create<DinhKhoanList>();
        }

        public static DinhKhoanList GetDinhKhoanList( )
        {
          return DataPortal.Fetch<DinhKhoanList>(new Criteria());
        }
               
        private DinhKhoanList()
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
                    cm.CommandText = "select * from tblDinhKhoan";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(DinhKhoan.GetDinhKhoan(dr));
                        }
                    }
                }

            }
            this.RaiseListChangedEvents = true;
        }
        


        protected  void DataPortal_Update(SqlTransaction tr)
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (DinhKhoan obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (DinhKhoan obj in this)
            {
                if (obj.IsDirty)
                {
                    if (obj.IsNew)
                        obj.Insert(tr);
                    else
                        obj.Update(tr);
                }
            }
            this.RaiseListChangedEvents = true;         
        }  

      

        #endregion

    }
}
