using PSC_ERP_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PSC_ERP_Digitizing.Client.Predefined
{
    public enum DocumentTypeEnum
    {
        [Description("<<Tất cả>>")]
        TatCa = 0,
        [Description("Chứng từ kế toán: Phiếu thu")]
        ChungTuKeToan_PhieuThu = 2,//tblLoaiChungTutbl
        [Description("Chứng từ kế toán: Phiếu chi")]
        ChungTuKeToan_PhieuChi = 3,//tblLoaiChungTu
        [Description("Chứng từ kế toán: Bảng kê")]
        ChungTuKeToan_BangKe = 16,//tblLoaiChungTu

        [Description("Chứng từ kế toán: Phiếu nhập")]
        ChungTuKeToan_PhieuNhap = 1001,
        [Description("Chứng từ kế toán: Phiếu xuất")]
        ChungTuKeToan_PhieuXuat = 1002,
        [Description("Hợp đồng: Nội bộ")]
        HopDong_NoiBo = 1003,
        [Description("Hợp đồng: Bên ngoài")]
        HopDong_BenNgoai = 1004,

        //[Description("Văn bản: Quyết định")]
        //VanBan_QuyetDinh,
        //[Description("Văn bản: Thông báo")]
        //VanBan_ThongBao,

        //[Description("Chuyên mục khác")]
        //VanBan_ChuyenMucKhac,

    }
    public class DocumentType
    {
        #region private Field

        Int32 _id;
        String _name;
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region public Property


        #endregion
        #region public static Property
        /// <summary>
        /// 
        /// </summary>
        public static List<DocumentType> DocumentTypeList = new List<DocumentType> {
                new DocumentType(){Id= (Int32)DocumentTypeEnum.TatCa,Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.TatCa)}
                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.ChungTuKeToan_BangKe, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.ChungTuKeToan_BangKe)}
                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.ChungTuKeToan_PhieuThu, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.ChungTuKeToan_PhieuThu)}
                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.ChungTuKeToan_PhieuChi, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.ChungTuKeToan_PhieuChi)}
                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.ChungTuKeToan_PhieuNhap, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.ChungTuKeToan_PhieuNhap)}
                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.ChungTuKeToan_PhieuXuat, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.ChungTuKeToan_PhieuXuat)}

                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.HopDong_NoiBo, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.HopDong_NoiBo)}
                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.HopDong_BenNgoai, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.HopDong_BenNgoai)}
                //,new DocumentType(){Id= (Int32)DocumentTypeEnum.VanBan_QuyetDinh, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.VanBan_QuyetDinh)}
                //,new DocumentType(){Id= (Int32)DocumentTypeEnum.VanBan_ThongBao, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.VanBan_ThongBao)}

                };
        #endregion
    }
}
