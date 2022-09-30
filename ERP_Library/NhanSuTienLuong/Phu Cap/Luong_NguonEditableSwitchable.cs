using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class Luong_Nguon : Csla.BusinessBase<Luong_Nguon>
	{
		#region Business Properties and Methods

		//declare members
		private int _maluongNguon = 0;
		private string _loai = string.Empty;
		private int _maKy = 0;
		private int _maNguon = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaluongNguon
		{
			get
			{
				CanReadProperty("MaluongNguon", true);
				return _maluongNguon;
			}
		}

		public string Loai
		{
			get
			{
				CanReadProperty("Loai", true);
				return _loai;
			}
			set
			{
				CanWriteProperty("Loai", true);
				if (value == null) value = string.Empty;
				if (!_loai.Equals(value))
				{
					_loai = value;
					PropertyHasChanged("Loai");
				}
			}
		}

		public int MaKy
		{
			get
			{
				CanReadProperty("MaKy", true);
				return _maKy;
			}
			set
			{
				CanWriteProperty("MaKy", true);
				if (!_maKy.Equals(value))
				{
					_maKy = value;
					PropertyHasChanged("MaKy");
				}
			}
		}

		public int MaNguon
		{
			get
			{
				CanReadProperty("MaNguon", true);
				return _maNguon;
			}
			set
			{
				CanWriteProperty("MaNguon", true);
				if (!_maNguon.Equals(value))
				{
					_maNguon = value;
					PropertyHasChanged("MaNguon");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maluongNguon;
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
			// Loai
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("Loai", 200));
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
			//TODO: Define authorization rules in Luong_Nguon
			//AuthorizationRules.AllowRead("MaluongNguon", "Luong_NguonReadGroup");
			//AuthorizationRules.AllowRead("Loai", "Luong_NguonReadGroup");
			//AuthorizationRules.AllowRead("MaKy", "Luong_NguonReadGroup");
			//AuthorizationRules.AllowRead("MaNguon", "Luong_NguonReadGroup");

			//AuthorizationRules.AllowWrite("Loai", "Luong_NguonWriteGroup");
			//AuthorizationRules.AllowWrite("MaKy", "Luong_NguonWriteGroup");
			//AuthorizationRules.AllowWrite("MaNguon", "Luong_NguonWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in Luong_Nguon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Luong_NguonViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in Luong_Nguon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Luong_NguonAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in Luong_Nguon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Luong_NguonEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in Luong_Nguon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("Luong_NguonDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private Luong_Nguon()
        { /* require use of factory method */ this.MarkAsChild(); }

		public static Luong_Nguon NewLuong_Nguon()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Luong_Nguon");
			return DataPortal.Create<Luong_Nguon>();
		}

		public static Luong_Nguon GetLuong_Nguon(int maluongNguon)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a Luong_Nguon");
			return DataPortal.Fetch<Luong_Nguon>(new Criteria(maluongNguon));
		}

		public static void DeleteLuong_Nguon(int maluongNguon)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Luong_Nguon");
			DataPortal.Delete(new Criteria(maluongNguon));
		}

		public override Luong_Nguon Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a Luong_Nguon");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a Luong_Nguon");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a Luong_Nguon");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static Luong_Nguon NewLuong_NguonChild()
		{
			Luong_Nguon child = new Luong_Nguon();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static Luong_Nguon GetLuong_Nguon(SafeDataReader dr)
		{
			Luong_Nguon child =  new Luong_Nguon();
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
			public int MaluongNguon;

			public Criteria(int maluongNguon)
			{
				this.MaluongNguon = maluongNguon;
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
                cm.CommandText = "spd_SelecttblnsLuong_Nguon";

				cm.Parameters.AddWithValue("@MaLuong_Nguon", criteria.MaluongNguon);

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
			DataPortal_Delete(new Criteria(_maluongNguon));
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
                cm.CommandText = "spd_DeletetblnsLuong_Nguon";

				cm.Parameters.AddWithValue("@MaLuong_Nguon", criteria.MaluongNguon);

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
			_maluongNguon = dr.GetInt32("MaLuong_Nguon");
			_loai = dr.GetString("Loai");
			_maKy = dr.GetInt32("MaKy");
			_maNguon = dr.GetInt32("MaNguon");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, Luong_NguonList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, Luong_NguonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsLuong_Nguon";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maluongNguon = (int)cm.Parameters["@MaLuong_Nguon"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, Luong_NguonList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_loai.Length > 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
			if (_maKy != 0)
				cm.Parameters.AddWithValue("@MaKy", _maKy);
			else
				cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
            cm.Parameters.AddWithValue("@MaLuong_Nguon", _maluongNguon);
            cm.Parameters["@MaLuong_Nguon"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, Luong_NguonList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, Luong_NguonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsLuong_Nguon";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, Luong_NguonList parent)
		{
			cm.Parameters.AddWithValue("@MaLuong_Nguon", _maluongNguon);
			if (_loai.Length > 0)
				cm.Parameters.AddWithValue("@Loai", _loai);
			else
				cm.Parameters.AddWithValue("@Loai", DBNull.Value);
			if (_maKy != 0)
				cm.Parameters.AddWithValue("@MaKy", _maKy);
			else
				cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maluongNguon));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
