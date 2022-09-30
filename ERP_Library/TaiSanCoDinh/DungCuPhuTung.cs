using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class DungCuPhuTung:BusinessBase<DungCuPhuTung>
    {
        private bool _idSet;
        protected override object GetIdValue()
        {
            return _MaDungCuPhuTung;
        }

        #region rule
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "MaDungCuQuanLy");
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "TenDungCuPhuTung");
           // ValidationRules.AddRule(Csla.Validation.CommonRules.IntegerMinValue, new Csla.Validation.CommonRules.IntegerMinValueRuleArgs("SoLuong", 1));
           // ValidationRules.AddRule(KiemTraTextDecimal, "GiaTri");
        }

      /*  private bool KiemTraTextDecimal(object target, Csla.Validation.RuleArgs e)
        {
            if (_GiaTri == 0)
            {
                e.Description = "Vui Lòng Nhập Thành Tiền Cho Dụng Cụ";
                return false;
            }
            else
                return true;
        }*/
        
        #endregion



        #region Khai Bao Bien

        int _MaDungCuPhuTung;
        public int MaDungCuPhuTung
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    //generate a default id value
                    _idSet = true;
                    DungCuPhuTungList parent = (DungCuPhuTungList)this.Parent;
                    int max = 0;
                    foreach (DungCuPhuTung item in parent)
                    {
                        if (item.MaDungCuPhuTung > max)
                            max = item.MaDungCuPhuTung;
                    }
                    _MaDungCuPhuTung = max + 1;
                }
                return _MaDungCuPhuTung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaDungCuPhuTung.Equals(value))
                {
                    _idSet = true;
                    _MaDungCuPhuTung = value;
                    PropertyHasChanged();
                }
            }
        }

        String _MaDungCuQuanLy;
        public String MaDungCuQuanLy
        {
            get
            {
                CanReadProperty(true);
                return _MaDungCuQuanLy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaDungCuQuanLy.Equals(value))
                {
                    _MaDungCuQuanLy = value;
                    PropertyHasChanged();
                }
            }
        }

        String _TenDungCuPhuTung;
        public String TenDungCuPhuTung
        {
            get
            {
                CanReadProperty(true);
                return _TenDungCuPhuTung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenDungCuPhuTung.Equals(value))
                {
                    _TenDungCuPhuTung = value;
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

        DateTime _NgayNhan;
        public DateTime NgayNhan
        {
            get
            {
                CanReadProperty(true);
                return _NgayNhan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayNhan.Equals(value))
                {
                    _NgayNhan = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _NgaySuDung;
        public DateTime NgaySuDung
        {
            get
            {
                CanReadProperty(true);
                return _NgaySuDung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgaySuDung.Equals(value))
                {
                    _NgaySuDung = value;
                    PropertyHasChanged();
                }
            }
        }

        int _MaTSCDCaBiet;
        public int MaTSCDCaBiet
        {
            get
            {
                CanReadProperty(true);
                return _MaTSCDCaBiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaTSCDCaBiet.Equals(value))
                {
                    _MaTSCDCaBiet = value;
                    PropertyHasChanged();
                }
            }
        }

        //DonViTinh _DonViTinh;
        //public DonViTinh DonViTinh
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _DonViTinh;
        //    }
        //    set
        //    {
        //        CanWriteProperty(true);
        //        if (!_DonViTinh.Equals(value))
        //        {
        //            _DonViTinh = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}
        private int _maDVT;
        public int MaDVT
        {
            get
            {
                CanReadProperty("MaDVT", true);
                return _maDVT;
            }
            set
            {
                CanWriteProperty("MaDVT", true);
                if (!_maDVT.Equals(value))
                {
                    _maDVT = value;
                    PropertyHasChanged("MaDVT");
                }
            }
        }

        private string _tenDVT = string.Empty;
        public string TenDonViTinh
        {
            get
            {
                CanReadProperty(true);
                //_tenDVT = DonViTinh.GetDonViTinh(_maDVT).TenDonViTinh;
                return _tenDVT;
            }
        }
      
        int _SoLuong;
        public int SoLuong
        {
            get
            {
                CanReadProperty(true);
                return _SoLuong;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoLuong.Equals(value))
                {
                    _SoLuong = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _GiaTri;
        public Decimal GiaTri
        {
            get
            {
                CanReadProperty(true);
                return _GiaTri;
            }
            set
            {
                CanWriteProperty(true);
                if (!_GiaTri.Equals(value))
                {
                    _GiaTri = value;
                    PropertyHasChanged();
                }
            }
        }
        #endregion                

        #region Contructors
        private DungCuPhuTung()
        {
            _GhiChu = String.Empty;
            _GiaTri = 0;
            //_DonViTinh = DonViTinh.NewDonViTinh();
            _maDVT = 0;
            _MaDungCuPhuTung = 0;
            _NgayNhan = DateTime.Today;
            _NgaySuDung = DateTime.Today;
            _SoLuong = 0;
            _TenDungCuPhuTung = String.Empty;
            _MaTSCDCaBiet = 0;
            MarkAsChild();
            
        }
        #endregion

        #region Static Methods

        public override DungCuPhuTung Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaDungCuPhuTung));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void InsertTranSacTion(SqlTransaction tr)
        {
            DataPortal_InsertTranSacTion(tr);
        }
        public void Update()
        {
            DataPortal_Update();
        }

        public void UpdateTranSacTion(SqlTransaction tr)
        {
            DataPortal_UpdateTranSacTion(tr);
        }    


        private DungCuPhuTung(SafeDataReader dr)
        {
            MarkAsChild();
            try
            {
                _MaDungCuPhuTung = dr.GetInt32("MaDungCuPhuTung");
                _MaDungCuQuanLy = dr.GetString("MaDungCuQuanLy");
                _TenDungCuPhuTung = dr.GetString("TenDungCuPhuTung");
                _GhiChu = dr.GetString("GhiChu");
                _NgayNhan = dr.GetDateTime("NgayNhan");
                _NgaySuDung = dr.GetDateTime("NgaySuDung");
                _MaTSCDCaBiet = dr.GetInt32("MaTSCDCaBiet");
                //if (dr.GetInt32("MaDVT") !=0)    
                //    _DonViTinh= DonViTinh.GetDonViTinh( dr.GetInt32("MaDVT"));
                _maDVT = dr.GetInt32("MaDVT");
                _SoLuong = dr.GetInt32("SoLuong");
                _GiaTri = dr.GetDecimal("GiaTri");                
                _idSet = true;
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DungCuPhuTung NewDungCuPhuTung()
        {
            DungCuPhuTung dcpt = new DungCuPhuTung();
            dcpt._MaDungCuQuanLy = String.Empty;
            dcpt.TenDungCuPhuTung = String.Empty;
            dcpt.GhiChu = String.Empty;
            dcpt.NgayNhan = DateTime.Today;
            dcpt.NgaySuDung = DateTime.Today;
            dcpt.MaTSCDCaBiet = 0;
            //dcpt.DonViTinh = DonViTinh.NewDonViTinh();
            dcpt.MaDVT = 0;
            dcpt.SoLuong = 0;
            dcpt.GiaTri = 0;
            dcpt.MarkDirty();
            dcpt.ValidationRules.CheckRules();
            return dcpt;
        }

        public static DungCuPhuTung NewDungCuPhuTung( String maDungCuQuanLy, String ghiChu, Decimal giaTri, int maDVT, DateTime ngayNhan,
            DateTime ngaySuDung, int soLuong, String tenDungCu, int taiSCDCaBiet)
        {
            DungCuPhuTung dc = new DungCuPhuTung();
            dc._MaDungCuQuanLy = maDungCuQuanLy;
            dc._GhiChu = ghiChu;
            dc._GiaTri = giaTri;            
            dc._NgayNhan = ngayNhan;
            dc._NgaySuDung = ngaySuDung;
            dc._SoLuong = soLuong;
            dc._TenDungCuPhuTung = tenDungCu;
            if(taiSCDCaBiet!=0)
                dc.MaTSCDCaBiet = taiSCDCaBiet;
            //if(maDVT!=0)
            //    dc._DonViTinh=DonViTinh.GetDonViTinh( maDVT);
            if (maDVT != 0)
                dc._maDVT = maDVT;
            dc.MarkDirty();
            dc.ValidationRules.CheckRules();
            return dc;
        }

        public static DungCuPhuTung NewDungCuPhuTung(DungCuPhuTung dungCuPhuTung)
        {
            DungCuPhuTung dc = new DungCuPhuTung();
            dc._MaDungCuQuanLy = dungCuPhuTung.MaDungCuQuanLy;
            dc._GhiChu = dungCuPhuTung.GhiChu;
            dc._GiaTri = dungCuPhuTung.GiaTri;
            dc._NgayNhan = dungCuPhuTung.NgayNhan;
            dc._NgaySuDung = dungCuPhuTung.NgaySuDung;
            dc._SoLuong = dungCuPhuTung.SoLuong;
            dc._TenDungCuPhuTung = dungCuPhuTung.TenDungCuPhuTung;
            //if (taiSCDCaBiet != 0)
            //    dc.MaTSCDCaBiet = taiSCDCaBiet;
            //if (dungCuPhuTung.DonViTinh != null)
            //    dc._DonViTinh = dungCuPhuTung.DonViTinh;
            dc._maDVT = dungCuPhuTung.MaDVT;
            dc.MarkDirty();
            dc.ValidationRules.CheckRules();
            return dc;
        }

        public static DungCuPhuTung GetDungCuPhuTung(int maDungCuPhuTung)
        {
            return (DungCuPhuTung)DataPortal.Fetch<DungCuPhuTung>(new Criteria(maDungCuPhuTung));
        }

        internal static DungCuPhuTung GetDungCuPhuTung(SafeDataReader dr)
        {
            return new DungCuPhuTung(dr);
        }

        public static void DeleteDungCuPhuTung(int maDungCuPhuTung)
        {
            DataPortal.Delete(new Criteria(maDungCuPhuTung));
        }

        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaDungCuPhuTung;

            public Criteria(int maDungCuPhuTung)
            {
                MaDungCuPhuTung = maDungCuPhuTung;
            }
        }

        #endregion

        #region Data Access

        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadMaCaBiet_DungCuPhuTung";
                    cm.Parameters.AddWithValue("@MaDungCuPhuTung", crit.MaDungCuPhuTung);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _MaDungCuPhuTung = dr.GetInt32("MaDungCuPhuTung");
                        _MaDungCuQuanLy = dr.GetString("MaDungCuQuanLy");
                        _TenDungCuPhuTung = dr.GetString("TenDungCuPhuTung");
                        _GhiChu = dr.GetString("GhiChu");
                        _NgayNhan = dr.GetDateTime("NgayNhan");
                        _NgaySuDung = dr.GetDateTime("NgaySuDung");
                        _MaTSCDCaBiet = dr.GetInt32("MaTSCDCaBiet");
                        //if (dr.GetInt32("MaDVT") != 0)
                        //    _DonViTinh = DonViTinh.GetDonViTinh(dr.GetInt32("MaDVT"));
                        if (dr.GetInt32("MaDVT") != 0)
                            _maDVT = dr.GetInt32("MaDVT");
                        _SoLuong = dr.GetInt32("SoLuong");
                        _GiaTri = dr.GetDecimal("GiaTri");
                        _idSet = true;
                        dr.NextResult();
                    }
                }
                MarkOld();

            }
        }
        
        protected override void DataPortal_Insert()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Insert_DungCuPhuTung";
                        cm.Parameters.AddWithValue("@MaDungCuPhuTung", _MaDungCuPhuTung).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@MaDungCuQuanLy", _MaDungCuQuanLy);
                        cm.Parameters.AddWithValue("@TenDungCuPhuTung", _TenDungCuPhuTung);
                        cm.Parameters.AddWithValue("@GhiChu", _GhiChu);
                        cm.Parameters.AddWithValue("@NgayNhan", _NgayNhan);
                        cm.Parameters.AddWithValue("@NgaySuDung", _NgaySuDung);
                        if (_MaTSCDCaBiet == 0)
                        {
                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", ((DungCuPhuTungList)this.Parent)._MaTSCDCaBiet);
                        }
                        else
                        {
                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", _MaTSCDCaBiet);
                        }

                        if (_maDVT == null || _maDVT == 0)
                        {
                            cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                        }
                        else cm.Parameters.AddWithValue("@MaDVT", _maDVT);
                        cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
                        cm.Parameters.AddWithValue("@GiaTri", _GiaTri);
                        cm.ExecuteNonQuery();
                        _MaDungCuPhuTung = (int)cm.Parameters["@MaDungCuPhuTung"].Value;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void DataPortal_InsertTranSacTion(SqlTransaction tr)
        {
            try
            {
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_DungCuPhuTung";
                    cm.Parameters.AddWithValue("@MaDungCuPhuTung", _MaDungCuPhuTung).Direction = ParameterDirection.Output;
                    cm.Parameters.AddWithValue("@MaDungCuQuanLy", _MaDungCuQuanLy);
                    cm.Parameters.AddWithValue("@TenDungCuPhuTung", _TenDungCuPhuTung);
                    cm.Parameters.AddWithValue("@GhiChu", _GhiChu);
                    cm.Parameters.AddWithValue("@NgayNhan", _NgayNhan);
                    cm.Parameters.AddWithValue("@NgaySuDung", _NgaySuDung);
                    if (_MaTSCDCaBiet == 0)
                    {
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", ((DungCuPhuTungList)this.Parent)._MaTSCDCaBiet);
                    }
                    else
                    {
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _MaTSCDCaBiet);
                    }
                    if (_maDVT == null || _maDVT == 0)
                    {
                        cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                    }
                    else cm.Parameters.AddWithValue("@MaDVT", _maDVT);
                    //if (_DonViTinh == null || _DonViTinh.MaDonViTinh == 0)
                    //{
                    //    cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                    //}
                    //else cm.Parameters.AddWithValue("@MaDVT", _DonViTinh.MaDonViTinh);
                    cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
                    cm.Parameters.AddWithValue("@GiaTri", _GiaTri);
                    cm.ExecuteNonQuery();
                    _MaDungCuPhuTung = (int)cm.Parameters["@MaDungCuPhuTung"].Value;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                        cm.CommandText = "spd_Update_DungCuPhuTung";
                        cm.Parameters.AddWithValue("@MaDungCuPhuTung", _MaDungCuPhuTung);
                        cm.Parameters.AddWithValue("@MaDungCuQuanLy", _MaDungCuQuanLy);
                        cm.Parameters.AddWithValue("@TenDungCuPhuTung", _TenDungCuPhuTung);
                        cm.Parameters.AddWithValue("@GhiChu", _GhiChu);
                        cm.Parameters.AddWithValue("@NgayNhan", _NgayNhan);
                        cm.Parameters.AddWithValue("@NgaySuDung", _NgaySuDung);                        
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _MaTSCDCaBiet);
                        //if (_DonViTinh == null || _DonViTinh.MaDonViTinh == 0)
                        //{
                        //    cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                        //}
                        //else cm.Parameters.AddWithValue("@MaDVT", _DonViTinh.MaDonViTinh);
                        if (_maDVT == null || _maDVT == 0)
                        {
                            cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                        }
                        else cm.Parameters.AddWithValue("@MaDVT", _maDVT);

                        cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
                        cm.Parameters.AddWithValue("@GiaTri", _GiaTri);
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

        public void DataPortal_UpdateTranSacTion(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                // we're not new, so update
                cm.CommandText = "spd_Update_DungCuPhuTung";
                cm.Parameters.AddWithValue("@MaDungCuPhuTung", _MaDungCuPhuTung);
                cm.Parameters.AddWithValue("@MaDungCuQuanLy", _MaDungCuQuanLy);
                cm.Parameters.AddWithValue("@TenDungCuPhuTung", _TenDungCuPhuTung);
                cm.Parameters.AddWithValue("@GhiChu", _GhiChu);
                cm.Parameters.AddWithValue("@NgayNhan", _NgayNhan);
                cm.Parameters.AddWithValue("@NgaySuDung", _NgaySuDung);
                cm.Parameters.AddWithValue("@MaTSCDCaBiet", _MaTSCDCaBiet);
                //if (_DonViTinh == null || _DonViTinh.MaDonViTinh == 0)
                //{
                //    cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                //}
                //else cm.Parameters.AddWithValue("@MaDVT", _DonViTinh.MaDonViTinh);

                if (_maDVT == null || _maDVT == 0)
                    cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                else 
                    cm.Parameters.AddWithValue("@MaDVT", _maDVT);
                cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
                cm.Parameters.AddWithValue("@GiaTri", _GiaTri);
                cm.ExecuteNonQuery();
                // make sure we're marked as an old object
                MarkOld();
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
                    cm.CommandText = "spd_Delete_DungCuPhuTung";
                    cm.Parameters.AddWithValue("@MaDungCuPhuTung", _MaDungCuPhuTung);
                    cm.ExecuteNonQuery();
                }
            }
        }
        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaDungCuPhuTung));
        }
       
        #endregion
    }
}
