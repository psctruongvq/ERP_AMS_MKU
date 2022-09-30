
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietGiayXacNhan_NhanVienList : Csla.BusinessListBase<ChiTietGiayXacNhan_NhanVienList, ChiTietGiayXacNhan_NhanVien>
	{

		#region Factory Methods
        protected override object AddNewCore()
        {
            ChiTietGiayXacNhan_NhanVien item = ChiTietGiayXacNhan_NhanVien.NewChiTietGiayXacNhan_NhanVien(0);
            this.Add(item);
            return item;
        }
		public static ChiTietGiayXacNhan_NhanVienList NewChiTietGiayXacNhan_NhanVienList()
		{
			return new ChiTietGiayXacNhan_NhanVienList();
		}

		internal static ChiTietGiayXacNhan_NhanVienList GetChiTietGiayXacNhan_NhanVienList(SafeDataReader dr)
		{
			return new ChiTietGiayXacNhan_NhanVienList(dr);
		}
        public static ChiTietGiayXacNhan_NhanVienList GetChiTietGiayXacNhan_NhanVienList(int maChiTietGiayXacNhan)
        {
            return DataPortal.Fetch<ChiTietGiayXacNhan_NhanVienList>(new FilterCriteria(maChiTietGiayXacNhan));
        }
       
		private ChiTietGiayXacNhan_NhanVienList()
		{
			MarkAsChild();
		}

		private ChiTietGiayXacNhan_NhanVienList(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods
        [Serializable()]
        private class FilterCriteria
        {
            public int MaChiTietGiayXacNhan;

            public FilterCriteria(int maChiTietGiayXacNhan)
            {
                this.MaChiTietGiayXacNhan = maChiTietGiayXacNhan;
            }
        }
       
        
		#region Data Access
		private void Fetch(SafeDataReader dr)
		{
			RaiseListChangedEvents = false;

			while(dr.Read())
				this.Add(ChiTietGiayXacNhan_NhanVien.GetChiTietGiayXacNhan_NhanVien(dr));

			RaiseListChangedEvents = true;
		}
        //protected override void DataPortal_Fetch(object criteria)
        //{
        //    if (criteria is FilterCriteria)
        //    {
        //        DataPortal_Fetch(criteria);
        //    }
        //    else if(criteria is FilterCriteriabyDatabase)
        //    {
                
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
                    cm.CommandText = "spd_SelecttblnsChiTietGiayXacNhan_NhanViensAll";
                    cm.Parameters.AddWithValue("@MaChiTietGiayXacNhan",((FilterCriteria) criteria).MaChiTietGiayXacNhan);
                }
               
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(ChiTietGiayXacNhan_NhanVien.GetChiTietGiayXacNhan_NhanVien(dr));
                }
            }//using
        }
       
		internal void Update(SqlTransaction tr, ChiTietGiayXacNhan parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (ChiTietGiayXacNhan_NhanVien deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (ChiTietGiayXacNhan_NhanVien child in this)
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
