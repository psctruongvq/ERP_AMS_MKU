using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class DanhGiaLaiList:BusinessListBase<DanhGiaLaiList,DanhGiaLai>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public DanhGiaLai GetDanhGiaLai(int maDanhGiaLai)
        {
            foreach (DanhGiaLai dgl in this)
                if (dgl.MaNghiepVuDanhGiaLai == maDanhGiaLai)
                    return dgl;
            return null;
        }

        public void Remove(int maDanhGiaLai)
        {
            foreach (DanhGiaLai item in this)
            {
                if (item.MaNghiepVuDanhGiaLai == maDanhGiaLai)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            DanhGiaLai item = DanhGiaLai.NewDanhGiaLai();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static DanhGiaLaiList NewDanhGiaLaiList()
        {
          return DataPortal.Create<DanhGiaLaiList>();
        }

        public static DanhGiaLaiList GetDanhGiaLaiList( )
        {
          return DataPortal.Fetch<DanhGiaLaiList>(new Criteria());
        }

        private DanhGiaLaiList()
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

        private void DataPortal_Create(Criteria criteria)
        {
            // TODO: load default values into object
        }

        private void DataPortal_Fetch(Criteria criteria)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadAllNghiepVuDanhGiaLai";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(DanhGiaLai.GetDanhGiaLai(dr));
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
            foreach (DanhGiaLai obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();



            // add/update any current child objects
            foreach (DanhGiaLai obj in this)
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

        private void DataPortal_Delete(Criteria criteria)
        {
            // TODO: delete object's data
        }

        #endregion

    }
}
