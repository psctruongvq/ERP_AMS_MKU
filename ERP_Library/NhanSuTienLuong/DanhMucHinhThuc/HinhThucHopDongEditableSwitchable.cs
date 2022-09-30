
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HinhThucHopDong : Csla.BusinessBase<HinhThucHopDong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHinhThucHopDong = 0;
		private string _maQuanLy = string.Empty;
		private string _tenHinhThucHopDong = string.Empty;
		private decimal _thoiHanHopDong = 0;
		private string _donViKyHan = string.Empty;
		private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaHinhThucHopDong
		{
			get
			{
				CanReadProperty("MaHinhThucHopDong", true);
				return _maHinhThucHopDong;
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

		public string TenHinhThucHopDong
		{
			get
			{
				CanReadProperty("TenHinhThucHopDong", true);
				return _tenHinhThucHopDong;
			}
			set
			{
				CanWriteProperty("TenHinhThucHopDong", true);
				if (value == null) value = string.Empty;
				if (!_tenHinhThucHopDong.Equals(value))
				{
					_tenHinhThucHopDong = value;
					PropertyHasChanged("TenHinhThucHopDong");
				}
			}
		}

		public decimal ThoiHanHopDong
		{
			get
			{
				CanReadProperty("ThoiHanHopDong", true);
				return _thoiHanHopDong;
			}
			set
			{
				CanWriteProperty("ThoiHanHopDong", true);
				if (!_thoiHanHopDong.Equals(value))
				{
					_thoiHanHopDong = value;
					PropertyHasChanged("ThoiHanHopDong");
				}
			}
		}

		public string DonViKyHan
		{
			get
			{
				CanReadProperty("DonViKyHan", true);
				return _donViKyHan;
			}
			set
			{
				CanWriteProperty("DonViKyHan", true);
				if (value == null) value = string.Empty;
				if (!_donViKyHan.Equals(value))
				{
					_donViKyHan = value;
					PropertyHasChanged("DonViKyHan");
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
			return _maHinhThucHopDong;
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
			// TenHinhThucHopDong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHinhThucHopDong", 500));
			//
			// DonViKyHan
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "DonViKyHan");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DonViKyHan", 50));
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
			//TODO: Define authorization rules in HinhThucHopDong
			//AuthorizationRules.AllowRead("MaHinhThucHopDong", "HinhThucHopDongReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "HinhThucHopDongReadGroup");
			//AuthorizationRules.AllowRead("TenHinhThucHopDong", "HinhThucHopDongReadGroup");
			//AuthorizationRules.AllowRead("ThoiHanHopDong", "HinhThucHopDongReadGroup");
			//AuthorizationRules.AllowRead("DonViKyHan", "HinhThucHopDongReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "HinhThucHopDongReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "HinhThucHopDongWriteGroup");
			//AuthorizationRules.AllowWrite("TenHinhThucHopDong", "HinhThucHopDongWriteGroup");
			//AuthorizationRules.AllowWrite("ThoiHanHopDong", "HinhThucHopDongWriteGroup");
			//AuthorizationRules.AllowWrite("DonViKyHan", "HinhThucHopDongWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "HinhThucHopDongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HinhThucHopDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucHopDongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HinhThucHopDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucHopDongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HinhThucHopDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucHopDongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HinhThucHopDong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucHopDongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HinhThucHopDong()
		{ /* require use of factory method */ }

		public static HinhThucHopDong NewHinhThucHopDong()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucHopDong");
			return DataPortal.Create<HinhThucHopDong>();
		}

		public static HinhThucHopDong GetHinhThucHopDong(int maHinhThucHopDong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HinhThucHopDong");
			return DataPortal.Fetch<HinhThucHopDong>(new Criteria(maHinhThucHopDong));
		}

		public static void DeleteHinhThucHopDong(int maHinhThucHopDong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucHopDong");
			DataPortal.Delete(new Criteria(maHinhThucHopDong));
		}

		public override HinhThucHopDong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucHopDong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucHopDong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HinhThucHopDong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HinhThucHopDong NewHinhThucHopDongChild()
		{
			HinhThucHopDong child = new HinhThucHopDong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HinhThucHopDong GetHinhThucHopDong(SafeDataReader dr)
		{
			HinhThucHopDong child =  new HinhThucHopDong();
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
			public int MaHinhThucHopDong;

			public Criteria(int maHinhThucHopDong)
			{
				this.MaHinhThucHopDong = maHinhThucHopDong;
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
                cm.CommandText = "spd_SelecttblnsHinhThucHopDong";

				cm.Parameters.AddWithValue("@MaHinhThucHopDong", criteria.MaHinhThucHopDong);

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
			DataPortal_Delete(new Criteria(_maHinhThucHopDong));
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
                cm.CommandText = "spd_DeletetblnsHinhThucHopDong";

				cm.Parameters.AddWithValue("@MaHinhThucHopDong", criteria.MaHinhThucHopDong);

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
			_maHinhThucHopDong = dr.GetInt32("MaHinhThucHopDong");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenHinhThucHopDong = dr.GetString("TenHinhThucHopDong");
			_thoiHanHopDong = dr.GetDecimal("ThoiHanHopDong");
			_donViKyHan = dr.GetString("DonViKyHan");
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
                cm.CommandText = "spd_InserttblnsHinhThucHopDong";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maHinhThucHopDong = (int)cm.Parameters["@MaHinhThucHopDong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenHinhThucHopDong.Length > 0)
				cm.Parameters.AddWithValue("@TenHinhThucHopDong", _tenHinhThucHopDong);
			else
				cm.Parameters.AddWithValue("@TenHinhThucHopDong", DBNull.Value);
			cm.Parameters.AddWithValue("@ThoiHanHopDong", _thoiHanHopDong);
			cm.Parameters.AddWithValue("@DonViKyHan", _donViKyHan);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaHinhThucHopDong", _maHinhThucHopDong);
			cm.Parameters["@MaHinhThucHopDong"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsHinhThucHopDong";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHinhThucHopDong", _maHinhThucHopDong);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_tenHinhThucHopDong.Length > 0)
				cm.Parameters.AddWithValue("@TenHinhThucHopDong", _tenHinhThucHopDong);
			else
				cm.Parameters.AddWithValue("@TenHinhThucHopDong", DBNull.Value);
			cm.Parameters.AddWithValue("@ThoiHanHopDong", _thoiHanHopDong);
			cm.Parameters.AddWithValue("@DonViKyHan", _donViKyHan);
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

			ExecuteDelete(cn, new Criteria(_maHinhThucHopDong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
