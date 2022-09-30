
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_HoaDonBQ : Csla.BusinessBase<ChungTu_HoaDonBQ>
    {
        #region Business Properties and Methods

        //declare members
        private long _machungtuChungtugoc = 0;
        private long _maChungTu = 0;
        private long _maHoaDon = 0;
        private long _maPhieuNhapXuat = 0;
        private decimal _soTien = 0;
        private string _soChungTu = string.Empty;
        private string _soHoaDon = string.Empty;
        private decimal _soTienConLai = 0;
        private decimal _soTienDaThanhToan = 0;
        private decimal _soTienSeThanhToan = 0;
        private bool _hoanTat = false;
        private DateTime _ngayLap = DateTime.Today.Date;
        private int _mabuttoan = 0;

        private int _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private int _mabophan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        private string _tenbophan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;


        [System.ComponentModel.DataObjectField(true, true)]
        public DateTime NgayLap
        {
            get { return _ngayLap; }
            set { _ngayLap = value; }
        }
        public int NguoiLap
        {
            get
            {
                _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                return _nguoiLap;
            }
            set { _nguoiLap = value; }
        }
        public string SoChungTu
        {
            get { return _soChungTu; }
            set { _soChungTu = value; }
        }
        public string SoHoaDon
        {
            get { return _soHoaDon; }
            set { _soHoaDon = value; }
        }
        public decimal SoTien
        {
            get
            {
                CanReadProperty("SoTien", true);
                return _soTien;
            }
            set
            {
                CanWriteProperty("SoTien", true);
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
                }
            }
        }
        public long MachungtuChungtugoc
        {
            get
            {
                CanReadProperty("MachungtuChungtugoc", true);
                return _machungtuChungtugoc;
            }
        }
        public decimal SoTienDaThanhToan
        {
            get { return _soTienDaThanhToan; }
            set
            {
                _soTienDaThanhToan = value;
            }
        }

        public decimal SoTienSeThanhToan
        {
            get
            {
              CanReadProperty("SoTienSeThanhToan", true);
                return _soTienSeThanhToan;
            }
            set
            {
                CanWriteProperty("SoTienSeThanhToan", true);
                if (!_soTienSeThanhToan.Equals(value))
               {
                _soTienSeThanhToan = value;
                 PropertyHasChanged("SoTienSeThanhToan");
               }
            }
        }

        public decimal SoTienConLai
        {
            get
            {

                //  _soTienConLai = _soTien - _soTienSeThanhToan;
                return _soTienConLai;
            }
            set { _soTienConLai = value; }

        }
        public bool HoanTat
        {
            get { return _hoanTat; }
            set { _hoanTat = value; }
        }
        public long MaChungTu
        {
            get
            {
                CanReadProperty("MaChungTu", true);
                return _maChungTu;
            }
            set
            {
                CanWriteProperty("MaChungTu", true);
                if (!_maChungTu.Equals(value))
                {
                    _maChungTu = value;
                    PropertyHasChanged("MaChungTu");
                }
            }
        }
        public int MaButToan
        {
            get
            {
                CanReadProperty( true);
                return _mabuttoan;
            }
            set
            {
                CanWriteProperty( true);
                if (!_mabuttoan.Equals(value))
                {
                    _mabuttoan = value;
                    PropertyHasChanged();
                }
            }
        }
        public long MaHoaDon
        {
            get
            {
                CanReadProperty("MaHoaDon", true);
                //HoaDon hd = HoaDon.GetHoaDon(_maHoaDon);
                //_soTienDaThanhToan = hd.SoTienDaThanhToan;
                // _soTienConLai = hd.SoTienConLai;
                //_hoanTat = hd.TatToan;
                return _maHoaDon;
            }
            set
            {
                CanWriteProperty("MaHoaDon", true);
                if (!_maHoaDon.Equals(value))
                {
                    _maHoaDon = value;
                    //HoaDon hd = HoaDon.GetHoaDon(_maHoaDon);
                    //_soTienDaThanhToan = hd.SoTienDaThanhToan;
                    //_hoanTat = hd.TatToan;
                    // _soTienConLai = hd.SoTienConLai;
                    PropertyHasChanged("MaHoaDon");
                }
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
        protected override object GetIdValue()
        {
            return _machungtuChungtugoc;
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

        #region Factory Methods
        private ChungTu_HoaDonBQ()
        { /* require use of factory method */ }

        public static ChungTu_HoaDonBQ NewChungTu_HoaDon()
        {
            ChungTu_HoaDonBQ item = new ChungTu_HoaDonBQ();
            item.MarkAsChild();
            return item;
        }

        public static ChungTu_HoaDonBQ NewChungTu_HoaDon(HoaDon _hoaDon)
        {
            ChungTu_HoaDonBQ item = new ChungTu_HoaDonBQ();
            item._maHoaDon = _hoaDon.MaHoaDon;
            item._soTien = _hoaDon.TienThue;
            item._soHoaDon = _hoaDon.SoHoaDon;
            item.MarkAsChild();
            return item;
        }

        public static ChungTu_HoaDonBQ NewChungTu_HoaDon(ChungTu_HoaDonBQ _ct_hd)
        {
            ChungTu_HoaDonBQ item = new ChungTu_HoaDonBQ();
            item._maHoaDon = _ct_hd.MaHoaDon;
            item._soTien = _ct_hd.SoTien;
            item.MaPhieuNhapXuat = _ct_hd.MaPhieuNhapXuat;
            item.MaButToan = _ct_hd.MaButToan;
            item.MaChungTu = _ct_hd.MaChungTu;
            item.SoHoaDon = _ct_hd.SoHoaDon;
            item.MarkAsChild();
            return item;
        }

        public static decimal SoTienDaThanhToanChungTu_HoaDon(long maChungTu, long maHoaDon)
        {
            decimal kq = 0;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    SqlCommand cm = cn.CreateCommand();
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "SoTienDaThanhToanCT_HoaDon";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    cm.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cm.Parameters.AddWithValue("@KQ", 0);
                    cm.Parameters["@KQ"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();
                    kq = Convert.ToDecimal(cm.Parameters["@KQ"].Value);

                }
            }
            catch (Exception ex)
            {
                kq = 0;
            }
            return kq;
        }

        public static ChungTu_HoaDonBQ GetChungTu_HoaDon(long machungtuChungtugoc)
        {
            return DataPortal.Fetch<ChungTu_HoaDonBQ>(new Criteria(machungtuChungtugoc));
        }

        public static void DeleteChungTu_HoaDon(long machungtuChungtugoc)
        {
            DataPortal.Delete(new Criteria(machungtuChungtugoc));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChungTu_HoaDonBQ NewChungTu_HoaDonChild()
        {
            ChungTu_HoaDonBQ child = new ChungTu_HoaDonBQ();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChungTu_HoaDonBQ GetChungTu_HoaDon(SafeDataReader dr)
        {
            ChungTu_HoaDonBQ child = new ChungTu_HoaDonBQ();
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
            public long MachungtuChungtugoc;

            public Criteria(long machungtuChungtugoc)
            {
                this.MachungtuChungtugoc = machungtuChungtugoc;
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
                cm.CommandText = "SelecttblChungTu_HoaDon";

                cm.Parameters.AddWithValue("@MaChungTu_ChungTuGoc", criteria.MachungtuChungtugoc);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        //   ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        /*
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
        */
        #endregion //Data Access - Insert

        #region Data Access - Update
        /*
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
        */
        #endregion //Data Access - Update

        #region Data Access - Delete
        /*
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_machungtuChungtugoc));
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
				cm.CommandText = "DeletetblChungTu_HoaDon";

				cm.Parameters.AddWithValue("@MaChungTu_ChungTuGoc", criteria.MachungtuChungtugoc);

				cm.ExecuteNonQuery();
			}//using
		}
        */
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
            _machungtuChungtugoc = dr.GetInt64("MaChungTu_ChungTuGoc");
            _maChungTu = dr.GetInt64("MaChungTu");
            _mabuttoan = dr.GetInt32("MaButToan");
            _maHoaDon = dr.GetInt64("MaHoaDon");
            _maPhieuNhapXuat = dr.GetInt64("MaPhieuNhapXuat");
            _soTien = dr.GetDecimal("SoTien");
            _soTienDaThanhToan = dr.GetDecimal("SoTienDaThanhToan");
            _soTienConLai = dr.GetDecimal("SoTienConLai");
            _hoanTat = dr.GetBoolean("TatToan");
            _soHoaDon = dr.GetString("SoHoaDon");
            _soChungTu = dr.GetString("SoChungTu");
            _soTienSeThanhToan = dr.GetDecimal("TienThanhToanChungTu");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _ngayLap = dr.GetDateTime("NgayLap");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert

        internal void Insert(SqlTransaction tr, ButToanPhieuNhapXuatBQ parent)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr, parent);
			MarkOld();

			//update child object(s)
            UpdateChildren(tr);
		}

        private void ExecuteInsert(SqlTransaction tr, ButToanPhieuNhapXuatBQ parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "InserttblChungTu_HoaDon";

				AddInsertParameters(cm, parent);

				cm.ExecuteNonQuery();

				_machungtuChungtugoc = (long)cm.Parameters["@MaChungTu_ChungTuGoc"].Value;
			}//using
		}

        private void AddInsertParameters(SqlCommand cm, ButToanPhieuNhapXuatBQ parent)
		{
		    _mabuttoan = parent.MaButToan;
            if(_maChungTu == 0)
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            else
			    cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			if (_maPhieuNhapXuat != 0)
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			else
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _mabuttoan);
            cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
			cm.Parameters.AddWithValue("@MaChungTu_ChungTuGoc", _machungtuChungtugoc);
			cm.Parameters["@MaChungTu_ChungTuGoc"].Direction = ParameterDirection.Output;
		}
         
        #endregion //Data Access - Insert

        #region Data Access - Update

        internal void Update(SqlTransaction tr, ButToanPhieuNhapXuatBQ parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ButToanPhieuNhapXuatBQ parent)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "UpdatetblChungTu_HoaDon";

				AddUpdateParameters(cm, parent);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm, ButToanPhieuNhapXuatBQ parent)
		{
			cm.Parameters.AddWithValue("@MaChungTu_ChungTuGoc", _machungtuChungtugoc);
            if (_maChungTu == 0)
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
			cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
			if (_maPhieuNhapXuat != 0)
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
			else
				cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
			cm.Parameters.AddWithValue("@SoTien", _soTien);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
			if (_nguoiLap != 0)
				cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
			else
				cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _mabuttoan);
            cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);

		}

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

        //#region Data Access - Delete
        //internal void DeleteSelf(SqlTransaction tr)
        //{
        //    if (!IsDirty) return;
        //    if (IsNew) return;

        //    ExecuteDelete(tr, new Criteria(_machungtuChungtugoc));
        //    MarkNew();
        //}
        //#endregion //Data Access - Delete
        

        #endregion //Data Access
        /// <summary>
        /// Edit ChungTu_HoaDon, cập nhật lại trạng thái, số tiền. None Transaction
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="maChungTu"></param>
        /// <param name="maHoaDon"></param>
        /// <param name="EditType">1:Insert; 2:Update; 3:Delete</param>
        public void EditChungTu_HoaDon( long maChungTu, long maHoaDon, int EditType)
        {
            using (SqlConnection cn=new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                _maChungTu = maChungTu;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "EdittblSoTienChungTu_HoaDon";
                AddEditParameters(cm, EditType);
                cm.ExecuteNonQuery();
                MarkOld();
                if (EditType == 1)
                {
                    _machungtuChungtugoc = (long)cm.Parameters["@MaChungTu_ChungTuGoc"].Value;
                }
            }//using
        }
        /// <summary>
        /// Edit ChungTu_HoaDon, cập nhật lại trạng thái, số tiền.Transaction
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="maChungTu"></param>
        /// <param name="maHoaDon"></param>
        /// <param name="EditType">1:Insert; 2:Update; 3:Delete</param>
        public void EditChungTu_HoaDon(SqlTransaction tr, int mabuttoan, long maHoaDon, int EditType)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                _mabuttoan = mabuttoan;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "EdittblSoTienChungTu_HoaDon";
                AddEditParameters(cm, EditType);
                cm.ExecuteNonQuery();
                MarkOld();
                if (EditType == 1)
                {
                    _machungtuChungtugoc = (long)cm.Parameters["@MaChungTu_ChungTuGoc"].Value;
                }
            }//using
        }
        private void AddEditParameters(SqlCommand cm, int EditType)
        {
            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            if (_maHoaDon != 0)
                cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            else
                cm.Parameters.AddWithValue("@MaHoaDon", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTienThanhToan", _soTienSeThanhToan);
            cm.Parameters.AddWithValue("@MaChungTu_ChungTuGoc", _machungtuChungtugoc);
            cm.Parameters.AddWithValue("@EditType", EditType);
            cm.Parameters.AddWithValue("@TatToan", _hoanTat);
            if (EditType == 1)
            {
                cm.Parameters["@MaChungTu_ChungTuGoc"].Direction = ParameterDirection.Output;
            }
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);

            cm.Parameters.AddWithValue("@MaBuTToan", _mabuttoan);
            cm.Parameters.AddWithValue("@MaBoPhan", _mabophan);
            cm.Parameters.AddWithValue("@TenBoPhan", _tenbophan);

        }

    }
   
}