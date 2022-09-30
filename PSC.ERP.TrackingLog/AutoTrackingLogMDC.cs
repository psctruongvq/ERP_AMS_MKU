using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_TrackingLog
{
    class AutoTrackingLogMDC : IDisposable
    {
        String _key;
        private bool _disposed = false;
        public String Value
        {
            get { return Log4netCustom2.MDC.Get(_key); }
            set { Log4netCustom2.MDC.Set(_key, value); }
        }
        public AutoTrackingLogMDC(String key, String value)
        {
            _key = key;
            Log4netCustom2.MDC.Set(_key, value);
        }
        public AutoTrackingLogMDC(AnotherTrackingLogKeys key, String value)
        {
            _key = key.ToString();
            Log4netCustom2.MDC.Set(_key, value);
        }

        public static implicit operator AutoTrackingLogMDC(KeyValuePair<String, String> keyValuePair)
        {
            AutoTrackingLogMDC obj = new AutoTrackingLogMDC(keyValuePair.Key, keyValuePair.Value);
            return obj;
        }

        ~AutoTrackingLogMDC()
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
            Log4netCustom2.MDC.Remove(_key);
        }
    }
}
