using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace PSC_ERP
{
    public partial class frmThoiGianKhoaSo : Form
    {
        
        long coutSec = 0;
        DateTime Time = new DateTime();
        int Ky = frmKhoaSo.MaKy;

        public frmThoiGianKhoaSo()
        {
            InitializeComponent();
        }

        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        private void timer1_Tick(object sender, EventArgs e)
        {
            Time = Time.AddSeconds(1);
            if (progressBar1.Value == 200)
            {             
                this.Close();                
            }
            lblThoiGianThucHien.Text = Time.Hour.ToString() + ":" + Time.Minute.ToString() + ":" + Time.Second.ToString();
            loadFiles();          
        }

        public void loadFiles()
        {
            // Sets the progress bar's minimum value to a number representing
            // no operations complete -- in this case, no files read.
            progressBar1.Minimum = 1;
            // Sets the progress bar's maximum value to a number representing
            // all operations complete -- in this case, all five files read.
            progressBar1.Maximum = 200;
            // Sets the Step property to amount to increase with each iteration.
            // In this case, it will increase by one with every file read.
            progressBar1.Step = 5;

            // Uses a for loop to iterate through the operations to be
            // completed. In this case, five files are to be copied into memory,
            // so the loop will execute 5 times.

            progressBar1.PerformStep();
            lblThang.Text = Ky.ToString();
            //for (int i = 0; i <= 3; i++)
            //{
            //    // Inserts code to copy a file
            //    progressBar1.PerformStep();
                
            //    // Updates the label to show that a file was read.
            //    lblThang.Text = "# of Files Read = " + progressBar1.Value.ToString();
            //}
            
        }
    }
}