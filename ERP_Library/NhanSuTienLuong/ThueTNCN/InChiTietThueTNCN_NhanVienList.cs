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
    public class InChiTietThueTNCN_NhanVienList : ReadOnlyListBase<InChiTietThueTNCN_NhanVienList, InChiTietThueTNCN_NhanVienChild>
    {
        private InChiTietThueTNCN_NhanVienList()
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
                command.CommandTimeout = 0;
                command.CommandText = "spd_Report_InChiTietThueTNCN_NhanVien";
                command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                command.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);
                command.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                command.Parameters.AddWithValue("@Nam", criteria.Nam);
                command.Parameters.AddWithValue("@TuQuyetToan", criteria.TuQuyetToan);
               // command.Parameters.AddWithValue("@ThangDen", criteria.DenThang);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    while (reader.Read())
                    {
                        base.Add(InChiTietThueTNCN_NhanVienChild.GetInChiTietThueTNCN_NhanVienChild(reader, criteria.Nam, criteria.Ky3_12, criteria.TuQuyetToan, criteria.DenThang));
                    }
                }
            }
        }

        public static InChiTietThueTNCN_NhanVienList GetInChiTietThueTNCN_NhanVienList(long maNhanVien, int MaBoPhan, int Nam, bool Ky3_12, bool TuQuyetToan, int DenThang)
        {
            return DataPortal.Fetch<InChiTietThueTNCN_NhanVienList>(new FilterCriteria(maNhanVien, MaBoPhan, Nam, Ky3_12, TuQuyetToan, DenThang ));
        }

        [Serializable]
        private class FilterCriteria
        {
            public bool Ky3_12;
            public int MaBoPhan;
            public long MaNhanVien;
            public int Nam;
            public bool TuQuyetToan;
            public int DenThang;

            public FilterCriteria(long maNhanVien, int maBoPhan, int nam, bool ky3_12, bool tuQuyetToan, int denThang)
            {
                this.MaNhanVien = maNhanVien;
                this.MaBoPhan = maBoPhan;
                this.Nam = nam;
                this.Ky3_12 = ky3_12;
                this.TuQuyetToan = tuQuyetToan;
                this.DenThang = denThang;
            }
        }
    }
}

