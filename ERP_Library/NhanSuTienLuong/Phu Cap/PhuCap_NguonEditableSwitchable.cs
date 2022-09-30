using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhuCap_Nguon : Csla.BusinessBase<PhuCap_Nguon>
	{
		#region Business Properties and Methods

		//declare members
		private int _maPhuCapNguon = 0;
		private int _maNguon = 0;
		private int _maNhomPhuCap = 0;
        private int _maLoaiPhuCap = 0;
		private int _maKy = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaPhuCapNguon
		{
			get
			{
				CanReadProperty("MaPhuCapNguon", true);
				return _maPhuCapNguon;
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

		public int MaNhomPhuCap
		{
			get
			{
				CanReadProperty("MaNhomPhuCap", true);
				return _maNhomPhuCap;
			}
			set
			{
				CanWriteProperty("MaNhomPhuCap", true);
				if (!_maNhomPhuCap.Equals(value))
				{
					_maNhomPhuCap = value;
					PropertyHasChanged("MaNhomPhuCap");
				}
			}
		}
        public int MaLoaiPhuCap
        {
            get
            {
                CanReadProperty("MaLoaiPhuCap", true);
                return _maLoaiPhuCap;
            }
            set
            {
                CanWriteProperty("MaLoaiPhuCap", true);
                if (!_maLoaiPhuCap.Equals(value))
                {
                    _maLoaiPhuCap = value;
                    PropertyHasChanged("MaLoaiPhuCap");
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
 
		protected override object GetIdValue()
		{
			return _maPhuCapNguon;
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
			//TODO: Define authorization rules in PhuCapNguon
			//AuthorizationRules.AllowRead("MaPhuCapNguon", "PhuCapNguonReadGroup");
			//AuthorizationRules.AllowRead("MaNguon", "PhuCapNguonReadGroup");
			//AuthorizationRules.AllowRead("MaNhomPhuCap", "PhuCapNguonReadGroup");
			//AuthorizationRules.AllowRead("MaKy", "PhuCapNguonReadGroup");

			//AuthorizationRules.AllowWrite("MaNguon", "PhuCapNguonWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhomPhuCap", "PhuCapNguonWriteGroup");
			//AuthorizationRules.AllowWrite("MaKy", "PhuCapNguonWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhuCapNguon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapNguonViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhuCapNguon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapNguonAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhuCapNguon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapNguonEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhuCapNguon
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhuCapNguonDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhuCap_Nguon()
		{ /* require use of factory method */
            this.MarkAsChild();
        }

		public static PhuCap_Nguon NewPhuCapNguon()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuCapNguon");
			return DataPortal.Create<PhuCap_Nguon>();
		}

		public static PhuCap_Nguon GetPhuCapNguon(int maPhuCapNguon)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhuCapNguon");
			return DataPortal.Fetch<PhuCap_Nguon>(new Criteria(maPhuCapNguon));
		}

		public static void DeletePhuCapNguon(int maPhuCapNguon)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhuCapNguon");
			DataPortal.Delete(new Criteria(maPhuCapNguon));
		}

		public override PhuCap_Nguon Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhuCapNguon");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhuCapNguon");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhuCapNguon");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static PhuCap_Nguon NewPhuCapNguonChild()
		{
			PhuCap_Nguon child = new PhuCap_Nguon();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhuCap_Nguon GetPhuCapNguon(SafeDataReader dr)
		{
			PhuCap_Nguon child =  new PhuCap_Nguon();
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
			public int MaPhuCapNguon;

			public Criteria(int maPhuCapNguon)
			{
				this.MaPhuCapNguon = maPhuCapNguon;
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
                cm.CommandText = "spd_SelecttblnsPhuCap_Nguon";

				cm.Parameters.AddWithValue("@MaPhuCapNguon", criteria.MaPhuCapNguon);

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
			DataPortal_Delete(new Criteria(_maPhuCapNguon));
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
                cm.CommandText = "spd_DeletetblnsPhuCap_Nguon";

				cm.Parameters.AddWithValue("@MaPhuCapNguon", criteria.MaPhuCapNguon);

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
			_maPhuCapNguon = dr.GetInt32("MaPhuCapNguon");
			_maNguon = dr.GetInt32("MaNguon");
			_maNhomPhuCap = dr.GetInt32("MaNhomPhuCap");
            _maLoaiPhuCap = dr.GetInt32("MaLoaiPhuCap");
			_maKy = dr.GetInt32("MaKy");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhuCap_NguonList parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhuCap_NguonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblnsPhuCap_Nguon";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_maPhuCapNguon = (int)cm.Parameters["@MaPhuCapNguon"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhuCap_NguonList parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
			if (_maNhomPhuCap != 0)
				cm.Parameters.AddWithValue("@MaNhomPhuCap", _maNhomPhuCap);
			else
				cm.Parameters.AddWithValue("@MaNhomPhuCap", DBNull.Value);
            if (_maLoaiPhuCap != 0)
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            else
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", DBNull.Value);
			if (_maKy != 0)
				cm.Parameters.AddWithValue("@MaKy", _maKy);
			else
				cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
            cm.Parameters.AddWithValue("@MaPhuCapNguon", _maPhuCapNguon);
            cm.Parameters["@MaPhuCapNguon"].Direction = ParameterDirection.Output;
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr, PhuCap_NguonList parent)
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

		private void ExecuteUpdate(SqlTransaction tr, PhuCap_NguonList parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblnsPhuCap_Nguon";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhuCap_NguonList parent)
		{
			cm.Parameters.AddWithValue("@MaPhuCapNguon", _maPhuCapNguon);
			if (_maNguon != 0)
				cm.Parameters.AddWithValue("@MaNguon", _maNguon);
			else
				cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
			if (_maNhomPhuCap != 0)
				cm.Parameters.AddWithValue("@MaNhomPhuCap", _maNhomPhuCap);
			else
				cm.Parameters.AddWithValue("@MaNhomPhuCap", DBNull.Value);
            if (_maLoaiPhuCap != 0)
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", _maLoaiPhuCap);
            else
                cm.Parameters.AddWithValue("@MaLoaiPhuCap", DBNull.Value);
			if (_maKy != 0)
				cm.Parameters.AddWithValue("@MaKy", _maKy);
			else
				cm.Parameters.AddWithValue("@MaKy", DBNull.Value);
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

			ExecuteDelete(tr, new Criteria(_maPhuCapNguon));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
