namespace PSC_ERP.ThanhToan
{
    partial class frmChonPhuCap
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            this.cmbNganHang = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNhomPC = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblNhomPC = new System.Windows.Forms.Label();
            this.cmbPhuCap = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblPhuCap = new System.Windows.Forms.Label();
            this.cmbKyPC = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhomPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyPC)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.cmbKyPC);
            this.pnlData.Controls.Add(this.label4);
            this.pnlData.Controls.Add(this.cmbNhomPC);
            this.pnlData.Controls.Add(this.lblNhomPC);
            this.pnlData.Controls.Add(this.cmbPhuCap);
            this.pnlData.Controls.Add(this.lblPhuCap);
            this.pnlData.Controls.Add(this.cmbNganHang);
            this.pnlData.Controls.Add(this.lblNganHang);
            this.pnlData.Controls.Add(this.cmbKyLuong);
            this.pnlData.Controls.Add(this.label1);
            this.pnlData.Size = new System.Drawing.Size(394, 136);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Enabled = false;
            this.txtSoTien.Size = new System.Drawing.Size(131, 21);
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(72, 18);
            this.txtDienGiai.Size = new System.Drawing.Size(316, 37);
            // 
            // cmbNganHang
            // 
            this.cmbNganHang.DisplayMember = "";
            this.cmbNganHang.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNganHang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbNganHang.Enabled = false;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Tiền mặt";
            this.cmbNganHang.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1});
            this.cmbNganHang.Location = new System.Drawing.Point(131, 108);
            this.cmbNganHang.Name = "cmbNganHang";
            this.cmbNganHang.Size = new System.Drawing.Size(257, 21);
            this.cmbNganHang.TabIndex = 9;
            this.cmbNganHang.ValueMember = "";
            this.cmbNganHang.ValueChanged += new System.EventHandler(this.cmbNganHang_ValueChanged);
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Location = new System.Drawing.Point(13, 110);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(112, 13);
            this.lblNganHang.TabIndex = 8;
            this.lblNganHang.Text = "Tiền mặt / Ngân hàng";
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(131, 7);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(257, 21);
            this.cmbKyLuong.TabIndex = 1;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.ValueChanged += new System.EventHandler(this.cmbKyLuong_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng lương";
            // 
            // cmbNhomPC
            // 
            appearance1.BackColor = System.Drawing.SystemColors.Info;
            this.cmbNhomPC.Appearance = appearance1;
            this.cmbNhomPC.BackColor = System.Drawing.SystemColors.Info;
            this.cmbNhomPC.DisplayMember = "Ten";
            this.cmbNhomPC.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNhomPC.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbNhomPC.Location = new System.Drawing.Point(131, 58);
            this.cmbNhomPC.Name = "cmbNhomPC";
            this.cmbNhomPC.Size = new System.Drawing.Size(257, 21);
            this.cmbNhomPC.TabIndex = 5;
            this.cmbNhomPC.ValueMember = "MaNhom";
            this.cmbNhomPC.ValueChanged += new System.EventHandler(this.cmbNhomPC_ValueChanged);
            // 
            // lblNhomPC
            // 
            this.lblNhomPC.AutoSize = true;
            this.lblNhomPC.Location = new System.Drawing.Point(13, 60);
            this.lblNhomPC.Name = "lblNhomPC";
            this.lblNhomPC.Size = new System.Drawing.Size(77, 13);
            this.lblNhomPC.TabIndex = 4;
            this.lblNhomPC.Text = "Nhóm phụ cấp";
            // 
            // cmbPhuCap
            // 
            appearance3.BackColor = System.Drawing.SystemColors.Info;
            this.cmbPhuCap.Appearance = appearance3;
            this.cmbPhuCap.BackColor = System.Drawing.SystemColors.Info;
            this.cmbPhuCap.DisplayMember = "TenLoaiPhuCap";
            this.cmbPhuCap.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbPhuCap.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbPhuCap.Location = new System.Drawing.Point(131, 83);
            this.cmbPhuCap.Name = "cmbPhuCap";
            this.cmbPhuCap.Size = new System.Drawing.Size(257, 21);
            this.cmbPhuCap.TabIndex = 7;
            this.cmbPhuCap.ValueMember = "MaLoaiPhuCap";
            this.cmbPhuCap.ValueChanged += new System.EventHandler(this.cmbPhuCap_ValueChanged);
            // 
            // lblPhuCap
            // 
            this.lblPhuCap.AutoSize = true;
            this.lblPhuCap.Location = new System.Drawing.Point(13, 85);
            this.lblPhuCap.Name = "lblPhuCap";
            this.lblPhuCap.Size = new System.Drawing.Size(47, 13);
            this.lblPhuCap.TabIndex = 6;
            this.lblPhuCap.Text = "Phụ cấp";
            // 
            // cmbKyPC
            // 
            this.cmbKyPC.DisplayMember = "";
            this.cmbKyPC.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyPC.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyPC.Location = new System.Drawing.Point(131, 32);
            this.cmbKyPC.Name = "cmbKyPC";
            this.cmbKyPC.Size = new System.Drawing.Size(257, 21);
            this.cmbKyPC.TabIndex = 3;
            this.cmbKyPC.ValueMember = "";
            this.cmbKyPC.ValueChanged += new System.EventHandler(this.cmbKyPC_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kỳ phụ cấp";
            // 
            // frmChonPhuCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 299);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChonPhuCap";
            this.Text = "Chọn phụ cấp";
            this.SaveXMLData += new System.ComponentModel.CancelEventHandler(this.frmChonPhuCap_SaveXMLData);
            this.CreateXMLData += new System.EventHandler(this.frmChonPhuCap_CreateXMLData);
            this.Load += new System.EventHandler(this.frmChonPhuCap_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhomPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyPC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbNganHang;
        private System.Windows.Forms.Label lblNganHang;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbNhomPC;
        private System.Windows.Forms.Label lblNhomPC;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbPhuCap;
        private System.Windows.Forms.Label lblPhuCap;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyPC;
        private System.Windows.Forms.Label label4;
    }
}