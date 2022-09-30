using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class KyList:BusinessListBase<KyList,Ky>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public Ky GetKy(int MaKy)
        {
            foreach (Ky k in this)
                if (k.MaKy == MaKy)
                    return k;
            return null;
        }

        public void Remove(int maKy)
        {
            foreach (Ky item in this)
            {
                if (item.MaKy == maKy)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            Ky item = Ky.NewKy();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static KyList NewKyList()
        {
          return DataPortal.Create<KyList>();
        }

        public static KyList GetKyList( )
        {
          return DataPortal.Fetch<KyList>(new Criteria());
        }
        public static KyList GetKyListByKhoaSo()
        {
            return DataPortal.Fetch<KyList>(new CriteriaByKhoaSo());
        }
        public static KyList GetKyList(int maKy)
        {
            return DataPortal.Fetch<KyList>(new CriteriaByMaKy(maKy));
        }      
        private KyList()
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
        private class CriteriaByMaKy
        {
            public int MaKy;
            public CriteriaByMaKy(int maKy)
            {
                this.MaKy = maKy;
            }
        }
        [Serializable()]
        private class CriteriaByKhoaSo
        {
            //hong làm gì hêt
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            if (criteria is Criteria)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblKysAll";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(Ky.GetKy(dr));
                            }
                        }
                    }

                }
            
             
            }//using
            else if (criteria is CriteriaByMaKy)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelectKyByMaKy";
                        cm.Parameters.AddWithValue("@MaKy", (((CriteriaByMaKy)criteria)).MaKy);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(Ky.GetKy(dr));
                            }
                        }
                    }
                }            
            }
            else if (criteria is CriteriaByKhoaSo)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblKysAllByKhoaSo";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(Ky.GetKy(dr));
                            }
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
            foreach (Ky obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (Ky obj in this)
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
