
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BaoHiemThatNghiep : Csla.BusinessBase<BaoHiemThatNghiep>
	{
		#region Business Properties and Methods

		//declare members
        private int _maBaoHiemThatNghiep = 0;
        private long _maNhanVien = 0;
        private bool _dongBaoHiem = true;
        private string _ghiChu = string.Empty;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today.Date);
        private long _maNguoiLap = 0;
        private string _tenNhanVien = string.Empty;

        
        [System.ComponentModel.DataObjectField(true, true)]
        public string TenNhanVien
        {
            get {
                _tenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                return _tenNhanVien; 
            }
            set { _tenNhanVien = value; }
        }
        public int MaBaoHiemThatNghiep
        {
            get
            {
                return _maBaoHiemThatNghiep;
            }
        }

        public long MaNhanVien
        {
            get
            {
                _tenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    _tenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public bool DongBaoHiem
        {
            get
            {
                return _dongBaoHiem;
            }
            set
            {
                if (!_dongBaoHiem.Equals(value))
                {
                    _dongBaoHiem = value;
                    PropertyHasChanged("DongBaoHiem");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
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
 
		protected override object GetIdValue()
		{
			return _maBaoHiemThatNghiep;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private BaoHiemThatNghiep()
		{ /* require use of factory method */ }

		public static BaoHiemThatNghiep NewBaoHiemThatNghiep()
		{
			return DataPortal.Create<BaoHiemThatNghiep>();
		}
        public static BaoHiemThatNghiep NewBaoHiemThatNghiep(long maNhanVien)
        {
            BaoHiemThatNghiep item = new BaoHiemThatNghiep();
            item.MarkAsChild();
            item.MaNhanVien = maNhanVien;
            return item;
        }
		public static BaoHiemThatNghiep GetBaoHiemThatNghiep(int maBaoHiemThatNghiep)
		{
			return DataPortal.Fetch<BaoHiemThatNghiep>(new Criteria(maBaoHiemThatNghiep));
		}
        public static BaoHiemThatNghiep GetBaoHiemThatNghiep(long MaNhanVien)
        {
            return DataPortal.Fetch<BaoHiemThatNghiep>(new CriteriaByMaNhanVien(MaNhanVien));
        }
		public static void DeleteBaoHiemThatNghiep(int maBaoHiemThatNghiep)
		{
			DataPortal.Delete(new Criteria(maBaoHiemThatNghiep));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BaoHiemThatNghiep NewBaoHiemThatNghiepChild()
		{
			BaoHiemThatNghiep child = new BaoHiemThatNghiep();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BaoHiemThatNghiep GetBaoHiemThatNghiep(SafeDataReader dr)
		{
			BaoHiemThatNghiep child =  new BaoHiemThatNghiep();
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
			public int MaBaoHiemThatNghiep;

			public Criteria(int maBaoHiemThatNghiep)
			{
				this.MaBaoHiemThatNghiep = maBaoHiemThatNghiep;
			}
		}
        private class CriteriaByMaNhanVien
        {
            public long MaNhanVien;

            public CriteriaByMaNhanVien(long maNhanVien)
            {
                this.MaNhanVien = maNhanVien;
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
                    cm.CommandText = "spd_SelecttblnsBaoHiemThatNghiep";
                    cm.Parameters.AddWithValue("@MaBaoHiemThatNghiep", ((Criteria)criteria).MaBaoHiemThatNghiep);
                }
               else if (criteria is CriteriaByMaNhanVien)
                {
                    cm.CommandText = "spd_SelecttblnsBaoHiemThatNghiepByNhanVien";
                    cm.Parameters.AddWithValue("@MaNhanVien", ((CriteriaByMaNhanVien)criteria).MaNhanVien);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                   while( dr.Read())
                    {
                        FetchObject(dr);
                        //ValidationRules.CheckRules();

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
			DataPortal_Delete(new Criteria(_maBaoHiemThatNghiep));
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
                cm.CommandText = "spd_DeletetblnsBaoHiemThatNghiep";

				cm.Parameters.AddWithValue("@MaBaoHiemThatNghiep", criteria.MaBaoHiemThatNghiep);

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
            _maBaoHiemThatNghiep = dr.GetInt32("MaBaoHiemThatNghiep");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _dongBaoHiem = dr.GetBoolean("DongBaoHiem");
            _ghiChu = dr.GetString("GhiChu");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _maNguoiLap = dr.GetInt64("MaNguoiLap");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, BaoHiemThatNghiepList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, BaoHiemThatNghiepList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsBaoHiemThatNghiep";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maBaoHiemThatNghiep = (int)cm.Parameters["@MaBaoHiemThatNghiep"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, BaoHiemThatNghiepList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_dongBaoHiem != false)
                cm.Parameters.AddWithValue("@DongBaoHiem", _dongBaoHiem);
            else
                cm.Parameters.AddWithValue("@DongBaoHiem", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
            if (_maNguoiLap != 0)
                cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
            else
                cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@MaBaoHiemThatNghiep", _maBaoHiemThatNghiep);
			cm.Parameters["@MaBaoHiemThatNghiep"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, BaoHiemThatNghiepList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, BaoHiemThatNghiepList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsBaoHiemThatNghiep";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, BaoHiemThatNghiepList parent)
		{
			cm.Parameters.AddWithValue("@MaBaoHiemThatNghiep", _maBaoHiemThatNghiep);
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            if (_dongBaoHiem != false)
                cm.Parameters.AddWithValue("@DongBaoHiem", _dongBaoHiem);
            else
                cm.Parameters.AddWithValue("@DongBaoHiem", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);
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

			ExecuteDelete(tr, new Criteria(_maBaoHiemThatNghiep));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
