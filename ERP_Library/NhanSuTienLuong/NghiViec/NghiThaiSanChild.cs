
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class NghiThaiSanChild : Csla.BusinessBase<NghiThaiSanChild>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maNghiThaiSan = 0;
        private int _maBoPhan = 0;
        private long _maNhanVien = 0;
        private string _ghiChu = string.Empty;
        private int _maKyLuong = 0;
        private int _tuKy = 0;
        private int _denKy = 0;
        private DateTime _ngayBatDau = DateTime.Today;
        private DateTime _ngayKetThuc = DateTime.Today;
        private long _nguoiLap = Security.CurrentUser.Info.UserID;
        private bool _traThe = false;
        private DateTime _ngayLap = DateTime.Today;
        private int _soNgay = 1;
        private decimal _luongBaoHiem = 0;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaNghiThaiSan
        {
            get
            {
                return _maNghiThaiSan;
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
            set
            {
                if (!_maBoPhan.Equals(value))
                {
                    _maBoPhan = value;
                    PropertyHasChanged("MaBoPhan");
                }
            }
        }

        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
            set
            {
                if (!_maNhanVien.Equals(value))
                {
                    _maNhanVien = value;
                    PropertyHasChanged("MaNhanVien");
                }
            }
        }

        public string GhiChu
        {
            get
            {
                return _ghiChu;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_ghiChu.Equals(value))
                {
                    _ghiChu = value;
                    PropertyHasChanged("GhiChu");
                }
            }
        }

        public int MaKyLuong
        {
            get
            {
                return _maKyLuong;
            }
            set
            {
                if (!_maKyLuong.Equals(value))
                {
                    _maKyLuong = value;
                    PropertyHasChanged("MaKyLuong");
                }
            }
        }

        public int TuKy
        {
            get
            {
                return _tuKy;
            }
            set
            {
                if (!_tuKy.Equals(value))
                {
                    _tuKy = value;
                    PropertyHasChanged("TuKy");
                }
            }
        }

        public int DenKy
        {
            get
            {
                return _denKy;
            }
            set
            {
                if (!_denKy.Equals(value))
                {
                    _denKy = value;
                    PropertyHasChanged("DenKy");
                }
            }
        }

        public DateTime NgayBatDau
        {
            get
            {
                return _ngayBatDau;
            }
            set
            {
                if (!_ngayBatDau.Equals(value))
                {
                    _ngayBatDau = value;
                    PropertyHasChanged("NgayBatDau");
                    CapNhatSoNgay();
                }
            }
        }

        public DateTime NgayKetThuc
        {
            get
            {
                return _ngayKetThuc;
            }
            set
            {
                if (!_ngayKetThuc.Equals(value))
                {
                    _ngayKetThuc = value;
                    PropertyHasChanged("NgayKetThuc");
                    CapNhatSoNgay();
                }
            }
        }

        public int SoNgay
        {
            get
            {
                return _soNgay;
            }
            set
            {
                if (!_soNgay.Equals(value))
                {
                    _soNgay = value;
                    PropertyHasChanged("SoNgay");
                }
            }
        }

        public long NguoiLap
        {
            get
            {
                return _nguoiLap;
            }
            set
            {
                if (!_nguoiLap.Equals(value))
                {
                    _nguoiLap = value;
                    PropertyHasChanged("NguoiLap");
                }
            }
        }

        public bool TraThe
        {
            get
            {
                return _traThe;
            }
            set
            {
                if (!_traThe.Equals(value))
                {
                    _traThe = value;
                    PropertyHasChanged("TraThe");
                }
            }
        }

        public DateTime NgayLap
        {
            get
            {
                return _ngayLap;
            }
            set
            {
                if (!_ngayLap.Equals(value))
                {
                    _ngayLap = value;
                    PropertyHasChanged("NgayLap");
                }
            }
        }

        public decimal LuongBaoHiem
        {
            get
            {
                return _luongBaoHiem;
            }
            set
            {
                if (!_luongBaoHiem.Equals(value))
                {
                    _luongBaoHiem = value;
                    PropertyHasChanged();
                }
            }
        }
	

        protected override object GetIdValue()
        {
            return _maNghiThaiSan;
        }

        #endregion //Business Properties and Methods

        private void CapNhatSoNgay()
        {
            //kiểm tra ngày holiday
            SqlConnection cn = new SqlConnection(Database.ERP_Connection);
            cn.Open();
            SqlCommand cm = cn.CreateCommand();
            cm.CommandText = "Select Ngay From tblnsNgayHoliday";
            cm.CommandType = CommandType.Text;
            System.Collections.Generic.List<DateTime> d = new System.Collections.Generic.List<DateTime>();
            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
            {
                while (dr.Read())
                {
                    d.Add(dr.GetDateTime("Ngay"));
                }
            }
            cn.Close();
            //không tính thứ 7 và chủ nhật
            int i = 0;
            if (_ngayBatDau <= _ngayKetThuc)
            {
                for (DateTime ngay = _ngayBatDau; ngay <= _ngayKetThuc; ngay = ngay.AddDays(1))
                {
                    if (ngay.DayOfWeek != DayOfWeek.Saturday && ngay.DayOfWeek != DayOfWeek.Sunday)
                    {
                        if (!d.Contains(ngay))
                            i++;
                    }
                }
            }

            SoNgay = i;
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

        #region Factory Methods
        public NghiThaiSanChild()
        { /* require use of factory method */ }

        public static NghiThaiSanChild NewNghiThaiSanChild()
        {
            return DataPortal.Create<NghiThaiSanChild>();
        }

        public static NghiThaiSanChild GetNghiThaiSanChild(int maNghiThaiSan)
        {
            return DataPortal.Fetch<NghiThaiSanChild>(new Criteria(maNghiThaiSan));
        }

        public static void DeleteNghiThaiSanChild(int maNghiThaiSan)
        {
            DataPortal.Delete(new Criteria(maNghiThaiSan));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static NghiThaiSanChild NewNghiThaiSanChildChild()
        {
            NghiThaiSanChild child = new NghiThaiSanChild();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static NghiThaiSanChild GetNghiThaiSanChild(SafeDataReader dr)
        {
            NghiThaiSanChild child = new NghiThaiSanChild();
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
            public int MaNghiThaiSan;

            public Criteria(int maNghiThaiSan)
            {
                this.MaNghiThaiSan = maNghiThaiSan;
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
                cm.CommandText = "spd_Select_NghiThaiSanChild";

                cm.Parameters.AddWithValue("@MaNghiThaiSan", criteria.MaNghiThaiSan);

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
            DataPortal_Delete(new Criteria(_maNghiThaiSan));
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
                cm.CommandText = "spd_Delete_NghiThaiSanChild";

                cm.Parameters.AddWithValue("@MaNghiThaiSan", criteria.MaNghiThaiSan);

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
            _maNghiThaiSan = dr.GetInt32("MaNghiThaiSan");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _ghiChu = dr.GetString("GhiChu");
            _maKyLuong = dr.GetInt32("MaKyLuong");
            _tuKy = dr.GetInt32("TuKy");
            _denKy = dr.GetInt32("DenKy");
            _ngayBatDau = dr.GetDateTime("NgayBatDau");
            _ngayKetThuc = dr.GetDateTime("NgayKetThuc");
            _nguoiLap = dr.GetInt64("NguoiLap");
            _traThe = dr.GetBoolean("TraThe");
            _ngayLap = dr.GetDateTime("NgayLap");
            _soNgay = dr.GetInt32("SoNgay");
            _luongBaoHiem = dr.GetDecimal("LuongBaoHiem");
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
                cm.CommandText = "spd_Insert_NghiThaiSanChild";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maNghiThaiSan = (int)cm.Parameters["@MaNghiThaiSan"].Value;
                _luongBaoHiem = Convert.ToDecimal(cm.Parameters["@LuongBaoHiemOUT"].Value);
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maKyLuong != 0)
                cm.Parameters.AddWithValue("@MaKyLuong", _maKyLuong);
            else
                cm.Parameters.AddWithValue("@MaKyLuong", DBNull.Value);
            if (_tuKy != 0)
                cm.Parameters.AddWithValue("@TuKy", _tuKy);
            else
                cm.Parameters.AddWithValue("@TuKy", DBNull.Value);
            if (_denKy != 0)
                cm.Parameters.AddWithValue("@DenKy", _denKy);
            else
                cm.Parameters.AddWithValue("@DenKy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau);
            cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_traThe != false)
                cm.Parameters.AddWithValue("@TraThe", _traThe);
            else
                cm.Parameters.AddWithValue("@TraThe", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaNghiThaiSan", _maNghiThaiSan);
            cm.Parameters["@MaNghiThaiSan"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@SoNgay", _soNgay);
            cm.Parameters.AddWithValue("@LuongBaoHiem", _luongBaoHiem);
            cm.Parameters.AddWithValue("@LuongBaoHiemOUT", _luongBaoHiem);
            cm.Parameters["@LuongBaoHiemOUT"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_NghiThaiSanChild";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();
                _luongBaoHiem = Convert.ToDecimal(cm.Parameters["@LuongBaoHiemOUT"].Value);
            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNghiThaiSan", _maNghiThaiSan);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maKyLuong != 0)
                cm.Parameters.AddWithValue("@MaKyLuong", _maKyLuong);
            else
                cm.Parameters.AddWithValue("@MaKyLuong", DBNull.Value);
            if (_tuKy != 0)
                cm.Parameters.AddWithValue("@TuKy", _tuKy);
            else
                cm.Parameters.AddWithValue("@TuKy", DBNull.Value);
            if (_denKy != 0)
                cm.Parameters.AddWithValue("@DenKy", _denKy);
            else
                cm.Parameters.AddWithValue("@DenKy", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayBatDau", _ngayBatDau);
            cm.Parameters.AddWithValue("@NgayKetThuc", _ngayKetThuc);
            if (_nguoiLap != 0)
                cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            else
                cm.Parameters.AddWithValue("@NguoiLap", DBNull.Value);
            if (_traThe != false)
                cm.Parameters.AddWithValue("@TraThe", _traThe);
            else
                cm.Parameters.AddWithValue("@TraThe", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@SoNgay", _soNgay);
            cm.Parameters.AddWithValue("@LuongBaoHiem", _luongBaoHiem);
            cm.Parameters.AddWithValue("@LuongBaoHiemOUT", _luongBaoHiem);
            cm.Parameters["@LuongBaoHiemOUT"].Direction = ParameterDirection.Output;
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

            ExecuteDelete(tr, new Criteria(_maNghiThaiSan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
