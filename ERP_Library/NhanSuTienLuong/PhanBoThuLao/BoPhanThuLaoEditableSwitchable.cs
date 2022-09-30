using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 

	[Serializable()] 
	public class BoPhanThuLao : Csla.BusinessBase<BoPhanThuLao>
	{
		#region Business Properties and Methods

		//declare members
		private int _ma = 0;
        private int _giaTri = 0;
        private int _maCongViec = 0;
        private long _maPhanBoThuLao = 0;
		private string _maQLBoPhan = string.Empty;
		private string _tenCongViec = string.Empty;
		private decimal _soTien = 0;
        private decimal _soTienCTV = 0;
        private decimal _soTienNV = 0;
        private decimal _soTienTrongDinhMuc = 0;
        private decimal _soTienNgoaiDinhMuc = 0;
        private decimal _soTienConLai = 0;
        private string _tenChuongTrinh = string.Empty;
        private string _maPhanBoQL = string.Empty;
        private Boolean _daDuyet = false;
        private string _dienGiai = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public int Ma
		{
			get
			{
				CanReadProperty("Ma", true);
				return _ma;
			}
		}

        public int GiaTri
        {
            get
            {
                CanReadProperty("GiaTri", true);
                return _giaTri;
            }
        }

        public int MaCongViec
        {
            get
            {
                CanReadProperty("MaCongViec", true);
                return _maCongViec;
            }
            set
            {
                CanWriteProperty("MaCongViec", true);
                if (!_maCongViec.Equals(value))
                {
                    _maCongViec = value;
                    PropertyHasChanged("MaCongViec");
                }
            }
        }
        public bool DaDuyet
        {
            get
            {
                CanReadProperty("DaDuyet", true);
                return _daDuyet;
            }
            set
            {
                CanWriteProperty("DaDuyet", true);
                if (!_daDuyet.Equals(value))
                {
                    _daDuyet = value;
                    PropertyHasChanged("DaDuyet");
                }
            }
        }
        public long MaPhanBoThuLao
        {
            get
            {
                CanReadProperty("MaPhanBoThuLao", true);
                return _maPhanBoThuLao;
            }
            set
            {
                CanWriteProperty("MaPhanBoThuLao", true);
                if (!_maPhanBoThuLao.Equals(value))
                {
                    _maPhanBoThuLao = value;
                    PropertyHasChanged("MaPhanBoThuLao");
                }
            }
        }

		public string MaQLBoPhan
		{
			get
			{
				CanReadProperty("MaQLBoPhan", true);
				return _maQLBoPhan;
			}
			set
			{
				CanWriteProperty("MaQLBoPhan", true);
				if (value == null) value = string.Empty;
				if (!_maQLBoPhan.Equals(value))
				{
					_maQLBoPhan = value;
					PropertyHasChanged("MaQLBoPhan");
				}
			}
		}

        public string MaPhanBoQL
        {
            get
            {
                CanReadProperty("MaPhanBoQL", true);
                return _maPhanBoQL;
            }
            set
            {
                CanWriteProperty("MaPhanBoQL", true);
                if (value == null) value = string.Empty;
                if (!_maPhanBoQL.Equals(value))
                {
                    _maPhanBoQL = value;
                    PropertyHasChanged("MaPhanBoQL");
                }
            }
        }

		public string TenCongViec
		{
			get
			{
				CanReadProperty("TenCongViec", true);
				return _tenCongViec;
			}
			set
			{
				CanWriteProperty("TenCongViec", true);
				if (value == null) value = string.Empty;
				if (!_tenCongViec.Equals(value))
				{
					_tenCongViec = value;
					PropertyHasChanged("TenCongViec");
				}
			}
		}

        public string TenChuongTrinh
        {
            get
            {
                CanReadProperty("TenChuongTrinh", true);
                return _tenChuongTrinh;
            }
            set
            {
                CanWriteProperty("TenChuongTrinh", true);
                if (value == null) value = string.Empty;
                if (!_tenChuongTrinh.Equals(value))
                {
                    _tenChuongTrinh = value;
                    PropertyHasChanged("TenChuongTrinh");
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

        public decimal SoTienTrongDinhMuc
        {
            get
            {
                CanReadProperty("SoTienTrongDinhMuc", true);
                return _soTienTrongDinhMuc;
            }
            set
            {
                CanWriteProperty("SoTienTrongDinhMuc", true);
                if (!_soTienTrongDinhMuc.Equals(value))
                {
                    _soTienTrongDinhMuc = value;
                    PropertyHasChanged("SoTienTrongDinhMuc");
                }
            }
        }
        public decimal SoTienNV
        {
            get
            {
                CanReadProperty("SoTienNV", true);
                return _soTienNV;
            }
            set
            {
                CanWriteProperty("SoTienNV", true);
                if (!_soTienNV.Equals(value))
                {
                    _soTienNV = value;
                    PropertyHasChanged("SoTienNV");
                }
            }
        }

        public decimal SoTienNgoaiDinhMuc
        {
            get
            {
                CanReadProperty("SoTienNgoaiDinhMuc", true);
                return _soTienNgoaiDinhMuc;
            }
            set
            {
                CanWriteProperty("SoTienNgoaiDinhMuc", true);
                if (!_soTienNgoaiDinhMuc.Equals(value))
                {
                    _soTienNgoaiDinhMuc = value;
                    PropertyHasChanged("SoTienNgoaiDinhMuc");
                }
            }
        }
        public decimal SoTienConLai
        {
            get
            {
                CanReadProperty("SoTienConLai", true);
                return _soTienConLai;
            }
            set
            {
                CanWriteProperty("SoTienConLai", true);
                if (!_soTienConLai.Equals(value))
                {
                    _soTienConLai = value;
                    PropertyHasChanged("SoTienConLai");
                }
            }
        }

        public decimal SoTienCTV
        {
            get
            {
                CanReadProperty("SoTienCTV", true);
                return _soTienCTV;
            }
            set
            {
                CanWriteProperty("SoTienCTV", true);
                if (!_soTienCTV.Equals(value))
                {
                    _soTienCTV = value;
                    PropertyHasChanged("SoTienCTV");
                }
            }
        }


		protected override object GetIdValue()
		{
			return _ma;
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
			// MaQLBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLBoPhan", 50));
			//
			// TenCongViec
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenCongViec", 500));
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
			//TODO: Define authorization rules in BoPhanThuLao
			//AuthorizationRules.AllowRead("Ma", "BoPhanThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaQLBoPhan", "BoPhanThuLaoReadGroup");
			//AuthorizationRules.AllowRead("TenCongViec", "BoPhanThuLaoReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "BoPhanThuLaoReadGroup");

			//AuthorizationRules.AllowWrite("MaQLBoPhan", "BoPhanThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("TenCongViec", "BoPhanThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "BoPhanThuLaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoPhanThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanThuLaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoPhanThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanThuLaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoPhanThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanThuLaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoPhanThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoPhanThuLaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoPhanThuLao()
		{ /* require use of factory method */ }

		public static BoPhanThuLao NewBoPhanThuLao(int ma)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhanThuLao");
			return DataPortal.Create<BoPhanThuLao>(new Criteria(ma));
		}

		public static BoPhanThuLao GetBoPhanThuLao(int ma)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoPhanThuLao");
			return DataPortal.Fetch<BoPhanThuLao>(new Criteria(ma));
		}

		public static void DeleteBoPhanThuLao(int ma)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoPhanThuLao");
			DataPortal.Delete(new Criteria(ma));
		}

		public override BoPhanThuLao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoPhanThuLao");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoPhanThuLao");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BoPhanThuLao");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private BoPhanThuLao(int ma)
		{
			this._ma = ma;
		}

		internal static BoPhanThuLao NewBoPhanThuLaoChild(int ma)
		{
			BoPhanThuLao child = new BoPhanThuLao(ma);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BoPhanThuLao GetBoPhanThuLao(SafeDataReader dr)
		{
			BoPhanThuLao child =  new BoPhanThuLao();
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
			public int Ma;

			public Criteria(int ma)
			{
				this.Ma = ma;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_ma = criteria.Ma;
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
				cm.CommandText = "Spd_SelectBoPhanThuLao";

				cm.Parameters.AddWithValue("@Ma", criteria.Ma);

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
			DataPortal_Delete(new Criteria(_ma));
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
				cm.CommandText = "DeleteBoPhanThuLao";

				cm.Parameters.AddWithValue("@Ma", criteria.Ma);

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
            _ma = dr.GetInt32("Ma");
            _giaTri = dr.GetInt32("GiaTri");
            _maCongViec = dr.GetInt32("MaCongViec");
            _maPhanBoThuLao = dr.GetInt64("MaPhanBoThuLao");
			_maQLBoPhan = dr.GetString("MaQLBoPhan");
			_tenCongViec = dr.GetString("TenCongViec");
			_soTien = dr.GetDecimal("SoTien");
            _tenChuongTrinh = dr.GetString("TenChuongTrinh");
            _maPhanBoQL = dr.GetString("MaPhanBoThuLaoQL");
            _soTienCTV = dr.GetDecimal("SoTienCTV");
            _soTienNV = dr.GetDecimal("SoTienNV");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            if (_giaTri == 1)
            {
                _soTienTrongDinhMuc = dr.GetDecimal("SoTienTrongDinhMuc");
                _soTienNgoaiDinhMuc = dr.GetDecimal("SoTienNgoaiDinhMuc");
            }
            _daDuyet = dr.GetBoolean("DaDuyet");
            _dienGiai = dr.GetString("DienGiai");
           
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BoPhanThuLaoList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BoPhanThuLaoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddBoPhanThuLao";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BoPhanThuLaoList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@Ma", _ma);
			if (_maQLBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@MaQLBoPhan", _maQLBoPhan);
			else
				cm.Parameters.AddWithValue("@MaQLBoPhan", DBNull.Value);
			if (_tenCongViec.Length > 0)
				cm.Parameters.AddWithValue("@TenCongViec", _tenCongViec);
			else
				cm.Parameters.AddWithValue("@TenCongViec", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BoPhanThuLaoList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BoPhanThuLaoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateBoPhanThuLao";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BoPhanThuLaoList parent)
		{
			cm.Parameters.AddWithValue("@Ma", _ma);
			if (_maQLBoPhan.Length > 0)
				cm.Parameters.AddWithValue("@MaQLBoPhan", _maQLBoPhan);
			else
				cm.Parameters.AddWithValue("@MaQLBoPhan", DBNull.Value);
			if (_tenCongViec.Length > 0)
				cm.Parameters.AddWithValue("@TenCongViec", _tenCongViec);
			else
				cm.Parameters.AddWithValue("@TenCongViec", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_ma));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}

