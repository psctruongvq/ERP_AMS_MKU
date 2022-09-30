
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TieuMucNganSach : Csla.BusinessBase<TieuMucNganSach>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTieuMuc = 0;
		private string _maQuanLy = string.Empty;
		private string _tenTieuMuc = string.Empty;
		private string _dienGiai = string.Empty;
        private int _maMucNganSach = 0;
		private decimal _soTienTieuMuc = 0;
        private bool _chon = false;
        private string _MaMucNganSachQL = string.Empty;
        private string _TenMucNganSach = string.Empty;
             

        public bool Chon
        {
            get { return _chon; }
            set { _chon = value; }
        }

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTieuMuc
		{
			get
			{
				CanReadProperty("MaTieuMuc", true);
				return _maTieuMuc;
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

		public string TenTieuMuc
		{
			get
			{
				CanReadProperty("TenTieuMuc", true);
				return _tenTieuMuc;
			}
			set
			{
				CanWriteProperty("TenTieuMuc", true);
				if (value == null) value = string.Empty;
				if (!_tenTieuMuc.Equals(value))
				{
					_tenTieuMuc = value;
					PropertyHasChanged("TenTieuMuc");
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

		public int MaMucNganSach
		{
			get
			{
				CanReadProperty("MaMucNganSach", true);
				return _maMucNganSach;
			}
			set
			{
				CanWriteProperty("MaMucNganSach", true);
				if (!_maMucNganSach.Equals(value))
				{
					_maMucNganSach = value;
					PropertyHasChanged("MaMucNganSach");
				}
			}
		}

		public decimal SoTienTieuMuc
		{
			get
			{
				CanReadProperty("SoTienTieuMuc", true);
				return _soTienTieuMuc;
			}
			set
			{
				CanWriteProperty("SoTienTieuMuc", true);
				if (!_soTienTieuMuc.Equals(value))
				{
					_soTienTieuMuc = value;
					PropertyHasChanged("SoTienTieuMuc");
				}
			}
		}
        public string MaMucNganSachQL
        {
            get
            {
                CanReadProperty("MaMucNganSachQL", true);
                return _MaMucNganSachQL;
            }
         
        }

        public string TenMucNganSach
        {
            get
            {
                CanReadProperty("TenMucNganSach", true);
                return _TenMucNganSach;
            }

        }
		protected override object GetIdValue()
		{
			return _maTieuMuc;
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
			
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			
            // TenTieuMuc
			
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTieuMuc", 500));
			
            // DienGiai
			
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
			
            // MaMucNganSach
			
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaMucNganSach", 50));
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
			//TODO: Define authorization rules in TieuMucNganSach
			//AuthorizationRules.AllowRead("MaTieuMuc", "TieuMucNganSachReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "TieuMucNganSachReadGroup");
			//AuthorizationRules.AllowRead("TenTieuMuc", "TieuMucNganSachReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "TieuMucNganSachReadGroup");
			//AuthorizationRules.AllowRead("MaMucNganSach", "TieuMucNganSachReadGroup");
			//AuthorizationRules.AllowRead("SoTienTieuMuc", "TieuMucNganSachReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "TieuMucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("TenTieuMuc", "TieuMucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "TieuMucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("MaMucNganSach", "TieuMucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("SoTienTieuMuc", "TieuMucNganSachWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TieuMucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuMucNganSachViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TieuMucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuMucNganSachAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TieuMucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuMucNganSachEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TieuMucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TieuMucNganSachDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TieuMucNganSach()
		{ /* require use of factory method */ }

		public static TieuMucNganSach NewTieuMucNganSach()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TieuMucNganSach");
			return DataPortal.Create<TieuMucNganSach>();
		}

        public static TieuMucNganSach NewTieuMucNganSach(string maTieuMuc, string TenTieuMuc)
        {
            TieuMucNganSach tm = TieuMucNganSach.NewTieuMucNganSach();
           
            tm.TenTieuMuc = TenTieuMuc;
            tm.MarkAsChild();
            return tm;
        }
		public static TieuMucNganSach GetTieuMucNganSach(int maTieuMuc)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TieuMucNganSach");
			return DataPortal.Fetch<TieuMucNganSach>(new Criteria(maTieuMuc));
		}
        public static TieuMucNganSach GetTieuMucNganSachByMaQuanLy(string maQuanLy)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a TieuMucNganSach");
            return DataPortal.Fetch<TieuMucNganSach>(new CriteriaByMaQuanLy(maQuanLy));
        }
		public static void DeleteTieuMucNganSach(int maTieuMuc)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TieuMucNganSach");
			DataPortal.Delete(new Criteria(maTieuMuc));
		}

		public override TieuMucNganSach Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TieuMucNganSach");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TieuMucNganSach");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TieuMucNganSach");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TieuMucNganSach NewTieuMucNganSachChild()
		{
			TieuMucNganSach child = new TieuMucNganSach();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TieuMucNganSach GetTieuMucNganSach(SafeDataReader dr)
		{
			TieuMucNganSach child =  new TieuMucNganSach();
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
			public int MaTieuMuc;

			public Criteria(int maTieuMuc)
			{
				this.MaTieuMuc = maTieuMuc;
			}
		}
        private class CriteriaByMaQuanLy
        {
            public string MaQuanLy;

            public CriteriaByMaQuanLy(string maQuanLy)
            {
                this.MaQuanLy = maQuanLy;
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
		private void DataPortal_Fetch(object criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

                ExecuteFetch(cn, criteria);

			}//using
		}

        private void ExecuteFetch(SqlConnection cn, object criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
                if (criteria is Criteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTieuMucNganSach";

                    cm.Parameters.AddWithValue("@MaTieuMuc", ((Criteria)criteria).MaTieuMuc);
                }
                if (criteria is CriteriaByMaQuanLy)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblTieuMucNganSachByMaQuanLy";

                    cm.Parameters.AddWithValue("@MaQuanLy", ((CriteriaByMaQuanLy)criteria).MaQuanLy);              
                }
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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn, null);

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				if (base.IsDirty)
				{
					ExecuteUpdate(cn, null);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maTieuMuc));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteDelete(cn, criteria);

			}//using

		}

		private void ExecuteDelete(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblTieuMucNganSach";

				cm.Parameters.AddWithValue("@MaTieuMuc", criteria.MaTieuMuc);

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
			_maTieuMuc = dr.GetInt32("MaTieuMuc");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenTieuMuc = dr.GetString("TenTieuMuc");
			_dienGiai = dr.GetString("DienGiai");
			_maMucNganSach = dr.GetInt32("MaMucNganSach");
			_soTienTieuMuc = dr.GetDecimal("SoTienTieuMuc");
            _MaMucNganSachQL = dr.GetString("MaMucNganSachQL");
            _TenMucNganSach = dr.GetString("TenMucNganSach");
            _chon = false;
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn, TieuMucNganSachList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn, TieuMucNganSachList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblTieuMucNganSach";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maTieuMuc = (int)cm.Parameters["@MaTieuMuc"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, TieuMucNganSachList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenTieuMuc.Length > 0)
				cm.Parameters.AddWithValue("@TenTieuMuc", _tenTieuMuc);
			else
				cm.Parameters.AddWithValue("@TenTieuMuc", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maMucNganSach != 0)
				cm.Parameters.AddWithValue("@MaMucNganSach", _maMucNganSach);
			else
				cm.Parameters.AddWithValue("@MaMucNganSach", DBNull.Value);
			if (_soTienTieuMuc != 0)
				cm.Parameters.AddWithValue("@SoTienTieuMuc", _soTienTieuMuc);
			else
				cm.Parameters.AddWithValue("@SoTienTieuMuc", DBNull.Value);
			cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			cm.Parameters["@MaTieuMuc"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn, TieuMucNganSachList parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn, TieuMucNganSachList parent)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblTieuMucNganSach";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, TieuMucNganSachList parent)
		{
			cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenTieuMuc.Length > 0)
				cm.Parameters.AddWithValue("@TenTieuMuc", _tenTieuMuc);
			else
				cm.Parameters.AddWithValue("@TenTieuMuc", DBNull.Value);
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			if (_maMucNganSach != 0)
				cm.Parameters.AddWithValue("@MaMucNganSach", _maMucNganSach);
			else
				cm.Parameters.AddWithValue("@MaMucNganSach", DBNull.Value);
			if (_soTienTieuMuc != 0)
				cm.Parameters.AddWithValue("@SoTienTieuMuc", _soTienTieuMuc);
			else
				cm.Parameters.AddWithValue("@SoTienTieuMuc", DBNull.Value);
		}

		private void UpdateChildren(SqlConnection cn)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlConnection cn)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(cn, new Criteria(_maTieuMuc));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
