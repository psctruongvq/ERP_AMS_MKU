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
    public partial class FrmCauTrucDoanhThuChiPhiEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        CauTrucDoanhThuChiPhi _KhoanMuc = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
        int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;
        //--


        #endregion

        public FrmCauTrucDoanhThuChiPhiEdit()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong();
        }
        public FrmCauTrucDoanhThuChiPhiEdit(CauTrucDoanhThuChiPhi khoanmuc)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong(khoanmuc);
        }
        #region Function


        private void DesignIDParentgridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(IDParentgridLookUpEdit1, CauTrucDoanhThuChiPhiParent_ListBindingSource1, "Ten", "Id", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(IDParentgridLookUpEdit1, new string[] { "Ten", "MaQL", "TinhChatSring" }, new string[] { "Khoản mục", "Mã QL", "Thuộc" }, new int[] { 100, 150,80 }, false);
        }

        private void DesignHoatDonggridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(HoatDonggridLookUpEdit1, HoatDongListBindingSource, "TenHoatDong", "MaHoatDong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(HoatDonggridLookUpEdit1, new string[] { "TenHoatDong", "MaQLHoatDong" }, new string[] { "Hoạt động", "Mã QL" }, new int[] { 100, 150 }, false);
        }

        private void DesignGridControl()
        {
            DesignHoatDonggridLookUpEdit1();
            DesignIDParentgridLookUpEdit1();
        }

        private void KhoiTao()
        {
            HoatDongListBindingSource.DataSource=typeof(HoatDongDevList);
            CauTrucDoanhThuChiPhiParent_ListBindingSource1.DataSource=typeof(CauTrucDoanhThuChiPhiList);
            CauTrucDoanhThuChiPhi_bindingSource1.DataSource=typeof(CauTrucDoanhThuChiPhi);

            HoatDongDevList hoatdongList = HoatDongDevList.GetHoatDongDevList(_MaCongTy);
            HoatDongDev hoatdongE = HoatDongDev.NewHoatDongDev();
            hoatdongE.TenHoatDong = "<<None>>";
            hoatdongList.Insert(0, hoatdongE);
            HoatDongListBindingSource.DataSource = hoatdongList;

            CauTrucDoanhThuChiPhiList khoanmuclist = CauTrucDoanhThuChiPhiList.GetCauTrucDoanhThuChiPhiList(_MaCongTy);
            CauTrucDoanhThuChiPhi khoanmucE = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            khoanmucE.Ten = "<<None>>";
            khoanmuclist.Insert(0, khoanmucE);
            CauTrucDoanhThuChiPhiParent_ListBindingSource1.DataSource = khoanmuclist;

            CauTrucDoanhThuChiPhi_bindingSource1.DataSource = _KhoanMuc;

            DesignGridControl();
        }

        private void KhoiTaoDinhKhoanTuDong()
        {
            _KhoanMuc = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            BindingData();
            Ten_TextEdit.Focus();

        }
        private void KhoiTaoDinhKhoanTuDong(CauTrucDoanhThuChiPhi khoanmuc)
        {
            _KhoanMuc = CauTrucDoanhThuChiPhi.NewCauTrucDoanhThuChiPhi();
            _KhoanMuc = CauTrucDoanhThuChiPhi.GetCauTrucDoanhThuChiPhi(khoanmuc.Id);
            BindingData();

        }

        private void BindingData()
        {
            CauTrucDoanhThuChiPhi_bindingSource1.DataSource = _KhoanMuc;
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
                    _KhoanMuc.ApplyEdit();
                    CauTrucDoanhThuChiPhi_bindingSource1.EndEdit();
                    _KhoanMuc.Save();
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