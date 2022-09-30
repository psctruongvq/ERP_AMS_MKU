using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    public class NghiepVuPhanBo:BusinessBase<NghiepVuPhanBo>
    {
        private bool _idSet;

         protected override object GetIdValue()
        {
            return _MaPhanBo;
        }

        #region Khởi tạo properties
        int _MaPhanBo;
        public int MaPhanBo
        {
          get
          {
            CanReadProperty(true) ;
            if (!_idSet)
            {
                // generate a default id value
                _idSet = true;
                if (Parent == null) return 0;
                NghiepVuPhanBoList parent = (NghiepVuPhanBoList)this.Parent;
                int max = 0;
                foreach (NghiepVuPhanBo item in parent)
                {
                    if (item.MaPhanBo > max)
                        max = item.MaPhanBo;
                }
                _MaPhanBo = max + 1;
            }
            return _MaPhanBo;
          }
          set
          {
            CanWriteProperty(true);
            if (!_MaPhanBo.Equals(value))
            {
              _MaPhanBo = value;
              PropertyHasChanged();
            }
          }
        }

        int _MaPhongBan;
        public int MaPhongBan
        {
          get
          {
            CanReadProperty(true) ;
            return _MaPhongBan;
          }
          set
          {
            CanWriteProperty(true);
            if (!_MaPhongBan.Equals(value))
            {
                _MaPhongBan = value;
              PropertyHasChanged();
            }
          }
        }
               
                        
        TSCDCaBiet _TaiSanCoDinhCaBiet;
        public TSCDCaBiet TaiSanCoDinhCaBiet
        {
          get
          {
            CanReadProperty(true) ;
            return _TaiSanCoDinhCaBiet;
          }
          set
          {
            CanWriteProperty(true);
            if (!_TaiSanCoDinhCaBiet.Equals(value))
            {
              _TaiSanCoDinhCaBiet = value;
              PropertyHasChanged();
            }
          }
        }

        DateTime _NgayThucHien;
        public DateTime NgayThucHien
        {
          get
          {
            CanReadProperty(true) ;
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

       
        #region constructor


        private NghiepVuPhanBo(TSCDCaBiet tscdCaBiet, int maPhongBan, DateTime dateTime)
        {
            _MaPhanBo = 0;
            _MaPhongBan = maPhongBan;
            _TaiSanCoDinhCaBiet = tscdCaBiet;
            _NgayThucHien = dateTime;
        
        }
        

        private NghiepVuPhanBo()
        {
            _MaPhanBo = 0;
            _MaPhongBan = 0;
            _TaiSanCoDinhCaBiet = TSCDCaBiet.NewTSCDCaBiet();
            _NgayThucHien = DateTime.Today;
            //MarkAsChild();
        }
       
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaPhanBo;

            public Criteria(int maPhanBo)
            {
                MaPhanBo = maPhanBo;
            }
        }


        [Serializable()]
        private class FilterCriteria_ByTSCDCaBiet
        {
            // Add criteria here
            public int _MaTSCDCaBiet;

            public FilterCriteria_ByTSCDCaBiet(int maTSCDCaBiet)
            {
                _MaTSCDCaBiet = maTSCDCaBiet;
            }
        }      



        #endregion

        #region Static Methods
        //giống constructor

        public override NghiepVuPhanBo Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaPhanBo));
        }

        public void Insert(SqlTransaction tr)
        {
            DataPortal_Insert(tr);
        }

        public void Update(SqlTransaction tr)
        {
            DataPortal_Update(tr);
        }    

        private NghiepVuPhanBo(SafeDataReader dr)
        {
            MarkAsChild();
            try
            {
                _MaPhanBo = dr.GetInt32("MaPhanBoSuDung");
                _MaPhongBan=dr.GetInt32("MaPhongBan");
                _TaiSanCoDinhCaBiet =TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                _NgayThucHien = dr.GetDateTime("NgayThucHien");
                _idSet = true;
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //LCQV
        public static  BoPhan GetPhongBanCuaTSCDCaBiet(int maTSCDCaBiet)
        {
            NghiepVuPhanBo pb = (NghiepVuPhanBo)DataPortal.Fetch<NghiepVuPhanBo>(new FilterCriteria_ByTSCDCaBiet(maTSCDCaBiet));
            if (pb == null) return null;
            return BoPhan.GetBoPhan(pb._MaPhongBan);
        }

        public static NghiepVuPhanBo NewNghiepVuPhanBo()
        {
            return new NghiepVuPhanBo();
        }

        public static NghiepVuPhanBo NewNghiepVuPhanBo(TSCDCaBiet tscdCaBiet, int maPhongBan, DateTime ngayThucHien)
        {
            return new NghiepVuPhanBo(tscdCaBiet, maPhongBan, ngayThucHien);
        }
        public static NghiepVuPhanBo NewNghiepVuPhanBoChild(TSCDCaBiet tscdCaBiet, int maPhongBan, DateTime ngayThucHien)
        {
            NghiepVuPhanBo nghiepVu = new NghiepVuPhanBo(tscdCaBiet, maPhongBan, ngayThucHien);
            nghiepVu.MarkAsChild();
            return nghiepVu;
        }

        public static NghiepVuPhanBo NewNghiepVuPhanBo(int maTSCDCaBiet, int MaPhongBan, DateTime NgayThucHien)
        {
            NghiepVuPhanBo pb = new NghiepVuPhanBo();
            pb._MaPhongBan =MaPhongBan;
            pb._TaiSanCoDinhCaBiet =TSCDCaBiet.GetTSCDCaBiet(maTSCDCaBiet);
            pb._NgayThucHien = NgayThucHien;
            return pb;
        }

        public static NghiepVuPhanBo GetNghiepVuPhanBo(int maPhanBo)
        {
            return (NghiepVuPhanBo)DataPortal.Fetch<NghiepVuPhanBo>(new Criteria(maPhanBo));
        }
        

        internal static NghiepVuPhanBo GetNghiepVuPhanBo(SafeDataReader dr)
        {
            return new NghiepVuPhanBo(dr);
        }

        public static void DeleteNghiepVuPhanBo(int maPhanBo)
        {
            DataPortal.Delete(new Criteria(maPhanBo));
        }


        public static NghiepVuPhanBo GetNghiepVuPhanBoByMaTSCDCaBiet(int MaTSCDCaBiet)
        {
            NghiepVuPhanBo nghiepVuPhanBo;
            nghiepVuPhanBo = new NghiepVuPhanBo();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LayNghiepVuPhanBoTheoMaTSCDCaBiet";
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", MaTSCDCaBiet);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {

                                nghiepVuPhanBo = GetNghiepVuPhanBo(dr);
                                // load child objects
                                dr.NextResult();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return nghiepVuPhanBo;
        }



        #endregion

        #region Data Access

        #region load tất cả cả
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
                        cm.CommandText = "spd_LoadMaCaBiet_TaiSanCoDinhCaBiet_PhongBan";
                        cm.Parameters.AddWithValue("@MaPhanBo", crit.MaPhanBo);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaPhanBo = dr.GetInt32("MaPhanBoSuDung");
                                _MaPhongBan = dr.GetInt32("MaPhongBan");
                                _TaiSanCoDinhCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                                _NgayThucHien = dr.GetDateTime("NgayThucHien");
                                _idSet = true;
                                // load child objects
                                dr.NextResult();
                            }
                        }
                    }
                    MarkOld();
                }
            }
            else if (criteria is FilterCriteria_ByTSCDCaBiet)
            {
                FilterCriteria_ByTSCDCaBiet crit = (FilterCriteria_ByTSCDCaBiet)criteria;
                try
                {
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_NghiepVuPhanBoSuDung_LayMaPhongBan";
                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", crit._MaTSCDCaBiet);

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    _MaPhanBo = dr.GetInt32("MaPhanBoSuDung");
                                    _MaPhongBan = dr.GetInt32("MaPhongBan");
                                    // _TaiSanCoDinhCaBiet =TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                                    _NgayThucHien = dr.GetDateTime("NgayThucHien");
                                    _idSet = true;
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
        }


        protected  void DataPortal_Insert(SqlTransaction tr)
        {
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_TaiSanCoDinhCaBiet_PhongBan";
                    cm.Parameters.AddWithValue("@MaPhanBo", _MaPhanBo);
                    cm.Parameters["@MaPhanBo"].Direction = ParameterDirection.Output;
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TaiSanCoDinhCaBiet.MaTSCDCaBiet);
                    cm.Parameters.AddWithValue("@MaPhongBan", _MaPhongBan);
                    cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                    cm.ExecuteNonQuery();
                    _MaPhanBo = (Int32)cm.Parameters["@MaPhanBo"].Value;
                    MarkOld();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected  void DataPortal_Update(SqlTransaction tr)
        {            
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                // we're not new, so update
                cm.CommandText = "spd_Update_TaiSanCoDinhCaBiet_PhongBan";
                cm.Parameters.AddWithValue("@MaPhanBoSuDung", _MaPhanBo);
                cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TaiSanCoDinhCaBiet.MaTSCDCaBiet);
                cm.Parameters.AddWithValue("@MaPhongBan", _MaPhongBan);
                cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                cm.ExecuteNonQuery();
                // make sure we're marked as an old object
                MarkOld();
            }

        }

        #region Delete

        
        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_TaiSanCoDinhCaBiet_PhongBan";
                    cm.Parameters.AddWithValue("@MaPhanBoSuDung", crit.MaPhanBo);
                    cm.ExecuteNonQuery();
                }
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaPhanBo));
        }
        #endregion

        #endregion

        #endregion
    }
}
