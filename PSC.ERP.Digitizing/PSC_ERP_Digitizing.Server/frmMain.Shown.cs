using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;

namespace PSC_ERP_Digitizing.Server
{
    public partial class frmMain
    {
        void frmMain_Shown(object sender, EventArgs e)
        {
            #region Shown body
            //run HotFolder
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = _hotFolderProgramFilePath;
                Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                
            }

            //
            var regValue = _registryKey.GetValue(Application.ProductName);
            if (regValue != null)
            {
                chkKhoiDongCungWindows.Checked = true;
            }
            else
            {
                chkKhoiDongCungWindows.Checked = false;
            }


            TimerService();
            AnFormVaHienNotifyIcon();
            //ghi nhận đã load xong form
            _daLoadForm = true;
            #endregion
        }


    }
}
