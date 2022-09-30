namespace PSC_ERP.UserInterface.NhanSu.ChamCong
{
    partial class frmInBangCong_DV
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
            this.btn_Xem = new System.Windows.Forms.Button();
            this.txtThang = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Xem
            // 
            this.btn_Xem.Location = new System.Drawing.Point(164, 10);
            this.btn_Xem.Name = "btn_Xem";
            this.btn_Xem.Size = new System.Drawing.Size(90, 25);
            this.btn_Xem.TabIndex = 14;
            this.btn_Xem.Text = "In Bảng Công";
            this.btn_Xem.UseVisualStyleBackColor = true;
            this.btn_Xem.Click += new System.EventHandler(this.btn_Xem_Click);
            // 
            // txtThang
            // 
            this.txtThang.CustomFormat = "MM/yyyy";
            this.txtThang.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtThang.Location = new System.Drawing.Point(74, 12);
            this.txtThang.Name = "txtThang";
            this.txtThang.ShowUpDown = true;
            this.txtThang.Size = new System.Drawing.Size(84, 20);
            this.txtThang.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tháng";
            // 
            // frmInBangCong_DV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 45);
            this.Controls.Add(this.btn_Xem);
            this.Controls.Add(this.txtThang);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInBangCong_DV";
            this.Text = "Bảng Chấm Công Đơn Vị";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Xem;
        private System.Windows.Forms.DateTimePicker txtThang;
        private System.Windows.Forms.Label label1;
    }
}