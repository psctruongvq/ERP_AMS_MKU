using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PSC_ERP_Business.Main.Predefined
{
    public enum ProjectReportTreeNodeEnum
    {//không hiểu vui lòng đừng rename
        [Description("Root")]
        Root = 0,
        [Description("Dự án")]
        Project = 1,
        [Description("Nhóm công việc")]
        Resource = 2,
        [Description("Công việc")]
        Task = 3

    }
}
