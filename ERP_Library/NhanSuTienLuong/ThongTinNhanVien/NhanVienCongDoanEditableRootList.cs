
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVienCongDoanList : Csla.BusinessListBase<NhanVienCongDoanList, NhanVienCongDoan>
	{

		#region Factory Methods
		private NhanVienCongDoanList()
		{ /* require use of factory method */ }

		public static NhanVienCongDoanList NewNhanVienCongDoanList()
		{
			return new NhanVienCongDoanList();
		}

		public static NhanVienCongDoanList GetNhanVienCongDoanList(DateTime tuNgay,DateTime denNgay,int Loai)
		{
			return DataPortal.Fetch<NhanVienCongDoanList>(new FilterCriteria(tuNgay,denNgay,Loai));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
            public DateTime TuNgay;
            public DateTime DenNgay;
            public int Loai;
			public FilterCriteria(DateTime tuNgay,DateTime denNgay,int loai)
            {
                this.TuNgay = tuNgay;
                this.DenNgay = denNgay;
                this.Loai = loai;
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
                cm.CommandText = "spd_SelectDanhSachNhanVienCongDoan";
                cm.Parameters.AddWithValue("@TuNgay", criteria.TuNgay);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);
                cm.Parameters.AddWithValue("@Loai", criteria.Loai);
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(NhanVienCongDoan.GetNhanVienCongDoan(dr));
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
        //        foreach (NhanVienCongDoan deletedChild in DeletedList)
        //            deletedChild.DeleteSelf(cn);
        //        DeletedList.Clear();

        //        // loop through each non-deleted child object
        //        foreach (NhanVienCongDoan child in this)
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
