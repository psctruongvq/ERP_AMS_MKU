using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_TrackingLog
{
    class CustomTrackingLogProperty
    {
        String _key;
        public String Value
        {
            get { return Log4netCustom2.ThreadContext.Properties[_key].ToString(); }
            set { Log4netCustom2.ThreadContext.Properties[_key] = value; }
        }
        public CustomTrackingLogProperty(String key, String value)
        {
            _key = key;
            Log4netCustom2.ThreadContext.Properties[_key] = value;
        }
        public CustomTrackingLogProperty(AnotherTrackingLogKeys key, String value)
        {
            _key = key.ToString();
            Log4netCustom2.ThreadContext.Properties[_key] = value;
        }
        public void Remove()
        {
            Log4netCustom2.ThreadContext.Properties[_key] = null;
        }
    }
}
