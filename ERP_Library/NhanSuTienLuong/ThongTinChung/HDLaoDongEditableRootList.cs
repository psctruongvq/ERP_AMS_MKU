
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HDLaoDongList : Csla.BusinessListBase<HDLaoDongList, HDLaoDong>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			HDLaoDong item = HDLaoDong.NewHDLaoDong();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HDLaoDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HDLaoDongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HDLaoDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HDLaoDongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HDLaoDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HDLaoDongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HDLaoDongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HDLaoDongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HDLaoDongList()
		{ /* require use of factory method */ }

		public static HDLaoDongList NewHDLaoDongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HDLaoDongList");
			return new HDLaoDongList();
		}

		public static HDLaoDongList GetHDLaoDongList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HDLaoDongList");
			return DataPortal.Fetch<HDLaoDongList>(new FilterCriteria());
		}

        public static HDLaoDongList GetHDLaoDongList(long MaNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HDLaoDongList");
            return DataPortal.Fetch<HDLaoDongList>(new FilterCriteriaTheoNhanVien(MaNhanVien));
        }

        public static HDLaoDongList GetHDLaoDongListByBoPhan(int Mabophan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HDLaoDongList");
            return DataPortal.Fetch<HDLaoDongList>(new FilterCriteriaTheoBoPhan(Mabophan));
        }

        public static HDLaoDongList GetHDLaoDongListByBoPhanVaLoaiHD(int Mabophan, int LoaiHD)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HDLaoDongList");
            return DataPortal.Fetch<HDLaoDongList>(new FilterCriteriaTheoBoPhanVaLoaiHD(Mabophan,LoaiHD));
        }

        public static HDLaoDongList GetHDLaoDongListByLoaiHD( int LoaiHD)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HDLaoDongList");
            return DataPortal.Fetch<HDLaoDongList>(new FilterCriteriaTheoLoaiHD( LoaiHD));
        }

        public static HDLaoDongList GetHDLaoDong_denhanchuyendoiHD(int mabophan, DateTime denngay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<HDLaoDongList>(new FilterCriteriaByDSdenhanchuyendoiHD(mabophan, denngay));
        }

        public static HDLaoDongList GetHDLaoDong_denhanchuyendoiHDByLoaiHD(int mabophan, DateTime denngay, int LoaiHD)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TenNhanVienList");
            return DataPortal.Fetch<HDLaoDongList>(new FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD(mabophan, denngay, LoaiHD));
        }
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
		private class FilterCriteria
		{
		    public FilterCriteria()
			{				
			}
		}

        private class FilterCriteriaTheoNhanVien
        {
            public long maNhanVien;
            public FilterCriteriaTheoNhanVien(long MaNhanVien)
            {
                maNhanVien = MaNhanVien;
            }
        }
        private class FilterCriteriaTheoBoPhan
        {
            public int Mabophan;
            public FilterCriteriaTheoBoPhan(int MaboPhan)
            {
                this.Mabophan = Mabophan;
            }
        }
        private class FilterCriteriaTheoBoPhanVaLoaiHD
        {
            public int Mabophan;
            public int LoaiHD;
            public FilterCriteriaTheoBoPhanVaLoaiHD(int MaboPhan, int LoaiHD)
            {
                this.Mabophan = Mabophan;
                this.LoaiHD = LoaiHD;
            }
        }
        private class FilterCriteriaTheoLoaiHD
        {
            public int LoaiHD;
            public FilterCriteriaTheoLoaiHD(int LoaiHD)
            {
                this.LoaiHD = LoaiHD;
            }
        }
        private class FilterCriteriaByDSdenhanchuyendoiHD
        {
            public int mabophan;
            public DateTime denngay;
            public FilterCriteriaByDSdenhanchuyendoiHD(int mabophan, DateTime denngay)
            {
                this.mabophan = mabophan;
                this.denngay = denngay;
            }
        }
        private class FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD
        {
            public int mabophan;
            public DateTime denngay;
            public int LoaiHD;
            public FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD(int mabophan, DateTime denngay, int LoaiHD)
            {
                this.mabophan = mabophan;
                this.denngay = denngay;
                this.LoaiHD = LoaiHD;
            }
        }
		#endregion //Filter Criteria

		#region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
		{
			RaiseListChangedEvents = false;

            SqlTransaction tr;
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();
                tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(tr, criteria);
                    tr.Commit();
				}
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using

			RaiseListChangedEvents = true;
		}

        private void ExecuteFetch(SqlTransaction tr, object criteria)
		{         
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    if (criteria is FilterCriteria)
                    {
                        cm.CommandText = "spd_SelecttblnsHopDongLaoDongsAll";
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(HDLaoDong.GetHDLaoDong(dr));
                        }
                    }
                    else if (criteria is FilterCriteriaTheoNhanVien)
                    {           
                        cm.CommandText = "spd_SelecttblnsHopDongLaoDongsAllTheoNV";
                        cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaTheoNhanVien)criteria).maNhanVien);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(HDLaoDong.GetHDLaoDong(dr));
                        }
                    }
                    else if (criteria is FilterCriteriaTheoBoPhan)
                    {       
                        cm.CommandText = "spd_SelecttblnsHopDongLaoDongsAllTheoBP";
                        cm.Parameters.AddWithValue("@Mabophan", ((FilterCriteriaTheoBoPhan)criteria).Mabophan);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(HDLaoDong.GetHDLaoDong(dr));
                        }
                    }
                    else if (criteria is FilterCriteriaTheoBoPhanVaLoaiHD)
                    {
                        cm.CommandText = "spd_SelecttblnsHopDongLaoDongsAllTheoBPVaLoaiHD";
                        cm.Parameters.AddWithValue("@Mabophan", ((FilterCriteriaTheoBoPhanVaLoaiHD)criteria).Mabophan);
                        cm.Parameters.AddWithValue("@LoaiHD", ((FilterCriteriaTheoBoPhanVaLoaiHD)criteria).LoaiHD);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(HDLaoDong.GetHDLaoDong(dr));
                        }
                    }
                    else if (criteria is FilterCriteriaTheoLoaiHD)
                    {
                        cm.CommandText = "spd_SelecttblnsHopDongLaoDongsAllTheoLoaiHD";
                        cm.Parameters.AddWithValue("@LoaiHD", ((FilterCriteriaTheoLoaiHD)criteria).LoaiHD);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(HDLaoDong.GetHDLaoDong(dr));
                        }
                    }
                    else if (criteria is FilterCriteriaByDSdenhanchuyendoiHD)
                    {
                        cm.CommandText = "spd_selecttblnsDSchuyendoiHD";
                        cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByDSdenhanchuyendoiHD)criteria).mabophan);
                        cm.Parameters.AddWithValue("@denngay", ((FilterCriteriaByDSdenhanchuyendoiHD)criteria).denngay);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(HDLaoDong.GetHDLaoDong(dr));
                        }
                    }
                    else if (criteria is FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD)
                    {
                        cm.CommandText = "spd_selecttblnsDSchuyendoiHDByLoaiHD";
                        cm.Parameters.AddWithValue("@mabophan", ((FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD)criteria).mabophan);
                        cm.Parameters.AddWithValue("@denngay", ((FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD)criteria).denngay);
                        cm.Parameters.AddWithValue("@LoaiHD", ((FilterCriteriaByDSdenhanchuyendoiHDByLoaiHD)criteria).LoaiHD);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(HDLaoDong.GetHDLaoDong(dr));
                        }
                    }

                }           
		}

		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					// loop through each deleted child object
					foreach (HDLaoDong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (HDLaoDong child in this)
					{
						if (child.IsNew)
							child.Insert(tr);
						else
							child.Update(tr);
					}

					tr.Commit();
				}
                catch (SqlException ex)
                {
                    tr.Rollback();
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
