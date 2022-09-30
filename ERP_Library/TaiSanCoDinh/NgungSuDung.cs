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
    public class NgungSuDung: BusinessBase<NgungSuDung>
    {
        private bool _idSet; 
        protected override object GetIdValue()
        {
            return _MaNghiepVuNgungSuDungTSCD;
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
        
        int _MaNghiepVuNgungSuDungTSCD;
        public int MaNghiepVuNgungSuDungTSCD
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    _idSet = true;

                    NgungSuDungList parent = (NgungSuDungList)this.Parent;
                    if (parent == null)
                    {
                        return GetIdentityDoiTuongNghiepVu() + 1;
                        
                    }
                    else if (parent != null)
                    {
                        int max = 0;
                        foreach (NgungSuDung item in parent)
                        {
                            if (item.MaNghiepVuNgungSuDungTSCD > max)
                                max = item.MaNghiepVuNgungSuDungTSCD;
                        }
                        _MaNghiepVuNgungSuDungTSCD= max + 1;
                    }

                    
                    
                    
                }
                return _MaNghiepVuNgungSuDungTSCD;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNghiepVuNgungSuDungTSCD.Equals(value))
                {
                    _MaNghiepVuNgungSuDungTSCD = value;
                    PropertyHasChanged();
                }
            }
        }
        
        TSCDCaBiet _TSCDCaBiet ;
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

        String _SoChungTuNghiepVu;
        public String SoChungTuNghiepVu
        {
            get
            {
                CanReadProperty(true);
                return _SoChungTuNghiepVu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoChungTuNghiepVu.Equals(value))
                {
                    _SoChungTuNghiepVu = value;
                    PropertyHasChanged();
                }
            }
        }

        String _DienGiai;
        public String DienGiai
        {
            get
            {
                CanReadProperty(true);
                return _DienGiai;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DienGiai.Equals(value))
                {
                    _DienGiai = value;
                    PropertyHasChanged();
                }
            }
        }

        //NguoiSuDung _NguoiLap;
        //public NguoiSuDung NguoiLap
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _NguoiLap;
        //    }
        //    set
        //    {
        //        CanWriteProperty(true);
        //        if (!_NguoiLap.Equals(value))
        //        {
        //            _NguoiLap = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        String _NguoiGiao;
        public String NguoiGiao
        {
            get
            {
                CanReadProperty(true);
                return _NguoiGiao;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NguoiGiao.Equals(value))
                {
                    _NguoiGiao = value;
                    PropertyHasChanged();
                }
            }
        }       
        
        long _MaNguoiLap;
        public long  MaNguoiLap
        {
            get
            {
                CanReadProperty(true);
                return _MaNguoiLap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNguoiLap.Equals(value))
                {
                    _MaNguoiLap = value;
                    PropertyHasChanged();
                }
            }
        }

        string _TenNguoiLap;
        public string TenNguoiLap
        {
            get
            {
                CanReadProperty(true);
                return _TenNguoiLap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenNguoiLap.Equals(value))
                {
                    _TenNguoiLap = value;
                    PropertyHasChanged();
                }
            }
        }


        #endregion       
       
        #region Constructors

        private NgungSuDung()
        {
            try
            {
                // Prevent direct creation
                _MaNghiepVuNgungSuDungTSCD = 0;              
                _NgayThucHien = DateTime.Today;
                _GhiChu = String.Empty;
                _MaChungTu = 0;
                _SoChungTuNghiepVu = string.Empty;
                _MaCTNVQL = String.Empty;
                _NguoiGiao = String.Empty;
                _MaNguoiLap = 0;
                _TenNguoiLap = string.Empty;
//                _NguoiLap = NguoiSuDung.NewNguoiSuDung();                                
                _DienGiai = String.Empty;
                _TSCDCaBiet = new TSCDCaBiet(); 
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Static Methods
        public override NgungSuDung Save()
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
         
        private NgungSuDung(SafeDataReader dr)
        {   
            try
            {
                MarkAsChild();
                _MaNghiepVuNgungSuDungTSCD = dr.GetInt32("MaNghiepVuNgungSuDungTSCD");
                _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
                _NgayThucHien = dr.GetDateTime("NgayThucHien");
                _GhiChu = dr.GetString("GhiChu");
                _MaChungTu = dr.GetInt32("MaCTNV");              
                _MaCTNVQL = dr.GetString("MaCTNVQL");
                _DienGiai = dr.GetString("DienGiai");
                _MaNguoiLap = dr.GetInt64("MaNguoiSuDung");
                _TenNguoiLap= dr.GetString("TenNhanVien");
                _SoChungTuNghiepVu = dr.GetString("SoCTNV");
                //_NguoiLap = NguoiSuDung.GetNguoiSuDung(dr.GetInt64("MaNguoiSuDung"));
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public static NgungSuDung NewNgungSuDung()
        {
            NgungSuDung nsd = new NgungSuDung();
            nsd.MaNghiepVuNgungSuDungTSCD = 0;            
            nsd.NgayThucHien = DateTime.Today;
            nsd.GhiChu = String.Empty;
            nsd.MarkDirty();
            return nsd;

        }

        public static NgungSuDung NewNgungSuDung(int maTSCDCaBiet)
        {
            NgungSuDung nsd = new NgungSuDung();
            nsd._MaNghiepVuNgungSuDungTSCD = 0;
            nsd._NgayThucHien = DateTime.Today;
            nsd._GhiChu = String.Empty;
            nsd._TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(maTSCDCaBiet);
            nsd.MarkNew();
            return nsd;

        }

        //public static NgungSuDung NewNgungSuDung(int maNghiepVuNgungSuDungTSCD, int maTSCDCaBiet, DateTime ngayThucHien, String ghiChu)
        //{
        //    NgungSuDung nsd = new NgungSuDung();
        //    nsd._MaNghiepVuNgungSuDungTSCD = maNghiepVuNgungSuDungTSCD;
        //    nsd._TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(maTSCDCaBiet);
        //    nsd._NgayThucHien = ngayThucHien;
        //    nsd._GhiChu = ghiChu;
        //    //nsd.MarkDirty();
        //    return nsd;
        //}

        //public static NgungSuDung GetNgungSuDung(int maNghiepVuNgungSuDungTSCD)
        //{
        //    return (NgungSuDung)DataPortal.Fetch<NgungSuDung>(new Criteria(maNghiepVuNgungSuDungTSCD));
        //}

        //public static NgungSuDung GetNgungSuDungChild(int maNghiepVuNgungSuDungTSCD)
        //{
        //    NgungSuDung ngungsudung = (NgungSuDung)DataPortal.Fetch<NgungSuDung>(new Criteria(maNghiepVuNgungSuDungTSCD));
        //    ngungsudung.MarkAsChild();
        //    return ngungsudung;
        //}

        internal static NgungSuDung GetNgungSuDung(SafeDataReader dr)
        {
            return new NgungSuDung(dr);            
        }

        public int KiemTraSoCTNgungSD(string soChungTuNgungSD)
        {
            int kq = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select count(SoCTNV) from tblChungTuNghiepVu where SoCTNV='" + soChungTuNgungSD + "'";
                    kq = Convert.ToInt32(cm.ExecuteScalar());
                    //_idSet = true;
                }
                //MarkOld();
            }
            return kq;
        }

        public static void DeleteNgungSuDung(int maNghiepVuNgungSuDungTSCD)
        {
            DataPortal.Delete(new Criteria(maNghiepVuNgungSuDungTSCD));
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
                    ident = Convert.ToInt32(cm.ExecuteScalar()) + 1;
                    _idSet = true;
                }
                MarkOld();
            }
            return ident;
        }


        #region Criteria

        [Serializable()]
        private class Criteria
        {
            public int MaNghiepVuNgungSuDungTSCD;

            public Criteria(int maNghiepVuNgungSuDungTSCD)
            {
                this.MaNghiepVuNgungSuDungTSCD = maNghiepVuNgungSuDungTSCD;
            }
        }

        #endregion //Criteria

        #region Data Access - Create
        [RunLocal]
        private void DataPortal_Create(Criteria criteria)
        {
            _MaNghiepVuNgungSuDungTSCD = criteria.MaNghiepVuNgungSuDungTSCD;
            ValidationRules.CheckRules();
        }

        #endregion //Data Access - Create

        #region Data Access - Fetch
        private void DataPortal_Fetch(Criteria criteria)
        {
            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    ExecuteFetch(tr, criteria);

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_Select_NgungSuDung";

                cm.Parameters.AddWithValue("@MaNghiepVuNgungSuDungTSCD", criteria.MaNghiepVuNgungSuDungTSCD);

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
            DataPortal_Delete(new Criteria(_MaNghiepVuNgungSuDungTSCD));
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
                cm.CommandText = "spd_Delete_NgungSuDung";

                cm.Parameters.AddWithValue("@MaNghiepVuNgungSuDungTSCD", criteria.MaNghiepVuNgungSuDungTSCD);

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
            _MaNghiepVuNgungSuDungTSCD = dr.GetInt32("MaNghiepVuNgungSuDungTSCD");
            _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr.GetInt32("MaTSCDCaBiet"));
            _NgayThucHien = dr.GetDateTime("NgayThucHien");
            _GhiChu = dr.GetString("GhiChu");
            _MaChungTu = dr.GetInt32("MaCTNV");
            _MaCTNVQL = dr.GetString("MaCTNVQL");
            _DienGiai = dr.GetString("DienGiai");
            _MaNguoiLap = dr.GetInt64("MaNguoiSuDung");
            _TenNguoiLap = dr.GetString("TenNhanVien"); 
        }

        private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            _TSCDCaBiet = TSCDCaBiet.GetTSCDCaBiet(dr);
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
                cm.CommandText = "spd_Insert_NghiepVuNgungSuDungTSCD";

                AddInsertParameters(cm);

                cm.ExecuteNonQuery();

                _MaNghiepVuNgungSuDungTSCD = (int)cm.Parameters["@MaNghiepVuNgungSuDungTSCD"].Value;
                _MaChungTu = (int)cm.Parameters["@MaChungTu"].Value;

            }//using
        }

        private void AddInsertParameters(SqlCommand cm)
        {            
            cm.Parameters.AddWithValue("@MaNghiepVuNgungSuDungTSCD", _MaNghiepVuNgungSuDungTSCD);
            cm.Parameters["@MaNghiepVuNgungSuDungTSCD"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@SoCTNV", _SoChungTuNghiepVu);
            cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TSCDCaBiet.MaTSCDCaBiet);
            cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
            cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu);
            cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@MaCTNV", _MaCTNVQL);
            cm.Parameters.AddWithValue("@GhiChu", _GhiChu);
            cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID  );
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
                cm.CommandText = "spd_Update_NghiepVuNgungSuDungTSCD";

                AddUpdateParameters(cm);

                cm.ExecuteNonQuery();

            }//using
        }

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaNghiepVuNgungSuDungTSCD", _MaNghiepVuNgungSuDungTSCD);
            cm.Parameters["@MaNghiepVuNgungSuDungTSCD"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@SoCTNV", _SoChungTuNghiepVu);
            cm.Parameters.AddWithValue("@MaTSCDCaBiet", _TSCDCaBiet.MaTSCDCaBiet);
            cm.Parameters.AddWithValue("@NgayThucHien", _NgayThucHien);
            cm.Parameters.AddWithValue("@MaChungTu", _MaChungTu);
            cm.Parameters["@MaChungTu"].Direction = ParameterDirection.Output;
            cm.Parameters.AddWithValue("@MaCTNV", _MaCTNVQL);
            cm.Parameters.AddWithValue("@GhiChu", _GhiChu);
            cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
        }

        private void UpdateChildren(SqlTransaction tr)
        {
            _TSCDCaBiet.Update(tr);
        }
        #endregion //Data Access - Update

        #region Data Access - Delete
        internal void DeleteSelf(SqlTransaction tr)
        {
            if (!IsDirty) return;
            if (IsNew) return;

            ExecuteDelete(tr, new Criteria(_MaNghiepVuNgungSuDungTSCD));
            MarkNew();
        }
        #endregion //Data Access - Delete
        #endregion //Data Access

    }
}
