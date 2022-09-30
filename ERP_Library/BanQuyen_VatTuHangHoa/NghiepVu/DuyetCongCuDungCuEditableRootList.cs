using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class DuyetCongCuDungCuList : Csla.BusinessListBase<DuyetCongCuDungCuList, DuyetCongCuDungCu>
    {
        //public static SqlTransaction AdvancedTransaction = null;
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            DuyetCongCuDungCu item = DuyetCongCuDungCu.NewDuyetCongCuDungCu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Authorization Rules

        public static bool CanGetObject()
        {
            //TODO: Define CanGetObject permission in DuyetCongCuDungCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DuyetCongCuDungCuListViewGroup"))
            //	return true;
            //return false;
        }

        public static bool CanAddObject()
        {
            //TODO: Define CanAddObject permission in DuyetCongCuDungCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DuyetCongCuDungCuListAddGroup"))
            //	return true;
            //return false;
        }

        public static bool CanEditObject()
        {
            //TODO: Define CanEditObject permission in DuyetCongCuDungCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DuyetCongCuDungCuListEditGroup"))
            //	return true;
            //return false;
        }

        public static bool CanDeleteObject()
        {
            //TODO: Define CanDeleteObject permission in DuyetCongCuDungCuList
            return true;
            //if (Csla.ApplicationContext.User.IsInRole("DuyetCongCuDungCuListDeleteGroup"))
            //	return true;
            //return false;
        }
        #endregion //Authorization Rules

        #region Factory Methods
        private DuyetCongCuDungCuList()
        { /* require use of factory method */ }

        public static DuyetCongCuDungCuList NewDuyetCongCuDungCuList()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException("User not authorized to add a DuyetCongCuDungCuList");
            return new DuyetCongCuDungCuList();
        }

        public static DuyetCongCuDungCuList GetDuyetCongCuDungCuList_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien(byte loaiNghiepVu, int maBoPhan, int maHangHoa)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DuyetCongCuDungCuList");
            return DataPortal.Fetch<DuyetCongCuDungCuList>(new FilterCriteria_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien(loaiNghiepVu, maBoPhan, maHangHoa));
        }
        public static DuyetCongCuDungCuList GetDuyetCongCuDungCuList_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien(byte loaiNghiepVu, int maBoPhan, int maHangHoa,DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DuyetCongCuDungCuList");
            return DataPortal.Fetch<DuyetCongCuDungCuList>(new FilterCriteria_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien(loaiNghiepVu, maBoPhan, maHangHoa,denNgay));
        }
        public static DuyetCongCuDungCuList GetDuyetCongCuDungCuList_ChoDuyetTheoDieuKien(byte loaiNghiepVu, int maBoPhan, int maHangHoa,DateTime denNgay)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DuyetCongCuDungCuList");
            return DataPortal.Fetch<DuyetCongCuDungCuList>(new FilterCriteria_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien(loaiNghiepVu, maBoPhan, maHangHoa,denNgay));
        }
        public static DuyetCongCuDungCuList GetDuyetCongCuDungCuList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a DuyetCongCuDungCuList");
            return DataPortal.Fetch<DuyetCongCuDungCuList>(new FilterCriteria());
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {

            public FilterCriteria()
            {

            }
        }

        [Serializable()]
        private class FilterCriteria_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien
        {
            public byte LoaiNghiepVu = 0;
            public int MaBoPhan = 0;
            public int MaHangHoa = 0;
            public FilterCriteria_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien(byte loaiNghiepVu, int maBoPhan, int maHangHoa)
            {
                this.LoaiNghiepVu = loaiNghiepVu;
                this.MaBoPhan = maBoPhan;
                this.MaHangHoa = maHangHoa;
            }
        }

        [Serializable()]
        private class FilterCriteria_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien
        {
            public byte LoaiNghiepVu = 0;
            public int MaBoPhan = 0;
            public int MaHangHoa = 0;
            public DateTime DenNgay;
            public FilterCriteria_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien(byte loaiNghiepVu, int maBoPhan, int maHangHoa,DateTime denNgay)
            {
                this.LoaiNghiepVu = loaiNghiepVu;
                this.MaBoPhan = maBoPhan;
                this.MaHangHoa = maHangHoa;
                this.DenNgay = denNgay;
            }
        }
        [Serializable()]
        private class FilterCriteria_ChoDuyetTheoDieuKien
        {
            public byte LoaiNghiepVu = 0;
            public int MaBoPhan = 0;
            public int MaHangHoa = 0;
            public FilterCriteria_ChoDuyetTheoDieuKien(byte loaiNghiepVu, int maBoPhan, int maHangHoa)
            {
                this.LoaiNghiepVu = loaiNghiepVu;
                this.MaBoPhan = maBoPhan;
                this.MaHangHoa = maHangHoa;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
        {
            RaiseListChangedEvents = false;
            if (criteria is FilterCriteria)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch(tr, criteria as FilterCriteria);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            else if (criteria is FilterCriteria_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien(tr, criteria as FilterCriteria_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            else if (criteria is FilterCriteria_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien(tr, criteria as FilterCriteria_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            else if (criteria is FilterCriteria_ChoDuyetTheoDieuKien)
            {
                SqlTransaction tr;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    tr = cn.BeginTransaction();
                    try
                    {
                        ExecuteFetch_ChoDuyetTheoDieuKien(tr, criteria as FilterCriteria_ChoDuyetTheoDieuKien);

                        tr.Commit();
                    }
                    catch
                    {
                        tr.Rollback();
                        throw;
                    }
                }//using
            }
            RaiseListChangedEvents = true;
        }
        private void ExecuteFetch_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien(SqlTransaction tr, FilterCriteria_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectDuyetCongCuDungCuList_ChuaThucHienNghiepVu_DuyetHoacChuaDuyet_TheoDieuKien";
                cm.Parameters.AddWithValue("@LoaiNghiepVu", criteria.LoaiNghiepVu);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@MaHangHoa", criteria.MaHangHoa);
                cm.Parameters.AddWithValue("@DenNgay", criteria.DenNgay);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DuyetCongCuDungCu.GetDuyetCongCuDungCu(dr));
                }
            }//using
        }
        private void ExecuteFetch_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien(SqlTransaction tr, FilterCriteria_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectDuyetCongCuDungCuList_ChuaThucHienNghiepVu_DaDuyet_TheoDieuKien";
                cm.Parameters.AddWithValue("@LoaiNghiepVu", criteria.LoaiNghiepVu);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@MaHangHoa", criteria.MaHangHoa);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DuyetCongCuDungCu.GetDuyetCongCuDungCu(dr));
                }
            }//using
        }
        private void ExecuteFetch_ChoDuyetTheoDieuKien(SqlTransaction tr, FilterCriteria_ChoDuyetTheoDieuKien criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectDuyetCongCuDungCuList_ChoDuyetTheoDieuKien";
                cm.Parameters.AddWithValue("@LoaiNghiepVu", criteria.LoaiNghiepVu);
                cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                cm.Parameters.AddWithValue("@MaHangHoa", criteria.MaHangHoa);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DuyetCongCuDungCu.GetDuyetCongCuDungCu(dr));
                }
            }//using
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "spd_SelectDuyetCongCuDungCuListAll";


                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(DuyetCongCuDungCu.GetDuyetCongCuDungCu(dr));
                }
            }//using
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
                        foreach (DuyetCongCuDungCu deletedChild in DeletedList)
                            deletedChild.DeleteSelf(tr);
                        DeletedList.Clear();

                        // loop through each non-deleted child object
                        foreach (DuyetCongCuDungCu child in this)
                        {
                            if (child.IsNew)
                                child.Insert(tr, this);
                            else
                                child.Update(tr, this);
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
