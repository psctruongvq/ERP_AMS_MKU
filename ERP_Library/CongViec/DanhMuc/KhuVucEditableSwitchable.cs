
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KhuVuc : Csla.BusinessBase<KhuVuc>
	{
		#region Business Properties and Methods

		//declare members
        int ii = 0;
		private int _maKhuVuc = 0;
		private string _maKhuVucQuanLy = string.Empty;
		private string _tenKhuVuc = string.Empty;
		private string _dienGiai = string.Empty;
		private int _maQuocGia = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaKhuVuc
		{
			get
			{
				CanReadProperty("MaKhuVuc", true);
				return _maKhuVuc;
			}
		}

		public string MaKhuVucQuanLy
		{
			get
			{
				CanReadProperty("MaKhuVucQuanLy", true);
				return _maKhuVucQuanLy;
			}
			set
			{
				CanWriteProperty("MaKhuVucQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maKhuVucQuanLy.Equals(value))
				{
					_maKhuVucQuanLy = value;
					PropertyHasChanged("MaKhuVucQuanLy");
				}
			}
		}

		public string TenKhuVuc
		{
			get
			{
				CanReadProperty("TenKhuVuc", true);
				return _tenKhuVuc;
			}
			set
			{
				CanWriteProperty("TenKhuVuc", true);
				if (value == null) value = string.Empty;
				if (!_tenKhuVuc.Equals(value))
				{
					_tenKhuVuc = value;
					PropertyHasChanged("TenKhuVuc");
				}
			}
		}

		public string DienGiai
		{
			get
			{
				CanReadProperty("DienGiai", true);
				return _dienGiai;
			}
			set
			{
				CanWriteProperty("DienGiai", true);
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
				}
			}
		}

		public int MaQuocGia
		{
			get
			{
				CanReadProperty("MaQuocGia", true);
				return _maQuocGia;
			}
			set
			{
				CanWriteProperty("MaQuocGia", true);
				if (!_maQuocGia.Equals(value))
				{
					_maQuocGia = value;
					PropertyHasChanged("MaQuocGia");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maKhuVuc;
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
			// MaKhuVucQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaKhuVucQuanLy", 20));
			//
			// TenKhuVuc
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKhuVuc", 500));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in KhuVuc
			//AuthorizationRules.AllowRead("MaKhuVuc", "KhuVucReadGroup");
			//AuthorizationRules.AllowRead("MaKhuVucQuanLy", "KhuVucReadGroup");
			//AuthorizationRules.AllowRead("TenKhuVuc", "KhuVucReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "KhuVucReadGroup");
			//AuthorizationRules.AllowRead("MaQuocGia", "KhuVucReadGroup");

			//AuthorizationRules.AllowWrite("MaKhuVucQuanLy", "KhuVucWriteGroup");
			//AuthorizationRules.AllowWrite("TenKhuVuc", "KhuVucWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "KhuVucWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuocGia", "KhuVucWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in KhuVuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhuVucViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in KhuVuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhuVucAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in KhuVuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhuVucEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in KhuVuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("KhuVucDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private KhuVuc()
		{ /* require use of factory method */ }

		public static KhuVuc NewKhuVuc()
		{
            KhuVuc i = new KhuVuc();
            i.MarkAsChild();
            return i;
		}
        private KhuVuc(int makhuvuc,string tenkhuvuc)
        {
            this._maKhuVuc = makhuvuc;
            this._tenKhuVuc = tenkhuvuc;
        }
        public static KhuVuc NewKhuVuc(int makhuvuc, string tenkhuvuc)
        {
            return new KhuVuc(makhuvuc, tenkhuvuc);
        }

		public static KhuVuc GetKhuVuc(int maKhuVuc)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a KhuVuc");
			return DataPortal.Fetch<KhuVuc>(new Criteria(maKhuVuc));
		}

		public static void DeleteKhuVuc(int maKhuVuc)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KhuVuc");
			DataPortal.Delete(new Criteria(maKhuVuc));
		}

		public override KhuVuc Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a KhuVuc");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a KhuVuc");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a KhuVuc");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static KhuVuc NewKhuVucChild()
		{
			KhuVuc child = new KhuVuc();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KhuVuc GetKhuVuc(SafeDataReader dr)
		{
			KhuVuc child =  new KhuVuc();
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
			public int MaKhuVuc;

			public Criteria(int maKhuVuc)
			{
				this.MaKhuVuc = maKhuVuc;
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
                cm.CommandText = "spd_SelecttblKhuVuc";

				cm.Parameters.AddWithValue("@MaKhuVuc", criteria.MaKhuVuc);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
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
			DataPortal_Delete(new Criteria(_maKhuVuc));
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
                cm.CommandText = "spd_DeletetblKhuVuc";

				cm.Parameters.AddWithValue("@MaKhuVuc", criteria.MaKhuVuc);

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
			_maKhuVuc = dr.GetInt32("MaKhuVuc");
			_maKhuVucQuanLy = dr.GetString("MaKhuVucQuanLy");
			_tenKhuVuc = dr.GetString("TenKhuVuc");
			_dienGiai = dr.GetString("DienGiai");
			_maQuocGia = dr.GetInt32("MaQuocGia");
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
                cm.CommandText = "spd_InserttblKhuVuc";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maKhuVuc = (int)cm.Parameters["@MaKhuVuc"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maKhuVucQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaKhuVucQuanLy", _maKhuVucQuanLy);
			else
				cm.Parameters.AddWithValue("@MaKhuVucQuanLy", DBNull.Value);
			if (_tenKhuVuc.Length > 0)
				cm.Parameters.AddWithValue("@TenKhuVuc", _tenKhuVuc);
			else
				cm.Parameters.AddWithValue("@TenKhuVuc", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maQuocGia != 0)
				cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
			else
				cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKhuVuc", _maKhuVuc);
			cm.Parameters["@MaKhuVuc"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblKhuVuc";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKhuVuc", _maKhuVuc);
			if (_maKhuVucQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaKhuVucQuanLy", _maKhuVucQuanLy);
			else
				cm.Parameters.AddWithValue("@MaKhuVucQuanLy", DBNull.Value);
			if (_tenKhuVuc.Length > 0)
				cm.Parameters.AddWithValue("@TenKhuVuc", _tenKhuVuc);
			else
				cm.Parameters.AddWithValue("@TenKhuVuc", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maQuocGia != 0)
				cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
			else
				cm.Parameters.AddWithValue("@MaQuocGia", DBNull.Value);
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
			ExecuteDelete(tr, new Criteria(_maKhuVuc));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
