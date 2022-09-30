using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;

namespace PSC_ERP
{
    public partial class FrmPhanLoaiHopDong : DevExpress.XtraEditors.XtraForm
    {
        #region Properties and Methods
        PhanLoaiHopDong _phanLoaiHD = PhanLoaiHopDong.NewPhanLoaiHopDong();
        PhanLoaiHopDongList _phanLoaiHopDongList = PhanLoaiHopDongList.NewPhanLoaiHopDongList();
        LoaiHopDongList _loaiHopDongList;
        private bool KiemTraHopLe()
        {

            return true;
        }
        #endregion //Properties and Methods
        public FrmPhanLoaiHopDong()
        {
            InitializeComponent();
        }
        private void KhoiTao()
        {
            _phanLoaiHopDongList = PhanLoaiHopDongList.GetPhanLoaiHopDongList();
            PhanLoaiHopDongList_bindingSource.DataSource = _phanLoaiHopDongList;
            grd_DSPhanLoaiHopDong.DataSource = PhanLoaiHopDongList_bindingSource;
            _loaiHopDongList = LoaiHopDongList.GetLoaiHopDongList();
            loaiHopDongListBindingSource.DataSource = _loaiHopDongList;
            

        }

        private void FrmPhanLoaiHopDong_Load(object sender, EventArgs e)
        {
            KhoiTao();
            Utils.GridUtils.SetSTTForGridView(gridView_DMPhanLoaiHD, 35);
            if (PhanLoaiHopDongList_bindingSource.Count == 0)
            {
                btnThemMoi.PerformClick();
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _phanLoaiHD = PhanLoaiHopDong.NewPhanLoaiHopDong();
            _phanLoaiHopDongList.Insert(0, _phanLoaiHD);
            txt_MaPhanLoaiHDQL.Focus();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridView_DMPhanLoaiHD.DeleteSelectedRows();
            }
            catch
            {
                MessageBox.Show("Nhấn nút Refesh trước khi bạn muốn xóa!");
            }
        }

        private void btn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _phanLoaiHopDongList = PhanLoaiHopDongList.GetPhanLoaiHopDongList();
            PhanLoaiHopDongList_bindingSource.DataSource = _phanLoaiHopDongList;
            grd_DSPhanLoaiHopDong.DataSource = PhanLoaiHopDongList_bindingSource;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraHopLe())
            {
                try
                {
                    _phanLoaiHopDongList.ApplyEdit();
                    PhanLoaiHopDongList_bindingSource.EndEdit();
                    _phanLoaiHopDongList.Save();
                    MessageBox.Show("Cập nhật thành công!");
                }
                catch
                {
                    MessageBox.Show("Không thể lưu");
                }
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}