namespace PSC_ERP
{
    partial class frmTuNgayDenNgay
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDenKyTinhLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.bindingSource1_KyTinhLuong2 = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbTuKyTinhLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.bindingSource1_KyTinhLuong = new System.Windows.Forms.BindingSource(this.components);
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDenKyTinhLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTuKyTinhLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.label1);
            this.ultraGroupBox1.Controls.Add(this.cbDenKyTinhLuong);
            this.ultraGroupBox1.Controls.Add(this.label2);
            this.ultraGroupBox1.Controls.Add(this.cbTuKyTinhLuong);
            this.ultraGroupBox1.Controls.Add(this.ultraButton1);
            this.ultraGroupBox1.Location = new System.Drawing.Point(20, 11);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(611, 97);
            this.ultraGroupBox1.TabIndex = 43;
            this.ultraGroupBox1.Text = "Chọn Kỳ Tính Lương";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 70;
            this.label1.Text = "Đến Kỳ";
            // 
            // cbDenKyTinhLuong
            // 
            appearance8.FontData.BoldAsString = "False";
            this.cbDenKyTinhLuong.Appearance = appearance8;
            this.cbDenKyTinhLuong.DataSource = this.bindingSource1_KyTinhLuong2;
            this.cbDenKyTinhLuong.DisplayMember = "TenKy";
            this.cbDenKyTinhLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbDenKyTinhLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbDenKyTinhLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDenKyTinhLuong.Location = new System.Drawing.Point(316, 40);
            this.cbDenKyTinhLuong.Name = "cbDenKyTinhLuong";
            this.cbDenKyTinhLuong.Size = new System.Drawing.Size(173, 21);
            this.cbDenKyTinhLuong.TabIndex = 69;
            this.cbDenKyTinhLuong.ValueMember = "MaKy";
            // 
            // bindingSource1_KyTinhLuong2
            // 
            this.bindingSource1_KyTinhLuong2.DataSource = typeof(ERP_Library.KyTinhLuongList);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Từ Kỳ";
            // 
            // cbTuKyTinhLuong
            // 
            appearance2.FontData.BoldAsString = "False";
            this.cbTuKyTinhLuong.Appearance = appearance2;
            this.cbTuKyTinhLuong.DataSource = this.bindingSource1_KyTinhLuong;
            this.cbTuKyTinhLuong.DisplayMember = "TenKy";
            this.cbTuKyTinhLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbTuKyTinhLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbTuKyTinhLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTuKyTinhLuong.Location = new System.Drawing.Point(47, 40);
            this.cbTuKyTinhLuong.Name = "cbTuKyTinhLuong";
            this.cbTuKyTinhLuong.Size = new System.Drawing.Size(173, 21);
            this.cbTuKyTinhLuong.TabIndex = 67;
            this.cbTuKyTinhLuong.ValueMember = "MaKy";
            // 
            // bindingSource1_KyTinhLuong
            // 
            this.bindingSource1_KyTinhLuong.DataSource = typeof(ERP_Library.KyTinhLuongList);
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(530, 38);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 3;
            this.ultraButton1.Text = "Xem";
            this.ultraButton1.Click += new System.EventHandler(this.ultraButton1_Click);
            // 
            // frmTuNgayDenNgay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 128);
            this.Controls.Add(this.ultraGroupBox1);
            this.KeyPreview = true;
            this.Name = "frmTuNgayDenNgay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn Kỳ Tính Lương";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTuNgayDenNgay_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbDenKyTinhLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTuKyTinhLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbDenKyTinhLuong;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTuKyTinhLuong;
        private System.Windows.Forms.BindingSource bindingSource1_KyTinhLuong;
        private System.Windows.Forms.BindingSource bindingSource1_KyTinhLuong2;
    }
}