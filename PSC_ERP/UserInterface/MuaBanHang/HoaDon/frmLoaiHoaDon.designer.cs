namespace PSC_ERP
{
    partial class frmLoaiHoaDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoaiHoaDon));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("LoaiHoaDon", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaLoaiHoaDon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenLoaiHonDon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLy");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.luuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtTenLoaiHoaDon = new System.Windows.Forms.TextBox();
            this.txtMaLoaiHoaDon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGridLoaiHoaDon = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.loaiHoaDonListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridLoaiHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHoaDonListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmToolStripMenuItem,
            this.luuToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.tìmToolStripMenuItem,
            this.trợGiúpToolStripMenuItem,
            this.trợGiúpToolStripMenuItem1,
            this.thoatToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(557, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "Thêm";
            // 
            // thêmToolStripMenuItem
            // 
            this.thêmToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thêmToolStripMenuItem.Image")));
            this.thêmToolStripMenuItem.Name = "thêmToolStripMenuItem";
            this.thêmToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.thêmToolStripMenuItem.Text = "Thêm";
            this.thêmToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.thêmToolStripMenuItem.Click += new System.EventHandler(this.thêmToolStripMenuItem_Click);
            // 
            // luuToolStripMenuItem
            // 
            this.luuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("luuToolStripMenuItem.Image")));
            this.luuToolStripMenuItem.Name = "luuToolStripMenuItem";
            this.luuToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.luuToolStripMenuItem.Text = "Lưu";
            this.luuToolStripMenuItem.Click += new System.EventHandler(this.luuToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("xóaToolStripMenuItem.Image")));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // tìmToolStripMenuItem
            // 
            this.tìmToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tìmToolStripMenuItem.Image")));
            this.tìmToolStripMenuItem.Name = "tìmToolStripMenuItem";
            this.tìmToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.tìmToolStripMenuItem.Text = "Tìm";
            // 
            // trợGiúpToolStripMenuItem
            // 
            this.trợGiúpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("trợGiúpToolStripMenuItem.Image")));
            this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.trợGiúpToolStripMenuItem.Text = "In";
            // 
            // trợGiúpToolStripMenuItem1
            // 
            this.trợGiúpToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("trợGiúpToolStripMenuItem1.Image")));
            this.trợGiúpToolStripMenuItem1.Name = "trợGiúpToolStripMenuItem1";
            this.trợGiúpToolStripMenuItem1.Size = new System.Drawing.Size(75, 20);
            this.trợGiúpToolStripMenuItem1.Text = "Trợ Giúp";
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thoatToolStripMenuItem.Image")));
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // ultraGroupBox1
            // 
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.Controls.Add(this.txtTenLoaiHoaDon);
            this.ultraGroupBox1.Controls.Add(this.txtMaLoaiHoaDon);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.label1);
            appearance2.FontData.BoldAsString = "True";
            this.ultraGroupBox1.HeaderAppearance = appearance2;
            this.ultraGroupBox1.Location = new System.Drawing.Point(8, 32);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(543, 54);
            this.ultraGroupBox1.TabIndex = 14;
            this.ultraGroupBox1.Text = "Thông Tin";
            // 
            // txtTenLoaiHoaDon
            // 
            this.txtTenLoaiHoaDon.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loaiHoaDonListBindingSource, "TenLoaiHonDon", true));
            this.txtTenLoaiHoaDon.Location = new System.Drawing.Point(279, 23);
            this.txtTenLoaiHoaDon.Name = "txtTenLoaiHoaDon";
            this.txtTenLoaiHoaDon.Size = new System.Drawing.Size(254, 20);
            this.txtTenLoaiHoaDon.TabIndex = 3;
            // 
            // txtMaLoaiHoaDon
            // 
            this.txtMaLoaiHoaDon.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loaiHoaDonListBindingSource, "MaQuanLy", true));
            this.txtMaLoaiHoaDon.Location = new System.Drawing.Point(112, 23);
            this.txtMaLoaiHoaDon.Name = "txtMaLoaiHoaDon";
            this.txtMaLoaiHoaDon.Size = new System.Drawing.Size(84, 20);
            this.txtMaLoaiHoaDon.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Loại Hóa Đơn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Loại Hóa Đơn";
            // 
            // ultraGroupBox2
            // 
            appearance3.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance3;
            this.ultraGroupBox2.Controls.Add(this.ultraGridLoaiHoaDon);
            appearance6.FontData.BoldAsString = "True";
            this.ultraGroupBox2.HeaderAppearance = appearance6;
            this.ultraGroupBox2.Location = new System.Drawing.Point(7, 90);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(542, 305);
            this.ultraGroupBox2.TabIndex = 15;
            this.ultraGroupBox2.Text = "Danh Sách Loại Hóa Đơn";
            // 
            // ultraGridLoaiHoaDon
            // 
            this.ultraGridLoaiHoaDon.DataSource = this.loaiHoaDonListBindingSource;
            appearance4.FontData.BoldAsString = "False";
            this.ultraGridLoaiHoaDon.DisplayLayout.Appearance = appearance4;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 330;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.ultraGridLoaiHoaDon.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGridLoaiHoaDon.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance5.BackColor = System.Drawing.Color.SteelBlue;
            this.ultraGridLoaiHoaDon.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.ultraGridLoaiHoaDon.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.ultraGridLoaiHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGridLoaiHoaDon.Location = new System.Drawing.Point(6, 19);
            this.ultraGridLoaiHoaDon.Name = "ultraGridLoaiHoaDon";
            this.ultraGridLoaiHoaDon.Size = new System.Drawing.Size(529, 279);
            this.ultraGridLoaiHoaDon.TabIndex = 6;
            this.ultraGridLoaiHoaDon.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGridLoaiHoaDon_InitializeLayout);
            // 
            // loaiHoaDonListBindingSource
            // 
            this.loaiHoaDonListBindingSource.DataSource = typeof(ERP_Library.LoaiHoaDonList);
            // 
            // frmLoaiHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 400);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmLoaiHoaDon";
            this.Text = "Loại Hóa Đơn";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridLoaiHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loaiHoaDonListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem luuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.TextBox txtTenLoaiHoaDon;
        private System.Windows.Forms.TextBox txtMaLoaiHoaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridLoaiHoaDon;
        private System.Windows.Forms.BindingSource loaiHoaDonListBindingSource;
    }
}