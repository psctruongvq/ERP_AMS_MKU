using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Util.DateTimeExtension
{
    public static class DateTimeExtension
    {
        //public static DateTime RemoveTime(this DateTime dateTime)
        //{
        //    return dateTime.Date;
        //}        
        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59);
        }
    }
}
