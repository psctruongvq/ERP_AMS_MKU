
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinKhacList : Csla.BusinessListBase<ThongTinKhacList, ThongTinKhac>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ThongTinKhac item = ThongTinKhac.NewThongTinKhac();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static ThongTinKhacList NewThongTinKhacList()
		{
			return new ThongTinKhacList();
		}

		internal static ThongTinKhacList GetThongTinKhacList(SafeDataReader dr)
		{
			return new ThongTinKhacList(dr);
		}

        public static ThongTinKhacList GetThongTinKhacList(long maNhanVien)
        {
            //return new HoatDongXaHoiList(dr);
            return DataPortal.Fetch<ThongTinKhacList>(new FilterCriteria(maNhanVien));
        }

		private ThongTinKhacList()
		{
			MarkAsChild();
		}

		private ThongTinKhacList(SafeDataReader dr)
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
        #endregion //Filter Criteria

        #region Fetch
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
                cm.CommandText = "spd_SelecttblnsThongTinKhacsAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ThongTinKhac.GetThongTinKhac(dr));
                }
            }//using
        }
        #endregion

        internal void Update(SqlTransaction tr, NhanVien parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ThongTinKhac deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ThongTinKhac child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
		#endregion //Data Access

	}
}
