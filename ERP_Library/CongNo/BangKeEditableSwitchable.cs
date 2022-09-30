
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BangKe : Csla.BusinessBase<BangKe>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChungTu = 0;
		private string _soChungTu = string.Empty;
		private int _ngay = 0;
		private int _thang = 0;
		private int _nam = 0;
		private string _tKNo = string.Empty;
		private string _tKCo = string.Empty;
		private string _dienGiai = string.Empty;
		private decimal _soTien = 0;
		private decimal _thanhTien = 0;
		private string _vietBangChu = string.Empty;
		private string _tenDoiTuong = string.Empty;
		private string _diaChi = string.Empty;
		private string _maQuanLy = string.Empty;
        private int _soChungTuKemTheo = 0;

		//declare child member(s)
		//private f _a = f.Newf();

		public long MaChungTu
		{
			get
			{
				CanReadProperty("MaChungTu", true);
				return _maChungTu;
			}
			set
			{
				CanWriteProperty("MaChungTu", true);
				if (!_maChungTu.Equals(value))
				{
					_maChungTu = value;
					PropertyHasChanged("MaChungTu");
				}
			}
		}

		[System.ComponentModel.DataObjectField(true, false)]
		public string SoChungTu
		{
			get
			{
				CanReadProperty("SoChungTu", true);
				return _soChungTu;
			}
		}

		public int Ngay
		{
			get
			{
				CanReadProperty("Ngay", true);
				return _ngay;
			}
			set
			{
				CanWriteProperty("Ngay", true);
				if (!_ngay.Equals(value))
				{
					_ngay = value;
					PropertyHasChanged("Ngay");
				}
			}
		}

		public int Thang
		{
			get
			{
				CanReadProperty("Thang", true);
				return _thang;
			}
			set
			{
				CanWriteProperty("Thang", true);
				if (!_thang.Equals(value))
				{
					_thang = value;
					PropertyHasChanged("Thang");
				}
			}
		}

		public int Nam
		{
			get
			{
				CanReadProperty("Nam", true);
				return _nam;
			}
			set
			{
				CanWriteProperty("Nam", true);
				if (!_nam.Equals(value))
				{
					_nam = value;
					PropertyHasChanged("Nam");
				}
			}
		}

		public string TKNo
		{
			get
			{
				CanReadProperty("TKNo", true);
				return _tKNo;
			}
			set
			{
				CanWriteProperty("TKNo", true);
				if (value == null) value = string.Empty;
				if (!_tKNo.Equals(value))
				{
					_tKNo = value;
					PropertyHasChanged("TKNo");
				}
			}
		}

		public string TKCo
		{
			get
			{
				CanReadProperty("TKCo", true);
				return _tKCo;
			}
			set
			{
				CanWriteProperty("TKCo", true);
				if (value == null) value = string.Empty;
				if (!_tKCo.Equals(value))
				{
					_tKCo = value;
					PropertyHasChanged("TKCo");
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

		public decimal SoTien
		{
			get
			{
				CanReadProperty("SoTien", true);
				return _soTien;
			}
			set
			{
				CanWriteProperty("SoTien", true);
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

		public decimal ThanhTien
		{
			get
			{
				CanReadProperty("ThanhTien", true);
				return _thanhTien;
			}
			set
			{
				CanWriteProperty("ThanhTien", true);
				if (!_thanhTien.Equals(value))
				{
					_thanhTien = value;
					PropertyHasChanged("ThanhTien");
				}
			}
		}

		public string VietBangChu
		{
			get
			{
				CanReadProperty("VietBangChu", true);
				return _vietBangChu;
			}
			set
			{
				CanWriteProperty("VietBangChu", true);
				if (value == null) value = string.Empty;
				if (!_vietBangChu.Equals(value))
				{
					_vietBangChu = value;
					PropertyHasChanged("VietBangChu");
				}
			}
		}

		public string TenDoiTuong
		{
			get
			{
				CanReadProperty("TenDoiTuong", true);
				return _tenDoiTuong;
			}
			set
			{
				CanWriteProperty("TenDoiTuong", true);
				if (value == null) value = string.Empty;
				if (!_tenDoiTuong.Equals(value))
				{
					_tenDoiTuong = value;
					PropertyHasChanged("TenDoiTuong");
				}
			}
		}

		public string DiaChi
		{
			get
			{
				CanReadProperty("DiaChi", true);
				return _diaChi;
			}
			set
			{
				CanWriteProperty("DiaChi", true);
				if (value == null) value = string.Empty;
				if (!_diaChi.Equals(value))
				{
					_diaChi = value;
					PropertyHasChanged("DiaChi");
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
        public int SoChungTuKemTheo
        {
            get
            {
                CanReadProperty("SoChungTuKemTheo", true);
                return _soChungTuKemTheo;
            }
            set
            {
                CanWriteProperty("SoChungTuKemTheo", true);
                if (!_soChungTuKemTheo.Equals(value))
                {
                    _soChungTuKemTheo = value;
                    PropertyHasChanged("SoChungTuKemTheo");
                }
            }
        }
	
 
		public override bool IsValid
		{
            get { return base.IsValid; }
		}

		public override bool IsDirty
		{
            get { return base.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _soChungTu;
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
			// SoChungTu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoChungTu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
			//
			// TKNo
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TKNo");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TKNo", 50));
			//
			// TKCo
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TKCo");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TKCo", 50));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
			//
			// VietBangChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("VietBangChu", 1000));
			//
			// TenDoiTuong
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDoiTuong", 50));
			//
			// DiaChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 100));
			//
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
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
			//TODO: Define authorization rules in BangKe
			//AuthorizationRules.AllowRead("a", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("MaChungTu", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("SoChungTu", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("Ngay", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("Thang", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("Nam", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("TKNo", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("TKCo", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("ThanhTien", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("VietBangChu", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("TenDoiTuong", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("DiaChi", "BangKeReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "BangKeReadGroup");

			//AuthorizationRules.AllowWrite("MaChungTu", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("Ngay", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("Thang", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("Nam", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("TKNo", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("TKCo", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTien", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("VietBangChu", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("TenDoiTuong", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChi", "BangKeWriteGroup");
			//AuthorizationRules.AllowWrite("MaQuanLy", "BangKeWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BangKe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangKeViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BangKe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangKeAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BangKe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangKeEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BangKe
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BangKeDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BangKe()
		{ /* require use of factory method */ }

		public static BangKe NewBangKe(long machungtu)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangKe");
            return DataPortal.Create<BangKe>(new Criteria(machungtu));
		}

		public static BangKe GetBangKe(long machungtu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BangKe");
            return DataPortal.Fetch<BangKe>(new Criteria(machungtu));
		}

		public static void DeleteBangKe(long machungtu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangKe");
            DataPortal.Delete(new Criteria(machungtu));
		}

		public override BangKe Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BangKe");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BangKe");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BangKe");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private BangKe(string soChungTu)
		{
			this._soChungTu = soChungTu;
		}

		internal static BangKe NewBangKeChild(string soChungTu)
		{
			BangKe child = new BangKe(soChungTu);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BangKe GetBangKe(SafeDataReader dr)
		{
			BangKe child =  new BangKe();
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
			public long machungtu;

			public Criteria(long MaChungTu)
			{
                this.machungtu = MaChungTu;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maChungTu = criteria.machungtu;
			//ValidationRules.CheckRules();
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
                cm.CommandText = "spd_BaoCaoChungTuGhiSo";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.machungtu);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					//ValidationRules.CheckRules();

					//load child object(s)
					//FetchChildren(dr);
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
			DataPortal_Delete(new Criteria(_maChungTu));
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
				cm.CommandText = "DeleteBangKe";

				cm.Parameters.AddWithValue("@SoChungTu", criteria.machungtu);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			//ValidationRules.CheckRules();

			//load child object(s)
			//FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maChungTu = dr.GetInt64("MaChungTu");
			_soChungTu = dr.GetString("SoChungTu");
			_ngay = dr.GetInt32("Ngay");
			_thang = dr.GetInt32("Thang");
			_nam = dr.GetInt32("Nam");
			_tKNo = dr.GetString("TKNo");
			_tKCo = dr.GetString("TKCo");
			_dienGiai = dr.GetString("DienGiai");
			_soTien = dr.GetDecimal("SoTien");
			_thanhTien = dr.GetDecimal("ThanhTien");
			_vietBangChu = dr.GetString("VietBangChu");
			_tenDoiTuong = dr.GetString("TenDoiTuong");
			_diaChi = dr.GetString("DiaChi");
			_maQuanLy = dr.GetString("MaQuanLy");
            _soChungTuKemTheo = dr.GetInt32("SoChungTuKemTheo");
		}

		private void FetchChildren(SafeDataReader dr)
		{
			dr.NextResult();
			//_a = f.Getf(dr);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, BangKeList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, BangKeList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddBangKe";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BangKeList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			if (_ngay != 0)
				cm.Parameters.AddWithValue("@Ngay", _ngay);
			else
				cm.Parameters.AddWithValue("@Ngay", DBNull.Value);
			if (_thang != 0)
				cm.Parameters.AddWithValue("@Thang", _thang);
			else
				cm.Parameters.AddWithValue("@Thang", DBNull.Value);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			cm.Parameters.AddWithValue("@TKNo", _tKNo);
			cm.Parameters.AddWithValue("@TKCo", _tKCo);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_vietBangChu.Length > 0)
				cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
			else
				cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
			if (_tenDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
			else
				cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, BangKeList parent)
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

		private void ExecuteUpdate(SqlConnection cn, BangKeList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateBangKe";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BangKeList parent)
		{
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			if (_ngay != 0)
				cm.Parameters.AddWithValue("@Ngay", _ngay);
			else
				cm.Parameters.AddWithValue("@Ngay", DBNull.Value);
			if (_thang != 0)
				cm.Parameters.AddWithValue("@Thang", _thang);
			else
				cm.Parameters.AddWithValue("@Thang", DBNull.Value);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			cm.Parameters.AddWithValue("@TKNo", _tKNo);
			cm.Parameters.AddWithValue("@TKCo", _tKCo);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_vietBangChu.Length > 0)
				cm.Parameters.AddWithValue("@VietBangChu", _vietBangChu);
			else
				cm.Parameters.AddWithValue("@VietBangChu", DBNull.Value);
			if (_tenDoiTuong.Length > 0)
				cm.Parameters.AddWithValue("@TenDoiTuong", _tenDoiTuong);
			else
				cm.Parameters.AddWithValue("@TenDoiTuong", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
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

			//ExecuteDelete(cn, new Criteria(_soChungTu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
