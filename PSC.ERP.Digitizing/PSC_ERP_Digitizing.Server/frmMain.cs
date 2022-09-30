using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Microsoft.Win32;
using PSC_ERP_Digitizing.Server.Util;
using System.IO;
//windows server 2012 startup folder C:\Users\cuong\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup
namespace PSC_ERP_Digitizing.Server
{
    public partial class frmMain : Form
    {
        RegistryKey _registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
        private Boolean _daLoadForm = false;


        String _customerCode;
        String _digitizingRootDirectory;
        String _trashDirectory;
        String _tempUploadDirectory;
        String _watchingDirectory;
        String _dataDirectory;
        //index
        String _indexDirectory;
        String _indexNhanSuDirectory;
        String _indexSoHoaDirectory;
        //convert
        String _convertedDirectory;
        //String _convertedNhanSuDirectory;
        //String _convertedSoHoaDirectory;
        //source
        String _sourceDirectory;
        String _sourceNhanSuDirectory;
        String _sourceSoHoaDirectory;

        String _tempForIndexDirectory;

        String _hotFolderProgramFilePath;
        //String _backupSegmentsFilePath;

        public frmMain()
        {
            _customerCode = ConfigurationManager.AppSettings["CustomerCode"];
            _digitizingRootDirectory = ConfigurationManager.AppSettings["DigitizingRootDirectory"];
            _trashDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["TrashDirectory"]);
            _tempUploadDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["TempUploadDirectory"]);
            _watchingDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["WatchingDirectory"]);
            _dataDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["DataDirectory"]);
            //index
            _indexDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["IndexDirectory"]);
            _indexNhanSuDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["IndexNhanSuDirectory"]);
            _indexSoHoaDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["IndexSoHoaDirectory"]);
            //convert
            _convertedDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["ConvertedDirectory"]);
            //_convertedNhanSuDirectory = Path.Combine(_convertedDirectory, ConfigurationManager.AppSettings["ConvertedNhanSuDirectory"]);
            //_convertedSoHoaDirectory = Path.Combine(_convertedDirectory, ConfigurationManager.AppSettings["ConvertedSoHoaDirectory"]);
            //source
            _sourceDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["SourceDirectory"]);
            _sourceNhanSuDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["SourceNhanSuDirectory"]);
            _sourceSoHoaDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["SourceSoHoaDirectory"]);

            _tempForIndexDirectory = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["TempForIndexDirectory"]);

            _hotFolderProgramFilePath = ConfigurationManager.AppSettings["HotFolderProgramFilePath"];


            //_backupSegmentsFilePath = Path.Combine(_digitizingRootDirectory, ConfigurationManager.AppSettings["BackupSegmentsFilePath"]);



            InitializeComponent();
        }


        /*
        private bool IsDateTimeForDeleteAllAttLogInAttDevice(DateTime currentDateTime)
        {
            Boolean result = false;
            //refresh appSettings section
            ConfigurationManager.RefreshSection("appSettings");

            String jsonDayListForDeleteAllAttLogInAttDevice = ConfigurationManager.AppSettings["DayListForDeleteAllAttLogInAttDevice"];
            List<Int32> dayListForDeleteAllAttLogInAttDevice = JsonConvert.DeserializeObject<List<Int32>>(jsonDayListForDeleteAllAttLogInAttDevice);

            String stringTimeForDeleteAllAttLogInAttDevice = ConfigurationManager.AppSettings["TimeForDeleteAllAttLogInAttDevice"];
            DateTime timeForDeleteAllAttLogInAttDevice = DateTime.Parse(stringTimeForDeleteAllAttLogInAttDevice);

            if (dayListForDeleteAllAttLogInAttDevice.Any(x => x == currentDateTime.Day) &&
                timeForDeleteAllAttLogInAttDevice.Hour == currentDateTime.Hour &&
                timeForDeleteAllAttLogInAttDevice.Minute == currentDateTime.Minute)
                result = true;

            return result;
        }
        */

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;

            this.Shown += frmMain_Shown;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                AnFormVaHienNotifyIcon();
            }
        }

        private void AnFormVaHienNotifyIcon()
        {
            Hide();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            //this.ShowInTaskbar = true;
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            this.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_mainTimer.Enabled == false)
            {
                DialogResult dlgResult = DialogUtil.ShowYesNo("Bạn thực sự muốn tắt ứng dụng?");
                if (dlgResult == DialogResult.Yes)
                {

                    this.Close();
                }
            }
            else
            {
                DialogUtil.ShowWarning("Hãy stop service trước khi tắt ứng dụng");
            }


        }

        private void chkKhoiDongCungWindows_CheckedChanged(object sender, EventArgs e)
        {
            if (_daLoadForm)
            {
                if (chkKhoiDongCungWindows.Checked)
                {
                    var regValue = _registryKey.GetValue(Application.ProductName);
                    if (regValue == null)
                    {
                        //dang ky khoi chay cung windows
                        _registryKey.SetValue(Application.ProductName, Application.ExecutablePath);
                    }
                }
                else
                {
                    //go bo khoi dong cung windows
                    _registryKey.DeleteValue(Application.ProductName);
                }
            }
        }

        private void btnSaveTimeAttendanceDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDeleteTimeAttendanceDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnRefreshAttendanceDevice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gridView_DSMayChamCong_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (_mainTimer.Enabled == false)
            {
                if (_daLoadForm == false || DialogResult.Yes == DialogUtil.ShowYesNo("Bạn muốn chạy service?"))
                {
                    //chạy
                    _mainTimer.Start();
                    btnStartStop.Text = "Stop service";
                }
            }
            else
            {
                if (DialogResult.Yes == DialogUtil.ShowYesNo("Bạn muốn dừng service?"))
                {
                    //stop
                    _mainTimer.Stop();
                    btnStartStop.Text = "Start service";
                }
            }
        }













    }
}
