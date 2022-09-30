using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class ChiTietCCDCChildList : Csla.BusinessListBase<ChiTietCCDCChildList, ChiTietCCDCChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            ChiTietCCDCChild item = ChiTietCCDCChild.NewChiTietCCDCChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static ChiTietCCDCChildList NewChiTietCCDCChildList()
        {
            return new ChiTietCCDCChildList();
        }

        internal static ChiTietCCDCChildList GetChiTietCCDCChildList(SafeDataReader dr)
        {
            return new ChiTietCCDCChildList(dr);
        }

        internal static ChiTietCCDCChildList GetChiTietCCDCChildList(int maCongCuDungCu)
        {
            return new ChiTietCCDCChildList(maCongCuDungCu);
        }

        private ChiTietCCDCChildList()
        {
            MarkAsChild();
        }

        private ChiTietCCDCChildList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        private ChiTietCCDCChildList(int maCongCuDungcu)
        {
            MarkAsChild();
            Fetch(maCongCuDungcu);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(ChiTietCCDCChild.GetChiTietCCDCChild(dr));

            RaiseListChangedEvents = true;
        }

        private void Fetch(int maCongCuDungCu)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblChiTietCCDCsAll";
                    cm.Parameters.AddWithValue("@MaCongCuDungCu", maCongCuDungCu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(ChiTietCCDCChild.GetChiTietCCDCChild(dr));
                    }
                }
            }        
           

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, CCDC parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (ChiTietCCDCChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (ChiTietCCDCChild child in this)
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
