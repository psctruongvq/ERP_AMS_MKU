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
    public partial class FrmKetChuyenXacDinhKetQuaKinhDoanhEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        KetChuyenXacDinhKetQuaKinhDoanh _KetChuyenXacDinhKetQuaKinhDoanh = KetChuyenXacDinhKetQuaKinhDoanh.NewKetChuyenXacDinhKetQuaKinhDoanh();
        BindingSource _LoaiKeChuyen_BindingSource = new BindingSource();
        BindingSource _MaLoaiKetChuyen_BindingSource = new BindingSource();
        //--


        #endregion

        public FrmKetChuyenXacDinhKetQuaKinhDoanhEdit()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoCongThucKetChuyen();
        }
        public FrmKetChuyenXacDinhKetQuaKinhDoanhEdit(KetChuyenXacDinhKetQuaKinhDoanh congthucketchuyen)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoongThucKetChuyen(congthucketchuyen);
        }
        #region Function

        //MaLoaiKeChuyen_gridLookUpEdit
        private void DesignMaLoaiKeChuyen_gridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(MaLoaiKeChuyen_gridLookUpEdit, _MaLoaiKetChuyen_BindingSource, "TenLoaiKetChuyen", "MaLoaiKetChuyen", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(MaLoaiKeChuyen_gridLookUpEdit, new string[] { "TenLoaiKetChuyen" }, new string[] { "Loại kết chuyển" }, new int[] { 120 }, true);
        }

        private void DesignLoaiKetChuyenGridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(LoaiKetChuyen_gridLookUpEdit1, _LoaiKeChuyen_BindingSource, "Ten", "Ma", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(LoaiKetChuyen_gridLookUpEdit1, new string[] { "Ten" }, new string[] { "Bên kết chuyển" }, new int[] { 120 }, false);
        }

        private void DesignTKKC_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(TKKC_gridLookUpEdit1, TKKC_heThongTaiKhoan1ListBindingSource1, "SoHieuTK", "MaTaiKhoan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(TKKC_gridLookUpEdit1, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu Tk", "Tên tài khoản" }, new int[] { 100, 150 }, false);
        }

        private void DesignTKNhan_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(TKNhan_gridLookUpEdit1, TKNhan_heThongTaiKhoan1ListBindingSource, "SoHieuTK", "MaTaiKhoan", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(TKNhan_gridLookUpEdit1, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu Tk", "Tên tài khoản" }, new int[] { 100, 150 }, false);
        }

        private void DesignGridControl()
        {
            DesignMaLoaiKeChuyen_gridLookUpEdit();
            DesignLoaiKetChuyenGridLookUpEdit();
            DesignTKKC_gridLookUpEdit1();
            DesignTKNhan_gridLookUpEdit1();
        }

        private void KhoiTao()
        {
            _MaLoaiKetChuyen_BindingSource.DataSource = typeof(List<MaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh>);
            _LoaiKeChuyen_BindingSource.DataSource = typeof(List<LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh>);
            TKNhan_heThongTaiKhoan1ListBindingSource.DataSource = typeof(HeThongTaiKhoan1List);
            TKKC_heThongTaiKhoan1ListBindingSource1.DataSource = typeof(HeThongTaiKhoan1List);
            KetChuyenXacDinhKetQuaKinhDoanhList_bindingSource.DataSource = typeof(KetChuyenXacDinhKetQuaKinhDoanh);

            HeThongTaiKhoan1List _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();// TaiKhoanList.GetTaiKhoanList();
            //HeThongTaiKhoan1 httk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("<<None>>");
            //_taiKhoanList.Insert(0, httk);
            TKNhan_heThongTaiKhoan1ListBindingSource.DataSource = _taiKhoanList;
            TKKC_heThongTaiKhoan1ListBindingSource1.DataSource = _taiKhoanList;

            List<MaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh> maLoaiKetChuyenList = MaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh.CreateListMaLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh();
            _MaLoaiKetChuyen_BindingSource.DataSource = maLoaiKetChuyenList;

            List<LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh> loaiketchuyenList = LoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh.CreateListLoaiKetChuyenXacDinhKetQuaHoatDongKinhDoanh();
            _LoaiKeChuyen_BindingSource.DataSource = loaiketchuyenList;

            KetChuyenXacDinhKetQuaKinhDoanhList_bindingSource.DataSource = _KetChuyenXacDinhKetQuaKinhDoanh;

            DesignGridControl();
        }

        private void KhoiTaoCongThucKetChuyen()
        {
            _KetChuyenXacDinhKetQuaKinhDoanh = KetChuyenXacDinhKetQuaKinhDoanh.NewKetChuyenXacDinhKetQuaKinhDoanh();
            BindingData();
            MaLoaiKeChuyen_gridLookUpEdit.Focus();

        }
        private void KhoiTaoongThucKetChuyen(KetChuyenXacDinhKetQuaKinhDoanh congthucketchuyen)
        {
            _KetChuyenXacDinhKetQuaKinhDoanh = congthucketchuyen;
            BindingData();

        }

        private void BindingData()
        {
            KetChuyenXacDinhKetQuaKinhDoanhList_bindingSource.DataSource = _KetChuyenXacDinhKetQuaKinhDoanh;
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
                    _KetChuyenXacDinhKetQuaKinhDoanh.ApplyEdit();
                    KetChuyenXacDinhKetQuaKinhDoanhList_bindingSource.EndEdit();
                    _KetChuyenXacDinhKetQuaKinhDoanh.Save();
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
                KhoiTaoCongThucKetChuyen();
            }
            else
            {
                MessageBox.Show(this, "Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}