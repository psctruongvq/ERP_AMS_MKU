using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;


namespace ERP_Library
{
    public class ChungTuGocList: BusinessListBase<ChungTuGocList, ChungTuGoc>
    {
        public long _MaChungTu = 0;

        #region Business Methods

        // TODO: add public properties and methods

        public ChungTuGoc GetChungTu(int maChungTu)
        {
            foreach (ChungTuGoc bt in this)

                if (bt.MaHoaDon == maChungTu)
                    return bt;
            return null;
        }

        public void Remove(int maChungTu)
        {
            foreach (ChungTuGoc item in this)
            {
                if (item.MaHoaDon== maChungTu)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            ChungTuGoc item = ChungTuGoc.NewChungTuGoc();
            Add(item);
            return item;
        }
        #endregion    

         private ChungTuGocList()
        {

            //MarkAsChild();
        }

        private ChungTuGocList(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            while (dr.Read())
                this.Add(ChungTuGoc.GetChungTuGoc(dr));
            RaiseListChangedEvents = true;
        }

        #region Factory Methods

        public static ChungTuGocList NewChungTuGocList()
        {
            return new ChungTuGocList();
        }

        public static ChungTuGocList GetChungTuGocList()
        {
            return DataPortal.Fetch<ChungTuGocList>(new Criteria());
        }

        //public static ChungTuGocList GetChungTuGocListTheoSoChungTu(string soChungTuGoc)
        //{
        //    return DataPortal.Fetch<ChungTuGocList>(new CriteriaTimChungTuGoc(soChungTuGoc));
        //}

        public static ChungTuGocList GetChungTuGocList(SafeDataReader dr)
        {
            return new ChungTuGocList(dr);
        }

        #endregion

        #region Data Access

        [Serializable()]
        private class Criteria
        {
         //hong làm gì hêt
        }

        //[Serializable()]
        //public class CriteriaTimChungTuGoc
        //{
        //    public string _SoChungTuGoc;
        //    public CriteriaTimChungTuGoc(string sochungtugoc)
        //    {
        //        _SoChungTuGoc = sochungtugoc;
        //    }

        //}     


        protected override void DataPortal_Fetch(object criteria)
        {
            this.RaiseListChangedEvents = false;
            try
            {
                if (criteria is Criteria)
                {
                    using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                    {
                        cn.Open();
                        using (SqlCommand cm = cn.CreateCommand())
                        {
                            cm.CommandType = CommandType.Text;
                            cm.CommandText = "select * from tblChungTuGoc";

                            using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                            {
                                 while (dr.Read())
                                {
                                    this.Add(ChungTuGoc.GetChungTuGoc(dr));
                                }
                            }
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            this.RaiseListChangedEvents = true;
        }
        


        public  void DataPortal_Update( SqlTransaction tr)
        {
            this.RaiseListChangedEvents = false;
            // update (thus deleting) any deleted child objects
            foreach (ChungTuGoc obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (ChungTuGoc obj in this)
            {
                if (obj.IsDirty)
                {
                    if (obj.IsNew)
                        obj.Insert(tr);
                    else
                        obj.Update(tr);
                }
            }
            this.RaiseListChangedEvents = true;         
        }       

        #endregion
        
        public void Update()
        {
            DataPortal_Update();
        }
    }
}
