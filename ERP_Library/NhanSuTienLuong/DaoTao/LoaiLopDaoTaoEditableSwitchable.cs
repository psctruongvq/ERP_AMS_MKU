using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;
using System.ComponentModel;

namespace ERP_Library
{
    [Serializable()]
    public class LoaiLopDaoTao : Csla.BusinessBase<LoaiLopDaoTao>
    {
        #region Business Properties and Methods

        //declare members
        private int _maLoaiLop = 0;
        private string _maQL = string.Empty;
        private string _tenLoaiLop = string.Empty;
        private int _loaiVanBang = 0;
        private int _maQuocGiaCap = 0;
        private int _maTruongDaoTao = 0;
        private int _maChuyenNganhDaoTao = 0;
        private byte _vanbangChungchi = 0;
        private byte _trongnuocNgoainuoc = 0;
        private int _maDonViDaoTao = 0;
        private int _loai = 0;//
        private int _maNgoaiNgu = 0;//
        private int _maTrinhDoNN = 0;//
        private int _maTrinhDoTH = 0;//
        private int _maLyLuanCT = 0;//
        private int _maQuanLyNhaNuoc = 0;//

        [System.ComponentModel.DataObjectField(true, true)]

        [DisplayName("Mã ID")]
        public int MaLoaiLop
        {
            get
            {
                CanReadProperty("MaLoaiLop", true);
                return _maLoaiLop;
            }
        }

        [DisplayName("Mã quản lý")]
        public string MaQL
        {
            get
            {
                CanReadProperty("MaQL", true);
                return _maQL;
            }
            set
            {
                CanWriteProperty("MaQL", true);
                if (value == null) value = string.Empty;
                if (!_maQL.Equals(value))
                {
                    _maQL = value;
                    PropertyHasChanged("MaQL");
                }
            }
        }

        [DisplayName("Tên Lớp học")]
        public string TenLoaiLop
        {
            get
            {
                CanReadProperty("TenLoaiLop", true);
                return _tenLoaiLop;
            }
            set
            {
                CanWriteProperty("TenLoaiLop", true);
                if (value == null) value = string.Empty;
                if (!_tenLoaiLop.Equals(value))
                {
                    _tenLoaiLop = value;
                    PropertyHasChanged("TenLoaiLop");
                }
            }
        }

        [DisplayName("Văn bằng/Chứng chỉ")]
        public byte VanbangChungChi
        {
            get
            {
                CanReadProperty("VanbangChungChi", true);
                return _vanbangChungchi;
            }
            set
            {
                CanWriteProperty("VanbangChungChi", true);
                if (!_vanbangChungchi.Equals(value))
                {
                    _vanbangChungchi = value;
                    PropertyHasChanged("VanbangChungChi");
                }
            }
        }
        [DisplayName("Văn bằng/Chứng chỉ")]
        public string VanbangChungChiString
        {
            get
            {
                if (_vanbangChungchi == 1)
                    return "Văn bằng";
                else if (_vanbangChungchi == 2)
                    return "Chứng chỉ";
                return "";
            }
        }


        [DisplayName("Loại Văn bằng/Chứng chỉ")]
        public int LoaiVanBang
        {
            get
            {
                CanReadProperty("LoaiVanBang", true);
                return _loaiVanBang;
            }
            set
            {
                CanWriteProperty("LoaiVanBang", true);
                if (!_loaiVanBang.Equals(value))
                {
                    _loaiVanBang = value;
                    PropertyHasChanged("LoaiVanBang");
                }
            }
        }
        [DisplayName("Loại Văn bằng/Chứng chỉ")]
        public string LoaiVanBangString
        {
            get
            {
                if (_loaiVanBang != 0)
                    return TrinhDoHocVanClass.GetTrinhDoHocVanClass(_loaiVanBang).TrinhDoHocVan;
                return "";
            }
        }

        [DisplayName("Quốc gia cấp")]
        public int MaQuocGiaCap
        {
            get
            {
                CanReadProperty("MaQuocGiaCap", true);
                return _maQuocGiaCap;
            }
            set
            {
                CanWriteProperty("MaQuocGiaCap", true);
                if (!_maQuocGiaCap.Equals(value))
                {
                    _maQuocGiaCap = value;
                    PropertyHasChanged("MaQuocGiaCap");
                }
            }
        }
        [DisplayName("Quốc gia cấp")]
        public string QuocGiaCap
        {
            get
            {
                if (_maQuocGiaCap != 0)
                    return QuocGia.GetQuocGia(_maQuocGiaCap).TenQuocGia;
                return "";
            }
        }

