namespace PSC_ERP.Security
{
    partial class frmUserThuLao
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
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("UserThuLaoChild", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("UserID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NguoiLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNguoiLap");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Chon");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
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
            this.grdNguoiLap = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.bdNguoiLap = new System.Windows.Forms.BindingSource(this.components);
            this.chkALL = new Infragistics.Win.UltraWinEditors.UltraCheckEditor();
            ((System.ComponentModel.ISupportInitialize)(this.grdNguoiLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNguoiLap)).BeginInit();
            this.SuspendLayout();
            // 
            // grdNguoiLap
            // 
            this.grdNguoiLap.DataSource = this.bdNguoiLap;
            appearance27.BackColor = System.Drawing.Color.White;
            this.grdNguoiLap.DisplayLayout.Appearance = appearance27;
            this.grdNguoiLap.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn1.Width = 261;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn2.Width = 420;
            ultraGridColumn3.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn3.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            ultraGridColumn3.Header.Caption = "Người lập";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 227;
            appearance2.TextHAlignAsString = "Right";
            ultraGridColumn4.Header.Appearance = appearance2;
            ultraGridColumn4.Header.Caption = "Chọn";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 88;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4});
            this.grdNguoiLap.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grdNguoiLap.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.grdNguoiLap.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance29.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance29.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance29.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance29.BorderColor = System.Drawing.SystemColors.Window;
            this.grdNguoiLap.DisplayLayout.GroupByBox.Appearance = appearance29;
            appearance30.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdNguoiLap.DisplayLayout.GroupByBox.BandLabelAppearance = appearance30;
            this.grdNguoiLap.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance31.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance31.BackColor2 = System.Drawing.SystemColors.Control;
            appearance31.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance31.ForeColor = System.Drawing.SystemColors.GrayText;
            this.grdNguoiLap.DisplayLayout.GroupByBox.PromptAppearance = appearance31;
            this.grdNguoiLap.DisplayLayout.MaxColScrollRegions = 1;
            this.grdNguoiLap.DisplayLayout.MaxRowScrollRegions = 1;
            appearance32.BackColor = System.Drawing.SystemColors.Window;
            appearance32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdNguoiLap.DisplayLayout.Override.ActiveCellAppearance = appearance32;
            appearance33.BackColor = System.Drawing.SystemColors.Highlight;
            appearance33.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.grdNguoiLap.DisplayLayout.Override.ActiveRowAppearance = appearance33;
            this.grdNguoiLap.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.grdNguoiLap.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.grdNguoiLap.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.grdNguoiLap.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.grdNguoiLap.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance34.BackColor = System.Drawing.Color.Transparent;
            this.grdNguoiLap.DisplayLayout.Override.CardAreaAppearance = appearance34;
            appearance35.BorderColor = System.Drawing.Color.Silver;
            appearance35.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.grdNguoiLap.DisplayLayout.Override.CellAppearance = appearance35;
            this.grdNguoiLap.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.grdNguoiLap.DisplayLayout.Override.CellPadding = 0;
            appearance36.BackColor = System.Drawing.SystemColors.Control;
            appearance36.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance36.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance36.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance36.BorderColor = System.Drawing.SystemColors.Window;
            this.grdNguoiLap.DisplayLayout.Override.GroupByRowAppearance = appearance36;
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance37.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance37.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance37.FontData.BoldAsString = "True";
            appearance37.FontData.Name = "Arial";
            appearance37.FontData.SizeInPoints = 10F;
            appearance37.ForeColor = System.Drawing.Color.White;
            appearance37.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grdNguoiLap.DisplayLayout.Override.HeaderAppearance = appearance37;
            this.grdNguoiLap.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.grdNguoiLap.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance38.BackColor = System.Drawing.SystemColors.Window;
            appearance38.BorderColor = System.Drawing.Color.Silver;
            this.grdNguoiLap.DisplayLayout.Override.RowAppearance = appearance38;
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance39.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance39.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdNguoiLap.DisplayLayout.Override.RowSelectorAppearance = appearance39;
            this.grdNguoiLap.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance40.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance40.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grdNguoiLap.DisplayLayout.Override.SelectedRowAppearance = appearance40;
            appearance41.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grdNguoiLap.DisplayLayout.Override.TemplateAddRowAppearance = appearance41;
            this.grdNguoiLap.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.grdNguoiLap.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.grdNguoiLap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdNguoiLap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grdNguoiLap.Location = new System.Drawing.Point(0, 0);
            this.grdNguoiLap.Name = "grdNguoiLap";
            this.grdNguoiLap.Size = new System.Drawing.Size(336, 472);
            this.grdNguoiLap.TabIndex = 0;
            // 
            // bdNguoiLap
            // 
            this.bdNguoiLap.DataSource = typeof(ERP_Library.Security.UserThuLaoList);
            // 
            // chkALL
            // 
            this.chkALL.BackColor = System.Drawing.Color.Transparent;
            this.chkALL.BackColorInternal = System.Drawing.Color.Transparent;
            this.chkALL.Location = new System.Drawing.Point(264, 8);
            this.chkALL.Name = "chkALL";
            this.chkALL.Size = new System.Drawing.Size(13, 13);
            this.chkALL.TabIndex = 1;
            this.chkALL.CheckedChanged += new System.EventHandler(this.chkALL_CheckedChanged);
            // 
            // frmUserThuLao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 472);
            this.Controls.Add(this.chkALL);
            this.Controls.Add(this.grdNguoiLap);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserThuLao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quyền đề nghị chuyển khoản thù lao";
            ((System.ComponentModel.ISupportInitialize)(this.grdNguoiLap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdNguoiLap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraGrid grdNguoiLap;
        private System.Windows.Forms.BindingSource bdNguoiLap;
        private Infragistics.Win.UltraWinEditors.UltraCheckEditor chkALL;
    }
}