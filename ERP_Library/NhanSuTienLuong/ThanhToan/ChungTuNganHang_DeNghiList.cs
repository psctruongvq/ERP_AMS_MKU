
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTuNganHang_DeNghiList : Csla.BusinessListBase<ChungTuNganHang_DeNghiList, ChungTuNganHang_DeNghi>
    {
        
        #region Factory Methods
        internal static ChungTuNganHang_DeNghiList NewChungTuNganHang_DeNghiList()
        {
            return new ChungTuNganHang_DeNghiList();
        }

        internal static ChungTuNganHang_DeNghiList GetChungTuNganHang_DeNghiList(int MaChungTu)
        {
            return new ChungTuNganHang_DeNghiList(MaChungTu);
        }
        /// <summary>
        /// Lấy các đề nghị chưa được duyệt chuyển khoản
        /// </summary>
        /// <param name="MaNganHang">Mã ID Ngân Hàng hoặc = 0 thì lấy tất cả</param>
        /// <returns></returns>
        public static ChungTuNganHang_DeNghiList GetDeNghiChuaDuyet(int MaNganHang, bool Loai)
        {
            ChungTuNganHang_DeNghiList item = new ChungTuNganHang_DeNghiList();
            item.FetchChuaDuyet(MaNganHang, Loai);
            return item;
        }

        public static ChungTuNganHang_DeNghiList GetDeNghiChuaDuyet_HoaDon(int MaNganHang, bool Loai)
        {
            ChungTuNganHang_DeNghiList item = new ChungTuNganHang_DeNghiList();
            item.FetchHoaDonChuaDuyet(MaNganHang, Loai);
            return item;
        }

        public static ChungTuNganHang_DeNghiList GetDeNghiChuaDuyet_ChuaMuaNgoaiTe(int MaNganHang, bool Loai)
        {
            ChungTuNganHang_DeNghiList item = new ChungTuNganHang_DeNghiList();
            item.FetchDeNghiChuaMuaNgoaiTe(MaNganHang, Loai);
            return item;
        }

        public static ChungTuNganHang_DeNghiList GetDeNghiChuaDuyet_Khac(int MaNganHang, bool Loai)
        {
            ChungTuNganHang_DeNghiList item = new ChungTuNganHang_DeNghiList();
            item.FetchChuaDuyetKhac(MaNganHang, Loai);
            return item;
        }

        private ChungTuNganHang_DeNghiList()
        {

        }

        private ChungTuNganHang_DeNghiList(int MaChungTu)
        {
            MarkAsChild();
            Fetch(MaChungTu);
        }
        #endregion //Factory Methods


        #region Data Access
        private void FetchChuaDuyet(int MaNganHang, bool Loai)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_ChungTuNganHang_DeNghiChuaDuyet";
                    cm.Parameters.AddWithValue("@MaNganHang", MaNganHang);
                    cm.Parameters.AddWithValue("@Loai", Loai);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(ChungTuNganHang_DeNghi.GetChungTuNganHang_DeNghi(dr));
                }
                cn.Close();
            }
        }

        private void FetchHoaDonChuaDuyet(int MaNganHang, bool Loai)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_ChungTuNganHang_UNCHoaDonChuaDuyet";
                    cm.Parameters.AddWithValue("@MaNganHang", MaNganHang);
                    cm.Parameters.AddWithValue("@Loai", Loai);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(ChungTuNganHang_DeNghi.GetChungTuNganHang_DeNghi_New(dr));
                }
                cn.Close();
            }
        }

        private void FetchDeNghiChuaMuaNgoaiTe(int MaNganHang, bool Loai)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_DeNghiChuaMuaNgoaiTe";
                    cm.Parameters.AddWithValue("@MaNganHang", MaNganHang);
                    cm.Parameters.AddWithValue("@Loai", Loai);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(ChungTuNganHang_DeNghi.GetChungTuNganHang_DeNghi_New(dr));
                }
                cn.Close();
            }
        }

        private void FetchChuaDuyetKhac(int MaNganHang, bool Loai)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_ChungTuNganHang_UNCChuaDuyet";
                    cm.Parameters.AddWithValue("@MaNganHang", MaNganHang);
                    cm.Parameters.AddWithValue("@Loai", Loai);
                    cm.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(ChungTuNganHang_DeNghi.GetChungTuNganHang_DeNghi(dr));
                }
                cn.Close();
            }
        }

        private void Fetch(int MaChungTu)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_ChungTuNganHang_DeNghiList";
                    cm.Parameters.AddWithValue("@MaChungTu", MaChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        while (dr.Read())
                            this.Add(ChungTuNganHang_DeNghi.GetChungTuNganHang_DeNghi(dr));
                }
                cn.Close();
            }

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTuNganHang parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChungTuNganHang_DeNghi deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChungTuNganHang_DeNghi child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}
