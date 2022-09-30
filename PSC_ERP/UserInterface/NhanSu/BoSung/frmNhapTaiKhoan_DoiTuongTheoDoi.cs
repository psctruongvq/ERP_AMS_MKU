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
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Columns;
//05_08_2014
namespace PSC_ERP
{
    public partial class frmNhapTaiKhoan_DoiTuongTheoDoi : DevExpress.XtraEditors.XtraForm
    {
        #region Properties
        private int _maTaiKhoan = 0;
        private int _maBoPhan = 0;
        private int _maNhanVien = 0;

        private DoiTuongTheoDoiList _doiTuongTheoDoiList = DoiTuongTheoDoiList.NewDoiTuongTheoDoiList();

        //ThongTinNhanVienTongHopList _nhanvienList;
        DoiTacList _doitaclist;

        #endregion//Properties

        #region Constructors

        public frmNhapTaiKhoan_DoiTuongTheoDoi()
        {
            InitializeComponent();
            InitForm();
            LoadDatasource();

        }

        #endregion //Constructors

        #region Function
        //private void getMaBoPhan()
        //{
        //    if (grdLUEDBoPhan.EditValue != null)
        //    {
        //        int mabophanOut = 0;
        //        if(int.TryParse(grdLUEDBoPhan.EditValue.ToString(),out mabophanOut))
        //        {
        //            _maBoPhan = mabophanOut;
        //        }
        //    }
        //}

        private void getMaTaiKhoan()
        {
            if (grdLUEDHeThongTaiKhoan.EditValue != null)
            {
                int mataikhoanOut = 0;
                if (int.TryParse(grdLUEDHeThongTaiKhoan.EditValue.ToString(), out mataikhoanOut))
                {
                    _maTaiKhoan = mataikhoanOut;
                }
            }
        }

        private void getMaNhanVienPhuTrach()
        {
            if (grdLUEDNhanVien.EditValue != null)
            {
                int manhanvienOut = 0;
                if (int.TryParse(grdLUEDNhanVien.EditValue.ToString(), out manhanvienOut))
                {
                    _maNhanVien = manhanvienOut;
                }
            }
        }

        private void InitForm()
        {
            this.bindingSource1_BoPhan.DataSource = typeof(BoPhanList);
            bindingSource_DoiTuongTheoDoi.DataSource = typeof(ERP_Library.DoiTuongTheoDoiList);
            tblTaiKhoanBindingSource.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            bindingSource_HeTongTaiKhoan1.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            bindingSource1_NhanVien.DataSource = typeof(ThongTinNhanVienTongHopList);
            bindingSource_NhanVien1.DataSource = typeof(ThongTinNhanVienTongHopList);
            bindingSource_DoiTacList.DataSource = typeof(DoiTacList);
            bindingSource_DoiTacList1.DataSource = typeof(DoiTacList);
        }

        private void LoadDatasource()
        {
            tblTaiKhoanBindingSource.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            bindingSource_HeTongTaiKhoan1.DataSource = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();

            BoPhanList boPhanList = BoPhanList.GetBoPhanListByAll();
            BoPhan boPhanAdd = BoPhan.NewBoPhan(0, "Tất Cả");
            boPhanList.Insert(0, boPhanAdd);
            this.bindingSource1_BoPhan.DataSource = boPhanList;

            _doitaclist = DoiTacList.GetDoiTacListForNhapDoiTuongTheoDoiTaiKhoan();
            bindingSource_DoiTacList.DataSource = _doitaclist;
            //bindingSource_DoiTacList1.DataSource = DoiTacList.GetDoiTacListForNhapDoiTuongTheoDoiTaiKhoan();

            //BindingSourceNhanVienByBoPhan(_maBoPhan);
            bindingSource1_NhanVien.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(ERP_Library.Security.CurrentUser.Info.MaBoPhan, false);
            bindingSource_NhanVien1.DataSource = ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(ERP_Library.Security.CurrentUser.Info.MaBoPhan, false);

            //DesigngrdLUEDBoPhan();
            DesigngrdLUEDHeThongTaiKhoan();
            DesigngrdLUEDNhanVien();
            DesigngridViewDoiTuong();
            DesigngridViewDoiTuongTheoDoi();
            //DesigngridViewNhanVien();
        }

