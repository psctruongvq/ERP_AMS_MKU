
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 

	[Serializable()] 
	public class LoaiKhachHang : Csla.BusinessBase<LoaiKhachHang>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiKhachHang = 0;
		private string _tenLoaiKhachHang = string.Empty;
		private string _maQuanLy = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiKhachHang
		{
			get
			{
				CanReadProperty("MaLoaiKhachHang", true);
				return _maLoaiKhachHang;
			}
		}

		public string TenLoaiKhachHang
		{
			get
			{
				CanReadProperty("TenLoaiKhachHang", true);
				return _tenLoaiKhachHang;
			}
			set
			{
				CanWriteProperty("TenLoaiKhachHang", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiKhachHang.Equals(value))
				{
					_tenLoaiKhachHang = value;
					PropertyHasChanged("TenLoaiKhachHang");
				}
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
 
		protected override object GetIdValue()
		{
			return _maLoaiKhachHang;
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
			// TenLoaiKhachHang
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiKhachHang", 500));
			//
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
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
			//TODO: Define authorization rules in LoaiKhachHang
			//AuthorizationRules.AllowRead("MaLoaiKhachHang", "LoaiKhachHangReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiKhachHang", "LoaiKhachHangReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LoaiKhachHangReadGroup");

			//AuthorizationRules.AllowWrite("TenLoaiKhachHang", "LoaiKhachHangWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLy", "LoaiKhachHangWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiKhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKhachHangViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiKhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKhachHangAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiKhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKhachHangEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiKhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiKhachHangDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiKhachHang()
		{ /* require use of factory method */ }

        private LoaiKhachHang(int ma,string ten)
        {
            _maLoaiKhachHang = ma;
            _tenLoaiKhachHang = ten;
        }
        public static LoaiKhachHang NewLoaiKhachHang(int ma,string ten)
        {
            return new LoaiKhachHang(ma, ten);
        }


		public static LoaiKhachHang NewLoaiKhachHang()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiKhachHang");
			return DataPortal.Create<LoaiKhachHang>();
		}

		public static LoaiKhachHang GetLoaiKhachHang(int maLoaiKhachHang)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiKhachHang");
			return DataPortal.Fetch<LoaiKhachHang>(new Criteria(maLoaiKhachHang));
		}

		public static void DeleteLoaiKhachHang(int maLoaiKhachHang)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiKhachHang");
			DataPortal.Delete(new Criteria(maLoaiKhachHang));
		}

		public override LoaiKhachHang Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiKhachHang");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiKhachHang");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiKhachHang");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiKhachHang NewLoaiKhachHangChild()
		{
			LoaiKhachHang child = new LoaiKhachHang();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiKhachHang GetLoaiKhachHang(SafeDataReader dr)
		{
			LoaiKhachHang child =  new LoaiKhachHang();
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
			public int MaLoaiKhachHang;

			public Criteria(int maLoaiKhachHang)
			{
				this.MaLoaiKhachHang = maLoaiKhachHang;
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
                cm.CommandText = "spd_SelecttblLoaiKhachHang";

				cm.Parameters.AddWithValue("@MaLoaiKhachHang", criteria.MaLoaiKhachHang);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    if (dr.Read())
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
			DataPortal_Delete(new Criteria(_maLoaiKhachHang));
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
                cm.CommandText = "spd_DeletetblLoaiKhachHang";

				cm.Parameters.AddWithValue("@MaLoaiKhachHang", criteria.MaLoaiKhachHang);

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
			_maLoaiKhachHang = dr.GetInt32("MaLoaiKhachHang");
			_tenLoaiKhachHang = dr.GetString("TenLoaiKhachHang");
			_maQuanLy = dr.GetString("MaQuanLy");
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
                cm.CommandText = "spd_InserttblLoaiKhachHang";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLoaiKhachHang = (int)cm.Parameters["@MaLoaiKhachHang"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_tenLoaiKhachHang.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiKhachHang", _tenLoaiKhachHang);
			else
				cm.Parameters.AddWithValue("@TenLoaiKhachHang", DBNull.Value);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			cm.Parameters.AddWithValue("@MaLoaiKhachHang", _maLoaiKhachHang);
			cm.Parameters["@MaLoaiKhachHang"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblLoaiKhachHang";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiKhachHang", _maLoaiKhachHang);
			if (_tenLoaiKhachHang.Length > 0)
				cm.Parameters.AddWithValue("@TenLoaiKhachHang", _tenLoaiKhachHang);
			else
				cm.Parameters.AddWithValue("@TenLoaiKhachHang", DBNull.Value);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maLoaiKhachHang));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
