
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{
    public class TinhLuongTuDong
    {

        #region Data Access - Insert
        public static void Insert(DateTime NgayChamCong,int MaCa,string NhaMay)
        {
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_TinhCong";
                    cm.Parameters.AddWithValue("@NgayChamCong", NgayChamCong.ToShortDateString());
                    cm.Parameters.AddWithValue("@MaCa", MaCa);
                    cm.Parameters.AddWithValue("@NhaMay", NhaMay);
                    //cm.Parameters.AddWithValue("@Date", NgayLap);
                    //cm.Parameters.AddWithValue("@KhoaSo", KhoaSo);
                    
                    cm.ExecuteNonQuery();
                }
            }//using
        }
        #endregion 
    }
}
