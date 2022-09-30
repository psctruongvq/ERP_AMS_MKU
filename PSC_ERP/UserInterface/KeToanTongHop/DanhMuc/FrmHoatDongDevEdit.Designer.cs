namespace PSC_ERP
{
    partial class FrmHoatDongDevEdit
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
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoatDongDevEdit));
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuuvaThemMoi = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.HoatDong_bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.MaQL_TextEdit = new DevExpress.XtraEditors.TextEdit();
            this.TenHoatDong_textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.NgungSuDung_checkBox = new System.Windows.Forms.CheckBox();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.EnglishName_textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoatDong_bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaQL_TextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHoatDong_textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishName_textEdit1.Properties)).BeginInit();
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
            this.mainMenuBarManager.Images = this.imageList1;
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnLuu,
            this.btnThoat,
            this.btnLuuvaThemMoi});
            this.mainMenuBarManager.LargeImages = this.imageList1;
            this.mainMenuBarManager.MainMenu = this.mainMenuBar;
            this.mainMenuBarManager.MaxItemId = 14;
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.BarName = "Main menu";
            this.mainMenuBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.mainMenuBar.DockCol = 0;
            this.mainMenuBar.DockRow = 0;
            this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(459, 267);
            this.mainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuuvaThemMoi, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageIndex = 5;
            this.btnLuu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnLuu.Name = "btnLuu";
            toolTipTitleItem7.Text = "Ctrl+S";
            superToolTip7.Items.Add(toolTipTitleItem7);
            this.btnLuu.SuperTip = superToolTip7;
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnLuuvaThemMoi
            // 
            this.btnLuuvaThemMoi.Caption = "Lưu và Thêm mới";
            this.btnLuuvaThemMoi.Id = 13;
            this.btnLuuvaThemMoi.ImageIndex = 5;
            this.btnLuuvaThemMoi.Name = "btnLuuvaThemMoi";
            this.btnLuuvaThemMoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuuvaThemMoi_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q));
            this.btnThoat.Name = "btnThoat";
            toolTipTitleItem8.Text = "Ctrl+Q";
            superToolTip8.Items.Add(toolTipTitleItem8);
            this.btnThoat.SuperTip = superToolTip8;
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(565, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 211);
            this.barDockControlBottom.Size = new System.Drawing.Size(565, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 177);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(565, 34);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 177);
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
            this.imageList1.Images.SetKeyName(12, "1345603535_invoice.png");
            this.imageList1.Images.SetKeyName(13, "1345604043_import.png");
            this.imageList1.Images.SetKeyName(14, "1345604085_export.png");
            this.imageList1.Images.SetKeyName(15, "Icon remove_256.png");
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // HoatDong_bindingSource1
            // 
            this.HoatDong_bindingSource1.DataSource = typeof(ERP_Library.HoatDongDev);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.EnglishName_textEdit1);
            this.panelControl1.Controls.Add(this.MaQL_TextEdit);
            this.panelControl1.Controls.Add(this.TenHoatDong_textEdit1);
            this.panelControl1.Controls.Add(this.NgungSuDung_checkBox);
            this.panelControl1.Controls.Add(this.labelControl6);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 34);
            this.panelControl1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(565, 177);
            this.panelControl1.TabIndex = 4;
            // 
            // MaQL_TextEdit
            // 
            this.MaQL_TextEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MaQL_TextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HoatDong_bindingSource1, "MaQLHoatDong", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.MaQL_TextEdit.Location = new System.Drawing.Point(127, 49);
            this.MaQL_TextEdit.Name = "MaQL_TextEdit";
            this.MaQL_TextEdit.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaQL_TextEdit.Properties.Appearance.Options.UseFont = true;
            this.MaQL_TextEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.MaQL_TextEdit.Size = new System.Drawing.Size(325, 22);
            this.MaQL_TextEdit.TabIndex = 1;
            // 
            // TenHoatDong_textEdit1
            // 
            this.TenHoatDong_textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TenHoatDong_textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HoatDong_bindingSource1, "TenHoatDong", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.TenHoatDong_textEdit1.Location = new System.Drawing.Point(127, 21);
            this.TenHoatDong_textEdit1.Name = "TenHoatDong_textEdit1";
            this.TenHoatDong_textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TenHoatDong_textEdit1.Properties.Appearance.Options.UseFont = true;
            this.TenHoatDong_textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.TenHoatDong_textEdit1.Size = new System.Drawing.Size(325, 22);
            this.TenHoatDong_textEdit1.TabIndex = 0;
            // 
            // NgungSuDung_checkBox
            // 
            this.NgungSuDung_checkBox.AutoSize = true;
            this.NgungSuDung_checkBox.BackColor = System.Drawing.Color.Transparent;
            this.NgungSuDung_checkBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.HoatDong_bindingSource1, "NgungSuDung", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.NgungSuDung_checkBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.NgungSuDung_checkBox.ForeColor = System.Drawing.Color.Blue;
            this.NgungSuDung_checkBox.Location = new System.Drawing.Point(127, 110);
            this.NgungSuDung_checkBox.Name = "NgungSuDung_checkBox";
            this.NgungSuDung_checkBox.Size = new System.Drawing.Size(110, 17);
            this.NgungSuDung_checkBox.TabIndex = 2;
            this.NgungSuDung_checkBox.Text = "Ngưng sử dụng";
            this.NgungSuDung_checkBox.UseVisualStyleBackColor = false;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl6.LineColor = System.Drawing.Color.Lime;
            this.labelControl6.Location = new System.Drawing.Point(44, 52);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(77, 15);
            this.labelControl6.TabIndex = 13;
            this.labelControl6.Text = "Mã hoạt động:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl2.LineColor = System.Drawing.Color.Lime;
            this.labelControl2.LineVisible = true;
            this.labelControl2.Location = new System.Drawing.Point(63, 24);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(58, 15);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Hoạt động:";
            // 
            // EnglishName_textEdit1
            // 
            this.EnglishName_textEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EnglishName_textEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.HoatDong_bindingSource1, "EnglishName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.EnglishName_textEdit1.Location = new System.Drawing.Point(127, 77);
            this.EnglishName_textEdit1.Name = "EnglishName_textEdit1";
            this.EnglishName_textEdit1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnglishName_textEdit1.Properties.Appearance.Options.UseFont = true;
            this.EnglishName_textEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.EnglishName_textEdit1.Size = new System.Drawing.Size(325, 22);
            this.EnglishName_textEdit1.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.LineColor = System.Drawing.Color.Lime;
            this.labelControl1.Location = new System.Drawing.Point(42, 80);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(79, 15);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Tên tiếng anh:";
            // 
            // FrmHoatDongDevEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 211);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmHoatDongDevEdit";
            this.Text = "Chi Tiết Loại Chứng Từ";
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoatDong_bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaQL_TextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TenHoatDong_textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EnglishName_textEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.BindingSource HoatDong_bindingSource1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraBars.BarButtonItem btnLuuvaThemMoi;
        private System.Windows.Forms.CheckBox NgungSuDung_checkBox;
        private DevExpress.XtraEditors.TextEdit MaQL_TextEdit;
        private DevExpress.XtraEditors.TextEdit TenHoatDong_textEdit1;
        private DevExpress.XtraEditors.TextEdit EnglishName_textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}