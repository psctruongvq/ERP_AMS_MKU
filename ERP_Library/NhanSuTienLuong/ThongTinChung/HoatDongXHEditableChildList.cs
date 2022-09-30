
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoatDongXaHoiList : Csla.BusinessListBase<HoatDongXaHoiList, HoatDongXaHoi>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			HoatDongXaHoi item = HoatDongXaHoi.NewHoatDongXaHoi();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		public static HoatDongXaHoiList NewHoatDongXaHoiList()
		{
			return new HoatDongXaHoiList();
		}

		public static HoatDongXaHoiList GetHoatDongXaHoiList()
		{
			//return new HoatDongXaHoiList(dr);
            return DataPortal.Fetch<HoatDongXaHoiList>(new FilterCriteriaAll());
		}

        public static HoatDongXaHoiList GetHoatDongXaHoiList(long maNhanVien)
        {
            //return new HoatDongXaHoiList(dr);
            return DataPortal.Fetch<HoatDongXaHoiList>(new FilterCriteria(maNhanVien));
        }


		private HoatDongXaHoiList()
		{
			MarkAsChild();
		}

		private HoatDongXaHoiList(SafeDataReader dr)
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

        //protected override void DataPortal_Fetch(object criteria)
        //{
        //    if (criteria is FilterCriteria)
        //    {
        //        DataPortal_Fetch(criteria);
        //    }
        //    else
        //    {
        //        //tu bo sung khi can
        //    }
        //}

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
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_SelecttblnsHoatDongXaHoisAll";
                    cm.Parameters.AddWithValue("@MaNhanVien",((FilterCriteria) criteria).MaNhanVien);
                }
                else if (criteria is FilterCriteriaAll)
                {

                    cm.CommandText = "spd_SelecttblnsHoatDongXaHoiByAll";
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(HoatDongXaHoi.GetHoatDongXaHoi(dr));
                }
            }//using
        }
       

		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (HoatDongXaHoi deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (HoatDongXaHoi child in this)
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
