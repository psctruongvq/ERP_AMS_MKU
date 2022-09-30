
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThongTinTuyenDung : Csla.BusinessBase<ThongTinTuyenDung>
	{
		#region Business Properties and Methods

		//declare members
		private long _maTuyenDung = 0;
		private int _soLuongTuyen = 0;
		private SmartDate _tuNgay = new SmartDate(DateTime.Today);
		private SmartDate _denNgay = new SmartDate(DateTime.Today);
		private int _maViTri = 0;
        private int _maBoPhan = 0;
		private string _noiDung = string.Empty;
		private string _tenTuyenDung = string.Empty;
        private string _tenBoPhan = string.Empty;
        private string _tenCongViec = string.Empty;
		[System.ComponentModel.DataObjectField(true, true)]
		public long MaTuyenDung
		{
			get
			{
				CanReadProperty("MaTuyenDung", true);
				return _maTuyenDung;
			}
		}

		public int SoLuongTuyen
		{
			get
			{
				CanReadProperty("SoLuongTuyen", true);
				return _soLuongTuyen;
			}
			set
			{
				CanWriteProperty("SoLuongTuyen", true);
				if (!_soLuongTuyen.Equals(value))
				{
					_soLuongTuyen = value;
					PropertyHasChanged("SoLuongTuyen");
				}
			}
		}

		public DateTime TuNgay
		{
			get
			{
				CanReadProperty("TuNgay", true);
				return _tuNgay.Date;
			}
            set
            {
                CanWriteProperty("TuNgay", true);
                if (!_tuNgay.Equals(value))
                {
                    _tuNgay = new SmartDate(value);
                    PropertyHasChanged("TuNgay");
                }
            }
		}

	
		public DateTime DenNgay
		{
			get
			{
				CanReadProperty("DenNgay", true);
				return _denNgay.Date;
			}
            set
            {
                CanWriteProperty("DenNgay", true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = new SmartDate(value);
                    PropertyHasChanged("DenNgay");
                }
            }
		}

	

		public int MaViTri
		{
			get
			{
				CanReadProperty("MaViTri", true);
				return _maViTri;
			}
			set
			{
				CanWriteProperty("MaViTri", true);
				if (!_maViTri.Equals(value))
				{
					_maViTri = value;
                    TenCongViec = CongViec.GetCongViec(_maViTri).TenCongViec;
					PropertyHasChanged("MaViTri");
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
                    TenBoPhan = BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

		public string NoiDung
		{
			get
			{
				CanReadProperty("NoiDung", true);
				return _noiDung;
			}
			set
			{
				CanWriteProperty("NoiDung", true);
				if (value == null) value = string.Empty;
				if (!_noiDung.Equals(value))
				{
					_noiDung = value;
					PropertyHasChanged("NoiDung");
				}
			}
		}
        public string TenBoPhan
        {
            get
            {
               
                return _tenBoPhan;
            }
            set
            {
                
                    _tenBoPhan = value;
                
            }
        }
        public string TenCongViec
        {
            get
            {
               
                return _tenCongViec;
            }
            set
            {
               
                    _tenCongViec = value;
                
            }
        }
		public string TenTuyenDung
		{
			get
			{
				CanReadProperty("TenTuyenDung", true);
				return _tenTuyenDung;
			}
			set
			{
				CanWriteProperty("TenTuyenDung", true);
				if (value == null) value = string.Empty;
				if (!_tenTuyenDung.Equals(value))
				{
					_tenTuyenDung = value;
					PropertyHasChanged("TenTuyenDung");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTuyenDung;
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
			// NoiDung
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiDung", 1000));
			//
			// TenTuyenDung
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTuyenDung", 500));
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
			//TODO: Define authorization rules in ThongTinTuyenDung
			//AuthorizationRules.AllowRead("MaTuyenDung", "ThongTinTuyenDungReadGroup");
			//AuthorizationRules.AllowRead("SoLuongTuyen", "ThongTinTuyenDungReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "ThongTinTuyenDungReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "ThongTinTuyenDungReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "ThongTinTuyenDungReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "ThongTinTuyenDungReadGroup");
			//AuthorizationRules.AllowRead("MaViTri", "ThongTinTuyenDungReadGroup");
			//AuthorizationRules.AllowRead("NoiDung", "ThongTinTuyenDungReadGroup");
			//AuthorizationRules.AllowRead("TenTuyenDung", "ThongTinTuyenDungReadGroup");

			//AuthorizationRules.AllowWrite("SoLuongTuyen", "ThongTinTuyenDungWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "ThongTinTuyenDungWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "ThongTinTuyenDungWriteGroup");
			//AuthorizationRules.AllowWrite("MaViTri", "ThongTinTuyenDungWriteGroup");
			//AuthorizationRules.AllowWrite("NoiDung", "ThongTinTuyenDungWriteGroup");
			//AuthorizationRules.AllowWrite("TenTuyenDung", "ThongTinTuyenDungWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThongTinTuyenDung
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTuyenDungViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThongTinTuyenDung
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTuyenDungAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThongTinTuyenDung
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTuyenDungEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThongTinTuyenDung
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThongTinTuyenDungDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThongTinTuyenDung()
		{ /* require use of factory method */ }

		public static ThongTinTuyenDung NewThongTinTuyenDung()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinTuyenDung");
			return DataPortal.Create<ThongTinTuyenDung>();
		}

		public static ThongTinTuyenDung GetThongTinTuyenDung(long maTuyenDung)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThongTinTuyenDung");
			return DataPortal.Fetch<ThongTinTuyenDung>(new Criteria(maTuyenDung));
		}

		public static void DeleteThongTinTuyenDung(long maTuyenDung)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinTuyenDung");
			DataPortal.Delete(new Criteria(maTuyenDung));
		}

		public override ThongTinTuyenDung Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThongTinTuyenDung");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThongTinTuyenDung");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThongTinTuyenDung");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ThongTinTuyenDung NewThongTinTuyenDungChild()
		{
			ThongTinTuyenDung child = new ThongTinTuyenDung();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThongTinTuyenDung GetThongTinTuyenDung(SafeDataReader dr)
		{
			ThongTinTuyenDung child =  new ThongTinTuyenDung();
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
			public long MaTuyenDung;

			public Criteria(long maTuyenDung)
			{
				this.MaTuyenDung = maTuyenDung;
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
                cm.CommandText = "sp_SelecttblnsThongTinTuyenDung";

				cm.Parameters.AddWithValue("@MaTuyenDung", criteria.MaTuyenDung);

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
			DataPortal_Delete(new Criteria(_maTuyenDung));
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
                cm.CommandText = "sp_DeletetblnsThongTinTuyenDung";

				cm.Parameters.AddWithValue("@MaTuyenDung", criteria.MaTuyenDung);

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
			_maTuyenDung = dr.GetInt64("MaTuyenDung");
			_soLuongTuyen = dr.GetInt32("SoLuongTuyen");
			_tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
			_denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
			_maViTri = dr.GetInt32("MaViTri");
            _maBoPhan = dr.GetInt32("MaBoPhan");
			_noiDung = dr.GetString("NoiDung");
			_tenTuyenDung = dr.GetString("TenTuyenDung");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ThongTinTuyenDungList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ThongTinTuyenDungList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_InserttblnsThongTinTuyenDung";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTuyenDung = (long)cm.Parameters["@MaTuyenDung"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ThongTinTuyenDungList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_soLuongTuyen != 0)
				cm.Parameters.AddWithValue("@SoLuongTuyen", _soLuongTuyen);
			else
				cm.Parameters.AddWithValue("@SoLuongTuyen", DBNull.Value);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_maViTri != 0)
				cm.Parameters.AddWithValue("@MaViTri", _maViTri);
			else
				cm.Parameters.AddWithValue("@MaViTri", DBNull.Value);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
			if (_noiDung.Length > 0)
				cm.Parameters.AddWithValue("@NoiDung", _noiDung);
			else
				cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
			if (_tenTuyenDung.Length > 0)
				cm.Parameters.AddWithValue("@TenTuyenDung", _tenTuyenDung);
			else
				cm.Parameters.AddWithValue("@TenTuyenDung", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTuyenDung", _maTuyenDung);
			cm.Parameters["@MaTuyenDung"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ThongTinTuyenDungList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ThongTinTuyenDungList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "sp_UpdatetblnsThongTinTuyenDung";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ThongTinTuyenDungList parent)
		{
			cm.Parameters.AddWithValue("@MaTuyenDung", _maTuyenDung);
			if (_soLuongTuyen != 0)
				cm.Parameters.AddWithValue("@SoLuongTuyen", _soLuongTuyen);
			else
				cm.Parameters.AddWithValue("@SoLuongTuyen", DBNull.Value);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
            if (_maBoPhan != 0)
                cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            else
                cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
            if (_maViTri != 0)
				cm.Parameters.AddWithValue("@MaViTri", _maViTri);
			else
				cm.Parameters.AddWithValue("@MaViTri", DBNull.Value);
			if (_noiDung.Length > 0)
				cm.Parameters.AddWithValue("@NoiDung", _noiDung);
			else
				cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
			if (_tenTuyenDung.Length > 0)
				cm.Parameters.AddWithValue("@TenTuyenDung", _tenTuyenDung);
			else
				cm.Parameters.AddWithValue("@TenTuyenDung", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maTuyenDung));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
