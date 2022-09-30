using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ERP_Library;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Repository;

namespace PSC_ERP
{
    public partial class frmSoDuDauKyH : DevExpress.XtraEditors.XtraForm
    {
        SoDuDauKyHList _soDuDauKyList;
        HeThongTaiKhoan1List _taiKhoanList;
        KyList _kyList;

        public int _maKy = 0;
        public bool _isSave = false;
        public bool _isShowFromParent = false;
        public int _maTaiKhoan_focus = 0;

        private bool indicatorIcon = true;
        int locationGrid = 0;
        private byte CheckSuaDL = 0;

        public frmSoDuDauKyH()
        {
            InitializeComponent();
            KhoiTao();
            this.Load += frmSoDuDauKyH_Load;
            this.btnThoat.ItemClick += btnThoat_ItemClick;
            this.btnXem.ItemClick += btnXem_ItemClick;
            //this.gvSoDuDauKyH.CustomDrawRowIndicator += gvSoDuDauKyH_CustomDrawRowIndicator;
            //this.gvSoDuDauKyH.RowCountChanged += gvSoDuDauKyH_RowCountChanged;
            this.btnLuu.ItemClick += btnLuu_ItemClick;
            //this.gvSoDuDauKyH.MouseDown += gvSoDuDauKyH_MouseDown;
            this.btnSuaDuLieu.ItemClick += btnSuaDuLieu_ItemClick;
            //this.gvSoDuDauKyH.CellValueChanged += gvSoDuDauKyH_CellValueChanged;
            this.gridView1.KeyDown += gridView1_KeyDown;
        }

