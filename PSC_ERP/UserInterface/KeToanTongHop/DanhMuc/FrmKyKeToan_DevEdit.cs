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
    public partial class FrmKyKeToan_DevEdit : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        KyKeToanDev _kyKeToan = KyKeToanDev.NewKyKeToanDev();

        BindingSource _danhmucKyTheoTheo_BindingSource = new BindingSource();
        #endregion

        public FrmKyKeToan_DevEdit()
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaoKyKeToan();
        }
        public FrmKyKeToan_DevEdit(KyKeToanDev kyketoan)
        {
            InitializeComponent();
            KhoiTao();
            KhoiTaokyKeToan(kyketoan);
        }
        #region Function



        private void DesignGridControl()
        {
        }

        private void KhoiTao()
        {

            Ky_bindingSource1.DataSource = _kyKeToan;

            //_danhmucKyTheoTheo_BindingSource.DataSource = DanhMucKyTheoThang.CreateListDanhMucKyTheoThang();
            DesignGridControl();
        }

        private void KhoiTaoKyKeToan()
        {
            _kyKeToan = KyKeToanDev.NewKyKeToanDev();
            InitializeKyKeToan(DateTime.Today.Year, DateTime.Today.Month);
            NgayBatDau_dateEdit.Focus();
        }
        private void KhoiTaokyKeToan(KyKeToanDev kyketoan)
        {
            _kyKeToan = KyKeToanDev.NewKyKeToanDev();
            _kyKeToan = KyKeToanDev.GetKyKeToanDev(kyketoan.MaKy); 
            BindingData();

        }
        private void InitializeKyKeToan(int year, int month)
        {
            _kyKeToan.TenKy = string.Format("Tháng {0}{1}/{2}", (new String('0', 2 - month.ToString().Length)), month, year);
            _kyKeToan.NgayBatDau = PublicClass.GetFirstDayInMonth(year, month);
            _kyKeToan.NgayKetThuc = PublicClass.GetLastDayInMonth(year, month);
            BindingData();
        }

        private void BindingData()
        {
            Ky_bindingSource1.DataSource = _kyKeToan;
        }

        private bool KiemTraDuLieu()
        {
            bool kq = true;
            if (_kyKeToan.NgayBatDau == DateTime.MinValue || _kyKeToan.NgayKetThuc == DateTime.MinValue || _kyKeToan.TenKy.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ cho Kỳ kế toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (KyKeToanDev.KiemTraTrungNgayBatDauKyKeToan(_kyKeToan.MaKy, _kyKeToan.NgayBatDau))
            {
                MessageBox.Show("Trung ngày bắt đầu Kỳ kế toán!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return kq;

        }


        private bool LuuDuLieu()
        {
            bool kq = true;
            try
            {
                if (KiemTraDuLieu())
                {
                    _kyKeToan.ApplyEdit();
                    Ky_bindingSource1.EndEdit();
                    _kyKeToan.Save();
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


        #region EventHandles
        #endregion Eventhandles

        private void btnLuuvaThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (LuuDuLieu())
            {
                MessageBox.Show(this, "Đã lưu thành công, Đang thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KhoiTaoKyKeToan();
            }
            else
            {
                MessageBox.Show(this, "Cập nhật thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NgayBatDau_dateEdit_Leave(object sender, EventArgs e)
        {
            if (NgayBatDau_dateEdit.EditValue != NgayBatDau_dateEdit.OldEditValue)
            {
                if (NgayBatDau_dateEdit.EditValue != null)
                {
                    DateTime ngayOut;
                    if(DateTime.TryParse(NgayBatDau_dateEdit.EditValue.ToString(), out ngayOut))
                    {
                        InitializeKyKeToan(ngayOut.Year, ngayOut.Month);
                    }
                }
            }
        }





    }
}