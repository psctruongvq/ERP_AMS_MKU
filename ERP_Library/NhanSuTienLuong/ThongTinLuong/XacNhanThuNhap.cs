
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class XacNhanThuNhap : Csla.BusinessBase<XacNhanThuNhap>
    {
        #region Business Properties and Methods

        //declare members
        internal int _maXacNhan = 0;
        private DateTime _ngayLap = DateTime.Today;
        private int _maBoPhan = 0;
        private int _maNhanVien = 0;
        private string _loaiNV = "";
        private int _nguoiLap = 0;
        private int _phuTrachTaiChinh = 0;
        private int _phuTrachDonVi = 0;
        private string _veViec = "";
        private string _chucDanh = "";
        private bool _daThanhLy = false;

        //declare child member(s)
        private XacNhanThuNhap_ChiTietList _chiTiet = XacNhanThuNhap_ChiTietList.NewXacNhanThuNhap_ChiTietList();

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaXacNhan
        {
            get
            {
                return _maXacNhan;
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

        public int MaNhanVien
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
                    CapNhatChucVuTenHD(MaNhanVien);
                }
            }
        }

        public string LoaiNV
        {
            get
            {
                return _loaiNV;
            }
            set
            {
                if (!_loaiNV.Equals(value))
                {
                    _loaiNV = value;
                    PropertyHasChanged("LoaiNV");
                }
            }
        }

        public int NguoiLap
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

        public int PhuTrachTaiChinh
        {
            get
            {
                return _phuTrachTaiChinh;
            }
            set
            {
                if (!_phuTrachTaiChinh.Equals(value))
                {
                    _phuTrachTaiChinh = value;
                    PropertyHasChanged("PhuTrachTaiChinh");
                }
            }
        }

        public int PhuTrachDonVi
        {
            get
            {
                return _phuTrachDonVi;
            }
            set
            {
                if (!_phuTrachDonVi.Equals(value))
                {
                    _phuTrachDonVi = value;
                    PropertyHasChanged("PhuTrachDonVi");
                }
            }
        }

        public string VeViec
        {
            get
            {
                return _veViec;
            }
            set
            {
                if (!_veViec.Equals(value))
                {
                    _veViec = value;
                    PropertyHasChanged("VeViec");
                }
            }
        }

        public string ChucDanh
        {
            get
            {
                return _chucDanh;
            }
            set
            {
                if (!_chucDanh.Equals(value))
                {
                    _chucDanh = value;
                    PropertyHasChanged("ChucDanh");
                }
            }
        }

        public bool DaThanhLy
        {
            get
            {
                return _daThanhLy;
            }
            set
            {
                if (!_daThanhLy.Equals(value))
                {
                    _daThanhLy = value;
                    PropertyHasChanged();
                }
            }
        }

        public XacNhanThuNhap_ChiTietList ChiTiet
        {
            get
            {
                return _chiTiet;
            }
        }
        public void CapNhatChucVuTenHD(long MaNhanVien)
        {
            //cập nhật lại tên chức vụ và hợp đồng nhân viên
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandText = "Select tblnsChucDanh.TenChucDanh as TenChucVu, B.TenHopDong From tblnsNhanVien A Inner Join tblnsNhanVien_Loai B On A.LoaiNV = B.MaLoaiNhanVien left join tblnsChucDanh on A.MaChucDanh=tblnsChucDanh.MaChucDanh Where MaNhanVien=@MaNhanVien";
                cm.CommandType = CommandType.Text;
                cm.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
                SafeDataReader dr = new SafeDataReader(cm.ExecuteReader());
                if (dr.Read())
                {
                    ChucDanh = dr.GetString("TenChucVu");
                    LoaiNV = dr.GetString("TenHopDong");
                }
                cn.Close();
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _chiTiet.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _chiTiet.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maXacNhan;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("NgayLap", "Chưa nhập ngày lập"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("VeViec", "Chưa nhập mục đích xác nhận về việc gì"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaBoPhan", "Chưa nhập bộ phận"));
            ValidationRules.AddRule(CommonRulesEx.ValueRequire, new CommonRulesEx.RequireArgs("MaNhanVien", "Chưa nhập nhân viên"));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Factory Methods
        private XacNhanThuNhap()
        { /* require use of factory method */ }

        public static XacNhanThuNhap NewXacNhanThuNhap()
        {
            return DataPortal.Create<XacNhanThuNhap>();
        }

        public static XacNhanThuNhap GetXacNhanThuNhap(int maXacNhan)
        {
            return DataPortal.Fetch<XacNhanThuNhap>(new Criteria(maXacNhan));
        }

        public static void DeleteXacNhanThuNhap(int maXacNhan)
        {
            DataPortal.Delete(new Criteria(maXacNhan));
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static XacNhanThuNhap NewXacNhanThuNhapChild()
        {
            XacNhanThuNhap child = new XacNhanThuNhap();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            child._chiTiet._parent = child;
            return child;
        }

        internal static XacNhanThuNhap GetXacNhanThuNhap(SafeDataReader dr)
        {
            XacNhanThuNhap child = new XacNhanThuNhap();
            child.MarkAsChild();
            child.Fetch(dr);
            child._chiTiet._parent = child;
            return child;
        }
        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaXacNhan;

            public Criteria(int maXacNhan)
            {
                this.MaXacNhan = maXacNhan;
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
                cm.CommandText = "spd_Select_XacNhanThuNhap";

                cm.Parameters.AddWithValue("@MaXacNhan", criteria.MaXacNhan);

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
            DataPortal_Delete(new Criteria(_maXacNhan));
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
                cm.CommandText = "spd_Delete_XacNhanThuNhap";

                cm.Parameters.AddWithValue("@MaXacNhan", criteria.MaXacNhan);

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
            _maXacNhan = dr.GetInt32("MaXacNhan");
            _ngayLap = dr.GetDateTime("NgayLap");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maNhanVien = dr.GetInt32("MaNhanVien");
            _loaiNV = dr.GetString("LoaiNV");
            _nguoiLap = dr.GetInt32("NguoiLap");
            _phuTrachTaiChinh = dr.GetInt32("PhuTrachTaiChinh");
            _phuTrachDonVi = dr.GetInt32("PhuTrachDonVi");
            _veViec = dr.GetString("VeViec");
            _chucDanh = dr.GetString("ChucDanh");
            _daThanhLy = dr.GetBoolean("DaThanhLy");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            if (this.IsChild)
            {
                _chiTiet = XacNhanThuNhap_ChiTietList.GetXacNhanThuNhap_ChiTietList(_maXacNhan);
            }
            else
            {
                dr.NextResult();
                _chiTiet = XacNhanThuNhap_ChiTietList.GetXacNhanThuNhap_ChiTietList(dr);
            }
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
                cm.CommandText = "spd_Insert_XacNhanThuNhap";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maXacNhan = (int)cm.Parameters["@MaXacNhan"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            cm.Parameters.AddWithValue("@PhuTrachTaiChinh", _phuTrachTaiChinh);
            cm.Parameters.AddWithValue("@PhuTrachDonVi", _phuTrachDonVi);
            cm.Parameters.AddWithValue("@VeViec", _veViec);
            cm.Parameters.AddWithValue("@ChucDanh", _chucDanh);
            cm.Parameters.AddWithValue("@DaThanhLy", _daThanhLy);
            cm.Parameters.AddWithValue("@MaXacNhan", _maXacNhan);
            cm.Parameters["@MaXacNhan"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_Update_XacNhanThuNhap";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaXacNhan", _maXacNhan);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap);
            cm.Parameters.AddWithValue("@MaBoPhan", _maBoPhan);
            cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            cm.Parameters.AddWithValue("@LoaiNV", _loaiNV);
            cm.Parameters.AddWithValue("@NguoiLap", _nguoiLap);
            cm.Parameters.AddWithValue("@PhuTrachTaiChinh", _phuTrachTaiChinh);
            cm.Parameters.AddWithValue("@PhuTrachDonVi", _phuTrachDonVi);
            cm.Parameters.AddWithValue("@VeViec", _veViec);
            cm.Parameters.AddWithValue("@ChucDanh", _chucDanh);
            cm.Parameters.AddWithValue("@DaThanhLy", _daThanhLy);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _chiTiet.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_maXacNhan));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
