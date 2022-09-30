
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LichSuBanThan : Csla.BusinessBase<LichSuBanThan>
	{
		#region Business Properties and Methods

		//declare members
		private int _mactLichsubanthan = 0;
		private long _maNhanVien = 0;
		private SmartDate _tuNgay = new SmartDate(DateTime.Today);
		private SmartDate _denNgay = new SmartDate(DateTime.Today);
		private string _congViec = string.Empty;
		private string _noiLamViec = string.Empty;
		private string _diaChiNoiO = string.Empty;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MactLichsubanthan
		{
			get
			{
				CanReadProperty("MactLichsubanthan", true);
				return _mactLichsubanthan;
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

		public DateTime TuNgay
		{
			get
			{
				CanReadProperty("TuNgay", true);
				return _tuNgay.Date;
			}
            set
            {
                CanWriteProperty(true);
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
                CanWriteProperty(true);
                if (!_denNgay.Equals(value))
                {
                    _denNgay = new SmartDate(value);
                    PropertyHasChanged("DenNgay");
                }
            }
		}		

		public string CongViec
		{
			get
			{
				CanReadProperty("CongViec", true);
				return _congViec;
			}
			set
			{
				CanWriteProperty("CongViec", true);
				if (value == null) value = string.Empty;
				if (!_congViec.Equals(value))
				{
					_congViec = value;
					PropertyHasChanged("CongViec");
				}
			}
		}

		public string NoiLamViec
		{
			get
			{
				CanReadProperty("NoiLamViec", true);
				return _noiLamViec;
			}
			set
			{
				CanWriteProperty("NoiLamViec", true);
				if (value == null) value = string.Empty;
				if (!_noiLamViec.Equals(value))
				{
					_noiLamViec = value;
					PropertyHasChanged("NoiLamViec");
				}
			}
		}

		public string DiaChiNoiO
		{
			get
			{
				CanReadProperty("DiaChiNoiO", true);
				return _diaChiNoiO;
			}
			set
			{
				CanWriteProperty("DiaChiNoiO", true);
				if (value == null) value = string.Empty;
				if (!_diaChiNoiO.Equals(value))
				{
					_diaChiNoiO = value;
					PropertyHasChanged("DiaChiNoiO");
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
			return _mactLichsubanthan;
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
			// TuNgay
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TuNgayString");
			//
			// DenNgay
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "DenNgayString");
			//
			// CongViec
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("CongViec", 200));
			//
			// NoiLamViec
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiLamViec", 200));
			//
			// DiaChiNoiO
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChiNoiO", 500));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 500));
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
			//TODO: Define authorization rules in LichSuBanThan
			//AuthorizationRules.AllowRead("MactLichsubanthan", "LichSuBanThanReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "LichSuBanThanReadGroup");
			//AuthorizationRules.AllowRead("TuNgay", "LichSuBanThanReadGroup");
			//AuthorizationRules.AllowRead("TuNgayString", "LichSuBanThanReadGroup");
			//AuthorizationRules.AllowRead("DenNgay", "LichSuBanThanReadGroup");
			//AuthorizationRules.AllowRead("DenNgayString", "LichSuBanThanReadGroup");
			//AuthorizationRules.AllowRead("CongViec", "LichSuBanThanReadGroup");
			//AuthorizationRules.AllowRead("NoiLamViec", "LichSuBanThanReadGroup");
			//AuthorizationRules.AllowRead("DiaChiNoiO", "LichSuBanThanReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "LichSuBanThanReadGroup");

			//AuthorizationRules.AllowWrite("MaNhanVien", "LichSuBanThanWriteGroup");
			//AuthorizationRules.AllowWrite("TuNgayString", "LichSuBanThanWriteGroup");
			//AuthorizationRules.AllowWrite("DenNgayString", "LichSuBanThanWriteGroup");
			//AuthorizationRules.AllowWrite("CongViec", "LichSuBanThanWriteGroup");
			//AuthorizationRules.AllowWrite("NoiLamViec", "LichSuBanThanWriteGroup");
			//AuthorizationRules.AllowWrite("DiaChiNoiO", "LichSuBanThanWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "LichSuBanThanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LichSuBanThan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LichSuBanThanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LichSuBanThan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LichSuBanThanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LichSuBanThan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LichSuBanThanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LichSuBanThan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LichSuBanThanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LichSuBanThan()
		{ /* require use of factory method */ }

		public static LichSuBanThan NewLichSuBanThan()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LichSuBanThan");
			return DataPortal.Create<LichSuBanThan>();
		}

        public static LichSuBanThan NewLichSuBanThan(long maNhanVien)
        {
            LichSuBanThan _LichSuBanThan = new LichSuBanThan();
            _LichSuBanThan.MaNhanVien = maNhanVien;
            return _LichSuBanThan;
        }

		public static LichSuBanThan GetLichSuBanThan(int mactLichsubanthan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LichSuBanThan");
			return DataPortal.Fetch<LichSuBanThan>(new Criteria(mactLichsubanthan));
		}

		public static void DeleteLichSuBanThan(int mactLichsubanthan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LichSuBanThan");
			DataPortal.Delete(new Criteria(mactLichsubanthan));
		}

		public override LichSuBanThan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LichSuBanThan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LichSuBanThan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LichSuBanThan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LichSuBanThan NewLichSuBanThanChild()
		{
			LichSuBanThan child = new LichSuBanThan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LichSuBanThan GetLichSuBanThan(SafeDataReader dr)
		{
			LichSuBanThan child =  new LichSuBanThan();
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
			public int MactLichsubanthan;

			public Criteria(int mactLichsubanthan)
			{
				this.MactLichsubanthan = mactLichsubanthan;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			//ValidationRules.CheckRules();
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
                cm.CommandText = "spd_SelecttblnsLichSuBanThan";

				cm.Parameters.AddWithValue("@MaCT_LichSuBanThan", criteria.MactLichsubanthan);

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
					ExecuteInsert(tr);

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
						ExecuteUpdate(tr);
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
			DataPortal_Delete(new Criteria(_mactLichsubanthan));
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
                cm.CommandText = "spd_DeletetblnsLichSuBanThan";

				cm.Parameters.AddWithValue("@MaCT_LichSuBanThan", criteria.MactLichsubanthan);

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
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_mactLichsubanthan = dr.GetInt32("MaCT_LichSuBanThan");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tuNgay = dr.GetSmartDate("TuNgay", _tuNgay.EmptyIsMin);
			_denNgay = dr.GetSmartDate("DenNgay", _denNgay.EmptyIsMin);
			_congViec = dr.GetString("CongViec");
			_noiLamViec = dr.GetString("NoiLamViec");
			_diaChiNoiO = dr.GetString("DiaChiNoiO");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsLichSuBanThan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_mactLichsubanthan = (int)cm.Parameters["@MaCT_LichSuBanThan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_congViec.Length > 0)
				cm.Parameters.AddWithValue("@CongViec", _congViec);
			else
				cm.Parameters.AddWithValue("@CongViec", DBNull.Value);
			if (_noiLamViec.Length > 0)
				cm.Parameters.AddWithValue("@NoiLamViec", _noiLamViec);
			else
				cm.Parameters.AddWithValue("@NoiLamViec", DBNull.Value);
			if (_diaChiNoiO.Length > 0)
				cm.Parameters.AddWithValue("@DiaChiNoiO", _diaChiNoiO);
			else
				cm.Parameters.AddWithValue("@DiaChiNoiO", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCT_LichSuBanThan", _mactLichsubanthan);
			cm.Parameters["@MaCT_LichSuBanThan"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsLichSuBanThan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaCT_LichSuBanThan", _mactLichsubanthan);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters.AddWithValue("@TuNgay", _tuNgay.DBValue);
			cm.Parameters.AddWithValue("@DenNgay", _denNgay.DBValue);
			if (_congViec.Length > 0)
				cm.Parameters.AddWithValue("@CongViec", _congViec);
			else
				cm.Parameters.AddWithValue("@CongViec", DBNull.Value);
			if (_noiLamViec.Length > 0)
				cm.Parameters.AddWithValue("@NoiLamViec", _noiLamViec);
			else
				cm.Parameters.AddWithValue("@NoiLamViec", DBNull.Value);
			if (_diaChiNoiO.Length > 0)
				cm.Parameters.AddWithValue("@DiaChiNoiO", _diaChiNoiO);
			else
				cm.Parameters.AddWithValue("@DiaChiNoiO", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_mactLichsubanthan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
