
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class DieuChuyenTaiKhoan_NoiBo : Csla.BusinessBase<DieuChuyenTaiKhoan_NoiBo>
	{
		#region Business Properties and Methods

		//declare members
		private int _maDieuChuyen = 0;
		private int _taiKhoanNhan = 0;
		private string _ghiChu = string.Empty;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaDieuChuyen
		{
			get
			{
				CanReadProperty("MaDieuChuyen", true);
				return _maDieuChuyen;
			}
		}

		public int TaiKhoanNhan
		{
			get
			{
				CanReadProperty("TaiKhoanNhan", true);
				return _taiKhoanNhan;
			}
			set
			{
				CanWriteProperty("TaiKhoanNhan", true);
				if (!_taiKhoanNhan.Equals(value))
				{
					_taiKhoanNhan = value;
					PropertyHasChanged("TaiKhoanNhan");
				}
			}
		}

		public string GhiChu
		{
			get
			{
				CanReadProperty("GhiChu", true);
				return _ghiChu;
			}
			set
			{
				CanWriteProperty("GhiChu", true);
				if (value == null) value = string.Empty;
				if (!_ghiChu.Equals(value))
				{
					_ghiChu = value;
					PropertyHasChanged("GhiChu");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _maDieuChuyen;
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
			// GhiChu
			//
			ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("GhiChu", 4000));
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
			//TODO: Define authorization rules in DieuChuyenTaiKhoan_NoiBo
			//AuthorizationRules.AllowRead("MaDieuChuyen", "DieuChuyenTaiKhoan_NoiBoReadGroup");
			//AuthorizationRules.AllowRead("TaiKhoanNhan", "DieuChuyenTaiKhoan_NoiBoReadGroup");
			//AuthorizationRules.AllowRead("GhiChu", "DieuChuyenTaiKhoan_NoiBoReadGroup");

			//AuthorizationRules.AllowWrite("TaiKhoanNhan", "DieuChuyenTaiKhoan_NoiBoWriteGroup");
			//AuthorizationRules.AllowWrite("GhiChu", "DieuChuyenTaiKhoan_NoiBoWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in DieuChuyenTaiKhoan_NoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTaiKhoan_NoiBoViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in DieuChuyenTaiKhoan_NoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTaiKhoan_NoiBoAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in DieuChuyenTaiKhoan_NoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTaiKhoan_NoiBoEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in DieuChuyenTaiKhoan_NoiBo
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("DieuChuyenTaiKhoan_NoiBoDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private DieuChuyenTaiKhoan_NoiBo()
		{ /* require use of factory method */ }

		public static DieuChuyenTaiKhoan_NoiBo NewDieuChuyenTaiKhoan_NoiBo(int maDieuChuyen)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DieuChuyenTaiKhoan_NoiBo");
			return DataPortal.Create<DieuChuyenTaiKhoan_NoiBo>(new Criteria(maDieuChuyen));
		}

		public static DieuChuyenTaiKhoan_NoiBo GetDieuChuyenTaiKhoan_NoiBo(int maDieuChuyen)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a DieuChuyenTaiKhoan_NoiBo");
			return DataPortal.Fetch<DieuChuyenTaiKhoan_NoiBo>(new Criteria(maDieuChuyen));
		}

		public static void DeleteDieuChuyenTaiKhoan_NoiBo(int maDieuChuyen)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DieuChuyenTaiKhoan_NoiBo");
			DataPortal.Delete(new Criteria(maDieuChuyen));
		}

		public override DieuChuyenTaiKhoan_NoiBo Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a DieuChuyenTaiKhoan_NoiBo");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a DieuChuyenTaiKhoan_NoiBo");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a DieuChuyenTaiKhoan_NoiBo");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private DieuChuyenTaiKhoan_NoiBo(int maDieuChuyen)
		{
			this._maDieuChuyen = maDieuChuyen;
		}

		internal static DieuChuyenTaiKhoan_NoiBo NewDieuChuyenTaiKhoan_NoiBoChild(int maDieuChuyen)
		{
			DieuChuyenTaiKhoan_NoiBo child = new DieuChuyenTaiKhoan_NoiBo(maDieuChuyen);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static DieuChuyenTaiKhoan_NoiBo GetDieuChuyenTaiKhoan_NoiBo(SafeDataReader dr)
		{
			DieuChuyenTaiKhoan_NoiBo child =  new DieuChuyenTaiKhoan_NoiBo();
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
			public int MaDieuChuyen;

			public Criteria(int maDieuChuyen)
			{
				this.MaDieuChuyen = maDieuChuyen;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maDieuChuyen = criteria.MaDieuChuyen;
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
                cm.CommandText = "spd_SelecttblDieuChuyenTaiKhoan_NoiBo";

				cm.Parameters.AddWithValue("@MaDieuChuyen", criteria.MaDieuChuyen);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    if (dr.Read())
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

		#region Data Access - Delete
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
                cm.CommandText = "spd_DeletetblDieuChuyenTaiKhoan_NoiBo";

				cm.Parameters.AddWithValue("@MaDieuChuyen", criteria.MaDieuChuyen);

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
			_maDieuChuyen = dr.GetInt32("MaDieuChuyen");
			_taiKhoanNhan = dr.GetInt32("TaiKhoanNhan");
			_ghiChu = dr.GetString("GhiChu");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, ChungTuNganHang parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ChungTuNganHang parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblDieuChuyenTaiKhoan_NoiBo";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ChungTuNganHang parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaDieuChuyen", parent.MaChungTu);
            cm.Parameters.AddWithValue("@TaiKhoanNhan", _taiKhoanNhan);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, ChungTuNganHang parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ChungTuNganHang parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblDieuChuyenTaiKhoan_NoiBo";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ChungTuNganHang parent)
        {
            cm.Parameters.AddWithValue("@MaDieuChuyen", parent.MaChungTu);
            cm.Parameters.AddWithValue("@TaiKhoanNhan", _taiKhoanNhan);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
        }
        #endregion //Data Access - Update

		#region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr, ChungTuNganHang parent)
		{
            //if (!IsDirty) return;
            //if (IsNew) return;

            ExecuteDelete(tr, new Criteria(parent.MaChungTu));
			//MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
