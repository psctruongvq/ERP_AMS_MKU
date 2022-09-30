
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangCongNhanVien : Csla.BusinessBase<BangCongNhanVien>
	{
		#region Business Properties and Methods

		//declare members
		private long _maBangCong = 0;
		private long _maNhanVien = 0;
		private string _tenPhongBan = string.Empty;
		private string _maQLNhanVien = string.Empty;
		private string _tenNhanVien = string.Empty;
		private string _ca = string.Empty;
		private string _gioIn = string.Empty;
		private string _gioOut = string.Empty;
		private SmartDate _ngayChamCong = new SmartDate(DateTime.Today);
		private int _maCongTy = 0;
		private int _maPhongban = 0;
		private int _maTo = 0;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaBangCong
		{
			get
			{
				CanReadProperty("MaBangCong", true);
				return _maBangCong;
			}
		}

		public long MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
			set
			{
				CanWriteProperty("MaNhanVien", true);
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public string TenPhongBan
		{
			get
			{
				CanReadProperty("TenPhongBan", true);
				return _tenPhongBan;
			}
			set
			{
				CanWriteProperty("TenPhongBan", true);
				if (value == null) value = string.Empty;
				if (!_tenPhongBan.Equals(value))
				{
					_tenPhongBan = value;
					PropertyHasChanged("TenPhongBan");
				}
			}
		}

		public string MaQLNhanVien
		{
			get
			{
				CanReadProperty("MaQLNhanVien", true);
				return _maQLNhanVien;
			}
			set
			{
				CanWriteProperty("MaQLNhanVien", true);
				if (value == null) value = string.Empty;
				if (!_maQLNhanVien.Equals(value))
				{
					_maQLNhanVien = value;
					PropertyHasChanged("MaQLNhanVien");
				}
			}
		}

		public string TenNhanVien
		{
			get
			{
				CanReadProperty("TenNhanVien", true);
				return _tenNhanVien;
			}
			set
			{
				CanWriteProperty("TenNhanVien", true);
				if (value == null) value = string.Empty;
				if (!_tenNhanVien.Equals(value))
				{
					_tenNhanVien = value;
					PropertyHasChanged("TenNhanVien");
				}
			}
		}

		public string Ca
		{
			get
			{
				CanReadProperty("Ca", true);
				return _ca;
			}
			set
			{
				CanWriteProperty("Ca", true);
				if (value == null) value = string.Empty;
				if (!_ca.Equals(value))
				{
					_ca = value;
					PropertyHasChanged("Ca");
				}
			}
		}

		public string GioIn
		{
			get
			{
				CanReadProperty("GioIn", true);
				return _gioIn;
			}
			set
			{
				CanWriteProperty("GioIn", true);
				if (value == null) value = string.Empty;
				if (!_gioIn.Equals(value))
				{
					_gioIn = value;
					PropertyHasChanged("GioIn");
				}
			}
		}

		public string GioOut
		{
			get
			{
				CanReadProperty("GioOut", true);
				return _gioOut;
			}
			set
			{
				CanWriteProperty("GioOut", true);
				if (value == null) value = string.Empty;
				if (!_gioOut.Equals(value))
				{
					_gioOut = value;
					PropertyHasChanged("GioOut");
				}
			}
		}

		public DateTime NgayChamCong
		{
			get
			{
				CanReadProperty("NgayChamCong", true);
				return _ngayChamCong.Date;
			}
		}

		/*public string NgayChamCongString
		{
			get
			{
				CanReadProperty("NgayChamCong", true);
				return _ngayChamCong.Text;
			}
			set
			{
				CanWriteProperty("NgayChamCong", true);
				if (value == null) value = string.Empty;
				if (!_ngayChamCong.Equals(value))
				{
					_ngayChamCong.Text = value;
					PropertyHasChanged("NgayChamCong");
				}
			}
		}*/

		public int MaCongTy
		{
			get
			{
				CanReadProperty("MaCongTy", true);
				return _maCongTy;
			}
			set
			{
				CanWriteProperty("MaCongTy", true);
				if (!_maCongTy.Equals(value))
				{
					_maCongTy = value;
					PropertyHasChanged("MaCongTy");
				}
			}
		}

		public int MaPhongban
		{
			get
			{
				CanReadProperty("MaPhongban", true);
				return _maPhongban;
			}
			set
			{
				CanWriteProperty("MaPhongban", true);
				if (!_maPhongban.Equals(value))
				{
					_maPhongban = value;
					PropertyHasChanged("MaPhongban");
				}
			}
		}

		public int MaTo
		{
			get
			{
				CanReadProperty("MaTo", true);
				return _maTo;
			}
			set
			{
				CanWriteProperty("MaTo", true);
				if (!_maTo.Equals(value))
				{
					_maTo = value;
					PropertyHasChanged("MaTo");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maBangCong;
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
			// TenPhongBan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenPhongBan", 500));
			//
			// MaQLNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLNhanVien", 50));
			//
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 500));
			//
			// Ca
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "Ca");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Ca", 20));
			//
			// GioIn
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GioIn", 20));
			//
			// GioOut
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GioOut", 20));
			//
			// NgayChamCong
			//
			//ValidationRules.AddRule(CommonRules.StringRequired, "NgayChamCongString");
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
			//TODO: Define authorization rules in BangCongNhanVien
			//AuthorizationRules.AllowRead("MaBangCong", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenPhongBan", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaQLNhanVien", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("TenNhanVien", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("Ca", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("GioIn", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("GioOut", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayChamCong", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("NgayChamCongString", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaCongTy", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaPhongban", "BangCongNhanVienReadGroup");
			//AuthorizationRules.AllowRead("MaTo", "BangCongNhanVienReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenPhongBan", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaQLNhanVien", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("TenNhanVien", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("Ca", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("GioIn", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("GioOut", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("NgayChamCongString", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongTy", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaPhongban", "BangCongNhanVienWriteGroup");
			//AuthorizationRules.AllowWrite("MaTo", "BangCongNhanVienWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangCongNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongNhanVienViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangCongNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongNhanVienAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangCongNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongNhanVienEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangCongNhanVien
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangCongNhanVienDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangCongNhanVien()
		{ /* require use of factory method */ }

		public static BangCongNhanVien NewBangCongNhanVien(long maBangCong)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangCongNhanVien");
			return DataPortal.Create<BangCongNhanVien>(new Criteria(maBangCong));
		}

		public static BangCongNhanVien GetBangCongNhanVien(long maBangCong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangCongNhanVien");
			return DataPortal.Fetch<BangCongNhanVien>(new Criteria(maBangCong));
		}

		public static void DeleteBangCongNhanVien(long maBangCong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangCongNhanVien");
			DataPortal.Delete(new Criteria(maBangCong));
		}

		public override BangCongNhanVien Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangCongNhanVien");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangCongNhanVien");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BangCongNhanVien");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private BangCongNhanVien(long maBangCong)
		{
			this._maBangCong = maBangCong;
		}

		internal static BangCongNhanVien NewBangCongNhanVienChild(long maBangCong)
		{
			BangCongNhanVien child = new BangCongNhanVien(maBangCong);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BangCongNhanVien GetBangCongNhanVien(SafeDataReader dr)
		{
			BangCongNhanVien child =  new BangCongNhanVien();
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
			public long MaBangCong;

			public Criteria(long maBangCong)
			{
				this.MaBangCong = maBangCong;
			}
		}


		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maBangCong = criteria.MaBangCong;
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
				cm.CommandText = "GetBangCongNhanVien";

				cm.Parameters.AddWithValue("@MaBangCong", criteria.MaBangCong);

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
			DataPortal_Delete(new Criteria(_maBangCong));
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
				cm.CommandText = "DeleteBangCongNhanVien";

				cm.Parameters.AddWithValue("@MaBangCong", criteria.MaBangCong);

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
			_maBangCong = dr.GetInt64("MaBangCong");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenPhongBan = dr.GetString("TenPhongBan");
			_maQLNhanVien = dr.GetString("MaQLNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_ca = dr.GetString("Ca");
			_gioIn = dr.GetString("GioIn");
			_gioOut = dr.GetString("GioOut");
			_ngayChamCong = dr.GetSmartDate("NgayChamCong", _ngayChamCong.EmptyIsMin);
			_maCongTy = dr.GetInt32("MaCongTy");
			_maPhongban = dr.GetInt32("MaPhongban");
			_maTo = dr.GetInt32("MaTo");
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
				cm.CommandText = "AddBangCongNhanVien";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaBangCong", _maBangCong);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenPhongBan.Length > 0)
				cm.Parameters.AddWithValue("@TenPhongBan", _tenPhongBan);
			else
				cm.Parameters.AddWithValue("@TenPhongBan", DBNull.Value);
			if (_maQLNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
			else
				cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@Ca", _ca);
			if (_gioIn.Length > 0)
				cm.Parameters.AddWithValue("@GioIn", _gioIn);
			else
				cm.Parameters.AddWithValue("@GioIn", DBNull.Value);
			if (_gioOut.Length > 0)
				cm.Parameters.AddWithValue("@GioOut", _gioOut);
			else
				cm.Parameters.AddWithValue("@GioOut", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayChamCong", _ngayChamCong.DBValue);
			cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
			cm.Parameters.AddWithValue("@MaPhongban", _maPhongban);
			cm.Parameters.AddWithValue("@MaTo", _maTo);
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
				cm.CommandText = "UpdateBangCongNhanVien";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaBangCong", _maBangCong);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenPhongBan.Length > 0)
				cm.Parameters.AddWithValue("@TenPhongBan", _tenPhongBan);
			else
				cm.Parameters.AddWithValue("@TenPhongBan", DBNull.Value);
			if (_maQLNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@MaQLNhanVien", _maQLNhanVien);
			else
				cm.Parameters.AddWithValue("@MaQLNhanVien", DBNull.Value);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@Ca", _ca);
			if (_gioIn.Length > 0)
				cm.Parameters.AddWithValue("@GioIn", _gioIn);
			else
				cm.Parameters.AddWithValue("@GioIn", DBNull.Value);
			if (_gioOut.Length > 0)
				cm.Parameters.AddWithValue("@GioOut", _gioOut);
			else
				cm.Parameters.AddWithValue("@GioOut", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayChamCong", _ngayChamCong.DBValue);
			cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
			cm.Parameters.AddWithValue("@MaPhongban", _maPhongban);
			cm.Parameters.AddWithValue("@MaTo", _maTo);
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

			ExecuteDelete(cn, new Criteria(_maBangCong));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
