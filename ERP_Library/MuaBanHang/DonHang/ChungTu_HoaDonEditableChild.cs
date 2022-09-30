
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTu_HoaDon : Csla.BusinessBase<ChungTu_HoaDon>
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
        //tblHoaDon.GhiChu", "LoaiHoaDon", "tblHoaDon.NgayLap", "tblHoaDon.SoHoaDon", "tblHoaDon.SoSerial", "tblHoaDon.MauHoaDon", "tblHoaDon.KyHieuMauHoaDon", "tblHoaDon.TongTien", "tblHoaDon.ThueVAT
        //tblHoaDon.GhiChu,tblHoaDon.NgayLap,tblHoaDon.SoHoaDon,tblHoaDon.SoSerial,tblHoaDon.MauHoaDon,tblHoaDon.KyHieuMauHoaDon,tblHoaDon.TongTien,tblHoaDon.ThueVAT
        private int _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
        private int _mabophan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
        private string _tenbophan = ERP_Library.Security.CurrentUser.Info.TenBoPhan;

        #region Properties BS
        HoaDon _HoaDon = HoaDon.NewHoaDon();
        public HoaDon HoaDon
        {
            get
            {
                CanReadProperty(true);
                return _HoaDon;
            }
            set
            {
                CanWriteProperty(true);
                if (!_HoaDon.Equals(value))
                {
                    _HoaDon = value;
                    PropertyHasChanged();
                }
            }
        }
        private string _GhiChu;
        private string _SoSerial;
        private string _MauHoaDon;
        private string _KyHieuMauHoaDon;
        private decimal _ThueVAT;
        private DateTime _NgayLapHoaDon;
        public string GhiChu
        {
            get { return _GhiChu; }
        }

        public string SoSerial
        {
            get { return _SoSerial; }
        }
        public string MauHoaDon
        {
            get { return _MauHoaDon; }
        }

        public string KyHieuMauHoaDon
        {
            get { return _KyHieuMauHoaDon; }
        }
        public decimal ThueVAT
        {
            get { return _ThueVAT; }
        }

        public DateTime NgayLapHoaDon
        {
            get { return _NgayLapHoaDon; }
        }
        #endregion //Properties BS


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
                CanReadProperty(true);
                return _mabuttoan;
            }
            set
            {
                CanWriteProperty(true);
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
                    #region Load HoaDon
                    //LoadHoaDon();
                    #endregion//Load HoaDon
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
        private ChungTu_HoaDon()
        { /* require use of factory method */ }

        public static ChungTu_HoaDon NewChungTu_HoaDon()
        {
            ChungTu_HoaDon item = new ChungTu_HoaDon();
            item.MarkAsChild();
            return item;
        }

        public static ChungTu_HoaDon NewChungTu_HoaDon(HoaDon _hoaDon)
        {
            ChungTu_HoaDon item = new ChungTu_HoaDon();
            item._HoaDon = HoaDon.GetHoaDon(_hoaDon.MaHoaDon);
            item._maHoaDon = _hoaDon.MaHoaDon;
            item._soTien = _hoaDon.TienThue;
            item._soHoaDon = _hoaDon.SoHoaDon;
            //
            item._GhiChu = _hoaDon.GhiChu;
            item._SoSerial = _hoaDon.SoSerial;
            item._MauHoaDon = _hoaDon.MauHoaDon;
            item._KyHieuMauHoaDon = _hoaDon.KyHieuMauHoaDon;
            item._ThueVAT = _hoaDon.ThueVAT;
            item._NgayLapHoaDon = _hoaDon.NgayLap;
            item._soTienDaThanhToan = _hoaDon.SoTienDaThanhToan;
            item._hoanTat = _hoaDon.TatToan;
            item._soTienConLai = _hoaDon.SoTienConLai;

            item.MarkAsChild();
            return item;
        }

        public static ChungTu_HoaDon NewChungTu_HoaDon(ChungTu_HoaDon _ct_hd)
        {
            ChungTu_HoaDon item = new ChungTu_HoaDon();
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

        public static ChungTu_HoaDon GetChungTu_HoaDon(long machungtuChungtugoc)
        {
            return DataPortal.Fetch<ChungTu_HoaDon>(new Criteria(machungtuChungtugoc));
        }

        public static void DeleteChungTu_HoaDon(long machungtuChungtugoc)
        {
            DataPortal.Delete(new Criteria(machungtuChungtugoc));
        }


        private void LoadHoaDon()
        {
            if (_maHoaDon != 0)
            {
                _HoaDon = HoaDon.GetHoaDon(_maHoaDon);
                _GhiChu = _HoaDon.GhiChu;
                _SoSerial = _HoaDon.SoSerial;
                _MauHoaDon = _HoaDon.MauHoaDon;
                _KyHieuMauHoaDon = _HoaDon.KyHieuMauHoaDon;
                _ThueVAT = _HoaDon.ThueVAT;
                _NgayLapHoaDon = _HoaDon.NgayLap;
                _soTienDaThanhToan = _HoaDon.SoTienDaThanhToan;
                _hoanTat = _HoaDon.TatToan;
                _soTienConLai = _HoaDon.SoTienConLai;
            }
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static ChungTu_HoaDon NewChungTu_HoaDonChild()
        {
            ChungTu_HoaDon child = new ChungTu_HoaDon();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static ChungTu_HoaDon GetChungTu_HoaDon(SafeDataReader dr)
        {
            ChungTu_HoaDon child = new ChungTu_HoaDon();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static ChungTu_HoaDon GetChungTu_HoaDonByHoaDon(SafeDataReader dr)
        {
            ChungTu_HoaDon child = new ChungTu_HoaDon();
            child.MarkAsChild();
            child.FetchByHoaDon(dr);
            return child;
        }
        #endregion //Child Factory Methods

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _HoaDon.IsDirty ;

            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid && _HoaDon.IsValid
                    ;
            }
        }
        #endregion

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
                cm.CommandText = "spd_DeletetblChungTu_HoaDon";

				cm.Parameters.AddWithValue("@MaChungTu_ChungTuGoc", criteria.MachungtuChungtugoc);

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

        private void FetchByHoaDon(SafeDataReader dr)
        {
            FetchObjectByHoaDon(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _HoaDon = HoaDon.GetHoaDon(dr.GetInt64("MaHoaDon"));
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


            //LoadHoaDon();
        }

        private void FetchObjectByHoaDon(SafeDataReader dr)
        {
            //_HoaDon = HoaDon.GetHoaDon(dr.GetInt64("MaHoaDon"));
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


            //LoadHoaDon();
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert

        #region Parent: ButToanPhieuNhapXuat
        internal void Insert(SqlTransaction tr, ButToanPhieuNhapXuat parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ButToanPhieuNhapXuat parent)
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

        private void AddInsertParameters(SqlCommand cm, ButToanPhieuNhapXuat parent)
        {
            _mabuttoan = parent.MaButToan;
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
            cm.Parameters.AddWithValue("@MaChungTu_ChungTuGoc", _machungtuChungtugoc);
            cm.Parameters["@MaChungTu_ChungTuGoc"].Direction = ParameterDirection.Output;
        }
        #endregion//Parent: ButToanPhieuNhapXuat

        #region Parent: ChungTu
        internal void Insert(SqlTransaction tr, ButToan parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, ButToan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                _HoaDon.Save(tr);
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblChungTu_HoaDon";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _machungtuChungtugoc = (long)cm.Parameters["@MaChungTu_ChungTuGoc"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, ButToan parent)
        {
            _mabuttoan = parent.MaButToan;
            if (_maChungTu == 0)
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            cm.Parameters.AddWithValue("@MaHoaDon", _HoaDon.MaHoaDon);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTien", _HoaDon.TienThue);
            cm.Parameters.AddWithValue("@NgayLap", _HoaDon.NgayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _mabuttoan);
            cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@MaChungTu_ChungTuGoc", _machungtuChungtugoc);
            cm.Parameters["@MaChungTu_ChungTuGoc"].Direction = ParameterDirection.Output;
        }
        #endregion//Parent: ChungTu

        #region Parent: HoaDon
        internal void Insert(SqlTransaction tr, HoaDon parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, HoaDon parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                //_HoaDon.Save(tr);
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "InserttblChungTu_HoaDon";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();

                _machungtuChungtugoc = (long)cm.Parameters["@MaChungTu_ChungTuGoc"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, HoaDon parent)
        {
            _maHoaDon = parent.MaHoaDon;
            if (_maChungTu == 0)
                cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
            else
                cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            cm.Parameters.AddWithValue("@MaHoaDon", _maHoaDon);
            if (_maPhieuNhapXuat != 0)
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", _maPhieuNhapXuat);
            else
                cm.Parameters.AddWithValue("@MaPhieuNhapXuat", DBNull.Value);
            cm.Parameters.AddWithValue("@SoTien", _HoaDon.TienThue);
            cm.Parameters.AddWithValue("@NgayLap", _HoaDon.NgayLap);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            cm.Parameters.AddWithValue("@MaButToan", _mabuttoan);
            cm.Parameters.AddWithValue("@MaBoPhan", ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@MaChungTu_ChungTuGoc", _machungtuChungtugoc);
            cm.Parameters["@MaChungTu_ChungTuGoc"].Direction = ParameterDirection.Output;
        }
        #endregion//Parent: HoaDon

        #endregion //Data Access - Insert

        #region Data Access - Update

        #region Parent: ButToanPhieuNhapXuat
        internal void Update(SqlTransaction tr, ButToanPhieuNhapXuat parent)
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

        private void ExecuteUpdate(SqlTransaction tr, ButToanPhieuNhapXuat parent)
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

        private void AddUpdateParameters(SqlCommand cm, ButToanPhieuNhapXuat parent)
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
        #endregion//Parent: ButToanPhieuNhapXuat

        #region Parent: ButToan
        internal void Update(SqlTransaction tr, ButToan parent)
        {
            if (!IsDirty) return;

            //if (base.IsDirty)
            if (IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, ButToan parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                _HoaDon.Save(tr);
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdatetblChungTu_HoaDon";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, ButToan parent)
        {
            _mabuttoan = parent.MaButToan;
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
        #endregion//Parent: ButToan\

        #region Parent: HoaDon
        internal void Update(SqlTransaction tr, HoaDon parent)
        {
            if (!IsDirty) return;

            //if (base.IsDirty)
            if (IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteUpdate(SqlTransaction tr, HoaDon parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                //_HoaDon.Save(tr);
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "UpdatetblChungTu_HoaDon";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, HoaDon parent)
        {
            _maHoaDon = parent.MaHoaDon;
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
        #endregion//Parent: ButToan

        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_machungtuChungtugoc));
            MarkNew();
        }
        #endregion //Data Access - Delete


        #endregion //Data Access
        /// <summary>
        /// Edit ChungTu_HoaDon, cập nhật lại trạng thái, số tiền. None Transaction
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="maChungTu"></param>
        /// <param name="maHoaDon"></param>
        /// <param name="EditType">1:Insert; 2:Update; 3:Delete</param>
        public void EditChungTu_HoaDon(long maChungTu, long maHoaDon, int EditType)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
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