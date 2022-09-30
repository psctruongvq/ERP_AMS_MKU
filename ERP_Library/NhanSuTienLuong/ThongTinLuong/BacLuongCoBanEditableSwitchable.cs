
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;


namespace ERP_Library
{ 
	[Serializable()] 
	public class BacLuongCoBan : Csla.BusinessBase<BacLuongCoBan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBacLuongCoBan = 0;
        private string _maQuanLy = string.Empty;
		private decimal _heSoLuong = 0;
		private int _maNgachLuongCB = 0;
        private decimal _ThoiGianNangBac = 0;
        private string _DonViThoiGian = string.Empty;
        private int _SoThuTu=0;
		private string _dienGiai = string.Empty;
        private string _TenBacLuongCoBan = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaBacLuongCoBan
		{
			get
			{
				CanReadProperty("MaBacLuongCoBan", true);
				return _maBacLuongCoBan;
			}
		}
        public string TenBacLuongCoBan
        {
            get
            {
                CanReadProperty("TenBacLuongCoBan", true);
                return _TenBacLuongCoBan;
            }
            set
            {
                CanWriteProperty("TenBacLuongCoBan", true);
                if (value == null) value = string.Empty;
                if (!_TenBacLuongCoBan.Equals(value))
                {
                    _TenBacLuongCoBan = value;
                    PropertyHasChanged("TenBacLuongCoBan");
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

		public decimal HeSoLuong
		{
			get
			{
				CanReadProperty("HeSoLuong", true);
				return _heSoLuong;
			}
			set
			{
				CanWriteProperty("HeSoLuong", true);
				if (!_heSoLuong.Equals(value))
				{
					_heSoLuong = value;
					PropertyHasChanged("HeSoLuong");
				}
			}
		}

		public int MaNgachLuongCB
		{
			get
			{
				CanReadProperty("MaNgachLuongCB", true);
				return _maNgachLuongCB;
			}
			set
			{
				CanWriteProperty("MaNgachLuongCB", true);
				if (!_maNgachLuongCB.Equals(value))
				{
					_maNgachLuongCB = value;
					PropertyHasChanged("MaNgachLuongCB");
				}
			}
		}

        public decimal ThoIGianNangBac
        {
            get
            {
                CanReadProperty("ThoIGianNangBac", true);
                return _ThoiGianNangBac;
            }
            set
            {
                CanWriteProperty("ThoIGianNangBac", true);
                if (!_ThoiGianNangBac.Equals(value))
                {
                    _ThoiGianNangBac = value;
                    PropertyHasChanged("ThoIGianNangBac");
                }
            }
        }

        public string DonViThoiGian
        {
            get
            {
                CanReadProperty("DonViThoiGian", true);
                return _DonViThoiGian;
            }
            set
            {
                CanWriteProperty("DonViThoiGian", true);
                if (value == null) value = string.Empty;
                if (!_DonViThoiGian.Equals(value))
                {
                    _DonViThoiGian = value;
                    PropertyHasChanged("DonViThoiGian");
                }
            }
        }

        public int SoThuTu
        {
            get
            {
                CanReadProperty("SoThutu", true);
                return _SoThuTu;
            }
            set
            {
                CanWriteProperty("SoThutu", true);
                if (!_SoThuTu.Equals(value))
                {
                    _SoThuTu = value;
                    PropertyHasChanged("SoThutu");
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
			return _maBacLuongCoBan;
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
			//TODO: Define authorization rules in BacLuongCoBan
			//AuthorizationRules.AllowRead("MaBacLuongCoBan", "BacLuongCoBanReadGroup");
			//AuthorizationRules.AllowRead("HeSoLuong", "BacLuongCoBanReadGroup");
			//AuthorizationRules.AllowRead("MaNgachLuongCB", "BacLuongCoBanReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "BacLuongCoBanReadGroup");

			//AuthorizationRules.AllowWrite("HeSoLuong", "BacLuongCoBanWriteGroup");
			//AuthorizationRules.AllowWrite("MaNgachLuongCB", "BacLuongCoBanWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "BacLuongCoBanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BacLuongCoBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongCoBanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BacLuongCoBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongCoBanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BacLuongCoBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongCoBanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BacLuongCoBan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BacLuongCoBanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BacLuongCoBan()
		{ /* require use of factory method */ }

		public static BacLuongCoBan NewBacLuongCoBan()
		{
            BacLuongCoBan child = new BacLuongCoBan();
            //child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
		}
        private BacLuongCoBan(int mabacluongCB, string maquanly)
        {
            this._maBacLuongCoBan = mabacluongCB;
            this._maQuanLy = maquanly;
        }

        public static BacLuongCoBan NewBacLuongCoBan(int mabacluongCB, string maquanly)
        {
            return new BacLuongCoBan(mabacluongCB, maquanly);
        }
		public static BacLuongCoBan GetBacLuongCoBan(int maBacLuongCoBan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BacLuongCoBan");
			return DataPortal.Fetch<BacLuongCoBan>(new Criteria(maBacLuongCoBan));
		}
        public static BacLuongCoBan GetBacLuongCoBanByHeSoLuong(decimal heSoLuong,int maNgachLuongCoBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BacLuongCoBan");
            return DataPortal.Fetch<BacLuongCoBan>(new CriteriaByHeSo(heSoLuong, maNgachLuongCoBan));
        }
		public static void DeleteBacLuongCoBan(int maBacLuongCoBan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BacLuongCoBan");
			DataPortal.Delete(new Criteria(maBacLuongCoBan));
		}

		public override BacLuongCoBan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BacLuongCoBan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BacLuongCoBan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BacLuongCoBan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BacLuongCoBan NewBacLuongCoBanChild()
		{
			BacLuongCoBan child = new BacLuongCoBan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BacLuongCoBan GetBacLuongCoBan(SafeDataReader dr)
		{
			BacLuongCoBan child =  new BacLuongCoBan();
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
			public int MaBacLuongCoBan;

			public Criteria(int maBacLuongCoBan)
			{
				this.MaBacLuongCoBan = maBacLuongCoBan;
			}
		}
        private class CriteriaByHeSo
		{
			public decimal heso;
            public int maNgachLuongCoBan;
            public CriteriaByHeSo(decimal heSo,int maNgachLuongCoBan)
			{
				this.heso = heSo;
                this.maNgachLuongCoBan = maNgachLuongCoBan;
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
        private void DataPortal_Fetch(object criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblnsBacLuongCoBan";

                    cm.Parameters.AddWithValue("@MaBacLuongCoBan",((Criteria) criteria).MaBacLuongCoBan);
                }
                else if (criteria is CriteriaByHeSo)
                {
                    cm.CommandText = "spd_SelecttblnsBacLuongCoBanByHeSo";

                    cm.Parameters.AddWithValue("@HeSo",((CriteriaByHeSo) criteria).heso);
                    cm.Parameters.AddWithValue("@MaNgachLuongCB", ((CriteriaByHeSo)criteria).maNgachLuongCoBan);
                }
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
			DataPortal_Delete(new Criteria(_maBacLuongCoBan));
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
                cm.CommandText = "spd_DeletetblnsBacLuongCoBan";

				cm.Parameters.AddWithValue("@MaBacLuongCoBan", criteria.MaBacLuongCoBan);

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
			_maBacLuongCoBan = dr.GetInt32("MaBacLuongCoBan");
            _maQuanLy = dr.GetString("MaQuanLy");
			_heSoLuong = dr.GetDecimal("HeSoLuong");
			_maNgachLuongCB = dr.GetInt32("MaNgachLuongCB");
            _ThoiGianNangBac = dr.GetDecimal("ThoiGianNangBac");
            _DonViThoiGian = dr.GetString("DonViThoiGian");
            _SoThuTu = dr.GetInt32("SoThuTu");
			_dienGiai = dr.GetString("DienGiai");
            _TenBacLuongCoBan = dr.GetString("TenBacLuongCoBan");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, BacLuongCoBanList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, BacLuongCoBanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsBacLuongCoBan";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maBacLuongCoBan = (int)cm.Parameters["@MaBacLuongCoBan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BacLuongCoBanList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			
			cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);		
			cm.Parameters.AddWithValue("@MaNgachLuongCB", _maNgachLuongCB);			
			cm.Parameters.AddWithValue("@DienGiai", _dienGiai);		
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            cm.Parameters.AddWithValue("@ThoiGianNangBac", _ThoiGianNangBac);
            cm.Parameters.AddWithValue("@Donvithoigian", _DonViThoiGian);
            cm.Parameters.AddWithValue("@TenBacLuongCoBan", _TenBacLuongCoBan);
            cm.Parameters.AddWithValue("@SoThuTu", _SoThuTu);
			cm.Parameters.AddWithValue("@MaBacLuongCoBan", _maBacLuongCoBan);
        
			cm.Parameters["@MaBacLuongCoBan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, BacLuongCoBanList parent)
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

		private void ExecuteUpdate(SqlConnection cn, BacLuongCoBanList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsBacLuongCoBan";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BacLuongCoBanList parent)
		{
			cm.Parameters.AddWithValue("@MaBacLuongCoBan", _maBacLuongCoBan);
            cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_heSoLuong != 0)
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			else
				cm.Parameters.AddWithValue("@HeSoLuong", DBNull.Value);
			if (_maNgachLuongCB != 0)
				cm.Parameters.AddWithValue("@MaNgachLuongCB", _maNgachLuongCB);
			else
				cm.Parameters.AddWithValue("@MaNgachLuongCB", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@ThoiGianNangBac", _ThoiGianNangBac);
            cm.Parameters.AddWithValue("@Donvithoigian", _DonViThoiGian);
            cm.Parameters.AddWithValue("@SoThuTu", _SoThuTu);
            cm.Parameters.AddWithValue("@TenBacLuongCoBan", _TenBacLuongCoBan);

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

			ExecuteDelete(cn, new Criteria(_maBacLuongCoBan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
