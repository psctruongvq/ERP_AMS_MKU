namespace PSC_ERPNew.Main
{
    partial class frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnDuaDuLieuVeChungTu = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.btnRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.grdChungTu = new DevExpress.XtraGrid.GridControl();
            this.grdViewChungTu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colChon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoChungTu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbDoiTac_ForGrid = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTenDoiTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenVietTat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaQLDoiTac = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.spTSCDLayDanhSachChungTuGhiTangCuTruocNam2014ResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewChungTu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTac_ForGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTSCDLayDanhSachChungTuGhiTangCuTruocNam2014ResultBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageList1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThoat,
            this.btnLuu,
            this.btnPrint,
            this.btnRefresh,
            this.btnDuaDuLieuVeChungTu});
            this.barManager1.MaxItemId = 7;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDuaDuLieuVeChungTu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnDuaDuLieuVeChungTu
            // 
            this.btnDuaDuLieuVeChungTu.Caption = "Đưa dữ liệu về chứng từ";
            this.btnDuaDuLieuVeChungTu.Id = 6;
            this.btnDuaDuLieuVeChungTu.ImageIndex = 10;
            this.btnDuaDuLieuVeChungTu.Name = "btnDuaDuLieuVeChungTu";
            this.btnDuaDuLieuVeChungTu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDuaDuLieuVeChungTu_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 1;
            this.btnThoat.ImageIndex = 9;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem1.Text = "Alt+X";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnThoat.SuperTip = superToolTip1;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(984, 39);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 661);
            this.barDockControlBottom.Size = new System.Drawing.Size(984, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 39);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 622);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(984, 39);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 622);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "add64.png");
            this.imageList1.Images.SetKeyName(1, "undo64.png");
            this.imageList1.Images.SetKeyName(2, "1337595172_file_edit.png");
            this.imageList1.Images.SetKeyName(3, "1343360966_file_delete.png");
            this.imageList1.Images.SetKeyName(4, "save64.png");
            this.imageList1.Images.SetKeyName(5, "1337595258_Gnome-View-Refresh-64.png");
            this.imageList1.Images.SetKeyName(6, "find64.png");
            this.imageList1.Images.SetKeyName(7, "printer64.png");
            this.imageList1.Images.SetKeyName(8, "help64.png");
            this.imageList1.Images.SetKeyName(9, "exit64.png");
            this.imageList1.Images.SetKeyName(10, "import.png");
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageIndex = 4;
            this.btnLuu.Name = "btnLuu";
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "In";
            this.btnPrint.Id = 4;
            this.btnPrint.ImageIndex = 7;
            this.btnPrint.Name = "btnPrint";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Caption = "Refresh";
            this.btnRefresh.Id = 5;
            this.btnRefresh.ImageIndex = 5;
            this.btnRefresh.Name = "btnRefresh";
            // 
            // grdChungTu
            // 
            this.grdChungTu.DataSource = this.spTSCDLayDanhSachChungTuGhiTangCuTruocNam2014ResultBindingSource;
            this.grdChungTu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdChungTu.Location = new System.Drawing.Point(0, 39);
            this.grdChungTu.MainView = this.grdViewChungTu;
            this.grdChungTu.MenuManager = this.barManager1;
            this.grdChungTu.Name = "grdChungTu";
            this.grdChungTu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbDoiTac_ForGrid});
            this.grdChungTu.Size = new System.Drawing.Size(984, 622);
            this.grdChungTu.TabIndex = 10;
            this.grdChungTu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewChungTu});
            // 
            // grdViewChungTu
            // 
            this.grdViewChungTu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colChon,
            this.colSoChungTu,
            this.colNgayLap});
            this.grdViewChungTu.GridControl = this.grdChungTu;
            this.grdViewChungTu.Name = "grdViewChungTu";
            this.grdViewChungTu.OptionsView.ShowAutoFilterRow = true;
            // 
            // colChon
            // 
            this.colChon.Caption = "Chọn";
            this.colChon.FieldName = "Chon";
            this.colChon.Name = "colChon";
            this.colChon.Visible = true;
            this.colChon.VisibleIndex = 0;
            // 
            // colSoChungTu
            // 
            this.colSoChungTu.Caption = "Số chứng từ";
            this.colSoChungTu.FieldName = "SoChungTu";
            this.colSoChungTu.Name = "colSoChungTu";
            this.colSoChungTu.OptionsColumn.ReadOnly = true;
            this.colSoChungTu.Visible = true;
            this.colSoChungTu.VisibleIndex = 1;
            // 
            // colNgayLap
            // 
            this.colNgayLap.Caption = "Ngày lập";
            this.colNgayLap.FieldName = "NgayLap";
            this.colNgayLap.Name = "colNgayLap";
            this.colNgayLap.OptionsColumn.ReadOnly = true;
            this.colNgayLap.Visible = true;
            this.colNgayLap.VisibleIndex = 2;
            // 
            // cbDoiTac_ForGrid
            // 
            this.cbDoiTac_ForGrid.AutoHeight = false;
            this.cbDoiTac_ForGrid.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDoiTac_ForGrid.DisplayMember = "TenDoiTac";
            this.cbDoiTac_ForGrid.Name = "cbDoiTac_ForGrid";
            this.cbDoiTac_ForGrid.ValueMember = "MaDoiTac";
            this.cbDoiTac_ForGrid.View = this.repositoryItemGridLookUpEdit1View;
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTenDoiTac,
            this.colTenVietTat,
            this.colMaQLDoiTac});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // colTenDoiTac
            // 
            this.colTenDoiTac.Caption = "Tên";
            this.colTenDoiTac.FieldName = "TenDoiTac";
            this.colTenDoiTac.Name = "colTenDoiTac";
            this.colTenDoiTac.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenDoiTac.Visible = true;
            this.colTenDoiTac.VisibleIndex = 1;
            // 
            // colTenVietTat
            // 
            this.colTenVietTat.Caption = "Tên viết tắt";
            this.colTenVietTat.FieldName = "TenVietTat";
            this.colTenVietTat.Name = "colTenVietTat";
            this.colTenVietTat.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenVietTat.Visible = true;
            this.colTenVietTat.VisibleIndex = 2;
            // 
            // colMaQLDoiTac
            // 
            this.colMaQLDoiTac.Caption = "Mã";
            this.colMaQLDoiTac.FieldName = "MaQLDoiTac";
            this.colMaQLDoiTac.Name = "colMaQLDoiTac";
            this.colMaQLDoiTac.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaQLDoiTac.Visible = true;
            this.colMaQLDoiTac.VisibleIndex = 0;
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(13, 39);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 13;
            this.txtBlackHole.TabStop = false;
            // 
            // spTSCDLayDanhSachChungTuGhiTangCuTruocNam2014ResultBindingSource
            // 
            this.spTSCDLayDanhSachChungTuGhiTangCuTruocNam2014ResultBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.sp_TSCD_LayDanhSachChungTuGhiTangCuTruocNam2014_Result);
            // 
            // frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.grdChungTu);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014";
            this.Text = "Danh sách chứng từ Ghi tăng tài sản cố định cá biệt trước năm 2014";
            this.Load += new System.EventHandler(this.frmDialogTimChonChungTu_GhiTangTSCDCaBietTruocNam2014_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewChungTu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDoiTac_ForGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spTSCDLayDanhSachChungTuGhiTangCuTruocNam2014ResultBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem btnRefresh;
        private DevExpress.XtraBars.BarButtonItem btnPrint;
        private DevExpress.XtraGrid.GridControl grdChungTu;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewChungTu;
        private DevExpress.XtraGrid.Columns.GridColumn colSoChungTu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayLap;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit cbDoiTac_ForGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDoiTac;
        private DevExpress.XtraGrid.Columns.GridColumn colTenVietTat;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQLDoiTac;
        private DevExpress.XtraBars.BarButtonItem btnDuaDuLieuVeChungTu;
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraGrid.Columns.GridColumn colChon;
        private System.Windows.Forms.BindingSource spTSCDLayDanhSachChungTuGhiTangCuTruocNam2014ResultBindingSource;
    }
}