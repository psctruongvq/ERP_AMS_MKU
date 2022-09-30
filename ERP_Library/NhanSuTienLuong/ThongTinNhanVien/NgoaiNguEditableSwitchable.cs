
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NgoaiNgu : Csla.BusinessBase<NgoaiNgu>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNgoaiNgu = 0;
		private string _maQuanLy = string.Empty;
		private string _tenNgoaiNgu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNgoaiNgu
		{
			get
			{
				CanReadProperty("MaNgoaiNgu", true);
				return _maNgoaiNgu;
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

		public string TenNgoaiNgu
		{
			get
			{
				CanReadProperty("TenNgoaiNgu", true);
				return _tenNgoaiNgu;
			}
			set
			{
				CanWriteProperty("TenNgoaiNgu", true);
				if (value == null) value = string.Empty;
				if (!_tenNgoaiNgu.Equals(value))
				{
					_tenNgoaiNgu = value;
					PropertyHasChanged("TenNgoaiNgu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maNgoaiNgu;
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
			ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// TenNgoaiNgu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenNgoaiNgu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenNgoaiNgu", 50));
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
			//TODO: Define authorization rules in NgoaiNgu
			//AuthorizationRules.AllowRead("MaNgoaiNgu", "NgoaiNguReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "NgoaiNguReadGroup");
			//AuthorizationRules.AllowRead("TenNgoaiNgu", "NgoaiNguReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "NgoaiNguWriteGroup");
			//AuthorizationRules.AllowWrite("TenNgoaiNgu", "NgoaiNguWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NgoaiNgu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgoaiNguViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NgoaiNgu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgoaiNguAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NgoaiNgu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgoaiNguEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NgoaiNgu
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NgoaiNguDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NgoaiNgu()
		{ /* require use of factory method */ }

		public static NgoaiNgu NewNgoaiNgu()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgoaiNgu");
			return DataPortal.Create<NgoaiNgu>();
		}
        private NgoaiNgu(int mangoaingu, string tenngoaingu)
        {
            this._maNgoaiNgu = mangoaingu;
            this._tenNgoaiNgu=tenngoaingu;
        }

        public static NgoaiNgu NewNgoaiNgu(int mangoaingu, string tenngoaingu)
        {
            return new NgoaiNgu(mangoaingu, tenngoaingu);
        }
		public static NgoaiNgu GetNgoaiNgu(int maNgoaiNgu)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NgoaiNgu");
			return DataPortal.Fetch<NgoaiNgu>(new Criteria(maNgoaiNgu));
		}

		public static void DeleteNgoaiNgu(int maNgoaiNgu)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NgoaiNgu");
			DataPortal.Delete(new Criteria(maNgoaiNgu));
		}

		public override NgoaiNgu Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NgoaiNgu");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NgoaiNgu");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NgoaiNgu");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NgoaiNgu NewNgoaiNguChild()
		{
			NgoaiNgu child = new NgoaiNgu();
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NgoaiNgu GetNgoaiNgu(SafeDataReader dr)
		{
			NgoaiNgu child =  new NgoaiNgu();
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
			public int MaNgoaiNgu;

			public Criteria(int maNgoaiNgu)
			{
				this.MaNgoaiNgu = maNgoaiNgu;
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
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				ExecuteFetch(cn, criteria);
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsNgoaiNgu";

				cm.Parameters.AddWithValue("@MaNgoaiNgu", criteria.MaNgoaiNgu);

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
			DataPortal_Delete(new Criteria(_maNgoaiNgu));
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
                cm.CommandText = "spd_DeletetblnsNgoaiNgu";

				cm.Parameters.AddWithValue("@MaNgoaiNgu", criteria.MaNgoaiNgu);

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
			_maNgoaiNgu = dr.GetInt32("MaNgoaiNgu");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenNgoaiNgu = dr.GetString("TenNgoaiNgu");
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
                cm.CommandText = "spd_InserttblnsNgoaiNgu";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maNgoaiNgu = (int)cm.Parameters["@MaNgoaiNgu"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenNgoaiNgu", _tenNgoaiNgu);
			cm.Parameters.AddWithValue("@MaNgoaiNgu", _maNgoaiNgu);
			cm.Parameters["@MaNgoaiNgu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsNgoaiNgu";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNgoaiNgu", _maNgoaiNgu);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenNgoaiNgu", _tenNgoaiNgu);
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

			ExecuteDelete(cn, new Criteria(_maNgoaiNgu));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
