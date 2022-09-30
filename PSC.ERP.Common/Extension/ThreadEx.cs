using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PSC_ERP_Common.Extension
{
    public static class ThreadEx
    {
        public static void WaitAll(this IEnumerable<Thread> threads)
        {
            if (threads != null)
            {
                foreach (Thread thread in threads)
                { thread.Join(); }
            }
        }
    }
}
