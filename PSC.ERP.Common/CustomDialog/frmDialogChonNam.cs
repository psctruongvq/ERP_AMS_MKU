using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace PSC_ERP_Common.CustomDialog
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
        private static Int32 Nam_;
        public Int32 Nam
        {
            get
            {
                return Convert.ToInt32(spinEditNam.EditValue);//trả về nam dc chon
            }
            set { spinEditNam.EditValue = value; }
        }
        static frmDialogChonNam()
        {
            Nam_=DateTime.Today.Year;
        }
        public frmDialogChonNam()
        {
            InitializeComponent();

        }


        private void frmDialogChonNam_Load(object sender, EventArgs e)
        {
            spinEditNam.EditValue =Nam_;
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void spinEditNam_EditValueChanged(object sender, EventArgs e)
        {
            Nam_ = Convert.ToInt32(spinEditNam.EditValue);
        }
    }
}