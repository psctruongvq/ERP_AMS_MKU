using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class NhomTaiSanList:BusinessListBase<NhomTaiSanList,NhomTaiSan>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public NhomTaiSan GetNhomTaiSan(int MaNhomTaiSan)
        {
            foreach (NhomTaiSan lhd in this)
                if (lhd.MaNhom == MaNhomTaiSan)
                    return lhd;
            return null;
        }

        public void Remove(int maNhomTaiSan)
        {
            foreach (NhomTaiSan item in this)
            {
                if (item.MaNhom == maNhomTaiSan)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            NhomTaiSan item = NhomTaiSan.NewNhomTaiSan();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static NhomTaiSanList NewNhomTaiSanList()
        {
          return DataPortal.Create<NhomTaiSanList>();
        }

        public static NhomTaiSanList GetNhomTaiSanList( )
        {
          return DataPortal.Fetch<NhomTaiSanList>(new Criteria());
        }

        private NhomTaiSanList()
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
                    cm.CommandText = "select * from tblNhomTaiSan";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(NhomTaiSan.GetNhomTaiSan(dr));
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
            foreach (NhomTaiSan obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (NhomTaiSan obj in this)
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
