namespace PSC_ERP
{
    partial class frmChucDanh
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChucDanh", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChucDanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChucDanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhomChucDanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenViettat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GhiChu");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChucDanh));
            this.grdu_ChucDanh = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ChucDanh_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.NhomChucDanh_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NgachLuong_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbu_NhomChucDanh = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.tlslblExportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.grdu_ChucDanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChucDanh_bindingSource)).BeginInit();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NhomChucDanh_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgachLuong_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_NhomChucDanh)).BeginInit();
            this.SuspendLayout();
            // 
            // grdu_ChucDanh
            // 
            this.grdu_ChucDanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdu_ChucDanh.DataSource = this.ChucDanh_bindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            this.grdu_ChucDanh.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 2;
            ultraGridColumn2.Header.VisiblePosition = 5;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn5.Header.VisiblePosition = 3;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            this.grdu_ChucDanh.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdu_ChucDanh.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdu_ChucDanh.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdu_ChucDanh.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "Arial";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdu_ChucDanh.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.grdu_ChucDanh.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdu_ChucDanh.DisplayLayout.Override.RowSelectorAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdu_ChucDanh.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.grdu_ChucDanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdu_ChucDanh.Location = new System.Drawing.Point(0, 28);
            this.grdu_ChucDanh.Name = "grdu_ChucDanh";
            this.grdu_ChucDanh.Size = new System.Drawing.Size(809, 377);
            this.grdu_ChucDanh.TabIndex = 28;
            this.grdu_ChucDanh.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdu_ChucDanh_InitializeLayout);
            this.grdu_ChucDanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdu_ChucDanh_KeyDown);
            // 
            // ChucDanh_bindingSource
            // 
            this.ChucDanh_bindingSource.AllowNew = true;
            this.ChucDanh_bindingSource.DataSource = typeof(ERP_Library.ChucDanhList);
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblLuu,
            this.toolStripSeparator1,
            this.tlslblXoa,
            this.toolStripSeparator2,
            this.tlslblUndo,
            this.toolStripSeparator4,
            this.tlslblExportExcel,
            this.toolStripSeparator3,
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(809, 25);
            this.tlsMain.TabIndex = 29;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(47, 22);
            this.tlslblLuu.Text = "Lưu";
            this.tlslblLuu.Click += new System.EventHandler(this.tlslblLuu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblXoa
            // 
            this.tlslblXoa.Image = ((System.Drawing.Image)(resources.GetObject("tlslblXoa.Image")));
            this.tlslblXoa.Name = "tlslblXoa";
            this.tlslblXoa.Size = new System.Drawing.Size(47, 22);
            this.tlslblXoa.Text = "&Xóa";
            this.tlslblXoa.Click += new System.EventHandler(this.tlslblXoa_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(56, 22);
            this.tlslblUndo.Text = "Undo";
            this.tlslblUndo.Click += new System.EventHandler(this.tlslblUndo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "In";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(73, 22);
            this.tlslblTroGiup.Text = "Trợ Giúp";
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
            this.tlslblThoat.Text = "Thoát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // NhomChucDanh_bindingSource
            // 
            this.NhomChucDanh_bindingSource.AllowNew = true;
            this.NhomChucDanh_bindingSource.DataSource = typeof(ERP_Library.NhomChucDanhList);
            // 
            // NgachLuong_bindingSource
            // 
            this.NgachLuong_bindingSource.AllowNew = true;
            this.NgachLuong_bindingSource.DataSource = typeof(ERP_Library.NgachLuongNoiBoList);
            // 
            // cmbu_NhomChucDanh
            // 
            this.cmbu_NhomChucDanh.DataSource = this.NhomChucDanh_bindingSource;
            this.cmbu_NhomChucDanh.DisplayMember = "TenNhomChucDanh";
            this.cmbu_NhomChucDanh.Location = new System.Drawing.Point(404, 322);
            this.cmbu_NhomChucDanh.Name = "cmbu_NhomChucDanh";
            this.cmbu_NhomChucDanh.Size = new System.Drawing.Size(95, 21);
            this.cmbu_NhomChucDanh.TabIndex = 30;
            this.cmbu_NhomChucDanh.ValueMember = "MaNhomChucDanh";
            // 
            // tlslblExportExcel
            // 
            this.tlslblExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("tlslblExportExcel.Image")));
            this.tlslblExportExcel.Name = "tlslblExportExcel";
            this.tlslblExportExcel.Size = new System.Drawing.Size(80, 22);
            this.tlslblExportExcel.Text = "&Xuất Excel";
            this.tlslblExportExcel.Click += new System.EventHandler(this.tlslblExportExcel_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // frmChucDanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 402);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.grdu_ChucDanh);
            this.Controls.Add(this.cmbu_NhomChucDanh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChucDanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chức Danh";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChucDanh_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grdu_ChucDanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChucDanh_bindingSource)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NhomChucDanh_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgachLuong_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_NhomChucDanh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid grdu_ChucDanh;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.BindingSource ChucDanh_bindingSource;
        private System.Windows.Forms.BindingSource NhomChucDanh_bindingSource;
        private System.Windows.Forms.BindingSource NgachLuong_bindingSource;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbu_NhomChucDanh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripButton tlslblExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}