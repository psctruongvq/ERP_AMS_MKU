namespace PSC_ERP
{
    partial class frmKhoaSo
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
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("Ky", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKy");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenKy");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayBatDau");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayKetThuc");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("KhoaSo");
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
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKhoaSo));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.label1 = new System.Windows.Forms.Label();
            this.KyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ultraCombo_Ky = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ubtThoat = new Infragistics.Win.Misc.UltraButton();
            this.ubtThucHien = new Infragistics.Win.Misc.UltraButton();
            this.lblTuNgay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.KyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_Ky)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(0, 12);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(279, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "Khi Thực Hiện Khóa Số Kế Toán Chứng Từ Không Cho Sửa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // KyBindingSource
            // 
            this.KyBindingSource.DataSource = typeof(ERP_Library.KyList);
            this.KyBindingSource.CurrentChanged += new System.EventHandler(this.KyBindingSource_CurrentChanged);
            // 
            // ultraCombo_Ky
            // 
            this.ultraCombo_Ky.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.ultraCombo_Ky.DataSource = this.KyBindingSource;
            appearance3.BackColor = System.Drawing.SystemColors.Window;
            appearance3.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.ultraCombo_Ky.DisplayLayout.Appearance = appearance3;
            appearance4.FontData.BoldAsString = "True";
            appearance4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance4.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn1.Header.Appearance = appearance4;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            appearance5.FontData.BoldAsString = "True";
            appearance5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance5.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn2.Header.Appearance = appearance5;
            ultraGridColumn2.Header.Caption = "Tên Kỳ";
            ultraGridColumn2.Header.VisiblePosition = 1;
            appearance6.FontData.BoldAsString = "True";
            appearance6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance6.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn3.Header.Appearance = appearance6;
            ultraGridColumn3.Header.Caption = "Ngày Bắt Đầu";
            ultraGridColumn3.Header.VisiblePosition = 2;
            appearance7.FontData.BoldAsString = "True";
            appearance7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance7.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn4.Header.Appearance = appearance7;
            ultraGridColumn4.Header.Caption = "Ngày Kết Thúc";
            ultraGridColumn4.Header.VisiblePosition = 3;
            appearance8.FontData.BoldAsString = "True";
            appearance8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            appearance8.ForeColorDisabled = System.Drawing.SystemColors.ActiveCaption;
            ultraGridColumn5.Header.Appearance = appearance8;
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
            appearance9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraCombo_Ky.DisplayLayout.GroupByBox.Appearance = appearance9;
            appearance10.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraCombo_Ky.DisplayLayout.GroupByBox.BandLabelAppearance = appearance10;
            this.ultraCombo_Ky.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance11.BackColor2 = System.Drawing.SystemColors.Control;
            appearance11.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance11.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ultraCombo_Ky.DisplayLayout.GroupByBox.PromptAppearance = appearance11;
            this.ultraCombo_Ky.DisplayLayout.MaxColScrollRegions = 1;
            this.ultraCombo_Ky.DisplayLayout.MaxRowScrollRegions = 1;
            appearance12.BackColor = System.Drawing.SystemColors.Window;
            appearance12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraCombo_Ky.DisplayLayout.Override.ActiveCellAppearance = appearance12;
            appearance13.BackColor = System.Drawing.SystemColors.Highlight;
            appearance13.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.ultraCombo_Ky.DisplayLayout.Override.ActiveRowAppearance = appearance13;
            this.ultraCombo_Ky.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.ultraCombo_Ky.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance14.BackColor = System.Drawing.SystemColors.Window;
            this.ultraCombo_Ky.DisplayLayout.Override.CardAreaAppearance = appearance14;
            appearance15.BorderColor = System.Drawing.Color.Silver;
            appearance15.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.ultraCombo_Ky.DisplayLayout.Override.CellAppearance = appearance15;
            this.ultraCombo_Ky.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.ultraCombo_Ky.DisplayLayout.Override.CellPadding = 0;
            appearance16.BackColor = System.Drawing.SystemColors.Control;
            appearance16.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance16.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.BorderColor = System.Drawing.SystemColors.Window;
            this.ultraCombo_Ky.DisplayLayout.Override.GroupByRowAppearance = appearance16;
            appearance17.TextHAlignAsString = "Left";
            this.ultraCombo_Ky.DisplayLayout.Override.HeaderAppearance = appearance17;
            this.ultraCombo_Ky.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.ultraCombo_Ky.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            appearance18.BorderColor = System.Drawing.Color.Silver;
            this.ultraCombo_Ky.DisplayLayout.Override.RowAppearance = appearance18;
            this.ultraCombo_Ky.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance19.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ultraCombo_Ky.DisplayLayout.Override.TemplateAddRowAppearance = appearance19;
            this.ultraCombo_Ky.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.ultraCombo_Ky.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.ultraCombo_Ky.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.ultraCombo_Ky.DisplayMember = "MaKy";
            this.ultraCombo_Ky.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Default;
            this.ultraCombo_Ky.Location = new System.Drawing.Point(91, 54);
            this.ultraCombo_Ky.Name = "ultraCombo_Ky";
            this.ultraCombo_Ky.Size = new System.Drawing.Size(80, 22);
            this.ultraCombo_Ky.TabIndex = 8;
            this.ultraCombo_Ky.ValueMember = "MaKy";
            // 
            // ubtThoat
            // 
            appearance2.Image = ((object)(resources.GetObject("appearance2.Image")));
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.ubtThoat.Appearance = appearance2;
            this.ubtThoat.Location = new System.Drawing.Point(160, 90);
            this.ubtThoat.Name = "ubtThoat";
            this.ubtThoat.Size = new System.Drawing.Size(81, 26);
            this.ubtThoat.TabIndex = 6;
            this.ubtThoat.Text = "Thoát";
            this.ubtThoat.Click += new System.EventHandler(this.ubtThoat_Click);
            // 
            // ubtThucHien
            // 
            appearance1.Image = ((object)(resources.GetObject("appearance1.Image")));
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Right;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Bottom;
            this.ubtThucHien.Appearance = appearance1;
            this.ubtThucHien.Location = new System.Drawing.Point(37, 90);
            this.ubtThucHien.Name = "ubtThucHien";
            this.ubtThucHien.Size = new System.Drawing.Size(82, 26);
            this.ubtThucHien.TabIndex = 7;
            this.ubtThucHien.Text = "Thực Hiện";
            this.ubtThucHien.Click += new System.EventHandler(this.ubtThucHien_Click);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(54, 56);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(19, 13);
            this.lblTuNgay.TabIndex = 5;
            this.lblTuNgay.Text = "Kỳ";
            // 
            // frmKhoaSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 135);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ultraCombo_Ky);
            this.Controls.Add(this.ubtThoat);
            this.Controls.Add(this.ubtThucHien);
            this.Controls.Add(this.lblTuNgay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmKhoaSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khóa Sổ Kế Toán";
            ((System.ComponentModel.ISupportInitialize)(this.KyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraCombo_Ky)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource KyBindingSource;
        private Infragistics.Win.UltraWinGrid.UltraCombo ultraCombo_Ky;
        private Infragistics.Win.Misc.UltraButton ubtThoat;
        private Infragistics.Win.Misc.UltraButton ubtThucHien;
        private System.Windows.Forms.Label lblTuNgay;
    }
}