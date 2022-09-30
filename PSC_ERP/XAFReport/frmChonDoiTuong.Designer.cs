namespace PSC_ERP
{
    partial class frmChonDoiTuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonDoiTuong));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnChon = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.bdTaiKhoan = new System.Windows.Forms.BindingSource(this.components);
            this.bdChuongTrinh = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bdDoiTuong = new System.Windows.Forms.BindingSource(this.components);
            this.gridView_DoiTuong = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaQLDoiTuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenDoiTuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtFocus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChuongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdDoiTuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DoiTuong)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1343360963_file_add.png");
            this.imageList1.Images.SetKeyName(1, "1337595172_file_edit.png");
            this.imageList1.Images.SetKeyName(2, "1343360966_file_delete.png");
            this.imageList1.Images.SetKeyName(3, "1343360964_file_search.png");
            this.imageList1.Images.SetKeyName(4, "undo64.png");
            this.imageList1.Images.SetKeyName(5, "save64.png");
            this.imageList1.Images.SetKeyName(6, "help64.png");
            this.imageList1.Images.SetKeyName(7, "printer64.png");
            this.imageList1.Images.SetKeyName(8, "exit64.png");
            this.imageList1.Images.SetKeyName(9, "1337595258_Gnome-View-Refresh-64.png");
            this.imageList1.Images.SetKeyName(10, "utilities64.png");
            this.imageList1.Images.SetKeyName(11, "report64.png");
            this.imageList1.Images.SetKeyName(12, "export.png");
            // 
            // mainMenuBarManager
            // 
            this.mainMenuBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.mainMenuBar});
            this.mainMenuBarManager.DockControls.Add(this.barDockControlTop);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlBottom);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlLeft);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlRight);
            this.mainMenuBarManager.Form = this;
            this.mainMenuBarManager.Images = this.imageList1;
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnChon,
            this.btnThoat});
            this.mainMenuBarManager.LargeImages = this.imageList1;
            this.mainMenuBarManager.MainMenu = this.mainMenuBar;
            this.mainMenuBarManager.MaxItemId = 15;
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.BarName = "Main menu";
            this.mainMenuBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.mainMenuBar.DockCol = 0;
            this.mainMenuBar.DockRow = 0;
            this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(244, 250);
            this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnChon, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // btnChon
            // 
            this.btnChon.Caption = "Chọn";
            this.btnChon.Id = 0;
            this.btnChon.ImageIndex = 1;
            this.btnChon.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.btnChon.Name = "btnChon";
            this.btnChon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChon_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem1.Text = "Ctrl+Q";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnThoat.SuperTip = superToolTip1;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(704, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 564);
            this.barDockControlBottom.Size = new System.Drawing.Size(704, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 530);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(704, 34);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 530);
            // 
            // bdTaiKhoan
            // 
            this.bdTaiKhoan.DataSource = typeof(ERP_Library.HeThongTaiKhoan1List);
            // 
            // bdChuongTrinh
            // 
            this.bdChuongTrinh.DataSource = typeof(ERP_Library.ChuongTrinhList);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.bdDoiTuong;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 34);
            this.gridControl1.MainView = this.gridView_DoiTuong;
            this.gridControl1.MenuManager = this.mainMenuBarManager;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(704, 530);
            this.gridControl1.TabIndex = 9;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_DoiTuong});
            // 
            // bdDoiTuong
            // 
            this.bdDoiTuong.DataSource = typeof(ERP_Library.DoiTuongAllList);
            // 
            // gridView_DoiTuong
            // 
            this.gridView_DoiTuong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCheck,
            this.colMaQLDoiTuong,
            this.colTenDoiTuong});
            this.gridView_DoiTuong.GridControl = this.gridControl1;
            this.gridView_DoiTuong.Name = "gridView_DoiTuong";
            this.gridView_DoiTuong.OptionsView.ShowAutoFilterRow = true;
            this.gridView_DoiTuong.OptionsView.ShowGroupPanel = false;
            // 
            // colCheck
            // 
            this.colCheck.Caption = "Chọn";
            this.colCheck.FieldName = "Check";
            this.colCheck.Name = "colCheck";
            this.colCheck.Visible = true;
            this.colCheck.VisibleIndex = 0;
            this.colCheck.Width = 69;
            // 
            // colMaQLDoiTuong
            // 
            this.colMaQLDoiTuong.Caption = "Mã đối tượng";
            this.colMaQLDoiTuong.FieldName = "MaQLDoiTuong";
            this.colMaQLDoiTuong.Name = "colMaQLDoiTuong";
            this.colMaQLDoiTuong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colMaQLDoiTuong.Visible = true;
            this.colMaQLDoiTuong.VisibleIndex = 1;
            this.colMaQLDoiTuong.Width = 139;
            // 
            // colTenDoiTuong
            // 
            this.colTenDoiTuong.Caption = "Tên đối tượng";
            this.colTenDoiTuong.FieldName = "TenDoiTuong";
            this.colTenDoiTuong.Name = "colTenDoiTuong";
            this.colTenDoiTuong.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colTenDoiTuong.Visible = true;
            this.colTenDoiTuong.VisibleIndex = 2;
            this.colTenDoiTuong.Width = 478;
            // 
            // txtFocus
            // 
            this.txtFocus.Location = new System.Drawing.Point(64, 492);
            this.txtFocus.Name = "txtFocus";
            this.txtFocus.Size = new System.Drawing.Size(100, 21);
            this.txtFocus.TabIndex = 14;
            // 
            // frmChonDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 564);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.txtFocus);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmChonDoiTuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn đối tượng";
            this.Load += new System.EventHandler(this.frmChonDoiTuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChuongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdDoiTuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_DoiTuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnChon;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource bdChuongTrinh;
        private System.Windows.Forms.BindingSource bdTaiKhoan;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_DoiTuong;
        private System.Windows.Forms.BindingSource bdDoiTuong;
        private DevExpress.XtraGrid.Columns.GridColumn colMaQLDoiTuong;
        private DevExpress.XtraGrid.Columns.GridColumn colTenDoiTuong;
        private DevExpress.XtraGrid.Columns.GridColumn colCheck;
        private System.Windows.Forms.TextBox txtFocus;
    }
}