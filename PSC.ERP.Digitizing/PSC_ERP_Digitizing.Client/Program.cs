//using PSC_ERP_Digitizing.Client.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PSC_ERP_Digitizing.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //gắn cứng userId để test
            PSC_ERP_Global.Main.UserID = 39;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmMain());
        }
    }
}
