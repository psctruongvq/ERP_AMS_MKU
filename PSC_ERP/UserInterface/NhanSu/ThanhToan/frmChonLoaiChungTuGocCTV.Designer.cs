namespace PSC_ERP.ThanhToan
{
    partial class frmChonLoaiChungTuGocCTV
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
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonLoaiChungTuGocCTV));
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            this.label1 = new System.Windows.Forms.Label();
            this.bdData = new System.Windows.Forms.BindingSource(this.components);
            this.btnKhong = new Infragistics.Win.Misc.UltraButton();
            this.btnDongY = new Infragistics.Win.Misc.UltraButton();
            this.lstData = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chọn loại chứng từ gốc kèm theo của phiếu đề nghị";
            // 
            // bdData
            // 
            this.bdData.DataSource = typeof(ERP_Library.ThanhToan.LoaiChungTuGocList);
            // 
            // btnKhong
            // 
            appearance20.Image = ((object)(resources.GetObject("appearance20.Image")));
            this.btnKhong.Appearance = appearance20;
            this.btnKhong.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKhong.ImageSize = new System.Drawing.Size(24, 24);
            this.btnKhong.Location = new System.Drawing.Point(167, 325);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(83, 34);
            this.btnKhong.TabIndex = 3;
            this.btnKhong.Text = "Không";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnDongY
            // 
            appearance13.Image = ((object)(resources.GetObject("appearance13.Image")));
            this.btnDongY.Appearance = appearance13;
            this.btnDongY.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDongY.Location = new System.Drawing.Point(78, 325);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(83, 34);
            this.btnDongY.TabIndex = 2;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // lstData
            // 
            this.lstData.DataSource = this.bdData;
            this.lstData.DisplayMember = "TenLoai";
            this.lstData.FormattingEnabled = true;
            this.lstData.Location = new System.Drawing.Point(12, 47);
            this.lstData.Name = "lstData";
            this.lstData.Size = new System.Drawing.Size(304, 277);
            this.lstData.TabIndex = 4;
            this.lstData.ValueMember = "MaLoaiChungTu";
            this.lstData.DoubleClick += new System.EventHandler(this.lstData_DoubleClick);
            // 
            // frmChonLoaiChungTuGocCTV
            // 
            this.AcceptButton = this.btnDongY;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKhong;
            this.ClientSize = new System.Drawing.Size(328, 371);
            this.ControlBox = false;
            this.Controls.Add(this.lstData);
            this.Controls.Add(this.btnKhong);
            this.Controls.Add(this.btnDongY);
            this.Controls.Add(this.label1);
            this.Name = "frmChonLoaiChungTuGocCTV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chứng từ gốc kèm theo";
            this.Load += new System.EventHandler(this.frmChonLoaiChungTuGoc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraButton btnKhong;
        private Infragistics.Win.Misc.UltraButton btnDongY;
        private System.Windows.Forms.BindingSource bdData;
        private System.Windows.Forms.ListBox lstData;
    }
}