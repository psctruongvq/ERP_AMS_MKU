using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{

    [Serializable()]
    public class HeThongTaiKhoan1List : Csla.BusinessListBase<HeThongTaiKhoan1List, HeThongTaiKhoan1>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            HeThongTaiKhoan1 item = HeThongTaiKhoan1.NewHeThongTaiKhoan1();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HeThongTaiKhoan1List
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HeThongTaiKhoan1ListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HeThongTaiKhoan1List
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HeThongTaiKhoan1ListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HeThongTaiKhoan1List
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HeThongTaiKhoan1ListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HeThongTaiKhoan1List
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HeThongTaiKhoan1ListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HeThongTaiKhoan1List()
        { /* require use of factory method */ }

        public static HeThongTaiKhoan1List NewHeThongTaiKhoan1List()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HeThongTaiKhoan1List");
            return new HeThongTaiKhoan1List();
        }

        public static HeThongTaiKhoan1List GetHeThongTaiKhoan1List(int MaTaiKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1List");
            return DataPortal.Fetch<HeThongTaiKhoan1List>(new FilterCriteria(MaTaiKhoan));
        }
        public static HeThongTaiKhoan1List GetHeThongTaiKhoan1ListByAll()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1List");
            return DataPortal.Fetch<HeThongTaiKhoan1List>(new FilterCriteriaByAll());
        }
        public static HeThongTaiKhoan1List GetHeThongTaiKhoan1List(string MaTaiKhoanChuoi)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1List");
            return DataPortal.Fetch<HeThongTaiKhoan1List>(new CriteriaMaChuoi(MaTaiKhoanChuoi));
        }
        public static HeThongTaiKhoan1List GetHeThongTaiKhoan1List()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1List");
            return DataPortal.Fetch<HeThongTaiKhoan1List>(new FilterCriteriaAll());
        }

        public static HeThongTaiKhoan1List GetHeThongTaiKhoan1ListByCongTy()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1List");
            return DataPortal.Fetch<HeThongTaiKhoan1List>(new FilterCriteriaAllByCongTy());
        }

        public static HeThongTaiKhoan1List GetHeThongTaiKhoan1ListCha()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1List");
            return DataPortal.Fetch<HeThongTaiKhoan1List>(new FilterCriteriaCha());
        }
        public static HeThongTaiKhoan1List GetHeThongTaiKhoan1ListTheoDoi()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1List");
            return DataPortal.Fetch<HeThongTaiKhoan1List>(new FilterCriteriaTheoDoi());
        }

        public static HeThongTaiKhoan1List GetHeThongTaiKhoanBySoHieu(string SoHieuTaiKhoan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1List");
            return DataPortal.Fetch<HeThongTaiKhoan1List>(new FilterCriteriaBySoHieu(SoHieuTaiKhoan));
        }

        public static HeThongTaiKhoan1List GetTaiKhoanConListByCongTy()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HeThongTaiKhoan1List");
            return DataPortal.Fetch<HeThongTaiKhoan1List>(new FilterCriteriaTaiKhoanConByCongTy());
        }

        public static HeThongTaiKhoan1List GetTaiKhoanCapBa()
        {
            HeThongTaiKhoan1List listTKCapBa = new HeThongTaiKhoan1List();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select * from view_HeThongTaiKhoanCapBa";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            listTKCapBa.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                        }
                    }
                }

            }
            return listTKCapBa;
        }

        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
                
            }
        }
        private class FilterCriteriaByAll
        {
            public FilterCriteriaByAll()
            {

            }
        }

        private class FilterCriteriaAllByCongTy
        {
            public FilterCriteriaAllByCongTy()
            {

            }
        }

        private class FilterCriteriaTaiKhoanConByCongTy
        {
            public FilterCriteriaTaiKhoanConByCongTy()
            {

            }
        }
        
        [Serializable()]
        private class CriteriaMaChuoi
        {
            public string MaTaiKhoanChuoi;

            public CriteriaMaChuoi(string maTaiKhoanChoi)
            {
                this.MaTaiKhoanChuoi = maTaiKhoanChoi;
            }
        }

        private class FilterCriteriaBySoHieu
        {
            public string SoHieuTK;

            public FilterCriteriaBySoHieu(string soHieuTK)
            {
                this.SoHieuTK = soHieuTK;
            }
        }

        private class FilterCriteria
        {
            public int MaTaiKhoan;

            public FilterCriteria(int maTaiKhoan)
            {
                this.MaTaiKhoan = maTaiKhoan;
            }
        }
        private class FilterCriteriaTheoDoi
        {
            public FilterCriteriaTheoDoi()
            {
            }
        }
        [Serializable()]
        private class FilterCriteriaCha
        {
            public FilterCriteriaCha()
            {
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            if (criteria is FilterCriteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTaiKhoans";
                    cm.Parameters.AddWithValue("@MaTaiKhoan", ((FilterCriteria)criteria).MaTaiKhoan);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                    }
                }//using
            }
            if (criteria is CriteriaMaChuoi)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimTaiKhoanChuoi";
                    cm.Parameters.AddWithValue("@TaiKhoan", ((CriteriaMaChuoi)criteria).MaTaiKhoanChuoi);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                    }
                }//using
                
            }
               
            else if (criteria is FilterCriteriaCha)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTaiKhoansAllCha";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaByAll)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTaiKhoanByAll";
                    cm.Parameters.AddWithValue("@MaCongTy",ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaAll)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTaiKhoansAll";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaAllByCongTy)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTaiKhoansAllByCongTy";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaTheoDoi)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTaiKhoansAllListTheoDoi";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaBySoHieu)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LayMaTaiKhoan_New";
                    cm.Parameters.AddWithValue("@SoHieuTK", ((FilterCriteriaBySoHieu)criteria).SoHieuTK);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                    }
                }//using
            }
            else if (criteria is FilterCriteriaTaiKhoanConByCongTy)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetTaiKhoanConByMaCongTy";
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HeThongTaiKhoan1.GetHeThongTaiKhoan1(dr));
                    }
                }//using
            }

        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                // loop through each deleted child object
                foreach (HeThongTaiKhoan1 deletedChild in DeletedList)
                    deletedChild.DeleteSelf(cn);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (HeThongTaiKhoan1 child in this)
                {
                    if (child.IsNew)
                        child.Insert(cn);
                    else
                        child.Update(cn);
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
