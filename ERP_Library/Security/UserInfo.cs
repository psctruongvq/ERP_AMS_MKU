
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library.Security
{
    [Serializable()]
    public class UserInfo : Csla.ReadOnlyBase<UserInfo>
    {
        #region Business Properties and Methods

        //declare members
        private int _userID = 0;
        private string _tenDangNhap = string.Empty;
        private long _maNhanVien = 0;
        private int _groupID = 0;
        private string _tenGroup = string.Empty;
        private int _maBoPhan = 0;
        private string _tenBoPhan = string.Empty;
        private string _maBoPhanQL = string.Empty;
        private int _maCongTy = 0;
        private int _maBoPhanCha = 0;
        private string _maQLUser = "";
        private string _tenThuTruong = string.Empty;
        private string _tenNguoiLap = string.Empty;
        private string _tenKeToanTruong = string.Empty;
        private string _tenThuQuy = string.Empty;

        private string _emailDenTang = string.Empty;
        private string _emailGui = string.Empty;
        private string _emailHRM = string.Empty;
        private string _matKhauEmailGui = string.Empty;
        private string _maCongTyQuanLy = string.Empty;
        private bool _congThue = false;
        private bool _capNhatHoSo;
        private bool _capNhatChamCong;
        private bool _capNhatPhuCap;

        private System.Collections.Generic.List<int> _phanQuyenBoPhan = new System.Collections.Generic.List<int>();

        [System.ComponentModel.DataObjectField(true, false)]
        public int UserID
        {
            get
            {
                return _userID;
            }
        }
        public bool CongThue
        {
            get
            {
                return _congThue;
            }  
        }
        public bool CapNhatHoSo
        {
            get
            {
                return _capNhatHoSo;
            }
        }
        public bool CapNhatChamCong
        {
            get
            {
                return _capNhatChamCong;
            }
        }
        public bool CapNhatPhuCap
        {
            get
            {
                return _capNhatPhuCap;
            }
        }

        public string TenKeToanTruong
        {
            get { return _tenKeToanTruong; }

        }

        public string TenThuQuy
        {
            get { return _tenThuQuy; }

        }
        public string MaQLUser
        {
            get
            {
                return _maQLUser;
            }
        }

        public string TenDangNhap
        {
            get
            {
                return _tenDangNhap;
            }
        }

        public int MaBoPhan
        {
            get
            {
                return _maBoPhan;
            }
        }
        public int MaBoPhanCha
        {
            get
            {
                return _maBoPhanCha;
            }
        }
        public string TenBoPhan
        {
            get
            {
                return _tenBoPhan; 
            }
        }
        public long MaNhanVien
        {
            get
            {
                return _maNhanVien;
            }
        }

        public int GroupID
        {
            get
            {
                return _groupID;
            }
        }

        public string TenGroup
        {
            get
            {
                return _tenGroup;
            }
        }

        public int MaCongTy
        {
            get
            {
                return _maCongTy;
            }
        }
        public string TenThuTruong
        {
            get { return _tenThuTruong; }

        }
        public string TenNguoiLap
        {
            get { return _tenNguoiLap; }

        }
        /// <summary>
        /// Danh sách các mã bộ phận mà user được phân quyền sử dụng, kiểu List int
        /// </summary>
        public System.Collections.Generic.List<int> PhanQuyenBoPhan
        {
            get
            {
                return _phanQuyenBoPhan;
            }
        }

        public string EmailDenTang
        {
            get
            {
                return _emailDenTang;
            }
        }

        public string EmailGui
        {
            get
            {
                return _emailGui;
            }   
        }

        public string EmailHRM
        {
            get
            {
                return _emailHRM;
            }
        }

        public string MatKhauEmailGui
        {
            get
            {
                return _matKhauEmailGui;
            }
        }

        public string MaCongTyQuanLy
        {
            get
            {
                return _maCongTyQuanLy;
            }
        }

        public string MaBoPhanQL
        {
            get
            {
                return _maBoPhanQL;
            }
        }

       

        protected override object GetIdValue()
        {
            return _userID;
        }

        #endregion //Business Properties and Methods

        #region Factory Methods
        private UserInfo()
        { /* require use of factory method */ }

        public static UserInfo GetUserInfo(int userID)
        {
            return DataPortal.Fetch<UserInfo>(new Criteria(userID));
        }
        #endregion //Factory Methods


        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int UserID;

            public Criteria(int userID)
            {
                this.UserID = userID;
            }
        }

        #endregion //Criteria

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
                cm.CommandText = "app_Select_UserInfo";

                cm.Parameters.AddWithValue("@UserID", criteria.UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    FetchObject(dr);

                    //load child object(s)
                   //FetchChildren(dr);
                }
            }//using
        }

        private void FetchObject(SafeDataReader dr)
        {
            dr.Read();
            _userID = dr.GetInt32("UserID");
            _tenDangNhap = dr.GetString("TenDangNhap");
            _maNhanVien = dr.GetInt64("MaNhanVien");
            _groupID = dr.GetInt32("GroupID");
            _tenGroup = dr.GetString("TenGroup");
            _maBoPhan = dr.GetInt32("MaBoPhan");
            _maBoPhanQL = dr.GetString("MaBoPhanQL");
            _maBoPhanCha = dr.GetInt32("MaBoPhanCha");
            _tenBoPhan = dr.GetString("TenBoPhan");
            _maCongTy = dr.GetInt32("MaCongTy");
            _maQLUser = dr.GetString("MaQLUser");
            _tenThuTruong = dr.GetString("ThuTruong_Ten");
            _tenNguoiLap = dr.GetString("NguoiLap_Ten");
            _tenKeToanTruong = dr.GetString("TenKTTTruong");
            _tenThuQuy = dr.GetString("TenThuQuy");
            _capNhatHoSo = dr.GetBoolean("CapNhatHoSo");
            _capNhatPhuCap = dr.GetBoolean("PhuCap");
            _capNhatChamCong = dr.GetBoolean("ChamCong");
            _congThue = dr.GetBoolean("CongThue");
            _emailDenTang = dr.GetString("EmailDenTang");
            _emailGui = dr.GetString("EmailGui");
            _emailHRM = dr.GetString("EmailHRM");
            _matKhauEmailGui = dr.GetString("MatKhauEmailGui");
            _maCongTyQuanLy = dr.GetString("MaCongTyQuanLy");
            dr.NextResult();
            while (dr.Read())
            {
                _phanQuyenBoPhan.Add(dr.GetInt32("MaBoPhan"));
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
