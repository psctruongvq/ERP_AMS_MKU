using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    public class ChiTietTaiSanCaBiet:BusinessBase<ChiTietTaiSanCaBiet>
    {
        
        private bool _idSet;
        protected override object GetIdValue()
        {
            return _MaChiTiet;
        }

        #region rule
        //protected override void AddBusinessRules()
        //{
        //    ValidationRules.AddRule(Csla.Validation.CommonRules.StringRequired, "TenChiTiet");
        //    ValidationRules.AddRule(Csla.Validation.CommonRules.IntegerMinValue, new Csla.Validation.CommonRules.IntegerMinValueRuleArgs("MaDVT", 1));
        //    ValidationRules.AddRule(Csla.Validation.CommonRules.IntegerMinValue, new Csla.Validation.CommonRules.IntegerMinValueRuleArgs("NamSanXuat", 1900));
        //    ValidationRules.AddRule(KiemTraTextDecimal, "NguyenGia");
        //}

      /*  private bool KiemTraTextDecimal(object target, Csla.Validation.RuleArgs e)
        {
          if (_NguyenGia==0)
          {
            e.Description = "Vui Lòng Nhập Nguyên Giá Cho Tài Sản";
            return false;
          }
          else
            return true;
        }*/
        

        #endregion

        #region Properties

        int _MaChiTiet;
        public int MaChiTiet
        {
            get
            {
                CanReadProperty(true);
                if (!_idSet)
                {
                    //generate a default id value
                    _idSet = true;
                    ChiTietTaiSanCaBietList parent = (ChiTietTaiSanCaBietList)this.Parent;
                    int max = 0;
                    foreach (ChiTietTaiSanCaBiet item in parent)
                    {
                        if (item.MaChiTiet > max)
                            max = item.MaChiTiet;
                    }
                    _MaChiTiet = max + 1;
                }
                return _MaChiTiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MaChiTiet.Equals(value))
                {
                    _MaChiTiet = value;
                    PropertyHasChanged();
                }
            }
        }

        
        String _TenChiTiet;
        public String TenChiTiet
        {
            get
            {
                CanReadProperty(true);
                return _TenChiTiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TenChiTiet.Equals(value))
                {
                    _TenChiTiet = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _NguyenGia;
        public Decimal NguyenGia
        {
            get
            {
                CanReadProperty(true);
                return _NguyenGia;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NguyenGia.Equals(value))
                {
                    _NguyenGia = value;
                    PropertyHasChanged();
                }
            }
        }

       

        int _maQuocGiaSX;
        public int MaQuocGiaSX
        {
            get
            {
                CanReadProperty(true);
                return _maQuocGiaSX;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maQuocGiaSX.Equals(value))
                {
                    _maQuocGiaSX = value;
                    PropertyHasChanged();
                }
            }
        }


        int _maDonViTinh;
        public int MaDonViTinh
        {
            get
            {
                CanReadProperty(true);
                return _maDonViTinh;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maDonViTinh.Equals(value))
                {
                    _maDonViTinh = value;
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

        int _NamSanXuat;
        public int NamSanXuat
        {
            get
            {
                CanReadProperty(true);
                return _NamSanXuat;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NamSanXuat.Equals(value))
                {
                    _NamSanXuat = value;
                    PropertyHasChanged();
                }
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

        String _Model;
        public String Model
        {
            get
            {
                CanReadProperty(true);
                return _Model;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Model.Equals(value))
                {
                    _Model = value;
                    PropertyHasChanged();
                }
            }
        }

        string _Serial;
        public string Serial
        {
            get
            {
                CanReadProperty(true);
                return _Serial;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Serial.Equals(value))
                {
                    _Serial = value;
                    PropertyHasChanged();
                }
            }
        }
        string _soHieu =string.Empty;
        public string SoHieu
        {
            get
            {
                CanReadProperty(true);
                return _soHieu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_soHieu.Equals(value))
                {
                    //_soHieu =  ChiTietTaiSanCaBiet.GetChiTietTaiSanCaBietByTSCDCaBiet(((ChiTietTaiSanCaBietList)this.Parent)._MaTSCDCaBiet);
                    _soHieu = value;
                    PropertyHasChanged();
                }
            }
        }
        #endregion

        #region Contructors
        private ChiTietTaiSanCaBiet()
        {
            _MaChiTiet = 0;
            _TenChiTiet = String.Empty; 
            _NguyenGia = 0;
            //_QuocGiaSX = NuocSanXuat.NewNuocSanXuat();
            //_DonViTinh= DonViTinh.NewDonViTinh();
            _maQuocGiaSX = 0;
            _maDonViTinh = 0;
            _MaTSCDCaBiet = 0;
            _NamSanXuat = 0;
            _SoLuong = 0;
            _Model = String.Empty;
            _Serial = String.Empty;
            MarkAsChild();

        }
        #endregion

        #region Static Methods

          public override ChiTietTaiSanCaBiet Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaChiTiet));
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

        public void UpdateTranSacTion( SqlTransaction tr)
        {
            DataPortal_UpdateTranSacTion(tr);
        }    
        private ChiTietTaiSanCaBiet(SafeDataReader dr)
        {
            MarkAsChild();
            try
            {
                _MaChiTiet = dr.GetInt32("MaChiTiet");
                _TenChiTiet = dr.GetString("TenChiTiet");
                _NguyenGia = dr.GetDecimal("NguyenGia");
                _maQuocGiaSX = dr.GetInt32("MaQuocGiaSX");
                _maDonViTinh = dr.GetInt32("MaDVT");
                _MaTSCDCaBiet=  dr.GetInt32("MaTSCDCaBiet");
                _NamSanXuat = dr.GetInt32("NamSanXuat");
                _SoLuong = dr.GetInt32("SoLuong");
                _Model = dr.GetString("Model");
                _Serial = dr.GetString("Serial");
                _soHieu = dr.GetString("SoHieu");
                _idSet = true;
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ChiTietTaiSanCaBiet NewChiTietTaiSanCaBiet()
        {
            ChiTietTaiSanCaBiet chiTietTSCB = new ChiTietTaiSanCaBiet();
            chiTietTSCB.MaChiTiet = 0;
            chiTietTSCB.TenChiTiet = String.Empty;
            chiTietTSCB.NguyenGia = 0;
            chiTietTSCB.MaQuocGiaSX = 0;
            chiTietTSCB.MaDonViTinh = 0;
            chiTietTSCB.MaTSCDCaBiet= 0;
            chiTietTSCB.NamSanXuat = 0;
            chiTietTSCB.SoLuong = 0;
            chiTietTSCB.Model = String.Empty;
            chiTietTSCB.MarkDirty();
            chiTietTSCB.ValidationRules.CheckRules();
            return new ChiTietTaiSanCaBiet();
        }

        public static ChiTietTaiSanCaBiet NewChiTietTaiSanCaBiet(ChiTietTaiSanCaBiet _chiTietTaiSanCaBiet)
        {
            ChiTietTaiSanCaBiet chiTietTSCB = new ChiTietTaiSanCaBiet();
            chiTietTSCB.MaChiTiet = 0;
            chiTietTSCB.TenChiTiet = _chiTietTaiSanCaBiet.TenChiTiet;
            chiTietTSCB.NguyenGia = _chiTietTaiSanCaBiet.NguyenGia;
            chiTietTSCB.MaQuocGiaSX = _chiTietTaiSanCaBiet.MaQuocGiaSX;
            chiTietTSCB.MaDonViTinh = _chiTietTaiSanCaBiet.MaDonViTinh;
            chiTietTSCB.MaTSCDCaBiet = _chiTietTaiSanCaBiet.MaTSCDCaBiet;
            chiTietTSCB.NamSanXuat = _chiTietTaiSanCaBiet.NamSanXuat;
            chiTietTSCB.SoLuong = _chiTietTaiSanCaBiet.SoLuong;
            chiTietTSCB.Model = _chiTietTaiSanCaBiet.Model;
            chiTietTSCB.MarkDirty();
            chiTietTSCB.ValidationRules.CheckRules();
            return chiTietTSCB;
        }


        public static ChiTietTaiSanCaBiet NewChiTietTaiSanCaBiet(string tenChiTiet, Decimal nguyenGia, int maQuocGia, int maDVT, int maTSCDCaBiet, int namSanXuat, int soLuong, String model, String soHieu)
        {
            ChiTietTaiSanCaBiet chiTietTSCB = new ChiTietTaiSanCaBiet();
            chiTietTSCB.TenChiTiet = tenChiTiet;
            chiTietTSCB.NguyenGia = nguyenGia;
            chiTietTSCB.MaQuocGiaSX = maQuocGia;
            chiTietTSCB.MaDonViTinh = maDVT;
            chiTietTSCB.MaTSCDCaBiet =  maTSCDCaBiet;
            chiTietTSCB.NamSanXuat = namSanXuat;
            chiTietTSCB.SoLuong = soLuong;
            chiTietTSCB.Model = model;
            chiTietTSCB.SoHieu = soHieu;
            chiTietTSCB.MarkDirty();            
            return chiTietTSCB;
        }

        public static ChiTietTaiSanCaBiet GetChiTietTaiSanCaBiet(int maChiTiet)
        {
            return (ChiTietTaiSanCaBiet)DataPortal.Fetch<ChiTietTaiSanCaBiet>(new Criteria(maChiTiet));
        }

        public static string GetChiTietTaiSanCaBietByTSCDCaBiet(int maTSCDCaBiet)
        {
            string sohieu = string.Empty;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "dbo.TimSoHieuChTietMax";
                    cm.Parameters.AddWithValue("@MaChiTiet", maTSCDCaBiet);
                   sohieu=(string)cm.ExecuteScalar();
                   return sohieu;                 
                }               

            }
        }

        internal static ChiTietTaiSanCaBiet GetChiTietTaiSanCaBiet(SafeDataReader dr)
        {
            return new ChiTietTaiSanCaBiet(dr);
        }

        public static void DeleteChiTietTaiSanCaBiet(int maChiTiet)
        {
            DataPortal.Delete(new Criteria(maChiTiet));
        }

        #endregion

        #region Criteria

        [Serializable()]
        private class Criteria
        {
            // Add criteria here
            public int MaChiTiet;

            public Criteria(int maChiTiet)
            {
                MaChiTiet = maChiTiet;
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
                    cm.CommandText = "spd_LoadMaCaBiet_ChiTietTaiSanCaBiet";
                    cm.Parameters.AddWithValue("@MaChiTiet", crit.MaChiTiet);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        dr.Read();
                        _MaChiTiet = dr.GetInt32("MaChiTiet");
                        _TenChiTiet = dr.GetString("TenChiTiet");
                        _NguyenGia = dr.GetDecimal("NguyenGia");
                        _maQuocGiaSX = dr.GetInt32("MaQuocGiaSX");
                        _maDonViTinh = dr.GetInt32("MaDVT");
                        //_QuocGiaSX = QuocGia.GetQuocGia(dr.GetInt32("MaQuocGiaSX"));
                        //_DonViTinh = DonViTinh.GetDonViTinh(dr.GetInt32("MaDVT"));
                        _MaTSCDCaBiet = dr.GetInt32("MaTSCDCaBiet");
                        _NamSanXuat = dr.GetInt32("NamSanXuat");
                        _SoLuong = dr.GetInt32("SoLuong");
                        _Model = dr.GetString("Model");
                        _Serial = dr.GetString("Serial");
                        _soHieu = dr.GetString("SoHieu");
                        _idSet = true;
                        // load child objects
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
                        cm.CommandText = "spd_Insert_ChiTietTaiSanCaBiet";
                        cm.Parameters.AddWithValue("@MaChiTietTSCDCaBiet", _MaChiTiet).Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@TenChiTiet", _TenChiTiet);
                        cm.Parameters.AddWithValue("@NguyenGia", _NguyenGia);
                        if (_maQuocGiaSX == 0)
                            cm.Parameters.AddWithValue("@MaQuocGiaSX", DBNull.Value);
                        else 
                            cm.Parameters.AddWithValue("@MaQuocGiaSX", _maQuocGiaSX);
                        if (_maDonViTinh==0)
                            cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                        else 
                            cm.Parameters.AddWithValue("@MaDVT", _maDonViTinh);
                        if (MaTSCDCaBiet==0)
                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", ((ChiTietTaiSanCaBietList)this.Parent)._MaTSCDCaBiet);
                        else
                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", MaTSCDCaBiet);
                        if (_NamSanXuat ==0)
                            cm.Parameters.AddWithValue("@NamSanXuat", DBNull.Value);
                        else 
                            cm.Parameters.AddWithValue("@NamSanXuat", _NamSanXuat);
                        cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
                        cm.Parameters.AddWithValue("@Model", _Model);
                        cm.Parameters.AddWithValue("@Serial", _Serial);
                        cm.Parameters.AddWithValue("@SoHieu", _soHieu);
                        cm.ExecuteNonQuery();
                        _MaChiTiet = (int)cm.Parameters["@MaChiTietTSCDCaBiet"].Value; 
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
                    cm.CommandText = "spd_Insert_ChiTietTaiSanCaBiet";
                    cm.Parameters.AddWithValue("@MaChiTietTSCDCaBiet", _MaChiTiet).Direction = ParameterDirection.Output;
                    cm.Parameters.AddWithValue("@TenChiTiet", _TenChiTiet);
                    cm.Parameters.AddWithValue("@NguyenGia", _NguyenGia);
                    if (_maQuocGiaSX == 0)
                        cm.Parameters.AddWithValue("@MaQuocGiaSX", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@MaQuocGiaSX", _maQuocGiaSX);
                    if (_maDonViTinh == 0)
                        cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@MaDVT", _maDonViTinh);
                    if (MaTSCDCaBiet == 0)
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", ((ChiTietTaiSanCaBietList)this.Parent)._MaTSCDCaBiet);
                    else
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", MaTSCDCaBiet);
                    if (_NamSanXuat == 0)
                        cm.Parameters.AddWithValue("@NamSanXuat", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@NamSanXuat", _NamSanXuat);
                    cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
                    cm.Parameters.AddWithValue("@Model", _Model);
                    cm.Parameters.AddWithValue("@Serial", _Serial);
                    cm.Parameters.AddWithValue("@SoHieu", _soHieu);
                    cm.ExecuteNonQuery();
                    _MaChiTiet = (int)cm.Parameters["@MaChiTietTSCDCaBiet"].Value;
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
                        cm.CommandText = "spd_Update_ChiTietTaiSanCaBiet";
                        cm.Parameters.AddWithValue("@MaChiTiet", _MaChiTiet);
                        cm.Parameters.AddWithValue("@TenChiTiet", _TenChiTiet);
                        cm.Parameters.AddWithValue("@NguyenGia", _NguyenGia);
                        if (_maQuocGiaSX == 0)
                            cm.Parameters.AddWithValue("@MaQuocGiaSX", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaQuocGiaSX", _maQuocGiaSX);
                        if (_maDonViTinh == 0)
                            cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaDVT", _maDonViTinh);
                        //if (_maQuocGiaSX.MaQuocGia == 0)
                        //    cm.Parameters.AddWithValue("@MaQuocGiaSX", DBNull.Value);
                        //else
                        //    cm.Parameters.AddWithValue("@MaQuocGiaSX", _maQuocGiaSX.MaQuocGia);
                        //if (DonViTinh.MaDonViTinh == 0)
                        //    cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                        //else
                        //    cm.Parameters.AddWithValue("@MaDVT", _maDonViTinh.MaDonViTinh);
                        if (MaTSCDCaBiet == 0)
                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", MaTSCDCaBiet);
                        cm.Parameters.AddWithValue("@NamSanXuat", _NamSanXuat); 
                        cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
                        cm.Parameters.AddWithValue("@Model", _Model);
                        cm.Parameters.AddWithValue("@Serial", _Serial);
                        cm.Parameters.AddWithValue("@SoHieu", _soHieu);
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
                cm.CommandText = "spd_Update_ChiTietTaiSanCaBiet";
                cm.Parameters.AddWithValue("@MaChiTiet", _MaChiTiet);
                cm.Parameters.AddWithValue("@TenChiTiet", _TenChiTiet);
                cm.Parameters.AddWithValue("@NguyenGia", _NguyenGia);
                if (_maQuocGiaSX == 0)
                    cm.Parameters.AddWithValue("@MaQuocGiaSX", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@MaQuocGiaSX", _maQuocGiaSX);
                if (_maDonViTinh == 0)
                    cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@MaDVT", _maDonViTinh);
                if (_maQuocGiaSX == 0)
                    cm.Parameters.AddWithValue("@MaQuocGiaSX", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@MaQuocGiaSX", _maQuocGiaSX);
                //if (DonViTinh.MaDonViTinh == 0)
                //    cm.Parameters.AddWithValue("@MaDVT", DBNull.Value);
                //else
                //    cm.Parameters.AddWithValue("@MaDVT", _maDonViTinh.MaDonViTinh);
                if (MaTSCDCaBiet == 0)
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", MaTSCDCaBiet);
                cm.Parameters.AddWithValue("@NamSanXuat", _NamSanXuat);
                cm.Parameters.AddWithValue("@SoLuong", _SoLuong);
                cm.Parameters.AddWithValue("@Model", _Model);
                cm.Parameters.AddWithValue("@Serial", _Serial);
                cm.Parameters.AddWithValue("@SoHieu", _soHieu);
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
                    cm.CommandText = "spd_Delete_ChiTietTaiSanCaBiet";
                    cm.Parameters.AddWithValue("@MaChiTiet", _MaChiTiet);
                    cm.ExecuteNonQuery();
                }
            }
        }

        
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaChiTiet));
        }
        #endregion

        #endregion
    }
}
