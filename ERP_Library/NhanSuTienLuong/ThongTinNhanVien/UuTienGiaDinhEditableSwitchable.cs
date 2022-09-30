
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class UuTienGiaDinh : Csla.BusinessBase<UuTienGiaDinh>
	{
		#region Business Properties and Methods

		//declare members
		private int _maUuTienGiaDinh = 0;
		private string _maQuanLy = string.Empty;
		private string _uuTienGiaDinh = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaUuTienGiaDinh
		{
			get
			{
				CanReadProperty("MaUuTienGiaDinh", true);
				return _maUuTienGiaDinh;
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

		public string UuTienGD
		{
			get
			{
				CanReadProperty("UuTienGiaDinh", true);
				return _uuTienGiaDinh;
			}
			set
			{
				CanWriteProperty("UuTienGiaDinh", true);
				if (value == null) value = string.Empty;
				if (!_uuTienGiaDinh.Equals(value))
				{
					_uuTienGiaDinh = value;
					PropertyHasChanged("UuTienGiaDinh");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maUuTienGiaDinh;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{
			
			// MaQuanLy
			
            //ValidationRules.AddRule(CommonRules.StringRequired, "MaQuanLy");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 20));
			
            // //UuTienGiaDinh
			
            //ValidationRules.AddRule(CommonRules.StringRequired, "UuTienGiaDinh");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("UuTienGiaDinh", 500));
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
			//TODO: Define authorization rules in UuTienGiaDinh
			//AuthorizationRules.AllowRead("MaUuTienGiaDinh", "UuTienGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "UuTienGiaDinhReadGroup");
			//AuthorizationRules.AllowRead("UuTienGiaDinh", "UuTienGiaDinhReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "UuTienGiaDinhWriteGroup");
			//AuthorizationRules.AllowWrite("UuTienGiaDinh", "UuTienGiaDinhWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in UuTienGiaDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("UuTienGiaDinhViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in UuTienGiaDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("UuTienGiaDinhAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in UuTienGiaDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("UuTienGiaDinhEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in UuTienGiaDinh
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("UuTienGiaDinhDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private UuTienGiaDinh()
		{ /* require use of factory method */ }

		public static UuTienGiaDinh NewUuTienGiaDinh()
		{
            UuTienGiaDinh item = new UuTienGiaDinh();
            item.MarkAsChild();
            return item;
		}
        private UuTienGiaDinh(int mauutiengiadinh, string uutiengiadinh)
        {
            this._maUuTienGiaDinh = mauutiengiadinh;
            this._uuTienGiaDinh = uutiengiadinh;
        }

        public static UuTienGiaDinh NewUuTienGiaDinh(int mauutiengiadinh, string uutiengiadinh)
        {
            return new UuTienGiaDinh(mauutiengiadinh, uutiengiadinh);
        }
		public static UuTienGiaDinh GetUuTienGiaDinh(int maUuTienGiaDinh)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a UuTienGiaDinh");
			return DataPortal.Fetch<UuTienGiaDinh>(new Criteria(maUuTienGiaDinh));
		}

		public static void DeleteUuTienGiaDinh(int maUuTienGiaDinh)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a UuTienGiaDinh");
			DataPortal.Delete(new Criteria(maUuTienGiaDinh));
		}

		public override UuTienGiaDinh Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a UuTienGiaDinh");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a UuTienGiaDinh");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a UuTienGiaDinh");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static UuTienGiaDinh NewUuTienGiaDinhChild()
		{
			UuTienGiaDinh child = new UuTienGiaDinh();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static UuTienGiaDinh GetUuTienGiaDinh(SafeDataReader dr)
		{
			UuTienGiaDinh child =  new UuTienGiaDinh();
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
			public int MaUuTienGiaDinh;

			public Criteria(int maUuTienGiaDinh)
			{
				this.MaUuTienGiaDinh = maUuTienGiaDinh;
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
                cm.CommandText = "spd_SelecttblnsUuTienGiaDinh";

				cm.Parameters.AddWithValue("@MaUuTienGiaDinh", criteria.MaUuTienGiaDinh);

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
			DataPortal_Delete(new Criteria(_maUuTienGiaDinh));
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
                cm.CommandText = "spd_DeletetblnsUuTienGiaDinh";

				cm.Parameters.AddWithValue("@MaUuTienGiaDinh", criteria.MaUuTienGiaDinh);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			//ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maUuTienGiaDinh = dr.GetInt32("MaUuTienGiaDinh");
			_maQuanLy = dr.GetString("MaQuanLy");
			_uuTienGiaDinh = dr.GetString("UuTienGiaDinh");
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
                cm.CommandText = "spd_InserttblnsUuTienGiaDinh";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maUuTienGiaDinh = (int)cm.Parameters["@MaUuTienGiaDinh"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@UuTienGiaDinh", _uuTienGiaDinh);
			cm.Parameters.AddWithValue("@MaUuTienGiaDinh", _maUuTienGiaDinh);
			cm.Parameters["@MaUuTienGiaDinh"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsUuTienGiaDinh";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaUuTienGiaDinh", _maUuTienGiaDinh);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@UuTienGiaDinh", _uuTienGiaDinh);
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

			ExecuteDelete(cn, new Criteria(_maUuTienGiaDinh));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
