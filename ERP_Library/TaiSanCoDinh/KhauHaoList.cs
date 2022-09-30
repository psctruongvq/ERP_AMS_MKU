using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    public class KhauHaoList:BusinessListBase<KhauHaoList,KhauHao> 
    {
        private int _MaKy;
        public int MaKy
        {
            get { return _MaKy; }
            set { _MaKy = value; }
        }
        
        #region Business Methods

        // TODO: add public properties and methods

        public KhauHao GetKhauHao(int MaKhauHao)
        {
            foreach (KhauHao k in this)
                if (k.MaKhauHaoHaoMon == MaKhauHao)
                    return k;
            return null;
        }

        public void Remove(int maKhauHao)
        {
            foreach (KhauHao item in this)
            {
                if (item.MaKhauHaoHaoMon == maKhauHao)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            KhauHao item = KhauHao.NewKhauHao();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods


        public static KhauHaoList NewKhauHaoList()
        {
            return new KhauHaoList();
        }

        public static KhauHaoList GetKhauHaoList()
        {
          return DataPortal.Fetch<KhauHaoList>(new Criteria());
        }
       
        public static KhauHaoList GetDanhSachKhauHaoList(bool mucDichSD, int maKy)
        {
            KhauHaoList listKhauHao;
            listKhauHao = new KhauHaoList();
            listKhauHao.RaiseListChangedEvents = false;
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_LayTSCDCaBietKhauHaoHaoMon";                        
                        cm.Parameters.AddWithValue("@MucDichSuDung", mucDichSD);
                        cm.Parameters.AddWithValue("@MaKy", maKy);

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listKhauHao.Add(KhauHao.GetKhauHao(dr));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            listKhauHao.RaiseListChangedEvents = true;
            return listKhauHao;        
        }

        public static Boolean DeleteKhauHaoHaoMon(bool mucDichSD, int maKy)
        {
            Boolean kq = true;            
            try
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.StoredProcedure;
                        cm.CommandText = "spd_DeleteTSCDCaBietKhauHaoHaoMon";
                        cm.Parameters.AddWithValue("@MucDichSuDung", mucDichSD);
                        cm.Parameters.AddWithValue("@MaKy", maKy);

                        cm.ExecuteNonQuery();
                       
                    }
                }
            }
            catch (Exception ex)
            {
                kq = false;
                throw ex;

            }
            return kq;
        }

        private KhauHaoList()
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
                    cm.CommandText = "select * from tblNghiepVuKhauHaoHaoMon";

                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            this.Add(KhauHao.GetKhauHaoHaoMon(dr));
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
            foreach (KhauHao obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (KhauHao obj in this)
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
