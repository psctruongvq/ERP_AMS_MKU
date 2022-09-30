
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class TonGiao : Csla.BusinessBase<TonGiao>
	{
		#region Business Properties and Methods

		//declare members
		private int _maTonGiao = 0;
		private string _maQuanLy = string.Empty;
		private string _tenTonGiao = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaTonGiao
		{
			get
			{
				CanReadProperty("MaTonGiao", true);
				return _maTonGiao;
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

		public string TenTonGiao
		{
			get
			{
				CanReadProperty("TenTonGiao", true);
				return _tenTonGiao;
			}
			set
			{
				CanWriteProperty("TenTonGiao", true);
				if (value == null) value = string.Empty;
				if (!_tenTonGiao.Equals(value))
				{
					_tenTonGiao = value;
					PropertyHasChanged("TenTonGiao");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maTonGiao;
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
			// TonGiao
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TonGiao");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TonGiao", 50));
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
			//TODO: Define authorization rules in TonGiao
			//AuthorizationRules.AllowRead("MaTonGiao", "TonGiaoReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "TonGiaoReadGroup");
			//AuthorizationRules.AllowRead("TonGiao", "TonGiaoReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "TonGiaoWriteGroup");
			//AuthorizationRules.AllowWrite("TonGiao", "TonGiaoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in TonGiao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TonGiaoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in TonGiao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TonGiaoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in TonGiao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TonGiaoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in TonGiao
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("TonGiaoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private TonGiao()
		{ /* require use of factory method */ }

		public static TonGiao NewTonGiao()
		{
            TonGiao item = new TonGiao();
            item.MarkAsChild();
            return item;
		}
        private TonGiao(int matongia, string tentongiao)
        {
            this._maTonGiao = matongia;
            this._tenTonGiao = tentongiao;
        }

        public static TonGiao NewTonGiao(int matongiao, string tentongiao)
        {
            return new TonGiao(matongiao, tentongiao);
        }
		public static TonGiao GetTonGiao(int maTonGiao)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a TonGiao");
			return DataPortal.Fetch<TonGiao>(new Criteria(maTonGiao));
		}

		public static void DeleteTonGiao(int maTonGiao)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TonGiao");
			DataPortal.Delete(new Criteria(maTonGiao));
		}

		public override TonGiao Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a TonGiao");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a TonGiao");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a TonGiao");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static TonGiao NewTonGiaoChild()
		{
			TonGiao child = new TonGiao();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static TonGiao GetTonGiao(SafeDataReader dr)
		{
			TonGiao child =  new TonGiao();
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
			public int MaTonGiao;

			public Criteria(int maTonGiao)
			{
				this.MaTonGiao = maTonGiao;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		protected override void DataPortal_Create()
		{
			//ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblnsTonGiao";

				cm.Parameters.AddWithValue("@MaTonGiao", criteria.MaTonGiao);

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
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr);

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					if (base.IsDirty)
					{
						ExecuteUpdate(tr);
					}

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maTonGiao));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteDelete(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblnsTonGiao";

				cm.Parameters.AddWithValue("@MaTonGiao", criteria.MaTonGiao);

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
			_maTonGiao = dr.GetInt32("MaTonGiao");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenTonGiao = dr.GetString("TenTonGiao");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsTonGiao";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maTonGiao = (int)cm.Parameters["@MaTonGiao"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenTonGiao", _tenTonGiao);
			cm.Parameters.AddWithValue("@MaTonGiao", _maTonGiao);
			cm.Parameters["@MaTonGiao"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsTonGiao";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaTonGiao", _maTonGiao);
			cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			cm.Parameters.AddWithValue("@TenTonGiao", _tenTonGiao);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maTonGiao));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
