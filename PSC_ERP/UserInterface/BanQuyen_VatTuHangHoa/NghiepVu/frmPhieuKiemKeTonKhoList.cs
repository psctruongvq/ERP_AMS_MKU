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
    public partial class frmPhieuKiemKeTonKhoList : DevExpress.XtraEditors.XtraForm
    {

        KiemKeTonKhoList _kiemKeTonKhoList;
        int _maKy = 0;
        int _maKho = 0;
        long _maNhanVien = 0;
        int _ngayLap = 0;
        DateTime _tuNgay;
        DateTime _denNgay;
        int _kieu = 1;
        KiemKeTonKho _kiemKeTonKho = KiemKeTonKho.NewKiemKeTonKho();
        public KiemKeTonKho KiemKeTonKho
        {
            get { return _kiemKeTonKho; }
        }

        public frmPhieuKiemKeTonKhoList()
        {
            InitializeComponent();
            LoadForm();
        }

        public frmPhieuKiemKeTonKhoList(int maKho)
        {
            InitializeComponent();
            LoadForm();
            _kieu = 2;
            _maKho = maKho;
            _kiemKeTonKhoList = KiemKeTonKhoList.GetKiemKeTonKhoList(_maKy, _maKho, _maNhanVien, _ngayLap, _tuNgay, _denNgay);
            kiemKeTonKhoListBindingSource.DataSource = _kiemKeTonKhoList;
        }

       
        public void LoadForm()
        {
            lueKy.EditValue = null;
            lueKho.EditValue = null;
            lueNhanVien.EditValue = null;
            ceNgayLap.Checked = false;
            deTuNgay.EditValue = DateTime.Today;
            deDenNgay.EditValue = DateTime.Today;
            _tuNgay = (DateTime)deTuNgay.EditValue;
            _denNgay = (DateTime)deDenNgay.EditValue;
            deTuNgay.Enabled = false;
            deDenNgay.Enabled = false;

            _kiemKeTonKhoList = KiemKeTonKhoList.NewKiemKeTonKhoList();
            kyListBindingSource.DataSource = KyList.GetKyList();
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
            thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
        }

        private void lueKy_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueKy.EditValue = null;
            } 
        }

        private void lueKho_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueKho.EditValue = null;
            } 
        }

        private void lueNhanVien_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                lueNhanVien.EditValue = null;
            } 
        }

        private void gridView_DanhSach_DoubleClick(object sender, EventArgs e)
        {
            KiemKeTonKho _phieu = (KiemKeTonKho)gridView_DanhSach.GetFocusedRow();
            _kiemKeTonKho = KiemKeTonKho.GetKiemKeTonKho(_phieu.MaKiemKe);
            
            if (_kieu == 1)
            {
                if (_phieu != null)
                {
                    frmPhieuKiemKeTonKho frm = new frmPhieuKiemKeTonKho(_kiemKeTonKho);
                    frm.ShowDialog();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KiemKeTonKho _phieu = _kiemKeTonKhoList.AddNew();
            frmPhieuKiemKeTonKho frm = new frmPhieuKiemKeTonKho(_phieu);
            frm.ShowDialog();
            if (_phieu.MaKiemKe == 0)
                _kiemKeTonKhoList = KiemKeTonKhoList.GetKiemKeTonKhoList(_maKy, _maKho, _maNhanVien, _ngayLap, _tuNgay, _denNgay);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView_DanhSach.GetSelectedRows() == null)
                MessageBox.Show(this, "Chọn dòng muốn xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                gridView_DanhSach.DeleteSelectedRows();
        }
     
        private void btLuu()
        {
            try
            {  
                _kiemKeTonKhoList.ApplyEdit();
                _kiemKeTonKhoList.Save();

                MessageBox.Show(this, "Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(this, "Không thể lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btLuu();
        }


        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Bạn có muốn lưu không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            switch (result)
            {
                case DialogResult.Yes: btLuu(); this.Close(); break;
                case DialogResult.No: this.Close(); break;
                case DialogResult.Cancel: break;
            }
        }

        private void ceNgayLap_CheckedChanged(object sender, EventArgs e)
        {
            deTuNgay.Enabled = (bool)ceNgayLap.EditValue;
            deDenNgay.Enabled = (bool)ceNgayLap.EditValue;
            _ngayLap = (bool)ceNgayLap.EditValue ? 1 : 0;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm();
        }

        private void gridView_DanhSach_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                gridView_DanhSach.DeleteSelectedRows();
            }
        }

        private void barbt_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lueKy.GetSelectedDataRow() == null)
                _maKy = 0;
            else
                _maKy = (int)lueKy.EditValue;

            if (lueKho.GetSelectedDataRow() == null)
                _maKho = 0;
            else
                _maKho = (int)lueKho.EditValue;

            if (lueNhanVien.GetSelectedDataRow() == null)
                _maNhanVien = 0;
            else
                _maNhanVien = (long)lueNhanVien.EditValue;

            _tuNgay = (DateTime)deTuNgay.EditValue;
            _denNgay = (DateTime)deDenNgay.EditValue;

            _kiemKeTonKhoList = KiemKeTonKhoList.GetKiemKeTonKhoList(_maKy, _maKho, _maNhanVien, _ngayLap, _tuNgay, _denNgay);
            if (_kiemKeTonKhoList.Count == 0)
                MessageBox.Show("Danh Sách Phiếu rỗng!");
            kiemKeTonKhoListBindingSource.DataSource = _kiemKeTonKhoList;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

    }
}