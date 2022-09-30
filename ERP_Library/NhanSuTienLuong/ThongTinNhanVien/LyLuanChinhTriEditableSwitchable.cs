
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LyLuanChinhTri : Csla.BusinessBase<LyLuanChinhTri>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLyLuanCT = 0;
		private string _maQuanLy = string.Empty;
		private string _lyLuanCT = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLyLuanCT
		{
			get
			{
				CanReadProperty("MaLyLuanCT", true);
				return _maLyLuanCT;
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

		public string LyLuanCT
		{
			get
			{
				CanReadProperty("LyLuanCT", true);
				return _lyLuanCT;
			}
			set
			{
				CanWriteProperty("LyLuanCT", true);
				if (value == null) value = string.Empty;
				if (!_lyLuanCT.Equals(value))
				{
					_lyLuanCT = value;
					PropertyHasChanged("LyLuanCT");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLyLuanCT;
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
			// LyLuanCT
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "LyLuanCT");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyLuanCT", 50));
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
			//TODO: Define authorization rules in LyLuanChinhTri
			//AuthorizationRules.AllowRead("MaLyLuanCT", "LyLuanChinhTriReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LyLuanChinhTriReadGroup");
			//AuthorizationRules.AllowRead("LyLuanCT", "LyLuanChinhTriReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "LyLuanChinhTriWriteGroup");
			//AuthorizationRules.AllowWrite("LyLuanCT", "LyLuanChinhTriWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LyLuanChinhTri
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyLuanChinhTriViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LyLuanChinhTri
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyLuanChinhTriAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LyLuanChinhTri
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyLuanChinhTriEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LyLuanChinhTri
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyLuanChinhTriDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LyLuanChinhTri()
		{ /* require use of factory method */ }

		public static LyLuanChinhTri NewLyLuanChinhTri()
		{
            LyLuanChinhTri item = new LyLuanChinhTri();
            item.MarkAsChild();
            return item;
		}

        private LyLuanChinhTri(int maLyluanCT, string LyluanCT)
        {
            this._maLyLuanCT = maLyluanCT;
            this._lyLuanCT = LyluanCT;
        }

        public static LyLuanChinhTri NewLyLuanChinhTri(int malyluanCT, string tenlyluanCT)
        {
            return new LyLuanChinhTri(malyluanCT, tenlyluanCT);
        }
		public static LyLuanChinhTri GetLyLuanChinhTri(int maLyLuanCT)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LyLuanChinhTri");
			return DataPortal.Fetch<LyLuanChinhTri>(new Criteria(maLyLuanCT));
		}

		public static void DeleteLyLuanChinhTri(int maLyLuanCT)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LyLuanChinhTri");
			DataPortal.Delete(new Criteria(maLyLuanCT));
		}

		public override LyLuanChinhTri Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LyLuanChinhTri");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LyLuanChinhTri");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LyLuanChinhTri");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LyLuanChinhTri NewLyLuanChinhTriChild()
		{
			LyLuanChinhTri child = new LyLuanChinhTri();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LyLuanChinhTri GetLyLuanChinhTri(SafeDataReader dr)
		{
			LyLuanChinhTri child =  new LyLuanChinhTri();
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
			public int MaLyLuanCT;

			public Criteria(int maLyLuanCT)
			{
				this.MaLyLuanCT = maLyLuanCT;
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
                cm.CommandText = "spd_SelecttblnsLyLuanCT";

				cm.Parameters.AddWithValue("@MaLyLuanCT", criteria.MaLyLuanCT);

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
			DataPortal_Delete(new Criteria(_maLyLuanCT));
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
                cm.CommandText = "spd_DeletetblnsLyLuanCT";

				cm.Parameters.AddWithValue("@MaLyLuanCT", criteria.MaLyLuanCT);

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
			_maLyLuanCT = dr.GetInt32("MaLyLuanCT");
			_maQuanLy = dr.GetString("MaQuanLy");
			_lyLuanCT = dr.GetString("LyLuanCT");
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
                cm.CommandText = "spd_InserttblnsLyLuanCT";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLyLuanCT = (int)cm.Parameters["@MaLyLuanCT"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@LyLuanCT", _lyLuanCT);
			cm.Parameters.AddWithValue("@MaLyLuanCT", _maLyLuanCT);
			cm.Parameters["@MaLyLuanCT"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsLyLuanCT";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLyLuanCT", _maLyLuanCT);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@LyLuanCT", _lyLuanCT);
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

			ExecuteDelete(cn, new Criteria(_maLyLuanCT));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
