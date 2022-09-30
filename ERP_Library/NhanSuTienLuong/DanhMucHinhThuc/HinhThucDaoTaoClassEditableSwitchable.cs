
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HinhThucDaoTaoClass : Csla.BusinessBase<HinhThucDaoTaoClass>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHinhThucDaoTao = 0;
		private string _maQuanLy = string.Empty;
		private string _hinhThucDaoTao = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaHinhThucDaoTao
		{
			get
			{
				CanReadProperty("MaHinhThucDaoTao", true);
				return _maHinhThucDaoTao;
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

		public string HinhThucDaoTao
		{
			get
			{
				CanReadProperty("HinhThucDaoTao", true);
				return _hinhThucDaoTao;
			}
			set
			{
				CanWriteProperty("HinhThucDaoTao", true);
				if (value == null) value = string.Empty;
				if (!_hinhThucDaoTao.Equals(value))
				{
					_hinhThucDaoTao = value;
					PropertyHasChanged("HinhThucDaoTao");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maHinhThucDaoTao;
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
			// HinhThucDaoTao
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "HinhThucDaoTao");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("HinhThucDaoTao", 200));
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
			//TODO: Define authorization rules in HinhThucDaoTaoClass
			//AuthorizationRules.AllowRead("MaHinhThucDaoTao", "HinhThucDaoTaoClassReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "HinhThucDaoTaoClassReadGroup");
			//AuthorizationRules.AllowRead("HinhThucDaoTao", "HinhThucDaoTaoClassReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "HinhThucDaoTaoClassWriteGroup");
			//AuthorizationRules.AllowWrite("HinhThucDaoTao", "HinhThucDaoTaoClassWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HinhThucDaoTaoClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucDaoTaoClassViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HinhThucDaoTaoClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucDaoTaoClassAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HinhThucDaoTaoClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucDaoTaoClassEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HinhThucDaoTaoClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucDaoTaoClassDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HinhThucDaoTaoClass()
		{ /* require use of factory method */ }

		public static HinhThucDaoTaoClass NewHinhThucDaoTaoClass()
		{
            HinhThucDaoTaoClass item = new HinhThucDaoTaoClass();
            item.MarkAsChild();
            return item;
		}

		public static HinhThucDaoTaoClass GetHinhThucDaoTaoClass(int maHinhThucDaoTao)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HinhThucDaoTaoClass");
			return DataPortal.Fetch<HinhThucDaoTaoClass>(new Criteria(maHinhThucDaoTao));
		}

		public static void DeleteHinhThucDaoTaoClass(int maHinhThucDaoTao)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucDaoTaoClass");
			DataPortal.Delete(new Criteria(maHinhThucDaoTao));
		}

		public override HinhThucDaoTaoClass Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucDaoTaoClass");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucDaoTaoClass");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HinhThucDaoTaoClass");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HinhThucDaoTaoClass NewHinhThucDaoTaoClassChild()
		{
			HinhThucDaoTaoClass child = new HinhThucDaoTaoClass();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HinhThucDaoTaoClass GetHinhThucDaoTaoClass(SafeDataReader dr)
		{
			HinhThucDaoTaoClass child =  new HinhThucDaoTaoClass();
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
			public int MaHinhThucDaoTao;

			public Criteria(int maHinhThucDaoTao)
			{
				this.MaHinhThucDaoTao = maHinhThucDaoTao;
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
                cm.CommandText = "spd_SelecttblnsHinhThucDaoTao";

				cm.Parameters.AddWithValue("@MaHinhThucDaoTao", criteria.MaHinhThucDaoTao);

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
			DataPortal_Delete(new Criteria(_maHinhThucDaoTao));
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
                cm.CommandText = "spd_DeletetblnsHinhThucDaoTao";

				cm.Parameters.AddWithValue("@MaHinhThucDaoTao", criteria.MaHinhThucDaoTao);

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
			_maHinhThucDaoTao = dr.GetInt32("MaHinhThucDaoTao");
			_maQuanLy = dr.GetString("MaQuanLy");
			_hinhThucDaoTao = dr.GetString("HinhThucDaoTao");
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
                cm.CommandText = "spd_InserttblnsHinhThucDaoTao";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maHinhThucDaoTao = (int)cm.Parameters["@MaHinhThucDaoTao"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@HinhThucDaoTao", _hinhThucDaoTao);
			cm.Parameters.AddWithValue("@MaHinhThucDaoTao", _maHinhThucDaoTao);
			cm.Parameters["@MaHinhThucDaoTao"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsHinhThucDaoTao";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHinhThucDaoTao", _maHinhThucDaoTao);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@HinhThucDaoTao", _hinhThucDaoTao);
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

			ExecuteDelete(cn, new Criteria(_maHinhThucDaoTao));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