        void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (CheckSuaDL == 1)
                {
                    if (DialogResult.OK == (MessageBox.Show("Bạn có chắc chắn muốn xóa !!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)))
                        gridView1.DeleteSelectedRows();
                    return;
                }
                else
                    MessageBox.Show("Mở khóa dữ liệu mới được xóa !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void KhoiTao()
        {
            SoDuDauKyListBindingSource.DataSource = typeof(SoDuDauKyList);
            kyListBindingSource.DataSource = typeof(KyList);
            LoadDataForm();
            InitializeObject();
            DesignControls();
        }

        private void DesignKyKeToan_gridLookUpEdit1()
        {
            HamDungChung.InitGridLookUpDev2(lueky, kyListBindingSource, "TenKy", "MaKy", "", true, true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldGridLookUpDev2(lueky, new string[] { "TenKy", "NgayBatDau", "NgayKetThuc" }, new string[] { "Kỳ", "Ngày bắt đầu", "Ngày kết thúc" }, new int[] { 100, 100, 100 }, false);
        }

        private void DesignControls()
        {
            DesignKyKeToan_gridLookUpEdit1();
            DesignGrid();
        }

        private void InitializeObject()
        {
            _soDuDauKyList = SoDuDauKyHList.NewSoDuDauKyHList();
            SoDuDauKyListBindingSource.DataSource = _soDuDauKyList;
        }

        private void LoadDataForm()
        {
            //Load Ky
            _kyList = KyList.GetKyList();
            kyListBindingSource.DataSource = _kyList;
            // tai khoan
            _taiKhoanList = HeThongTaiKhoan1List.GetHeThongTaiKhoan1ListByCongTy();
            TaiKhoanListBindingSource.DataSource = _taiKhoanList;
        }


        private void GetInformations()
        {
            _maKy = 0;
            if (lueky.EditValue != null)
            {
                int kyKTOut = 0;
                if (int.TryParse(lueky.EditValue.ToString(), out kyKTOut))
                {
                    _maKy = kyKTOut;
                }
            }
            //
        }

        private void LoadDataObjectForm()
        {
            GetInformations();
            _soDuDauKyList = SoDuDauKyHList.GetSoDuDauKyHList(_maKy, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            SoDuDauKyListBindingSource.DataSource = _soDuDauKyList;
        }

        void btnXem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lueky.EditValue != null && lueky.EditValue != "")
            {
                LoadDataObjectForm();
                if (SoDuDauKyListBindingSource.Count == 0)
                    MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //gvSoDuDauKyH.Columns["SoDuDauKyNo"].DisplayFormat.FormatType = FormatType.Numeric;
                //gvSoDuDauKyH.Columns["SoDuDauKyNo"].DisplayFormat.FormatString = "n0";
                //gvSoDuDauKyH.Columns["SoDuDauKyCo"].DisplayFormat.FormatType = FormatType.Numeric;
                //gvSoDuDauKyH.Columns["SoDuDauKyCo"].DisplayFormat.FormatString = "n0";
                //gvSoDuDauKyH.Columns["PhatSinhTrongKyNo"].DisplayFormat.FormatType = FormatType.Numeric;
                //gvSoDuDauKyH.Columns["PhatSinhTrongKyNo"].DisplayFormat.FormatString = "n0";
                //gvSoDuDauKyH.Columns["PhatSinhTrongKyCo"].DisplayFormat.FormatType = FormatType.Numeric;
                //gvSoDuDauKyH.Columns["PhatSinhTrongKyCo"].DisplayFormat.FormatString = "n0";
                //gvSoDuDauKyH.Columns["LuyKeCo"].DisplayFormat.FormatType = FormatType.Numeric;
                //gvSoDuDauKyH.Columns["LuyKeCo"].DisplayFormat.FormatString = "n0";
                //gvSoDuDauKyH.Columns["LuyKeNo"].DisplayFormat.FormatType = FormatType.Numeric;
                //gvSoDuDauKyH.Columns["LuyKeNo"].DisplayFormat.FormatString = "n0";
                ////UnLock_LockColumnChoseGridViewDev(gvSoDuDauKyH, new string[] { "MaSoDuDauKy","MaTaiKhoan", "TenTaiKhoan", "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhTrongKyNo", "PhatSinhTrongKyCo", "LuyKeNo", "LuyKeCo" }, true);
            }
        }

        void gvSoDuDauKyH_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
        }

        void btnSuaDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckSuaDL == 1)
            {
                gridView1.OptionsBehavior.ReadOnly = true;
                btnSuaDuLieu.ImageIndex = 13;
                btnSuaDuLieu.Caption = "Sữa dữ liệu";
                btnLuu.Enabled = false;
                CheckSuaDL = 0;
            }
            else
            {
                gridView1.OptionsBehavior.ReadOnly = false;
                btnSuaDuLieu.ImageIndex = 12;
                btnSuaDuLieu.Caption = "Khóa dữ liệu";
                btnLuu.Enabled = true;
                CheckSuaDL = 1;
            }
        }

        void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lueky.Focus();
            textEdit1.Focus();
            
            _soDuDauKyList.ApplyEdit();
            SoDuDauKyListBindingSource.EndEdit();
            _soDuDauKyList.Save();
            MessageBox.Show("Lưu thành công !!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            gridView1.OptionsBehavior.ReadOnly = true;
            btnSuaDuLieu.ImageIndex = 13;
            btnSuaDuLieu.Caption = "Sữa dữ liệu";
            btnLuu.Enabled = false;
            CheckSuaDL = 0;

            if (_isShowFromParent == true)
            {
                _isSave = true;
                this.Close();
            }

            btnXem_ItemClick(sender, e);

        }

        //void gvSoDuDauKyH_RowCountChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        GridView gridview = ((GridView)sender);
        //        if (!gridview.GridControl.IsHandleCreated) return;
        //        Graphics gr = Graphics.FromHwnd(gridview.GridControl.Handle);
        //        SizeF size = gr.MeasureString(gridview.RowCount.ToString(), gridview.PaintAppearance.Row.GetFont());
        //        gridview.IndicatorWidth = Convert.ToInt32(size.Width + 0.999f) + GridPainter.Indicator.ImageSize.Width + 14;
        //    }
        //    catch
        //    {

        //    }
        //}

        //void gvSoDuDauKyH_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        //{
        //    try
        //    {
        //        GridView view = (GridView)sender;
        //        if (e.Info.IsRowIndicator && e.RowHandle >= 0)
        //        {
        //            string sText = (e.RowHandle + 1).ToString();
        //            Graphics gr = e.Info.Graphics;
        //            gr.PageUnit = GraphicsUnit.Pixel;
        //            GridView gridView = ((GridView)sender);
        //            SizeF size = gr.MeasureString(sText, e.Info.Appearance.Font);
        //            int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
        //            if (gridView.IndicatorWidth < nNewSize)
        //            {
        //                gridView.IndicatorWidth = nNewSize;
        //            }

        //            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //            //e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
        //            e.Info.DisplayText = sText;
        //        }
        //        if (!indicatorIcon)
        //            e.Info.ImageIndex = -1;

        //        if (e.RowHandle == GridControl.InvalidRowHandle)
        //        {
        //            Graphics gr = e.Info.Graphics;
        //            gr.PageUnit = GraphicsUnit.Pixel;
        //            GridView gridView = ((GridView)sender);
        //            SizeF size = gr.MeasureString("STT", e.Info.Appearance.Font);
        //            int nNewSize = Convert.ToInt32(size.Width) + GridPainter.Indicator.ImageSize.Width + 10;
        //            if (gridView.IndicatorWidth < nNewSize)
        //            {
        //                gridView.IndicatorWidth = nNewSize;
        //            }

        //            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
        //            e.Info.DisplayText = "STT";
        //            e.Info.Appearance.Font = new Font(e.Info.Appearance.Font, FontStyle.Bold);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}


        void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void NewRowGridViewDev(GridView grid)
        {
            grid.Appearance.Row.Font = new System.Drawing.Font("Times New Roman", 10F);
            grid.Appearance.Row.Options.UseFont = true;
            grid.Appearance.TopNewRow.Options.UseTextOptions = true;
            grid.Appearance.TopNewRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            grid.Appearance.ViewCaption.Font = new System.Drawing.Font("Times New Roman", 10F);
            grid.Appearance.ViewCaption.Options.UseFont = true;
            grid.NewItemRowText = "Thêm dòng mới";
            grid.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
        }

        void frmSoDuDauKyH_Load(object sender, EventArgs e)
        {
            if (_isShowFromParent == true)
            {
                gridView1.OptionsBehavior.ReadOnly = false;
                btnSuaDuLieu.ImageIndex = 12;
                btnSuaDuLieu.Caption = "Khóa dữ liệu";
                btnLuu.Enabled = true;
                CheckSuaDL = 1;
                btnXem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                btnSuaDuLieu.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;


                lueky.EditValue = _maKy;
                LoadData_TaiKhoanCon();

                gridControl1.Focus();
                gridControl1.ForceInitialize();
                int i = 0;
                foreach (SoDuDauKyH obj in _soDuDauKyList)
                {
                    if (obj.MaTaiKhoan == this._maTaiKhoan_focus)
                    {
                        gridView1.FocusedRowHandle = i;
                        gridView1.FocusedColumn = gridView1.Columns["SoDuDauKyNo"];
                        //gridView1.SelectCell(i,gridView1.Columns["SoDuDauKyNo"]);
                        gridView1.MakeRowVisible(i);
                        gridView1.ShowEditor();

                        break;
                    }
                    i++;
                }

            }

        }

        private void DesignGrid()
        {

            gridControl1.DataSource = SoDuDauKyListBindingSource;
            gridView1.OptionsBehavior.ReadOnly = true;
            HamDungChung.InitGridViewDev(gridView1, true, true, DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect, false, true, true, true);
            HamDungChung.ShowFieldGridViewDev(gridView1, new string[] { "MaTaiKhoan", "TenTaiKhoan", "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhTrongKyNo", "PhatSinhTrongKyCo", "LuyKeNo", "LuyKeCo" },
                                new string[] { "Số hiệu TK", "Tên Tài Khoản", "Đầu kỳ Nợ", "Đầu kỳ Có", "Phát sinh Nợ", "Phát sinh Có", "Lũy kế Nợ", "Lũy kế Có" },
                                             new int[] { 90, 120, 100, 100, 100, 100, 100, 100 });
            HamDungChung.AlignHeaderColumnGridViewDev(gridView1, new string[] { "MaTaiKhoan", "TenTaiKhoan", "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhTrongKyNo", "PhatSinhTrongKyCo", "LuyKeNo", "LuyKeCo" }, DevExpress.Utils.HorzAlignment.Center);
            HamDungChung.FormatNumberTypeofColumnGridViewDev2(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhTrongKyNo", "PhatSinhTrongKyCo", "LuyKeNo", "LuyKeCo" }, "#,###.#");
            HamDungChung.ShowSummaryFooterofColumnGridViewDev2(gridView1, new string[] { "SoDuDauKyNo", "SoDuDauKyCo" }, "{0:#,###.#}");

            NewRowGridViewDev(gridView1);

            //UnLock_LockColumnChoseGridViewDev(gridView1, new string[] { "MaTaiKhoan", "MaDoiTuong", "SoDuDauKyNo", "SoDuDauKyCo", "PhatSinhNoTrongKy", "PhatSinhCoTrongKy", "LuyKeNo", "LuyKeCo" }, false);

            Utils.GridUtils.SetSTTForGridView(gridView1, 50);//M

            //TaiKhoan
            RepositoryItemGridLookUpEdit TaiKhoanNo_GrdLU = new RepositoryItemGridLookUpEdit();
            HamDungChung.InitRepositoryItemGridLookUpDev2(TaiKhoanNo_GrdLU, TaiKhoanListBindingSource, "SoHieuTK", "MaTaiKhoan", "", true, DevExpress.XtraEditors.Controls.TextEditStyles.Standard);
            HamDungChung.ShowFieldRepositoryItemGridLookUpDev(TaiKhoanNo_GrdLU, new string[] { "SoHieuTK", "TenTaiKhoan" }, new string[] { "Số hiệu", "Tên tài khoản" }, new int[] { 100, 150 }, false);
            HamDungChung.RegisterControlFieldGridViewDev(gridView1, "MaTaiKhoan", TaiKhoanNo_GrdLU);

            //

            gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            gridView1.Appearance.GroupPanel.Options.UseFont = true;
            gridView1.GroupPanelText = "Danh Sách Số Dư Đầu Tài Khoản";

            //gridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyDown);
            //gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.InitNewRow += gridView1_InitNewRow;
        }

        void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GetInformations();
            SoDuDauKyH sodudaukyCur = this.gridView1.GetRow(e.RowHandle) as SoDuDauKyH;
            if (sodudaukyCur != null)
            {
                sodudaukyCur.MaBoPhan = ERP_Library.Security.CurrentUser.Info.MaBoPhan;
                sodudaukyCur.MaKy = _maKy;

            }
        }



        private void LoadData_TaiKhoanCon()
        {
            _soDuDauKyList = SoDuDauKyHList.GetSoDuDauKyHList_TaiKhoanCon(_maKy, ERP_Library.Security.CurrentUser.Info.MaBoPhan);
            SoDuDauKyListBindingSource.DataSource = _soDuDauKyList;
        }

    }
}