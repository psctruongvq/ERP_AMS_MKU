namespace PSC_ERP
{
    partial class frmDinhDangFile_DuLieuTho
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDinhDangFile_DuLieuTho));
            this.label1 = new System.Windows.Forms.Label();
            this.frt_Ngay = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.frt_Gio = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.frt_CardID = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_KetQua = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_CardIdFormat = new System.Windows.Forms.TextBox();
            this.txt_GioFormat = new System.Windows.Forms.TextBox();
            this.txt_NgayFormat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cột Ngày:";
            // 
            // frt_Ngay
            // 
            this.frt_Ngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frt_Ngay.Location = new System.Drawing.Point(87, 24);
            this.frt_Ngay.Mask = "00";
            this.frt_Ngay.Name = "frt_Ngay";
            this.frt_Ngay.Size = new System.Drawing.Size(34, 21);
            this.frt_Ngay.TabIndex = 1;
            this.frt_Ngay.Text = "2";
            this.frt_Ngay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.frt_Ngay.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.frt_Ngay_MaskInputRejected);
            this.frt_Ngay.TextChanged += new System.EventHandler(this.frt_Ngay_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cột Giờ:";
            // 
            // frt_Gio
            // 
            this.frt_Gio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frt_Gio.Location = new System.Drawing.Point(87, 49);
            this.frt_Gio.Mask = "00";
            this.frt_Gio.Name = "frt_Gio";
            this.frt_Gio.Size = new System.Drawing.Size(34, 21);
            this.frt_Gio.TabIndex = 2;
            this.frt_Gio.Text = "3";
            this.frt_Gio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.frt_Gio.TextChanged += new System.EventHandler(this.frt_Gio_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cột CardID:";
            // 
            // frt_CardID
            // 
            this.frt_CardID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frt_CardID.Location = new System.Drawing.Point(87, 77);
            this.frt_CardID.Mask = "00";
            this.frt_CardID.Name = "frt_CardID";
            this.frt_CardID.Size = new System.Drawing.Size(34, 21);
            this.frt_CardID.TabIndex = 3;
            this.frt_CardID.Text = "4";
            this.frt_CardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.frt_CardID.TextChanged += new System.EventHandler(this.frt_CardID_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.frt_CardID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.frt_Gio);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.frt_Ngay);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Định vị trí:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_KetQua);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(17, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(362, 57);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả:";
            // 
            // txt_KetQua
            // 
            this.txt_KetQua.Enabled = false;
            this.txt_KetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_KetQua.Location = new System.Drawing.Point(11, 21);
            this.txt_KetQua.Name = "txt_KetQua";
            this.txt_KetQua.Size = new System.Drawing.Size(337, 22);
            this.txt_KetQua.TabIndex = 0;
            this.txt_KetQua.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_CardIdFormat);
            this.groupBox3.Controls.Add(this.txt_GioFormat);
            this.groupBox3.Controls.Add(this.txt_NgayFormat);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(167, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 112);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Định dạng:";
            // 
            // txt_CardIdFormat
            // 
            this.txt_CardIdFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CardIdFormat.Location = new System.Drawing.Point(79, 75);
            this.txt_CardIdFormat.Name = "txt_CardIdFormat";
            this.txt_CardIdFormat.Size = new System.Drawing.Size(121, 21);
            this.txt_CardIdFormat.TabIndex = 3;
            this.txt_CardIdFormat.Text = "\'";
            this.txt_CardIdFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_CardIdFormat.TextChanged += new System.EventHandler(this.txt_CardIdFormat_TextChanged);
            // 
            // txt_GioFormat
            // 
            this.txt_GioFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_GioFormat.Location = new System.Drawing.Point(79, 49);
            this.txt_GioFormat.Name = "txt_GioFormat";
            this.txt_GioFormat.Size = new System.Drawing.Size(121, 21);
            this.txt_GioFormat.TabIndex = 2;
            this.txt_GioFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_GioFormat.TextChanged += new System.EventHandler(this.txt_GioFormat_TextChanged);
            // 
            // txt_NgayFormat
            // 
            this.txt_NgayFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NgayFormat.Location = new System.Drawing.Point(79, 24);
            this.txt_NgayFormat.Name = "txt_NgayFormat";
            this.txt_NgayFormat.Size = new System.Drawing.Size(121, 21);
            this.txt_NgayFormat.TabIndex = 1;
            this.txt_NgayFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_NgayFormat.TextChanged += new System.EventHandler(this.txt_NgayFormat_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cột Ngày:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cột Giờ:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Cột CardID:";
            // 
            // frmDinhDangFile_DuLieuTho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 201);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDinhDangFile_DuLieuTho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Định Dạng File Dữ Liệu Thô";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox frt_Ngay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox frt_Gio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox frt_CardID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_KetQua;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_CardIdFormat;
        private System.Windows.Forms.TextBox txt_GioFormat;
        private System.Windows.Forms.TextBox txt_NgayFormat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}