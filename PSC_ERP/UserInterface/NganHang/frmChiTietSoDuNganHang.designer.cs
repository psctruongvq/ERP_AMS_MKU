namespace PSC_ERP.UserInterface.NganHang
{
    partial class frmChiTietSoDuNganHang
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
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhomNganHang", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhomNganHang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNhomNganHang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaUNCNganHang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChuVietTat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("SoUNCBatDau");
            this.txtDenNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTuNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Loai = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.cmbu_NhomNganHang = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.label4 = new System.Windows.Forms.Label();
            this.nhomNganHangListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Loai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_NhomNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhomNganHangListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtDenNgay.Location = new System.Drawing.Point(285, 33);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Size = new System.Drawing.Size(113, 21);
            this.txtDenNgay.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Từ ngày";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTuNgay.Location = new System.Drawing.Point(108, 33);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Size = new System.Drawing.Size(113, 21);
            this.txtTuNgay.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "đến ngày";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(158, 89);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(90, 30);
            this.btnXem.TabIndex = 14;
            this.btnXem.Text = "X&em";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Loại";
            // 
            // cmb_Loai
            // 
            this.cmb_Loai.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            valueListItem1.DataValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            valueListItem1.DisplayText = "Theo ngày xác nhận";
            valueListItem2.DataValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            valueListItem2.DisplayText = "Theo ngày lập chứng từ";
            valueListItem3.DataValue = new decimal(new int[] {
            2,
            0,
            0,
            0});
            valueListItem3.DisplayText = "Theo ngày lập trừ ngày xác nhận";
            this.cmb_Loai.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3});
            this.cmb_Loai.Location = new System.Drawing.Point(108, 5);
            this.cmb_Loai.Name = "cmb_Loai";
            this.cmb_Loai.Size = new System.Drawing.Size(290, 21);
            this.cmb_Loai.TabIndex = 16;
            // 
            // cmbu_NhomNganHang
            // 
            this.cmbu_NhomNganHang.DataSource = this.nhomNganHangListBindingSource;
            ultraGridColumn11.Header.VisiblePosition = 0;
            ultraGridColumn11.Hidden = true;
            ultraGridColumn12.Header.Caption = "Tên nhóm ngân hàng";
            ultraGridColumn12.Header.VisiblePosition = 1;
            ultraGridColumn13.Header.VisiblePosition = 2;
            ultraGridColumn13.Hidden = true;
            ultraGridColumn14.Header.Caption = "Chữ viết tắt";
            ultraGridColumn14.Header.VisiblePosition = 3;
            ultraGridColumn15.Header.VisiblePosition = 4;
            ultraGridColumn15.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15});
            this.cmbu_NhomNganHang.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbu_NhomNganHang.DisplayMember = "TenNhomNganHang";
            this.cmbu_NhomNganHang.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbu_NhomNganHang.Location = new System.Drawing.Point(108, 61);
            this.cmbu_NhomNganHang.Name = "cmbu_NhomNganHang";
            this.cmbu_NhomNganHang.Size = new System.Drawing.Size(290, 22);
            this.cmbu_NhomNganHang.TabIndex = 17;
            this.cmbu_NhomNganHang.ValueMember = "MaNhomNganHang";
            this.cmbu_NhomNganHang.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cmbu_NhomNganHang_InitializeLayout);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Nhóm ngân hàng";
            // 
            // nhomNganHangListBindingSource
            // 
            this.nhomNganHangListBindingSource.DataSource = typeof(ERP_Library.NhomNganHangList);
            // 
            // frmChiTietSoDuNganHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 122);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbu_NhomNganHang);
            this.Controls.Add(this.cmb_Loai);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.txtDenNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTuNgay);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChiTietSoDuNganHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết số dư ngân hàng";
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Loai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbu_NhomNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhomNganHangListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDenNgay;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtTuNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label3;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmb_Loai;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbu_NhomNganHang;
        private System.Windows.Forms.BindingSource nhomNganHangListBindingSource;
        private System.Windows.Forms.Label label4;
    }
}