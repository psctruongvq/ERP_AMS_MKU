

using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()]
    public class DanhMucMauHoaDon : Csla.BusinessBase<DanhMucMauHoaDon>
	{
		private int _maLoaiHoaDon  = 0;
		private string _tenLoaiHoaDon = string.Empty;
		private string _maQuanLy = string.Empty;
		
		[System.ComponentModel.DataObjectField(true, true)]
		public int MaLoaiHoaDon
		{
			get
			{
				CanReadProperty("MaLoaiHoaDon", true);
				return _maLoaiHoaDon;
			}
		}

        public bool Chon
        {
            get ; set;
        }   

		public string TenLoaiHoaDon
		{
			get
			{
				CanReadProperty("TenLoaiHoaDon", true);
				return _tenLoaiHoaDon;
			}
			set
			{
				CanWriteProperty("TenLoaiHoaDon", true);
				if (value == null) value = string.Empty;
				if (!_tenLoaiHoaDon.Equals(value))
				{
					_tenLoaiHoaDon = value;
					PropertyHasChanged("TenLoaiHoaDon");
				}
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

		protected override object GetIdValue()
		{
			return _maLoaiHoaDon;
		}

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
			return true;

		}

		public static bool CanAddObject()
		{			
			return true;
		}

		public static bool CanEditObject()
		{
			return true;
		}

		public static bool CanDeleteObject()
		{
			return true;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DanhMucMauHoaDon()
        { /* require use of factory method */  MarkAsChild(); }       
		public static DanhMucMauHoaDon NewDanhMucMauHoaDon()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanhMucMauHoaDon");
			return DataPortal.Create<DanhMucMauHoaDon>();
		}
       
        public static DanhMucMauHoaDon GetDanhMucMauHoaDon(int maLoaiHoaDon)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HoaDon");
            return DataPortal.Fetch<DanhMucMauHoaDon>(new Criteria(maLoaiHoaDon));
        }
        internal static DanhMucMauHoaDon GetDanhMucMauHoaDon(SafeDataReader dr)
        {
            DanhMucMauHoaDon child = new DanhMucMauHoaDon();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }
		public override DanhMucMauHoaDon Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DanhMucMauHoaDon");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DanhMucMauHoaDon");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DanhMucMauHoaDon");

			return base.Save();
		}
      
        #endregion

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaLoaiHoaDon;

            public Criteria(int maLoaiHoaDon)
            {
                this.MaLoaiHoaDon = maLoaiHoaDon;
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
                cm.CommandText = "spd_SelecttblDanhMucMauHoaDonByMaLoaiHoaDon";

                cm.Parameters.AddWithValue("@MaLoaiHoaDon", _maLoaiHoaDon);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();
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
            DataPortal_Delete(new Criteria(_maLoaiHoaDon));
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
                cm.CommandText = "spd_DeletetblDanhMucMauHoaDon";

                cm.Parameters.AddWithValue("@MaLoaiHoaDon", criteria.MaLoaiHoaDon);

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
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maLoaiHoaDon = dr.GetInt32("MaLoaiHoaDon");
            _tenLoaiHoaDon = dr.GetString("TenLoaiHoaDon");
            _maQuanLy = dr.GetString("MaQuanLy");

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
                cm.CommandText = "spd_InserttblDanhMucMauHoaDon";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maLoaiHoaDon = (int)cm.Parameters["@MaLoaiHoaDon"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenLoaiHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@TenLoaiHoaDon", _tenLoaiHoaDon);
            else
                cm.Parameters.AddWithValue("@TenLoaiHoaDon", DBNull.Value);

            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);

            cm.Parameters.AddWithValue("@MaLoaiHoaDon", _maLoaiHoaDon);
            cm.Parameters["@MaLoaiHoaDon"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblDanhMucMauHoaDon";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaLoaiHoaDon", _maLoaiHoaDon);

            if (_tenLoaiHoaDon.Length > 0)
                cm.Parameters.AddWithValue("@TenLoaiHoaDon", _tenLoaiHoaDon);
            else
                cm.Parameters.AddWithValue("@TenLoaiHoaDon", DBNull.Value);

            if (_maQuanLy.Length > 0)
                cm.Parameters.AddWithValue("@MaQuanLy", _maQuanLy);
            else
                cm.Parameters.AddWithValue("@MaQuanLy", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maLoaiHoaDon));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }   

}
