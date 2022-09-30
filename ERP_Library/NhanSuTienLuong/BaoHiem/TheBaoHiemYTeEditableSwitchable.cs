
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TheBaoHiemYTe : Csla.BusinessBase<TheBaoHiemYTe>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTheBHYT = 0;
		private string _soTheBHYT = string.Empty;
        private SmartDate _ngayBatDau = new SmartDate(DateTime.Today.Date);
        private SmartDate _ngayKetThuc = new SmartDate(DateTime.Today.Date);
		private int _maNoiDangKyKCB = 0;
		private bool _traThe = false;
		private long _maNhanVien = 0;
        private SmartDate _ngayCap = new SmartDate(DateTime.Today.Date);
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
		private string _dienGiai = string.Empty;
		private bool _suDung = true;
        private string _TenNhanVien = string.Empty;
		[System.ComponentModel.DataObjectField(true, false)]
		public int MaTheBHYT
		{
			get
			{
				return _maTheBHYT;
			}
		}
        public string TenNhanVien
        {
            get
            {
                _TenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                return _TenNhanVien;
            }
            set { _TenNhanVien = value; }
        }
		public string SoTheBHYT
		{
			get
			{
				return _soTheBHYT;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soTheBHYT.Equals(value))
				{
					_soTheBHYT = value;
					PropertyHasChanged("SoTheBHYT");
				}
			}
		}

		public DateTime NgayBatDau
		{
			get
			{
				return _ngayBatDau.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayBatDau.Equals(value))
                {
                    _ngayBatDau = new SmartDate(value);
                    PropertyHasChanged("NgayBatDau");
                }
            }
		}


		public DateTime NgayKetThuc
		{
			get
			{
				return _ngayKetThuc.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayKetThuc.Equals(value))
                {
                    _ngayKetThuc = new SmartDate(value);
                    PropertyHasChanged("NgayKetThuc");
                }
            }
		}

	
		public int MaNoiDangKyKCB
		{
			get
			{
				return _maNoiDangKyKCB;
			}
			set
			{
				if (!_maNoiDangKyKCB.Equals(value))
				{
					_maNoiDangKyKCB = value;
					PropertyHasChanged("MaNoiDangKyKCB");
				}
			}
		}

		public bool TraThe
		{
			get
			{
				return _traThe;
			}
			set
			{
				if (!_traThe.Equals(value))
				{
					_traThe = value;
					PropertyHasChanged("TraThe");
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

		public DateTime NgayCap
		{
			get
			{
				return _ngayCap.Date;
			}
            set
            {
                CanWriteProperty(true);
                if (!_ngayCap.Equals(value))
                {
                    _ngayCap = new SmartDate(value);
                    PropertyHasChanged("NgayCap");
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

		public bool SuDung
		{
			get
			{
				return _suDung;
			}
			set
			{
				if (!_suDung.Equals(value))
				{
					_suDung = value;
					PropertyHasChanged("SuDung");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTheBHYT;
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
			// SoTheBHYT
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoTheBHYT", 50));
			//
			// DienGiai
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 200));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private TheBaoHiemYTe()
		{ /* require use of factory method */ }
        public static TheBaoHiemYTe NewTheBaoHiemYTe()
        {
            TheBaoHiemYTe item = new TheBaoHiemYTe();
            item.MarkAsChild();
            return item;
        }
        public static TheBaoHiemYTe NewTheBaoHiemYTe(long maNhanVien)
        {
            TheBaoHiemYTe item = new TheBaoHiemYTe();
            item.MaNhanVien = maNhanVien;
            item.MarkAsChild();
            return item;
        }
		public static TheBaoHiemYTe NewTheBaoHiemYTe(int maTheBHYT)
		{
			return DataPortal.Create<TheBaoHiemYTe>(new Criteria(maTheBHYT));
		}

		public static TheBaoHiemYTe GetTheBaoHiemYTe(int maTheBHYT)
		{
			return DataPortal.Fetch<TheBaoHiemYTe>(new Criteria(maTheBHYT));
		}
        public static TheBaoHiemYTe GetTheBaoHiemYTe(long maNhanVien)
        {
            return DataPortal.Fetch<TheBaoHiemYTe>(new CriteriaByNhanVien(maNhanVien));
        }
		public static void DeleteTheBaoHiemYTe(int maTheBHYT)
		{
			DataPortal.Delete(new Criteria(maTheBHYT));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private TheBaoHiemYTe(int maTheBHYT)
		{
			this._maTheBHYT = maTheBHYT;
		}

		internal static TheBaoHiemYTe NewTheBaoHiemYTeChild(int maTheBHYT)
		{
			TheBaoHiemYTe child = new TheBaoHiemYTe(maTheBHYT);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TheBaoHiemYTe GetTheBaoHiemYTe(SafeDataReader dr)
		{
			TheBaoHiemYTe child =  new TheBaoHiemYTe();
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
			public int MaTheBHYT;
            public long _maNhanVien;
            public Criteria()
            { 
            }
            public Criteria(long maNhanVien)
            {
                this._maNhanVien = maNhanVien;
            }
			public Criteria(int maTheBHYT)
			{
				this.MaTheBHYT = maTheBHYT;
			}
		}
        private class CriteriaByNhanVien
        {
          
            public long _maNhanVien;
          
            public CriteriaByNhanVien(long maNhanVien)
            {
                this._maNhanVien = maNhanVien;
            }
           
        }
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maTheBHYT = criteria.MaTheBHYT;
			//ValidationRules.CheckRules();
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
                    cm.CommandText = "spd_SelecttblnsTheBaoHiemYTe";
                    cm.Parameters.AddWithValue("@MaTheBHYT",((Criteria) criteria).MaTheBHYT);
                }
                else if (criteria is CriteriaByNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsTheBaoHiemYTeByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((CriteriaByNhanVien)criteria)._maNhanVien);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                       // ValidationRules.CheckRules();

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
			DataPortal_Delete(new Criteria(_maTheBHYT));
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
                cm.CommandText = "spd_DeletetblnsTheBaoHiemYTe";

				cm.Parameters.AddWithValue("@MaTheBHYT", criteria.MaTheBHYT);

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
			_maTheBHYT = dr.GetInt32("MaTheBHYT");
			_soTheBHYT = dr.GetString("SoTheBHYT");
			_ngayBatDau = dr.GetSmartDate("NgayBatDau", _ngayBatDau.EmptyIsMin);
			_ngayKetThuc = dr.GetSmartDate("NgayKetThuc", _ngayKetThuc.EmptyIsMin);
			_maNoiDangKyKCB = dr.GetInt32("MaNoiDangKyKCB");
			_traThe = dr.GetBoolean("TraThe");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_ngayCap = dr.GetSmartDate("NgayCap", _ngayCap.EmptyIsMin);
			_ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
			_dienGiai = dr.GetString("DienGiai");
			_suDung = dr.GetBoolean("SuDung");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, TheBaoHiemYTeList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, TheBaoHiemYTeList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsTheBaoHiemYTe";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TheBaoHiemYTeList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaTheBHYT", _maTheBHYT);
            cm.Parameters["@MaTheBHYT"].Direction = ParameterDirection.Output;
			if (_soTheBHYT.Length > 0)
				cm.Parameters.AddWithValue("@SoTheBHYT", _soTheBHYT);
			else
				cm.Parameters.AddWithValue("@SoTheBHYT", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.DBValue);
			cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
			if (_maNoiDangKyKCB != 0)
				cm.Parameters.AddWithValue("@MaNoiDangKyKCB", _maNoiDangKyKCB);
			else
				cm.Parameters.AddWithValue("@MaNoiDangKyKCB", DBNull.Value);
			if (_traThe != false)
				cm.Parameters.AddWithValue("@TraThe", _traThe);
			else
				cm.Parameters.AddWithValue("@TraThe", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_suDung != false)
				cm.Parameters.AddWithValue("@SuDung", _suDung);
			else
				cm.Parameters.AddWithValue("@SuDung", DBNull.Value);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, TheBaoHiemYTeList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, TheBaoHiemYTeList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsTheBaoHiemYTe";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TheBaoHiemYTeList parent)
		{
			cm.Parameters.AddWithValue("@MaTheBHYT", _maTheBHYT);
			if (_soTheBHYT.Length > 0)
				cm.Parameters.AddWithValue("@SoTheBHYT", _soTheBHYT);
			else
				cm.Parameters.AddWithValue("@SoTheBHYT", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau.DBValue);
			cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc.DBValue);
			if (_maNoiDangKyKCB != 0)
				cm.Parameters.AddWithValue("@MaNoiDangKyKCB", _maNoiDangKyKCB);
			else
				cm.Parameters.AddWithValue("@MaNoiDangKyKCB", DBNull.Value);
			if (_traThe != false)
				cm.Parameters.AddWithValue("@TraThe", _traThe);
			else
				cm.Parameters.AddWithValue("@TraThe", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayCap", _ngayCap.DBValue);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_suDung != false)
				cm.Parameters.AddWithValue("@SuDung", _suDung);
			else
				cm.Parameters.AddWithValue("@SuDung", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maTheBHYT));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
