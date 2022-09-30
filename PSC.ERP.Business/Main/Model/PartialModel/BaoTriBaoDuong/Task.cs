
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;


namespace PSC_ERP_Business.Main.Model
{

    public partial class Task
    {
        //partial void On_EndTime_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue)
        //{
        //    if (oldValue != null && oldValue != currentValue)
        //    {
        //        this.ActualEndTime = _endTime;
        //    }
        //}
        //partial void On_StartTime_Changed(Nullable<System.DateTime> oldValue, Nullable<System.DateTime> currentValue)
        //{
        //    if (oldValue != null && oldValue != currentValue)
        //    {
        //        this.ActualStartTime = _startTime;
        //    }
        //}

        public DateTime? EndTimeFix
        {
            get
            {
                try
                {
                    TimeSpan diffResult = this.EndTime.Value.Subtract(this.StartTime.Value);

                    DateTime? fixDate = this.EndTime.Value;
                    if (diffResult.Days > 0)
                    {
                        fixDate = this.EndTime.Value.AddDays(1);

                    }
                    return fixDate;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            set
            {
                TimeSpan diffResult = value.Value.Subtract(this.StartTime.Value);
                if (diffResult.Days > 0)
                {
                    this.EndTime = value.Value.AddDays(-1);
                }
            }
        }

        public decimal CapNhatPhanTramHoanTat()
        {
            decimal phanTramHoanTat = 0;
            //Lấy tổng số tài sản
            decimal tongTaiSan = this.Task_Asset.Count;

            //Lấy số lượng tài sản đã hoàn tất
            decimal soLuongHoanTat = (from o in this.Task_Asset
                                      where o.Completed == true
                                      select o).Count();
            //Tính phần trăm hoàn tất
            if (tongTaiSan > 0)
            {
                phanTramHoanTat = Math.Round(((soLuongHoanTat / tongTaiSan) * 100));
            }
            else
            {
                phanTramHoanTat = 0;
            }
            //
            if (soLuongHoanTat > tongTaiSan)
            {
                phanTramHoanTat = 100;
            }
            //
            return phanTramHoanTat;
        }
    }
}