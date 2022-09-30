using PSC_ERP_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PSC_ERPNew.Main.PhanHe.DIGITIZING.Predefined
{
    public enum DocumentTypeEnum
    {
        [Description("<<Tất cả>>")]
        TatCa = 0,
        [Description("Phiếu thu")]
        ChungTuKeToan_PhieuThu = 2,//tblLoaiChungTu
        [Description("Phiếu chi")]
        ChungTuKeToan_PhieuChi = 3,//tblLoaiChungTu
        [Description("Bảng kê")]
        ChungTuKeToan_BangKe = 16,//tblLoaiChungTu

        [Description("Phiếu nhập")]
        ChungTuKeToan_PhieuNhap = 1001,
        [Description("Phiếu xuất")]
        ChungTuKeToan_PhieuXuat = 1002,
        [Description("Hợp đồng trong đài")]
        HopDong_NoiBo = 1003,
        [Description("Hợp đồng ngoài đài")]
        HopDong_BenNgoai = 1004,
      
        /// ////////////////////////////////////
        [Description("Văn bản: Quyết định")]
        VanBan_QuyetDinh=2005,
        [Description("Văn bản: Thông báo")]
        VanBan_ThongBao=2006,

        [Description("Chuyên mục khác")]
        VanBan_ChuyenMucKhac=2007,

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
                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.VanBan_QuyetDinh, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.VanBan_QuyetDinh)}
                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.VanBan_ThongBao, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.VanBan_ThongBao)}
                ,new DocumentType(){Id= (Int32)DocumentTypeEnum.VanBan_ChuyenMucKhac, Name= AttributeUtil.GetEnumFieldDescription(DocumentTypeEnum.VanBan_ChuyenMucKhac)}

                };
        #endregion
    }
}
