using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Model;
using PSC_ERP_Business.Main.Factory;

namespace PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog
{
    public partial class frmDialogChonViTri : DevExpress.XtraEditors.XtraForm
    {
        private static frmDialogChonViTri singleton_ = null;
        public static frmDialogChonViTri Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogChonViTri();
                return singleton_;
            }
        }
        List<tblBoPhanERPNew> _viTriList = null;

        public List<tblBoPhanERPNew> ViTriList
        {
            set { _viTriList = value; }
        }
        public Int32 MaViTri
        {
            get
            {
                return Convert.ToInt32(cbViTriNew.EditValue);//trả về mã vị trí được chọn
            }
            set
            {
                cbViTriNew.EditValue = value;
            }
        }
        public frmDialogChonViTri()
        {
            InitializeComponent();
            LoadData();
        }
        public frmDialogChonViTri(List<tblBoPhanERPNew> viTriList, Boolean choPhepChonTatCa = true)
        {
            InitializeComponent();
            ViTriList = viTriList;
            LoadData(choPhepChonTatCa);
        }
        private void LoadData(Boolean choPhepChonTatCa = true)
        {
            if (_viTriList == null)
                _viTriList = BoPhanERPNew_Factory.New().GetAll().ToList();
            this.tblBoPhanERPNewBindingSource.DataSource = _viTriList;

            if (choPhepChonTatCa == true)
            {
                tblBoPhanERPNew viTri_chonTatCa = new tblBoPhanERPNew() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
                _viTriList.Insert(0, viTri_chonTatCa);
                cbViTriNew.EditValue = 0;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}