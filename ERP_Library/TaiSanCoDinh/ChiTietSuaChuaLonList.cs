using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{
    public class ChiTietSuaChuaLonList : BusinessListBase<ChiTietSuaChuaLonList, ChiTietSuaChuaLon>
    {
        public int MaSuaChuaLon;

        #region Business Methods

        // TODO: add public properties and methods

        public ChiTietSuaChuaLon GetChiTietSuaChuaLon(int MaChiTiet)
        {
            foreach (ChiTietSuaChuaLon ct in this)
                if (ct.MaChiTiet == MaChiTiet)
                    return ct;
            return null;
        }

        public void Remove(int maChiTiet)
        {
            foreach (ChiTietSuaChuaLon item in this)
            {
                if (item.MaChiTiet == maChiTiet)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            ChiTietSuaChuaLon item = ChiTietSuaChuaLon.NewChiTietSuaChuaLon();
            Add(item);
            return item;
        }
        #endregion

        #region Factory Methods

        public static ChiTietSuaChuaLonList NewChiTietSuaChuaLonList()
        {
            return new ChiTietSuaChuaLonList();
        }

        public static ChiTietSuaChuaLonList GetChiTietSuaChuaLonList()
        {
            return DataPortal.Fetch<ChiTietSuaChuaLonList>(new Criteria());
        }

        public static ChiTietSuaChuaLonList GetChiTietSuaChuaLonList(int maSuaChuaLon)
        {
            return DataPortal.Fetch<ChiTietSuaChuaLonList>(new FilterCriteriaByMaSuaChuaLon(maSuaChuaLon));
        }

        public ChiTietSuaChuaLonList()
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
        private class FilterCriteriaByMaSuaChuaLon
        {
            private int _MaSuaChuaLon;

            public FilterCriteriaByMaSuaChuaLon(int maSuaChuaLon)
            {
                _MaSuaChuaLon = maSuaChuaLon;
            }
            public int MaSuaChuaLon
            {
                get { return _MaSuaChuaLon; }
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
                        cm.CommandText = "select * from tblChiTietBoPhanSuaChua";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(ChiTietSuaChuaLon.GetChiTietSuaChuaLon(dr));
                            }
                        }
                    }

                }
            }
            else if (criteria is FilterCriteriaByMaSuaChuaLon)
            {
                FilterCriteriaByMaSuaChuaLon crit = (FilterCriteriaByMaSuaChuaLon)criteria;
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select * from tblChiTietBoPhanSuaChua where MaNghiepVuSuaChuaLon = " + crit.MaSuaChuaLon.ToString();

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(ChiTietSuaChuaLon.GetChiTietSuaChuaLon(dr));
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
            foreach (ChiTietSuaChuaLon obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (ChiTietSuaChuaLon obj in this)
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
            foreach (ChiTietSuaChuaLon obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (ChiTietSuaChuaLon obj in this)
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
