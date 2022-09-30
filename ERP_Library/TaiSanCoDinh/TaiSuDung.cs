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
    public class TaiSuDung: BusinessBase<TaiSuDung>
    {
        private bool _idSet; 
        protected override object GetIdValue()
        {
            return _MaNghiepVuTaiSuDungTSCD;
        }

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _TSCDCaBiet.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid || _TSCDCaBiet.IsValid;
            }
        }
        #endregion

        #region Khai Bao Bien
        
        int _MaNghiepVuTaiSuDungTSCD;
        public int MaNghiepVuTaiSuDungTSCD
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    _idSet = true;

                    TaiSuDungList parent = (TaiSuDungList)this.Parent;
                    if (parent == null) 
                    {
                        return GetIdentityDoiTuongNghiepVu() + 1;
                        
                    }
                    else if (parent != null)
                    {
                        int max = 0;
                        foreach (TaiSuDung item in parent)
                        {
                            if (item.MaNghiepVuTaiSuDungTSCD > max)
                                max = item.MaNghiepVuTaiSuDungTSCD;
                        }
                        _MaNghiepVuTaiSuDungTSCD= max + 1;
                    }

                    
                    
                    
                }
                return _MaNghiepVuTaiSuDungTSCD;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNghiepVuTaiSuDungTSCD.Equals(value))
                {
                    _MaNghiepVuTaiSuDungTSCD = value;
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
                _TSCDCaBiet = value;
                PropertyHasChanged();
                

                //Ghi chú: Không biết khi nào 2 TSCD cá Biệt
                
                //if (!_TSCDCaBiet.Equals(value))
                //{
                //    _TSCDCaBiet = value;
                //    PropertyHasChanged();
                //}
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

        String _GhiChu;
        public String GhiChu
        {
            get
            {
                CanReadProperty(true);
                return _GhiChu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GhiChu.Equals(value))
                {
                    _GhiChu = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaChungTu;
        public int MaChungTu
        {
            get
            {
                CanReadProperty(true);
                return _MaChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaChungTu.Equals(value))
                {
                    _MaChungTu = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MaCTNVQL;
        public String MaCTNVQL
        {
            get
            {
                CanReadProperty(true);
                return _MaCTNVQL;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaCTNVQL.Equals(value))
                {
                    _MaCTNVQL = value;
                    PropertyHasChanged();
                }
            }
        }

        string  _SoChungTu;
        public string  SoChungTu
        {
            get
            {
                CanReadProperty(true);
                return _SoChungTu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoChungTu.Equals(value))
                {
                    _SoChungTu = value;
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
            public int MaNghiepVuTaiSuDung;

            public Criteria(int maNghiepVuTaiSuDung)
            {
                MaNghiepVuTaiSuDung = maNghiepVuTaiSuDung;
            }
        }

        #endregion

        #region Constructors

        private TaiSuDung()
        {
            try
            {
                // Prevent direct creation
                _MaNghiepVuTaiSuDungTSCD = 0;              
                _NgayThucHien = DateTime.Today;
                _GhiChu = String.Empty;
                _TSCDCaBiet = TSCDCaBiet.NewTSCDCaBiet();
                _MaChungTu = 0;
                _MaCTNVQL = String.Empty;
                _SoChungTu = String.Empty;
                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Static Methods
        public override TaiSuDung Save()
        {
            return base.Save();
        }
      
        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }    
         
        private TaiSuDung(SafeDataReader dr)
        {   
            try
            {
                MarkAsChild();
                _MaNghiepVuTaiSuDungTSCD = dr.GetInt32("MaNghiepVuTaiSuDungTSCD");
                _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                _NgayThucHien = dr.GetDateTime("NgayThucHien");
                _GhiChu = dr.GetString("GhiChu");
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public static TaiSuDung NewTaiSuDung()
        {
            TaiSuDung nsd = new TaiSuDung();
            nsd.MaNghiepVuTaiSuDungTSCD = 0;            
            nsd.NgayThucHien = DateTime.Today;
            nsd.GhiChu = String.Empty;

            nsd.MarkDirty();
            return nsd;

        }

        public static TaiSuDung NewTaiSuDung(int maTSCDCaBiet)
        {
            TaiSuDung nsd = new TaiSuDung();
            nsd._MaNghiepVuTaiSuDungTSCD = 0;
            nsd._NgayThucHien = DateTime.Today;
            nsd._GhiChu = String.Empty;
            nsd._TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(maTSCDCaBiet);
            nsd.MarkNew();
            return nsd;

        }

        public static TaiSuDung NewTaiSuDung(int maNghiepVuTaiSuDungTSCD, int maTSCDCaBiet, DateTime ngayThucHien, String ghiChu)
        {
            TaiSuDung nsd = new TaiSuDung();
            nsd._MaNghiepVuTaiSuDungTSCD = maNghiepVuTaiSuDungTSCD;
            nsd._TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(maTSCDCaBiet);
            nsd._NgayThucHien = ngayThucHien;
            nsd._GhiChu = ghiChu;
            //nsd.MarkDirty();
            return nsd;
        }

        public static TaiSuDung GetTaiSuDung(int maNghiepVuTaiSuDungTSCD)
        {
            return (TaiSuDung)DataPortal.Fetch<TaiSuDung>(new Criteria(maNghiepVuTaiSuDungTSCD));
        }

        public static TaiSuDung GetTaiSuDungChild(int maNghiepVuTaiSuDungTSCD)
        {
            TaiSuDung TaiSuDung = (TaiSuDung)DataPortal.Fetch<TaiSuDung>(new Criteria(maNghiepVuTaiSuDungTSCD));
            TaiSuDung.MarkAsChild();
            return TaiSuDung;
        }

        internal static TaiSuDung GetTaiSuDung(SafeDataReader dr)
        {
            return new TaiSuDung(dr);            
        }

        public static void DeleteTaiSuDung(int maNghiepVuTaiSuDungTSCD)
        {
            DataPortal.Delete(new Criteria(maNghiepVuTaiSuDungTSCD));
        }

        #endregion

        #region Data Access

        protected int GetIdentityDoiTuongNghiepVu()
        {
            int ident = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select IDENT_CURRENT('tblDoiTuongNghiepVu')";
                    ident= Convert.ToInt32(cm.ExecuteScalar())+1;                    
                    _idSet = true;                   
                }
                MarkOld();
            }
            return ident;
        }

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
                    cm.CommandText = "spd_LoadMaCaBiet_NghiepVuTaiSuDungTSCD";
                    cm.Parameters.AddWithValue("@MaNghiepVuTaiSuDungTSCD", crit.MaNghiepVuTaiSuDung);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            _MaNghiepVuTaiSuDungTSCD = dr.GetInt32("MaNghiepVuTaiSuDungTSCD");
                            _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                            _NgayThucHien = dr.GetDateTime("NgayThucHien");
                            _GhiChu = dr.GetString("GhiChu");
                            // load child objects
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
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.Transaction = tr;
                        _TSCDCaBiet.ApplyEdit();
                        _TSCDCaBiet.Update(tr);
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_NghiepVuTaiSuDungTSCD";
                        cm.Parameters.AddWithValue("@MaNghiepVuTaiSuDungTSCD", _MaNghiepVuTaiSuDungTSCD);
                        cm.Parameters["@MaNghiepVuTaiSuDungTSCD"].Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TSCDCaBiet.MaTSCDCaBiet);                        
                        cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
                        cm.Parameters.AddWithValue("@GhiChu", _GhiChu);
                        cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu);
                        cm.Parameters.AddWithValue("@SoChungTu", _SoChungTu);
                        cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@MaCTNV", _MaCTNVQL);    
                        cm.ExecuteNonQuery();
                        _idSet = true;
                        _MaNghiepVuTaiSuDungTSCD = (int)cm.Parameters["@MaNghiepVuTaiSuDungTSCD"].Value;
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

        #endregion

        #endregion

      }
}
