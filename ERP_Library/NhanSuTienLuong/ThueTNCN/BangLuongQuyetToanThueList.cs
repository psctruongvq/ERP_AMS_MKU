namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using ERP_Library.Security;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class BangLuongQuyetToanThueList : ReadOnlyListBase<BangLuongQuyetToanThueList, BangLuongQuyetToanThueChild>
    {
        private BangLuongQuyetToanThueList()
        {
        }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            base.RaiseListChangedEvents = false;
            base.IsReadOnly = false;
            using (SqlConnection connection = new SqlConnection(Database.ERP_Connection))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                try
                {
                    this.ExecuteFetch(tr, criteria);
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
            base.IsReadOnly = true;
            base.RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandTimeout = 0;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Report_BangLuongQuyetToanThue";
                command.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                command.Parameters.AddWithValue("@Loai", criteria.Loai);
                command.Parameters.AddWithValue("@Nam", criteria.Nam);
                command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    while (reader.Read())
                    {
                        base.Add(BangLuongQuyetToanThueChild.GetBangLuongQuyetToanThueChild(reader));
                    }
                }
            }
        }

        public static BangLuongQuyetToanThueList GetBangLuongQuyetToanThueList(long MaNhanVien, int Loai, int Nam)
        {
            return DataPortal.Fetch<BangLuongQuyetToanThueList>(new FilterCriteria(MaNhanVien, Loai, Nam));
        }

        [Serializable]
        private class FilterCriteria
        {
            public int Loai;
            public long MaNhanVien;
            public int Nam;

            public FilterCriteria(long maNhanVien, int loai, int nam)
            {
                this.MaNhanVien = maNhanVien;
                this.Loai = loai;
                this.Nam = nam;
            }
        }
    }
}

