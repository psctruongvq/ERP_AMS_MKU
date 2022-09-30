using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class QuanHuyen : Csla.BusinessBase<QuanHuyen>
	{
		#region Business Properties and Methods

		//declare members
		private int _maQuanHuyen = 0;
		private string _maQuanLy = string.Empty;
		private string _tenQuanHuyen = string.Empty;
		private int _maTinhThanh = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaQuanHuyen
		{
			get
			{
				CanReadProperty("MaQuanHuyen", true);
				return _maQuanHuyen;
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

		public string TenQuanHuyen
		{
			get
			{
				CanReadProperty("TenQuanHuyen", true);
				return _tenQuanHuyen;
			}
			set
			{
				CanWriteProperty("TenQuanHuyen", true);
				if (value == null) value = string.Empty;
				if (!_tenQuanHuyen.Equals(value))
				{
					_tenQuanHuyen = value;
					PropertyHasChanged("TenQuanHuyen");
				}
			}
		}

		public int MaTinhThanh
		{
			get
			{
				CanReadProperty("MaTinhThanh", true);
				return _maTinhThanh;
			}
			set
			{
				CanWriteProperty("MaTinhThanh", true);
				if (!_maTinhThanh.Equals(value))
				{
					_maTinhThanh = value;
					PropertyHasChanged("MaTinhThanh");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maQuanHuyen;
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
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaQuanLy", 50));
			//
			// TenQuanHuyen
			//
			//ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenQuanHuyen", 500));
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
			//TODO: Define authorization rules in QuanHuyen
			//AuthorizationRules.AllowRead("MaQuanHuyen", "QuanHuyenReadGroup");
			//AuthorizationRules.AllowRead("MaQuanLy", "QuanHuyenReadGroup");
			//AuthorizationRules.AllowRead("TenQuanHuyen", "QuanHuyenReadGroup");
			//AuthorizationRules.AllowRead("MaTinhThanh", "QuanHuyenReadGroup");

			//AuthorizationRules.AllowWrite("MaQuanLy", "QuanHuyenWriteGroup");
			//AuthorizationRules.AllowWrite("TenQuanHuyen", "QuanHuyenWriteGroup");
			//AuthorizationRules.AllowWrite("MaTinhThanh", "QuanHuyenWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in QuanHuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHuyenViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in QuanHuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHuyenAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in QuanHuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHuyenEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in QuanHuyen
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("QuanHuyenDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private QuanHuyen()
		{ /* require use of factory method */ }

        private QuanHuyen(string ten, int ma)
        {
            this._tenQuanHuyen = ten;
            this._maQuanHuyen = ma;
            MarkAsChild();
        }

		public static QuanHuyen NewQuanHuyen()
		{
            QuanHuyen item = new QuanHuyen();
            item.MarkAsChild();
            return item;
		}

        public static QuanHuyen NewQuanHuyen(string ten, int ma)
        {
            return new QuanHuyen(ten, ma);
        }

		public static QuanHuyen GetQuanHuyen(int maQuanHuyen)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a QuanHuyen");
			return DataPortal.Fetch<QuanHuyen>(new Criteria(maQuanHuyen));
		}

		public static void DeleteQuanHuyen(int maQuanHuyen)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuanHuyen");
			DataPortal.Delete(new Criteria(maQuanHuyen));
		}

		public override QuanHuyen Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a QuanHuyen");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a QuanHuyen");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a QuanHuyen");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static QuanHuyen NewQuanHuyenChild()
		{
			QuanHuyen child = new QuanHuyen();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static QuanHuyen GetQuanHuyen(SafeDataReader dr)
		{
			QuanHuyen child =  new QuanHuyen();
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
			public int MaQuanHuyen;

			public Criteria(int maQuanHuyen)
			{
				this.MaQuanHuyen = maQuanHuyen;
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
                cm.CommandText = "spd_SelecttblQuanHuyen";

				cm.Parameters.AddWithValue("@MaQuanHuyen", criteria.MaQuanHuyen);

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
			DataPortal_Delete(new Criteria(_maQuanHuyen));
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
                cm.CommandText = "spd_DeletetblQuanHuyen";

				cm.Parameters.AddWithValue("@MaQuanHuyen", criteria.MaQuanHuyen);

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
			_maQuanHuyen = dr.GetInt32("MaQuanHuyen");
			_maQuanLy = dr.GetString("MaQuanLy");
			_tenQuanHuyen = dr.GetString("TenQuanHuyen");
			_maTinhThanh = dr.GetInt32("MaTinhThanh");
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
                cm.CommandText = "spd_InserttblQuanHuyen";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maQuanHuyen = (int)cm.Parameters["@MaQuanHuyen"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenQuanHuyen.Length > 0)
				cm.Parameters.AddWithValue("@TenQuanHuyen", _tenQuanHuyen);
			else
				cm.Parameters.AddWithValue("@TenQuanHuyen", DBNull.Value);
			if (_maTinhThanh != 0)
				cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
			else
				cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
			cm.Parameters.AddWithValue("@MaQuanHuyen", _maQuanHuyen);
			cm.Parameters["@MaQuanHuyen"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblQuanHuyen";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaQuanHuyen", _maQuanHuyen);
			if (_maQuanLy.Length > 0)
				cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
			else
				cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
			if (_tenQuanHuyen.Length > 0)
				cm.Parameters.AddWithValue("@TenQuanHuyen", _tenQuanHuyen);
			else
				cm.Parameters.AddWithValue("@TenQuanHuyen", DBNull.Value);
			if (_maTinhThanh != 0)
				cm.Parameters.AddWithValue("@MaTinhThanh", _maTinhThanh);
			else
				cm.Parameters.AddWithValue("@MaTinhThanh", DBNull.Value);
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

			ExecuteDelete(cn, new Criteria(_maQuanHuyen));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
