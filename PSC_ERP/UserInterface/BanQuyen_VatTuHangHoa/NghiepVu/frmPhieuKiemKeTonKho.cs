using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using System.IO;
using System.Diagnostics;
namespace PSC_ERP
{
    public partial class frmPhieuKiemKeTonKho : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        bool _khoa;
        #endregion 
        public frmPhieuKiemKeTonKho(KiemKeTonKho phieu)
        {
            InitializeComponent();
            _kiemKeTonKho = phieu;
            LoadForm();
            //btnThemMoi.Enabled = false;
        }

        public frmPhieuKiemKeTonKho()
        {
            InitializeComponent();            
            LoadForm();
        }

        KiemKeTonKho _kiemKeTonKho = KiemKeTonKho.NewKiemKeTonKho();

        public void LoadForm()
        {

            btnThemMoi.Enabled = false;
            kiemKeTonKhoBindingSource.DataSource = _kiemKeTonKho;
            cTKiemKeTonKhoListBindingSource.DataSource = _kiemKeTonKho.CT_KiemKeTonKhoList;
            kyListBindingSource.DataSource = KyList.GetKyList();
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoBQ_VTList();
            thongTinNhanVienTongHopListBindingSource.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopAll();
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList();
        }
        #region Function

        private void KhoiTaoPhieu()
        {
            KiemKeTonKho _kiemKeTonKho = KiemKeTonKho.NewKiemKeTonKho();
            _kiemKeTonKho.SoPhieu = KiemKeTonKho.SetSoChungTu(_kiemKeTonKho.NgayLap);
            kiemKeTonKhoBindingSource.DataSource = _kiemKeTonKho;
            cTKiemKeTonKhoListBindingSource.DataSource = _kiemKeTonKho.CT_KiemKeTonKhoList;
        }

        private void SetTieubtn_Khoa(bool khoa)
        {
            if (khoa)
            {
                btn_Khoa.Caption = "Mở khóa lưới";
                this.btn_Khoa.ImageIndex = 13;
            }
            else
            {
                btn_Khoa.Caption = "Khóa lưới";
                this.btn_Khoa.ImageIndex = 14;
            }
        }

