
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TrinhDoHocVanClass : Csla.BusinessBase<TrinhDoHocVanClass>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTrinhDoHocVan = 0;
		private string _maQuanLy = string.Empty;
		private string _trinhDoHocVan = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTrinhDoHocVan
		{
			get
			{
				CanReadProperty("MaTrinhDoHocVan", true);
				return _maTrinhDoHocVan;
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

		public string TrinhDoHocVan
		{
			get
			{
				CanReadProperty("TrinhDoHocVan", true);
				return _trinhDoHocVan;
			}
			set
			{
				CanWriteProperty("TrinhDoHocVan", true);
				if (value == null) value = string.Empty;
				if (!_trinhDoHocVan.Equals(value))
				{
					_trinhDoHocVan = value;
					PropertyHasChanged("TrinhDoHocVan");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTrinhDoHocVan;
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
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			//
			// TrinhDoHocVan
			//
			//ValidationRules.AddRule(CommonRules.StringRequired, "TrinhDoHocVan");
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TrinhDoHocVan", 50));
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
			//TODO: Define authorization rules in TrinhDoHocVanClass
			//AuthorizationRules.AllowRead("MaTrinhDoHocVan", "TrinhDoHocVanClassReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "TrinhDoHocVanClassReadGroup");
			//AuthorizationRules.AllowRead("TrinhDoHocVan", "TrinhDoHocVanClassReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "TrinhDoHocVanClassWriteGroup");
			//AuthorizationRules.AllowWrite("TrinhDoHocVan", "TrinhDoHocVanClassWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TrinhDoHocVanClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoHocVanClassViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TrinhDoHocVanClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoHocVanClassAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TrinhDoHocVanClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoHocVanClassEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TrinhDoHocVanClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TrinhDoHocVanClassDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TrinhDoHocVanClass()
		{ /* require use of factory method */ }

		public static TrinhDoHocVanClass NewTrinhDoHocVanClass()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrinhDoHocVanClass");
			return DataPortal.Create<TrinhDoHocVanClass>();
		}
        private TrinhDoHocVanClass(int matrinhdohocvan, string trinhdohocvan)
        {
            this._maTrinhDoHocVan = matrinhdohocvan;
            this._trinhDoHocVan = trinhdohocvan;
        }

        public static TrinhDoHocVanClass NewTrinhDoHocVanClass(int matrinhdohocvan, string trinhdohocvan)
        {
            return new TrinhDoHocVanClass(matrinhdohocvan, trinhdohocvan);
        }
		public static TrinhDoHocVanClass GetTrinhDoHocVanClass(int maTrinhDoHocVan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TrinhDoHocVanClass");
			return DataPortal.Fetch<TrinhDoHocVanClass>(new Criteria(maTrinhDoHocVan));
		}

		public static void DeleteTrinhDoHocVanClass(int maTrinhDoHocVan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrinhDoHocVanClass");
			DataPortal.Delete(new Criteria(maTrinhDoHocVan));
		}

		public override TrinhDoHocVanClass Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TrinhDoHocVanClass");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TrinhDoHocVanClass");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TrinhDoHocVanClass");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TrinhDoHocVanClass NewTrinhDoHocVanClassChild()
		{
			TrinhDoHocVanClass child = new TrinhDoHocVanClass();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TrinhDoHocVanClass GetTrinhDoHocVanClass(SafeDataReader dr)
		{
			TrinhDoHocVanClass child =  new TrinhDoHocVanClass();
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
			public int MaTrinhDoHocVan;

			public Criteria(int maTrinhDoHocVan)
			{
				this.MaTrinhDoHocVan = maTrinhDoHocVan;
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
                cm.CommandText = "spd_SelecttblnsTrinhDoHocVan";

				cm.Parameters.AddWithValue("@MaTrinhDoHocVan", criteria.MaTrinhDoHocVan);

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
			DataPortal_Delete(new Criteria(_maTrinhDoHocVan));
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
                cm.CommandText = "spd_DeletetblnsTrinhDoHocVan";

				cm.Parameters.AddWithValue("@MaTrinhDoHocVan", criteria.MaTrinhDoHocVan);

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
			_maTrinhDoHocVan = dr.GetInt32("MaTrinhDoHocVan");
			_maQuanLy = dr.GetString("MaQuanLy");
			_trinhDoHocVan = dr.GetString("TrinhDoHocVan");
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
                cm.CommandText = "spd_InserttblnsTrinhDoHocVan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maTrinhDoHocVan = (int)cm.Parameters["@MaTrinhDoHocVan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TrinhDoHocVan", _trinhDoHocVan);
			cm.Parameters.AddWithValue("@MaTrinhDoHocVan", _maTrinhDoHocVan);
			cm.Parameters["@MaTrinhDoHocVan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsTrinhDoHocVan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTrinhDoHocVan", _maTrinhDoHocVan);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TrinhDoHocVan", _trinhDoHocVan);
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

			ExecuteDelete(cn, new Criteria(_maTrinhDoHocVan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
