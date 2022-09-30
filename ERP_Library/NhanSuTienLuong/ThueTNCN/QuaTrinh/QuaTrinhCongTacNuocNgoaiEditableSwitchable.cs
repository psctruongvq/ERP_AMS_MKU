
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class CongTacNuocNgoai : Csla.BusinessBase<CongTacNuocNgoai>
	{
		#region Business Properties and Methods

		//declare members
		private int _maCongTac = 0;
		private long _maNhanVien = 0;
		private string _tenNhanVien = string.Empty;
		private int _maBoPhan = 0;
		private string _tenBoPhan = string.Empty;
		private string _soQuyetDinh = string.Empty;
		private string _nguoiQuyetDinh = string.Empty;
		private int _maQuocGiaDen = 0;
		private string _lyDo = string.Empty;
		private DateTime _tuNgay = DateTime.Today;
		private DateTime _denNgay = DateTime.Today;
		private decimal _soTien = 0;
		private int _maNguon = 0;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaCongTac
		{
			get
			{
				return _maCongTac;
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
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
                    _maBoPhan = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).MaBoPhan;
                    _tenBoPhan = BoPhan.GetBoPhan(_maBoPhan).TenBoPhan;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public string TenNhanVien
		{
			get
			{
				return _tenNhanVien;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenNhanVien.Equals(value))
				{
					_tenNhanVien = value;
					PropertyHasChanged("TenNhanVien");
				}
			}
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

		public string TenBoPhan
		{
			get
			{
				return _tenBoPhan;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenBoPhan.Equals(value))
				{
					_tenBoPhan = value;
					PropertyHasChanged("TenBoPhan");
				}
			}
		}

		public string SoQuyetDinh
		{
			get
			{
				return _soQuyetDinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soQuyetDinh.Equals(value))
				{
					_soQuyetDinh = value;
					PropertyHasChanged("SoQuyetDinh");
				}
			}
		}

		public string NguoiQuyetDinh
		{
			get
			{
				return _nguoiQuyetDinh;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_nguoiQuyetDinh.Equals(value))
				{
					_nguoiQuyetDinh = value;
					PropertyHasChanged("NguoiQuyetDinh");
				}
			}
		}

		public int MaQuocGiaDen
		{
			get
            {
                CanReadProperty("MaQuocGiaDen", true);
				return _maQuocGiaDen;
			}
			set
			{
				if (!_maQuocGiaDen.Equals(value))
				{
					_maQuocGiaDen = value;
					PropertyHasChanged("MaQuocGiaDen");
				}
			}
		}

		public string LyDo
		{
			get
			{
				return _lyDo;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_lyDo.Equals(value))
				{
					_lyDo = value;
					PropertyHasChanged("LyDo");
				}
			}
		}

		public DateTime TuNgay
		{
			get
			{
				return _tuNgay;
			}
			set
			{
				if (!_tuNgay.Equals(value))
				{
					_tuNgay = value;
					PropertyHasChanged("TuNgay");
				}
			}
		}

		public DateTime DenNgay
		{
			get
			{
				return _denNgay;
			}
			set
			{
				if (!_denNgay.Equals(value))
				{
					_denNgay = value;
					PropertyHasChanged("DenNgay");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				return _soTien;
			}
			set
			{
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
				}
			}
		}

		public int MaNguon
		{
			get
            {
                CanReadProperty("MaNguon", true);
				return _maNguon;
			}
			set
			{
				if (!_maNguon.Equals(value))
				{
					_maNguon = value;
					PropertyHasChanged("MaNguon");
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
			return _maCongTac;
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
			// TenNhanVien
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNhanVien", 50));
			//
			// TenBoPhan
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenBoPhan", 50));
			//
			// SoQuyetDinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 50));
			//
			// NguoiQuyetDinh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguoiQuyetDinh", 50));
			//
			// LyDo
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 500));
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

		#region Factory Methods
		private CongTacNuocNgoai()
		{ /* require use of factory method */ }

		public static CongTacNuocNgoai NewCongTacNuocNgoai()
		{
            CongTacNuocNgoai item = new CongTacNuocNgoai();
            item.MarkAsChild();
            return item;
		}

		public static CongTacNuocNgoai GetCongTacNuocNgoai(int maCongTac)
		{
			return DataPortal.Fetch<CongTacNuocNgoai>(new Criteria(maCongTac));
		}

		public static void DeleteCongTacNuocNgoai(int maCongTac)
		{
			DataPortal.Delete(new Criteria(maCongTac));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static CongTacNuocNgoai NewCongTacNuocNgoaiChild()
		{
			CongTacNuocNgoai child = new CongTacNuocNgoai();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static CongTacNuocNgoai GetCongTacNuocNgoai(SafeDataReader dr)
		{
			CongTacNuocNgoai child =  new CongTacNuocNgoai();
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
			public int MaCongTac;

			public Criteria(int maCongTac)
			{
				this.MaCongTac = maCongTac;
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
				cm.CommandText = "SelecttblnsQuaTrinhCongTacNuocNgoai";

				cm.Parameters.AddWithValue("@MaCongTac", criteria.MaCongTac);

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
			DataPortal_Delete(new Criteria(_maCongTac));
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
				cm.CommandText = "DeletetblnsQuaTrinhCongTacNuocNgoai";

				cm.Parameters.AddWithValue("@MaCongTac", criteria.MaCongTac);

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
			_maCongTac = dr.GetInt32("MaCongTac");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_tenBoPhan = dr.GetString("TenBoPhan");
			_soQuyetDinh = dr.GetString("SoQuyetDinh");
			_nguoiQuyetDinh = dr.GetString("NguoiQuyetDinh");
			_maQuocGiaDen = dr.GetInt32("MaQuocGiaDen");
			_lyDo = dr.GetString("LyDo");
			_tuNgay = dr.GetDateTime("TuNgay");
			_denNgay = dr.GetDateTime("DenNgay");
			_soTien = dr.GetDecimal("SoTien");
			_maNguon = dr.GetInt32("MaNguon");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, CongTacNuocNgoaiList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, CongTacNuocNgoaiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblnsQuaTrinhCongTacNuocNgoai";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maCongTac = (int)cm.Parameters["@MaCongTac"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, CongTacNuocNgoaiList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            NhanVien nv = NhanVien.GetNhanVien(_maNhanVien);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);			
				cm.Parameters.AddWithValue("@TenNhanVien", nv.TenNhanVien);
				cm.Parameters.AddWithValue("@MaBoPhan", nv.MaBoPhan);	
				cm.Parameters.AddWithValue("@TenBoPhan", nv.TenBoPhan);
			
			if (_soQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			else
				cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
			if (_nguoiQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@NguoiQuyetDinh", _nguoiQuyetDinh);
			else
				cm.Parameters.AddWithValue("@NguoiQuyetDinh", DBNull.Value);
			if (_maQuocGiaDen != 0)
				cm.Parameters.AddWithValue("@MaQuocGiaDen", _maQuocGiaDen);
			else
				cm.Parameters.AddWithValue("@MaQuocGiaDen", DBNull.Value);
			if (_lyDo.Length > 0)
				cm.Parameters.AddWithValue("@LyDo", _lyDo);
			else
				cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
			
				cm.Parameters.AddWithValue("@TuNgay", _tuNgay);
			
			
				cm.Parameters.AddWithValue("@DenNgay", _denNgay);
		
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaCongTac", _maCongTac);
			cm.Parameters["@MaCongTac"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, CongTacNuocNgoaiList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, CongTacNuocNgoaiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblnsQuaTrinhCongTacNuocNgoai";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, CongTacNuocNgoaiList parent)
		{
            NhanVien nv = NhanVien.GetNhanVien(_maNhanVien);
			cm.Parameters.AddWithValue("@MaCongTac", _maCongTac);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@TenNhanVien", nv.TenNhanVien);
            cm.Parameters.AddWithValue("@MaBoPhan", nv.MaBoPhan);
            cm.Parameters.AddWithValue("@TenBoPhan", nv.TenBoPhan);
			if (_soQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
			else
				cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);
			if (_nguoiQuyetDinh.Length > 0)
				cm.Parameters.AddWithValue("@NguoiQuyetDinh", _nguoiQuyetDinh);
			else
				cm.Parameters.AddWithValue("@NguoiQuyetDinh", DBNull.Value);
			if (_maQuocGiaDen != 0)
				cm.Parameters.AddWithValue("@MaQuocGiaDen", _maQuocGiaDen);
			else
				cm.Parameters.AddWithValue("@MaQuocGiaDen", DBNull.Value);
			if (_lyDo.Length > 0)
				cm.Parameters.AddWithValue("@LyDo", _lyDo);
			else
				cm.Parameters.AddWithValue("@LyDo", DBNull.Value);
            cm.Parameters.AddWithValue("@TuNgay", _tuNgay);

            cm.Parameters.AddWithValue("@DenNgay", _denNgay);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maCongTac));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
