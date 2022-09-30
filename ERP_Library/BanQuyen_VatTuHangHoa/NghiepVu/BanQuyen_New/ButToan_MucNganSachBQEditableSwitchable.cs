
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
//08/11/2013
namespace ERP_Library
{ 
	[Serializable()] 
	public class ButToan_MucNganSachBQ : Csla.BusinessBase<ButToan_MucNganSachBQ>
	{
		#region Business Properties and Methods

		//declare members
		private int _maButToanMucNganSach = 0;
		private int _maButToan = 0;
		private int _maTieuMuc = 0;
		private decimal _soTien = 0;
		private string _dienGiai = string.Empty;

        private long _maCT_ChiPhiSanXuat = 0;
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaButToanMucNganSach
		{
			get
			{
				CanReadProperty("MaButToanMucNganSach", true);
				return _maButToanMucNganSach;
			}
		}

		public int MaButToan
		{
			get
			{
				CanReadProperty("MaButToan", true);
				return _maButToan;
			}
			set
			{
				CanWriteProperty("MaButToan", true);
				if (!_maButToan.Equals(value))
				{
					_maButToan = value;
					PropertyHasChanged("MaButToan");
				}
			}
		}

		public int MaTieuMuc
		{
			get
			{
				CanReadProperty("MaTieuMuc", true);
				return _maTieuMuc;
			}
			set
			{
				CanWriteProperty("MaTieuMuc", true);
				if (!_maTieuMuc.Equals(value))
				{
					_maTieuMuc = value;
					PropertyHasChanged("MaTieuMuc");
				}
			}
		}

