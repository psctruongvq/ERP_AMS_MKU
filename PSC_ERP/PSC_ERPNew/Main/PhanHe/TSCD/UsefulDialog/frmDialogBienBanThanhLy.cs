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
    public partial class frmDialogBienBanThanhLy : DevExpress.XtraEditors.XtraForm
    {
        private static frmDialogBienBanThanhLy singleton_ = null;
        public static frmDialogBienBanThanhLy Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogBienBanThanhLy();
                return singleton_;
            }
        }
        tblChungTu _chungTu = null;
        tblNVThanhLyvaDieuChuyenNgoaiTSCD _nghiepVu = null;
        ChungTuThanhLy_DerivedFactory _factory = null;
        long _maChungTu;

        public frmDialogBienBanThanhLy()
        {
            InitializeComponent();
            LoadData();
        }
        public frmDialogBienBanThanhLy(long MaChungTu)
        {
            InitializeComponent();
            _maChungTu = MaChungTu;
            LoadData();
        }
        private void LoadData(Boolean choPhepChonTatCa = true)
        {
            //Khởi tạo factory
            _factory = ChungTuThanhLy_DerivedFactory.New();

            // Lấy chứng từ nghiệp vụ
            _chungTu = _factory.Get_ChungTu_ByMaChungTu(_maChungTu);
            _nghiepVu = _chungTu.tblNVThanhLyvaDieuChuyenNgoaiTSCDs.First();
            this.tblNVThanhLyvaDieuChuyenNgoaiTSCDBindingSource.DataSource = _nghiepVu;
        }
        private void frmDialogBienBanThanhLy_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _factory.SaveChanges();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}