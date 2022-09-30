
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Report
{
    [Serializable()]
    public class TongHopChamNgoaiGioBoPhanList : Csla.ReadOnlyListBase<TongHopChamNgoaiGioBoPhanList, TongHopChamNgoaiGioBoPhanChild>
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
        private TongHopChamNgoaiGioBoPhanList()
        { /* require use of factory method */ }

        public static TongHopChamNgoaiGioBoPhanList GetTongHopChamNgoaiGioBoPhanList(int tuKy, int denKy, int maBoPhan,bool TheoKyChamCong,bool Duyet )
        {
            return DataPortal.Fetch<TongHopChamNgoaiGioBoPhanList>(new FilterCriteria(tuKy, denKy, maBoPhan,TheoKyChamCong, Duyet));
        }

        public static TongHopChamNgoaiGioBoPhanList GetTongHopChamNgoaiGioBoPhanTrong200GioList(int tuKy, int denKy, int maBoPhan, bool TheoKyChamCong, bool Duyet)
        {
            return DataPortal.Fetch<TongHopChamNgoaiGioBoPhanList>(new FilterCriteriaTongTrong200Gio(tuKy, denKy, maBoPhan, TheoKyChamCong, Duyet));
        }


        public static TongHopChamNgoaiGioBoPhanList GetTongHopChamNgoaiGioBoPhanLonHon200GioList(int tuKy, int denKy, int maBoPhan, bool TheoKyChamCong, bool Duyet)
        {
            return DataPortal.Fetch<TongHopChamNgoaiGioBoPhanList>(new FilterCriteriaTongLonHon200Gio(tuKy, denKy, maBoPhan, TheoKyChamCong, Duyet));
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

            public FilterCriteria(int tuKy, int denKy, int maBoPhan, bool theoKyChamCong, bool duyet)
            {
                TuKy = tuKy;
                DenKy = denKy;
                this.MaBoPhan = maBoPhan;
                TheoKyChamCong = theoKyChamCong;
                Duyet = duyet;
            }
        }

        private class FilterCriteriaTongTrong200Gio
        {
            public int TuKy, DenKy, MaBoPhan;
            public bool TheoKyChamCong;
            public bool Duyet;

            public FilterCriteriaTongTrong200Gio(int tuKy, int denKy, int maBoPhan, bool theoKyChamCong, bool duyet)
            {
                TuKy = tuKy;
                DenKy = denKy;
                this.MaBoPhan = maBoPhan;
                TheoKyChamCong = theoKyChamCong;
                Duyet = duyet;
            }
        }


        private class FilterCriteriaTongLonHon200Gio
        {
            public int TuKy, DenKy, MaBoPhan;
            public bool TheoKyChamCong;
            public bool Duyet;

            public FilterCriteriaTongLonHon200Gio(int tuKy, int denKy, int maBoPhan, bool theoKyChamCong, bool duyet)
            {
                TuKy = tuKy;
                DenKy = denKy;
                this.MaBoPhan = maBoPhan;
                TheoKyChamCong = theoKyChamCong;
                Duyet = duyet;
            }
        }
        #endregion //Filter Criteria

        #region Data Access - Fetch
        private void DataPortal_Fetch(object criteria)
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
                    cm.CommandText = "spd_Report_TongHopChamNgoaiGioBoPhan";
                    cm.Parameters.AddWithValue("@TuKy", ((FilterCriteria)criteria).TuKy);
                    cm.Parameters.AddWithValue("@DenKy", ((FilterCriteria)criteria).DenKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteria)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TheoKyChamCong", ((FilterCriteria)criteria).TheoKyChamCong);
                    cm.Parameters.AddWithValue("@Duyet", ((FilterCriteria)criteria).Duyet);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }
                else if (criteria is FilterCriteriaTongTrong200Gio)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_TongHopChamNgoaiGioBoPhanTrong200Gio";
                    cm.Parameters.AddWithValue("@TuKy", ((FilterCriteriaTongTrong200Gio)criteria).TuKy);
                    cm.Parameters.AddWithValue("@DenKy", ((FilterCriteriaTongTrong200Gio)criteria).DenKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaTongTrong200Gio)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TheoKyChamCong", ((FilterCriteriaTongTrong200Gio)criteria).TheoKyChamCong);
                    cm.Parameters.AddWithValue("@Duyet", ((FilterCriteriaTongTrong200Gio)criteria).Duyet);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }
                else if (criteria is FilterCriteriaTongLonHon200Gio)
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Report_TongHopChamNgoaiGioBoPhanLonHon200Gio";
                    cm.Parameters.AddWithValue("@TuKy", ((FilterCriteriaTongLonHon200Gio)criteria).TuKy);
                    cm.Parameters.AddWithValue("@DenKy", ((FilterCriteriaTongLonHon200Gio)criteria).DenKy);
                    cm.Parameters.AddWithValue("@MaBoPhan", ((FilterCriteriaTongLonHon200Gio)criteria).MaBoPhan);
                    cm.Parameters.AddWithValue("@UserID", Security.CurrentUser.Info.UserID);
                    cm.Parameters.AddWithValue("@TheoKyChamCong", ((FilterCriteriaTongLonHon200Gio)criteria).TheoKyChamCong);
                    cm.Parameters.AddWithValue("@Duyet", ((FilterCriteriaTongLonHon200Gio)criteria).Duyet);
                    cm.Parameters.Add("@SoCot", SqlDbType.Int);
                    cm.Parameters["@SoCot"].Direction = ParameterDirection.Output;
                }

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(TongHopChamNgoaiGioBoPhanChild.GetTongHopChamNgoaiGioBoPhanChild(dr));
                }
                _SoCot = Convert.ToInt32(cm.Parameters["@SoCot"].Value);
            }//using
        }
        #endregion //Data Access - Fetch
        #endregion //Data Access
    }
}
