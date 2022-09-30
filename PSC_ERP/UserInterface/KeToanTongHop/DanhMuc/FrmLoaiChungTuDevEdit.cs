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
    public partial class FrmLoaiChungTuDevEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        LoaiChungTuDev _LoaiChungTu = LoaiChungTuDev.NewLoaiChungTuDev();
        //--


        #endregion

        public FrmLoaiChungTuDevEdit()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong();
        }
        public FrmLoaiChungTuDevEdit(LoaiChungTuDev loaichungtu)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong(loaichungtu);
        }
        #region Function


        private void DesignNo_HeThongTaiKhoanGridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(TKNogridLookUpEdit1, No_heThongTaiKhoan1ListBindingSource1, "SoHieuTK", "MaTaiKhoan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(TKNogridLookUpEdit1, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu Tk", "Tên tài khoản" }, new int[] { 100, 150 }, false);
        }

        private void DesignCo_HeThongTaiKhoanGridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(TKCogridLookUpEdit1, Co_heThongTaiKhoan1ListBindingSource, "SoHieuTK", "MaTaiKhoan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(TKCogridLookUpEdit1, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu Tk", "Tên tài khoản" }, new int[] { 100, 150 }, false);
        }

        private void DesignGridControl()
        {
            DesignCo_HeThongTaiKhoanGridLookUpEdit();
            DesignNo_HeThongTaiKhoanGridLookUpEdit();
        }

        private void KhoiTao()
        {
            Co_heThongTaiKhoan1ListBindingSource.DataSource=typeof(HeThongTaiKhoan1List);
            No_heThongTaiKhoan1ListBindingSource1.DataSource=typeof(HeThongTaiKhoan1List);
            LoaiChungTuEdit_bindingSource1.DataSource=typeof(LoaiChungTuDev);

            HeThongTaiKhoan1List _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();// TaiKhoanList.GetTaiKhoanList();
            HeThongTaiKhoan1 httk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("<<None>>");
            _taiKhoanList.Insert(0, httk);
            Co_heThongTaiKhoan1ListBindingSource.DataSource = _taiKhoanList;
            No_heThongTaiKhoan1ListBindingSource1.DataSource = _taiKhoanList;

            LoaiChungTuEdit_bindingSource1.DataSource = _LoaiChungTu;

            DesignGridControl();
            
        }

        private void KhoiTaoDinhKhoanTuDong()
        {
            _LoaiChungTu = LoaiChungTuDev.NewLoaiChungTuDev();
            BindingData();
            TenLoaiCT_TextEdit.Focus();

        }
        private void KhoiTaoDinhKhoanTuDong(LoaiChungTuDev loaichungtu)
        {
            _LoaiChungTu = LoaiChungTuDev.NewLoaiChungTuDev();
            _LoaiChungTu = LoaiChungTuDev.GetLoaiChungTuDev(loaichungtu.MaLoaiCT);
            BindingData();

        }

        private void BindingData()
        {
            LoaiChungTuEdit_bindingSource1.DataSource = _LoaiChungTu;
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
                    _LoaiChungTu.ApplyEdit();
                    LoaiChungTuEdit_bindingSource1.EndEdit();
                    _LoaiChungTu.Save();
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