using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
namespace ERP_Library
{ 
	[Serializable()] 
	public class DanhSachPhanBoThuLao : Csla.BusinessBase<DanhSachPhanBoThuLao>
	{
		#region Business Properties and Methods

		//declare members
		private int _ma = 0;
		private string _maPhanBoThuLao = string.Empty;
		private string _tenChuongTrinh = string.Empty;
		private string _tenCongViec = string.Empty;
        private string _tenBoPhan = string.Empty;
		private decimal _soTien = 0;
		private decimal _soTienNhapNhanVien = 0;
		private decimal _soTienNhapCongTacVien = 0;
		private decimal _soTienConLai = 0;
		private bool _hoanTat = false;

		[System.ComponentModel.DataObjectField(true, false)]
		public int Ma
		{
			get
			{
				CanReadProperty("Ma", true);
				return _ma;
			}
		}

		public string MaPhanBoThuLao
		{
			get
			{
				CanReadProperty("MaPhanBoThuLao", true);
				return _maPhanBoThuLao;
			}
			set
			{
				CanWriteProperty("MaPhanBoThuLao", true);
				if (value == null) value = string.Empty;
				if (!_maPhanBoThuLao.Equals(value))
				{
					_maPhanBoThuLao = value;
					PropertyHasChanged("MaPhanBoThuLao");
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

        public string TenBoPhan
        {
            get
            {
                CanReadProperty("TenBoPhan", true);
                return _tenBoPhan;
            }
            set
            {
                CanWriteProperty("TenBoPhan", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhan.Equals(value))
                {
                    _tenBoPhan = value;
                    PropertyHasChanged("TenBoPhan");
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

		public decimal SoTienNhapNhanVien
		{
			get
			{
				CanReadProperty("SoTienNhapNhanVien", true);
				return _soTienNhapNhanVien;
			}
			set
			{
				CanWriteProperty("SoTienNhapNhanVien", true);
				if (!_soTienNhapNhanVien.Equals(value))
				{
					_soTienNhapNhanVien = value;
					PropertyHasChanged("SoTienNhapNhanVien");
				}
			}
		}

		public decimal SoTienNhapCongTacVien
		{
			get
			{
				CanReadProperty("SoTienNhapCongTacVien", true);
				return _soTienNhapCongTacVien;
			}
			set
			{
                CanWriteProperty("SoTienNhapCongTacVien", true);
				if (!_soTienNhapCongTacVien.Equals(value))
				{
					_soTienNhapCongTacVien = value;
                    PropertyHasChanged("SoTienNhapCongTacVien");
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

		public bool HoanTat
		{
			get
			{
				CanReadProperty("HoanTat", true);
				return _hoanTat;

			}
			set
			{
				CanWriteProperty("HoanTat", true);
				if (!_hoanTat.Equals(value))
				{
					_hoanTat = value;
					PropertyHasChanged("HoanTat");
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
			// MaPhanBoThuLao
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaPhanBoThuLao", 50));
			//
			// TenChuongTrinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChuongTrinh", 1000));
			//
			// TenCongViec
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenCongViec", 1000));
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
			//TODO: Define authorization rules in DanhSachPhanBoThuLao
			//AuthorizationRules.AllowRead("Ma", "DanhSachPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaPhanBoThuLao", "DanhSachPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("TenChuongTrinh", "DanhSachPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("TenCongViec", "DanhSachPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "DanhSachPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("SoTienNhapNhanVien", "DanhSachPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("SoTienNhapConTacVien", "DanhSachPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("SoTienConLai", "DanhSachPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("HoanTat", "DanhSachPhanBoThuLaoReadGroup");

			//AuthorizationRules.AllowWrite("MaPhanBoThuLao", "DanhSachPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("TenChuongTrinh", "DanhSachPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("TenCongViec", "DanhSachPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "DanhSachPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienNhapNhanVien", "DanhSachPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienNhapConTacVien", "DanhSachPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienConLai", "DanhSachPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("HoanTat", "DanhSachPhanBoThuLaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DanhSachPhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachPhanBoThuLaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DanhSachPhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachPhanBoThuLaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DanhSachPhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachPhanBoThuLaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DanhSachPhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DanhSachPhanBoThuLaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DanhSachPhanBoThuLao()
		{ /* require use of factory method */ }

		public static DanhSachPhanBoThuLao NewDanhSachPhanBoThuLao(int ma)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanhSachPhanBoThuLao");
			return DataPortal.Create<DanhSachPhanBoThuLao>(new Criteria(ma));
		}

		public static DanhSachPhanBoThuLao GetDanhSachPhanBoThuLao(int ma)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DanhSachPhanBoThuLao");
			return DataPortal.Fetch<DanhSachPhanBoThuLao>(new Criteria(ma));
		}

		public static void DeleteDanhSachPhanBoThuLao(int ma)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DanhSachPhanBoThuLao");
			DataPortal.Delete(new Criteria(ma));
		}

		public override DanhSachPhanBoThuLao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DanhSachPhanBoThuLao");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanhSachPhanBoThuLao");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DanhSachPhanBoThuLao");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private DanhSachPhanBoThuLao(int ma)
		{
			this._ma = ma;
		}

		internal static DanhSachPhanBoThuLao NewDanhSachPhanBoThuLaoChild(int ma)
		{
			DanhSachPhanBoThuLao child = new DanhSachPhanBoThuLao(ma);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DanhSachPhanBoThuLao GetDanhSachPhanBoThuLao(SafeDataReader dr)
		{
			DanhSachPhanBoThuLao child =  new DanhSachPhanBoThuLao();
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
				cm.CommandText = "GetDanhSachPhanBoThuLao";

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
				cm.CommandText = "DeleteDanhSachPhanBoThuLao";

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
			//_ma = dr.GetInt32("HoanTat");
			_maPhanBoThuLao = dr.GetString("MaPhanBoThuLao");
			_tenChuongTrinh = dr.GetString("TenChuongTrinh");
			_tenCongViec = dr.GetString("TenCongViec");
            _tenBoPhan = dr.GetString("TenBoPhan");
			_soTien = dr.GetDecimal("SoTien");
			_soTienNhapNhanVien = dr.GetDecimal("SoTienNhapNhanVien");
            _soTienNhapCongTacVien = dr.GetDecimal("SoTienNhapCongTacVien");
			_soTienConLai = dr.GetDecimal("SoTienConLai");
			_hoanTat = Convert.ToBoolean(dr.GetInt32("HoanTat"));
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, DanhSachPhanBoThuLaoList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, DanhSachPhanBoThuLaoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "AddDanhSachPhanBoThuLao";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DanhSachPhanBoThuLaoList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@Ma", _ma);
			if (_maPhanBoThuLao.Length > 0)
				cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
			else
				cm.Parameters.AddWithValue("@MaPhanBoThuLao", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			if (_tenCongViec.Length > 0)
				cm.Parameters.AddWithValue("@TenCongViec", _tenCongViec);
			else
				cm.Parameters.AddWithValue("@TenCongViec", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_soTienNhapNhanVien != 0)
				cm.Parameters.AddWithValue("@SoTienNhapNhanVien", _soTienNhapNhanVien);
			else
				cm.Parameters.AddWithValue("@SoTienNhapNhanVien", DBNull.Value);
			if (_soTienNhapCongTacVien != 0)
                cm.Parameters.AddWithValue("@SoTienNhapCongTacVien", _soTienNhapCongTacVien);
			else
                cm.Parameters.AddWithValue("@SoTienNhapCongTacVien", DBNull.Value);
			if (_soTienConLai != 0)
				cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
			else
				cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
			if (_hoanTat != false)
				cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
			else
				cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, DanhSachPhanBoThuLaoList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, DanhSachPhanBoThuLaoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdateDanhSachPhanBoThuLao";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DanhSachPhanBoThuLaoList parent)
		{
			cm.Parameters.AddWithValue("@Ma", _ma);
			if (_maPhanBoThuLao.Length > 0)
				cm.Parameters.AddWithValue("@MaPhanBoThuLao", _maPhanBoThuLao);
			else
				cm.Parameters.AddWithValue("@MaPhanBoThuLao", DBNull.Value);
			if (_tenChuongTrinh.Length > 0)
				cm.Parameters.AddWithValue("@TenChuongTrinh", _tenChuongTrinh);
			else
				cm.Parameters.AddWithValue("@TenChuongTrinh", DBNull.Value);
			if (_tenCongViec.Length > 0)
				cm.Parameters.AddWithValue("@TenCongViec", _tenCongViec);
			else
				cm.Parameters.AddWithValue("@TenCongViec", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_soTienNhapNhanVien != 0)
				cm.Parameters.AddWithValue("@SoTienNhapNhanVien", _soTienNhapNhanVien);
			else
				cm.Parameters.AddWithValue("@SoTienNhapNhanVien", DBNull.Value);
			if (_soTienNhapCongTacVien != 0)
				cm.Parameters.AddWithValue("@SoTienNhapCongTacVien", _soTienNhapCongTacVien);
			else
				cm.Parameters.AddWithValue("@SoTienNhapCongTacVien", DBNull.Value);
			if (_soTienConLai != 0)
				cm.Parameters.AddWithValue("@SoTienConLai", _soTienConLai);
			else
				cm.Parameters.AddWithValue("@SoTienConLai", DBNull.Value);
			if (_hoanTat != false)
				cm.Parameters.AddWithValue("@HoanTat", _hoanTat);
			else
				cm.Parameters.AddWithValue("@HoanTat", DBNull.Value);
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


