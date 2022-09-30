using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Util;
using PSC_ERP_Common;
using System.Windows.Forms;
using PSC_ERP_Core;
using PSC_ERP_Business.Main.Model.Context;
using System.Data.Objects.DataClasses;
//Cường


namespace PSC_ERP_Business.Main.Model
{

    public partial class spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result
    {

        public bool Chon
        {
            get
            {
                return _chon;
            }
            set
            {
                bool oldValue = _chon;
                bool stopChanging = false;
                On_Chon_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Chon");
                if (!stopChanging)
                {
                    _chon = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Chon");
                    On_Chon_Changed(oldValue, _chon);//\\
                }
            }
        }
        public string LoaiChungTuString
        {
            get
            {
                string loaiCTString = "";
                if (_loaiCT == 1) loaiCTString = "Đề nghị chuyển khoản";
                else if (_loaiCT == 2) loaiCTString = "Giấy báo có";
                else if (_loaiCT == 3) loaiCTString = "Giấy bán ngoại tệ";
                else if (_loaiCT == 4) loaiCTString = "Lệnh chuyển tiền";
                else if (_loaiCT == 5) loaiCTString = "Ủy Nhiệm Chi Con người";
                else if (_loaiCT == 6) loaiCTString = "Phí Chuyển Tiền";
                else if (_loaiCT == 7) loaiCTString = "Giấy rút tiền";
                else if (_loaiCT == 8) loaiCTString = "Ủy Nhiệm Chi Điều Chuyển";
                return loaiCTString;
            }
        }
        public static String Chon_PropertyName { get { return "Chon"; } }
        private bool _chon;
        partial void On_Chon_Changing(bool currentValue, ref bool newValue, ref bool stopChanging);
        partial void On_Chon_Changed(bool oldValue, bool currentValue);

        public Nullable<decimal> ThanhTien
        {
            get
            {
                return SoTien*TyGia;
            }
            
        }
        public static String ThanhTien_PropertyName { get { return "ThanhTien"; } } 
       
    }
}