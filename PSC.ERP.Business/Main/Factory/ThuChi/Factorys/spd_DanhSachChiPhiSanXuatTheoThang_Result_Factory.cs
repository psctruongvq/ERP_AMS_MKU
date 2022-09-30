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
using System.Collections;
using PSC_ERP_Common.Ado.Net;

namespace PSC_ERP_Business.Main.Factory
{
    public partial class spd_DanhSachChiPhiSanXuatTheoThang_Result_Factory 
    {
        //static readonly Log4netCustom.ILog TracingLog_ = Log4netCustom.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static spd_DanhSachChiPhiSanXuatTheoThang_Result_Factory New()
        {
            return new spd_DanhSachChiPhiSanXuatTheoThang_Result_Factory();
        }

        #region Custom
        public void CapNhatMaButToanChiPhiSanXuat(long maButToanChiPhiSanXuat, int maBoPhan, int maChuongTrinh, string soDeNghi, bool loaiNV,bool isDelete)
        {
            Hashtable output = new Hashtable();
            SpeedDataAccess execNonQuery = new SpeedDataAccess(PSC_ERP_Business.Main.Database.NormalConnectionString);
            execNonQuery.ExecuteNonQueryStore(out output, "spd_CapNhatMaButToanChiPhiSanXuatE"
                                                , new string[] { "@MaButToanChiPhiSanXuat", "@MaBoPhan", "@MaChuongTrinh", "@SoDeNghi", "@LoaiNV", "@isDelete" }
                                                                , maButToanChiPhiSanXuat, maBoPhan, maChuongTrinh, soDeNghi, loaiNV,isDelete);
        }
        #endregion
    }//end class
}
