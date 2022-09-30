using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using System.Transactions;


namespace ERP_Library
{
    public class TaiSanCoDinhCaBietList:BusinessListBase<TaiSanCoDinhCaBietList,TSCDCaBiet>
    {        
        #region Business Methods

        // TODO: add public properties and methods

        public TSCDCaBiet GetTSCDCaBiet(int maTSCDCaBiet)
        {
            foreach (TSCDCaBiet cb in this)
                if (cb.MaTSCDCaBiet == maTSCDCaBiet)
                    return cb;
            return null;
        }

        public void Remove(int maTSCDCaBiet)
        {
            foreach (TSCDCaBiet item in this)
            {
                if (item.MaTSCDCaBiet == maTSCDCaBiet)
                {
                    Remove(item);
                    break;
                }
            }
        }
        protected override void RemoveItem(int index)
        {
               base.RemoveItem(index);
        }
        protected override object AddNewCore()
        {
            TSCDCaBiet item = TSCDCaBiet.NewTSCDCaBiet();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods        

        public static TaiSanCoDinhCaBietList NewTSCDCaBietList()
        {
            return new TaiSanCoDinhCaBietList();
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietList( )
        {
          return DataPortal.Fetch<TaiSanCoDinhCaBietList>(new Criteria());
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietByTSCDList(int MaTSCD)
        {
            return DataPortal.Fetch<TaiSanCoDinhCaBietList>(new CriteriaTaiSanCoDinhCBByTSCD(MaTSCD));
        }
        public static TaiSanCoDinhCaBietList GetTimTSCDCaBietNotInBarCoder(int maTaiSanCoDinh, int maLoaiTaiSan, int maNhomTaiSan)
        {
            return DataPortal.Fetch<TaiSanCoDinhCaBietList>(new CriteriaTSCDCaBietNoInInBarcoder(maTaiSanCoDinh, maLoaiTaiSan, maNhomTaiSan));
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietByTSCDDanhGiaLai()
        {
            return DataPortal.Fetch<TaiSanCoDinhCaBietList>(  new CriteriaByDanhGiaLai());
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietByTSCDSuaChuaLon()
        {
            return DataPortal.Fetch<TaiSanCoDinhCaBietList>(new CriteriaBySuaChuaLon());
        }
        public static TaiSanCoDinhCaBietList GetTSCDCaBietByMaNVDieuChuyen(int MaNghiepVuDieuChuyen)
        {
            return DataPortal.Fetch<TaiSanCoDinhCaBietList>(new CriteriaTaiSanCoDinhCBByMaDieuChuyen(MaNghiepVuDieuChuyen));
        }

        public TaiSanCoDinhCaBietList()
        {
            this.AllowNew = true;            
        }

       

        public static TaiSanCoDinhCaBietList GetTimTSCDCaBiet(int maNguon, int maNhomTaiSan, int maLoaiTaiSan, int maPhongBan, int maTSCD)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimTaiSanCoDinhCaBiet";
                        if (maNguon == 0)
                            cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaNguon", maNguon);
                        if (maLoaiTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaLoaiTS", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaLoaiTS", maLoaiTaiSan);
                        if (maNhomTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaNhomTS", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaNhomTS", maNhomTaiSan);
                        if (maTSCD == 0)
                            cm.Parameters.AddWithValue("@MaTSCD", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaTSCD", maTSCD);
                        if (maPhongBan == 0)
                            cm.Parameters.AddWithValue("@MaPBSD", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaPBSD", maPhongBan);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetTimTSCDCaBiet_ChuoiTimKiem(string chuoiTimKiem)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        //cm.CommandText = "spd_TimTaiSanCoDinhCaBiet_ChuoiTimKiem";
                        //cm.Parameters.AddWithValue("@ChuoiTimKiem", chuoiTimKiem);
                        cm.CommandText = "spd_TimTaiSanCoDinhCaBiet_ChuoiTimKiem_Test";
                        cm.Parameters.AddWithValue("@ChuoiTimKiem", chuoiTimKiem);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet_TimKiem(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetTimTSCDCaBietNgungSuDung_TaiSuDung(int maNguon, int maNhomTaiSan, int maLoaiTaiSan, int maPhongBan, int maTSCD, int ngungSuDung)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimTaiSanCoDinhCaBietNgungSuDung_TaiSuDung";
                        if (maNguon == 0)
                            cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaNguon", maNguon);
                        if (maLoaiTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaLoaiTS", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaLoaiTS", maLoaiTaiSan);
                        if (maNhomTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaNhomTS", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaNhomTS", maNhomTaiSan);
                        if (maTSCD == 0)
                            cm.Parameters.AddWithValue("@MaTSCD", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaTSCD", maTSCD);
                        if (maPhongBan == 0)
                            cm.Parameters.AddWithValue("@MaPBSD", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaPBSD", maPhongBan);
                        
                        cm.Parameters.AddWithValue("@NgungSuDung", ngungSuDung);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietList_TimTongQuat(int maNguon, int maNhomTaiSan, int maLoaiTaiSan, int maPhongBan, int maTSCD, int ngungSuDung,string ChuoiTimKiem,DateTime TuNgay,DateTime DenNgay)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimTaiSanCoDinhCaBiet_TongQuat";
                        if (maNguon == 0)
                            cm.Parameters.AddWithValue("@MaNguon", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaNguon", maNguon);
                        if (maLoaiTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaLoaiTS", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaLoaiTS", maLoaiTaiSan);
                        if (maNhomTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaNhomTS", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaNhomTS", maNhomTaiSan);
                        if (maTSCD == 0)
                            cm.Parameters.AddWithValue("@MaTSCD", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaTSCD", maTSCD);
                        if (maPhongBan == 0)
                            cm.Parameters.AddWithValue("@MaPBSD", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaPBSD", maPhongBan);
                        cm.Parameters.AddWithValue("@NgungSuDung", ngungSuDung);
                        if (ChuoiTimKiem.Length == 0)
                            cm.Parameters.AddWithValue("@ChuoiTimKiem", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@ChuoiTimKiem", ChuoiTimKiem);
                        if (TuNgay.Date.ToShortDateString() == "1/1/0001")
                            cm.Parameters.AddWithValue("@TuNgay", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@TuNgay", TuNgay);
                        if (DenNgay.Date.ToShortDateString() == "1/1/0001")
                            cm.Parameters.AddWithValue("@DenNgay", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@DenNgay", DenNgay);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet_TimKiem(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }
        
        public static TaiSanCoDinhCaBietList GetDanhSachTSCDCaBietChoDuyet(int loaiNghiepVu)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DanhSachTSCDCaBietChoDuyet";
                        if (loaiNghiepVu < 0)
                            cm.Parameters.AddWithValue("@LoaiNghiepVu", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@LoaiNghiepVu", loaiNghiepVu);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetDanhSachTSCDThanhLy_DieuChuyenNgoai(int maNhomTaiSan, int maLoaiTaiSan, int maPhongBan, int maTSCD, int thanhLy)
        {
            TaiSanCoDinhCaBietList listTSCDCaBiet;
            listTSCDCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimTSCDCaBietThanhLy_DieuChuyen";
                        if (maLoaiTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaLoaiTaiSan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaLoaiTaiSan", maLoaiTaiSan);
                        if (maNhomTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", maNhomTaiSan);
                        if (maTSCD == 0)
                            cm.Parameters.AddWithValue("@MaTaiSan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaTaiSan", maTSCD);
                        if (maPhongBan == 0)
                            cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                        if (thanhLy == 1)
                            cm.Parameters.AddWithValue("@ThanhLy", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@ThanhLy", thanhLy);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTSCDCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTSCDCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetDanhSachTSCDChoDuyet(int maNhomTaiSan, int maLoaiTaiSan, int maPhongBan, int maTSCD, int loaiNghiepVu)
        {
            TaiSanCoDinhCaBietList listTSCDCaBiet;
            listTSCDCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimTSCDCaBiet_ChoDuyet";
                        if (maLoaiTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaLoaiTaiSan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaLoaiTaiSan", maLoaiTaiSan);
                        if (maNhomTaiSan == 0)
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaNhomTaiSan", maNhomTaiSan);
                        if (maTSCD == 0)
                            cm.Parameters.AddWithValue("@MaTaiSan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaTaiSan", maTSCD);
                        if (maPhongBan == 0)
                            cm.Parameters.AddWithValue("@MaPhongBan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                        if (loaiNghiepVu == -1) // Lay tat ca
                            cm.Parameters.AddWithValue("@LoaiNghiepVu", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@LoaiNghiepVu", loaiNghiepVu);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTSCDCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTSCDCaBiet;
        }
        
        public static TaiSanCoDinhCaBietList GetTSCDCaBietTheoPhieuXuat(int maNghiepVuThanhLy)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadTSCDCaBietTheoNghiepVuThanhLyCT";
                        cm.Parameters.AddWithValue("@MaNghiepVuThanhLy", maNghiepVuThanhLy);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietCanThanhLy0_DieuChuyen1(int loaiPhanBiet)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadTSCDCaBietTheoNghiepVuThanhLy";
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", loaiPhanBiet);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return listTaiSanCoDinhCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietCanDieuChuyenTheoPhongBan(int loaiPhanBiet, int maPhongBan)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadTSCDCaBietDieuChuyenNoiBoTheoPhongBan";
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", loaiPhanBiet);
                        cm.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietCanSuaChuaLon1_DanhGiaLai0(int loaiPhanBiet)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadTSCDCaBietTheoNghiepVuSuaChuaLon_DanhGiaLai";
                        cm.Parameters.AddWithValue("@LoaiPhanBiet", loaiPhanBiet);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietDaThanhLy()
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select tscb.*,bp.TenBoPhan from tblTaiSanCoDinhCaBiet tscb INNER JOIN  tblnsBoPhan bp on tscb.MaPhongBan=bp.MaBoPhan where tscb.ThanhLy = 1";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }

        public static TaiSanCoDinhCaBietList GetTSCDCaBietTheoPhieuNhap(int maPhieuNhap)
        {
            TaiSanCoDinhCaBietList listTaiSanCoDinhCaBiet;
            listTaiSanCoDinhCaBiet = new TaiSanCoDinhCaBietList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LoadTSCDCaBietTheoPhieuNhap";
                        cm.Parameters.AddWithValue("@MaPhieu", maPhieuNhap);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTaiSanCoDinhCaBiet.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return listTaiSanCoDinhCaBiet;
        }

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            //hong lm g� h�t
        }

        private class CriteriaByDanhGiaLai
        {
            //hong l�m g� h�t
        }

        private class CriteriaBySuaChuaLon
        {
            //hong l�m g� h�t
        }

        [Serializable()]
        private class CriteriaTaiSanCoDinhCBByTSCD
        {
            private int _MaTSCD;
            public int MaTSCD
            {
                get { return _MaTSCD; }  
              
            }

            public CriteriaTaiSanCoDinhCBByTSCD(int MaTSCD)
            {
                _MaTSCD = MaTSCD;
            }
            //hong l�m g� h�t
        }

        private class CriteriaTaiSanCoDinhCBByMaDieuChuyen
        {
            private int _MaDieuChuyen;
            public int MaDieuChuyen
            {
                get { return _MaDieuChuyen; }

            }

            public CriteriaTaiSanCoDinhCBByMaDieuChuyen(int maDieuChuyen)
            {
                _MaDieuChuyen = maDieuChuyen;
            }
            //hong l�m g� h�t
        }

        private class CriteriaTSCDCaBietNoInInBarcoder
        {
            public int  MaTaiSanCoDinh;
            public int MaLoaiTaiSan;
            public int MaNhomTaiSan; 

            public CriteriaTSCDCaBietNoInInBarcoder(int maTaiSanCoDinh, int maLoaiTaiSan, int maNhomTaiSan)
            {
                this.MaTaiSanCoDinh = maTaiSanCoDinh;
                this.MaLoaiTaiSan = maLoaiTaiSan;
                this.MaNhomTaiSan = maNhomTaiSan;
            }
            //hong l�m g� h�t
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            if (criteria is Criteria)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select tscb.*,bp.[TenBoPhan] from tblTaiSanCoDinhCaBiet tscb INNER JOIN [tblnsBoPhan] bp ON tscb.[MaPhongBan]=bp.[MaBoPhan]";

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else if (criteria is CriteriaTaiSanCoDinhCBByTSCD)

            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select tscb.*,bp.[TenBoPhan] from tblTaiSanCoDinhCaBiet tscb INNER JOIN [tblnsBoPhan] bp ON tscb.[MaPhongBan]=bp.[MaBoPhan] where MaTSCD =" + ((CriteriaTaiSanCoDinhCBByTSCD)criteria).MaTSCD;

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            else if (criteria is CriteriaByDanhGiaLai)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_DanhSachTaiSanYeuCauDanhGiaLai";

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            else if (criteria is CriteriaBySuaChuaLon)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_DanhSachTaiSanYeuCauSuaChuaLon";

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            else if (criteria is CriteriaTaiSanCoDinhCBByMaDieuChuyen)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LoadDanhSachTSCDCaBietByMaDieuChuyen";
                            cm.Parameters.AddWithValue("@MaDieuChuyen", ((CriteriaTaiSanCoDinhCBByMaDieuChuyen)criteria).MaDieuChuyen);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else if (criteria is CriteriaTSCDCaBietNoInInBarcoder)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_SelecAllTSCDCaBietNotInInBarcoder";
                            if(((CriteriaTSCDCaBietNoInInBarcoder)criteria).MaTaiSanCoDinh == 0)
                                cm.Parameters.AddWithValue("@MaTSCD", DBNull.Value);
                            else cm.Parameters.AddWithValue("@MaTSCD", ((CriteriaTSCDCaBietNoInInBarcoder)criteria).MaTaiSanCoDinh);
                            if (((CriteriaTSCDCaBietNoInInBarcoder)criteria).MaLoaiTaiSan == 0)
                                cm.Parameters.AddWithValue("@MaLoaiTS", DBNull.Value);
                            else cm.Parameters.AddWithValue("@MaLoaiTS", ((CriteriaTSCDCaBietNoInInBarcoder)criteria).MaLoaiTaiSan);
                            if (((CriteriaTSCDCaBietNoInInBarcoder)criteria).MaNhomTaiSan == 0)
                                cm.Parameters.AddWithValue("@MaNhomTS", DBNull.Value);
                            else cm.Parameters.AddWithValue("@MaNhomTS", ((CriteriaTSCDCaBietNoInInBarcoder)criteria).MaNhomTaiSan);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(TSCDCaBiet.GetTSCDCaBiet(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            this.RaiseListChangedEvents = true;
            
        }

        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                
                cn.Open();
                tr = cn.BeginTransaction();
                // update (thus deleting) any deleted child objects
                try
                {
                    foreach (TSCDCaBiet obj in DeletedList)
                        obj.DeleteSelf();
                    // now that they are deleted, remove them from memory too
                    DeletedList.Clear();
                    // add/update any current child objects
                    foreach (TSCDCaBiet obj in this)
                    {
                        if (obj.IsDirty)
                        {
                            if (obj.IsNew)
                                obj.Insert(tr);
                            else
                                obj.Update(tr);
                        }
                    }
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
            this.RaiseListChangedEvents = true;
        }

        public void DataPortal_UpdateTranSacTion(SqlTransaction tr)
        {
            this.RaiseListChangedEvents = false;
            foreach (TSCDCaBiet obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (TSCDCaBiet obj in this)
            {
                if (obj.IsDirty)
                {
                    if (obj.IsNew)
                        obj.Insert(tr);
                    else
                        obj.Update(tr);
                }
            }
            this.RaiseListChangedEvents = true;
        }

        #region xóa tài sản chờ duyệt

        public void DeleteTaiSanCDCB_ChoDuyet(int MaTSCDCaBiet)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_Delete_TaiSanCoDinhCaBiet_ChoDuyet";
                        cm.Parameters.AddWithValue("@MaTSCDCaBiet", MaTSCDCaBiet);
                        cm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void DeleteSelf_ChoDuyet()
        //{
        //    DeleteTaiSanCDCB_ChoDuyet(new Criteria(_MaTSCDCaBiet));
        //}

        #endregion

        #endregion
    }
}
