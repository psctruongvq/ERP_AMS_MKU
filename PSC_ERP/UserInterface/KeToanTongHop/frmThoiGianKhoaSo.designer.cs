namespace PSC_ERP
{
    partial class frmThoiGianKhoaSo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThoiGianKhoaSo));
            this.lblThang = new System.Windows.Forms.Label();
            this.lblDangKhoaSo = new System.Windows.Forms.Label();
            this.lblThoiGianThucHien = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.lblKhaoSo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThang.Location = new System.Drawing.Point(238, 47);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(45, 16);
            this.lblThang.TabIndex = 5;
            this.lblThang.Text = "label1";
            // 
            // lblDangKhoaSo
            // 
            this.lblDangKhoaSo.AutoSize = true;
            this.lblDangKhoaSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDangKhoaSo.Location = new System.Drawing.Point(75, 47);
            this.lblDangKhoaSo.Name = "lblDangKhoaSo";
            this.lblDangKhoaSo.Size = new System.Drawing.Size(157, 16);
            this.lblDangKhoaSo.TabIndex = 8;
            this.lblDangKhoaSo.Text = "Đang Khóa Hồ Sơ Tháng";
            // 
            // lblThoiGianThucHien
            // 
            this.lblThoiGianThucHien.AutoSize = true;
            this.lblThoiGianThucHien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianThucHien.Location = new System.Drawing.Point(211, 120);
            this.lblThoiGianThucHien.Name = "lblThoiGianThucHien";
            this.lblThoiGianThucHien.Size = new System.Drawing.Size(0, 16);
            this.lblThoiGianThucHien.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGian.Location = new System.Drawing.Point(75, 120);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(130, 16);
            this.lblThoiGian.TabIndex = 6;
            this.lblThoiGian.Text = "Thời Gian Thực Hiện";
            // 
            // lblKhaoSo
            // 
            this.lblKhaoSo.AutoSize = true;
            this.lblKhaoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhaoSo.Location = new System.Drawing.Point(81, 16);
            this.lblKhaoSo.Name = "lblKhaoSo";
            this.lblKhaoSo.Size = new System.Drawing.Size(231, 20);
            this.lblKhaoSo.TabIndex = 4;
            this.lblKhaoSo.Text = "Khóa Sổ Kế Toán Tổng Hợp";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(30, 78);
            this.progressBar1.Maximum = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(329, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            // 
            // frmThoiGianKhoaSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(388, 153);
            this.Controls.Add(this.lblThang);
            this.Controls.Add(this.lblDangKhoaSo);
            this.Controls.Add(this.lblThoiGianThucHien);
            this.Controls.Add(this.lblThoiGian);
            this.Controls.Add(this.lblKhaoSo);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmThoiGianKhoaSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thời Gian Khóa Sổ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.Label lblDangKhoaSo;
        private System.Windows.Forms.Label lblThoiGianThucHien;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label lblKhaoSo;
        private System.Windows.Forms.ProgressBar progressBar1;

        

    }
}