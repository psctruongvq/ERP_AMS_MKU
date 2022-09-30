
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class HinhThucTrichNop : Csla.BusinessBase<HinhThucTrichNop>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHinhThucTrichNop = 0;
		private string _maQuanLy = string.Empty;
		private string _tenHinhThuc = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaHinhThucTrichNop
		{
			get
			{
				CanReadProperty("MaHinhThucTrichNop", true);
				return _maHinhThucTrichNop;
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

		public string TenHinhThuc
		{
			get
			{
				CanReadProperty("TenHinhThuc", true);
				return _tenHinhThuc;
			}
			set
			{
				CanWriteProperty("TenHinhThuc", true);
				if (value == null) value = string.Empty;
				if (!_tenHinhThuc.Equals(value))
				{
					_tenHinhThuc = value;
					PropertyHasChanged("TenHinhThuc");
				}
			}
		}

		protected override object GetIdValue()
		{
			return _maHinhThucTrichNop;
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
			// TenHinhThuc
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenHinhThuc");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenHinhThuc", 200));
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
			//TODO: Define authorization rules in HinhThucTrichNop
			//AuthorizationRules.AllowRead("MaHinhThucTrichNop", "HinhThucTrichNopReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "HinhThucTrichNopReadGroup");
			//AuthorizationRules.AllowRead("TenHinhThuc", "HinhThucTrichNopReadGroup");
			//AuthorizationRules.AllowRead("HeSoV1", "HinhThucTrichNopReadGroup");
			//AuthorizationRules.AllowRead("HeSoV2", "HinhThucTrichNopReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "HinhThucTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("TenHinhThuc", "HinhThucTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoV1", "HinhThucTrichNopWriteGroup");
			//AuthorizationRules.AllowWrite("HeSoV2", "HinhThucTrichNopWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in HinhThucTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucTrichNopViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in HinhThucTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucTrichNopAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in HinhThucTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucTrichNopEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in HinhThucTrichNop
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("HinhThucTrichNopDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private HinhThucTrichNop()
		{ /* require use of factory method */ }

		public static HinhThucTrichNop NewHinhThucTrichNop()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucTrichNop");
			return DataPortal.Create<HinhThucTrichNop>();
		}

		public static HinhThucTrichNop GetHinhThucTrichNop(int maHinhThucTrichNop)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a HinhThucTrichNop");
			return DataPortal.Fetch<HinhThucTrichNop>(new Criteria(maHinhThucTrichNop));
		}

		public static void DeleteHinhThucTrichNop(int maHinhThucTrichNop)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucTrichNop");
			DataPortal.Delete(new Criteria(maHinhThucTrichNop));
		}

		public override HinhThucTrichNop Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a HinhThucTrichNop");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a HinhThucTrichNop");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a HinhThucTrichNop");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static HinhThucTrichNop NewHinhThucTrichNopChild()
		{
			HinhThucTrichNop child = new HinhThucTrichNop();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static HinhThucTrichNop GetHinhThucTrichNop(SafeDataReader dr)
		{
			HinhThucTrichNop child =  new HinhThucTrichNop();
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
			public int MaHinhThucTrichNop;

			public Criteria(int maHinhThucTrichNop)
			{
				this.MaHinhThucTrichNop = maHinhThucTrichNop;
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
                cm.CommandText = "spd_SelecttblnsHinhThucTrichNop";

				cm.Parameters.AddWithValue("@MaHinhThucTrichNop", criteria.MaHinhThucTrichNop);

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
			DataPortal_Delete(new Criteria(_maHinhThucTrichNop));
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
                cm.CommandText = "spd_DeletetblnsHinhThucTrichNop";

				cm.Parameters.AddWithValue("@MaHinhThucTrichNop", criteria.MaHinhThucTrichNop);

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
			_maHinhThucTrichNop = dr.GetInt32("MaHinhThucTrichNop");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenHinhThuc = dr.GetString("TenHinhThuc");
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
                cm.CommandText = "spd_InserttblnsHinhThucTrichNop";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maHinhThucTrichNop = (int)cm.Parameters["@MaHinhThucTrichNop"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenHinhThuc", _tenHinhThuc);
			
			cm.Parameters.AddWithValue("@MaHinhThucTrichNop", _maHinhThucTrichNop);
			cm.Parameters["@MaHinhThucTrichNop"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsHinhThucTrichNop";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHinhThucTrichNop", _maHinhThucTrichNop);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenHinhThuc", _tenHinhThuc);
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

			ExecuteDelete(cn, new Criteria(_maHinhThucTrichNop));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
