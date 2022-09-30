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
    public partial class frmDialogChonPhongBan : DevExpress.XtraEditors.XtraForm
    {
        private static frmDialogChonPhongBan singleton_ = null;
        public static frmDialogChonPhongBan Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogChonPhongBan();
                return singleton_;
            }
        }
        List<tblnsBoPhan> _phongBanList = null;
        public List<tblnsBoPhan> PhongBanList
        {
            set { _phongBanList = value; }
        }
        public Int32 MaPhongBan
        {
            get
            {
                return Convert.ToInt32(cbBoPhan.EditValue);//trả về mã phòng ban được chọn
            }
            set { cbBoPhan.EditValue = value; }
        }

        public frmDialogChonPhongBan()
        {
            InitializeComponent();
            LoadData();
        }
        public frmDialogChonPhongBan(List<tblnsBoPhan> phongBanList, Boolean choPhepChonTatCa = true)
        {
            InitializeComponent();
            PhongBanList = phongBanList;
            LoadData(choPhepChonTatCa);
        }
        private void LoadData(Boolean choPhepChonTatCa = true)
        {
            if (_phongBanList == null)
                _phongBanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).ToList();
            this.tblBoPhanERPNewBindingSource.DataSource = _phongBanList;

            if (choPhepChonTatCa == true)
            {
                tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
                _phongBanList.Insert(0, boPhan_chonTatCa);
            }
            //tblBoPhanERPNewBindingSource.MoveFirst();
            //Int32 maBoPhan = (tblBoPhanERPNewBindingSource.Current as tblBoPhanERPNew).MaBoPhan;
            //cbBoPhan.EditValue = maBoPhan;
        }
        private void frmDialogChonPhongBan_Load(object sender, EventArgs e)
        {

        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}