
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_CongThucMauBieuBaoCaoList : Csla.BusinessListBase<CT_CongThucMauBieuBaoCaoList, CT_CongThucMauBieuBaoCao>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_CongThucMauBieuBaoCao item = CT_CongThucMauBieuBaoCao.NewCT_CongThucMauBieuBaoCao();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides
        #region Factory Methods
        public static CT_CongThucMauBieuBaoCaoList NewCT_CongThucMauBieuBaoCaoList()
        {
            return new CT_CongThucMauBieuBaoCaoList();
        }

        public static CT_CongThucMauBieuBaoCaoList GetCT_CongThucMauBieuBaoCaoList(int MaMuc)
        {
            return new CT_CongThucMauBieuBaoCaoList(MaMuc);
        }

        private CT_CongThucMauBieuBaoCaoList()
        {
            MarkAsChild();
        }

        private CT_CongThucMauBieuBaoCaoList(int MaMuc)
        {
            RaiseListChangedEvents = false;

            SqlTransaction tr;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();

                tr = cn.BeginTransaction();
                try
                {
                    using (SqlCommand cm = tr.Connection.CreateCommand())
                    {
                        cm.Transaction = tr;
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_SelecttblCT_CongThucMauBieuBaoCaoByMaMuc";
                        cm.Parameters.AddWithValue("@MaMuc", MaMuc);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(CT_CongThucMauBieuBaoCao.GetCT_CongThucMauBieuBaoCao(dr));
                        }
                    }//using
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }//using

            RaiseListChangedEvents = true;

        }
        #endregion //Factory Methods

        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(CT_CongThucMauBieuBaoCao.GetCT_CongThucMauBieuBaoCao(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, CongThucMauBieuBaoCao parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_CongThucMauBieuBaoCao deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_CongThucMauBieuBaoCao child in this)
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
