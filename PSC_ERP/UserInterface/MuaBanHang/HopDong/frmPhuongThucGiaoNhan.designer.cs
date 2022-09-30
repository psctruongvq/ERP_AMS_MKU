namespace PSC_ERP
{
    partial class frmPhuongThucGiaoNhan
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("PhuongThucGiaoNhan", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPTGNQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenPhuongThuc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhuongThucGiaoNhan");
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPhuongThucGiaoNhan));
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.txtTenPTGN = new System.Windows.Forms.TextBox();
            this.txtMaPTGN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGridPuongThucGN = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.phuongThucGiaoNhanListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridPuongThucGN)).BeginInit();
            this.tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phuongThucGiaoNhanListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            appearance7.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox1.Appearance = appearance7;
            this.ultraGroupBox1.Controls.Add(this.txtTenPTGN);
            this.ultraGroupBox1.Controls.Add(this.txtMaPTGN);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.label1);
            appearance8.FontData.BoldAsString = "True";
            this.ultraGroupBox1.HeaderAppearance = appearance8;
            this.ultraGroupBox1.Location = new System.Drawing.Point(8, 33);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(543, 54);
            this.ultraGroupBox1.TabIndex = 0;
            this.ultraGroupBox1.Text = "Thông Tin";
            // 
            // txtTenPTGN
            // 
            this.txtTenPTGN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phuongThucGiaoNhanListBindingSource, "TenPhuongThuc", true));
            this.txtTenPTGN.Location = new System.Drawing.Point(263, 23);
            this.txtTenPTGN.Name = "txtTenPTGN";
            this.txtTenPTGN.Size = new System.Drawing.Size(254, 20);
            this.txtTenPTGN.TabIndex = 1;
            // 
            // txtMaPTGN
            // 
            this.txtMaPTGN.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.phuongThucGiaoNhanListBindingSource, "MaPTGNQL", true));
            this.txtMaPTGN.Location = new System.Drawing.Point(85, 23);
            this.txtMaPTGN.Name = "txtMaPTGN";
            this.txtMaPTGN.Size = new System.Drawing.Size(84, 20);
            this.txtMaPTGN.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên PTGN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã PTGN";
            // 
            // ultraGroupBox2
            // 
            appearance9.BackColor = System.Drawing.Color.Transparent;
            this.ultraGroupBox2.Appearance = appearance9;
            this.ultraGroupBox2.Controls.Add(this.ultraGridPuongThucGN);
            appearance12.FontData.BoldAsString = "True";
            this.ultraGroupBox2.HeaderAppearance = appearance12;
            this.ultraGroupBox2.Location = new System.Drawing.Point(8, 90);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(542, 305);
            this.ultraGroupBox2.TabIndex = 1;
            this.ultraGroupBox2.Text = "Danh Sách Phương Thức Giao Nhận";
            // 
            // ultraGridPuongThucGN
            // 
            this.ultraGridPuongThucGN.DataSource = this.phuongThucGiaoNhanListBindingSource;
            appearance10.FontData.BoldAsString = "False";
            this.ultraGridPuongThucGN.DisplayLayout.Appearance = appearance10;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3});
            this.ultraGridPuongThucGN.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraGridPuongThucGN.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance11.BackColor = System.Drawing.Color.SteelBlue;
            this.ultraGridPuongThucGN.DisplayLayout.Override.HeaderAppearance = appearance11;
            this.ultraGridPuongThucGN.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            this.ultraGridPuongThucGN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ultraGridPuongThucGN.Location = new System.Drawing.Point(6, 19);
            this.ultraGridPuongThucGN.Name = "ultraGridPuongThucGN";
            this.ultraGridPuongThucGN.Size = new System.Drawing.Size(529, 279);
            this.ultraGridPuongThucGN.TabIndex = 0;
            this.ultraGridPuongThucGN.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.ultraGridPuongThucGN_InitializeLayout);
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblThem,
            this.toolStripSeparator1,
            this.tlslblLuu,
            this.toolStripSeparator2,
            this.tlslblXoa,
            this.toolStripSeparator3,
            this.tlslblIn,
            this.toolStripButton1,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(558, 25);
            this.tlsMain.TabIndex = 12;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblThem
            // 
            this.tlslblThem.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThem.Image")));
            this.tlslblThem.Name = "tlslblThem";
            this.tlslblThem.Size = new System.Drawing.Size(53, 22);
            this.tlslblThem.Text = "Thê&m";
            this.tlslblThem.ToolTipText = "Ctr+M";
            this.tlslblThem.Click += new System.EventHandler(this.thêmToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblLuu
            // 
            this.tlslblLuu.Image = ((System.Drawing.Image)(resources.GetObject("tlslblLuu.Image")));
            this.tlslblLuu.Name = "tlslblLuu";
            this.tlslblLuu.Size = new System.Drawing.Size(45, 22);
            this.tlslblLuu.Text = "&Lưu";
            this.tlslblLuu.ToolTipText = "Ctr+L";
            this.tlslblLuu.Click += new System.EventHandler(this.luuToolStripMenuItem_Click);
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
            this.tlslblXoa.Size = new System.Drawing.Size(45, 22);
            this.tlslblXoa.Text = "&Xóa";
            this.tlslblXoa.ToolTipText = "Ctr+X";
            this.tlslblXoa.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblIn
            // 
            this.tlslblIn.Image = ((System.Drawing.Image)(resources.GetObject("tlslblIn.Image")));
            this.tlslblIn.Name = "tlslblIn";
            this.tlslblIn.Size = new System.Drawing.Size(37, 22);
            this.tlslblIn.Text = "&In";
            this.tlslblIn.ToolTipText = "Ctr+I";
            this.tlslblIn.Click += new System.EventHandler(this.inToolStripMenuItem_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblThoat
            // 
            this.tlslblThoat.Image = ((System.Drawing.Image)(resources.GetObject("tlslblThoat.Image")));
            this.tlslblThoat.Name = "tlslblThoat";
            this.tlslblThoat.Size = new System.Drawing.Size(55, 22);
            this.tlslblThoat.Text = "Th&oát";
            this.tlslblThoat.ToolTipText = "Ctr+O";
            this.tlslblThoat.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // phuongThucGiaoNhanListBindingSource
            // 
            this.phuongThucGiaoNhanListBindingSource.DataSource = typeof(ERP_Library.PhuongThucGiaoNhanList);
            // 
            // frmPhuongThucGiaoNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 404);
            this.Controls.Add(this.tlsMain);
            this.Controls.Add(this.ultraGroupBox2);
            this.Controls.Add(this.ultraGroupBox1);
            this.KeyPreview = true;
            this.Name = "frmPhuongThucGiaoNhan";
            this.Text = "Phương Thức Giao Nhận";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPhuongThucGiaoNhan_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGridPuongThucGN)).EndInit();
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.phuongThucGiaoNhanListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.TextBox txtTenPTGN;
        private System.Windows.Forms.TextBox txtMaPTGN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.UltraWinGrid.UltraGrid ultraGridPuongThucGN;
        private System.Windows.Forms.BindingSource phuongThucGiaoNhanListBindingSource;
        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblThem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tlslblLuu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tlslblXoa;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tlslblIn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
    }
}