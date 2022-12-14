
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Csla;
using Csla.Data;


namespace ERP_Library
{
    public class ChungTuList : BusinessListBase<ChungTuList, ChungTu>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public ChungTu GetChungTu(int maChungTu)
        {
            foreach (ChungTu ct in this)
                if (ct.MaChungTu == maChungTu)
                    return ct;
            return null;
        }

        public void Remove(int maChungTu)
        {
            foreach (ChungTu item in this)
            {
                if (item.MaChungTu == maChungTu)
                {
                    Remove(item);
                    break;
                }
            }
        }
        protected override object AddNewCore()
        {
            ChungTu item = ChungTu.NewChungTu();
            Add(item);
            return item;
        }
        #endregion

        private ChungTuList()
        {
            //MarkAsChild();
        }
        public static ChungTuList GetChungTuListAll()
        {
            return DataPortal.Fetch<ChungTuList>(new CriteriaAll());
        }

        private ChungTuList(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            while (dr.Read())
                this.Add(ChungTu.GetChungTu(dr));
            RaiseListChangedEvents = true;
        }

        #region Factory Methods

        public static ChungTuList NewChungTuList()
        {
            ChungTuList ct = new ChungTuList();
            return ct;
        }

        public static ChungTuList GetChungTuList()
        {
            return DataPortal.Fetch<ChungTuList>(new Criteria());
        }
        /// <summary>
        /// Lấy các loại chứng từ: Phiếu Chi, Phiếu Thu, Chứng Từ Khác
        /// </summary>
        /// <returns></returns>
        public static ChungTuList GetChungTuList_ByTamUng()
        {
            return DataPortal.Fetch<ChungTuList>(new CriteriaByTamUng());
        }

        public static ChungTuList GetChungTuListByQuanTri(DateTime tuNgay, DateTime denNgay, string  soHieuTK, int maBoPhan)
        {
            return DataPortal.Fetch<ChungTuList>(new CriteriaFilerByQuanTri(tuNgay, denNgay, soHieuTK, maBoPhan));
        }
        public static ChungTuList GetChungTuListTheoNgay(DateTime tuNgay, DateTime denNgay, Int32 maLoaiChungTu)
        {
            return DataPortal.Fetch<ChungTuList>(new CriteriaFilerChungTuByNgay(tuNgay, denNgay, maLoaiChungTu));
        }

        public static ChungTuList GetChungTuList(SafeDataReader dr)
        {
            return new ChungTuList(dr);
        }

        public static ChungTuList GetChungTuListByFind(DateTime tuNgay, DateTime denNgay, int maLoaiCt, String maDoiTac)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimChungTu";

