namespace PSC_ERP.ThanhToan
{
    partial class frmChonPhuCapCTV
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NganHang", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNganHang");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNganHang", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenVietTat");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChiNhanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenTinhThanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTinhThanh");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
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
            this.bdNganHang = new System.Windows.Forms.BindingSource(this.components);
            this.grdNganHang = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).BeginInit();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhomPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyPC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNganHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNganHang)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDienGiai
            // 
            this.txtDienGiai.Size = new System.Drawing.Size(576, 21);
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.grdNganHang);
            this.pnlData.Controls.Add(this.label5);
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
            this.pnlData.Size = new System.Drawing.Size(666, 333);
            // 
            // txtSoTien
            // 
            this.txtSoTien.Enabled = false;
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
            this.cmbNganHang.Location = new System.Drawing.Point(133, 57);
            this.cmbNganHang.Name = "cmbNganHang";
            this.cmbNganHang.Size = new System.Drawing.Size(152, 21);
            this.cmbNganHang.TabIndex = 9;
            this.cmbNganHang.ValueMember = "";
            this.cmbNganHang.ValueChanged += new System.EventHandler(this.cmbNganHang_ValueChanged);
            // 
            // lblNganHang
            // 
            this.lblNganHang.AutoSize = true;
            this.lblNganHang.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNganHang.Location = new System.Drawing.Point(11, 60);
            this.lblNganHang.Name = "lblNganHang";
            this.lblNganHang.Size = new System.Drawing.Size(108, 14);
            this.lblNganHang.TabIndex = 8;
            this.lblNganHang.Text = "Tiền mặt / Ngân hàng";
            // 
            // cmbKyLuong
            // 
            this.cmbKyLuong.DisplayMember = "TenKy";
            this.cmbKyLuong.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyLuong.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyLuong.Location = new System.Drawing.Point(98, 6);
            this.cmbKyLuong.Name = "cmbKyLuong";
            this.cmbKyLuong.Size = new System.Drawing.Size(187, 21);
            this.cmbKyLuong.TabIndex = 1;
            this.cmbKyLuong.ValueMember = "MaKy";
            this.cmbKyLuong.ValueChanged += new System.EventHandler(this.cmbKyLuong_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 14);
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
            this.cmbNhomPC.Location = new System.Drawing.Point(98, 32);
            this.cmbNhomPC.Name = "cmbNhomPC";
            this.cmbNhomPC.Size = new System.Drawing.Size(187, 21);
            this.cmbNhomPC.TabIndex = 5;
            this.cmbNhomPC.ValueMember = "MaNhom";
            this.cmbNhomPC.ValueChanged += new System.EventHandler(this.cmbNhomPC_ValueChanged);
            // 
            // lblNhomPC
            // 
            this.lblNhomPC.AutoSize = true;
            this.lblNhomPC.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhomPC.Location = new System.Drawing.Point(11, 35);
            this.lblNhomPC.Name = "lblNhomPC";
            this.lblNhomPC.Size = new System.Drawing.Size(76, 14);
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
            this.cmbPhuCap.Location = new System.Drawing.Point(370, 32);
            this.cmbPhuCap.Name = "cmbPhuCap";
            this.cmbPhuCap.Size = new System.Drawing.Size(283, 21);
            this.cmbPhuCap.TabIndex = 7;
            this.cmbPhuCap.ValueMember = "MaLoaiPhuCap";
            this.cmbPhuCap.ValueChanged += new System.EventHandler(this.cmbPhuCap_ValueChanged);
            // 
            // lblPhuCap
            // 
            this.lblPhuCap.AutoSize = true;
            this.lblPhuCap.Location = new System.Drawing.Point(303, 35);
            this.lblPhuCap.Name = "lblPhuCap";
            this.lblPhuCap.Size = new System.Drawing.Size(46, 14);
            this.lblPhuCap.TabIndex = 6;
            this.lblPhuCap.Text = "Phụ cấp";
            // 
            // cmbKyPC
            // 
            this.cmbKyPC.DisplayMember = "";
            this.cmbKyPC.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbKyPC.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.cmbKyPC.Location = new System.Drawing.Point(370, 6);
            this.cmbKyPC.Name = "cmbKyPC";
            this.cmbKyPC.Size = new System.Drawing.Size(283, 21);
            this.cmbKyPC.TabIndex = 3;
            this.cmbKyPC.ValueMember = "";
            this.cmbKyPC.ValueChanged += new System.EventHandler(this.cmbKyPC_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 14);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kỳ phụ cấp";
            // 
            // bdNganHang
            // 
            this.bdNganHang.DataSource = typeof(ERP_Library.NganHangList);
            // 
            // grdNganHang
            // 
            this.grdNganHang.DataSource = this.bdNganHang;
            appearance27.BackColor = System.Drawing.Color.White;
            this.grdNganHang.DisplayLayout.Appearance = appearance27;
            this.grdNganHang.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Width = 24;
            ultraGridColumn2.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 98;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 70;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 72;
            ultraGridColumn5.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 65;
            ultraGridColumn6.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Width = 65;
            ultraGridColumn7.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 72;
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Width = 80;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.grdNganHang.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdNganHang.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdNganHang.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance29.BorderColor = System.Drawing.SystemColors.Window;
            this.grdNganHang.DisplayLayout.GroupByBox.Appearance = appearance29;
            appearance30.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdNganHang.DisplayLayout.GroupByBox.BandLabelAppearance = appearance30;
            this.grdNganHang.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance31.BackColor2 = System.Drawing.SystemColors.Control;
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance31.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdNganHang.DisplayLayout.GroupByBox.PromptAppearance = appearance31;
            this.grdNganHang.DisplayLayout.MaxColScrollRegions = 1;
            this.grdNganHang.DisplayLayout.MaxRowScrollRegions = 1;
            appearance32.BackColor = System.Drawing.SystemColors.Window;
            appearance32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdNganHang.DisplayLayout.Override.ActiveCellAppearance = appearance32;
            appearance33.BackColor = System.Drawing.SystemColors.Highlight;
            appearance33.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdNganHang.DisplayLayout.Override.ActiveRowAppearance = appearance33;
            this.grdNganHang.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdNganHang.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.grdNganHang.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.None;
            this.grdNganHang.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.grdNganHang.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdNganHang.DisplayLayout.Override.AllowGroupBy = Infragistics.Win.DefaultableBoolean.False;
            this.grdNganHang.DisplayLayout.Override.AllowGroupMoving = Infragistics.Win.UltraWinGrid.AllowGroupMoving.NotAllowed;
            this.grdNganHang.DisplayLayout.Override.AllowGroupSwapping = Infragistics.Win.UltraWinGrid.AllowGroupSwapping.NotAllowed;
            this.grdNganHang.DisplayLayout.Override.AllowMultiCellOperations = Infragistics.Win.UltraWinGrid.AllowMultiCellOperation.None;
            this.grdNganHang.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;
            this.grdNganHang.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.grdNganHang.DisplayLayout.Override.AllowRowLayoutCellSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.grdNganHang.DisplayLayout.Override.AllowRowLayoutColMoving = Infragistics.Win.Layout.GridBagLayoutAllowMoving.None;
            this.grdNganHang.DisplayLayout.Override.AllowRowLayoutLabelSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            this.grdNganHang.DisplayLayout.Override.AllowRowLayoutLabelSpanSizing = Infragistics.Win.Layout.GridBagLayoutAllowSpanSizing.None;
            this.grdNganHang.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.False;
            this.grdNganHang.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grdNganHang.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdNganHang.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.grdNganHang.DisplayLayout.Override.CardAreaAppearance = appearance34;
            appearance35.BorderColor = System.Drawing.Color.Silver;
            appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdNganHang.DisplayLayout.Override.CellAppearance = appearance35;
            this.grdNganHang.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdNganHang.DisplayLayout.Override.CellPadding = 0;
            appearance36.BackColor = System.Drawing.SystemColors.Control;
            appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance36.BorderColor = System.Drawing.SystemColors.Window;
            this.grdNganHang.DisplayLayout.Override.GroupByRowAppearance = appearance36;
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance37.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance37.FontData.BoldAsString = "True";
            appearance37.FontData.Name = "Arial";
            appearance37.FontData.SizeInPoints = 10F;
            appearance37.ForeColor = System.Drawing.Color.White;
            appearance37.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdNganHang.DisplayLayout.Override.HeaderAppearance = appearance37;
            this.grdNganHang.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdNganHang.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance38.BackColor = System.Drawing.SystemColors.Window;
            appearance38.BorderColor = System.Drawing.Color.Silver;
            this.grdNganHang.DisplayLayout.Override.RowAppearance = appearance38;
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance39.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdNganHang.DisplayLayout.Override.RowSelectorAppearance = appearance39;
            this.grdNganHang.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance40.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdNganHang.DisplayLayout.Override.SelectedRowAppearance = appearance40;
            appearance41.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdNganHang.DisplayLayout.Override.TemplateAddRowAppearance = appearance41;
            this.grdNganHang.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdNganHang.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdNganHang.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grdNganHang.Location = new System.Drawing.Point(77, 84);
            this.grdNganHang.Name = "grdNganHang";
            this.grdNganHang.Size = new System.Drawing.Size(567, 243);
            this.grdNganHang.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ngân hàng";
            // 
            // frmChonPhuCapCTV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 497);
            this.Name = "frmChonPhuCapCTV";
            this.Text = "Chọn phụ cấp";
            this.SaveXMLData += new System.ComponentModel.CancelEventHandler(this.frmChonPhuCap_SaveXMLData);
            this.CreateXMLData += new System.EventHandler(this.frmChonPhuCap_CreateXMLData);
            this.Load += new System.EventHandler(this.frmChonPhuCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDienGiai)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._dataset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhomPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbKyPC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNganHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNganHang)).EndInit();
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
        private System.Windows.Forms.BindingSource bdNganHang;
        private Infragistics.Win.UltraWinGrid.UltraGrid grdNganHang;
        private System.Windows.Forms.Label label5;
    }
}