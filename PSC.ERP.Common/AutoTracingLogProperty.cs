using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSC_ERP_Common
{
    public class AutoTracingLogProperty : IDisposable
    {
        String _key;
        private bool _disposed = false;
        public String Value
        {
            get { return Log4netCustom.ThreadContext.Properties[_key].ToString(); }
            set { Log4netCustom.ThreadContext.Properties[_key] = value; }
        }
        public AutoTracingLogProperty(String name, String value)
        {
            _key = name;
            Log4netCustom.ThreadContext.Properties[_key] = value;
        }
        public AutoTracingLogProperty(TracingLogPropertyKeys key, String value)
        {
            _key = key.ToString();
            Log4netCustom.ThreadContext.Properties[_key] = value;
        }

        public static implicit operator AutoTracingLogProperty(KeyValuePair<String, String> keyValuePair)
        {
            AutoTracingLogProperty obj = new AutoTracingLogProperty(keyValuePair.Key, keyValuePair.Value);
            return obj;
        }

        ~AutoTracingLogProperty()
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
            Log4netCustom.ThreadContext.Properties[_key] = null;
        }
    }
}
