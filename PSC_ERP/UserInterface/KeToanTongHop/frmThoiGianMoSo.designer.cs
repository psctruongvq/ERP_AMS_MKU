namespace PSC_ERP
{
    partial class frmThoiGianMoSo
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lb_ThongBao = new System.Windows.Forms.Label();
            this.lblThoiGianThucHien = new System.Windows.Forms.Label();
            this.lblThoiGian = new System.Windows.Forms.Label();
            this.lblKhaoSo = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lb_ThongBao
            // 
            this.lb_ThongBao.AutoSize = true;
            this.lb_ThongBao.Location = new System.Drawing.Point(310, 21);
            this.lb_ThongBao.Name = "lb_ThongBao";
            this.lb_ThongBao.Size = new System.Drawing.Size(0, 13);
            this.lb_ThongBao.TabIndex = 14;
            // 
            // lblThoiGianThucHien
            // 
            this.lblThoiGianThucHien.AutoSize = true;
            this.lblThoiGianThucHien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianThucHien.Location = new System.Drawing.Point(217, 95);
            this.lblThoiGianThucHien.Name = "lblThoiGianThucHien";
            this.lblThoiGianThucHien.Size = new System.Drawing.Size(0, 16);
            this.lblThoiGianThucHien.TabIndex = 13;
            // 
            // lblThoiGian
            // 
            this.lblThoiGian.AutoSize = true;
            this.lblThoiGian.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGian.Location = new System.Drawing.Point(81, 95);
            this.lblThoiGian.Name = "lblThoiGian";
            this.lblThoiGian.Size = new System.Drawing.Size(130, 16);
            this.lblThoiGian.TabIndex = 12;
            this.lblThoiGian.Text = "Thời Gian Thực Hiện";
            // 
            // lblKhaoSo
            // 
            this.lblKhaoSo.AutoSize = true;
            this.lblKhaoSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKhaoSo.Location = new System.Drawing.Point(80, 15);
            this.lblKhaoSo.Name = "lblKhaoSo";
            this.lblKhaoSo.Size = new System.Drawing.Size(214, 20);
            this.lblKhaoSo.TabIndex = 11;
            this.lblKhaoSo.Text = "Mở Sổ Kế Toán Tổng Hợp";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 52);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(329, 23);
            this.progressBar1.TabIndex = 10;
            // 
            // frmThoiGianMoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(380, 127);
            this.Controls.Add(this.lb_ThongBao);
            this.Controls.Add(this.lblThoiGianThucHien);
            this.Controls.Add(this.lblThoiGian);
            this.Controls.Add(this.lblKhaoSo);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmThoiGianMoSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thời Gian Mở Sổ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lb_ThongBao;
        private System.Windows.Forms.Label lblThoiGianThucHien;
        private System.Windows.Forms.Label lblThoiGian;
        private System.Windows.Forms.Label lblKhaoSo;
        private System.Windows.Forms.ProgressBar progressBar1;

        
    }
}