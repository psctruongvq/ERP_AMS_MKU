using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    public class NghiepVuPhanBoList:BusinessListBase<NghiepVuPhanBoList,NghiepVuPhanBo>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public NghiepVuPhanBo GetNghiepVuPhanBo(int MaPhanBo)
        {
            foreach (NghiepVuPhanBo pb in this)
                if (pb.MaPhanBo == MaPhanBo)
                    return pb;
            return null;
        }

        public void Remove(int maPhanBo)
        {
            foreach (NghiepVuPhanBo item in this)
            {
                if (item.MaPhanBo == maPhanBo)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            NghiepVuPhanBo item = NghiepVuPhanBo.NewNghiepVuPhanBo();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static NghiepVuPhanBoList NewNghiepVuPhanBoList()
        {
          return DataPortal.Create<NghiepVuPhanBoList>();
        }

        public static NghiepVuPhanBoList GetNghiepVuPhanBoList( )
        {
          return DataPortal.Fetch<NghiepVuPhanBoList>(new Criteria());
        }

        public NghiepVuPhanBoList()
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
                    cm.CommandText = "select * from tblChiTietTaiSanCaBiet";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(NghiepVuPhanBo.GetNghiepVuPhanBo(dr));
                        }
                    }
                }

            }
            this.RaiseListChangedEvents = true;
        }

        public void DataPortal_Update(SqlTransaction tr)
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (NghiepVuPhanBo obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (NghiepVuPhanBo obj in this)
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
