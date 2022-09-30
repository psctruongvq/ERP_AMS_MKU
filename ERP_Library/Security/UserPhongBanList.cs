
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library.Security
{
    [Serializable()]
    public class UserPhongBanList : Csla.BusinessListBase<UserPhongBanList, UserPhongBan>
    {
        #region BindingList Overrides
        private int iddef = -1;
        protected override object AddNewCore()
        {
            return null;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        internal static UserPhongBanList NewUserPhongBanList()
        {
            return new UserPhongBanList();
        }

        internal static UserPhongBanList GetUserPhongBanList(int UserID)
        {
            return new UserPhongBanList(UserID);
        }

        private UserPhongBanList()
        {
            MarkAsChild();
        }

        private UserPhongBanList(int UserID)
        {
            MarkAsChild();
            Fetch(UserID);
        }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(int UserID)
        {
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                SqlCommand cm = cn.CreateCommand();
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "app_Select_UserPhongBanList";
                cm.Parameters.AddWithValue("@UserID", UserID);

                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    while (dr.Read())
                        this.Add(UserPhongBan.GetUserPhongBan(dr));
                }
            }
            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, UserItem parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (UserPhongBan deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (UserPhongBan child in this)
            {
                if (child.IsNew)
                    child.Insert(tr);
                else
                    child.Update(tr);
            }

            RaiseListChangedEvents = true;
        }
        #endregion //Data Access

    }
}
