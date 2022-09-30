using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.ComponentModel;

namespace ERP_Library
{
    [Serializable()]
    public class TaiSanCoDinh: BusinessBase<TaiSanCoDinh>
    {
        private bool _idSet;
        protected override object GetIdValue()
        {
            return _MaTSCD;
        }

        public override string ToString()
        {
            return _TenTSCD;
        }

        #region rule
        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "SoHieu");
            ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "TenTSCD");
            //ValidationRules.AddRule(Csla.Validation.CommonRules.IntegerMinValue, new Csla.Validation.CommonRules.IntegerMinValueRuleArgs("MaDonViTinh", 1));
            //ValidationRules.AddRule(Csla.Validation.CommonRules.IntegerMinValue, new Csla.Validation.CommonRules.IntegerMinValueRuleArgs("MaLoaiTaiSan", 1));
        }

        #endregion

        #region Properties

        private int _MaTSCD = GetMaTSCD_Max();
        public int MaTSCD
        {
            get
            {
                CanReadProperty(true);
                //if (!_idSet)
                //{
                //    _idSet = true;
                //    TaiSanCoDinhList parent = (TaiSanCoDinhList)this.Parent;
                //    int max = 0; // nen lay gtri max cua matscd roi gan lai cho max
                //    foreach (TaiSanCoDinh item in parent)
                //    {
                //        if (item.MaTSCD > max)
                //            max = item.MaTSCD;
                //    }
                //    _MaTSCD = max + 1;
                //}
                return _MaTSCD;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaTSCD.Equals(value))
                {
                    _MaTSCD = value;
                    PropertyHasChanged();
                }
            }
        }
        
        String _TenTSCD;
        public String TenTSCD
        {
            get
            {
                CanReadProperty(true);
                return _TenTSCD;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenTSCD.Equals(value))
                {
                    _TenTSCD = value;
                    PropertyHasChanged();
                }
            }
        }

        String _SoHieu;
        public String SoHieu
        {
            get
            {
                CanReadProperty(true);
                return _SoHieu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoHieu.Equals(value))
                {
                    _SoHieu = value;
                    PropertyHasChanged();
                }
            }
        }
        
        String _MoDel;
        public String MoDel
        {
            get
            {
                CanReadProperty(true);
                return _MoDel;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MoDel.Equals(value))
                {
                    _MoDel = value;
                    PropertyHasChanged();
                }
            }
        }
        
        //LoaiTaiSan _LoaiTaiSan;
        //public LoaiTaiSan LoaiTaiSan
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _LoaiTaiSan;
        //    }
        //    set
        //    {
        //        CanWriteProperty(true);
        //        if (!_LoaiTaiSan.Equals(value))
        //        {
        //            _LoaiTaiSan = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        private int _MaLoaiTaiSan;
        public int MaLoaiTaiSan
        {
            get
            {
                CanReadProperty(true);
                return _MaLoaiTaiSan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaLoaiTaiSan.Equals(value))
                {
                    _MaLoaiTaiSan = value;
                    PropertyHasChanged();
                }
            }
        }

        private string _TenLoaiTaiSan;
        public string TenLoaiTaiSan
        {
            get
            {
                CanReadProperty(true);
                _TenLoaiTaiSan = LoaiTaiSan.GetLoaiTaiSan(_MaLoaiTaiSan).TenLoaiTaiSan;
                return _TenLoaiTaiSan;
            }
        }

        //NuocSanXuat _NuocSanXuat;
        //public NuocSanXuat NuocSanXuat
        //{
        //    get
        //    {
        //        CanReadProperty(true);
        //        return _NuocSanXuat;
        //    }
        //    set
        //    {
        //        CanWriteProperty(true);
        //        if (!_NuocSanXuat.Equals(value))
        //        {
        //            _NuocSanXuat = value;
        //            PropertyHasChanged();
        //        }
        //    }
        //}

        private int _MaNuocSX;
        public int MaNuocSX
        {
            get
            {
                CanReadProperty(true);
                return _MaNuocSX;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaNuocSX.Equals(value))
                {
                    _MaNuocSX = value;
                    PropertyHasChanged();
                }
            }
        }

        private string _TenNuocSX;
        public string TenNuocSX
        {
            get
            {
                CanReadProperty(true);
                _TenNuocSX = QuocGia.GetQuocGia(_MaNuocSX).TenQuocGia;
                return _TenNuocSX;
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

        private int _MaDonViTinh;
        public int MaDonViTinh
        {
            get
            {
                CanReadProperty(true);
                return _MaDonViTinh;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaDonViTinh.Equals(value))
                {
                    _MaDonViTinh = value;
                    PropertyHasChanged();
                }
            }
        }

        private string _TenDonViTinh;
        public string TenDonViTinh
        {
            get
            {
                CanReadProperty(true);
               // _TenDonViTinh = DonViTinh.GetDonViTinh(_MaDonViTinh).TenDonViTinh;
                return _TenDonViTinh;
            }
        }
        
        int _TGSuDungToiDa;
        public int TGSuDungToiDa
        {
            get
            {
                CanReadProperty(true);
                return _TGSuDungToiDa;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TGSuDungToiDa.Equals(value))
                {
                    _TGSuDungToiDa = value;
                    PropertyHasChanged();
                }
            }
        }

        
        int _TGSuDungToiThieu;
        public int TGSuDungToiThieu
        {
            get
            {
                CanReadProperty(true);
                return _TGSuDungToiThieu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TGSuDungToiThieu.Equals(value))
                {
                    _TGSuDungToiThieu = value;
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
            public int MaTSCD;

            public Criteria(int maTSCD)
            {
                MaTSCD = maTSCD;
            }
        }

        #endregion

        #region Static Methods
        //giống constructor

        public override TaiSanCoDinh Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaTSCD));
        }

        public void Insert()
        {
            DataPortal_Insert();
        }

        public void Update()
        {
            DataPortal_Update();
        }    

        private TaiSanCoDinh(SafeDataReader dr)
        {
            MarkAsChild();
            _MaTSCD = dr.GetInt32("MaTSCD");
            _TenTSCD = dr.GetString("TenTSCD");
            //_NuocSanXuat = NuocSanXuat.GetNuocSanXuat(dr.GetInt32("MaNuocSX"));
            //_DonViTinh = DonViTinh.GetDonViTinh(dr.GetInt32("MaDonViTinh"));
            //_LoaiTaiSan = LoaiTaiSan.GetLoaiTaiSan(dr.GetInt32("MaLoaiTaiSan"));
            _MaNuocSX = dr.GetInt32("MaNuocSX");
            _MaDonViTinh = dr.GetInt32("MaDonViTinh");
            _MaLoaiTaiSan = dr.GetInt32("MaLoaiTaiSan");
            _MoDel = dr.GetString("Model");
            _SoHieu = dr.GetString("SoHieuTSCD");
            _TGSuDungToiDa = dr.GetInt32("TGSuDungToiDa");
            _TGSuDungToiThieu = dr.GetInt32("TGSuDungToiThieu");
            _idSet = true;
            MarkOld();
        }

        public static TaiSanCoDinh NewTaiSanCoDinh()
        {
            TaiSanCoDinh tscd = new TaiSanCoDinh();
            tscd.TenTSCD = String.Empty;
            tscd.SoHieu = String.Empty;
            //tscd.LoaiTaiSan = LoaiTaiSan.NewLoaiTaiSan();
            //tscd.DonViTinh = DonViTinh.NewDonViTinh();
            //tscd.NuocSanXuat = NuocSanXuat.NewNuocSanXuat();
            tscd.MaLoaiTaiSan = 0;
            tscd.MaDonViTinh = 0;
            tscd.MaNuocSX = 0;
            tscd.MoDel = String.Empty;
            tscd.TGSuDungToiDa = 0;
            tscd._TGSuDungToiThieu = 0;
            tscd.MarkDirty();
            tscd.ValidationRules.CheckRules();
            return tscd;
        }

        public static TaiSanCoDinh NewTaiSanCoDinh(string tenTSCD, int maNuocSx, int maDonViTinh, int maLoaiTaiSan, string model, string soHieuTSCD, int tgSuDungToiDa, int tgSuDungToiThieu)
        {
            TaiSanCoDinh tscd = new TaiSanCoDinh();                        
            tscd._TenTSCD = tenTSCD;
            //tscd._NuocSanXuat = NuocSanXuat.GetNuocSanXuat(maNuocSx);
            //tscd._DonViTinh = DonViTinh.GetDonViTinh(maDonViTinh);
            //tscd._LoaiTaiSan = LoaiTaiSan.GetLoaiTaiSan(maLoaiTaiSan);
            tscd._MaNuocSX = maNuocSx;
            tscd._MaDonViTinh = maDonViTinh;
            tscd._MaLoaiTaiSan = maLoaiTaiSan;
            tscd._MoDel = model;
            tscd._SoHieu = soHieuTSCD;
            tscd._TGSuDungToiDa = tgSuDungToiDa;
            tscd._TGSuDungToiThieu = tgSuDungToiThieu;
            tscd.MarkAsChild();
            tscd.MarkDirty();
            tscd.ValidationRules.CheckRules();
            return tscd;
        }

        public static TaiSanCoDinh GetTaiSanCoDinh(int maTSCD)
        {
            return (TaiSanCoDinh)DataPortal.Fetch<TaiSanCoDinh>(new Criteria(maTSCD));
        }

        internal static TaiSanCoDinh GetTaiSanCoDinh(SafeDataReader dr)
        {
            return new TaiSanCoDinh(dr);
        }

        public static void DeleteTaiSanCoDinh(int maTSCD)
        {
            DataPortal.Delete(new Criteria(maTSCD));
        }

        public static String GetSoHieu_TSCoDinhByLoai(int MaLoaiTSCD)
        {
            string SoHieuTaiSan = "";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_MaxSoHieuTaiSanTheoLoai";
                    cm.Parameters.AddWithValue("@MaLoaiTS", MaLoaiTSCD);
                    SqlParameter prmDoHieuTS = new SqlParameter("@SoHieuTaiSan", SqlDbType.VarChar, 20);
                    prmDoHieuTS.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmDoHieuTS);
                    //cm.Parameters.AddWithValue("@SoHieuTaiSan",
                    //cm.Parameters["@SoHieuTaiSan"].Direction = ParameterDirection.Output;
                    cm.ExecuteNonQuery();

                    /*if (cm.Parameters["@SoHieuTaiSan"].Value is System.DBNull)
                    {
                        return SoHieuTaiSan;
                    }

                    else SoHieuTaiSan = (string)cm.Parameters["@SoHieuTaiSan"].SqlValue.ToString(); */
                    return prmDoHieuTS.SqlValue.ToString();

                }
            }
            return SoHieuTaiSan;
        }

        public static int GetMaTSCD_Max()
        {
            int gtri;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetMax_MaTSCD";
                    SqlParameter gt = new SqlParameter("@gt", SqlDbType.Int);
                    gt.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(gt);
                    cm.ExecuteNonQuery();
                    gtri = int.Parse(gt.SqlValue.ToString());
                    return gtri;
                }
            }
            return gtri;
        }

        #endregion

        #region Constructors

        private TaiSanCoDinh()
        {
            // Prevent direct creation
            _TenTSCD = String.Empty;
            //_NuocSanXuat = NuocSanXuat.NewNuocSanXuat();
            //_DonViTinh = DonViTinh.NewDonViTinh();
            //_LoaiTaiSan = LoaiTaiSan.NewLoaiTaiSan();
            _MaNuocSX = 0;
            _MaDonViTinh = 0;
            _MaLoaiTaiSan = 0;
            _MoDel = String.Empty;
            _SoHieu = String.Empty;
            _TGSuDungToiDa = 0;
            _TGSuDungToiThieu = 0;
           
        }

        #endregion

        #region Data Access

        #region load tất cả cả
        protected override void DataPortal_Fetch(object criteria)
        {
            Criteria crit = (Criteria)criteria;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_TaiSanCoDinh";
                        cm.Parameters.AddWithValue("@MaTSCD", crit.MaTSCD);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaTSCD = dr.GetInt32("MaTSCD");
                                _TenTSCD = dr.GetString("TenTSCD");
                                //_NuocSanXuat = NuocSanXuat.GetNuocSanXuat(dr.GetInt32("MaNuocSX"));
                                //_DonViTinh = DonViTinh.GetDonViTinh(dr.GetInt32("MaDonViTinh"));
                                //_LoaiTaiSan = LoaiTaiSan.GetLoaiTaiSan(dr.GetInt32("MaLoaiTaiSan"));
                                _MaNuocSX = dr.GetInt32("MaNuocSX");
                                _MaDonViTinh = dr.GetInt32("MaDonViTinh");
                                _MaLoaiTaiSan = dr.GetInt32("MaLoaiTaiSan");
                                _MoDel = dr.GetString("Model");
                                _SoHieu = dr.GetString("SoHieuTSCD");
                                _TGSuDungToiDa = dr.GetInt32("TGSuDungToiDa");
                                _TGSuDungToiThieu = dr.GetInt32("TGSuDungToiThieu");
                                _idSet = true;
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
                        cm.CommandText = "spd_Insert_TaiSanCoDinh";
                        cm.Parameters.AddWithValue("@MaTSCD", _MaTSCD);
                        cm.Parameters.AddWithValue("@TenTSCD", _TenTSCD);
                        //if (_NuocSanXuat == null || _NuocSanXuat.MaNuocSX == 0)
                        //    cm.Parameters.AddWithValue("@MaNuocSX", DBNull.Value);
                        //else cm.Parameters.AddWithValue("@MaNuocSX", _NuocSanXuat.MaNuocSX);
                        //if (_DonViTinh==null || _DonViTinh.MaDonViTinh ==0)
                        //    cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
                        //else  cm.Parameters.AddWithValue("@MaDonViTinh", _DonViTinh.MaDonViTinh);
                        //cm.Parameters.AddWithValue("MaLoaiTaiSan", _LoaiTaiSan.MaLoaiTaiSan);
                        if (_MaNuocSX == 0)
                            cm.Parameters.AddWithValue("@MaNuocSX", DBNull.Value);
                        else 
                            cm.Parameters.AddWithValue("@MaNuocSX", _MaNuocSX);
                        if (_MaDonViTinh == 0)
                            cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
                        else 
                            cm.Parameters.AddWithValue("@MaDonViTinh", _MaDonViTinh);
                        cm.Parameters.AddWithValue("MaLoaiTaiSan", _MaLoaiTaiSan);

                        cm.Parameters.AddWithValue("Model", _MoDel);
                        cm.Parameters.AddWithValue("@SoHieuTSCD", _SoHieu);
                        cm.Parameters.AddWithValue("@TGSuDungToiDa", _TGSuDungToiDa);
                        cm.Parameters.AddWithValue("@TGSuDungToiThieu", _TGSuDungToiThieu);
                        cm.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected override void DataPortal_Update()
        {
            // save data into db
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    // we're not new, so update
                    cm.CommandText = "spd_Update_TaiSanCoDinh";
                    cm.Parameters.AddWithValue("@MaTSCD", _MaTSCD);
                    cm.Parameters.AddWithValue("@TenTSCD", _TenTSCD);
                    if (_MaNuocSX == 0)
                        cm.Parameters.AddWithValue("@MaNuocSX", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@MaNuocSX", _MaNuocSX);
                    if (_MaDonViTinh == 0)
                        cm.Parameters.AddWithValue("@MaDonViTinh", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@MaDonViTinh", _MaDonViTinh);
                    cm.Parameters.AddWithValue("MaLoaiTaiSan", _MaLoaiTaiSan);
               
                    cm.Parameters.AddWithValue("Model", _MoDel);
                    cm.Parameters.AddWithValue("@SoHieuTSCD", _SoHieu);
                    cm.Parameters.AddWithValue("@TGSuDungToiDa", _TGSuDungToiDa);
                    cm.Parameters.AddWithValue("@TGSuDungToiThieu", _TGSuDungToiThieu);
                    cm.ExecuteNonQuery();
                    // make sure we're marked as an old object
                    MarkOld();
                }
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
                    cm.CommandText = "spd_Delete_TaiSanCoDinh";
                    cm.Parameters.AddWithValue("@MaTSCD", _MaTSCD); 
                    cm.ExecuteNonQuery();
                }
            }
        }

        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaTSCD));
        }

        #endregion

        #endregion

        #endregion
    }
    #region Type Converter

    public class TaiSanCoDinhTypeConverter : TypeConverter
    {

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            int giatri = Convert.ToInt32(value);
            return TaiSanCoDinh.GetTaiSanCoDinh((int)giatri);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return ((TaiSanCoDinh)value).MaTSCD;
            }
            if (destinationType == typeof(String))
            {
                return ((TaiSanCoDinh)value).TenTSCD;
            }
            return value;
        }
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(Int32))
            {
                return true;
            }
            else if (destinationType == typeof(String))
            {
                return true;
            }
            return false;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(Int32))
            {
                return true;
            }
            else return false;
        }

    }
    #endregion 
}
