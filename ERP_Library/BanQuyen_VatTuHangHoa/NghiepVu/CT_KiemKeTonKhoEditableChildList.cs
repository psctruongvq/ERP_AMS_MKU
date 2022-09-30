
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_KiemKeTonKhoList : Csla.BusinessListBase<CT_KiemKeTonKhoList, CT_KiemKeTonKho>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_KiemKeTonKho item = CT_KiemKeTonKho.NewCT_KiemKeTonKho();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CT_KiemKeTonKhoList NewCT_KiemKeTonKhoList()
        {
            return new CT_KiemKeTonKhoList();
        }

        internal static CT_KiemKeTonKhoList GetCT_KiemKeTonKhoList(SafeDataReader dr)
        {
            return new CT_KiemKeTonKhoList(dr);
        }

        internal static CT_KiemKeTonKhoList GetCT_KiemKeTonKhoList(long maKiemKe)
        {
            return DataPortal.Fetch<CT_KiemKeTonKhoList>(new Criteria(maKiemKe));
        }

        public static CT_KiemKeTonKhoList GetCT_KiemKeTonKhoList(int maKho, int maKy)
        {
            return DataPortal.Fetch<CT_KiemKeTonKhoList>(new CriteriaByNew(maKho, maKy));
        }

        private CT_KiemKeTonKhoList()
        {
            MarkAsChild();
        }

        private CT_KiemKeTonKhoList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        private class CriteriaByNew
        {

            public int MaKho;
            public int MaKy;
            public CriteriaByNew(int maKho, int maKy)
            {
                this.MaKho = maKho;
                this.MaKy = maKy;
            }
        }

        private class Criteria
        {
            public long MaKiemKe;
            public Criteria(long maKiemKe)
            {
                this.MaKiemKe = maKiemKe;
            }
        }



            private void DataPortal_Fetch(Object criteria)
            {
                RaiseListChangedEvents = false;

                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();

                    ExecuteFetch(cn, criteria);
                }//using

                RaiseListChangedEvents = true;
            }


            private void ExecuteFetch(SqlConnection cn, Object criteria)
            {
               
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        if (criteria is CriteriaByNew)
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_SelecttblCT_KiemKeTonKhosByMaKiemKe";
                            cm.Parameters.AddWithValue("@MaKiemKe", ((CriteriaByNew)criteria).MaKho);
                            cm.Parameters.AddWithValue("@MaKho", ((CriteriaByNew)criteria).MaKho);
                            cm.Parameters.AddWithValue("@MaKy", ((CriteriaByNew)criteria).MaKy);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                    this.Add(CT_KiemKeTonKho.GetCT_KiemKeTonKho(dr, false));
                            }
                        }
                        else if (criteria is Criteria)
                        {
                            cm.CommandType = CommandType.StoredProcedure;
                            cm.CommandText = "spd_SelecttblCT_KiemKeTonKhosByAndMaKiemKe";
                            cm.Parameters.AddWithValue("@MaKiemKe", ((Criteria)criteria).MaKiemKe);
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                    this.Add(CT_KiemKeTonKho.GetCT_KiemKeTonKho(dr, true));
                            }
                        }
                    }
                              
            }



            private void Fetch(SafeDataReader dr)
            {
                RaiseListChangedEvents = false;

                while (dr.Read())
                    this.Add(CT_KiemKeTonKho.GetCT_KiemKeTonKho(dr, true));

                RaiseListChangedEvents = true;
            }

            internal void Update(SqlTransaction tr, KiemKeTonKho parent)
            {
                RaiseListChangedEvents = false;

                // loop through each deleted child object
                foreach (CT_KiemKeTonKho deletedChild in DeletedList)
                    deletedChild.DeleteSelf(tr);
                DeletedList.Clear();

                // loop through each non-deleted child object
                foreach (CT_KiemKeTonKho child in this)
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
