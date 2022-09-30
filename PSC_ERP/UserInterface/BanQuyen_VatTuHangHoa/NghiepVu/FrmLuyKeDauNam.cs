using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;

namespace PSC_ERP.UserInterface.BanQuyen_VatTuHangHoa.NghiepVu
{
    public partial class FrmLuyKeDauNam : DevExpress.XtraEditors.XtraForm
    {
        LuyKeBanQuyenDauNam _lKBanQuyenDauNam;
        int _nam;

        public FrmLuyKeDauNam()
        {
            InitializeComponent();
            KhoiTao();
            
        }

        private void KhoiTao()
        {
            List<int> namList = new List<int>();
            int nam = DateTime.Today.Year;
            for (int i = nam - 1; i < nam + 3; i++)
                namList.Add(i);
            gridLookUpEdit_Nam.Properties.DataSource = namList;
            gridLookUpEdit_Nam.EditValue = nam;
        }

        private void gridLookUpEdit_Nam_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit_Nam.EditValue != null)
            {
                _nam=(int)gridLookUpEdit_Nam.EditValue;
                //_lKBanQuyenDauNam = LuyKeBanQuyenDauNam.GetLuyKeBanQuyenDauNamTheoNam(_nam);
                if (LuyKeBanQuyenDauNam.CheckTonTaiNamLuyKeBanQuyen(_nam))
                {
                    _lKBanQuyenDauNam = LuyKeBanQuyenDauNam.GetLuyKeBanQuyenDauNamTheoNam(_nam);
                }
                else
                {
                    _lKBanQuyenDauNam = LuyKeBanQuyenDauNam.NewLuyKeBanQuyenDauNam();
                    _lKBanQuyenDauNam.Nam = _nam;
                }
                LKBanQuyenDauNam_bindingSource.DataSource = _lKBanQuyenDauNam;
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LKBanQuyenDauNam_bindingSource.EndEdit();
                _lKBanQuyenDauNam.ApplyEdit();
                _lKBanQuyenDauNam.Save();
                MessageBox.Show("Cập nhật thành công!");

            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại!");
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}