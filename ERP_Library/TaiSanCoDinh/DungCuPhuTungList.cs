using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class DungCuPhuTungList:BusinessListBase<DungCuPhuTungList,DungCuPhuTung> 
    {
        public int _MaTSCDCaBiet;

        #region Business Methods

        // TODO: add public properties and methods

        public DungCuPhuTung GetDungCuPhuTung(int MaDungCuPhuTung)
        {
            foreach (DungCuPhuTung lt in this)
                if (lt.MaDungCuPhuTung == MaDungCuPhuTung)
                    return lt;
            return null;
        }

        public void Remove(int maDungCuPhuTung)
        {
            foreach (DungCuPhuTung item in this)
            {
                if (item.MaDungCuPhuTung== maDungCuPhuTung)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            DungCuPhuTung item = DungCuPhuTung.NewDungCuPhuTung();
            Add(item);
            return item;
        }
        #endregion    



        #region Factory Methods

        public static DungCuPhuTungList NewDungCuPhuTungList()
        {
            return new DungCuPhuTungList();
        }

        public static DungCuPhuTungList GetDungCuPhuTungList( )
        {
          return DataPortal.Fetch<DungCuPhuTungList>(new Criteria());
        }

        public static DungCuPhuTungList GetDungCuPhuTungByMaTSCDCaBietList(int MaTSCDCaBiet)
        {
            return DataPortal.Fetch<DungCuPhuTungList>(new CriteriaDungCuPhuTungByMaTSCDCaBiet(MaTSCDCaBiet));
        }

        private DungCuPhuTungList()
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

        [Serializable()]
        private class CriteriaDungCuPhuTungByMaTSCDCaBiet
        {
            private int _MaTSCDCaBiet;
            public int MaTSCDCaBiet
            {
                get { return _MaTSCDCaBiet; }
            }

            public CriteriaDungCuPhuTungByMaTSCDCaBiet(int MaTSCDCaBiet)
            {
                _MaTSCDCaBiet = MaTSCDCaBiet;
            }
        }     

        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            if (criteria is Criteria)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select * from tblDungCuPhuTung";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(DungCuPhuTung.GetDungCuPhuTung(dr));
                            }
                        }
                    }

                }
            }
            else if (criteria is CriteriaDungCuPhuTungByMaTSCDCaBiet)
            {
                try
                {
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select * from tblDungCuPhuTung where MaTSCDCaBiet = " + ((CriteriaDungCuPhuTungByMaTSCDCaBiet)criteria).MaTSCDCaBiet;

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(DungCuPhuTung.GetDungCuPhuTung(dr));
                                }
                            }
                        }

                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            this.RaiseListChangedEvents = true;
        }

         protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (DungCuPhuTung obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (DungCuPhuTung obj in this)
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

        public void DataPortal_UpdateTranSacTion(SqlTransaction tr)
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (DungCuPhuTung obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (DungCuPhuTung obj in this)
            {
                if (obj.IsDirty)
                {
                    if (obj.IsNew)
                        obj.InsertTranSacTion(tr);
                    else
                        obj.UpdateTranSacTion(tr);
                }
            }
            this.RaiseListChangedEvents = true;
        }       


        #endregion
    }
}
