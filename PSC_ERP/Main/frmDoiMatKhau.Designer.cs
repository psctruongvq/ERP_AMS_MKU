namespace PSC_ERP.Main
{
    partial class frmDoiMatKhau
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtMKCu = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.txtMKMoi = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKiemTra = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDongY = new Infragistics.Win.Misc.UltraButton();
            this.btnKhong = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKCu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKMoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKiemTra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mật khẩu cũ";
            // 
            // txtMKCu
            // 
            this.txtMKCu.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtMKCu.Location = new System.Drawing.Point(89, 12);
            this.txtMKCu.Name = "txtMKCu";
            this.txtMKCu.PasswordChar = '*';
            this.txtMKCu.Size = new System.Drawing.Size(166, 21);
            this.txtMKCu.TabIndex = 1;
            this.txtMKCu.TextChanged += new System.EventHandler(this.txtMKCu_TextChanged);
            // 
            // txtMKMoi
            // 
            this.txtMKMoi.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtMKMoi.Enabled = false;
            this.txtMKMoi.Location = new System.Drawing.Point(89, 39);
            this.txtMKMoi.Name = "txtMKMoi";
            this.txtMKMoi.PasswordChar = '*';
            this.txtMKMoi.Size = new System.Drawing.Size(166, 21);
            this.txtMKMoi.TabIndex = 3;
            this.txtMKMoi.TextChanged += new System.EventHandler(this.HopLe);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu mới";
            // 
            // txtKiemTra
            // 
            this.txtKiemTra.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtKiemTra.Enabled = false;
            this.txtKiemTra.Location = new System.Drawing.Point(89, 66);
            this.txtKiemTra.Name = "txtKiemTra";
            this.txtKiemTra.PasswordChar = '*';
            this.txtKiemTra.Size = new System.Drawing.Size(166, 21);
            this.txtKiemTra.TabIndex = 5;
            this.txtKiemTra.TextChanged += new System.EventHandler(this.HopLe);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kiểm tra";
            // 
            // btnDongY
            // 
            this.btnDongY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDongY.Enabled = false;
            this.btnDongY.Location = new System.Drawing.Point(55, 104);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(79, 32);
            this.btnDongY.TabIndex = 6;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKhong.Location = new System.Drawing.Point(140, 104);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(79, 32);
            this.btnKhong.TabIndex = 7;
            this.btnKhong.Text = "Không";
            this.btnKhong.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 146);
            this.ControlBox = false;
            this.Controls.Add(this.btnKhong);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.txtKiemTra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMKMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMKCu);
            this.Controls.Add(this.label1);
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMKCu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKMoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKiemTra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMKCu;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtMKMoi;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtKiemTra;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.Misc.UltraButton btnDongY;
        private Infragistics.Win.Misc.UltraButton btnKhong;
    }
}