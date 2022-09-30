namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using ERP_Library;
    using ERP_Library.Security;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class ChiTietThueTNCNKy3QuyetToanNamList : ReadOnlyListBase<ChiTietThueTNCNKy3QuyetToanNamList, ChiTietThueTNCNKy3QuyetToanNamChild>
    {
        private ChiTietThueTNCNKy3QuyetToanNamList()
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
                command.CommandType = CommandType.StoredProcedure;
                if (criteria.ChiTiet)
                {
                    command.CommandText = "spd_Report_ChiTietThueTNCNKy3QuyetToanNam";
                }
                else
                {
                    command.CommandText = "spd_Report_TongHopThueTNCNKy3QuyetToanNam";
                }
                command.Parameters.AddWithValue("@Nam", criteria.Nam);
                command.Parameters.AddWithValue("@TuQuyetToan", criteria.TuQuyetToan);
                command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    while (reader.Read())
                    {
                        base.Add(ChiTietThueTNCNKy3QuyetToanNamChild.GetChiTietThueTNCNKy3QuyetToanNamChild(reader));
                    }
                }
            }
        }

        public static ChiTietThueTNCNKy3QuyetToanNamList GetChiTietThueTNCNKy3QuyetToanNamList(int Nam, bool TuQuyetToan)
        {
            return DataPortal.Fetch<ChiTietThueTNCNKy3QuyetToanNamList>(new FilterCriteria(Nam, TuQuyetToan, true));
        }

        public static ChiTietThueTNCNKy3QuyetToanNamList GetTongHopThueTNCNKy3QuyetToanNamList(int Nam, bool TuQuyetToan)
        {
            return DataPortal.Fetch<ChiTietThueTNCNKy3QuyetToanNamList>(new FilterCriteria(Nam, TuQuyetToan, false));
        }

        [Serializable]
        private class FilterCriteria
        {
            public bool ChiTiet;
            public int Nam;
            public bool TuQuyetToan;

            public FilterCriteria(int nam, bool tuQuyetToan, bool chiTiet)
            {
                this.Nam = nam;
                this.TuQuyetToan = tuQuyetToan;
                this.ChiTiet = chiTiet;
            }
        }
    }
}

