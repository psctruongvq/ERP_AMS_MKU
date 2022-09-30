namespace PSC_ERP
{
    partial class frmDanhSach_BaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDanhSach_BaoCao));
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.tlslblUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTim = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblTroGiup = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tlslblThoat = new System.Windows.Forms.ToolStripButton();
            this.trvbaocao = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpGiaHanHD = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbu_HDLDBoPhan = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.BindS_BoPhan = new System.Windows.Forms.BindingSource(this.components);
            this.dtp_HDLDDenngay = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.grpBiaHS = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdu_Biahoso = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.BindS_BiaHS = new System.Windows.Forms.BindingSource(this.components);
            this.grpBHXH = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbu_BiaBHXH = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.BindS_BiaBHXH = new System.Windows.Forms.BindingSource(this.components);
            this.imgTree = new System.Windows.Forms.ImageList(this.components);
            this.tlsMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpGiaHanHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_HDLDBoPhan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).BeginInit();
            this.grpBiaHS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdu_Biahoso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BiaHS)).BeginInit();
            this.grpBHXH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_BiaBHXH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BiaBHXH)).BeginInit();
            this.SuspendLayout();
            // 
            // tlsMain
            // 
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlslblUndo,
            this.toolStripSeparator4,
            this.tlslblTim,
            this.toolStripLabel1,
            this.tlslblTroGiup,
            this.toolStripSeparator5,
            this.tlslblThoat});
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(776, 25);
            this.tlsMain.TabIndex = 55;
            this.tlsMain.Text = "toolStrip1";
            // 
            // tlslblUndo
            // 
            this.tlslblUndo.Image = ((System.Drawing.Image)(resources.GetObject("tlslblUndo.Image")));
            this.tlslblUndo.Name = "tlslblUndo";
            this.tlslblUndo.Size = new System.Drawing.Size(52, 22);
            this.tlslblUndo.Text = "&Undo";
            this.tlslblUndo.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // tlslblTim
            // 
            this.tlslblTim.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTim.Image")));
            this.tlslblTim.Name = "tlslblTim";
            this.tlslblTim.Size = new System.Drawing.Size(59, 22);
            this.tlslblTim.Text = "&Xem...";
            this.tlslblTim.Click += new System.EventHandler(this.tlslblTim_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(6, 25);
            // 
            // tlslblTroGiup
            // 
            this.tlslblTroGiup.Image = ((System.Drawing.Image)(resources.GetObject("tlslblTroGiup.Image")));
            this.tlslblTroGiup.Name = "tlslblTroGiup";
            this.tlslblTroGiup.Size = new System.Drawing.Size(67, 22);
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
            this.tlslblThoat.Size = new System.Drawing.Size(55, 22);
            this.tlslblThoat.Text = "Th&oát";
            this.tlslblThoat.Click += new System.EventHandler(this.tlslblThoat_Click);
            // 
            // trvbaocao
            // 
            this.trvbaocao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.trvbaocao.Location = new System.Drawing.Point(7, 28);
            this.trvbaocao.Name = "trvbaocao";
            this.trvbaocao.Size = new System.Drawing.Size(355, 356);
            this.trvbaocao.TabIndex = 56;
            this.trvbaocao.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvbaocao_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grpGiaHanHD);
            this.groupBox1.Controls.Add(this.grpBiaHS);
            this.groupBox1.Controls.Add(this.grpBHXH);
            this.groupBox1.Location = new System.Drawing.Point(368, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 356);
            this.groupBox1.TabIndex = 57;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Báo Cáo";
            // 
            // grpGiaHanHD
            // 
            this.grpGiaHanHD.Controls.Add(this.label4);
            this.grpGiaHanHD.Controls.Add(this.cmbu_HDLDBoPhan);
            this.grpGiaHanHD.Controls.Add(this.dtp_HDLDDenngay);
            this.grpGiaHanHD.Controls.Add(this.label3);
            this.grpGiaHanHD.Location = new System.Drawing.Point(6, 140);
            this.grpGiaHanHD.Name = "grpGiaHanHD";
            this.grpGiaHanHD.Size = new System.Drawing.Size(384, 85);
            this.grpGiaHanHD.TabIndex = 2;
            this.grpGiaHanHD.TabStop = false;
            this.grpGiaHanHD.Text = "Gia Hạn Hợp Đồng";
            this.grpGiaHanHD.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "Bộ Phận";
            // 
            // cmbu_HDLDBoPhan
            // 
            this.cmbu_HDLDBoPhan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance3.FontData.BoldAsString = "False";
            this.cmbu_HDLDBoPhan.Appearance = appearance3;
            this.cmbu_HDLDBoPhan.DataSource = this.BindS_BoPhan;
            this.cmbu_HDLDBoPhan.DisplayMember = "TenBoPhan";
            this.cmbu_HDLDBoPhan.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_HDLDBoPhan.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbu_HDLDBoPhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_HDLDBoPhan.Location = new System.Drawing.Point(104, 44);
            this.cmbu_HDLDBoPhan.Name = "cmbu_HDLDBoPhan";
            this.cmbu_HDLDBoPhan.Size = new System.Drawing.Size(274, 21);
            this.cmbu_HDLDBoPhan.TabIndex = 45;
            this.cmbu_HDLDBoPhan.ValueMember = "MaBoPhan";
            // 
            // BindS_BoPhan
            // 
            this.BindS_BoPhan.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // dtp_HDLDDenngay
            // 
            this.dtp_HDLDDenngay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_HDLDDenngay.Location = new System.Drawing.Point(104, 18);
            this.dtp_HDLDDenngay.Name = "dtp_HDLDDenngay";
            this.dtp_HDLDDenngay.Size = new System.Drawing.Size(274, 20);
            this.dtp_HDLDDenngay.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Tính Đến Ngày";
            // 
            // grpBiaHS
            // 
            this.grpBiaHS.Controls.Add(this.label1);
            this.grpBiaHS.Controls.Add(this.cmdu_Biahoso);
            this.grpBiaHS.Location = new System.Drawing.Point(6, 78);
            this.grpBiaHS.Name = "grpBiaHS";
            this.grpBiaHS.Size = new System.Drawing.Size(384, 56);
            this.grpBiaHS.TabIndex = 1;
            this.grpBiaHS.TabStop = false;
            this.grpBiaHS.Text = "Bìa HS";
            this.grpBiaHS.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Bìa hồ sơ";
            // 
            // cmdu_Biahoso
            // 
            this.cmdu_Biahoso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance1.FontData.BoldAsString = "False";
            this.cmdu_Biahoso.Appearance = appearance1;
            this.cmdu_Biahoso.DataSource = this.BindS_BiaHS;
            this.cmdu_Biahoso.DisplayMember = "TenBiaHoSo";
            this.cmdu_Biahoso.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmdu_Biahoso.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmdu_Biahoso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdu_Biahoso.Location = new System.Drawing.Point(74, 19);
            this.cmdu_Biahoso.Name = "cmdu_Biahoso";
            this.cmdu_Biahoso.Size = new System.Drawing.Size(304, 21);
            this.cmdu_Biahoso.TabIndex = 42;
            this.cmdu_Biahoso.ValueMember = "MaBiaHoSo";
            // 
            // BindS_BiaHS
            // 
            this.BindS_BiaHS.DataSource = typeof(ERP_Library.BiaHoSoList);
            // 
            // grpBHXH
            // 
            this.grpBHXH.Controls.Add(this.label2);
            this.grpBHXH.Controls.Add(this.cmbu_BiaBHXH);
            this.grpBHXH.Location = new System.Drawing.Point(6, 19);
            this.grpBHXH.Name = "grpBHXH";
            this.grpBHXH.Size = new System.Drawing.Size(384, 53);
            this.grpBHXH.TabIndex = 0;
            this.grpBHXH.TabStop = false;
            this.grpBHXH.Text = "Bìa BHXH";
            this.grpBHXH.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Bìa BHXH";
            // 
            // cmbu_BiaBHXH
            // 
            this.cmbu_BiaBHXH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            appearance2.FontData.BoldAsString = "False";
            this.cmbu_BiaBHXH.Appearance = appearance2;
            this.cmbu_BiaBHXH.DataSource = this.BindS_BiaBHXH;
            this.cmbu_BiaBHXH.DisplayMember = "TenBiaBHXH";
            this.cmbu_BiaBHXH.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_BiaBHXH.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbu_BiaBHXH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbu_BiaBHXH.Location = new System.Drawing.Point(74, 19);
            this.cmbu_BiaBHXH.Name = "cmbu_BiaBHXH";
            this.cmbu_BiaBHXH.Size = new System.Drawing.Size(304, 21);
            this.cmbu_BiaBHXH.TabIndex = 44;
            this.cmbu_BiaBHXH.ValueMember = "MaBiaBHXH";
            // 
            // BindS_BiaBHXH
            // 
            this.BindS_BiaBHXH.DataSource = typeof(ERP_Library.BiaBHXHList);
            // 
            // imgTree
            // 
            this.imgTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTree.ImageStream")));
            this.imgTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTree.Images.SetKeyName(0, "267.gif");
            this.imgTree.Images.SetKeyName(1, "260.gif");
            this.imgTree.Images.SetKeyName(2, "344.gif");
            this.imgTree.Images.SetKeyName(3, "980.gif");
            // 
            // frmDanhSach_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 387);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.trvbaocao);
            this.Controls.Add(this.tlsMain);
            this.Name = "frmDanhSach_BaoCao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo";
            this.Load += new System.EventHandler(this.frmDanhSach_BaoCao_Load);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grpGiaHanHD.ResumeLayout(false);
            this.grpGiaHanHD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_HDLDBoPhan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BoPhan)).EndInit();
            this.grpBiaHS.ResumeLayout(false);
            this.grpBiaHS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmdu_Biahoso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BiaHS)).EndInit();
            this.grpBHXH.ResumeLayout(false);
            this.grpBHXH.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_BiaBHXH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BindS_BiaBHXH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton tlslblUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tlslblTim;
        private System.Windows.Forms.ToolStripSeparator toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tlslblTroGiup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tlslblThoat;
        private System.Windows.Forms.TreeView trvbaocao;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList imgTree;
        private System.Windows.Forms.GroupBox grpBHXH;
        private System.Windows.Forms.GroupBox grpBiaHS;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmdu_Biahoso;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbu_BiaBHXH;
        private System.Windows.Forms.BindingSource BindS_BiaHS;
        private System.Windows.Forms.BindingSource BindS_BiaBHXH;
        private System.Windows.Forms.GroupBox grpGiaHanHD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtp_HDLDDenngay;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbu_HDLDBoPhan;
        private System.Windows.Forms.BindingSource BindS_BoPhan;
    }
}