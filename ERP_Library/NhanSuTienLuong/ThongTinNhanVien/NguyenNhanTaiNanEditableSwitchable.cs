
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NguyenNhanTaiNan : Csla.BusinessBase<NguyenNhanTaiNan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maNguyenNhanTaiNan = 0;
		private string _maQuanLy = string.Empty;
		private string _nguyenNhanTaiNan = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaNguyenNhanTaiNan
		{
			get
			{
				CanReadProperty("MaNguyenNhanTaiNan", true);
				return _maNguyenNhanTaiNan;
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

		public string _NguyenNhanTaiNan
		{
			get
			{
				CanReadProperty("NguyenNhanTaiNan", true);
				return _nguyenNhanTaiNan;
			}
			set
			{
				CanWriteProperty("NguyenNhanTaiNan", true);
				if (value == null) value = string.Empty;
				if (!_nguyenNhanTaiNan.Equals(value))
				{
					_nguyenNhanTaiNan = value;
					PropertyHasChanged("NguyenNhanTaiNan");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maNguyenNhanTaiNan;
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
            ////
            //// NguyenNhanTaiNan
            ////
            //ValidationRules.AddRule(CommonRules.StringRequired, "NguyenNhanTaiNan");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("NguyenNhanTaiNan", 4000));
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
			//TODO: Define authorization rules in NguyenNhanTaiNan
			//AuthorizationRules.AllowRead("MaNguyenNhanTaiNan", "NguyenNhanTaiNanReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "NguyenNhanTaiNanReadGroup");
			//AuthorizationRules.AllowRead("NguyenNhanTaiNan", "NguyenNhanTaiNanReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "NguyenNhanTaiNanWriteGroup");
			//AuthorizationRules.AllowWrite("NguyenNhanTaiNan", "NguyenNhanTaiNanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NguyenNhanTaiNan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NguyenNhanTaiNanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NguyenNhanTaiNan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NguyenNhanTaiNanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NguyenNhanTaiNan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NguyenNhanTaiNanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NguyenNhanTaiNan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NguyenNhanTaiNanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NguyenNhanTaiNan()
		{ /* require use of factory method */ }

		public static NguyenNhanTaiNan NewNguyenNhanTaiNan()
		{
            NguyenNhanTaiNan item = new NguyenNhanTaiNan();
            item.MarkAsChild();
            return item;
		}

		public static NguyenNhanTaiNan GetNguyenNhanTaiNan(int maNguyenNhanTaiNan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NguyenNhanTaiNan");
			return DataPortal.Fetch<NguyenNhanTaiNan>(new Criteria(maNguyenNhanTaiNan));
		}

		public static void DeleteNguyenNhanTaiNan(int maNguyenNhanTaiNan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NguyenNhanTaiNan");
			DataPortal.Delete(new Criteria(maNguyenNhanTaiNan));
		}

		public override NguyenNhanTaiNan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NguyenNhanTaiNan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NguyenNhanTaiNan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NguyenNhanTaiNan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static NguyenNhanTaiNan NewNguyenNhanTaiNanChild()
		{
			NguyenNhanTaiNan child = new NguyenNhanTaiNan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NguyenNhanTaiNan GetNguyenNhanTaiNan(SafeDataReader dr)
		{
			NguyenNhanTaiNan child =  new NguyenNhanTaiNan();
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
			public int MaNguyenNhanTaiNan;

			public Criteria(int maNguyenNhanTaiNan)
			{
				this.MaNguyenNhanTaiNan = maNguyenNhanTaiNan;
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
                cm.CommandText = "spd_SelecttblnsNguyenNhanTaiNan";

				cm.Parameters.AddWithValue("@MaNguyenNhanTaiNan", criteria.MaNguyenNhanTaiNan);

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
			DataPortal_Delete(new Criteria(_maNguyenNhanTaiNan));
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
                cm.CommandText = "spd_DeletetblnsNguyenNhanTaiNan";

				cm.Parameters.AddWithValue("@MaNguyenNhanTaiNan", criteria.MaNguyenNhanTaiNan);

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
			_maNguyenNhanTaiNan = dr.GetInt32("MaNguyenNhanTaiNan");
			_maQuanLy = dr.GetString("MaQuanLy");
			_nguyenNhanTaiNan = dr.GetString("NguyenNhanTaiNan");
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
                cm.CommandText = "spd_InserttblnsNguyenNhanTaiNan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maNguyenNhanTaiNan = (int)cm.Parameters["@MaNguyenNhanTaiNan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@NguyenNhanTaiNan", _nguyenNhanTaiNan);
			cm.Parameters.AddWithValue("@MaNguyenNhanTaiNan", _maNguyenNhanTaiNan);
			cm.Parameters["@MaNguyenNhanTaiNan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsNguyenNhanTaiNan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaNguyenNhanTaiNan", _maNguyenNhanTaiNan);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@NguyenNhanTaiNan", _nguyenNhanTaiNan);
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

			ExecuteDelete(cn, new Criteria(_maNguyenNhanTaiNan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
