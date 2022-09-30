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
    public class NghiepVuDieuChuyenNgoai : BusinessBase<NghiepVuDieuChuyenNgoai>
    {
        protected override object GetIdValue()
        {
            return _MaNghiepVuThanhLy;
        }

        #region rule
        protected override void AddBusinessRules()
        {

            ValidationRules.AddRule(Csla.Validation.CommonRules.IntegerMinValue, new Csla.Validation.CommonRules.IntegerMinValueRuleArgs("MaChungTu", 1));

            ValidationRules.AddRule(Csla.Validation.CommonRules.IntegerMinValue, new Csla.Validation.CommonRules.IntegerMinValueRuleArgs("MaTSCDCaBiet", 1));
            //ValidationRules.AddRule(KiemTraTextDecimal, "ChiPhiThanhLy");
            //ValidationRules.AddRule(KiemTraTextDatetime, "NgayThucHien");
        }

        private bool KiemTraTextDecimal(object target, Csla.Validation.RuleArgs e)
        {
            if (_ChiPhiThanhLy == 0)
            {
                e.Description = "Vui Lòng Nhập Thành Tiền Cho Phí Thanh  Lý";
                return false;
            }
            else
                return true;
        }

        private bool KiemTraTextDatetime(object target, Csla.Validation.RuleArgs e)
        {
            if (_NgayThucHien == null)
            {
                e.Description = "Vui Lòng Nhập Ngày Thực Hiện";
                return false;
            }
            else
                return true;
        }
        #endregion

        #region Properties

        int _MaNghiepVuThanhLy;
        public int MaNghiepVuThanhLy
        {
            get
            {
                CanReadProperty(true);
                return _MaNghiepVuThanhLy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNghiepVuThanhLy.Equals(value))
                {
                    _MaNghiepVuThanhLy = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _ChiPhiThanhLy;
        public Decimal ChiPhiThanhLy
        {
            get
            {
                CanReadProperty(true);
                return _ChiPhiThanhLy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ChiPhiThanhLy.Equals(value))
                {
                    _ChiPhiThanhLy = value;
                    PropertyHasChanged();
                }
            }
        }

        String _LyDo;
        public String LyDo
        {
            get
            {
                CanReadProperty(true);
                return _LyDo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LyDo.Equals(value))
                {
                    _LyDo = value;
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
        enumLoaiPhanBiet _LoaiPhanBiet;
        public enumLoaiPhanBiet LoaiPhanBiet
        {
            get
            {
                CanReadProperty(true);
                return _LoaiPhanBiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LoaiPhanBiet.Equals(value))
                {
                    _LoaiPhanBiet = value;
                    PropertyHasChanged();
                }
            }
        }

        TaiSanCoDinhCaBietList _DanhSachTSCDCaBiet;
        public TaiSanCoDinhCaBietList DanhSachTSCDCaBiet
        {
            get
            {
                CanReadProperty(true);
                return _DanhSachTSCDCaBiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DanhSachTSCDCaBiet.Equals(value))
                {
                    _DanhSachTSCDCaBiet = value;
                    PropertyHasChanged();
                }
            }
        }

        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaNghiepVuThanhLy;

            public Criteria(int maNghiepVuThanhLy)
            {
                MaNghiepVuThanhLy = maNghiepVuThanhLy;
            }
        }

        private class CriteriaThanhLyByChungTu
        {
            private int _MaChungTu;
            public int MaChungTu
            {
                get { return _MaChungTu; }
            }

            public CriteriaThanhLyByChungTu(int maChungTu)
            {
                _MaChungTu = maChungTu;
            }
            //hong làm gì hêt
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

        public NghiepVuDieuChuyenNgoai(SafeDataReader dr)
        {
            // MarkAsChild();
            try
            {
                _MaNghiepVuThanhLy = dr.GetInt32("MaNghiepVuThanhLy");
                _ChiPhiThanhLy = dr.GetDecimal("ChiPhiThanhLy");
                _LyDo = dr.GetString("LyDo");
                _NgayThucHien = dr.GetDateTime("NgayThucHien");
                _ChungTu = ChungTu.GetChungTu(dr.GetInt64("MaChungTu"));
                _DanhSachTSCDCaBiet = TaiSanCoDinhCaBietList.GetTSCDCaBietCanThanhLy0_DieuChuyen1(1);
                if (dr.GetBoolean("LoaiPhanBiet"))
                    _LoaiPhanBiet = enumLoaiPhanBiet.DieuChuyenNgoai;
                else
                {
                    _LoaiPhanBiet = enumLoaiPhanBiet.ThanLy;
                }
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static NghiepVuDieuChuyenNgoai NewDieuChuyenNgoai()
        {
            return new NghiepVuDieuChuyenNgoai();
        }

        public static NghiepVuDieuChuyenNgoai NewDieuChuyenNgoaiParent()
        {
            NghiepVuDieuChuyenNgoai NghiepVuDieuChuyenNgoai = new NghiepVuDieuChuyenNgoai();
            //NghiepVuDieuChuyenNgoai.ValidationRules.CheckRules();            
            return NghiepVuDieuChuyenNgoai;
        }

        public static NghiepVuDieuChuyenNgoai NewDieuChuyenNgoai(int maNghiepVuThanhLy, int maTSCDCaBiet, Decimal chiPhiThanhLy, string lyDo, DateTime ngayThucHien, Int32 maChungTu, enumLoaiPhanBiet loaiPhanBiet)
        {
            NghiepVuDieuChuyenNgoai tlts = new NghiepVuDieuChuyenNgoai();
            tlts._MaNghiepVuThanhLy = maNghiepVuThanhLy;
            tlts._NgayThucHien = ngayThucHien;
            tlts._ChiPhiThanhLy = chiPhiThanhLy;
            tlts._LyDo = lyDo;
            tlts._LoaiPhanBiet = loaiPhanBiet;
            tlts.MarkDirty();
            tlts.ValidationRules.CheckRules();
            return tlts;
        }

        public static NghiepVuDieuChuyenNgoai GetDieuChuyenNgoai(int maNghiepVuThanhLy)
        {
            return (NghiepVuDieuChuyenNgoai)DataPortal.Fetch<NghiepVuDieuChuyenNgoai>(new Criteria(maNghiepVuThanhLy));
        }

        public static NghiepVuDieuChuyenNgoai GetDieuChuyenNgoaiByChungTu(int maChungTu)
        {
            return (NghiepVuDieuChuyenNgoai)DataPortal.Fetch<NghiepVuDieuChuyenNgoai>(new CriteriaThanhLyByChungTu(maChungTu));
        }

        public static NghiepVuDieuChuyenNgoai GetDieuChuyenNgoai(SafeDataReader dr)
        {
            return new NghiepVuDieuChuyenNgoai(dr);
        }

        public static void DeleteDieuChuyenNgoai(int maNghiepVuThanhly)
        {
            DataPortal.Delete(new Criteria(maNghiepVuThanhly));
        }

        #endregion

        #region Constructors

        private NghiepVuDieuChuyenNgoai()
        {
            // Prevent direct creation
            _MaNghiepVuThanhLy = 0;
            _NgayThucHien = DateTime.Today;
            _ChiPhiThanhLy = 0;
            _LyDo = String.Empty;
            _ChungTu = ChungTu.NewChungTu(12);
            //  _DanhSachTSCDCaBiet = TaiSanCoDinhCaBietList.GetTSCDCaBietCanThanhLy(1);
            _DanhSachTSCDCaBiet = new TaiSanCoDinhCaBietList();
            _LoaiPhanBiet = enumLoaiPhanBiet.ThanLy;
        }

        #endregion

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _DanhSachTSCDCaBiet.IsDirty || _ChungTu.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid || _DanhSachTSCDCaBiet.IsValid || _ChungTu.IsDirty;
            }
        }
        #endregion

        #region Data Access

        #region load tất cả cả


        private void Update_DanhSachTSCDCaBiet()
        {

            foreach (TSCDCaBiet TaiSanCoDinhCaBiet in _DanhSachTSCDCaBiet)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {

                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_Update_TSCDCaBietNghiepVuDieuChuyenNgoai";
                            cm.Parameters.AddWithValue("@MaNghiepVuThanhLy", _MaNghiepVuThanhLy);
                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", TaiSanCoDinhCaBiet.MaTSCDCaBiet);
                            cm.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        private void Update_DanhSachTSCDCaBietTranSacTion(SqlTransaction tr)
        {

            foreach (TSCDCaBiet TaiSanCoDinhCaBiet in _DanhSachTSCDCaBiet)
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Update_TSCDCaBietNghiepVuDieuChuyenNgoai";
                    cm.Parameters.AddWithValue("@MaNghiepVuThanhLy", _MaNghiepVuThanhLy);
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", TaiSanCoDinhCaBiet.MaTSCDCaBiet);
                    cm.ExecuteNonQuery();
                }

            }
        }



        protected override void DataPortal_Fetch(object criteria)
        {
            try
            {
                if (criteria is Criteria)
                {
                    Criteria crit = (Criteria)criteria;
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LoadMaCaBiet_NghiepVuDieuChuyenNgoai";
                            cm.Parameters.AddWithValue("@MaNghiepVuThanhLy", crit.MaNghiepVuThanhLy);

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    _MaNghiepVuThanhLy = dr.GetInt32("MaNghiepVuThanhLy");
                                    _NgayThucHien = dr.GetDateTime("NgayThucHien");
                                    _ChiPhiThanhLy = dr.GetDecimal("ChiPhiThanhLy");
                                    _LyDo = dr.GetString("LyDo");
                                    _ChungTu = ChungTu.GetChungTu(dr.GetInt64("MaChungTu"));
                                    _LoaiPhanBiet = (enumLoaiPhanBiet)dr.GetValue("LoaiPhanBiet");
                                    _DanhSachTSCDCaBiet = TaiSanCoDinhCaBietList.GetTSCDCaBietCanThanhLy0_DieuChuyen1(1);
                                    // load child objects
                                    dr.NextResult();
                                }
                            }
                        }
                        MarkOld();
                    }
                }
                else if (criteria is CriteriaThanhLyByChungTu)
                {
                    CriteriaThanhLyByChungTu crit = (CriteriaThanhLyByChungTu)criteria;
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = " spd_LoadDieuChuyenNgoaiByChungTu";
                            cm.Parameters.AddWithValue("@MaChungTu", crit.MaChungTu);

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    _MaNghiepVuThanhLy = dr.GetInt32("MaNghiepVuThanhLy");
                                    _NgayThucHien = dr.GetDateTime("NgayThucHien");
                                    _ChiPhiThanhLy = dr.GetDecimal("ChiPhiThanhLy");
                                    _LyDo = dr.GetString("LyDo");
                                    _LoaiPhanBiet = (enumLoaiPhanBiet)dr.GetValue("LoaiPhanBiet");
                                    // load child objects
                                    dr.NextResult();
                                }
                            }
                        }
                        MarkOld();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        _ChungTu.ApplyEdit();
                        _ChungTu.InsertTranSacTion(tr);
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_NghiepVuThanhLy";

                        cm.Parameters.AddWithValue("@MaNghiepvuThanhLy", _MaNghiepVuThanhLy).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                        if (_ChiPhiThanhLy == 0)
                        {
                            cm.Parameters.AddWithValue("@ChiPhiThanhLy", DBNull.Value);
                        }
                        else
                            cm.Parameters.AddWithValue("@ChiPhiThanhLy", _ChiPhiThanhLy);
                        cm.Parameters.AddWithValue("@LyDo", _LyDo);
                        if (_ChungTu.MaChungTu != 0)
                        {
                            cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                        }
                        else cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", enumLoaiPhanBiet.DieuChuyenNgoai);
                        cm.ExecuteNonQuery();
                        _MaNghiepVuThanhLy = (int)cm.Parameters["@MaNghiepvuThanhLy"].Value;
                        Update_DanhSachTSCDCaBietTranSacTion(tr);
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
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Update_NghiepVuThanhLy";
                        cm.Parameters.AddWithValue("@MaNghiepvuThanhLy", _MaNghiepVuThanhLy);
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                        cm.Parameters.AddWithValue("@ChiPhiThanhLy", _ChiPhiThanhLy);
                        cm.Parameters.AddWithValue("@LyDo", _LyDo);
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", enumLoaiPhanBiet.DieuChuyenNgoai);
                        cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu).Direction = ParameterDirection.Output;

                        cm.ExecuteNonQuery();
                        // _ChungTu = ChungTu.GetChungTu((int)(cm.Parameters["@MaChungTu"].Value));
                        _ChungTu.ApplyEdit();
                        _ChungTu.UpdateTranSacTion(tr);
                        Update_DanhSachTSCDCaBietTranSacTion(tr);
                        // make sure we're marked as an old object
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