        //private void BindingSourceNhanVienByBoPhan(int maBoPhan)
        //{
        //    _nhanvienList=ThongTinNhanVienTongHopList.GetThongTinNhanVienTongHopList_BophanByThuLaoChuongTrinh(maBoPhan, false);
        //    bindingSource1_NhanVien.DataSource = _nhanvienList;
        //}

        private void DesigngrdLUEDHeThongTaiKhoan()
        {
            grdLUEDHeThongTaiKhoan.Properties.DataSource = tblTaiKhoanBindingSource;
            grdLUEDHeThongTaiKhoan.Properties.ValueMember = "MaTaiKhoan";
            grdLUEDHeThongTaiKhoan.Properties.DisplayMember = "SoHieuTK";
            grdLUEDHeThongTaiKhoan.Properties.NullText = "<<Chọn tài khoản>>";
            HamDungChung.InitGridLookUpDev(grdLUEDHeThongTaiKhoan, true, DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor);
            HamDungChung.ShowFieldGridLookUpDev(grdLUEDHeThongTaiKhoan, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu TK", "Tên tài khoản" }, new int[] { 80, 200 });
            this.grdLUEDHeThongTaiKhoan.EditValueChanged += new System.EventHandler(grdLUEDHeThongTaiKhoan_EditValueChanged);
        }

        private void DesigngrdLUEDNhanVien()
        {
            grdLUEDNhanVien.Properties.DataSource = bindingSource1_NhanVien;
            grdLUEDNhanVien.Properties.ValueMember = "MaNhanVien";
            grdLUEDNhanVien.Properties.DisplayMember = "TenNhanVien";
            grdLUEDNhanVien.Properties.NullText = "<<Chọn nhân viên phụ trách>>";
            HamDungChung.InitGridLookUpDev(grdLUEDNhanVien, true, DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor);
            HamDungChung.ShowFieldGridLookUpDev(grdLUEDNhanVien, new string[] { "TenNhanVien", "MaQLNhanVien", "TenBoPhan" }, new string[] { "Tên nhân viên", "mã nhân viên", "Tên bộ phận" }, new int[] { 100, 70, 80 });
            this.grdLUEDNhanVien.EditValueChanged += new System.EventHandler(grdLUEDNhanVien_EditValueChanged);
        }

        //private void DesigngrdLUEDBoPhan()
        //{
        //    grdLUEDBoPhan.Properties.DataSource = bindingSource1_BoPhan;
        //    grdLUEDBoPhan.Properties.ValueMember = "MaBoPhan";
        //    grdLUEDBoPhan.Properties.DisplayMember = "TenBoPhan";
        //    grdLUEDBoPhan.Properties.NullText = "<<Load nhân viên theo bộ phận>>";
        //    HamDungChung.InitGridLookUpDev(grdLUEDBoPhan, true, DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor);
        //    HamDungChung.ShowFieldGridLookUpDev(grdLUEDBoPhan, new string[] { "MaBoPhanQL", "TenBoPhan" }, new string[] { "Mã bộ phận", "Tên bộ phận" }, new int[] { 80, 100 });
        //    this.grdLUEDBoPhan.EditValueChanged += new System.EventHandler(grdLUEDBoPhan_EditValueChanged);
        //}

        private void DesigngridViewDoiTuong()
        {
            gridControlDoiTuong.DataSource = bindingSource_DoiTacList;
            HamDungChung.InitGridViewDev(gridViewDoiTuong, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

            HamDungChung.ShowFieldGridViewDev2(gridViewDoiTuong, new string[] { "Check", "MaQLDoiTac", "TenDoiTac" },
                                new string[] { "Chọn", "Mã đối tác", "Tên đối tác" },
                                             new int[] { 60, 80, 250 }, false);
            HamDungChung.AlignHeaderColumnGridViewDev(gridViewDoiTuong, new string[] { "Check", "MaQLDoiTac", "TenDoiTac" }, DevExpress.Utils.HorzAlignment.Center);

            //gridViewDoiTuong.OptionsNavigation.AutoFocusNewRow = true;
            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridViewDoiTuong, new string[] { "MaQLDoiTac", "TenDoiTac" });
            //this.gridViewDoiTuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewDoiTuong_KeyDown);

            Utils.GridUtils.SetSTTForGridView(gridViewDoiTuong, 50);//M
        }

        private void DesigngridViewDoiTuongTheoDoi()
        {
            gridControlDoiTuongTheoDoi.DataSource = bindingSource_DoiTuongTheoDoi;
            HamDungChung.InitGridViewDev(gridViewDoiTuongTheoDoi, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);
            //HamDungChung.ShowFieldGridViewDev(gridViewDoiTuongTheoDoi, new string[] { "MaTaiKhoan", "MaDoiTuong", "MaNguoiPhuTrachChinh" },
            //                    new string[] { "Tài khoản theo dõi", "Đối tượng", "Người phụ trách chính" },
            //                                 new int[] { 50, 120, 100});

            HamDungChung.ShowFieldGridViewDev(gridViewDoiTuongTheoDoi, new string[] { "MaTaiKhoan", "TenDoiTuong", "MaNguoiPhuTrachChinh", "Check" },
                                new string[] { "Tài khoản theo dõi", "Đối tượng", "Người phụ trách chính", "Chọn Gán PT" },
                                             new int[] { 50, 120, 80, 40 });

            HamDungChung.ReadOnlyColumnChoseGridViewDev(gridViewDoiTuongTheoDoi, new string[] { "MaTaiKhoan", "TenDoiTuong" });
            HamDungChung.AlignHeaderColumnGridViewDev(gridViewDoiTuongTheoDoi, new string[] { "MaTaiKhoan", "TenDoiTuong", "MaNguoiPhuTrachChinh", "Check" }, DevExpress.Utils.HorzAlignment.Center);

            //HamDungChung.NewRowGridViewDev(gridViewDoiTuongTheoDoi, NewItemRowPosition.Bottom);
            //HamDungChung.NewRowGridViewDev(gridViewDoiTuongTheoDoi);

            Utils.GridUtils.SetSTTForGridView(gridViewDoiTuongTheoDoi, 40);//M

            //MaTaiKhoan
            RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            TaiKhoanNo_GrdLU.DataSource = bindingSource_HeTongTaiKhoan1;
            TaiKhoanNo_GrdLU.DisplayMember = "SoHieuTK";
            TaiKhoanNo_GrdLU.ValueMember = "MaTaiKhoan";
            HamDungChung.InitRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridViewDoiTuongTheoDoi, "MaTaiKhoan", TaiKhoanNo_GrdLU);
            //
            //
            //MaNhanVien PhuTrach
            RepositoryItemGridLookUpEdit nhanvienphutrac_grdLU = new RepositoryItemGridLookUpEdit();
            nhanvienphutrac_grdLU.DataSource = bindingSource_NhanVien1;
            nhanvienphutrac_grdLU.DisplayMember = "TenNhanVien";
            nhanvienphutrac_grdLU.ValueMember = "MaNhanVien";
            HamDungChung.InitRepositoryItemGridLookUpDev(nhanvienphutrac_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(nhanvienphutrac_grdLU, new string[] { "TenNhanVien", "MaQLNhanVien", "TenBoPhan" }, new string[] { "Nhân viên", "Mã nhân viên", "thuộc bộ phận" }, new int[] { 100, 90, 100 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridViewDoiTuongTheoDoi, "MaNguoiPhuTrachChinh", nhanvienphutrac_grdLU);

            //MaDoiTuong
            //RepositoryItemGridLookUpEdit doiTuong_grdLU = new RepositoryItemGridLookUpEdit();
            //doiTuong_grdLU.DataSource = bindingSource_DoiTacList1;
            //doiTuong_grdLU.DisplayMember = "TenDoiTac";
            //doiTuong_grdLU.ValueMember = "MaDoiTac";
            //HamDungChung.InitRepositoryItemGridLookUpDev(doiTuong_grdLU, false, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            //HamDungChung.ShowFieldRepositoryItemGridLookUpDev(doiTuong_grdLU, new string[] { "MaQLDoiTac", "TenDoiTac", }, new string[] { "Mã đối tác", "Tên đối tác" }, new int[] { 80, 120 }, false);
            //HamDungChung.RegisterControlFieldGridViewDev(gridViewDoiTuongTheoDoi, "MaDoiTuong", doiTuong_grdLU);


            //this.gridViewDoiTuongTheoDoi.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridViewDoiTuongTheoDoi_InitNewRow);
            //////this.gridViewDoiTuongTheoDoi.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewDoiTuongTheoDoi_CellValueChanged);
            //////this.gridViewDoiTuongTheoDoi.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewDoiTuongTheoDoi_RowClick);
            //this.gridViewDoiTuongTheoDoi.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewDoiTuongTheoDoi_RowCellClick);
            this.gridViewDoiTuongTheoDoi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewDoiTuongTheoDoi_KeyDown);
            //////this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);

            //this.gridControlDoiTuongTheoDoi.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControlDoiTuongTheoDoi_ProcessGridKey);
            //this.gridViewDoiTuongTheoDoi.FocusedColumnChanged += new DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventHandler(this.gridViewDoiTuongTheoDoi_FocusedColumnChanged);
        }

        //private void DesigngridViewNhanVien()
        //{
        //    gridControlNhanVien.DataSource = bindingSource1_NhanVien;
        //    HamDungChung.InitGridViewDev(gridViewNhanVien, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, false, true, true);

        //    HamDungChung.ShowFieldGridViewDev2(gridViewNhanVien, new string[] { "Chon", "MaQLNhanVien", "TenNhanVien", "TenBoPhan" },
        //                        new string[] { "Chọn", "Mã nhân viên", "Tên nhân viên", "Bộ phận" },
        //                                     new int[] { 60, 80, 100, 100 }, false);
        //    HamDungChung.AlignHeaderColumnGridViewDev(gridViewNhanVien, new string[] { "Chon", "MaQLNhanVien", "TenNhanVien", "TenBoPhan" }, DevExpress.Utils.HorzAlignment.Center);

        //    //gridViewNhanVien.OptionsNavigation.AutoFocusNewRow = true;
        //    HamDungChung.ReadOnlyColumnChoseGridViewDev(gridViewNhanVien, new string[] { "MaQLNhanVien", "TenNhanVien", "TenBoPhan" });
        //    //this.gridViewNhanVien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridViewNhanVien_KeyDown);

        //    Utils.GridUtils.SetSTTForGridView(gridViewNhanVien, 50);//M
        //}

        private void LoadDoiTuongTheoDoi()
        {
            _doiTuongTheoDoiList = DoiTuongTheoDoiList.NewDoiTuongTheoDoiList();
            if (_maTaiKhoan != 0)
            {
                _doiTuongTheoDoiList = DoiTuongTheoDoiList.GetDoiTuongTheoDoiListByTaiKhoan(_maTaiKhoan);
            }
            bindingSource_DoiTuongTheoDoi.DataSource = _doiTuongTheoDoiList;
        }

        private bool KiemTraDaTonTaiMaTaiKhoanTheoDoiDoiTuong(int mataikhoan, long madoituong)
        {
            foreach (DoiTuongTheoDoi dttd in _doiTuongTheoDoiList)
            {
                if (dttd.MaDoiTuong == madoituong && dttd.MaTaiKhoan == mataikhoan)
                {
                    return true;
                }
            }
            return false;
        }

        private void TaoDoiTuongTheoDoiFromDoiTuong()
        {
            if (_maTaiKhoan != 0)
            {
                foreach (DoiTac dt in _doitaclist)
                {
                    if (dt.Check)
                    {
                        if (KiemTraDaTonTaiMaTaiKhoanTheoDoiDoiTuong(_maTaiKhoan, dt.MaDoiTac) == false)
                        {
                            DoiTuongTheoDoi dttd = DoiTuongTheoDoi.NewDoiTuongTheoDoi();
                            dttd.MaTaiKhoan = _maTaiKhoan;
                            dttd.MaDoiTuong = dt.MaDoiTac;
                            _doiTuongTheoDoiList.Add(dttd);
                        }
                    }
                }
                bindingSource_DoiTuongTheoDoi.DataSource = _doiTuongTheoDoiList;
                RefreshDoiTuongList();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần theo dõi đối tượng");
            }
        }

        private void UpdateMaNguoiPhuTrachFromNhanVien()
        {
            if (_maNhanVien != 0)
            {
                foreach (DoiTuongTheoDoi dttd in _doiTuongTheoDoiList)
                {
                    if (dttd.Check)
                        dttd.MaNguoiPhuTrachChinh = _maNhanVien;
                }
                bindingSource_DoiTuongTheoDoi.DataSource = _doiTuongTheoDoiList;
                RefreshDoiTuongTheoDoiList();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn viên cần gán phụ trách chính");
            }
        }

        private void RefreshDoiTuongList()
        {
            foreach (DoiTac dt in _doitaclist)
            {
                dt.Check = false;
            }
            bindingSource_DoiTacList.DataSource = _doitaclist;
            gridViewDoiTuong.RefreshData();
        }

        private void RefreshDoiTuongTheoDoiList()
        {
            foreach (DoiTuongTheoDoi dttd in _doiTuongTheoDoiList)
            {
                dttd.Check = false;
            }
            bindingSource_DoiTuongTheoDoi.DataSource = _doiTuongTheoDoiList;
            gridViewDoiTuongTheoDoi.RefreshData();
        }

        #endregion

        #region Event
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void FrmDanhSachHopDongThuChi_Load(object sender, EventArgs e)
        {
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textBoxFocus1.Focus();
            textBoxFocus2.Focus();
            try
            {
                _doiTuongTheoDoiList.ApplyEdit();
                bindingSource_DoiTuongTheoDoi.EndEdit();
                _doiTuongTheoDoiList.Save();
                MessageBox.Show("Cập nhật thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Cập nhật thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnChonDoiTuong_Click(object sender, EventArgs e)
        {
            textBoxFocus1.Focus();
            textBoxFocus2.Focus();
            TaoDoiTuongTheoDoiFromDoiTuong();
        }

        private void btnGanNhanVienPhuTrach_Click(object sender, EventArgs e)
        {
            textBoxFocus2.Focus();
            UpdateMaNguoiPhuTrachFromNhanVien();
        }

        private void checkEditDoiTuongTheoDoiAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DoiTuongTheoDoi dttd in _doiTuongTheoDoiList)
            {
                dttd.Check = checkEditDoiTuongTheoDoiAll.Checked;
            }
            bindingSource_DoiTuongTheoDoi.DataSource = _doiTuongTheoDoiList;
            gridViewDoiTuongTheoDoi.RefreshData();
        }

        #endregion

        #region EventHandle
        //private void grdLUEDBoPhan_EditValueChanged(object sender, EventArgs e)
        //{
        //    _maBoPhan = 0;
        //    getMaBoPhan();
        //    BindingSourceNhanVienByBoPhan(_maBoPhan);


        //}
        private void grdLUEDHeThongTaiKhoan_EditValueChanged(object sender, EventArgs e)
        {
            _maTaiKhoan = 0;
            getMaTaiKhoan();
            LoadDoiTuongTheoDoi();
        }

        private void grdLUEDNhanVien_EditValueChanged(object sender, EventArgs e)
        {

            _maNhanVien = 0;
            getMaNhanVienPhuTrach();
        }

        private void gridViewDoiTuongTheoDoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                HamDungChung.DeleteSelectedRowsGridViewDev(gridViewDoiTuongTheoDoi);
            }

        }
        #endregion EventHandle

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}