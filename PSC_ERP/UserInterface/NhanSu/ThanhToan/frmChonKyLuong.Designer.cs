namespace PSC_ERP.ThanhToan
{
    partial class frmChonKyLuong
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
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNganHang = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.dataSet1 = new System.Data.DataSet();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.cmbNganHang);
            this.pnlData.Controls.Add(this.lblNganHang);
            this.pnlData.Controls.Add(this.cmbKyLuong);
            this.pnlData.Controls.Add(this.label1);
            this.pnlData.Size = new System.Drawing.Size(424, 74);
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Size = new System.Drawing.Size(346, 35);
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(127, 17);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(291, 21);
            this.cmbKyLuong.TabIndex = 1;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.ValueChanged += new System.EventHandler(this.CapNhatChungTuGoc);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng lương";
            // 
            // cmbNganHang
            // 
            this.cmbNganHang.DisplayMember = "";
            this.cmbNganHang.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNganHang.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "Tiền mặt";
            this.cmbNganHang.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1});
            this.cmbNganHang.Location = new System.Drawing.Point(127, 44);
            this.cmbNganHang.Name = "cmbNganHang";
            this.cmbNganHang.Size = new System.Drawing.Size(291, 21);
            this.cmbNganHang.TabIndex = 3;
            this.cmbNganHang.ValueMember = "";
            this.cmbNganHang.ValueChanged += new System.EventHandler(this.CapNhatChungTuGoc);
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Location = new System.Drawing.Point(13, 47);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(112, 13);
            this.lblNganHang.TabIndex = 2;
            this.lblNganHang.Text = "Tiền mặt / Ngân hàng";
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            // 
            // frmChonKyLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 237);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChonKyLuong";
            this.Text = "Chọn Tháng lương";
            this.SaveXMLData += new System.ComponentModel.CancelEventHandler(this.frmChonKyLuong_SaveXMLData);
            this.CreateXMLData += new System.EventHandler(this.frmChonKyLuong_CreateXMLData);
            this.Load += new System.EventHandler(this.frmChonKyLuong_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbNganHang;
        private System.Windows.Forms.Label lblNganHang;
        private System.Data.DataSet dataSet1;
    }
}