namespace PSC_ERP.ThanhToan
{
    partial class frmChonThuLao
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
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ChuongTrinh", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChuongTrinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaChuongTrinhCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaPhanCap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQL");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChuongTrinh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgaySanXuat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKetThuc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNguoiLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn9 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn10 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChuongTrinhCha");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn11 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNguon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn12 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNguon");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn13 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("HoanTat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn14 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("DungChung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn15 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaCongTy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("PhanTramThueTNCN");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            this.cmbNganHang = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.lblNganHang = new System.Windows.Forms.Label();
            this.cmbKyLuong = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTuNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.txtDenNgay = new Infragistics.Win.UltraWinEditors.UltraDateTimeEditor();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbChuongTrinh = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.bdChuongTrinh = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChuongTrinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChuongTrinh)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.cmbChuongTrinh);
            this.pnlData.Controls.Add(this.label6);
            this.pnlData.Controls.Add(this.txtDenNgay);
            this.pnlData.Controls.Add(this.label5);
            this.pnlData.Controls.Add(this.txtTuNgay);
            this.pnlData.Controls.Add(this.label4);
            this.pnlData.Controls.Add(this.cmbNganHang);
            this.pnlData.Controls.Add(this.cmbKyLuong);
            this.pnlData.Controls.Add(this.lblNganHang);
            this.pnlData.Controls.Add(this.label1);
            this.pnlData.Size = new System.Drawing.Size(424, 117);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Enabled = false;
            this.txtSoTien.Location = new System.Drawing.Point(78, 60);
            this.txtSoTien.Size = new System.Drawing.Size(131, 21);
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Location = new System.Drawing.Point(78, 19);
            this.txtDienGiai.Size = new System.Drawing.Size(337, 36);
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
            this.cmbNganHang.Location = new System.Drawing.Point(135, 91);
            this.cmbNganHang.Name = "cmbNganHang";
            this.cmbNganHang.Size = new System.Drawing.Size(244, 21);
            this.cmbNganHang.TabIndex = 9;
            this.cmbNganHang.ValueMember = "";
            this.cmbNganHang.ValueChanged += new System.EventHandler(this.cmbNganHang_ValueChanged);
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Location = new System.Drawing.Point(22, 94);
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
            this.cmbKyLuong.Location = new System.Drawing.Point(98, 15);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(281, 21);
            this.cmbKyLuong.TabIndex = 1;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.ValueChanged += new System.EventHandler(this.cmbKyLuong_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tháng lương";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Từ ngày";
            // 
            // txtTuNgay
            // 
            this.txtTuNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtTuNgay.Location = new System.Drawing.Point(98, 40);
            this.txtTuNgay.Name = "txtTuNgay";
            this.txtTuNgay.Nullable = false;
            this.txtTuNgay.Size = new System.Drawing.Size(99, 21);
            this.txtTuNgay.TabIndex = 3;
            this.txtTuNgay.ValueChanged += new System.EventHandler(this.txtTuNgay_ValueChanged);
            this.txtTuNgay.Validating += new System.ComponentModel.CancelEventHandler(this.txtTuNgay_Validating);
            // 
            // txtDenNgay
            // 
            this.txtDenNgay.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.txtDenNgay.Location = new System.Drawing.Point(280, 40);
            this.txtDenNgay.Name = "txtDenNgay";
            this.txtDenNgay.Nullable = false;
            this.txtDenNgay.Size = new System.Drawing.Size(99, 21);
            this.txtDenNgay.TabIndex = 5;
            this.txtDenNgay.ValueChanged += new System.EventHandler(this.txtDenNgay_ValueChanged);
            this.txtDenNgay.Validating += new System.ComponentModel.CancelEventHandler(this.txtDenNgay_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(221, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Đến ngày";
            // 
            // cmbChuongTrinh
            // 
            this.cmbChuongTrinh.CheckedListSettings.CheckStateMember = "";
            this.cmbChuongTrinh.DataSource = this.bdChuongTrinh;
            appearance5.BackColor = System.Drawing.Color.White;
            this.cmbChuongTrinh.DisplayLayout.Appearance = appearance5;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.Caption = "Mã chương trình";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 104;
            ultraGridColumn5.Header.Caption = "Tên chương trình";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 413;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Hidden = true;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Hidden = true;
            ultraGridColumn9.Header.VisiblePosition = 8;
            ultraGridColumn9.Hidden = true;
            ultraGridColumn10.Header.VisiblePosition = 9;
            ultraGridColumn10.Hidden = true;
            ultraGridColumn11.Header.VisiblePosition = 10;
            ultraGridColumn12.Header.VisiblePosition = 11;
            ultraGridColumn13.Header.VisiblePosition = 12;
            ultraGridColumn14.Header.VisiblePosition = 13;
            ultraGridColumn15.Header.VisiblePosition = 14;
            ultraGridColumn16.Header.VisiblePosition = 15;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8,
            ultraGridColumn9,
            ultraGridColumn10,
            ultraGridColumn11,
            ultraGridColumn12,
            ultraGridColumn13,
            ultraGridColumn14,
            ultraGridColumn15,
            ultraGridColumn16});
            this.cmbChuongTrinh.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbChuongTrinh.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.cmbChuongTrinh.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.cmbChuongTrinh.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False;
            appearance1.BackColor = System.Drawing.Color.Transparent;
            this.cmbChuongTrinh.DisplayLayout.Override.CardAreaAppearance = appearance1;
            this.cmbChuongTrinh.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.cmbChuongTrinh.DisplayLayout.Override.ColumnAutoSizeMode = Infragistics.Win.UltraWinGrid.ColumnAutoSizeMode.AllRowsInBand;
            appearance2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.FontData.BoldAsString = "True";
            appearance2.FontData.Name = "Arial";
            appearance2.FontData.SizeInPoints = 10F;
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.cmbChuongTrinh.DisplayLayout.Override.HeaderAppearance = appearance2;
            this.cmbChuongTrinh.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance3.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance3.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbChuongTrinh.DisplayLayout.Override.RowSelectorAppearance = appearance3;
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance4.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbChuongTrinh.DisplayLayout.Override.SelectedRowAppearance = appearance4;
            this.cmbChuongTrinh.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.cmbChuongTrinh.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.cmbChuongTrinh.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;
            this.cmbChuongTrinh.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbChuongTrinh.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbChuongTrinh.DisplayLayout.TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl;
            this.cmbChuongTrinh.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;
            this.cmbChuongTrinh.DisplayMember = "TenChuongTrinh";
            this.cmbChuongTrinh.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbChuongTrinh.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChuongTrinh.Location = new System.Drawing.Point(98, 65);
            this.cmbChuongTrinh.Name = "cmbChuongTrinh";
            this.cmbChuongTrinh.Size = new System.Drawing.Size(281, 22);
            this.cmbChuongTrinh.TabIndex = 7;
            this.cmbChuongTrinh.ValueMember = "MaChuongTrinh";
            this.cmbChuongTrinh.ValueChanged += new System.EventHandler(this.cmbChuongTrinh_ValueChanged);
            // 
            // bdChuongTrinh
            // 
            this.bdChuongTrinh.DataSource = typeof(ERP_Library.ChuongTrinhList);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Chương trình";
            // 
            // frmChonThuLao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 280);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmChonThuLao";
            this.Text = "Chọn thù lao nhân viên";
            this.SaveXMLData += new System.ComponentModel.CancelEventHandler(this.frmChonThuLao_SaveXMLData);
            this.CreateXMLData += new System.EventHandler(this.frmChonThuLao_CreateXMLData);
            this.Load += new System.EventHandler(this.frmChonThuLao_Load);
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTuNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDenNgay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbChuongTrinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdChuongTrinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtTuNgay;
        private System.Windows.Forms.Label label4;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbNganHang;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cmbKyLuong;
        private System.Windows.Forms.Label lblNganHang;
        private System.Windows.Forms.Label label1;
        private Infragistics.Win.UltraWinEditors.UltraDateTimeEditor txtDenNgay;
        private System.Windows.Forms.Label label5;
        private Infragistics.Win.UltraWinGrid.UltraCombo cmbChuongTrinh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource bdChuongTrinh;
    }
}