
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class SoBaoHiemXaHoi : Csla.BusinessBase<SoBaoHiemXaHoi>
	{
		#region Business Properties and Methods

		//declare members
		private int _maSoBaoHiemXH = 0;
		private string _soSoBaoHiem = string.Empty;
		private long _maNhanVien = 0;
		private SmartDate _ngayLamSo = new SmartDate(DateTime.Today.Date);
        private SmartDate _ngayThamGia = new SmartDate(DateTime.Today.Date);
		private string _dienGiai = string.Empty;
		private string _noiLamSo = string.Empty;
		private long _maNguoiLap = 0;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
		private bool _choCapSo = false;
        private string _TenNhanVien = string.Empty;

        public string TenNhanVien
        {
            get
            {
                _TenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                return _TenNhanVien; 
            }
            set { _TenNhanVien = value; }
        }
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaSoBaoHiemXH
		{
			get
			{
				return _maSoBaoHiemXH;
			}
		}

		public string SoSoBaoHiem
		{
			get
			{
				return _soSoBaoHiem;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soSoBaoHiem.Equals(value))
				{
					_soSoBaoHiem = value;
					PropertyHasChanged("SoSoBaoHiem");
				}
			}
		}

		public long MaNhanVien
		{
			get
			{
                _TenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
				return _maNhanVien;
			}
			set
			{
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
                    _TenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public DateTime NgayLamSo
		{
			get
			{
				return _ngayLamSo.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayLamSo.Equals(value))
                {
                    _ngayLamSo = new SmartDate(value);
                    PropertyHasChanged("NgayLamSo");
                }
            }
		}

	
		public DateTime NgayThamGia
		{
			get
			{
				return _ngayThamGia.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayThamGia.Equals(value))
                {
                    _ngayThamGia = new SmartDate(value);
                    PropertyHasChanged("NgayThamGia");
                }
            }
		}


		public string DienGiai
		{
			get
			{
				return _dienGiai;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
				}
			}
		}

		public string NoiLamSo
		{
			get
			{
				return _noiLamSo;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_noiLamSo.Equals(value))
				{
					_noiLamSo = value;
					PropertyHasChanged("NoiLamSo");
				}
			}
		}

		public long MaNguoiLap
		{
			get
			{
				return _maNguoiLap;
			}
			set
			{
				if (!_maNguoiLap.Equals(value))
				{
					_maNguoiLap = value;
					PropertyHasChanged("MaNguoiLap");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				return _ngayLap.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
		}

	
		public bool ChoCapSo
		{
			get
			{
				return _choCapSo;
			}
			set
			{
				if (!_choCapSo.Equals(value))
				{
					_choCapSo = value;
					PropertyHasChanged("ChoCapSo");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maSoBaoHiemXH;
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
			// SoSoBaoHiem
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoSoBaoHiem", 50));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
			//
			// NoiLamSo
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NoiLamSo", 500));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private SoBaoHiemXaHoi()
		{ /* require use of factory method */ }

		public static SoBaoHiemXaHoi NewSoBaoHiemXaHoi()
		{
            SoBaoHiemXaHoi item = new SoBaoHiemXaHoi();
            item.MarkAsChild();
            return item;
		}
        public static SoBaoHiemXaHoi NewSoBaoHiemXaHoi(long maNhanVien)
        {
            SoBaoHiemXaHoi item = new SoBaoHiemXaHoi();
            item.MaNhanVien = maNhanVien;
            item.MarkAsChild();
            return item;
        }
		public static SoBaoHiemXaHoi GetSoBaoHiemXaHoi(int maSoBaoHiemXH)
		{
			return DataPortal.Fetch<SoBaoHiemXaHoi>(new Criteria(maSoBaoHiemXH));
		}
        public static SoBaoHiemXaHoi GetSoBaoHiemXaHoi(long maNhanVien)
        {
            return DataPortal.Fetch<SoBaoHiemXaHoi>(new CriteriaByNhanVien(maNhanVien));
        }
		public static void DeleteSoBaoHiemXaHoi(int maSoBaoHiemXH)
		{
			DataPortal.Delete(new Criteria(maSoBaoHiemXH));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static SoBaoHiemXaHoi NewSoBaoHiemXaHoiChild()
		{
			SoBaoHiemXaHoi child = new SoBaoHiemXaHoi();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static SoBaoHiemXaHoi GetSoBaoHiemXaHoi(SafeDataReader dr)
		{
			SoBaoHiemXaHoi child =  new SoBaoHiemXaHoi();
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
			public int MaSoBaoHiemXH;

			public Criteria(int maSoBaoHiemXH)
			{
				this.MaSoBaoHiemXH = maSoBaoHiemXH;
			}
		}
        private class CriteriaByNhanVien
        {
            public long maNhanVien;

            public CriteriaByNhanVien(long manhanvien)
            {
                this.maNhanVien = manhanvien;
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
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblnsSoBaoHiemXaHoi";
                    cm.Parameters.AddWithValue("@MaSoBaoHiemXH",((Criteria) criteria).MaSoBaoHiemXH);
                }
                else if (criteria is CriteriaByNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsSoBaoHiemXaHoiByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((CriteriaByNhanVien)criteria).maNhanVien);
                }
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
			DataPortal_Delete(new Criteria(_maSoBaoHiemXH));
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
                cm.CommandText = "spd_DeletetblnsSoBaoHiemXaHoi";

				cm.Parameters.AddWithValue("@MaSoBaoHiemXH", criteria.MaSoBaoHiemXH);

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
			_maSoBaoHiemXH = dr.GetInt32("MaSoBaoHiemXH");
			_soSoBaoHiem = dr.GetString("SoSoBaoHiem");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_ngayLamSo = dr.GetSmartDate("NgayLamSo", _ngayLamSo.EmptyIsMin);
			_ngayThamGia = dr.GetSmartDate("NgayThamGia", _ngayThamGia.EmptyIsMin);
			_dienGiai = dr.GetString("DienGiai");
			_noiLamSo = dr.GetString("NoiLamSo");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_choCapSo = dr.GetBoolean("ChoCapSo");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, SoBaoHiemXaHoiList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, SoBaoHiemXaHoiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsSoBaoHiemXaHoi";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maSoBaoHiemXH = (int)cm.Parameters["@MaSoBaoHiemXH"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, SoBaoHiemXaHoiList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_soSoBaoHiem.Length > 0)
				cm.Parameters.AddWithValue("@SoSoBaoHiem", _soSoBaoHiem);
			else
				cm.Parameters.AddWithValue("@SoSoBaoHiem", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLamSo", _ngayLamSo.DBValue);
			cm.Parameters.AddWithValue("@NgayThamGia", _ngayThamGia.DBValue);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_noiLamSo.Length > 0)
				cm.Parameters.AddWithValue("@NoiLamSo", _noiLamSo);
			else
				cm.Parameters.AddWithValue("@NoiLamSo", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_choCapSo != false)
				cm.Parameters.AddWithValue("@ChoCapSo", _choCapSo);
			else
				cm.Parameters.AddWithValue("@ChoCapSo", DBNull.Value);
			cm.Parameters.AddWithValue("@MaSoBaoHiemXH", _maSoBaoHiemXH);
			cm.Parameters["@MaSoBaoHiemXH"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, SoBaoHiemXaHoiList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, SoBaoHiemXaHoiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsSoBaoHiemXaHoi";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, SoBaoHiemXaHoiList parent)
		{
			cm.Parameters.AddWithValue("@MaSoBaoHiemXH", _maSoBaoHiemXH);
			if (_soSoBaoHiem.Length > 0)
				cm.Parameters.AddWithValue("@SoSoBaoHiem", _soSoBaoHiem);
			else
				cm.Parameters.AddWithValue("@SoSoBaoHiem", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLamSo", _ngayLamSo.DBValue);
			cm.Parameters.AddWithValue("@NgayThamGia", _ngayThamGia.DBValue);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_noiLamSo.Length > 0)
				cm.Parameters.AddWithValue("@NoiLamSo", _noiLamSo);
			else
				cm.Parameters.AddWithValue("@NoiLamSo", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_choCapSo != false)
				cm.Parameters.AddWithValue("@ChoCapSo", _choCapSo);
			else
				cm.Parameters.AddWithValue("@ChoCapSo", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maSoBaoHiemXH));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
