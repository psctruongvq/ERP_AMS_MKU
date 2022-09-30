
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTu_QuyetDinhList : Csla.BusinessListBase<ChungTu_QuyetDinhList, ChungTu_QuyetDinh>
	{
        public long MaQuyetDinh = 0;

        public static long MaChungTu = 0;

        #region BindingList Overrides
		protected override object AddNewCore()
		{
			ChungTu_QuyetDinh item = ChungTu_QuyetDinh.NewChungTu_QuyetDinh();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChungTu_QuyetDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_QuyetDinhListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChungTu_QuyetDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_QuyetDinhListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChungTu_QuyetDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_QuyetDinhListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChungTu_QuyetDinhList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTu_QuyetDinhListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChungTu_QuyetDinhList()
		{ /* require use of factory method */ }

		public static ChungTu_QuyetDinhList NewChungTu_QuyetDinhList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTu_QuyetDinhList");
			return new ChungTu_QuyetDinhList();
		}

        public static ChungTu_QuyetDinhList GetChungTu_QuyetDinhList(long _maChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTu_QuyetDinhList");
            return DataPortal.Fetch<ChungTu_QuyetDinhList>(new FilterCriteria_ChungTu(_maChungTu));
        }

		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
        [Serializable()]
        private class FilterCriteria_ChungTu
        {
            public long MaChungTu;
            public FilterCriteria_ChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
		private void DataPortal_Fetch(FilterCriteria_ChungTu criteria)
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

		private void ExecuteFetch(SqlTransaction tr, FilterCriteria_ChungTu criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblChungTu_QuyetDinhChungTu";
                cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteria_ChungTu)criteria).MaChungTu);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChungTu_QuyetDinh.GetChungTu_QuyetDinh(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
        
        public void DataPortal_Update(SqlTransaction tr, long MaChungTu)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (ChungTu_QuyetDinh deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChungTu_QuyetDinh child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, MaChungTu);
                    else
                        child.Update(tr, MaChungTu);
                }
            }
            
            catch(Exception ex)
            {
                tr.Rollback();
                throw ex;
            }
           

            RaiseListChangedEvents = true;
        }
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
