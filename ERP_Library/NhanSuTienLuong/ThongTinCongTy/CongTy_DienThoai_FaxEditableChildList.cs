
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongTy_DienThoai_FaxList : Csla.BusinessListBase<CongTy_DienThoai_FaxList, CongTy_DienThoai_Fax>
	{
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CongTy_DienThoai_Fax item = CongTy_DienThoai_Fax.NewCongTy_DienThoai_Fax();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

		#region Factory Methods
		public static CongTy_DienThoai_FaxList NewCongTy_DienThoai_FaxList()
		{
			return new CongTy_DienThoai_FaxList();
		}

		public static CongTy_DienThoai_FaxList GetCongTy_DienThoai_FaxList()
		{
			//return new CongTy_DienThoai_FaxList(dr);
            return DataPortal.Fetch<CongTy_DienThoai_FaxList>(new FilterCriteriaAll());
		}

        public static CongTy_DienThoai_FaxList GetCongTy_DienThoai_FaxList(int maCongTy)
        {
            //return new CongTy_DienThoai_FaxList(dr);
            return DataPortal.Fetch<CongTy_DienThoai_FaxList>(new FilterCriteria(maCongTy));
        }


		public CongTy_DienThoai_FaxList()
		{
			MarkAsChild();
		}

		public CongTy_DienThoai_FaxList(SafeDataReader dr)
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
                this.maCongTy = maCongTy ;
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
                cm.CommandText = "spd_SelecttblDienThoai_Fax_CongTiesAll";
                cm.Parameters.AddWithValue("@MaCongTy", criteria.maCongTy);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(CongTy_DienThoai_Fax.GetCongTy_DienThoai_Fax(dr));
                }
            }//using
        }


		internal void Update(SqlTransaction tr, CongTy parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (CongTy_DienThoai_Fax deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (CongTy_DienThoai_Fax child in this)
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
