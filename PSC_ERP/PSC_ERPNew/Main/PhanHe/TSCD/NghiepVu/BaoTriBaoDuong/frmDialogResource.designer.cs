namespace PSC_ERP.Main
{
    partial class frmDialogResource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogResource));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnDuaDuLieuVe = new DevExpress.XtraBars.BarButtonItem();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.txtBlackHole = new System.Windows.Forms.TextBox();
            this.resourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TreeList_Resource = new DevExpress.XtraTreeList.TreeList();
            this.colDescription2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDaysPlanned1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.PictureImage = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList_Resource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureImage)).BeginInit();
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
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDuaDuLieuVe,
            this.btnThoat,
            this.btnXoa,
            this.btnThem});
            this.barManager1.MaxItemId = 10;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDuaDuLieuVe, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.Text = "Tools";
            // 
            // btnDuaDuLieuVe
            // 
            this.btnDuaDuLieuVe.Caption = "Đưa dữ liệu về";
            this.btnDuaDuLieuVe.Id = 6;
            this.btnDuaDuLieuVe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDuaDuLieuVe.ImageOptions.Image")));
            this.btnDuaDuLieuVe.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B));
            this.btnDuaDuLieuVe.Name = "btnDuaDuLieuVe";
            toolTipTitleItem1.Text = "Ctrl+B";
            superToolTip1.Items.Add(toolTipTitleItem1);
            this.btnDuaDuLieuVe.SuperTip = superToolTip1;
            this.btnDuaDuLieuVe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDuaDuLieuVe_ItemClick);
            // 
            // btnThem
            // 
            this.btnThem.Caption = "Thêm";
            this.btnThem.Id = 9;
            this.btnThem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.ImageOptions.Image")));
            this.btnThem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N));
            this.btnThem.Name = "btnThem";
            toolTipTitleItem2.Text = "Ctrl+N";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnThem.SuperTip = superToolTip2;
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 8;
            this.btnXoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.ImageOptions.Image")));
            this.btnXoa.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D));
            this.btnXoa.Name = "btnXoa";
            toolTipTitleItem3.Text = "Ctrl+D";
            superToolTip3.Items.Add(toolTipTitleItem3);
            this.btnXoa.SuperTip = superToolTip3;
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 7;
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem4.Text = "Alt+X";
            superToolTip4.Items.Add(toolTipTitleItem4);
            this.btnThoat.SuperTip = superToolTip4;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(503, 47);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 264);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(503, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 47);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 217);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(503, 47);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 217);
            // 
            // txtBlackHole
            // 
            this.txtBlackHole.Location = new System.Drawing.Point(143, 97);
            this.txtBlackHole.Name = "txtBlackHole";
            this.txtBlackHole.Size = new System.Drawing.Size(100, 21);
            this.txtBlackHole.TabIndex = 20;
            this.txtBlackHole.TabStop = false;
            // 
            // resourceBindingSource
            // 
            this.resourceBindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.Resource);
            // 
            // TreeList_Resource
            // 
            this.TreeList_Resource.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDescription2,
            this.colDaysPlanned1});
            this.TreeList_Resource.DataSource = this.resourceBindingSource;
            this.TreeList_Resource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeList_Resource.Location = new System.Drawing.Point(0, 47);
            this.TreeList_Resource.Name = "TreeList_Resource";
            this.TreeList_Resource.OptionsNavigation.AutoFocusNewNode = true;
            this.TreeList_Resource.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.PictureImage});
            this.TreeList_Resource.Size = new System.Drawing.Size(503, 217);
            this.TreeList_Resource.TabIndex = 40;
            // 
            // colDescription2
            // 
            this.colDescription2.Caption = "Miêu tả";
            this.colDescription2.FieldName = "Description";
            this.colDescription2.MinWidth = 41;
            this.colDescription2.Name = "colDescription2";
            this.colDescription2.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colDescription2.Visible = true;
            this.colDescription2.VisibleIndex = 0;
            this.colDescription2.Width = 147;
            // 
            // colDaysPlanned1
            // 
            this.colDaysPlanned1.Caption = "Số ngày";
            this.colDaysPlanned1.FieldName = "DaysPlanned";
            this.colDaysPlanned1.Name = "colDaysPlanned1";
            this.colDaysPlanned1.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.colDaysPlanned1.Visible = true;
            this.colDaysPlanned1.VisibleIndex = 1;
            this.colDaysPlanned1.Width = 61;
            // 
            // PictureImage
            // 
            this.PictureImage.CustomHeight = 16;
            this.PictureImage.Name = "PictureImage";
            this.PictureImage.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.PictureImage.ZoomAccelerationFactor = 1D;
            // 
            // frmDialogResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 264);
            this.ControlBox = false;
            this.Controls.Add(this.TreeList_Resource);
            this.Controls.Add(this.txtBlackHole);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmDialogResource";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resource";
            this.Load += new System.EventHandler(this.frmDialogResource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TreeList_Resource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnDuaDuLieuVe;
        private System.Windows.Forms.TextBox txtBlackHole;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private System.Windows.Forms.BindingSource resourceBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraTreeList.TreeList TreeList_Resource;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDaysPlanned1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit PictureImage;
        private DevExpress.XtraBars.BarButtonItem btnThem;
    }
}