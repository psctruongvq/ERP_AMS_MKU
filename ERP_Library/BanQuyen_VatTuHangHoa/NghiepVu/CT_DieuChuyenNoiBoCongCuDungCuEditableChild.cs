using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    [Serializable()]
    public class CT_DieuChuyenNoiBoCongCuDungCu : Csla.BusinessBase<CT_DieuChuyenNoiBoCongCuDungCu>
    {

        #region Business Properties and Methods
        //child

        DuyetCongCuDungCu _duyetCongCuDungCu;


        CongCuDungCu_PhongBan _congCuDungCu_PhongBan_Cu;
        CongCuDungCu_PhongBan _congCuDungCu_PhongBan_Moi;
        private CongCuDungCu _congCuDungCu = null;



        public DuyetCongCuDungCu DuyetCongCuDungCu
        {
            get { return _duyetCongCuDungCu; }
            set { _duyetCongCuDungCu = value; }
        }
        public CongCuDungCu_PhongBan CongCuDungCu_PhongBan_Cu
        {
            get { return _congCuDungCu_PhongBan_Cu; }
            set { _congCuDungCu_PhongBan_Cu = value; }
        }


        public CongCuDungCu_PhongBan CongCuDungCu_PhongBan_Moi
        {
            get { return _congCuDungCu_PhongBan_Moi; }
            set { _congCuDungCu_PhongBan_Moi = value; }
        }

        public CongCuDungCu CongCuDungCu
        {
            get { return _congCuDungCu; }
            set { _congCuDungCu = value; }
        }
        //declare members
        private int _maChiTiet = 0;
        private int _maDieuChuyen = 0;
        private int _maCongCuDungCu = 0;
        private byte _lyDoDieuChuyen = 0;
        private bool _khongConDung = false;
        private bool _khongSuDung = false;
        private string _hienTrang = string.Empty;
        private string _dienGiai = string.Empty;
        private int _maPhanBoCu = 0;
        private int _maPhanBoMoi = 0;


        [System.ComponentModel.DataObjectField(true, true)]
        public int MaChiTiet
        {
            get
            {
                CanReadProperty("MaChiTiet", true);
                return _maChiTiet;
            }
        }
        public int MaPhanBoCu
        {
            get
            {
                CanReadProperty("MaPhanBoCu", true);
                return _maPhanBoCu;
            }
            set
            {
                CanWriteProperty("MaPhanBoCu", true);
                if (!_maPhanBoCu.Equals(value))
                {
                    _maPhanBoCu = value;
                    PropertyHasChanged("MaPhanBoCu");
                }
            }
        }
        public int MaPhanBoMoi
        {
            get
            {
                CanReadProperty("MaPhanBo", true);
                return _maPhanBoMoi;
            }
            set
            {
                CanWriteProperty("MaPhanBo", true);
                if (!_maPhanBoMoi.Equals(value))
                {
                    _maPhanBoMoi = value;
                    PropertyHasChanged("MaPhanBo");
                }
            }
        }
        public int MaDieuChuyen
        {
            get
            {
                CanReadProperty("MaDieuChuyen", true);
                return _maDieuChuyen;
            }
            set
            {
                CanWriteProperty("MaDieuChuyen", true);
                if (!_maDieuChuyen.Equals(value))
                {
                    _maDieuChuyen = value;
                    PropertyHasChanged("MaDieuChuyen");
                }
            }
        }

        public int MaCongCuDungCu
        {
            get
            {
                CanReadProperty("MaCongCuDungCu", true);
                return _maCongCuDungCu;
            }
            set
            {
                CanWriteProperty("MaCongCuDungCu", true);
                if (!_maCongCuDungCu.Equals(value))
                {
                    _maCongCuDungCu = value;
                    PropertyHasChanged("MaCongCuDungCu");
                }
            }
        }

        public byte LyDoDieuChuyen
        {
            get
            {
                CanReadProperty("LyDoDieuChuyen", true);
                return _lyDoDieuChuyen;
            }
            set
            {
                CanWriteProperty("LyDoDieuChuyen", true);
                if (!_lyDoDieuChuyen.Equals(value))
                {
                    _lyDoDieuChuyen = value;
                    PropertyHasChanged("LyDoDieuChuyen");
                    if (value == 1)
                    {
                        this._khongConDung = true;

                        this._khongSuDung = false;
                    }
                    else if (value == 2)
                    {
                        this._khongConDung = false;
                        this._khongSuDung = true;


                    }
                    else
                    {
                        this._khongConDung = false;

                        this._khongSuDung = false;

                    }
                }
            }
        }
        public bool KhongConDung
        {
            get
            {
                CanReadProperty("KhongConDung", true);
                return _khongConDung;
            }
            set
            {
                CanWriteProperty("KhongConDung", true);
                if (!_khongConDung.Equals(value))
                {
                    _khongConDung = value;
                    PropertyHasChanged("KhongConDung");
                    if (value == true)
                    {
                        _lyDoDieuChuyen = 1;

                    }

                    this._khongSuDung = !value;

                }
            }
        }

        public bool KhongSuDung
        {
            get
            {
                CanReadProperty("KhongSuDung", true);
                return _khongSuDung;
            }
            set
            {
                CanWriteProperty("KhongSuDung", true);
                if (!_khongSuDung.Equals(value))
                {
                    _khongSuDung = value;

                    PropertyHasChanged("KhongSuDung");
                    if (value == true)
                    {
                        _lyDoDieuChuyen = 2;

                    }
                    this._khongConDung = !value;

                }
            }
        }

        public string HienTrang
        {
            get
            {
                CanReadProperty("HienTrang", true);
                return _hienTrang;
            }
            set
            {
                CanWriteProperty("HienTrang", true);
                if (!_hienTrang.Equals(value))
                {
                    _hienTrang = value;
                    PropertyHasChanged("HienTrang");
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

        protected override object GetIdValue()
        {
            return _maChiTiet;
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
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs("DienGiai", 1000));
        }

        protected override void AddBusinessRules()
        {
            AddCommonRules();
            AddCustomRules();
        }
        #endregion //Validation Rules

        #region Authorization Rules
        public static bool CanAddObject()
        {
            return true;
        }
        protected override void AddAuthorizationRules()
        {
            //TODO: Define authorization rules in CT_DieuChuyenNoiBoCongCuDungCu
            //AuthorizationRules.AllowRead("MaChiTiet", "CT_DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaDieuChuyen", "CT_DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("MaCongCuDungCu", "CT_DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("LyDoDieuChuyen", "CT_DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("HienTrang", "CT_DieuChuyenNoiBoCongCuDungCuReadGroup");
            //AuthorizationRules.AllowRead("DienGiai", "CT_DieuChuyenNoiBoCongCuDungCuReadGroup");

            //AuthorizationRules.AllowWrite("MaDieuChuyen", "CT_DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("MaCongCuDungCu", "CT_DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("LyDoDieuChuyen", "CT_DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("HienTrang", "CT_DieuChuyenNoiBoCongCuDungCuWriteGroup");
            //AuthorizationRules.AllowWrite("DienGiai", "CT_DieuChuyenNoiBoCongCuDungCuWriteGroup");
        }

        #endregion //Authorization Rules

        #region Factory Methods
        public static CT_DieuChuyenNoiBoCongCuDungCu TaoMoi_CT_DieuChuyenNoiBoCongCuDungCu()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a CT_DieuChuyenNoiBoCongCuDungCu");
            return DataPortal.Create<CT_DieuChuyenNoiBoCongCuDungCu>(new CriteriaNew());
        }
        internal static CT_DieuChuyenNoiBoCongCuDungCu NewCT_DieuChuyenNoiBoCongCuDungCu()//(int maChiTiet)
        {
            //return new CT_DieuChuyenNoiBoCongCuDungCu(maChiTiet);
            return new CT_DieuChuyenNoiBoCongCuDungCu();
        }

        internal static CT_DieuChuyenNoiBoCongCuDungCu GetCT_DieuChuyenNoiBoCongCuDungCu(SafeDataReader dr)
        {
            return new CT_DieuChuyenNoiBoCongCuDungCu(dr);
        }

        private CT_DieuChuyenNoiBoCongCuDungCu()
        {

            ValidationRules.CheckRules();
            MarkAsChild();
        }
        private CT_DieuChuyenNoiBoCongCuDungCu(int maChiTiet)
        {
            this._maChiTiet = maChiTiet;
            ValidationRules.CheckRules();
            MarkAsChild();
        }

        private CT_DieuChuyenNoiBoCongCuDungCu(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods
        #region Criteria
        [Serializable()]
        private class CriteriaNew
        {
            public CriteriaNew()
            {

            }
        }
        #endregion

        #region Data Access
        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(object criteria)
        {
            if (criteria is CriteriaNew)
            {

            }
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

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
            _maChiTiet = dr.GetInt32("MaChiTiet");
            _maDieuChuyen = dr.GetInt32("MaDieuChuyen");
            _maPhanBoCu = dr.GetInt32("MaPhanBoCu");
            _maPhanBoMoi = dr.GetInt32("MaPhanBoMoi");
            _maCongCuDungCu = dr.GetInt32("MaCongCuDungCu");
            _lyDoDieuChuyen = dr.GetByte("LyDoDieuChuyen");
            if (_lyDoDieuChuyen == 1)
            {
                _khongConDung = true;
                _khongSuDung = false;
            }
            else if (_lyDoDieuChuyen == 2)
            {
                _khongConDung = false;
                _khongSuDung = true;

            }
            else
            {
                _khongConDung = false;
                _khongSuDung = false;
            }
            _hienTrang = dr.GetString("HienTrang");
            _dienGiai = dr.GetString("DienGiai");
        }

        private void FetchChildren(SafeDataReader dr)
        {
            _duyetCongCuDungCu = ERP_Library.DuyetCongCuDungCu.GetDuyetCongCuDungCu_ByMaChiTietDieuChuyenNoiBo(_maChiTiet);
            _congCuDungCu = CongCuDungCu.GetCongCuDungCu(_maCongCuDungCu);
            _congCuDungCu_PhongBan_Cu = CongCuDungCu_PhongBan.GetCongCuDungCu_PhongBan_ByMaPhanBo(_maPhanBoCu);
            _congCuDungCu_PhongBan_Moi = CongCuDungCu_PhongBan.GetCongCuDungCu_PhongBan_ByMaPhanBo(_maPhanBoMoi);
        }
        #endregion //Data Access - Fetch

        #region Data Access - Insert
        internal void Insert(SqlTransaction tr, DieuChuyenNoiBoCongCuDungCu parent)
        {
            if (!IsDirty) return;

            ExecuteInsert(tr, parent);
            MarkOld();

            //update child object(s)
            UpdateChildren(tr);
        }

        private void ExecuteInsert(SqlTransaction tr, DieuChuyenNoiBoCongCuDungCu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_InsertCT_DieuChuyenNoiBoCongCuDungCu";

                AddInsertParameters(cm, parent);

                cm.ExecuteNonQuery();
                _maChiTiet = (int)cm.Parameters["@MaChiTiet"].Value;
            }//using
        }

        private void AddInsertParameters(SqlCommand cm, DieuChuyenNoiBoCongCuDungCu parent)
        {
            //TODO: if parent use identity key, fix fk member with value from parent
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);
            cm.Parameters["@MaChiTiet"].Direction = ParameterDirection.Output;

            if (_maDieuChuyen != 0)
                cm.Parameters.AddWithValue("@MaDieuChuyen", _maDieuChuyen);
            else
                cm.Parameters.AddWithValue("@MaDieuChuyen", DBNull.Value);
            //
            if (_maPhanBoCu != 0)
                cm.Parameters.AddWithValue("@MaPhanBoCu", _maPhanBoCu);
            else
                cm.Parameters.AddWithValue("@MaPhanBoCu", DBNull.Value);
            //
            //
            if (_maPhanBoMoi != 0)
                cm.Parameters.AddWithValue("@MaPhanBoMoi", _maPhanBoMoi);
            else
                cm.Parameters.AddWithValue("@MaPhanBoMoi", DBNull.Value);
            //
            if (_maCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
            if (_lyDoDieuChuyen != 0)
                cm.Parameters.AddWithValue("@LyDoDieuChuyen", _lyDoDieuChuyen);
            else
                cm.Parameters.AddWithValue("@LyDoDieuChuyen", DBNull.Value);
            if (_hienTrang.Length > 0)
                cm.Parameters.AddWithValue("@HienTrang", _hienTrang);
            else
                cm.Parameters.AddWithValue("@HienTrang", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
        }
        #endregion //Data Access - Insert

        #region Data Access - Update
        internal void Update(SqlTransaction tr, DieuChuyenNoiBoCongCuDungCu parent)
        {
            if (!IsDirty) return;

            if (base.IsDirty)
            {
                ExecuteUpdate(tr, parent);
                MarkOld();
            }

            //update child object(s)
            UpdateChildren(tr);


        }

        private void ExecuteUpdate(SqlTransaction tr, DieuChuyenNoiBoCongCuDungCu parent)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_UpdateCT_DieuChuyenNoiBoCongCuDungCu";

                AddUpdateParameters(cm, parent);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm, DieuChuyenNoiBoCongCuDungCu parent)
        {
            cm.Parameters.AddWithValue("@MaChiTiet", _maChiTiet);


            if (_maDieuChuyen != 0)
                cm.Parameters.AddWithValue("@MaDieuChuyen", _maDieuChuyen);
            else
                cm.Parameters.AddWithValue("@MaDieuChuyen", DBNull.Value);
            //
            if (_maPhanBoCu != 0)
                cm.Parameters.AddWithValue("@MaPhanBoCu", _maPhanBoCu);
            else
                cm.Parameters.AddWithValue("@MaPhanBoCu", DBNull.Value);
            //
            //
            if (_maPhanBoMoi != 0)
                cm.Parameters.AddWithValue("@MaPhanBoMoi", _maPhanBoMoi);
            else
                cm.Parameters.AddWithValue("@MaPhanBoMoi", DBNull.Value);
            //
            if (_maCongCuDungCu != 0)
                cm.Parameters.AddWithValue("@MaCongCuDungCu", _maCongCuDungCu);
            else
                cm.Parameters.AddWithValue("@MaCongCuDungCu", DBNull.Value);
            if (_lyDoDieuChuyen != 0)
                cm.Parameters.AddWithValue("@LyDoDieuChuyen", _lyDoDieuChuyen);
            else
                cm.Parameters.AddWithValue("@LyDoDieuChuyen", DBNull.Value);
            if (_hienTrang.Length > 0)
                cm.Parameters.AddWithValue("@HienTrang", _hienTrang);
            else
                cm.Parameters.AddWithValue("@HienTrang", DBNull.Value);
            if (_dienGiai.Length > 0)
                cm.Parameters.AddWithValue("@DienGiai", _dienGiai);
            else
                cm.Parameters.AddWithValue("@DienGiai", DBNull.Value);
        }

        private void UpdateChildren(SqlTransaction tr)
        {


            if (_congCuDungCu_PhongBan_Cu != null
                && _congCuDungCu_PhongBan_Moi != null
                && _duyetCongCuDungCu !=null
               )
            {
                //
                _duyetCongCuDungCu.DaThucHienNghiepVu = true;
                _duyetCongCuDungCu.MaChiTietDieuChuyenNoiBo = _maChiTiet;
                _duyetCongCuDungCu.Update(tr, null);
                //
                _congCuDungCu_PhongBan_Cu.Update(tr, null);

                if (_congCuDungCu_PhongBan_Moi.IsNew)
                    _congCuDungCu_PhongBan_Moi.Insert(tr, null);
                else
                    _congCuDungCu_PhongBan_Moi.Update(tr, null);
                //
                //gan them thong tin
                _maPhanBoCu = _congCuDungCu_PhongBan_Cu.MaPhanBo;
                _maPhanBoMoi = _congCuDungCu_PhongBan_Moi.MaPhanBo;
                //update lai chi tiet dieu chuyen
                ExecuteUpdate(tr, null);
            }


        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;
        
            CapNhatChildTruocKhiXoaChiTietDieuChuyenNoiBo(tr);
            ExecuteDelete(tr);
            DeleteChild_SauKhiXoaChiTietDieuChuyenNoiBo(tr);//truong hop dat biet phai dat phia sau ExecuteDelete
            MarkNew();
        }
        private void CapNhatChildTruocKhiXoaChiTietDieuChuyenNoiBo(SqlTransaction tr)
        {    //truoc khi xoa phai thay doi chut thong tin
            //trong tblDuyetCongCuDungCu
            _duyetCongCuDungCu.DaThucHienNghiepVu = false;
            _duyetCongCuDungCu.MaChiTietDieuChuyenNoiBo = 0;
            _duyetCongCuDungCu.Update(tr, null);
        }
        private void DeleteChild_SauKhiXoaChiTietDieuChuyenNoiBo(SqlTransaction tr)
        {
            _congCuDungCu_PhongBan_Cu.DenNgay = DateTime.MinValue;//empty is min
            _congCuDungCu_PhongBan_Cu.Update(tr, null);//cap nhat lai phong ban cu
            _congCuDungCu_PhongBan_Moi.DeleteSelf(tr);//xoa phan bo phong ban moi
           
        }
        private void ExecuteDelete(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_DeleteCT_DieuChuyenNoiBoCongCuDungCu";

                cm.Parameters.AddWithValue("@MaChiTiet", this._maChiTiet);

                cm.ExecuteNonQuery();
            }//using
        }
        #endregion //Data Access - Delete
        #endregion //Data Access
    }
}
