
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HoatDong : Csla.BusinessBase<HoatDong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHoatDong = 0;
		private string _tenHoatDong = string.Empty;
		private string _maQLHoatDong = string.Empty;
        private int _maCongTy = 0;

        public int MaCongTy
        {
            get { return _maCongTy; }
            set { _maCongTy = value; }
        }
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaHoatDong
		{
			get
			{
				return _maHoatDong;
			}
		}

		public string TenHoatDong
		{
			get
			{
				return _tenHoatDong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenHoatDong.Equals(value))
				{
					_tenHoatDong = value;
					PropertyHasChanged("TenHoatDong");
				}
			}
		}

		public string MaQLHoatDong
		{
			get
			{
				return _maQLHoatDong;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maQLHoatDong.Equals(value))
				{
					_maQLHoatDong = value;
					PropertyHasChanged("MaQLHoatDong");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maHoatDong;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
			//
			// TenHoatDong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHoatDong", 2000));
			//
			// MaQLHoatDong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLHoatDong", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private HoatDong()
		{ /* require use of factory method */ }

		public static HoatDong NewHoatDong()
		{
            HoatDong item = new HoatDong();
            item.MarkAsChild();
            return item;
		}

		public static HoatDong GetHoatDong(int maHoatDong)
		{
			return DataPortal.Fetch<HoatDong>(new Criteria(maHoatDong));
		}

		public static void DeleteHoatDong(int maHoatDong)
		{
			DataPortal.Delete(new Criteria(maHoatDong));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HoatDong NewHoatDongChild()
		{
			HoatDong child = new HoatDong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HoatDong GetHoatDong(SafeDataReader dr)
		{
			HoatDong child =  new HoatDong();
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
			public int MaHoatDong;

			public Criteria(int maHoatDong)
			{
				this.MaHoatDong = maHoatDong;
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
				cm.CommandText = "SelecttblHoatDong";

				cm.Parameters.AddWithValue("@MaHoatDong", criteria.MaHoatDong);

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
			DataPortal_Delete(new Criteria(_maHoatDong));
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
				cm.CommandText = "DeletetblHoatDong";

				cm.Parameters.AddWithValue("@MaHoatDong", criteria.MaHoatDong);

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
			_maHoatDong = dr.GetInt32("MaHoatDong");
			_tenHoatDong = dr.GetString("TenHoatDong");
			_maQLHoatDong = dr.GetString("MaQLHoatDong");
            _maCongTy = dr.GetInt32("MaCongTy");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, HoatDongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, HoatDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblHoatDong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maHoatDong = (int)cm.Parameters["@MaHoatDong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, HoatDongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
            cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
			if (_tenHoatDong.Length > 0)
				cm.Parameters.AddWithValue("@TenHoatDong", _tenHoatDong);
			else
				cm.Parameters.AddWithValue("@TenHoatDong", DBNull.Value);
			if (_maQLHoatDong.Length > 0)
				cm.Parameters.AddWithValue("@MaQLHoatDong", _maQLHoatDong);
			else
				cm.Parameters.AddWithValue("@MaQLHoatDong", DBNull.Value);
			cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);          
			cm.Parameters["@MaHoatDong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, HoatDongList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, HoatDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblHoatDong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, HoatDongList parent)
		{
			cm.Parameters.AddWithValue("@MaHoatDong", _maHoatDong);
			if (_tenHoatDong.Length > 0)
				cm.Parameters.AddWithValue("@TenHoatDong", _tenHoatDong);
			else
				cm.Parameters.AddWithValue("@TenHoatDong", DBNull.Value);
			if (_maQLHoatDong.Length > 0)
				cm.Parameters.AddWithValue("@MaQLHoatDong", _maQLHoatDong);
			else
				cm.Parameters.AddWithValue("@MaQLHoatDong", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maHoatDong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
