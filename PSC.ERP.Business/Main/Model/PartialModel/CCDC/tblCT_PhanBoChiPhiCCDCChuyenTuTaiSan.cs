
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;
//Cường

namespace PSC_ERP_Business.Main.Model
{

    public partial class tblCT_PhanBoChiPhiCCDCChuyenTuTaiSan
    {

        //phần trăm
        partial void On_PhanTramPhanBo_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {

        }
        partial void On_PhanTramPhanBo_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            if (oldValue != null)
                try
                {

                    //nguyên giá tính phân bổ
                    Decimal NguyenGiaTinhPhanBo = 0;
                    NguyenGiaTinhPhanBo = (this.tblCongCuDungCu.NguyenGia ?? 0) - (this.tblCongCuDungCu.LuyKeKHTaiSanChuyenSang ?? 0) - (this.tblCongCuDungCu.LuyKeHMTaiSanChuyenSang ?? 0);

                    Decimal chiPhiPhanBoChuaLamTron = (Decimal)((NguyenGiaTinhPhanBo / 100) * this.PhanTramPhanBo);
                    Decimal chiPhiPhanBoLamTron = Math.Round(chiPhiPhanBoChuaLamTron);
                    if (chiPhiPhanBoLamTron > this.ChiPhiConLaiTruocPhanBo || this.tblPhanBoChiPhiCCDCChuyenTuTaiSan.NgayChungTu.Value.Year == 2016)
                        chiPhiPhanBoLamTron = this.ChiPhiConLaiTruocPhanBo.Value;
                    //tính lại số tiền phân bổ
                    this.ChiPhiPhanBo = chiPhiPhanBoLamTron;
                }
                catch (System.Exception ex)
                {

                }


        }
        //chi phí phân bổ
        partial void On_ChiPhiPhanBo_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {

        }
        partial void On_ChiPhiPhanBo_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {
            ////tính lại chi phí đã phân bổ trên CCDC
            if (oldValue != null)
                try
                {
                    if ((oldValue ?? 0) != (currentValue ?? 0))
                    {
                        Decimal soLuongTonTruoc = (this.tblCongCuDungCu.ChiPhiDaPhanBo ?? 0);
                        this.tblCongCuDungCu.ChiPhiDaPhanBo = soLuongTonTruoc + (currentValue ?? 0) - (oldValue ?? 0);
                        this.ChiPhiConLai = ((this.tblCongCuDungCu.NguyenGia ?? 0)
                                            - (this.tblCongCuDungCu.LuyKeKHTaiSanChuyenSang ?? 0)
                                            - (this.tblCongCuDungCu.LuyKeHMTaiSanChuyenSang ?? 0))
                            - (this.tblCongCuDungCu.ChiPhiDaPhanBo ?? 0);
                    }
                }
                catch (Exception ex)
                {

                }
        }
        //chi phí còn lại trước phân bổ
        partial void On_ChiPhiConLaiTruocPhanBo_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {

        }
        partial void On_ChiPhiConLaiTruocPhanBo_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {

        }
        //chi phí còn lại sau phân bổ
        partial void On_ChiPhiConLai_Changing(Nullable<decimal> currentValue, ref Nullable<decimal> newValue, ref bool stopChanging)
        {

        }
        partial void On_ChiPhiConLai_Changed(Nullable<decimal> oldValue, Nullable<decimal> currentValue)
        {

        }
    }
}