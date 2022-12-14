using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PSC_ERP
{
    public partial class frmWaitProcess : Form
    /* Hiền Trung - 25/12/2008
     * Hiển thị form chờ trong khi đang thực hiện quá trình xử lý
     * Sử dụng : frmWaitProcess.Wait(method thực hiện, tham số (có thể có hoặc không))
     * method thực hiện : void (object , DoWorkEventArgs), trong method này cần sử dụng lệnh ở dưới để báo cáo % kết quả
        ((BackgroundWorker)sender).ReportProgress(pt);
     * */
    {
        private object _arg;

        public frmWaitProcess()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn ngừng quá trình xử lý không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                bgWorker.CancelAsync();
                this.Close();
            }
        }

        public static void Wait(DoWorkEventHandler work)
        {
            Wait(work, null);
        }

        public static void Wait(DoWorkEventHandler work, object arg)
        {
            frmWaitProcess f = new frmWaitProcess();
            f.bgWorker.DoWork += work;
            f._arg = arg;
            f.ShowDialog();            
        }

        private void frmWaitProcess_Load(object sender, EventArgs e)
        {
            bgWorker.RunWorkerAsync(_arg);
        }


        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.prbProcess.Value = e.ProgressPercentage;
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                prbProcess.Value = prbProcess.Maximum;
                MessageBox.Show("Đã xử lý thành công", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}