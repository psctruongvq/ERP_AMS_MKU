namespace PSC_ERP.ThuChiEntity
{
    partial class frmChonDeNghiChuyenKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonDeNghiChuyenKhoan));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.toolMain = new System.Windows.Forms.ToolStrip();
            this.tlThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlClose = new System.Windows.Forms.ToolStripButton();
            this.DeNghiList_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Focus1 = new System.Windows.Forms.TextBox();
            this.AllDoiTuong_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BoPhanbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeNghiList_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllDoiTuong_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhanbindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2010 Blue";
            // 
            // toolMain
            // 
            this.toolMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlThem,
            this.toolStripSeparator2,
            this.tlClose});
            this.toolMain.Location = new System.Drawing.Point(0, 0);
            this.toolMain.Name = "toolMain";
            this.toolMain.Size = new System.Drawing.Size(1028, 25);
            this.toolMain.TabIndex = 11;
            this.toolMain.Text = "Chức năng";
            // 
            // tlThem
            // 
            this.tlThem.Image = ((System.Drawing.Image)(resources.GetObject("tlThem.Image")));
            this.tlThem.ImageTransparentColor = System.Drawing.Color.White;
            this.tlThem.Name = "tlThem";
            this.tlThem.Size = new System.Drawing.Size(56, 22);
            this.tlThem.Text = "&Chọn";
            this.tlThem.Click += new System.EventHandler(this.tlThem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlClose
            // 
            this.tlClose.Image = ((System.Drawing.Image)(resources.GetObject("tlClose.Image")));
            this.tlClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlClose.Name = "tlClose";
            this.tlClose.Size = new System.Drawing.Size(56, 22);
            this.tlClose.Text = "Đóng";
            this.tlClose.Click += new System.EventHandler(this.tlClose_Click);
            // 
            // DeNghiList_bindingSource
            // 
            this.DeNghiList_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.spd_Select_DeNghiChuyenKhoan_ChuaLapCT_Result);
            // 
            // Focus1
            // 
            this.Focus1.Location = new System.Drawing.Point(374, 302);
            this.Focus1.Name = "Focus1";
            this.Focus1.Size = new System.Drawing.Size(100, 21);
            this.Focus1.TabIndex = 13;
            this.Focus1.TabStop = false;
            // 
            // AllDoiTuong_bindingSource
            // 
            this.AllDoiTuong_bindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.sp_AllDoiTuong_Result);
            // 
            // BoPhanbindingSource
            // 
            this.BoPhanbindingSource.DataSource = typeof(PSC_ERP_Business.Main.Model.tblnsBoPhan);
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 25);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1028, 529);
            this.gridControl2.TabIndex = 14;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // frmChonDeNghiChuyenKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 554);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.toolMain);
            this.Controls.Add(this.Focus1);
            this.Name = "frmChonDeNghiChuyenKhoan";
            this.Text = "Chọn Đề Nghị Chuyển Khoản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTamUng_FormClosing);
            this.Load += new System.EventHandler(this.frmTamUng_Load);
            this.toolMain.ResumeLayout(false);
            this.toolMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeNghiList_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllDoiTuong_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoPhanbindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.ToolStrip toolMain;
        private System.Windows.Forms.ToolStripButton tlThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlClose;
        private System.Windows.Forms.BindingSource DeNghiList_bindingSource;
        private System.Windows.Forms.TextBox Focus1;
        private System.Windows.Forms.BindingSource AllDoiTuong_bindingSource;
        private System.Windows.Forms.BindingSource BoPhanbindingSource;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;


    }
}