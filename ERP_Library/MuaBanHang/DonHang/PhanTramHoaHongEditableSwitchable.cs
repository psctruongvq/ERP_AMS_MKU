
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class PhanTramHoaHong : Csla.BusinessBase<PhanTramHoaHong>
	{
		#region Business Properties and Methods

		//declare members
		private int _maHoaHong = 0;
		private int _maLoaiHangHoa = 0;
		private double _phanTram = 0;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaHoaHong
		{
			get
			{
				CanReadProperty("MaHoaHong", true);
				return _maHoaHong;
			}
		}

		public int MaLoaiHangHoa
		{
			get
			{
				CanReadProperty("MaLoaiHangHoa", true);
				return _maLoaiHangHoa;
			}
			set
			{
				CanWriteProperty("MaLoaiHangHoa", true);
				if (!_maLoaiHangHoa.Equals(value))
				{
					_maLoaiHangHoa = value;
					PropertyHasChanged("MaLoaiHangHoa");
				}
			}
		}

		public double PhanTram
		{
			get
			{
				CanReadProperty("PhanTram", true);
				return _phanTram;
			}
			set
			{
				CanWriteProperty("PhanTram", true);
                if (!_phanTram.Equals(value))
				{
                    _phanTram = value;
					PropertyHasChanged("PhanTram");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maHoaHong;
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
			//TODO: Define authorization rules in PhanTramHoaHong
			//AuthorizationRules.AllowRead("MaHoaHong", "PhanTramHoaHongReadGroup");
			//AuthorizationRules.AllowRead("MaLoaiHangHoa", "PhanTramHoaHongReadGroup");
			//AuthorizationRules.AllowRead("PhanTramHoaHong", "PhanTramHoaHongReadGroup");

			//AuthorizationRules.AllowWrite("MaLoaiHangHoa", "PhanTramHoaHongWriteGroup");
			//AuthorizationRules.AllowWrite("PhanTramHoaHong", "PhanTramHoaHongWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in PhanTramHoaHong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanTramHoaHongViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in PhanTramHoaHong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanTramHoaHongAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in PhanTramHoaHong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanTramHoaHongEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in PhanTramHoaHong
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("PhanTramHoaHongDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private PhanTramHoaHong()
		{ /* require use of factory method */ }

		public static PhanTramHoaHong NewPhanTramHoaHong(int maHoaHong)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanTramHoaHong");
			return DataPortal.Create<PhanTramHoaHong>(new Criteria(maHoaHong));
		}

		public static PhanTramHoaHong GetPhanTramHoaHong(int maHoaHong)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a PhanTramHoaHong");
			return DataPortal.Fetch<PhanTramHoaHong>(new Criteria(maHoaHong));
		}

        public static PhanTramHoaHong GetPhanTramHoaHongByMaHangHoa(int maHangHoa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a PhanTramHoaHong");
            return DataPortal.Fetch<PhanTramHoaHong>(new CriteriaByMaHangHoa(maHangHoa));
        }

		public static void DeletePhanTramHoaHong(int maHoaHong)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanTramHoaHong");
			DataPortal.Delete(new Criteria(maHoaHong));
		}

		public override PhanTramHoaHong Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a PhanTramHoaHong");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a PhanTramHoaHong");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a PhanTramHoaHong");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods		

		public static PhanTramHoaHong NewPhanTramHoaHongChild()
		{
			PhanTramHoaHong child = new PhanTramHoaHong();
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static PhanTramHoaHong GetPhanTramHoaHong(SafeDataReader dr)
		{
			PhanTramHoaHong child =  new PhanTramHoaHong();
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
            public int MaHoaHong;
			public Criteria(int maHoaHong)
			{
                MaHoaHong = maHoaHong;
			}
		}

        private class CriteriaByMaHangHoa
        {
            public int MaHangHoa;
            public CriteriaByMaHangHoa(int maHangHoa)
            {
                MaHangHoa = maHangHoa;
            }
        }

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maHoaHong = criteria.MaHoaHong;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Object criteria)
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

		private void ExecuteFetch(SqlTransaction tr, Object criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                if (criteria is Criteria)
                {
                    cm.CommandText = "spd_SelecttblPhanTramHoaHong";
                    cm.Parameters.AddWithValue("@MaHoaHong", ((Criteria)criteria).MaHoaHong);
                }
                else if (criteria is CriteriaByMaHangHoa)
                {
                    cm.CommandText = "spd_PhanTramHoaHongByMaHangHoa";
                    cm.Parameters.AddWithValue("@MaHangHoa", ((CriteriaByMaHangHoa)criteria).MaHangHoa);
                }

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
			DataPortal_Delete(new Criteria(_maHoaHong));
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
                cm.CommandText = "spd_DeletetblPhanTramHoaHong";

				cm.Parameters.AddWithValue("@MaHoaHong", criteria.MaHoaHong);

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
			_maHoaHong = dr.GetInt32("MaHoaHong");
			_maLoaiHangHoa = dr.GetInt32("MaLoaiHangHoa");
			_phanTram = dr.GetDouble("PhanTram");
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
                cm.CommandText = "spd_InserttblPhanTramHoaHong";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();
                _maHoaHong = (int)cm.Parameters["@MaHoaHong"].Value;

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHoaHong", _maHoaHong);
			if (_maLoaiHangHoa != 0)
				cm.Parameters.AddWithValue("@MaLoaiHangHoa", _maLoaiHangHoa);
			else
				cm.Parameters.AddWithValue("@MaLoaiHangHoa", DBNull.Value);			
				cm.Parameters.AddWithValue("@PhanTram", _phanTram);			
            cm.Parameters["@MaHoaHong"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblPhanTramHoaHong";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaHoaHong", _maHoaHong);
			if (_maLoaiHangHoa != 0)
				cm.Parameters.AddWithValue("@MaLoaiHangHoa", _maLoaiHangHoa);
			else
				cm.Parameters.AddWithValue("@MaLoaiHangHoa", DBNull.Value);			
				cm.Parameters.AddWithValue("@PhanTram", _phanTram);			
				
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

			ExecuteDelete(tr, new Criteria(_maHoaHong));
			MarkNew();
		}
		#endregion //Data Access - Delete

		#endregion //Data Access
	}
}
