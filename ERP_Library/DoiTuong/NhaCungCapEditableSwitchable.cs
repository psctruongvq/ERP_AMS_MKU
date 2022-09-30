
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhaCungCap : Csla.BusinessBase<NhaCungCap>
	{
		#region Business Properties and Methods

		//declare members
		private long _maNhaCungCap = 0;

		//declare child member(s)
		private HangCungCapList _hangCungCapList = HangCungCapList.NewHangCungCapList();

		[System.ComponentModel.DataObjectField(true, false)]
		public long MaNhaCungCap
		{
			get
			{
				CanReadProperty("MaNhaCungCap", true);
				return _maNhaCungCap;
			}
		}

		public HangCungCapList HangCungCapList
		{
			get
			{
				CanReadProperty("HangCungCapList", true);
				return _hangCungCapList;
			}
		}
 
		public override bool IsValid
		{
			get { return base.IsValid && _hangCungCapList.IsValid; }
		}

		public override bool IsDirty
		{
			get { return base.IsDirty || _hangCungCapList.IsDirty; }
		}

		protected override object GetIdValue()
		{
			return _maNhaCungCap;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

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
			//TODO: Define authorization rules in NhaCungCap
			//AuthorizationRules.AllowRead("HangCungCapList", "NhaCungCapReadGroup");
			//AuthorizationRules.AllowRead("MaNhaCungCap", "NhaCungCapReadGroup");

		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in NhaCungCap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhaCungCapViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in NhaCungCap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhaCungCapAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in NhaCungCap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhaCungCapEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in NhaCungCap
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("NhaCungCapDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private NhaCungCap()
		{ /* require use of factory method */ }

		public static NhaCungCap NewNhaCungCap()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhaCungCap");
			return DataPortal.Create<NhaCungCap>(new CriteriaAll());
		}

		public static NhaCungCap GetNhaCungCap(long maNhaCungCap)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a NhaCungCap");
			return DataPortal.Fetch<NhaCungCap>(new Criteria(maNhaCungCap));
		}

		public static void DeleteNhaCungCap(long maNhaCungCap)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhaCungCap");
			DataPortal.Delete(new Criteria(maNhaCungCap));
		}

		public override NhaCungCap Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a NhaCungCap");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a NhaCungCap");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a NhaCungCap");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private NhaCungCap(long maNhaCungCap)
		{
			this._maNhaCungCap = maNhaCungCap;
		}

		internal static NhaCungCap NewNhaCungCapChild(long maNhaCungCap)
		{
			NhaCungCap child = new NhaCungCap(maNhaCungCap);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static NhaCungCap GetNhaCungCap(SafeDataReader dr)
		{
			NhaCungCap child =  new NhaCungCap();
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
			public long MaNhaCungCap;

			public Criteria(long maNhaCungCap)
			{
				this.MaNhaCungCap = maNhaCungCap;
			}
		}

        private class CriteriaAll
        {         
            public CriteriaAll()
            {
           
            }
        }
		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(CriteriaAll criteria)
		{
			//_maNhaCungCap = criteria.MaNhaCungCap;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{			
			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();				    
				try
				{
					ExecuteFetch(cn, criteria);
				    	
				}
				catch
				{					
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlConnection cn, Criteria criteria)
		{
			using (SqlCommand cm = cn.CreateCommand())
			{				
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblNhaCungCap";

				cm.Parameters.AddWithValue("@MaNhaCungCap", criteria.MaNhaCungCap);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        //dr.Read();
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(this.MaNhaCungCap);
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
					ExecuteInsert(tr, null);

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
						ExecuteUpdate(tr, null);
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
			DataPortal_Delete(new Criteria(_maNhaCungCap));
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
                cm.CommandText = "spd_DeletetblNhaCungCap";

				cm.Parameters.AddWithValue("@MaNhaCungCap", criteria.MaNhaCungCap);

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
			FetchChildren(this.MaNhaCungCap);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maNhaCungCap = dr.GetInt64("MaNhaCungCap");
		}

		private void FetchChildren(long maNhaCungCap)
		{
			//dr.NextResult();
            _hangCungCapList = HangCungCapList.GetHangCungCapList(maNhaCungCap);
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, DoiTac parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, DoiTac parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblNhaCungCap";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm, DoiTac parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maNhaCungCap = parent.MaDoiTac;
			cm.Parameters.AddWithValue("@MaNhaCungCap", _maNhaCungCap);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, DoiTac parent)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr, parent);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr, DoiTac parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblNhaCungCap";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, DoiTac parent)
		{
			cm.Parameters.AddWithValue("@MaNhaCungCap", parent.MaDoiTac);
		}

		private void UpdateChildren(SqlTransaction tr)
		{
			_hangCungCapList.Update(tr, this);
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;
            _hangCungCapList.Clear();
            UpdateChildren(tr);
			ExecuteDelete(tr, new Criteria(_maNhaCungCap));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
