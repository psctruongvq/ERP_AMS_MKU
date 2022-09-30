using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class SuaChuaLon : BusinessBase<SuaChuaLon>
    {
        protected override object GetIdValue()
        {
            return _MaNghiepVuSuaChuaLon;
        }

        #region rule
        protected override void AddBusinessRules()
        {

            ValidationRules.AddRule(Csla.Validation.CommonRules.IntegerMinValue, new Csla.Validation.CommonRules.IntegerMinValueRuleArgs("MaChungTu", 1));
            ValidationRules.AddRule(KiemTraTextDecimal, "TongTien");
        }

        private bool KiemTraTextDecimal(object target, Csla.Validation.RuleArgs e)
        {
            if (_TongTien == 0)
            {
                e.Description = "Vui Lòng Nhập Chi Phí Sửa Chữa";
                return false;
            }
            else
                return true;
        }

        #endregion

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _ChiTietSuaChuaLonList.IsDirty || _TSCDCaBiet.IsDirty || _ChungTu.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid || _ChiTietSuaChuaLonList.IsValid || _TSCDCaBiet.IsValid || _ChungTu.IsValid;
            }
        }
        #endregion

        #region Khai Bao Bien

        int _MaNghiepVuSuaChuaLon;
        public int MaNghiepVuSuaChuaLon
        {
            get
            {
                CanReadProperty(true);
                return _MaNghiepVuSuaChuaLon;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNghiepVuSuaChuaLon.Equals(value))
                {
                    _MaNghiepVuSuaChuaLon = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _TuNgay;
        public DateTime TuNgay
        {
            get
            {
                CanReadProperty(true);
                return _TuNgay;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TuNgay.Equals(value))
                {
                    _TuNgay = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _DenNgay;
        public DateTime DenNgay
        {
            get
            {
                CanReadProperty(true);
                return _DenNgay;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DenNgay.Equals(value))
                {
                    _DenNgay = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _TongTien;
        public Decimal TongTien
        {
            get
            {
                CanReadProperty(true);
                return _TongTien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TongTien.Equals(value))
                {
                    _TongTien = value;
                    _VietBangChu = HamDungChung.DocTien(value);
                    _ChungTu.Tien.SoTien = value;
                    PropertyHasChanged();
                }
            }
        }

        string _VietBangChu;
        public string VietBangChu
        {
            get
            {
                CanReadProperty(true);
                return _VietBangChu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_VietBangChu.Equals(value))
                {
                    _VietBangChu = value;
                    PropertyHasChanged();
                }
            }
        }

        TSCDCaBiet _TSCDCaBiet;
        public TSCDCaBiet TSCDCaBiet
        {
            get
            {
                CanReadProperty(true);
                return _TSCDCaBiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TSCDCaBiet.Equals(value))
                {
                    _TSCDCaBiet = value;
                    PropertyHasChanged();
                }
            }
        }

        ChungTu _ChungTu;
        public ChungTu ChungTu
        {
            get
            {
                CanReadProperty(true);
                return _ChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChungTu.Equals(value))
                {
                    _ChungTu = value;
                    PropertyHasChanged();
                }
            }
        }

        ChiTietSuaChuaLonList _ChiTietSuaChuaLonList = ChiTietSuaChuaLonList.NewChiTietSuaChuaLonList();
        public ChiTietSuaChuaLonList ChiTietSuaChuaLon
        {
            get
            {
                CanReadProperty(true);
                return _ChiTietSuaChuaLonList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChiTietSuaChuaLonList.Equals(value))
                {
                    _ChiTietSuaChuaLonList = value;
                    _ChiTietSuaChuaLonList.MaSuaChuaLon = _MaNghiepVuSuaChuaLon;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _NgayThucHien;
        public DateTime NgayThucHien
        {
            get
            {
                CanReadProperty(true);
                return _NgayThucHien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayThucHien.Equals(value))
                {
                    _NgayThucHien = value;
                    PropertyHasChanged();
                }
            }
        }

        #endregion

        #region Static Methods

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }

        private SuaChuaLon(SafeDataReader dr)
        {
            try
            {
                //if (dr.Read())
                //{
                //  MarkAsChild();

                _MaNghiepVuSuaChuaLon = dr.GetInt32("MaNghiepVuSuaChuaLon");
                _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("TSCDCaBiet"));
                _TuNgay = dr.GetDateTime("TuNgay");
                _DenNgay = dr.GetDateTime("DenNgay");
                _TongTien = dr.GetDecimal("TongTien");
                _VietBangChu = dr.GetString("VietBangChu");

                _ChungTu = ChungTu.GetChungTu(dr.GetInt64("MaChungTu"));
                _NgayThucHien = dr.GetDateTime("NgayThucHien");
                _ChiTietSuaChuaLonList = ChiTietSuaChuaLonList.GetChiTietSuaChuaLonList(_MaNghiepVuSuaChuaLon);
                MarkOld();
                // }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SuaChuaLon NewSuaChuaLon()
        {
            return new SuaChuaLon();
        }

        public static SuaChuaLon NewSuaChuaLonParent()
        {
            try
            {
                SuaChuaLon suaChuaLon = new SuaChuaLon();
                //suaChuaLon.ValidationRules.CheckRules();
                return suaChuaLon;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SuaChuaLon NewSuaChuaLonParent(TSCDCaBiet tscdCaBiet)
        {
            SuaChuaLon suaChuaLon = new SuaChuaLon();
            suaChuaLon.TSCDCaBiet = tscdCaBiet;
            suaChuaLon.ValidationRules.CheckRules();
            return suaChuaLon;
        }

        public static SuaChuaLon NewSuaChuaLon(int maNghiepVuSuaChuaLon, int maTSCDCaBiet, DateTime tuNgay, DateTime denNgay, string vietBangChu, DateTime ngayThucHien, Int32 maChungTu)
        {
            SuaChuaLon scl = new SuaChuaLon();
            scl._MaNghiepVuSuaChuaLon = maNghiepVuSuaChuaLon;
            scl._TuNgay = tuNgay;
            scl._DenNgay = denNgay;
            scl._TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(maTSCDCaBiet);
            scl._VietBangChu = vietBangChu;
            scl._NgayThucHien = ngayThucHien;
            scl._ChungTu = ChungTu.GetChungTu(maChungTu);
            scl.MarkDirty();
            scl.ValidationRules.CheckRules();
            return scl;
        }

        public static SuaChuaLon GetSuaChuaLon(int maNghiepVuSuaChuaLon)
        {
            return (SuaChuaLon)DataPortal.Fetch<SuaChuaLon>(new Criteria(maNghiepVuSuaChuaLon));
        }

        public static SuaChuaLon GetSuaChuaLon(SafeDataReader dr)
        {
            return new SuaChuaLon(dr);
        }

        public static void DeleteSuaChuaLon(int maNghiepVuSuaChuaLon)
        {
            DataPortal.Delete(new Criteria(maNghiepVuSuaChuaLon));
        }

        #endregion

        #region Constructors

        private SuaChuaLon()
        {
            // Prevent direct creation
            _MaNghiepVuSuaChuaLon = 0;
            _TuNgay = DateTime.Today;
            _DenNgay = DateTime.Today;
            _TSCDCaBiet = TSCDCaBiet.NewTSCDCaBiet();
            _TongTien = 0;
            _VietBangChu = String.Empty;
            _NgayThucHien = DateTime.Today;
            _ChungTu = ChungTu.NewChungTu(11);
            _ChiTietSuaChuaLonList.MaSuaChuaLon = this._MaNghiepVuSuaChuaLon;
        }

        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaNghiepVuSuaChualon;

            public Criteria(int maNghiepVuSuaChualon)
            {
                MaNghiepVuSuaChualon = maNghiepVuSuaChualon;
            }
        }

        #endregion

        #region Data Access

        #region load tất cả cả
        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadMaCaBiet_NghiepVuSuaChuaLon";
                    cm.Parameters.AddWithValue("@MaNghiepVuSuaChuaLon", crit.MaNghiepVuSuaChualon);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            _MaNghiepVuSuaChuaLon = dr.GetInt32("MaNghiepVuSuaChuaLon");
                            _TuNgay = dr.GetDateTime("TuNgay");
                            _DenNgay = dr.GetDateTime("DenNgay");
                            _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("TSCDCaBiet"));
                            _TongTien = dr.GetDecimal("TongTien");
                            _VietBangChu = dr.GetString("VietBangChu");
                            _NgayThucHien = dr.GetDateTime("NgayThucHien");
                            // load child objects
                            _ChiTietSuaChuaLonList = ChiTietSuaChuaLonList.GetChiTietSuaChuaLonList(_MaNghiepVuSuaChuaLon);
                            //Lụi
                            this.ChiTietSuaChuaLon.MaSuaChuaLon = _MaNghiepVuSuaChuaLon;
                            dr.NextResult();
                        }
                    }
                }
                MarkOld();
            }
        }


        protected override void DataPortal_Insert()
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
                        _ChungTu.ApplyEdit();
                        _ChungTu.InsertTranSacTion(tr);
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_NghiepVuSuaChuaLon";
                        cm.Parameters.AddWithValue("@MaNghiepVuSuaChuaLon", _MaNghiepVuSuaChuaLon).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TSCDCaBiet.MaTSCDCaBiet);
                        cm.Parameters.AddWithValue("@TongTien", _TongTien);
                        cm.Parameters.AddWithValue("@VietBangChu", _VietBangChu);
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                        cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                        cm.ExecuteNonQuery();
                        _MaNghiepVuSuaChuaLon = (int)cm.Parameters["@MaNghiepVuSuaChuaLon"].Value;
                        //Lụi
                        _ChiTietSuaChuaLonList.MaSuaChuaLon = _MaNghiepVuSuaChuaLon;
                        //quoc Long Bổ sung he he he
                        TSCDCaBiet.DataPortal_Update_SuaChuaLon(tr, _TSCDCaBiet.MaTSCDCaBiet, _TSCDCaBiet.NguyenGiaConLai + _TongTien, _TSCDCaBiet.NguyenGiaConLai + _TongTien);
                        this.ChiTietSuaChuaLon.DataPortal_UpdateTranSacTion(tr);
                        tr.Commit();
                        MarkOld();
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }

        }

        protected override void DataPortal_Update()
        {
            // save data into db
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
                        _ChungTu.ApplyEdit();
                        _ChungTu.DataPortal_UpdateTranSacTion(tr);
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Update_NghiepVuSuaChuaLon";
                        cm.Parameters.AddWithValue("@MaNghiepVuSuaChuaLon", _MaNghiepVuSuaChuaLon);
                        cm.Parameters.AddWithValue("@TuNgay", _TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", _DenNgay);
                        cm.Parameters.AddWithValue("@TSCDCaBiet", _TSCDCaBiet.MaTSCDCaBiet);
                        cm.Parameters.AddWithValue("@TongTien", _TongTien);
                        cm.Parameters.AddWithValue("@VietBangChu", _VietBangChu);
                        cm.ExecuteNonQuery();
                        _ChiTietSuaChuaLonList.MaSuaChuaLon = _MaNghiepVuSuaChuaLon;
                        _ChiTietSuaChuaLonList.DataPortal_UpdateTranSacTion(tr);
                        //quoc Long Bổ sung he he he
                        TSCDCaBiet.DataPortal_Update_SuaChuaLon(tr, _TSCDCaBiet.MaTSCDCaBiet, _TSCDCaBiet.NguyenGiaConLai + _TongTien, _TSCDCaBiet.NguyenGiaConLai + _TongTien);
                        tr.Commit();
                        MarkOld();
                    }
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
        }

        #endregion

         #endregion
     
    }
}
