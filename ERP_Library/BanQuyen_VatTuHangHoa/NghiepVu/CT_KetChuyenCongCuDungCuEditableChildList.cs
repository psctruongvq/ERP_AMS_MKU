
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class CT_KetChuyenCongCuDungCuList : Csla.BusinessListBase<CT_KetChuyenCongCuDungCuList, CT_KetChuyenCongCuDungCu>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            CT_KetChuyenCongCuDungCu item = CT_KetChuyenCongCuDungCu.NewCT_KetChuyenCongCuDungCu();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static CT_KetChuyenCongCuDungCuList NewCT_KetChuyenCongCuDungCuList()
        {
            return new CT_KetChuyenCongCuDungCuList();
        }

        //internal static CT_KetChuyenCongCuDungCuList GetCT_KetChuyenCongCuDungCuList(SafeDataReader dr)
        //{
        //    return new CT_KetChuyenCongCuDungCuList(dr);
        //}

        internal static CT_KetChuyenCongCuDungCuList GetCT_KetChuyenCongCuDungCuList(int id)
        {
            return new CT_KetChuyenCongCuDungCuList(id);
        }

        private CT_KetChuyenCongCuDungCuList()
        {
            MarkAsChild();
        }

        //private CT_KetChuyenCongCuDungCuList(SafeDataReader dr)
        //{
        //    MarkAsChild();
        //    Fetch(dr);
        //}

        private CT_KetChuyenCongCuDungCuList(int id)
        {
            MarkAsChild();
            Fetch(id);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(int MaKetChuyen)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblCT_KetChuyenCongCuDungCu_MaKetChuyen";//\\
                    cm.Parameters.AddWithValue("@MaKetChuyen", MaKetChuyen);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())                            
                            this.Add(CT_KetChuyenCongCuDungCu.GetCT_KetChuyenCongCuDungCu(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, KyKetChuyenCongCuDungCu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (CT_KetChuyenCongCuDungCu deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (CT_KetChuyenCongCuDungCu child in this)
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
