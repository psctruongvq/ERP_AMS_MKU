
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChucDanh : Csla.BusinessBase<ChucDanh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChucDanh = 0;
		private string _maQuanLy = string.Empty;
		private string _tenChucDanh = string.Empty;
		private int _maNhomChucDanh = 0;
		private int _maChucVu = 0;
		private string _tenViettat = string.Empty;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChucDanh
		{
			get
			{
				CanReadProperty("MaChucDanh", true);
				return _maChucDanh;
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

		public string TenChucDanh
		{
			get
			{
				CanReadProperty("TenChucDanh", true);
				return _tenChucDanh;
			}
			set
			{
				CanWriteProperty("TenChucDanh", true);
				if (value == null) value = string.Empty;
				if (!_tenChucDanh.Equals(value))
				{
					_tenChucDanh = value;
					PropertyHasChanged("TenChucDanh");
				}
			}
		}

		public int MaNhomChucDanh
		{
			get
			{
				CanReadProperty("MaNhomChucDanh", true);
				return _maNhomChucDanh;
			}
			set
			{
				CanWriteProperty("MaNhomChucDanh", true);
				if (!_maNhomChucDanh.Equals(value))
				{
					_maNhomChucDanh = value;
					PropertyHasChanged("MaNhomChucDanh");
				}
			}
		}

	
		public string TenViettat
		{
			get
			{
				CanReadProperty("TenViettat", true);
				return _tenViettat;
			}
			set
			{
				CanWriteProperty("TenViettat", true);
				if (value == null) value = string.Empty;
				if (!_tenViettat.Equals(value))
				{
					_tenViettat = value;
					PropertyHasChanged("TenViettat");
				}
			}
		}

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
			return _maChucDanh;
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
			ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenChucDanh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucDanh", 100));
			//
			// TenViettat
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenViettat", 50));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
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
			//TODO: Define authorization rules in ChucDanh
			//AuthorizationRules.AllowRead("MaChucDanh", "ChucDanhReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "ChucDanhReadGroup");
			//AuthorizationRules.AllowRead("TenChucDanh", "ChucDanhReadGroup");
			//AuthorizationRules.AllowRead("MaNhomChucDanh", "ChucDanhReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "ChucDanhReadGroup");
			//AuthorizationRules.AllowRead("MaNgachLuongKinhDoanh", "ChucDanhReadGroup");
			//AuthorizationRules.AllowRead("TenViettat", "ChucDanhReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "ChucDanhReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "ChucDanhWriteGroup");
			//AuthorizationRules.AllowWrite("TenChucDanh", "ChucDanhWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhomChucDanh", "ChucDanhWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "ChucDanhWriteGroup");
			//AuthorizationRules.AllowWrite("MaNgachLuongKinhDoanh", "ChucDanhWriteGroup");
			//AuthorizationRules.AllowWrite("TenViettat", "ChucDanhWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "ChucDanhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChucDanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucDanhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChucDanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucDanhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChucDanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucDanhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChucDanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucDanhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChucDanh()
		{ /* require use of factory method */ }

		public static ChucDanh NewChucDanh()
		{
            ChucDanh item = new ChucDanh();
            item.MarkAsChild();
            return item;
		}
        private ChucDanh(int machucdanh, string tenchucdanh)
        {
            this._maChucDanh = machucdanh;
            this._tenChucDanh = tenchucdanh;
        }

        public static ChucDanh NewChucDanh(int machucdanh, string tenchucdanh)
        {
            return new ChucDanh(machucdanh, tenchucdanh);
        }
		public static ChucDanh GetChucDanh(int maChucDanh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChucDanh");
			return DataPortal.Fetch<ChucDanh>(new Criteria(maChucDanh));
		}

		public static void DeleteChucDanh(int maChucDanh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChucDanh");
			DataPortal.Delete(new Criteria(maChucDanh));
		}

		public override ChucDanh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChucDanh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChucDanh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChucDanh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChucDanh NewChucDanhChild()
		{
			ChucDanh child = new ChucDanh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}
        public static ChucDanh NewChucDanhChild(int maChucDanh,string tenChucDanh)
        {
            ChucDanh child = new ChucDanh();
            child._maChucDanh = maChucDanh;
            child._tenChucDanh = tenChucDanh;
            child.MarkAsChild();
            return child;
        }

		internal static ChucDanh GetChucDanh(SafeDataReader dr)
		{
			ChucDanh child =  new ChucDanh();
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
			public int MaChucDanh;

			public Criteria(int maChucDanh)
			{
				this.MaChucDanh = maChucDanh;
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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsChucDanh";

				cm.Parameters.AddWithValue("@MaChucDanh", criteria.MaChucDanh);

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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maChucDanh));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsChucDanh";

				cm.Parameters.AddWithValue("@MaChucDanh", criteria.MaChucDanh);

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
			_maChucDanh = dr.GetInt32("MaChucDanh");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenChucDanh = dr.GetString("TenChucDanh");
			_maNhomChucDanh = dr.GetInt32("MaNhomChucDanh");
			_maChucVu = dr.GetInt32("MaChucVu");
			_tenViettat = dr.GetString("TenViettat");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsChucDanh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maChucDanh = (int)cm.Parameters["@MaChucDanh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenChucDanh.Length > 0)
				cm.Parameters.AddWithValue("@TenChucDanh", _tenChucDanh);
			else
				cm.Parameters.AddWithValue("@TenChucDanh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhomChucDanh", _maNhomChucDanh);
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			if (_tenViettat.Length > 0)
				cm.Parameters.AddWithValue("@TenViettat", _tenViettat);
			else
				cm.Parameters.AddWithValue("@TenViettat", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChucDanh", _maChucDanh);
			cm.Parameters["@MaChucDanh"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsChucDanh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaChucDanh", _maChucDanh);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenChucDanh.Length > 0)
				cm.Parameters.AddWithValue("@TenChucDanh", _tenChucDanh);
			else
				cm.Parameters.AddWithValue("@TenChucDanh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhomChucDanh", _maNhomChucDanh);
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			if (_tenViettat.Length > 0)
				cm.Parameters.AddWithValue("@TenViettat", _tenViettat);
			else
				cm.Parameters.AddWithValue("@TenViettat", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
		}

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_maChucDanh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
