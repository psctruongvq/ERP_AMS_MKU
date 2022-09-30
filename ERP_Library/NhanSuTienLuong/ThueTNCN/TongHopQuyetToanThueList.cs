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
    public class TongHopQuyetToanThueList : ReadOnlyListBase<TongHopQuyetToanThueList, TongHopQuyetToanThueChild>
    {
        private TongHopQuyetToanThueList()
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
                command.CommandText = "spd_Report_TongHopQuyetToanThueTNCN";
                command.Parameters.AddWithValue("@Nam", criteria.Nam);
                command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                command.Parameters.AddWithValue("@TuQuyetToan", criteria.TuQuyetToan);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    while (reader.Read())
                    {
                        base.Add(TongHopQuyetToanThueChild.GetTongHopQuyetToanThueChild(reader));
                    }
                }
            }
        }

        public static TongHopQuyetToanThueList GetTongHopQuyetToanThueList(int Nam, bool TuQuyetToan)
        {
            return DataPortal.Fetch<TongHopQuyetToanThueList>(new FilterCriteria(Nam, TuQuyetToan));
        }

        [Serializable]
        private class FilterCriteria
        {
            public int Nam;
            public bool TuQuyetToan;

            public FilterCriteria(int nam, bool tuQuyetToan)
            {
                this.Nam = nam;
                this.TuQuyetToan = tuQuyetToan;
            }
        }
    }
}