        private void DinhDangLuoiTheoKhoa(bool khoa)
        {
            if (khoa)
            {
                grid_ChiTiet.OptionsBehavior.ReadOnly = true;
                //MaHangHoa
                this.colTenHangHoa1.Visible = true;
                this.colTenHangHoa1.VisibleIndex = 1;
                this.colTenHangHoa1.Width = 139;

                this.colMaHangHoa.Visible = false;
                //MaHnagHoa
            }
            else
            {
                grid_ChiTiet.OptionsBehavior.ReadOnly = false;
                //MaHangHoa
                this.colMaHangHoa.Visible = true;
                this.colMaHangHoa.VisibleIndex = 1;

                this.colTenHangHoa1.Visible = false;
                //MaHnagHoa
            }
        }
        #endregion
        
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txt_SoPhieu.EditValue != null)//IF 1
            {
                string _soPhieu = txt_SoPhieu.EditValue.ToString();
                int _stt;
                if (int.TryParse(_soPhieu.Substring(0, 4), out _stt))//IF 2
                {
                    bool ktphieutrung = true;
                    if (_kiemKeTonKho.IsNew)
                    {
                        ktphieutrung = KiemKeTonKho.CheckSoPhieuKiemKe(_kiemKeTonKho.MaKiemKe, _kiemKeTonKho.SoPhieu, true);
                    }
                    else//k phai IS NEW
                    {
                        ktphieutrung = KiemKeTonKho.CheckSoPhieuKiemKe(_kiemKeTonKho.MaKiemKe, _kiemKeTonKho.SoPhieu, false);

                    }
                    if (ktphieutrung)//IF 5
                    {
                        //
                        try
                        {
                            //GH
                            if (lueKy.GetSelectedDataRow() == null)
                                MessageBox.Show(this, "Vui lòng chọn Kỳ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                if (lueKhoNhan.GetSelectedDataRow() == null)
                                    MessageBox.Show(this, "Vui lòng chọn Kho nhận", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    if (lookUpEdit_NhanVien.GetSelectedDataRow() == null)
                                        MessageBox.Show(this, "Vui lòng chọn Nhân viên kiểm kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else if (_kiemKeTonKho.CT_KiemKeTonKhoList.Count == 0)
                                        MessageBox.Show(this, "Phiếu Không Có Chi Tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    else
                                        btLuu();
                            //GH
                        }//End Try
                        catch
                        {
                            MessageBox.Show("Cập Nhật Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        //
                    }//END IF 5
                    else
                    {
                        MessageBox.Show("Trùng Số Phiếu! Không Thể Lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_SoPhieu.Focus();
                    }
                }//END IF 2
                else
                {
                    MessageBox.Show("Số Phiếu Không Hợp Lệ! 4 ký tự đầu phải là số!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_SoPhieu.Focus();
                }

            }//END IF 1
        }

        private void btLuu()
        {
            try
            {
                _kiemKeTonKho.ApplyEdit();
                _kiemKeTonKho.Save();

                MessageBox.Show(this, "Đã lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(this, "Không thể lưu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void lueKy_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lueKhoNhan_EditValueChanged(object sender, EventArgs e)
        {
            if(lueKy.EditValue!=null && lueKhoNhan.EditValue!=null)
                if(_kiemKeTonKho.MaKiemKe==0)
            {
                _kiemKeTonKho = KiemKeTonKho.NewKiemKeTonKho((int)lueKhoNhan.EditValue, (int)lueKy.EditValue);
                _kiemKeTonKho.MaNguoiLap = ERP_Library.Security.CurrentUser.Info.UserID;
                _kiemKeTonKho.SoPhieu = KiemKeTonKho.SetSoChungTu(_kiemKeTonKho.NgayLap);
                kiemKeTonKhoBindingSource.DataSource = _kiemKeTonKho;
                cTKiemKeTonKhoListBindingSource.DataSource = _kiemKeTonKho.CT_KiemKeTonKhoList;
            }
        }



        private void btnLapPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_kiemKeTonKho.IsNew)
            {
                MessageBox.Show(this, "Vui Lòng Lưu Kiểm Kê Trước Khi Lập Phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmPhieuNhapDieuChinh frm = new frmPhieuNhapDieuChinh(_kiemKeTonKho, true);
                frm.ShowDialog();
            }
        }              

        private void grid_ChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (int i in grid_ChiTiet.GetSelectedRows())
                {
                    grid_ChiTiet.DeleteRow(i);
                }
            }
        }

        private void btnLapPhieuXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_kiemKeTonKho.IsNew)
            {
                MessageBox.Show(this, "Vui Lòng Lưu Kiểm Kê Trước Khi Lập Phiếu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmPhieuNhapDieuChinh frm = new frmPhieuNhapDieuChinh(_kiemKeTonKho, false);
                frm.ShowDialog();
            }
        }

        private void grid_ChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (cTKiemKeTonKhoListBindingSource.Current != null)
            {
                CT_KiemKeTonKho _ct_kk = (CT_KiemKeTonKho)cTKiemKeTonKhoListBindingSource.Current;

                if (grid_ChiTiet.FocusedColumn.Name == "colSLKiemKe")
                {
                    decimal slKK_gv = 0;
                    if (decimal.TryParse(e.Value.ToString(), out slKK_gv))
                    {
                        if (_ct_kk.SLSoSach > 0)
                        {
                            decimal donGiaBQ = Math.Round(_ct_kk.GiaTriSoSach / _ct_kk.SLSoSach, 0, MidpointRounding.AwayFromZero);
                            _ct_kk.GiaTriKiemKe = Math.Round(_ct_kk.SLKiemKe * donGiaBQ, 0, MidpointRounding.AwayFromZero);
                        }
                    }
                }
            }
        }

        private void btn_XuatFileExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _khoa = true;
            SetTieubtn_Khoa(_khoa);
            DinhDangLuoiTheoKhoa(_khoa);
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "Excel File (*.xls)|.xls|All file (*.*)|.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    grid_ChiTiet.ExportToXls(dlg.FileName);
                    OpenFile(dlg.FileName);
                }
            
        }
        private void OpenFile(string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            if (MessageBox.Show(string.Format("Bạn có muốn mở file '{0}' không?", fileName), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
            {
                Process.Start(filePath);
            }
        }

        private void frmPhieuKiemKeTonKho_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.SetSTTForGridView(grid_ChiTiet, 35);//M
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (int i in grid_ChiTiet.GetSelectedRows())
            {
                grid_ChiTiet.DeleteRow(i);
            }
        }

        private void btn_Khoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _khoa = !_khoa;
            SetTieubtn_Khoa(_khoa);
            DinhDangLuoiTheoKhoa(_khoa);

        }
              
    }
}