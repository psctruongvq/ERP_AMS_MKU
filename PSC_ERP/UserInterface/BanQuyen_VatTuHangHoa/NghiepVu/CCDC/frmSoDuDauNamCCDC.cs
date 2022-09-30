using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using PSC_ERP_Common;
//03/04/2014
namespace PSC_ERP
{
    public partial class frmSoDuDauNamCCDC : XtraForm
    {
        #region Properties

        KyKetChuyenSoDuCCDC _kyKetChuyenSoDuCCDC = KyKetChuyenSoDuCCDC.NewKyKetChuyenSoDuCCDC();

        private int _maKy = 0;
        private int _nam = 0;
        private int _maKho = 0;
        private int _maBoPhan = -1;//Tất cả Bộ Phận
        private bool _loadformFinish = false;
        private bool _choPhepSuaDuLieu = false;
        private bool _xem = false;

        #endregion//End Properties

        #region Functions

        private Boolean GetInformations()
        {
            if (cb_NamKeToan.Text != null)
            {
                _nam = Convert.ToInt32(cb_NamKeToan.Text);
            }
            else
            {
                if (_xem)
                {
                    MessageBox.Show("Vui lòng nhập thông tin Năm cần thực hiện!", "Thông Báo");
                    return false;
                }
                cb_NamKeToan.Focus();
                _nam = 0;
            }

            if (gridLookUpEdit_Ky.Text != "")
            {
                _maKy = Convert.ToInt32(gridLookUpEdit_Ky.EditValue);
            }
            else
            {
                if (_xem)
                {
                    MessageBox.Show("Vui lòng nhập thông tin kỳ cần thực hiện!", "Thông Báo");
                    return false;
                }
                gridLookUpEdit_Ky.Focus();
                _maKy = 0;
            }

            if (gridLookUpEdit_Kho.Text != "")
            {
                _maKho = Convert.ToInt32(gridLookUpEdit_Kho.EditValue);
            }
            else
            {
                if (_xem)
                {
                    MessageBox.Show("Vui lòng nhập thông tin kho cần thực hiện!", "Thông Báo");
                    return false;
                }
                gridLookUpEdit_Kho.Focus();
                _maKho = 0;
            }
            if (lookUpEdit_PhongBan != null)
            {
                int mabophanout;
                if (int.TryParse(lookUpEdit_PhongBan.EditValue.ToString(), out mabophanout))
                {
                    _maBoPhan = mabophanout;
                }
                else _maBoPhan = -1;
            }
            else
            {
                if (_xem)
                {
                    MessageBox.Show("Vui lòng nhập thông tin Bộ phận cần thực hiện!", "Thông Báo");
                    return false;
                }
                lookUpEdit_PhongBan.Focus();
                _maBoPhan = -1;
            }
            return true;
        }

        private bool KiemTraKhoaSo()
        {
            return true;
        }

