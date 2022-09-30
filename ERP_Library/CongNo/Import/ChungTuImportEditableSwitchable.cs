
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChungTuImport : Csla.BusinessBase<ChungTuImport>
	{
		#region Business Properties and Methods

		//declare members
		private long _maChungTu = 0;
		private string _soChungTu = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;
		private int _mucNganSach = 0;
		private long _maDoiTuong = 0;
		private int _maLoaiChungTu = 0;
		private string _dienGiai = string.Empty;
		private int _maDoiTuongThuChi = 0;
		private int _maBoPhan = 0;
		private decimal _soTien = 0;
		private decimal _tyGia = 0;
		private decimal _thanhTien = 0;
		private bool _ghiSoCai = false;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaChungTu
		{
			get
			{
				return _maChungTu;
			}
		}

		public string SoChungTu
		{
			get
			{
				return _soChungTu;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_soChungTu.Equals(value))
				{
					_soChungTu = value;
					PropertyHasChanged("SoChungTu");
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

		public int MucNganSach
		{
			get
			{
				return _mucNganSach;
			}
			set
			{
				if (!_mucNganSach.Equals(value))
				{
					_mucNganSach = value;
					PropertyHasChanged("MucNganSach");
				}
			}
		}

		public long MaDoiTuong
		{
			get
			{
				return _maDoiTuong;
			}
			set
			{
				if (!_maDoiTuong.Equals(value))
				{
					_maDoiTuong = value;
					PropertyHasChanged("MaDoiTuong");
				}
			}
		}

		public int MaLoaiChungTu
		{
			get
			{
				return _maLoaiChungTu;
			}
			set
			{
				if (!_maLoaiChungTu.Equals(value))
				{
					_maLoaiChungTu = value;
					PropertyHasChanged("MaLoaiChungTu");
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

		public int MaDoiTuongThuChi
		{
			get
			{
				return _maDoiTuongThuChi;
			}
			set
			{
				if (!_maDoiTuongThuChi.Equals(value))
				{
					_maDoiTuongThuChi = value;
					PropertyHasChanged("MaDoiTuongThuChi");
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
					PropertyHasChanged("MaBoPhan");
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

		public decimal TyGia
		{
			get
			{
				return _tyGia;
			}
			set
			{
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
				return _thanhTien;
			}
			set
			{
				if (!_thanhTien.Equals(value))
				{
					_thanhTien = value;
					PropertyHasChanged("ThanhTien");
				}
			}
		}

		public bool GhiSoCai
		{
			get
			{
				return _ghiSoCai;
			}
			set
			{
				if (!_ghiSoCai.Equals(value))
				{
					_ghiSoCai = value;
					PropertyHasChanged("GhiSoCai");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChungTu;
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
			// SoChungTu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "SoChungTu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoChungTu", 50));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 2000));
		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Factory Methods
		private ChungTuImport()
		{ /* require use of factory method */ }

		public static ChungTuImport NewChungTuImport()
		{
			return DataPortal.Create<ChungTuImport>();
		}

		public static ChungTuImport GetChungTuImport(long maChungTu)
		{
			return DataPortal.Fetch<ChungTuImport>(new Criteria(maChungTu));
		}

		public static void DeleteChungTuImport(long maChungTu)
		{
			DataPortal.Delete(new Criteria(maChungTu));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChungTuImport NewChungTuImportChild()
		{
			ChungTuImport child = new ChungTuImport();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChungTuImport GetChungTuImport(SafeDataReader dr)
		{
			ChungTuImport child =  new ChungTuImport();
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
			public long MaChungTu;

			public Criteria(long maChungTu)
			{
				this.MaChungTu = maChungTu;
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
				cm.CommandText = "SelecttblChungTuImport";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
			DataPortal_Delete(new Criteria(_maChungTu));
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
				cm.CommandText = "DeletetblChungTuImport";

				cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
			_maChungTu = dr.GetInt64("MaChungTu");
			_soChungTu = dr.GetString("SoChungTu");
			_ngayLap = dr.GetDateTime("NgayLap");
			_mucNganSach = dr.GetInt32("MucNganSach");
			_maDoiTuong = dr.GetInt64("MaDoiTuong");
			_maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
			_dienGiai = dr.GetString("DienGiai");
			_maDoiTuongThuChi = dr.GetInt32("MaDoiTuongThuChi");
			_maBoPhan = dr.GetInt32("MaBoPhan");
			_soTien = dr.GetDecimal("SoTien");
			_tyGia = dr.GetDecimal("TyGia");
			_thanhTien = dr.GetDecimal("ThanhTien");
			_ghiSoCai = dr.GetBoolean("GhiSoCai");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, ChungTuImportList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, ChungTuImportList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblChungTuImport";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maChungTu = (long)cm.Parameters["@MaChungTu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, ChungTuImportList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_mucNganSach != 0)
					cm.Parameters.AddWithValue("@MucNganSach", _mucNganSach);
				else
					cm.Parameters.AddWithValue("@MucNganSach", DBNull.Value);
				if (_maDoiTuong != 0)
					cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
				else
					cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
				if (_maLoaiChungTu != 0)
					cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
				else
					cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
				if (_dienGiai.Length > 0)
					cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
				else
					cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
				if (_maDoiTuongThuChi != 0)
					cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _maDoiTuongThuChi);
				else
					cm.Parameters.AddWithValue("@MaDoiTuongThuChi", DBNull.Value);
				if (_maBoPhan != 0)
					cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
				else
					cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
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
				if (_ghiSoCai != false)
					cm.Parameters.AddWithValue("@GhiSoCai", _ghiSoCai);
				else
					cm.Parameters.AddWithValue("@GhiSoCai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, ChungTuImportList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, ChungTuImportList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblChungTuImport";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, ChungTuImportList parent)
		{
			cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_mucNganSach != 0)
				cm.Parameters.AddWithValue("@MucNganSach", _mucNganSach);
			else
				cm.Parameters.AddWithValue("@MucNganSach", DBNull.Value);
			if (_maDoiTuong != 0)
				cm.Parameters.AddWithValue("@MaDoiTuong", _maDoiTuong);
			else
				cm.Parameters.AddWithValue("@MaDoiTuong", DBNull.Value);
			if (_maLoaiChungTu != 0)
				cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
			else
				cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maDoiTuongThuChi != 0)
				cm.Parameters.AddWithValue("@MaDoiTuongThuChi", _maDoiTuongThuChi);
			else
				cm.Parameters.AddWithValue("@MaDoiTuongThuChi", DBNull.Value);
			if (_maBoPhan != 0)
				cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
			else
				cm.Parameters.AddWithValue("@MaBoPhan", DBNull.Value);
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
			if (_ghiSoCai != false)
				cm.Parameters.AddWithValue("@GhiSoCai", _ghiSoCai);
			else
				cm.Parameters.AddWithValue("@GhiSoCai", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maChungTu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
