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
    public partial class FrmKeHoachHopDong : DevExpress.XtraEditors.XtraForm
    {
        #region Properties and Methods
        KeHoachHopDong _keHoachHD = KeHoachHopDong.NewKeHoachHopDong();
        KeHoachHopDongList _keHoachiHopDongList = KeHoachHopDongList.NewKeHoachHopDongList();
        
        private bool KiemTraHopLe()
        {
            if (gridView_DMKeHoachHD.RowCount> 0)
            {
                int handle = -1;
                foreach (KeHoachHopDong khhd in _keHoachiHopDongList)
                {
                    handle += 1;
                    if (khhd.TenKeHoach.ToString().Length < 1)
                    {
                        MessageBox.Show("Tên Kế Hoạch Không thể trống!");
                        gridView_DMKeHoachHD.FocusedRowHandle = handle;
                        txt_TenKeHoach.Focus();
                        return false;
                    }
                    else if (khhd.MaPhongBan == 0)
                    {
                        MessageBox.Show("Vui lòng nhập vào Tên bộ phận!");
                        gridView_DMKeHoachHD.FocusedRowHandle = handle;
                        lookUpEdit_MaBoPhanChuQuan.Focus();
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion //Properties and Methods
        public FrmKeHoachHopDong()
        {
            InitializeComponent();
        }
        private void KhoiTao()
        {
            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            BoPhan _BoPhan = BoPhan.NewBoPhan(0, "Không Chọn");
            _BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            _keHoachiHopDongList = KeHoachHopDongList.GetKeHoachHopDongList();
            KeHoachHopDongList_bindingSource.DataSource = _keHoachiHopDongList;
            grd_DSKeHoachHopDong.DataSource = KeHoachHopDongList_bindingSource;
            

        }

       

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _keHoachHD = KeHoachHopDong.NewKeHoachHopDong();
            _keHoachiHopDongList.Insert(0, _keHoachHD);
            txt_MaQLKeHoach.Focus();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                gridView_DMKeHoachHD.DeleteSelectedRows();
            }
            catch
            {
                MessageBox.Show("Nhấn nút Refesh trước khi bạn muốn xóa!");
            }
        }

        private void btn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _keHoachiHopDongList = KeHoachHopDongList.GetKeHoachHopDongList();
            KeHoachHopDongList_bindingSource.DataSource = _keHoachiHopDongList;
            grd_DSKeHoachHopDong.DataSource = KeHoachHopDongList_bindingSource;
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraHopLe())
            {
                try
                {
                    _keHoachiHopDongList.ApplyEdit();
                    KeHoachHopDongList_bindingSource.EndEdit();
                    _keHoachiHopDongList.Save();
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

        private void FrmKeHoachHopDong_Load(object sender, EventArgs e)
        {
            KhoiTao();
            Utils.GridUtils.SetSTTForGridView(gridView_DMKeHoachHD, 35);
            if (KeHoachHopDongList_bindingSource.Count == 0)
            {
                btnThemMoi.PerformClick();
            }
        }

        
    }
}