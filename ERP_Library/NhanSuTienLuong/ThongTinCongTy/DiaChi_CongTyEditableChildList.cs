
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DiaChi_CongTyList : Csla.BusinessListBase<DiaChi_CongTyList, DiaChi_CongTy>
	{
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DiaChi_CongTy item = DiaChi_CongTy.NewDiaChi_CongTy();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

		#region Factory Methods
		public static DiaChi_CongTyList NewDiaChi_CongTyList()
		{
			return new DiaChi_CongTyList();
		}

		public static DiaChi_CongTyList GetDiaChi_CongTyList()
		{
			//return new DiaChi_CongTyList(dr);
            return DataPortal.Fetch<DiaChi_CongTyList>(new FilterCriteriaAll());
		}

        public static DiaChi_CongTyList GetDiaChi_CongTyList(int maCongTy)
        {
            //return new DiaChi_CongTyList(dr);
            return DataPortal.Fetch<DiaChi_CongTyList>(new FilterCriteria(maCongTy));
        }


		private DiaChi_CongTyList()
		{
			MarkAsChild();
		}

		private DiaChi_CongTyList(SafeDataReader dr)
		{
			MarkAsChild();
			//Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int maCongTy;

            public FilterCriteria(int maCongTy)
            {
                this.maCongTy = maCongTy;
            }
        }

        [Serializable()]
        private class FilterCriteriaAll
        {
            public FilterCriteriaAll()
            {
            }
        }
        #endregion //Filter Criteria

        protected override void DataPortal_Fetch(object criteria)
        {
            if (criteria is FilterCriteria)
            {
                DataPortal_Fetch(criteria);
            }
            else
            {
                //tu bo sung khi can
            }
        }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblDiaChi_CongTiesAll";
                cm.Parameters.AddWithValue("@MaCongTy", criteria.maCongTy);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DiaChi_CongTy.GetDiaChi_CongTy(dr));
                }
            }//using
        }

		internal void Update(SqlTransaction tr, CongTy parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (DiaChi_CongTy deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (DiaChi_CongTy child in this)
			{
				if(child.IsNew)
					child.Insert(tr, parent);
				else
					child.Update(tr, parent);
			}

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

	}
}