        [DisplayName("Trường đào tạo")]
        public int MaTruongDaoTao
        {
            get
            {
                CanReadProperty("MaTruongDaoTao", true);
                return _maTruongDaoTao;
            }
            set
            {
                CanWriteProperty("MaTruongDaoTao", true);
                if (!_maTruongDaoTao.Equals(value))
                {
                    _maTruongDaoTao = value;
                    PropertyHasChanged("MaTruongDaoTao");
                }
            }
        }
        [DisplayName("Trường đào tạo")]
        public string TenTruongDaoTao
        {
            get
            {
                if (_maTruongDaoTao != 0)
                    return TruongDaoTao.GetTruongDaoTao(_maTruongDaoTao).TenTruongDaoTao;
                return "";
            }
        }


        [DisplayName("Chuyên ngành đào tạo")]
        public int MaChuyenNganhDaoTao
        {
            get
            {
                CanReadProperty("MaChuyenNganhDaoTao", true);
                return _maChuyenNganhDaoTao;
            }
            set
            {
                CanWriteProperty("MaChuyenNganhDaoTao", true);
                if (!_maChuyenNganhDaoTao.Equals(value))
                {
                    _maChuyenNganhDaoTao = value;
                    PropertyHasChanged("MaChuyenNganhDaoTao");
                }
            }
        }
        [DisplayName("Chuyên ngành đào tạo")]
        public string TenChuyenNganhDaoTao
        {
            get
            {
                if (_maChuyenNganhDaoTao != 0)
                    return ChuyenNganhDaoTaoClass.GetChuyenNganhDaoTaoClass(_maChuyenNganhDaoTao).ChuyenNganhDaoTao;
                return "";
            }
        }

        [DisplayName("Đào tạo trong nước/ ngoài nước")]
        public byte TrongnuocNgoainuoc
        {
            get
            {
                CanReadProperty("TrongnuocNgoainuoc", true);
                return _trongnuocNgoainuoc;
            }
            set
            {
                CanWriteProperty("TrongnuocNgoainuoc", true);
                if (!_trongnuocNgoainuoc.Equals(value))
                {
                    _trongnuocNgoainuoc = value;
                    PropertyHasChanged("TrongnuocNgoainuoc");
                }
            }
        }
        [DisplayName("Đào tạo")]
        public string TrongnuocNgoainuocString
        {
            get
            {
                if (_trongnuocNgoainuoc == 1)
                    return "Trong nước";
                else if (_trongnuocNgoainuoc == 2)
                    return "Ngoài nước";
                return "";
            }
        }

        public int MaDonViDaoTao
        {
            get
            {
                CanReadProperty("MaDonViDaoTao", true);
                return _maDonViDaoTao;
            }
            set
            {
                CanWriteProperty("MaDonViDaoTao", true);
                if (!_maDonViDaoTao.Equals(value))
                {
                    _maDonViDaoTao = value;
                    PropertyHasChanged("MaDonViDaoTao");
                }
            }
        }
        public string TenDonViDaoTao
        {
            get
            {
                if (_maDonViDaoTao != 0)
                    return DonViDaoTao.GetDonViDaoTao(_maDonViDaoTao).TenDonViDaoTao;
                return "";
            }
        }

        public int Loai
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

        public int MaNgoaiNgu
        {
            get
            {
                CanReadProperty("MaNgoaiNgu", true);
                return _maNgoaiNgu;
            }
            set
            {
                CanWriteProperty("MaNgoaiNgu", true);
                if (!_maNgoaiNgu.Equals(value))
                {
                    _maNgoaiNgu = value;
                    PropertyHasChanged("MaNgoaiNgu");
                }
            }
        }

        public int MaTrinhDoNN
        {
            get
            {
                CanReadProperty("MaTrinhDoNN", true);
                return _maTrinhDoNN;
            }
            set
            {
                CanWriteProperty("MaTrinhDoNN", true);
                if (!_maTrinhDoNN.Equals(value))
                {
                    _maTrinhDoNN = value;
                    PropertyHasChanged("MaTrinhDoNN");
                }
            }
        }

        public int MaTrinhDoTH
        {
            get
            {
                CanReadProperty("MaTrinhDoTH", true);
                return _maTrinhDoTH;
            }
            set
            {
                CanWriteProperty("MaTrinhDoTH", true);
                if (!_maTrinhDoTH.Equals(value))
                {
                    _maTrinhDoTH = value;
                    PropertyHasChanged("MaTrinhDoTH");
                }
            }
        }

