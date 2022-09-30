using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class DanhGiaLai : BusinessBase<DanhGiaLai>
    {
        protected override object GetIdValue()
        {
            return _MaNghiepVuDanhGiaLai;
        }

        #region Properties

        private void TinhLaiNguyenGiaMoi()
        {
            _NguyenGiaMoi = _TSCDCaBiet.NguyenGiaConLai - _GiaTriGiam + _GiaTriTang;
            _VietBangChu = HamDungChung.DocTien((decimal)_NguyenGiaMoi);
        }

        int _MaNghiepVuDanhGiaLai;
        public int MaNghiepVuDanhGiaLai
        {
            get
            {
                CanReadProperty(true);
                return _MaNghiepVuDanhGiaLai;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNghiepVuDanhGiaLai.Equals(value))
                {
                    _MaNghiepVuDanhGiaLai = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _GiaTriTang;
        public Decimal GiaTriTang
        {
            get
            {
                CanReadProperty(true);
                return _GiaTriTang;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GiaTriTang.Equals(value))
                {
                    _GiaTriTang = value;
                    _NguyenGiaMoi = _TSCDCaBiet.NguyenGiaTinhKhauHao + _GiaTriTang;
                    _VietBangChu = HamDungChung.DocTien((decimal)_GiaTriTang);
                    PropertyHasChanged();
                }
            }
        }

        Decimal _TyLeKhauHaoMoi;
        public Decimal TyLeKhauHaoMoi
        {
            get
            {
                CanReadProperty(true);
                //return _TSCDCaBiet.TyLeKhauHaoNam;
                return _TyLeKhauHaoMoi;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TyLeKhauHaoMoi.Equals(value))
                {
                    _TyLeKhauHaoMoi = value;
                    //_TSCDCaBiet.TyLeKhauHaoNam = _TyLeKhauHaoMoi;
                    ////_TyLeKhauHaoMoi = _TSCDCaBiet.TyLeKhauHaoNam;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _GiaTriGiam;
        public Decimal GiaTriGiam
        {
            get
            {
                CanReadProperty(true);
                return _GiaTriGiam;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GiaTriGiam.Equals(value))
                {
                    _GiaTriGiam = value;
                    //TinhLaiNguyenGiaMoi();
                    _NguyenGiaMoi = _TSCDCaBiet.NguyenGiaTinhKhauHao - _GiaTriGiam;
                    _VietBangChu = HamDungChung.DocTien((decimal)_GiaTriGiam);
                    PropertyHasChanged();
                }
            }
        }

        Decimal _NguyenGiaMoi;
        public Decimal NguyenGiaMoi
        {
            get
            {
                CanReadProperty(true);
                //return _NguyenGiaMoi;
                return _NguyenGiaMoi;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NguyenGiaMoi.Equals(value))
                {
                    _NguyenGiaMoi = value;
                    //  _VietBangChu = TienTe.moneyToText(((long)_NguyenGiaMoi).ToString());
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

        String _VietBangChu;
        public String VietBangChu
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

        TSCDCaBiet _TSCDCaBiet = TSCDCaBiet.NewTSCDCaBiet();
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
                    _NguyenGiaMoi = _TSCDCaBiet.NguyenGiaTinhKhauHao;
                    //_TyLeKhauHaoMoi = _TSCDCaBiet.TyLeKhauHaoNam; // 07-04-2009
                    PropertyHasChanged();
                }
            }
        }

        int _ThoiGianTang;
        public int ThoiGianTang
        {
            get
            {
                CanReadProperty(true);
                return _ThoiGianTang;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ThoiGianTang.Equals(value))
                {
                    _ThoiGianTang = value;
                    PropertyHasChanged();
                }
            }
        }

        int _ThoiGianGiam;
        public int ThoiGianGiam
        {
            get
            {
                CanReadProperty(true);
                return _ThoiGianGiam;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ThoiGianGiam.Equals(value))
                {
                    _ThoiGianGiam = value;
                    PropertyHasChanged();
                }
            }
        }

        int _ThoiGianSuDung;
        public int ThoiGianSuDung
        {
            get
            {
                CanReadProperty(true);
                return _ThoiGianSuDung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ThoiGianSuDung.Equals(value))
                {
                    _ThoiGianSuDung = value;
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

        #endregion

        #region Contructors
        private DanhGiaLai()
        {
            _GiaTriGiam = 0;
            _GiaTriTang = 0;
            _LyDo = String.Empty;
            _MaNghiepVuDanhGiaLai = 0;
            _NgayThucHien = DateTime.Today;
            _NguyenGiaMoi = 0;
            _TSCDCaBiet = TSCDCaBiet.NewTSCDCaBiet();
            _TyLeKhauHaoMoi = 0;
            _VietBangChu = String.Empty;
            _ThoiGianGiam = 0;
            _ThoiGianSuDung = 0;
            _ThoiGianTang = 0;
            _ChungTu = ChungTu.NewChungTu();
            //  MarkAsChild();
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
        public override DanhGiaLai Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNghiepVuDanhGiaLai));
        }
        private DanhGiaLai(SafeDataReader dr)
        {
            //MarkAsChild();
            _MaNghiepVuDanhGiaLai = dr.GetInt32("MaNghiepVuDanhGiaLai");
            _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
            _GiaTriTang = dr.GetDecimal("GiaTriTang");
            _GiaTriGiam = dr.GetDecimal("GiaTriGiam");
            _TyLeKhauHaoMoi = dr.GetDecimal("TyLeKhauHaoMoi");
            _NguyenGiaMoi = dr.GetDecimal("NguyenGiaMoi");
            _VietBangChu = dr.GetString("VietBangChu");
            _LyDo = dr.GetString("LyDo");
            _NgayThucHien = dr.GetDateTime("NgayThucHien");
            _ThoiGianGiam = dr.GetInt32("ThoiGianGiam");
            _ThoiGianTang = dr.GetInt32("ThoiGianTang");
            _ThoiGianSuDung = dr.GetInt32("ThoiGianSuDung");
            MarkOld();
        }

        public static DanhGiaLai NewDanhGiaLai()
        {
            //return (NhanVien)DataPortal.Create(new Criteria());
            return new DanhGiaLai();
        }

        public static DanhGiaLai NewDanhGiaLaiParent()
        {
            DanhGiaLai danhGiaLai = new DanhGiaLai();
            danhGiaLai.MarkNew();
            return new DanhGiaLai();
        }

        public static DanhGiaLai GetDanhGiaLai(int maDanhGiaLai)
        {
            return (DanhGiaLai)DataPortal.Fetch<DanhGiaLai>(new Criteria(maDanhGiaLai));
        }


        public static DanhGiaLai GetNghiepVuDanhGiaLaiTheoChungTu(long maChungTu)
        {
            return (DanhGiaLai)DataPortal.Fetch<DanhGiaLai>(new CriteriaByMaChungTu(maChungTu));
        }
        public static DanhGiaLai NewDanhGiaLai(Decimal giaTriGiam, Decimal giaTriTang, String lyDo,
                int maChungTu, int maNghiepVu, DateTime ngayThucHien, Decimal nguyenGiaMoi, int tscdCaBiet,
                    Decimal tyLeKhauHaoMoi, String vietbangChu)
        {
            DanhGiaLai dg = new DanhGiaLai();
            dg._GiaTriGiam = giaTriGiam;
            dg._GiaTriTang = giaTriTang;
            dg._LyDo = lyDo;
            dg._MaNghiepVuDanhGiaLai = maNghiepVu;
            dg._NgayThucHien = ngayThucHien;
            dg._NguyenGiaMoi = nguyenGiaMoi;
            dg._TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(tscdCaBiet);
            dg._TyLeKhauHaoMoi = tyLeKhauHaoMoi;
            dg._VietBangChu = vietbangChu;
            return dg;
        }
        internal static DanhGiaLai GetDanhGiaLai(SafeDataReader dr)
        {
            return new DanhGiaLai(dr);
        }
        public static void DeleteDanhGiaLai(int maDanhGiaLai)
        {
            DataPortal.Delete(new Criteria(maDanhGiaLai));
        }

        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaDanhGiaLai;

            public Criteria(int maDanhGiaLai)
            {
                MaDanhGiaLai = maDanhGiaLai;
            }
        }

        private class CriteriaByMaChungTu
        {
            // Add criteria here
            public long MaChungTu;

            public CriteriaByMaChungTu(long maChungTu)
            {
                MaChungTu = maChungTu;
            }
        }


        #endregion

        #region Data Access

        protected override void DataPortal_Fetch(object criteria)
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
                        cm.CommandText = "spd_LoadMaCaBiet_NghiepVuDanhGiaLai";
                        cm.Parameters.AddWithValue("@MaNghiepVuDanhGiaLai", crit.MaDanhGiaLai);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaNghiepVuDanhGiaLai = dr.GetInt32("MaNghiepVuDanhGiaLai");
                                _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                                _GiaTriTang = dr.GetDecimal("GiaTriTang");
                                _GiaTriGiam = dr.GetDecimal("GiaTriGiam");
                                _TyLeKhauHaoMoi = dr.GetDecimal("TyLeKhauHaoMoi");
                                _NguyenGiaMoi = dr.GetDecimal("NguyenGiaMoi");
                                _VietBangChu = dr.GetString("VietBangChu");
                                _LyDo = dr.GetString("LyDo");
                                _NgayThucHien = dr.GetDateTime("NgayThucHien");
                                _ThoiGianGiam = dr.GetInt32("ThoiGianGiam");
                                _ThoiGianTang = dr.GetInt32("ThoiGianTang");
                                _ThoiGianSuDung = dr.GetInt32("ThoiGianSuDung");
                                // _TSCDCaBiet.NguyenGiaTinhKhauHao = TSCDCaBiet.NguyenGiaTinhKhauHao + GiaTriTang - GiaTriGiam;


                                // load child objects
                                dr.NextResult();
                            }
                        }
                    }
                    MarkOld();
                }
            }
            if (criteria is CriteriaByMaChungTu)
            {
                CriteriaByMaChungTu crit = (CriteriaByMaChungTu)criteria;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_NghiepVuDanhGiaLaiTheoChungTu";
                            cm.Parameters.AddWithValue("@MaChungTu", crit.MaChungTu);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    _MaNghiepVuDanhGiaLai = dr.GetInt32("MaNghiepVuDanhGiaLai");
                                    _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                                    _GiaTriTang = dr.GetDecimal("GiaTriTang");
                                    _GiaTriGiam = dr.GetDecimal("GiaTriGiam");
                                    _VietBangChu = dr.GetString("VietBangChu");
                                    _LyDo = dr.GetString("LyDo");
                                    _NgayThucHien = dr.GetDateTime("NgayThucHien");
                                    _ThoiGianGiam = dr.GetByte("ThoiGianGiam");
                                    _ThoiGianTang = dr.GetByte("ThoiGianTang");
                                    _ThoiGianSuDung = dr.GetByte("ThoiGianSuDung");
                                    _ChungTu = ChungTu.GetChungTu(dr.GetInt64("MaChungTu"));
                                    _NguyenGiaMoi = _TSCDCaBiet.NguyenGiaTinhKhauHao;
                                    _TSCDCaBiet.NguyenGiaTinhKhauHao = dr.GetDecimal("NguyenGiaMoi");
                                    _TSCDCaBiet.ThoiGianSuDung = _ThoiGianSuDung;
                                    _TSCDCaBiet.TyLeKhauHaoNam = dr.GetDecimal("TyLeKhauHaoMoi");
                                    _TyLeKhauHaoMoi = dr.GetDecimal("KhauHaoNam");
                                    // load child objects
                                    dr.NextResult();
                                }
                            }
                        }
                        MarkOld();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }


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
                        cm.CommandText = "spd_Insert_NghiepVuDanhGiaLai";
                        cm.Parameters.AddWithValue("@MaNghiepVuDanhGiaLai", _MaNghiepVuDanhGiaLai).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TSCDCaBiet.MaTSCDCaBiet);
                        cm.Parameters.AddWithValue("@GiaTriTang", _GiaTriTang);
                        cm.Parameters.AddWithValue("@GiaTriGiam", _GiaTriGiam);
                        cm.Parameters.AddWithValue("@TyLeKhauHaoMoi", _TyLeKhauHaoMoi);
                        cm.Parameters.AddWithValue("@NguyenGiaMoi", _NguyenGiaMoi);
                        cm.Parameters.AddWithValue("@VietBangChu", _VietBangChu);
                        cm.Parameters.AddWithValue("@Lydo", _LyDo);
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                        cm.Parameters.AddWithValue("@ThoiGianTang", _ThoiGianTang);
                        cm.Parameters.AddWithValue("@ThoiGianGiam", _ThoiGianGiam);
                        _ThoiGianSuDung = _TSCDCaBiet.ThoiGianSuDung + ThoiGianTang - _ThoiGianGiam;
                        cm.Parameters.AddWithValue("@ThoiGianSuDung", _ThoiGianSuDung);
                        cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);

                        cm.ExecuteNonQuery();
                        _MaNghiepVuDanhGiaLai = (int)cm.Parameters["@MaNghiepVuDanhGiaLai"].Value;
                        // _TSCDCaBiet.NguyenGiaConLai = _NguyenGiaMoi;
                        // _TSCDCaBiet.Save();
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
            // Insert or update object data into database
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
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Update_NghiepVuDanhGiaLai";
                        cm.Parameters.AddWithValue("@MaNghiepVuDanhGiaLai", _MaNghiepVuDanhGiaLai);
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TSCDCaBiet.MaTSCDCaBiet);
                        cm.Parameters.AddWithValue("@GiaTriTang", _GiaTriTang);
                        cm.Parameters.AddWithValue("@GiaTriGiam", _GiaTriGiam);
                        cm.Parameters.AddWithValue("@TyLeKhauHaoMoi", _TyLeKhauHaoMoi);
                        cm.Parameters.AddWithValue("@NguyenGiaMoi", _NguyenGiaMoi);
                        cm.Parameters.AddWithValue("@VietBangChu", _VietBangChu);
                        cm.Parameters.AddWithValue("@Lydo", _LyDo);
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                        cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@ThoiGianSuDung", _ThoiGianSuDung);
                        cm.Parameters.AddWithValue("@ThoiGianTang", _ThoiGianTang);
                        cm.Parameters.AddWithValue("@ThoiGianGiam", _ThoiGianGiam);
                        //NHỚ PHẢI SỬA NHA 
                       
                        cm.ExecuteNonQuery();
                        _ChungTu.ApplyEdit();
                        _ChungTu.UpdateTranSacTion(tr);
                     
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

        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            try
            {
                // Delete object data from database
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Delete_NghiepVuDanhGiaLai";
                        cm.Parameters.AddWithValue("@MaNghiepVuDanhGiaLai", crit.MaDanhGiaLai);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string temp = ex.Message;
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNghiepVuDanhGiaLai));
        }       

        #endregion

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _ChungTu.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid || _ChungTu.IsValid;
            }
        }
        #endregion
    }
}
