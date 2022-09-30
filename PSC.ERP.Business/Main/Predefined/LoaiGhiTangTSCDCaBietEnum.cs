using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum LoaiGhiTangTSCDCaBietEnum
    {
        TangMoi = 0,
        KhongTangMoi = 1
    }
    /// <summary>
    /// 
    /// </summary>
    public class LoaiGhiTangTSCDCaBiet
    {

        #region private Field

        Int32 _ma;
        String _name;

        public String TenLoaiGhiTangTSCDCaBiet
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region public Property

        public Int32 MaLoaiGhiTangTSCDCaBiet
        {
            get { return _ma; }
            set { _ma = value; }
        }
        #endregion
        #region public static Property
        /// <summary>
        /// 
        /// </summary>
        public static List<LoaiGhiTangTSCDCaBiet> LoaiGhiTangTSCDCaBietList = new List<LoaiGhiTangTSCDCaBiet> {
                new LoaiGhiTangTSCDCaBiet(){MaLoaiGhiTangTSCDCaBiet= (Int32)LoaiGhiTangTSCDCaBietEnum.TangMoi, TenLoaiGhiTangTSCDCaBiet = "Tăng mới"}
                ,new LoaiGhiTangTSCDCaBiet(){MaLoaiGhiTangTSCDCaBiet = (Int32)LoaiGhiTangTSCDCaBietEnum.KhongTangMoi, TenLoaiGhiTangTSCDCaBiet = "Không tăng mới"}
                };
        #endregion

    }
}
