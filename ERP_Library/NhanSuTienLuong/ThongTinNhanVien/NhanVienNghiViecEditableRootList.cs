
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVienNghiViecList : Csla.BusinessListBase<NhanVienNghiViecList, NhanVienNghiViec>
	{

		#region Factory Methods
		private NhanVienNghiViecList()
		{ /* require use of factory method */ }

		public static NhanVienNghiViecList NewNhanVienNghiViecList()
		{
			return new NhanVienNghiViecList();
		}

		public static NhanVienNghiViecList GetNhanVienNghiViecList(DateTime tuNgay,DateTime denNgay)
		{
			return DataPortal.Fetch<NhanVienNghiViecList>(new FilterCriteria(tuNgay,denNgay));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public DateTime TuNgay;
            public DateTime DenNgay;
			public FilterCriteria(DateTime tuNgay,DateTime denNgay)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;

			}
		}
		#endregion //Filter Criteria

		#region Data Access - Fetch
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
                cm.CommandText = "spd_SelectDanhSachNhanVienNghiViec";
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NhanVienNghiViec.GetNhanVienNghiViec(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
        //protected override void DataPortal_Update()
        //{
        //    RaiseListChangedEvents = false;

        //    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
        //    {
        //        cn.Open();

        //        // loop through each deleted child object
        //        foreach (NhanVienNghiViec deletedChild in DeletedList)
        //            deletedChild.DeleteSelf(cn);
        //        DeletedList.Clear();

        //        // loop through each non-deleted child object
        //        foreach (NhanVienNghiViec child in this)
        //        {
        //            if (child.IsNew)
        //                child.Insert(cn);
        //            else
        //                child.Update(cn);
        //        }
        //    }//using SqlConnection

        //    RaiseListChangedEvents = true;
        //}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
