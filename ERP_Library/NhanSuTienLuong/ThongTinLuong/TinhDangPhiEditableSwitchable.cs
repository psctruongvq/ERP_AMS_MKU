
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TinhDangPhi : Csla.BusinessBase<TinhDangPhi>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTinhDangPhi = 0;
		private long _maNhanVien = 0;
		private int _maKyTinhLuong = 0;
		private decimal _soTienPhuCap = 0;
		private decimal _soTienLuongV2 = 0;
		private decimal _soTienThuLao = 0;
		private decimal _soTienDongDangPhi = 0;
        private string _TenNhanVien = string.Empty;
        private decimal _soTienTinhDangPhi = 0;
      
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTinhDangPhi
		{
			get
			{
				return _maTinhDangPhi;
			}
		}

		public long MaNhanVien
		{
			get
			{
				return _maNhanVien;
			}
			set
			{
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}
        public string TenNhanVien
        {
            get {
                _TenNhanVien = TTNhanVienRutGon.GetTTNhanVienRutGon(_maNhanVien).TenNhanVien;
                return _TenNhanVien; }

        }
		public int MaKyTinhLuong
		{
			get
			{
				return _maKyTinhLuong;
			}
			set
			{
				if (!_maKyTinhLuong.Equals(value))
				{
					_maKyTinhLuong = value;
					PropertyHasChanged("MaKyTinhLuong");
				}
			}
		}

		public decimal SoTienPhuCap
		{
			get
			{
				return _soTienPhuCap;
			}
			set
			{
				if (!_soTienPhuCap.Equals(value))
				{
					_soTienPhuCap = value;
					PropertyHasChanged("SoTienPhuCap");
				}
			}
		}

		public decimal SoTienLuongV2
		{
			get
			{
				return _soTienLuongV2;
			}
			set
			{
				if (!_soTienLuongV2.Equals(value))
				{
					_soTienLuongV2 = value;
					PropertyHasChanged("SoTienLuongV2");
				}
			}
		}

		public decimal SoTienThuLao
		{
			get
			{
				return _soTienThuLao;
			}
			set
			{
				if (!_soTienThuLao.Equals(value))
				{
					_soTienThuLao = value;
					PropertyHasChanged("SoTienThuLao");
				}
			}
		}
        public decimal SoTienTinhDangPhi
        {
            get
            {
                return _soTienTinhDangPhi;
            }
            set
            {
                if (!_soTienTinhDangPhi.Equals(value))
                {
                    _soTienTinhDangPhi = value;
                    PropertyHasChanged("SoTienTinhDangPhi");
                }
            }
        }
		public decimal SoTienDongDangPhi
		{
			get
			{
				return _soTienDongDangPhi;
			}
			set
			{
				if (!_soTienDongDangPhi.Equals(value))
				{
					_soTienDongDangPhi = value;
					PropertyHasChanged("SoTienDongDangPhi");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTinhDangPhi;
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

		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TinhDangPhi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhDangPhiViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TinhDangPhi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhDangPhiAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TinhDangPhi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhDangPhiEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TinhDangPhi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhDangPhiDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TinhDangPhi()
		{ /* require use of factory method */ }

		public static TinhDangPhi NewTinhDangPhi()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TinhDangPhi");
			return DataPortal.Create<TinhDangPhi>();
		}

		public static TinhDangPhi GetTinhDangPhi(int maTinhDangPhi)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TinhDangPhi");
			return DataPortal.Fetch<TinhDangPhi>(new Criteria(maTinhDangPhi));
		}

		public static void DeleteTinhDangPhi(int maTinhDangPhi)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TinhDangPhi");
			DataPortal.Delete(new Criteria(maTinhDangPhi));
		}
        public static void XuLyTinhDangPhi(int maKyTinhLuong, long maNhanVien)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_InserttblnsNhanVien_DangPhi";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", maKyTinhLuong);
                        cm.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);                        
                        cm.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    throw ex;
                }

            }
        }   
   
		public override TinhDangPhi Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TinhDangPhi");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TinhDangPhi");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TinhDangPhi");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TinhDangPhi NewTinhDangPhiChild()
		{
			TinhDangPhi child = new TinhDangPhi();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TinhDangPhi GetTinhDangPhi(SafeDataReader dr)
		{
			TinhDangPhi child =  new TinhDangPhi();
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
			public int MaTinhDangPhi;

			public Criteria(int maTinhDangPhi)
			{
				this.MaTinhDangPhi = maTinhDangPhi;
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
                cm.CommandText = "spd_SelecttblnsNhanVien_DangPhi";

				cm.Parameters.AddWithValue("@MaTinhDangPhi", criteria.MaTinhDangPhi);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					dr.Read();
					FetchObject(dr);
					//ValidationRules.CheckRules();

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
			DataPortal_Delete(new Criteria(_maTinhDangPhi));
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
            //using (SqlCommand cm = tr.Connection.CreateCommand())
            //{
            //    cm.Transaction = tr;
            //    cm.CommandType = CommandType.StoredProcedure;
            //    cm.CommandText = "spd_DeletetblnsNhanVien_DangPhi";

            //    cm.Parameters.AddWithValue("@MaTinhDangPhi", criteria.MaTinhDangPhi);

            //    cm.ExecuteNonQuery();
            //}//using
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
			_maTinhDangPhi = dr.GetInt32("MaTinhDangPhi");
			_maNhanVien = dr.GetInt64("MaNhanVien");
			_maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
			_soTienPhuCap = dr.GetDecimal("SoTienPhuCap");
			_soTienLuongV2 = dr.GetDecimal("SoTienLuongV2");
			_soTienThuLao = dr.GetDecimal("SoTienThuLao");
            _soTienTinhDangPhi = dr.GetDecimal("SoTienTinhDangPhi");
            _soTienDongDangPhi = dr.GetDecimal("SoTienDongDangPhi");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, TinhDangPhiList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, TinhDangPhiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNhanVien_DangPhi";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTinhDangPhi = (int)cm.Parameters["@MaTinhDangPhi"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TinhDangPhiList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
			if (_soTienPhuCap != 0)
				cm.Parameters.AddWithValue("@SoTienPhuCap", _soTienPhuCap);
			else
				cm.Parameters.AddWithValue("@SoTienPhuCap", DBNull.Value);
			if (_soTienLuongV2 != 0)
				cm.Parameters.AddWithValue("@SoTienLuongV2", _soTienLuongV2);
			else
				cm.Parameters.AddWithValue("@SoTienLuongV2", DBNull.Value);
			if (_soTienThuLao != 0)
				cm.Parameters.AddWithValue("@SoTienThuLao", _soTienThuLao);
			else
				cm.Parameters.AddWithValue("@SoTienThuLao", DBNull.Value);
			if (_soTienDongDangPhi != 0)
				cm.Parameters.AddWithValue("@SoTienDongDangPhi", _soTienDongDangPhi);
			else
				cm.Parameters.AddWithValue("@SoTienDongDangPhi", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTinhDangPhi", _maTinhDangPhi);
			cm.Parameters["@MaTinhDangPhi"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, TinhDangPhiList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, TinhDangPhiList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNhanVien_DangPhi";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TinhDangPhiList parent)
		{
			cm.Parameters.AddWithValue("@MaTinhDangPhi", _maTinhDangPhi);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			if (_maKyTinhLuong != 0)
				cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
			else
				cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
			if (_soTienPhuCap != 0)
				cm.Parameters.AddWithValue("@SoTienPhuCap", _soTienPhuCap);
			else
				cm.Parameters.AddWithValue("@SoTienPhuCap", DBNull.Value);
			if (_soTienLuongV2 != 0)
				cm.Parameters.AddWithValue("@SoTienLuongV2", _soTienLuongV2);
			else
				cm.Parameters.AddWithValue("@SoTienLuongV2", DBNull.Value);
			if (_soTienThuLao != 0)
				cm.Parameters.AddWithValue("@SoTienThuLao", _soTienThuLao);
			else
				cm.Parameters.AddWithValue("@SoTienThuLao", DBNull.Value);
			if (_soTienDongDangPhi != 0)
				cm.Parameters.AddWithValue("@SoTienDongDangPhi", _soTienDongDangPhi);
			else
				cm.Parameters.AddWithValue("@SoTienDongDangPhi", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maTinhDangPhi));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
