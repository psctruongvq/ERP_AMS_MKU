using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{
    public class ChungTuGoc : BusinessBase<ChungTuGoc>
    {
        private bool _idSet; 
        
        protected override object GetIdValue()
        {

            return _MaHoaDon;
        }

        #region Khai báo biến
        int _MaHoaDon;
        public int MaHoaDon
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    _idSet = true;
                    ChungTuGocList parent = (ChungTuGocList)this.Parent;
                    int max = 0;
                    if (Parent == null) return 0;
                    foreach (ChungTuGoc item in parent)
                    {
                        if (item.MaHoaDon > max)
                            max = item.MaHoaDon;
                   }
                   _MaHoaDon = max + 1;
                }
                   
                return _MaHoaDon;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaHoaDon.Equals(value))
                {
                    _idSet = true;
                    _MaHoaDon = value;
                    PropertyHasChanged();
                }
            }
        }

        String _SoHoaDon;
        public String SoHoaDon
        {
            get
            {
                CanReadProperty(true);
                return _SoHoaDon;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoHoaDon.Equals(value))
                {
                    _SoHoaDon = value;
                    PropertyHasChanged();
                }
            }
        }

        String _SoSeRi;
        public String SoSeRi
        {
            get
            {
                CanReadProperty(true);
                return _SoSeRi;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoSeRi.Equals(value))
                {
                    _SoSeRi = value;
                    PropertyHasChanged();
                }
            }
        }

        DateTime _NgayLap;
        public DateTime NgayLap
        {
            get
            {
                CanReadProperty(true);
                return _NgayLap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayLap.Equals(value))
                {
                    _NgayLap = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _PhanTramThue;
        public Decimal PhanTramThue
        {
            get
            {
                CanReadProperty(true);
                return _PhanTramThue;
            }
            set
            {
                CanWriteProperty(true);
                if (!_PhanTramThue.Equals(value))
                {
                    _PhanTramThue = value;
                    if (_PhanTramThue != 0)
                    {
                        _ThueSuat =Math.Round(_SoTien * _PhanTramThue / 100,0,MidpointRounding.AwayFromZero);
                        _TongTien = _SoTien + _ThueSuat;
                    }
                    PropertyHasChanged();
                }
            }
        }

        String _TenMatHang;
        public String TenMatHang
        {
            get
            {
                CanReadProperty(true);
                return _TenMatHang;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenMatHang.Equals(value))
                {
                    _TenMatHang = value;
                    PropertyHasChanged();
                }
            }
        }
     

        Decimal _SoTien;
        public Decimal SoTien
        {
            get
            {
                CanReadProperty(true);
                return _SoTien;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoTien.Equals(value))
                {
                    _SoTien = value;
                    if (_PhanTramThue != 0)
                    {
                        _ThueSuat = Math.Round(_SoTien * _PhanTramThue / 100, 0, MidpointRounding.AwayFromZero);
                    }
                    _TongTien = _SoTien + _ThueSuat;
                    PropertyHasChanged();
                }
            }
        }  
           

        DoiTuong _KhachHang;
        public DoiTuong KhachHang
        {
            get
            {
                CanReadProperty(true);
                return _KhachHang;
            }
            set
            {
                CanWriteProperty(true);
                if (!_KhachHang.Equals(value))
                {
                    _KhachHang = value;
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

        Decimal _ThueSuat;
        public Decimal ThueSuat
        {
            get
            {
                CanReadProperty(true);
                return _ThueSuat;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ThueSuat.Equals(value))
                {
                    _ThueSuat = value;
                    _TongTien = _SoTien + _ThueSuat;
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
                    _TongTien = _SoTien + _ThueSuat;
                    PropertyHasChanged();
                }
            }
        }

        #endregion                

        #region constructor
        private ChungTuGoc()
        {
            // Prevent direct creation
            _MaHoaDon = 0;
            _NgayLap = DateTime.Today;
            _PhanTramThue = 0;
            _SoHoaDon = String.Empty;
            
            _SoSeRi = String.Empty;
            _TenMatHang = String.Empty;
            _SoTien = 0;
            _ThueSuat = 0;
            
            
            _KhachHang = DoiTuong.NewDoiTuong(0);
            MarkAsChild();
        }
       
        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaChungTuGoc;

            public Criteria(int maChungTuGoc)
            {
                MaChungTuGoc = maChungTuGoc;
            }
        }

        [Serializable()]
        public class CriteriaTimChungTuGoc
        {
            public string _SoChungTuGoc;
            public CriteriaTimChungTuGoc(string sochungtugoc)
            {
                _SoChungTuGoc = sochungtugoc;
            }

        }     

        #endregion

        #region Static Methods
        //giống constructor
       
           public override ChungTuGoc Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaHoaDon));
        }
        public void Insert(SqlTransaction tr )
        {
            DataPortal_Insert(tr);
        }
        public void Update(SqlTransaction tr)
        {
            DataPortal_Update(tr);
        }    
         
        private ChungTuGoc(SafeDataReader dr)
        {
            try
            {
                MarkAsChild();
                _MaHoaDon = dr.GetInt32("MaHoaDon");
                _SoHoaDon = dr.GetString("SoHoaDon");
                _SoSeRi = dr.GetString("SoSeri");
                _NgayLap = dr.GetDateTime("NgayLap");
                _PhanTramThue = dr.GetDecimal("PhanTramThue");
                _TenMatHang = dr.GetString("TenMatHang");
                _ThueSuat = dr.GetDecimal("ThueSuat");
                _SoTien =dr.GetDecimal("SoTien");                
                _KhachHang = DoiTuong.GetDoiTuong(dr.GetInt32("MaKhachHang"));
                _idSet = true;
                MarkOld();
            }
            catch (Exception ee)
            {
                string temp = ee.Message;
            }
        }


        public static ChungTuGoc NewChungTuGoc()
        {
            return new ChungTuGoc();
        }
        public static ChungTuGoc NewChungTuGoc(DateTime ngayLap, String soHoaDon, String soSeri,
            int tienTe, String  tenMatHang, Decimal phanTramThue, int soLuong)
        {
            ChungTuGoc ctg = new ChungTuGoc();            
            ctg.NgayLap = ngayLap;
            ctg.SoHoaDon = soHoaDon;
            ctg.SoSeRi = soSeri;
            ctg.SoTien = tienTe;
            ctg.TenMatHang = tenMatHang;
            ctg.PhanTramThue = phanTramThue;
            
            ctg.MarkOld();
            return  ctg;
        }

        public static ChungTuGoc GetChungTuGoc(int maChungTuGoc)
        {
            return (ChungTuGoc)DataPortal.Fetch<ChungTuGoc>(new Criteria(maChungTuGoc));
        }

        public static ChungTuGoc GetChungTuGocTheoSoChungTu(String soChungTuGoc)
        {
            return (ChungTuGoc)DataPortal.Fetch<ChungTuGoc>(new CriteriaTimChungTuGoc(soChungTuGoc));
        }

        internal static ChungTuGoc GetChungTuGoc(SafeDataReader dr)
        {
            return new ChungTuGoc(dr);            
        }

        public static void DeleteChungTuGoc(int maChungTuGoc)
        {
            DataPortal.Delete(new Criteria(maChungTuGoc));
        }
        #endregion

        #region Data Access

        
        protected override void DataPortal_Fetch(object criteria)
        {           
            if(criteria is Criteria)
            {
                Criteria crit = (Criteria)criteria;
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadMaCaBiet_ChungTuGoc";
                        cm.Parameters.AddWithValue("@MaHoaDon", crit.MaChungTuGoc);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            dr.Read();
                            _MaHoaDon = dr.GetInt32("MaHoaDon");
                            _SoHoaDon = dr.GetString("SoHoaDon");
                            _SoSeRi = dr.GetString("SoSeri");
                            _NgayLap = dr.GetDateTime("NgayLap");
                            _PhanTramThue = dr.GetDecimal("PhanTramThue");
                            _TenMatHang = dr.GetString("TenMatHang");
                            _ThueSuat = dr.GetDecimal("ThueSuat");
                            _SoTien = dr.GetDecimal("SoTien");
                            _KhachHang = DoiTuong.GetDoiTuong(dr.GetInt32("MaKhachHang"));
                            _idSet = true;
                            // load child objects
                            dr.NextResult();
                        }
                    }
                    MarkOld();
                }               
            }
            else if (criteria is CriteriaTimChungTuGoc)
            {
                CriteriaTimChungTuGoc critb = (CriteriaTimChungTuGoc)criteria ;
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;                      
                        cm.CommandText = "spd_TestTim";
                        cm.Parameters.AddWithValue("@SoHoaDonNhap", critb._SoChungTuGoc);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            if (dr.Read())
                            {
                                _MaHoaDon = dr.GetInt32("MaHoaDon");
                                _SoHoaDon = dr.GetString("SoHoaDon");
                                _SoSeRi = dr.GetString("SoSeri");
                                _NgayLap = dr.GetDateTime("NgayLap");
                                _PhanTramThue = dr.GetDecimal("PhanTramThue");
                                _TenMatHang = dr.GetString("TenMatHang");
                                _ThueSuat = dr.GetDecimal("ThueSuat");
                                _SoTien = dr.GetDecimal("SoTien");
                                _KhachHang = DoiTuong.GetDoiTuong(dr.GetInt32("MaKhachHang"));
                                _idSet = true;
                                // load child objects
                                dr.NextResult();
                            }
                            
                        }
                    }
                    MarkOld();
                }               
            }
        }


        protected  void DataPortal_Insert( SqlTransaction tr)
        {

            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                try
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_ChungTuGoc";
                    cm.Parameters.AddWithValue("@MaHoaDon", _MaHoaDon).Direction = ParameterDirection.Output;
                    cm.Parameters.AddWithValue("@SoHoaDon", _SoHoaDon);
                    cm.Parameters.AddWithValue("@SoSeri", _SoSeRi);
                    cm.Parameters.AddWithValue("@NgayLap", _NgayLap);
                    cm.Parameters.AddWithValue("@PhanTramThue", _PhanTramThue);
                    cm.Parameters.AddWithValue("@TenMatHang", _TenMatHang);
                    cm.Parameters.AddWithValue("@ThueSuat", _ThueSuat);
                    cm.Parameters.AddWithValue("@SoTien", _SoTien);
                    cm.Parameters.AddWithValue("@MaKhachHang", _KhachHang.MaDoiTuong);
                    cm.Parameters.AddWithValue("@MaChungTu", ((ChungTuGocList)Parent)._MaChungTu);
                    cm.ExecuteNonQuery();
                    _MaHoaDon = (int)cm.Parameters["@MaHoaDon"].Value;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            
        }


        protected void DataPortal_Update(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                try
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Update_ChungTuGoc";
                    cm.Parameters.AddWithValue("@MaHoaDon", _MaHoaDon);    
                    cm.Parameters.AddWithValue("@SoHoaDon", _SoHoaDon);
                    cm.Parameters.AddWithValue("@SoSeri", _SoSeRi);
                    cm.Parameters.AddWithValue("@NgayLap", _NgayLap);
                    cm.Parameters.AddWithValue("@PhanTramThue", _PhanTramThue);
                    cm.Parameters.AddWithValue("@MaKhachHang", _KhachHang.MaDoiTuong);
                    cm.Parameters.AddWithValue("@TenMatHang", _TenMatHang);
                    cm.Parameters.AddWithValue("@ThueSuat", _ThueSuat);
                    cm.Parameters.AddWithValue("@SoTien", _SoTien);
                    cm.ExecuteNonQuery();
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
                    cm.CommandText = "spd_Delete_ChungTuGoc";
                    cm.Parameters.AddWithValue("@MaHoaDon", crit.MaChungTuGoc);
                    cm.ExecuteNonQuery();
                }
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaHoaDon));
        }     

        #endregion


        #region đọc tiền
        public static string moneyToText(string moneyStr)
        {
            long money;
            string returnStr = "";
            string fullText = "";
            int number;
            string[] digits = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };

            if (moneyStr[0] == '-')
            {
                fullText = "âm ";
                moneyStr = moneyStr.Substring(1);
            }
            try
            {
                money = long.Parse(moneyStr);
            }
            catch//(Exception e)
            {
                return "############";
            }
            if (moneyStr == "0")
                return "không đồng";
            int strLength = moneyStr.Length;

            for (int i = 0; i < strLength; i++)
            {
                number = int.Parse(moneyStr[i].ToString());
                switch ((strLength - i) % 3)
                {
                    case 0:    // hundred
                        if ((number == 0) && (int.Parse(moneyStr[i + 1].ToString()) == 0) && (int.Parse(moneyStr[i + 2].ToString()) == 0))
                            returnStr = "không";
                        else

                            returnStr = digits[number] + " trăm";
                        break;
                    case 2:    // ten
                        switch (number)
                        {
                            case 0:
                                returnStr = (int.Parse(moneyStr[i + 1].ToString()) == 0) ? "" : "lẻ";
                                break;
                            case 1:
                                returnStr = "mười ";
                                break;
                            default:
                                returnStr = digits[number] + " mươi";
                                break;
                        }
                        break;
                    case 1:    // unit

                        switch (number)
                        {
                            case 0:
                                returnStr = "";
                                break;
                            case 1:
                                try
                                {
                                    if (i == 0)
                                        returnStr = "một";
                                    else
                                        returnStr = (int.Parse(moneyStr[i - 1].ToString()) > 1) ? "mốt" : "một";


                                }
                                catch//(Exception  e)
                                {
                                }
                                break;
                            case 5:
                                try
                                {
                                    returnStr = (int.Parse(moneyStr[i - 1].ToString()) > 0) ? "lăm" : "năm";
                                }
                                catch//(Exception e)
                                {
                                }
                                break;
                            default:
                                returnStr = digits[number];
                                break;
                        }
                        break;
                }
                switch ((strLength - i) % 9)
                {
                    case 1:
                        returnStr += ((strLength - i) > 9) ? " tỉ" : " đồng";
                        break;
                    case 4:
                        returnStr += " ngàn";
                        break;
                    case 7:
                        returnStr += " triệu";
                        break;
                    default:
                        break;
                }
                fullText = fullText + " " + returnStr;
            }


            fullText = fullText.Replace("không tỉ", "tỷ");
            fullText = fullText.Replace("không triệu", "");
            fullText = fullText.Replace("không ngàn", "");
            fullText = fullText.Replace("không đồng", "đồng");
            fullText = fullText.Replace("   ", " ");

            //fullText=fullText.Replace("  ","");
            int ntemp = 1;
            string a = fullText[0].ToString();
            if (a == " ")
            {
                a = fullText[1].ToString();
                ntemp++;
            }

            a = a.ToUpper();
            fullText = a + fullText.Substring(ntemp);
            return fullText;
        }

        #endregion
    }
}
