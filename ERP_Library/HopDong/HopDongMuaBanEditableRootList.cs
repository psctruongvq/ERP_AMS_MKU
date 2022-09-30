
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    //Thành
    [Serializable()]
    public class HopDongMuaBanList : Csla.BusinessListBase<HopDongMuaBanList, HopDongMuaBan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            HopDongMuaBan item = HopDongMuaBan.NewHopDongMuaBan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in HopDongMuaBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in HopDongMuaBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in HopDongMuaBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in HopDongMuaBanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("HopDongMuaBanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private HopDongMuaBanList()
        { /* require use of factory method */ }

        public static HopDongMuaBanList NewHopDongMuaBanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a HopDongMuaBanList");
            return new HopDongMuaBanList();
        }

        public static HopDongMuaBanList GetHopDongMuaBanList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteria());
        }

        public static HopDongMuaBanList GetHopDongMuaBanList(DateTime TuNgay, DateTime DenNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriabyNgayLap(TuNgay, DenNgay));
        }

        public static HopDongMuaBanList GetHopDongMuaBanList_ChuaLapDeNghi()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriaby_ChuaLapDeNghi());
        }

        public static HopDongMuaBanList GetHopDongMuaBanList_TheoDoiTac(long maDoiTac)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriaby_TheoDoiTac(maDoiTac));
        }

        public static HopDongMuaBanList GetHopDongMuaBanList(short Loai)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriaByLoai(Loai));
        }

        public static HopDongMuaBanList GetHopDongMuaBanList(short Loai, string ChuoiTimKiem, bool MuaBan)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriaByTimHopDong(Loai, ChuoiTimKiem, MuaBan));
        }

        public static HopDongMuaBanList GetHopDongMuaBanList(short Loai, string ChuoiTimKiem, bool MuaBan, string ChuoiHHDV, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriaByFull(Loai, ChuoiTimKiem, MuaBan, ChuoiHHDV, tuNgay, denNgay));
        }
        //M
        public static HopDongMuaBanList GetHopDongMuaBanList( int loaiHopDong,long maDoiTac, byte TinhTrang)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriaByLapPhieu(loaiHopDong,maDoiTac,TinhTrang));
        }
        public static HopDongMuaBanList GetHopDongMuaBanList(long maPhieuNhapXuat)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriaByMaPhieuNhapXuat(maPhieuNhapXuat));
        }
        //END M

        public static HopDongMuaBanList GetHopDongMuaBanTaiSanList(short Loai, string ChuoiTimKiem)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriaByTimHopDongTaiSan(Loai, ChuoiTimKiem));
        }

        public static HopDongMuaBanList GetHopDongMuaBanByUserID()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a HopDongMuaBanList");
            return DataPortal.Fetch<HopDongMuaBanList>(new FilterCriteriaByUserID());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {


            public FilterCriteria()//long maHopDong
            {

            }
        }

        private class FilterCriteriaby_ChuaLapDeNghi
        {
            public FilterCriteriaby_ChuaLapDeNghi()//long maHopDong
            {

            }
        }

        private class FilterCriteriaby_TheoDoiTac
        {
            public long _maDoiTac = 0;
            public FilterCriteriaby_TheoDoiTac(long MaDoiTac)//long maHopDong
            {
                this._maDoiTac = MaDoiTac;
            }
        }

        private class FilterCriteriabyNgayLap
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            //public int Loai;
            //public bool MuaBan;

            public FilterCriteriabyNgayLap(DateTime _tuNgay, DateTime _denNgay)
            {
                this.TuNgay = _tuNgay;
                this.DenNgay = _denNgay;
                //this.Loai = _loai;
                //this.MuaBan = _muaBan;
            }
        }
        private class FilterCriteriaByLoai
        {
            public short Loai;

            public FilterCriteriaByLoai(short _loai)//long maHopDong
            {
                Loai = _loai;
            }
        }

        private class FilterCriteriaByTimHopDong
        {
            public short Loai;
            public string ChuoiTimKiem;
            public bool MuaBan;

            public FilterCriteriaByTimHopDong(short _loai, string _chuoiTimKiem, bool _muaBan)//long maHopDong
            {
                Loai = _loai;
                ChuoiTimKiem = _chuoiTimKiem;
                MuaBan = _muaBan;
            }
        }

        private class FilterCriteriaByTimHopDongTaiSan
        {
            public short Loai;
            public string ChuoiTimKiem;

            public FilterCriteriaByTimHopDongTaiSan(short _loai, string _chuoiTimKiem)//long maHopDong
            {
                Loai = _loai;
                ChuoiTimKiem = _chuoiTimKiem;
            }
        }

        private class FilterCriteriaByFull
        {
            public DateTime TuNgay;
            public DateTime DenNgay;
            public string ChuoiHangHoaDV;
            public string ChuoiTimKiemHDKH;
            public bool MuaBan;
            public short Loai;

            public FilterCriteriaByFull(short _loai, string _chuoiTimKiemHDKH, bool _muaBan, string _chuoiHangHoaDV, DateTime _tuNgay, DateTime _denNgay)
            {
                Loai = _loai;
                ChuoiTimKiemHDKH = _chuoiTimKiemHDKH;
                MuaBan = _muaBan;
                ChuoiHangHoaDV = _chuoiHangHoaDV;
                TuNgay = _tuNgay;
                DenNgay = _denNgay;
            }
        }

        private class FilterCriteriaByLapPhieu//Theo Ma Doi Tac ===M
        {
            public long maDoiTac;
            public int loaiHopDong;
            public byte tinhTrang;

            public FilterCriteriaByLapPhieu(int _loaihopDong, long _maDoiTac, byte _tinhTrang)
            {
                maDoiTac = _maDoiTac;
                loaiHopDong = _loaihopDong;
                tinhTrang = _tinhTrang;
            }
        }



        private class FilterCriteriaByMaPhieuNhapXuat//Theo Ma Phieu Nhap Xuat ===M
        {
            public long MaPhieuNhapXuat;
            public FilterCriteriaByMaPhieuNhapXuat(long maPhieuNhapXuat)
            {
                MaPhieuNhapXuat = maPhieuNhapXuat;
            }
        }
        private class FilterCriteriaByUserID
        {
            public FilterCriteriaByUserID()
            { 
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        protected override void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;

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
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }//using

            RaiseListChangedEvents = true;
        }


        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteriaByLapPhieu)//M1
                {
                    cm.CommandText = "spd_SelecttblHopDongsByLapPhieu";
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaByLapPhieu)criteria).maDoiTac);
                    cm.Parameters.AddWithValue("@TinhTrang", ((FilterCriteriaByLapPhieu)criteria).tinhTrang);
                    cm.Parameters.AddWithValue("@LoaiHopDong", ((FilterCriteriaByLapPhieu)criteria).loaiHopDong);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongMuaBan.GetHopDongMuaBanWitoutChild(dr));
                    }
                }//END M1
                else
                {

                    if (criteria is FilterCriteria)
                    {
                        cm.CommandText = "spd_SelecttblHopDongMuaBansAll";
                    }
                    else if (criteria is FilterCriteriaby_ChuaLapDeNghi)
                    {
                        cm.CommandText = "spd_SelecttblHopDongMuaBan_ChuaLapDeNghi";
                        cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    }
                    else if (criteria is FilterCriteriaby_TheoDoiTac)
                    {
                        cm.CommandText = "spd_SelecttblHopDongMuaBan_TheoDoiTac";
                        cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteriaby_TheoDoiTac)criteria)._maDoiTac);
                    }
                    else if (criteria is FilterCriteriabyNgayLap)
                    {
                        cm.CommandText = "spd_SelecttblHopDongMuaBansByNgayLap";
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriabyNgayLap)criteria).TuNgay);
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriabyNgayLap)criteria).DenNgay);
                        cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    }
                    else if (criteria is FilterCriteriaByLoai)
                    {
                        cm.CommandText = "spd_SelecttblHopDongMuaBansByLoai";
                        cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByLoai)criteria).Loai);
                        cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    }
                    else if (criteria is FilterCriteriaByTimHopDong)
                    {
                        cm.CommandText = "spd_SelecttblTimHopDongLapDonHang";
                        cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByTimHopDong)criteria).Loai);
                        cm.Parameters.AddWithValue("@ChuoiTimKiem", ((FilterCriteriaByTimHopDong)criteria).ChuoiTimKiem);
                        cm.Parameters.AddWithValue("@MuaBan", ((FilterCriteriaByTimHopDong)criteria).MuaBan);
                        cm.Parameters.AddWithValue("@MaNguoiDung", ERP_Library.Security.CurrentUser.Info.UserID);
                    }
                    else if (criteria is FilterCriteriaByFull)
                    {
                        cm.CommandText = "spd_SelecttblTimHopDongDieuKienFull";
                        if (((FilterCriteriaByFull)criteria).TuNgay != DateTime.MinValue)
                            cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByFull)criteria).TuNgay);
                        else cm.Parameters.AddWithValue("@TuNgay", DBNull.Value);
                        if (((FilterCriteriaByFull)criteria).DenNgay != DateTime.MinValue)
                            cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByFull)criteria).DenNgay);
                        else cm.Parameters.AddWithValue("@DenNgay", DBNull.Value);
                        cm.Parameters.AddWithValue("@Loai", ((FilterCriteriaByFull)criteria).Loai);
                        cm.Parameters.AddWithValue("@MuaBan", ((FilterCriteriaByFull)criteria).MuaBan);
                        cm.Parameters.AddWithValue("@ChuoiHangHoaDV", ((FilterCriteriaByFull)criteria).ChuoiHangHoaDV);
                        cm.Parameters.AddWithValue("@ChuoiTimKiemHDKH", ((FilterCriteriaByFull)criteria).ChuoiTimKiemHDKH);
                    }

                    else if (criteria is FilterCriteriaByMaPhieuNhapXuat)//M2
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblHopDongsByMaPhieuNhapXuat";
                        cm.Parameters.AddWithValue("@MaPhieuNhapxuat", ((FilterCriteriaByMaPhieuNhapXuat)criteria).MaPhieuNhapXuat);
                    }//END M2
                    else if (criteria is FilterCriteriaByUserID)
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblHopDongsByUserID";
                        cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                    }

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(HopDongMuaBan.GetHopDongMuaBan(dr));
                    }
                }
            }
        }
        #endregion //Data Access - Fetch

        #region Data Access - Update
        protected override void DataPortal_Update()
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    // loop through each deleted child object
                    foreach (HopDongMuaBan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (HopDongMuaBan child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    throw ex;
                }
            }//using SqlConnection

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
