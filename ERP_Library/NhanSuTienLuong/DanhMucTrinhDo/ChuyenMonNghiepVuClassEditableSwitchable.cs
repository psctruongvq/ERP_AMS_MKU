
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChuyenMonNghiepVuClass : Csla.BusinessBase<ChuyenMonNghiepVuClass>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChuyenMonNV = 0;
		private string _maQuanLy = string.Empty;
		private string _chuyenMonNghiepVu = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChuyenMonNV
		{
			get
			{
				CanReadProperty("MaChuyenMonNV", true);
				return _maChuyenMonNV;
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

		public string ChuyenMonNghiepVu
		{
			get
			{
				CanReadProperty("ChuyenMonNghiepVu", true);
				return _chuyenMonNghiepVu;
			}
			set
			{
				CanWriteProperty("ChuyenMonNghiepVu", true);
				if (value == null) value = string.Empty;
				if (!_chuyenMonNghiepVu.Equals(value))
				{
					_chuyenMonNghiepVu = value;
					PropertyHasChanged("ChuyenMonNghiepVu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChuyenMonNV;
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
			// ChuyenMonNghiepVu
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "ChuyenMonNghiepVu");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ChuyenMonNghiepVu", 100));
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
			//TODO: Define authorization rules in ChuyenMonNghiepVuClass
			//AuthorizationRules.AllowRead("MaChuyenMonNV", "ChuyenMonNghiepVuClassReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "ChuyenMonNghiepVuClassReadGroup");
			//AuthorizationRules.AllowRead("ChuyenMonNghiepVu", "ChuyenMonNghiepVuClassReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "ChuyenMonNghiepVuClassWriteGroup");
			//AuthorizationRules.AllowWrite("ChuyenMonNghiepVu", "ChuyenMonNghiepVuClassWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChuyenMonNghiepVuClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuyenMonNghiepVuClassViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChuyenMonNghiepVuClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuyenMonNghiepVuClassAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChuyenMonNghiepVuClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuyenMonNghiepVuClassEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChuyenMonNghiepVuClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuyenMonNghiepVuClassDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChuyenMonNghiepVuClass()
		{ /* require use of factory method */ }

		public static ChuyenMonNghiepVuClass NewChuyenMonNghiepVuClass()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChuyenMonNghiepVuClass");
			return DataPortal.Create<ChuyenMonNghiepVuClass>();
		}
        private ChuyenMonNghiepVuClass(int machuyenmonNV, string Chuyenmonnghiepvu)
        {
            this._maChuyenMonNV = machuyenmonNV;
            this._chuyenMonNghiepVu = Chuyenmonnghiepvu;
        }

        public static ChuyenMonNghiepVuClass NewChuyenMonNghiepVuClass(int machuyenmonNV, string chuyenmonNV)
        {
            return new ChuyenMonNghiepVuClass(machuyenmonNV, chuyenmonNV);
        }
		public static ChuyenMonNghiepVuClass GetChuyenMonNghiepVuClass(int maChuyenMonNV)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChuyenMonNghiepVuClass");
			return DataPortal.Fetch<ChuyenMonNghiepVuClass>(new Criteria(maChuyenMonNV));
		}

		public static void DeleteChuyenMonNghiepVuClass(int maChuyenMonNV)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChuyenMonNghiepVuClass");
			DataPortal.Delete(new Criteria(maChuyenMonNV));
		}

		public override ChuyenMonNghiepVuClass Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChuyenMonNghiepVuClass");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChuyenMonNghiepVuClass");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChuyenMonNghiepVuClass");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChuyenMonNghiepVuClass NewChuyenMonNghiepVuClassChild()
		{
			ChuyenMonNghiepVuClass child = new ChuyenMonNghiepVuClass();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChuyenMonNghiepVuClass GetChuyenMonNghiepVuClass(SafeDataReader dr)
		{
			ChuyenMonNghiepVuClass child =  new ChuyenMonNghiepVuClass();
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
			public int MaChuyenMonNV;

			public Criteria(int maChuyenMonNV)
			{
				this.MaChuyenMonNV = maChuyenMonNV;
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
                cm.CommandText = "spd_SelecttblnsChuyenMonNghiepVu";

				cm.Parameters.AddWithValue("@MaChuyenMonNV", criteria.MaChuyenMonNV);

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
			DataPortal_Delete(new Criteria(_maChuyenMonNV));
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
                cm.CommandText = "spd_DeletetblnsChuyenMonNghiepVu";

				cm.Parameters.AddWithValue("@MaChuyenMonNV", criteria.MaChuyenMonNV);

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
			_maChuyenMonNV = dr.GetInt32("MaChuyenMonNV");
			_maQuanLy = dr.GetString("MaQuanLy");
			_chuyenMonNghiepVu = dr.GetString("ChuyenMonNghiepVu");
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
                cm.CommandText = "spd_InserttblnsChuyenMonNghiepVu";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maChuyenMonNV = (int)cm.Parameters["@MaChuyenMonNV"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@ChuyenMonNghiepVu", _chuyenMonNghiepVu);
			cm.Parameters.AddWithValue("@MaChuyenMonNV", _maChuyenMonNV);
			cm.Parameters["@MaChuyenMonNV"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsChuyenMonNghiepVu";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaChuyenMonNV", _maChuyenMonNV);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@ChuyenMonNghiepVu", _chuyenMonNghiepVu);
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

			ExecuteDelete(cn, new Criteria(_maChuyenMonNV));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
