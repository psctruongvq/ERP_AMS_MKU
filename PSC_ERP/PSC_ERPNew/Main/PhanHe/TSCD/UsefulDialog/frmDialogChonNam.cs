using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;

namespace PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog
{
    public partial class frmDialogChonNam : DevExpress.XtraEditors.XtraForm
    {
        private static frmDialogChonNam singleton_ = null;
        public static frmDialogChonNam Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogChonNam();
                return singleton_;
            }
        }
        
        public Int32 Nam
        {
            get
            {
                return Convert.ToInt32(spinEditNam.EditValue);//trả về nam dc chon
            }
            set { spinEditNam.EditValue = value; }
        }

        public frmDialogChonNam()
        {
            InitializeComponent();

        }


        private void frmDialogChonNam_Load(object sender, EventArgs e)
        {
            spinEditNam.EditValue = app_users_Factory.New().SystemDate.Year;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}