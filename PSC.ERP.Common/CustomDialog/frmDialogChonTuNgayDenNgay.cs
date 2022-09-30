using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace PSC_ERP_Common.CustomDialog
{
    public partial class frmDialogChonTuNgayDenNgay : DevExpress.XtraEditors.XtraForm
    {
        private static frmDialogChonTuNgayDenNgay singleton_ = null;
        public static frmDialogChonTuNgayDenNgay Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogChonTuNgayDenNgay();
                return singleton_;
            }
        }
        private static DateTime TuNgay_;
        private static DateTime DenNgay_;
        public DateTime TuNgay
        {
            get
            {
                return dteTuNgay.DateTime.Date;
            }
            set {dteTuNgay.DateTime = value; }
        }
        public DateTime DenNgay
        {
            get
            {
                return dteDenNgay.DateTime.Date;
            }
            set { dteDenNgay.DateTime = value; }
        }
        static frmDialogChonTuNgayDenNgay()
        {
            TuNgay_ = DateTime.Today;
            DenNgay_ = DateTime.Today;

        }
        public frmDialogChonTuNgayDenNgay()
        {
            InitializeComponent();

        }

        
        private void frmDialogChonTuNgayDenNgay_Load(object sender, EventArgs e)
        {
            dteTuNgay.DateTime = TuNgay_;
            dteDenNgay.DateTime = DenNgay_;
            dteTuNgay.Focus();
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dteTuNgay_EditValueChanged(object sender, EventArgs e)
        {
            TuNgay_ = dteTuNgay.DateTime;
        }

        private void dteDenNgay_EditValueChanged(object sender, EventArgs e)
        {
            DenNgay_ = dteDenNgay.DateTime;
        }
    }
}