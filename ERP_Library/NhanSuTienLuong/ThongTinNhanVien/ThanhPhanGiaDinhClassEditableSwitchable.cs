

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ThanhPhanGiaDinhClass : Csla.BusinessBase<ThanhPhanGiaDinhClass>
	{
		#region Business Properties and Methods

		//declare members
		private int _maThanhPhan = 0;
		private string _maQuanLy = string.Empty;
		private string _thanhPhanGiaDinh = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaThanhPhan
		{
			get
			{
				CanReadProperty("MaThanhPhan", true);
				return _maThanhPhan;
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

		public string ThanhPhanGiaDinh
		{
			get
			{
				CanReadProperty("ThanhPhanGiaDinh", true);
				return _thanhPhanGiaDinh;
			}
			set
			{
				CanWriteProperty("ThanhPhanGiaDinh", true);
				if (value == null) value = string.Empty;
				if (!_thanhPhanGiaDinh.Equals(value))
				{
					_thanhPhanGiaDinh = value;
					PropertyHasChanged("ThanhPhanGiaDinh");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maThanhPhan;
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
			// ThanhPhanGiaDinh
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "ThanhPhanGiaDinh");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThanhPhanGiaDinh", 500));
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
			//TODO: Define authorization rules in ThanhPhanGiaDinhClass
			//AuthorizationRules.AllowRead("MaThanhPhan", "ThanhPhanGiaDinhClassReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "ThanhPhanGiaDinhClassReadGroup");
			//AuthorizationRules.AllowRead("ThanhPhanGiaDinh", "ThanhPhanGiaDinhClassReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "ThanhPhanGiaDinhClassWriteGroup");
			//AuthorizationRules.AllowWrite("ThanhPhanGiaDinh", "ThanhPhanGiaDinhClassWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ThanhPhanGiaDinhClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThanhPhanGiaDinhClassViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ThanhPhanGiaDinhClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThanhPhanGiaDinhClassAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ThanhPhanGiaDinhClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThanhPhanGiaDinhClassEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ThanhPhanGiaDinhClass
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ThanhPhanGiaDinhClassDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ThanhPhanGiaDinhClass()
		{ /* require use of factory method */ }

		public static ThanhPhanGiaDinhClass NewThanhPhanGiaDinhClass()
		{
            ThanhPhanGiaDinhClass child = new ThanhPhanGiaDinhClass();
            //child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
		}
        private ThanhPhanGiaDinhClass(int mathanhphanGD, string thanhphanGD)
        {
            this._maThanhPhan = mathanhphanGD;
            this._thanhPhanGiaDinh = thanhphanGD;
        }

        public static ThanhPhanGiaDinhClass NewThanhPhanGiaDinhClass(int mathanhphanGD, string thanhphanGD)
        {
            return new ThanhPhanGiaDinhClass(mathanhphanGD, thanhphanGD);
        }
		public static ThanhPhanGiaDinhClass GetThanhPhanGiaDinhClass(int maThanhPhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ThanhPhanGiaDinhClass");
			return DataPortal.Fetch<ThanhPhanGiaDinhClass>(new Criteria(maThanhPhan));
		}

		public static void DeleteThanhPhanGiaDinhClass(int maThanhPhan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThanhPhanGiaDinhClass");
			DataPortal.Delete(new Criteria(maThanhPhan));
		}

		public override ThanhPhanGiaDinhClass Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ThanhPhanGiaDinhClass");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ThanhPhanGiaDinhClass");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ThanhPhanGiaDinhClass");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static ThanhPhanGiaDinhClass NewThanhPhanGiaDinhClassChild()
		{
			ThanhPhanGiaDinhClass child = new ThanhPhanGiaDinhClass();
			//child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ThanhPhanGiaDinhClass GetThanhPhanGiaDinhClass(SafeDataReader dr)
		{
			ThanhPhanGiaDinhClass child =  new ThanhPhanGiaDinhClass();
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
			public int MaThanhPhan;

			public Criteria(int maThanhPhan)
			{
				this.MaThanhPhan = maThanhPhan;
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
                cm.CommandText = "spd_SelecttblnsThanhPhanGiaDinh";

				cm.Parameters.AddWithValue("@MaThanhPhan", criteria.MaThanhPhan);

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
			DataPortal_Delete(new Criteria(_maThanhPhan));
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
                cm.CommandText = "spd_DeletetblnsThanhPhanGiaDinh";

				cm.Parameters.AddWithValue("@MaThanhPhan", criteria.MaThanhPhan);

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
			_maThanhPhan = dr.GetInt32("MaThanhPhan");
			_maQuanLy = dr.GetString("MaQuanLy");
			_thanhPhanGiaDinh = dr.GetString("ThanhPhanGiaDinh");
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
                cm.CommandText = "spd_InserttblnsThanhPhanGiaDinh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maThanhPhan = (int)cm.Parameters["@MaThanhPhan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@ThanhPhanGiaDinh", _thanhPhanGiaDinh);
			cm.Parameters.AddWithValue("@MaThanhPhan", _maThanhPhan);
			cm.Parameters["@MaThanhPhan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsThanhPhanGiaDinh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaThanhPhan", _maThanhPhan);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@ThanhPhanGiaDinh", _thanhPhanGiaDinh);
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

			ExecuteDelete(cn, new Criteria(_maThanhPhan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
