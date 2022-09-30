using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    public class TongHopNghiepVuGhiTangList:BusinessListBase<TongHopNghiepVuGhiTangList,TongHopNghiepVuGhiTang>
    {
        #region Business Methods

        // TODO: add public properties and methods

        

        protected override object AddNewCore()
        {
            TongHopNghiepVuGhiTang item = TongHopNghiepVuGhiTang.NewTongHopNghiepVuGhiTang();
            Add(item);
            return item;
        }
        #endregion    

        #region Factory Methods

        public static TongHopNghiepVuGhiTangList NewTongHopNghiepVuGhiTangList()
        {
          return DataPortal.Create<TongHopNghiepVuGhiTangList>();
        }

        public static TongHopNghiepVuGhiTangList GetTongHopNghiepVuGhiTangList( )
        {
            return DataPortal.Fetch<TongHopNghiepVuGhiTangList>(new Criteria());
        }

        private TongHopNghiepVuGhiTangList()
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

        private void DataPortal_Create(Criteria criteria)
        {
            // TODO: load default values into object
        }

        public static TongHopNghiepVuGhiTangList GetTongHopNVGhiTang(DateTime tuNgay, DateTime denNgay)
        {
            TongHopNghiepVuGhiTangList list = new TongHopNghiepVuGhiTangList();
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_LoadNghiepVuGhiTang";
                    cm.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cm.Parameters.AddWithValue("@DenNgay", denNgay);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                        {
                            list.Add(TongHopNghiepVuGhiTang.GetTongHopNghiepVuGhiTang(dr));
                        }
                    }
                }
            }
            return list;
            
        }     
        
        #endregion
    }
}
