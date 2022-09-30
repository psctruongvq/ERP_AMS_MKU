namespace PSC_ERP
{
    partial class frmChonSoQuy
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("SoQuy", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaSoQuy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenSoQuy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NguoiLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            this.cbSoQuy = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bdSoQuy = new System.Windows.Forms.BindingSource(this.components);
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cbSoQuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSoQuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbChiPhi
            // 
            this.cbSoQuy.CheckedListSettings.CheckStateMember = "";
            this.cbSoQuy.DataSource = this.bdSoQuy;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 5;
            ultraGridColumn6.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6});
            this.cbSoQuy.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbSoQuy.DisplayMember = "TenSoQuy";
            this.cbSoQuy.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbSoQuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSoQuy.Location = new System.Drawing.Point(72, 22);
            this.cbSoQuy.Name = "cbChiPhi";
            this.cbSoQuy.Size = new System.Drawing.Size(196, 22);
            this.cbSoQuy.TabIndex = 5;
            this.cbSoQuy.ValueMember = "MaSoQuy";
            this.cbSoQuy.ValueChanged += new System.EventHandler(this.cbChiPhi_ValueChanged);
            this.cbSoQuy.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbChiPhi_InitializeLayout);
            // 
            // bdSoQuy
            // 
            this.bdSoQuy.AllowNew = true;
            this.bdSoQuy.DataSource = typeof(ERP_Library.SoQuyList);
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
            this.ultraGroupBox1.Controls.Add(this.cbSoQuy);
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
            this.ultraLabel1.Text = "Sổ Quỹ";
            // 
            // frmChonSoQuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 143);
            this.Controls.Add(this.ultraButton2);
            this.Controls.Add(this.ultraButton1);
            this.Controls.Add(this.ultraGroupBox1);
            this.Name = "frmChonSoQuy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Sổ Quỹ";
            this.Load += new System.EventHandler(this.frmChonChiPhi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbSoQuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdSoQuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bdSoQuy;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbSoQuy;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
    }
}