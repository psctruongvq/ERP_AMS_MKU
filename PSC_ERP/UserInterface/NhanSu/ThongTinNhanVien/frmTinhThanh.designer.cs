namespace PSC_ERP
{
    partial class frmTinhThanh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTinhThanh));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("TinhThanh", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuocGia");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTinhThanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTinhThanhQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenTinhThanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DienGiai");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKhuVuc");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.grdTinhThanh = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.TinhThanh_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbu_KhuVuc = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.KhuVuc_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbu_QuocGia = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.QuocGia_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tlslblExportExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTinhThanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TinhThanh_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_KhuVuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KhuVuc_bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuocGia_bindingSource)).BeginInit();
            this.SuspendLayout();
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
            this.tlsMain.Size = new System.Drawing.Size(687, 25);
            this.tlsMain.TabIndex = 40;
            this.tlsMain.Text = "toolStrip1";
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
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(56, 22);
            this.tlslblUndo.Text = "&Undo";
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
            this.tlslblIn.Text = "&In";
            this.tlslblIn.Click += new System.EventHandler(this.tlslblIn_Click);
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
            // grdTinhThanh
            // 
            this.grdTinhThanh.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTinhThanh.DataSource = this.TinhThanh_bindingSource;
            appearance1.BackColor = System.Drawing.Color.White;
            this.grdTinhThanh.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 1;
            ultraGridColumn2.Header.VisiblePosition = 3;
            ultraGridColumn3.Header.VisiblePosition = 5;
            ultraGridColumn4.Header.VisiblePosition = 4;
            ultraGridColumn4.Width = 136;
            ultraGridColumn5.Header.VisiblePosition = 2;
            ultraGridColumn5.Width = 188;
            ultraGridColumn6.Header.VisiblePosition = 0;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            this.grdTinhThanh.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdTinhThanh.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grdTinhThanh.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance2.BackColor = System.Drawing.Color.Transparent;
            this.grdTinhThanh.DisplayLayout.Override.CardAreaAppearance = appearance2;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance3.FontData.BoldAsString = "True";
            appearance3.FontData.Name = "Arial";
            appearance3.FontData.SizeInPoints = 10F;
            appearance3.ForeColor = System.Drawing.Color.White;
            appearance3.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdTinhThanh.DisplayLayout.Override.HeaderAppearance = appearance3;
            this.grdTinhThanh.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdTinhThanh.DisplayLayout.Override.RowSelectorAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdTinhThanh.DisplayLayout.Override.SelectedRowAppearance = appearance5;
            this.grdTinhThanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grdTinhThanh.Location = new System.Drawing.Point(0, 28);
            this.grdTinhThanh.Name = "grdTinhThanh";
            this.grdTinhThanh.Size = new System.Drawing.Size(687, 447);
            this.grdTinhThanh.TabIndex = 41;
            this.grdTinhThanh.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grdTinhThanh_InitializeLayout);
            this.grdTinhThanh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdTinhThanh_KeyDown);
            this.grdTinhThanh.Leave += new System.EventHandler(this.grdTinhThanh_Leave);
            // 
            // TinhThanh_bindingSource
            // 
            this.TinhThanh_bindingSource.AllowNew = true;
            this.TinhThanh_bindingSource.DataSource = typeof(ERP_Library.TinhThanhList);
            // 
            // cmbu_KhuVuc
            // 
            this.cmbu_KhuVuc.DataSource = this.KhuVuc_bindingSource;
            this.cmbu_KhuVuc.DisplayMember = "TenKhuVuc";
            this.cmbu_KhuVuc.Location = new System.Drawing.Point(358, 152);
            this.cmbu_KhuVuc.Name = "cmbu_KhuVuc";
            this.cmbu_KhuVuc.Size = new System.Drawing.Size(123, 21);
            this.cmbu_KhuVuc.TabIndex = 42;
            this.cmbu_KhuVuc.ValueMember = "MaKhuVuc";
            this.cmbu_KhuVuc.ValueChanged += new System.EventHandler(this.cmbu_KhuVuc_ValueChanged);
            // 
            // KhuVuc_bindingSource
            // 
            this.KhuVuc_bindingSource.AllowNew = true;
            this.KhuVuc_bindingSource.DataSource = typeof(ERP_Library.KhuVucList);
            // 
            // cmbu_QuocGia
            // 
            this.cmbu_QuocGia.DataSource = this.QuocGia_bindingSource;
            this.cmbu_QuocGia.DisplayMember = "TenQuocGia";
            this.cmbu_QuocGia.Location = new System.Drawing.Point(229, 152);
            this.cmbu_QuocGia.Name = "cmbu_QuocGia";
            this.cmbu_QuocGia.Size = new System.Drawing.Size(123, 21);
            this.cmbu_QuocGia.TabIndex = 43;
            this.cmbu_QuocGia.ValueMember = "MaQuocGia";
            // 
            // QuocGia_bindingSource
            // 
            this.QuocGia_bindingSource.AllowNew = true;
            this.QuocGia_bindingSource.DataSource = typeof(ERP_Library.QuocGiaList);
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
            // frmTinhThanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 473);
            this.Controls.Add(this.grdTinhThanh);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.cmbu_QuocGia);
            this.Controls.Add(this.cmbu_KhuVuc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTinhThanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tỉnh Thành";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTinhThanh_KeyDown);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTinhThanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TinhThanh_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_KhuVuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KhuVuc_bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_QuocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuocGia_bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.BindingSource TinhThanh_bindingSource;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdTinhThanh;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbu_KhuVuc;
        private System.Windows.Forms.BindingSource KhuVuc_bindingSource;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbu_QuocGia;
        private System.Windows.Forms.BindingSource QuocGia_bindingSource;
        private System.Windows.Forms.ToolStripButton tlslblExportExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}