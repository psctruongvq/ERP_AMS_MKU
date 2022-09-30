
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class NhapXuat_HopDong : Csla.BusinessBase<NhapXuat_HopDong>
	{
		#region Business Properties and Methods

		//declare members
		private int _idnhapxuatHopdong = 0;
		private long _maPhieuNhapXuat = 0;
		private long _maHopDong = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int IdnhapxuatHopdong
		{
			get
			{
				CanReadProperty("IdnhapxuatHopdong", true);
				return _idnhapxuatHopdong;
			}
		}

		public long MaPhieuNhapXuat
		{
			get
			{
				CanReadProperty("MaPhieuNhapXuat", true);
				return _maPhieuNhapXuat;
			}
			set
			{
				CanWriteProperty("MaPhieuNhapXuat", true);
				if (!_maPhieuNhapXuat.Equals(value))
				{
					_maPhieuNhapXuat = value;
					PropertyHasChanged("MaPhieuNhapXuat");
				}
			}
		}

		public long MaHopDong
		{
			get
			{
				CanReadProperty("MaHopDong", true);
				return _maHopDong;
			}
			set
			{
				CanWriteProperty("MaHopDong", true);
				if (!_maHopDong.Equals(value))
				{
					_maHopDong = value;
					PropertyHasChanged("MaHopDong");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _idnhapxuatHopdong;
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
			//TODO: Define authorization rules in NhapXuat_HopDong
			//AuthorizationRules.AllowRead("IdnhapxuatHopdong", "NhapXuat_HopDongReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuNhapXuat", "NhapXuat_HopDongReadGroup");
			//AuthorizationRules.AllowRead("MaHopDong", "NhapXuat_HopDongReadGroup");

			//AuthorizationRules.AllowWrite("MaPhieuNhapXuat", "NhapXuat_HopDongWriteGroup");
			//AuthorizationRules.AllowWrite("MaHopDong", "NhapXuat_HopDongWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods
		internal static NhapXuat_HopDong NewNhapXuat_HopDong()
		{
			return new NhapXuat_HopDong();
		}
        public static NhapXuat_HopDong NewNhapXuat_HopDong(long maHopDong)
        {
            NhapXuat_HopDong nhapXuat_HopDong = new NhapXuat_HopDong();
            nhapXuat_HopDong.MaHopDong = maHopDong;
            return nhapXuat_HopDong;
        }

		internal static NhapXuat_HopDong GetNhapXuat_HopDong(SafeDataReader dr)
		{
			return new NhapXuat_HopDong(dr);
		}

		private NhapXuat_HopDong()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private NhapXuat_HopDong(SafeDataReader dr)
		{
			MarkAsChild();
			Fetch(dr);
		}
		#endregion //Factory Methods


		#region Data Access

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
			_idnhapxuatHopdong = dr.GetInt32("IDNhapXuat_HopDong");
			_maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
			_maHopDong = dr.GetInt64("MaHopDong");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr, PhieuNhapXuat parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuat parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblNhapXuat_HopDong";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_idnhapxuatHopdong = (int)cm.Parameters["@IDNhapXuat_HopDong"].Value;
			}//using
		}

		private void AddInsertParameters(SqlCommand cm, PhieuNhapXuat parent)
		{
			//TODO: if parent use identity key, fix fk member with value from parent
            _maPhieuNhapXuat = parent.MaPhieuNhapXuat;
			if (_maPhieuNhapXuat != 0)
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			else
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
			if (_maHopDong != 0)
				cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			else
				cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
			cm.Parameters.AddWithValue("@IDNhapXuat_HopDong", _idnhapxuatHopdong);
			cm.Parameters["@IDNhapXuat_HopDong"].Direction = ParameterDirection.Output;
		}

        #region BanQuyen
        internal void Insert(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblNhapXuat_HopDong";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _idnhapxuatHopdong = (int)cm.Parameters["@IDNhapXuat_HopDong"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, PhieuNhapXuatBQ parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maPhieuNhapXuat = parent.MaPhieuNhapXuat;
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
            cm.Parameters.AddWithValue("@IDNhapXuat_HopDong", _idnhapxuatHopdong);
            cm.Parameters["@IDNhapXuat_HopDong"].Direction = ParameterDirection.Output;
        }
        #endregion //BanQuyen
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
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

		private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuat parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblNhapXuat_HopDong";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuat parent)
		{
			cm.Parameters.AddWithValue("@IDNhapXuat_HopDong", _idnhapxuatHopdong);
			if (_maPhieuNhapXuat != 0)
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			else
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
			if (_maHopDong != 0)
				cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
			else
				cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
		}

        #region BanQuyen
        internal void Update(SqlTransaction tr, PhieuNhapXuatBQ parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuatBQ parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblNhapXuat_HopDong";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuatBQ parent)
        {
            cm.Parameters.AddWithValue("@IDNhapXuat_HopDong", _idnhapxuatHopdong);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            if (_maHopDong != 0)
                cm.Parameters.AddWithValue("@MaHopDong", _maHopDong);
            else
                cm.Parameters.AddWithValue("@MaHopDong", DBNull.Value);
        }
        #endregion //BanQuyen

        private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr);
			MarkNew();
		}

		private void ExecuteDelete(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblNhapXuat_HopDong";

				cm.Parameters.AddWithValue("@IDNhapXuat_HopDong", this._idnhapxuatHopdong);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
