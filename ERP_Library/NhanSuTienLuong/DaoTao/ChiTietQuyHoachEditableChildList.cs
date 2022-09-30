using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietQuyHoachList : Csla.BusinessListBase<ChiTietQuyHoachList, ChiTietQuyHoach>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietQuyHoach item = ChiTietQuyHoach.NewChiTietQuyHoach();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static ChiTietQuyHoachList NewChiTietQuyHoachList()
        {
            return new ChiTietQuyHoachList();
        }

        public static ChiTietQuyHoachList GetChiTietQuyHoachList(int maQuyHoach)
        {
            return new ChiTietQuyHoachList(maQuyHoach);
        }

        public static ChiTietQuyHoachList GetChiTietQuyHoachListbySearch(int nam, bool search)
        {
            return new ChiTietQuyHoachList(nam,search);
        }

        private ChiTietQuyHoachList()
        {
            MarkAsChild();
        }

        private ChiTietQuyHoachList(int maQuyHoach)
        {
            MarkAsChild();
            Fetch(maQuyHoach);
        }

        private ChiTietQuyHoachList(int maQuyHoach,bool search)
        {
            MarkAsChild();
            FetchbySearch(maQuyHoach);
        }
        #endregion //Factory Methods


        #region Data Access
        

        private void Fetch(int maQuyHoach)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsCTQuyHoachList";
                    cm.Parameters.AddWithValue("@MaQuyHoach", maQuyHoach);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChiTietQuyHoach.GetChiTietQuyHoach(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        private void FetchbySearch(int nam)//BoSung
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsCTQuyHoachListbySearch";
                    cm.Parameters.AddWithValue("@Nam", nam);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChiTietQuyHoach.GetChiTietQuyHoach(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }


        internal void Update(SqlTransaction tr, QuyHoach parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietQuyHoach deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietQuyHoach child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}
