
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoatDong_ChiPhiHoatDong : Csla.BusinessBase<HoatDong_ChiPhiHoatDong>
	{
		#region Business Properties and Methods

		//declare members
		private int _id = 0;
		private int _maChiHoatDong = 0;
		private int _maChiTietHoatDong = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int Id
		{
			get
			{
				return _id;
			}
		}

		public int MaChiHoatDong
		{
			get
			{
				return _maChiHoatDong;
			}
			set
			{
				if (!_maChiHoatDong.Equals(value))
				{
					_maChiHoatDong = value;
					PropertyHasChanged("MaChiHoatDong");
				}
			}
		}

		public int MaChiTietHoatDong
		{
			get
			{
				return _maChiTietHoatDong;
			}
			set
			{
				if (!_maChiTietHoatDong.Equals(value))
				{
					_maChiTietHoatDong = value;
					PropertyHasChanged("MaChiTietHoatDong");
				}
			}
		}
        private int _maCongTy = 0;
        public int MaCongTy
        {
            get
            {
                return _maCongTy;
            }
            set
            {
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }
		protected override object GetIdValue()
		{
			return _id;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private HoatDong_ChiPhiHoatDong()
		{ /* require use of factory method */ }

		public static HoatDong_ChiPhiHoatDong NewHoatDong_ChiPhiHoatDong()
        {
            HoatDong_ChiPhiHoatDong item = new HoatDong_ChiPhiHoatDong();
            item.MarkAsChild();
            return item;
		
		}

		public static HoatDong_ChiPhiHoatDong GetHoatDong_ChiPhiHoatDong(int id)
		{
			return DataPortal.Fetch<HoatDong_ChiPhiHoatDong>(new Criteria(id));
		}

		public static void DeleteHoatDong_ChiPhiHoatDong(int id)
		{
			DataPortal.Delete(new Criteria(id));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HoatDong_ChiPhiHoatDong NewHoatDong_ChiPhiHoatDongChild()
		{
			HoatDong_ChiPhiHoatDong child = new HoatDong_ChiPhiHoatDong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HoatDong_ChiPhiHoatDong GetHoatDong_ChiPhiHoatDong(SafeDataReader dr)
		{
			HoatDong_ChiPhiHoatDong child =  new HoatDong_ChiPhiHoatDong();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int Id;

			public Criteria(int id)
			{
				this.Id = id;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
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
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "SelecttblHoatDong_ChiPhiHoatDong";

				cm.Parameters.AddWithValue("@ID", criteria.Id);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					ValidationRules.CheckRules();

					//load child object(s)
					FetchChildren(dr);
				}
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr, null);

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					if (base.IsDirty)
					{
						ExecuteUpdate(tr, null);
					}

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_id));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteDelete(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "DeletetblHoatDong_ChiPhiHoatDong";

				cm.Parameters.AddWithValue("@ID", criteria.Id);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_id = dr.GetInt32("ID");
			_maChiHoatDong = dr.GetInt32("MaChiHoatDong");
			_maChiTietHoatDong = dr.GetInt32("MaChiTietHoatDong");
            _maCongTy = dr.GetInt32("MaCongTy");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, HoatDong_ChiPhiHoatDongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, HoatDong_ChiPhiHoatDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblHoatDong_ChiPhiHoatDong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_id = (int)cm.Parameters["@ID"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, HoatDong_ChiPhiHoatDongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maChiHoatDong != 0)
				cm.Parameters.AddWithValue("@MaChiHoatDong", _maChiHoatDong);
			else
				cm.Parameters.AddWithValue("@MaChiHoatDong", DBNull.Value);
			if (_maChiTietHoatDong != 0)
				cm.Parameters.AddWithValue("@MaChiTietHoatDong", _maChiTietHoatDong);
			else
				cm.Parameters.AddWithValue("@MaChiTietHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
			cm.Parameters.AddWithValue("@ID", _id);
			cm.Parameters["@ID"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, HoatDong_ChiPhiHoatDongList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, HoatDong_ChiPhiHoatDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblHoatDong_ChiPhiHoatDong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HoatDong_ChiPhiHoatDongList parent)
		{
			cm.Parameters.AddWithValue("@ID", _id);
			if (_maChiHoatDong != 0)
				cm.Parameters.AddWithValue("@MaChiHoatDong", _maChiHoatDong);
			else
				cm.Parameters.AddWithValue("@MaChiHoatDong", DBNull.Value);
			if (_maChiTietHoatDong != 0)
				cm.Parameters.AddWithValue("@MaChiTietHoatDong", _maChiTietHoatDong);
			else
				cm.Parameters.AddWithValue("@MaChiTietHoatDong", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_id));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
