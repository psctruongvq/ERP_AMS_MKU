namespace PSC_ERP
{
    partial class frmNhanVien_NgoaiNgu
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVien_NgoaiNgu", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenNgoaiNgu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenTrinhDoNN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ManhanvienNgoaingu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNgoaiNgu");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTrinhDoNN");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("NgoaiNguChinh");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.cbNgoaiNgu = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.NgoaiNgu_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbTrinhDoNgoaiNgu = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.TrinhDoNgoaiNgu_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grd_DSDiaChiNhanVien = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.NgoaiNgu_NhanVien_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cbNgoaiNgu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgoaiNgu_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTrinhDoNgoaiNgu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrinhDoNgoaiNgu_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgoaiNgu_NhanVien_bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbNgoaiNgu
            // 
            this.cbNgoaiNgu.DataSource = this.NgoaiNgu_BindingSource;
            this.cbNgoaiNgu.DisplayMember = "TenNgoaiNgu";
            this.cbNgoaiNgu.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbNgoaiNgu.Location = new System.Drawing.Point(50, 208);
            this.cbNgoaiNgu.Name = "cbNgoaiNgu";
            this.cbNgoaiNgu.Size = new System.Drawing.Size(207, 21);
            this.cbNgoaiNgu.TabIndex = 46;
            this.cbNgoaiNgu.ValueMember = "MaNgoaiNgu";
            // 
            // NgoaiNgu_BindingSource
            // 
            this.NgoaiNgu_BindingSource.DataSource = typeof(ERP_Library.NgoaiNguList);
            // 
            // cbTrinhDoNgoaiNgu
            // 
            this.cbTrinhDoNgoaiNgu.DataSource = this.TrinhDoNgoaiNgu_BindingSource;
            this.cbTrinhDoNgoaiNgu.DisplayMember = "TrinhDoNgoaiNgu";
            this.cbTrinhDoNgoaiNgu.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbTrinhDoNgoaiNgu.Location = new System.Drawing.Point(2, 245);
            this.cbTrinhDoNgoaiNgu.Name = "cbTrinhDoNgoaiNgu";
            this.cbTrinhDoNgoaiNgu.Size = new System.Drawing.Size(207, 21);
            this.cbTrinhDoNgoaiNgu.TabIndex = 46;
            this.cbTrinhDoNgoaiNgu.ValueMember = "MaTrinhDoNN";
            // 
            // TrinhDoNgoaiNgu_BindingSource
            // 
            this.TrinhDoNgoaiNgu_BindingSource.DataSource = typeof(ERP_Library.TrinhDoNgoaiNguClassList);
            // 
            // grd_DSDiaChiNhanVien
            // 
            this.grd_DSDiaChiNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_DSDiaChiNhanVien.DataSource = this.NgoaiNgu_NhanVien_bindingSource;
            appearance3.BackColor = System.Drawing.Color.White;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.Header.VisiblePosition = 2;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 3;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.VisiblePosition = 4;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 5;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Caption = "Ngoại Ngữ";
            ultraGridColumn5.Header.VisiblePosition = 0;
            ultraGridColumn5.Width = 200;
            ultraGridColumn6.Header.Caption = "Trình Độ";
            ultraGridColumn6.Header.VisiblePosition = 1;
            ultraGridColumn6.Width = 200;
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7});
            this.grd_DSDiaChiNhanVien.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.grd_DSDiaChiNhanVien.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.Yes;
            appearance4.BackColor = System.Drawing.Color.Transparent;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.CardAreaAppearance = appearance4;
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance5.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance5.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance5.FontData.BoldAsString = "True";
            appearance5.FontData.Name = "Arial";
            appearance5.FontData.SizeInPoints = 10F;
            appearance5.ForeColor = System.Drawing.Color.White;
            appearance5.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderAppearance = appearance5;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(192)))), ((int)(((byte)(130)))));
            appearance6.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(122)))), ((int)(((byte)(68)))));
            appearance6.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.RowSelectorAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance7.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance7.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Override.SelectedRowAppearance = appearance7;
            this.grd_DSDiaChiNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.grd_DSDiaChiNhanVien.Location = new System.Drawing.Point(2, -1);
            this.grd_DSDiaChiNhanVien.Name = "grd_DSDiaChiNhanVien";
            this.grd_DSDiaChiNhanVien.Size = new System.Drawing.Size(555, 281);
            this.grd_DSDiaChiNhanVien.TabIndex = 45;
            this.grd_DSDiaChiNhanVien.InitializeLayout += new Infragistics.Win.UltraWinGrid.InitializeLayoutEventHandler(this.grd_DSDiaChiNhanVien_InitializeLayout);
            this.grd_DSDiaChiNhanVien.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.grd_DSDiaChiNhanVien_CellChange);
            // 
            // NgoaiNgu_NhanVien_bindingSource
            // 
            this.NgoaiNgu_NhanVien_bindingSource.AllowNew = true;
            this.NgoaiNgu_NhanVien_bindingSource.DataSource = typeof(ERP_Library.NhanVien_NgoaiNguList);
            // 
            // frmNhanVien_NgoaiNgu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 278);
            this.Controls.Add(this.grd_DSDiaChiNhanVien);
            this.Controls.Add(this.cbNgoaiNgu);
            this.Controls.Add(this.cbTrinhDoNgoaiNgu);
            this.Name = "frmNhanVien_NgoaiNgu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trình Độ Ngoại Ngữ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanVien_NgoaiNgu_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.cbNgoaiNgu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgoaiNgu_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTrinhDoNgoaiNgu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrinhDoNgoaiNgu_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NgoaiNgu_NhanVien_bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource NgoaiNgu_NhanVien_bindingSource;
        private Infragistics.Win.UltraWinGrid.UltraGrid grd_DSDiaChiNhanVien;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbTrinhDoNgoaiNgu;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbNgoaiNgu;
        private System.Windows.Forms.BindingSource TrinhDoNgoaiNgu_BindingSource;
        private System.Windows.Forms.BindingSource NgoaiNgu_BindingSource;
    }
}