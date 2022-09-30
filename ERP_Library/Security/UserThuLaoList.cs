
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Security
{
    [Serializable()]
    public class UserThuLaoList : Csla.BusinessListBase<UserThuLaoList, UserThuLaoChild>
    {

        #region Factory Methods
        internal static UserThuLaoList NewUserThuLaoList()
        {
            return new UserThuLaoList();
        }

        internal static UserThuLaoList GetUserThuLaoList(int UserID)
        {
            UserThuLaoList item;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlTransaction tr = cn.BeginTransaction();
                using (SqlCommand cm = cn.CreateCommand())
                {

                    cm.Transaction = tr;
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_Select_UserThuLaoList";
                    cm.Parameters.AddWithValue("@UserID", UserID);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        item = new UserThuLaoList(dr);
                    }
                }
                cn.Close();
            }
            return item;
        }

        private UserThuLaoList()
        {
            MarkAsChild();
        }

        private UserThuLaoList(SafeDataReader dr)
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
                this.Add(UserThuLaoChild.GetUserThuLaoChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, UserItem parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (UserThuLaoChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (UserThuLaoChild child in this)
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
