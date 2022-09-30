
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopChamNgoaiGioList : Csla.ReadOnlyListBase<TongHopChamNgoaiGioList, TongHopChamNgoaiGioChild>
    {
        private int _SoCot = 0;
        public int SoCot
        {
            get
            {
                return _SoCot;
            }
        }
                     
        #region Factory Methods
        private TongHopChamNgoaiGioList()
        { /* require use of factory method */ }

        public static TongHopChamNgoaiGioList GetTongHopChamNgoaiGioList(int TuKy, int DenKy, int MaBoPhan,bool TheoKyChamCong,bool Duyet)
        {
            return DataPortal.Fetch<TongHopChamNgoaiGioList>(new FilterCriteria(TuKy, DenKy, MaBoPhan,TheoKyChamCong, Duyet));
        }

        public static TongHopChamNgoaiGioList GetTongHopChamNgoaiGio200GioList(int TuKy, int DenKy, int MaBoPhan, bool TheoKyChamCong, bool Duyet)
        {
            return DataPortal.Fetch<TongHopChamNgoaiGioList>(new FilterCriteria200Gio(TuKy, DenKy, MaBoPhan, TheoKyChamCong, Duyet));
        }

        public static TongHopChamNgoaiGioList GetTongHopChamNgoaiGioLonHon200List(int TuKy, int DenKy, int MaBoPhan, bool TheoKyChamCong, bool Duyet)
        {
            return DataPortal.Fetch<TongHopChamNgoaiGioList>(new FilterCriteriaLonHon200Gio(TuKy, DenKy, MaBoPhan, TheoKyChamCong, Duyet));
        }
        #endregion //Factory Methods

        #region Data Access

        #region Filter Criteria
        [Serializable()]
        private class FilterCriteria
        {
            public int TuKy, DenKy, MaBoPhan;
            public bool TheoKyChamCong;
            public bool Duyet;
            public FilterCriteria(int tuKy, int denKy, int maBoPhan,bool theoKyChamCong, bool duyet)
            {
                TuKy = tuKy;
                DenKy = denKy;
                MaBoPhan = maBoPhan;
                TheoKyChamCong = theoKyChamCong;
                Duyet = duyet;
            }
        }


        private class FilterCriteria200Gio
        {
            public int TuKy, DenKy, MaBoPhan;
            public bool TheoKyChamCong;
            public bool Duyet;
            public FilterCriteria200Gio(int tuKy, int denKy, int maBoPhan, bool theoKyChamCong, bool duyet)
            {
                TuKy = tuKy;
                DenKy = denKy;
                MaBoPhan = maBoPhan;
                TheoKyChamCong = theoKyChamCong;
                Duyet = duyet;
            }
        }

        private class FilterCriteriaLonHon200Gio
        {
            public int TuKy, DenKy, MaBoPhan;
            public bool TheoKyChamCong;
            public bool Duyet;
            public FilterCriteriaLonHon200Gio(int tuKy, int denKy, int maBoPhan, bool theoKyChamCong, bool duyet)
            {
                TuKy = tuKy;
                DenKy = denKy;
                MaBoPhan = maBoPhan;
                TheoKyChamCong = theoKyChamCong;
                Duyet = duyet;
            }
        }

        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(Object criteria)
        {
            RaiseListChangedEvents = false;
            IsReadOnly = false;

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

            IsReadOnly = true;
            RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, object criteria)
        {
            using (SqlCommand cm = tr.Connection.CreateCommand())
            {
                cm.Transaction = tr;
                if (criteria is FilterCriteria)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_TongHopChamNgoaiGio";
                    cm.Parameters.AddWithValue("@TuKy", ((FilterCriteria)criteria).TuKy);
                    cm.Parameters.AddWithValue("@DenKy", ((FilterCriteria)criteria).DenKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@TheoKyChamCong", ((FilterCriteria)criteria).TheoKyChamCong);
                    cm.Parameters.AddWithValue("@Duyet", ((FilterCriteria)criteria).Duyet);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }
                else if (criteria is FilterCriteria200Gio)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_TongHopChamNgoaiGioTrong200Gio";
                    cm.Parameters.AddWithValue("@TuKy", ((FilterCriteria200Gio)criteria).TuKy);
                    cm.Parameters.AddWithValue("@DenKy", ((FilterCriteria200Gio)criteria).DenKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria200Gio)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@TheoKyChamCong", ((FilterCriteria200Gio)criteria).TheoKyChamCong);
                    cm.Parameters.AddWithValue("@Duyet", ((FilterCriteria200Gio)criteria).Duyet);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }

                else if (criteria is FilterCriteriaLonHon200Gio)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "[spd_Report_TongHopChamNgoaiGioLonhon200Gio]";
                    cm.Parameters.AddWithValue("@TuKy", ((FilterCriteriaLonHon200Gio)criteria).TuKy);
                    cm.Parameters.AddWithValue("@DenKy", ((FilterCriteriaLonHon200Gio)criteria).DenKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaLonHon200Gio)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@TheoKyChamCong", ((FilterCriteriaLonHon200Gio)criteria).TheoKyChamCong);
                    cm.Parameters.AddWithValue("@Duyet", ((FilterCriteriaLonHon200Gio)criteria).Duyet);
                    cm.Parameters.AddWithValue("@UserID", ERP_Library.Security.CurrentUser.Info.UserID);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                 
                }
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TongHopChamNgoaiGioChild.GetTongHopChamNgoaiGioChild(dr));
                }
                _SoCot = Convert.ToInt32(cm.Parameters["@SoCot"].Value);
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
