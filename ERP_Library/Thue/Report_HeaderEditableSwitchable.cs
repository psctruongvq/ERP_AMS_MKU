
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class Report_Header : Csla.BusinessBase<Report_Header>
	{
		#region Business Properties and Methods

		//declare members
		private int _macongty = 0;     
        private string _tencongty = "";
        private string _diachi = "";
        
        private string _sodtfax = "";
        private string _tinht = "";
        private string _masothue = "";  

		[System.ComponentModel.DataObjectField(true, false)]
		public int macongty
		{
			get
			{
				CanReadProperty( true);
				return _macongty;
			}
		}
      
         public string Tencongty
         {
             get
             {
                 CanReadProperty(true);
                 return _tencongty;
             }
         }
         public string Diachi
         {
             get
             {
                 CanReadProperty(true);
                 return _diachi;
             }
         }       
         public string Sodtfax
         {
             get
             {
                 CanReadProperty(true);
                 return _sodtfax;
             }
         }
         public string TinhT
         {
             get
             {
                 CanReadProperty(true);
                 return _tinht;
             }
         }
         public string Masothue
         {
             get
             {
                 CanReadProperty(true);
                 return _masothue;
             }
         }
        
		protected override object GetIdValue()
		{
			return _macongty;
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
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in Report_Header
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Report_HeaderViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in Report_Header
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Report_HeaderAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in Report_Header
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Report_HeaderEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in Report_Header
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Report_HeaderDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private Report_Header()
		{ /* require use of factory method */ }

		public static Report_Header NewReport_Header(int maKy)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Report_Header");
			return DataPortal.Create<Report_Header>(new Criteria(maKy));
		}

		public static Report_Header GetReport_Header(int maKy)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a Report_Header");
			return DataPortal.Fetch<Report_Header>(new Criteria(maKy));
		}

		public static void DeleteReport_Header(int maKy)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Report_Header");
			DataPortal.Delete(new Criteria(maKy));
		}

		public override Report_Header Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Report_Header");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Report_Header");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a Report_Header");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private Report_Header(int maKy)
		{
			this._macongty = maKy;
		}

		internal static Report_Header NewReport_HeaderChild(int maKy)
		{
			Report_Header child = new Report_Header(maKy);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static Report_Header GetReport_Header(SafeDataReader dr)
		{
			Report_Header child =  new Report_Header();
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
			public int MaKy;

			public Criteria(int maKy)
			{
				this.MaKy = maKy;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_macongty = criteria.MaKy;
			ValidationRules.CheckRules();
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
                cm.CommandText = "spd_reportThue01_2GTGT";
				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

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
			DataPortal_Delete(new Criteria(_macongty));
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
				cm.CommandText = "DeleteReport_Header";

				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

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
           // _maKy = dr.GetInt32("MaKy");           
            _tencongty = dr.GetString("tencongty");
            _sodtfax = dr.GetString("sodtfax");
            _diachi = dr.GetString("diachi");
            _tinht = dr.GetString("tinht");
            _masothue = dr.GetString("masothue");           
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
				cm.CommandText = "[dbo].[spd_InserttblToKhaiThueGTGTGianTiep]";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			
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
				cm.CommandText = "[dbo].[spd_UpdatetblToKhaiThueGTGTGianTiep]";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm)
        {          

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

			ExecuteDelete(tr, new Criteria(_macongty));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
