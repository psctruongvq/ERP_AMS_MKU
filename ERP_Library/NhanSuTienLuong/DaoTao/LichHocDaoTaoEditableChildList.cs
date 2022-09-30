using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class LichHocDaoTaoList : Csla.BusinessListBase<LichHocDaoTaoList, LichHocDaoTao>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            LichHocDaoTao item = LichHocDaoTao.NewLichHocDaoTao();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static LichHocDaoTaoList NewLichHocDaoTaoList()
        {
            return new LichHocDaoTaoList();
        }

        internal static LichHocDaoTaoList GetLichHocDaoTaoList(int maDeCu)
        {
            return new LichHocDaoTaoList(maDeCu);
        }

        private LichHocDaoTaoList()
        {
            MarkAsChild();
        }

        private LichHocDaoTaoList(int maDeCu)
        {
            MarkAsChild();
            Fetch(maDeCu);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(int maDeCu)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblnsLichHocDaoTaosAll";
                    cm.Parameters.AddWithValue("@MaDeCu", maDeCu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(LichHocDaoTao.GetLichHocDaoTao(dr));
                    }
                }
            }
            //RaiseListChangedEvents = true;


            //RaiseListChangedEvents = false;

            //while (dr.Read())
            //    this.Add(LichHocDaoTao.GetLichHocDaoTao(dr));

            //RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, DeCu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (LichHocDaoTao deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (LichHocDaoTao child in this)
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
