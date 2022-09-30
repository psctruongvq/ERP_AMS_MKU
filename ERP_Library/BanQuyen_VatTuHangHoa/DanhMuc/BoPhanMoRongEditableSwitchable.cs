using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoPhanMoRong : Csla.BusinessBase<BoPhanMoRong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBoPhanMoRong = 0;
		private string _maQuanLy = string.Empty;
		private string _tenBoPhanMoRong = string.Empty;
        private DateTime _ngayLap = DateTime.Today;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaBoPhanMoRong
		{
			get
			{
				CanReadProperty("MaBoPhanMoRong", true);
				return _maBoPhanMoRong;
			}
		}

		public string MaQuanLy
		{
			get
			{
				CanReadProperty("MaQuanLy", true);
				return _maQuanLy;
			}
			set
			{
				CanWriteProperty("MaQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maQuanLy.Equals(value))
				{
					_maQuanLy = value;
					PropertyHasChanged("MaQuanLy");
				}
			}
		}

		public string TenBoPhanMoRong
		{
			get
			{
				CanReadProperty("TenBoPhanMoRong", true);
				return _tenBoPhanMoRong;
			}
			set
			{
				CanWriteProperty("TenBoPhanMoRong", true);
				if (value == null) value = string.Empty;
				if (!_tenBoPhanMoRong.Equals(value))
				{
					_tenBoPhanMoRong = value;
					PropertyHasChanged("TenBoPhanMoRong");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap;
			}
            set
            {
                CanWriteProperty("NgayLap", true);
                if (value == null) value = DateTime.Today;
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
		}

        //public string NgayLapString
        //{
        //    get
        //    {
        //        CanReadProperty("NgayLapString", true);
        //        return _ngayLap.Text;
        //    }
        //    set
        //    {
        //        CanWriteProperty("NgayLapString", true);
        //        if (value == null) value = string.Empty;
        //        if (!_ngayLap.Equals(value))
        //        {
        //            _ngayLap.Text = value;
        //            PropertyHasChanged("NgayLapString");
        //        }
        //    }
        //}

		public string GhiChu
		{
			get
			{
				CanReadProperty("GhiChu", true);
				return _ghiChu;
			}
			set
			{
				CanWriteProperty("GhiChu", true);
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maBoPhanMoRong;
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
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenBoPhanMoRong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhanMoRong", 200));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 1000));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in BoPhanMoRong
			//AuthorizationRules.AllowRead("MaBoPhanMoRong", "BoPhanMoRongReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "BoPhanMoRongReadGroup");
			//AuthorizationRules.AllowRead("TenBoPhanMoRong", "BoPhanMoRongReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "BoPhanMoRongReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "BoPhanMoRongReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "BoPhanMoRongReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "BoPhanMoRongWriteGroup");
			//AuthorizationRules.AllowWrite("TenBoPhanMoRong", "BoPhanMoRongWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "BoPhanMoRongWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "BoPhanMoRongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoPhanMoRong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoPhanMoRong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoPhanMoRong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoPhanMoRong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanMoRongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoPhanMoRong()
		{ /* require use of factory method */ }

		public static BoPhanMoRong NewBoPhanMoRong()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhanMoRong");
			return DataPortal.Create<BoPhanMoRong>();
		}

		public static BoPhanMoRong GetBoPhanMoRong(int maBoPhanMoRong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoPhanMoRong");
			return DataPortal.Fetch<BoPhanMoRong>(new Criteria(maBoPhanMoRong));
		}

		public static void DeleteBoPhanMoRong(int maBoPhanMoRong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoPhanMoRong");
			DataPortal.Delete(new Criteria(maBoPhanMoRong));
		}

		public override BoPhanMoRong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoPhanMoRong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhanMoRong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BoPhanMoRong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BoPhanMoRong NewBoPhanMoRongChild()
		{
			BoPhanMoRong child = new BoPhanMoRong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BoPhanMoRong GetBoPhanMoRong(SafeDataReader dr)
		{
			BoPhanMoRong child =  new BoPhanMoRong();
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
			public int MaBoPhanMoRong;

			public Criteria(int maBoPhanMoRong)
			{
				this.MaBoPhanMoRong = maBoPhanMoRong;
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
                cm.CommandText = "spd_SelectnsBoPhanMoRong";

				cm.Parameters.AddWithValue("@MaBoPhanMoRong", criteria.MaBoPhanMoRong);

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
			DataPortal_Delete(new Criteria(_maBoPhanMoRong));
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
                cm.CommandText = "spd_DeletensBoPhanMoRong";

				cm.Parameters.AddWithValue("@MaBoPhanMoRong", criteria.MaBoPhanMoRong);

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
			_maBoPhanMoRong = dr.GetInt32("MaBoPhanMoRong");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenBoPhanMoRong = dr.GetString("TenBoPhanMoRong");
			_ngayLap = dr.GetDateTime("NgayLap");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BoPhanMoRongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BoPhanMoRongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InsertnsBoPhanMoRong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maBoPhanMoRong = (int)cm.Parameters["@MaBoPhanMoRong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BoPhanMoRongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenBoPhanMoRong.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhanMoRong", _tenBoPhanMoRong);
			else
				cm.Parameters.AddWithValue("@TenBoPhanMoRong", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBoPhanMoRong", _maBoPhanMoRong);
			cm.Parameters["@MaBoPhanMoRong"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BoPhanMoRongList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BoPhanMoRongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatensBoPhanMoRong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BoPhanMoRongList parent)
		{
			cm.Parameters.AddWithValue("@MaBoPhanMoRong", _maBoPhanMoRong);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenBoPhanMoRong.Length > 0)
				cm.Parameters.AddWithValue("@TenBoPhanMoRong", _tenBoPhanMoRong);
			else
				cm.Parameters.AddWithValue("@TenBoPhanMoRong", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maBoPhanMoRong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
