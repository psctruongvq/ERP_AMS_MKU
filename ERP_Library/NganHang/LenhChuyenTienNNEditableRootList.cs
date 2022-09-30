
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LenhChuyenTienNuocNgoaiList : Csla.BusinessListBase<LenhChuyenTienNuocNgoaiList, LenhChuyenTienNuocNgoai>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			LenhChuyenTienNuocNgoai item = LenhChuyenTienNuocNgoai.NewLenhChuyenTienNuocNgoai();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LenhChuyenTienNuocNgoaiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LenhChuyenTienNuocNgoaiListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LenhChuyenTienNuocNgoaiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LenhChuyenTienNuocNgoaiListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LenhChuyenTienNuocNgoaiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LenhChuyenTienNuocNgoaiListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LenhChuyenTienNuocNgoaiList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LenhChuyenTienNuocNgoaiListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LenhChuyenTienNuocNgoaiList()
		{ /* require use of factory method */ }

		public static LenhChuyenTienNuocNgoaiList NewLenhChuyenTienNuocNgoaiList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LenhChuyenTienNuocNgoaiList");
			return new LenhChuyenTienNuocNgoaiList();
		}

		public static LenhChuyenTienNuocNgoaiList GetLenhChuyenTienNuocNgoaiList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LenhChuyenTienNuocNgoaiList");
			return DataPortal.Fetch<LenhChuyenTienNuocNgoaiList>(new FilterCriteria());
		}

        public static LenhChuyenTienNuocNgoaiList GetLenhChuyenTienNuocNgoaiList_ChuaCT()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LenhChuyenTienNuocNgoaiList");
            return DataPortal.Fetch<LenhChuyenTienNuocNgoaiList>(new FilterCriteriaChuaCT());
        }

        public static LenhChuyenTienNuocNgoaiList GetLenhChuyenTienNuocNgoaiList(DateTime dtTuNgay, DateTime dtDenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LenhChuyenTienNuocNgoaiList");
            return DataPortal.Fetch<LenhChuyenTienNuocNgoaiList>(new FilterCriteria_ByNgayLap(dtTuNgay, dtDenNgay));
        }
		#endregion //Factory Methods


        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public FilterCriteria()
            {

            }
        }

        private class FilterCriteriaChuaCT
        {
            public FilterCriteriaChuaCT()
            {

            }
        }

        private class FilterCriteria_ByNgayLap
        {
            public DateTime _dtTuNgay;
            public DateTime _dtDenNgay;
            public FilterCriteria_ByNgayLap(DateTime dtTuNgay, DateTime dtDenNgay)
            {
                this._dtTuNgay = dtTuNgay;
                this._dtDenNgay = dtDenNgay;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblLenhChuyenTienNuocNgoaisAll";
                    cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteria_ByNgayLap)
                {
                    cm.CommandText = "spd_SelecttblLenhChuyenTienNuocNgoai_ByNgayLap";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByNgayLap)criteria)._dtTuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByNgayLap)criteria)._dtDenNgay);
                    cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
                }
                else if (criteria is FilterCriteriaChuaCT)
                {
                    cm.CommandText = "spd_SelecttblLenhChuyenTienNuocNgoai_ChuaLapDN";
                    cm.Parameters.AddWithValue("@UserId", Security.CurrentUser.Info.UserID);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(LenhChuyenTienNuocNgoai.GetLenhChuyenTienNuocNgoai(dr));
                }
            }//using
        }
        #endregion //Data Access - Fetch


        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (LenhChuyenTienNuocNgoai deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (LenhChuyenTienNuocNgoai child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr, this);
                        else
                            child.Update(tr, this);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
