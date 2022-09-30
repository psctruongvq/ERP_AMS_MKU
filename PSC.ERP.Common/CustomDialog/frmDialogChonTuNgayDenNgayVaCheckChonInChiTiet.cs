using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace PSC_ERP_Common.CustomDialog
{
    public partial class frmDialogChonTuNgayDenNgayVaCheckChonInChiTiet : DevExpress.XtraEditors.XtraForm
    {
        private static frmDialogChonTuNgayDenNgayVaCheckChonInChiTiet singleton_ = null;
        public static frmDialogChonTuNgayDenNgayVaCheckChonInChiTiet Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogChonTuNgayDenNgayVaCheckChonInChiTiet();
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
            set { dteTuNgay.DateTime = value; }
        }
        public DateTime DenNgay
        {
            get
            {
                return dteDenNgay.DateTime.Date;
            }
            set { dteDenNgay.DateTime = value; }
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
        static frmDialogChonTuNgayDenNgayVaCheckChonInChiTiet()
        {
            TuNgay_ = DateTime.Today;
            DenNgay_ = DateTime.Today;
            CoChiTiet_ = false;

        }
        public frmDialogChonTuNgayDenNgayVaCheckChonInChiTiet()
        {
            InitializeComponent();

        }


        private void frmDialogChonTuNgayDenNgayVaCheckChonInChiTiet_Load(object sender, EventArgs e)
        {
            dteTuNgay.DateTime = TuNgay_;
            dteDenNgay.DateTime = DenNgay_;
            chkChiTiet.Checked = CoChiTiet_;
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

        private void chkChiTiet_CheckedChanged(object sender, EventArgs e)
        {
            CoChiTiet_ = chkChiTiet.Checked;
        }
    }
}