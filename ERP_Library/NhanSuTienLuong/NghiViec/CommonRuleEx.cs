using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Library
{
    public static class CommonRulesEx
    {
        public class RequireArgs : Csla.Validation.RuleArgs
        {
            public RequireArgs(string PropertyName, string ErrMsg)
                : base(PropertyName)
            {
                this.Description = ErrMsg;
            }
        }


        public static bool ValueRequire(object obj, Csla.Validation.RuleArgs e)
        {
            object value = Csla.Utilities.CallByName(obj, e.PropertyName, Csla.CallType.Get);
            if (value == null)
                return false;
            if (value == DBNull.Value)
                return false;
            if (value is string && ((string)value).Length == 0)
                return false;
            return true;
        }
    }
}
