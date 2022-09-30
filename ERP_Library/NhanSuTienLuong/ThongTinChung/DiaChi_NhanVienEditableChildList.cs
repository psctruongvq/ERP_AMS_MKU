
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DiaChi_NhanVienList : Csla.BusinessListBase<DiaChi_NhanVienList, DiaChi_NhanVien>
	{
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DiaChi_NhanVien item = DiaChi_NhanVien.NewDiaChi_NhanVien();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

		#region Factory Methods
		public static DiaChi_NhanVienList NewDiaChi_NhanVienList()
		{
			return new DiaChi_NhanVienList();
		}

		public static DiaChi_NhanVienList GetDiaChi_NhanVienList()
		{
			//return new DiaChi_NhanVienList(dr);
            return DataPortal.Fetch<DiaChi_NhanVienList>(new FilterCriteriaAll());
		}

        public static DiaChi_NhanVienList GetDiaChi_NhanVienList(long maNhanVien)
        {
            //return new DiaChi_NhanVienList(dr);
            return DataPortal.Fetch<DiaChi_NhanVienList>(new FilterCriteriaByMaNhanVien(maNhanVien));
        }


		public DiaChi_NhanVienList()
		{
			MarkAsChild();
		}

		public DiaChi_NhanVienList(SafeDataReader dr)
		{
			MarkAsChild();
			//Fetch(dr);
		}
		#endregion //Factory Methods

		#region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteriaByMaNhanVien
        {
            public long MaNhanVien;

            public FilterCriteriaByMaNhanVien(long MaNhanVien)
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

        protected override void DataPortal_Fetch(object criteria)
        {
            if (criteria is FilterCriteriaByMaNhanVien)
            {
                DataPortal_Fetch(criteria);
            }
            else
            {
                //tu bo sung khi can
            }
        }

        private void DataPortal_Fetch(FilterCriteriaByMaNhanVien criteria)
        {
            RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    ExecuteFetch(cn, criteria);
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlConnection cn, FilterCriteriaByMaNhanVien criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblDiaChi_NhanViensAll";
                cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DiaChi_NhanVien.GetDiaChi_NhanVien(dr));
                }
            }//using
        }
		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (DiaChi_NhanVien deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (DiaChi_NhanVien child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }
            }
            catch (SqlException ex)
            {
                tr.Rollback();
                HamDungChung.ThongBaoLoi(ex);
            }
			RaiseListChangedEvents = true;
		}
		#endregion //Data Access

	}
}
