
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanBoGTGT : Csla.BusinessBase<PhanBoGTGT>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKy = 0;
		private decimal _c1 = 0;
		private decimal _c2 = 0;
		private decimal _c3 = 0;
		private decimal _c4 = 0;
		private decimal _c5 = 0;
		private int _manhanVien = 0;
		private DateTime _ngayLap =DateTime.Now;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaKy
		{
			get
			{
				CanReadProperty("MaKy", true);
				return _maKy;
			}
		}

		public decimal C1
		{
			get
			{
				CanReadProperty("C1", true);
				return _c1;
			}
			set
			{
				CanWriteProperty("C1", true);
				if (!_c1.Equals(value))
				{
					_c1 = value;
                   // _c3 = _c2 / _c1;
					PropertyHasChanged("C1");
				}
			}
		}

		public decimal C2
		{
			get
			{
				CanReadProperty("C2", true);
				return _c2;
			}
			set
			{
				CanWriteProperty("C2", true);
				if (!_c2.Equals(value))
                {

					_c2 = value;
                    //_c3 = _c2 / _c1;
					PropertyHasChanged("C2");
				}
			}
		}

		public decimal C3
		{
			get
			{
				CanReadProperty("C3", true);
				return _c3;
			}
			set
			{
				CanWriteProperty("C3", true);
				if (!_c3.Equals(value))
				{
					_c3 = value;
                    //_c5 = _c4 * _c3;
					PropertyHasChanged("C3");
				}
			}
		}

		public decimal C4
		{
			get
			{
				CanReadProperty("C4", true);
				return _c4;
			}
			set
			{
				CanWriteProperty("C4", true);
				if (!_c4.Equals(value))
				{
					_c4 = value;
                    //_c5 = _c4 * _c3;
					PropertyHasChanged("C4");
				}
			}
		}

		public decimal C5
		{
			get
			{
				CanReadProperty("C5", true);
				return _c5;
			}
			set
			{
				CanWriteProperty("C5", true);
				if (!_c5.Equals(value))
				{
					_c5 = value;
					PropertyHasChanged("C5");
				}
			}
		}

		public int ManhanVien
		{
			get
			{
				CanReadProperty("ManhanVien", true);
				return _manhanVien;
			}
			set
			{
				CanWriteProperty("ManhanVien", true);
				if (!_manhanVien.Equals(value))
				{
					_manhanVien = value;
					PropertyHasChanged("ManhanVien");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap.Date;
			}
            set{
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap=value;
                }
            }
		}

	
 
		protected override object GetIdValue()
		{
			return _maKy;
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
			//TODO: Define authorization rules in PhanBoGTGT
			//AuthorizationRules.AllowRead("MaKy", "PhanBoGTGTReadGroup");
			//AuthorizationRules.AllowRead("C1", "PhanBoGTGTReadGroup");
			//AuthorizationRules.AllowRead("C2", "PhanBoGTGTReadGroup");
			//AuthorizationRules.AllowRead("C3", "PhanBoGTGTReadGroup");
			//AuthorizationRules.AllowRead("C4", "PhanBoGTGTReadGroup");
			//AuthorizationRules.AllowRead("C5", "PhanBoGTGTReadGroup");
			//AuthorizationRules.AllowRead("ManhanVien", "PhanBoGTGTReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "PhanBoGTGTReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "PhanBoGTGTReadGroup");

			//AuthorizationRules.AllowWrite("C1", "PhanBoGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C2", "PhanBoGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C3", "PhanBoGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C4", "PhanBoGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C5", "PhanBoGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("ManhanVien", "PhanBoGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "PhanBoGTGTWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanBoGTGT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoGTGTViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanBoGTGT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoGTGTAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanBoGTGT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoGTGTEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanBoGTGT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanBoGTGTDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanBoGTGT()
		{ /* require use of factory method */ }

		public static PhanBoGTGT NewPhanBoGTGT(int maKy)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoGTGT");
			return DataPortal.Create<PhanBoGTGT>(new Criteria(maKy));
		}

		public static PhanBoGTGT GetPhanBoGTGT(int maKy)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanBoGTGT");
			return DataPortal.Fetch<PhanBoGTGT>(new Criteria(maKy));
		}

		public static void DeletePhanBoGTGT(int maKy)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoGTGT");
			DataPortal.Delete(new Criteria(maKy));
		}

		public override PhanBoGTGT Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanBoGTGT");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanBoGTGT");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhanBoGTGT");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private PhanBoGTGT(int maKy)
		{
			this._maKy = maKy;
		}

		internal static PhanBoGTGT NewPhanBoGTGTChild(int maKy)
		{
			PhanBoGTGT child = new PhanBoGTGT(maKy);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhanBoGTGT GetPhanBoGTGT(SafeDataReader dr)
		{
			PhanBoGTGT child =  new PhanBoGTGT();
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
			_maKy = criteria.MaKy;
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
				cm.CommandText = "[spd_SelecttblBangPhanBoGTGT]";

				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
					while(dr.Read())
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
			DataPortal_Delete(new Criteria(_maKy));
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
				cm.CommandText = "DeletePhanBoGTGT";

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
			_maKy = dr.GetInt32("MaKy");
			_c1 = dr.GetDecimal("C1");
			_c2 = dr.GetDecimal("C2");
			_c3 = dr.GetDecimal("C3");
			_c4 = dr.GetDecimal("C4");
			_c5 = dr.GetDecimal("C5");
			_manhanVien = dr.GetInt32("ManhanVien");
			_ngayLap = dr.GetDateTime("NgayLap");
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
				cm.CommandText = "AddPhanBoGTGT";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_c1 != 0)
				cm.Parameters.AddWithValue("@C1", _c1);
			else
				cm.Parameters.AddWithValue("@C1", DBNull.Value);
			if (_c2 != 0)
				cm.Parameters.AddWithValue("@C2", _c2);
			else
				cm.Parameters.AddWithValue("@C2", DBNull.Value);
			if (_c3 != 0)
				cm.Parameters.AddWithValue("@C3", _c3);
			else
				cm.Parameters.AddWithValue("@C3", DBNull.Value);
			if (_c4 != 0)
				cm.Parameters.AddWithValue("@C4", _c4);
			else
				cm.Parameters.AddWithValue("@C4", DBNull.Value);
			if (_c5 != 0)
				cm.Parameters.AddWithValue("@C5", _c5);
			else
				cm.Parameters.AddWithValue("@C5", DBNull.Value);
			if (_manhanVien != 0)
				cm.Parameters.AddWithValue("@ManhanVien", _manhanVien);
			else
				cm.Parameters.AddWithValue("@ManhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Date);
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
				cm.CommandText = "[spd_UpdatetblBangPhanBoGTGT]";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKy", _maKy);
		
				cm.Parameters.AddWithValue("@C1", _c1);			
	
				cm.Parameters.AddWithValue("@C2", _c2);	
		
				cm.Parameters.AddWithValue("@C3", _c3);
		
				cm.Parameters.AddWithValue("@C4", _c4);
			
				cm.Parameters.AddWithValue("@C5", _c5);
			
				cm.Parameters.AddWithValue("@ManhanVien", _manhanVien);
			
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Date);
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

			ExecuteDelete(tr, new Criteria(_maKy));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
