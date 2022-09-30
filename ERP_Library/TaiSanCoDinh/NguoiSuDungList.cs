using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class NguoiSuDungList:BusinessListBase<NguoiSuDungList,NguoiSuDung>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public NguoiSuDung GetNguoiSuDung(long MaNguoiSuDung)
        {
            foreach (NguoiSuDung nsd in this)
                if (nsd.MaNguoiSuDung == MaNguoiSuDung)
                    return nsd;
            return null;
        }

        public void Remove(long maNguoiSuDung)
        {
            foreach (NguoiSuDung item in this)
            {
                if (item.MaNguoiSuDung == maNguoiSuDung)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            NguoiSuDung item = NguoiSuDung.NewNguoiSuDung();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static NguoiSuDungList NewNguoiSuDungList()
        {
          return DataPortal.Create<NguoiSuDungList>();
        }

        public static NguoiSuDungList GetNguoiSuDungList( )
        {
          return DataPortal.Fetch<NguoiSuDungList>(new Criteria());
        }
               
        private NguoiSuDungList()
        {
            this.AllowNew = true;            
        }

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
            //hong làm gì hêt
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select * from tblNguoiSuDung";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(NguoiSuDung.GetNguoiSuDung(dr));
                        }
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // add/update any current child objects
            foreach (NguoiSuDung obj in this)
            {
                if (obj.IsDirty)
                {
                    if (obj.IsNew)
                        obj.Insert();
                    else
                        obj.Update();
                }
            }
            this.RaiseListChangedEvents = true;
        }

        #endregion
    }
}
