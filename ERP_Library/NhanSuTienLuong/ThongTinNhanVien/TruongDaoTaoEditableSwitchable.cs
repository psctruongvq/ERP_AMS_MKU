
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TruongDaoTao : Csla.BusinessBase<TruongDaoTao>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTruongDaoTao = 0;
		private string _maQuanLy = string.Empty;
		private string _tenTruongDaoTao = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTruongDaoTao
		{
			get
			{
				CanReadProperty("MaTruongDaoTao", true);
				return _maTruongDaoTao;
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

		public string TenTruongDaoTao
		{
			get
			{
				CanReadProperty("TenTruongDaoTao", true);
				return _tenTruongDaoTao;
			}
			set
			{
				CanWriteProperty("TenTruongDaoTao", true);
				if (value == null) value = string.Empty;
				if (!_tenTruongDaoTao.Equals(value))
				{
					_tenTruongDaoTao = value;
					PropertyHasChanged("TenTruongDaoTao");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTruongDaoTao;
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
			// TenTruongDaoTao
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenTruongDaoTao");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenTruongDaoTao", 500));
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
			//TODO: Define authorization rules in TruongDaoTao
			//AuthorizationRules.AllowRead("MaTruongDaoTao", "TruongDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "TruongDaoTaoReadGroup");
			//AuthorizationRules.AllowRead("TenTruongDaoTao", "TruongDaoTaoReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "TruongDaoTaoWriteGroup");
			//AuthorizationRules.AllowWrite("TenTruongDaoTao", "TruongDaoTaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TruongDaoTao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TruongDaoTaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TruongDaoTao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TruongDaoTaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TruongDaoTao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TruongDaoTaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TruongDaoTao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TruongDaoTaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TruongDaoTao()
		{ /* require use of factory method */ }

		public static TruongDaoTao NewTruongDaoTao()
		{
            TruongDaoTao item = new TruongDaoTao();
            item.MarkAsChild();
            return item;
		}
        public static TruongDaoTao NewTruongDaoTao(string tenTruong)
        {
            TruongDaoTao item = new TruongDaoTao();
            item.TenTruongDaoTao = tenTruong;
            item.MarkAsChild();
            return item;
        }
		public static TruongDaoTao GetTruongDaoTao(int maTruongDaoTao)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TruongDaoTao");
			return DataPortal.Fetch<TruongDaoTao>(new Criteria(maTruongDaoTao));
		}

		public static void DeleteTruongDaoTao(int maTruongDaoTao)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TruongDaoTao");
			DataPortal.Delete(new Criteria(maTruongDaoTao));
		}

		public override TruongDaoTao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TruongDaoTao");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TruongDaoTao");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TruongDaoTao");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TruongDaoTao NewTruongDaoTaoChild()
		{
			TruongDaoTao child = new TruongDaoTao();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TruongDaoTao GetTruongDaoTao(SafeDataReader dr)
		{
			TruongDaoTao child =  new TruongDaoTao();
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
			public int MaTruongDaoTao;

			public Criteria(int maTruongDaoTao)
			{
				this.MaTruongDaoTao = maTruongDaoTao;
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
                cm.CommandText = "spd_SelecttblnsTruongDaoTao";

				cm.Parameters.AddWithValue("@MaTruongDaoTao", criteria.MaTruongDaoTao);

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
			DataPortal_Delete(new Criteria(_maTruongDaoTao));
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
                cm.CommandText = "spd_DeletetblnsTruongDaoTao";

				cm.Parameters.AddWithValue("@MaTruongDaoTao", criteria.MaTruongDaoTao);

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
			_maTruongDaoTao = dr.GetInt32("MaTruongDaoTao");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenTruongDaoTao = dr.GetString("TenTruongDaoTao");
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
                cm.CommandText = "spd_InserttblnsTruongDaoTao";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maTruongDaoTao = (int)cm.Parameters["@MaTruongDaoTao"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenTruongDaoTao", _tenTruongDaoTao);
			cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
			cm.Parameters["@MaTruongDaoTao"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsTruongDaoTao";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenTruongDaoTao", _tenTruongDaoTao);
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

			ExecuteDelete(cn, new Criteria(_maTruongDaoTao));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
