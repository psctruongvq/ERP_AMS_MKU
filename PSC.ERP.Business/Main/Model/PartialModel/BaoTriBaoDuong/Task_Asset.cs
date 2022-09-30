
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PSC_ERP_Business.Main.Factory;


namespace PSC_ERP_Business.Main.Model
{

    public partial class Task_Asset
    {
        partial void On_Completed_Changed(Nullable<bool> oldValue, Nullable<bool> currentValue)
        {
            if (oldValue != null && oldValue != currentValue)
            {
                {//Set ngày hoàn tất của task

                    if (this.Completed.Value)
                    {
                        //
                        if (app_users_Factory.New().SystemDate >= this.Task.ActualStartTime && app_users_Factory.New().SystemDate <= this.Task.ActualEndTime)
                            this.CompletedDate = app_users_Factory.New().SystemDate;
                        else
                            this.CompletedDate = this.Task.ActualEndTime; 
                    }
                    else
                    {
                        //
                        this.CompletedDate = null;
                    }
                }

                { //Cập nhật phần trăm hoàn tất của task

                    this.Task.PercentComplete = (Int32)this.Task.CapNhatPhanTramHoanTat();                   
                }
            }
        }
    }
}