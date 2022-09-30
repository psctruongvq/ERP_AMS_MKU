using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_TrackingLog
{
    class AutoTrackingLogProperty : IDisposable
    {
        String _key;
        private bool _disposed = false;
        public String Value
        {
            get { return Log4netCustom2.ThreadContext.Properties[_key].ToString(); }
            set { Log4netCustom2.ThreadContext.Properties[_key] = value; }
        }
        public AutoTrackingLogProperty(String key, String value)
        {
            _key = key;
            Log4netCustom2.ThreadContext.Properties[_key] = value;
        }
        public AutoTrackingLogProperty(AnotherTrackingLogKeys key, String value)
        {
            _key = key.ToString();
            Log4netCustom2.ThreadContext.Properties[_key] = value;
        }

        public static implicit operator AutoTrackingLogProperty(KeyValuePair<String, String> keyValuePair)
        {
            AutoTrackingLogProperty obj = new AutoTrackingLogProperty(keyValuePair.Key, keyValuePair.Value);
            return obj;
        }

        ~AutoTrackingLogProperty()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (!_disposed)
            {
                this.Remove();
                _disposed = true;
                //GC.ReRegisterForFinalize(this);
            }
        }

        public void Remove()
        {
            Log4netCustom2.ThreadContext.Properties[_key] = null;
        }
    }
}
