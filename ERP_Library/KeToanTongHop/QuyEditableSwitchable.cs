
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class Quy : Csla.BusinessBase<Quy>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuy = 0;
		private string _maQuanLy = string.Empty;
		private string _tenQuy = string.Empty;
		private int _tuKy = 0;
		private int _denKy = 0;
        private string _tenKyBatDau = string.Empty;
        private string _tenKyKetThuc = string.Empty;
		private DateTime _ngayBatDau = DateTime.Today;
		private DateTime _ngayKetThuc = DateTime.Today;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuy
		{
			get
			{
				CanReadProperty("MaQuy", true);
				return _maQuy;
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

		public string TenQuy
		{
			get
			{
				CanReadProperty("TenQuy", true);
				return _tenQuy;
			}
			set
			{
				CanWriteProperty("TenQuy", true);
				if (value == null) value = string.Empty;
				if (!_tenQuy.Equals(value))
				{
					_tenQuy = value;
					PropertyHasChanged("TenQuy");
				}
			}
		}

		public int TuKy
		{
			get
			{
				CanReadProperty("TuKy", true);
				return _tuKy;
			}
			set
			{
				CanWriteProperty("TuKy", true);
				if (!_tuKy.Equals(value))
				{
					_tuKy = value;
					PropertyHasChanged("TuKy");
				}
			}
		}

		public int DenKy
		{
			get
			{
				CanReadProperty("DenKy", true);
				return _denKy;
			}
			set
			{
				CanWriteProperty("DenKy", true);
				if (!_denKy.Equals(value))
				{
					_denKy = value;
					PropertyHasChanged("DenKy");
				}
			}
		}

        public string TenKyBatDau
        {
            get
            {
                CanReadProperty("TenKyBatDau", true);
                return _tenKyBatDau;
            }
            set
            {
                CanWriteProperty("TenKyBatDau", true);
                if (!_tenKyBatDau.Equals(value))
                {
                    _tenKyBatDau = value;
                    PropertyHasChanged("TenKyBatDau");
                }
            }
        }

        public string TenKyKetThuc
        {
            get
            {
                CanReadProperty("TenKyKetThuc", true);
                return _tenKyKetThuc;
            }
            set
            {
                CanWriteProperty("TenKyKetThuc", true);
                if (!_tenKyKetThuc.Equals(value))
                {
                    _tenKyKetThuc = value;
                    PropertyHasChanged("TenKyKetThuc");
                }
            }
        }

		public DateTime NgayBatDau
		{
			get
			{
				CanReadProperty("NgayBatDau", true);
				return _ngayBatDau;
			}
			set
			{
				CanWriteProperty("NgayBatDau", true);
				if (!_ngayBatDau.Equals(value))
				{
					_ngayBatDau = value;
					PropertyHasChanged("NgayBatDau");
				}
			}
		}

		public DateTime NgayKetThuc
		{
			get
			{
				CanReadProperty("NgayKetThuc", true);
				return _ngayKetThuc;
			}
			set
			{
				CanWriteProperty("NgayKetThuc", true);
				if (!_ngayKetThuc.Equals(value))
				{
					_ngayKetThuc = value;
					PropertyHasChanged("NgayKetThuc");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maQuy;
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
			// TenQuy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQuy", 500));
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
			//TODO: Define authorization rules in Quy
			//AuthorizationRules.AllowRead("MaQuy", "QuyReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "QuyReadGroup");
			//AuthorizationRules.AllowRead("TenQuy", "QuyReadGroup");
			//AuthorizationRules.AllowRead("TuKy", "QuyReadGroup");
			//AuthorizationRules.AllowRead("DenKy", "QuyReadGroup");
			//AuthorizationRules.AllowRead("NgayBatDau", "QuyReadGroup");
			//AuthorizationRules.AllowRead("NgayKetThuc", "QuyReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "QuyWriteGroup");
			//AuthorizationRules.AllowWrite("TenQuy", "QuyWriteGroup");
			//AuthorizationRules.AllowWrite("TuKy", "QuyWriteGroup");
			//AuthorizationRules.AllowWrite("DenKy", "QuyWriteGroup");
			//AuthorizationRules.AllowWrite("NgayBatDau", "QuyWriteGroup");
			//AuthorizationRules.AllowWrite("NgayKetThuc", "QuyWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in Quy
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in Quy
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in Quy
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in Quy
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuyDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private Quy()
		{ /* require use of factory method */ }

		public static Quy NewQuy()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Quy");
			return DataPortal.Create<Quy>();
		}

		public static Quy GetQuy(int maQuy)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a Quy");
			return DataPortal.Fetch<Quy>(new Criteria(maQuy));
		}

		public static void DeleteQuy(int maQuy)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Quy");
			DataPortal.Delete(new Criteria(maQuy));
		}

		public override Quy Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Quy");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Quy");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a Quy");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static Quy NewQuyChild()
		{
			Quy child = new Quy();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static Quy GetQuy(SafeDataReader dr)
		{
			Quy child =  new Quy();
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
			public int MaQuy;

			public Criteria(int maQuy)
			{
				this.MaQuy = maQuy;
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
                cm.CommandText = "spd_SelecttblQuy";

				cm.Parameters.AddWithValue("@MaQuy", criteria.MaQuy);

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
					ExecuteInsert(tr);

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
						ExecuteUpdate(tr);
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
			DataPortal_Delete(new Criteria(_maQuy));
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
                cm.CommandText = "spd_DeletetblQuy";

				cm.Parameters.AddWithValue("@MaQuy", criteria.MaQuy);

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
			_maQuy = dr.GetInt32("MaQuy");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenQuy = dr.GetString("TenQuy");
			_tuKy = dr.GetInt32("TuKy");
			_denKy = dr.GetInt32("DenKy");
			_ngayBatDau = dr.GetDateTime("NgayBatDau");
			_ngayKetThuc = dr.GetDateTime("NgayKetThuc");
            _tenKyBatDau= dr.GetString("TenKyBatDau");
            _tenKyKetThuc= dr.GetString("TenKyKetThuc");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblQuy";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maQuy = (int)cm.Parameters["@MaQuy"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenQuy.Length > 0)
				cm.Parameters.AddWithValue("@TenQuy", _tenQuy);
			else
				cm.Parameters.AddWithValue("@TenQuy", DBNull.Value);
			if (_tuKy != 0)
				cm.Parameters.AddWithValue("@TuKy", _tuKy);
			else
				cm.Parameters.AddWithValue("@TuKy", DBNull.Value);
			if (_denKy != 0)
				cm.Parameters.AddWithValue("@DenKy", _denKy);
			else
				cm.Parameters.AddWithValue("@DenKy", DBNull.Value);
			if (_ngayBatDau != DateTime.Today)
				cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau);
			else
				cm.Parameters.AddWithValue("@NgayBatDau", DBNull.Value);
			if (_ngayKetThuc != DateTime.Today)
				cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc);
			else
				cm.Parameters.AddWithValue("@NgayKetThuc", DBNull.Value);
			cm.Parameters.AddWithValue("@MaQuy", _maQuy);
			cm.Parameters["@MaQuy"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblQuy";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuy", _maQuy);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenQuy.Length > 0)
				cm.Parameters.AddWithValue("@TenQuy", _tenQuy);
			else
				cm.Parameters.AddWithValue("@TenQuy", DBNull.Value);
			if (_tuKy != 0)
				cm.Parameters.AddWithValue("@TuKy", _tuKy);
			else
				cm.Parameters.AddWithValue("@TuKy", DBNull.Value);
			if (_denKy != 0)
				cm.Parameters.AddWithValue("@DenKy", _denKy);
			else
				cm.Parameters.AddWithValue("@DenKy", DBNull.Value);
			if (_ngayBatDau != DateTime.Today)
				cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau);
			else
				cm.Parameters.AddWithValue("@NgayBatDau", DBNull.Value);
			if (_ngayKetThuc != DateTime.Today)
				cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc);
			else
				cm.Parameters.AddWithValue("@NgayKetThuc", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maQuy));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