        public int MaLyLuanCT
        {
            get
            {
                CanReadProperty("MaLyLuanCT", true);
                return _maLyLuanCT;
            }
            set
            {
                CanWriteProperty("MaLyLuanCT", true);
                if (!_maLyLuanCT.Equals(value))
                {
                    _maLyLuanCT = value;
                    PropertyHasChanged("MaLyLuanCT");
                }
            }
        }
        public int MaQuanLyNhaNuoc
        {
            get
            {
                CanReadProperty("MaQuanLyNhaNuoc", true);
                return _maQuanLyNhaNuoc;
            }
            set
            {
                CanWriteProperty("MaQuanLyNhaNuoc", true);
                if (!_maQuanLyNhaNuoc.Equals(value))
                {
                    _maQuanLyNhaNuoc = value;
                    PropertyHasChanged("MaQuanLyNhaNuoc");
                }
            }
        }

        protected override object GetIdValue()
        {
            return _maLoaiLop;
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
            //TODO: Define authorization rules in LoaiLopDaoTao
            //AuthorizationRules.AllowRead("MaLoaiLop", "LoaiLopDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("MaQL", "LoaiLopDaoTaoReadGroup");
            //AuthorizationRules.AllowRead("TenLoaiLop", "LoaiLopDaoTaoReadGroup");

            //AuthorizationRules.AllowWrite("MaQL", "LoaiLopDaoTaoWriteGroup");
            //AuthorizationRules.AllowWrite("TenLoaiLop", "LoaiLopDaoTaoWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in LoaiLopDaoTao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiLopDaoTaoViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in LoaiLopDaoTao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiLopDaoTaoAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in LoaiLopDaoTao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiLopDaoTaoEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in LoaiLopDaoTao
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("LoaiLopDaoTaoDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private LoaiLopDaoTao()
        { /* require use of factory method */ }

        private LoaiLopDaoTao(string tenLoaiLopHoc)//Bosung
        {
            _tenLoaiLop = tenLoaiLopHoc;
        }

        public static LoaiLopDaoTao NewLoaiLopDaoTao()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiLopDaoTao");
            return DataPortal.Create<LoaiLopDaoTao>();
        }
        public static LoaiLopDaoTao NewLoaiLopDaoTao(string tenLoaiLopHoc)//Bosung
        {
            return new LoaiLopDaoTao(tenLoaiLopHoc);
        }

        public static LoaiLopDaoTao GetLoaiLopDaoTao(int maLoaiLop)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a LoaiLopDaoTao");
            return DataPortal.Fetch<LoaiLopDaoTao>(new Criteria(maLoaiLop));
        }

        public static void DeleteLoaiLopDaoTao(int maLoaiLop)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiLopDaoTao");
            DataPortal.Delete(new Criteria(maLoaiLop));
        }

