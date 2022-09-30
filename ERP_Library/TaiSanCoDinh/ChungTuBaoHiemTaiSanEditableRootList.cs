using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
//23_04_2013

namespace ERP_Library
{
    [Serializable()]
    public class ChungTuBaoHiemTaiSanList : Csla.BusinessListBase<ChungTuBaoHiemTaiSanList, ChungTuBaoHiemTaiSan>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChungTuBaoHiemTaiSan item = ChungTuBaoHiemTaiSan.NewChungTuBaoHiemTaiSan();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in ChungTuBaoHiemTaiSanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuBaoHiemTaiSanListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in ChungTuBaoHiemTaiSanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuBaoHiemTaiSanListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in ChungTuBaoHiemTaiSanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuBaoHiemTaiSanListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in ChungTuBaoHiemTaiSanList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("ChungTuBaoHiemTaiSanListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private ChungTuBaoHiemTaiSanList()
        { /* require use of factory method */ }

        public static ChungTuBaoHiemTaiSanList NewChungTuBaoHiemTaiSanList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a ChungTuBaoHiemTaiSanList");
            return new ChungTuBaoHiemTaiSanList();
        }

        public static ChungTuBaoHiemTaiSanList GetChungTuBaoHiemTaiSanList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuBaoHiemTaiSanList");
            return DataPortal.Fetch<ChungTuBaoHiemTaiSanList>(new FilterCriteria());
        }

        public static ChungTuBaoHiemTaiSanList GetChungTuBaoHiemTaiSanList_TimTheoLoaiVaNgay(int loai, long maDoiTac, DateTime tuNgay, DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a ChungTuBaoHiemTaiSanList");
            return DataPortal.Fetch<ChungTuBaoHiemTaiSanList>(new FilterCriteria_TimTheoLoaiVaNgay(loai, maDoiTac, tuNgay, denNgay));
        }     

        public static DataTable GetPhieuXuatByPhieuNhap(int ma, int loai)
        {
            //
            DataTable kqTbl = new DataTable();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                // @TuNgay datatime, @DenNgay datatime, @MaBoPhan int, @ChuongTrinh int, @DienGiai nvarchar(max)
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandTimeout = 1800;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetPhieuXuatByPhieuNhap";
                    cm.Parameters.AddWithValue("@MaChungTuBaoHiemTaiSan", ma);
                    cm.Parameters.AddWithValue("@loai", loai);
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        if (ds != null && ds.Tables.Count > 0)
                            kqTbl = ds.Tables[0];
                    }
                }
            }//us
            return kqTbl;
        }

        public static int GetMaPhieuBySoPhieu(string maChungTuBaoHiemTaiSan)
        {
            int _count = 0;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetMaPhieuBySo";
                    cm.Parameters.AddWithValue("@SoChungTuBaoHiemTaiSan", maChungTuBaoHiemTaiSan);
                    using (SqlDataReader rdr = cm.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            _count = Convert.ToInt32(rdr["MaChungTuBaoHiemTaiSan"].ToString());
                        }
                    }
                }
            }//us
            return _count;
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int MaNguoiLap;
            public int MaKho;
            public long MaDoiTac;
            public int MaDinhKhoan;
            public long MaNguoiNhapXuat;
            public int MaPhongBan;
            public long MaChungTuBaoHiemTaiSanThamChieu;

            public FilterCriteria()
            { }
            public FilterCriteria(int maNguoiLap, int maKho, long maDoiTac, int maDinhKhoan, long maNguoiNhapXuat, int maPhongBan, long maChungTuBaoHiemTaiSanThamChieu)
            {
                this.MaNguoiLap = maNguoiLap;
                this.MaKho = maKho;
                this.MaDoiTac = maDoiTac;
                this.MaDinhKhoan = maDinhKhoan;
                this.MaNguoiNhapXuat = maNguoiNhapXuat;
                this.MaPhongBan = maPhongBan;
                this.MaChungTuBaoHiemTaiSanThamChieu = maChungTuBaoHiemTaiSanThamChieu;

            }
        }
        [Serializable()]
        private class FilterCriteria_TimTheoLoaiVaNgay
        {
            public int Loai = 0;
            public DateTime TuNgay;
            public DateTime DenNgay;
            public long MaDoiTac;
            public FilterCriteria_TimTheoLoaiVaNgay(int loai, long maDoiTac, DateTime ngay, DateTime denNgay)
            {
                this.Loai = loai;
                this.TuNgay = ngay;
                this.DenNgay = denNgay;
                this.MaDoiTac = maDoiTac;
            }
        }       
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
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
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, Object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandTimeout = 900;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_GetPhieuDeNghiXuatDongPhucList";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTuBaoHiemTaiSan.GetChungTuBaoHiemTaiSan(dr));
                    }
                }
                else if (criteria is FilterCriteria_TimTheoLoaiVaNgay)
                {
                    cm.CommandText = "spd_GetChungTuBaoHiemTaiSanList_TimTheoLoaiVaNgay";
                    cm.Parameters.AddWithValue("@Loai", ((FilterCriteria_TimTheoLoaiVaNgay)criteria).Loai);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteria_TimTheoLoaiVaNgay)criteria).MaDoiTac);
                    if (((FilterCriteria_TimTheoLoaiVaNgay)criteria).TuNgay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_TimTheoLoaiVaNgay)criteria).TuNgay);
                    else
                        cm.Parameters.AddWithValue("@Ngay", DBNull.Value);

                    if (((FilterCriteria_TimTheoLoaiVaNgay)criteria).DenNgay != DateTime.MinValue)
                        cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_TimTheoLoaiVaNgay)criteria).DenNgay);
                    else
                        cm.Parameters.AddWithValue("@DenNgay", DBNull.Value);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTuBaoHiemTaiSan.GetChungTuBaoHiemTaiSan(dr));
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
                    foreach (ChungTuBaoHiemTaiSan deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChungTuBaoHiemTaiSan child in this)
                    {
                        if (child.IsNew)
                            child.Insert(tr);
                        else
                            child.Update(tr);
                    }

                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using SqlConnection
            RaiseListChangedEvents = true;
        }
        #endregion //Data Access - Update
        #endregion //Data Access
    }
}
