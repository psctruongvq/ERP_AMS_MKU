
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NgachLuongCoBan : Csla.BusinessBase<NgachLuongCoBan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNgachLuongCoBan = 0;
		private string _maQuanLy = string.Empty;
		private decimal _thoiGianNangBac = 0;
		private string _donViThoiGian = string.Empty;
		private string _dienGiai = string.Empty;
        private int _Machucvu = 0;
        private string _tenchucvu = string.Empty;
        private int _MaNhomNgachLuongCoBan = 0;
        private string _TenNgachLuongCoBan = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]

        public string TenNgachLuongCoBan
        {
            get
            {
                CanReadProperty("TenNgachLuongCoBan", true);
                return _TenNgachLuongCoBan;
            }
            set
            {
                CanWriteProperty("TenNgachLuongCoBan", true);
                if (value == null) value = string.Empty;
                if (!_TenNgachLuongCoBan.Equals(value))
                {
                    _TenNgachLuongCoBan = value;
                    PropertyHasChanged("TenNgachLuongCoBan");
                }
            }
        }

        public int MaNhomNgachLuongCoBan
        {
            get
            {
                CanReadProperty("MaNhomNgachLuongCoBan", true);
                return _MaNhomNgachLuongCoBan;
            }
            set
            {
                CanWriteProperty("MaNhomNgachLuongCoBan", true);
                if (!_MaNhomNgachLuongCoBan.Equals(value))
                {
                    _MaNhomNgachLuongCoBan = value;
                    PropertyHasChanged("MaNhomNgachLuongCoBan");
                }
            }
        }
		public int MaNgachLuongCoBan
		{
			get
			{
				CanReadProperty("MaNgachLuongCoBan", true);
				return _maNgachLuongCoBan;
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

		public decimal ThoiGianNangBac
		{
			get
			{
				CanReadProperty("ThoiGianNangBac", true);
				return _thoiGianNangBac;
			}
			set
			{
				CanWriteProperty("ThoiGianNangBac", true);
				if (!_thoiGianNangBac.Equals(value))
				{
					_thoiGianNangBac = value;
					PropertyHasChanged("ThoiGianNangBac");
				}
			}
		}

		public string DonViThoiGian
		{
			get
			{
				CanReadProperty("DonViThoiGian", true);
                
				return _donViThoiGian;
			}
			set
			{
				CanWriteProperty("DonViThoiGian", true);
				if (!_donViThoiGian.Equals(value))
				{
					_donViThoiGian = value;
					PropertyHasChanged("DonViThoiGian");
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

        public string TenchucVu
        {
            get
            {
                CanReadProperty( true);
                return _tenchucvu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_tenchucvu.Equals(value))
                {
                    _tenchucvu = value;
                    PropertyHasChanged();
                }
            }
        }

        public int MaChucVu
        {
            get
            {
                CanReadProperty("Machucvu", true);
                return _Machucvu;
            }
            set
            {
                CanWriteProperty("maChucvu", true);
                if (!_Machucvu.Equals(value))
                {
                    _Machucvu = value;
                    TenchucVu = ChucVu.GetChucVu(_Machucvu).TenChucVu;
                    PropertyHasChanged("MaChucVu");
                }
            }
            
        }
 
		protected override object GetIdValue()
		{
			return _maNgachLuongCoBan;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
            //ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "MaQuanLy");
            //ValidationRules.AddRule(KiemTraTextDecimal, "ThoiGianNangBac");
        }
        private bool KiemTraTextDecimal(object target, Csla.Validation.RuleArgs e)
        {
            if (_thoiGianNangBac== 0)
            {
                e.Description = "Vui Lòng Nhập Tỷ Giá Quy Đổi Cho Loại Tiền";
                return false;
            }
            else
                return true;
        }

		private void AddCommonRules()
		{
			//
			// MaQuanLy
			//
            ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// DienGiai
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in NgachLuongCoBan
			//AuthorizationRules.AllowRead("MaNgachLuongCoBan", "NgachLuongCoBanReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "NgachLuongCoBanReadGroup");
			//AuthorizationRules.AllowRead("ThoiGianNangBac", "NgachLuongCoBanReadGroup");
			//AuthorizationRules.AllowRead("MaDonViThoiGian", "NgachLuongCoBanReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "NgachLuongCoBanReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "NgachLuongCoBanWriteGroup");
			//AuthorizationRules.AllowWrite("ThoiGianNangBac", "NgachLuongCoBanWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViThoiGian", "NgachLuongCoBanWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "NgachLuongCoBanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NgachLuongCoBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongCoBanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NgachLuongCoBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongCoBanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NgachLuongCoBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongCoBanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NgachLuongCoBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongCoBanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NgachLuongCoBan()
		{ /* require use of factory method */ }

		public static NgachLuongCoBan NewNgachLuongCoBan()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgachLuongCoBan");
			return DataPortal.Create<NgachLuongCoBan>();
		}

        private NgachLuongCoBan(int mangachluongcb, string maquanly)
        {
            this._maNgachLuongCoBan = mangachluongcb;
            this._maQuanLy = maquanly;
        }

        public static NgachLuongCoBan NewNgachLuongCoBan(int mangachluongCB, string maquanly)
        {
            return new NgachLuongCoBan(mangachluongCB, maquanly);
        }

		public static NgachLuongCoBan GetNgachLuongCoBan(int maNgachLuongCoBan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NgachLuongCoBan");
			return DataPortal.Fetch<NgachLuongCoBan>(new Criteria(maNgachLuongCoBan));
		}

		public static void DeleteNgachLuongCoBan(int maNgachLuongCoBan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NgachLuongCoBan");
			DataPortal.Delete(new Criteria(maNgachLuongCoBan));
		}

		public override NgachLuongCoBan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NgachLuongCoBan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgachLuongCoBan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NgachLuongCoBan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NgachLuongCoBan NewNgachLuongCoBanChild()
		{
			NgachLuongCoBan child = new NgachLuongCoBan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NgachLuongCoBan GetNgachLuongCoBan(SafeDataReader dr)
		{
			NgachLuongCoBan child =  new NgachLuongCoBan();
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
			public int MaNgachLuongCoBan;

			public Criteria(int maNgachLuongCoBan)
			{
				this.MaNgachLuongCoBan = maNgachLuongCoBan;
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
                cm.CommandText = "spd_SelecttblnsNgachLuongCoBan";

				cm.Parameters.AddWithValue("@MaNgachLuongCoBan", criteria.MaNgachLuongCoBan);

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
			DataPortal_Delete(new Criteria(_maNgachLuongCoBan));
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
                cm.CommandText = "spd_DeletetblnsNgachLuongCoBan";

				cm.Parameters.AddWithValue("@MaNgachLuongCoBan", criteria.MaNgachLuongCoBan);

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
			_maNgachLuongCoBan = dr.GetInt32("MaNgachLuongCoBan");
			_maQuanLy = dr.GetString("MaQuanLy");
			_thoiGianNangBac = dr.GetDecimal("ThoiGianNangBac");
			_donViThoiGian = dr.GetString("DonViThoiGian");
			_dienGiai = dr.GetString("DienGiai");
            _Machucvu = dr.GetInt32("MachucVu");
            _MaNhomNgachLuongCoBan = dr.GetInt32("MaNhomNgachLuongCoBan");
            _TenNgachLuongCoBan = dr.GetString("TenNgachLuongCoBan");
          //  _tenchucvu = dr.GetString("TenChucVu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, NgachLuongCoBanList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, NgachLuongCoBanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNgachLuongCoBan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNgachLuongCoBan = (int)cm.Parameters["@MaNgachLuongCoBan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NgachLuongCoBanList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_thoiGianNangBac != 0)
				cm.Parameters.AddWithValue("@ThoiGianNangBac", _thoiGianNangBac);
			else
				cm.Parameters.AddWithValue("@ThoiGianNangBac", DBNull.Value);
            if (_MaNhomNgachLuongCoBan != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", _MaNhomNgachLuongCoBan);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", DBNull.Value);
			if (_donViThoiGian.Length > 0)
				cm.Parameters.AddWithValue("@DonViThoiGian", _donViThoiGian);
			else
				cm.Parameters.AddWithValue("@DonViThoiGian", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNgachLuongCoBan", _maNgachLuongCoBan);
            cm.Parameters.AddWithValue("@MachucVu", _Machucvu);
            cm.Parameters.AddWithValue("@TenNgachLuongCoBan", _TenNgachLuongCoBan);
			cm.Parameters["@MaNgachLuongCoBan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, NgachLuongCoBanList parent)
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

		private void ExecuteUpdate(SqlConnection cn, NgachLuongCoBanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNgachLuongCoBan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NgachLuongCoBanList parent)
		{
            cm.Parameters.AddWithValue("@TenNgachLuongCoBan", _TenNgachLuongCoBan);
			cm.Parameters.AddWithValue("@MaNgachLuongCoBan", _maNgachLuongCoBan);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@ThoiGianNangBac", _thoiGianNangBac);
            cm.Parameters.AddWithValue("@DonViThoiGian", _donViThoiGian);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@Machucvu", _Machucvu);
            if (_MaNhomNgachLuongCoBan != 0)
                cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", _MaNhomNgachLuongCoBan);
            else
                cm.Parameters.AddWithValue("@MaNhomNgachLuongCoBan", DBNull.Value);
			
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

			ExecuteDelete(cn, new Criteria(_maNgachLuongCoBan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
