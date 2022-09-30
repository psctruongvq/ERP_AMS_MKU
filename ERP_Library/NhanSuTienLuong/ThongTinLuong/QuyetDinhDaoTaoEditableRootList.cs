
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuyetDinhDaoTaoList : Csla.BusinessListBase<QuyetDinhDaoTaoList, QuyetDinhDaoTao>
	{
		#region BindingList Overrides
		protected override object AddNewCore()
		{
			QuyetDinhDaoTao item = QuyetDinhDaoTao.NewQuyetDinhDaoTao();
			this.Add(item);
			return item;
		}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuyetDinhDaoTaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhDaoTaoListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuyetDinhDaoTaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhDaoTaoListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuyetDinhDaoTaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhDaoTaoListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuyetDinhDaoTaoList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhDaoTaoListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuyetDinhDaoTaoList()
		{ /* require use of factory method */ }

        public static QuyetDinhDaoTaoList GetQuyetDinhDaoTaoList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetDinhDaoTaoList");
            return DataPortal.Fetch<QuyetDinhDaoTaoList>(new FilterCriteria());
        }

		public static QuyetDinhDaoTaoList NewQuyetDinhDaoTaoList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuyetDinhDaoTaoList");
			return new QuyetDinhDaoTaoList();
		}

		public static QuyetDinhDaoTaoList GetQuyetDinhDaoTaoList(int maHinhThucDaoTao, int maTruongDaoTao, int maChuyenNganhDaoTao, int maTacDongDen, int maTrinhDoChuyenMon)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuyetDinhDaoTaoList");
			return DataPortal.Fetch<QuyetDinhDaoTaoList>(new FilterCriteria(maHinhThucDaoTao, maTruongDaoTao, maChuyenNganhDaoTao, maTacDongDen, maTrinhDoChuyenMon));
		}
		#endregion //Factory Methods

		#region Data Access

		#region Filter Criteria
		[Serializable()]
        
		private class FilterCriteria
		{
			public int MaHinhThucDaoTao;
			public int MaTruongDaoTao;
			public int MaChuyenNganhDaoTao;
			public int MaTacDongDen;
			public int MaTrinhDoChuyenMon;
            public FilterCriteria() { }
			public FilterCriteria(int maHinhThucDaoTao, int maTruongDaoTao, int maChuyenNganhDaoTao, int maTacDongDen, int maTrinhDoChuyenMon)
			{
				this.MaHinhThucDaoTao = maHinhThucDaoTao;
				this.MaTruongDaoTao = maTruongDaoTao;
				this.MaChuyenNganhDaoTao = maChuyenNganhDaoTao;
				this.MaTacDongDen = maTacDongDen;
				this.MaTrinhDoChuyenMon = maTrinhDoChuyenMon;
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

		private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
		{
            try
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsQuyetDinhDaoTaosAll";
                    //cm.Parameters.AddWithValue("@MaHinhThucDaoTao", criteria.MaHinhThucDaoTao);
                    //cm.Parameters.AddWithValue("@MaTruongDaoTao", criteria.MaTruongDaoTao);
                    //cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", criteria.MaChuyenNganhDaoTao);
                    //cm.Parameters.AddWithValue("@MaTacDongDen", criteria.MaTacDongDen);
                    //cm.Parameters.AddWithValue("@MaTrinhDoChuyenMon", criteria.MaTrinhDoChuyenMon);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(QuyetDinhDaoTao.GetQuyetDinhDaoTao(dr));
                    }
                }//using
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}
		#endregion //Data Access - Fetch


		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			RaiseListChangedEvents = false;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();
                try
                {
                    // loop through each deleted child object
                    foreach (QuyetDinhDaoTao deletedChild in DeletedList)
                        deletedChild.DeleteSelf(cn);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (QuyetDinhDaoTao child in this)
                    {
                        if (child.IsNew)
                            child.Insert(cn, this);
                        else
                            child.Update(cn, this);
                    }
                }
                catch (SqlException ex)
                {
                    HamDungChung.ThongBaoLoi(ex);
                }
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
