namespace PSC_ERPNew.Main.PhanHe.DIGITIZING
{
    partial class frmDigitizingModule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDigitizingModule));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.applicationMenu1 = new DevExpress.XtraBars.Ribbon.ApplicationMenu(this.components);
            this.btnThoatPhanHe = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoatHeThongERP = new DevExpress.XtraBars.BarButtonItem();
            this.imageList16x16 = new System.Windows.Forms.ImageList(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.themeChooser_RibbonGalleryBarItem = new DevExpress.XtraBars.RibbonGalleryBarItem();
            this.imageList32x32 = new System.Windows.Forms.ImageList(this.components);
            this.ribbonPage_System = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.applicationMenu1;
            this.ribbonControl1.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbonControl1.ApplicationIcon")));
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Images = this.imageList16x16;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItem1,
            this.themeChooser_RibbonGalleryBarItem,
            this.btnThoatPhanHe,
            this.btnThoatHeThongERP});
            this.ribbonControl1.LargeImages = this.imageList32x32;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 1;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage_System});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.ribbonControl1.Size = new System.Drawing.Size(1054, 147);
            // 
            // applicationMenu1
            // 
            this.applicationMenu1.ItemLinks.Add(this.btnThoatPhanHe);
            this.applicationMenu1.ItemLinks.Add(this.btnThoatHeThongERP);
            this.applicationMenu1.Name = "applicationMenu1";
            this.applicationMenu1.Ribbon = this.ribbonControl1;
            // 
            // btnThoatPhanHe
            // 
            this.btnThoatPhanHe.Caption = "Thoát phân hệ TSCĐ";
            this.btnThoatPhanHe.Id = 28;
            this.btnThoatPhanHe.LargeImageIndex = 2;
            this.btnThoatPhanHe.Name = "btnThoatPhanHe";
            this.btnThoatPhanHe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoatPhanHe_ItemClick);
            // 
            // btnThoatHeThongERP
            // 
            this.btnThoatHeThongERP.Caption = "Thoát hệ thống ERP";
            this.btnThoatHeThongERP.Id = 29;
            this.btnThoatHeThongERP.LargeImageIndex = 2;
            this.btnThoatHeThongERP.Name = "btnThoatHeThongERP";
            this.btnThoatHeThongERP.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoatHeThongERP_ItemClick);
            // 
            // imageList16x16
            // 
            this.imageList16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16x16.ImageStream")));
            this.imageList16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16x16.Images.SetKeyName(0, "1343361114_application.png");
            this.imageList16x16.Images.SetKeyName(1, "1343361116_calendar.png");
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 26;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // themeChooser_RibbonGalleryBarItem
            // 
            this.themeChooser_RibbonGalleryBarItem.Caption = "ribbonGalleryBarItem1";
            // 
            // 
            // 
            this.themeChooser_RibbonGalleryBarItem.Gallery.ItemClick += new DevExpress.XtraBars.Ribbon.GalleryItemClickEventHandler(this.ribbonGalleryBarItem1_Gallery_ItemClick);
            this.themeChooser_RibbonGalleryBarItem.Id = 27;
            this.themeChooser_RibbonGalleryBarItem.Name = "themeChooser_RibbonGalleryBarItem";
            this.themeChooser_RibbonGalleryBarItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.themeChooser_RibbonGalleryBarItem_ItemClick);
            // 
            // imageList32x32
            // 
            this.imageList32x32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList32x32.ImageStream")));
            this.imageList32x32.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList32x32.Images.SetKeyName(0, "1343361114_application.png");
            this.imageList32x32.Images.SetKeyName(1, "1343361116_calendar.png");
            this.imageList32x32.Images.SetKeyName(2, "exit64.png");
            // 
            // ribbonPage_System
            // 
            this.ribbonPage_System.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage_System.ImageIndex = 0;
            this.ribbonPage_System.Name = "ribbonPage_System";
            this.ribbonPage_System.Text = "Hiển thị";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.themeChooser_RibbonGalleryBarItem);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Cơ bản";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "ribbonPage4";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // frmDigitizingModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 422);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmDigitizingModule";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Phân hệ lưu trữ chứng từ";
            this.Load += new System.EventHandler(this.frmDigitizingModule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicationMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.ApplicationMenu applicationMenu1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage_System;
        //private DevExpress.Utils.ImageCollection imageColection32x32;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        //private DevExpress.Utils.ImageCollection imageCollection16x16;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private System.Windows.Forms.ImageList imageList16x16;
        private System.Windows.Forms.ImageList imageList32x32;
        private DevExpress.XtraBars.RibbonGalleryBarItem themeChooser_RibbonGalleryBarItem;
        private DevExpress.XtraBars.BarButtonItem btnThoatPhanHe;
        private DevExpress.XtraBars.BarButtonItem btnThoatHeThongERP;

    }
}

