using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Common
{
    public static class DateTimeUtil
    {
        public static DateTime GetFirstDayOfWeek(DateTime date)
        {
            return date.AddDays(1 - (int)date.DayOfWeek);
        }

        public static DateTime GetFirstDayOfWeek()
        {
            return GetFirstDayOfWeek(DateTime.Now);
        }

        public static DateTime GetFirstDayOfMonth(DateTime date)
        {
            return date.AddDays(1 - date.Day);
        }

        public static DateTime GetFirstDayOfMonth()
        {
            return GetFirstDayOfMonth(DateTime.Now);
        }

        public static DateTime GetFirstDayOfQuarter(DateTime date)
        {
            while (date.Month % 3 != 1) date = date.AddMonths(-1);
            return date.AddDays(1 - date.Day);
        }

        public static DateTime GetFirstDayOfQuarter()
        {
            return GetFirstDayOfQuarter(DateTime.Now);
        }

        public static DateTime GetFirstDayOfYear(DateTime date)
        {
            return date.AddDays(1 - date.DayOfYear);
        }

        public static DateTime GetFirstDayOfYear()
        {
            return GetFirstDayOfYear(DateTime.Now);
        }

        public static DateTime GetLastDayOfWeek(DateTime date)
        {
            return date.AddDays(7 - (int)date.DayOfWeek);
        }

        public static DateTime GetLastDayOfWeek()
        {
            return GetLastDayOfWeek(DateTime.Now);
        }

        public static DateTime GetLastDayOfMonth(DateTime date)
        {
            date = date.AddMonths(1);
            return date.AddDays(0 - date.Day);
        }

        public static DateTime GetLastDayOfMonth()
        {
            return GetLastDayOfMonth(DateTime.Now);
        }

        public static DateTime GetLastDayOfQuarter(DateTime date)
        {
            while (date.Month % 3 != 0) date = date.AddMonths(1);
            date = date.AddMonths(1);
            return date.AddDays(0 - date.Day);
        }

        public static DateTime GetLastDayOfQuarter()
        {
            return GetLastDayOfQuarter(DateTime.Now);
        }

        public static DateTime GetLastDayOfYear(DateTime date)
        {
            date = date.AddYears(1);
            return date.AddDays(0 - date.DayOfYear);
        }

        public static DateTime GetLastDayOfYear()
        {
            return GetLastDayOfYear(DateTime.Now);
        }

    }
}
