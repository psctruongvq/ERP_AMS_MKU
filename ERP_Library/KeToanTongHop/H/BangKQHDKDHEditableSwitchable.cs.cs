using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class BangKQHDKDH : Csla.BusinessBase<BangKQHDKDH>
    {
        #region Business Properties and Methods

        //declare members
        private int _maMuc = 0;
        private string _tenMuc = string.Empty;
        private string _maSo = string.Empty;
        private string _thuyetMinh = string.Empty;
        private byte _loai = 0;
        private byte _loaiBaoCao = 2;
        private int _maMucCha = 0;
        private int _sTTTinh = 0;
        private byte _isNHNN = 0;
        private int _maThongTu = 0;
        private int _maMucDoiUng = 0;
        private string _dienGiai = string.Empty;
        private string _col1 = string.Empty;
        private string _col2 = string.Empty;

        private string _soHieuTK = string.Empty;
        private string _dauCongThuc = string.Empty;
        private string _kieuLaySoDu = string.Empty;
        private string _benNoCo = string.Empty;
        private string _tenMucLienQuan = string.Empty;
        private string _soHieuTKDoiUng = string.Empty;
        private string _TenHoatDong = string.Empty;
        private string _TenKhoanMuc = string.Empty;
        private string _SapXep = string.Empty;        
        private int _MaChiTiet = 0;
        private int _keyOfTree = 0;

        private CT_MauBangBaoCaoListH _cT_MauBangBaoCaoListH = CT_MauBangBaoCaoListH.NewCT_MauBangBaoCaoListH();

        [System.ComponentModel.DataObjectField(true, true)]

        public string COL1
        {
            get
            {
                CanReadProperty("COL1", true);
                return _col1;
            }
            set
            {
                CanWriteProperty("COL1", true);
                if (value == null) value = string.Empty;
                if (!_col1.Equals(value))
                {
                    _col1 = value;
                    PropertyHasChanged("COL1");
                }
            }
        }

        public string COL2
        {
            get
            {
                CanReadProperty("COL2", true);
                return _col2;
            }
            set
            {
                CanWriteProperty("COL2", true);
                if (value == null) value = string.Empty;
                if (!_col2.Equals(value))
                {
                    _col2 = value;
                    PropertyHasChanged("COL2");
                }
            }
        }

        public int MaMuc
        {
            get
            {
                CanReadProperty("MaMuc", true);
                return _maMuc;
            }
            set
            {
                CanWriteProperty("MaMuc", true);
                if (!_maMuc.Equals(value))
                {
                    _maMuc = value;
                    PropertyHasChanged("MaMuc");
                }
            }
        }

        public string TenMuc
        {
            get
            {
                CanReadProperty("TenMuc", true);
                return _tenMuc;
            }
            set
            {
                CanWriteProperty("TenMuc", true);
                if (value == null) value = string.Empty;
                if (!_tenMuc.Equals(value))
                {
                    _tenMuc = value;
                    PropertyHasChanged("TenMuc");
                }
            }
        }

        public string MaSo
        {
            get
            {
                CanReadProperty("MaSo", true);
                return _maSo;
            }
            set
            {
                CanWriteProperty("MaSo", true);
                if (value == null) value = string.Empty;
                if (!_maSo.Equals(value))
                {
                    _maSo = value;
                    PropertyHasChanged("MaSo");
                }
            }
        }

        public string ThuyetMinh
        {
            get
            {
                CanReadProperty("ThuyetMinh", true);
                return _thuyetMinh;
            }
            set
            {
                CanWriteProperty("ThuyetMinh", true);
                if (value == null) value = string.Empty;
                if (!_thuyetMinh.Equals(value))
                {
                    _thuyetMinh = value;
                    PropertyHasChanged("ThuyetMinh");
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

        public byte LoaiBaoCao
        {
            get
            {
                CanReadProperty("LoaiBaoCao", true);
                return _loaiBaoCao;
            }
            set
            {
                CanWriteProperty("LoaiBaoCao", true);
                if (!_loaiBaoCao.Equals(value))
                {
                    _loaiBaoCao = value;
                    PropertyHasChanged("LoaiBaoCao");
                }
            }
        }

        public int MaMucCha
        {
            get
            {
                CanReadProperty("MaMucCha", true);
                return _maMucCha;
            }
            set
            {
                CanWriteProperty("MaMucCha", true);
                if (!_maMucCha.Equals(value))
                {
                    _maMucCha = value;
                    PropertyHasChanged("MaMucCha");
                }
            }
        }

        public int STTTinh
        {
            get
            {
                CanReadProperty("STTTinh", true);
                return _sTTTinh;
            }
            set
            {
                CanWriteProperty("STTTinh", true);
                if (!_sTTTinh.Equals(value))
                {
                    _sTTTinh = value;
                    PropertyHasChanged("STTTinh");
                }
            }
        }

        public byte IsNHNN
        {
            get
            {
                CanReadProperty("IsNHNN", true);
                return _isNHNN;
            }
            set
            {
                CanWriteProperty("IsNHNN", true);
                if (!_isNHNN.Equals(value))
                {
                    _isNHNN = value;
                    PropertyHasChanged("IsNHNN");
                }
            }
        }

        public int MaThongTu
        {
            get
            {
                CanReadProperty("MaThongTu", true);
                return _maThongTu;
            }
            set
            {
                CanWriteProperty("MaThongTu", true);
                if (!_maThongTu.Equals(value))
                {
                    _maThongTu = value;
                    PropertyHasChanged("MaThongTu");
                }
            }
        }

        public int MaMucDoiUng
        {
            get
            {
                CanReadProperty("MaMucDoiUng", true);
                return _maMucDoiUng;
            }
            set
            {
                CanWriteProperty("MaMucDoiUng", true);
                if (!_maMucDoiUng.Equals(value))
                {
                    _maMucDoiUng = value;
                    PropertyHasChanged("MaMucDoiUng");
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

        public string SoHieuTK
        {
            get
            {
                CanReadProperty("SoHieuTK", true);
                return _soHieuTK;
            }
            set
            {
                CanWriteProperty("SoHieuTK", true);
                if (!_soHieuTK.Equals(value))
                {
                    _soHieuTK = value;
                    PropertyHasChanged("SoHieuTK");
                }
            }
        }

        public string DauCongThuc
        {
            get
            {
                CanReadProperty("DauCongThuc", true);
                return _dauCongThuc;
            }
            set
            {
                CanWriteProperty("DauCongThuc", true);
                if (!_dauCongThuc.Equals(value))
                {
                    _dauCongThuc = value;
                    PropertyHasChanged("DauCongThuc");
                }
            }
        }

        public string KieuLaySoDu
        {
            get
            {
                CanReadProperty("KieuLaySoDu", true);
                return _kieuLaySoDu;
            }
            set
            {
                CanWriteProperty("KieuLaySoDu", true);
                if (!_kieuLaySoDu.Equals(value))
                {
                    _kieuLaySoDu = value;
                    PropertyHasChanged("KieuLaySoDu");
                }
            }
        }

        public string BenNoCo
        {
            get
            {
                CanReadProperty("BenNoCo", true);
                return _benNoCo;
            }
            set
            {
                CanWriteProperty("BenNoCo", true);
                if (!_benNoCo.Equals(value))
                {
                    _benNoCo = value;
                    PropertyHasChanged("BenNoCo");
                }
            }
        }

        public string TenMucLienQuan
        {
            get
            {
                CanReadProperty("TenMucLienQuan", true);
                return _tenMucLienQuan;
            }
            set
            {
                CanWriteProperty("TenMucLienQuan", true);
                if (!_tenMucLienQuan.Equals(value))
                {
                    _tenMucLienQuan = value;
                    PropertyHasChanged("TenMucLienQuan");
                }
            }
        }

        public string SoHieuTKDoiUng
        {
            get
            {
                CanReadProperty("SoHieuTKDoiUng", true);
                return _soHieuTKDoiUng;
            }
            set
            {
                CanWriteProperty("SoHieuTKDoiUng", true);
                if (!_soHieuTKDoiUng.Equals(value))
                {
                    _soHieuTKDoiUng = value;
                    PropertyHasChanged("SoHieuTKDoiUng");
                }
            }
        }

        public string TenHoatDong
        {
            get
            {
                CanReadProperty("TenHoatDong", true);
                return _TenHoatDong;
            }
            set
            {
                CanWriteProperty("TenHoatDong", true);
                if (!_TenHoatDong.Equals(value))
                {
                    _TenHoatDong = value;
                    PropertyHasChanged("TenHoatDong");
                }
            }
        }

        public string TenKhoanMuc
        {
            get
            {
                CanReadProperty("TenKhoanMuc", true);
                return _TenKhoanMuc;
            }
            set
            {
                CanWriteProperty("TenKhoanMuc", true);
                if (!_TenKhoanMuc.Equals(value))
                {
                    _TenKhoanMuc = value;
                    PropertyHasChanged("TenKhoanMuc");
                }
            }
        }

        public string SapXep
        {
            get
            {
                CanReadProperty("SapXep", true);
                return _SapXep;
            }
            set
            {
                CanWriteProperty("SapXep", true);
                if (!_SapXep.Equals(value))
                {
                    _SapXep = value;
                    PropertyHasChanged("SapXep");
                }
            }
        }      

        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _MaChiTiet;
            }
            set
            {
                CanWriteProperty("MaChiTiet", true);
                if (!_MaChiTiet.Equals(value))
                {
                    _MaChiTiet = value;
                    PropertyHasChanged("MaChiTiet");
                }
            }
        }

        public int KeyOfTree
        {
            get
            {
                CanReadProperty("KeyOfTree", true);
                return _keyOfTree;
            }
            set
            {
                CanWriteProperty("KeyOfTree", true);
                if (!_keyOfTree.Equals(value))
                {
                    _keyOfTree = value;
                    PropertyHasChanged("KeyOfTree");
                }
            }
        }

        public CT_MauBangBaoCaoListH CT_MauBangBaoCaoListH
        {
            get
            {
                CanReadProperty("CT_MauBangBaoCaoListH", true);
                return _cT_MauBangBaoCaoListH;
            }
        }

        public override bool IsValid
        {
            get { return base.IsValid && _cT_MauBangBaoCaoListH.IsValid; }
        }

        public override bool IsDirty
        {
            get { return base.IsDirty || _cT_MauBangBaoCaoListH.IsDirty; }
        }

        protected override object GetIdValue()
        {
            return _maMuc;
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
            // TenMuc
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("TenMuc", 1000));
            //
            // MaSo
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("MaSo", 50));
            //
            // ThuyetMinh
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("ThuyetMinh", 50));
            //
            // DienGiai
            //
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
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
            //TODO: Define authorization rules in BangKQHDKDH
            //AuthorizationRules.AllowRead("MaMuc", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("TenMuc", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("MaSo", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("ThuyetMinh", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("Loai", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("LoaiBaoCao", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("MaMucCha", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("STTTinh", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("IsNHNN", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("MaThongTu", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("MaMucDoiUng", "BangKQHDKDHReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "BangKQHDKDHReadGroup");

            //AuthorizationRules.AllowWrite("TenMuc", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("MaSo", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("ThuyetMinh", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("Loai", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("LoaiBaoCao", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("MaMucCha", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("STTTinh", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("IsNHNN", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("MaThongTu", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("MaMucDoiUng", "BangKQHDKDHWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "BangKQHDKDHWriteGroup");
        }


        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in BangKQHDKDH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangKQHDKDHViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in BangKQHDKDH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangKQHDKDHAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in BangKQHDKDH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangKQHDKDHEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in BangKQHDKDH
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("BangKQHDKDHDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private BangKQHDKDH()
        { /* require use of factory method */ }

        public static BangKQHDKDH NewBangKQHDKDH()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangKQHDKDH");
            return DataPortal.Create<BangKQHDKDH>();
            
        }

        public static BangKQHDKDH GetBangKQHDKDH(int maMuc)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangKQHDKDH");
            return DataPortal.Fetch<BangKQHDKDH>(new Criteria(maMuc));
        }

        public static void DeleteBangKQHDKDH(int maMuc)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangKQHDKDH");
            DataPortal.Delete(new Criteria(maMuc));
        }

        public override BangKQHDKDH Save()
        {
            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException("User not authorized to remove a BangKQHDKDH");
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a BangKQHDKDH");
            else if (!CanEditObject())
                throw new System.Security.SecurityException("User not authorized to update a BangKQHDKDH");

            return base.Save();
        }

        #endregion //Factory Methods

        #region Child Factory Methods
        public static BangKQHDKDH NewBangKQHDKDHChild()
        {
            BangKQHDKDH child = new BangKQHDKDH();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        internal static BangKQHDKDH GetBangKQHDKDH(SafeDataReader dr)
        {
            BangKQHDKDH child = new BangKQHDKDH();
            child.MarkAsChild();
            child.Fetch(dr);
            return child;
        }

        internal static BangKQHDKDH GetBangKQHDKDH_ForTree(SafeDataReader dr)
        {
            BangKQHDKDH child = new BangKQHDKDH();
            child.MarkAsChild();
            child.Fetch_ForTree(dr);
            return child;
        }

        public static BangKQHDKDH NewBCKQHDKDChildH(BangKQHDKDH copy,byte loaibaocao)
        {

            BangKQHDKDH child = new BangKQHDKDH();
            child.TenMuc = copy.TenMuc;
            child.MaSo = copy.MaSo;
            child.ThuyetMinh = copy.ThuyetMinh;
            child.Loai = copy.Loai;
            child.LoaiBaoCao = copy.LoaiBaoCao;
            //child.MaMucCha = copy.MaMucCha;
            child.STTTinh = copy.STTTinh;
            //child.MaMucDoiUng = copy.MaMucDoiUng;
            child.DienGiai = copy.DienGiai;
            //child.isNHNN = copy.isNHNN;
            //child.MaThongTu
            child.MaMucDoiUng = copy.MaMucDoiUng != 0 ? copy.MaMucDoiUng : copy.MaMuc;
            foreach (CT_MauBangBaoCaoH ct in copy.CT_MauBangBaoCaoListH)
            {
                child._cT_MauBangBaoCaoListH.Add(CT_MauBangBaoCaoH.NewCT_MauBangBaoCaoH(ct, loaibaocao));
            }
            child.MarkNew();
            child.ValidationRules.CheckRules();
            child.MarkAsChild();
            return child;
        }

        #endregion //Child Factory Methods

        #region Data Access

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaMuc;

            public Criteria(int maMuc)
            {
                this.MaMuc = maMuc;
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
                cm.CommandText = "spd_SelecttblMauBCKQHoatDongKinhDoanh";

                cm.Parameters.AddWithValue("@MaMuc", criteria.MaMuc);

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
            DataPortal_Delete(new Criteria(_maMuc));
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
                cm.CommandText = "spd_DeleteBangKQHDKDH";

                cm.Parameters.AddWithValue("@MaMuc", criteria.MaMuc);

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

        private void Fetch_ForTree(SafeDataReader dr)
        {
            FetchObjectForTree(dr);
            MarkOld();
            ValidationRules.CheckRules();

            //load child object(s)
            FetchChildren(dr);
        }

        private void FetchObject(SafeDataReader dr)
        {
            _maMuc = dr.GetInt32("MaMuc");
            _tenMuc = dr.GetString("TenMuc");
            _maSo = dr.GetString("MaSo");
            _thuyetMinh = dr.GetString("ThuyetMinh");
            _loai = dr.GetByte("Loai");
            _loaiBaoCao = dr.GetByte("LoaiBaoCao");
            _maMucCha = dr.GetInt32("MaMucCha");
            _sTTTinh = dr.GetInt32("STTTinh");
            _isNHNN = dr.GetByte("isNHNN");
            _maThongTu = dr.GetInt32("MaThongTu");
            _maMucDoiUng = dr.GetInt32("MaMucDoiUng");
            _dienGiai = dr.GetString("DienGiai");
        }

        private void FetchObjectForTree(SafeDataReader dr)
        {
            _maMuc = dr.GetInt32("MaMuc");
            _tenMuc = dr.GetString("TenMuc");
            _maSo = dr.GetString("MaSo");
            _thuyetMinh = dr.GetString("ThuyetMinh");
            _loai = dr.GetByte("Loai");
            _loaiBaoCao = dr.GetByte("LoaiBaoCao");
            _maMucCha = dr.GetInt32("MaMucCha");
            _sTTTinh = dr.GetInt32("STTTinh");
            _isNHNN = dr.GetByte("isNHNN");
            _maThongTu = dr.GetInt32("MaThongTu");
            _maMucDoiUng = dr.GetInt32("MaMucDoiUng");
            _dienGiai = dr.GetString("DienGiai");
            _soHieuTK = dr.GetString("SoHieuTK");
            _dauCongThuc = dr.GetString("DauCongThuc");
            _kieuLaySoDu = dr.GetString("KieuLaySoDu");
            _benNoCo = dr.GetString("BenNoCo");
            _tenMucLienQuan = dr.GetString("TenMucLienQuan");
            _soHieuTKDoiUng = dr.GetString("SoHieuTKDoiUng");
            _TenHoatDong = dr.GetString("TenHoatDong");
            _TenKhoanMuc = dr.GetString("TenKhoanMuc");
            _MaChiTiet = dr.GetInt32("MaChiTiet");            
            _keyOfTree = dr.GetInt32("KeyOfTree");
        }

        public void FetchChildren(SafeDataReader dr)
        {
            _cT_MauBangBaoCaoListH = CT_MauBangBaoCaoListH.GetCT_MauBangBaoCaoListH(this.MaMuc,_loaiBaoCao);
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
                cm.CommandText = "spd_InserttblBangKQHDKDH";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _maMuc = (int)cm.Parameters["@MaMuc"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {
            if (_tenMuc.Length > 0)
                cm.Parameters.AddWithValue("@TenMuc", _tenMuc);
            else
                cm.Parameters.AddWithValue("@TenMuc", DBNull.Value);
            if (_maSo.Length > 0)
                cm.Parameters.AddWithValue("@MaSo", _maSo);
            else
                cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
            if (_thuyetMinh.Length > 0)
                cm.Parameters.AddWithValue("@ThuyetMinh", _thuyetMinh);
            else
                cm.Parameters.AddWithValue("@ThuyetMinh", DBNull.Value);
            cm.Parameters.AddWithValue("@Loai", _loai);
            if (_loaiBaoCao != 0)
                cm.Parameters.AddWithValue("@LoaiBaoCao", _loaiBaoCao);
            else
                cm.Parameters.AddWithValue("@LoaiBaoCao", DBNull.Value);
            if (_maMucCha != 0)
                cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
            else
                cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
            if (_sTTTinh != 0)
                cm.Parameters.AddWithValue("@STTTinh", _sTTTinh);
            else
                cm.Parameters.AddWithValue("@STTTinh", DBNull.Value);
            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);
            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);
            if (_maMucDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucDoiUng", _maMucDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucDoiUng", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
            cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            cm.Parameters["@MaMuc"].Direction = ParameterDirection.Output;
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
                cm.CommandText = "spd_UpdatetblBangKQHDKDH";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaMuc", _maMuc);
            if (_tenMuc.Length > 0)
                cm.Parameters.AddWithValue("@TenMuc", _tenMuc);
            else
                cm.Parameters.AddWithValue("@TenMuc", DBNull.Value);
            if (_maSo.Length > 0)
                cm.Parameters.AddWithValue("@MaSo", _maSo);
            else
                cm.Parameters.AddWithValue("@MaSo", DBNull.Value);
            if (_thuyetMinh.Length > 0)
                cm.Parameters.AddWithValue("@ThuyetMinh", _thuyetMinh);
            else
                cm.Parameters.AddWithValue("@ThuyetMinh", DBNull.Value);
            cm.Parameters.AddWithValue("@Loai", _loai);
            if (_loaiBaoCao != 0)
                cm.Parameters.AddWithValue("@LoaiBaoCao", _loaiBaoCao);
            else
                cm.Parameters.AddWithValue("@LoaiBaoCao", DBNull.Value);
            if (_maMucCha != 0)
                cm.Parameters.AddWithValue("@MaMucCha", _maMucCha);
            else
                cm.Parameters.AddWithValue("@MaMucCha", DBNull.Value);
            if (_sTTTinh != 0)
                cm.Parameters.AddWithValue("@STTTinh", _sTTTinh);
            else
                cm.Parameters.AddWithValue("@STTTinh", DBNull.Value);
            if (_isNHNN != 0)
                cm.Parameters.AddWithValue("@isNHNN", _isNHNN);
            else
                cm.Parameters.AddWithValue("@isNHNN", DBNull.Value);
            if (_maThongTu != 0)
                cm.Parameters.AddWithValue("@MaThongTu", _maThongTu);
            else
                cm.Parameters.AddWithValue("@MaThongTu", DBNull.Value);
            if (_maMucDoiUng != 0)
                cm.Parameters.AddWithValue("@MaMucDoiUng", _maMucDoiUng);
            else
                cm.Parameters.AddWithValue("@MaMucDoiUng", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _cT_MauBangBaoCaoListH.Update(tr, this);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            _cT_MauBangBaoCaoListH.Clear();
            UpdateChildren(tr);

            ExecuteDelete(tr, new Criteria(_maMuc));
            //MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