        public static void DeleteLoaiLopDaoTao(LoaiLopDaoTao loaiLopHoc)
        {
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeletetblnsLoaiLopDaoTao";

                        cm.Parameters.AddWithValue("@MaLoaiLop", loaiLopHoc.MaLoaiLop);

                        cm.ExecuteNonQuery();
                    }//using
                    tr.Commit();
                }
                catch (Exception ex)
                {

                }

            }//using
        }

        public override LoaiLopDaoTao Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a LoaiLopDaoTao");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a LoaiLopDaoTao");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a LoaiLopDaoTao");

            return base.Save();
        }

        #region Bo Sung


        public static bool KiemTraLoaiLopHocdaDung(int maLoaiLop)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckLoaiLopHocdadung";
                    cm.Parameters.AddWithValue("@MaLoaiLop", maLoaiLop);
                    SqlParameter outPara = new SqlParameter("@DaDung", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }//end function

        public static bool KiemTraTrungMaQlLoaiLopDaoTao(int maLoaiLop, string maQl)
        {
            bool result = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "Spd_CheckTrungMaQlLopHocDaoTao";
                    cm.Parameters.AddWithValue("@MaLoaiLop", maLoaiLop);
                    cm.Parameters.AddWithValue("@MaQL", maQl);
                    SqlParameter outPara = new SqlParameter("@Trung", SqlDbType.Bit);
                    outPara.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(outPara);
                    cm.ExecuteNonQuery();
                    result = (bool)outPara.Value;
                }
            }//end using
            return result;
        }
        #endregion


        #endregion //Factory Methods

        #region Child Factory Methods
        internal static LoaiLopDaoTao NewLoaiLopDaoTaoChild()
        {
            LoaiLopDaoTao child = new LoaiLopDaoTao();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static LoaiLopDaoTao GetLoaiLopDaoTao(SafeDataReader dr)
        {
            LoaiLopDaoTao child = new LoaiLopDaoTao();
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
            public int MaLoaiLop;

            public Criteria(int maLoaiLop)
            {
                this.MaLoaiLop = maLoaiLop;
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
                cm.CommandText = "spd_SelecttblnsLoaiLopDaoTao";

                cm.Parameters.AddWithValue("@MaLoaiLop", criteria.MaLoaiLop);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
                    //dr.Read();
                    //FetchObject(dr);
                    //ValidationRules.CheckRules();

                    ////load child object(s)
                    //FetchChildren(dr);
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Insert
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                SqlTransaction tr;
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {

                    ExecuteInsert(tr);

                    //update child object(s)
                    UpdateChildren(tr);
                    tr.Commit();
                }
                catch (Exception ex)
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                SqlTransaction tr;
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
                catch (Exception ex)
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
            DataPortal_Delete(new Criteria(_maLoaiLop));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                SqlTransaction tr;
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    ExecuteDelete(tr, criteria);
                    tr.Commit();
                }
                catch (Exception ex)
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
                cm.CommandText = "spd_DeletetblnsLoaiLopDaoTao";

                cm.Parameters.AddWithValue("@MaLoaiLop", criteria.MaLoaiLop);

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
            _maLoaiLop = dr.GetInt32("MaLoaiLop");
            _maQL = dr.GetString("MaQL");
            _tenLoaiLop = dr.GetString("TenLoaiLop");

            _vanbangChungchi = dr.GetByte("VanBang_ChungChi");
            _loaiVanBang = dr.GetInt32("LoaiVanBang");
            _maQuocGiaCap = dr.GetInt32("MaQuocGiaCap");
            _maTruongDaoTao = dr.GetInt32("MaTruongDaoTao");
            _maChuyenNganhDaoTao = dr.GetInt32("MaChuyenNganhDaoTao");
            _trongnuocNgoainuoc = dr.GetByte("TrongNuoc_NgoaiNuoc");
            _maDonViDaoTao = dr.GetInt32("MaDonViDaoTao");
            _loai = dr.GetInt32("Loai");//
            _maNgoaiNgu = dr.GetInt32("MaNgoaiNgu");//
            _maTrinhDoNN = dr.GetInt32("MaTrinhDoNN");//
            _maTrinhDoTH = dr.GetInt32("MaTrinhDoTH");//
            _maLyLuanCT = dr.GetInt32("MaLyLuanCT");//
            _maQuanLyNhaNuoc = dr.GetInt32("MaQuanLyNhaNuoc");//
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
                cm.CommandText = "spd_InserttblnsLoaiLopDaoTao";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maLoaiLop = (int)cm.Parameters["@MaLoaiLop"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_tenLoaiLop.Length > 0)
                cm.Parameters.AddWithValue("@TenLoaiLop", _tenLoaiLop);
            else
                cm.Parameters.AddWithValue("@TenLoaiLop", DBNull.Value);


            if (_vanbangChungchi != 0)
                cm.Parameters.AddWithValue("@VanBang_ChungChi", _vanbangChungchi);
            else
                cm.Parameters.AddWithValue("@VanBang_ChungChi", DBNull.Value);
            if (_loaiVanBang != 0)
                cm.Parameters.AddWithValue("@LoaiVanBang", _loaiVanBang);
            else
                cm.Parameters.AddWithValue("@LoaiVanBang", DBNull.Value);
            if (_maQuocGiaCap != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaCap", _maQuocGiaCap);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaCap", DBNull.Value);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
            if (_maChuyenNganhDaoTao != 0)
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
            else
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", DBNull.Value);
            if (_trongnuocNgoainuoc != 0)
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", _trongnuocNgoainuoc);
            else
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", DBNull.Value);
            if (_maDonViDaoTao != 0)
                cm.Parameters.AddWithValue("@MaDonViDaoTao", _maDonViDaoTao);
            else
                cm.Parameters.AddWithValue("@MaDonViDaoTao", DBNull.Value);

            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            if (_maNgoaiNgu != 0)
                cm.Parameters.AddWithValue("@MaNgoaiNgu", _maNgoaiNgu);
            else
                cm.Parameters.AddWithValue("@MaNgoaiNgu", DBNull.Value);
            if (_maTrinhDoNN != 0)
                cm.Parameters.AddWithValue("@MaTrinhDoNN", _maTrinhDoNN);
            else
                cm.Parameters.AddWithValue("@MaTrinhDoNN", DBNull.Value);
            if (_maTrinhDoTH != 0)
                cm.Parameters.AddWithValue("@MaTrinhDoTH", _maTrinhDoTH);
            else
                cm.Parameters.AddWithValue("@MaTrinhDoTH", DBNull.Value);
            if (_maLyLuanCT != 0)
                cm.Parameters.AddWithValue("@MaLyLuanCT", _maLyLuanCT);
            else
                cm.Parameters.AddWithValue("@MaLyLuanCT", DBNull.Value);
            if (_maQuanLyNhaNuoc != 0)
                cm.Parameters.AddWithValue("@MaQuanLyNhaNuoc", _maQuanLyNhaNuoc);
            else
                cm.Parameters.AddWithValue("@MaQuanLyNhaNuoc", DBNull.Value);

            cm.Parameters.AddWithValue("@MaLoaiLop", _maLoaiLop);
            cm.Parameters["@MaLoaiLop"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblnsLoaiLopDaoTao";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaLoaiLop", _maLoaiLop);
            if (_maQL.Length > 0)
                cm.Parameters.AddWithValue("@MaQL", _maQL);
            else
                cm.Parameters.AddWithValue("@MaQL", DBNull.Value);
            if (_tenLoaiLop.Length > 0)
                cm.Parameters.AddWithValue("@TenLoaiLop", _tenLoaiLop);
            else
                cm.Parameters.AddWithValue("@TenLoaiLop", DBNull.Value);

            if (_vanbangChungchi != 0)
                cm.Parameters.AddWithValue("@VanBang_ChungChi", _vanbangChungchi);
            else
                cm.Parameters.AddWithValue("@VanBang_ChungChi", DBNull.Value);
            if (_loaiVanBang != 0)
                cm.Parameters.AddWithValue("@LoaiVanBang", _loaiVanBang);
            else
                cm.Parameters.AddWithValue("@LoaiVanBang", DBNull.Value);
            if (_maQuocGiaCap != 0)
                cm.Parameters.AddWithValue("@MaQuocGiaCap", _maQuocGiaCap);
            else
                cm.Parameters.AddWithValue("@MaQuocGiaCap", DBNull.Value);
            if (_maTruongDaoTao != 0)
                cm.Parameters.AddWithValue("@MaTruongDaoTao", _maTruongDaoTao);
            else
                cm.Parameters.AddWithValue("@MaTruongDaoTao", DBNull.Value);
            if (_maChuyenNganhDaoTao != 0)
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", _maChuyenNganhDaoTao);
            else
                cm.Parameters.AddWithValue("@MaChuyenNganhDaoTao", DBNull.Value);
            if (_trongnuocNgoainuoc != 0)
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", _trongnuocNgoainuoc);
            else
                cm.Parameters.AddWithValue("@TrongNuoc_NgoaiNuoc", DBNull.Value);
            if (_maDonViDaoTao != 0)
                cm.Parameters.AddWithValue("@MaDonViDaoTao", _maDonViDaoTao);
            else
                cm.Parameters.AddWithValue("@MaDonViDaoTao", DBNull.Value);

            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            if (_maNgoaiNgu != 0)
                cm.Parameters.AddWithValue("@MaNgoaiNgu", _maNgoaiNgu);
            else
                cm.Parameters.AddWithValue("@MaNgoaiNgu", DBNull.Value);
            if (_maTrinhDoNN != 0)
                cm.Parameters.AddWithValue("@MaTrinhDoNN", _maTrinhDoNN);
            else
                cm.Parameters.AddWithValue("@MaTrinhDoNN", DBNull.Value);
            if (_maTrinhDoTH != 0)
                cm.Parameters.AddWithValue("@MaTrinhDoTH", _maTrinhDoTH);
            else
                cm.Parameters.AddWithValue("@MaTrinhDoTH", DBNull.Value);
            if (_maLyLuanCT != 0)
                cm.Parameters.AddWithValue("@MaLyLuanCT", _maLyLuanCT);
            else
                cm.Parameters.AddWithValue("@MaLyLuanCT", DBNull.Value);
            if (_maQuanLyNhaNuoc != 0)
                cm.Parameters.AddWithValue("@MaQuanLyNhaNuoc", _maQuanLyNhaNuoc);
            else
                cm.Parameters.AddWithValue("@MaQuanLyNhaNuoc", DBNull.Value);
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

            ExecuteDelete(tr, new Criteria(_maLoaiLop));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
