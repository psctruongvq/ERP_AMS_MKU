using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    public class LoaiChungTu : BusinessBase<LoaiChungTu>
    {
        private bool _idSet;

        protected override object GetIdValue()
        {
            return _TenLoaiCT;
        }
        #region rule
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "MaLoaiCTQuanLy");
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "TenLoaiCT");
        }
        #endregion

        #region contructors
        
        private LoaiChungTu()
        {
            _MaLoaiCT = 0;
            _MaLoaiCTQuanLy = String.Empty;
            _TenLoaiCT = String.Empty;
            MarkAsChild();
        }
        #endregion

        #region Khai báo biến
        int _MaLoaiCT ;
        public int MaLoaiCT
        {
            get
            {
                CanReadProperty(true);
                //if (!_idSet)
                //{ 
                //    _idSet=true;
                //    int max=0;
                //    if (Parent == null) return 0;
                //    LoaiChungTuList parent=(LoaiChungTuList) this.Parent;
                //    foreach (LoaiChungTu item in parent)
                //    {
                //        if (item.MaLoaiCT > max)
                //            max = item.MaLoaiCT;
                //    }
                //    _MaLoaiCT = max + 1;
                //}
                return _MaLoaiCT;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaLoaiCT.Equals(value))
                {
                    _idSet = true;
                    _MaLoaiCT = value;
                    PropertyHasChanged();
                }
            }
        }

        private string _TenLoaiCT;
        public String TenLoaiCT
        {
            get
            {
                CanReadProperty(true);
                return _TenLoaiCT;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenLoaiCT.Equals(value))
                {
                    _TenLoaiCT = value;
                    PropertyHasChanged();
                }
            }
        }

        private string _MaLoaiCTQuanLy;
        public String MaLoaiCTQuanLy
        {
            get
            {
                CanReadProperty(true);
                return _MaLoaiCTQuanLy;
            }
            //set
            //{
            //    CanWriteProperty(true);
            //    if (!_MaLoaiCTQuanLy.Equals(value))
            //    {
            //        _MaLoaiCTQuanLy = value;
            //        PropertyHasChanged();
            //    }
            //}
        }          

        //TienTo ,TongKyTuPhanSo ,TrungTo ,HauTo ,KyTuSoBatDau,NgungSuDung
        private bool _NgungSuDung;
        public bool NgungSuDung
        {
            get
            {
                CanReadProperty(true);
                return _NgungSuDung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgungSuDung.Equals(value))
                {
                    _NgungSuDung = value;
                    PropertyHasChanged();
                }
            }
        }
        private int _KyTuSoBatDau;
        public int KyTuSoBatDau
        {
            get
            {
                CanReadProperty(true);
                return _KyTuSoBatDau;
            }
            set
            {
                CanWriteProperty(true);
                if (!_KyTuSoBatDau.Equals(value))
                {
                    _KyTuSoBatDau = value;
                    PropertyHasChanged();
                }
            }
        }
        private string _HauTo = string.Empty;
        public string HauTo
        {
            get
            {
                CanReadProperty(true);
                return _HauTo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_HauTo.Equals(value))
                {
                    _HauTo = value;
                    PropertyHasChanged();
                }
            }
        }
        private string _TrungTo = string.Empty;
        public string TrungTo
        {
            get
            {
                CanReadProperty(true);
                return _TrungTo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TrungTo.Equals(value))
                {
                    _TrungTo = value;
                    PropertyHasChanged();
                }
            }
        }
        private string _TienTo = string.Empty;
        public string TienTo
        {
            get
            {
                CanReadProperty(true);
                return _TienTo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TienTo.Equals(value))
                {
                    _TienTo = value;
                    PropertyHasChanged();
                }
            }
        }
        private int _TongKyTuPhanSo ;
        public int TongKyTuPhanSo
        {
            get
            {
                CanReadProperty(true);
                return _TongKyTuPhanSo;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TongKyTuPhanSo.Equals(value))
                {
                    _TongKyTuPhanSo = value;
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
            public int MaLoaiChungTu;

            public Criteria(int maLoaiChungTu)
            {
                MaLoaiChungTu = maLoaiChungTu;
            }
        }

        [Serializable()]
        private class CriteriaByMaQuanLy
        {
            // Add criteria here
            public string MaQuanLy;

            public CriteriaByMaQuanLy(string maql)
            {
                MaQuanLy = maql;
            }
        }

        #endregion

        #region Static Methods
         public override LoaiChungTu Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaLoaiCT));
        }
        public void Insert()
        {
            DataPortal_Insert();
        }
        public void Update()
        {
            DataPortal_Update();
        }    
         

        /// <summary>
        /// Constructor này dùng cho PhongBanList Load từng Phòng Ban lên
        /// </summary>
        /// <param name="dr">là SafeDataReader của PhongBanList Fetch ra</param>
        private LoaiChungTu(SafeDataReader dr)
        {
            MarkAsChild();
            _MaLoaiCT = dr.GetInt32("MaLoaiCT");
            _TenLoaiCT = dr.GetString("TenLoaiCT");
            _MaLoaiCTQuanLy = dr.GetString("MaLoaiCTQuanLy");
            _TienTo = dr.GetString("TienTo");
            _TongKyTuPhanSo = dr.GetInt32("TongKyTuPhanSo");
            _TrungTo = dr.GetString("TrungTo");
            _HauTo = dr.GetString("HauTo");
            _KyTuSoBatDau = dr.GetInt32("KyTuSoBatDau");
            _NgungSuDung = dr.GetBoolean("NgungSuDung");

            _idSet = true; //Do tự set value cho ID
            MarkOld();
        }

       public static LoaiChungTu NewLoaiChungTu()
        {
            LoaiChungTu lct=new LoaiChungTu();
            lct.TenLoaiCT=String.Empty;
            lct.MarkDirty();
            lct.ValidationRules.CheckRules();
            return lct;
        }

        public static LoaiChungTu NewLoaiChungTu(String tenLoaiChungTu, String maLoaiChungTuQL)
        {
            LoaiChungTu loaiChungTu= new LoaiChungTu();
            loaiChungTu._TenLoaiCT = tenLoaiChungTu;
            loaiChungTu._MaLoaiCTQuanLy = maLoaiChungTuQL;
            loaiChungTu.MarkDirty();
            loaiChungTu.ValidationRules.CheckRules();
            return loaiChungTu;           
        }

        public static LoaiChungTu GetLoaiChungTu(int maLoaiCT)
        {
            return (LoaiChungTu)DataPortal.Fetch<LoaiChungTu>(new Criteria(maLoaiCT));
        }

        public static LoaiChungTu GetLoaiChungTu(string maquanly)
        {
            return (LoaiChungTu)DataPortal.Fetch<LoaiChungTu>(new CriteriaByMaQuanLy(maquanly));
        }

        internal static LoaiChungTu GetLoaiChungTu(SafeDataReader dr)
        {
            return new LoaiChungTu(dr);            
        }

        public static void DeleteLoaiChungTu(int maLoaiCT)
        {
            DataPortal.Delete(new Criteria(maLoaiCT));
        }   
                
        #endregion

        #region Data Access
        protected override void DataPortal_Create()
        {
            base.DataPortal_Create();
        }

        //protected override void DataPortal_Create(object criteria)
        //{
        //    Criteria crit = (Criteria)criteria;

        //    // Load default values from database
        //}

        protected override void DataPortal_Fetch(object criteria)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        if (criteria is Criteria)
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LoadMaCaBiet_LoaiChungTu";
                            cm.Parameters.AddWithValue("@MaLoaiCT", ((Criteria)criteria).MaLoaiChungTu);
                        }
                        else if (criteria is CriteriaByMaQuanLy)
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_GetLoaiChungTuByMaQuanLy";
                            cm.Parameters.AddWithValue("@MaQuanLy", ((CriteriaByMaQuanLy)criteria).MaQuanLy);
                        }
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            if (dr.Read())
                            {
                                _MaLoaiCT = dr.GetInt32("MaLoaiCT");
                                _TenLoaiCT = dr.GetString("TenLoaiCT");
                                _MaLoaiCTQuanLy = dr.GetString("MaLoaiCTQuanLy");
                                _TienTo = dr.GetString("TienTo");
                                _TongKyTuPhanSo = dr.GetInt32("TongKyTuPhanSo");
                                _TrungTo = dr.GetString("TrungTo");
                                _HauTo = dr.GetString("HauTo");
                                _KyTuSoBatDau = dr.GetInt32("KyTuSoBatDau");
                                _NgungSuDung = dr.GetBoolean("NgungSuDung");
                                _idSet = true;
                            }
                            // load child objects
                            dr.NextResult();
                        }
                    }
                    MarkOld();
                }
            }
            catch (Exception e)
            {
                string temp = e.Message;
            }
        }

        
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {             
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_InserttblLoaiChungTu";
                    cm.Parameters.AddWithValue("@MaLoaiChungTu", _MaLoaiCT);
                    cm.Parameters.AddWithValue("@TenLoaiCT", _TenLoaiCT.ToString());
                    cm.Parameters.AddWithValue("@MaLoaiCTQuanLy", _MaLoaiCTQuanLy.ToString());
                    //ienTo ,TongKyTuPhanSo ,TrungTo ,HauTo ,KyTuSoBatDau,NgungSuDung    
                    cm.Parameters.AddWithValue("@TienTo", _TienTo);
                    cm.Parameters.AddWithValue("@TongKyTuPhanSo", _TongKyTuPhanSo);
                    cm.Parameters.AddWithValue("@TrungTo", _TrungTo);
                    cm.Parameters.AddWithValue("@HauTo", _HauTo);
                    cm.Parameters.AddWithValue("@KyTuSoBatDau", _KyTuSoBatDau);
                    cm.Parameters.AddWithValue("@NgungSuDung", _NgungSuDung);
                    cm.ExecuteNonQuery();
                }
            }
        }

        protected override void DataPortal_Update()
        {
            // save data into db
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_UpdatetblLoaiChungTu";
                        cm.Parameters.AddWithValue("@MaLoaiCT", _MaLoaiCT);
                        cm.Parameters.AddWithValue("@TenLoaiCT", _TenLoaiCT.ToString());
                        cm.Parameters.AddWithValue("@MaLoaiCTQuanLy", _MaLoaiCTQuanLy.ToString());
                        //ienTo ,TongKyTuPhanSo ,TrungTo ,HauTo ,KyTuSoBatDau,NgungSuDung    
                        cm.Parameters.AddWithValue("@TienTo", _TienTo);
                        cm.Parameters.AddWithValue("@TongKyTuPhanSo", _TongKyTuPhanSo);
                        cm.Parameters.AddWithValue("@TrungTo", _TrungTo);
                        cm.Parameters.AddWithValue("@HauTo", _HauTo);
                        cm.Parameters.AddWithValue("@KyTuSoBatDau", _KyTuSoBatDau);
                        cm.Parameters.AddWithValue("@NgungSuDung", _NgungSuDung);
                        cm.ExecuteNonQuery();
                        // make sure we're marked as an old object
                        MarkOld();
                    }
                }
                catch (Exception ex)

                {
                    throw ex;
                }
            }
        }

        
        protected override void DataPortal_Delete(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Delete_LoaiChungTu";
                    cm.Parameters.AddWithValue("@MaLoaiCT", _MaLoaiCT);
                    cm.ExecuteNonQuery();
                }
            }
        }


        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaLoaiCT));
        }

        #endregion
    }
}
