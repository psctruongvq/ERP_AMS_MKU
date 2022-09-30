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
    public class InChiTietThueTNCN2_TongHopList : ReadOnlyListBase<InChiTietThueTNCN2_TongHopList, InChiTietThueTNCN2_TongHopChild>
    {
        private InChiTietThueTNCN2_TongHopList()
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
                command.CommandText = "spd_Report_InChiTietThueTNCN_NhanVien";
                command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                command.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                command.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    while (reader.Read())
                    {
                        using (SqlConnection connection = new SqlConnection(Database.ERP_Connection))
                        {
                            connection.Open();
                            using (SqlCommand command2 = connection.CreateCommand())
                            {
                                command2.CommandType = CommandType.StoredProcedure;
                                command2.CommandTimeout = 0;

                                command2.CommandText = "spd_Report_ChiTietQuyetToanThueTNCN2";
                                command2.Parameters.AddWithValue("@Nam", criteria.Nam);
                                command2.Parameters.AddWithValue("@Ky3_12", criteria.Ky3_12);
                                command2.Parameters.AddWithValue("@MaNhanVien", reader.GetInt64("MaNhanVien"));
                                using (SafeDataReader reader2 = new SafeDataReader(command2.ExecuteReader()))
                                {
                                    while (reader2.Read())
                                    {
                                        base.Add(InChiTietThueTNCN2_TongHopChild.GetInChiTietThueTNCN2_TongHopChild(reader2, reader.GetInt64("MaNhanVien"), reader.GetString("TenNhanVien"), reader.GetString("TenBoPhan"), reader.GetString("MaSoThue")));
                                    }
                                }
                            }
                            connection.Close();
                        }
                    }
                }
            }
        }

        public static InChiTietThueTNCN2_TongHopList GetInChiTietThueTNCN2_TongHopList(int Nam, int MaBoPhan, long MaNhanVien, bool Ky3_12)
        {
            return DataPortal.Fetch<InChiTietThueTNCN2_TongHopList>(new FilterCriteria(Nam, MaBoPhan, MaNhanVien, Ky3_12));
        }

        [Serializable]
        private class FilterCriteria
        {
            public bool Ky3_12;
            public int MaBoPhan;
            public long MaNhanVien;
            public int Nam;

            public FilterCriteria(int nam, int maBoPhan, long maNhanVien, bool ky3_12)
            {
                this.Nam = nam;
                this.MaBoPhan = maBoPhan;
                this.MaNhanVien = maNhanVien;
                this.Ky3_12 = ky3_12;
            }
        }
    }
}

