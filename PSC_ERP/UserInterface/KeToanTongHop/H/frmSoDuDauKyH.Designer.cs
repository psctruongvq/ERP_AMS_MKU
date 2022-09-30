namespace PSC_ERP
{
    partial class frmSoDuDauKyH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoDuDauKyH));
            this.tableAdapterManager1 = new PSC_ERP.ERP_HTVDataSet1TableAdapters.TableAdapterManager();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TenKy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayBatDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NgayKetThuc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.mainMenuBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnXem = new DevExpress.XtraBars.BarButtonItem();
            this.btnSuaDuLieu = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnHelp = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.aaaaaaaaa = new DevExpress.XtraEditors.PanelControl();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.lueky = new DevExpress.XtraEditors.GridLookUpEdit();
            this.kyListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.mainMenuBar = new DevExpress.XtraBars.Bar();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.SoDuDauKyListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TaiKhoanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aaaaaaaaa)).BeginInit();
            this.aaaaaaaaa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueky.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kyListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoDuDauKyListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaiKhoanListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.Connection = null;
            this.tableAdapterManager1.UpdateOrder = PSC_ERP.ERP_HTVDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.TenKy,
            this.NgayBatDau,
            this.NgayKetThuc});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // TenKy
            // 
            this.TenKy.Caption = "Tên kỳ";
            this.TenKy.FieldName = "TenKy";
            this.TenKy.Name = "TenKy";
            this.TenKy.Visible = true;
            this.TenKy.VisibleIndex = 0;
            // 
            // NgayBatDau
            // 
            this.NgayBatDau.Caption = "Ngày bắt đầu";
            this.NgayBatDau.FieldName = "NgayBatDau";
            this.NgayBatDau.Name = "NgayBatDau";
            this.NgayBatDau.Visible = true;
            this.NgayBatDau.VisibleIndex = 1;
            // 
            // NgayKetThuc
            // 
            this.NgayKetThuc.Caption = "Ngày kết thúc";
            this.NgayKetThuc.FieldName = "NgayKetThuc";
            this.NgayKetThuc.Name = "NgayKetThuc";
            this.NgayKetThuc.Visible = true;
            this.NgayKetThuc.VisibleIndex = 2;
            // 
            // mainMenuBarManager
            // 
            this.mainMenuBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.mainMenuBarManager.DockControls.Add(this.barDockControlTop);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlBottom);
            this.mainMenuBarManager.DockControls.Add(this.barDockControlLeft);
            this.mainMenuBarManager.DockControls.Add(this.barDockControl1);
            this.mainMenuBarManager.Form = this;
            this.mainMenuBarManager.Images = this.imageList1;
            this.mainMenuBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnLuu,
            this.btnThoat,
            this.btnHelp,
            this.btnXem,
            this.btnSuaDuLieu});
            this.mainMenuBarManager.LargeImages = this.imageList1;
            this.mainMenuBarManager.MainMenu = this.bar1;
            this.mainMenuBarManager.MaxItemId = 13;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.FloatLocation = new System.Drawing.Point(796, 214);
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSuaDuLieu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHelp, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // btnXem
            // 
            this.btnXem.Caption = "Xem";
            this.btnXem.Id = 8;
            this.btnXem.ImageIndex = 3;
            this.btnXem.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z));
            this.btnXem.Name = "btnXem";
            // 
            // btnSuaDuLieu
            // 
            this.btnSuaDuLieu.Caption = "Sửa dữ liệu";
            this.btnSuaDuLieu.Id = 10;
            this.btnSuaDuLieu.ImageIndex = 13;
            this.btnSuaDuLieu.Name = "btnSuaDuLieu";
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 3;
            this.btnLuu.ImageIndex = 5;
            this.btnLuu.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S));
            this.btnLuu.Name = "btnLuu";
            // 
            // btnHelp
            // 
            this.btnHelp.Caption = "Trợ giúp";
            this.btnHelp.Id = 7;
            this.btnHelp.ImageIndex = 6;
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 6;
            this.btnThoat.ImageIndex = 8;
            this.btnThoat.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.btnThoat.Name = "btnThoat";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(967, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 638);
            this.barDockControlBottom.Size = new System.Drawing.Size(967, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 604);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl1.Location = new System.Drawing.Point(967, 34);
            this.barDockControl1.Size = new System.Drawing.Size(0, 604);
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
            this.imageList1.Images.SetKeyName(12, "4725-200.png");
            this.imageList1.Images.SetKeyName(13, "18799-200.png");
            // 
            // aaaaaaaaa
            // 
            this.aaaaaaaaa.Appearance.BackColor = System.Drawing.Color.LightCyan;
            this.aaaaaaaaa.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.aaaaaaaaa.Appearance.Options.UseBackColor = true;
            this.aaaaaaaaa.Controls.Add(this.textEdit1);
            this.aaaaaaaaa.Controls.Add(this.lueky);
            this.aaaaaaaaa.Controls.Add(this.labelControl5);
            this.aaaaaaaaa.Dock = System.Windows.Forms.DockStyle.Top;
            this.aaaaaaaaa.Location = new System.Drawing.Point(0, 34);
            this.aaaaaaaaa.LookAndFeel.SkinName = "Office 2010 Silver";
            this.aaaaaaaaa.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.aaaaaaaaa.Name = "aaaaaaaaa";
            this.aaaaaaaaa.Size = new System.Drawing.Size(967, 48);
            this.aaaaaaaaa.TabIndex = 71;
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(501, 14);
            this.textEdit1.MenuManager = this.mainMenuBarManager;
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(100, 20);
            this.textEdit1.TabIndex = 25;
            this.textEdit1.Visible = false;
            // 
            // lueky
            // 
            this.lueky.EditValue = "";
            this.lueky.Location = new System.Drawing.Point(185, 14);
            this.lueky.MenuManager = this.mainMenuBarManager;
            this.lueky.Name = "lueky";
            this.lueky.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueky.Properties.DataSource = this.kyListBindingSource;
            this.lueky.Properties.DisplayMember = "TenKy";
            this.lueky.Properties.ValueMember = "MaKy";
            this.lueky.Properties.View = this.gridLookUpEdit1View;
            this.lueky.Size = new System.Drawing.Size(267, 20);
            this.lueky.TabIndex = 4;
            // 
            // kyListBindingSource
            // 
            this.kyListBindingSource.DataSource = typeof(ERP_Library.KyList);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl5.LineColor = System.Drawing.Color.Lime;
            this.labelControl5.Location = new System.Drawing.Point(97, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(82, 15);
            this.labelControl5.TabIndex = 24;
            this.labelControl5.Text = "Kỳ kết chuyển:";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // mainMenuBar
            // 
            this.mainMenuBar.BarName = "Main menu";
            this.mainMenuBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.mainMenuBar.DockCol = 0;
            this.mainMenuBar.DockRow = 0;
            this.mainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.mainMenuBar.FloatLocation = new System.Drawing.Point(796, 214);
            this.mainMenuBar.OptionsBar.MultiLine = true;
            this.mainMenuBar.OptionsBar.UseWholeRow = true;
            this.mainMenuBar.Text = "Main menu";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Thoát";
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.ImageIndex = 8;
            this.barButtonItem2.ItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // SoDuDauKyListBindingSource
            // 
            this.SoDuDauKyListBindingSource.AllowNew = true;
            this.SoDuDauKyListBindingSource.DataSource = typeof(ERP_Library.SoDuDauKyList);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 82);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.mainMenuBarManager;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(967, 556);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // TaiKhoanListBindingSource
            // 
            this.TaiKhoanListBindingSource.DataSource = typeof(ERP_Library.TaiKhoanList);
            // 
            // frmSoDuDauKyH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 638);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.aaaaaaaaa);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmSoDuDauKyH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập số dư đầu kỳ";
            this.Load += new System.EventHandler(this.frmSoDuDauKyH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainMenuBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aaaaaaaaa)).EndInit();
            this.aaaaaaaaa.ResumeLayout(false);
            this.aaaaaaaaa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueky.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kyListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SoDuDauKyListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TaiKhoanListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ERP_HTVDataSet1TableAdapters.TableAdapterManager tableAdapterManager1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraBars.BarManager mainMenuBarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnXem;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnHelp;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraEditors.PanelControl aaaaaaaaa;
        private DevExpress.XtraEditors.GridLookUpEdit lueky;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Bar mainMenuBar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraGrid.Columns.GridColumn TenKy;
        private DevExpress.XtraGrid.Columns.GridColumn NgayBatDau;
        private DevExpress.XtraGrid.Columns.GridColumn NgayKetThuc;
        private System.Windows.Forms.BindingSource kyListBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnSuaDuLieu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.BindingSource SoDuDauKyListBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource TaiKhoanListBindingSource;
        private DevExpress.XtraEditors.TextEdit textEdit1;
    }
}