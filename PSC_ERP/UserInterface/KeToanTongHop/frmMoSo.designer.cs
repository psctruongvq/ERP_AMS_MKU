namespace PSC_ERP
{
    partial class frmMoSo
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
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMoSo));
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Ky", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKy");
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenKy");
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayBatDau");
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKetThuc");
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSo");
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            this.ubtThoat = new Infragistics.Win.Misc.UltraButton();
            this.ubtThucHien = new Infragistics.Win.Misc.UltraButton();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ultraCombo_Ky = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.KyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_Ky)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ubtThoat
            // 
            appearance18.Image = ((object)(resources.GetObject("appearance18.Image")));
            appearance18.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance18.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.ubtThoat.Appearance = appearance18;
            this.ubtThoat.Location = new System.Drawing.Point(175, 83);
            this.ubtThoat.Name = "ubtThoat";
            this.ubtThoat.Size = new System.Drawing.Size(82, 26);
            this.ubtThoat.TabIndex = 12;
            this.ubtThoat.Text = "Thoát";
            this.ubtThoat.Click += new System.EventHandler(this.ubtThoat_Click);
            // 
            // ubtThucHien
            // 
            appearance19.Image = ((object)(resources.GetObject("appearance19.Image")));
            appearance19.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance19.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.ubtThucHien.Appearance = appearance19;
            this.ubtThucHien.Location = new System.Drawing.Point(45, 83);
            this.ubtThucHien.Name = "ubtThucHien";
            this.ubtThucHien.Size = new System.Drawing.Size(82, 26);
            this.ubtThucHien.TabIndex = 11;
            this.ubtThucHien.Text = "Thực Hiện";
            this.ubtThucHien.Click += new System.EventHandler(this.ubtThucHien_Click);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(62, 49);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(19, 13);
            this.lblTuNgay.TabIndex = 10;
            this.lblTuNgay.Text = "Kỳ";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(65, 6);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(159, 35);
            this.label1.TabIndex = 14;
            this.label1.Text = "Thực Hiện Mở Số Kế Toán ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ultraCombo_Ky
            // 
            this.ultraCombo_Ky.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ultraCombo_Ky.DataSource = this.KyBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ultraCombo_Ky.DisplayLayout.Appearance = appearance1;
            appearance20.FontData.BoldAsString = "True";
            appearance20.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance20.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn1.Header.Appearance = appearance20;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            appearance21.FontData.BoldAsString = "True";
            appearance21.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance21.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn2.Header.Appearance = appearance21;
            ultraGridColumn2.Header.Caption = "Tên Kỳ";
            ultraGridColumn2.Header.VisiblePosition = 1;
            appearance22.FontData.BoldAsString = "True";
            appearance22.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance22.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn3.Header.Appearance = appearance22;
            ultraGridColumn3.Header.Caption = "Ngày Bắt Đầu";
            ultraGridColumn3.Header.VisiblePosition = 2;
            appearance23.FontData.BoldAsString = "True";
            appearance23.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance23.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn4.Header.Appearance = appearance23;
            ultraGridColumn4.Header.Caption = "Ngày Kết Thúc";
            ultraGridColumn4.Header.VisiblePosition = 3;
            appearance24.FontData.BoldAsString = "True";
            appearance24.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance24.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn5.Header.Appearance = appearance24;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Hidden = true;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.ultraCombo_Ky.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.ultraCombo_Ky.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.ultraCombo_Ky.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance7.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraCombo_Ky.DisplayLayout.GroupByBox.Appearance = appearance7;
            appearance8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraCombo_Ky.DisplayLayout.GroupByBox.BandLabelAppearance = appearance8;
            this.ultraCombo_Ky.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance9.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance9.BackColor2 = System.Drawing.SystemColors.Control;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraCombo_Ky.DisplayLayout.GroupByBox.PromptAppearance = appearance9;
            this.ultraCombo_Ky.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraCombo_Ky.DisplayLayout.MaxRowScrollRegions = 1;
            appearance10.BackColor = System.Drawing.SystemColors.Window;
            appearance10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraCombo_Ky.DisplayLayout.Override.ActiveCellAppearance = appearance10;
            appearance11.BackColor = System.Drawing.SystemColors.Highlight;
            appearance11.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ultraCombo_Ky.DisplayLayout.Override.ActiveRowAppearance = appearance11;
            this.ultraCombo_Ky.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraCombo_Ky.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            this.ultraCombo_Ky.DisplayLayout.Override.CardAreaAppearance = appearance12;
            appearance13.BorderColor = System.Drawing.Color.Silver;
            appearance13.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ultraCombo_Ky.DisplayLayout.Override.CellAppearance = appearance13;
            this.ultraCombo_Ky.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ultraCombo_Ky.DisplayLayout.Override.CellPadding = 0;
            appearance14.BackColor = System.Drawing.SystemColors.Control;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraCombo_Ky.DisplayLayout.Override.GroupByRowAppearance = appearance14;
            appearance15.TextHAlignAsString = "Left";
            this.ultraCombo_Ky.DisplayLayout.Override.HeaderAppearance = appearance15;
            this.ultraCombo_Ky.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraCombo_Ky.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance16.BackColor = System.Drawing.SystemColors.Window;
            appearance16.BorderColor = System.Drawing.Color.Silver;
            this.ultraCombo_Ky.DisplayLayout.Override.RowAppearance = appearance16;
            this.ultraCombo_Ky.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance17.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ultraCombo_Ky.DisplayLayout.Override.TemplateAddRowAppearance = appearance17;
            this.ultraCombo_Ky.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraCombo_Ky.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraCombo_Ky.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraCombo_Ky.DisplayMember = "TenKy";
            this.ultraCombo_Ky.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.ultraCombo_Ky.Location = new System.Drawing.Point(99, 47);
            this.ultraCombo_Ky.Name = "ultraCombo_Ky";
            this.ultraCombo_Ky.Size = new System.Drawing.Size(80, 22);
            this.ultraCombo_Ky.TabIndex = 13;
            this.ultraCombo_Ky.ValueMember = "MaKy";
            // 
            // KyBindingSource
            // 
            this.KyBindingSource.DataSource = typeof(ERP_Library.KyList);
            this.KyBindingSource.CurrentChanged += new System.EventHandler(this.KyBindingSource_CurrentChanged);
            // 
            // frmMoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 141);
            this.Controls.Add(this.ubtThoat);
            this.Controls.Add(this.ubtThucHien);
            this.Controls.Add(this.lblTuNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ultraCombo_Ky);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMoSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mở Sổ Kế Toán ";
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_Ky)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ubtThoat;
        private Infragistics.Win.Misc.UltraButton ubtThucHien;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource KyBindingSource;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraCombo_Ky;
    }
}