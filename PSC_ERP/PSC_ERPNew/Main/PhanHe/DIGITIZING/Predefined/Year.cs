using PSC_ERP_Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PSC_ERPNew.Main.PhanHe.DIGITIZING.Predefined
{

    public class Year
    {


        Int32 _id;
        String _name;
        public Int32 Id
        {
            get { return _id; }
            //set { _id = value; }
        }

        public String Name
        {
            get { return _name; }
            //set { _name = value; }
        }

        public Year(Int32 year, String yearName = null)
        {
            _id = year;
            if (yearName != null)
                _name = yearName;
            else
                _name = year.ToString();
        }

    }
}