                        cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay);
                        if (maLoaiCt == 0)
                            cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiCt);
                        if (maDoiTac == null)
                            cm.Parameters.AddWithValue("@MaKhachHang", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaKhachHang", maDoiTac);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTu(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        public static ChungTuList GetChungTuListByLoaiChungTu(DateTime tuNgay, DateTime denNgay, int maLoaiCt, String maDoiTac, int loaiChungTu)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimChungTu_LoaiChungTu";

                        cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", denNgay);
                        cm.Parameters.AddWithValue("@LoaiChungTu", loaiChungTu);
                        if (maLoaiCt == 0)
                            cm.Parameters.AddWithValue("@MaLoaiChungTu", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaLoaiChungTu", maLoaiCt);
                        if (maDoiTac == null)
                            cm.Parameters.AddWithValue("@MaKhachHang", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaKhachHang", maDoiTac);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTu(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }
        public static ChungTuList GetChungTuListByLoaiChungTu(int loaiChungTu)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "SelectChungTuByLoai";

                        cm.Parameters.AddWithValue("@MaLoaiChungTu", loaiChungTu);
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                        
                       
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTuByLoaiChungTu(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        public static ChungTuList TimChungTuListThoaDieuKien(DateTime tuNgay, DateTime denNgay, String maKhachHang, Decimal soTienNhoHon, Decimal soTienLonHon, String noTaiKhoan, String coTaiKhoan)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimChungTuThoaDieuKienLLLLL";

                        SmartDate temp_tuNgay = new SmartDate(tuNgay);
                        SmartDate temp_denNgay = new SmartDate(denNgay);

                        cm.Parameters.AddWithValue("@TuNgay", temp_tuNgay.DBValue);
                        cm.Parameters.AddWithValue("@DenNgay", temp_denNgay.DBValue);
                        if (maKhachHang == null)
                            cm.Parameters.AddWithValue("@MaKhachHang", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                        if (soTienNhoHon == 0)
                            cm.Parameters.AddWithValue("@SoTienNhoHon", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@SoTienNhoHon", soTienNhoHon);
                        if (soTienLonHon == 0)
                            cm.Parameters.AddWithValue("@SoTienLonHon", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@SoTienLonHon", soTienLonHon);

                        if (noTaiKhoan == null)
                            cm.Parameters.AddWithValue("@NoTaiKhoan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@NoTaiKhoan", noTaiKhoan);
                        if (coTaiKhoan == null)
                            cm.Parameters.AddWithValue("@CoTaiKhoan", DBNull.Value);
                        else
                            cm.Parameters.AddWithValue("@CoTaiKhoan", coTaiKhoan);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTu(dr));
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return listChungTu;
        }

        public static ChungTuList TimChungTu(string dieuKienTim)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimChungTu_DieuKienTim";
                        cm.Parameters.AddWithValue("@DieuKienTim", dieuKienTim);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTu(dr));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }
        public static ChungTuList DanhSachCTUpdateData()
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "UpdateDataTemp";
                   
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTu(dr));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }
        #endregion
        public static ChungTuList GetChungTuListByMaChungTu(long maChungTu)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelectChungTuByMaChungTu";                       
                        cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTu(dr));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        public static ChungTuList GetChungTuListByMaChungTu_New(long maChungTu)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelectChungTuByMaChungTu";
                        cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTu_New(dr));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }
        // chi lay con la cac buttoan
        public static ChungTuList GetChungTuListByMaChungTuByLoc(long maChungTu)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelectChungTuByMaChungTu";
                        cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTu_ByLoc(dr));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        public static int TongDonngTim(string dieuKienTim,long NguoiLap,int loai,string TuNgay,string DenNgay)
        {
            //int CK = 0;
            //if (blCK == true)
            //    CK = 1;
            int giaTriTraVe = 0;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TimTongDongChungTu_DieuKienTim";
                    cm.Parameters.AddWithValue("@DieuKienTim", dieuKienTim);
                    cm.Parameters.AddWithValue("@NguoiLap", NguoiLap);
                    cm.Parameters.AddWithValue("@Loai", loai);
                    cm.Parameters.AddWithValue("@TuNgay", TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", DenNgay);
                    SqlParameter OutPut = new SqlParameter("@GiaTriTraVe", SqlDbType.Int);
                    OutPut.Direction = ParameterDirection.Output;
                    cm.Parameters.Add(OutPut);
                    cm.ExecuteNonQuery();
                    giaTriTraVe = (int)OutPut.Value;
                }
            }//us

            return giaTriTraVe;
        }
        public static ChungTuList TimChungTu_Paging(string dieuKienTim, long TrangBo, int Size,long NguoiLap,int loai,string TuNgay,string DenNgay, int MaLoaiChungTu)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimChungTu_DieuKienTim_Paging";
                        cm.Parameters.AddWithValue("@DieuKienTim", dieuKienTim);
                        cm.Parameters.AddWithValue("@TrangBo", TrangBo);
                        cm.Parameters.AddWithValue("@Size", Size);
                        cm.Parameters.AddWithValue("@NguoiLap", NguoiLap);
                        cm.Parameters.AddWithValue("@Loai", loai);
                        cm.Parameters.AddWithValue("@TuNgay", TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", DenNgay);
                        cm.Parameters.AddWithValue("@LoaiChungTu", MaLoaiChungTu);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTu(dr));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }



        public static ChungTuList TimChungTu(string SoChungTu, DateTime TuNgay, DateTime DenNgay, decimal SoTienTu, decimal SoTienDen, string DienGiai, int NoTaiKhoan, int CoTaiKhoan, string TenDoiTuong, int MaLoaiChungTu)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "[spd_TimChungTu_New]";
                        cm.Parameters.AddWithValue("@SoChungTu", SoChungTu);
                        cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);
                        
                        cm.Parameters.AddWithValue("@TuNgay", TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", DenNgay);
                        cm.Parameters.AddWithValue("@LoaiChungTu", MaLoaiChungTu );
                        cm.Parameters.AddWithValue("@SoTienTu", SoTienTu);
                        cm.Parameters.AddWithValue("@SoTienDen", SoTienDen);
                        cm.Parameters.AddWithValue("@DienGiai", DienGiai);
                        cm.Parameters.AddWithValue("@NoTaiKhoan", NoTaiKhoan);
                        cm.Parameters.AddWithValue("@CoTaiKhoan", CoTaiKhoan);
                        cm.Parameters.AddWithValue("@TenDoiTuong", TenDoiTuong);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTuList(dr));                               
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        public static ChungTuList TimChungTu_New(string SoChungTu, DateTime TuNgay, DateTime DenNgay, decimal SoTienTu, decimal SoTienDen, string DienGiai, int NoTaiKhoan, int CoTaiKhoan, string TenDoiTuong, int MaLoaiChungTu)
        {
            ChungTuList listChungTu;
            listChungTu = new ChungTuList();
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_TimChungTu_New";
                        cm.Parameters.AddWithValue("@SoChungTu", SoChungTu);
                        cm.Parameters.AddWithValue("@NguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);

                        cm.Parameters.AddWithValue("@TuNgay", TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", DenNgay);
                        cm.Parameters.AddWithValue("@LoaiChungTu", MaLoaiChungTu);
                        cm.Parameters.AddWithValue("@SoTienTu", SoTienTu);
                        cm.Parameters.AddWithValue("@SoTienDen", SoTienDen);
                        cm.Parameters.AddWithValue("@DienGiai", DienGiai);
                        cm.Parameters.AddWithValue("@NoTaiKhoan", NoTaiKhoan);
                        cm.Parameters.AddWithValue("@CoTaiKhoan", CoTaiKhoan);
                        cm.Parameters.AddWithValue("@TenDoiTuong", TenDoiTuong);
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listChungTu.Add(ChungTu.GetChungTuList_New(dr));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listChungTu;
        }

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            
        }
        private class CriteriaAll
        {
            
        }
        private class CriteriaByTamUng
        {
            public CriteriaByTamUng()
            { }
        }
        
        [Serializable()]
        private class CriteriaFilerChungTuByNgay
        {
            public DateTime _TuNgay;
            public DateTime _DenNgay;
            public Int32 _MaLoaiChungTu;
            public CriteriaFilerChungTuByNgay(DateTime tuNgay, DateTime denNgay, Int32 maLoaiChungTu)
            {

                _TuNgay = tuNgay;
                _DenNgay = denNgay;
                _MaLoaiChungTu = maLoaiChungTu;
            }
        }

        [Serializable()]
        private class CriteriaFilerByQuanTri
        {
            public DateTime _TuNgay;
            public DateTime _DenNgay;
            public string _SoHieuTK;
            public int _MaBoPhan;
            public CriteriaFilerByQuanTri(DateTime tuNgay, DateTime denNgay, string soHieuTK, int maBoPhan)
            {
                _TuNgay = tuNgay;
                _DenNgay = denNgay;
                _SoHieuTK = soHieuTK;
                _MaBoPhan = maBoPhan;
            }
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            try
            {
                this.RaiseListChangedEvents = false;
                if (criteria is Criteria)
                {
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select * from tblChungTu";

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ChungTu.GetChungTu(dr));
                                }
                            }
                        }

                    }
                }
                else if (criteria is CriteriaByTamUng)
                {
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "SelectChungTuByTamUng";
                            cm.Parameters.AddWithValue("UserID",ERP_Library.Security.CurrentUser.Info.UserID);

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ChungTu.GetChungTu(dr));
                                }
                            }
                        }

                    }
                }
                else if (criteria is CriteriaFilerChungTuByNgay)
                {
                    CriteriaFilerChungTuByNgay crit = (CriteriaFilerChungTuByNgay)criteria;
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_LoadChungTuTheoNgay";
                            cm.Parameters.AddWithValue("@TuNgay", crit._TuNgay);
                            cm.Parameters.AddWithValue("@DenNgay", crit._DenNgay);
                            cm.Parameters.AddWithValue("@MaLoaiChungTu", crit._MaLoaiChungTu);
                            cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID);// 1);// 1: admin
                            //cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID); // nhớ sửa lại
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ChungTu.GetChungTu(dr));
                                }
                            }
                        }
                    }
                }
                else if (criteria is CriteriaFilerByQuanTri)
                {
                    CriteriaFilerByQuanTri crit = (CriteriaFilerByQuanTri)criteria;
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_DanhSachChungTuAll";
                            cm.Parameters.AddWithValue("@TuNgay", crit._TuNgay);
                            cm.Parameters.AddWithValue("@DenNgay", crit._DenNgay);
                            cm.Parameters.AddWithValue("@SoHieuTK", crit._SoHieuTK);
                            cm.Parameters.AddWithValue("@MaBoPhan", crit._MaBoPhan);// 1);// 1: admin
                            //cm.Parameters.AddWithValue("@MaNguoiLap", ERP_Library.Security.CurrentUser.Info.UserID); // nhớ sửa lại
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ChungTu.GetChungTuByQuanTri(dr));
                                }
                            }
                        }

                    }

                }
                else if (criteria is CriteriaAll)
                {
                  
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_SelecttblChungTuList";
                         
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ChungTu.GetChungTuByListAll(dr));
                                }
                            }
                        }

                    }

                }
                this.RaiseListChangedEvents = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            SqlTransaction tr;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    // update (thus deleting) any deleted child objects
                    foreach (ChungTu obj in DeletedList)
                        obj.DeleteSelf();
                    // now that they are deleted, remove them from memory too
                    DeletedList.Clear();
                    // add/update any current child objects 1030K/AE/DV09/2010
                    foreach (ChungTu obj in this)
                    {
                        if (obj.IsDirty)
                        {
                            if (obj.IsNew)
                                obj.Insert();
                            else
                                obj.UpdateTranSacTion(tr);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
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

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                tr = cn.BeginTransaction();
                try
                {
                    // update (thus deleting) any deleted child objects
                    foreach (ChungTu obj in DeletedList)
                        obj.DeleteSelf();
                    // now that they are deleted, remove them from memory too
                    DeletedList.Clear();
                    // add/update any current child objects
                    foreach (ChungTu obj in this)
                    {
                        if (obj.IsDirty)
                        {
                            if (obj.IsNew)
                                obj.InsertTranSacTion(tr);
                            else
                                obj.UpdateTranSacTion(tr);
                        }
                    }
                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }
            this.RaiseListChangedEvents = true;
        }


        #endregion
    }
}
