using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTuCu : Csla.BusinessBase<ChungTuCu>
	{
		#region Business Properties and Methods

		//declare members
		private string _maChungTuCu = string.Empty;
		private string _soChungTu = string.Empty;
		private SmartDate _ngayChungTu = new SmartDate(false);
		private string _loaiChungTu = string.Empty;
		private string _dienGiai = string.Empty;
		private decimal _soTien = 0;
		private decimal _tyGia = 0;
		private decimal _thanhTien = 0;
		private string _maKH = string.Empty;
		private string _tenKH = string.Empty;
		private string _noTK = string.Empty;
		private string _coTK = string.Empty;
		private string _muc = string.Empty;
		[System.ComponentModel.DataObjectField(true, false)]
		public string MaChungTuCu
		{
			get
			{
				CanReadProperty("MaChungTuCu", true);
				return _maChungTuCu;
			}
		}

		public string SoChungTu
		{
			get
			{
				CanReadProperty("SoChungTu", true);
				return _soChungTu;
			}
			set
			{
				CanWriteProperty("SoChungTu", true);
				if (value == null) value = string.Empty;
				if (!_soChungTu.Equals(value))
				{
					_soChungTu = value;
					PropertyHasChanged("SoChungTu");
				}
			}
		}

		public DateTime NgayChungTu
		{
			get
			{
				CanReadProperty("NgayChungTu", true);
				return _ngayChungTu.Date;
			}
		}

		public string NgayChungTuString
		{
			get
			{
				CanReadProperty("NgayChungTuString", true);
				return _ngayChungTu.Text;
			}
			set
			{
				CanWriteProperty("NgayChungTuString", true);
				if (value == null) value = string.Empty;
				if (!_ngayChungTu.Equals(value))
				{
					_ngayChungTu.Text = value;
					PropertyHasChanged("NgayChungTuString");
				}
			}
		}

		public string LoaiChungTu
		{
			get
			{
				CanReadProperty("LoaiChungTu", true);
				return _loaiChungTu;
			}
			set
			{
				CanWriteProperty("LoaiChungTu", true);
				if (value == null) value = string.Empty;
				if (!_loaiChungTu.Equals(value))
				{
					_loaiChungTu = value;
					PropertyHasChanged("LoaiChungTu");
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

		public decimal TyGia
		{
			get
			{
				CanReadProperty("TyGia", true);
				return _tyGia;
			}
			set
			{
				CanWriteProperty("TyGia", true);
				if (!_tyGia.Equals(value))
				{
					_tyGia = value;
					PropertyHasChanged("TyGia");
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

		public string MaKH
		{
			get
			{
				CanReadProperty("MaKH", true);
				return _maKH;
			}
			set
			{
				CanWriteProperty("MaKH", true);
				if (value == null) value = string.Empty;
				if (!_maKH.Equals(value))
				{
					_maKH = value;
					PropertyHasChanged("MaKH");
				}
			}
		}

		public string TenKH
		{
			get
			{
				CanReadProperty("TenKH", true);
				return _tenKH;
			}
			set
			{
				CanWriteProperty("TenKH", true);
				if (value == null) value = string.Empty;
				if (!_tenKH.Equals(value))
				{
					_tenKH = value;
					PropertyHasChanged("TenKH");
				}
			}
		}

		public string NoTK
		{
			get
			{
				CanReadProperty("NoTK", true);
				return _noTK;
			}
			set
			{
				CanWriteProperty("NoTK", true);
				if (value == null) value = string.Empty;
				if (!_noTK.Equals(value))
				{
					_noTK = value;
					PropertyHasChanged("NoTK");
				}
			}
		}

		public string CoTK
		{
			get
			{
				CanReadProperty("CoTK", true);
				return _coTK;
			}
			set
			{
				CanWriteProperty("CoTK", true);
				if (value == null) value = string.Empty;
				if (!_coTK.Equals(value))
				{
					_coTK = value;
					PropertyHasChanged("CoTK");
				}
			}
		}

		public string Muc
		{
			get
			{
				CanReadProperty("Muc", true);
				return _muc;
			}
			set
			{
				CanWriteProperty("Muc", true);
				if (value == null) value = string.Empty;
				if (!_muc.Equals(value))
				{
					_muc = value;
					PropertyHasChanged("Muc");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChungTuCu;
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
			// MaChungTuCu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaChungTuCu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaChungTuCu", 50));
			//
			// SoChungTu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
			//
			// LoaiChungTu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LoaiChungTu", 200));
			//
			// MaKH
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaKH", 50));
			//
			// TenKH
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenKH", 1000));
			//
			// NoTK
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoTK", 100));
			//
			// CoTK
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CoTK", 100));
			//
			// Muc
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Muc", 50));
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
			//TODO: Define authorization rules in ChungTuCu
			//AuthorizationRules.AllowRead("MaChungTuCu", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("SoChungTu", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("NgayChungTu", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("NgayChungTuString", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("LoaiChungTu", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("TyGia", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("ThanhTien", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("MaKH", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("TenKH", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("NoTK", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("CoTK", "ChungTuCuReadGroup");
			//AuthorizationRules.AllowRead("Muc", "ChungTuCuReadGroup");

			//AuthorizationRules.AllowWrite("SoChungTu", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("NgayChungTuString", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("LoaiChungTu", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("TyGia", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhTien", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("MaKH", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("TenKH", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("NoTK", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("CoTK", "ChungTuCuWriteGroup");
			//AuthorizationRules.AllowWrite("Muc", "ChungTuCuWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChungTuCu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTuCuViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChungTuCu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTuCuAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChungTuCu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTuCuEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChungTuCu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChungTuCuDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChungTuCu()
		{ /* require use of factory method */ }

		public static ChungTuCu NewChungTuCu(string maChungTuCu)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTuCu");
			return DataPortal.Create<ChungTuCu>(new Criteria(maChungTuCu));
		}

		public static ChungTuCu GetChungTuCu(string maChungTuCu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChungTuCu");
			return DataPortal.Fetch<ChungTuCu>(new Criteria(maChungTuCu));
		}

        public static ChungTuCu GetChungTuMoiByMaChungTu(long maChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuCu");
            return DataPortal.Fetch<ChungTuCu>(new CriteriaByMaChungTu(maChungTu));
        }

		public static void DeleteChungTuCu(string maChungTuCu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChungTuCu");
			DataPortal.Delete(new Criteria(maChungTuCu));
		}

		public override ChungTuCu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChungTuCu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChungTuCu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChungTuCu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChungTuCu GetChungTuCu(SafeDataReader dr)
		{
			ChungTuCu child =  new ChungTuCu();
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
			public string MaChungTuCu;

			public Criteria(string maChungTuCu)
			{
				this.MaChungTuCu = maChungTuCu;
			}
		}
        private class CriteriaByMaChungTu
        {
            public long MaChungTu;

            public CriteriaByMaChungTu(long maChungTu)
            {
                this.MaChungTu = maChungTu;
            }
        }

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maChungTuCu = criteria.MaChungTuCu;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;

                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblChungTuCu";
                    cm.Parameters.AddWithValue("@MaChungTuCu",((Criteria)criteria).MaChungTuCu);
                }
                if (criteria is CriteriaByMaChungTu)
                {
                    cm.CommandText = "spd_SelecttblChungTuNewByMaChungTu";
                    cm.Parameters.AddWithValue("@MaChungTu", ((CriteriaByMaChungTu)criteria).MaChungTu);
                }

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
			DataPortal_Delete(new Criteria(_maChungTuCu));
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
                cm.CommandText = "spd_DeletetblChungTuCu";

				cm.Parameters.AddWithValue("@MaChungTuCu", criteria.MaChungTuCu);

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
			_maChungTuCu = dr.GetString("MaChungTuCu");
			_soChungTu = dr.GetString("SoChungTu");
			_ngayChungTu = dr.GetSmartDate("NgayChungTu", _ngayChungTu.EmptyIsMin);
			_loaiChungTu = dr.GetString("LoaiChungTu");
			_dienGiai = dr.GetString("DienGiai");
			_soTien = dr.GetDecimal("SoTien");
			_tyGia = dr.GetDecimal("TyGia");
			_thanhTien = dr.GetDecimal("ThanhTien");
			_maKH = dr.GetString("MaKH");
			_tenKH = dr.GetString("TenKH");
			_noTK = dr.GetString("NoTK");
			_coTK = dr.GetString("CoTK");
			_muc = dr.GetString("Muc");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ChungTuCuList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ChungTuCuList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblChungTuCu";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChungTuCuList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaChungTuCu", _maChungTuCu);
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu.DBValue);
			if (_loaiChungTu.Length > 0)
				cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
			else
				cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_tyGia != 0)
				cm.Parameters.AddWithValue("@TyGia", _tyGia);
			else
				cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_maKH.Length > 0)
				cm.Parameters.AddWithValue("@MaKH", _maKH);
			else
				cm.Parameters.AddWithValue("@MaKH", DBNull.Value);
			if (_tenKH.Length > 0)
				cm.Parameters.AddWithValue("@TenKH", _tenKH);
			else
				cm.Parameters.AddWithValue("@TenKH", DBNull.Value);
			if (_noTK.Length > 0)
				cm.Parameters.AddWithValue("@NoTK", _noTK);
			else
				cm.Parameters.AddWithValue("@NoTK", DBNull.Value);
			if (_coTK.Length > 0)
				cm.Parameters.AddWithValue("@CoTK", _coTK);
			else
				cm.Parameters.AddWithValue("@CoTK", DBNull.Value);
			if (_muc.Length > 0)
				cm.Parameters.AddWithValue("@Muc", _muc);
			else
				cm.Parameters.AddWithValue("@Muc", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ChungTuCuList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ChungTuCuList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblChungTuCu";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChungTuCuList parent)
		{
			cm.Parameters.AddWithValue("@MaChungTuCu", _maChungTuCu);
			if (_soChungTu.Length > 0)
				cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			else
				cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayChungTu", _ngayChungTu.DBValue);
			if (_loaiChungTu.Length > 0)
				cm.Parameters.AddWithValue("@LoaiChungTu", _loaiChungTu);
			else
				cm.Parameters.AddWithValue("@LoaiChungTu", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_tyGia != 0)
				cm.Parameters.AddWithValue("@TyGia", _tyGia);
			else
				cm.Parameters.AddWithValue("@TyGia", DBNull.Value);
			if (_thanhTien != 0)
				cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
			else
				cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
			if (_maKH.Length > 0)
				cm.Parameters.AddWithValue("@MaKH", _maKH);
			else
				cm.Parameters.AddWithValue("@MaKH", DBNull.Value);
			if (_tenKH.Length > 0)
				cm.Parameters.AddWithValue("@TenKH", _tenKH);
			else
				cm.Parameters.AddWithValue("@TenKH", DBNull.Value);
			if (_noTK.Length > 0)
				cm.Parameters.AddWithValue("@NoTK", _noTK);
			else
				cm.Parameters.AddWithValue("@NoTK", DBNull.Value);
			if (_coTK.Length > 0)
				cm.Parameters.AddWithValue("@CoTK", _coTK);
			else
				cm.Parameters.AddWithValue("@CoTK", DBNull.Value);
			if (_muc.Length > 0)
				cm.Parameters.AddWithValue("@Muc", _muc);
			else
				cm.Parameters.AddWithValue("@Muc", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maChungTuCu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
