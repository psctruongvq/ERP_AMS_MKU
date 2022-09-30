using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongThucKetChuyenChinhThuc : Csla.BusinessBase<CongThucKetChuyenChinhThuc>
	{
		#region Business Properties and Methods

		//declare members
		private int _maCongThucKC = 0;
        private int _maCongThuc = 0;
		private long _maChungTu = 0;
		private int _soTT = 0;
		private int _maTaiKhoanKC = 0;
		private string _soHieuTaiKhoan = string.Empty;
		private int _maLoaiKetChuyen = 0;
		private int _maTaiKhoanNhanKC = 0;
		private byte _ketChuyenNoCo = 0;
        private int _maBoPhan = 0;
        private int _maNguoiLap = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaCongThucKC
		{
			get
			{
				CanReadProperty("MaCongThucKC", true);
				return _maCongThucKC;
			}
		}
        public int MaCongThuc
        {
            get
            {
                CanReadProperty("MaCongThuc", true);
                return _maCongThuc;
            }
            set
            {
                CanWriteProperty("MaCongThuc", true);
                if (!_maCongThuc.Equals(value))
                {
                    _maCongThuc = value;
                    PropertyHasChanged("MaCongThuc");
                }
            }
        }
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
        public int MaNguoiLap
        {
            get
            {
                CanReadProperty("MaNguoiLap", true);
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
        public int MaBoPhan
        {
            get
            {
                CanReadProperty("MaBoPhan", true);
                return _maBoPhan;
            }
            set
            {
                CanWriteProperty("MaBoPhan", true);
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }
		public int SoTT
		{
			get
			{
				CanReadProperty("SoTT", true);
				return _soTT;
			}
			set
			{
				CanWriteProperty("SoTT", true);
				if (!_soTT.Equals(value))
				{
					_soTT = value;
					PropertyHasChanged("SoTT");
				}
			}
		}

		public int MaTaiKhoanKC
		{
			get
			{
				CanReadProperty("MaTaiKhoanKC", true);
				return _maTaiKhoanKC;
			}
			set
			{
				CanWriteProperty("MaTaiKhoanKC", true);
				if (!_maTaiKhoanKC.Equals(value))
				{
					_maTaiKhoanKC = value;
					PropertyHasChanged("MaTaiKhoanKC");
				}
			}
		}

		public string SoHieuTaiKhoan
		{
			get
			{
				CanReadProperty("SoHieuTaiKhoan", true);
				return _soHieuTaiKhoan;
			}
			set
			{
				CanWriteProperty("SoHieuTaiKhoan", true);
				if (value == null) value = string.Empty;
				if (!_soHieuTaiKhoan.Equals(value))
				{
					_soHieuTaiKhoan = value;
					PropertyHasChanged("SoHieuTaiKhoan");
				}
			}
		}

		public int MaLoaiKetChuyen
		{
			get
			{
				CanReadProperty("MaLoaiKetChuyen", true);
				return _maLoaiKetChuyen;
			}
			set
			{
				CanWriteProperty("MaLoaiKetChuyen", true);
				if (!_maLoaiKetChuyen.Equals(value))
				{
					_maLoaiKetChuyen = value;
					PropertyHasChanged("MaLoaiKetChuyen");
				}
			}
		}

		public int MaTaiKhoanNhanKC
		{
			get
			{
				CanReadProperty("MaTaiKhoanNhanKC", true);
				return _maTaiKhoanNhanKC;
			}
			set
			{
				CanWriteProperty("MaTaiKhoanNhanKC", true);
				if (!_maTaiKhoanNhanKC.Equals(value))
				{
					_maTaiKhoanNhanKC = value;
					PropertyHasChanged("MaTaiKhoanNhanKC");
				}
			}
		}

		public byte KetChuyenNoCo
		{
			get
			{
				CanReadProperty("KetChuyenNoCo", true);
				return _ketChuyenNoCo;
			}
			set
			{
				CanWriteProperty("KetChuyenNoCo", true);
				if (!_ketChuyenNoCo.Equals(value))
				{
					_ketChuyenNoCo = value;
					PropertyHasChanged("KetChuyenNoCo");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maCongThucKC;
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
			// SoHieuTaiKhoan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoHieuTaiKhoan", 50));
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
			//TODO: Define authorization rules in CongThucKetChuyenChinhThuc
			//AuthorizationRules.AllowRead("MaCongThucKC", "CongThucKetChuyenChinhThucReadGroup");
			//AuthorizationRules.AllowRead("MaChungTu", "CongThucKetChuyenChinhThucReadGroup");
			//AuthorizationRules.AllowRead("SoTT", "CongThucKetChuyenChinhThucReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanKC", "CongThucKetChuyenChinhThucReadGroup");
			//AuthorizationRules.AllowRead("SoHieuTaiKhoan", "CongThucKetChuyenChinhThucReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiKetChuyen", "CongThucKetChuyenChinhThucReadGroup");
			//AuthorizationRules.AllowRead("MaTaiKhoanNhanKC", "CongThucKetChuyenChinhThucReadGroup");
			//AuthorizationRules.AllowRead("KetChuyenNoCo", "CongThucKetChuyenChinhThucReadGroup");

			//AuthorizationRules.AllowWrite("MaChungTu", "CongThucKetChuyenChinhThucWriteGroup");
			//AuthorizationRules.AllowWrite("SoTT", "CongThucKetChuyenChinhThucWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoanKC", "CongThucKetChuyenChinhThucWriteGroup");
			//AuthorizationRules.AllowWrite("SoHieuTaiKhoan", "CongThucKetChuyenChinhThucWriteGroup");
			//AuthorizationRules.AllowWrite("MaLoaiKetChuyen", "CongThucKetChuyenChinhThucWriteGroup");
			//AuthorizationRules.AllowWrite("MaTaiKhoanNhanKC", "CongThucKetChuyenChinhThucWriteGroup");
			//AuthorizationRules.AllowWrite("KetChuyenNoCo", "CongThucKetChuyenChinhThucWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in CongThucKetChuyenChinhThuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThucKetChuyenChinhThucViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in CongThucKetChuyenChinhThuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThucKetChuyenChinhThucAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in CongThucKetChuyenChinhThuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThucKetChuyenChinhThucEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in CongThucKetChuyenChinhThuc
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("CongThucKetChuyenChinhThucDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private CongThucKetChuyenChinhThuc()
        { /* require use of factory method */ MarkAsChild();  }

		public static CongThucKetChuyenChinhThuc NewCongThucKetChuyenChinhThuc()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CongThucKetChuyenChinhThuc");
			return DataPortal.Create<CongThucKetChuyenChinhThuc>();
		}

		public static CongThucKetChuyenChinhThuc GetCongThucKetChuyenChinhThuc(int maCongThucKC)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a CongThucKetChuyenChinhThuc");
			return DataPortal.Fetch<CongThucKetChuyenChinhThuc>(new Criteria(maCongThucKC));
		}

		public static void DeleteCongThucKetChuyenChinhThuc(int maCongThucKC)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CongThucKetChuyenChinhThuc");
			DataPortal.Delete(new Criteria(maCongThucKC));
		}

		public override CongThucKetChuyenChinhThuc Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a CongThucKetChuyenChinhThuc");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a CongThucKetChuyenChinhThuc");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a CongThucKetChuyenChinhThuc");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CongThucKetChuyenChinhThuc NewCongThucKetChuyenChinhThucChild()
		{
			CongThucKetChuyenChinhThuc child = new CongThucKetChuyenChinhThuc();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CongThucKetChuyenChinhThuc GetCongThucKetChuyenChinhThuc(SafeDataReader dr)
		{
			CongThucKetChuyenChinhThuc child =  new CongThucKetChuyenChinhThuc();
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
			public int MaCongThucKC;

			public Criteria(int maCongThucKC)
			{
				this.MaCongThucKC = maCongThucKC;
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
                cm.CommandText = "spd_SelecttblCongThucKetChuyenChinhThuc";

				cm.Parameters.AddWithValue("@MaCongThucKC", criteria.MaCongThucKC);

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
			SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr, null);

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
						ExecuteUpdate(tr, null);
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
			DataPortal_Delete(new Criteria(_maCongThucKC));
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
                cm.CommandText = "spd_DeletetblCongThucKetChuyenChinhThuc";

				cm.Parameters.AddWithValue("@MaCongThucKC", criteria.MaCongThucKC);

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
			_maCongThucKC = dr.GetInt32("MaCongThucKC");
			_maChungTu = dr.GetInt64("MaChungTu");
			_soTT = dr.GetInt32("SoTT");
			_maTaiKhoanKC = dr.GetInt32("MaTaiKhoanKC");
			_soHieuTaiKhoan = dr.GetString("SoHieuTaiKhoan");
			_maLoaiKetChuyen = dr.GetInt32("MaLoaiKetChuyen");
			_maTaiKhoanNhanKC = dr.GetInt32("MaTaiKhoanNhanKC");
			_ketChuyenNoCo = dr.GetByte("KetChuyenNoCo");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNguoiLap = dr.GetInt32("MaBoPhan");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, CongThucKetChuyenChinhThucList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, CongThucKetChuyenChinhThucList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCongThucKetChuyenChinhThuc";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maCongThucKC = (int)cm.Parameters["@MaCongThucKC"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CongThucKetChuyenChinhThucList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			if (_soTT != 0)
				cm.Parameters.AddWithValue("@SoTT", _soTT);
			else
				cm.Parameters.AddWithValue("@SoTT", DBNull.Value);
			if (_maTaiKhoanKC != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoanKC", _maTaiKhoanKC);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoanKC", DBNull.Value);
			if (_soHieuTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@SoHieuTaiKhoan", _soHieuTaiKhoan);
			else
				cm.Parameters.AddWithValue("@SoHieuTaiKhoan", DBNull.Value);
			if (_maLoaiKetChuyen != 0)
				cm.Parameters.AddWithValue("@MaLoaiKetChuyen", _maLoaiKetChuyen);
			else
				cm.Parameters.AddWithValue("@MaLoaiKetChuyen", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTaiKhoanNhanKC", _maTaiKhoanNhanKC);
			if (_ketChuyenNoCo != 0)
				cm.Parameters.AddWithValue("@KetChuyenNoCo", _ketChuyenNoCo);
			else
				cm.Parameters.AddWithValue("@KetChuyenNoCo", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongThucKC", _maCongThucKC);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters["@MaCongThucKC"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, CongThucKetChuyenChinhThucList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, CongThucKetChuyenChinhThucList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCongThucKetChuyenChinhThuc";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CongThucKetChuyenChinhThucList parent)
		{
			cm.Parameters.AddWithValue("@MaCongThucKC", _maCongThucKC);
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			if (_soTT != 0)
				cm.Parameters.AddWithValue("@SoTT", _soTT);
			else
				cm.Parameters.AddWithValue("@SoTT", DBNull.Value);
			if (_maTaiKhoanKC != 0)
				cm.Parameters.AddWithValue("@MaTaiKhoanKC", _maTaiKhoanKC);
			else
				cm.Parameters.AddWithValue("@MaTaiKhoanKC", DBNull.Value);
			if (_soHieuTaiKhoan.Length > 0)
				cm.Parameters.AddWithValue("@SoHieuTaiKhoan", _soHieuTaiKhoan);
			else
				cm.Parameters.AddWithValue("@SoHieuTaiKhoan", DBNull.Value);
			if (_maLoaiKetChuyen != 0)
				cm.Parameters.AddWithValue("@MaLoaiKetChuyen", _maLoaiKetChuyen);
			else
				cm.Parameters.AddWithValue("@MaLoaiKetChuyen", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTaiKhoanNhanKC", _maTaiKhoanNhanKC);
			if (_ketChuyenNoCo != 0)
				cm.Parameters.AddWithValue("@KetChuyenNoCo", _ketChuyenNoCo);
			else
				cm.Parameters.AddWithValue("@KetChuyenNoCo", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maCongThucKC));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
