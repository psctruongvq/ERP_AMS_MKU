using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum GioiTinhEnum
    {
        [Description("Nữ")]
        Nu = 0,
        [Description("Nam")]
        Nam = 1,
    }
    /// <summary>
    /// 
    /// </summary>
    public class GioiTinh
    {

        #region private Field

        Boolean _gioiTinhNam;
        String _name;

        public String Ten
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
        #region public Property

        public Boolean GioiTinhNam
        {
            get { return _gioiTinhNam; }
            set { _gioiTinhNam = value; }
        }
        #endregion
        #region public static Property
        /// <summary>
        /// 
        /// </summary>
        public static List<GioiTinh> GioiTinhList = new List<GioiTinh> {
                new GioiTinh(){GioiTinhNam= Convert.ToBoolean(GioiTinhEnum.Nu), Ten = PSC_ERP_Common.AttributeUtil.GetEnumFieldDescription(GioiTinhEnum.Nu)}
                ,new GioiTinh(){GioiTinhNam= Convert.ToBoolean(GioiTinhEnum.Nam), Ten = PSC_ERP_Common.AttributeUtil.GetEnumFieldDescription(GioiTinhEnum.Nam)}
                };
        #endregion

    }
}
