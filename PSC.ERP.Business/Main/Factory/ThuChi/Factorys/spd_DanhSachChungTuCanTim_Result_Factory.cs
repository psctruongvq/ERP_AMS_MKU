using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Core;
using System.Reflection;
using System.ComponentModel;
using System.Data.Linq;
using System.Data.Objects;
using System.Data;
using PSC_ERP_Business.Main.Model.Context;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main;
using PSC_ERP_Util.DateTimeExtension;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class spd_DanhSachChungTuCanTim_Factory
    {

        public static spd_DanhSachChungTuCanTim_Factory New()
        {
            return new spd_DanhSachChungTuCanTim_Factory();
        }


        #region Custom

        public static IEnumerable<spd_DanhSachChungTuCanTim_Result> GetAll(byte kieu,int maLoaiChungTu,int maBoPhan,DateTime tuNgay, DateTime denNgay,int userID)
        {

            IEnumerable<spd_DanhSachChungTuCanTim_Result> query = ChungTuThuChi_DerivedFactory.New().Context.spd_DanhSachChungTuCanTim(kieu, maLoaiChungTu, maBoPhan, tuNgay, denNgay, userID);
            return query;
        }

        #endregion
    }//end class
}
