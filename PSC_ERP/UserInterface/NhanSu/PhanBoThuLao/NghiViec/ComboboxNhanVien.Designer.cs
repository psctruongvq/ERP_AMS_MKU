namespace PSC_ERP
{
    partial class ComboboxNhanVien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVienComboListChild", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQLNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CardID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenChucVu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaBoPhan");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenBoPhan");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.cmbNhanVien = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.nhanVienComboListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienComboListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.CheckedListSettings.CheckStateMember = "";
            this.cmbNhanVien.DataSource = this.nhanVienComboListBindingSource;
            appearance7.BackColor = System.Drawing.SystemColors.ControlLight;
            appearance7.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.cmbNhanVien.DisplayLayout.Appearance = appearance7;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.Caption = "Mã nhân viên";
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Width = 89;
            ultraGridColumn3.Header.Caption = "Tên nhân viên";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 157;
            ultraGridColumn4.Header.Caption = "Card ID";
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Width = 86;
            ultraGridColumn5.Header.Caption = "Chức vụ";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 120;
            ultraGridColumn6.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Caption = "Bộ phận";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 122;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            this.cmbNhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.cmbNhanVien.DisplayLayout.InterBandSpacing = 10;
            this.cmbNhanVien.DisplayLayout.MaxColScrollRegions = 1;
            this.cmbNhanVien.DisplayLayout.MaxRowScrollRegions = 1;
            appearance8.BackColor = System.Drawing.Color.Transparent;
            this.cmbNhanVien.DisplayLayout.Override.CardAreaAppearance = appearance8;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlLightLight;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbNhanVien.DisplayLayout.Override.CellAppearance = appearance9;
            this.cmbNhanVien.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            appearance10.BackColor = System.Drawing.SystemColors.Control;
            appearance10.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance10.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            appearance10.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.cmbNhanVien.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.cmbNhanVien.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            appearance11.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.cmbNhanVien.DisplayLayout.Override.RowSelectorAppearance = appearance11;
            appearance12.BackColor = System.Drawing.SystemColors.InactiveCaption;
            appearance12.BackColor2 = System.Drawing.SystemColors.ActiveCaption;
            appearance12.BackGradientStyle = Infragistics.Win.GradientStyle.VerticalBump;
            this.cmbNhanVien.DisplayLayout.Override.SelectedRowAppearance = appearance12;
            this.cmbNhanVien.DisplayLayout.RowConnectorColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cmbNhanVien.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed;
            this.cmbNhanVien.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.cmbNhanVien.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.cmbNhanVien.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.cmbNhanVien.DisplayMember = "TenNhanVien";
            this.cmbNhanVien.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cmbNhanVien.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbNhanVien.Location = new System.Drawing.Point(0, 0);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(184, 22);
            this.cmbNhanVien.TabIndex = 0;
            this.cmbNhanVien.ValueMember = "MaNhanVien";
            this.cmbNhanVien.AfterCloseUp += new System.EventHandler(this.cmbNhanVien_AfterCloseUp);
            this.cmbNhanVien.Validated += new System.EventHandler(this.cmbNhanVien_Validated);
            // 
            // nhanVienComboListBindingSource
            // 
            this.nhanVienComboListBindingSource.DataSource = typeof(ERP_Library.NhanVienComboList);
            // 
            // ComboboxNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.cmbNhanVien);
            this.Name = "ComboboxNhanVien";
            this.Size = new System.Drawing.Size(184, 22);
            ((System.ComponentModel.ISupportInitialize)(this.cmbNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nhanVienComboListBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Infragistics.Win.UltraWinGrid.UltraCombo cmbNhanVien;
        private System.Windows.Forms.BindingSource nhanVienComboListBindingSource;
    }
}
