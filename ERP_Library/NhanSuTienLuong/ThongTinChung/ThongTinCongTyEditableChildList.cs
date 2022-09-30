
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinCongTyList : Csla.BusinessListBase<ThongTinCongTyList, ThongTinCongTy>
	{

		#region Factory Methods
		public static ThongTinCongTyList NewThongTinCongTyList()
		{
			return new ThongTinCongTyList();
		}

        public static ThongTinCongTyList GetNhanVien(int cty,int pb,int to)
        {
            //return new ThongTinCongTyList(dr);
            return DataPortal.Fetch<ThongTinCongTyList>(new FilterCriteria_NhanVien(cty,pb,to));
        }

		public static ThongTinCongTyList GetThongTinCongTyList(long maNhanVien)
		{
			//return new ThongTinCongTyList(dr);
            return DataPortal.Fetch<ThongTinCongTyList>(new FilterCriteria(maNhanVien));
		}

		private ThongTinCongTyList()
		{
			MarkAsChild();
		}

		private ThongTinCongTyList(SafeDataReader dr)
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
            public long maNhanVien;

            public FilterCriteria(long maNhanVien)
            {
                this.maNhanVien = maNhanVien;
            }
        }
        private class FilterCriteria_NhanVien
        {
            public int cTy,phongBan,toNhom;

            public FilterCriteria_NhanVien(int cty,int pb,int to)
            {
                this.cTy = cty;
                this.phongBan = pb;
                this.toNhom = to;
            }
        }
        #endregion //Filter Criteria


        /*protected override void DataPortal_Fetch(object criteria)
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
        */

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
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsThongTinCongTiesAll";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).maNhanVien);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ThongTinCongTy.GetThongTinCongTy(dr));
                    }
                }
                else if (criteria is FilterCriteria_NhanVien)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_NhanVien_Select";
                    cm.Parameters.AddWithValue("@MaCongTy", ((FilterCriteria_NhanVien)criteria).cTy);
                    cm.Parameters.AddWithValue("@MaPhongBan", ((FilterCriteria_NhanVien)criteria).phongBan);
                    cm.Parameters.AddWithValue("@MaTo", ((FilterCriteria_NhanVien)criteria).toNhom);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(ThongTinCongTy.GetNhanVien(dr));
                        }
                    }    
                }
                

            }//using
        }

		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;

			// loop through each deleted child object
			foreach (ThongTinCongTy deletedChild in DeletedList)
				deletedChild.DeleteSelf(tr);
			DeletedList.Clear();

			// loop through each non-deleted child object
			foreach (ThongTinCongTy child in this)
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
