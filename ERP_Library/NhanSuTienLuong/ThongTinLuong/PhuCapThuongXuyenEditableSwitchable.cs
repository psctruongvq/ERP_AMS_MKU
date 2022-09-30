
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhuCapThuongXuyen : Csla.BusinessBase<PhuCapThuongXuyen>
	{
		#region Business Properties and Methods

		//declare members
		private int _maPhuCapTX = 0;
		private long _maNhanVien = 0;
		private int _maLoaiPhuCapTX = 0;
        private string _tenLoaiPhuCapTX = string.Empty;
		private short _nam = 0;
		private short _thang = 0;
		private decimal _soTien = 0;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaPhuCapTX
		{
			get
			{
				CanReadProperty("MaPhuCapTX", true);
				return _maPhuCapTX;
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

		public int MaLoaiPhuCapTX
		{
			get
			{
				CanReadProperty("MaLoaiPhuCapTX", true);
				return _maLoaiPhuCapTX;
			}
			set
			{
				CanWriteProperty("MaLoaiPhuCapTX", true);
				if (!_maLoaiPhuCapTX.Equals(value))
				{
					_maLoaiPhuCapTX = value;
					PropertyHasChanged("MaLoaiPhuCapTX");
				}
			}
		}

        public string TenLoaiPhuCapTX
        {
            get
            {
                CanReadProperty("TenLoaiPhuCapTX", true);
                _tenLoaiPhuCapTX = (LoaiPhuCapTX.GetLoaiPhuCapTX(MaLoaiPhuCapTX)).TenLoaiPhuCapTX.ToString();
                return _tenLoaiPhuCapTX;
            }
        }

		public short Nam
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

		public short Thang
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
			return _maPhuCapTX;
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
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
			//TODO: Define authorization rules in PhuCapThuongXuyen
			//AuthorizationRules.AllowRead("MaPhuCapTX", "PhuCapThuongXuyenReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "PhuCapThuongXuyenReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiPhuCapTX", "PhuCapThuongXuyenReadGroup");
			//AuthorizationRules.AllowRead("Nam", "PhuCapThuongXuyenReadGroup");
			//AuthorizationRules.AllowRead("Thang", "PhuCapThuongXuyenReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "PhuCapThuongXuyenReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "PhuCapThuongXuyenReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "PhuCapThuongXuyenWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiPhuCapTX", "PhuCapThuongXuyenWriteGroup");
			//AuthorizationRules.AllowWrite("Nam", "PhuCapThuongXuyenWriteGroup");
			//AuthorizationRules.AllowWrite("Thang", "PhuCapThuongXuyenWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "PhuCapThuongXuyenWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "PhuCapThuongXuyenWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhuCapThuongXuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapThuongXuyenViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhuCapThuongXuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapThuongXuyenAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhuCapThuongXuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapThuongXuyenEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhuCapThuongXuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapThuongXuyenDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhuCapThuongXuyen()
		{ /* require use of factory method */ }

		public static PhuCapThuongXuyen NewPhuCapThuongXuyen()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuCapThuongXuyen");
			return DataPortal.Create<PhuCapThuongXuyen>();
		}

        public static PhuCapThuongXuyen NewPhuCapThuongXuyen(long MaNhanVien)
        {
            PhuCapThuongXuyen _PhuCapThuongXuyen = new PhuCapThuongXuyen();
            _PhuCapThuongXuyen.MaNhanVien = MaNhanVien;
            return _PhuCapThuongXuyen;
        }

		public static PhuCapThuongXuyen GetPhuCapThuongXuyen(int maPhuCapTX)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhuCapThuongXuyen");
			return DataPortal.Fetch<PhuCapThuongXuyen>(new Criteria(maPhuCapTX));
		}

		public static void DeletePhuCapThuongXuyen(int maPhuCapTX)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhuCapThuongXuyen");
			DataPortal.Delete(new Criteria(maPhuCapTX));
		}

		public override PhuCapThuongXuyen Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhuCapThuongXuyen");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuCapThuongXuyen");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhuCapThuongXuyen");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhuCapThuongXuyen NewPhuCapThuongXuyenChild()
		{
			PhuCapThuongXuyen child = new PhuCapThuongXuyen();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhuCapThuongXuyen GetPhuCapThuongXuyen(SafeDataReader dr)
		{
			PhuCapThuongXuyen child =  new PhuCapThuongXuyen();
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
			public int MaPhuCapTX;

			public Criteria(int maPhuCapTX)
			{
				this.MaPhuCapTX = maPhuCapTX;
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
                cm.CommandText = "spd_SelecttblnsPhuCapThuongXuyen";

				cm.Parameters.AddWithValue("@MaPhuCapTX", criteria.MaPhuCapTX);

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
			DataPortal_Delete(new Criteria(_maPhuCapTX));
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
                cm.CommandText = "spd_DeletetblnsPhuCapThuongXuyen";

				cm.Parameters.AddWithValue("@MaPhuCapTX", criteria.MaPhuCapTX);

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
			_maPhuCapTX = dr.GetInt32("MaPhuCapTX");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maLoaiPhuCapTX = dr.GetInt32("MaLoaiPhuCapTX");
			_nam = dr.GetInt16("Nam");
			_thang = dr.GetInt16("Thang");
			_soTien = dr.GetDecimal("SoTien");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, PhuCapThuongXuyenList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, PhuCapThuongXuyenList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsPhuCapThuongXuyen";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maPhuCapTX = (int)cm.Parameters["@MaPhuCapTX"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhuCapThuongXuyenList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaLoaiPhuCapTX", _maLoaiPhuCapTX);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			if (_thang != 0)
				cm.Parameters.AddWithValue("@Thang", _thang);
			else
				cm.Parameters.AddWithValue("@Thang", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaPhuCapTX", _maPhuCapTX);
			cm.Parameters["@MaPhuCapTX"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, PhuCapThuongXuyenList parent)
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

		private void ExecuteUpdate(SqlConnection cn, PhuCapThuongXuyenList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsPhuCapThuongXuyen";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhuCapThuongXuyenList parent)
		{
			cm.Parameters.AddWithValue("@MaPhuCapTX", _maPhuCapTX);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@MaLoaiPhuCapTX", _maLoaiPhuCapTX);
			if (_nam != 0)
				cm.Parameters.AddWithValue("@Nam", _nam);
			else
				cm.Parameters.AddWithValue("@Nam", DBNull.Value);
			if (_thang != 0)
				cm.Parameters.AddWithValue("@Thang", _thang);
			else
				cm.Parameters.AddWithValue("@Thang", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maPhuCapTX));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
