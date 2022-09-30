
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class KyLuatTheoNhom : Csla.BusinessBase<KyLuatTheoNhom>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKyLuat = 0;
		private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private int _maHinhThucKyLuat = 0;
        private string _tenHinhThucKyLuat = string.Empty;
        private int _maCapQuyetDinh = 0;
        private string _tenCapQuyetDinh = string.Empty;
        
		private string _soQuyetDinih = string.Empty;
		private DateTime _ngayQuyetDinh = DateTime.Today.Date;
		private DateTime _tGBDKyLuat = DateTime.Today.Date;
		private DateTime _tGKTKyLuat = DateTime.Today.Date;
		private string _nguoiKy = string.Empty;
		private short _giamLuongDenHan = 0;
		private long _maNguoiLap = 0;
		private DateTime _ngayLap = DateTime.Today.Date;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaKyLuat
		{
			get
			{
				return _maKyLuat;
			}
		}
        public string TenBoPhan
        {
            get {
                _tenBoPhan = BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;
                return _tenBoPhan; }
            set { _tenBoPhan = value; }
        }



        public string TenHinhThucKyLuat
        {
            get {
                _tenHinhThucKyLuat = HinhThucKyLuat.GetHinhThucKyLuat(_maHinhThucKyLuat).TenKyLyat;
                return _tenHinhThucKyLuat; }
            set { _tenHinhThucKyLuat = value; }
        }


        public string TenCapQuyetDinh
        {
            get {
                _tenCapQuyetDinh = CapQuyetDinh.GetCapQuyetDinh(_maCapQuyetDinh).TenCapQuyetDinh;
                return _tenCapQuyetDinh; }
            set { _tenCapQuyetDinh = value; }
        }
		public int MaBoPhan
		{
			get
			{
				return _maBoPhan;
			}
			set
			{
				if (!_maBoPhan.Equals(value))
				{
					_maBoPhan = value;
                    _tenBoPhan = BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;
					PropertyHasChanged("MaBoPhan");
				}
			}
		}

		public int MaHinhThucKyLuat
		{
			get
			{
				return _maHinhThucKyLuat;
			}
			set
			{
				if (!_maHinhThucKyLuat.Equals(value))
				{
					_maHinhThucKyLuat = value;
                    _tenHinhThucKyLuat = HinhThucKyLuat.GetHinhThucKyLuat(_maHinhThucKyLuat).TenKyLyat;
					PropertyHasChanged("MaHinhThucKyLuat");
				}
			}
		}

		public int MaCapQuyetDinh
		{
			get
			{
				return _maCapQuyetDinh;
			}
			set
			{
				if (!_maCapQuyetDinh.Equals(value))
				{
					_maCapQuyetDinh = value;
                    _tenCapQuyetDinh = CapQuyetDinh.GetCapQuyetDinh(_maCapQuyetDinh).TenCapQuyetDinh;
					PropertyHasChanged("MaCapQuyetDinh");
				}
			}
		}

		public string SoQuyetDinih
		{
			get
			{
				return _soQuyetDinih;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soQuyetDinih.Equals(value))
				{
					_soQuyetDinih = value;
					PropertyHasChanged("SoQuyetDinih");
				}
			}
		}

		public DateTime NgayQuyetDinh
		{
			get
			{
				return _ngayQuyetDinh;
			}
			set
			{
				if (!_ngayQuyetDinh.Equals(value))
				{
					_ngayQuyetDinh = value;
					PropertyHasChanged("NgayQuyetDinh");
				}
			}
		}

		public DateTime TGBDKyLuat
		{
			get
			{
				return _tGBDKyLuat;
			}
			set
			{
				if (!_tGBDKyLuat.Equals(value))
				{
					_tGBDKyLuat = value;
					PropertyHasChanged("TGBDKyLuat");
				}
			}
		}

		public DateTime TGKTKyLuat
		{
			get
			{
				return _tGKTKyLuat;
			}
			set
			{
				if (!_tGKTKyLuat.Equals(value))
				{
					_tGKTKyLuat = value;
					PropertyHasChanged("TGKTKyLuat");
				}
			}
		}

		public string NguoiKy
		{
			get
			{
				return _nguoiKy;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_nguoiKy.Equals(value))
				{
					_nguoiKy = value;
					PropertyHasChanged("NguoiKy");
				}
			}
		}

		public short GiamLuongDenHan
		{
			get
			{
				return _giamLuongDenHan;
			}
			set
			{
				if (!_giamLuongDenHan.Equals(value))
				{
					_giamLuongDenHan = value;
					PropertyHasChanged("GiamLuongDenHan");
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
				return _ngayLap;
			}
			set
			{
				if (!_ngayLap.Equals(value))
				{
					_ngayLap = value;
					PropertyHasChanged("NgayLap");
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
 
		protected override object GetIdValue()
		{
			return _maKyLuat;
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
			// SoQuyetDinih
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoQuyetDinih");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinih", 50));
			//
			// NguoiKy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiKy", 500));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 1024));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private KyLuatTheoNhom()
		{ /* require use of factory method */ }

		public static KyLuatTheoNhom NewKyLuatTheoNhom()
		{
            KyLuatTheoNhom item = new KyLuatTheoNhom();
            item.MarkAsChild();
            return item;
		}

		public static KyLuatTheoNhom GetKyLuatTheoNhom(int maKyLuat)
		{
			return DataPortal.Fetch<KyLuatTheoNhom>(new Criteria(maKyLuat));
		}

		public static void DeleteKyLuatTheoNhom(int maKyLuat)
		{
			DataPortal.Delete(new Criteria(maKyLuat));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static KyLuatTheoNhom NewKyLuatTheoNhomChild()
		{
			KyLuatTheoNhom child = new KyLuatTheoNhom();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static KyLuatTheoNhom GetKyLuatTheoNhom(SafeDataReader dr)
		{
			KyLuatTheoNhom child =  new KyLuatTheoNhom();
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
			public int MaKyLuat;

			public Criteria(int maKyLuat)
			{
				this.MaKyLuat = maKyLuat;
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
				cm.CommandText = "SelecttblnsKyLuatTheoNhom";

				cm.Parameters.AddWithValue("@MaKyLuat", criteria.MaKyLuat);

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
			DataPortal_Delete(new Criteria(_maKyLuat));
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
				cm.CommandText = "DeletetblnsKyLuatTheoNhom";

				cm.Parameters.AddWithValue("@MaKyLuat", criteria.MaKyLuat);

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
			_maKyLuat = dr.GetInt32("MaKyLuat");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_maHinhThucKyLuat = dr.GetInt32("MaHinhThucKyLuat");
			_maCapQuyetDinh = dr.GetInt32("MaCapQuyetDinh");
			_soQuyetDinih = dr.GetString("SoQuyetDinih");
			_ngayQuyetDinh = dr.GetDateTime("NgayQuyetDinh");
			_tGBDKyLuat = dr.GetDateTime("TGBDKyLuat");
			_tGKTKyLuat = dr.GetDateTime("TGKTKyLuat");
			_nguoiKy = dr.GetString("NguoiKy");
			_giamLuongDenHan = dr.GetInt16("GiamLuongDenHan");
			_maNguoiLap = dr.GetInt64("MaNguoiLap");
			_ngayLap = dr.GetDateTime("NgayLap");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, KyLuatTheoNhomList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, KyLuatTheoNhomList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblnsKyLuatTheoNhom";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maKyLuat = (int)cm.Parameters["@MaKyLuat"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, KyLuatTheoNhomList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			cm.Parameters.AddWithValue("@MaHinhThucKyLuat", _maHinhThucKyLuat);
			cm.Parameters.AddWithValue("@MaCapQuyetDinh", _maCapQuyetDinh);
			cm.Parameters.AddWithValue("@SoQuyetDinih", _soQuyetDinih);
				cm.Parameters.AddWithValue("@NgayQuyetDinh", _ngayQuyetDinh);
					cm.Parameters.AddWithValue("@TGBDKyLuat", _tGBDKyLuat);
						cm.Parameters.AddWithValue("@TGKTKyLuat", _tGKTKyLuat);
						if (_nguoiKy.Length > 0)
							cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
						else
							cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
						if (_giamLuongDenHan != 0)
							cm.Parameters.AddWithValue("@GiamLuongDenHan", _giamLuongDenHan);
						else
							cm.Parameters.AddWithValue("@GiamLuongDenHan", DBNull.Value);
						if (_maNguoiLap != 0)
							cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
						else
							cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
							cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
							if (_ghiChu.Length > 0)
								cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
							else
								cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaKyLuat", _maKyLuat);
			cm.Parameters["@MaKyLuat"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, KyLuatTheoNhomList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, KyLuatTheoNhomList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblnsKyLuatTheoNhom";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, KyLuatTheoNhomList parent)
		{
			cm.Parameters.AddWithValue("@MaKyLuat", _maKyLuat);
			cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			cm.Parameters.AddWithValue("@MaHinhThucKyLuat", _maHinhThucKyLuat);
			cm.Parameters.AddWithValue("@MaCapQuyetDinh", _maCapQuyetDinh);
			cm.Parameters.AddWithValue("@SoQuyetDinih", _soQuyetDinih);
			cm.Parameters.AddWithValue("@NgayQuyetDinh", _ngayQuyetDinh);
			cm.Parameters.AddWithValue("@TGBDKyLuat", _tGBDKyLuat);
			cm.Parameters.AddWithValue("@TGKTKyLuat", _tGKTKyLuat);
			if (_nguoiKy.Length > 0)
				cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
			else
				cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
			if (_giamLuongDenHan != 0)
				cm.Parameters.AddWithValue("@GiamLuongDenHan", _giamLuongDenHan);
			else
				cm.Parameters.AddWithValue("@GiamLuongDenHan", DBNull.Value);
			if (_maNguoiLap != 0)
				cm.Parameters.AddWithValue("@MaNguoiLap", _maNguoiLap);
			else
				cm.Parameters.AddWithValue("@MaNguoiLap", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
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

			ExecuteDelete(tr, new Criteria(_maKyLuat));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
