namespace PSC_ERP
{
    partial class FrmGetBienLaiFronOtherDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGetBienLaiFronOtherDB));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnChon = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportDataExcell = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.FocustextBox1 = new System.Windows.Forms.TextBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnChon,
            this.btnThoat,
            this.btnExportDataExcell});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExportDataExcell, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // btnChon
            // 
            this.btnChon.Caption = "Chọn";
            this.btnChon.Glyph = ((System.Drawing.Image)(resources.GetObject("btnChon.Glyph")));
            this.btnChon.Id = 0;
            this.btnChon.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.btnChon.Name = "btnChon";
            this.btnChon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChon_ItemClick);
            // 
            // btnExportDataExcell
            // 
            this.btnExportDataExcell.Caption = "Export dữ liệu ra excel";
            this.btnExportDataExcell.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportDataExcell.Glyph")));
            this.btnExportDataExcell.Id = 14;
            this.btnExportDataExcell.Name = "btnExportDataExcell";
            this.btnExportDataExcell.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportDataExcell_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThoat.Glyph")));
            this.btnThoat.Id = 6;
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
            this.barDockControlTop.Size = new System.Drawing.Size(1022, 42);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 471);
            this.barDockControlBottom.Size = new System.Drawing.Size(1022, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 42);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 429);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1022, 42);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 429);
            // 
            // FocustextBox1
            // 
            this.FocustextBox1.Location = new System.Drawing.Point(376, 180);
            this.FocustextBox1.Name = "FocustextBox1";
            this.FocustextBox1.Size = new System.Drawing.Size(100, 21);
            this.FocustextBox1.TabIndex = 100;
            this.FocustextBox1.TabStop = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.mainMenuBarManager;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1022, 407);
            this.gridControl1.TabIndex = 105;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(56, 3);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(82, 17);
            this.chkAll.TabIndex = 110;
            this.chkAll.Text = "Chọn tất cả";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 22);
            this.panel1.TabIndex = 115;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 407);
            this.panel2.TabIndex = 116;
            // 
            // FrmGetBienLaiFronOtherDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.FocustextBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmGetBienLaiFronOtherDB";
            this.Text = "Danh Sách Biên Lai";
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnChon;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.TextBox FocustextBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem btnExportDataExcell;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
    }
}