        private bool KiemTraTruocKhiCapNhat()
        {
            GetInformations();
            //if(!CCDC.KiemTraChoPhepCapNhat(_nam))
            //{
            //    MessageBox.Show("Đã phát sinh các nghiệp vụ trong năm này,Không thể cập nhật số dư đầu năm!", "Xác Nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            if (_maBoPhan <= 0)
            {
                MessageBox.Show("Không thể cập nhật trong trường hợp Bộ phận không xác định!", "Xác Nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            //if (!KyKetChuyenSoDuCCDC.KiemTraKyKetChuyenSoDuCCDCChuaKetChuyenSangKySau(_nam, _maBoPhan))
            //{
            //    MessageBox.Show("Năm này đã kết chuyển số dư sang các năm sau, không thể thực hiện!", "Xác Nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            return true;
        }

        private void SaveObject()
        {
            if (KiemTraTruocKhiCapNhat())
            {
                try
                {
                    _kyKetChuyenSoDuCCDC.ApplyEdit();
                    _kyKetChuyenSoDuCCDC.Save();
                    MessageBox.Show("Cập nhật thành công!", "Thông Báo");
                    Show_HidebtnUpdate(true);
                    UnLock_LockDuLieu(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cập nhật thất bại!", "Thông Báo");
                }
            }
        }

        private void KhoiTao()
        {                 
            kyListBindingSource.DataSource = KyList.GetKyList();
            khoBQVTListBindingSource.DataSource = KhoBQ_VTList.GetKhoVatTuList();

            congCuDungCuListBindingSource.DataSource = typeof(CCDCList);
            hangHoaBQVTListBindingSource.DataSource = typeof(HangHoaBQ_VTList);
            boPhanListBindingSource.DataSource = typeof(BoPhanList);

            hangHoaBQVTListBindingSource.DataSource = HangHoaBQ_VTList.GetHangHoaBQ_VTList(3);
            //congCuDungCuListBindingSource.DataSource = CCDCList.GetCongCuDungCuListForShowListAll(0,DateTime.Now.Date,DateTime.Now.Date,0);
            BoPhanList bophanlist = BoPhanList.GetBoPhanListKeCaBoPhanMoRong();
            BoPhan bp = BoPhan.NewBoPhan(0, "<<Tất cả>>");
            bophanlist.Insert(0, bp);
            boPhanListBindingSource.DataSource = bophanlist;

            KyKetChuyenSoDuCCDCbindingSource.DataSource = typeof(KyKetChuyenSoDuCCDC);
            CT_KetChuyenSoDuCCDCListbindingSource.DataSource = typeof(CT_KetChuyenSoDuCCDCList);

            //Load Danh Sach Nam_Ky
            for (int i = 2010; i < 2020; i++)
            {
                cb_NamKeToan.Items.Add(i);
            }
            //cb_NamKeToan.Text = DateTime.Today.Year.ToString();
            cb_NamKeToan.SelectedItem = DateTime.Today.Year as object;
            //End Load Danh Sach Nam_Ky
            _loadformFinish = true;
        }

        private void GetObjectKyKetChuySoDuCCDC(int nam, int maBoPhan)
        {
            UnLock_LockDuLieu(false);          

            if (KyKetChuyenSoDuCCDC.KiemTraTonTaiKyKetChuyenSoDuCCDC(nam, maBoPhan))
            {
                _kyKetChuyenSoDuCCDC = KyKetChuyenSoDuCCDC.GetKyKetChuyenSoDuCCDCbyNamvaMaBoPhan(nam, maBoPhan);
                BindingObjectForGridView();
                Show_HidebtnUpdate(true);
            }
            else
            {
                MessageBox.Show(string.Format("Năm {0} chưa có dữ liệu!", _nam), "Thông Báo");
                ResetObject();
            }
        }

        private void GetObjectKyKetChuySoDuCCDC_ByKy(int maky, int maBoPhan, int maKho)
        {
            UnLock_LockDuLieu(false);          

            if (KyKetChuyenSoDuCCDC.KiemTraTonTaiKyKetChuyenSoDuCCDC_ByMaKy(maky, maBoPhan,maKho))
            {
                _kyKetChuyenSoDuCCDC = KyKetChuyenSoDuCCDC.GetKyKetChuyenSoDuCCDCbyMaKyvaMaBoPhanvaMaKho(maky, maBoPhan, maKho);
                BindingObjectForGridView();              
            }
            else
            {
                MessageBox.Show(string.Format("Kỳ {0} chưa có dữ liệu!\nPhần mềm sẽ tự đổ danh mục CCDC để bạn nhập số dư!", KyKeToanDev.GetKyKeToanDev(maky).TenKy), "Thông Báo");
                ResetObject();
            }
            Show_HidebtnUpdate(true);        }

        
        private void BindingObjectForGridView()
        {
            //if (_maBoPhan > 0)
            //{
            //    CT_KetChuyenSoDuCCDCListbindingSource.DataSource = _kyKetChuyenSoDuCCDC.CT_KetChuyenSoDuCCDCList;
            //}
            //else if (_maBoPhan == 0)
            //{
            //    CT_KetChuyenSoDuCCDCListbindingSource.DataSource = CT_KetChuyenSoDuCCDCList.GetCT_KetChuyenSoDuCCDCListAllbyNam(_nam);
            //}
            //else
            //{
            //    CT_KetChuyenSoDuCCDCListbindingSource.DataSource = null;
            //}
            CT_KetChuyenSoDuCCDCListbindingSource.DataSource = _kyKetChuyenSoDuCCDC.CT_KetChuyenSoDuCCDCList;
            KyKetChuyenSoDuCCDCbindingSource.DataSource = _kyKetChuyenSoDuCCDC;           
        }

        private void ResetObject()
        {
            _kyKetChuyenSoDuCCDC = KyKetChuyenSoDuCCDC.NewKyKetChuyenSoDuCCDC(_maKy,_maBoPhan,_maKho);           
            BindingObjectForGridView();
            grdvCt_TonKhoDauKy.GroupPanelText = "Danh Sách Số Dư Công Cụ Dụng Cụ Đầu Kỳ.";
        }

        public static void NewRowGridViewDev(GridView grid)
        {
            grid.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 11F);
            grid.Appearance.Row.Options.UseFont = true;
            grid.Appearance.TopNewRow.Options.UseTextOptions = true;
            grid.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            grid.Appearance.ViewCaption.Font = new System.Drawing.Font("Times New Roman", 11F);
            grid.Appearance.ViewCaption.Options.UseFont = true;
            grid.NewItemRowText = "Thêm dòng mới";
            grid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }

        private void UnLock_LockColumnChoseGridViewDev(GridView grid, string[] fieldName, bool unlockColumn)
        {
            for (int i = 0; i < fieldName.Length; i++)
            {
                grid.Columns[fieldName[i]].OptionsColumn.AllowEdit = unlockColumn;
            }
        }

        private void UnLock_LockDuLieu(bool unlock)
        {
            //15 lock, 16 unlock
            if (unlock && _maBoPhan > 0)
            {
                btnUpdate.Caption = "Khóa dữ liệu";
                btnUpdate.ImageIndex = 15;//Lock

                textEdit_LKNhap.Enabled = true;
                textEdit_LKXuat.Enabled = true;
                textEdit_TonDauNam.Enabled = true;
                btnLuu.Enabled = true;
                //unlock dữ liệu
                UnLock_LockColumnChoseGridViewDev(grdvCt_TonKhoDauKy, new string[] { "MaHangHoa", "SoLuong", "ThanhTien" }, true);
            }
            else
            {
                _choPhepSuaDuLieu = false;
                btnUpdate.Caption = "Sửa dữ liệu";
                btnUpdate.ImageIndex = 16;//Unlock

                textEdit_LKNhap.Enabled = false;
                textEdit_LKXuat.Enabled = false;
                textEdit_TonDauNam.Enabled = false;
                btnLuu.Enabled = false;
                //Lock dữ liệu
                UnLock_LockColumnChoseGridViewDev(grdvCt_TonKhoDauKy, new string[] { "MaHangHoa", "SoLuong", "ThanhTien" }, false);
            }
        }

        private void Show_HidebtnUpdate(bool isShow)
        {
            if (isShow && _maBoPhan > 0)
            {
                btnLuu.Enabled = true;
                btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }
            else
            {
                btnLuu.Enabled = false;
                btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            }
        }

        #endregion//End Functions

        #region Events
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void cb_NamKeToan_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (_loadformFinish)
            //{
            //    btnXem.PerformClick();
            //}
        }

        private void btnKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //KetChuyen();
        }