		public decimal SoTien
		{
			get
			{
				CanReadProperty("SoTien", true);
				return _soTien;
			}
			set
			{
				CanWriteProperty("SoTien", true);
				if (!_soTien.Equals(value))
				{
					_soTien = value;
					PropertyHasChanged("SoTien");
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

        public long MaCT_ChiPhiSanXuat
        {
            get
            {
                CanReadProperty("MaCT_ChiPhiSanXuat", true);
                return _maCT_ChiPhiSanXuat;
            }
        }
 
		protected override object GetIdValue()
		{
			return _maButToanMucNganSach;
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

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in ButToan_MucNganSach
			//AuthorizationRules.AllowRead("MaButToanMucNganSach", "ButToan_MucNganSachReadGroup");
			//AuthorizationRules.AllowRead("MaButToan", "ButToan_MucNganSachReadGroup");
			//AuthorizationRules.AllowRead("MaTieuMuc", "ButToan_MucNganSachReadGroup");
			//AuthorizationRules.AllowRead("SoTien", "ButToan_MucNganSachReadGroup");
			//AuthorizationRules.AllowRead("DienGiai", "ButToan_MucNganSachReadGroup");

			//AuthorizationRules.AllowWrite("MaButToan", "ButToan_MucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("MaTieuMuc", "ButToan_MucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("SoTien", "ButToan_MucNganSachWriteGroup");
			//AuthorizationRules.AllowWrite("DienGiai", "ButToan_MucNganSachWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ButToan_MucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ButToan_MucNganSachViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ButToan_MucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ButToan_MucNganSachAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ButToan_MucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ButToan_MucNganSachEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ButToan_MucNganSach
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ButToan_MucNganSachDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
        private ButToan_MucNganSachBQ()
		{ /* require use of factory method */ }

        public static ButToan_MucNganSachBQ NewButToan_MucNganSach()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ButToan_MucNganSach");
            return DataPortal.Create<ButToan_MucNganSachBQ>();
		}

        public static ButToan_MucNganSachBQ GetButToan_MucNganSach(int maButToanMucNganSach)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ButToan_MucNganSach");
            return DataPortal.Fetch<ButToan_MucNganSachBQ>(new Criteria(maButToanMucNganSach));
		}

        public static ButToan_MucNganSachBQ GetButToan_MucNganSachByMaButToan(int maButToan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ButToan_MucNganSach");
            return DataPortal.Fetch<ButToan_MucNganSachBQ>(new CriteriaByMaButToan(maButToan));
        }

		public static void DeleteButToan_MucNganSach(int maButToanMucNganSach)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ButToan_MucNganSach");
			DataPortal.Delete(new Criteria(maButToanMucNganSach));
		}

        public override ButToan_MucNganSachBQ Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ButToan_MucNganSach");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ButToan_MucNganSach");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ButToan_MucNganSach");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
        internal static ButToan_MucNganSachBQ NewButToan_MucNganSachChild()
		{
            ButToan_MucNganSachBQ child = new ButToan_MucNganSachBQ();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

        internal static ButToan_MucNganSachBQ GetButToan_MucNganSach(SafeDataReader dr)
		{
            ButToan_MucNganSachBQ child = new ButToan_MucNganSachBQ();
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
			public int MaButToanMucNganSach;

			public Criteria(int maButToanMucNganSach)
			{
				this.MaButToanMucNganSach = maButToanMucNganSach;
			}
		}

        private class CriteriaByMaButToan
        {
            public int MaButToan;

            public CriteriaByMaButToan(int maButToan)
            {
                this.MaButToan= maButToan;
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
		private void DataPortal_Fetch(Object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_LoadMaCaBiet_ButToan_MucNganSach";
                    cm.Parameters.AddWithValue("@MaButToanMucNganSach", ((Criteria)criteria).MaButToanMucNganSach);
                }
                else if (criteria is CriteriaByMaButToan)
                {
                    cm.CommandText = "spd_SelecttblButToan_MucNganSachesByAndMaButToan";
                    cm.Parameters.AddWithValue("@MaButToan", ((CriteriaByMaButToan)criteria).MaButToan);
                }
				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();
                    }

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
			DataPortal_Delete(new Criteria(_maButToanMucNganSach));
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
                cm.CommandText = "spd_Delete_ButToan_MucNganSach";

				cm.Parameters.AddWithValue("@MaButToanMucNganSach", criteria.MaButToanMucNganSach);

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
			_maButToanMucNganSach = dr.GetInt32("MaButToanMucNganSach");
			_maButToan = dr.GetInt32("MaButToan");
			_maTieuMuc = dr.GetInt32("MaTieuMuc");
			_soTien = dr.GetDecimal("SoTien");
			_dienGiai = dr.GetString("DienGiai");

            _maCT_ChiPhiSanXuat = dr.GetInt64("MaCT_ChiPhiSanXuat");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
        internal void Insert(SqlTransaction tr, ButToanPhieuNhapXuatBQ parent)
		{
			if (!IsDirty || _maTieuMuc == 0) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, ButToanPhieuNhapXuatBQ parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Insert_ButToan_MucNganSach";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maButToanMucNganSach = (int)cm.Parameters["@MaButToanMucNganSach"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, ButToanPhieuNhapXuatBQ parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maButToan = parent.MaButToan;
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			cm.Parameters.AddWithValue("@SoTien", parent.SoTien);
            if (parent.DienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", parent.DienGiai);
			else
				cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
			cm.Parameters.AddWithValue("@MaButToanMucNganSach", _maButToanMucNganSach);
			cm.Parameters["@MaButToanMucNganSach"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
        internal void Update(SqlTransaction tr, ButToanPhieuNhapXuatBQ parent)
		{
            //if (!IsDirty) return;

            //if (base.IsDirty)
            //{
				ExecuteUpdate(tr, parent);
				MarkOld();
            //}

			//update child object(s)
			UpdateChildren(tr);
		}

        private void ExecuteUpdate(SqlTransaction tr, ButToanPhieuNhapXuatBQ parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Update_ButToan_MucNganSach";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, ButToanPhieuNhapXuatBQ parent)
		{
			cm.Parameters.AddWithValue("@MaButToanMucNganSach", _maButToanMucNganSach);
			cm.Parameters.AddWithValue("@MaButToan", _maButToan);
			cm.Parameters.AddWithValue("@MaTieuMuc", _maTieuMuc);
			cm.Parameters.AddWithValue("@SoTien", parent.SoTien);
            if (parent.DienGiai.Length > 0)
				cm.Parameters.AddWithValue("@DienGiai", parent.DienGiai);
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
			
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maButToanMucNganSach));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
