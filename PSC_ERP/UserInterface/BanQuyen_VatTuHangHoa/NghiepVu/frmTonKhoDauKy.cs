using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//10/04/2013
namespace PSC_ERP
{
    public partial class frmTonKhoDauKy : DevExpress.XtraEditors.XtraForm
    {

        KyKetChuyenTonKho _kyKetchuyenTonKho = KyKetChuyenTonKho.NewKyKetChuyenTonKho();
        bool _luu = false;
        private bool KiemTraKhoaSo(DateTime ngayKetThucKy)
        {

            KhoaSo_UserList khoa = KhoaSo_UserList.GetKhoaSo_UserListByNgayLap(ngayKetThucKy);
            if (khoa.Count > 0)
            {
                if (khoa[0].KhoaSo == true)
                {
                    MessageBox.Show(this, "Đã khóa sổ, xin vui lòng kiểm tra lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (gridLookUpEdit_Kho.EditValue + "" == "0")
            {
                MessageBox.Show(this, "Bạn vui lòng chọn kho", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;

        }

        public frmTonKhoDauKy()
        {
            InitializeComponent();
            KhoiTao();
        }

        private void KhoiTao()
        {
            //khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoVatTuList();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
            kyListBindingSource.DataSource = KyList.GetKyList();
            kyKetChuyenTonKhoBindingSource.DataSource = _kyKetchuyenTonKho;
            cTKetChuyenTonKhoListBindingSource.DataSource = _kyKetchuyenTonKho.CT_KetChuyenTonKhoList;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barBt_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridLookUpEdit_Kho.EditValue + "" == "0")
            {
                MessageBox.Show(this, "Bạn vui lòng chọn kho", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            kyKetChuyenTonKhoBindingSource.EndEdit();            
            if (KyKetChuyenTonKho.KiemTraKyKetChuyen(_kyKetchuyenTonKho.MaKy, _kyKetchuyenTonKho.MaKho)==false)
            {
                _kyKetchuyenTonKho = KyKetChuyenTonKho.NewKyKetChuyenTonKho(_kyKetchuyenTonKho.MaKy, _kyKetchuyenTonKho.MaKho);
            }
            else
            {
                _kyKetchuyenTonKho = KyKetChuyenTonKho.GetKyKetChuyenTonKho(_kyKetchuyenTonKho.MaKy, _kyKetchuyenTonKho.MaKho);
            }
            cTKetChuyenTonKhoListBindingSource.DataSource = _kyKetchuyenTonKho.CT_KetChuyenTonKhoList;
            kyKetChuyenTonKhoBindingSource.DataSource = _kyKetchuyenTonKho;

        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraKhoaSo(KyKetChuyenTonKho.GetNgayKetThucCuaKy(_kyKetchuyenTonKho.MaKy).Date))
            {
                //
                try
                {
                    if (_luu)
                    {
                        _kyKetchuyenTonKho.ApplyEdit();
                        _kyKetchuyenTonKho.Save();
                        MessageBox.Show("Cập Nhật Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu đang khóa, không thế lưu! Hãy nhấn nút [Sửa] để cập nhật dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KyKetChuyenTonKho _kyKetchuyenTonKho = KyKetChuyenTonKho.NewKyKetChuyenTonKho();
            kyKetChuyenTonKhoBindingSource.DataSource = _kyKetchuyenTonKho;
            cTKetChuyenTonKhoListBindingSource.DataSource = _kyKetchuyenTonKho.CT_KetChuyenTonKhoList;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
        }

        private void frmTonKhoDauKy_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.SetSTTForGridView(grdvCt_TonKhoDauKy, 35);
            grdvCt_TonKhoDauKy.OptionsBehavior.Editable = false;
        }

        private void btn_Sua_Khoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(btn_Sua_Khoa.Caption=="Sửa")
            {
                _luu = true;
                btn_Sua_Khoa.Caption = "Khóa";
                grdvCt_TonKhoDauKy.OptionsBehavior.Editable = true;
 
            }
            else if(btn_Sua_Khoa.Caption=="Khóa")
            {
                _luu = false;
                btn_Sua_Khoa.Caption = "Sửa";
                grdvCt_TonKhoDauKy.OptionsBehavior.Editable = false;
            }
        }

        private void GridLookUpEdit_HangHoa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void gridLookUpEdit_Ky_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit_Ky.EditValue != null)
            {
                _kyKetchuyenTonKho.MaKy = (int)gridLookUpEdit_Ky.EditValue;
                if (_kyKetchuyenTonKho.MaKho != 0 && _kyKetchuyenTonKho.MaKy != 0)
                    barBt_Tim.PerformClick();
            }
            

        }

        private void gridLookUpEdit_Kho_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit_Kho.EditValue != null)
            {
                _kyKetchuyenTonKho.MaKho = (int)gridLookUpEdit_Kho.EditValue;
                if (_kyKetchuyenTonKho.MaKho != 0 && _kyKetchuyenTonKho.MaKy != 0)
                    barBt_Tim.PerformClick();
            }
        }

    }
}