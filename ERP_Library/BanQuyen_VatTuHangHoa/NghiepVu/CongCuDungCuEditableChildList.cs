
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CongCuDungCuList : Csla.BusinessListBase<CongCuDungCuList, CongCuDungCu>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CongCuDungCu item = CongCuDungCu.NewCongCuDungCu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static CongCuDungCuList NewCongCuDungCuList()
        {
            return new CongCuDungCuList();
        }

        internal static CongCuDungCuList GetCongCuDungCuList(long MaPhieuNhapXuat)
        {
            return new CongCuDungCuList(MaPhieuNhapXuat);
        }
        public static CongCuDungCuList GetCongCuDungCuList_ByMaThanhLy(long maThanhLy)
        {
            CongCuDungCuList congCuDungCuList = new CongCuDungCuList();

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
                            congCuDungCuList.Add(CongCuDungCu.GetCongCuDungCu(dr));
                    }
                }
            }

            return congCuDungCuList;

        }
        public static CongCuDungCuList GetCongCuDungCuList_DangChoDuyet()
        {
            CongCuDungCuList congCuDungCuList = new CongCuDungCuList();

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
                            congCuDungCuList.Add(CongCuDungCu.GetCongCuDungCu(dr));
                    }
                }
            }

            return congCuDungCuList;

        }
        public static CongCuDungCuList GetCongCuDungCuListChuaThanhLy_By_MaBoPhan_MaHangHoa(int maBoPhan, int maHangHoa)
        {
            CongCuDungCuList congCuDungCuList = new CongCuDungCuList();

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
                            congCuDungCuList.Add(CongCuDungCu.GetCongCuDungCu(dr));
                    }
                }
            }

            return congCuDungCuList;

        }

        public static CongCuDungCuList GetCongCuDungCuListChuaThanhLy_By_MaHangHoa(int maHangHoa)
        {
            CongCuDungCuList congCuDungCuList = new CongCuDungCuList();

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
                            congCuDungCuList.Add(CongCuDungCu.GetCongCuDungCu(dr));
                    }
                }
            }

            return congCuDungCuList;

        }
        public static CongCuDungCuList GetCongCuDungCuList(int maBoPhan)
        {
            CongCuDungCuList congCuDungCuList = new CongCuDungCuList();

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
                            congCuDungCuList.Add(CongCuDungCu.GetCongCuDungCu(dr));
                    }
                }
            }

            return congCuDungCuList;

        }

        private CongCuDungCuList()
        {
            MarkAsChild();
        }

        private CongCuDungCuList(long MaPhieuNhapXuat)
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
                            this.Add(CongCuDungCu.GetCongCuDungCu(dr));
                    }
                }
            }

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, PhieuNhapXuat parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            if (parent.Loai == 7 || parent.Loai == 8)//7:Thanh ly CCDC; 8:Dieu chuyen ngoai CCDC
            {
                //khong xoa ma chi cap nhat lai chut thong tin roi clear khoi danh sách
                foreach (CongCuDungCu deletedChild in DeletedList)
                {
                    deletedChild.ThanhLy = false;
                    deletedChild.NgayThanhLy = DateTime.MinValue;
                    deletedChild.MaThanhLy = 0;
                    int maDuyetCongCuDungCu = deletedChild.MaDuyetCongCuDungCu;
                    deletedChild.MaDuyetCongCuDungCu = 0;
                   
                    deletedChild.Update(tr, parent);

                    DuyetCongCuDungCu duyetCcdc = DuyetCongCuDungCu.GetDuyetCongCuDungCu(maDuyetCongCuDungCu);
                    duyetCcdc.DaThucHienNghiepVu = false;
                    duyetCcdc.Update(tr, null);
                }
                DeletedList.Clear();
                //
                foreach (CongCuDungCu child in this)
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

                        DuyetCongCuDungCu duyetCcdc = DuyetCongCuDungCu.GetDuyetCongCuDungCu(child.MaDuyetCongCuDungCu);
                        duyetCcdc.DaThucHienNghiepVu = true;
                        duyetCcdc.Update(tr, null);
                    }
                }
            }
            else
            {
                foreach (CongCuDungCu deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (CongCuDungCu child in this)
                {
                    if (child.IsNew)
                        child.Insert(tr, parent);
                    else
                        child.Update(tr, parent);
                }
            }


            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}
