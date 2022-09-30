using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;  

namespace ERP_Library
{
    public class ChiTietTaiSanCaBietList:BusinessListBase<ChiTietTaiSanCaBietList,ChiTietTaiSanCaBiet>
    {

        #region properties
        public int _MaTSCDCaBiet;       
        #endregion

        #region Business Methods

        // TODO: add public properties and methods

        public ChiTietTaiSanCaBiet GetChiTietTaiSanCaBiet(int maChiTiet)
        {
            foreach (ChiTietTaiSanCaBiet lts in this)
                if (lts.MaChiTiet == maChiTiet)
                    return lts;
            return null;
        }

        public void Remove(int maChiTiet)
        {
            foreach (ChiTietTaiSanCaBiet item in this)
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
            ChiTietTaiSanCaBiet item = ChiTietTaiSanCaBiet.NewChiTietTaiSanCaBiet();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static ChiTietTaiSanCaBietList NewChiTietTaiSanCaBietList()
        {
            return new ChiTietTaiSanCaBietList();
        }

        public static ChiTietTaiSanCaBietList GetChiTietTaiSanCaBietList( )
        {
          return DataPortal.Fetch<ChiTietTaiSanCaBietList>(new Criteria());
        }

        public static ChiTietTaiSanCaBietList GetChiTietTaiSanCaBietByMaTSCDCaBietList(int maTSCDCaBiet)
        {
            return DataPortal.Fetch<ChiTietTaiSanCaBietList>(new CriteriaChiTietByMaTSCDCaBiet(maTSCDCaBiet));
        }
               
        private ChiTietTaiSanCaBietList()
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
        private class CriteriaChiTietByMaTSCDCaBiet
        {
            //hong làm gì hêt
            private int _MaTSCDCaBiet;
            public int MaTSCDCaBiet
            {
                get { return _MaTSCDCaBiet; }
            }

            public CriteriaChiTietByMaTSCDCaBiet(int maTSCDCaBiet)
            {
                _MaTSCDCaBiet = maTSCDCaBiet;
            }
        }



        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            if (criteria is Criteria)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select * from tblChiTietTaiSanCaBiet";

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ChiTietTaiSanCaBiet.GetChiTietTaiSanCaBiet(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            else if (criteria is CriteriaChiTietByMaTSCDCaBiet)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    try
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select * from tblChiTietTaiSanCaBiet where MaTSCDCaBiet = " + ((CriteriaChiTietByMaTSCDCaBiet)criteria).MaTSCDCaBiet;
                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                while (dr.Read())
                                {
                                    this.Add(ChiTietTaiSanCaBiet.GetChiTietTaiSanCaBiet(dr));
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            
            }
            this.RaiseListChangedEvents = true;
        }


        protected override void DataPortal_Update()
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (ChiTietTaiSanCaBiet obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (ChiTietTaiSanCaBiet obj in this)
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
            foreach (ChiTietTaiSanCaBiet obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (ChiTietTaiSanCaBiet obj in this)
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
