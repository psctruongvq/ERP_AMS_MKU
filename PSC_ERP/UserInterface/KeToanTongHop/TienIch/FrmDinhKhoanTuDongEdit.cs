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
    public partial class FrmDinhKhoanTuDongEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        DinhKhoanTuDong _DinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
        //--
        int _MaCongTy = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        #endregion

        public FrmDinhKhoanTuDongEdit()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong();
        }
        public FrmDinhKhoanTuDongEdit(DinhKhoanTuDong dinhkhoantuDong)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong(dinhkhoantuDong);
        }
        #region Function


        private void DesignLoaiChungTuGridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(LoaiChungTugridLookUpEdit1, LoaiChungTu_bindingSource1, "TenLoaiCT", "MaLoaiCT", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(LoaiChungTugridLookUpEdit1, new string[] { "TenLoaiCT" }, new string[] { "Loại chứng từ" }, new int[] { 120 }, false);
        }

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

        private void DesignKhoanMucgridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(KhoanMucgridLookUpEdit1, CauTrucDoanhThuChiPhiParent_ListBindingSource1, "Ten", "ID", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(KhoanMucgridLookUpEdit1, new string[] { "Ten", "MaQL", "TinhChatSring" }, new string[] { "Khoản mục", "Mã QL", "Thuộc" }, new int[] { 100, 150 }, false);
        }

        private void DesignHoatDonggridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(HoatDonggridLookUpEdit1, HoatDongListBindingSource, "TenHoatDong", "MaHoatDong", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(HoatDonggridLookUpEdit1, new string[] { "TenHoatDong", "MaQLHoatDong" }, new string[] { "Hoạt động", "Mã QL" }, new int[] { 100, 150 }, false);
        }

        private void DesignGridControl()
        {
            DesignLoaiChungTuGridLookUpEdit();
            DesignCo_HeThongTaiKhoanGridLookUpEdit();
            DesignNo_HeThongTaiKhoanGridLookUpEdit();
        }

        private void KhoiTao()
        {
            Co_heThongTaiKhoan1ListBindingSource.DataSource=typeof(HeThongTaiKhoan1List);
            No_heThongTaiKhoan1ListBindingSource1.DataSource=typeof(HeThongTaiKhoan1List);
            LoaiChungTu_bindingSource1.DataSource=typeof(LoaiChungTuList);
            DinhKhoanTuDong_bindingSource1.DataSource=typeof(DinhKhoanTuDong);

            HoatDongListBindingSource.DataSource = typeof(HoatDongDevList);
            CauTrucDoanhThuChiPhiParent_ListBindingSource1.DataSource = typeof(CauTrucDoanhThuChiPhiList);

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

            HeThongTaiKhoan1List _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByAll();// TaiKhoanList.GetTaiKhoanList();
            //HeThongTaiKhoan1 httk = HeThongTaiKhoan1.NewHeThongTaiKhoan1("<<None>>");
            //_taiKhoanList.Insert(0, httk);
            Co_heThongTaiKhoan1ListBindingSource.DataSource = _taiKhoanList;
            No_heThongTaiKhoan1ListBindingSource1.DataSource = _taiKhoanList;

            LoaiChungTuList loaichungtuList = LoaiChungTuList.GetLoaiChungTuList();
            LoaiChungTu_bindingSource1.DataSource = loaichungtuList;

            DinhKhoanTuDong_bindingSource1.DataSource = _DinhKhoanTuDong;

            DesignGridControl();
        }

        private void KhoiTaoDinhKhoanTuDong()
        {
            _DinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
            BindingData();
            LoaiChungTugridLookUpEdit1.Focus();

        }
        private void KhoiTaoDinhKhoanTuDong(DinhKhoanTuDong dinhkhoantudong)
        {
            _DinhKhoanTuDong = DinhKhoanTuDong.NewDinhKhoanTuDong();
            _DinhKhoanTuDong = DinhKhoanTuDong.GetDinhKhoanTuDong(dinhkhoantudong.Id);
            BindingData();

        }

        private void BindingData()
        {
            DinhKhoanTuDong_bindingSource1.DataSource = _DinhKhoanTuDong;
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
                    _DinhKhoanTuDong.ApplyEdit();
                    DinhKhoanTuDong_bindingSource1.EndEdit();
                    _DinhKhoanTuDong.Save();
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

        private void btnChonTuThuPhiList_Click(object sender, EventArgs e)
        {
            FrmThuPhiListFromOtherDB frm = new FrmThuPhiListFromOtherDB();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                if (frm.TenloaithuThuPhi != string.Empty)
                {
                    _DinhKhoanTuDong.TenDinhKhoan = frm.TenloaithuThuPhi;
                    BindingData();
                }
            }
        }





    }
}