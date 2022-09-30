namespace PSC_ERP
{
    partial class frmChonChiPhi
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChiPhiHoatDong", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiPhiHD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChiPhiHDQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChiPhiHD");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NguoiLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SuDung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaHoaDong");
            this.cbChiPhi = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bdChiPhiHoatDong = new System.Windows.Forms.BindingSource(this.components);
            this.cbLoaiThu = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cbChiPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChiPhiHoatDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbChiPhi
            // 
            this.cbChiPhi.CheckedListSettings.CheckStateMember = "";
            this.cbChiPhi.DataSource = this.bdChiPhiHoatDong;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9});
            this.cbChiPhi.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbChiPhi.DisplayMember = "TenChiPhiHD";
            this.cbChiPhi.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbChiPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChiPhi.Location = new System.Drawing.Point(72, 22);
            this.cbChiPhi.Name = "cbChiPhi";
            this.cbChiPhi.Size = new System.Drawing.Size(196, 22);
            this.cbChiPhi.TabIndex = 5;
            this.cbChiPhi.ValueMember = "MaChiPhiHD";
            this.cbChiPhi.ValueChanged += new System.EventHandler(this.cbChiPhi_ValueChanged);
            this.cbChiPhi.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbChiPhi_InitializeLayout);
            // 
            // bdChiPhiHoatDong
            // 
            this.bdChiPhiHoatDong.AllowNew = true;
            this.bdChiPhiHoatDong.DataSource = typeof(ERP_Library.ChiPhiHoatDongList);
            // 
            // cbLoaiThu
            // 
            this.cbLoaiThu.Location = new System.Drawing.Point(274, 23);
            this.cbLoaiThu.Name = "cbLoaiThu";
            this.cbLoaiThu.Size = new System.Drawing.Size(112, 20);
            this.cbLoaiThu.TabIndex = 6;
            this.cbLoaiThu.Text = "Loại Thu";
            this.cbLoaiThu.CheckedChanged += new System.EventHandler(this.cbLoaiThu_CheckedChanged);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(87, 73);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(92, 33);
            this.ultraButton1.TabIndex = 7;
            this.ultraButton1.Text = "Chọn";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(205, 73);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(92, 33);
            this.ultraButton2.TabIndex = 8;
            this.ultraButton2.Text = "Hủy";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.ultraLabel1);
            this.ultraGroupBox1.Controls.Add(this.cbChiPhi);
            this.ultraGroupBox1.Controls.Add(this.cbLoaiThu);
            this.ultraGroupBox1.Location = new System.Drawing.Point(12, 3);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(395, 64);
            this.ultraGroupBox1.TabIndex = 9;
            // 
            // ultraLabel1
            // 
            this.ultraLabel1.Location = new System.Drawing.Point(7, 23);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(59, 23);
            this.ultraLabel1.TabIndex = 7;
            this.ultraLabel1.Text = "Chi phí";
            // 
            // frmChonChiPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 143);
            this.Controls.Add(this.ultraButton2);
            this.Controls.Add(this.ultraButton1);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmChonChiPhi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Chi Phí";
            this.Load += new System.EventHandler(this.frmChonChiPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbChiPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChiPhiHoatDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bdChiPhiHoatDong;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbChiPhi;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor cbLoaiThu;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    }
}