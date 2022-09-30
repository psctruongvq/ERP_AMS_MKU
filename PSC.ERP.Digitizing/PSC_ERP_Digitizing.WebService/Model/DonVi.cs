


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSC_Digitizing.WebService.Model
{
    [Serializable()]
    public class DonVi
    {
        internal Guid Oid;
        public DateTime DateChanged;
        public String MaDonVi;
        public String TenDonVi;
        public String CapDonViCapTren;
    }
}