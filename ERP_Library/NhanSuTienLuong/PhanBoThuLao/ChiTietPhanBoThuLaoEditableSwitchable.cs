using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
namespace ERP_Library
{ 
	[Serializable()] 
	public class ChiTietPhanBoThuLao : Csla.BusinessBase<ChiTietPhanBoThuLao>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChiTietPhanBoThuLao = 0;
		private long _maPhanBoThuLao = 0;
		private int _maBoPhanDen = 0;
		private string _tenBoPhanDen = string.Empty;
		private decimal _soTien = 0;
		private SmartDate _ngayHoanTat = new SmartDate(DateTime.Today);
		private string _ghiChu = string.Empty;
		private bool _duocNhapHo = false;
		private int _maCongViec = 0;
		private string _tenCongViec = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChiTietPhanBoThuLao
		{
			get
			{
				CanReadProperty("MaChiTietPhanBoThuLao", true);
				return _maChiTietPhanBoThuLao;
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

		public int MaBoPhanDen
		{
			get
			{
				CanReadProperty("MaBoPhanDen", true);
				return _maBoPhanDen;
			}
			set
			{
				CanWriteProperty("MaBoPhanDen", true);
				if (!_maBoPhanDen.Equals(value))
				{
					_maBoPhanDen = value;
					PropertyHasChanged("MaBoPhanDen");
				}
			}
		}

		public string TenBoPhanDen
		{
			get
			{
				CanReadProperty("TenBoPhanDen", true);
				return _tenBoPhanDen;
			}
			set
			{
				CanWriteProperty("TenBoPhanDen", true);
				if (value == null) value = string.Empty;
				if (!_tenBoPhanDen.Equals(value))
				{
					_tenBoPhanDen = value;
					PropertyHasChanged("TenBoPhanDen");
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

		public DateTime NgayHoanTat
		{
			get
			{
				CanReadProperty("NgayHoanTat", true);
				return _ngayHoanTat.Date;
			}
            set
            {
                CanWriteProperty("NgayHoanTat", true);
                if (!_ngayHoanTat.Equals(value))
                {
                    _ngayHoanTat = new SmartDate(value);
                    PropertyHasChanged("NgayHoanTat");
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

		public bool DuocNhapHo
		{
			get
			{
				CanReadProperty("DuocNhapHo", true);
				return _duocNhapHo;
			}
			set
			{
				CanWriteProperty("DuocNhapHo", true);
				if (!_duocNhapHo.Equals(value))
				{
					_duocNhapHo = value;
					PropertyHasChanged("DuocNhapHo");
				}
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
 
		protected override object GetIdValue()
		{
			return _maChiTietPhanBoThuLao;
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
			// TenBoPhanDen
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenBoPhanDen");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhanDen", 200));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
			//
			// TenCongViec
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenCongViec");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenCongViec", 200));
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
			//TODO: Define authorization rules in ChiTietPhanBoThuLao
			//AuthorizationRules.AllowRead("MaChiTietPhanBoThuLao", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaPhanBoThuLao", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaBoPhanDen", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("TenBoPhanDen", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("NgayHoanTat", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("NgayHoanTatString", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("DuocNhapHo", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("MaCongViec", "ChiTietPhanBoThuLaoReadGroup");
			//AuthorizationRules.AllowRead("TenCongViec", "ChiTietPhanBoThuLaoReadGroup");

			//AuthorizationRules.AllowWrite("MaPhanBoThuLao", "ChiTietPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaBoPhanDen", "ChiTietPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("TenBoPhanDen", "ChiTietPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "ChiTietPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("NgayHoanTatString", "ChiTietPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "ChiTietPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("DuocNhapHo", "ChiTietPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("MaCongViec", "ChiTietPhanBoThuLaoWriteGroup");
			//AuthorizationRules.AllowWrite("TenCongViec", "ChiTietPhanBoThuLaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChiTietPhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietPhanBoThuLaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChiTietPhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietPhanBoThuLaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChiTietPhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietPhanBoThuLaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChiTietPhanBoThuLao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChiTietPhanBoThuLaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChiTietPhanBoThuLao()
		{ /* require use of factory method */ }

        private ChiTietPhanBoThuLao(int index)
        {
           _maChiTietPhanBoThuLao=index;
        }
        public static ChiTietPhanBoThuLao NewChiTietPhanBoThuLaoAdd(int index)
        {
            return new ChiTietPhanBoThuLao(index);
        }
        public static ChiTietPhanBoThuLao NewChiTietPhanBoThuLao()
        {
            ChiTietPhanBoThuLao item = new ChiTietPhanBoThuLao();
            item.MarkAsChild();
            return item;
        }

		public static ChiTietPhanBoThuLao GetChiTietPhanBoThuLao(long maChiTietPhanBoThuLao)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChiTietPhanBoThuLao");
			return DataPortal.Fetch<ChiTietPhanBoThuLao>(new Criteria(maChiTietPhanBoThuLao));
		}

        public static ChiTietPhanBoThuLao GetChiTietPhanBoThuLaoByMaBoPhan_MaPhanBo(long maChiTietPhanBoThuLao, int maBoPhan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChiTietPhanBoThuLao");
            return DataPortal.Fetch<ChiTietPhanBoThuLao>(new CriteriaBy_MaBoPhan_MaPhanBo(maChiTietPhanBoThuLao, maBoPhan));
        }


		public static void DeleteChiTietPhanBoThuLao(long maChiTietPhanBoThuLao)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChiTietPhanBoThuLao");
			DataPortal.Delete(new Criteria(maChiTietPhanBoThuLao));
		}

		public override ChiTietPhanBoThuLao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChiTietPhanBoThuLao");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChiTietPhanBoThuLao");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChiTietPhanBoThuLao");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChiTietPhanBoThuLao NewChiTietPhanBoThuLaoChild()
		{
			ChiTietPhanBoThuLao child = new ChiTietPhanBoThuLao();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChiTietPhanBoThuLao GetChiTietPhanBoThuLao(SafeDataReader dr)
		{
			ChiTietPhanBoThuLao child =  new ChiTietPhanBoThuLao();
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
			public long MaChiTietPhanBoThuLao;

			public Criteria(long maChiTietPhanBoThuLao)
			{
				this.MaChiTietPhanBoThuLao = maChiTietPhanBoThuLao;
			}
		}

        private class CriteriaBy_MaBoPhan_MaPhanBo
        {
            public long MaChiTietPhanBoThuLao;
            public int MaBoPhan;

            public CriteriaBy_MaBoPhan_MaPhanBo(long maChiTietPhanBoThuLao, int maBoPhan)
            {
                this.MaChiTietPhanBoThuLao = maChiTietPhanBoThuLao;
                this.MaBoPhan = maBoPhan;
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
                if (criteria is Criteria)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsChiTietPhanBoThuLao";

                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", ((Criteria)criteria).MaChiTietPhanBoThuLao);
                }

                if (criteria is CriteriaBy_MaBoPhan_MaPhanBo)
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_SelecttblnsChiTietPhanBoThuLao_MaBoPhan_MaPhanBo";

                    cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", ((CriteriaBy_MaBoPhan_MaPhanBo)criteria).MaChiTietPhanBoThuLao);
                    cm.Parameters.Add("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
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
			DataPortal_Delete(new Criteria(_maChiTietPhanBoThuLao));
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
                cm.CommandText = "Spd_DeletetblnsChiTietPhanBoThuLao";

				cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", criteria.MaChiTietPhanBoThuLao);

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
			_maChiTietPhanBoThuLao = dr.GetInt64("MaChiTietPhanBoThuLao");
			_maPhanBoThuLao = dr.GetInt64("MaPhanBoThuLao");
			_maBoPhanDen = dr.GetInt32("MaBoPhanDen");
			_tenBoPhanDen = dr.GetString("TenBoPhanDen");
			_soTien = dr.GetDecimal("SoTien");
			_ngayHoanTat = dr.GetSmartDate("NgayHoanTat", _ngayHoanTat.EmptyIsMin);
			_ghiChu = dr.GetString("GhiChu");
			_duocNhapHo = dr.GetBoolean("DuocNhapHo");
			_maCongViec = dr.GetInt32("MaCongViec");
			_tenCongViec = dr.GetString("TenCongViec");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhanBoThuLao parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhanBoThuLao parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "Spd_InserttblnsChiTietPhanBoThuLao";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChiTietPhanBoThuLao = (long)cm.Parameters["@MaChiTietPhanBoThuLao"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhanBoThuLao parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            if (parent.MaPhanBoThuLao > 0)
            {
                cm.Parameters.AddWithValue("@MaPhanBoThuLao", parent.MaPhanBoThuLao);
            }
			cm.Parameters.AddWithValue("@MaBoPhanDen", _maBoPhanDen);
			cm.Parameters.AddWithValue("@TenBoPhanDen", _tenBoPhanDen);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@NgayHoanTat", _ngayHoanTat.DBValue);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
			cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			cm.Parameters.AddWithValue("@TenCongViec", _tenCongViec);
			cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", _maChiTietPhanBoThuLao);
			cm.Parameters["@MaChiTietPhanBoThuLao"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, PhanBoThuLao parent)
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

		private void ExecuteUpdate(SqlTransaction tr, PhanBoThuLao parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "Spd_UpdatetblnsChiTietPhanBoThuLao";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhanBoThuLao parent)
		{
			cm.Parameters.AddWithValue("@MaChiTietPhanBoThuLao", _maChiTietPhanBoThuLao);
			cm.Parameters.AddWithValue("@MaBoPhanDen", _maBoPhanDen);
			cm.Parameters.AddWithValue("@TenBoPhanDen", _tenBoPhanDen);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@NgayHoanTat", _ngayHoanTat.DBValue);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@DuocNhapHo", _duocNhapHo);
			cm.Parameters.AddWithValue("@MaCongViec", _maCongViec);
			cm.Parameters.AddWithValue("@TenCongViec", _tenCongViec);
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

			ExecuteDelete(tr, new Criteria(_maChiTietPhanBoThuLao));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
