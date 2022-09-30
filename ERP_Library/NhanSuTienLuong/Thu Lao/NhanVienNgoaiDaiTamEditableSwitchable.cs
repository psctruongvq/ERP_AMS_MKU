
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhanVienNgoaiDaiTam : Csla.BusinessBase<NhanVienNgoaiDaiTam>
	{
		#region Business Properties and Methods

		//declare members
		private long _maNhanVien = 0;
		private string _tenNhanVien = string.Empty;
		private string _cmnd = string.Empty;
		private string _mst = string.Empty;
		private string _diaChi = string.Empty;
		private string _dienThoai = string.Empty;
		private DateTime _ngayLap = DateTime.Today.Date;
		private int _nguoiLap = 0;
		private decimal _soTien = 0;
		private string _ghiChuThuLao = string.Empty;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public long MaNhanVien
		{
			get
			{
				return _maNhanVien;
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

		public string Cmnd
		{
			get
			{
				return _cmnd;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_cmnd.Equals(value))
				{
					_cmnd = value;
					PropertyHasChanged("Cmnd");
				}
			}
		}

		public string Mst
		{
			get
			{
				return _mst;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_mst.Equals(value))
				{
					_mst = value;
					PropertyHasChanged("Mst");
				}
			}
		}

		public string DiaChi
		{
			get
			{
				return _diaChi;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_diaChi.Equals(value))
				{
					_diaChi = value;
					PropertyHasChanged("DiaChi");
				}
			}
		}

		public string DienThoai
		{
			get
			{
				return _dienThoai;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_dienThoai.Equals(value))
				{
					_dienThoai = value;
					PropertyHasChanged("DienThoai");
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

		public string GhiChuThuLao
		{
			get
			{
				return _ghiChuThuLao;
			}
			set
			{
				if (value == null) value = string.Empty;
				if (!_ghiChuThuLao.Equals(value))
				{
					_ghiChuThuLao = value;
					PropertyHasChanged("GhiChuThuLao");
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
			return _maNhanVien;
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
			// Cmnd
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "Cmnd");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Cmnd", 50));
			//
			// Mst
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Mst", 50));
			//
			// DiaChi
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DiaChi", 500));
			//
			// DienThoai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienThoai", 50));
			//
			// GhiChuThuLao
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChuThuLao", 500));
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
		private NhanVienNgoaiDaiTam()
		{ /* require use of factory method */ }

		public static NhanVienNgoaiDaiTam NewNhanVienNgoaiDaiTam()
		{
			return DataPortal.Create<NhanVienNgoaiDaiTam>();
		}

		public static NhanVienNgoaiDaiTam GetNhanVienNgoaiDaiTam(long maNhanVien)
		{
			return DataPortal.Fetch<NhanVienNgoaiDaiTam>(new Criteria(maNhanVien));
		}

		public static void DeleteNhanVienNgoaiDaiTam(long maNhanVien)
		{
			DataPortal.Delete(new Criteria(maNhanVien));
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NhanVienNgoaiDaiTam NewNhanVienNgoaiDaiTamChild()
		{
			NhanVienNgoaiDaiTam child = new NhanVienNgoaiDaiTam();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhanVienNgoaiDaiTam GetNhanVienNgoaiDaiTam(SafeDataReader dr)
		{
			NhanVienNgoaiDaiTam child =  new NhanVienNgoaiDaiTam();
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
			public long MaNhanVien;

			public Criteria(long maNhanVien)
			{
				this.MaNhanVien = maNhanVien;
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
				cm.CommandText = "SelecttblnsNhanVienNgoaiDai_Tam";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
			DataPortal_Delete(new Criteria(_maNhanVien));
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
				cm.CommandText = "DeletetblnsNhanVienNgoaiDai_Tam";

				cm.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);

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
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_tenNhanVien = dr.GetString("TenNhanVien");
			_cmnd = dr.GetString("CMND");
			_mst = dr.GetString("MST");
			_diaChi = dr.GetString("DiaChi");
			_dienThoai = dr.GetString("DienThoai");
			_ngayLap = dr.GetDateTime("NgayLap");
			_nguoiLap = dr.GetInt32("NguoiLap");
			_soTien = dr.GetDecimal("SoTien");
			_ghiChuThuLao = dr.GetString("GhiChuThuLao");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NhanVienNgoaiDaiTamList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NhanVienNgoaiDaiTamList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblnsNhanVienNgoaiDai_Tam";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNhanVien = (long)cm.Parameters["@MaNhanVien"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NhanVienNgoaiDaiTamList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@CMND", _cmnd);
			if (_mst.Length > 0)
				cm.Parameters.AddWithValue("@MST", _mst);
			else
				cm.Parameters.AddWithValue("@MST", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_dienThoai.Length > 0)
				cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
			else
				cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
				cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
				if (_nguoiLap != 0)
					cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
				else
					cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
				if (_soTien != 0)
					cm.Parameters.AddWithValue("@SoTien", _soTien);
				else
					cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
				if (_ghiChuThuLao.Length > 0)
					cm.Parameters.AddWithValue("@GhiChuThuLao", _ghiChuThuLao);
				else
					cm.Parameters.AddWithValue("@GhiChuThuLao", DBNull.Value);
				if (_ghiChu.Length > 0)
					cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
				else
					cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			cm.Parameters["@MaNhanVien"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NhanVienNgoaiDaiTamList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NhanVienNgoaiDaiTamList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblnsNhanVienNgoaiDai_Tam";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NhanVienNgoaiDaiTamList parent)
		{
			cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			if (_tenNhanVien.Length > 0)
				cm.Parameters.AddWithValue("@TenNhanVien", _tenNhanVien);
			else
				cm.Parameters.AddWithValue("@TenNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@CMND", _cmnd);
			if (_mst.Length > 0)
				cm.Parameters.AddWithValue("@MST", _mst);
			else
				cm.Parameters.AddWithValue("@MST", DBNull.Value);
			if (_diaChi.Length > 0)
				cm.Parameters.AddWithValue("@DiaChi", _diaChi);
			else
				cm.Parameters.AddWithValue("@DiaChi", DBNull.Value);
			if (_dienThoai.Length > 0)
				cm.Parameters.AddWithValue("@DienThoai", _dienThoai);
			else
				cm.Parameters.AddWithValue("@DienThoai", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
			if (_soTien != 0)
				cm.Parameters.AddWithValue("@SoTien", _soTien);
			else
				cm.Parameters.AddWithValue("@SoTien", DBNull.Value);
			if (_ghiChuThuLao.Length > 0)
				cm.Parameters.AddWithValue("@GhiChuThuLao", _ghiChuThuLao);
			else
				cm.Parameters.AddWithValue("@GhiChuThuLao", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maNhanVien));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
