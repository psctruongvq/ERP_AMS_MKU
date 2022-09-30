namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using ERP_Library.Security;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class BangKeThueTNCNList : BusinessListBase<BangKeThueTNCNList, BangKeThueTNCNChild>
    {
        private BangKeThueTNCNList()
        {
        }

        private void DataPortal_Fetch(object criteria)
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
                    foreach (BangKeThueTNCNChild child in base.DeletedList)
                    {
                        child.DeleteSelf(tr);
                    }
                    base.DeletedList.Clear();
                    foreach (BangKeThueTNCNChild child2 in this)
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

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                if (criteria is FilterCriteria)
                {
                    command.CommandText = "spd_Report_BangKeThueTNCN";
                    command.Parameters.AddWithValue("@Nam", ((FilterCriteria)criteria).Nam);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    command.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteria)criteria).MaNhanVien);
                    command.Parameters.AddWithValue("@TuQuyetToan", ((FilterCriteria)criteria).TuQuyetToan);
                }
                else if (criteria is FilterCriteriaByNghiViec)
                {
                    command.CommandText = "[spd_Report_BangKeThueTNCNN_NghiViec]";
                    command.Parameters.AddWithValue("@Nam", ((FilterCriteriaByNghiViec)criteria).Nam);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaByNghiViec)criteria).MaBoPhan);
                    command.Parameters.AddWithValue("@MaNhanVien", ((FilterCriteriaByNghiViec)criteria).MaNhanVien);
                    command.Parameters.AddWithValue("@TuQuyetToan", ((FilterCriteriaByNghiViec)criteria).TuQuyetToan);
                }
                else if (criteria is FilterCriteriaNam2013)
                {
                    command.CommandText = "[spd_Report_ChiTietQuyetToanThueLuyTien]";
                    command.Parameters.AddWithValue("@Nam", ((FilterCriteriaNam2013)criteria).Nam);
                    command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    command.Parameters.AddWithValue("@TuQuyetToan", ((FilterCriteriaNam2013)criteria).TuQuyetToan);
                    using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        while (reader.Read())
                        {
                            base.Add(BangKeThueTNCNChild.GetBangKeThueTNCNChild2013(reader));
                        }
                    }
                    return;
                }
             
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    while (reader.Read())
                    {
                        base.Add(BangKeThueTNCNChild.GetBangKeThueTNCNChild(reader));
                    }
                }
            }
        }

        public static BangKeThueTNCNList GetBangKeThueTNCNList(int Nam, int MaBoPhan, long MaNhanVien, bool TuQuyetToan)
        {
            return DataPortal.Fetch<BangKeThueTNCNList>(new FilterCriteria(Nam, MaBoPhan, MaNhanVien, TuQuyetToan));
        }
        public static BangKeThueTNCNList GetBangKeThueTNCNList2013(int Nam, int UsreID, bool TuQuyetToan)
        {
            return DataPortal.Fetch<BangKeThueTNCNList>(new FilterCriteriaNam2013(Nam, UsreID,TuQuyetToan));
        }

        public static BangKeThueTNCNList GetBangKeThueTNCNListByNghiViec(int Nam, int MaBoPhan, long MaNhanVien, bool TuQuyetToan)
        {
            return DataPortal.Fetch<BangKeThueTNCNList>(new FilterCriteriaByNghiViec(Nam, MaBoPhan, MaNhanVien, TuQuyetToan));
        }

        public static BangKeThueTNCNList NewBangKeThueTNCNList()
        {
            return new BangKeThueTNCNList();
        }

        public void XuLyThueTNCN(int Nam, int DenKy,int MaBoPhan, long MaNhanVien)
        {
            SqlConnection connection = new SqlConnection(Database.ERP_Connection);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandTimeout = 0;
            command.CommandText = "spd_XuLyQuyetToanThueTNCNLong";
            command.Parameters.AddWithValue("@Nam", Nam);
            command.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
            command.Parameters.AddWithValue("@DenKy", DenKy);
            command.Parameters.AddWithValue("@MaBoPhanTinh", MaBoPhan);
            command.Parameters.AddWithValue("@MaNhanVien", MaNhanVien);
            command.ExecuteNonQuery();
            connection.Close();
        }

        [Serializable]
        private class FilterCriteria
        {
            public int MaBoPhan;
            public long MaNhanVien;
            public int Nam;
            public bool TuQuyetToan;

            public FilterCriteria(int nam, int maBoPhan, long maNhanVien, bool tuQuyetToan)
            {
                this.Nam = nam;
                this.MaBoPhan = maBoPhan;
                this.MaNhanVien = maNhanVien;
                this.TuQuyetToan = tuQuyetToan;
            }
        }

        [Serializable]
        private class FilterCriteriaNam2013
        {
            public int UserID;
            public int Nam;
            public bool TuQuyetToan;

            public FilterCriteriaNam2013(int nam, int userID, bool tuQuyetToan)
            {
                this.Nam = nam;
                this.UserID = userID;
                this.TuQuyetToan = tuQuyetToan;
            }
        }

        [Serializable]
        private class FilterCriteriaByNghiViec
        {
            public int MaBoPhan;
            public long MaNhanVien;
            public int Nam;
            public bool TuQuyetToan;

            public FilterCriteriaByNghiViec(int nam, int maBoPhan, long maNhanVien, bool tuQuyetToan)
            {
                this.Nam = nam;
                this.MaBoPhan = maBoPhan;
                this.MaNhanVien = maNhanVien;
                this.TuQuyetToan = tuQuyetToan;
            }
        }
    }
}

