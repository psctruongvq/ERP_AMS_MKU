
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{ 
	[Serializable()] 
	public class BaoCao_CTKPHD_DNQTList : Csla.BusinessListBase<BaoCao_CTKPHD_DNQTList, BaoCao_CTKPHD_DNQT>
	{

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BaoCao_CTKPHD_DNQTList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCao_CTKPHD_DNQTListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BaoCao_CTKPHD_DNQTList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCao_CTKPHD_DNQTListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BaoCao_CTKPHD_DNQTList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCao_CTKPHD_DNQTListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BaoCao_CTKPHD_DNQTList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BaoCao_CTKPHD_DNQTListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BaoCao_CTKPHD_DNQTList()
		{ /* require use of factory method */ }

		public static BaoCao_CTKPHD_DNQTList NewBaoCao_CTKPHD_DNQTList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BaoCao_CTKPHD_DNQTList");
			return new BaoCao_CTKPHD_DNQTList();
		}

        public static BaoCao_CTKPHD_DNQTList GetBaoCao_CTKPHD_DNQTList(string mabophan, int manguon, DateTime tuNgay, DateTime denNgay)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BaoCao_CTKPHD_DNQTList");
            return DataPortal.Fetch<BaoCao_CTKPHD_DNQTList>(new FilterCriteria(mabophan,manguon, tuNgay, denNgay));
		}

        public static BaoCao_CTKPHD_DNQTList GetBaoCao_THKPHD_DNQTList(string mabophan, int manguon, DateTime tuNgay, DateTime denNgay )
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BaoCao_THKPHD_DNQTList");
            return DataPortal.Fetch<BaoCao_CTKPHD_DNQTList>(new FilterCriteria_TH(mabophan, manguon, tuNgay, denNgay));
        }

        public static BaoCao_CTKPHD_DNQTList GetBaoCao_THKPHD_DNQTListIn(string mabophan, int manguon, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BaoCao_THKPHD_DNQTList");
            return DataPortal.Fetch<BaoCao_CTKPHD_DNQTList>(new FilterCriteria_THIn(mabophan, manguon, tuNgay, denNgay));
        }
        public static BaoCao_CTKPHD_DNQTList GetBaoCao_THKPHD_DNQTListInSoSanh(string mabophan, int manguon, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BaoCao_THKPHD_DNQTList");
            return DataPortal.Fetch<BaoCao_CTKPHD_DNQTList>(new FilterCriteria_THInSoSanh(mabophan, manguon, tuNgay, denNgay));
        }

		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public string maBoPhan;
            public int manguon;  
            public DateTime tungay;
            public DateTime dengay;
            public FilterCriteria(string maBoPhan, int manguon, DateTime TuNgay, DateTime DenNgay)
            {
                this.maBoPhan = maBoPhan;
                this.manguon = manguon;
                this.tungay = TuNgay;
                this.dengay = DenNgay;

            }
        }
        private class FilterCriteria_TH
        {
           
            public string maBoPhan;
            public int manguon;  
            public DateTime tungay;
            public DateTime dengay;
            public FilterCriteria_TH(string maBoPhan, int manguon, DateTime TuNgay, DateTime DenNgay)
            {
                this.maBoPhan = maBoPhan;
                this.manguon = manguon;
                this.tungay = TuNgay;
                this.dengay = DenNgay;

            }
        }

        private class FilterCriteria_THInSoSanh
        {

            public string maBoPhan;
            public int manguon;
            public DateTime tungay;
            public DateTime dengay;
            public FilterCriteria_THInSoSanh(string maBoPhan, int manguon, DateTime TuNgay, DateTime DenNgay)
            {
                this.maBoPhan = maBoPhan;
                this.manguon = manguon;
                this.tungay = TuNgay;
                this.dengay = DenNgay;

            }
        }

         private class FilterCriteria_THIn
        {

            public string maBoPhan;
            public int manguon;
            public DateTime tungay;
            public DateTime dengay;
            public FilterCriteria_THIn(string maBoPhan, int manguon, DateTime TuNgay, DateTime DenNgay)
            {
                this.maBoPhan = maBoPhan;
                this.manguon = manguon;
                this.tungay = TuNgay;
                this.dengay = DenNgay;

            }
        }

		#endregion //Filter Criteria

		#region Data Access - Fetch
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
                cm.CommandTimeout = 0;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "[spd_BaoCaoChiTietKinhPhiHD_DeNghiQTDung]";                    
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@Manguon", ((FilterCriteria)criteria).manguon);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria).tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria).dengay);
                }
                else if (criteria is FilterCriteria_TH)
                {
                    cm.CommandText = "[spd_BaoCaoTongHopKinhPhiHD_DeNghiQT_Dung]";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_TH)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@Manguon", ((FilterCriteria_TH)criteria).manguon);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_TH)criteria).tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_TH)criteria).dengay);

                }
                else if (criteria is FilterCriteria_THIn)
                {
                    cm.CommandText = "[spd_BaoCaoTongHopKinhPhiHD_DeNghiQT_DungIn]";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_THIn)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@Manguon", ((FilterCriteria_THIn)criteria).manguon);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_THIn)criteria).tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_THIn)criteria).dengay);
                }

                else if (criteria is FilterCriteria_THInSoSanh)
                {
                    cm.CommandText = "[spd_BaoCaoTongHopKinhPhiHD_DeNghiQT_DungInSoSanh]";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria_THInSoSanh)criteria).maBoPhan);
                    cm.Parameters.AddWithValue("@Manguon", ((FilterCriteria_THInSoSanh)criteria).manguon);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_THInSoSanh)criteria).tungay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_THInSoSanh)criteria).dengay);

                    using (SafeDataReader drnew = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (drnew.Read())
                            this.Add(BaoCao_CTKPHD_DNQT.GetBaoCao_CTKPHD_DNQTSoSanh(drnew));
                    }
                    return;

                }

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(BaoCao_CTKPHD_DNQT.GetBaoCao_CTKPHD_DNQT(dr));
				}

			}//using
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
