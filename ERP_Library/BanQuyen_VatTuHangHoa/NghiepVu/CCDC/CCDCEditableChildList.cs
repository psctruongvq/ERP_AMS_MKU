
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library////05012016
{
    [Serializable()]
    public class CCDCList : Csla.BusinessListBase<CCDCList, CCDC>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CCDC item = CCDC.NewCongCuDungCu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static CCDCList NewCongCuDungCuList()
        {
            return new CCDCList();
        }

        public static CCDCList NewCongCuDungCuListForUpdate()
        {
            return new CCDCList(true);
        }

        internal static CCDCList GetCongCuDungCuList(long MaPhieuNhapXuat)
        {
            return new CCDCList(MaPhieuNhapXuat);
        }
        public static CCDCList GetCongCuDungCuList_ByMaThanhLy(long maThanhLy)
        {
            CCDCList congCuDungCuList = new CCDCList();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectCongCuDungCu_ByMaThanhLy";
                    cm.Parameters.AddWithValue("@MaThanhLy", maThanhLy);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            congCuDungCuList.Add(CCDC.GetCongCuDungCu(dr));
                    }
                }
            }

            return congCuDungCuList;

        }
        public static CCDCList GetCongCuDungCuList_DangChoDuyet()
        {
            CCDCList congCuDungCuList = new CCDCList();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelectCongCuDungCu_DangChoDuyet";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            congCuDungCuList.Add(CCDC.GetCongCuDungCu(dr));
                    }
                }
            }

            return congCuDungCuList;

        }
        public static CCDCList GetCongCuDungCuListChuaThanhLy_By_MaBoPhan_MaHangHoa(int maBoPhan, int maHangHoa)
        {
            CCDCList congCuDungCuList = new CCDCList();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetCongCuDungCuListChuaThanhLy_By_MaBoPhan_MaHangHoa";
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            congCuDungCuList.Add(CCDC.GetCongCuDungCu(dr));
                    }
                }
            }

            return congCuDungCuList;

        }

        public static CCDCList GetCongCuDungCuListChuaThanhLy_By_MaHangHoa(int maHangHoa)
        {
            CCDCList congCuDungCuList = new CCDCList();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetCongCuDungCuListChuaThanhLy_By_MaHangHoa";
                    cm.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            congCuDungCuList.Add(CCDC.GetCongCuDungCu(dr));
                    }
                }
            }
            return congCuDungCuList;
        }

        public static CCDCList GetCongCuDungCuList_LaCCDCCu(Boolean laCCDCCu)
        {
            CCDCList congCuDungCuList = new CCDCList();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_GetCongCuDungCuListChuaThanhLy_By_LaCCDCCu";
                    cm.Parameters.AddWithValue("@LaCCDCCu", laCCDCCu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            congCuDungCuList.Add(CCDC.GetCongCuDungCu(dr));
                    }
                }
            }
            return congCuDungCuList;
        }

        public static CCDCList GetCongCuDungCuList(int maBoPhan)
        {
            CCDCList congCuDungCuList = new CCDCList();

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCongCuDungCusByAndMaBoPhan";
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            congCuDungCuList.Add(CCDC.GetCongCuDungCu(dr));
                    }
                }
            }

            return congCuDungCuList;

        }

        public static CCDCList GetCongCuDungCuListForShowListAll(int maBoPhan, DateTime tungay, DateTime denngay, byte htxemngay)
        {
            CCDCList congCuDungCuList = new CCDCList(true);

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCCDCListAll";
                    cm.Parameters.AddWithValue("@MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("@TuNgay", tungay);
                    cm.Parameters.AddWithValue("@DenNgay", denngay);
                    cm.Parameters.AddWithValue("@HTXemNgay", htxemngay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            congCuDungCuList.Add(CCDC.GetCongCuDungCuForShowListAll(dr));
                    }
                }
            }

            return congCuDungCuList;

        }

        public static CCDCList GetCongCuDungCuListForUpdateNguyenGia()
        {
            CCDCList congCuDungCuList = new CCDCList(true);

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCCDCListForUpdateNguyenGia";
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            congCuDungCuList.Add(CCDC.GetCongCuDungCuForShowListAll(dr));
                    }
                }
            }

            return congCuDungCuList;

        }

        public static CCDCList GetCongCuDungCuListForInMaVach(int maBoPhan, int maHangHoa)
        {
            CCDCList congCuDungCuList = new CCDCList(true);

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCCDCListAllForInMaVach";
                    cm.Parameters.AddWithValue("MaBoPhan", maBoPhan);
                    cm.Parameters.AddWithValue("MaHangHoa", maHangHoa);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            congCuDungCuList.Add(CCDC.GetCongCuDungCuForShowListAll(dr));
                    }
                }
            }

            return congCuDungCuList;

        }

        private CCDCList()
        {
            MarkAsChild();
        }

        private CCDCList(bool update)
        {
          
        }

        private CCDCList(long MaPhieuNhapXuat)
        {
            MarkAsChild();
            Fetch(MaPhieuNhapXuat);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(long MaPhieuNhapXuat)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCongCuDungCusByAndMaPhieuNhapXuat";
                    cm.Parameters.AddWithValue("@MaPhieuNhapXuat", MaPhieuNhapXuat);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CCDC.GetCongCuDungCu(dr));
                    }
                }
            }

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, PhieuNhapXuatCCDC parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            if (parent.Loai == 7 || parent.Loai == 8)//7:Thanh ly CCDC; 8:Dieu chuyen ngoai CCDC
            {
                //khong xoa ma chi cap nhat lai chut thong tin roi clear khoi danh sách
                foreach (CCDC deletedChild in DeletedList)
                {
                    deletedChild.ThanhLy = false;
                    deletedChild.NgayThanhLy = DateTime.MinValue;
                    deletedChild.MaThanhLy = 0;
                    //int maDuyetCongCuDungCu = deletedChild.MaDuyetCongCuDungCu;
                    deletedChild.MaDuyetCongCuDungCu = 0;
                   
                    deletedChild.Update(tr, parent);

                    //DuyetCCDC duyetCcdc = DuyetCCDC.GetDuyetCongCuDungCu(maDuyetCongCuDungCu);
                    //duyetCcdc.DaThucHienNghiepVu = false;
                    //duyetCcdc.Update(tr, null);
                }
                DeletedList.Clear();
                //
                foreach (CCDC child in this)
                {
                    if (child.IsNew)
                    {
                        //khong duoc phep insert khi xu ly thanh ly hoac dieu chuyen ngoai
                    }
                    else
                    {
                        child.ThanhLy = true;
                        child.NgayThanhLy = parent.NgayNX;
                        child.MaThanhLy = parent.MaPhieuNhapXuat;
                        child.Update(tr, parent);

                        //DuyetCCDC duyetCcdc = DuyetCCDC.GetDuyetCongCuDungCu(child.MaDuyetCongCuDungCu);
                        //duyetCcdc.DaThucHienNghiepVu = true;
                        //duyetCcdc.Update(tr, null);
                    }
                }
            }
            else
            {
                foreach (CCDC deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (CCDC child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }
            }


            RaiseListChangedEvents = true;
        }


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
                    // loop through each non-deleted child object
                    foreach (CCDC child in this)
                    {
                            child.UpdateNguyenGia(tr);
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
        #endregion //Data Access

    }
}
