
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVien_ChuyenNganhList : Csla.BusinessListBase<NhanVien_ChuyenNganhList, NhanVien_ChuyenNganh>
	{
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            NhanVien_ChuyenNganh item = NhanVien_ChuyenNganh.NewNhanVien_ChuyenNganh();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

		#region Factory Methods
		public static NhanVien_ChuyenNganhList NewNhanVien_ChuyenNganhList()
		{
			return new NhanVien_ChuyenNganhList();
		}

		public static NhanVien_ChuyenNganhList GetNhanVien_ChuyenNganhList()
		{
			//return new NhanVien_ChuyenMonList(dr);
            return DataPortal.Fetch<NhanVien_ChuyenNganhList>(new FilterCriteriaAll());
		}

        public static NhanVien_ChuyenNganhList GetNhanVien_ChuyenNganhList(long maNhanVien)
        {
            //return new NhanVien_ChuyenMonList(dr);
            return DataPortal.Fetch<NhanVien_ChuyenNganhList>(new FilterCriteriaByMaNhanVien(maNhanVien));
        }


		public NhanVien_ChuyenNganhList()
		{
			MarkAsChild();
		}

		public NhanVien_ChuyenNganhList(SafeDataReader dr)
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

        //protected override void DataPortal_Fetch(object criteria)
        //{
        //    if (criteria is FilterCriteriaByMaNhanVien)
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

        private void ExecuteFetch(SqlConnection cn, object criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteriaByMaNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsNhanVien_ChuyenNganhNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByMaNhanVien)criteria).MaNhanVien);
                }
                else if(criteria is FilterCriteriaAll)
                {

                    cm.CommandText = "spd_SelecttblnsNhanVien_ChuyenNganhesAll";
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(NhanVien_ChuyenNganh.GetNhanVien_ChuyenNganh(dr));
                }
            }//using
        }
		internal void Update(SqlTransaction tr, NhanVien parent)
		{
			RaiseListChangedEvents = false;
            try
            {
                // loop through each deleted child object
                foreach (NhanVien_ChuyenNganh deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (NhanVien_ChuyenNganh child in this)
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
