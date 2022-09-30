
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ERP_Library;

namespace ERP_Library
{
    [Serializable()] 

    public class BangCatCongList : Csla.BusinessListBase<BangCatCongList, BangCatCong>
    {

	    #region Authorization Rules

	    public static bool CanGetObject()
	    {
		    //TODO: Define CanGetObject permission in BangCatCongList
		    return true;
		    //if (Csla.ApplicationContext.User.IsInRole("BangCatCongListViewGroup"))
		    //	return true;
		    //return false;
	    }

	    public static bool CanAddObject()
	    {
		    //TODO: Define CanAddObject permission in BangCatCongList
		    return true;
		    //if (Csla.ApplicationContext.User.IsInRole("BangCatCongListAddGroup"))
		    //	return true;
		    //return false;
	    }

	    public static bool CanEditObject()
	    {
		    //TODO: Define CanEditObject permission in BangCatCongList
		    return true;
		    //if (Csla.ApplicationContext.User.IsInRole("BangCatCongListEditGroup"))
		    //	return true;
		    //return false;
	    }

	    public static bool CanDeleteObject()
	    {
		    //TODO: Define CanDeleteObject permission in BangCatCongList
		    return true;
		    //if (Csla.ApplicationContext.User.IsInRole("BangCatCongListDeleteGroup"))
		    //	return true;
		    //return false;
	    }
	    #endregion //Authorization Rules

	    #region Factory Methods
	    private BangCatCongList()
	    { /* require use of factory method */ }

	    public static BangCatCongList NewBangCatCongList()
	    {
		    if (!CanAddObject())
			    throw new System.Security.SecurityException("User not authorized to add a BangCatCongList");
		    return new BangCatCongList();
	    }

	    public static BangCatCongList GetBangCatCongList(int maBoPhan)
	    {
		    if (!CanGetObject())
			    throw new System.Security.SecurityException("User not authorized to view a BangCatCongList");
		    return DataPortal.Fetch<BangCatCongList>(new FilterCriteria(maBoPhan));
	    }

        public static BangCatCongList GetBangCatCongList()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException("User not authorized to view a BangCatCongList");
            return DataPortal.Fetch<BangCatCongList>(new FilterCriteria());
        }
        public static void DeleteBangCatCongList()
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "DELETE FROM tblnsBangCatCong";

                    //AddUpdateParameters(cm, parent);

                    //cm.Parameters.AddWithValue("@NgayCatCong", DateTime.Parse(NgayCatCong.Text));
                    //cm.Parameters.AddWithValue("@NhaMay", "");//Properties.Settings.Default.NhaMay);
                    cn.Open();
                    cm.ExecuteNonQuery();
                    
                    cn.Close();

                }//using
            }
        }
	    #endregion //Factory Methods

	    #region Data Access

	    #region Filter Criteria
	    [Serializable()]
	    private class FilterCriteria
	    {
		    public int MaBoPhan;

		    public FilterCriteria(int maBoPhan)
		    {
			    this.MaBoPhan = maBoPhan;
		    }
            public FilterCriteria()
            {
                this.MaBoPhan = 0;
            }
	    }
	    #endregion //Filter Criteria

	    #region Data Access - Fetch
	    private void DataPortal_Fetch(FilterCriteria criteria)
	    {
		    RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
		    {
			    cn.Open();

			    ExecuteFetch(cn, criteria);
		    }//using

		    RaiseListChangedEvents = true;
	    }

	    private void ExecuteFetch(SqlConnection cn, FilterCriteria criteria)
	    {
		    using (SqlCommand cm = cn.CreateCommand())
		    {
			    cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "[spd_SelecttblnsBangCatCongsAll]";
			    cm.Parameters.AddWithValue("@MaBoPhan", criteria.MaBoPhan);

			    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
			    {
				    while (dr.Read())
					    this.Add(BangCatCong.GetBangCatCong(dr));
			    }
		    }//using
	    }
	    #endregion //Data Access - Fetch


	    #region Data Access - Update
	    protected override void DataPortal_Update()
	    {
		    RaiseListChangedEvents = false;

            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
		    {
			    cn.Open();

			    // loop through each deleted child object
			    foreach (BangCatCong deletedChild in DeletedList)
				    deletedChild.DeleteSelf(cn);
			    DeletedList.Clear();

			    // loop through each non-deleted child object
			    foreach (BangCatCong child in this)
			    {
				    if (child.IsNew)
					    child.Insert(cn,this);
				    else
					    child.Update(cn,this);
			    }
		    }//using SqlConnection

		    RaiseListChangedEvents = true;
	    }
	    #endregion //Data Access - Update
	    #endregion //Data Access
    }
}

