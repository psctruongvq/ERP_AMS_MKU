
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChucVu : Csla.BusinessBase<ChucVu>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChucVu = 0;
		private string _tenChucVu = string.Empty;
		private string _maQLChucVu = string.Empty;
		private string _tenVietTat = string.Empty;
        //private string _tenNhomChucVu = string.Empty;
		//private int _maNhomChucVu = 0;
		private string _dienGiai = string.Empty;

        //public override string ToString()
        //{
        //    return _tenChucVu;
        //}

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChucVu
		{
			get
			{
				CanReadProperty("MaChucVu", true);
				return _maChucVu;
			}
		}

		public string TenChucVu
		{
			get
			{
				CanReadProperty("TenChucVu", true);
				return _tenChucVu;
			}
			set
			{
				CanWriteProperty("TenChucVu", true);
				if (value == null) value = string.Empty;
				if (!_tenChucVu.Equals(value))
				{
					_tenChucVu = value;
					PropertyHasChanged("TenChucVu");
				}
			}
		}

		public string MaQLChucVu
		{
			get
			{
				CanReadProperty("MaQLChucVu", true);
				return _maQLChucVu;
			}
			set
			{
				CanWriteProperty("MaQLChucVu", true);
				if (value == null) value = string.Empty;
				if (!_maQLChucVu.Equals(value))
				{
					_maQLChucVu = value;
					PropertyHasChanged("MaQLChucVu");
				}
			}
		}

		public string TenVietTat
		{
			get
			{
				CanReadProperty("TenVietTat", true);
				return _tenVietTat;
			}
			set
			{
				CanWriteProperty("TenVietTat", true);
				if (value == null) value = string.Empty;
				if (!_tenVietTat.Equals(value))
				{
					_tenVietTat = value;
					PropertyHasChanged("TenVietTat");
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
			return _maChucVu;
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
			// TenChucVu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenChucVu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenChucVu", 500));
			//
			// MaQLChucVu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "MaQLChucVu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQLChucVu", 50));
			//
			// TenVietTat
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenVietTat", 50));
			//
			// DienGiai
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 500));
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
			//TODO: Define authorization rules in ChucVu
			//AuthorizationRules.AllowRead("MaChucVu", "ChucVuReadGroup");
			//AuthorizationRules.AllowRead("TenChucVu", "ChucVuReadGroup");
			//AuthorizationRules.AllowRead("MaQLChucVu", "ChucVuReadGroup");
			//AuthorizationRules.AllowRead("TenVietTat", "ChucVuReadGroup");
			//AuthorizationRules.AllowRead("MaNhomChucVu", "ChucVuReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "ChucVuReadGroup");

			//AuthorizationRules.AllowWrite("TenChucVu", "ChucVuWriteGroup");
			//AuthorizationRules.AllowWrite("MaQLChucVu", "ChucVuWriteGroup");
			//AuthorizationRules.AllowWrite("TenVietTat", "ChucVuWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhomChucVu", "ChucVuWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "ChucVuWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChucVu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucVuViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChucVu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucVuAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChucVu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucVuEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChucVu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChucVuDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChucVu()
		{ /* require use of factory method */ }

		public static ChucVu NewChucVu()
		{
            ChucVu item = new ChucVu();
            item.MarkAsChild();
            return item;
		}

        public static ChucVu NewChucVu(int _maChucVu, string _tenChucVu)
        {
            return new ChucVu(_maChucVu, _tenChucVu);
        }
        private ChucVu (int _maChucVu, string _tenChucVu)
        {
            this._maChucVu = _maChucVu;
            this._tenChucVu = _tenChucVu;
            MarkAsChild();
        }
		public static ChucVu GetChucVu(int maChucVu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChucVu");
			return DataPortal.Fetch<ChucVu>(new Criteria(maChucVu));
		}
        public static ChucVu GetChucVuTheoNhanVien(long maNhanVien)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChucVu");
            return DataPortal.Fetch<ChucVu>(new CriteriaByMaNV(maNhanVien));
        }        

		public static void DeleteChucVu(int maChucVu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChucVu");
			DataPortal.Delete(new Criteria(maChucVu));
		}

		public override ChucVu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChucVu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChucVu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChucVu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChucVu NewChucVuChild()
		{
			ChucVu child = new ChucVu();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChucVu GetChucVu(SafeDataReader dr)
		{
			ChucVu child =  new ChucVu();
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
			public int MaChucVu;

			public Criteria(int maChucVu)
			{
				this.MaChucVu = maChucVu;
			}
		}
        private class CriteriaByMaNV
        {
            public long MaNhanVien;

            public CriteriaByMaNV(long maNV)
            {
                this.MaNhanVien = maNV;
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
		protected override void DataPortal_Fetch(object criteria)
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, object criteria)
		{
            if (criteria is Criteria)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsChucVu";

                    cm.Parameters.AddWithValue("@MaChucVu",((Criteria)criteria).MaChucVu);

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
            else if (criteria is CriteriaByMaNV)
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsByMaNV";

                    cm.Parameters.AddWithValue("@MaNhanVien", ((CriteriaByMaNV)criteria).MaNhanVien);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            FetchObject(dr);
                        }
                    }
                }//using
            }
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteInsert(cn);

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
					ExecuteUpdate(cn);
				}

				//update child object(s)
				UpdateChildren(cn);
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maChucVu));
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
                cm.CommandText = "spd_DeletetblnsChucVu";

				cm.Parameters.AddWithValue("@MaChucVu", criteria.MaChucVu);

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
            try
            {
                _maChucVu = dr.GetInt32("MaChucVu");
                _tenChucVu = dr.GetString("TenChucVu");
                _maQLChucVu = dr.GetString("MaQLChucVu");
                _tenVietTat = dr.GetString("TenVietTat");
             
                _dienGiai = dr.GetString("DienGiai");
            }
            catch (Exception ex)
            {
                throw ex;
            }
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlConnection cn)
		{
			if (!IsDirty) return;

			ExecuteInsert(cn);
			MarkOld();

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteInsert(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsChucVu";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maChucVu = (int)cm.Parameters["@MaChucVu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			cm.Parameters.AddWithValue("@MaQLChucVu", _maQLChucVu);
			if (_tenVietTat.Length > 0)
				cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
			else
				cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
			
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters["@MaChucVu"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlConnection cn)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(cn);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(cn);
		}

		private void ExecuteUpdate(SqlConnection cn)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsChucVu";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaChucVu", _maChucVu);
			cm.Parameters.AddWithValue("@TenChucVu", _tenChucVu);
			cm.Parameters.AddWithValue("@MaQLChucVu", _maQLChucVu);
			if (_tenVietTat.Length > 0)
				cm.Parameters.AddWithValue("@TenVietTat", _tenVietTat);
			else
				cm.Parameters.AddWithValue("@TenVietTat", DBNull.Value);
			
			if (_dienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maChucVu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
