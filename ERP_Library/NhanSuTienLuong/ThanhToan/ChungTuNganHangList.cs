using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChungTuNganHangList : Csla.BusinessListBase<ChungTuNganHangList, ChungTuNganHang>
    {
        #region BindingList Overrides
        private int iddef = -1;
        protected override object AddNewCore()
        {
            ChungTuNganHang item = ChungTuNganHang.NewChungTuNganHangChild();
            item._maChungTu = iddef--;
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        private ChungTuNganHangList()
        { /* require use of factory method */ }

        public static ChungTuNganHangList NewChungTuNganHangList()
        {
            return new ChungTuNganHangList();
        }

        public static ChungTuNganHangList GetChungTuNganHangList(DateTime TuNgay, DateTime DenNgay, int LoaiChungTu)
        {
            return DataPortal.Fetch<ChungTuNganHangList>(new FilterCriteria(TuNgay, DenNgay, LoaiChungTu));
        }

        public static ChungTuNganHangList GetChungTuNganHangList(DateTime TuNgay, DateTime DenNgay, int LoaiChungTu, long MaDoiTac)
        {
            return DataPortal.Fetch<ChungTuNganHangList>(new FilterCriteria_ByDoiTac(TuNgay, DenNgay, LoaiChungTu, MaDoiTac));
        }

        public static ChungTuNganHangList GetChungTuNganHangList_HDDV(DateTime TuNgay, DateTime DenNgay, int LoaiChungTu)
        {
            return DataPortal.Fetch<ChungTuNganHangList>(new FilterCriteria_HDDV(TuNgay, DenNgay, LoaiChungTu));
        }

        public static ChungTuNganHangList GetChungTuNganHangListByLoai(int maBP)
        {
            return DataPortal.Fetch<ChungTuNganHangList>(new FilterCriteriaByLoai(maBP));
        }

        public static ChungTuNganHangList GetChungTuNganHangList(DateTime tuNgay, DateTime denNgay)
        {
            return DataPortal.Fetch<ChungTuNganHangList>(new FilterCriteriaByUser(tuNgay, denNgay));
        }

        public static ChungTuNganHangList GetChungTuNganHangListByChungTu(long soChungTu)
        {
            return DataPortal.Fetch<ChungTuNganHangList>(new FilterCriteriaByChungTu(soChungTu));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public DateTime TuNgay, DenNgay;
            public int LoaiChungTu;
            public FilterCriteria(DateTime tuNgay, DateTime denNgay, int loaiChungTu)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
                LoaiChungTu = loaiChungTu;
            }
        }

        private class FilterCriteria_ByDoiTac
        {
            public DateTime TuNgay, DenNgay;
            public int LoaiChungTu;
            public long MaDoiTac;
            public FilterCriteria_ByDoiTac(DateTime tuNgay, DateTime denNgay, int loaiChungTu, long maDoiTac)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
                LoaiChungTu = loaiChungTu;
                MaDoiTac = maDoiTac;
            }
        }

        private class FilterCriteria_HDDV
        {
            public DateTime TuNgay, DenNgay;
            public int LoaiChungTu;
            public FilterCriteria_HDDV(DateTime tuNgay, DateTime denNgay, int loaiChungTu)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
                LoaiChungTu = loaiChungTu;
            }
        }

        private class FilterCriteriaByLoai
        {
            public int MaBoPhan;
            public FilterCriteriaByLoai(int maBP)
            {
                MaBoPhan = maBP;
            }
        }

        private class FilterCriteriaByUser
        {
            public DateTime TuNgay, DenNgay;
            public FilterCriteriaByUser(DateTime tuNgay, DateTime denNgay)
            {
                TuNgay = tuNgay;
                DenNgay = denNgay;
            }
        }
        private class FilterCriteriaByChungTu
        {
            public long SoChungTu;
            public FilterCriteriaByChungTu(long soChungTu)
            {
                SoChungTu = soChungTu;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
           
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                cm.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    cm.CommandText = "spd_Select_ChungTuNganHangList";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@LoaiChungTu", ((FilterCriteria)criteria).LoaiChungTu);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTuNganHang.GetChungTuNganHang(dr));
                    }
                }
                if (criteria is FilterCriteria_ByDoiTac)
                {
                    cm.CommandText = "spd_Select_ChungTuNganHangList_ByDoiTac";
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteria_ByDoiTac)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteria_ByDoiTac)criteria).DenNgay);
                    cm.Parameters.AddWithValue("@LoaiChungTu", ((FilterCriteria_ByDoiTac)criteria).LoaiChungTu);
                    cm.Parameters.AddWithValue("@MaDoiTac", ((FilterCriteria_ByDoiTac)criteria).MaDoiTac);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTuNganHang.GetChungTuNganHang_ByDoiTac(dr));
                    }
                }
                else if (criteria is FilterCriteriaByLoai)
                {
                    cm.CommandText = "spd_Select_ChungTuNganHangListByLoai";
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByLoai)criteria).MaBoPhan);
                    
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTuNganHang.GetChungTuNganHang(dr));
                    }
                   
                }

                else if (criteria is FilterCriteriaByUser)
                {
                    cm.CommandText = "spd_SelectChungTuNganHangListByUser";
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TuNgay", ((FilterCriteriaByUser)criteria).TuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", ((FilterCriteriaByUser)criteria).DenNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTuNganHang.GetChungTuNganHang(dr));
                    }

                }
                else if (criteria is FilterCriteriaByChungTu)
                {
                    cm.CommandText = "spd_Select_ChungTuNganHangListByChungTu";
                    cm.Parameters.AddWithValue("@SoChungTu", ((FilterCriteriaByChungTu)criteria).SoChungTu);

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChungTuNganHang.GetChungTuNganHang(dr));
                    }
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
                    foreach (ChungTuNganHang deletedChild in DeletedList)
                        deletedChild.DeleteSelf(tr);
                    DeletedList.Clear();

                    // loop through each non-deleted child object
                    foreach (ChungTuNganHang child in this)
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
        // them
        public void DataPortal_Update(SqlTransaction tr)
        {
            RaiseListChangedEvents = false;
            try
            {
                foreach (ChungTuNganHang child in this)
                {
                    if (!child.IsNew)
                        child.Update(tr);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            RaiseListChangedEvents = true;
        }

        #endregion //Data Access - Update
        #endregion //Data Access
        string thongbao;
         public  String  KiemTraChuyenKhoan(string MaDeNghiChuyenKhoan, DateTime NgayLap)
        {
            string kq;
             SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = new SqlConnection(ERP_Library.Database.ERP_Connection);
            command.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            DataSet dataSet = new DataSet();
            command.CommandText = "spd_KiemTraKhoaKyLuongChuyenKhoan";
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Parameters.AddWithValue("@NgayLap", NgayLap);
            command.Parameters.AddWithValue("@MaCongTy", ERP_Library.Security.CurrentUser.Info.MaCongTy);
            command.Parameters.AddWithValue("@MaDeNghi", MaDeNghiChuyenKhoan);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataSet.Tables.Add(table);
            thongbao = string.Empty;

            foreach (DataRow  data in table.Rows)
            {
                thongbao += data["ThongBao"] + ",";
            
            }
            kq = thongbao;
            return thongbao;

           
        }
    }
}
