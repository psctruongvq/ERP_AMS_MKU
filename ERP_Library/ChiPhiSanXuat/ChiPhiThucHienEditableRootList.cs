
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiPhiThucHienList : Csla.BusinessListBase<ChiPhiThucHienList, ChiPhiThucHien>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			ChiPhiThucHien item = ChiPhiThucHien.NewChiPhiThucHien();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Factory Methods
		private ChiPhiThucHienList()
		{ /* require use of factory method */ }

		public static ChiPhiThucHienList NewChiPhiThucHienList()
		{
			return new ChiPhiThucHienList();
		}

		public static ChiPhiThucHienList GetChiPhiThucHienList(long machungtuChiphisanxuat)
		{
			return DataPortal.Fetch<ChiPhiThucHienList>(new FilterCriteria(machungtuChiphisanxuat));
		}
        public static ChiPhiThucHienList GetChiPhiThucHienListByChungTu(long maChungTu)
        {
            return DataPortal.Fetch<ChiPhiThucHienList>(new FilterCriteriaByChungTu(maChungTu));
        }

        public static ChiPhiThucHienList GetChiPhiThucHienListByKetChuyen(int maChuongTrinh)
        {
            return DataPortal.Fetch<ChiPhiThucHienList>(new FilterCriteriaByKetChuyen(maChuongTrinh));
        }

        public static ChiPhiThucHienList GetChiPhiThucHienListByKetChuyen_New(long maCTChiPhiSanXuat)
        {
            return DataPortal.Fetch<ChiPhiThucHienList>(new FilterCriteriaByKetChuyen_New(maCTChiPhiSanXuat));
        }

        public static ChiPhiThucHienList GetChiPhiThucHienListBySoChungTu(string soChungTu)
        {
            return DataPortal.Fetch<ChiPhiThucHienList>(new FilterCriteriaBySoChungTu(soChungTu));
        }

		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public long MachungtuChiphisanxuat;

            public FilterCriteria(long machungtuChiphisanxuat)
            {
                this.MachungtuChiphisanxuat = machungtuChiphisanxuat;
            }
        }
        private class FilterCriteriaByKetChuyen
        {
            public int MaChuongTrinh;
            public FilterCriteriaByKetChuyen(int maChuongTrinh)
            {
                MaChuongTrinh = maChuongTrinh;
            }
        }

        private class FilterCriteriaByKetChuyen_New
        {
            public long MaCTChiPhiSanXuat;
            public FilterCriteriaByKetChuyen_New(long maCTChiPhiSanXuat)
            {
                MaCTChiPhiSanXuat = maCTChiPhiSanXuat;
            }
        }

        private class FilterCriteriaByChungTu
		{
			public long MaChungTu;

            public FilterCriteriaByChungTu(long maChungTu)
			{
                this.MaChungTu = maChungTu;
			}
		}

        private class FilterCriteriaBySoChungTu
        {
            public string SoChungTu;

            public FilterCriteriaBySoChungTu(string soChungTu)
            {
                this.SoChungTu = soChungTu;
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
				catch
				{
					tr.Rollback();
					throw;
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
                    cm.CommandText = "SelecttblChiPhiThucHienByMaCT_ChiPhiSX";
                    cm.Parameters.AddWithValue("@MaCT_ChiPhiSanXuat", ((FilterCriteria)criteria).MachungtuChiphisanxuat);
                }
                else if (criteria is FilterCriteriaByChungTu)
                {
                    cm.CommandText = "SelecttblChiPhiThucHienByMaCT_ChiPhiSXByChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((FilterCriteriaByChungTu)criteria).MaChungTu);
                }
                else if (criteria is FilterCriteriaByKetChuyen)
                {
                    cm.CommandText = "Spd_SelecttblChiPhiThucHienByKetChuyen";
                    cm.Parameters.AddWithValue("@MaChuongTrinh", ((FilterCriteriaByKetChuyen)criteria).MaChuongTrinh);
              
                }
                else if (criteria is FilterCriteriaByKetChuyen_New)
                {
                    cm.CommandText = "Spd_SelecttblChiPhiThucHienByKetChuyen_New";
                    cm.Parameters.AddWithValue("@MaCTChiPhiSanXuat", ((FilterCriteriaByKetChuyen_New)criteria).MaCTChiPhiSanXuat);

                }  
                else if (criteria is FilterCriteriaBySoChungTu)
                {
                    cm.CommandText = "SelecttblChiPhiThucHien_BySoChungTu";
                    cm.Parameters.AddWithValue("@SoChungTu", ((FilterCriteriaBySoChungTu)criteria).SoChungTu);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(ChiPhiThucHien.GetChiPhiThucHien(dr));
				}
			}//using
		}
		#endregion //Data Access - Fetch


        #region Data Access - Update
        public void DataPortal_Update(SqlTransaction tr, long MaChungTu,string soChungTu,long maCT_ChiPhiSanXuat,int maChuongTrinh,string tenChuongTrinh)
        {
            RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (ChiPhiThucHien deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (ChiPhiThucHien child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, MaChungTu,soChungTu,maCT_ChiPhiSanXuat,maChuongTrinh,tenChuongTrinh);
                    else
                        child.Update(tr, MaChungTu,soChungTu,maCT_ChiPhiSanXuat,maChuongTrinh,tenChuongTrinh);
                }
            }

            catch (Exception ex)
            {
                tr.Rollback();
                throw ex;
            }


            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
		#endregion //Data Access
	}
}
