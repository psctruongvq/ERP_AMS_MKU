using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class LoaiTaiKhoanList:BusinessListBase<LoaiTaiKhoanList,LoaiTaiKhoan>
    {
          #region Business Methods

        // TODO: add public properties and methods

        public LoaiTaiKhoan GetLoaiTaiKhoan(int MaLoaiTK)
        {
            foreach (LoaiTaiKhoan ltk in this)
                if (ltk.MaLoaiTK == MaLoaiTK)
                    return ltk;
            return null;
        }

        public void Remove(int maLoaiTK)
        {
            foreach (LoaiTaiKhoan item in this)
            {
                if (item.MaLoaiTK == maLoaiTK)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            LoaiTaiKhoan item = LoaiTaiKhoan.NewLoaiTaiKhoan();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static LoaiTaiKhoanList NewLoaiTaiKhoanList()
        {
          return DataPortal.Create<LoaiTaiKhoanList>();
        }

        public static LoaiTaiKhoanList GetLoaiTaiKhoanList( )
        {
          return DataPortal.Fetch<LoaiTaiKhoanList>(new Criteria());
        }

        private LoaiTaiKhoanList()
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
            try
            {
                this.RaiseListChangedEvents = false;
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select * from tblLoaiTaiKhoan";
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(LoaiTaiKhoan.GetLoaiTaiKhoan(dr));
                            }
                        }
                    }
                }
                this.RaiseListChangedEvents = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        

        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (LoaiTaiKhoan obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (LoaiTaiKhoan obj in this)
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
