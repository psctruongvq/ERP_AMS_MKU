using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CongThucApDungKeToanTongHop : Csla.BusinessBase<CongThucApDungKeToanTongHop>
    {
        #region Business Properties and Methods

        //declare members
        private int _maCongThuc = 0;
        private byte _loai = 0;
        private SmartDate _ngayApDung = new SmartDate(DateTime.Today);
        private string _noiDung = string.Empty;

        private string _loaiString = string.Empty;

        [System.ComponentModel.DataObjectField(true, true)]
        public int MaCongThuc
        {
            get
            {
                CanReadProperty("MaCongThuc", true);
                return _maCongThuc;
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
                    switch (_loai)
                    {
                        case 1:
                            _loaiString = "Mẫu Bảng Cân Đối Kế Toán";
                            break;
                        case 2:
                            _loaiString = "Mẫu Báo cáo Kết Quả Hoạt Động Kinh Doanh";
                            break;
                        case 3:
                            _loaiString = "Mẫu Báo Cáo Lưu Chuyển Tiền Tệ";
                            break;
                        case 4:
                            _loaiString = "Mẫu Báo Cáo Chi Tiết KQHĐKD";
                            break;
                        case 5:
                            _loaiString = "Mẫu Báo Cáo Ước Tính Doanh Thu Chi Phí";
                            break;
                        case 6:
                            _loaiString = "Mẫu Chi Phí HĐ Đề Nghị Quyết Toán";
                            break;
                    }
                    PropertyHasChanged("Loai");
                }
            }
        }

        public DateTime NgayApDung
        {
            get
            {
                CanReadProperty("NgayApDung", true);
                return _ngayApDung.Date;
            }
            set
            {
                CanWriteProperty("NgayApDung", true);
                _ngayApDung = new SmartDate(value);
                PropertyHasChanged("NgayApDung");
            }
        }

        public string NgayApDungString
        {
            get
            {
                CanReadProperty("NgayApDungString", true);
                return _ngayApDung.Text;
            }
            set
            {
                CanWriteProperty("NgayApDungString", true);
                if (value == null) value = string.Empty;
                if (!_ngayApDung.Equals(value))
                {
                    _ngayApDung.Text = value;
                    PropertyHasChanged("NgayApDungString");
                }
            }
        }

        public string NoiDung
        {
            get
            {
                CanReadProperty("NoiDung", true);
                return _noiDung;
            }
            set
            {
                CanWriteProperty("NoiDung", true);
                if (value == null) value = string.Empty;
                if (!_noiDung.Equals(value))
                {
                    _noiDung = value;
                    PropertyHasChanged("NoiDung");
                }
            }
        }

        public string LoaiString
        {
            get
            {
                CanReadProperty("LoaiString", true);
                return _loaiString;
            }
        }

        protected override object GetIdValue()
        {
            return _maCongThuc;
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
            //TODO: Define authorization rules in CongThucApDungKeToanTongHop
            //AuthorizationRules.AllowRead("MaCongThuc", "CongThucApDungKeToanTongHopReadGroup");
            //AuthorizationRules.AllowRead("Loai", "CongThucApDungKeToanTongHopReadGroup");
            //AuthorizationRules.AllowRead("NgayApDung", "CongThucApDungKeToanTongHopReadGroup");
            //AuthorizationRules.AllowRead("NgayApDungString", "CongThucApDungKeToanTongHopReadGroup");
            //AuthorizationRules.AllowRead("NoiDung", "CongThucApDungKeToanTongHopReadGroup");

            //AuthorizationRules.AllowWrite("Loai", "CongThucApDungKeToanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("NgayApDungString", "CongThucApDungKeToanTongHopWriteGroup");
            //AuthorizationRules.AllowWrite("NoiDung", "CongThucApDungKeToanTongHopWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in CongThucApDungKeToanTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucApDungKeToanTongHopViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in CongThucApDungKeToanTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucApDungKeToanTongHopAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in CongThucApDungKeToanTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucApDungKeToanTongHopEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in CongThucApDungKeToanTongHop
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("CongThucApDungKeToanTongHopDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private CongThucApDungKeToanTongHop()
        { /* require use of factory method */ }

        private CongThucApDungKeToanTongHop(string noidung)
        { _noiDung = noidung; }

        public static CongThucApDungKeToanTongHop NewCongThucApDungKeToanTongHop(string noidung)
        {
            return new CongThucApDungKeToanTongHop(noidung);
        }

        public static CongThucApDungKeToanTongHop NewCongThucApDungKeToanTongHop()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongThucApDungKeToanTongHop");
            return DataPortal.Create<CongThucApDungKeToanTongHop>();
        }

        public static CongThucApDungKeToanTongHop GetCongThucApDungKeToanTongHop(int maCongThuc)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a CongThucApDungKeToanTongHop");
            return DataPortal.Fetch<CongThucApDungKeToanTongHop>(new Criteria(maCongThuc));
        }

        public static void DeleteCongThucApDungKeToanTongHop(int maCongThuc)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CongThucApDungKeToanTongHop");
            DataPortal.Delete(new Criteria(maCongThuc));
        }

        public override CongThucApDungKeToanTongHop Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a CongThucApDungKeToanTongHop");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CongThucApDungKeToanTongHop");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a CongThucApDungKeToanTongHop");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        internal static CongThucApDungKeToanTongHop NewCongThucApDungKeToanTongHopChild()
        {
            CongThucApDungKeToanTongHop child = new CongThucApDungKeToanTongHop();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }


        internal static CongThucApDungKeToanTongHop GetCongThucApDungKeToanTongHop(SafeDataReader dr)
        {
            CongThucApDungKeToanTongHop child = new CongThucApDungKeToanTongHop();
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
            public int MaCongThuc;

            public Criteria(int maCongThuc)
            {
                this.MaCongThuc = maCongThuc;
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
                cm.CommandText = "spd_SelecttblCongThucApDungKeToanTongHop";

                cm.Parameters.AddWithValue("@MaCongThuc", criteria.MaCongThuc);

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
            DataPortal_Delete(new Criteria(_maCongThuc));
        }

        private void DataPortal_Delete(Criteria criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                ExecuteDelete(cn, criteria);

            }//using

        }

        private void ExecuteDelete(SqlConnection cn, Criteria criteria)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeletetblCongThucApDungKeToanTongHop";

                cm.Parameters.AddWithValue("@MaCongThuc", criteria.MaCongThuc);

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
            _maCongThuc = dr.GetInt32("MaCongThuc");
            _loai = dr.GetByte("Loai");
            _ngayApDung = dr.GetSmartDate("NgayApDung", _ngayApDung.EmptyIsMin);
            _noiDung = dr.GetString("NoiDung");
            _loaiString = dr.GetString("LoaiString");
        }

        private void FetchChildren(SafeDataReader dr)
        {
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlConnection cn)
        {
            if (!IsDirty) return;

            ExecuteInsert(cn);
            MarkOld();

            //update child object(s)
            UpdateChildren(cn);
        }

        private void ExecuteInsert(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InserttblCongThucApDungKeToanTongHop";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maCongThuc = (int)cm.Parameters["@MaCongThuc"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
            cm.Parameters.AddWithValue("@MaCongThuc", _maCongThuc);
            cm.Parameters["@MaCongThuc"].Direction = ParameterDirection.Output;
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
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

        private void ExecuteUpdate(SqlConnection cn)
        {
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdatetblCongThucApDungKeToanTongHop";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaCongThuc", _maCongThuc);
            if (_loai != 0)
                cm.Parameters.AddWithValue("@Loai", _loai);
            else
                cm.Parameters.AddWithValue("@Loai", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayApDung", _ngayApDung.DBValue);
            if (_noiDung.Length > 0)
                cm.Parameters.AddWithValue("@NoiDung", _noiDung);
            else
                cm.Parameters.AddWithValue("@NoiDung", DBNull.Value);
        }

        private void UpdateChildren(SqlConnection cn)
        {
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlConnection cn)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(cn, new Criteria(_maCongThuc));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
