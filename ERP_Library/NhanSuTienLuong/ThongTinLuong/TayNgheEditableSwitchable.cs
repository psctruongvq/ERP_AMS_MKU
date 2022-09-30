
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TayNghe : Csla.BusinessBase<TayNghe>
	{

		#region Business Properties and Methods

		//declare members
		private int _maTayNghe = 0;
		private string _maQuanLy = string.Empty;
		private string _tayNghe = string.Empty;
        private int _Makhoiquanly = 0;
        private string _tenkhoiquanly = string.Empty;
        // _maNguoiLap=Mã nhân viên đăng nhập vào chương trình
		private long _maNguoiLap = Security.CurrentUser.Info.UserID;
        private string _tenNguoiLap = string.Empty;
		private SmartDate _ngayLap = new SmartDate(false);
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTayNghe
		{
			get
			{
				CanReadProperty("MaTayNghe", true);
				return _maTayNghe;
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

		public string TenTayNghe
		{
			get
			{
                CanReadProperty("TenTayNghe", true);
				return _tayNghe;
			}
			set
			{
                CanWriteProperty("TenTayNghe", true);
				if (value == null) value = string.Empty;
				if (!_tayNghe.Equals(value))
				{
					_tayNghe = value;
                    PropertyHasChanged("TenTayNghe");
				}
			}
		}
        public string TenKhoiQuanLy
        {
            get
            {
                CanReadProperty(true);
                return _tenkhoiquanly;
            }
            set
            {
                CanWriteProperty( true);
                if (value == null) value = string.Empty;
                if (!_tenkhoiquanly.Equals(value))
                {
                    _tenkhoiquanly = value;
                    PropertyHasChanged();
                }
            }
        }
		public long MaNguoiLap
		{
			get
			{
				CanReadProperty("MaNguoiLap", true);
                //_tenNguoiLap = NguoiSuDung.GetNguoiSuDung(_maNguoiLap).NhanVien.TenNhanVien;
				return _maNguoiLap;
			}
			set
			{
				CanWriteProperty("MaNguoiLap", true);
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

        public string TenNguoiLap
        {
            get
            {
                CanReadProperty(true);
                return _tenNguoiLap;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_tenNguoiLap.Equals(value))
                {
                    _tenNguoiLap = value;
                    PropertyHasChanged();
                }
            }
        }

        public int Makhoiquanly
        {
            get
            {
                CanReadProperty("makhoiquanly", true);
                return _Makhoiquanly;
            }
            set
            {
                CanWriteProperty("makhoiquanly", true);
                if (!_Makhoiquanly.Equals(value))
                {
                    _Makhoiquanly = value;
                    PropertyHasChanged("makhoiquanly");
                }
            }
        }

		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap.Date;
			}
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
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
			return _maTayNghe;
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
            //ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
            ////
            //// TayNghe
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "TayNghe");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TayNghe", 200));
            ////
            //// GhiChu
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 2000));
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
			//TODO: Define authorization rules in TayNghe
			//AuthorizationRules.AllowRead("MaTayNghe", "TayNgheReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "TayNgheReadGroup");
			//AuthorizationRules.AllowRead("TayNghe", "TayNgheReadGroup");
			//AuthorizationRules.AllowRead("MaNguoiLap", "TayNgheReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "TayNgheReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "TayNgheReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "TayNgheReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "TayNgheWriteGroup");
			//AuthorizationRules.AllowWrite("TayNghe", "TayNgheWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguoiLap", "TayNgheWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "TayNgheWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "TayNgheWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TayNghe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TayNgheViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TayNghe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TayNgheAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TayNghe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TayNgheEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TayNghe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TayNgheDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TayNghe()
		{ /* require use of factory method */ }

		public static TayNghe NewTayNghe()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TayNghe");
			return DataPortal.Create<TayNghe>();
		}
        public static TayNghe NewTayNghe(int _maTayNghe, string _tenTayNghe)
        {
            return new TayNghe(_maTayNghe, _tenTayNghe);
        }
        private TayNghe(int _maTayNghe, string _tenTayNghe)
        {
            this._maTayNghe = _maTayNghe;
            this._tayNghe = _tenTayNghe;
            MarkAsChild();
        }
		public static TayNghe GetTayNghe(int maTayNghe)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TayNghe");
			return DataPortal.Fetch<TayNghe>(new Criteria(maTayNghe));
		}

		public static void DeleteTayNghe(int maTayNghe)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TayNghe");
			DataPortal.Delete(new Criteria(maTayNghe));
		}

		public override TayNghe Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TayNghe");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TayNghe");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TayNghe");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TayNghe NewTayNgheChild()
		{
			TayNghe child = new TayNghe();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TayNghe GetTayNghe(SafeDataReader dr)
		{
			TayNghe child =  new TayNghe();
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
			public int MaTayNghe;

			public Criteria(int maTayNghe)
			{
				this.MaTayNghe = maTayNghe;
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
                cm.CommandText = "spd_SelecttblnsTayNghe";

				cm.Parameters.AddWithValue("@MaTayNghe", criteria.MaTayNghe);

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

				ExecuteInsert(cn, null);

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
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maTayNghe));
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
                cm.CommandText = "spd_DeletetblnsTayNghe";

				cm.Parameters.AddWithValue("@MaTayNghe", criteria.MaTayNghe);

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
			_maTayNghe = dr.GetInt32("MaTayNghe");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tayNghe = dr.GetString("TayNghe");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
            _tenNguoiLap = dr.GetString("Tennhanvien");
            _Makhoiquanly = dr.GetInt32("Makhoiquanly");
            _tenkhoiquanly = KhoiSanXuat.GetKhoiSanXuat(_Makhoiquanly).TenKhoiSanXuat;
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, TayNgheList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, TayNgheList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsTayNghe";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTayNghe = (int)cm.Parameters["@MaTayNghe"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TayNgheList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TayNghe", _tayNghe);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);

            if (_Makhoiquanly != 0)
                cm.Parameters.AddWithValue("@makhoiquanly", _Makhoiquanly);
            else
                cm.Parameters.AddWithValue("@makhoiquanly", DBNull.Value);

			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTayNghe", _maTayNghe);
			cm.Parameters["@MaTayNghe"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, TayNgheList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, TayNgheList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsTayNghe";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TayNgheList parent)
		{
			cm.Parameters.AddWithValue("@MaTayNghe", _maTayNghe);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TayNghe", _tayNghe);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_Makhoiquanly != 0)
                cm.Parameters.AddWithValue("@makhoiquanly", _Makhoiquanly);
            else
                cm.Parameters.AddWithValue("@makhoiquanly", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maTayNghe));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
