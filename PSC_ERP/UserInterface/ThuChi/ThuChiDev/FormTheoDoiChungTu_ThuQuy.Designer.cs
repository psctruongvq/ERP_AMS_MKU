namespace PSC_ERP
{
    partial class FormTheoDoiChungTu_ThuQuy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTheoDoiChungTu_ThuQuy));
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.barbtnTim = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ChungTuTheoDoiList_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FocustextBox1 = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtEdit_DenNgay = new DevExpress.XtraEditors.DateEdit();
            this.dtEdit_TuNgay = new DevExpress.XtraEditors.DateEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChungTuTheoDoiList_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_DenNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_DenNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_TuNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_TuNgay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            this.btnSave,
            this.btnThoat,
            this.barbtnTim});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barbtnTim, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSave, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // barbtnTim
            // 
            this.barbtnTim.Caption = "Tìm";
            this.barbtnTim.Id = 14;
            this.barbtnTim.ImageIndex = 3;
            this.barbtnTim.Name = "barbtnTim";
            this.barbtnTim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnTim_ItemClick);
            // 
            // btnSave
            // 
            this.btnSave.Caption = "Lưu";
            this.btnSave.Id = 0;
            this.btnSave.ImageIndex = 5;
            this.btnSave.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem2.Text = "Ctrl+Q";
            superToolTip2.Items.Add(toolTipTitleItem2);
            this.btnThoat.SuperTip = superToolTip2;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1022, 34);
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
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 437);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1022, 34);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 437);
            // 
            // ChungTuTheoDoiList_BindingSource
            // 
            this.ChungTuTheoDoiList_BindingSource.AllowNew = false;
            this.ChungTuTheoDoiList_BindingSource.DataSource = typeof(ERP_Library.ChungTu_TheoDoiList);
            // 
            // FocustextBox1
            // 
            this.FocustextBox1.Location = new System.Drawing.Point(444, 404);
            this.FocustextBox1.Name = "FocustextBox1";
            this.FocustextBox1.Size = new System.Drawing.Size(100, 21);
            this.FocustextBox1.TabIndex = 100;
            this.FocustextBox1.TabStop = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.dtEdit_DenNgay);
            this.groupControl1.Controls.Add(this.dtEdit_TuNgay);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 34);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1022, 63);
            this.groupControl1.TabIndex = 105;
            this.groupControl1.Text = "Thông Tin Tìm Kiếm";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(316, 27);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 13);
            this.labelControl2.TabIndex = 14;
            this.labelControl2.Text = "Đến Ngày";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(73, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 13);
            this.labelControl1.TabIndex = 13;
            this.labelControl1.Text = "Từ Ngày";
            // 
            // dtEdit_DenNgay
            // 
            this.dtEdit_DenNgay.EditValue = new System.DateTime(2013, 1, 9, 0, 0, 0, 0);
            this.dtEdit_DenNgay.Location = new System.Drawing.Point(370, 24);
            this.dtEdit_DenNgay.Name = "dtEdit_DenNgay";
            this.dtEdit_DenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdit_DenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEdit_DenNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtEdit_DenNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdit_DenNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtEdit_DenNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdit_DenNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtEdit_DenNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtEdit_DenNgay.Size = new System.Drawing.Size(216, 20);
            this.dtEdit_DenNgay.TabIndex = 12;
            // 
            // dtEdit_TuNgay
            // 
            this.dtEdit_TuNgay.EditValue = new System.DateTime(2013, 1, 9, 0, 0, 0, 0);
            this.dtEdit_TuNgay.Location = new System.Drawing.Point(120, 24);
            this.dtEdit_TuNgay.MenuManager = this.mainMenuBarManager;
            this.dtEdit_TuNgay.Name = "dtEdit_TuNgay";
            this.dtEdit_TuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtEdit_TuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dtEdit_TuNgay.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtEdit_TuNgay.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdit_TuNgay.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtEdit_TuNgay.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtEdit_TuNgay.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dtEdit_TuNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
            this.dtEdit_TuNgay.Size = new System.Drawing.Size(165, 20);
            this.dtEdit_TuNgay.TabIndex = 10;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 97);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.mainMenuBarManager;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1022, 374);
            this.gridControl1.TabIndex = 106;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // FormTheoDoiChungTu_ThuQuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 471);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.FocustextBox1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FormTheoDoiChungTu_ThuQuy";
            this.Text = "Theo Dõi Chứng Từ";
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChungTuTheoDoiList_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_DenNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_DenNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_TuNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtEdit_TuNgay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource ChungTuTheoDoiList_BindingSource;
        private System.Windows.Forms.TextBox FocustextBox1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dtEdit_TuNgay;
        private DevExpress.XtraEditors.DateEdit dtEdit_DenNgay;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarButtonItem barbtnTim;
    }
}