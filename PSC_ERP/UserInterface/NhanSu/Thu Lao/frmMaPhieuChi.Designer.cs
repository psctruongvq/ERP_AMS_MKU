namespace PSC_ERP.UserInterface.NhanSu.Thu_Lao
{
    partial class frmMaPhieuChi
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKyTinhLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.bindingSource1_KyTinhLuong = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_NgayLap = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.cbKyTinhLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 95);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã Phiếu Chi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Kỳ Tính Lương";
            // 
            // cbKyTinhLuong
            // 
            appearance8.FontData.BoldAsString = "False";
            this.cbKyTinhLuong.Appearance = appearance8;
            this.cbKyTinhLuong.DataSource = this.bindingSource1_KyTinhLuong;
            this.cbKyTinhLuong.DisplayMember = "TenKy";
            this.cbKyTinhLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbKyTinhLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cbKyTinhLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKyTinhLuong.Location = new System.Drawing.Point(96, 21);
            this.cbKyTinhLuong.Name = "cbKyTinhLuong";
            this.cbKyTinhLuong.Size = new System.Drawing.Size(285, 21);
            this.cbKyTinhLuong.TabIndex = 67;
            this.cbKyTinhLuong.ValueMember = "MaKy";
            // 
            // bindingSource1_KyTinhLuong
            // 
            this.bindingSource1_KyTinhLuong.DataSource = typeof(ERP_Library.KyTinhLuongList);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(219, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Ngày Lập";
            // 
            // dateTimePicker_NgayLap
            // 
            this.dateTimePicker_NgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateTimePicker_NgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_NgayLap.Location = new System.Drawing.Point(278, 52);
            this.dateTimePicker_NgayLap.Name = "dateTimePicker_NgayLap";
            this.dateTimePicker_NgayLap.Size = new System.Drawing.Size(103, 20);
            this.dateTimePicker_NgayLap.TabIndex = 80;
            // 
            // frmMaPhieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 130);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker_NgayLap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbKyTinhLuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmMaPhieuChi";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhập Phiếu Chi";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMaPhieuChi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.cbKyTinhLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1_KyTinhLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbKyTinhLuong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_NgayLap;
        private System.Windows.Forms.BindingSource bindingSource1_KyTinhLuong;
    }
}