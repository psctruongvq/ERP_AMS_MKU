
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NgachLuongNoiBo : Csla.BusinessBase<NgachLuongNoiBo>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNgachLuongNoiBo = 0;
		private string _maQuanLy = string.Empty;
		private decimal _thoiGianNangBac = 0;
		private string _donViThoiGian = string.Empty;
		private int _maChucVu = 0;
        private int _MaNhomNgachLuongBaoHiem = 0;
		private string _dienGiai = string.Empty;
        string _TenNgachLuongBaoHiem = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNgachLuongNoiBo
		{
			get
			{
				CanReadProperty("MaNgachLuongNoiBo", true);
				return _maNgachLuongNoiBo;
			}
		}
        public string TenNgachLuongBaoHiem
        {
            get
            {
                CanReadProperty("TenNgachLuongBaoHiem", true);
                return _TenNgachLuongBaoHiem;
            }
            set
            {
                CanWriteProperty("TenNgachLuongBaoHiem", true);
                if (value == null) value = string.Empty;
                if (!_TenNgachLuongBaoHiem.Equals(value))
                {
                    _TenNgachLuongBaoHiem = value;
                    PropertyHasChanged("TenNgachLuongBaoHiem");
                }
            }
        }
		
        public string MaQuanLy
        {
            get
            {
                CanReadProperty("MaQuanLy", true);
                return _maQuanLy;
            }
            set
            {
                CanWriteProperty("MaQuanLy", true);
                if (value == null) value = string.Empty;
                if (!_maQuanLy.Equals(value))
                {
                    _maQuanLy = value;
                    PropertyHasChanged("MaQuanLy");
                }
            }
        }
		public decimal ThoiGianNangBac
		{
			get
			{
				CanReadProperty("ThoiGianNangBac", true);
				return _thoiGianNangBac;
			}
			set
			{
				CanWriteProperty("ThoiGianNangBac", true);
				if (!_thoiGianNangBac.Equals(value))
				{
					_thoiGianNangBac = value;
					PropertyHasChanged("ThoiGianNangBac");
				}
			}
		}

		public string DonViThoiGian
		{
			get
			{
				CanReadProperty("DonViThoiGian", true);
				return _donViThoiGian;
			}
			set
			{
				CanWriteProperty("DonViThoiGian", true);
				if (value == null) value = string.Empty;
				if (!_donViThoiGian.Equals(value))
				{
					_donViThoiGian = value;
					PropertyHasChanged("DonViThoiGian");
				}
			}
		}

		public int MaChucVu
		{
			get
			{
				CanReadProperty("MaChucVu", true);
				return _maChucVu;
			}
			set
			{
				CanWriteProperty("MaChucVu", true);
				if (!_maChucVu.Equals(value))
				{
					_maChucVu = value;
					PropertyHasChanged("MaChucVu");
				}
			}
		}
        public int MaNhomNgachLuongBaoHiem
        {
            get
            {
                CanReadProperty("MaNhomNgachLuongBaoHiem", true);
                return _MaNhomNgachLuongBaoHiem;
            }
            set
            {
                CanWriteProperty("MaNhomNgachLuongBaoHiem", true);
                if (!_MaNhomNgachLuongBaoHiem.Equals(value))
                {
                    _MaNhomNgachLuongBaoHiem = value;
                    PropertyHasChanged("MaNhomNgachLuongBaoHiem");
                }
            }
        }
		public string DienGiai
		{
			get
			{
				CanReadProperty("DienGiai", true);
				return _dienGiai;
			}
			set
			{
				CanWriteProperty("DienGiai", true);
				if (value == null) value = string.Empty;
				if (!_dienGiai.Equals(value))
				{
					_dienGiai = value;
					PropertyHasChanged("DienGiai");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maNgachLuongNoiBo;
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
			//ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// DonViThoiGian
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DonViThoiGian", 50));
			//
			// DienGiai
			//
		//	ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 4000));
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
			//TODO: Define authorization rules in NgachLuongNoiBo
			//AuthorizationRules.AllowRead("MaNgachLuongNoiBo", "NgachLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "NgachLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("ThoiGianNangBac", "NgachLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("DonViThoiGian", "NgachLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("MaChucVu", "NgachLuongNoiBoReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "NgachLuongNoiBoReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "NgachLuongNoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("ThoiGianNangBac", "NgachLuongNoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("DonViThoiGian", "NgachLuongNoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("MaChucVu", "NgachLuongNoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "NgachLuongNoiBoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NgachLuongNoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongNoiBoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NgachLuongNoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongNoiBoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NgachLuongNoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongNoiBoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NgachLuongNoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgachLuongNoiBoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NgachLuongNoiBo()
		{ /* require use of factory method */ }

		public static NgachLuongNoiBo NewNgachLuongNoiBo()
		{
            NgachLuongNoiBo child = new NgachLuongNoiBo();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
		}

		public static NgachLuongNoiBo GetNgachLuongNoiBo(int maNgachLuongNoiBo)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NgachLuongNoiBo");
			return DataPortal.Fetch<NgachLuongNoiBo>(new Criteria(maNgachLuongNoiBo));
		}

		public static void DeleteNgachLuongNoiBo(int maNgachLuongNoiBo)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NgachLuongNoiBo");
			DataPortal.Delete(new Criteria(maNgachLuongNoiBo));
		}

		public override NgachLuongNoiBo Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NgachLuongNoiBo");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgachLuongNoiBo");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NgachLuongNoiBo");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NgachLuongNoiBo NewNgachLuongNoiBoChild()
		{
			NgachLuongNoiBo child = new NgachLuongNoiBo();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NgachLuongNoiBo GetNgachLuongNoiBo(SafeDataReader dr)
		{
			NgachLuongNoiBo child =  new NgachLuongNoiBo();
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
			public int MaNgachLuongNoiBo;

			public Criteria(int maNgachLuongNoiBo)
			{
				this.MaNgachLuongNoiBo = maNgachLuongNoiBo;
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
                cm.CommandText = "spd_SelecttblnsNgachLuongNoiBo";

				cm.Parameters.AddWithValue("@MaNgachLuongNoiBo", criteria.MaNgachLuongNoiBo);

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
			DataPortal_Delete(new Criteria(_maNgachLuongNoiBo));
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
                cm.CommandText = "spd_DeletetblnsNgachLuongNoiBo";

				cm.Parameters.AddWithValue("@MaNgachLuongNoiBo", criteria.MaNgachLuongNoiBo);

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
			_maNgachLuongNoiBo = dr.GetInt32("MaNgachLuongNoiBo");
			_maQuanLy = dr.GetString("MaQuanLy");
            
			_thoiGianNangBac = dr.GetDecimal("ThoiGianNangBac");
			_donViThoiGian = dr.GetString("DonViThoiGian");
			_maChucVu = dr.GetInt32("MaChucVu");
			_dienGiai = dr.GetString("DienGiai");
            _MaNhomNgachLuongBaoHiem = dr.GetInt32("MaNhomNgachLuongBaoHiem");
            _TenNgachLuongBaoHiem = dr.GetString("TenNgachLuongBaoHiem");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, NgachLuongNoiBoList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, NgachLuongNoiBoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsNgachLuongNoiBo";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maNgachLuongNoiBo = (int)cm.Parameters["@MaNgachLuongNoiBo"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, NgachLuongNoiBoList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_thoiGianNangBac != 0)
				cm.Parameters.AddWithValue("@ThoiGianNangBac", _thoiGianNangBac);
			else
				cm.Parameters.AddWithValue("@ThoiGianNangBac", DBNull.Value);
			if (_donViThoiGian.Length > 0)
				cm.Parameters.AddWithValue("@DonViThoiGian", _donViThoiGian);
			else
				cm.Parameters.AddWithValue("@DonViThoiGian", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", _maNgachLuongNoiBo);
            cm.Parameters.AddWithValue("@MaNgachLuongNoiBo", _maNgachLuongNoiBo);
            cm.Parameters.AddWithValue("@TenNgachLuongBaoHiem", _TenNgachLuongBaoHiem);
			cm.Parameters["@MaNgachLuongNoiBo"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, NgachLuongNoiBoList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, NgachLuongNoiBoList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsNgachLuongNoiBo";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, NgachLuongNoiBoList parent)
		{
            cm.Parameters.AddWithValue("@TenNgachLuongBaoHiem", _TenNgachLuongBaoHiem);
            cm.Parameters.AddWithValue("@MaNhomNgachLuongBaoHiem", _MaNhomNgachLuongBaoHiem);
			cm.Parameters.AddWithValue("@MaNgachLuongNoiBo", _maNgachLuongNoiBo);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			if (_thoiGianNangBac != 0)
				cm.Parameters.AddWithValue("@ThoiGianNangBac", _thoiGianNangBac);
			else
				cm.Parameters.AddWithValue("@ThoiGianNangBac", DBNull.Value);
			if (_donViThoiGian.Length > 0)
				cm.Parameters.AddWithValue("@DonViThoiGian", _donViThoiGian);
			else
				cm.Parameters.AddWithValue("@DonViThoiGian", DBNull.Value);
			if (_maChucVu != 0)
				cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			else
				cm.Parameters.AddWithValue("@MaChucVu", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maNgachLuongNoiBo));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
