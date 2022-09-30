using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class GhiTangTaiSan :BusinessBase<GhiTangTaiSan>
    {
        protected override object GetIdValue()
        {
            return _MaNghiepVuGhiTang;
        }

        #region Properties

        int _MaNghiepVuGhiTang;
        public int MaNghiepVuGhiTang
        {
            get
            {
                CanReadProperty(true);
                return _MaNghiepVuGhiTang;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNghiepVuGhiTang.Equals(value))
                {
                    _MaNghiepVuGhiTang = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _NgayGhitang;
        public DateTime NgayGhitang
        {
            get
            {
                CanReadProperty(true);
                return _NgayGhitang;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayGhitang.Equals(value))
                {
                    _NgayGhitang = value;
                    _ChungTu.NgayThucHien = _NgayGhitang;
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

        NghiepVuPhanBoList _PhanBoList = new NghiepVuPhanBoList();
        public NghiepVuPhanBoList PhanBoList
        {
            get
            {
                CanReadProperty(true);
                return _PhanBoList;
            }
            set
            {
                CanWriteProperty(true);
                if (!_PhanBoList.Equals(value))
                {
                    _PhanBoList = value;
                    PropertyHasChanged();
                }
            }
        }

        #endregion

        #region Contructors
        private GhiTangTaiSan()
        {                       
            
            _MaNghiepVuGhiTang = 0;
            _NgayGhitang = DateTime.Today;
            _ChungTu = ChungTu.NewChungTu(4);            
            _DanhSachTSCDCaBiet = new TaiSanCoDinhCaBietList();
            _PhanBoList = new NghiepVuPhanBoList();

            // MarkAsChild();
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
        public override GhiTangTaiSan Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaNghiepVuGhiTang));
        }
        private GhiTangTaiSan(SafeDataReader dr)
        {
            //MarkAsChild();
            _MaNghiepVuGhiTang = dr.GetInt32("MaNghiepVuGhiTang");
            _NgayGhitang = dr.GetDateTime("NgayGhiTang");            
            _ChungTu = ChungTu.GetChungTu(dr.GetInt32("MaChungTu"));
            
            _DanhSachTSCDCaBiet = TaiSanCoDinhCaBietList.GetTSCDCaBietTheoPhieuNhap(_MaNghiepVuGhiTang);
            
            foreach (TSCDCaBiet tscdCaBiet in  _DanhSachTSCDCaBiet )
            {
                _PhanBoList.Add((NghiepVuPhanBo) NghiepVuPhanBo.GetNghiepVuPhanBoByMaTSCDCaBiet(tscdCaBiet.MaTSCDCaBiet));
            }
            MarkOld();
        }

        public static GhiTangTaiSan NewGhiTangTaiSan()
        {           
            return new GhiTangTaiSan();
        }

        public static GhiTangTaiSan GetGhiTangTaiSan(int maGhiTangTaiSan)
        {
            return (GhiTangTaiSan)DataPortal.Fetch<GhiTangTaiSan>(new Criteria(maGhiTangTaiSan));
        }

        public static GhiTangTaiSan NewGhiTangTaiSan(int maGhiTang, DateTime ngayThucHien, int maTSCD, int maPhieuNhap)
        {
            GhiTangTaiSan gt = new GhiTangTaiSan();
            gt._MaNghiepVuGhiTang = maGhiTang;
            gt._NgayGhitang = ngayThucHien;           
            return gt;
        }
        internal static GhiTangTaiSan GetGhiTangTaiSan(SafeDataReader dr)
        {
            return new GhiTangTaiSan(dr);
        }
        public static void DeleteGhiTangTaiSan(int maGhiTangTaiSan)
        {
            DataPortal.Delete(new Criteria(maGhiTangTaiSan));
        }

        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaGhiTang;

            public Criteria(int maGhiTang)
            {
                MaGhiTang = maGhiTang;
            }
        }

        #endregion

        #region Data Access


       
        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_NghiepVuGhiTang";
                        cm.Parameters.AddWithValue("@MaNghiepVuGhiTang", crit.MaGhiTang);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaNghiepVuGhiTang = dr.GetInt32("MaNghiepVuGhiTang");
                                _NgayGhitang = dr.GetDateTime("NgayGhiTang");
                                _ChungTu = ChungTu.GetChungTu(dr.GetInt32("MaChungTu"));
                                _DanhSachTSCDCaBiet = TaiSanCoDinhCaBietList.GetTSCDCaBietTheoPhieuNhap(_MaNghiepVuGhiTang);
                                foreach (TSCDCaBiet tscdCaBiet in _DanhSachTSCDCaBiet)
                                {
                                    _PhanBoList.Add(NghiepVuPhanBo.GetNghiepVuPhanBoByMaTSCDCaBiet(tscdCaBiet.MaTSCDCaBiet));
                                }
                                // load child objects
                                dr.NextResult();
                            }
                        }
                    }
                    MarkOld();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
                            cm.CommandText = "spd_Update_TSCDCaBiet";
                            cm.Parameters.AddWithValue("@MaNghiepVuGhiTang", _MaNghiepVuGhiTang);
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
                    cm.CommandText = "spd_Update_TSCDCaBiet";
                    cm.Parameters.AddWithValue("@MaNghiepVuGhiTang", _MaNghiepVuGhiTang);
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", TaiSanCoDinhCaBiet.MaTSCDCaBiet);
                    cm.ExecuteNonQuery();
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
                        _ChungTu.InsertTranSacTion(tr);
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_NghiepVuGhiTang";
                        cm.Parameters.AddWithValue("@MaNghiepVuGhiTang", _MaNghiepVuGhiTang).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@NgayGhiTang", _NgayGhitang);
                        if (_ChungTu.MaChungTu != 0)
                        {
                            cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu);
                        }
                        else cm.Parameters.AddWithValue("@MaChungTu", DBNull.Value);

                        cm.ExecuteNonQuery();
                        MarkOld();
                        _MaNghiepVuGhiTang = (int)cm.Parameters["@MaNghiepVuGhiTang"].Value;

                        _DanhSachTSCDCaBiet.ApplyEdit();
                        _DanhSachTSCDCaBiet.DataPortal_UpdateTranSacTion(tr);
                        Update_DanhSachTSCDCaBietTranSacTion(tr);
                        _PhanBoList.ApplyEdit();
                        _PhanBoList.DataPortal_Update(tr);
                        tr.Commit();
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
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                SqlTransaction tr;
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Update_NghiepVuGhiTang";
                        cm.Parameters.AddWithValue("@MaNghiepVuGhiTang", _MaNghiepVuGhiTang);
                        cm.Parameters.AddWithValue("@NgayGhiTang", _NgayGhitang);
                        cm.Parameters.AddWithValue("@MaChungTu", _ChungTu.MaChungTu).Direction = ParameterDirection.Output;
                        cm.ExecuteNonQuery();
                        _ChungTu.ApplyEdit();
                        _ChungTu.UpdateTranSacTion(tr);                        

                        _DanhSachTSCDCaBiet.ApplyEdit();
                        _DanhSachTSCDCaBiet.DataPortal_UpdateTranSacTion(tr);                        

                        Update_DanhSachTSCDCaBietTranSacTion(tr);                        
                        
                        _PhanBoList.ApplyEdit();
                        _PhanBoList.DataPortal_Update(tr);                        
                        
                        MarkOld();
                        tr.Commit();
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
                        cm.CommandText = "spd_Delete_NghiepVuGhiTang";
                        cm.Parameters.AddWithValue("@MaNghiepVuGhiTang", crit.MaGhiTang);
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
            DataPortal_Delete(new Criteria(_MaNghiepVuGhiTang));
        }

        #endregion

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _ChungTu.IsDirty||_DanhSachTSCDCaBiet.IsDirty||_PhanBoList.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid || _ChungTu.IsValid||_DanhSachTSCDCaBiet.IsValid||_PhanBoList.IsValid;
            }
        }
        #endregion
    }
}
