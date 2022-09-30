namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using ERP_Library;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class InChiTietThueTNCN_ChiTietList : ReadOnlyListBase<InChiTietThueTNCN_ChiTietList, InChiTietThueTNCN_ChiTietChild>
    {
        private InChiTietThueTNCN_ChiTietList()
        {
        }

        public InChiTietThueTNCN_ChiTietList(SafeDataReader dr)
        {
            this.Fetch(dr);
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
                command.CommandText = "GetInChiTietThueTNCN_ChiTietList";
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    while (reader.Read())
                    {
                        base.Add(InChiTietThueTNCN_ChiTietChild.GetInChiTietThueTNCN_ChiTietChild(reader));
                    }
                }
            }
        }

        internal void Fetch(SafeDataReader dr)
        {
            base.RaiseListChangedEvents = false;
            base.IsReadOnly = false;
            while (dr.Read())
            {
                base.Add(InChiTietThueTNCN_ChiTietChild.GetInChiTietThueTNCN_ChiTietChild(dr));
            }
            base.IsReadOnly = true;
            base.RaiseListChangedEvents = true;
        }

        [Serializable]
        private class FilterCriteria
        {
        }
    }
}

