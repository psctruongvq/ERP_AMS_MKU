using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using PSC_ERP_Business.Main.Factory;
using PSC_ERP_Business.Main.Model;
using DevExpress.XtraLayout;

namespace PSC_ERPNew.Main.PhanHe.TSCD.UsefulDialog
{
    public partial class frmDialogChonDuLieuInKiemKe : XtraForm
    {
        private static frmDialogChonDuLieuInKiemKe singleton_ = null;
        public static frmDialogChonDuLieuInKiemKe Singleton
        {
            get
            {
                if (singleton_ == null || singleton_.IsDisposed)
                    singleton_ = new frmDialogChonDuLieuInKiemKe();
                return singleton_;
            }
        }
        List<tblnsBoPhan> _phongBanList = null;
        Boolean _baoCao;
        public List<tblnsBoPhan> PhongBanList
        {
            set { _phongBanList = value; }
        }
       
        public Int32 MaPhongBan
        {
            get
            {
                return Convert.ToInt32(cbPhongBan.EditValue);//trả về mã phòng ban được chọn
            }
            set { cbPhongBan.EditValue = value; }
        }
        
        //báo cáo đối chiếu, thừa, thiếu
        public Int32 LoaiBaoCao
        {
            get
            {
                if (rad_DoiChieu.Checked)
                    return 0;               
                else if (rad_Thua.Checked)
                    return 1;
                else if (rad_Thieu.Checked)
                    return 2;
                else return 3;
            }
        }
        public DateTime DenNgay
        {
            get
            {
                return (DateTime)dteDenNgay.EditValue;
            }
            set {
                dteDenNgay.EditValue = value;
            }
        }

        public Boolean CoChiTietTaiSan
        {
            get
            {
                if (chk_ChiTietTaiSan.Checked)
                    return true;
                else
                    return false;
            }
        }

        public Int32 TSCDorCCDCorTS_CCDCTheoDoi
        {
            get
            {
                if (rad_TSCD.Checked)
                    return 1;
                else if (rad_CCDC.Checked)
                    return 2;
                else if (rad_TSCD_CCDC_TheoDoi.Checked)
                    return 3;
                else return 0;
            }
        }

        public frmDialogChonDuLieuInKiemKe()
        {
            InitializeComponent();
            LoadData();
        }
        public frmDialogChonDuLieuInKiemKe(Boolean baocao = true, Boolean choPhepChonTatCa = true)
        {
            InitializeComponent();
            _baoCao = baocao;
            LoadData(choPhepChonTatCa);
        }
        public frmDialogChonDuLieuInKiemKe(Boolean baocao, Int32 maBoPhan, DateTime ngayKiemKe ,Boolean choPhepChonTatCa)
        {
            InitializeComponent();
            _baoCao = baocao;
            LoadData(choPhepChonTatCa);
            this.MaPhongBan = maBoPhan;
            this.DenNgay = ngayKiemKe;
        }
        private void LoadData(Boolean choPhepChonTatCa = true)
        {
            if (_phongBanList == null)
                _phongBanList = BoPhan_Factory.New().GetBoPhanbyMaCongTy(ERP_Library.Security.CurrentUser.Info.MaCongTy).ToList();
            if (choPhepChonTatCa == true)
            {
                tblnsBoPhan boPhan_chonTatCa = new tblnsBoPhan() { MaBoPhan = 0, MaBoPhanQL = "<<Tất cả>>", TenBoPhan = "<<Tất cả>>" };
                _phongBanList.Insert(0, boPhan_chonTatCa);
            }
            this.tblnsBoPhan_BindingSource.DataSource = _phongBanList;
        }
        private void AnTatCaLayoutControlItem()
        {
            foreach (LayoutControlItem item in this.layoutControlGroup1.Items)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }

        private void HienTatCaLayoutControlItem()
        {
            foreach (LayoutControlItem item in this.layoutControlGroup1.Items)
            {
                item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            }
        }

        private void ShowLayoutControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

        }
        private void HideLayoutControlItem(LayoutControlItem item)
        {
            item.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        private void frmDialogChonPhongBan_Load(object sender, EventArgs e)
        {
            dteDenNgay.EditValue = this.DenNgay; //app_users_Factory.New().SystemDate;

            this.AnTatCaLayoutControlItem();
            if (_baoCao)
            {
                HienTatCaLayoutControlItem();               
            }
            else
            {
               
            }
        }

        private void btn_DongY_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_HuyBo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

    }
}