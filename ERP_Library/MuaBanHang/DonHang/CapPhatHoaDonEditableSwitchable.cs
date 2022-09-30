
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CapPhatHoaDon : Csla.BusinessBase<CapPhatHoaDon>
    {
        #region Business Properties and Methods

        //declare members
        private int _id = 0;
        private int _tuSo = 0;
        private int _denSo = 0;
        private string _kyHieu = string.Empty;
        private string _ghiChu = string.Empty;
        private DateTime _ngayCap = DateTime.Now.Date;
        private int _maBoPhanDuocCap = 0;
        private string _tenBoPhanDuocCap = string.Empty;
        private int _maBoPhanCap = 0;
        private string _tenBoPhanCap = string.Empty;
        private int _maDaiLyDuocCap = 0;
        private string _tenDaiLyDuocCap = string.Empty;
        private bool _sudung = false;

        [System.ComponentModel.DataObjectField(true, true)]
        public int Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public int TuSo
        {
            get
            {
                CanReadProperty("TuSo", true);
                return _tuSo;
            }
            set
            {
                CanWriteProperty("TuSo", true);
                if (!_tuSo.Equals(value))
                {
                    _tuSo = value;
                    PropertyHasChanged("TuSo");
                }
            }
        }

        public int DenSo
        {
            get
            {
                CanReadProperty("DenSo", true);
                return _denSo;
            }
            set
            {
                CanWriteProperty("DenSo", true);
                if (!_denSo.Equals(value))
                {
                    _denSo = value;
                    PropertyHasChanged("DenSo");
                }
            }
        }

        public string KyHieu
        {
            get
            {
                CanReadProperty("KyHieu", true);
                return _kyHieu;
            }
            set
            {
                CanWriteProperty("KyHieu", true);
                if (value == null) value = string.Empty;
                if (!_kyHieu.Equals(value))
                {
                    _kyHieu = value;
                    PropertyHasChanged("KyHieu");
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
        public DateTime NgayCap
        {
            get
            {
                CanReadProperty("NgayCap", true);
                return _ngayCap.Date;
            }
            set
            {
                if (!_ngayCap.Equals(value))
                    _ngayCap = value;
                PropertyHasChanged();
            }
        }

        public int MaBoPhanDuocCap
        {
            get
            {
                CanReadProperty( true);
                return _maBoPhanDuocCap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maBoPhanDuocCap.Equals(value))
                {
                    _maBoPhanDuocCap = value;
                    PropertyHasChanged();
                }
            }
        }

        public string TenBoPhanDuocCap
        {
            get
            {
                CanReadProperty("TenBoPhanDuocCap", true);
                return _tenBoPhanDuocCap;
            }
            set
            {
                CanWriteProperty("TenBoPhanDuocCap", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhanDuocCap.Equals(value))
                {
                    _tenBoPhanDuocCap = value;
                    PropertyHasChanged("TenBoPhanDuocCap");
                }
            }
        }

        public int MaBoPhanCap
        {
            get
            {
                CanReadProperty("MaBoPhanCap", true);
                return _maBoPhanCap;
            }
            set
            {
                CanWriteProperty("MaBoPhanCap", true);
                if (!_maBoPhanCap.Equals(value))
                {
                    _maBoPhanCap = value;
                    PropertyHasChanged("MaBoPhanCap");
                }
            }
        }

        public string TenBoPhanCap
        {
            get
            {
                CanReadProperty("TenBoPhanCap", true);
                return _tenBoPhanCap;
            }
            set
            {
                CanWriteProperty("TenBoPhanCap", true);
                if (value == null) value = string.Empty;
                if (!_tenBoPhanCap.Equals(value))
                {
                    _tenBoPhanCap = value;
                    PropertyHasChanged("TenBoPhanCap");
                }
            }
        }

        public int MaDaiLyDuocCap
        {
            get
            {
                CanReadProperty("MaDaiLyDuocCap", true);
                return _maDaiLyDuocCap;
            }
            set
            {
                CanWriteProperty("MaDaiLyDuocCap", true);
                if (!_maDaiLyDuocCap.Equals(value))
                {
                    _maDaiLyDuocCap = value;
                    PropertyHasChanged("MaDaiLyDuocCap");
                }
            }
        }

        public string TenDaiLyDuocCap
        {
            get
            {
                CanReadProperty("TenDaiLyDuocCap", true);
                return _tenDaiLyDuocCap;
            }
            set
            {
                CanWriteProperty("TenDaiLyDuocCap", true);
                if (value == null) value = string.Empty;
                if (!_tenDaiLyDuocCap.Equals(value))
                {
                    _tenDaiLyDuocCap = value;
                    PropertyHasChanged("TenDaiLyDuocCap");
                }
            }
        }

        public bool SuDung
        {
            get
            {
                CanReadProperty(true);
                return _sudung;
            }
            set
            {
                CanWriteProperty( true);
                if (!_sudung.Equals(value))
                {
                    _sudung = value;
                    PropertyHasChanged();
                }
            }
        }


        protected override object GetIdValue()
        {
            return _id;
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
            // KyHieu
            //
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
            //TODO: Define authorization rules in CapPhatHoaDon
            //AuthorizationRules.AllowRead("Id", "CapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("TuSo", "CapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("DenSo", "CapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("KyHieu", "CapPhatHoaDonReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "CapPhatHoaDonReadGroup");

            //AuthorizationRules.AllowWrite("TuSo", "CapPhatHoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("DenSo", "CapPhatHoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("KyHieu", "CapPhatHoaDonWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "CapPhatHoaDonWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CapPhatHoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CapPhatHoaDonViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CapPhatHoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CapPhatHoaDonAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CapPhatHoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CapPhatHoaDonEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CapPhatHoaDon
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CapPhatHoaDonDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CapPhatHoaDon()
        { /* require use of factory method */ }

        public static CapPhatHoaDon NewCapPhatHoaDon()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CapPhatHoaDon");
            return DataPortal.Create<CapPhatHoaDon>();
        }

        public static CapPhatHoaDon GetCapPhatHoaDon(int id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CapPhatHoaDon");
            return DataPortal.Fetch<CapPhatHoaDon>(new Criteria(id));
        }

        public static void DeleteCapPhatHoaDon(int id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CapPhatHoaDon");
            DataPortal.Delete(new Criteria(id));
        }

        public override CapPhatHoaDon Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CapPhatHoaDon");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CapPhatHoaDon");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a CapPhatHoaDon");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static CapPhatHoaDon NewCapPhatHoaDonChild()
        {
            CapPhatHoaDon child = new CapPhatHoaDon();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static CapPhatHoaDon GetCapPhatHoaDon(SafeDataReader dr)
        {
            CapPhatHoaDon child = new CapPhatHoaDon();
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
            public int Id;

            public Criteria(int id)
            {
                this.Id = id;
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
                cm.CommandText = "[spd_SelecttblCapSoHoaDon]";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            DataPortal_Delete(new Criteria(_id));
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
                cm.CommandText = "[spd_DeletetblCapSoHoaDon]";

                cm.Parameters.AddWithValue("@ID", criteria.Id);

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
            _id = dr.GetInt32("ID");
            _tuSo = dr.GetInt32("TuSo");
            _denSo = dr.GetInt32("DenSo");
            _kyHieu = dr.GetString("KyHieu");
            _ghiChu = dr.GetString("GhiChu");
            _ngayCap = dr.GetDateTime("NgayCap");
            _maBoPhanDuocCap = dr.GetInt32("MaBoPhanDuocCap");
            _tenBoPhanDuocCap = dr.GetString("TenBoPhanDuocCap");
            _maBoPhanCap = dr.GetInt32("MaBoPhanCap");
            _tenBoPhanCap = dr.GetString("TenBoPhanCap");
            _maDaiLyDuocCap = dr.GetInt32("MaDaiLyDuocCap");
            _sudung = dr.GetBoolean("SuDung");
            _tenDaiLyDuocCap = dr.GetString("TenDaiLyDuocCap");
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
                cm.CommandText = "[spd_InserttblCapSoHoaDon]";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (int)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tuSo != 0)
                cm.Parameters.AddWithValue("@TuSo", _tuSo);
            else
                cm.Parameters.AddWithValue("@TuSo", DBNull.Value);
            if (_denSo != 0)
                cm.Parameters.AddWithValue("@DenSo", _denSo);
            else
                cm.Parameters.AddWithValue("@DenSo", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.Date);
            if (_maBoPhanDuocCap != 0)
                cm.Parameters.AddWithValue("@MaBoPhanDuocCap", _maBoPhanDuocCap);
            else
                cm.Parameters.AddWithValue("@MaBoPhanDuocCap", DBNull.Value);
            cm.Parameters.AddWithValue("@TenBoPhanDuocCap", BoPhan.GetBoPhan(_maBoPhanDuocCap).TenBoPhan);
            cm.Parameters.AddWithValue("@MaBoPhanCap", Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@TenBoPhanCap", BoPhan.GetBoPhan(Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            if (_maDaiLyDuocCap != 0)
                cm.Parameters.AddWithValue("@MaDaiLyDuocCap", _maDaiLyDuocCap);
            else
                cm.Parameters.AddWithValue("@MaDaiLyDuocCap", DBNull.Value);
            cm.Parameters.AddWithValue("@TenDaiLyDuocCap", DoiTac.GetDoiTac(_maDaiLyDuocCap).TenDoiTac);
            if (_maBoPhanDuocCap == Security.CurrentUser.Info.MaBoPhan)
                cm.Parameters.AddWithValue("@SuDung", 1);
            else
                cm.Parameters.AddWithValue("@SuDung", 0);
            cm.Parameters.AddWithValue("@ID", _id);
            cm.Parameters["@ID"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "[spd_UpdatetblCapSoHoaDon]";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_tuSo != 0)
                cm.Parameters.AddWithValue("@TuSo", _tuSo);
            else
                cm.Parameters.AddWithValue("@TuSo", DBNull.Value);
            if (_denSo != 0)
                cm.Parameters.AddWithValue("@DenSo", _denSo);
            else
                cm.Parameters.AddWithValue("@DenSo", DBNull.Value);
            if (_kyHieu.Length > 0)
                cm.Parameters.AddWithValue("@KyHieu", _kyHieu);
            else
                cm.Parameters.AddWithValue("@KyHieu", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayCap", _ngayCap.Date);
            if (_maBoPhanDuocCap != 0)
                cm.Parameters.AddWithValue("@MaBoPhanDuocCap", _maBoPhanDuocCap);
            else
                cm.Parameters.AddWithValue("@MaBoPhanDuocCap", DBNull.Value);
            cm.Parameters.AddWithValue("@TenBoPhanDuocCap", BoPhan.GetBoPhan(_maBoPhanDuocCap).TenBoPhan);
            cm.Parameters.AddWithValue("@MaBoPhanCap", Security.CurrentUser.Info.MaBoPhan);
            cm.Parameters.AddWithValue("@TenBoPhanCap", BoPhan.GetBoPhan(Security.CurrentUser.Info.MaBoPhan).TenBoPhan);
            if (_maDaiLyDuocCap != 0)
                cm.Parameters.AddWithValue("@MaDaiLyDuocCap", _maDaiLyDuocCap);
            else
                cm.Parameters.AddWithValue("@MaDaiLyDuocCap", DBNull.Value);
            cm.Parameters.AddWithValue("@TenDaiLyDuocCap", DoiTac.GetDoiTac(_maDaiLyDuocCap).TenDoiTac);

            if (_maBoPhanDuocCap == Security.CurrentUser.Info.MaBoPhan)
                cm.Parameters.AddWithValue("@SuDung", 1);
            else
                cm.Parameters.AddWithValue("@SuDung", 0);
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

            ExecuteDelete(tr, new Criteria(_id));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access


        // tru ra hoa don mua hang dich vu
        public static int LaySoHoaDon(ref string _sokh, ref string _sohd, int mabophan)
        {
            int dodaiHoaDon = 7;
            int _tuso = 0, _denso = 0, _kiemtra = 0;
            CapPhatHoaDonList _caphd = CapPhatHoaDonList.GetCapPhatHoaDonListSuDungMoiNhat(mabophan);
            if (_caphd.Count != 0)
            {
                _tuso = _caphd[0].TuSo;
                _denso = _caphd[0].DenSo;
            }
            object _obj;
            using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
            {
                cn.Open();
                {
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_GetSoHoaDonLonNhatAll";
                        cm.Parameters.AddWithValue("@mabophan", mabophan);
                        _obj = cm.ExecuteScalar();
                    }
                }
            }
            // kiem tra cac truong hop cua hoa don tu tang 
            bool isnum;
            int Num;
            isnum = int.TryParse(_obj.ToString(), out Num);
            if (isnum)
            {
                if (Convert.ToInt32(_obj) > _denso || Convert.ToInt32(_obj) < _tuso && Convert.ToInt32(_obj)!=0)
                    _kiemtra = 1; // Nam ngoai khoang so hoa don duoc cap.
                // 1 So hoa don tang khong nam trong khoang tang             
                if (_caphd.Count != 0)
                    _sokh = _caphd[0].KyHieu;
                if (Convert.ToInt32(_obj) == 0)
                    _sohd = _tuso.ToString();
                else
                    _sohd = Convert.ToString(Convert.ToInt32(_obj.ToString()) + 1);

                int _lensohd=_sohd.Length;

                if (_lensohd < dodaiHoaDon+1)
                    for (int i = 1; i <= dodaiHoaDon - _lensohd; i++)
                    {
                        _sohd = "0" + _sohd;
                    }
            }
            else
            {
                _sohd = "";
            }
            if (_sokh == "")
            {
                object oSerial;
                using (SqlConnection cn = new SqlConnection(ERP_Library.Database.ERP_Connection))
                {
                    cn.Open();
                    {
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_GetSoSerialHoaDonBanRa";
                            cm.Parameters.AddWithValue("@mabophan", mabophan);
                            oSerial = cm.ExecuteScalar();
                        }
                    }
                }
                _sokh = oSerial + "";
            }
            return _kiemtra;
        }
        // By Loc Test So Hoa Don
        public static int KiemTraSoHoaDon(string SoHD, string KyHieu)
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
                        cm.CommandText = "spd_KiemTraTrungSoHoaDon";
                        cm.Parameters.AddWithValue("@SoHD", SoHD);
                        cm.Parameters.AddWithValue("@KyHieu", KyHieu);
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
        public static int KiemTraSoHoDonSua(string SoHD, string KyHieu, long mahoadon)
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
                        cm.CommandText = "spd_KiemTraTrungSoHoaDonSua";
                        cm.Parameters.AddWithValue("@SoHD", SoHD);
                        cm.Parameters.AddWithValue("@KyHieu", KyHieu);
                        cm.Parameters.AddWithValue("@mahoadon", mahoadon);
                        gt = (int)cm.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return gt;
            }//using
        }
    }
}
