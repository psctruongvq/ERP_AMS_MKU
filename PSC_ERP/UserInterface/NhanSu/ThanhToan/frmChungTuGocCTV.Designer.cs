namespace PSC_ERP.ThanhToan
{
    partial class frmChungTuGocCTV

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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChungTuGocCTV));
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            this.btnKhong = new Infragistics.Win.Misc.UltraButton();
            this.btnDongY = new Infragistics.Win.Misc.UltraButton();
            this.grpChungTu = new System.Windows.Forms.GroupBox();
            this.txtSoTien = new Infragistics.Win.UltraWinEditors.UltraNumericEditor();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDienGiai = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblErr = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.grpChungTu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKhong
            // 
            this.btnKhong.Anchor = System.Windows.Forms.AnchorStyles.None;
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            this.btnKhong.Appearance = appearance1;
            this.btnKhong.ImageSize = new System.Drawing.Size(24, 24);
            this.btnKhong.Location = new System.Drawing.Point(228, 20);
            this.btnKhong.Name = "btnKhong";
            this.btnKhong.Size = new System.Drawing.Size(83, 34);
            this.btnKhong.TabIndex = 1;
            this.btnKhong.Text = "Không";
            this.btnKhong.Click += new System.EventHandler(this.btnKhong_Click);
            // 
            // btnDongY
            // 
            this.btnDongY.Anchor = System.Windows.Forms.AnchorStyles.None;
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            this.btnDongY.Appearance = appearance2;
            this.btnDongY.ImageSize = new System.Drawing.Size(24, 24);
            this.btnDongY.Location = new System.Drawing.Point(139, 20);
            this.btnDongY.Name = "btnDongY";
            this.btnDongY.Size = new System.Drawing.Size(83, 34);
            this.btnDongY.TabIndex = 0;
            this.btnDongY.Text = "Đồng ý";
            this.btnDongY.Click += new System.EventHandler(this.btnDongY_Click);
            // 
            // grpChungTu
            // 
            this.grpChungTu.Controls.Add(this.txtSoTien);
            this.grpChungTu.Controls.Add(this.label3);
            this.grpChungTu.Controls.Add(this.txtDienGiai);
            this.grpChungTu.Controls.Add(this.label2);
            this.grpChungTu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpChungTu.Location = new System.Drawing.Point(5, 20);
            this.grpChungTu.Name = "grpChungTu";
            this.grpChungTu.Size = new System.Drawing.Size(438, 87);
            this.grpChungTu.TabIndex = 1;
            this.grpChungTu.TabStop = false;
            this.grpChungTu.Text = "Chứng gốc kèm theo phiếu đề nghị";
            // 
            // txtSoTien
            // 
            this.txtSoTien.FormatString = "#,###";
            this.txtSoTien.Location = new System.Drawing.Point(77, 52);
            this.txtSoTien.MaskInput = "nnnnnnnnnnnn";
            this.txtSoTien.MaxValue = ((long)(999999999999));
            this.txtSoTien.MinValue = ((long)(-999999999999));
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.NumericType = Infragistics.Win.UltraWinEditors.NumericType.Double;
            this.txtSoTien.Size = new System.Drawing.Size(120, 21);
            this.txtSoTien.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số tiền";
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDienGiai.Location = new System.Drawing.Point(77, 25);
            this.txtDienGiai.Name = "txtDienGiai";
            this.txtDienGiai.Size = new System.Drawing.Size(341, 21);
            this.txtDienGiai.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Diễn giải";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.lblErr);
            this.pnlBottom.Controls.Add(this.btnKhong);
            this.pnlBottom.Controls.Add(this.btnDongY);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(5, 107);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(438, 56);
            this.pnlBottom.TabIndex = 2;
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(13, 3);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(334, 13);
            this.lblErr.TabIndex = 2;
            this.lblErr.Text = "Danh sách nhân viên kèm theo đã được lập nên không thể cập nhật";
            // 
            // pnlData
            // 
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(5, 5);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(438, 15);
            this.pnlData.TabIndex = 0;
            // 
            // frmChungTuGocCTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 168);
            this.ControlBox = false;
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.grpChungTu);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmChungTuGocCTV";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chứng từ gốc";
            this.grpChungTu.ResumeLayout(false);
            this.grpChungTu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton btnKhong;
        private Infragistics.Win.Misc.UltraButton btnDongY;
        private System.Windows.Forms.GroupBox grpChungTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlBottom;
        protected System.Windows.Forms.Panel pnlData;
        protected Infragistics.Win.UltraWinEditors.UltraNumericEditor txtSoTien;
        protected Infragistics.Win.UltraWinEditors.UltraTextEditor txtDienGiai;
        private System.Windows.Forms.Label lblErr;
    }
}