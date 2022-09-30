using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum ChiTietNguyenGiaTSCD_LoaiPhanBietNVEnum
    {
        [Description("Tài sản gốc")]
        TaiSanGoc = 1,
        [Description("Điều chỉnh giá trị tài sản")]
        DieuChinhGiaTriTaiSan = 2,
        [Description("Sửa chữa lớn tài sản")]
        SuaChuaLonTaiSan = 3
    }
    /// <summary>
    /// 
    /// </summary>
    //public class ChiTietNguyenGiaTSCD_LoaiPhanBietNV
    //{

    //    #region private Field

    //    Int32 _ma;
    //    String _name;

    //    public String Ten
    //    {
    //        get { return _name; }
    //        set { _name = value; }
    //    }
    //    #endregion
    //    #region public Property

    //    public Int32 Ma
    //    {
    //        get { return _ma; }
    //        set { _ma = value; }
    //    }
    //    #endregion
    //    #region public static Property
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public static List<ChiTietNguyenGiaTSCD_LoaiPhanBietNV> ChiTietNguyenGiaTSCD_LoaiPhanBietNVList = new List<ChiTietNguyenGiaTSCD_LoaiPhanBietNV> {
    //            new ChiTietNguyenGiaTSCD_LoaiPhanBietNV(){Ma= (Int32)ChiTietNguyenGiaTSCD_LoaiPhanBietNVEnum.TaiSanGoc, Ten = "Tài sản gốc"}
    //            ,new ChiTietNguyenGiaTSCD_LoaiPhanBietNV(){Ma= (Int32)ChiTietNguyenGiaTSCD_LoaiPhanBietNVEnum.DieuChinhGiaTriTaiSan, Ten = "Điều chỉnh giá trị tài sản"}
    //            ,new ChiTietNguyenGiaTSCD_LoaiPhanBietNV(){Ma = (Int32)ChiTietNguyenGiaTSCD_LoaiPhanBietNVEnum.SuaChuaLonTaiSan, Ten = "Sửa chữa lớn tài sản"}
    //            };
    //    #endregion

    //}
}
