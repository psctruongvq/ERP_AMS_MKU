
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ChuyenNganhDaoTaoClass : Csla.BusinessBase<ChuyenNganhDaoTaoClass>
	{
		#region Business Properties and Methods

		//declare members
		private int _maChuyenNganhDaoTao = 0;
		private string _maQuanLy = string.Empty;
		private string _chuyenNganhDaoTao = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaChuyenNganhDaoTao
		{
			get
			{
				CanReadProperty("MaChuyenNganhDaoTao", true);
				return _maChuyenNganhDaoTao;
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

		public string ChuyenNganhDaoTao
		{
			get
			{
				CanReadProperty("ChuyenNganhDaoTao", true);
				return _chuyenNganhDaoTao;
			}
			set
			{
				CanWriteProperty("ChuyenNganhDaoTao", true);
				if (value == null) value = string.Empty;
				if (!_chuyenNganhDaoTao.Equals(value))
				{
					_chuyenNganhDaoTao = value;
					PropertyHasChanged("ChuyenNganhDaoTao");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maChuyenNganhDaoTao;
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
			// ChuyenNganhDaoTao
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "ChuyenNganhDaoTao");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ChuyenNganhDaoTao", 500));
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
			//TODO: Define authorization rules in ChuyenNganhDaoTaoClass
			//AuthorizationRules.AllowRead("MaChuyenNganhDaoTao", "ChuyenNganhDaoTaoClassReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "ChuyenNganhDaoTaoClassReadGroup");
			//AuthorizationRules.AllowRead("ChuyenNganhDaoTao", "ChuyenNganhDaoTaoClassReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "ChuyenNganhDaoTaoClassWriteGroup");
			//AuthorizationRules.AllowWrite("ChuyenNganhDaoTao", "ChuyenNganhDaoTaoClassWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ChuyenNganhDaoTaoClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuyenNganhDaoTaoClassViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ChuyenNganhDaoTaoClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuyenNganhDaoTaoClassAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ChuyenNganhDaoTaoClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuyenNganhDaoTaoClassEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ChuyenNganhDaoTaoClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ChuyenNganhDaoTaoClassDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ChuyenNganhDaoTaoClass()
		{ /* require use of factory method */ }

		public static ChuyenNganhDaoTaoClass NewChuyenNganhDaoTaoClass()
		{
            ChuyenNganhDaoTaoClass item = new ChuyenNganhDaoTaoClass();
            item.MarkAsChild();
            return item;
		}
        private ChuyenNganhDaoTaoClass(int machuyennganhDT, string chuyennganhDT)
        {
            this._maChuyenNganhDaoTao = machuyennganhDT;
            this._chuyenNganhDaoTao = chuyennganhDT;
        }

        public static ChuyenNganhDaoTaoClass NewChuyenNganhDaoTaoClass(int machuyennganhDT, string chuyennganhDT)
        {
            return new ChuyenNganhDaoTaoClass(machuyennganhDT, chuyennganhDT);
        }
		public static ChuyenNganhDaoTaoClass GetChuyenNganhDaoTaoClass(int maChuyenNganhDaoTao)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ChuyenNganhDaoTaoClass");
			return DataPortal.Fetch<ChuyenNganhDaoTaoClass>(new Criteria(maChuyenNganhDaoTao));
		}

		public static void DeleteChuyenNganhDaoTaoClass(int maChuyenNganhDaoTao)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChuyenNganhDaoTaoClass");
			DataPortal.Delete(new Criteria(maChuyenNganhDaoTao));
		}

		public override ChuyenNganhDaoTaoClass Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ChuyenNganhDaoTaoClass");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ChuyenNganhDaoTaoClass");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ChuyenNganhDaoTaoClass");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ChuyenNganhDaoTaoClass NewChuyenNganhDaoTaoClassChild()
		{
			ChuyenNganhDaoTaoClass child = new ChuyenNganhDaoTaoClass();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ChuyenNganhDaoTaoClass GetChuyenNganhDaoTaoClass(SafeDataReader dr)
		{
			ChuyenNganhDaoTaoClass child =  new ChuyenNganhDaoTaoClass();
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
			public int MaChuyenNganhDaoTao;

			public Criteria(int maChuyenNganhDaoTao)
			{
				this.MaChuyenNganhDaoTao = maChuyenNganhDaoTao;
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
                cm.CommandText = "spd_SelecttblnsChuyenNganhDaoTao";

				cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", criteria.MaChuyenNganhDaoTao);

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
			DataPortal_Delete(new Criteria(_maChuyenNganhDaoTao));
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
                cm.CommandText = "spd_DeletetblnsChuyenNganhDaoTao";

				cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", criteria.MaChuyenNganhDaoTao);

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
			_maChuyenNganhDaoTao = dr.GetInt32("MaChuyenNganhDaoTao");
			_maQuanLy = dr.GetString("MaQuanLy");
			_chuyenNganhDaoTao = dr.GetString("ChuyenNganhDaoTao");
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
                cm.CommandText = "spd_InserttblnsChuyenNganhDaoTao";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maChuyenNganhDaoTao = (int)cm.Parameters["@MaChuyenNganhDaoTao"].Value;
			}//using
		}
     
		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@ChuyenNganhDaoTao", _chuyenNganhDaoTao);
			cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
			cm.Parameters["@MaChuyenNganhDaoTao"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsChuyenNganhDaoTao";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@ChuyenNganhDaoTao", _chuyenNganhDaoTao);
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

			ExecuteDelete(cn, new Criteria(_maChuyenNganhDaoTao));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
