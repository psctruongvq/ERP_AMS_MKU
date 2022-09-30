namespace PSC_ERP
{
    partial class frmNhanVien_TrinhDoQuanLy
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("NhanVien_TrinhDoQuanLy", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenTrinhDoQuanLyNhaNuoc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TenTrinhDoQuanLyKinhTe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaTrinhDoQuanLy");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaNhanVien");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLyNhaNuoc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("MaQuanLyKinhTe");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("TrinhDoChinh");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            this.cbQuanLyNhaNuoc = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.QuanLyNhaNuoc_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbQuanLyKT = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.QuanLyKinhTe_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grd_DSDiaChiNhanVien = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.TrinhDoQuanLy_NhanVien_bindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cbQuanLyNhaNuoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyNhaNuoc_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbQuanLyKT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKinhTe_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrinhDoQuanLy_NhanVien_bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbQuanLyNhaNuoc
            // 
            this.cbQuanLyNhaNuoc.DataSource = this.QuanLyNhaNuoc_BindingSource;
            this.cbQuanLyNhaNuoc.DisplayMember = "TenQuanLyNhaNuoc";
            this.cbQuanLyNhaNuoc.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbQuanLyNhaNuoc.Location = new System.Drawing.Point(50, 208);
            this.cbQuanLyNhaNuoc.Name = "cbQuanLyNhaNuoc";
            this.cbQuanLyNhaNuoc.Size = new System.Drawing.Size(207, 21);
            this.cbQuanLyNhaNuoc.TabIndex = 46;
            this.cbQuanLyNhaNuoc.ValueMember = "MaQuaLyNhaNuoc";
            // 
            // QuanLyNhaNuoc_BindingSource
            // 
            this.QuanLyNhaNuoc_BindingSource.DataSource = typeof(ERP_Library.QuanLyNhaNuocList);
            // 
            // cbQuanLyKT
            // 
            this.cbQuanLyKT.DataSource = this.QuanLyKinhTe_BindingSource;
            this.cbQuanLyKT.DisplayMember = "TenQuanLyKinhTe";
            this.cbQuanLyKT.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2007;
            this.cbQuanLyKT.Location = new System.Drawing.Point(2, 245);
            this.cbQuanLyKT.Name = "cbQuanLyKT";
            this.cbQuanLyKT.Size = new System.Drawing.Size(207, 21);
            this.cbQuanLyKT.TabIndex = 46;
            this.cbQuanLyKT.ValueMember = "MaQuanLyKinhTe";
            // 
            // QuanLyKinhTe_BindingSource
            // 
            this.QuanLyKinhTe_BindingSource.DataSource = typeof(ERP_Library.QuanLyKinhTeList);
            // 
            // grd_DSDiaChiNhanVien
            // 
            this.grd_DSDiaChiNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_DSDiaChiNhanVien.DataSource = this.TrinhDoQuanLy_NhanVien_bindingSource;
            appearance3.BackColor = System.Drawing.Color.White;
            this.grd_DSDiaChiNhanVien.DisplayLayout.Appearance = appearance3;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn2.Header.VisiblePosition = 2;
            ultraGridColumn3.Header.VisiblePosition = 1;
            ultraGridColumn4.CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            ultraGridColumn4.Header.VisiblePosition = 5;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.VisiblePosition = 6;
            ultraGridColumn6.Header.VisiblePosition = 3;
            ultraGridColumn7.Header.VisiblePosition = 4;
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
            // 
            // TrinhDoQuanLy_NhanVien_bindingSource
            // 
            this.TrinhDoQuanLy_NhanVien_bindingSource.AllowNew = true;
            this.TrinhDoQuanLy_NhanVien_bindingSource.DataSource = typeof(ERP_Library.NhanVien_TrinhDoQuanLyList);
            // 
            // frmNhanVien_TrinhDoQuanLy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 278);
            this.Controls.Add(this.grd_DSDiaChiNhanVien);
            this.Controls.Add(this.cbQuanLyNhaNuoc);
            this.Controls.Add(this.cbQuanLyKT);
            this.Name = "frmNhanVien_TrinhDoQuanLy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trình Độ Quản Lý";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNhanVien_TrinhDoQuanLy_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.cbQuanLyNhaNuoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyNhaNuoc_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbQuanLyKT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyKinhTe_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_DSDiaChiNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrinhDoQuanLy_NhanVien_bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource TrinhDoQuanLy_NhanVien_bindingSource;
        private Infragistics.Win.UltraWinGrid.UltraGrid grd_DSDiaChiNhanVien;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbQuanLyKT;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor cbQuanLyNhaNuoc;
        private System.Windows.Forms.BindingSource QuanLyKinhTe_BindingSource;
        private System.Windows.Forms.BindingSource QuanLyNhaNuoc_BindingSource;
    }
}