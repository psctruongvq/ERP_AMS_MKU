using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_ChungTuBienLaiChildList : Csla.BusinessListBase<CT_ChungTuBienLaiChildList, CT_ChungTuBienLaiChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_ChungTuBienLaiChild item = CT_ChungTuBienLaiChild.NewCT_ChungTuBienLaiChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static CT_ChungTuBienLaiChildList NewCT_ChungTuBienLaiChildList()
        {
            return new CT_ChungTuBienLaiChildList();
        }

        internal static CT_ChungTuBienLaiChildList GetCT_ChungTuBienLaiChildList(SafeDataReader dr)
        {
            return new CT_ChungTuBienLaiChildList(dr);
        }

        internal static CT_ChungTuBienLaiChildList GetCT_ChungTuBienLaiChildList(long maChungTu)
        {
            return new CT_ChungTuBienLaiChildList(maChungTu);
        }

        private CT_ChungTuBienLaiChildList()
        {
            MarkAsChild();
        }

        private CT_ChungTuBienLaiChildList(long maChungTu)
        {
            MarkAsChild();
            Fetch(maChungTu);
        }

        private CT_ChungTuBienLaiChildList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(CT_ChungTuBienLaiChild.GetCT_ChungTuBienLaiChild(dr));

            RaiseListChangedEvents = true;
        }

        private void Fetch(long maChungTu)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_ChungTuBienLaisAll";
                    cm.Parameters.AddWithValue("@MaChungTu", maChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(CT_ChungTuBienLaiChild.GetCT_ChungTuBienLaiChild(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_ChungTuBienLaiChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_ChungTuBienLaiChild child in this)
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
