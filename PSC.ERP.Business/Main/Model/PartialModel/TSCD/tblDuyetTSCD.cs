
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;


namespace PSC_ERP_Business.Main.Model
{

    public partial class tblDuyetTSCD
    {
        public Boolean Chon { get; set; }
        //tblTaiSanCoDinhCaBiet_PhongBan _phanBoSauCung_RefObj = null;
        public tblTaiSanCoDinhCaBiet_PhongBan PhanBoSauCung_RefObj
        {
            get
            {
                //if (_phanBoSauCung_RefObj == null)
                //    _phanBoSauCung_RefObj = TaiSanCoDinhCaBiet_PhongBan_Factory.New().Get_PhanBoSauCung_ByMaTSCDCaBiet(this.MaTSCDCaBiet.Value);
                //return _phanBoSauCung_RefObj;
                return this.tblTaiSanCoDinhCaBiet.PhanBoSauCung_RefObj;
            }

        }

        partial void On_DaDuyet_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue)
        {
            if (this.DaDuyet == true)
            {
                this.NgayDuyet = app_users_Factory.New().SystemDate;
                this.UserDuyet = PSC_ERP_Global.Main.UserID;
            }
            else
            {
                this.NgayDuyet = null;
                this.UserDuyet = null;
            }
        }
    }
}