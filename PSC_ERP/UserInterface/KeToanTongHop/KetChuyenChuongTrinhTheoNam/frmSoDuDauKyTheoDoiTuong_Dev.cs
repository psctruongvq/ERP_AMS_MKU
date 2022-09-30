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
    public partial class frmSoDuDauKyTheoDoiTuong_Dev : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        SoDuDauKyTheoDoiTuongList _SoDuDauKyList;

        public bool _isSave = false;
        public bool _isShowFromParent = false;
        public int _maTaiKhoan_focus = 0;

        private bool _loadformFinish = false;
        private bool _choPhepSuaDuLieu = false;
        private bool _xem = false;
        public int _KyKeToan = 0;
        private int _MaLoaiDoiTuong = 0;

        BindingSource _loaiDoiTuongBindingSource = new BindingSource();

        #endregion//End Properties

        #region Functions

        private void GetInformations()
        {
            _KyKeToan = 0;
            if (KyKeToan_gridLookUpEdit1.EditValue != null)
            {
                int kyKTOut = 0;
                if (int.TryParse(KyKeToan_gridLookUpEdit1.EditValue.ToString(), out kyKTOut))
                {
                    _KyKeToan = kyKTOut;
                }
            }
            //
            _MaLoaiDoiTuong = 0;
            if (LoaiDoiTuong_gridLookUpEdit.EditValue != null)
            {
                int maloaiDTOut = 0;
                if (int.TryParse(LoaiDoiTuong_gridLookUpEdit.EditValue.ToString(), out maloaiDTOut))
                {
                    _MaLoaiDoiTuong = maloaiDTOut;
                }
            }
        }

        private void LoadDataForm()
        {
            //Load Doi Tuong
            DoiTuongAllList doituongNoCoList = DoiTuongAllList.GetDoiTuongAllList_Tim("", 0); //_factory.Context.sp_AllDoiTuong(1, 0).Where(x => x.MaCongTy == _maCongTy).ToList();//Lấy đối tác
            DoiTuongAll doituongNCEmpty = DoiTuongAll.NewDoiTuongAll("");//new sp_AllDoiTuong_Result() { MaDoiTuong = 0, TenDoiTuong = "" };
            doituongNoCoList.Insert(0, doituongNCEmpty);
            AllDoiTuong_bindingSource.DataSource = doituongNoCoList;
            // tai khoan
            HeThongTaiKhoan1List hethongtaikhoanlist = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            TaiKhoanListBindingSource.DataSource = hethongtaikhoanlist;
            //KyKetoan
            kyListBindingSource.DataSource = KyList.GetKyList();
            //Loai Doituong
            _loaiDoiTuongBindingSource.DataSource = LoaiDoiTuongModify.CreateListLoaiDoiTuong();
        }

        private void LoadDataObjectForm()
        {
            GetInformations();
            _SoDuDauKyList = SoDuDauKyTheoDoiTuongList.GetSoDuDauKyTheoDoiTuongList(_KyKeToan, ERP_Library.Security.CurrentUser.Info.MaBoPhan, _MaLoaiDoiTuong);
            soDuDauKyTheoDoiTuongListBindingSource.DataSource = _SoDuDauKyList;
            Show_HidebtnUpdate(true);
        }

        private void InitializeObject()
        {
            _SoDuDauKyList = SoDuDauKyTheoDoiTuongList.NewSoDuDauKyTheoDoiTuongList();
            soDuDauKyTheoDoiTuongListBindingSource.DataSource = _SoDuDauKyList;
        }

        private bool KiemTraKhoaSo()
        {
            return true;
        }

        private bool KiemTraTruocKhiCapNhat()
        {
            GetInformations();
            if (PublicClass.KiemTraDaPhatSinhNghiepVuTrongKyHoacSauKy(_KyKeToan))
            {
                MessageBox.Show("Đã phát sinh các nghiệp vụ trong năm này,Không thể cập nhật số dư đầu năm!", "Xác Nhận", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void SaveObject()
        {
            FocustextBox.Focus();
            if (KiemTraTruocKhiCapNhat())
            {
                try
                {
                    _SoDuDauKyList.ApplyEdit();
                    _SoDuDauKyList.Save();
                    SoDuDauKyTheoDoiTuong.UpdateSoDuTaiKhoan_BySoDuTheoDoiTuong(this._KyKeToan, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
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

        private void GanBindingSource()
        {
            soDuDauKyTheoDoiTuongListBindingSource.DataSource = _SoDuDauKyList;
        }



        private void KhoiTao()
        {
            soDuDauKyTheoDoiTuongListBindingSource.DataSource = typeof(SoDuDauKyTheoDoiTuongList);
            kyListBindingSource.DataSource = typeof(KyList);
            AllDoiTuong_bindingSource.DataSource = typeof(DoiTuongAllList);
            _loaiDoiTuongBindingSource.DataSource = typeof(LoaiDoiTuongModify);
            LoadDataForm();
            InitializeObject();
            DesignControls();

            _loadformFinish = true;
        }

        private void DesignControls()
        {
            DesignKyKeToan_gridLookUpEdit1();
            DesignLoaiDoiTuong_gridLookUpEdit1();
            DesignGrid();
        }

        private void DesignKyKeToan_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(KyKeToan_gridLookUpEdit1, kyListBindingSource, "TenKy", "MaKy", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(KyKeToan_gridLookUpEdit1, new string[] { "TenKy", "NgayBatDau", "NgayKetThuc" }, new string[] { "Kỳ", "Ngày bắt đầu", "Ngày kết thúc" }, new int[] { 100, 100, 100 }, false);
        }

        private void DesignLoaiDoiTuong_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(LoaiDoiTuong_gridLookUpEdit, _loaiDoiTuongBindingSource, "MoTa", "MaLoai", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(LoaiDoiTuong_gridLookUpEdit, new string[] { "MoTa" }, new string[] { "Loại đối tượng" }, new int[] { 200 }, false);
        }

        private void DesignGrid()
        {
            gridControl1.DataSource = soDuDauKyTheoDoiTuongListBindingSource;

            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, true, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaTaiKhoan", "MaDoiTuong", "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhNoTrongKy", "PhatSinhCoTrongKy", "LuyKeNo", "LuyKeCo" },
                                new string[] { "Số hiệu TK", "Đối tượng", "Đầu kỳ Nợ", "Đầu kỳ Có", "Phát sinh Nợ", "Phát sinh Có", "Lũy kế Nợ", "Lũy kế Có" },
                                             new int[] { 90, 120, 100, 100, 100, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaTaiKhoan", "MaDoiTuong", "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhNoTrongKy", "PhatSinhCoTrongKy", "LuyKeNo", "LuyKeCo" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhNoTrongKy", "PhatSinhCoTrongKy", "LuyKeNo", "LuyKeCo" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo" }, "{0:#,###.#}");

            NewRowGridViewDev(gridView1);

            UnLock_LockColumnChoseGridViewDev(gridView1, new string[] { "MaTaiKhoan", "MaDoiTuong", "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhNoTrongKy", "PhatSinhCoTrongKy", "LuyKeNo", "LuyKeCo" }, false);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M

            //TaiKhoan
            RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanNo_GrdLU, TaiKhoanListBindingSource, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaTaiKhoan", TaiKhoanNo_GrdLU);
            TaiKhoanNo_GrdLU.ExportMode = ExportMode.DisplayText;

            //DoiTuong
            RepositoryItemGridLookUpEdit DoiTuong_grdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(DoiTuong_grdLU, AllDoiTuong_bindingSource, "TenDoiTuong", "MaDoiTuong", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(DoiTuong_grdLU, new string[] { "MaQLDoiTuong", "MaSoThue", "TenDoiTuong" }, new string[] { "Mã đối tượng", "Mã số thuế", "Tên đối tượng" }, new int[] { 90, 90, 200 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaDoiTuong", DoiTuong_grdLU);
            DoiTuong_grdLU.ExportMode = ExportMode.DisplayText;
            //

            gridView1.Columns["MaTaiKhoan"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            gridView1.Columns["MaDoiTuong"].FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;

            gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            gridView1.Appearance.GroupPanel.Options.UseFont = true;
            gridView1.GroupPanelText = "Danh Sách Số Dư Đầu Đối Tượng";

            gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
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
            if (unlock && _KyKeToan != 0)
            {
                btnUpdate.Caption = "Khóa dữ liệu";
                btnUpdate.ImageIndex = 15;//Lock
                btnLuu.Enabled = true;
                //unlock dữ liệu
                UnLock_LockColumnChoseGridViewDev(gridView1, new string[] { "MaTaiKhoan", "MaDoiTuong", "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhNoTrongKy", "PhatSinhCoTrongKy", "LuyKeNo", "LuyKeCo" }, true);
            }
            else
            {
                _choPhepSuaDuLieu = false;
                btnUpdate.Caption = "Sửa dữ liệu";
                btnUpdate.ImageIndex = 16;//Unlock
                btnLuu.Enabled = false;
                //Lock dữ liệu
                UnLock_LockColumnChoseGridViewDev(gridView1, new string[] { "MaTaiKhoan", "MaDoiTuong", "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhNoTrongKy", "PhatSinhCoTrongKy", "LuyKeNo", "LuyKeCo" }, false);
            }

        }

        private void Show_HidebtnUpdate(bool isShow)
        {
            if (isShow && _KyKeToan != 0)
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

        private void ThamChieuGoiPhiHocSinhThamGia()
        {
            GetInformations();
            if (_KyKeToan == 0)
            {
                MessageBox.Show("Vui lòng còn kỳ kế toán trước khi thực hiện!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #region Process
            FrmGetGoiPhiHocSinhFromOtherDB frm = new FrmGetGoiPhiHocSinhFromOtherDB(_KyKeToan);            
            if (frm.ShowDialog() != DialogResult.OK)
            {
                List<GoiPhiThamGiaHocSinhFromOtherDB> goiphithamgialistSelected = frm.GoiPhiThamGiaListSelected;//M
                if (goiphithamgialistSelected.Count != 0)//M
                {
                    bool codulieu = false;
                    //SoDuDauKyTheoDoiTuongList soDuDauKyListKiemTra = SoDuDauKyTheoDoiTuongList.NewSoDuDauKyTheoDoiTuongList();
                    foreach (GoiPhiThamGiaHocSinhFromOtherDB goiphiitem in goiphithamgialistSelected)
                    {
                        bool insert = true;
                        //foreach (SoDuDauKyTheoDoiTuong item in soDuDauKyListKiemTra)
                        foreach (SoDuDauKyTheoDoiTuong item in _SoDuDauKyList)
                        {
                            if (item.MaDoiTuong == goiphiitem.MaDoiTuongInt && item.MaTaiKhoan==goiphiitem.MaTaiKhoan)
                            {
                                insert = false;
                                break;
                            }
                        }

                        if (insert)
                        {
                            SoDuDauKyTheoDoiTuong soduDauAdd = SoDuDauKyTheoDoiTuong.NewSoDuDauKyTheoDoiTuong();
                            soduDauAdd.MaDoiTuong = goiphiitem.MaDoiTuongInt;
                            soduDauAdd.MaTaiKhoan = goiphiitem.MaTaiKhoan;
                            soduDauAdd.SoDuDauKyCo = goiphiitem.SoTienCuaGoi;
                            soduDauAdd.MaBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                            soduDauAdd.MaKy = _KyKeToan;
                            _SoDuDauKyList.Add(soduDauAdd);
                            codulieu = true;
                        }
                    }
                    if (codulieu)
                    {
                        UnLock_LockColumnChoseGridViewDev(gridView1, new string[] { "MaTaiKhoan" }, true);
                    }
                }
            }
            #endregion//Process
            //GanBindingSource();

        }
        #endregion//End Functions

        #region Events

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //KetChuyen();
        }

        private void btnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _xem = true;
            GetInformations();
            LoadDataObjectForm();
            //Show_HidebtnUpdate(false);
            _xem = false;
            if (_SoDuDauKyList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông Báo");
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ERP_Library.Security.CurrentUser.Info.GroupID != 2)
            {
                MessageBox.Show("User không được phân quyền chỉnh sửa số dư đầu kỳ");
                return;
            }

            SaveObject();
            if (this._isShowFromParent == true)
            {
                this._isSave = true;
                this.Close();
            }
        }

        private void btnHuyKetChuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //if(_kyKetChuyenSoDuCCDC.IsNew==false)
            //{
            //    HuyKetChuyen();
            //}
        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _choPhepSuaDuLieu = !_choPhepSuaDuLieu;
            UnLock_LockDuLieu(_choPhepSuaDuLieu);
        }



        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {

                if (_choPhepSuaDuLieu == true)
                {
                    if (KiemTraTruocKhiCapNhat())
                    {
                        if (MessageBox.Show(String.Format("Bạn có muốn xóa {0} dòng được chọn không?", gridView1.GetSelectedRows().Length), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            gridView1.DeleteSelectedRows();
                        }
                    }
                }
                else
                    MessageBox.Show("Dữ liệu đang khóa, không thể xóa!", "Thông Báo");
            }

        }


        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Value != null)
            //{
            //    if (gridView1.FocusedColumn.FieldName == "MaCCDC")
            //    {

            //        if (!CT_KetChuyenSoDuCCDC.KiemTraCCDCChuaTonTaiTrongKy((int)e.Value, _nam))
            //        {
            //            MessageBox.Show(string.Format("Công cụ dụng cụ này đã tồn tại trong năm {0}, không thể thực hiện!", _nam), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            gridView1.SetRowCellValue(e.RowHandle, "MaCCDC", 0);
            //        }
            //    }
            //}
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GetInformations();
            #region Modify Method
            #region New
            SoDuDauKyTheoDoiTuong sodudaukyCur = this.gridView1.GetRow(e.RowHandle) as SoDuDauKyTheoDoiTuong;
            if (sodudaukyCur != null)
            {
                sodudaukyCur.MaBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                sodudaukyCur.MaKy = _KyKeToan;

            }
            //gridView_ButToan.UpdateCurrentRow();
            #endregion//New

            #endregion//Modify Method

        }

        #endregion//End Events

        #region Innitialize

        public frmSoDuDauKyTheoDoiTuong_Dev()
        {
            InitializeComponent();
            Show_HidebtnUpdate(false);
            KhoiTao();
        }

        #endregion Innitialize

        private void btnThamChieuGoiPhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ThamChieuGoiPhiHocSinhThamGia();
        }

        private void frmSoDuDauKyTheoDoiTuong_Dev_Load(object sender, EventArgs e)
        {
            if (_isShowFromParent == true)
            {
                gridView1.OptionsBehavior.ReadOnly = false;

                _choPhepSuaDuLieu = true;
                UnLock_LockDuLieu(true);
                btnXem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnUpdate.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                KyKeToan_gridLookUpEdit1.EditValue = _KyKeToan;

                LoadData_TheoTaiKhoan();
                gridControl1.Focus();
                gridControl1.ForceInitialize();
              

            }
        }

        private void LoadData_TheoTaiKhoan()
        {
            GetInformations();
            _SoDuDauKyList = SoDuDauKyTheoDoiTuongList.GetSoDuDauKyTheoDoiTuongList_MaTaiKhoan(_KyKeToan, ERP_Library.Security.CurrentUser.Info.MaBoPhan, _maTaiKhoan_focus);
            soDuDauKyTheoDoiTuongListBindingSource.DataSource = _SoDuDauKyList;            
        }

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GridUtil.ExportToExcel(gridView1, true);
        }

    }
}