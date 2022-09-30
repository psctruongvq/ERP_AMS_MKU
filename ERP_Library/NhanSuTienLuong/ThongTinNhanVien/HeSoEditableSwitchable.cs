
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HeSo : Csla.BusinessBase<HeSo>
	{
		#region Business Properties and Methods

		//declare members
		private long _maHeSo = 0;
		private int _maKyTinhLuong = 0;
		private long _maNhanVien = 0;
        private double _heSoLuong = 0;
        private string _tenNhanVien =string.Empty;
        private string _tenBoPhan = string.Empty;
        private string  _tenChucVu = string.Empty;
        private string _tenCongViec  = string.Empty;
        private string _maQuanLy = string.Empty;
        private string  _tenKy = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaHeSo
		{
			get
			{
				CanReadProperty("MaHeSo", true);
				return _maHeSo;
			}
		}

        public string  TenNhanVien
		{
			get
			{
				CanReadProperty("TenNhanVien", true);
				return _tenNhanVien;
			}
		}
        public string TenBoPhan
		{
			get
			{
				CanReadProperty("TenBoPhan", true);
				return _tenBoPhan;
			}
		}
        public string TenChucVu
		{
			get
			{
				CanReadProperty("TenChucVu", true);
				return _tenChucVu;
			}
		}
        public string  TenCongViec
		{
			get
			{
				CanReadProperty("TenCongViec", true);
				return _tenCongViec;
			}
		}
        public string  MaQuanLy
		{
			get
			{
				CanReadProperty("MaQuanLy", true);
				return _maQuanLy;
			}
		}public string  TenKy
		{
			get
			{
				CanReadProperty("TenKy", true);
				return _tenKy;
			}
		}


		public int MaKyTinhLuong
		{
			get
			{
				CanReadProperty("MaKyTinhLuong", true);
				return _maKyTinhLuong;
			}
			set
			{
				CanWriteProperty("MaKyTinhLuong", true);
				if (!_maKyTinhLuong.Equals(value))
				{
					_maKyTinhLuong = value;
					PropertyHasChanged("MaKyTinhLuong");
				}
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

        public double HeSoLuong
		{
			get
			{
                CanReadProperty("HeSoLuong", true);
                return _heSoLuong;
			}
			set
			{
                CanWriteProperty("HeSoLuong", true);
                if (!_heSoLuong.Equals(value))
				{
                    _heSoLuong = value;
                    PropertyHasChanged("HeSoLuong");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maHeSo;
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

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in HeSo
			//AuthorizationRules.AllowRead("MaHeSo", "HeSoReadGroup");
			//AuthorizationRules.AllowRead("MaKyTinhLuong", "HeSoReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "HeSoReadGroup");
			//AuthorizationRules.AllowRead("HeSo", "HeSoReadGroup");

			//AuthorizationRules.AllowWrite("MaKyTinhLuong", "HeSoWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "HeSoWriteGroup");
			//AuthorizationRules.AllowWrite("HeSo", "HeSoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HeSo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HeSoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HeSo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HeSoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HeSo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HeSoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HeSo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HeSoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HeSo()
		{ /* require use of factory method */ }

		public static HeSo NewHeSo(long maHeSo)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HeSo");
			return DataPortal.Create<HeSo>(new Criteria(maHeSo));
		}

		public static HeSo GetHeSo(long maHeSo)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HeSo");
			return DataPortal.Fetch<HeSo>(new Criteria(maHeSo));
		}

		public static void DeleteHeSo(long maHeSo)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HeSo");
			DataPortal.Delete(new Criteria(maHeSo));
		}

		public override HeSo Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HeSo");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HeSo");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HeSo");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private HeSo(long maHeSo)
		{
			this._maHeSo = maHeSo;
		}

		internal static HeSo NewHeSoChild(long maHeSo)
		{
			HeSo child = new HeSo(maHeSo);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HeSo GetHeSo(SafeDataReader dr)
		{
			HeSo child =  new HeSo();
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
			public long MaHeSo;

			public Criteria(long maHeSo)
			{
				this.MaHeSo = maHeSo;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maHeSo = criteria.MaHeSo;
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
				cm.CommandText = "GetHeSo";

				cm.Parameters.AddWithValue("@MaHeSo", criteria.MaHeSo);

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
			DataPortal_Delete(new Criteria(_maHeSo));
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
                cm.CommandText = "spd_DeletetblnsHeSo";

				cm.Parameters.AddWithValue("@MaHeSo", criteria.MaHeSo);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maHeSo = dr.GetInt64("MaHeSo");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_heSoLuong = dr.GetDouble("HeSoLuong");
            _maQuanLy = dr.GetString("MaQuanLy");
            _tenKy = dr.GetString("TenKy");
            _tenNhanVien = dr.GetString("TenNhanVien");
            _tenCongViec = dr.GetString("TenCongViec");
            _tenChucVu = dr.GetString("TenChucVu") ;
            _tenBoPhan = dr.GetString("TenBoPhan");
            if (_maHeSo != 0)
                MarkOld();
            else
                MarkNew();
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
                cm.CommandText = "spd_InserttblnsHeSo";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();
                _maHeSo = (long)cm.Parameters["@MaHeSo"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHeSo", _maHeSo);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			
			cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			
            cm.Parameters["@MaHeSo"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsHeSo";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHeSo", _maHeSo);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			
				cm.Parameters.AddWithValue("@HeSoLuong", _heSoLuong);
			
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

			ExecuteDelete(tr, new Criteria(_maHeSo));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
