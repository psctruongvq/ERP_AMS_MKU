
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuanHam : Csla.BusinessBase<QuanHam>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuanHam = 0;
		private string _maQuanLy = string.Empty;
		private string _tenQuanHam = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuanHam
		{
			get
			{
				CanReadProperty("MaQuanHam", true);
				return _maQuanHam;
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

		public string TenQuanHam
		{
			get
			{
				CanReadProperty("TenQuanHam", true);
				return _tenQuanHam;
			}
			set
			{
				CanWriteProperty("TenQuanHam", true);
				if (value == null) value = string.Empty;
				if (!_tenQuanHam.Equals(value))
				{
					_tenQuanHam = value;
					PropertyHasChanged("TenQuanHam");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maQuanHam;
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
			// TenQuanHam
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenQuanHam");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQuanHam", 100));
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
			//TODO: Define authorization rules in QuanHam
			//AuthorizationRules.AllowRead("MaQuanHam", "QuanHamReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "QuanHamReadGroup");
			//AuthorizationRules.AllowRead("TenQuanHam", "QuanHamReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "QuanHamWriteGroup");
			//AuthorizationRules.AllowWrite("TenQuanHam", "QuanHamWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuanHam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHamViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuanHam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHamAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuanHam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHamEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuanHam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHamDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuanHam()
		{ /* require use of factory method */ }

		public static QuanHam NewQuanHam()
		{
            QuanHam item = new QuanHam();
            item.MarkAsChild();
            return item;
		}
        private QuanHam(int maquanham, string tenquanham)
        {
            this._maQuanHam = maquanham;
            this._tenQuanHam = tenquanham;
        }

        public static QuanHam NewQuanHam(int maquanham, string tenquanham)
        {
            return new QuanHam(maquanham, tenquanham);
        }

		public static QuanHam GetQuanHam(int maQuanHam)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuanHam");
			return DataPortal.Fetch<QuanHam>(new Criteria(maQuanHam));
		}

		public static void DeleteQuanHam(int maQuanHam)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuanHam");
			DataPortal.Delete(new Criteria(maQuanHam));
		}

		public override QuanHam Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuanHam");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuanHam");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuanHam");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuanHam NewQuanHamChild()
		{
			QuanHam child = new QuanHam();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuanHam GetQuanHam(SafeDataReader dr)
		{
			QuanHam child =  new QuanHam();
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
			public int MaQuanHam;

			public Criteria(int maQuanHam)
			{
				this.MaQuanHam = maQuanHam;
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
				cm.CommandText = "GetQuanHam";

				cm.Parameters.AddWithValue("@MaQuanHam", criteria.MaQuanHam);

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
			DataPortal_Delete(new Criteria(_maQuanHam));
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
                cm.CommandText = "spd_DeletetblnsQuanHam";

				cm.Parameters.AddWithValue("@MaQuanHam", criteria.MaQuanHam);

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
			_maQuanHam = dr.GetInt32("MaQuanHam");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenQuanHam = dr.GetString("TenQuanHam");
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
                cm.CommandText = "spd_InserttblnsQuanHam";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				//_maQuanHam = (int)cm.Parameters["@NewMaQuanHam"].Value;
                _maQuanHam = (int)cm.Parameters["@MaQuanHam"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenQuanHam", _tenQuanHam);
			//cm.Parameters.AddWithValue("@NewMaQuanHam", _maQuanHam);
            cm.Parameters.AddWithValue("@MaQuanHam", _maQuanHam);
			//cm.Parameters["@NewMaQuanHam"].Direction = ParameterDirection.Output;
            cm.Parameters["@MaQuanHam"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsQuanHam";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanHam", _maQuanHam);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenQuanHam", _tenQuanHam);
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

			ExecuteDelete(cn, new Criteria(_maQuanHam));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
