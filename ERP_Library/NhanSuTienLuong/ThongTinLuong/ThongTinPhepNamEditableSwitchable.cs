
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class ThongTinPhepNam : Csla.BusinessBase<ThongTinPhepNam>
    {
        #region Business Properties and Methods

        //declare members
        private long _maNhanVien = 0;
        private string _tenNhanVien = string.Empty;
        private string _maQLNhanVien = string.Empty;
        private string _cardID = string.Empty;
        private DateTime _ngayVaoNganh = DateTime.Today;
        private decimal _soNgayPhepNamTrongNam = 0;
        private decimal _soNgayDaNghi = 0;
        private decimal _soNgayConLai = 0;
        private int _thang1 = 0;
        private int _thang2 = 0;
        private int _thang3 = 0;
        private int _thang4 = 0;
        private int _thang5 = 0;
        private int _thang6 = 0;
        private int _thang7 = 0;
        private int _thang8 = 0;
        private int _thang9 = 0;
        private int _thang10 = 0;
        private int _thang11 = 0;
        private int _thang12 = 0;

        ThongTinNhanVienTongHop _ThongTinNhanVienTongHop;

        [System.ComponentModel.DataObjectField(true, true)]
        
        public long MaNhanVien
        {
            get
            {
                CanReadProperty("MaNhanVien", true);
                return _maNhanVien;
            }
        }

        public string TenNhanVien
        {
            get
            {
                CanReadProperty("TenNhanVien", true);
                return ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien).TenNhanVien;
            }
        }

        public string MaQLNhanVien
        {
            get
            {
                CanReadProperty("MaQLNhanVien", true);
                return ThongTinNhanVienTongHop.GetThongTinNhanVienTongHop(MaNhanVien).MaQLNhanVien;
            }
        }

     
        public DateTime NgayVaoNganh
        {
            get
            {
                CanReadProperty("NgayVaoNganh", true);
                return _ngayVaoNganh.Date;
            }
        }

        public decimal SoNgayPhepNamTrongNam
        {
            get
            {
                CanReadProperty("SoNgayPhepNamTrongNam", true);
                return _soNgayPhepNamTrongNam;
            }
        }

        public decimal SoNgayDaNghi
        {
            get
            {
                CanReadProperty("SoNgayDaNghi", true);
                return _soNgayDaNghi;
            }
        }

        public decimal SoNgayConLai
        {
            get
            {
                CanReadProperty("SoNgayConLai", true);
                return _soNgayConLai;
            }
        }

        public int Thang1
        {
            get
            {
                CanReadProperty("Thang1", true);
                return _thang1;
            }
        }

        public int Thang2
        {
            get
            {
                CanReadProperty("Thang2", true);
                return _thang2;
            }
        }

        public int Thang3
        {
            get
            {
                CanReadProperty("Thang3", true);
                return _thang3;
            }
        }

        public int Thang4
        {
            get
            {
                CanReadProperty("Thang4", true);
                return _thang4;
            }
        }

        public int Thang5
        {
            get
            {
                CanReadProperty("Thang5", true);
                return _thang5;
            }
        }

        public int Thang6
        {
            get
            {
                CanReadProperty("Thang6", true);
                return _thang6;
            }
        }

        public int Thang7
        {
            get
            {
                CanReadProperty("Thang7", true);
                return _thang7;
            }
        }

        public int Thang8
        {
            get
            {
                CanReadProperty("Thang8", true);
                return _thang8;
            }
        }

        public int Thang9
        {
            get
            {
                CanReadProperty("Thang9", true);
                return _thang9;
            }
        }

        public int Thang10
        {
            get
            {
                CanReadProperty("Thang10", true);
                return _thang10;
            }
        }

        public int Thang11
        {
            get
            {
                CanReadProperty("Thang11", true);
                return _thang11;
            }
        }

        public int Thang12
        {
            get
            {
                CanReadProperty("Thang12", true);
                return _thang12;
            }
        }
        protected override object GetIdValue()
        {
            return _maNhanVien;
        }

        #endregion //Business Properties and Methods

        #region Validation Rules
        private void AddCustomRules()
        {
            //add custom/non-generated rules here...
        }

        private void AddCommonRules()
        {
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("LyDo", 4000));
            ////
            //// MaNguoiLap
            ////
            //ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaNguoiLap", 10));
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
            //TODO: Define authorization rules in QuaTrinhNghi
            //AuthorizationRules.AllowRead("MaQuaTrinhNghi", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("MaNhanVien", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("MaHinhThucNghi", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("TuNgay", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("TuNgayString", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("DenNgay", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("DenNgayString", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("LyDo", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("TruChuyenCan", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("MaNguoiLap", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("NgayLap", "QuaTrinhNghiReadGroup");
            //AuthorizationRules.AllowRead("NgayLapString", "QuaTrinhNghiReadGroup");

            //AuthorizationRules.AllowWrite("MaNhanVien", "QuaTrinhNghiWriteGroup");
            //AuthorizationRules.AllowWrite("MaHinhThucNghi", "QuaTrinhNghiWriteGroup");
            //AuthorizationRules.AllowWrite("TuNgayString", "QuaTrinhNghiWriteGroup");
            //AuthorizationRules.AllowWrite("DenNgayString", "QuaTrinhNghiWriteGroup");
            //AuthorizationRules.AllowWrite("LyDo", "QuaTrinhNghiWriteGroup");
            //AuthorizationRules.AllowWrite("TruChuyenCan", "QuaTrinhNghiWriteGroup");
            //AuthorizationRules.AllowWrite("MaNguoiLap", "QuaTrinhNghiWriteGroup");
            //AuthorizationRules.AllowWrite("NgayLapString", "QuaTrinhNghiWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in QuaTrinhNghi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in QuaTrinhNghi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in QuaTrinhNghi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in QuaTrinhNghi
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("QuaTrinhNghiDeleteGroup"))
            //	return true;
            //return false;
        }

        #endregion //Authorization Rules

        #region Factory Methods
        private ThongTinPhepNam()
        { /* require use of factory method */ }

        public static ThongTinPhepNam GetThongTinPhepNam(int MaChiNhanh, int MaPhongBan, int MaTo, int Nam)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a QuaTrinhNghi");
            return DataPortal.Fetch<ThongTinPhepNam>(new Criteria(MaChiNhanh, MaPhongBan, MaTo, Nam));
        }

        public override ThongTinPhepNam Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a QuaTrinhNghi");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a QuaTrinhNghi");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a QuaTrinhNghi");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        //internal static QuaTrinhNghi NewQuaTrinhNghiChild()
        //{
        //    QuaTrinhNghi child = new QuaTrinhNghi();
        //    child.ValidationRules.CheckRules();
        //    child.MarkAsChild();
        //    return child;
        //}

        internal static ThongTinPhepNam GetThongTinPhepNam(SafeDataReader dr)
        {
            ThongTinPhepNam child = new ThongTinPhepNam();
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
            public int MaChiNhanh;
            public int MaPhongBan;
            public int MaTo;
            public int Nam;

            public Criteria(int maChiNhanh, int maPhongBan, int maTo, int nam)
            {
                this.MaChiNhanh = maChiNhanh;
                this.MaPhongBan = maPhongBan;
                this.MaTo = maTo;
                this.Nam = nam;
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
                cm.CommandText = "spd_ThongTinNghiPhepNam";

                cm.Parameters.AddWithValue("@MaChiNhanh", criteria.MaChiNhanh);
                cm.Parameters.AddWithValue("@MaPhongBan", criteria.MaPhongBan);
                cm.Parameters.AddWithValue("@MaTo", criteria.MaTo);
                cm.Parameters.AddWithValue("@Nam", criteria.Nam);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    dr.Read();
                    FetchObject(dr);
                    ValidationRules.CheckRules();

                    //load child object(s)
                    //FetchChildren(dr);
                }
            }//using
        }

        #endregion //Data Access - Fetch

        #region Data Access - Fetch
        private void Fetch(SafeDataReader dr)
        {
            FetchObject(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            //FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            try
            {
                _maNhanVien = dr.GetInt64("MaNhanVien");
                _tenNhanVien = dr.GetString("TenNhanVien");
                _ngayVaoNganh = dr.GetDateTime("NgayVaoNganh");
                _soNgayPhepNamTrongNam = dr.GetDecimal("SoNgayPhepNamTrongNam");
                _soNgayDaNghi = dr.GetInt32("SoNgayDaNghi");
                _soNgayConLai = dr.GetDecimal("SoNgayConLai");
                _thang1 = dr.GetInt32("Thang1");
                _thang2 = dr.GetInt32("Thang2");
                _thang3 = dr.GetInt32("Thang3");
                _thang4 = dr.GetInt32("Thang4");
                _thang5 = dr.GetInt32("Thang5");
                _thang6 = dr.GetInt32("Thang6");
                _thang7 = dr.GetInt32("Thang7");
                _thang8 = dr.GetInt32("Thang8");
                _thang9 = dr.GetInt32("Thang9");
                _thang10 = dr.GetInt32("Thang10");
                _thang11 = dr.GetInt32("Thang11");
                _thang12 = dr.GetInt32("Thang12");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #endregion //Data Access
    }
}
