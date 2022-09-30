namespace PSC_ERP
{
    partial class frmKetChuyenTaiKhoanTheoDoiTuong
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
            this.kyListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.bt_NhapSoDu = new System.Windows.Forms.Button();
            this.cb_NamKeToan = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kyListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // kyListBindingSource
            // 
            this.kyListBindingSource.DataSource = typeof(ERP_Library.KyList);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Năm kết chuyển";
            // 
            // bt_NhapSoDu
            // 
            this.bt_NhapSoDu.Location = new System.Drawing.Point(276, 24);
            this.bt_NhapSoDu.Name = "bt_NhapSoDu";
            this.bt_NhapSoDu.Size = new System.Drawing.Size(87, 23);
            this.bt_NhapSoDu.TabIndex = 15;
            this.bt_NhapSoDu.Text = "Xem";
            this.bt_NhapSoDu.UseVisualStyleBackColor = true;
            this.bt_NhapSoDu.Click += new System.EventHandler(this.bt_NhapSoDu_Click);
            // 
            // cb_NamKeToan
            // 
            this.cb_NamKeToan.FormattingEnabled = true;
            this.cb_NamKeToan.Location = new System.Drawing.Point(103, 25);
            this.cb_NamKeToan.Name = "cb_NamKeToan";
            this.cb_NamKeToan.Size = new System.Drawing.Size(167, 21);
            this.cb_NamKeToan.TabIndex = 16;
            // 
            // frmKetChuyenTaiKhoanTheoDoiTuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 78);
            this.Controls.Add(this.cb_NamKeToan);
            this.Controls.Add(this.bt_NhapSoDu);
            this.Controls.Add(this.label4);
            this.Name = "frmKetChuyenTaiKhoanTheoDoiTuong";
            this.Text = "Kết Chuyển Tài Khoản Theo Đối Tượng";
            ((System.ComponentModel.ISupportInitialize)(this.kyListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource kyListBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_NhapSoDu;
        private System.Windows.Forms.ComboBox cb_NamKeToan;

    }
}