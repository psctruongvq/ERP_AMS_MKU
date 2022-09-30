namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class DieuChinhQuyetToanThueList : BusinessListBase<DieuChinhQuyetToanThueList, DieuChinhQuyetToanThueChild>
    {
        private DieuChinhQuyetToanThueList()
        {
        }

        protected override object AddNewCore()
        {
            DieuChinhQuyetToanThueChild item = DieuChinhQuyetToanThueChild.NewDieuChinhQuyetToanThueChild();
            base.Add(item);
            return item;
        }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            base.RaiseListChangedEvents = false;
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
            base.RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Update()
        {
            base.RaiseListChangedEvents = false;
            using (SqlConnection connection = new SqlConnection(Database.ERP_Connection))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                try
                {
                    foreach (DieuChinhQuyetToanThueChild child in base.DeletedList)
                    {
                        child.DeleteSelf(tr);
                    }
                    base.DeletedList.Clear();
                    foreach (DieuChinhQuyetToanThueChild child2 in this)
                    {
                        if (child2.IsNew)
                        {
                            child2.Insert(tr);
                        }
                        else
                        {
                            child2.Update(tr);
                        }
                    }
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
            base.RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Select_DieuChinhQuyetToanThueList";
                command.Parameters.AddWithValue("@MaNhanVien", criteria.MaNhanVien);
                command.Parameters.AddWithValue("@Loai", criteria.Loai);
                command.Parameters.AddWithValue("@Nam", criteria.Nam);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    while (reader.Read())
                    {
                        base.Add(DieuChinhQuyetToanThueChild.GetDieuChinhQuyetToanThueChild(reader));
                    }
                }
            }
        }

        public static DieuChinhQuyetToanThueList GetDieuChinhQuyetToanThueList(long MaNhanVien, int Loai, int Nam)
        {
            return DataPortal.Fetch<DieuChinhQuyetToanThueList>(new FilterCriteria(MaNhanVien, Loai, Nam));
        }

        public static DieuChinhQuyetToanThueList NewDieuChinhQuyetToanThueList()
        {
            return new DieuChinhQuyetToanThueList();
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

