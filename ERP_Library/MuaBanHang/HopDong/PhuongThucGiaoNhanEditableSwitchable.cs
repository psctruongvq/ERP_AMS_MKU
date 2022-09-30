
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhuongThucGiaoNhan : Csla.BusinessBase<PhuongThucGiaoNhan>
	{
		#region Business Properties and Methods

		//declare members
		private int _maPhuongThucGiaoNhan = 0;
        private string _maPTGNQL = string.Empty;
		private string _tenPhuongThuc = string.Empty;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaPhuongThucGiaoNhan
		{
			get
			{
				CanReadProperty("MaPhuongThucGiaoNhan", true);
				return _maPhuongThucGiaoNhan;
			}
		}

        public string MaPTGNQL
        {
            get
            {
                CanReadProperty("MaPTGNQL", true);
                return _maPTGNQL;
            }
            set
            {
                CanWriteProperty("MaPTGNQL", true);
                if (value == null) value = string.Empty;
                if (!_maPTGNQL.Equals(value))
                {
                    _maPTGNQL = value;
                    PropertyHasChanged("MaPTGNQL");
                }
            }
        }    

		public string TenPhuongThuc
		{
			get
			{
				CanReadProperty("TenPhuongThuc", true);
				return _tenPhuongThuc;
			}
			set
			{
				CanWriteProperty("TenPhuongThuc", true);
				if (value == null) value = string.Empty;
				if (!_tenPhuongThuc.Equals(value))
				{
					_tenPhuongThuc = value;
					PropertyHasChanged("TenPhuongThuc");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maPhuongThucGiaoNhan;
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
			// TenPhuongThuc
			//
			ValidationRules.AddRule(CommonRules.StringRequired, "TenPhuongThuc");
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenPhuongThuc", 500));
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
			//TODO: Define authorization rules in PhuongThucGiaoNhan
			//AuthorizationRules.AllowRead("MaPhuongThucGiaoNhan", "PhuongThucGiaoNhanReadGroup");
			//AuthorizationRules.AllowRead("TenPhuongThuc", "PhuongThucGiaoNhanReadGroup");

			//AuthorizationRules.AllowWrite("TenPhuongThuc", "PhuongThucGiaoNhanWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhuongThucGiaoNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucGiaoNhanViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhuongThucGiaoNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucGiaoNhanAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhuongThucGiaoNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucGiaoNhanEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhuongThucGiaoNhan
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuongThucGiaoNhanDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhuongThucGiaoNhan()
		{ /* require use of factory method */
            MarkAsChild();
        }

		public static PhuongThucGiaoNhan NewPhuongThucGiaoNhan()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuongThucGiaoNhan");
			return DataPortal.Create<PhuongThucGiaoNhan>();
		}

		public static PhuongThucGiaoNhan GetPhuongThucGiaoNhan(int maPhuongThucGiaoNhan)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhuongThucGiaoNhan");
			return DataPortal.Fetch<PhuongThucGiaoNhan>(new Criteria(maPhuongThucGiaoNhan));
		}

		public static void DeletePhuongThucGiaoNhan(int maPhuongThucGiaoNhan)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhuongThucGiaoNhan");
			DataPortal.Delete(new Criteria(maPhuongThucGiaoNhan));
		}

		public override PhuongThucGiaoNhan Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhuongThucGiaoNhan");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuongThucGiaoNhan");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhuongThucGiaoNhan");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhuongThucGiaoNhan NewPhuongThucGiaoNhanChild()
		{
			PhuongThucGiaoNhan child = new PhuongThucGiaoNhan();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhuongThucGiaoNhan GetPhuongThucGiaoNhan(SafeDataReader dr)
		{
			PhuongThucGiaoNhan child =  new PhuongThucGiaoNhan();
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
			public int MaPhuongThucGiaoNhan;

			public Criteria(int maPhuongThucGiaoNhan)
			{
				this.MaPhuongThucGiaoNhan = maPhuongThucGiaoNhan;
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
                cm.CommandText = "spd_SelecttblPhuongThucGiaoNhan";

				cm.Parameters.AddWithValue("@MaPhuongThucGiaoNhan", criteria.MaPhuongThucGiaoNhan);

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
			DataPortal_Delete(new Criteria(_maPhuongThucGiaoNhan));
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
                cm.CommandText = "spd_DeletetblPhuongThucGiaoNhan";

				cm.Parameters.AddWithValue("@MaPhuongThucGiaoNhan", criteria.MaPhuongThucGiaoNhan);

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
			_maPhuongThucGiaoNhan = dr.GetInt32("MaPhuongThucGiaoNhan");
            _maPTGNQL = dr.GetString("MaPTGNQL");
			_tenPhuongThuc = dr.GetString("TenPhuongThuc");
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
                cm.CommandText = "spd_InserttblPhuongThucGiaoNhan";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maPhuongThucGiaoNhan = (int)cm.Parameters["@MaPhuongThucGiaoNhan"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@TenPhuongThuc", _tenPhuongThuc);
            cm.Parameters.AddWithValue("@MaPTGNQL", _maPTGNQL);
			cm.Parameters.AddWithValue("@MaPhuongThucGiaoNhan", _maPhuongThucGiaoNhan);
			cm.Parameters["@MaPhuongThucGiaoNhan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblPhuongThucGiaoNhan";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaPhuongThucGiaoNhan", _maPhuongThucGiaoNhan);
			cm.Parameters.AddWithValue("@TenPhuongThuc", _tenPhuongThuc);
            cm.Parameters.AddWithValue("@MaPTGNQL", _maPTGNQL);
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

			ExecuteDelete(tr, new Criteria(_maPhuongThucGiaoNhan));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
