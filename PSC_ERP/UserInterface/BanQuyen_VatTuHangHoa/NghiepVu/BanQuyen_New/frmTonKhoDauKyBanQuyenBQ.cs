using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
//10_04_2013

namespace PSC_ERP
{
    public partial class frmTonKhoDauKyBanQuyenBQ : DevExpress.XtraEditors.XtraForm
    {
        KetChuyenTonKhoBanQuyenBQ _ketChuyenTonKhoBanQuyen = KetChuyenTonKhoBanQuyenBQ.NewKetChuyenTonKhoBanQuyen();
        KhoBQ_VTList _khoBQ_VTList;
        HopDongMuaBanList _hopDongMuaBanList;
        NguonList _nguonList;
        int _hoanTat = -1;
        int _maCongTyCurrent = ERP_Library.Security.CurrentUser.Info.MaCongTy;

        bool _luu = false;

        public frmTonKhoDauKyBanQuyenBQ()
        {
            InitializeComponent();
            KhoiTao();
        }
        #region Function
        private void KhoiTao()
        {
            _khoBQ_VTList = KhoBQ_VTList.GetKhoBQ_VTList(1);
            khoBQVTListBindingSource.DataSource = _khoBQ_VTList;
            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(1);
            bs_ChuongTrinhConBanQuyenList.DataSource = ChuongTrinhBanQuyenConList.GetChuongTrinhBanQuyenConList();
            kyListBindingSource.DataSource = KyList.GetKyList();
            //boPhanListBindingSource.DataSource = BoPhanList.GetBoPhanList();

            BoPhanList _BoPhanList = BoPhanList.GetBoPhanListBy_All();
            //BoPhan _BoPhan = BoPhan.NewBoPhan(0, "<Tất cả>");
            //_BoPhanList.Insert(0, _BoPhan);
            boPhanListBindingSource.DataSource = _BoPhanList;

            KetChuyenTonKhoBanQuyenBindingSource.DataSource = _ketChuyenTonKhoBanQuyen;
            cT_KetChuyenTonKhoBanQuyenListBindingSource.DataSource = _ketChuyenTonKhoBanQuyen.CT_KetChuyenTonKhoBanQuyenList;
            _hopDongMuaBanList = HopDongMuaBanList.GetHopDongMuaBanList(1, 0, 0);
            HopDongMuaBan _hopDongMuaBan = HopDongMuaBan.NewHopDongMuaBan(0, "Không chọn");
            _hopDongMuaBanList.Insert(0, _hopDongMuaBan);
            HopDongMuaBanList_BindingSource.DataSource = _hopDongMuaBanList;
            _ketChuyenTonKhoBanQuyen.MaKho = _khoBQ_VTList[0].MaKho;

            _nguonList = NguonList.GetNguonList();
            Nguon _nguon = Nguon.NewNguon("Không Chọn");
            _nguonList.Insert(0, _nguon);
            NguonList_bindingSource.DataSource = _nguonList;

            ChuongTrinh_NewList _chuongTrinh_NewList = ChuongTrinh_NewList.GetChuongTrinh_NewListAll(_hoanTat, _maCongTyCurrent);
            ChuongTrinh_New ct0 = ChuongTrinh_New.NewChuongTrinh_New("Không Chọn");
            _chuongTrinh_NewList.Insert(0, ct0);
            chuongTrinh_NewListBindingSource.DataSource = _chuongTrinh_NewList;
            chuongTrinh_NewListbindingSource1.DataSource = ChuongTrinh_NewList.GetChuongTrinh_NewListAll(_hoanTat, _maCongTyCurrent); ;
        }
        //Kiem Tra Du Lieu Nhap Vao
        private bool KTDuLieuNhap()
        {
            bool _Check = true;
            if (_ketChuyenTonKhoBanQuyen.MaKy == 0)
            {
                MessageBox.Show("Hãy nhập vào giá trị Kỳ");
                _Check = false;
                gridLookUpEdit_Ky.Focus();
            }
            else if (_ketChuyenTonKhoBanQuyen.MaKho == 0)
            {
                MessageBox.Show("Hãy nhập vào giá trị Kho");
                _Check = false;
                gridLookUpEdit_Kho.Focus();
            }
            else if (_ketChuyenTonKhoBanQuyen.MaBoPhan == 0)
            {
                MessageBox.Show("Hãy nhập vào giá trị Bộ Phận");
                _Check = false;
                gridLookUpEdit_BoPhan.Focus();
            }
            return _Check;
        }
        private bool KiemTraChiTiet()
        {
            bool kq = true;
            foreach (CT_KetChuyenTonKhoBanQuyenBQ ctkc in _ketChuyenTonKhoBanQuyen.CT_KetChuyenTonKhoBanQuyenList)
            {
                if (ctkc.MaChuongTrinh == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập Tên Chương trình chính cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                //if (ctkc.MaHangHoa == 0)
                //{
                //    kq = false;
                //    MessageBox.Show(this, "Vui lòng nhập Tên Chương trình cha cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    break;
                //} 
                //if (ctkc.MaChuongTrinhCon == 0)
                //{
                //    kq = false;
                //    MessageBox.Show(this, "Vui lòng nhập Tên Chương trình con cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    break;
                //}
                if (ctkc.SoLuongTon == 0)
                {
                    kq = false;
                    MessageBox.Show(this, "Vui lòng nhập số lượng cho chi tiết", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
            }
            return kq;
        }
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
            return true;
        }
        //
        private void AllowUpdate()
        {
            btn_Sua_Khoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
        }
        private void NotAllowUpdate()
        {
            btn_Sua_Khoa.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            btnLuu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
        }
        private void KiemTrachonBoPhan()
        {
            if (_ketChuyenTonKhoBanQuyen.MaBoPhan == 0)
            {
                NotAllowUpdate();
            }
            else
            {
                AllowUpdate();
            }
        }
        #endregion Function
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }

        private void barBt_Tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KetChuyenTonKhoBanQuyenBindingSource.EndEdit();
            if (KetChuyenTonKhoBanQuyenBQ.KiemTraKetChuyenTonKhoBanQuyen(_ketChuyenTonKhoBanQuyen.MaKho, _ketChuyenTonKhoBanQuyen.MaKy, _ketChuyenTonKhoBanQuyen.MaBoPhan) == false)
            {
                _ketChuyenTonKhoBanQuyen = KetChuyenTonKhoBanQuyenBQ.NewKetChuyenTonKhoBanQuyen(_ketChuyenTonKhoBanQuyen.MaKy, _ketChuyenTonKhoBanQuyen.MaKho, _ketChuyenTonKhoBanQuyen.MaBoPhan);
            }
            else
            {
                _ketChuyenTonKhoBanQuyen = KetChuyenTonKhoBanQuyenBQ.GetKetChuyenTonKhoBanQuyen(_ketChuyenTonKhoBanQuyen.MaKy, _ketChuyenTonKhoBanQuyen.MaKho, _ketChuyenTonKhoBanQuyen.MaBoPhan);
            }
            //if (_ketChuyenTonKhoBanQuyen.MaKho == 0 || _ketChuyenTonKhoBanQuyen.MaKy == 0)
            //{
            //    MessageBox.Show("Nhập vào Kỳ cần xem số dư");
            //    gridLookUpEdit_Ky.Focus();
            //    return;
            //}
            //else if (_ketChuyenTonKhoBanQuyen.MaKho == 0)
            //{
            //    MessageBox.Show("Nhập vào Kho cần xem số dư");
            //    gridLookUpEdit_Kho.Focus();
            //    return;
            //}
            //else
            //{
            //    _ketChuyenTonKhoBanQuyen = KetChuyenTonKhoBanQuyenBQ.GetKetChuyenTonKhoBanQuyen(_ketChuyenTonKhoBanQuyen.MaKy, _ketChuyenTonKhoBanQuyen.MaKho, _ketChuyenTonKhoBanQuyen.MaBoPhan);
            //}

            cT_KetChuyenTonKhoBanQuyenListBindingSource.DataSource = _ketChuyenTonKhoBanQuyen.CT_KetChuyenTonKhoBanQuyenList;
            KetChuyenTonKhoBanQuyenBindingSource.DataSource = _ketChuyenTonKhoBanQuyen;
            if (_ketChuyenTonKhoBanQuyen.CT_KetChuyenTonKhoBanQuyenList.Count < 1)
            {
                MessageBox.Show("Bộ phận chưa có dữ liệu trong kỳ này");
            }

            //KiemTrachonBoPhan();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KTDuLieuNhap())
            {
                if (KiemTraKhoaSo(KetChuyenTonKhoBanQuyen.GetNgayKetThucCuaKy(_ketChuyenTonKhoBanQuyen.MaKy).Date))
                {
                    try
                    {
                        if (_luu)
                        {
                            _ketChuyenTonKhoBanQuyen.ApplyEdit();
                            _ketChuyenTonKhoBanQuyen.Save();
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
                }
            }
        }

        private void btnThemMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KetChuyenTonKhoBanQuyen _ketChuyenTonKhoBanQuyen = KetChuyenTonKhoBanQuyen.NewKetChuyenTonKhoBanQuyen();
            _ketChuyenTonKhoBanQuyen.MaKho = _khoBQ_VTList[0].MaKho;
            KetChuyenTonKhoBanQuyenBindingSource.DataSource = _ketChuyenTonKhoBanQuyen;
            cT_KetChuyenTonKhoBanQuyenListBindingSource.DataSource = _ketChuyenTonKhoBanQuyen.CT_KetChuyenTonKhoBanQuyenList;
        }

        private void btnHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void gridLookUpEdit_Ky_EditValueChanged(object sender, EventArgs e)
        {

            if (gridLookUpEdit_Ky.EditValue != null)
            {
                _ketChuyenTonKhoBanQuyen.MaKy = (int)gridLookUpEdit_Ky.EditValue;
                if (_ketChuyenTonKhoBanQuyen.MaBoPhan != 0 && _ketChuyenTonKhoBanQuyen.MaKy != 0)
                    barBt_Tim.PerformClick();
            }
        }

        private void gridLookUpEdit_Kho_EditValueChanged(object sender, EventArgs e)
        {
            _ketChuyenTonKhoBanQuyen.MaKho = (int)gridLookUpEdit_Kho.EditValue;
        }

        private void gridLookUpEdit_BoPhan_EditValueChanged(object sender, EventArgs e)
        {
            if (gridLookUpEdit_BoPhan.EditValue != null)
            {
                _ketChuyenTonKhoBanQuyen.MaBoPhan = (int)gridLookUpEdit_BoPhan.EditValue;
                if (_ketChuyenTonKhoBanQuyen.MaBoPhan != 0 && _ketChuyenTonKhoBanQuyen.MaKy != 0)
                    barBt_Tim.PerformClick();
            }

        }

        private void frmTonKhoDauKyBQ_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.SetSTTForGridView(grdvCt_TonKhoDauKy, 35);
            grdvCt_TonKhoDauKy.OptionsBehavior.Editable = false;
        }
        private void btn_Sua_Khoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btn_Sua_Khoa.Caption == "Sửa")
            {
                _luu = true;
                btn_Sua_Khoa.Caption = "Khóa";
                grdvCt_TonKhoDauKy.OptionsBehavior.Editable = true;

            }
            else if (btn_Sua_Khoa.Caption == "Khóa")
            {
                _luu = false;
                btn_Sua_Khoa.Caption = "Sửa";
                grdvCt_TonKhoDauKy.OptionsBehavior.Editable = false;
            }
        }

        private void GridLookUpEdit_ChuongTrinh_Popup(object sender, EventArgs e)
        {
            if (cT_KetChuyenTonKhoBanQuyenListBindingSource.Current != null && grdvCt_TonKhoDauKy.GetFocusedRow() != null)
            {
                CT_KetChuyenTonKhoBanQuyenBQ ctkc = cT_KetChuyenTonKhoBanQuyenListBindingSource.Current as CT_KetChuyenTonKhoBanQuyenBQ;
                if (ctkc.MaHangHoa != 0)
                {
                    GridLookUpEdit grid = (GridLookUpEdit)sender;
                    if (grid != null)
                    {
                        grid.Properties.View.ActiveFilterString = "MaHangHoa=" + ctkc.MaHangHoa.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập vào tên chương trình cha");
                    return;
                }
            }
        }

        private void grdvCt_TonKhoDauKy_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (cT_KetChuyenTonKhoBanQuyenListBindingSource.Current != null)
            {
                CT_KetChuyenTonKhoBanQuyen _ctkc = (CT_KetChuyenTonKhoBanQuyen)cT_KetChuyenTonKhoBanQuyenListBindingSource.Current;
                if (grdvCt_TonKhoDauKy.FocusedColumn.Name == "colMaHangHoa")
                {
                    _ctkc.MaChuongTrinhCon = 0;

                }
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

        private void repositoryItemGridLookUpEdit_HopDongList_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }

        private void GridLookUpEdit_ChuongTrinh_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }

        }

        private void GridLookUpEdit_NguonList_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }

        }

        private void GridLookUpEdit_ChuongTrinh_Popup_1(object sender, EventArgs e)
        {
            if (cT_KetChuyenTonKhoBanQuyenListBindingSource.Current != null && grdvCt_TonKhoDauKy.GetFocusedRow() != null)
            {
                CT_KetChuyenTonKhoBanQuyenBQ ctkc = cT_KetChuyenTonKhoBanQuyenListBindingSource.Current as CT_KetChuyenTonKhoBanQuyenBQ;
                if (ctkc.MaChuongTrinhCha != 0)
                {
                    GridLookUpEdit grid = (GridLookUpEdit)sender;
                    if (grid != null)
                    {
                        grid.Properties.View.ActiveFilterString = "MaChuongTrinhCha=" + ctkc.MaChuongTrinhCha.ToString() + "or MaChuongTrinh=" + ctkc.MaChuongTrinhCha.ToString();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập vào tên chương trình cha");
                    return;
                }
            }
        }
    }
}