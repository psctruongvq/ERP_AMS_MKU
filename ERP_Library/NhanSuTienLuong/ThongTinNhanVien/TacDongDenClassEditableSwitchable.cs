
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TacDongDenClass : Csla.BusinessBase<TacDongDenClass>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTacDongDen = 0;
		private string _maQuanLy = string.Empty;
		private string _tacDongDen = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTacDongDen
		{
			get
			{
				CanReadProperty("MaTacDongDen", true);
				return _maTacDongDen;
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

		public string TacDongDen
		{
			get
			{
				CanReadProperty("TacDongDen", true);
				return _tacDongDen;
			}
			set
			{
				CanWriteProperty("TacDongDen", true);
				if (value == null) value = string.Empty;
				if (!_tacDongDen.Equals(value))
				{
					_tacDongDen = value;
					PropertyHasChanged("TacDongDen");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTacDongDen;
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
			// TacDongDen
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TacDongDen");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TacDongDen", 500));
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
			//TODO: Define authorization rules in TacDongDenClass
			//AuthorizationRules.AllowRead("MaTacDongDen", "TacDongDenClassReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "TacDongDenClassReadGroup");
			//AuthorizationRules.AllowRead("TacDongDen", "TacDongDenClassReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "TacDongDenClassWriteGroup");
			//AuthorizationRules.AllowWrite("TacDongDen", "TacDongDenClassWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TacDongDenClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TacDongDenClassViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TacDongDenClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TacDongDenClassAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TacDongDenClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TacDongDenClassEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TacDongDenClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TacDongDenClassDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TacDongDenClass()
		{ /* require use of factory method */ }

		public static TacDongDenClass NewTacDongDenClass()
		{
            TacDongDenClass item = new TacDongDenClass();
            item.MarkAsChild();
            return item;
		}

		public static TacDongDenClass GetTacDongDenClass(int maTacDongDen)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TacDongDenClass");
			return DataPortal.Fetch<TacDongDenClass>(new Criteria(maTacDongDen));
		}

		public static void DeleteTacDongDenClass(int maTacDongDen)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TacDongDenClass");
			DataPortal.Delete(new Criteria(maTacDongDen));
		}

		public override TacDongDenClass Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TacDongDenClass");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TacDongDenClass");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TacDongDenClass");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TacDongDenClass NewTacDongDenClassChild()
		{
			TacDongDenClass child = new TacDongDenClass();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TacDongDenClass GetTacDongDenClass(SafeDataReader dr)
		{
			TacDongDenClass child =  new TacDongDenClass();
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
			public int MaTacDongDen;

			public Criteria(int maTacDongDen)
			{
				this.MaTacDongDen = maTacDongDen;
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
                cm.CommandText = "spd_SelecttblnsTacDongDen";

				cm.Parameters.AddWithValue("@MaTacDongDen", criteria.MaTacDongDen);

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
			DataPortal_Delete(new Criteria(_maTacDongDen));
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
                cm.CommandText = "spd_DeletetblnsTacDongDen";

				cm.Parameters.AddWithValue("@MaTacDongDen", criteria.MaTacDongDen);

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
			_maTacDongDen = dr.GetInt32("MaTacDongDen");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tacDongDen = dr.GetString("TacDongDen");
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
                cm.CommandText = "spd_InserttblnsTacDongDen";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maTacDongDen = (int)cm.Parameters["@MaTacDongDen"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TacDongDen", _tacDongDen);
			cm.Parameters.AddWithValue("@MaTacDongDen", _maTacDongDen);
			cm.Parameters["@MaTacDongDen"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsTacDongDen";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTacDongDen", _maTacDongDen);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TacDongDen", _tacDongDen);
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

			ExecuteDelete(cn, new Criteria(_maTacDongDen));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
