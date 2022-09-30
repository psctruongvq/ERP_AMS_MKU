namespace PSC_ERP
{
    partial class frmXacNhanThongTuMauBaoCao
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("ThoiDiemApDungThongTuMauKeToanTongHop", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Id");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaKy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NoiDung");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("GhiChu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgayApDung");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.label1 = new System.Windows.Forms.Label();
            this.cbu_ThoiDiemApDungMauKeToanTongHop = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.ThoiDiemApDungMauKeToanTongHopbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.radioBtnThongTu = new System.Windows.Forms.RadioButton();
            this.radioBtnNHNN = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cbu_ThoiDiemApDungMauKeToanTongHop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThoiDiemApDungMauKeToanTongHopbindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tư";
            // 
            // cbu_ThoiDiemApDungMauKeToanTongHop
            // 
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DataSource = this.ThoiDiemApDungMauKeToanTongHopbindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5});
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.MaxColScrollRegions = 1;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.CellAppearance = appearance8;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.RowAppearance = appearance11;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.DisplayMember = "NoiDung";
            this.cbu_ThoiDiemApDungMauKeToanTongHop.Location = new System.Drawing.Point(69, 21);
            this.cbu_ThoiDiemApDungMauKeToanTongHop.Name = "cbu_ThoiDiemApDungMauKeToanTongHop";
            this.cbu_ThoiDiemApDungMauKeToanTongHop.Size = new System.Drawing.Size(276, 22);
            this.cbu_ThoiDiemApDungMauKeToanTongHop.TabIndex = 35;
            this.cbu_ThoiDiemApDungMauKeToanTongHop.ValueMember = "Id";
            this.cbu_ThoiDiemApDungMauKeToanTongHop.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.cbu_ThoiDiemApDungMauKeToanTongHop_InitializeLayout);
            // 
            // ThoiDiemApDungMauKeToanTongHopbindingSource
            // 
            this.ThoiDiemApDungMauKeToanTongHopbindingSource.DataSource = typeof(ERP_Library.ThoiDiemApDungThongTuMauKeToanTongHopList);
            // 
            // radioBtnThongTu
            // 
            this.radioBtnThongTu.AutoSize = true;
            this.radioBtnThongTu.Checked = true;
            this.radioBtnThongTu.Location = new System.Drawing.Point(45, 19);
            this.radioBtnThongTu.Name = "radioBtnThongTu";
            this.radioBtnThongTu.Size = new System.Drawing.Size(72, 17);
            this.radioBtnThongTu.TabIndex = 36;
            this.radioBtnThongTu.TabStop = true;
            this.radioBtnThongTu.Text = "Thông Tư";
            this.radioBtnThongTu.UseVisualStyleBackColor = true;
            // 
            // radioBtnNHNN
            // 
            this.radioBtnNHNN.AutoSize = true;
            this.radioBtnNHNN.Location = new System.Drawing.Point(45, 42);
            this.radioBtnNHNN.Name = "radioBtnNHNN";
            this.radioBtnNHNN.Size = new System.Drawing.Size(146, 17);
            this.radioBtnNHNN.TabIndex = 37;
            this.radioBtnNHNN.Text = "Ngân Hàng Nông Nghiệp";
            this.radioBtnNHNN.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnThongTu);
            this.groupBox1.Controls.Add(this.radioBtnNHNN);
            this.groupBox1.Location = new System.Drawing.Point(69, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 69);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mẫu của";
            this.groupBox1.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(156, 153);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 39;
            this.btnOK.Text = "Xem Mẫu";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmXacNhanThongTuMauBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 213);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbu_ThoiDiemApDungMauKeToanTongHop);
            this.Name = "frmXacNhanThongTuMauBaoCao";
            this.Text = "Xác Nhận Thông Tư Mẫu Báo Cáo";
            ((System.ComponentModel.ISupportInitialize)(this.cbu_ThoiDiemApDungMauKeToanTongHop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ThoiDiemApDungMauKeToanTongHopbindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource ThoiDiemApDungMauKeToanTongHopbindingSource;
        private Infragistics.Win.UltraWinGrid.UltraCombo cbu_ThoiDiemApDungMauKeToanTongHop;
        private System.Windows.Forms.RadioButton radioBtnThongTu;
        private System.Windows.Forms.RadioButton radioBtnNHNN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnOK;
    }
}