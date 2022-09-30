
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TinhThanh : Csla.BusinessBase<TinhThanh>
	{
		#region Business Properties and Methods
        
		//declare members
		private int _maTinhThanh = 0;
		private string _maTinhThanhQuanLy = string.Empty;
		private string _tenTinhThanh = string.Empty;
		private string _dienGiai = string.Empty;
		private int _maKhuVuc = 0;
        private int _maQuocGia = 0;

        public int MaQuocGia
        {
            get
            {
                CanReadProperty("MaQuocGia", true);
                _maQuocGia = KhuVuc.GetKhuVuc(_maKhuVuc).MaQuocGia;
                return _maQuocGia;
            }
            set
            {
                CanWriteProperty("MaQuocGia", true);
                if (!_maQuocGia.Equals(value))
                {
                    _maQuocGia = value;
                    PropertyHasChanged("MaQuocGia");
                }
            }
        }

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTinhThanh
		{
			get
			{
				CanReadProperty("MaTinhThanh", true);
				return _maTinhThanh;
			}
		}

		public string MaTinhThanhQuanLy
		{
			get
			{
				CanReadProperty("MaTinhThanhQuanLy", true);
				return _maTinhThanhQuanLy;
			}
			set
			{
				CanWriteProperty("MaTinhThanhQuanLy", true);
				if (value == null) value = string.Empty;
				if (!_maTinhThanhQuanLy.Equals(value))
				{
					_maTinhThanhQuanLy = value;
					PropertyHasChanged("MaTinhThanhQuanLy");
				}
			}
		}

		public string TenTinhThanh
		{
			get
			{
				CanReadProperty("TenTinhThanh", true);
				return _tenTinhThanh;
			}
			set
			{
				CanWriteProperty("TenTinhThanh", true);
				if (value == null) value = string.Empty;
				if (!_tenTinhThanh.Equals(value))
				{
					_tenTinhThanh = value;
					PropertyHasChanged("TenTinhThanh");
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

		public int MaKhuVuc
		{
			get
			{
				CanReadProperty("MaKhuVuc", true);
				return _maKhuVuc;
			}
			set
			{
				CanWriteProperty("MaKhuVuc", true);
				if (!_maKhuVuc.Equals(value))
				{
					_maKhuVuc = value;
					PropertyHasChanged("MaKhuVuc");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTinhThanh;
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
			// MaTinhThanhQuanLy
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaTinhThanhQuanLy", 20));
			//
			// TenTinhThanh
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTinhThanh", 500));
			//
			// DienGiai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in TinhThanh
			//AuthorizationRules.AllowRead("MaTinhThanh", "TinhThanhReadGroup");
			//AuthorizationRules.AllowRead("MaTinhThanhQuanLy", "TinhThanhReadGroup");
			//AuthorizationRules.AllowRead("TenTinhThanh", "TinhThanhReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "TinhThanhReadGroup");
			//AuthorizationRules.AllowRead("MaKhuVuc", "TinhThanhReadGroup");

			//AuthorizationRules.AllowWrite("MaTinhThanhQuanLy", "TinhThanhWriteGroup");
			//AuthorizationRules.AllowWrite("TenTinhThanh", "TinhThanhWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "TinhThanhWriteGroup");
			//AuthorizationRules.AllowWrite("MaKhuVuc", "TinhThanhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TinhThanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhThanhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TinhThanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhThanhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TinhThanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhThanhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TinhThanh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TinhThanhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TinhThanh()
		{ /* require use of factory method */ }

        private TinhThanh(string tenTinh)
        {
            this.TenTinhThanh = tenTinh;
        }
        private TinhThanh(int matinhthanh,string tenTinhthanh)
        {
            this._maTinhThanh = matinhthanh;
            this._tenTinhThanh = tenTinhthanh;
        }

        public static TinhThanh NewTinhThanh(string maQuanLy)
        {
            return new TinhThanh(maQuanLy);
        }
        public static TinhThanh NewTinhThanh(int matinhthanh,string Tentinhthanh)
        {
            return new TinhThanh(matinhthanh, Tentinhthanh);
        }

		public static TinhThanh NewTinhThanh()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TinhThanh");
			return DataPortal.Create<TinhThanh>();
		}

		public static TinhThanh GetTinhThanh(int maTinhThanh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TinhThanh");
			return DataPortal.Fetch<TinhThanh>(new Criteria(maTinhThanh));
		}

		public static void DeleteTinhThanh(int maTinhThanh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TinhThanh");
			DataPortal.Delete(new Criteria(maTinhThanh));
		}

		public override TinhThanh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TinhThanh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TinhThanh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TinhThanh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TinhThanh NewTinhThanhChild()
		{
			TinhThanh child = new TinhThanh();
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TinhThanh GetTinhThanh(SafeDataReader dr)
		{
			TinhThanh child =  new TinhThanh();
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
			public int MaTinhThanh;

			public Criteria(int maTinhThanh)
			{
				this.MaTinhThanh = maTinhThanh;
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
				catch (Exception ex)
				{
					tr.Rollback();
					throw ex;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblTinhThanh";

				cm.Parameters.AddWithValue("@MaTinhThanh", criteria.MaTinhThanh);

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
			DataPortal_Delete(new Criteria(_maTinhThanh));
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
                cm.CommandText = "spd_DeletetblTinhThanh";

				cm.Parameters.AddWithValue("@MaTinhThanh", criteria.MaTinhThanh);

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
			_maTinhThanh = dr.GetInt32("MaTinhThanh");
			_maTinhThanhQuanLy = dr.GetString("MaTinhThanhQuanLy");
			_tenTinhThanh = dr.GetString("TenTinhThanh");
			_dienGiai = dr.GetString("DienGiai");
			_maKhuVuc = dr.GetInt32("MaKhuVuc");
            _maQuocGia = dr.GetInt32("MaQuocGia");
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
                cm.CommandText = "spd_InserttblTinhThanh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maTinhThanh = (int)cm.Parameters["@MaTinhThanh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maTinhThanhQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaTinhThanhQuanLy", _maTinhThanhQuanLy);
			else
				cm.Parameters.AddWithValue("@MaTinhThanhQuanLy", DBNull.Value);
			if (_tenTinhThanh.Length > 0)
				cm.Parameters.AddWithValue("@TenTinhThanh", _tenTinhThanh);
			else
				cm.Parameters.AddWithValue("@TenTinhThanh", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maKhuVuc != 0)
				cm.Parameters.AddWithValue("@MaKhuVuc", _maKhuVuc);
			else
				cm.Parameters.AddWithValue("@MaKhuVuc", DBNull.Value);
            cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
			cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
			cm.Parameters["@MaTinhThanh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblTinhThanh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
			if (_maTinhThanhQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaTinhThanhQuanLy", _maTinhThanhQuanLy);
			else
				cm.Parameters.AddWithValue("@MaTinhThanhQuanLy", DBNull.Value);
			if (_tenTinhThanh.Length > 0)
				cm.Parameters.AddWithValue("@TenTinhThanh", _tenTinhThanh);
			else
				cm.Parameters.AddWithValue("@TenTinhThanh", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maKhuVuc != 0)
				cm.Parameters.AddWithValue("@MaKhuVuc", _maKhuVuc);
			else
				cm.Parameters.AddWithValue("@MaKhuVuc", DBNull.Value);
            cm.Parameters.AddWithValue("@MaQuocGia", _maQuocGia);
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

			ExecuteDelete(tr, new Criteria(_maTinhThanh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
