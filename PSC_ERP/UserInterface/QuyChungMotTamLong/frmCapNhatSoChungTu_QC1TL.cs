using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraEditors.Repository;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
//05_08_2014
namespace PSC_ERP
{
    public partial class frmCapNhatSoChungTu_QC1TL : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private int _MaLoaiChungTu = 0;
        private DateTime _TuNgay;
        public DateTime TuNgay
        {
            get { return _TuNgay; }
        }
        public bool CapNhat = false;
        #endregion//Properties

        public frmCapNhatSoChungTu_QC1TL(int maLoaiChugnTu)
        {
            InitializeComponent();
            _MaLoaiChungTu = maLoaiChugnTu;
            KhoiTao();

        }

        private void KhoiTao()
        {
            dateEdit_TuNgay.EditValue = (object)DateTime.Today.Date;
        }
        #region Function
        private bool KiemTraHopLe()
        {
            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(_TuNgay);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show(this, "Đã khóa sổ,không thể cập nhật!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (BoPhan.GetBoPhan(ERP_Library.Security.CurrentUser.Info.MaBoPhan).MaBoPhanQL == "DV02")//Không là Trung Tâm Tin Tức
            {
                MessageBox.Show(this, "Không áp dụng cho Trung Tâm Tin Tức!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true; 
        }

        #endregion

        #region Event


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        #endregion

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            button1.Focus();
            _TuNgay=(DateTime) dateEdit_TuNgay.EditValue;
            //if(KiemTraHopLe())
            //{
                ChungTu_CacLoaiQuy.CapNhapLaiSoChungTuTangLienTiepTuNgay(_MaLoaiChungTu, _TuNgay);
                MessageBox.Show("Cập nhật số chứng từ hoàn thành", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                CapNhat = true;
                this.Close();
            //}
        }

        private void dateEdit_TuNgay_EditValueChanged(object sender, EventArgs e)
        {
            DateTime tungay;
            if (dateEdit_TuNgay.EditValue != null)
            {
                if (DateTime.TryParse(dateEdit_TuNgay.EditValue.ToString(), out tungay))
                {
                    _TuNgay = (DateTime)dateEdit_TuNgay.EditValue;
                }
            }
        }






    }
}