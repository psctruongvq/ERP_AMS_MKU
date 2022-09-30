
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class QuyetDinhThuChi : Csla.BusinessBase<QuyetDinhThuChi>
    {
        #region Business Properties and Methods

        //declare members
        private long _maQuyetDinh = 0;
        private int _maKyTinhLuong = 0;
        private string _soQuyetDinh = string.Empty;
        private SmartDate _ngayKy = new SmartDate(DateTime.Today);
        private long _nguoiKy = 0;
        private long _nguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;  
        private decimal _tongTien = 0;
        private long _maNguoiNhanTien = 0;
        private bool _tinhTrang = false;
        private SmartDate _ngayLap = new SmartDate(DateTime.Today);
        private string _dienGiai = string.Empty;
        private short _loaiQuyetDinh = 13;// thu
        private byte _loai = 3;

        private ChungTu_QuyetDinhList _ChungTu_QuyetDinhList = ChungTu_QuyetDinhList.NewChungTu_QuyetDinhList();
        [System.ComponentModel.DataObjectField(true, true)]

        public long MaQuyetDinh
        {
            get
            {
                CanReadProperty("MaQuyetDinh", true);
                return _maQuyetDinh;
            }
        }

        public int MaKyTinhLuong
        {
            get
            {
                CanReadProperty("MaKyTinhLuong", true);
                _tongTien = Convert.ToDecimal(QuyetDinhThuChi.LayTongTien(_maKyTinhLuong, _loaiQuyetDinh));
                return _maKyTinhLuong;
            }
            set
            {
                CanWriteProperty("MaKyTinhLuong", true);
                if (!_maKyTinhLuong.Equals(value))
                {
                    _maKyTinhLuong = value;
                    if (QuyetDinhThuChi.LayTongTien(_maKyTinhLuong, _loaiQuyetDinh) != 0)
                        _tongTien = Convert.ToDecimal(QuyetDinhThuChi.LayTongTien(_maKyTinhLuong, _loaiQuyetDinh));
                    else
                        _tongTien = 0;
                    PropertyHasChanged("MaKyTinhLuong");
                }
            }
        }

        public string SoQuyetDinh
        {
            get
            {
                CanReadProperty("SoQuyetDinh", true);
                return _soQuyetDinh;
            }
            set
            {
                CanWriteProperty("SoQuyetDinh", true);
                if (value == null) value = string.Empty;
                if (!_soQuyetDinh.Equals(value))
                {
                    _soQuyetDinh = value;
                    PropertyHasChanged("SoQuyetDinh");
                }
            }
        }

        public DateTime NgayKy
        {
            get
            {
                CanReadProperty("NgayKy", true);
                return _ngayKy.Date;
            }
            set
            {
                CanWriteProperty("NgayKy", true);
                if (!_ngayKy.Equals(value))
                {
                    _ngayKy = new SmartDate(value);
                    PropertyHasChanged("NgayKy");
                }
            }
        }

        public long NguoiKy
        {
            get
            {
                CanReadProperty("NguoiKy", true);
                return _nguoiKy;
            }
            set
            {
                CanWriteProperty("NguoiKy", true);
                if (!_nguoiKy.Equals(value))
                {
                    _nguoiKy = value;
                    PropertyHasChanged("NguoiKy");
                }
            }
        }

        public long NguoiLap
        {
            get
            {
                CanReadProperty("NguoiLap", true);
                return _nguoiLap;
            }
            set
            {
                CanWriteProperty("NguoiLap", true);
                if (!_nguoiLap.Equals(value))
                {
                    _nguoiLap = value;
                    PropertyHasChanged("NguoiLap");
                }
            }
        }

        public decimal TongTien
        {
            get
            {
                CanReadProperty("TongTien", true);
                return _tongTien;
            }
            set
            {
                CanWriteProperty("TongTien", true);
                if (!_tongTien.Equals(value))
                {
                    _tongTien = value;
                    PropertyHasChanged("TongTien");
                }
            }
        }

        public long MaNguoiNhanTien
        {
            get
            {
                CanReadProperty("MaNguoiNhanTien", true);
                return _maNguoiNhanTien;
            }
            set
            {
                CanWriteProperty("MaNguoiNhanTien", true);
                if (!_maNguoiNhanTien.Equals(value))
                {
                    _maNguoiNhanTien = value;
                    PropertyHasChanged("MaNguoiNhanTien");
                }
            }
        }

        public bool TinhTrang
        {
            get
            {
                CanReadProperty("TinhTrang", true);
                return _tinhTrang;
            }
            set
            {
                CanWriteProperty("TinhTrang", true);
                if (!_tinhTrang.Equals(value))
                {
                    _tinhTrang = value;
                    PropertyHasChanged("TinhTrang");
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
            set
            {
                CanWriteProperty("NgayLap", true);
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = new SmartDate(value);
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public string DienGiai
        {
            get
            {
                CanReadProperty("DienGiai", true);
                return _dienGiai;
            }
            set
            {
                CanWriteProperty("DienGiai", true);
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }

        public short LoaiQuyetDinh
        {
            get
            {
                CanReadProperty("LoaiQuyetDinh", true);
                return _loaiQuyetDinh;
            }
            set
            {
                CanWriteProperty("LoaiQuyetDinh", true);
                if (!_loaiQuyetDinh.Equals(value))
                {
                    _loaiQuyetDinh = value;
                    if (_maKyTinhLuong != 0)
                    {
                        if (QuyetDinhThuChi.LayTongTien(_maKyTinhLuong, _loaiQuyetDinh) != 0)
                            _tongTien = Convert.ToDecimal(QuyetDinhThuChi.LayTongTien(_maKyTinhLuong, _loaiQuyetDinh));
                        else
                            _tongTien = 0;
                    }
                    PropertyHasChanged("LoaiQuyetDinh");
                }
            }
        }

        public byte Loai
        {
            get
            {
                CanReadProperty("Loai", true);
                return _loai;
            }
            set
            {
                CanWriteProperty("Loai", true);
                if (!_loai.Equals(value))
                {
                    _loai = value;
                    PropertyHasChanged("Loai");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maQuyetDinh;
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
            // SoQuyetDinh
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("SoQuyetDinh", 50));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 2000));
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
            //TODO: Define authorization rules in QuyetDinhThuChi
            //AuthorizationRules.AllowRead("MaQuyetDinh", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("MaKyTinhLuong", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("SoQuyetDinh", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("NgayKy", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("NgayKyString", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("NguoiKy", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("NguoiLap", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("TongTien", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("TinhTrang", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("LoaiQuyetDinh", "QuyetDinhThuChiReadGroup");
            //AuthorizationRules.AllowRead("Loai", "QuyetDinhThuChiReadGroup");

            //AuthorizationRules.AllowWrite("MaKyTinhLuong", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("SoQuyetDinh", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("NgayKyString", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiKy", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("NguoiLap", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("TongTien", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("TinhTrang", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiQuyetDinh", "QuyetDinhThuChiWriteGroup");
            //AuthorizationRules.AllowWrite("Loai", "QuyetDinhThuChiWriteGroup");
        }

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuyetDinhThuChi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhThuChiViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuyetDinhThuChi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhThuChiAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuyetDinhThuChi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhThuChiEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuyetDinhThuChi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuyetDinhThuChiDeleteGroup"))
            //	return true;
            //return false;
        }

        #region Kiem Tra Quyet Dinh Thu Chi
        public static int KiemTraSoQuyetDinh(string soQuyetDinh)
        {
            int gt = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_KiemTraSoQuyetDinhThuChi";
                        cm.Parameters.AddWithValue("@SoQuyetDinh", soQuyetDinh);
                        cm.Parameters.AddWithValue("@GiaTri", gt);
                        cm.Parameters["@GiaTri"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        gt = (int)cm.Parameters["@GiaTri"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
        #endregion
        #endregion //Authorization Rules

        #region Factory Methods
        private QuyetDinhThuChi()
        { /* require use of factory method */ }

        public static QuyetDinhThuChi NewQuyetDinhThuChi()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuyetDinhThuChi");
            return DataPortal.Create<QuyetDinhThuChi>();
        }

        public static QuyetDinhThuChi GetQuyetDinhThuChi(long maQuyetDinh)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuyetDinhThuChi");
            return DataPortal.Fetch<QuyetDinhThuChi>(new Criteria(maQuyetDinh));
        }

        public static void DeleteQuyetDinhThuChi(long maQuyetDinh)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuyetDinhThuChi");
            DataPortal.Delete(new Criteria(maQuyetDinh));
        }

        public override QuyetDinhThuChi Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuyetDinhThuChi");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuyetDinhThuChi");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a QuyetDinhThuChi");

            return base.Save();
        }

        public override bool IsDirty
        {
            get
            {
                    return base.IsDirty|| _ChungTu_QuyetDinhList.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                   return base.IsValid && _ChungTu_QuyetDinhList.IsValid;
            }
        }
        #endregion //Factory Methods

        #region Child Factory Methods
        public static QuyetDinhThuChi NewQuyetDinhThuChiChild()
        {
            QuyetDinhThuChi child = new QuyetDinhThuChi();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static QuyetDinhThuChi GetQuyetDinhThuChi(SafeDataReader dr)
        {
            QuyetDinhThuChi child = new QuyetDinhThuChi();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        public static decimal LayTongTien(int maKy, int loaiQuyetDinh)
        {
            decimal TongTien = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                try
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TongTien_CongNo";
                        cm.Parameters.AddWithValue("@MaKy", maKy);
                        cm.Parameters.AddWithValue("@LoaiQuyetDinh", loaiQuyetDinh);
                        cm.Parameters.AddWithValue("@TongTien", TongTien);
                        cm.Parameters["@TongTien"].Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        TongTien = (decimal)cm.Parameters["@TongTien"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return TongTien;
            }//using
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public long MaQuyetDinh;

            public Criteria(long maQuyetDinh)
            {
                this.MaQuyetDinh = maQuyetDinh;
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteFetch(cn, criteria);
            }//using
        }

        private void ExecuteFetch(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelecttblcnQuyetDinh";

                cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteInsert(cn);

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Insert

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                if (base.IsDirty)
                {
                    ExecuteUpdate(cn);
                }

                //update child object(s)
                UpdateChildren(cn);
            }//using

        }

        #endregion //Data Access - Update

        #region Data Access - Delete
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_maQuyetDinh));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }
        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblcnQuyetDinh";

                cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

                cm.ExecuteNonQuery();
            }//using
        }
        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblcnQuyetDinh";

                cm.Parameters.AddWithValue("@MaQuyetDinh", criteria.MaQuyetDinh);

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
            _maQuyetDinh = dr.GetInt64("MaQuyetDinh");
            _maKyTinhLuong = dr.GetInt32("MaKyTinhLuong");
            _soQuyetDinh = dr.GetString("SoQuyetDinh");
            _ngayKy = dr.GetSmartDate("NgayKy", _ngayKy.EmptyIsMin);
            _nguoiKy = dr.GetInt64("NguoiKy");
            _nguoiLap = dr.GetInt64("NguoiLap");
            _tongTien = dr.GetDecimal("TongTien");
            _maNguoiNhanTien = dr.GetInt64("MaNguoiNhanTien");
            _tinhTrang = dr.GetBoolean("TinhTrang");
            _ngayLap = dr.GetSmartDate("NgayLap", _ngayLap.EmptyIsMin);
            _dienGiai = dr.GetString("DienGiai");
            _loaiQuyetDinh = dr.GetInt16("LoaiQuyetDinh");
            _loai = dr.GetByte("Loai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, long MaChungTu)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, MaChungTu);
            MarkOld();

            //update child object(s)
            //UpdateChildren(cn);
        }

        internal void Insert(SqlConnection cn)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlTransaction  tr, long MaChungTu)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblcnQuyetDinh";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maQuyetDinh = (long)cm.Parameters["@MaQuyetDinh"].Value;
                _ChungTu_QuyetDinhList.MaQuyetDinh = _maQuyetDinh;

                _ChungTu_QuyetDinhList.DataPortal_Update(tr, MaChungTu);
            }//using
        }

        private void ExecuteInsert(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblcnQuyetDinh";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maQuyetDinh = (long)cm.Parameters["@MaQuyetDinh"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            if (_maKyTinhLuong != 0)
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            else
                cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
            if (_soQuyetDinh.Length > 0)
                cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            else
                cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            if (_nguoiKy != 0)
                cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
            else
                cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_tongTien != 0)
                cm.Parameters.AddWithValue("@TongTien", _tongTien);
            else
                cm.Parameters.AddWithValue("@TongTien", DBNull.Value);
            if (_maNguoiNhanTien != 0)
                cm.Parameters.AddWithValue("@MaNguoiNhanTien", _maNguoiNhanTien);
            else
                cm.Parameters.AddWithValue("@MaNguoiNhanTien", DBNull.Value);
            
            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);

            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);

            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_loaiQuyetDinh != 0)
                cm.Parameters.AddWithValue("@LoaiQuyetDinh", _loaiQuyetDinh);
            else
                cm.Parameters.AddWithValue("@LoaiQuyetDinh", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);

            cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);

            cm.Parameters["@MaQuyetDinh"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, long MaChungTu)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, MaChungTu);
                MarkOld();
            }

            //update child object(s)
            //UpdateChildren(cn);
        }

        internal void Update(SqlConnection cn)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(cn);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(cn);
        }
        private void ExecuteUpdate(SqlTransaction tr, long MaChungTu)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblcnQuyetDinh";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();
                _ChungTu_QuyetDinhList.MaQuyetDinh = _maQuyetDinh;
                ChungTu_QuyetDinh _ChungTu_QuyetDinh = new ChungTu_QuyetDinh(ChungTu_QuyetDinhList.MaChungTu , _maQuyetDinh, 1);
                _ChungTu_QuyetDinhList.Add(_ChungTu_QuyetDinh);
                _ChungTu_QuyetDinhList.ApplyEdit();
                _ChungTu_QuyetDinhList.DataPortal_Update(tr, MaChungTu);


            }//using
        }

        private void ExecuteUpdate(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblcnQuyetDinh";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaQuyetDinh", _maQuyetDinh);
            if (_maKyTinhLuong != 0)
                cm.Parameters.AddWithValue("@MaKyTinhLuong", _maKyTinhLuong);
            else
                cm.Parameters.AddWithValue("@MaKyTinhLuong", DBNull.Value);
            if (_soQuyetDinh.Length > 0)
                cm.Parameters.AddWithValue("@SoQuyetDinh", _soQuyetDinh);
            else
                cm.Parameters.AddWithValue("@SoQuyetDinh", DBNull.Value);

            cm.Parameters.AddWithValue("@NgayKy", _ngayKy.DBValue);
            if (_nguoiKy != 0)
                cm.Parameters.AddWithValue("@NguoiKy", _nguoiKy);
            else
                cm.Parameters.AddWithValue("@NguoiKy", DBNull.Value);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_tongTien != 0)
                cm.Parameters.AddWithValue("@TongTien", _tongTien);
            else
                cm.Parameters.AddWithValue("@TongTien", DBNull.Value);
            if (_maNguoiNhanTien != 0)
                cm.Parameters.AddWithValue("@MaNguoiNhanTien", _maNguoiNhanTien);
            else
                cm.Parameters.AddWithValue("@MaNguoiNhanTien", DBNull.Value);

            cm.Parameters.AddWithValue("@TinhTrang", _tinhTrang);

            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.DBValue);

            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            if (_loaiQuyetDinh != 0)
                cm.Parameters.AddWithValue("@LoaiQuyetDinh", _loaiQuyetDinh);
            else
                cm.Parameters.AddWithValue("@LoaiQuyetDinh", DBNull.Value);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maQuyetDinh));
            MarkNew();
        }
        internal void DeleteSelf(SqlConnection cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn, new Criteria(_maQuyetDinh));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
