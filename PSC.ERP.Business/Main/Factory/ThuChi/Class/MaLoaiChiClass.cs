using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ERP_Library
{
    public class MaLoaiChiClass
    {
        // Fields...
        public int MaLoaiChi{get;set;}

        [DisplayName("Loại chi")]
        public string LoaiChi { get; set; }

        public MaLoaiChiClass(int maloaichi, string loaichi)
        {
            this.MaLoaiChi = maloaichi;
            this.LoaiChi = loaichi;
        }


        public static List<MaLoaiChiClass> CreatMaLoaiChiClassList()
        {
            List<MaLoaiChiClass> listResult = new List<MaLoaiChiClass>();
            listResult.Add(new MaLoaiChiClass(0,"<<Không Chọn>>"));
            listResult.Add(new MaLoaiChiClass(1, "Chi Thù Lao"));
            listResult.Add(new MaLoaiChiClass(2, "Chi Khen Thưởng"));
            listResult.Add(new MaLoaiChiClass(4, "Chi Phụ Cấp"));
            listResult.Add(new MaLoaiChiClass(5, "Truy Lĩnh"));
            listResult.Add(new MaLoaiChiClass(6, "Truy Thu"));
            listResult.Add(new MaLoaiChiClass(3, "Loại Chi Khác"));
            return listResult;
        }

        

        
        
    }
}
