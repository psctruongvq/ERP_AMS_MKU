namespace PSC_ERP
{
    partial class frmSapXepBoPhan
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
            this.cbBoPhanCha = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.bindingSource1_BoPhanCha = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.ultraButton2 = new Infragistics.Win.Misc.UltraButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLoaiBP = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.bindingSource1_LoaiBoPhan = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cbBoPhanCha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_BoPhanCha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiBP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LoaiBoPhan)).BeginInit();
            this.SuspendLayout();
            // 
            // cbBoPhanCha
            // 
            this.cbBoPhanCha.DataSource = this.bindingSource1_BoPhanCha;
            this.cbBoPhanCha.DisplayMember = "TenBoPhan";
            this.cbBoPhanCha.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbBoPhanCha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBoPhanCha.Location = new System.Drawing.Point(119, 26);
            this.cbBoPhanCha.Name = "cbBoPhanCha";
            this.cbBoPhanCha.Size = new System.Drawing.Size(182, 21);
            this.cbBoPhanCha.TabIndex = 6;
            this.cbBoPhanCha.ValueMember = "MaBoPhan";
            this.cbBoPhanCha.ValueChanged += new System.EventHandler(this.cbBoPhanCha_ValueChanged);
            // 
            // bindingSource1_BoPhanCha
            // 
            this.bindingSource1_BoPhanCha.DataSource = typeof(ERP_Library.BoPhanList);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(21, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tên Bộ Phận Cha";
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(221, 61);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(96, 24);
            this.ultraButton1.TabIndex = 10;
            this.ultraButton1.Text = "OK";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // ultraButton2
            // 
            this.ultraButton2.Location = new System.Drawing.Point(354, 61);
            this.ultraButton2.Name = "ultraButton2";
            this.ultraButton2.Size = new System.Drawing.Size(96, 24);
            this.ultraButton2.TabIndex = 11;
            this.ultraButton2.Text = "Cancel";
            this.ultraButton2.Click += new System.EventHandler(this.ultraButton2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(328, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Loại Bộ Phận";
            // 
            // cbLoaiBP
            // 
            this.cbLoaiBP.DataSource = this.bindingSource1_LoaiBoPhan;
            this.cbLoaiBP.DisplayMember = "TenLoaiBoPhan";
            this.cbLoaiBP.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbLoaiBP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiBP.Location = new System.Drawing.Point(414, 26);
            this.cbLoaiBP.Name = "cbLoaiBP";
            this.cbLoaiBP.Size = new System.Drawing.Size(166, 21);
            this.cbLoaiBP.TabIndex = 13;
            this.cbLoaiBP.ValueMember = "MaLoaiBoPhan";
            this.cbLoaiBP.ValueChanged += new System.EventHandler(this.cbLoaiBP_ValueChanged);
            // 
            // bindingSource1_LoaiBoPhan
            // 
            this.bindingSource1_LoaiBoPhan.DataSource = typeof(ERP_Library.LoaiBoPhanList);
            // 
            // frmSapXepBoPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 114);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbLoaiBP);
            this.Controls.Add(this.ultraButton2);
            this.Controls.Add(this.ultraButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbBoPhanCha);
            this.Name = "frmSapXepBoPhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sắp Xếp Bộ Phận";
            this.Load += new System.EventHandler(this.frmDinhViBoPhan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbBoPhanCha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_BoPhanCha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLoaiBP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_LoaiBoPhan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1_BoPhanCha;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbBoPhanCha;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private Infragistics.Win.Misc.UltraButton ultraButton2;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbLoaiBP;
        private System.Windows.Forms.BindingSource bindingSource1_LoaiBoPhan;
    }
}