using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CTNhapXuatImportFromExcel : Csla.BusinessBase<CTNhapXuatImportFromExcel>
    {
        #region Business Properties and Methods

        //declare members
        private long _id = 0;
        private int _stt = 0;
        private string _soChungTu = string.Empty;
        private string _maVTHH = string.Empty;
        private string _tenVTHH = string.Empty;
        private decimal _soLuong = 0;
        private decimal _donGia = 0;
        private decimal _thanhTien = 0;
        private string _ghiChu = string.Empty;
        private int _maCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        private int _userImport = ERP_Library.Security.CurrentUser.Info.UserID;
        private string _fileImportName = string.Empty;
        DateTime _ngayImport = DateTime.Today.Date;

        [System.ComponentModel.DataObjectField(true, true)]
        public long Id
        {
            get
            {
                CanReadProperty("Id", true);
                return _id;
            }
        }

        public int Stt
        {
            get
            {
                CanReadProperty("Stt", true);
                return _stt;
            }
            set
            {
                CanWriteProperty("Stt", true);
                if (!_stt.Equals(value))
                {
                    _stt = value;
                    PropertyHasChanged("Stt");
                }
            }
        }

        public string SoChungTu
        {
            get
            {
                CanReadProperty("SoChungTu", true);
                return _soChungTu;
            }
            set
            {
                CanWriteProperty("SoChungTu", true);
                if (value == null) value = string.Empty;
                if (!_soChungTu.Equals(value))
                {
                    _soChungTu = value;
                    PropertyHasChanged("SoChungTu");
                }
            }
        }

        public string MaVTHH
        {
            get
            {
                CanReadProperty("MaVTHH", true);
                return _maVTHH;
            }
            set
            {
                CanWriteProperty("MaVTHH", true);
                if (value == null) value = string.Empty;
                if (!_maVTHH.Equals(value))
                {
                    _maVTHH = value;
                    PropertyHasChanged("MaVTHH");
                }
            }
        }

        public string TenVTHH
        {
            get
            {
                CanReadProperty("TenVTHH", true);
                return _tenVTHH;
            }
            set
            {
                CanWriteProperty("TenVTHH", true);
                if (value == null) value = string.Empty;
                if (!_tenVTHH.Equals(value))
                {
                    _tenVTHH = value;
                    PropertyHasChanged("TenVTHH");
                }
            }
        }

        public decimal SoLuong
        {
            get
            {
                CanReadProperty("SoLuong", true);
                return _soLuong;
            }
            set
            {
                CanWriteProperty("SoLuong", true);
                if (!_soLuong.Equals(value))
                {
                    _soLuong = value;
                    PropertyHasChanged("SoLuong");
                }
            }
        }

        public decimal DonGia
        {
            get
            {
                CanReadProperty("DonGia", true);
                return _donGia;
            }
            set
            {
                CanWriteProperty("DonGia", true);
                if (!_donGia.Equals(value))
                {
                    _donGia = value;
                    PropertyHasChanged("DonGia");
                }
            }
        }

        public decimal ThanhTien
        {
            get
            {
                CanReadProperty("ThanhTien", true);
                return _thanhTien;
            }
            set
            {
                CanWriteProperty("ThanhTien", true);
                if (!_thanhTien.Equals(value))
                {
                    _thanhTien = value;
                    PropertyHasChanged("ThanhTien");
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

        public int MaCongTy
        {
            get
            {
                CanReadProperty("MaCongTy", true);
                return _maCongTy;
            }
            set
            {
                CanWriteProperty("MaCongTy", true);
                if (!_maCongTy.Equals(value))
                {
                    _maCongTy = value;
                    PropertyHasChanged("MaCongTy");
                }
            }
        }

        public int UserImport
        {
            get
            {
                CanReadProperty("UserImport", true);
                return _userImport;
            }
            set
            {
                CanWriteProperty("UserImport", true);
                if (!_userImport.Equals(value))
                {
                    _userImport = value;
                    PropertyHasChanged("UserImport");
                }
            }
        }

        public string FileImportName
        {
            get
            {
                CanReadProperty("FileImportName", true);
                return _fileImportName;
            }
            set
            {
                CanWriteProperty("FileImportName", true);
                if (value == null) value = string.Empty;
                if (!_fileImportName.Equals(value))
                {
                    _fileImportName = value;
                    PropertyHasChanged("FileImportName");
                }
            }
        }

        public DateTime NgayImport
        {
            get
            {
                CanReadProperty("NgayImport", true);
                return _ngayImport.Date;
            }
            set
            {
                CanWriteProperty("NgayImport", true);
                if (!_ngayImport.Equals(value))
                {
                    _ngayImport = value;
                    PropertyHasChanged("NgayImport");
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
            //TODO: Define authorization rules in CTNhapXuatImportFromExcel
            //AuthorizationRules.AllowRead("Id", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("Stt", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("SoChungTu", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("MaVTHH", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("TenVTHH", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("SoLuong", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("DonGia", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("ThanhTien", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("GhiChu", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("MaCongTy", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("UserImport", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("FileImportName", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayImport", "CTNhapXuatImportFromExcelReadGroup");
            //AuthorizationRules.AllowRead("NgayImportString", "CTNhapXuatImportFromExcelReadGroup");

            //AuthorizationRules.AllowWrite("Stt", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("SoChungTu", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("MaVTHH", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("TenVTHH", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("SoLuong", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("DonGia", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("ThanhTien", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("GhiChu", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongTy", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("UserImport", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("FileImportName", "CTNhapXuatImportFromExcelWriteGroup");
            //AuthorizationRules.AllowWrite("NgayImportString", "CTNhapXuatImportFromExcelWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CTNhapXuatImportFromExcel
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CTNhapXuatImportFromExcelViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CTNhapXuatImportFromExcel
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CTNhapXuatImportFromExcelAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CTNhapXuatImportFromExcel
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CTNhapXuatImportFromExcelEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CTNhapXuatImportFromExcel
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CTNhapXuatImportFromExcelDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CTNhapXuatImportFromExcel()
        { /* require use of factory method */ }

        public static CTNhapXuatImportFromExcel NewCTNhapXuatImportFromExcel()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CTNhapXuatImportFromExcel");
            return DataPortal.Create<CTNhapXuatImportFromExcel>();
        }

        public static CTNhapXuatImportFromExcel GetCTNhapXuatImportFromExcel(long id)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CTNhapXuatImportFromExcel");
            return DataPortal.Fetch<CTNhapXuatImportFromExcel>(new Criteria(id));
        }

        public static void DeleteCTNhapXuatImportFromExcel(long id)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CTNhapXuatImportFromExcel");
            DataPortal.Delete(new Criteria(id));
        }

        public override CTNhapXuatImportFromExcel Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CTNhapXuatImportFromExcel");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CTNhapXuatImportFromExcel");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a CTNhapXuatImportFromExcel");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static CTNhapXuatImportFromExcel NewCTNhapXuatImportFromExcelChild()
        {
            CTNhapXuatImportFromExcel child = new CTNhapXuatImportFromExcel();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static CTNhapXuatImportFromExcel GetCTNhapXuatImportFromExcel(SafeDataReader dr)
        {
            CTNhapXuatImportFromExcel child = new CTNhapXuatImportFromExcel();
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
            public long Id;

            public Criteria(long id)
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
                cm.CommandText = "spd_SelecttblCTNhapXuatImportFromExcel";

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
                tr = cn.BeginTransaction();
                cn.Open();

                ExecuteInsert(tr);

                //update child object(s)
                UpdateChildren(tr);
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
                if (base.IsDirty)
                {
                    ExecuteUpdate(tr);
                }

                //update child object(s)
                UpdateChildren(tr);
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
                tr=cn.BeginTransaction();
                ExecuteDelete(tr, criteria);

            }//using

        }

        private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCTNhapXuatImportFromExcel";

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
            _id = dr.GetInt64("ID");
            _stt = dr.GetInt32("STT");
            _soChungTu = dr.GetString("SoChungTu");
            _maVTHH = dr.GetString("MaVTHH");
            _tenVTHH = dr.GetString("TenVTHH");
            _soLuong = dr.GetDecimal("SoLuong");
            _donGia = dr.GetDecimal("DonGia");
            _thanhTien = dr.GetDecimal("ThanhTien");
            _ghiChu = dr.GetString("GhiChu");
            _maCongTy = dr.GetInt32("MaCongTy");
            _userImport = dr.GetInt32("UserImport");
            _fileImportName = dr.GetString("FileImportName");
            _ngayImport = dr.GetDateTime("NgayImport");
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
                cm.CommandText = "spd_InserttblCTNhapXuatImportFromExcel";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _id = (long)cm.Parameters["@ID"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_stt != 0)
                cm.Parameters.AddWithValue("@STT", _stt);
            else
                cm.Parameters.AddWithValue("@STT", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maVTHH.Length > 0)
                cm.Parameters.AddWithValue("@MaVTHH", _maVTHH);
            else
                cm.Parameters.AddWithValue("@MaVTHH", DBNull.Value);
            if (_tenVTHH.Length > 0)
                cm.Parameters.AddWithValue("@TenVTHH", _tenVTHH);
            else
                cm.Parameters.AddWithValue("@TenVTHH", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_userImport != 0)
                cm.Parameters.AddWithValue("@UserImport", _userImport);
            else
                cm.Parameters.AddWithValue("@UserImport", DBNull.Value);
            if (_fileImportName.Length > 0)
                cm.Parameters.AddWithValue("@FileImportName", _fileImportName);
            else
                cm.Parameters.AddWithValue("@FileImportName", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayImport", _ngayImport);
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
                cm.CommandText = "spd_UpdatetblCTNhapXuatImportFromExcel";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@ID", _id);
            if (_stt != 0)
                cm.Parameters.AddWithValue("@STT", _stt);
            else
                cm.Parameters.AddWithValue("@STT", DBNull.Value);
            if (_soChungTu.Length > 0)
                cm.Parameters.AddWithValue("@SoChungTu", _soChungTu);
            else
                cm.Parameters.AddWithValue("@SoChungTu", DBNull.Value);
            if (_maVTHH.Length > 0)
                cm.Parameters.AddWithValue("@MaVTHH", _maVTHH);
            else
                cm.Parameters.AddWithValue("@MaVTHH", DBNull.Value);
            if (_tenVTHH.Length > 0)
                cm.Parameters.AddWithValue("@TenVTHH", _tenVTHH);
            else
                cm.Parameters.AddWithValue("@TenVTHH", DBNull.Value);
            if (_soLuong != 0)
                cm.Parameters.AddWithValue("@SoLuong", _soLuong);
            else
                cm.Parameters.AddWithValue("@SoLuong", DBNull.Value);
            if (_donGia != 0)
                cm.Parameters.AddWithValue("@DonGia", _donGia);
            else
                cm.Parameters.AddWithValue("@DonGia", DBNull.Value);
            if (_thanhTien != 0)
                cm.Parameters.AddWithValue("@ThanhTien", _thanhTien);
            else
                cm.Parameters.AddWithValue("@ThanhTien", DBNull.Value);
            if (_ghiChu.Length > 0)
                cm.Parameters.AddWithValue("@GhiChu", _ghiChu);
            else
                cm.Parameters.AddWithValue("@GhiChu", DBNull.Value);
            if (_maCongTy != 0)
                cm.Parameters.AddWithValue("@MaCongTy", _maCongTy);
            else
                cm.Parameters.AddWithValue("@MaCongTy", DBNull.Value);
            if (_userImport != 0)
                cm.Parameters.AddWithValue("@UserImport", _userImport);
            else
                cm.Parameters.AddWithValue("@UserImport", DBNull.Value);
            if (_fileImportName.Length > 0)
                cm.Parameters.AddWithValue("@FileImportName", _fileImportName);
            else
                cm.Parameters.AddWithValue("@FileImportName", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayImport", _ngayImport);
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
    }
}
