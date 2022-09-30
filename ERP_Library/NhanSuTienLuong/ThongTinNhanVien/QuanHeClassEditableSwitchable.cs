
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuanHeClass : Csla.BusinessBase<QuanHeClass>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuanHe = 0;
		private string _maQuanLy = string.Empty;
		private string _quanHe = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuanHe
		{
			get
			{
				CanReadProperty("MaQuanHe", true);
				return _maQuanHe;
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

		public string QuanHe
		{
			get
			{
				CanReadProperty("QuanHe", true);
				return _quanHe;
			}
			set
			{
				CanWriteProperty("QuanHe", true);
				if (value == null) value = string.Empty;
				if (!_quanHe.Equals(value))
				{
					_quanHe = value;
					PropertyHasChanged("QuanHe");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maQuanHe;
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
			// QuanHe
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "QuanHe");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("QuanHe", 50));
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
			//TODO: Define authorization rules in QuanHeClass
			//AuthorizationRules.AllowRead("MaQuanHe", "QuanHeClassReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "QuanHeClassReadGroup");
			//AuthorizationRules.AllowRead("QuanHe", "QuanHeClassReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "QuanHeClassWriteGroup");
			//AuthorizationRules.AllowWrite("QuanHe", "QuanHeClassWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuanHeClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeClassViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuanHeClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeClassAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuanHeClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeClassEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuanHeClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHeClassDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuanHeClass()
		{ /* require use of factory method */ }

		public static QuanHeClass NewQuanHeClass()
		{
            QuanHeClass item = new QuanHeClass();
            item.MarkAsChild();
            return item;
		}

		public static QuanHeClass GetQuanHeClass(int maQuanHe)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuanHeClass");
			return DataPortal.Fetch<QuanHeClass>(new Criteria(maQuanHe));
		}

		public static void DeleteQuanHeClass(int maQuanHe)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuanHeClass");
			DataPortal.Delete(new Criteria(maQuanHe));
		}

		public override QuanHeClass Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuanHeClass");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuanHeClass");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuanHeClass");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuanHeClass NewQuanHeClassChild()
		{
			QuanHeClass child = new QuanHeClass();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuanHeClass GetQuanHeClass(SafeDataReader dr)
		{
			QuanHeClass child =  new QuanHeClass();
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
			public int MaQuanHe;

			public Criteria(int maQuanHe)
			{
				this.MaQuanHe = maQuanHe;
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
                cm.CommandText = "spd_SelecttblnsQuanHe";

				cm.Parameters.AddWithValue("@MaQuanHe", criteria.MaQuanHe);

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
			DataPortal_Delete(new Criteria(_maQuanHe));
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
                cm.CommandText = "spd_DeletetblnsQuanHe";

				cm.Parameters.AddWithValue("@MaQuanHe", criteria.MaQuanHe);

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
			_maQuanHe = dr.GetInt32("MaQuanHe");
			_maQuanLy = dr.GetString("MaQuanLy");
			_quanHe = dr.GetString("QuanHe");
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
                cm.CommandText = "spd_InserttblnsQuanHe";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maQuanHe = (int)cm.Parameters["@MaQuanHe"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@QuanHe", _quanHe);
			cm.Parameters.AddWithValue("@MaQuanHe", _maQuanHe);
			cm.Parameters["@MaQuanHe"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsQuanHe";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanHe", _maQuanHe);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@QuanHe", _quanHe);
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

			ExecuteDelete(cn, new Criteria(_maQuanHe));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
