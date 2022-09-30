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
    [TypeConverter(typeof(TSCDCaBietTypeConverter))]
    [Serializable()]
    public class TSCDCaBiet: BusinessBase<TSCDCaBiet>
    {
        private bool _idSet = false;
        protected override object GetIdValue()
        {
            return _MaTSCDCaBiet;
        }

        #region Override
        public override bool IsDirty
        {
            get
            {
                return base.IsDirty || _TaiSanCoDinh.IsDirty; // || _Nguon.IsDirty || _NhaCungCap.IsDirty;
            }
        }
        public override bool IsValid
        {
            get
            {
                return base.IsValid || _TaiSanCoDinh.IsValid;// || _Nguon.IsValid || _NhaCungCap.IsValid;
            }
        }
        #endregion

        #region Khai Bao Bien

        int _MaTSCDCaBiet;
        public int MaTSCDCaBiet
        {
            get
            {
                CanReadProperty(true);
               /* if (!_idSet)
                {
                    _idSet = true;
                    if (Parent == null) return 0;
                    TaiSanCoDinhCaBietList parent = (TaiSanCoDinhCaBietList)this.Parent;

                    int max = 0;
                    foreach (TSCDCaBiet item in parent)
                    {
                        if (item.MaTSCDCaBiet > max)
                            max = item.MaTSCDCaBiet;
                    }
                    _MaTSCDCaBiet = max + 1;
                }*/
                    
                
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

        String _SoHieuCB;
        public String SoHieuCB
        {
            get
            {
                CanReadProperty(true);
                return _SoHieuCB;
            }
            set
            {
                CanWriteProperty(true);
                if (!_SoHieuCB.Equals(value))
                {
                    _SoHieuCB = value;
                    PropertyHasChanged();
                }
            }
        }
        
        String _Serial;
        public String Serial
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
        
        String _Barcode;
        public String Barcode
        {
            get
            {
                CanReadProperty(true);
                return _Barcode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_Barcode.Equals(value))
                {
                    _Barcode = value;
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
        
        Decimal _NguyenGiaMua;
        public Decimal NguyenGiaMua
        {
            get
            {
                CanReadProperty(true);
                return _NguyenGiaMua;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NguyenGiaMua.Equals(value))
                {
                    _NguyenGiaMua = value;
                    PropertyHasChanged();
                }
            }
        }
        
        Decimal _NguyenGiaConLai;
        public Decimal NguyenGiaConLai
        {
            get
            {
                CanReadProperty(true);
                return _NguyenGiaConLai;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NguyenGiaConLai.Equals(value))
                {
                    _NguyenGiaConLai = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _NguyenGiaTinhKhauHao;
        public Decimal NguyenGiaTinhKhauHao
        {
            get
            {
                CanReadProperty(true);
                return _NguyenGiaTinhKhauHao;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NguyenGiaTinhKhauHao.Equals(value))
                {
                    _NguyenGiaTinhKhauHao = value;
                    PropertyHasChanged();
                }
            }
        }

        String _CongSuat;
        public String CongSuat
        {
            get
            {
                CanReadProperty(true);
                return _CongSuat;
            }
            set
            {
                CanWriteProperty(true);
                if (!_CongSuat.Equals(value))
                {
                    _CongSuat = value;
                    PropertyHasChanged();
                }
            }
        }

        SmartDate _NgayNhan = new SmartDate(DateTime.Today);
        public DateTime NgayNhan
        {
            get
            {
                CanReadProperty(true);
                return _NgayNhan.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayNhan.Equals(value))
                {
                    _NgayNhan = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        SmartDate _NgaySuDung = new SmartDate(DateTime.Today);
        public DateTime NgaySuDung
        {
            get
            {
                CanReadProperty(true);
                return _NgaySuDung.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgaySuDung.Equals(value))
                {
                    _NgaySuDung = new SmartDate(value);
                    PropertyHasChanged();
                }
            }
        }

        SmartDate _NgayHetHanBaoHanh = new SmartDate(DateTime.Today);
        //public SmartDate NgayHetHanBaoHanh // mac dinh ban dau
        public DateTime NgayHetHanBaoHanh
        {
            get
            {
                CanReadProperty(true);
                return _NgayHetHanBaoHanh.Date;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NgayHetHanBaoHanh.Equals(value))
                {
                    //_NgayHetHanBaoHanh = value; // default
                    _NgayHetHanBaoHanh = new SmartDate(value);
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
        
        
        Decimal _TyLeKhauHaoNam;
        public Decimal TyLeKhauHaoNam
        {
            get
            {
                CanReadProperty(true);
                return _TyLeKhauHaoNam;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TyLeKhauHaoNam.Equals(value))
                {
                    _TyLeKhauHaoNam = value;
                    PropertyHasChanged();
                }
            }
        }
        
        String _ViTri;
        public String ViTri
        {
            get
            {
                CanReadProperty(true);
                return _ViTri;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ViTri.Equals(value))
                {
                    _ViTri = value;
                    PropertyHasChanged();
                }
            }
        }
        
        Boolean _MucDichSuDung;
        public Boolean MucDichSuDung
        {
            get
            {
                CanReadProperty(true);
                return _MucDichSuDung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_MucDichSuDung.Equals(value))
                {
                    _MucDichSuDung = value;
                    PropertyHasChanged();
                }
            }
        }
        
        byte _QuyetToan;
        public byte QuyetToan
        {
            get
            {
                CanReadProperty(true);
                return _QuyetToan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_QuyetToan.Equals(value))
                {
                    _QuyetToan = value;
                    PropertyHasChanged();
                }
            }
        }

        Boolean _BaoHiem;
        public Boolean BaoHiem
        {
            get
            {
                CanReadProperty(true);
                return _BaoHiem;
            }
            set
            {
                CanWriteProperty(true);
                if (!_BaoHiem.Equals(value))
                {
                    _BaoHiem = value;
                    PropertyHasChanged();
                }
            }
        }

        
        Boolean _NgungSuDung = false;
        public Boolean NgungSuDung
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
        
        Boolean _ThanhLy;
        public Boolean ThanhLy
        {
            get
            {
                CanReadProperty(true);
                return _ThanhLy;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ThanhLy.Equals(value))
                {
                    _ThanhLy = value;
                    PropertyHasChanged();
                }
            }
        }
        
        TaiSanCoDinh _TaiSanCoDinh;
        public TaiSanCoDinh TaiSanCoDinh
        {
            get
            {
                CanReadProperty(true);
                return _TaiSanCoDinh;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TaiSanCoDinh.Equals(value))
                {
                    _TaiSanCoDinh = value;                    
                    PropertyHasChanged();
                }
            }
        }
        
        long _maNhaCungCap;
        public long MaNhaCungCap
        {
            get
            {
                CanReadProperty(true);
                return _maNhaCungCap;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maNhaCungCap.Equals(value))
                {
                    _maNhaCungCap = value;
                    PropertyHasChanged();
                }
            }
        }

        public string TenNhaCungCap
        {
            get
            {
                CanReadProperty(true);
                return DoiTac.GetDoiTac(_maNhaCungCap).TenDoiTac;
            }
        }
        
        Boolean _NguonMua;
        public Boolean NguonMua
        {
            get
            {
                CanReadProperty(true);
                return _NguonMua;
            }
            set
            {
                CanWriteProperty(true);
                if (!_NguonMua.Equals(value))
                {
                    _NguonMua = value;
                    PropertyHasChanged();
                }
            }
        }

        int _maNguon;
        public int MaNguon
        {
            get
            {
                CanReadProperty(true);
                return _maNguon;
            }
            set
            {
                CanWriteProperty(true);
                if (!_maNguon.Equals(value))
                {
                    _maNguon = value;
                    PropertyHasChanged();
                }
            }
        }
      

        Decimal _PhiVanChuyen;
        public Decimal PhiVanChuyen
        {
            get
            {
                CanReadProperty(true);
                return _PhiVanChuyen;
            }
            set
            {
                CanWriteProperty(true);
                if (!_PhiVanChuyen.Equals(value))
                {
                    _PhiVanChuyen = value;
                    PropertyHasChanged();
                }
            }
        }

        Decimal _PhiChayThu;
        public Decimal PhiChayThu
        {
            get
            {
                CanReadProperty(true);
                return _PhiChayThu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_PhiChayThu.Equals(value))
                {
                    _PhiChayThu = value;
                    PropertyHasChanged();
                }
            }
        }

        string _TaiKhoanDoiUng = string.Empty;
        public string TaiKhoanDoiUng
        {
            get
            {
                CanReadProperty(true);
                return _TaiKhoanDoiUng;
            }
            set
            {
                CanWriteProperty(true);
                if (!_TaiKhoanDoiUng.Equals(value))
                {
                    _TaiKhoanDoiUng = value;
                    PropertyHasChanged();
                }
            }
        }

        //hỏi đại ca LCQV
        int _maPhongBan;
        public int MaPhongBan
        {
            get {            
            
                CanReadProperty(true);
                return _maPhongBan;
                /*if (_MaTSCDCaBiet == 0) return PhongBan.NewPhongBan();
                return NghiepVuPhanBo.GetPhongBanCuaTSCDCaBiet(_MaTSCDCaBiet);            */
            }
            set
            {
                CanWriteProperty(true);
                if (!_maPhongBan.Equals(value))
                {
                    _maPhongBan = value;
                    PropertyHasChanged();
                }
            }
        }

        string _tenPhongBan;
        public String TenPhongBan
        {
            get
            {
                CanReadProperty(true);
                return _tenPhongBan;
            }
            set
            {
                CanWriteProperty(true);
                if (!_tenPhongBan.Equals(value))
                {
                    _tenPhongBan = value;
                    PropertyHasChanged();
                }
            }
        }

        //String _Model;
        public String Model
        {
            get
            {
                CanReadProperty(true);
                return _TaiSanCoDinh.MoDel;
            }            
        }

        Boolean _DaDuyet;
        public Boolean DaDuyet
        {
            get
            {
                CanReadProperty(true);
                return _DaDuyet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_DaDuyet.Equals(value))
                {
                    _DaDuyet = value;
                    PropertyHasChanged();
                }
            }
        }

        int _LoaiNghiepVu;
        public int LoaiNghiepVu
        {
            get
            {
                CanReadProperty(true);
                return _LoaiNghiepVu;
            }
            set
            {
                CanWriteProperty(true);
                if (!_LoaiNghiepVu.Equals(value))
                {
                    _LoaiNghiepVu = value;
                    PropertyHasChanged();
                }
            }
        }

        String _SoHopDong;
        public String SoHopDong
        {
            get
            {
                CanReadProperty(true);
                return _SoHopDong;
            }
        }

        String _TenHopDong;
        public String TenHopDong
        {
            get
            {
                CanReadProperty(true);
                return _TenHopDong;
            }
        }

        DateTime _NgayKyHopDong;
        public DateTime NgayKyHopDong
        {
            get
            {
                CanReadProperty(true);
                return _NgayKyHopDong;
            }
        }

        string _NgayKyHDString;
        public string NgayKyHDString
        {
            get
            {
                CanReadProperty(true);
                return _NgayKyHopDong.Year < 1700 ? string.Empty : _NgayKyHopDong.ToShortDateString();
            }
        }

        ChiTietTaiSanCaBietList _ListChiTietTaisanCaBiet;
        public ChiTietTaiSanCaBietList ListChiTietTaisanCaBiet
        {
            get
            {
                CanReadProperty(true);
                return _ListChiTietTaisanCaBiet;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ListChiTietTaisanCaBiet.Equals(value))
                {
                    _ListChiTietTaisanCaBiet = value;
                    PropertyHasChanged();
                }
            }
        }

        DungCuPhuTungList _ListDungCuPhuTung;
        public DungCuPhuTungList ListDungCuPhuTung
        {
            get
            {
                CanReadProperty(true);
                return _ListDungCuPhuTung;
            }
            set
            {
                CanWriteProperty(true);
                if (!_ListDungCuPhuTung.Equals(value))
                {
                    _ListDungCuPhuTung = value;
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
            public int MaTSCDCaBiet;

            public Criteria(int maTSCDBaBiet)
            {
                MaTSCDCaBiet = maTSCDBaBiet;
            }
        }

        private class Criteria_SoHieuTS
        {
            // Add criteria here
            public string _SoHieuTSCDCaBiet;

            public Criteria_SoHieuTS(string soHieuTSCDCaBiet)
            {
                _SoHieuTSCDCaBiet = soHieuTSCDCaBiet;
            }
        }

        #endregion

        #region Static Methods
        //giống constructor

        public override TSCDCaBiet Save()
        {
            return base.Save();
        }

        public void DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaTSCDCaBiet));
        }

        public void Insert(SqlTransaction tr)
        {
            InsertTranSacTion(tr);
        }

        public void Update(SqlTransaction tr)
        {
            DataPortal_Update(tr);
        }

        public void UpdateTaiSanCaBiet()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    // we're not new, so update
                    cm.CommandText = "spd_Update_TaiSanCoDinhCaBiet";
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", _MaTSCDCaBiet);
                    cm.Parameters.AddWithValue("@SoHieu", _SoHieuCB);
                    if (_Serial == "")
                        cm.Parameters.AddWithValue("@Serial", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@Serial", _Serial);
                    if (_Barcode == "")
                        cm.Parameters.AddWithValue("@Barcode", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@Barcode", _Barcode);
                    if (_NamSanXuat == 0)
                        cm.Parameters.AddWithValue("@NamSX", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@NamSX", _NamSanXuat);
                    cm.Parameters.AddWithValue("@NguyenGiaMua", _NguyenGiaMua);
                    cm.Parameters.AddWithValue("@NguyenGiaConLai", _NguyenGiaConLai);
                    cm.Parameters.AddWithValue("CongSuat", _CongSuat);
                    cm.Parameters.AddWithValue("NgayNhan", _NgayNhan.DBValue);
                    cm.Parameters.AddWithValue("NgaySuDung", _NgaySuDung.DBValue);


                    cm.Parameters.AddWithValue("@NgayHetHanBaoHanh", _NgayHetHanBaoHanh.DBValue);
                    cm.Parameters.AddWithValue("ThoiGianSuDung", _ThoiGianSuDung);

                    cm.Parameters.AddWithValue("KhauHaoNam", _TyLeKhauHaoNam);
                    if (_ViTri == "")
                        cm.Parameters.AddWithValue("ViTri", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("ViTri", _ViTri);
                    cm.Parameters.AddWithValue("MucDichSuDung", _MucDichSuDung);
                    cm.Parameters.AddWithValue("@QuyetToan", _QuyetToan);
                    cm.Parameters.AddWithValue("@BaoHiem", _BaoHiem);
                    cm.Parameters.AddWithValue("NgungSuDung", _NgungSuDung);
                    cm.Parameters.AddWithValue("@ThanhLy", _ThanhLy);
                    cm.Parameters.AddWithValue("@MaTSCD", _TaiSanCoDinh.MaTSCD);
                    cm.Parameters.AddWithValue("@MaNhaCungCap", _maNhaCungCap);
                    cm.Parameters.AddWithValue("@NguonMua", _NguonMua);
                    cm.Parameters.AddWithValue("@ChiPhiVanChuyen", _PhiVanChuyen);
                    cm.Parameters.AddWithValue("@ChiPhiChayThu", _PhiChayThu);
                    if (_maNguon == 0)
                        cm.Parameters.AddWithValue("@MaNguon ", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@MaNguon ", _maNguon);

                    if (_TaiKhoanDoiUng == String.Empty)
                        cm.Parameters.AddWithValue("@TaiKhoanDoiUng", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@TaiKhoanDoiUng", _TaiKhoanDoiUng);
                    cm.ExecuteNonQuery();

                    //_ListChiTietTaisanCaBiet._MaTSCDCaBiet = _MaTSCDCaBiet;
                    //_ListChiTietTaisanCaBiet.ApplyEdit();
                    //_ListChiTietTaisanCaBiet.DataPortal_UpdateTranSacTion(tr);
                    //_ListDungCuPhuTung.ApplyEdit();
                    //_ListDungCuPhuTung._MaTSCDCaBiet = _MaTSCDCaBiet;
                    //_ListDungCuPhuTung.DataPortal_UpdateTranSacTion(tr);
                    // make sure we're marked as an old object
                    MarkOld();
                }
            }
        }

        private TSCDCaBiet(SafeDataReader dr)
        {
            try
            {
                MarkAsChild();
                _MaTSCDCaBiet = dr.GetInt32("MaTSCDCaBiet");
                _SoHieuCB = dr.GetString("SoHieu");
                _Serial = dr.GetString("Serial");
                _Barcode = dr.GetString("Barcode");
                _NamSanXuat = dr.GetInt32("NamSX");
                _NguyenGiaMua = dr.GetDecimal("NguyenGiaMua");
                _NguyenGiaConLai = dr.GetDecimal("NguyenGiaConLai");
                _NguyenGiaTinhKhauHao = dr.GetDecimal("NguyenGiaTinhKhauHao");
                _CongSuat = dr.GetString("CongSuat");

                _NgayNhan = dr.GetSmartDate("NgayNhan");
                _NgaySuDung = dr.GetSmartDate("NgaySuDung");                               
                
                _NgayHetHanBaoHanh = dr.GetSmartDate("NgayHetBaoHanHanh");
                _ThoiGianSuDung = dr.GetInt32("ThoiGianSuDung");
                
                _TyLeKhauHaoNam = dr.GetDecimal("KhauHaoNam");
                _ViTri = dr.GetString("ViTri");
                _MucDichSuDung = dr.GetBoolean("MucDichSuDung");
                _QuyetToan = dr.GetByte("QuyetToan");
                //_QuyetToan = dr.GetBoolean("QuyetToan");
                _BaoHiem = dr.GetBoolean("BaoHiem");
                _NgungSuDung = dr.GetBoolean("NgungSuDung");
                _ThanhLy = dr.GetBoolean("ThanhLy");
                _TaiSanCoDinh = TaiSanCoDinh.GetTaiSanCoDinh(dr.GetInt32("MaTSCD"));
                _maNhaCungCap = dr.GetInt64("MaNhaCungCap");
                _PhiVanChuyen = dr.GetDecimal("ChiPhiVanChuyen");                
                _PhiChayThu = dr.GetDecimal("ChiPhiChayThu");              
                _NguonMua = dr.GetBoolean("NguonMua");
                //_PhongBan = NghiepVuPhanBo.GetPhongBanCuaTSCDCaBiet(_MaTSCDCaBiet);
                _maPhongBan= dr.GetInt32("MaPhongBan");
                //_tenPhongBan = dr.GetString("TenPhongBan");
                //_tenPhongBan = BoPhan.GetBoPhan(_maPhongBan).TenBoPhan;
                _maNguon = dr.GetInt32("MaNguon");
                _tenPhongBan = dr.GetString("TenBoPhan");
                if (dr.GetString("TaiKhoanDoiUng") != null)
                {
                    _TaiKhoanDoiUng = dr.GetString("TaiKhoanDoiUng");
                }
                _idSet = true;
                MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static TSCDCaBiet TSCDCaBiet_TimKiem(SafeDataReader dr)
        {
            TSCDCaBiet _TSCDCaBiet = new TSCDCaBiet();
            try
            {
                _TSCDCaBiet.MarkAsChild();
                _TSCDCaBiet._SoHopDong = dr.GetString("SoHopDong");
                _TSCDCaBiet._TenHopDong = dr.GetString("TenHopDong");
                _TSCDCaBiet._NgayKyHopDong = dr.GetDateTime("NgayKyHopDong");
                _TSCDCaBiet._MaTSCDCaBiet = dr.GetInt32("MaTSCDCaBiet");
                _TSCDCaBiet._SoHieuCB = dr.GetString("SoHieu");
                _TSCDCaBiet._Serial = dr.GetString("Serial");
                _TSCDCaBiet._Barcode = dr.GetString("Barcode");
                _TSCDCaBiet._NamSanXuat = dr.GetInt32("NamSX");
                _TSCDCaBiet._NguyenGiaMua = dr.GetDecimal("NguyenGiaMua");
                _TSCDCaBiet._NguyenGiaConLai = dr.GetDecimal("NguyenGiaConLai");
                _TSCDCaBiet._NguyenGiaTinhKhauHao = dr.GetDecimal("NguyenGiaTinhKhauHao");
                _TSCDCaBiet._CongSuat = dr.GetString("CongSuat");

                _TSCDCaBiet._NgayNhan = dr.GetSmartDate("NgayNhan");
                _TSCDCaBiet._NgaySuDung = dr.GetSmartDate("NgaySuDung");

                _TSCDCaBiet._NgayHetHanBaoHanh = dr.GetSmartDate("NgayHetBaoHanHanh");
                _TSCDCaBiet._ThoiGianSuDung = dr.GetInt32("ThoiGianSuDung");

                _TSCDCaBiet._TyLeKhauHaoNam = dr.GetDecimal("KhauHaoNam");
                _TSCDCaBiet._ViTri = dr.GetString("ViTri");
                _TSCDCaBiet._MucDichSuDung = dr.GetBoolean("MucDichSuDung");
                _TSCDCaBiet._QuyetToan = dr.GetByte("QuyetToan");
                //_QuyetToan = dr.GetBoolean("QuyetToan");
                _TSCDCaBiet._BaoHiem = dr.GetBoolean("BaoHiem");
                _TSCDCaBiet._NgungSuDung = dr.GetBoolean("NgungSuDung");
                _TSCDCaBiet._ThanhLy = dr.GetBoolean("ThanhLy");
                _TSCDCaBiet._TaiSanCoDinh = TaiSanCoDinh.GetTaiSanCoDinh(dr.GetInt32("MaTSCD"));
                _TSCDCaBiet._maNhaCungCap = dr.GetInt64("MaNhaCungCap");
                _TSCDCaBiet._PhiVanChuyen = dr.GetDecimal("ChiPhiVanChuyen");
                _TSCDCaBiet._PhiChayThu = dr.GetDecimal("ChiPhiChayThu");
                _TSCDCaBiet._NguonMua = dr.GetBoolean("NguonMua");
                _TSCDCaBiet._maPhongBan = dr.GetInt32("MaPhongBan"); //NghiepVuPhanBo.GetPhongBanCuaTSCDCaBiet(_TSCDCaBiet._MaTSCDCaBiet);
                //_TSCDCaBiet._tenPhongBan = dr.GetString("TenPhongBan");
                //_TSCDCaBiet._tenPhongBan = BoPhan.GetBoPhan(_TSCDCaBiet._maPhongBan).TenBoPhan;
                _TSCDCaBiet._tenPhongBan = dr.GetString("TenBoPhan");
                _TSCDCaBiet._maNguon = dr.GetInt32("MaNguon");
                if (dr.GetString("TaiKhoanDoiUng") != null)
                {
                    _TSCDCaBiet._TaiKhoanDoiUng = dr.GetString("TaiKhoanDoiUng");
                }
                _TSCDCaBiet._idSet = true;
                _TSCDCaBiet.MarkOld();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _TSCDCaBiet;
        }

        public static TSCDCaBiet NewTSCDCaBiet()
        {
            return new TSCDCaBiet();
        }
        
        public static TSCDCaBiet NewTSCDCaBietChild()
        {
            TSCDCaBiet ts =  new TSCDCaBiet();
            ts.MarkAsChild();
            return ts;
        }

        public void ThuyenMarkOld()
        {
            this.MarkOld();
        }

        public static TSCDCaBiet NewTSCDCaBiet(string SoHieu,int maTSCDCaBiet)
        {
            TSCDCaBiet cb = new TSCDCaBiet();
            cb._SoHieuCB = SoHieu;
            cb._MaTSCDCaBiet = maTSCDCaBiet;
            return cb;
        }// Dung cho All

        public static TSCDCaBiet NewTSCDCaBiet(int maTSCDCaBiet)
        {
            TSCDCaBiet cb = new TSCDCaBiet();
            cb._MaTSCDCaBiet = maTSCDCaBiet;
            return cb;
        }

        public static TSCDCaBiet NewTSCDCaBiet(string soHieu, string serial, string barcode, int namSX, Decimal nguyenGiaMua, Decimal nguyenGiaConLai, string congSuat, SmartDate ngayNhan,
            SmartDate ngaySuDung,  SmartDate ngayHetHanBaoHanh, int thoiGianSuDung, Decimal khauHaoNam, string viTri, Boolean mucDichSuDung, byte quyetToan,
            Boolean baoHiem, Boolean ngungSuDung, Boolean thanhLy, int maTSCD,
            int maNhaCungCap, Boolean nguonMua, int maNguon, int maNghiepVuGhiTang, int maNghiepVuThanhLy, Decimal phiVanChuyen, Decimal phiChayThu, string soHieuTaiKhoan)
        {
            TSCDCaBiet cb = new TSCDCaBiet();            
            cb._SoHieuCB = soHieu;
            cb._Serial = serial;
            cb._Barcode = barcode;
            cb._NamSanXuat = namSX;
            cb._NguyenGiaMua = nguyenGiaMua;
            cb._NguyenGiaConLai = nguyenGiaConLai;
            cb._CongSuat = congSuat;
            cb._NgayNhan = ngayNhan;
            cb._NgaySuDung = ngaySuDung;
            
            
            cb._ThoiGianSuDung = thoiGianSuDung;            
            cb._TyLeKhauHaoNam = khauHaoNam;
            cb._ViTri = viTri;
            cb._MucDichSuDung = mucDichSuDung;
            cb._QuyetToan = quyetToan;
            cb._BaoHiem = baoHiem ;
            cb._NgungSuDung = ngungSuDung;
            cb._ThanhLy = thanhLy;
            cb._TaiSanCoDinh =TaiSanCoDinh.GetTaiSanCoDinh(maTSCD);
            cb._maNhaCungCap = maNhaCungCap;
            cb._NguonMua = nguonMua;
            cb._maNguon = maNguon;
            cb._PhiChayThu = phiChayThu;
            cb._PhiVanChuyen = phiVanChuyen;
           
            cb._TaiKhoanDoiUng = soHieuTaiKhoan;            
            cb.MarkAsChild();
            return cb;
        }


        public static TSCDCaBiet NewTSCDCaBiet(TSCDCaBiet _tscdCaBiet, ChiTietTaiSanCaBietList _chiTietTSCaBietList, DungCuPhuTungList _dungCuphuTungList)
        {
            TSCDCaBiet cb = new TSCDCaBiet();
            cb._SoHieuCB = _tscdCaBiet.SoHieuCB;
            cb._Serial = _tscdCaBiet.Serial;
            cb._Barcode = _tscdCaBiet.Barcode;
            cb._NamSanXuat =_tscdCaBiet.NamSanXuat;
            cb._NguyenGiaMua = _tscdCaBiet.NguyenGiaMua;
            cb._NguyenGiaConLai = _tscdCaBiet.NguyenGiaConLai;
            cb._CongSuat = _tscdCaBiet.CongSuat;
            cb._NgayNhan = new SmartDate(_tscdCaBiet.NgayNhan);
            cb._NgaySuDung = new SmartDate(_tscdCaBiet.NgaySuDung);
            cb._NgayHetHanBaoHanh = new SmartDate(_tscdCaBiet.NgayHetHanBaoHanh);// them thu (ban dau ko co)
            cb._ThoiGianSuDung = _tscdCaBiet.ThoiGianSuDung;
            cb._TyLeKhauHaoNam = _tscdCaBiet.TyLeKhauHaoNam;
            cb._ViTri = _tscdCaBiet.ViTri;
            cb._MucDichSuDung = _tscdCaBiet.MucDichSuDung;
            cb._QuyetToan = _tscdCaBiet.QuyetToan;
            cb._BaoHiem = _tscdCaBiet.BaoHiem;
            cb._NgungSuDung = _tscdCaBiet.NgungSuDung;
            cb._ThanhLy = _tscdCaBiet.ThanhLy;
            cb._TaiSanCoDinh = TaiSanCoDinh.GetTaiSanCoDinh(_tscdCaBiet.TaiSanCoDinh.MaTSCD);
            cb._maNhaCungCap = _tscdCaBiet.MaNhaCungCap;
            cb._NguonMua = _tscdCaBiet.NguonMua;
            cb._maNguon = _tscdCaBiet.MaNguon;
            cb._PhiChayThu = _tscdCaBiet.PhiChayThu;
            cb._PhiVanChuyen = _tscdCaBiet.PhiVanChuyen;

            cb._TaiKhoanDoiUng = _tscdCaBiet.TaiKhoanDoiUng;
            if (_chiTietTSCaBietList != null)
            {
                foreach (ChiTietTaiSanCaBiet chiTietTaiSanCaBiet in _chiTietTSCaBietList)
                {
                    cb._ListChiTietTaisanCaBiet.Add(ChiTietTaiSanCaBiet.NewChiTietTaiSanCaBiet(chiTietTaiSanCaBiet));
                }
            }
            if (_dungCuphuTungList!= null)
            {
                foreach (DungCuPhuTung dungCuPhuTung in _dungCuphuTungList)
                {
                    cb._ListDungCuPhuTung.Add(DungCuPhuTung.NewDungCuPhuTung(dungCuPhuTung));
                }
            }
            
            cb._maPhongBan = _tscdCaBiet.MaPhongBan;
            cb.MarkNew();
            cb.MarkAsChild();
            return cb;
        }

        public static TSCDCaBiet NewTSCDCaBietParent(string soHieu, string serial, 
            string barcode, int namSX, Decimal nguyenGiaMua, Decimal nguyenGiaConLai,
            string congSuat, SmartDate ngayNhan, SmartDate ngaySuDung,  SmartDate ngayHetHanBaoHanh,
            int thoiGianSuDung,  Decimal khauHaoNam, string viTri, 
            Boolean mucDichSuDung, byte quyetToan, Boolean baoHiem, Boolean ngungSuDung, 
            Boolean thanhLy, int maTSCD, int maNhaCungCap, Boolean nguonMua, int maNguon, 
            int maNghiepVuGhiTang, int maNghiepVuThanhLy, String soHieuTaiKhoan)
        {
            TSCDCaBiet cb = new TSCDCaBiet();
            cb._SoHieuCB = soHieu;
            cb._Serial = serial;
            cb._Barcode = barcode;
            cb._NamSanXuat = namSX;
            cb._NguyenGiaMua = nguyenGiaMua;
            cb._NguyenGiaConLai = nguyenGiaConLai;
            cb._CongSuat = congSuat;
            cb._NgayNhan = ngayNhan;
            cb._NgaySuDung = ngaySuDung;
            cb._NgayHetHanBaoHanh = ngayHetHanBaoHanh; // default ko co(them thu)
            cb._ThoiGianSuDung = thoiGianSuDung;
            
            cb._TyLeKhauHaoNam = khauHaoNam;
            cb._ViTri = viTri;
            cb._MucDichSuDung = mucDichSuDung;
            cb._QuyetToan = quyetToan;
            cb._BaoHiem= baoHiem;
            cb._NgungSuDung = ngungSuDung;
            cb._ThanhLy = thanhLy;
            cb._TaiSanCoDinh = TaiSanCoDinh.GetTaiSanCoDinh(maTSCD);
            cb._maNhaCungCap = maNhaCungCap;
            cb._NguonMua = nguonMua;
            cb._maNguon = maNguon;
           
            cb._TaiKhoanDoiUng = soHieuTaiKhoan;            
            return cb;
        }

        public int GetIdent_TSCDCaBiet()
        {
            int ident = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select IDent_Current('tblTaiSanCoDinhCaBiet')";                      
                    ident = Convert.ToInt32(cm.ExecuteScalar())+1;
                    _idSet = true;
                }
            }
            return ident;
        }

        public static String GetSoHieu_TSCDCaBiet(int MaTSCD)
        {
            string SoHieuTaiSan ="";
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_MaxSoHieuTaiSan";
                    cm.Parameters.AddWithValue("@MaTSCD", MaTSCD);
                    SqlParameter prmDoHieuTS = new SqlParameter("@SoHieuTaiSan",SqlDbType.VarChar,20);
                    prmDoHieuTS.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(prmDoHieuTS);                  
                    cm.ExecuteNonQuery();                                     
                    return prmDoHieuTS.SqlValue.ToString();
                }
            }
            return SoHieuTaiSan;
        }

        public static TSCDCaBiet GetTSCDCaBiet(int maTSCDCaBiet)
        {
            if (maTSCDCaBiet == 0)
            {
                return new TSCDCaBiet();
            }
            return (TSCDCaBiet)DataPortal.Fetch<TSCDCaBiet>(new Criteria(maTSCDCaBiet));
        }

        public static TSCDCaBiet GetTSCDCaBietBySoHieu(String soHieuTSCDCaBiet)
        {
            TSCDCaBiet tscdCaBiet = new TSCDCaBiet();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadTSCDCaBiet_SoHieu";
                        cm.Parameters.AddWithValue("@SoHieu", soHieuTSCDCaBiet.Trim());
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                tscdCaBiet._MaTSCDCaBiet = dr.GetInt32("MaTSCDCaBiet");
                                tscdCaBiet._SoHieuCB = dr.GetString("SoHieu");
                                tscdCaBiet._Serial = dr.GetString("Serial");
                                tscdCaBiet._Barcode = dr.GetString("Barcode");
                                tscdCaBiet._NamSanXuat = dr.GetInt32("NamSX");
                                tscdCaBiet._NguyenGiaMua = dr.GetDecimal("NguyenGiaMua");
                                tscdCaBiet._NguyenGiaConLai = dr.GetDecimal("NguyenGiaConLai");
                                tscdCaBiet._NguyenGiaTinhKhauHao = dr.GetDecimal("NguyenGiaTinhKhauHao");
                                tscdCaBiet._CongSuat = dr.GetString("CongSuat");
                                tscdCaBiet._NgayNhan = dr.GetSmartDate("NgayNhan");
                                tscdCaBiet._NgaySuDung = dr.GetSmartDate("NgaySuDung");
                                tscdCaBiet._NgayHetHanBaoHanh = dr.GetSmartDate("NgayHetBaoHanHanh");
                                tscdCaBiet._ThoiGianSuDung = dr.GetInt32("ThoiGianSuDung");

                                tscdCaBiet._TyLeKhauHaoNam = dr.GetDecimal("KhauHaoNam");
                                tscdCaBiet._ViTri = dr.GetString("ViTri");
                                tscdCaBiet._MucDichSuDung = dr.GetBoolean("MucDichSuDung");
                                tscdCaBiet._QuyetToan = dr.GetByte("QuyetToan");
                                tscdCaBiet._BaoHiem = dr.GetBoolean("BaoHiem");
                                tscdCaBiet._NgungSuDung = dr.GetBoolean("NgungSuDung");
                                tscdCaBiet._ThanhLy = dr.GetBoolean("ThanhLy");
                                tscdCaBiet._TaiSanCoDinh = TaiSanCoDinh.GetTaiSanCoDinh(dr.GetInt32("MaTSCD"));
                                tscdCaBiet._maNhaCungCap = dr.GetInt64("MaNhaCungCap");
                                tscdCaBiet._NguonMua = dr.GetBoolean("NguonMua");
                                tscdCaBiet._maPhongBan = dr.GetInt32("MaPhongBan");
                                //tscdCaBiet._tenPhongBan = dr.GetString("TenPhongBan");
                                tscdCaBiet._tenPhongBan = dr.GetString("TenBoPhan");
                                //tscdCaBiet._PhongBan = NghiepVuPhanBo.GetPhongBanCuaTSCDCaBiet(tscdCaBiet._MaTSCDCaBiet);
                                if (dr.GetDecimal("ChiPhiVanChuyen") != 0)
                                    tscdCaBiet._PhiVanChuyen = dr.GetDecimal("ChiPhiVanChuyen");
                                if (dr.GetDecimal("ChiPhiChayThu") != 0)
                                    tscdCaBiet._PhiChayThu = dr.GetDecimal("ChiPhiChayThu");
                                if (dr.GetInt32("MaNguon") != 0)
                                {
                                    tscdCaBiet._maNguon = dr.GetInt32("MaNguon");
                                }

                                if (dr.GetString("TaiKhoanDoiUng") != null)
                                {
                                    tscdCaBiet._TaiKhoanDoiUng = dr.GetString("TaiKhoanDoiUng");
                                }
                                tscdCaBiet._idSet = true;
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
            return tscdCaBiet;
            
        }
                
        public static int KiemTraSuTonTaiCuaTaiSan(String SoHieuTS)
        {
            int count = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                 try
                {
              
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select count(*) from tblTaiSanCoDinhCaBiet where SoHieu = '" + SoHieuTS+"'";
                        count = Convert.ToInt32(cm.ExecuteScalar());
                    }


                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }            
            
            return count;
        }

        public static int KiemTraTaiSanDaThanhLy(string SoHieu)
        {
            int count = 0;
            
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select count(*) from tblTaiSanCoDinhCaBiet where SoHieu = '" + SoHieu + "' and ThanhLy = 1";
                            count = (int)cm.ExecuteScalar();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            
            
            return count;
        }

        internal static TSCDCaBiet GetTSCDCaBiet(SafeDataReader dr)
        {
            return new TSCDCaBiet(dr);
        }

        internal static TSCDCaBiet GetTSCDCaBiet_TimKiem(SafeDataReader dr)
        {
            return TSCDCaBiet_TimKiem(dr);
        }

        public static void DeleteTSCDCaBiet(int maTSCDCaBiet)
        {
            DataPortal.Delete(new Criteria(maTSCDCaBiet));
        }

        #endregion

        #region Constructors

        public TSCDCaBiet()
        {
            // Prevent direct creation
            _MaTSCDCaBiet = 0;
            _idSet = false;
            _SoHieuCB = String.Empty;
            _Serial = String.Empty;
            _Barcode = String.Empty;
            _NamSanXuat = 0;
            _NguyenGiaMua = 0;
            _NguyenGiaConLai = 0;
            _CongSuat = String.Empty;
            _NgayNhan = new SmartDate(DateTime.Today);
            _NgaySuDung = new SmartDate(DateTime.Today);            
            _NgayHetHanBaoHanh = new SmartDate(DateTime.Today);
            _ThoiGianSuDung = 0;
            _TyLeKhauHaoNam = 0;
            _ViTri = String.Empty;
            _MucDichSuDung = true;
            _QuyetToan = 0;
            _BaoHiem= true;
            _NgungSuDung = false;
            _ThanhLy = false;
            _TaiSanCoDinh = TaiSanCoDinh.NewTaiSanCoDinh();
            _maNhaCungCap = 0;
            _NguonMua = true;
            _maNguon = 0;           
            _PhiChayThu = 0;
            _PhiVanChuyen = 0;
            _TaiKhoanDoiUng = string.Empty;
            _ListChiTietTaisanCaBiet = ChiTietTaiSanCaBietList.NewChiTietTaiSanCaBietList();
            _ListDungCuPhuTung = DungCuPhuTungList.NewDungCuPhuTungList();
           // MarkAsChild();
        }
        
        public static TSCDCaBiet NewTSCDCaBietChoKhauHao()
        {
            TSCDCaBiet tscdCaBiet = new TSCDCaBiet();
            tscdCaBiet._idSet = true;
            return tscdCaBiet;
            
        }
        #endregion

        #region Data Access

        #region load tất cả cả

        protected override void DataPortal_Fetch(object criteria)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        if (criteria is Criteria)
                        {
                            Criteria crit = (Criteria)criteria;
                            cm.CommandText = "spd_LoadMaCaBiet_TaiSanCoDinhCaBiet";
                            cm.Parameters.AddWithValue("@MaTSCDCaBiet", crit.MaTSCDCaBiet);
                        }
                        if (criteria is Criteria_SoHieuTS)
                        {
                            Criteria_SoHieuTS cri = (Criteria_SoHieuTS)criteria;
                            cm.CommandText = "spd_LoadTSCDCaBiet_SoHieu";// spd_Load_TaiSanCoDinhCaBiet_SoHieu
                            cm.Parameters.AddWithValue("@SoHieuTSCDCABIET", cri._SoHieuTSCDCaBiet);
                        }

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                _MaTSCDCaBiet = dr.GetInt32("MaTSCDCaBiet");
                                _SoHieuCB = dr.GetString("SoHieu");
                                _Serial = dr.GetString("Serial");
                                _Barcode = dr.GetString("Barcode");
                                _NamSanXuat = dr.GetInt32("NamSX");
                                _NguyenGiaMua = dr.GetDecimal("NguyenGiaMua");
                                _NguyenGiaConLai = dr.GetDecimal("NguyenGiaConLai");
                                _NguyenGiaTinhKhauHao = dr.GetDecimal("NguyenGiaTinhKhauHao");
                                _CongSuat = dr.GetString("CongSuat");
                                _NgayNhan = dr.GetSmartDate("NgayNhan");
                                _NgaySuDung = dr.GetSmartDate("NgaySuDung");

                                _NgayHetHanBaoHanh = dr.GetSmartDate("NgayHetBaoHanHanh");
                                _ThoiGianSuDung = dr.GetInt32("ThoiGianSuDung");

                                _TyLeKhauHaoNam = dr.GetDecimal("KhauHaoNam");
                                _ViTri = dr.GetString("ViTri");
                                _MucDichSuDung = dr.GetBoolean("MucDichSuDung");
                                _QuyetToan = dr.GetByte("QuyetToan");
                                _BaoHiem = dr.GetBoolean("BaoHiem");
                                _NgungSuDung = dr.GetBoolean("NgungSuDung");
                                _ThanhLy = dr.GetBoolean("ThanhLy");
                                _TaiSanCoDinh = TaiSanCoDinh.GetTaiSanCoDinh(dr.GetInt32("MaTSCD"));
                                _maNhaCungCap = dr.GetInt64("MaNhaCungCap");
                                _NguonMua = dr.GetBoolean("NguonMua");
                                //_PhongBan = NghiepVuPhanBo.GetPhongBanCuaTSCDCaBiet(_MaTSCDCaBiet);
                                _maPhongBan = dr.GetInt32("MaPhongBan");
                                _tenPhongBan = dr.GetString("TenBoPhan");
                                if (dr.GetDecimal("ChiPhiVanChuyen") != 0)
                                    _PhiVanChuyen = dr.GetDecimal("ChiPhiVanChuyen");
                                if (dr.GetDecimal("ChiPhiChayThu") != 0)
                                    _PhiChayThu = dr.GetDecimal("ChiPhiChayThu");
                                if (dr.GetInt32("MaNguon") != 0)
                                {
                                    _maNguon = dr.GetInt32("MaNguon");
                                }

                                if (dr.GetString("TaiKhoanDoiUng") != null)
                                {
                                    _TaiKhoanDoiUng = dr.GetString("TaiKhoanDoiUng");
                                }
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

        internal void InsertTranSacTion(SqlTransaction tr)
        {
            if (!IsDirty) return;
            try
            {
                ExecuteInsert(tr);
                MarkOld();

                //update child object(s)
               // UpdateChildren(tr);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void ExecuteInsert(SqlTransaction tr)
        {
            try
            {                
                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Insert_TaiSanCoDinhCaBiet";
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", _MaTSCDCaBiet);
                    cm.Parameters["@MaTSCDCaBiet"].Direction = ParameterDirection.Output;
                    cm.Parameters.AddWithValue("@SoHieu", _SoHieuCB);
                    if (_Serial == "")
                        cm.Parameters.AddWithValue("@Serial", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@Serial", _Serial);
                    if (_Barcode == "")
                        cm.Parameters.AddWithValue("@Barcode", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@Barcode", _Barcode);
                    if (_NamSanXuat == 0)
                        cm.Parameters.AddWithValue("@NamSX", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@NamSX", _NamSanXuat);
                    cm.Parameters.AddWithValue("@NguyenGiaMua", _NguyenGiaMua);
                    cm.Parameters.AddWithValue("@NguyenGiaConLai", _NguyenGiaConLai);
                    cm.Parameters.AddWithValue("CongSuat", _CongSuat);
                    cm.Parameters.AddWithValue("NgayNhan", _NgayNhan.DBValue);
                    cm.Parameters.AddWithValue("NgaySuDung", _NgaySuDung.DBValue);

                    cm.Parameters.AddWithValue("@NgayHetHanBaoHanh", _NgayHetHanBaoHanh.DBValue);
                    cm.Parameters.AddWithValue("ThoiGianSuDung", _ThoiGianSuDung);
                    cm.Parameters.AddWithValue("KhauHaoNam", _TyLeKhauHaoNam);
                    if (_ViTri == "")
                        cm.Parameters.AddWithValue("ViTri", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("ViTri", _ViTri);
                    cm.Parameters.AddWithValue("MucDichSuDung", _MucDichSuDung);
                    cm.Parameters.AddWithValue("@QuyetToan", _QuyetToan);
                    cm.Parameters.AddWithValue("@BaoHiem", _BaoHiem);
                    cm.Parameters.AddWithValue("NgungSuDung", _NgungSuDung);
                    cm.Parameters.AddWithValue("@ThanhLy", _ThanhLy);
                    cm.Parameters.AddWithValue("@MaTSCD", _TaiSanCoDinh.MaTSCD);
                    cm.Parameters.AddWithValue("@MaNhaCungCap", _maNhaCungCap);
                    cm.Parameters.AddWithValue("@NguonMua", _NguonMua);
                    cm.Parameters.AddWithValue("@ChiPhiVanChuyen", _PhiVanChuyen);
                    cm.Parameters.AddWithValue("@ChiPhiChayThu", _PhiChayThu);
                    if (_maNguon == 0)
                        cm.Parameters.AddWithValue("@MaNguon ", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@MaNguon ", _maNguon);
                    if (_TaiKhoanDoiUng == String.Empty)
                        cm.Parameters.AddWithValue("@TaiKhoanDoiUng", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@TaiKhoanDoiUng", _TaiKhoanDoiUng);
                    if (_maPhongBan == 0)
                        cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
                    else
                        cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);

                    // Phải xem lại                      

                    cm.ExecuteNonQuery();
                    _MaTSCDCaBiet = (Int32)cm.Parameters["@MaTSCDCaBiet"].Value;                    
                    _ListChiTietTaisanCaBiet._MaTSCDCaBiet = _MaTSCDCaBiet;
                    _ListChiTietTaisanCaBiet.ApplyEdit();
                    _ListChiTietTaisanCaBiet.DataPortal_UpdateTranSacTion(tr);                    
                    _ListDungCuPhuTung.ApplyEdit();
                    _ListDungCuPhuTung._MaTSCDCaBiet = _MaTSCDCaBiet;
                    _ListDungCuPhuTung.DataPortal_UpdateTranSacTion(tr);
                    _idSet = true;
                    //tr.Commit();
                }
                MarkOld();
            }
            catch (Exception ex)
            {
                //tr.Rollback();
                throw ex;
            }
            
        }

        protected void DataPortal_Update(SqlTransaction tr)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                // we're not new, so update
                cm.CommandText = "spd_Update_TaiSanCoDinhCaBiet";
                cm.Parameters.AddWithValue("@MaTSCDCaBiet", _MaTSCDCaBiet);
                cm.Parameters.AddWithValue("@SoHieu", _SoHieuCB);
                if (_Serial == "")
                    cm.Parameters.AddWithValue("@Serial", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@Serial", _Serial);
                if (_Barcode == "")
                    cm.Parameters.AddWithValue("@Barcode", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@Barcode", _Barcode);
                if (_NamSanXuat == 0)
                    cm.Parameters.AddWithValue("@NamSX", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@NamSX", _NamSanXuat);
                cm.Parameters.AddWithValue("@NguyenGiaMua", _NguyenGiaMua);
                cm.Parameters.AddWithValue("@NguyenGiaConLai", _NguyenGiaConLai);
                cm.Parameters.AddWithValue("CongSuat", _CongSuat);
                cm.Parameters.AddWithValue("NgayNhan", _NgayNhan.DBValue);
                cm.Parameters.AddWithValue("NgaySuDung", _NgaySuDung.DBValue);
                cm.Parameters.AddWithValue("@NgayHetHanBaoHanh", _NgayHetHanBaoHanh.DBValue);
                cm.Parameters.AddWithValue("ThoiGianSuDung", _ThoiGianSuDung);
                cm.Parameters.AddWithValue("KhauHaoNam", _TyLeKhauHaoNam);
                if (_ViTri == "")
                    cm.Parameters.AddWithValue("ViTri", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("ViTri", _ViTri);
                cm.Parameters.AddWithValue("MucDichSuDung", _MucDichSuDung);
                cm.Parameters.AddWithValue("@QuyetToan", _QuyetToan);
                cm.Parameters.AddWithValue("@BaoHiem", _BaoHiem);
                cm.Parameters.AddWithValue("NgungSuDung", _NgungSuDung);
                cm.Parameters.AddWithValue("@ThanhLy", _ThanhLy);
                cm.Parameters.AddWithValue("@MaTSCD", _TaiSanCoDinh.MaTSCD);
                cm.Parameters.AddWithValue("@MaNhaCungCap", _maNhaCungCap);
                cm.Parameters.AddWithValue("@NguonMua", _NguonMua);
                cm.Parameters.AddWithValue("@ChiPhiVanChuyen", _PhiVanChuyen);
                cm.Parameters.AddWithValue("@ChiPhiChayThu", _PhiChayThu);

                if (_maNguon == 0)
                    cm.Parameters.AddWithValue("@MaNguon ", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@MaNguon ", _maNguon);
                if (_TaiKhoanDoiUng == String.Empty)
                    cm.Parameters.AddWithValue("@TaiKhoanDoiUng", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@TaiKhoanDoiUng", _TaiKhoanDoiUng);
                if (_maPhongBan == 0)
                    cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
                else
                    cm.Parameters.AddWithValue("@MaPhongBan", _maPhongBan);
                cm.ExecuteNonQuery();                
                
                //_ListChiTietTaisanCaBiet._MaTSCDCaBiet = _MaTSCDCaBiet;
                //_ListChiTietTaisanCaBiet.ApplyEdit();
                //_ListChiTietTaisanCaBiet.DataPortal_UpdateTranSacTion(tr);
                //_ListDungCuPhuTung.ApplyEdit();
                //_ListDungCuPhuTung._MaTSCDCaBiet = _MaTSCDCaBiet;
                //_ListDungCuPhuTung.DataPortal_UpdateTranSacTion(tr);
                // make sure we're marked as an old object
                MarkOld();
            }
        }
         
        public static void DataPortal_Update_SuaChuaLon(SqlTransaction tr, int maTaiSanCaBiet, decimal nguyenGiaConLai, decimal nguyenGiaTinhKhauHao)
        {
            try
            {
                // save data into db

                using (SqlCommand cm = tr.Connection.CreateCommand())
                {
                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    // we're not new, so update
                    cm.CommandText = "spd_Update_TSCDCaBiet_NghiepVuSuaChuaLon";
                    cm.Parameters.AddWithValue("@MaTSCDCaBiet", maTaiSanCaBiet);
                    cm.Parameters.AddWithValue("@NguyenGiaConLai", nguyenGiaConLai);
                    cm.Parameters.AddWithValue("@NguyenGiaTinhKhauHao", nguyenGiaTinhKhauHao);
                    cm.ExecuteNonQuery();
                    // make sure we're marked as an old object
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Delete

        protected override void DataPortal_Delete(object criteria)
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
                        cm.CommandText = "spd_Delete_TaiSanCoDinhCaBiet";
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", _MaTSCDCaBiet);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new Criteria(_MaTSCDCaBiet));
        }

        #endregion

        #region Chứng Từ
        public static void Update_HoanTatChungTu(long maChungTu)
        {
            try
            {
                // save data into db
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Update_HoanTatChungTu";
                        cm.Parameters.AddWithValue("@maChungTu", maChungTu);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        #endregion

        #endregion

        #endregion

        #region Update Nghiệp Vụ Thanh Lý
        public static void Update_TSCDCaBietThanhLy(int maTSCDCaBiet, int maNghiepVuThanhLy)
        {

            try
            {
                // save data into db
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_UpdateTaiSanCoDinhThanhLy";
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", maTSCDCaBiet);
                        cm.Parameters.AddWithValue("@MaNghiepVuThanhLy", maNghiepVuThanhLy);                        
                        cm.ExecuteNonQuery();                                               
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      
    
        #endregion

        #region Insert Danh Sach TSCDCB cho Nghiệp Vụ Thanh Lý Giống Thái Bình

        #region Đã duyệt
        public static void Insert_TSCDCaBietThanhLy(bool daDuyet, int maTSCDCaBiet, int loaiPhanBiet, bool thanhLy, int loaiNghiepVu, DateTime ngayDuyet)
        {
            try
            {
                // save data into db
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Insert_TaiSanDuocDuyet";
                        cm.Parameters.AddWithValue("@MaDuocDuyet", 0);
                        cm.Parameters["@MaDuocDuyet"].Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@DuocDuyet", daDuyet);
                        cm.Parameters.AddWithValue("@MaTSCDCaBIet", maTSCDCaBiet);
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", loaiPhanBiet);// LoaiPhanBiet: 0: ThanhLy; 1: DieuChuyen Ngoai; 2: DieuChuyen Noi Bo 
                        cm.Parameters.AddWithValue("@ThanhLy", thanhLy);
                        cm.Parameters.AddWithValue("@LoaiNghiepVu", loaiNghiepVu);//loaiNghiepVu:{ 0: ThanhLy; 1: DieuChuyenNgoai; 2: DanhGiaLai; 3: SuaChuaLon; 4: DieuChuyenNoiBo }
                        cm.Parameters.AddWithValue("@NgayDuyet", ngayDuyet);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Insert_TSCDCaBietSuaChuaLon(bool daDuyet, int maTSCDCaBiet, bool loaiPhanBiet, int loaiNghiepVu, DateTime ngayDuyet)
        {
            try
            {
                // save data into db
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Insert_TaiSanDuocDuyet_SuaChuaLon";
                        cm.Parameters.AddWithValue("@MaDuocDuyet", 0);
                        cm.Parameters["@MaDuocDuyet"].Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@DuocDuyet", daDuyet);
                        cm.Parameters.AddWithValue("@MaTSCDCaBIet", maTSCDCaBiet);
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", loaiPhanBiet);
                        cm.Parameters.AddWithValue("@LoaiNghiepVu", loaiNghiepVu);
                        cm.Parameters.AddWithValue("@NgayDuyet", ngayDuyet);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Insert_TSCDCaBietDieuChuyenNoiBo(int maTSCDCaBiet, bool daDieuChuyen, bool thanhLy, int loaiNghiepVu, DateTime ngayDuyet)
        {
            try
            {
                // save data into db
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Insert_TaiSanDieuChuyenNoiBo";
                        cm.Parameters.AddWithValue("@MaDieuChuyen", 0);
                        cm.Parameters["@MaDieuChuyen"].Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@MaTSCDCaBIet", maTSCDCaBiet);
                        cm.Parameters.AddWithValue("@DaDieuChuyen", daDieuChuyen);
                        cm.Parameters.AddWithValue("@ThanhLy", thanhLy);
                        cm.Parameters.AddWithValue("@LoaiNghiepVu", loaiNghiepVu);
                        cm.Parameters.AddWithValue("@NgayDuyet", ngayDuyet);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Lập DS Tài Sản đem đi duyệt

        /// <summary>
        /// LoaiPhanBiet: 0: ThanhLy; 1: DieuChuyenNgoai; 2: DanhGiaLai; 3: SuaChuaLon; 4: DieuChuyenNoiBo
        /// </summary>
        /// <param name="choDuyet"></param>
        /// <param name="maTSCDCaBiet"></param>
        /// <param name="loaiPhanBiet"></param>
        public static void Insert_TSCDCaBietChoDuyet(bool choDuyet, int maTSCDCaBiet, int loaiPhanBiet, DateTime ngayLap)//, int loaiNghiepVu)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                SqlTransaction tr;
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    // save data into db
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        // we're not new, so update
                        cm.CommandText = "spd_Insert_TaiSanChoDuyet";
                        cm.Parameters.AddWithValue("@MaChoDuyet", 0);
                        cm.Parameters["@MaChoDuyet"].Direction = ParameterDirection.Output;
                        cm.Parameters.AddWithValue("@ChoDuyet", choDuyet);
                        cm.Parameters.AddWithValue("@MaTSCDCaBIet", maTSCDCaBiet);
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", loaiPhanBiet);
                        cm.Parameters.AddWithValue("@NgayLapDS", ngayLap);
                        //cm.Parameters.AddWithValue("@LoaiNghiepVu", loaiNghiepVu);
                        cm.ExecuteNonQuery();
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
    #region Type Converter

    public class TSCDCaBietTypeConverter : TypeConverter
    {

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            int giatri = Convert.ToInt32(value);
            return TSCDCaBiet.GetTSCDCaBiet((int)giatri);
        }
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return ((TSCDCaBiet)value).MaTSCDCaBiet;

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
            else if (destinationType == typeof(Object))
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
