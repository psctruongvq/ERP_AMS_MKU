
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_EmailList : Csla.BusinessListBase<NhanVien_EmailList, NhanVien_Email>
	{
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhanVien_Email item = NhanVien_Email.NewNhanVien_Email();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

		#region Factory Methods
		public static NhanVien_EmailList NewNhanVien_EmailList()
		{
			return new NhanVien_EmailList();
		}

		public static NhanVien_EmailList GetNhanVien_EmailList()
		{			
            return DataPortal.Fetch<NhanVien_EmailList>(new FilterCriteriaAll());
		}

        public static NhanVien_EmailList GetNhanVien_EmailList(long maNhanVien)
        {
            return DataPortal.Fetch<NhanVien_EmailList>(new FilterCriteria(maNhanVien));
        }


		private NhanVien_EmailList()
		{
			MarkAsChild();
		}

		private NhanVien_EmailList(SafeDataReader dr)
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
            public long MaNhanVien;

            public FilterCriteria(long MaNhanVien)
            {
                this.MaNhanVien = MaNhanVien;
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
                try
                {
                    ExecuteFetch(cn, criteria);
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsNhanVien_Email_WebSitesAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVien_Email.GetNhanVien_Email(dr));
                }
            }//using
        }

		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (NhanVien_Email deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (NhanVien_Email child in this)
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
