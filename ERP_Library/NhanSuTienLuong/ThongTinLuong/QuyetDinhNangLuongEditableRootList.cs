
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//TT11
namespace ERP_Library
{ 
	[Serializable()] 
	public class QuyetDinhNangLuongList : Csla.BusinessListBase<QuyetDinhNangLuongList, QuyetDinhNangLuong>
	{
		#region BindingList Overrides
        //protected override object AddNewCore()
        //{
        //    QuyetDinhNangLuong item = QuyetDinhNangLuong.NewQuyetDinhNangLuong();
        //    this.Add(item);
        //    return item;
        //}
		#endregion //BindingList Overrides

		#region Authorization Rules

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuyetDinhNangLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhNangLuongListViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuyetDinhNangLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhNangLuongListAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuyetDinhNangLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhNangLuongListEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuyetDinhNangLuongList
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyetDinhNangLuongListDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuyetDinhNangLuongList()
		{ /* require use of factory method */ }

		public static QuyetDinhNangLuongList NewQuyetDinhNangLuongList()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuyetDinhNangLuongList");
			return new QuyetDinhNangLuongList();
		}

		public static QuyetDinhNangLuongList GetQuyetDinhNangLuongList()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuyetDinhNangLuongList");
			return DataPortal.Fetch<QuyetDinhNangLuongList>(new FilterCriteria());
		}
        public static QuyetDinhNangLuongList GetQuyetDinhNangLuongList(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetDinhNangLuongList");
            return DataPortal.Fetch<QuyetDinhNangLuongList>(new FilterCriteriaByNhanVien(maNhanVien));
        }

        public static QuyetDinhNangLuongList GetQuyetDinhNangLuongList(bool _capNhatSau)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetDinhNangLuongList");
            return DataPortal.Fetch<QuyetDinhNangLuongList>(new FilterCriteriaByChoCapNhat(_capNhatSau));
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
        private class FilterCriteriaByNhanVien
        {
            public long maNhanVien;

            public FilterCriteriaByNhanVien(long manhanvien)
            {
                this.maNhanVien = manhanvien;
            }
        }

        private class FilterCriteriaByChoCapNhat
        {
            public bool capNhatSau;

            public FilterCriteriaByChoCapNhat(bool _capNhatSau)
            {
                this.capNhatSau = _capNhatSau;
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
                    cm.CommandText = "spd_SelecttblnsQuyetDinhNangLuongsAll";
                }
                else if (criteria is FilterCriteriaByNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsQuyetDinhNangLuongsByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien",((FilterCriteriaByNhanVien)criteria).maNhanVien);
                }
                else if (criteria is FilterCriteriaByChoCapNhat)
                {
                    cm.CommandText = "spd_KiemTraNgayChoCapNhatDuLieu";
                    cm.Parameters.AddWithValue("@CapNhatSau", ((FilterCriteriaByChoCapNhat)criteria).capNhatSau);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while (dr.Read())
						this.Add(QuyetDinhNangLuong.GetQuyetDinhNangLuong(dr));
				}
			}//using
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
					foreach (QuyetDinhNangLuong deletedChild in DeletedList)
						deletedChild.DeleteSelf(tr);
					DeletedList.Clear();

					// loop through each non-deleted child object
					foreach (QuyetDinhNangLuong child in this)
					{
						if (child.IsNew)
							child.Insert(tr,this);
						else
							child.Update(tr,this);
					}

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using SqlConnection

			RaiseListChangedEvents = true;
		}
		#endregion //Data Access - Update
		#endregion //Data Access
	}
}
