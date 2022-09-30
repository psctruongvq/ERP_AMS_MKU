
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DungCuLaoDong : Csla.BusinessBase<DungCuLaoDong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maDungCu = 0;
		private string _maQuanLy = string.Empty;
		private string _tenDungCu = string.Empty;
		private int _maLoaiDungCu = 0;
		private int _thoiGianSuDung = 0;
		private bool _suDung = false;
		private string _ghiChu = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;
		private int _nguoiLap = 0;
		private decimal _soTien = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaDungCu
		{
			get
			{
				return _maDungCu;
			}
		}

		public string MaQuanLy
		{
			get
			{
				return _maQuanLy;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_maQuanLy.Equals(value))
				{
					_maQuanLy = value;
					PropertyHasChanged("MaQuanLy");
				}
			}
		}

		public string TenDungCu
		{
			get
			{
				return _tenDungCu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_tenDungCu.Equals(value))
				{
					_tenDungCu = value;
					PropertyHasChanged("TenDungCu");
				}
			}
		}

		public int MaLoaiDungCu
		{
			get
			{
				return _maLoaiDungCu;
			}
			set
			{
				if (!_maLoaiDungCu.Equals(value))
				{
					_maLoaiDungCu = value;
					PropertyHasChanged("MaLoaiDungCu");
				}
			}
		}

		public int ThoiGianSuDung
		{
			get
			{
				return _thoiGianSuDung;
			}
			set
			{
				if (!_thoiGianSuDung.Equals(value))
				{
					_thoiGianSuDung = value;
					PropertyHasChanged("ThoiGianSuDung");
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

		public int NguoiLap
		{
			get
			{
				return _nguoiLap;
			}
			set
			{
				if (!_nguoiLap.Equals(value))
				{
					_nguoiLap = value;
					PropertyHasChanged("NguoiLap");
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
 
		protected override object GetIdValue()
		{
			return _maDungCu;
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
			// MaQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenDungCu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenDungCu", 50));
			//
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 50));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private DungCuLaoDong()
		{ /* require use of factory method */ }

		public static DungCuLaoDong NewDungCuLaoDong()
		{
			return DataPortal.Create<DungCuLaoDong>();
		}

		public static DungCuLaoDong GetDungCuLaoDong(int maDungCu)
		{
			return DataPortal.Fetch<DungCuLaoDong>(new Criteria(maDungCu));
		}

		public static void DeleteDungCuLaoDong(int maDungCu)
		{
			DataPortal.Delete(new Criteria(maDungCu));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static DungCuLaoDong NewDungCuLaoDongChild()
		{
			DungCuLaoDong child = new DungCuLaoDong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DungCuLaoDong GetDungCuLaoDong(SafeDataReader dr)
		{
			DungCuLaoDong child =  new DungCuLaoDong();
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
			public int MaDungCu;

			public Criteria(int maDungCu)
			{
				this.MaDungCu = maDungCu;
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
				cm.CommandText = "SelecttblnsDungCuLaoDong";

				cm.Parameters.AddWithValue("@MaDungCu", criteria.MaDungCu);

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
			DataPortal_Delete(new Criteria(_maDungCu));
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
				cm.CommandText = "DeletetblnsDungCuLaoDong";

				cm.Parameters.AddWithValue("@MaDungCu", criteria.MaDungCu);

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
			_maDungCu = dr.GetInt32("MaDungCu");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenDungCu = dr.GetString("TenDungCu");
			_maLoaiDungCu = dr.GetInt32("MaLoaiDungCu");
			_thoiGianSuDung = dr.GetInt32("ThoiGianSuDung");
			_suDung = dr.GetBoolean("SuDung");
			_ghiChu = dr.GetString("GhiChu");
			_ngayLap = dr.GetDateTime("NgayLap");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_soTien = dr.GetDecimal("SoTien");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, DungCuLaoDongList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, DungCuLaoDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblnsDungCuLaoDong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maDungCu = (int)cm.Parameters["@MaDungCu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DungCuLaoDongList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenDungCu.Length > 0)
				cm.Parameters.AddWithValue("@TenDungCu", _tenDungCu);
			else
				cm.Parameters.AddWithValue("@TenDungCu", DBNull.Value);
			if (_maLoaiDungCu != 0)
				cm.Parameters.AddWithValue("@MaLoaiDungCu", _maLoaiDungCu);
			else
				cm.Parameters.AddWithValue("@MaLoaiDungCu", DBNull.Value);
			if (_thoiGianSuDung != 0)
				cm.Parameters.AddWithValue("@ThoiGianSuDung", _thoiGianSuDung);
			else
				cm.Parameters.AddWithValue("@ThoiGianSuDung", DBNull.Value);
			if (_suDung != false)
				cm.Parameters.AddWithValue("@SuDung", _suDung);
			else
				cm.Parameters.AddWithValue("@SuDung", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_nguoiLap != 0)
					cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
				else
					cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
				if (_soTien != 0)
					cm.Parameters.AddWithValue("@SoTien", _soTien);
				else
					cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			cm.Parameters.AddWithValue("@MaDungCu", _maDungCu);
			cm.Parameters["@MaDungCu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, DungCuLaoDongList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, DungCuLaoDongList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblnsDungCuLaoDong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DungCuLaoDongList parent)
		{
			cm.Parameters.AddWithValue("@MaDungCu", _maDungCu);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenDungCu.Length > 0)
				cm.Parameters.AddWithValue("@TenDungCu", _tenDungCu);
			else
				cm.Parameters.AddWithValue("@TenDungCu", DBNull.Value);
			if (_maLoaiDungCu != 0)
				cm.Parameters.AddWithValue("@MaLoaiDungCu", _maLoaiDungCu);
			else
				cm.Parameters.AddWithValue("@MaLoaiDungCu", DBNull.Value);
			if (_thoiGianSuDung != 0)
				cm.Parameters.AddWithValue("@ThoiGianSuDung", _thoiGianSuDung);
			else
				cm.Parameters.AddWithValue("@ThoiGianSuDung", DBNull.Value);
			if (_suDung != false)
				cm.Parameters.AddWithValue("@SuDung", _suDung);
			else
				cm.Parameters.AddWithValue("@SuDung", DBNull.Value);
			if (_ghiChu.Length > 0)
				cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
			else
				cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maDungCu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
