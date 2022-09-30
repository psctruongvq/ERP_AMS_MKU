
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_MauBangBaoCaoListH : Csla.BusinessListBase<CT_MauBangBaoCaoListH, CT_MauBangBaoCaoH>
    {

        #region Factory Methods
        public static CT_MauBangBaoCaoListH NewCT_MauBangBaoCaoListH()
        {
            return new CT_MauBangBaoCaoListH();
        }

        public static CT_MauBangBaoCaoListH GetCT_MauBangBaoCaoListH(int MaMuc, byte loaiMau)
        {
            return new CT_MauBangBaoCaoListH(MaMuc, loaiMau);
        }

        private CT_MauBangBaoCaoListH()
        {
            MarkAsChild();
        }

        private CT_MauBangBaoCaoListH(int MaMuc, byte loaiMau)
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
                        cm.CommandText = "spd_SelecttblCT_BangCanDoiKeToan1ByMaMuc";
                        cm.Parameters.AddWithValue("@MaMuc", MaMuc);
                        cm.Parameters.AddWithValue("@LoaiMau", loaiMau);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                                this.Add(CT_MauBangBaoCaoH.GetCT_MauBangBaoCaoH(dr));
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
                this.Add(CT_MauBangBaoCaoH.GetCT_MauBangBaoCaoH(dr));

            RaiseListChangedEvents = true;
        }

        
        internal void Update(SqlTransaction tr, BangCanDoiKeToanH parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_MauBangBaoCaoH deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_MauBangBaoCaoH child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, BangKQHDKDH parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_MauBangBaoCaoH deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_MauBangBaoCaoH child in this)
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
