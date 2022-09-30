using System;
using System.Collections.Generic;
using System.Text;
using Csla;
using Csla.Data;
using System.Data;
using System.Data.SqlClient;

namespace ERP_Library
{
    public class TaiKhoanList:BusinessListBase<TaiKhoanList,HeThongTaiKhoan> 
    {
        #region Business Methods

        // TODO: add public properties and methods

        public HeThongTaiKhoan GetHeThongTaiKhoan(String soHieuTK)
        {
            foreach (HeThongTaiKhoan tk in this)
                if (tk.SoHieuTK == soHieuTK)
                    return tk;
            return null;
        }

        public void Remove(String soHieuTK)
        {
            foreach (HeThongTaiKhoan item in this)
            {
                if (item.SoHieuTK == soHieuTK)
                {
                    Remove(item);
                    break;
                }
            }
        }

        protected override object AddNewCore()
        {
            HeThongTaiKhoan item = HeThongTaiKhoan.NewHeThongTaiKhoan();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static TaiKhoanList NewTaiKhoanList()
        {
          return DataPortal.Create<TaiKhoanList>();
        }

        public static TaiKhoanList GetTaiKhoanList( )
        {
          return DataPortal.Fetch<TaiKhoanList>(new Criteria());
        }

        public static TaiKhoanList GetTaiKhoanListTKChaNULL()
        {
            return DataPortal.Fetch<TaiKhoanList>(new FilerByTaiKhoanChaByNullCriteria());
        }

        public static TaiKhoanList GetTaiKhoanCapBa()
        {
            TaiKhoanList listTKCapBa = new TaiKhoanList();          
            
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select * from view_HeThongTaiKhoanCapBa";
                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                listTKCapBa.Add(HeThongTaiKhoan.GetHeThongTaiKhoan(dr));
                            }
                        }
                    }                  

                }            
            return listTKCapBa;
        }

        public static TaiKhoanList GetSoHieu_NganHang()
        {
            return DataPortal.Fetch<TaiKhoanList>(new Criteria_NganHang());
        }
               
        private TaiKhoanList()
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
        private class FilerByTaiKhoanChaByNullCriteria
        {
            
        }

        private class Criteria_NganHang
        {
            public Criteria_NganHang()
            {

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
                        cm.CommandText = "select * from tblTaiKhoan";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(HeThongTaiKhoan.GetHeThongTaiKhoan(dr));
                            }
                        }
                    }

                }
            }
            else if (criteria is FilerByTaiKhoanChaByNullCriteria)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "select * from tblTaiKhoan where SoHieuTKCha is NULL ";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(HeThongTaiKhoan.GetHeThongTaiKhoan(dr));
                            }
                        }
                    }

                }
            }

            else if (criteria is Criteria_NganHang)
            {
                using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
                {
                    cn.Open();
                    using (SqlCommand cm = cn.CreateCommand())
                    {
                        cm.CommandType = CommandType.Text;
                        cm.CommandText = "spd_SoHieuTK_NganHang";

                        using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                        {
                            while (dr.Read())
                            {
                                this.Add(HeThongTaiKhoan.GetHeThongTaiKhoan(dr));
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
            foreach (HeThongTaiKhoan obj in DeletedList)
                obj.DeleteSelf();
            // now that they are deleted, remove them from memory too
            DeletedList.Clear();
            // add/update any current child objects
            foreach (HeThongTaiKhoan obj in this)
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
