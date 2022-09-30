
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library//05012016
{ 
	[Serializable()] 
	public class HoaDon_NhapXuat : Csla.BusinessBase<HoaDon_NhapXuat>
	{
		#region Business Properties and Methods

		//declare members
		private int _idhoadonNhapxuat = 0;
		private long _maPhieuNhapXuat = 0;
		private long _maHoaDon = 0;

		[System.ComponentModel.DataObjectField(true, true)]
		public int IdhoadonNhapxuat
		{
			get
			{
				CanReadProperty("IdhoadonNhapxuat", true);
				return _idhoadonNhapxuat;
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

		public long MaHoaDon
		{
			get
			{
				CanReadProperty("MaHoaDon", true);
				return _maHoaDon;
			}
			set
			{
				CanWriteProperty("MaHoaDon", true);
				if (!_maHoaDon.Equals(value))
				{
					_maHoaDon = value;
					PropertyHasChanged("MaHoaDon");
				}
			}
		}
 
		protected override object GetIdValue()
		{
			return _idhoadonNhapxuat;
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
			//TODO: Define authorization rules in HoaDon_NhapXuat
			//AuthorizationRules.AllowRead("IdhoadonNhapxuat", "HoaDon_NhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaPhieuNhapXuat", "HoaDon_NhapXuatReadGroup");
			//AuthorizationRules.AllowRead("MaHoaDon", "HoaDon_NhapXuatReadGroup");

			//AuthorizationRules.AllowWrite("MaPhieuNhapXuat", "HoaDon_NhapXuatWriteGroup");
			//AuthorizationRules.AllowWrite("MaHoaDon", "HoaDon_NhapXuatWriteGroup");
		}

		#endregion //Authorization Rules

		#region Factory Methods

		internal static HoaDon_NhapXuat NewHoaDon_NhapXuat()
		{
            
			return new HoaDon_NhapXuat();
		}
        public static HoaDon_NhapXuat NewHoaDon_NhapXuat(long maHoaDon )
        {
            HoaDon_NhapXuat hoaDon_NhapXuat = new HoaDon_NhapXuat();
            hoaDon_NhapXuat.MaHoaDon = maHoaDon;
            return hoaDon_NhapXuat;
        }


		internal static HoaDon_NhapXuat GetHoaDon_NhapXuat(SafeDataReader dr)
		{
			return new HoaDon_NhapXuat(dr);
		}

		private HoaDon_NhapXuat()
		{

			ValidationRules.CheckRules();
			MarkAsChild();
		}

		private HoaDon_NhapXuat(SafeDataReader dr)
		{
            MarkAsChild();
			Fetch(dr);
		}
        public static bool KiemTraHoaDonTonTaiTrongHoaDon_NhapXuat(long maPhieuNhapXuat,long maHoaDon)
        {
            bool _kq = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_KiemTraHoaDonTonTaiTrongHoaDon_NhapXuat ";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", maPhieuNhapXuat);
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    SqlParameter prmGiaTriTraVe = new SqlParameter("@GiaTriTraVe", SqlDbType.Bit, 16);
                    prmGiaTriTraVe.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmGiaTriTraVe);
                    cm.ExecuteNonQuery();
                    _kq = (bool)prmGiaTriTraVe.Value;
                }
            }//us
            return _kq;
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
			_idhoadonNhapxuat = dr.GetInt32("IDHoaDon_NhapXuat");
			_maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
			_maHoaDon = dr.GetInt64("MaHoaDon");
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
                cm.CommandText = "spd_InserttblHoaDon_NhapXuat";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_idhoadonNhapxuat = (int)cm.Parameters["@IDHoaDon_NhapXuat"].Value;
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
			if (_maHoaDon != 0)
				cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			else
				cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
			cm.Parameters.AddWithValue("@IDHoaDon_NhapXuat", _idhoadonNhapxuat);
			cm.Parameters["@IDHoaDon_NhapXuat"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_InserttblHoaDon_NhapXuat";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _idhoadonNhapxuat = (int)cm.Parameters["@IDHoaDon_NhapXuat"].Value;
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
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            cm.Parameters.AddWithValue("@IDHoaDon_NhapXuat", _idhoadonNhapxuat);
            cm.Parameters["@IDHoaDon_NhapXuat"].Direction = ParameterDirection.Output;
        }
        #endregion //BanQuyen

        #region CCDC
        internal void Insert(SqlTransaction tr, PhieuNhapXuatCCDC parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, PhieuNhapXuatCCDC parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblHoaDon_NhapXuat";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _idhoadonNhapxuat = (int)cm.Parameters["@IDHoaDon_NhapXuat"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, PhieuNhapXuatCCDC parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            _maPhieuNhapXuat = parent.MaPhieuNhapXuat;
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            cm.Parameters.AddWithValue("@IDHoaDon_NhapXuat", _idhoadonNhapxuat);
            cm.Parameters["@IDHoaDon_NhapXuat"].Direction = ParameterDirection.Output;
        }
        #endregion

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
                cm.CommandText = "spd_UpdatetblHoaDon_NhapXuat";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuat parent)
		{
			cm.Parameters.AddWithValue("@IDHoaDon_NhapXuat", _idhoadonNhapxuat);
			if (_maPhieuNhapXuat != 0)
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			else
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
			if (_maHoaDon != 0)
				cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			else
				cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
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
                cm.CommandText = "spd_UpdatetblHoaDon_NhapXuat";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuatBQ parent)
        {
            cm.Parameters.AddWithValue("@IDHoaDon_NhapXuat", _idhoadonNhapxuat);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
        }
        #endregion //BanQuyen

        #region CCDC
        internal void Update(SqlTransaction tr, PhieuNhapXuatCCDC parent)
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

        private void ExecuteUpdate(SqlTransaction tr, PhieuNhapXuatCCDC parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblHoaDon_NhapXuat";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, PhieuNhapXuatCCDC parent)
        {
            cm.Parameters.AddWithValue("@IDHoaDon_NhapXuat", _idhoadonNhapxuat);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
        }
        #endregion//CCDC

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
                cm.CommandText = "spd_DeletetblHoaDon_NhapXuat";

				cm.Parameters.AddWithValue("@IDHoaDon_NhapXuat", this._idhoadonNhapxuat);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
