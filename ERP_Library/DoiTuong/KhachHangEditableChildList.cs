
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhachHangList : Csla.BusinessListBase<KhachHangList, KhachHang>
	{

		#region Factory Methods
		public static KhachHangList NewKhachHangList()
		{
			return new KhachHangList();
		}

        public static KhachHangList GetKhachHangList(long maDoiTac)
		{
			//return new KhachHangList(dr);
            return DataPortal.Fetch<KhachHangList>(new FilterCriteria(maDoiTac));
		}

		public KhachHangList()
		{
			MarkAsChild();
		}

		public KhachHangList(SafeDataReader dr)
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
            public long MaDoiTac;

            public FilterCriteria(long MaDoiTac)
            {
                this.MaDoiTac = MaDoiTac;
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
                cm.CommandText = "spd_SelecttblKhachHangsAll";
                cm.Parameters.AddWithValue("@MaDoiTac", criteria.MaDoiTac);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(KhachHang.GetKhachHang(dr));
                }
            }//using
        }    

		internal void Update(SqlTransaction tr, DoiTac parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (KhachHang deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (KhachHang child in this)
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
