namespace PSC_ERP
{
    partial class frmDuLieuTho_ChamCong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDuLieuTho_ChamCong));
            this.btnChonFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TenFile = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnDocDuLieu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DinhDang = new System.Windows.Forms.TextBox();
            this.btn_DoiDinhDang = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnChonFile
            // 
            this.btnChonFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonFile.Location = new System.Drawing.Point(316, 43);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 23);
            this.btnChonFile.TabIndex = 1;
            this.btnChonFile.Text = "Chọn File!";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File từ máy chấm công";
            // 
            // txt_TenFile
            // 
            this.txt_TenFile.Enabled = false;
            this.txt_TenFile.Location = new System.Drawing.Point(29, 44);
            this.txt_TenFile.Name = "txt_TenFile";
            this.txt_TenFile.ReadOnly = true;
            this.txt_TenFile.Size = new System.Drawing.Size(277, 20);
            this.txt_TenFile.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnDocDuLieu
            // 
            this.btnDocDuLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocDuLieu.Location = new System.Drawing.Point(142, 125);
            this.btnDocDuLieu.Name = "btnDocDuLieu";
            this.btnDocDuLieu.Size = new System.Drawing.Size(108, 27);
            this.btnDocDuLieu.TabIndex = 4;
            this.btnDocDuLieu.Text = "Đọc Dữ Liệu!";
            this.btnDocDuLieu.UseVisualStyleBackColor = true;
            this.btnDocDuLieu.Click += new System.EventHandler(this.btnDocDuLieu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Định dạng File";
            // 
            // txt_DinhDang
            // 
            this.txt_DinhDang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DinhDang.Location = new System.Drawing.Point(29, 91);
            this.txt_DinhDang.Name = "txt_DinhDang";
            this.txt_DinhDang.Size = new System.Drawing.Size(277, 20);
            this.txt_DinhDang.TabIndex = 2;
            this.txt_DinhDang.Text = "2@3@4@dd-MM-yyyy@HH:mm:ss@\'@";
            this.txt_DinhDang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_DoiDinhDang
            // 
            this.btn_DoiDinhDang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DoiDinhDang.Location = new System.Drawing.Point(316, 90);
            this.btn_DoiDinhDang.Name = "btn_DoiDinhDang";
            this.btn_DoiDinhDang.Size = new System.Drawing.Size(75, 23);
            this.btn_DoiDinhDang.TabIndex = 3;
            this.btn_DoiDinhDang.Text = "Đổi";
            this.btn_DoiDinhDang.UseVisualStyleBackColor = true;
            this.btn_DoiDinhDang.Click += new System.EventHandler(this.btn_DoiDinhDang_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_DoiDinhDang);
            this.groupBox1.Controls.Add(this.txt_DinhDang);
            this.groupBox1.Controls.Add(this.btnChonFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnDocDuLieu);
            this.groupBox1.Controls.Add(this.txt_TenFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 166);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Import";
            // 
            // frmDuLieuTho_ChamCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 179);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDuLieuTho_ChamCong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Import Dữ Liệu Thô";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TenFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnDocDuLieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_DinhDang;
        private System.Windows.Forms.Button btn_DoiDinhDang;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}