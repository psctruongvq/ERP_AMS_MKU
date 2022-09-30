
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhomKhachHang : Csla.BusinessBase<NhomKhachHang>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNhomKhachHang = 0;
		private string _tenNhomKhachHang = string.Empty;
		private string _maQuanLy = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNhomKhachHang
		{
			get
			{
				CanReadProperty("MaNhomKhachHang", true);
				return _maNhomKhachHang;
			}
		}

		public string TenNhomKhachHang
		{
			get
			{
				CanReadProperty("TenNhomKhachHang", true);
				return _tenNhomKhachHang;
			}
			set
			{
				CanWriteProperty("TenNhomKhachHang", true);
				if (value == null) value = string.Empty;
				if (!_tenNhomKhachHang.Equals(value))
				{
					_tenNhomKhachHang = value;
					PropertyHasChanged("TenNhomKhachHang");
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
			return _maNhomKhachHang;
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
			// TenNhomKhachHang
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhomKhachHang", 500));
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
			//TODO: Define authorization rules in NhomKhachHang
			//AuthorizationRules.AllowRead("MaNhomKhachHang", "NhomKhachHangReadGroup");
			//AuthorizationRules.AllowRead("TenNhomKhachHang", "NhomKhachHangReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "NhomKhachHangReadGroup");

			//AuthorizationRules.AllowWrite("TenNhomKhachHang", "NhomKhachHangWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLy", "NhomKhachHangWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhomKhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomKhachHangViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhomKhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomKhachHangAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhomKhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomKhachHangEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhomKhachHang
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhomKhachHangDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		public NhomKhachHang()
		{ /* require use of factory method */ }

        public NhomKhachHang(int ma,string ten)
        {
            _maNhomKhachHang = ma;
            _tenNhomKhachHang = ten;
        }

        public static NhomKhachHang NewNhomKhachHang(int ma,string ten)
        {
            return new NhomKhachHang(ma, ten);
        }

		public static NhomKhachHang NewNhomKhachHang()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhomKhachHang");
			return DataPortal.Create<NhomKhachHang>();
		}

		public static NhomKhachHang GetNhomKhachHang(int maNhomKhachHang)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhomKhachHang");
			return DataPortal.Fetch<NhomKhachHang>(new Criteria(maNhomKhachHang));
		}

		public static void DeleteNhomKhachHang(int maNhomKhachHang)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhomKhachHang");
			DataPortal.Delete(new Criteria(maNhomKhachHang));
		}

		public override NhomKhachHang Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhomKhachHang");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhomKhachHang");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NhomKhachHang");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NhomKhachHang NewNhomKhachHangChild()
		{
			NhomKhachHang child = new NhomKhachHang();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhomKhachHang GetNhomKhachHang(SafeDataReader dr)
		{
			NhomKhachHang child =  new NhomKhachHang();
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
			public int MaNhomKhachHang;

			public Criteria(int maNhomKhachHang)
			{
				this.MaNhomKhachHang = maNhomKhachHang;
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
                cm.CommandText = "spd_SelecttblNhomKhachHang";

				cm.Parameters.AddWithValue("@MaNhomKhachHang", criteria.MaNhomKhachHang);

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
			DataPortal_Delete(new Criteria(_maNhomKhachHang));
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
                cm.CommandText = "spd_DeletetblNhomKhachHang";

				cm.Parameters.AddWithValue("@MaNhomKhachHang", criteria.MaNhomKhachHang);

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
			_maNhomKhachHang = dr.GetInt32("MaNhomKhachHang");
			_tenNhomKhachHang = dr.GetString("TenNhomKhachHang");
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
                cm.CommandText = "spd_InserttblNhomKhachHang";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maNhomKhachHang = (int)cm.Parameters["@MaNhomKhachHang"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_tenNhomKhachHang.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomKhachHang", _tenNhomKhachHang);
			else
				cm.Parameters.AddWithValue("@TenNhomKhachHang", DBNull.Value);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhomKhachHang", _maNhomKhachHang);
			cm.Parameters["@MaNhomKhachHang"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblNhomKhachHang";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhomKhachHang", _maNhomKhachHang);
			if (_tenNhomKhachHang.Length > 0)
				cm.Parameters.AddWithValue("@TenNhomKhachHang", _tenNhomKhachHang);
			else
				cm.Parameters.AddWithValue("@TenNhomKhachHang", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maNhomKhachHang));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
