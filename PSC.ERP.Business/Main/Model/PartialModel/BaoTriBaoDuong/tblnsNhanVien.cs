using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Util;
//Cường

namespace PSC_ERP_Business.Main.Model
{
    public partial class tblnsNhanVien
    {
        public Boolean Chon { get; set; }
        public Int32 PercentComplete { get; set; }
        public Int32 AmountComplete { get; set; }
        public Int32 AmountNotComplete { get; set; }
    }
}