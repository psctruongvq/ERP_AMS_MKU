using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class GhiTangTaiSanList:BusinessListBase<GhiTangTaiSanList,GhiTangTaiSan>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public GhiTangTaiSan GetGhiTangTaiSan(int maGhiTangTaiSan)
        {
            foreach (GhiTangTaiSan dgl in this)
                if (dgl.MaNghiepVuGhiTang == maGhiTangTaiSan)
                    return dgl;
            return null;
        }

        public void Remove(int maGhiTangTaiSan)
        {
            foreach (GhiTangTaiSan item in this)
            {
                if (item.MaNghiepVuGhiTang == maGhiTangTaiSan)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            GhiTangTaiSan item = GhiTangTaiSan.NewGhiTangTaiSan();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static GhiTangTaiSanList NewGhiTangTaiSanList()
        {
          return DataPortal.Create<GhiTangTaiSanList>();
        }

        public static GhiTangTaiSanList GetGhiTangTaiSanList( )
        {
          return DataPortal.Fetch<GhiTangTaiSanList>(new Criteria());
        }

        private GhiTangTaiSanList()
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

         public static GhiTangTaiSan GetNghiepVuGhiTangTheoChungTu(long maChungTu)
        { 
            GhiTangTaiSan nghiepVuGhiTang = GhiTangTaiSan.NewGhiTangTaiSan();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_NghiepVuGhiTangTheoChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            nghiepVuGhiTang = GhiTangTaiSan.GetGhiTangTaiSan(dr);
                            // load child objects
                            dr.NextResult();
                        }
                    }
                }
            }
                    return nghiepVuGhiTang;

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
                    cm.CommandText = "spd_LoadAllNghiepVuGhiTang";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(GhiTangTaiSan.GetGhiTangTaiSan(dr));
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
            foreach (GhiTangTaiSan obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // add/update any current child objects
            foreach (GhiTangTaiSan obj in this)
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
