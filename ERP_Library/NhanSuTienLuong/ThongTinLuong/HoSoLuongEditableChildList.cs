
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoSoLuongList : Csla.BusinessListBase<HoSoLuongList, HoSoLuong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			HoSoLuong item = HoSoLuong.NewHoSoLuong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		internal static HoSoLuongList NewHoSoLuongList()
		{
			return new HoSoLuongList();
		}

		internal static HoSoLuongList GetHoSoLuongList(SafeDataReader dr)
		{
			return new HoSoLuongList(dr);
		}
        public static HoSoLuongList GetHoSoLuongList(long maNhanVien)
        {
            return DataPortal.Fetch<HoSoLuongList>(new FilterCriteria(maNhanVien));
        }

        public static HoSoLuongList GetHoSoLuongListByBoPhan(int mabophan)
        {
            return DataPortal.Fetch<HoSoLuongList>(new FilterCriteriaByBoPhan(mabophan));
        }

        public static HoSoLuongList GetHoSoLuongListByNhanVien(int mabophan, string DKTim)
        {
            return DataPortal.Fetch<HoSoLuongList>(new FilterCriteriaByNhanVien(mabophan,DKTim));
        }
        public static HoSoLuongList GetHoSoLuongListByBoPhanAll(int mabophan)
        {
            return DataPortal.Fetch<HoSoLuongList>(new FilterCriteriaByBoPhanAll(mabophan));
        }

        public static HoSoLuongList GetHoSoLuongListByNhanVienAll(int mabophan, string DKTim)
        {
            return DataPortal.Fetch<HoSoLuongList>(new FilterCriteriaByNhanVienAll(mabophan, DKTim));
        }
		private HoSoLuongList()
		{
			MarkAsChild();
		}

		private HoSoLuongList(SafeDataReader dr)
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

        private class FilterCriteriaByBoPhan
        {
            public int mabophan;

            public FilterCriteriaByBoPhan(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }

        private class FilterCriteriaByNhanVien
        {
            public int mabophan;
            public string DKTim;

            public FilterCriteriaByNhanVien(int mabophan,string DKTim)
            {
                this.DKTim = DKTim;
                this.mabophan = mabophan;
            }
        }

        private class FilterCriteriaByBoPhanAll
        {
            public int mabophan;

            public FilterCriteriaByBoPhanAll(int mabophan)
            {
                this.mabophan = mabophan;
            }
        }

        private class FilterCriteriaByNhanVienAll
        {
            public int mabophan;
            public string DKTim;

            public FilterCriteriaByNhanVienAll(int mabophan, string DKTim)
            {
                this.DKTim = DKTim;
                this.mabophan = mabophan;
            }
        }
        #endregion //Filter Criteria

        #region Fetch
        //protected override void DataPortal_Fetch(object criteria)
        //{
        //    DataPortal_Fetch(criteria);
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
                    cm.CommandText = "spd_SelecttblnsHoSoLuongsAll";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                }
                else if (criteria is FilterCriteriaByBoPhanAll)
                {
                    cm.CommandText = "spd_SelecttblnsHoSoLuongByBophanAll";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByBoPhanAll)criteria).mabophan);
                }
                else if (criteria is FilterCriteriaByNhanVienAll)
                {
                    cm.CommandText = "spd_SelecttblnsHoSoLuongByNhanVienAll";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByNhanVienAll)criteria).mabophan);
                    cm.Parameters.AddWithValue("@DKTim", ((FilterCriteriaByNhanVienAll)criteria).DKTim);
                }

                else if (criteria is FilterCriteriaByBoPhan)
                {
                    cm.CommandText = "spd_SelecttblnsHoSoLuongByBophan";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByBoPhan)criteria).mabophan);
                }
                else if (criteria is FilterCriteriaByNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsHoSoLuongByNhanVien";
                    cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByNhanVien)criteria).mabophan);
                    cm.Parameters.AddWithValue("@DKTim", ((FilterCriteriaByNhanVien)criteria).DKTim);
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(HoSoLuong.GetHoSoLuong(dr));
                }
            }//using
        }
        #endregion

        internal void Update(SqlTransaction cn, NhanVien parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (HoSoLuong deletedChild in DeletedList)
				deletedChild.DeleteSelf(cn);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (HoSoLuong child in this)
			{
				if(child.IsNew)
					child.Insert(cn, parent);
				else
					child.Update(cn, parent);
			}

			RaiseListChangedEvents = true;
		}

        public void Update1(NhanVien parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (HoSoLuong deletedChild in DeletedList)
                deletedChild.DeleteSelf();
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (HoSoLuong child in this)
            {
                if (child.IsNew)
                    child.Insert(parent);
                else
                    child.Update(parent);
            }

            RaiseListChangedEvents = true;
        }
		#endregion //Data Access
	}
}
