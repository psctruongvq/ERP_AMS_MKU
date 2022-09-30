using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ERP_Library
{
    public class PhanLoaiLopDaoTao
    {
        
        //[Browsable(false)]
        public int ID{ get;set;}
        [DisplayName("Mã")]
        public string MaQL { get; set; }
        [DisplayName("Tên")]
        public string TenLoai { get; set; }

        public PhanLoaiLopDaoTao(int id, string maQl, string tenLoai)
        {
            this.ID=id;
            this.MaQL = maQl;
            this.TenLoai = tenLoai;
        }

        public static List<PhanLoaiLopDaoTao> CreatePhanLoaiLopDaoTaoList()
        {
            List<PhanLoaiLopDaoTao> list = new List<PhanLoaiLopDaoTao>();
            //1: Lý luận chính trị | 2: Quản lý nhà nước | 3: Tin Học | 4: Ngoại ngữ
            list.Add(new PhanLoaiLopDaoTao(0, "", "<Không chọn>"));
            list.Add(new PhanLoaiLopDaoTao(1,"LLCT","Lý Luận Chính Trị"));
            list.Add(new PhanLoaiLopDaoTao(2,"QLNN","Quản Lý Nhà Nước"));
            list.Add(new PhanLoaiLopDaoTao(3, "TH", "Tin Học"));
            list.Add(new PhanLoaiLopDaoTao(4, "NN", "Ngoại Ngữ"));
            list.Add(new PhanLoaiLopDaoTao(5, "QPAN", "Quốc Phòng An Ninh"));
            list.Add(new PhanLoaiLopDaoTao(6, "LĐQL", "Lãnh Đạo Quản Lý"));
            return list;

        }

    }
}
