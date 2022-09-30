
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class BoQuiDoi : Csla.BusinessBase<BoQuiDoi>
	{
		#region Business Properties and Methods

		//declare members
		private int _maBoQuiDoi = 0;
		private int _maHangHoa = 0;
		private int _maDonViQuiDoi = 0;
		private double _tyLeQuiDoi = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int MaBoQuiDoi
		{
			get
			{
				CanReadProperty("MaBoQuiDoi", true);
				return _maBoQuiDoi;
			}
		}

		public int MaHangHoa
		{
			get
			{
				CanReadProperty("MaHangHoa", true);
				return _maHangHoa;
			}
			set
			{
				CanWriteProperty("MaHangHoa", true);
				if (!_maHangHoa.Equals(value))
				{
					_maHangHoa = value;
					PropertyHasChanged("MaHangHoa");
				}
			}
		}

		public int MaDonViQuiDoi
		{
			get
			{
				CanReadProperty("MaDonViQuiDoi", true);
				return _maDonViQuiDoi;
			}
			set
			{
				CanWriteProperty("MaDonViQuiDoi", true);
				if (!_maDonViQuiDoi.Equals(value))
				{
					_maDonViQuiDoi = value;
					PropertyHasChanged("MaDonViQuiDoi");
				}
			}
		}

		public double TyLeQuiDoi
		{
			get
			{
				CanReadProperty("TyLeQuiDoi", true);
				return _tyLeQuiDoi;
			}
			set
			{
				CanWriteProperty("TyLeQuiDoi", true);
				if (!_tyLeQuiDoi.Equals(value))
				{
					_tyLeQuiDoi = value;
					PropertyHasChanged("TyLeQuiDoi");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maBoQuiDoi;
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
			//TODO: Define authorization rules in BoQuiDoi
			//AuthorizationRules.AllowRead("MaBoQuiDoi", "BoQuiDoiReadGroup");
			//AuthorizationRules.AllowRead("MaHangHoa", "BoQuiDoiReadGroup");
			//AuthorizationRules.AllowRead("MaDonViQuiDoi", "BoQuiDoiReadGroup");
			//AuthorizationRules.AllowRead("TyLeQuiDoi", "BoQuiDoiReadGroup");

			//AuthorizationRules.AllowWrite("MaHangHoa", "BoQuiDoiWriteGroup");
			//AuthorizationRules.AllowWrite("MaDonViQuiDoi", "BoQuiDoiWriteGroup");
			//AuthorizationRules.AllowWrite("TyLeQuiDoi", "BoQuiDoiWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in BoQuiDoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoQuiDoiViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in BoQuiDoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoQuiDoiAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in BoQuiDoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoQuiDoiEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in BoQuiDoi
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("BoQuiDoiDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private BoQuiDoi()
		{ /* require use of factory method */ }

		public static BoQuiDoi NewBoQuiDoi()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoQuiDoi");
			return DataPortal.Create<BoQuiDoi>();
		}

		public static BoQuiDoi GetBoQuiDoi(int maBoQuiDoi)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a BoQuiDoi");
			return DataPortal.Fetch<BoQuiDoi>(new Criteria(maBoQuiDoi));
		}

		public static void DeleteBoQuiDoi(int maBoQuiDoi)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoQuiDoi");
			DataPortal.Delete(new Criteria(maBoQuiDoi));
		}

		public override BoQuiDoi Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a BoQuiDoi");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a BoQuiDoi");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a BoQuiDoi");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		internal static BoQuiDoi NewBoQuiDoiChild()
		{
			BoQuiDoi child = new BoQuiDoi();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static BoQuiDoi GetBoQuiDoi(SafeDataReader dr)
		{
			BoQuiDoi child =  new BoQuiDoi();
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
			public int MaBoQuiDoi;

			public Criteria(int maBoQuiDoi)
			{
				this.MaBoQuiDoi = maBoQuiDoi;
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
                cm.CommandText = "spd_SelecttblBoQuiDoi";

				cm.Parameters.AddWithValue("@MaBoQuiDoi", criteria.MaBoQuiDoi);

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
			DataPortal_Delete(new Criteria(_maBoQuiDoi));
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
                cm.CommandText = "spd_DeletetblBoQuiDoi";

				cm.Parameters.AddWithValue("@MaBoQuiDoi", criteria.MaBoQuiDoi);

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
			_maBoQuiDoi = dr.GetInt32("MaBoQuiDoi");
			_maHangHoa = dr.GetInt32("MaHangHoa");
			_maDonViQuiDoi = dr.GetInt32("MaDonViQuiDoi");
			_tyLeQuiDoi = dr.GetDouble("TyLeQuiDoi");
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
                cm.CommandText = "spd_InserttblBoQuiDoi";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

				_maBoQuiDoi = (int)cm.Parameters["@MaBoQuiDoi"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
            if(_maDonViQuiDoi!=0)
			    cm.Parameters.AddWithValue("@MaDonViQuiDoi", _maDonViQuiDoi);
            else
                cm.Parameters.AddWithValue("@MaDonViQuiDoi", DBNull.Value);
			cm.Parameters.AddWithValue("@TyLeQuiDoi", _tyLeQuiDoi);
			cm.Parameters.AddWithValue("@MaBoQuiDoi", _maBoQuiDoi);
			cm.Parameters["@MaBoQuiDoi"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblBoQuiDoi";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaBoQuiDoi", _maBoQuiDoi);
			if (_maHangHoa != 0)
				cm.Parameters.AddWithValue("@MaHangHoa", _maHangHoa);
			else
				cm.Parameters.AddWithValue("@MaHangHoa", DBNull.Value);
			if (_maDonViQuiDoi!=0)
                cm.Parameters.AddWithValue("@MaDonViQuiDoi", _maDonViQuiDoi);
            else
                cm.Parameters.AddWithValue("@MaDonViQuiDoi", DBNull.Value);
			cm.Parameters.AddWithValue("@TyLeQuiDoi", _tyLeQuiDoi);
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

			ExecuteDelete(tr, new Criteria(_maBoQuiDoi));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
