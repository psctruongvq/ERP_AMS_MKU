using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.ThanhToan
{
    [Serializable()]
    public class DeNghiChuyenKhoan_ChungTu : Csla.BusinessBase<DeNghiChuyenKhoan_ChungTu>
    {
        #region Business Properties and Methods

        //declare members
        internal long _maChungTu = 0;
        private long _maPhieu = 0;
        private int _maLoaiChungTu = 0;
        private string _dienGiai = string.Empty;
        private decimal _soTien = 0;
        private string _duLieuChungTu = "";

        [System.ComponentModel.DataObjectField(true, true)]
        public long MaChungTu
        {
            get
            {
                return _maChungTu;
            }
        }

        public long MaPhieu
        {
            get
            {
                return _maPhieu;
            }
            set
            {
                if (!_maPhieu.Equals(value))
                {
                    _maPhieu = value;
                    PropertyHasChanged("MaPhieu");
                }
            }
        }

        public int MaLoaiChungTu
        {
            get
            {
                return _maLoaiChungTu;
            }
            set
            {
                if (!_maLoaiChungTu.Equals(value))
                {
                    _maLoaiChungTu = value;
                    PropertyHasChanged("MaLoaiChungTu");
                }
            }
        }

        public string DienGiai
        {
            get
            {
                return _dienGiai;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (!_dienGiai.Equals(value))
                {
                    _dienGiai = value;
                    PropertyHasChanged("DienGiai");
                }
            }
        }

        public decimal SoTien
        {
            get
            {
                return _soTien;
            }
            set
            {
                if (!_soTien.Equals(value))
                {
                    _soTien = value;
                    PropertyHasChanged("SoTien");
                }
            }
        }

        public string DuLieuChungTu
        {
            get
            {
                return _duLieuChungTu;
            }
            set
            {
                if (!_duLieuChungTu.Equals(value))
                {
                    _duLieuChungTu = value;
                    PropertyHasChanged("DuLieuChungTu");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maChungTu;
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
            // DienGiai
            //
            //ValidationRules.AddRule(CommonRules.StringRequired, "DienGiai");
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 250));
        }

        protected override void AddBusinessRules()
        {
            //AddCommonRules();
            //AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DeNghiChuyenKhoan_ChungTu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DeNghiChuyenKhoan_ChungTu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DeNghiChuyenKhoan_ChungTu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DeNghiChuyenKhoan_ChungTu
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DeNghiChuyenKhoan_ChungTuDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        public DeNghiChuyenKhoan_ChungTu()
        { /* require use of factory method */ }

        public static DeNghiChuyenKhoan_ChungTu NewDeNghiChuyenKhoan_ChungTu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiChuyenKhoan_ChungTu");
            return DataPortal.Create<DeNghiChuyenKhoan_ChungTu>();
        }

        public static DeNghiChuyenKhoan_ChungTu GetDeNghiChuyenKhoan_ChungTu(long maChungTu)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DeNghiChuyenKhoan_ChungTu");
            return DataPortal.Fetch<DeNghiChuyenKhoan_ChungTu>(new Criteria(maChungTu));
        }

        public static void DeleteDeNghiChuyenKhoan_ChungTu(long maChungTu)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiChuyenKhoan_ChungTu");
            DataPortal.Delete(new Criteria(maChungTu));
        }

        public override DeNghiChuyenKhoan_ChungTu Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a DeNghiChuyenKhoan_ChungTu");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DeNghiChuyenKhoan_ChungTu");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a DeNghiChuyenKhoan_ChungTu");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static DeNghiChuyenKhoan_ChungTu NewDeNghiChuyenKhoan_ChungTuChild()
        {
            DeNghiChuyenKhoan_ChungTu child = new DeNghiChuyenKhoan_ChungTu();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static DeNghiChuyenKhoan_ChungTu GetDeNghiChuyenKhoan_ChungTu(SafeDataReader dr)
        {
            DeNghiChuyenKhoan_ChungTu child = new DeNghiChuyenKhoan_ChungTu();
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
            public long MaChungTu;

            public Criteria(long maChungTu)
            {
                this.MaChungTu = maChungTu;
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
                cm.CommandText = "spd_Select_DeNghiChuyenKhoan_ChungTu";

                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
            DataPortal_Delete(new Criteria(_maChungTu));
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
                cm.CommandText = "spd_Delete_DeNghiChuyenKhoan_ChungTu";

                cm.Parameters.AddWithValue("@MaChungTu", criteria.MaChungTu);

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
            _maChungTu = dr.GetInt64("MaChungTu");
            _maPhieu = dr.GetInt64("MaPhieu");
            _maLoaiChungTu = dr.GetInt32("MaLoaiChungTu");
            _dienGiai = dr.GetString("DienGiai");
            _soTien = dr.GetDecimal("SoTien");
            _duLieuChungTu = (string)dr["DuLieuChungTu"];
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
                cm.CommandText = "spd_Insert_DeNghiChuyenKhoan_ChungTu";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maChungTu = (long)cm.Parameters["@MaChungTu"].Value;
            }//using

            UpdateChiTietDeNghi(tr);
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@DuLieuChungTu", _duLieuChungTu);
            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_DeNghiChuyenKhoan_ChungTu";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using

            UpdateChiTietDeNghi(tr);
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
            cm.Parameters.AddWithValue("@MaPhieu", _maPhieu);
            cm.Parameters.AddWithValue("@MaLoaiChungTu", _maLoaiChungTu);
            cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            cm.Parameters.AddWithValue("@SoTien", _soTien);
            cm.Parameters.AddWithValue("@DuLieuChungTu", _duLieuChungTu);
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

            ExecuteDelete(tr, new Criteria(_maChungTu));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

        /// <summary>
        /// Cập nhật danh sách nhân viên kèm theo phiếu đề nghị
        /// </summary>
        private void UpdateChiTietDeNghi(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 0;
                DataSet ds = new DataSet();
                ds.ReadXml(new System.IO.StringReader(_duLieuChungTu));
                switch (_maLoaiChungTu)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        if (_maLoaiChungTu == 1)
                            cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanLuongDot1";
                        else if (_maLoaiChungTu == 2)
                            cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanLuongDot2";
                        else if (_maLoaiChungTu == 3)
                            cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanLuongDot2";
                        else if (_maLoaiChungTu == 4)
                            cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanTruyLuong";

                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ds.Tables["ChonKyLuong"].Rows[0]["MaKyTinhLuong"]);
                        cm.Parameters.AddWithValue("@MaNganHang", ds.Tables["ChonKyLuong"].Rows[0]["MaNganHang"]);
                        break;
                    case 6: //thù lao
                        cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanThuLao";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ds.Tables["ChonThuLao"].Rows[0]["MaKyTinhLuong"]);
                        cm.Parameters.AddWithValue("@MaNganHang", ds.Tables["ChonThuLao"].Rows[0]["MaNganHang"]);
                        cm.Parameters.AddWithValue("@TuNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["TuNgay"].ToString(), "dd/MM/yyyy", null));
                        cm.Parameters.AddWithValue("@DenNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["DenNgay"].ToString(), "dd/MM/yyyy", null));
                        cm.Parameters.AddWithValue("@MaChuongTrinh", ds.Tables["ChonThuLao"].Rows[0]["MaChuongTrinh"]);
                        cm.Parameters.AddWithValue("@MaDatabaseGui", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseGui"]);
                        cm.Parameters.AddWithValue("@MaDatabaseNhan", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseNhan"]);
                        break;
                    case 109 : //thù lao nhan vien ngoai dai

                        cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanThuLaoCTV";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", SqlDbType.Int);
                        cm.Parameters.Add("@MaNganHang", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@TuNgay", SqlDbType.DateTime);
                        cm.Parameters.AddWithValue("@DenNgay", SqlDbType.DateTime);
                        cm.Parameters.AddWithValue("@MaChuongTrinh", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDatabaseGui", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDatabaseNhan", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDeNghi", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaChungTu", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@LoaiChungTu", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                        //cm.Parameters.AddWithValue("@TuNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["TuNgay"].ToString(), "dd/MM/yyyy", null));
                        //cm.Parameters.AddWithValue("@DenNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["DenNgay"].ToString(), "dd/MM/yyyy", null));
                        //cm.Parameters.AddWithValue("@MaChuongTrinh", ds.Tables["ChonThuLao"].Rows[0]["MaChuongTrinh"]);
                        //cm.Parameters.AddWithValue("@MaDatabaseGui", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseGui"]);
                        //cm.Parameters.AddWithValue("@MaDatabaseNhan", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseNhan"]);
                        //cm.Parameters.AddWithValue("@MaDeNghi", _maPhieu);
                        //cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                        //cm.Parameters.AddWithValue("@LoaiChungTu", _maLoaiChungTu);
                        //cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        foreach (DataRow dr in ds.Tables["ChonThuLao"].Rows)
                        {
                            if (Convert.ToInt32(dr["MaNganHang"].ToString()) != 0)
                            {
                                try
                                {
                                    cm.Parameters["@MaNganHang"].Value = Convert.ToInt32(dr["MaNganHang"].ToString());
                                    cm.Parameters["@MaKyTinhLuong"].Value = Convert.ToInt32(dr["MaKyTinhLuong"].ToString());
                                    cm.Parameters["@TuNgay"].Value = DateTime.ParseExact(dr["TuNgay"].ToString(), "dd/MM/yyyy", null);
                                    cm.Parameters["@DenNgay"].Value = DateTime.ParseExact(dr["DenNgay"].ToString(), "dd/MM/yyyy", null);
                                    cm.Parameters["@MaChuongTrinh"].Value = Convert.ToInt32(dr["MaChuongTrinh"].ToString());
                                    cm.Parameters["@MaDatabaseGui"].Value = Convert.ToInt32(dr["MaDatabaseGui"].ToString());
                                    cm.Parameters["@MaDatabaseNhan"].Value = Convert.ToInt32(dr["MaDatabaseNhan"].ToString());
                                    cm.Parameters["@MaDeNghi"].Value = _maPhieu;
                                    cm.Parameters["@MaChungTu"].Value = _maChungTu;
                                    cm.Parameters["@LoaiChungTu"].Value = _maLoaiChungTu;
                                    cm.Parameters["@UserID"].Value = ERP_Library.Security.CurrentUser.Info.UserID;
                                    cm.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        break;
                    case 111: //thù lao nhan vien ngoai dai

                        cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanThuLaoCTV";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", SqlDbType.Int);
                        cm.Parameters.Add("@MaNganHang", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@TuNgay", SqlDbType.DateTime);
                        cm.Parameters.AddWithValue("@DenNgay", SqlDbType.DateTime);
                        cm.Parameters.AddWithValue("@MaChuongTrinh", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDatabaseGui", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDatabaseNhan", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDeNghi", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaChungTu", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@LoaiChungTu", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                        //cm.Parameters.AddWithValue("@TuNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["TuNgay"].ToString(), "dd/MM/yyyy", null));
                        //cm.Parameters.AddWithValue("@DenNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["DenNgay"].ToString(), "dd/MM/yyyy", null));
                        //cm.Parameters.AddWithValue("@MaChuongTrinh", ds.Tables["ChonThuLao"].Rows[0]["MaChuongTrinh"]);
                        //cm.Parameters.AddWithValue("@MaDatabaseGui", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseGui"]);
                        //cm.Parameters.AddWithValue("@MaDatabaseNhan", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseNhan"]);
                        //cm.Parameters.AddWithValue("@MaDeNghi", _maPhieu);
                        //cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                        //cm.Parameters.AddWithValue("@LoaiChungTu", _maLoaiChungTu);
                        //cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        foreach (DataRow dr in ds.Tables["ChonThuLao"].Rows)
                        {
                            if (Convert.ToInt32(dr["MaNganHang"].ToString()) != 0)
                            {
                                try
                                {
                                    cm.Parameters["@MaNganHang"].Value = Convert.ToInt32(dr["MaNganHang"].ToString());
                                    cm.Parameters["@MaKyTinhLuong"].Value = Convert.ToInt32(dr["MaKyTinhLuong"].ToString());
                                    cm.Parameters["@TuNgay"].Value = DateTime.ParseExact(dr["TuNgay"].ToString(), "dd/MM/yyyy", null);
                                    cm.Parameters["@DenNgay"].Value = DateTime.ParseExact(dr["DenNgay"].ToString(), "dd/MM/yyyy", null);
                                    cm.Parameters["@MaChuongTrinh"].Value = Convert.ToInt32(dr["MaChuongTrinh"].ToString());
                                    cm.Parameters["@MaDatabaseGui"].Value = Convert.ToInt32(dr["MaDatabaseGui"].ToString());
                                    cm.Parameters["@MaDatabaseNhan"].Value = Convert.ToInt32(dr["MaDatabaseNhan"].ToString());
                                    cm.Parameters["@MaDeNghi"].Value = _maPhieu;
                                    cm.Parameters["@MaChungTu"].Value = _maChungTu;
                                    cm.Parameters["@LoaiChungTu"].Value = _maLoaiChungTu;
                                    cm.Parameters["@UserID"].Value = ERP_Library.Security.CurrentUser.Info.UserID;
                                    cm.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        break;
                    case 112: //thù lao nhan vien ngoai dai

                        cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanThuLaoCTV";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", SqlDbType.Int);
                        cm.Parameters.Add("@MaNganHang", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@TuNgay", SqlDbType.DateTime);
                        cm.Parameters.AddWithValue("@DenNgay", SqlDbType.DateTime);
                        cm.Parameters.AddWithValue("@MaChuongTrinh", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDatabaseGui", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDatabaseNhan", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDeNghi", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaChungTu", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@LoaiChungTu", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                        //cm.Parameters.AddWithValue("@TuNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["TuNgay"].ToString(), "dd/MM/yyyy", null));
                        //cm.Parameters.AddWithValue("@DenNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["DenNgay"].ToString(), "dd/MM/yyyy", null));
                        //cm.Parameters.AddWithValue("@MaChuongTrinh", ds.Tables["ChonThuLao"].Rows[0]["MaChuongTrinh"]);
                        //cm.Parameters.AddWithValue("@MaDatabaseGui", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseGui"]);
                        //cm.Parameters.AddWithValue("@MaDatabaseNhan", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseNhan"]);
                        //cm.Parameters.AddWithValue("@MaDeNghi", _maPhieu);
                        //cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                        //cm.Parameters.AddWithValue("@LoaiChungTu", _maLoaiChungTu);
                        //cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        foreach (DataRow dr in ds.Tables["ChonThuLao"].Rows)
                        {
                            if (Convert.ToInt32(dr["MaNganHang"].ToString()) != 0)
                            {
                                try
                                {
                                    cm.Parameters["@MaNganHang"].Value = Convert.ToInt32(dr["MaNganHang"].ToString());
                                    cm.Parameters["@MaKyTinhLuong"].Value = Convert.ToInt32(dr["MaKyTinhLuong"].ToString());
                                    cm.Parameters["@TuNgay"].Value = DateTime.ParseExact(dr["TuNgay"].ToString(), "dd/MM/yyyy", null);
                                    cm.Parameters["@DenNgay"].Value = DateTime.ParseExact(dr["DenNgay"].ToString(), "dd/MM/yyyy", null);
                                    cm.Parameters["@MaChuongTrinh"].Value = Convert.ToInt32(dr["MaChuongTrinh"].ToString());
                                    cm.Parameters["@MaDatabaseGui"].Value = Convert.ToInt32(dr["MaDatabaseGui"].ToString());
                                    cm.Parameters["@MaDatabaseNhan"].Value = Convert.ToInt32(dr["MaDatabaseNhan"].ToString());
                                    cm.Parameters["@MaDeNghi"].Value = _maPhieu;
                                    cm.Parameters["@MaChungTu"].Value = _maChungTu;
                                    cm.Parameters["@LoaiChungTu"].Value = _maLoaiChungTu;
                                    cm.Parameters["@UserID"].Value = ERP_Library.Security.CurrentUser.Info.UserID;
                                    cm.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        break;
                    case 113: //thù lao nhan vien ngoai dai

                        cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanThuLaoCTV";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", SqlDbType.Int);
                        cm.Parameters.Add("@MaNganHang", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@TuNgay", SqlDbType.DateTime);
                        cm.Parameters.AddWithValue("@DenNgay", SqlDbType.DateTime);
                        cm.Parameters.AddWithValue("@MaChuongTrinh", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDatabaseGui", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDatabaseNhan", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaDeNghi", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@MaChungTu", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@LoaiChungTu", SqlDbType.Int);
                        cm.Parameters.AddWithValue("@UserID", SqlDbType.Int);
                        //cm.Parameters.AddWithValue("@TuNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["TuNgay"].ToString(), "dd/MM/yyyy", null));
                        //cm.Parameters.AddWithValue("@DenNgay", DateTime.ParseExact(ds.Tables["ChonThuLao"].Rows[0]["DenNgay"].ToString(), "dd/MM/yyyy", null));
                        //cm.Parameters.AddWithValue("@MaChuongTrinh", ds.Tables["ChonThuLao"].Rows[0]["MaChuongTrinh"]);
                        //cm.Parameters.AddWithValue("@MaDatabaseGui", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseGui"]);
                        //cm.Parameters.AddWithValue("@MaDatabaseNhan", ds.Tables["ChonThuLao"].Rows[0]["MaDatabaseNhan"]);
                        //cm.Parameters.AddWithValue("@MaDeNghi", _maPhieu);
                        //cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                        //cm.Parameters.AddWithValue("@LoaiChungTu", _maLoaiChungTu);
                        //cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        foreach (DataRow dr in ds.Tables["ChonThuLao"].Rows)
                        {
                            if (Convert.ToInt32(dr["MaNganHang"].ToString()) != 0)
                            {
                                try
                                {
                                    cm.Parameters["@MaNganHang"].Value = Convert.ToInt32(dr["MaNganHang"].ToString());
                                    cm.Parameters["@MaKyTinhLuong"].Value = Convert.ToInt32(dr["MaKyTinhLuong"].ToString());
                                    cm.Parameters["@TuNgay"].Value = DateTime.ParseExact(dr["TuNgay"].ToString(), "dd/MM/yyyy", null);
                                    cm.Parameters["@DenNgay"].Value = DateTime.ParseExact(dr["DenNgay"].ToString(), "dd/MM/yyyy", null);
                                    cm.Parameters["@MaChuongTrinh"].Value = Convert.ToInt32(dr["MaChuongTrinh"].ToString());
                                    cm.Parameters["@MaDatabaseGui"].Value = Convert.ToInt32(dr["MaDatabaseGui"].ToString());
                                    cm.Parameters["@MaDatabaseNhan"].Value = Convert.ToInt32(dr["MaDatabaseNhan"].ToString());
                                    cm.Parameters["@MaDeNghi"].Value = _maPhieu;
                                    cm.Parameters["@MaChungTu"].Value = _maChungTu;
                                    cm.Parameters["@LoaiChungTu"].Value = _maLoaiChungTu;
                                    cm.Parameters["@UserID"].Value = ERP_Library.Security.CurrentUser.Info.UserID;
                                    cm.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        break;
                    case 7://phụ cấp
                        cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanPhuCap";
                        cm.Parameters.AddWithValue("@MaKyTinhLuong", ds.Tables["ChonPhuCap"].Rows[0]["MaKyTinhLuong"]);
                        cm.Parameters.AddWithValue("@MaKyPhuCap", ds.Tables["ChonPhuCap"].Rows[0]["MaKyPhuCap"]);
                        cm.Parameters.AddWithValue("@MaNganHang", ds.Tables["ChonPhuCap"].Rows[0]["MaNganHang"]);
                        cm.Parameters.AddWithValue("@MaNhomPhuCap", ds.Tables["ChonPhuCap"].Rows[0]["MaNhomPhuCap"]);
                        cm.Parameters.AddWithValue("@MaLoaiPhuCap", ds.Tables["ChonPhuCap"].Rows[0]["MaLoaiPhuCap"]);
                        break;
                    case 201://phụ cấp
                        cm.CommandText = "spd_ChungTuGoc_ChuyenKhoanHoaDon_DichVu";
                        cm.Parameters.AddWithValue("@MaDoiTuong", ds.Tables["HoaDon_DichVu"].Rows[0]["MaDoiTuong"]);
                        cm.Parameters.AddWithValue("@TenDoiTuong", ds.Tables["HoaDon_DichVu"].Rows[0]["TenDoiTuong"]);
                        cm.Parameters.AddWithValue("@SoDienThoai", ds.Tables["HoaDon_DichVu"].Rows[0]["SoDienThoai"]);
                        cm.Parameters.AddWithValue("@CMND", ds.Tables["HoaDon_DichVu"].Rows[0]["CMND"]);
                        cm.Parameters.AddWithValue("@MaSoThue", ds.Tables["HoaDon_DichVu"].Rows[0]["MaSoThue"]);
                        cm.Parameters.AddWithValue("@MaNganHang", ds.Tables["HoaDon_DichVu"].Rows[0]["MaNganHang"]);
                        cm.Parameters.AddWithValue("@SoTaiKhoan", ds.Tables["HoaDon_DichVu"].Rows[0]["SoTaiKhoan"]);
                        cm.Parameters.AddWithValue("@TenNganHang", ds.Tables["HoaDon_DichVu"].Rows[0]["TenNganHang"]);
                        cm.Parameters.AddWithValue("@SoTien", _soTien);
                        cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
                       break;
                    default:
                        break;
                }
                if (!String.IsNullOrEmpty(cm.CommandText) && _maLoaiChungTu != 109 && !String.IsNullOrEmpty(cm.CommandText) && _maLoaiChungTu != 111 && !String.IsNullOrEmpty(cm.CommandText) && _maLoaiChungTu != 112 && !String.IsNullOrEmpty(cm.CommandText) && _maLoaiChungTu != 113)
                {
                    cm.Parameters.AddWithValue("@MaDeNghi", _maPhieu);
                    cm.Parameters.AddWithValue("@MaChungTu", _maChungTu);
                    cm.Parameters.AddWithValue("@LoaiChungTu", _maLoaiChungTu);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.ExecuteNonQuery();
                }
            }
        }
    }
}