        private void btnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _xem = true;
            if (GetInformations())
            {
                //if (_nam != 0 && _maBoPhan >= 0)
                //{
                //    gridView1.GroupPanelText = string.Format("Danh Sách Số Dư Công Cụ Dụng Cụ Năm {0}", _nam);
                //    GetObjectKyKetChuySoDuCCDC(_nam, _maBoPhan);
                //}
                if (_maKy != 0 && _maBoPhan > 0 && _maKho > 0)
                {
                    grdvCt_TonKhoDauKy.GroupPanelText = string.Format("Danh Sách Số Dư Công Cụ Dụng Cụ kỳ {0}", KyKeToanDev.GetKyKeToanDev(_maKy).TenKy);
                    GetObjectKyKetChuySoDuCCDC_ByKy(_maKy, _maBoPhan, _maKho);
                }
                else
                {
                    if (_maKy == 0)
                    {
                        DialogUtil.ShowWarning("Vui lòng chọn kỳ nhập số dư đầu kỳ!");
                    }
                    if (_maBoPhan == 0)
                    {
                        DialogUtil.ShowWarning("Vui lòng chọn bộ phận nhập số dư đầu kỳ!");
                    }
                    if (_maKho == 0)
                    {
                        DialogUtil.ShowWarning("Vui lòng chọn kho nhập số dư đầu kỳ!");
                    }
                }
            }
            _xem = false;  
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveObject();
        }

        private void btnHuyKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if(_kyKetChuyenSoDuCCDC.IsNew==false)
            //{
            //    HuyKetChuyen();
            //}
        }

        private void GridLookUpEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Undo)
            {
                GridLookUpEdit gridLUE = sender as GridLookUpEdit;
                gridLUE.EditValue = null;
            }
        }
       
        #endregion//End Events

        public frmSoDuDauNamCCDC()
        {
            InitializeComponent();
            Show_HidebtnUpdate(false);
            KhoiTao();
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _choPhepSuaDuLieu = !_choPhepSuaDuLieu;
            UnLock_LockDuLieu(_choPhepSuaDuLieu);
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //_kyKetChuyenSoDuCCDC = SoDuDauKyChuongTrinhTheoNam.NewSoDuDauKyChuongTrinhTheoNam();
            //BindingObject();
            //UnLock_LockDuLieu(true);
            //Show_HidebtnUpdate(false);
        }

        private void lookUpEdit_PhongBan_EditValueChanged(object sender, EventArgs e)
        {
            //if (_loadformFinish && _maBoPhan>=0)
            //{
            //    btnXem.PerformClick();
            //}
        }

        private void frmSoDuDauNamCCDC_Load(object sender, EventArgs e)
        {
            Utils.GridUtils.SetSTTForGridView(grdvCt_TonKhoDauKy, 50);            
        }
    }
}