using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSC_ERP_Common
{
    public static class TaskUtil
    {
        public static Task InvokeCrossThread(Form form, Action action, Boolean wait = false)
        {
            Task task = new Task(() =>
            {
                if (form.InvokeRequired)
                    form.Invoke(action);
                else
                    action.Invoke();
            });

            task.Start();
            if (wait) task.Wait();
            return task;
        }
        public static Task<object> InvokeCrossThread(Form form, Func<object> func, Boolean wait = false)
        {
            Task<object> task = new Task<object>(() =>
            {
                Object result = null;
                if (form.InvokeRequired)
                    result = form.Invoke(func);
                else
                    result = func.Invoke();
                return result;
            });

            task.Start();
            if (wait) task.Wait();
            return task;
        }
        public static void WaitAll(this IEnumerable<Task> tasks)
        {
            if (tasks != null)
            {
                foreach (Task task in tasks)
                { task.Wait(); }
            }
        }
    }
}
