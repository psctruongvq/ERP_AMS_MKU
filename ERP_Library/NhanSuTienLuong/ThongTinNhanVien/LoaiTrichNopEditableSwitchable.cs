
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LoaiTrichNop : Csla.BusinessBase<LoaiTrichNop>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLoaiTrichNop = 0;
		private string _maQuanLy = string.Empty;
		private string _tenLoaiTrichNop = string.Empty;
		private bool _tinhVaoLuong = false;
		private string _congTruLuong = string.Empty;
		private bool _tinhThueThuNhap = false;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiTrichNop
		{
			get
			{
				CanReadProperty("MaLoaiTrichNop", true);
				return _maLoaiTrichNop;
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

		public string TenLoaiTrichNop
		{
			get
			{
				CanReadProperty("TenLoaiTrichNop", true);
				return _tenLoaiTrichNop;
			}
			set
			{
				CanWriteProperty("TenLoaiTrichNop", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiTrichNop.Equals(value))
				{
					_tenLoaiTrichNop = value;
					PropertyHasChanged("TenLoaiTrichNop");
				}
			}
		}

		public bool TinhVaoLuong
		{
			get
			{
				CanReadProperty("TinhVaoLuong", true);
				return _tinhVaoLuong;
			}
			set
			{
				CanWriteProperty("TinhVaoLuong", true);
				if (!_tinhVaoLuong.Equals(value))
				{
					_tinhVaoLuong = value;
					PropertyHasChanged("TinhVaoLuong");
				}
			}
		}

		public string CongTruLuong
		{
			get
			{
				CanReadProperty("CongTruLuong", true);
				return _congTruLuong;
			}
			set
			{
				CanWriteProperty("CongTruLuong", true);
				if (value == null) value = string.Empty;
				if (!_congTruLuong.Equals(value))
				{
					_congTruLuong = value;
					PropertyHasChanged("CongTruLuong");
				}
			}
		}

		public bool TinhThueThuNhap
		{
			get
			{
				CanReadProperty("TinhThueThuNhap", true);
				return _tinhThueThuNhap;
			}
			set
			{
				CanWriteProperty("TinhThueThuNhap", true);
				if (!_tinhThueThuNhap.Equals(value))
				{
					_tinhThueThuNhap = value;
					PropertyHasChanged("TinhThueThuNhap");
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
 
		protected override object GetIdValue()
		{
			return _maLoaiTrichNop;
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
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// TenLoaiTrichNop
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenLoaiTrichNop");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenLoaiTrichNop", 500));
			//
			// CongTruLuong
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "CongTruLuong");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CongTruLuong", 50));
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
			//TODO: Define authorization rules in LoaiTrichNop
			//AuthorizationRules.AllowRead("MaLoaiTrichNop", "LoaiTrichNopReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LoaiTrichNopReadGroup");
			//AuthorizationRules.AllowRead("TenLoaiTrichNop", "LoaiTrichNopReadGroup");
			//AuthorizationRules.AllowRead("TinhVaoLuong", "LoaiTrichNopReadGroup");
			//AuthorizationRules.AllowRead("CongTruLuong", "LoaiTrichNopReadGroup");
			//AuthorizationRules.AllowRead("TinhThueThuNhap", "LoaiTrichNopReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "LoaiTrichNopReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "LoaiTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("TenLoaiTrichNop", "LoaiTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("TinhVaoLuong", "LoaiTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("CongTruLuong", "LoaiTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("TinhThueThuNhap", "LoaiTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "LoaiTrichNopWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LoaiTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTrichNopViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LoaiTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTrichNopAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LoaiTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTrichNopEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LoaiTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LoaiTrichNopDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LoaiTrichNop()
		{ /* require use of factory method */ }

		public static LoaiTrichNop NewLoaiTrichNop()
		{
            LoaiTrichNop item = new LoaiTrichNop();
            item.MarkAsChild();
            return item;
		}

		public static LoaiTrichNop GetLoaiTrichNop(int maLoaiTrichNop)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LoaiTrichNop");
			return DataPortal.Fetch<LoaiTrichNop>(new Criteria(maLoaiTrichNop));
		}

		public static void DeleteLoaiTrichNop(int maLoaiTrichNop)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiTrichNop");
			DataPortal.Delete(new Criteria(maLoaiTrichNop));
		}

		public override LoaiTrichNop Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LoaiTrichNop");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LoaiTrichNop");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LoaiTrichNop");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LoaiTrichNop NewLoaiTrichNopChild()
		{
			LoaiTrichNop child = new LoaiTrichNop();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LoaiTrichNop GetLoaiTrichNop(SafeDataReader dr)
		{
			LoaiTrichNop child =  new LoaiTrichNop();
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
			public int MaLoaiTrichNop;

			public Criteria(int maLoaiTrichNop)
			{
				this.MaLoaiTrichNop = maLoaiTrichNop;
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
                cm.CommandText = "spd_SelecttblnsLoaiTrichNop";

				cm.Parameters.AddWithValue("@MaLoaiTrichNop", criteria.MaLoaiTrichNop);

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
			DataPortal_Delete(new Criteria(_maLoaiTrichNop));
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
                cm.CommandText = "spd_DeletetblnsLoaiTrichNop";

				cm.Parameters.AddWithValue("@MaLoaiTrichNop", criteria.MaLoaiTrichNop);

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
			_maLoaiTrichNop = dr.GetInt32("MaLoaiTrichNop");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenLoaiTrichNop = dr.GetString("TenLoaiTrichNop");
			_tinhVaoLuong = dr.GetBoolean("TinhVaoLuong");
			_congTruLuong = dr.GetString("CongTruLuong");
			_tinhThueThuNhap = dr.GetBoolean("TinhThueThuNhap");
			_dienGiai = dr.GetString("DienGiai");
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
                cm.CommandText = "spd_InserttblnsLoaiTrichNop";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLoaiTrichNop = (int)cm.Parameters["@MaLoaiTrichNop"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiTrichNop", _tenLoaiTrichNop);
			cm.Parameters.AddWithValue("@TinhVaoLuong", _tinhVaoLuong);
			cm.Parameters.AddWithValue("@CongTruLuong", _congTruLuong);
			cm.Parameters.AddWithValue("@TinhThueThuNhap", _tinhThueThuNhap);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaLoaiTrichNop", _maLoaiTrichNop);
			cm.Parameters["@MaLoaiTrichNop"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsLoaiTrichNop";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLoaiTrichNop", _maLoaiTrichNop);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenLoaiTrichNop", _tenLoaiTrichNop);
			cm.Parameters.AddWithValue("@TinhVaoLuong", _tinhVaoLuong);
			cm.Parameters.AddWithValue("@CongTruLuong", _congTruLuong);
			cm.Parameters.AddWithValue("@TinhThueThuNhap", _tinhThueThuNhap);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maLoaiTrichNop));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
