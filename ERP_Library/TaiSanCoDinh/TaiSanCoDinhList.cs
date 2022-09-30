using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class TaiSanCoDinhList:BusinessListBase<TaiSanCoDinhList,TaiSanCoDinh>
    {
        #region Business Methods

        // TODO: add public properties and methods

        public TaiSanCoDinh GetTaiSanCoDinh(int MaTSCD)
        {
            foreach (TaiSanCoDinh tscd in this)
                if (tscd.MaTSCD == MaTSCD)
                    return tscd;
            return null;
        }

        public void Remove(int maTSCD)
        {
            foreach (TaiSanCoDinh item in this)
            {
                if (item.MaTSCD == maTSCD)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            try
            {
                TaiSanCoDinh item = TaiSanCoDinh.NewTaiSanCoDinh();
                Add(item);
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }                
        }
        #endregion    


        #region Factory Methods

        public static TaiSanCoDinhList NewTaiSanCoDinhList()
        {
          //return DataPortal.Create<TaiSanCoDinhList>();
            return new TaiSanCoDinhList();
        }

        public static TaiSanCoDinhList GetTaiSanCoDinhList( )
        {
          return DataPortal.Fetch<TaiSanCoDinhList>(new Criteria());
        }

        public static TaiSanCoDinhList GetTaiSanCoDinhByMaTSCDList(int MaTSCD)
        {
            return DataPortal.Fetch<TaiSanCoDinhList>(new CriteriaTaiSanCoDinhCBByMaTSCD(MaTSCD));
        }

        public static TaiSanCoDinhList GetTaiSanCoDinhByLoaiTaiSan(int MaLoaiTaiSan)
        {
            return DataPortal.Fetch<TaiSanCoDinhList>(new CriteriaTaiSanCoDinhCBByLoaiTaisan(MaLoaiTaiSan));
        }
               
        private TaiSanCoDinhList()
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
        private class CriteriaTaiSanCoDinhCBByMaTSCD
        {
            private int _MaTSCD;
            public int MaTSCD
            {
                get { return _MaTSCD; }

            }

            public CriteriaTaiSanCoDinhCBByMaTSCD(int MaTSCD)
            {
                _MaTSCD = MaTSCD;
            }
            //hong làm gì hêt
        }

        private class CriteriaTaiSanCoDinhCBByLoaiTaisan
        {
            private int _MaLoaiTaiSan;
            public int MaLoaiTaiSan
            {
                get { return _MaLoaiTaiSan; }

            }

            public CriteriaTaiSanCoDinhCBByLoaiTaisan(int MaLoaiTaiSan)
            {
                _MaLoaiTaiSan = MaLoaiTaiSan;
            }
            //hong làm gì hêt
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
                        cm.CommandText = "select * from tblTaiSanCoDinh";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(TaiSanCoDinh.GetTaiSanCoDinh(dr));
                            }
                        }
                    }
                }
            }
            else if (criteria is CriteriaTaiSanCoDinhCBByMaTSCD)

            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select * from tblTaiSanCoDinh where MaTSCD =" + ((CriteriaTaiSanCoDinhCBByMaTSCD)criteria).MaTSCD;

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(TaiSanCoDinh.GetTaiSanCoDinh(dr));
                            }
                        }
                    }
                }
            }

            else if (criteria is CriteriaTaiSanCoDinhCBByLoaiTaisan)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select * from tblTaiSanCoDinh where MaLoaiTaiSan=" + ((CriteriaTaiSanCoDinhCBByLoaiTaisan)criteria).MaLoaiTaiSan;

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(TaiSanCoDinh.GetTaiSanCoDinh(dr));
                            }
                        }
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (TaiSanCoDinh obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (TaiSanCoDinh obj in this)
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
