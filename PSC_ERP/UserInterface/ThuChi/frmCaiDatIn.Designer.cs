namespace PSC_ERP
{
    partial class frmCaiDatIn
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.txtTenThuQuy = new System.Windows.Forms.TextBox();
            this.CaiDatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtNhanThuQuy = new System.Windows.Forms.TextBox();
            this.txtTenNguoiLap = new System.Windows.Forms.TextBox();
            this.txtNhanNguoiLap = new System.Windows.Forms.TextBox();
            this.txtTenKeToanTruong = new System.Windows.Forms.TextBox();
            this.txtNhanKeToanTruong = new System.Windows.Forms.TextBox();
            this.txtTenThuTruong = new System.Windows.Forms.TextBox();
            this.txtNhanThuTruong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaiDatBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.txtTenThuQuy);
            this.groupBox1.Controls.Add(this.txtNhanThuQuy);
            this.groupBox1.Controls.Add(this.txtTenNguoiLap);
            this.groupBox1.Controls.Add(this.txtNhanNguoiLap);
            this.groupBox1.Controls.Add(this.txtTenKeToanTruong);
            this.groupBox1.Controls.Add(this.txtNhanKeToanTruong);
            this.groupBox1.Controls.Add(this.txtTenThuTruong);
            this.groupBox1.Controls.Add(this.txtNhanThuTruong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 260);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin cài đặt";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(255, 185);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // txtTenThuQuy
            // 
            this.txtTenThuQuy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CaiDatBindingSource, "TenThuQuy", true));
            this.txtTenThuQuy.Location = new System.Drawing.Point(331, 117);
            this.txtTenThuQuy.Name = "txtTenThuQuy";
            this.txtTenThuQuy.Size = new System.Drawing.Size(153, 20);
            this.txtTenThuQuy.TabIndex = 5;
            // 
            // CaiDatBindingSource
            // 
            this.CaiDatBindingSource.DataSource = typeof(ERP_Library.CaiDatKyTen);
            // 
            // txtNhanThuQuy
            // 
            this.txtNhanThuQuy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CaiDatBindingSource, "NhanThuQuy", true));
            this.txtNhanThuQuy.Location = new System.Drawing.Point(134, 117);
            this.txtNhanThuQuy.Name = "txtNhanThuQuy";
            this.txtNhanThuQuy.Size = new System.Drawing.Size(163, 20);
            this.txtNhanThuQuy.TabIndex = 4;
            // 
            // txtTenNguoiLap
            // 
            this.txtTenNguoiLap.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CaiDatBindingSource, "TenNguoiLap", true));
            this.txtTenNguoiLap.Enabled = false;
            this.txtTenNguoiLap.Location = new System.Drawing.Point(331, 143);
            this.txtTenNguoiLap.Name = "txtTenNguoiLap";
            this.txtTenNguoiLap.Size = new System.Drawing.Size(153, 20);
            this.txtTenNguoiLap.TabIndex = 8;
            // 
            // txtNhanNguoiLap
            // 
            this.txtNhanNguoiLap.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CaiDatBindingSource, "NhanNguoiLap", true));
            this.txtNhanNguoiLap.Location = new System.Drawing.Point(134, 143);
            this.txtNhanNguoiLap.Name = "txtNhanNguoiLap";
            this.txtNhanNguoiLap.Size = new System.Drawing.Size(163, 20);
            this.txtNhanNguoiLap.TabIndex = 6;
            // 
            // txtTenKeToanTruong
            // 
            this.txtTenKeToanTruong.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CaiDatBindingSource, "TenKTTTruong", true));
            this.txtTenKeToanTruong.Location = new System.Drawing.Point(331, 91);
            this.txtTenKeToanTruong.Name = "txtTenKeToanTruong";
            this.txtTenKeToanTruong.Size = new System.Drawing.Size(153, 20);
            this.txtTenKeToanTruong.TabIndex = 3;
            // 
            // txtNhanKeToanTruong
            // 
            this.txtNhanKeToanTruong.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CaiDatBindingSource, "NhanKTTruong", true));
            this.txtNhanKeToanTruong.Location = new System.Drawing.Point(134, 91);
            this.txtNhanKeToanTruong.Name = "txtNhanKeToanTruong";
            this.txtNhanKeToanTruong.Size = new System.Drawing.Size(163, 20);
            this.txtNhanKeToanTruong.TabIndex = 2;
            // 
            // txtTenThuTruong
            // 
            this.txtTenThuTruong.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CaiDatBindingSource, "TenThuTruong", true));
            this.txtTenThuTruong.Location = new System.Drawing.Point(331, 65);
            this.txtTenThuTruong.Name = "txtTenThuTruong";
            this.txtTenThuTruong.Size = new System.Drawing.Size(153, 20);
            this.txtTenThuTruong.TabIndex = 1;
            // 
            // txtNhanThuTruong
            // 
            this.txtNhanThuTruong.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.CaiDatBindingSource, "NhanThuTruong", true));
            this.txtNhanThuTruong.Location = new System.Drawing.Point(134, 65);
            this.txtNhanThuTruong.Name = "txtNhanThuTruong";
            this.txtNhanThuTruong.Size = new System.Drawing.Size(163, 20);
            this.txtNhanThuTruong.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ký tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhãn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Thủ trưởng đơn vị";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Kế toán trưởng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Thủ quỹ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Người lập";
            // 
            // frmCaiDatIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 275);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCaiDatIn";
            this.Text = "Cài đặt in phiếu";
            this.Load += new System.EventHandler(this.frmCaiDatIn_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaiDatBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenThuQuy;
        private System.Windows.Forms.TextBox txtNhanThuQuy;
        private System.Windows.Forms.TextBox txtTenNguoiLap;
        private System.Windows.Forms.TextBox txtNhanNguoiLap;
        private System.Windows.Forms.TextBox txtTenKeToanTruong;
        private System.Windows.Forms.TextBox txtNhanKeToanTruong;
        private System.Windows.Forms.TextBox txtTenThuTruong;
        private System.Windows.Forms.TextBox txtNhanThuTruong;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.BindingSource CaiDatBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}