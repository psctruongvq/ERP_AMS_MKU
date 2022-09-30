
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HocHam : Csla.BusinessBase<HocHam>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHocHam = 0;
		private string _maQuanLy = string.Empty;
		private string _tenHocHam = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaHocHam
		{
			get
			{
				CanReadProperty("MaHocHam", true);
				return _maHocHam;
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

		public string TenHocHam
		{
			get
			{
				CanReadProperty("TenHocHam", true);
				return _tenHocHam;
			}
			set
			{
				CanWriteProperty("TenHocHam", true);
				if (value == null) value = string.Empty;
				if (!_tenHocHam.Equals(value))
				{
					_tenHocHam = value;
					PropertyHasChanged("TenHocHam");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maHocHam;
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
			// TenHocHam
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenHocHam");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHocHam", 100));
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
			//TODO: Define authorization rules in HocHam
			//AuthorizationRules.AllowRead("MaHocHam", "HocHamReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "HocHamReadGroup");
			//AuthorizationRules.AllowRead("TenHocHam", "HocHamReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "HocHamWriteGroup");
			//AuthorizationRules.AllowWrite("TenHocHam", "HocHamWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HocHam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HocHamViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HocHam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HocHamAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HocHam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HocHamEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HocHam
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HocHamDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HocHam()
		{ /* require use of factory method */ }

		public static HocHam NewHocHam()
		{
            HocHam item = new HocHam();
            item.MarkAsChild();
            return item;
		}
        private HocHam(int mahocham, string tenhocham)
        {
            this._maHocHam = mahocham;
            this._tenHocHam = tenhocham;
        }

        public static HocHam NewHocHam(int mahocham, string tenhocham)
        {
            return new HocHam(mahocham, tenhocham);
        }

		public static HocHam GetHocHam(int maHocHam)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HocHam");
			return DataPortal.Fetch<HocHam>(new Criteria(maHocHam));
		}

		public static void DeleteHocHam(int maHocHam)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HocHam");
			DataPortal.Delete(new Criteria(maHocHam));
		}

		public override HocHam Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HocHam");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HocHam");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HocHam");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HocHam NewHocHamChild()
		{
			HocHam child = new HocHam();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HocHam GetHocHam(SafeDataReader dr)
		{
			HocHam child =  new HocHam();
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
			public int MaHocHam;

			public Criteria(int maHocHam)
			{
				this.MaHocHam = maHocHam;
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
                cm.CommandText = "spd_SelecttblnsHocHam";

				cm.Parameters.AddWithValue("@MaHocHam", criteria.MaHocHam);

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
			DataPortal_Delete(new Criteria(_maHocHam));
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
                cm.CommandText = "spd_DeletetblnsHocHam";

				cm.Parameters.AddWithValue("@MaHocHam", criteria.MaHocHam);

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
			_maHocHam = dr.GetInt32("MaHocHam");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenHocHam = dr.GetString("TenHocHam");
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
                cm.CommandText = "spd_InserttblnsHocHam";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maHocHam = (int)cm.Parameters["@MaHocHam"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenHocHam", _tenHocHam);
			cm.Parameters.AddWithValue("@MaHocHam", _maHocHam);
			cm.Parameters["@MaHocHam"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsHocHam";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHocHam", _maHocHam);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenHocHam", _tenHocHam);
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

			ExecuteDelete(cn, new Criteria(_maHocHam));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
