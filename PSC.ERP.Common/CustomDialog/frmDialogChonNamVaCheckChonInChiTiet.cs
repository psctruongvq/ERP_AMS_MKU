using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace PSC_ERP_Common.CustomDialog
{
    public partial class frmDialogChonNamVaCheckChonInChiTiet : DevExpress.XtraEditors.XtraForm
    {
        private static frmDialogChonNamVaCheckChonInChiTiet singleton_ = null;
        public static frmDialogChonNamVaCheckChonInChiTiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogChonNamVaCheckChonInChiTiet();
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

        private static Boolean CoChiTiet_;
        public Boolean CoChiTiet
        {
            get
            {
                return chkChiTiet.Checked;//trả về nam dc chon
            }
            set { chkChiTiet.Checked = value; }
        }

        static frmDialogChonNamVaCheckChonInChiTiet()
        {
            Nam_ = DateTime.Today.Year;
            CoChiTiet_ = false;
        }
        public frmDialogChonNamVaCheckChonInChiTiet()
        {
            InitializeComponent();

        }


        private void frmDialogChonNamVaCheckChonInChiTiet_Load(object sender, EventArgs e)
        {
            spinEditNam.EditValue = Nam_;
            chkChiTiet.Checked = CoChiTiet_;
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

        private void chkChiTiet_CheckedChanged(object sender, EventArgs e)
        {
            CoChiTiet_ = chkChiTiet.Checked;
        }

    }
}