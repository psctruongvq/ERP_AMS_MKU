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

namespace PSC_ERP
{
    public partial class FrmHoatDongDevEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        HoatDongDev _HoatDong = HoatDongDev.NewHoatDongDev();
        //--


        #endregion

        public FrmHoatDongDevEdit()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong();
        }
        public FrmHoatDongDevEdit(HoatDongDev hoatdong)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong(hoatdong);
        }
        #region Function


        private void DesignGridControl()
        {
        }

        private void KhoiTao()
        {
            HoatDong_bindingSource1.DataSource=typeof(HoatDongDev);

            HoatDong_bindingSource1.DataSource = _HoatDong;

            DesignGridControl();
        }

        private void KhoiTaoDinhKhoanTuDong()
        {
            _HoatDong = HoatDongDev.NewHoatDongDev();
            BindingData();
            TenHoatDong_textEdit1.Focus();

        }
        private void KhoiTaoDinhKhoanTuDong(HoatDongDev hoatdong)
        {
            _HoatDong = HoatDongDev.NewHoatDongDev();
            _HoatDong = HoatDongDev.GetHoatDongDev(hoatdong.MaHoatDong);
            BindingData();

        }

        private void BindingData()
        {
            HoatDong_bindingSource1.DataSource = _HoatDong;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = true;
            return kq;

        }


        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (KiemTraDuLieu())
                {
                    _HoatDong.ApplyEdit();
                    HoatDong_bindingSource1.EndEdit();
                    _HoatDong.Save();
                }
            }
            catch (ApplicationException ex)
            {
                kq = false;
            }
            return kq;
        }

        #endregion

        #region Event


        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                MessageBox.Show(this, "Đã lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(this, "Cậpnhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        #endregion

        private void btnLuuvaThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                KhoiTaoDinhKhoanTuDong();
            }
            else
            {
                MessageBox.Show(this, "Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}