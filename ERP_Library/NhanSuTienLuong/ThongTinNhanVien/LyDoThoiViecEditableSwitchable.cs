
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class LyDoThoiViec : Csla.BusinessBase<LyDoThoiViec>
	{
		#region Business Properties and Methods

		//declare members
		private int _maLyDoThoiViec = 0;
		private string _maQuanLy = string.Empty;
		private string _lyDo = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLyDoThoiViec
		{
			get
			{
				CanReadProperty("MaLyDoThoiViec", true);
				return _maLyDoThoiViec;
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

		public string LyDo
		{
			get
			{
				CanReadProperty("LyDo", true);
				return _lyDo;
			}
			set
			{
				CanWriteProperty("LyDo", true);
				if (value == null) value = string.Empty;
				if (!_lyDo.Equals(value))
				{
					_lyDo = value;
					PropertyHasChanged("LyDo");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maLyDoThoiViec;
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
			// LyDo
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "LyDo");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 500));
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
			//TODO: Define authorization rules in LyDoThoiViec
			//AuthorizationRules.AllowRead("MaLyDoThoiViec", "LyDoThoiViecReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "LyDoThoiViecReadGroup");
			//AuthorizationRules.AllowRead("LyDo", "LyDoThoiViecReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "LyDoThoiViecWriteGroup");
			//AuthorizationRules.AllowWrite("LyDo", "LyDoThoiViecWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in LyDoThoiViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyDoThoiViecViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in LyDoThoiViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyDoThoiViecAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in LyDoThoiViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyDoThoiViecEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in LyDoThoiViec
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("LyDoThoiViecDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private LyDoThoiViec()
		{ /* require use of factory method */ }

		public static LyDoThoiViec NewLyDoThoiViec()
		{
            LyDoThoiViec item = new LyDoThoiViec();
            item.MarkAsChild();
            return item;
		}

		public static LyDoThoiViec GetLyDoThoiViec(int maLyDoThoiViec)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a LyDoThoiViec");
			return DataPortal.Fetch<LyDoThoiViec>(new Criteria(maLyDoThoiViec));
		}

		public static void DeleteLyDoThoiViec(int maLyDoThoiViec)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LyDoThoiViec");
			DataPortal.Delete(new Criteria(maLyDoThoiViec));
		}

		public override LyDoThoiViec Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a LyDoThoiViec");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a LyDoThoiViec");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a LyDoThoiViec");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static LyDoThoiViec NewLyDoThoiViecChild()
		{
			LyDoThoiViec child = new LyDoThoiViec();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static LyDoThoiViec GetLyDoThoiViec(SafeDataReader dr)
		{
			LyDoThoiViec child =  new LyDoThoiViec();
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
			public int MaLyDoThoiViec;

			public Criteria(int maLyDoThoiViec)
			{
				this.MaLyDoThoiViec = maLyDoThoiViec;
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
                cm.CommandText = "spd_SelecttblnsLyDoThoiViec";

				cm.Parameters.AddWithValue("@MaLyDoThoiViec", criteria.MaLyDoThoiViec);

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
			DataPortal_Delete(new Criteria(_maLyDoThoiViec));
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
                cm.CommandText = "spd_DeletetblnsLyDoThoiViec";

				cm.Parameters.AddWithValue("@MaLyDoThoiViec", criteria.MaLyDoThoiViec);

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
			_maLyDoThoiViec = dr.GetInt32("MaLyDoThoiViec");
			_maQuanLy = dr.GetString("MaQuanLy");
			_lyDo = dr.GetString("LyDo");
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
                cm.CommandText = "spd_InserttblnsLyDoThoiViec";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maLyDoThoiViec = (int)cm.Parameters["@MaLyDoThoiViec"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@LyDo", _lyDo);
			cm.Parameters.AddWithValue("@MaLyDoThoiViec", _maLyDoThoiViec);
			cm.Parameters["@MaLyDoThoiViec"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsLyDoThoiViec";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaLyDoThoiViec", _maLyDoThoiViec);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@LyDo", _lyDo);
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

			ExecuteDelete(cn, new Criteria(_maLyDoThoiViec));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
