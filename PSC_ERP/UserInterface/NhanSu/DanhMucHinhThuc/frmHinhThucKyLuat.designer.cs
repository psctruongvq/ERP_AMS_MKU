namespace PSC_ERP
{
    partial class frmHinhThucKyLuat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHinhThucKyLuat));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("HinhThucKyLuat", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKyLuat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenKyLyat");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ultragrdHInhThucKyLuat = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.hinhThucKyLuatListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.tlslblExportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.ultragrdHInhThucKyLuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hinhThucKyLuatListBindingSource)).BeginInit();
            this.tlsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(56, 22);
            this.tlslblUndo.Text = "Undo";
            this.tlslblUndo.Click += new System.EventHandler(this.tlslblUndo_Click);
            // 
            // tlslblXoa
            // 
            this.tlslblXoa.Image = ((System.Drawing.Image)(resources.GetObject("tlslblXoa.Image")));
            this.tlslblXoa.Name = "tlslblXoa";
            this.tlslblXoa.Size = new System.Drawing.Size(47, 22);
            this.tlslblXoa.Text = "&Xóa";
            this.tlslblXoa.Click += new System.EventHandler(this.tlslblXoa_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(47, 22);
            this.tlslblLuu.Text = "&Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // ultragrdHInhThucKyLuat
            // 
            this.ultragrdHInhThucKyLuat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ultragrdHInhThucKyLuat.DataSource = this.hinhThucKyLuatListBindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            this.ultragrdHInhThucKyLuat.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.ultragrdHInhThucKyLuat.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultragrdHInhThucKyLuat.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultragrdHInhThucKyLuat.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.ultragrdHInhThucKyLuat.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "Arial";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.ultragrdHInhThucKyLuat.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.ultragrdHInhThucKyLuat.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultragrdHInhThucKyLuat.DisplayLayout.Override.RowSelectorAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.ultragrdHInhThucKyLuat.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.ultragrdHInhThucKyLuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultragrdHInhThucKyLuat.Location = new System.Drawing.Point(0, 24);
            this.ultragrdHInhThucKyLuat.Name = "ultragrdHInhThucKyLuat";
            this.ultragrdHInhThucKyLuat.Size = new System.Drawing.Size(472, 320);
            this.ultragrdHInhThucKyLuat.TabIndex = 22;
            this.ultragrdHInhThucKyLuat.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultragrdHInhThucKyLuat_InitializeLayout);
            this.ultragrdHInhThucKyLuat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ultragrdHInhThucKyLuat_KeyDown);
            this.ultragrdHInhThucKyLuat.Leave += new System.EventHandler(this.ultragrdHInhThucKyLuat_Leave);
            // 
            // hinhThucKyLuatListBindingSource
            // 
            this.hinhThucKyLuatListBindingSource.AllowNew = true;
            this.hinhThucKyLuatListBindingSource.DataSource = typeof(ERP_Library.HinhThucKyLuatList);
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "&In";
            this.tlslblIn.Click += new System.EventHandler(this.tlslblIn_Click);
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblXoa,
            this.toolStripSeparator3,
            this.tlslblUndo,
            this.toolStripSeparator4,
            this.tlslblExportExcel,
            this.toolStripSeparator1,
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(473, 25);
            this.tlsMain.TabIndex = 23;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(73, 22);
            this.tlslblTroGiup.Text = "Trợ &Giúp";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(58, 22);
            this.tlslblThoat.Text = "Th&oát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // tlslblExportExcel
            // 
            this.tlslblExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("tlslblExportExcel.Image")));
            this.tlslblExportExcel.Name = "tlslblExportExcel";
            this.tlslblExportExcel.Size = new System.Drawing.Size(80, 22);
            this.tlslblExportExcel.Text = "&Xuất Excel";
            this.tlslblExportExcel.Click += new System.EventHandler(this.tlslblExportExcel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // frmHinhThucKyLuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 344);
            this.Controls.Add(this.ultragrdHInhThucKyLuat);
            this.Controls.Add(this.tlsMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHinhThucKyLuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hình Thức Kỷ Luật";
            ((System.ComponentModel.ISupportInitialize)(this.ultragrdHInhThucKyLuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hinhThucKyLuatListBindingSource)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultragrdHInhThucKyLuat;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.BindingSource hinhThucKyLuatListBindingSource;
        private System.Windows.Forms.ToolStripButton tlslblExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}