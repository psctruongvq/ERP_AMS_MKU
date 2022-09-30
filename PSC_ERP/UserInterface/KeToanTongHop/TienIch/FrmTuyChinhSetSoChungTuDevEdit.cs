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
    public partial class FrmTuyChinhSetSoChungTuDevEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        TuyChinhSetSoChungTu _tuyChinhSetSoChungTu = TuyChinhSetSoChungTu.NewTuyChinhSetSoChungTu();
        int _userCurrent = ERP_Library.Security.CurrentUser.Info.UserID;
        //--


        #endregion

        public FrmTuyChinhSetSoChungTuDevEdit()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong();
        }
        public FrmTuyChinhSetSoChungTuDevEdit(TuyChinhSetSoChungTu tuychinhsetsochungtu)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoDinhKhoanTuDong(tuychinhsetsochungtu);
        }
        #region Function


        private void DesignLoaiChungTuGridLookUpEdit()
        {
            HamDungChung.InitGridLookUpDev2(LoaiChungTugridLookUpEdit1, LoaiChungTu_bindingSource1, "TenLoaiCT", "MaLoaiCT", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(LoaiChungTugridLookUpEdit1, new string[] { "TenLoaiCT" }, new string[] { "Loại chứng từ" }, new int[] { 120 }, false);
        }


        private void DesignGridControl()
        {
            DesignLoaiChungTuGridLookUpEdit();
        }

        private void KhoiTao()
        {
            LoaiChungTu_bindingSource1.DataSource = typeof(LoaiChungTuList);
            TuyChinhSoChungTu_bindingSource1.DataSource = typeof(TuyChinhSetSoChungTu);

            LoaiChungTuList loaichungtuList = LoaiChungTuList.GetLoaiChungTuList();
            LoaiChungTu_bindingSource1.DataSource = loaichungtuList;

            TuyChinhSoChungTu_bindingSource1.DataSource = _tuyChinhSetSoChungTu;

            DesignGridControl();
        }

        private void KhoiTaoDinhKhoanTuDong()
        {
            _tuyChinhSetSoChungTu = TuyChinhSetSoChungTu.NewTuyChinhSetSoChungTu();
            _tuyChinhSetSoChungTu.UserLap = _userCurrent;
            LoaiChungTugridLookUpEdit1.Enabled = true;
            BindingData();
            LoaiChungTugridLookUpEdit1.Focus();

        }
        private void KhoiTaoDinhKhoanTuDong(TuyChinhSetSoChungTu tuychinhsetsochungtu)
        {
            _tuyChinhSetSoChungTu = TuyChinhSetSoChungTu.NewTuyChinhSetSoChungTu();
            if (tuychinhsetsochungtu.UserLap == _userCurrent)
            {
                _tuyChinhSetSoChungTu = TuyChinhSetSoChungTu.GetTuyChinhSetSoChungTu(tuychinhsetsochungtu.Id);
            }
            else
            {
                _tuyChinhSetSoChungTu.MaLoaiCT = tuychinhsetsochungtu.MaLoaiCT;
                _tuyChinhSetSoChungTu.TienTo = tuychinhsetsochungtu.TienTo;
                _tuyChinhSetSoChungTu.TrungTo = tuychinhsetsochungtu.TrungTo;
                _tuyChinhSetSoChungTu.HauTo = tuychinhsetsochungtu.HauTo;
                _tuyChinhSetSoChungTu.TongKyTuPhanSo = tuychinhsetsochungtu.TongKyTuPhanSo;
                _tuyChinhSetSoChungTu.KyTuSoBatDau = tuychinhsetsochungtu.KyTuSoBatDau;
                _tuyChinhSetSoChungTu.UserLap = _userCurrent;
            }
            BindingData();

        }

        private void BindingData()
        {
            TuyChinhSoChungTu_bindingSource1.DataSource = _tuyChinhSetSoChungTu;
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
                    _tuyChinhSetSoChungTu.ApplyEdit();
                    TuyChinhSoChungTu_bindingSource1.EndEdit();
                    _tuyChinhSetSoChungTu.Save();
                    LoaiChungTugridLookUpEdit1.Enabled = false;
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