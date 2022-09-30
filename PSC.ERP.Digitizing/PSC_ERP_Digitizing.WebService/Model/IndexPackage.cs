using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSC_ERP_Digitizing.WebService.Model
{
    [Serializable()]
    public class IndexPackage
    {
        public String DocId;
        public String DocFileName;
        //public String Name;
        public String Content;
        public String UpdateDate;

            //dt.Columns.Add("DocId", typeof(string));
            //dt.Columns.Add("DocFileName", typeof(string));
            //dt.Columns.Add("Content", typeof(string));
            //dt.Columns.Add("UpdateDate", typeof(string));
    }
}